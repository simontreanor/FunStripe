namespace Stripe.Event

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type EventType =
    | [<JsonPropertyName("account.application.authorized")>] AccountApplicationAuthorized
    | [<JsonPropertyName("account.application.deauthorized")>] AccountApplicationDeauthorized
    | [<JsonPropertyName("account.external_account.created")>] AccountExternalAccountCreated
    | [<JsonPropertyName("account.external_account.deleted")>] AccountExternalAccountDeleted
    | [<JsonPropertyName("account.external_account.updated")>] AccountExternalAccountUpdated
    | [<JsonPropertyName("account.updated")>] AccountUpdated
    | [<JsonPropertyName("application_fee.created")>] ApplicationFeeCreated
    | [<JsonPropertyName("application_fee.refund.updated")>] ApplicationFeeRefundUpdated
    | [<JsonPropertyName("application_fee.refunded")>] ApplicationFeeRefunded
    | [<JsonPropertyName("balance.available")>] BalanceAvailable
    | [<JsonPropertyName("balance_settings.updated")>] BalanceSettingsUpdated
    | [<JsonPropertyName("billing.alert.triggered")>] BillingAlertTriggered
    | [<JsonPropertyName("billing.credit_grant.created")>] BillingCreditGrantCreated
    | [<JsonPropertyName("billing_portal.configuration.created")>] BillingPortalConfigurationCreated
    | [<JsonPropertyName("billing_portal.configuration.updated")>] BillingPortalConfigurationUpdated
    | [<JsonPropertyName("billing_portal.session.created")>] BillingPortalSessionCreated
    | [<JsonPropertyName("capability.updated")>] CapabilityUpdated
    | [<JsonPropertyName("cash_balance.funds_available")>] CashBalanceFundsAvailable
    | [<JsonPropertyName("charge.captured")>] ChargeCaptured
    | [<JsonPropertyName("charge.dispute.closed")>] ChargeDisputeClosed
    | [<JsonPropertyName("charge.dispute.created")>] ChargeDisputeCreated
    | [<JsonPropertyName("charge.dispute.funds_reinstated")>] ChargeDisputeFundsReinstated
    | [<JsonPropertyName("charge.dispute.funds_withdrawn")>] ChargeDisputeFundsWithdrawn
    | [<JsonPropertyName("charge.dispute.updated")>] ChargeDisputeUpdated
    | [<JsonPropertyName("charge.expired")>] ChargeExpired
    | [<JsonPropertyName("charge.failed")>] ChargeFailed
    | [<JsonPropertyName("charge.pending")>] ChargePending
    | [<JsonPropertyName("charge.refund.updated")>] ChargeRefundUpdated
    | [<JsonPropertyName("charge.refunded")>] ChargeRefunded
    | [<JsonPropertyName("charge.succeeded")>] ChargeSucceeded
    | [<JsonPropertyName("charge.updated")>] ChargeUpdated
    | [<JsonPropertyName("checkout.session.async_payment_failed")>] CheckoutSessionAsyncPaymentFailed
    | [<JsonPropertyName("checkout.session.async_payment_succeeded")>] CheckoutSessionAsyncPaymentSucceeded
    | [<JsonPropertyName("checkout.session.completed")>] CheckoutSessionCompleted
    | [<JsonPropertyName("checkout.session.expired")>] CheckoutSessionExpired
    | [<JsonPropertyName("climate.order.canceled")>] ClimateOrderCanceled
    | [<JsonPropertyName("climate.order.created")>] ClimateOrderCreated
    | [<JsonPropertyName("climate.order.delayed")>] ClimateOrderDelayed
    | [<JsonPropertyName("climate.order.delivered")>] ClimateOrderDelivered
    | [<JsonPropertyName("climate.order.product_substituted")>] ClimateOrderProductSubstituted
    | [<JsonPropertyName("climate.product.created")>] ClimateProductCreated
    | [<JsonPropertyName("climate.product.pricing_updated")>] ClimateProductPricingUpdated
    | [<JsonPropertyName("coupon.created")>] CouponCreated
    | [<JsonPropertyName("coupon.deleted")>] CouponDeleted
    | [<JsonPropertyName("coupon.updated")>] CouponUpdated
    | [<JsonPropertyName("credit_note.created")>] CreditNoteCreated
    | [<JsonPropertyName("credit_note.updated")>] CreditNoteUpdated
    | [<JsonPropertyName("credit_note.voided")>] CreditNoteVoided
    | [<JsonPropertyName("customer.created")>] CustomerCreated
    | [<JsonPropertyName("customer.deleted")>] CustomerDeleted
    | [<JsonPropertyName("customer.discount.created")>] CustomerDiscountCreated
    | [<JsonPropertyName("customer.discount.deleted")>] CustomerDiscountDeleted
    | [<JsonPropertyName("customer.discount.updated")>] CustomerDiscountUpdated
    | [<JsonPropertyName("customer.source.created")>] CustomerSourceCreated
    | [<JsonPropertyName("customer.source.deleted")>] CustomerSourceDeleted
    | [<JsonPropertyName("customer.source.expiring")>] CustomerSourceExpiring
    | [<JsonPropertyName("customer.source.updated")>] CustomerSourceUpdated
    | [<JsonPropertyName("customer.subscription.created")>] CustomerSubscriptionCreated
    | [<JsonPropertyName("customer.subscription.deleted")>] CustomerSubscriptionDeleted
    | [<JsonPropertyName("customer.subscription.paused")>] CustomerSubscriptionPaused
    | [<JsonPropertyName("customer.subscription.pending_update_applied")>] CustomerSubscriptionPendingUpdateApplied
    | [<JsonPropertyName("customer.subscription.pending_update_expired")>] CustomerSubscriptionPendingUpdateExpired
    | [<JsonPropertyName("customer.subscription.resumed")>] CustomerSubscriptionResumed
    | [<JsonPropertyName("customer.subscription.trial_will_end")>] CustomerSubscriptionTrialWillEnd
    | [<JsonPropertyName("customer.subscription.updated")>] CustomerSubscriptionUpdated
    | [<JsonPropertyName("customer.tax_id.created")>] CustomerTaxIdCreated
    | [<JsonPropertyName("customer.tax_id.deleted")>] CustomerTaxIdDeleted
    | [<JsonPropertyName("customer.tax_id.updated")>] CustomerTaxIdUpdated
    | [<JsonPropertyName("customer.updated")>] CustomerUpdated
    | [<JsonPropertyName("customer_cash_balance_transaction.created")>] CustomerCashBalanceTransactionCreated
    | [<JsonPropertyName("entitlements.active_entitlement_summary.updated")>] EntitlementsActiveEntitlementSummaryUpdated
    | [<JsonPropertyName("file.created")>] FileCreated
    | [<JsonPropertyName("financial_connections.account.account_numbers_updated")>] FinancialConnectionsAccountAccountNumbersUpdated
    | [<JsonPropertyName("financial_connections.account.created")>] FinancialConnectionsAccountCreated
    | [<JsonPropertyName("financial_connections.account.deactivated")>] FinancialConnectionsAccountDeactivated
    | [<JsonPropertyName("financial_connections.account.disconnected")>] FinancialConnectionsAccountDisconnected
    | [<JsonPropertyName("financial_connections.account.reactivated")>] FinancialConnectionsAccountReactivated
    | [<JsonPropertyName("financial_connections.account.refreshed_balance")>] FinancialConnectionsAccountRefreshedBalance
    | [<JsonPropertyName("financial_connections.account.refreshed_ownership")>] FinancialConnectionsAccountRefreshedOwnership
    | [<JsonPropertyName("financial_connections.account.refreshed_transactions")>] FinancialConnectionsAccountRefreshedTransactions
    | [<JsonPropertyName("financial_connections.account.upcoming_account_number_expiry")>] FinancialConnectionsAccountUpcomingAccountNumberExpiry
    | [<JsonPropertyName("identity.verification_session.canceled")>] IdentityVerificationSessionCanceled
    | [<JsonPropertyName("identity.verification_session.created")>] IdentityVerificationSessionCreated
    | [<JsonPropertyName("identity.verification_session.processing")>] IdentityVerificationSessionProcessing
    | [<JsonPropertyName("identity.verification_session.redacted")>] IdentityVerificationSessionRedacted
    | [<JsonPropertyName("identity.verification_session.requires_input")>] IdentityVerificationSessionRequiresInput
    | [<JsonPropertyName("identity.verification_session.verified")>] IdentityVerificationSessionVerified
    | [<JsonPropertyName("invoice.created")>] InvoiceCreated
    | [<JsonPropertyName("invoice.deleted")>] InvoiceDeleted
    | [<JsonPropertyName("invoice.finalization_failed")>] InvoiceFinalizationFailed
    | [<JsonPropertyName("invoice.finalized")>] InvoiceFinalized
    | [<JsonPropertyName("invoice.marked_uncollectible")>] InvoiceMarkedUncollectible
    | [<JsonPropertyName("invoice.overdue")>] InvoiceOverdue
    | [<JsonPropertyName("invoice.overpaid")>] InvoiceOverpaid
    | [<JsonPropertyName("invoice.paid")>] InvoicePaid
    | [<JsonPropertyName("invoice.payment_action_required")>] InvoicePaymentActionRequired
    | [<JsonPropertyName("invoice.payment_attempt_required")>] InvoicePaymentAttemptRequired
    | [<JsonPropertyName("invoice.payment_failed")>] InvoicePaymentFailed
    | [<JsonPropertyName("invoice.payment_succeeded")>] InvoicePaymentSucceeded
    | [<JsonPropertyName("invoice.sent")>] InvoiceSent
    | [<JsonPropertyName("invoice.upcoming")>] InvoiceUpcoming
    | [<JsonPropertyName("invoice.updated")>] InvoiceUpdated
    | [<JsonPropertyName("invoice.voided")>] InvoiceVoided
    | [<JsonPropertyName("invoice.will_be_due")>] InvoiceWillBeDue
    | [<JsonPropertyName("invoice_payment.paid")>] InvoicePaymentPaid
    | [<JsonPropertyName("invoiceitem.created")>] InvoiceitemCreated
    | [<JsonPropertyName("invoiceitem.deleted")>] InvoiceitemDeleted
    | [<JsonPropertyName("issuing_authorization.created")>] IssuingAuthorizationCreated
    | [<JsonPropertyName("issuing_authorization.request")>] IssuingAuthorizationRequest
    | [<JsonPropertyName("issuing_authorization.updated")>] IssuingAuthorizationUpdated
    | [<JsonPropertyName("issuing_card.created")>] IssuingCardCreated
    | [<JsonPropertyName("issuing_card.updated")>] IssuingCardUpdated
    | [<JsonPropertyName("issuing_cardholder.created")>] IssuingCardholderCreated
    | [<JsonPropertyName("issuing_cardholder.updated")>] IssuingCardholderUpdated
    | [<JsonPropertyName("issuing_dispute.closed")>] IssuingDisputeClosed
    | [<JsonPropertyName("issuing_dispute.created")>] IssuingDisputeCreated
    | [<JsonPropertyName("issuing_dispute.funds_reinstated")>] IssuingDisputeFundsReinstated
    | [<JsonPropertyName("issuing_dispute.funds_rescinded")>] IssuingDisputeFundsRescinded
    | [<JsonPropertyName("issuing_dispute.submitted")>] IssuingDisputeSubmitted
    | [<JsonPropertyName("issuing_dispute.updated")>] IssuingDisputeUpdated
    | [<JsonPropertyName("issuing_personalization_design.activated")>] IssuingPersonalizationDesignActivated
    | [<JsonPropertyName("issuing_personalization_design.deactivated")>] IssuingPersonalizationDesignDeactivated
    | [<JsonPropertyName("issuing_personalization_design.rejected")>] IssuingPersonalizationDesignRejected
    | [<JsonPropertyName("issuing_personalization_design.updated")>] IssuingPersonalizationDesignUpdated
    | [<JsonPropertyName("issuing_token.created")>] IssuingTokenCreated
    | [<JsonPropertyName("issuing_token.updated")>] IssuingTokenUpdated
    | [<JsonPropertyName("issuing_transaction.created")>] IssuingTransactionCreated
    | [<JsonPropertyName("issuing_transaction.purchase_details_receipt_updated")>] IssuingTransactionPurchaseDetailsReceiptUpdated
    | [<JsonPropertyName("issuing_transaction.updated")>] IssuingTransactionUpdated
    | [<JsonPropertyName("mandate.updated")>] MandateUpdated
    | [<JsonPropertyName("payment_intent.amount_capturable_updated")>] PaymentIntentAmountCapturableUpdated
    | [<JsonPropertyName("payment_intent.canceled")>] PaymentIntentCanceled
    | [<JsonPropertyName("payment_intent.created")>] PaymentIntentCreated
    | [<JsonPropertyName("payment_intent.partially_funded")>] PaymentIntentPartiallyFunded
    | [<JsonPropertyName("payment_intent.payment_failed")>] PaymentIntentPaymentFailed
    | [<JsonPropertyName("payment_intent.processing")>] PaymentIntentProcessing
    | [<JsonPropertyName("payment_intent.requires_action")>] PaymentIntentRequiresAction
    | [<JsonPropertyName("payment_intent.succeeded")>] PaymentIntentSucceeded
    | [<JsonPropertyName("payment_link.created")>] PaymentLinkCreated
    | [<JsonPropertyName("payment_link.updated")>] PaymentLinkUpdated
    | [<JsonPropertyName("payment_method.attached")>] PaymentMethodAttached
    | [<JsonPropertyName("payment_method.automatically_updated")>] PaymentMethodAutomaticallyUpdated
    | [<JsonPropertyName("payment_method.detached")>] PaymentMethodDetached
    | [<JsonPropertyName("payment_method.updated")>] PaymentMethodUpdated
    | [<JsonPropertyName("payout.canceled")>] PayoutCanceled
    | [<JsonPropertyName("payout.created")>] PayoutCreated
    | [<JsonPropertyName("payout.failed")>] PayoutFailed
    | [<JsonPropertyName("payout.paid")>] PayoutPaid
    | [<JsonPropertyName("payout.reconciliation_completed")>] PayoutReconciliationCompleted
    | [<JsonPropertyName("payout.updated")>] PayoutUpdated
    | [<JsonPropertyName("person.created")>] PersonCreated
    | [<JsonPropertyName("person.deleted")>] PersonDeleted
    | [<JsonPropertyName("person.updated")>] PersonUpdated
    | [<JsonPropertyName("plan.created")>] PlanCreated
    | [<JsonPropertyName("plan.deleted")>] PlanDeleted
    | [<JsonPropertyName("plan.updated")>] PlanUpdated
    | [<JsonPropertyName("price.created")>] PriceCreated
    | [<JsonPropertyName("price.deleted")>] PriceDeleted
    | [<JsonPropertyName("price.updated")>] PriceUpdated
    | [<JsonPropertyName("product.created")>] ProductCreated
    | [<JsonPropertyName("product.deleted")>] ProductDeleted
    | [<JsonPropertyName("product.updated")>] ProductUpdated
    | [<JsonPropertyName("promotion_code.created")>] PromotionCodeCreated
    | [<JsonPropertyName("promotion_code.updated")>] PromotionCodeUpdated
    | [<JsonPropertyName("quote.accepted")>] QuoteAccepted
    | [<JsonPropertyName("quote.canceled")>] QuoteCanceled
    | [<JsonPropertyName("quote.created")>] QuoteCreated
    | [<JsonPropertyName("quote.finalized")>] QuoteFinalized
    | [<JsonPropertyName("radar.early_fraud_warning.created")>] RadarEarlyFraudWarningCreated
    | [<JsonPropertyName("radar.early_fraud_warning.updated")>] RadarEarlyFraudWarningUpdated
    | [<JsonPropertyName("refund.created")>] RefundCreated
    | [<JsonPropertyName("refund.failed")>] RefundFailed
    | [<JsonPropertyName("refund.updated")>] RefundUpdated
    | [<JsonPropertyName("reporting.report_run.failed")>] ReportingReportRunFailed
    | [<JsonPropertyName("reporting.report_run.succeeded")>] ReportingReportRunSucceeded
    | [<JsonPropertyName("reporting.report_type.updated")>] ReportingReportTypeUpdated
    | [<JsonPropertyName("reserve.hold.created")>] ReserveHoldCreated
    | [<JsonPropertyName("reserve.hold.updated")>] ReserveHoldUpdated
    | [<JsonPropertyName("reserve.plan.created")>] ReservePlanCreated
    | [<JsonPropertyName("reserve.plan.disabled")>] ReservePlanDisabled
    | [<JsonPropertyName("reserve.plan.expired")>] ReservePlanExpired
    | [<JsonPropertyName("reserve.plan.updated")>] ReservePlanUpdated
    | [<JsonPropertyName("reserve.release.created")>] ReserveReleaseCreated
    | [<JsonPropertyName("review.closed")>] ReviewClosed
    | [<JsonPropertyName("review.opened")>] ReviewOpened
    | [<JsonPropertyName("setup_intent.canceled")>] SetupIntentCanceled
    | [<JsonPropertyName("setup_intent.created")>] SetupIntentCreated
    | [<JsonPropertyName("setup_intent.requires_action")>] SetupIntentRequiresAction
    | [<JsonPropertyName("setup_intent.setup_failed")>] SetupIntentSetupFailed
    | [<JsonPropertyName("setup_intent.succeeded")>] SetupIntentSucceeded
    | [<JsonPropertyName("sigma.scheduled_query_run.created")>] SigmaScheduledQueryRunCreated
    | [<JsonPropertyName("source.canceled")>] SourceCanceled
    | [<JsonPropertyName("source.chargeable")>] SourceChargeable
    | [<JsonPropertyName("source.failed")>] SourceFailed
    | [<JsonPropertyName("source.mandate_notification")>] SourceMandateNotification
    | [<JsonPropertyName("source.refund_attributes_required")>] SourceRefundAttributesRequired
    | [<JsonPropertyName("source.transaction.created")>] SourceTransactionCreated
    | [<JsonPropertyName("source.transaction.updated")>] SourceTransactionUpdated
    | [<JsonPropertyName("subscription_schedule.aborted")>] SubscriptionScheduleAborted
    | [<JsonPropertyName("subscription_schedule.canceled")>] SubscriptionScheduleCanceled
    | [<JsonPropertyName("subscription_schedule.completed")>] SubscriptionScheduleCompleted
    | [<JsonPropertyName("subscription_schedule.created")>] SubscriptionScheduleCreated
    | [<JsonPropertyName("subscription_schedule.expiring")>] SubscriptionScheduleExpiring
    | [<JsonPropertyName("subscription_schedule.released")>] SubscriptionScheduleReleased
    | [<JsonPropertyName("subscription_schedule.updated")>] SubscriptionScheduleUpdated
    | [<JsonPropertyName("tax.settings.updated")>] TaxSettingsUpdated
    | [<JsonPropertyName("tax_rate.created")>] TaxRateCreated
    | [<JsonPropertyName("tax_rate.updated")>] TaxRateUpdated
    | [<JsonPropertyName("terminal.reader.action_failed")>] TerminalReaderActionFailed
    | [<JsonPropertyName("terminal.reader.action_succeeded")>] TerminalReaderActionSucceeded
    | [<JsonPropertyName("terminal.reader.action_updated")>] TerminalReaderActionUpdated
    | [<JsonPropertyName("test_helpers.test_clock.advancing")>] TestHelpersTestClockAdvancing
    | [<JsonPropertyName("test_helpers.test_clock.created")>] TestHelpersTestClockCreated
    | [<JsonPropertyName("test_helpers.test_clock.deleted")>] TestHelpersTestClockDeleted
    | [<JsonPropertyName("test_helpers.test_clock.internal_failure")>] TestHelpersTestClockInternalFailure
    | [<JsonPropertyName("test_helpers.test_clock.ready")>] TestHelpersTestClockReady
    | [<JsonPropertyName("topup.canceled")>] TopupCanceled
    | [<JsonPropertyName("topup.created")>] TopupCreated
    | [<JsonPropertyName("topup.failed")>] TopupFailed
    | [<JsonPropertyName("topup.reversed")>] TopupReversed
    | [<JsonPropertyName("topup.succeeded")>] TopupSucceeded
    | [<JsonPropertyName("transfer.created")>] TransferCreated
    | [<JsonPropertyName("transfer.reversed")>] TransferReversed
    | [<JsonPropertyName("transfer.updated")>] TransferUpdated
    | [<JsonPropertyName("treasury.credit_reversal.created")>] TreasuryCreditReversalCreated
    | [<JsonPropertyName("treasury.credit_reversal.posted")>] TreasuryCreditReversalPosted
    | [<JsonPropertyName("treasury.debit_reversal.completed")>] TreasuryDebitReversalCompleted
    | [<JsonPropertyName("treasury.debit_reversal.created")>] TreasuryDebitReversalCreated
    | [<JsonPropertyName("treasury.debit_reversal.initial_credit_granted")>] TreasuryDebitReversalInitialCreditGranted
    | [<JsonPropertyName("treasury.financial_account.closed")>] TreasuryFinancialAccountClosed
    | [<JsonPropertyName("treasury.financial_account.created")>] TreasuryFinancialAccountCreated
    | [<JsonPropertyName("treasury.financial_account.features_status_updated")>] TreasuryFinancialAccountFeaturesStatusUpdated
    | [<JsonPropertyName("treasury.inbound_transfer.canceled")>] TreasuryInboundTransferCanceled
    | [<JsonPropertyName("treasury.inbound_transfer.created")>] TreasuryInboundTransferCreated
    | [<JsonPropertyName("treasury.inbound_transfer.failed")>] TreasuryInboundTransferFailed
    | [<JsonPropertyName("treasury.inbound_transfer.succeeded")>] TreasuryInboundTransferSucceeded
    | [<JsonPropertyName("treasury.outbound_payment.canceled")>] TreasuryOutboundPaymentCanceled
    | [<JsonPropertyName("treasury.outbound_payment.created")>] TreasuryOutboundPaymentCreated
    | [<JsonPropertyName("treasury.outbound_payment.expected_arrival_date_updated")>] TreasuryOutboundPaymentExpectedArrivalDateUpdated
    | [<JsonPropertyName("treasury.outbound_payment.failed")>] TreasuryOutboundPaymentFailed
    | [<JsonPropertyName("treasury.outbound_payment.posted")>] TreasuryOutboundPaymentPosted
    | [<JsonPropertyName("treasury.outbound_payment.returned")>] TreasuryOutboundPaymentReturned
    | [<JsonPropertyName("treasury.outbound_payment.tracking_details_updated")>] TreasuryOutboundPaymentTrackingDetailsUpdated
    | [<JsonPropertyName("treasury.outbound_transfer.canceled")>] TreasuryOutboundTransferCanceled
    | [<JsonPropertyName("treasury.outbound_transfer.created")>] TreasuryOutboundTransferCreated
    | [<JsonPropertyName("treasury.outbound_transfer.expected_arrival_date_updated")>] TreasuryOutboundTransferExpectedArrivalDateUpdated
    | [<JsonPropertyName("treasury.outbound_transfer.failed")>] TreasuryOutboundTransferFailed
    | [<JsonPropertyName("treasury.outbound_transfer.posted")>] TreasuryOutboundTransferPosted
    | [<JsonPropertyName("treasury.outbound_transfer.returned")>] TreasuryOutboundTransferReturned
    | [<JsonPropertyName("treasury.outbound_transfer.tracking_details_updated")>] TreasuryOutboundTransferTrackingDetailsUpdated
    | [<JsonPropertyName("treasury.received_credit.created")>] TreasuryReceivedCreditCreated
    | [<JsonPropertyName("treasury.received_credit.failed")>] TreasuryReceivedCreditFailed
    | [<JsonPropertyName("treasury.received_credit.succeeded")>] TreasuryReceivedCreditSucceeded
    | [<JsonPropertyName("treasury.received_debit.created")>] TreasuryReceivedDebitCreated

type NotificationEventData =
    {
        /// Object containing the API resource relevant to the event. For example, an `invoice.created` event will have a full [invoice object](https://api.stripe.com#invoice_object) as the value of the object key.
        Object: string
        /// Object containing the names of the updated attributes and their values prior to the event (only included in events of type `*.updated`). If an array attribute has any updated elements, this object contains the entire array. In Stripe API versions 2017-04-06 or earlier, an updated array attribute in this object includes only the updated array elements.
        PreviousAttributes: string option
    }

type NotificationEventData with
    static member New(object: string, ?previousAttributes: string) =
        {
            Object = object
            PreviousAttributes = previousAttributes
        }

type NotificationEventRequest =
    {
        /// ID of the API request that caused the event. If null, the event was automatic (e.g., Stripe's automatic subscription handling). Request logs are available in the [dashboard](https://dashboard.stripe.com/logs), but currently not in the API.
        Id: string option
        /// The idempotency key transmitted during the request, if any. *Note: This property is populated only for events on or after May 23, 2017*.
        IdempotencyKey: string option
    }

type NotificationEventRequest with
    static member New(id: string option, idempotencyKey: string option) =
        {
            Id = id
            IdempotencyKey = idempotencyKey
        }

/// Snapshot events allow you to track and react to activity in your Stripe integration. When
/// the state of another API resource changes, Stripe creates an `Event` object that contains
/// all the relevant information associated with that action, including the affected API
/// resource. For example, a successful payment triggers a `charge.succeeded` event, which
/// contains the `Charge` in the event's data property. Some actions trigger multiple events.
/// For example, if you create a new subscription for a customer, it triggers both a
/// `customer.subscription.created` event and a `charge.succeeded` event.
/// Configure an event destination in your account to listen for events that represent actions
/// your integration needs to respond to. Additionally, you can retrieve an individual event or
/// a list of events from the API.
/// [Connect](https://docs.stripe.com/connect) platforms can also receive event notifications
/// that occur in their connected accounts. These events include an account attribute that
/// identifies the relevant connected account.
/// You can access events through the [Retrieve Event API](https://docs.stripe.com/api/events#retrieve_event)
/// for 30 days.
type Event =
    {
        /// The connected account that originates the event.
        Account: string option
        /// The Stripe API version used to render `data` when the event was created. The contents of `data` never change, so this value remains static regardless of the API version currently in use. This property is populated only for events created on or after October 31, 2014.
        ApiVersion: string option
        /// Authentication context needed to fetch the event or related object.
        Context: string option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        Data: NotificationEventData
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Number of webhooks that haven't been successfully delivered (for example, to return a 20x response) to the URLs you specify.
        PendingWebhooks: int
        /// Information on the API request that triggers the event.
        Request: NotificationEventRequest option
        /// Description of the event (for example, `invoice.created` or `charge.refunded`).
        Type: EventType
    }

type Event with
    static member New(apiVersion: string option, created: DateTime, data: NotificationEventData, id: string, livemode: bool, pendingWebhooks: int, request: NotificationEventRequest option, ``type``: EventType, ?account: string, ?context: string) =
        {
            ApiVersion = apiVersion
            Created = created
            Data = data
            Id = id
            Livemode = livemode
            PendingWebhooks = pendingWebhooks
            Request = request
            Type = ``type``
            Account = account
            Context = context
        }

module Event =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "event"

