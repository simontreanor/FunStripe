namespace StripeRequest.BillingPortal

open FunStripe
open System.Text.Json.Serialization
open Stripe.BillingPortal
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module BillingPortalConfigurations =

    type ListOptions =
        {
            /// Only return configurations that are active or inactive (e.g., pass `true` to only list active configurations).
            [<Config.Query>]
            Active: bool option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Only return the default or non-default configurations (e.g., pass `true` to only list the default configuration).
            [<Config.Query>]
            IsDefault: bool option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                active: bool option,
                endingBefore: string option,
                expand: string list option,
                isDefault: bool option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Active = active
              EndingBefore = endingBefore
              Expand = expand
              IsDefault = isDefault
              Limit = limit
              StartingAfter = startingAfter
            }

    type Create'BusinessProfile =
        {
            /// The messaging shown to customers in the portal.
            [<Config.Form>]
            Headline: Choice<string,string> option
            /// A link to the business’s publicly available privacy policy.
            [<Config.Form>]
            PrivacyPolicyUrl: string option
            /// A link to the business’s publicly available terms of service.
            [<Config.Form>]
            TermsOfServiceUrl: string option
        }

    module Create'BusinessProfile =
        let create
            (
                headline: Choice<string,string> option,
                privacyPolicyUrl: string option,
                termsOfServiceUrl: string option
            ) : Create'BusinessProfile
            =
            {
              Headline = headline
              PrivacyPolicyUrl = privacyPolicyUrl
              TermsOfServiceUrl = termsOfServiceUrl
            }

    type Create'FeaturesCustomerUpdateAllowedUpdates =
        | Address
        | Email
        | Name
        | Phone
        | Shipping
        | TaxId

    type Create'FeaturesCustomerUpdate =
        {
            /// The types of customer updates that are supported. When empty, customers are not updateable.
            [<Config.Form>]
            AllowedUpdates: Choice<Create'FeaturesCustomerUpdateAllowedUpdates list,string> option
            /// Whether the feature is enabled.
            [<Config.Form>]
            Enabled: bool option
        }

    module Create'FeaturesCustomerUpdate =
        let create
            (
                allowedUpdates: Choice<Create'FeaturesCustomerUpdateAllowedUpdates list,string> option,
                enabled: bool option
            ) : Create'FeaturesCustomerUpdate
            =
            {
              AllowedUpdates = allowedUpdates
              Enabled = enabled
            }

    type Create'FeaturesInvoiceHistory =
        {
            /// Whether the feature is enabled.
            [<Config.Form>]
            Enabled: bool option
        }

    module Create'FeaturesInvoiceHistory =
        let create
            (
                enabled: bool option
            ) : Create'FeaturesInvoiceHistory
            =
            {
              Enabled = enabled
            }

    type Create'FeaturesPaymentMethodUpdate =
        {
            /// Whether the feature is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The [Payment Method Configuration](/api/payment_method_configurations) to use for this portal session. When specified, customers will be able to update their payment method to one of the options specified by the payment method configuration. If not set or set to an empty string, the default payment method configuration is used.
            [<Config.Form>]
            PaymentMethodConfiguration: Choice<string,string> option
        }

    module Create'FeaturesPaymentMethodUpdate =
        let create
            (
                enabled: bool option,
                paymentMethodConfiguration: Choice<string,string> option
            ) : Create'FeaturesPaymentMethodUpdate
            =
            {
              Enabled = enabled
              PaymentMethodConfiguration = paymentMethodConfiguration
            }

    type Create'FeaturesSubscriptionCancelCancellationReasonOptions =
        | CustomerService
        | LowQuality
        | MissingFeatures
        | Other
        | SwitchedService
        | TooComplex
        | TooExpensive
        | Unused

    type Create'FeaturesSubscriptionCancelCancellationReason =
        {
            /// Whether the feature is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// Which cancellation reasons will be given as options to the customer.
            [<Config.Form>]
            Options: Choice<Create'FeaturesSubscriptionCancelCancellationReasonOptions list,string> option
        }

    module Create'FeaturesSubscriptionCancelCancellationReason =
        let create
            (
                enabled: bool option,
                options: Choice<Create'FeaturesSubscriptionCancelCancellationReasonOptions list,string> option
            ) : Create'FeaturesSubscriptionCancelCancellationReason
            =
            {
              Enabled = enabled
              Options = options
            }

    type Create'FeaturesSubscriptionCancelMode =
        | AtPeriodEnd
        | Immediately

    type Create'FeaturesSubscriptionCancelProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type Create'FeaturesSubscriptionCancel =
        {
            /// Whether the cancellation reasons will be collected in the portal and which options are exposed to the customer
            [<Config.Form>]
            CancellationReason: Create'FeaturesSubscriptionCancelCancellationReason option
            /// Whether the feature is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// Whether to cancel subscriptions immediately or at the end of the billing period.
            [<Config.Form>]
            Mode: Create'FeaturesSubscriptionCancelMode option
            /// Whether to create prorations when canceling subscriptions. Possible values are `none` and `create_prorations`, which is only compatible with `mode=immediately`. Passing `always_invoice` will result in an error. No prorations are generated when canceling a subscription at the end of its natural billing period.
            [<Config.Form>]
            ProrationBehavior: Create'FeaturesSubscriptionCancelProrationBehavior option
        }

    module Create'FeaturesSubscriptionCancel =
        let create
            (
                cancellationReason: Create'FeaturesSubscriptionCancelCancellationReason option,
                enabled: bool option,
                mode: Create'FeaturesSubscriptionCancelMode option,
                prorationBehavior: Create'FeaturesSubscriptionCancelProrationBehavior option
            ) : Create'FeaturesSubscriptionCancel
            =
            {
              CancellationReason = cancellationReason
              Enabled = enabled
              Mode = mode
              ProrationBehavior = prorationBehavior
            }

    type Create'FeaturesSubscriptionUpdateBillingCycleAnchor =
        | Now
        | Unchanged

    type Create'FeaturesSubscriptionUpdateDefaultAllowedUpdates =
        | Price
        | PromotionCode
        | Quantity

    type Create'FeaturesSubscriptionUpdateProductsAdjustableQuantity =
        {
            /// Set to true if the quantity can be adjusted to any non-negative integer.
            [<Config.Form>]
            Enabled: bool option
            /// The maximum quantity that can be set for the product.
            [<Config.Form>]
            Maximum: int option
            /// The minimum quantity that can be set for the product.
            [<Config.Form>]
            Minimum: int option
        }

    module Create'FeaturesSubscriptionUpdateProductsAdjustableQuantity =
        let create
            (
                enabled: bool option,
                maximum: int option,
                minimum: int option
            ) : Create'FeaturesSubscriptionUpdateProductsAdjustableQuantity
            =
            {
              Enabled = enabled
              Maximum = maximum
              Minimum = minimum
            }

    type Create'FeaturesSubscriptionUpdateProducts =
        {
            /// Control whether the quantity of the product can be adjusted.
            [<Config.Form>]
            AdjustableQuantity: Create'FeaturesSubscriptionUpdateProductsAdjustableQuantity option
            /// The list of price IDs for the product that a subscription can be updated to.
            [<Config.Form>]
            Prices: string list option
            /// The product id.
            [<Config.Form>]
            Product: string option
        }

    module Create'FeaturesSubscriptionUpdateProducts =
        let create
            (
                adjustableQuantity: Create'FeaturesSubscriptionUpdateProductsAdjustableQuantity option,
                prices: string list option,
                product: string option
            ) : Create'FeaturesSubscriptionUpdateProducts
            =
            {
              AdjustableQuantity = adjustableQuantity
              Prices = prices
              Product = product
            }

    type Create'FeaturesSubscriptionUpdateProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType =
        | DecreasingItemAmount
        | ShorteningInterval

    type Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions =
        {
            /// The type of condition.
            [<Config.Form>]
            Type: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType option
        }

    module Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions =
        let create
            (
                ``type``: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType option
            ) : Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions
            =
            {
              Type = ``type``
            }

    type Create'FeaturesSubscriptionUpdateScheduleAtPeriodEnd =
        {
            /// List of conditions. When any condition is true, the update will be scheduled at the end of the current period.
            [<Config.Form>]
            Conditions: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions list option
        }

    module Create'FeaturesSubscriptionUpdateScheduleAtPeriodEnd =
        let create
            (
                conditions: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions list option
            ) : Create'FeaturesSubscriptionUpdateScheduleAtPeriodEnd
            =
            {
              Conditions = conditions
            }

    type Create'FeaturesSubscriptionUpdateTrialUpdateBehavior =
        | ContinueTrial
        | EndTrial

    type Create'FeaturesSubscriptionUpdate =
        {
            /// Determines the value to use for the billing cycle anchor on subscription updates. Valid values are `now` or `unchanged`, and the default value is `unchanged`. Setting the value to `now` resets the subscription's billing cycle anchor to the current time (in UTC). For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).
            [<Config.Form>]
            BillingCycleAnchor: Create'FeaturesSubscriptionUpdateBillingCycleAnchor option
            /// The types of subscription updates that are supported. When empty, subscriptions are not updateable.
            [<Config.Form>]
            DefaultAllowedUpdates: Choice<Create'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string> option
            /// Whether the feature is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of up to 10 products that support subscription updates.
            [<Config.Form>]
            Products: Choice<Create'FeaturesSubscriptionUpdateProducts list,string> option
            /// Determines how to handle prorations resulting from subscription updates. Valid values are `none`, `create_prorations`, and `always_invoice`.
            [<Config.Form>]
            ProrationBehavior: Create'FeaturesSubscriptionUpdateProrationBehavior option
            /// Setting to control when an update should be scheduled at the end of the period instead of applying immediately.
            [<Config.Form>]
            ScheduleAtPeriodEnd: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEnd option
            /// The behavior when updating a subscription that is trialing.
            [<Config.Form>]
            TrialUpdateBehavior: Create'FeaturesSubscriptionUpdateTrialUpdateBehavior option
        }

    module Create'FeaturesSubscriptionUpdate =
        let create
            (
                billingCycleAnchor: Create'FeaturesSubscriptionUpdateBillingCycleAnchor option,
                defaultAllowedUpdates: Choice<Create'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string> option,
                enabled: bool option,
                products: Choice<Create'FeaturesSubscriptionUpdateProducts list,string> option,
                prorationBehavior: Create'FeaturesSubscriptionUpdateProrationBehavior option,
                scheduleAtPeriodEnd: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEnd option,
                trialUpdateBehavior: Create'FeaturesSubscriptionUpdateTrialUpdateBehavior option
            ) : Create'FeaturesSubscriptionUpdate
            =
            {
              BillingCycleAnchor = billingCycleAnchor
              DefaultAllowedUpdates = defaultAllowedUpdates
              Enabled = enabled
              Products = products
              ProrationBehavior = prorationBehavior
              ScheduleAtPeriodEnd = scheduleAtPeriodEnd
              TrialUpdateBehavior = trialUpdateBehavior
            }

    type Create'Features =
        {
            /// Information about updating the customer details in the portal.
            [<Config.Form>]
            CustomerUpdate: Create'FeaturesCustomerUpdate option
            /// Information about showing the billing history in the portal.
            [<Config.Form>]
            InvoiceHistory: Create'FeaturesInvoiceHistory option
            /// Information about updating payment methods in the portal.
            [<Config.Form>]
            PaymentMethodUpdate: Create'FeaturesPaymentMethodUpdate option
            /// Information about canceling subscriptions in the portal.
            [<Config.Form>]
            SubscriptionCancel: Create'FeaturesSubscriptionCancel option
            /// Information about updating subscriptions in the portal.
            [<Config.Form>]
            SubscriptionUpdate: Create'FeaturesSubscriptionUpdate option
        }

    module Create'Features =
        let create
            (
                customerUpdate: Create'FeaturesCustomerUpdate option,
                invoiceHistory: Create'FeaturesInvoiceHistory option,
                paymentMethodUpdate: Create'FeaturesPaymentMethodUpdate option,
                subscriptionCancel: Create'FeaturesSubscriptionCancel option,
                subscriptionUpdate: Create'FeaturesSubscriptionUpdate option
            ) : Create'Features
            =
            {
              CustomerUpdate = customerUpdate
              InvoiceHistory = invoiceHistory
              PaymentMethodUpdate = paymentMethodUpdate
              SubscriptionCancel = subscriptionCancel
              SubscriptionUpdate = subscriptionUpdate
            }

    type Create'LoginPage =
        {
            /// Set to `true` to generate a shareable URL [`login_page.url`](https://docs.stripe.com/api/customer_portal/configuration#portal_configuration_object-login_page-url) that will take your customers to a hosted login page for the customer portal.
            [<Config.Form>]
            Enabled: bool option
        }

    module Create'LoginPage =
        let create
            (
                enabled: bool option
            ) : Create'LoginPage
            =
            {
              Enabled = enabled
            }

    type CreateOptions =
        {
            /// The business information shown to customers in the portal.
            [<Config.Form>]
            BusinessProfile: Create'BusinessProfile option
            /// The default URL to redirect customers to when they click on the portal's link to return to your website. This can be [overriden](https://docs.stripe.com/api/customer_portal/sessions/create#create_portal_session-return_url) when creating the session.
            [<Config.Form>]
            DefaultReturnUrl: Choice<string,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Information about the features available in the portal.
            [<Config.Form>]
            Features: Create'Features
            /// The hosted login page for this configuration. Learn more about the portal login page in our [integration docs](https://stripe.com/docs/billing/subscriptions/integrating-customer-portal#share).
            [<Config.Form>]
            LoginPage: Create'LoginPage option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The name of the configuration.
            [<Config.Form>]
            Name: Choice<string,string> option
        }

    module CreateOptions =
        let create
            (
                features: Create'Features
            ) : CreateOptions
            =
            {
              Features = features
              BusinessProfile = None
              DefaultReturnUrl = None
              Expand = None
              LoginPage = None
              Metadata = None
              Name = None
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Configuration: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                configuration: string
            ) : RetrieveOptions
            =
            {
              Configuration = configuration
              Expand = None
            }

    type Update'BusinessProfile =
        {
            /// The messaging shown to customers in the portal.
            [<Config.Form>]
            Headline: Choice<string,string> option
            /// A link to the business’s publicly available privacy policy.
            [<Config.Form>]
            PrivacyPolicyUrl: Choice<string,string> option
            /// A link to the business’s publicly available terms of service.
            [<Config.Form>]
            TermsOfServiceUrl: Choice<string,string> option
        }

    module Update'BusinessProfile =
        let create
            (
                headline: Choice<string,string> option,
                privacyPolicyUrl: Choice<string,string> option,
                termsOfServiceUrl: Choice<string,string> option
            ) : Update'BusinessProfile
            =
            {
              Headline = headline
              PrivacyPolicyUrl = privacyPolicyUrl
              TermsOfServiceUrl = termsOfServiceUrl
            }

    type Update'FeaturesCustomerUpdateAllowedUpdates =
        | Address
        | Email
        | Name
        | Phone
        | Shipping
        | TaxId

    type Update'FeaturesCustomerUpdate =
        {
            /// The types of customer updates that are supported. When empty, customers are not updateable.
            [<Config.Form>]
            AllowedUpdates: Choice<Update'FeaturesCustomerUpdateAllowedUpdates list,string> option
            /// Whether the feature is enabled.
            [<Config.Form>]
            Enabled: bool option
        }

    module Update'FeaturesCustomerUpdate =
        let create
            (
                allowedUpdates: Choice<Update'FeaturesCustomerUpdateAllowedUpdates list,string> option,
                enabled: bool option
            ) : Update'FeaturesCustomerUpdate
            =
            {
              AllowedUpdates = allowedUpdates
              Enabled = enabled
            }

    type Update'FeaturesInvoiceHistory =
        {
            /// Whether the feature is enabled.
            [<Config.Form>]
            Enabled: bool option
        }

    module Update'FeaturesInvoiceHistory =
        let create
            (
                enabled: bool option
            ) : Update'FeaturesInvoiceHistory
            =
            {
              Enabled = enabled
            }

    type Update'FeaturesPaymentMethodUpdate =
        {
            /// Whether the feature is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The [Payment Method Configuration](/api/payment_method_configurations) to use for this portal session. When specified, customers will be able to update their payment method to one of the options specified by the payment method configuration. If not set or set to an empty string, the default payment method configuration is used.
            [<Config.Form>]
            PaymentMethodConfiguration: Choice<string,string> option
        }

    module Update'FeaturesPaymentMethodUpdate =
        let create
            (
                enabled: bool option,
                paymentMethodConfiguration: Choice<string,string> option
            ) : Update'FeaturesPaymentMethodUpdate
            =
            {
              Enabled = enabled
              PaymentMethodConfiguration = paymentMethodConfiguration
            }

    type Update'FeaturesSubscriptionCancelCancellationReasonOptions =
        | CustomerService
        | LowQuality
        | MissingFeatures
        | Other
        | SwitchedService
        | TooComplex
        | TooExpensive
        | Unused

    type Update'FeaturesSubscriptionCancelCancellationReason =
        {
            /// Whether the feature is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// Which cancellation reasons will be given as options to the customer.
            [<Config.Form>]
            Options: Choice<Update'FeaturesSubscriptionCancelCancellationReasonOptions list,string> option
        }

    module Update'FeaturesSubscriptionCancelCancellationReason =
        let create
            (
                enabled: bool option,
                options: Choice<Update'FeaturesSubscriptionCancelCancellationReasonOptions list,string> option
            ) : Update'FeaturesSubscriptionCancelCancellationReason
            =
            {
              Enabled = enabled
              Options = options
            }

    type Update'FeaturesSubscriptionCancelMode =
        | AtPeriodEnd
        | Immediately

    type Update'FeaturesSubscriptionCancelProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type Update'FeaturesSubscriptionCancel =
        {
            /// Whether the cancellation reasons will be collected in the portal and which options are exposed to the customer
            [<Config.Form>]
            CancellationReason: Update'FeaturesSubscriptionCancelCancellationReason option
            /// Whether the feature is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// Whether to cancel subscriptions immediately or at the end of the billing period.
            [<Config.Form>]
            Mode: Update'FeaturesSubscriptionCancelMode option
            /// Whether to create prorations when canceling subscriptions. Possible values are `none` and `create_prorations`, which is only compatible with `mode=immediately`. Passing `always_invoice` will result in an error. No prorations are generated when canceling a subscription at the end of its natural billing period.
            [<Config.Form>]
            ProrationBehavior: Update'FeaturesSubscriptionCancelProrationBehavior option
        }

    module Update'FeaturesSubscriptionCancel =
        let create
            (
                cancellationReason: Update'FeaturesSubscriptionCancelCancellationReason option,
                enabled: bool option,
                mode: Update'FeaturesSubscriptionCancelMode option,
                prorationBehavior: Update'FeaturesSubscriptionCancelProrationBehavior option
            ) : Update'FeaturesSubscriptionCancel
            =
            {
              CancellationReason = cancellationReason
              Enabled = enabled
              Mode = mode
              ProrationBehavior = prorationBehavior
            }

    type Update'FeaturesSubscriptionUpdateBillingCycleAnchor =
        | Now
        | Unchanged

    type Update'FeaturesSubscriptionUpdateDefaultAllowedUpdates =
        | Price
        | PromotionCode
        | Quantity

    type Update'FeaturesSubscriptionUpdateProductsAdjustableQuantity =
        {
            /// Set to true if the quantity can be adjusted to any non-negative integer.
            [<Config.Form>]
            Enabled: bool option
            /// The maximum quantity that can be set for the product.
            [<Config.Form>]
            Maximum: int option
            /// The minimum quantity that can be set for the product.
            [<Config.Form>]
            Minimum: int option
        }

    module Update'FeaturesSubscriptionUpdateProductsAdjustableQuantity =
        let create
            (
                enabled: bool option,
                maximum: int option,
                minimum: int option
            ) : Update'FeaturesSubscriptionUpdateProductsAdjustableQuantity
            =
            {
              Enabled = enabled
              Maximum = maximum
              Minimum = minimum
            }

    type Update'FeaturesSubscriptionUpdateProducts =
        {
            /// Control whether the quantity of the product can be adjusted.
            [<Config.Form>]
            AdjustableQuantity: Update'FeaturesSubscriptionUpdateProductsAdjustableQuantity option
            /// The list of price IDs for the product that a subscription can be updated to.
            [<Config.Form>]
            Prices: string list option
            /// The product id.
            [<Config.Form>]
            Product: string option
        }

    module Update'FeaturesSubscriptionUpdateProducts =
        let create
            (
                adjustableQuantity: Update'FeaturesSubscriptionUpdateProductsAdjustableQuantity option,
                prices: string list option,
                product: string option
            ) : Update'FeaturesSubscriptionUpdateProducts
            =
            {
              AdjustableQuantity = adjustableQuantity
              Prices = prices
              Product = product
            }

    type Update'FeaturesSubscriptionUpdateProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType =
        | DecreasingItemAmount
        | ShorteningInterval

    type Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions =
        {
            /// The type of condition.
            [<Config.Form>]
            Type: Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType option
        }

    module Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions =
        let create
            (
                ``type``: Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType option
            ) : Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions
            =
            {
              Type = ``type``
            }

    type Update'FeaturesSubscriptionUpdateScheduleAtPeriodEnd =
        {
            /// List of conditions. When any condition is true, the update will be scheduled at the end of the current period.
            [<Config.Form>]
            Conditions: Choice<Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions list,string> option
        }

    module Update'FeaturesSubscriptionUpdateScheduleAtPeriodEnd =
        let create
            (
                conditions: Choice<Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions list,string> option
            ) : Update'FeaturesSubscriptionUpdateScheduleAtPeriodEnd
            =
            {
              Conditions = conditions
            }

    type Update'FeaturesSubscriptionUpdateTrialUpdateBehavior =
        | ContinueTrial
        | EndTrial

    type Update'FeaturesSubscriptionUpdate =
        {
            /// Determines the value to use for the billing cycle anchor on subscription updates. Valid values are `now` or `unchanged`, and the default value is `unchanged`. Setting the value to `now` resets the subscription's billing cycle anchor to the current time (in UTC). For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).
            [<Config.Form>]
            BillingCycleAnchor: Update'FeaturesSubscriptionUpdateBillingCycleAnchor option
            /// The types of subscription updates that are supported. When empty, subscriptions are not updateable.
            [<Config.Form>]
            DefaultAllowedUpdates: Choice<Update'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string> option
            /// Whether the feature is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of up to 10 products that support subscription updates.
            [<Config.Form>]
            Products: Choice<Update'FeaturesSubscriptionUpdateProducts list,string> option
            /// Determines how to handle prorations resulting from subscription updates. Valid values are `none`, `create_prorations`, and `always_invoice`.
            [<Config.Form>]
            ProrationBehavior: Update'FeaturesSubscriptionUpdateProrationBehavior option
            /// Setting to control when an update should be scheduled at the end of the period instead of applying immediately.
            [<Config.Form>]
            ScheduleAtPeriodEnd: Update'FeaturesSubscriptionUpdateScheduleAtPeriodEnd option
            /// The behavior when updating a subscription that is trialing.
            [<Config.Form>]
            TrialUpdateBehavior: Update'FeaturesSubscriptionUpdateTrialUpdateBehavior option
        }

    module Update'FeaturesSubscriptionUpdate =
        let create
            (
                billingCycleAnchor: Update'FeaturesSubscriptionUpdateBillingCycleAnchor option,
                defaultAllowedUpdates: Choice<Update'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string> option,
                enabled: bool option,
                products: Choice<Update'FeaturesSubscriptionUpdateProducts list,string> option,
                prorationBehavior: Update'FeaturesSubscriptionUpdateProrationBehavior option,
                scheduleAtPeriodEnd: Update'FeaturesSubscriptionUpdateScheduleAtPeriodEnd option,
                trialUpdateBehavior: Update'FeaturesSubscriptionUpdateTrialUpdateBehavior option
            ) : Update'FeaturesSubscriptionUpdate
            =
            {
              BillingCycleAnchor = billingCycleAnchor
              DefaultAllowedUpdates = defaultAllowedUpdates
              Enabled = enabled
              Products = products
              ProrationBehavior = prorationBehavior
              ScheduleAtPeriodEnd = scheduleAtPeriodEnd
              TrialUpdateBehavior = trialUpdateBehavior
            }

    type Update'Features =
        {
            /// Information about updating the customer details in the portal.
            [<Config.Form>]
            CustomerUpdate: Update'FeaturesCustomerUpdate option
            /// Information about showing the billing history in the portal.
            [<Config.Form>]
            InvoiceHistory: Update'FeaturesInvoiceHistory option
            /// Information about updating payment methods in the portal.
            [<Config.Form>]
            PaymentMethodUpdate: Update'FeaturesPaymentMethodUpdate option
            /// Information about canceling subscriptions in the portal.
            [<Config.Form>]
            SubscriptionCancel: Update'FeaturesSubscriptionCancel option
            /// Information about updating subscriptions in the portal.
            [<Config.Form>]
            SubscriptionUpdate: Update'FeaturesSubscriptionUpdate option
        }

    module Update'Features =
        let create
            (
                customerUpdate: Update'FeaturesCustomerUpdate option,
                invoiceHistory: Update'FeaturesInvoiceHistory option,
                paymentMethodUpdate: Update'FeaturesPaymentMethodUpdate option,
                subscriptionCancel: Update'FeaturesSubscriptionCancel option,
                subscriptionUpdate: Update'FeaturesSubscriptionUpdate option
            ) : Update'Features
            =
            {
              CustomerUpdate = customerUpdate
              InvoiceHistory = invoiceHistory
              PaymentMethodUpdate = paymentMethodUpdate
              SubscriptionCancel = subscriptionCancel
              SubscriptionUpdate = subscriptionUpdate
            }

    type Update'LoginPage =
        {
            /// Set to `true` to generate a shareable URL [`login_page.url`](https://docs.stripe.com/api/customer_portal/configuration#portal_configuration_object-login_page-url) that will take your customers to a hosted login page for the customer portal.
            /// Set to `false` to deactivate the `login_page.url`.
            [<Config.Form>]
            Enabled: bool option
        }

    module Update'LoginPage =
        let create
            (
                enabled: bool option
            ) : Update'LoginPage
            =
            {
              Enabled = enabled
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Configuration: string
            /// Whether the configuration is active and can be used to create portal sessions.
            [<Config.Form>]
            Active: bool option
            /// The business information shown to customers in the portal.
            [<Config.Form>]
            BusinessProfile: Update'BusinessProfile option
            /// The default URL to redirect customers to when they click on the portal's link to return to your website. This can be [overriden](https://docs.stripe.com/api/customer_portal/sessions/create#create_portal_session-return_url) when creating the session.
            [<Config.Form>]
            DefaultReturnUrl: Choice<string,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Information about the features available in the portal.
            [<Config.Form>]
            Features: Update'Features option
            /// The hosted login page for this configuration. Learn more about the portal login page in our [integration docs](https://stripe.com/docs/billing/subscriptions/integrating-customer-portal#share).
            [<Config.Form>]
            LoginPage: Update'LoginPage option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The name of the configuration.
            [<Config.Form>]
            Name: Choice<string,string> option
        }

    module UpdateOptions =
        let create
            (
                configuration: string
            ) : UpdateOptions
            =
            {
              Configuration = configuration
              Active = None
              BusinessProfile = None
              DefaultReturnUrl = None
              Expand = None
              Features = None
              LoginPage = None
              Metadata = None
              Name = None
            }

    ///<p>Returns a list of configurations that describe the functionality of the customer portal.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("is_default", options.IsDefault |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/billing_portal/configurations"
        |> RestApi.getAsync<StripeList<BillingPortalConfiguration>> settings qs

    ///<p>Creates a configuration that describes the functionality and behavior of a PortalSession</p>
    let Create settings (options: CreateOptions) =
        $"/v1/billing_portal/configurations"
        |> RestApi.postAsync<_, BillingPortalConfiguration> settings (Map.empty) options

    ///<p>Retrieves a configuration that describes the functionality of the customer portal.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/billing_portal/configurations/{options.Configuration}"
        |> RestApi.getAsync<BillingPortalConfiguration> settings qs

    ///<p>Updates a configuration that describes the functionality of the customer portal.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/billing_portal/configurations/{options.Configuration}"
        |> RestApi.postAsync<_, BillingPortalConfiguration> settings (Map.empty) options

module BillingPortalSessions =

    type Create'FlowDataAfterCompletionHostedConfirmation =
        {
            /// A custom message to display to the customer after the flow is completed.
            [<Config.Form>]
            CustomMessage: string option
        }

    module Create'FlowDataAfterCompletionHostedConfirmation =
        let create
            (
                customMessage: string option
            ) : Create'FlowDataAfterCompletionHostedConfirmation
            =
            {
              CustomMessage = customMessage
            }

    type Create'FlowDataAfterCompletionRedirect =
        {
            /// The URL the customer will be redirected to after the flow is completed.
            [<Config.Form>]
            ReturnUrl: string option
        }

    module Create'FlowDataAfterCompletionRedirect =
        let create
            (
                returnUrl: string option
            ) : Create'FlowDataAfterCompletionRedirect
            =
            {
              ReturnUrl = returnUrl
            }

    type Create'FlowDataAfterCompletionType =
        | HostedConfirmation
        | PortalHomepage
        | Redirect

    type Create'FlowDataAfterCompletion =
        {
            /// Configuration when `after_completion.type=hosted_confirmation`.
            [<Config.Form>]
            HostedConfirmation: Create'FlowDataAfterCompletionHostedConfirmation option
            /// Configuration when `after_completion.type=redirect`.
            [<Config.Form>]
            Redirect: Create'FlowDataAfterCompletionRedirect option
            /// The specified behavior after the flow is completed.
            [<Config.Form>]
            Type: Create'FlowDataAfterCompletionType option
        }

    module Create'FlowDataAfterCompletion =
        let create
            (
                hostedConfirmation: Create'FlowDataAfterCompletionHostedConfirmation option,
                redirect: Create'FlowDataAfterCompletionRedirect option,
                ``type``: Create'FlowDataAfterCompletionType option
            ) : Create'FlowDataAfterCompletion
            =
            {
              HostedConfirmation = hostedConfirmation
              Redirect = redirect
              Type = ``type``
            }

    type Create'FlowDataSubscriptionCancelRetentionCouponOffer =
        {
            /// The ID of the coupon to be offered.
            [<Config.Form>]
            Coupon: string option
        }

    module Create'FlowDataSubscriptionCancelRetentionCouponOffer =
        let create
            (
                coupon: string option
            ) : Create'FlowDataSubscriptionCancelRetentionCouponOffer
            =
            {
              Coupon = coupon
            }

    type Create'FlowDataSubscriptionCancelRetentionType = | CouponOffer

    type Create'FlowDataSubscriptionCancelRetention =
        {
            /// Configuration when `retention.type=coupon_offer`.
            [<Config.Form>]
            CouponOffer: Create'FlowDataSubscriptionCancelRetentionCouponOffer option
            /// Type of retention strategy to use with the customer.
            [<Config.Form>]
            Type: Create'FlowDataSubscriptionCancelRetentionType option
        }

    module Create'FlowDataSubscriptionCancelRetention =
        let create
            (
                couponOffer: Create'FlowDataSubscriptionCancelRetentionCouponOffer option,
                ``type``: Create'FlowDataSubscriptionCancelRetentionType option
            ) : Create'FlowDataSubscriptionCancelRetention
            =
            {
              CouponOffer = couponOffer
              Type = ``type``
            }

    type Create'FlowDataSubscriptionCancel =
        {
            /// Specify a retention strategy to be used in the cancellation flow.
            [<Config.Form>]
            Retention: Create'FlowDataSubscriptionCancelRetention option
            /// The ID of the subscription to be canceled.
            [<Config.Form>]
            Subscription: string option
        }

    module Create'FlowDataSubscriptionCancel =
        let create
            (
                retention: Create'FlowDataSubscriptionCancelRetention option,
                subscription: string option
            ) : Create'FlowDataSubscriptionCancel
            =
            {
              Retention = retention
              Subscription = subscription
            }

    type Create'FlowDataSubscriptionUpdate =
        {
            /// The ID of the subscription to be updated.
            [<Config.Form>]
            Subscription: string option
        }

    module Create'FlowDataSubscriptionUpdate =
        let create
            (
                subscription: string option
            ) : Create'FlowDataSubscriptionUpdate
            =
            {
              Subscription = subscription
            }

    type Create'FlowDataSubscriptionUpdateConfirmDiscounts =
        {
            /// The ID of the coupon to apply to this subscription update.
            [<Config.Form>]
            Coupon: string option
            /// The ID of a promotion code to apply to this subscription update.
            [<Config.Form>]
            PromotionCode: string option
        }

    module Create'FlowDataSubscriptionUpdateConfirmDiscounts =
        let create
            (
                coupon: string option,
                promotionCode: string option
            ) : Create'FlowDataSubscriptionUpdateConfirmDiscounts
            =
            {
              Coupon = coupon
              PromotionCode = promotionCode
            }

    type Create'FlowDataSubscriptionUpdateConfirmItems =
        {
            /// The ID of the [subscription item](https://docs.stripe.com/api/subscriptions/object#subscription_object-items-data-id) to be updated.
            [<Config.Form>]
            Id: string option
            /// The price the customer should subscribe to through this flow. The price must also be included in the configuration's [`features.subscription_update.products`](https://docs.stripe.com/api/customer_portal/configuration#portal_configuration_object-features-subscription_update-products).
            [<Config.Form>]
            Price: string option
            /// [Quantity](https://docs.stripe.com/subscriptions/quantities) for this item that the customer should subscribe to through this flow.
            [<Config.Form>]
            Quantity: int option
        }

    module Create'FlowDataSubscriptionUpdateConfirmItems =
        let create
            (
                id: string option,
                price: string option,
                quantity: int option
            ) : Create'FlowDataSubscriptionUpdateConfirmItems
            =
            {
              Id = id
              Price = price
              Quantity = quantity
            }

    type Create'FlowDataSubscriptionUpdateConfirm =
        {
            /// The coupon or promotion code to apply to this subscription update.
            [<Config.Form>]
            Discounts: Create'FlowDataSubscriptionUpdateConfirmDiscounts list option
            /// The [subscription item](https://docs.stripe.com/api/subscription_items) to be updated through this flow. Currently, only up to one may be specified and subscriptions with multiple items are not updatable.
            [<Config.Form>]
            Items: Create'FlowDataSubscriptionUpdateConfirmItems list option
            /// The ID of the subscription to be updated.
            [<Config.Form>]
            Subscription: string option
        }

    module Create'FlowDataSubscriptionUpdateConfirm =
        let create
            (
                discounts: Create'FlowDataSubscriptionUpdateConfirmDiscounts list option,
                items: Create'FlowDataSubscriptionUpdateConfirmItems list option,
                subscription: string option
            ) : Create'FlowDataSubscriptionUpdateConfirm
            =
            {
              Discounts = discounts
              Items = items
              Subscription = subscription
            }

    type Create'FlowDataType =
        | PaymentMethodUpdate
        | SubscriptionCancel
        | SubscriptionUpdate
        | SubscriptionUpdateConfirm

    type Create'FlowData =
        {
            /// Behavior after the flow is completed.
            [<Config.Form>]
            AfterCompletion: Create'FlowDataAfterCompletion option
            /// Configuration when `flow_data.type=subscription_cancel`.
            [<Config.Form>]
            SubscriptionCancel: Create'FlowDataSubscriptionCancel option
            /// Configuration when `flow_data.type=subscription_update`.
            [<Config.Form>]
            SubscriptionUpdate: Create'FlowDataSubscriptionUpdate option
            /// Configuration when `flow_data.type=subscription_update_confirm`.
            [<Config.Form>]
            SubscriptionUpdateConfirm: Create'FlowDataSubscriptionUpdateConfirm option
            /// Type of flow that the customer will go through.
            [<Config.Form>]
            Type: Create'FlowDataType option
        }

    module Create'FlowData =
        let create
            (
                afterCompletion: Create'FlowDataAfterCompletion option,
                subscriptionCancel: Create'FlowDataSubscriptionCancel option,
                subscriptionUpdate: Create'FlowDataSubscriptionUpdate option,
                subscriptionUpdateConfirm: Create'FlowDataSubscriptionUpdateConfirm option,
                ``type``: Create'FlowDataType option
            ) : Create'FlowData
            =
            {
              AfterCompletion = afterCompletion
              SubscriptionCancel = subscriptionCancel
              SubscriptionUpdate = subscriptionUpdate
              SubscriptionUpdateConfirm = subscriptionUpdateConfirm
              Type = ``type``
            }

    type Create'Locale =
        | Auto
        | Bg
        | Cs
        | Da
        | De
        | El
        | En
        | [<JsonPropertyName("en-AU")>] EnAU
        | [<JsonPropertyName("en-CA")>] EnCA
        | [<JsonPropertyName("en-GB")>] EnGB
        | [<JsonPropertyName("en-IE")>] EnIE
        | [<JsonPropertyName("en-IN")>] EnIN
        | [<JsonPropertyName("en-NZ")>] EnNZ
        | [<JsonPropertyName("en-SG")>] EnSG
        | Es
        | [<JsonPropertyName("es-419")>] Es419
        | Et
        | Fi
        | Fil
        | Fr
        | [<JsonPropertyName("fr-CA")>] FrCA
        | Hr
        | Hu
        | Id
        | It
        | Ja
        | Ko
        | Lt
        | Lv
        | Ms
        | Mt
        | Nb
        | Nl
        | Pl
        | Pt
        | [<JsonPropertyName("pt-BR")>] PtBR
        | Ro
        | Ru
        | Sk
        | Sl
        | Sv
        | Th
        | Tr
        | Vi
        | Zh
        | [<JsonPropertyName("zh-HK")>] ZhHK
        | [<JsonPropertyName("zh-TW")>] ZhTW

    type CreateOptions =
        {
            /// The ID of an existing [configuration](https://docs.stripe.com/api/customer_portal/configurations) to use for this session, describing its functionality and features. If not specified, the session uses the default configuration.
            [<Config.Form>]
            Configuration: string option
            /// The ID of an existing customer.
            [<Config.Form>]
            Customer: string option
            /// The ID of an existing account.
            [<Config.Form>]
            CustomerAccount: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Information about a specific flow for the customer to go through. See the [docs](https://docs.stripe.com/customer-management/portal-deep-links) to learn more about using customer portal deep links and flows.
            [<Config.Form>]
            FlowData: Create'FlowData option
            /// The IETF language tag of the locale customer portal is displayed in. If blank or auto, the customer’s `preferred_locales` or browser’s locale is used.
            [<Config.Form>]
            Locale: Create'Locale option
            /// The `on_behalf_of` account to use for this session. When specified, only subscriptions and invoices with this `on_behalf_of` account appear in the portal. For more information, see the [docs](https://docs.stripe.com/connect/separate-charges-and-transfers#settlement-merchant). Use the [Accounts API](https://docs.stripe.com/api/accounts/object#account_object-settings-branding) to modify the `on_behalf_of` account's branding settings, which the portal displays.
            [<Config.Form>]
            OnBehalfOf: string option
            /// The default URL to redirect customers to when they click on the portal's link to return to your website.
            [<Config.Form>]
            ReturnUrl: string option
        }

    module CreateOptions =
        let create
            (
                configuration: string option,
                customer: string option,
                customerAccount: string option,
                expand: string list option,
                flowData: Create'FlowData option,
                locale: Create'Locale option,
                onBehalfOf: string option,
                returnUrl: string option
            ) : CreateOptions
            =
            {
              Configuration = configuration
              Customer = customer
              CustomerAccount = customerAccount
              Expand = expand
              FlowData = flowData
              Locale = locale
              OnBehalfOf = onBehalfOf
              ReturnUrl = returnUrl
            }

    ///<p>Creates a session of the customer portal.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/billing_portal/sessions"
        |> RestApi.postAsync<_, BillingPortalSession> settings (Map.empty) options

