namespace Stripe.CreditNoteLineItem

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod
open Stripe.TaxRate

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type CreditNoteLineItemType =
    | CustomLineItem
    | InvoiceLineItem

/// The credit note line item object
type CreditNoteLineItem =
    {
        /// The integer amount in cents (or local equivalent) representing the gross amount being credited for this line item, excluding (exclusive) tax and discounts.
        Amount: int
        /// Description of the item being credited.
        Description: string option
        /// The integer amount in cents (or local equivalent) representing the discount being credited for this line item.
        DiscountAmount: int
        /// The amount of discount calculated per discount for this line item
        DiscountAmounts: DiscountsResourceDiscountAmount list
        /// Unique identifier for the object.
        Id: string
        /// ID of the invoice line item being credited
        InvoiceLineItem: string option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The pretax credit amounts (ex: discount, credit grants, etc) for this line item.
        PretaxCreditAmounts: CreditNotesPretaxCreditAmount list
        /// The number of units of product being credited.
        Quantity: int option
        /// The tax rates which apply to the line item.
        TaxRates: TaxRate list
        /// The tax information of the line item.
        Taxes: BillingBillResourceInvoicingTaxesTax list option
        /// The type of the credit note line item, one of `invoice_line_item` or `custom_line_item`. When the type is `invoice_line_item` there is an additional `invoice_line_item` property on the resource the value of which is the id of the credited line item on the invoice.
        Type: CreditNoteLineItemType
        /// The cost of each unit of product being credited.
        UnitAmount: int option
        /// Same as `unit_amount`, but contains a decimal value with at most 12 decimal places.
        UnitAmountDecimal: string option
    }

type CreditNoteLineItem with
    static member New(amount: int, description: string option, discountAmount: int, discountAmounts: DiscountsResourceDiscountAmount list, id: string, livemode: bool, metadata: Map<string, string> option, pretaxCreditAmounts: CreditNotesPretaxCreditAmount list, quantity: int option, taxRates: TaxRate list, taxes: BillingBillResourceInvoicingTaxesTax list option, ``type``: CreditNoteLineItemType, unitAmount: int option, unitAmountDecimal: string option, ?invoiceLineItem: string) =
        {
            Amount = amount
            Description = description
            DiscountAmount = discountAmount
            DiscountAmounts = discountAmounts
            Id = id
            Livemode = livemode
            Metadata = metadata
            PretaxCreditAmounts = pretaxCreditAmounts
            Quantity = quantity
            TaxRates = taxRates
            Taxes = taxes
            Type = ``type``
            UnitAmount = unitAmount
            UnitAmountDecimal = unitAmountDecimal
            InvoiceLineItem = invoiceLineItem
        }

module CreditNoteLineItem =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "credit_note_line_item"

