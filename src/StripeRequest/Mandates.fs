namespace StripeRequest.Mandates

open FunStripe
open System.Text.Json.Serialization
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module Mandates =

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Mandate: string
        }

    module RetrieveOptions =
        let create
            (
                mandate: string
            ) : RetrieveOptions
            =
            {
              Mandate = mandate
              Expand = None
            }

    ///<p>Retrieves a Mandate object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/mandates/{options.Mandate}"
        |> RestApi.getAsync<Mandate> settings qs

