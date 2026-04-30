namespace Stripe.Fee

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type FeeType =
    | ApplicationFee
    | PaymentMethodPassthroughFee
    | StripeFee
    | Tax
    | WithheldTax

type Fee =
    {
        /// Amount of the fee, in cents.
        Amount: int
        /// ID of the Connect application that earned the fee.
        Application: string option
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        /// Type of the fee, one of: `application_fee`, `payment_method_passthrough_fee`, `stripe_fee`, `tax`, or `withheld_tax`.
        Type: FeeType
    }

module Fee =
    let create
        (
            amount: int,
            application: string option,
            currency: IsoTypes.IsoCurrencyCode,
            description: string option,
            ``type``: FeeType
        ) : Fee
        =
        {
          Amount = amount
          Application = application
          Currency = currency
          Description = description
          Type = ``type``
        }

