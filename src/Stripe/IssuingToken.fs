namespace Stripe.IssuingToken

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Issuing

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type IssuingTokenNetwork =
    | Mastercard
    | Visa

[<Struct>]
type IssuingTokenStatus =
    | Active
    | Deleted
    | Requested
    | Suspended

[<Struct>]
type IssuingTokenWalletProvider =
    | ApplePay
    | GooglePay
    | SamsungPay

/// An issuing token object is created when an issued card is added to a digital wallet. As a [card issuer](https://docs.stripe.com/issuing), you can [view and manage these tokens](https://docs.stripe.com/issuing/controls/token-management) through Stripe.
type IssuingToken =
    {
        /// Card associated with this token.
        Card: string
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The hashed ID derived from the device ID from the card network associated with the token.
        DeviceFingerprint: string option
        /// Unique identifier for the object.
        Id: string
        /// The last four digits of the token.
        [<JsonPropertyName("last4")>]
        Last4: string option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The token service provider / card network associated with the token.
        Network: IssuingTokenNetwork
        NetworkData: IssuingNetworkTokenNetworkData option
        /// Time at which the token was last updated by the card network. Measured in seconds since the Unix epoch.
        NetworkUpdatedAt: DateTime
        /// The usage state of the token.
        Status: IssuingTokenStatus
        /// The digital wallet for this token, if one was used.
        WalletProvider: IssuingTokenWalletProvider option
    }

module IssuingToken =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "issuing.token"

/// Occurs whenever an issuing digital wallet token is updated.
type IssuingTokenUpdated = { Object: IssuingToken }

/// Occurs whenever an issuing digital wallet token is created.
type IssuingTokenCreated = { Object: IssuingToken }

