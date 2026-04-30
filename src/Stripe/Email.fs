namespace Stripe.Email

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type EmailSent =
    {
        /// The timestamp when the email was sent.
        EmailSentAt: DateTime
        /// The recipient's email address.
        EmailSentTo: string
    }

