namespace Stripe.Quotes

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Payment

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type QuotesResourceTransferDataDestination'AnyOf =
    | String of string
    | Account of Account

type QuotesResourceTransferData =
    {
        /// The amount in cents (or local equivalent) that will be transferred to the destination account when the invoice is paid. By default, the entire amount is transferred to the destination.
        Amount: int option
        /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount will be transferred to the destination.
        AmountPercent: decimal option
        /// The account where funds from the payment will be transferred to upon payment success.
        Destination: QuotesResourceTransferDataDestination'AnyOf
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

type QuotesResourceStatusTransitions =
    {
        /// The time that the quote was accepted. Measured in seconds since Unix epoch.
        AcceptedAt: DateTime option
        /// The time that the quote was canceled. Measured in seconds since Unix epoch.
        CanceledAt: DateTime option
        /// The time that the quote was finalized. Measured in seconds since Unix epoch.
        FinalizedAt: DateTime option
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

type QuotesResourceComputed =
    {
        /// The definitive totals and line items the customer will be charged on a recurring basis. Takes into account the line items with recurring prices and discounts with `duration=forever` coupons only. Defaults to `null` if no inputted line items with recurring prices.
        Recurring: QuotesResourceRecurring option
        Upfront: QuotesResourceUpfront
    }

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

