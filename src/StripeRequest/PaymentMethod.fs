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

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
module Account =

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(?expand: string list) =
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

    type Create'CollectionOptions with
        static member New(?fields: Create'CollectionOptionsFields, ?futureRequirements: Create'CollectionOptionsFutureRequirements) =
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

    type CreateOptions with
        static member New(account: string, type': Create'Type, ?collect: Create'Collect, ?collectionOptions: Create'CollectionOptions, ?expand: string list, ?refreshUrl: string, ?returnUrl: string) =
            {
                Account = account
                Type = type'
                Collect = collect
                CollectionOptions = collectionOptions
                Expand = expand
                RefreshUrl = refreshUrl
                ReturnUrl = returnUrl
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

    type Create'ComponentsAccountManagementFeatures with
        static member New(?disableStripeUserAuthentication: bool, ?externalAccountCollection: bool) =
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

    type Create'ComponentsAccountManagement with
        static member New(?enabled: bool, ?features: Create'ComponentsAccountManagementFeatures) =
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

    type Create'ComponentsAccountOnboardingFeatures with
        static member New(?disableStripeUserAuthentication: bool, ?externalAccountCollection: bool) =
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

    type Create'ComponentsAccountOnboarding with
        static member New(?enabled: bool, ?features: Create'ComponentsAccountOnboardingFeatures) =
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

    type Create'ComponentsBalanceReport with
        static member New(?enabled: bool, ?features: string) =
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

    type Create'ComponentsBalancesFeatures with
        static member New(?disableStripeUserAuthentication: bool, ?editPayoutSchedule: bool, ?externalAccountCollection: bool, ?instantPayouts: bool, ?standardPayouts: bool) =
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

    type Create'ComponentsBalances with
        static member New(?enabled: bool, ?features: Create'ComponentsBalancesFeatures) =
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

    type Create'ComponentsDisputesListFeatures with
        static member New(?capturePayments: bool, ?destinationOnBehalfOfChargeManagement: bool, ?disputeManagement: bool, ?refundManagement: bool) =
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

    type Create'ComponentsDisputesList with
        static member New(?enabled: bool, ?features: Create'ComponentsDisputesListFeatures) =
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

    type Create'ComponentsDocuments with
        static member New(?enabled: bool, ?features: string) =
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

    type Create'ComponentsFinancialAccountFeatures with
        static member New(?disableStripeUserAuthentication: bool, ?externalAccountCollection: bool, ?sendMoney: bool, ?transferBalance: bool) =
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

    type Create'ComponentsFinancialAccount with
        static member New(?enabled: bool, ?features: Create'ComponentsFinancialAccountFeatures) =
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

    type Create'ComponentsFinancialAccountTransactionsFeatures with
        static member New(?cardSpendDisputeManagement: bool) =
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

    type Create'ComponentsFinancialAccountTransactions with
        static member New(?enabled: bool, ?features: Create'ComponentsFinancialAccountTransactionsFeatures) =
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

    type Create'ComponentsInstantPayoutsPromotionFeatures with
        static member New(?disableStripeUserAuthentication: bool, ?externalAccountCollection: bool, ?instantPayouts: bool) =
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

    type Create'ComponentsInstantPayoutsPromotion with
        static member New(?enabled: bool, ?features: Create'ComponentsInstantPayoutsPromotionFeatures) =
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

    type Create'ComponentsIssuingCardFeatures with
        static member New(?cardManagement: bool, ?cardSpendDisputeManagement: bool, ?cardholderManagement: bool, ?spendControlManagement: bool) =
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

    type Create'ComponentsIssuingCard with
        static member New(?enabled: bool, ?features: Create'ComponentsIssuingCardFeatures) =
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

    type Create'ComponentsIssuingCardsListFeatures with
        static member New(?cardManagement: bool, ?cardSpendDisputeManagement: bool, ?cardholderManagement: bool, ?disableStripeUserAuthentication: bool, ?spendControlManagement: bool) =
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

    type Create'ComponentsIssuingCardsList with
        static member New(?enabled: bool, ?features: Create'ComponentsIssuingCardsListFeatures) =
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

    type Create'ComponentsNotificationBannerFeatures with
        static member New(?disableStripeUserAuthentication: bool, ?externalAccountCollection: bool) =
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

    type Create'ComponentsNotificationBanner with
        static member New(?enabled: bool, ?features: Create'ComponentsNotificationBannerFeatures) =
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

    type Create'ComponentsPaymentDetailsFeatures with
        static member New(?capturePayments: bool, ?destinationOnBehalfOfChargeManagement: bool, ?disputeManagement: bool, ?refundManagement: bool) =
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

    type Create'ComponentsPaymentDetails with
        static member New(?enabled: bool, ?features: Create'ComponentsPaymentDetailsFeatures) =
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

    type Create'ComponentsPaymentDisputesFeatures with
        static member New(?destinationOnBehalfOfChargeManagement: bool, ?disputeManagement: bool, ?refundManagement: bool) =
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

    type Create'ComponentsPaymentDisputes with
        static member New(?enabled: bool, ?features: Create'ComponentsPaymentDisputesFeatures) =
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

    type Create'ComponentsPaymentsFeatures with
        static member New(?capturePayments: bool, ?destinationOnBehalfOfChargeManagement: bool, ?disputeManagement: bool, ?refundManagement: bool) =
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

    type Create'ComponentsPayments with
        static member New(?enabled: bool, ?features: Create'ComponentsPaymentsFeatures) =
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

    type Create'ComponentsPayoutDetails with
        static member New(?enabled: bool, ?features: string) =
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

    type Create'ComponentsPayoutReconciliationReport with
        static member New(?enabled: bool, ?features: string) =
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

    type Create'ComponentsPayoutsFeatures with
        static member New(?disableStripeUserAuthentication: bool, ?editPayoutSchedule: bool, ?externalAccountCollection: bool, ?instantPayouts: bool, ?standardPayouts: bool) =
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

    type Create'ComponentsPayouts with
        static member New(?enabled: bool, ?features: Create'ComponentsPayoutsFeatures) =
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

    type Create'ComponentsPayoutsList with
        static member New(?enabled: bool, ?features: string) =
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

    type Create'ComponentsTaxRegistrations with
        static member New(?enabled: bool, ?features: string) =
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

    type Create'ComponentsTaxSettings with
        static member New(?enabled: bool, ?features: string) =
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

    type Create'Components with
        static member New(?accountManagement: Create'ComponentsAccountManagement, ?accountOnboarding: Create'ComponentsAccountOnboarding, ?balanceReport: Create'ComponentsBalanceReport, ?balances: Create'ComponentsBalances, ?disputesList: Create'ComponentsDisputesList, ?documents: Create'ComponentsDocuments, ?financialAccount: Create'ComponentsFinancialAccount, ?financialAccountTransactions: Create'ComponentsFinancialAccountTransactions, ?instantPayoutsPromotion: Create'ComponentsInstantPayoutsPromotion, ?issuingCard: Create'ComponentsIssuingCard, ?issuingCardsList: Create'ComponentsIssuingCardsList, ?notificationBanner: Create'ComponentsNotificationBanner, ?paymentDetails: Create'ComponentsPaymentDetails, ?paymentDisputes: Create'ComponentsPaymentDisputes, ?payments: Create'ComponentsPayments, ?payoutDetails: Create'ComponentsPayoutDetails, ?payoutReconciliationReport: Create'ComponentsPayoutReconciliationReport, ?payouts: Create'ComponentsPayouts, ?payoutsList: Create'ComponentsPayoutsList, ?taxRegistrations: Create'ComponentsTaxRegistrations, ?taxSettings: Create'ComponentsTaxSettings) =
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

    type CreateOptions with
        static member New(account: string, components: Create'Components, ?expand: string list) =
            {
                Account = account
                Components = components
                Expand = expand
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

    type ListOptions with
        static member New(?alertType: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?meter: string, ?startingAfter: string) =
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

    type Create'UsageThresholdFilters with
        static member New(?customer: string, ?type': Create'UsageThresholdFiltersType) =
            {
                Customer = customer
                Type = type'
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

    type Create'UsageThreshold with
        static member New(?filters: Create'UsageThresholdFilters list, ?gte: int, ?meter: string, ?recurrence: Create'UsageThresholdRecurrence) =
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

    type CreateOptions with
        static member New(alertType: Create'AlertType, title: string, ?expand: string list, ?usageThreshold: Create'UsageThreshold) =
            {
                AlertType = alertType
                Title = title
                Expand = expand
                UsageThreshold = usageThreshold
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    type RetrieveOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
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

    type ActivateOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
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

    type ArchiveOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
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

    type DeactivateOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
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

    type RetrieveOptions with
        static member New(filter: Map<string, string>, ?customer: string, ?customerAccount: string, ?expand: string list) =
            {
                Filter = filter
                Customer = customer
                CustomerAccount = customerAccount
                Expand = expand
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

    type ListOptions with
        static member New(?creditGrant: string, ?customer: string, ?customerAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
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

    type RetrieveOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
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

    type ListOptions with
        static member New(?customer: string, ?customerAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
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

    type Create'AmountMonetary with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?value: int) =
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

    type Create'Amount with
        static member New(?monetary: Create'AmountMonetary, ?type': Create'AmountType) =
            {
                Monetary = monetary
                Type = type'
            }

    type Create'ApplicabilityConfigScopePriceType = | Metered

    type Create'ApplicabilityConfigScopePrices =
        {
            /// The price ID this credit grant should apply to.
            [<Config.Form>]
            Id: string option
        }

    type Create'ApplicabilityConfigScopePrices with
        static member New(?id: string) =
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

    type Create'ApplicabilityConfigScope with
        static member New(?priceType: Create'ApplicabilityConfigScopePriceType, ?prices: Create'ApplicabilityConfigScopePrices list) =
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

    type Create'ApplicabilityConfig with
        static member New(?scope: Create'ApplicabilityConfigScope) =
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

    type CreateOptions with
        static member New(amount: Create'Amount, applicabilityConfig: Create'ApplicabilityConfig, ?category: Create'Category, ?customer: string, ?customerAccount: string, ?effectiveAt: DateTime, ?expand: string list, ?expiresAt: DateTime, ?metadata: Map<string, string>, ?name: string, ?priority: int) =
            {
                Amount = amount
                ApplicabilityConfig = applicabilityConfig
                Category = category
                Customer = customer
                CustomerAccount = customerAccount
                EffectiveAt = effectiveAt
                Expand = expand
                ExpiresAt = expiresAt
                Metadata = metadata
                Name = name
                Priority = priority
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

    type RetrieveOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
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

    type UpdateOptions with
        static member New(id: string, ?expand: string list, ?expiresAt: Choice<DateTime,string>, ?metadata: Map<string, string>) =
            {
                Id = id
                Expand = expand
                ExpiresAt = expiresAt
                Metadata = metadata
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

    type ExpireOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
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

    type VoidGrantOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
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

    type Create'Cancel with
        static member New(?identifier: string) =
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

    type CreateOptions with
        static member New(eventName: string, type': Create'Type, ?cancel: Create'Cancel, ?expand: string list) =
            {
                EventName = eventName
                Type = type'
                Cancel = cancel
                Expand = expand
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

    type CreateOptions with
        static member New(eventName: string, payload: Map<string, string>, ?expand: string list, ?identifier: string, ?timestamp: DateTime) =
            {
                EventName = eventName
                Payload = payload
                Expand = expand
                Identifier = identifier
                Timestamp = timestamp
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

    type ListOptions with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
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

    type Create'CustomerMapping with
        static member New(?eventPayloadKey: string, ?type': Create'CustomerMappingType) =
            {
                EventPayloadKey = eventPayloadKey
                Type = type'
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

    type Create'DefaultAggregation with
        static member New(?formula: Create'DefaultAggregationFormula) =
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

    type Create'ValueSettings with
        static member New(?eventPayloadKey: string) =
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

    type CreateOptions with
        static member New(defaultAggregation: Create'DefaultAggregation, displayName: string, eventName: string, ?customerMapping: Create'CustomerMapping, ?eventTimeWindow: Create'EventTimeWindow, ?expand: string list, ?valueSettings: Create'ValueSettings) =
            {
                DefaultAggregation = defaultAggregation
                DisplayName = displayName
                EventName = eventName
                CustomerMapping = customerMapping
                EventTimeWindow = eventTimeWindow
                Expand = expand
                ValueSettings = valueSettings
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Id: string
        }

    type RetrieveOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
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

    type UpdateOptions with
        static member New(id: string, ?displayName: string, ?expand: string list) =
            {
                Id = id
                DisplayName = displayName
                Expand = expand
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

    type DeactivateOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
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

    type ListOptions with
        static member New(customer: string, endTime: int, id: string, startTime: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?valueGroupingWindow: string) =
            {
                Customer = customer
                EndTime = endTime
                Id = id
                StartTime = startTime
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                ValueGroupingWindow = valueGroupingWindow
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

    type ReactivateOptions with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
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

    type Create'ComponentsBuyButton with
        static member New(?enabled: bool) =
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

    type Create'ComponentsCustomerSheetFeatures with
        static member New(?paymentMethodAllowRedisplayFilters: Create'ComponentsCustomerSheetFeaturesPaymentMethodAllowRedisplayFilters list, ?paymentMethodRemove: Create'ComponentsCustomerSheetFeaturesPaymentMethodRemove) =
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

    type Create'ComponentsCustomerSheet with
        static member New(?enabled: bool, ?features: Create'ComponentsCustomerSheetFeatures) =
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

    type Create'ComponentsMobilePaymentElementFeatures with
        static member New(?paymentMethodAllowRedisplayFilters: Create'ComponentsMobilePaymentElementFeaturesPaymentMethodAllowRedisplayFilters list, ?paymentMethodRedisplay: Create'ComponentsMobilePaymentElementFeaturesPaymentMethodRedisplay, ?paymentMethodRemove: Create'ComponentsMobilePaymentElementFeaturesPaymentMethodRemove, ?paymentMethodSave: Create'ComponentsMobilePaymentElementFeaturesPaymentMethodSave, ?paymentMethodSaveAllowRedisplayOverride: Create'ComponentsMobilePaymentElementFeaturesPaymentMethodSaveAllowRedisplayOverride) =
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

    type Create'ComponentsMobilePaymentElement with
        static member New(?enabled: bool, ?features: Create'ComponentsMobilePaymentElementFeatures) =
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

    type Create'ComponentsPaymentElementFeatures with
        static member New(?paymentMethodAllowRedisplayFilters: Create'ComponentsPaymentElementFeaturesPaymentMethodAllowRedisplayFilters list, ?paymentMethodRedisplay: Create'ComponentsPaymentElementFeaturesPaymentMethodRedisplay, ?paymentMethodRedisplayLimit: int, ?paymentMethodRemove: Create'ComponentsPaymentElementFeaturesPaymentMethodRemove, ?paymentMethodSave: Create'ComponentsPaymentElementFeaturesPaymentMethodSave, ?paymentMethodSaveUsage: Create'ComponentsPaymentElementFeaturesPaymentMethodSaveUsage) =
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

    type Create'ComponentsPaymentElement with
        static member New(?enabled: bool, ?features: Create'ComponentsPaymentElementFeatures) =
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

    type Create'ComponentsPricingTable with
        static member New(?enabled: bool) =
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

    type Create'Components with
        static member New(?buyButton: Create'ComponentsBuyButton, ?customerSheet: Create'ComponentsCustomerSheet, ?mobilePaymentElement: Create'ComponentsMobilePaymentElement, ?paymentElement: Create'ComponentsPaymentElement, ?pricingTable: Create'ComponentsPricingTable) =
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

    type CreateOptions with
        static member New(components: Create'Components, ?customer: string, ?customerAccount: string, ?expand: string list) =
            {
                Components = components
                Customer = customer
                CustomerAccount = customerAccount
                Expand = expand
            }

    ///<p>Creates a Customer Session object that includes a single-use client secret that you can use on your front-end to grant client-side API access for certain customer resources.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/customer_sessions"
        |> RestApi.postAsync<_, CustomerSession> settings (Map.empty) options

module FinancialConnectionsAccounts =

    type ListOptions =
        {
            /// If present, only return accounts that belong to the specified account holder. `account_holder[customer]` and `account_holder[account]` are mutually exclusive.
            [<Config.Query>]
            AccountHolder: Map<string, string> option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// If present, only return accounts that were collected as part of the given session.
            [<Config.Query>]
            Session: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListOptions with
        static member New(?accountHolder: Map<string, string>, ?endingBefore: string, ?expand: string list, ?limit: int, ?session: string, ?startingAfter: string) =
            {
                AccountHolder = accountHolder
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Session = session
                StartingAfter = startingAfter
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Account: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(account: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
            }

    ///<p>Returns a list of Financial Connections <code>Account</code> objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("account_holder", options.AccountHolder |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("session", options.Session |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/financial_connections/accounts"
        |> RestApi.getAsync<StripeList<FinancialConnectionsAccount>> settings qs

    ///<p>Retrieves the details of an Financial Connections <code>Account</code>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/financial_connections/accounts/{options.Account}"
        |> RestApi.getAsync<FinancialConnectionsAccount> settings qs

module FinancialConnectionsAccountsDisconnect =

    type DisconnectOptions =
        {
            [<Config.Path>]
            Account: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
        }

    type DisconnectOptions with
        static member New(account: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
            }

    ///<p>Disables your access to a Financial Connections <code>Account</code>. You will no longer be able to access data associated with the account (e.g. balances, transactions).</p>
    let Disconnect settings (options: DisconnectOptions) =
        $"/v1/financial_connections/accounts/{options.Account}/disconnect"
        |> RestApi.postAsync<_, FinancialConnectionsAccount> settings (Map.empty) options

module FinancialConnectionsAccountsOwners =

    type ListOwnersOptions =
        {
            [<Config.Path>]
            Account: string
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// The ID of the ownership object to fetch owners from.
            [<Config.Query>]
            Ownership: string
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListOwnersOptions with
        static member New(account: string, ownership: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Account = account
                Ownership = ownership
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Lists all owners for a given <code>Account</code></p>
    let ListOwners settings (options: ListOwnersOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("ownership", options.Ownership |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/financial_connections/accounts/{options.Account}/owners"
        |> RestApi.getAsync<StripeList<FinancialConnectionsAccountOwner>> settings qs

module FinancialConnectionsAccountsRefresh =

    type Refresh'Features =
        | Balance
        | Ownership
        | Transactions

    type RefreshOptions =
        {
            [<Config.Path>]
            Account: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The list of account features that you would like to refresh.
            [<Config.Form>]
            Features: Refresh'Features list
        }

    type RefreshOptions with
        static member New(account: string, features: Refresh'Features list, ?expand: string list) =
            {
                Account = account
                Features = features
                Expand = expand
            }

    ///<p>Refreshes the data associated with a Financial Connections <code>Account</code>.</p>
    let Refresh settings (options: RefreshOptions) =
        $"/v1/financial_connections/accounts/{options.Account}/refresh"
        |> RestApi.postAsync<_, FinancialConnectionsAccount> settings (Map.empty) options

module FinancialConnectionsAccountsSubscribe =

    type Subscribe'Features = | Transactions

    type SubscribeOptions =
        {
            [<Config.Path>]
            Account: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The list of account features to which you would like to subscribe.
            [<Config.Form>]
            Features: Subscribe'Features list
        }

    type SubscribeOptions with
        static member New(account: string, features: Subscribe'Features list, ?expand: string list) =
            {
                Account = account
                Features = features
                Expand = expand
            }

    ///<p>Subscribes to periodic refreshes of data associated with a Financial Connections <code>Account</code>. When the account status is active, data is typically refreshed once a day.</p>
    let Subscribe settings (options: SubscribeOptions) =
        $"/v1/financial_connections/accounts/{options.Account}/subscribe"
        |> RestApi.postAsync<_, FinancialConnectionsAccount> settings (Map.empty) options

module FinancialConnectionsAccountsUnsubscribe =

    type Unsubscribe'Features = | Transactions

    type UnsubscribeOptions =
        {
            [<Config.Path>]
            Account: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The list of account features from which you would like to unsubscribe.
            [<Config.Form>]
            Features: Unsubscribe'Features list
        }

    type UnsubscribeOptions with
        static member New(account: string, features: Unsubscribe'Features list, ?expand: string list) =
            {
                Account = account
                Features = features
                Expand = expand
            }

    ///<p>Unsubscribes from periodic refreshes of data associated with a Financial Connections <code>Account</code>.</p>
    let Unsubscribe settings (options: UnsubscribeOptions) =
        $"/v1/financial_connections/accounts/{options.Account}/unsubscribe"
        |> RestApi.postAsync<_, FinancialConnectionsAccount> settings (Map.empty) options

module FinancialConnectionsSessions =

    type Create'AccountHolderType =
        | Account
        | Customer

    type Create'AccountHolder =
        {
            /// The ID of the Stripe account whose accounts you will retrieve. Only available when `type` is `account`.
            [<Config.Form>]
            Account: string option
            /// The ID of the Stripe customer whose accounts you will retrieve. Only available when `type` is `customer`.
            [<Config.Form>]
            Customer: string option
            /// The ID of Account representing a customer whose accounts you will retrieve. Only available when `type` is `customer`.
            [<Config.Form>]
            CustomerAccount: string option
            /// Type of account holder to collect accounts for.
            [<Config.Form>]
            Type: Create'AccountHolderType option
        }

    type Create'AccountHolder with
        static member New(?account: string, ?customer: string, ?customerAccount: string, ?type': Create'AccountHolderType) =
            {
                Account = account
                Customer = customer
                CustomerAccount = customerAccount
                Type = type'
            }

    type Create'FiltersAccountSubcategories =
        | Checking
        | CreditCard
        | LineOfCredit
        | Mortgage
        | Savings

    type Create'Filters =
        {
            /// Restricts the Session to subcategories of accounts that can be linked. Valid subcategories are: `checking`, `savings`, `mortgage`, `line_of_credit`, `credit_card`.
            [<Config.Form>]
            AccountSubcategories: Create'FiltersAccountSubcategories list option
            /// List of countries from which to collect accounts.
            [<Config.Form>]
            Countries: string list option
        }

    type Create'Filters with
        static member New(?accountSubcategories: Create'FiltersAccountSubcategories list, ?countries: string list) =
            {
                AccountSubcategories = accountSubcategories
                Countries = countries
            }

    type Create'Permissions =
        | Balances
        | Ownership
        | PaymentMethod
        | Transactions

    type Create'Prefetch =
        | Balances
        | Ownership
        | Transactions

    type CreateOptions =
        {
            /// The account holder to link accounts for.
            [<Config.Form>]
            AccountHolder: Create'AccountHolder
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Filters to restrict the kinds of accounts to collect.
            [<Config.Form>]
            Filters: Create'Filters option
            /// List of data features that you would like to request access to.
            /// Possible values are `balances`, `transactions`, `ownership`, and `payment_method`.
            [<Config.Form>]
            Permissions: Create'Permissions list
            /// List of data features that you would like to retrieve upon account creation.
            [<Config.Form>]
            Prefetch: Create'Prefetch list option
            /// For webview integrations only. Upon completing OAuth login in the native browser, the user will be redirected to this URL to return to your app.
            [<Config.Form>]
            ReturnUrl: string option
        }

    type CreateOptions with
        static member New(accountHolder: Create'AccountHolder, permissions: Create'Permissions list, ?expand: string list, ?filters: Create'Filters, ?prefetch: Create'Prefetch list, ?returnUrl: string) =
            {
                AccountHolder = accountHolder
                Permissions = permissions
                Expand = expand
                Filters = filters
                Prefetch = prefetch
                ReturnUrl = returnUrl
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Session: string
        }

    type RetrieveOptions with
        static member New(session: string, ?expand: string list) =
            {
                Session = session
                Expand = expand
            }

    ///<p>To launch the Financial Connections authorization flow, create a <code>Session</code>. The session’s <code>client_secret</code> can be used to launch the flow using Stripe.js.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/financial_connections/sessions"
        |> RestApi.postAsync<_, FinancialConnectionsSession> settings (Map.empty) options

    ///<p>Retrieves the details of a Financial Connections <code>Session</code></p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/financial_connections/sessions/{options.Session}"
        |> RestApi.getAsync<FinancialConnectionsSession> settings qs

module FinancialConnectionsTransactions =

    type ListOptions =
        {
            /// The ID of the Financial Connections Account whose transactions will be retrieved.
            [<Config.Query>]
            Account: string
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
            /// A filter on the list based on the object `transacted_at` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with the following options:
            [<Config.Query>]
            TransactedAt: int option
            /// A filter on the list based on the object `transaction_refresh` field. The value can be a dictionary with the following options:
            [<Config.Query>]
            TransactionRefresh: Map<string, string> option
        }

    type ListOptions with
        static member New(account: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?transactedAt: int, ?transactionRefresh: Map<string, string>) =
            {
                Account = account
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                TransactedAt = transactedAt
                TransactionRefresh = transactionRefresh
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Transaction: string
        }

    type RetrieveOptions with
        static member New(transaction: string, ?expand: string list) =
            {
                Transaction = transaction
                Expand = expand
            }

    ///<p>Returns a list of Financial Connections <code>Transaction</code> objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("account", options.Account |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("transacted_at", options.TransactedAt |> box); ("transaction_refresh", options.TransactionRefresh |> box)] |> Map.ofList
        $"/v1/financial_connections/transactions"
        |> RestApi.getAsync<StripeList<FinancialConnectionsTransaction>> settings qs

    ///<p>Retrieves the details of a Financial Connections <code>Transaction</code></p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/financial_connections/transactions/{options.Transaction}"
        |> RestApi.getAsync<FinancialConnectionsTransaction> settings qs

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

    type ListOptions with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?invoice: string, ?limit: int, ?payment: Map<string, string>, ?startingAfter: string, ?status: string) =
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

    type RetrieveOptions with
        static member New(invoicePayment: string, ?expand: string list) =
            {
                InvoicePayment = invoicePayment
                Expand = expand
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

    type ListOptions with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
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

    type RetrieveOptions with
        static member New(template: string, ?expand: string list, ?version: int) =
            {
                Template = template
                Expand = expand
                Version = version
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

    type ArchiveOptions with
        static member New(template: string, ?expand: string list) =
            {
                Template = template
                Expand = expand
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

    type UnarchiveOptions with
        static member New(template: string, ?expand: string list) =
            {
                Template = template
                Expand = expand
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

    type ListOptions with
        static member New(?application: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
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

    type Create'AcssDebitDisplayPreference with
        static member New(?preference: Create'AcssDebitDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'AcssDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AcssDebitDisplayPreference option
        }

    type Create'AcssDebit with
        static member New(?displayPreference: Create'AcssDebitDisplayPreference) =
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

    type Create'AffirmDisplayPreference with
        static member New(?preference: Create'AffirmDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Affirm =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AffirmDisplayPreference option
        }

    type Create'Affirm with
        static member New(?displayPreference: Create'AffirmDisplayPreference) =
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

    type Create'AfterpayClearpayDisplayPreference with
        static member New(?preference: Create'AfterpayClearpayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'AfterpayClearpay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AfterpayClearpayDisplayPreference option
        }

    type Create'AfterpayClearpay with
        static member New(?displayPreference: Create'AfterpayClearpayDisplayPreference) =
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

    type Create'AlipayDisplayPreference with
        static member New(?preference: Create'AlipayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Alipay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AlipayDisplayPreference option
        }

    type Create'Alipay with
        static member New(?displayPreference: Create'AlipayDisplayPreference) =
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

    type Create'AlmaDisplayPreference with
        static member New(?preference: Create'AlmaDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Alma =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AlmaDisplayPreference option
        }

    type Create'Alma with
        static member New(?displayPreference: Create'AlmaDisplayPreference) =
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

    type Create'AmazonPayDisplayPreference with
        static member New(?preference: Create'AmazonPayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'AmazonPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AmazonPayDisplayPreference option
        }

    type Create'AmazonPay with
        static member New(?displayPreference: Create'AmazonPayDisplayPreference) =
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

    type Create'ApplePayDisplayPreference with
        static member New(?preference: Create'ApplePayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'ApplePay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'ApplePayDisplayPreference option
        }

    type Create'ApplePay with
        static member New(?displayPreference: Create'ApplePayDisplayPreference) =
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

    type Create'ApplePayLaterDisplayPreference with
        static member New(?preference: Create'ApplePayLaterDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'ApplePayLater =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'ApplePayLaterDisplayPreference option
        }

    type Create'ApplePayLater with
        static member New(?displayPreference: Create'ApplePayLaterDisplayPreference) =
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

    type Create'AuBecsDebitDisplayPreference with
        static member New(?preference: Create'AuBecsDebitDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'AuBecsDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'AuBecsDebitDisplayPreference option
        }

    type Create'AuBecsDebit with
        static member New(?displayPreference: Create'AuBecsDebitDisplayPreference) =
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

    type Create'BacsDebitDisplayPreference with
        static member New(?preference: Create'BacsDebitDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'BacsDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'BacsDebitDisplayPreference option
        }

    type Create'BacsDebit with
        static member New(?displayPreference: Create'BacsDebitDisplayPreference) =
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

    type Create'BancontactDisplayPreference with
        static member New(?preference: Create'BancontactDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Bancontact =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'BancontactDisplayPreference option
        }

    type Create'Bancontact with
        static member New(?displayPreference: Create'BancontactDisplayPreference) =
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

    type Create'BillieDisplayPreference with
        static member New(?preference: Create'BillieDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Billie =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'BillieDisplayPreference option
        }

    type Create'Billie with
        static member New(?displayPreference: Create'BillieDisplayPreference) =
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

    type Create'BlikDisplayPreference with
        static member New(?preference: Create'BlikDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Blik =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'BlikDisplayPreference option
        }

    type Create'Blik with
        static member New(?displayPreference: Create'BlikDisplayPreference) =
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

    type Create'BoletoDisplayPreference with
        static member New(?preference: Create'BoletoDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Boleto =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'BoletoDisplayPreference option
        }

    type Create'Boleto with
        static member New(?displayPreference: Create'BoletoDisplayPreference) =
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

    type Create'CardDisplayPreference with
        static member New(?preference: Create'CardDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Card =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'CardDisplayPreference option
        }

    type Create'Card with
        static member New(?displayPreference: Create'CardDisplayPreference) =
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

    type Create'CartesBancairesDisplayPreference with
        static member New(?preference: Create'CartesBancairesDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'CartesBancaires =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'CartesBancairesDisplayPreference option
        }

    type Create'CartesBancaires with
        static member New(?displayPreference: Create'CartesBancairesDisplayPreference) =
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

    type Create'CashappDisplayPreference with
        static member New(?preference: Create'CashappDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Cashapp =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'CashappDisplayPreference option
        }

    type Create'Cashapp with
        static member New(?displayPreference: Create'CashappDisplayPreference) =
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

    type Create'CryptoDisplayPreference with
        static member New(?preference: Create'CryptoDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Crypto =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'CryptoDisplayPreference option
        }

    type Create'Crypto with
        static member New(?displayPreference: Create'CryptoDisplayPreference) =
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

    type Create'CustomerBalanceDisplayPreference with
        static member New(?preference: Create'CustomerBalanceDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'CustomerBalance =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'CustomerBalanceDisplayPreference option
        }

    type Create'CustomerBalance with
        static member New(?displayPreference: Create'CustomerBalanceDisplayPreference) =
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

    type Create'EpsDisplayPreference with
        static member New(?preference: Create'EpsDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Eps =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'EpsDisplayPreference option
        }

    type Create'Eps with
        static member New(?displayPreference: Create'EpsDisplayPreference) =
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

    type Create'FpxDisplayPreference with
        static member New(?preference: Create'FpxDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Fpx =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'FpxDisplayPreference option
        }

    type Create'Fpx with
        static member New(?displayPreference: Create'FpxDisplayPreference) =
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

    type Create'FrMealVoucherConecsDisplayPreference with
        static member New(?preference: Create'FrMealVoucherConecsDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'FrMealVoucherConecs =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'FrMealVoucherConecsDisplayPreference option
        }

    type Create'FrMealVoucherConecs with
        static member New(?displayPreference: Create'FrMealVoucherConecsDisplayPreference) =
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

    type Create'GiropayDisplayPreference with
        static member New(?preference: Create'GiropayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Giropay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'GiropayDisplayPreference option
        }

    type Create'Giropay with
        static member New(?displayPreference: Create'GiropayDisplayPreference) =
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

    type Create'GooglePayDisplayPreference with
        static member New(?preference: Create'GooglePayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'GooglePay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'GooglePayDisplayPreference option
        }

    type Create'GooglePay with
        static member New(?displayPreference: Create'GooglePayDisplayPreference) =
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

    type Create'GrabpayDisplayPreference with
        static member New(?preference: Create'GrabpayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Grabpay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'GrabpayDisplayPreference option
        }

    type Create'Grabpay with
        static member New(?displayPreference: Create'GrabpayDisplayPreference) =
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

    type Create'IdealDisplayPreference with
        static member New(?preference: Create'IdealDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Ideal =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'IdealDisplayPreference option
        }

    type Create'Ideal with
        static member New(?displayPreference: Create'IdealDisplayPreference) =
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

    type Create'JcbDisplayPreference with
        static member New(?preference: Create'JcbDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Jcb =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'JcbDisplayPreference option
        }

    type Create'Jcb with
        static member New(?displayPreference: Create'JcbDisplayPreference) =
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

    type Create'KakaoPayDisplayPreference with
        static member New(?preference: Create'KakaoPayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'KakaoPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'KakaoPayDisplayPreference option
        }

    type Create'KakaoPay with
        static member New(?displayPreference: Create'KakaoPayDisplayPreference) =
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

    type Create'KlarnaDisplayPreference with
        static member New(?preference: Create'KlarnaDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Klarna =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'KlarnaDisplayPreference option
        }

    type Create'Klarna with
        static member New(?displayPreference: Create'KlarnaDisplayPreference) =
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

    type Create'KonbiniDisplayPreference with
        static member New(?preference: Create'KonbiniDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Konbini =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'KonbiniDisplayPreference option
        }

    type Create'Konbini with
        static member New(?displayPreference: Create'KonbiniDisplayPreference) =
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

    type Create'KrCardDisplayPreference with
        static member New(?preference: Create'KrCardDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'KrCard =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'KrCardDisplayPreference option
        }

    type Create'KrCard with
        static member New(?displayPreference: Create'KrCardDisplayPreference) =
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

    type Create'LinkDisplayPreference with
        static member New(?preference: Create'LinkDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Link =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'LinkDisplayPreference option
        }

    type Create'Link with
        static member New(?displayPreference: Create'LinkDisplayPreference) =
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

    type Create'MbWayDisplayPreference with
        static member New(?preference: Create'MbWayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'MbWay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'MbWayDisplayPreference option
        }

    type Create'MbWay with
        static member New(?displayPreference: Create'MbWayDisplayPreference) =
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

    type Create'MobilepayDisplayPreference with
        static member New(?preference: Create'MobilepayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Mobilepay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'MobilepayDisplayPreference option
        }

    type Create'Mobilepay with
        static member New(?displayPreference: Create'MobilepayDisplayPreference) =
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

    type Create'MultibancoDisplayPreference with
        static member New(?preference: Create'MultibancoDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Multibanco =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'MultibancoDisplayPreference option
        }

    type Create'Multibanco with
        static member New(?displayPreference: Create'MultibancoDisplayPreference) =
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

    type Create'NaverPayDisplayPreference with
        static member New(?preference: Create'NaverPayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'NaverPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'NaverPayDisplayPreference option
        }

    type Create'NaverPay with
        static member New(?displayPreference: Create'NaverPayDisplayPreference) =
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

    type Create'NzBankAccountDisplayPreference with
        static member New(?preference: Create'NzBankAccountDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'NzBankAccount =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'NzBankAccountDisplayPreference option
        }

    type Create'NzBankAccount with
        static member New(?displayPreference: Create'NzBankAccountDisplayPreference) =
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

    type Create'OxxoDisplayPreference with
        static member New(?preference: Create'OxxoDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Oxxo =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'OxxoDisplayPreference option
        }

    type Create'Oxxo with
        static member New(?displayPreference: Create'OxxoDisplayPreference) =
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

    type Create'P24DisplayPreference with
        static member New(?preference: Create'P24DisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'P24 =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'P24DisplayPreference option
        }

    type Create'P24 with
        static member New(?displayPreference: Create'P24DisplayPreference) =
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

    type Create'PayByBankDisplayPreference with
        static member New(?preference: Create'PayByBankDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'PayByBank =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PayByBankDisplayPreference option
        }

    type Create'PayByBank with
        static member New(?displayPreference: Create'PayByBankDisplayPreference) =
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

    type Create'PaycoDisplayPreference with
        static member New(?preference: Create'PaycoDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Payco =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PaycoDisplayPreference option
        }

    type Create'Payco with
        static member New(?displayPreference: Create'PaycoDisplayPreference) =
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

    type Create'PaynowDisplayPreference with
        static member New(?preference: Create'PaynowDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Paynow =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PaynowDisplayPreference option
        }

    type Create'Paynow with
        static member New(?displayPreference: Create'PaynowDisplayPreference) =
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

    type Create'PaypalDisplayPreference with
        static member New(?preference: Create'PaypalDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Paypal =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PaypalDisplayPreference option
        }

    type Create'Paypal with
        static member New(?displayPreference: Create'PaypalDisplayPreference) =
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

    type Create'PaytoDisplayPreference with
        static member New(?preference: Create'PaytoDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Payto =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PaytoDisplayPreference option
        }

    type Create'Payto with
        static member New(?displayPreference: Create'PaytoDisplayPreference) =
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

    type Create'PixDisplayPreference with
        static member New(?preference: Create'PixDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Pix =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PixDisplayPreference option
        }

    type Create'Pix with
        static member New(?displayPreference: Create'PixDisplayPreference) =
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

    type Create'PromptpayDisplayPreference with
        static member New(?preference: Create'PromptpayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Promptpay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'PromptpayDisplayPreference option
        }

    type Create'Promptpay with
        static member New(?displayPreference: Create'PromptpayDisplayPreference) =
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

    type Create'RevolutPayDisplayPreference with
        static member New(?preference: Create'RevolutPayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'RevolutPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'RevolutPayDisplayPreference option
        }

    type Create'RevolutPay with
        static member New(?displayPreference: Create'RevolutPayDisplayPreference) =
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

    type Create'SamsungPayDisplayPreference with
        static member New(?preference: Create'SamsungPayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'SamsungPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'SamsungPayDisplayPreference option
        }

    type Create'SamsungPay with
        static member New(?displayPreference: Create'SamsungPayDisplayPreference) =
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

    type Create'SatispayDisplayPreference with
        static member New(?preference: Create'SatispayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Satispay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'SatispayDisplayPreference option
        }

    type Create'Satispay with
        static member New(?displayPreference: Create'SatispayDisplayPreference) =
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

    type Create'SepaDebitDisplayPreference with
        static member New(?preference: Create'SepaDebitDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'SepaDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'SepaDebitDisplayPreference option
        }

    type Create'SepaDebit with
        static member New(?displayPreference: Create'SepaDebitDisplayPreference) =
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

    type Create'SofortDisplayPreference with
        static member New(?preference: Create'SofortDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Sofort =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'SofortDisplayPreference option
        }

    type Create'Sofort with
        static member New(?displayPreference: Create'SofortDisplayPreference) =
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

    type Create'SunbitDisplayPreference with
        static member New(?preference: Create'SunbitDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Sunbit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'SunbitDisplayPreference option
        }

    type Create'Sunbit with
        static member New(?displayPreference: Create'SunbitDisplayPreference) =
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

    type Create'SwishDisplayPreference with
        static member New(?preference: Create'SwishDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Swish =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'SwishDisplayPreference option
        }

    type Create'Swish with
        static member New(?displayPreference: Create'SwishDisplayPreference) =
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

    type Create'TwintDisplayPreference with
        static member New(?preference: Create'TwintDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Twint =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'TwintDisplayPreference option
        }

    type Create'Twint with
        static member New(?displayPreference: Create'TwintDisplayPreference) =
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

    type Create'UpiDisplayPreference with
        static member New(?preference: Create'UpiDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Upi =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'UpiDisplayPreference option
        }

    type Create'Upi with
        static member New(?displayPreference: Create'UpiDisplayPreference) =
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

    type Create'UsBankAccountDisplayPreference with
        static member New(?preference: Create'UsBankAccountDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'UsBankAccount =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'UsBankAccountDisplayPreference option
        }

    type Create'UsBankAccount with
        static member New(?displayPreference: Create'UsBankAccountDisplayPreference) =
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

    type Create'WechatPayDisplayPreference with
        static member New(?preference: Create'WechatPayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'WechatPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'WechatPayDisplayPreference option
        }

    type Create'WechatPay with
        static member New(?displayPreference: Create'WechatPayDisplayPreference) =
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

    type Create'ZipDisplayPreference with
        static member New(?preference: Create'ZipDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Create'Zip =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Create'ZipDisplayPreference option
        }

    type Create'Zip with
        static member New(?displayPreference: Create'ZipDisplayPreference) =
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

    type CreateOptions with
        static member New(?acssDebit: Create'AcssDebit, ?affirm: Create'Affirm, ?afterpayClearpay: Create'AfterpayClearpay, ?alipay: Create'Alipay, ?alma: Create'Alma, ?amazonPay: Create'AmazonPay, ?applePay: Create'ApplePay, ?applePayLater: Create'ApplePayLater, ?auBecsDebit: Create'AuBecsDebit, ?bacsDebit: Create'BacsDebit, ?bancontact: Create'Bancontact, ?billie: Create'Billie, ?blik: Create'Blik, ?boleto: Create'Boleto, ?card: Create'Card, ?cartesBancaires: Create'CartesBancaires, ?cashapp: Create'Cashapp, ?crypto: Create'Crypto, ?customerBalance: Create'CustomerBalance, ?eps: Create'Eps, ?expand: string list, ?fpx: Create'Fpx, ?frMealVoucherConecs: Create'FrMealVoucherConecs, ?giropay: Create'Giropay, ?googlePay: Create'GooglePay, ?grabpay: Create'Grabpay, ?ideal: Create'Ideal, ?jcb: Create'Jcb, ?kakaoPay: Create'KakaoPay, ?klarna: Create'Klarna, ?konbini: Create'Konbini, ?krCard: Create'KrCard, ?link: Create'Link, ?mbWay: Create'MbWay, ?mobilepay: Create'Mobilepay, ?multibanco: Create'Multibanco, ?name: string, ?naverPay: Create'NaverPay, ?nzBankAccount: Create'NzBankAccount, ?oxxo: Create'Oxxo, ?p24: Create'P24, ?parent: string, ?payByBank: Create'PayByBank, ?payco: Create'Payco, ?paynow: Create'Paynow, ?paypal: Create'Paypal, ?payto: Create'Payto, ?pix: Create'Pix, ?promptpay: Create'Promptpay, ?revolutPay: Create'RevolutPay, ?samsungPay: Create'SamsungPay, ?satispay: Create'Satispay, ?sepaDebit: Create'SepaDebit, ?sofort: Create'Sofort, ?sunbit: Create'Sunbit, ?swish: Create'Swish, ?twint: Create'Twint, ?upi: Create'Upi, ?usBankAccount: Create'UsBankAccount, ?wechatPay: Create'WechatPay, ?zip: Create'Zip) =
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

    type RetrieveOptions with
        static member New(configuration: string, ?expand: string list) =
            {
                Configuration = configuration
                Expand = expand
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

    type Update'AcssDebitDisplayPreference with
        static member New(?preference: Update'AcssDebitDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'AcssDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AcssDebitDisplayPreference option
        }

    type Update'AcssDebit with
        static member New(?displayPreference: Update'AcssDebitDisplayPreference) =
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

    type Update'AffirmDisplayPreference with
        static member New(?preference: Update'AffirmDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Affirm =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AffirmDisplayPreference option
        }

    type Update'Affirm with
        static member New(?displayPreference: Update'AffirmDisplayPreference) =
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

    type Update'AfterpayClearpayDisplayPreference with
        static member New(?preference: Update'AfterpayClearpayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'AfterpayClearpay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AfterpayClearpayDisplayPreference option
        }

    type Update'AfterpayClearpay with
        static member New(?displayPreference: Update'AfterpayClearpayDisplayPreference) =
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

    type Update'AlipayDisplayPreference with
        static member New(?preference: Update'AlipayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Alipay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AlipayDisplayPreference option
        }

    type Update'Alipay with
        static member New(?displayPreference: Update'AlipayDisplayPreference) =
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

    type Update'AlmaDisplayPreference with
        static member New(?preference: Update'AlmaDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Alma =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AlmaDisplayPreference option
        }

    type Update'Alma with
        static member New(?displayPreference: Update'AlmaDisplayPreference) =
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

    type Update'AmazonPayDisplayPreference with
        static member New(?preference: Update'AmazonPayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'AmazonPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AmazonPayDisplayPreference option
        }

    type Update'AmazonPay with
        static member New(?displayPreference: Update'AmazonPayDisplayPreference) =
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

    type Update'ApplePayDisplayPreference with
        static member New(?preference: Update'ApplePayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'ApplePay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'ApplePayDisplayPreference option
        }

    type Update'ApplePay with
        static member New(?displayPreference: Update'ApplePayDisplayPreference) =
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

    type Update'ApplePayLaterDisplayPreference with
        static member New(?preference: Update'ApplePayLaterDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'ApplePayLater =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'ApplePayLaterDisplayPreference option
        }

    type Update'ApplePayLater with
        static member New(?displayPreference: Update'ApplePayLaterDisplayPreference) =
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

    type Update'AuBecsDebitDisplayPreference with
        static member New(?preference: Update'AuBecsDebitDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'AuBecsDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'AuBecsDebitDisplayPreference option
        }

    type Update'AuBecsDebit with
        static member New(?displayPreference: Update'AuBecsDebitDisplayPreference) =
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

    type Update'BacsDebitDisplayPreference with
        static member New(?preference: Update'BacsDebitDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'BacsDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'BacsDebitDisplayPreference option
        }

    type Update'BacsDebit with
        static member New(?displayPreference: Update'BacsDebitDisplayPreference) =
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

    type Update'BancontactDisplayPreference with
        static member New(?preference: Update'BancontactDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Bancontact =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'BancontactDisplayPreference option
        }

    type Update'Bancontact with
        static member New(?displayPreference: Update'BancontactDisplayPreference) =
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

    type Update'BillieDisplayPreference with
        static member New(?preference: Update'BillieDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Billie =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'BillieDisplayPreference option
        }

    type Update'Billie with
        static member New(?displayPreference: Update'BillieDisplayPreference) =
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

    type Update'BlikDisplayPreference with
        static member New(?preference: Update'BlikDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Blik =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'BlikDisplayPreference option
        }

    type Update'Blik with
        static member New(?displayPreference: Update'BlikDisplayPreference) =
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

    type Update'BoletoDisplayPreference with
        static member New(?preference: Update'BoletoDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Boleto =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'BoletoDisplayPreference option
        }

    type Update'Boleto with
        static member New(?displayPreference: Update'BoletoDisplayPreference) =
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

    type Update'CardDisplayPreference with
        static member New(?preference: Update'CardDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Card =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'CardDisplayPreference option
        }

    type Update'Card with
        static member New(?displayPreference: Update'CardDisplayPreference) =
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

    type Update'CartesBancairesDisplayPreference with
        static member New(?preference: Update'CartesBancairesDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'CartesBancaires =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'CartesBancairesDisplayPreference option
        }

    type Update'CartesBancaires with
        static member New(?displayPreference: Update'CartesBancairesDisplayPreference) =
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

    type Update'CashappDisplayPreference with
        static member New(?preference: Update'CashappDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Cashapp =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'CashappDisplayPreference option
        }

    type Update'Cashapp with
        static member New(?displayPreference: Update'CashappDisplayPreference) =
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

    type Update'CryptoDisplayPreference with
        static member New(?preference: Update'CryptoDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Crypto =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'CryptoDisplayPreference option
        }

    type Update'Crypto with
        static member New(?displayPreference: Update'CryptoDisplayPreference) =
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

    type Update'CustomerBalanceDisplayPreference with
        static member New(?preference: Update'CustomerBalanceDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'CustomerBalance =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'CustomerBalanceDisplayPreference option
        }

    type Update'CustomerBalance with
        static member New(?displayPreference: Update'CustomerBalanceDisplayPreference) =
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

    type Update'EpsDisplayPreference with
        static member New(?preference: Update'EpsDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Eps =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'EpsDisplayPreference option
        }

    type Update'Eps with
        static member New(?displayPreference: Update'EpsDisplayPreference) =
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

    type Update'FpxDisplayPreference with
        static member New(?preference: Update'FpxDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Fpx =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'FpxDisplayPreference option
        }

    type Update'Fpx with
        static member New(?displayPreference: Update'FpxDisplayPreference) =
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

    type Update'FrMealVoucherConecsDisplayPreference with
        static member New(?preference: Update'FrMealVoucherConecsDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'FrMealVoucherConecs =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'FrMealVoucherConecsDisplayPreference option
        }

    type Update'FrMealVoucherConecs with
        static member New(?displayPreference: Update'FrMealVoucherConecsDisplayPreference) =
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

    type Update'GiropayDisplayPreference with
        static member New(?preference: Update'GiropayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Giropay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'GiropayDisplayPreference option
        }

    type Update'Giropay with
        static member New(?displayPreference: Update'GiropayDisplayPreference) =
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

    type Update'GooglePayDisplayPreference with
        static member New(?preference: Update'GooglePayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'GooglePay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'GooglePayDisplayPreference option
        }

    type Update'GooglePay with
        static member New(?displayPreference: Update'GooglePayDisplayPreference) =
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

    type Update'GrabpayDisplayPreference with
        static member New(?preference: Update'GrabpayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Grabpay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'GrabpayDisplayPreference option
        }

    type Update'Grabpay with
        static member New(?displayPreference: Update'GrabpayDisplayPreference) =
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

    type Update'IdealDisplayPreference with
        static member New(?preference: Update'IdealDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Ideal =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'IdealDisplayPreference option
        }

    type Update'Ideal with
        static member New(?displayPreference: Update'IdealDisplayPreference) =
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

    type Update'JcbDisplayPreference with
        static member New(?preference: Update'JcbDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Jcb =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'JcbDisplayPreference option
        }

    type Update'Jcb with
        static member New(?displayPreference: Update'JcbDisplayPreference) =
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

    type Update'KakaoPayDisplayPreference with
        static member New(?preference: Update'KakaoPayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'KakaoPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'KakaoPayDisplayPreference option
        }

    type Update'KakaoPay with
        static member New(?displayPreference: Update'KakaoPayDisplayPreference) =
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

    type Update'KlarnaDisplayPreference with
        static member New(?preference: Update'KlarnaDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Klarna =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'KlarnaDisplayPreference option
        }

    type Update'Klarna with
        static member New(?displayPreference: Update'KlarnaDisplayPreference) =
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

    type Update'KonbiniDisplayPreference with
        static member New(?preference: Update'KonbiniDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Konbini =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'KonbiniDisplayPreference option
        }

    type Update'Konbini with
        static member New(?displayPreference: Update'KonbiniDisplayPreference) =
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

    type Update'KrCardDisplayPreference with
        static member New(?preference: Update'KrCardDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'KrCard =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'KrCardDisplayPreference option
        }

    type Update'KrCard with
        static member New(?displayPreference: Update'KrCardDisplayPreference) =
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

    type Update'LinkDisplayPreference with
        static member New(?preference: Update'LinkDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Link =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'LinkDisplayPreference option
        }

    type Update'Link with
        static member New(?displayPreference: Update'LinkDisplayPreference) =
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

    type Update'MbWayDisplayPreference with
        static member New(?preference: Update'MbWayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'MbWay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'MbWayDisplayPreference option
        }

    type Update'MbWay with
        static member New(?displayPreference: Update'MbWayDisplayPreference) =
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

    type Update'MobilepayDisplayPreference with
        static member New(?preference: Update'MobilepayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Mobilepay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'MobilepayDisplayPreference option
        }

    type Update'Mobilepay with
        static member New(?displayPreference: Update'MobilepayDisplayPreference) =
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

    type Update'MultibancoDisplayPreference with
        static member New(?preference: Update'MultibancoDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Multibanco =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'MultibancoDisplayPreference option
        }

    type Update'Multibanco with
        static member New(?displayPreference: Update'MultibancoDisplayPreference) =
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

    type Update'NaverPayDisplayPreference with
        static member New(?preference: Update'NaverPayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'NaverPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'NaverPayDisplayPreference option
        }

    type Update'NaverPay with
        static member New(?displayPreference: Update'NaverPayDisplayPreference) =
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

    type Update'NzBankAccountDisplayPreference with
        static member New(?preference: Update'NzBankAccountDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'NzBankAccount =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'NzBankAccountDisplayPreference option
        }

    type Update'NzBankAccount with
        static member New(?displayPreference: Update'NzBankAccountDisplayPreference) =
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

    type Update'OxxoDisplayPreference with
        static member New(?preference: Update'OxxoDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Oxxo =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'OxxoDisplayPreference option
        }

    type Update'Oxxo with
        static member New(?displayPreference: Update'OxxoDisplayPreference) =
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

    type Update'P24DisplayPreference with
        static member New(?preference: Update'P24DisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'P24 =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'P24DisplayPreference option
        }

    type Update'P24 with
        static member New(?displayPreference: Update'P24DisplayPreference) =
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

    type Update'PayByBankDisplayPreference with
        static member New(?preference: Update'PayByBankDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'PayByBank =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PayByBankDisplayPreference option
        }

    type Update'PayByBank with
        static member New(?displayPreference: Update'PayByBankDisplayPreference) =
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

    type Update'PaycoDisplayPreference with
        static member New(?preference: Update'PaycoDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Payco =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PaycoDisplayPreference option
        }

    type Update'Payco with
        static member New(?displayPreference: Update'PaycoDisplayPreference) =
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

    type Update'PaynowDisplayPreference with
        static member New(?preference: Update'PaynowDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Paynow =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PaynowDisplayPreference option
        }

    type Update'Paynow with
        static member New(?displayPreference: Update'PaynowDisplayPreference) =
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

    type Update'PaypalDisplayPreference with
        static member New(?preference: Update'PaypalDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Paypal =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PaypalDisplayPreference option
        }

    type Update'Paypal with
        static member New(?displayPreference: Update'PaypalDisplayPreference) =
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

    type Update'PaytoDisplayPreference with
        static member New(?preference: Update'PaytoDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Payto =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PaytoDisplayPreference option
        }

    type Update'Payto with
        static member New(?displayPreference: Update'PaytoDisplayPreference) =
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

    type Update'PixDisplayPreference with
        static member New(?preference: Update'PixDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Pix =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PixDisplayPreference option
        }

    type Update'Pix with
        static member New(?displayPreference: Update'PixDisplayPreference) =
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

    type Update'PromptpayDisplayPreference with
        static member New(?preference: Update'PromptpayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Promptpay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'PromptpayDisplayPreference option
        }

    type Update'Promptpay with
        static member New(?displayPreference: Update'PromptpayDisplayPreference) =
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

    type Update'RevolutPayDisplayPreference with
        static member New(?preference: Update'RevolutPayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'RevolutPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'RevolutPayDisplayPreference option
        }

    type Update'RevolutPay with
        static member New(?displayPreference: Update'RevolutPayDisplayPreference) =
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

    type Update'SamsungPayDisplayPreference with
        static member New(?preference: Update'SamsungPayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'SamsungPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'SamsungPayDisplayPreference option
        }

    type Update'SamsungPay with
        static member New(?displayPreference: Update'SamsungPayDisplayPreference) =
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

    type Update'SatispayDisplayPreference with
        static member New(?preference: Update'SatispayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Satispay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'SatispayDisplayPreference option
        }

    type Update'Satispay with
        static member New(?displayPreference: Update'SatispayDisplayPreference) =
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

    type Update'SepaDebitDisplayPreference with
        static member New(?preference: Update'SepaDebitDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'SepaDebit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'SepaDebitDisplayPreference option
        }

    type Update'SepaDebit with
        static member New(?displayPreference: Update'SepaDebitDisplayPreference) =
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

    type Update'SofortDisplayPreference with
        static member New(?preference: Update'SofortDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Sofort =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'SofortDisplayPreference option
        }

    type Update'Sofort with
        static member New(?displayPreference: Update'SofortDisplayPreference) =
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

    type Update'SunbitDisplayPreference with
        static member New(?preference: Update'SunbitDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Sunbit =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'SunbitDisplayPreference option
        }

    type Update'Sunbit with
        static member New(?displayPreference: Update'SunbitDisplayPreference) =
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

    type Update'SwishDisplayPreference with
        static member New(?preference: Update'SwishDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Swish =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'SwishDisplayPreference option
        }

    type Update'Swish with
        static member New(?displayPreference: Update'SwishDisplayPreference) =
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

    type Update'TwintDisplayPreference with
        static member New(?preference: Update'TwintDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Twint =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'TwintDisplayPreference option
        }

    type Update'Twint with
        static member New(?displayPreference: Update'TwintDisplayPreference) =
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

    type Update'UpiDisplayPreference with
        static member New(?preference: Update'UpiDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Upi =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'UpiDisplayPreference option
        }

    type Update'Upi with
        static member New(?displayPreference: Update'UpiDisplayPreference) =
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

    type Update'UsBankAccountDisplayPreference with
        static member New(?preference: Update'UsBankAccountDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'UsBankAccount =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'UsBankAccountDisplayPreference option
        }

    type Update'UsBankAccount with
        static member New(?displayPreference: Update'UsBankAccountDisplayPreference) =
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

    type Update'WechatPayDisplayPreference with
        static member New(?preference: Update'WechatPayDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'WechatPay =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'WechatPayDisplayPreference option
        }

    type Update'WechatPay with
        static member New(?displayPreference: Update'WechatPayDisplayPreference) =
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

    type Update'ZipDisplayPreference with
        static member New(?preference: Update'ZipDisplayPreferencePreference) =
            {
                Preference = preference
            }

    type Update'Zip =
        {
            /// Whether or not the payment method should be displayed.
            [<Config.Form>]
            DisplayPreference: Update'ZipDisplayPreference option
        }

    type Update'Zip with
        static member New(?displayPreference: Update'ZipDisplayPreference) =
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

    type UpdateOptions with
        static member New(configuration: string, ?acssDebit: Update'AcssDebit, ?active: bool, ?affirm: Update'Affirm, ?afterpayClearpay: Update'AfterpayClearpay, ?alipay: Update'Alipay, ?alma: Update'Alma, ?amazonPay: Update'AmazonPay, ?applePay: Update'ApplePay, ?applePayLater: Update'ApplePayLater, ?auBecsDebit: Update'AuBecsDebit, ?bacsDebit: Update'BacsDebit, ?bancontact: Update'Bancontact, ?billie: Update'Billie, ?blik: Update'Blik, ?boleto: Update'Boleto, ?card: Update'Card, ?cartesBancaires: Update'CartesBancaires, ?cashapp: Update'Cashapp, ?crypto: Update'Crypto, ?customerBalance: Update'CustomerBalance, ?eps: Update'Eps, ?expand: string list, ?fpx: Update'Fpx, ?frMealVoucherConecs: Update'FrMealVoucherConecs, ?giropay: Update'Giropay, ?googlePay: Update'GooglePay, ?grabpay: Update'Grabpay, ?ideal: Update'Ideal, ?jcb: Update'Jcb, ?kakaoPay: Update'KakaoPay, ?klarna: Update'Klarna, ?konbini: Update'Konbini, ?krCard: Update'KrCard, ?link: Update'Link, ?mbWay: Update'MbWay, ?mobilepay: Update'Mobilepay, ?multibanco: Update'Multibanco, ?name: string, ?naverPay: Update'NaverPay, ?nzBankAccount: Update'NzBankAccount, ?oxxo: Update'Oxxo, ?p24: Update'P24, ?payByBank: Update'PayByBank, ?payco: Update'Payco, ?paynow: Update'Paynow, ?paypal: Update'Paypal, ?payto: Update'Payto, ?pix: Update'Pix, ?promptpay: Update'Promptpay, ?revolutPay: Update'RevolutPay, ?samsungPay: Update'SamsungPay, ?satispay: Update'Satispay, ?sepaDebit: Update'SepaDebit, ?sofort: Update'Sofort, ?sunbit: Update'Sunbit, ?swish: Update'Swish, ?twint: Update'Twint, ?upi: Update'Upi, ?usBankAccount: Update'UsBankAccount, ?wechatPay: Update'WechatPay, ?zip: Update'Zip) =
            {
                Configuration = configuration
                AcssDebit = acssDebit
                Active = active
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

    type ListOptions with
        static member New(?domainName: string, ?enabled: bool, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
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

    type CreateOptions with
        static member New(domainName: string, ?enabled: bool, ?expand: string list) =
            {
                DomainName = domainName
                Enabled = enabled
                Expand = expand
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            PaymentMethodDomain: string
        }

    type RetrieveOptions with
        static member New(paymentMethodDomain: string, ?expand: string list) =
            {
                PaymentMethodDomain = paymentMethodDomain
                Expand = expand
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

    type UpdateOptions with
        static member New(paymentMethodDomain: string, ?enabled: bool, ?expand: string list) =
            {
                PaymentMethodDomain = paymentMethodDomain
                Enabled = enabled
                Expand = expand
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

    type ValidateOptions with
        static member New(paymentMethodDomain: string, ?expand: string list) =
            {
                PaymentMethodDomain = paymentMethodDomain
                Expand = expand
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

    type ListOptions with
        static member New(subscription: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Subscription = subscription
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    type Create'BillingThresholdsItemBillingThresholds =
        {
            /// Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
            [<Config.Form>]
            UsageGte: int option
        }

    type Create'BillingThresholdsItemBillingThresholds with
        static member New(?usageGte: int) =
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

    type Create'Discounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
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

    type Create'PriceDataRecurring with
        static member New(?interval: Create'PriceDataRecurringInterval, ?intervalCount: int) =
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

    type Create'PriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: Create'PriceDataRecurring, ?taxBehavior: Create'PriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
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

    type CreateOptions with
        static member New(subscription: string, ?billingThresholds: Choice<Create'BillingThresholdsItemBillingThresholds,string>, ?discounts: Choice<Create'Discounts list,string>, ?expand: string list, ?metadata: Map<string, string>, ?paymentBehavior: Create'PaymentBehavior, ?plan: string, ?price: string, ?priceData: Create'PriceData, ?prorationBehavior: Create'ProrationBehavior, ?prorationDate: DateTime, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Subscription = subscription
                BillingThresholds = billingThresholds
                Discounts = discounts
                Expand = expand
                Metadata = metadata
                PaymentBehavior = paymentBehavior
                Plan = plan
                Price = price
                PriceData = priceData
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
                Quantity = quantity
                TaxRates = taxRates
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

    type DeleteOptions with
        static member New(item: string, ?clearUsage: bool, ?paymentBehavior: Delete'PaymentBehavior, ?prorationBehavior: Delete'ProrationBehavior, ?prorationDate: DateTime) =
            {
                Item = item
                ClearUsage = clearUsage
                PaymentBehavior = paymentBehavior
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Item: string
        }

    type RetrieveOptions with
        static member New(item: string, ?expand: string list) =
            {
                Item = item
                Expand = expand
            }

    type Update'BillingThresholdsItemBillingThresholds =
        {
            /// Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))
            [<Config.Form>]
            UsageGte: int option
        }

    type Update'BillingThresholdsItemBillingThresholds with
        static member New(?usageGte: int) =
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

    type Update'Discounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
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

    type Update'PriceDataRecurring with
        static member New(?interval: Update'PriceDataRecurringInterval, ?intervalCount: int) =
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

    type Update'PriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: Update'PriceDataRecurring, ?taxBehavior: Update'PriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
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

    type UpdateOptions with
        static member New(item: string, ?billingThresholds: Choice<Update'BillingThresholdsItemBillingThresholds,string>, ?discounts: Choice<Update'Discounts list,string>, ?expand: string list, ?metadata: Map<string, string>, ?offSession: bool, ?paymentBehavior: Update'PaymentBehavior, ?plan: string, ?price: string, ?priceData: Update'PriceData, ?prorationBehavior: Update'ProrationBehavior, ?prorationDate: DateTime, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Item = item
                BillingThresholds = billingThresholds
                Discounts = discounts
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

    type ListOptions with
        static member New(?canceledAt: int, ?completedAt: int, ?created: int, ?customer: string, ?customerAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?releasedAt: int, ?scheduled: bool, ?startingAfter: string) =
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

    type Create'BillingModeFlexible with
        static member New(?prorationDiscounts: Create'BillingModeFlexibleProrationDiscounts) =
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

    type Create'BillingMode with
        static member New(?flexible: Create'BillingModeFlexible, ?type': Create'BillingModeType) =
            {
                Flexible = flexible
                Type = type'
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

    type Create'DefaultSettingsAutomaticTaxLiability with
        static member New(?account: string, ?type': Create'DefaultSettingsAutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
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

    type Create'DefaultSettingsAutomaticTax with
        static member New(?enabled: bool, ?liability: Create'DefaultSettingsAutomaticTaxLiability) =
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

    type Create'DefaultSettingsBillingThresholdsBillingThresholds with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
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

    type Create'DefaultSettingsInvoiceSettingsIssuer with
        static member New(?account: string, ?type': Create'DefaultSettingsInvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
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

    type Create'DefaultSettingsInvoiceSettings with
        static member New(?accountTaxIds: Choice<string list,string>, ?daysUntilDue: int, ?issuer: Create'DefaultSettingsInvoiceSettingsIssuer) =
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

    type Create'DefaultSettingsTransferDataTransferDataSpecs with
        static member New(?amountPercent: decimal, ?destination: string) =
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

    type Create'DefaultSettings with
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

    type Create'PhasesAddInvoiceItemsDiscounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
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

    type Create'PhasesAddInvoiceItemsPeriodEnd with
        static member New(?timestamp: DateTime, ?type': Create'PhasesAddInvoiceItemsPeriodEndType) =
            {
                Timestamp = timestamp
                Type = type'
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

    type Create'PhasesAddInvoiceItemsPeriodStart with
        static member New(?timestamp: DateTime, ?type': Create'PhasesAddInvoiceItemsPeriodStartType) =
            {
                Timestamp = timestamp
                Type = type'
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

    type Create'PhasesAddInvoiceItemsPeriod with
        static member New(?end': Create'PhasesAddInvoiceItemsPeriodEnd, ?start: Create'PhasesAddInvoiceItemsPeriodStart) =
            {
                End = end'
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

    type Create'PhasesAddInvoiceItemsPriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?taxBehavior: Create'PhasesAddInvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
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

    type Create'PhasesAddInvoiceItems with
        static member New(?discounts: Create'PhasesAddInvoiceItemsDiscounts list, ?metadata: Map<string, string>, ?period: Create'PhasesAddInvoiceItemsPeriod, ?price: string, ?priceData: Create'PhasesAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
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

    type Create'PhasesAutomaticTaxLiability with
        static member New(?account: string, ?type': Create'PhasesAutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
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

    type Create'PhasesAutomaticTax with
        static member New(?enabled: bool, ?liability: Create'PhasesAutomaticTaxLiability) =
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

    type Create'PhasesBillingThresholdsBillingThresholds with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
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

    type Create'PhasesDiscounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
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

    type Create'PhasesDuration with
        static member New(?interval: Create'PhasesDurationInterval, ?intervalCount: int) =
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

    type Create'PhasesInvoiceSettingsIssuer with
        static member New(?account: string, ?type': Create'PhasesInvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
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

    type Create'PhasesInvoiceSettings with
        static member New(?accountTaxIds: Choice<string list,string>, ?daysUntilDue: int, ?issuer: Create'PhasesInvoiceSettingsIssuer) =
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

    type Create'PhasesItemsBillingThresholdsItemBillingThresholds with
        static member New(?usageGte: int) =
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

    type Create'PhasesItemsDiscounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
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

    type Create'PhasesItemsPriceDataRecurring with
        static member New(?interval: Create'PhasesItemsPriceDataRecurringInterval, ?intervalCount: int) =
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

    type Create'PhasesItemsPriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: Create'PhasesItemsPriceDataRecurring, ?taxBehavior: Create'PhasesItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
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

    type Create'PhasesItems with
        static member New(?billingThresholds: Choice<Create'PhasesItemsBillingThresholdsItemBillingThresholds,string>, ?discounts: Choice<Create'PhasesItemsDiscounts list,string>, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: Create'PhasesItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
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

    type Create'PhasesTransferData with
        static member New(?amountPercent: decimal, ?destination: string) =
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

    type Create'Phases with
        static member New(?addInvoiceItems: Create'PhasesAddInvoiceItems list, ?applicationFeePercent: decimal, ?automaticTax: Create'PhasesAutomaticTax, ?billingCycleAnchor: Create'PhasesBillingCycleAnchor, ?billingThresholds: Choice<Create'PhasesBillingThresholdsBillingThresholds,string>, ?collectionMethod: Create'PhasesCollectionMethod, ?currency: IsoTypes.IsoCurrencyCode, ?defaultPaymentMethod: string, ?defaultTaxRates: Choice<string list,string>, ?description: Choice<string,string>, ?discounts: Choice<Create'PhasesDiscounts list,string>, ?duration: Create'PhasesDuration, ?endDate: DateTime, ?invoiceSettings: Create'PhasesInvoiceSettings, ?items: Create'PhasesItems list, ?metadata: Map<string, string>, ?onBehalfOf: string, ?prorationBehavior: Create'PhasesProrationBehavior, ?transferData: Create'PhasesTransferData, ?trial: bool, ?trialEnd: DateTime) =
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

    type CreateOptions with
        static member New(?billingMode: Create'BillingMode, ?customer: string, ?customerAccount: string, ?defaultSettings: Create'DefaultSettings, ?endBehavior: Create'EndBehavior, ?expand: string list, ?fromSubscription: string, ?metadata: Map<string, string>, ?phases: Create'Phases list, ?startDate: Choice<DateTime,Create'StartDate>) =
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

    type RetrieveOptions with
        static member New(schedule: string, ?expand: string list) =
            {
                Schedule = schedule
                Expand = expand
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

    type Update'DefaultSettingsAutomaticTaxLiability with
        static member New(?account: string, ?type': Update'DefaultSettingsAutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
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

    type Update'DefaultSettingsAutomaticTax with
        static member New(?enabled: bool, ?liability: Update'DefaultSettingsAutomaticTaxLiability) =
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

    type Update'DefaultSettingsBillingThresholdsBillingThresholds with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
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

    type Update'DefaultSettingsInvoiceSettingsIssuer with
        static member New(?account: string, ?type': Update'DefaultSettingsInvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
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

    type Update'DefaultSettingsInvoiceSettings with
        static member New(?accountTaxIds: Choice<string list,string>, ?daysUntilDue: int, ?issuer: Update'DefaultSettingsInvoiceSettingsIssuer) =
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

    type Update'DefaultSettingsTransferDataTransferDataSpecs with
        static member New(?amountPercent: decimal, ?destination: string) =
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

    type Update'DefaultSettings with
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

    type Update'PhasesAddInvoiceItemsDiscounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
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

    type Update'PhasesAddInvoiceItemsPeriodEnd with
        static member New(?timestamp: DateTime, ?type': Update'PhasesAddInvoiceItemsPeriodEndType) =
            {
                Timestamp = timestamp
                Type = type'
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

    type Update'PhasesAddInvoiceItemsPeriodStart with
        static member New(?timestamp: DateTime, ?type': Update'PhasesAddInvoiceItemsPeriodStartType) =
            {
                Timestamp = timestamp
                Type = type'
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

    type Update'PhasesAddInvoiceItemsPeriod with
        static member New(?end': Update'PhasesAddInvoiceItemsPeriodEnd, ?start: Update'PhasesAddInvoiceItemsPeriodStart) =
            {
                End = end'
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

    type Update'PhasesAddInvoiceItemsPriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?taxBehavior: Update'PhasesAddInvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
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

    type Update'PhasesAddInvoiceItems with
        static member New(?discounts: Update'PhasesAddInvoiceItemsDiscounts list, ?metadata: Map<string, string>, ?period: Update'PhasesAddInvoiceItemsPeriod, ?price: string, ?priceData: Update'PhasesAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
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

    type Update'PhasesAutomaticTaxLiability with
        static member New(?account: string, ?type': Update'PhasesAutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
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

    type Update'PhasesAutomaticTax with
        static member New(?enabled: bool, ?liability: Update'PhasesAutomaticTaxLiability) =
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

    type Update'PhasesBillingThresholdsBillingThresholds with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
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

    type Update'PhasesDiscounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
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

    type Update'PhasesDuration with
        static member New(?interval: Update'PhasesDurationInterval, ?intervalCount: int) =
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

    type Update'PhasesInvoiceSettingsIssuer with
        static member New(?account: string, ?type': Update'PhasesInvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
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

    type Update'PhasesInvoiceSettings with
        static member New(?accountTaxIds: Choice<string list,string>, ?daysUntilDue: int, ?issuer: Update'PhasesInvoiceSettingsIssuer) =
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

    type Update'PhasesItemsBillingThresholdsItemBillingThresholds with
        static member New(?usageGte: int) =
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

    type Update'PhasesItemsDiscounts with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
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

    type Update'PhasesItemsPriceDataRecurring with
        static member New(?interval: Update'PhasesItemsPriceDataRecurringInterval, ?intervalCount: int) =
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

    type Update'PhasesItemsPriceData with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: Update'PhasesItemsPriceDataRecurring, ?taxBehavior: Update'PhasesItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
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

    type Update'PhasesItems with
        static member New(?billingThresholds: Choice<Update'PhasesItemsBillingThresholdsItemBillingThresholds,string>, ?discounts: Choice<Update'PhasesItemsDiscounts list,string>, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: Update'PhasesItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
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

    type Update'PhasesTransferData with
        static member New(?amountPercent: decimal, ?destination: string) =
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

    type Update'Phases with
        static member New(?addInvoiceItems: Update'PhasesAddInvoiceItems list, ?applicationFeePercent: decimal, ?automaticTax: Update'PhasesAutomaticTax, ?billingCycleAnchor: Update'PhasesBillingCycleAnchor, ?billingThresholds: Choice<Update'PhasesBillingThresholdsBillingThresholds,string>, ?collectionMethod: Update'PhasesCollectionMethod, ?currency: IsoTypes.IsoCurrencyCode, ?defaultPaymentMethod: string, ?defaultTaxRates: Choice<string list,string>, ?description: Choice<string,string>, ?discounts: Choice<Update'PhasesDiscounts list,string>, ?duration: Update'PhasesDuration, ?endDate: Choice<DateTime,Update'PhasesEndDate>, ?invoiceSettings: Update'PhasesInvoiceSettings, ?items: Update'PhasesItems list, ?metadata: Map<string, string>, ?onBehalfOf: string, ?prorationBehavior: Update'PhasesProrationBehavior, ?startDate: Choice<DateTime,Update'PhasesStartDate>, ?transferData: Update'PhasesTransferData, ?trial: bool, ?trialEnd: Choice<DateTime,Update'PhasesTrialEnd>) =
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

    type UpdateOptions with
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

    type CancelOptions with
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

    type ReleaseOptions with
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

