namespace Stripe.ReserveTransaction

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type ReserveTransaction =
    {
        Amount: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        /// Unique identifier for the object.
        Id: string
    }

module ReserveTransaction =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "reserve_transaction"

