namespace StripeRequest.PaymentMethod

open FunStripe
open System.Text.Json.Serialization
open Stripe.AccountLink
open Stripe.AccountSession
open Stripe.CustomerSession
open Stripe.InvoiceRenderingTemplate
open Stripe.PaymentMethod
open Stripe.PaymentMethodConfiguration
open Stripe.PaymentMethodDomain
open Stripe.SubscriptionItem
open Stripe.SubscriptionSchedule
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module Account =

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Expand = expand
            }

    ///<p>Retrieves the details of an account.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/account"
        |> RestApi.getAsync<Account> settings qs

module AccountLinks =

    type Create'Collect =
        | CurrentlyDue
        | EventuallyDue

    type Create'CollectionOptionsFields =
        | CurrentlyDue
        | EventuallyDue

    type Create'CollectionOptionsFutureRequirements =
        | Include
        | Omit

    type Create'CollectionOptions =
        {
            /// Specifies whether the platform collects only currently_due requirements (`currently_due`) or both currently_due and eventually_due requirements (`eventually_due`). If you don't specify `collection_options`, the default value is `currently_due`.
            [<Config.Form>]
            Fields: Create'CollectionOptionsFields option
            /// Specifies whether the platform collects future_requirements in addition to requirements in Connect Onboarding. The default value is `omit`.
            [<Config.Form>]
            FutureRequirements: Create'CollectionOptionsFutureRequirements option
        }

    module Create'CollectionOptions =
        let create
            (
                fields: Create'CollectionOptionsFields option,
                futureRequirements: Create'CollectionOptionsFutureRequirements option
            ) : Create'CollectionOptions
            =
            {
              Fields = fields
              FutureRequirements = futureRequirements
            }

    type Create'Type =
        | AccountOnboarding
        | AccountUpdate

    type CreateOptions =
        {
            /// The identifier of the account to create an account link for.
            [<Config.Form>]
            Account: string
            /// The collect parameter is deprecated. Use `collection_options` instead.
            [<Config.Form>]
            Collect: Create'Collect option
            /// Specifies the requirements that Stripe collects from connected accounts in the Connect Onboarding flow.
            [<Config.Form>]
            CollectionOptions: Create'CollectionOptions option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The URL the user will be redirected to if the account link is expired, has been previously-visited, or is otherwise invalid. The URL you specify should attempt to generate a new account link with the same parameters used to create the original account link, then redirect the user to the new account link's URL so they can continue with Connect Onboarding. If a new account link cannot be generated or the redirect fails you should display a useful error to the user.
            [<Config.Form>]
            RefreshUrl: string option
            /// The URL that the user will be redirected to upon leaving or completing the linked flow.
            [<Config.Form>]
            ReturnUrl: string option
            /// The type of account link the user is requesting.
            /// You can create Account Links of type `account_update` only for connected accounts where your platform is responsible for collecting requirements, including Custom accounts. You can't create them for accounts that have access to a Stripe-hosted Dashboard. If you use [Connect embedded components](/connect/get-started-connect-embedded-components), you can include components that allow your connected accounts to update their own information. For an account without Stripe-hosted Dashboard access where Stripe is liable for negative balances, you must use embedded components.
            [<Config.Form>]
            Type: Create'Type
        }

    module CreateOptions =
        let create
            (
                account: string,
                ``type``: Create'Type
            ) : CreateOptions
            =
            {
              Account = account
              Type = ``type``
              Collect = None
              CollectionOptions = None
              Expand = None
              RefreshUrl = None
              ReturnUrl = None
            }

    ///<p>Creates an AccountLink object that includes a single-use Stripe URL that the platform can redirect their user to in order to take them through the Connect Onboarding flow.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/account_links"
        |> RestApi.postAsync<_, AccountLink> settings (Map.empty) options

module AccountSessions =

    type Create'ComponentsAccountManagementFeatures =
        {
            /// Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.
            [<Config.Form>]
            DisableStripeUserAuthentication: bool option
            /// Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.
            [<Config.Form>]
            ExternalAccountCollection: bool option
        }

    module Create'ComponentsAccountManagementFeatures =
        let create
            (
                disableStripeUserAuthentication: bool option,
                externalAccountCollection: bool option
            ) : Create'ComponentsAccountManagementFeatures
            =
            {
              DisableStripeUserAuthentication = disableStripeUserAuthentication
              ExternalAccountCollection = externalAccountCollection
            }

    type Create'ComponentsAccountManagement =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsAccountManagementFeatures option
        }

    module Create'ComponentsAccountManagement =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsAccountManagementFeatures option
            ) : Create'ComponentsAccountManagement
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsAccountOnboardingFeatures =
        {
            /// Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.
            [<Config.Form>]
            DisableStripeUserAuthentication: bool option
            /// Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.
            [<Config.Form>]
            ExternalAccountCollection: bool option
        }

    module Create'ComponentsAccountOnboardingFeatures =
        let create
            (
                disableStripeUserAuthentication: bool option,
                externalAccountCollection: bool option
            ) : Create'ComponentsAccountOnboardingFeatures
            =
            {
              DisableStripeUserAuthentication = disableStripeUserAuthentication
              ExternalAccountCollection = externalAccountCollection
            }

    type Create'ComponentsAccountOnboarding =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsAccountOnboardingFeatures option
        }

    module Create'ComponentsAccountOnboarding =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsAccountOnboardingFeatures option
            ) : Create'ComponentsAccountOnboarding
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsBalanceReport =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// An empty list, because this embedded component has no features.
            [<Config.Form>]
            Features: string option
        }

    module Create'ComponentsBalanceReport =
        let create
            (
                enabled: bool option,
                features: string option
            ) : Create'ComponentsBalanceReport
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsBalancesFeatures =
        {
            /// Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.
            [<Config.Form>]
            DisableStripeUserAuthentication: bool option
            /// Whether to allow payout schedule to be changed. Defaults to `true` when `controller.losses.payments` is set to `stripe` for the account, otherwise `false`.
            [<Config.Form>]
            EditPayoutSchedule: bool option
            /// Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.
            [<Config.Form>]
            ExternalAccountCollection: bool option
            /// Whether instant payouts are enabled for this component.
            [<Config.Form>]
            InstantPayouts: bool option
            /// Whether to allow creation of standard payouts. Defaults to `true` when `controller.losses.payments` is set to `stripe` for the account, otherwise `false`.
            [<Config.Form>]
            StandardPayouts: bool option
        }

    module Create'ComponentsBalancesFeatures =
        let create
            (
                disableStripeUserAuthentication: bool option,
                editPayoutSchedule: bool option,
                externalAccountCollection: bool option,
                instantPayouts: bool option,
                standardPayouts: bool option
            ) : Create'ComponentsBalancesFeatures
            =
            {
              DisableStripeUserAuthentication = disableStripeUserAuthentication
              EditPayoutSchedule = editPayoutSchedule
              ExternalAccountCollection = externalAccountCollection
              InstantPayouts = instantPayouts
              StandardPayouts = standardPayouts
            }

    type Create'ComponentsBalances =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsBalancesFeatures option
        }

    module Create'ComponentsBalances =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsBalancesFeatures option
            ) : Create'ComponentsBalances
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsDisputesListFeatures =
        {
            /// Whether to allow capturing and cancelling payment intents. This is `true` by default.
            [<Config.Form>]
            CapturePayments: bool option
            /// Whether connected accounts can manage destination charges that are created on behalf of them. This is `false` by default.
            [<Config.Form>]
            DestinationOnBehalfOfChargeManagement: bool option
            /// Whether responding to disputes is enabled, including submitting evidence and accepting disputes. This is `true` by default.
            [<Config.Form>]
            DisputeManagement: bool option
            /// Whether sending refunds is enabled. This is `true` by default.
            [<Config.Form>]
            RefundManagement: bool option
        }

    module Create'ComponentsDisputesListFeatures =
        let create
            (
                capturePayments: bool option,
                destinationOnBehalfOfChargeManagement: bool option,
                disputeManagement: bool option,
                refundManagement: bool option
            ) : Create'ComponentsDisputesListFeatures
            =
            {
              CapturePayments = capturePayments
              DestinationOnBehalfOfChargeManagement = destinationOnBehalfOfChargeManagement
              DisputeManagement = disputeManagement
              RefundManagement = refundManagement
            }

    type Create'ComponentsDisputesList =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsDisputesListFeatures option
        }

    module Create'ComponentsDisputesList =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsDisputesListFeatures option
            ) : Create'ComponentsDisputesList
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsDocuments =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// An empty list, because this embedded component has no features.
            [<Config.Form>]
            Features: string option
        }

    module Create'ComponentsDocuments =
        let create
            (
                enabled: bool option,
                features: string option
            ) : Create'ComponentsDocuments
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsFinancialAccountFeatures =
        {
            /// Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.
            [<Config.Form>]
            DisableStripeUserAuthentication: bool option
            /// Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.
            [<Config.Form>]
            ExternalAccountCollection: bool option
            /// Whether to allow sending money.
            [<Config.Form>]
            SendMoney: bool option
            /// Whether to allow transferring balance.
            [<Config.Form>]
            TransferBalance: bool option
        }

    module Create'ComponentsFinancialAccountFeatures =
        let create
            (
                disableStripeUserAuthentication: bool option,
                externalAccountCollection: bool option,
                sendMoney: bool option,
                transferBalance: bool option
            ) : Create'ComponentsFinancialAccountFeatures
            =
            {
              DisableStripeUserAuthentication = disableStripeUserAuthentication
              ExternalAccountCollection = externalAccountCollection
              SendMoney = sendMoney
              TransferBalance = transferBalance
            }

    type Create'ComponentsFinancialAccount =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsFinancialAccountFeatures option
        }

    module Create'ComponentsFinancialAccount =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsFinancialAccountFeatures option
            ) : Create'ComponentsFinancialAccount
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsFinancialAccountTransactionsFeatures =
        {
            /// Whether to allow card spend dispute management features.
            [<Config.Form>]
            CardSpendDisputeManagement: bool option
        }

    module Create'ComponentsFinancialAccountTransactionsFeatures =
        let create
            (
                cardSpendDisputeManagement: bool option
            ) : Create'ComponentsFinancialAccountTransactionsFeatures
            =
            {
              CardSpendDisputeManagement = cardSpendDisputeManagement
            }

    type Create'ComponentsFinancialAccountTransactions =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsFinancialAccountTransactionsFeatures option
        }

    module Create'ComponentsFinancialAccountTransactions =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsFinancialAccountTransactionsFeatures option
            ) : Create'ComponentsFinancialAccountTransactions
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsInstantPayoutsPromotionFeatures =
        {
            /// Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.
            [<Config.Form>]
            DisableStripeUserAuthentication: bool option
            /// Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.
            [<Config.Form>]
            ExternalAccountCollection: bool option
            /// Whether instant payouts are enabled for this component.
            [<Config.Form>]
            InstantPayouts: bool option
        }

    module Create'ComponentsInstantPayoutsPromotionFeatures =
        let create
            (
                disableStripeUserAuthentication: bool option,
                externalAccountCollection: bool option,
                instantPayouts: bool option
            ) : Create'ComponentsInstantPayoutsPromotionFeatures
            =
            {
              DisableStripeUserAuthentication = disableStripeUserAuthentication
              ExternalAccountCollection = externalAccountCollection
              InstantPayouts = instantPayouts
            }

    type Create'ComponentsInstantPayoutsPromotion =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsInstantPayoutsPromotionFeatures option
        }

    module Create'ComponentsInstantPayoutsPromotion =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsInstantPayoutsPromotionFeatures option
            ) : Create'ComponentsInstantPayoutsPromotion
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsIssuingCardFeatures =
        {
            /// Whether to allow card management features.
            [<Config.Form>]
            CardManagement: bool option
            /// Whether to allow card spend dispute management features.
            [<Config.Form>]
            CardSpendDisputeManagement: bool option
            /// Whether to allow cardholder management features.
            [<Config.Form>]
            CardholderManagement: bool option
            /// Whether to allow spend control management features.
            [<Config.Form>]
            SpendControlManagement: bool option
        }

    module Create'ComponentsIssuingCardFeatures =
        let create
            (
                cardManagement: bool option,
                cardSpendDisputeManagement: bool option,
                cardholderManagement: bool option,
                spendControlManagement: bool option
            ) : Create'ComponentsIssuingCardFeatures
            =
            {
              CardManagement = cardManagement
              CardSpendDisputeManagement = cardSpendDisputeManagement
              CardholderManagement = cardholderManagement
              SpendControlManagement = spendControlManagement
            }

    type Create'ComponentsIssuingCard =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsIssuingCardFeatures option
        }

    module Create'ComponentsIssuingCard =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsIssuingCardFeatures option
            ) : Create'ComponentsIssuingCard
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsIssuingCardsListFeatures =
        {
            /// Whether to allow card management features.
            [<Config.Form>]
            CardManagement: bool option
            /// Whether to allow card spend dispute management features.
            [<Config.Form>]
            CardSpendDisputeManagement: bool option
            /// Whether to allow cardholder management features.
            [<Config.Form>]
            CardholderManagement: bool option
            /// Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.
            [<Config.Form>]
            DisableStripeUserAuthentication: bool option
            /// Whether to allow spend control management features.
            [<Config.Form>]
            SpendControlManagement: bool option
        }

    module Create'ComponentsIssuingCardsListFeatures =
        let create
            (
                cardManagement: bool option,
                cardSpendDisputeManagement: bool option,
                cardholderManagement: bool option,
                disableStripeUserAuthentication: bool option,
                spendControlManagement: bool option
            ) : Create'ComponentsIssuingCardsListFeatures
            =
            {
              CardManagement = cardManagement
              CardSpendDisputeManagement = cardSpendDisputeManagement
              CardholderManagement = cardholderManagement
              DisableStripeUserAuthentication = disableStripeUserAuthentication
              SpendControlManagement = spendControlManagement
            }

    type Create'ComponentsIssuingCardsList =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsIssuingCardsListFeatures option
        }

    module Create'ComponentsIssuingCardsList =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsIssuingCardsListFeatures option
            ) : Create'ComponentsIssuingCardsList
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsNotificationBannerFeatures =
        {
            /// Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.
            [<Config.Form>]
            DisableStripeUserAuthentication: bool option
            /// Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.
            [<Config.Form>]
            ExternalAccountCollection: bool option
        }

    module Create'ComponentsNotificationBannerFeatures =
        let create
            (
                disableStripeUserAuthentication: bool option,
                externalAccountCollection: bool option
            ) : Create'ComponentsNotificationBannerFeatures
            =
            {
              DisableStripeUserAuthentication = disableStripeUserAuthentication
              ExternalAccountCollection = externalAccountCollection
            }

    type Create'ComponentsNotificationBanner =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsNotificationBannerFeatures option
        }

    module Create'ComponentsNotificationBanner =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsNotificationBannerFeatures option
            ) : Create'ComponentsNotificationBanner
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsPaymentDetailsFeatures =
        {
            /// Whether to allow capturing and cancelling payment intents. This is `true` by default.
            [<Config.Form>]
            CapturePayments: bool option
            /// Whether connected accounts can manage destination charges that are created on behalf of them. This is `false` by default.
            [<Config.Form>]
            DestinationOnBehalfOfChargeManagement: bool option
            /// Whether responding to disputes is enabled, including submitting evidence and accepting disputes. This is `true` by default.
            [<Config.Form>]
            DisputeManagement: bool option
            /// Whether sending refunds is enabled. This is `true` by default.
            [<Config.Form>]
            RefundManagement: bool option
        }

    module Create'ComponentsPaymentDetailsFeatures =
        let create
            (
                capturePayments: bool option,
                destinationOnBehalfOfChargeManagement: bool option,
                disputeManagement: bool option,
                refundManagement: bool option
            ) : Create'ComponentsPaymentDetailsFeatures
            =
            {
              CapturePayments = capturePayments
              DestinationOnBehalfOfChargeManagement = destinationOnBehalfOfChargeManagement
              DisputeManagement = disputeManagement
              RefundManagement = refundManagement
            }

    type Create'ComponentsPaymentDetails =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsPaymentDetailsFeatures option
        }

    module Create'ComponentsPaymentDetails =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsPaymentDetailsFeatures option
            ) : Create'ComponentsPaymentDetails
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsPaymentDisputesFeatures =
        {
            /// Whether connected accounts can manage destination charges that are created on behalf of them. This is `false` by default.
            [<Config.Form>]
            DestinationOnBehalfOfChargeManagement: bool option
            /// Whether responding to disputes is enabled, including submitting evidence and accepting disputes. This is `true` by default.
            [<Config.Form>]
            DisputeManagement: bool option
            /// Whether sending refunds is enabled. This is `true` by default.
            [<Config.Form>]
            RefundManagement: bool option
        }

    module Create'ComponentsPaymentDisputesFeatures =
        let create
            (
                destinationOnBehalfOfChargeManagement: bool option,
                disputeManagement: bool option,
                refundManagement: bool option
            ) : Create'ComponentsPaymentDisputesFeatures
            =
            {
              DestinationOnBehalfOfChargeManagement = destinationOnBehalfOfChargeManagement
              DisputeManagement = disputeManagement
              RefundManagement = refundManagement
            }

    type Create'ComponentsPaymentDisputes =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsPaymentDisputesFeatures option
        }

    module Create'ComponentsPaymentDisputes =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsPaymentDisputesFeatures option
            ) : Create'ComponentsPaymentDisputes
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsPaymentsFeatures =
        {
            /// Whether to allow capturing and cancelling payment intents. This is `true` by default.
            [<Config.Form>]
            CapturePayments: bool option
            /// Whether connected accounts can manage destination charges that are created on behalf of them. This is `false` by default.
            [<Config.Form>]
            DestinationOnBehalfOfChargeManagement: bool option
            /// Whether responding to disputes is enabled, including submitting evidence and accepting disputes. This is `true` by default.
            [<Config.Form>]
            DisputeManagement: bool option
            /// Whether sending refunds is enabled. This is `true` by default.
            [<Config.Form>]
            RefundManagement: bool option
        }

    module Create'ComponentsPaymentsFeatures =
        let create
            (
                capturePayments: bool option,
                destinationOnBehalfOfChargeManagement: bool option,
                disputeManagement: bool option,
                refundManagement: bool option
            ) : Create'ComponentsPaymentsFeatures
            =
            {
              CapturePayments = capturePayments
              DestinationOnBehalfOfChargeManagement = destinationOnBehalfOfChargeManagement
              DisputeManagement = disputeManagement
              RefundManagement = refundManagement
            }

    type Create'ComponentsPayments =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsPaymentsFeatures option
        }

    module Create'ComponentsPayments =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsPaymentsFeatures option
            ) : Create'ComponentsPayments
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsPayoutDetails =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// An empty list, because this embedded component has no features.
            [<Config.Form>]
            Features: string option
        }

    module Create'ComponentsPayoutDetails =
        let create
            (
                enabled: bool option,
                features: string option
            ) : Create'ComponentsPayoutDetails
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsPayoutReconciliationReport =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// An empty list, because this embedded component has no features.
            [<Config.Form>]
            Features: string option
        }

    module Create'ComponentsPayoutReconciliationReport =
        let create
            (
                enabled: bool option,
                features: string option
            ) : Create'ComponentsPayoutReconciliationReport
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsPayoutsFeatures =
        {
            /// Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.
            [<Config.Form>]
            DisableStripeUserAuthentication: bool option
            /// Whether to allow payout schedule to be changed. Defaults to `true` when `controller.losses.payments` is set to `stripe` for the account, otherwise `false`.
            [<Config.Form>]
            EditPayoutSchedule: bool option
            /// Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.
            [<Config.Form>]
            ExternalAccountCollection: bool option
            /// Whether instant payouts are enabled for this component.
            [<Config.Form>]
            InstantPayouts: bool option
            /// Whether to allow creation of standard payouts. Defaults to `true` when `controller.losses.payments` is set to `stripe` for the account, otherwise `false`.
            [<Config.Form>]
            StandardPayouts: bool option
        }

    module Create'ComponentsPayoutsFeatures =
        let create
            (
                disableStripeUserAuthentication: bool option,
                editPayoutSchedule: bool option,
                externalAccountCollection: bool option,
                instantPayouts: bool option,
                standardPayouts: bool option
            ) : Create'ComponentsPayoutsFeatures
            =
            {
              DisableStripeUserAuthentication = disableStripeUserAuthentication
              EditPayoutSchedule = editPayoutSchedule
              ExternalAccountCollection = externalAccountCollection
              InstantPayouts = instantPayouts
              StandardPayouts = standardPayouts
            }

    type Create'ComponentsPayouts =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// The list of features enabled in the embedded component.
            [<Config.Form>]
            Features: Create'ComponentsPayoutsFeatures option
        }

    module Create'ComponentsPayouts =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsPayoutsFeatures option
            ) : Create'ComponentsPayouts
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsPayoutsList =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// An empty list, because this embedded component has no features.
            [<Config.Form>]
            Features: string option
        }

    module Create'ComponentsPayoutsList =
        let create
            (
                enabled: bool option,
                features: string option
            ) : Create'ComponentsPayoutsList
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsTaxRegistrations =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// An empty list, because this embedded component has no features.
            [<Config.Form>]
            Features: string option
        }

    module Create'ComponentsTaxRegistrations =
        let create
            (
                enabled: bool option,
                features: string option
            ) : Create'ComponentsTaxRegistrations
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsTaxSettings =
        {
            /// Whether the embedded component is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// An empty list, because this embedded component has no features.
            [<Config.Form>]
            Features: string option
        }

    module Create'ComponentsTaxSettings =
        let create
            (
                enabled: bool option,
                features: string option
            ) : Create'ComponentsTaxSettings
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'Components =
        {
            /// Configuration for the [account management](/connect/supported-embedded-components/account-management/) embedded component.
            [<Config.Form>]
            AccountManagement: Create'ComponentsAccountManagement option
            /// Configuration for the [account onboarding](/connect/supported-embedded-components/account-onboarding/) embedded component.
            [<Config.Form>]
            AccountOnboarding: Create'ComponentsAccountOnboarding option
            /// Configuration for the [balance report](/connect/supported-embedded-components/financial-reports#balance-report) embedded component.
            [<Config.Form>]
            BalanceReport: Create'ComponentsBalanceReport option
            /// Configuration for the [balances](/connect/supported-embedded-components/balances/) embedded component.
            [<Config.Form>]
            Balances: Create'ComponentsBalances option
            /// Configuration for the [disputes list](/connect/supported-embedded-components/disputes-list/) embedded component.
            [<Config.Form>]
            DisputesList: Create'ComponentsDisputesList option
            /// Configuration for the [documents](/connect/supported-embedded-components/documents/) embedded component.
            [<Config.Form>]
            Documents: Create'ComponentsDocuments option
            /// Configuration for the [financial account](/connect/supported-embedded-components/financial-account/) embedded component.
            [<Config.Form>]
            FinancialAccount: Create'ComponentsFinancialAccount option
            /// Configuration for the [financial account transactions](/connect/supported-embedded-components/financial-account-transactions/) embedded component.
            [<Config.Form>]
            FinancialAccountTransactions: Create'ComponentsFinancialAccountTransactions option
            /// Configuration for the [instant payouts promotion](/connect/supported-embedded-components/instant-payouts-promotion/) embedded component.
            [<Config.Form>]
            InstantPayoutsPromotion: Create'ComponentsInstantPayoutsPromotion option
            /// Configuration for the [issuing card](/connect/supported-embedded-components/issuing-card/) embedded component.
            [<Config.Form>]
            IssuingCard: Create'ComponentsIssuingCard option
            /// Configuration for the [issuing cards list](/connect/supported-embedded-components/issuing-cards-list/) embedded component.
            [<Config.Form>]
            IssuingCardsList: Create'ComponentsIssuingCardsList option
            /// Configuration for the [notification banner](/connect/supported-embedded-components/notification-banner/) embedded component.
            [<Config.Form>]
            NotificationBanner: Create'ComponentsNotificationBanner option
            /// Configuration for the [payment details](/connect/supported-embedded-components/payment-details/) embedded component.
            [<Config.Form>]
            PaymentDetails: Create'ComponentsPaymentDetails option
            /// Configuration for the [payment disputes](/connect/supported-embedded-components/payment-disputes/) embedded component.
            [<Config.Form>]
            PaymentDisputes: Create'ComponentsPaymentDisputes option
            /// Configuration for the [payments](/connect/supported-embedded-components/payments/) embedded component.
            [<Config.Form>]
            Payments: Create'ComponentsPayments option
            /// Configuration for the [payout details](/connect/supported-embedded-components/payout-details/) embedded component.
            [<Config.Form>]
            PayoutDetails: Create'ComponentsPayoutDetails option
            /// Configuration for the [payout reconciliation report](/connect/supported-embedded-components/financial-reports#payout-reconciliation-report) embedded component.
            [<Config.Form>]
            PayoutReconciliationReport: Create'ComponentsPayoutReconciliationReport option
            /// Configuration for the [payouts](/connect/supported-embedded-components/payouts/) embedded component.
            [<Config.Form>]
            Payouts: Create'ComponentsPayouts option
            /// Configuration for the [payouts list](/connect/supported-embedded-components/payouts-list/) embedded component.
            [<Config.Form>]
            PayoutsList: Create'ComponentsPayoutsList option
            /// Configuration for the [tax registrations](/connect/supported-embedded-components/tax-registrations/) embedded component.
            [<Config.Form>]
            TaxRegistrations: Create'ComponentsTaxRegistrations option
            /// Configuration for the [tax settings](/connect/supported-embedded-components/tax-settings/) embedded component.
            [<Config.Form>]
            TaxSettings: Create'ComponentsTaxSettings option
        }

    module Create'Components =
        let create
            (
                accountManagement: Create'ComponentsAccountManagement option,
                accountOnboarding: Create'ComponentsAccountOnboarding option,
                balanceReport: Create'ComponentsBalanceReport option,
                balances: Create'ComponentsBalances option,
                disputesList: Create'ComponentsDisputesList option,
                documents: Create'ComponentsDocuments option,
                financialAccount: Create'ComponentsFinancialAccount option,
                financialAccountTransactions: Create'ComponentsFinancialAccountTransactions option,
                instantPayoutsPromotion: Create'ComponentsInstantPayoutsPromotion option,
                issuingCard: Create'ComponentsIssuingCard option,
                issuingCardsList: Create'ComponentsIssuingCardsList option,
                notificationBanner: Create'ComponentsNotificationBanner option,
                paymentDetails: Create'ComponentsPaymentDetails option,
                paymentDisputes: Create'ComponentsPaymentDisputes option,
                payments: Create'ComponentsPayments option,
                payoutDetails: Create'ComponentsPayoutDetails option,
                payoutReconciliationReport: Create'ComponentsPayoutReconciliationReport option,
                payouts: Create'ComponentsPayouts option,
                payoutsList: Create'ComponentsPayoutsList option,
                taxRegistrations: Create'ComponentsTaxRegistrations option,
                taxSettings: Create'ComponentsTaxSettings option
            ) : Create'Components
            =
            {
              AccountManagement = accountManagement
              AccountOnboarding = accountOnboarding
              BalanceReport = balanceReport
              Balances = balances
              DisputesList = disputesList
              Documents = documents
              FinancialAccount = financialAccount
              FinancialAccountTransactions = financialAccountTransactions
              InstantPayoutsPromotion = instantPayoutsPromotion
              IssuingCard = issuingCard
              IssuingCardsList = issuingCardsList
              NotificationBanner = notificationBanner
              PaymentDetails = paymentDetails
              PaymentDisputes = paymentDisputes
              Payments = payments
              PayoutDetails = payoutDetails
              PayoutReconciliationReport = payoutReconciliationReport
              Payouts = payouts
              PayoutsList = payoutsList
              TaxRegistrations = taxRegistrations
              TaxSettings = taxSettings
            }

    type CreateOptions =
        {
            /// The identifier of the account to create an Account Session for.
            [<Config.Form>]
            Account: string
            /// Each key of the dictionary represents an embedded component, and each embedded component maps to its configuration (e.g. whether it has been enabled or not).
            [<Config.Form>]
            Components: Create'Components
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CreateOptions =
        let create
            (
                account: string,
                components: Create'Components
            ) : CreateOptions
            =
            {
              Account = account
              Components = components
              Expand = None
            }

    ///<p>Creates a AccountSession object that includes a single-use token that the platform can use on their front-end to grant client-side API access.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/account_sessions"
        |> RestApi.postAsync<_, AccountSession> settings (Map.empty) options

module BillingAlerts =

    type ListOptions =
        {
            /// Filter results to only include this type of alert.
            [<Config.Query>]
            AlertType: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Filter results to only include alerts with the given meter.
            [<Config.Query>]
            Meter: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                alertType: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                meter: string option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              AlertType = alertType
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              Meter = meter
              StartingAfter = startingAfter
            }

    type Create'AlertType = | UsageThreshold

    type Create'UsageThresholdFiltersType = | Customer

    type Create'UsageThresholdFilters =
        {
            /// Limit the scope to this usage alert only to this customer.
            [<Config.Form>]
            Customer: string option
            /// What type of filter is being applied to this usage alert.
            [<Config.Form>]
            Type: Create'UsageThresholdFiltersType option
        }

    module Create'UsageThresholdFilters =
        let create
            (
                customer: string option,
                ``type``: Create'UsageThresholdFiltersType option
            ) : Create'UsageThresholdFilters
            =
            {
              Customer = customer
              Type = ``type``
            }

    type Create'UsageThresholdRecurrence = | OneTime

    type Create'UsageThreshold =
        {
            /// The filters allows limiting the scope of this usage alert. You can only specify up to one filter at this time.
            [<Config.Form>]
            Filters: Create'UsageThresholdFilters list option
            /// Defines the threshold value that triggers the alert.
            [<Config.Form>]
            Gte: int option
            /// The [Billing Meter](/api/billing/meter) ID whose usage is monitored.
            [<Config.Form>]
            Meter: string option
            /// Defines how the alert will behave.
            [<Config.Form>]
            Recurrence: Create'UsageThresholdRecurrence option
        }

    module Create'UsageThreshold =
        let create
            (
                filters: Create'UsageThresholdFilters list option,
                gte: int option,
                meter: string option,
                recurrence: Create'UsageThresholdRecurrence option
            ) : Create'UsageThreshold
            =
            {
              Filters = filters
              Gte = gte
              Meter = meter
              Recurrence = recurrence
            }

    type CreateOptions =
        {
            /// The type of alert to create.
            [<Config.Form>]
            AlertType: Create'AlertType
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The title of the alert.
            [<Config.Form>]
            Title: string
            /// The configuration of the usage threshold.
            [<Config.Form>]
            UsageThreshold: Create'UsageThreshold option
        }

    module CreateOptions =
        let create
            (
                alertType: Create'AlertType,
                title: string
            ) : CreateOptions
            =
            {
              AlertType = alertType
              Title = title
              Expand = None
              UsageThreshold = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Lists billing active and inactive alerts</p>
    let List settings (options: ListOptions) =
        let qs = [("alert_type", options.AlertType |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("meter", options.Meter |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/billing/alerts"
        |> RestApi.getAsync<StripeList<BillingAlert>> settings qs

    ///<p>Creates a billing alert</p>
    let Create settings (options: CreateOptions) =
        $"/v1/billing/alerts"
        |> RestApi.postAsync<_, BillingAlert> settings (Map.empty) options

    ///<p>Retrieves a billing alert given an ID</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/billing/alerts/{options.Id}"
        |> RestApi.getAsync<BillingAlert> settings qs

module BillingAlertsActivate =

    type ActivateOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module ActivateOptions =
        let create
            (
                id: string
            ) : ActivateOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Reactivates this alert, allowing it to trigger again.</p>
    let Activate settings (options: ActivateOptions) =
        $"/v1/billing/alerts/{options.Id}/activate"
        |> RestApi.postAsync<_, BillingAlert> settings (Map.empty) options

module BillingAlertsArchive =

    type ArchiveOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module ArchiveOptions =
        let create
            (
                id: string
            ) : ArchiveOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Archives this alert, removing it from the list view and APIs. This is non-reversible.</p>
    let Archive settings (options: ArchiveOptions) =
        $"/v1/billing/alerts/{options.Id}/archive"
        |> RestApi.postAsync<_, BillingAlert> settings (Map.empty) options

module BillingAlertsDeactivate =

    type DeactivateOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module DeactivateOptions =
        let create
            (
                id: string
            ) : DeactivateOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Deactivates this alert, preventing it from triggering.</p>
    let Deactivate settings (options: DeactivateOptions) =
        $"/v1/billing/alerts/{options.Id}/deactivate"
        |> RestApi.postAsync<_, BillingAlert> settings (Map.empty) options

module BillingCreditBalanceSummary =

    type RetrieveOptions =
        {
            /// The customer whose credit balance summary you're retrieving.
            [<Config.Query>]
            Customer: string option
            /// The account representing the customer whose credit balance summary you're retrieving.
            [<Config.Query>]
            CustomerAccount: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// The filter criteria for the credit balance summary.
            [<Config.Query>]
            Filter: Map<string, string>
        }

    module RetrieveOptions =
        let create
            (
                filter: Map<string, string>
            ) : RetrieveOptions
            =
            {
              Filter = filter
              Customer = None
              CustomerAccount = None
              Expand = None
            }

    ///<p>Retrieves the credit balance summary for a customer.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("expand", options.Expand |> box); ("filter", options.Filter |> box)] |> Map.ofList
        $"/v1/billing/credit_balance_summary"
        |> RestApi.getAsync<BillingCreditBalanceSummary> settings qs

module BillingCreditBalanceTransactions =

    type ListOptions =
        {
            /// The credit grant for which to fetch credit balance transactions.
            [<Config.Query>]
            CreditGrant: string option
            /// The customer whose credit balance transactions you're retrieving.
            [<Config.Query>]
            Customer: string option
            /// The account representing the customer whose credit balance transactions you're retrieving.
            [<Config.Query>]
            CustomerAccount: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
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
                creditGrant: string option,
                customer: string option,
                customerAccount: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              CreditGrant = creditGrant
              Customer = customer
              CustomerAccount = customerAccount
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Unique identifier for the object.
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Retrieve a list of credit balance transactions.</p>
    let List settings (options: ListOptions) =
        let qs = [("credit_grant", options.CreditGrant |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/billing/credit_balance_transactions"
        |> RestApi.getAsync<StripeList<BillingCreditBalanceTransaction>> settings qs

    ///<p>Retrieves a credit balance transaction.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/billing/credit_balance_transactions/{options.Id}"
        |> RestApi.getAsync<BillingCreditBalanceTransaction> settings qs

module BillingCreditGrants =

    type ListOptions =
        {
            /// Only return credit grants for this customer.
            [<Config.Query>]
            Customer: string option
            /// Only return credit grants for this account representing the customer.
            [<Config.Query>]
            CustomerAccount: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
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
                customer: string option,
                customerAccount: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Customer = customer
              CustomerAccount = customerAccount
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    type Create'AmountMonetary =
        {
            /// Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) of the `value` parameter.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// A positive integer representing the amount of the credit grant.
            [<Config.Form>]
            Value: int option
        }

    module Create'AmountMonetary =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                value: int option
            ) : Create'AmountMonetary
            =
            {
              Currency = currency
              Value = value
            }

    type Create'AmountType = | Monetary

    type Create'Amount =
        {
            /// The monetary amount.
            [<Config.Form>]
            Monetary: Create'AmountMonetary option
            /// The type of this amount. We currently only support `monetary` billing credits.
            [<Config.Form>]
            Type: Create'AmountType option
        }

    module Create'Amount =
        let create
            (
                monetary: Create'AmountMonetary option,
                ``type``: Create'AmountType option
            ) : Create'Amount
            =
            {
              Monetary = monetary
              Type = ``type``
            }

    type Create'ApplicabilityConfigScopePriceType = | Metered

    type Create'ApplicabilityConfigScopePrices =
        {
            /// The price ID this credit grant should apply to.
            [<Config.Form>]
            Id: string option
        }

    module Create'ApplicabilityConfigScopePrices =
        let create
            (
                id: string option
            ) : Create'ApplicabilityConfigScopePrices
            =
            {
              Id = id
            }

    type Create'ApplicabilityConfigScope =
        {
            /// The price type that credit grants can apply to. We currently only support the `metered` price type. Cannot be used in combination with `prices`.
            [<Config.Form>]
            PriceType: Create'ApplicabilityConfigScopePriceType option
            /// A list of prices that the credit grant can apply to. We currently only support the `metered` prices. Cannot be used in combination with `price_type`.
            [<Config.Form>]
            Prices: Create'ApplicabilityConfigScopePrices list option
        }

    module Create'ApplicabilityConfigScope =
        let create
            (
                priceType: Create'ApplicabilityConfigScopePriceType option,
                prices: Create'ApplicabilityConfigScopePrices list option
            ) : Create'ApplicabilityConfigScope
            =
            {
              PriceType = priceType
              Prices = prices
            }

    type Create'ApplicabilityConfig =
        {
            /// Specify the scope of this applicability config.
            [<Config.Form>]
            Scope: Create'ApplicabilityConfigScope option
        }

    module Create'ApplicabilityConfig =
        let create
            (
                scope: Create'ApplicabilityConfigScope option
            ) : Create'ApplicabilityConfig
            =
            {
              Scope = scope
            }

    type Create'Category =
        | Paid
        | Promotional

    type CreateOptions =
        {
            /// Amount of this credit grant.
            [<Config.Form>]
            Amount: Create'Amount
            /// Configuration specifying what this credit grant applies to. We currently only support `metered` prices that have a [Billing Meter](https://docs.stripe.com/api/billing/meter) attached to them.
            [<Config.Form>]
            ApplicabilityConfig: Create'ApplicabilityConfig
            /// The category of this credit grant. It defaults to `paid` if not specified.
            [<Config.Form>]
            Category: Create'Category option
            /// ID of the customer receiving the billing credits.
            [<Config.Form>]
            Customer: string option
            /// ID of the account representing the customer receiving the billing credits.
            [<Config.Form>]
            CustomerAccount: string option
            /// The time when the billing credits become effective-when they're eligible for use. It defaults to the current timestamp if not specified.
            [<Config.Form>]
            EffectiveAt: DateTime option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The time when the billing credits expire. If not specified, the billing credits don't expire.
            [<Config.Form>]
            ExpiresAt: DateTime option
            /// Set of key-value pairs that you can attach to an object. You can use this to store additional information about the object (for example, cost basis) in a structured format.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// A descriptive name shown in the Dashboard.
            [<Config.Form>]
            Name: string option
            /// The desired priority for applying this credit grant. If not specified, it will be set to the default value of 50. The highest priority is 0 and the lowest is 100.
            [<Config.Form>]
            Priority: int option
        }

    module CreateOptions =
        let create
            (
                amount: Create'Amount,
                applicabilityConfig: Create'ApplicabilityConfig
            ) : CreateOptions
            =
            {
              Amount = amount
              ApplicabilityConfig = applicabilityConfig
              Category = None
              Customer = None
              CustomerAccount = None
              EffectiveAt = None
              Expand = None
              ExpiresAt = None
              Metadata = None
              Name = None
              Priority = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Unique identifier for the object.
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    type UpdateOptions =
        {
            /// Unique identifier for the object.
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The time when the billing credits created by this credit grant expire. If set to empty, the billing credits never expire.
            [<Config.Form>]
            ExpiresAt: Choice<DateTime,string> option
            /// Set of key-value pairs you can attach to an object. You can use this to store additional information about the object (for example, cost basis) in a structured format.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    module UpdateOptions =
        let create
            (
                id: string
            ) : UpdateOptions
            =
            {
              Id = id
              Expand = None
              ExpiresAt = None
              Metadata = None
            }

    ///<p>Retrieve a list of credit grants.</p>
    let List settings (options: ListOptions) =
        let qs = [("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/billing/credit_grants"
        |> RestApi.getAsync<StripeList<BillingCreditGrant>> settings qs

    ///<p>Creates a credit grant.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/billing/credit_grants"
        |> RestApi.postAsync<_, BillingCreditGrant> settings (Map.empty) options

    ///<p>Retrieves a credit grant.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/billing/credit_grants/{options.Id}"
        |> RestApi.getAsync<BillingCreditGrant> settings qs

    ///<p>Updates a credit grant.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/billing/credit_grants/{options.Id}"
        |> RestApi.postAsync<_, BillingCreditGrant> settings (Map.empty) options

module BillingCreditGrantsExpire =

    type ExpireOptions =
        {
            /// Unique identifier for the object.
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module ExpireOptions =
        let create
            (
                id: string
            ) : ExpireOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Expires a credit grant.</p>
    let Expire settings (options: ExpireOptions) =
        $"/v1/billing/credit_grants/{options.Id}/expire"
        |> RestApi.postAsync<_, BillingCreditGrant> settings (Map.empty) options

module BillingCreditGrantsVoid =

    type VoidGrantOptions =
        {
            /// Unique identifier for the object.
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module VoidGrantOptions =
        let create
            (
                id: string
            ) : VoidGrantOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>Voids a credit grant.</p>
    let VoidGrant settings (options: VoidGrantOptions) =
        $"/v1/billing/credit_grants/{options.Id}/void"
        |> RestApi.postAsync<_, BillingCreditGrant> settings (Map.empty) options

module BillingMeterEventAdjustments =

    type Create'Cancel =
        {
            /// Unique identifier for the event. You can only cancel events within 24 hours of Stripe receiving them.
            [<Config.Form>]
            Identifier: string option
        }

    module Create'Cancel =
        let create
            (
                identifier: string option
            ) : Create'Cancel
            =
            {
              Identifier = identifier
            }

    type Create'Type = | Cancel

    type CreateOptions =
        {
            /// Specifies which event to cancel.
            [<Config.Form>]
            Cancel: Create'Cancel option
            /// The name of the meter event. Corresponds with the `event_name` field on a meter.
            [<Config.Form>]
            EventName: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Specifies whether to cancel a single event or a range of events for a time period. Time period cancellation is not supported yet.
            [<Config.Form>]
            Type: Create'Type
        }

    module CreateOptions =
        let create
            (
                eventName: string,
                ``type``: Create'Type
            ) : CreateOptions
            =
            {
              EventName = eventName
              Type = ``type``
              Cancel = None
              Expand = None
            }

    ///<p>Creates a billing meter event adjustment.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/billing/meter_event_adjustments"
        |> RestApi.postAsync<_, BillingMeterEventAdjustment> settings (Map.empty) options

module BillingMeterEvents =

    type CreateOptions =
        {
            /// The name of the meter event. Corresponds with the `event_name` field on a meter.
            [<Config.Form>]
            EventName: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A unique identifier for the event. If not provided, one is generated. We recommend using UUID-like identifiers. Stripe enforces uniqueness within a rolling period of at least 24 hours. The enforcement of uniqueness primarily addresses issues arising from accidental retries or other problems occurring within extremely brief time intervals. This approach helps prevent duplicate entries and ensures data integrity in high-frequency operations.
            [<Config.Form>]
            Identifier: string option
            /// The payload of the event. This must contain the fields corresponding to a meter's `customer_mapping.event_payload_key` (default is `stripe_customer_id`) and `value_settings.event_payload_key` (default is `value`). Read more about the [payload](https://docs.stripe.com/billing/subscriptions/usage-based/meters/configure#meter-configuration-attributes).
            [<Config.Form>]
            Payload: Map<string, string>
            /// The time of the event. Measured in seconds since the Unix epoch. Must be within the past 35 calendar days or up to 5 minutes in the future. Defaults to current timestamp if not specified.
            [<Config.Form>]
            Timestamp: DateTime option
        }

    module CreateOptions =
        let create
            (
                eventName: string,
                payload: Map<string, string>
            ) : CreateOptions
            =
            {
              EventName = eventName
              Payload = payload
              Expand = None
              Identifier = None
              Timestamp = None
            }

    ///<p>Creates a billing meter event.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/billing/meter_events"
        |> RestApi.postAsync<_, BillingMeterEvent> settings (Map.empty) options

module BillingMeters =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Filter results to only include meters with the given status.
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                status: string option
            ) : ListOptions
            =
            {
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              Status = status
            }

    type Create'CustomerMappingType = | ById

    type Create'CustomerMapping =
        {
            /// The key in the meter event payload to use for mapping the event to a customer.
            [<Config.Form>]
            EventPayloadKey: string option
            /// The method for mapping a meter event to a customer. Must be `by_id`.
            [<Config.Form>]
            Type: Create'CustomerMappingType option
        }

    module Create'CustomerMapping =
        let create
            (
                eventPayloadKey: string option,
                ``type``: Create'CustomerMappingType option
            ) : Create'CustomerMapping
            =
            {
              EventPayloadKey = eventPayloadKey
              Type = ``type``
            }

    type Create'DefaultAggregationFormula =
        | Count
        | Last
        | Sum

    type Create'DefaultAggregation =
        {
            /// Specifies how events are aggregated.
            [<Config.Form>]
            Formula: Create'DefaultAggregationFormula option
        }

    module Create'DefaultAggregation =
        let create
            (
                formula: Create'DefaultAggregationFormula option
            ) : Create'DefaultAggregation
            =
            {
              Formula = formula
            }

    type Create'EventTimeWindow =
        | Day
        | Hour

    type Create'ValueSettings =
        {
            /// The key in the usage event payload to use as the value for this meter. For example, if the event payload contains usage on a `bytes_used` field, then set the event_payload_key to "bytes_used".
            [<Config.Form>]
            EventPayloadKey: string option
        }

    module Create'ValueSettings =
        let create
            (
                eventPayloadKey: string option
            ) : Create'ValueSettings
            =
            {
              EventPayloadKey = eventPayloadKey
            }

    type CreateOptions =
        {
            /// Fields that specify how to map a meter event to a customer.
            [<Config.Form>]
            CustomerMapping: Create'CustomerMapping option
            /// The default settings to aggregate a meter's events with.
            [<Config.Form>]
            DefaultAggregation: Create'DefaultAggregation
            /// The meter’s name. Not visible to the customer.
            [<Config.Form>]
            DisplayName: string
            /// The name of the meter event to record usage for. Corresponds with the `event_name` field on meter events.
            [<Config.Form>]
            EventName: string
            /// The time window which meter events have been pre-aggregated for, if any.
            [<Config.Form>]
            EventTimeWindow: Create'EventTimeWindow option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Fields that specify how to calculate a meter event's value.
            [<Config.Form>]
            ValueSettings: Create'ValueSettings option
        }

    module CreateOptions =
        let create
            (
                defaultAggregation: Create'DefaultAggregation,
                displayName: string,
                eventName: string
            ) : CreateOptions
            =
            {
              DefaultAggregation = defaultAggregation
              DisplayName = displayName
              EventName = eventName
              CustomerMapping = None
              EventTimeWindow = None
              Expand = None
              ValueSettings = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    module RetrieveOptions =
        let create
            (
                id: string
            ) : RetrieveOptions
            =
            {
              Id = id
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Id: string
            /// The meter’s name. Not visible to the customer.
            [<Config.Form>]
            DisplayName: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module UpdateOptions =
        let create
            (
                id: string
            ) : UpdateOptions
            =
            {
              Id = id
              DisplayName = None
              Expand = None
            }

    ///<p>Retrieve a list of billing meters.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/billing/meters"
        |> RestApi.getAsync<StripeList<BillingMeter>> settings qs

    ///<p>Creates a billing meter.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/billing/meters"
        |> RestApi.postAsync<_, BillingMeter> settings (Map.empty) options

    ///<p>Retrieves a billing meter given an ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/billing/meters/{options.Id}"
        |> RestApi.getAsync<BillingMeter> settings qs

    ///<p>Updates a billing meter.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/billing/meters/{options.Id}"
        |> RestApi.postAsync<_, BillingMeter> settings (Map.empty) options

module BillingMetersDeactivate =

    type DeactivateOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module DeactivateOptions =
        let create
            (
                id: string
            ) : DeactivateOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>When a meter is deactivated, no more meter events will be accepted for this meter. You can’t attach a deactivated meter to a price.</p>
    let Deactivate settings (options: DeactivateOptions) =
        $"/v1/billing/meters/{options.Id}/deactivate"
        |> RestApi.postAsync<_, BillingMeter> settings (Map.empty) options

module BillingMetersEventSummaries =

    type ListOptions =
        {
            /// The customer for which to fetch event summaries.
            [<Config.Query>]
            Customer: string
            /// The timestamp from when to stop aggregating meter events (exclusive). Must be aligned with minute boundaries.
            [<Config.Query>]
            EndTime: int
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// Unique identifier for the object.
            [<Config.Path>]
            Id: string
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// The timestamp from when to start aggregating meter events (inclusive). Must be aligned with minute boundaries.
            [<Config.Query>]
            StartTime: int
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Specifies what granularity to use when generating event summaries. If not specified, a single event summary would be returned for the specified time range. For hourly granularity, start and end times must align with hour boundaries (e.g., 00:00, 01:00, ..., 23:00). For daily granularity, start and end times must align with UTC day boundaries (00:00 UTC).
            [<Config.Query>]
            ValueGroupingWindow: string option
        }

    module ListOptions =
        let create
            (
                customer: string,
                endTime: int,
                id: string,
                startTime: int
            ) : ListOptions
            =
            {
              Customer = customer
              EndTime = endTime
              Id = id
              StartTime = startTime
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
              ValueGroupingWindow = None
            }

    ///<p>Retrieve a list of billing meter event summaries.</p>
    let List settings (options: ListOptions) =
        let qs = [("customer", options.Customer |> box); ("end_time", options.EndTime |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("start_time", options.StartTime |> box); ("starting_after", options.StartingAfter |> box); ("value_grouping_window", options.ValueGroupingWindow |> box)] |> Map.ofList
        $"/v1/billing/meters/{options.Id}/event_summaries"
        |> RestApi.getAsync<StripeList<BillingMeterEventSummary>> settings qs

module BillingMetersReactivate =

    type ReactivateOptions =
        {
            [<Config.Path>]
            Id: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module ReactivateOptions =
        let create
            (
                id: string
            ) : ReactivateOptions
            =
            {
              Id = id
              Expand = None
            }

    ///<p>When a meter is reactivated, events for this meter can be accepted and you can attach the meter to a price.</p>
    let Reactivate settings (options: ReactivateOptions) =
        $"/v1/billing/meters/{options.Id}/reactivate"
        |> RestApi.postAsync<_, BillingMeter> settings (Map.empty) options

module CustomerSessions =

    type Create'ComponentsBuyButton =
        {
            /// Whether the buy button is enabled.
            [<Config.Form>]
            Enabled: bool option
        }

    module Create'ComponentsBuyButton =
        let create
            (
                enabled: bool option
            ) : Create'ComponentsBuyButton
            =
            {
              Enabled = enabled
            }

    type Create'ComponentsCustomerSheetFeaturesPaymentMethodAllowRedisplayFilters =
        | Always
        | Limited
        | Unspecified

    type Create'ComponentsCustomerSheetFeaturesPaymentMethodRemove =
        | Disabled
        | Enabled

    type Create'ComponentsCustomerSheetFeatures =
        {
            /// A list of [`allow_redisplay`](https://docs.stripe.com/api/payment_methods/object#payment_method_object-allow_redisplay) values that controls which saved payment methods the customer sheet displays by filtering to only show payment methods with an `allow_redisplay` value that is present in this list.
            /// If not specified, defaults to ["always"]. In order to display all saved payment methods, specify ["always", "limited", "unspecified"].
            [<Config.Form>]
            PaymentMethodAllowRedisplayFilters:
                Create'ComponentsCustomerSheetFeaturesPaymentMethodAllowRedisplayFilters list option
            /// Controls whether the customer sheet displays the option to remove a saved payment method."
            /// Allowing buyers to remove their saved payment methods impacts subscriptions that depend on that payment method. Removing the payment method detaches the [`customer` object](https://docs.stripe.com/api/payment_methods/object#payment_method_object-customer) from that [PaymentMethod](https://docs.stripe.com/api/payment_methods).
            [<Config.Form>]
            PaymentMethodRemove: Create'ComponentsCustomerSheetFeaturesPaymentMethodRemove option
        }

    module Create'ComponentsCustomerSheetFeatures =
        let create
            (
                paymentMethodAllowRedisplayFilters: Create'ComponentsCustomerSheetFeaturesPaymentMethodAllowRedisplayFilters list option,
                paymentMethodRemove: Create'ComponentsCustomerSheetFeaturesPaymentMethodRemove option
            ) : Create'ComponentsCustomerSheetFeatures
            =
            {
              PaymentMethodAllowRedisplayFilters = paymentMethodAllowRedisplayFilters
              PaymentMethodRemove = paymentMethodRemove
            }

    type Create'ComponentsCustomerSheet =
        {
            /// Whether the customer sheet is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// This hash defines whether the customer sheet supports certain features.
            [<Config.Form>]
            Features: Create'ComponentsCustomerSheetFeatures option
        }

    module Create'ComponentsCustomerSheet =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsCustomerSheetFeatures option
            ) : Create'ComponentsCustomerSheet
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsMobilePaymentElementFeaturesPaymentMethodAllowRedisplayFilters =
        | Always
        | Limited
        | Unspecified

    type Create'ComponentsMobilePaymentElementFeaturesPaymentMethodRedisplay =
        | Disabled
        | Enabled

    type Create'ComponentsMobilePaymentElementFeaturesPaymentMethodRemove =
        | Disabled
        | Enabled

    type Create'ComponentsMobilePaymentElementFeaturesPaymentMethodSave =
        | Disabled
        | Enabled

    type Create'ComponentsMobilePaymentElementFeaturesPaymentMethodSaveAllowRedisplayOverride =
        | Always
        | Limited
        | Unspecified

    type Create'ComponentsMobilePaymentElementFeatures =
        {
            /// A list of [`allow_redisplay`](https://docs.stripe.com/api/payment_methods/object#payment_method_object-allow_redisplay) values that controls which saved payment methods the mobile payment element displays by filtering to only show payment methods with an `allow_redisplay` value that is present in this list.
            /// If not specified, defaults to ["always"]. In order to display all saved payment methods, specify ["always", "limited", "unspecified"].
            [<Config.Form>]
            PaymentMethodAllowRedisplayFilters:
                Create'ComponentsMobilePaymentElementFeaturesPaymentMethodAllowRedisplayFilters list option
            /// Controls whether or not the mobile payment element shows saved payment methods.
            [<Config.Form>]
            PaymentMethodRedisplay: Create'ComponentsMobilePaymentElementFeaturesPaymentMethodRedisplay option
            /// Controls whether the mobile payment element displays the option to remove a saved payment method."
            /// Allowing buyers to remove their saved payment methods impacts subscriptions that depend on that payment method. Removing the payment method detaches the [`customer` object](https://docs.stripe.com/api/payment_methods/object#payment_method_object-customer) from that [PaymentMethod](https://docs.stripe.com/api/payment_methods).
            [<Config.Form>]
            PaymentMethodRemove: Create'ComponentsMobilePaymentElementFeaturesPaymentMethodRemove option
            /// Controls whether the mobile payment element displays a checkbox offering to save a new payment method.
            /// If a customer checks the box, the [`allow_redisplay`](https://docs.stripe.com/api/payment_methods/object#payment_method_object-allow_redisplay) value on the PaymentMethod is set to `'always'` at confirmation time. For PaymentIntents, the [`setup_future_usage`](https://docs.stripe.com/api/payment_intents/object#payment_intent_object-setup_future_usage) value is also set to the value defined in `payment_method_save_usage`.
            [<Config.Form>]
            PaymentMethodSave: Create'ComponentsMobilePaymentElementFeaturesPaymentMethodSave option
            /// Allows overriding the value of allow_override when saving a new payment method when payment_method_save is set to disabled. Use values: "always", "limited", or "unspecified".
            /// If not specified, defaults to `nil` (no override value).
            [<Config.Form>]
            PaymentMethodSaveAllowRedisplayOverride:
                Create'ComponentsMobilePaymentElementFeaturesPaymentMethodSaveAllowRedisplayOverride option
        }

    module Create'ComponentsMobilePaymentElementFeatures =
        let create
            (
                paymentMethodAllowRedisplayFilters: Create'ComponentsMobilePaymentElementFeaturesPaymentMethodAllowRedisplayFilters list option,
                paymentMethodRedisplay: Create'ComponentsMobilePaymentElementFeaturesPaymentMethodRedisplay option,
                paymentMethodRemove: Create'ComponentsMobilePaymentElementFeaturesPaymentMethodRemove option,
                paymentMethodSave: Create'ComponentsMobilePaymentElementFeaturesPaymentMethodSave option,
                paymentMethodSaveAllowRedisplayOverride: Create'ComponentsMobilePaymentElementFeaturesPaymentMethodSaveAllowRedisplayOverride option
            ) : Create'ComponentsMobilePaymentElementFeatures
            =
            {
              PaymentMethodAllowRedisplayFilters = paymentMethodAllowRedisplayFilters
              PaymentMethodRedisplay = paymentMethodRedisplay
              PaymentMethodRemove = paymentMethodRemove
              PaymentMethodSave = paymentMethodSave
              PaymentMethodSaveAllowRedisplayOverride = paymentMethodSaveAllowRedisplayOverride
            }

    type Create'ComponentsMobilePaymentElement =
        {
            /// Whether the mobile payment element is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// This hash defines whether the mobile payment element supports certain features.
            [<Config.Form>]
            Features: Create'ComponentsMobilePaymentElementFeatures option
        }

    module Create'ComponentsMobilePaymentElement =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsMobilePaymentElementFeatures option
            ) : Create'ComponentsMobilePaymentElement
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsPaymentElementFeaturesPaymentMethodAllowRedisplayFilters =
        | Always
        | Limited
        | Unspecified

    type Create'ComponentsPaymentElementFeaturesPaymentMethodRedisplay =
        | Disabled
        | Enabled

    type Create'ComponentsPaymentElementFeaturesPaymentMethodRemove =
        | Disabled
        | Enabled

    type Create'ComponentsPaymentElementFeaturesPaymentMethodSave =
        | Disabled
        | Enabled

    type Create'ComponentsPaymentElementFeaturesPaymentMethodSaveUsage =
        | OffSession
        | OnSession

    type Create'ComponentsPaymentElementFeatures =
        {
            /// A list of [`allow_redisplay`](https://docs.stripe.com/api/payment_methods/object#payment_method_object-allow_redisplay) values that controls which saved payment methods the Payment Element displays by filtering to only show payment methods with an `allow_redisplay` value that is present in this list.
            /// If not specified, defaults to ["always"]. In order to display all saved payment methods, specify ["always", "limited", "unspecified"].
            [<Config.Form>]
            PaymentMethodAllowRedisplayFilters:
                Create'ComponentsPaymentElementFeaturesPaymentMethodAllowRedisplayFilters list option
            /// Controls whether or not the Payment Element shows saved payment methods. This parameter defaults to `disabled`.
            [<Config.Form>]
            PaymentMethodRedisplay: Create'ComponentsPaymentElementFeaturesPaymentMethodRedisplay option
            /// Determines the max number of saved payment methods for the Payment Element to display. This parameter defaults to `3`. The maximum redisplay limit is `10`.
            [<Config.Form>]
            PaymentMethodRedisplayLimit: int option
            /// Controls whether the Payment Element displays the option to remove a saved payment method. This parameter defaults to `disabled`.
            /// Allowing buyers to remove their saved payment methods impacts subscriptions that depend on that payment method. Removing the payment method detaches the [`customer` object](https://docs.stripe.com/api/payment_methods/object#payment_method_object-customer) from that [PaymentMethod](https://docs.stripe.com/api/payment_methods).
            [<Config.Form>]
            PaymentMethodRemove: Create'ComponentsPaymentElementFeaturesPaymentMethodRemove option
            /// Controls whether the Payment Element displays a checkbox offering to save a new payment method. This parameter defaults to `disabled`.
            /// If a customer checks the box, the [`allow_redisplay`](https://docs.stripe.com/api/payment_methods/object#payment_method_object-allow_redisplay) value on the PaymentMethod is set to `'always'` at confirmation time. For PaymentIntents, the [`setup_future_usage`](https://docs.stripe.com/api/payment_intents/object#payment_intent_object-setup_future_usage) value is also set to the value defined in `payment_method_save_usage`.
            [<Config.Form>]
            PaymentMethodSave: Create'ComponentsPaymentElementFeaturesPaymentMethodSave option
            /// When using PaymentIntents and the customer checks the save checkbox, this field determines the [`setup_future_usage`](https://docs.stripe.com/api/payment_intents/object#payment_intent_object-setup_future_usage) value used to confirm the PaymentIntent.
            /// When using SetupIntents, directly configure the [`usage`](https://docs.stripe.com/api/setup_intents/object#setup_intent_object-usage) value on SetupIntent creation.
            [<Config.Form>]
            PaymentMethodSaveUsage: Create'ComponentsPaymentElementFeaturesPaymentMethodSaveUsage option
        }

    module Create'ComponentsPaymentElementFeatures =
        let create
            (
                paymentMethodAllowRedisplayFilters: Create'ComponentsPaymentElementFeaturesPaymentMethodAllowRedisplayFilters list option,
                paymentMethodRedisplay: Create'ComponentsPaymentElementFeaturesPaymentMethodRedisplay option,
                paymentMethodRedisplayLimit: int option,
                paymentMethodRemove: Create'ComponentsPaymentElementFeaturesPaymentMethodRemove option,
                paymentMethodSave: Create'ComponentsPaymentElementFeaturesPaymentMethodSave option,
                paymentMethodSaveUsage: Create'ComponentsPaymentElementFeaturesPaymentMethodSaveUsage option
            ) : Create'ComponentsPaymentElementFeatures
            =
            {
              PaymentMethodAllowRedisplayFilters = paymentMethodAllowRedisplayFilters
              PaymentMethodRedisplay = paymentMethodRedisplay
              PaymentMethodRedisplayLimit = paymentMethodRedisplayLimit
              PaymentMethodRemove = paymentMethodRemove
              PaymentMethodSave = paymentMethodSave
              PaymentMethodSaveUsage = paymentMethodSaveUsage
            }

    type Create'ComponentsPaymentElement =
        {
            /// Whether the Payment Element is enabled.
            [<Config.Form>]
            Enabled: bool option
            /// This hash defines whether the Payment Element supports certain features.
            [<Config.Form>]
            Features: Create'ComponentsPaymentElementFeatures option
        }

    module Create'ComponentsPaymentElement =
        let create
            (
                enabled: bool option,
                features: Create'ComponentsPaymentElementFeatures option
            ) : Create'ComponentsPaymentElement
            =
            {
              Enabled = enabled
              Features = features
            }

    type Create'ComponentsPricingTable =
        {
            /// Whether the pricing table is enabled.
            [<Config.Form>]
            Enabled: bool option
        }

    module Create'ComponentsPricingTable =
        let create
            (
                enabled: bool option
            ) : Create'ComponentsPricingTable
            =
            {
              Enabled = enabled
            }

    type Create'Components =
        {
            /// Configuration for buy button.
            [<Config.Form>]
            BuyButton: Create'ComponentsBuyButton option
            /// Configuration for the customer sheet.
            [<Config.Form>]
            CustomerSheet: Create'ComponentsCustomerSheet option
            /// Configuration for the mobile payment element.
            [<Config.Form>]
            MobilePaymentElement: Create'ComponentsMobilePaymentElement option
            /// Configuration for the Payment Element.
            [<Config.Form>]
            PaymentElement: Create'ComponentsPaymentElement option
            /// Configuration for the pricing table.
            [<Config.Form>]
            PricingTable: Create'ComponentsPricingTable option
        }

    module Create'Components =
        let create
            (
                buyButton: Create'ComponentsBuyButton option,
                customerSheet: Create'ComponentsCustomerSheet option,
                mobilePaymentElement: Create'ComponentsMobilePaymentElement option,
                paymentElement: Create'ComponentsPaymentElement option,
                pricingTable: Create'ComponentsPricingTable option
            ) : Create'Components
            =
            {
              BuyButton = buyButton
              CustomerSheet = customerSheet
              MobilePaymentElement = mobilePaymentElement
              PaymentElement = paymentElement
              PricingTable = pricingTable
            }

    type CreateOptions =
        {
            /// Configuration for each component. At least 1 component must be enabled.
            [<Config.Form>]
            Components: Create'Components
            /// The ID of an existing customer for which to create the Customer Session.
            [<Config.Form>]
            Customer: string option
            /// The ID of an existing Account for which to create the Customer Session.
            [<Config.Form>]
            CustomerAccount: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CreateOptions =
        let create
            (
                components: Create'Components
            ) : CreateOptions
            =
            {
              Components = components
              Customer = None
              CustomerAccount = None
              Expand = None
            }

    ///<p>Creates a Customer Session object that includes a single-use client secret that you can use on your front-end to grant client-side API access for certain customer resources.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/customer_sessions"
        |> RestApi.postAsync<_, CustomerSession> settings (Map.empty) options

module InvoicePayments =

    type ListOptions =
        {
            /// Only return invoice payments that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// The identifier of the invoice whose payments to return.
            [<Config.Query>]
            Invoice: string option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// The payment details of the invoice payments to return.
            [<Config.Query>]
            Payment: Map<string, string> option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// The status of the invoice payments to return.
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                created: int option,
                endingBefore: string option,
                expand: string list option,
                invoice: string option,
                limit: int option,
                payment: Map<string, string> option,
                startingAfter: string option,
                status: string option
            ) : ListOptions
            =
            {
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Invoice = invoice
              Limit = limit
              Payment = payment
              StartingAfter = startingAfter
              Status = status
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            InvoicePayment: string
        }

    module RetrieveOptions =
        let create
            (
                invoicePayment: string
            ) : RetrieveOptions
            =
            {
              InvoicePayment = invoicePayment
              Expand = None
            }

    ///<p>When retrieving an invoice, there is an includable payments property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of payments.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("payment", options.Payment |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/invoice_payments"
        |> RestApi.getAsync<StripeList<InvoicePayment>> settings qs

    ///<p>Retrieves the invoice payment with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/invoice_payments/{options.InvoicePayment}"
        |> RestApi.getAsync<InvoicePayment> settings qs

module InvoiceRenderingTemplates =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            [<Config.Query>]
            Status: string option
        }

    module ListOptions =
        let create
            (
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option,
                status: string option
            ) : ListOptions
            =
            {
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
              Status = status
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Template: string
            [<Config.Query>]
            Version: int option
        }

    module RetrieveOptions =
        let create
            (
                template: string
            ) : RetrieveOptions
            =
            {
              Template = template
              Expand = None
              Version = None
            }

    ///<p>List all templates, ordered by creation date, with the most recently created template appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/invoice_rendering_templates"
        |> RestApi.getAsync<StripeList<InvoiceRenderingTemplate>> settings qs

    ///<p>Retrieves an invoice rendering template with the given ID. It by default returns the latest version of the template. Optionally, specify a version to see previous versions.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box); ("version", options.Version |> box)] |> Map.ofList
        $"/v1/invoice_rendering_templates/{options.Template}"
        |> RestApi.getAsync<InvoiceRenderingTemplate> settings qs

module InvoiceRenderingTemplatesArchive =

    type ArchiveOptions =
        {
            [<Config.Path>]
            Template: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module ArchiveOptions =
        let create
            (
                template: string
            ) : ArchiveOptions
            =
            {
              Template = template
              Expand = None
            }

    ///<p>Updates the status of an invoice rendering template to ‘archived’ so no new Stripe objects (customers, invoices, etc.) can reference it. The template can also no longer be updated. However, if the template is already set on a Stripe object, it will continue to be applied on invoices generated by it.</p>
    let Archive settings (options: ArchiveOptions) =
        $"/v1/invoice_rendering_templates/{options.Template}/archive"
        |> RestApi.postAsync<_, InvoiceRenderingTemplate> settings (Map.empty) options

module InvoiceRenderingTemplatesUnarchive =

    type UnarchiveOptions =
        {
            [<Config.Path>]
            Template: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module UnarchiveOptions =
        let create
            (
                template: string
            ) : UnarchiveOptions
            =
            {
              Template = template
              Expand = None
            }

    ///<p>Unarchive an invoice rendering template so it can be used on new Stripe objects again.</p>
    let Unarchive settings (options: UnarchiveOptions) =
        $"/v1/invoice_rendering_templates/{options.Template}/unarchive"
        |> RestApi.postAsync<_, InvoiceRenderingTemplate> settings (Map.empty) options

module PaymentMethodConfigurations =

    type ListOptions =
        {
            /// The Connect application to filter by.
            [<Config.Query>]
            Application: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
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
                application: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Application = application
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    type Create'AcssDebitDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'AcssDebitDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'AcssDebitDisplayPreferencePreference option
        }

    module Create'AcssDebitDisplayPreference =
        let create
            (
                preference: Create'AcssDebitDisplayPreferencePreference option
            ) : Create'AcssDebitDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'AcssDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AcssDebitDisplayPreference option
        }

    module Create'AcssDebit =
        let create
            (
                displayPreference: Create'AcssDebitDisplayPreference option
            ) : Create'AcssDebit
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'AffirmDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'AffirmDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'AffirmDisplayPreferencePreference option
        }

    module Create'AffirmDisplayPreference =
        let create
            (
                preference: Create'AffirmDisplayPreferencePreference option
            ) : Create'AffirmDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Affirm =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AffirmDisplayPreference option
        }

    module Create'Affirm =
        let create
            (
                displayPreference: Create'AffirmDisplayPreference option
            ) : Create'Affirm
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'AfterpayClearpayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'AfterpayClearpayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'AfterpayClearpayDisplayPreferencePreference option
        }

    module Create'AfterpayClearpayDisplayPreference =
        let create
            (
                preference: Create'AfterpayClearpayDisplayPreferencePreference option
            ) : Create'AfterpayClearpayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'AfterpayClearpay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AfterpayClearpayDisplayPreference option
        }

    module Create'AfterpayClearpay =
        let create
            (
                displayPreference: Create'AfterpayClearpayDisplayPreference option
            ) : Create'AfterpayClearpay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'AlipayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'AlipayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'AlipayDisplayPreferencePreference option
        }

    module Create'AlipayDisplayPreference =
        let create
            (
                preference: Create'AlipayDisplayPreferencePreference option
            ) : Create'AlipayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Alipay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AlipayDisplayPreference option
        }

    module Create'Alipay =
        let create
            (
                displayPreference: Create'AlipayDisplayPreference option
            ) : Create'Alipay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'AlmaDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'AlmaDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'AlmaDisplayPreferencePreference option
        }

    module Create'AlmaDisplayPreference =
        let create
            (
                preference: Create'AlmaDisplayPreferencePreference option
            ) : Create'AlmaDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Alma =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AlmaDisplayPreference option
        }

    module Create'Alma =
        let create
            (
                displayPreference: Create'AlmaDisplayPreference option
            ) : Create'Alma
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'AmazonPayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'AmazonPayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'AmazonPayDisplayPreferencePreference option
        }

    module Create'AmazonPayDisplayPreference =
        let create
            (
                preference: Create'AmazonPayDisplayPreferencePreference option
            ) : Create'AmazonPayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'AmazonPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AmazonPayDisplayPreference option
        }

    module Create'AmazonPay =
        let create
            (
                displayPreference: Create'AmazonPayDisplayPreference option
            ) : Create'AmazonPay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'ApplePayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'ApplePayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'ApplePayDisplayPreferencePreference option
        }

    module Create'ApplePayDisplayPreference =
        let create
            (
                preference: Create'ApplePayDisplayPreferencePreference option
            ) : Create'ApplePayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'ApplePay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'ApplePayDisplayPreference option
        }

    module Create'ApplePay =
        let create
            (
                displayPreference: Create'ApplePayDisplayPreference option
            ) : Create'ApplePay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'ApplePayLaterDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'ApplePayLaterDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'ApplePayLaterDisplayPreferencePreference option
        }

    module Create'ApplePayLaterDisplayPreference =
        let create
            (
                preference: Create'ApplePayLaterDisplayPreferencePreference option
            ) : Create'ApplePayLaterDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'ApplePayLater =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'ApplePayLaterDisplayPreference option
        }

    module Create'ApplePayLater =
        let create
            (
                displayPreference: Create'ApplePayLaterDisplayPreference option
            ) : Create'ApplePayLater
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'AuBecsDebitDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'AuBecsDebitDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'AuBecsDebitDisplayPreferencePreference option
        }

    module Create'AuBecsDebitDisplayPreference =
        let create
            (
                preference: Create'AuBecsDebitDisplayPreferencePreference option
            ) : Create'AuBecsDebitDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'AuBecsDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AuBecsDebitDisplayPreference option
        }

    module Create'AuBecsDebit =
        let create
            (
                displayPreference: Create'AuBecsDebitDisplayPreference option
            ) : Create'AuBecsDebit
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'BacsDebitDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'BacsDebitDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'BacsDebitDisplayPreferencePreference option
        }

    module Create'BacsDebitDisplayPreference =
        let create
            (
                preference: Create'BacsDebitDisplayPreferencePreference option
            ) : Create'BacsDebitDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'BacsDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'BacsDebitDisplayPreference option
        }

    module Create'BacsDebit =
        let create
            (
                displayPreference: Create'BacsDebitDisplayPreference option
            ) : Create'BacsDebit
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'BancontactDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'BancontactDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'BancontactDisplayPreferencePreference option
        }

    module Create'BancontactDisplayPreference =
        let create
            (
                preference: Create'BancontactDisplayPreferencePreference option
            ) : Create'BancontactDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Bancontact =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'BancontactDisplayPreference option
        }

    module Create'Bancontact =
        let create
            (
                displayPreference: Create'BancontactDisplayPreference option
            ) : Create'Bancontact
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'BillieDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'BillieDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'BillieDisplayPreferencePreference option
        }

    module Create'BillieDisplayPreference =
        let create
            (
                preference: Create'BillieDisplayPreferencePreference option
            ) : Create'BillieDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Billie =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'BillieDisplayPreference option
        }

    module Create'Billie =
        let create
            (
                displayPreference: Create'BillieDisplayPreference option
            ) : Create'Billie
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'BlikDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'BlikDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'BlikDisplayPreferencePreference option
        }

    module Create'BlikDisplayPreference =
        let create
            (
                preference: Create'BlikDisplayPreferencePreference option
            ) : Create'BlikDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Blik =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'BlikDisplayPreference option
        }

    module Create'Blik =
        let create
            (
                displayPreference: Create'BlikDisplayPreference option
            ) : Create'Blik
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'BoletoDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'BoletoDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'BoletoDisplayPreferencePreference option
        }

    module Create'BoletoDisplayPreference =
        let create
            (
                preference: Create'BoletoDisplayPreferencePreference option
            ) : Create'BoletoDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Boleto =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'BoletoDisplayPreference option
        }

    module Create'Boleto =
        let create
            (
                displayPreference: Create'BoletoDisplayPreference option
            ) : Create'Boleto
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'CardDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'CardDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'CardDisplayPreferencePreference option
        }

    module Create'CardDisplayPreference =
        let create
            (
                preference: Create'CardDisplayPreferencePreference option
            ) : Create'CardDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Card =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'CardDisplayPreference option
        }

    module Create'Card =
        let create
            (
                displayPreference: Create'CardDisplayPreference option
            ) : Create'Card
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'CartesBancairesDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'CartesBancairesDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'CartesBancairesDisplayPreferencePreference option
        }

    module Create'CartesBancairesDisplayPreference =
        let create
            (
                preference: Create'CartesBancairesDisplayPreferencePreference option
            ) : Create'CartesBancairesDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'CartesBancaires =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'CartesBancairesDisplayPreference option
        }

    module Create'CartesBancaires =
        let create
            (
                displayPreference: Create'CartesBancairesDisplayPreference option
            ) : Create'CartesBancaires
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'CashappDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'CashappDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'CashappDisplayPreferencePreference option
        }

    module Create'CashappDisplayPreference =
        let create
            (
                preference: Create'CashappDisplayPreferencePreference option
            ) : Create'CashappDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Cashapp =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'CashappDisplayPreference option
        }

    module Create'Cashapp =
        let create
            (
                displayPreference: Create'CashappDisplayPreference option
            ) : Create'Cashapp
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'CryptoDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'CryptoDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'CryptoDisplayPreferencePreference option
        }

    module Create'CryptoDisplayPreference =
        let create
            (
                preference: Create'CryptoDisplayPreferencePreference option
            ) : Create'CryptoDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Crypto =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'CryptoDisplayPreference option
        }

    module Create'Crypto =
        let create
            (
                displayPreference: Create'CryptoDisplayPreference option
            ) : Create'Crypto
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'CustomerBalanceDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'CustomerBalanceDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'CustomerBalanceDisplayPreferencePreference option
        }

    module Create'CustomerBalanceDisplayPreference =
        let create
            (
                preference: Create'CustomerBalanceDisplayPreferencePreference option
            ) : Create'CustomerBalanceDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'CustomerBalance =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'CustomerBalanceDisplayPreference option
        }

    module Create'CustomerBalance =
        let create
            (
                displayPreference: Create'CustomerBalanceDisplayPreference option
            ) : Create'CustomerBalance
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'EpsDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'EpsDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'EpsDisplayPreferencePreference option
        }

    module Create'EpsDisplayPreference =
        let create
            (
                preference: Create'EpsDisplayPreferencePreference option
            ) : Create'EpsDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Eps =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'EpsDisplayPreference option
        }

    module Create'Eps =
        let create
            (
                displayPreference: Create'EpsDisplayPreference option
            ) : Create'Eps
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'FpxDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'FpxDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'FpxDisplayPreferencePreference option
        }

    module Create'FpxDisplayPreference =
        let create
            (
                preference: Create'FpxDisplayPreferencePreference option
            ) : Create'FpxDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Fpx =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'FpxDisplayPreference option
        }

    module Create'Fpx =
        let create
            (
                displayPreference: Create'FpxDisplayPreference option
            ) : Create'Fpx
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'FrMealVoucherConecsDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'FrMealVoucherConecsDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'FrMealVoucherConecsDisplayPreferencePreference option
        }

    module Create'FrMealVoucherConecsDisplayPreference =
        let create
            (
                preference: Create'FrMealVoucherConecsDisplayPreferencePreference option
            ) : Create'FrMealVoucherConecsDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'FrMealVoucherConecs =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'FrMealVoucherConecsDisplayPreference option
        }

    module Create'FrMealVoucherConecs =
        let create
            (
                displayPreference: Create'FrMealVoucherConecsDisplayPreference option
            ) : Create'FrMealVoucherConecs
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'GiropayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'GiropayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'GiropayDisplayPreferencePreference option
        }

    module Create'GiropayDisplayPreference =
        let create
            (
                preference: Create'GiropayDisplayPreferencePreference option
            ) : Create'GiropayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Giropay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'GiropayDisplayPreference option
        }

    module Create'Giropay =
        let create
            (
                displayPreference: Create'GiropayDisplayPreference option
            ) : Create'Giropay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'GooglePayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'GooglePayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'GooglePayDisplayPreferencePreference option
        }

    module Create'GooglePayDisplayPreference =
        let create
            (
                preference: Create'GooglePayDisplayPreferencePreference option
            ) : Create'GooglePayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'GooglePay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'GooglePayDisplayPreference option
        }

    module Create'GooglePay =
        let create
            (
                displayPreference: Create'GooglePayDisplayPreference option
            ) : Create'GooglePay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'GrabpayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'GrabpayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'GrabpayDisplayPreferencePreference option
        }

    module Create'GrabpayDisplayPreference =
        let create
            (
                preference: Create'GrabpayDisplayPreferencePreference option
            ) : Create'GrabpayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Grabpay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'GrabpayDisplayPreference option
        }

    module Create'Grabpay =
        let create
            (
                displayPreference: Create'GrabpayDisplayPreference option
            ) : Create'Grabpay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'IdealDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'IdealDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'IdealDisplayPreferencePreference option
        }

    module Create'IdealDisplayPreference =
        let create
            (
                preference: Create'IdealDisplayPreferencePreference option
            ) : Create'IdealDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Ideal =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'IdealDisplayPreference option
        }

    module Create'Ideal =
        let create
            (
                displayPreference: Create'IdealDisplayPreference option
            ) : Create'Ideal
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'JcbDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'JcbDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'JcbDisplayPreferencePreference option
        }

    module Create'JcbDisplayPreference =
        let create
            (
                preference: Create'JcbDisplayPreferencePreference option
            ) : Create'JcbDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Jcb =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'JcbDisplayPreference option
        }

    module Create'Jcb =
        let create
            (
                displayPreference: Create'JcbDisplayPreference option
            ) : Create'Jcb
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'KakaoPayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'KakaoPayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'KakaoPayDisplayPreferencePreference option
        }

    module Create'KakaoPayDisplayPreference =
        let create
            (
                preference: Create'KakaoPayDisplayPreferencePreference option
            ) : Create'KakaoPayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'KakaoPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'KakaoPayDisplayPreference option
        }

    module Create'KakaoPay =
        let create
            (
                displayPreference: Create'KakaoPayDisplayPreference option
            ) : Create'KakaoPay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'KlarnaDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'KlarnaDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'KlarnaDisplayPreferencePreference option
        }

    module Create'KlarnaDisplayPreference =
        let create
            (
                preference: Create'KlarnaDisplayPreferencePreference option
            ) : Create'KlarnaDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Klarna =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'KlarnaDisplayPreference option
        }

    module Create'Klarna =
        let create
            (
                displayPreference: Create'KlarnaDisplayPreference option
            ) : Create'Klarna
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'KonbiniDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'KonbiniDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'KonbiniDisplayPreferencePreference option
        }

    module Create'KonbiniDisplayPreference =
        let create
            (
                preference: Create'KonbiniDisplayPreferencePreference option
            ) : Create'KonbiniDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Konbini =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'KonbiniDisplayPreference option
        }

    module Create'Konbini =
        let create
            (
                displayPreference: Create'KonbiniDisplayPreference option
            ) : Create'Konbini
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'KrCardDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'KrCardDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'KrCardDisplayPreferencePreference option
        }

    module Create'KrCardDisplayPreference =
        let create
            (
                preference: Create'KrCardDisplayPreferencePreference option
            ) : Create'KrCardDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'KrCard =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'KrCardDisplayPreference option
        }

    module Create'KrCard =
        let create
            (
                displayPreference: Create'KrCardDisplayPreference option
            ) : Create'KrCard
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'LinkDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'LinkDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'LinkDisplayPreferencePreference option
        }

    module Create'LinkDisplayPreference =
        let create
            (
                preference: Create'LinkDisplayPreferencePreference option
            ) : Create'LinkDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Link =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'LinkDisplayPreference option
        }

    module Create'Link =
        let create
            (
                displayPreference: Create'LinkDisplayPreference option
            ) : Create'Link
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'MbWayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'MbWayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'MbWayDisplayPreferencePreference option
        }

    module Create'MbWayDisplayPreference =
        let create
            (
                preference: Create'MbWayDisplayPreferencePreference option
            ) : Create'MbWayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'MbWay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'MbWayDisplayPreference option
        }

    module Create'MbWay =
        let create
            (
                displayPreference: Create'MbWayDisplayPreference option
            ) : Create'MbWay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'MobilepayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'MobilepayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'MobilepayDisplayPreferencePreference option
        }

    module Create'MobilepayDisplayPreference =
        let create
            (
                preference: Create'MobilepayDisplayPreferencePreference option
            ) : Create'MobilepayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Mobilepay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'MobilepayDisplayPreference option
        }

    module Create'Mobilepay =
        let create
            (
                displayPreference: Create'MobilepayDisplayPreference option
            ) : Create'Mobilepay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'MultibancoDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'MultibancoDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'MultibancoDisplayPreferencePreference option
        }

    module Create'MultibancoDisplayPreference =
        let create
            (
                preference: Create'MultibancoDisplayPreferencePreference option
            ) : Create'MultibancoDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Multibanco =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'MultibancoDisplayPreference option
        }

    module Create'Multibanco =
        let create
            (
                displayPreference: Create'MultibancoDisplayPreference option
            ) : Create'Multibanco
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'NaverPayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'NaverPayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'NaverPayDisplayPreferencePreference option
        }

    module Create'NaverPayDisplayPreference =
        let create
            (
                preference: Create'NaverPayDisplayPreferencePreference option
            ) : Create'NaverPayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'NaverPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'NaverPayDisplayPreference option
        }

    module Create'NaverPay =
        let create
            (
                displayPreference: Create'NaverPayDisplayPreference option
            ) : Create'NaverPay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'NzBankAccountDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'NzBankAccountDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'NzBankAccountDisplayPreferencePreference option
        }

    module Create'NzBankAccountDisplayPreference =
        let create
            (
                preference: Create'NzBankAccountDisplayPreferencePreference option
            ) : Create'NzBankAccountDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'NzBankAccount =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'NzBankAccountDisplayPreference option
        }

    module Create'NzBankAccount =
        let create
            (
                displayPreference: Create'NzBankAccountDisplayPreference option
            ) : Create'NzBankAccount
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'OxxoDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'OxxoDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'OxxoDisplayPreferencePreference option
        }

    module Create'OxxoDisplayPreference =
        let create
            (
                preference: Create'OxxoDisplayPreferencePreference option
            ) : Create'OxxoDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Oxxo =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'OxxoDisplayPreference option
        }

    module Create'Oxxo =
        let create
            (
                displayPreference: Create'OxxoDisplayPreference option
            ) : Create'Oxxo
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'P24DisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'P24DisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'P24DisplayPreferencePreference option
        }

    module Create'P24DisplayPreference =
        let create
            (
                preference: Create'P24DisplayPreferencePreference option
            ) : Create'P24DisplayPreference
            =
            {
              Preference = preference
            }

    type Create'P24 =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'P24DisplayPreference option
        }

    module Create'P24 =
        let create
            (
                displayPreference: Create'P24DisplayPreference option
            ) : Create'P24
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'PayByBankDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'PayByBankDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'PayByBankDisplayPreferencePreference option
        }

    module Create'PayByBankDisplayPreference =
        let create
            (
                preference: Create'PayByBankDisplayPreferencePreference option
            ) : Create'PayByBankDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'PayByBank =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PayByBankDisplayPreference option
        }

    module Create'PayByBank =
        let create
            (
                displayPreference: Create'PayByBankDisplayPreference option
            ) : Create'PayByBank
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'PaycoDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'PaycoDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'PaycoDisplayPreferencePreference option
        }

    module Create'PaycoDisplayPreference =
        let create
            (
                preference: Create'PaycoDisplayPreferencePreference option
            ) : Create'PaycoDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Payco =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PaycoDisplayPreference option
        }

    module Create'Payco =
        let create
            (
                displayPreference: Create'PaycoDisplayPreference option
            ) : Create'Payco
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'PaynowDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'PaynowDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'PaynowDisplayPreferencePreference option
        }

    module Create'PaynowDisplayPreference =
        let create
            (
                preference: Create'PaynowDisplayPreferencePreference option
            ) : Create'PaynowDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Paynow =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PaynowDisplayPreference option
        }

    module Create'Paynow =
        let create
            (
                displayPreference: Create'PaynowDisplayPreference option
            ) : Create'Paynow
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'PaypalDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'PaypalDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'PaypalDisplayPreferencePreference option
        }

    module Create'PaypalDisplayPreference =
        let create
            (
                preference: Create'PaypalDisplayPreferencePreference option
            ) : Create'PaypalDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Paypal =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PaypalDisplayPreference option
        }

    module Create'Paypal =
        let create
            (
                displayPreference: Create'PaypalDisplayPreference option
            ) : Create'Paypal
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'PaytoDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'PaytoDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'PaytoDisplayPreferencePreference option
        }

    module Create'PaytoDisplayPreference =
        let create
            (
                preference: Create'PaytoDisplayPreferencePreference option
            ) : Create'PaytoDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Payto =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PaytoDisplayPreference option
        }

    module Create'Payto =
        let create
            (
                displayPreference: Create'PaytoDisplayPreference option
            ) : Create'Payto
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'PixDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'PixDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'PixDisplayPreferencePreference option
        }

    module Create'PixDisplayPreference =
        let create
            (
                preference: Create'PixDisplayPreferencePreference option
            ) : Create'PixDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Pix =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PixDisplayPreference option
        }

    module Create'Pix =
        let create
            (
                displayPreference: Create'PixDisplayPreference option
            ) : Create'Pix
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'PromptpayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'PromptpayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'PromptpayDisplayPreferencePreference option
        }

    module Create'PromptpayDisplayPreference =
        let create
            (
                preference: Create'PromptpayDisplayPreferencePreference option
            ) : Create'PromptpayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Promptpay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PromptpayDisplayPreference option
        }

    module Create'Promptpay =
        let create
            (
                displayPreference: Create'PromptpayDisplayPreference option
            ) : Create'Promptpay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'RevolutPayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'RevolutPayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'RevolutPayDisplayPreferencePreference option
        }

    module Create'RevolutPayDisplayPreference =
        let create
            (
                preference: Create'RevolutPayDisplayPreferencePreference option
            ) : Create'RevolutPayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'RevolutPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'RevolutPayDisplayPreference option
        }

    module Create'RevolutPay =
        let create
            (
                displayPreference: Create'RevolutPayDisplayPreference option
            ) : Create'RevolutPay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'SamsungPayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'SamsungPayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'SamsungPayDisplayPreferencePreference option
        }

    module Create'SamsungPayDisplayPreference =
        let create
            (
                preference: Create'SamsungPayDisplayPreferencePreference option
            ) : Create'SamsungPayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'SamsungPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'SamsungPayDisplayPreference option
        }

    module Create'SamsungPay =
        let create
            (
                displayPreference: Create'SamsungPayDisplayPreference option
            ) : Create'SamsungPay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'SatispayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'SatispayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'SatispayDisplayPreferencePreference option
        }

    module Create'SatispayDisplayPreference =
        let create
            (
                preference: Create'SatispayDisplayPreferencePreference option
            ) : Create'SatispayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Satispay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'SatispayDisplayPreference option
        }

    module Create'Satispay =
        let create
            (
                displayPreference: Create'SatispayDisplayPreference option
            ) : Create'Satispay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'SepaDebitDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'SepaDebitDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'SepaDebitDisplayPreferencePreference option
        }

    module Create'SepaDebitDisplayPreference =
        let create
            (
                preference: Create'SepaDebitDisplayPreferencePreference option
            ) : Create'SepaDebitDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'SepaDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'SepaDebitDisplayPreference option
        }

    module Create'SepaDebit =
        let create
            (
                displayPreference: Create'SepaDebitDisplayPreference option
            ) : Create'SepaDebit
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'SofortDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'SofortDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'SofortDisplayPreferencePreference option
        }

    module Create'SofortDisplayPreference =
        let create
            (
                preference: Create'SofortDisplayPreferencePreference option
            ) : Create'SofortDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Sofort =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'SofortDisplayPreference option
        }

    module Create'Sofort =
        let create
            (
                displayPreference: Create'SofortDisplayPreference option
            ) : Create'Sofort
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'SunbitDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'SunbitDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'SunbitDisplayPreferencePreference option
        }

    module Create'SunbitDisplayPreference =
        let create
            (
                preference: Create'SunbitDisplayPreferencePreference option
            ) : Create'SunbitDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Sunbit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'SunbitDisplayPreference option
        }

    module Create'Sunbit =
        let create
            (
                displayPreference: Create'SunbitDisplayPreference option
            ) : Create'Sunbit
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'SwishDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'SwishDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'SwishDisplayPreferencePreference option
        }

    module Create'SwishDisplayPreference =
        let create
            (
                preference: Create'SwishDisplayPreferencePreference option
            ) : Create'SwishDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Swish =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'SwishDisplayPreference option
        }

    module Create'Swish =
        let create
            (
                displayPreference: Create'SwishDisplayPreference option
            ) : Create'Swish
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'TwintDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'TwintDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'TwintDisplayPreferencePreference option
        }

    module Create'TwintDisplayPreference =
        let create
            (
                preference: Create'TwintDisplayPreferencePreference option
            ) : Create'TwintDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Twint =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'TwintDisplayPreference option
        }

    module Create'Twint =
        let create
            (
                displayPreference: Create'TwintDisplayPreference option
            ) : Create'Twint
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'UpiDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'UpiDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'UpiDisplayPreferencePreference option
        }

    module Create'UpiDisplayPreference =
        let create
            (
                preference: Create'UpiDisplayPreferencePreference option
            ) : Create'UpiDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Upi =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'UpiDisplayPreference option
        }

    module Create'Upi =
        let create
            (
                displayPreference: Create'UpiDisplayPreference option
            ) : Create'Upi
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'UsBankAccountDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'UsBankAccountDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'UsBankAccountDisplayPreferencePreference option
        }

    module Create'UsBankAccountDisplayPreference =
        let create
            (
                preference: Create'UsBankAccountDisplayPreferencePreference option
            ) : Create'UsBankAccountDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'UsBankAccount =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'UsBankAccountDisplayPreference option
        }

    module Create'UsBankAccount =
        let create
            (
                displayPreference: Create'UsBankAccountDisplayPreference option
            ) : Create'UsBankAccount
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'WechatPayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'WechatPayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'WechatPayDisplayPreferencePreference option
        }

    module Create'WechatPayDisplayPreference =
        let create
            (
                preference: Create'WechatPayDisplayPreferencePreference option
            ) : Create'WechatPayDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'WechatPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'WechatPayDisplayPreference option
        }

    module Create'WechatPay =
        let create
            (
                displayPreference: Create'WechatPayDisplayPreference option
            ) : Create'WechatPay
            =
            {
              DisplayPreference = displayPreference
            }

    type Create'ZipDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Create'ZipDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Create'ZipDisplayPreferencePreference option
        }

    module Create'ZipDisplayPreference =
        let create
            (
                preference: Create'ZipDisplayPreferencePreference option
            ) : Create'ZipDisplayPreference
            =
            {
              Preference = preference
            }

    type Create'Zip =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'ZipDisplayPreference option
        }

    module Create'Zip =
        let create
            (
                displayPreference: Create'ZipDisplayPreference option
            ) : Create'Zip
            =
            {
              DisplayPreference = displayPreference
            }

    type CreateOptions =
        {
            /// Canadian pre-authorized debit payments, check this [page](https://docs.stripe.com/payments/acss-debit) for more details like country availability.
            [<Config.Form>]
            AcssDebit: Create'AcssDebit option
            /// [Affirm](https://www.affirm.com/) gives your customers a way to split purchases over a series of payments. Depending on the purchase, they can pay with four interest-free payments (Split Pay) or pay over a longer term (Installments), which might include interest. Check this [page](https://docs.stripe.com/payments/affirm) for more details like country availability.
            [<Config.Form>]
            Affirm: Create'Affirm option
            /// Afterpay gives your customers a way to pay for purchases in installments, check this [page](https://docs.stripe.com/payments/afterpay-clearpay) for more details like country availability. Afterpay is particularly popular among businesses selling fashion, beauty, and sports products.
            [<Config.Form>]
            AfterpayClearpay: Create'AfterpayClearpay option
            /// Alipay is a digital wallet in China that has more than a billion active users worldwide. Alipay users can pay on the web or on a mobile device using login credentials or their Alipay app. Alipay has a low dispute rate and reduces fraud by authenticating payments using the customer's login credentials. Check this [page](https://docs.stripe.com/payments/alipay) for more details.
            [<Config.Form>]
            Alipay: Create'Alipay option
            /// Alma is a Buy Now, Pay Later payment method that offers customers the ability to pay in 2, 3, or 4 installments.
            [<Config.Form>]
            Alma: Create'Alma option
            /// Amazon Pay is a wallet payment method that lets your customers check out the same way as on Amazon.
            [<Config.Form>]
            AmazonPay: Create'AmazonPay option
            /// Stripe users can accept [Apple Pay](https://stripe.com/payments/apple-pay) in iOS applications in iOS 9 and later, and on the web in Safari starting with iOS 10 or macOS Sierra. There are no additional fees to process Apple Pay payments, and the [pricing](https://stripe.com/pricing) is the same as other card transactions. Check this [page](https://docs.stripe.com/apple-pay) for more details.
            [<Config.Form>]
            ApplePay: Create'ApplePay option
            /// Apple Pay Later, a payment method for customers to buy now and pay later, gives your customers a way to split purchases into four installments across six weeks.
            [<Config.Form>]
            ApplePayLater: Create'ApplePayLater option
            /// Stripe users in Australia can accept Bulk Electronic Clearing System (BECS) direct debit payments from customers with an Australian bank account. Check this [page](https://docs.stripe.com/payments/au-becs-debit) for more details.
            [<Config.Form>]
            AuBecsDebit: Create'AuBecsDebit option
            /// Stripe users in the UK can accept Bacs Direct Debit payments from customers with a UK bank account, check this [page](https://docs.stripe.com/payments/payment-methods/bacs-debit) for more details.
            [<Config.Form>]
            BacsDebit: Create'BacsDebit option
            /// Bancontact is the most popular online payment method in Belgium, with over 15 million cards in circulation. [Customers](https://docs.stripe.com/api/customers) use a Bancontact card or mobile app linked to a Belgian bank account to make online payments that are secure, guaranteed, and confirmed immediately. Check this [page](https://docs.stripe.com/payments/bancontact) for more details.
            [<Config.Form>]
            Bancontact: Create'Bancontact option
            /// Billie is a [single-use](https://docs.stripe.com/payments/payment-methods#usage) payment method that offers businesses Pay by Invoice where they offer payment terms ranging from 7-120 days. Customers are redirected from your website or app, authorize the payment with Billie, then return to your website or app. You get [immediate notification](/payments/payment-methods#payment-notification) of whether the payment succeeded or failed.
            [<Config.Form>]
            Billie: Create'Billie option
            /// BLIK is a [single use](https://docs.stripe.com/payments/payment-methods#usage) payment method that requires customers to authenticate their payments. When customers want to pay online using BLIK, they request a six-digit code from their banking application and enter it into the payment collection form. Check this [page](https://docs.stripe.com/payments/blik) for more details.
            [<Config.Form>]
            Blik: Create'Blik option
            /// Boleto is an official (regulated by the Central Bank of Brazil) payment method in Brazil. Check this [page](https://docs.stripe.com/payments/boleto) for more details.
            [<Config.Form>]
            Boleto: Create'Boleto option
            /// Cards are a popular way for consumers and businesses to pay online or in person. Stripe supports global and local card networks.
            [<Config.Form>]
            Card: Create'Card option
            /// Cartes Bancaires is France's local card network. More than 95% of these cards are co-branded with either Visa or Mastercard, meaning you can process these cards over either Cartes Bancaires or the Visa or Mastercard networks. Check this [page](https://docs.stripe.com/payments/cartes-bancaires) for more details.
            [<Config.Form>]
            CartesBancaires: Create'CartesBancaires option
            /// Cash App is a popular consumer app in the US that allows customers to bank, invest, send, and receive money using their digital wallet. Check this [page](https://docs.stripe.com/payments/cash-app-pay) for more details.
            [<Config.Form>]
            Cashapp: Create'Cashapp option
            /// [Stablecoin payments](https://docs.stripe.com/payments/stablecoin-payments) enable customers to pay in stablecoins like USDC from 100s of wallets including Phantom and Metamask.
            [<Config.Form>]
            Crypto: Create'Crypto option
            /// Uses a customer’s [cash balance](https://docs.stripe.com/payments/customer-balance) for the payment. The cash balance can be funded via a bank transfer. Check this [page](https://docs.stripe.com/payments/bank-transfers) for more details.
            [<Config.Form>]
            CustomerBalance: Create'CustomerBalance option
            /// EPS is an Austria-based payment method that allows customers to complete transactions online using their bank credentials. EPS is supported by all Austrian banks and is accepted by over 80% of Austrian online retailers. Check this [page](https://docs.stripe.com/payments/eps) for more details.
            [<Config.Form>]
            Eps: Create'Eps option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Financial Process Exchange (FPX) is a Malaysia-based payment method that allows customers to complete transactions online using their bank credentials. Bank Negara Malaysia (BNM), the Central Bank of Malaysia, and eleven other major Malaysian financial institutions are members of the PayNet Group, which owns and operates FPX. It is one of the most popular online payment methods in Malaysia, with nearly 90 million transactions in 2018 according to BNM. Check this [page](https://docs.stripe.com/payments/fpx) for more details.
            [<Config.Form>]
            Fpx: Create'Fpx option
            /// Meal vouchers in France, or “titres-restaurant”, is a local benefits program commonly offered by employers for their employees to purchase prepared food and beverages on working days. Check this [page](https://docs.stripe.com/payments/meal-vouchers/fr-meal-vouchers) for more details.
            [<Config.Form>]
            FrMealVoucherConecs: Create'FrMealVoucherConecs option
            /// giropay is a German payment method based on online banking, introduced in 2006. It allows customers to complete transactions online using their online banking environment, with funds debited from their bank account. Depending on their bank, customers confirm payments on giropay using a second factor of authentication or a PIN. giropay accounts for 10% of online checkouts in Germany. Check this [page](https://docs.stripe.com/payments/giropay) for more details.
            [<Config.Form>]
            Giropay: Create'Giropay option
            /// Google Pay allows customers to make payments in your app or website using any credit or debit card saved to their Google Account, including those from Google Play, YouTube, Chrome, or an Android device. Use the Google Pay API to request any credit or debit card stored in your customer's Google account. Check this [page](https://docs.stripe.com/google-pay) for more details.
            [<Config.Form>]
            GooglePay: Create'GooglePay option
            /// GrabPay is a payment method developed by [Grab](https://www.grab.com/sg/consumer/finance/pay/). GrabPay is a digital wallet - customers maintain a balance in their wallets that they pay out with. Check this [page](https://docs.stripe.com/payments/grabpay) for more details.
            [<Config.Form>]
            Grabpay: Create'Grabpay option
            /// iDEAL is a Netherlands-based payment method that allows customers to complete transactions online using their bank credentials. All major Dutch banks are members of Currence, the scheme that operates iDEAL, making it the most popular online payment method in the Netherlands with a share of online transactions close to 55%. Check this [page](https://docs.stripe.com/payments/ideal) for more details.
            [<Config.Form>]
            Ideal: Create'Ideal option
            /// JCB is a credit card company based in Japan. JCB is currently available in Japan to businesses approved by JCB, and available to all businesses in Australia, Canada, Hong Kong, Japan, New Zealand, Singapore, Switzerland, United Kingdom, United States, and all countries in the European Economic Area except Iceland. Check this [page](https://support.stripe.com/questions/accepting-japan-credit-bureau-%28jcb%29-payments) for more details.
            [<Config.Form>]
            Jcb: Create'Jcb option
            /// Kakao Pay is a popular local wallet available in South Korea.
            [<Config.Form>]
            KakaoPay: Create'KakaoPay option
            /// Klarna gives customers a range of [payment options](https://docs.stripe.com/payments/klarna#payment-options) during checkout. Available payment options vary depending on the customer's billing address and the transaction amount. These payment options make it convenient for customers to purchase items in all price ranges. Check this [page](https://docs.stripe.com/payments/klarna) for more details.
            [<Config.Form>]
            Klarna: Create'Klarna option
            /// Konbini allows customers in Japan to pay for bills and online purchases at convenience stores with cash. Check this [page](https://docs.stripe.com/payments/konbini) for more details.
            [<Config.Form>]
            Konbini: Create'Konbini option
            /// Korean cards let users pay using locally issued cards from South Korea.
            [<Config.Form>]
            KrCard: Create'KrCard option
            /// [Link](https://docs.stripe.com/payments/link) is a payment method network. With Link, users save their payment details once, then reuse that information to pay with one click for any business on the network.
            [<Config.Form>]
            Link: Create'Link option
            /// MB WAY is the most popular wallet in Portugal. After entering their phone number in your checkout, customers approve the payment directly in their MB WAY app. Check this [page](https://docs.stripe.com/payments/mb-way) for more details.
            [<Config.Form>]
            MbWay: Create'MbWay option
            /// MobilePay is a [single-use](https://docs.stripe.com/payments/payment-methods#usage) card wallet payment method used in Denmark and Finland. It allows customers to [authenticate and approve](https://docs.stripe.com/payments/payment-methods#customer-actions) payments using the MobilePay app. Check this [page](https://docs.stripe.com/payments/mobilepay) for more details.
            [<Config.Form>]
            Mobilepay: Create'Mobilepay option
            /// Stripe users in Europe and the United States can accept Multibanco payments from customers in Portugal using [Sources](https://stripe.com/docs/sources)—a single integration path for creating payments using any supported method.
            [<Config.Form>]
            Multibanco: Create'Multibanco option
            /// Configuration name.
            [<Config.Form>]
            Name: string option
            /// Naver Pay is a popular local wallet available in South Korea.
            [<Config.Form>]
            NaverPay: Create'NaverPay option
            /// Stripe users in New Zealand can accept Bulk Electronic Clearing System (BECS) direct debit payments from customers with a New Zeland bank account. Check this [page](https://docs.stripe.com/payments/nz-bank-account) for more details.
            [<Config.Form>]
            NzBankAccount: Create'NzBankAccount option
            /// OXXO is a Mexican chain of convenience stores with thousands of locations across Latin America and represents nearly 20% of online transactions in Mexico. OXXO allows customers to pay bills and online purchases in-store with cash. Check this [page](https://docs.stripe.com/payments/oxxo) for more details.
            [<Config.Form>]
            Oxxo: Create'Oxxo option
            /// Przelewy24 is a Poland-based payment method aggregator that allows customers to complete transactions online using bank transfers and other methods. Bank transfers account for 30% of online payments in Poland and Przelewy24 provides a way for customers to pay with over 165 banks. Check this [page](https://docs.stripe.com/payments/p24) for more details.
            [<Config.Form>]
            P24: Create'P24 option
            /// Configuration's parent configuration. Specify to create a child configuration.
            [<Config.Form>]
            Parent: string option
            /// Pay by bank is a redirect payment method backed by bank transfers. A customer is redirected to their bank to authorize a bank transfer for a given amount. This removes a lot of the error risks inherent in waiting for the customer to initiate a transfer themselves, and is less expensive than card payments.
            [<Config.Form>]
            PayByBank: Create'PayByBank option
            /// PAYCO is a [single-use](https://docs.stripe.com/payments/payment-methods#usage local wallet available in South Korea.
            [<Config.Form>]
            Payco: Create'Payco option
            /// PayNow is a Singapore-based payment method that allows customers to make a payment using their preferred app from participating banks and participating non-bank financial institutions. Check this [page](https://docs.stripe.com/payments/paynow) for more details.
            [<Config.Form>]
            Paynow: Create'Paynow option
            /// PayPal, a digital wallet popular with customers in Europe, allows your customers worldwide to pay using their PayPal account. Check this [page](https://docs.stripe.com/payments/paypal) for more details.
            [<Config.Form>]
            Paypal: Create'Paypal option
            /// PayTo is a [real-time](https://docs.stripe.com/payments/real-time) payment method that enables customers in Australia to pay by providing their bank account details. Customers must accept a mandate authorizing you to debit their account. Check this [page](https://docs.stripe.com/payments/payto) for more details.
            [<Config.Form>]
            Payto: Create'Payto option
            /// Pix is a payment method popular in Brazil. When paying with Pix, customers authenticate and approve payments by scanning a QR code in their preferred banking app. Check this [page](https://docs.stripe.com/payments/pix) for more details.
            [<Config.Form>]
            Pix: Create'Pix option
            /// PromptPay is a Thailand-based payment method that allows customers to make a payment using their preferred app from participating banks. Check this [page](https://docs.stripe.com/payments/promptpay) for more details.
            [<Config.Form>]
            Promptpay: Create'Promptpay option
            /// Revolut Pay, developed by Revolut, a global finance app, is a digital wallet payment method. Revolut Pay uses the customer’s stored balance or cards to fund the payment, and offers the option for non-Revolut customers to save their details after their first purchase.
            [<Config.Form>]
            RevolutPay: Create'RevolutPay option
            /// Samsung Pay is a [single-use](https://docs.stripe.com/payments/payment-methods#usage local wallet available in South Korea.
            [<Config.Form>]
            SamsungPay: Create'SamsungPay option
            /// Satispay is a [single-use](https://docs.stripe.com/payments/payment-methods#usage) payment method where customers are required to [authenticate](/payments/payment-methods#customer-actions) their payment. Customers pay by being redirected from your website or app, authorizing the payment with Satispay, then returning to your website or app. You get [immediate notification](/payments/payment-methods#payment-notification) of whether the payment succeeded or failed.
            [<Config.Form>]
            Satispay: Create'Satispay option
            /// The [Single Euro Payments Area (SEPA)](https://en.wikipedia.org/wiki/Single_Euro_Payments_Area) is an initiative of the European Union to simplify payments within and across member countries. SEPA established and enforced banking standards to allow for the direct debiting of every EUR-denominated bank account within the SEPA region, check this [page](https://docs.stripe.com/payments/sepa-debit) for more details.
            [<Config.Form>]
            SepaDebit: Create'SepaDebit option
            /// Stripe users in Europe and the United States can use the [Payment Intents API](https://stripe.com/docs/payments/payment-intents)—a single integration path for creating payments using any supported method—to accept [Sofort](https://www.sofort.com/) payments from customers. Check this [page](https://docs.stripe.com/payments/sofort) for more details.
            [<Config.Form>]
            Sofort: Create'Sofort option
            /// Sunbit is a [single-use](https://docs.stripe.com/payments/payment-methods#usage) payment method where customers choose to pay in 3, 6, or 12 installments. Customers are redirected from your website or app, authorize the payment with Sunbit, then return to your website or app. You get [immediate notification](https://docs.stripe.com/payments/payment-methods#payment-notification) of whether the payment succeeded or failed.
            [<Config.Form>]
            Sunbit: Create'Sunbit option
            /// Swish is a [real-time](https://docs.stripe.com/payments/real-time) payment method popular in Sweden. It allows customers to [authenticate and approve](https://docs.stripe.com/payments/payment-methods#customer-actions) payments using the Swish mobile app and the Swedish BankID mobile app. Check this [page](https://docs.stripe.com/payments/swish) for more details.
            [<Config.Form>]
            Swish: Create'Swish option
            /// Twint is a payment method popular in Switzerland. It allows customers to pay using their mobile phone. Check this [page](https://docs.stripe.com/payments/twint) for more details.
            [<Config.Form>]
            Twint: Create'Twint option
            /// Unified Payment Interface (UPI) is India's leading payment method with exponential growth since it launched in 2016.
            [<Config.Form>]
            Upi: Create'Upi option
            /// Stripe users in the United States can accept ACH direct debit payments from customers with a US bank account using the Automated Clearing House (ACH) payments system operated by Nacha. Check this [page](https://docs.stripe.com/payments/ach-direct-debit) for more details.
            [<Config.Form>]
            UsBankAccount: Create'UsBankAccount option
            /// WeChat, owned by Tencent, is China's leading mobile app with over 1 billion monthly active users. Chinese consumers can use WeChat Pay to pay for goods and services inside of businesses' apps and websites. WeChat Pay users buy most frequently in gaming, e-commerce, travel, online education, and food/nutrition. Check this [page](https://docs.stripe.com/payments/wechat-pay) for more details.
            [<Config.Form>]
            WechatPay: Create'WechatPay option
            /// Zip gives your customers a way to split purchases over a series of payments. Check this [page](https://docs.stripe.com/payments/zip) for more details like country availability.
            [<Config.Form>]
            Zip: Create'Zip option
        }

    module CreateOptions =
        let create
            (
                acssDebit: Create'AcssDebit option,
                affirm: Create'Affirm option,
                afterpayClearpay: Create'AfterpayClearpay option,
                alipay: Create'Alipay option,
                alma: Create'Alma option,
                amazonPay: Create'AmazonPay option,
                applePay: Create'ApplePay option,
                applePayLater: Create'ApplePayLater option,
                auBecsDebit: Create'AuBecsDebit option,
                bacsDebit: Create'BacsDebit option,
                bancontact: Create'Bancontact option,
                billie: Create'Billie option,
                blik: Create'Blik option,
                boleto: Create'Boleto option,
                card: Create'Card option,
                cartesBancaires: Create'CartesBancaires option,
                cashapp: Create'Cashapp option,
                crypto: Create'Crypto option,
                customerBalance: Create'CustomerBalance option,
                eps: Create'Eps option,
                expand: string list option,
                fpx: Create'Fpx option,
                frMealVoucherConecs: Create'FrMealVoucherConecs option,
                giropay: Create'Giropay option,
                googlePay: Create'GooglePay option,
                grabpay: Create'Grabpay option,
                ideal: Create'Ideal option,
                jcb: Create'Jcb option,
                kakaoPay: Create'KakaoPay option,
                klarna: Create'Klarna option,
                konbini: Create'Konbini option,
                krCard: Create'KrCard option,
                link: Create'Link option,
                mbWay: Create'MbWay option,
                mobilepay: Create'Mobilepay option,
                multibanco: Create'Multibanco option,
                name: string option,
                naverPay: Create'NaverPay option,
                nzBankAccount: Create'NzBankAccount option,
                oxxo: Create'Oxxo option,
                p24: Create'P24 option,
                parent: string option,
                payByBank: Create'PayByBank option,
                payco: Create'Payco option,
                paynow: Create'Paynow option,
                paypal: Create'Paypal option,
                payto: Create'Payto option,
                pix: Create'Pix option,
                promptpay: Create'Promptpay option,
                revolutPay: Create'RevolutPay option,
                samsungPay: Create'SamsungPay option,
                satispay: Create'Satispay option,
                sepaDebit: Create'SepaDebit option,
                sofort: Create'Sofort option,
                sunbit: Create'Sunbit option,
                swish: Create'Swish option,
                twint: Create'Twint option,
                upi: Create'Upi option,
                usBankAccount: Create'UsBankAccount option,
                wechatPay: Create'WechatPay option,
                zip: Create'Zip option
            ) : CreateOptions
            =
            {
              AcssDebit = acssDebit
              Affirm = affirm
              AfterpayClearpay = afterpayClearpay
              Alipay = alipay
              Alma = alma
              AmazonPay = amazonPay
              ApplePay = applePay
              ApplePayLater = applePayLater
              AuBecsDebit = auBecsDebit
              BacsDebit = bacsDebit
              Bancontact = bancontact
              Billie = billie
              Blik = blik
              Boleto = boleto
              Card = card
              CartesBancaires = cartesBancaires
              Cashapp = cashapp
              Crypto = crypto
              CustomerBalance = customerBalance
              Eps = eps
              Expand = expand
              Fpx = fpx
              FrMealVoucherConecs = frMealVoucherConecs
              Giropay = giropay
              GooglePay = googlePay
              Grabpay = grabpay
              Ideal = ideal
              Jcb = jcb
              KakaoPay = kakaoPay
              Klarna = klarna
              Konbini = konbini
              KrCard = krCard
              Link = link
              MbWay = mbWay
              Mobilepay = mobilepay
              Multibanco = multibanco
              Name = name
              NaverPay = naverPay
              NzBankAccount = nzBankAccount
              Oxxo = oxxo
              P24 = p24
              Parent = parent
              PayByBank = payByBank
              Payco = payco
              Paynow = paynow
              Paypal = paypal
              Payto = payto
              Pix = pix
              Promptpay = promptpay
              RevolutPay = revolutPay
              SamsungPay = samsungPay
              Satispay = satispay
              SepaDebit = sepaDebit
              Sofort = sofort
              Sunbit = sunbit
              Swish = swish
              Twint = twint
              Upi = upi
              UsBankAccount = usBankAccount
              WechatPay = wechatPay
              Zip = zip
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

    type Update'AcssDebitDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'AcssDebitDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'AcssDebitDisplayPreferencePreference option
        }

    module Update'AcssDebitDisplayPreference =
        let create
            (
                preference: Update'AcssDebitDisplayPreferencePreference option
            ) : Update'AcssDebitDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'AcssDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AcssDebitDisplayPreference option
        }

    module Update'AcssDebit =
        let create
            (
                displayPreference: Update'AcssDebitDisplayPreference option
            ) : Update'AcssDebit
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'AffirmDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'AffirmDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'AffirmDisplayPreferencePreference option
        }

    module Update'AffirmDisplayPreference =
        let create
            (
                preference: Update'AffirmDisplayPreferencePreference option
            ) : Update'AffirmDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Affirm =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AffirmDisplayPreference option
        }

    module Update'Affirm =
        let create
            (
                displayPreference: Update'AffirmDisplayPreference option
            ) : Update'Affirm
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'AfterpayClearpayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'AfterpayClearpayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'AfterpayClearpayDisplayPreferencePreference option
        }

    module Update'AfterpayClearpayDisplayPreference =
        let create
            (
                preference: Update'AfterpayClearpayDisplayPreferencePreference option
            ) : Update'AfterpayClearpayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'AfterpayClearpay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AfterpayClearpayDisplayPreference option
        }

    module Update'AfterpayClearpay =
        let create
            (
                displayPreference: Update'AfterpayClearpayDisplayPreference option
            ) : Update'AfterpayClearpay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'AlipayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'AlipayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'AlipayDisplayPreferencePreference option
        }

    module Update'AlipayDisplayPreference =
        let create
            (
                preference: Update'AlipayDisplayPreferencePreference option
            ) : Update'AlipayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Alipay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AlipayDisplayPreference option
        }

    module Update'Alipay =
        let create
            (
                displayPreference: Update'AlipayDisplayPreference option
            ) : Update'Alipay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'AlmaDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'AlmaDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'AlmaDisplayPreferencePreference option
        }

    module Update'AlmaDisplayPreference =
        let create
            (
                preference: Update'AlmaDisplayPreferencePreference option
            ) : Update'AlmaDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Alma =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AlmaDisplayPreference option
        }

    module Update'Alma =
        let create
            (
                displayPreference: Update'AlmaDisplayPreference option
            ) : Update'Alma
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'AmazonPayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'AmazonPayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'AmazonPayDisplayPreferencePreference option
        }

    module Update'AmazonPayDisplayPreference =
        let create
            (
                preference: Update'AmazonPayDisplayPreferencePreference option
            ) : Update'AmazonPayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'AmazonPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AmazonPayDisplayPreference option
        }

    module Update'AmazonPay =
        let create
            (
                displayPreference: Update'AmazonPayDisplayPreference option
            ) : Update'AmazonPay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'ApplePayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'ApplePayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'ApplePayDisplayPreferencePreference option
        }

    module Update'ApplePayDisplayPreference =
        let create
            (
                preference: Update'ApplePayDisplayPreferencePreference option
            ) : Update'ApplePayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'ApplePay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'ApplePayDisplayPreference option
        }

    module Update'ApplePay =
        let create
            (
                displayPreference: Update'ApplePayDisplayPreference option
            ) : Update'ApplePay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'ApplePayLaterDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'ApplePayLaterDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'ApplePayLaterDisplayPreferencePreference option
        }

    module Update'ApplePayLaterDisplayPreference =
        let create
            (
                preference: Update'ApplePayLaterDisplayPreferencePreference option
            ) : Update'ApplePayLaterDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'ApplePayLater =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'ApplePayLaterDisplayPreference option
        }

    module Update'ApplePayLater =
        let create
            (
                displayPreference: Update'ApplePayLaterDisplayPreference option
            ) : Update'ApplePayLater
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'AuBecsDebitDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'AuBecsDebitDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'AuBecsDebitDisplayPreferencePreference option
        }

    module Update'AuBecsDebitDisplayPreference =
        let create
            (
                preference: Update'AuBecsDebitDisplayPreferencePreference option
            ) : Update'AuBecsDebitDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'AuBecsDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AuBecsDebitDisplayPreference option
        }

    module Update'AuBecsDebit =
        let create
            (
                displayPreference: Update'AuBecsDebitDisplayPreference option
            ) : Update'AuBecsDebit
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'BacsDebitDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'BacsDebitDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'BacsDebitDisplayPreferencePreference option
        }

    module Update'BacsDebitDisplayPreference =
        let create
            (
                preference: Update'BacsDebitDisplayPreferencePreference option
            ) : Update'BacsDebitDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'BacsDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'BacsDebitDisplayPreference option
        }

    module Update'BacsDebit =
        let create
            (
                displayPreference: Update'BacsDebitDisplayPreference option
            ) : Update'BacsDebit
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'BancontactDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'BancontactDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'BancontactDisplayPreferencePreference option
        }

    module Update'BancontactDisplayPreference =
        let create
            (
                preference: Update'BancontactDisplayPreferencePreference option
            ) : Update'BancontactDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Bancontact =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'BancontactDisplayPreference option
        }

    module Update'Bancontact =
        let create
            (
                displayPreference: Update'BancontactDisplayPreference option
            ) : Update'Bancontact
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'BillieDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'BillieDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'BillieDisplayPreferencePreference option
        }

    module Update'BillieDisplayPreference =
        let create
            (
                preference: Update'BillieDisplayPreferencePreference option
            ) : Update'BillieDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Billie =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'BillieDisplayPreference option
        }

    module Update'Billie =
        let create
            (
                displayPreference: Update'BillieDisplayPreference option
            ) : Update'Billie
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'BlikDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'BlikDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'BlikDisplayPreferencePreference option
        }

    module Update'BlikDisplayPreference =
        let create
            (
                preference: Update'BlikDisplayPreferencePreference option
            ) : Update'BlikDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Blik =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'BlikDisplayPreference option
        }

    module Update'Blik =
        let create
            (
                displayPreference: Update'BlikDisplayPreference option
            ) : Update'Blik
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'BoletoDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'BoletoDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'BoletoDisplayPreferencePreference option
        }

    module Update'BoletoDisplayPreference =
        let create
            (
                preference: Update'BoletoDisplayPreferencePreference option
            ) : Update'BoletoDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Boleto =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'BoletoDisplayPreference option
        }

    module Update'Boleto =
        let create
            (
                displayPreference: Update'BoletoDisplayPreference option
            ) : Update'Boleto
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'CardDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'CardDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'CardDisplayPreferencePreference option
        }

    module Update'CardDisplayPreference =
        let create
            (
                preference: Update'CardDisplayPreferencePreference option
            ) : Update'CardDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Card =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'CardDisplayPreference option
        }

    module Update'Card =
        let create
            (
                displayPreference: Update'CardDisplayPreference option
            ) : Update'Card
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'CartesBancairesDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'CartesBancairesDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'CartesBancairesDisplayPreferencePreference option
        }

    module Update'CartesBancairesDisplayPreference =
        let create
            (
                preference: Update'CartesBancairesDisplayPreferencePreference option
            ) : Update'CartesBancairesDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'CartesBancaires =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'CartesBancairesDisplayPreference option
        }

    module Update'CartesBancaires =
        let create
            (
                displayPreference: Update'CartesBancairesDisplayPreference option
            ) : Update'CartesBancaires
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'CashappDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'CashappDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'CashappDisplayPreferencePreference option
        }

    module Update'CashappDisplayPreference =
        let create
            (
                preference: Update'CashappDisplayPreferencePreference option
            ) : Update'CashappDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Cashapp =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'CashappDisplayPreference option
        }

    module Update'Cashapp =
        let create
            (
                displayPreference: Update'CashappDisplayPreference option
            ) : Update'Cashapp
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'CryptoDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'CryptoDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'CryptoDisplayPreferencePreference option
        }

    module Update'CryptoDisplayPreference =
        let create
            (
                preference: Update'CryptoDisplayPreferencePreference option
            ) : Update'CryptoDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Crypto =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'CryptoDisplayPreference option
        }

    module Update'Crypto =
        let create
            (
                displayPreference: Update'CryptoDisplayPreference option
            ) : Update'Crypto
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'CustomerBalanceDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'CustomerBalanceDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'CustomerBalanceDisplayPreferencePreference option
        }

    module Update'CustomerBalanceDisplayPreference =
        let create
            (
                preference: Update'CustomerBalanceDisplayPreferencePreference option
            ) : Update'CustomerBalanceDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'CustomerBalance =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'CustomerBalanceDisplayPreference option
        }

    module Update'CustomerBalance =
        let create
            (
                displayPreference: Update'CustomerBalanceDisplayPreference option
            ) : Update'CustomerBalance
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'EpsDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'EpsDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'EpsDisplayPreferencePreference option
        }

    module Update'EpsDisplayPreference =
        let create
            (
                preference: Update'EpsDisplayPreferencePreference option
            ) : Update'EpsDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Eps =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'EpsDisplayPreference option
        }

    module Update'Eps =
        let create
            (
                displayPreference: Update'EpsDisplayPreference option
            ) : Update'Eps
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'FpxDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'FpxDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'FpxDisplayPreferencePreference option
        }

    module Update'FpxDisplayPreference =
        let create
            (
                preference: Update'FpxDisplayPreferencePreference option
            ) : Update'FpxDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Fpx =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'FpxDisplayPreference option
        }

    module Update'Fpx =
        let create
            (
                displayPreference: Update'FpxDisplayPreference option
            ) : Update'Fpx
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'FrMealVoucherConecsDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'FrMealVoucherConecsDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'FrMealVoucherConecsDisplayPreferencePreference option
        }

    module Update'FrMealVoucherConecsDisplayPreference =
        let create
            (
                preference: Update'FrMealVoucherConecsDisplayPreferencePreference option
            ) : Update'FrMealVoucherConecsDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'FrMealVoucherConecs =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'FrMealVoucherConecsDisplayPreference option
        }

    module Update'FrMealVoucherConecs =
        let create
            (
                displayPreference: Update'FrMealVoucherConecsDisplayPreference option
            ) : Update'FrMealVoucherConecs
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'GiropayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'GiropayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'GiropayDisplayPreferencePreference option
        }

    module Update'GiropayDisplayPreference =
        let create
            (
                preference: Update'GiropayDisplayPreferencePreference option
            ) : Update'GiropayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Giropay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'GiropayDisplayPreference option
        }

    module Update'Giropay =
        let create
            (
                displayPreference: Update'GiropayDisplayPreference option
            ) : Update'Giropay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'GooglePayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'GooglePayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'GooglePayDisplayPreferencePreference option
        }

    module Update'GooglePayDisplayPreference =
        let create
            (
                preference: Update'GooglePayDisplayPreferencePreference option
            ) : Update'GooglePayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'GooglePay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'GooglePayDisplayPreference option
        }

    module Update'GooglePay =
        let create
            (
                displayPreference: Update'GooglePayDisplayPreference option
            ) : Update'GooglePay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'GrabpayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'GrabpayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'GrabpayDisplayPreferencePreference option
        }

    module Update'GrabpayDisplayPreference =
        let create
            (
                preference: Update'GrabpayDisplayPreferencePreference option
            ) : Update'GrabpayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Grabpay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'GrabpayDisplayPreference option
        }

    module Update'Grabpay =
        let create
            (
                displayPreference: Update'GrabpayDisplayPreference option
            ) : Update'Grabpay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'IdealDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'IdealDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'IdealDisplayPreferencePreference option
        }

    module Update'IdealDisplayPreference =
        let create
            (
                preference: Update'IdealDisplayPreferencePreference option
            ) : Update'IdealDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Ideal =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'IdealDisplayPreference option
        }

    module Update'Ideal =
        let create
            (
                displayPreference: Update'IdealDisplayPreference option
            ) : Update'Ideal
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'JcbDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'JcbDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'JcbDisplayPreferencePreference option
        }

    module Update'JcbDisplayPreference =
        let create
            (
                preference: Update'JcbDisplayPreferencePreference option
            ) : Update'JcbDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Jcb =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'JcbDisplayPreference option
        }

    module Update'Jcb =
        let create
            (
                displayPreference: Update'JcbDisplayPreference option
            ) : Update'Jcb
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'KakaoPayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'KakaoPayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'KakaoPayDisplayPreferencePreference option
        }

    module Update'KakaoPayDisplayPreference =
        let create
            (
                preference: Update'KakaoPayDisplayPreferencePreference option
            ) : Update'KakaoPayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'KakaoPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'KakaoPayDisplayPreference option
        }

    module Update'KakaoPay =
        let create
            (
                displayPreference: Update'KakaoPayDisplayPreference option
            ) : Update'KakaoPay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'KlarnaDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'KlarnaDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'KlarnaDisplayPreferencePreference option
        }

    module Update'KlarnaDisplayPreference =
        let create
            (
                preference: Update'KlarnaDisplayPreferencePreference option
            ) : Update'KlarnaDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Klarna =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'KlarnaDisplayPreference option
        }

    module Update'Klarna =
        let create
            (
                displayPreference: Update'KlarnaDisplayPreference option
            ) : Update'Klarna
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'KonbiniDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'KonbiniDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'KonbiniDisplayPreferencePreference option
        }

    module Update'KonbiniDisplayPreference =
        let create
            (
                preference: Update'KonbiniDisplayPreferencePreference option
            ) : Update'KonbiniDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Konbini =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'KonbiniDisplayPreference option
        }

    module Update'Konbini =
        let create
            (
                displayPreference: Update'KonbiniDisplayPreference option
            ) : Update'Konbini
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'KrCardDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'KrCardDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'KrCardDisplayPreferencePreference option
        }

    module Update'KrCardDisplayPreference =
        let create
            (
                preference: Update'KrCardDisplayPreferencePreference option
            ) : Update'KrCardDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'KrCard =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'KrCardDisplayPreference option
        }

    module Update'KrCard =
        let create
            (
                displayPreference: Update'KrCardDisplayPreference option
            ) : Update'KrCard
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'LinkDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'LinkDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'LinkDisplayPreferencePreference option
        }

    module Update'LinkDisplayPreference =
        let create
            (
                preference: Update'LinkDisplayPreferencePreference option
            ) : Update'LinkDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Link =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'LinkDisplayPreference option
        }

    module Update'Link =
        let create
            (
                displayPreference: Update'LinkDisplayPreference option
            ) : Update'Link
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'MbWayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'MbWayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'MbWayDisplayPreferencePreference option
        }

    module Update'MbWayDisplayPreference =
        let create
            (
                preference: Update'MbWayDisplayPreferencePreference option
            ) : Update'MbWayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'MbWay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'MbWayDisplayPreference option
        }

    module Update'MbWay =
        let create
            (
                displayPreference: Update'MbWayDisplayPreference option
            ) : Update'MbWay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'MobilepayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'MobilepayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'MobilepayDisplayPreferencePreference option
        }

    module Update'MobilepayDisplayPreference =
        let create
            (
                preference: Update'MobilepayDisplayPreferencePreference option
            ) : Update'MobilepayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Mobilepay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'MobilepayDisplayPreference option
        }

    module Update'Mobilepay =
        let create
            (
                displayPreference: Update'MobilepayDisplayPreference option
            ) : Update'Mobilepay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'MultibancoDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'MultibancoDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'MultibancoDisplayPreferencePreference option
        }

    module Update'MultibancoDisplayPreference =
        let create
            (
                preference: Update'MultibancoDisplayPreferencePreference option
            ) : Update'MultibancoDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Multibanco =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'MultibancoDisplayPreference option
        }

    module Update'Multibanco =
        let create
            (
                displayPreference: Update'MultibancoDisplayPreference option
            ) : Update'Multibanco
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'NaverPayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'NaverPayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'NaverPayDisplayPreferencePreference option
        }

    module Update'NaverPayDisplayPreference =
        let create
            (
                preference: Update'NaverPayDisplayPreferencePreference option
            ) : Update'NaverPayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'NaverPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'NaverPayDisplayPreference option
        }

    module Update'NaverPay =
        let create
            (
                displayPreference: Update'NaverPayDisplayPreference option
            ) : Update'NaverPay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'NzBankAccountDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'NzBankAccountDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'NzBankAccountDisplayPreferencePreference option
        }

    module Update'NzBankAccountDisplayPreference =
        let create
            (
                preference: Update'NzBankAccountDisplayPreferencePreference option
            ) : Update'NzBankAccountDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'NzBankAccount =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'NzBankAccountDisplayPreference option
        }

    module Update'NzBankAccount =
        let create
            (
                displayPreference: Update'NzBankAccountDisplayPreference option
            ) : Update'NzBankAccount
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'OxxoDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'OxxoDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'OxxoDisplayPreferencePreference option
        }

    module Update'OxxoDisplayPreference =
        let create
            (
                preference: Update'OxxoDisplayPreferencePreference option
            ) : Update'OxxoDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Oxxo =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'OxxoDisplayPreference option
        }

    module Update'Oxxo =
        let create
            (
                displayPreference: Update'OxxoDisplayPreference option
            ) : Update'Oxxo
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'P24DisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'P24DisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'P24DisplayPreferencePreference option
        }

    module Update'P24DisplayPreference =
        let create
            (
                preference: Update'P24DisplayPreferencePreference option
            ) : Update'P24DisplayPreference
            =
            {
              Preference = preference
            }

    type Update'P24 =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'P24DisplayPreference option
        }

    module Update'P24 =
        let create
            (
                displayPreference: Update'P24DisplayPreference option
            ) : Update'P24
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'PayByBankDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'PayByBankDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'PayByBankDisplayPreferencePreference option
        }

    module Update'PayByBankDisplayPreference =
        let create
            (
                preference: Update'PayByBankDisplayPreferencePreference option
            ) : Update'PayByBankDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'PayByBank =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PayByBankDisplayPreference option
        }

    module Update'PayByBank =
        let create
            (
                displayPreference: Update'PayByBankDisplayPreference option
            ) : Update'PayByBank
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'PaycoDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'PaycoDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'PaycoDisplayPreferencePreference option
        }

    module Update'PaycoDisplayPreference =
        let create
            (
                preference: Update'PaycoDisplayPreferencePreference option
            ) : Update'PaycoDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Payco =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PaycoDisplayPreference option
        }

    module Update'Payco =
        let create
            (
                displayPreference: Update'PaycoDisplayPreference option
            ) : Update'Payco
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'PaynowDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'PaynowDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'PaynowDisplayPreferencePreference option
        }

    module Update'PaynowDisplayPreference =
        let create
            (
                preference: Update'PaynowDisplayPreferencePreference option
            ) : Update'PaynowDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Paynow =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PaynowDisplayPreference option
        }

    module Update'Paynow =
        let create
            (
                displayPreference: Update'PaynowDisplayPreference option
            ) : Update'Paynow
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'PaypalDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'PaypalDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'PaypalDisplayPreferencePreference option
        }

    module Update'PaypalDisplayPreference =
        let create
            (
                preference: Update'PaypalDisplayPreferencePreference option
            ) : Update'PaypalDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Paypal =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PaypalDisplayPreference option
        }

    module Update'Paypal =
        let create
            (
                displayPreference: Update'PaypalDisplayPreference option
            ) : Update'Paypal
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'PaytoDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'PaytoDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'PaytoDisplayPreferencePreference option
        }

    module Update'PaytoDisplayPreference =
        let create
            (
                preference: Update'PaytoDisplayPreferencePreference option
            ) : Update'PaytoDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Payto =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PaytoDisplayPreference option
        }

    module Update'Payto =
        let create
            (
                displayPreference: Update'PaytoDisplayPreference option
            ) : Update'Payto
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'PixDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'PixDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'PixDisplayPreferencePreference option
        }

    module Update'PixDisplayPreference =
        let create
            (
                preference: Update'PixDisplayPreferencePreference option
            ) : Update'PixDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Pix =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PixDisplayPreference option
        }

    module Update'Pix =
        let create
            (
                displayPreference: Update'PixDisplayPreference option
            ) : Update'Pix
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'PromptpayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'PromptpayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'PromptpayDisplayPreferencePreference option
        }

    module Update'PromptpayDisplayPreference =
        let create
            (
                preference: Update'PromptpayDisplayPreferencePreference option
            ) : Update'PromptpayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Promptpay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PromptpayDisplayPreference option
        }

    module Update'Promptpay =
        let create
            (
                displayPreference: Update'PromptpayDisplayPreference option
            ) : Update'Promptpay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'RevolutPayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'RevolutPayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'RevolutPayDisplayPreferencePreference option
        }

    module Update'RevolutPayDisplayPreference =
        let create
            (
                preference: Update'RevolutPayDisplayPreferencePreference option
            ) : Update'RevolutPayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'RevolutPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'RevolutPayDisplayPreference option
        }

    module Update'RevolutPay =
        let create
            (
                displayPreference: Update'RevolutPayDisplayPreference option
            ) : Update'RevolutPay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'SamsungPayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'SamsungPayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'SamsungPayDisplayPreferencePreference option
        }

    module Update'SamsungPayDisplayPreference =
        let create
            (
                preference: Update'SamsungPayDisplayPreferencePreference option
            ) : Update'SamsungPayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'SamsungPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'SamsungPayDisplayPreference option
        }

    module Update'SamsungPay =
        let create
            (
                displayPreference: Update'SamsungPayDisplayPreference option
            ) : Update'SamsungPay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'SatispayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'SatispayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'SatispayDisplayPreferencePreference option
        }

    module Update'SatispayDisplayPreference =
        let create
            (
                preference: Update'SatispayDisplayPreferencePreference option
            ) : Update'SatispayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Satispay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'SatispayDisplayPreference option
        }

    module Update'Satispay =
        let create
            (
                displayPreference: Update'SatispayDisplayPreference option
            ) : Update'Satispay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'SepaDebitDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'SepaDebitDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'SepaDebitDisplayPreferencePreference option
        }

    module Update'SepaDebitDisplayPreference =
        let create
            (
                preference: Update'SepaDebitDisplayPreferencePreference option
            ) : Update'SepaDebitDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'SepaDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'SepaDebitDisplayPreference option
        }

    module Update'SepaDebit =
        let create
            (
                displayPreference: Update'SepaDebitDisplayPreference option
            ) : Update'SepaDebit
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'SofortDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'SofortDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'SofortDisplayPreferencePreference option
        }

    module Update'SofortDisplayPreference =
        let create
            (
                preference: Update'SofortDisplayPreferencePreference option
            ) : Update'SofortDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Sofort =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'SofortDisplayPreference option
        }

    module Update'Sofort =
        let create
            (
                displayPreference: Update'SofortDisplayPreference option
            ) : Update'Sofort
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'SunbitDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'SunbitDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'SunbitDisplayPreferencePreference option
        }

    module Update'SunbitDisplayPreference =
        let create
            (
                preference: Update'SunbitDisplayPreferencePreference option
            ) : Update'SunbitDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Sunbit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'SunbitDisplayPreference option
        }

    module Update'Sunbit =
        let create
            (
                displayPreference: Update'SunbitDisplayPreference option
            ) : Update'Sunbit
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'SwishDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'SwishDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'SwishDisplayPreferencePreference option
        }

    module Update'SwishDisplayPreference =
        let create
            (
                preference: Update'SwishDisplayPreferencePreference option
            ) : Update'SwishDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Swish =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'SwishDisplayPreference option
        }

    module Update'Swish =
        let create
            (
                displayPreference: Update'SwishDisplayPreference option
            ) : Update'Swish
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'TwintDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'TwintDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'TwintDisplayPreferencePreference option
        }

    module Update'TwintDisplayPreference =
        let create
            (
                preference: Update'TwintDisplayPreferencePreference option
            ) : Update'TwintDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Twint =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'TwintDisplayPreference option
        }

    module Update'Twint =
        let create
            (
                displayPreference: Update'TwintDisplayPreference option
            ) : Update'Twint
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'UpiDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'UpiDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'UpiDisplayPreferencePreference option
        }

    module Update'UpiDisplayPreference =
        let create
            (
                preference: Update'UpiDisplayPreferencePreference option
            ) : Update'UpiDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Upi =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'UpiDisplayPreference option
        }

    module Update'Upi =
        let create
            (
                displayPreference: Update'UpiDisplayPreference option
            ) : Update'Upi
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'UsBankAccountDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'UsBankAccountDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'UsBankAccountDisplayPreferencePreference option
        }

    module Update'UsBankAccountDisplayPreference =
        let create
            (
                preference: Update'UsBankAccountDisplayPreferencePreference option
            ) : Update'UsBankAccountDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'UsBankAccount =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'UsBankAccountDisplayPreference option
        }

    module Update'UsBankAccount =
        let create
            (
                displayPreference: Update'UsBankAccountDisplayPreference option
            ) : Update'UsBankAccount
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'WechatPayDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'WechatPayDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'WechatPayDisplayPreferencePreference option
        }

    module Update'WechatPayDisplayPreference =
        let create
            (
                preference: Update'WechatPayDisplayPreferencePreference option
            ) : Update'WechatPayDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'WechatPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'WechatPayDisplayPreference option
        }

    module Update'WechatPay =
        let create
            (
                displayPreference: Update'WechatPayDisplayPreference option
            ) : Update'WechatPay
            =
            {
              DisplayPreference = displayPreference
            }

    type Update'ZipDisplayPreferencePreference =
        | [<JsonPropertyName("none")>] None'
        | Off
        | On

    type Update'ZipDisplayPreference =
        {
            /// The account's preference for whether or not to display this payment method.
            [<Config.Form>]
            Preference: Update'ZipDisplayPreferencePreference option
        }

    module Update'ZipDisplayPreference =
        let create
            (
                preference: Update'ZipDisplayPreferencePreference option
            ) : Update'ZipDisplayPreference
            =
            {
              Preference = preference
            }

    type Update'Zip =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'ZipDisplayPreference option
        }

    module Update'Zip =
        let create
            (
                displayPreference: Update'ZipDisplayPreference option
            ) : Update'Zip
            =
            {
              DisplayPreference = displayPreference
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Configuration: string
            /// Canadian pre-authorized debit payments, check this [page](https://docs.stripe.com/payments/acss-debit) for more details like country availability.
            [<Config.Form>]
            AcssDebit: Update'AcssDebit option
            /// Whether the configuration can be used for new payments.
            [<Config.Form>]
            Active: bool option
            /// [Affirm](https://www.affirm.com/) gives your customers a way to split purchases over a series of payments. Depending on the purchase, they can pay with four interest-free payments (Split Pay) or pay over a longer term (Installments), which might include interest. Check this [page](https://docs.stripe.com/payments/affirm) for more details like country availability.
            [<Config.Form>]
            Affirm: Update'Affirm option
            /// Afterpay gives your customers a way to pay for purchases in installments, check this [page](https://docs.stripe.com/payments/afterpay-clearpay) for more details like country availability. Afterpay is particularly popular among businesses selling fashion, beauty, and sports products.
            [<Config.Form>]
            AfterpayClearpay: Update'AfterpayClearpay option
            /// Alipay is a digital wallet in China that has more than a billion active users worldwide. Alipay users can pay on the web or on a mobile device using login credentials or their Alipay app. Alipay has a low dispute rate and reduces fraud by authenticating payments using the customer's login credentials. Check this [page](https://docs.stripe.com/payments/alipay) for more details.
            [<Config.Form>]
            Alipay: Update'Alipay option
            /// Alma is a Buy Now, Pay Later payment method that offers customers the ability to pay in 2, 3, or 4 installments.
            [<Config.Form>]
            Alma: Update'Alma option
            /// Amazon Pay is a wallet payment method that lets your customers check out the same way as on Amazon.
            [<Config.Form>]
            AmazonPay: Update'AmazonPay option
            /// Stripe users can accept [Apple Pay](https://stripe.com/payments/apple-pay) in iOS applications in iOS 9 and later, and on the web in Safari starting with iOS 10 or macOS Sierra. There are no additional fees to process Apple Pay payments, and the [pricing](https://stripe.com/pricing) is the same as other card transactions. Check this [page](https://docs.stripe.com/apple-pay) for more details.
            [<Config.Form>]
            ApplePay: Update'ApplePay option
            /// Apple Pay Later, a payment method for customers to buy now and pay later, gives your customers a way to split purchases into four installments across six weeks.
            [<Config.Form>]
            ApplePayLater: Update'ApplePayLater option
            /// Stripe users in Australia can accept Bulk Electronic Clearing System (BECS) direct debit payments from customers with an Australian bank account. Check this [page](https://docs.stripe.com/payments/au-becs-debit) for more details.
            [<Config.Form>]
            AuBecsDebit: Update'AuBecsDebit option
            /// Stripe users in the UK can accept Bacs Direct Debit payments from customers with a UK bank account, check this [page](https://docs.stripe.com/payments/payment-methods/bacs-debit) for more details.
            [<Config.Form>]
            BacsDebit: Update'BacsDebit option
            /// Bancontact is the most popular online payment method in Belgium, with over 15 million cards in circulation. [Customers](https://docs.stripe.com/api/customers) use a Bancontact card or mobile app linked to a Belgian bank account to make online payments that are secure, guaranteed, and confirmed immediately. Check this [page](https://docs.stripe.com/payments/bancontact) for more details.
            [<Config.Form>]
            Bancontact: Update'Bancontact option
            /// Billie is a [single-use](https://docs.stripe.com/payments/payment-methods#usage) payment method that offers businesses Pay by Invoice where they offer payment terms ranging from 7-120 days. Customers are redirected from your website or app, authorize the payment with Billie, then return to your website or app. You get [immediate notification](/payments/payment-methods#payment-notification) of whether the payment succeeded or failed.
            [<Config.Form>]
            Billie: Update'Billie option
            /// BLIK is a [single use](https://docs.stripe.com/payments/payment-methods#usage) payment method that requires customers to authenticate their payments. When customers want to pay online using BLIK, they request a six-digit code from their banking application and enter it into the payment collection form. Check this [page](https://docs.stripe.com/payments/blik) for more details.
            [<Config.Form>]
            Blik: Update'Blik option
            /// Boleto is an official (regulated by the Central Bank of Brazil) payment method in Brazil. Check this [page](https://docs.stripe.com/payments/boleto) for more details.
            [<Config.Form>]
            Boleto: Update'Boleto option
            /// Cards are a popular way for consumers and businesses to pay online or in person. Stripe supports global and local card networks.
            [<Config.Form>]
            Card: Update'Card option
            /// Cartes Bancaires is France's local card network. More than 95% of these cards are co-branded with either Visa or Mastercard, meaning you can process these cards over either Cartes Bancaires or the Visa or Mastercard networks. Check this [page](https://docs.stripe.com/payments/cartes-bancaires) for more details.
            [<Config.Form>]
            CartesBancaires: Update'CartesBancaires option
            /// Cash App is a popular consumer app in the US that allows customers to bank, invest, send, and receive money using their digital wallet. Check this [page](https://docs.stripe.com/payments/cash-app-pay) for more details.
            [<Config.Form>]
            Cashapp: Update'Cashapp option
            /// [Stablecoin payments](https://docs.stripe.com/payments/stablecoin-payments) enable customers to pay in stablecoins like USDC from 100s of wallets including Phantom and Metamask.
            [<Config.Form>]
            Crypto: Update'Crypto option
            /// Uses a customer’s [cash balance](https://docs.stripe.com/payments/customer-balance) for the payment. The cash balance can be funded via a bank transfer. Check this [page](https://docs.stripe.com/payments/bank-transfers) for more details.
            [<Config.Form>]
            CustomerBalance: Update'CustomerBalance option
            /// EPS is an Austria-based payment method that allows customers to complete transactions online using their bank credentials. EPS is supported by all Austrian banks and is accepted by over 80% of Austrian online retailers. Check this [page](https://docs.stripe.com/payments/eps) for more details.
            [<Config.Form>]
            Eps: Update'Eps option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Financial Process Exchange (FPX) is a Malaysia-based payment method that allows customers to complete transactions online using their bank credentials. Bank Negara Malaysia (BNM), the Central Bank of Malaysia, and eleven other major Malaysian financial institutions are members of the PayNet Group, which owns and operates FPX. It is one of the most popular online payment methods in Malaysia, with nearly 90 million transactions in 2018 according to BNM. Check this [page](https://docs.stripe.com/payments/fpx) for more details.
            [<Config.Form>]
            Fpx: Update'Fpx option
            /// Meal vouchers in France, or “titres-restaurant”, is a local benefits program commonly offered by employers for their employees to purchase prepared food and beverages on working days. Check this [page](https://docs.stripe.com/payments/meal-vouchers/fr-meal-vouchers) for more details.
            [<Config.Form>]
            FrMealVoucherConecs: Update'FrMealVoucherConecs option
            /// giropay is a German payment method based on online banking, introduced in 2006. It allows customers to complete transactions online using their online banking environment, with funds debited from their bank account. Depending on their bank, customers confirm payments on giropay using a second factor of authentication or a PIN. giropay accounts for 10% of online checkouts in Germany. Check this [page](https://docs.stripe.com/payments/giropay) for more details.
            [<Config.Form>]
            Giropay: Update'Giropay option
            /// Google Pay allows customers to make payments in your app or website using any credit or debit card saved to their Google Account, including those from Google Play, YouTube, Chrome, or an Android device. Use the Google Pay API to request any credit or debit card stored in your customer's Google account. Check this [page](https://docs.stripe.com/google-pay) for more details.
            [<Config.Form>]
            GooglePay: Update'GooglePay option
            /// GrabPay is a payment method developed by [Grab](https://www.grab.com/sg/consumer/finance/pay/). GrabPay is a digital wallet - customers maintain a balance in their wallets that they pay out with. Check this [page](https://docs.stripe.com/payments/grabpay) for more details.
            [<Config.Form>]
            Grabpay: Update'Grabpay option
            /// iDEAL is a Netherlands-based payment method that allows customers to complete transactions online using their bank credentials. All major Dutch banks are members of Currence, the scheme that operates iDEAL, making it the most popular online payment method in the Netherlands with a share of online transactions close to 55%. Check this [page](https://docs.stripe.com/payments/ideal) for more details.
            [<Config.Form>]
            Ideal: Update'Ideal option
            /// JCB is a credit card company based in Japan. JCB is currently available in Japan to businesses approved by JCB, and available to all businesses in Australia, Canada, Hong Kong, Japan, New Zealand, Singapore, Switzerland, United Kingdom, United States, and all countries in the European Economic Area except Iceland. Check this [page](https://support.stripe.com/questions/accepting-japan-credit-bureau-%28jcb%29-payments) for more details.
            [<Config.Form>]
            Jcb: Update'Jcb option
            /// Kakao Pay is a popular local wallet available in South Korea.
            [<Config.Form>]
            KakaoPay: Update'KakaoPay option
            /// Klarna gives customers a range of [payment options](https://docs.stripe.com/payments/klarna#payment-options) during checkout. Available payment options vary depending on the customer's billing address and the transaction amount. These payment options make it convenient for customers to purchase items in all price ranges. Check this [page](https://docs.stripe.com/payments/klarna) for more details.
            [<Config.Form>]
            Klarna: Update'Klarna option
            /// Konbini allows customers in Japan to pay for bills and online purchases at convenience stores with cash. Check this [page](https://docs.stripe.com/payments/konbini) for more details.
            [<Config.Form>]
            Konbini: Update'Konbini option
            /// Korean cards let users pay using locally issued cards from South Korea.
            [<Config.Form>]
            KrCard: Update'KrCard option
            /// [Link](https://docs.stripe.com/payments/link) is a payment method network. With Link, users save their payment details once, then reuse that information to pay with one click for any business on the network.
            [<Config.Form>]
            Link: Update'Link option
            /// MB WAY is the most popular wallet in Portugal. After entering their phone number in your checkout, customers approve the payment directly in their MB WAY app. Check this [page](https://docs.stripe.com/payments/mb-way) for more details.
            [<Config.Form>]
            MbWay: Update'MbWay option
            /// MobilePay is a [single-use](https://docs.stripe.com/payments/payment-methods#usage) card wallet payment method used in Denmark and Finland. It allows customers to [authenticate and approve](https://docs.stripe.com/payments/payment-methods#customer-actions) payments using the MobilePay app. Check this [page](https://docs.stripe.com/payments/mobilepay) for more details.
            [<Config.Form>]
            Mobilepay: Update'Mobilepay option
            /// Stripe users in Europe and the United States can accept Multibanco payments from customers in Portugal using [Sources](https://stripe.com/docs/sources)—a single integration path for creating payments using any supported method.
            [<Config.Form>]
            Multibanco: Update'Multibanco option
            /// Configuration name.
            [<Config.Form>]
            Name: string option
            /// Naver Pay is a popular local wallet available in South Korea.
            [<Config.Form>]
            NaverPay: Update'NaverPay option
            /// Stripe users in New Zealand can accept Bulk Electronic Clearing System (BECS) direct debit payments from customers with a New Zeland bank account. Check this [page](https://docs.stripe.com/payments/nz-bank-account) for more details.
            [<Config.Form>]
            NzBankAccount: Update'NzBankAccount option
            /// OXXO is a Mexican chain of convenience stores with thousands of locations across Latin America and represents nearly 20% of online transactions in Mexico. OXXO allows customers to pay bills and online purchases in-store with cash. Check this [page](https://docs.stripe.com/payments/oxxo) for more details.
            [<Config.Form>]
            Oxxo: Update'Oxxo option
            /// Przelewy24 is a Poland-based payment method aggregator that allows customers to complete transactions online using bank transfers and other methods. Bank transfers account for 30% of online payments in Poland and Przelewy24 provides a way for customers to pay with over 165 banks. Check this [page](https://docs.stripe.com/payments/p24) for more details.
            [<Config.Form>]
            P24: Update'P24 option
            /// Pay by bank is a redirect payment method backed by bank transfers. A customer is redirected to their bank to authorize a bank transfer for a given amount. This removes a lot of the error risks inherent in waiting for the customer to initiate a transfer themselves, and is less expensive than card payments.
            [<Config.Form>]
            PayByBank: Update'PayByBank option
            /// PAYCO is a [single-use](https://docs.stripe.com/payments/payment-methods#usage local wallet available in South Korea.
            [<Config.Form>]
            Payco: Update'Payco option
            /// PayNow is a Singapore-based payment method that allows customers to make a payment using their preferred app from participating banks and participating non-bank financial institutions. Check this [page](https://docs.stripe.com/payments/paynow) for more details.
            [<Config.Form>]
            Paynow: Update'Paynow option
            /// PayPal, a digital wallet popular with customers in Europe, allows your customers worldwide to pay using their PayPal account. Check this [page](https://docs.stripe.com/payments/paypal) for more details.
            [<Config.Form>]
            Paypal: Update'Paypal option
            /// PayTo is a [real-time](https://docs.stripe.com/payments/real-time) payment method that enables customers in Australia to pay by providing their bank account details. Customers must accept a mandate authorizing you to debit their account. Check this [page](https://docs.stripe.com/payments/payto) for more details.
            [<Config.Form>]
            Payto: Update'Payto option
            /// Pix is a payment method popular in Brazil. When paying with Pix, customers authenticate and approve payments by scanning a QR code in their preferred banking app. Check this [page](https://docs.stripe.com/payments/pix) for more details.
            [<Config.Form>]
            Pix: Update'Pix option
            /// PromptPay is a Thailand-based payment method that allows customers to make a payment using their preferred app from participating banks. Check this [page](https://docs.stripe.com/payments/promptpay) for more details.
            [<Config.Form>]
            Promptpay: Update'Promptpay option
            /// Revolut Pay, developed by Revolut, a global finance app, is a digital wallet payment method. Revolut Pay uses the customer’s stored balance or cards to fund the payment, and offers the option for non-Revolut customers to save their details after their first purchase.
            [<Config.Form>]
            RevolutPay: Update'RevolutPay option
            /// Samsung Pay is a [single-use](https://docs.stripe.com/payments/payment-methods#usage local wallet available in South Korea.
            [<Config.Form>]
            SamsungPay: Update'SamsungPay option
            /// Satispay is a [single-use](https://docs.stripe.com/payments/payment-methods#usage) payment method where customers are required to [authenticate](/payments/payment-methods#customer-actions) their payment. Customers pay by being redirected from your website or app, authorizing the payment with Satispay, then returning to your website or app. You get [immediate notification](/payments/payment-methods#payment-notification) of whether the payment succeeded or failed.
            [<Config.Form>]
            Satispay: Update'Satispay option
            /// The [Single Euro Payments Area (SEPA)](https://en.wikipedia.org/wiki/Single_Euro_Payments_Area) is an initiative of the European Union to simplify payments within and across member countries. SEPA established and enforced banking standards to allow for the direct debiting of every EUR-denominated bank account within the SEPA region, check this [page](https://docs.stripe.com/payments/sepa-debit) for more details.
            [<Config.Form>]
            SepaDebit: Update'SepaDebit option
            /// Stripe users in Europe and the United States can use the [Payment Intents API](https://stripe.com/docs/payments/payment-intents)—a single integration path for creating payments using any supported method—to accept [Sofort](https://www.sofort.com/) payments from customers. Check this [page](https://docs.stripe.com/payments/sofort) for more details.
            [<Config.Form>]
            Sofort: Update'Sofort option
            /// Sunbit is a [single-use](https://docs.stripe.com/payments/payment-methods#usage) payment method where customers choose to pay in 3, 6, or 12 installments. Customers are redirected from your website or app, authorize the payment with Sunbit, then return to your website or app. You get [immediate notification](https://docs.stripe.com/payments/payment-methods#payment-notification) of whether the payment succeeded or failed.
            [<Config.Form>]
            Sunbit: Update'Sunbit option
            /// Swish is a [real-time](https://docs.stripe.com/payments/real-time) payment method popular in Sweden. It allows customers to [authenticate and approve](https://docs.stripe.com/payments/payment-methods#customer-actions) payments using the Swish mobile app and the Swedish BankID mobile app. Check this [page](https://docs.stripe.com/payments/swish) for more details.
            [<Config.Form>]
            Swish: Update'Swish option
            /// Twint is a payment method popular in Switzerland. It allows customers to pay using their mobile phone. Check this [page](https://docs.stripe.com/payments/twint) for more details.
            [<Config.Form>]
            Twint: Update'Twint option
            /// Unified Payment Interface (UPI) is India's leading payment method with exponential growth since it launched in 2016.
            [<Config.Form>]
            Upi: Update'Upi option
            /// Stripe users in the United States can accept ACH direct debit payments from customers with a US bank account using the Automated Clearing House (ACH) payments system operated by Nacha. Check this [page](https://docs.stripe.com/payments/ach-direct-debit) for more details.
            [<Config.Form>]
            UsBankAccount: Update'UsBankAccount option
            /// WeChat, owned by Tencent, is China's leading mobile app with over 1 billion monthly active users. Chinese consumers can use WeChat Pay to pay for goods and services inside of businesses' apps and websites. WeChat Pay users buy most frequently in gaming, e-commerce, travel, online education, and food/nutrition. Check this [page](https://docs.stripe.com/payments/wechat-pay) for more details.
            [<Config.Form>]
            WechatPay: Update'WechatPay option
            /// Zip gives your customers a way to split purchases over a series of payments. Check this [page](https://docs.stripe.com/payments/zip) for more details like country availability.
            [<Config.Form>]
            Zip: Update'Zip option
        }

    module UpdateOptions =
        let create
            (
                configuration: string
            ) : UpdateOptions
            =
            {
              Configuration = configuration
              AcssDebit = None
              Active = None
              Affirm = None
              AfterpayClearpay = None
              Alipay = None
              Alma = None
              AmazonPay = None
              ApplePay = None
              ApplePayLater = None
              AuBecsDebit = None
              BacsDebit = None
              Bancontact = None
              Billie = None
              Blik = None
              Boleto = None
              Card = None
              CartesBancaires = None
              Cashapp = None
              Crypto = None
              CustomerBalance = None
              Eps = None
              Expand = None
              Fpx = None
              FrMealVoucherConecs = None
              Giropay = None
              GooglePay = None
              Grabpay = None
              Ideal = None
              Jcb = None
              KakaoPay = None
              Klarna = None
              Konbini = None
              KrCard = None
              Link = None
              MbWay = None
              Mobilepay = None
              Multibanco = None
              Name = None
              NaverPay = None
              NzBankAccount = None
              Oxxo = None
              P24 = None
              PayByBank = None
              Payco = None
              Paynow = None
              Paypal = None
              Payto = None
              Pix = None
              Promptpay = None
              RevolutPay = None
              SamsungPay = None
              Satispay = None
              SepaDebit = None
              Sofort = None
              Sunbit = None
              Swish = None
              Twint = None
              Upi = None
              UsBankAccount = None
              WechatPay = None
              Zip = None
            }

    ///<p>List payment method configurations</p>
    let List settings (options: ListOptions) =
        let qs = [("application", options.Application |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/payment_method_configurations"
        |> RestApi.getAsync<StripeList<PaymentMethodConfiguration>> settings qs

    ///<p>Creates a payment method configuration</p>
    let Create settings (options: CreateOptions) =
        $"/v1/payment_method_configurations"
        |> RestApi.postAsync<_, PaymentMethodConfiguration> settings (Map.empty) options

    ///<p>Retrieve payment method configuration</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/payment_method_configurations/{options.Configuration}"
        |> RestApi.getAsync<PaymentMethodConfiguration> settings qs

    ///<p>Update payment method configuration</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/payment_method_configurations/{options.Configuration}"
        |> RestApi.postAsync<_, PaymentMethodConfiguration> settings (Map.empty) options

module PaymentMethodDomains =

    type ListOptions =
        {
            /// The domain name that this payment method domain object represents.
            [<Config.Query>]
            DomainName: string option
            /// Whether this payment method domain is enabled. If the domain is not enabled, payment methods will not appear in Elements or Embedded Checkout
            [<Config.Query>]
            Enabled: bool option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
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
                domainName: string option,
                enabled: bool option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              DomainName = domainName
              Enabled = enabled
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    type CreateOptions =
        {
            /// The domain name that this payment method domain object represents.
            [<Config.Form>]
            DomainName: string
            /// Whether this payment method domain is enabled. If the domain is not enabled, payment methods that require a payment method domain will not appear in Elements or Embedded Checkout.
            [<Config.Form>]
            Enabled: bool option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module CreateOptions =
        let create
            (
                domainName: string
            ) : CreateOptions
            =
            {
              DomainName = domainName
              Enabled = None
              Expand = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            PaymentMethodDomain: string
        }

    module RetrieveOptions =
        let create
            (
                paymentMethodDomain: string
            ) : RetrieveOptions
            =
            {
              PaymentMethodDomain = paymentMethodDomain
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            PaymentMethodDomain: string
            /// Whether this payment method domain is enabled. If the domain is not enabled, payment methods that require a payment method domain will not appear in Elements or Embedded Checkout.
            [<Config.Form>]
            Enabled: bool option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module UpdateOptions =
        let create
            (
                paymentMethodDomain: string
            ) : UpdateOptions
            =
            {
              PaymentMethodDomain = paymentMethodDomain
              Enabled = None
              Expand = None
            }

    ///<p>Lists the details of existing payment method domains.</p>
    let List settings (options: ListOptions) =
        let qs = [("domain_name", options.DomainName |> box); ("enabled", options.Enabled |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/payment_method_domains"
        |> RestApi.getAsync<StripeList<PaymentMethodDomain>> settings qs

    ///<p>Creates a payment method domain.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/payment_method_domains"
        |> RestApi.postAsync<_, PaymentMethodDomain> settings (Map.empty) options

    ///<p>Retrieves the details of an existing payment method domain.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/payment_method_domains/{options.PaymentMethodDomain}"
        |> RestApi.getAsync<PaymentMethodDomain> settings qs

    ///<p>Updates an existing payment method domain.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/payment_method_domains/{options.PaymentMethodDomain}"
        |> RestApi.postAsync<_, PaymentMethodDomain> settings (Map.empty) options

module PaymentMethodDomainsValidate =

    type ValidateOptions =
        {
            [<Config.Path>]
            PaymentMethodDomain: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    module ValidateOptions =
        let create
            (
                paymentMethodDomain: string
            ) : ValidateOptions
            =
            {
              PaymentMethodDomain = paymentMethodDomain
              Expand = None
            }

    ///<p>Some payment methods might require additional steps to register a domain. If the requirements weren’t satisfied when the domain was created, the payment method will be inactive on the domain.
    ///The payment method doesn’t appear in Elements or Embedded Checkout for this domain until it is active.</p>
    ///<p>To activate a payment method on an existing payment method domain, complete the required registration steps specific to the payment method, and then validate the payment method domain with this endpoint.</p>
    ///<p>Related guides: <a href="/docs/payments/payment-methods/pmd-registration">Payment method domains</a>.</p>
    let Validate settings (options: ValidateOptions) =
        $"/v1/payment_method_domains/{options.PaymentMethodDomain}/validate"
        |> RestApi.postAsync<_, PaymentMethodDomain> settings (Map.empty) options

module SubscriptionItems =

    type ListOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// The ID of the subscription whose items will be retrieved.
            [<Config.Query>]
            Subscription: string
        }

    module ListOptions =
        let create
            (
                subscription: string
            ) : ListOptions
            =
            {
              Subscription = subscription
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
            }

    type Create'BillingThresholdsItemBillingThresholds =
        {
            /// Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
            [<Config.Form>]
            UsageGte: int option
        }

    module Create'BillingThresholdsItemBillingThresholds =
        let create
            (
                usageGte: int option
            ) : Create'BillingThresholdsItemBillingThresholds
            =
            {
              UsageGte = usageGte
            }

    type Create'Discounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    module Create'Discounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Create'Discounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Create'PaymentBehavior =
        | AllowIncomplete
        | DefaultIncomplete
        | ErrorIfIncomplete
        | PendingIfIncomplete

    type Create'PriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type Create'PriceDataRecurring =
        {
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Create'PriceDataRecurringInterval option
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    module Create'PriceDataRecurring =
        let create
            (
                interval: Create'PriceDataRecurringInterval option,
                intervalCount: int option
            ) : Create'PriceDataRecurring
            =
            {
              Interval = interval
              IntervalCount = intervalCount
            }

    type Create'PriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Create'PriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// The recurring components of a price such as `interval` and `interval_count`.
            [<Config.Form>]
            Recurring: Create'PriceDataRecurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Create'PriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Create'PriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                recurring: Create'PriceDataRecurring option,
                taxBehavior: Create'PriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Create'PriceData
            =
            {
              Currency = currency
              Product = product
              Recurring = recurring
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Create'ProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type CreateOptions =
        {
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds: Choice<Create'BillingThresholdsItemBillingThresholds,string> option
            /// The coupons to redeem into discounts for the subscription item.
            [<Config.Form>]
            Discounts: Choice<Create'Discounts list,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://docs.stripe.com/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
            /// Use `default_incomplete` to transition the subscription to `status=past_due` when payment is required and await explicit confirmation of the invoice's payment intent. This allows simpler management of scenarios where additional user actions are needed to pay a subscription’s invoice. Such as failed payments, [SCA regulation](https://docs.stripe.com/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method.
            /// Use `pending_if_incomplete` to update the subscription using [pending updates](https://docs.stripe.com/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://docs.stripe.com/billing/pending-updates-reference#supported-attributes).
            /// Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://docs.stripe.com/changelog/2019-03-14) to learn more.
            [<Config.Form>]
            PaymentBehavior: Create'PaymentBehavior option
            /// The identifier of the plan to add to the subscription.
            [<Config.Form>]
            Plan: string option
            /// The ID of the price object.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.
            [<Config.Form>]
            PriceData: Create'PriceData option
            /// Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.
            [<Config.Form>]
            ProrationBehavior: Create'ProrationBehavior option
            /// If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply the same proration that was previewed with the [upcoming invoice](/api/invoices/create_preview) endpoint.
            [<Config.Form>]
            ProrationDate: DateTime option
            /// The quantity you'd like to apply to the subscription item you're creating.
            [<Config.Form>]
            Quantity: int option
            /// The identifier of the subscription to modify.
            [<Config.Form>]
            Subscription: string
            /// A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    module CreateOptions =
        let create
            (
                subscription: string
            ) : CreateOptions
            =
            {
              Subscription = subscription
              BillingThresholds = None
              Discounts = None
              Expand = None
              Metadata = None
              PaymentBehavior = None
              Plan = None
              Price = None
              PriceData = None
              ProrationBehavior = None
              ProrationDate = None
              Quantity = None
              TaxRates = None
            }

    type Delete'PaymentBehavior =
        | AllowIncomplete
        | DefaultIncomplete
        | ErrorIfIncomplete
        | PendingIfIncomplete

    type Delete'ProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type DeleteOptions =
        {
            [<Config.Path>]
            Item: string
            /// Delete all usage for the given subscription item. Allowed only when the current plan's `usage_type` is `metered`.
            [<Config.Form>]
            ClearUsage: bool option
            /// Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://docs.stripe.com/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
            /// Use `default_incomplete` to transition the subscription to `status=past_due` when payment is required and await explicit confirmation of the invoice's payment intent. This allows simpler management of scenarios where additional user actions are needed to pay a subscription’s invoice. Such as failed payments, [SCA regulation](https://docs.stripe.com/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method.
            /// Use `pending_if_incomplete` to update the subscription using [pending updates](https://docs.stripe.com/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://docs.stripe.com/billing/pending-updates-reference#supported-attributes).
            /// Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://docs.stripe.com/changelog/2019-03-14) to learn more.
            [<Config.Form>]
            PaymentBehavior: Delete'PaymentBehavior option
            /// Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.
            [<Config.Form>]
            ProrationBehavior: Delete'ProrationBehavior option
            /// If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply the same proration that was previewed with the [upcoming invoice](/api/invoices/create_preview) endpoint.
            [<Config.Form>]
            ProrationDate: DateTime option
        }

    module DeleteOptions =
        let create
            (
                item: string
            ) : DeleteOptions
            =
            {
              Item = item
              ClearUsage = None
              PaymentBehavior = None
              ProrationBehavior = None
              ProrationDate = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Item: string
        }

    module RetrieveOptions =
        let create
            (
                item: string
            ) : RetrieveOptions
            =
            {
              Item = item
              Expand = None
            }

    type Update'BillingThresholdsItemBillingThresholds =
        {
            /// Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
            [<Config.Form>]
            UsageGte: int option
        }

    module Update'BillingThresholdsItemBillingThresholds =
        let create
            (
                usageGte: int option
            ) : Update'BillingThresholdsItemBillingThresholds
            =
            {
              UsageGte = usageGte
            }

    type Update'Discounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    module Update'Discounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Update'Discounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Update'PaymentBehavior =
        | AllowIncomplete
        | DefaultIncomplete
        | ErrorIfIncomplete
        | PendingIfIncomplete

    type Update'PriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type Update'PriceDataRecurring =
        {
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Update'PriceDataRecurringInterval option
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    module Update'PriceDataRecurring =
        let create
            (
                interval: Update'PriceDataRecurringInterval option,
                intervalCount: int option
            ) : Update'PriceDataRecurring
            =
            {
              Interval = interval
              IntervalCount = intervalCount
            }

    type Update'PriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Update'PriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// The recurring components of a price such as `interval` and `interval_count`.
            [<Config.Form>]
            Recurring: Update'PriceDataRecurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Update'PriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Update'PriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                recurring: Update'PriceDataRecurring option,
                taxBehavior: Update'PriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Update'PriceData
            =
            {
              Currency = currency
              Product = product
              Recurring = recurring
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Update'ProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type UpdateOptions =
        {
            [<Config.Path>]
            Item: string
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds: Choice<Update'BillingThresholdsItemBillingThresholds,string> option
            /// The coupons to redeem into discounts for the subscription item.
            [<Config.Form>]
            Discounts: Choice<Update'Discounts list,string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Indicates if a customer is on or off-session while an invoice payment is attempted. Defaults to `false` (on-session).
            [<Config.Form>]
            OffSession: bool option
            /// Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://docs.stripe.com/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
            /// Use `default_incomplete` to transition the subscription to `status=past_due` when payment is required and await explicit confirmation of the invoice's payment intent. This allows simpler management of scenarios where additional user actions are needed to pay a subscription’s invoice. Such as failed payments, [SCA regulation](https://docs.stripe.com/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method.
            /// Use `pending_if_incomplete` to update the subscription using [pending updates](https://docs.stripe.com/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://docs.stripe.com/billing/pending-updates-reference#supported-attributes).
            /// Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://docs.stripe.com/changelog/2019-03-14) to learn more.
            [<Config.Form>]
            PaymentBehavior: Update'PaymentBehavior option
            /// The identifier of the new plan for this subscription item.
            [<Config.Form>]
            Plan: string option
            /// The ID of the price object. One of `price` or `price_data` is required. When changing a subscription item's price, `quantity` is set to 1 unless a `quantity` parameter is provided.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.
            [<Config.Form>]
            PriceData: Update'PriceData option
            /// Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.
            [<Config.Form>]
            ProrationBehavior: Update'ProrationBehavior option
            /// If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply the same proration that was previewed with the [upcoming invoice](/api/invoices/create_preview) endpoint.
            [<Config.Form>]
            ProrationDate: DateTime option
            /// The quantity you'd like to apply to the subscription item you're creating.
            [<Config.Form>]
            Quantity: int option
            /// A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    module UpdateOptions =
        let create
            (
                item: string
            ) : UpdateOptions
            =
            {
              Item = item
              BillingThresholds = None
              Discounts = None
              Expand = None
              Metadata = None
              OffSession = None
              PaymentBehavior = None
              Plan = None
              Price = None
              PriceData = None
              ProrationBehavior = None
              ProrationDate = None
              Quantity = None
              TaxRates = None
            }

    ///<p>Returns a list of your subscription items for a given subscription.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("subscription", options.Subscription |> box)] |> Map.ofList
        $"/v1/subscription_items"
        |> RestApi.getAsync<StripeList<SubscriptionItem>> settings qs

    ///<p>Adds a new item to an existing subscription. No existing items will be changed or replaced.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/subscription_items"
        |> RestApi.postAsync<_, SubscriptionItem> settings (Map.empty) options

    ///<p>Deletes an item from the subscription. Removing a subscription item from a subscription will not cancel the subscription.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/subscription_items/{options.Item}"
        |> RestApi.deleteAsync<DeletedSubscriptionItem> settings (Map.empty)

    ///<p>Retrieves the subscription item with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/subscription_items/{options.Item}"
        |> RestApi.getAsync<SubscriptionItem> settings qs

    ///<p>Updates the plan or quantity of an item on a current subscription.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/subscription_items/{options.Item}"
        |> RestApi.postAsync<_, SubscriptionItem> settings (Map.empty) options

module SubscriptionSchedules =

    type ListOptions =
        {
            /// Only return subscription schedules that were created canceled the given date interval.
            [<Config.Query>]
            CanceledAt: int option
            /// Only return subscription schedules that completed during the given date interval.
            [<Config.Query>]
            CompletedAt: int option
            /// Only return subscription schedules that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// Only return subscription schedules for the given customer.
            [<Config.Query>]
            Customer: string option
            /// Only return subscription schedules for the given account.
            [<Config.Query>]
            CustomerAccount: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Only return subscription schedules that were released during the given date interval.
            [<Config.Query>]
            ReleasedAt: int option
            /// Only return subscription schedules that have not started yet.
            [<Config.Query>]
            Scheduled: bool option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module ListOptions =
        let create
            (
                canceledAt: int option,
                completedAt: int option,
                created: int option,
                customer: string option,
                customerAccount: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                releasedAt: int option,
                scheduled: bool option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              CanceledAt = canceledAt
              CompletedAt = completedAt
              Created = created
              Customer = customer
              CustomerAccount = customerAccount
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              ReleasedAt = releasedAt
              Scheduled = scheduled
              StartingAfter = startingAfter
            }

    type Create'BillingModeFlexibleProrationDiscounts =
        | Included
        | Itemized

    type Create'BillingModeFlexible =
        {
            /// Controls how invoices and invoice items display proration amounts and discount amounts.
            [<Config.Form>]
            ProrationDiscounts: Create'BillingModeFlexibleProrationDiscounts option
        }

    module Create'BillingModeFlexible =
        let create
            (
                prorationDiscounts: Create'BillingModeFlexibleProrationDiscounts option
            ) : Create'BillingModeFlexible
            =
            {
              ProrationDiscounts = prorationDiscounts
            }

    type Create'BillingModeType =
        | Classic
        | Flexible

    type Create'BillingMode =
        {
            /// Configure behavior for flexible billing mode.
            [<Config.Form>]
            Flexible: Create'BillingModeFlexible option
            /// Controls the calculation and orchestration of prorations and invoices for subscriptions. If no value is passed, the default is `flexible`.
            [<Config.Form>]
            Type: Create'BillingModeType option
        }

    module Create'BillingMode =
        let create
            (
                flexible: Create'BillingModeFlexible option,
                ``type``: Create'BillingModeType option
            ) : Create'BillingMode
            =
            {
              Flexible = flexible
              Type = ``type``
            }

    type Create'DefaultSettingsAutomaticTaxLiabilityType =
        | Account
        | Self

    type Create'DefaultSettingsAutomaticTaxLiability =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Create'DefaultSettingsAutomaticTaxLiabilityType option
        }

    module Create'DefaultSettingsAutomaticTaxLiability =
        let create
            (
                account: string option,
                ``type``: Create'DefaultSettingsAutomaticTaxLiabilityType option
            ) : Create'DefaultSettingsAutomaticTaxLiability
            =
            {
              Account = account
              Type = ``type``
            }

    type Create'DefaultSettingsAutomaticTax =
        {
            /// Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.
            [<Config.Form>]
            Enabled: bool option
            /// The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.
            [<Config.Form>]
            Liability: Create'DefaultSettingsAutomaticTaxLiability option
        }

    module Create'DefaultSettingsAutomaticTax =
        let create
            (
                enabled: bool option,
                liability: Create'DefaultSettingsAutomaticTaxLiability option
            ) : Create'DefaultSettingsAutomaticTax
            =
            {
              Enabled = enabled
              Liability = liability
            }

    type Create'DefaultSettingsBillingCycleAnchor =
        | Automatic
        | PhaseStart

    type Create'DefaultSettingsBillingThresholdsBillingThresholds =
        {
            /// Monetary threshold that triggers the subscription to advance to a new billing period
            [<Config.Form>]
            AmountGte: int option
            /// Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
            [<Config.Form>]
            ResetBillingCycleAnchor: bool option
        }

    module Create'DefaultSettingsBillingThresholdsBillingThresholds =
        let create
            (
                amountGte: int option,
                resetBillingCycleAnchor: bool option
            ) : Create'DefaultSettingsBillingThresholdsBillingThresholds
            =
            {
              AmountGte = amountGte
              ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Create'DefaultSettingsCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type Create'DefaultSettingsInvoiceSettingsIssuerType =
        | Account
        | Self

    type Create'DefaultSettingsInvoiceSettingsIssuer =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Create'DefaultSettingsInvoiceSettingsIssuerType option
        }

    module Create'DefaultSettingsInvoiceSettingsIssuer =
        let create
            (
                account: string option,
                ``type``: Create'DefaultSettingsInvoiceSettingsIssuerType option
            ) : Create'DefaultSettingsInvoiceSettingsIssuer
            =
            {
              Account = account
              Type = ``type``
            }

    type Create'DefaultSettingsInvoiceSettings =
        {
            /// The account tax IDs associated with the subscription schedule. Will be set on invoices generated by the subscription schedule.
            [<Config.Form>]
            AccountTaxIds: Choice<string list,string> option
            /// Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `collection_method=charge_automatically`.
            [<Config.Form>]
            DaysUntilDue: int option
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: Create'DefaultSettingsInvoiceSettingsIssuer option
        }

    module Create'DefaultSettingsInvoiceSettings =
        let create
            (
                accountTaxIds: Choice<string list,string> option,
                daysUntilDue: int option,
                issuer: Create'DefaultSettingsInvoiceSettingsIssuer option
            ) : Create'DefaultSettingsInvoiceSettings
            =
            {
              AccountTaxIds = accountTaxIds
              DaysUntilDue = daysUntilDue
              Issuer = issuer
            }

    type Create'DefaultSettingsTransferDataTransferDataSpecs =
        {
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
            [<Config.Form>]
            AmountPercent: decimal option
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Destination: string option
        }

    module Create'DefaultSettingsTransferDataTransferDataSpecs =
        let create
            (
                amountPercent: decimal option,
                destination: string option
            ) : Create'DefaultSettingsTransferDataTransferDataSpecs
            =
            {
              AmountPercent = amountPercent
              Destination = destination
            }

    type Create'DefaultSettings =
        {
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
            [<Config.Form>]
            ApplicationFeePercent: decimal option
            /// Default settings for automatic tax computation.
            [<Config.Form>]
            AutomaticTax: Create'DefaultSettingsAutomaticTax option
            /// Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).
            [<Config.Form>]
            BillingCycleAnchor: Create'DefaultSettingsBillingCycleAnchor option
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds: Choice<Create'DefaultSettingsBillingThresholdsBillingThresholds,string> option
            /// Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.
            [<Config.Form>]
            CollectionMethod: Create'DefaultSettingsCollectionMethod option
            /// ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
            [<Config.Form>]
            DefaultPaymentMethod: string option
            /// Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.
            [<Config.Form>]
            Description: Choice<string,string> option
            /// All invoices will be billed using the specified settings.
            [<Config.Form>]
            InvoiceSettings: Create'DefaultSettingsInvoiceSettings option
            /// The account on behalf of which to charge, for each of the associated subscription's invoices.
            [<Config.Form>]
            OnBehalfOf: Choice<string,string> option
            /// The data with which to automatically create a Transfer for each of the associated subscription's invoices.
            [<Config.Form>]
            TransferData: Choice<Create'DefaultSettingsTransferDataTransferDataSpecs,string> option
        }

    module Create'DefaultSettings =
        let create
            (
                applicationFeePercent: decimal option,
                automaticTax: Create'DefaultSettingsAutomaticTax option,
                billingCycleAnchor: Create'DefaultSettingsBillingCycleAnchor option,
                billingThresholds: Choice<Create'DefaultSettingsBillingThresholdsBillingThresholds,string> option,
                collectionMethod: Create'DefaultSettingsCollectionMethod option,
                defaultPaymentMethod: string option,
                description: Choice<string,string> option,
                invoiceSettings: Create'DefaultSettingsInvoiceSettings option,
                onBehalfOf: Choice<string,string> option,
                transferData: Choice<Create'DefaultSettingsTransferDataTransferDataSpecs,string> option
            ) : Create'DefaultSettings
            =
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

    type Create'EndBehavior =
        | Cancel
        | [<JsonPropertyName("none")>] None'
        | Release
        | Renew

    type Create'PhasesAddInvoiceItemsDiscounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    module Create'PhasesAddInvoiceItemsDiscounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Create'PhasesAddInvoiceItemsDiscounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Create'PhasesAddInvoiceItemsPeriodEndType =
        | MinItemPeriodEnd
        | PhaseEnd
        | Timestamp

    type Create'PhasesAddInvoiceItemsPeriodEnd =
        {
            /// A precise Unix timestamp for the end of the invoice item period. Must be greater than or equal to `period.start`.
            [<Config.Form>]
            Timestamp: DateTime option
            /// Select how to calculate the end of the invoice item period.
            [<Config.Form>]
            Type: Create'PhasesAddInvoiceItemsPeriodEndType option
        }

    module Create'PhasesAddInvoiceItemsPeriodEnd =
        let create
            (
                timestamp: DateTime option,
                ``type``: Create'PhasesAddInvoiceItemsPeriodEndType option
            ) : Create'PhasesAddInvoiceItemsPeriodEnd
            =
            {
              Timestamp = timestamp
              Type = ``type``
            }

    type Create'PhasesAddInvoiceItemsPeriodStartType =
        | MaxItemPeriodStart
        | PhaseStart
        | Timestamp

    type Create'PhasesAddInvoiceItemsPeriodStart =
        {
            /// A precise Unix timestamp for the start of the invoice item period. Must be less than or equal to `period.end`.
            [<Config.Form>]
            Timestamp: DateTime option
            /// Select how to calculate the start of the invoice item period.
            [<Config.Form>]
            Type: Create'PhasesAddInvoiceItemsPeriodStartType option
        }

    module Create'PhasesAddInvoiceItemsPeriodStart =
        let create
            (
                timestamp: DateTime option,
                ``type``: Create'PhasesAddInvoiceItemsPeriodStartType option
            ) : Create'PhasesAddInvoiceItemsPeriodStart
            =
            {
              Timestamp = timestamp
              Type = ``type``
            }

    type Create'PhasesAddInvoiceItemsPeriod =
        {
            /// End of the invoice item period.
            [<Config.Form>]
            End: Create'PhasesAddInvoiceItemsPeriodEnd option
            /// Start of the invoice item period.
            [<Config.Form>]
            Start: Create'PhasesAddInvoiceItemsPeriodStart option
        }

    module Create'PhasesAddInvoiceItemsPeriod =
        let create
            (
                ``end``: Create'PhasesAddInvoiceItemsPeriodEnd option,
                start: Create'PhasesAddInvoiceItemsPeriodStart option
            ) : Create'PhasesAddInvoiceItemsPeriod
            =
            {
              End = ``end``
              Start = start
            }

    type Create'PhasesAddInvoiceItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Create'PhasesAddInvoiceItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Create'PhasesAddInvoiceItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge or a negative integer representing the amount to credit to the customer.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Create'PhasesAddInvoiceItemsPriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                taxBehavior: Create'PhasesAddInvoiceItemsPriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Create'PhasesAddInvoiceItemsPriceData
            =
            {
              Currency = currency
              Product = product
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Create'PhasesAddInvoiceItems =
        {
            /// The coupons to redeem into discounts for the item.
            [<Config.Form>]
            Discounts: Create'PhasesAddInvoiceItemsDiscounts list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The period associated with this invoice item. If not set, `period.start.type` defaults to `max_item_period_start` and `period.end.type` defaults to `min_item_period_end`.
            [<Config.Form>]
            Period: Create'PhasesAddInvoiceItemsPeriod option
            /// The ID of the price object. One of `price` or `price_data` is required.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.
            [<Config.Form>]
            PriceData: Create'PhasesAddInvoiceItemsPriceData option
            /// Quantity for this item. Defaults to 1.
            [<Config.Form>]
            Quantity: int option
            /// The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    module Create'PhasesAddInvoiceItems =
        let create
            (
                discounts: Create'PhasesAddInvoiceItemsDiscounts list option,
                metadata: Map<string, string> option,
                period: Create'PhasesAddInvoiceItemsPeriod option,
                price: string option,
                priceData: Create'PhasesAddInvoiceItemsPriceData option,
                quantity: int option,
                taxRates: Choice<string list,string> option
            ) : Create'PhasesAddInvoiceItems
            =
            {
              Discounts = discounts
              Metadata = metadata
              Period = period
              Price = price
              PriceData = priceData
              Quantity = quantity
              TaxRates = taxRates
            }

    type Create'PhasesAutomaticTaxLiabilityType =
        | Account
        | Self

    type Create'PhasesAutomaticTaxLiability =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Create'PhasesAutomaticTaxLiabilityType option
        }

    module Create'PhasesAutomaticTaxLiability =
        let create
            (
                account: string option,
                ``type``: Create'PhasesAutomaticTaxLiabilityType option
            ) : Create'PhasesAutomaticTaxLiability
            =
            {
              Account = account
              Type = ``type``
            }

    type Create'PhasesAutomaticTax =
        {
            /// Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.
            [<Config.Form>]
            Enabled: bool option
            /// The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.
            [<Config.Form>]
            Liability: Create'PhasesAutomaticTaxLiability option
        }

    module Create'PhasesAutomaticTax =
        let create
            (
                enabled: bool option,
                liability: Create'PhasesAutomaticTaxLiability option
            ) : Create'PhasesAutomaticTax
            =
            {
              Enabled = enabled
              Liability = liability
            }

    type Create'PhasesBillingCycleAnchor =
        | Automatic
        | PhaseStart

    type Create'PhasesBillingThresholdsBillingThresholds =
        {
            /// Monetary threshold that triggers the subscription to advance to a new billing period
            [<Config.Form>]
            AmountGte: int option
            /// Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
            [<Config.Form>]
            ResetBillingCycleAnchor: bool option
        }

    module Create'PhasesBillingThresholdsBillingThresholds =
        let create
            (
                amountGte: int option,
                resetBillingCycleAnchor: bool option
            ) : Create'PhasesBillingThresholdsBillingThresholds
            =
            {
              AmountGte = amountGte
              ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Create'PhasesCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type Create'PhasesDiscounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    module Create'PhasesDiscounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Create'PhasesDiscounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Create'PhasesDurationInterval =
        | Day
        | Month
        | Week
        | Year

    type Create'PhasesDuration =
        {
            /// Specifies phase duration. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Create'PhasesDurationInterval option
            /// The multiplier applied to the interval.
            [<Config.Form>]
            IntervalCount: int option
        }

    module Create'PhasesDuration =
        let create
            (
                interval: Create'PhasesDurationInterval option,
                intervalCount: int option
            ) : Create'PhasesDuration
            =
            {
              Interval = interval
              IntervalCount = intervalCount
            }

    type Create'PhasesInvoiceSettingsIssuerType =
        | Account
        | Self

    type Create'PhasesInvoiceSettingsIssuer =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Create'PhasesInvoiceSettingsIssuerType option
        }

    module Create'PhasesInvoiceSettingsIssuer =
        let create
            (
                account: string option,
                ``type``: Create'PhasesInvoiceSettingsIssuerType option
            ) : Create'PhasesInvoiceSettingsIssuer
            =
            {
              Account = account
              Type = ``type``
            }

    type Create'PhasesInvoiceSettings =
        {
            /// The account tax IDs associated with this phase of the subscription schedule. Will be set on invoices generated by this phase of the subscription schedule.
            [<Config.Form>]
            AccountTaxIds: Choice<string list,string> option
            /// Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `billing=charge_automatically`.
            [<Config.Form>]
            DaysUntilDue: int option
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: Create'PhasesInvoiceSettingsIssuer option
        }

    module Create'PhasesInvoiceSettings =
        let create
            (
                accountTaxIds: Choice<string list,string> option,
                daysUntilDue: int option,
                issuer: Create'PhasesInvoiceSettingsIssuer option
            ) : Create'PhasesInvoiceSettings
            =
            {
              AccountTaxIds = accountTaxIds
              DaysUntilDue = daysUntilDue
              Issuer = issuer
            }

    type Create'PhasesItemsBillingThresholdsItemBillingThresholds =
        {
            /// Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
            [<Config.Form>]
            UsageGte: int option
        }

    module Create'PhasesItemsBillingThresholdsItemBillingThresholds =
        let create
            (
                usageGte: int option
            ) : Create'PhasesItemsBillingThresholdsItemBillingThresholds
            =
            {
              UsageGte = usageGte
            }

    type Create'PhasesItemsDiscounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    module Create'PhasesItemsDiscounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Create'PhasesItemsDiscounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Create'PhasesItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type Create'PhasesItemsPriceDataRecurring =
        {
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Create'PhasesItemsPriceDataRecurringInterval option
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    module Create'PhasesItemsPriceDataRecurring =
        let create
            (
                interval: Create'PhasesItemsPriceDataRecurringInterval option,
                intervalCount: int option
            ) : Create'PhasesItemsPriceDataRecurring
            =
            {
              Interval = interval
              IntervalCount = intervalCount
            }

    type Create'PhasesItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Create'PhasesItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// The recurring components of a price such as `interval` and `interval_count`.
            [<Config.Form>]
            Recurring: Create'PhasesItemsPriceDataRecurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Create'PhasesItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Create'PhasesItemsPriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                recurring: Create'PhasesItemsPriceDataRecurring option,
                taxBehavior: Create'PhasesItemsPriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Create'PhasesItemsPriceData
            =
            {
              Currency = currency
              Product = product
              Recurring = recurring
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Create'PhasesItems =
        {
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds: Choice<Create'PhasesItemsBillingThresholdsItemBillingThresholds,string> option
            /// The coupons to redeem into discounts for the subscription item.
            [<Config.Form>]
            Discounts: Choice<Create'PhasesItemsDiscounts list,string> option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to a configuration item. Metadata on a configuration item will update the underlying subscription item's `metadata` when the phase is entered, adding new keys and replacing existing keys. Individual keys in the subscription item's `metadata` can be unset by posting an empty value to them in the configuration item's `metadata`. To unset all keys in the subscription item's `metadata`, update the subscription item directly or unset every key individually from the configuration item's `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The plan ID to subscribe to. You may specify the same ID in `plan` and `price`.
            [<Config.Form>]
            Plan: string option
            /// The ID of the price object.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.
            [<Config.Form>]
            PriceData: Create'PhasesItemsPriceData option
            /// Quantity for the given price. Can be set only if the price's `usage_type` is `licensed` and not `metered`.
            [<Config.Form>]
            Quantity: int option
            /// A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    module Create'PhasesItems =
        let create
            (
                billingThresholds: Choice<Create'PhasesItemsBillingThresholdsItemBillingThresholds,string> option,
                discounts: Choice<Create'PhasesItemsDiscounts list,string> option,
                metadata: Map<string, string> option,
                plan: string option,
                price: string option,
                priceData: Create'PhasesItemsPriceData option,
                quantity: int option,
                taxRates: Choice<string list,string> option
            ) : Create'PhasesItems
            =
            {
              BillingThresholds = billingThresholds
              Discounts = discounts
              Metadata = metadata
              Plan = plan
              Price = price
              PriceData = priceData
              Quantity = quantity
              TaxRates = taxRates
            }

    type Create'PhasesProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type Create'PhasesTransferData =
        {
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
            [<Config.Form>]
            AmountPercent: decimal option
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Destination: string option
        }

    module Create'PhasesTransferData =
        let create
            (
                amountPercent: decimal option,
                destination: string option
            ) : Create'PhasesTransferData
            =
            {
              AmountPercent = amountPercent
              Destination = destination
            }

    type Create'Phases =
        {
            /// A list of prices and quantities that will generate invoice items appended to the next invoice for this phase. You may pass up to 20 items.
            [<Config.Form>]
            AddInvoiceItems: Create'PhasesAddInvoiceItems list option
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
            [<Config.Form>]
            ApplicationFeePercent: decimal option
            /// Automatic tax settings for this phase.
            [<Config.Form>]
            AutomaticTax: Create'PhasesAutomaticTax option
            /// Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).
            [<Config.Form>]
            BillingCycleAnchor: Create'PhasesBillingCycleAnchor option
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds: Choice<Create'PhasesBillingThresholdsBillingThresholds,string> option
            /// Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.
            [<Config.Form>]
            CollectionMethod: Create'PhasesCollectionMethod option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
            [<Config.Form>]
            DefaultPaymentMethod: string option
            /// A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will set the Subscription's [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates), which means they will be the Invoice's [`default_tax_rates`](https://docs.stripe.com/api/invoices/create#create_invoice-default_tax_rates) for any Invoices issued by the Subscription during this Phase.
            [<Config.Form>]
            DefaultTaxRates: Choice<string list,string> option
            /// Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.
            [<Config.Form>]
            Description: Choice<string,string> option
            /// The coupons to redeem into discounts for the schedule phase. If not specified, inherits the discount from the subscription's customer. Pass an empty string to avoid inheriting any discounts.
            [<Config.Form>]
            Discounts: Choice<Create'PhasesDiscounts list,string> option
            /// The number of intervals the phase should last. If set, `end_date` must not be set.
            [<Config.Form>]
            Duration: Create'PhasesDuration option
            /// The date at which this phase of the subscription schedule ends. If set, `duration` must not be set.
            [<Config.Form>]
            EndDate: DateTime option
            /// All invoices will be billed using the specified settings.
            [<Config.Form>]
            InvoiceSettings: Create'PhasesInvoiceSettings option
            /// List of configuration items, each with an attached price, to apply during this phase of the subscription schedule.
            [<Config.Form>]
            Items: Create'PhasesItems list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to a phase. Metadata on a schedule's phase will update the underlying subscription's `metadata` when the phase is entered, adding new keys and replacing existing keys in the subscription's `metadata`. Individual keys in the subscription's `metadata` can be unset by posting an empty value to them in the phase's `metadata`. To unset all keys in the subscription's `metadata`, update the subscription directly or unset every key individually from the phase's `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The account on behalf of which to charge, for each of the associated subscription's invoices.
            [<Config.Form>]
            OnBehalfOf: string option
            /// Controls whether the subscription schedule should create [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when transitioning to this phase if there is a difference in billing configuration. It's different from the request-level [proration_behavior](https://docs.stripe.com/api/subscription_schedules/update#update_subscription_schedule-proration_behavior) parameter which controls what happens if the update request affects the billing configuration (item price, quantity, etc.) of the current phase.
            [<Config.Form>]
            ProrationBehavior: Create'PhasesProrationBehavior option
            /// The data with which to automatically create a Transfer for each of the associated subscription's invoices.
            [<Config.Form>]
            TransferData: Create'PhasesTransferData option
            /// If set to true the entire phase is counted as a trial and the customer will not be charged for any fees.
            [<Config.Form>]
            Trial: bool option
            /// Sets the phase to trialing from the start date to this date. Must be before the phase end date, can not be combined with `trial`
            [<Config.Form>]
            TrialEnd: DateTime option
        }

    module Create'Phases =
        let create
            (
                addInvoiceItems: Create'PhasesAddInvoiceItems list option,
                applicationFeePercent: decimal option,
                automaticTax: Create'PhasesAutomaticTax option,
                billingCycleAnchor: Create'PhasesBillingCycleAnchor option,
                billingThresholds: Choice<Create'PhasesBillingThresholdsBillingThresholds,string> option,
                collectionMethod: Create'PhasesCollectionMethod option,
                currency: IsoTypes.IsoCurrencyCode option,
                defaultPaymentMethod: string option,
                defaultTaxRates: Choice<string list,string> option,
                description: Choice<string,string> option,
                discounts: Choice<Create'PhasesDiscounts list,string> option,
                duration: Create'PhasesDuration option,
                endDate: DateTime option,
                invoiceSettings: Create'PhasesInvoiceSettings option,
                items: Create'PhasesItems list option,
                metadata: Map<string, string> option,
                onBehalfOf: string option,
                prorationBehavior: Create'PhasesProrationBehavior option,
                transferData: Create'PhasesTransferData option,
                trial: bool option,
                trialEnd: DateTime option
            ) : Create'Phases
            =
            {
              AddInvoiceItems = addInvoiceItems
              ApplicationFeePercent = applicationFeePercent
              AutomaticTax = automaticTax
              BillingCycleAnchor = billingCycleAnchor
              BillingThresholds = billingThresholds
              CollectionMethod = collectionMethod
              Currency = currency
              DefaultPaymentMethod = defaultPaymentMethod
              DefaultTaxRates = defaultTaxRates
              Description = description
              Discounts = discounts
              Duration = duration
              EndDate = endDate
              InvoiceSettings = invoiceSettings
              Items = items
              Metadata = metadata
              OnBehalfOf = onBehalfOf
              ProrationBehavior = prorationBehavior
              TransferData = transferData
              Trial = trial
              TrialEnd = trialEnd
            }

    type Create'StartDate = | Now

    type CreateOptions =
        {
            /// Controls how prorations and invoices for subscriptions are calculated and orchestrated.
            [<Config.Form>]
            BillingMode: Create'BillingMode option
            /// The identifier of the customer to create the subscription schedule for.
            [<Config.Form>]
            Customer: string option
            /// The identifier of the account to create the subscription schedule for.
            [<Config.Form>]
            CustomerAccount: string option
            /// Object representing the subscription schedule's default settings.
            [<Config.Form>]
            DefaultSettings: Create'DefaultSettings option
            /// Behavior of the subscription schedule and underlying subscription when it ends. Possible values are `release` or `cancel` with the default being `release`. `release` will end the subscription schedule and keep the underlying subscription running. `cancel` will end the subscription schedule and cancel the underlying subscription.
            [<Config.Form>]
            EndBehavior: Create'EndBehavior option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Migrate an existing subscription to be managed by a subscription schedule. If this parameter is set, a subscription schedule will be created using the subscription's item(s), set to auto-renew using the subscription's interval. When using this parameter, other parameters (such as phase values) cannot be set. To create a subscription schedule with other modifications, we recommend making two separate API calls.
            [<Config.Form>]
            FromSubscription: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// List representing phases of the subscription schedule. Each phase can be customized to have different durations, plans, and coupons. If there are multiple phases, the `end_date` of one phase will always equal the `start_date` of the next phase.
            [<Config.Form>]
            Phases: Create'Phases list option
            /// When the subscription schedule starts. We recommend using `now` so that it starts the subscription immediately. You can also use a Unix timestamp to backdate the subscription so that it starts on a past date, or set a future date for the subscription to start on.
            [<Config.Form>]
            StartDate: Choice<DateTime,Create'StartDate> option
        }

    module CreateOptions =
        let create
            (
                billingMode: Create'BillingMode option,
                customer: string option,
                customerAccount: string option,
                defaultSettings: Create'DefaultSettings option,
                endBehavior: Create'EndBehavior option,
                expand: string list option,
                fromSubscription: string option,
                metadata: Map<string, string> option,
                phases: Create'Phases list option,
                startDate: Choice<DateTime,Create'StartDate> option
            ) : CreateOptions
            =
            {
              BillingMode = billingMode
              Customer = customer
              CustomerAccount = customerAccount
              DefaultSettings = defaultSettings
              EndBehavior = endBehavior
              Expand = expand
              FromSubscription = fromSubscription
              Metadata = metadata
              Phases = phases
              StartDate = startDate
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Schedule: string
        }

    module RetrieveOptions =
        let create
            (
                schedule: string
            ) : RetrieveOptions
            =
            {
              Schedule = schedule
              Expand = None
            }

    type Update'DefaultSettingsAutomaticTaxLiabilityType =
        | Account
        | Self

    type Update'DefaultSettingsAutomaticTaxLiability =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Update'DefaultSettingsAutomaticTaxLiabilityType option
        }

    module Update'DefaultSettingsAutomaticTaxLiability =
        let create
            (
                account: string option,
                ``type``: Update'DefaultSettingsAutomaticTaxLiabilityType option
            ) : Update'DefaultSettingsAutomaticTaxLiability
            =
            {
              Account = account
              Type = ``type``
            }

    type Update'DefaultSettingsAutomaticTax =
        {
            /// Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.
            [<Config.Form>]
            Enabled: bool option
            /// The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.
            [<Config.Form>]
            Liability: Update'DefaultSettingsAutomaticTaxLiability option
        }

    module Update'DefaultSettingsAutomaticTax =
        let create
            (
                enabled: bool option,
                liability: Update'DefaultSettingsAutomaticTaxLiability option
            ) : Update'DefaultSettingsAutomaticTax
            =
            {
              Enabled = enabled
              Liability = liability
            }

    type Update'DefaultSettingsBillingCycleAnchor =
        | Automatic
        | PhaseStart

    type Update'DefaultSettingsBillingThresholdsBillingThresholds =
        {
            /// Monetary threshold that triggers the subscription to advance to a new billing period
            [<Config.Form>]
            AmountGte: int option
            /// Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
            [<Config.Form>]
            ResetBillingCycleAnchor: bool option
        }

    module Update'DefaultSettingsBillingThresholdsBillingThresholds =
        let create
            (
                amountGte: int option,
                resetBillingCycleAnchor: bool option
            ) : Update'DefaultSettingsBillingThresholdsBillingThresholds
            =
            {
              AmountGte = amountGte
              ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Update'DefaultSettingsCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type Update'DefaultSettingsInvoiceSettingsIssuerType =
        | Account
        | Self

    type Update'DefaultSettingsInvoiceSettingsIssuer =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Update'DefaultSettingsInvoiceSettingsIssuerType option
        }

    module Update'DefaultSettingsInvoiceSettingsIssuer =
        let create
            (
                account: string option,
                ``type``: Update'DefaultSettingsInvoiceSettingsIssuerType option
            ) : Update'DefaultSettingsInvoiceSettingsIssuer
            =
            {
              Account = account
              Type = ``type``
            }

    type Update'DefaultSettingsInvoiceSettings =
        {
            /// The account tax IDs associated with the subscription schedule. Will be set on invoices generated by the subscription schedule.
            [<Config.Form>]
            AccountTaxIds: Choice<string list,string> option
            /// Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `collection_method=charge_automatically`.
            [<Config.Form>]
            DaysUntilDue: int option
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: Update'DefaultSettingsInvoiceSettingsIssuer option
        }

    module Update'DefaultSettingsInvoiceSettings =
        let create
            (
                accountTaxIds: Choice<string list,string> option,
                daysUntilDue: int option,
                issuer: Update'DefaultSettingsInvoiceSettingsIssuer option
            ) : Update'DefaultSettingsInvoiceSettings
            =
            {
              AccountTaxIds = accountTaxIds
              DaysUntilDue = daysUntilDue
              Issuer = issuer
            }

    type Update'DefaultSettingsTransferDataTransferDataSpecs =
        {
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
            [<Config.Form>]
            AmountPercent: decimal option
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Destination: string option
        }

    module Update'DefaultSettingsTransferDataTransferDataSpecs =
        let create
            (
                amountPercent: decimal option,
                destination: string option
            ) : Update'DefaultSettingsTransferDataTransferDataSpecs
            =
            {
              AmountPercent = amountPercent
              Destination = destination
            }

    type Update'DefaultSettings =
        {
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
            [<Config.Form>]
            ApplicationFeePercent: decimal option
            /// Default settings for automatic tax computation.
            [<Config.Form>]
            AutomaticTax: Update'DefaultSettingsAutomaticTax option
            /// Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).
            [<Config.Form>]
            BillingCycleAnchor: Update'DefaultSettingsBillingCycleAnchor option
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds: Choice<Update'DefaultSettingsBillingThresholdsBillingThresholds,string> option
            /// Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.
            [<Config.Form>]
            CollectionMethod: Update'DefaultSettingsCollectionMethod option
            /// ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
            [<Config.Form>]
            DefaultPaymentMethod: string option
            /// Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.
            [<Config.Form>]
            Description: Choice<string,string> option
            /// All invoices will be billed using the specified settings.
            [<Config.Form>]
            InvoiceSettings: Update'DefaultSettingsInvoiceSettings option
            /// The account on behalf of which to charge, for each of the associated subscription's invoices.
            [<Config.Form>]
            OnBehalfOf: Choice<string,string> option
            /// The data with which to automatically create a Transfer for each of the associated subscription's invoices.
            [<Config.Form>]
            TransferData: Choice<Update'DefaultSettingsTransferDataTransferDataSpecs,string> option
        }

    module Update'DefaultSettings =
        let create
            (
                applicationFeePercent: decimal option,
                automaticTax: Update'DefaultSettingsAutomaticTax option,
                billingCycleAnchor: Update'DefaultSettingsBillingCycleAnchor option,
                billingThresholds: Choice<Update'DefaultSettingsBillingThresholdsBillingThresholds,string> option,
                collectionMethod: Update'DefaultSettingsCollectionMethod option,
                defaultPaymentMethod: string option,
                description: Choice<string,string> option,
                invoiceSettings: Update'DefaultSettingsInvoiceSettings option,
                onBehalfOf: Choice<string,string> option,
                transferData: Choice<Update'DefaultSettingsTransferDataTransferDataSpecs,string> option
            ) : Update'DefaultSettings
            =
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

    type Update'EndBehavior =
        | Cancel
        | [<JsonPropertyName("none")>] None'
        | Release
        | Renew

    type Update'PhasesAddInvoiceItemsDiscounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    module Update'PhasesAddInvoiceItemsDiscounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Update'PhasesAddInvoiceItemsDiscounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Update'PhasesAddInvoiceItemsPeriodEndType =
        | MinItemPeriodEnd
        | PhaseEnd
        | Timestamp

    type Update'PhasesAddInvoiceItemsPeriodEnd =
        {
            /// A precise Unix timestamp for the end of the invoice item period. Must be greater than or equal to `period.start`.
            [<Config.Form>]
            Timestamp: DateTime option
            /// Select how to calculate the end of the invoice item period.
            [<Config.Form>]
            Type: Update'PhasesAddInvoiceItemsPeriodEndType option
        }

    module Update'PhasesAddInvoiceItemsPeriodEnd =
        let create
            (
                timestamp: DateTime option,
                ``type``: Update'PhasesAddInvoiceItemsPeriodEndType option
            ) : Update'PhasesAddInvoiceItemsPeriodEnd
            =
            {
              Timestamp = timestamp
              Type = ``type``
            }

    type Update'PhasesAddInvoiceItemsPeriodStartType =
        | MaxItemPeriodStart
        | PhaseStart
        | Timestamp

    type Update'PhasesAddInvoiceItemsPeriodStart =
        {
            /// A precise Unix timestamp for the start of the invoice item period. Must be less than or equal to `period.end`.
            [<Config.Form>]
            Timestamp: DateTime option
            /// Select how to calculate the start of the invoice item period.
            [<Config.Form>]
            Type: Update'PhasesAddInvoiceItemsPeriodStartType option
        }

    module Update'PhasesAddInvoiceItemsPeriodStart =
        let create
            (
                timestamp: DateTime option,
                ``type``: Update'PhasesAddInvoiceItemsPeriodStartType option
            ) : Update'PhasesAddInvoiceItemsPeriodStart
            =
            {
              Timestamp = timestamp
              Type = ``type``
            }

    type Update'PhasesAddInvoiceItemsPeriod =
        {
            /// End of the invoice item period.
            [<Config.Form>]
            End: Update'PhasesAddInvoiceItemsPeriodEnd option
            /// Start of the invoice item period.
            [<Config.Form>]
            Start: Update'PhasesAddInvoiceItemsPeriodStart option
        }

    module Update'PhasesAddInvoiceItemsPeriod =
        let create
            (
                ``end``: Update'PhasesAddInvoiceItemsPeriodEnd option,
                start: Update'PhasesAddInvoiceItemsPeriodStart option
            ) : Update'PhasesAddInvoiceItemsPeriod
            =
            {
              End = ``end``
              Start = start
            }

    type Update'PhasesAddInvoiceItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Update'PhasesAddInvoiceItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Update'PhasesAddInvoiceItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge or a negative integer representing the amount to credit to the customer.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Update'PhasesAddInvoiceItemsPriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                taxBehavior: Update'PhasesAddInvoiceItemsPriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Update'PhasesAddInvoiceItemsPriceData
            =
            {
              Currency = currency
              Product = product
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Update'PhasesAddInvoiceItems =
        {
            /// The coupons to redeem into discounts for the item.
            [<Config.Form>]
            Discounts: Update'PhasesAddInvoiceItemsDiscounts list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The period associated with this invoice item. If not set, `period.start.type` defaults to `max_item_period_start` and `period.end.type` defaults to `min_item_period_end`.
            [<Config.Form>]
            Period: Update'PhasesAddInvoiceItemsPeriod option
            /// The ID of the price object. One of `price` or `price_data` is required.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.
            [<Config.Form>]
            PriceData: Update'PhasesAddInvoiceItemsPriceData option
            /// Quantity for this item. Defaults to 1.
            [<Config.Form>]
            Quantity: int option
            /// The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    module Update'PhasesAddInvoiceItems =
        let create
            (
                discounts: Update'PhasesAddInvoiceItemsDiscounts list option,
                metadata: Map<string, string> option,
                period: Update'PhasesAddInvoiceItemsPeriod option,
                price: string option,
                priceData: Update'PhasesAddInvoiceItemsPriceData option,
                quantity: int option,
                taxRates: Choice<string list,string> option
            ) : Update'PhasesAddInvoiceItems
            =
            {
              Discounts = discounts
              Metadata = metadata
              Period = period
              Price = price
              PriceData = priceData
              Quantity = quantity
              TaxRates = taxRates
            }

    type Update'PhasesAutomaticTaxLiabilityType =
        | Account
        | Self

    type Update'PhasesAutomaticTaxLiability =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Update'PhasesAutomaticTaxLiabilityType option
        }

    module Update'PhasesAutomaticTaxLiability =
        let create
            (
                account: string option,
                ``type``: Update'PhasesAutomaticTaxLiabilityType option
            ) : Update'PhasesAutomaticTaxLiability
            =
            {
              Account = account
              Type = ``type``
            }

    type Update'PhasesAutomaticTax =
        {
            /// Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.
            [<Config.Form>]
            Enabled: bool option
            /// The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.
            [<Config.Form>]
            Liability: Update'PhasesAutomaticTaxLiability option
        }

    module Update'PhasesAutomaticTax =
        let create
            (
                enabled: bool option,
                liability: Update'PhasesAutomaticTaxLiability option
            ) : Update'PhasesAutomaticTax
            =
            {
              Enabled = enabled
              Liability = liability
            }

    type Update'PhasesBillingCycleAnchor =
        | Automatic
        | PhaseStart

    type Update'PhasesBillingThresholdsBillingThresholds =
        {
            /// Monetary threshold that triggers the subscription to advance to a new billing period
            [<Config.Form>]
            AmountGte: int option
            /// Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.
            [<Config.Form>]
            ResetBillingCycleAnchor: bool option
        }

    module Update'PhasesBillingThresholdsBillingThresholds =
        let create
            (
                amountGte: int option,
                resetBillingCycleAnchor: bool option
            ) : Update'PhasesBillingThresholdsBillingThresholds
            =
            {
              AmountGte = amountGte
              ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Update'PhasesCollectionMethod =
        | ChargeAutomatically
        | SendInvoice

    type Update'PhasesDiscounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    module Update'PhasesDiscounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Update'PhasesDiscounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Update'PhasesDurationInterval =
        | Day
        | Month
        | Week
        | Year

    type Update'PhasesDuration =
        {
            /// Specifies phase duration. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Update'PhasesDurationInterval option
            /// The multiplier applied to the interval.
            [<Config.Form>]
            IntervalCount: int option
        }

    module Update'PhasesDuration =
        let create
            (
                interval: Update'PhasesDurationInterval option,
                intervalCount: int option
            ) : Update'PhasesDuration
            =
            {
              Interval = interval
              IntervalCount = intervalCount
            }

    type Update'PhasesEndDate = | Now

    type Update'PhasesInvoiceSettingsIssuerType =
        | Account
        | Self

    type Update'PhasesInvoiceSettingsIssuer =
        {
            /// The connected account being referenced when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// Type of the account referenced in the request.
            [<Config.Form>]
            Type: Update'PhasesInvoiceSettingsIssuerType option
        }

    module Update'PhasesInvoiceSettingsIssuer =
        let create
            (
                account: string option,
                ``type``: Update'PhasesInvoiceSettingsIssuerType option
            ) : Update'PhasesInvoiceSettingsIssuer
            =
            {
              Account = account
              Type = ``type``
            }

    type Update'PhasesInvoiceSettings =
        {
            /// The account tax IDs associated with this phase of the subscription schedule. Will be set on invoices generated by this phase of the subscription schedule.
            [<Config.Form>]
            AccountTaxIds: Choice<string list,string> option
            /// Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `billing=charge_automatically`.
            [<Config.Form>]
            DaysUntilDue: int option
            /// The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.
            [<Config.Form>]
            Issuer: Update'PhasesInvoiceSettingsIssuer option
        }

    module Update'PhasesInvoiceSettings =
        let create
            (
                accountTaxIds: Choice<string list,string> option,
                daysUntilDue: int option,
                issuer: Update'PhasesInvoiceSettingsIssuer option
            ) : Update'PhasesInvoiceSettings
            =
            {
              AccountTaxIds = accountTaxIds
              DaysUntilDue = daysUntilDue
              Issuer = issuer
            }

    type Update'PhasesItemsBillingThresholdsItemBillingThresholds =
        {
            /// Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
            [<Config.Form>]
            UsageGte: int option
        }

    module Update'PhasesItemsBillingThresholdsItemBillingThresholds =
        let create
            (
                usageGte: int option
            ) : Update'PhasesItemsBillingThresholdsItemBillingThresholds
            =
            {
              UsageGte = usageGte
            }

    type Update'PhasesItemsDiscounts =
        {
            /// ID of the coupon to create a new discount for.
            [<Config.Form>]
            Coupon: string option
            /// ID of an existing discount on the object (or one of its ancestors) to reuse.
            [<Config.Form>]
            Discount: string option
            /// ID of the promotion code to create a new discount for.
            [<Config.Form>]
            PromotionCode: string option
        }

    module Update'PhasesItemsDiscounts =
        let create
            (
                coupon: string option,
                discount: string option,
                promotionCode: string option
            ) : Update'PhasesItemsDiscounts
            =
            {
              Coupon = coupon
              Discount = discount
              PromotionCode = promotionCode
            }

    type Update'PhasesItemsPriceDataRecurringInterval =
        | Day
        | Month
        | Week
        | Year

    type Update'PhasesItemsPriceDataRecurring =
        {
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Update'PhasesItemsPriceDataRecurringInterval option
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
        }

    module Update'PhasesItemsPriceDataRecurring =
        let create
            (
                interval: Update'PhasesItemsPriceDataRecurringInterval option,
                intervalCount: int option
            ) : Update'PhasesItemsPriceDataRecurring
            =
            {
              Interval = interval
              IntervalCount = intervalCount
            }

    type Update'PhasesItemsPriceDataTaxBehavior =
        | Exclusive
        | Inclusive
        | Unspecified

    type Update'PhasesItemsPriceData =
        {
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.
            [<Config.Form>]
            Product: string option
            /// The recurring components of a price such as `interval` and `interval_count`.
            [<Config.Form>]
            Recurring: Update'PhasesItemsPriceDataRecurring option
            /// Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
            [<Config.Form>]
            TaxBehavior: Update'PhasesItemsPriceDataTaxBehavior option
            /// A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
        }

    module Update'PhasesItemsPriceData =
        let create
            (
                currency: IsoTypes.IsoCurrencyCode option,
                product: string option,
                recurring: Update'PhasesItemsPriceDataRecurring option,
                taxBehavior: Update'PhasesItemsPriceDataTaxBehavior option,
                unitAmount: int option,
                unitAmountDecimal: string option
            ) : Update'PhasesItemsPriceData
            =
            {
              Currency = currency
              Product = product
              Recurring = recurring
              TaxBehavior = taxBehavior
              UnitAmount = unitAmount
              UnitAmountDecimal = unitAmountDecimal
            }

    type Update'PhasesItems =
        {
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds: Choice<Update'PhasesItemsBillingThresholdsItemBillingThresholds,string> option
            /// The coupons to redeem into discounts for the subscription item.
            [<Config.Form>]
            Discounts: Choice<Update'PhasesItemsDiscounts list,string> option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to a configuration item. Metadata on a configuration item will update the underlying subscription item's `metadata` when the phase is entered, adding new keys and replacing existing keys. Individual keys in the subscription item's `metadata` can be unset by posting an empty value to them in the configuration item's `metadata`. To unset all keys in the subscription item's `metadata`, update the subscription item directly or unset every key individually from the configuration item's `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The plan ID to subscribe to. You may specify the same ID in `plan` and `price`.
            [<Config.Form>]
            Plan: string option
            /// The ID of the price object.
            [<Config.Form>]
            Price: string option
            /// Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.
            [<Config.Form>]
            PriceData: Update'PhasesItemsPriceData option
            /// Quantity for the given price. Can be set only if the price's `usage_type` is `licensed` and not `metered`.
            [<Config.Form>]
            Quantity: int option
            /// A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.
            [<Config.Form>]
            TaxRates: Choice<string list,string> option
        }

    module Update'PhasesItems =
        let create
            (
                billingThresholds: Choice<Update'PhasesItemsBillingThresholdsItemBillingThresholds,string> option,
                discounts: Choice<Update'PhasesItemsDiscounts list,string> option,
                metadata: Map<string, string> option,
                plan: string option,
                price: string option,
                priceData: Update'PhasesItemsPriceData option,
                quantity: int option,
                taxRates: Choice<string list,string> option
            ) : Update'PhasesItems
            =
            {
              BillingThresholds = billingThresholds
              Discounts = discounts
              Metadata = metadata
              Plan = plan
              Price = price
              PriceData = priceData
              Quantity = quantity
              TaxRates = taxRates
            }

    type Update'PhasesProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type Update'PhasesStartDate = | Now

    type Update'PhasesTransferData =
        {
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.
            [<Config.Form>]
            AmountPercent: decimal option
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Destination: string option
        }

    module Update'PhasesTransferData =
        let create
            (
                amountPercent: decimal option,
                destination: string option
            ) : Update'PhasesTransferData
            =
            {
              AmountPercent = amountPercent
              Destination = destination
            }

    type Update'PhasesTrialEnd = | Now

    type Update'Phases =
        {
            /// A list of prices and quantities that will generate invoice items appended to the next invoice for this phase. You may pass up to 20 items.
            [<Config.Form>]
            AddInvoiceItems: Update'PhasesAddInvoiceItems list option
            /// A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).
            [<Config.Form>]
            ApplicationFeePercent: decimal option
            /// Automatic tax settings for this phase.
            [<Config.Form>]
            AutomaticTax: Update'PhasesAutomaticTax option
            /// Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).
            [<Config.Form>]
            BillingCycleAnchor: Update'PhasesBillingCycleAnchor option
            /// Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.
            [<Config.Form>]
            BillingThresholds: Choice<Update'PhasesBillingThresholdsBillingThresholds,string> option
            /// Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.
            [<Config.Form>]
            CollectionMethod: Update'PhasesCollectionMethod option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.
            [<Config.Form>]
            DefaultPaymentMethod: string option
            /// A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will set the Subscription's [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates), which means they will be the Invoice's [`default_tax_rates`](https://docs.stripe.com/api/invoices/create#create_invoice-default_tax_rates) for any Invoices issued by the Subscription during this Phase.
            [<Config.Form>]
            DefaultTaxRates: Choice<string list,string> option
            /// Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.
            [<Config.Form>]
            Description: Choice<string,string> option
            /// The coupons to redeem into discounts for the schedule phase. If not specified, inherits the discount from the subscription's customer. Pass an empty string to avoid inheriting any discounts.
            [<Config.Form>]
            Discounts: Choice<Update'PhasesDiscounts list,string> option
            /// The number of intervals the phase should last. If set, `end_date` must not be set.
            [<Config.Form>]
            Duration: Update'PhasesDuration option
            /// The date at which this phase of the subscription schedule ends. If set, `duration` must not be set.
            [<Config.Form>]
            EndDate: Choice<DateTime,Update'PhasesEndDate> option
            /// All invoices will be billed using the specified settings.
            [<Config.Form>]
            InvoiceSettings: Update'PhasesInvoiceSettings option
            /// List of configuration items, each with an attached price, to apply during this phase of the subscription schedule.
            [<Config.Form>]
            Items: Update'PhasesItems list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to a phase. Metadata on a schedule's phase will update the underlying subscription's `metadata` when the phase is entered, adding new keys and replacing existing keys in the subscription's `metadata`. Individual keys in the subscription's `metadata` can be unset by posting an empty value to them in the phase's `metadata`. To unset all keys in the subscription's `metadata`, update the subscription directly or unset every key individually from the phase's `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The account on behalf of which to charge, for each of the associated subscription's invoices.
            [<Config.Form>]
            OnBehalfOf: string option
            /// Controls whether the subscription schedule should create [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when transitioning to this phase if there is a difference in billing configuration. It's different from the request-level [proration_behavior](https://docs.stripe.com/api/subscription_schedules/update#update_subscription_schedule-proration_behavior) parameter which controls what happens if the update request affects the billing configuration (item price, quantity, etc.) of the current phase.
            [<Config.Form>]
            ProrationBehavior: Update'PhasesProrationBehavior option
            /// The date at which this phase of the subscription schedule starts or `now`. Must be set on the first phase.
            [<Config.Form>]
            StartDate: Choice<DateTime,Update'PhasesStartDate> option
            /// The data with which to automatically create a Transfer for each of the associated subscription's invoices.
            [<Config.Form>]
            TransferData: Update'PhasesTransferData option
            /// If set to true the entire phase is counted as a trial and the customer will not be charged for any fees.
            [<Config.Form>]
            Trial: bool option
            /// Sets the phase to trialing from the start date to this date. Must be before the phase end date, can not be combined with `trial`
            [<Config.Form>]
            TrialEnd: Choice<DateTime,Update'PhasesTrialEnd> option
        }

    module Update'Phases =
        let create
            (
                addInvoiceItems: Update'PhasesAddInvoiceItems list option,
                applicationFeePercent: decimal option,
                automaticTax: Update'PhasesAutomaticTax option,
                billingCycleAnchor: Update'PhasesBillingCycleAnchor option,
                billingThresholds: Choice<Update'PhasesBillingThresholdsBillingThresholds,string> option,
                collectionMethod: Update'PhasesCollectionMethod option,
                currency: IsoTypes.IsoCurrencyCode option,
                defaultPaymentMethod: string option,
                defaultTaxRates: Choice<string list,string> option,
                description: Choice<string,string> option,
                discounts: Choice<Update'PhasesDiscounts list,string> option,
                duration: Update'PhasesDuration option,
                endDate: Choice<DateTime,Update'PhasesEndDate> option,
                invoiceSettings: Update'PhasesInvoiceSettings option,
                items: Update'PhasesItems list option,
                metadata: Map<string, string> option,
                onBehalfOf: string option,
                prorationBehavior: Update'PhasesProrationBehavior option,
                startDate: Choice<DateTime,Update'PhasesStartDate> option,
                transferData: Update'PhasesTransferData option,
                trial: bool option,
                trialEnd: Choice<DateTime,Update'PhasesTrialEnd> option
            ) : Update'Phases
            =
            {
              AddInvoiceItems = addInvoiceItems
              ApplicationFeePercent = applicationFeePercent
              AutomaticTax = automaticTax
              BillingCycleAnchor = billingCycleAnchor
              BillingThresholds = billingThresholds
              CollectionMethod = collectionMethod
              Currency = currency
              DefaultPaymentMethod = defaultPaymentMethod
              DefaultTaxRates = defaultTaxRates
              Description = description
              Discounts = discounts
              Duration = duration
              EndDate = endDate
              InvoiceSettings = invoiceSettings
              Items = items
              Metadata = metadata
              OnBehalfOf = onBehalfOf
              ProrationBehavior = prorationBehavior
              StartDate = startDate
              TransferData = transferData
              Trial = trial
              TrialEnd = trialEnd
            }

    type Update'ProrationBehavior =
        | AlwaysInvoice
        | CreateProrations
        | [<JsonPropertyName("none")>] None'

    type UpdateOptions =
        {
            [<Config.Path>]
            Schedule: string
            /// Object representing the subscription schedule's default settings.
            [<Config.Form>]
            DefaultSettings: Update'DefaultSettings option
            /// Behavior of the subscription schedule and underlying subscription when it ends. Possible values are `release` or `cancel` with the default being `release`. `release` will end the subscription schedule and keep the underlying subscription running. `cancel` will end the subscription schedule and cancel the underlying subscription.
            [<Config.Form>]
            EndBehavior: Update'EndBehavior option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// List representing phases of the subscription schedule. Each phase can be customized to have different durations, plans, and coupons. If there are multiple phases, the `end_date` of one phase will always equal the `start_date` of the next phase. Note that past phases can be omitted.
            [<Config.Form>]
            Phases: Update'Phases list option
            /// If the update changes the billing configuration (item price, quantity, etc.) of the current phase, indicates how prorations from this change should be handled. The default value is `create_prorations`.
            [<Config.Form>]
            ProrationBehavior: Update'ProrationBehavior option
        }

    module UpdateOptions =
        let create
            (
                schedule: string
            ) : UpdateOptions
            =
            {
              Schedule = schedule
              DefaultSettings = None
              EndBehavior = None
              Expand = None
              Metadata = None
              Phases = None
              ProrationBehavior = None
            }

    ///<p>Retrieves the list of your subscription schedules.</p>
    let List settings (options: ListOptions) =
        let qs = [("canceled_at", options.CanceledAt |> box); ("completed_at", options.CompletedAt |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("released_at", options.ReleasedAt |> box); ("scheduled", options.Scheduled |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/subscription_schedules"
        |> RestApi.getAsync<StripeList<SubscriptionSchedule>> settings qs

    ///<p>Creates a new subscription schedule object. Each customer can have up to 500 active or scheduled subscriptions.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/subscription_schedules"
        |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) options

    ///<p>Retrieves the details of an existing subscription schedule. You only need to supply the unique subscription schedule identifier that was returned upon subscription schedule creation.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/subscription_schedules/{options.Schedule}"
        |> RestApi.getAsync<SubscriptionSchedule> settings qs

    ///<p>Updates an existing subscription schedule.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/subscription_schedules/{options.Schedule}"
        |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) options

module SubscriptionSchedulesCancel =

    type CancelOptions =
        {
            [<Config.Path>]
            Schedule: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// If the subscription schedule is `active`, indicates if a final invoice will be generated that contains any un-invoiced metered usage and new/pending proration invoice items. Defaults to `true`.
            [<Config.Form>]
            InvoiceNow: bool option
            /// If the subscription schedule is `active`, indicates if the cancellation should be prorated. Defaults to `true`.
            [<Config.Form>]
            Prorate: bool option
        }

    module CancelOptions =
        let create
            (
                schedule: string
            ) : CancelOptions
            =
            {
              Schedule = schedule
              Expand = None
              InvoiceNow = None
              Prorate = None
            }

    ///<p>Cancels a subscription schedule and its associated subscription immediately (if the subscription schedule has an active subscription). A subscription schedule can only be canceled if its status is <code>not_started</code> or <code>active</code>.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/subscription_schedules/{options.Schedule}/cancel"
        |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) options

module SubscriptionSchedulesRelease =

    type ReleaseOptions =
        {
            [<Config.Path>]
            Schedule: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Keep any cancellation on the subscription that the schedule has set
            [<Config.Form>]
            PreserveCancelDate: bool option
        }

    module ReleaseOptions =
        let create
            (
                schedule: string
            ) : ReleaseOptions
            =
            {
              Schedule = schedule
              Expand = None
              PreserveCancelDate = None
            }

    ///<p>Releases the subscription schedule immediately, which will stop scheduling of its phases, but leave any existing subscription in place. A schedule can only be released if its status is <code>not_started</code> or <code>active</code>. If the subscription schedule is currently associated with a subscription, releasing it will remove its <code>subscription</code> property and set the subscription’s ID to the <code>released_subscription</code> property.</p>
    let Release settings (options: ReleaseOptions) =
        $"/v1/subscription_schedules/{options.Schedule}/release"
        |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) options

