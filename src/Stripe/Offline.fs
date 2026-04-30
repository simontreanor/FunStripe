namespace Stripe.Offline

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type OfflineAcceptance = { OfflineAcceptance: string option }

module OfflineAcceptance =
    let create
        (
            offlineAcceptance: string option option
        ) : OfflineAcceptance
        =
        {
          OfflineAcceptance = offlineAcceptance |> Option.flatten
        }

