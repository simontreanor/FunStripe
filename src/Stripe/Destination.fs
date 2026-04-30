namespace Stripe.Destination

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type DestinationDetailsUnimplemented =
    { DestinationDetailsUnimplemented: string option }

module DestinationDetailsUnimplemented =
    let create
        (
            destinationDetailsUnimplemented: string option option
        ) : DestinationDetailsUnimplemented
        =
        {
          DestinationDetailsUnimplemented = destinationDetailsUnimplemented |> Option.flatten
        }

