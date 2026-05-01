namespace StripeRequest.Webhook

open FunStripe
open System.Text.Json.Serialization
open Stripe.WebhookEndpoint
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
module WebhookEndpoints =

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
        }

    type ListOptions with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    type Create'ApiVersion =
        | [<JsonPropertyName("2011-01-01")>] Numeric20110101
        | [<JsonPropertyName("2011-06-21")>] Numeric20110621
        | [<JsonPropertyName("2011-06-28")>] Numeric20110628
        | [<JsonPropertyName("2011-08-01")>] Numeric20110801
        | [<JsonPropertyName("2011-09-15")>] Numeric20110915
        | [<JsonPropertyName("2011-11-17")>] Numeric20111117
        | [<JsonPropertyName("2012-02-23")>] Numeric20120223
        | [<JsonPropertyName("2012-03-25")>] Numeric20120325
        | [<JsonPropertyName("2012-06-18")>] Numeric20120618
        | [<JsonPropertyName("2012-06-28")>] Numeric20120628
        | [<JsonPropertyName("2012-07-09")>] Numeric20120709
        | [<JsonPropertyName("2012-09-24")>] Numeric20120924
        | [<JsonPropertyName("2012-10-26")>] Numeric20121026
        | [<JsonPropertyName("2012-11-07")>] Numeric20121107
        | [<JsonPropertyName("2013-02-11")>] Numeric20130211
        | [<JsonPropertyName("2013-02-13")>] Numeric20130213
        | [<JsonPropertyName("2013-07-05")>] Numeric20130705
        | [<JsonPropertyName("2013-08-12")>] Numeric20130812
        | [<JsonPropertyName("2013-08-13")>] Numeric20130813
        | [<JsonPropertyName("2013-10-29")>] Numeric20131029
        | [<JsonPropertyName("2013-12-03")>] Numeric20131203
        | [<JsonPropertyName("2014-01-31")>] Numeric20140131
        | [<JsonPropertyName("2014-03-13")>] Numeric20140313
        | [<JsonPropertyName("2014-03-28")>] Numeric20140328
        | [<JsonPropertyName("2014-05-19")>] Numeric20140519
        | [<JsonPropertyName("2014-06-13")>] Numeric20140613
        | [<JsonPropertyName("2014-06-17")>] Numeric20140617
        | [<JsonPropertyName("2014-07-22")>] Numeric20140722
        | [<JsonPropertyName("2014-07-26")>] Numeric20140726
        | [<JsonPropertyName("2014-08-04")>] Numeric20140804
        | [<JsonPropertyName("2014-08-20")>] Numeric20140820
        | [<JsonPropertyName("2014-09-08")>] Numeric20140908
        | [<JsonPropertyName("2014-10-07")>] Numeric20141007
        | [<JsonPropertyName("2014-11-05")>] Numeric20141105
        | [<JsonPropertyName("2014-11-20")>] Numeric20141120
        | [<JsonPropertyName("2014-12-08")>] Numeric20141208
        | [<JsonPropertyName("2014-12-17")>] Numeric20141217
        | [<JsonPropertyName("2014-12-22")>] Numeric20141222
        | [<JsonPropertyName("2015-01-11")>] Numeric20150111
        | [<JsonPropertyName("2015-01-26")>] Numeric20150126
        | [<JsonPropertyName("2015-02-10")>] Numeric20150210
        | [<JsonPropertyName("2015-02-16")>] Numeric20150216
        | [<JsonPropertyName("2015-02-18")>] Numeric20150218
        | [<JsonPropertyName("2015-03-24")>] Numeric20150324
        | [<JsonPropertyName("2015-04-07")>] Numeric20150407
        | [<JsonPropertyName("2015-06-15")>] Numeric20150615
        | [<JsonPropertyName("2015-07-07")>] Numeric20150707
        | [<JsonPropertyName("2015-07-13")>] Numeric20150713
        | [<JsonPropertyName("2015-07-28")>] Numeric20150728
        | [<JsonPropertyName("2015-08-07")>] Numeric20150807
        | [<JsonPropertyName("2015-08-19")>] Numeric20150819
        | [<JsonPropertyName("2015-09-03")>] Numeric20150903
        | [<JsonPropertyName("2015-09-08")>] Numeric20150908
        | [<JsonPropertyName("2015-09-23")>] Numeric20150923
        | [<JsonPropertyName("2015-10-01")>] Numeric20151001
        | [<JsonPropertyName("2015-10-12")>] Numeric20151012
        | [<JsonPropertyName("2015-10-16")>] Numeric20151016
        | [<JsonPropertyName("2016-02-03")>] Numeric20160203
        | [<JsonPropertyName("2016-02-19")>] Numeric20160219
        | [<JsonPropertyName("2016-02-22")>] Numeric20160222
        | [<JsonPropertyName("2016-02-23")>] Numeric20160223
        | [<JsonPropertyName("2016-02-29")>] Numeric20160229
        | [<JsonPropertyName("2016-03-07")>] Numeric20160307
        | [<JsonPropertyName("2016-06-15")>] Numeric20160615
        | [<JsonPropertyName("2016-07-06")>] Numeric20160706
        | [<JsonPropertyName("2016-10-19")>] Numeric20161019
        | [<JsonPropertyName("2017-01-27")>] Numeric20170127
        | [<JsonPropertyName("2017-02-14")>] Numeric20170214
        | [<JsonPropertyName("2017-04-06")>] Numeric20170406
        | [<JsonPropertyName("2017-05-25")>] Numeric20170525
        | [<JsonPropertyName("2017-06-05")>] Numeric20170605
        | [<JsonPropertyName("2017-08-15")>] Numeric20170815
        | [<JsonPropertyName("2017-12-14")>] Numeric20171214
        | [<JsonPropertyName("2018-01-23")>] Numeric20180123
        | [<JsonPropertyName("2018-02-05")>] Numeric20180205
        | [<JsonPropertyName("2018-02-06")>] Numeric20180206
        | [<JsonPropertyName("2018-02-28")>] Numeric20180228
        | [<JsonPropertyName("2018-05-21")>] Numeric20180521
        | [<JsonPropertyName("2018-07-27")>] Numeric20180727
        | [<JsonPropertyName("2018-08-23")>] Numeric20180823
        | [<JsonPropertyName("2018-09-06")>] Numeric20180906
        | [<JsonPropertyName("2018-09-24")>] Numeric20180924
        | [<JsonPropertyName("2018-10-31")>] Numeric20181031
        | [<JsonPropertyName("2018-11-08")>] Numeric20181108
        | [<JsonPropertyName("2019-02-11")>] Numeric20190211
        | [<JsonPropertyName("2019-02-19")>] Numeric20190219
        | [<JsonPropertyName("2019-03-14")>] Numeric20190314
        | [<JsonPropertyName("2019-05-16")>] Numeric20190516
        | [<JsonPropertyName("2019-08-14")>] Numeric20190814
        | [<JsonPropertyName("2019-09-09")>] Numeric20190909
        | [<JsonPropertyName("2019-10-08")>] Numeric20191008
        | [<JsonPropertyName("2019-10-17")>] Numeric20191017
        | [<JsonPropertyName("2019-11-05")>] Numeric20191105
        | [<JsonPropertyName("2019-12-03")>] Numeric20191203
        | [<JsonPropertyName("2020-03-02")>] Numeric20200302
        | [<JsonPropertyName("2020-08-27")>] Numeric20200827
        | [<JsonPropertyName("2022-08-01")>] Numeric20220801
        | [<JsonPropertyName("2022-11-15")>] Numeric20221115
        | [<JsonPropertyName("2023-08-16")>] Numeric20230816
        | [<JsonPropertyName("2023-10-16")>] Numeric20231016
        | [<JsonPropertyName("2024-04-10")>] Numeric20240410
        | [<JsonPropertyName("2024-06-20")>] Numeric20240620
        | [<JsonPropertyName("2024-09-30.acacia")>] Numeric20240930Acacia
        | [<JsonPropertyName("2024-10-28.acacia")>] Numeric20241028Acacia
        | [<JsonPropertyName("2024-11-20.acacia")>] Numeric20241120Acacia
        | [<JsonPropertyName("2024-12-18.acacia")>] Numeric20241218Acacia
        | [<JsonPropertyName("2025-01-27.acacia")>] Numeric20250127Acacia
        | [<JsonPropertyName("2025-02-24.acacia")>] Numeric20250224Acacia
        | [<JsonPropertyName("2025-03-01.dashboard")>] Numeric20250301Dashboard
        | [<JsonPropertyName("2025-03-31.basil")>] Numeric20250331Basil
        | [<JsonPropertyName("2025-04-30.basil")>] Numeric20250430Basil
        | [<JsonPropertyName("2025-05-28.basil")>] Numeric20250528Basil
        | [<JsonPropertyName("2025-06-30.basil")>] Numeric20250630Basil
        | [<JsonPropertyName("2025-07-30.basil")>] Numeric20250730Basil
        | [<JsonPropertyName("2025-08-27.basil")>] Numeric20250827Basil
        | [<JsonPropertyName("2025-09-30.clover")>] Numeric20250930Clover
        | [<JsonPropertyName("2025-10-29.clover")>] Numeric20251029Clover
        | [<JsonPropertyName("2025-11-17.clover")>] Numeric20251117Clover
        | [<JsonPropertyName("2025-12-15.clover")>] Numeric20251215Clover
        | [<JsonPropertyName("2026-01-28.clover")>] Numeric20260128Clover
        | [<JsonPropertyName("2026-02-25.clover")>] Numeric20260225Clover
        | [<JsonPropertyName("2026-03-25.dahlia")>] Numeric20260325Dahlia
        | [<JsonPropertyName("2026-04-22.dahlia")>] Numeric20260422Dahlia

    type Create'EnabledEvents =
        | Asterix
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

    type CreateOptions =
        {
            /// Events sent to this endpoint will be generated with this Stripe Version instead of your account's default Stripe Version.
            [<Config.Form>]
            ApiVersion: Create'ApiVersion option
            /// Whether this endpoint should receive events from connected accounts (`true`), or from your account (`false`). Defaults to `false`.
            [<Config.Form>]
            Connect: bool option
            /// An optional description of what the webhook is used for.
            [<Config.Form>]
            Description: Choice<string,string> option
            /// The list of events to enable for this endpoint. You may specify `['*']` to enable all events, except those that require explicit selection.
            [<Config.Form>]
            EnabledEvents: Create'EnabledEvents list
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The URL of the webhook endpoint.
            [<Config.Form>]
            Url: string
        }

    type CreateOptions with
        static member New(enabledEvents: Create'EnabledEvents list, url: string, ?apiVersion: Create'ApiVersion, ?connect: bool, ?description: Choice<string,string>, ?expand: string list, ?metadata: Map<string, string>) =
            {
                EnabledEvents = enabledEvents
                Url = url
                ApiVersion = apiVersion
                Connect = connect
                Description = description
                Expand = expand
                Metadata = metadata
            }

    type DeleteOptions =
        { [<Config.Path>]
          WebhookEndpoint: string }

    type DeleteOptions with
        static member New(webhookEndpoint: string) =
            {
                WebhookEndpoint = webhookEndpoint
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            WebhookEndpoint: string
        }

    type RetrieveOptions with
        static member New(webhookEndpoint: string, ?expand: string list) =
            {
                WebhookEndpoint = webhookEndpoint
                Expand = expand
            }

    type Update'EnabledEvents =
        | Asterix
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

    type UpdateOptions =
        {
            [<Config.Path>]
            WebhookEndpoint: string
            /// An optional description of what the webhook is used for.
            [<Config.Form>]
            Description: Choice<string,string> option
            /// Disable the webhook endpoint if set to true.
            [<Config.Form>]
            Disabled: bool option
            /// The list of events to enable for this endpoint. You may specify `['*']` to enable all events, except those that require explicit selection.
            [<Config.Form>]
            EnabledEvents: Update'EnabledEvents list option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The URL of the webhook endpoint.
            [<Config.Form>]
            Url: string option
        }

    type UpdateOptions with
        static member New(webhookEndpoint: string, ?description: Choice<string,string>, ?disabled: bool, ?enabledEvents: Update'EnabledEvents list, ?expand: string list, ?metadata: Map<string, string>, ?url: string) =
            {
                WebhookEndpoint = webhookEndpoint
                Description = description
                Disabled = disabled
                EnabledEvents = enabledEvents
                Expand = expand
                Metadata = metadata
                Url = url
            }

    ///<p>Returns a list of your webhook endpoints.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/webhook_endpoints"
        |> RestApi.getAsync<StripeList<WebhookEndpoint>> settings qs

    ///<p>A webhook endpoint must have a <code>url</code> and a list of <code>enabled_events</code>. You may optionally specify the Boolean <code>connect</code> parameter. If set to true, then a Connect webhook endpoint that notifies the specified <code>url</code> about events from all connected accounts is created; otherwise an account webhook endpoint that notifies the specified <code>url</code> only about events from your account is created. You can also create webhook endpoints in the <a href="https://dashboard.stripe.com/account/webhooks">webhooks settings</a> section of the Dashboard.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/webhook_endpoints"
        |> RestApi.postAsync<_, WebhookEndpoint> settings (Map.empty) options

    ///<p>You can also delete webhook endpoints via the <a href="https://dashboard.stripe.com/account/webhooks">webhook endpoint management</a> page of the Stripe dashboard.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/webhook_endpoints/{options.WebhookEndpoint}"
        |> RestApi.deleteAsync<DeletedWebhookEndpoint> settings (Map.empty)

    ///<p>Retrieves the webhook endpoint with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/webhook_endpoints/{options.WebhookEndpoint}"
        |> RestApi.getAsync<WebhookEndpoint> settings qs

    ///<p>Updates the webhook endpoint. You may edit the <code>url</code>, the list of <code>enabled_events</code>, and the status of your endpoint.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/webhook_endpoints/{options.WebhookEndpoint}"
        |> RestApi.postAsync<_, WebhookEndpoint> settings (Map.empty) options

