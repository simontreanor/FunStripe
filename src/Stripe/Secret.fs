namespace Stripe.Secret

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type SecretServiceResourceScopeType =
    | Account
    | User

type SecretServiceResourceScope =
    {
        /// The secret scope type.
        Type: SecretServiceResourceScopeType
        /// The user ID, if type is set to "user"
        User: string option
    }

