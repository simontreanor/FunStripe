namespace Stripe.LoginLink

open System.Text.Json.Serialization
open FunStripe
open System

/// Login Links are single-use URLs that takes an Express account to the login page for their Stripe dashboard.
/// A Login Link differs from an [Account Link](https://docs.stripe.com/api/account_links) in that it takes the user directly to their [Express dashboard for the specified account](https://docs.stripe.com/connect/integrate-express-dashboard#create-login-link)
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type LoginLink =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The URL for the login link.
        Url: string
    }

type LoginLink with
    static member New(created: DateTime, url: string) =
        {
            Created = created
            Url = url
        }

module LoginLink =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "login_link"

