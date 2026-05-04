namespace Stripe.PaymentLink

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Application
open Stripe.PaymentMethod

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type PaymentLinkApplication'AnyOf =
    | String of string
    | Application of Application
    | DeletedApplication of DeletedApplication

[<Struct>]
type PaymentLinkBillingAddressCollection =
    | Auto
    | Required

[<Struct>]
type PaymentLinkCustomerCreation =
    | Always
    | IfRequired

/// The line items representing what is being sold.
type PaymentLinkLineItems =
    {
        /// Details about each object.
        Data: Item list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

type PaymentLinkLineItems with
    static member New(data: Item list, hasMore: bool, url: string) =
        {
            Data = data
            HasMore = hasMore
            Url = url
        }

module PaymentLinkLineItems =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

[<Struct>]
type PaymentLinkPaymentMethodCollection =
    | Always
    | IfRequired

type PaymentLinkPaymentMethodTypes =
    | Affirm
    | AfterpayClearpay
    | Alipay
    | Alma
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Billie
    | Blik
    | Boleto
    | Card
    | Cashapp
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Klarna
    | Konbini
    | Link
    | MbWay
    | Mobilepay
    | Multibanco
    | Oxxo
    | P24
    | PayByBank
    | Paynow
    | Paypal
    | Payto
    | Pix
    | Promptpay
    | Satispay
    | SepaDebit
    | Sofort
    | Sunbit
    | Swish
    | Twint
    | Upi
    | UsBankAccount
    | WechatPay
    | Zip

[<Struct>]
type PaymentLinkSubmitType =
    | Auto
    | Book
    | Donate
    | Pay
    | Subscribe

/// A payment link is a shareable URL that will take your customers to a hosted payment page. A payment link can be shared and used multiple times.
/// When a customer opens a payment link it will open a new [checkout session](https://docs.stripe.com/api/checkout/sessions) to render the payment page. You can use [checkout session events](https://docs.stripe.com/api/events/types#event_types-checkout.session.completed) to track payments through payment links.
/// Related guide: [Payment Links API](https://docs.stripe.com/payment-links)
type PaymentLink =
    {
        /// Whether the payment link's `url` is active. If `false`, customers visiting the URL will be shown a page saying that the link has been deactivated.
        Active: bool
        AfterCompletion: PaymentLinksResourceAfterCompletion
        /// Whether user redeemable promotion codes are enabled.
        AllowPromotionCodes: bool
        /// The ID of the Connect application that created the Payment Link.
        Application: PaymentLinkApplication'AnyOf option
        /// The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account.
        ApplicationFeeAmount: int option
        /// This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account.
        ApplicationFeePercent: decimal option
        AutomaticTax: PaymentLinksResourceAutomaticTax
        /// Configuration for collecting the customer's billing address. Defaults to `auto`.
        BillingAddressCollection: PaymentLinkBillingAddressCollection
        /// When set, provides configuration to gather active consent from customers.
        ConsentCollection: PaymentLinksResourceConsentCollection option
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// Collect additional information from your customer using custom fields. Up to 3 fields are supported. You can't set this parameter if `ui_mode` is `custom`.
        CustomFields: PaymentLinksResourceCustomFields list
        CustomText: PaymentLinksResourceCustomText
        /// Configuration for Customer creation during checkout.
        CustomerCreation: PaymentLinkCustomerCreation
        /// Unique identifier for the object.
        Id: string
        /// The custom message to be displayed to a customer when a payment link is no longer active.
        InactiveMessage: string option
        /// Configuration for creating invoice for payment mode payment links.
        InvoiceCreation: PaymentLinksResourceInvoiceCreation option
        /// The line items representing what is being sold.
        LineItems: PaymentLinkLineItems option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Settings for Managed Payments for this Payment Link and resulting [CheckoutSessions](/api/checkout/sessions/object), [PaymentIntents](/api/payment_intents/object), [Invoices](/api/invoices/object), and [Subscriptions](/api/subscriptions/object).
        ManagedPayments: PaymentPagesCheckoutSessionManagedPayments option
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        NameCollection: PaymentLinksResourceNameCollection option
        /// The account on behalf of which to charge. See the [Connect documentation](https://support.stripe.com/questions/sending-invoices-on-behalf-of-connected-accounts) for details.
        OnBehalfOf: StripeId<Markers.Account> option
        /// The optional items presented to the customer at checkout.
        OptionalItems: PaymentLinksResourceOptionalItem list option
        /// Indicates the parameters to be passed to PaymentIntent creation during checkout.
        PaymentIntentData: PaymentLinksResourcePaymentIntentData option
        /// Configuration for collecting a payment method during checkout. Defaults to `always`.
        PaymentMethodCollection: PaymentLinkPaymentMethodCollection
        /// The list of payment method types that customers can use. When `null`, Stripe will dynamically show relevant payment methods you've enabled in your [payment method settings](https://dashboard.stripe.com/settings/payment_methods).
        PaymentMethodTypes: PaymentLinkPaymentMethodTypes list option
        PhoneNumberCollection: PaymentLinksResourcePhoneNumberCollection
        /// Settings that restrict the usage of a payment link.
        Restrictions: PaymentLinksResourceRestrictions option
        /// Configuration for collecting the customer's shipping address.
        ShippingAddressCollection: PaymentLinksResourceShippingAddressCollection option
        /// The shipping rate options applied to the session.
        ShippingOptions: PaymentLinksResourceShippingOption list
        /// Indicates the type of transaction being performed which customizes relevant text on the page, such as the submit button.
        SubmitType: PaymentLinkSubmitType
        /// When creating a subscription, the specified configuration data will be used. There must be at least one line item with a recurring price to use `subscription_data`.
        SubscriptionData: PaymentLinksResourceSubscriptionData option
        TaxIdCollection: PaymentLinksResourceTaxIdCollection
        /// The account (if any) the payments will be attributed to for tax reporting, and where funds from each payment will be transferred to.
        TransferData: PaymentLinksResourceTransferData option
        /// The public URL that can be shared with customers.
        Url: string
    }

type PaymentLink with
    static member New(active: bool, afterCompletion: PaymentLinksResourceAfterCompletion, allowPromotionCodes: bool, application: PaymentLinkApplication'AnyOf option, applicationFeeAmount: int option, applicationFeePercent: decimal option, automaticTax: PaymentLinksResourceAutomaticTax, billingAddressCollection: PaymentLinkBillingAddressCollection, consentCollection: PaymentLinksResourceConsentCollection option, currency: IsoTypes.IsoCurrencyCode, customFields: PaymentLinksResourceCustomFields list, customText: PaymentLinksResourceCustomText, customerCreation: PaymentLinkCustomerCreation, id: string, inactiveMessage: string option, invoiceCreation: PaymentLinksResourceInvoiceCreation option, livemode: bool, managedPayments: PaymentPagesCheckoutSessionManagedPayments option, metadata: Map<string, string>, onBehalfOf: StripeId<Markers.Account> option, paymentIntentData: PaymentLinksResourcePaymentIntentData option, paymentMethodCollection: PaymentLinkPaymentMethodCollection, paymentMethodTypes: PaymentLinkPaymentMethodTypes list option, phoneNumberCollection: PaymentLinksResourcePhoneNumberCollection, restrictions: PaymentLinksResourceRestrictions option, shippingAddressCollection: PaymentLinksResourceShippingAddressCollection option, shippingOptions: PaymentLinksResourceShippingOption list, submitType: PaymentLinkSubmitType, subscriptionData: PaymentLinksResourceSubscriptionData option, taxIdCollection: PaymentLinksResourceTaxIdCollection, transferData: PaymentLinksResourceTransferData option, url: string, ?lineItems: PaymentLinkLineItems, ?nameCollection: PaymentLinksResourceNameCollection, ?optionalItems: PaymentLinksResourceOptionalItem list option) =
        {
            Active = active
            AfterCompletion = afterCompletion
            AllowPromotionCodes = allowPromotionCodes
            Application = application
            ApplicationFeeAmount = applicationFeeAmount
            ApplicationFeePercent = applicationFeePercent
            AutomaticTax = automaticTax
            BillingAddressCollection = billingAddressCollection
            ConsentCollection = consentCollection
            Currency = currency
            CustomFields = customFields
            CustomText = customText
            CustomerCreation = customerCreation
            Id = id
            InactiveMessage = inactiveMessage
            InvoiceCreation = invoiceCreation
            Livemode = livemode
            ManagedPayments = managedPayments
            Metadata = metadata
            OnBehalfOf = onBehalfOf
            PaymentIntentData = paymentIntentData
            PaymentMethodCollection = paymentMethodCollection
            PaymentMethodTypes = paymentMethodTypes
            PhoneNumberCollection = phoneNumberCollection
            Restrictions = restrictions
            ShippingAddressCollection = shippingAddressCollection
            ShippingOptions = shippingOptions
            SubmitType = submitType
            SubscriptionData = subscriptionData
            TaxIdCollection = taxIdCollection
            TransferData = transferData
            Url = url
            LineItems = lineItems
            NameCollection = nameCollection
            OptionalItems = optionalItems |> Option.flatten
        }

module PaymentLink =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "payment_link"

/// Occurs when a payment link is created.
type PaymentLinkCreated = { Object: PaymentLink }

type PaymentLinkCreated with
    static member New(object: PaymentLink) =
        {
            Object = object
        }

/// Occurs when a payment link is updated.
type PaymentLinkUpdated = { Object: PaymentLink }

type PaymentLinkUpdated with
    static member New(object: PaymentLink) =
        {
            Object = object
        }

