namespace Stripe.BillingPortal

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Application
open Stripe.PaymentMethod
open Stripe.Portal

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type BillingPortalConfigurationApplication'AnyOf =
    | String of string
    | Application of Application
    | DeletedApplication of DeletedApplication

type PortalBusinessProfile =
    {
        /// The messaging shown to customers in the portal.
        Headline: string option
        /// A link to the business’s publicly available privacy policy.
        PrivacyPolicyUrl: string option
        /// A link to the business’s publicly available terms of service.
        TermsOfServiceUrl: string option
    }

type PortalFeatures =
    { CustomerUpdate: PortalCustomerUpdate
      InvoiceHistory: PortalInvoiceList
      PaymentMethodUpdate: PortalPaymentMethodUpdate
      SubscriptionCancel: PortalSubscriptionCancel
      SubscriptionUpdate: PortalSubscriptionUpdate }

type PortalLoginPage =
    {
        /// If `true`, a shareable `url` will be generated that will take your customers to a hosted login page for the customer portal.
        /// If `false`, the previously generated `url`, if any, will be deactivated.
        Enabled: bool
        /// A shareable URL to the hosted portal login page. Your customers will be able to log in with their [email](https://docs.stripe.com/api/customers/object#customer_object-email) and receive a link to their customer portal.
        Url: string option
    }

/// A portal configuration describes the functionality and behavior you embed in a portal session. Related guide: [Configure the customer portal](/customer-management/configure-portal).
type BillingPortalConfiguration =
    {
        /// Whether the configuration is active and can be used to create portal sessions.
        Active: bool
        /// ID of the Connect Application that created the configuration.
        Application: BillingPortalConfigurationApplication'AnyOf option
        BusinessProfile: PortalBusinessProfile
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The default URL to redirect customers to when they click on the portal's link to return to your website. This can be [overriden](https://docs.stripe.com/api/customer_portal/sessions/create#create_portal_session-return_url) when creating the session.
        DefaultReturnUrl: string option
        Features: PortalFeatures
        /// Unique identifier for the object.
        Id: string
        /// Whether the configuration is the default. If `true`, this configuration can be managed in the Dashboard and portal sessions will use this configuration unless it is overriden when creating the session.
        IsDefault: bool
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        LoginPage: PortalLoginPage
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The name of the configuration.
        Name: string option
        /// Time at which the object was last updated. Measured in seconds since the Unix epoch.
        Updated: DateTime
    }

module BillingPortalConfiguration =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "billing_portal.configuration"

type BillingPortalSessionConfiguration'AnyOf =
    | String of string
    | BillingPortalConfiguration of BillingPortalConfiguration

type BillingPortalSessionLocale =
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

/// The Billing customer portal is a Stripe-hosted UI for subscription and
/// billing management.
/// A portal configuration describes the functionality and features that you
/// want to provide to your customers through the portal.
/// A portal session describes the instantiation of the customer portal for
/// a particular customer. By visiting the session's URL, the customer
/// can manage their subscriptions and billing details. For security reasons,
/// sessions are short-lived and will expire if the customer does not visit the URL.
/// Create sessions on-demand when customers intend to manage their subscriptions
/// and billing details.
/// Related guide: [Customer management](/customer-management)
type BillingPortalSession =
    {
        /// The configuration used by this session, describing the features available.
        Configuration: BillingPortalSessionConfiguration'AnyOf
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// The ID of the customer for this session.
        Customer: string
        /// The ID of the account for this session.
        CustomerAccount: string option
        /// Information about a specific flow for the customer to go through. See the [docs](https://docs.stripe.com/customer-management/portal-deep-links) to learn more about using customer portal deep links and flows.
        Flow: PortalFlowsFlow option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The IETF language tag of the locale Customer Portal is displayed in. If blank or auto, the customer’s `preferred_locales` or browser’s locale is used.
        Locale: BillingPortalSessionLocale option
        /// The account for which the session was created on behalf of. When specified, only subscriptions and invoices with this `on_behalf_of` account appear in the portal. For more information, see the [docs](https://docs.stripe.com/connect/separate-charges-and-transfers#settlement-merchant). Use the [Accounts API](https://docs.stripe.com/api/accounts/object#account_object-settings-branding) to modify the `on_behalf_of` account's branding settings, which the portal displays.
        OnBehalfOf: string option
        /// The URL to redirect customers to when they click on the portal's link to return to your website.
        ReturnUrl: string option
        /// The short-lived URL of the session that gives customers access to the customer portal.
        Url: string
    }

module BillingPortalSession =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "billing_portal.session"

/// Occurs whenever a portal session is created.
type BillingPortalSessionCreated = { Object: BillingPortalSession }

/// Occurs whenever a portal configuration is updated.
type BillingPortalConfigurationUpdated = { Object: BillingPortalConfiguration }

/// Occurs whenever a portal configuration is created.
type BillingPortalConfigurationCreated = { Object: BillingPortalConfiguration }

