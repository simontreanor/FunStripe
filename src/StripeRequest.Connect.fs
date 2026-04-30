namespace FunStripe.StripeRequest

open FunStripe
open System.Text.Json.Serialization
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module AccountLinks =

    type Create'CollectionOptionsFields =
    | CurrentlyDue
    | EventuallyDue

    type Create'CollectionOptionsFutureRequirements =
    | Include
    | Omit

    type Create'CollectionOptions = {
        ///<summary>Specifies whether the platform collects only currently_due requirements (`currently_due`) or both currently_due and eventually_due requirements (`eventually_due`). If you don't specify `collection_options`, the default value is `currently_due`.</summary>
        [<Config.Form>]Fields: Create'CollectionOptionsFields option
        ///<summary>Specifies whether the platform collects future_requirements in addition to requirements in Connect Onboarding. The default value is `omit`.</summary>
        [<Config.Form>]FutureRequirements: Create'CollectionOptionsFutureRequirements option
    }
    with
        static member New(?fields: Create'CollectionOptionsFields, ?futureRequirements: Create'CollectionOptionsFutureRequirements) =
            {
                Fields = fields
                FutureRequirements = futureRequirements
            }

    type Create'Collect =
    | CurrentlyDue
    | EventuallyDue

    type Create'Type =
    | AccountOnboarding
    | AccountUpdate

    type CreateOptions = {
        ///<summary>The identifier of the account to create an account link for.</summary>
        [<Config.Form>]Account: string
        ///<summary>The collect parameter is deprecated. Use `collection_options` instead.</summary>
        [<Config.Form>]Collect: Create'Collect option
        ///<summary>Specifies the requirements that Stripe collects from connected accounts in the Connect Onboarding flow.</summary>
        [<Config.Form>]CollectionOptions: Create'CollectionOptions option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The URL the user will be redirected to if the account link is expired, has been previously-visited, or is otherwise invalid. The URL you specify should attempt to generate a new account link with the same parameters used to create the original account link, then redirect the user to the new account link's URL so they can continue with Connect Onboarding. If a new account link cannot be generated or the redirect fails you should display a useful error to the user.</summary>
        [<Config.Form>]RefreshUrl: string option
        ///<summary>The URL that the user will be redirected to upon leaving or completing the linked flow.</summary>
        [<Config.Form>]ReturnUrl: string option
        ///<summary>The type of account link the user is requesting.
        ///You can create Account Links of type `account_update` only for connected accounts where your platform is responsible for collecting requirements, including Custom accounts. You can't create them for accounts that have access to a Stripe-hosted Dashboard. If you use [Connect embedded components](/connect/get-started-connect-embedded-components), you can include components that allow your connected accounts to update their own information. For an account without Stripe-hosted Dashboard access where Stripe is liable for negative balances, you must use embedded components.</summary>
        [<Config.Form>]Type: Create'Type
    }
    with
        static member New(account: string, type': Create'Type, ?collect: Create'Collect, ?collectionOptions: Create'CollectionOptions, ?expand: string list, ?refreshUrl: string, ?returnUrl: string) =
            {
                Account = account
                Collect = collect
                CollectionOptions = collectionOptions
                Expand = expand
                RefreshUrl = refreshUrl
                ReturnUrl = returnUrl
                Type = type'
            }

    ///<summary><p>Creates an AccountLink object that includes a single-use Stripe URL that the platform can redirect their user to in order to take them through the Connect Onboarding flow.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/account_links"
        |> RestApi.postAsync<_, AccountLink> settings (Map.empty) options

module AccountSessions =

    type Create'ComponentsAccountManagementFeatures = {
        ///<summary>Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.</summary>
        [<Config.Form>]DisableStripeUserAuthentication: bool option
        ///<summary>Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.</summary>
        [<Config.Form>]ExternalAccountCollection: bool option
    }
    with
        static member New(?disableStripeUserAuthentication: bool, ?externalAccountCollection: bool) =
            {
                DisableStripeUserAuthentication = disableStripeUserAuthentication
                ExternalAccountCollection = externalAccountCollection
            }

    type Create'ComponentsAccountManagement = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsAccountManagementFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsAccountManagementFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsAccountOnboardingFeatures = {
        ///<summary>Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.</summary>
        [<Config.Form>]DisableStripeUserAuthentication: bool option
        ///<summary>Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.</summary>
        [<Config.Form>]ExternalAccountCollection: bool option
    }
    with
        static member New(?disableStripeUserAuthentication: bool, ?externalAccountCollection: bool) =
            {
                DisableStripeUserAuthentication = disableStripeUserAuthentication
                ExternalAccountCollection = externalAccountCollection
            }

    type Create'ComponentsAccountOnboarding = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsAccountOnboardingFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsAccountOnboardingFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsBalanceReport = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>An empty list, because this embedded component has no features.</summary>
        [<Config.Form>]Features: string option
    }
    with
        static member New(?enabled: bool, ?features: string) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsBalancesFeatures = {
        ///<summary>Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.</summary>
        [<Config.Form>]DisableStripeUserAuthentication: bool option
        ///<summary>Whether to allow payout schedule to be changed. Defaults to `true` when `controller.losses.payments` is set to `stripe` for the account, otherwise `false`.</summary>
        [<Config.Form>]EditPayoutSchedule: bool option
        ///<summary>Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.</summary>
        [<Config.Form>]ExternalAccountCollection: bool option
        ///<summary>Whether instant payouts are enabled for this component.</summary>
        [<Config.Form>]InstantPayouts: bool option
        ///<summary>Whether to allow creation of standard payouts. Defaults to `true` when `controller.losses.payments` is set to `stripe` for the account, otherwise `false`.</summary>
        [<Config.Form>]StandardPayouts: bool option
    }
    with
        static member New(?disableStripeUserAuthentication: bool, ?editPayoutSchedule: bool, ?externalAccountCollection: bool, ?instantPayouts: bool, ?standardPayouts: bool) =
            {
                DisableStripeUserAuthentication = disableStripeUserAuthentication
                EditPayoutSchedule = editPayoutSchedule
                ExternalAccountCollection = externalAccountCollection
                InstantPayouts = instantPayouts
                StandardPayouts = standardPayouts
            }

    type Create'ComponentsBalances = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsBalancesFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsBalancesFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsDisputesListFeatures = {
        ///<summary>Whether to allow capturing and cancelling payment intents. This is `true` by default.</summary>
        [<Config.Form>]CapturePayments: bool option
        ///<summary>Whether connected accounts can manage destination charges that are created on behalf of them. This is `false` by default.</summary>
        [<Config.Form>]DestinationOnBehalfOfChargeManagement: bool option
        ///<summary>Whether responding to disputes is enabled, including submitting evidence and accepting disputes. This is `true` by default.</summary>
        [<Config.Form>]DisputeManagement: bool option
        ///<summary>Whether sending refunds is enabled. This is `true` by default.</summary>
        [<Config.Form>]RefundManagement: bool option
    }
    with
        static member New(?capturePayments: bool, ?destinationOnBehalfOfChargeManagement: bool, ?disputeManagement: bool, ?refundManagement: bool) =
            {
                CapturePayments = capturePayments
                DestinationOnBehalfOfChargeManagement = destinationOnBehalfOfChargeManagement
                DisputeManagement = disputeManagement
                RefundManagement = refundManagement
            }

    type Create'ComponentsDisputesList = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsDisputesListFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsDisputesListFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsDocuments = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>An empty list, because this embedded component has no features.</summary>
        [<Config.Form>]Features: string option
    }
    with
        static member New(?enabled: bool, ?features: string) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsFinancialAccountFeatures = {
        ///<summary>Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.</summary>
        [<Config.Form>]DisableStripeUserAuthentication: bool option
        ///<summary>Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.</summary>
        [<Config.Form>]ExternalAccountCollection: bool option
        ///<summary>Whether to allow sending money.</summary>
        [<Config.Form>]SendMoney: bool option
        ///<summary>Whether to allow transferring balance.</summary>
        [<Config.Form>]TransferBalance: bool option
    }
    with
        static member New(?disableStripeUserAuthentication: bool, ?externalAccountCollection: bool, ?sendMoney: bool, ?transferBalance: bool) =
            {
                DisableStripeUserAuthentication = disableStripeUserAuthentication
                ExternalAccountCollection = externalAccountCollection
                SendMoney = sendMoney
                TransferBalance = transferBalance
            }

    type Create'ComponentsFinancialAccount = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsFinancialAccountFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsFinancialAccountFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsFinancialAccountTransactionsFeatures = {
        ///<summary>Whether to allow card spend dispute management features.</summary>
        [<Config.Form>]CardSpendDisputeManagement: bool option
    }
    with
        static member New(?cardSpendDisputeManagement: bool) =
            {
                CardSpendDisputeManagement = cardSpendDisputeManagement
            }

    type Create'ComponentsFinancialAccountTransactions = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsFinancialAccountTransactionsFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsFinancialAccountTransactionsFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsInstantPayoutsPromotionFeatures = {
        ///<summary>Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.</summary>
        [<Config.Form>]DisableStripeUserAuthentication: bool option
        ///<summary>Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.</summary>
        [<Config.Form>]ExternalAccountCollection: bool option
        ///<summary>Whether instant payouts are enabled for this component.</summary>
        [<Config.Form>]InstantPayouts: bool option
    }
    with
        static member New(?disableStripeUserAuthentication: bool, ?externalAccountCollection: bool, ?instantPayouts: bool) =
            {
                DisableStripeUserAuthentication = disableStripeUserAuthentication
                ExternalAccountCollection = externalAccountCollection
                InstantPayouts = instantPayouts
            }

    type Create'ComponentsInstantPayoutsPromotion = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsInstantPayoutsPromotionFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsInstantPayoutsPromotionFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsIssuingCardFeatures = {
        ///<summary>Whether to allow card management features.</summary>
        [<Config.Form>]CardManagement: bool option
        ///<summary>Whether to allow card spend dispute management features.</summary>
        [<Config.Form>]CardSpendDisputeManagement: bool option
        ///<summary>Whether to allow cardholder management features.</summary>
        [<Config.Form>]CardholderManagement: bool option
        ///<summary>Whether to allow spend control management features.</summary>
        [<Config.Form>]SpendControlManagement: bool option
    }
    with
        static member New(?cardManagement: bool, ?cardSpendDisputeManagement: bool, ?cardholderManagement: bool, ?spendControlManagement: bool) =
            {
                CardManagement = cardManagement
                CardSpendDisputeManagement = cardSpendDisputeManagement
                CardholderManagement = cardholderManagement
                SpendControlManagement = spendControlManagement
            }

    type Create'ComponentsIssuingCard = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsIssuingCardFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsIssuingCardFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsIssuingCardsListFeatures = {
        ///<summary>Whether to allow card management features.</summary>
        [<Config.Form>]CardManagement: bool option
        ///<summary>Whether to allow card spend dispute management features.</summary>
        [<Config.Form>]CardSpendDisputeManagement: bool option
        ///<summary>Whether to allow cardholder management features.</summary>
        [<Config.Form>]CardholderManagement: bool option
        ///<summary>Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.</summary>
        [<Config.Form>]DisableStripeUserAuthentication: bool option
        ///<summary>Whether to allow spend control management features.</summary>
        [<Config.Form>]SpendControlManagement: bool option
    }
    with
        static member New(?cardManagement: bool, ?cardSpendDisputeManagement: bool, ?cardholderManagement: bool, ?disableStripeUserAuthentication: bool, ?spendControlManagement: bool) =
            {
                CardManagement = cardManagement
                CardSpendDisputeManagement = cardSpendDisputeManagement
                CardholderManagement = cardholderManagement
                DisableStripeUserAuthentication = disableStripeUserAuthentication
                SpendControlManagement = spendControlManagement
            }

    type Create'ComponentsIssuingCardsList = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsIssuingCardsListFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsIssuingCardsListFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsNotificationBannerFeatures = {
        ///<summary>Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.</summary>
        [<Config.Form>]DisableStripeUserAuthentication: bool option
        ///<summary>Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.</summary>
        [<Config.Form>]ExternalAccountCollection: bool option
    }
    with
        static member New(?disableStripeUserAuthentication: bool, ?externalAccountCollection: bool) =
            {
                DisableStripeUserAuthentication = disableStripeUserAuthentication
                ExternalAccountCollection = externalAccountCollection
            }

    type Create'ComponentsNotificationBanner = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsNotificationBannerFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsNotificationBannerFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsPaymentDetailsFeatures = {
        ///<summary>Whether to allow capturing and cancelling payment intents. This is `true` by default.</summary>
        [<Config.Form>]CapturePayments: bool option
        ///<summary>Whether connected accounts can manage destination charges that are created on behalf of them. This is `false` by default.</summary>
        [<Config.Form>]DestinationOnBehalfOfChargeManagement: bool option
        ///<summary>Whether responding to disputes is enabled, including submitting evidence and accepting disputes. This is `true` by default.</summary>
        [<Config.Form>]DisputeManagement: bool option
        ///<summary>Whether sending refunds is enabled. This is `true` by default.</summary>
        [<Config.Form>]RefundManagement: bool option
    }
    with
        static member New(?capturePayments: bool, ?destinationOnBehalfOfChargeManagement: bool, ?disputeManagement: bool, ?refundManagement: bool) =
            {
                CapturePayments = capturePayments
                DestinationOnBehalfOfChargeManagement = destinationOnBehalfOfChargeManagement
                DisputeManagement = disputeManagement
                RefundManagement = refundManagement
            }

    type Create'ComponentsPaymentDetails = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsPaymentDetailsFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsPaymentDetailsFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsPaymentDisputesFeatures = {
        ///<summary>Whether connected accounts can manage destination charges that are created on behalf of them. This is `false` by default.</summary>
        [<Config.Form>]DestinationOnBehalfOfChargeManagement: bool option
        ///<summary>Whether responding to disputes is enabled, including submitting evidence and accepting disputes. This is `true` by default.</summary>
        [<Config.Form>]DisputeManagement: bool option
        ///<summary>Whether sending refunds is enabled. This is `true` by default.</summary>
        [<Config.Form>]RefundManagement: bool option
    }
    with
        static member New(?destinationOnBehalfOfChargeManagement: bool, ?disputeManagement: bool, ?refundManagement: bool) =
            {
                DestinationOnBehalfOfChargeManagement = destinationOnBehalfOfChargeManagement
                DisputeManagement = disputeManagement
                RefundManagement = refundManagement
            }

    type Create'ComponentsPaymentDisputes = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsPaymentDisputesFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsPaymentDisputesFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsPaymentsFeatures = {
        ///<summary>Whether to allow capturing and cancelling payment intents. This is `true` by default.</summary>
        [<Config.Form>]CapturePayments: bool option
        ///<summary>Whether connected accounts can manage destination charges that are created on behalf of them. This is `false` by default.</summary>
        [<Config.Form>]DestinationOnBehalfOfChargeManagement: bool option
        ///<summary>Whether responding to disputes is enabled, including submitting evidence and accepting disputes. This is `true` by default.</summary>
        [<Config.Form>]DisputeManagement: bool option
        ///<summary>Whether sending refunds is enabled. This is `true` by default.</summary>
        [<Config.Form>]RefundManagement: bool option
    }
    with
        static member New(?capturePayments: bool, ?destinationOnBehalfOfChargeManagement: bool, ?disputeManagement: bool, ?refundManagement: bool) =
            {
                CapturePayments = capturePayments
                DestinationOnBehalfOfChargeManagement = destinationOnBehalfOfChargeManagement
                DisputeManagement = disputeManagement
                RefundManagement = refundManagement
            }

    type Create'ComponentsPayments = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsPaymentsFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsPaymentsFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsPayoutDetails = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>An empty list, because this embedded component has no features.</summary>
        [<Config.Form>]Features: string option
    }
    with
        static member New(?enabled: bool, ?features: string) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsPayoutReconciliationReport = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>An empty list, because this embedded component has no features.</summary>
        [<Config.Form>]Features: string option
    }
    with
        static member New(?enabled: bool, ?features: string) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsPayoutsFeatures = {
        ///<summary>Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.</summary>
        [<Config.Form>]DisableStripeUserAuthentication: bool option
        ///<summary>Whether to allow payout schedule to be changed. Defaults to `true` when `controller.losses.payments` is set to `stripe` for the account, otherwise `false`.</summary>
        [<Config.Form>]EditPayoutSchedule: bool option
        ///<summary>Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.</summary>
        [<Config.Form>]ExternalAccountCollection: bool option
        ///<summary>Whether instant payouts are enabled for this component.</summary>
        [<Config.Form>]InstantPayouts: bool option
        ///<summary>Whether to allow creation of standard payouts. Defaults to `true` when `controller.losses.payments` is set to `stripe` for the account, otherwise `false`.</summary>
        [<Config.Form>]StandardPayouts: bool option
    }
    with
        static member New(?disableStripeUserAuthentication: bool, ?editPayoutSchedule: bool, ?externalAccountCollection: bool, ?instantPayouts: bool, ?standardPayouts: bool) =
            {
                DisableStripeUserAuthentication = disableStripeUserAuthentication
                EditPayoutSchedule = editPayoutSchedule
                ExternalAccountCollection = externalAccountCollection
                InstantPayouts = instantPayouts
                StandardPayouts = standardPayouts
            }

    type Create'ComponentsPayouts = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of features enabled in the embedded component.</summary>
        [<Config.Form>]Features: Create'ComponentsPayoutsFeatures option
    }
    with
        static member New(?enabled: bool, ?features: Create'ComponentsPayoutsFeatures) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsPayoutsList = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>An empty list, because this embedded component has no features.</summary>
        [<Config.Form>]Features: string option
    }
    with
        static member New(?enabled: bool, ?features: string) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsTaxRegistrations = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>An empty list, because this embedded component has no features.</summary>
        [<Config.Form>]Features: string option
    }
    with
        static member New(?enabled: bool, ?features: string) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'ComponentsTaxSettings = {
        ///<summary>Whether the embedded component is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>An empty list, because this embedded component has no features.</summary>
        [<Config.Form>]Features: string option
    }
    with
        static member New(?enabled: bool, ?features: string) =
            {
                Enabled = enabled
                Features = features
            }

    type Create'Components = {
        ///<summary>Configuration for the [account management](/connect/supported-embedded-components/account-management/) embedded component.</summary>
        [<Config.Form>]AccountManagement: Create'ComponentsAccountManagement option
        ///<summary>Configuration for the [account onboarding](/connect/supported-embedded-components/account-onboarding/) embedded component.</summary>
        [<Config.Form>]AccountOnboarding: Create'ComponentsAccountOnboarding option
        ///<summary>Configuration for the [balance report](/connect/supported-embedded-components/financial-reports#balance-report) embedded component.</summary>
        [<Config.Form>]BalanceReport: Create'ComponentsBalanceReport option
        ///<summary>Configuration for the [balances](/connect/supported-embedded-components/balances/) embedded component.</summary>
        [<Config.Form>]Balances: Create'ComponentsBalances option
        ///<summary>Configuration for the [disputes list](/connect/supported-embedded-components/disputes-list/) embedded component.</summary>
        [<Config.Form>]DisputesList: Create'ComponentsDisputesList option
        ///<summary>Configuration for the [documents](/connect/supported-embedded-components/documents/) embedded component.</summary>
        [<Config.Form>]Documents: Create'ComponentsDocuments option
        ///<summary>Configuration for the [financial account](/connect/supported-embedded-components/financial-account/) embedded component.</summary>
        [<Config.Form>]FinancialAccount: Create'ComponentsFinancialAccount option
        ///<summary>Configuration for the [financial account transactions](/connect/supported-embedded-components/financial-account-transactions/) embedded component.</summary>
        [<Config.Form>]FinancialAccountTransactions: Create'ComponentsFinancialAccountTransactions option
        ///<summary>Configuration for the [instant payouts promotion](/connect/supported-embedded-components/instant-payouts-promotion/) embedded component.</summary>
        [<Config.Form>]InstantPayoutsPromotion: Create'ComponentsInstantPayoutsPromotion option
        ///<summary>Configuration for the [issuing card](/connect/supported-embedded-components/issuing-card/) embedded component.</summary>
        [<Config.Form>]IssuingCard: Create'ComponentsIssuingCard option
        ///<summary>Configuration for the [issuing cards list](/connect/supported-embedded-components/issuing-cards-list/) embedded component.</summary>
        [<Config.Form>]IssuingCardsList: Create'ComponentsIssuingCardsList option
        ///<summary>Configuration for the [notification banner](/connect/supported-embedded-components/notification-banner/) embedded component.</summary>
        [<Config.Form>]NotificationBanner: Create'ComponentsNotificationBanner option
        ///<summary>Configuration for the [payment details](/connect/supported-embedded-components/payment-details/) embedded component.</summary>
        [<Config.Form>]PaymentDetails: Create'ComponentsPaymentDetails option
        ///<summary>Configuration for the [payment disputes](/connect/supported-embedded-components/payment-disputes/) embedded component.</summary>
        [<Config.Form>]PaymentDisputes: Create'ComponentsPaymentDisputes option
        ///<summary>Configuration for the [payments](/connect/supported-embedded-components/payments/) embedded component.</summary>
        [<Config.Form>]Payments: Create'ComponentsPayments option
        ///<summary>Configuration for the [payout details](/connect/supported-embedded-components/payout-details/) embedded component.</summary>
        [<Config.Form>]PayoutDetails: Create'ComponentsPayoutDetails option
        ///<summary>Configuration for the [payout reconciliation report](/connect/supported-embedded-components/financial-reports#payout-reconciliation-report) embedded component.</summary>
        [<Config.Form>]PayoutReconciliationReport: Create'ComponentsPayoutReconciliationReport option
        ///<summary>Configuration for the [payouts](/connect/supported-embedded-components/payouts/) embedded component.</summary>
        [<Config.Form>]Payouts: Create'ComponentsPayouts option
        ///<summary>Configuration for the [payouts list](/connect/supported-embedded-components/payouts-list/) embedded component.</summary>
        [<Config.Form>]PayoutsList: Create'ComponentsPayoutsList option
        ///<summary>Configuration for the [tax registrations](/connect/supported-embedded-components/tax-registrations/) embedded component.</summary>
        [<Config.Form>]TaxRegistrations: Create'ComponentsTaxRegistrations option
        ///<summary>Configuration for the [tax settings](/connect/supported-embedded-components/tax-settings/) embedded component.</summary>
        [<Config.Form>]TaxSettings: Create'ComponentsTaxSettings option
    }
    with
        static member New(?accountManagement: Create'ComponentsAccountManagement, ?payoutsList: Create'ComponentsPayoutsList, ?payouts: Create'ComponentsPayouts, ?payoutReconciliationReport: Create'ComponentsPayoutReconciliationReport, ?payoutDetails: Create'ComponentsPayoutDetails, ?payments: Create'ComponentsPayments, ?paymentDisputes: Create'ComponentsPaymentDisputes, ?paymentDetails: Create'ComponentsPaymentDetails, ?notificationBanner: Create'ComponentsNotificationBanner, ?taxRegistrations: Create'ComponentsTaxRegistrations, ?issuingCardsList: Create'ComponentsIssuingCardsList, ?instantPayoutsPromotion: Create'ComponentsInstantPayoutsPromotion, ?financialAccountTransactions: Create'ComponentsFinancialAccountTransactions, ?financialAccount: Create'ComponentsFinancialAccount, ?documents: Create'ComponentsDocuments, ?disputesList: Create'ComponentsDisputesList, ?balances: Create'ComponentsBalances, ?balanceReport: Create'ComponentsBalanceReport, ?accountOnboarding: Create'ComponentsAccountOnboarding, ?issuingCard: Create'ComponentsIssuingCard, ?taxSettings: Create'ComponentsTaxSettings) =
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

    type CreateOptions = {
        ///<summary>The identifier of the account to create an Account Session for.</summary>
        [<Config.Form>]Account: string
        ///<summary>Each key of the dictionary represents an embedded component, and each embedded component maps to its configuration (e.g. whether it has been enabled or not).</summary>
        [<Config.Form>]Components: Create'Components
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(account: string, components: Create'Components, ?expand: string list) =
            {
                Account = account
                Components = components
                Expand = expand
            }

    ///<summary><p>Creates a AccountSession object that includes a single-use token that the platform can use on their front-end to grant client-side API access.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/account_sessions"
        |> RestApi.postAsync<_, AccountSession> settings (Map.empty) options

module Accounts =

    type ListOptions = {
        ///<summary>Only return connected accounts that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
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

    ///<summary><p>Returns a list of accounts connected to your platform via <a href="/docs/connect">Connect</a>. If you’re not a platform, the list is empty.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/accounts"
        |> RestApi.getAsync<StripeList<Account>> settings qs

    type Create'BusinessProfileAnnualRevenue = {
        ///<summary>A non-negative integer representing the amount in the [smallest currency unit](/currencies#zero-decimal).</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The close-out date of the preceding fiscal year in ISO 8601 format. E.g. 2023-12-31 for the 31st of December, 2023.</summary>
        [<Config.Form>]FiscalYearEnd: string option
    }
    with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode, ?fiscalYearEnd: string) =
            {
                Amount = amount
                Currency = currency
                FiscalYearEnd = fiscalYearEnd
            }

    type Create'BusinessProfileMinorityOwnedBusinessDesignation =
    | LgbtqiOwnedBusiness
    | MinorityOwnedBusiness
    | None'OfTheseApply
    | PreferNotToAnswer
    | WomenOwnedBusiness

    type Create'BusinessProfileMonthlyEstimatedRevenue = {
        ///<summary>A non-negative integer representing how much to charge in the [smallest currency unit](/currencies#zero-decimal).</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
    }
    with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode) =
            {
                Amount = amount
                Currency = currency
            }

    type Create'BusinessProfileSupportAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'BusinessProfile = {
        ///<summary>The applicant's gross annual revenue for its preceding fiscal year.</summary>
        [<Config.Form>]AnnualRevenue: Create'BusinessProfileAnnualRevenue option
        ///<summary>An estimated upper bound of employees, contractors, vendors, etc. currently working for the business.</summary>
        [<Config.Form>]EstimatedWorkerCount: int option
        ///<summary>[The merchant category code for the account](/connect/setting-mcc). MCCs are used to classify businesses based on the goods or services they provide.</summary>
        [<Config.Form>]Mcc: string option
        ///<summary>Whether the business is a minority-owned, women-owned, and/or LGBTQI+ -owned business.</summary>
        [<Config.Form>]MinorityOwnedBusinessDesignation: Create'BusinessProfileMinorityOwnedBusinessDesignation list option
        ///<summary>An estimate of the monthly revenue of the business. Only accepted for accounts in Brazil and India.</summary>
        [<Config.Form>]MonthlyEstimatedRevenue: Create'BusinessProfileMonthlyEstimatedRevenue option
        ///<summary>The customer-facing business name.</summary>
        [<Config.Form>]Name: string option
        ///<summary>Internal-only description of the product sold by, or service provided by, the business. Used by Stripe for risk and underwriting purposes.</summary>
        [<Config.Form>]ProductDescription: string option
        ///<summary>A publicly available mailing address for sending support issues to.</summary>
        [<Config.Form>]SupportAddress: Create'BusinessProfileSupportAddress option
        ///<summary>A publicly available email address for sending support issues to.</summary>
        [<Config.Form>]SupportEmail: string option
        ///<summary>A publicly available phone number to call with support issues.</summary>
        [<Config.Form>]SupportPhone: string option
        ///<summary>A publicly available website for handling support issues.</summary>
        [<Config.Form>]SupportUrl: Choice<string,string> option
        ///<summary>The business's publicly available website.</summary>
        [<Config.Form>]Url: string option
    }
    with
        static member New(?annualRevenue: Create'BusinessProfileAnnualRevenue, ?estimatedWorkerCount: int, ?mcc: string, ?minorityOwnedBusinessDesignation: Create'BusinessProfileMinorityOwnedBusinessDesignation list, ?monthlyEstimatedRevenue: Create'BusinessProfileMonthlyEstimatedRevenue, ?name: string, ?productDescription: string, ?supportAddress: Create'BusinessProfileSupportAddress, ?supportEmail: string, ?supportPhone: string, ?supportUrl: Choice<string,string>, ?url: string) =
            {
                AnnualRevenue = annualRevenue
                EstimatedWorkerCount = estimatedWorkerCount
                Mcc = mcc
                MinorityOwnedBusinessDesignation = minorityOwnedBusinessDesignation
                MonthlyEstimatedRevenue = monthlyEstimatedRevenue
                Name = name
                ProductDescription = productDescription
                SupportAddress = supportAddress
                SupportEmail = supportEmail
                SupportPhone = supportPhone
                SupportUrl = supportUrl
                Url = url
            }

    type Create'CapabilitiesAcssDebitPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesAffirmPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesAfterpayClearpayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesAlmaPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesAmazonPayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesAppDistribution = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesAuBecsDebitPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesBacsDebitPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesBancontactPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesBankTransferPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesBilliePayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesBlikPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesBoletoPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesCardIssuing = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesCardPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesCartesBancairesPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesCashappPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesCryptoPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesEpsPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesFpxPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesGbBankTransferPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesGiropayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesGrabpayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesIdealPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesIndiaInternationalPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesJcbPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesJpBankTransferPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesKakaoPayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesKlarnaPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesKonbiniPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesKrCardPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesLegacyPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesLinkPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesMbWayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesMobilepayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesMultibancoPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesMxBankTransferPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesNaverPayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesNzBankAccountBecsDebitPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesOxxoPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesP24Payments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesPayByBankPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesPaycoPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesPaynowPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesPaytoPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesPixPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesPromptpayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesRevolutPayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesSamsungPayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesSatispayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesSepaBankTransferPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesSepaDebitPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesSofortPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesSunbitPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesSwishPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesTaxReportingUs1099K = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesTaxReportingUs1099Misc = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesTransfers = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesTreasury = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesTwintPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesUpiPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesUsBankAccountAchPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesUsBankTransferPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'CapabilitiesZipPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Create'Capabilities = {
        ///<summary>The acss_debit_payments capability.</summary>
        [<Config.Form>]AcssDebitPayments: Create'CapabilitiesAcssDebitPayments option
        ///<summary>The affirm_payments capability.</summary>
        [<Config.Form>]AffirmPayments: Create'CapabilitiesAffirmPayments option
        ///<summary>The afterpay_clearpay_payments capability.</summary>
        [<Config.Form>]AfterpayClearpayPayments: Create'CapabilitiesAfterpayClearpayPayments option
        ///<summary>The alma_payments capability.</summary>
        [<Config.Form>]AlmaPayments: Create'CapabilitiesAlmaPayments option
        ///<summary>The amazon_pay_payments capability.</summary>
        [<Config.Form>]AmazonPayPayments: Create'CapabilitiesAmazonPayPayments option
        ///<summary>The app_distribution capability.</summary>
        [<Config.Form>]AppDistribution: Create'CapabilitiesAppDistribution option
        ///<summary>The au_becs_debit_payments capability.</summary>
        [<Config.Form>]AuBecsDebitPayments: Create'CapabilitiesAuBecsDebitPayments option
        ///<summary>The bacs_debit_payments capability.</summary>
        [<Config.Form>]BacsDebitPayments: Create'CapabilitiesBacsDebitPayments option
        ///<summary>The bancontact_payments capability.</summary>
        [<Config.Form>]BancontactPayments: Create'CapabilitiesBancontactPayments option
        ///<summary>The bank_transfer_payments capability.</summary>
        [<Config.Form>]BankTransferPayments: Create'CapabilitiesBankTransferPayments option
        ///<summary>The billie_payments capability.</summary>
        [<Config.Form>]BilliePayments: Create'CapabilitiesBilliePayments option
        ///<summary>The blik_payments capability.</summary>
        [<Config.Form>]BlikPayments: Create'CapabilitiesBlikPayments option
        ///<summary>The boleto_payments capability.</summary>
        [<Config.Form>]BoletoPayments: Create'CapabilitiesBoletoPayments option
        ///<summary>The card_issuing capability.</summary>
        [<Config.Form>]CardIssuing: Create'CapabilitiesCardIssuing option
        ///<summary>The card_payments capability.</summary>
        [<Config.Form>]CardPayments: Create'CapabilitiesCardPayments option
        ///<summary>The cartes_bancaires_payments capability.</summary>
        [<Config.Form>]CartesBancairesPayments: Create'CapabilitiesCartesBancairesPayments option
        ///<summary>The cashapp_payments capability.</summary>
        [<Config.Form>]CashappPayments: Create'CapabilitiesCashappPayments option
        ///<summary>The crypto_payments capability.</summary>
        [<Config.Form>]CryptoPayments: Create'CapabilitiesCryptoPayments option
        ///<summary>The eps_payments capability.</summary>
        [<Config.Form>]EpsPayments: Create'CapabilitiesEpsPayments option
        ///<summary>The fpx_payments capability.</summary>
        [<Config.Form>]FpxPayments: Create'CapabilitiesFpxPayments option
        ///<summary>The gb_bank_transfer_payments capability.</summary>
        [<Config.Form>]GbBankTransferPayments: Create'CapabilitiesGbBankTransferPayments option
        ///<summary>The giropay_payments capability.</summary>
        [<Config.Form>]GiropayPayments: Create'CapabilitiesGiropayPayments option
        ///<summary>The grabpay_payments capability.</summary>
        [<Config.Form>]GrabpayPayments: Create'CapabilitiesGrabpayPayments option
        ///<summary>The ideal_payments capability.</summary>
        [<Config.Form>]IdealPayments: Create'CapabilitiesIdealPayments option
        ///<summary>The india_international_payments capability.</summary>
        [<Config.Form>]IndiaInternationalPayments: Create'CapabilitiesIndiaInternationalPayments option
        ///<summary>The jcb_payments capability.</summary>
        [<Config.Form>]JcbPayments: Create'CapabilitiesJcbPayments option
        ///<summary>The jp_bank_transfer_payments capability.</summary>
        [<Config.Form>]JpBankTransferPayments: Create'CapabilitiesJpBankTransferPayments option
        ///<summary>The kakao_pay_payments capability.</summary>
        [<Config.Form>]KakaoPayPayments: Create'CapabilitiesKakaoPayPayments option
        ///<summary>The klarna_payments capability.</summary>
        [<Config.Form>]KlarnaPayments: Create'CapabilitiesKlarnaPayments option
        ///<summary>The konbini_payments capability.</summary>
        [<Config.Form>]KonbiniPayments: Create'CapabilitiesKonbiniPayments option
        ///<summary>The kr_card_payments capability.</summary>
        [<Config.Form>]KrCardPayments: Create'CapabilitiesKrCardPayments option
        ///<summary>The legacy_payments capability.</summary>
        [<Config.Form>]LegacyPayments: Create'CapabilitiesLegacyPayments option
        ///<summary>The link_payments capability.</summary>
        [<Config.Form>]LinkPayments: Create'CapabilitiesLinkPayments option
        ///<summary>The mb_way_payments capability.</summary>
        [<Config.Form>]MbWayPayments: Create'CapabilitiesMbWayPayments option
        ///<summary>The mobilepay_payments capability.</summary>
        [<Config.Form>]MobilepayPayments: Create'CapabilitiesMobilepayPayments option
        ///<summary>The multibanco_payments capability.</summary>
        [<Config.Form>]MultibancoPayments: Create'CapabilitiesMultibancoPayments option
        ///<summary>The mx_bank_transfer_payments capability.</summary>
        [<Config.Form>]MxBankTransferPayments: Create'CapabilitiesMxBankTransferPayments option
        ///<summary>The naver_pay_payments capability.</summary>
        [<Config.Form>]NaverPayPayments: Create'CapabilitiesNaverPayPayments option
        ///<summary>The nz_bank_account_becs_debit_payments capability.</summary>
        [<Config.Form>]NzBankAccountBecsDebitPayments: Create'CapabilitiesNzBankAccountBecsDebitPayments option
        ///<summary>The oxxo_payments capability.</summary>
        [<Config.Form>]OxxoPayments: Create'CapabilitiesOxxoPayments option
        ///<summary>The p24_payments capability.</summary>
        [<Config.Form>]P24Payments: Create'CapabilitiesP24Payments option
        ///<summary>The pay_by_bank_payments capability.</summary>
        [<Config.Form>]PayByBankPayments: Create'CapabilitiesPayByBankPayments option
        ///<summary>The payco_payments capability.</summary>
        [<Config.Form>]PaycoPayments: Create'CapabilitiesPaycoPayments option
        ///<summary>The paynow_payments capability.</summary>
        [<Config.Form>]PaynowPayments: Create'CapabilitiesPaynowPayments option
        ///<summary>The payto_payments capability.</summary>
        [<Config.Form>]PaytoPayments: Create'CapabilitiesPaytoPayments option
        ///<summary>The pix_payments capability.</summary>
        [<Config.Form>]PixPayments: Create'CapabilitiesPixPayments option
        ///<summary>The promptpay_payments capability.</summary>
        [<Config.Form>]PromptpayPayments: Create'CapabilitiesPromptpayPayments option
        ///<summary>The revolut_pay_payments capability.</summary>
        [<Config.Form>]RevolutPayPayments: Create'CapabilitiesRevolutPayPayments option
        ///<summary>The samsung_pay_payments capability.</summary>
        [<Config.Form>]SamsungPayPayments: Create'CapabilitiesSamsungPayPayments option
        ///<summary>The satispay_payments capability.</summary>
        [<Config.Form>]SatispayPayments: Create'CapabilitiesSatispayPayments option
        ///<summary>The sepa_bank_transfer_payments capability.</summary>
        [<Config.Form>]SepaBankTransferPayments: Create'CapabilitiesSepaBankTransferPayments option
        ///<summary>The sepa_debit_payments capability.</summary>
        [<Config.Form>]SepaDebitPayments: Create'CapabilitiesSepaDebitPayments option
        ///<summary>The sofort_payments capability.</summary>
        [<Config.Form>]SofortPayments: Create'CapabilitiesSofortPayments option
        ///<summary>The sunbit_payments capability.</summary>
        [<Config.Form>]SunbitPayments: Create'CapabilitiesSunbitPayments option
        ///<summary>The swish_payments capability.</summary>
        [<Config.Form>]SwishPayments: Create'CapabilitiesSwishPayments option
        ///<summary>The tax_reporting_us_1099_k capability.</summary>
        [<Config.Form>]TaxReportingUs1099K: Create'CapabilitiesTaxReportingUs1099K option
        ///<summary>The tax_reporting_us_1099_misc capability.</summary>
        [<Config.Form>]TaxReportingUs1099Misc: Create'CapabilitiesTaxReportingUs1099Misc option
        ///<summary>The transfers capability.</summary>
        [<Config.Form>]Transfers: Create'CapabilitiesTransfers option
        ///<summary>The treasury capability.</summary>
        [<Config.Form>]Treasury: Create'CapabilitiesTreasury option
        ///<summary>The twint_payments capability.</summary>
        [<Config.Form>]TwintPayments: Create'CapabilitiesTwintPayments option
        ///<summary>The upi_payments capability.</summary>
        [<Config.Form>]UpiPayments: Create'CapabilitiesUpiPayments option
        ///<summary>The us_bank_account_ach_payments capability.</summary>
        [<Config.Form>]UsBankAccountAchPayments: Create'CapabilitiesUsBankAccountAchPayments option
        ///<summary>The us_bank_transfer_payments capability.</summary>
        [<Config.Form>]UsBankTransferPayments: Create'CapabilitiesUsBankTransferPayments option
        ///<summary>The zip_payments capability.</summary>
        [<Config.Form>]ZipPayments: Create'CapabilitiesZipPayments option
    }
    with
        static member New(?acssDebitPayments: Create'CapabilitiesAcssDebitPayments, ?mobilepayPayments: Create'CapabilitiesMobilepayPayments, ?multibancoPayments: Create'CapabilitiesMultibancoPayments, ?mxBankTransferPayments: Create'CapabilitiesMxBankTransferPayments, ?naverPayPayments: Create'CapabilitiesNaverPayPayments, ?nzBankAccountBecsDebitPayments: Create'CapabilitiesNzBankAccountBecsDebitPayments, ?oxxoPayments: Create'CapabilitiesOxxoPayments, ?p24Payments: Create'CapabilitiesP24Payments, ?payByBankPayments: Create'CapabilitiesPayByBankPayments, ?paycoPayments: Create'CapabilitiesPaycoPayments, ?paynowPayments: Create'CapabilitiesPaynowPayments, ?paytoPayments: Create'CapabilitiesPaytoPayments, ?pixPayments: Create'CapabilitiesPixPayments, ?promptpayPayments: Create'CapabilitiesPromptpayPayments, ?mbWayPayments: Create'CapabilitiesMbWayPayments, ?revolutPayPayments: Create'CapabilitiesRevolutPayPayments, ?satispayPayments: Create'CapabilitiesSatispayPayments, ?sepaBankTransferPayments: Create'CapabilitiesSepaBankTransferPayments, ?sepaDebitPayments: Create'CapabilitiesSepaDebitPayments, ?sofortPayments: Create'CapabilitiesSofortPayments, ?sunbitPayments: Create'CapabilitiesSunbitPayments, ?swishPayments: Create'CapabilitiesSwishPayments, ?taxReportingUs1099K: Create'CapabilitiesTaxReportingUs1099K, ?taxReportingUs1099Misc: Create'CapabilitiesTaxReportingUs1099Misc, ?transfers: Create'CapabilitiesTransfers, ?treasury: Create'CapabilitiesTreasury, ?twintPayments: Create'CapabilitiesTwintPayments, ?upiPayments: Create'CapabilitiesUpiPayments, ?usBankAccountAchPayments: Create'CapabilitiesUsBankAccountAchPayments, ?samsungPayPayments: Create'CapabilitiesSamsungPayPayments, ?linkPayments: Create'CapabilitiesLinkPayments, ?legacyPayments: Create'CapabilitiesLegacyPayments, ?krCardPayments: Create'CapabilitiesKrCardPayments, ?affirmPayments: Create'CapabilitiesAffirmPayments, ?afterpayClearpayPayments: Create'CapabilitiesAfterpayClearpayPayments, ?almaPayments: Create'CapabilitiesAlmaPayments, ?amazonPayPayments: Create'CapabilitiesAmazonPayPayments, ?appDistribution: Create'CapabilitiesAppDistribution, ?auBecsDebitPayments: Create'CapabilitiesAuBecsDebitPayments, ?bacsDebitPayments: Create'CapabilitiesBacsDebitPayments, ?bancontactPayments: Create'CapabilitiesBancontactPayments, ?bankTransferPayments: Create'CapabilitiesBankTransferPayments, ?billiePayments: Create'CapabilitiesBilliePayments, ?blikPayments: Create'CapabilitiesBlikPayments, ?boletoPayments: Create'CapabilitiesBoletoPayments, ?cardIssuing: Create'CapabilitiesCardIssuing, ?cardPayments: Create'CapabilitiesCardPayments, ?cartesBancairesPayments: Create'CapabilitiesCartesBancairesPayments, ?cashappPayments: Create'CapabilitiesCashappPayments, ?cryptoPayments: Create'CapabilitiesCryptoPayments, ?epsPayments: Create'CapabilitiesEpsPayments, ?fpxPayments: Create'CapabilitiesFpxPayments, ?gbBankTransferPayments: Create'CapabilitiesGbBankTransferPayments, ?giropayPayments: Create'CapabilitiesGiropayPayments, ?grabpayPayments: Create'CapabilitiesGrabpayPayments, ?idealPayments: Create'CapabilitiesIdealPayments, ?indiaInternationalPayments: Create'CapabilitiesIndiaInternationalPayments, ?jcbPayments: Create'CapabilitiesJcbPayments, ?jpBankTransferPayments: Create'CapabilitiesJpBankTransferPayments, ?kakaoPayPayments: Create'CapabilitiesKakaoPayPayments, ?klarnaPayments: Create'CapabilitiesKlarnaPayments, ?konbiniPayments: Create'CapabilitiesKonbiniPayments, ?usBankTransferPayments: Create'CapabilitiesUsBankTransferPayments, ?zipPayments: Create'CapabilitiesZipPayments) =
            {
                AcssDebitPayments = acssDebitPayments
                AffirmPayments = affirmPayments
                AfterpayClearpayPayments = afterpayClearpayPayments
                AlmaPayments = almaPayments
                AmazonPayPayments = amazonPayPayments
                AppDistribution = appDistribution
                AuBecsDebitPayments = auBecsDebitPayments
                BacsDebitPayments = bacsDebitPayments
                BancontactPayments = bancontactPayments
                BankTransferPayments = bankTransferPayments
                BilliePayments = billiePayments
                BlikPayments = blikPayments
                BoletoPayments = boletoPayments
                CardIssuing = cardIssuing
                CardPayments = cardPayments
                CartesBancairesPayments = cartesBancairesPayments
                CashappPayments = cashappPayments
                CryptoPayments = cryptoPayments
                EpsPayments = epsPayments
                FpxPayments = fpxPayments
                GbBankTransferPayments = gbBankTransferPayments
                GiropayPayments = giropayPayments
                GrabpayPayments = grabpayPayments
                IdealPayments = idealPayments
                IndiaInternationalPayments = indiaInternationalPayments
                JcbPayments = jcbPayments
                JpBankTransferPayments = jpBankTransferPayments
                KakaoPayPayments = kakaoPayPayments
                KlarnaPayments = klarnaPayments
                KonbiniPayments = konbiniPayments
                KrCardPayments = krCardPayments
                LegacyPayments = legacyPayments
                LinkPayments = linkPayments
                MbWayPayments = mbWayPayments
                MobilepayPayments = mobilepayPayments
                MultibancoPayments = multibancoPayments
                MxBankTransferPayments = mxBankTransferPayments
                NaverPayPayments = naverPayPayments
                NzBankAccountBecsDebitPayments = nzBankAccountBecsDebitPayments
                OxxoPayments = oxxoPayments
                P24Payments = p24Payments
                PayByBankPayments = payByBankPayments
                PaycoPayments = paycoPayments
                PaynowPayments = paynowPayments
                PaytoPayments = paytoPayments
                PixPayments = pixPayments
                PromptpayPayments = promptpayPayments
                RevolutPayPayments = revolutPayPayments
                SamsungPayPayments = samsungPayPayments
                SatispayPayments = satispayPayments
                SepaBankTransferPayments = sepaBankTransferPayments
                SepaDebitPayments = sepaDebitPayments
                SofortPayments = sofortPayments
                SunbitPayments = sunbitPayments
                SwishPayments = swishPayments
                TaxReportingUs1099K = taxReportingUs1099K
                TaxReportingUs1099Misc = taxReportingUs1099Misc
                Transfers = transfers
                Treasury = treasury
                TwintPayments = twintPayments
                UpiPayments = upiPayments
                UsBankAccountAchPayments = usBankAccountAchPayments
                UsBankTransferPayments = usBankTransferPayments
                ZipPayments = zipPayments
            }

    type Create'CompanyAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'CompanyAddressKana = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'CompanyAddressKanji = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'CompanyDirectorshipDeclaration = {
        ///<summary>The Unix timestamp marking when the directorship declaration attestation was made.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the directorship declaration attestation was made.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the directorship declaration attestation was made.</summary>
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'CompanyOwnershipDeclaration = {
        ///<summary>The Unix timestamp marking when the beneficial owner attestation was made.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the beneficial owner attestation was made.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the beneficial owner attestation was made.</summary>
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'CompanyRegistrationDateRegistrationDateSpecs = {
        ///<summary>The day of registration, between 1 and 31.</summary>
        [<Config.Form>]Day: int option
        ///<summary>The month of registration, between 1 and 12.</summary>
        [<Config.Form>]Month: int option
        ///<summary>The four-digit year of registration.</summary>
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'CompanyRepresentativeDeclaration = {
        ///<summary>The Unix timestamp marking when the representative declaration attestation was made.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the representative declaration attestation was made.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the representative declaration attestation was made.</summary>
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'CompanyVerificationDocument = {
        ///<summary>The back of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Back: string option
        ///<summary>The front of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'CompanyVerification = {
        ///<summary>A document verifying the business.</summary>
        [<Config.Form>]Document: Create'CompanyVerificationDocument option
    }
    with
        static member New(?document: Create'CompanyVerificationDocument) =
            {
                Document = document
            }

    type Create'CompanyOwnershipExemptionReason =
    | QualifiedEntityExceedsOwnershipThreshold
    | QualifiesAsFinancialInstitution

    type Create'CompanyStructure =
    | FreeZoneEstablishment
    | FreeZoneLlc
    | GovernmentInstrumentality
    | GovernmentalUnit
    | IncorporatedNonProfit
    | IncorporatedPartnership
    | LimitedLiabilityPartnership
    | Llc
    | MultiMemberLlc
    | PrivateCompany
    | PrivateCorporation
    | PrivatePartnership
    | PublicCompany
    | PublicCorporation
    | PublicPartnership
    | RegisteredCharity
    | SingleMemberLlc
    | SoleEstablishment
    | SoleProprietorship
    | TaxExemptGovernmentInstrumentality
    | UnincorporatedAssociation
    | UnincorporatedNonProfit
    | UnincorporatedPartnership

    type Create'Company = {
        ///<summary>The company's primary address.</summary>
        [<Config.Form>]Address: Create'CompanyAddress option
        ///<summary>The Kana variation of the company's primary address (Japan only).</summary>
        [<Config.Form>]AddressKana: Create'CompanyAddressKana option
        ///<summary>The Kanji variation of the company's primary address (Japan only).</summary>
        [<Config.Form>]AddressKanji: Create'CompanyAddressKanji option
        ///<summary>Whether the company's directors have been provided. Set this Boolean to `true` after creating all the company's directors with [the Persons API](/api/persons) for accounts with a `relationship.director` requirement. This value is not automatically set to `true` after creating directors, so it needs to be updated to indicate all directors have been provided.</summary>
        [<Config.Form>]DirectorsProvided: bool option
        ///<summary>This hash is used to attest that the directors information provided to Stripe is both current and correct.</summary>
        [<Config.Form>]DirectorshipDeclaration: Create'CompanyDirectorshipDeclaration option
        ///<summary>Whether the company's executives have been provided. Set this Boolean to `true` after creating all the company's executives with [the Persons API](/api/persons) for accounts with a `relationship.executive` requirement.</summary>
        [<Config.Form>]ExecutivesProvided: bool option
        ///<summary>The export license ID number of the company, also referred as Import Export Code (India only).</summary>
        [<Config.Form>]ExportLicenseId: string option
        ///<summary>The purpose code to use for export transactions (India only).</summary>
        [<Config.Form>]ExportPurposeCode: string option
        ///<summary>The company's legal name.</summary>
        [<Config.Form>]Name: string option
        ///<summary>The Kana variation of the company's legal name (Japan only).</summary>
        [<Config.Form>]NameKana: string option
        ///<summary>The Kanji variation of the company's legal name (Japan only).</summary>
        [<Config.Form>]NameKanji: string option
        ///<summary>Whether the company's owners have been provided. Set this Boolean to `true` after creating all the company's owners with [the Persons API](/api/persons) for accounts with a `relationship.owner` requirement.</summary>
        [<Config.Form>]OwnersProvided: bool option
        ///<summary>This hash is used to attest that the beneficial owner information provided to Stripe is both current and correct.</summary>
        [<Config.Form>]OwnershipDeclaration: Create'CompanyOwnershipDeclaration option
        ///<summary>This value is used to determine if a business is exempt from providing ultimate beneficial owners. See [this support article](https://support.stripe.com/questions/exemption-from-providing-ownership-details) and [changelog](https://docs.stripe.com/changelog/acacia/2025-01-27/ownership-exemption-reason-accounts-api) for more details.</summary>
        [<Config.Form>]OwnershipExemptionReason: Create'CompanyOwnershipExemptionReason option
        ///<summary>The company's phone number (used for verification).</summary>
        [<Config.Form>]Phone: string option
        ///<summary>When the business was incorporated or registered.</summary>
        [<Config.Form>]RegistrationDate: Choice<Create'CompanyRegistrationDateRegistrationDateSpecs,string> option
        ///<summary>The identification number given to a company when it is registered or incorporated, if distinct from the identification number used for filing taxes. (Examples are the CIN for companies and LLP IN for partnerships in India, and the Company Registration Number in Hong Kong).</summary>
        [<Config.Form>]RegistrationNumber: string option
        ///<summary>This hash is used to attest that the representative is authorized to act as the representative of their legal entity.</summary>
        [<Config.Form>]RepresentativeDeclaration: Create'CompanyRepresentativeDeclaration option
        ///<summary>The category identifying the legal structure of the company or legal entity. See [Business structure](/connect/identity-verification#business-structure) for more details. Pass an empty string to unset this value.</summary>
        [<Config.Form>]Structure: Create'CompanyStructure option
        ///<summary>The business ID number of the company, as appropriate for the company’s country. (Examples are an Employer ID Number in the U.S., a Business Number in Canada, or a Company Number in the UK.)</summary>
        [<Config.Form>]TaxId: string option
        ///<summary>The jurisdiction in which the `tax_id` is registered (Germany-based companies only).</summary>
        [<Config.Form>]TaxIdRegistrar: string option
        ///<summary>The VAT number of the company.</summary>
        [<Config.Form>]VatId: string option
        ///<summary>Information on the verification state of the company.</summary>
        [<Config.Form>]Verification: Create'CompanyVerification option
    }
    with
        static member New(?address: Create'CompanyAddress, ?taxIdRegistrar: string, ?taxId: string, ?structure: Create'CompanyStructure, ?representativeDeclaration: Create'CompanyRepresentativeDeclaration, ?registrationNumber: string, ?registrationDate: Choice<Create'CompanyRegistrationDateRegistrationDateSpecs,string>, ?phone: string, ?ownershipExemptionReason: Create'CompanyOwnershipExemptionReason, ?ownershipDeclaration: Create'CompanyOwnershipDeclaration, ?vatId: string, ?ownersProvided: bool, ?nameKana: string, ?name: string, ?exportPurposeCode: string, ?exportLicenseId: string, ?executivesProvided: bool, ?directorshipDeclaration: Create'CompanyDirectorshipDeclaration, ?directorsProvided: bool, ?addressKanji: Create'CompanyAddressKanji, ?addressKana: Create'CompanyAddressKana, ?nameKanji: string, ?verification: Create'CompanyVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                DirectorsProvided = directorsProvided
                DirectorshipDeclaration = directorshipDeclaration
                ExecutivesProvided = executivesProvided
                ExportLicenseId = exportLicenseId
                ExportPurposeCode = exportPurposeCode
                Name = name
                NameKana = nameKana
                NameKanji = nameKanji
                OwnersProvided = ownersProvided
                OwnershipDeclaration = ownershipDeclaration
                OwnershipExemptionReason = ownershipExemptionReason
                Phone = phone
                RegistrationDate = registrationDate
                RegistrationNumber = registrationNumber
                RepresentativeDeclaration = representativeDeclaration
                Structure = structure
                TaxId = taxId
                TaxIdRegistrar = taxIdRegistrar
                VatId = vatId
                Verification = verification
            }

    type Create'ControllerFeesPayer =
    | Account
    | Application

    type Create'ControllerFees = {
        ///<summary>A value indicating the responsible payer of Stripe fees on this account. Defaults to `account`. Learn more about [fee behavior on connected accounts](https://docs.stripe.com/connect/direct-charges-fee-payer-behavior).</summary>
        [<Config.Form>]Payer: Create'ControllerFeesPayer option
    }
    with
        static member New(?payer: Create'ControllerFeesPayer) =
            {
                Payer = payer
            }

    type Create'ControllerLossesPayments =
    | Application
    | Stripe

    type Create'ControllerLosses = {
        ///<summary>A value indicating who is liable when this account can't pay back negative balances resulting from payments. Defaults to `stripe`.</summary>
        [<Config.Form>]Payments: Create'ControllerLossesPayments option
    }
    with
        static member New(?payments: Create'ControllerLossesPayments) =
            {
                Payments = payments
            }

    type Create'ControllerStripeDashboardType =
    | Express
    | Full
    | None'

    type Create'ControllerStripeDashboard = {
        ///<summary>Whether this account should have access to the full Stripe Dashboard (`full`), to the Express Dashboard (`express`), or to no Stripe-hosted dashboard (`none`). Defaults to `full`.</summary>
        [<Config.Form>]Type: Create'ControllerStripeDashboardType option
    }
    with
        static member New(?type': Create'ControllerStripeDashboardType) =
            {
                Type = type'
            }

    type Create'ControllerRequirementCollection =
    | Application
    | Stripe

    type Create'Controller = {
        ///<summary>A hash of configuration for who pays Stripe fees for product usage on this account.</summary>
        [<Config.Form>]Fees: Create'ControllerFees option
        ///<summary>A hash of configuration for products that have negative balance liability, and whether Stripe or a Connect application is responsible for them.</summary>
        [<Config.Form>]Losses: Create'ControllerLosses option
        ///<summary>A value indicating responsibility for collecting updated information when requirements on the account are due or change. Defaults to `stripe`.</summary>
        [<Config.Form>]RequirementCollection: Create'ControllerRequirementCollection option
        ///<summary>A hash of configuration for Stripe-hosted dashboards.</summary>
        [<Config.Form>]StripeDashboard: Create'ControllerStripeDashboard option
    }
    with
        static member New(?fees: Create'ControllerFees, ?losses: Create'ControllerLosses, ?requirementCollection: Create'ControllerRequirementCollection, ?stripeDashboard: Create'ControllerStripeDashboard) =
            {
                Fees = fees
                Losses = losses
                RequirementCollection = requirementCollection
                StripeDashboard = stripeDashboard
            }

    type Create'DocumentsBankAccountOwnershipVerification = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'DocumentsCompanyLicense = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'DocumentsCompanyMemorandumOfAssociation = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'DocumentsCompanyMinisterialDecree = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'DocumentsCompanyRegistrationVerification = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'DocumentsCompanyTaxIdVerification = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'DocumentsProofOfAddress = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Create'DocumentsProofOfRegistrationSigner = {
        ///<summary>The token of the person signing the document, if applicable.</summary>
        [<Config.Form>]Person: string option
    }
    with
        static member New(?person: string) =
            {
                Person = person
            }

    type Create'DocumentsProofOfRegistration = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
        ///<summary>Information regarding the person signing the document if applicable.</summary>
        [<Config.Form>]Signer: Create'DocumentsProofOfRegistrationSigner option
    }
    with
        static member New(?files: string list, ?signer: Create'DocumentsProofOfRegistrationSigner) =
            {
                Files = files
                Signer = signer
            }

    type Create'DocumentsProofOfUltimateBeneficialOwnershipSigner = {
        ///<summary>The token of the person signing the document, if applicable.</summary>
        [<Config.Form>]Person: string option
    }
    with
        static member New(?person: string) =
            {
                Person = person
            }

    type Create'DocumentsProofOfUltimateBeneficialOwnership = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
        ///<summary>Information regarding the person signing the document if applicable.</summary>
        [<Config.Form>]Signer: Create'DocumentsProofOfUltimateBeneficialOwnershipSigner option
    }
    with
        static member New(?files: string list, ?signer: Create'DocumentsProofOfUltimateBeneficialOwnershipSigner) =
            {
                Files = files
                Signer = signer
            }

    type Create'Documents = {
        ///<summary>One or more documents that support the [Bank account ownership verification](https://support.stripe.com/questions/bank-account-ownership-verification) requirement. Must be a document associated with the account’s primary active bank account that displays the last 4 digits of the account number, either a statement or a check.</summary>
        [<Config.Form>]BankAccountOwnershipVerification: Create'DocumentsBankAccountOwnershipVerification option
        ///<summary>One or more documents that demonstrate proof of a company's license to operate.</summary>
        [<Config.Form>]CompanyLicense: Create'DocumentsCompanyLicense option
        ///<summary>One or more documents showing the company's Memorandum of Association.</summary>
        [<Config.Form>]CompanyMemorandumOfAssociation: Create'DocumentsCompanyMemorandumOfAssociation option
        ///<summary>(Certain countries only) One or more documents showing the ministerial decree legalizing the company's establishment.</summary>
        [<Config.Form>]CompanyMinisterialDecree: Create'DocumentsCompanyMinisterialDecree option
        ///<summary>One or more documents that demonstrate proof of a company's registration with the appropriate local authorities.</summary>
        [<Config.Form>]CompanyRegistrationVerification: Create'DocumentsCompanyRegistrationVerification option
        ///<summary>One or more documents that demonstrate proof of a company's tax ID.</summary>
        [<Config.Form>]CompanyTaxIdVerification: Create'DocumentsCompanyTaxIdVerification option
        ///<summary>One or more documents that demonstrate proof of address.</summary>
        [<Config.Form>]ProofOfAddress: Create'DocumentsProofOfAddress option
        ///<summary>One or more documents showing the company’s proof of registration with the national business registry.</summary>
        [<Config.Form>]ProofOfRegistration: Create'DocumentsProofOfRegistration option
        ///<summary>One or more documents that demonstrate proof of ultimate beneficial ownership.</summary>
        [<Config.Form>]ProofOfUltimateBeneficialOwnership: Create'DocumentsProofOfUltimateBeneficialOwnership option
    }
    with
        static member New(?bankAccountOwnershipVerification: Create'DocumentsBankAccountOwnershipVerification, ?companyLicense: Create'DocumentsCompanyLicense, ?companyMemorandumOfAssociation: Create'DocumentsCompanyMemorandumOfAssociation, ?companyMinisterialDecree: Create'DocumentsCompanyMinisterialDecree, ?companyRegistrationVerification: Create'DocumentsCompanyRegistrationVerification, ?companyTaxIdVerification: Create'DocumentsCompanyTaxIdVerification, ?proofOfAddress: Create'DocumentsProofOfAddress, ?proofOfRegistration: Create'DocumentsProofOfRegistration, ?proofOfUltimateBeneficialOwnership: Create'DocumentsProofOfUltimateBeneficialOwnership) =
            {
                BankAccountOwnershipVerification = bankAccountOwnershipVerification
                CompanyLicense = companyLicense
                CompanyMemorandumOfAssociation = companyMemorandumOfAssociation
                CompanyMinisterialDecree = companyMinisterialDecree
                CompanyRegistrationVerification = companyRegistrationVerification
                CompanyTaxIdVerification = companyTaxIdVerification
                ProofOfAddress = proofOfAddress
                ProofOfRegistration = proofOfRegistration
                ProofOfUltimateBeneficialOwnership = proofOfUltimateBeneficialOwnership
            }

    type Create'Groups = {
        ///<summary>The group the account is in to determine their payments pricing, and null if the account is on customized pricing. [See the Platform pricing tool documentation](https://docs.stripe.com/connect/platform-pricing-tools) for details.</summary>
        [<Config.Form>]PaymentsPricing: Choice<string,string> option
    }
    with
        static member New(?paymentsPricing: Choice<string,string>) =
            {
                PaymentsPricing = paymentsPricing
            }

    type Create'IndividualAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'IndividualAddressKana = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'IndividualAddressKanji = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'IndividualDobDateOfBirthSpecs = {
        ///<summary>The day of birth, between 1 and 31.</summary>
        [<Config.Form>]Day: int option
        ///<summary>The month of birth, between 1 and 12.</summary>
        [<Config.Form>]Month: int option
        ///<summary>The four-digit year of birth.</summary>
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'IndividualRegisteredAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'IndividualRelationship = {
        ///<summary>Whether the person is a director of the account's legal entity. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.</summary>
        [<Config.Form>]Director: bool option
        ///<summary>Whether the person has significant responsibility to control, manage, or direct the organization.</summary>
        [<Config.Form>]Executive: bool option
        ///<summary>Whether the person is an owner of the account’s legal entity.</summary>
        [<Config.Form>]Owner: bool option
        ///<summary>The percent owned by the person of the account's legal entity.</summary>
        [<Config.Form>]PercentOwnership: Choice<decimal,string> option
        ///<summary>The person's title (e.g., CEO, Support Engineer).</summary>
        [<Config.Form>]Title: string option
    }
    with
        static member New(?director: bool, ?executive: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?title: string) =
            {
                Director = director
                Executive = executive
                Owner = owner
                PercentOwnership = percentOwnership
                Title = title
            }

    type Create'IndividualVerificationAdditionalDocument = {
        ///<summary>The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Back: string option
        ///<summary>The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'IndividualVerificationDocument = {
        ///<summary>The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Back: string option
        ///<summary>The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'IndividualVerification = {
        ///<summary>A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.</summary>
        [<Config.Form>]AdditionalDocument: Create'IndividualVerificationAdditionalDocument option
        ///<summary>An identifying document, either a passport or local ID card.</summary>
        [<Config.Form>]Document: Create'IndividualVerificationDocument option
    }
    with
        static member New(?additionalDocument: Create'IndividualVerificationAdditionalDocument, ?document: Create'IndividualVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Create'IndividualPoliticalExposure =
    | Existing
    | None'

    type Create'Individual = {
        ///<summary>The individual's primary address.</summary>
        [<Config.Form>]Address: Create'IndividualAddress option
        ///<summary>The Kana variation of the individual's primary address (Japan only).</summary>
        [<Config.Form>]AddressKana: Create'IndividualAddressKana option
        ///<summary>The Kanji variation of the individual's primary address (Japan only).</summary>
        [<Config.Form>]AddressKanji: Create'IndividualAddressKanji option
        ///<summary>The individual's date of birth.</summary>
        [<Config.Form>]Dob: Choice<Create'IndividualDobDateOfBirthSpecs,string> option
        ///<summary>The individual's email address.</summary>
        [<Config.Form>]Email: string option
        ///<summary>The individual's first name.</summary>
        [<Config.Form>]FirstName: string option
        ///<summary>The Kana variation of the individual's first name (Japan only).</summary>
        [<Config.Form>]FirstNameKana: string option
        ///<summary>The Kanji variation of the individual's first name (Japan only).</summary>
        [<Config.Form>]FirstNameKanji: string option
        ///<summary>A list of alternate names or aliases that the individual is known by.</summary>
        [<Config.Form>]FullNameAliases: Choice<string list,string> option
        ///<summary>The individual's gender</summary>
        [<Config.Form>]Gender: string option
        ///<summary>The government-issued ID number of the individual, as appropriate for the representative's country. (Examples are a Social Security Number in the U.S., or a Social Insurance Number in Canada). Instead of the number itself, you can also provide a [PII token created with Stripe.js](/js/tokens/create_token?type=pii).</summary>
        [<Config.Form>]IdNumber: string option
        ///<summary>The government-issued secondary ID number of the individual, as appropriate for the representative's country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token created with Stripe.js](/js/tokens/create_token?type=pii).</summary>
        [<Config.Form>]IdNumberSecondary: string option
        ///<summary>The individual's last name.</summary>
        [<Config.Form>]LastName: string option
        ///<summary>The Kana variation of the individual's last name (Japan only).</summary>
        [<Config.Form>]LastNameKana: string option
        ///<summary>The Kanji variation of the individual's last name (Japan only).</summary>
        [<Config.Form>]LastNameKanji: string option
        ///<summary>The individual's maiden name.</summary>
        [<Config.Form>]MaidenName: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The individual's phone number.</summary>
        [<Config.Form>]Phone: string option
        ///<summary>Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.</summary>
        [<Config.Form>]PoliticalExposure: Create'IndividualPoliticalExposure option
        ///<summary>The individual's registered address.</summary>
        [<Config.Form>]RegisteredAddress: Create'IndividualRegisteredAddress option
        ///<summary>Describes the person’s relationship to the account.</summary>
        [<Config.Form>]Relationship: Create'IndividualRelationship option
        ///<summary>The last four digits of the individual's Social Security Number (U.S. only).</summary>
        [<Config.Form>]SsnLast4: string option
        ///<summary>The individual's verification document information.</summary>
        [<Config.Form>]Verification: Create'IndividualVerification option
    }
    with
        static member New(?address: Create'IndividualAddress, ?relationship: Create'IndividualRelationship, ?registeredAddress: Create'IndividualRegisteredAddress, ?politicalExposure: Create'IndividualPoliticalExposure, ?phone: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?ssnLast4: string, ?idNumberSecondary: string, ?gender: string, ?fullNameAliases: Choice<string list,string>, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?dob: Choice<Create'IndividualDobDateOfBirthSpecs,string>, ?addressKanji: Create'IndividualAddressKanji, ?addressKana: Create'IndividualAddressKana, ?idNumber: string, ?verification: Create'IndividualVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Email = email
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                FullNameAliases = fullNameAliases
                Gender = gender
                IdNumber = idNumber
                IdNumberSecondary = idNumberSecondary
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                Phone = phone
                PoliticalExposure = politicalExposure
                RegisteredAddress = registeredAddress
                Relationship = relationship
                SsnLast4 = ssnLast4
                Verification = verification
            }

    type Create'SettingsBacsDebitPayments = {
        ///<summary>The Bacs Direct Debit Display Name for this account. For payments made with Bacs Direct Debit, this name appears on the mandate as the statement descriptor. Mobile banking apps display it as the name of the business. To use custom branding, set the Bacs Direct Debit Display Name during or right after creation. Custom branding incurs an additional monthly fee for the platform. If you don't set the display name before requesting Bacs capability, it's automatically set as "Stripe" and the account is onboarded to Stripe branding, which is free.</summary>
        [<Config.Form>]DisplayName: string option
    }
    with
        static member New(?displayName: string) =
            {
                DisplayName = displayName
            }

    type Create'SettingsBranding = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) An icon for the account. Must be square and at least 128px x 128px.</summary>
        [<Config.Form>]Icon: string option
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A logo for the account that will be used in Checkout instead of the icon and without the account's name next to it if provided. Must be at least 128px x 128px.</summary>
        [<Config.Form>]Logo: string option
        ///<summary>A CSS hex color value representing the primary branding color for this account.</summary>
        [<Config.Form>]PrimaryColor: string option
        ///<summary>A CSS hex color value representing the secondary branding color for this account.</summary>
        [<Config.Form>]SecondaryColor: string option
    }
    with
        static member New(?icon: string, ?logo: string, ?primaryColor: string, ?secondaryColor: string) =
            {
                Icon = icon
                Logo = logo
                PrimaryColor = primaryColor
                SecondaryColor = secondaryColor
            }

    type Create'SettingsCardIssuingTosAcceptance = {
        ///<summary>The Unix timestamp marking when the account representative accepted the service agreement.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the account representative accepted the service agreement.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the account representative accepted the service agreement.</summary>
        [<Config.Form>]UserAgent: Choice<string,string> option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'SettingsCardIssuing = {
        ///<summary>Details on the account's acceptance of the [Stripe Issuing Terms and Disclosures](/issuing/connect/tos_acceptance).</summary>
        [<Config.Form>]TosAcceptance: Create'SettingsCardIssuingTosAcceptance option
    }
    with
        static member New(?tosAcceptance: Create'SettingsCardIssuingTosAcceptance) =
            {
                TosAcceptance = tosAcceptance
            }

    type Create'SettingsCardPaymentsDeclineOn = {
        ///<summary>Whether Stripe automatically declines charges with an incorrect ZIP or postal code. This setting only applies when a ZIP or postal code is provided and they fail bank verification.</summary>
        [<Config.Form>]AvsFailure: bool option
        ///<summary>Whether Stripe automatically declines charges with an incorrect CVC. This setting only applies when a CVC is provided and it fails bank verification.</summary>
        [<Config.Form>]CvcFailure: bool option
    }
    with
        static member New(?avsFailure: bool, ?cvcFailure: bool) =
            {
                AvsFailure = avsFailure
                CvcFailure = cvcFailure
            }

    type Create'SettingsCardPayments = {
        ///<summary>Automatically declines certain charge types regardless of whether the card issuer accepted or declined the charge.</summary>
        [<Config.Form>]DeclineOn: Create'SettingsCardPaymentsDeclineOn option
        ///<summary>The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge. `statement_descriptor_prefix` is useful for maximizing descriptor space for the dynamic portion.</summary>
        [<Config.Form>]StatementDescriptorPrefix: string option
        ///<summary>The Kana variation of the default text that appears on credit card statements when a charge is made (Japan only). This field prefixes any dynamic `statement_descriptor_suffix_kana` specified on the charge. `statement_descriptor_prefix_kana` is useful for maximizing descriptor space for the dynamic portion.</summary>
        [<Config.Form>]StatementDescriptorPrefixKana: Choice<string,string> option
        ///<summary>The Kanji variation of the default text that appears on credit card statements when a charge is made (Japan only). This field prefixes any dynamic `statement_descriptor_suffix_kanji` specified on the charge. `statement_descriptor_prefix_kanji` is useful for maximizing descriptor space for the dynamic portion.</summary>
        [<Config.Form>]StatementDescriptorPrefixKanji: Choice<string,string> option
    }
    with
        static member New(?declineOn: Create'SettingsCardPaymentsDeclineOn, ?statementDescriptorPrefix: string, ?statementDescriptorPrefixKana: Choice<string,string>, ?statementDescriptorPrefixKanji: Choice<string,string>) =
            {
                DeclineOn = declineOn
                StatementDescriptorPrefix = statementDescriptorPrefix
                StatementDescriptorPrefixKana = statementDescriptorPrefixKana
                StatementDescriptorPrefixKanji = statementDescriptorPrefixKanji
            }

    type Create'SettingsInvoicesHostedPaymentMethodSave =
    | Always
    | Never
    | Offer

    type Create'SettingsInvoices = {
        ///<summary>Whether to save the payment method after a payment is completed for a one-time invoice or a subscription invoice when the customer already has a default payment method on the hosted invoice page.</summary>
        [<Config.Form>]HostedPaymentMethodSave: Create'SettingsInvoicesHostedPaymentMethodSave option
    }
    with
        static member New(?hostedPaymentMethodSave: Create'SettingsInvoicesHostedPaymentMethodSave) =
            {
                HostedPaymentMethodSave = hostedPaymentMethodSave
            }

    type Create'SettingsPayments = {
        ///<summary>The default text that appears on statements for non-card charges outside of Japan. For card charges, if you don't set a `statement_descriptor_prefix`, this text is also used as the statement descriptor prefix. In that case, if concatenating the statement descriptor suffix causes the combined statement descriptor to exceed 22 characters, we truncate the `statement_descriptor` text to limit the full descriptor to 22 characters. For more information about statement descriptors and their requirements, see the [account settings documentation](https://docs.stripe.com/get-started/account/statement-descriptors).</summary>
        [<Config.Form>]StatementDescriptor: string option
        ///<summary>The Kana variation of `statement_descriptor` used for charges in Japan. Japanese statement descriptors have [special requirements](https://docs.stripe.com/get-started/account/statement-descriptors#set-japanese-statement-descriptors).</summary>
        [<Config.Form>]StatementDescriptorKana: string option
        ///<summary>The Kanji variation of `statement_descriptor` used for charges in Japan. Japanese statement descriptors have [special requirements](https://docs.stripe.com/get-started/account/statement-descriptors#set-japanese-statement-descriptors).</summary>
        [<Config.Form>]StatementDescriptorKanji: string option
    }
    with
        static member New(?statementDescriptor: string, ?statementDescriptorKana: string, ?statementDescriptorKanji: string) =
            {
                StatementDescriptor = statementDescriptor
                StatementDescriptorKana = statementDescriptorKana
                StatementDescriptorKanji = statementDescriptorKanji
            }

    type Create'SettingsPayoutsScheduleDelayDays =
    | Minimum

    type Create'SettingsPayoutsScheduleWeeklyPayoutDays =
    | Friday
    | Monday
    | Thursday
    | Tuesday
    | Wednesday

    type Create'SettingsPayoutsScheduleInterval =
    | Daily
    | Manual
    | Monthly
    | Weekly

    type Create'SettingsPayoutsScheduleWeeklyAnchor =
    | Friday
    | Monday
    | Saturday
    | Sunday
    | Thursday
    | Tuesday
    | Wednesday

    type Create'SettingsPayoutsSchedule = {
        ///<summary>The number of days charge funds are held before being paid out. May also be set to `minimum`, representing the lowest available value for the account country. Default is `minimum`. The `delay_days` parameter remains at the last configured value if `interval` is `manual`. [Learn more about controlling payout delay days](/connect/manage-payout-schedule).</summary>
        [<Config.Form>]DelayDays: Choice<Create'SettingsPayoutsScheduleDelayDays,int> option
        ///<summary>How frequently available funds are paid out. One of: `daily`, `manual`, `weekly`, or `monthly`. Default is `daily`.</summary>
        [<Config.Form>]Interval: Create'SettingsPayoutsScheduleInterval option
        ///<summary>The day of the month when available funds are paid out, specified as a number between 1--31. Payouts nominally scheduled between the 29th and 31st of the month are instead sent on the last day of a shorter month. Required and applicable only if `interval` is `monthly`.</summary>
        [<Config.Form>]MonthlyAnchor: int option
        ///<summary>The days of the month when available funds are paid out, specified as an array of numbers between 1--31. Payouts nominally scheduled between the 29th and 31st of the month are instead sent on the last day of a shorter month. Required and applicable only if `interval` is `monthly` and `monthly_anchor` is not set.</summary>
        [<Config.Form>]MonthlyPayoutDays: int list option
        ///<summary>The day of the week when available funds are paid out, specified as `monday`, `tuesday`, etc. Required and applicable only if `interval` is `weekly`.</summary>
        [<Config.Form>]WeeklyAnchor: Create'SettingsPayoutsScheduleWeeklyAnchor option
        ///<summary>The days of the week when available funds are paid out, specified as an array, e.g., [`monday`, `tuesday`]. Required and applicable only if `interval` is `weekly`.</summary>
        [<Config.Form>]WeeklyPayoutDays: Create'SettingsPayoutsScheduleWeeklyPayoutDays list option
    }
    with
        static member New(?delayDays: Choice<Create'SettingsPayoutsScheduleDelayDays,int>, ?interval: Create'SettingsPayoutsScheduleInterval, ?monthlyAnchor: int, ?monthlyPayoutDays: int list, ?weeklyAnchor: Create'SettingsPayoutsScheduleWeeklyAnchor, ?weeklyPayoutDays: Create'SettingsPayoutsScheduleWeeklyPayoutDays list) =
            {
                DelayDays = delayDays
                Interval = interval
                MonthlyAnchor = monthlyAnchor
                MonthlyPayoutDays = monthlyPayoutDays
                WeeklyAnchor = weeklyAnchor
                WeeklyPayoutDays = weeklyPayoutDays
            }

    type Create'SettingsPayouts = {
        ///<summary>A Boolean indicating whether Stripe should try to reclaim negative balances from an attached bank account. For details, see [Understanding Connect Account Balances](/connect/account-balances).</summary>
        [<Config.Form>]DebitNegativeBalances: bool option
        ///<summary>Details on when funds from charges are available, and when they are paid out to an external account. For details, see our [Setting Bank and Debit Card Payouts](/connect/bank-transfers#payout-information) documentation.</summary>
        [<Config.Form>]Schedule: Create'SettingsPayoutsSchedule option
        ///<summary>The text that appears on the bank account statement for payouts. If not set, this defaults to the platform's bank descriptor as set in the Dashboard.</summary>
        [<Config.Form>]StatementDescriptor: string option
    }
    with
        static member New(?debitNegativeBalances: bool, ?schedule: Create'SettingsPayoutsSchedule, ?statementDescriptor: string) =
            {
                DebitNegativeBalances = debitNegativeBalances
                Schedule = schedule
                StatementDescriptor = statementDescriptor
            }

    type Create'SettingsTreasuryTosAcceptance = {
        ///<summary>The Unix timestamp marking when the account representative accepted the service agreement.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the account representative accepted the service agreement.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the account representative accepted the service agreement.</summary>
        [<Config.Form>]UserAgent: Choice<string,string> option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'SettingsTreasury = {
        ///<summary>Details on the account's acceptance of the Stripe Treasury Services Agreement.</summary>
        [<Config.Form>]TosAcceptance: Create'SettingsTreasuryTosAcceptance option
    }
    with
        static member New(?tosAcceptance: Create'SettingsTreasuryTosAcceptance) =
            {
                TosAcceptance = tosAcceptance
            }

    type Create'Settings = {
        ///<summary>Settings specific to Bacs Direct Debit.</summary>
        [<Config.Form>]BacsDebitPayments: Create'SettingsBacsDebitPayments option
        ///<summary>Settings used to apply the account's branding to email receipts, invoices, Checkout, and other products.</summary>
        [<Config.Form>]Branding: Create'SettingsBranding option
        ///<summary>Settings specific to the account's use of the Card Issuing product.</summary>
        [<Config.Form>]CardIssuing: Create'SettingsCardIssuing option
        ///<summary>Settings specific to card charging on the account.</summary>
        [<Config.Form>]CardPayments: Create'SettingsCardPayments option
        ///<summary>Settings specific to the account’s use of Invoices.</summary>
        [<Config.Form>]Invoices: Create'SettingsInvoices option
        ///<summary>Settings that apply across payment methods for charging on the account.</summary>
        [<Config.Form>]Payments: Create'SettingsPayments option
        ///<summary>Settings specific to the account's payouts.</summary>
        [<Config.Form>]Payouts: Create'SettingsPayouts option
        ///<summary>Settings specific to the account's Treasury FinancialAccounts.</summary>
        [<Config.Form>]Treasury: Create'SettingsTreasury option
    }
    with
        static member New(?bacsDebitPayments: Create'SettingsBacsDebitPayments, ?branding: Create'SettingsBranding, ?cardIssuing: Create'SettingsCardIssuing, ?cardPayments: Create'SettingsCardPayments, ?invoices: Create'SettingsInvoices, ?payments: Create'SettingsPayments, ?payouts: Create'SettingsPayouts, ?treasury: Create'SettingsTreasury) =
            {
                BacsDebitPayments = bacsDebitPayments
                Branding = branding
                CardIssuing = cardIssuing
                CardPayments = cardPayments
                Invoices = invoices
                Payments = payments
                Payouts = payouts
                Treasury = treasury
            }

    type Create'TosAcceptance = {
        ///<summary>The Unix timestamp marking when the account representative accepted their service agreement.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the account representative accepted their service agreement.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user's service agreement type.</summary>
        [<Config.Form>]ServiceAgreement: string option
        ///<summary>The user agent of the browser from which the account representative accepted their service agreement.</summary>
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?serviceAgreement: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                ServiceAgreement = serviceAgreement
                UserAgent = userAgent
            }

    type Create'BusinessType =
    | Company
    | GovernmentEntity
    | Individual
    | NonProfit

    type Create'Type =
    | Custom
    | Express
    | Standard

    type CreateOptions = {
        ///<summary>An [account token](https://api.stripe.com#create_account_token), used to securely provide details to the account.</summary>
        [<Config.Form>]AccountToken: string option
        ///<summary>Business information about the account.</summary>
        [<Config.Form>]BusinessProfile: Create'BusinessProfile option
        ///<summary>The business type. Once you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.</summary>
        [<Config.Form>]BusinessType: Create'BusinessType option
        ///<summary>Each key of the dictionary represents a capability, and each capability
        ///maps to its settings (for example, whether it has been requested or not). Each
        ///capability is inactive until you have provided its specific
        ///requirements and Stripe has verified them. An account might have some
        ///of its requested capabilities be active and some be inactive.
        ///Required when [account.controller.stripe_dashboard.type](/api/accounts/create#create_account-controller-dashboard-type)
        ///is `none`, which includes Custom accounts.</summary>
        [<Config.Form>]Capabilities: Create'Capabilities option
        ///<summary>Information about the company or business. This field is available for any `business_type`. Once you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.</summary>
        [<Config.Form>]Company: Create'Company option
        ///<summary>A hash of configuration describing the account controller's attributes.</summary>
        [<Config.Form>]Controller: Create'Controller option
        ///<summary>The country in which the account holder resides, or in which the business is legally established. This should be an ISO 3166-1 alpha-2 country code. For example, if you are in the United States and the business for which you're creating an account is legally represented in Canada, you would use `CA` as the country for the account being created. Available countries include [Stripe's global markets](https://stripe.com/global) as well as countries where [cross-border payouts](https://stripe.com/docs/connect/cross-border-payouts) are supported.</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Three-letter ISO currency code representing the default currency for the account. This must be a currency that [Stripe supports in the account's country](https://docs.stripe.com/payouts).</summary>
        [<Config.Form>]DefaultCurrency: IsoTypes.IsoCurrencyCode option
        ///<summary>Documents that may be submitted to satisfy various informational requests.</summary>
        [<Config.Form>]Documents: Create'Documents option
        ///<summary>The email address of the account holder. This is only to make the account easier to identify to you. If [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts, Stripe doesn't email the account without your consent.</summary>
        [<Config.Form>]Email: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A card or bank account to attach to the account for receiving [payouts](/connect/bank-debit-card-payouts) (you won’t be able to use it for top-ups). You can provide either a token, like the ones returned by [Stripe.js](/js), or a dictionary, as documented in the `external_account` parameter for [bank account](/api#account_create_bank_account) creation. <br><br>By default, providing an external account sets it as the new default external account for its currency, and deletes the old default if one exists. To add additional external accounts without replacing the existing default for the currency, use the [bank account](/api#account_create_bank_account) or [card creation](/api#account_create_card) APIs. After you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.</summary>
        [<Config.Form>]ExternalAccount: string option
        ///<summary>A hash of account group type to tokens. These are account groups this account should be added to.</summary>
        [<Config.Form>]Groups: Create'Groups option
        ///<summary>Information about the person represented by the account. This field is null unless `business_type` is set to `individual`. Once you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.</summary>
        [<Config.Form>]Individual: Create'Individual option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Options for customizing how the account functions within Stripe.</summary>
        [<Config.Form>]Settings: Create'Settings option
        ///<summary>Details on the account's acceptance of the [Stripe Services Agreement](/connect/updating-accounts#tos-acceptance). This property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts. This property defaults to a `full` service agreement when empty.</summary>
        [<Config.Form>]TosAcceptance: Create'TosAcceptance option
        ///<summary>The `type` parameter is deprecated. Use [`controller`](/api/accounts/create#create_account-controller) instead to configure dashboard access, fee payer, loss liability, and requirement collection.</summary>
        [<Config.Form>]Type: Create'Type option
    }
    with
        static member New(?accountToken: string, ?settings: Create'Settings, ?metadata: Map<string, string>, ?individual: Create'Individual, ?groups: Create'Groups, ?externalAccount: string, ?expand: string list, ?email: string, ?documents: Create'Documents, ?defaultCurrency: IsoTypes.IsoCurrencyCode, ?country: IsoTypes.IsoCountryCode, ?controller: Create'Controller, ?company: Create'Company, ?capabilities: Create'Capabilities, ?businessType: Create'BusinessType, ?businessProfile: Create'BusinessProfile, ?tosAcceptance: Create'TosAcceptance, ?type': Create'Type) =
            {
                AccountToken = accountToken
                BusinessProfile = businessProfile
                BusinessType = businessType
                Capabilities = capabilities
                Company = company
                Controller = controller
                Country = country
                DefaultCurrency = defaultCurrency
                Documents = documents
                Email = email
                Expand = expand
                ExternalAccount = externalAccount
                Groups = groups
                Individual = individual
                Metadata = metadata
                Settings = settings
                TosAcceptance = tosAcceptance
                Type = type'
            }

    ///<summary><p>With <a href="/docs/connect">Connect</a>, you can create Stripe accounts for your users.
    ///To do this, you’ll first need to <a href="https://dashboard.stripe.com/account/applications/settings">register your platform</a>.</p>
    ///<p>If you’ve already collected information for your connected accounts, you <a href="/docs/connect/best-practices#onboarding">can prefill that information</a> when
    ///creating the account. Connect Onboarding won’t ask for the prefilled information during account onboarding.
    ///You can prefill any information on the account.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/accounts"
        |> RestApi.postAsync<_, Account> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Account: string
    }
    with
        static member New(account: string) =
            {
                Account = account
            }

    ///<summary><p>With <a href="/connect">Connect</a>, you can delete accounts you manage.</p>
    ///<p>Test-mode accounts can be deleted at any time.</p>
    ///<p>Live-mode accounts that have access to the standard dashboard and Stripe is responsible for negative account balances cannot be deleted, which includes Standard accounts. All other Live-mode accounts, can be deleted when all <a href="/api/balance/balance_object">balances</a> are zero.</p>
    ///<p>If you want to delete your own account, use the <a href="https://dashboard.stripe.com/settings/account">account information tab in your account settings</a> instead.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/accounts/{options.Account}"
        |> RestApi.deleteAsync<DeletedAccount> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Account: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(account: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
            }

    ///<summary><p>Retrieves the details of an account.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}"
        |> RestApi.getAsync<Account> settings qs

    type Update'BusinessProfileAnnualRevenue = {
        ///<summary>A non-negative integer representing the amount in the [smallest currency unit](/currencies#zero-decimal).</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The close-out date of the preceding fiscal year in ISO 8601 format. E.g. 2023-12-31 for the 31st of December, 2023.</summary>
        [<Config.Form>]FiscalYearEnd: string option
    }
    with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode, ?fiscalYearEnd: string) =
            {
                Amount = amount
                Currency = currency
                FiscalYearEnd = fiscalYearEnd
            }

    type Update'BusinessProfileMinorityOwnedBusinessDesignation =
    | LgbtqiOwnedBusiness
    | MinorityOwnedBusiness
    | None'OfTheseApply
    | PreferNotToAnswer
    | WomenOwnedBusiness

    type Update'BusinessProfileMonthlyEstimatedRevenue = {
        ///<summary>A non-negative integer representing how much to charge in the [smallest currency unit](/currencies#zero-decimal).</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
    }
    with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode) =
            {
                Amount = amount
                Currency = currency
            }

    type Update'BusinessProfileSupportAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'BusinessProfile = {
        ///<summary>The applicant's gross annual revenue for its preceding fiscal year.</summary>
        [<Config.Form>]AnnualRevenue: Update'BusinessProfileAnnualRevenue option
        ///<summary>An estimated upper bound of employees, contractors, vendors, etc. currently working for the business.</summary>
        [<Config.Form>]EstimatedWorkerCount: int option
        ///<summary>[The merchant category code for the account](/connect/setting-mcc). MCCs are used to classify businesses based on the goods or services they provide.</summary>
        [<Config.Form>]Mcc: string option
        ///<summary>Whether the business is a minority-owned, women-owned, and/or LGBTQI+ -owned business.</summary>
        [<Config.Form>]MinorityOwnedBusinessDesignation: Update'BusinessProfileMinorityOwnedBusinessDesignation list option
        ///<summary>An estimate of the monthly revenue of the business. Only accepted for accounts in Brazil and India.</summary>
        [<Config.Form>]MonthlyEstimatedRevenue: Update'BusinessProfileMonthlyEstimatedRevenue option
        ///<summary>The customer-facing business name.</summary>
        [<Config.Form>]Name: string option
        ///<summary>Internal-only description of the product sold by, or service provided by, the business. Used by Stripe for risk and underwriting purposes.</summary>
        [<Config.Form>]ProductDescription: string option
        ///<summary>A publicly available mailing address for sending support issues to.</summary>
        [<Config.Form>]SupportAddress: Update'BusinessProfileSupportAddress option
        ///<summary>A publicly available email address for sending support issues to.</summary>
        [<Config.Form>]SupportEmail: string option
        ///<summary>A publicly available phone number to call with support issues.</summary>
        [<Config.Form>]SupportPhone: string option
        ///<summary>A publicly available website for handling support issues.</summary>
        [<Config.Form>]SupportUrl: Choice<string,string> option
        ///<summary>The business's publicly available website.</summary>
        [<Config.Form>]Url: string option
    }
    with
        static member New(?annualRevenue: Update'BusinessProfileAnnualRevenue, ?estimatedWorkerCount: int, ?mcc: string, ?minorityOwnedBusinessDesignation: Update'BusinessProfileMinorityOwnedBusinessDesignation list, ?monthlyEstimatedRevenue: Update'BusinessProfileMonthlyEstimatedRevenue, ?name: string, ?productDescription: string, ?supportAddress: Update'BusinessProfileSupportAddress, ?supportEmail: string, ?supportPhone: string, ?supportUrl: Choice<string,string>, ?url: string) =
            {
                AnnualRevenue = annualRevenue
                EstimatedWorkerCount = estimatedWorkerCount
                Mcc = mcc
                MinorityOwnedBusinessDesignation = minorityOwnedBusinessDesignation
                MonthlyEstimatedRevenue = monthlyEstimatedRevenue
                Name = name
                ProductDescription = productDescription
                SupportAddress = supportAddress
                SupportEmail = supportEmail
                SupportPhone = supportPhone
                SupportUrl = supportUrl
                Url = url
            }

    type Update'CapabilitiesAcssDebitPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesAffirmPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesAfterpayClearpayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesAlmaPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesAmazonPayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesAppDistribution = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesAuBecsDebitPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesBacsDebitPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesBancontactPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesBankTransferPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesBilliePayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesBlikPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesBoletoPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesCardIssuing = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesCardPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesCartesBancairesPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesCashappPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesCryptoPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesEpsPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesFpxPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesGbBankTransferPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesGiropayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesGrabpayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesIdealPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesIndiaInternationalPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesJcbPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesJpBankTransferPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesKakaoPayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesKlarnaPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesKonbiniPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesKrCardPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesLegacyPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesLinkPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesMbWayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesMobilepayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesMultibancoPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesMxBankTransferPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesNaverPayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesNzBankAccountBecsDebitPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesOxxoPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesP24Payments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesPayByBankPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesPaycoPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesPaynowPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesPaytoPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesPixPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesPromptpayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesRevolutPayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesSamsungPayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesSatispayPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesSepaBankTransferPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesSepaDebitPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesSofortPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesSunbitPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesSwishPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesTaxReportingUs1099K = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesTaxReportingUs1099Misc = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesTransfers = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesTreasury = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesTwintPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesUpiPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesUsBankAccountAchPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesUsBankTransferPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'CapabilitiesZipPayments = {
        ///<summary>Passing true requests the capability for the account, if it is not already requested. A requested capability may not immediately become active. Any requirements to activate the capability are returned in the `requirements` arrays.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(?requested: bool) =
            {
                Requested = requested
            }

    type Update'Capabilities = {
        ///<summary>The acss_debit_payments capability.</summary>
        [<Config.Form>]AcssDebitPayments: Update'CapabilitiesAcssDebitPayments option
        ///<summary>The affirm_payments capability.</summary>
        [<Config.Form>]AffirmPayments: Update'CapabilitiesAffirmPayments option
        ///<summary>The afterpay_clearpay_payments capability.</summary>
        [<Config.Form>]AfterpayClearpayPayments: Update'CapabilitiesAfterpayClearpayPayments option
        ///<summary>The alma_payments capability.</summary>
        [<Config.Form>]AlmaPayments: Update'CapabilitiesAlmaPayments option
        ///<summary>The amazon_pay_payments capability.</summary>
        [<Config.Form>]AmazonPayPayments: Update'CapabilitiesAmazonPayPayments option
        ///<summary>The app_distribution capability.</summary>
        [<Config.Form>]AppDistribution: Update'CapabilitiesAppDistribution option
        ///<summary>The au_becs_debit_payments capability.</summary>
        [<Config.Form>]AuBecsDebitPayments: Update'CapabilitiesAuBecsDebitPayments option
        ///<summary>The bacs_debit_payments capability.</summary>
        [<Config.Form>]BacsDebitPayments: Update'CapabilitiesBacsDebitPayments option
        ///<summary>The bancontact_payments capability.</summary>
        [<Config.Form>]BancontactPayments: Update'CapabilitiesBancontactPayments option
        ///<summary>The bank_transfer_payments capability.</summary>
        [<Config.Form>]BankTransferPayments: Update'CapabilitiesBankTransferPayments option
        ///<summary>The billie_payments capability.</summary>
        [<Config.Form>]BilliePayments: Update'CapabilitiesBilliePayments option
        ///<summary>The blik_payments capability.</summary>
        [<Config.Form>]BlikPayments: Update'CapabilitiesBlikPayments option
        ///<summary>The boleto_payments capability.</summary>
        [<Config.Form>]BoletoPayments: Update'CapabilitiesBoletoPayments option
        ///<summary>The card_issuing capability.</summary>
        [<Config.Form>]CardIssuing: Update'CapabilitiesCardIssuing option
        ///<summary>The card_payments capability.</summary>
        [<Config.Form>]CardPayments: Update'CapabilitiesCardPayments option
        ///<summary>The cartes_bancaires_payments capability.</summary>
        [<Config.Form>]CartesBancairesPayments: Update'CapabilitiesCartesBancairesPayments option
        ///<summary>The cashapp_payments capability.</summary>
        [<Config.Form>]CashappPayments: Update'CapabilitiesCashappPayments option
        ///<summary>The crypto_payments capability.</summary>
        [<Config.Form>]CryptoPayments: Update'CapabilitiesCryptoPayments option
        ///<summary>The eps_payments capability.</summary>
        [<Config.Form>]EpsPayments: Update'CapabilitiesEpsPayments option
        ///<summary>The fpx_payments capability.</summary>
        [<Config.Form>]FpxPayments: Update'CapabilitiesFpxPayments option
        ///<summary>The gb_bank_transfer_payments capability.</summary>
        [<Config.Form>]GbBankTransferPayments: Update'CapabilitiesGbBankTransferPayments option
        ///<summary>The giropay_payments capability.</summary>
        [<Config.Form>]GiropayPayments: Update'CapabilitiesGiropayPayments option
        ///<summary>The grabpay_payments capability.</summary>
        [<Config.Form>]GrabpayPayments: Update'CapabilitiesGrabpayPayments option
        ///<summary>The ideal_payments capability.</summary>
        [<Config.Form>]IdealPayments: Update'CapabilitiesIdealPayments option
        ///<summary>The india_international_payments capability.</summary>
        [<Config.Form>]IndiaInternationalPayments: Update'CapabilitiesIndiaInternationalPayments option
        ///<summary>The jcb_payments capability.</summary>
        [<Config.Form>]JcbPayments: Update'CapabilitiesJcbPayments option
        ///<summary>The jp_bank_transfer_payments capability.</summary>
        [<Config.Form>]JpBankTransferPayments: Update'CapabilitiesJpBankTransferPayments option
        ///<summary>The kakao_pay_payments capability.</summary>
        [<Config.Form>]KakaoPayPayments: Update'CapabilitiesKakaoPayPayments option
        ///<summary>The klarna_payments capability.</summary>
        [<Config.Form>]KlarnaPayments: Update'CapabilitiesKlarnaPayments option
        ///<summary>The konbini_payments capability.</summary>
        [<Config.Form>]KonbiniPayments: Update'CapabilitiesKonbiniPayments option
        ///<summary>The kr_card_payments capability.</summary>
        [<Config.Form>]KrCardPayments: Update'CapabilitiesKrCardPayments option
        ///<summary>The legacy_payments capability.</summary>
        [<Config.Form>]LegacyPayments: Update'CapabilitiesLegacyPayments option
        ///<summary>The link_payments capability.</summary>
        [<Config.Form>]LinkPayments: Update'CapabilitiesLinkPayments option
        ///<summary>The mb_way_payments capability.</summary>
        [<Config.Form>]MbWayPayments: Update'CapabilitiesMbWayPayments option
        ///<summary>The mobilepay_payments capability.</summary>
        [<Config.Form>]MobilepayPayments: Update'CapabilitiesMobilepayPayments option
        ///<summary>The multibanco_payments capability.</summary>
        [<Config.Form>]MultibancoPayments: Update'CapabilitiesMultibancoPayments option
        ///<summary>The mx_bank_transfer_payments capability.</summary>
        [<Config.Form>]MxBankTransferPayments: Update'CapabilitiesMxBankTransferPayments option
        ///<summary>The naver_pay_payments capability.</summary>
        [<Config.Form>]NaverPayPayments: Update'CapabilitiesNaverPayPayments option
        ///<summary>The nz_bank_account_becs_debit_payments capability.</summary>
        [<Config.Form>]NzBankAccountBecsDebitPayments: Update'CapabilitiesNzBankAccountBecsDebitPayments option
        ///<summary>The oxxo_payments capability.</summary>
        [<Config.Form>]OxxoPayments: Update'CapabilitiesOxxoPayments option
        ///<summary>The p24_payments capability.</summary>
        [<Config.Form>]P24Payments: Update'CapabilitiesP24Payments option
        ///<summary>The pay_by_bank_payments capability.</summary>
        [<Config.Form>]PayByBankPayments: Update'CapabilitiesPayByBankPayments option
        ///<summary>The payco_payments capability.</summary>
        [<Config.Form>]PaycoPayments: Update'CapabilitiesPaycoPayments option
        ///<summary>The paynow_payments capability.</summary>
        [<Config.Form>]PaynowPayments: Update'CapabilitiesPaynowPayments option
        ///<summary>The payto_payments capability.</summary>
        [<Config.Form>]PaytoPayments: Update'CapabilitiesPaytoPayments option
        ///<summary>The pix_payments capability.</summary>
        [<Config.Form>]PixPayments: Update'CapabilitiesPixPayments option
        ///<summary>The promptpay_payments capability.</summary>
        [<Config.Form>]PromptpayPayments: Update'CapabilitiesPromptpayPayments option
        ///<summary>The revolut_pay_payments capability.</summary>
        [<Config.Form>]RevolutPayPayments: Update'CapabilitiesRevolutPayPayments option
        ///<summary>The samsung_pay_payments capability.</summary>
        [<Config.Form>]SamsungPayPayments: Update'CapabilitiesSamsungPayPayments option
        ///<summary>The satispay_payments capability.</summary>
        [<Config.Form>]SatispayPayments: Update'CapabilitiesSatispayPayments option
        ///<summary>The sepa_bank_transfer_payments capability.</summary>
        [<Config.Form>]SepaBankTransferPayments: Update'CapabilitiesSepaBankTransferPayments option
        ///<summary>The sepa_debit_payments capability.</summary>
        [<Config.Form>]SepaDebitPayments: Update'CapabilitiesSepaDebitPayments option
        ///<summary>The sofort_payments capability.</summary>
        [<Config.Form>]SofortPayments: Update'CapabilitiesSofortPayments option
        ///<summary>The sunbit_payments capability.</summary>
        [<Config.Form>]SunbitPayments: Update'CapabilitiesSunbitPayments option
        ///<summary>The swish_payments capability.</summary>
        [<Config.Form>]SwishPayments: Update'CapabilitiesSwishPayments option
        ///<summary>The tax_reporting_us_1099_k capability.</summary>
        [<Config.Form>]TaxReportingUs1099K: Update'CapabilitiesTaxReportingUs1099K option
        ///<summary>The tax_reporting_us_1099_misc capability.</summary>
        [<Config.Form>]TaxReportingUs1099Misc: Update'CapabilitiesTaxReportingUs1099Misc option
        ///<summary>The transfers capability.</summary>
        [<Config.Form>]Transfers: Update'CapabilitiesTransfers option
        ///<summary>The treasury capability.</summary>
        [<Config.Form>]Treasury: Update'CapabilitiesTreasury option
        ///<summary>The twint_payments capability.</summary>
        [<Config.Form>]TwintPayments: Update'CapabilitiesTwintPayments option
        ///<summary>The upi_payments capability.</summary>
        [<Config.Form>]UpiPayments: Update'CapabilitiesUpiPayments option
        ///<summary>The us_bank_account_ach_payments capability.</summary>
        [<Config.Form>]UsBankAccountAchPayments: Update'CapabilitiesUsBankAccountAchPayments option
        ///<summary>The us_bank_transfer_payments capability.</summary>
        [<Config.Form>]UsBankTransferPayments: Update'CapabilitiesUsBankTransferPayments option
        ///<summary>The zip_payments capability.</summary>
        [<Config.Form>]ZipPayments: Update'CapabilitiesZipPayments option
    }
    with
        static member New(?acssDebitPayments: Update'CapabilitiesAcssDebitPayments, ?mobilepayPayments: Update'CapabilitiesMobilepayPayments, ?multibancoPayments: Update'CapabilitiesMultibancoPayments, ?mxBankTransferPayments: Update'CapabilitiesMxBankTransferPayments, ?naverPayPayments: Update'CapabilitiesNaverPayPayments, ?nzBankAccountBecsDebitPayments: Update'CapabilitiesNzBankAccountBecsDebitPayments, ?oxxoPayments: Update'CapabilitiesOxxoPayments, ?p24Payments: Update'CapabilitiesP24Payments, ?payByBankPayments: Update'CapabilitiesPayByBankPayments, ?paycoPayments: Update'CapabilitiesPaycoPayments, ?paynowPayments: Update'CapabilitiesPaynowPayments, ?paytoPayments: Update'CapabilitiesPaytoPayments, ?pixPayments: Update'CapabilitiesPixPayments, ?promptpayPayments: Update'CapabilitiesPromptpayPayments, ?mbWayPayments: Update'CapabilitiesMbWayPayments, ?revolutPayPayments: Update'CapabilitiesRevolutPayPayments, ?satispayPayments: Update'CapabilitiesSatispayPayments, ?sepaBankTransferPayments: Update'CapabilitiesSepaBankTransferPayments, ?sepaDebitPayments: Update'CapabilitiesSepaDebitPayments, ?sofortPayments: Update'CapabilitiesSofortPayments, ?sunbitPayments: Update'CapabilitiesSunbitPayments, ?swishPayments: Update'CapabilitiesSwishPayments, ?taxReportingUs1099K: Update'CapabilitiesTaxReportingUs1099K, ?taxReportingUs1099Misc: Update'CapabilitiesTaxReportingUs1099Misc, ?transfers: Update'CapabilitiesTransfers, ?treasury: Update'CapabilitiesTreasury, ?twintPayments: Update'CapabilitiesTwintPayments, ?upiPayments: Update'CapabilitiesUpiPayments, ?usBankAccountAchPayments: Update'CapabilitiesUsBankAccountAchPayments, ?samsungPayPayments: Update'CapabilitiesSamsungPayPayments, ?linkPayments: Update'CapabilitiesLinkPayments, ?legacyPayments: Update'CapabilitiesLegacyPayments, ?krCardPayments: Update'CapabilitiesKrCardPayments, ?affirmPayments: Update'CapabilitiesAffirmPayments, ?afterpayClearpayPayments: Update'CapabilitiesAfterpayClearpayPayments, ?almaPayments: Update'CapabilitiesAlmaPayments, ?amazonPayPayments: Update'CapabilitiesAmazonPayPayments, ?appDistribution: Update'CapabilitiesAppDistribution, ?auBecsDebitPayments: Update'CapabilitiesAuBecsDebitPayments, ?bacsDebitPayments: Update'CapabilitiesBacsDebitPayments, ?bancontactPayments: Update'CapabilitiesBancontactPayments, ?bankTransferPayments: Update'CapabilitiesBankTransferPayments, ?billiePayments: Update'CapabilitiesBilliePayments, ?blikPayments: Update'CapabilitiesBlikPayments, ?boletoPayments: Update'CapabilitiesBoletoPayments, ?cardIssuing: Update'CapabilitiesCardIssuing, ?cardPayments: Update'CapabilitiesCardPayments, ?cartesBancairesPayments: Update'CapabilitiesCartesBancairesPayments, ?cashappPayments: Update'CapabilitiesCashappPayments, ?cryptoPayments: Update'CapabilitiesCryptoPayments, ?epsPayments: Update'CapabilitiesEpsPayments, ?fpxPayments: Update'CapabilitiesFpxPayments, ?gbBankTransferPayments: Update'CapabilitiesGbBankTransferPayments, ?giropayPayments: Update'CapabilitiesGiropayPayments, ?grabpayPayments: Update'CapabilitiesGrabpayPayments, ?idealPayments: Update'CapabilitiesIdealPayments, ?indiaInternationalPayments: Update'CapabilitiesIndiaInternationalPayments, ?jcbPayments: Update'CapabilitiesJcbPayments, ?jpBankTransferPayments: Update'CapabilitiesJpBankTransferPayments, ?kakaoPayPayments: Update'CapabilitiesKakaoPayPayments, ?klarnaPayments: Update'CapabilitiesKlarnaPayments, ?konbiniPayments: Update'CapabilitiesKonbiniPayments, ?usBankTransferPayments: Update'CapabilitiesUsBankTransferPayments, ?zipPayments: Update'CapabilitiesZipPayments) =
            {
                AcssDebitPayments = acssDebitPayments
                AffirmPayments = affirmPayments
                AfterpayClearpayPayments = afterpayClearpayPayments
                AlmaPayments = almaPayments
                AmazonPayPayments = amazonPayPayments
                AppDistribution = appDistribution
                AuBecsDebitPayments = auBecsDebitPayments
                BacsDebitPayments = bacsDebitPayments
                BancontactPayments = bancontactPayments
                BankTransferPayments = bankTransferPayments
                BilliePayments = billiePayments
                BlikPayments = blikPayments
                BoletoPayments = boletoPayments
                CardIssuing = cardIssuing
                CardPayments = cardPayments
                CartesBancairesPayments = cartesBancairesPayments
                CashappPayments = cashappPayments
                CryptoPayments = cryptoPayments
                EpsPayments = epsPayments
                FpxPayments = fpxPayments
                GbBankTransferPayments = gbBankTransferPayments
                GiropayPayments = giropayPayments
                GrabpayPayments = grabpayPayments
                IdealPayments = idealPayments
                IndiaInternationalPayments = indiaInternationalPayments
                JcbPayments = jcbPayments
                JpBankTransferPayments = jpBankTransferPayments
                KakaoPayPayments = kakaoPayPayments
                KlarnaPayments = klarnaPayments
                KonbiniPayments = konbiniPayments
                KrCardPayments = krCardPayments
                LegacyPayments = legacyPayments
                LinkPayments = linkPayments
                MbWayPayments = mbWayPayments
                MobilepayPayments = mobilepayPayments
                MultibancoPayments = multibancoPayments
                MxBankTransferPayments = mxBankTransferPayments
                NaverPayPayments = naverPayPayments
                NzBankAccountBecsDebitPayments = nzBankAccountBecsDebitPayments
                OxxoPayments = oxxoPayments
                P24Payments = p24Payments
                PayByBankPayments = payByBankPayments
                PaycoPayments = paycoPayments
                PaynowPayments = paynowPayments
                PaytoPayments = paytoPayments
                PixPayments = pixPayments
                PromptpayPayments = promptpayPayments
                RevolutPayPayments = revolutPayPayments
                SamsungPayPayments = samsungPayPayments
                SatispayPayments = satispayPayments
                SepaBankTransferPayments = sepaBankTransferPayments
                SepaDebitPayments = sepaDebitPayments
                SofortPayments = sofortPayments
                SunbitPayments = sunbitPayments
                SwishPayments = swishPayments
                TaxReportingUs1099K = taxReportingUs1099K
                TaxReportingUs1099Misc = taxReportingUs1099Misc
                Transfers = transfers
                Treasury = treasury
                TwintPayments = twintPayments
                UpiPayments = upiPayments
                UsBankAccountAchPayments = usBankAccountAchPayments
                UsBankTransferPayments = usBankTransferPayments
                ZipPayments = zipPayments
            }

    type Update'CompanyAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'CompanyAddressKana = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Update'CompanyAddressKanji = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Update'CompanyDirectorshipDeclaration = {
        ///<summary>The Unix timestamp marking when the directorship declaration attestation was made.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the directorship declaration attestation was made.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the directorship declaration attestation was made.</summary>
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Update'CompanyOwnershipDeclaration = {
        ///<summary>The Unix timestamp marking when the beneficial owner attestation was made.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the beneficial owner attestation was made.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the beneficial owner attestation was made.</summary>
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Update'CompanyRegistrationDateRegistrationDateSpecs = {
        ///<summary>The day of registration, between 1 and 31.</summary>
        [<Config.Form>]Day: int option
        ///<summary>The month of registration, between 1 and 12.</summary>
        [<Config.Form>]Month: int option
        ///<summary>The four-digit year of registration.</summary>
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Update'CompanyRepresentativeDeclaration = {
        ///<summary>The Unix timestamp marking when the representative declaration attestation was made.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the representative declaration attestation was made.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the representative declaration attestation was made.</summary>
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Update'CompanyVerificationDocument = {
        ///<summary>The back of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Back: string option
        ///<summary>The front of a document returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Update'CompanyVerification = {
        ///<summary>A document verifying the business.</summary>
        [<Config.Form>]Document: Update'CompanyVerificationDocument option
    }
    with
        static member New(?document: Update'CompanyVerificationDocument) =
            {
                Document = document
            }

    type Update'CompanyOwnershipExemptionReason =
    | QualifiedEntityExceedsOwnershipThreshold
    | QualifiesAsFinancialInstitution

    type Update'CompanyStructure =
    | FreeZoneEstablishment
    | FreeZoneLlc
    | GovernmentInstrumentality
    | GovernmentalUnit
    | IncorporatedNonProfit
    | IncorporatedPartnership
    | LimitedLiabilityPartnership
    | Llc
    | MultiMemberLlc
    | PrivateCompany
    | PrivateCorporation
    | PrivatePartnership
    | PublicCompany
    | PublicCorporation
    | PublicPartnership
    | RegisteredCharity
    | SingleMemberLlc
    | SoleEstablishment
    | SoleProprietorship
    | TaxExemptGovernmentInstrumentality
    | UnincorporatedAssociation
    | UnincorporatedNonProfit
    | UnincorporatedPartnership

    type Update'Company = {
        ///<summary>The company's primary address.</summary>
        [<Config.Form>]Address: Update'CompanyAddress option
        ///<summary>The Kana variation of the company's primary address (Japan only).</summary>
        [<Config.Form>]AddressKana: Update'CompanyAddressKana option
        ///<summary>The Kanji variation of the company's primary address (Japan only).</summary>
        [<Config.Form>]AddressKanji: Update'CompanyAddressKanji option
        ///<summary>Whether the company's directors have been provided. Set this Boolean to `true` after creating all the company's directors with [the Persons API](/api/persons) for accounts with a `relationship.director` requirement. This value is not automatically set to `true` after creating directors, so it needs to be updated to indicate all directors have been provided.</summary>
        [<Config.Form>]DirectorsProvided: bool option
        ///<summary>This hash is used to attest that the directors information provided to Stripe is both current and correct.</summary>
        [<Config.Form>]DirectorshipDeclaration: Update'CompanyDirectorshipDeclaration option
        ///<summary>Whether the company's executives have been provided. Set this Boolean to `true` after creating all the company's executives with [the Persons API](/api/persons) for accounts with a `relationship.executive` requirement.</summary>
        [<Config.Form>]ExecutivesProvided: bool option
        ///<summary>The export license ID number of the company, also referred as Import Export Code (India only).</summary>
        [<Config.Form>]ExportLicenseId: string option
        ///<summary>The purpose code to use for export transactions (India only).</summary>
        [<Config.Form>]ExportPurposeCode: string option
        ///<summary>The company's legal name.</summary>
        [<Config.Form>]Name: string option
        ///<summary>The Kana variation of the company's legal name (Japan only).</summary>
        [<Config.Form>]NameKana: string option
        ///<summary>The Kanji variation of the company's legal name (Japan only).</summary>
        [<Config.Form>]NameKanji: string option
        ///<summary>Whether the company's owners have been provided. Set this Boolean to `true` after creating all the company's owners with [the Persons API](/api/persons) for accounts with a `relationship.owner` requirement.</summary>
        [<Config.Form>]OwnersProvided: bool option
        ///<summary>This hash is used to attest that the beneficial owner information provided to Stripe is both current and correct.</summary>
        [<Config.Form>]OwnershipDeclaration: Update'CompanyOwnershipDeclaration option
        ///<summary>This value is used to determine if a business is exempt from providing ultimate beneficial owners. See [this support article](https://support.stripe.com/questions/exemption-from-providing-ownership-details) and [changelog](https://docs.stripe.com/changelog/acacia/2025-01-27/ownership-exemption-reason-accounts-api) for more details.</summary>
        [<Config.Form>]OwnershipExemptionReason: Update'CompanyOwnershipExemptionReason option
        ///<summary>The company's phone number (used for verification).</summary>
        [<Config.Form>]Phone: string option
        [<Config.Form>]RegistrationDate: Choice<Update'CompanyRegistrationDateRegistrationDateSpecs,string> option
        ///<summary>The identification number given to a company when it is registered or incorporated, if distinct from the identification number used for filing taxes. (Examples are the CIN for companies and LLP IN for partnerships in India, and the Company Registration Number in Hong Kong).</summary>
        [<Config.Form>]RegistrationNumber: string option
        ///<summary>This hash is used to attest that the representative is authorized to act as the representative of their legal entity.</summary>
        [<Config.Form>]RepresentativeDeclaration: Update'CompanyRepresentativeDeclaration option
        ///<summary>The category identifying the legal structure of the company or legal entity. See [Business structure](/connect/identity-verification#business-structure) for more details. Pass an empty string to unset this value.</summary>
        [<Config.Form>]Structure: Update'CompanyStructure option
        ///<summary>The business ID number of the company, as appropriate for the company’s country. (Examples are an Employer ID Number in the U.S., a Business Number in Canada, or a Company Number in the UK.)</summary>
        [<Config.Form>]TaxId: string option
        ///<summary>The jurisdiction in which the `tax_id` is registered (Germany-based companies only).</summary>
        [<Config.Form>]TaxIdRegistrar: string option
        ///<summary>The VAT number of the company.</summary>
        [<Config.Form>]VatId: string option
        ///<summary>Information on the verification state of the company.</summary>
        [<Config.Form>]Verification: Update'CompanyVerification option
    }
    with
        static member New(?address: Update'CompanyAddress, ?taxIdRegistrar: string, ?taxId: string, ?structure: Update'CompanyStructure, ?representativeDeclaration: Update'CompanyRepresentativeDeclaration, ?registrationNumber: string, ?registrationDate: Choice<Update'CompanyRegistrationDateRegistrationDateSpecs,string>, ?phone: string, ?ownershipExemptionReason: Update'CompanyOwnershipExemptionReason, ?ownershipDeclaration: Update'CompanyOwnershipDeclaration, ?vatId: string, ?ownersProvided: bool, ?nameKana: string, ?name: string, ?exportPurposeCode: string, ?exportLicenseId: string, ?executivesProvided: bool, ?directorshipDeclaration: Update'CompanyDirectorshipDeclaration, ?directorsProvided: bool, ?addressKanji: Update'CompanyAddressKanji, ?addressKana: Update'CompanyAddressKana, ?nameKanji: string, ?verification: Update'CompanyVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                DirectorsProvided = directorsProvided
                DirectorshipDeclaration = directorshipDeclaration
                ExecutivesProvided = executivesProvided
                ExportLicenseId = exportLicenseId
                ExportPurposeCode = exportPurposeCode
                Name = name
                NameKana = nameKana
                NameKanji = nameKanji
                OwnersProvided = ownersProvided
                OwnershipDeclaration = ownershipDeclaration
                OwnershipExemptionReason = ownershipExemptionReason
                Phone = phone
                RegistrationDate = registrationDate
                RegistrationNumber = registrationNumber
                RepresentativeDeclaration = representativeDeclaration
                Structure = structure
                TaxId = taxId
                TaxIdRegistrar = taxIdRegistrar
                VatId = vatId
                Verification = verification
            }

    type Update'DocumentsBankAccountOwnershipVerification = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'DocumentsCompanyLicense = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'DocumentsCompanyMemorandumOfAssociation = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'DocumentsCompanyMinisterialDecree = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'DocumentsCompanyRegistrationVerification = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'DocumentsCompanyTaxIdVerification = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'DocumentsProofOfAddress = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'DocumentsProofOfRegistrationSigner = {
        ///<summary>The token of the person signing the document, if applicable.</summary>
        [<Config.Form>]Person: string option
    }
    with
        static member New(?person: string) =
            {
                Person = person
            }

    type Update'DocumentsProofOfRegistration = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
        ///<summary>Information regarding the person signing the document if applicable.</summary>
        [<Config.Form>]Signer: Update'DocumentsProofOfRegistrationSigner option
    }
    with
        static member New(?files: string list, ?signer: Update'DocumentsProofOfRegistrationSigner) =
            {
                Files = files
                Signer = signer
            }

    type Update'DocumentsProofOfUltimateBeneficialOwnershipSigner = {
        ///<summary>The token of the person signing the document, if applicable.</summary>
        [<Config.Form>]Person: string option
    }
    with
        static member New(?person: string) =
            {
                Person = person
            }

    type Update'DocumentsProofOfUltimateBeneficialOwnership = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
        ///<summary>Information regarding the person signing the document if applicable.</summary>
        [<Config.Form>]Signer: Update'DocumentsProofOfUltimateBeneficialOwnershipSigner option
    }
    with
        static member New(?files: string list, ?signer: Update'DocumentsProofOfUltimateBeneficialOwnershipSigner) =
            {
                Files = files
                Signer = signer
            }

    type Update'Documents = {
        ///<summary>One or more documents that support the [Bank account ownership verification](https://support.stripe.com/questions/bank-account-ownership-verification) requirement. Must be a document associated with the account’s primary active bank account that displays the last 4 digits of the account number, either a statement or a check.</summary>
        [<Config.Form>]BankAccountOwnershipVerification: Update'DocumentsBankAccountOwnershipVerification option
        ///<summary>One or more documents that demonstrate proof of a company's license to operate.</summary>
        [<Config.Form>]CompanyLicense: Update'DocumentsCompanyLicense option
        ///<summary>One or more documents showing the company's Memorandum of Association.</summary>
        [<Config.Form>]CompanyMemorandumOfAssociation: Update'DocumentsCompanyMemorandumOfAssociation option
        ///<summary>(Certain countries only) One or more documents showing the ministerial decree legalizing the company's establishment.</summary>
        [<Config.Form>]CompanyMinisterialDecree: Update'DocumentsCompanyMinisterialDecree option
        ///<summary>One or more documents that demonstrate proof of a company's registration with the appropriate local authorities.</summary>
        [<Config.Form>]CompanyRegistrationVerification: Update'DocumentsCompanyRegistrationVerification option
        ///<summary>One or more documents that demonstrate proof of a company's tax ID.</summary>
        [<Config.Form>]CompanyTaxIdVerification: Update'DocumentsCompanyTaxIdVerification option
        ///<summary>One or more documents that demonstrate proof of address.</summary>
        [<Config.Form>]ProofOfAddress: Update'DocumentsProofOfAddress option
        ///<summary>One or more documents showing the company’s proof of registration with the national business registry.</summary>
        [<Config.Form>]ProofOfRegistration: Update'DocumentsProofOfRegistration option
        ///<summary>One or more documents that demonstrate proof of ultimate beneficial ownership.</summary>
        [<Config.Form>]ProofOfUltimateBeneficialOwnership: Update'DocumentsProofOfUltimateBeneficialOwnership option
    }
    with
        static member New(?bankAccountOwnershipVerification: Update'DocumentsBankAccountOwnershipVerification, ?companyLicense: Update'DocumentsCompanyLicense, ?companyMemorandumOfAssociation: Update'DocumentsCompanyMemorandumOfAssociation, ?companyMinisterialDecree: Update'DocumentsCompanyMinisterialDecree, ?companyRegistrationVerification: Update'DocumentsCompanyRegistrationVerification, ?companyTaxIdVerification: Update'DocumentsCompanyTaxIdVerification, ?proofOfAddress: Update'DocumentsProofOfAddress, ?proofOfRegistration: Update'DocumentsProofOfRegistration, ?proofOfUltimateBeneficialOwnership: Update'DocumentsProofOfUltimateBeneficialOwnership) =
            {
                BankAccountOwnershipVerification = bankAccountOwnershipVerification
                CompanyLicense = companyLicense
                CompanyMemorandumOfAssociation = companyMemorandumOfAssociation
                CompanyMinisterialDecree = companyMinisterialDecree
                CompanyRegistrationVerification = companyRegistrationVerification
                CompanyTaxIdVerification = companyTaxIdVerification
                ProofOfAddress = proofOfAddress
                ProofOfRegistration = proofOfRegistration
                ProofOfUltimateBeneficialOwnership = proofOfUltimateBeneficialOwnership
            }

    type Update'Groups = {
        ///<summary>The group the account is in to determine their payments pricing, and null if the account is on customized pricing. [See the Platform pricing tool documentation](https://docs.stripe.com/connect/platform-pricing-tools) for details.</summary>
        [<Config.Form>]PaymentsPricing: Choice<string,string> option
    }
    with
        static member New(?paymentsPricing: Choice<string,string>) =
            {
                PaymentsPricing = paymentsPricing
            }

    type Update'IndividualAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'IndividualAddressKana = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Update'IndividualAddressKanji = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Update'IndividualDobDateOfBirthSpecs = {
        ///<summary>The day of birth, between 1 and 31.</summary>
        [<Config.Form>]Day: int option
        ///<summary>The month of birth, between 1 and 12.</summary>
        [<Config.Form>]Month: int option
        ///<summary>The four-digit year of birth.</summary>
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Update'IndividualRegisteredAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'IndividualRelationship = {
        ///<summary>Whether the person is a director of the account's legal entity. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.</summary>
        [<Config.Form>]Director: bool option
        ///<summary>Whether the person has significant responsibility to control, manage, or direct the organization.</summary>
        [<Config.Form>]Executive: bool option
        ///<summary>Whether the person is an owner of the account’s legal entity.</summary>
        [<Config.Form>]Owner: bool option
        ///<summary>The percent owned by the person of the account's legal entity.</summary>
        [<Config.Form>]PercentOwnership: Choice<decimal,string> option
        ///<summary>The person's title (e.g., CEO, Support Engineer).</summary>
        [<Config.Form>]Title: string option
    }
    with
        static member New(?director: bool, ?executive: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?title: string) =
            {
                Director = director
                Executive = executive
                Owner = owner
                PercentOwnership = percentOwnership
                Title = title
            }

    type Update'IndividualVerificationAdditionalDocument = {
        ///<summary>The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Back: string option
        ///<summary>The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Update'IndividualVerificationDocument = {
        ///<summary>The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Back: string option
        ///<summary>The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Update'IndividualVerification = {
        ///<summary>A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.</summary>
        [<Config.Form>]AdditionalDocument: Update'IndividualVerificationAdditionalDocument option
        ///<summary>An identifying document, either a passport or local ID card.</summary>
        [<Config.Form>]Document: Update'IndividualVerificationDocument option
    }
    with
        static member New(?additionalDocument: Update'IndividualVerificationAdditionalDocument, ?document: Update'IndividualVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Update'IndividualPoliticalExposure =
    | Existing
    | None'

    type Update'Individual = {
        ///<summary>The individual's primary address.</summary>
        [<Config.Form>]Address: Update'IndividualAddress option
        ///<summary>The Kana variation of the individual's primary address (Japan only).</summary>
        [<Config.Form>]AddressKana: Update'IndividualAddressKana option
        ///<summary>The Kanji variation of the individual's primary address (Japan only).</summary>
        [<Config.Form>]AddressKanji: Update'IndividualAddressKanji option
        ///<summary>The individual's date of birth.</summary>
        [<Config.Form>]Dob: Choice<Update'IndividualDobDateOfBirthSpecs,string> option
        ///<summary>The individual's email address.</summary>
        [<Config.Form>]Email: string option
        ///<summary>The individual's first name.</summary>
        [<Config.Form>]FirstName: string option
        ///<summary>The Kana variation of the individual's first name (Japan only).</summary>
        [<Config.Form>]FirstNameKana: string option
        ///<summary>The Kanji variation of the individual's first name (Japan only).</summary>
        [<Config.Form>]FirstNameKanji: string option
        ///<summary>A list of alternate names or aliases that the individual is known by.</summary>
        [<Config.Form>]FullNameAliases: Choice<string list,string> option
        ///<summary>The individual's gender</summary>
        [<Config.Form>]Gender: string option
        ///<summary>The government-issued ID number of the individual, as appropriate for the representative's country. (Examples are a Social Security Number in the U.S., or a Social Insurance Number in Canada). Instead of the number itself, you can also provide a [PII token created with Stripe.js](/js/tokens/create_token?type=pii).</summary>
        [<Config.Form>]IdNumber: string option
        ///<summary>The government-issued secondary ID number of the individual, as appropriate for the representative's country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token created with Stripe.js](/js/tokens/create_token?type=pii).</summary>
        [<Config.Form>]IdNumberSecondary: string option
        ///<summary>The individual's last name.</summary>
        [<Config.Form>]LastName: string option
        ///<summary>The Kana variation of the individual's last name (Japan only).</summary>
        [<Config.Form>]LastNameKana: string option
        ///<summary>The Kanji variation of the individual's last name (Japan only).</summary>
        [<Config.Form>]LastNameKanji: string option
        ///<summary>The individual's maiden name.</summary>
        [<Config.Form>]MaidenName: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The individual's phone number.</summary>
        [<Config.Form>]Phone: string option
        ///<summary>Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.</summary>
        [<Config.Form>]PoliticalExposure: Update'IndividualPoliticalExposure option
        ///<summary>The individual's registered address.</summary>
        [<Config.Form>]RegisteredAddress: Update'IndividualRegisteredAddress option
        ///<summary>Describes the person’s relationship to the account.</summary>
        [<Config.Form>]Relationship: Update'IndividualRelationship option
        ///<summary>The last four digits of the individual's Social Security Number (U.S. only).</summary>
        [<Config.Form>]SsnLast4: string option
        ///<summary>The individual's verification document information.</summary>
        [<Config.Form>]Verification: Update'IndividualVerification option
    }
    with
        static member New(?address: Update'IndividualAddress, ?relationship: Update'IndividualRelationship, ?registeredAddress: Update'IndividualRegisteredAddress, ?politicalExposure: Update'IndividualPoliticalExposure, ?phone: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?ssnLast4: string, ?idNumberSecondary: string, ?gender: string, ?fullNameAliases: Choice<string list,string>, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?dob: Choice<Update'IndividualDobDateOfBirthSpecs,string>, ?addressKanji: Update'IndividualAddressKanji, ?addressKana: Update'IndividualAddressKana, ?idNumber: string, ?verification: Update'IndividualVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Email = email
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                FullNameAliases = fullNameAliases
                Gender = gender
                IdNumber = idNumber
                IdNumberSecondary = idNumberSecondary
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                Phone = phone
                PoliticalExposure = politicalExposure
                RegisteredAddress = registeredAddress
                Relationship = relationship
                SsnLast4 = ssnLast4
                Verification = verification
            }

    type Update'SettingsBacsDebitPayments = {
        ///<summary>The Bacs Direct Debit Display Name for this account. For payments made with Bacs Direct Debit, this name appears on the mandate as the statement descriptor. Mobile banking apps display it as the name of the business. To use custom branding, set the Bacs Direct Debit Display Name during or right after creation. Custom branding incurs an additional monthly fee for the platform. If you don't set the display name before requesting Bacs capability, it's automatically set as "Stripe" and the account is onboarded to Stripe branding, which is free.</summary>
        [<Config.Form>]DisplayName: string option
    }
    with
        static member New(?displayName: string) =
            {
                DisplayName = displayName
            }

    type Update'SettingsBranding = {
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) An icon for the account. Must be square and at least 128px x 128px.</summary>
        [<Config.Form>]Icon: string option
        ///<summary>(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A logo for the account that will be used in Checkout instead of the icon and without the account's name next to it if provided. Must be at least 128px x 128px.</summary>
        [<Config.Form>]Logo: string option
        ///<summary>A CSS hex color value representing the primary branding color for this account.</summary>
        [<Config.Form>]PrimaryColor: string option
        ///<summary>A CSS hex color value representing the secondary branding color for this account.</summary>
        [<Config.Form>]SecondaryColor: string option
    }
    with
        static member New(?icon: string, ?logo: string, ?primaryColor: string, ?secondaryColor: string) =
            {
                Icon = icon
                Logo = logo
                PrimaryColor = primaryColor
                SecondaryColor = secondaryColor
            }

    type Update'SettingsCardIssuingTosAcceptance = {
        ///<summary>The Unix timestamp marking when the account representative accepted the service agreement.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the account representative accepted the service agreement.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the account representative accepted the service agreement.</summary>
        [<Config.Form>]UserAgent: Choice<string,string> option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Update'SettingsCardIssuing = {
        ///<summary>Details on the account's acceptance of the [Stripe Issuing Terms and Disclosures](/issuing/connect/tos_acceptance).</summary>
        [<Config.Form>]TosAcceptance: Update'SettingsCardIssuingTosAcceptance option
    }
    with
        static member New(?tosAcceptance: Update'SettingsCardIssuingTosAcceptance) =
            {
                TosAcceptance = tosAcceptance
            }

    type Update'SettingsCardPaymentsDeclineOn = {
        ///<summary>Whether Stripe automatically declines charges with an incorrect ZIP or postal code. This setting only applies when a ZIP or postal code is provided and they fail bank verification.</summary>
        [<Config.Form>]AvsFailure: bool option
        ///<summary>Whether Stripe automatically declines charges with an incorrect CVC. This setting only applies when a CVC is provided and it fails bank verification.</summary>
        [<Config.Form>]CvcFailure: bool option
    }
    with
        static member New(?avsFailure: bool, ?cvcFailure: bool) =
            {
                AvsFailure = avsFailure
                CvcFailure = cvcFailure
            }

    type Update'SettingsCardPayments = {
        ///<summary>Automatically declines certain charge types regardless of whether the card issuer accepted or declined the charge.</summary>
        [<Config.Form>]DeclineOn: Update'SettingsCardPaymentsDeclineOn option
        ///<summary>The default text that appears on credit card statements when a charge is made. This field prefixes any dynamic `statement_descriptor` specified on the charge. `statement_descriptor_prefix` is useful for maximizing descriptor space for the dynamic portion.</summary>
        [<Config.Form>]StatementDescriptorPrefix: string option
        ///<summary>The Kana variation of the default text that appears on credit card statements when a charge is made (Japan only). This field prefixes any dynamic `statement_descriptor_suffix_kana` specified on the charge. `statement_descriptor_prefix_kana` is useful for maximizing descriptor space for the dynamic portion.</summary>
        [<Config.Form>]StatementDescriptorPrefixKana: Choice<string,string> option
        ///<summary>The Kanji variation of the default text that appears on credit card statements when a charge is made (Japan only). This field prefixes any dynamic `statement_descriptor_suffix_kanji` specified on the charge. `statement_descriptor_prefix_kanji` is useful for maximizing descriptor space for the dynamic portion.</summary>
        [<Config.Form>]StatementDescriptorPrefixKanji: Choice<string,string> option
    }
    with
        static member New(?declineOn: Update'SettingsCardPaymentsDeclineOn, ?statementDescriptorPrefix: string, ?statementDescriptorPrefixKana: Choice<string,string>, ?statementDescriptorPrefixKanji: Choice<string,string>) =
            {
                DeclineOn = declineOn
                StatementDescriptorPrefix = statementDescriptorPrefix
                StatementDescriptorPrefixKana = statementDescriptorPrefixKana
                StatementDescriptorPrefixKanji = statementDescriptorPrefixKanji
            }

    type Update'SettingsInvoicesHostedPaymentMethodSave =
    | Always
    | Never
    | Offer

    type Update'SettingsInvoices = {
        ///<summary>The list of default Account Tax IDs to automatically include on invoices. Account Tax IDs get added when an invoice is finalized.</summary>
        [<Config.Form>]DefaultAccountTaxIds: Choice<string list,string> option
        ///<summary>Whether to save the payment method after a payment is completed for a one-time invoice or a subscription invoice when the customer already has a default payment method on the hosted invoice page.</summary>
        [<Config.Form>]HostedPaymentMethodSave: Update'SettingsInvoicesHostedPaymentMethodSave option
    }
    with
        static member New(?defaultAccountTaxIds: Choice<string list,string>, ?hostedPaymentMethodSave: Update'SettingsInvoicesHostedPaymentMethodSave) =
            {
                DefaultAccountTaxIds = defaultAccountTaxIds
                HostedPaymentMethodSave = hostedPaymentMethodSave
            }

    type Update'SettingsPayments = {
        ///<summary>The default text that appears on statements for non-card charges outside of Japan. For card charges, if you don't set a `statement_descriptor_prefix`, this text is also used as the statement descriptor prefix. In that case, if concatenating the statement descriptor suffix causes the combined statement descriptor to exceed 22 characters, we truncate the `statement_descriptor` text to limit the full descriptor to 22 characters. For more information about statement descriptors and their requirements, see the [account settings documentation](https://docs.stripe.com/get-started/account/statement-descriptors).</summary>
        [<Config.Form>]StatementDescriptor: string option
        ///<summary>The Kana variation of `statement_descriptor` used for charges in Japan. Japanese statement descriptors have [special requirements](https://docs.stripe.com/get-started/account/statement-descriptors#set-japanese-statement-descriptors).</summary>
        [<Config.Form>]StatementDescriptorKana: string option
        ///<summary>The Kanji variation of `statement_descriptor` used for charges in Japan. Japanese statement descriptors have [special requirements](https://docs.stripe.com/get-started/account/statement-descriptors#set-japanese-statement-descriptors).</summary>
        [<Config.Form>]StatementDescriptorKanji: string option
    }
    with
        static member New(?statementDescriptor: string, ?statementDescriptorKana: string, ?statementDescriptorKanji: string) =
            {
                StatementDescriptor = statementDescriptor
                StatementDescriptorKana = statementDescriptorKana
                StatementDescriptorKanji = statementDescriptorKanji
            }

    type Update'SettingsPayoutsScheduleDelayDays =
    | Minimum

    type Update'SettingsPayoutsScheduleWeeklyPayoutDays =
    | Friday
    | Monday
    | Thursday
    | Tuesday
    | Wednesday

    type Update'SettingsPayoutsScheduleInterval =
    | Daily
    | Manual
    | Monthly
    | Weekly

    type Update'SettingsPayoutsScheduleWeeklyAnchor =
    | Friday
    | Monday
    | Saturday
    | Sunday
    | Thursday
    | Tuesday
    | Wednesday

    type Update'SettingsPayoutsSchedule = {
        ///<summary>The number of days charge funds are held before being paid out. May also be set to `minimum`, representing the lowest available value for the account country. Default is `minimum`. The `delay_days` parameter remains at the last configured value if `interval` is `manual`. [Learn more about controlling payout delay days](/connect/manage-payout-schedule).</summary>
        [<Config.Form>]DelayDays: Choice<Update'SettingsPayoutsScheduleDelayDays,int> option
        ///<summary>How frequently available funds are paid out. One of: `daily`, `manual`, `weekly`, or `monthly`. Default is `daily`.</summary>
        [<Config.Form>]Interval: Update'SettingsPayoutsScheduleInterval option
        ///<summary>The day of the month when available funds are paid out, specified as a number between 1--31. Payouts nominally scheduled between the 29th and 31st of the month are instead sent on the last day of a shorter month. Required and applicable only if `interval` is `monthly`.</summary>
        [<Config.Form>]MonthlyAnchor: int option
        ///<summary>The days of the month when available funds are paid out, specified as an array of numbers between 1--31. Payouts nominally scheduled between the 29th and 31st of the month are instead sent on the last day of a shorter month. Required and applicable only if `interval` is `monthly` and `monthly_anchor` is not set.</summary>
        [<Config.Form>]MonthlyPayoutDays: int list option
        ///<summary>The day of the week when available funds are paid out, specified as `monday`, `tuesday`, etc. Required and applicable only if `interval` is `weekly`.</summary>
        [<Config.Form>]WeeklyAnchor: Update'SettingsPayoutsScheduleWeeklyAnchor option
        ///<summary>The days of the week when available funds are paid out, specified as an array, e.g., [`monday`, `tuesday`]. Required and applicable only if `interval` is `weekly`.</summary>
        [<Config.Form>]WeeklyPayoutDays: Update'SettingsPayoutsScheduleWeeklyPayoutDays list option
    }
    with
        static member New(?delayDays: Choice<Update'SettingsPayoutsScheduleDelayDays,int>, ?interval: Update'SettingsPayoutsScheduleInterval, ?monthlyAnchor: int, ?monthlyPayoutDays: int list, ?weeklyAnchor: Update'SettingsPayoutsScheduleWeeklyAnchor, ?weeklyPayoutDays: Update'SettingsPayoutsScheduleWeeklyPayoutDays list) =
            {
                DelayDays = delayDays
                Interval = interval
                MonthlyAnchor = monthlyAnchor
                MonthlyPayoutDays = monthlyPayoutDays
                WeeklyAnchor = weeklyAnchor
                WeeklyPayoutDays = weeklyPayoutDays
            }

    type Update'SettingsPayouts = {
        ///<summary>A Boolean indicating whether Stripe should try to reclaim negative balances from an attached bank account. For details, see [Understanding Connect Account Balances](/connect/account-balances).</summary>
        [<Config.Form>]DebitNegativeBalances: bool option
        ///<summary>Details on when funds from charges are available, and when they are paid out to an external account. For details, see our [Setting Bank and Debit Card Payouts](/connect/bank-transfers#payout-information) documentation.</summary>
        [<Config.Form>]Schedule: Update'SettingsPayoutsSchedule option
        ///<summary>The text that appears on the bank account statement for payouts. If not set, this defaults to the platform's bank descriptor as set in the Dashboard.</summary>
        [<Config.Form>]StatementDescriptor: string option
    }
    with
        static member New(?debitNegativeBalances: bool, ?schedule: Update'SettingsPayoutsSchedule, ?statementDescriptor: string) =
            {
                DebitNegativeBalances = debitNegativeBalances
                Schedule = schedule
                StatementDescriptor = statementDescriptor
            }

    type Update'SettingsTreasuryTosAcceptance = {
        ///<summary>The Unix timestamp marking when the account representative accepted the service agreement.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the account representative accepted the service agreement.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the account representative accepted the service agreement.</summary>
        [<Config.Form>]UserAgent: Choice<string,string> option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Update'SettingsTreasury = {
        ///<summary>Details on the account's acceptance of the Stripe Treasury Services Agreement.</summary>
        [<Config.Form>]TosAcceptance: Update'SettingsTreasuryTosAcceptance option
    }
    with
        static member New(?tosAcceptance: Update'SettingsTreasuryTosAcceptance) =
            {
                TosAcceptance = tosAcceptance
            }

    type Update'Settings = {
        ///<summary>Settings specific to Bacs Direct Debit payments.</summary>
        [<Config.Form>]BacsDebitPayments: Update'SettingsBacsDebitPayments option
        ///<summary>Settings used to apply the account's branding to email receipts, invoices, Checkout, and other products.</summary>
        [<Config.Form>]Branding: Update'SettingsBranding option
        ///<summary>Settings specific to the account's use of the Card Issuing product.</summary>
        [<Config.Form>]CardIssuing: Update'SettingsCardIssuing option
        ///<summary>Settings specific to card charging on the account.</summary>
        [<Config.Form>]CardPayments: Update'SettingsCardPayments option
        ///<summary>Settings specific to the account's use of Invoices.</summary>
        [<Config.Form>]Invoices: Update'SettingsInvoices option
        ///<summary>Settings that apply across payment methods for charging on the account.</summary>
        [<Config.Form>]Payments: Update'SettingsPayments option
        ///<summary>Settings specific to the account's payouts.</summary>
        [<Config.Form>]Payouts: Update'SettingsPayouts option
        ///<summary>Settings specific to the account's Treasury FinancialAccounts.</summary>
        [<Config.Form>]Treasury: Update'SettingsTreasury option
    }
    with
        static member New(?bacsDebitPayments: Update'SettingsBacsDebitPayments, ?branding: Update'SettingsBranding, ?cardIssuing: Update'SettingsCardIssuing, ?cardPayments: Update'SettingsCardPayments, ?invoices: Update'SettingsInvoices, ?payments: Update'SettingsPayments, ?payouts: Update'SettingsPayouts, ?treasury: Update'SettingsTreasury) =
            {
                BacsDebitPayments = bacsDebitPayments
                Branding = branding
                CardIssuing = cardIssuing
                CardPayments = cardPayments
                Invoices = invoices
                Payments = payments
                Payouts = payouts
                Treasury = treasury
            }

    type Update'TosAcceptance = {
        ///<summary>The Unix timestamp marking when the account representative accepted their service agreement.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the account representative accepted their service agreement.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user's service agreement type.</summary>
        [<Config.Form>]ServiceAgreement: string option
        ///<summary>The user agent of the browser from which the account representative accepted their service agreement.</summary>
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?serviceAgreement: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                ServiceAgreement = serviceAgreement
                UserAgent = userAgent
            }

    type Update'BusinessType =
    | Company
    | GovernmentEntity
    | Individual
    | NonProfit

    type UpdateOptions = {
        [<Config.Path>]Account: string
        ///<summary>An [account token](https://api.stripe.com#create_account_token), used to securely provide details to the account.</summary>
        [<Config.Form>]AccountToken: string option
        ///<summary>Business information about the account.</summary>
        [<Config.Form>]BusinessProfile: Update'BusinessProfile option
        ///<summary>The business type. Once you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.</summary>
        [<Config.Form>]BusinessType: Update'BusinessType option
        ///<summary>Each key of the dictionary represents a capability, and each capability
        ///maps to its settings (for example, whether it has been requested or not). Each
        ///capability is inactive until you have provided its specific
        ///requirements and Stripe has verified them. An account might have some
        ///of its requested capabilities be active and some be inactive.
        ///Required when [account.controller.stripe_dashboard.type](/api/accounts/create#create_account-controller-dashboard-type)
        ///is `none`, which includes Custom accounts.</summary>
        [<Config.Form>]Capabilities: Update'Capabilities option
        ///<summary>Information about the company or business. This field is available for any `business_type`. Once you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.</summary>
        [<Config.Form>]Company: Update'Company option
        ///<summary>Three-letter ISO currency code representing the default currency for the account. This must be a currency that [Stripe supports in the account's country](https://docs.stripe.com/payouts).</summary>
        [<Config.Form>]DefaultCurrency: IsoTypes.IsoCurrencyCode option
        ///<summary>Documents that may be submitted to satisfy various informational requests.</summary>
        [<Config.Form>]Documents: Update'Documents option
        ///<summary>The email address of the account holder. This is only to make the account easier to identify to you. If [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts, Stripe doesn't email the account without your consent.</summary>
        [<Config.Form>]Email: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A card or bank account to attach to the account for receiving [payouts](/connect/bank-debit-card-payouts) (you won’t be able to use it for top-ups). You can provide either a token, like the ones returned by [Stripe.js](/js), or a dictionary, as documented in the `external_account` parameter for [bank account](/api#account_create_bank_account) creation. <br><br>By default, providing an external account sets it as the new default external account for its currency, and deletes the old default if one exists. To add additional external accounts without replacing the existing default for the currency, use the [bank account](/api#account_create_bank_account) or [card creation](/api#account_create_card) APIs. After you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.</summary>
        [<Config.Form>]ExternalAccount: string option
        ///<summary>A hash of account group type to tokens. These are account groups this account should be added to.</summary>
        [<Config.Form>]Groups: Update'Groups option
        ///<summary>Information about the person represented by the account. This field is null unless `business_type` is set to `individual`. Once you create an [Account Link](/api/account_links) or [Account Session](/api/account_sessions), this property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts.</summary>
        [<Config.Form>]Individual: Update'Individual option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Options for customizing how the account functions within Stripe.</summary>
        [<Config.Form>]Settings: Update'Settings option
        ///<summary>Details on the account's acceptance of the [Stripe Services Agreement](/connect/updating-accounts#tos-acceptance). This property can only be updated for accounts where [controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts. This property defaults to a `full` service agreement when empty.</summary>
        [<Config.Form>]TosAcceptance: Update'TosAcceptance option
    }
    with
        static member New(account: string, ?accountToken: string, ?businessProfile: Update'BusinessProfile, ?businessType: Update'BusinessType, ?capabilities: Update'Capabilities, ?company: Update'Company, ?defaultCurrency: IsoTypes.IsoCurrencyCode, ?documents: Update'Documents, ?email: string, ?expand: string list, ?externalAccount: string, ?groups: Update'Groups, ?individual: Update'Individual, ?metadata: Map<string, string>, ?settings: Update'Settings, ?tosAcceptance: Update'TosAcceptance) =
            {
                Account = account
                AccountToken = accountToken
                BusinessProfile = businessProfile
                BusinessType = businessType
                Capabilities = capabilities
                Company = company
                DefaultCurrency = defaultCurrency
                Documents = documents
                Email = email
                Expand = expand
                ExternalAccount = externalAccount
                Groups = groups
                Individual = individual
                Metadata = metadata
                Settings = settings
                TosAcceptance = tosAcceptance
            }

    ///<summary><p>Updates a <a href="/connect/accounts">connected account</a> by setting the values of the parameters passed. Any parameters not provided are
    ///left unchanged.</p>
    ///<p>For accounts where <a href="/api/accounts/object#account_object-controller-requirement_collection">controller.requirement_collection</a>
    ///is <code>application</code>, which includes Custom accounts, you can update any information on the account.</p>
    ///<p>For accounts where <a href="/api/accounts/object#account_object-controller-requirement_collection">controller.requirement_collection</a>
    ///is <code>stripe</code>, which includes Standard and Express accounts, you can update all information until you create
    ///an <a href="/api/account_links">Account Link</a> or <a href="/api/account_sessions">Account Session</a> to start Connect onboarding,
    ///after which some properties can no longer be updated.</p>
    ///<p>To update your own account, use the <a href="https://dashboard.stripe.com/settings/account">Dashboard</a>. Refer to our
    ///<a href="/docs/connect/updating-accounts">Connect</a> documentation to learn more about updating accounts.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/accounts/{options.Account}"
        |> RestApi.postAsync<_, Account> settings (Map.empty) options

module AccountsCapabilities =

    type CapabilitiesOptions = {
        [<Config.Path>]Account: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(account: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
            }

    ///<summary><p>Returns a list of capabilities associated with the account. The capabilities are returned sorted by creation date, with the most recent capability appearing first.</p></summary>
    let Capabilities settings (options: CapabilitiesOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/capabilities"
        |> RestApi.getAsync<StripeList<Capability>> settings qs

    type RetrieveOptions = {
        [<Config.Path>]Account: string
        [<Config.Path>]Capability: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(account: string, capability: string, ?expand: string list) =
            {
                Account = account
                Capability = capability
                Expand = expand
            }

    ///<summary><p>Retrieves information about the specified Account Capability.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/capabilities/{options.Capability}"
        |> RestApi.getAsync<Capability> settings qs

    type UpdateOptions = {
        [<Config.Path>]Account: string
        [<Config.Path>]Capability: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>To request a new capability for an account, pass true. There can be a delay before the requested capability becomes active. If the capability has any activation requirements, the response includes them in the `requirements` arrays.
        ///If a capability isn't permanent, you can remove it from the account by passing false. Some capabilities are permanent after they've been requested. Attempting to remove a permanent capability returns an error.</summary>
        [<Config.Form>]Requested: bool option
    }
    with
        static member New(account: string, capability: string, ?expand: string list, ?requested: bool) =
            {
                Account = account
                Capability = capability
                Expand = expand
                Requested = requested
            }

    ///<summary><p>Updates an existing Account Capability. Request or remove a capability by updating its <code>requested</code> parameter.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/accounts/{options.Account}/capabilities/{options.Capability}"
        |> RestApi.postAsync<_, Capability> settings (Map.empty) options

module AccountsExternalAccounts =

    type ListOptions = {
        [<Config.Path>]Account: string
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Filter external accounts according to a particular object type.</summary>
        [<Config.Query>]Object: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(account: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?object: string, ?startingAfter: string) =
            {
                Account = account
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Object = object
                StartingAfter = startingAfter
            }

    ///<summary><p>List external accounts for an account.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("object", options.Object |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/external_accounts"
        |> RestApi.getAsync<StripeList<ExternalAccount>> settings qs

    type CreateOptions = {
        [<Config.Path>]Account: string
        ///<summary>When set to true, or if this is the first external account added in this currency, this account becomes the default external account for its currency.</summary>
        [<Config.Form>]DefaultForCurrency: bool option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A token, like the ones returned by [Stripe.js](https://docs.stripe.com/js) or a dictionary containing a user's external account details (with the options shown below). Please refer to full [documentation](https://stripe.com/docs/api/external_accounts) instead.</summary>
        [<Config.Form>]ExternalAccount: string
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(account: string, externalAccount: string, ?defaultForCurrency: bool, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Account = account
                DefaultForCurrency = defaultForCurrency
                Expand = expand
                ExternalAccount = externalAccount
                Metadata = metadata
            }

    ///<summary><p>Create an external account for a given account.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/accounts/{options.Account}/external_accounts"
        |> RestApi.postAsync<_, ExternalAccount> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Account: string
        ///<summary>Unique identifier for the external account to be deleted.</summary>
        [<Config.Path>]Id: string
    }
    with
        static member New(account: string, id: string) =
            {
                Account = account
                Id = id
            }

    ///<summary><p>Delete a specified external account for a given account.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/accounts/{options.Account}/external_accounts/{options.Id}"
        |> RestApi.deleteAsync<DeletedExternalAccount> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Account: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Unique identifier for the external account to be retrieved.</summary>
        [<Config.Path>]Id: string
    }
    with
        static member New(account: string, id: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieve a specified external account for a given account.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/external_accounts/{options.Id}"
        |> RestApi.getAsync<ExternalAccount> settings qs

    type Update'DocumentsBankAccountOwnershipVerification = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: string list option
    }
    with
        static member New(?files: string list) =
            {
                Files = files
            }

    type Update'Documents = {
        ///<summary>One or more documents that support the [Bank account ownership verification](https://support.stripe.com/questions/bank-account-ownership-verification) requirement. Must be a document associated with the bank account that displays the last 4 digits of the account number, either a statement or a check.</summary>
        [<Config.Form>]BankAccountOwnershipVerification: Update'DocumentsBankAccountOwnershipVerification option
    }
    with
        static member New(?bankAccountOwnershipVerification: Update'DocumentsBankAccountOwnershipVerification) =
            {
                BankAccountOwnershipVerification = bankAccountOwnershipVerification
            }

    type Update'AccountHolderType =
    | Company
    | Individual

    type Update'AccountType =
    | Checking
    | Futsu
    | Savings
    | Toza

    type UpdateOptions = {
        [<Config.Path>]Account: string
        [<Config.Path>]Id: string
        ///<summary>The name of the person or business that owns the bank account.</summary>
        [<Config.Form>]AccountHolderName: string option
        ///<summary>The type of entity that holds the account. This can be either `individual` or `company`.</summary>
        [<Config.Form>]AccountHolderType: Update'AccountHolderType option
        ///<summary>The bank account type. This can only be `checking` or `savings` in most countries. In Japan, this can only be `futsu` or `toza`.</summary>
        [<Config.Form>]AccountType: Update'AccountType option
        ///<summary>City/District/Suburb/Town/Village.</summary>
        [<Config.Form>]AddressCity: string option
        ///<summary>Billing address country, if provided when creating card.</summary>
        [<Config.Form>]AddressCountry: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1 (Street address/PO Box/Company name).</summary>
        [<Config.Form>]AddressLine1: string option
        ///<summary>Address line 2 (Apartment/Suite/Unit/Building).</summary>
        [<Config.Form>]AddressLine2: string option
        ///<summary>State/County/Province/Region.</summary>
        [<Config.Form>]AddressState: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]AddressZip: string option
        ///<summary>When set to true, this becomes the default external account for its currency.</summary>
        [<Config.Form>]DefaultForCurrency: bool option
        ///<summary>Documents that may be submitted to satisfy various informational requests.</summary>
        [<Config.Form>]Documents: Update'Documents option
        ///<summary>Two digit number representing the card’s expiration month.</summary>
        [<Config.Form>]ExpMonth: string option
        ///<summary>Four digit number representing the card’s expiration year.</summary>
        [<Config.Form>]ExpYear: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Cardholder name.</summary>
        [<Config.Form>]Name: string option
    }
    with
        static member New(account: string, id: string, ?expand: string list, ?expYear: string, ?expMonth: string, ?documents: Update'Documents, ?defaultForCurrency: bool, ?addressZip: string, ?addressState: string, ?addressLine2: string, ?addressLine1: string, ?addressCountry: IsoTypes.IsoCountryCode, ?addressCity: string, ?accountType: Update'AccountType, ?accountHolderType: Update'AccountHolderType, ?accountHolderName: string, ?metadata: Map<string, string>, ?name: string) =
            {
                Account = account
                Id = id
                AccountHolderName = accountHolderName
                AccountHolderType = accountHolderType
                AccountType = accountType
                AddressCity = addressCity
                AddressCountry = addressCountry
                AddressLine1 = addressLine1
                AddressLine2 = addressLine2
                AddressState = addressState
                AddressZip = addressZip
                DefaultForCurrency = defaultForCurrency
                Documents = documents
                ExpMonth = expMonth
                ExpYear = expYear
                Expand = expand
                Metadata = metadata
                Name = name
            }

    ///<summary><p>Updates the metadata, account holder name, account holder type of a bank account belonging to
    ///a connected account and optionally sets it as the default for its currency. Other bank account
    ///details are not editable by design.</p>
    ///<p>You can only update bank accounts when <a href="/api/accounts/object#account_object-controller-requirement_collection">account.controller.requirement_collection</a> is <code>application</code>, which includes <a href="/connect/custom-accounts">Custom accounts</a>.</p>
    ///<p>You can re-enable a disabled bank account by performing an update call without providing any
    ///arguments or changes.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/accounts/{options.Account}/external_accounts/{options.Id}"
        |> RestApi.postAsync<_, ExternalAccount> settings (Map.empty) options

module AccountsLoginLinks =

    type CreateOptions = {
        [<Config.Path>]Account: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(account: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
            }

    ///<summary><p>Creates a login link for a connected account to access the Express Dashboard.</p>
    ///<p><strong>You can only create login links for accounts that use the <a href="/connect/express-dashboard">Express Dashboard</a> and are connected to your platform</strong>.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/accounts/{options.Account}/login_links"
        |> RestApi.postAsync<_, LoginLink> settings (Map.empty) options

module AccountsPersons =

    type PersonsOptions = {
        [<Config.Path>]Account: string
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Filters on the list of people returned based on the person's relationship to the account's company.</summary>
        [<Config.Query>]Relationship: Map<string, string> option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(account: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?relationship: Map<string, string>, ?startingAfter: string) =
            {
                Account = account
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Relationship = relationship
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of people associated with the account’s legal entity. The people are returned sorted by creation date, with the most recent people appearing first.</p></summary>
    let Persons settings (options: PersonsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("relationship", options.Relationship |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/persons"
        |> RestApi.getAsync<StripeList<Person>> settings qs

    type Create'AdditionalTosAcceptancesAccount = {
        ///<summary>The Unix timestamp marking when the account representative accepted the service agreement.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the account representative accepted the service agreement.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the account representative accepted the service agreement.</summary>
        [<Config.Form>]UserAgent: Choice<string,string> option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'AdditionalTosAcceptances = {
        ///<summary>Details on the legal guardian's acceptance of the main Stripe service agreement.</summary>
        [<Config.Form>]Account: Create'AdditionalTosAcceptancesAccount option
    }
    with
        static member New(?account: Create'AdditionalTosAcceptancesAccount) =
            {
                Account = account
            }

    type Create'Address = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'AddressKana = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'AddressKanji = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'DobDateOfBirthSpecs = {
        ///<summary>The day of birth, between 1 and 31.</summary>
        [<Config.Form>]Day: int option
        ///<summary>The month of birth, between 1 and 12.</summary>
        [<Config.Form>]Month: int option
        ///<summary>The four-digit year of birth.</summary>
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'DocumentsCompanyAuthorization = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Create'DocumentsPassport = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Create'DocumentsVisa = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Create'Documents = {
        ///<summary>One or more documents that demonstrate proof that this person is authorized to represent the company.</summary>
        [<Config.Form>]CompanyAuthorization: Create'DocumentsCompanyAuthorization option
        ///<summary>One or more documents showing the person's passport page with photo and personal data.</summary>
        [<Config.Form>]Passport: Create'DocumentsPassport option
        ///<summary>One or more documents showing the person's visa required for living in the country where they are residing.</summary>
        [<Config.Form>]Visa: Create'DocumentsVisa option
    }
    with
        static member New(?companyAuthorization: Create'DocumentsCompanyAuthorization, ?passport: Create'DocumentsPassport, ?visa: Create'DocumentsVisa) =
            {
                CompanyAuthorization = companyAuthorization
                Passport = passport
                Visa = visa
            }

    type Create'RegisteredAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'Relationship = {
        ///<summary>Whether the person is the authorizer of the account's representative.</summary>
        [<Config.Form>]Authorizer: bool option
        ///<summary>Whether the person is a director of the account's legal entity. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.</summary>
        [<Config.Form>]Director: bool option
        ///<summary>Whether the person has significant responsibility to control, manage, or direct the organization.</summary>
        [<Config.Form>]Executive: bool option
        ///<summary>Whether the person is the legal guardian of the account's representative.</summary>
        [<Config.Form>]LegalGuardian: bool option
        ///<summary>Whether the person is an owner of the account’s legal entity.</summary>
        [<Config.Form>]Owner: bool option
        ///<summary>The percent owned by the person of the account's legal entity.</summary>
        [<Config.Form>]PercentOwnership: Choice<decimal,string> option
        ///<summary>Whether the person is authorized as the primary representative of the account. This is the person nominated by the business to provide information about themselves, and general information about the account. There can only be one representative at any given time. At the time the account is created, this person should be set to the person responsible for opening the account.</summary>
        [<Config.Form>]Representative: bool option
        ///<summary>The person's title (e.g., CEO, Support Engineer).</summary>
        [<Config.Form>]Title: string option
    }
    with
        static member New(?authorizer: bool, ?director: bool, ?executive: bool, ?legalGuardian: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?representative: bool, ?title: string) =
            {
                Authorizer = authorizer
                Director = director
                Executive = executive
                LegalGuardian = legalGuardian
                Owner = owner
                PercentOwnership = percentOwnership
                Representative = representative
                Title = title
            }

    type Create'UsCfpbDataEthnicityDetailsEthnicity =
    | Cuban
    | HispanicOrLatino
    | Mexican
    | NotHispanicOrLatino
    | OtherHispanicOrLatino
    | PreferNotToAnswer
    | PuertoRican

    type Create'UsCfpbDataEthnicityDetails = {
        ///<summary>The persons ethnicity</summary>
        [<Config.Form>]Ethnicity: Create'UsCfpbDataEthnicityDetailsEthnicity list option
        ///<summary>Please specify your origin, when other is selected.</summary>
        [<Config.Form>]EthnicityOther: string option
    }
    with
        static member New(?ethnicity: Create'UsCfpbDataEthnicityDetailsEthnicity list, ?ethnicityOther: string) =
            {
                Ethnicity = ethnicity
                EthnicityOther = ethnicityOther
            }

    type Create'UsCfpbDataRaceDetailsRace =
    | AfricanAmerican
    | AmericanIndianOrAlaskaNative
    | Asian
    | AsianIndian
    | BlackOrAfricanAmerican
    | Chinese
    | Ethiopian
    | Filipino
    | GuamanianOrChamorro
    | Haitian
    | Jamaican
    | Japanese
    | Korean
    | NativeHawaiian
    | NativeHawaiianOrOtherPacificIslander
    | Nigerian
    | OtherAsian
    | OtherBlackOrAfricanAmerican
    | OtherPacificIslander
    | PreferNotToAnswer
    | Samoan
    | Somali
    | Vietnamese
    | White

    type Create'UsCfpbDataRaceDetails = {
        ///<summary>The persons race.</summary>
        [<Config.Form>]Race: Create'UsCfpbDataRaceDetailsRace list option
        ///<summary>Please specify your race, when other is selected.</summary>
        [<Config.Form>]RaceOther: string option
    }
    with
        static member New(?race: Create'UsCfpbDataRaceDetailsRace list, ?raceOther: string) =
            {
                Race = race
                RaceOther = raceOther
            }

    type Create'UsCfpbData = {
        ///<summary>The persons ethnicity details</summary>
        [<Config.Form>]EthnicityDetails: Create'UsCfpbDataEthnicityDetails option
        ///<summary>The persons race details</summary>
        [<Config.Form>]RaceDetails: Create'UsCfpbDataRaceDetails option
        ///<summary>The persons self-identified gender</summary>
        [<Config.Form>]SelfIdentifiedGender: string option
    }
    with
        static member New(?ethnicityDetails: Create'UsCfpbDataEthnicityDetails, ?raceDetails: Create'UsCfpbDataRaceDetails, ?selfIdentifiedGender: string) =
            {
                EthnicityDetails = ethnicityDetails
                RaceDetails = raceDetails
                SelfIdentifiedGender = selfIdentifiedGender
            }

    type Create'VerificationAdditionalDocument = {
        ///<summary>The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Back: string option
        ///<summary>The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'VerificationDocument = {
        ///<summary>The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Back: string option
        ///<summary>The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'Verification = {
        ///<summary>A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.</summary>
        [<Config.Form>]AdditionalDocument: Create'VerificationAdditionalDocument option
        ///<summary>An identifying document, either a passport or local ID card.</summary>
        [<Config.Form>]Document: Create'VerificationDocument option
    }
    with
        static member New(?additionalDocument: Create'VerificationAdditionalDocument, ?document: Create'VerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Create'PoliticalExposure =
    | Existing
    | None'

    type CreateOptions = {
        [<Config.Path>]Account: string
        ///<summary>Details on the legal guardian's or authorizer's acceptance of the required Stripe agreements.</summary>
        [<Config.Form>]AdditionalTosAcceptances: Create'AdditionalTosAcceptances option
        ///<summary>The person's address.</summary>
        [<Config.Form>]Address: Create'Address option
        ///<summary>The Kana variation of the person's address (Japan only).</summary>
        [<Config.Form>]AddressKana: Create'AddressKana option
        ///<summary>The Kanji variation of the person's address (Japan only).</summary>
        [<Config.Form>]AddressKanji: Create'AddressKanji option
        ///<summary>The person's date of birth.</summary>
        [<Config.Form>]Dob: Choice<Create'DobDateOfBirthSpecs,string> option
        ///<summary>Documents that may be submitted to satisfy various informational requests.</summary>
        [<Config.Form>]Documents: Create'Documents option
        ///<summary>The person's email address.</summary>
        [<Config.Form>]Email: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The person's first name.</summary>
        [<Config.Form>]FirstName: string option
        ///<summary>The Kana variation of the person's first name (Japan only).</summary>
        [<Config.Form>]FirstNameKana: string option
        ///<summary>The Kanji variation of the person's first name (Japan only).</summary>
        [<Config.Form>]FirstNameKanji: string option
        ///<summary>A list of alternate names or aliases that the person is known by.</summary>
        [<Config.Form>]FullNameAliases: Choice<string list,string> option
        ///<summary>The person's gender (International regulations require either "male" or "female").</summary>
        [<Config.Form>]Gender: string option
        ///<summary>The person's ID number, as appropriate for their country. For example, a social security number in the U.S., social insurance number in Canada, etc. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://docs.stripe.com/js/tokens/create_token?type=pii).</summary>
        [<Config.Form>]IdNumber: string option
        ///<summary>The person's secondary ID number, as appropriate for their country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://docs.stripe.com/js/tokens/create_token?type=pii).</summary>
        [<Config.Form>]IdNumberSecondary: string option
        ///<summary>The person's last name.</summary>
        [<Config.Form>]LastName: string option
        ///<summary>The Kana variation of the person's last name (Japan only).</summary>
        [<Config.Form>]LastNameKana: string option
        ///<summary>The Kanji variation of the person's last name (Japan only).</summary>
        [<Config.Form>]LastNameKanji: string option
        ///<summary>The person's maiden name.</summary>
        [<Config.Form>]MaidenName: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The country where the person is a national. Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)), or "XX" if unavailable.</summary>
        [<Config.Form>]Nationality: string option
        ///<summary>A [person token](https://docs.stripe.com/connect/account-tokens), used to securely provide details to the person.</summary>
        [<Config.Form>]PersonToken: string option
        ///<summary>The person's phone number.</summary>
        [<Config.Form>]Phone: string option
        ///<summary>Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.</summary>
        [<Config.Form>]PoliticalExposure: Create'PoliticalExposure option
        ///<summary>The person's registered address.</summary>
        [<Config.Form>]RegisteredAddress: Create'RegisteredAddress option
        ///<summary>The relationship that this person has with the account's legal entity.</summary>
        [<Config.Form>]Relationship: Create'Relationship option
        ///<summary>The last four digits of the person's Social Security number (U.S. only).</summary>
        [<Config.Form>]SsnLast4: string option
        ///<summary>Demographic data related to the person.</summary>
        [<Config.Form>]UsCfpbData: Create'UsCfpbData option
        ///<summary>The person's verification status.</summary>
        [<Config.Form>]Verification: Create'Verification option
    }
    with
        static member New(account: string, ?ssnLast4: string, ?relationship: Create'Relationship, ?registeredAddress: Create'RegisteredAddress, ?politicalExposure: Create'PoliticalExposure, ?phone: string, ?personToken: string, ?nationality: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?idNumberSecondary: string, ?idNumber: string, ?gender: string, ?fullNameAliases: Choice<string list,string>, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?expand: string list, ?email: string, ?documents: Create'Documents, ?dob: Choice<Create'DobDateOfBirthSpecs,string>, ?addressKanji: Create'AddressKanji, ?addressKana: Create'AddressKana, ?address: Create'Address, ?additionalTosAcceptances: Create'AdditionalTosAcceptances, ?usCfpbData: Create'UsCfpbData, ?verification: Create'Verification) =
            {
                Account = account
                AdditionalTosAcceptances = additionalTosAcceptances
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Documents = documents
                Email = email
                Expand = expand
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                FullNameAliases = fullNameAliases
                Gender = gender
                IdNumber = idNumber
                IdNumberSecondary = idNumberSecondary
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                Nationality = nationality
                PersonToken = personToken
                Phone = phone
                PoliticalExposure = politicalExposure
                RegisteredAddress = registeredAddress
                Relationship = relationship
                SsnLast4 = ssnLast4
                UsCfpbData = usCfpbData
                Verification = verification
            }

    ///<summary><p>Creates a new person.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/accounts/{options.Account}/persons"
        |> RestApi.postAsync<_, Person> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Account: string
        [<Config.Path>]Person: string
    }
    with
        static member New(account: string, person: string) =
            {
                Account = account
                Person = person
            }

    ///<summary><p>Deletes an existing person’s relationship to the account’s legal entity. Any person with a relationship for an account can be deleted through the API, except if the person is the <code>account_opener</code>. If your integration is using the <code>executive</code> parameter, you cannot delete the only verified <code>executive</code> on file.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/accounts/{options.Account}/persons/{options.Person}"
        |> RestApi.deleteAsync<DeletedPerson> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Account: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Person: string
    }
    with
        static member New(account: string, person: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
                Person = person
            }

    ///<summary><p>Retrieves an existing person.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/accounts/{options.Account}/persons/{options.Person}"
        |> RestApi.getAsync<Person> settings qs

    type Update'AdditionalTosAcceptancesAccount = {
        ///<summary>The Unix timestamp marking when the account representative accepted the service agreement.</summary>
        [<Config.Form>]Date: DateTime option
        ///<summary>The IP address from which the account representative accepted the service agreement.</summary>
        [<Config.Form>]Ip: string option
        ///<summary>The user agent of the browser from which the account representative accepted the service agreement.</summary>
        [<Config.Form>]UserAgent: Choice<string,string> option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: Choice<string,string>) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Update'AdditionalTosAcceptances = {
        ///<summary>Details on the legal guardian's acceptance of the main Stripe service agreement.</summary>
        [<Config.Form>]Account: Update'AdditionalTosAcceptancesAccount option
    }
    with
        static member New(?account: Update'AdditionalTosAcceptancesAccount) =
            {
                Account = account
            }

    type Update'Address = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'AddressKana = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Update'AddressKanji = {
        ///<summary>City or ward.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Block or building number.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Building details.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>Postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>Prefecture.</summary>
        [<Config.Form>]State: string option
        ///<summary>Town or cho-me.</summary>
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Update'DobDateOfBirthSpecs = {
        ///<summary>The day of birth, between 1 and 31.</summary>
        [<Config.Form>]Day: int option
        ///<summary>The month of birth, between 1 and 12.</summary>
        [<Config.Form>]Month: int option
        ///<summary>The four-digit year of birth.</summary>
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Update'DocumentsCompanyAuthorization = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Update'DocumentsPassport = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Update'DocumentsVisa = {
        ///<summary>One or more document ids returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `account_requirement`.</summary>
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Update'Documents = {
        ///<summary>One or more documents that demonstrate proof that this person is authorized to represent the company.</summary>
        [<Config.Form>]CompanyAuthorization: Update'DocumentsCompanyAuthorization option
        ///<summary>One or more documents showing the person's passport page with photo and personal data.</summary>
        [<Config.Form>]Passport: Update'DocumentsPassport option
        ///<summary>One or more documents showing the person's visa required for living in the country where they are residing.</summary>
        [<Config.Form>]Visa: Update'DocumentsVisa option
    }
    with
        static member New(?companyAuthorization: Update'DocumentsCompanyAuthorization, ?passport: Update'DocumentsPassport, ?visa: Update'DocumentsVisa) =
            {
                CompanyAuthorization = companyAuthorization
                Passport = passport
                Visa = visa
            }

    type Update'RegisteredAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'Relationship = {
        ///<summary>Whether the person is the authorizer of the account's representative.</summary>
        [<Config.Form>]Authorizer: bool option
        ///<summary>Whether the person is a director of the account's legal entity. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.</summary>
        [<Config.Form>]Director: bool option
        ///<summary>Whether the person has significant responsibility to control, manage, or direct the organization.</summary>
        [<Config.Form>]Executive: bool option
        ///<summary>Whether the person is the legal guardian of the account's representative.</summary>
        [<Config.Form>]LegalGuardian: bool option
        ///<summary>Whether the person is an owner of the account’s legal entity.</summary>
        [<Config.Form>]Owner: bool option
        ///<summary>The percent owned by the person of the account's legal entity.</summary>
        [<Config.Form>]PercentOwnership: Choice<decimal,string> option
        ///<summary>Whether the person is authorized as the primary representative of the account. This is the person nominated by the business to provide information about themselves, and general information about the account. There can only be one representative at any given time. At the time the account is created, this person should be set to the person responsible for opening the account.</summary>
        [<Config.Form>]Representative: bool option
        ///<summary>The person's title (e.g., CEO, Support Engineer).</summary>
        [<Config.Form>]Title: string option
    }
    with
        static member New(?authorizer: bool, ?director: bool, ?executive: bool, ?legalGuardian: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?representative: bool, ?title: string) =
            {
                Authorizer = authorizer
                Director = director
                Executive = executive
                LegalGuardian = legalGuardian
                Owner = owner
                PercentOwnership = percentOwnership
                Representative = representative
                Title = title
            }

    type Update'UsCfpbDataEthnicityDetailsEthnicity =
    | Cuban
    | HispanicOrLatino
    | Mexican
    | NotHispanicOrLatino
    | OtherHispanicOrLatino
    | PreferNotToAnswer
    | PuertoRican

    type Update'UsCfpbDataEthnicityDetails = {
        ///<summary>The persons ethnicity</summary>
        [<Config.Form>]Ethnicity: Update'UsCfpbDataEthnicityDetailsEthnicity list option
        ///<summary>Please specify your origin, when other is selected.</summary>
        [<Config.Form>]EthnicityOther: string option
    }
    with
        static member New(?ethnicity: Update'UsCfpbDataEthnicityDetailsEthnicity list, ?ethnicityOther: string) =
            {
                Ethnicity = ethnicity
                EthnicityOther = ethnicityOther
            }

    type Update'UsCfpbDataRaceDetailsRace =
    | AfricanAmerican
    | AmericanIndianOrAlaskaNative
    | Asian
    | AsianIndian
    | BlackOrAfricanAmerican
    | Chinese
    | Ethiopian
    | Filipino
    | GuamanianOrChamorro
    | Haitian
    | Jamaican
    | Japanese
    | Korean
    | NativeHawaiian
    | NativeHawaiianOrOtherPacificIslander
    | Nigerian
    | OtherAsian
    | OtherBlackOrAfricanAmerican
    | OtherPacificIslander
    | PreferNotToAnswer
    | Samoan
    | Somali
    | Vietnamese
    | White

    type Update'UsCfpbDataRaceDetails = {
        ///<summary>The persons race.</summary>
        [<Config.Form>]Race: Update'UsCfpbDataRaceDetailsRace list option
        ///<summary>Please specify your race, when other is selected.</summary>
        [<Config.Form>]RaceOther: string option
    }
    with
        static member New(?race: Update'UsCfpbDataRaceDetailsRace list, ?raceOther: string) =
            {
                Race = race
                RaceOther = raceOther
            }

    type Update'UsCfpbData = {
        ///<summary>The persons ethnicity details</summary>
        [<Config.Form>]EthnicityDetails: Update'UsCfpbDataEthnicityDetails option
        ///<summary>The persons race details</summary>
        [<Config.Form>]RaceDetails: Update'UsCfpbDataRaceDetails option
        ///<summary>The persons self-identified gender</summary>
        [<Config.Form>]SelfIdentifiedGender: string option
    }
    with
        static member New(?ethnicityDetails: Update'UsCfpbDataEthnicityDetails, ?raceDetails: Update'UsCfpbDataRaceDetails, ?selfIdentifiedGender: string) =
            {
                EthnicityDetails = ethnicityDetails
                RaceDetails = raceDetails
                SelfIdentifiedGender = selfIdentifiedGender
            }

    type Update'VerificationAdditionalDocument = {
        ///<summary>The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Back: string option
        ///<summary>The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Update'VerificationDocument = {
        ///<summary>The back of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Back: string option
        ///<summary>The front of an ID returned by a [file upload](https://api.stripe.com#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.</summary>
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Update'Verification = {
        ///<summary>A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.</summary>
        [<Config.Form>]AdditionalDocument: Update'VerificationAdditionalDocument option
        ///<summary>An identifying document, either a passport or local ID card.</summary>
        [<Config.Form>]Document: Update'VerificationDocument option
    }
    with
        static member New(?additionalDocument: Update'VerificationAdditionalDocument, ?document: Update'VerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Update'PoliticalExposure =
    | Existing
    | None'

    type UpdateOptions = {
        [<Config.Path>]Account: string
        [<Config.Path>]Person: string
        ///<summary>Details on the legal guardian's or authorizer's acceptance of the required Stripe agreements.</summary>
        [<Config.Form>]AdditionalTosAcceptances: Update'AdditionalTosAcceptances option
        ///<summary>The person's address.</summary>
        [<Config.Form>]Address: Update'Address option
        ///<summary>The Kana variation of the person's address (Japan only).</summary>
        [<Config.Form>]AddressKana: Update'AddressKana option
        ///<summary>The Kanji variation of the person's address (Japan only).</summary>
        [<Config.Form>]AddressKanji: Update'AddressKanji option
        ///<summary>The person's date of birth.</summary>
        [<Config.Form>]Dob: Choice<Update'DobDateOfBirthSpecs,string> option
        ///<summary>Documents that may be submitted to satisfy various informational requests.</summary>
        [<Config.Form>]Documents: Update'Documents option
        ///<summary>The person's email address.</summary>
        [<Config.Form>]Email: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The person's first name.</summary>
        [<Config.Form>]FirstName: string option
        ///<summary>The Kana variation of the person's first name (Japan only).</summary>
        [<Config.Form>]FirstNameKana: string option
        ///<summary>The Kanji variation of the person's first name (Japan only).</summary>
        [<Config.Form>]FirstNameKanji: string option
        ///<summary>A list of alternate names or aliases that the person is known by.</summary>
        [<Config.Form>]FullNameAliases: Choice<string list,string> option
        ///<summary>The person's gender (International regulations require either "male" or "female").</summary>
        [<Config.Form>]Gender: string option
        ///<summary>The person's ID number, as appropriate for their country. For example, a social security number in the U.S., social insurance number in Canada, etc. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://docs.stripe.com/js/tokens/create_token?type=pii).</summary>
        [<Config.Form>]IdNumber: string option
        ///<summary>The person's secondary ID number, as appropriate for their country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://docs.stripe.com/js/tokens/create_token?type=pii).</summary>
        [<Config.Form>]IdNumberSecondary: string option
        ///<summary>The person's last name.</summary>
        [<Config.Form>]LastName: string option
        ///<summary>The Kana variation of the person's last name (Japan only).</summary>
        [<Config.Form>]LastNameKana: string option
        ///<summary>The Kanji variation of the person's last name (Japan only).</summary>
        [<Config.Form>]LastNameKanji: string option
        ///<summary>The person's maiden name.</summary>
        [<Config.Form>]MaidenName: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The country where the person is a national. Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)), or "XX" if unavailable.</summary>
        [<Config.Form>]Nationality: string option
        ///<summary>A [person token](https://docs.stripe.com/connect/account-tokens), used to securely provide details to the person.</summary>
        [<Config.Form>]PersonToken: string option
        ///<summary>The person's phone number.</summary>
        [<Config.Form>]Phone: string option
        ///<summary>Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.</summary>
        [<Config.Form>]PoliticalExposure: Update'PoliticalExposure option
        ///<summary>The person's registered address.</summary>
        [<Config.Form>]RegisteredAddress: Update'RegisteredAddress option
        ///<summary>The relationship that this person has with the account's legal entity.</summary>
        [<Config.Form>]Relationship: Update'Relationship option
        ///<summary>The last four digits of the person's Social Security number (U.S. only).</summary>
        [<Config.Form>]SsnLast4: string option
        ///<summary>Demographic data related to the person.</summary>
        [<Config.Form>]UsCfpbData: Update'UsCfpbData option
        ///<summary>The person's verification status.</summary>
        [<Config.Form>]Verification: Update'Verification option
    }
    with
        static member New(account: string, person: string, ?ssnLast4: string, ?relationship: Update'Relationship, ?registeredAddress: Update'RegisteredAddress, ?politicalExposure: Update'PoliticalExposure, ?phone: string, ?personToken: string, ?nationality: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?idNumberSecondary: string, ?idNumber: string, ?gender: string, ?fullNameAliases: Choice<string list,string>, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?expand: string list, ?email: string, ?documents: Update'Documents, ?dob: Choice<Update'DobDateOfBirthSpecs,string>, ?addressKanji: Update'AddressKanji, ?addressKana: Update'AddressKana, ?address: Update'Address, ?additionalTosAcceptances: Update'AdditionalTosAcceptances, ?usCfpbData: Update'UsCfpbData, ?verification: Update'Verification) =
            {
                Account = account
                Person = person
                AdditionalTosAcceptances = additionalTosAcceptances
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Documents = documents
                Email = email
                Expand = expand
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                FullNameAliases = fullNameAliases
                Gender = gender
                IdNumber = idNumber
                IdNumberSecondary = idNumberSecondary
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                Nationality = nationality
                PersonToken = personToken
                Phone = phone
                PoliticalExposure = politicalExposure
                RegisteredAddress = registeredAddress
                Relationship = relationship
                SsnLast4 = ssnLast4
                UsCfpbData = usCfpbData
                Verification = verification
            }

    ///<summary><p>Updates an existing person.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/accounts/{options.Account}/persons/{options.Person}"
        |> RestApi.postAsync<_, Person> settings (Map.empty) options

module AccountsReject =

    type RejectOptions = {
        [<Config.Path>]Account: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The reason for rejecting the account. Can be `fraud`, `terms_of_service`, or `other`.</summary>
        [<Config.Form>]Reason: string
    }
    with
        static member New(account: string, reason: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
                Reason = reason
            }

    ///<summary><p>With <a href="/connect">Connect</a>, you can reject accounts that you have flagged as suspicious.</p>
    ///<p>Only accounts where your platform is liable for negative account balances, which includes Custom and Express accounts, can be rejected. Test-mode accounts can be rejected at any time. Live-mode accounts can only be rejected after all balances are zero.</p></summary>
    let Reject settings (options: RejectOptions) =
        $"/v1/accounts/{options.Account}/reject"
        |> RestApi.postAsync<_, Account> settings (Map.empty) options

module ApplePayDomains =

    type ListOptions = {
        [<Config.Query>]DomainName: string option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?domainName: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                DomainName = domainName
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>List apple pay domains.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("domain_name", options.DomainName |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/apple_pay/domains"
        |> RestApi.getAsync<StripeList<ApplePayDomain>> settings qs

    type CreateOptions = {
        [<Config.Form>]DomainName: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(domainName: string, ?expand: string list) =
            {
                DomainName = domainName
                Expand = expand
            }

    ///<summary><p>Create an apple pay domain.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/apple_pay/domains"
        |> RestApi.postAsync<_, ApplePayDomain> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Domain: string
    }
    with
        static member New(domain: string) =
            {
                Domain = domain
            }

    ///<summary><p>Delete an apple pay domain.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/apple_pay/domains/{options.Domain}"
        |> RestApi.deleteAsync<DeletedApplePayDomain> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Domain: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(domain: string, ?expand: string list) =
            {
                Domain = domain
                Expand = expand
            }

    ///<summary><p>Retrieve an apple pay domain.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/apple_pay/domains/{options.Domain}"
        |> RestApi.getAsync<ApplePayDomain> settings qs

module ApplicationFees =

    type ListOptions = {
        ///<summary>Only return application fees for the charge specified by this charge ID.</summary>
        [<Config.Query>]Charge: string option
        ///<summary>Only return applications fees that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?charge: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Charge = charge
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of application fees you’ve previously collected. The application fees are returned in sorted order, with the most recent fees appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("charge", options.Charge |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/application_fees"
        |> RestApi.getAsync<StripeList<ApplicationFee>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves the details of an application fee that your account has collected. The same information is returned when refunding the application fee.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/application_fees/{options.Id}"
        |> RestApi.getAsync<ApplicationFee> settings qs

module ApplicationFeesRefunds =

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Fee: string
        [<Config.Path>]Id: string
    }
    with
        static member New(fee: string, id: string, ?expand: string list) =
            {
                Expand = expand
                Fee = fee
                Id = id
            }

    ///<summary><p>By default, you can see the 10 most recent refunds stored directly on the application fee object, but you can also retrieve details about a specific refund stored on the application fee.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/application_fees/{options.Fee}/refunds/{options.Id}"
        |> RestApi.getAsync<FeeRefund> settings qs

    type UpdateOptions = {
        [<Config.Path>]Fee: string
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(fee: string, id: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Fee = fee
                Id = id
                Expand = expand
                Metadata = metadata
            }

    ///<summary><p>Updates the specified application fee refund by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    ///<p>This request only accepts metadata as an argument.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/application_fees/{options.Fee}/refunds/{options.Id}"
        |> RestApi.postAsync<_, FeeRefund> settings (Map.empty) options

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(id: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Id = id
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>You can see a list of the refunds belonging to a specific application fee. Note that the 10 most recent refunds are always available by default on the application fee object. If you need more than those 10, you can use this API method and the <code>limit</code> and <code>starting_after</code> parameters to page through additional refunds.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/application_fees/{options.Id}/refunds"
        |> RestApi.getAsync<StripeList<FeeRefund>> settings qs

    type CreateOptions = {
        [<Config.Path>]Id: string
        ///<summary>A positive integer, in _cents (or local equivalent)_, representing how much of this fee to refund. Can refund only up to the remaining unrefunded amount of the fee.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(id: string, ?amount: int, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Id = id
                Amount = amount
                Expand = expand
                Metadata = metadata
            }

    ///<summary><p>Refunds an application fee that has previously been collected but not yet refunded.
    ///Funds will be refunded to the Stripe account from which the fee was originally collected.</p>
    ///<p>You can optionally refund only part of an application fee.
    ///You can do so multiple times, until the entire fee has been refunded.</p>
    ///<p>Once entirely refunded, an application fee can’t be refunded again.
    ///This method will raise an error when called on an already-refunded application fee,
    ///or when trying to refund more money than is left on an application fee.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/application_fees/{options.Id}/refunds"
        |> RestApi.postAsync<_, FeeRefund> settings (Map.empty) options

module AppsSecrets =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Specifies the scoping of the secret. Requests originating from UI extensions can only access account-scoped secrets or secrets scoped to their own user.</summary>
        [<Config.Query>]Scope: Map<string, string>
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(scope: Map<string, string>, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Scope = scope
                StartingAfter = startingAfter
            }

    ///<summary><p>List all secrets stored on the given scope.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("scope", options.Scope |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/apps/secrets"
        |> RestApi.getAsync<StripeList<AppsSecret>> settings qs

    type Create'ScopeType =
    | Account
    | User

    type Create'Scope = {
        ///<summary>The secret scope type.</summary>
        [<Config.Form>]Type: Create'ScopeType option
        ///<summary>The user ID. This field is required if `type` is set to `user`, and should not be provided if `type` is set to `account`.</summary>
        [<Config.Form>]User: string option
    }
    with
        static member New(?type': Create'ScopeType, ?user: string) =
            {
                Type = type'
                User = user
            }

    type CreateOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The Unix timestamp for the expiry time of the secret, after which the secret deletes.</summary>
        [<Config.Form>]ExpiresAt: DateTime option
        ///<summary>A name for the secret that's unique within the scope.</summary>
        [<Config.Form>]Name: string
        ///<summary>The plaintext secret value to be stored.</summary>
        [<Config.Form>]Payload: string
        ///<summary>Specifies the scoping of the secret. Requests originating from UI extensions can only access account-scoped secrets or secrets scoped to their own user.</summary>
        [<Config.Form>]Scope: Create'Scope
    }
    with
        static member New(name: string, payload: string, scope: Create'Scope, ?expand: string list, ?expiresAt: DateTime) =
            {
                Expand = expand
                ExpiresAt = expiresAt
                Name = name
                Payload = payload
                Scope = scope
            }

    ///<summary><p>Create or replace a secret in the secret store.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/apps/secrets"
        |> RestApi.postAsync<_, AppsSecret> settings (Map.empty) options

module AppsSecretsDelete =

    type DeleteWhere'ScopeType =
    | Account
    | User

    type DeleteWhere'Scope = {
        ///<summary>The secret scope type.</summary>
        [<Config.Form>]Type: DeleteWhere'ScopeType option
        ///<summary>The user ID. This field is required if `type` is set to `user`, and should not be provided if `type` is set to `account`.</summary>
        [<Config.Form>]User: string option
    }
    with
        static member New(?type': DeleteWhere'ScopeType, ?user: string) =
            {
                Type = type'
                User = user
            }

    type DeleteWhereOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A name for the secret that's unique within the scope.</summary>
        [<Config.Form>]Name: string
        ///<summary>Specifies the scoping of the secret. Requests originating from UI extensions can only access account-scoped secrets or secrets scoped to their own user.</summary>
        [<Config.Form>]Scope: DeleteWhere'Scope
    }
    with
        static member New(name: string, scope: DeleteWhere'Scope, ?expand: string list) =
            {
                Expand = expand
                Name = name
                Scope = scope
            }

    ///<summary><p>Deletes a secret from the secret store by name and scope.</p></summary>
    let DeleteWhere settings (options: DeleteWhereOptions) =
        $"/v1/apps/secrets/delete"
        |> RestApi.postAsync<_, AppsSecret> settings (Map.empty) options

module AppsSecretsFind =

    type FindOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A name for the secret that's unique within the scope.</summary>
        [<Config.Query>]Name: string
        ///<summary>Specifies the scoping of the secret. Requests originating from UI extensions can only access account-scoped secrets or secrets scoped to their own user.</summary>
        [<Config.Query>]Scope: Map<string, string>
    }
    with
        static member New(name: string, scope: Map<string, string>, ?expand: string list) =
            {
                Expand = expand
                Name = name
                Scope = scope
            }

    ///<summary><p>Finds a secret in the secret store by name and scope.</p></summary>
    let Find settings (options: FindOptions) =
        let qs = [("expand", options.Expand |> box); ("name", options.Name |> box); ("scope", options.Scope |> box)] |> Map.ofList
        $"/v1/apps/secrets/find"
        |> RestApi.getAsync<AppsSecret> settings qs
