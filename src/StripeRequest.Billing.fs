namespace FunStripe.StripeRequest

open FunStripe
open FunStripe.Json
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module BillingPortalConfigurations =

    type ListOptions = {
        ///Only return configurations that are active or inactive (e.g., pass `true` to only list active configurations).
        [<Config.Query>]Active: bool option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///Only return the default or non-default configurations (e.g., pass `true` to only list the default configuration).
        [<Config.Query>]IsDefault: bool option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?active: bool, ?endingBefore: string, ?expand: string list, ?isDefault: bool, ?limit: int, ?startingAfter: string) =
            {
                Active = active
                EndingBefore = endingBefore
                Expand = expand
                IsDefault = isDefault
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of configurations that describe the functionality of the customer portal.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("is_default", options.IsDefault |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/billing_portal/configurations"
        |> RestApi.getAsync<BillingPortalConfiguration list> settings qs

    type Create'BusinessProfile = {
        ///The messaging shown to customers in the portal.
        [<Config.Form>]Headline: Choice<string,string> option
        ///A link to the business’s publicly available privacy policy.
        [<Config.Form>]PrivacyPolicyUrl: string option
        ///A link to the business’s publicly available terms of service.
        [<Config.Form>]TermsOfServiceUrl: string option
    }
    with
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

    type Create'FeaturesCustomerUpdate = {
        ///The types of customer updates that are supported. When empty, customers are not updateable.
        [<Config.Form>]AllowedUpdates: Choice<Create'FeaturesCustomerUpdateAllowedUpdates list,string> option
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?allowedUpdates: Choice<Create'FeaturesCustomerUpdateAllowedUpdates list,string>, ?enabled: bool) =
            {
                AllowedUpdates = allowedUpdates
                Enabled = enabled
            }

    type Create'FeaturesInvoiceHistory = {
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'FeaturesPaymentMethodUpdate = {
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
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

    type Create'FeaturesSubscriptionCancelCancellationReason = {
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
        ///Which cancellation reasons will be given as options to the customer.
        [<Config.Form>]Options: Choice<Create'FeaturesSubscriptionCancelCancellationReasonOptions list,string> option
    }
    with
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
    | None'

    type Create'FeaturesSubscriptionCancel = {
        ///Whether the cancellation reasons will be collected in the portal and which options are exposed to the customer
        [<Config.Form>]CancellationReason: Create'FeaturesSubscriptionCancelCancellationReason option
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
        ///Whether to cancel subscriptions immediately or at the end of the billing period.
        [<Config.Form>]Mode: Create'FeaturesSubscriptionCancelMode option
        ///Whether to create prorations when canceling subscriptions. Possible values are `none` and `create_prorations`, which is only compatible with `mode=immediately`. No prorations are generated when canceling a subscription at the end of its natural billing period.
        [<Config.Form>]ProrationBehavior: Create'FeaturesSubscriptionCancelProrationBehavior option
    }
    with
        static member New(?cancellationReason: Create'FeaturesSubscriptionCancelCancellationReason, ?enabled: bool, ?mode: Create'FeaturesSubscriptionCancelMode, ?prorationBehavior: Create'FeaturesSubscriptionCancelProrationBehavior) =
            {
                CancellationReason = cancellationReason
                Enabled = enabled
                Mode = mode
                ProrationBehavior = prorationBehavior
            }

    type Create'FeaturesSubscriptionPause = {
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'FeaturesSubscriptionUpdateDefaultAllowedUpdates =
    | Price
    | PromotionCode
    | Quantity

    type Create'FeaturesSubscriptionUpdateProducts = {
        ///The list of price IDs for the product that a subscription can be updated to.
        [<Config.Form>]Prices: string list option
        ///The product id.
        [<Config.Form>]Product: string option
    }
    with
        static member New(?prices: string list, ?product: string) =
            {
                Prices = prices
                Product = product
            }

    type Create'FeaturesSubscriptionUpdateProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type Create'FeaturesSubscriptionUpdate = {
        ///The types of subscription updates that are supported. When empty, subscriptions are not updateable.
        [<Config.Form>]DefaultAllowedUpdates: Choice<Create'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string> option
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
        ///The list of products that support subscription updates.
        [<Config.Form>]Products: Choice<Create'FeaturesSubscriptionUpdateProducts list,string> option
        ///Determines how to handle prorations resulting from subscription updates. Valid values are `none`, `create_prorations`, and `always_invoice`.
        [<Config.Form>]ProrationBehavior: Create'FeaturesSubscriptionUpdateProrationBehavior option
    }
    with
        static member New(?defaultAllowedUpdates: Choice<Create'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string>, ?enabled: bool, ?products: Choice<Create'FeaturesSubscriptionUpdateProducts list,string>, ?prorationBehavior: Create'FeaturesSubscriptionUpdateProrationBehavior) =
            {
                DefaultAllowedUpdates = defaultAllowedUpdates
                Enabled = enabled
                Products = products
                ProrationBehavior = prorationBehavior
            }

    type Create'Features = {
        ///Information about updating the customer details in the portal.
        [<Config.Form>]CustomerUpdate: Create'FeaturesCustomerUpdate option
        ///Information about showing the billing history in the portal.
        [<Config.Form>]InvoiceHistory: Create'FeaturesInvoiceHistory option
        ///Information about updating payment methods in the portal.
        [<Config.Form>]PaymentMethodUpdate: Create'FeaturesPaymentMethodUpdate option
        ///Information about canceling subscriptions in the portal.
        [<Config.Form>]SubscriptionCancel: Create'FeaturesSubscriptionCancel option
        ///Information about pausing subscriptions in the portal.
        [<Config.Form>]SubscriptionPause: Create'FeaturesSubscriptionPause option
        ///Information about updating subscriptions in the portal.
        [<Config.Form>]SubscriptionUpdate: Create'FeaturesSubscriptionUpdate option
    }
    with
        static member New(?customerUpdate: Create'FeaturesCustomerUpdate, ?invoiceHistory: Create'FeaturesInvoiceHistory, ?paymentMethodUpdate: Create'FeaturesPaymentMethodUpdate, ?subscriptionCancel: Create'FeaturesSubscriptionCancel, ?subscriptionPause: Create'FeaturesSubscriptionPause, ?subscriptionUpdate: Create'FeaturesSubscriptionUpdate) =
            {
                CustomerUpdate = customerUpdate
                InvoiceHistory = invoiceHistory
                PaymentMethodUpdate = paymentMethodUpdate
                SubscriptionCancel = subscriptionCancel
                SubscriptionPause = subscriptionPause
                SubscriptionUpdate = subscriptionUpdate
            }

    type Create'LoginPage = {
        ///Set to `true` to generate a shareable URL [`login_page.url`](https://stripe.com/docs/api/customer_portal/configuration#portal_configuration_object-login_page-url) that will take your customers to a hosted login page for the customer portal.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type CreateOptions = {
        ///The business information shown to customers in the portal.
        [<Config.Form>]BusinessProfile: Create'BusinessProfile
        ///The default URL to redirect customers to when they click on the portal's link to return to your website. This can be [overriden](https://stripe.com/docs/api/customer_portal/sessions/create#create_portal_session-return_url) when creating the session.
        [<Config.Form>]DefaultReturnUrl: Choice<string,string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Information about the features available in the portal.
        [<Config.Form>]Features: Create'Features
        ///The hosted login page for this configuration. Learn more about the portal login page in our [integration docs](https://stripe.com/docs/billing/subscriptions/integrating-customer-portal#share).
        [<Config.Form>]LoginPage: Create'LoginPage option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(businessProfile: Create'BusinessProfile, features: Create'Features, ?defaultReturnUrl: Choice<string,string>, ?expand: string list, ?loginPage: Create'LoginPage, ?metadata: Map<string, string>) =
            {
                BusinessProfile = businessProfile
                DefaultReturnUrl = defaultReturnUrl
                Expand = expand
                Features = features
                LoginPage = loginPage
                Metadata = metadata
            }

    ///<p>Creates a configuration that describes the functionality and behavior of a PortalSession</p>
    let Create settings (options: CreateOptions) =
        $"/v1/billing_portal/configurations"
        |> RestApi.postAsync<_, BillingPortalConfiguration> settings (Map.empty) options

    type RetrieveOptions = {
        [<Config.Path>]Configuration: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(configuration: string, ?expand: string list) =
            {
                Configuration = configuration
                Expand = expand
            }

    ///<p>Retrieves a configuration that describes the functionality of the customer portal.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/billing_portal/configurations/{options.Configuration}"
        |> RestApi.getAsync<BillingPortalConfiguration> settings qs

    type Update'BusinessProfile = {
        ///The messaging shown to customers in the portal.
        [<Config.Form>]Headline: Choice<string,string> option
        ///A link to the business’s publicly available privacy policy.
        [<Config.Form>]PrivacyPolicyUrl: Choice<string,string> option
        ///A link to the business’s publicly available terms of service.
        [<Config.Form>]TermsOfServiceUrl: Choice<string,string> option
    }
    with
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

    type Update'FeaturesCustomerUpdate = {
        ///The types of customer updates that are supported. When empty, customers are not updateable.
        [<Config.Form>]AllowedUpdates: Choice<Update'FeaturesCustomerUpdateAllowedUpdates list,string> option
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?allowedUpdates: Choice<Update'FeaturesCustomerUpdateAllowedUpdates list,string>, ?enabled: bool) =
            {
                AllowedUpdates = allowedUpdates
                Enabled = enabled
            }

    type Update'FeaturesInvoiceHistory = {
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Update'FeaturesPaymentMethodUpdate = {
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
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

    type Update'FeaturesSubscriptionCancelCancellationReason = {
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
        ///Which cancellation reasons will be given as options to the customer.
        [<Config.Form>]Options: Choice<Update'FeaturesSubscriptionCancelCancellationReasonOptions list,string> option
    }
    with
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
    | None'

    type Update'FeaturesSubscriptionCancel = {
        ///Whether the cancellation reasons will be collected in the portal and which options are exposed to the customer
        [<Config.Form>]CancellationReason: Update'FeaturesSubscriptionCancelCancellationReason option
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
        ///Whether to cancel subscriptions immediately or at the end of the billing period.
        [<Config.Form>]Mode: Update'FeaturesSubscriptionCancelMode option
        ///Whether to create prorations when canceling subscriptions. Possible values are `none` and `create_prorations`, which is only compatible with `mode=immediately`. No prorations are generated when canceling a subscription at the end of its natural billing period.
        [<Config.Form>]ProrationBehavior: Update'FeaturesSubscriptionCancelProrationBehavior option
    }
    with
        static member New(?cancellationReason: Update'FeaturesSubscriptionCancelCancellationReason, ?enabled: bool, ?mode: Update'FeaturesSubscriptionCancelMode, ?prorationBehavior: Update'FeaturesSubscriptionCancelProrationBehavior) =
            {
                CancellationReason = cancellationReason
                Enabled = enabled
                Mode = mode
                ProrationBehavior = prorationBehavior
            }

    type Update'FeaturesSubscriptionPause = {
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Update'FeaturesSubscriptionUpdateDefaultAllowedUpdates =
    | Price
    | PromotionCode
    | Quantity

    type Update'FeaturesSubscriptionUpdateProducts = {
        ///The list of price IDs for the product that a subscription can be updated to.
        [<Config.Form>]Prices: string list option
        ///The product id.
        [<Config.Form>]Product: string option
    }
    with
        static member New(?prices: string list, ?product: string) =
            {
                Prices = prices
                Product = product
            }

    type Update'FeaturesSubscriptionUpdateProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type Update'FeaturesSubscriptionUpdate = {
        ///The types of subscription updates that are supported. When empty, subscriptions are not updateable.
        [<Config.Form>]DefaultAllowedUpdates: Choice<Update'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string> option
        ///Whether the feature is enabled.
        [<Config.Form>]Enabled: bool option
        ///The list of products that support subscription updates.
        [<Config.Form>]Products: Choice<Update'FeaturesSubscriptionUpdateProducts list,string> option
        ///Determines how to handle prorations resulting from subscription updates. Valid values are `none`, `create_prorations`, and `always_invoice`.
        [<Config.Form>]ProrationBehavior: Update'FeaturesSubscriptionUpdateProrationBehavior option
    }
    with
        static member New(?defaultAllowedUpdates: Choice<Update'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string>, ?enabled: bool, ?products: Choice<Update'FeaturesSubscriptionUpdateProducts list,string>, ?prorationBehavior: Update'FeaturesSubscriptionUpdateProrationBehavior) =
            {
                DefaultAllowedUpdates = defaultAllowedUpdates
                Enabled = enabled
                Products = products
                ProrationBehavior = prorationBehavior
            }

    type Update'Features = {
        ///Information about updating the customer details in the portal.
        [<Config.Form>]CustomerUpdate: Update'FeaturesCustomerUpdate option
        ///Information about showing the billing history in the portal.
        [<Config.Form>]InvoiceHistory: Update'FeaturesInvoiceHistory option
        ///Information about updating payment methods in the portal.
        [<Config.Form>]PaymentMethodUpdate: Update'FeaturesPaymentMethodUpdate option
        ///Information about canceling subscriptions in the portal.
        [<Config.Form>]SubscriptionCancel: Update'FeaturesSubscriptionCancel option
        ///Information about pausing subscriptions in the portal.
        [<Config.Form>]SubscriptionPause: Update'FeaturesSubscriptionPause option
        ///Information about updating subscriptions in the portal.
        [<Config.Form>]SubscriptionUpdate: Update'FeaturesSubscriptionUpdate option
    }
    with
        static member New(?customerUpdate: Update'FeaturesCustomerUpdate, ?invoiceHistory: Update'FeaturesInvoiceHistory, ?paymentMethodUpdate: Update'FeaturesPaymentMethodUpdate, ?subscriptionCancel: Update'FeaturesSubscriptionCancel, ?subscriptionPause: Update'FeaturesSubscriptionPause, ?subscriptionUpdate: Update'FeaturesSubscriptionUpdate) =
            {
                CustomerUpdate = customerUpdate
                InvoiceHistory = invoiceHistory
                PaymentMethodUpdate = paymentMethodUpdate
                SubscriptionCancel = subscriptionCancel
                SubscriptionPause = subscriptionPause
                SubscriptionUpdate = subscriptionUpdate
            }

    type Update'LoginPage = {
        ///Set to `true` to generate a shareable URL [`login_page.url`](https://stripe.com/docs/api/customer_portal/configuration#portal_configuration_object-login_page-url) that will take your customers to a hosted login page for the customer portal.
        ///Set to `false` to deactivate the `login_page.url`.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type UpdateOptions = {
        [<Config.Path>]Configuration: string
        ///Whether the configuration is active and can be used to create portal sessions.
        [<Config.Form>]Active: bool option
        ///The business information shown to customers in the portal.
        [<Config.Form>]BusinessProfile: Update'BusinessProfile option
        ///The default URL to redirect customers to when they click on the portal's link to return to your website. This can be [overriden](https://stripe.com/docs/api/customer_portal/sessions/create#create_portal_session-return_url) when creating the session.
        [<Config.Form>]DefaultReturnUrl: Choice<string,string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Information about the features available in the portal.
        [<Config.Form>]Features: Update'Features option
        ///The hosted login page for this configuration. Learn more about the portal login page in our [integration docs](https://stripe.com/docs/billing/subscriptions/integrating-customer-portal#share).
        [<Config.Form>]LoginPage: Update'LoginPage option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(configuration: string, ?active: bool, ?businessProfile: Update'BusinessProfile, ?defaultReturnUrl: Choice<string,string>, ?expand: string list, ?features: Update'Features, ?loginPage: Update'LoginPage, ?metadata: Map<string, string>) =
            {
                Configuration = configuration
                Active = active
                BusinessProfile = businessProfile
                DefaultReturnUrl = defaultReturnUrl
                Expand = expand
                Features = features
                LoginPage = loginPage
                Metadata = metadata
            }

    ///<p>Updates a configuration that describes the functionality of the customer portal.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/billing_portal/configurations/{options.Configuration}"
        |> RestApi.postAsync<_, BillingPortalConfiguration> settings (Map.empty) options

module BillingPortalSessions =

    type Create'FlowDataAfterCompletionHostedConfirmation = {
        ///A custom message to display to the customer after the flow is completed.
        [<Config.Form>]CustomMessage: string option
    }
    with
        static member New(?customMessage: string) =
            {
                CustomMessage = customMessage
            }

    type Create'FlowDataAfterCompletionRedirect = {
        ///The URL the customer will be redirected to after the flow is completed.
        [<Config.Form>]ReturnUrl: string option
    }
    with
        static member New(?returnUrl: string) =
            {
                ReturnUrl = returnUrl
            }

    type Create'FlowDataAfterCompletionType =
    | HostedConfirmation
    | PortalHomepage
    | Redirect

    type Create'FlowDataAfterCompletion = {
        ///Configuration when `after_completion.type=hosted_confirmation`.
        [<Config.Form>]HostedConfirmation: Create'FlowDataAfterCompletionHostedConfirmation option
        ///Configuration when `after_completion.type=redirect`.
        [<Config.Form>]Redirect: Create'FlowDataAfterCompletionRedirect option
        ///The specified behavior after the flow is completed.
        [<Config.Form>]Type: Create'FlowDataAfterCompletionType option
    }
    with
        static member New(?hostedConfirmation: Create'FlowDataAfterCompletionHostedConfirmation, ?redirect: Create'FlowDataAfterCompletionRedirect, ?type': Create'FlowDataAfterCompletionType) =
            {
                HostedConfirmation = hostedConfirmation
                Redirect = redirect
                Type = type'
            }

    type Create'FlowDataSubscriptionCancelRetentionCouponOffer = {
        ///The ID of the coupon to be offered.
        [<Config.Form>]Coupon: string option
    }
    with
        static member New(?coupon: string) =
            {
                Coupon = coupon
            }

    type Create'FlowDataSubscriptionCancelRetentionType =
    | CouponOffer

    type Create'FlowDataSubscriptionCancelRetention = {
        ///Configuration when `retention.type=coupon_offer`.
        [<Config.Form>]CouponOffer: Create'FlowDataSubscriptionCancelRetentionCouponOffer option
        ///Type of retention strategy to use with the customer.
        [<Config.Form>]Type: Create'FlowDataSubscriptionCancelRetentionType option
    }
    with
        static member New(?couponOffer: Create'FlowDataSubscriptionCancelRetentionCouponOffer, ?type': Create'FlowDataSubscriptionCancelRetentionType) =
            {
                CouponOffer = couponOffer
                Type = type'
            }

    type Create'FlowDataSubscriptionCancel = {
        ///Specify a retention strategy to be used in the cancellation flow.
        [<Config.Form>]Retention: Create'FlowDataSubscriptionCancelRetention option
        ///The ID of the subscription to be canceled.
        [<Config.Form>]Subscription: string option
    }
    with
        static member New(?retention: Create'FlowDataSubscriptionCancelRetention, ?subscription: string) =
            {
                Retention = retention
                Subscription = subscription
            }

    type Create'FlowDataSubscriptionUpdate = {
        ///The ID of the subscription to be updated.
        [<Config.Form>]Subscription: string option
    }
    with
        static member New(?subscription: string) =
            {
                Subscription = subscription
            }

    type Create'FlowDataSubscriptionUpdateConfirmDiscounts = {
        ///The ID of the coupon to apply to this subscription update.
        [<Config.Form>]Coupon: string option
        ///The ID of a promotion code to apply to this subscription update.
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?promotionCode: string) =
            {
                Coupon = coupon
                PromotionCode = promotionCode
            }

    type Create'FlowDataSubscriptionUpdateConfirmItems = {
        ///The ID of the [subscription item](https://stripe.com/docs/api/subscriptions/object#subscription_object-items-data-id) to be updated.
        [<Config.Form>]Id: string option
        ///The price the customer should subscribe to through this flow. The price must also be included in the configuration's [`features.subscription_update.products`](https://stripe.com/docs/api/customer_portal/configuration#portal_configuration_object-features-subscription_update-products).
        [<Config.Form>]Price: string option
        ///[Quantity](https://stripe.com/docs/subscriptions/quantities) for this item that the customer should subscribe to through this flow.
        [<Config.Form>]Quantity: int option
    }
    with
        static member New(?id: string, ?price: string, ?quantity: int) =
            {
                Id = id
                Price = price
                Quantity = quantity
            }

    type Create'FlowDataSubscriptionUpdateConfirm = {
        ///The coupon or promotion code to apply to this subscription update. Currently, only up to one may be specified.
        [<Config.Form>]Discounts: Create'FlowDataSubscriptionUpdateConfirmDiscounts list option
        ///The [subscription item](https://stripe.com/docs/api/subscription_items) to be updated through this flow. Currently, only up to one may be specified and subscriptions with multiple items are not updatable.
        [<Config.Form>]Items: Create'FlowDataSubscriptionUpdateConfirmItems list option
        ///The ID of the subscription to be updated.
        [<Config.Form>]Subscription: string option
    }
    with
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

    type Create'FlowData = {
        ///Behavior after the flow is completed.
        [<Config.Form>]AfterCompletion: Create'FlowDataAfterCompletion option
        ///Configuration when `flow_data.type=subscription_cancel`.
        [<Config.Form>]SubscriptionCancel: Create'FlowDataSubscriptionCancel option
        ///Configuration when `flow_data.type=subscription_update`.
        [<Config.Form>]SubscriptionUpdate: Create'FlowDataSubscriptionUpdate option
        ///Configuration when `flow_data.type=subscription_update_confirm`.
        [<Config.Form>]SubscriptionUpdateConfirm: Create'FlowDataSubscriptionUpdateConfirm option
        ///Type of flow that the customer will go through.
        [<Config.Form>]Type: Create'FlowDataType option
    }
    with
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
    | [<JsonUnionCase("en-AU")>] EnAU
    | [<JsonUnionCase("en-CA")>] EnCA
    | [<JsonUnionCase("en-GB")>] EnGB
    | [<JsonUnionCase("en-IE")>] EnIE
    | [<JsonUnionCase("en-IN")>] EnIN
    | [<JsonUnionCase("en-NZ")>] EnNZ
    | [<JsonUnionCase("en-SG")>] EnSG
    | Es
    | [<JsonUnionCase("es-419")>] Es419
    | Et
    | Fi
    | Fil
    | Fr
    | [<JsonUnionCase("fr-CA")>] FrCA
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
    | [<JsonUnionCase("pt-BR")>] PtBR
    | Ro
    | Ru
    | Sk
    | Sl
    | Sv
    | Th
    | Tr
    | Vi
    | Zh
    | [<JsonUnionCase("zh-HK")>] ZhHK
    | [<JsonUnionCase("zh-TW")>] ZhTW

    type CreateOptions = {
        ///The ID of an existing [configuration](https://stripe.com/docs/api/customer_portal/configuration) to use for this session, describing its functionality and features. If not specified, the session uses the default configuration.
        [<Config.Form>]Configuration: string option
        ///The ID of an existing customer.
        [<Config.Form>]Customer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Information about a specific flow for the customer to go through. See the [docs](https://stripe.com/docs/customer-management/portal-deep-links) to learn more about using customer portal deep links and flows.
        [<Config.Form>]FlowData: Create'FlowData option
        ///The IETF language tag of the locale customer portal is displayed in. If blank or auto, the customer’s `preferred_locales` or browser’s locale is used.
        [<Config.Form>]Locale: Create'Locale option
        ///The `on_behalf_of` account to use for this session. When specified, only subscriptions and invoices with this `on_behalf_of` account appear in the portal. For more information, see the [docs](https://stripe.com/docs/connect/separate-charges-and-transfers#on-behalf-of). Use the [Accounts API](https://stripe.com/docs/api/accounts/object#account_object-settings-branding) to modify the `on_behalf_of` account's branding settings, which the portal displays.
        [<Config.Form>]OnBehalfOf: string option
        ///The default URL to redirect customers to when they click on the portal's link to return to your website.
        [<Config.Form>]ReturnUrl: string option
    }
    with
        static member New(customer: string, ?configuration: string, ?expand: string list, ?flowData: Create'FlowData, ?locale: Create'Locale, ?onBehalfOf: string, ?returnUrl: string) =
            {
                Configuration = configuration
                Customer = customer
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

module Coupons =

    type ListOptions = {
        ///A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of your coupons.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/coupons"
        |> RestApi.getAsync<Coupon list> settings qs

    type Create'AppliesTo = {
        ///An array of Product IDs that this Coupon will apply to.
        [<Config.Form>]Products: string list option
    }
    with
        static member New(?products: string list) =
            {
                Products = products
            }

    type Create'Duration =
    | Forever
    | Once
    | Repeating

    type CreateOptions = {
        ///A positive integer representing the amount to subtract from an invoice total (required if `percent_off` is not passed).
        [<Config.Form>]AmountOff: int option
        ///A hash containing directions for what this Coupon will apply discounts to.
        [<Config.Form>]AppliesTo: Create'AppliesTo option
        ///Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) of the `amount_off` parameter (required if `amount_off` is passed).
        [<Config.Form>]Currency: string option
        ///Coupons defined in each available currency option (only supported if `amount_off` is passed). Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]CurrencyOptions: Map<string, string> option
        ///Specifies how long the discount will be in effect if used on a subscription. Defaults to `once`.
        [<Config.Form>]Duration: Create'Duration option
        ///Required only if `duration` is `repeating`, in which case it must be a positive integer that specifies the number of months the discount will be in effect.
        [<Config.Form>]DurationInMonths: int option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Unique string of your choice that will be used to identify this coupon when applying it to a customer. If you don't want to specify a particular code, you can leave the ID blank and we'll generate a random code for you.
        [<Config.Form>]Id: string option
        ///A positive integer specifying the number of times the coupon can be redeemed before it's no longer valid. For example, you might have a 50% off coupon that the first 20 readers of your blog can use.
        [<Config.Form>]MaxRedemptions: int option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Name of the coupon displayed to customers on, for instance invoices, or receipts. By default the `id` is shown if `name` is not set.
        [<Config.Form>]Name: string option
        ///A positive float larger than 0, and smaller or equal to 100, that represents the discount the coupon will apply (required if `amount_off` is not passed).
        [<Config.Form>]PercentOff: decimal option
        ///Unix timestamp specifying the last time at which the coupon can be redeemed. After the redeem_by date, the coupon can no longer be applied to new customers.
        [<Config.Form>]RedeemBy: DateTime option
    }
    with
        static member New(?amountOff: int, ?appliesTo: Create'AppliesTo, ?currency: string, ?currencyOptions: Map<string, string>, ?duration: Create'Duration, ?durationInMonths: int, ?expand: string list, ?id: string, ?maxRedemptions: int, ?metadata: Map<string, string>, ?name: string, ?percentOff: decimal, ?redeemBy: DateTime) =
            {
                AmountOff = amountOff
                AppliesTo = appliesTo
                Currency = currency
                CurrencyOptions = currencyOptions
                Duration = duration
                DurationInMonths = durationInMonths
                Expand = expand
                Id = id
                MaxRedemptions = maxRedemptions
                Metadata = metadata
                Name = name
                PercentOff = percentOff
                RedeemBy = redeemBy
            }

    ///<p>You can create coupons easily via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. Coupon creation is also accessible via the API if you need to create coupons on the fly.
    ///A coupon has either a <code>percent_off</code> or an <code>amount_off</code> and <code>currency</code>. If you set an <code>amount_off</code>, that amount will be subtracted from any invoice’s subtotal. For example, an invoice with a subtotal of <currency>100</currency> will have a final total of <currency>0</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it and an invoice with a subtotal of <currency>300</currency> will have a final total of <currency>100</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/coupons"
        |> RestApi.postAsync<_, Coupon> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Coupon: string
    }
    with
        static member New(coupon: string) =
            {
                Coupon = coupon
            }

    ///<p>You can delete coupons via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. However, deleting a coupon does not affect any customers who have already applied the coupon; it means that new customers can’t redeem the coupon. You can also delete coupons via the API.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/coupons/{options.Coupon}"
        |> RestApi.deleteAsync<DeletedCoupon> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Coupon: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(coupon: string, ?expand: string list) =
            {
                Coupon = coupon
                Expand = expand
            }

    ///<p>Retrieves the coupon with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/coupons/{options.Coupon}"
        |> RestApi.getAsync<Coupon> settings qs

    type UpdateOptions = {
        [<Config.Path>]Coupon: string
        ///Coupons defined in each available currency option (only supported if the coupon is amount-based). Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]CurrencyOptions: Map<string, string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Name of the coupon displayed to customers on, for instance invoices, or receipts. By default the `id` is shown if `name` is not set.
        [<Config.Form>]Name: string option
    }
    with
        static member New(coupon: string, ?currencyOptions: Map<string, string>, ?expand: string list, ?metadata: Map<string, string>, ?name: string) =
            {
                Coupon = coupon
                CurrencyOptions = currencyOptions
                Expand = expand
                Metadata = metadata
                Name = name
            }

    ///<p>Updates the metadata of a coupon. Other coupon details (currency, duration, amount_off) are, by design, not editable.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/coupons/{options.Coupon}"
        |> RestApi.postAsync<_, Coupon> settings (Map.empty) options

module CreditNotes =

    type ListOptions = {
        ///Only return credit notes for the customer specified by this customer ID.
        [<Config.Query>]Customer: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///Only return credit notes for the invoice specified by this invoice ID.
        [<Config.Query>]Invoice: string option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?customer: string, ?endingBefore: string, ?expand: string list, ?invoice: string, ?limit: int, ?startingAfter: string) =
            {
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Invoice = invoice
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of credit notes.</p>
    let List settings (options: ListOptions) =
        let qs = [("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/credit_notes"
        |> RestApi.getAsync<CreditNote list> settings qs

    type Create'LinesType =
    | CustomLineItem
    | InvoiceLineItem

    type Create'Lines = {
        ///The line item amount to credit. Only valid when `type` is `invoice_line_item`.
        [<Config.Form>]Amount: int option
        ///The description of the credit note line item. Only valid when the `type` is `custom_line_item`.
        [<Config.Form>]Description: string option
        ///The invoice line item to credit. Only valid when the `type` is `invoice_line_item`.
        [<Config.Form>]InvoiceLineItem: string option
        ///The line item quantity to credit.
        [<Config.Form>]Quantity: int option
        ///The tax rates which apply to the credit note line item. Only valid when the `type` is `custom_line_item`.
        [<Config.Form>]TaxRates: Choice<string list,string> option
        ///Type of the credit note line item, one of `invoice_line_item` or `custom_line_item`
        [<Config.Form>]Type: Create'LinesType option
        ///The integer unit amount in cents (or local equivalent) of the credit note line item. This `unit_amount` will be multiplied by the quantity to get the full amount to credit for this line item. Only valid when `type` is `custom_line_item`.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?amount: int, ?description: string, ?invoiceLineItem: string, ?quantity: int, ?taxRates: Choice<string list,string>, ?type': Create'LinesType, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Amount = amount
                Description = description
                InvoiceLineItem = invoiceLineItem
                Quantity = quantity
                TaxRates = taxRates
                Type = type'
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'ShippingCost = {
        ///The ID of the shipping rate to use for this order.
        [<Config.Form>]ShippingRate: string option
    }
    with
        static member New(?shippingRate: string) =
            {
                ShippingRate = shippingRate
            }

    type Create'Reason =
    | Duplicate
    | Fraudulent
    | OrderChange
    | ProductUnsatisfactory

    type CreateOptions = {
        ///The integer amount in cents (or local equivalent) representing the total amount of the credit note.
        [<Config.Form>]Amount: int option
        ///The integer amount in cents (or local equivalent) representing the amount to credit the customer's balance, which will be automatically applied to their next invoice.
        [<Config.Form>]CreditAmount: int option
        ///The date when this credit note is in effect. Same as `created` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the credit note PDF.
        [<Config.Form>]EffectiveAt: DateTime option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///ID of the invoice.
        [<Config.Form>]Invoice: string
        ///Line items that make up the credit note.
        [<Config.Form>]Lines: Create'Lines list option
        ///The credit note's memo appears on the credit note PDF.
        [<Config.Form>]Memo: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The integer amount in cents (or local equivalent) representing the amount that is credited outside of Stripe.
        [<Config.Form>]OutOfBandAmount: int option
        ///Reason for issuing this credit note, one of `duplicate`, `fraudulent`, `order_change`, or `product_unsatisfactory`
        [<Config.Form>]Reason: Create'Reason option
        ///ID of an existing refund to link this credit note to.
        [<Config.Form>]Refund: string option
        ///The integer amount in cents (or local equivalent) representing the amount to refund. If set, a refund will be created for the charge associated with the invoice.
        [<Config.Form>]RefundAmount: int option
        ///When shipping_cost contains the shipping_rate from the invoice, the shipping_cost is included in the credit note.
        [<Config.Form>]ShippingCost: Create'ShippingCost option
    }
    with
        static member New(invoice: string, ?amount: int, ?creditAmount: int, ?effectiveAt: DateTime, ?expand: string list, ?lines: Create'Lines list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: Create'Reason, ?refund: string, ?refundAmount: int, ?shippingCost: Create'ShippingCost) =
            {
                Amount = amount
                CreditAmount = creditAmount
                EffectiveAt = effectiveAt
                Expand = expand
                Invoice = invoice
                Lines = lines
                Memo = memo
                Metadata = metadata
                OutOfBandAmount = outOfBandAmount
                Reason = reason
                Refund = refund
                RefundAmount = refundAmount
                ShippingCost = shippingCost
            }

    ///<p>Issue a credit note to adjust the amount of a finalized invoice. For a <code>status=open</code> invoice, a credit note reduces
    ///its <code>amount_due</code>. For a <code>status=paid</code> invoice, a credit note does not affect its <code>amount_due</code>. Instead, it can result
    ///in any combination of the following:
    ///<ul>
    ///<li>Refund: create a new refund (using <code>refund_amount</code>) or link an existing refund (using <code>refund</code>).</li>
    ///<li>Customer balance credit: credit the customer’s balance (using <code>credit_amount</code>) which will be automatically applied to their next invoice when it’s finalized.</li>
    ///<li>Outside of Stripe credit: record the amount that is or will be credited outside of Stripe (using <code>out_of_band_amount</code>).</li>
    ///</ul>
    ///For post-payment credit notes the sum of the refund, credit and outside of Stripe amounts must equal the credit note total.
    ///You may issue multiple credit notes for an invoice. Each credit note will increment the invoice’s <code>pre_payment_credit_notes_amount</code>
    ///or <code>post_payment_credit_notes_amount</code> depending on its <code>status</code> at the time of credit note creation.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/credit_notes"
        |> RestApi.postAsync<_, CreditNote> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<p>Retrieves the credit note object with the given identifier.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/credit_notes/{options.Id}"
        |> RestApi.getAsync<CreditNote> settings qs

    type UpdateOptions = {
        [<Config.Path>]Id: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Credit note memo.
        [<Config.Form>]Memo: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(id: string, ?expand: string list, ?memo: string, ?metadata: Map<string, string>) =
            {
                Id = id
                Expand = expand
                Memo = memo
                Metadata = metadata
            }

    ///<p>Updates an existing credit note.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/credit_notes/{options.Id}"
        |> RestApi.postAsync<_, CreditNote> settings (Map.empty) options

module CreditNotesPreview =

    type PreviewOptions = {
        ///The integer amount in cents (or local equivalent) representing the total amount of the credit note.
        [<Config.Query>]Amount: int option
        ///The integer amount in cents (or local equivalent) representing the amount to credit the customer's balance, which will be automatically applied to their next invoice.
        [<Config.Query>]CreditAmount: int option
        ///The date when this credit note is in effect. Same as `created` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the credit note PDF.
        [<Config.Query>]EffectiveAt: int option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///ID of the invoice.
        [<Config.Query>]Invoice: string
        ///Line items that make up the credit note.
        [<Config.Query>]Lines: string list option
        ///The credit note's memo appears on the credit note PDF.
        [<Config.Query>]Memo: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Query>]Metadata: Map<string, string> option
        ///The integer amount in cents (or local equivalent) representing the amount that is credited outside of Stripe.
        [<Config.Query>]OutOfBandAmount: int option
        ///Reason for issuing this credit note, one of `duplicate`, `fraudulent`, `order_change`, or `product_unsatisfactory`
        [<Config.Query>]Reason: string option
        ///ID of an existing refund to link this credit note to.
        [<Config.Query>]Refund: string option
        ///The integer amount in cents (or local equivalent) representing the amount to refund. If set, a refund will be created for the charge associated with the invoice.
        [<Config.Query>]RefundAmount: int option
        ///When shipping_cost contains the shipping_rate from the invoice, the shipping_cost is included in the credit note.
        [<Config.Query>]ShippingCost: Map<string, string> option
    }
    with
        static member New(invoice: string, ?amount: int, ?creditAmount: int, ?effectiveAt: int, ?expand: string list, ?lines: string list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: string, ?refund: string, ?refundAmount: int, ?shippingCost: Map<string, string>) =
            {
                Amount = amount
                CreditAmount = creditAmount
                EffectiveAt = effectiveAt
                Expand = expand
                Invoice = invoice
                Lines = lines
                Memo = memo
                Metadata = metadata
                OutOfBandAmount = outOfBandAmount
                Reason = reason
                Refund = refund
                RefundAmount = refundAmount
                ShippingCost = shippingCost
            }

    ///<p>Get a preview of a credit note without creating it.</p>
    let Preview settings (options: PreviewOptions) =
        let qs = [("amount", options.Amount |> box); ("credit_amount", options.CreditAmount |> box); ("effective_at", options.EffectiveAt |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("lines", options.Lines |> box); ("memo", options.Memo |> box); ("metadata", options.Metadata |> box); ("out_of_band_amount", options.OutOfBandAmount |> box); ("reason", options.Reason |> box); ("refund", options.Refund |> box); ("refund_amount", options.RefundAmount |> box); ("shipping_cost", options.ShippingCost |> box)] |> Map.ofList
        $"/v1/credit_notes/preview"
        |> RestApi.getAsync<CreditNote> settings qs

module CreditNotesPreviewLines =

    type PreviewLinesOptions = {
        ///The integer amount in cents (or local equivalent) representing the total amount of the credit note.
        [<Config.Query>]Amount: int option
        ///The integer amount in cents (or local equivalent) representing the amount to credit the customer's balance, which will be automatically applied to their next invoice.
        [<Config.Query>]CreditAmount: int option
        ///The date when this credit note is in effect. Same as `created` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the credit note PDF.
        [<Config.Query>]EffectiveAt: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///ID of the invoice.
        [<Config.Query>]Invoice: string
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Line items that make up the credit note.
        [<Config.Query>]Lines: string list option
        ///The credit note's memo appears on the credit note PDF.
        [<Config.Query>]Memo: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Query>]Metadata: Map<string, string> option
        ///The integer amount in cents (or local equivalent) representing the amount that is credited outside of Stripe.
        [<Config.Query>]OutOfBandAmount: int option
        ///Reason for issuing this credit note, one of `duplicate`, `fraudulent`, `order_change`, or `product_unsatisfactory`
        [<Config.Query>]Reason: string option
        ///ID of an existing refund to link this credit note to.
        [<Config.Query>]Refund: string option
        ///The integer amount in cents (or local equivalent) representing the amount to refund. If set, a refund will be created for the charge associated with the invoice.
        [<Config.Query>]RefundAmount: int option
        ///When shipping_cost contains the shipping_rate from the invoice, the shipping_cost is included in the credit note.
        [<Config.Query>]ShippingCost: Map<string, string> option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(invoice: string, ?amount: int, ?creditAmount: int, ?effectiveAt: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?lines: string list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: string, ?refund: string, ?refundAmount: int, ?shippingCost: Map<string, string>, ?startingAfter: string) =
            {
                Amount = amount
                CreditAmount = creditAmount
                EffectiveAt = effectiveAt
                EndingBefore = endingBefore
                Expand = expand
                Invoice = invoice
                Limit = limit
                Lines = lines
                Memo = memo
                Metadata = metadata
                OutOfBandAmount = outOfBandAmount
                Reason = reason
                Refund = refund
                RefundAmount = refundAmount
                ShippingCost = shippingCost
                StartingAfter = startingAfter
            }

    ///<p>When retrieving a credit note preview, you’ll get a <strong>lines</strong> property containing the first handful of those items. This URL you can retrieve the full (paginated) list of line items.</p>
    let PreviewLines settings (options: PreviewLinesOptions) =
        let qs = [("amount", options.Amount |> box); ("credit_amount", options.CreditAmount |> box); ("effective_at", options.EffectiveAt |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("lines", options.Lines |> box); ("memo", options.Memo |> box); ("metadata", options.Metadata |> box); ("out_of_band_amount", options.OutOfBandAmount |> box); ("reason", options.Reason |> box); ("refund", options.Refund |> box); ("refund_amount", options.RefundAmount |> box); ("shipping_cost", options.ShippingCost |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/credit_notes/preview/lines"
        |> RestApi.getAsync<CreditNoteLineItem list> settings qs

module CreditNotesLines =

    type ListOptions = {
        [<Config.Path>]CreditNote: string
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(creditNote: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                CreditNote = creditNote
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>When retrieving a credit note, you’ll get a <strong>lines</strong> property containing the the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/credit_notes/{options.CreditNote}/lines"
        |> RestApi.getAsync<CreditNoteLineItem list> settings qs

module CreditNotesVoid =

    type VoidCreditNoteOptions = {
        [<Config.Path>]Id: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<p>Marks a credit note as void. Learn more about <a href="/docs/billing/invoices/credit-notes#voiding">voiding credit notes</a>.</p>
    let VoidCreditNote settings (options: VoidCreditNoteOptions) =
        $"/v1/credit_notes/{options.Id}/void"
        |> RestApi.postAsync<_, CreditNote> settings (Map.empty) options

module Invoiceitems =

    type ListOptions = {
        [<Config.Query>]Created: int option
        ///The identifier of the customer whose invoice items to return. If none is provided, all invoice items will be returned.
        [<Config.Query>]Customer: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///Only return invoice items belonging to this invoice. If none is provided, all invoice items will be returned. If specifying an invoice, no customer identifier is needed.
        [<Config.Query>]Invoice: string option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Set to `true` to only show pending invoice items, which are not yet attached to any invoices. Set to `false` to only show invoice items already attached to invoices. If unspecified, no filter is applied.
        [<Config.Query>]Pending: bool option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?invoice: string, ?limit: int, ?pending: bool, ?startingAfter: string) =
            {
                Created = created
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Invoice = invoice
                Limit = limit
                Pending = pending
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of your invoice items. Invoice items are returned sorted by creation date, with the most recently created invoice items appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("pending", options.Pending |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/invoiceitems"
        |> RestApi.getAsync<Invoiceitem list> settings qs

    type Create'Discounts = {
        ///ID of the coupon to create a new discount for.
        [<Config.Form>]Coupon: string option
        ///ID of an existing discount on the object (or one of its ancestors) to reuse.
        [<Config.Form>]Discount: string option
    }
    with
        static member New(?coupon: string, ?discount: string) =
            {
                Coupon = coupon
                Discount = discount
            }

    type Create'Period = {
        ///The end of the period, which must be greater than or equal to the start. This value is inclusive.
        [<Config.Form>]End: DateTime option
        ///The start of the period. This value is inclusive.
        [<Config.Form>]Start: DateTime option
    }
    with
        static member New(?end': DateTime, ?start: DateTime) =
            {
                End = end'
                Start = start
            }

    type Create'PriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'PriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Create'PriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?taxBehavior: Create'PriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'TaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type CreateOptions = {
        ///The integer amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. Passing in a negative `amount` will reduce the `amount_due` on the invoice.
        [<Config.Form>]Amount: int option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the customer who will be billed when this invoice item is billed.
        [<Config.Form>]Customer: string
        ///An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.
        [<Config.Form>]Description: string option
        ///Controls whether discounts apply to this invoice item. Defaults to false for prorations or negative invoice items, and true for all other invoice items.
        [<Config.Form>]Discountable: bool option
        ///The coupons to redeem into discounts for the invoice item or invoice line item.
        [<Config.Form>]Discounts: Choice<Create'Discounts list,string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The ID of an existing invoice to add this invoice item to. When left blank, the invoice item will be added to the next upcoming scheduled invoice. This is useful when adding invoice items in response to an invoice.created webhook. You can only add invoice items to draft invoices and there is a maximum of 250 items per invoice.
        [<Config.Form>]Invoice: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://stripe.com/docs/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://stripe.com/docs/revenue-recognition/methodology/subscriptions-and-invoicing) for details.
        [<Config.Form>]Period: Create'Period option
        ///The ID of the price object.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        [<Config.Form>]PriceData: Create'PriceData option
        ///Non-negative integer. The quantity of units for the invoice item.
        [<Config.Form>]Quantity: int option
        ///The ID of a subscription to add this invoice item to. When left blank, the invoice item will be be added to the next upcoming scheduled invoice. When set, scheduled invoices for subscriptions other than the specified subscription will ignore the invoice item. Use this when you want to express that an invoice item has been accrued within the context of a particular subscription.
        [<Config.Form>]Subscription: string option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Create'TaxBehavior option
        ///A [tax code](https://stripe.com/docs/tax/tax-categories) ID.
        [<Config.Form>]TaxCode: Choice<string,string> option
        ///The tax rates which apply to the invoice item. When set, the `default_tax_rates` on the invoice do not apply to this invoice item.
        [<Config.Form>]TaxRates: string list option
        ///The integer unit amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. This `unit_amount` will be multiplied by the quantity to get the full amount. Passing in a negative `unit_amount` will reduce the `amount_due` on the invoice.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(customer: string, ?amount: int, ?taxRates: string list, ?taxCode: Choice<string,string>, ?taxBehavior: Create'TaxBehavior, ?subscription: string, ?quantity: int, ?priceData: Create'PriceData, ?price: string, ?period: Create'Period, ?metadata: Map<string, string>, ?invoice: string, ?expand: string list, ?discounts: Choice<Create'Discounts list,string>, ?discountable: bool, ?description: string, ?currency: string, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Amount = amount
                Currency = currency
                Customer = customer
                Description = description
                Discountable = discountable
                Discounts = discounts
                Expand = expand
                Invoice = invoice
                Metadata = metadata
                Period = period
                Price = price
                PriceData = priceData
                Quantity = quantity
                Subscription = subscription
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                TaxRates = taxRates
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    ///<p>Creates an item to be added to a draft invoice (up to 250 items per invoice). If no invoice is specified, the item will be on the next invoice created for the customer specified.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/invoiceitems"
        |> RestApi.postAsync<_, Invoiceitem> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Invoiceitem: string
    }
    with
        static member New(invoiceitem: string) =
            {
                Invoiceitem = invoiceitem
            }

    ///<p>Deletes an invoice item, removing it from an invoice. Deleting invoice items is only possible when they’re not attached to invoices, or if it’s attached to a draft invoice.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/invoiceitems/{options.Invoiceitem}"
        |> RestApi.deleteAsync<DeletedInvoiceitem> settings (Map.empty)

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Invoiceitem: string
    }
    with
        static member New(invoiceitem: string, ?expand: string list) =
            {
                Expand = expand
                Invoiceitem = invoiceitem
            }

    ///<p>Retrieves the invoice item with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/invoiceitems/{options.Invoiceitem}"
        |> RestApi.getAsync<Invoiceitem> settings qs

    type Update'Discounts = {
        ///ID of the coupon to create a new discount for.
        [<Config.Form>]Coupon: string option
        ///ID of an existing discount on the object (or one of its ancestors) to reuse.
        [<Config.Form>]Discount: string option
    }
    with
        static member New(?coupon: string, ?discount: string) =
            {
                Coupon = coupon
                Discount = discount
            }

    type Update'Period = {
        ///The end of the period, which must be greater than or equal to the start. This value is inclusive.
        [<Config.Form>]End: DateTime option
        ///The start of the period. This value is inclusive.
        [<Config.Form>]Start: DateTime option
    }
    with
        static member New(?end': DateTime, ?start: DateTime) =
            {
                End = end'
                Start = start
            }

    type Update'PriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'PriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Update'PriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?taxBehavior: Update'PriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'TaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type UpdateOptions = {
        [<Config.Path>]Invoiceitem: string
        ///The integer amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. If you want to apply a credit to the customer's account, pass a negative amount.
        [<Config.Form>]Amount: int option
        ///An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.
        [<Config.Form>]Description: string option
        ///Controls whether discounts apply to this invoice item. Defaults to false for prorations or negative invoice items, and true for all other invoice items. Cannot be set to true for prorations.
        [<Config.Form>]Discountable: bool option
        ///The coupons & existing discounts which apply to the invoice item or invoice line item. Item discounts are applied before invoice discounts. Pass an empty string to remove previously-defined discounts.
        [<Config.Form>]Discounts: Choice<Update'Discounts list,string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://stripe.com/docs/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://stripe.com/docs/revenue-recognition/methodology/subscriptions-and-invoicing) for details.
        [<Config.Form>]Period: Update'Period option
        ///The ID of the price object.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        [<Config.Form>]PriceData: Update'PriceData option
        ///Non-negative integer. The quantity of units for the invoice item.
        [<Config.Form>]Quantity: int option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Update'TaxBehavior option
        ///A [tax code](https://stripe.com/docs/tax/tax-categories) ID.
        [<Config.Form>]TaxCode: Choice<string,string> option
        ///The tax rates which apply to the invoice item. When set, the `default_tax_rates` on the invoice do not apply to this invoice item. Pass an empty string to remove previously-defined tax rates.
        [<Config.Form>]TaxRates: Choice<string list,string> option
        ///The integer unit amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. This unit_amount will be multiplied by the quantity to get the full amount. If you want to apply a credit to the customer's account, pass a negative unit_amount.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(invoiceitem: string, ?amount: int, ?description: string, ?discountable: bool, ?discounts: Choice<Update'Discounts list,string>, ?expand: string list, ?metadata: Map<string, string>, ?period: Update'Period, ?price: string, ?priceData: Update'PriceData, ?quantity: int, ?taxBehavior: Update'TaxBehavior, ?taxCode: Choice<string,string>, ?taxRates: Choice<string list,string>, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Invoiceitem = invoiceitem
                Amount = amount
                Description = description
                Discountable = discountable
                Discounts = discounts
                Expand = expand
                Metadata = metadata
                Period = period
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                TaxRates = taxRates
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    ///<p>Updates the amount or description of an invoice item on an upcoming invoice. Updating an invoice item is only possible before the invoice it’s attached to is closed.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/invoiceitems/{options.Invoiceitem}"
        |> RestApi.postAsync<_, Invoiceitem> settings (Map.empty) options

module Invoices =

    type ListOptions = {
        ///The collection method of the invoice to retrieve. Either `charge_automatically` or `send_invoice`.
        [<Config.Query>]CollectionMethod: string option
        [<Config.Query>]Created: int option
        ///Only return invoices for the customer specified by this customer ID.
        [<Config.Query>]Customer: string option
        [<Config.Query>]DueDate: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///The status of the invoice, one of `draft`, `open`, `paid`, `uncollectible`, or `void`. [Learn more](https://stripe.com/docs/billing/invoices/workflow#workflow-overview)
        [<Config.Query>]Status: string option
        ///Only return invoices for the subscription specified by this subscription ID.
        [<Config.Query>]Subscription: string option
    }
    with
        static member New(?collectionMethod: string, ?created: int, ?customer: string, ?dueDate: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string, ?subscription: string) =
            {
                CollectionMethod = collectionMethod
                Created = created
                Customer = customer
                DueDate = dueDate
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
                Subscription = subscription
            }

    ///<p>You can list all invoices, or list the invoices for a specific customer. The invoices are returned sorted by creation date, with the most recently created invoices appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("collection_method", options.CollectionMethod |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("due_date", options.DueDate |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("subscription", options.Subscription |> box)] |> Map.ofList
        $"/v1/invoices"
        |> RestApi.getAsync<Invoice list> settings qs

    type Create'AutomaticTax = {
        ///Whether Stripe automatically computes tax on this invoice. Note that incompatible invoice items (invoice items with manually specified [tax rates](https://stripe.com/docs/api/tax_rates), negative amounts, or `tax_behavior=unspecified`) cannot be added to automatic tax invoices.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'CustomFields = {
        ///The name of the custom field. This may be up to 30 characters.
        [<Config.Form>]Name: string option
        ///The value of the custom field. This may be up to 30 characters.
        [<Config.Form>]Value: string option
    }
    with
        static member New(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Create'Discounts = {
        ///ID of the coupon to create a new discount for.
        [<Config.Form>]Coupon: string option
        ///ID of an existing discount on the object (or one of its ancestors) to reuse.
        [<Config.Form>]Discount: string option
    }
    with
        static member New(?coupon: string, ?discount: string) =
            {
                Coupon = coupon
                Discount = discount
            }

    type Create'FromInvoiceAction =
    | Revision

    type Create'FromInvoice = {
        ///The relation between the new invoice and the original invoice. Currently, only 'revision' is permitted
        [<Config.Form>]Action: Create'FromInvoiceAction option
        ///The `id` of the invoice that will be cloned.
        [<Config.Form>]Invoice: string option
    }
    with
        static member New(?action: Create'FromInvoiceAction, ?invoice: string) =
            {
                Action = action
                Invoice = invoice
            }

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType =
    | Business
    | Personal

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions = {
        ///Transaction type of the mandate.
        [<Config.Form>]TransactionType: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
    }
    with
        static member New(?transactionType: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType) =
            {
                TransactionType = transactionType
            }

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions = {
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions, ?verificationMethod: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod) =
            {
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Fr
    | Nl

    type Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions = {
        ///Preferred language of the Bancontact authorization page that the customer is redirected to.
        [<Config.Form>]PreferredLanguage: Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
    }
    with
        static member New(?preferredLanguage: Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval =
    | Month

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType =
    | FixedCount

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan = {
        ///For `fixed_count` installment plans, this is the number of installment payments your customer will make to their credit card.
        [<Config.Form>]Count: int option
        ///For `fixed_count` installment plans, this is the interval between installment payments your customer will make to their credit card.
        ///One of `month`.
        [<Config.Form>]Interval: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval option
        ///Type of installment plan, one of `fixed_count`.
        [<Config.Form>]Type: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType option
    }
    with
        static member New(?count: int, ?interval: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval, ?type': Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType) =
            {
                Count = count
                Interval = interval
                Type = type'
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments = {
        ///Setting to true enables installments for this invoice.
        ///Setting to false will prevent any selected plan from applying to a payment.
        [<Config.Form>]Enabled: bool option
        ///The selected installment plan to use for this invoice.
        [<Config.Form>]Plan: Choice<Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan,string> option
    }
    with
        static member New(?enabled: bool, ?plan: Choice<Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan,string>) =
            {
                Enabled = enabled
                Plan = plan
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure =
    | Any
    | Automatic

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions = {
        ///Installment configuration for payments attempted on this invoice (Mexico Only).
        ///For more information, see the [installments integration guide](https://stripe.com/docs/payments/installments).
        [<Config.Form>]Installments: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments option
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        [<Config.Form>]RequestThreeDSecure: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure option
    }
    with
        static member New(?installments: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments, ?requestThreeDSecure: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure) =
            {
                Installments = installments
                RequestThreeDSecure = requestThreeDSecure
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer = {
        ///The desired country code of the bank account information. Permitted values include: `BE`, `DE`, `ES`, `FR`, `IE`, or `NL`.
        [<Config.Form>]Country: string option
    }
    with
        static member New(?country: string) =
            {
                Country = country
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer = {
        ///Configuration for eu_bank_transfer funding type.
        [<Config.Form>]EuBankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option
        ///The bank transfer type that can be used for funding. Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.
        [<Config.Form>]Type: string option
    }
    with
        static member New(?euBankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer, ?type': string) =
            {
                EuBankTransfer = euBankTransfer
                Type = type'
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions = {
        ///Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.
        [<Config.Form>]BankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option
        ///The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
        [<Config.Form>]FundingType: string option
    }
    with
        static member New(?bankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer, ?fundingType: string) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch =
    | Balances

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections = {
        ///The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
        [<Config.Form>]Permissions: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option
        ///List of data features that you would like to retrieve upon account creation.
        [<Config.Form>]Prefetch: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
    }
    with
        static member New(?permissions: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list, ?prefetch: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list) =
            {
                Permissions = permissions
                Prefetch = prefetch
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions = {
        ///Additional fields for Financial Connections Session creation
        [<Config.Form>]FinancialConnections: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?financialConnections: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections, ?verificationMethod: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod) =
            {
                FinancialConnections = financialConnections
                VerificationMethod = verificationMethod
            }

    type Create'PaymentSettingsPaymentMethodOptions = {
        ///If paying by `acss_debit`, this sub-hash contains details about the Canadian pre-authorized debit payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]AcssDebit: Choice<Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option
        ///If paying by `bancontact`, this sub-hash contains details about the Bancontact payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]Bancontact: Choice<Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option
        ///If paying by `card`, this sub-hash contains details about the Card payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]Card: Choice<Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions,string> option
        ///If paying by `customer_balance`, this sub-hash contains details about the Bank transfer payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]CustomerBalance: Choice<Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option
        ///If paying by `konbini`, this sub-hash contains details about the Konbini payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]Konbini: Choice<string,string> option
        ///If paying by `us_bank_account`, this sub-hash contains details about the ACH direct debit payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]UsBankAccount: Choice<Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
    }
    with
        static member New(?acssDebit: Choice<Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string>, ?bancontact: Choice<Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string>, ?card: Choice<Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions,string>, ?customerBalance: Choice<Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string>, ?konbini: Choice<string,string>, ?usBankAccount: Choice<Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string>) =
            {
                AcssDebit = acssDebit
                Bancontact = bancontact
                Card = card
                CustomerBalance = customerBalance
                Konbini = konbini
                UsBankAccount = usBankAccount
            }

    type Create'PaymentSettingsPaymentMethodTypes =
    | AchCreditTransfer
    | AchDebit
    | AcssDebit
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Boleto
    | Card
    | Cashapp
    | CustomerBalance
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Konbini
    | Link
    | Paynow
    | Paypal
    | Promptpay
    | SepaCreditTransfer
    | SepaDebit
    | Sofort
    | UsBankAccount
    | WechatPay

    type Create'PaymentSettings = {
        ///ID of the mandate to be used for this invoice. It must correspond to the payment method used to pay the invoice, including the invoice's default_payment_method or default_source, if set.
        [<Config.Form>]DefaultMandate: Choice<string,string> option
        ///Payment-method-specific configuration to provide to the invoice’s PaymentIntent.
        [<Config.Form>]PaymentMethodOptions: Create'PaymentSettingsPaymentMethodOptions option
        ///The list of payment method types (e.g. card) to provide to the invoice’s PaymentIntent. If not set, Stripe attempts to automatically determine the types to use by looking at the invoice’s default payment method, the subscription’s default payment method, the customer’s default payment method, and your [invoice template settings](https://dashboard.stripe.com/settings/billing/invoice).
        [<Config.Form>]PaymentMethodTypes: Choice<Create'PaymentSettingsPaymentMethodTypes list,string> option
    }
    with
        static member New(?defaultMandate: Choice<string,string>, ?paymentMethodOptions: Create'PaymentSettingsPaymentMethodOptions, ?paymentMethodTypes: Choice<Create'PaymentSettingsPaymentMethodTypes list,string>) =
            {
                DefaultMandate = defaultMandate
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
            }

    type Create'RenderingOptionsRenderingOptionsAmountTaxDisplay =
    | ExcludeTax
    | IncludeInclusiveTax

    type Create'RenderingOptionsRenderingOptions = {
        ///How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.
        [<Config.Form>]AmountTaxDisplay: Create'RenderingOptionsRenderingOptionsAmountTaxDisplay option
    }
    with
        static member New(?amountTaxDisplay: Create'RenderingOptionsRenderingOptionsAmountTaxDisplay) =
            {
                AmountTaxDisplay = amountTaxDisplay
            }

    type Create'ShippingCostShippingRateDataDeliveryEstimateMaximumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Create'ShippingCostShippingRateDataDeliveryEstimateMaximum = {
        ///A unit of time.
        [<Config.Form>]Unit: Create'ShippingCostShippingRateDataDeliveryEstimateMaximumUnit option
        ///Must be greater than 0.
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Create'ShippingCostShippingRateDataDeliveryEstimateMaximumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'ShippingCostShippingRateDataDeliveryEstimateMinimumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Create'ShippingCostShippingRateDataDeliveryEstimateMinimum = {
        ///A unit of time.
        [<Config.Form>]Unit: Create'ShippingCostShippingRateDataDeliveryEstimateMinimumUnit option
        ///Must be greater than 0.
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Create'ShippingCostShippingRateDataDeliveryEstimateMinimumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'ShippingCostShippingRateDataDeliveryEstimate = {
        ///The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.
        [<Config.Form>]Maximum: Create'ShippingCostShippingRateDataDeliveryEstimateMaximum option
        ///The lower bound of the estimated range. If empty, represents no lower bound.
        [<Config.Form>]Minimum: Create'ShippingCostShippingRateDataDeliveryEstimateMinimum option
    }
    with
        static member New(?maximum: Create'ShippingCostShippingRateDataDeliveryEstimateMaximum, ?minimum: Create'ShippingCostShippingRateDataDeliveryEstimateMinimum) =
            {
                Maximum = maximum
                Minimum = minimum
            }

    type Create'ShippingCostShippingRateDataFixedAmount = {
        ///A non-negative integer in cents representing how much to charge.
        [<Config.Form>]Amount: int option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]CurrencyOptions: Map<string, string> option
    }
    with
        static member New(?amount: int, ?currency: string, ?currencyOptions: Map<string, string>) =
            {
                Amount = amount
                Currency = currency
                CurrencyOptions = currencyOptions
            }

    type Create'ShippingCostShippingRateDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'ShippingCostShippingRateDataType =
    | FixedAmount

    type Create'ShippingCostShippingRateData = {
        ///The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.
        [<Config.Form>]DeliveryEstimate: Create'ShippingCostShippingRateDataDeliveryEstimate option
        ///The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.
        [<Config.Form>]DisplayName: string option
        ///Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.
        [<Config.Form>]FixedAmount: Create'ShippingCostShippingRateDataFixedAmount option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.
        [<Config.Form>]TaxBehavior: Create'ShippingCostShippingRateDataTaxBehavior option
        ///A [tax code](https://stripe.com/docs/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.
        [<Config.Form>]TaxCode: string option
        ///The type of calculation to use on the shipping rate. Can only be `fixed_amount` for now.
        [<Config.Form>]Type: Create'ShippingCostShippingRateDataType option
    }
    with
        static member New(?deliveryEstimate: Create'ShippingCostShippingRateDataDeliveryEstimate, ?displayName: string, ?fixedAmount: Create'ShippingCostShippingRateDataFixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Create'ShippingCostShippingRateDataTaxBehavior, ?taxCode: string, ?type': Create'ShippingCostShippingRateDataType) =
            {
                DeliveryEstimate = deliveryEstimate
                DisplayName = displayName
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                Type = type'
            }

    type Create'ShippingCost = {
        ///The ID of the shipping rate to use for this order.
        [<Config.Form>]ShippingRate: string option
        ///Parameters to create a new ad-hoc shipping rate for this order.
        [<Config.Form>]ShippingRateData: Create'ShippingCostShippingRateData option
    }
    with
        static member New(?shippingRate: string, ?shippingRateData: Create'ShippingCostShippingRateData) =
            {
                ShippingRate = shippingRate
                ShippingRateData = shippingRateData
            }

    type Create'ShippingDetailsAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'ShippingDetails = {
        ///Shipping address
        [<Config.Form>]Address: Create'ShippingDetailsAddress option
        ///Recipient name.
        [<Config.Form>]Name: string option
        ///Recipient phone (including extension)
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Create'ShippingDetailsAddress, ?name: string, ?phone: Choice<string,string>) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Create'TransferData = {
        ///The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred.
        [<Config.Form>]Amount: int option
        ///ID of an existing, connected Stripe account.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type Create'CollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Create'PendingInvoiceItemsBehavior =
    | Exclude
    | Include
    | IncludeAndRequire

    type CreateOptions = {
        ///The account tax IDs associated with the invoice. Only editable when the invoice is a draft.
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///A fee in cents (or local equivalent) that will be applied to the invoice and transferred to the application owner's Stripe account. The request must be made with an OAuth key or the Stripe-Account header in order to take an application fee. For more information, see the application fees [documentation](https://stripe.com/docs/billing/invoices/connect#collecting-fees).
        [<Config.Form>]ApplicationFeeAmount: int option
        ///Controls whether Stripe performs [automatic collection](https://stripe.com/docs/invoicing/integration/automatic-advancement-collection) of the invoice. If `false`, the invoice's state doesn't automatically advance without an explicit action.
        [<Config.Form>]AutoAdvance: bool option
        ///Settings for automatic tax lookup for this invoice.
        [<Config.Form>]AutomaticTax: Create'AutomaticTax option
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this invoice using the default source attached to the customer. When sending an invoice, Stripe will email this invoice to the customer with payment instructions. Defaults to `charge_automatically`.
        [<Config.Form>]CollectionMethod: Create'CollectionMethod option
        ///The currency to create this invoice in. Defaults to that of `customer` if not specified.
        [<Config.Form>]Currency: string option
        ///A list of up to 4 custom fields to be displayed on the invoice.
        [<Config.Form>]CustomFields: Choice<Create'CustomFields list,string> option
        ///The ID of the customer who will be billed.
        [<Config.Form>]Customer: string option
        ///The number of days from when the invoice is created until it is due. Valid only for invoices where `collection_method=send_invoice`.
        [<Config.Form>]DaysUntilDue: int option
        ///ID of the default payment method for the invoice. It must belong to the customer associated with the invoice. If not set, defaults to the subscription's default payment method, if any, or to the default payment method in the customer's invoice settings.
        [<Config.Form>]DefaultPaymentMethod: string option
        ///ID of the default payment source for the invoice. It must belong to the customer associated with the invoice and be in a chargeable state. If not set, defaults to the subscription's default source, if any, or to the customer's default source.
        [<Config.Form>]DefaultSource: string option
        ///The tax rates that will apply to any line item that does not have `tax_rates` set.
        [<Config.Form>]DefaultTaxRates: string list option
        ///An arbitrary string attached to the object. Often useful for displaying to users. Referenced as 'memo' in the Dashboard.
        [<Config.Form>]Description: string option
        ///The coupons to redeem into discounts for the invoice. If not specified, inherits the discount from the invoice's customer. Pass an empty string to avoid inheriting any discounts.
        [<Config.Form>]Discounts: Choice<Create'Discounts list,string> option
        ///The date on which payment for this invoice is due. Valid only for invoices where `collection_method=send_invoice`.
        [<Config.Form>]DueDate: DateTime option
        ///The date when this invoice is in effect. Same as `finalized_at` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the invoice PDF and receipt.
        [<Config.Form>]EffectiveAt: DateTime option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Footer to be displayed on the invoice.
        [<Config.Form>]Footer: string option
        ///Revise an existing invoice. The new invoice will be created in `status=draft`. See the [revision documentation](https://stripe.com/docs/invoicing/invoice-revisions) for more details.
        [<Config.Form>]FromInvoice: Create'FromInvoice option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The account (if any) for which the funds of the invoice payment are intended. If set, the invoice will be presented with the branding and support information of the specified account. See the [Invoices with Connect](https://stripe.com/docs/billing/invoices/connect) documentation for details.
        [<Config.Form>]OnBehalfOf: string option
        ///Configuration settings for the PaymentIntent that is generated when the invoice is finalized.
        [<Config.Form>]PaymentSettings: Create'PaymentSettings option
        ///How to handle pending invoice items on invoice creation. One of `include` or `exclude`. `include` will include any pending invoice items, and will create an empty draft invoice if no pending invoice items exist. `exclude` will always create an empty invoice draft regardless if there are pending invoice items or not. Defaults to `exclude` if the parameter is omitted.
        [<Config.Form>]PendingInvoiceItemsBehavior: Create'PendingInvoiceItemsBehavior option
        ///Options for invoice PDF rendering.
        [<Config.Form>]RenderingOptions: Choice<Create'RenderingOptionsRenderingOptions,string> option
        ///Settings for the cost of shipping for this invoice.
        [<Config.Form>]ShippingCost: Create'ShippingCost option
        ///Shipping details for the invoice. The Invoice PDF will use the `shipping_details` value if it is set, otherwise the PDF will render the shipping address from the customer.
        [<Config.Form>]ShippingDetails: Create'ShippingDetails option
        ///Extra information about a charge for the customer's credit card statement. It must contain at least one letter. If not specified and this invoice is part of a subscription, the default `statement_descriptor` will be set to the first subscription item's product's `statement_descriptor`.
        [<Config.Form>]StatementDescriptor: string option
        ///The ID of the subscription to invoice, if any. If set, the created invoice will only include pending invoice items for that subscription. The subscription's billing cycle and regular subscription events won't be affected.
        [<Config.Form>]Subscription: string option
        ///If specified, the funds from the invoice will be transferred to the destination and the ID of the resulting transfer will be found on the invoice's charge.
        [<Config.Form>]TransferData: Create'TransferData option
    }
    with
        static member New(?accountTaxIds: Choice<string list,string>, ?statementDescriptor: string, ?shippingDetails: Create'ShippingDetails, ?shippingCost: Create'ShippingCost, ?renderingOptions: Choice<Create'RenderingOptionsRenderingOptions,string>, ?pendingInvoiceItemsBehavior: Create'PendingInvoiceItemsBehavior, ?paymentSettings: Create'PaymentSettings, ?onBehalfOf: string, ?metadata: Map<string, string>, ?fromInvoice: Create'FromInvoice, ?footer: string, ?expand: string list, ?effectiveAt: DateTime, ?subscription: string, ?dueDate: DateTime, ?description: string, ?defaultTaxRates: string list, ?defaultSource: string, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?customer: string, ?customFields: Choice<Create'CustomFields list,string>, ?currency: string, ?collectionMethod: Create'CollectionMethod, ?automaticTax: Create'AutomaticTax, ?autoAdvance: bool, ?applicationFeeAmount: int, ?discounts: Choice<Create'Discounts list,string>, ?transferData: Create'TransferData) =
            {
                AccountTaxIds = accountTaxIds
                ApplicationFeeAmount = applicationFeeAmount
                AutoAdvance = autoAdvance
                AutomaticTax = automaticTax
                CollectionMethod = collectionMethod
                Currency = currency
                CustomFields = customFields
                Customer = customer
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                DueDate = dueDate
                EffectiveAt = effectiveAt
                Expand = expand
                Footer = footer
                FromInvoice = fromInvoice
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                PaymentSettings = paymentSettings
                PendingInvoiceItemsBehavior = pendingInvoiceItemsBehavior
                RenderingOptions = renderingOptions
                ShippingCost = shippingCost
                ShippingDetails = shippingDetails
                StatementDescriptor = statementDescriptor
                Subscription = subscription
                TransferData = transferData
            }

    ///<p>This endpoint creates a draft invoice for a given customer. The invoice remains a draft until you <a href="#finalize_invoice">finalize</a> the invoice, which allows you to <a href="#pay_invoice">pay</a> or <a href="#send_invoice">send</a> the invoice to your customers.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/invoices"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Invoice: string
    }
    with
        static member New(invoice: string) =
            {
                Invoice = invoice
            }

    ///<p>Permanently deletes a one-off invoice draft. This cannot be undone. Attempts to delete invoices that are no longer in a draft state will fail; once an invoice has been finalized or if an invoice is for a subscription, it must be <a href="#void_invoice">voided</a>.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/invoices/{options.Invoice}"
        |> RestApi.deleteAsync<DeletedInvoice> settings (Map.empty)

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Invoice: string
    }
    with
        static member New(invoice: string, ?expand: string list) =
            {
                Expand = expand
                Invoice = invoice
            }

    ///<p>Retrieves the invoice with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/invoices/{options.Invoice}"
        |> RestApi.getAsync<Invoice> settings qs

    type Update'AutomaticTax = {
        ///Whether Stripe automatically computes tax on this invoice. Note that incompatible invoice items (invoice items with manually specified [tax rates](https://stripe.com/docs/api/tax_rates), negative amounts, or `tax_behavior=unspecified`) cannot be added to automatic tax invoices.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Update'CustomFields = {
        ///The name of the custom field. This may be up to 30 characters.
        [<Config.Form>]Name: string option
        ///The value of the custom field. This may be up to 30 characters.
        [<Config.Form>]Value: string option
    }
    with
        static member New(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Update'Discounts = {
        ///ID of the coupon to create a new discount for.
        [<Config.Form>]Coupon: string option
        ///ID of an existing discount on the object (or one of its ancestors) to reuse.
        [<Config.Form>]Discount: string option
    }
    with
        static member New(?coupon: string, ?discount: string) =
            {
                Coupon = coupon
                Discount = discount
            }

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType =
    | Business
    | Personal

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions = {
        ///Transaction type of the mandate.
        [<Config.Form>]TransactionType: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
    }
    with
        static member New(?transactionType: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType) =
            {
                TransactionType = transactionType
            }

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions = {
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions, ?verificationMethod: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod) =
            {
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Fr
    | Nl

    type Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions = {
        ///Preferred language of the Bancontact authorization page that the customer is redirected to.
        [<Config.Form>]PreferredLanguage: Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
    }
    with
        static member New(?preferredLanguage: Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval =
    | Month

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType =
    | FixedCount

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan = {
        ///For `fixed_count` installment plans, this is the number of installment payments your customer will make to their credit card.
        [<Config.Form>]Count: int option
        ///For `fixed_count` installment plans, this is the interval between installment payments your customer will make to their credit card.
        ///One of `month`.
        [<Config.Form>]Interval: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval option
        ///Type of installment plan, one of `fixed_count`.
        [<Config.Form>]Type: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType option
    }
    with
        static member New(?count: int, ?interval: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval, ?type': Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType) =
            {
                Count = count
                Interval = interval
                Type = type'
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments = {
        ///Setting to true enables installments for this invoice.
        ///Setting to false will prevent any selected plan from applying to a payment.
        [<Config.Form>]Enabled: bool option
        ///The selected installment plan to use for this invoice.
        [<Config.Form>]Plan: Choice<Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan,string> option
    }
    with
        static member New(?enabled: bool, ?plan: Choice<Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan,string>) =
            {
                Enabled = enabled
                Plan = plan
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure =
    | Any
    | Automatic

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions = {
        ///Installment configuration for payments attempted on this invoice (Mexico Only).
        ///For more information, see the [installments integration guide](https://stripe.com/docs/payments/installments).
        [<Config.Form>]Installments: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments option
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        [<Config.Form>]RequestThreeDSecure: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure option
    }
    with
        static member New(?installments: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments, ?requestThreeDSecure: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure) =
            {
                Installments = installments
                RequestThreeDSecure = requestThreeDSecure
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer = {
        ///The desired country code of the bank account information. Permitted values include: `BE`, `DE`, `ES`, `FR`, `IE`, or `NL`.
        [<Config.Form>]Country: string option
    }
    with
        static member New(?country: string) =
            {
                Country = country
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer = {
        ///Configuration for eu_bank_transfer funding type.
        [<Config.Form>]EuBankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option
        ///The bank transfer type that can be used for funding. Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.
        [<Config.Form>]Type: string option
    }
    with
        static member New(?euBankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer, ?type': string) =
            {
                EuBankTransfer = euBankTransfer
                Type = type'
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions = {
        ///Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.
        [<Config.Form>]BankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option
        ///The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
        [<Config.Form>]FundingType: string option
    }
    with
        static member New(?bankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer, ?fundingType: string) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch =
    | Balances

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections = {
        ///The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
        [<Config.Form>]Permissions: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option
        ///List of data features that you would like to retrieve upon account creation.
        [<Config.Form>]Prefetch: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
    }
    with
        static member New(?permissions: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list, ?prefetch: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list) =
            {
                Permissions = permissions
                Prefetch = prefetch
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions = {
        ///Additional fields for Financial Connections Session creation
        [<Config.Form>]FinancialConnections: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?financialConnections: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections, ?verificationMethod: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod) =
            {
                FinancialConnections = financialConnections
                VerificationMethod = verificationMethod
            }

    type Update'PaymentSettingsPaymentMethodOptions = {
        ///If paying by `acss_debit`, this sub-hash contains details about the Canadian pre-authorized debit payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]AcssDebit: Choice<Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option
        ///If paying by `bancontact`, this sub-hash contains details about the Bancontact payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]Bancontact: Choice<Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option
        ///If paying by `card`, this sub-hash contains details about the Card payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]Card: Choice<Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions,string> option
        ///If paying by `customer_balance`, this sub-hash contains details about the Bank transfer payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]CustomerBalance: Choice<Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option
        ///If paying by `konbini`, this sub-hash contains details about the Konbini payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]Konbini: Choice<string,string> option
        ///If paying by `us_bank_account`, this sub-hash contains details about the ACH direct debit payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]UsBankAccount: Choice<Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
    }
    with
        static member New(?acssDebit: Choice<Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string>, ?bancontact: Choice<Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string>, ?card: Choice<Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions,string>, ?customerBalance: Choice<Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string>, ?konbini: Choice<string,string>, ?usBankAccount: Choice<Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string>) =
            {
                AcssDebit = acssDebit
                Bancontact = bancontact
                Card = card
                CustomerBalance = customerBalance
                Konbini = konbini
                UsBankAccount = usBankAccount
            }

    type Update'PaymentSettingsPaymentMethodTypes =
    | AchCreditTransfer
    | AchDebit
    | AcssDebit
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Boleto
    | Card
    | Cashapp
    | CustomerBalance
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Konbini
    | Link
    | Paynow
    | Paypal
    | Promptpay
    | SepaCreditTransfer
    | SepaDebit
    | Sofort
    | UsBankAccount
    | WechatPay

    type Update'PaymentSettings = {
        ///ID of the mandate to be used for this invoice. It must correspond to the payment method used to pay the invoice, including the invoice's default_payment_method or default_source, if set.
        [<Config.Form>]DefaultMandate: Choice<string,string> option
        ///Payment-method-specific configuration to provide to the invoice’s PaymentIntent.
        [<Config.Form>]PaymentMethodOptions: Update'PaymentSettingsPaymentMethodOptions option
        ///The list of payment method types (e.g. card) to provide to the invoice’s PaymentIntent. If not set, Stripe attempts to automatically determine the types to use by looking at the invoice’s default payment method, the subscription’s default payment method, the customer’s default payment method, and your [invoice template settings](https://dashboard.stripe.com/settings/billing/invoice).
        [<Config.Form>]PaymentMethodTypes: Choice<Update'PaymentSettingsPaymentMethodTypes list,string> option
    }
    with
        static member New(?defaultMandate: Choice<string,string>, ?paymentMethodOptions: Update'PaymentSettingsPaymentMethodOptions, ?paymentMethodTypes: Choice<Update'PaymentSettingsPaymentMethodTypes list,string>) =
            {
                DefaultMandate = defaultMandate
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
            }

    type Update'RenderingOptionsRenderingOptionsAmountTaxDisplay =
    | ExcludeTax
    | IncludeInclusiveTax

    type Update'RenderingOptionsRenderingOptions = {
        ///How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.
        [<Config.Form>]AmountTaxDisplay: Update'RenderingOptionsRenderingOptionsAmountTaxDisplay option
    }
    with
        static member New(?amountTaxDisplay: Update'RenderingOptionsRenderingOptionsAmountTaxDisplay) =
            {
                AmountTaxDisplay = amountTaxDisplay
            }

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximum = {
        ///A unit of time.
        [<Config.Form>]Unit: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximumUnit option
        ///Must be greater than 0.
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimum = {
        ///A unit of time.
        [<Config.Form>]Unit: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimumUnit option
        ///Must be greater than 0.
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimate = {
        ///The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.
        [<Config.Form>]Maximum: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximum option
        ///The lower bound of the estimated range. If empty, represents no lower bound.
        [<Config.Form>]Minimum: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimum option
    }
    with
        static member New(?maximum: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximum, ?minimum: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimum) =
            {
                Maximum = maximum
                Minimum = minimum
            }

    type Update'ShippingCostShippingCostShippingRateDataFixedAmount = {
        ///A non-negative integer in cents representing how much to charge.
        [<Config.Form>]Amount: int option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]CurrencyOptions: Map<string, string> option
    }
    with
        static member New(?amount: int, ?currency: string, ?currencyOptions: Map<string, string>) =
            {
                Amount = amount
                Currency = currency
                CurrencyOptions = currencyOptions
            }

    type Update'ShippingCostShippingCostShippingRateDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'ShippingCostShippingCostShippingRateDataType =
    | FixedAmount

    type Update'ShippingCostShippingCostShippingRateData = {
        ///The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.
        [<Config.Form>]DeliveryEstimate: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimate option
        ///The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.
        [<Config.Form>]DisplayName: string option
        ///Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.
        [<Config.Form>]FixedAmount: Update'ShippingCostShippingCostShippingRateDataFixedAmount option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.
        [<Config.Form>]TaxBehavior: Update'ShippingCostShippingCostShippingRateDataTaxBehavior option
        ///A [tax code](https://stripe.com/docs/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.
        [<Config.Form>]TaxCode: string option
        ///The type of calculation to use on the shipping rate. Can only be `fixed_amount` for now.
        [<Config.Form>]Type: Update'ShippingCostShippingCostShippingRateDataType option
    }
    with
        static member New(?deliveryEstimate: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimate, ?displayName: string, ?fixedAmount: Update'ShippingCostShippingCostShippingRateDataFixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Update'ShippingCostShippingCostShippingRateDataTaxBehavior, ?taxCode: string, ?type': Update'ShippingCostShippingCostShippingRateDataType) =
            {
                DeliveryEstimate = deliveryEstimate
                DisplayName = displayName
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                Type = type'
            }

    type Update'ShippingCostShippingCost = {
        ///The ID of the shipping rate to use for this order.
        [<Config.Form>]ShippingRate: string option
        ///Parameters to create a new ad-hoc shipping rate for this order.
        [<Config.Form>]ShippingRateData: Update'ShippingCostShippingCostShippingRateData option
    }
    with
        static member New(?shippingRate: string, ?shippingRateData: Update'ShippingCostShippingCostShippingRateData) =
            {
                ShippingRate = shippingRate
                ShippingRateData = shippingRateData
            }

    type Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddressAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddress = {
        ///Shipping address
        [<Config.Form>]Address: Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddressAddress option
        ///Recipient name.
        [<Config.Form>]Name: string option
        ///Recipient phone (including extension)
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddressAddress, ?name: string, ?phone: Choice<string,string>) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Update'TransferDataTransferDataSpecs = {
        ///The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred.
        [<Config.Form>]Amount: int option
        ///ID of an existing, connected Stripe account.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type Update'CollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type UpdateOptions = {
        [<Config.Path>]Invoice: string
        ///The account tax IDs associated with the invoice. Only editable when the invoice is a draft.
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///A fee in cents (or local equivalent) that will be applied to the invoice and transferred to the application owner's Stripe account. The request must be made with an OAuth key or the Stripe-Account header in order to take an application fee. For more information, see the application fees [documentation](https://stripe.com/docs/billing/invoices/connect#collecting-fees).
        [<Config.Form>]ApplicationFeeAmount: int option
        ///Controls whether Stripe performs [automatic collection](https://stripe.com/docs/invoicing/integration/automatic-advancement-collection) of the invoice.
        [<Config.Form>]AutoAdvance: bool option
        ///Settings for automatic tax lookup for this invoice.
        [<Config.Form>]AutomaticTax: Update'AutomaticTax option
        ///Either `charge_automatically` or `send_invoice`. This field can be updated only on `draft` invoices.
        [<Config.Form>]CollectionMethod: Update'CollectionMethod option
        ///A list of up to 4 custom fields to be displayed on the invoice. If a value for `custom_fields` is specified, the list specified will replace the existing custom field list on this invoice. Pass an empty string to remove previously-defined fields.
        [<Config.Form>]CustomFields: Choice<Update'CustomFields list,string> option
        ///The number of days from which the invoice is created until it is due. Only valid for invoices where `collection_method=send_invoice`. This field can only be updated on `draft` invoices.
        [<Config.Form>]DaysUntilDue: int option
        ///ID of the default payment method for the invoice. It must belong to the customer associated with the invoice. If not set, defaults to the subscription's default payment method, if any, or to the default payment method in the customer's invoice settings.
        [<Config.Form>]DefaultPaymentMethod: string option
        ///ID of the default payment source for the invoice. It must belong to the customer associated with the invoice and be in a chargeable state. If not set, defaults to the subscription's default source, if any, or to the customer's default source.
        [<Config.Form>]DefaultSource: Choice<string,string> option
        ///The tax rates that will apply to any line item that does not have `tax_rates` set. Pass an empty string to remove previously-defined tax rates.
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///An arbitrary string attached to the object. Often useful for displaying to users. Referenced as 'memo' in the Dashboard.
        [<Config.Form>]Description: string option
        ///The discounts that will apply to the invoice. Pass an empty string to remove previously-defined discounts.
        [<Config.Form>]Discounts: Choice<Update'Discounts list,string> option
        ///The date on which payment for this invoice is due. Only valid for invoices where `collection_method=send_invoice`. This field can only be updated on `draft` invoices.
        [<Config.Form>]DueDate: DateTime option
        ///The date when this invoice is in effect. Same as `finalized_at` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the invoice PDF and receipt.
        [<Config.Form>]EffectiveAt: Choice<DateTime,string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Footer to be displayed on the invoice.
        [<Config.Form>]Footer: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The account (if any) for which the funds of the invoice payment are intended. If set, the invoice will be presented with the branding and support information of the specified account. See the [Invoices with Connect](https://stripe.com/docs/billing/invoices/connect) documentation for details.
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///Configuration settings for the PaymentIntent that is generated when the invoice is finalized.
        [<Config.Form>]PaymentSettings: Update'PaymentSettings option
        ///Options for invoice PDF rendering.
        [<Config.Form>]RenderingOptions: Choice<Update'RenderingOptionsRenderingOptions,string> option
        ///Settings for the cost of shipping for this invoice.
        [<Config.Form>]ShippingCost: Choice<Update'ShippingCostShippingCost,string> option
        ///Shipping details for the invoice. The Invoice PDF will use the `shipping_details` value if it is set, otherwise the PDF will render the shipping address from the customer.
        [<Config.Form>]ShippingDetails: Choice<Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddress,string> option
        ///Extra information about a charge for the customer's credit card statement. It must contain at least one letter. If not specified and this invoice is part of a subscription, the default `statement_descriptor` will be set to the first subscription item's product's `statement_descriptor`.
        [<Config.Form>]StatementDescriptor: string option
        ///If specified, the funds from the invoice will be transferred to the destination and the ID of the resulting transfer will be found on the invoice's charge. This will be unset if you POST an empty value.
        [<Config.Form>]TransferData: Choice<Update'TransferDataTransferDataSpecs,string> option
    }
    with
        static member New(invoice: string, ?shippingDetails: Choice<Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddress,string>, ?shippingCost: Choice<Update'ShippingCostShippingCost,string>, ?renderingOptions: Choice<Update'RenderingOptionsRenderingOptions,string>, ?paymentSettings: Update'PaymentSettings, ?onBehalfOf: Choice<string,string>, ?metadata: Map<string, string>, ?footer: string, ?expand: string list, ?effectiveAt: Choice<DateTime,string>, ?dueDate: DateTime, ?statementDescriptor: string, ?discounts: Choice<Update'Discounts list,string>, ?defaultTaxRates: Choice<string list,string>, ?defaultSource: Choice<string,string>, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?customFields: Choice<Update'CustomFields list,string>, ?collectionMethod: Update'CollectionMethod, ?automaticTax: Update'AutomaticTax, ?autoAdvance: bool, ?applicationFeeAmount: int, ?accountTaxIds: Choice<string list,string>, ?description: string, ?transferData: Choice<Update'TransferDataTransferDataSpecs,string>) =
            {
                Invoice = invoice
                AccountTaxIds = accountTaxIds
                ApplicationFeeAmount = applicationFeeAmount
                AutoAdvance = autoAdvance
                AutomaticTax = automaticTax
                CollectionMethod = collectionMethod
                CustomFields = customFields
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                DueDate = dueDate
                EffectiveAt = effectiveAt
                Expand = expand
                Footer = footer
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                PaymentSettings = paymentSettings
                RenderingOptions = renderingOptions
                ShippingCost = shippingCost
                ShippingDetails = shippingDetails
                StatementDescriptor = statementDescriptor
                TransferData = transferData
            }

    ///<p>Draft invoices are fully editable. Once an invoice is <a href="/docs/billing/invoices/workflow#finalized">finalized</a>,
    ///monetary values, as well as <code>collection_method</code>, become uneditable.
    ///If you would like to stop the Stripe Billing engine from automatically finalizing, reattempting payments on,
    ///sending reminders for, or <a href="/docs/billing/invoices/reconciliation">automatically reconciling</a> invoices, pass
    ///<code>auto_advance=false</code>.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/invoices/{options.Invoice}"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesSearch =

    type SearchOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.
        [<Config.Query>]Page: string option
        ///The search query string. See [search query language](https://stripe.com/docs/search#search-query-language) and the list of supported [query fields for invoices](https://stripe.com/docs/search#query-fields-for-invoices).
        [<Config.Query>]Query: string
    }
    with
        static member New(query: string, ?expand: string list, ?limit: int, ?page: string) =
            {
                Expand = expand
                Limit = limit
                Page = page
                Query = query
            }

    ///<p>Search for invoices you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/invoices/search"
        |> RestApi.getAsync<Invoice list> settings qs

module InvoicesUpcoming =

    type UpcomingOptions = {
        ///Settings for automatic tax lookup for this invoice preview.
        [<Config.Query>]AutomaticTax: Map<string, string> option
        ///The code of the coupon to apply. If `subscription` or `subscription_items` is provided, the invoice returned will preview updating or creating a subscription with that coupon. Otherwise, it will preview applying that coupon to the customer for the next upcoming invoice from among the customer's subscriptions. The invoice can be previewed without a coupon by passing this value as an empty string.
        [<Config.Query>]Coupon: string option
        ///The currency to preview this invoice in. Defaults to that of `customer` if not specified.
        [<Config.Query>]Currency: string option
        ///The identifier of the customer whose upcoming invoice you'd like to retrieve. If `automatic_tax` is enabled then one of `customer`, `customer_details`, `subscription`, or `schedule` must be set.
        [<Config.Query>]Customer: string option
        ///Details about the customer you want to invoice or overrides for an existing customer. If `automatic_tax` is enabled then one of `customer`, `customer_details`, `subscription`, or `schedule` must be set.
        [<Config.Query>]CustomerDetails: Map<string, string> option
        ///The coupons to redeem into discounts for the invoice preview. If not specified, inherits the discount from the customer or subscription. This only works for coupons directly applied to the invoice. To apply a coupon to a subscription, you must use the `coupon` parameter instead. Pass an empty string to avoid inheriting any discounts. To preview the upcoming invoice for a subscription that hasn't been created, use `coupon` instead.
        [<Config.Query>]Discounts: string list option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///List of invoice items to add or update in the upcoming invoice preview.
        [<Config.Query>]InvoiceItems: string list option
        ///The identifier of the schedule whose upcoming invoice you'd like to retrieve. Cannot be used with subscription or subscription fields.
        [<Config.Query>]Schedule: string option
        ///The identifier of the subscription for which you'd like to retrieve the upcoming invoice. If not provided, but a `subscription_items` is provided, you will preview creating a subscription with those items. If neither `subscription` nor `subscription_items` is provided, you will retrieve the next upcoming invoice from among the customer's subscriptions.
        [<Config.Query>]Subscription: string option
        ///For new subscriptions, a future timestamp to anchor the subscription's [billing cycle](https://stripe.com/docs/subscriptions/billing-cycle). This is used to determine the date of the first full invoice, and, for plans with `month` or `year` intervals, the day of the month for subsequent invoices. For existing subscriptions, the value can only be set to `now` or `unchanged`.
        [<Config.Query>]SubscriptionBillingCycleAnchor: string option
        ///Timestamp indicating when the subscription should be scheduled to cancel. Will prorate if within the current period and prorations have been enabled using `proration_behavior`.
        [<Config.Query>]SubscriptionCancelAt: int option
        ///Boolean indicating whether this subscription should cancel at the end of the current period.
        [<Config.Query>]SubscriptionCancelAtPeriodEnd: bool option
        ///This simulates the subscription being canceled or expired immediately.
        [<Config.Query>]SubscriptionCancelNow: bool option
        ///If provided, the invoice returned will preview updating or creating a subscription with these default tax rates. The default tax rates will apply to any line item that does not have `tax_rates` set.
        [<Config.Query>]SubscriptionDefaultTaxRates: string list option
        ///A list of up to 20 subscription items, each with an attached price.
        [<Config.Query>]SubscriptionItems: string list option
        ///Determines how to handle [prorations](https://stripe.com/docs/subscriptions/billing-cycle#prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.
        [<Config.Query>]SubscriptionProrationBehavior: string option
        ///If previewing an update to a subscription, and doing proration, `subscription_proration_date` forces the proration to be calculated as though the update was done at the specified time. The time given must be within the current subscription period and within the current phase of the schedule backing this subscription, if the schedule exists. If set, `subscription`, and one of `subscription_items`, or `subscription_trial_end` are required. Also, `subscription_proration_behavior` cannot be set to 'none'.
        [<Config.Query>]SubscriptionProrationDate: int option
        ///For paused subscriptions, setting `subscription_resume_at` to `now` will preview the invoice that will be generated if the subscription is resumed.
        [<Config.Query>]SubscriptionResumeAt: string option
        ///Date a subscription is intended to start (can be future or past)
        [<Config.Query>]SubscriptionStartDate: int option
        ///If provided, the invoice returned will preview updating or creating a subscription with that trial end. If set, one of `subscription_items` or `subscription` is required.
        [<Config.Query>]SubscriptionTrialEnd: string option
        ///Indicates if a plan's `trial_period_days` should be applied to the subscription. Setting `subscription_trial_end` per subscription is preferred, and this defaults to `false`. Setting this flag to `true` together with `subscription_trial_end` is not allowed. See [Using trial periods on subscriptions](https://stripe.com/docs/billing/subscriptions/trials) to learn more.
        [<Config.Query>]SubscriptionTrialFromPlan: bool option
    }
    with
        static member New(?automaticTax: Map<string, string>, ?subscriptionStartDate: int, ?subscriptionResumeAt: string, ?subscriptionProrationDate: int, ?subscriptionProrationBehavior: string, ?subscriptionItems: string list, ?subscriptionDefaultTaxRates: string list, ?subscriptionCancelNow: bool, ?subscriptionCancelAtPeriodEnd: bool, ?subscriptionCancelAt: int, ?subscriptionBillingCycleAnchor: string, ?subscription: string, ?schedule: string, ?invoiceItems: string list, ?expand: string list, ?discounts: string list, ?customerDetails: Map<string, string>, ?customer: string, ?currency: string, ?coupon: string, ?subscriptionTrialEnd: string, ?subscriptionTrialFromPlan: bool) =
            {
                AutomaticTax = automaticTax
                Coupon = coupon
                Currency = currency
                Customer = customer
                CustomerDetails = customerDetails
                Discounts = discounts
                Expand = expand
                InvoiceItems = invoiceItems
                Schedule = schedule
                Subscription = subscription
                SubscriptionBillingCycleAnchor = subscriptionBillingCycleAnchor
                SubscriptionCancelAt = subscriptionCancelAt
                SubscriptionCancelAtPeriodEnd = subscriptionCancelAtPeriodEnd
                SubscriptionCancelNow = subscriptionCancelNow
                SubscriptionDefaultTaxRates = subscriptionDefaultTaxRates
                SubscriptionItems = subscriptionItems
                SubscriptionProrationBehavior = subscriptionProrationBehavior
                SubscriptionProrationDate = subscriptionProrationDate
                SubscriptionResumeAt = subscriptionResumeAt
                SubscriptionStartDate = subscriptionStartDate
                SubscriptionTrialEnd = subscriptionTrialEnd
                SubscriptionTrialFromPlan = subscriptionTrialFromPlan
            }

    ///<p>At any time, you can preview the upcoming invoice for a customer. This will show you all the charges that are pending, including subscription renewal charges, invoice item charges, etc. It will also show you any discounts that are applicable to the invoice.
    ///Note that when you are viewing an upcoming invoice, you are simply viewing a preview – the invoice has not yet been created. As such, the upcoming invoice will not show up in invoice listing calls, and you cannot use the API to pay or edit the invoice. If you want to change the amount that your customer will be billed, you can add, remove, or update pending invoice items, or update the customer’s discount.
    ///You can preview the effects of updating a subscription, including a preview of what proration will take place. To ensure that the actual proration is calculated exactly the same as the previewed proration, you should pass a <code>proration_date</code> parameter when doing the actual subscription update. The value passed in should be the same as the <code>subscription_proration_date</code> returned on the upcoming invoice resource. The recommended way to get only the prorations being previewed is to consider only proration line items where <code>period[start]</code> is equal to the <code>subscription_proration_date</code> on the upcoming invoice resource.</p>
    let Upcoming settings (options: UpcomingOptions) =
        let qs = [("automatic_tax", options.AutomaticTax |> box); ("coupon", options.Coupon |> box); ("currency", options.Currency |> box); ("customer", options.Customer |> box); ("customer_details", options.CustomerDetails |> box); ("discounts", options.Discounts |> box); ("expand", options.Expand |> box); ("invoice_items", options.InvoiceItems |> box); ("schedule", options.Schedule |> box); ("subscription", options.Subscription |> box); ("subscription_billing_cycle_anchor", options.SubscriptionBillingCycleAnchor |> box); ("subscription_cancel_at", options.SubscriptionCancelAt |> box); ("subscription_cancel_at_period_end", options.SubscriptionCancelAtPeriodEnd |> box); ("subscription_cancel_now", options.SubscriptionCancelNow |> box); ("subscription_default_tax_rates", options.SubscriptionDefaultTaxRates |> box); ("subscription_items", options.SubscriptionItems |> box); ("subscription_proration_behavior", options.SubscriptionProrationBehavior |> box); ("subscription_proration_date", options.SubscriptionProrationDate |> box); ("subscription_resume_at", options.SubscriptionResumeAt |> box); ("subscription_start_date", options.SubscriptionStartDate |> box); ("subscription_trial_end", options.SubscriptionTrialEnd |> box); ("subscription_trial_from_plan", options.SubscriptionTrialFromPlan |> box)] |> Map.ofList
        $"/v1/invoices/upcoming"
        |> RestApi.getAsync<Invoice> settings qs

module InvoicesUpcomingLines =

    type UpcomingLinesOptions = {
        ///Settings for automatic tax lookup for this invoice preview.
        [<Config.Query>]AutomaticTax: Map<string, string> option
        ///The code of the coupon to apply. If `subscription` or `subscription_items` is provided, the invoice returned will preview updating or creating a subscription with that coupon. Otherwise, it will preview applying that coupon to the customer for the next upcoming invoice from among the customer's subscriptions. The invoice can be previewed without a coupon by passing this value as an empty string.
        [<Config.Query>]Coupon: string option
        ///The currency to preview this invoice in. Defaults to that of `customer` if not specified.
        [<Config.Query>]Currency: string option
        ///The identifier of the customer whose upcoming invoice you'd like to retrieve. If `automatic_tax` is enabled then one of `customer`, `customer_details`, `subscription`, or `schedule` must be set.
        [<Config.Query>]Customer: string option
        ///Details about the customer you want to invoice or overrides for an existing customer. If `automatic_tax` is enabled then one of `customer`, `customer_details`, `subscription`, or `schedule` must be set.
        [<Config.Query>]CustomerDetails: Map<string, string> option
        ///The coupons to redeem into discounts for the invoice preview. If not specified, inherits the discount from the customer or subscription. This only works for coupons directly applied to the invoice. To apply a coupon to a subscription, you must use the `coupon` parameter instead. Pass an empty string to avoid inheriting any discounts. To preview the upcoming invoice for a subscription that hasn't been created, use `coupon` instead.
        [<Config.Query>]Discounts: string list option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///List of invoice items to add or update in the upcoming invoice preview.
        [<Config.Query>]InvoiceItems: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///The identifier of the schedule whose upcoming invoice you'd like to retrieve. Cannot be used with subscription or subscription fields.
        [<Config.Query>]Schedule: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///The identifier of the subscription for which you'd like to retrieve the upcoming invoice. If not provided, but a `subscription_items` is provided, you will preview creating a subscription with those items. If neither `subscription` nor `subscription_items` is provided, you will retrieve the next upcoming invoice from among the customer's subscriptions.
        [<Config.Query>]Subscription: string option
        ///For new subscriptions, a future timestamp to anchor the subscription's [billing cycle](https://stripe.com/docs/subscriptions/billing-cycle). This is used to determine the date of the first full invoice, and, for plans with `month` or `year` intervals, the day of the month for subsequent invoices. For existing subscriptions, the value can only be set to `now` or `unchanged`.
        [<Config.Query>]SubscriptionBillingCycleAnchor: string option
        ///Timestamp indicating when the subscription should be scheduled to cancel. Will prorate if within the current period and prorations have been enabled using `proration_behavior`.
        [<Config.Query>]SubscriptionCancelAt: int option
        ///Boolean indicating whether this subscription should cancel at the end of the current period.
        [<Config.Query>]SubscriptionCancelAtPeriodEnd: bool option
        ///This simulates the subscription being canceled or expired immediately.
        [<Config.Query>]SubscriptionCancelNow: bool option
        ///If provided, the invoice returned will preview updating or creating a subscription with these default tax rates. The default tax rates will apply to any line item that does not have `tax_rates` set.
        [<Config.Query>]SubscriptionDefaultTaxRates: string list option
        ///A list of up to 20 subscription items, each with an attached price.
        [<Config.Query>]SubscriptionItems: string list option
        ///Determines how to handle [prorations](https://stripe.com/docs/subscriptions/billing-cycle#prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.
        [<Config.Query>]SubscriptionProrationBehavior: string option
        ///If previewing an update to a subscription, and doing proration, `subscription_proration_date` forces the proration to be calculated as though the update was done at the specified time. The time given must be within the current subscription period and within the current phase of the schedule backing this subscription, if the schedule exists. If set, `subscription`, and one of `subscription_items`, or `subscription_trial_end` are required. Also, `subscription_proration_behavior` cannot be set to 'none'.
        [<Config.Query>]SubscriptionProrationDate: int option
        ///For paused subscriptions, setting `subscription_resume_at` to `now` will preview the invoice that will be generated if the subscription is resumed.
        [<Config.Query>]SubscriptionResumeAt: string option
        ///Date a subscription is intended to start (can be future or past)
        [<Config.Query>]SubscriptionStartDate: int option
        ///If provided, the invoice returned will preview updating or creating a subscription with that trial end. If set, one of `subscription_items` or `subscription` is required.
        [<Config.Query>]SubscriptionTrialEnd: string option
        ///Indicates if a plan's `trial_period_days` should be applied to the subscription. Setting `subscription_trial_end` per subscription is preferred, and this defaults to `false`. Setting this flag to `true` together with `subscription_trial_end` is not allowed. See [Using trial periods on subscriptions](https://stripe.com/docs/billing/subscriptions/trials) to learn more.
        [<Config.Query>]SubscriptionTrialFromPlan: bool option
    }
    with
        static member New(?automaticTax: Map<string, string>, ?subscriptionStartDate: int, ?subscriptionResumeAt: string, ?subscriptionProrationDate: int, ?subscriptionProrationBehavior: string, ?subscriptionItems: string list, ?subscriptionDefaultTaxRates: string list, ?subscriptionCancelNow: bool, ?subscriptionCancelAtPeriodEnd: bool, ?subscriptionCancelAt: int, ?subscriptionBillingCycleAnchor: string, ?subscriptionTrialEnd: string, ?subscription: string, ?schedule: string, ?limit: int, ?invoiceItems: string list, ?expand: string list, ?endingBefore: string, ?discounts: string list, ?customerDetails: Map<string, string>, ?customer: string, ?currency: string, ?coupon: string, ?startingAfter: string, ?subscriptionTrialFromPlan: bool) =
            {
                AutomaticTax = automaticTax
                Coupon = coupon
                Currency = currency
                Customer = customer
                CustomerDetails = customerDetails
                Discounts = discounts
                EndingBefore = endingBefore
                Expand = expand
                InvoiceItems = invoiceItems
                Limit = limit
                Schedule = schedule
                StartingAfter = startingAfter
                Subscription = subscription
                SubscriptionBillingCycleAnchor = subscriptionBillingCycleAnchor
                SubscriptionCancelAt = subscriptionCancelAt
                SubscriptionCancelAtPeriodEnd = subscriptionCancelAtPeriodEnd
                SubscriptionCancelNow = subscriptionCancelNow
                SubscriptionDefaultTaxRates = subscriptionDefaultTaxRates
                SubscriptionItems = subscriptionItems
                SubscriptionProrationBehavior = subscriptionProrationBehavior
                SubscriptionProrationDate = subscriptionProrationDate
                SubscriptionResumeAt = subscriptionResumeAt
                SubscriptionStartDate = subscriptionStartDate
                SubscriptionTrialEnd = subscriptionTrialEnd
                SubscriptionTrialFromPlan = subscriptionTrialFromPlan
            }

    ///<p>When retrieving an upcoming invoice, you’ll get a <strong>lines</strong> property containing the total count of line items and the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
    let UpcomingLines settings (options: UpcomingLinesOptions) =
        let qs = [("automatic_tax", options.AutomaticTax |> box); ("coupon", options.Coupon |> box); ("currency", options.Currency |> box); ("customer", options.Customer |> box); ("customer_details", options.CustomerDetails |> box); ("discounts", options.Discounts |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice_items", options.InvoiceItems |> box); ("limit", options.Limit |> box); ("schedule", options.Schedule |> box); ("starting_after", options.StartingAfter |> box); ("subscription", options.Subscription |> box); ("subscription_billing_cycle_anchor", options.SubscriptionBillingCycleAnchor |> box); ("subscription_cancel_at", options.SubscriptionCancelAt |> box); ("subscription_cancel_at_period_end", options.SubscriptionCancelAtPeriodEnd |> box); ("subscription_cancel_now", options.SubscriptionCancelNow |> box); ("subscription_default_tax_rates", options.SubscriptionDefaultTaxRates |> box); ("subscription_items", options.SubscriptionItems |> box); ("subscription_proration_behavior", options.SubscriptionProrationBehavior |> box); ("subscription_proration_date", options.SubscriptionProrationDate |> box); ("subscription_resume_at", options.SubscriptionResumeAt |> box); ("subscription_start_date", options.SubscriptionStartDate |> box); ("subscription_trial_end", options.SubscriptionTrialEnd |> box); ("subscription_trial_from_plan", options.SubscriptionTrialFromPlan |> box)] |> Map.ofList
        $"/v1/invoices/upcoming/lines"
        |> RestApi.getAsync<LineItem list> settings qs

module InvoicesFinalize =

    type FinalizeInvoiceOptions = {
        [<Config.Path>]Invoice: string
        ///Controls whether Stripe performs [automatic collection](https://stripe.com/docs/invoicing/integration/automatic-advancement-collection) of the invoice. If `false`, the invoice's state doesn't automatically advance without an explicit action.
        [<Config.Form>]AutoAdvance: bool option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(invoice: string, ?autoAdvance: bool, ?expand: string list) =
            {
                Invoice = invoice
                AutoAdvance = autoAdvance
                Expand = expand
            }

    ///<p>Stripe automatically finalizes drafts before sending and attempting payment on invoices. However, if you’d like to finalize a draft invoice manually, you can do so using this method.</p>
    let FinalizeInvoice settings (options: FinalizeInvoiceOptions) =
        $"/v1/invoices/{options.Invoice}/finalize"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesLines =

    type ListOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Invoice: string
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(invoice: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Invoice = invoice
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>When retrieving an invoice, you’ll get a <strong>lines</strong> property containing the total count of line items and the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/invoices/{options.Invoice}/lines"
        |> RestApi.getAsync<LineItem list> settings qs

module InvoicesMarkUncollectible =

    type MarkUncollectibleOptions = {
        [<Config.Path>]Invoice: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(invoice: string, ?expand: string list) =
            {
                Invoice = invoice
                Expand = expand
            }

    ///<p>Marking an invoice as uncollectible is useful for keeping track of bad debts that can be written off for accounting purposes.</p>
    let MarkUncollectible settings (options: MarkUncollectibleOptions) =
        $"/v1/invoices/{options.Invoice}/mark_uncollectible"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesPay =

    type PayOptions = {
        [<Config.Path>]Invoice: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///In cases where the source used to pay the invoice has insufficient funds, passing `forgive=true` controls whether a charge should be attempted for the full amount available on the source, up to the amount to fully pay the invoice. This effectively forgives the difference between the amount available on the source and the amount due. 
        ///Passing `forgive=false` will fail the charge if the source hasn't been pre-funded with the right amount. An example for this case is with ACH Credit Transfers and wires: if the amount wired is less than the amount due by a small amount, you might want to forgive the difference. Defaults to `false`.
        [<Config.Form>]Forgive: bool option
        ///ID of the mandate to be used for this invoice. It must correspond to the payment method used to pay the invoice, including the payment_method param or the invoice's default_payment_method or default_source, if set.
        [<Config.Form>]Mandate: Choice<string,string> option
        ///Indicates if a customer is on or off-session while an invoice payment is attempted. Defaults to `true` (off-session).
        [<Config.Form>]OffSession: bool option
        ///Boolean representing whether an invoice is paid outside of Stripe. This will result in no charge being made. Defaults to `false`.
        [<Config.Form>]PaidOutOfBand: bool option
        ///A PaymentMethod to be charged. The PaymentMethod must be the ID of a PaymentMethod belonging to the customer associated with the invoice being paid.
        [<Config.Form>]PaymentMethod: string option
        ///A payment source to be charged. The source must be the ID of a source belonging to the customer associated with the invoice being paid.
        [<Config.Form>]Source: string option
    }
    with
        static member New(invoice: string, ?expand: string list, ?forgive: bool, ?mandate: Choice<string,string>, ?offSession: bool, ?paidOutOfBand: bool, ?paymentMethod: string, ?source: string) =
            {
                Invoice = invoice
                Expand = expand
                Forgive = forgive
                Mandate = mandate
                OffSession = offSession
                PaidOutOfBand = paidOutOfBand
                PaymentMethod = paymentMethod
                Source = source
            }

    ///<p>Stripe automatically creates and then attempts to collect payment on invoices for customers on subscriptions according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to attempt payment on an invoice out of the normal collection schedule or for some other reason, you can do so.</p>
    let Pay settings (options: PayOptions) =
        $"/v1/invoices/{options.Invoice}/pay"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesSend =

    type SendInvoiceOptions = {
        [<Config.Path>]Invoice: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(invoice: string, ?expand: string list) =
            {
                Invoice = invoice
                Expand = expand
            }

    ///<p>Stripe will automatically send invoices to customers according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to manually send an invoice to your customer out of the normal schedule, you can do so. When sending invoices that have already been paid, there will be no reference to the payment in the email.
    ///Requests made in test-mode result in no emails being sent, despite sending an <code>invoice.sent</code> event.</p>
    let SendInvoice settings (options: SendInvoiceOptions) =
        $"/v1/invoices/{options.Invoice}/send"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesVoid =

    type VoidInvoiceOptions = {
        [<Config.Path>]Invoice: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(invoice: string, ?expand: string list) =
            {
                Invoice = invoice
                Expand = expand
            }

    ///<p>Mark a finalized invoice as void. This cannot be undone. Voiding an invoice is similar to <a href="#delete_invoice">deletion</a>, however it only applies to finalized invoices and maintains a papertrail where the invoice can still be found.</p>
    let VoidInvoice settings (options: VoidInvoiceOptions) =
        $"/v1/invoices/{options.Invoice}/void"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module Plans =

    type ListOptions = {
        ///Only return plans that are active or inactive (e.g., pass `false` to list all inactive plans).
        [<Config.Query>]Active: bool option
        ///A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Only return plans for the given product.
        [<Config.Query>]Product: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?product: string, ?startingAfter: string) =
            {
                Active = active
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Product = product
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of your plans.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("product", options.Product |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/plans"
        |> RestApi.getAsync<Plan list> settings qs

    type Create'ProductInlineProductParams = {
        ///Whether the product is currently available for purchase. Defaults to `true`.
        [<Config.Form>]Active: bool option
        ///The identifier for the product. Must be unique. If not provided, an identifier will be randomly generated.
        [<Config.Form>]Id: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The product's name, meant to be displayable to the customer.
        [<Config.Form>]Name: string option
        ///An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
        ///This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.
        [<Config.Form>]StatementDescriptor: string option
        ///A [tax code](https://stripe.com/docs/tax/tax-categories) ID.
        [<Config.Form>]TaxCode: string option
        ///A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.
        [<Config.Form>]UnitLabel: string option
    }
    with
        static member New(?active: bool, ?id: string, ?metadata: Map<string, string>, ?name: string, ?statementDescriptor: string, ?taxCode: string, ?unitLabel: string) =
            {
                Active = active
                Id = id
                Metadata = metadata
                Name = name
                StatementDescriptor = statementDescriptor
                TaxCode = taxCode
                UnitLabel = unitLabel
            }

    type Create'TiersUpTo =
    | Inf

    type Create'Tiers = {
        ///The flat billing amount for an entire tier, regardless of the number of units in the tier.
        [<Config.Form>]FlatAmount: int option
        ///Same as `flat_amount`, but accepts a decimal value representing an integer in the minor units of the currency. Only one of `flat_amount` and `flat_amount_decimal` can be set.
        [<Config.Form>]FlatAmountDecimal: string option
        ///The per unit billing amount for each individual unit for which this tier applies.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
        ///Specifies the upper bound of this tier. The lower bound of a tier is the upper bound of the previous tier adding one. Use `inf` to define a fallback tier.
        [<Config.Form>]UpTo: Choice<Create'TiersUpTo,int> option
    }
    with
        static member New(?flatAmount: int, ?flatAmountDecimal: string, ?unitAmount: int, ?unitAmountDecimal: string, ?upTo: Choice<Create'TiersUpTo,int>) =
            {
                FlatAmount = flatAmount
                FlatAmountDecimal = flatAmountDecimal
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
                UpTo = upTo
            }

    type Create'TransformUsageRound =
    | Down
    | Up

    type Create'TransformUsage = {
        ///Divide usage by this number.
        [<Config.Form>]DivideBy: int option
        ///After division, either round the result `up` or `down`.
        [<Config.Form>]Round: Create'TransformUsageRound option
    }
    with
        static member New(?divideBy: int, ?round: Create'TransformUsageRound) =
            {
                DivideBy = divideBy
                Round = round
            }

    type Create'AggregateUsage =
    | LastDuringPeriod
    | LastEver
    | Max
    | Sum

    type Create'BillingScheme =
    | PerUnit
    | Tiered

    type Create'Interval =
    | Day
    | Month
    | Week
    | Year

    type Create'TiersMode =
    | Graduated
    | Volume

    type Create'UsageType =
    | Licensed
    | Metered

    type CreateOptions = {
        ///Whether the plan is currently available for new subscriptions. Defaults to `true`.
        [<Config.Form>]Active: bool option
        ///Specifies a usage aggregation strategy for plans of `usage_type=metered`. Allowed values are `sum` for summing up all usage during a period, `last_during_period` for using the last usage record reported within a period, `last_ever` for using the last usage record ever (across period bounds) or `max` which uses the usage record with the maximum reported usage during a period. Defaults to `sum`.
        [<Config.Form>]AggregateUsage: Create'AggregateUsage option
        ///A positive integer in cents (or local equivalent) (or 0 for a free plan) representing how much to charge on a recurring basis.
        [<Config.Form>]Amount: int option
        ///Same as `amount`, but accepts a decimal value with at most 12 decimal places. Only one of `amount` and `amount_decimal` can be set.
        [<Config.Form>]AmountDecimal: string option
        ///Describes how to compute the price per period. Either `per_unit` or `tiered`. `per_unit` indicates that the fixed amount (specified in `amount`) will be charged per unit in `quantity` (for plans with `usage_type=licensed`), or per unit of total usage (for plans with `usage_type=metered`). `tiered` indicates that the unit pricing will be computed using a tiering strategy as defined using the `tiers` and `tiers_mode` attributes.
        [<Config.Form>]BillingScheme: Create'BillingScheme option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///An identifier randomly generated by Stripe. Used to identify this plan when subscribing a customer. You can optionally override this ID, but the ID must be unique across all plans in your Stripe account. You can, however, use the same plan ID in both live and test modes.
        [<Config.Form>]Id: string option
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Create'Interval
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///A brief description of the plan, hidden from customers.
        [<Config.Form>]Nickname: string option
        [<Config.Form>]Product: Choice<Create'ProductInlineProductParams,string> option
        ///Each element represents a pricing tier. This parameter requires `billing_scheme` to be set to `tiered`. See also the documentation for `billing_scheme`.
        [<Config.Form>]Tiers: Create'Tiers list option
        ///Defines if the tiering price should be `graduated` or `volume` based. In `volume`-based tiering, the maximum quantity within a period determines the per unit price, in `graduated` tiering pricing can successively change as the quantity grows.
        [<Config.Form>]TiersMode: Create'TiersMode option
        ///Apply a transformation to the reported usage or set quantity before computing the billed price. Cannot be combined with `tiers`.
        [<Config.Form>]TransformUsage: Create'TransformUsage option
        ///Default number of trial days when subscribing a customer to this plan using [`trial_from_plan=true`](https://stripe.com/docs/api#create_subscription-trial_from_plan).
        [<Config.Form>]TrialPeriodDays: int option
        ///Configures how the quantity per period should be determined. Can be either `metered` or `licensed`. `licensed` automatically bills the `quantity` set when adding it to a subscription. `metered` aggregates the total usage based on usage records. Defaults to `licensed`.
        [<Config.Form>]UsageType: Create'UsageType option
    }
    with
        static member New(interval: Create'Interval, currency: string, ?transformUsage: Create'TransformUsage, ?tiersMode: Create'TiersMode, ?tiers: Create'Tiers list, ?product: Choice<Create'ProductInlineProductParams,string>, ?nickname: string, ?metadata: Map<string, string>, ?intervalCount: int, ?active: bool, ?id: string, ?expand: string list, ?billingScheme: Create'BillingScheme, ?amountDecimal: string, ?amount: int, ?aggregateUsage: Create'AggregateUsage, ?trialPeriodDays: int, ?usageType: Create'UsageType) =
            {
                Active = active
                AggregateUsage = aggregateUsage
                Amount = amount
                AmountDecimal = amountDecimal
                BillingScheme = billingScheme
                Currency = currency
                Expand = expand
                Id = id
                Interval = interval
                IntervalCount = intervalCount
                Metadata = metadata
                Nickname = nickname
                Product = product
                Tiers = tiers
                TiersMode = tiersMode
                TransformUsage = transformUsage
                TrialPeriodDays = trialPeriodDays
                UsageType = usageType
            }

    ///<p>You can now model subscriptions more flexibly using the <a href="#prices">Prices API</a>. It replaces the Plans API and is backwards compatible to simplify your migration.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/plans"
        |> RestApi.postAsync<_, Plan> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Plan: string
    }
    with
        static member New(plan: string) =
            {
                Plan = plan
            }

    ///<p>Deleting plans means new subscribers can’t be added. Existing subscribers aren’t affected.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/plans/{options.Plan}"
        |> RestApi.deleteAsync<DeletedPlan> settings (Map.empty)

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Plan: string
    }
    with
        static member New(plan: string, ?expand: string list) =
            {
                Expand = expand
                Plan = plan
            }

    ///<p>Retrieves the plan with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/plans/{options.Plan}"
        |> RestApi.getAsync<Plan> settings qs

    type UpdateOptions = {
        [<Config.Path>]Plan: string
        ///Whether the plan is currently available for new subscriptions.
        [<Config.Form>]Active: bool option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///A brief description of the plan, hidden from customers.
        [<Config.Form>]Nickname: string option
        ///The product the plan belongs to. This cannot be changed once it has been used in a subscription or subscription schedule.
        [<Config.Form>]Product: string option
        ///Default number of trial days when subscribing a customer to this plan using [`trial_from_plan=true`](https://stripe.com/docs/api#create_subscription-trial_from_plan).
        [<Config.Form>]TrialPeriodDays: int option
    }
    with
        static member New(plan: string, ?active: bool, ?expand: string list, ?metadata: Map<string, string>, ?nickname: string, ?product: string, ?trialPeriodDays: int) =
            {
                Plan = plan
                Active = active
                Expand = expand
                Metadata = metadata
                Nickname = nickname
                Product = product
                TrialPeriodDays = trialPeriodDays
            }

    ///<p>Updates the specified plan by setting the values of the parameters passed. Any parameters not provided are left unchanged. By design, you cannot change a plan’s ID, amount, currency, or billing cycle.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/plans/{options.Plan}"
        |> RestApi.postAsync<_, Plan> settings (Map.empty) options

module Prices =

    type ListOptions = {
        ///Only return prices that are active or inactive (e.g., pass `false` to list all inactive prices).
        [<Config.Query>]Active: bool option
        ///A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
        [<Config.Query>]Created: int option
        ///Only return prices for the given currency.
        [<Config.Query>]Currency: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Only return the price with these lookup_keys, if any exist.
        [<Config.Query>]LookupKeys: string list option
        ///Only return prices for the given product.
        [<Config.Query>]Product: string option
        ///Only return prices with these recurring fields.
        [<Config.Query>]Recurring: Map<string, string> option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only return prices of type `recurring` or `one_time`.
        [<Config.Query>]Type: string option
    }
    with
        static member New(?active: bool, ?created: int, ?currency: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?lookupKeys: string list, ?product: string, ?recurring: Map<string, string>, ?startingAfter: string, ?type': string) =
            {
                Active = active
                Created = created
                Currency = currency
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                LookupKeys = lookupKeys
                Product = product
                Recurring = recurring
                StartingAfter = startingAfter
                Type = type'
            }

    ///<p>Returns a list of your prices.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("currency", options.Currency |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("lookup_keys", options.LookupKeys |> box); ("product", options.Product |> box); ("recurring", options.Recurring |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/prices"
        |> RestApi.getAsync<Price list> settings qs

    type Create'CustomUnitAmount = {
        ///Pass in `true` to enable `custom_unit_amount`, otherwise omit `custom_unit_amount`.
        [<Config.Form>]Enabled: bool option
        ///The maximum unit amount the customer can specify for this item.
        [<Config.Form>]Maximum: int option
        ///The minimum unit amount the customer can specify for this item. Must be at least the minimum charge amount.
        [<Config.Form>]Minimum: int option
        ///The starting unit amount which can be updated by the customer.
        [<Config.Form>]Preset: int option
    }
    with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int, ?preset: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
                Preset = preset
            }

    type Create'ProductData = {
        ///Whether the product is currently available for purchase. Defaults to `true`.
        [<Config.Form>]Active: bool option
        ///The identifier for the product. Must be unique. If not provided, an identifier will be randomly generated.
        [<Config.Form>]Id: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The product's name, meant to be displayable to the customer.
        [<Config.Form>]Name: string option
        ///An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
        ///This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.
        [<Config.Form>]StatementDescriptor: string option
        ///A [tax code](https://stripe.com/docs/tax/tax-categories) ID.
        [<Config.Form>]TaxCode: string option
        ///A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.
        [<Config.Form>]UnitLabel: string option
    }
    with
        static member New(?active: bool, ?id: string, ?metadata: Map<string, string>, ?name: string, ?statementDescriptor: string, ?taxCode: string, ?unitLabel: string) =
            {
                Active = active
                Id = id
                Metadata = metadata
                Name = name
                StatementDescriptor = statementDescriptor
                TaxCode = taxCode
                UnitLabel = unitLabel
            }

    type Create'RecurringAggregateUsage =
    | LastDuringPeriod
    | LastEver
    | Max
    | Sum

    type Create'RecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'RecurringUsageType =
    | Licensed
    | Metered

    type Create'Recurring = {
        ///Specifies a usage aggregation strategy for prices of `usage_type=metered`. Allowed values are `sum` for summing up all usage during a period, `last_during_period` for using the last usage record reported within a period, `last_ever` for using the last usage record ever (across period bounds) or `max` which uses the usage record with the maximum reported usage during a period. Defaults to `sum`.
        [<Config.Form>]AggregateUsage: Create'RecurringAggregateUsage option
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Create'RecurringInterval option
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
        ///Default number of trial days when subscribing a customer to this price using [`trial_from_plan=true`](https://stripe.com/docs/api#create_subscription-trial_from_plan).
        [<Config.Form>]TrialPeriodDays: int option
        ///Configures how the quantity per period should be determined. Can be either `metered` or `licensed`. `licensed` automatically bills the `quantity` set when adding it to a subscription. `metered` aggregates the total usage based on usage records. Defaults to `licensed`.
        [<Config.Form>]UsageType: Create'RecurringUsageType option
    }
    with
        static member New(?aggregateUsage: Create'RecurringAggregateUsage, ?interval: Create'RecurringInterval, ?intervalCount: int, ?trialPeriodDays: int, ?usageType: Create'RecurringUsageType) =
            {
                AggregateUsage = aggregateUsage
                Interval = interval
                IntervalCount = intervalCount
                TrialPeriodDays = trialPeriodDays
                UsageType = usageType
            }

    type Create'TiersUpTo =
    | Inf

    type Create'Tiers = {
        ///The flat billing amount for an entire tier, regardless of the number of units in the tier.
        [<Config.Form>]FlatAmount: int option
        ///Same as `flat_amount`, but accepts a decimal value representing an integer in the minor units of the currency. Only one of `flat_amount` and `flat_amount_decimal` can be set.
        [<Config.Form>]FlatAmountDecimal: string option
        ///The per unit billing amount for each individual unit for which this tier applies.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
        ///Specifies the upper bound of this tier. The lower bound of a tier is the upper bound of the previous tier adding one. Use `inf` to define a fallback tier.
        [<Config.Form>]UpTo: Choice<Create'TiersUpTo,int> option
    }
    with
        static member New(?flatAmount: int, ?flatAmountDecimal: string, ?unitAmount: int, ?unitAmountDecimal: string, ?upTo: Choice<Create'TiersUpTo,int>) =
            {
                FlatAmount = flatAmount
                FlatAmountDecimal = flatAmountDecimal
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
                UpTo = upTo
            }

    type Create'TransformQuantityRound =
    | Down
    | Up

    type Create'TransformQuantity = {
        ///Divide usage by this number.
        [<Config.Form>]DivideBy: int option
        ///After division, either round the result `up` or `down`.
        [<Config.Form>]Round: Create'TransformQuantityRound option
    }
    with
        static member New(?divideBy: int, ?round: Create'TransformQuantityRound) =
            {
                DivideBy = divideBy
                Round = round
            }

    type Create'BillingScheme =
    | PerUnit
    | Tiered

    type Create'TaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'TiersMode =
    | Graduated
    | Volume

    type CreateOptions = {
        ///Whether the price can be used for new purchases. Defaults to `true`.
        [<Config.Form>]Active: bool option
        ///Describes how to compute the price per period. Either `per_unit` or `tiered`. `per_unit` indicates that the fixed amount (specified in `unit_amount` or `unit_amount_decimal`) will be charged per unit in `quantity` (for prices with `usage_type=licensed`), or per unit of total usage (for prices with `usage_type=metered`). `tiered` indicates that the unit pricing will be computed using a tiering strategy as defined using the `tiers` and `tiers_mode` attributes.
        [<Config.Form>]BillingScheme: Create'BillingScheme option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string
        ///Prices defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]CurrencyOptions: Map<string, string> option
        ///When set, provides configuration for the amount to be adjusted by the customer during Checkout Sessions and Payment Links.
        [<Config.Form>]CustomUnitAmount: Create'CustomUnitAmount option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A lookup key used to retrieve prices dynamically from a static string. This may be up to 200 characters.
        [<Config.Form>]LookupKey: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///A brief description of the price, hidden from customers.
        [<Config.Form>]Nickname: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///These fields can be used to create a new product that this price will belong to.
        [<Config.Form>]ProductData: Create'ProductData option
        ///The recurring components of a price such as `interval` and `usage_type`.
        [<Config.Form>]Recurring: Create'Recurring option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Create'TaxBehavior option
        ///Each element represents a pricing tier. This parameter requires `billing_scheme` to be set to `tiered`. See also the documentation for `billing_scheme`.
        [<Config.Form>]Tiers: Create'Tiers list option
        ///Defines if the tiering price should be `graduated` or `volume` based. In `volume`-based tiering, the maximum quantity within a period determines the per unit price, in `graduated` tiering pricing can successively change as the quantity grows.
        [<Config.Form>]TiersMode: Create'TiersMode option
        ///If set to true, will atomically remove the lookup key from the existing price, and assign it to this price.
        [<Config.Form>]TransferLookupKey: bool option
        ///Apply a transformation to the reported usage or set quantity before computing the billed price. Cannot be combined with `tiers`.
        [<Config.Form>]TransformQuantity: Create'TransformQuantity option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge. One of `unit_amount` or `custom_unit_amount` is required, unless `billing_scheme=tiered`.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(currency: string, ?active: bool, ?transformQuantity: Create'TransformQuantity, ?transferLookupKey: bool, ?tiersMode: Create'TiersMode, ?tiers: Create'Tiers list, ?taxBehavior: Create'TaxBehavior, ?recurring: Create'Recurring, ?productData: Create'ProductData, ?product: string, ?nickname: string, ?metadata: Map<string, string>, ?lookupKey: string, ?expand: string list, ?customUnitAmount: Create'CustomUnitAmount, ?currencyOptions: Map<string, string>, ?billingScheme: Create'BillingScheme, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Active = active
                BillingScheme = billingScheme
                Currency = currency
                CurrencyOptions = currencyOptions
                CustomUnitAmount = customUnitAmount
                Expand = expand
                LookupKey = lookupKey
                Metadata = metadata
                Nickname = nickname
                Product = product
                ProductData = productData
                Recurring = recurring
                TaxBehavior = taxBehavior
                Tiers = tiers
                TiersMode = tiersMode
                TransferLookupKey = transferLookupKey
                TransformQuantity = transformQuantity
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    ///<p>Creates a new price for an existing product. The price can be recurring or one-time.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/prices"
        |> RestApi.postAsync<_, Price> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Price: string
    }
    with
        static member New(price: string, ?expand: string list) =
            {
                Expand = expand
                Price = price
            }

    ///<p>Retrieves the price with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/prices/{options.Price}"
        |> RestApi.getAsync<Price> settings qs

    type Update'TaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type UpdateOptions = {
        [<Config.Path>]Price: string
        ///Whether the price can be used for new purchases. Defaults to `true`.
        [<Config.Form>]Active: bool option
        ///Prices defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]CurrencyOptions: Choice<Map<string, string>,string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A lookup key used to retrieve prices dynamically from a static string. This may be up to 200 characters.
        [<Config.Form>]LookupKey: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///A brief description of the price, hidden from customers.
        [<Config.Form>]Nickname: string option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Update'TaxBehavior option
        ///If set to true, will atomically remove the lookup key from the existing price, and assign it to this price.
        [<Config.Form>]TransferLookupKey: bool option
    }
    with
        static member New(price: string, ?active: bool, ?currencyOptions: Choice<Map<string, string>,string>, ?expand: string list, ?lookupKey: string, ?metadata: Map<string, string>, ?nickname: string, ?taxBehavior: Update'TaxBehavior, ?transferLookupKey: bool) =
            {
                Price = price
                Active = active
                CurrencyOptions = currencyOptions
                Expand = expand
                LookupKey = lookupKey
                Metadata = metadata
                Nickname = nickname
                TaxBehavior = taxBehavior
                TransferLookupKey = transferLookupKey
            }

    ///<p>Updates the specified price by setting the values of the parameters passed. Any parameters not provided are left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/prices/{options.Price}"
        |> RestApi.postAsync<_, Price> settings (Map.empty) options

module PricesSearch =

    type SearchOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.
        [<Config.Query>]Page: string option
        ///The search query string. See [search query language](https://stripe.com/docs/search#search-query-language) and the list of supported [query fields for prices](https://stripe.com/docs/search#query-fields-for-prices).
        [<Config.Query>]Query: string
    }
    with
        static member New(query: string, ?expand: string list, ?limit: int, ?page: string) =
            {
                Expand = expand
                Limit = limit
                Page = page
                Query = query
            }

    ///<p>Search for prices you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/prices/search"
        |> RestApi.getAsync<Price list> settings qs

module PromotionCodes =

    type ListOptions = {
        ///Filter promotion codes by whether they are active.
        [<Config.Query>]Active: bool option
        ///Only return promotion codes that have this case-insensitive code.
        [<Config.Query>]Code: string option
        ///Only return promotion codes for this coupon.
        [<Config.Query>]Coupon: string option
        ///A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
        [<Config.Query>]Created: int option
        ///Only return promotion codes that are restricted to this customer.
        [<Config.Query>]Customer: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?active: bool, ?code: string, ?coupon: string, ?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Active = active
                Code = code
                Coupon = coupon
                Created = created
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of your promotion codes.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("code", options.Code |> box); ("coupon", options.Coupon |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/promotion_codes"
        |> RestApi.getAsync<PromotionCode list> settings qs

    type Create'Restrictions = {
        ///Promotion codes defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]CurrencyOptions: Map<string, string> option
        ///A Boolean indicating if the Promotion Code should only be redeemed for Customers without any successful payments or invoices
        [<Config.Form>]FirstTimeTransaction: bool option
        ///Minimum amount required to redeem this Promotion Code into a Coupon (e.g., a purchase must be $100 or more to work).
        [<Config.Form>]MinimumAmount: int option
        ///Three-letter [ISO code](https://stripe.com/docs/currencies) for minimum_amount
        [<Config.Form>]MinimumAmountCurrency: string option
    }
    with
        static member New(?currencyOptions: Map<string, string>, ?firstTimeTransaction: bool, ?minimumAmount: int, ?minimumAmountCurrency: string) =
            {
                CurrencyOptions = currencyOptions
                FirstTimeTransaction = firstTimeTransaction
                MinimumAmount = minimumAmount
                MinimumAmountCurrency = minimumAmountCurrency
            }

    type CreateOptions = {
        ///Whether the promotion code is currently active.
        [<Config.Form>]Active: bool option
        ///The customer-facing code. Regardless of case, this code must be unique across all active promotion codes for a specific customer. If left blank, we will generate one automatically.
        [<Config.Form>]Code: string option
        ///The coupon for this promotion code.
        [<Config.Form>]Coupon: string
        ///The customer that this promotion code can be used by. If not set, the promotion code can be used by all customers.
        [<Config.Form>]Customer: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The timestamp at which this promotion code will expire. If the coupon has specified a `redeems_by`, then this value cannot be after the coupon's `redeems_by`.
        [<Config.Form>]ExpiresAt: DateTime option
        ///A positive integer specifying the number of times the promotion code can be redeemed. If the coupon has specified a `max_redemptions`, then this value cannot be greater than the coupon's `max_redemptions`.
        [<Config.Form>]MaxRedemptions: int option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Settings that restrict the redemption of the promotion code.
        [<Config.Form>]Restrictions: Create'Restrictions option
    }
    with
        static member New(coupon: string, ?active: bool, ?code: string, ?customer: string, ?expand: string list, ?expiresAt: DateTime, ?maxRedemptions: int, ?metadata: Map<string, string>, ?restrictions: Create'Restrictions) =
            {
                Active = active
                Code = code
                Coupon = coupon
                Customer = customer
                Expand = expand
                ExpiresAt = expiresAt
                MaxRedemptions = maxRedemptions
                Metadata = metadata
                Restrictions = restrictions
            }

    ///<p>A promotion code points to a coupon. You can optionally restrict the code to a specific customer, redemption limit, and expiration date.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/promotion_codes"
        |> RestApi.postAsync<_, PromotionCode> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]PromotionCode: string
    }
    with
        static member New(promotionCode: string, ?expand: string list) =
            {
                Expand = expand
                PromotionCode = promotionCode
            }

    ///<p>Retrieves the promotion code with the given ID. In order to retrieve a promotion code by the customer-facing <code>code</code> use <a href="/docs/api/promotion_codes/list">list</a> with the desired <code>code</code>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/promotion_codes/{options.PromotionCode}"
        |> RestApi.getAsync<PromotionCode> settings qs

    type Update'Restrictions = {
        ///Promotion codes defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]CurrencyOptions: Map<string, string> option
    }
    with
        static member New(?currencyOptions: Map<string, string>) =
            {
                CurrencyOptions = currencyOptions
            }

    type UpdateOptions = {
        [<Config.Path>]PromotionCode: string
        ///Whether the promotion code is currently active. A promotion code can only be reactivated when the coupon is still valid and the promotion code is otherwise redeemable.
        [<Config.Form>]Active: bool option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Settings that restrict the redemption of the promotion code.
        [<Config.Form>]Restrictions: Update'Restrictions option
    }
    with
        static member New(promotionCode: string, ?active: bool, ?expand: string list, ?metadata: Map<string, string>, ?restrictions: Update'Restrictions) =
            {
                PromotionCode = promotionCode
                Active = active
                Expand = expand
                Metadata = metadata
                Restrictions = restrictions
            }

    ///<p>Updates the specified promotion code by setting the values of the parameters passed. Most fields are, by design, not editable.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/promotion_codes/{options.PromotionCode}"
        |> RestApi.postAsync<_, PromotionCode> settings (Map.empty) options

module Quotes =

    type ListOptions = {
        ///The ID of the customer whose quotes will be retrieved.
        [<Config.Query>]Customer: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///The status of the quote.
        [<Config.Query>]Status: string option
        ///Provides a list of quotes that are associated with the specified test clock. The response will not include quotes with test clocks if this and the customer parameter is not set.
        [<Config.Query>]TestClock: string option
    }
    with
        static member New(?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string, ?testClock: string) =
            {
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
                TestClock = testClock
            }

    ///<p>Returns a list of your quotes.</p>
    let List settings (options: ListOptions) =
        let qs = [("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("test_clock", options.TestClock |> box)] |> Map.ofList
        $"/v1/quotes"
        |> RestApi.getAsync<Quote list> settings qs

    type Create'AutomaticTax = {
        ///Controls whether Stripe will automatically compute tax on the resulting invoices or subscriptions as well as the quote itself.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'Discounts = {
        ///ID of the coupon to create a new discount for.
        [<Config.Form>]Coupon: string option
        ///ID of an existing discount on the object (or one of its ancestors) to reuse.
        [<Config.Form>]Discount: string option
    }
    with
        static member New(?coupon: string, ?discount: string) =
            {
                Coupon = coupon
                Discount = discount
            }

    type Create'FromQuote = {
        ///Whether this quote is a revision of the previous quote.
        [<Config.Form>]IsRevision: bool option
        ///The `id` of the quote that will be cloned.
        [<Config.Form>]Quote: string option
    }
    with
        static member New(?isRevision: bool, ?quote: string) =
            {
                IsRevision = isRevision
                Quote = quote
            }

    type Create'InvoiceSettings = {
        ///Number of days within which a customer must pay the invoice generated by this quote. This value will be `null` for quotes where `collection_method=charge_automatically`.
        [<Config.Form>]DaysUntilDue: int option
    }
    with
        static member New(?daysUntilDue: int) =
            {
                DaysUntilDue = daysUntilDue
            }

    type Create'LineItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'LineItemsPriceDataRecurring = {
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Create'LineItemsPriceDataRecurringInterval option
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'LineItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'LineItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'LineItemsPriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///The recurring components of a price such as `interval` and `interval_count`.
        [<Config.Form>]Recurring: Create'LineItemsPriceDataRecurring option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Create'LineItemsPriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?recurring: Create'LineItemsPriceDataRecurring, ?taxBehavior: Create'LineItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'LineItems = {
        ///The ID of the price object. One of `price` or `price_data` is required.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline. One of `price` or `price_data` is required.
        [<Config.Form>]PriceData: Create'LineItemsPriceData option
        ///The quantity of the line item.
        [<Config.Form>]Quantity: int option
        ///The tax rates which apply to the line item. When set, the `default_tax_rates` on the quote do not apply to this line item.
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?price: string, ?priceData: Create'LineItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Create'SubscriptionDataEffectiveDate =
    | CurrentPeriodEnd

    type Create'SubscriptionData = {
        ///The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription.
        [<Config.Form>]Description: string option
        ///When creating a new subscription, the date of which the subscription schedule will start after the quote is accepted. When updating a subscription, the date of which the subscription will be updated using a subscription schedule. The special value `current_period_end` can be provided to update a subscription at the end of its current period. The `effective_date` is ignored if it is in the past when the quote is accepted.
        [<Config.Form>]EffectiveDate: Choice<Create'SubscriptionDataEffectiveDate,DateTime,string> option
        ///Integer representing the number of trial period days before the customer is charged for the first time.
        [<Config.Form>]TrialPeriodDays: Choice<int,string> option
    }
    with
        static member New(?description: string, ?effectiveDate: Choice<Create'SubscriptionDataEffectiveDate,DateTime,string>, ?trialPeriodDays: Choice<int,string>) =
            {
                Description = description
                EffectiveDate = effectiveDate
                TrialPeriodDays = trialPeriodDays
            }

    type Create'TransferDataTransferDataSpecs = {
        ///The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred. There cannot be any line items with recurring prices when using this field.
        [<Config.Form>]Amount: int option
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination. There must be at least 1 line item with a recurring price to use this field.
        [<Config.Form>]AmountPercent: decimal option
        ///ID of an existing, connected Stripe account.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amount: int, ?amountPercent: decimal, ?destination: string) =
            {
                Amount = amount
                AmountPercent = amountPercent
                Destination = destination
            }

    type Create'CollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type CreateOptions = {
        ///The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. There cannot be any line items with recurring prices when using this field.
        [<Config.Form>]ApplicationFeeAmount: Choice<int,string> option
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. There must be at least 1 line item with a recurring price to use this field.
        [<Config.Form>]ApplicationFeePercent: Choice<decimal,string> option
        ///Settings for automatic tax lookup for this quote and resulting invoices and subscriptions.
        [<Config.Form>]AutomaticTax: Create'AutomaticTax option
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay invoices at the end of the subscription cycle or at invoice finalization using the default payment method attached to the subscription or customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically`.
        [<Config.Form>]CollectionMethod: Create'CollectionMethod option
        ///The customer for which this quote belongs to. A customer is required before finalizing the quote. Once specified, it cannot be changed.
        [<Config.Form>]Customer: string option
        ///The tax rates that will apply to any line item that does not have `tax_rates` set.
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///A description that will be displayed on the quote PDF. If no value is passed, the default description configured in your [quote template settings](https://dashboard.stripe.com/settings/billing/quote) will be used.
        [<Config.Form>]Description: Choice<string,string> option
        ///The discounts applied to the quote. You can only set up to one discount.
        [<Config.Form>]Discounts: Choice<Create'Discounts list,string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A future timestamp on which the quote will be canceled if in `open` or `draft` status. Measured in seconds since the Unix epoch. If no value is passed, the default expiration date configured in your [quote template settings](https://dashboard.stripe.com/settings/billing/quote) will be used.
        [<Config.Form>]ExpiresAt: DateTime option
        ///A footer that will be displayed on the quote PDF. If no value is passed, the default footer configured in your [quote template settings](https://dashboard.stripe.com/settings/billing/quote) will be used.
        [<Config.Form>]Footer: Choice<string,string> option
        ///Clone an existing quote. The new quote will be created in `status=draft`. When using this parameter, you cannot specify any other parameters except for `expires_at`.
        [<Config.Form>]FromQuote: Create'FromQuote option
        ///A header that will be displayed on the quote PDF. If no value is passed, the default header configured in your [quote template settings](https://dashboard.stripe.com/settings/billing/quote) will be used.
        [<Config.Form>]Header: Choice<string,string> option
        ///All invoices will be billed using the specified settings.
        [<Config.Form>]InvoiceSettings: Create'InvoiceSettings option
        ///A list of line items the customer is being quoted for. Each line item includes information about the product, the quantity, and the resulting cost.
        [<Config.Form>]LineItems: Create'LineItems list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The account on behalf of which to charge.
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///When creating a subscription or subscription schedule, the specified configuration data will be used. There must be at least one line item with a recurring price for a subscription or subscription schedule to be created. A subscription schedule is created if `subscription_data[effective_date]` is present and in the future, otherwise a subscription is created.
        [<Config.Form>]SubscriptionData: Create'SubscriptionData option
        ///ID of the test clock to attach to the quote.
        [<Config.Form>]TestClock: string option
        ///The data with which to automatically create a Transfer for each of the invoices.
        [<Config.Form>]TransferData: Choice<Create'TransferDataTransferDataSpecs,string> option
    }
    with
        static member New(?applicationFeeAmount: Choice<int,string>, ?subscriptionData: Create'SubscriptionData, ?onBehalfOf: Choice<string,string>, ?metadata: Map<string, string>, ?lineItems: Create'LineItems list, ?invoiceSettings: Create'InvoiceSettings, ?header: Choice<string,string>, ?fromQuote: Create'FromQuote, ?footer: Choice<string,string>, ?expiresAt: DateTime, ?expand: string list, ?discounts: Choice<Create'Discounts list,string>, ?description: Choice<string,string>, ?defaultTaxRates: Choice<string list,string>, ?customer: string, ?collectionMethod: Create'CollectionMethod, ?automaticTax: Create'AutomaticTax, ?applicationFeePercent: Choice<decimal,string>, ?testClock: string, ?transferData: Choice<Create'TransferDataTransferDataSpecs,string>) =
            {
                ApplicationFeeAmount = applicationFeeAmount
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                CollectionMethod = collectionMethod
                Customer = customer
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                Expand = expand
                ExpiresAt = expiresAt
                Footer = footer
                FromQuote = fromQuote
                Header = header
                InvoiceSettings = invoiceSettings
                LineItems = lineItems
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                SubscriptionData = subscriptionData
                TestClock = testClock
                TransferData = transferData
            }

    ///<p>A quote models prices and services for a customer. Default options for <code>header</code>, <code>description</code>, <code>footer</code>, and <code>expires_at</code> can be set in the dashboard via the <a href="https://dashboard.stripe.com/settings/billing/quote">quote template</a>.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/quotes"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Quote: string
    }
    with
        static member New(quote: string, ?expand: string list) =
            {
                Expand = expand
                Quote = quote
            }

    ///<p>Retrieves the quote with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/quotes/{options.Quote}"
        |> RestApi.getAsync<Quote> settings qs

    type Update'AutomaticTax = {
        ///Controls whether Stripe will automatically compute tax on the resulting invoices or subscriptions as well as the quote itself.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Update'Discounts = {
        ///ID of the coupon to create a new discount for.
        [<Config.Form>]Coupon: string option
        ///ID of an existing discount on the object (or one of its ancestors) to reuse.
        [<Config.Form>]Discount: string option
    }
    with
        static member New(?coupon: string, ?discount: string) =
            {
                Coupon = coupon
                Discount = discount
            }

    type Update'InvoiceSettings = {
        ///Number of days within which a customer must pay the invoice generated by this quote. This value will be `null` for quotes where `collection_method=charge_automatically`.
        [<Config.Form>]DaysUntilDue: int option
    }
    with
        static member New(?daysUntilDue: int) =
            {
                DaysUntilDue = daysUntilDue
            }

    type Update'LineItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Update'LineItemsPriceDataRecurring = {
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Update'LineItemsPriceDataRecurringInterval option
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Update'LineItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Update'LineItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'LineItemsPriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///The recurring components of a price such as `interval` and `interval_count`.
        [<Config.Form>]Recurring: Update'LineItemsPriceDataRecurring option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Update'LineItemsPriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?recurring: Update'LineItemsPriceDataRecurring, ?taxBehavior: Update'LineItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'LineItems = {
        ///The ID of an existing line item on the quote.
        [<Config.Form>]Id: string option
        ///The ID of the price object. One of `price` or `price_data` is required.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline. One of `price` or `price_data` is required.
        [<Config.Form>]PriceData: Update'LineItemsPriceData option
        ///The quantity of the line item.
        [<Config.Form>]Quantity: int option
        ///The tax rates which apply to the line item. When set, the `default_tax_rates` on the quote do not apply to this line item.
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?id: string, ?price: string, ?priceData: Update'LineItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Id = id
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Update'SubscriptionDataEffectiveDate =
    | CurrentPeriodEnd

    type Update'SubscriptionData = {
        ///The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription.
        [<Config.Form>]Description: Choice<string,string> option
        ///When creating a new subscription, the date of which the subscription schedule will start after the quote is accepted. When updating a subscription, the date of which the subscription will be updated using a subscription schedule. The special value `current_period_end` can be provided to update a subscription at the end of its current period. The `effective_date` is ignored if it is in the past when the quote is accepted.
        [<Config.Form>]EffectiveDate: Choice<Update'SubscriptionDataEffectiveDate,DateTime,string> option
        ///Integer representing the number of trial period days before the customer is charged for the first time.
        [<Config.Form>]TrialPeriodDays: Choice<int,string> option
    }
    with
        static member New(?description: Choice<string,string>, ?effectiveDate: Choice<Update'SubscriptionDataEffectiveDate,DateTime,string>, ?trialPeriodDays: Choice<int,string>) =
            {
                Description = description
                EffectiveDate = effectiveDate
                TrialPeriodDays = trialPeriodDays
            }

    type Update'TransferDataTransferDataSpecs = {
        ///The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred. There cannot be any line items with recurring prices when using this field.
        [<Config.Form>]Amount: int option
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination. There must be at least 1 line item with a recurring price to use this field.
        [<Config.Form>]AmountPercent: decimal option
        ///ID of an existing, connected Stripe account.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amount: int, ?amountPercent: decimal, ?destination: string) =
            {
                Amount = amount
                AmountPercent = amountPercent
                Destination = destination
            }

    type Update'CollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type UpdateOptions = {
        [<Config.Path>]Quote: string
        ///The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. There cannot be any line items with recurring prices when using this field.
        [<Config.Form>]ApplicationFeeAmount: Choice<int,string> option
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. There must be at least 1 line item with a recurring price to use this field.
        [<Config.Form>]ApplicationFeePercent: Choice<decimal,string> option
        ///Settings for automatic tax lookup for this quote and resulting invoices and subscriptions.
        [<Config.Form>]AutomaticTax: Update'AutomaticTax option
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay invoices at the end of the subscription cycle or at invoice finalization using the default payment method attached to the subscription or customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically`.
        [<Config.Form>]CollectionMethod: Update'CollectionMethod option
        ///The customer for which this quote belongs to. A customer is required before finalizing the quote. Once specified, it cannot be changed.
        [<Config.Form>]Customer: string option
        ///The tax rates that will apply to any line item that does not have `tax_rates` set.
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///A description that will be displayed on the quote PDF.
        [<Config.Form>]Description: Choice<string,string> option
        ///The discounts applied to the quote. You can only set up to one discount.
        [<Config.Form>]Discounts: Choice<Update'Discounts list,string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A future timestamp on which the quote will be canceled if in `open` or `draft` status. Measured in seconds since the Unix epoch.
        [<Config.Form>]ExpiresAt: DateTime option
        ///A footer that will be displayed on the quote PDF.
        [<Config.Form>]Footer: Choice<string,string> option
        ///A header that will be displayed on the quote PDF.
        [<Config.Form>]Header: Choice<string,string> option
        ///All invoices will be billed using the specified settings.
        [<Config.Form>]InvoiceSettings: Update'InvoiceSettings option
        ///A list of line items the customer is being quoted for. Each line item includes information about the product, the quantity, and the resulting cost.
        [<Config.Form>]LineItems: Update'LineItems list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The account on behalf of which to charge.
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///When creating a subscription or subscription schedule, the specified configuration data will be used. There must be at least one line item with a recurring price for a subscription or subscription schedule to be created. A subscription schedule is created if `subscription_data[effective_date]` is present and in the future, otherwise a subscription is created.
        [<Config.Form>]SubscriptionData: Update'SubscriptionData option
        ///The data with which to automatically create a Transfer for each of the invoices.
        [<Config.Form>]TransferData: Choice<Update'TransferDataTransferDataSpecs,string> option
    }
    with
        static member New(quote: string, ?onBehalfOf: Choice<string,string>, ?metadata: Map<string, string>, ?lineItems: Update'LineItems list, ?invoiceSettings: Update'InvoiceSettings, ?header: Choice<string,string>, ?footer: Choice<string,string>, ?expiresAt: DateTime, ?subscriptionData: Update'SubscriptionData, ?expand: string list, ?description: Choice<string,string>, ?defaultTaxRates: Choice<string list,string>, ?customer: string, ?collectionMethod: Update'CollectionMethod, ?automaticTax: Update'AutomaticTax, ?applicationFeePercent: Choice<decimal,string>, ?applicationFeeAmount: Choice<int,string>, ?discounts: Choice<Update'Discounts list,string>, ?transferData: Choice<Update'TransferDataTransferDataSpecs,string>) =
            {
                Quote = quote
                ApplicationFeeAmount = applicationFeeAmount
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                CollectionMethod = collectionMethod
                Customer = customer
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                Expand = expand
                ExpiresAt = expiresAt
                Footer = footer
                Header = header
                InvoiceSettings = invoiceSettings
                LineItems = lineItems
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                SubscriptionData = subscriptionData
                TransferData = transferData
            }

    ///<p>A quote models prices and services for a customer.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/quotes/{options.Quote}"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

module QuotesAccept =

    type AcceptOptions = {
        [<Config.Path>]Quote: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(quote: string, ?expand: string list) =
            {
                Quote = quote
                Expand = expand
            }

    ///<p>Accepts the specified quote.</p>
    let Accept settings (options: AcceptOptions) =
        $"/v1/quotes/{options.Quote}/accept"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

module QuotesCancel =

    type CancelOptions = {
        [<Config.Path>]Quote: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(quote: string, ?expand: string list) =
            {
                Quote = quote
                Expand = expand
            }

    ///<p>Cancels the quote.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/quotes/{options.Quote}/cancel"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

module QuotesComputedUpfrontLineItems =

    type ListComputedUpfrontLineItemsOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        [<Config.Path>]Quote: string
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(quote: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Quote = quote
                StartingAfter = startingAfter
            }

    ///<p>When retrieving a quote, there is an includable <a href="https://stripe.com/docs/api/quotes/object#quote_object-computed-upfront-line_items"><strong>computed.upfront.line_items</strong></a> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of upfront line items.</p>
    let ListComputedUpfrontLineItems settings (options: ListComputedUpfrontLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/quotes/{options.Quote}/computed_upfront_line_items"
        |> RestApi.getAsync<Item list> settings qs

module QuotesFinalize =

    type FinalizeQuoteOptions = {
        [<Config.Path>]Quote: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A future timestamp on which the quote will be canceled if in `open` or `draft` status. Measured in seconds since the Unix epoch.
        [<Config.Form>]ExpiresAt: DateTime option
    }
    with
        static member New(quote: string, ?expand: string list, ?expiresAt: DateTime) =
            {
                Quote = quote
                Expand = expand
                ExpiresAt = expiresAt
            }

    ///<p>Finalizes the quote.</p>
    let FinalizeQuote settings (options: FinalizeQuoteOptions) =
        $"/v1/quotes/{options.Quote}/finalize"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

module QuotesLineItems =

    type ListLineItemsOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        [<Config.Path>]Quote: string
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(quote: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Quote = quote
                StartingAfter = startingAfter
            }

    ///<p>When retrieving a quote, there is an includable <strong>line_items</strong> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/quotes/{options.Quote}/line_items"
        |> RestApi.getAsync<Item list> settings qs

module QuotesPdf =

    type PdfOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Quote: string
    }
    with
        static member New(quote: string, ?expand: string list) =
            {
                Expand = expand
                Quote = quote
            }

    ///<p>Download the PDF for a finalized quote</p>
    let Pdf settings (options: PdfOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/quotes/{options.Quote}/pdf"
        |> RestApi.getAsync<string> settings qs

module ShippingRates =

    type ListOptions = {
        ///Only return shipping rates that are active or inactive.
        [<Config.Query>]Active: bool option
        ///A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
        [<Config.Query>]Created: int option
        ///Only return shipping rates for the given currency.
        [<Config.Query>]Currency: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?active: bool, ?created: int, ?currency: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Active = active
                Created = created
                Currency = currency
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of your shipping rates.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("currency", options.Currency |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/shipping_rates"
        |> RestApi.getAsync<ShippingRate list> settings qs

    type Create'DeliveryEstimateMaximumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Create'DeliveryEstimateMaximum = {
        ///A unit of time.
        [<Config.Form>]Unit: Create'DeliveryEstimateMaximumUnit option
        ///Must be greater than 0.
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Create'DeliveryEstimateMaximumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'DeliveryEstimateMinimumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Create'DeliveryEstimateMinimum = {
        ///A unit of time.
        [<Config.Form>]Unit: Create'DeliveryEstimateMinimumUnit option
        ///Must be greater than 0.
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Create'DeliveryEstimateMinimumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'DeliveryEstimate = {
        ///The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.
        [<Config.Form>]Maximum: Create'DeliveryEstimateMaximum option
        ///The lower bound of the estimated range. If empty, represents no lower bound.
        [<Config.Form>]Minimum: Create'DeliveryEstimateMinimum option
    }
    with
        static member New(?maximum: Create'DeliveryEstimateMaximum, ?minimum: Create'DeliveryEstimateMinimum) =
            {
                Maximum = maximum
                Minimum = minimum
            }

    type Create'FixedAmount = {
        ///A non-negative integer in cents representing how much to charge.
        [<Config.Form>]Amount: int option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]CurrencyOptions: Map<string, string> option
    }
    with
        static member New(?amount: int, ?currency: string, ?currencyOptions: Map<string, string>) =
            {
                Amount = amount
                Currency = currency
                CurrencyOptions = currencyOptions
            }

    type Create'TaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'Type =
    | FixedAmount

    type CreateOptions = {
        ///The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.
        [<Config.Form>]DeliveryEstimate: Create'DeliveryEstimate option
        ///The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.
        [<Config.Form>]DisplayName: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.
        [<Config.Form>]FixedAmount: Create'FixedAmount option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.
        [<Config.Form>]TaxBehavior: Create'TaxBehavior option
        ///A [tax code](https://stripe.com/docs/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.
        [<Config.Form>]TaxCode: string option
        ///The type of calculation to use on the shipping rate. Can only be `fixed_amount` for now.
        [<Config.Form>]Type: Create'Type option
    }
    with
        static member New(displayName: string, ?deliveryEstimate: Create'DeliveryEstimate, ?expand: string list, ?fixedAmount: Create'FixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Create'TaxBehavior, ?taxCode: string, ?type': Create'Type) =
            {
                DeliveryEstimate = deliveryEstimate
                DisplayName = displayName
                Expand = expand
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                Type = type'
            }

    ///<p>Creates a new shipping rate object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/shipping_rates"
        |> RestApi.postAsync<_, ShippingRate> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]ShippingRateToken: string
    }
    with
        static member New(shippingRateToken: string, ?expand: string list) =
            {
                Expand = expand
                ShippingRateToken = shippingRateToken
            }

    ///<p>Returns the shipping rate object with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/shipping_rates/{options.ShippingRateToken}"
        |> RestApi.getAsync<ShippingRate> settings qs

    type Update'FixedAmount = {
        ///Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]CurrencyOptions: Map<string, string> option
    }
    with
        static member New(?currencyOptions: Map<string, string>) =
            {
                CurrencyOptions = currencyOptions
            }

    type Update'TaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type UpdateOptions = {
        [<Config.Path>]ShippingRateToken: string
        ///Whether the shipping rate can be used for new purchases. Defaults to `true`.
        [<Config.Form>]Active: bool option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.
        [<Config.Form>]FixedAmount: Update'FixedAmount option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.
        [<Config.Form>]TaxBehavior: Update'TaxBehavior option
    }
    with
        static member New(shippingRateToken: string, ?active: bool, ?expand: string list, ?fixedAmount: Update'FixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Update'TaxBehavior) =
            {
                ShippingRateToken = shippingRateToken
                Active = active
                Expand = expand
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
            }

    ///<p>Updates an existing shipping rate object.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/shipping_rates/{options.ShippingRateToken}"
        |> RestApi.postAsync<_, ShippingRate> settings (Map.empty) options

module SubscriptionItems =

    type ListOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///The ID of the subscription whose items will be retrieved.
        [<Config.Query>]Subscription: string
    }
    with
        static member New(subscription: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Subscription = subscription
            }

    ///<p>Returns a list of your subscription items for a given subscription.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("subscription", options.Subscription |> box)] |> Map.ofList
        $"/v1/subscription_items"
        |> RestApi.getAsync<SubscriptionItem list> settings qs

    type Create'BillingThresholdsItemBillingThresholds = {
        ///Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://stripe.com/docs/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Create'PriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'PriceDataRecurring = {
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Create'PriceDataRecurringInterval option
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'PriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'PriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'PriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///The recurring components of a price such as `interval` and `interval_count`.
        [<Config.Form>]Recurring: Create'PriceDataRecurring option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Create'PriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?recurring: Create'PriceDataRecurring, ?taxBehavior: Create'PriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'PaymentBehavior =
    | AllowIncomplete
    | DefaultIncomplete
    | ErrorIfIncomplete
    | PendingIfIncomplete

    type Create'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type CreateOptions = {
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
        [<Config.Form>]BillingThresholds: Choice<Create'BillingThresholdsItemBillingThresholds,string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://stripe.com/docs/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
        ///Use `default_incomplete` to transition the subscription to `status=past_due` when payment is required and await explicit confirmation of the invoice's payment intent. This allows simpler management of scenarios where additional user actions are needed to pay a subscription’s invoice. Such as failed payments, [SCA regulation](https://stripe.com/docs/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method.
        ///Use `pending_if_incomplete` to update the subscription using [pending updates](https://stripe.com/docs/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://stripe.com/docs/billing/pending-updates-reference#supported-attributes).
        ///Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://stripe.com/docs/upgrades#2019-03-14) to learn more.
        [<Config.Form>]PaymentBehavior: Create'PaymentBehavior option
        ///The identifier of the plan to add to the subscription.
        [<Config.Form>]Plan: string option
        ///The ID of the price object.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        [<Config.Form>]PriceData: Create'PriceData option
        ///Determines how to handle [prorations](https://stripe.com/docs/subscriptions/billing-cycle#prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.
        [<Config.Form>]ProrationBehavior: Create'ProrationBehavior option
        ///If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply the same proration that was previewed with the [upcoming invoice](https://stripe.com/docs/api#retrieve_customer_invoice) endpoint.
        [<Config.Form>]ProrationDate: DateTime option
        ///The quantity you'd like to apply to the subscription item you're creating.
        [<Config.Form>]Quantity: int option
        ///The identifier of the subscription to modify.
        [<Config.Form>]Subscription: string
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(subscription: string, ?billingThresholds: Choice<Create'BillingThresholdsItemBillingThresholds,string>, ?expand: string list, ?metadata: Map<string, string>, ?paymentBehavior: Create'PaymentBehavior, ?plan: string, ?price: string, ?priceData: Create'PriceData, ?prorationBehavior: Create'ProrationBehavior, ?prorationDate: DateTime, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Expand = expand
                Metadata = metadata
                PaymentBehavior = paymentBehavior
                Plan = plan
                Price = price
                PriceData = priceData
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
                Quantity = quantity
                Subscription = subscription
                TaxRates = taxRates
            }

    ///<p>Adds a new item to an existing subscription. No existing items will be changed or replaced.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/subscription_items"
        |> RestApi.postAsync<_, SubscriptionItem> settings (Map.empty) options

    type Delete'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type DeleteOptions = {
        [<Config.Path>]Item: string
        ///Delete all usage for the given subscription item. Allowed only when the current plan's `usage_type` is `metered`.
        [<Config.Form>]ClearUsage: bool option
        ///Determines how to handle [prorations](https://stripe.com/docs/subscriptions/billing-cycle#prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.
        [<Config.Form>]ProrationBehavior: Delete'ProrationBehavior option
        ///If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply the same proration that was previewed with the [upcoming invoice](https://stripe.com/docs/api#retrieve_customer_invoice) endpoint.
        [<Config.Form>]ProrationDate: DateTime option
    }
    with
        static member New(item: string, ?clearUsage: bool, ?prorationBehavior: Delete'ProrationBehavior, ?prorationDate: DateTime) =
            {
                Item = item
                ClearUsage = clearUsage
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
            }

    ///<p>Deletes an item from the subscription. Removing a subscription item from a subscription will not cancel the subscription.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/subscription_items/{options.Item}"
        |> RestApi.deleteAsync<DeletedSubscriptionItem> settings (Map.empty)

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Item: string
    }
    with
        static member New(item: string, ?expand: string list) =
            {
                Expand = expand
                Item = item
            }

    ///<p>Retrieves the subscription item with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/subscription_items/{options.Item}"
        |> RestApi.getAsync<SubscriptionItem> settings qs

    type Update'BillingThresholdsItemBillingThresholds = {
        ///Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://stripe.com/docs/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Update'PriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Update'PriceDataRecurring = {
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Update'PriceDataRecurringInterval option
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Update'PriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Update'PriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'PriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///The recurring components of a price such as `interval` and `interval_count`.
        [<Config.Form>]Recurring: Update'PriceDataRecurring option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Update'PriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?recurring: Update'PriceDataRecurring, ?taxBehavior: Update'PriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'PaymentBehavior =
    | AllowIncomplete
    | DefaultIncomplete
    | ErrorIfIncomplete
    | PendingIfIncomplete

    type Update'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type UpdateOptions = {
        [<Config.Path>]Item: string
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
        [<Config.Form>]BillingThresholds: Choice<Update'BillingThresholdsItemBillingThresholds,string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Indicates if a customer is on or off-session while an invoice payment is attempted.
        [<Config.Form>]OffSession: bool option
        ///Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://stripe.com/docs/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
        ///Use `default_incomplete` to transition the subscription to `status=past_due` when payment is required and await explicit confirmation of the invoice's payment intent. This allows simpler management of scenarios where additional user actions are needed to pay a subscription’s invoice. Such as failed payments, [SCA regulation](https://stripe.com/docs/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method.
        ///Use `pending_if_incomplete` to update the subscription using [pending updates](https://stripe.com/docs/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://stripe.com/docs/billing/pending-updates-reference#supported-attributes).
        ///Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://stripe.com/docs/upgrades#2019-03-14) to learn more.
        [<Config.Form>]PaymentBehavior: Update'PaymentBehavior option
        ///The identifier of the new plan for this subscription item.
        [<Config.Form>]Plan: string option
        ///The ID of the price object. When changing a subscription item's price, `quantity` is set to 1 unless a `quantity` parameter is provided.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        [<Config.Form>]PriceData: Update'PriceData option
        ///Determines how to handle [prorations](https://stripe.com/docs/subscriptions/billing-cycle#prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.
        [<Config.Form>]ProrationBehavior: Update'ProrationBehavior option
        ///If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply the same proration that was previewed with the [upcoming invoice](https://stripe.com/docs/api#retrieve_customer_invoice) endpoint.
        [<Config.Form>]ProrationDate: DateTime option
        ///The quantity you'd like to apply to the subscription item you're creating.
        [<Config.Form>]Quantity: int option
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(item: string, ?billingThresholds: Choice<Update'BillingThresholdsItemBillingThresholds,string>, ?expand: string list, ?metadata: Map<string, string>, ?offSession: bool, ?paymentBehavior: Update'PaymentBehavior, ?plan: string, ?price: string, ?priceData: Update'PriceData, ?prorationBehavior: Update'ProrationBehavior, ?prorationDate: DateTime, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Item = item
                BillingThresholds = billingThresholds
                Expand = expand
                Metadata = metadata
                OffSession = offSession
                PaymentBehavior = paymentBehavior
                Plan = plan
                Price = price
                PriceData = priceData
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
                Quantity = quantity
                TaxRates = taxRates
            }

    ///<p>Updates the plan or quantity of an item on a current subscription.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/subscription_items/{options.Item}"
        |> RestApi.postAsync<_, SubscriptionItem> settings (Map.empty) options

module SubscriptionSchedules =

    type ListOptions = {
        ///Only return subscription schedules that were created canceled the given date interval.
        [<Config.Query>]CanceledAt: int option
        ///Only return subscription schedules that completed during the given date interval.
        [<Config.Query>]CompletedAt: int option
        ///Only return subscription schedules that were created during the given date interval.
        [<Config.Query>]Created: int option
        ///Only return subscription schedules for the given customer.
        [<Config.Query>]Customer: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Only return subscription schedules that were released during the given date interval.
        [<Config.Query>]ReleasedAt: int option
        ///Only return subscription schedules that have not started yet.
        [<Config.Query>]Scheduled: bool option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?canceledAt: int, ?completedAt: int, ?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?releasedAt: int, ?scheduled: bool, ?startingAfter: string) =
            {
                CanceledAt = canceledAt
                CompletedAt = completedAt
                Created = created
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                ReleasedAt = releasedAt
                Scheduled = scheduled
                StartingAfter = startingAfter
            }

    ///<p>Retrieves the list of your subscription schedules.</p>
    let List settings (options: ListOptions) =
        let qs = [("canceled_at", options.CanceledAt |> box); ("completed_at", options.CompletedAt |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("released_at", options.ReleasedAt |> box); ("scheduled", options.Scheduled |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/subscription_schedules"
        |> RestApi.getAsync<SubscriptionSchedule list> settings qs

    type Create'DefaultSettingsAutomaticTax = {
        ///Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'DefaultSettingsBillingThresholdsBillingThresholds = {
        ///Monetary threshold that triggers the subscription to advance to a new billing period
        [<Config.Form>]AmountGte: int option
        ///Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
        [<Config.Form>]ResetBillingCycleAnchor: bool option
    }
    with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Create'DefaultSettingsInvoiceSettings = {
        ///Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `collection_method=charge_automatically`.
        [<Config.Form>]DaysUntilDue: int option
    }
    with
        static member New(?daysUntilDue: int) =
            {
                DaysUntilDue = daysUntilDue
            }

    type Create'DefaultSettingsTransferDataTransferDataSpecs = {
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        [<Config.Form>]AmountPercent: decimal option
        ///ID of an existing, connected Stripe account.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Create'DefaultSettingsBillingCycleAnchor =
    | Automatic
    | PhaseStart

    type Create'DefaultSettingsCollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Create'DefaultSettings = {
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///Default settings for automatic tax computation.
        [<Config.Form>]AutomaticTax: Create'DefaultSettingsAutomaticTax option
        ///Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://stripe.com/docs/billing/subscriptions/billing-cycle).
        [<Config.Form>]BillingCycleAnchor: Create'DefaultSettingsBillingCycleAnchor option
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
        [<Config.Form>]BillingThresholds: Choice<Create'DefaultSettingsBillingThresholdsBillingThresholds,string> option
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.
        [<Config.Form>]CollectionMethod: Create'DefaultSettingsCollectionMethod option
        ///ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
        [<Config.Form>]DefaultPaymentMethod: string option
        ///Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription.
        [<Config.Form>]Description: Choice<string,string> option
        ///All invoices will be billed using the specified settings.
        [<Config.Form>]InvoiceSettings: Create'DefaultSettingsInvoiceSettings option
        ///The account on behalf of which to charge, for each of the associated subscription's invoices.
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///The data with which to automatically create a Transfer for each of the associated subscription's invoices.
        [<Config.Form>]TransferData: Choice<Create'DefaultSettingsTransferDataTransferDataSpecs,string> option
    }
    with
        static member New(?applicationFeePercent: decimal, ?automaticTax: Create'DefaultSettingsAutomaticTax, ?billingCycleAnchor: Create'DefaultSettingsBillingCycleAnchor, ?billingThresholds: Choice<Create'DefaultSettingsBillingThresholdsBillingThresholds,string>, ?collectionMethod: Create'DefaultSettingsCollectionMethod, ?defaultPaymentMethod: string, ?description: Choice<string,string>, ?invoiceSettings: Create'DefaultSettingsInvoiceSettings, ?onBehalfOf: Choice<string,string>, ?transferData: Choice<Create'DefaultSettingsTransferDataTransferDataSpecs,string>) =
            {
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                DefaultPaymentMethod = defaultPaymentMethod
                Description = description
                InvoiceSettings = invoiceSettings
                OnBehalfOf = onBehalfOf
                TransferData = transferData
            }

    type Create'PhasesAddInvoiceItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'PhasesAddInvoiceItemsPriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Create'PhasesAddInvoiceItemsPriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?taxBehavior: Create'PhasesAddInvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'PhasesAddInvoiceItems = {
        ///The ID of the price object.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        [<Config.Form>]PriceData: Create'PhasesAddInvoiceItemsPriceData option
        ///Quantity for this item. Defaults to 1.
        [<Config.Form>]Quantity: int option
        ///The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?price: string, ?priceData: Create'PhasesAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Create'PhasesAutomaticTax = {
        ///Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'PhasesBillingThresholdsBillingThresholds = {
        ///Monetary threshold that triggers the subscription to advance to a new billing period
        [<Config.Form>]AmountGte: int option
        ///Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
        [<Config.Form>]ResetBillingCycleAnchor: bool option
    }
    with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Create'PhasesInvoiceSettings = {
        ///Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `billing=charge_automatically`.
        [<Config.Form>]DaysUntilDue: int option
    }
    with
        static member New(?daysUntilDue: int) =
            {
                DaysUntilDue = daysUntilDue
            }

    type Create'PhasesItemsBillingThresholdsItemBillingThresholds = {
        ///Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://stripe.com/docs/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Create'PhasesItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'PhasesItemsPriceDataRecurring = {
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Create'PhasesItemsPriceDataRecurringInterval option
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'PhasesItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'PhasesItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'PhasesItemsPriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///The recurring components of a price such as `interval` and `interval_count`.
        [<Config.Form>]Recurring: Create'PhasesItemsPriceDataRecurring option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Create'PhasesItemsPriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?recurring: Create'PhasesItemsPriceDataRecurring, ?taxBehavior: Create'PhasesItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'PhasesItems = {
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
        [<Config.Form>]BillingThresholds: Choice<Create'PhasesItemsBillingThresholdsItemBillingThresholds,string> option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to a configuration item. Metadata on a configuration item will update the underlying subscription item's `metadata` when the phase is entered, adding new keys and replacing existing keys. Individual keys in the subscription item's `metadata` can be unset by posting an empty value to them in the configuration item's `metadata`. To unset all keys in the subscription item's `metadata`, update the subscription item directly or unset every key individually from the configuration item's `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The plan ID to subscribe to. You may specify the same ID in `plan` and `price`.
        [<Config.Form>]Plan: string option
        ///The ID of the price object.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        [<Config.Form>]PriceData: Create'PhasesItemsPriceData option
        ///Quantity for the given price. Can be set only if the price's `usage_type` is `licensed` and not `metered`.
        [<Config.Form>]Quantity: int option
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?billingThresholds: Choice<Create'PhasesItemsBillingThresholdsItemBillingThresholds,string>, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: Create'PhasesItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Create'PhasesTransferData = {
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        [<Config.Form>]AmountPercent: decimal option
        ///ID of an existing, connected Stripe account.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Create'PhasesBillingCycleAnchor =
    | Automatic
    | PhaseStart

    type Create'PhasesCollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Create'PhasesProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type Create'Phases = {
        ///A list of prices and quantities that will generate invoice items appended to the next invoice for this phase. You may pass up to 20 items.
        [<Config.Form>]AddInvoiceItems: Create'PhasesAddInvoiceItems list option
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///Automatic tax settings for this phase.
        [<Config.Form>]AutomaticTax: Create'PhasesAutomaticTax option
        ///Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://stripe.com/docs/billing/subscriptions/billing-cycle).
        [<Config.Form>]BillingCycleAnchor: Create'PhasesBillingCycleAnchor option
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
        [<Config.Form>]BillingThresholds: Choice<Create'PhasesBillingThresholdsBillingThresholds,string> option
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.
        [<Config.Form>]CollectionMethod: Create'PhasesCollectionMethod option
        ///The identifier of the coupon to apply to this phase of the subscription schedule.
        [<Config.Form>]Coupon: string option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
        [<Config.Form>]DefaultPaymentMethod: string option
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will set the Subscription's [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates), which means they will be the Invoice's [`default_tax_rates`](https://stripe.com/docs/api/invoices/create#create_invoice-default_tax_rates) for any Invoices issued by the Subscription during this Phase.
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription.
        [<Config.Form>]Description: Choice<string,string> option
        ///The date at which this phase of the subscription schedule ends. If set, `iterations` must not be set.
        [<Config.Form>]EndDate: DateTime option
        ///All invoices will be billed using the specified settings.
        [<Config.Form>]InvoiceSettings: Create'PhasesInvoiceSettings option
        ///List of configuration items, each with an attached price, to apply during this phase of the subscription schedule.
        [<Config.Form>]Items: Create'PhasesItems list option
        ///Integer representing the multiplier applied to the price interval. For example, `iterations=2` applied to a price with `interval=month` and `interval_count=3` results in a phase of duration `2 * 3 months = 6 months`. If set, `end_date` must not be set.
        [<Config.Form>]Iterations: int option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to a phase. Metadata on a schedule's phase will update the underlying subscription's `metadata` when the phase is entered, adding new keys and replacing existing keys in the subscription's `metadata`. Individual keys in the subscription's `metadata` can be unset by posting an empty value to them in the phase's `metadata`. To unset all keys in the subscription's `metadata`, update the subscription directly or unset every key individually from the phase's `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The account on behalf of which to charge, for each of the associated subscription's invoices.
        [<Config.Form>]OnBehalfOf: string option
        ///Whether the subscription schedule will create [prorations](https://stripe.com/docs/billing/subscriptions/prorations) when transitioning to this phase. The default value is `create_prorations`. This setting controls prorations when a phase is started asynchronously and it is persisted as a field on the phase. It's different from the request-level [proration_behavior](https://stripe.com/docs/api/subscription_schedules/update#update_subscription_schedule-proration_behavior) parameter which controls what happens if the update request affects the billing configuration of the current phase.
        [<Config.Form>]ProrationBehavior: Create'PhasesProrationBehavior option
        ///The data with which to automatically create a Transfer for each of the associated subscription's invoices.
        [<Config.Form>]TransferData: Create'PhasesTransferData option
        ///If set to true the entire phase is counted as a trial and the customer will not be charged for any fees.
        [<Config.Form>]Trial: bool option
        ///Sets the phase to trialing from the start date to this date. Must be before the phase end date, can not be combined with `trial`
        [<Config.Form>]TrialEnd: DateTime option
    }
    with
        static member New(?addInvoiceItems: Create'PhasesAddInvoiceItems list, ?transferData: Create'PhasesTransferData, ?prorationBehavior: Create'PhasesProrationBehavior, ?onBehalfOf: string, ?metadata: Map<string, string>, ?iterations: int, ?items: Create'PhasesItems list, ?invoiceSettings: Create'PhasesInvoiceSettings, ?endDate: DateTime, ?trial: bool, ?description: Choice<string,string>, ?defaultPaymentMethod: string, ?currency: string, ?coupon: string, ?collectionMethod: Create'PhasesCollectionMethod, ?billingThresholds: Choice<Create'PhasesBillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: Create'PhasesBillingCycleAnchor, ?automaticTax: Create'PhasesAutomaticTax, ?applicationFeePercent: decimal, ?defaultTaxRates: Choice<string list,string>, ?trialEnd: DateTime) =
            {
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                Coupon = coupon
                Currency = currency
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultTaxRates = defaultTaxRates
                Description = description
                EndDate = endDate
                InvoiceSettings = invoiceSettings
                Items = items
                Iterations = iterations
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                ProrationBehavior = prorationBehavior
                TransferData = transferData
                Trial = trial
                TrialEnd = trialEnd
            }

    type Create'StartDate =
    | Now

    type Create'EndBehavior =
    | Cancel
    | None'
    | Release
    | Renew

    type CreateOptions = {
        ///The identifier of the customer to create the subscription schedule for.
        [<Config.Form>]Customer: string option
        ///Object representing the subscription schedule's default settings.
        [<Config.Form>]DefaultSettings: Create'DefaultSettings option
        ///Behavior of the subscription schedule and underlying subscription when it ends. Possible values are `release` or `cancel` with the default being `release`. `release` will end the subscription schedule and keep the underlying subscription running.`cancel` will end the subscription schedule and cancel the underlying subscription.
        [<Config.Form>]EndBehavior: Create'EndBehavior option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Migrate an existing subscription to be managed by a subscription schedule. If this parameter is set, a subscription schedule will be created using the subscription's item(s), set to auto-renew using the subscription's interval. When using this parameter, other parameters (such as phase values) cannot be set. To create a subscription schedule with other modifications, we recommend making two separate API calls.
        [<Config.Form>]FromSubscription: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///List representing phases of the subscription schedule. Each phase can be customized to have different durations, plans, and coupons. If there are multiple phases, the `end_date` of one phase will always equal the `start_date` of the next phase.
        [<Config.Form>]Phases: Create'Phases list option
        ///When the subscription schedule starts. We recommend using `now` so that it starts the subscription immediately. You can also use a Unix timestamp to backdate the subscription so that it starts on a past date, or set a future date for the subscription to start on.
        [<Config.Form>]StartDate: Choice<int,Create'StartDate> option
    }
    with
        static member New(?customer: string, ?defaultSettings: Create'DefaultSettings, ?endBehavior: Create'EndBehavior, ?expand: string list, ?fromSubscription: string, ?metadata: Map<string, string>, ?phases: Create'Phases list, ?startDate: Choice<int,Create'StartDate>) =
            {
                Customer = customer
                DefaultSettings = defaultSettings
                EndBehavior = endBehavior
                Expand = expand
                FromSubscription = fromSubscription
                Metadata = metadata
                Phases = phases
                StartDate = startDate
            }

    ///<p>Creates a new subscription schedule object. Each customer can have up to 500 active or scheduled subscriptions.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/subscription_schedules"
        |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Schedule: string
    }
    with
        static member New(schedule: string, ?expand: string list) =
            {
                Expand = expand
                Schedule = schedule
            }

    ///<p>Retrieves the details of an existing subscription schedule. You only need to supply the unique subscription schedule identifier that was returned upon subscription schedule creation.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/subscription_schedules/{options.Schedule}"
        |> RestApi.getAsync<SubscriptionSchedule> settings qs

    type Update'DefaultSettingsAutomaticTax = {
        ///Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Update'DefaultSettingsBillingThresholdsBillingThresholds = {
        ///Monetary threshold that triggers the subscription to advance to a new billing period
        [<Config.Form>]AmountGte: int option
        ///Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
        [<Config.Form>]ResetBillingCycleAnchor: bool option
    }
    with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Update'DefaultSettingsInvoiceSettings = {
        ///Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `collection_method=charge_automatically`.
        [<Config.Form>]DaysUntilDue: int option
    }
    with
        static member New(?daysUntilDue: int) =
            {
                DaysUntilDue = daysUntilDue
            }

    type Update'DefaultSettingsTransferDataTransferDataSpecs = {
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        [<Config.Form>]AmountPercent: decimal option
        ///ID of an existing, connected Stripe account.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Update'DefaultSettingsBillingCycleAnchor =
    | Automatic
    | PhaseStart

    type Update'DefaultSettingsCollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Update'DefaultSettings = {
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///Default settings for automatic tax computation.
        [<Config.Form>]AutomaticTax: Update'DefaultSettingsAutomaticTax option
        ///Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://stripe.com/docs/billing/subscriptions/billing-cycle).
        [<Config.Form>]BillingCycleAnchor: Update'DefaultSettingsBillingCycleAnchor option
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
        [<Config.Form>]BillingThresholds: Choice<Update'DefaultSettingsBillingThresholdsBillingThresholds,string> option
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.
        [<Config.Form>]CollectionMethod: Update'DefaultSettingsCollectionMethod option
        ///ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
        [<Config.Form>]DefaultPaymentMethod: string option
        ///Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription.
        [<Config.Form>]Description: Choice<string,string> option
        ///All invoices will be billed using the specified settings.
        [<Config.Form>]InvoiceSettings: Update'DefaultSettingsInvoiceSettings option
        ///The account on behalf of which to charge, for each of the associated subscription's invoices.
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///The data with which to automatically create a Transfer for each of the associated subscription's invoices.
        [<Config.Form>]TransferData: Choice<Update'DefaultSettingsTransferDataTransferDataSpecs,string> option
    }
    with
        static member New(?applicationFeePercent: decimal, ?automaticTax: Update'DefaultSettingsAutomaticTax, ?billingCycleAnchor: Update'DefaultSettingsBillingCycleAnchor, ?billingThresholds: Choice<Update'DefaultSettingsBillingThresholdsBillingThresholds,string>, ?collectionMethod: Update'DefaultSettingsCollectionMethod, ?defaultPaymentMethod: string, ?description: Choice<string,string>, ?invoiceSettings: Update'DefaultSettingsInvoiceSettings, ?onBehalfOf: Choice<string,string>, ?transferData: Choice<Update'DefaultSettingsTransferDataTransferDataSpecs,string>) =
            {
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                DefaultPaymentMethod = defaultPaymentMethod
                Description = description
                InvoiceSettings = invoiceSettings
                OnBehalfOf = onBehalfOf
                TransferData = transferData
            }

    type Update'PhasesAddInvoiceItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'PhasesAddInvoiceItemsPriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Update'PhasesAddInvoiceItemsPriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?taxBehavior: Update'PhasesAddInvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'PhasesAddInvoiceItems = {
        ///The ID of the price object.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        [<Config.Form>]PriceData: Update'PhasesAddInvoiceItemsPriceData option
        ///Quantity for this item. Defaults to 1.
        [<Config.Form>]Quantity: int option
        ///The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?price: string, ?priceData: Update'PhasesAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Update'PhasesAutomaticTax = {
        ///Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Update'PhasesBillingThresholdsBillingThresholds = {
        ///Monetary threshold that triggers the subscription to advance to a new billing period
        [<Config.Form>]AmountGte: int option
        ///Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
        [<Config.Form>]ResetBillingCycleAnchor: bool option
    }
    with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Update'PhasesEndDate =
    | Now

    type Update'PhasesInvoiceSettings = {
        ///Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `billing=charge_automatically`.
        [<Config.Form>]DaysUntilDue: int option
    }
    with
        static member New(?daysUntilDue: int) =
            {
                DaysUntilDue = daysUntilDue
            }

    type Update'PhasesItemsBillingThresholdsItemBillingThresholds = {
        ///Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://stripe.com/docs/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Update'PhasesItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Update'PhasesItemsPriceDataRecurring = {
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Update'PhasesItemsPriceDataRecurringInterval option
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Update'PhasesItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Update'PhasesItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'PhasesItemsPriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///The recurring components of a price such as `interval` and `interval_count`.
        [<Config.Form>]Recurring: Update'PhasesItemsPriceDataRecurring option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Update'PhasesItemsPriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?recurring: Update'PhasesItemsPriceDataRecurring, ?taxBehavior: Update'PhasesItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'PhasesItems = {
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
        [<Config.Form>]BillingThresholds: Choice<Update'PhasesItemsBillingThresholdsItemBillingThresholds,string> option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to a configuration item. Metadata on a configuration item will update the underlying subscription item's `metadata` when the phase is entered, adding new keys and replacing existing keys. Individual keys in the subscription item's `metadata` can be unset by posting an empty value to them in the configuration item's `metadata`. To unset all keys in the subscription item's `metadata`, update the subscription item directly or unset every key individually from the configuration item's `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The plan ID to subscribe to. You may specify the same ID in `plan` and `price`.
        [<Config.Form>]Plan: string option
        ///The ID of the price object.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        [<Config.Form>]PriceData: Update'PhasesItemsPriceData option
        ///Quantity for the given price. Can be set only if the price's `usage_type` is `licensed` and not `metered`.
        [<Config.Form>]Quantity: int option
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?billingThresholds: Choice<Update'PhasesItemsBillingThresholdsItemBillingThresholds,string>, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: Update'PhasesItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Update'PhasesStartDate =
    | Now

    type Update'PhasesTransferData = {
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        [<Config.Form>]AmountPercent: decimal option
        ///ID of an existing, connected Stripe account.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Update'PhasesTrialEnd =
    | Now

    type Update'PhasesBillingCycleAnchor =
    | Automatic
    | PhaseStart

    type Update'PhasesCollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Update'PhasesProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type Update'Phases = {
        ///A list of prices and quantities that will generate invoice items appended to the next invoice for this phase. You may pass up to 20 items.
        [<Config.Form>]AddInvoiceItems: Update'PhasesAddInvoiceItems list option
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///Automatic tax settings for this phase.
        [<Config.Form>]AutomaticTax: Update'PhasesAutomaticTax option
        ///Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://stripe.com/docs/billing/subscriptions/billing-cycle).
        [<Config.Form>]BillingCycleAnchor: Update'PhasesBillingCycleAnchor option
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
        [<Config.Form>]BillingThresholds: Choice<Update'PhasesBillingThresholdsBillingThresholds,string> option
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.
        [<Config.Form>]CollectionMethod: Update'PhasesCollectionMethod option
        ///The identifier of the coupon to apply to this phase of the subscription schedule.
        [<Config.Form>]Coupon: string option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
        [<Config.Form>]DefaultPaymentMethod: string option
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will set the Subscription's [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates), which means they will be the Invoice's [`default_tax_rates`](https://stripe.com/docs/api/invoices/create#create_invoice-default_tax_rates) for any Invoices issued by the Subscription during this Phase.
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription.
        [<Config.Form>]Description: Choice<string,string> option
        ///The date at which this phase of the subscription schedule ends. If set, `iterations` must not be set.
        [<Config.Form>]EndDate: Choice<int,Update'PhasesEndDate> option
        ///All invoices will be billed using the specified settings.
        [<Config.Form>]InvoiceSettings: Update'PhasesInvoiceSettings option
        ///List of configuration items, each with an attached price, to apply during this phase of the subscription schedule.
        [<Config.Form>]Items: Update'PhasesItems list option
        ///Integer representing the multiplier applied to the price interval. For example, `iterations=2` applied to a price with `interval=month` and `interval_count=3` results in a phase of duration `2 * 3 months = 6 months`. If set, `end_date` must not be set.
        [<Config.Form>]Iterations: int option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to a phase. Metadata on a schedule's phase will update the underlying subscription's `metadata` when the phase is entered, adding new keys and replacing existing keys in the subscription's `metadata`. Individual keys in the subscription's `metadata` can be unset by posting an empty value to them in the phase's `metadata`. To unset all keys in the subscription's `metadata`, update the subscription directly or unset every key individually from the phase's `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The account on behalf of which to charge, for each of the associated subscription's invoices.
        [<Config.Form>]OnBehalfOf: string option
        ///Whether the subscription schedule will create [prorations](https://stripe.com/docs/billing/subscriptions/prorations) when transitioning to this phase. The default value is `create_prorations`. This setting controls prorations when a phase is started asynchronously and it is persisted as a field on the phase. It's different from the request-level [proration_behavior](https://stripe.com/docs/api/subscription_schedules/update#update_subscription_schedule-proration_behavior) parameter which controls what happens if the update request affects the billing configuration of the current phase.
        [<Config.Form>]ProrationBehavior: Update'PhasesProrationBehavior option
        ///The date at which this phase of the subscription schedule starts or `now`. Must be set on the first phase.
        [<Config.Form>]StartDate: Choice<int,Update'PhasesStartDate> option
        ///The data with which to automatically create a Transfer for each of the associated subscription's invoices.
        [<Config.Form>]TransferData: Update'PhasesTransferData option
        ///If set to true the entire phase is counted as a trial and the customer will not be charged for any fees.
        [<Config.Form>]Trial: bool option
        ///Sets the phase to trialing from the start date to this date. Must be before the phase end date, can not be combined with `trial`
        [<Config.Form>]TrialEnd: Choice<int,Update'PhasesTrialEnd> option
    }
    with
        static member New(?addInvoiceItems: Update'PhasesAddInvoiceItems list, ?transferData: Update'PhasesTransferData, ?startDate: Choice<int,Update'PhasesStartDate>, ?prorationBehavior: Update'PhasesProrationBehavior, ?onBehalfOf: string, ?metadata: Map<string, string>, ?iterations: int, ?items: Update'PhasesItems list, ?invoiceSettings: Update'PhasesInvoiceSettings, ?endDate: Choice<int,Update'PhasesEndDate>, ?description: Choice<string,string>, ?defaultTaxRates: Choice<string list,string>, ?defaultPaymentMethod: string, ?currency: string, ?coupon: string, ?collectionMethod: Update'PhasesCollectionMethod, ?billingThresholds: Choice<Update'PhasesBillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: Update'PhasesBillingCycleAnchor, ?automaticTax: Update'PhasesAutomaticTax, ?applicationFeePercent: decimal, ?trial: bool, ?trialEnd: Choice<int,Update'PhasesTrialEnd>) =
            {
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                Coupon = coupon
                Currency = currency
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultTaxRates = defaultTaxRates
                Description = description
                EndDate = endDate
                InvoiceSettings = invoiceSettings
                Items = items
                Iterations = iterations
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                ProrationBehavior = prorationBehavior
                StartDate = startDate
                TransferData = transferData
                Trial = trial
                TrialEnd = trialEnd
            }

    type Update'EndBehavior =
    | Cancel
    | None'
    | Release
    | Renew

    type Update'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type UpdateOptions = {
        [<Config.Path>]Schedule: string
        ///Object representing the subscription schedule's default settings.
        [<Config.Form>]DefaultSettings: Update'DefaultSettings option
        ///Behavior of the subscription schedule and underlying subscription when it ends. Possible values are `release` or `cancel` with the default being `release`. `release` will end the subscription schedule and keep the underlying subscription running.`cancel` will end the subscription schedule and cancel the underlying subscription.
        [<Config.Form>]EndBehavior: Update'EndBehavior option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///List representing phases of the subscription schedule. Each phase can be customized to have different durations, plans, and coupons. If there are multiple phases, the `end_date` of one phase will always equal the `start_date` of the next phase. Note that past phases can be omitted.
        [<Config.Form>]Phases: Update'Phases list option
        ///If the update changes the current phase, indicates whether the changes should be prorated. The default value is `create_prorations`.
        [<Config.Form>]ProrationBehavior: Update'ProrationBehavior option
    }
    with
        static member New(schedule: string, ?defaultSettings: Update'DefaultSettings, ?endBehavior: Update'EndBehavior, ?expand: string list, ?metadata: Map<string, string>, ?phases: Update'Phases list, ?prorationBehavior: Update'ProrationBehavior) =
            {
                Schedule = schedule
                DefaultSettings = defaultSettings
                EndBehavior = endBehavior
                Expand = expand
                Metadata = metadata
                Phases = phases
                ProrationBehavior = prorationBehavior
            }

    ///<p>Updates an existing subscription schedule.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/subscription_schedules/{options.Schedule}"
        |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) options

module SubscriptionSchedulesCancel =

    type CancelOptions = {
        [<Config.Path>]Schedule: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///If the subscription schedule is `active`, indicates if a final invoice will be generated that contains any un-invoiced metered usage and new/pending proration invoice items. Defaults to `true`.
        [<Config.Form>]InvoiceNow: bool option
        ///If the subscription schedule is `active`, indicates if the cancellation should be prorated. Defaults to `true`.
        [<Config.Form>]Prorate: bool option
    }
    with
        static member New(schedule: string, ?expand: string list, ?invoiceNow: bool, ?prorate: bool) =
            {
                Schedule = schedule
                Expand = expand
                InvoiceNow = invoiceNow
                Prorate = prorate
            }

    ///<p>Cancels a subscription schedule and its associated subscription immediately (if the subscription schedule has an active subscription). A subscription schedule can only be canceled if its status is <code>not_started</code> or <code>active</code>.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/subscription_schedules/{options.Schedule}/cancel"
        |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) options

module SubscriptionSchedulesRelease =

    type ReleaseOptions = {
        [<Config.Path>]Schedule: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Keep any cancellation on the subscription that the schedule has set
        [<Config.Form>]PreserveCancelDate: bool option
    }
    with
        static member New(schedule: string, ?expand: string list, ?preserveCancelDate: bool) =
            {
                Schedule = schedule
                Expand = expand
                PreserveCancelDate = preserveCancelDate
            }

    ///<p>Releases the subscription schedule immediately, which will stop scheduling of its phases, but leave any existing subscription in place. A schedule can only be released if its status is <code>not_started</code> or <code>active</code>. If the subscription schedule is currently associated with a subscription, releasing it will remove its <code>subscription</code> property and set the subscription’s ID to the <code>released_subscription</code> property.</p>
    let Release settings (options: ReleaseOptions) =
        $"/v1/subscription_schedules/{options.Schedule}/release"
        |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) options

module Subscriptions =

    type ListOptions = {
        ///Filter subscriptions by their automatic tax settings.
        [<Config.Query>]AutomaticTax: Map<string, string> option
        ///The collection method of the subscriptions to retrieve. Either `charge_automatically` or `send_invoice`.
        [<Config.Query>]CollectionMethod: string option
        [<Config.Query>]Created: int option
        [<Config.Query>]CurrentPeriodEnd: int option
        [<Config.Query>]CurrentPeriodStart: int option
        ///The ID of the customer whose subscriptions will be retrieved.
        [<Config.Query>]Customer: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///The ID of the plan whose subscriptions will be retrieved.
        [<Config.Query>]Plan: string option
        ///Filter for subscriptions that contain this recurring price ID.
        [<Config.Query>]Price: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///The status of the subscriptions to retrieve. Passing in a value of `canceled` will return all canceled subscriptions, including those belonging to deleted customers. Pass `ended` to find subscriptions that are canceled and subscriptions that are expired due to [incomplete payment](https://stripe.com/docs/billing/subscriptions/overview#subscription-statuses). Passing in a value of `all` will return subscriptions of all statuses. If no value is supplied, all subscriptions that have not been canceled are returned.
        [<Config.Query>]Status: string option
        ///Filter for subscriptions that are associated with the specified test clock. The response will not include subscriptions with test clocks if this and the customer parameter is not set.
        [<Config.Query>]TestClock: string option
    }
    with
        static member New(?automaticTax: Map<string, string>, ?collectionMethod: string, ?created: int, ?currentPeriodEnd: int, ?currentPeriodStart: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?plan: string, ?price: string, ?startingAfter: string, ?status: string, ?testClock: string) =
            {
                AutomaticTax = automaticTax
                CollectionMethod = collectionMethod
                Created = created
                CurrentPeriodEnd = currentPeriodEnd
                CurrentPeriodStart = currentPeriodStart
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Plan = plan
                Price = price
                StartingAfter = startingAfter
                Status = status
                TestClock = testClock
            }

    ///<p>By default, returns a list of subscriptions that have not been canceled. In order to list canceled subscriptions, specify <code>status=canceled</code>.</p>
    let List settings (options: ListOptions) =
        let qs = [("automatic_tax", options.AutomaticTax |> box); ("collection_method", options.CollectionMethod |> box); ("created", options.Created |> box); ("current_period_end", options.CurrentPeriodEnd |> box); ("current_period_start", options.CurrentPeriodStart |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("plan", options.Plan |> box); ("price", options.Price |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("test_clock", options.TestClock |> box)] |> Map.ofList
        $"/v1/subscriptions"
        |> RestApi.getAsync<Subscription list> settings qs

    type Create'AddInvoiceItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'AddInvoiceItemsPriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Create'AddInvoiceItemsPriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?taxBehavior: Create'AddInvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'AddInvoiceItems = {
        ///The ID of the price object.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        [<Config.Form>]PriceData: Create'AddInvoiceItemsPriceData option
        ///Quantity for this item. Defaults to 1.
        [<Config.Form>]Quantity: int option
        ///The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?price: string, ?priceData: Create'AddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Create'AutomaticTax = {
        ///Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'BillingThresholdsBillingThresholds = {
        ///Monetary threshold that triggers the subscription to advance to a new billing period
        [<Config.Form>]AmountGte: int option
        ///Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
        [<Config.Form>]ResetBillingCycleAnchor: bool option
    }
    with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Create'ItemsBillingThresholdsItemBillingThresholds = {
        ///Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://stripe.com/docs/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Create'ItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'ItemsPriceDataRecurring = {
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Create'ItemsPriceDataRecurringInterval option
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'ItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'ItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'ItemsPriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///The recurring components of a price such as `interval` and `interval_count`.
        [<Config.Form>]Recurring: Create'ItemsPriceDataRecurring option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Create'ItemsPriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?recurring: Create'ItemsPriceDataRecurring, ?taxBehavior: Create'ItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'Items = {
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
        [<Config.Form>]BillingThresholds: Choice<Create'ItemsBillingThresholdsItemBillingThresholds,string> option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Plan ID for this item, as a string.
        [<Config.Form>]Plan: string option
        ///The ID of the price object.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        [<Config.Form>]PriceData: Create'ItemsPriceData option
        ///Quantity for this item.
        [<Config.Form>]Quantity: int option
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?billingThresholds: Choice<Create'ItemsBillingThresholdsItemBillingThresholds,string>, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: Create'ItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType =
    | Business
    | Personal

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions = {
        ///Transaction type of the mandate.
        [<Config.Form>]TransactionType: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
    }
    with
        static member New(?transactionType: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType) =
            {
                TransactionType = transactionType
            }

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions = {
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions, ?verificationMethod: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod) =
            {
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Fr
    | Nl

    type Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions = {
        ///Preferred language of the Bancontact authorization page that the customer is redirected to.
        [<Config.Form>]PreferredLanguage: Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
    }
    with
        static member New(?preferredLanguage: Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions = {
        ///Amount to be charged for future payments.
        [<Config.Form>]Amount: int option
        ///One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
        [<Config.Form>]AmountType: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType option
        ///A description of the mandate or subscription that is meant to be displayed to the customer.
        [<Config.Form>]Description: string option
    }
    with
        static member New(?amount: int, ?amountType: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType, ?description: string) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork =
    | Amex
    | CartesBancaires
    | Diners
    | Discover
    | EftposAu
    | Interac
    | Jcb
    | Mastercard
    | Unionpay
    | Unknown
    | Visa

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure =
    | Any
    | Automatic

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions = {
        ///Configuration options for setting up an eMandate for cards issued in India.
        [<Config.Form>]MandateOptions: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions option
        ///Selected network to process this Subscription on. Depends on the available networks of the card attached to the Subscription. Can be only set confirm-time.
        [<Config.Form>]Network: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork option
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        [<Config.Form>]RequestThreeDSecure: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure option
    }
    with
        static member New(?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions, ?network: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork, ?requestThreeDSecure: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure) =
            {
                MandateOptions = mandateOptions
                Network = network
                RequestThreeDSecure = requestThreeDSecure
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer = {
        ///The desired country code of the bank account information. Permitted values include: `BE`, `DE`, `ES`, `FR`, `IE`, or `NL`.
        [<Config.Form>]Country: string option
    }
    with
        static member New(?country: string) =
            {
                Country = country
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer = {
        ///Configuration for eu_bank_transfer funding type.
        [<Config.Form>]EuBankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option
        ///The bank transfer type that can be used for funding. Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.
        [<Config.Form>]Type: string option
    }
    with
        static member New(?euBankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer, ?type': string) =
            {
                EuBankTransfer = euBankTransfer
                Type = type'
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions = {
        ///Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.
        [<Config.Form>]BankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option
        ///The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
        [<Config.Form>]FundingType: string option
    }
    with
        static member New(?bankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer, ?fundingType: string) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch =
    | Balances

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections = {
        ///The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
        [<Config.Form>]Permissions: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option
        ///List of data features that you would like to retrieve upon account creation.
        [<Config.Form>]Prefetch: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
    }
    with
        static member New(?permissions: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list, ?prefetch: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list) =
            {
                Permissions = permissions
                Prefetch = prefetch
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions = {
        ///Additional fields for Financial Connections Session creation
        [<Config.Form>]FinancialConnections: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?financialConnections: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections, ?verificationMethod: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod) =
            {
                FinancialConnections = financialConnections
                VerificationMethod = verificationMethod
            }

    type Create'PaymentSettingsPaymentMethodOptions = {
        ///This sub-hash contains details about the Canadian pre-authorized debit payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]AcssDebit: Choice<Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option
        ///This sub-hash contains details about the Bancontact payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]Bancontact: Choice<Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option
        ///This sub-hash contains details about the Card payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]Card: Choice<Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions,string> option
        ///This sub-hash contains details about the Bank transfer payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]CustomerBalance: Choice<Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option
        ///This sub-hash contains details about the Konbini payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]Konbini: Choice<string,string> option
        ///This sub-hash contains details about the ACH direct debit payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]UsBankAccount: Choice<Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
    }
    with
        static member New(?acssDebit: Choice<Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string>, ?bancontact: Choice<Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string>, ?card: Choice<Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions,string>, ?customerBalance: Choice<Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string>, ?konbini: Choice<string,string>, ?usBankAccount: Choice<Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string>) =
            {
                AcssDebit = acssDebit
                Bancontact = bancontact
                Card = card
                CustomerBalance = customerBalance
                Konbini = konbini
                UsBankAccount = usBankAccount
            }

    type Create'PaymentSettingsPaymentMethodTypes =
    | AchCreditTransfer
    | AchDebit
    | AcssDebit
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Boleto
    | Card
    | Cashapp
    | CustomerBalance
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Konbini
    | Link
    | Paynow
    | Paypal
    | Promptpay
    | SepaCreditTransfer
    | SepaDebit
    | Sofort
    | UsBankAccount
    | WechatPay

    type Create'PaymentSettingsSaveDefaultPaymentMethod =
    | Off
    | OnSubscription

    type Create'PaymentSettings = {
        ///Payment-method-specific configuration to provide to invoices created by the subscription.
        [<Config.Form>]PaymentMethodOptions: Create'PaymentSettingsPaymentMethodOptions option
        ///The list of payment method types (e.g. card) to provide to the invoice’s PaymentIntent. If not set, Stripe attempts to automatically determine the types to use by looking at the invoice’s default payment method, the subscription’s default payment method, the customer’s default payment method, and your [invoice template settings](https://dashboard.stripe.com/settings/billing/invoice).
        [<Config.Form>]PaymentMethodTypes: Choice<Create'PaymentSettingsPaymentMethodTypes list,string> option
        ///Either `off`, or `on_subscription`. With `on_subscription` Stripe updates `subscription.default_payment_method` when a subscription payment succeeds.
        [<Config.Form>]SaveDefaultPaymentMethod: Create'PaymentSettingsSaveDefaultPaymentMethod option
    }
    with
        static member New(?paymentMethodOptions: Create'PaymentSettingsPaymentMethodOptions, ?paymentMethodTypes: Choice<Create'PaymentSettingsPaymentMethodTypes list,string>, ?saveDefaultPaymentMethod: Create'PaymentSettingsSaveDefaultPaymentMethod) =
            {
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
                SaveDefaultPaymentMethod = saveDefaultPaymentMethod
            }

    type Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams = {
        ///Specifies invoicing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval option
        ///The number of intervals between invoices. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'TransferData = {
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        [<Config.Form>]AmountPercent: decimal option
        ///ID of an existing, connected Stripe account.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Create'TrialEnd =
    | Now

    type Create'TrialSettingsEndBehaviorMissingPaymentMethod =
    | Cancel
    | CreateInvoice
    | Pause

    type Create'TrialSettingsEndBehavior = {
        ///Indicates how the subscription should change when the trial ends if the user did not provide a payment method.
        [<Config.Form>]MissingPaymentMethod: Create'TrialSettingsEndBehaviorMissingPaymentMethod option
    }
    with
        static member New(?missingPaymentMethod: Create'TrialSettingsEndBehaviorMissingPaymentMethod) =
            {
                MissingPaymentMethod = missingPaymentMethod
            }

    type Create'TrialSettings = {
        ///Defines how the subscription should behave when the user's free trial ends.
        [<Config.Form>]EndBehavior: Create'TrialSettingsEndBehavior option
    }
    with
        static member New(?endBehavior: Create'TrialSettingsEndBehavior) =
            {
                EndBehavior = endBehavior
            }

    type Create'CollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Create'PaymentBehavior =
    | AllowIncomplete
    | DefaultIncomplete
    | ErrorIfIncomplete
    | PendingIfIncomplete

    type Create'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type CreateOptions = {
        ///A list of prices and quantities that will generate invoice items appended to the next invoice for this subscription. You may pass up to 20 items.
        [<Config.Form>]AddInvoiceItems: Create'AddInvoiceItems list option
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///Automatic tax settings for this subscription. We recommend you only include this parameter when the existing value is being changed.
        [<Config.Form>]AutomaticTax: Create'AutomaticTax option
        ///For new subscriptions, a past timestamp to backdate the subscription's start date to. If set, the first invoice will contain a proration for the timespan between the start date and the current time. Can be combined with trials and the billing cycle anchor.
        [<Config.Form>]BackdateStartDate: DateTime option
        ///A future timestamp to anchor the subscription's [billing cycle](https://stripe.com/docs/subscriptions/billing-cycle). This is used to determine the date of the first full invoice, and, for plans with `month` or `year` intervals, the day of the month for subsequent invoices. The timestamp is in UTC format.
        [<Config.Form>]BillingCycleAnchor: DateTime option
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
        [<Config.Form>]BillingThresholds: Choice<Create'BillingThresholdsBillingThresholds,string> option
        ///A timestamp at which the subscription should cancel. If set to a date before the current period ends, this will cause a proration if prorations have been enabled using `proration_behavior`. If set during a future period, this will always cause a proration for that period.
        [<Config.Form>]CancelAt: DateTime option
        ///Boolean indicating whether this subscription should cancel at the end of the current period.
        [<Config.Form>]CancelAtPeriodEnd: bool option
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this subscription at the end of the cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically`.
        [<Config.Form>]CollectionMethod: Create'CollectionMethod option
        ///The ID of the coupon to apply to this subscription. A coupon applied to a subscription will only affect invoices created for that particular subscription.
        [<Config.Form>]Coupon: string option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The identifier of the customer to subscribe.
        [<Config.Form>]Customer: string
        ///Number of days a customer has to pay invoices generated by this subscription. Valid only for subscriptions where `collection_method` is set to `send_invoice`.
        [<Config.Form>]DaysUntilDue: int option
        ///ID of the default payment method for the subscription. It must belong to the customer associated with the subscription. This takes precedence over `default_source`. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://stripe.com/docs/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://stripe.com/docs/api/customers/object#customer_object-default_source).
        [<Config.Form>]DefaultPaymentMethod: string option
        ///ID of the default payment source for the subscription. It must belong to the customer associated with the subscription and be in a chargeable state. If `default_payment_method` is also set, `default_payment_method` will take precedence. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://stripe.com/docs/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://stripe.com/docs/api/customers/object#customer_object-default_source).
        [<Config.Form>]DefaultSource: string option
        ///The tax rates that will apply to any subscription item that does not have `tax_rates` set. Invoices created will have their `default_tax_rates` populated from the subscription.
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A list of up to 20 subscription items, each with an attached price.
        [<Config.Form>]Items: Create'Items list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Indicates if a customer is on or off-session while an invoice payment is attempted.
        [<Config.Form>]OffSession: bool option
        ///The account on behalf of which to charge, for each of the subscription's invoices.
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///Only applies to subscriptions with `collection_method=charge_automatically`.
        ///Use `allow_incomplete` to create subscriptions with `status=incomplete` if the first invoice cannot be paid. Creating subscriptions with this status allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://stripe.com/docs/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
        ///Use `default_incomplete` to create Subscriptions with `status=incomplete` when the first invoice requires payment, otherwise start as active. Subscriptions transition to `status=active` when successfully confirming the payment intent on the first invoice. This allows simpler management of scenarios where additional user actions are needed to pay a subscription’s invoice. Such as failed payments, [SCA regulation](https://stripe.com/docs/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method. If the payment intent is not confirmed within 23 hours subscriptions transition to `status=incomplete_expired`, which is a terminal state.
        ///Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's first invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not create a subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://stripe.com/docs/upgrades#2019-03-14) to learn more.
        ///`pending_if_incomplete` is only used with updates and cannot be passed when creating a subscription.
        ///Subscriptions with `collection_method=send_invoice` are automatically activated regardless of the first invoice status.
        [<Config.Form>]PaymentBehavior: Create'PaymentBehavior option
        ///Payment settings to pass to invoices created by the subscription.
        [<Config.Form>]PaymentSettings: Create'PaymentSettings option
        ///Specifies an interval for how often to bill for any pending invoice items. It is analogous to calling [Create an invoice](https://stripe.com/docs/api#create_invoice) for the given subscription at the specified interval.
        [<Config.Form>]PendingInvoiceItemInterval: Choice<Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string> option
        ///The API ID of a promotion code to apply to this subscription. A promotion code applied to a subscription will only affect invoices created for that particular subscription.
        [<Config.Form>]PromotionCode: string option
        ///Determines how to handle [prorations](https://stripe.com/docs/subscriptions/billing-cycle#prorations) resulting from the `billing_cycle_anchor`. If no value is passed, the default is `create_prorations`.
        [<Config.Form>]ProrationBehavior: Create'ProrationBehavior option
        ///If specified, the funds from the subscription's invoices will be transferred to the destination and the ID of the resulting transfers will be found on the resulting charges.
        [<Config.Form>]TransferData: Create'TransferData option
        ///Unix timestamp representing the end of the trial period the customer will get before being charged for the first time. If set, trial_end will override the default trial period of the plan the customer is being subscribed to. The special value `now` can be provided to end the customer's trial immediately. Can be at most two years from `billing_cycle_anchor`. See [Using trial periods on subscriptions](https://stripe.com/docs/billing/subscriptions/trials) to learn more.
        [<Config.Form>]TrialEnd: Choice<Create'TrialEnd,DateTime> option
        ///Indicates if a plan's `trial_period_days` should be applied to the subscription. Setting `trial_end` per subscription is preferred, and this defaults to `false`. Setting this flag to `true` together with `trial_end` is not allowed. See [Using trial periods on subscriptions](https://stripe.com/docs/billing/subscriptions/trials) to learn more.
        [<Config.Form>]TrialFromPlan: bool option
        ///Integer representing the number of trial period days before the customer is charged for the first time. This will always overwrite any trials that might apply via a subscribed plan. See [Using trial periods on subscriptions](https://stripe.com/docs/billing/subscriptions/trials) to learn more.
        [<Config.Form>]TrialPeriodDays: int option
        ///Settings related to subscription trials.
        [<Config.Form>]TrialSettings: Create'TrialSettings option
    }
    with
        static member New(customer: string, ?addInvoiceItems: Create'AddInvoiceItems list, ?trialFromPlan: bool, ?trialEnd: Choice<Create'TrialEnd,DateTime>, ?transferData: Create'TransferData, ?prorationBehavior: Create'ProrationBehavior, ?promotionCode: string, ?pendingInvoiceItemInterval: Choice<Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string>, ?paymentSettings: Create'PaymentSettings, ?paymentBehavior: Create'PaymentBehavior, ?onBehalfOf: Choice<string,string>, ?offSession: bool, ?metadata: Map<string, string>, ?items: Create'Items list, ?expand: string list, ?description: string, ?defaultTaxRates: Choice<string list,string>, ?defaultSource: string, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?currency: string, ?coupon: string, ?collectionMethod: Create'CollectionMethod, ?cancelAtPeriodEnd: bool, ?cancelAt: DateTime, ?billingThresholds: Choice<Create'BillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: DateTime, ?backdateStartDate: DateTime, ?automaticTax: Create'AutomaticTax, ?applicationFeePercent: decimal, ?trialPeriodDays: int, ?trialSettings: Create'TrialSettings) =
            {
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BackdateStartDate = backdateStartDate
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CancelAt = cancelAt
                CancelAtPeriodEnd = cancelAtPeriodEnd
                CollectionMethod = collectionMethod
                Coupon = coupon
                Currency = currency
                Customer = customer
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Description = description
                Expand = expand
                Items = items
                Metadata = metadata
                OffSession = offSession
                OnBehalfOf = onBehalfOf
                PaymentBehavior = paymentBehavior
                PaymentSettings = paymentSettings
                PendingInvoiceItemInterval = pendingInvoiceItemInterval
                PromotionCode = promotionCode
                ProrationBehavior = prorationBehavior
                TransferData = transferData
                TrialEnd = trialEnd
                TrialFromPlan = trialFromPlan
                TrialPeriodDays = trialPeriodDays
                TrialSettings = trialSettings
            }

    ///<p>Creates a new subscription on an existing customer. Each customer can have up to 500 active or scheduled subscriptions.
    ///When you create a subscription with <code>collection_method=charge_automatically</code>, the first invoice is finalized as part of the request.
    ///The <code>payment_behavior</code> parameter determines the exact behavior of the initial payment.
    ///To start subscriptions where the first invoice always begins in a <code>draft</code> status, use <a href="/docs/billing/subscriptions/subscription-schedules#managing">subscription schedules</a> instead.
    ///Schedules provide the flexibility to model more complex billing configurations that change over time.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/subscriptions"
        |> RestApi.postAsync<_, Subscription> settings (Map.empty) options

    type Cancel'CancellationDetailsFeedback =
    | CustomerService
    | LowQuality
    | MissingFeatures
    | Other
    | SwitchedService
    | TooComplex
    | TooExpensive
    | Unused

    type Cancel'CancellationDetails = {
        ///Additional comments about why the user canceled the subscription, if the subscription was cancelled explicitly by the user.
        [<Config.Form>]Comment: Choice<string,string> option
        ///The customer submitted reason for why they cancelled, if the subscription was cancelled explicitly by the user.
        [<Config.Form>]Feedback: Cancel'CancellationDetailsFeedback option
    }
    with
        static member New(?comment: Choice<string,string>, ?feedback: Cancel'CancellationDetailsFeedback) =
            {
                Comment = comment
                Feedback = feedback
            }

    type CancelOptions = {
        [<Config.Path>]SubscriptionExposedId: string
        ///Details about why this subscription was cancelled
        [<Config.Form>]CancellationDetails: Cancel'CancellationDetails option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Will generate a final invoice that invoices for any un-invoiced metered usage and new/pending proration invoice items.
        [<Config.Form>]InvoiceNow: bool option
        ///Will generate a proration invoice item that credits remaining unused time until the subscription period end.
        [<Config.Form>]Prorate: bool option
    }
    with
        static member New(subscriptionExposedId: string, ?cancellationDetails: Cancel'CancellationDetails, ?expand: string list, ?invoiceNow: bool, ?prorate: bool) =
            {
                SubscriptionExposedId = subscriptionExposedId
                CancellationDetails = cancellationDetails
                Expand = expand
                InvoiceNow = invoiceNow
                Prorate = prorate
            }

    ///<p>Cancels a customer’s subscription immediately. The customer will not be charged again for the subscription.
    ///Note, however, that any pending invoice items that you’ve created will still be charged for at the end of the period, unless manually <a href="#delete_invoiceitem">deleted</a>. If you’ve set the subscription to cancel at the end of the period, any pending prorations will also be left in place and collected at the end of the period. But if the subscription is set to cancel immediately, pending prorations will be removed.
    ///By default, upon subscription cancellation, Stripe will stop automatic collection of all finalized invoices for the customer. This is intended to prevent unexpected payment attempts after the customer has canceled a subscription. However, you can resume automatic collection of the invoices manually after subscription cancellation to have us proceed. Or, you could check for unpaid invoices before allowing the customer to cancel the subscription at all.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/subscriptions/{options.SubscriptionExposedId}"
        |> RestApi.deleteAsync<Subscription> settings (Map.empty)

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]SubscriptionExposedId: string
    }
    with
        static member New(subscriptionExposedId: string, ?expand: string list) =
            {
                Expand = expand
                SubscriptionExposedId = subscriptionExposedId
            }

    ///<p>Retrieves the subscription with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/subscriptions/{options.SubscriptionExposedId}"
        |> RestApi.getAsync<Subscription> settings qs

    type Update'AddInvoiceItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'AddInvoiceItemsPriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Update'AddInvoiceItemsPriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?taxBehavior: Update'AddInvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'AddInvoiceItems = {
        ///The ID of the price object.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        [<Config.Form>]PriceData: Update'AddInvoiceItemsPriceData option
        ///Quantity for this item. Defaults to 1.
        [<Config.Form>]Quantity: int option
        ///The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?price: string, ?priceData: Update'AddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Update'AutomaticTax = {
        ///Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Update'BillingThresholdsBillingThresholds = {
        ///Monetary threshold that triggers the subscription to advance to a new billing period
        [<Config.Form>]AmountGte: int option
        ///Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
        [<Config.Form>]ResetBillingCycleAnchor: bool option
    }
    with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Update'CancellationDetailsFeedback =
    | CustomerService
    | LowQuality
    | MissingFeatures
    | Other
    | SwitchedService
    | TooComplex
    | TooExpensive
    | Unused

    type Update'CancellationDetails = {
        ///Additional comments about why the user canceled the subscription, if the subscription was cancelled explicitly by the user.
        [<Config.Form>]Comment: Choice<string,string> option
        ///The customer submitted reason for why they cancelled, if the subscription was cancelled explicitly by the user.
        [<Config.Form>]Feedback: Update'CancellationDetailsFeedback option
    }
    with
        static member New(?comment: Choice<string,string>, ?feedback: Update'CancellationDetailsFeedback) =
            {
                Comment = comment
                Feedback = feedback
            }

    type Update'ItemsBillingThresholdsItemBillingThresholds = {
        ///Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://stripe.com/docs/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Update'ItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Update'ItemsPriceDataRecurring = {
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Update'ItemsPriceDataRecurringInterval option
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Update'ItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Update'ItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'ItemsPriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of the product that this price will belong to.
        [<Config.Form>]Product: string option
        ///The recurring components of a price such as `interval` and `interval_count`.
        [<Config.Form>]Recurring: Update'ItemsPriceDataRecurring option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Update'ItemsPriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?product: string, ?recurring: Update'ItemsPriceDataRecurring, ?taxBehavior: Update'ItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'Items = {
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.
        [<Config.Form>]BillingThresholds: Choice<Update'ItemsBillingThresholdsItemBillingThresholds,string> option
        ///Delete all usage for a given subscription item. Allowed only when `deleted` is set to `true` and the current plan's `usage_type` is `metered`.
        [<Config.Form>]ClearUsage: bool option
        ///A flag that, if set to `true`, will delete the specified item.
        [<Config.Form>]Deleted: bool option
        ///Subscription item to update.
        [<Config.Form>]Id: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Plan ID for this item, as a string.
        [<Config.Form>]Plan: string option
        ///The ID of the price object. When changing a subscription item's price, `quantity` is set to 1 unless a `quantity` parameter is provided.
        [<Config.Form>]Price: string option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object inline.
        [<Config.Form>]PriceData: Update'ItemsPriceData option
        ///Quantity for this item.
        [<Config.Form>]Quantity: int option
        ///A list of [Tax Rate](https://stripe.com/docs/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://stripe.com/docs/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?billingThresholds: Choice<Update'ItemsBillingThresholdsItemBillingThresholds,string>, ?clearUsage: bool, ?deleted: bool, ?id: string, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: Update'ItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                ClearUsage = clearUsage
                Deleted = deleted
                Id = id
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Update'PauseCollectionPauseCollectionBehavior =
    | KeepAsDraft
    | MarkUncollectible
    | Void

    type Update'PauseCollectionPauseCollection = {
        ///The payment collection behavior for this subscription while paused. One of `keep_as_draft`, `mark_uncollectible`, or `void`.
        [<Config.Form>]Behavior: Update'PauseCollectionPauseCollectionBehavior option
        ///The time after which the subscription will resume collecting payments.
        [<Config.Form>]ResumesAt: DateTime option
    }
    with
        static member New(?behavior: Update'PauseCollectionPauseCollectionBehavior, ?resumesAt: DateTime) =
            {
                Behavior = behavior
                ResumesAt = resumesAt
            }

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType =
    | Business
    | Personal

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions = {
        ///Transaction type of the mandate.
        [<Config.Form>]TransactionType: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
    }
    with
        static member New(?transactionType: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType) =
            {
                TransactionType = transactionType
            }

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions = {
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions, ?verificationMethod: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod) =
            {
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Fr
    | Nl

    type Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions = {
        ///Preferred language of the Bancontact authorization page that the customer is redirected to.
        [<Config.Form>]PreferredLanguage: Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
    }
    with
        static member New(?preferredLanguage: Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions = {
        ///Amount to be charged for future payments.
        [<Config.Form>]Amount: int option
        ///One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
        [<Config.Form>]AmountType: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType option
        ///A description of the mandate or subscription that is meant to be displayed to the customer.
        [<Config.Form>]Description: string option
    }
    with
        static member New(?amount: int, ?amountType: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType, ?description: string) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork =
    | Amex
    | CartesBancaires
    | Diners
    | Discover
    | EftposAu
    | Interac
    | Jcb
    | Mastercard
    | Unionpay
    | Unknown
    | Visa

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure =
    | Any
    | Automatic

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions = {
        ///Configuration options for setting up an eMandate for cards issued in India.
        [<Config.Form>]MandateOptions: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions option
        ///Selected network to process this Subscription on. Depends on the available networks of the card attached to the Subscription. Can be only set confirm-time.
        [<Config.Form>]Network: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork option
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        [<Config.Form>]RequestThreeDSecure: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure option
    }
    with
        static member New(?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions, ?network: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork, ?requestThreeDSecure: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure) =
            {
                MandateOptions = mandateOptions
                Network = network
                RequestThreeDSecure = requestThreeDSecure
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer = {
        ///The desired country code of the bank account information. Permitted values include: `BE`, `DE`, `ES`, `FR`, `IE`, or `NL`.
        [<Config.Form>]Country: string option
    }
    with
        static member New(?country: string) =
            {
                Country = country
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer = {
        ///Configuration for eu_bank_transfer funding type.
        [<Config.Form>]EuBankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option
        ///The bank transfer type that can be used for funding. Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.
        [<Config.Form>]Type: string option
    }
    with
        static member New(?euBankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer, ?type': string) =
            {
                EuBankTransfer = euBankTransfer
                Type = type'
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions = {
        ///Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.
        [<Config.Form>]BankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option
        ///The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
        [<Config.Form>]FundingType: string option
    }
    with
        static member New(?bankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer, ?fundingType: string) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch =
    | Balances

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections = {
        ///The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
        [<Config.Form>]Permissions: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option
        ///List of data features that you would like to retrieve upon account creation.
        [<Config.Form>]Prefetch: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
    }
    with
        static member New(?permissions: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list, ?prefetch: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list) =
            {
                Permissions = permissions
                Prefetch = prefetch
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions = {
        ///Additional fields for Financial Connections Session creation
        [<Config.Form>]FinancialConnections: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?financialConnections: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections, ?verificationMethod: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod) =
            {
                FinancialConnections = financialConnections
                VerificationMethod = verificationMethod
            }

    type Update'PaymentSettingsPaymentMethodOptions = {
        ///This sub-hash contains details about the Canadian pre-authorized debit payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]AcssDebit: Choice<Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option
        ///This sub-hash contains details about the Bancontact payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]Bancontact: Choice<Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option
        ///This sub-hash contains details about the Card payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]Card: Choice<Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions,string> option
        ///This sub-hash contains details about the Bank transfer payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]CustomerBalance: Choice<Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option
        ///This sub-hash contains details about the Konbini payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]Konbini: Choice<string,string> option
        ///This sub-hash contains details about the ACH direct debit payment method options to pass to the invoice’s PaymentIntent.
        [<Config.Form>]UsBankAccount: Choice<Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
    }
    with
        static member New(?acssDebit: Choice<Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string>, ?bancontact: Choice<Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string>, ?card: Choice<Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions,string>, ?customerBalance: Choice<Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string>, ?konbini: Choice<string,string>, ?usBankAccount: Choice<Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string>) =
            {
                AcssDebit = acssDebit
                Bancontact = bancontact
                Card = card
                CustomerBalance = customerBalance
                Konbini = konbini
                UsBankAccount = usBankAccount
            }

    type Update'PaymentSettingsPaymentMethodTypes =
    | AchCreditTransfer
    | AchDebit
    | AcssDebit
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Boleto
    | Card
    | Cashapp
    | CustomerBalance
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Konbini
    | Link
    | Paynow
    | Paypal
    | Promptpay
    | SepaCreditTransfer
    | SepaDebit
    | Sofort
    | UsBankAccount
    | WechatPay

    type Update'PaymentSettingsSaveDefaultPaymentMethod =
    | Off
    | OnSubscription

    type Update'PaymentSettings = {
        ///Payment-method-specific configuration to provide to invoices created by the subscription.
        [<Config.Form>]PaymentMethodOptions: Update'PaymentSettingsPaymentMethodOptions option
        ///The list of payment method types (e.g. card) to provide to the invoice’s PaymentIntent. If not set, Stripe attempts to automatically determine the types to use by looking at the invoice’s default payment method, the subscription’s default payment method, the customer’s default payment method, and your [invoice template settings](https://dashboard.stripe.com/settings/billing/invoice).
        [<Config.Form>]PaymentMethodTypes: Choice<Update'PaymentSettingsPaymentMethodTypes list,string> option
        ///Either `off`, or `on_subscription`. With `on_subscription` Stripe updates `subscription.default_payment_method` when a subscription payment succeeds.
        [<Config.Form>]SaveDefaultPaymentMethod: Update'PaymentSettingsSaveDefaultPaymentMethod option
    }
    with
        static member New(?paymentMethodOptions: Update'PaymentSettingsPaymentMethodOptions, ?paymentMethodTypes: Choice<Update'PaymentSettingsPaymentMethodTypes list,string>, ?saveDefaultPaymentMethod: Update'PaymentSettingsSaveDefaultPaymentMethod) =
            {
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
                SaveDefaultPaymentMethod = saveDefaultPaymentMethod
            }

    type Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval =
    | Day
    | Month
    | Week
    | Year

    type Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams = {
        ///Specifies invoicing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval option
        ///The number of intervals between invoices. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Update'TransferDataTransferDataSpecs = {
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
        [<Config.Form>]AmountPercent: decimal option
        ///ID of an existing, connected Stripe account.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Update'TrialEnd =
    | Now

    type Update'TrialSettingsEndBehaviorMissingPaymentMethod =
    | Cancel
    | CreateInvoice
    | Pause

    type Update'TrialSettingsEndBehavior = {
        ///Indicates how the subscription should change when the trial ends if the user did not provide a payment method.
        [<Config.Form>]MissingPaymentMethod: Update'TrialSettingsEndBehaviorMissingPaymentMethod option
    }
    with
        static member New(?missingPaymentMethod: Update'TrialSettingsEndBehaviorMissingPaymentMethod) =
            {
                MissingPaymentMethod = missingPaymentMethod
            }

    type Update'TrialSettings = {
        ///Defines how the subscription should behave when the user's free trial ends.
        [<Config.Form>]EndBehavior: Update'TrialSettingsEndBehavior option
    }
    with
        static member New(?endBehavior: Update'TrialSettingsEndBehavior) =
            {
                EndBehavior = endBehavior
            }

    type Update'BillingCycleAnchor =
    | Now
    | Unchanged

    type Update'CollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Update'PaymentBehavior =
    | AllowIncomplete
    | DefaultIncomplete
    | ErrorIfIncomplete
    | PendingIfIncomplete

    type Update'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type UpdateOptions = {
        [<Config.Path>]SubscriptionExposedId: string
        ///A list of prices and quantities that will generate invoice items appended to the next invoice for this subscription. You may pass up to 20 items.
        [<Config.Form>]AddInvoiceItems: Update'AddInvoiceItems list option
        ///A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///Automatic tax settings for this subscription. We recommend you only include this parameter when the existing value is being changed.
        [<Config.Form>]AutomaticTax: Update'AutomaticTax option
        ///Either `now` or `unchanged`. Setting the value to `now` resets the subscription's billing cycle anchor to the current time (in UTC). For more information, see the billing cycle [documentation](https://stripe.com/docs/billing/subscriptions/billing-cycle).
        [<Config.Form>]BillingCycleAnchor: Update'BillingCycleAnchor option
        ///Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
        [<Config.Form>]BillingThresholds: Choice<Update'BillingThresholdsBillingThresholds,string> option
        ///A timestamp at which the subscription should cancel. If set to a date before the current period ends, this will cause a proration if prorations have been enabled using `proration_behavior`. If set during a future period, this will always cause a proration for that period.
        [<Config.Form>]CancelAt: Choice<DateTime,string> option
        ///Boolean indicating whether this subscription should cancel at the end of the current period.
        [<Config.Form>]CancelAtPeriodEnd: bool option
        ///Details about why this subscription was cancelled
        [<Config.Form>]CancellationDetails: Update'CancellationDetails option
        ///Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this subscription at the end of the cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically`.
        [<Config.Form>]CollectionMethod: Update'CollectionMethod option
        ///The ID of the coupon to apply to this subscription. A coupon applied to a subscription will only affect invoices created for that particular subscription.
        [<Config.Form>]Coupon: string option
        ///Number of days a customer has to pay invoices generated by this subscription. Valid only for subscriptions where `collection_method` is set to `send_invoice`.
        [<Config.Form>]DaysUntilDue: int option
        ///ID of the default payment method for the subscription. It must belong to the customer associated with the subscription. This takes precedence over `default_source`. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://stripe.com/docs/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://stripe.com/docs/api/customers/object#customer_object-default_source).
        [<Config.Form>]DefaultPaymentMethod: string option
        ///ID of the default payment source for the subscription. It must belong to the customer associated with the subscription and be in a chargeable state. If `default_payment_method` is also set, `default_payment_method` will take precedence. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://stripe.com/docs/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://stripe.com/docs/api/customers/object#customer_object-default_source).
        [<Config.Form>]DefaultSource: Choice<string,string> option
        ///The tax rates that will apply to any subscription item that does not have `tax_rates` set. Invoices created will have their `default_tax_rates` populated from the subscription. Pass an empty string to remove previously-defined tax rates.
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces.
        [<Config.Form>]Description: Choice<string,string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A list of up to 20 subscription items, each with an attached price.
        [<Config.Form>]Items: Update'Items list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Indicates if a customer is on or off-session while an invoice payment is attempted.
        [<Config.Form>]OffSession: bool option
        ///The account on behalf of which to charge, for each of the subscription's invoices.
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///If specified, payment collection for this subscription will be paused.
        [<Config.Form>]PauseCollection: Choice<Update'PauseCollectionPauseCollection,string> option
        ///Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://stripe.com/docs/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
        ///Use `default_incomplete` to transition the subscription to `status=past_due` when payment is required and await explicit confirmation of the invoice's payment intent. This allows simpler management of scenarios where additional user actions are needed to pay a subscription’s invoice. Such as failed payments, [SCA regulation](https://stripe.com/docs/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method.
        ///Use `pending_if_incomplete` to update the subscription using [pending updates](https://stripe.com/docs/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://stripe.com/docs/billing/pending-updates-reference#supported-attributes).
        ///Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://stripe.com/docs/upgrades#2019-03-14) to learn more.
        [<Config.Form>]PaymentBehavior: Update'PaymentBehavior option
        ///Payment settings to pass to invoices created by the subscription.
        [<Config.Form>]PaymentSettings: Update'PaymentSettings option
        ///Specifies an interval for how often to bill for any pending invoice items. It is analogous to calling [Create an invoice](https://stripe.com/docs/api#create_invoice) for the given subscription at the specified interval.
        [<Config.Form>]PendingInvoiceItemInterval: Choice<Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string> option
        ///The promotion code to apply to this subscription. A promotion code applied to a subscription will only affect invoices created for that particular subscription.
        [<Config.Form>]PromotionCode: string option
        ///Determines how to handle [prorations](https://stripe.com/docs/subscriptions/billing-cycle#prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.
        [<Config.Form>]ProrationBehavior: Update'ProrationBehavior option
        ///If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply exactly the same proration that was previewed with [upcoming invoice](https://stripe.com/docs/api#upcoming_invoice) endpoint. It can also be used to implement custom proration logic, such as prorating by day instead of by second, by providing the time that you wish to use for proration calculations.
        [<Config.Form>]ProrationDate: DateTime option
        ///If specified, the funds from the subscription's invoices will be transferred to the destination and the ID of the resulting transfers will be found on the resulting charges. This will be unset if you POST an empty value.
        [<Config.Form>]TransferData: Choice<Update'TransferDataTransferDataSpecs,string> option
        ///Unix timestamp representing the end of the trial period the customer will get before being charged for the first time. This will always overwrite any trials that might apply via a subscribed plan. If set, trial_end will override the default trial period of the plan the customer is being subscribed to. The special value `now` can be provided to end the customer's trial immediately. Can be at most two years from `billing_cycle_anchor`.
        [<Config.Form>]TrialEnd: Choice<Update'TrialEnd,DateTime> option
        ///Indicates if a plan's `trial_period_days` should be applied to the subscription. Setting `trial_end` per subscription is preferred, and this defaults to `false`. Setting this flag to `true` together with `trial_end` is not allowed. See [Using trial periods on subscriptions](https://stripe.com/docs/billing/subscriptions/trials) to learn more.
        [<Config.Form>]TrialFromPlan: bool option
        ///Settings related to subscription trials.
        [<Config.Form>]TrialSettings: Update'TrialSettings option
    }
    with
        static member New(subscriptionExposedId: string, ?trialEnd: Choice<Update'TrialEnd,DateTime>, ?transferData: Choice<Update'TransferDataTransferDataSpecs,string>, ?prorationDate: DateTime, ?prorationBehavior: Update'ProrationBehavior, ?promotionCode: string, ?pendingInvoiceItemInterval: Choice<Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string>, ?paymentSettings: Update'PaymentSettings, ?paymentBehavior: Update'PaymentBehavior, ?pauseCollection: Choice<Update'PauseCollectionPauseCollection,string>, ?onBehalfOf: Choice<string,string>, ?offSession: bool, ?metadata: Map<string, string>, ?items: Update'Items list, ?expand: string list, ?description: Choice<string,string>, ?defaultTaxRates: Choice<string list,string>, ?defaultSource: Choice<string,string>, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?coupon: string, ?collectionMethod: Update'CollectionMethod, ?cancellationDetails: Update'CancellationDetails, ?cancelAtPeriodEnd: bool, ?cancelAt: Choice<DateTime,string>, ?billingThresholds: Choice<Update'BillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: Update'BillingCycleAnchor, ?automaticTax: Update'AutomaticTax, ?applicationFeePercent: decimal, ?addInvoiceItems: Update'AddInvoiceItems list, ?trialFromPlan: bool, ?trialSettings: Update'TrialSettings) =
            {
                SubscriptionExposedId = subscriptionExposedId
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CancelAt = cancelAt
                CancelAtPeriodEnd = cancelAtPeriodEnd
                CancellationDetails = cancellationDetails
                CollectionMethod = collectionMethod
                Coupon = coupon
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Description = description
                Expand = expand
                Items = items
                Metadata = metadata
                OffSession = offSession
                OnBehalfOf = onBehalfOf
                PauseCollection = pauseCollection
                PaymentBehavior = paymentBehavior
                PaymentSettings = paymentSettings
                PendingInvoiceItemInterval = pendingInvoiceItemInterval
                PromotionCode = promotionCode
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
                TransferData = transferData
                TrialEnd = trialEnd
                TrialFromPlan = trialFromPlan
                TrialSettings = trialSettings
            }

    ///<p>Updates an existing subscription on a customer to match the specified parameters. When changing plans or quantities, we will optionally prorate the price we charge next month to make up for any price changes. To preview how the proration will be calculated, use the <a href="#upcoming_invoice">upcoming invoice</a> endpoint.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/subscriptions/{options.SubscriptionExposedId}"
        |> RestApi.postAsync<_, Subscription> settings (Map.empty) options

module SubscriptionsSearch =

    type SearchOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.
        [<Config.Query>]Page: string option
        ///The search query string. See [search query language](https://stripe.com/docs/search#search-query-language) and the list of supported [query fields for subscriptions](https://stripe.com/docs/search#query-fields-for-subscriptions).
        [<Config.Query>]Query: string
    }
    with
        static member New(query: string, ?expand: string list, ?limit: int, ?page: string) =
            {
                Expand = expand
                Limit = limit
                Page = page
                Query = query
            }

    ///<p>Search for subscriptions you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/subscriptions/search"
        |> RestApi.getAsync<Subscription list> settings qs

module SubscriptionsDiscount =

    type DeleteDiscountOptions = {
        [<Config.Path>]SubscriptionExposedId: string
    }
    with
        static member New(subscriptionExposedId: string) =
            {
                SubscriptionExposedId = subscriptionExposedId
            }

    ///<p>Removes the currently applied discount on a subscription.</p>
    let DeleteDiscount settings (options: DeleteDiscountOptions) =
        $"/v1/subscriptions/{options.SubscriptionExposedId}/discount"
        |> RestApi.deleteAsync<DeletedDiscount> settings (Map.empty)

module SubscriptionsResume =

    type Resume'BillingCycleAnchor =
    | Now
    | Unchanged

    type Resume'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type ResumeOptions = {
        [<Config.Path>]Subscription: string
        ///Either `now` or `unchanged`. Setting the value to `now` resets the subscription's billing cycle anchor to the current time (in UTC). Setting the value to `unchanged` advances the subscription's billing cycle anchor to the period that surrounds the current time. For more information, see the billing cycle [documentation](https://stripe.com/docs/billing/subscriptions/billing-cycle).
        [<Config.Form>]BillingCycleAnchor: Resume'BillingCycleAnchor option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Determines how to handle [prorations](https://stripe.com/docs/subscriptions/billing-cycle#prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.
        [<Config.Form>]ProrationBehavior: Resume'ProrationBehavior option
        ///If set, the proration will be calculated as though the subscription was resumed at the given time. This can be used to apply exactly the same proration that was previewed with [upcoming invoice](https://stripe.com/docs/api#retrieve_customer_invoice) endpoint.
        [<Config.Form>]ProrationDate: DateTime option
    }
    with
        static member New(subscription: string, ?billingCycleAnchor: Resume'BillingCycleAnchor, ?expand: string list, ?prorationBehavior: Resume'ProrationBehavior, ?prorationDate: DateTime) =
            {
                Subscription = subscription
                BillingCycleAnchor = billingCycleAnchor
                Expand = expand
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
            }

    ///<p>Initiates resumption of a paused subscription, optionally resetting the billing cycle anchor and creating prorations. If a resumption invoice is generated, it must be paid or marked uncollectible before the subscription will be unpaused. If payment succeeds the subscription will become <code>active</code>, and if payment fails the subscription will be <code>past_due</code>. The resumption invoice will void automatically if not paid by the expiration date.</p>
    let Resume settings (options: ResumeOptions) =
        $"/v1/subscriptions/{options.Subscription}/resume"
        |> RestApi.postAsync<_, Subscription> settings (Map.empty) options

module TaxCalculations =

    type Create'CustomerDetailsAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: Choice<string,string> option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: Choice<string,string> option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: Choice<string,string> option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: Choice<string,string> option
        ///State/province as an [ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2) subdivision code, without country prefix. Example: "NY" or "TX".
        [<Config.Form>]State: Choice<string,string> option
    }
    with
        static member New(?city: Choice<string,string>, ?country: string, ?line1: Choice<string,string>, ?line2: Choice<string,string>, ?postalCode: Choice<string,string>, ?state: Choice<string,string>) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'CustomerDetailsTaxIdsType =
    | AdNrt
    | AeTrn
    | ArCuit
    | AuAbn
    | AuArn
    | BgUic
    | BoTin
    | BrCnpj
    | BrCpf
    | CaBn
    | CaGstHst
    | CaPstBc
    | CaPstMb
    | CaPstSk
    | CaQst
    | ChVat
    | ClTin
    | CnTin
    | CoNit
    | CrTin
    | DoRcn
    | EcRuc
    | EgTin
    | EsCif
    | EuOssVat
    | EuVat
    | GbVat
    | GeVat
    | HkBr
    | HuTin
    | IdNpwp
    | IlVat
    | InGst
    | IsVat
    | JpCn
    | JpRn
    | JpTrn
    | KePin
    | KrBrn
    | LiUid
    | MxRfc
    | MyFrp
    | MyItn
    | MySst
    | NoVat
    | NzGst
    | PeRuc
    | PhTin
    | RoTin
    | RsPib
    | RuInn
    | RuKpp
    | SaVat
    | SgGst
    | SgUen
    | SiTin
    | SvNit
    | ThVat
    | TrTin
    | TwVat
    | UaVat
    | UsEin
    | UyRuc
    | VeRif
    | VnTin
    | ZaVat

    type Create'CustomerDetailsTaxIds = {
        ///Type of the tax ID, one of `ad_nrt`, `ae_trn`, `ar_cuit`, `au_abn`, `au_arn`, `bg_uic`, `bo_tin`, `br_cnpj`, `br_cpf`, `ca_bn`, `ca_gst_hst`, `ca_pst_bc`, `ca_pst_mb`, `ca_pst_sk`, `ca_qst`, `ch_vat`, `cl_tin`, `cn_tin`, `co_nit`, `cr_tin`, `do_rcn`, `ec_ruc`, `eg_tin`, `es_cif`, `eu_oss_vat`, `eu_vat`, `gb_vat`, `ge_vat`, `hk_br`, `hu_tin`, `id_npwp`, `il_vat`, `in_gst`, `is_vat`, `jp_cn`, `jp_rn`, `jp_trn`, `ke_pin`, `kr_brn`, `li_uid`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `no_vat`, `nz_gst`, `pe_ruc`, `ph_tin`, `ro_tin`, `rs_pib`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `si_tin`, `sv_nit`, `th_vat`, `tr_tin`, `tw_vat`, `ua_vat`, `us_ein`, `uy_ruc`, `ve_rif`, `vn_tin`, or `za_vat`
        [<Config.Form>]Type: Create'CustomerDetailsTaxIdsType option
        ///Value of the tax ID.
        [<Config.Form>]Value: string option
    }
    with
        static member New(?type': Create'CustomerDetailsTaxIdsType, ?value: string) =
            {
                Type = type'
                Value = value
            }

    type Create'CustomerDetailsAddressSource =
    | Billing
    | Shipping

    type Create'CustomerDetailsTaxabilityOverride =
    | CustomerExempt
    | None'
    | ReverseCharge

    type Create'CustomerDetails = {
        ///The customer's postal address (for example, home or business location).
        [<Config.Form>]Address: Create'CustomerDetailsAddress option
        ///The type of customer address provided.
        [<Config.Form>]AddressSource: Create'CustomerDetailsAddressSource option
        ///The customer's IP address (IPv4 or IPv6).
        [<Config.Form>]IpAddress: string option
        ///The customer's tax IDs.
        [<Config.Form>]TaxIds: Create'CustomerDetailsTaxIds list option
        ///Overrides the tax calculation result to allow you to not collect tax from your customer. Use this if you've manually checked your customer's tax exemptions. Prefer providing the customer's `tax_ids` where possible, which automatically determines whether `reverse_charge` applies.
        [<Config.Form>]TaxabilityOverride: Create'CustomerDetailsTaxabilityOverride option
    }
    with
        static member New(?address: Create'CustomerDetailsAddress, ?addressSource: Create'CustomerDetailsAddressSource, ?ipAddress: string, ?taxIds: Create'CustomerDetailsTaxIds list, ?taxabilityOverride: Create'CustomerDetailsTaxabilityOverride) =
            {
                Address = address
                AddressSource = addressSource
                IpAddress = ipAddress
                TaxIds = taxIds
                TaxabilityOverride = taxabilityOverride
            }

    type Create'LineItemsTaxBehavior =
    | Exclusive
    | Inclusive

    type Create'LineItems = {
        ///A positive integer in cents representing the line item's total price. If `tax_behavior=inclusive`, then this amount includes taxes. Otherwise, taxes are calculated on top of this amount.
        [<Config.Form>]Amount: int option
        ///If provided, the product's `tax_code` will be used as the line item's `tax_code`.
        [<Config.Form>]Product: string option
        ///The number of units of the item being purchased. Used to calculate the per-unit price from the total `amount` for the line. For example, if `amount=100` and `quantity=4`, the calculated unit price is 25.
        [<Config.Form>]Quantity: int option
        ///A custom identifier for this line item, which must be unique across the line items in the calculation. The reference helps identify each line item in exported [tax reports](https://stripe.com/docs/tax/reports).
        [<Config.Form>]Reference: string option
        ///Specifies whether the `amount` includes taxes. Defaults to `exclusive`.
        [<Config.Form>]TaxBehavior: Create'LineItemsTaxBehavior option
        ///A [tax code](https://stripe.com/docs/tax/tax-categories) ID to use for this line item. If not provided, we will use the tax code from the provided `product` param. If neither `tax_code` nor `product` is provided, we will use the default tax code from your Tax Settings.
        [<Config.Form>]TaxCode: string option
    }
    with
        static member New(?amount: int, ?product: string, ?quantity: int, ?reference: string, ?taxBehavior: Create'LineItemsTaxBehavior, ?taxCode: string) =
            {
                Amount = amount
                Product = product
                Quantity = quantity
                Reference = reference
                TaxBehavior = taxBehavior
                TaxCode = taxCode
            }

    type Create'ShippingCostTaxBehavior =
    | Exclusive
    | Inclusive

    type Create'ShippingCost = {
        ///A positive integer in cents representing the shipping charge. If `tax_behavior=inclusive`, then this amount includes taxes. Otherwise, taxes are calculated on top of this amount.
        [<Config.Form>]Amount: int option
        ///If provided, the [shipping rate](https://stripe.com/docs/api/shipping_rates/object)'s `amount`, `tax_code` and `tax_behavior` are used. If you provide a shipping rate, then you cannot pass the `amount`, `tax_code`, or `tax_behavior` parameters.
        [<Config.Form>]ShippingRate: string option
        ///Specifies whether the `amount` includes taxes. If `tax_behavior=inclusive`, then the amount includes taxes. Defaults to `exclusive`.
        [<Config.Form>]TaxBehavior: Create'ShippingCostTaxBehavior option
        ///The [tax code](https://stripe.com/docs/tax/tax-categories) used to calculate tax on shipping. If not provided, the default shipping tax code from your [Tax Settings](/settings/tax) is used.
        [<Config.Form>]TaxCode: string option
    }
    with
        static member New(?amount: int, ?shippingRate: string, ?taxBehavior: Create'ShippingCostTaxBehavior, ?taxCode: string) =
            {
                Amount = amount
                ShippingRate = shippingRate
                TaxBehavior = taxBehavior
                TaxCode = taxCode
            }

    type CreateOptions = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string
        ///The ID of an existing customer to use for this calculation. If provided, the customer's address and tax IDs are copied to `customer_details`.
        [<Config.Form>]Customer: string option
        ///Details about the customer, including address and tax IDs.
        [<Config.Form>]CustomerDetails: Create'CustomerDetails option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A list of items the customer is purchasing.
        [<Config.Form>]LineItems: Create'LineItems list
        ///Shipping cost details to be used for the calculation.
        [<Config.Form>]ShippingCost: Create'ShippingCost option
        ///Timestamp of date at which the tax rules and rates in effect applies for the calculation. Measured in seconds since the Unix epoch. Can be up to 48 hours in the past, and up to 48 hours in the future.
        [<Config.Form>]TaxDate: int option
    }
    with
        static member New(currency: string, lineItems: Create'LineItems list, ?customer: string, ?customerDetails: Create'CustomerDetails, ?expand: string list, ?shippingCost: Create'ShippingCost, ?taxDate: int) =
            {
                Currency = currency
                Customer = customer
                CustomerDetails = customerDetails
                Expand = expand
                LineItems = lineItems
                ShippingCost = shippingCost
                TaxDate = taxDate
            }

    ///<p>Calculates tax based on input and returns a Tax <code>Calculation</code> object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/tax/calculations"
        |> RestApi.postAsync<_, TaxCalculation> settings (Map.empty) options

module TaxCalculationsLineItems =

    type ListLineItemsOptions = {
        [<Config.Path>]Calculation: string
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(calculation: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Calculation = calculation
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Retrieves the line items of a persisted tax calculation as a collection.</p>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax/calculations/{options.Calculation}/line_items"
        |> RestApi.getAsync<TaxCalculationLineItem list> settings qs

module TaxSettings =

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(?expand: string list) =
            {
                Expand = expand
            }

    ///<p>Retrieves Tax <code>Settings</code> for a merchant.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax/settings"
        |> RestApi.getAsync<TaxSettings> settings qs

    type Update'DefaultsTaxBehavior =
    | Exclusive
    | Inclusive
    | InferredByCurrency

    type Update'Defaults = {
        ///Specifies the default [tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#tax-behavior) to be used when the item's price has unspecified tax behavior. One of inclusive, exclusive, or inferred_by_currency. Once specified, it cannot be changed back to null.
        [<Config.Form>]TaxBehavior: Update'DefaultsTaxBehavior option
        ///A [tax code](https://stripe.com/docs/tax/tax-categories) ID.
        [<Config.Form>]TaxCode: string option
    }
    with
        static member New(?taxBehavior: Update'DefaultsTaxBehavior, ?taxCode: string) =
            {
                TaxBehavior = taxBehavior
                TaxCode = taxCode
            }

    type Update'HeadOfficeAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State/province as an [ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2) subdivision code, without country prefix. Example: "NY" or "TX".
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'HeadOffice = {
        ///The location of the business for tax purposes.
        [<Config.Form>]Address: Update'HeadOfficeAddress option
    }
    with
        static member New(?address: Update'HeadOfficeAddress) =
            {
                Address = address
            }

    type UpdateOptions = {
        ///Default configuration to be used on Stripe Tax calculations.
        [<Config.Form>]Defaults: Update'Defaults option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The place where your business is located.
        [<Config.Form>]HeadOffice: Update'HeadOffice option
    }
    with
        static member New(?defaults: Update'Defaults, ?expand: string list, ?headOffice: Update'HeadOffice) =
            {
                Defaults = defaults
                Expand = expand
                HeadOffice = headOffice
            }

    ///<p>Updates Tax <code>Settings</code> parameters used in tax calculations. All parameters are editable but none can be removed once set.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/tax/settings"
        |> RestApi.postAsync<_, TaxSettings> settings (Map.empty) options

module TaxTransactionsCreateFromCalculation =

    type CreateFromCalculationOptions = {
        ///Tax Calculation ID to be used as input when creating the transaction.
        [<Config.Form>]Calculation: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///A custom order or sale identifier, such as 'myOrder_123'. Must be unique across all transactions, including reversals.
        [<Config.Form>]Reference: string
    }
    with
        static member New(calculation: string, reference: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Calculation = calculation
                Expand = expand
                Metadata = metadata
                Reference = reference
            }

    ///<p>Creates a Tax <code>Transaction</code> from a calculation.</p>
    let CreateFromCalculation settings (options: CreateFromCalculationOptions) =
        $"/v1/tax/transactions/create_from_calculation"
        |> RestApi.postAsync<_, TaxTransaction> settings (Map.empty) options

module TaxTransactionsCreateReversal =

    type CreateReversal'LineItems = {
        ///The amount to reverse, in negative integer cents.
        [<Config.Form>]Amount: int option
        ///The amount of tax to reverse, in negative integer cents.
        [<Config.Form>]AmountTax: int option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The `id` of the line item to reverse in the original transaction.
        [<Config.Form>]OriginalLineItem: string option
        ///The quantity reversed. Appears in [tax exports](https://stripe.com/docs/tax/reports), but does not affect the amount of tax reversed.
        [<Config.Form>]Quantity: int option
        ///A custom identifier for this line item in the reversal transaction, such as 'L1-refund'.
        [<Config.Form>]Reference: string option
    }
    with
        static member New(?amount: int, ?amountTax: int, ?metadata: Map<string, string>, ?originalLineItem: string, ?quantity: int, ?reference: string) =
            {
                Amount = amount
                AmountTax = amountTax
                Metadata = metadata
                OriginalLineItem = originalLineItem
                Quantity = quantity
                Reference = reference
            }

    type CreateReversal'ShippingCost = {
        ///The amount to reverse, in negative integer cents.
        [<Config.Form>]Amount: int option
        ///The amount of tax to reverse, in negative integer cents.
        [<Config.Form>]AmountTax: int option
    }
    with
        static member New(?amount: int, ?amountTax: int) =
            {
                Amount = amount
                AmountTax = amountTax
            }

    type CreateReversal'Mode =
    | Full
    | Partial

    type CreateReversalOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A flat amount to reverse across the entire transaction, in negative integer cents. This value represents the total amount to refund from the transaction, including taxes.
        [<Config.Form>]FlatAmount: int option
        ///The line item amounts to reverse.
        [<Config.Form>]LineItems: CreateReversal'LineItems list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///If `partial`, the provided line item or shipping cost amounts are reversed. If `full`, the original transaction is fully reversed.
        [<Config.Form>]Mode: CreateReversal'Mode
        ///The ID of the Transaction to partially or fully reverse.
        [<Config.Form>]OriginalTransaction: string
        ///A custom identifier for this reversal, such as `myOrder_123-refund_1`, which must be unique across all transactions. The reference helps identify this reversal transaction in exported [tax reports](https://stripe.com/docs/tax/reports).
        [<Config.Form>]Reference: string
        ///The shipping cost to reverse.
        [<Config.Form>]ShippingCost: CreateReversal'ShippingCost option
    }
    with
        static member New(mode: CreateReversal'Mode, originalTransaction: string, reference: string, ?expand: string list, ?flatAmount: int, ?lineItems: CreateReversal'LineItems list, ?metadata: Map<string, string>, ?shippingCost: CreateReversal'ShippingCost) =
            {
                Expand = expand
                FlatAmount = flatAmount
                LineItems = lineItems
                Metadata = metadata
                Mode = mode
                OriginalTransaction = originalTransaction
                Reference = reference
                ShippingCost = shippingCost
            }

    ///<p>Partially or fully reverses a previously created <code>Transaction</code>.</p>
    let CreateReversal settings (options: CreateReversalOptions) =
        $"/v1/tax/transactions/create_reversal"
        |> RestApi.postAsync<_, TaxTransaction> settings (Map.empty) options

module TaxTransactions =

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Transaction: string
    }
    with
        static member New(transaction: string, ?expand: string list) =
            {
                Expand = expand
                Transaction = transaction
            }

    ///<p>Retrieves a Tax <code>Transaction</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax/transactions/{options.Transaction}"
        |> RestApi.getAsync<TaxTransaction> settings qs

module TaxTransactionsLineItems =

    type ListLineItemsOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        [<Config.Path>]Transaction: string
    }
    with
        static member New(transaction: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Transaction = transaction
            }

    ///<p>Retrieves the line items of a committed standalone transaction as a collection.</p>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax/transactions/{options.Transaction}/line_items"
        |> RestApi.getAsync<TaxTransactionLineItem list> settings qs

module TaxCodes =

    type ListOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>A list of <a href="https://stripe.com/docs/tax/tax-categories">all tax codes available</a> to add to Products in order to allow specific tax calculations.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax_codes"
        |> RestApi.getAsync<TaxCode list> settings qs

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<p>Retrieves the details of an existing tax code. Supply the unique tax code ID and Stripe will return the corresponding tax code information.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax_codes/{options.Id}"
        |> RestApi.getAsync<TaxCode> settings qs

module TaxRates =

    type ListOptions = {
        ///Optional flag to filter by tax rates that are either active or inactive (archived).
        [<Config.Query>]Active: bool option
        ///Optional range for filtering created date.
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///Optional flag to filter by tax rates that are inclusive (or those that are not inclusive).
        [<Config.Query>]Inclusive: bool option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?inclusive: bool, ?limit: int, ?startingAfter: string) =
            {
                Active = active
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Inclusive = inclusive
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of your tax rates. Tax rates are returned sorted by creation date, with the most recently created tax rates appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("inclusive", options.Inclusive |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax_rates"
        |> RestApi.getAsync<TaxRate list> settings qs

    type Create'TaxType =
    | AmusementTax
    | CommunicationsTax
    | Gst
    | Hst
    | Igst
    | Jct
    | LeaseTax
    | Pst
    | Qst
    | Rst
    | SalesTax
    | ServiceTax
    | Vat

    type CreateOptions = {
        ///Flag determining whether the tax rate is active or inactive (archived). Inactive tax rates cannot be used with new applications or Checkout Sessions, but will still work for subscriptions and invoices that already have it set.
        [<Config.Form>]Active: bool option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.
        [<Config.Form>]Description: string option
        ///The display name of the tax rate, which will be shown to users.
        [<Config.Form>]DisplayName: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///This specifies if the tax rate is inclusive or exclusive.
        [<Config.Form>]Inclusive: bool
        ///The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.
        [<Config.Form>]Jurisdiction: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///This represents the tax rate percent out of 100.
        [<Config.Form>]Percentage: decimal
        ///[ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2:US), without country prefix. For example, "NY" for New York, United States.
        [<Config.Form>]State: string option
        ///The high-level tax type, such as `vat` or `sales_tax`.
        [<Config.Form>]TaxType: Create'TaxType option
    }
    with
        static member New(displayName: string, inclusive: bool, percentage: decimal, ?active: bool, ?country: string, ?description: string, ?expand: string list, ?jurisdiction: string, ?metadata: Map<string, string>, ?state: string, ?taxType: Create'TaxType) =
            {
                Active = active
                Country = country
                Description = description
                DisplayName = displayName
                Expand = expand
                Inclusive = inclusive
                Jurisdiction = jurisdiction
                Metadata = metadata
                Percentage = percentage
                State = state
                TaxType = taxType
            }

    ///<p>Creates a new tax rate.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/tax_rates"
        |> RestApi.postAsync<_, TaxRate> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]TaxRate: string
    }
    with
        static member New(taxRate: string, ?expand: string list) =
            {
                Expand = expand
                TaxRate = taxRate
            }

    ///<p>Retrieves a tax rate with the given ID</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax_rates/{options.TaxRate}"
        |> RestApi.getAsync<TaxRate> settings qs

    type Update'TaxType =
    | AmusementTax
    | CommunicationsTax
    | Gst
    | Hst
    | Igst
    | Jct
    | LeaseTax
    | Pst
    | Qst
    | Rst
    | SalesTax
    | ServiceTax
    | Vat

    type UpdateOptions = {
        [<Config.Path>]TaxRate: string
        ///Flag determining whether the tax rate is active or inactive (archived). Inactive tax rates cannot be used with new applications or Checkout Sessions, but will still work for subscriptions and invoices that already have it set.
        [<Config.Form>]Active: bool option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.
        [<Config.Form>]Description: string option
        ///The display name of the tax rate, which will be shown to users.
        [<Config.Form>]DisplayName: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.
        [<Config.Form>]Jurisdiction: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///[ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2:US), without country prefix. For example, "NY" for New York, United States.
        [<Config.Form>]State: string option
        ///The high-level tax type, such as `vat` or `sales_tax`.
        [<Config.Form>]TaxType: Update'TaxType option
    }
    with
        static member New(taxRate: string, ?active: bool, ?country: string, ?description: string, ?displayName: string, ?expand: string list, ?jurisdiction: string, ?metadata: Map<string, string>, ?state: string, ?taxType: Update'TaxType) =
            {
                TaxRate = taxRate
                Active = active
                Country = country
                Description = description
                DisplayName = displayName
                Expand = expand
                Jurisdiction = jurisdiction
                Metadata = metadata
                State = state
                TaxType = taxType
            }

    ///<p>Updates an existing tax rate.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/tax_rates/{options.TaxRate}"
        |> RestApi.postAsync<_, TaxRate> settings (Map.empty) options
