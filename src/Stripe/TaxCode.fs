namespace Stripe.TaxCode

open System.Text.Json.Serialization
open FunStripe
open System

/// [Tax codes](https://stripe.com/docs/tax/tax-categories) classify goods and services for tax purposes.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type TaxCode =
    {
        /// A detailed description of which types of products the tax code represents.
        Description: string
        /// Unique identifier for the object.
        Id: string
        /// A short name for the tax code.
        Name: string
    }

type TaxCode with
    static member New(description: string, id: string, name: string) =
        {
            Description = description
            Id = id
            Name = name
        }

module TaxCode =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax_code"

