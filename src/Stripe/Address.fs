namespace Stripe.Address

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type Address =
    {
        /// City, district, suburb, town, or village.
        City: string option
        /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        Country: IsoTypes.IsoCountryCode option
        /// Address line 1, such as the street, PO Box, or company name.
        [<JsonPropertyName("line1")>]
        Line1: string option
        /// Address line 2, such as the apartment, suite, unit, or building.
        [<JsonPropertyName("line2")>]
        Line2: string option
        /// ZIP or postal code.
        PostalCode: string option
        /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
        State: string option
    }

module Address =
    let create
        (
            city: string option,
            country: IsoTypes.IsoCountryCode option,
            line1: string option,
            line2: string option,
            postalCode: string option,
            state: string option
        ) : Address
        =
        {
          City = city
          Country = country
          Line1 = line1
          Line2 = line2
          PostalCode = postalCode
          State = state
        }

