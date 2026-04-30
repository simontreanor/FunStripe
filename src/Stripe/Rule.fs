namespace Stripe.Rule

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type Rule =
    {
        /// The action taken on the payment.
        Action: string
        /// Unique identifier for the object.
        Id: string
        /// The predicate to evaluate the payment against.
        Predicate: string
    }

module Rule =
    let create
        (
            action: string,
            id: string,
            predicate: string
        ) : Rule
        =
        {
          Action = action
          Id = id
          Predicate = predicate
        }

