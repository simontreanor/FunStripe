namespace Stripe.Ephemeral

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type EphemeralKey =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Time at which the key will expire. Measured in seconds since the Unix epoch.
        Expires: DateTime
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The key's secret. You can use this value to make authorized requests to the Stripe API.
        Secret: string option
    }

module EphemeralKey =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "ephemeral_key"

