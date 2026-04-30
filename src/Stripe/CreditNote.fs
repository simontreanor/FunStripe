namespace Stripe.CreditNote

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.CreditNoteLineItem
open Stripe.Discount
open Stripe.PaymentMethod

/// Line items that make up the credit note
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type CreditNoteLines =
    {
        /// Details about each object.
        Data: CreditNoteLineItem list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

module CreditNoteLines =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

[<Struct>]
type CreditNoteReason =
    | Duplicate
    | Fraudulent
    | OrderChange
    | ProductUnsatisfactory

[<Struct>]
type CreditNoteRefundType =
    | PaymentRecordRefund
    | Refund

type CreditNoteRefund =
    {
        /// Amount of the refund that applies to this credit note, in cents (or local equivalent).
        AmountRefunded: int
        /// The PaymentRecord refund details associated with this credit note refund.
        PaymentRecordRefund: CreditNotesPaymentRecordRefund option
        /// ID of the refund.
        Refund: string
        /// Type of the refund, one of `refund` or `payment_record_refund`.
        Type: CreditNoteRefundType option
    }

[<Struct>]
type CreditNoteStatus =
    | Issued
    | Void

[<Struct>]
type CreditNoteType =
    | Mixed
    | PostPayment
    | PrePayment

/// Issue a credit note to adjust an invoice's amount after the invoice is finalized.
/// Related guide: [Credit notes](https://docs.stripe.com/billing/invoices/credit-notes)
type CreditNote =
    {
        /// The integer amount in cents (or local equivalent) representing the total amount of the credit note, including tax.
        Amount: int
        /// This is the sum of all the shipping amounts.
        AmountShipping: int
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// ID of the customer.
        Customer: string
        /// ID of the account representing the customer.
        CustomerAccount: string option
        /// Customer balance transaction related to this credit note.
        CustomerBalanceTransaction: string option
        /// The integer amount in cents (or local equivalent) representing the total amount of discount that was credited.
        DiscountAmount: int
        /// The aggregate amounts calculated per discount for all line items.
        DiscountAmounts: DiscountsResourceDiscountAmount list
        /// The date when this credit note is in effect. Same as `created` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the credit note PDF.
        EffectiveAt: DateTime option
        /// Unique identifier for the object.
        Id: string
        /// ID of the invoice.
        Invoice: string
        /// Line items that make up the credit note
        Lines: CreditNoteLines
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Customer-facing text that appears on the credit note PDF.
        Memo: string option
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// A unique number that identifies this particular credit note and appears on the PDF of the credit note and its associated invoice.
        Number: string
        /// Amount that was credited outside of Stripe.
        OutOfBandAmount: int option
        /// The link to download the PDF of the credit note.
        Pdf: string
        /// The amount of the credit note that was refunded to the customer, credited to the customer's balance, credited outside of Stripe, or any combination thereof.
        PostPaymentAmount: int
        /// The amount of the credit note by which the invoice's `amount_remaining` and `amount_due` were reduced.
        PrePaymentAmount: int
        /// The pretax credit amounts (ex: discount, credit grants, etc) for all line items.
        PretaxCreditAmounts: CreditNotesPretaxCreditAmount list
        /// Reason for issuing this credit note, one of `duplicate`, `fraudulent`, `order_change`, or `product_unsatisfactory`
        Reason: CreditNoteReason option
        /// Refunds related to this credit note.
        Refunds: CreditNoteRefund list
        /// The details of the cost of shipping, including the ShippingRate applied to the invoice.
        ShippingCost: InvoicesResourceShippingCost option
        /// Status of this credit note, one of `issued` or `void`. Learn more about [voiding credit notes](https://docs.stripe.com/billing/invoices/credit-notes#voiding).
        Status: CreditNoteStatus
        /// The integer amount in cents (or local equivalent) representing the amount of the credit note, excluding exclusive tax and invoice level discounts.
        Subtotal: int
        /// The integer amount in cents (or local equivalent) representing the amount of the credit note, excluding all tax and invoice level discounts.
        SubtotalExcludingTax: int option
        /// The integer amount in cents (or local equivalent) representing the total amount of the credit note, including tax and all discount.
        Total: int
        /// The integer amount in cents (or local equivalent) representing the total amount of the credit note, excluding tax, but including discounts.
        TotalExcludingTax: int option
        /// The aggregate tax information for all line items.
        TotalTaxes: BillingBillResourceInvoicingTaxesTax list option
        /// Type of this credit note, one of `pre_payment` or `post_payment`. A `pre_payment` credit note means it was issued when the invoice was open. A `post_payment` credit note means it was issued when the invoice was paid.
        Type: CreditNoteType
        /// The time that the credit note was voided.
        VoidedAt: DateTime option
    }

module CreditNote =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "credit_note"

/// Occurs whenever a credit note is voided.
type CreditNoteVoided = { Object: CreditNote }

/// Occurs whenever a credit note is updated.
type CreditNoteUpdated = { Object: CreditNote }

/// Occurs whenever a credit note is created.
type CreditNoteCreated = { Object: CreditNote }

