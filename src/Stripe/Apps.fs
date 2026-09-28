namespace Stripe.Apps

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.5.0")>]
type AppServiceResourceInstallContentSecurityPolicy =
    {
        /// The URLs that the app can make network requests to.
        ConnectSrc: string list
        /// The URLs that the app can load images from.
        ImageSrc: string list
    }

type AppServiceResourceInstallContentSecurityPolicy with
    static member New(connectSrc: string list, imageSrc: string list) =
        {
            ConnectSrc = connectSrc
            ImageSrc = imageSrc
        }

[<Struct>]
type AppsInstallChannel =
    | PrivateLive
    | PrivateTest
    | Public
    | Review
    | Testing

[<Struct>]
type AppsInstallStatus =
    | InstallFailed
    | Installed
    | Installing
    | UninstallFailed
    | Uninstalling

/// An app install represents a Stripe App that is installed on an account. It reports the permissions,
/// content security policy entries, and endpoints that the installing account has authorized, along with any
/// that the app's latest version requests but the account has not authorized yet. Use the Install API to
/// install, reauthorize, and uninstall apps, and to check the state of existing installs.
type AppsInstall =
    {
        /// The ID of the account that the app install belongs to.
        Account: string
        /// The ID of the app installed.
        App: string
        /// Whether the installer must authorize pending permissions, content security policy entries, or endpoints. For private apps, `approval_required` stays `false`. Install a new version from the Dashboard to grant its permissions.
        ApprovalRequired: bool
        /// The authorization code for an oauth app install.
        AuthCode: string option
        /// The distribution channel associated with the app install.
        Channel: AppsInstallChannel
        ContentSecurityPolicyGranted: AppServiceResourceInstallContentSecurityPolicy
        ContentSecurityPolicyPending: AppServiceResourceInstallContentSecurityPolicy
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The ID of the embedding platform that created the install, if applicable.
        CreatedBy: string option
        /// The endpoint URLs authorized by the installer.
        EndpointsGranted: string list
        /// The endpoint URLs requested by the latest app version that the installer has not authorized.
        EndpointsPending: string list
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The permissions authorized by the installer.
        PermissionsGranted: string list
        /// The permissions requested by the latest app version that the installer has not authorized.
        PermissionsPending: string list
        /// The status of the app install.
        Status: AppsInstallStatus
    }

type AppsInstall with
    static member New(account: string, app: string, approvalRequired: bool, authCode: string option, channel: AppsInstallChannel, contentSecurityPolicyGranted: AppServiceResourceInstallContentSecurityPolicy, contentSecurityPolicyPending: AppServiceResourceInstallContentSecurityPolicy, created: DateTime, createdBy: string option, endpointsGranted: string list, endpointsPending: string list, id: string, livemode: bool, permissionsGranted: string list, permissionsPending: string list, status: AppsInstallStatus) =
        {
            Account = account
            App = app
            ApprovalRequired = approvalRequired
            AuthCode = authCode
            Channel = channel
            ContentSecurityPolicyGranted = contentSecurityPolicyGranted
            ContentSecurityPolicyPending = contentSecurityPolicyPending
            Created = created
            CreatedBy = createdBy
            EndpointsGranted = endpointsGranted
            EndpointsPending = endpointsPending
            Id = id
            Livemode = livemode
            PermissionsGranted = permissionsGranted
            PermissionsPending = permissionsPending
            Status = status
        }

module AppsInstall =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "apps.install"

/// Occurs whenever a user installs a Stripe app. Sent to the app developer, embedding platform, and installing merchant.
type AppsInstallCreated = { Object: AppsInstall }

type AppsInstallCreated with
    static member New(object: AppsInstall) =
        {
            Object = object
        }

/// Occurs whenever a user uninstalls a Stripe app. Sent to the app developer, embedding platform, and installing merchant.
type AppsInstallDeleted = { Object: AppsInstall }

type AppsInstallDeleted with
    static member New(object: AppsInstall) =
        {
            Object = object
        }

/// Occurs whenever a user updates a Stripe app. Sent to the app developer, embedding platform, and installing merchant.
type AppsInstallUpdated = { Object: AppsInstall }

type AppsInstallUpdated with
    static member New(object: AppsInstall) =
        {
            Object = object
        }

[<Struct>]
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

