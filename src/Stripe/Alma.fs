namespace Stripe.Alma

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type AlmaInstallments =
    {
        /// The number of installments.
        Count: int
    }

module AlmaInstallments =
    let create
        (
            count: int
        ) : AlmaInstallments
        =
        {
          Count = count
        }

