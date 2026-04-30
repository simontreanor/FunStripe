namespace Stripe.Portal

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type PortalFlowsAfterCompletionHostedConfirmation =
    {
        /// A custom message to display to the customer after the flow is completed.
        CustomMessage: string option
    }

type PortalFlowsAfterCompletionRedirect =
    {
        /// The URL the customer will be redirected to after the flow is completed.
        ReturnUrl: string
    }

[<Struct>]
type PortalFlowsFlowAfterCompletionType =
    | HostedConfirmation
    | PortalHomepage
    | Redirect

type PortalFlowsFlowAfterCompletion =
    {
        /// Configuration when `after_completion.type=hosted_confirmation`.
        HostedConfirmation: PortalFlowsAfterCompletionHostedConfirmation option
        /// Configuration when `after_completion.type=redirect`.
        Redirect: PortalFlowsAfterCompletionRedirect option
        /// The specified type of behavior after the flow is completed.
        Type: PortalFlowsFlowAfterCompletionType
    }

type PortalFlowsCouponOffer =
    {
        /// The ID of the coupon to be offered.
        Coupon: string
    }

type PortalFlowsRetention =
    {
        /// Configuration when `retention.type=coupon_offer`.
        CouponOffer: PortalFlowsCouponOffer option
    }

module PortalFlowsRetention =
    ///Type of retention strategy that will be used.
    let ``type`` = "coupon_offer"

type PortalFlowsFlowSubscriptionCancel =
    {
        /// Specify a retention strategy to be used in the cancellation flow.
        Retention: PortalFlowsRetention option
        /// The ID of the subscription to be canceled.
        Subscription: string
    }

type PortalFlowsFlowSubscriptionUpdate =
    {
        /// The ID of the subscription to be updated.
        Subscription: string
    }

type PortalFlowsSubscriptionUpdateConfirmDiscount =
    {
        /// The ID of the coupon to apply to this subscription update.
        Coupon: string option
        /// The ID of a promotion code to apply to this subscription update.
        PromotionCode: string option
    }

type PortalFlowsSubscriptionUpdateConfirmItem =
    {
        /// The ID of the [subscription item](https://docs.stripe.com/api/subscriptions/object#subscription_object-items-data-id) to be updated.
        Id: string option
        /// The price the customer should subscribe to through this flow. The price must also be included in the configuration's [`features.subscription_update.products`](https://docs.stripe.com/api/customer_portal/configuration#portal_configuration_object-features-subscription_update-products).
        Price: string option
        /// [Quantity](https://docs.stripe.com/subscriptions/quantities) for this item that the customer should subscribe to through this flow.
        Quantity: int option
    }

type PortalFlowsFlowSubscriptionUpdateConfirm =
    {
        /// The coupon or promotion code to apply to this subscription update.
        Discounts: PortalFlowsSubscriptionUpdateConfirmDiscount list option
        /// The [subscription item](https://docs.stripe.com/api/subscription_items) to be updated through this flow. Currently, only up to one may be specified and subscriptions with multiple items are not updatable.
        Items: PortalFlowsSubscriptionUpdateConfirmItem list
        /// The ID of the subscription to be updated.
        Subscription: string
    }

[<Struct>]
type PortalFlowsFlowType =
    | PaymentMethodUpdate
    | SubscriptionCancel
    | SubscriptionUpdate
    | SubscriptionUpdateConfirm

type PortalFlowsFlow =
    {
        AfterCompletion: PortalFlowsFlowAfterCompletion
        /// Configuration when `flow.type=subscription_cancel`.
        SubscriptionCancel: PortalFlowsFlowSubscriptionCancel option
        /// Configuration when `flow.type=subscription_update`.
        SubscriptionUpdate: PortalFlowsFlowSubscriptionUpdate option
        /// Configuration when `flow.type=subscription_update_confirm`.
        SubscriptionUpdateConfirm: PortalFlowsFlowSubscriptionUpdateConfirm option
        /// Type of flow that the customer will go through.
        Type: PortalFlowsFlowType
    }

type PortalLoginPage =
    {
        /// If `true`, a shareable `url` will be generated that will take your customers to a hosted login page for the customer portal.
        /// If `false`, the previously generated `url`, if any, will be deactivated.
        Enabled: bool
        /// A shareable URL to the hosted portal login page. Your customers will be able to log in with their [email](https://docs.stripe.com/api/customers/object#customer_object-email) and receive a link to their customer portal.
        Url: string option
    }

type PortalCustomerUpdateAllowedUpdates =
    | Address
    | Email
    | Name
    | Phone
    | Shipping
    | TaxId

type PortalCustomerUpdate =
    {
        /// The types of customer updates that are supported. When empty, customers are not updateable.
        AllowedUpdates: PortalCustomerUpdateAllowedUpdates list
        /// Whether the feature is enabled.
        Enabled: bool
    }

type PortalInvoiceList =
    {
        /// Whether the feature is enabled.
        Enabled: bool
    }

type PortalPaymentMethodUpdate =
    {
        /// Whether the feature is enabled.
        Enabled: bool
        /// The [Payment Method Configuration](/api/payment_method_configurations) to use for this portal session. When specified, customers will be able to update their payment method to one of the options specified by the payment method configuration. If not set, the default payment method configuration is used.
        PaymentMethodConfiguration: string option
    }

[<Struct>]
type PortalSubscriptionCancelMode =
    | AtPeriodEnd
    | Immediately

[<Struct>]
type PortalSubscriptionCancelProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | [<JsonPropertyName("none")>] None'

type PortalSubscriptionCancellationReasonOptions =
    | CustomerService
    | LowQuality
    | MissingFeatures
    | Other
    | SwitchedService
    | TooComplex
    | TooExpensive
    | Unused

type PortalSubscriptionCancellationReason =
    {
        /// Whether the feature is enabled.
        Enabled: bool
        /// Which cancellation reasons will be given as options to the customer.
        Options: PortalSubscriptionCancellationReasonOptions list
    }

type PortalSubscriptionCancel =
    {
        CancellationReason: PortalSubscriptionCancellationReason
        /// Whether the feature is enabled.
        Enabled: bool
        /// Whether to cancel subscriptions immediately or at the end of the billing period.
        Mode: PortalSubscriptionCancelMode
        /// Whether to create prorations when canceling subscriptions. Possible values are `none` and `create_prorations`.
        ProrationBehavior: PortalSubscriptionCancelProrationBehavior
    }

[<Struct>]
type PortalResourceScheduleUpdateAtPeriodEndConditionType =
    | DecreasingItemAmount
    | ShorteningInterval

type PortalResourceScheduleUpdateAtPeriodEndCondition =
    {
        /// The type of condition.
        Type: PortalResourceScheduleUpdateAtPeriodEndConditionType
    }

type PortalResourceScheduleUpdateAtPeriodEnd =
    {
        /// List of conditions. When any condition is true, an update will be scheduled at the end of the current period.
        Conditions: PortalResourceScheduleUpdateAtPeriodEndCondition list
    }

[<Struct>]
type PortalSubscriptionUpdateBillingCycleAnchor =
    | Now
    | Unchanged

[<Struct>]
type PortalSubscriptionUpdateDefaultAllowedUpdates =
    | Price
    | PromotionCode
    | Quantity

type PortalSubscriptionUpdateProductAdjustableQuantity =
    {
        /// If true, the quantity can be adjusted to any non-negative integer.
        Enabled: bool
        /// The maximum quantity that can be set for the product.
        Maximum: int option
        /// The minimum quantity that can be set for the product.
        Minimum: int
    }

type PortalSubscriptionUpdateProduct =
    {
        AdjustableQuantity: PortalSubscriptionUpdateProductAdjustableQuantity
        /// The list of price IDs which, when subscribed to, a subscription can be updated.
        Prices: string list
        /// The product ID.
        Product: string
    }

[<Struct>]
type PortalSubscriptionUpdateProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | [<JsonPropertyName("none")>] None'

[<Struct>]
type PortalSubscriptionUpdateTrialUpdateBehavior =
    | ContinueTrial
    | EndTrial

type PortalSubscriptionUpdate =
    {
        /// Determines the value to use for the billing cycle anchor on subscription updates. Valid values are `now` or `unchanged`, and the default value is `unchanged`. Setting the value to `now` resets the subscription's billing cycle anchor to the current time (in UTC). For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).
        BillingCycleAnchor: PortalSubscriptionUpdateBillingCycleAnchor option
        /// The types of subscription updates that are supported for items listed in the `products` attribute. When empty, subscriptions are not updateable.
        DefaultAllowedUpdates: PortalSubscriptionUpdateDefaultAllowedUpdates list
        /// Whether the feature is enabled.
        Enabled: bool
        /// The list of up to 10 products that support subscription updates.
        Products: PortalSubscriptionUpdateProduct list option
        /// Determines how to handle prorations resulting from subscription updates. Valid values are `none`, `create_prorations`, and `always_invoice`. Defaults to a value of `none` if you don't set it during creation.
        ProrationBehavior: PortalSubscriptionUpdateProrationBehavior
        ScheduleAtPeriodEnd: PortalResourceScheduleUpdateAtPeriodEnd
        /// Determines how handle updates to trialing subscriptions. Valid values are `end_trial` and `continue_trial`. Defaults to a value of `end_trial` if you don't set it during creation.
        TrialUpdateBehavior: PortalSubscriptionUpdateTrialUpdateBehavior
    }

type PortalFeatures =
    { CustomerUpdate: PortalCustomerUpdate
      InvoiceHistory: PortalInvoiceList
      PaymentMethodUpdate: PortalPaymentMethodUpdate
      SubscriptionCancel: PortalSubscriptionCancel
      SubscriptionUpdate: PortalSubscriptionUpdate }

type PortalBusinessProfile =
    {
        /// The messaging shown to customers in the portal.
        Headline: string option
        /// A link to the business’s publicly available privacy policy.
        PrivacyPolicyUrl: string option
        /// A link to the business’s publicly available terms of service.
        TermsOfServiceUrl: string option
    }

