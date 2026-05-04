namespace Stripe.Invoiceitem

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod
open Stripe.TaxRate

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type DeletedInvoiceitem =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

type DeletedInvoiceitem with
    static member New(deleted: bool, id: string) =
        {
            Deleted = deleted
            Id = id
        }

module DeletedInvoiceitem =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "invoiceitem"

type InvoiceitemCustomer'AnyOf =
    | String of string
    | Customer of Customer
    | DeletedCustomer of DeletedCustomer

type ProrationDetails =
    {
        /// Discount amounts applied when the proration was created.
        DiscountAmounts: DiscountsResourceDiscountAmount list
    }

type ProrationDetails with
    static member New(discountAmounts: DiscountsResourceDiscountAmount list) =
        {
            DiscountAmounts = discountAmounts
        }

/// Invoice Items represent the component lines of an [invoice](https://docs.stripe.com/api/invoices). When you create an invoice item with an `invoice` field, it is attached to the specified invoice and included as [an invoice line item](https://docs.stripe.com/api/invoices/line_item) within [invoice.lines](https://docs.stripe.com/api/invoices/object#invoice_object-lines).
/// Invoice Items can be created before you are ready to actually send the invoice. This can be particularly useful when combined
/// with a [subscription](https://docs.stripe.com/api/subscriptions). Sometimes you want to add a charge or credit to a customer, but actually charge
/// or credit the customer's card only at the end of a regular billing cycle. This is useful for combining several charges
/// (to minimize per-transaction fees), or for having Stripe tabulate your usage-based billing totals.
/// Related guides: [Integrate with the Invoicing API](https://docs.stripe.com/invoicing/integration), [Subscription Invoices](https://docs.stripe.com/billing/invoices/subscription#adding-upcoming-invoice-items).
type Invoiceitem =
    {
        /// Amount (in the `currency` specified) of the invoice item. This should always be equal to `unit_amount * quantity`.
        Amount: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// The ID of the customer to bill for this invoice item.
        Customer: InvoiceitemCustomer'AnyOf
        /// The ID of the account to bill for this invoice item.
        CustomerAccount: string option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Date: DateTime
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        /// If true, discounts will apply to this invoice item. Always false for prorations.
        Discountable: bool
        /// The discounts which apply to the invoice item. Item discounts are applied before invoice discounts. Use `expand[]=discounts` to expand each discount.
        Discounts: StripeId<Markers.Discount> list option
        /// Unique identifier for the object.
        Id: string
        /// The ID of the invoice this invoice item belongs to.
        Invoice: StripeId<Markers.Invoice> option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The amount after discounts, but before credits and taxes. This field is `null` for `discountable=true` items.
        NetAmount: int option
        /// The parent that generated this invoice item.
        Parent: BillingBillResourceInvoiceItemParentsInvoiceItemParent option
        Period: InvoiceLineItemPeriod
        /// The pricing information of the invoice item.
        Pricing: BillingBillResourceInvoicingPricingPricing option
        /// Whether the invoice item was created automatically as a proration adjustment when the customer switched plans.
        Proration: bool
        ProrationDetails: ProrationDetails option
        /// Quantity of units for the invoice item in integer format, with any decimal precision truncated. For the item's full-precision decimal quantity, use `quantity_decimal`. This field will be deprecated in favor of `quantity_decimal` in a future version. If the invoice item is a proration, the quantity of the subscription that the proration was computed for.
        Quantity: int
        /// Non-negative decimal with at most 12 decimal places. The quantity of units for the invoice item.
        QuantityDecimal: string
        /// The tax rates which apply to the invoice item. When set, the `default_tax_rates` on the invoice do not apply to this invoice item.
        TaxRates: TaxRate list option
        /// ID of the test clock this invoice item belongs to.
        TestClock: StripeId<Markers.TestHelpersTestClock> option
    }

type Invoiceitem with
    static member New(amount: int, currency: IsoTypes.IsoCurrencyCode, customer: InvoiceitemCustomer'AnyOf, customerAccount: string option, date: DateTime, description: string option, discountable: bool, discounts: StripeId<Markers.Discount> list option, id: string, invoice: StripeId<Markers.Invoice> option, livemode: bool, metadata: Map<string, string> option, parent: BillingBillResourceInvoiceItemParentsInvoiceItemParent option, period: InvoiceLineItemPeriod, pricing: BillingBillResourceInvoicingPricingPricing option, proration: bool, quantity: int, quantityDecimal: string, taxRates: TaxRate list option, testClock: StripeId<Markers.TestHelpersTestClock> option, ?netAmount: int, ?prorationDetails: ProrationDetails) =
        {
            Amount = amount
            Currency = currency
            Customer = customer
            CustomerAccount = customerAccount
            Date = date
            Description = description
            Discountable = discountable
            Discounts = discounts
            Id = id
            Invoice = invoice
            Livemode = livemode
            Metadata = metadata
            Parent = parent
            Period = period
            Pricing = pricing
            Proration = proration
            Quantity = quantity
            QuantityDecimal = quantityDecimal
            TaxRates = taxRates
            TestClock = testClock
            NetAmount = netAmount
            ProrationDetails = prorationDetails
        }

module Invoiceitem =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "invoiceitem"

/// Occurs whenever an invoice item is created.
type InvoiceitemCreated = { Object: Invoiceitem }

type InvoiceitemCreated with
    static member New(object: Invoiceitem) =
        {
            Object = object
        }

/// Occurs whenever an invoice item is deleted.
type InvoiceitemDeleted = { Object: Invoiceitem }

type InvoiceitemDeleted with
    static member New(object: Invoiceitem) =
        {
            Object = object
        }

