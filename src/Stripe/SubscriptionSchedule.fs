namespace Stripe.SubscriptionSchedule

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Application
open Stripe.PaymentMethod
open Stripe.Plan
open Stripe.Price
open Stripe.SubscriptionItem
open Stripe.TaxRate

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type SchedulesPhaseAutomaticTax =
    {
        /// Whether Stripe automatically computes tax on invoices created during this phase.
        Enabled: bool
        /// The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.
        Liability: ConnectAccountReference option
    }

type SchedulesPhaseAutomaticTax with
    static member New(enabled: bool, liability: ConnectAccountReference option) =
        {
            Enabled = enabled
            Liability = liability
        }

module SchedulesPhaseAutomaticTax =
    ///If Stripe disabled automatic tax, this enum describes why.
    let disabledReason = "requires_location_inputs"

type StackableDiscountWithDiscountSettings =
    {
        /// ID of the coupon to create a new discount for.
        Coupon: StripeId<Markers.Coupon> option
        /// ID of an existing discount on the object (or one of its ancestors) to reuse.
        Discount: StripeId<Markers.Discount> option
        /// ID of the promotion code to create a new discount for.
        PromotionCode: StripeId<Markers.PromotionCode> option
    }

type StackableDiscountWithDiscountSettings with
    static member New(coupon: StripeId<Markers.Coupon> option, discount: StripeId<Markers.Discount> option, promotionCode: StripeId<Markers.PromotionCode> option) =
        {
            Coupon = coupon
            Discount = discount
            PromotionCode = promotionCode
        }

type StackableDiscountWithDiscountSettingsAndDiscountEnd =
    {
        /// ID of the coupon to create a new discount for.
        Coupon: StripeId<Markers.Coupon> option
        /// ID of an existing discount on the object (or one of its ancestors) to reuse.
        Discount: StripeId<Markers.Discount> option
        /// ID of the promotion code to create a new discount for.
        PromotionCode: StripeId<Markers.PromotionCode> option
    }

type StackableDiscountWithDiscountSettingsAndDiscountEnd with
    static member New(coupon: StripeId<Markers.Coupon> option, discount: StripeId<Markers.Discount> option, promotionCode: StripeId<Markers.PromotionCode> option) =
        {
            Coupon = coupon
            Discount = discount
            PromotionCode = promotionCode
        }

type SubscriptionScheduleApplication'AnyOf =
    | String of string
    | Application of Application
    | DeletedApplication of DeletedApplication

type SubscriptionScheduleCurrentPhase =
    {
        /// The end of this phase of the subscription schedule.
        EndDate: DateTime
        /// The start of this phase of the subscription schedule.
        StartDate: DateTime
    }

type SubscriptionScheduleCurrentPhase with
    static member New(endDate: DateTime, startDate: DateTime) =
        {
            EndDate = endDate
            StartDate = startDate
        }

type SubscriptionScheduleCustomer'AnyOf =
    | String of string
    | Customer of Customer
    | DeletedCustomer of DeletedCustomer

[<Struct>]
type SubscriptionScheduleEndBehavior =
    | Cancel
    | [<JsonPropertyName("none")>] None'
    | Release
    | Renew

type SubscriptionScheduleAddInvoiceItemPeriod =
    { End: SubscriptionSchedulesResourceInvoiceItemPeriodResourcePeriodEnd
      Start: SubscriptionSchedulesResourceInvoiceItemPeriodResourcePeriodStart }

type SubscriptionScheduleAddInvoiceItemPeriod with
    static member New(``end``: SubscriptionSchedulesResourceInvoiceItemPeriodResourcePeriodEnd, start: SubscriptionSchedulesResourceInvoiceItemPeriodResourcePeriodStart) =
        {
            End = ``end``
            Start = start
        }

type SubscriptionScheduleAddInvoiceItemPrice'AnyOf =
    | String of string
    | Price of Price
    | DeletedPrice of DeletedPrice

/// An Add Invoice Item describes the prices and quantities that will be added as pending invoice items when entering a phase.
type SubscriptionScheduleAddInvoiceItem =
    {
        /// The stackable discounts that will be applied to the item.
        Discounts: DiscountsResourceStackableDiscountWithDiscountEnd list
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        Period: SubscriptionScheduleAddInvoiceItemPeriod
        /// ID of the price used to generate the invoice item.
        Price: SubscriptionScheduleAddInvoiceItemPrice'AnyOf
        /// The quantity of the invoice item.
        Quantity: int option
        /// The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
        TaxRates: TaxRate list option
    }

type SubscriptionScheduleAddInvoiceItem with
    static member New(discounts: DiscountsResourceStackableDiscountWithDiscountEnd list, metadata: Map<string, string> option, period: SubscriptionScheduleAddInvoiceItemPeriod, price: SubscriptionScheduleAddInvoiceItemPrice'AnyOf, quantity: int option, ?taxRates: TaxRate list option) =
        {
            Discounts = discounts
            Metadata = metadata
            Period = period
            Price = price
            Quantity = quantity
            TaxRates = taxRates |> Option.flatten
        }

type SubscriptionScheduleConfigurationItemPlan'AnyOf =
    | String of string
    | Plan of Plan
    | DeletedPlan of DeletedPlan

type SubscriptionScheduleConfigurationItemPrice'AnyOf =
    | String of string
    | Price of Price
    | DeletedPrice of DeletedPrice

/// A phase item describes the price and quantity of a phase.
type SubscriptionScheduleConfigurationItem =
    {
        /// Define thresholds at which an invoice will be sent, and the related subscription advanced to a new billing period
        BillingThresholds: SubscriptionItemBillingThresholds option
        /// The discounts applied to the subscription item. Subscription item discounts are applied before subscription discounts. Use `expand[]=discounts` to expand each discount.
        Discounts: StackableDiscountWithDiscountSettings list
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an item. Metadata on this item will update the underlying subscription item's `metadata` when the phase is entered.
        Metadata: Map<string, string> option
        /// ID of the plan to which the customer should be subscribed.
        Plan: SubscriptionScheduleConfigurationItemPlan'AnyOf
        /// ID of the price to which the customer should be subscribed.
        Price: SubscriptionScheduleConfigurationItemPrice'AnyOf
        /// Quantity of the plan to which the customer should be subscribed.
        Quantity: int option
        /// The tax rates which apply to this `phase_item`. When set, the `default_tax_rates` on the phase do not apply to this `phase_item`.
        TaxRates: TaxRate list option
    }

type SubscriptionScheduleConfigurationItem with
    static member New(billingThresholds: SubscriptionItemBillingThresholds option, discounts: StackableDiscountWithDiscountSettings list, metadata: Map<string, string> option, plan: SubscriptionScheduleConfigurationItemPlan'AnyOf, price: SubscriptionScheduleConfigurationItemPrice'AnyOf, ?quantity: int, ?taxRates: TaxRate list option) =
        {
            BillingThresholds = billingThresholds
            Discounts = discounts
            Metadata = metadata
            Plan = plan
            Price = price
            Quantity = quantity
            TaxRates = taxRates |> Option.flatten
        }

[<Struct>]
type SubscriptionSchedulePhaseConfigurationBillingCycleAnchor =
    | Automatic
    | PhaseStart

[<Struct>]
type SubscriptionSchedulePhaseConfigurationCollectionMethod =
    | ChargeAutomatically
    | SendInvoice

[<Struct>]
type SubscriptionSchedulePhaseConfigurationProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | [<JsonPropertyName("none")>] None'

/// A phase describes the plans, coupon, and trialing status of a subscription for a predefined time period.
type SubscriptionSchedulePhaseConfiguration =
    {
        /// A list of prices and quantities that will generate invoice items appended to the next invoice for this phase.
        AddInvoiceItems: SubscriptionScheduleAddInvoiceItem list
        /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account during this phase of the schedule.
        ApplicationFeePercent: decimal option
        AutomaticTax: SchedulesPhaseAutomaticTax option
        /// Possible values are `phase_start` or `automatic`. If `phase_start` then billing cycle anchor of the subscription is set to the start of the phase when entering the phase. If `automatic` then the billing cycle anchor is automatically modified as needed when entering the phase. For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).
        BillingCycleAnchor: SubscriptionSchedulePhaseConfigurationBillingCycleAnchor option
        /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period
        BillingThresholds: SubscriptionBillingThresholds option
        /// Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`.
        CollectionMethod: SubscriptionSchedulePhaseConfigurationCollectionMethod option
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
        DefaultPaymentMethod: StripeId<Markers.PaymentMethod> option
        /// The default tax rates to apply to the subscription during this phase of the subscription schedule.
        DefaultTaxRates: TaxRate list option
        /// Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.
        Description: string option
        /// The stackable discounts that will be applied to the subscription on this phase. Subscription item discounts are applied before subscription discounts.
        Discounts: StackableDiscountWithDiscountSettingsAndDiscountEnd list
        /// The end of this phase of the subscription schedule.
        EndDate: DateTime
        /// The invoice settings applicable during this phase.
        InvoiceSettings: InvoiceSettingSubscriptionSchedulePhaseSetting option
        /// Subscription items to configure the subscription to during this phase of the subscription schedule.
        Items: SubscriptionScheduleConfigurationItem list
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to a phase. Metadata on a schedule's phase will update the underlying subscription's `metadata` when the phase is entered. Updating the underlying subscription's `metadata` directly will not affect the current phase's `metadata`.
        Metadata: Map<string, string> option
        /// The account (if any) the charge was made on behalf of for charges associated with the schedule's subscription. See the Connect documentation for details.
        OnBehalfOf: StripeId<Markers.Account> option
        /// When transitioning phases, controls how prorations are handled (if any). Possible values are `create_prorations`, `none`, and `always_invoice`.
        ProrationBehavior: SubscriptionSchedulePhaseConfigurationProrationBehavior
        /// The start of this phase of the subscription schedule.
        StartDate: DateTime
        /// The account (if any) the associated subscription's payments will be attributed to for tax reporting, and where funds from each payment will be transferred to for each of the subscription's invoices.
        TransferData: SubscriptionTransferData option
        /// When the trial ends within the phase.
        TrialEnd: DateTime option
    }

type SubscriptionSchedulePhaseConfiguration with
    static member New(addInvoiceItems: SubscriptionScheduleAddInvoiceItem list, applicationFeePercent: decimal option, billingCycleAnchor: SubscriptionSchedulePhaseConfigurationBillingCycleAnchor option, billingThresholds: SubscriptionBillingThresholds option, collectionMethod: SubscriptionSchedulePhaseConfigurationCollectionMethod option, currency: IsoTypes.IsoCurrencyCode, defaultPaymentMethod: StripeId<Markers.PaymentMethod> option, description: string option, discounts: StackableDiscountWithDiscountSettingsAndDiscountEnd list, endDate: DateTime, invoiceSettings: InvoiceSettingSubscriptionSchedulePhaseSetting option, items: SubscriptionScheduleConfigurationItem list, metadata: Map<string, string> option, onBehalfOf: StripeId<Markers.Account> option, prorationBehavior: SubscriptionSchedulePhaseConfigurationProrationBehavior, startDate: DateTime, transferData: SubscriptionTransferData option, trialEnd: DateTime option, ?automaticTax: SchedulesPhaseAutomaticTax, ?defaultTaxRates: TaxRate list option) =
        {
            AddInvoiceItems = addInvoiceItems
            ApplicationFeePercent = applicationFeePercent
            BillingCycleAnchor = billingCycleAnchor
            BillingThresholds = billingThresholds
            CollectionMethod = collectionMethod
            Currency = currency
            DefaultPaymentMethod = defaultPaymentMethod
            Description = description
            Discounts = discounts
            EndDate = endDate
            InvoiceSettings = invoiceSettings
            Items = items
            Metadata = metadata
            OnBehalfOf = onBehalfOf
            ProrationBehavior = prorationBehavior
            StartDate = startDate
            TransferData = transferData
            TrialEnd = trialEnd
            AutomaticTax = automaticTax
            DefaultTaxRates = defaultTaxRates |> Option.flatten
        }

[<Struct>]
type SubscriptionScheduleStatus =
    | Active
    | Canceled
    | Completed
    | NotStarted
    | Released

/// A subscription schedule allows you to create and manage the lifecycle of a subscription by predefining expected changes.
/// Related guide: [Subscription schedules](https://docs.stripe.com/billing/subscriptions/subscription-schedules)
type SubscriptionSchedule =
    {
        /// ID of the Connect Application that created the schedule.
        Application: SubscriptionScheduleApplication'AnyOf option
        BillingMode: SubscriptionsResourceBillingMode
        /// Time at which the subscription schedule was canceled. Measured in seconds since the Unix epoch.
        CanceledAt: DateTime option
        /// Time at which the subscription schedule was completed. Measured in seconds since the Unix epoch.
        CompletedAt: DateTime option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Object representing the start and end dates for the current phase of the subscription schedule, if it is `active`.
        CurrentPhase: SubscriptionScheduleCurrentPhase option
        /// ID of the customer who owns the subscription schedule.
        Customer: SubscriptionScheduleCustomer'AnyOf
        /// ID of the account who owns the subscription schedule.
        CustomerAccount: string option
        DefaultSettings: SubscriptionSchedulesResourceDefaultSettings
        /// Behavior of the subscription schedule and underlying subscription when it ends. Possible values are `release` or `cancel` with the default being `release`. `release` will end the subscription schedule and keep the underlying subscription running. `cancel` will end the subscription schedule and cancel the underlying subscription.
        EndBehavior: SubscriptionScheduleEndBehavior
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// Configuration for the subscription schedule's phases.
        Phases: SubscriptionSchedulePhaseConfiguration list
        /// Time at which the subscription schedule was released. Measured in seconds since the Unix epoch.
        ReleasedAt: DateTime option
        /// ID of the subscription once managed by the subscription schedule (if it is released).
        ReleasedSubscription: string option
        /// The present status of the subscription schedule. Possible values are `not_started`, `active`, `completed`, `released`, and `canceled`. You can read more about the different states in our [behavior guide](https://docs.stripe.com/billing/subscriptions/subscription-schedules).
        Status: SubscriptionScheduleStatus
        /// ID of the subscription managed by the subscription schedule.
        Subscription: StripeId<Markers.Subscription> option
        /// ID of the test clock this subscription schedule belongs to.
        TestClock: StripeId<Markers.TestHelpersTestClock> option
    }

type SubscriptionSchedule with
    static member New(application: SubscriptionScheduleApplication'AnyOf option, billingMode: SubscriptionsResourceBillingMode, canceledAt: DateTime option, completedAt: DateTime option, created: DateTime, currentPhase: SubscriptionScheduleCurrentPhase option, customer: SubscriptionScheduleCustomer'AnyOf, customerAccount: string option, defaultSettings: SubscriptionSchedulesResourceDefaultSettings, endBehavior: SubscriptionScheduleEndBehavior, id: string, livemode: bool, metadata: Map<string, string> option, phases: SubscriptionSchedulePhaseConfiguration list, releasedAt: DateTime option, releasedSubscription: string option, status: SubscriptionScheduleStatus, subscription: StripeId<Markers.Subscription> option, testClock: StripeId<Markers.TestHelpersTestClock> option) =
        {
            Application = application
            BillingMode = billingMode
            CanceledAt = canceledAt
            CompletedAt = completedAt
            Created = created
            CurrentPhase = currentPhase
            Customer = customer
            CustomerAccount = customerAccount
            DefaultSettings = defaultSettings
            EndBehavior = endBehavior
            Id = id
            Livemode = livemode
            Metadata = metadata
            Phases = phases
            ReleasedAt = releasedAt
            ReleasedSubscription = releasedSubscription
            Status = status
            Subscription = subscription
            TestClock = testClock
        }

module SubscriptionSchedule =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "subscription_schedule"

/// Occurs whenever a subscription schedule is canceled due to the underlying subscription being canceled because of delinquency.
type SubscriptionScheduleAborted = { Object: SubscriptionSchedule }

type SubscriptionScheduleAborted with
    static member New(object: SubscriptionSchedule) =
        {
            Object = object
        }

/// Occurs whenever a subscription schedule is canceled.
type SubscriptionScheduleCanceled = { Object: SubscriptionSchedule }

type SubscriptionScheduleCanceled with
    static member New(object: SubscriptionSchedule) =
        {
            Object = object
        }

/// Occurs whenever a new subscription schedule is completed.
type SubscriptionScheduleCompleted = { Object: SubscriptionSchedule }

type SubscriptionScheduleCompleted with
    static member New(object: SubscriptionSchedule) =
        {
            Object = object
        }

/// Occurs whenever a new subscription schedule is created.
type SubscriptionScheduleCreated = { Object: SubscriptionSchedule }

type SubscriptionScheduleCreated with
    static member New(object: SubscriptionSchedule) =
        {
            Object = object
        }

/// Occurs 7 days before a subscription schedule will expire.
type SubscriptionScheduleExpiring = { Object: SubscriptionSchedule }

type SubscriptionScheduleExpiring with
    static member New(object: SubscriptionSchedule) =
        {
            Object = object
        }

/// Occurs whenever a new subscription schedule is released.
type SubscriptionScheduleReleased = { Object: SubscriptionSchedule }

type SubscriptionScheduleReleased with
    static member New(object: SubscriptionSchedule) =
        {
            Object = object
        }

/// Occurs whenever a subscription schedule is updated.
type SubscriptionScheduleUpdated = { Object: SubscriptionSchedule }

type SubscriptionScheduleUpdated with
    static member New(object: SubscriptionSchedule) =
        {
            Object = object
        }

