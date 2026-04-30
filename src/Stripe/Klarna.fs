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

module KlarnaAddress =
    let create
        (
            country: IsoTypes.IsoCountryCode option
        ) : KlarnaAddress
        =
        {
          Country = country
        }

type KlarnaPayerDetails =
    {
        /// The payer's address
        Address: KlarnaAddress option
    }

module KlarnaPayerDetails =
    let create
        (
            address: KlarnaAddress option
        ) : KlarnaPayerDetails
        =
        {
          Address = address
        }

