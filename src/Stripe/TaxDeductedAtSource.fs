namespace Stripe.TaxDeductedAtSource

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type TaxDeductedAtSource =
    {
        /// Unique identifier for the object.
        Id: string
        /// The end of the invoicing period. This TDS applies to Stripe fees collected during this invoicing period.
        PeriodEnd: DateTime
        /// The start of the invoicing period. This TDS applies to Stripe fees collected during this invoicing period.
        PeriodStart: DateTime
        /// The TAN that was supplied to Stripe when TDS was assessed
        TaxDeductionAccountNumber: string
    }

type TaxDeductedAtSource with
    static member New(id: string, periodEnd: DateTime, periodStart: DateTime, taxDeductionAccountNumber: string) =
        {
            Id = id
            PeriodEnd = periodEnd
            PeriodStart = periodStart
            TaxDeductionAccountNumber = taxDeductionAccountNumber
        }

module TaxDeductedAtSource =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax_deducted_at_source"

