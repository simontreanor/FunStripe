namespace Stripe.Package

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type PackageDimensions =
    {
        /// Height, in inches.
        Height: decimal
        /// Length, in inches.
        Length: decimal
        /// Weight, in ounces.
        Weight: decimal
        /// Width, in inches.
        Width: decimal
    }

module PackageDimensions =
    let create
        (
            height: decimal,
            length: decimal,
            weight: decimal,
            width: decimal
        ) : PackageDimensions
        =
        {
          Height = height
          Length = length
          Weight = weight
          Width = width
        }

