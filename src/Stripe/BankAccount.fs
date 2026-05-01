namespace Stripe.BankAccount

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type DeletedBankAccount =
    {
        /// Three-letter [ISO code for the currency](https://stripe.com/docs/payouts) paid out to the bank account.
        Currency: IsoTypes.IsoCurrencyCode option
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

type DeletedBankAccount with
    static member New(deleted: bool, id: string, ?currency: IsoTypes.IsoCurrencyCode option) =
        {
            Deleted = deleted
            Id = id
            Currency = currency |> Option.flatten
        }

module DeletedBankAccount =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "bank_account"

