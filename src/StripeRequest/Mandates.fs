namespace StripeRequest.Mandates

open FunStripe
open System.Text.Json.Serialization
open Stripe.Mandate
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
module Mandates =

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Mandate: string
        }

    type RetrieveOptions with
        static member New(mandate: string, ?expand: string list) =
            {
                Mandate = mandate
                Expand = expand
            }

    ///<p>Retrieves a Mandate object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/mandates/{options.Mandate}"
        |> RestApi.getAsync<Mandate> settings qs

