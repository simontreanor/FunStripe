namespace Stripe.Internal

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type InternalCard =
    {
        /// Brand of the card used in the transaction
        Brand: string option
        /// Two-letter ISO code representing the country of the card
        Country: IsoTypes.IsoCountryCode option
        /// Two digit number representing the card's expiration month
        ExpMonth: int option
        /// Two digit number representing the card's expiration year
        ExpYear: int option
        /// The last 4 digits of the card
        [<JsonPropertyName("last4")>]
        Last4: string option
    }

