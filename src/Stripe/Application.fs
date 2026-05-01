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

type DeletedApplication with
    static member New(deleted: bool, id: string, name: string option) =
        {
            Deleted = deleted
            Id = id
            Name = name
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

type Application with
    static member New(id: string, name: string option) =
        {
            Id = id
            Name = name
        }

module Application =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "application"

