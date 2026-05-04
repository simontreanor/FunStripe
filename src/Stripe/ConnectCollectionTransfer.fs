namespace Stripe.ConnectCollectionTransfer

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type ConnectCollectionTransfer =
    {
        /// Amount transferred, in cents (or local equivalent).
        Amount: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// ID of the account that funds are being collected for.
        Destination: StripeId<Markers.Account>
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
    }

type ConnectCollectionTransfer with
    static member New(amount: int, currency: IsoTypes.IsoCurrencyCode, destination: StripeId<Markers.Account>, id: string, livemode: bool) =
        {
            Amount = amount
            Currency = currency
            Destination = destination
            Id = id
            Livemode = livemode
        }

module ConnectCollectionTransfer =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "connect_collection_transfer"

