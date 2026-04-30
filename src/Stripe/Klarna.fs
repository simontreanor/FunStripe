namespace Stripe.Klarna

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type KlarnaAddress =
    {
        /// The payer address country
        Country: IsoTypes.IsoCountryCode option
    }

type KlarnaPayerDetails =
    {
        /// The payer's address
        Address: KlarnaAddress option
    }

