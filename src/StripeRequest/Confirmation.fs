namespace StripeRequest.Confirmation

open FunStripe
open System.Text.Json.Serialization
open Stripe.ConfirmationToken
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module ConfirmationTokens =

    type RetrieveOptions =
        {
            [<Config.Path>]
            ConfirmationToken: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                confirmationToken: string
            ) : RetrieveOptions
            =
            {
              ConfirmationToken = confirmationToken
              Expand = None
            }

    ///<p>Retrieves an existing ConfirmationToken object</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/confirmation_tokens/{options.ConfirmationToken}"
        |> RestApi.getAsync<ConfirmationToken> settings qs

