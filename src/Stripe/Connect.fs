namespace Stripe.Connect

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type ConnectEmbeddedPayoutsFeatures =
    {
        /// Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.
        DisableStripeUserAuthentication: bool
        /// Whether to allow payout schedule to be changed. Defaults to `true` when `controller.losses.payments` is set to `stripe` for the account, otherwise `false`.
        EditPayoutSchedule: bool
        /// Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.
        ExternalAccountCollection: bool
        /// Whether to allow creation of instant payouts. The default value is `enabled` when Stripe is responsible for negative account balances, and `use_dashboard_rules` otherwise.
        InstantPayouts: bool
        /// Whether to allow creation of standard payouts. Defaults to `true` when `controller.losses.payments` is set to `stripe` for the account, otherwise `false`.
        StandardPayouts: bool
    }

type ConnectEmbeddedPayoutsConfig =
    {
        /// Whether the embedded component is enabled.
        Enabled: bool
        Features: ConnectEmbeddedPayoutsFeatures
    }

type ConnectEmbeddedPaymentsFeatures =
    {
        /// Whether to allow capturing and cancelling payment intents. This is `true` by default.
        CapturePayments: bool
        /// Whether connected accounts can manage destination charges that are created on behalf of them. This is `false` by default.
        DestinationOnBehalfOfChargeManagement: bool
        /// Whether responding to disputes is enabled, including submitting evidence and accepting disputes. This is `true` by default.
        DisputeManagement: bool
        /// Whether sending refunds is enabled. This is `true` by default.
        RefundManagement: bool
    }

type ConnectEmbeddedPaymentsConfigClaim =
    {
        /// Whether the embedded component is enabled.
        Enabled: bool
        Features: ConnectEmbeddedPaymentsFeatures
    }

type ConnectEmbeddedPaymentDisputesFeatures =
    {
        /// Whether connected accounts can manage destination charges that are created on behalf of them. This is `false` by default.
        DestinationOnBehalfOfChargeManagement: bool
        /// Whether responding to disputes is enabled, including submitting evidence and accepting disputes. This is `true` by default.
        DisputeManagement: bool
        /// Whether sending refunds is enabled. This is `true` by default.
        RefundManagement: bool
    }

type ConnectEmbeddedPaymentDisputesConfig =
    {
        /// Whether the embedded component is enabled.
        Enabled: bool
        Features: ConnectEmbeddedPaymentDisputesFeatures
    }

type ConnectEmbeddedIssuingCardsListFeatures =
    {
        /// Whether to allow card management features.
        CardManagement: bool
        /// Whether to allow card spend dispute management features.
        CardSpendDisputeManagement: bool
        /// Whether to allow cardholder management features.
        CardholderManagement: bool
        /// Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.
        DisableStripeUserAuthentication: bool
        /// Whether to allow spend control management features.
        SpendControlManagement: bool
    }

type ConnectEmbeddedIssuingCardsListConfigClaim =
    {
        /// Whether the embedded component is enabled.
        Enabled: bool
        Features: ConnectEmbeddedIssuingCardsListFeatures
    }

type ConnectEmbeddedIssuingCardFeatures =
    {
        /// Whether to allow card management features.
        CardManagement: bool
        /// Whether to allow card spend dispute management features.
        CardSpendDisputeManagement: bool
        /// Whether to allow cardholder management features.
        CardholderManagement: bool
        /// Whether to allow spend control management features.
        SpendControlManagement: bool
    }

type ConnectEmbeddedIssuingCardConfigClaim =
    {
        /// Whether the embedded component is enabled.
        Enabled: bool
        Features: ConnectEmbeddedIssuingCardFeatures
    }

type ConnectEmbeddedInstantPayoutsPromotionFeatures =
    {
        /// Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.
        DisableStripeUserAuthentication: bool
        /// Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.
        ExternalAccountCollection: bool
        /// Whether to allow creation of instant payouts. The default value is `enabled` when Stripe is responsible for negative account balances, and `use_dashboard_rules` otherwise.
        InstantPayouts: bool
    }

type ConnectEmbeddedInstantPayoutsPromotionConfig =
    {
        /// Whether the embedded component is enabled.
        Enabled: bool
        Features: ConnectEmbeddedInstantPayoutsPromotionFeatures
    }

type ConnectEmbeddedFinancialAccountTransactionsFeatures =
    {
        /// Whether to allow card spend dispute management features.
        CardSpendDisputeManagement: bool
    }

type ConnectEmbeddedFinancialAccountTransactionsConfigClaim =
    {
        /// Whether the embedded component is enabled.
        Enabled: bool
        Features: ConnectEmbeddedFinancialAccountTransactionsFeatures
    }

type ConnectEmbeddedFinancialAccountFeatures =
    {
        /// Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.
        DisableStripeUserAuthentication: bool
        /// Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.
        ExternalAccountCollection: bool
        /// Whether to allow sending money.
        SendMoney: bool
        /// Whether to allow transferring balance.
        TransferBalance: bool
    }

type ConnectEmbeddedFinancialAccountConfigClaim =
    {
        /// Whether the embedded component is enabled.
        Enabled: bool
        Features: ConnectEmbeddedFinancialAccountFeatures
    }

type ConnectEmbeddedDisputesListFeatures =
    {
        /// Whether to allow capturing and cancelling payment intents. This is `true` by default.
        CapturePayments: bool
        /// Whether connected accounts can manage destination charges that are created on behalf of them. This is `false` by default.
        DestinationOnBehalfOfChargeManagement: bool
        /// Whether responding to disputes is enabled, including submitting evidence and accepting disputes. This is `true` by default.
        DisputeManagement: bool
        /// Whether sending refunds is enabled. This is `true` by default.
        RefundManagement: bool
    }

type ConnectEmbeddedDisputesListConfig =
    {
        /// Whether the embedded component is enabled.
        Enabled: bool
        Features: ConnectEmbeddedDisputesListFeatures
    }

type ConnectEmbeddedBaseFeatures =
    { ConnectEmbeddedBaseFeatures: string option }

type ConnectEmbeddedBaseConfigClaim =
    {
        /// Whether the embedded component is enabled.
        Enabled: bool
        Features: ConnectEmbeddedBaseFeatures
    }

type ConnectEmbeddedAccountFeaturesClaim =
    {
        /// Whether Stripe user authentication is disabled. This value can only be `true` for accounts where `controller.requirement_collection` is `application` for the account. The default value is the opposite of the `external_account_collection` value. For example, if you don't set `external_account_collection`, it defaults to `true` and `disable_stripe_user_authentication` defaults to `false`.
        DisableStripeUserAuthentication: bool
        /// Whether external account collection is enabled. This feature can only be `false` for accounts where you’re responsible for collecting updated information when requirements are due or change, like Custom accounts. The default value for this feature is `true`.
        ExternalAccountCollection: bool
    }

type ConnectEmbeddedAccountConfigClaim =
    {
        /// Whether the embedded component is enabled.
        Enabled: bool
        Features: ConnectEmbeddedAccountFeaturesClaim
    }

