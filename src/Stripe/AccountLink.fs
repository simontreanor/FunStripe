namespace Stripe.AccountLink

open System.Text.Json.Serialization
open FunStripe
open System

/// Account Links are the means by which a Connect platform grants a connected account permission to access
/// Stripe-hosted applications, such as Connect Onboarding.
/// Related guide: [Connect Onboarding](https://docs.stripe.com/connect/custom/hosted-onboarding)
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type AccountLink =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The timestamp at which this account link will expire.
        ExpiresAt: DateTime
        /// The URL for the account link.
        Url: string
    }

type AccountLink with
    static member New(created: DateTime, expiresAt: DateTime, url: string) =
        {
            Created = created
            ExpiresAt = expiresAt
            Url = url
        }

module AccountLink =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "account_link"

