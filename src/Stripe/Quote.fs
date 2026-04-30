namespace Stripe.Quote

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Deleted
open Stripe.Payment
open Stripe.Quotes
open Stripe.Tax

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type QuoteApplication'AnyOf =
    | String of string
    | Application of Application
    | DeletedApplication of DeletedApplication

[<Struct>]
type QuoteCollectionMethod =
    | ChargeAutomatically
    | SendInvoice

type QuoteCustomer'AnyOf =
    | String of string
    | Customer of Customer
    | DeletedCustomer of DeletedCustomer

type QuoteDefaultTaxRates'AnyOf =
    | String of string
    | TaxRate of TaxRate

type QuoteDiscounts'AnyOf =
    | String of string
    | Discount of Discount

type QuoteInvoice'AnyOf =
    | String of string
    | Invoice of Invoice
    | DeletedInvoice of DeletedInvoice

/// A list of items the customer is being quoted for.
type QuoteLineItems =
    {
        /// Details about each object.
        Data: Item list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

type QuoteOnBehalfOf'AnyOf =
    | String of string
    | Account of Account

[<Struct>]
type QuoteStatus =
    | Accepted
    | Canceled
    | Draft
    | Open

type QuoteSubscription'AnyOf =
    | String of string
    | Subscription of Subscription

type QuoteSubscriptionSchedule'AnyOf =
    | String of string
    | SubscriptionSchedule of SubscriptionSchedule

type QuoteTestClock'AnyOf =
    | String of string
    | TestHelpersTestClock of TestHelpersTestClock

/// A Quote is a way to model prices that you'd like to provide to a customer.
/// Once accepted, it will automatically create an invoice, subscription or subscription schedule.
type Quote =
    {
        /// Total before any discounts or taxes are applied.
        AmountSubtotal: int
        /// Total after discounts and taxes are applied.
        AmountTotal: int
        /// ID of the Connect Application that created the quote.
        Application: QuoteApplication'AnyOf option
        /// The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. Only applicable if there are no line items with recurring prices on the quote.
        ApplicationFeeAmount: int option
        /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. Only applicable if there are line items with recurring prices on the quote.
        ApplicationFeePercent: decimal option
        AutomaticTax: QuotesResourceAutomaticTax
        /// Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay invoices at the end of the subscription cycle or on finalization using the default payment method attached to the subscription or customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically`.
        CollectionMethod: QuoteCollectionMethod
        Computed: QuotesResourceComputed
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode option
        /// The customer who received this quote. A customer is required to finalize the quote. Once specified, you can't change it.
        Customer: QuoteCustomer'AnyOf option
        /// The account representing the customer who received this quote. A customer or account is required to finalize the quote. Once specified, you can't change it.
        CustomerAccount: string option
        /// The tax rates applied to this quote.
        DefaultTaxRates: QuoteDefaultTaxRates'AnyOf list option
        /// A description that will be displayed on the quote PDF.
        Description: string option
        /// The discounts applied to this quote.
        Discounts: QuoteDiscounts'AnyOf list
        /// The date on which the quote will be canceled if in `open` or `draft` status. Measured in seconds since the Unix epoch.
        ExpiresAt: DateTime
        /// A footer that will be displayed on the quote PDF.
        Footer: string option
        /// Details of the quote that was cloned. See the [cloning documentation](https://docs.stripe.com/quotes/clone) for more details.
        FromQuote: QuotesResourceFromQuote option
        /// A header that will be displayed on the quote PDF.
        Header: string option
        /// Unique identifier for the object.
        Id: string
        /// The invoice that was created from this quote.
        Invoice: QuoteInvoice'AnyOf option
        InvoiceSettings: InvoiceSettingQuoteSetting
        /// A list of items the customer is being quoted for.
        LineItems: QuoteLineItems option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// A unique number that identifies this particular quote. This number is assigned once the quote is [finalized](https://docs.stripe.com/quotes/overview#finalize).
        Number: string option
        /// The account on behalf of which to charge. See the [Connect documentation](https://support.stripe.com/questions/sending-invoices-on-behalf-of-connected-accounts) for details.
        OnBehalfOf: QuoteOnBehalfOf'AnyOf option
        /// The status of the quote.
        Status: QuoteStatus
        StatusTransitions: QuotesResourceStatusTransitions
        /// The subscription that was created or updated from this quote.
        Subscription: QuoteSubscription'AnyOf option
        SubscriptionData: QuotesResourceSubscriptionDataSubscriptionData
        /// The subscription schedule that was created or updated from this quote.
        SubscriptionSchedule: QuoteSubscriptionSchedule'AnyOf option
        /// ID of the test clock this quote belongs to.
        TestClock: QuoteTestClock'AnyOf option
        TotalDetails: QuotesResourceTotalDetails
        /// The account (if any) the payments will be attributed to for tax reporting, and where funds from each payment will be transferred to for each of the invoices.
        TransferData: QuotesResourceTransferData option
    }

and QuotesResourceFromQuote =
    {
        /// Whether this quote is a revision of a different quote.
        IsRevision: bool
        /// The quote that was cloned.
        Quote: QuotesResourceFromQuoteQuote'AnyOf
    }

and QuotesResourceFromQuoteQuote'AnyOf =
    | String of string
    | Quote of Quote

/// Occurs whenever a quote is finalized.
type QuoteFinalized = { Object: Quote }

/// Occurs whenever a quote is created.
type QuoteCreated = { Object: Quote }

/// Occurs whenever a quote is canceled.
type QuoteCanceled = { Object: Quote }

/// Occurs whenever a quote is accepted.
type QuoteAccepted = { Object: Quote }

module QuoteLineItems =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

    let create
        (
            data: Item list,
            hasMore: bool,
            url: string
        ) : QuoteLineItems
        =
        {
          Data = data
          HasMore = hasMore
          Url = url
        }

module Quote =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "quote"

    let create
        (
            amountSubtotal: int,
            amountTotal: int,
            application: QuoteApplication'AnyOf option,
            applicationFeeAmount: int option,
            applicationFeePercent: decimal option,
            automaticTax: QuotesResourceAutomaticTax,
            collectionMethod: QuoteCollectionMethod,
            computed: QuotesResourceComputed,
            created: DateTime,
            currency: IsoTypes.IsoCurrencyCode option,
            customer: QuoteCustomer'AnyOf option,
            customerAccount: string option,
            description: string option,
            discounts: QuoteDiscounts'AnyOf list,
            expiresAt: DateTime,
            footer: string option,
            fromQuote: QuotesResourceFromQuote option,
            header: string option,
            id: string,
            invoice: QuoteInvoice'AnyOf option,
            invoiceSettings: InvoiceSettingQuoteSetting,
            livemode: bool,
            metadata: Map<string, string>,
            number: string option,
            onBehalfOf: QuoteOnBehalfOf'AnyOf option,
            status: QuoteStatus,
            statusTransitions: QuotesResourceStatusTransitions,
            subscription: QuoteSubscription'AnyOf option,
            subscriptionData: QuotesResourceSubscriptionDataSubscriptionData,
            subscriptionSchedule: QuoteSubscriptionSchedule'AnyOf option,
            testClock: QuoteTestClock'AnyOf option,
            totalDetails: QuotesResourceTotalDetails,
            transferData: QuotesResourceTransferData option
        ) : Quote
        =
        {
          AmountSubtotal = amountSubtotal
          AmountTotal = amountTotal
          Application = application
          ApplicationFeeAmount = applicationFeeAmount
          ApplicationFeePercent = applicationFeePercent
          AutomaticTax = automaticTax
          CollectionMethod = collectionMethod
          Computed = computed
          Created = created
          Currency = currency
          Customer = customer
          CustomerAccount = customerAccount
          Description = description
          Discounts = discounts
          ExpiresAt = expiresAt
          Footer = footer
          FromQuote = fromQuote
          Header = header
          Id = id
          Invoice = invoice
          InvoiceSettings = invoiceSettings
          Livemode = livemode
          Metadata = metadata
          Number = number
          OnBehalfOf = onBehalfOf
          Status = status
          StatusTransitions = statusTransitions
          Subscription = subscription
          SubscriptionData = subscriptionData
          SubscriptionSchedule = subscriptionSchedule
          TestClock = testClock
          TotalDetails = totalDetails
          TransferData = transferData
          DefaultTaxRates = None
          LineItems = None
        }

module QuotesResourceFromQuote =
    let create
        (
            isRevision: bool,
            quote: QuotesResourceFromQuoteQuote'AnyOf
        ) : QuotesResourceFromQuote
        =
        {
          IsRevision = isRevision
          Quote = quote
        }

module QuoteFinalized =
    let create
        (
            object: Quote
        ) : QuoteFinalized
        =
        {
          Object = object
        }

module QuoteCreated =
    let create
        (
            object: Quote
        ) : QuoteCreated
        =
        {
          Object = object
        }

module QuoteCanceled =
    let create
        (
            object: Quote
        ) : QuoteCanceled
        =
        {
          Object = object
        }

module QuoteAccepted =
    let create
        (
            object: Quote
        ) : QuoteAccepted
        =
        {
          Object = object
        }

