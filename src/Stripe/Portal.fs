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

module PortalFlowsAfterCompletionHostedConfirmation =
    let create
        (
            customMessage: string option
        ) : PortalFlowsAfterCompletionHostedConfirmation
        =
        {
          CustomMessage = customMessage
        }

type PortalFlowsAfterCompletionRedirect =
    {
        /// The URL the customer will be redirected to after the flow is completed.
        ReturnUrl: string
    }

module PortalFlowsAfterCompletionRedirect =
    let create
        (
            returnUrl: string
        ) : PortalFlowsAfterCompletionRedirect
        =
        {
          ReturnUrl = returnUrl
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

module PortalFlowsFlowAfterCompletion =
    let create
        (
            hostedConfirmation: PortalFlowsAfterCompletionHostedConfirmation option,
            redirect: PortalFlowsAfterCompletionRedirect option,
            ``type``: PortalFlowsFlowAfterCompletionType
        ) : PortalFlowsFlowAfterCompletion
        =
        {
          HostedConfirmation = hostedConfirmation
          Redirect = redirect
          Type = ``type``
        }

type PortalFlowsCouponOffer =
    {
        /// The ID of the coupon to be offered.
        Coupon: string
    }

module PortalFlowsCouponOffer =
    let create
        (
            coupon: string
        ) : PortalFlowsCouponOffer
        =
        {
          Coupon = coupon
        }

type PortalFlowsRetention =
    {
        /// Configuration when `retention.type=coupon_offer`.
        CouponOffer: PortalFlowsCouponOffer option
    }

module PortalFlowsRetention =
    ///Type of retention strategy that will be used.
    let ``type`` = "coupon_offer"

    let create
        (
            couponOffer: PortalFlowsCouponOffer option
        ) : PortalFlowsRetention
        =
        {
          CouponOffer = couponOffer
        }

type PortalFlowsFlowSubscriptionCancel =
    {
        /// Specify a retention strategy to be used in the cancellation flow.
        Retention: PortalFlowsRetention option
        /// The ID of the subscription to be canceled.
        Subscription: string
    }

module PortalFlowsFlowSubscriptionCancel =
    let create
        (
            retention: PortalFlowsRetention option,
            subscription: string
        ) : PortalFlowsFlowSubscriptionCancel
        =
        {
          Retention = retention
          Subscription = subscription
        }

type PortalFlowsFlowSubscriptionUpdate =
    {
        /// The ID of the subscription to be updated.
        Subscription: string
    }

module PortalFlowsFlowSubscriptionUpdate =
    let create
        (
            subscription: string
        ) : PortalFlowsFlowSubscriptionUpdate
        =
        {
          Subscription = subscription
        }

type PortalFlowsSubscriptionUpdateConfirmDiscount =
    {
        /// The ID of the coupon to apply to this subscription update.
        Coupon: string option
        /// The ID of a promotion code to apply to this subscription update.
        PromotionCode: string option
    }

module PortalFlowsSubscriptionUpdateConfirmDiscount =
    let create
        (
            coupon: string option,
            promotionCode: string option
        ) : PortalFlowsSubscriptionUpdateConfirmDiscount
        =
        {
          Coupon = coupon
          PromotionCode = promotionCode
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

module PortalFlowsSubscriptionUpdateConfirmItem =
    let create
        (
            id: string option,
            price: string option,
            quantity: int option
        ) : PortalFlowsSubscriptionUpdateConfirmItem
        =
        {
          Id = id
          Price = price
          Quantity = quantity
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

module PortalFlowsFlowSubscriptionUpdateConfirm =
    let create
        (
            discounts: PortalFlowsSubscriptionUpdateConfirmDiscount list option,
            items: PortalFlowsSubscriptionUpdateConfirmItem list,
            subscription: string
        ) : PortalFlowsFlowSubscriptionUpdateConfirm
        =
        {
          Discounts = discounts
          Items = items
          Subscription = subscription
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

module PortalFlowsFlow =
    let create
        (
            afterCompletion: PortalFlowsFlowAfterCompletion,
            subscriptionCancel: PortalFlowsFlowSubscriptionCancel option,
            subscriptionUpdate: PortalFlowsFlowSubscriptionUpdate option,
            subscriptionUpdateConfirm: PortalFlowsFlowSubscriptionUpdateConfirm option,
            ``type``: PortalFlowsFlowType
        ) : PortalFlowsFlow
        =
        {
          AfterCompletion = afterCompletion
          SubscriptionCancel = subscriptionCancel
          SubscriptionUpdate = subscriptionUpdate
          SubscriptionUpdateConfirm = subscriptionUpdateConfirm
          Type = ``type``
        }

type PortalLoginPage =
    {
        /// If `true`, a shareable `url` will be generated that will take your customers to a hosted login page for the customer portal.
        /// If `false`, the previously generated `url`, if any, will be deactivated.
        Enabled: bool
        /// A shareable URL to the hosted portal login page. Your customers will be able to log in with their [email](https://docs.stripe.com/api/customers/object#customer_object-email) and receive a link to their customer portal.
        Url: string option
    }

module PortalLoginPage =
    let create
        (
            enabled: bool,
            url: string option
        ) : PortalLoginPage
        =
        {
          Enabled = enabled
          Url = url
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

module PortalCustomerUpdate =
    let create
        (
            allowedUpdates: PortalCustomerUpdateAllowedUpdates list,
            enabled: bool
        ) : PortalCustomerUpdate
        =
        {
          AllowedUpdates = allowedUpdates
          Enabled = enabled
        }

type PortalInvoiceList =
    {
        /// Whether the feature is enabled.
        Enabled: bool
    }

module PortalInvoiceList =
    let create
        (
            enabled: bool
        ) : PortalInvoiceList
        =
        {
          Enabled = enabled
        }

type PortalPaymentMethodUpdate =
    {
        /// Whether the feature is enabled.
        Enabled: bool
        /// The [Payment Method Configuration](/api/payment_method_configurations) to use for this portal session. When specified, customers will be able to update their payment method to one of the options specified by the payment method configuration. If not set, the default payment method configuration is used.
        PaymentMethodConfiguration: string option
    }

module PortalPaymentMethodUpdate =
    let create
        (
            enabled: bool,
            paymentMethodConfiguration: string option
        ) : PortalPaymentMethodUpdate
        =
        {
          Enabled = enabled
          PaymentMethodConfiguration = paymentMethodConfiguration
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

module PortalSubscriptionCancellationReason =
    let create
        (
            enabled: bool,
            options: PortalSubscriptionCancellationReasonOptions list
        ) : PortalSubscriptionCancellationReason
        =
        {
          Enabled = enabled
          Options = options
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

module PortalSubscriptionCancel =
    let create
        (
            cancellationReason: PortalSubscriptionCancellationReason,
            enabled: bool,
            mode: PortalSubscriptionCancelMode,
            prorationBehavior: PortalSubscriptionCancelProrationBehavior
        ) : PortalSubscriptionCancel
        =
        {
          CancellationReason = cancellationReason
          Enabled = enabled
          Mode = mode
          ProrationBehavior = prorationBehavior
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

module PortalResourceScheduleUpdateAtPeriodEndCondition =
    let create
        (
            ``type``: PortalResourceScheduleUpdateAtPeriodEndConditionType
        ) : PortalResourceScheduleUpdateAtPeriodEndCondition
        =
        {
          Type = ``type``
        }

type PortalResourceScheduleUpdateAtPeriodEnd =
    {
        /// List of conditions. When any condition is true, an update will be scheduled at the end of the current period.
        Conditions: PortalResourceScheduleUpdateAtPeriodEndCondition list
    }

module PortalResourceScheduleUpdateAtPeriodEnd =
    let create
        (
            conditions: PortalResourceScheduleUpdateAtPeriodEndCondition list
        ) : PortalResourceScheduleUpdateAtPeriodEnd
        =
        {
          Conditions = conditions
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

module PortalSubscriptionUpdateProductAdjustableQuantity =
    let create
        (
            enabled: bool,
            maximum: int option,
            minimum: int
        ) : PortalSubscriptionUpdateProductAdjustableQuantity
        =
        {
          Enabled = enabled
          Maximum = maximum
          Minimum = minimum
        }

type PortalSubscriptionUpdateProduct =
    {
        AdjustableQuantity: PortalSubscriptionUpdateProductAdjustableQuantity
        /// The list of price IDs which, when subscribed to, a subscription can be updated.
        Prices: string list
        /// The product ID.
        Product: string
    }

module PortalSubscriptionUpdateProduct =
    let create
        (
            adjustableQuantity: PortalSubscriptionUpdateProductAdjustableQuantity,
            prices: string list,
            product: string
        ) : PortalSubscriptionUpdateProduct
        =
        {
          AdjustableQuantity = adjustableQuantity
          Prices = prices
          Product = product
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

module PortalSubscriptionUpdate =
    let create
        (
            billingCycleAnchor: PortalSubscriptionUpdateBillingCycleAnchor option,
            defaultAllowedUpdates: PortalSubscriptionUpdateDefaultAllowedUpdates list,
            enabled: bool,
            prorationBehavior: PortalSubscriptionUpdateProrationBehavior,
            scheduleAtPeriodEnd: PortalResourceScheduleUpdateAtPeriodEnd,
            trialUpdateBehavior: PortalSubscriptionUpdateTrialUpdateBehavior,
            products: PortalSubscriptionUpdateProduct list option option
        ) : PortalSubscriptionUpdate
        =
        {
          BillingCycleAnchor = billingCycleAnchor
          DefaultAllowedUpdates = defaultAllowedUpdates
          Enabled = enabled
          ProrationBehavior = prorationBehavior
          ScheduleAtPeriodEnd = scheduleAtPeriodEnd
          TrialUpdateBehavior = trialUpdateBehavior
          Products = products |> Option.flatten
        }

type PortalFeatures =
    { CustomerUpdate: PortalCustomerUpdate
      InvoiceHistory: PortalInvoiceList
      PaymentMethodUpdate: PortalPaymentMethodUpdate
      SubscriptionCancel: PortalSubscriptionCancel
      SubscriptionUpdate: PortalSubscriptionUpdate }

module PortalFeatures =
    let create
        (
            customerUpdate: PortalCustomerUpdate,
            invoiceHistory: PortalInvoiceList,
            paymentMethodUpdate: PortalPaymentMethodUpdate,
            subscriptionCancel: PortalSubscriptionCancel,
            subscriptionUpdate: PortalSubscriptionUpdate
        ) : PortalFeatures
        =
        {
          CustomerUpdate = customerUpdate
          InvoiceHistory = invoiceHistory
          PaymentMethodUpdate = paymentMethodUpdate
          SubscriptionCancel = subscriptionCancel
          SubscriptionUpdate = subscriptionUpdate
        }

type PortalBusinessProfile =
    {
        /// The messaging shown to customers in the portal.
        Headline: string option
        /// A link to the business’s publicly available privacy policy.
        PrivacyPolicyUrl: string option
        /// A link to the business’s publicly available terms of service.
        TermsOfServiceUrl: string option
    }

module PortalBusinessProfile =
    let create
        (
            headline: string option,
            privacyPolicyUrl: string option,
            termsOfServiceUrl: string option
        ) : PortalBusinessProfile
        =
        {
          Headline = headline
          PrivacyPolicyUrl = privacyPolicyUrl
          TermsOfServiceUrl = termsOfServiceUrl
        }

