namespace Stripe.Online

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type OnlineAcceptance =
    {
        /// The customer accepts the mandate from this IP address.
        IpAddress: string option
        /// The customer accepts the mandate using the user agent of the browser.
        UserAgent: string option
    }

