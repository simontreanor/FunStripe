namespace StripeRequest.Confirmation

open FunStripe
open System.Text.Json.Serialization
open Stripe.ConfirmationToken
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
module ConfirmationTokens =

    type RetrieveOptions =
        {
            [<Config.Path>]
            ConfirmationToken: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(confirmationToken: string, ?expand: string list) =
            {
                ConfirmationToken = confirmationToken
                Expand = expand
            }

    ///<p>Retrieves an existing ConfirmationToken object</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/confirmation_tokens/{options.ConfirmationToken}"
        |> RestApi.getAsync<ConfirmationToken> settings qs

