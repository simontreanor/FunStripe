namespace StripeRequest.Ephemeral

open FunStripe
open System.Text.Json.Serialization
open Stripe.EphemeralKey
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
module EphemeralKeys =

    type CreateOptions =
        {
            /// The ID of the Customer you'd like to modify using the resulting ephemeral key.
            [<Config.Form>]
            Customer: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The ID of the Issuing Card you'd like to access using the resulting ephemeral key.
            [<Config.Form>]
            IssuingCard: string option
            /// A single-use token, created by Stripe.js, used for creating ephemeral keys for Issuing Cards without exchanging sensitive information.
            [<Config.Form>]
            Nonce: string option
            /// The ID of the Identity VerificationSession you'd like to access using the resulting ephemeral key
            [<Config.Form>]
            VerificationSession: string option
        }

    type CreateOptions with
        static member New(?customer: string, ?expand: string list, ?issuingCard: string, ?nonce: string, ?verificationSession: string) =
            {
                Customer = customer
                Expand = expand
                IssuingCard = issuingCard
                Nonce = nonce
                VerificationSession = verificationSession
            }

    type DeleteOptions =
        {
            [<Config.Path>]
            Key: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type DeleteOptions with
        static member New(key: string, ?expand: string list) =
            {
                Key = key
                Expand = expand
            }

    ///<p>Creates a short-lived API key for a given resource.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/ephemeral_keys"
        |> RestApi.postAsync<_, EphemeralKey> settings (Map.empty) options

    ///<p>Invalidates a short-lived API key for a given resource.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/ephemeral_keys/{options.Key}"
        |> RestApi.deleteAsync<EphemeralKey> settings (Map.empty)

