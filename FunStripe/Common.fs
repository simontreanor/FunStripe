namespace FunStripe

open FSharp.Json

module Common =

    type Address = {
        City: string option
        Country: string option
        [<JsonField("line1")>] Line1: string option
        [<JsonField("line2")>] Line2: string option
        PostalCode: string option
        State: string option
    }

    type BillingDetails = {
        Address: Address
        Email: string option
        Name: string option
        Phone: string option
    }

    