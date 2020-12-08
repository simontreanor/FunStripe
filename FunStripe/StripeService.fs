namespace FunStripe

open FSharp.Json

open StripeModel

module StripeService =

    type AccountService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Retrieve () =
            $"/v1/account"
            |> this.RestApiClient.GetAsync<Account>

        member this.Retrieve (account) =
            $"/v1/accounts/{account}"
            |> this.RestApiClient.GetAsync<Account>

        member this.Update (account) =
            $"/v1/accounts/{account}"
            |> this.RestApiClient.PostAsync<_, Account>

        member this.List () =
            $"/v1/accounts"
            |> this.RestApiClient.GetAsync<Account>

        member this.Create () =
            $"/v1/accounts"
            |> this.RestApiClient.PostAsync<_, Account>

        member this.Delete (account) =
            $"/v1/accounts/{account}"
            |> this.RestApiClient.DeleteAsync<Account>

        member this.Reject (account) =
            $"/v1/accounts/{account}/reject"
            |> this.RestApiClient.PostAsync<_, Account>

        member this.Capabilities (account) =
            $"/v1/accounts/{account}/capabilities"
            |> this.RestApiClient.GetAsync<Account>

    and AccountLinkService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create () =
            $"/v1/account_links"
            |> this.RestApiClient.PostAsync<_, AccountLink>

    and ApplePayDomainService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/apple_pay/domains"
            |> this.RestApiClient.GetAsync<ApplePayDomain>

        member this.Create () =
            $"/v1/apple_pay/domains"
            |> this.RestApiClient.PostAsync<_, ApplePayDomain>

        member this.Retrieve (domain) =
            $"/v1/apple_pay/domains/{domain}"
            |> this.RestApiClient.GetAsync<ApplePayDomain>

        member this.Delete (domain) =
            $"/v1/apple_pay/domains/{domain}"
            |> this.RestApiClient.DeleteAsync<ApplePayDomain>

    and ApplicationFeeService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/application_fees"
            |> this.RestApiClient.GetAsync<ApplicationFee>

        member this.Retrieve (id) =
            $"/v1/application_fees/{id}"
            |> this.RestApiClient.GetAsync<ApplicationFee>

    and BalanceService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Retrieve () =
            $"/v1/balance"
            |> this.RestApiClient.GetAsync<Balance>

    and BalanceTransactionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/balance_transactions"
            |> this.RestApiClient.GetAsync<BalanceTransaction>

        member this.Retrieve (id) =
            $"/v1/balance_transactions/{id}"
            |> this.RestApiClient.GetAsync<BalanceTransaction>

    and BankAccountService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Update (customer, id) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.PostAsync<_, BankAccount>

        member this.Delete (customer, id) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.DeleteAsync<BankAccount>

        member this.Verify (customer, id) =
            $"/v1/customers/{customer}/sources/{id}/verify"
            |> this.RestApiClient.PostAsync<_, BankAccount>

        member this.Update (account, id) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.PostAsync<_, BankAccount>

        member this.Delete (account, id) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.DeleteAsync<BankAccount>

    and BillingPortalSessionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create () =
            $"/v1/billing_portal/sessions"
            |> this.RestApiClient.PostAsync<_, BillingPortalSession>

    and BitcoinReceiverService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/bitcoin/receivers"
            |> this.RestApiClient.GetAsync<BitcoinReceiver>

        member this.Retrieve (id) =
            $"/v1/bitcoin/receivers/{id}"
            |> this.RestApiClient.GetAsync<BitcoinReceiver>

    and BitcoinTransactionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List (receiver) =
            $"/v1/bitcoin/receivers/{receiver}/transactions"
            |> this.RestApiClient.GetAsync<BitcoinTransaction>

    and CapabilityService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List (account) =
            $"/v1/accounts/{account}/capabilities"
            |> this.RestApiClient.GetAsync<Capability>

        member this.Retrieve (account, capability) =
            $"/v1/accounts/{account}/capabilities/{capability}"
            |> this.RestApiClient.GetAsync<Capability>

        member this.Update (account, capability) =
            $"/v1/accounts/{account}/capabilities/{capability}"
            |> this.RestApiClient.PostAsync<_, Capability>

    and CardService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Update (customer, id) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.PostAsync<_, Card>

        member this.Delete (customer, id) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.DeleteAsync<Card>

        member this.Update (account, id) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.PostAsync<_, Card>

        member this.Delete (account, id) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.DeleteAsync<Card>

    and ChargeService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/charges"
            |> this.RestApiClient.GetAsync<Charge>

        member this.Create () =
            $"/v1/charges"
            |> this.RestApiClient.PostAsync<_, Charge>

        member this.Retrieve (charge) =
            $"/v1/charges/{charge}"
            |> this.RestApiClient.GetAsync<Charge>

        member this.Update (charge) =
            $"/v1/charges/{charge}"
            |> this.RestApiClient.PostAsync<_, Charge>

        member this.Capture (charge) =
            $"/v1/charges/{charge}/capture"
            |> this.RestApiClient.PostAsync<_, Charge>

    and CheckoutSessionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/checkout/sessions"
            |> this.RestApiClient.GetAsync<CheckoutSession>

        member this.Retrieve (session) =
            $"/v1/checkout/sessions/{session}"
            |> this.RestApiClient.GetAsync<CheckoutSession>

        member this.Create () =
            $"/v1/checkout/sessions"
            |> this.RestApiClient.PostAsync<_, CheckoutSession>

    and CountrySpecService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/country_specs"
            |> this.RestApiClient.GetAsync<CountrySpec>

        member this.Retrieve (country) =
            $"/v1/country_specs/{country}"
            |> this.RestApiClient.GetAsync<CountrySpec>

    and CouponService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/coupons"
            |> this.RestApiClient.GetAsync<Coupon>

        member this.Create () =
            $"/v1/coupons"
            |> this.RestApiClient.PostAsync<_, Coupon>

        member this.Retrieve (coupon) =
            $"/v1/coupons/{coupon}"
            |> this.RestApiClient.GetAsync<Coupon>

        member this.Update (coupon) =
            $"/v1/coupons/{coupon}"
            |> this.RestApiClient.PostAsync<_, Coupon>

        member this.Delete (coupon) =
            $"/v1/coupons/{coupon}"
            |> this.RestApiClient.DeleteAsync<Coupon>

    and CreditNoteService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create () =
            $"/v1/credit_notes"
            |> this.RestApiClient.PostAsync<_, CreditNote>

        member this.Preview () =
            $"/v1/credit_notes/preview"
            |> this.RestApiClient.GetAsync<CreditNote>

        member this.Retrieve (id) =
            $"/v1/credit_notes/{id}"
            |> this.RestApiClient.GetAsync<CreditNote>

        member this.List () =
            $"/v1/credit_notes"
            |> this.RestApiClient.GetAsync<CreditNote>

        member this.Update (id) =
            $"/v1/credit_notes/{id}"
            |> this.RestApiClient.PostAsync<_, CreditNote>

        member this.VoidCreditNote (id) =
            $"/v1/credit_notes/{id}/void"
            |> this.RestApiClient.PostAsync<_, CreditNote>

        member this.PreviewLines () =
            $"/v1/credit_notes/preview/lines"
            |> this.RestApiClient.GetAsync<CreditNote>

    and CreditNoteLineItemService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List (credit_note) =
            $"/v1/credit_notes/{credit_note}/lines"
            |> this.RestApiClient.GetAsync<CreditNoteLineItem>

    and CustomerService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/customers"
            |> this.RestApiClient.GetAsync<Customer>

        member this.Create () =
            $"/v1/customers"
            |> this.RestApiClient.PostAsync<_, Customer>

        member this.Retrieve (customer) =
            $"/v1/customers/{customer}"
            |> this.RestApiClient.GetAsync<Customer>

        member this.Update (customer) =
            $"/v1/customers/{customer}"
            |> this.RestApiClient.PostAsync<_, Customer>

        member this.Delete (customer) =
            $"/v1/customers/{customer}"
            |> this.RestApiClient.DeleteAsync<Customer>

        member this.DeleteDiscount (customer) =
            $"/v1/customers/{customer}/discount"
            |> this.RestApiClient.DeleteAsync<Customer>

    and CustomerBalanceTransactionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Retrieve (customer, transaction) =
            $"/v1/customers/{customer}/balance_transactions/{transaction}"
            |> this.RestApiClient.GetAsync<CustomerBalanceTransaction>

        member this.List (customer) =
            $"/v1/customers/{customer}/balance_transactions"
            |> this.RestApiClient.GetAsync<CustomerBalanceTransaction>

        member this.Create (customer) =
            $"/v1/customers/{customer}/balance_transactions"
            |> this.RestApiClient.PostAsync<_, CustomerBalanceTransaction>

        member this.Update (customer, transaction) =
            $"/v1/customers/{customer}/balance_transactions/{transaction}"
            |> this.RestApiClient.PostAsync<_, CustomerBalanceTransaction>

    and DisputeService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/disputes"
            |> this.RestApiClient.GetAsync<Dispute>

        member this.Retrieve (dispute) =
            $"/v1/disputes/{dispute}"
            |> this.RestApiClient.GetAsync<Dispute>

        member this.Update (dispute) =
            $"/v1/disputes/{dispute}"
            |> this.RestApiClient.PostAsync<_, Dispute>

        member this.Close (dispute) =
            $"/v1/disputes/{dispute}/close"
            |> this.RestApiClient.PostAsync<_, Dispute>

    and EphemeralKeyService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create () =
            $"/v1/ephemeral_keys"
            |> this.RestApiClient.PostAsync<_, EphemeralKey>

        member this.Delete (key) =
            $"/v1/ephemeral_keys/{key}"
            |> this.RestApiClient.DeleteAsync<EphemeralKey>

    and EventService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/events"
            |> this.RestApiClient.GetAsync<Event>

        member this.Retrieve (id) =
            $"/v1/events/{id}"
            |> this.RestApiClient.GetAsync<Event>

    and ExchangeRateService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/exchange_rates"
            |> this.RestApiClient.GetAsync<ExchangeRate>

        member this.Retrieve (rate_id) =
            $"/v1/exchange_rates/{rate_id}"
            |> this.RestApiClient.GetAsync<ExchangeRate>

    and ExternalAccountService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List (account) =
            $"/v1/accounts/{account}/external_accounts"
            |> this.RestApiClient.GetAsync<ExternalAccount>

        member this.Retrieve (account, id) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.GetAsync<ExternalAccount>

        member this.Create (account) =
            $"/v1/accounts/{account}/external_accounts"
            |> this.RestApiClient.PostAsync<_, ExternalAccount>

        member this.Update (account, id) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.PostAsync<_, ExternalAccount>

        member this.Delete (account, id) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.DeleteAsync<ExternalAccount>

    and FeeRefundService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create (id) =
            $"/v1/application_fees/{id}/refunds"
            |> this.RestApiClient.PostAsync<_, FeeRefund>

        member this.List (id) =
            $"/v1/application_fees/{id}/refunds"
            |> this.RestApiClient.GetAsync<FeeRefund>

        member this.Retrieve (fee, id) =
            $"/v1/application_fees/{fee}/refunds/{id}"
            |> this.RestApiClient.GetAsync<FeeRefund>

        member this.Update (fee, id) =
            $"/v1/application_fees/{fee}/refunds/{id}"
            |> this.RestApiClient.PostAsync<_, FeeRefund>

    and FileService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/files"
            |> this.RestApiClient.GetAsync<File>

        member this.Retrieve (file) =
            $"/v1/files/{file}"
            |> this.RestApiClient.GetAsync<File>

        member this.Create () =
            $"/v1/files"
            |> this.RestApiClient.PostAsync<_, File>

    and FileLinkService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Retrieve (link) =
            $"/v1/file_links/{link}"
            |> this.RestApiClient.GetAsync<FileLink>

        member this.Create () =
            $"/v1/file_links"
            |> this.RestApiClient.PostAsync<_, FileLink>

        member this.Update (link) =
            $"/v1/file_links/{link}"
            |> this.RestApiClient.PostAsync<_, FileLink>

        member this.List () =
            $"/v1/file_links"
            |> this.RestApiClient.GetAsync<FileLink>

    and InvoiceService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/invoices"
            |> this.RestApiClient.GetAsync<Invoice>

        member this.Upcoming () =
            $"/v1/invoices/upcoming"
            |> this.RestApiClient.GetAsync<Invoice>

        member this.Create () =
            $"/v1/invoices"
            |> this.RestApiClient.PostAsync<_, Invoice>

        member this.Retrieve (invoice) =
            $"/v1/invoices/{invoice}"
            |> this.RestApiClient.GetAsync<Invoice>

        member this.Update (invoice) =
            $"/v1/invoices/{invoice}"
            |> this.RestApiClient.PostAsync<_, Invoice>

        member this.Delete (invoice) =
            $"/v1/invoices/{invoice}"
            |> this.RestApiClient.DeleteAsync<Invoice>

        member this.Pay (invoice) =
            $"/v1/invoices/{invoice}/pay"
            |> this.RestApiClient.PostAsync<_, Invoice>

        member this.FinalizeInvoice (invoice) =
            $"/v1/invoices/{invoice}/finalize"
            |> this.RestApiClient.PostAsync<_, Invoice>

        member this.UpcomingLines () =
            $"/v1/invoices/upcoming/lines"
            |> this.RestApiClient.GetAsync<Invoice>

        member this.SendInvoice (invoice) =
            $"/v1/invoices/{invoice}/send"
            |> this.RestApiClient.PostAsync<_, Invoice>

        member this.MarkUncollectible (invoice) =
            $"/v1/invoices/{invoice}/mark_uncollectible"
            |> this.RestApiClient.PostAsync<_, Invoice>

        member this.VoidInvoice (invoice) =
            $"/v1/invoices/{invoice}/void"
            |> this.RestApiClient.PostAsync<_, Invoice>

    and InvoiceitemService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/invoiceitems"
            |> this.RestApiClient.GetAsync<Invoiceitem>

        member this.Create () =
            $"/v1/invoiceitems"
            |> this.RestApiClient.PostAsync<_, Invoiceitem>

        member this.Retrieve (invoiceitem) =
            $"/v1/invoiceitems/{invoiceitem}"
            |> this.RestApiClient.GetAsync<Invoiceitem>

        member this.Update (invoiceitem) =
            $"/v1/invoiceitems/{invoiceitem}"
            |> this.RestApiClient.PostAsync<_, Invoiceitem>

        member this.Delete (invoiceitem) =
            $"/v1/invoiceitems/{invoiceitem}"
            |> this.RestApiClient.DeleteAsync<Invoiceitem>

    and IssuerFraudRecordService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/issuer_fraud_records"
            |> this.RestApiClient.GetAsync<IssuerFraudRecord>

        member this.Retrieve (issuer_fraud_record) =
            $"/v1/issuer_fraud_records/{issuer_fraud_record}"
            |> this.RestApiClient.GetAsync<IssuerFraudRecord>

    and IssuingAuthorizationService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/issuing/authorizations"
            |> this.RestApiClient.GetAsync<IssuingAuthorization>

        member this.Retrieve (authorization) =
            $"/v1/issuing/authorizations/{authorization}"
            |> this.RestApiClient.GetAsync<IssuingAuthorization>

        member this.Update (authorization) =
            $"/v1/issuing/authorizations/{authorization}"
            |> this.RestApiClient.PostAsync<_, IssuingAuthorization>

        member this.Approve (authorization) =
            $"/v1/issuing/authorizations/{authorization}/approve"
            |> this.RestApiClient.PostAsync<_, IssuingAuthorization>

        member this.Decline (authorization) =
            $"/v1/issuing/authorizations/{authorization}/decline"
            |> this.RestApiClient.PostAsync<_, IssuingAuthorization>

    and IssuingCardService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/issuing/cards"
            |> this.RestApiClient.GetAsync<IssuingCard>

        member this.Create () =
            $"/v1/issuing/cards"
            |> this.RestApiClient.PostAsync<_, IssuingCard>

        member this.Retrieve (card) =
            $"/v1/issuing/cards/{card}"
            |> this.RestApiClient.GetAsync<IssuingCard>

        member this.Update (card) =
            $"/v1/issuing/cards/{card}"
            |> this.RestApiClient.PostAsync<_, IssuingCard>

    and IssuingCardholderService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/issuing/cardholders"
            |> this.RestApiClient.GetAsync<IssuingCardholder>

        member this.Create () =
            $"/v1/issuing/cardholders"
            |> this.RestApiClient.PostAsync<_, IssuingCardholder>

        member this.Retrieve (cardholder) =
            $"/v1/issuing/cardholders/{cardholder}"
            |> this.RestApiClient.GetAsync<IssuingCardholder>

        member this.Update (cardholder) =
            $"/v1/issuing/cardholders/{cardholder}"
            |> this.RestApiClient.PostAsync<_, IssuingCardholder>

    and IssuingDisputeService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/issuing/disputes"
            |> this.RestApiClient.GetAsync<IssuingDispute>

        member this.Create () =
            $"/v1/issuing/disputes"
            |> this.RestApiClient.PostAsync<_, IssuingDispute>

        member this.Update (dispute) =
            $"/v1/issuing/disputes/{dispute}"
            |> this.RestApiClient.PostAsync<_, IssuingDispute>

        member this.Retrieve (dispute) =
            $"/v1/issuing/disputes/{dispute}"
            |> this.RestApiClient.GetAsync<IssuingDispute>

        member this.Submit (dispute) =
            $"/v1/issuing/disputes/{dispute}/submit"
            |> this.RestApiClient.PostAsync<_, IssuingDispute>

    and IssuingTransactionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/issuing/transactions"
            |> this.RestApiClient.GetAsync<IssuingTransaction>

        member this.Retrieve (transaction) =
            $"/v1/issuing/transactions/{transaction}"
            |> this.RestApiClient.GetAsync<IssuingTransaction>

        member this.Update (transaction) =
            $"/v1/issuing/transactions/{transaction}"
            |> this.RestApiClient.PostAsync<_, IssuingTransaction>

    and ItemService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List (session) =
            $"/v1/checkout/sessions/{session}/line_items"
            |> this.RestApiClient.GetAsync<Item>

    and LineItemService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List (invoice) =
            $"/v1/invoices/{invoice}/lines"
            |> this.RestApiClient.GetAsync<LineItem>

    and LoginLinkService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create (account) =
            $"/v1/accounts/{account}/login_links"
            |> this.RestApiClient.PostAsync<_, LoginLink>

    and MandateService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Retrieve (mandate) =
            $"/v1/mandates/{mandate}"
            |> this.RestApiClient.GetAsync<Mandate>

    and OrderService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create () =
            $"/v1/orders"
            |> this.RestApiClient.PostAsync<_, Order>

        member this.List () =
            $"/v1/orders"
            |> this.RestApiClient.GetAsync<Order>

        member this.Retrieve (id) =
            $"/v1/orders/{id}"
            |> this.RestApiClient.GetAsync<Order>

        member this.Update (id) =
            $"/v1/orders/{id}"
            |> this.RestApiClient.PostAsync<_, Order>

        member this.Pay (id) =
            $"/v1/orders/{id}/pay"
            |> this.RestApiClient.PostAsync<_, Order>

        member this.ReturnOrder (id) =
            $"/v1/orders/{id}/returns"
            |> this.RestApiClient.PostAsync<_, Order>

    and OrderReturnService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/order_returns"
            |> this.RestApiClient.GetAsync<OrderReturn>

        member this.Retrieve (id) =
            $"/v1/order_returns/{id}"
            |> this.RestApiClient.GetAsync<OrderReturn>

    and PaymentIntentService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create () =
            $"/v1/payment_intents"
            |> this.RestApiClient.PostAsync<_, PaymentIntent>

        member this.List () =
            $"/v1/payment_intents"
            |> this.RestApiClient.GetAsync<PaymentIntent>

        member this.Retrieve (intent) =
            $"/v1/payment_intents/{intent}"
            |> this.RestApiClient.GetAsync<PaymentIntent>

        member this.Update (intent) =
            $"/v1/payment_intents/{intent}"
            |> this.RestApiClient.PostAsync<_, PaymentIntent>

        member this.Confirm (intent) =
            $"/v1/payment_intents/{intent}/confirm"
            |> this.RestApiClient.PostAsync<_, PaymentIntent>

        member this.Cancel (intent) =
            $"/v1/payment_intents/{intent}/cancel"
            |> this.RestApiClient.PostAsync<_, PaymentIntent>

        member this.Capture (intent) =
            $"/v1/payment_intents/{intent}/capture"
            |> this.RestApiClient.PostAsync<_, PaymentIntent>

    and PaymentMethodService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create () =
            $"/v1/payment_methods"
            |> this.RestApiClient.PostAsync<_, PaymentMethod>

        member this.Retrieve (payment_method) =
            $"/v1/payment_methods/{payment_method}"
            |> this.RestApiClient.GetAsync<PaymentMethod>

        member this.Update (payment_method) =
            $"/v1/payment_methods/{payment_method}"
            |> this.RestApiClient.PostAsync<_, PaymentMethod>

        member this.List () =
            $"/v1/payment_methods"
            |> this.RestApiClient.GetAsync<PaymentMethod>

        member this.Attach (payment_method) =
            $"/v1/payment_methods/{payment_method}/attach"
            |> this.RestApiClient.PostAsync<_, PaymentMethod>

        member this.Detach (payment_method) =
            $"/v1/payment_methods/{payment_method}/detach"
            |> this.RestApiClient.PostAsync<_, PaymentMethod>

    and PaymentSourceService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List (customer) =
            $"/v1/customers/{customer}/sources"
            |> this.RestApiClient.GetAsync<PaymentSource>

        member this.Retrieve (customer, id) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.GetAsync<PaymentSource>

        member this.Create (customer) =
            $"/v1/customers/{customer}/sources"
            |> this.RestApiClient.PostAsync<_, PaymentSource>

    and PayoutService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Retrieve (payout) =
            $"/v1/payouts/{payout}"
            |> this.RestApiClient.GetAsync<Payout>

        member this.List () =
            $"/v1/payouts"
            |> this.RestApiClient.GetAsync<Payout>

        member this.Create () =
            $"/v1/payouts"
            |> this.RestApiClient.PostAsync<_, Payout>

        member this.Update (payout) =
            $"/v1/payouts/{payout}"
            |> this.RestApiClient.PostAsync<_, Payout>

        member this.Cancel (payout) =
            $"/v1/payouts/{payout}/cancel"
            |> this.RestApiClient.PostAsync<_, Payout>

        member this.Reverse (payout) =
            $"/v1/payouts/{payout}/reverse"
            |> this.RestApiClient.PostAsync<_, Payout>

    and PersonService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List (account) =
            $"/v1/accounts/{account}/persons"
            |> this.RestApiClient.GetAsync<Person>

        member this.Retrieve (account, person) =
            $"/v1/accounts/{account}/persons/{person}"
            |> this.RestApiClient.GetAsync<Person>

        member this.Create (account) =
            $"/v1/accounts/{account}/persons"
            |> this.RestApiClient.PostAsync<_, Person>

        member this.Update (account, person) =
            $"/v1/accounts/{account}/persons/{person}"
            |> this.RestApiClient.PostAsync<_, Person>

        member this.Delete (account, person) =
            $"/v1/accounts/{account}/persons/{person}"
            |> this.RestApiClient.DeleteAsync<Person>

    and PlanService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/plans"
            |> this.RestApiClient.GetAsync<Plan>

        member this.Create () =
            $"/v1/plans"
            |> this.RestApiClient.PostAsync<_, Plan>

        member this.Retrieve (plan) =
            $"/v1/plans/{plan}"
            |> this.RestApiClient.GetAsync<Plan>

        member this.Update (plan) =
            $"/v1/plans/{plan}"
            |> this.RestApiClient.PostAsync<_, Plan>

        member this.Delete (plan) =
            $"/v1/plans/{plan}"
            |> this.RestApiClient.DeleteAsync<Plan>

    and PriceService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/prices"
            |> this.RestApiClient.GetAsync<Price>

        member this.Create () =
            $"/v1/prices"
            |> this.RestApiClient.PostAsync<_, Price>

        member this.Retrieve (price) =
            $"/v1/prices/{price}"
            |> this.RestApiClient.GetAsync<Price>

        member this.Update (price) =
            $"/v1/prices/{price}"
            |> this.RestApiClient.PostAsync<_, Price>

    and ProductService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create () =
            $"/v1/products"
            |> this.RestApiClient.PostAsync<_, Product>

        member this.Retrieve (id) =
            $"/v1/products/{id}"
            |> this.RestApiClient.GetAsync<Product>

        member this.Update (id) =
            $"/v1/products/{id}"
            |> this.RestApiClient.PostAsync<_, Product>

        member this.List () =
            $"/v1/products"
            |> this.RestApiClient.GetAsync<Product>

        member this.Delete (id) =
            $"/v1/products/{id}"
            |> this.RestApiClient.DeleteAsync<Product>

    and PromotionCodeService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Retrieve (promotion_code) =
            $"/v1/promotion_codes/{promotion_code}"
            |> this.RestApiClient.GetAsync<PromotionCode>

        member this.Create () =
            $"/v1/promotion_codes"
            |> this.RestApiClient.PostAsync<_, PromotionCode>

        member this.Update (promotion_code) =
            $"/v1/promotion_codes/{promotion_code}"
            |> this.RestApiClient.PostAsync<_, PromotionCode>

        member this.List () =
            $"/v1/promotion_codes"
            |> this.RestApiClient.GetAsync<PromotionCode>

    and RadarEarlyFraudWarningService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/radar/early_fraud_warnings"
            |> this.RestApiClient.GetAsync<RadarEarlyFraudWarning>

        member this.Retrieve (early_fraud_warning) =
            $"/v1/radar/early_fraud_warnings/{early_fraud_warning}"
            |> this.RestApiClient.GetAsync<RadarEarlyFraudWarning>

    and RadarValueListService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/radar/value_lists"
            |> this.RestApiClient.GetAsync<RadarValueList>

        member this.Retrieve (value_list) =
            $"/v1/radar/value_lists/{value_list}"
            |> this.RestApiClient.GetAsync<RadarValueList>

        member this.Create () =
            $"/v1/radar/value_lists"
            |> this.RestApiClient.PostAsync<_, RadarValueList>

        member this.Update (value_list) =
            $"/v1/radar/value_lists/{value_list}"
            |> this.RestApiClient.PostAsync<_, RadarValueList>

        member this.Delete (value_list) =
            $"/v1/radar/value_lists/{value_list}"
            |> this.RestApiClient.DeleteAsync<RadarValueList>

    and RadarValueListItemService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/radar/value_list_items"
            |> this.RestApiClient.GetAsync<RadarValueListItem>

        member this.Retrieve (item) =
            $"/v1/radar/value_list_items/{item}"
            |> this.RestApiClient.GetAsync<RadarValueListItem>

        member this.Create () =
            $"/v1/radar/value_list_items"
            |> this.RestApiClient.PostAsync<_, RadarValueListItem>

        member this.Delete (item) =
            $"/v1/radar/value_list_items/{item}"
            |> this.RestApiClient.DeleteAsync<RadarValueListItem>

    and RecipientService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/recipients"
            |> this.RestApiClient.GetAsync<Recipient>

        member this.Create () =
            $"/v1/recipients"
            |> this.RestApiClient.PostAsync<_, Recipient>

        member this.Retrieve (id) =
            $"/v1/recipients/{id}"
            |> this.RestApiClient.GetAsync<Recipient>

        member this.Update (id) =
            $"/v1/recipients/{id}"
            |> this.RestApiClient.PostAsync<_, Recipient>

        member this.Delete (id) =
            $"/v1/recipients/{id}"
            |> this.RestApiClient.DeleteAsync<Recipient>

    and RefundService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/refunds"
            |> this.RestApiClient.GetAsync<Refund>

        member this.Create () =
            $"/v1/refunds"
            |> this.RestApiClient.PostAsync<_, Refund>

        member this.Retrieve (refund) =
            $"/v1/refunds/{refund}"
            |> this.RestApiClient.GetAsync<Refund>

        member this.Update (refund) =
            $"/v1/refunds/{refund}"
            |> this.RestApiClient.PostAsync<_, Refund>

    and ReportingReportRunService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Retrieve (report_run) =
            $"/v1/reporting/report_runs/{report_run}"
            |> this.RestApiClient.GetAsync<ReportingReportRun>

        member this.Create () =
            $"/v1/reporting/report_runs"
            |> this.RestApiClient.PostAsync<_, ReportingReportRun>

        member this.List () =
            $"/v1/reporting/report_runs"
            |> this.RestApiClient.GetAsync<ReportingReportRun>

    and ReportingReportTypeService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Retrieve (report_type) =
            $"/v1/reporting/report_types/{report_type}"
            |> this.RestApiClient.GetAsync<ReportingReportType>

        member this.List () =
            $"/v1/reporting/report_types"
            |> this.RestApiClient.GetAsync<ReportingReportType>

    and ReviewService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/reviews"
            |> this.RestApiClient.GetAsync<Review>

        member this.Retrieve (review) =
            $"/v1/reviews/{review}"
            |> this.RestApiClient.GetAsync<Review>

        member this.Approve (review) =
            $"/v1/reviews/{review}/approve"
            |> this.RestApiClient.PostAsync<_, Review>

    and ScheduledQueryRunService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/sigma/scheduled_query_runs"
            |> this.RestApiClient.GetAsync<ScheduledQueryRun>

        member this.Retrieve (scheduled_query_run) =
            $"/v1/sigma/scheduled_query_runs/{scheduled_query_run}"
            |> this.RestApiClient.GetAsync<ScheduledQueryRun>

    and SetupAttemptService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/setup_attempts"
            |> this.RestApiClient.GetAsync<SetupAttempt>

    and SetupIntentService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create () =
            $"/v1/setup_intents"
            |> this.RestApiClient.PostAsync<_, SetupIntent>

        member this.List () =
            $"/v1/setup_intents"
            |> this.RestApiClient.GetAsync<SetupIntent>

        member this.Retrieve (intent) =
            $"/v1/setup_intents/{intent}"
            |> this.RestApiClient.GetAsync<SetupIntent>

        member this.Update (intent) =
            $"/v1/setup_intents/{intent}"
            |> this.RestApiClient.PostAsync<_, SetupIntent>

        member this.Confirm (intent) =
            $"/v1/setup_intents/{intent}/confirm"
            |> this.RestApiClient.PostAsync<_, SetupIntent>

        member this.Cancel (intent) =
            $"/v1/setup_intents/{intent}/cancel"
            |> this.RestApiClient.PostAsync<_, SetupIntent>

    and SkuService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Retrieve (id) =
            $"/v1/skus/{id}"
            |> this.RestApiClient.GetAsync<Sku>

        member this.List () =
            $"/v1/skus"
            |> this.RestApiClient.GetAsync<Sku>

        member this.Update (id) =
            $"/v1/skus/{id}"
            |> this.RestApiClient.PostAsync<_, Sku>

        member this.Create () =
            $"/v1/skus"
            |> this.RestApiClient.PostAsync<_, Sku>

        member this.Delete (id) =
            $"/v1/skus/{id}"
            |> this.RestApiClient.DeleteAsync<Sku>

    and SourceService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Detach (customer, id) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.DeleteAsync<Source>

        member this.Retrieve (source) =
            $"/v1/sources/{source}"
            |> this.RestApiClient.GetAsync<Source>

        member this.Create () =
            $"/v1/sources"
            |> this.RestApiClient.PostAsync<_, Source>

        member this.Update (source) =
            $"/v1/sources/{source}"
            |> this.RestApiClient.PostAsync<_, Source>

        member this.Verify (source) =
            $"/v1/sources/{source}/verify"
            |> this.RestApiClient.PostAsync<_, Source>

        member this.SourceTransactions (source) =
            $"/v1/sources/{source}/source_transactions"
            |> this.RestApiClient.GetAsync<Source>

    and SubscriptionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/subscriptions"
            |> this.RestApiClient.GetAsync<Subscription>

        member this.Create () =
            $"/v1/subscriptions"
            |> this.RestApiClient.PostAsync<_, Subscription>

        member this.Update (subscription_exposed_id) =
            $"/v1/subscriptions/{subscription_exposed_id}"
            |> this.RestApiClient.PostAsync<_, Subscription>

        member this.Retrieve (subscription_exposed_id) =
            $"/v1/subscriptions/{subscription_exposed_id}"
            |> this.RestApiClient.GetAsync<Subscription>

        member this.Cancel (subscription_exposed_id) =
            $"/v1/subscriptions/{subscription_exposed_id}"
            |> this.RestApiClient.DeleteAsync<Subscription>

        member this.DeleteDiscount (subscription_exposed_id) =
            $"/v1/subscriptions/{subscription_exposed_id}/discount"
            |> this.RestApiClient.DeleteAsync<Subscription>

    and SubscriptionItemService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/subscription_items"
            |> this.RestApiClient.GetAsync<SubscriptionItem>

        member this.Retrieve (item) =
            $"/v1/subscription_items/{item}"
            |> this.RestApiClient.GetAsync<SubscriptionItem>

        member this.Create () =
            $"/v1/subscription_items"
            |> this.RestApiClient.PostAsync<_, SubscriptionItem>

        member this.Update (item) =
            $"/v1/subscription_items/{item}"
            |> this.RestApiClient.PostAsync<_, SubscriptionItem>

        member this.Delete (item) =
            $"/v1/subscription_items/{item}"
            |> this.RestApiClient.DeleteAsync<SubscriptionItem>

        member this.UsageRecordSummaries (subscription_item) =
            $"/v1/subscription_items/{subscription_item}/usage_record_summaries"
            |> this.RestApiClient.GetAsync<SubscriptionItem>

    and SubscriptionScheduleService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/subscription_schedules"
            |> this.RestApiClient.GetAsync<SubscriptionSchedule>

        member this.Create () =
            $"/v1/subscription_schedules"
            |> this.RestApiClient.PostAsync<_, SubscriptionSchedule>

        member this.Retrieve (schedule) =
            $"/v1/subscription_schedules/{schedule}"
            |> this.RestApiClient.GetAsync<SubscriptionSchedule>

        member this.Update (schedule) =
            $"/v1/subscription_schedules/{schedule}"
            |> this.RestApiClient.PostAsync<_, SubscriptionSchedule>

        member this.Cancel (schedule) =
            $"/v1/subscription_schedules/{schedule}/cancel"
            |> this.RestApiClient.PostAsync<_, SubscriptionSchedule>

        member this.Release (schedule) =
            $"/v1/subscription_schedules/{schedule}/release"
            |> this.RestApiClient.PostAsync<_, SubscriptionSchedule>

    and TaxIdService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create (customer) =
            $"/v1/customers/{customer}/tax_ids"
            |> this.RestApiClient.PostAsync<_, TaxId>

        member this.Retrieve (customer, id) =
            $"/v1/customers/{customer}/tax_ids/{id}"
            |> this.RestApiClient.GetAsync<TaxId>

        member this.List (customer) =
            $"/v1/customers/{customer}/tax_ids"
            |> this.RestApiClient.GetAsync<TaxId>

        member this.Delete (customer, id) =
            $"/v1/customers/{customer}/tax_ids/{id}"
            |> this.RestApiClient.DeleteAsync<TaxId>

    and TaxRateService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/tax_rates"
            |> this.RestApiClient.GetAsync<TaxRate>

        member this.Retrieve (tax_rate) =
            $"/v1/tax_rates/{tax_rate}"
            |> this.RestApiClient.GetAsync<TaxRate>

        member this.Create () =
            $"/v1/tax_rates"
            |> this.RestApiClient.PostAsync<_, TaxRate>

        member this.Update (tax_rate) =
            $"/v1/tax_rates/{tax_rate}"
            |> this.RestApiClient.PostAsync<_, TaxRate>

    and TerminalConnectionTokenService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create () =
            $"/v1/terminal/connection_tokens"
            |> this.RestApiClient.PostAsync<_, TerminalConnectionToken>

    and TerminalLocationService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Retrieve (location) =
            $"/v1/terminal/locations/{location}"
            |> this.RestApiClient.GetAsync<TerminalLocation>

        member this.Create () =
            $"/v1/terminal/locations"
            |> this.RestApiClient.PostAsync<_, TerminalLocation>

        member this.Update (location) =
            $"/v1/terminal/locations/{location}"
            |> this.RestApiClient.PostAsync<_, TerminalLocation>

        member this.List () =
            $"/v1/terminal/locations"
            |> this.RestApiClient.GetAsync<TerminalLocation>

        member this.Delete (location) =
            $"/v1/terminal/locations/{location}"
            |> this.RestApiClient.DeleteAsync<TerminalLocation>

    and TerminalReaderService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Update (reader) =
            $"/v1/terminal/readers/{reader}"
            |> this.RestApiClient.PostAsync<_, TerminalReader>

        member this.Retrieve (reader) =
            $"/v1/terminal/readers/{reader}"
            |> this.RestApiClient.GetAsync<TerminalReader>

        member this.Create () =
            $"/v1/terminal/readers"
            |> this.RestApiClient.PostAsync<_, TerminalReader>

        member this.List () =
            $"/v1/terminal/readers"
            |> this.RestApiClient.GetAsync<TerminalReader>

        member this.Delete (reader) =
            $"/v1/terminal/readers/{reader}"
            |> this.RestApiClient.DeleteAsync<TerminalReader>

    and ThreeDSecureService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Retrieve (three_d_secure) =
            $"/v1/3d_secure/{three_d_secure}"
            |> this.RestApiClient.GetAsync<ThreeDSecure>

        member this.Create () =
            $"/v1/3d_secure"
            |> this.RestApiClient.PostAsync<_, ThreeDSecure>

    and TokenService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Retrieve (token) =
            $"/v1/tokens/{token}"
            |> this.RestApiClient.GetAsync<Token>

        member this.Create () =
            $"/v1/tokens"
            |> this.RestApiClient.PostAsync<_, Token>

    and TopupService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create () =
            $"/v1/topups"
            |> this.RestApiClient.PostAsync<_, Topup>

        member this.List () =
            $"/v1/topups"
            |> this.RestApiClient.GetAsync<Topup>

        member this.Retrieve (topup) =
            $"/v1/topups/{topup}"
            |> this.RestApiClient.GetAsync<Topup>

        member this.Update (topup) =
            $"/v1/topups/{topup}"
            |> this.RestApiClient.PostAsync<_, Topup>

        member this.Cancel (topup) =
            $"/v1/topups/{topup}/cancel"
            |> this.RestApiClient.PostAsync<_, Topup>

    and TransferService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create () =
            $"/v1/transfers"
            |> this.RestApiClient.PostAsync<_, Transfer>

        member this.List () =
            $"/v1/transfers"
            |> this.RestApiClient.GetAsync<Transfer>

        member this.Retrieve (transfer) =
            $"/v1/transfers/{transfer}"
            |> this.RestApiClient.GetAsync<Transfer>

        member this.Update (transfer) =
            $"/v1/transfers/{transfer}"
            |> this.RestApiClient.PostAsync<_, Transfer>

    and TransferReversalService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create (id) =
            $"/v1/transfers/{id}/reversals"
            |> this.RestApiClient.PostAsync<_, TransferReversal>

        member this.List (id) =
            $"/v1/transfers/{id}/reversals"
            |> this.RestApiClient.GetAsync<TransferReversal>

        member this.Retrieve (transfer, id) =
            $"/v1/transfers/{transfer}/reversals/{id}"
            |> this.RestApiClient.GetAsync<TransferReversal>

        member this.Update (transfer, id) =
            $"/v1/transfers/{transfer}/reversals/{id}"
            |> this.RestApiClient.PostAsync<_, TransferReversal>

    and UsageRecordService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.Create (subscription_item) =
            $"/v1/subscription_items/{subscription_item}/usage_records"
            |> this.RestApiClient.PostAsync<_, UsageRecord>

    and UsageRecordSummaryService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List (subscription_item) =
            $"/v1/subscription_items/{subscription_item}/usage_record_summaries"
            |> this.RestApiClient.GetAsync<UsageRecordSummary>

    and WebhookEndpointService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        member this.List () =
            $"/v1/webhook_endpoints"
            |> this.RestApiClient.GetAsync<WebhookEndpoint>

        member this.Retrieve (webhook_endpoint) =
            $"/v1/webhook_endpoints/{webhook_endpoint}"
            |> this.RestApiClient.GetAsync<WebhookEndpoint>

        member this.Create () =
            $"/v1/webhook_endpoints"
            |> this.RestApiClient.PostAsync<_, WebhookEndpoint>

        member this.Update (webhook_endpoint) =
            $"/v1/webhook_endpoints/{webhook_endpoint}"
            |> this.RestApiClient.PostAsync<_, WebhookEndpoint>

        member this.Delete (webhook_endpoint) =
            $"/v1/webhook_endpoints/{webhook_endpoint}"
            |> this.RestApiClient.DeleteAsync<WebhookEndpoint>

