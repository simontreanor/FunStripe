namespace Stripe.Application

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type DeletedApplication =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
        /// The name of the application.
        Name: string option
    }

module DeletedApplication =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "application"

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

