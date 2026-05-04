namespace StripeRequest.Credit

open FunStripe
open System.Text.Json.Serialization
open Stripe.CreditNote
open Stripe.CreditNoteLineItem
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
module CreditNotes =

    type ListOptions =
        {
            /// Only return credit notes that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// Only return credit notes for the customer specified by this customer ID.
            [<Config.Query>]
            Customer: string option
            /// Only return credit notes for the account representing the customer specified by this account ID.
            [<Config.Query>]
            CustomerAccount: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Only return credit notes for the invoice specified by this invoice ID.
            [<Config.Query>]
            Invoice: string option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListOptions with
        static member New(?created: int, ?customer: string, ?customerAccount: string, ?endingBefore: string, ?expand: string list, ?invoice: string, ?limit: int, ?startingAfter: string) =
            {
                Created = created
                Customer = customer
                CustomerAccount = customerAccount
                EndingBefore = endingBefore
                Expand = expand
                Invoice = invoice
                Limit = limit
                StartingAfter = startingAfter
            }

    type Create'EmailType =
        | CreditNote
        | [<JsonPropertyName("none")>] None'

    type Create'LinesTaxAmounts =
        {
            /// The amount, in cents (or local equivalent), of the tax.
            [<Config.Form>]
            Amount: int option
            /// The id of the tax rate for this tax amount. The tax rate must have been automatically created by Stripe.
            [<Config.Form>]
            TaxRate: string option
            /// The amount on which tax is calculated, in cents (or local equivalent).
            [<Config.Form>]
            TaxableAmount: int option
        }

    type Create'LinesTaxAmounts with
        static member New(?amount: int, ?taxRate: string, ?taxableAmount: int) =
            {
                Amount = amount
                TaxRate = taxRate
                TaxableAmount = taxableAmount
            }

    type Create'LinesType =
        | CustomLineItem
        | InvoiceLineItem

    type Create'Lines =
        {
            /// The line item amount to credit. Only valid when `type` is `invoice_line_item`. If invoice is set up with `automatic_tax[enabled]=true`, this amount is tax exclusive
            [<Config.Form>]
            Amount: int option
            /// The description of the credit note line item. Only valid when the `type` is `custom_line_item`.
            [<Config.Form>]
            Description: string option
            /// The invoice line item to credit. Only valid when the `type` is `invoice_line_item`.
            [<Config.Form>]
            InvoiceLineItem: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The line item quantity to credit.
            [<Config.Form>]
            Quantity: int option
            /// A list of up to 10 tax amounts for the credit note line item. Not valid when `tax_rates` is used or if invoice is set up with `automatic_tax[enabled]=true`.
            [<Config.Form>]
            TaxAmounts: Choice<Create'LinesTaxAmounts list,string> option
            /// The tax rates which apply to the credit note line item. Only valid when the `type` is `custom_line_item` and `tax_amounts` is not used.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
            /// Type of the credit note line item, one of `invoice_line_item` or `custom_line_item`. `custom_line_item` is not valid when the invoice is set up with `automatic_tax[enabled]=true`.
            [<Config.Form>]
            Type: Create'LinesType option
            /// The integer unit amount in cents (or local equivalent) of the credit note line item. This `unit_amount` will be multiplied by the quantity to get the full amount to credit for this line item. Only valid when `type` is `custom_line_item`.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    type Create'Lines with
        static member New(?amount: int, ?description: string, ?invoiceLineItem: string, ?metadata: Map<string, string>, ?quantity: int, ?taxAmounts: Choice<Create'LinesTaxAmounts list,string>, ?taxRates: Choice<string list,string>, ?type': Create'LinesType, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Amount = amount
                Description = description
                InvoiceLineItem = invoiceLineItem
                Metadata = metadata
                Quantity = quantity
                TaxAmounts = taxAmounts
                TaxRates = taxRates
                Type = type'
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'Reason =
        | Duplicate
        | Fraudulent
        | OrderChange
        | ProductUnsatisfactory

    type Create'RefundsPaymentRecordRefund =
        {
            /// The ID of the PaymentRecord with the refund to link to this credit note.
            [<Config.Form>]
            PaymentRecord: string option
            /// The PaymentRecord refund group to link to this credit note. For refunds processed off-Stripe, this will correspond to the `processor_details.custom.refund_reference` field provided when reporting the refund on the PaymentRecord.
            [<Config.Form>]
            RefundGroup: string option
        }

    type Create'RefundsPaymentRecordRefund with
        static member New(?paymentRecord: string, ?refundGroup: string) =
            {
                PaymentRecord = paymentRecord
                RefundGroup = refundGroup
            }

    type Create'RefundsType =
        | PaymentRecordRefund
        | Refund

    type Create'Refunds =
        {
            /// Amount of the refund that applies to this credit note, in cents (or local equivalent). Defaults to the entire refund amount.
            [<Config.Form>]
            AmountRefunded: int option
            /// The PaymentRecord refund details to link to this credit note. Required when `type` is `payment_record_refund`.
            [<Config.Form>]
            PaymentRecordRefund: Create'RefundsPaymentRecordRefund option
            /// ID of an existing refund to link this credit note to. Required when `type` is `refund`.
            [<Config.Form>]
            Refund: string option
            /// Type of the refund, one of `refund` or `payment_record_refund`. Defaults to `refund`.
            [<Config.Form>]
            Type: Create'RefundsType option
        }

    type Create'Refunds with
        static member New(?amountRefunded: int, ?paymentRecordRefund: Create'RefundsPaymentRecordRefund, ?refund: string, ?type': Create'RefundsType) =
            {
                AmountRefunded = amountRefunded
                PaymentRecordRefund = paymentRecordRefund
                Refund = refund
                Type = type'
            }

    type Create'ShippingCost =
        {
            /// The ID of the shipping rate to use for this order.
            [<Config.Form>]
            ShippingRate: string option
        }

    type Create'ShippingCost with
        static member New(?shippingRate: string) =
            {
                ShippingRate = shippingRate
            }

    type CreateOptions =
        {
            /// The integer amount in cents (or local equivalent) representing the total amount of the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.
            [<Config.Form>]
            Amount: int option
            /// The integer amount in cents (or local equivalent) representing the amount to credit the customer's balance, which will be automatically applied to their next invoice.
            [<Config.Form>]
            CreditAmount: int option
            /// The date when this credit note is in effect. Same as `created` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the credit note PDF.
            [<Config.Form>]
            EffectiveAt: DateTime option
            /// Type of email to send to the customer, one of `credit_note` or `none` and the default is `credit_note`.
            [<Config.Form>]
            EmailType: Create'EmailType option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// ID of the invoice.
            [<Config.Form>]
            Invoice: string
            /// Line items that make up the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.
            [<Config.Form>]
            Lines: Create'Lines list option
            /// The credit note's memo appears on the credit note PDF.
            [<Config.Form>]
            Memo: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The integer amount in cents (or local equivalent) representing the amount that is credited outside of Stripe.
            [<Config.Form>]
            OutOfBandAmount: int option
            /// Reason for issuing this credit note, one of `duplicate`, `fraudulent`, `order_change`, or `product_unsatisfactory`
            [<Config.Form>]
            Reason: Create'Reason option
            /// The integer amount in cents (or local equivalent) representing the amount to refund. If set, a refund will be created for the charge associated with the invoice.
            [<Config.Form>]
            RefundAmount: int option
            /// Refunds to link to this credit note.
            [<Config.Form>]
            Refunds: Create'Refunds list option
            /// When shipping_cost contains the shipping_rate from the invoice, the shipping_cost is included in the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.
            [<Config.Form>]
            ShippingCost: Create'ShippingCost option
        }

    type CreateOptions with
        static member New(invoice: string, ?amount: int, ?creditAmount: int, ?effectiveAt: DateTime, ?emailType: Create'EmailType, ?expand: string list, ?lines: Create'Lines list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: Create'Reason, ?refundAmount: int, ?refunds: Create'Refunds list, ?shippingCost: Create'ShippingCost) =
            {
                Invoice = invoice
                Amount = amount
                CreditAmount = creditAmount
                EffectiveAt = effectiveAt
                EmailType = emailType
                Expand = expand
                Lines = lines
                Memo = memo
                Metadata = metadata
                OutOfBandAmount = outOfBandAmount
                Reason = reason
                RefundAmount = refundAmount
                Refunds = refunds
                ShippingCost = shippingCost
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    type RetrieveOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Credit note memo.
            [<Config.Form>]
            Memo: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    type UpdateOptions with
        static member New(id: string, ?expand: string list, ?memo: string, ?metadata: Map<string, string>) =
            {
                Id = id
                Expand = expand
                Memo = memo
                Metadata = metadata
            }

    ///<p>Returns a list of credit notes.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/credit_notes"
        |> RestApi.getAsync<StripeList<CreditNote>> settings qs

    ///<p>Issue a credit note to adjust the amount of a finalized invoice. A credit note will first reduce the invoice’s <code>amount_remaining</code> (and <code>amount_due</code>), but not below zero.
    ///This amount is indicated by the credit note’s <code>pre_payment_amount</code>. The excess amount is indicated by <code>post_payment_amount</code>, and it can result in any combination of the following:</p>
    ///<ul>
    ///<li>Refunds: create a new refund (using <code>refund_amount</code>) or link existing refunds (using <code>refunds</code>).</li>
    ///<li>Customer balance credit: credit the customer’s balance (using <code>credit_amount</code>) which will be automatically applied to their next invoice when it’s finalized.</li>
    ///<li>Outside of Stripe credit: record the amount that is or will be credited outside of Stripe (using <code>out_of_band_amount</code>).</li>
    ///</ul>
    ///<p>The sum of refunds, customer balance credits, and outside of Stripe credits must equal the <code>post_payment_amount</code>.</p>
    ///<p>You may issue multiple credit notes for an invoice. Each credit note may increment the invoice’s <code>pre_payment_credit_notes_amount</code>,
    ///<code>post_payment_credit_notes_amount</code>, or both, depending on the invoice’s <code>amount_remaining</code> at the time of credit note creation.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/credit_notes"
        |> RestApi.postAsync<_, CreditNote> settings (Map.empty) options

    ///<p>Retrieves the credit note object with the given identifier.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/credit_notes/{options.Id}"
        |> RestApi.getAsync<CreditNote> settings qs

    ///<p>Updates an existing credit note.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/credit_notes/{options.Id}"
        |> RestApi.postAsync<_, CreditNote> settings (Map.empty) options

module CreditNotesPreview =

    type PreviewOptions =
        {
            /// The integer amount in cents (or local equivalent) representing the total amount of the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.
            [<Config.Query>]
            Amount: int option
            /// The integer amount in cents (or local equivalent) representing the amount to credit the customer's balance, which will be automatically applied to their next invoice.
            [<Config.Query>]
            CreditAmount: int option
            /// The date when this credit note is in effect. Same as `created` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the credit note PDF.
            [<Config.Query>]
            EffectiveAt: int option
            /// Type of email to send to the customer, one of `credit_note` or `none` and the default is `credit_note`.
            [<Config.Query>]
            EmailType: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// ID of the invoice.
            [<Config.Query>]
            Invoice: string
            /// Line items that make up the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.
            [<Config.Query>]
            Lines: string list option
            /// The credit note's memo appears on the credit note PDF.
            [<Config.Query>]
            Memo: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Query>]
            Metadata: Map<string, string> option
            /// The integer amount in cents (or local equivalent) representing the amount that is credited outside of Stripe.
            [<Config.Query>]
            OutOfBandAmount: int option
            /// Reason for issuing this credit note, one of `duplicate`, `fraudulent`, `order_change`, or `product_unsatisfactory`
            [<Config.Query>]
            Reason: string option
            /// The integer amount in cents (or local equivalent) representing the amount to refund. If set, a refund will be created for the charge associated with the invoice.
            [<Config.Query>]
            RefundAmount: int option
            /// Refunds to link to this credit note.
            [<Config.Query>]
            Refunds: string list option
            /// When shipping_cost contains the shipping_rate from the invoice, the shipping_cost is included in the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.
            [<Config.Query>]
            ShippingCost: Map<string, string> option
        }

    type PreviewOptions with
        static member New(invoice: string, ?amount: int, ?creditAmount: int, ?effectiveAt: int, ?emailType: string, ?expand: string list, ?lines: string list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: string, ?refundAmount: int, ?refunds: string list, ?shippingCost: Map<string, string>) =
            {
                Invoice = invoice
                Amount = amount
                CreditAmount = creditAmount
                EffectiveAt = effectiveAt
                EmailType = emailType
                Expand = expand
                Lines = lines
                Memo = memo
                Metadata = metadata
                OutOfBandAmount = outOfBandAmount
                Reason = reason
                RefundAmount = refundAmount
                Refunds = refunds
                ShippingCost = shippingCost
            }

    ///<p>Get a preview of a credit note without creating it.</p>
    let Preview settings (options: PreviewOptions) =
        let qs = [("amount", options.Amount |> box); ("credit_amount", options.CreditAmount |> box); ("effective_at", options.EffectiveAt |> box); ("email_type", options.EmailType |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("lines", options.Lines |> box); ("memo", options.Memo |> box); ("metadata", options.Metadata |> box); ("out_of_band_amount", options.OutOfBandAmount |> box); ("reason", options.Reason |> box); ("refund_amount", options.RefundAmount |> box); ("refunds", options.Refunds |> box); ("shipping_cost", options.ShippingCost |> box)] |> Map.ofList
        $"/v1/credit_notes/preview"
        |> RestApi.getAsync<CreditNote> settings qs

module CreditNotesPreviewLines =

    type PreviewLinesOptions =
        {
            /// The integer amount in cents (or local equivalent) representing the total amount of the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.
            [<Config.Query>]
            Amount: int option
            /// The integer amount in cents (or local equivalent) representing the amount to credit the customer's balance, which will be automatically applied to their next invoice.
            [<Config.Query>]
            CreditAmount: int option
            /// The date when this credit note is in effect. Same as `created` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the credit note PDF.
            [<Config.Query>]
            EffectiveAt: int option
            /// Type of email to send to the customer, one of `credit_note` or `none` and the default is `credit_note`.
            [<Config.Query>]
            EmailType: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// ID of the invoice.
            [<Config.Query>]
            Invoice: string
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Line items that make up the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.
            [<Config.Query>]
            Lines: string list option
            /// The credit note's memo appears on the credit note PDF.
            [<Config.Query>]
            Memo: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Query>]
            Metadata: Map<string, string> option
            /// The integer amount in cents (or local equivalent) representing the amount that is credited outside of Stripe.
            [<Config.Query>]
            OutOfBandAmount: int option
            /// Reason for issuing this credit note, one of `duplicate`, `fraudulent`, `order_change`, or `product_unsatisfactory`
            [<Config.Query>]
            Reason: string option
            /// The integer amount in cents (or local equivalent) representing the amount to refund. If set, a refund will be created for the charge associated with the invoice.
            [<Config.Query>]
            RefundAmount: int option
            /// Refunds to link to this credit note.
            [<Config.Query>]
            Refunds: string list option
            /// When shipping_cost contains the shipping_rate from the invoice, the shipping_cost is included in the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.
            [<Config.Query>]
            ShippingCost: Map<string, string> option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type PreviewLinesOptions with
        static member New(invoice: string, ?amount: int, ?creditAmount: int, ?effectiveAt: int, ?emailType: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?lines: string list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: string, ?refundAmount: int, ?refunds: string list, ?shippingCost: Map<string, string>, ?startingAfter: string) =
            {
                Invoice = invoice
                Amount = amount
                CreditAmount = creditAmount
                EffectiveAt = effectiveAt
                EmailType = emailType
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Lines = lines
                Memo = memo
                Metadata = metadata
                OutOfBandAmount = outOfBandAmount
                Reason = reason
                RefundAmount = refundAmount
                Refunds = refunds
                ShippingCost = shippingCost
                StartingAfter = startingAfter
            }

    ///<p>When retrieving a credit note preview, you’ll get a <strong>lines</strong> property containing the first handful of those items. This URL you can retrieve the full (paginated) list of line items.</p>
    let PreviewLines settings (options: PreviewLinesOptions) =
        let qs = [("amount", options.Amount |> box); ("credit_amount", options.CreditAmount |> box); ("effective_at", options.EffectiveAt |> box); ("email_type", options.EmailType |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("lines", options.Lines |> box); ("memo", options.Memo |> box); ("metadata", options.Metadata |> box); ("out_of_band_amount", options.OutOfBandAmount |> box); ("reason", options.Reason |> box); ("refund_amount", options.RefundAmount |> box); ("refunds", options.Refunds |> box); ("shipping_cost", options.ShippingCost |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/credit_notes/preview/lines"
        |> RestApi.getAsync<StripeList<CreditNoteLineItem>> settings qs

module CreditNotesLines =

    type ListOptions =
        {
            [<Config.Path>]
            CreditNote: string
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListOptions with
        static member New(creditNote: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                CreditNote = creditNote
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>When retrieving a credit note, you’ll get a <strong>lines</strong> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/credit_notes/{options.CreditNote}/lines"
        |> RestApi.getAsync<StripeList<CreditNoteLineItem>> settings qs

module CreditNotesVoid =

    type VoidCreditNoteOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type VoidCreditNoteOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<p>Marks a credit note as void. Learn more about <a href="/docs/billing/invoices/credit-notes#voiding">voiding credit notes</a>.</p>
    let VoidCreditNote settings (options: VoidCreditNoteOptions) =
        $"/v1/credit_notes/{options.Id}/void"
        |> RestApi.postAsync<_, CreditNote> settings (Map.empty) options

