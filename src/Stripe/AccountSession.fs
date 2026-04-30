namespace Stripe.AccountSession

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

/// An AccountSession allows a Connect platform to grant access to a connected account in Connect embedded components.
/// We recommend that you create an AccountSession each time you need to display an embedded component
/// to your user. Do not save AccountSessions to your database as they expire relatively
/// quickly, and cannot be used more than once.
/// Related guide: [Connect embedded components](https://docs.stripe.com/connect/get-started-connect-embedded-components)
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type AccountSession =
    {
        /// The ID of the account the AccountSession was created for
        Account: string
        /// The client secret of this AccountSession. Used on the client to set up secure access to the given `account`.
        /// The client secret can be used to provide access to `account` from your frontend. It should not be stored, logged, or exposed to anyone other than the connected account. Make sure that you have TLS enabled on any page that includes the client secret.
        /// Refer to our docs to [setup Connect embedded components](https://docs.stripe.com/connect/get-started-connect-embedded-components) and learn about how `client_secret` should be handled.
        ClientSecret: string
        Components: ConnectEmbeddedAccountSessionCreateComponents
        /// The timestamp at which this AccountSession will expire.
        ExpiresAt: DateTime
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
    }

module AccountSession =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "account_session"

