namespace Stripe.Application

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type Application =
    {
        /// Unique identifier for the object.
        Id: string
        /// The name of the application.
        Name: string option
    }

module Application =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "application"

