namespace StripeRequest.BillingPortal

open FunStripe
open System.Text.Json.Serialization
open Stripe.BillingPortal
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
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

    type ListOptions with
        static member New(?active: bool, ?endingBefore: string, ?expand: string list, ?isDefault: bool, ?limit: int, ?startingAfter: string) =
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

    type Create'BusinessProfile with
        static member New(?headline: Choice<string,string>, ?privacyPolicyUrl: string, ?termsOfServiceUrl: string) =
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

    type Create'FeaturesCustomerUpdate with
        static member New(?allowedUpdates: Choice<Create'FeaturesCustomerUpdateAllowedUpdates list,string>, ?enabled: bool) =
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

    type Create'FeaturesInvoiceHistory with
        static member New(?enabled: bool) =
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

    type Create'FeaturesPaymentMethodUpdate with
        static member New(?enabled: bool, ?paymentMethodConfiguration: Choice<string,string>) =
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

    type Create'FeaturesSubscriptionCancelCancellationReason with
        static member New(?enabled: bool, ?options: Choice<Create'FeaturesSubscriptionCancelCancellationReasonOptions list,string>) =
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

    type Create'FeaturesSubscriptionCancel with
        static member New(?cancellationReason: Create'FeaturesSubscriptionCancelCancellationReason, ?enabled: bool, ?mode: Create'FeaturesSubscriptionCancelMode, ?prorationBehavior: Create'FeaturesSubscriptionCancelProrationBehavior) =
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

    type Create'FeaturesSubscriptionUpdateProductsAdjustableQuantity with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int) =
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

    type Create'FeaturesSubscriptionUpdateProducts with
        static member New(?adjustableQuantity: Create'FeaturesSubscriptionUpdateProductsAdjustableQuantity, ?prices: string list, ?product: string) =
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

    type Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions with
        static member New(?type': Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType) =
            {
                Type = type'
            }

    type Create'FeaturesSubscriptionUpdateScheduleAtPeriodEnd =
        {
            /// List of conditions. When any condition is true, the update will be scheduled at the end of the current period.
            [<Config.Form>]
            Conditions: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions list option
        }

    type Create'FeaturesSubscriptionUpdateScheduleAtPeriodEnd with
        static member New(?conditions: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions list) =
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

    type Create'FeaturesSubscriptionUpdate with
        static member New(?billingCycleAnchor: Create'FeaturesSubscriptionUpdateBillingCycleAnchor, ?defaultAllowedUpdates: Choice<Create'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string>, ?enabled: bool, ?products: Choice<Create'FeaturesSubscriptionUpdateProducts list,string>, ?prorationBehavior: Create'FeaturesSubscriptionUpdateProrationBehavior, ?scheduleAtPeriodEnd: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEnd, ?trialUpdateBehavior: Create'FeaturesSubscriptionUpdateTrialUpdateBehavior) =
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

    type Create'Features with
        static member New(?customerUpdate: Create'FeaturesCustomerUpdate, ?invoiceHistory: Create'FeaturesInvoiceHistory, ?paymentMethodUpdate: Create'FeaturesPaymentMethodUpdate, ?subscriptionCancel: Create'FeaturesSubscriptionCancel, ?subscriptionUpdate: Create'FeaturesSubscriptionUpdate) =
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

    type Create'LoginPage with
        static member New(?enabled: bool) =
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

    type CreateOptions with
        static member New(features: Create'Features, ?businessProfile: Create'BusinessProfile, ?defaultReturnUrl: Choice<string,string>, ?expand: string list, ?loginPage: Create'LoginPage, ?metadata: Map<string, string>, ?name: Choice<string,string>) =
            {
                Features = features
                BusinessProfile = businessProfile
                DefaultReturnUrl = defaultReturnUrl
                Expand = expand
                LoginPage = loginPage
                Metadata = metadata
                Name = name
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Configuration: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(configuration: string, ?expand: string list) =
            {
                Configuration = configuration
                Expand = expand
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

    type Update'BusinessProfile with
        static member New(?headline: Choice<string,string>, ?privacyPolicyUrl: Choice<string,string>, ?termsOfServiceUrl: Choice<string,string>) =
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

    type Update'FeaturesCustomerUpdate with
        static member New(?allowedUpdates: Choice<Update'FeaturesCustomerUpdateAllowedUpdates list,string>, ?enabled: bool) =
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

    type Update'FeaturesInvoiceHistory with
        static member New(?enabled: bool) =
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

    type Update'FeaturesPaymentMethodUpdate with
        static member New(?enabled: bool, ?paymentMethodConfiguration: Choice<string,string>) =
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

    type Update'FeaturesSubscriptionCancelCancellationReason with
        static member New(?enabled: bool, ?options: Choice<Update'FeaturesSubscriptionCancelCancellationReasonOptions list,string>) =
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

    type Update'FeaturesSubscriptionCancel with
        static member New(?cancellationReason: Update'FeaturesSubscriptionCancelCancellationReason, ?enabled: bool, ?mode: Update'FeaturesSubscriptionCancelMode, ?prorationBehavior: Update'FeaturesSubscriptionCancelProrationBehavior) =
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

    type Update'FeaturesSubscriptionUpdateProductsAdjustableQuantity with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int) =
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

    type Update'FeaturesSubscriptionUpdateProducts with
        static member New(?adjustableQuantity: Update'FeaturesSubscriptionUpdateProductsAdjustableQuantity, ?prices: string list, ?product: string) =
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

    type Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions with
        static member New(?type': Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType) =
            {
                Type = type'
            }

    type Update'FeaturesSubscriptionUpdateScheduleAtPeriodEnd =
        {
            /// List of conditions. When any condition is true, the update will be scheduled at the end of the current period.
            [<Config.Form>]
            Conditions: Choice<Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions list,string> option
        }

    type Update'FeaturesSubscriptionUpdateScheduleAtPeriodEnd with
        static member New(?conditions: Choice<Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions list,string>) =
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

    type Update'FeaturesSubscriptionUpdate with
        static member New(?billingCycleAnchor: Update'FeaturesSubscriptionUpdateBillingCycleAnchor, ?defaultAllowedUpdates: Choice<Update'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string>, ?enabled: bool, ?products: Choice<Update'FeaturesSubscriptionUpdateProducts list,string>, ?prorationBehavior: Update'FeaturesSubscriptionUpdateProrationBehavior, ?scheduleAtPeriodEnd: Update'FeaturesSubscriptionUpdateScheduleAtPeriodEnd, ?trialUpdateBehavior: Update'FeaturesSubscriptionUpdateTrialUpdateBehavior) =
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

    type Update'Features with
        static member New(?customerUpdate: Update'FeaturesCustomerUpdate, ?invoiceHistory: Update'FeaturesInvoiceHistory, ?paymentMethodUpdate: Update'FeaturesPaymentMethodUpdate, ?subscriptionCancel: Update'FeaturesSubscriptionCancel, ?subscriptionUpdate: Update'FeaturesSubscriptionUpdate) =
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

    type Update'LoginPage with
        static member New(?enabled: bool) =
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

    type UpdateOptions with
        static member New(configuration: string, ?active: bool, ?businessProfile: Update'BusinessProfile, ?defaultReturnUrl: Choice<string,string>, ?expand: string list, ?features: Update'Features, ?loginPage: Update'LoginPage, ?metadata: Map<string, string>, ?name: Choice<string,string>) =
            {
                Configuration = configuration
                Active = active
                BusinessProfile = businessProfile
                DefaultReturnUrl = defaultReturnUrl
                Expand = expand
                Features = features
                LoginPage = loginPage
                Metadata = metadata
                Name = name
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

    type Create'FlowDataAfterCompletionHostedConfirmation with
        static member New(?customMessage: string) =
            {
                CustomMessage = customMessage
            }

    type Create'FlowDataAfterCompletionRedirect =
        {
            /// The URL the customer will be redirected to after the flow is completed.
            [<Config.Form>]
            ReturnUrl: string option
        }

    type Create'FlowDataAfterCompletionRedirect with
        static member New(?returnUrl: string) =
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

    type Create'FlowDataAfterCompletion with
        static member New(?hostedConfirmation: Create'FlowDataAfterCompletionHostedConfirmation, ?redirect: Create'FlowDataAfterCompletionRedirect, ?type': Create'FlowDataAfterCompletionType) =
            {
                HostedConfirmation = hostedConfirmation
                Redirect = redirect
                Type = type'
            }

    type Create'FlowDataSubscriptionCancelRetentionCouponOffer =
        {
            /// The ID of the coupon to be offered.
            [<Config.Form>]
            Coupon: string option
        }

    type Create'FlowDataSubscriptionCancelRetentionCouponOffer with
        static member New(?coupon: string) =
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

    type Create'FlowDataSubscriptionCancelRetention with
        static member New(?couponOffer: Create'FlowDataSubscriptionCancelRetentionCouponOffer, ?type': Create'FlowDataSubscriptionCancelRetentionType) =
            {
                CouponOffer = couponOffer
                Type = type'
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

    type Create'FlowDataSubscriptionCancel with
        static member New(?retention: Create'FlowDataSubscriptionCancelRetention, ?subscription: string) =
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

    type Create'FlowDataSubscriptionUpdate with
        static member New(?subscription: string) =
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

    type Create'FlowDataSubscriptionUpdateConfirmDiscounts with
        static member New(?coupon: string, ?promotionCode: string) =
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

    type Create'FlowDataSubscriptionUpdateConfirmItems with
        static member New(?id: string, ?price: string, ?quantity: int) =
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

    type Create'FlowDataSubscriptionUpdateConfirm with
        static member New(?discounts: Create'FlowDataSubscriptionUpdateConfirmDiscounts list, ?items: Create'FlowDataSubscriptionUpdateConfirmItems list, ?subscription: string) =
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

    type Create'FlowData with
        static member New(?afterCompletion: Create'FlowDataAfterCompletion, ?subscriptionCancel: Create'FlowDataSubscriptionCancel, ?subscriptionUpdate: Create'FlowDataSubscriptionUpdate, ?subscriptionUpdateConfirm: Create'FlowDataSubscriptionUpdateConfirm, ?type': Create'FlowDataType) =
            {
                AfterCompletion = afterCompletion
                SubscriptionCancel = subscriptionCancel
                SubscriptionUpdate = subscriptionUpdate
                SubscriptionUpdateConfirm = subscriptionUpdateConfirm
                Type = type'
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

    type CreateOptions with
        static member New(?configuration: string, ?customer: string, ?customerAccount: string, ?expand: string list, ?flowData: Create'FlowData, ?locale: Create'Locale, ?onBehalfOf: string, ?returnUrl: string) =
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

