namespace Stripe.Klarna

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type KlarnaAddress =
    {
        /// The payer address country
        Country: IsoTypes.IsoCountryCode option
    }

