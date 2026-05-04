namespace Stripe.Quote

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Application
open Stripe.PaymentMethod

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
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

type QuoteLineItems with
    static member New(data: Item list, hasMore: bool, url: string) =
        {
            Data = data
            HasMore = hasMore
            Url = url
        }

module QuoteLineItems =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

[<Struct>]
type QuoteStatus =
    | Accepted
    | Canceled
    | Draft
    | Open

[<Struct>]
type QuotesResourceAutomaticTaxStatus =
    | Complete
    | Failed
    | RequiresLocationInputs

type QuotesResourceAutomaticTax =
    {
        /// Automatically calculate taxes
        Enabled: bool
        /// The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.
        Liability: ConnectAccountReference option
        /// The tax provider powering automatic tax.
        Provider: string option
        /// The status of the most recent automated tax calculation for this quote.
        Status: QuotesResourceAutomaticTaxStatus option
    }

type QuotesResourceAutomaticTax with
    static member New(enabled: bool, liability: ConnectAccountReference option, provider: string option, status: QuotesResourceAutomaticTaxStatus option) =
        {
            Enabled = enabled
            Liability = liability
            Provider = provider
            Status = status
        }

[<Struct>]
type QuotesResourceRecurringInterval =
    | Day
    | Month
    | Week
    | Year

type QuotesResourceTotalDetailsResourceBreakdown =
    {
        /// The aggregated discounts.
        Discounts: LineItemsDiscountAmount list
        /// The aggregated tax amounts by rate.
        Taxes: LineItemsTaxAmount list
    }

type QuotesResourceTotalDetailsResourceBreakdown with
    static member New(discounts: LineItemsDiscountAmount list, taxes: LineItemsTaxAmount list) =
        {
            Discounts = discounts
            Taxes = taxes
        }

type QuotesResourceTotalDetails =
    {
        /// This is the sum of all the discounts.
        AmountDiscount: int
        /// This is the sum of all the shipping amounts.
        AmountShipping: int option
        /// This is the sum of all the tax amounts.
        AmountTax: int
        Breakdown: QuotesResourceTotalDetailsResourceBreakdown option
    }

type QuotesResourceTotalDetails with
    static member New(amountDiscount: int, amountShipping: int option, amountTax: int, ?breakdown: QuotesResourceTotalDetailsResourceBreakdown) =
        {
            AmountDiscount = amountDiscount
            AmountShipping = amountShipping
            AmountTax = amountTax
            Breakdown = breakdown
        }

type QuotesResourceRecurring =
    {
        /// Total before any discounts or taxes are applied.
        AmountSubtotal: int
        /// Total after discounts and taxes are applied.
        AmountTotal: int
        /// The frequency at which a subscription is billed. One of `day`, `week`, `month` or `year`.
        Interval: QuotesResourceRecurringInterval
        /// The number of intervals (specified in the `interval` attribute) between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months.
        IntervalCount: int
        TotalDetails: QuotesResourceTotalDetails
    }

type QuotesResourceRecurring with
    static member New(amountSubtotal: int, amountTotal: int, interval: QuotesResourceRecurringInterval, intervalCount: int, totalDetails: QuotesResourceTotalDetails) =
        {
            AmountSubtotal = amountSubtotal
            AmountTotal = amountTotal
            Interval = interval
            IntervalCount = intervalCount
            TotalDetails = totalDetails
        }

/// The line items that will appear on the next invoice after this quote is accepted. This does not include pending invoice items that exist on the customer but may still be included in the next invoice.
type QuotesResourceUpfrontLineItems =
    {
        /// Details about each object.
        Data: Item list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

type QuotesResourceUpfrontLineItems with
    static member New(data: Item list, hasMore: bool, url: string) =
        {
            Data = data
            HasMore = hasMore
            Url = url
        }

module QuotesResourceUpfrontLineItems =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

type QuotesResourceUpfront =
    {
        /// Total before any discounts or taxes are applied.
        AmountSubtotal: int
        /// Total after discounts and taxes are applied.
        AmountTotal: int
        /// The line items that will appear on the next invoice after this quote is accepted. This does not include pending invoice items that exist on the customer but may still be included in the next invoice.
        LineItems: QuotesResourceUpfrontLineItems option
        TotalDetails: QuotesResourceTotalDetails
    }

type QuotesResourceUpfront with
    static member New(amountSubtotal: int, amountTotal: int, totalDetails: QuotesResourceTotalDetails, ?lineItems: QuotesResourceUpfrontLineItems) =
        {
            AmountSubtotal = amountSubtotal
            AmountTotal = amountTotal
            TotalDetails = totalDetails
            LineItems = lineItems
        }

type QuotesResourceComputed =
    {
        /// The definitive totals and line items the customer will be charged on a recurring basis. Takes into account the line items with recurring prices and discounts with `duration=forever` coupons only. Defaults to `null` if no inputted line items with recurring prices.
        Recurring: QuotesResourceRecurring option
        Upfront: QuotesResourceUpfront
    }

type QuotesResourceComputed with
    static member New(recurring: QuotesResourceRecurring option, upfront: QuotesResourceUpfront) =
        {
            Recurring = recurring
            Upfront = upfront
        }

type QuotesResourceFromQuote =
    {
        /// Whether this quote is a revision of a different quote.
        IsRevision: bool
        /// The quote that was cloned.
        Quote: StripeId<Markers.Quote>
    }

type QuotesResourceFromQuote with
    static member New(isRevision: bool, quote: StripeId<Markers.Quote>) =
        {
            IsRevision = isRevision
            Quote = quote
        }

type QuotesResourceStatusTransitions =
    {
        /// The time that the quote was accepted. Measured in seconds since Unix epoch.
        AcceptedAt: DateTime option
        /// The time that the quote was canceled. Measured in seconds since Unix epoch.
        CanceledAt: DateTime option
        /// The time that the quote was finalized. Measured in seconds since Unix epoch.
        FinalizedAt: DateTime option
    }

type QuotesResourceStatusTransitions with
    static member New(acceptedAt: DateTime option, canceledAt: DateTime option, finalizedAt: DateTime option) =
        {
            AcceptedAt = acceptedAt
            CanceledAt = canceledAt
            FinalizedAt = finalizedAt
        }

[<Struct>]
type QuotesResourceSubscriptionDataBillingModeType =
    | Classic
    | Flexible

/// The billing mode of the quote.
type QuotesResourceSubscriptionDataBillingMode =
    {
        Flexible: SubscriptionsResourceBillingModeFlexible option
        /// Controls how prorations and invoices for subscriptions are calculated and orchestrated.
        Type: QuotesResourceSubscriptionDataBillingModeType
    }

type QuotesResourceSubscriptionDataBillingMode with
    static member New(``type``: QuotesResourceSubscriptionDataBillingModeType, ?flexible: SubscriptionsResourceBillingModeFlexible) =
        {
            Type = ``type``
            Flexible = flexible
        }

type QuotesResourceSubscriptionDataSubscriptionData =
    {
        BillingMode: QuotesResourceSubscriptionDataBillingMode
        /// The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.
        Description: string option
        /// When creating a new subscription, the date of which the subscription schedule will start after the quote is accepted. This date is ignored if it is in the past when the quote is accepted. Measured in seconds since the Unix epoch.
        EffectiveDate: DateTime option
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that will set metadata on the subscription or subscription schedule when the quote is accepted. If a recurring price is included in `line_items`, this field will be passed to the resulting subscription's `metadata` field. If `subscription_data.effective_date` is used, this field will be passed to the resulting subscription schedule's `phases.metadata` field. Unlike object-level metadata, this field is declarative. Updates will clear prior values.
        Metadata: Map<string, string> option
        /// Integer representing the number of trial period days before the customer is charged for the first time.
        TrialPeriodDays: int option
    }

type QuotesResourceSubscriptionDataSubscriptionData with
    static member New(billingMode: QuotesResourceSubscriptionDataBillingMode, description: string option, effectiveDate: DateTime option, metadata: Map<string, string> option, trialPeriodDays: int option) =
        {
            BillingMode = billingMode
            Description = description
            EffectiveDate = effectiveDate
            Metadata = metadata
            TrialPeriodDays = trialPeriodDays
        }

type QuotesResourceTransferData =
    {
        /// The amount in cents (or local equivalent) that will be transferred to the destination account when the invoice is paid. By default, the entire amount is transferred to the destination.
        Amount: int option
        /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount will be transferred to the destination.
        AmountPercent: decimal option
        /// The account where funds from the payment will be transferred to upon payment success.
        Destination: StripeId<Markers.Account>
    }

type QuotesResourceTransferData with
    static member New(amount: int option, amountPercent: decimal option, destination: StripeId<Markers.Account>) =
        {
            Amount = amount
            AmountPercent = amountPercent
            Destination = destination
        }

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
        DefaultTaxRates: StripeId<Markers.TaxRate> list option
        /// A description that will be displayed on the quote PDF.
        Description: string option
        /// The discounts applied to this quote.
        Discounts: StripeId<Markers.Discount> list
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
        OnBehalfOf: StripeId<Markers.Account> option
        /// The status of the quote.
        Status: QuoteStatus
        StatusTransitions: QuotesResourceStatusTransitions
        /// The subscription that was created or updated from this quote.
        Subscription: StripeId<Markers.Subscription> option
        SubscriptionData: QuotesResourceSubscriptionDataSubscriptionData
        /// The subscription schedule that was created or updated from this quote.
        SubscriptionSchedule: StripeId<Markers.SubscriptionSchedule> option
        /// ID of the test clock this quote belongs to.
        TestClock: StripeId<Markers.TestHelpersTestClock> option
        TotalDetails: QuotesResourceTotalDetails
        /// The account (if any) the payments will be attributed to for tax reporting, and where funds from each payment will be transferred to for each of the invoices.
        TransferData: QuotesResourceTransferData option
    }

type Quote with
    static member New(amountSubtotal: int, amountTotal: int, application: QuoteApplication'AnyOf option, applicationFeeAmount: int option, applicationFeePercent: decimal option, automaticTax: QuotesResourceAutomaticTax, collectionMethod: QuoteCollectionMethod, computed: QuotesResourceComputed, created: DateTime, currency: IsoTypes.IsoCurrencyCode option, customer: QuoteCustomer'AnyOf option, customerAccount: string option, description: string option, discounts: StripeId<Markers.Discount> list, expiresAt: DateTime, footer: string option, fromQuote: QuotesResourceFromQuote option, header: string option, id: string, invoice: QuoteInvoice'AnyOf option, invoiceSettings: InvoiceSettingQuoteSetting, livemode: bool, metadata: Map<string, string>, number: string option, onBehalfOf: StripeId<Markers.Account> option, status: QuoteStatus, statusTransitions: QuotesResourceStatusTransitions, subscription: StripeId<Markers.Subscription> option, subscriptionData: QuotesResourceSubscriptionDataSubscriptionData, subscriptionSchedule: StripeId<Markers.SubscriptionSchedule> option, testClock: StripeId<Markers.TestHelpersTestClock> option, totalDetails: QuotesResourceTotalDetails, transferData: QuotesResourceTransferData option, ?defaultTaxRates: StripeId<Markers.TaxRate> list, ?lineItems: QuoteLineItems) =
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
            DefaultTaxRates = defaultTaxRates
            LineItems = lineItems
        }

module Quote =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "quote"

/// Occurs whenever a quote is accepted.
type QuoteAccepted = { Object: Quote }

type QuoteAccepted with
    static member New(object: Quote) =
        {
            Object = object
        }

/// Occurs whenever a quote is canceled.
type QuoteCanceled = { Object: Quote }

type QuoteCanceled with
    static member New(object: Quote) =
        {
            Object = object
        }

/// Occurs whenever a quote is created.
type QuoteCreated = { Object: Quote }

type QuoteCreated with
    static member New(object: Quote) =
        {
            Object = object
        }

/// Occurs whenever a quote is finalized.
type QuoteFinalized = { Object: Quote }

type QuoteFinalized with
    static member New(object: Quote) =
        {
            Object = object
        }

