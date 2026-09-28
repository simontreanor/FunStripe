namespace Stripe.TaxCode

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "3.0.0")>]
type TaxCodeRequirementsPerformanceLocation =
    | Optional
    | Required

type TaxCodeRequirements =
    {
        /// Describes whether a performance location is required for a successful tax calculation with a tax code.
        PerformanceLocation: TaxCodeRequirementsPerformanceLocation
    }

type TaxCodeRequirements with
    static member New(performanceLocation: TaxCodeRequirementsPerformanceLocation) =
        {
            PerformanceLocation = performanceLocation
        }

/// [Tax codes](https://stripe.com/docs/tax/tax-categories) classify goods and services for tax purposes.
type TaxCode =
    {
        /// A detailed description of which types of products the tax code represents.
        Description: string
        /// Unique identifier for the object.
        Id: string
        /// A short name for the tax code.
        Name: string
        /// An object that describes more information about the tax location required for this tax code. Some tax codes require a [performance location](/tax/location-sales#required-versus-optional-performance-locations) to calculate tax correctly.
        Requirements: TaxCodeRequirements option
    }

type TaxCode with
    static member New(description: string, id: string, name: string, requirements: TaxCodeRequirements option) =
        {
            Description = description
            Id = id
            Name = name
            Requirements = requirements
        }

module TaxCode =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax_code"

