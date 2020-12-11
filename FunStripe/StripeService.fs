namespace FunStripe

open FSharp.Json

open StripeModel

module StripeService =

    type AccountService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves the details of an account.</p>
        member this.Retrieve (?expand: string list) =
            $"/v1/account"
            |> this.RestApiClient.GetAsync<Account>

        ///<p>Retrieves the details of an account.</p>
        member this.Retrieve (account: string, ?expand: string list) =
            $"/v1/accounts/{account}"
            |> this.RestApiClient.GetAsync<Account>

        ///<p>Updates a connected <a href="/docs/connect/accounts">Express or Custom account</a> by setting the values of the parameters passed. Any parameters not provided are left unchanged. Most parameters can be changed only for Custom accounts. (These are marked <strong>Custom Only</strong> below.) Parameters marked <strong>Custom and Express</strong> are supported by both account types.
        ///To update your own account, use the <a href="https://dashboard.stripe.com/account">Dashboard</a>. Refer to our <a href="/docs/connect/updating-accounts">Connect</a> documentation to learn more about updating accounts.</p>
        member this.Update ((``params``: PostAccountsAccountParams), account: string) =
            $"/v1/accounts/{account}"
            |> this.RestApiClient.PostAsync<_, Account> ``params``

        ///<p>Returns a list of accounts connected to your platform via <a href="/docs/connect">Connect</a>. If you’re not a platform, the list is empty.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/accounts"
            |> this.RestApiClient.GetAsync<Account>

        ///<p>With <a href="/docs/connect">Connect</a>, you can create Stripe accounts for your users.
        ///To do this, you’ll first need to <a href="https://dashboard.stripe.com/account/applications/settings">register your platform</a>.</p>
        member this.Create ((``params``: PostAccountsParams)) =
            $"/v1/accounts"
            |> this.RestApiClient.PostAsync<_, Account> ``params``

        ///<p>With <a href="/docs/connect">Connect</a>, you can delete Custom or Express accounts you manage.
        ///Accounts created using test-mode keys can be deleted at any time. Accounts created using live-mode keys can only be deleted once all balances are zero.
        ///If you want to delete your own account, use the <a href="https://dashboard.stripe.com/account">account information tab in your account settings</a> instead.</p>
        member this.Delete (account: string) =
            $"/v1/accounts/{account}"
            |> this.RestApiClient.DeleteAsync<DeletedAccount>

        ///<p>With <a href="/docs/connect">Connect</a>, you may flag accounts as suspicious.
        ///Test-mode Custom and Express accounts can be rejected at any time. Accounts created using live-mode keys may only be rejected once all balances are zero.</p>
        member this.Reject ((``params``: PostAccountsAccountRejectParams), account: string) =
            $"/v1/accounts/{account}/reject"
            |> this.RestApiClient.PostAsync<_, Account> ``params``

        ///<p>Returns a list of capabilities associated with the account. The capabilities are returned sorted by creation date, with the most recent capability appearing first.</p>
        member this.Capabilities (account: string, ?expand: string list) =
            $"/v1/accounts/{account}/capabilities"
            |> this.RestApiClient.GetAsync<Capability>

    and AccountLinkService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Creates an AccountLink object that includes a single-use Stripe URL that the platform can redirect their user to in order to take them through the Connect Onboarding flow.</p>
        member this.Create ((``params``: PostAccountLinksParams)) =
            $"/v1/account_links"
            |> this.RestApiClient.PostAsync<_, AccountLink> ``params``

    and ApplePayDomainService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>List apple pay domains.</p>
        member this.List (?domainName: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/apple_pay/domains"
            |> this.RestApiClient.GetAsync<ApplePayDomain>

        ///<p>Create an apple pay domain.</p>
        member this.Create ((``params``: PostApplePayDomainsParams)) =
            $"/v1/apple_pay/domains"
            |> this.RestApiClient.PostAsync<_, ApplePayDomain> ``params``

        ///<p>Retrieve an apple pay domain.</p>
        member this.Retrieve (domain: string, ?expand: string list) =
            $"/v1/apple_pay/domains/{domain}"
            |> this.RestApiClient.GetAsync<ApplePayDomain>

        ///<p>Delete an apple pay domain.</p>
        member this.Delete (domain: string) =
            $"/v1/apple_pay/domains/{domain}"
            |> this.RestApiClient.DeleteAsync<DeletedApplePayDomain>

    and ApplicationFeeService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of application fees you’ve previously collected. The application fees are returned in sorted order, with the most recent fees appearing first.</p>
        member this.List (?charge: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/application_fees"
            |> this.RestApiClient.GetAsync<ApplicationFee>

        ///<p>Retrieves the details of an application fee that your account has collected. The same information is returned when refunding the application fee.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/application_fees/{id}"
            |> this.RestApiClient.GetAsync<ApplicationFee>

    and BalanceService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves the current account balance, based on the authentication that was used to make the request.
        /// For a sample request, see <a href="/docs/connect/account-balances#accounting-for-negative-balances">Accounting for negative balances</a>.</p>
        member this.Retrieve (?expand: string list) =
            $"/v1/balance"
            |> this.RestApiClient.GetAsync<Balance>

    and BalanceTransactionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of transactions that have contributed to the Stripe account balance (e.g., charges, transfers, and so forth). The transactions are returned in sorted order, with the most recent transactions appearing first.
        ///Note that this endpoint was previously called “Balance history” and used the path <code>/v1/balance/history</code>.</p>
        member this.List (?availableOn: int, ?created: int, ?currency: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?payout: string, ?source: string, ?startingAfter: string, ?``type``: string) =
            $"/v1/balance_transactions"
            |> this.RestApiClient.GetAsync<BalanceTransaction>

        ///<p>Retrieves the balance transaction with the given ID.
        ///Note that this endpoint previously used the path <code>/v1/balance/history/:id</code>.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/balance_transactions/{id}"
            |> this.RestApiClient.GetAsync<BalanceTransaction>

    and BankAccountService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Update a specified source for a given customer.</p>
        member this.UpdateForCustomer ((``params``: PostCustomersCustomerSourcesIdParams), customer: string, id: string) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.PostAsync<_, Card> ``params``

        ///<p>Delete a specified source for a given customer.</p>
        member this.DeleteForCustomer ((``params``: DeleteCustomersCustomerSourcesIdParams), customer: string, id: string) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.DeleteAsync<PaymentSource>

        ///<p>Verify a specified bank account for a given customer.</p>
        member this.VerifyForCustomer ((``params``: PostCustomersCustomerSourcesIdVerifyParams), customer: string, id: string) =
            $"/v1/customers/{customer}/sources/{id}/verify"
            |> this.RestApiClient.PostAsync<_, BankAccount> ``params``

        ///<p>Updates the metadata, account holder name, and account holder type of a bank account belonging to a <a href="/docs/connect/custom-accounts">Custom account</a>, and optionally sets it as the default for its currency. Other bank account details are not editable by design.
        ///You can re-enable a disabled bank account by performing an update call without providing any arguments or changes.</p>
        member this.UpdateForAccount ((``params``: PostAccountsAccountExternalAccountsIdParams), account: string, id: string) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.PostAsync<_, ExternalAccount> ``params``

        ///<p>Delete a specified external account for a given account.</p>
        member this.DeleteForAccount (account: string, id: string) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.DeleteAsync<DeletedExternalAccount>

    and BillingPortalSessionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Creates a session of the customer portal.</p>
        member this.Create ((``params``: PostBillingPortalSessionsParams)) =
            $"/v1/billing_portal/sessions"
            |> this.RestApiClient.PostAsync<_, BillingPortalSession> ``params``

    and BitcoinReceiverService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of your receivers. Receivers are returned sorted by creation date, with the most recently created receivers appearing first.</p>
        member this.List (?active: bool, ?endingBefore: string, ?expand: string list, ?filled: bool, ?limit: int, ?startingAfter: string, ?uncapturedFunds: bool) =
            $"/v1/bitcoin/receivers"
            |> this.RestApiClient.GetAsync<BitcoinReceiver>

        ///<p>Retrieves the Bitcoin receiver with the given ID.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/bitcoin/receivers/{id}"
            |> this.RestApiClient.GetAsync<BitcoinReceiver>

    and BitcoinTransactionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>List bitcoin transacitons for a given receiver.</p>
        member this.List (receiver: string, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/bitcoin/receivers/{receiver}/transactions"
            |> this.RestApiClient.GetAsync<BitcoinTransaction>

    and CapabilityService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of capabilities associated with the account. The capabilities are returned sorted by creation date, with the most recent capability appearing first.</p>
        member this.ListForAccount (account: string, ?expand: string list) =
            $"/v1/accounts/{account}/capabilities"
            |> this.RestApiClient.GetAsync<Capability>

        ///<p>Retrieves information about the specified Account Capability.</p>
        member this.RetrieveForAccount (account: string, capability: string, ?expand: string list) =
            $"/v1/accounts/{account}/capabilities/{capability}"
            |> this.RestApiClient.GetAsync<Capability>

        ///<p>Updates an existing Account Capability.</p>
        member this.UpdateForAccount ((``params``: PostAccountsAccountCapabilitiesCapabilityParams), account: string, capability: string) =
            $"/v1/accounts/{account}/capabilities/{capability}"
            |> this.RestApiClient.PostAsync<_, Capability> ``params``

    and CardService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Update a specified source for a given customer.</p>
        member this.UpdateForCustomer ((``params``: PostCustomersCustomerSourcesIdParams), customer: string, id: string) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.PostAsync<_, Card> ``params``

        ///<p>Delete a specified source for a given customer.</p>
        member this.DeleteForCustomer ((``params``: DeleteCustomersCustomerSourcesIdParams), customer: string, id: string) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.DeleteAsync<PaymentSource>

        ///<p>Updates the metadata, account holder name, and account holder type of a bank account belonging to a <a href="/docs/connect/custom-accounts">Custom account</a>, and optionally sets it as the default for its currency. Other bank account details are not editable by design.
        ///You can re-enable a disabled bank account by performing an update call without providing any arguments or changes.</p>
        member this.UpdateForAccount ((``params``: PostAccountsAccountExternalAccountsIdParams), account: string, id: string) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.PostAsync<_, ExternalAccount> ``params``

        ///<p>Delete a specified external account for a given account.</p>
        member this.DeleteForAccount (account: string, id: string) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.DeleteAsync<DeletedExternalAccount>

    and ChargeService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of charges you’ve previously created. The charges are returned in sorted order, with the most recent charges appearing first.</p>
        member this.List (?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string, ?transferGroup: string) =
            $"/v1/charges"
            |> this.RestApiClient.GetAsync<Charge>

        ///<p>To charge a credit card or other payment source, you create a <code>Charge</code> object. If your API key is in test mode, the supplied payment source (e.g., card) won’t actually be charged, although everything else will occur as if in live mode. (Stripe assumes that the charge would have completed successfully).</p>
        member this.Create ((``params``: PostChargesParams)) =
            $"/v1/charges"
            |> this.RestApiClient.PostAsync<_, Charge> ``params``

        ///<p>Retrieves the details of a charge that has previously been created. Supply the unique charge ID that was returned from your previous request, and Stripe will return the corresponding charge information. The same information is returned when creating or refunding the charge.</p>
        member this.Retrieve (charge: string, ?expand: string list) =
            $"/v1/charges/{charge}"
            |> this.RestApiClient.GetAsync<Charge>

        ///<p>Updates the specified charge by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((``params``: PostChargesChargeParams), charge: string) =
            $"/v1/charges/{charge}"
            |> this.RestApiClient.PostAsync<_, Charge> ``params``

        ///<p>Capture the payment of an existing, uncaptured, charge. This is the second half of the two-step payment flow, where first you <a href="#create_charge">created a charge</a> with the capture option set to false.
        ///Uncaptured payments expire exactly seven days after they are created. If they are not captured by that point in time, they will be marked as refunded and will no longer be capturable.</p>
        member this.Capture ((``params``: PostChargesChargeCaptureParams), charge: string) =
            $"/v1/charges/{charge}/capture"
            |> this.RestApiClient.PostAsync<_, Charge> ``params``

    and CheckoutSessionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of Checkout Sessions.</p>
        member this.List (?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string, ?subscription: string) =
            $"/v1/checkout/sessions"
            |> this.RestApiClient.GetAsync<CheckoutSession>

        ///<p>Retrieves a Session object.</p>
        member this.Retrieve (session: string, ?expand: string list) =
            $"/v1/checkout/sessions/{session}"
            |> this.RestApiClient.GetAsync<CheckoutSession>

        ///<p>Creates a Session object.</p>
        member this.Create ((``params``: PostCheckoutSessionsParams)) =
            $"/v1/checkout/sessions"
            |> this.RestApiClient.PostAsync<_, CheckoutSession> ``params``

    and CountrySpecService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Lists all Country Spec objects available in the API.</p>
        member this.List (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/country_specs"
            |> this.RestApiClient.GetAsync<CountrySpec>

        ///<p>Returns a Country Spec for a given Country code.</p>
        member this.Retrieve (country: string, ?expand: string list) =
            $"/v1/country_specs/{country}"
            |> this.RestApiClient.GetAsync<CountrySpec>

    and CouponService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of your coupons.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/coupons"
            |> this.RestApiClient.GetAsync<Coupon>

        ///<p>You can create coupons easily via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. Coupon creation is also accessible via the API if you need to create coupons on the fly.
        ///A coupon has either a <code>percent_off</code> or an <code>amount_off</code> and <code>currency</code>. If you set an <code>amount_off</code>, that amount will be subtracted from any invoice’s subtotal. For example, an invoice with a subtotal of <currency>100</currency> will have a final total of <currency>0</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it and an invoice with a subtotal of <currency>300</currency> will have a final total of <currency>100</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it.</p>
        member this.Create ((``params``: PostCouponsParams)) =
            $"/v1/coupons"
            |> this.RestApiClient.PostAsync<_, Coupon> ``params``

        ///<p>Retrieves the coupon with the given ID.</p>
        member this.Retrieve (coupon: string, ?expand: string list) =
            $"/v1/coupons/{coupon}"
            |> this.RestApiClient.GetAsync<Coupon>

        ///<p>Updates the metadata of a coupon. Other coupon details (currency, duration, amount_off) are, by design, not editable.</p>
        member this.Update ((``params``: PostCouponsCouponParams), coupon: string) =
            $"/v1/coupons/{coupon}"
            |> this.RestApiClient.PostAsync<_, Coupon> ``params``

        ///<p>You can delete coupons via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. However, deleting a coupon does not affect any customers who have already applied the coupon; it means that new customers can’t redeem the coupon. You can also delete coupons via the API.</p>
        member this.Delete (coupon: string) =
            $"/v1/coupons/{coupon}"
            |> this.RestApiClient.DeleteAsync<DeletedCoupon>

    and CreditNoteService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

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
        member this.Create ((``params``: PostCreditNotesParams)) =
            $"/v1/credit_notes"
            |> this.RestApiClient.PostAsync<_, CreditNote> ``params``

        ///<p>Get a preview of a credit note without creating it.</p>
        member this.Preview (invoice: string, ?amount: int, ?creditAmount: int, ?expand: string list, ?lines: string list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: string, ?refund: string, ?refundAmount: int) =
            $"/v1/credit_notes/preview"
            |> this.RestApiClient.GetAsync<CreditNote>

        ///<p>Retrieves the credit note object with the given identifier.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/credit_notes/{id}"
            |> this.RestApiClient.GetAsync<CreditNote>

        ///<p>Returns a list of credit notes.</p>
        member this.List (?customer: string, ?endingBefore: string, ?expand: string list, ?invoice: string, ?limit: int, ?startingAfter: string) =
            $"/v1/credit_notes"
            |> this.RestApiClient.GetAsync<CreditNote>

        ///<p>Updates an existing credit note.</p>
        member this.Update ((``params``: PostCreditNotesIdParams), id: string) =
            $"/v1/credit_notes/{id}"
            |> this.RestApiClient.PostAsync<_, CreditNote> ``params``

        ///<p>Marks a credit note as void. Learn more about <a href="/docs/billing/invoices/credit-notes#voiding">voiding credit notes</a>.</p>
        member this.VoidCreditNote ((``params``: PostCreditNotesIdVoidParams), id: string) =
            $"/v1/credit_notes/{id}/void"
            |> this.RestApiClient.PostAsync<_, CreditNote> ``params``

        ///<p>When retrieving a credit note preview, you’ll get a <strong>lines</strong> property containing the first handful of those items. This URL you can retrieve the full (paginated) list of line items.</p>
        member this.PreviewLines (invoice: string, ?amount: int, ?creditAmount: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?lines: string list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: string, ?refund: string, ?refundAmount: int, ?startingAfter: string) =
            $"/v1/credit_notes/preview/lines"
            |> this.RestApiClient.GetAsync<CreditNoteLineItem>

    and CreditNoteLineItemService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>When retrieving a credit note, you’ll get a <strong>lines</strong> property containing the the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
        member this.List (creditNote: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/credit_notes/{creditNote}/lines"
            |> this.RestApiClient.GetAsync<CreditNoteLineItem>

    and CustomerService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of your customers. The customers are returned sorted by creation date, with the most recent customers appearing first.</p>
        member this.List (?created: int, ?email: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/customers"
            |> this.RestApiClient.GetAsync<Customer>

        ///<p>Creates a new customer object.</p>
        member this.Create ((``params``: PostCustomersParams)) =
            $"/v1/customers"
            |> this.RestApiClient.PostAsync<_, Customer> ``params``

        ///<p>Retrieves the details of an existing customer. You need only supply the unique customer identifier that was returned upon customer creation.</p>
        member this.Retrieve (customer: string, ?expand: string list) =
            $"/v1/customers/{customer}"
            |> this.RestApiClient.GetAsync<Customer>

        ///<p>Updates the specified customer by setting the values of the parameters passed. Any parameters not provided will be left unchanged. For example, if you pass the <strong>source</strong> parameter, that becomes the customer’s active source (e.g., a card) to be used for all charges in the future. When you update a customer to a new valid card source by passing the <strong>source</strong> parameter: for each of the customer’s current subscriptions, if the subscription bills automatically and is in the <code>past_due</code> state, then the latest open invoice for the subscription with automatic collection enabled will be retried. This retry will not count as an automatic retry, and will not affect the next regularly scheduled payment for the invoice. Changing the <strong>default_source</strong> for a customer will not trigger this behavior.
        ///This request accepts mostly the same arguments as the customer creation call.</p>
        member this.Update ((``params``: PostCustomersCustomerParams), customer: string) =
            $"/v1/customers/{customer}"
            |> this.RestApiClient.PostAsync<_, Customer> ``params``

        ///<p>Permanently deletes a customer. It cannot be undone. Also immediately cancels any active subscriptions on the customer.</p>
        member this.Delete (customer: string) =
            $"/v1/customers/{customer}"
            |> this.RestApiClient.DeleteAsync<DeletedCustomer>

        ///<p>Removes the currently applied discount on a customer.</p>
        member this.DeleteDiscount (customer: string) =
            $"/v1/customers/{customer}/discount"
            |> this.RestApiClient.DeleteAsync<DeletedDiscount>

    and CustomerBalanceTransactionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves a specific customer balance transaction that updated the customer’s <a href="/docs/billing/customer/balance">balances</a>.</p>
        member this.Retrieve (customer: string, transaction: string, ?expand: string list) =
            $"/v1/customers/{customer}/balance_transactions/{transaction}"
            |> this.RestApiClient.GetAsync<CustomerBalanceTransaction>

        ///<p>Returns a list of transactions that updated the customer’s <a href="/docs/billing/customer/balance">balances</a>.</p>
        member this.List (customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/customers/{customer}/balance_transactions"
            |> this.RestApiClient.GetAsync<CustomerBalanceTransaction>

        ///<p>Creates an immutable transaction that updates the customer’s credit <a href="/docs/billing/customer/balance">balance</a>.</p>
        member this.Create ((``params``: PostCustomersCustomerBalanceTransactionsParams), customer: string) =
            $"/v1/customers/{customer}/balance_transactions"
            |> this.RestApiClient.PostAsync<_, CustomerBalanceTransaction> ``params``

        ///<p>Most credit balance transaction fields are immutable, but you may update its <code>description</code> and <code>metadata</code>.</p>
        member this.Update ((``params``: PostCustomersCustomerBalanceTransactionsTransactionParams), customer: string, transaction: string) =
            $"/v1/customers/{customer}/balance_transactions/{transaction}"
            |> this.RestApiClient.PostAsync<_, CustomerBalanceTransaction> ``params``

    and DisputeService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of your disputes.</p>
        member this.List (?charge: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string) =
            $"/v1/disputes"
            |> this.RestApiClient.GetAsync<Dispute>

        ///<p>Retrieves the dispute with the given ID.</p>
        member this.Retrieve (dispute: string, ?expand: string list) =
            $"/v1/disputes/{dispute}"
            |> this.RestApiClient.GetAsync<Dispute>

        ///<p>When you get a dispute, contacting your customer is always the best first step. If that doesn’t work, you can submit evidence to help us resolve the dispute in your favor. You can do this in your <a href="https://dashboard.stripe.com/disputes">dashboard</a>, but if you prefer, you can use the API to submit evidence programmatically.
        ///Depending on your dispute type, different evidence fields will give you a better chance of winning your dispute. To figure out which evidence fields to provide, see our <a href="/docs/disputes/categories">guide to dispute types</a>.</p>
        member this.Update ((``params``: PostDisputesDisputeParams), dispute: string) =
            $"/v1/disputes/{dispute}"
            |> this.RestApiClient.PostAsync<_, Dispute> ``params``

        ///<p>Closing the dispute for a charge indicates that you do not have any evidence to submit and are essentially dismissing the dispute, acknowledging it as lost.
        ///The status of the dispute will change from <code>needs_response</code> to <code>lost</code>. <em>Closing a dispute is irreversible</em>.</p>
        member this.Close ((``params``: PostDisputesDisputeCloseParams), dispute: string) =
            $"/v1/disputes/{dispute}/close"
            |> this.RestApiClient.PostAsync<_, Dispute> ``params``

    and EphemeralKeyService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Creates a short-lived API key for a given resource.</p>
        member this.Create ((``params``: PostEphemeralKeysParams)) =
            $"/v1/ephemeral_keys"
            |> this.RestApiClient.PostAsync<_, EphemeralKey> ``params``

        ///<p>Invalidates a short-lived API key for a given resource.</p>
        member this.Delete ((``params``: DeleteEphemeralKeysKeyParams), key: string) =
            $"/v1/ephemeral_keys/{key}"
            |> this.RestApiClient.DeleteAsync<EphemeralKey>

    and EventService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>List events, going back up to 30 days. Each event data is rendered according to Stripe API version at its creation time, specified in <a href="/docs/api/events/object">event object</a> <code>api_version</code> attribute (not according to your current Stripe API version or <code>Stripe-Version</code> header).</p>
        member this.List (?created: int, ?deliverySuccess: bool, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?``type``: string, ?types: string list) =
            $"/v1/events"
            |> this.RestApiClient.GetAsync<Event>

        ///<p>Retrieves the details of an event. Supply the unique identifier of the event, which you might have received in a webhook.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/events/{id}"
            |> this.RestApiClient.GetAsync<Event>

    and ExchangeRateService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of objects that contain the rates at which foreign currencies are converted to one another. Only shows the currencies for which Stripe supports.</p>
        member this.List (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/exchange_rates"
            |> this.RestApiClient.GetAsync<ExchangeRate>

        ///<p>Retrieves the exchange rates from the given currency to every supported currency.</p>
        member this.Retrieve (rateId: string, ?expand: string list) =
            $"/v1/exchange_rates/{rateId}"
            |> this.RestApiClient.GetAsync<ExchangeRate>

    and ExternalAccountService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>List external accounts for an account.</p>
        member this.ListForAccount (account: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/accounts/{account}/external_accounts"
            |> this.RestApiClient.GetAsync<ExternalAccount>

        ///<p>Retrieve a specified external account for a given account.</p>
        member this.RetrieveForAccount (account: string, id: string, ?expand: string list) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.GetAsync<ExternalAccount>

        ///<p>Create an external account for a given account.</p>
        member this.CreateForAccount ((``params``: PostAccountsAccountExternalAccountsParams), account: string) =
            $"/v1/accounts/{account}/external_accounts"
            |> this.RestApiClient.PostAsync<_, ExternalAccount> ``params``

        ///<p>Updates the metadata, account holder name, and account holder type of a bank account belonging to a <a href="/docs/connect/custom-accounts">Custom account</a>, and optionally sets it as the default for its currency. Other bank account details are not editable by design.
        ///You can re-enable a disabled bank account by performing an update call without providing any arguments or changes.</p>
        member this.UpdateForAccount ((``params``: PostAccountsAccountExternalAccountsIdParams), account: string, id: string) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.PostAsync<_, ExternalAccount> ``params``

        ///<p>Delete a specified external account for a given account.</p>
        member this.DeleteForAccount (account: string, id: string) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.DeleteAsync<DeletedExternalAccount>

    and FeeRefundService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Refunds an application fee that has previously been collected but not yet refunded.
        ///Funds will be refunded to the Stripe account from which the fee was originally collected.
        ///You can optionally refund only part of an application fee.
        ///You can do so multiple times, until the entire fee has been refunded.
        ///Once entirely refunded, an application fee can’t be refunded again.
        ///This method will raise an error when called on an already-refunded application fee,
        ///or when trying to refund more money than is left on an application fee.</p>
        member this.CreateForApplicationFee ((``params``: PostApplicationFeesIdRefundsParams), id: string) =
            $"/v1/application_fees/{id}/refunds"
            |> this.RestApiClient.PostAsync<_, FeeRefund> ``params``

        ///<p>You can see a list of the refunds belonging to a specific application fee. Note that the 10 most recent refunds are always available by default on the application fee object. If you need more than those 10, you can use this API method and the <code>limit</code> and <code>starting_after</code> parameters to page through additional refunds.</p>
        member this.ListForApplicationFee (id: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/application_fees/{id}/refunds"
            |> this.RestApiClient.GetAsync<FeeRefund>

        ///<p>By default, you can see the 10 most recent refunds stored directly on the application fee object, but you can also retrieve details about a specific refund stored on the application fee.</p>
        member this.RetrieveForApplicationFee (fee: string, id: string, ?expand: string list) =
            $"/v1/application_fees/{fee}/refunds/{id}"
            |> this.RestApiClient.GetAsync<FeeRefund>

        ///<p>Updates the specified application fee refund by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request only accepts metadata as an argument.</p>
        member this.UpdateForApplicationFee ((``params``: PostApplicationFeesFeeRefundsIdParams), fee: string, id: string) =
            $"/v1/application_fees/{fee}/refunds/{id}"
            |> this.RestApiClient.PostAsync<_, FeeRefund> ``params``

    and FileService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of the files that your account has access to. The files are returned sorted by creation date, with the most recently created files appearing first.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?purpose: string, ?startingAfter: string) =
            $"/v1/files"
            |> this.RestApiClient.GetAsync<File>

        ///<p>Retrieves the details of an existing file object. Supply the unique file ID from a file, and Stripe will return the corresponding file object. To access file contents, see the <a href="/docs/file-upload#download-file-contents">File Upload Guide</a>.</p>
        member this.Retrieve (file: string, ?expand: string list) =
            $"/v1/files/{file}"
            |> this.RestApiClient.GetAsync<File>

        ///<p>To upload a file to Stripe, you’ll need to send a request of type <code>multipart/form-data</code>. The request should contain the file you would like to upload, as well as the parameters for creating a file.
        ///All of Stripe’s officially supported Client libraries should have support for sending <code>multipart/form-data</code>.</p>
        member this.Create () =
            $"/v1/files"
            |> this.RestApiClient.PostWithoutAsync<File>

    and FileLinkService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves the file link with the given ID.</p>
        member this.Retrieve (link: string, ?expand: string list) =
            $"/v1/file_links/{link}"
            |> this.RestApiClient.GetAsync<FileLink>

        ///<p>Creates a new file link object.</p>
        member this.Create ((``params``: PostFileLinksParams)) =
            $"/v1/file_links"
            |> this.RestApiClient.PostAsync<_, FileLink> ``params``

        ///<p>Updates an existing file link object. Expired links can no longer be updated.</p>
        member this.Update ((``params``: PostFileLinksLinkParams), link: string) =
            $"/v1/file_links/{link}"
            |> this.RestApiClient.PostAsync<_, FileLink> ``params``

        ///<p>Returns a list of file links.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?expired: bool, ?file: string, ?limit: int, ?startingAfter: string) =
            $"/v1/file_links"
            |> this.RestApiClient.GetAsync<FileLink>

    and InvoiceService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>You can list all invoices, or list the invoices for a specific customer. The invoices are returned sorted by creation date, with the most recently created invoices appearing first.</p>
        member this.List (?collectionMethod: string, ?created: int, ?customer: string, ?dueDate: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string, ?subscription: string) =
            $"/v1/invoices"
            |> this.RestApiClient.GetAsync<Invoice>

        ///<p>At any time, you can preview the upcoming invoice for a customer. This will show you all the charges that are pending, including subscription renewal charges, invoice item charges, etc. It will also show you any discounts that are applicable to the invoice.
        ///Note that when you are viewing an upcoming invoice, you are simply viewing a preview – the invoice has not yet been created. As such, the upcoming invoice will not show up in invoice listing calls, and you cannot use the API to pay or edit the invoice. If you want to change the amount that your customer will be billed, you can add, remove, or update pending invoice items, or update the customer’s discount.
        ///You can preview the effects of updating a subscription, including a preview of what proration will take place. To ensure that the actual proration is calculated exactly the same as the previewed proration, you should pass a <code>proration_date</code> parameter when doing the actual subscription update. The value passed in should be the same as the <code>subscription_proration_date</code> returned on the upcoming invoice resource. The recommended way to get only the prorations being previewed is to consider only proration line items where <code>period[start]</code> is equal to the <code>subscription_proration_date</code> on the upcoming invoice resource.</p>
        member this.Upcoming (?coupon: string, ?subscriptionStartDate: int, ?subscriptionProrationDate: int, ?subscriptionProrationBehavior: string, ?subscriptionItems: string list, ?subscriptionDefaultTaxRates: string list, ?subscriptionCancelNow: bool, ?subscriptionCancelAtPeriodEnd: bool, ?subscriptionCancelAt: int, ?subscriptionBillingCycleAnchor: string, ?subscription: string, ?schedule: string, ?invoiceItems: string list, ?expand: string list, ?discounts: string list, ?customer: string, ?subscriptionTrialEnd: string, ?subscriptionTrialFromPlan: bool) =
            $"/v1/invoices/upcoming"
            |> this.RestApiClient.GetAsync<Invoice>

        ///<p>This endpoint creates a draft invoice for a given customer. The draft invoice created pulls in all pending invoice items on that customer, including prorations. The invoice remains a draft until you <a href="#finalize_invoice">finalize</a> the invoice, which allows you to <a href="#pay_invoice">pay</a> or <a href="#send_invoice">send</a> the invoice to your customers.</p>
        member this.Create ((``params``: PostInvoicesParams)) =
            $"/v1/invoices"
            |> this.RestApiClient.PostAsync<_, Invoice> ``params``

        ///<p>Retrieves the invoice with the given ID.</p>
        member this.Retrieve (invoice: string, ?expand: string list) =
            $"/v1/invoices/{invoice}"
            |> this.RestApiClient.GetAsync<Invoice>

        ///<p>Draft invoices are fully editable. Once an invoice is <a href="/docs/billing/invoices/workflow#finalized">finalized</a>,
        ///monetary values, as well as <code>collection_method</code>, become uneditable.
        ///If you would like to stop the Stripe Billing engine from automatically finalizing, reattempting payments on,
        ///sending reminders for, or <a href="/docs/billing/invoices/reconciliation">automatically reconciling</a> invoices, pass
        ///<code>auto_advance=false</code>.</p>
        member this.Update ((``params``: PostInvoicesInvoiceParams), invoice: string) =
            $"/v1/invoices/{invoice}"
            |> this.RestApiClient.PostAsync<_, Invoice> ``params``

        ///<p>Permanently deletes a one-off invoice draft. This cannot be undone. Attempts to delete invoices that are no longer in a draft state will fail; once an invoice has been finalized or if an invoice is for a subscription, it must be <a href="#void_invoice">voided</a>.</p>
        member this.Delete (invoice: string) =
            $"/v1/invoices/{invoice}"
            |> this.RestApiClient.DeleteAsync<DeletedInvoice>

        ///<p>Stripe automatically creates and then attempts to collect payment on invoices for customers on subscriptions according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to attempt payment on an invoice out of the normal collection schedule or for some other reason, you can do so.</p>
        member this.Pay ((``params``: PostInvoicesInvoicePayParams), invoice: string) =
            $"/v1/invoices/{invoice}/pay"
            |> this.RestApiClient.PostAsync<_, Invoice> ``params``

        ///<p>Stripe automatically finalizes drafts before sending and attempting payment on invoices. However, if you’d like to finalize a draft invoice manually, you can do so using this method.</p>
        member this.FinalizeInvoice ((``params``: PostInvoicesInvoiceFinalizeParams), invoice: string) =
            $"/v1/invoices/{invoice}/finalize"
            |> this.RestApiClient.PostAsync<_, Invoice> ``params``

        ///<p>When retrieving an upcoming invoice, you’ll get a <strong>lines</strong> property containing the total count of line items and the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
        member this.UpcomingLines (?coupon: string, ?subscriptionStartDate: int, ?subscriptionProrationDate: int, ?subscriptionProrationBehavior: string, ?subscriptionItems: string list, ?subscriptionDefaultTaxRates: string list, ?subscriptionCancelNow: bool, ?subscriptionCancelAtPeriodEnd: bool, ?subscriptionCancelAt: int, ?subscriptionTrialEnd: string, ?subscriptionBillingCycleAnchor: string, ?startingAfter: string, ?schedule: string, ?limit: int, ?invoiceItems: string list, ?expand: string list, ?endingBefore: string, ?discounts: string list, ?customer: string, ?subscription: string, ?subscriptionTrialFromPlan: bool) =
            $"/v1/invoices/upcoming/lines"
            |> this.RestApiClient.GetAsync<LineItem>

        ///<p>Stripe will automatically send invoices to customers according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to manually send an invoice to your customer out of the normal schedule, you can do so. When sending invoices that have already been paid, there will be no reference to the payment in the email.
        ///Requests made in test-mode result in no emails being sent, despite sending an <code>invoice.sent</code> event.</p>
        member this.SendInvoice ((``params``: PostInvoicesInvoiceSendParams), invoice: string) =
            $"/v1/invoices/{invoice}/send"
            |> this.RestApiClient.PostAsync<_, Invoice> ``params``

        ///<p>Marking an invoice as uncollectible is useful for keeping track of bad debts that can be written off for accounting purposes.</p>
        member this.MarkUncollectible ((``params``: PostInvoicesInvoiceMarkUncollectibleParams), invoice: string) =
            $"/v1/invoices/{invoice}/mark_uncollectible"
            |> this.RestApiClient.PostAsync<_, Invoice> ``params``

        ///<p>Mark a finalized invoice as void. This cannot be undone. Voiding an invoice is similar to <a href="#delete_invoice">deletion</a>, however it only applies to finalized invoices and maintains a papertrail where the invoice can still be found.</p>
        member this.VoidInvoice ((``params``: PostInvoicesInvoiceVoidParams), invoice: string) =
            $"/v1/invoices/{invoice}/void"
            |> this.RestApiClient.PostAsync<_, Invoice> ``params``

    and InvoiceitemService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of your invoice items. Invoice items are returned sorted by creation date, with the most recently created invoice items appearing first.</p>
        member this.List (?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?invoice: string, ?limit: int, ?pending: bool, ?startingAfter: string) =
            $"/v1/invoiceitems"
            |> this.RestApiClient.GetAsync<Invoiceitem>

        ///<p>Creates an item to be added to a draft invoice (up to 250 items per invoice). If no invoice is specified, the item will be on the next invoice created for the customer specified.</p>
        member this.Create ((``params``: PostInvoiceitemsParams)) =
            $"/v1/invoiceitems"
            |> this.RestApiClient.PostAsync<_, Invoiceitem> ``params``

        ///<p>Retrieves the invoice item with the given ID.</p>
        member this.Retrieve (invoiceitem: string, ?expand: string list) =
            $"/v1/invoiceitems/{invoiceitem}"
            |> this.RestApiClient.GetAsync<Invoiceitem>

        ///<p>Updates the amount or description of an invoice item on an upcoming invoice. Updating an invoice item is only possible before the invoice it’s attached to is closed.</p>
        member this.Update ((``params``: PostInvoiceitemsInvoiceitemParams), invoiceitem: string) =
            $"/v1/invoiceitems/{invoiceitem}"
            |> this.RestApiClient.PostAsync<_, Invoiceitem> ``params``

        ///<p>Deletes an invoice item, removing it from an invoice. Deleting invoice items is only possible when they’re not attached to invoices, or if it’s attached to a draft invoice.</p>
        member this.Delete (invoiceitem: string) =
            $"/v1/invoiceitems/{invoiceitem}"
            |> this.RestApiClient.DeleteAsync<DeletedInvoiceitem>

    and IssuerFraudRecordService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of issuer fraud records.</p>
        member this.List (?charge: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/issuer_fraud_records"
            |> this.RestApiClient.GetAsync<IssuerFraudRecord>

        ///<p>Retrieves the details of an issuer fraud record that has previously been created. 
        ///Please refer to the <a href="#issuer_fraud_record_object">issuer fraud record</a> object reference for more details.</p>
        member this.Retrieve (issuerFraudRecord: string, ?expand: string list) =
            $"/v1/issuer_fraud_records/{issuerFraudRecord}"
            |> this.RestApiClient.GetAsync<IssuerFraudRecord>

    and IssuingAuthorizationService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of Issuing <code>Authorization</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?card: string, ?cardholder: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            $"/v1/issuing/authorizations"
            |> this.RestApiClient.GetAsync<IssuingAuthorization>

        ///<p>Retrieves an Issuing <code>Authorization</code> object.</p>
        member this.Retrieve (authorization: string, ?expand: string list) =
            $"/v1/issuing/authorizations/{authorization}"
            |> this.RestApiClient.GetAsync<IssuingAuthorization>

        ///<p>Updates the specified Issuing <code>Authorization</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((``params``: PostIssuingAuthorizationsAuthorizationParams), authorization: string) =
            $"/v1/issuing/authorizations/{authorization}"
            |> this.RestApiClient.PostAsync<_, IssuingAuthorization> ``params``

        ///<p>Approves a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real-time authorization</a> flow.</p>
        member this.Approve ((``params``: PostIssuingAuthorizationsAuthorizationApproveParams), authorization: string) =
            $"/v1/issuing/authorizations/{authorization}/approve"
            |> this.RestApiClient.PostAsync<_, IssuingAuthorization> ``params``

        ///<p>Declines a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real time authorization</a> flow.</p>
        member this.Decline ((``params``: PostIssuingAuthorizationsAuthorizationDeclineParams), authorization: string) =
            $"/v1/issuing/authorizations/{authorization}/decline"
            |> this.RestApiClient.PostAsync<_, IssuingAuthorization> ``params``

    and IssuingCardService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of Issuing <code>Card</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?cardholder: string, ?created: int, ?endingBefore: string, ?expMonth: int, ?expYear: int, ?expand: string list, ?last4: string, ?limit: int, ?startingAfter: string, ?status: string, ?``type``: string) =
            $"/v1/issuing/cards"
            |> this.RestApiClient.GetAsync<IssuingCard>

        ///<p>Creates an Issuing <code>Card</code> object.</p>
        member this.Create ((``params``: PostIssuingCardsParams)) =
            $"/v1/issuing/cards"
            |> this.RestApiClient.PostAsync<_, IssuingCard> ``params``

        ///<p>Retrieves an Issuing <code>Card</code> object.</p>
        member this.Retrieve (card: string, ?expand: string list) =
            $"/v1/issuing/cards/{card}"
            |> this.RestApiClient.GetAsync<IssuingCard>

        ///<p>Updates the specified Issuing <code>Card</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((``params``: PostIssuingCardsCardParams), card: string) =
            $"/v1/issuing/cards/{card}"
            |> this.RestApiClient.PostAsync<_, IssuingCard> ``params``

    and IssuingCardholderService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of Issuing <code>Cardholder</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?created: int, ?email: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?phoneNumber: string, ?startingAfter: string, ?status: string, ?``type``: string) =
            $"/v1/issuing/cardholders"
            |> this.RestApiClient.GetAsync<IssuingCardholder>

        ///<p>Creates a new Issuing <code>Cardholder</code> object that can be issued cards.</p>
        member this.Create ((``params``: PostIssuingCardholdersParams)) =
            $"/v1/issuing/cardholders"
            |> this.RestApiClient.PostAsync<_, IssuingCardholder> ``params``

        ///<p>Retrieves an Issuing <code>Cardholder</code> object.</p>
        member this.Retrieve (cardholder: string, ?expand: string list) =
            $"/v1/issuing/cardholders/{cardholder}"
            |> this.RestApiClient.GetAsync<IssuingCardholder>

        ///<p>Updates the specified Issuing <code>Cardholder</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((``params``: PostIssuingCardholdersCardholderParams), cardholder: string) =
            $"/v1/issuing/cardholders/{cardholder}"
            |> this.RestApiClient.PostAsync<_, IssuingCardholder> ``params``

    and IssuingDisputeService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of Issuing <code>Dispute</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string, ?transaction: string) =
            $"/v1/issuing/disputes"
            |> this.RestApiClient.GetAsync<IssuingDispute>

        ///<p>Creates an Issuing <code>Dispute</code> object. Individual pieces of evidence within the <code>evidence</code> object are optional at this point. Stripe only validates that required evidence is present during submission. Refer to <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a> for more details about evidence requirements.</p>
        member this.Create ((``params``: PostIssuingDisputesParams)) =
            $"/v1/issuing/disputes"
            |> this.RestApiClient.PostAsync<_, IssuingDispute> ``params``

        ///<p>Updates the specified Issuing <code>Dispute</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Properties on the <code>evidence</code> object can be unset by passing in an empty string.</p>
        member this.Update ((``params``: PostIssuingDisputesDisputeParams), dispute: string) =
            $"/v1/issuing/disputes/{dispute}"
            |> this.RestApiClient.PostAsync<_, IssuingDispute> ``params``

        ///<p>Retrieves an Issuing <code>Dispute</code> object.</p>
        member this.Retrieve (dispute: string, ?expand: string list) =
            $"/v1/issuing/disputes/{dispute}"
            |> this.RestApiClient.GetAsync<IssuingDispute>

        ///<p>Submits an Issuing <code>Dispute</code> to the card network. Stripe validates that all evidence fields required for the dispute’s reason are present. For more details, see <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a>.</p>
        member this.Submit ((``params``: PostIssuingDisputesDisputeSubmitParams), dispute: string) =
            $"/v1/issuing/disputes/{dispute}/submit"
            |> this.RestApiClient.PostAsync<_, IssuingDispute> ``params``

    and IssuingTransactionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of Issuing <code>Transaction</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?card: string, ?cardholder: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/issuing/transactions"
            |> this.RestApiClient.GetAsync<IssuingTransaction>

        ///<p>Retrieves an Issuing <code>Transaction</code> object.</p>
        member this.Retrieve (transaction: string, ?expand: string list) =
            $"/v1/issuing/transactions/{transaction}"
            |> this.RestApiClient.GetAsync<IssuingTransaction>

        ///<p>Updates the specified Issuing <code>Transaction</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((``params``: PostIssuingTransactionsTransactionParams), transaction: string) =
            $"/v1/issuing/transactions/{transaction}"
            |> this.RestApiClient.PostAsync<_, IssuingTransaction> ``params``

    and ItemService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>When retrieving a Checkout Session, there is an includable <strong>line_items</strong> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
        member this.ListForCheckout (session: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/checkout/sessions/{session}/line_items"
            |> this.RestApiClient.GetAsync<Item>

    and LineItemService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>When retrieving an invoice, you’ll get a <strong>lines</strong> property containing the total count of line items and the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
        member this.ListForInvoice (invoice: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/invoices/{invoice}/lines"
            |> this.RestApiClient.GetAsync<LineItem>

    and LoginLinkService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Creates a single-use login link for an Express account to access their Stripe dashboard.
        ///<strong>You may only create login links for <a href="/docs/connect/express-accounts">Express accounts</a> connected to your platform</strong>.</p>
        member this.CreateForAccount ((``params``: PostAccountsAccountLoginLinksParams), account: string) =
            $"/v1/accounts/{account}/login_links"
            |> this.RestApiClient.PostAsync<_, LoginLink> ``params``

    and MandateService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves a Mandate object.</p>
        member this.Retrieve (mandate: string, ?expand: string list) =
            $"/v1/mandates/{mandate}"
            |> this.RestApiClient.GetAsync<Mandate>

    and OrderService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Creates a new order object.</p>
        member this.Create ((``params``: PostOrdersParams)) =
            $"/v1/orders"
            |> this.RestApiClient.PostAsync<_, Order> ``params``

        ///<p>Returns a list of your orders. The orders are returned sorted by creation date, with the most recently created orders appearing first.</p>
        member this.List (?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?ids: string list, ?limit: int, ?startingAfter: string, ?status: string, ?statusTransitions: Map<string, string>, ?upstreamIds: string list) =
            $"/v1/orders"
            |> this.RestApiClient.GetAsync<Order>

        ///<p>Retrieves the details of an existing order. Supply the unique order ID from either an order creation request or the order list, and Stripe will return the corresponding order information.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/orders/{id}"
            |> this.RestApiClient.GetAsync<Order>

        ///<p>Updates the specific order by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((``params``: PostOrdersIdParams), id: string) =
            $"/v1/orders/{id}"
            |> this.RestApiClient.PostAsync<_, Order> ``params``

        ///<p>Pay an order by providing a <code>source</code> to create a payment.</p>
        member this.Pay ((``params``: PostOrdersIdPayParams), id: string) =
            $"/v1/orders/{id}/pay"
            |> this.RestApiClient.PostAsync<_, Order> ``params``

        ///<p>Return all or part of an order. The order must have a status of <code>paid</code> or <code>fulfilled</code> before it can be returned. Once all items have been returned, the order will become <code>canceled</code> or <code>returned</code> depending on which status the order started in.</p>
        member this.ReturnOrder ((``params``: PostOrdersIdReturnsParams), id: string) =
            $"/v1/orders/{id}/returns"
            |> this.RestApiClient.PostAsync<_, OrderReturn> ``params``

    and OrderReturnService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of your order returns. The returns are returned sorted by creation date, with the most recently created return appearing first.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?order: string, ?startingAfter: string) =
            $"/v1/order_returns"
            |> this.RestApiClient.GetAsync<OrderReturn>

        ///<p>Retrieves the details of an existing order return. Supply the unique order ID from either an order return creation request or the order return list, and Stripe will return the corresponding order information.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/order_returns/{id}"
            |> this.RestApiClient.GetAsync<OrderReturn>

    and PaymentIntentService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Creates a PaymentIntent object.
        ///After the PaymentIntent is created, attach a payment method and <a href="/docs/api/payment_intents/confirm">confirm</a>
        ///to continue the payment. You can read more about the different payment flows
        ///available via the Payment Intents API <a href="/docs/payments/payment-intents">here</a>.
        ///When <code>confirm=true</code> is used during creation, it is equivalent to creating
        ///and confirming the PaymentIntent in the same call. You may use any parameters
        ///available in the <a href="/docs/api/payment_intents/confirm">confirm API</a> when <code>confirm=true</code>
        ///is supplied.</p>
        member this.Create ((``params``: PostPaymentIntentsParams)) =
            $"/v1/payment_intents"
            |> this.RestApiClient.PostAsync<_, PaymentIntent> ``params``

        ///<p>Returns a list of PaymentIntents.</p>
        member this.List (?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/payment_intents"
            |> this.RestApiClient.GetAsync<PaymentIntent>

        ///<p>Retrieves the details of a PaymentIntent that has previously been created. 
        ///Client-side retrieval using a publishable key is allowed when the <code>client_secret</code> is provided in the query string. 
        ///When retrieved with a publishable key, only a subset of properties will be returned. Please refer to the <a href="#payment_intent_object">payment intent</a> object reference for more details.</p>
        member this.Retrieve (intent: string, ?expand: string list, ?clientSecret: string) =
            $"/v1/payment_intents/{intent}"
            |> this.RestApiClient.GetAsync<PaymentIntent>

        ///<p>Updates properties on a PaymentIntent object without confirming.
        ///Depending on which properties you update, you may need to confirm the
        ///PaymentIntent again. For example, updating the <code>payment_method</code> will
        ///always require you to confirm the PaymentIntent again. If you prefer to
        ///update and confirm at the same time, we recommend updating properties via
        ///the <a href="/docs/api/payment_intents/confirm">confirm API</a> instead.</p>
        member this.Update ((``params``: PostPaymentIntentsIntentParams), intent: string) =
            $"/v1/payment_intents/{intent}"
            |> this.RestApiClient.PostAsync<_, PaymentIntent> ``params``

        ///<p>Confirm that your customer intends to pay with current or provided
        ///payment method. Upon confirmation, the PaymentIntent will attempt to initiate
        ///a payment.
        ///If the selected payment method requires additional authentication steps, the
        ///PaymentIntent will transition to the <code>requires_action</code> status and
        ///suggest additional actions via <code>next_action</code>. If payment fails,
        ///the PaymentIntent will transition to the <code>requires_payment_method</code> status. If
        ///payment succeeds, the PaymentIntent will transition to the <code>succeeded</code>
        ///status (or <code>requires_capture</code>, if <code>capture_method</code> is set to <code>manual</code>).
        ///If the <code>confirmation_method</code> is <code>automatic</code>, payment may be attempted
        ///using our <a href="/docs/stripe-js/reference#stripe-handle-card-payment">client SDKs</a>
        ///and the PaymentIntent’s <a href="#payment_intent_object-client_secret">client_secret</a>.
        ///After <code>next_action</code>s are handled by the client, no additional
        ///confirmation is required to complete the payment.
        ///If the <code>confirmation_method</code> is <code>manual</code>, all payment attempts must be
        ///initiated using a secret key.
        ///If any actions are required for the payment, the PaymentIntent will
        ///return to the <code>requires_confirmation</code> state
        ///after those actions are completed. Your server needs to then
        ///explicitly re-confirm the PaymentIntent to initiate the next payment
        ///attempt. Read the <a href="/docs/payments/payment-intents/web-manual">expanded documentation</a>
        ///to learn more about manual confirmation.</p>
        member this.Confirm ((``params``: PostPaymentIntentsIntentConfirmParams), intent: string) =
            $"/v1/payment_intents/{intent}/confirm"
            |> this.RestApiClient.PostAsync<_, PaymentIntent> ``params``

        ///<p>A PaymentIntent object can be canceled when it is in one of these statuses: <code>requires_payment_method</code>, <code>requires_capture</code>, <code>requires_confirmation</code>, or <code>requires_action</code>. 
        ///Once canceled, no additional charges will be made by the PaymentIntent and any operations on the PaymentIntent will fail with an error. For PaymentIntents with <code>status=’requires_capture’</code>, the remaining <code>amount_capturable</code> will automatically be refunded.</p>
        member this.Cancel ((``params``: PostPaymentIntentsIntentCancelParams), intent: string) =
            $"/v1/payment_intents/{intent}/cancel"
            |> this.RestApiClient.PostAsync<_, PaymentIntent> ``params``

        ///<p>Capture the funds of an existing uncaptured PaymentIntent when its status is <code>requires_capture</code>.
        ///Uncaptured PaymentIntents will be canceled exactly seven days after they are created.
        ///Learn more about <a href="/docs/payments/capture-later">separate authorization and capture</a>.</p>
        member this.Capture ((``params``: PostPaymentIntentsIntentCaptureParams), intent: string) =
            $"/v1/payment_intents/{intent}/capture"
            |> this.RestApiClient.PostAsync<_, PaymentIntent> ``params``

    and PaymentMethodService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Creates a PaymentMethod object. Read the <a href="/docs/stripe-js/reference#stripe-create-payment-method">Stripe.js reference</a> to learn how to create PaymentMethods via Stripe.js.</p>
        member this.Create ((``params``: PostPaymentMethodsParams)) =
            $"/v1/payment_methods"
            |> this.RestApiClient.PostAsync<_, PaymentMethod> ``params``

        ///<p>Retrieves a PaymentMethod object.</p>
        member this.Retrieve (paymentMethod: string, ?expand: string list) =
            $"/v1/payment_methods/{paymentMethod}"
            |> this.RestApiClient.GetAsync<PaymentMethod>

        ///<p>Updates a PaymentMethod object. A PaymentMethod must be attached a customer to be updated.</p>
        member this.Update ((``params``: PostPaymentMethodsPaymentMethodParams), paymentMethod: string) =
            $"/v1/payment_methods/{paymentMethod}"
            |> this.RestApiClient.PostAsync<_, PaymentMethod> ``params``

        ///<p>Returns a list of PaymentMethods for a given Customer</p>
        member this.List (customer: string, ``type``: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/payment_methods"
            |> this.RestApiClient.GetAsync<PaymentMethod>

        ///<p>Attaches a PaymentMethod object to a Customer.
        ///To attach a new PaymentMethod to a customer for future payments, we recommend you use a <a href="/docs/api/setup_intents">SetupIntent</a>
        ///or a PaymentIntent with <a href="/docs/api/payment_intents/create#create_payment_intent-setup_future_usage">setup_future_usage</a>.
        ///These approaches will perform any necessary steps to ensure that the PaymentMethod can be used in a future payment. Using the
        ///<code>/v1/payment_methods/:id/attach</code> endpoint does not ensure that future payments can be made with the attached PaymentMethod.
        ///See <a href="/docs/payments/payment-intents#future-usage">Optimizing cards for future payments</a> for more information about setting up future payments.
        ///To use this PaymentMethod as the default for invoice or subscription payments,
        ///set <a href="/docs/api/customers/update#update_customer-invoice_settings-default_payment_method"><code>invoice_settings.default_payment_method</code></a>,
        ///on the Customer to the PaymentMethod’s ID.</p>
        member this.Attach ((``params``: PostPaymentMethodsPaymentMethodAttachParams), paymentMethod: string) =
            $"/v1/payment_methods/{paymentMethod}/attach"
            |> this.RestApiClient.PostAsync<_, PaymentMethod> ``params``

        ///<p>Detaches a PaymentMethod object from a Customer.</p>
        member this.Detach ((``params``: PostPaymentMethodsPaymentMethodDetachParams), paymentMethod: string) =
            $"/v1/payment_methods/{paymentMethod}/detach"
            |> this.RestApiClient.PostAsync<_, PaymentMethod> ``params``

    and PaymentSourceService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>List sources for a specified customer.</p>
        member this.ListForCustomer (customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?object: string, ?startingAfter: string) =
            $"/v1/customers/{customer}/sources"
            |> this.RestApiClient.GetAsync<PaymentSource>

        ///<p>Retrieve a specified source for a given customer.</p>
        member this.RetrieveForCustomer (customer: string, id: string, ?expand: string list) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.GetAsync<PaymentSource>

        ///<p>When you create a new credit card, you must specify a customer or recipient on which to create it.
        ///If the card’s owner has no default card, then the new card will become the default.
        ///However, if the owner already has a default, then it will not change.
        ///To change the default, you should <a href="/docs/api#update_customer">update the customer</a> to have a new <code>default_source</code>.</p>
        member this.CreateForCustomer ((``params``: PostCustomersCustomerSourcesParams), customer: string) =
            $"/v1/customers/{customer}/sources"
            |> this.RestApiClient.PostAsync<_, PaymentSource> ``params``

    and PayoutService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves the details of an existing payout. Supply the unique payout ID from either a payout creation request or the payout list, and Stripe will return the corresponding payout information.</p>
        member this.Retrieve (payout: string, ?expand: string list) =
            $"/v1/payouts/{payout}"
            |> this.RestApiClient.GetAsync<Payout>

        ///<p>Returns a list of existing payouts sent to third-party bank accounts or that Stripe has sent you. The payouts are returned in sorted order, with the most recently created payouts appearing first.</p>
        member this.List (?arrivalDate: int, ?created: int, ?destination: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            $"/v1/payouts"
            |> this.RestApiClient.GetAsync<Payout>

        ///<p>To send funds to your own bank account, you create a new payout object. Your <a href="#balance">Stripe balance</a> must be able to cover the payout amount, or you’ll receive an “Insufficient Funds” error.
        ///If your API key is in test mode, money won’t actually be sent, though everything else will occur as if in live mode.
        ///If you are creating a manual payout on a Stripe account that uses multiple payment source types, you’ll need to specify the source type balance that the payout should draw from. The <a href="#balance_object">balance object</a> details available and pending amounts by source type.</p>
        member this.Create ((``params``: PostPayoutsParams)) =
            $"/v1/payouts"
            |> this.RestApiClient.PostAsync<_, Payout> ``params``

        ///<p>Updates the specified payout by setting the values of the parameters passed. Any parameters not provided will be left unchanged. This request accepts only the metadata as arguments.</p>
        member this.Update ((``params``: PostPayoutsPayoutParams), payout: string) =
            $"/v1/payouts/{payout}"
            |> this.RestApiClient.PostAsync<_, Payout> ``params``

        ///<p>A previously created payout can be canceled if it has not yet been paid out. Funds will be refunded to your available balance. You may not cancel automatic Stripe payouts.</p>
        member this.Cancel ((``params``: PostPayoutsPayoutCancelParams), payout: string) =
            $"/v1/payouts/{payout}/cancel"
            |> this.RestApiClient.PostAsync<_, Payout> ``params``

        ///<p>Reverses a payout by debiting the destination bank account. Only payouts for connected accounts to US bank accounts may be reversed at this time. If the payout is in the <code>pending</code> status, <code>/v1/payouts/:id/cancel</code> should be used instead.
        ///By requesting a reversal via <code>/v1/payouts/:id/reverse</code>, you confirm that the authorized signatory of the selected bank account has authorized the debit on the bank account and that no other authorization is required.</p>
        member this.Reverse ((``params``: PostPayoutsPayoutReverseParams), payout: string) =
            $"/v1/payouts/{payout}/reverse"
            |> this.RestApiClient.PostAsync<_, Payout> ``params``

    and PersonService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of people associated with the account’s legal entity. The people are returned sorted by creation date, with the most recent people appearing first.</p>
        member this.ListForAccount (account: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?relationship: Map<string, string>, ?startingAfter: string) =
            $"/v1/accounts/{account}/persons"
            |> this.RestApiClient.GetAsync<Person>

        ///<p>Retrieves an existing person.</p>
        member this.RetrieveForAccount (account: string, person: string, ?expand: string list) =
            $"/v1/accounts/{account}/persons/{person}"
            |> this.RestApiClient.GetAsync<Person>

        ///<p>Creates a new person.</p>
        member this.CreateForAccount ((``params``: PostAccountsAccountPersonsParams), account: string) =
            $"/v1/accounts/{account}/persons"
            |> this.RestApiClient.PostAsync<_, Person> ``params``

        ///<p>Updates an existing person.</p>
        member this.UpdateForAccount ((``params``: PostAccountsAccountPersonsPersonParams), account: string, person: string) =
            $"/v1/accounts/{account}/persons/{person}"
            |> this.RestApiClient.PostAsync<_, Person> ``params``

        ///<p>Deletes an existing person’s relationship to the account’s legal entity. Any person with a relationship for an account can be deleted through the API, except if the person is the <code>account_opener</code>. If your integration is using the <code>executive</code> parameter, you cannot delete the only verified <code>executive</code> on file.</p>
        member this.DeleteForAccount (account: string, person: string) =
            $"/v1/accounts/{account}/persons/{person}"
            |> this.RestApiClient.DeleteAsync<DeletedPerson>

    and PlanService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of your plans.</p>
        member this.List (?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?product: string, ?startingAfter: string) =
            $"/v1/plans"
            |> this.RestApiClient.GetAsync<Plan>

        ///<p>You can now model subscriptions more flexibly using the <a href="#prices">Prices API</a>. It replaces the Plans API and is backwards compatible to simplify your migration.</p>
        member this.Create ((``params``: PostPlansParams)) =
            $"/v1/plans"
            |> this.RestApiClient.PostAsync<_, Plan> ``params``

        ///<p>Retrieves the plan with the given ID.</p>
        member this.Retrieve (plan: string, ?expand: string list) =
            $"/v1/plans/{plan}"
            |> this.RestApiClient.GetAsync<Plan>

        ///<p>Updates the specified plan by setting the values of the parameters passed. Any parameters not provided are left unchanged. By design, you cannot change a plan’s ID, amount, currency, or billing cycle.</p>
        member this.Update ((``params``: PostPlansPlanParams), plan: string) =
            $"/v1/plans/{plan}"
            |> this.RestApiClient.PostAsync<_, Plan> ``params``

        ///<p>Deleting plans means new subscribers can’t be added. Existing subscribers aren’t affected.</p>
        member this.Delete (plan: string) =
            $"/v1/plans/{plan}"
            |> this.RestApiClient.DeleteAsync<DeletedPlan>

    and PriceService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of your prices.</p>
        member this.List (?active: bool, ?created: int, ?currency: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?lookupKeys: string list, ?product: string, ?recurring: Map<string, string>, ?startingAfter: string, ?``type``: string) =
            $"/v1/prices"
            |> this.RestApiClient.GetAsync<Price>

        ///<p>Creates a new price for an existing product. The price can be recurring or one-time.</p>
        member this.Create ((``params``: PostPricesParams)) =
            $"/v1/prices"
            |> this.RestApiClient.PostAsync<_, Price> ``params``

        ///<p>Retrieves the price with the given ID.</p>
        member this.Retrieve (price: string, ?expand: string list) =
            $"/v1/prices/{price}"
            |> this.RestApiClient.GetAsync<Price>

        ///<p>Updates the specified price by setting the values of the parameters passed. Any parameters not provided are left unchanged.</p>
        member this.Update ((``params``: PostPricesPriceParams), price: string) =
            $"/v1/prices/{price}"
            |> this.RestApiClient.PostAsync<_, Price> ``params``

    and ProductService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Creates a new product object.</p>
        member this.Create ((``params``: PostProductsParams)) =
            $"/v1/products"
            |> this.RestApiClient.PostAsync<_, Product> ``params``

        ///<p>Retrieves the details of an existing product. Supply the unique product ID from either a product creation request or the product list, and Stripe will return the corresponding product information.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/products/{id}"
            |> this.RestApiClient.GetAsync<Product>

        ///<p>Updates the specific product by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((``params``: PostProductsIdParams), id: string) =
            $"/v1/products/{id}"
            |> this.RestApiClient.PostAsync<_, Product> ``params``

        ///<p>Returns a list of your products. The products are returned sorted by creation date, with the most recently created products appearing first.</p>
        member this.List (?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?ids: string list, ?limit: int, ?shippable: bool, ?startingAfter: string, ?``type``: string, ?url: string) =
            $"/v1/products"
            |> this.RestApiClient.GetAsync<Product>

        ///<p>Delete a product. Deleting a product is only possible if it has no prices associated with it. Additionally, deleting a product with <code>type=good</code> is only possible if it has no SKUs associated with it.</p>
        member this.Delete (id: string) =
            $"/v1/products/{id}"
            |> this.RestApiClient.DeleteAsync<DeletedProduct>

    and PromotionCodeService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves the promotion code with the given ID.</p>
        member this.Retrieve (promotionCode: string, ?expand: string list) =
            $"/v1/promotion_codes/{promotionCode}"
            |> this.RestApiClient.GetAsync<PromotionCode>

        ///<p>A promotion code points to a coupon. You can optionally restrict the code to a specific customer, redemption limit, and expiration date.</p>
        member this.Create ((``params``: PostPromotionCodesParams)) =
            $"/v1/promotion_codes"
            |> this.RestApiClient.PostAsync<_, PromotionCode> ``params``

        ///<p>Updates the specified promotion code by setting the values of the parameters passed. Most fields are, by design, not editable.</p>
        member this.Update ((``params``: PostPromotionCodesPromotionCodeParams), promotionCode: string) =
            $"/v1/promotion_codes/{promotionCode}"
            |> this.RestApiClient.PostAsync<_, PromotionCode> ``params``

        ///<p>Returns a list of your promotion codes.</p>
        member this.List (?active: bool, ?code: string, ?coupon: string, ?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/promotion_codes"
            |> this.RestApiClient.GetAsync<PromotionCode>

    and RadarEarlyFraudWarningService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of early fraud warnings.</p>
        member this.List (?charge: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/radar/early_fraud_warnings"
            |> this.RestApiClient.GetAsync<RadarEarlyFraudWarning>

        ///<p>Retrieves the details of an early fraud warning that has previously been created. 
        ///Please refer to the <a href="#early_fraud_warning_object">early fraud warning</a> object reference for more details.</p>
        member this.Retrieve (earlyFraudWarning: string, ?expand: string list) =
            $"/v1/radar/early_fraud_warnings/{earlyFraudWarning}"
            |> this.RestApiClient.GetAsync<RadarEarlyFraudWarning>

    and RadarValueListService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of <code>ValueList</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?alias: string, ?contains: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/radar/value_lists"
            |> this.RestApiClient.GetAsync<RadarValueList>

        ///<p>Retrieves a <code>ValueList</code> object.</p>
        member this.Retrieve (valueList: string, ?expand: string list) =
            $"/v1/radar/value_lists/{valueList}"
            |> this.RestApiClient.GetAsync<RadarValueList>

        ///<p>Creates a new <code>ValueList</code> object, which can then be referenced in rules.</p>
        member this.Create ((``params``: PostRadarValueListsParams)) =
            $"/v1/radar/value_lists"
            |> this.RestApiClient.PostAsync<_, RadarValueList> ``params``

        ///<p>Updates a <code>ValueList</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Note that <code>item_type</code> is immutable.</p>
        member this.Update ((``params``: PostRadarValueListsValueListParams), valueList: string) =
            $"/v1/radar/value_lists/{valueList}"
            |> this.RestApiClient.PostAsync<_, RadarValueList> ``params``

        ///<p>Deletes a <code>ValueList</code> object, also deleting any items contained within the value list. To be deleted, a value list must not be referenced in any rules.</p>
        member this.Delete (valueList: string) =
            $"/v1/radar/value_lists/{valueList}"
            |> this.RestApiClient.DeleteAsync<DeletedRadarValueList>

    and RadarValueListItemService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of <code>ValueListItem</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (valueList: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?value: string) =
            $"/v1/radar/value_list_items"
            |> this.RestApiClient.GetAsync<RadarValueListItem>

        ///<p>Retrieves a <code>ValueListItem</code> object.</p>
        member this.Retrieve (item: string, ?expand: string list) =
            $"/v1/radar/value_list_items/{item}"
            |> this.RestApiClient.GetAsync<RadarValueListItem>

        ///<p>Creates a new <code>ValueListItem</code> object, which is added to the specified parent value list.</p>
        member this.Create ((``params``: PostRadarValueListItemsParams)) =
            $"/v1/radar/value_list_items"
            |> this.RestApiClient.PostAsync<_, RadarValueListItem> ``params``

        ///<p>Deletes a <code>ValueListItem</code> object, removing it from its parent value list.</p>
        member this.Delete (item: string) =
            $"/v1/radar/value_list_items/{item}"
            |> this.RestApiClient.DeleteAsync<DeletedRadarValueListItem>

    and RecipientService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of your recipients. The recipients are returned sorted by creation date, with the most recently created recipients appearing first.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?``type``: string, ?verified: bool) =
            $"/v1/recipients"
            |> this.RestApiClient.GetAsync<Recipient>

        ///<p>Creates a new <code>Recipient</code> object and verifies the recipient’s identity.
        ///Also verifies the recipient’s bank account information or debit card, if either is provided.</p>
        member this.Create ((``params``: PostRecipientsParams)) =
            $"/v1/recipients"
            |> this.RestApiClient.PostAsync<_, Recipient> ``params``

        ///<p>Retrieves the details of an existing recipient. You need only supply the unique recipient identifier that was returned upon recipient creation.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/recipients/{id}"
            |> this.RestApiClient.GetAsync<Recipient>

        ///<p>Updates the specified recipient by setting the values of the parameters passed.
        ///Any parameters not provided will be left unchanged.
        ///If you update the name or tax ID, the identity verification will automatically be rerun.
        ///If you update the bank account, the bank account validation will automatically be rerun.</p>
        member this.Update ((``params``: PostRecipientsIdParams), id: string) =
            $"/v1/recipients/{id}"
            |> this.RestApiClient.PostAsync<_, Recipient> ``params``

        ///<p>Permanently deletes a recipient. It cannot be undone.</p>
        member this.Delete (id: string) =
            $"/v1/recipients/{id}"
            |> this.RestApiClient.DeleteAsync<DeletedRecipient>

    and RefundService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of all refunds you’ve previously created. The refunds are returned in sorted order, with the most recent refunds appearing first. For convenience, the 10 most recent refunds are always available by default on the charge object.</p>
        member this.List (?charge: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string) =
            $"/v1/refunds"
            |> this.RestApiClient.GetAsync<Refund>

        ///<p>Create a refund.</p>
        member this.Create ((``params``: PostRefundsParams)) =
            $"/v1/refunds"
            |> this.RestApiClient.PostAsync<_, Refund> ``params``

        ///<p>Retrieves the details of an existing refund.</p>
        member this.Retrieve (refund: string, ?expand: string list) =
            $"/v1/refunds/{refund}"
            |> this.RestApiClient.GetAsync<Refund>

        ///<p>Updates the specified refund by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request only accepts <code>metadata</code> as an argument.</p>
        member this.Update ((``params``: PostRefundsRefundParams), refund: string) =
            $"/v1/refunds/{refund}"
            |> this.RestApiClient.PostAsync<_, Refund> ``params``

    and ReportingReportRunService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves the details of an existing Report Run. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        member this.Retrieve (reportRun: string, ?expand: string list) =
            $"/v1/reporting/report_runs/{reportRun}"
            |> this.RestApiClient.GetAsync<ReportingReportRun>

        ///<p>Creates a new object and begin running the report. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        member this.Create ((``params``: PostReportingReportRunsParams)) =
            $"/v1/reporting/report_runs"
            |> this.RestApiClient.PostAsync<_, ReportingReportRun> ``params``

        ///<p>Returns a list of Report Runs, with the most recent appearing first. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/reporting/report_runs"
            |> this.RestApiClient.GetAsync<ReportingReportRun>

    and ReportingReportTypeService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves the details of a Report Type. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        member this.Retrieve (reportType: string, ?expand: string list) =
            $"/v1/reporting/report_types/{reportType}"
            |> this.RestApiClient.GetAsync<ReportingReportType>

        ///<p>Returns a full list of Report Types. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        member this.List (?expand: string list) =
            $"/v1/reporting/report_types"
            |> this.RestApiClient.GetAsync<ReportingReportType>

    and ReviewService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of <code>Review</code> objects that have <code>open</code> set to <code>true</code>. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/reviews"
            |> this.RestApiClient.GetAsync<Review>

        ///<p>Retrieves a <code>Review</code> object.</p>
        member this.Retrieve (review: string, ?expand: string list) =
            $"/v1/reviews/{review}"
            |> this.RestApiClient.GetAsync<Review>

        ///<p>Approves a <code>Review</code> object, closing it and removing it from the list of reviews.</p>
        member this.Approve ((``params``: PostReviewsReviewApproveParams), review: string) =
            $"/v1/reviews/{review}/approve"
            |> this.RestApiClient.PostAsync<_, Review> ``params``

    and ScheduledQueryRunService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of scheduled query runs.</p>
        member this.ListForSigma (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/sigma/scheduled_query_runs"
            |> this.RestApiClient.GetAsync<ScheduledQueryRun>

        ///<p>Retrieves the details of an scheduled query run.</p>
        member this.RetrieveForSigma (scheduledQueryRun: string, ?expand: string list) =
            $"/v1/sigma/scheduled_query_runs/{scheduledQueryRun}"
            |> this.RestApiClient.GetAsync<ScheduledQueryRun>

    and SetupAttemptService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of SetupAttempts associated with a provided SetupIntent.</p>
        member this.List (setupIntent: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/setup_attempts"
            |> this.RestApiClient.GetAsync<SetupAttempt>

    and SetupIntentService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Creates a SetupIntent object.
        ///After the SetupIntent is created, attach a payment method and <a href="/docs/api/setup_intents/confirm">confirm</a>
        ///to collect any required permissions to charge the payment method later.</p>
        member this.Create ((``params``: PostSetupIntentsParams)) =
            $"/v1/setup_intents"
            |> this.RestApiClient.PostAsync<_, SetupIntent> ``params``

        ///<p>Returns a list of SetupIntents.</p>
        member this.List (?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentMethod: string, ?startingAfter: string) =
            $"/v1/setup_intents"
            |> this.RestApiClient.GetAsync<SetupIntent>

        ///<p>Retrieves the details of a SetupIntent that has previously been created. 
        ///Client-side retrieval using a publishable key is allowed when the <code>client_secret</code> is provided in the query string. 
        ///When retrieved with a publishable key, only a subset of properties will be returned. Please refer to the <a href="#setup_intent_object">SetupIntent</a> object reference for more details.</p>
        member this.Retrieve (intent: string, ?expand: string list, ?clientSecret: string) =
            $"/v1/setup_intents/{intent}"
            |> this.RestApiClient.GetAsync<SetupIntent>

        ///<p>Updates a SetupIntent object.</p>
        member this.Update ((``params``: PostSetupIntentsIntentParams), intent: string) =
            $"/v1/setup_intents/{intent}"
            |> this.RestApiClient.PostAsync<_, SetupIntent> ``params``

        ///<p>Confirm that your customer intends to set up the current or
        ///provided payment method. For example, you would confirm a SetupIntent
        ///when a customer hits the “Save” button on a payment method management
        ///page on your website.
        ///If the selected payment method does not require any additional
        ///steps from the customer, the SetupIntent will transition to the
        ///<code>succeeded</code> status.
        ///Otherwise, it will transition to the <code>requires_action</code> status and
        ///suggest additional actions via <code>next_action</code>. If setup fails,
        ///the SetupIntent will transition to the
        ///<code>requires_payment_method</code> status.</p>
        member this.Confirm ((``params``: PostSetupIntentsIntentConfirmParams), intent: string) =
            $"/v1/setup_intents/{intent}/confirm"
            |> this.RestApiClient.PostAsync<_, SetupIntent> ``params``

        ///<p>A SetupIntent object can be canceled when it is in one of these statuses: <code>requires_payment_method</code>, <code>requires_confirmation</code>, or <code>requires_action</code>. 
        ///Once canceled, setup is abandoned and any operations on the SetupIntent will fail with an error.</p>
        member this.Cancel ((``params``: PostSetupIntentsIntentCancelParams), intent: string) =
            $"/v1/setup_intents/{intent}/cancel"
            |> this.RestApiClient.PostAsync<_, SetupIntent> ``params``

    and SkuService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves the details of an existing SKU. Supply the unique SKU identifier from either a SKU creation request or from the product, and Stripe will return the corresponding SKU information.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/skus/{id}"
            |> this.RestApiClient.GetAsync<Sku>

        ///<p>Returns a list of your SKUs. The SKUs are returned sorted by creation date, with the most recently created SKUs appearing first.</p>
        member this.List (?active: bool, ?attributes: Map<string, string>, ?endingBefore: string, ?expand: string list, ?ids: string list, ?inStock: bool, ?limit: int, ?product: string, ?startingAfter: string) =
            $"/v1/skus"
            |> this.RestApiClient.GetAsync<Sku>

        ///<p>Updates the specific SKU by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///Note that a SKU’s <code>attributes</code> are not editable. Instead, you would need to deactivate the existing SKU and create a new one with the new attribute values.</p>
        member this.Update ((``params``: PostSkusIdParams), id: string) =
            $"/v1/skus/{id}"
            |> this.RestApiClient.PostAsync<_, Sku> ``params``

        ///<p>Creates a new SKU associated with a product.</p>
        member this.Create ((``params``: PostSkusParams)) =
            $"/v1/skus"
            |> this.RestApiClient.PostAsync<_, Sku> ``params``

        ///<p>Delete a SKU. Deleting a SKU is only possible until it has been used in an order.</p>
        member this.Delete (id: string) =
            $"/v1/skus/{id}"
            |> this.RestApiClient.DeleteAsync<DeletedSku>

    and SourceService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Delete a specified source for a given customer.</p>
        member this.DetachForCustomer ((``params``: DeleteCustomersCustomerSourcesIdParams), customer: string, id: string) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.DeleteAsync<PaymentSource>

        ///<p>Retrieves an existing source object. Supply the unique source ID from a source creation request and Stripe will return the corresponding up-to-date source object information.</p>
        member this.Retrieve (source: string, ?expand: string list, ?clientSecret: string) =
            $"/v1/sources/{source}"
            |> this.RestApiClient.GetAsync<Source>

        ///<p>Creates a new source object.</p>
        member this.Create ((``params``: PostSourcesParams)) =
            $"/v1/sources"
            |> this.RestApiClient.PostAsync<_, Source> ``params``

        ///<p>Updates the specified source by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request accepts the <code>metadata</code> and <code>owner</code> as arguments. It is also possible to update type specific information for selected payment methods. Please refer to our <a href="/docs/sources">payment method guides</a> for more detail.</p>
        member this.Update ((``params``: PostSourcesSourceParams), source: string) =
            $"/v1/sources/{source}"
            |> this.RestApiClient.PostAsync<_, Source> ``params``

        ///<p>Verify a given source.</p>
        member this.Verify ((``params``: PostSourcesSourceVerifyParams), source: string) =
            $"/v1/sources/{source}/verify"
            |> this.RestApiClient.PostAsync<_, Source> ``params``

        ///<p>List source transactions for a given source.</p>
        member this.SourceTransactions (source: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/sources/{source}/source_transactions"
            |> this.RestApiClient.GetAsync<SourceTransaction>

    and SubscriptionService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>By default, returns a list of subscriptions that have not been canceled. In order to list canceled subscriptions, specify <code>status=canceled</code>.</p>
        member this.List (?collectionMethod: string, ?created: int, ?currentPeriodEnd: int, ?currentPeriodStart: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?plan: string, ?price: string, ?startingAfter: string, ?status: string) =
            $"/v1/subscriptions"
            |> this.RestApiClient.GetAsync<Subscription>

        ///<p>Creates a new subscription on an existing customer. Each customer can have up to 500 active or scheduled subscriptions.</p>
        member this.Create ((``params``: PostSubscriptionsParams)) =
            $"/v1/subscriptions"
            |> this.RestApiClient.PostAsync<_, Subscription> ``params``

        ///<p>Updates an existing subscription on a customer to match the specified parameters. When changing plans or quantities, we will optionally prorate the price we charge next month to make up for any price changes. To preview how the proration will be calculated, use the <a href="#upcoming_invoice">upcoming invoice</a> endpoint.</p>
        member this.Update ((``params``: PostSubscriptionsSubscriptionExposedIdParams), subscriptionExposedId: string) =
            $"/v1/subscriptions/{subscriptionExposedId}"
            |> this.RestApiClient.PostAsync<_, Subscription> ``params``

        ///<p>Retrieves the subscription with the given ID.</p>
        member this.Retrieve (subscriptionExposedId: string, ?expand: string list) =
            $"/v1/subscriptions/{subscriptionExposedId}"
            |> this.RestApiClient.GetAsync<Subscription>

        ///<p>Cancels a customer’s subscription immediately. The customer will not be charged again for the subscription.
        ///Note, however, that any pending invoice items that you’ve created will still be charged for at the end of the period, unless manually <a href="#delete_invoiceitem">deleted</a>. If you’ve set the subscription to cancel at the end of the period, any pending prorations will also be left in place and collected at the end of the period. But if the subscription is set to cancel immediately, pending prorations will be removed.
        ///By default, upon subscription cancellation, Stripe will stop automatic collection of all finalized invoices for the customer. This is intended to prevent unexpected payment attempts after the customer has canceled a subscription. However, you can resume automatic collection of the invoices manually after subscription cancellation to have us proceed. Or, you could check for unpaid invoices before allowing the customer to cancel the subscription at all.</p>
        member this.Cancel ((``params``: DeleteSubscriptionsSubscriptionExposedIdParams), subscriptionExposedId: string) =
            $"/v1/subscriptions/{subscriptionExposedId}"
            |> this.RestApiClient.DeleteAsync<Subscription>

        ///<p>Removes the currently applied discount on a subscription.</p>
        member this.DeleteDiscount (subscriptionExposedId: string) =
            $"/v1/subscriptions/{subscriptionExposedId}/discount"
            |> this.RestApiClient.DeleteAsync<DeletedDiscount>

    and SubscriptionItemService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of your subscription items for a given subscription.</p>
        member this.List (subscription: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/subscription_items"
            |> this.RestApiClient.GetAsync<SubscriptionItem>

        ///<p>Retrieves the subscription item with the given ID.</p>
        member this.Retrieve (item: string, ?expand: string list) =
            $"/v1/subscription_items/{item}"
            |> this.RestApiClient.GetAsync<SubscriptionItem>

        ///<p>Adds a new item to an existing subscription. No existing items will be changed or replaced.</p>
        member this.Create ((``params``: PostSubscriptionItemsParams)) =
            $"/v1/subscription_items"
            |> this.RestApiClient.PostAsync<_, SubscriptionItem> ``params``

        ///<p>Updates the plan or quantity of an item on a current subscription.</p>
        member this.Update ((``params``: PostSubscriptionItemsItemParams), item: string) =
            $"/v1/subscription_items/{item}"
            |> this.RestApiClient.PostAsync<_, SubscriptionItem> ``params``

        ///<p>Deletes an item from the subscription. Removing a subscription item from a subscription will not cancel the subscription.</p>
        member this.Delete ((``params``: DeleteSubscriptionItemsItemParams), item: string) =
            $"/v1/subscription_items/{item}"
            |> this.RestApiClient.DeleteAsync<DeletedSubscriptionItem>

        ///<p>For the specified subscription item, returns a list of summary objects. Each object in the list provides usage information that’s been summarized from multiple usage records and over a subscription billing period (e.g., 15 usage records in the month of September).
        ///The list is sorted in reverse-chronological order (newest first). The first list item represents the most current usage period that hasn’t ended yet. Since new usage records can still be added, the returned summary information for the subscription item’s ID should be seen as unstable until the subscription billing period ends.</p>
        member this.UsageRecordSummaries (subscriptionItem: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/subscription_items/{subscriptionItem}/usage_record_summaries"
            |> this.RestApiClient.GetAsync<UsageRecordSummary>

    and SubscriptionScheduleService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves the list of your subscription schedules.</p>
        member this.List (?canceledAt: int, ?completedAt: int, ?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?releasedAt: int, ?scheduled: bool, ?startingAfter: string) =
            $"/v1/subscription_schedules"
            |> this.RestApiClient.GetAsync<SubscriptionSchedule>

        ///<p>Creates a new subscription schedule object. Each customer can have up to 500 active or scheduled subscriptions.</p>
        member this.Create ((``params``: PostSubscriptionSchedulesParams)) =
            $"/v1/subscription_schedules"
            |> this.RestApiClient.PostAsync<_, SubscriptionSchedule> ``params``

        ///<p>Retrieves the details of an existing subscription schedule. You only need to supply the unique subscription schedule identifier that was returned upon subscription schedule creation.</p>
        member this.Retrieve (schedule: string, ?expand: string list) =
            $"/v1/subscription_schedules/{schedule}"
            |> this.RestApiClient.GetAsync<SubscriptionSchedule>

        ///<p>Updates an existing subscription schedule.</p>
        member this.Update ((``params``: PostSubscriptionSchedulesScheduleParams), schedule: string) =
            $"/v1/subscription_schedules/{schedule}"
            |> this.RestApiClient.PostAsync<_, SubscriptionSchedule> ``params``

        ///<p>Cancels a subscription schedule and its associated subscription immediately (if the subscription schedule has an active subscription). A subscription schedule can only be canceled if its status is <code>not_started</code> or <code>active</code>.</p>
        member this.Cancel ((``params``: PostSubscriptionSchedulesScheduleCancelParams), schedule: string) =
            $"/v1/subscription_schedules/{schedule}/cancel"
            |> this.RestApiClient.PostAsync<_, SubscriptionSchedule> ``params``

        ///<p>Releases the subscription schedule immediately, which will stop scheduling of its phases, but leave any existing subscription in place. A schedule can only be released if its status is <code>not_started</code> or <code>active</code>. If the subscription schedule is currently associated with a subscription, releasing it will remove its <code>subscription</code> property and set the subscription’s ID to the <code>released_subscription</code> property.</p>
        member this.Release ((``params``: PostSubscriptionSchedulesScheduleReleaseParams), schedule: string) =
            $"/v1/subscription_schedules/{schedule}/release"
            |> this.RestApiClient.PostAsync<_, SubscriptionSchedule> ``params``

    and TaxIdService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Creates a new <code>TaxID</code> object for a customer.</p>
        member this.CreateForCustomer ((``params``: PostCustomersCustomerTaxIdsParams), customer: string) =
            $"/v1/customers/{customer}/tax_ids"
            |> this.RestApiClient.PostAsync<_, TaxId> ``params``

        ///<p>Retrieves the <code>TaxID</code> object with the given identifier.</p>
        member this.RetrieveForCustomer (customer: string, id: string, ?expand: string list) =
            $"/v1/customers/{customer}/tax_ids/{id}"
            |> this.RestApiClient.GetAsync<TaxId>

        ///<p>Returns a list of tax IDs for a customer.</p>
        member this.ListForCustomer (customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/customers/{customer}/tax_ids"
            |> this.RestApiClient.GetAsync<TaxId>

        ///<p>Deletes an existing <code>TaxID</code> object.</p>
        member this.DeleteForCustomer (customer: string, id: string) =
            $"/v1/customers/{customer}/tax_ids/{id}"
            |> this.RestApiClient.DeleteAsync<DeletedTaxId>

    and TaxRateService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of your tax rates. Tax rates are returned sorted by creation date, with the most recently created tax rates appearing first.</p>
        member this.List (?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?inclusive: bool, ?limit: int, ?startingAfter: string) =
            $"/v1/tax_rates"
            |> this.RestApiClient.GetAsync<TaxRate>

        ///<p>Retrieves a tax rate with the given ID</p>
        member this.Retrieve (taxRate: string, ?expand: string list) =
            $"/v1/tax_rates/{taxRate}"
            |> this.RestApiClient.GetAsync<TaxRate>

        ///<p>Creates a new tax rate.</p>
        member this.Create ((``params``: PostTaxRatesParams)) =
            $"/v1/tax_rates"
            |> this.RestApiClient.PostAsync<_, TaxRate> ``params``

        ///<p>Updates an existing tax rate.</p>
        member this.Update ((``params``: PostTaxRatesTaxRateParams), taxRate: string) =
            $"/v1/tax_rates/{taxRate}"
            |> this.RestApiClient.PostAsync<_, TaxRate> ``params``

    and TerminalConnectionTokenService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>To connect to a reader the Stripe Terminal SDK needs to retrieve a short-lived connection token from Stripe, proxied through your server. On your backend, add an endpoint that creates and returns a connection token.</p>
        member this.Create ((``params``: PostTerminalConnectionTokensParams)) =
            $"/v1/terminal/connection_tokens"
            |> this.RestApiClient.PostAsync<_, TerminalConnectionToken> ``params``

    and TerminalLocationService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves a <code>Location</code> object.</p>
        member this.Retrieve (location: string, ?expand: string list) =
            $"/v1/terminal/locations/{location}"
            |> this.RestApiClient.GetAsync<TerminalLocation>

        ///<p>Creates a new <code>Location</code> object.</p>
        member this.Create ((``params``: PostTerminalLocationsParams)) =
            $"/v1/terminal/locations"
            |> this.RestApiClient.PostAsync<_, TerminalLocation> ``params``

        ///<p>Updates a <code>Location</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((``params``: PostTerminalLocationsLocationParams), location: string) =
            $"/v1/terminal/locations/{location}"
            |> this.RestApiClient.PostAsync<_, TerminalLocation> ``params``

        ///<p>Returns a list of <code>Location</code> objects.</p>
        member this.List (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/terminal/locations"
            |> this.RestApiClient.GetAsync<TerminalLocation>

        ///<p>Deletes a <code>Location</code> object.</p>
        member this.Delete (location: string) =
            $"/v1/terminal/locations/{location}"
            |> this.RestApiClient.DeleteAsync<DeletedTerminalLocation>

    and TerminalReaderService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Updates a <code>Reader</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((``params``: PostTerminalReadersReaderParams), reader: string) =
            $"/v1/terminal/readers/{reader}"
            |> this.RestApiClient.PostAsync<_, TerminalReader> ``params``

        ///<p>Retrieves a <code>Reader</code> object.</p>
        member this.Retrieve (reader: string, ?expand: string list) =
            $"/v1/terminal/readers/{reader}"
            |> this.RestApiClient.GetAsync<TerminalReader>

        ///<p>Creates a new <code>Reader</code> object.</p>
        member this.Create ((``params``: PostTerminalReadersParams)) =
            $"/v1/terminal/readers"
            |> this.RestApiClient.PostAsync<_, TerminalReader> ``params``

        ///<p>Returns a list of <code>Reader</code> objects.</p>
        member this.List (?deviceType: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?location: string, ?startingAfter: string, ?status: string) =
            $"/v1/terminal/readers"
            |> this.RestApiClient.GetAsync<TerminalReader>

        ///<p>Deletes a <code>Reader</code> object.</p>
        member this.Delete (reader: string) =
            $"/v1/terminal/readers/{reader}"
            |> this.RestApiClient.DeleteAsync<DeletedTerminalReader>

    and ThreeDSecureService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves a 3D Secure object.</p>
        member this.RetrieveFor3dSecure (threeDSecure: string, ?expand: string list) =
            $"/v1/3d_secure/{threeDSecure}"
            |> this.RestApiClient.GetAsync<ThreeDSecure>

        ///<p>Initiate 3D Secure authentication.</p>
        member this.Create ((``params``: Post3dSecureParams)) =
            $"/v1/3d_secure"
            |> this.RestApiClient.PostAsync<_, ThreeDSecure> ``params``

    and TokenService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Retrieves the token with the given ID.</p>
        member this.Retrieve (token: string, ?expand: string list) =
            $"/v1/tokens/{token}"
            |> this.RestApiClient.GetAsync<Token>

        ///<p>Creates a single-use token that represents a bank account’s details.
        ///This token can be used with any API method in place of a bank account dictionary. This token can be used only once, by attaching it to a <a href="#accounts">Custom account</a>.</p>
        member this.Create ((``params``: PostTokensParams)) =
            $"/v1/tokens"
            |> this.RestApiClient.PostAsync<_, Token> ``params``

    and TopupService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Top up the balance of an account</p>
        member this.Create ((``params``: PostTopupsParams)) =
            $"/v1/topups"
            |> this.RestApiClient.PostAsync<_, Topup> ``params``

        ///<p>Returns a list of top-ups.</p>
        member this.List (?amount: int, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            $"/v1/topups"
            |> this.RestApiClient.GetAsync<Topup>

        ///<p>Retrieves the details of a top-up that has previously been created. Supply the unique top-up ID that was returned from your previous request, and Stripe will return the corresponding top-up information.</p>
        member this.Retrieve (topup: string, ?expand: string list) =
            $"/v1/topups/{topup}"
            |> this.RestApiClient.GetAsync<Topup>

        ///<p>Updates the metadata of a top-up. Other top-up details are not editable by design.</p>
        member this.Update ((``params``: PostTopupsTopupParams), topup: string) =
            $"/v1/topups/{topup}"
            |> this.RestApiClient.PostAsync<_, Topup> ``params``

        ///<p>Cancels a top-up. Only pending top-ups can be canceled.</p>
        member this.Cancel ((``params``: PostTopupsTopupCancelParams), topup: string) =
            $"/v1/topups/{topup}/cancel"
            |> this.RestApiClient.PostAsync<_, Topup> ``params``

    and TransferService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>To send funds from your Stripe account to a connected account, you create a new transfer object. Your <a href="#balance">Stripe balance</a> must be able to cover the transfer amount, or you’ll receive an “Insufficient Funds” error.</p>
        member this.Create ((``params``: PostTransfersParams)) =
            $"/v1/transfers"
            |> this.RestApiClient.PostAsync<_, Transfer> ``params``

        ///<p>Returns a list of existing transfers sent to connected accounts. The transfers are returned in sorted order, with the most recently created transfers appearing first.</p>
        member this.List (?created: int, ?destination: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?transferGroup: string) =
            $"/v1/transfers"
            |> this.RestApiClient.GetAsync<Transfer>

        ///<p>Retrieves the details of an existing transfer. Supply the unique transfer ID from either a transfer creation request or the transfer list, and Stripe will return the corresponding transfer information.</p>
        member this.Retrieve (transfer: string, ?expand: string list) =
            $"/v1/transfers/{transfer}"
            |> this.RestApiClient.GetAsync<Transfer>

        ///<p>Updates the specified transfer by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request accepts only metadata as an argument.</p>
        member this.Update ((``params``: PostTransfersTransferParams), transfer: string) =
            $"/v1/transfers/{transfer}"
            |> this.RestApiClient.PostAsync<_, Transfer> ``params``

    and TransferReversalService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>When you create a new reversal, you must specify a transfer to create it on.
        ///When reversing transfers, you can optionally reverse part of the transfer. You can do so as many times as you wish until the entire transfer has been reversed.
        ///Once entirely reversed, a transfer can’t be reversed again. This method will return an error when called on an already-reversed transfer, or when trying to reverse more money than is left on a transfer.</p>
        member this.Create ((``params``: PostTransfersIdReversalsParams), id: string) =
            $"/v1/transfers/{id}/reversals"
            |> this.RestApiClient.PostAsync<_, TransferReversal> ``params``

        ///<p>You can see a list of the reversals belonging to a specific transfer. Note that the 10 most recent reversals are always available by default on the transfer object. If you need more than those 10, you can use this API method and the <code>limit</code> and <code>starting_after</code> parameters to page through additional reversals.</p>
        member this.List (id: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/transfers/{id}/reversals"
            |> this.RestApiClient.GetAsync<TransferReversal>

        ///<p>By default, you can see the 10 most recent reversals stored directly on the transfer object, but you can also retrieve details about a specific reversal stored on the transfer.</p>
        member this.Retrieve (id: string, transfer: string, ?expand: string list) =
            $"/v1/transfers/{transfer}/reversals/{id}"
            |> this.RestApiClient.GetAsync<TransferReversal>

        ///<p>Updates the specified reversal by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request only accepts metadata and description as arguments.</p>
        member this.Update ((``params``: PostTransfersTransferReversalsIdParams), id: string, transfer: string) =
            $"/v1/transfers/{transfer}/reversals/{id}"
            |> this.RestApiClient.PostAsync<_, TransferReversal> ``params``

    and UsageRecordService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Creates a usage record for a specified subscription item and date, and fills it with a quantity.
        ///Usage records provide <code>quantity</code> information that Stripe uses to track how much a customer is using your service. With usage information and the pricing model set up by the <a href="https://stripe.com/docs/billing/subscriptions/metered-billing">metered billing</a> plan, Stripe helps you send accurate invoices to your customers.
        ///The default calculation for usage is to add up all the <code>quantity</code> values of the usage records within a billing period. You can change this default behavior with the billing plan’s <code>aggregate_usage</code> <a href="/docs/api/plans/create#create_plan-aggregate_usage">parameter</a>. When there is more than one usage record with the same timestamp, Stripe adds the <code>quantity</code> values together. In most cases, this is the desired resolution, however, you can change this behavior with the <code>action</code> parameter.
        ///The default pricing model for metered billing is <a href="/docs/api/plans/object#plan_object-billing_scheme">per-unit pricing</a>. For finer granularity, you can configure metered billing to have a <a href="https://stripe.com/docs/billing/subscriptions/tiers">tiered pricing</a> model.</p>
        member this.CreateForSubscriptionItem ((``params``: PostSubscriptionItemsSubscriptionItemUsageRecordsParams), subscriptionItem: string) =
            $"/v1/subscription_items/{subscriptionItem}/usage_records"
            |> this.RestApiClient.PostAsync<_, UsageRecord> ``params``

    and UsageRecordSummaryService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>For the specified subscription item, returns a list of summary objects. Each object in the list provides usage information that’s been summarized from multiple usage records and over a subscription billing period (e.g., 15 usage records in the month of September).
        ///The list is sorted in reverse-chronological order (newest first). The first list item represents the most current usage period that hasn’t ended yet. Since new usage records can still be added, the returned summary information for the subscription item’s ID should be seen as unstable until the subscription billing period ends.</p>
        member this.ListForSubscriptionItem (subscriptionItem: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/subscription_items/{subscriptionItem}/usage_record_summaries"
            |> this.RestApiClient.GetAsync<UsageRecordSummary>

    and WebhookEndpointService(?apiKey: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey)

        ///<p>Returns a list of your webhook endpoints.</p>
        member this.List (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/webhook_endpoints"
            |> this.RestApiClient.GetAsync<WebhookEndpoint>

        ///<p>Retrieves the webhook endpoint with the given ID.</p>
        member this.Retrieve (webhookEndpoint: string, ?expand: string list) =
            $"/v1/webhook_endpoints/{webhookEndpoint}"
            |> this.RestApiClient.GetAsync<WebhookEndpoint>

        ///<p>A webhook endpoint must have a <code>url</code> and a list of <code>enabled_events</code>. You may optionally specify the Boolean <code>connect</code> parameter. If set to true, then a Connect webhook endpoint that notifies the specified <code>url</code> about events from all connected accounts is created; otherwise an account webhook endpoint that notifies the specified <code>url</code> only about events from your account is created. You can also create webhook endpoints in the <a href="https://dashboard.stripe.com/account/webhooks">webhooks settings</a> section of the Dashboard.</p>
        member this.Create ((``params``: PostWebhookEndpointsParams)) =
            $"/v1/webhook_endpoints"
            |> this.RestApiClient.PostAsync<_, WebhookEndpoint> ``params``

        ///<p>Updates the webhook endpoint. You may edit the <code>url</code>, the list of <code>enabled_events</code>, and the status of your endpoint.</p>
        member this.Update ((``params``: PostWebhookEndpointsWebhookEndpointParams), webhookEndpoint: string) =
            $"/v1/webhook_endpoints/{webhookEndpoint}"
            |> this.RestApiClient.PostAsync<_, WebhookEndpoint> ``params``

        ///<p>You can also delete webhook endpoints via the <a href="https://dashboard.stripe.com/account/webhooks">webhook endpoint management</a> page of the Stripe dashboard.</p>
        member this.Delete (webhookEndpoint: string) =
            $"/v1/webhook_endpoints/{webhookEndpoint}"
            |> this.RestApiClient.DeleteAsync<DeletedWebhookEndpoint>

    and PostAccountsAccountSupportAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostAccountsAccountBusinessProfileParam (mcc: string, name: string, productDescription: string, supportAddress: SupportAddressParam, supportEmail: string, supportPhone: string, supportUrl: string, url: string) =
        member _.mcc = mcc
        member _.name = name
        member _.productDescription = productDescription
        member _.supportAddress = supportAddress
        member _.supportEmail = supportEmail
        member _.supportPhone = supportPhone
        member _.supportUrl = supportUrl
        member _.url = url

    and PostAccountsAccountAuBecsDebitPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountBacsDebitPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountBancontactPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountCardIssuingParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountCardPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountCartesBancairesPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountEpsPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountFpxPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountGiropayPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountGrabpayPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountIdealPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountJcbPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountLegacyPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountOxxoPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountP24PaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountSepaDebitPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountSofortPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountTaxReportingUs1099KParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountTaxReportingUs1099MiscParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountTransfersParam (requested: bool) =
        member _.requested = requested

    and PostAccountsAccountCapabilitiesParam (auBecsDebitPayments: AuBecsDebitPaymentsParam, bacsDebitPayments: BacsDebitPaymentsParam, bancontactPayments: BancontactPaymentsParam, cardIssuing: CardIssuingParam, cardPayments: CardPaymentsParam, cartesBancairesPayments: CartesBancairesPaymentsParam, epsPayments: EpsPaymentsParam, fpxPayments: FpxPaymentsParam, giropayPayments: GiropayPaymentsParam, grabpayPayments: GrabpayPaymentsParam, idealPayments: IdealPaymentsParam, jcbPayments: JcbPaymentsParam, legacyPayments: LegacyPaymentsParam, oxxoPayments: OxxoPaymentsParam, p24Payments: P24PaymentsParam, sepaDebitPayments: SepaDebitPaymentsParam, sofortPayments: SofortPaymentsParam, taxReportingUs1099K: TaxReportingUs1099KParam, taxReportingUs1099Misc: TaxReportingUs1099MiscParam, transfers: TransfersParam) =
        member _.auBecsDebitPayments = auBecsDebitPayments
        member _.bacsDebitPayments = bacsDebitPayments
        member _.bancontactPayments = bancontactPayments
        member _.cardIssuing = cardIssuing
        member _.cardPayments = cardPayments
        member _.cartesBancairesPayments = cartesBancairesPayments
        member _.epsPayments = epsPayments
        member _.fpxPayments = fpxPayments
        member _.giropayPayments = giropayPayments
        member _.grabpayPayments = grabpayPayments
        member _.idealPayments = idealPayments
        member _.jcbPayments = jcbPayments
        member _.legacyPayments = legacyPayments
        member _.oxxoPayments = oxxoPayments
        member _.p24Payments = p24Payments
        member _.sepaDebitPayments = sepaDebitPayments
        member _.sofortPayments = sofortPayments
        member _.taxReportingUs1099K = taxReportingUs1099K
        member _.taxReportingUs1099Misc = taxReportingUs1099Misc
        member _.transfers = transfers

    and PostAccountsAccountAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostAccountsAccountAddressKanaParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string, town: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state
        member _.town = town

    and PostAccountsAccountAddressKanjiParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string, town: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state
        member _.town = town

    and PostAccountsAccountDocumentParam (back: string, front: string) =
        member _.back = back
        member _.front = front

    and PostAccountsAccountVerificationParam (document: DocumentParam) =
        member _.document = document

    and PostAccountsAccountCompanyParam (address: AddressParam, addressKana: AddressKanaParam, addressKanji: AddressKanjiParam, directorsProvided: bool, executivesProvided: bool, name: string, nameKana: string, nameKanji: string, ownersProvided: bool, phone: string, registrationNumber: string, structure: string, taxId: string, taxIdRegistrar: string, vatId: string, verification: VerificationParam) =
        member _.address = address
        member _.addressKana = addressKana
        member _.addressKanji = addressKanji
        member _.directorsProvided = directorsProvided
        member _.executivesProvided = executivesProvided
        member _.name = name
        member _.nameKana = nameKana
        member _.nameKanji = nameKanji
        member _.ownersProvided = ownersProvided
        member _.phone = phone
        member _.registrationNumber = registrationNumber
        member _.structure = structure
        member _.taxId = taxId
        member _.taxIdRegistrar = taxIdRegistrar
        member _.vatId = vatId
        member _.verification = verification

    and PostAccountsAccountDobParam (day: int, month: int, year: int) =
        member _.day = day
        member _.month = month
        member _.year = year

    and PostAccountsAccountAdditionalDocumentParam (back: string, front: string) =
        member _.back = back
        member _.front = front

    and PostAccountsAccountVerificationParam (additionalDocument: AdditionalDocumentParam, document: DocumentParam) =
        member _.additionalDocument = additionalDocument
        member _.document = document

    and PostAccountsAccountIndividualParam (address: AddressParam, addressKana: AddressKanaParam, addressKanji: AddressKanjiParam, dob: DobParam, email: string, firstName: string, firstNameKana: string, firstNameKanji: string, gender: string, idNumber: string, lastName: string, lastNameKana: string, lastNameKanji: string, maidenName: string, metadata: Map<string, string>, phone: string, politicalExposure: string, ssnLast4: string, verification: VerificationParam) =
        member _.address = address
        member _.addressKana = addressKana
        member _.addressKanji = addressKanji
        member _.dob = dob
        member _.email = email
        member _.firstName = firstName
        member _.firstNameKana = firstNameKana
        member _.firstNameKanji = firstNameKanji
        member _.gender = gender
        member _.idNumber = idNumber
        member _.lastName = lastName
        member _.lastNameKana = lastNameKana
        member _.lastNameKanji = lastNameKanji
        member _.maidenName = maidenName
        member _.metadata = metadata
        member _.phone = phone
        member _.politicalExposure = politicalExposure
        member _.ssnLast4 = ssnLast4
        member _.verification = verification

    and PostAccountsAccountBrandingParam (icon: string, logo: string, primaryColor: string, secondaryColor: string) =
        member _.icon = icon
        member _.logo = logo
        member _.primaryColor = primaryColor
        member _.secondaryColor = secondaryColor

    and PostAccountsAccountDeclineOnParam (avsFailure: bool, cvcFailure: bool) =
        member _.avsFailure = avsFailure
        member _.cvcFailure = cvcFailure

    and PostAccountsAccountCardPaymentsParam (declineOn: DeclineOnParam, statementDescriptorPrefix: string) =
        member _.declineOn = declineOn
        member _.statementDescriptorPrefix = statementDescriptorPrefix

    and PostAccountsAccountPaymentsParam (statementDescriptor: string, statementDescriptorKana: string, statementDescriptorKanji: string) =
        member _.statementDescriptor = statementDescriptor
        member _.statementDescriptorKana = statementDescriptorKana
        member _.statementDescriptorKanji = statementDescriptorKanji

    and PostAccountsAccountScheduleParam (delayDays: string, interval: string, monthlyAnchor: int, weeklyAnchor: string) =
        member _.delayDays = delayDays
        member _.interval = interval
        member _.monthlyAnchor = monthlyAnchor
        member _.weeklyAnchor = weeklyAnchor

    and PostAccountsAccountPayoutsParam (debitNegativeBalances: bool, schedule: ScheduleParam, statementDescriptor: string) =
        member _.debitNegativeBalances = debitNegativeBalances
        member _.schedule = schedule
        member _.statementDescriptor = statementDescriptor

    and PostAccountsAccountSettingsParam (branding: BrandingParam, cardPayments: CardPaymentsParam, payments: PaymentsParam, payouts: PayoutsParam) =
        member _.branding = branding
        member _.cardPayments = cardPayments
        member _.payments = payments
        member _.payouts = payouts

    and PostAccountsAccountTosAcceptanceParam (date: int, ip: string, serviceAgreement: string, userAgent: string) =
        member _.date = date
        member _.ip = ip
        member _.serviceAgreement = serviceAgreement
        member _.userAgent = userAgent

    and PostAccountsAccountParams (accountToken: string, businessProfile: BusinessProfileParam, businessType: string, capabilities: CapabilitiesParam, company: CompanyParam, defaultCurrency: string, email: string, expand: string list, externalAccount: string, individual: IndividualParam, metadata: Map<string, string>, settings: SettingsParam, tosAcceptance: TosAcceptanceParam) =
        member _.accountToken = accountToken
        member _.businessProfile = businessProfile
        member _.businessType = businessType
        member _.capabilities = capabilities
        member _.company = company
        member _.defaultCurrency = defaultCurrency
        member _.email = email
        member _.expand = expand
        member _.externalAccount = externalAccount
        member _.individual = individual
        member _.metadata = metadata
        member _.settings = settings
        member _.tosAcceptance = tosAcceptance

    and PostAccountsSupportAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostAccountsBusinessProfileParam (mcc: string, name: string, productDescription: string, supportAddress: SupportAddressParam, supportEmail: string, supportPhone: string, supportUrl: string, url: string) =
        member _.mcc = mcc
        member _.name = name
        member _.productDescription = productDescription
        member _.supportAddress = supportAddress
        member _.supportEmail = supportEmail
        member _.supportPhone = supportPhone
        member _.supportUrl = supportUrl
        member _.url = url

    and PostAccountsAuBecsDebitPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsBacsDebitPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsBancontactPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsCardIssuingParam (requested: bool) =
        member _.requested = requested

    and PostAccountsCardPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsCartesBancairesPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsEpsPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsFpxPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsGiropayPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsGrabpayPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsIdealPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsJcbPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsLegacyPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsOxxoPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsP24PaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsSepaDebitPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsSofortPaymentsParam (requested: bool) =
        member _.requested = requested

    and PostAccountsTaxReportingUs1099KParam (requested: bool) =
        member _.requested = requested

    and PostAccountsTaxReportingUs1099MiscParam (requested: bool) =
        member _.requested = requested

    and PostAccountsTransfersParam (requested: bool) =
        member _.requested = requested

    and PostAccountsCapabilitiesParam (auBecsDebitPayments: AuBecsDebitPaymentsParam, bacsDebitPayments: BacsDebitPaymentsParam, bancontactPayments: BancontactPaymentsParam, cardIssuing: CardIssuingParam, cardPayments: CardPaymentsParam, cartesBancairesPayments: CartesBancairesPaymentsParam, epsPayments: EpsPaymentsParam, fpxPayments: FpxPaymentsParam, giropayPayments: GiropayPaymentsParam, grabpayPayments: GrabpayPaymentsParam, idealPayments: IdealPaymentsParam, jcbPayments: JcbPaymentsParam, legacyPayments: LegacyPaymentsParam, oxxoPayments: OxxoPaymentsParam, p24Payments: P24PaymentsParam, sepaDebitPayments: SepaDebitPaymentsParam, sofortPayments: SofortPaymentsParam, taxReportingUs1099K: TaxReportingUs1099KParam, taxReportingUs1099Misc: TaxReportingUs1099MiscParam, transfers: TransfersParam) =
        member _.auBecsDebitPayments = auBecsDebitPayments
        member _.bacsDebitPayments = bacsDebitPayments
        member _.bancontactPayments = bancontactPayments
        member _.cardIssuing = cardIssuing
        member _.cardPayments = cardPayments
        member _.cartesBancairesPayments = cartesBancairesPayments
        member _.epsPayments = epsPayments
        member _.fpxPayments = fpxPayments
        member _.giropayPayments = giropayPayments
        member _.grabpayPayments = grabpayPayments
        member _.idealPayments = idealPayments
        member _.jcbPayments = jcbPayments
        member _.legacyPayments = legacyPayments
        member _.oxxoPayments = oxxoPayments
        member _.p24Payments = p24Payments
        member _.sepaDebitPayments = sepaDebitPayments
        member _.sofortPayments = sofortPayments
        member _.taxReportingUs1099K = taxReportingUs1099K
        member _.taxReportingUs1099Misc = taxReportingUs1099Misc
        member _.transfers = transfers

    and PostAccountsAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostAccountsAddressKanaParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string, town: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state
        member _.town = town

    and PostAccountsAddressKanjiParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string, town: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state
        member _.town = town

    and PostAccountsDocumentParam (back: string, front: string) =
        member _.back = back
        member _.front = front

    and PostAccountsVerificationParam (document: DocumentParam) =
        member _.document = document

    and PostAccountsCompanyParam (address: AddressParam, addressKana: AddressKanaParam, addressKanji: AddressKanjiParam, directorsProvided: bool, executivesProvided: bool, name: string, nameKana: string, nameKanji: string, ownersProvided: bool, phone: string, registrationNumber: string, structure: string, taxId: string, taxIdRegistrar: string, vatId: string, verification: VerificationParam) =
        member _.address = address
        member _.addressKana = addressKana
        member _.addressKanji = addressKanji
        member _.directorsProvided = directorsProvided
        member _.executivesProvided = executivesProvided
        member _.name = name
        member _.nameKana = nameKana
        member _.nameKanji = nameKanji
        member _.ownersProvided = ownersProvided
        member _.phone = phone
        member _.registrationNumber = registrationNumber
        member _.structure = structure
        member _.taxId = taxId
        member _.taxIdRegistrar = taxIdRegistrar
        member _.vatId = vatId
        member _.verification = verification

    and PostAccountsDobParam (day: int, month: int, year: int) =
        member _.day = day
        member _.month = month
        member _.year = year

    and PostAccountsAdditionalDocumentParam (back: string, front: string) =
        member _.back = back
        member _.front = front

    and PostAccountsVerificationParam (additionalDocument: AdditionalDocumentParam, document: DocumentParam) =
        member _.additionalDocument = additionalDocument
        member _.document = document

    and PostAccountsIndividualParam (address: AddressParam, addressKana: AddressKanaParam, addressKanji: AddressKanjiParam, dob: DobParam, email: string, firstName: string, firstNameKana: string, firstNameKanji: string, gender: string, idNumber: string, lastName: string, lastNameKana: string, lastNameKanji: string, maidenName: string, metadata: Map<string, string>, phone: string, politicalExposure: string, ssnLast4: string, verification: VerificationParam) =
        member _.address = address
        member _.addressKana = addressKana
        member _.addressKanji = addressKanji
        member _.dob = dob
        member _.email = email
        member _.firstName = firstName
        member _.firstNameKana = firstNameKana
        member _.firstNameKanji = firstNameKanji
        member _.gender = gender
        member _.idNumber = idNumber
        member _.lastName = lastName
        member _.lastNameKana = lastNameKana
        member _.lastNameKanji = lastNameKanji
        member _.maidenName = maidenName
        member _.metadata = metadata
        member _.phone = phone
        member _.politicalExposure = politicalExposure
        member _.ssnLast4 = ssnLast4
        member _.verification = verification

    and PostAccountsBrandingParam (icon: string, logo: string, primaryColor: string, secondaryColor: string) =
        member _.icon = icon
        member _.logo = logo
        member _.primaryColor = primaryColor
        member _.secondaryColor = secondaryColor

    and PostAccountsDeclineOnParam (avsFailure: bool, cvcFailure: bool) =
        member _.avsFailure = avsFailure
        member _.cvcFailure = cvcFailure

    and PostAccountsCardPaymentsParam (declineOn: DeclineOnParam, statementDescriptorPrefix: string) =
        member _.declineOn = declineOn
        member _.statementDescriptorPrefix = statementDescriptorPrefix

    and PostAccountsPaymentsParam (statementDescriptor: string, statementDescriptorKana: string, statementDescriptorKanji: string) =
        member _.statementDescriptor = statementDescriptor
        member _.statementDescriptorKana = statementDescriptorKana
        member _.statementDescriptorKanji = statementDescriptorKanji

    and PostAccountsScheduleParam (delayDays: string, interval: string, monthlyAnchor: int, weeklyAnchor: string) =
        member _.delayDays = delayDays
        member _.interval = interval
        member _.monthlyAnchor = monthlyAnchor
        member _.weeklyAnchor = weeklyAnchor

    and PostAccountsPayoutsParam (debitNegativeBalances: bool, schedule: ScheduleParam, statementDescriptor: string) =
        member _.debitNegativeBalances = debitNegativeBalances
        member _.schedule = schedule
        member _.statementDescriptor = statementDescriptor

    and PostAccountsSettingsParam (branding: BrandingParam, cardPayments: CardPaymentsParam, payments: PaymentsParam, payouts: PayoutsParam) =
        member _.branding = branding
        member _.cardPayments = cardPayments
        member _.payments = payments
        member _.payouts = payouts

    and PostAccountsTosAcceptanceParam (date: int, ip: string, serviceAgreement: string, userAgent: string) =
        member _.date = date
        member _.ip = ip
        member _.serviceAgreement = serviceAgreement
        member _.userAgent = userAgent

    and PostAccountsParams (accountToken: string, businessProfile: BusinessProfileParam, businessType: string, capabilities: CapabilitiesParam, company: CompanyParam, country: string, defaultCurrency: string, email: string, expand: string list, externalAccount: string, individual: IndividualParam, metadata: Map<string, string>, settings: SettingsParam, tosAcceptance: TosAcceptanceParam, ``type``: string) =
        member _.accountToken = accountToken
        member _.businessProfile = businessProfile
        member _.businessType = businessType
        member _.capabilities = capabilities
        member _.company = company
        member _.country = country
        member _.defaultCurrency = defaultCurrency
        member _.email = email
        member _.expand = expand
        member _.externalAccount = externalAccount
        member _.individual = individual
        member _.metadata = metadata
        member _.settings = settings
        member _.tosAcceptance = tosAcceptance
        member _.``type`` = ``type``

    and PostAccountsAccountRejectParams (expand: string list, reason: string) =
        member _.expand = expand
        member _.reason = reason

    and PostAccountLinksParams (account: string, collect: string, expand: string list, refreshUrl: string, returnUrl: string, ``type``: string) =
        member _.account = account
        member _.collect = collect
        member _.expand = expand
        member _.refreshUrl = refreshUrl
        member _.returnUrl = returnUrl
        member _.``type`` = ``type``

    and PostApplePayDomainsParams (domainName: string, expand: string list) =
        member _.domainName = domainName
        member _.expand = expand

    and PostCustomersCustomerSourcesIdAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostCustomersCustomerSourcesIdOwnerParam (address: AddressParam, email: string, name: string, phone: string) =
        member _.address = address
        member _.email = email
        member _.name = name
        member _.phone = phone

    and PostCustomersCustomerSourcesIdParams (accountHolderName: string, accountHolderType: string, addressCity: string, addressCountry: string, addressLine1: string, addressLine2: string, addressState: string, addressZip: string, expMonth: string, expYear: string, expand: string list, metadata: Map<string, string>, name: string, owner: OwnerParam) =
        member _.accountHolderName = accountHolderName
        member _.accountHolderType = accountHolderType
        member _.addressCity = addressCity
        member _.addressCountry = addressCountry
        member _.addressLine1 = addressLine1
        member _.addressLine2 = addressLine2
        member _.addressState = addressState
        member _.addressZip = addressZip
        member _.expMonth = expMonth
        member _.expYear = expYear
        member _.expand = expand
        member _.metadata = metadata
        member _.name = name
        member _.owner = owner

    and DeleteCustomersCustomerSourcesIdParams (expand: string list) =
        member _.expand = expand

    and PostCustomersCustomerSourcesIdVerifyParams (amounts: string list, expand: string list) =
        member _.amounts = amounts
        member _.expand = expand

    and PostAccountsAccountExternalAccountsIdParams (accountHolderName: string, accountHolderType: string, addressCity: string, addressCountry: string, addressLine1: string, addressLine2: string, addressState: string, addressZip: string, defaultForCurrency: bool, expMonth: string, expYear: string, expand: string list, metadata: Map<string, string>, name: string) =
        member _.accountHolderName = accountHolderName
        member _.accountHolderType = accountHolderType
        member _.addressCity = addressCity
        member _.addressCountry = addressCountry
        member _.addressLine1 = addressLine1
        member _.addressLine2 = addressLine2
        member _.addressState = addressState
        member _.addressZip = addressZip
        member _.defaultForCurrency = defaultForCurrency
        member _.expMonth = expMonth
        member _.expYear = expYear
        member _.expand = expand
        member _.metadata = metadata
        member _.name = name

    and PostBillingPortalSessionsParams (customer: string, expand: string list, returnUrl: string) =
        member _.customer = customer
        member _.expand = expand
        member _.returnUrl = returnUrl

    and PostAccountsAccountCapabilitiesCapabilityParams (expand: string list, requested: bool) =
        member _.expand = expand
        member _.requested = requested

    and PostChargesDestinationParam (account: string, amount: int) =
        member _.account = account
        member _.amount = amount

    and PostChargesAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostChargesShippingParam (address: AddressParam, carrier: string, name: string, phone: string, trackingNumber: string) =
        member _.address = address
        member _.carrier = carrier
        member _.name = name
        member _.phone = phone
        member _.trackingNumber = trackingNumber

    and PostChargesTransferDataParam (amount: int, destination: string) =
        member _.amount = amount
        member _.destination = destination

    and PostChargesParams (amount: int, applicationFee: int, applicationFeeAmount: int, capture: bool, currency: string, customer: string, description: string, destination: DestinationParam, expand: string list, metadata: Map<string, string>, onBehalfOf: string, receiptEmail: string, shipping: ShippingParam, source: string, statementDescriptor: string, statementDescriptorSuffix: string, transferData: TransferDataParam, transferGroup: string) =
        member _.amount = amount
        member _.applicationFee = applicationFee
        member _.applicationFeeAmount = applicationFeeAmount
        member _.capture = capture
        member _.currency = currency
        member _.customer = customer
        member _.description = description
        member _.destination = destination
        member _.expand = expand
        member _.metadata = metadata
        member _.onBehalfOf = onBehalfOf
        member _.receiptEmail = receiptEmail
        member _.shipping = shipping
        member _.source = source
        member _.statementDescriptor = statementDescriptor
        member _.statementDescriptorSuffix = statementDescriptorSuffix
        member _.transferData = transferData
        member _.transferGroup = transferGroup

    and PostChargesChargeFraudDetailsParam (userReport: string) =
        member _.userReport = userReport

    and PostChargesChargeAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostChargesChargeShippingParam (address: AddressParam, carrier: string, name: string, phone: string, trackingNumber: string) =
        member _.address = address
        member _.carrier = carrier
        member _.name = name
        member _.phone = phone
        member _.trackingNumber = trackingNumber

    and PostChargesChargeParams (customer: string, description: string, expand: string list, fraudDetails: FraudDetailsParam, metadata: Map<string, string>, receiptEmail: string, shipping: ShippingParam, transferGroup: string) =
        member _.customer = customer
        member _.description = description
        member _.expand = expand
        member _.fraudDetails = fraudDetails
        member _.metadata = metadata
        member _.receiptEmail = receiptEmail
        member _.shipping = shipping
        member _.transferGroup = transferGroup

    and PostChargesChargeCaptureTransferDataParam (amount: int) =
        member _.amount = amount

    and PostChargesChargeCaptureParams (amount: int, applicationFee: int, applicationFeeAmount: int, expand: string list, receiptEmail: string, statementDescriptor: string, statementDescriptorSuffix: string, transferData: TransferDataParam, transferGroup: string) =
        member _.amount = amount
        member _.applicationFee = applicationFee
        member _.applicationFeeAmount = applicationFeeAmount
        member _.expand = expand
        member _.receiptEmail = receiptEmail
        member _.statementDescriptor = statementDescriptor
        member _.statementDescriptorSuffix = statementDescriptorSuffix
        member _.transferData = transferData
        member _.transferGroup = transferGroup

    and PostCheckoutSessionsAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostCheckoutSessionsShippingParam (address: AddressParam, carrier: string, name: string, phone: string, trackingNumber: string) =
        member _.address = address
        member _.carrier = carrier
        member _.name = name
        member _.phone = phone
        member _.trackingNumber = trackingNumber

    and PostCheckoutSessionsTransferDataParam (amount: int, destination: string) =
        member _.amount = amount
        member _.destination = destination

    and PostCheckoutSessionsPaymentIntentDataParam (applicationFeeAmount: int, captureMethod: string, description: string, metadata: Map<string, string>, onBehalfOf: string, receiptEmail: string, setupFutureUsage: string, shipping: ShippingParam, statementDescriptor: string, statementDescriptorSuffix: string, transferData: TransferDataParam, transferGroup: string) =
        member _.applicationFeeAmount = applicationFeeAmount
        member _.captureMethod = captureMethod
        member _.description = description
        member _.metadata = metadata
        member _.onBehalfOf = onBehalfOf
        member _.receiptEmail = receiptEmail
        member _.setupFutureUsage = setupFutureUsage
        member _.shipping = shipping
        member _.statementDescriptor = statementDescriptor
        member _.statementDescriptorSuffix = statementDescriptorSuffix
        member _.transferData = transferData
        member _.transferGroup = transferGroup

    and PostCheckoutSessionsSetupIntentDataParam (description: string, metadata: Map<string, string>, onBehalfOf: string) =
        member _.description = description
        member _.metadata = metadata
        member _.onBehalfOf = onBehalfOf

    and PostCheckoutSessionsShippingAddressCollectionParam (allowedCountries: string list) =
        member _.allowedCountries = allowedCountries

    and PostCheckoutSessionsSubscriptionDataParam (applicationFeePercent: decimal, coupon: string, defaultTaxRates: string list, items: string list, metadata: Map<string, string>, trialEnd: int, trialFromPlan: bool, trialPeriodDays: int) =
        member _.applicationFeePercent = applicationFeePercent
        member _.coupon = coupon
        member _.defaultTaxRates = defaultTaxRates
        member _.items = items
        member _.metadata = metadata
        member _.trialEnd = trialEnd
        member _.trialFromPlan = trialFromPlan
        member _.trialPeriodDays = trialPeriodDays

    and PostCheckoutSessionsParams (allowPromotionCodes: bool, billingAddressCollection: string, cancelUrl: string, clientReferenceId: string, customer: string, customerEmail: string, discounts: string list, expand: string list, lineItems: string list, locale: string, metadata: Map<string, string>, mode: string, paymentIntentData: PaymentIntentDataParam, paymentMethodTypes: string list, setupIntentData: SetupIntentDataParam, shippingAddressCollection: ShippingAddressCollectionParam, submitType: string, subscriptionData: SubscriptionDataParam, successUrl: string) =
        member _.allowPromotionCodes = allowPromotionCodes
        member _.billingAddressCollection = billingAddressCollection
        member _.cancelUrl = cancelUrl
        member _.clientReferenceId = clientReferenceId
        member _.customer = customer
        member _.customerEmail = customerEmail
        member _.discounts = discounts
        member _.expand = expand
        member _.lineItems = lineItems
        member _.locale = locale
        member _.metadata = metadata
        member _.mode = mode
        member _.paymentIntentData = paymentIntentData
        member _.paymentMethodTypes = paymentMethodTypes
        member _.setupIntentData = setupIntentData
        member _.shippingAddressCollection = shippingAddressCollection
        member _.submitType = submitType
        member _.subscriptionData = subscriptionData
        member _.successUrl = successUrl

    and PostCouponsAppliesToParam (products: string list) =
        member _.products = products

    and PostCouponsParams (amountOff: int, appliesTo: AppliesToParam, currency: string, duration: string, durationInMonths: int, expand: string list, id: string, maxRedemptions: int, metadata: Map<string, string>, name: string, percentOff: decimal, redeemBy: int) =
        member _.amountOff = amountOff
        member _.appliesTo = appliesTo
        member _.currency = currency
        member _.duration = duration
        member _.durationInMonths = durationInMonths
        member _.expand = expand
        member _.id = id
        member _.maxRedemptions = maxRedemptions
        member _.metadata = metadata
        member _.name = name
        member _.percentOff = percentOff
        member _.redeemBy = redeemBy

    and PostCouponsCouponParams (expand: string list, metadata: Map<string, string>, name: string) =
        member _.expand = expand
        member _.metadata = metadata
        member _.name = name

    and PostCreditNotesParams (amount: int, creditAmount: int, expand: string list, invoice: string, lines: string list, memo: string, metadata: Map<string, string>, outOfBandAmount: int, reason: string, refund: string, refundAmount: int) =
        member _.amount = amount
        member _.creditAmount = creditAmount
        member _.expand = expand
        member _.invoice = invoice
        member _.lines = lines
        member _.memo = memo
        member _.metadata = metadata
        member _.outOfBandAmount = outOfBandAmount
        member _.reason = reason
        member _.refund = refund
        member _.refundAmount = refundAmount

    and PostCreditNotesIdParams (expand: string list, memo: string, metadata: Map<string, string>) =
        member _.expand = expand
        member _.memo = memo
        member _.metadata = metadata

    and PostCreditNotesIdVoidParams (expand: string list) =
        member _.expand = expand

    and PostCustomersAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostCustomersInvoiceSettingsParam (customFields: string list, defaultPaymentMethod: string, footer: string) =
        member _.customFields = customFields
        member _.defaultPaymentMethod = defaultPaymentMethod
        member _.footer = footer

    and PostCustomersShippingParam (address: AddressParam, name: string, phone: string) =
        member _.address = address
        member _.name = name
        member _.phone = phone

    and PostCustomersParams (address: AddressParam, balance: int, coupon: string, description: string, email: string, expand: string list, invoicePrefix: string, invoiceSettings: InvoiceSettingsParam, metadata: Map<string, string>, name: string, nextInvoiceSequence: int, paymentMethod: string, phone: string, preferredLocales: string list, promotionCode: string, shipping: ShippingParam, source: string, taxExempt: string, taxIdData: string list) =
        member _.address = address
        member _.balance = balance
        member _.coupon = coupon
        member _.description = description
        member _.email = email
        member _.expand = expand
        member _.invoicePrefix = invoicePrefix
        member _.invoiceSettings = invoiceSettings
        member _.metadata = metadata
        member _.name = name
        member _.nextInvoiceSequence = nextInvoiceSequence
        member _.paymentMethod = paymentMethod
        member _.phone = phone
        member _.preferredLocales = preferredLocales
        member _.promotionCode = promotionCode
        member _.shipping = shipping
        member _.source = source
        member _.taxExempt = taxExempt
        member _.taxIdData = taxIdData

    and PostCustomersCustomerAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostCustomersCustomerInvoiceSettingsParam (customFields: string list, defaultPaymentMethod: string, footer: string) =
        member _.customFields = customFields
        member _.defaultPaymentMethod = defaultPaymentMethod
        member _.footer = footer

    and PostCustomersCustomerShippingParam (address: AddressParam, name: string, phone: string) =
        member _.address = address
        member _.name = name
        member _.phone = phone

    and PostCustomersCustomerParams (address: AddressParam, balance: int, coupon: string, defaultSource: string, description: string, email: string, expand: string list, invoicePrefix: string, invoiceSettings: InvoiceSettingsParam, metadata: Map<string, string>, name: string, nextInvoiceSequence: int, phone: string, preferredLocales: string list, promotionCode: string, shipping: ShippingParam, source: string, taxExempt: string, trialEnd: string) =
        member _.address = address
        member _.balance = balance
        member _.coupon = coupon
        member _.defaultSource = defaultSource
        member _.description = description
        member _.email = email
        member _.expand = expand
        member _.invoicePrefix = invoicePrefix
        member _.invoiceSettings = invoiceSettings
        member _.metadata = metadata
        member _.name = name
        member _.nextInvoiceSequence = nextInvoiceSequence
        member _.phone = phone
        member _.preferredLocales = preferredLocales
        member _.promotionCode = promotionCode
        member _.shipping = shipping
        member _.source = source
        member _.taxExempt = taxExempt
        member _.trialEnd = trialEnd

    and PostCustomersCustomerBalanceTransactionsParams (amount: int, currency: string, description: string, expand: string list, metadata: Map<string, string>) =
        member _.amount = amount
        member _.currency = currency
        member _.description = description
        member _.expand = expand
        member _.metadata = metadata

    and PostCustomersCustomerBalanceTransactionsTransactionParams (description: string, expand: string list, metadata: Map<string, string>) =
        member _.description = description
        member _.expand = expand
        member _.metadata = metadata

    and PostDisputesDisputeEvidenceParam (accessActivityLog: string, billingAddress: string, cancellationPolicy: string, cancellationPolicyDisclosure: string, cancellationRebuttal: string, customerCommunication: string, customerEmailAddress: string, customerName: string, customerPurchaseIp: string, customerSignature: string, duplicateChargeDocumentation: string, duplicateChargeExplanation: string, duplicateChargeId: string, productDescription: string, receipt: string, refundPolicy: string, refundPolicyDisclosure: string, refundRefusalExplanation: string, serviceDate: string, serviceDocumentation: string, shippingAddress: string, shippingCarrier: string, shippingDate: string, shippingDocumentation: string, shippingTrackingNumber: string, uncategorizedFile: string, uncategorizedText: string) =
        member _.accessActivityLog = accessActivityLog
        member _.billingAddress = billingAddress
        member _.cancellationPolicy = cancellationPolicy
        member _.cancellationPolicyDisclosure = cancellationPolicyDisclosure
        member _.cancellationRebuttal = cancellationRebuttal
        member _.customerCommunication = customerCommunication
        member _.customerEmailAddress = customerEmailAddress
        member _.customerName = customerName
        member _.customerPurchaseIp = customerPurchaseIp
        member _.customerSignature = customerSignature
        member _.duplicateChargeDocumentation = duplicateChargeDocumentation
        member _.duplicateChargeExplanation = duplicateChargeExplanation
        member _.duplicateChargeId = duplicateChargeId
        member _.productDescription = productDescription
        member _.receipt = receipt
        member _.refundPolicy = refundPolicy
        member _.refundPolicyDisclosure = refundPolicyDisclosure
        member _.refundRefusalExplanation = refundRefusalExplanation
        member _.serviceDate = serviceDate
        member _.serviceDocumentation = serviceDocumentation
        member _.shippingAddress = shippingAddress
        member _.shippingCarrier = shippingCarrier
        member _.shippingDate = shippingDate
        member _.shippingDocumentation = shippingDocumentation
        member _.shippingTrackingNumber = shippingTrackingNumber
        member _.uncategorizedFile = uncategorizedFile
        member _.uncategorizedText = uncategorizedText

    and PostDisputesDisputeParams (evidence: EvidenceParam, expand: string list, metadata: Map<string, string>, submit: bool) =
        member _.evidence = evidence
        member _.expand = expand
        member _.metadata = metadata
        member _.submit = submit

    and PostDisputesDisputeCloseParams (expand: string list) =
        member _.expand = expand

    and PostEphemeralKeysParams (customer: string, expand: string list, issuingCard: string) =
        member _.customer = customer
        member _.expand = expand
        member _.issuingCard = issuingCard

    and DeleteEphemeralKeysKeyParams (expand: string list) =
        member _.expand = expand

    and PostAccountsAccountExternalAccountsParams (defaultForCurrency: bool, expand: string list, externalAccount: string, metadata: Map<string, string>) =
        member _.defaultForCurrency = defaultForCurrency
        member _.expand = expand
        member _.externalAccount = externalAccount
        member _.metadata = metadata

    and PostApplicationFeesIdRefundsParams (amount: int, expand: string list, metadata: Map<string, string>) =
        member _.amount = amount
        member _.expand = expand
        member _.metadata = metadata

    and PostApplicationFeesFeeRefundsIdParams (expand: string list, metadata: Map<string, string>) =
        member _.expand = expand
        member _.metadata = metadata

    and PostFileLinksParams (expand: string list, expiresAt: int, file: string, metadata: Map<string, string>) =
        member _.expand = expand
        member _.expiresAt = expiresAt
        member _.file = file
        member _.metadata = metadata

    and PostFileLinksLinkParams (expand: string list, expiresAt: string, metadata: Map<string, string>) =
        member _.expand = expand
        member _.expiresAt = expiresAt
        member _.metadata = metadata

    and PostInvoicesTransferDataParam (amount: int, destination: string) =
        member _.amount = amount
        member _.destination = destination

    and PostInvoicesParams (accountTaxIds: string list, applicationFeeAmount: int, autoAdvance: bool, collectionMethod: string, customFields: string list, customer: string, daysUntilDue: int, defaultPaymentMethod: string, defaultSource: string, defaultTaxRates: string list, description: string, discounts: string list, dueDate: int, expand: string list, footer: string, metadata: Map<string, string>, statementDescriptor: string, subscription: string, transferData: TransferDataParam) =
        member _.accountTaxIds = accountTaxIds
        member _.applicationFeeAmount = applicationFeeAmount
        member _.autoAdvance = autoAdvance
        member _.collectionMethod = collectionMethod
        member _.customFields = customFields
        member _.customer = customer
        member _.daysUntilDue = daysUntilDue
        member _.defaultPaymentMethod = defaultPaymentMethod
        member _.defaultSource = defaultSource
        member _.defaultTaxRates = defaultTaxRates
        member _.description = description
        member _.discounts = discounts
        member _.dueDate = dueDate
        member _.expand = expand
        member _.footer = footer
        member _.metadata = metadata
        member _.statementDescriptor = statementDescriptor
        member _.subscription = subscription
        member _.transferData = transferData

    and PostInvoicesInvoiceTransferDataParam (amount: int, destination: string) =
        member _.amount = amount
        member _.destination = destination

    and PostInvoicesInvoiceParams (accountTaxIds: string list, applicationFeeAmount: int, autoAdvance: bool, collectionMethod: string, customFields: string list, daysUntilDue: int, defaultPaymentMethod: string, defaultSource: string, defaultTaxRates: string list, description: string, discounts: string list, dueDate: int, expand: string list, footer: string, metadata: Map<string, string>, statementDescriptor: string, transferData: TransferDataParam) =
        member _.accountTaxIds = accountTaxIds
        member _.applicationFeeAmount = applicationFeeAmount
        member _.autoAdvance = autoAdvance
        member _.collectionMethod = collectionMethod
        member _.customFields = customFields
        member _.daysUntilDue = daysUntilDue
        member _.defaultPaymentMethod = defaultPaymentMethod
        member _.defaultSource = defaultSource
        member _.defaultTaxRates = defaultTaxRates
        member _.description = description
        member _.discounts = discounts
        member _.dueDate = dueDate
        member _.expand = expand
        member _.footer = footer
        member _.metadata = metadata
        member _.statementDescriptor = statementDescriptor
        member _.transferData = transferData

    and PostInvoicesInvoicePayParams (expand: string list, forgive: bool, offSession: bool, paidOutOfBand: bool, paymentMethod: string, source: string) =
        member _.expand = expand
        member _.forgive = forgive
        member _.offSession = offSession
        member _.paidOutOfBand = paidOutOfBand
        member _.paymentMethod = paymentMethod
        member _.source = source

    and PostInvoicesInvoiceFinalizeParams (autoAdvance: bool, expand: string list) =
        member _.autoAdvance = autoAdvance
        member _.expand = expand

    and PostInvoicesInvoiceSendParams (expand: string list) =
        member _.expand = expand

    and PostInvoicesInvoiceMarkUncollectibleParams (expand: string list) =
        member _.expand = expand

    and PostInvoicesInvoiceVoidParams (expand: string list) =
        member _.expand = expand

    and PostInvoiceitemsPeriodParam (``end``: int, start: int) =
        member _.``end`` = ``end``
        member _.start = start

    and PostInvoiceitemsPriceDataParam (currency: string, product: string, unitAmount: int, unitAmountDecimal: string) =
        member _.currency = currency
        member _.product = product
        member _.unitAmount = unitAmount
        member _.unitAmountDecimal = unitAmountDecimal

    and PostInvoiceitemsParams (amount: int, currency: string, customer: string, description: string, discountable: bool, discounts: string list, expand: string list, invoice: string, metadata: Map<string, string>, period: PeriodParam, price: string, priceData: PriceDataParam, quantity: int, subscription: string, taxRates: string list, unitAmount: int, unitAmountDecimal: string) =
        member _.amount = amount
        member _.currency = currency
        member _.customer = customer
        member _.description = description
        member _.discountable = discountable
        member _.discounts = discounts
        member _.expand = expand
        member _.invoice = invoice
        member _.metadata = metadata
        member _.period = period
        member _.price = price
        member _.priceData = priceData
        member _.quantity = quantity
        member _.subscription = subscription
        member _.taxRates = taxRates
        member _.unitAmount = unitAmount
        member _.unitAmountDecimal = unitAmountDecimal

    and PostInvoiceitemsInvoiceitemPeriodParam (``end``: int, start: int) =
        member _.``end`` = ``end``
        member _.start = start

    and PostInvoiceitemsInvoiceitemPriceDataParam (currency: string, product: string, unitAmount: int, unitAmountDecimal: string) =
        member _.currency = currency
        member _.product = product
        member _.unitAmount = unitAmount
        member _.unitAmountDecimal = unitAmountDecimal

    and PostInvoiceitemsInvoiceitemParams (amount: int, description: string, discountable: bool, discounts: string list, expand: string list, metadata: Map<string, string>, period: PeriodParam, price: string, priceData: PriceDataParam, quantity: int, taxRates: string list, unitAmount: int, unitAmountDecimal: string) =
        member _.amount = amount
        member _.description = description
        member _.discountable = discountable
        member _.discounts = discounts
        member _.expand = expand
        member _.metadata = metadata
        member _.period = period
        member _.price = price
        member _.priceData = priceData
        member _.quantity = quantity
        member _.taxRates = taxRates
        member _.unitAmount = unitAmount
        member _.unitAmountDecimal = unitAmountDecimal

    and PostIssuingAuthorizationsAuthorizationParams (expand: string list, metadata: Map<string, string>) =
        member _.expand = expand
        member _.metadata = metadata

    and PostIssuingAuthorizationsAuthorizationApproveParams (amount: int, expand: string list, metadata: Map<string, string>) =
        member _.amount = amount
        member _.expand = expand
        member _.metadata = metadata

    and PostIssuingAuthorizationsAuthorizationDeclineParams (expand: string list, metadata: Map<string, string>) =
        member _.expand = expand
        member _.metadata = metadata

    and PostIssuingCardsAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostIssuingCardsShippingParam (address: AddressParam, name: string, service: string, ``type``: string) =
        member _.address = address
        member _.name = name
        member _.service = service
        member _.``type`` = ``type``

    and PostIssuingCardsSpendingControlsParam (allowedCategories: string list, blockedCategories: string list, spendingLimits: string list) =
        member _.allowedCategories = allowedCategories
        member _.blockedCategories = blockedCategories
        member _.spendingLimits = spendingLimits

    and PostIssuingCardsParams (cardholder: string, currency: string, expand: string list, metadata: Map<string, string>, replacementFor: string, replacementReason: string, shipping: ShippingParam, spendingControls: SpendingControlsParam, status: string, ``type``: string) =
        member _.cardholder = cardholder
        member _.currency = currency
        member _.expand = expand
        member _.metadata = metadata
        member _.replacementFor = replacementFor
        member _.replacementReason = replacementReason
        member _.shipping = shipping
        member _.spendingControls = spendingControls
        member _.status = status
        member _.``type`` = ``type``

    and PostIssuingCardsCardSpendingControlsParam (allowedCategories: string list, blockedCategories: string list, spendingLimits: string list) =
        member _.allowedCategories = allowedCategories
        member _.blockedCategories = blockedCategories
        member _.spendingLimits = spendingLimits

    and PostIssuingCardsCardParams (cancellationReason: string, expand: string list, metadata: Map<string, string>, spendingControls: SpendingControlsParam, status: string) =
        member _.cancellationReason = cancellationReason
        member _.expand = expand
        member _.metadata = metadata
        member _.spendingControls = spendingControls
        member _.status = status

    and PostIssuingCardholdersAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostIssuingCardholdersBillingParam (address: AddressParam) =
        member _.address = address

    and PostIssuingCardholdersCompanyParam (taxId: string) =
        member _.taxId = taxId

    and PostIssuingCardholdersDobParam (day: int, month: int, year: int) =
        member _.day = day
        member _.month = month
        member _.year = year

    and PostIssuingCardholdersDocumentParam (back: string, front: string) =
        member _.back = back
        member _.front = front

    and PostIssuingCardholdersVerificationParam (document: DocumentParam) =
        member _.document = document

    and PostIssuingCardholdersIndividualParam (dob: DobParam, firstName: string, lastName: string, verification: VerificationParam) =
        member _.dob = dob
        member _.firstName = firstName
        member _.lastName = lastName
        member _.verification = verification

    and PostIssuingCardholdersSpendingControlsParam (allowedCategories: string list, blockedCategories: string list, spendingLimits: string list, spendingLimitsCurrency: string) =
        member _.allowedCategories = allowedCategories
        member _.blockedCategories = blockedCategories
        member _.spendingLimits = spendingLimits
        member _.spendingLimitsCurrency = spendingLimitsCurrency

    and PostIssuingCardholdersParams (billing: BillingParam, company: CompanyParam, email: string, expand: string list, individual: IndividualParam, metadata: Map<string, string>, name: string, phoneNumber: string, spendingControls: SpendingControlsParam, status: string, ``type``: string) =
        member _.billing = billing
        member _.company = company
        member _.email = email
        member _.expand = expand
        member _.individual = individual
        member _.metadata = metadata
        member _.name = name
        member _.phoneNumber = phoneNumber
        member _.spendingControls = spendingControls
        member _.status = status
        member _.``type`` = ``type``

    and PostIssuingCardholdersCardholderAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostIssuingCardholdersCardholderBillingParam (address: AddressParam) =
        member _.address = address

    and PostIssuingCardholdersCardholderCompanyParam (taxId: string) =
        member _.taxId = taxId

    and PostIssuingCardholdersCardholderDobParam (day: int, month: int, year: int) =
        member _.day = day
        member _.month = month
        member _.year = year

    and PostIssuingCardholdersCardholderDocumentParam (back: string, front: string) =
        member _.back = back
        member _.front = front

    and PostIssuingCardholdersCardholderVerificationParam (document: DocumentParam) =
        member _.document = document

    and PostIssuingCardholdersCardholderIndividualParam (dob: DobParam, firstName: string, lastName: string, verification: VerificationParam) =
        member _.dob = dob
        member _.firstName = firstName
        member _.lastName = lastName
        member _.verification = verification

    and PostIssuingCardholdersCardholderSpendingControlsParam (allowedCategories: string list, blockedCategories: string list, spendingLimits: string list, spendingLimitsCurrency: string) =
        member _.allowedCategories = allowedCategories
        member _.blockedCategories = blockedCategories
        member _.spendingLimits = spendingLimits
        member _.spendingLimitsCurrency = spendingLimitsCurrency

    and PostIssuingCardholdersCardholderParams (billing: BillingParam, company: CompanyParam, email: string, expand: string list, individual: IndividualParam, metadata: Map<string, string>, phoneNumber: string, spendingControls: SpendingControlsParam, status: string) =
        member _.billing = billing
        member _.company = company
        member _.email = email
        member _.expand = expand
        member _.individual = individual
        member _.metadata = metadata
        member _.phoneNumber = phoneNumber
        member _.spendingControls = spendingControls
        member _.status = status

    and PostIssuingDisputesCanceledParam (additionalDocumentation: string, canceledAt: int, cancellationPolicyProvided: bool, cancellationReason: string, expectedAt: int, explanation: string, productDescription: string, productType: string, returnStatus: string, returnedAt: int) =
        member _.additionalDocumentation = additionalDocumentation
        member _.canceledAt = canceledAt
        member _.cancellationPolicyProvided = cancellationPolicyProvided
        member _.cancellationReason = cancellationReason
        member _.expectedAt = expectedAt
        member _.explanation = explanation
        member _.productDescription = productDescription
        member _.productType = productType
        member _.returnStatus = returnStatus
        member _.returnedAt = returnedAt

    and PostIssuingDisputesDuplicateParam (additionalDocumentation: string, cardStatement: string, cashReceipt: string, checkImage: string, explanation: string, originalTransaction: string) =
        member _.additionalDocumentation = additionalDocumentation
        member _.cardStatement = cardStatement
        member _.cashReceipt = cashReceipt
        member _.checkImage = checkImage
        member _.explanation = explanation
        member _.originalTransaction = originalTransaction

    and PostIssuingDisputesFraudulentParam (additionalDocumentation: string, explanation: string) =
        member _.additionalDocumentation = additionalDocumentation
        member _.explanation = explanation

    and PostIssuingDisputesMerchandiseNotAsDescribedParam (additionalDocumentation: string, explanation: string, receivedAt: int, returnDescription: string, returnStatus: string, returnedAt: int) =
        member _.additionalDocumentation = additionalDocumentation
        member _.explanation = explanation
        member _.receivedAt = receivedAt
        member _.returnDescription = returnDescription
        member _.returnStatus = returnStatus
        member _.returnedAt = returnedAt

    and PostIssuingDisputesNotReceivedParam (additionalDocumentation: string, expectedAt: int, explanation: string, productDescription: string, productType: string) =
        member _.additionalDocumentation = additionalDocumentation
        member _.expectedAt = expectedAt
        member _.explanation = explanation
        member _.productDescription = productDescription
        member _.productType = productType

    and PostIssuingDisputesOtherParam (additionalDocumentation: string, explanation: string, productDescription: string, productType: string) =
        member _.additionalDocumentation = additionalDocumentation
        member _.explanation = explanation
        member _.productDescription = productDescription
        member _.productType = productType

    and PostIssuingDisputesServiceNotAsDescribedParam (additionalDocumentation: string, canceledAt: int, cancellationReason: string, explanation: string, receivedAt: int) =
        member _.additionalDocumentation = additionalDocumentation
        member _.canceledAt = canceledAt
        member _.cancellationReason = cancellationReason
        member _.explanation = explanation
        member _.receivedAt = receivedAt

    and PostIssuingDisputesEvidenceParam (canceled: CanceledParam, duplicate: DuplicateParam, fraudulent: FraudulentParam, merchandiseNotAsDescribed: MerchandiseNotAsDescribedParam, notReceived: NotReceivedParam, other: OtherParam, reason: string, serviceNotAsDescribed: ServiceNotAsDescribedParam) =
        member _.canceled = canceled
        member _.duplicate = duplicate
        member _.fraudulent = fraudulent
        member _.merchandiseNotAsDescribed = merchandiseNotAsDescribed
        member _.notReceived = notReceived
        member _.other = other
        member _.reason = reason
        member _.serviceNotAsDescribed = serviceNotAsDescribed

    and PostIssuingDisputesParams (evidence: EvidenceParam, expand: string list, metadata: Map<string, string>, transaction: string) =
        member _.evidence = evidence
        member _.expand = expand
        member _.metadata = metadata
        member _.transaction = transaction

    and PostIssuingDisputesDisputeCanceledParam (additionalDocumentation: string, canceledAt: int, cancellationPolicyProvided: bool, cancellationReason: string, expectedAt: int, explanation: string, productDescription: string, productType: string, returnStatus: string, returnedAt: int) =
        member _.additionalDocumentation = additionalDocumentation
        member _.canceledAt = canceledAt
        member _.cancellationPolicyProvided = cancellationPolicyProvided
        member _.cancellationReason = cancellationReason
        member _.expectedAt = expectedAt
        member _.explanation = explanation
        member _.productDescription = productDescription
        member _.productType = productType
        member _.returnStatus = returnStatus
        member _.returnedAt = returnedAt

    and PostIssuingDisputesDisputeDuplicateParam (additionalDocumentation: string, cardStatement: string, cashReceipt: string, checkImage: string, explanation: string, originalTransaction: string) =
        member _.additionalDocumentation = additionalDocumentation
        member _.cardStatement = cardStatement
        member _.cashReceipt = cashReceipt
        member _.checkImage = checkImage
        member _.explanation = explanation
        member _.originalTransaction = originalTransaction

    and PostIssuingDisputesDisputeFraudulentParam (additionalDocumentation: string, explanation: string) =
        member _.additionalDocumentation = additionalDocumentation
        member _.explanation = explanation

    and PostIssuingDisputesDisputeMerchandiseNotAsDescribedParam (additionalDocumentation: string, explanation: string, receivedAt: int, returnDescription: string, returnStatus: string, returnedAt: int) =
        member _.additionalDocumentation = additionalDocumentation
        member _.explanation = explanation
        member _.receivedAt = receivedAt
        member _.returnDescription = returnDescription
        member _.returnStatus = returnStatus
        member _.returnedAt = returnedAt

    and PostIssuingDisputesDisputeNotReceivedParam (additionalDocumentation: string, expectedAt: int, explanation: string, productDescription: string, productType: string) =
        member _.additionalDocumentation = additionalDocumentation
        member _.expectedAt = expectedAt
        member _.explanation = explanation
        member _.productDescription = productDescription
        member _.productType = productType

    and PostIssuingDisputesDisputeOtherParam (additionalDocumentation: string, explanation: string, productDescription: string, productType: string) =
        member _.additionalDocumentation = additionalDocumentation
        member _.explanation = explanation
        member _.productDescription = productDescription
        member _.productType = productType

    and PostIssuingDisputesDisputeServiceNotAsDescribedParam (additionalDocumentation: string, canceledAt: int, cancellationReason: string, explanation: string, receivedAt: int) =
        member _.additionalDocumentation = additionalDocumentation
        member _.canceledAt = canceledAt
        member _.cancellationReason = cancellationReason
        member _.explanation = explanation
        member _.receivedAt = receivedAt

    and PostIssuingDisputesDisputeEvidenceParam (canceled: CanceledParam, duplicate: DuplicateParam, fraudulent: FraudulentParam, merchandiseNotAsDescribed: MerchandiseNotAsDescribedParam, notReceived: NotReceivedParam, other: OtherParam, reason: string, serviceNotAsDescribed: ServiceNotAsDescribedParam) =
        member _.canceled = canceled
        member _.duplicate = duplicate
        member _.fraudulent = fraudulent
        member _.merchandiseNotAsDescribed = merchandiseNotAsDescribed
        member _.notReceived = notReceived
        member _.other = other
        member _.reason = reason
        member _.serviceNotAsDescribed = serviceNotAsDescribed

    and PostIssuingDisputesDisputeParams (evidence: EvidenceParam, expand: string list, metadata: Map<string, string>) =
        member _.evidence = evidence
        member _.expand = expand
        member _.metadata = metadata

    and PostIssuingDisputesDisputeSubmitParams (expand: string list, metadata: Map<string, string>) =
        member _.expand = expand
        member _.metadata = metadata

    and PostIssuingTransactionsTransactionParams (expand: string list, metadata: Map<string, string>) =
        member _.expand = expand
        member _.metadata = metadata

    and PostAccountsAccountLoginLinksParams (expand: string list, redirectUrl: string) =
        member _.expand = expand
        member _.redirectUrl = redirectUrl

    and PostOrdersAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostOrdersShippingParam (address: AddressParam, name: string, phone: string) =
        member _.address = address
        member _.name = name
        member _.phone = phone

    and PostOrdersParams (coupon: string, currency: string, customer: string, email: string, expand: string list, items: string list, metadata: Map<string, string>, shipping: ShippingParam) =
        member _.coupon = coupon
        member _.currency = currency
        member _.customer = customer
        member _.email = email
        member _.expand = expand
        member _.items = items
        member _.metadata = metadata
        member _.shipping = shipping

    and PostOrdersIdShippingParam (carrier: string, trackingNumber: string) =
        member _.carrier = carrier
        member _.trackingNumber = trackingNumber

    and PostOrdersIdParams (coupon: string, expand: string list, metadata: Map<string, string>, selectedShippingMethod: string, shipping: ShippingParam, status: string) =
        member _.coupon = coupon
        member _.expand = expand
        member _.metadata = metadata
        member _.selectedShippingMethod = selectedShippingMethod
        member _.shipping = shipping
        member _.status = status

    and PostOrdersIdPayParams (applicationFee: int, customer: string, email: string, expand: string list, metadata: Map<string, string>, source: string) =
        member _.applicationFee = applicationFee
        member _.customer = customer
        member _.email = email
        member _.expand = expand
        member _.metadata = metadata
        member _.source = source

    and PostOrdersIdReturnsParams (expand: string list, items: string list) =
        member _.expand = expand
        member _.items = items


    and PostPaymentIntentsOnlineParam (ipAddress: string, userAgent: string) =
        member _.ipAddress = ipAddress
        member _.userAgent = userAgent

    and PostPaymentIntentsCustomerAcceptanceParam (acceptedAt: int, offline: OfflineParam, online: OnlineParam, ``type``: string) =
        member _.acceptedAt = acceptedAt
        member _.offline = offline
        member _.online = online
        member _.``type`` = ``type``

    and PostPaymentIntentsMandateDataParam (customerAcceptance: CustomerAcceptanceParam) =
        member _.customerAcceptance = customerAcceptance

    and PostPaymentIntentsAuBecsDebitParam (accountNumber: string, bsbNumber: string) =
        member _.accountNumber = accountNumber
        member _.bsbNumber = bsbNumber

    and PostPaymentIntentsBacsDebitParam (accountNumber: string, sortCode: string) =
        member _.accountNumber = accountNumber
        member _.sortCode = sortCode

    and PostPaymentIntentsAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostPaymentIntentsBillingDetailsParam (address: AddressParam, email: string, name: string, phone: string) =
        member _.address = address
        member _.email = email
        member _.name = name
        member _.phone = phone

    and PostPaymentIntentsFpxParam (accountHolderType: string, bank: string) =
        member _.accountHolderType = accountHolderType
        member _.bank = bank

    and PostPaymentIntentsIdealParam (bank: string) =
        member _.bank = bank

    and PostPaymentIntentsP24Param (bank: string) =
        member _.bank = bank

    and PostPaymentIntentsSepaDebitParam (iban: string) =
        member _.iban = iban

    and PostPaymentIntentsSofortParam (country: string) =
        member _.country = country

    and PostPaymentIntentsPaymentMethodDataParam (alipay: AlipayParam, auBecsDebit: AuBecsDebitParam, bacsDebit: BacsDebitParam, bancontact: BancontactParam, billingDetails: BillingDetailsParam, eps: EpsParam, fpx: FpxParam, giropay: GiropayParam, grabpay: GrabpayParam, ideal: IdealParam, interacPresent: InteracPresentParam, metadata: Map<string, string>, oxxo: OxxoParam, p24: P24Param, sepaDebit: SepaDebitParam, sofort: SofortParam, ``type``: string) =
        member _.alipay = alipay
        member _.auBecsDebit = auBecsDebit
        member _.bacsDebit = bacsDebit
        member _.bancontact = bancontact
        member _.billingDetails = billingDetails
        member _.eps = eps
        member _.fpx = fpx
        member _.giropay = giropay
        member _.grabpay = grabpay
        member _.ideal = ideal
        member _.interacPresent = interacPresent
        member _.metadata = metadata
        member _.oxxo = oxxo
        member _.p24 = p24
        member _.sepaDebit = sepaDebit
        member _.sofort = sofort
        member _.``type`` = ``type``

    and PostPaymentIntentsBancontactParam (preferredLanguage: string) =
        member _.preferredLanguage = preferredLanguage

    and PostPaymentIntentsPlanParam (count: int, interval: string, ``type``: string) =
        member _.count = count
        member _.interval = interval
        member _.``type`` = ``type``

    and PostPaymentIntentsInstallmentsParam (enabled: bool, plan: PlanParam) =
        member _.enabled = enabled
        member _.plan = plan

    and PostPaymentIntentsCardParam (cvcToken: string, installments: InstallmentsParam, moto: bool, network: string, requestThreeDSecure: string) =
        member _.cvcToken = cvcToken
        member _.installments = installments
        member _.moto = moto
        member _.network = network
        member _.requestThreeDSecure = requestThreeDSecure

    and PostPaymentIntentsOxxoParam (expiresAfterDays: int) =
        member _.expiresAfterDays = expiresAfterDays

    and PostPaymentIntentsSepaDebitParam (mandateOptions: MandateOptionsParam) =
        member _.mandateOptions = mandateOptions

    and PostPaymentIntentsSofortParam (preferredLanguage: string) =
        member _.preferredLanguage = preferredLanguage

    and PostPaymentIntentsPaymentMethodOptionsParam (alipay: AlipayParam, bancontact: BancontactParam, card: CardParam, oxxo: OxxoParam, p24: P24Param, sepaDebit: SepaDebitParam, sofort: SofortParam) =
        member _.alipay = alipay
        member _.bancontact = bancontact
        member _.card = card
        member _.oxxo = oxxo
        member _.p24 = p24
        member _.sepaDebit = sepaDebit
        member _.sofort = sofort

    and PostPaymentIntentsShippingParam (address: AddressParam, carrier: string, name: string, phone: string, trackingNumber: string) =
        member _.address = address
        member _.carrier = carrier
        member _.name = name
        member _.phone = phone
        member _.trackingNumber = trackingNumber

    and PostPaymentIntentsTransferDataParam (amount: int, destination: string) =
        member _.amount = amount
        member _.destination = destination

    and PostPaymentIntentsParams (amount: int, applicationFeeAmount: int, captureMethod: string, confirm: bool, confirmationMethod: string, currency: string, customer: string, description: string, errorOnRequiresAction: bool, expand: string list, mandate: string, mandateData: MandateDataParam, metadata: Map<string, string>, offSession: bool, onBehalfOf: string, paymentMethod: string, paymentMethodData: PaymentMethodDataParam, paymentMethodOptions: PaymentMethodOptionsParam, paymentMethodTypes: string list, receiptEmail: string, returnUrl: string, setupFutureUsage: string, shipping: ShippingParam, statementDescriptor: string, statementDescriptorSuffix: string, transferData: TransferDataParam, transferGroup: string, useStripeSdk: bool) =
        member _.amount = amount
        member _.applicationFeeAmount = applicationFeeAmount
        member _.captureMethod = captureMethod
        member _.confirm = confirm
        member _.confirmationMethod = confirmationMethod
        member _.currency = currency
        member _.customer = customer
        member _.description = description
        member _.errorOnRequiresAction = errorOnRequiresAction
        member _.expand = expand
        member _.mandate = mandate
        member _.mandateData = mandateData
        member _.metadata = metadata
        member _.offSession = offSession
        member _.onBehalfOf = onBehalfOf
        member _.paymentMethod = paymentMethod
        member _.paymentMethodData = paymentMethodData
        member _.paymentMethodOptions = paymentMethodOptions
        member _.paymentMethodTypes = paymentMethodTypes
        member _.receiptEmail = receiptEmail
        member _.returnUrl = returnUrl
        member _.setupFutureUsage = setupFutureUsage
        member _.shipping = shipping
        member _.statementDescriptor = statementDescriptor
        member _.statementDescriptorSuffix = statementDescriptorSuffix
        member _.transferData = transferData
        member _.transferGroup = transferGroup
        member _.useStripeSdk = useStripeSdk

    and PostPaymentIntentsIntentAuBecsDebitParam (accountNumber: string, bsbNumber: string) =
        member _.accountNumber = accountNumber
        member _.bsbNumber = bsbNumber

    and PostPaymentIntentsIntentBacsDebitParam (accountNumber: string, sortCode: string) =
        member _.accountNumber = accountNumber
        member _.sortCode = sortCode

    and PostPaymentIntentsIntentAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostPaymentIntentsIntentBillingDetailsParam (address: AddressParam, email: string, name: string, phone: string) =
        member _.address = address
        member _.email = email
        member _.name = name
        member _.phone = phone

    and PostPaymentIntentsIntentFpxParam (accountHolderType: string, bank: string) =
        member _.accountHolderType = accountHolderType
        member _.bank = bank

    and PostPaymentIntentsIntentIdealParam (bank: string) =
        member _.bank = bank

    and PostPaymentIntentsIntentP24Param (bank: string) =
        member _.bank = bank

    and PostPaymentIntentsIntentSepaDebitParam (iban: string) =
        member _.iban = iban

    and PostPaymentIntentsIntentSofortParam (country: string) =
        member _.country = country

    and PostPaymentIntentsIntentPaymentMethodDataParam (alipay: AlipayParam, auBecsDebit: AuBecsDebitParam, bacsDebit: BacsDebitParam, bancontact: BancontactParam, billingDetails: BillingDetailsParam, eps: EpsParam, fpx: FpxParam, giropay: GiropayParam, grabpay: GrabpayParam, ideal: IdealParam, interacPresent: InteracPresentParam, metadata: Map<string, string>, oxxo: OxxoParam, p24: P24Param, sepaDebit: SepaDebitParam, sofort: SofortParam, ``type``: string) =
        member _.alipay = alipay
        member _.auBecsDebit = auBecsDebit
        member _.bacsDebit = bacsDebit
        member _.bancontact = bancontact
        member _.billingDetails = billingDetails
        member _.eps = eps
        member _.fpx = fpx
        member _.giropay = giropay
        member _.grabpay = grabpay
        member _.ideal = ideal
        member _.interacPresent = interacPresent
        member _.metadata = metadata
        member _.oxxo = oxxo
        member _.p24 = p24
        member _.sepaDebit = sepaDebit
        member _.sofort = sofort
        member _.``type`` = ``type``

    and PostPaymentIntentsIntentBancontactParam (preferredLanguage: string) =
        member _.preferredLanguage = preferredLanguage

    and PostPaymentIntentsIntentPlanParam (count: int, interval: string, ``type``: string) =
        member _.count = count
        member _.interval = interval
        member _.``type`` = ``type``

    and PostPaymentIntentsIntentInstallmentsParam (enabled: bool, plan: PlanParam) =
        member _.enabled = enabled
        member _.plan = plan

    and PostPaymentIntentsIntentCardParam (cvcToken: string, installments: InstallmentsParam, moto: bool, network: string, requestThreeDSecure: string) =
        member _.cvcToken = cvcToken
        member _.installments = installments
        member _.moto = moto
        member _.network = network
        member _.requestThreeDSecure = requestThreeDSecure

    and PostPaymentIntentsIntentOxxoParam (expiresAfterDays: int) =
        member _.expiresAfterDays = expiresAfterDays

    and PostPaymentIntentsIntentSepaDebitParam (mandateOptions: MandateOptionsParam) =
        member _.mandateOptions = mandateOptions

    and PostPaymentIntentsIntentSofortParam (preferredLanguage: string) =
        member _.preferredLanguage = preferredLanguage

    and PostPaymentIntentsIntentPaymentMethodOptionsParam (alipay: AlipayParam, bancontact: BancontactParam, card: CardParam, oxxo: OxxoParam, p24: P24Param, sepaDebit: SepaDebitParam, sofort: SofortParam) =
        member _.alipay = alipay
        member _.bancontact = bancontact
        member _.card = card
        member _.oxxo = oxxo
        member _.p24 = p24
        member _.sepaDebit = sepaDebit
        member _.sofort = sofort

    and PostPaymentIntentsIntentShippingParam (address: AddressParam, carrier: string, name: string, phone: string, trackingNumber: string) =
        member _.address = address
        member _.carrier = carrier
        member _.name = name
        member _.phone = phone
        member _.trackingNumber = trackingNumber

    and PostPaymentIntentsIntentTransferDataParam (amount: int) =
        member _.amount = amount

    and PostPaymentIntentsIntentParams (amount: int, applicationFeeAmount: int, currency: string, customer: string, description: string, expand: string list, metadata: Map<string, string>, paymentMethod: string, paymentMethodData: PaymentMethodDataParam, paymentMethodOptions: PaymentMethodOptionsParam, paymentMethodTypes: string list, receiptEmail: string, setupFutureUsage: string, shipping: ShippingParam, statementDescriptor: string, statementDescriptorSuffix: string, transferData: TransferDataParam, transferGroup: string) =
        member _.amount = amount
        member _.applicationFeeAmount = applicationFeeAmount
        member _.currency = currency
        member _.customer = customer
        member _.description = description
        member _.expand = expand
        member _.metadata = metadata
        member _.paymentMethod = paymentMethod
        member _.paymentMethodData = paymentMethodData
        member _.paymentMethodOptions = paymentMethodOptions
        member _.paymentMethodTypes = paymentMethodTypes
        member _.receiptEmail = receiptEmail
        member _.setupFutureUsage = setupFutureUsage
        member _.shipping = shipping
        member _.statementDescriptor = statementDescriptor
        member _.statementDescriptorSuffix = statementDescriptorSuffix
        member _.transferData = transferData
        member _.transferGroup = transferGroup

    and PostPaymentIntentsIntentConfirmOnlineParam (ipAddress: string, userAgent: string) =
        member _.ipAddress = ipAddress
        member _.userAgent = userAgent

    and PostPaymentIntentsIntentConfirmCustomerAcceptanceParam (acceptedAt: int, offline: OfflineParam, online: OnlineParam, ``type``: string) =
        member _.acceptedAt = acceptedAt
        member _.offline = offline
        member _.online = online
        member _.``type`` = ``type``

    and PostPaymentIntentsIntentConfirmMandateDataParam (customerAcceptance: CustomerAcceptanceParam) =
        member _.customerAcceptance = customerAcceptance

    and PostPaymentIntentsIntentConfirmAuBecsDebitParam (accountNumber: string, bsbNumber: string) =
        member _.accountNumber = accountNumber
        member _.bsbNumber = bsbNumber

    and PostPaymentIntentsIntentConfirmBacsDebitParam (accountNumber: string, sortCode: string) =
        member _.accountNumber = accountNumber
        member _.sortCode = sortCode

    and PostPaymentIntentsIntentConfirmAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostPaymentIntentsIntentConfirmBillingDetailsParam (address: AddressParam, email: string, name: string, phone: string) =
        member _.address = address
        member _.email = email
        member _.name = name
        member _.phone = phone

    and PostPaymentIntentsIntentConfirmFpxParam (accountHolderType: string, bank: string) =
        member _.accountHolderType = accountHolderType
        member _.bank = bank

    and PostPaymentIntentsIntentConfirmIdealParam (bank: string) =
        member _.bank = bank

    and PostPaymentIntentsIntentConfirmP24Param (bank: string) =
        member _.bank = bank

    and PostPaymentIntentsIntentConfirmSepaDebitParam (iban: string) =
        member _.iban = iban

    and PostPaymentIntentsIntentConfirmSofortParam (country: string) =
        member _.country = country

    and PostPaymentIntentsIntentConfirmPaymentMethodDataParam (alipay: AlipayParam, auBecsDebit: AuBecsDebitParam, bacsDebit: BacsDebitParam, bancontact: BancontactParam, billingDetails: BillingDetailsParam, eps: EpsParam, fpx: FpxParam, giropay: GiropayParam, grabpay: GrabpayParam, ideal: IdealParam, interacPresent: InteracPresentParam, metadata: Map<string, string>, oxxo: OxxoParam, p24: P24Param, sepaDebit: SepaDebitParam, sofort: SofortParam, ``type``: string) =
        member _.alipay = alipay
        member _.auBecsDebit = auBecsDebit
        member _.bacsDebit = bacsDebit
        member _.bancontact = bancontact
        member _.billingDetails = billingDetails
        member _.eps = eps
        member _.fpx = fpx
        member _.giropay = giropay
        member _.grabpay = grabpay
        member _.ideal = ideal
        member _.interacPresent = interacPresent
        member _.metadata = metadata
        member _.oxxo = oxxo
        member _.p24 = p24
        member _.sepaDebit = sepaDebit
        member _.sofort = sofort
        member _.``type`` = ``type``

    and PostPaymentIntentsIntentConfirmBancontactParam (preferredLanguage: string) =
        member _.preferredLanguage = preferredLanguage

    and PostPaymentIntentsIntentConfirmPlanParam (count: int, interval: string, ``type``: string) =
        member _.count = count
        member _.interval = interval
        member _.``type`` = ``type``

    and PostPaymentIntentsIntentConfirmInstallmentsParam (enabled: bool, plan: PlanParam) =
        member _.enabled = enabled
        member _.plan = plan

    and PostPaymentIntentsIntentConfirmCardParam (cvcToken: string, installments: InstallmentsParam, moto: bool, network: string, requestThreeDSecure: string) =
        member _.cvcToken = cvcToken
        member _.installments = installments
        member _.moto = moto
        member _.network = network
        member _.requestThreeDSecure = requestThreeDSecure

    and PostPaymentIntentsIntentConfirmOxxoParam (expiresAfterDays: int) =
        member _.expiresAfterDays = expiresAfterDays

    and PostPaymentIntentsIntentConfirmSepaDebitParam (mandateOptions: MandateOptionsParam) =
        member _.mandateOptions = mandateOptions

    and PostPaymentIntentsIntentConfirmSofortParam (preferredLanguage: string) =
        member _.preferredLanguage = preferredLanguage

    and PostPaymentIntentsIntentConfirmPaymentMethodOptionsParam (alipay: AlipayParam, bancontact: BancontactParam, card: CardParam, oxxo: OxxoParam, p24: P24Param, sepaDebit: SepaDebitParam, sofort: SofortParam) =
        member _.alipay = alipay
        member _.bancontact = bancontact
        member _.card = card
        member _.oxxo = oxxo
        member _.p24 = p24
        member _.sepaDebit = sepaDebit
        member _.sofort = sofort

    and PostPaymentIntentsIntentConfirmShippingParam (address: AddressParam, carrier: string, name: string, phone: string, trackingNumber: string) =
        member _.address = address
        member _.carrier = carrier
        member _.name = name
        member _.phone = phone
        member _.trackingNumber = trackingNumber

    and PostPaymentIntentsIntentConfirmParams (errorOnRequiresAction: bool, expand: string list, mandate: string, mandateData: MandateDataParam, offSession: bool, paymentMethod: string, paymentMethodData: PaymentMethodDataParam, paymentMethodOptions: PaymentMethodOptionsParam, receiptEmail: string, returnUrl: string, setupFutureUsage: string, shipping: ShippingParam, useStripeSdk: bool) =
        member _.errorOnRequiresAction = errorOnRequiresAction
        member _.expand = expand
        member _.mandate = mandate
        member _.mandateData = mandateData
        member _.offSession = offSession
        member _.paymentMethod = paymentMethod
        member _.paymentMethodData = paymentMethodData
        member _.paymentMethodOptions = paymentMethodOptions
        member _.receiptEmail = receiptEmail
        member _.returnUrl = returnUrl
        member _.setupFutureUsage = setupFutureUsage
        member _.shipping = shipping
        member _.useStripeSdk = useStripeSdk

    and PostPaymentIntentsIntentCancelParams (cancellationReason: string, expand: string list) =
        member _.cancellationReason = cancellationReason
        member _.expand = expand

    and PostPaymentIntentsIntentCaptureTransferDataParam (amount: int) =
        member _.amount = amount

    and PostPaymentIntentsIntentCaptureParams (amountToCapture: int, applicationFeeAmount: int, expand: string list, statementDescriptor: string, statementDescriptorSuffix: string, transferData: TransferDataParam) =
        member _.amountToCapture = amountToCapture
        member _.applicationFeeAmount = applicationFeeAmount
        member _.expand = expand
        member _.statementDescriptor = statementDescriptor
        member _.statementDescriptorSuffix = statementDescriptorSuffix
        member _.transferData = transferData

    and PostPaymentMethodsAuBecsDebitParam (accountNumber: string, bsbNumber: string) =
        member _.accountNumber = accountNumber
        member _.bsbNumber = bsbNumber

    and PostPaymentMethodsBacsDebitParam (accountNumber: string, sortCode: string) =
        member _.accountNumber = accountNumber
        member _.sortCode = sortCode

    and PostPaymentMethodsAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostPaymentMethodsBillingDetailsParam (address: AddressParam, email: string, name: string, phone: string) =
        member _.address = address
        member _.email = email
        member _.name = name
        member _.phone = phone

    and PostPaymentMethodsCardParam (cvc: string, expMonth: int, expYear: int, number: string) =
        member _.cvc = cvc
        member _.expMonth = expMonth
        member _.expYear = expYear
        member _.number = number

    and PostPaymentMethodsFpxParam (accountHolderType: string, bank: string) =
        member _.accountHolderType = accountHolderType
        member _.bank = bank

    and PostPaymentMethodsIdealParam (bank: string) =
        member _.bank = bank

    and PostPaymentMethodsP24Param (bank: string) =
        member _.bank = bank

    and PostPaymentMethodsSepaDebitParam (iban: string) =
        member _.iban = iban

    and PostPaymentMethodsSofortParam (country: string) =
        member _.country = country

    and PostPaymentMethodsParams (alipay: AlipayParam, auBecsDebit: AuBecsDebitParam, bacsDebit: BacsDebitParam, bancontact: BancontactParam, billingDetails: BillingDetailsParam, card: CardParam, customer: string, eps: EpsParam, expand: string list, fpx: FpxParam, giropay: GiropayParam, grabpay: GrabpayParam, ideal: IdealParam, interacPresent: InteracPresentParam, metadata: Map<string, string>, oxxo: OxxoParam, p24: P24Param, paymentMethod: string, sepaDebit: SepaDebitParam, sofort: SofortParam, ``type``: string) =
        member _.alipay = alipay
        member _.auBecsDebit = auBecsDebit
        member _.bacsDebit = bacsDebit
        member _.bancontact = bancontact
        member _.billingDetails = billingDetails
        member _.card = card
        member _.customer = customer
        member _.eps = eps
        member _.expand = expand
        member _.fpx = fpx
        member _.giropay = giropay
        member _.grabpay = grabpay
        member _.ideal = ideal
        member _.interacPresent = interacPresent
        member _.metadata = metadata
        member _.oxxo = oxxo
        member _.p24 = p24
        member _.paymentMethod = paymentMethod
        member _.sepaDebit = sepaDebit
        member _.sofort = sofort
        member _.``type`` = ``type``

    and PostPaymentMethodsPaymentMethodAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostPaymentMethodsPaymentMethodBillingDetailsParam (address: AddressParam, email: string, name: string, phone: string) =
        member _.address = address
        member _.email = email
        member _.name = name
        member _.phone = phone

    and PostPaymentMethodsPaymentMethodCardParam (expMonth: int, expYear: int) =
        member _.expMonth = expMonth
        member _.expYear = expYear

    and PostPaymentMethodsPaymentMethodParams (auBecsDebit: AuBecsDebitParam, billingDetails: BillingDetailsParam, card: CardParam, expand: string list, metadata: Map<string, string>, sepaDebit: SepaDebitParam) =
        member _.auBecsDebit = auBecsDebit
        member _.billingDetails = billingDetails
        member _.card = card
        member _.expand = expand
        member _.metadata = metadata
        member _.sepaDebit = sepaDebit

    and PostPaymentMethodsPaymentMethodAttachParams (customer: string, expand: string list) =
        member _.customer = customer
        member _.expand = expand

    and PostPaymentMethodsPaymentMethodDetachParams (expand: string list) =
        member _.expand = expand

    and PostCustomersCustomerSourcesParams (expand: string list, metadata: Map<string, string>, source: string) =
        member _.expand = expand
        member _.metadata = metadata
        member _.source = source

    and PostPayoutsParams (amount: int, currency: string, description: string, destination: string, expand: string list, metadata: Map<string, string>, method: string, sourceType: string, statementDescriptor: string) =
        member _.amount = amount
        member _.currency = currency
        member _.description = description
        member _.destination = destination
        member _.expand = expand
        member _.metadata = metadata
        member _.method = method
        member _.sourceType = sourceType
        member _.statementDescriptor = statementDescriptor

    and PostPayoutsPayoutParams (expand: string list, metadata: Map<string, string>) =
        member _.expand = expand
        member _.metadata = metadata

    and PostPayoutsPayoutCancelParams (expand: string list) =
        member _.expand = expand

    and PostPayoutsPayoutReverseParams (expand: string list, metadata: Map<string, string>) =
        member _.expand = expand
        member _.metadata = metadata

    and PostAccountsAccountPersonsAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostAccountsAccountPersonsAddressKanaParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string, town: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state
        member _.town = town

    and PostAccountsAccountPersonsAddressKanjiParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string, town: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state
        member _.town = town

    and PostAccountsAccountPersonsDobParam (day: int, month: int, year: int) =
        member _.day = day
        member _.month = month
        member _.year = year

    and PostAccountsAccountPersonsRelationshipParam (director: bool, executive: bool, owner: bool, percentOwnership: decimal, representative: bool, title: string) =
        member _.director = director
        member _.executive = executive
        member _.owner = owner
        member _.percentOwnership = percentOwnership
        member _.representative = representative
        member _.title = title

    and PostAccountsAccountPersonsAdditionalDocumentParam (back: string, front: string) =
        member _.back = back
        member _.front = front

    and PostAccountsAccountPersonsDocumentParam (back: string, front: string) =
        member _.back = back
        member _.front = front

    and PostAccountsAccountPersonsVerificationParam (additionalDocument: AdditionalDocumentParam, document: DocumentParam) =
        member _.additionalDocument = additionalDocument
        member _.document = document

    and PostAccountsAccountPersonsParams (address: AddressParam, addressKana: AddressKanaParam, addressKanji: AddressKanjiParam, dob: DobParam, email: string, expand: string list, firstName: string, firstNameKana: string, firstNameKanji: string, gender: string, idNumber: string, lastName: string, lastNameKana: string, lastNameKanji: string, maidenName: string, metadata: Map<string, string>, personToken: string, phone: string, politicalExposure: string, relationship: RelationshipParam, ssnLast4: string, verification: VerificationParam) =
        member _.address = address
        member _.addressKana = addressKana
        member _.addressKanji = addressKanji
        member _.dob = dob
        member _.email = email
        member _.expand = expand
        member _.firstName = firstName
        member _.firstNameKana = firstNameKana
        member _.firstNameKanji = firstNameKanji
        member _.gender = gender
        member _.idNumber = idNumber
        member _.lastName = lastName
        member _.lastNameKana = lastNameKana
        member _.lastNameKanji = lastNameKanji
        member _.maidenName = maidenName
        member _.metadata = metadata
        member _.personToken = personToken
        member _.phone = phone
        member _.politicalExposure = politicalExposure
        member _.relationship = relationship
        member _.ssnLast4 = ssnLast4
        member _.verification = verification

    and PostAccountsAccountPersonsPersonAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostAccountsAccountPersonsPersonAddressKanaParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string, town: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state
        member _.town = town

    and PostAccountsAccountPersonsPersonAddressKanjiParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string, town: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state
        member _.town = town

    and PostAccountsAccountPersonsPersonDobParam (day: int, month: int, year: int) =
        member _.day = day
        member _.month = month
        member _.year = year

    and PostAccountsAccountPersonsPersonRelationshipParam (director: bool, executive: bool, owner: bool, percentOwnership: decimal, representative: bool, title: string) =
        member _.director = director
        member _.executive = executive
        member _.owner = owner
        member _.percentOwnership = percentOwnership
        member _.representative = representative
        member _.title = title

    and PostAccountsAccountPersonsPersonAdditionalDocumentParam (back: string, front: string) =
        member _.back = back
        member _.front = front

    and PostAccountsAccountPersonsPersonDocumentParam (back: string, front: string) =
        member _.back = back
        member _.front = front

    and PostAccountsAccountPersonsPersonVerificationParam (additionalDocument: AdditionalDocumentParam, document: DocumentParam) =
        member _.additionalDocument = additionalDocument
        member _.document = document

    and PostAccountsAccountPersonsPersonParams (address: AddressParam, addressKana: AddressKanaParam, addressKanji: AddressKanjiParam, dob: DobParam, email: string, expand: string list, firstName: string, firstNameKana: string, firstNameKanji: string, gender: string, idNumber: string, lastName: string, lastNameKana: string, lastNameKanji: string, maidenName: string, metadata: Map<string, string>, personToken: string, phone: string, politicalExposure: string, relationship: RelationshipParam, ssnLast4: string, verification: VerificationParam) =
        member _.address = address
        member _.addressKana = addressKana
        member _.addressKanji = addressKanji
        member _.dob = dob
        member _.email = email
        member _.expand = expand
        member _.firstName = firstName
        member _.firstNameKana = firstNameKana
        member _.firstNameKanji = firstNameKanji
        member _.gender = gender
        member _.idNumber = idNumber
        member _.lastName = lastName
        member _.lastNameKana = lastNameKana
        member _.lastNameKanji = lastNameKanji
        member _.maidenName = maidenName
        member _.metadata = metadata
        member _.personToken = personToken
        member _.phone = phone
        member _.politicalExposure = politicalExposure
        member _.relationship = relationship
        member _.ssnLast4 = ssnLast4
        member _.verification = verification

    and PostPlansProductParam (active: bool, id: string, metadata: Map<string, string>, name: string, statementDescriptor: string, unitLabel: string) =
        member _.active = active
        member _.id = id
        member _.metadata = metadata
        member _.name = name
        member _.statementDescriptor = statementDescriptor
        member _.unitLabel = unitLabel

    and PostPlansTransformUsageParam (divideBy: int, round: string) =
        member _.divideBy = divideBy
        member _.round = round

    and PostPlansParams (active: bool, aggregateUsage: string, amount: int, amountDecimal: string, billingScheme: string, currency: string, expand: string list, id: string, interval: string, intervalCount: int, metadata: Map<string, string>, nickname: string, product: ProductParam, tiers: string list, tiersMode: string, transformUsage: TransformUsageParam, trialPeriodDays: int, usageType: string) =
        member _.active = active
        member _.aggregateUsage = aggregateUsage
        member _.amount = amount
        member _.amountDecimal = amountDecimal
        member _.billingScheme = billingScheme
        member _.currency = currency
        member _.expand = expand
        member _.id = id
        member _.interval = interval
        member _.intervalCount = intervalCount
        member _.metadata = metadata
        member _.nickname = nickname
        member _.product = product
        member _.tiers = tiers
        member _.tiersMode = tiersMode
        member _.transformUsage = transformUsage
        member _.trialPeriodDays = trialPeriodDays
        member _.usageType = usageType

    and PostPlansPlanParams (active: bool, expand: string list, metadata: Map<string, string>, nickname: string, product: string, trialPeriodDays: int) =
        member _.active = active
        member _.expand = expand
        member _.metadata = metadata
        member _.nickname = nickname
        member _.product = product
        member _.trialPeriodDays = trialPeriodDays

    and PostPricesProductDataParam (active: bool, id: string, metadata: Map<string, string>, name: string, statementDescriptor: string, unitLabel: string) =
        member _.active = active
        member _.id = id
        member _.metadata = metadata
        member _.name = name
        member _.statementDescriptor = statementDescriptor
        member _.unitLabel = unitLabel

    and PostPricesRecurringParam (aggregateUsage: string, interval: string, intervalCount: int, trialPeriodDays: int, usageType: string) =
        member _.aggregateUsage = aggregateUsage
        member _.interval = interval
        member _.intervalCount = intervalCount
        member _.trialPeriodDays = trialPeriodDays
        member _.usageType = usageType

    and PostPricesTransformQuantityParam (divideBy: int, round: string) =
        member _.divideBy = divideBy
        member _.round = round

    and PostPricesParams (active: bool, billingScheme: string, currency: string, expand: string list, lookupKey: string, metadata: Map<string, string>, nickname: string, product: string, productData: ProductDataParam, recurring: RecurringParam, tiers: string list, tiersMode: string, transferLookupKey: bool, transformQuantity: TransformQuantityParam, unitAmount: int, unitAmountDecimal: string) =
        member _.active = active
        member _.billingScheme = billingScheme
        member _.currency = currency
        member _.expand = expand
        member _.lookupKey = lookupKey
        member _.metadata = metadata
        member _.nickname = nickname
        member _.product = product
        member _.productData = productData
        member _.recurring = recurring
        member _.tiers = tiers
        member _.tiersMode = tiersMode
        member _.transferLookupKey = transferLookupKey
        member _.transformQuantity = transformQuantity
        member _.unitAmount = unitAmount
        member _.unitAmountDecimal = unitAmountDecimal

    and PostPricesPriceRecurringParam (trialPeriodDays: int) =
        member _.trialPeriodDays = trialPeriodDays

    and PostPricesPriceParams (active: bool, expand: string list, lookupKey: string, metadata: Map<string, string>, nickname: string, recurring: RecurringParam, transferLookupKey: bool) =
        member _.active = active
        member _.expand = expand
        member _.lookupKey = lookupKey
        member _.metadata = metadata
        member _.nickname = nickname
        member _.recurring = recurring
        member _.transferLookupKey = transferLookupKey

    and PostProductsPackageDimensionsParam (height: decimal, length: decimal, weight: decimal, width: decimal) =
        member _.height = height
        member _.length = length
        member _.weight = weight
        member _.width = width

    and PostProductsParams (active: bool, attributes: string list, caption: string, deactivateOn: string list, description: string, expand: string list, id: string, images: string list, metadata: Map<string, string>, name: string, packageDimensions: PackageDimensionsParam, shippable: bool, statementDescriptor: string, ``type``: string, unitLabel: string, url: string) =
        member _.active = active
        member _.attributes = attributes
        member _.caption = caption
        member _.deactivateOn = deactivateOn
        member _.description = description
        member _.expand = expand
        member _.id = id
        member _.images = images
        member _.metadata = metadata
        member _.name = name
        member _.packageDimensions = packageDimensions
        member _.shippable = shippable
        member _.statementDescriptor = statementDescriptor
        member _.``type`` = ``type``
        member _.unitLabel = unitLabel
        member _.url = url

    and PostProductsIdPackageDimensionsParam (height: decimal, length: decimal, weight: decimal, width: decimal) =
        member _.height = height
        member _.length = length
        member _.weight = weight
        member _.width = width

    and PostProductsIdParams (active: bool, attributes: string list, caption: string, deactivateOn: string list, description: string, expand: string list, images: string list, metadata: Map<string, string>, name: string, packageDimensions: PackageDimensionsParam, shippable: bool, statementDescriptor: string, unitLabel: string, url: string) =
        member _.active = active
        member _.attributes = attributes
        member _.caption = caption
        member _.deactivateOn = deactivateOn
        member _.description = description
        member _.expand = expand
        member _.images = images
        member _.metadata = metadata
        member _.name = name
        member _.packageDimensions = packageDimensions
        member _.shippable = shippable
        member _.statementDescriptor = statementDescriptor
        member _.unitLabel = unitLabel
        member _.url = url

    and PostPromotionCodesRestrictionsParam (firstTimeTransaction: bool, minimumAmount: int, minimumAmountCurrency: string) =
        member _.firstTimeTransaction = firstTimeTransaction
        member _.minimumAmount = minimumAmount
        member _.minimumAmountCurrency = minimumAmountCurrency

    and PostPromotionCodesParams (active: bool, code: string, coupon: string, customer: string, expand: string list, expiresAt: int, maxRedemptions: int, metadata: Map<string, string>, restrictions: RestrictionsParam) =
        member _.active = active
        member _.code = code
        member _.coupon = coupon
        member _.customer = customer
        member _.expand = expand
        member _.expiresAt = expiresAt
        member _.maxRedemptions = maxRedemptions
        member _.metadata = metadata
        member _.restrictions = restrictions

    and PostPromotionCodesPromotionCodeParams (active: bool, expand: string list, metadata: Map<string, string>) =
        member _.active = active
        member _.expand = expand
        member _.metadata = metadata

    and PostRadarValueListsParams (alias: string, expand: string list, itemType: string, metadata: Map<string, string>, name: string) =
        member _.alias = alias
        member _.expand = expand
        member _.itemType = itemType
        member _.metadata = metadata
        member _.name = name

    and PostRadarValueListsValueListParams (alias: string, expand: string list, metadata: Map<string, string>, name: string) =
        member _.alias = alias
        member _.expand = expand
        member _.metadata = metadata
        member _.name = name

    and PostRadarValueListItemsParams (expand: string list, value: string, valueList: string) =
        member _.expand = expand
        member _.value = value
        member _.valueList = valueList

    and PostRecipientsParams (bankAccount: string, card: string, description: string, email: string, expand: string list, metadata: Map<string, string>, name: string, taxId: string, ``type``: string) =
        member _.bankAccount = bankAccount
        member _.card = card
        member _.description = description
        member _.email = email
        member _.expand = expand
        member _.metadata = metadata
        member _.name = name
        member _.taxId = taxId
        member _.``type`` = ``type``

    and PostRecipientsIdParams (bankAccount: string, card: string, defaultCard: string, description: string, email: string, expand: string list, metadata: Map<string, string>, name: string, taxId: string) =
        member _.bankAccount = bankAccount
        member _.card = card
        member _.defaultCard = defaultCard
        member _.description = description
        member _.email = email
        member _.expand = expand
        member _.metadata = metadata
        member _.name = name
        member _.taxId = taxId

    and PostRefundsParams (amount: int, charge: string, expand: string list, metadata: Map<string, string>, paymentIntent: string, reason: string, refundApplicationFee: bool, reverseTransfer: bool) =
        member _.amount = amount
        member _.charge = charge
        member _.expand = expand
        member _.metadata = metadata
        member _.paymentIntent = paymentIntent
        member _.reason = reason
        member _.refundApplicationFee = refundApplicationFee
        member _.reverseTransfer = reverseTransfer

    and PostRefundsRefundParams (expand: string list, metadata: Map<string, string>) =
        member _.expand = expand
        member _.metadata = metadata

    and PostReportingReportRunsParametersParam (columns: string list, connectedAccount: string, currency: string, intervalEnd: int, intervalStart: int, payout: string, reportingCategory: string, timezone: string) =
        member _.columns = columns
        member _.connectedAccount = connectedAccount
        member _.currency = currency
        member _.intervalEnd = intervalEnd
        member _.intervalStart = intervalStart
        member _.payout = payout
        member _.reportingCategory = reportingCategory
        member _.timezone = timezone

    and PostReportingReportRunsParams (expand: string list, parameters: ParametersParam, reportType: string) =
        member _.expand = expand
        member _.parameters = parameters
        member _.reportType = reportType

    and PostReviewsReviewApproveParams (expand: string list) =
        member _.expand = expand

    and PostSetupIntentsOnlineParam (ipAddress: string, userAgent: string) =
        member _.ipAddress = ipAddress
        member _.userAgent = userAgent

    and PostSetupIntentsCustomerAcceptanceParam (acceptedAt: int, offline: OfflineParam, online: OnlineParam, ``type``: string) =
        member _.acceptedAt = acceptedAt
        member _.offline = offline
        member _.online = online
        member _.``type`` = ``type``

    and PostSetupIntentsMandateDataParam (customerAcceptance: CustomerAcceptanceParam) =
        member _.customerAcceptance = customerAcceptance

    and PostSetupIntentsCardParam (moto: bool, requestThreeDSecure: string) =
        member _.moto = moto
        member _.requestThreeDSecure = requestThreeDSecure

    and PostSetupIntentsSepaDebitParam (mandateOptions: MandateOptionsParam) =
        member _.mandateOptions = mandateOptions

    and PostSetupIntentsPaymentMethodOptionsParam (card: CardParam, sepaDebit: SepaDebitParam) =
        member _.card = card
        member _.sepaDebit = sepaDebit

    and PostSetupIntentsSingleUseParam (amount: int, currency: string) =
        member _.amount = amount
        member _.currency = currency

    and PostSetupIntentsParams (confirm: bool, customer: string, description: string, expand: string list, mandateData: MandateDataParam, metadata: Map<string, string>, onBehalfOf: string, paymentMethod: string, paymentMethodOptions: PaymentMethodOptionsParam, paymentMethodTypes: string list, returnUrl: string, singleUse: SingleUseParam, usage: string) =
        member _.confirm = confirm
        member _.customer = customer
        member _.description = description
        member _.expand = expand
        member _.mandateData = mandateData
        member _.metadata = metadata
        member _.onBehalfOf = onBehalfOf
        member _.paymentMethod = paymentMethod
        member _.paymentMethodOptions = paymentMethodOptions
        member _.paymentMethodTypes = paymentMethodTypes
        member _.returnUrl = returnUrl
        member _.singleUse = singleUse
        member _.usage = usage

    and PostSetupIntentsIntentCardParam (moto: bool, requestThreeDSecure: string) =
        member _.moto = moto
        member _.requestThreeDSecure = requestThreeDSecure

    and PostSetupIntentsIntentSepaDebitParam (mandateOptions: MandateOptionsParam) =
        member _.mandateOptions = mandateOptions

    and PostSetupIntentsIntentPaymentMethodOptionsParam (card: CardParam, sepaDebit: SepaDebitParam) =
        member _.card = card
        member _.sepaDebit = sepaDebit

    and PostSetupIntentsIntentParams (customer: string, description: string, expand: string list, metadata: Map<string, string>, paymentMethod: string, paymentMethodOptions: PaymentMethodOptionsParam, paymentMethodTypes: string list) =
        member _.customer = customer
        member _.description = description
        member _.expand = expand
        member _.metadata = metadata
        member _.paymentMethod = paymentMethod
        member _.paymentMethodOptions = paymentMethodOptions
        member _.paymentMethodTypes = paymentMethodTypes

    and PostSetupIntentsIntentConfirmOnlineParam (ipAddress: string, userAgent: string) =
        member _.ipAddress = ipAddress
        member _.userAgent = userAgent

    and PostSetupIntentsIntentConfirmCustomerAcceptanceParam (acceptedAt: int, offline: OfflineParam, online: OnlineParam, ``type``: string) =
        member _.acceptedAt = acceptedAt
        member _.offline = offline
        member _.online = online
        member _.``type`` = ``type``

    and PostSetupIntentsIntentConfirmMandateDataParam (customerAcceptance: CustomerAcceptanceParam) =
        member _.customerAcceptance = customerAcceptance

    and PostSetupIntentsIntentConfirmCardParam (moto: bool, requestThreeDSecure: string) =
        member _.moto = moto
        member _.requestThreeDSecure = requestThreeDSecure

    and PostSetupIntentsIntentConfirmSepaDebitParam (mandateOptions: MandateOptionsParam) =
        member _.mandateOptions = mandateOptions

    and PostSetupIntentsIntentConfirmPaymentMethodOptionsParam (card: CardParam, sepaDebit: SepaDebitParam) =
        member _.card = card
        member _.sepaDebit = sepaDebit

    and PostSetupIntentsIntentConfirmParams (expand: string list, mandateData: MandateDataParam, paymentMethod: string, paymentMethodOptions: PaymentMethodOptionsParam, returnUrl: string) =
        member _.expand = expand
        member _.mandateData = mandateData
        member _.paymentMethod = paymentMethod
        member _.paymentMethodOptions = paymentMethodOptions
        member _.returnUrl = returnUrl

    and PostSetupIntentsIntentCancelParams (cancellationReason: string, expand: string list) =
        member _.cancellationReason = cancellationReason
        member _.expand = expand

    and PostSkusIdInventoryParam (quantity: int, ``type``: string, value: string) =
        member _.quantity = quantity
        member _.``type`` = ``type``
        member _.value = value

    and PostSkusIdPackageDimensionsParam (height: decimal, length: decimal, weight: decimal, width: decimal) =
        member _.height = height
        member _.length = length
        member _.weight = weight
        member _.width = width

    and PostSkusIdParams (active: bool, attributes: Map<string, string>, currency: string, expand: string list, image: string, inventory: InventoryParam, metadata: Map<string, string>, packageDimensions: PackageDimensionsParam, price: int, product: string) =
        member _.active = active
        member _.attributes = attributes
        member _.currency = currency
        member _.expand = expand
        member _.image = image
        member _.inventory = inventory
        member _.metadata = metadata
        member _.packageDimensions = packageDimensions
        member _.price = price
        member _.product = product

    and PostSkusInventoryParam (quantity: int, ``type``: string, value: string) =
        member _.quantity = quantity
        member _.``type`` = ``type``
        member _.value = value

    and PostSkusPackageDimensionsParam (height: decimal, length: decimal, weight: decimal, width: decimal) =
        member _.height = height
        member _.length = length
        member _.weight = weight
        member _.width = width

    and PostSkusParams (active: bool, attributes: Map<string, string>, currency: string, expand: string list, id: string, image: string, inventory: InventoryParam, metadata: Map<string, string>, packageDimensions: PackageDimensionsParam, price: int, product: string) =
        member _.active = active
        member _.attributes = attributes
        member _.currency = currency
        member _.expand = expand
        member _.id = id
        member _.image = image
        member _.inventory = inventory
        member _.metadata = metadata
        member _.packageDimensions = packageDimensions
        member _.price = price
        member _.product = product

    and PostSourcesOfflineParam (contactEmail: string) =
        member _.contactEmail = contactEmail

    and PostSourcesOnlineParam (date: int, ip: string, userAgent: string) =
        member _.date = date
        member _.ip = ip
        member _.userAgent = userAgent

    and PostSourcesAcceptanceParam (date: int, ip: string, offline: OfflineParam, online: OnlineParam, status: string, ``type``: string, userAgent: string) =
        member _.date = date
        member _.ip = ip
        member _.offline = offline
        member _.online = online
        member _.status = status
        member _.``type`` = ``type``
        member _.userAgent = userAgent

    and PostSourcesMandateParam (acceptance: AcceptanceParam, amount: int, currency: string, interval: string, notificationMethod: string) =
        member _.acceptance = acceptance
        member _.amount = amount
        member _.currency = currency
        member _.interval = interval
        member _.notificationMethod = notificationMethod

    and PostSourcesAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostSourcesOwnerParam (address: AddressParam, email: string, name: string, phone: string) =
        member _.address = address
        member _.email = email
        member _.name = name
        member _.phone = phone

    and PostSourcesReceiverParam (refundAttributesMethod: string) =
        member _.refundAttributesMethod = refundAttributesMethod

    and PostSourcesRedirectParam (returnUrl: string) =
        member _.returnUrl = returnUrl

    and PostSourcesShippingParam (address: AddressParam, carrier: string, name: string, phone: string, trackingNumber: string) =
        member _.address = address
        member _.carrier = carrier
        member _.name = name
        member _.phone = phone
        member _.trackingNumber = trackingNumber

    and PostSourcesSourceOrderParam (items: string list, shipping: ShippingParam) =
        member _.items = items
        member _.shipping = shipping

    and PostSourcesParams (amount: int, currency: string, customer: string, expand: string list, flow: string, mandate: MandateParam, metadata: Map<string, string>, originalSource: string, owner: OwnerParam, receiver: ReceiverParam, redirect: RedirectParam, sourceOrder: SourceOrderParam, statementDescriptor: string, token: string, ``type``: string, usage: string) =
        member _.amount = amount
        member _.currency = currency
        member _.customer = customer
        member _.expand = expand
        member _.flow = flow
        member _.mandate = mandate
        member _.metadata = metadata
        member _.originalSource = originalSource
        member _.owner = owner
        member _.receiver = receiver
        member _.redirect = redirect
        member _.sourceOrder = sourceOrder
        member _.statementDescriptor = statementDescriptor
        member _.token = token
        member _.``type`` = ``type``
        member _.usage = usage

    and PostSourcesSourceOfflineParam (contactEmail: string) =
        member _.contactEmail = contactEmail

    and PostSourcesSourceOnlineParam (date: int, ip: string, userAgent: string) =
        member _.date = date
        member _.ip = ip
        member _.userAgent = userAgent

    and PostSourcesSourceAcceptanceParam (date: int, ip: string, offline: OfflineParam, online: OnlineParam, status: string, ``type``: string, userAgent: string) =
        member _.date = date
        member _.ip = ip
        member _.offline = offline
        member _.online = online
        member _.status = status
        member _.``type`` = ``type``
        member _.userAgent = userAgent

    and PostSourcesSourceMandateParam (acceptance: AcceptanceParam, amount: int, currency: string, interval: string, notificationMethod: string) =
        member _.acceptance = acceptance
        member _.amount = amount
        member _.currency = currency
        member _.interval = interval
        member _.notificationMethod = notificationMethod

    and PostSourcesSourceAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostSourcesSourceOwnerParam (address: AddressParam, email: string, name: string, phone: string) =
        member _.address = address
        member _.email = email
        member _.name = name
        member _.phone = phone

    and PostSourcesSourceShippingParam (address: AddressParam, carrier: string, name: string, phone: string, trackingNumber: string) =
        member _.address = address
        member _.carrier = carrier
        member _.name = name
        member _.phone = phone
        member _.trackingNumber = trackingNumber

    and PostSourcesSourceSourceOrderParam (items: string list, shipping: ShippingParam) =
        member _.items = items
        member _.shipping = shipping

    and PostSourcesSourceParams (amount: int, expand: string list, mandate: MandateParam, metadata: Map<string, string>, owner: OwnerParam, sourceOrder: SourceOrderParam) =
        member _.amount = amount
        member _.expand = expand
        member _.mandate = mandate
        member _.metadata = metadata
        member _.owner = owner
        member _.sourceOrder = sourceOrder

    and PostSourcesSourceVerifyParams (expand: string list, values: string list) =
        member _.expand = expand
        member _.values = values

    and PostSubscriptionsBillingThresholdsParam (amountGte: int, resetBillingCycleAnchor: bool) =
        member _.amountGte = amountGte
        member _.resetBillingCycleAnchor = resetBillingCycleAnchor

    and PostSubscriptionsPendingInvoiceItemIntervalParam (interval: string, intervalCount: int) =
        member _.interval = interval
        member _.intervalCount = intervalCount

    and PostSubscriptionsTransferDataParam (amountPercent: decimal, destination: string) =
        member _.amountPercent = amountPercent
        member _.destination = destination

    and PostSubscriptionsParams (addInvoiceItems: string list, applicationFeePercent: decimal, backdateStartDate: int, billingCycleAnchor: int, billingThresholds: BillingThresholdsParam, cancelAt: int, cancelAtPeriodEnd: bool, collectionMethod: string, coupon: string, customer: string, daysUntilDue: int, defaultPaymentMethod: string, defaultSource: string, defaultTaxRates: string list, expand: string list, items: string list, metadata: Map<string, string>, offSession: bool, paymentBehavior: string, pendingInvoiceItemInterval: PendingInvoiceItemIntervalParam, promotionCode: string, prorationBehavior: string, transferData: TransferDataParam, trialEnd: string, trialFromPlan: bool, trialPeriodDays: int) =
        member _.addInvoiceItems = addInvoiceItems
        member _.applicationFeePercent = applicationFeePercent
        member _.backdateStartDate = backdateStartDate
        member _.billingCycleAnchor = billingCycleAnchor
        member _.billingThresholds = billingThresholds
        member _.cancelAt = cancelAt
        member _.cancelAtPeriodEnd = cancelAtPeriodEnd
        member _.collectionMethod = collectionMethod
        member _.coupon = coupon
        member _.customer = customer
        member _.daysUntilDue = daysUntilDue
        member _.defaultPaymentMethod = defaultPaymentMethod
        member _.defaultSource = defaultSource
        member _.defaultTaxRates = defaultTaxRates
        member _.expand = expand
        member _.items = items
        member _.metadata = metadata
        member _.offSession = offSession
        member _.paymentBehavior = paymentBehavior
        member _.pendingInvoiceItemInterval = pendingInvoiceItemInterval
        member _.promotionCode = promotionCode
        member _.prorationBehavior = prorationBehavior
        member _.transferData = transferData
        member _.trialEnd = trialEnd
        member _.trialFromPlan = trialFromPlan
        member _.trialPeriodDays = trialPeriodDays

    and PostSubscriptionsSubscriptionExposedIdBillingThresholdsParam (amountGte: int, resetBillingCycleAnchor: bool) =
        member _.amountGte = amountGte
        member _.resetBillingCycleAnchor = resetBillingCycleAnchor

    and PostSubscriptionsSubscriptionExposedIdPauseCollectionParam (behavior: string, resumesAt: int) =
        member _.behavior = behavior
        member _.resumesAt = resumesAt

    and PostSubscriptionsSubscriptionExposedIdPendingInvoiceItemIntervalParam (interval: string, intervalCount: int) =
        member _.interval = interval
        member _.intervalCount = intervalCount

    and PostSubscriptionsSubscriptionExposedIdTransferDataParam (amountPercent: decimal, destination: string) =
        member _.amountPercent = amountPercent
        member _.destination = destination

    and PostSubscriptionsSubscriptionExposedIdParams (addInvoiceItems: string list, applicationFeePercent: decimal, billingCycleAnchor: string, billingThresholds: BillingThresholdsParam, cancelAt: int, cancelAtPeriodEnd: bool, collectionMethod: string, coupon: string, daysUntilDue: int, defaultPaymentMethod: string, defaultSource: string, defaultTaxRates: string list, expand: string list, items: string list, metadata: Map<string, string>, offSession: bool, pauseCollection: PauseCollectionParam, paymentBehavior: string, pendingInvoiceItemInterval: PendingInvoiceItemIntervalParam, promotionCode: string, prorationBehavior: string, prorationDate: int, transferData: TransferDataParam, trialEnd: string, trialFromPlan: bool) =
        member _.addInvoiceItems = addInvoiceItems
        member _.applicationFeePercent = applicationFeePercent
        member _.billingCycleAnchor = billingCycleAnchor
        member _.billingThresholds = billingThresholds
        member _.cancelAt = cancelAt
        member _.cancelAtPeriodEnd = cancelAtPeriodEnd
        member _.collectionMethod = collectionMethod
        member _.coupon = coupon
        member _.daysUntilDue = daysUntilDue
        member _.defaultPaymentMethod = defaultPaymentMethod
        member _.defaultSource = defaultSource
        member _.defaultTaxRates = defaultTaxRates
        member _.expand = expand
        member _.items = items
        member _.metadata = metadata
        member _.offSession = offSession
        member _.pauseCollection = pauseCollection
        member _.paymentBehavior = paymentBehavior
        member _.pendingInvoiceItemInterval = pendingInvoiceItemInterval
        member _.promotionCode = promotionCode
        member _.prorationBehavior = prorationBehavior
        member _.prorationDate = prorationDate
        member _.transferData = transferData
        member _.trialEnd = trialEnd
        member _.trialFromPlan = trialFromPlan

    and DeleteSubscriptionsSubscriptionExposedIdParams (expand: string list, invoiceNow: bool, prorate: bool) =
        member _.expand = expand
        member _.invoiceNow = invoiceNow
        member _.prorate = prorate

    and PostSubscriptionItemsBillingThresholdsParam (usageGte: int) =
        member _.usageGte = usageGte

    and PostSubscriptionItemsRecurringParam (interval: string, intervalCount: int) =
        member _.interval = interval
        member _.intervalCount = intervalCount

    and PostSubscriptionItemsPriceDataParam (currency: string, product: string, recurring: RecurringParam, unitAmount: int, unitAmountDecimal: string) =
        member _.currency = currency
        member _.product = product
        member _.recurring = recurring
        member _.unitAmount = unitAmount
        member _.unitAmountDecimal = unitAmountDecimal

    and PostSubscriptionItemsParams (billingThresholds: BillingThresholdsParam, expand: string list, metadata: Map<string, string>, paymentBehavior: string, plan: string, price: string, priceData: PriceDataParam, prorationBehavior: string, prorationDate: int, quantity: int, subscription: string, taxRates: string list) =
        member _.billingThresholds = billingThresholds
        member _.expand = expand
        member _.metadata = metadata
        member _.paymentBehavior = paymentBehavior
        member _.plan = plan
        member _.price = price
        member _.priceData = priceData
        member _.prorationBehavior = prorationBehavior
        member _.prorationDate = prorationDate
        member _.quantity = quantity
        member _.subscription = subscription
        member _.taxRates = taxRates

    and PostSubscriptionItemsItemBillingThresholdsParam (usageGte: int) =
        member _.usageGte = usageGte

    and PostSubscriptionItemsItemRecurringParam (interval: string, intervalCount: int) =
        member _.interval = interval
        member _.intervalCount = intervalCount

    and PostSubscriptionItemsItemPriceDataParam (currency: string, product: string, recurring: RecurringParam, unitAmount: int, unitAmountDecimal: string) =
        member _.currency = currency
        member _.product = product
        member _.recurring = recurring
        member _.unitAmount = unitAmount
        member _.unitAmountDecimal = unitAmountDecimal

    and PostSubscriptionItemsItemParams (billingThresholds: BillingThresholdsParam, expand: string list, metadata: Map<string, string>, offSession: bool, paymentBehavior: string, plan: string, price: string, priceData: PriceDataParam, prorationBehavior: string, prorationDate: int, quantity: int, taxRates: string list) =
        member _.billingThresholds = billingThresholds
        member _.expand = expand
        member _.metadata = metadata
        member _.offSession = offSession
        member _.paymentBehavior = paymentBehavior
        member _.plan = plan
        member _.price = price
        member _.priceData = priceData
        member _.prorationBehavior = prorationBehavior
        member _.prorationDate = prorationDate
        member _.quantity = quantity
        member _.taxRates = taxRates

    and DeleteSubscriptionItemsItemParams (clearUsage: bool, prorationBehavior: string, prorationDate: int) =
        member _.clearUsage = clearUsage
        member _.prorationBehavior = prorationBehavior
        member _.prorationDate = prorationDate

    and PostSubscriptionSchedulesBillingThresholdsParam (amountGte: int, resetBillingCycleAnchor: bool) =
        member _.amountGte = amountGte
        member _.resetBillingCycleAnchor = resetBillingCycleAnchor

    and PostSubscriptionSchedulesInvoiceSettingsParam (daysUntilDue: int) =
        member _.daysUntilDue = daysUntilDue

    and PostSubscriptionSchedulesTransferDataParam (amountPercent: decimal, destination: string) =
        member _.amountPercent = amountPercent
        member _.destination = destination

    and PostSubscriptionSchedulesDefaultSettingsParam (billingCycleAnchor: string, billingThresholds: BillingThresholdsParam, collectionMethod: string, defaultPaymentMethod: string, invoiceSettings: InvoiceSettingsParam, transferData: TransferDataParam) =
        member _.billingCycleAnchor = billingCycleAnchor
        member _.billingThresholds = billingThresholds
        member _.collectionMethod = collectionMethod
        member _.defaultPaymentMethod = defaultPaymentMethod
        member _.invoiceSettings = invoiceSettings
        member _.transferData = transferData

    and PostSubscriptionSchedulesParams (customer: string, defaultSettings: DefaultSettingsParam, endBehavior: string, expand: string list, fromSubscription: string, metadata: Map<string, string>, phases: string list, startDate: int) =
        member _.customer = customer
        member _.defaultSettings = defaultSettings
        member _.endBehavior = endBehavior
        member _.expand = expand
        member _.fromSubscription = fromSubscription
        member _.metadata = metadata
        member _.phases = phases
        member _.startDate = startDate

    and PostSubscriptionSchedulesScheduleBillingThresholdsParam (amountGte: int, resetBillingCycleAnchor: bool) =
        member _.amountGte = amountGte
        member _.resetBillingCycleAnchor = resetBillingCycleAnchor

    and PostSubscriptionSchedulesScheduleInvoiceSettingsParam (daysUntilDue: int) =
        member _.daysUntilDue = daysUntilDue

    and PostSubscriptionSchedulesScheduleTransferDataParam (amountPercent: decimal, destination: string) =
        member _.amountPercent = amountPercent
        member _.destination = destination

    and PostSubscriptionSchedulesScheduleDefaultSettingsParam (billingCycleAnchor: string, billingThresholds: BillingThresholdsParam, collectionMethod: string, defaultPaymentMethod: string, invoiceSettings: InvoiceSettingsParam, transferData: TransferDataParam) =
        member _.billingCycleAnchor = billingCycleAnchor
        member _.billingThresholds = billingThresholds
        member _.collectionMethod = collectionMethod
        member _.defaultPaymentMethod = defaultPaymentMethod
        member _.invoiceSettings = invoiceSettings
        member _.transferData = transferData

    and PostSubscriptionSchedulesScheduleParams (defaultSettings: DefaultSettingsParam, endBehavior: string, expand: string list, metadata: Map<string, string>, phases: string list, prorationBehavior: string) =
        member _.defaultSettings = defaultSettings
        member _.endBehavior = endBehavior
        member _.expand = expand
        member _.metadata = metadata
        member _.phases = phases
        member _.prorationBehavior = prorationBehavior

    and PostSubscriptionSchedulesScheduleCancelParams (expand: string list, invoiceNow: bool, prorate: bool) =
        member _.expand = expand
        member _.invoiceNow = invoiceNow
        member _.prorate = prorate

    and PostSubscriptionSchedulesScheduleReleaseParams (expand: string list, preserveCancelDate: bool) =
        member _.expand = expand
        member _.preserveCancelDate = preserveCancelDate

    and PostCustomersCustomerTaxIdsParams (expand: string list, ``type``: string, value: string) =
        member _.expand = expand
        member _.``type`` = ``type``
        member _.value = value

    and PostTaxRatesParams (active: bool, description: string, displayName: string, expand: string list, inclusive: bool, jurisdiction: string, metadata: Map<string, string>, percentage: decimal) =
        member _.active = active
        member _.description = description
        member _.displayName = displayName
        member _.expand = expand
        member _.inclusive = inclusive
        member _.jurisdiction = jurisdiction
        member _.metadata = metadata
        member _.percentage = percentage

    and PostTaxRatesTaxRateParams (active: bool, description: string, displayName: string, expand: string list, jurisdiction: string, metadata: Map<string, string>) =
        member _.active = active
        member _.description = description
        member _.displayName = displayName
        member _.expand = expand
        member _.jurisdiction = jurisdiction
        member _.metadata = metadata

    and PostTerminalConnectionTokensParams (expand: string list, location: string) =
        member _.expand = expand
        member _.location = location

    and PostTerminalLocationsAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostTerminalLocationsParams (address: AddressParam, displayName: string, expand: string list, metadata: Map<string, string>) =
        member _.address = address
        member _.displayName = displayName
        member _.expand = expand
        member _.metadata = metadata

    and PostTerminalLocationsLocationAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostTerminalLocationsLocationParams (address: AddressParam, displayName: string, expand: string list, metadata: Map<string, string>) =
        member _.address = address
        member _.displayName = displayName
        member _.expand = expand
        member _.metadata = metadata

    and PostTerminalReadersReaderParams (expand: string list, label: string, metadata: Map<string, string>) =
        member _.expand = expand
        member _.label = label
        member _.metadata = metadata

    and PostTerminalReadersParams (expand: string list, label: string, location: string, metadata: Map<string, string>, registrationCode: string) =
        member _.expand = expand
        member _.label = label
        member _.location = location
        member _.metadata = metadata
        member _.registrationCode = registrationCode

    and Post3dSecureParams (amount: int, card: string, currency: string, customer: string, expand: string list, returnUrl: string) =
        member _.amount = amount
        member _.card = card
        member _.currency = currency
        member _.customer = customer
        member _.expand = expand
        member _.returnUrl = returnUrl

    and PostTokensAddressParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state

    and PostTokensAddressKanaParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string, town: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state
        member _.town = town

    and PostTokensAddressKanjiParam (city: string, country: string, line1: string, line2: string, postalCode: string, state: string, town: string) =
        member _.city = city
        member _.country = country
        member _.line1 = line1
        member _.line2 = line2
        member _.postalCode = postalCode
        member _.state = state
        member _.town = town

    and PostTokensDocumentParam (back: string, front: string) =
        member _.back = back
        member _.front = front

    and PostTokensVerificationParam (document: DocumentParam) =
        member _.document = document

    and PostTokensCompanyParam (address: AddressParam, addressKana: AddressKanaParam, addressKanji: AddressKanjiParam, directorsProvided: bool, executivesProvided: bool, name: string, nameKana: string, nameKanji: string, ownersProvided: bool, phone: string, registrationNumber: string, structure: string, taxId: string, taxIdRegistrar: string, vatId: string, verification: VerificationParam) =
        member _.address = address
        member _.addressKana = addressKana
        member _.addressKanji = addressKanji
        member _.directorsProvided = directorsProvided
        member _.executivesProvided = executivesProvided
        member _.name = name
        member _.nameKana = nameKana
        member _.nameKanji = nameKanji
        member _.ownersProvided = ownersProvided
        member _.phone = phone
        member _.registrationNumber = registrationNumber
        member _.structure = structure
        member _.taxId = taxId
        member _.taxIdRegistrar = taxIdRegistrar
        member _.vatId = vatId
        member _.verification = verification

    and PostTokensDobParam (day: int, month: int, year: int) =
        member _.day = day
        member _.month = month
        member _.year = year

    and PostTokensAdditionalDocumentParam (back: string, front: string) =
        member _.back = back
        member _.front = front

    and PostTokensVerificationParam (additionalDocument: AdditionalDocumentParam, document: DocumentParam) =
        member _.additionalDocument = additionalDocument
        member _.document = document

    and PostTokensIndividualParam (address: AddressParam, addressKana: AddressKanaParam, addressKanji: AddressKanjiParam, dob: DobParam, email: string, firstName: string, firstNameKana: string, firstNameKanji: string, gender: string, idNumber: string, lastName: string, lastNameKana: string, lastNameKanji: string, maidenName: string, metadata: Map<string, string>, phone: string, politicalExposure: string, ssnLast4: string, verification: VerificationParam) =
        member _.address = address
        member _.addressKana = addressKana
        member _.addressKanji = addressKanji
        member _.dob = dob
        member _.email = email
        member _.firstName = firstName
        member _.firstNameKana = firstNameKana
        member _.firstNameKanji = firstNameKanji
        member _.gender = gender
        member _.idNumber = idNumber
        member _.lastName = lastName
        member _.lastNameKana = lastNameKana
        member _.lastNameKanji = lastNameKanji
        member _.maidenName = maidenName
        member _.metadata = metadata
        member _.phone = phone
        member _.politicalExposure = politicalExposure
        member _.ssnLast4 = ssnLast4
        member _.verification = verification

    and PostTokensAccountParam (businessType: string, company: CompanyParam, individual: IndividualParam, tosShownAndAccepted: bool) =
        member _.businessType = businessType
        member _.company = company
        member _.individual = individual
        member _.tosShownAndAccepted = tosShownAndAccepted

    and PostTokensBankAccountParam (accountHolderName: string, accountHolderType: string, accountNumber: string, country: string, currency: string, routingNumber: string) =
        member _.accountHolderName = accountHolderName
        member _.accountHolderType = accountHolderType
        member _.accountNumber = accountNumber
        member _.country = country
        member _.currency = currency
        member _.routingNumber = routingNumber

    and PostTokensCardParam (addressCity: string, addressCountry: string, addressLine1: string, addressLine2: string, addressState: string, addressZip: string, currency: string, cvc: string, expMonth: string, expYear: string, name: string, number: string) =
        member _.addressCity = addressCity
        member _.addressCountry = addressCountry
        member _.addressLine1 = addressLine1
        member _.addressLine2 = addressLine2
        member _.addressState = addressState
        member _.addressZip = addressZip
        member _.currency = currency
        member _.cvc = cvc
        member _.expMonth = expMonth
        member _.expYear = expYear
        member _.name = name
        member _.number = number

    and PostTokensCvcUpdateParam (cvc: string) =
        member _.cvc = cvc

    and PostTokensRelationshipParam (director: bool, executive: bool, owner: bool, percentOwnership: decimal, representative: bool, title: string) =
        member _.director = director
        member _.executive = executive
        member _.owner = owner
        member _.percentOwnership = percentOwnership
        member _.representative = representative
        member _.title = title

    and PostTokensPersonParam (address: AddressParam, addressKana: AddressKanaParam, addressKanji: AddressKanjiParam, dob: DobParam, email: string, firstName: string, firstNameKana: string, firstNameKanji: string, gender: string, idNumber: string, lastName: string, lastNameKana: string, lastNameKanji: string, maidenName: string, metadata: Map<string, string>, phone: string, politicalExposure: string, relationship: RelationshipParam, ssnLast4: string, verification: VerificationParam) =
        member _.address = address
        member _.addressKana = addressKana
        member _.addressKanji = addressKanji
        member _.dob = dob
        member _.email = email
        member _.firstName = firstName
        member _.firstNameKana = firstNameKana
        member _.firstNameKanji = firstNameKanji
        member _.gender = gender
        member _.idNumber = idNumber
        member _.lastName = lastName
        member _.lastNameKana = lastNameKana
        member _.lastNameKanji = lastNameKanji
        member _.maidenName = maidenName
        member _.metadata = metadata
        member _.phone = phone
        member _.politicalExposure = politicalExposure
        member _.relationship = relationship
        member _.ssnLast4 = ssnLast4
        member _.verification = verification

    and PostTokensPiiParam (idNumber: string) =
        member _.idNumber = idNumber

    and PostTokensParams (account: AccountParam, bankAccount: BankAccountParam, card: CardParam, customer: string, cvcUpdate: CvcUpdateParam, expand: string list, person: PersonParam, pii: PiiParam) =
        member _.account = account
        member _.bankAccount = bankAccount
        member _.card = card
        member _.customer = customer
        member _.cvcUpdate = cvcUpdate
        member _.expand = expand
        member _.person = person
        member _.pii = pii

    and PostTopupsParams (amount: int, currency: string, description: string, expand: string list, metadata: Map<string, string>, source: string, statementDescriptor: string, transferGroup: string) =
        member _.amount = amount
        member _.currency = currency
        member _.description = description
        member _.expand = expand
        member _.metadata = metadata
        member _.source = source
        member _.statementDescriptor = statementDescriptor
        member _.transferGroup = transferGroup

    and PostTopupsTopupParams (description: string, expand: string list, metadata: Map<string, string>) =
        member _.description = description
        member _.expand = expand
        member _.metadata = metadata

    and PostTopupsTopupCancelParams (expand: string list) =
        member _.expand = expand

    and PostTransfersParams (amount: int, currency: string, description: string, destination: string, expand: string list, metadata: Map<string, string>, sourceTransaction: string, sourceType: string, transferGroup: string) =
        member _.amount = amount
        member _.currency = currency
        member _.description = description
        member _.destination = destination
        member _.expand = expand
        member _.metadata = metadata
        member _.sourceTransaction = sourceTransaction
        member _.sourceType = sourceType
        member _.transferGroup = transferGroup

    and PostTransfersTransferParams (description: string, expand: string list, metadata: Map<string, string>) =
        member _.description = description
        member _.expand = expand
        member _.metadata = metadata

    and PostTransfersIdReversalsParams (amount: int, description: string, expand: string list, metadata: Map<string, string>, refundApplicationFee: bool) =
        member _.amount = amount
        member _.description = description
        member _.expand = expand
        member _.metadata = metadata
        member _.refundApplicationFee = refundApplicationFee

    and PostTransfersTransferReversalsIdParams (expand: string list, metadata: Map<string, string>) =
        member _.expand = expand
        member _.metadata = metadata

    and PostSubscriptionItemsSubscriptionItemUsageRecordsParams (action: string, expand: string list, quantity: int, timestamp: int) =
        member _.action = action
        member _.expand = expand
        member _.quantity = quantity
        member _.timestamp = timestamp

    and PostWebhookEndpointsParams (apiVersion: string, connect: bool, description: string, enabledEvents: string list, expand: string list, metadata: Map<string, string>, url: string) =
        member _.apiVersion = apiVersion
        member _.connect = connect
        member _.description = description
        member _.enabledEvents = enabledEvents
        member _.expand = expand
        member _.metadata = metadata
        member _.url = url

    and PostWebhookEndpointsWebhookEndpointParams (description: string, disabled: bool, enabledEvents: string list, expand: string list, metadata: Map<string, string>, url: string) =
        member _.description = description
        member _.disabled = disabled
        member _.enabledEvents = enabledEvents
        member _.expand = expand
        member _.metadata = metadata
        member _.url = url

