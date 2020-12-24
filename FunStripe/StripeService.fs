namespace FunStripe

open FSharp.Json
open StripeModel
open StripeRequest

module StripeService =

    type AccountService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

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
        member this.Update ((parameters: PostAccountsAccountParams), account: string) =
            $"/v1/accounts/{account}"
            |> this.RestApiClient.PostAsync<_, Account> parameters

        ///<p>Returns a list of accounts connected to your platform via <a href="/docs/connect">Connect</a>. If you’re not a platform, the list is empty.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/accounts"
            |> this.RestApiClient.GetAsync<Account>

        ///<p>With <a href="/docs/connect">Connect</a>, you can create Stripe accounts for your users.
        ///To do this, you’ll first need to <a href="https://dashboard.stripe.com/account/applications/settings">register your platform</a>.</p>
        member this.Create ((parameters: PostAccountsParams)) =
            $"/v1/accounts"
            |> this.RestApiClient.PostAsync<_, Account> parameters

        ///<p>With <a href="/docs/connect">Connect</a>, you can delete Custom or Express accounts you manage.
        ///Accounts created using test-mode keys can be deleted at any time. Accounts created using live-mode keys can only be deleted once all balances are zero.
        ///If you want to delete your own account, use the <a href="https://dashboard.stripe.com/account">account information tab in your account settings</a> instead.</p>
        member this.Delete (account: string) =
            $"/v1/accounts/{account}"
            |> this.RestApiClient.DeleteAsync<DeletedAccount>

        ///<p>With <a href="/docs/connect">Connect</a>, you may flag accounts as suspicious.
        ///Test-mode Custom and Express accounts can be rejected at any time. Accounts created using live-mode keys may only be rejected once all balances are zero.</p>
        member this.Reject ((parameters: PostAccountsAccountRejectParams), account: string) =
            $"/v1/accounts/{account}/reject"
            |> this.RestApiClient.PostAsync<_, Account> parameters

        ///<p>Returns a list of capabilities associated with the account. The capabilities are returned sorted by creation date, with the most recent capability appearing first.</p>
        member this.Capabilities (account: string, ?expand: string list) =
            $"/v1/accounts/{account}/capabilities"
            |> this.RestApiClient.GetAsync<Capability>

    and AccountLinkService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Creates an AccountLink object that includes a single-use Stripe URL that the platform can redirect their user to in order to take them through the Connect Onboarding flow.</p>
        member this.Create ((parameters: PostAccountLinksParams)) =
            $"/v1/account_links"
            |> this.RestApiClient.PostAsync<_, AccountLink> parameters

    and ApplePayDomainService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>List apple pay domains.</p>
        member this.List (?domainName: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/apple_pay/domains"
            |> this.RestApiClient.GetAsync<ApplePayDomain>

        ///<p>Create an apple pay domain.</p>
        member this.Create ((parameters: PostApplePayDomainsParams)) =
            $"/v1/apple_pay/domains"
            |> this.RestApiClient.PostAsync<_, ApplePayDomain> parameters

        ///<p>Retrieve an apple pay domain.</p>
        member this.Retrieve (domain: string, ?expand: string list) =
            $"/v1/apple_pay/domains/{domain}"
            |> this.RestApiClient.GetAsync<ApplePayDomain>

        ///<p>Delete an apple pay domain.</p>
        member this.Delete (domain: string) =
            $"/v1/apple_pay/domains/{domain}"
            |> this.RestApiClient.DeleteAsync<DeletedApplePayDomain>

    and ApplicationFeeService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of application fees you’ve previously collected. The application fees are returned in sorted order, with the most recent fees appearing first.</p>
        member this.List (?charge: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/application_fees"
            |> this.RestApiClient.GetAsync<ApplicationFee>

        ///<p>Retrieves the details of an application fee that your account has collected. The same information is returned when refunding the application fee.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/application_fees/{id}"
            |> this.RestApiClient.GetAsync<ApplicationFee>

    and BalanceService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Retrieves the current account balance, based on the authentication that was used to make the request.
        /// For a sample request, see <a href="/docs/connect/account-balances#accounting-for-negative-balances">Accounting for negative balances</a>.</p>
        member this.Retrieve (?expand: string list) =
            $"/v1/balance"
            |> this.RestApiClient.GetAsync<Balance>

    and BalanceTransactionService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

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

    and BankAccountService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Update a specified source for a given customer.</p>
        member this.UpdateForCustomer ((parameters: PostCustomersCustomerSourcesIdParams), customer: string, id: string) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.PostAsync<_, Card> parameters

        ///<p>Delete a specified source for a given customer.</p>
        member this.DeleteForCustomer ((parameters: DeleteCustomersCustomerSourcesIdParams), customer: string, id: string) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.DeleteAsync<PaymentSource>

        ///<p>Verify a specified bank account for a given customer.</p>
        member this.VerifyForCustomer ((parameters: PostCustomersCustomerSourcesIdVerifyParams), customer: string, id: string) =
            $"/v1/customers/{customer}/sources/{id}/verify"
            |> this.RestApiClient.PostAsync<_, BankAccount> parameters

        ///<p>Updates the metadata, account holder name, and account holder type of a bank account belonging to a <a href="/docs/connect/custom-accounts">Custom account</a>, and optionally sets it as the default for its currency. Other bank account details are not editable by design.
        ///You can re-enable a disabled bank account by performing an update call without providing any arguments or changes.</p>
        member this.UpdateForAccount ((parameters: PostAccountsAccountExternalAccountsIdParams), account: string, id: string) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.PostAsync<_, ExternalAccount> parameters

        ///<p>Delete a specified external account for a given account.</p>
        member this.DeleteForAccount (account: string, id: string) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.DeleteAsync<DeletedExternalAccount>

    and BillingPortalSessionService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Creates a session of the customer portal.</p>
        member this.Create ((parameters: PostBillingPortalSessionsParams)) =
            $"/v1/billing_portal/sessions"
            |> this.RestApiClient.PostAsync<_, BillingPortalSession> parameters

    and BitcoinReceiverService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of your receivers. Receivers are returned sorted by creation date, with the most recently created receivers appearing first.</p>
        member this.List (?active: bool, ?endingBefore: string, ?expand: string list, ?filled: bool, ?limit: int, ?startingAfter: string, ?uncapturedFunds: bool) =
            $"/v1/bitcoin/receivers"
            |> this.RestApiClient.GetAsync<BitcoinReceiver>

        ///<p>Retrieves the Bitcoin receiver with the given ID.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/bitcoin/receivers/{id}"
            |> this.RestApiClient.GetAsync<BitcoinReceiver>

    and BitcoinTransactionService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>List bitcoin transacitons for a given receiver.</p>
        member this.List (receiver: string, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/bitcoin/receivers/{receiver}/transactions"
            |> this.RestApiClient.GetAsync<BitcoinTransaction>

    and CapabilityService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of capabilities associated with the account. The capabilities are returned sorted by creation date, with the most recent capability appearing first.</p>
        member this.ListForAccount (account: string, ?expand: string list) =
            $"/v1/accounts/{account}/capabilities"
            |> this.RestApiClient.GetAsync<Capability>

        ///<p>Retrieves information about the specified Account Capability.</p>
        member this.RetrieveForAccount (account: string, capability: string, ?expand: string list) =
            $"/v1/accounts/{account}/capabilities/{capability}"
            |> this.RestApiClient.GetAsync<Capability>

        ///<p>Updates an existing Account Capability.</p>
        member this.UpdateForAccount ((parameters: PostAccountsAccountCapabilitiesCapabilityParams), account: string, capability: string) =
            $"/v1/accounts/{account}/capabilities/{capability}"
            |> this.RestApiClient.PostAsync<_, Capability> parameters

    and CardService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Update a specified source for a given customer.</p>
        member this.UpdateForCustomer ((parameters: PostCustomersCustomerSourcesIdParams), customer: string, id: string) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.PostAsync<_, Card> parameters

        ///<p>Delete a specified source for a given customer.</p>
        member this.DeleteForCustomer ((parameters: DeleteCustomersCustomerSourcesIdParams), customer: string, id: string) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.DeleteAsync<PaymentSource>

        ///<p>Updates the metadata, account holder name, and account holder type of a bank account belonging to a <a href="/docs/connect/custom-accounts">Custom account</a>, and optionally sets it as the default for its currency. Other bank account details are not editable by design.
        ///You can re-enable a disabled bank account by performing an update call without providing any arguments or changes.</p>
        member this.UpdateForAccount ((parameters: PostAccountsAccountExternalAccountsIdParams), account: string, id: string) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.PostAsync<_, ExternalAccount> parameters

        ///<p>Delete a specified external account for a given account.</p>
        member this.DeleteForAccount (account: string, id: string) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.DeleteAsync<DeletedExternalAccount>

    and ChargeService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of charges you’ve previously created. The charges are returned in sorted order, with the most recent charges appearing first.</p>
        member this.List (?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string, ?transferGroup: string) =
            $"/v1/charges"
            |> this.RestApiClient.GetAsync<Charge>

        ///<p>To charge a credit card or other payment source, you create a <code>Charge</code> object. If your API key is in test mode, the supplied payment source (e.g., card) won’t actually be charged, although everything else will occur as if in live mode. (Stripe assumes that the charge would have completed successfully).</p>
        member this.Create ((parameters: PostChargesParams)) =
            $"/v1/charges"
            |> this.RestApiClient.PostAsync<_, Charge> parameters

        ///<p>Retrieves the details of a charge that has previously been created. Supply the unique charge ID that was returned from your previous request, and Stripe will return the corresponding charge information. The same information is returned when creating or refunding the charge.</p>
        member this.Retrieve (charge: string, ?expand: string list) =
            $"/v1/charges/{charge}"
            |> this.RestApiClient.GetAsync<Charge>

        ///<p>Updates the specified charge by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((parameters: PostChargesChargeParams), charge: string) =
            $"/v1/charges/{charge}"
            |> this.RestApiClient.PostAsync<_, Charge> parameters

        ///<p>Capture the payment of an existing, uncaptured, charge. This is the second half of the two-step payment flow, where first you <a href="#create_charge">created a charge</a> with the capture option set to false.
        ///Uncaptured payments expire exactly seven days after they are created. If they are not captured by that point in time, they will be marked as refunded and will no longer be capturable.</p>
        member this.Capture ((parameters: PostChargesChargeCaptureParams), charge: string) =
            $"/v1/charges/{charge}/capture"
            |> this.RestApiClient.PostAsync<_, Charge> parameters

    and CheckoutSessionService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of Checkout Sessions.</p>
        member this.List (?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string, ?subscription: string) =
            $"/v1/checkout/sessions"
            |> this.RestApiClient.GetAsync<CheckoutSession>

        ///<p>Retrieves a Session object.</p>
        member this.Retrieve (session: string, ?expand: string list) =
            $"/v1/checkout/sessions/{session}"
            |> this.RestApiClient.GetAsync<CheckoutSession>

        ///<p>Creates a Session object.</p>
        member this.Create ((parameters: PostCheckoutSessionsParams)) =
            $"/v1/checkout/sessions"
            |> this.RestApiClient.PostAsync<_, CheckoutSession> parameters

    and CountrySpecService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Lists all Country Spec objects available in the API.</p>
        member this.List (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/country_specs"
            |> this.RestApiClient.GetAsync<CountrySpec>

        ///<p>Returns a Country Spec for a given Country code.</p>
        member this.Retrieve (country: string, ?expand: string list) =
            $"/v1/country_specs/{country}"
            |> this.RestApiClient.GetAsync<CountrySpec>

    and CouponService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of your coupons.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/coupons"
            |> this.RestApiClient.GetAsync<Coupon>

        ///<p>You can create coupons easily via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. Coupon creation is also accessible via the API if you need to create coupons on the fly.
        ///A coupon has either a <code>percent_off</code> or an <code>amount_off</code> and <code>currency</code>. If you set an <code>amount_off</code>, that amount will be subtracted from any invoice’s subtotal. For example, an invoice with a subtotal of <currency>100</currency> will have a final total of <currency>0</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it and an invoice with a subtotal of <currency>300</currency> will have a final total of <currency>100</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it.</p>
        member this.Create ((parameters: PostCouponsParams)) =
            $"/v1/coupons"
            |> this.RestApiClient.PostAsync<_, Coupon> parameters

        ///<p>Retrieves the coupon with the given ID.</p>
        member this.Retrieve (coupon: string, ?expand: string list) =
            $"/v1/coupons/{coupon}"
            |> this.RestApiClient.GetAsync<Coupon>

        ///<p>Updates the metadata of a coupon. Other coupon details (currency, duration, amount_off) are, by design, not editable.</p>
        member this.Update ((parameters: PostCouponsCouponParams), coupon: string) =
            $"/v1/coupons/{coupon}"
            |> this.RestApiClient.PostAsync<_, Coupon> parameters

        ///<p>You can delete coupons via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. However, deleting a coupon does not affect any customers who have already applied the coupon; it means that new customers can’t redeem the coupon. You can also delete coupons via the API.</p>
        member this.Delete (coupon: string) =
            $"/v1/coupons/{coupon}"
            |> this.RestApiClient.DeleteAsync<DeletedCoupon>

    and CreditNoteService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

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
        member this.Create ((parameters: PostCreditNotesParams)) =
            $"/v1/credit_notes"
            |> this.RestApiClient.PostAsync<_, CreditNote> parameters

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
        member this.Update ((parameters: PostCreditNotesIdParams), id: string) =
            $"/v1/credit_notes/{id}"
            |> this.RestApiClient.PostAsync<_, CreditNote> parameters

        ///<p>Marks a credit note as void. Learn more about <a href="/docs/billing/invoices/credit-notes#voiding">voiding credit notes</a>.</p>
        member this.VoidCreditNote ((parameters: PostCreditNotesIdVoidParams), id: string) =
            $"/v1/credit_notes/{id}/void"
            |> this.RestApiClient.PostAsync<_, CreditNote> parameters

        ///<p>When retrieving a credit note preview, you’ll get a <strong>lines</strong> property containing the first handful of those items. This URL you can retrieve the full (paginated) list of line items.</p>
        member this.PreviewLines (invoice: string, ?amount: int, ?creditAmount: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?lines: string list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: string, ?refund: string, ?refundAmount: int, ?startingAfter: string) =
            $"/v1/credit_notes/preview/lines"
            |> this.RestApiClient.GetAsync<CreditNoteLineItem>

    and CreditNoteLineItemService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>When retrieving a credit note, you’ll get a <strong>lines</strong> property containing the the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
        member this.List (creditNote: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/credit_notes/{creditNote}/lines"
            |> this.RestApiClient.GetAsync<CreditNoteLineItem>

    and CustomerService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of your customers. The customers are returned sorted by creation date, with the most recent customers appearing first.</p>
        member this.List (?created: int, ?email: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/customers"
            |> this.RestApiClient.GetAsync<Customer>

        ///<p>Creates a new customer object.</p>
        member this.Create ((parameters: PostCustomersParams)) =
            $"/v1/customers"
            |> this.RestApiClient.PostAsync<_, Customer> parameters

        ///<p>Retrieves the details of an existing customer. You need only supply the unique customer identifier that was returned upon customer creation.</p>
        member this.Retrieve (customer: string, ?expand: string list) =
            $"/v1/customers/{customer}"
            |> this.RestApiClient.GetAsync<Customer>

        ///<p>Updates the specified customer by setting the values of the parameters passed. Any parameters not provided will be left unchanged. For example, if you pass the <strong>source</strong> parameter, that becomes the customer’s active source (e.g., a card) to be used for all charges in the future. When you update a customer to a new valid card source by passing the <strong>source</strong> parameter: for each of the customer’s current subscriptions, if the subscription bills automatically and is in the <code>past_due</code> state, then the latest open invoice for the subscription with automatic collection enabled will be retried. This retry will not count as an automatic retry, and will not affect the next regularly scheduled payment for the invoice. Changing the <strong>default_source</strong> for a customer will not trigger this behavior.
        ///This request accepts mostly the same arguments as the customer creation call.</p>
        member this.Update ((parameters: PostCustomersCustomerParams), customer: string) =
            $"/v1/customers/{customer}"
            |> this.RestApiClient.PostAsync<_, Customer> parameters

        ///<p>Permanently deletes a customer. It cannot be undone. Also immediately cancels any active subscriptions on the customer.</p>
        member this.Delete (customer: string) =
            $"/v1/customers/{customer}"
            |> this.RestApiClient.DeleteAsync<DeletedCustomer>

        ///<p>Removes the currently applied discount on a customer.</p>
        member this.DeleteDiscount (customer: string) =
            $"/v1/customers/{customer}/discount"
            |> this.RestApiClient.DeleteAsync<DeletedDiscount>

    and CustomerBalanceTransactionService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Retrieves a specific customer balance transaction that updated the customer’s <a href="/docs/billing/customer/balance">balances</a>.</p>
        member this.Retrieve (customer: string, transaction: string, ?expand: string list) =
            $"/v1/customers/{customer}/balance_transactions/{transaction}"
            |> this.RestApiClient.GetAsync<CustomerBalanceTransaction>

        ///<p>Returns a list of transactions that updated the customer’s <a href="/docs/billing/customer/balance">balances</a>.</p>
        member this.List (customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/customers/{customer}/balance_transactions"
            |> this.RestApiClient.GetAsync<CustomerBalanceTransaction>

        ///<p>Creates an immutable transaction that updates the customer’s credit <a href="/docs/billing/customer/balance">balance</a>.</p>
        member this.Create ((parameters: PostCustomersCustomerBalanceTransactionsParams), customer: string) =
            $"/v1/customers/{customer}/balance_transactions"
            |> this.RestApiClient.PostAsync<_, CustomerBalanceTransaction> parameters

        ///<p>Most credit balance transaction fields are immutable, but you may update its <code>description</code> and <code>metadata</code>.</p>
        member this.Update ((parameters: PostCustomersCustomerBalanceTransactionsTransactionParams), customer: string, transaction: string) =
            $"/v1/customers/{customer}/balance_transactions/{transaction}"
            |> this.RestApiClient.PostAsync<_, CustomerBalanceTransaction> parameters

    and DisputeService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

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
        member this.Update ((parameters: PostDisputesDisputeParams), dispute: string) =
            $"/v1/disputes/{dispute}"
            |> this.RestApiClient.PostAsync<_, Dispute> parameters

        ///<p>Closing the dispute for a charge indicates that you do not have any evidence to submit and are essentially dismissing the dispute, acknowledging it as lost.
        ///The status of the dispute will change from <code>needs_response</code> to <code>lost</code>. <em>Closing a dispute is irreversible</em>.</p>
        member this.Close ((parameters: PostDisputesDisputeCloseParams), dispute: string) =
            $"/v1/disputes/{dispute}/close"
            |> this.RestApiClient.PostAsync<_, Dispute> parameters

    and EphemeralKeyService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Creates a short-lived API key for a given resource.</p>
        member this.Create ((parameters: PostEphemeralKeysParams)) =
            $"/v1/ephemeral_keys"
            |> this.RestApiClient.PostAsync<_, EphemeralKey> parameters

        ///<p>Invalidates a short-lived API key for a given resource.</p>
        member this.Delete ((parameters: DeleteEphemeralKeysKeyParams), key: string) =
            $"/v1/ephemeral_keys/{key}"
            |> this.RestApiClient.DeleteAsync<EphemeralKey>

    and EventService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>List events, going back up to 30 days. Each event data is rendered according to Stripe API version at its creation time, specified in <a href="/docs/api/events/object">event object</a> <code>api_version</code> attribute (not according to your current Stripe API version or <code>Stripe-Version</code> header).</p>
        member this.List (?created: int, ?deliverySuccess: bool, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?``type``: string, ?types: string list) =
            $"/v1/events"
            |> this.RestApiClient.GetAsync<Event>

        ///<p>Retrieves the details of an event. Supply the unique identifier of the event, which you might have received in a webhook.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/events/{id}"
            |> this.RestApiClient.GetAsync<Event>

    and ExchangeRateService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of objects that contain the rates at which foreign currencies are converted to one another. Only shows the currencies for which Stripe supports.</p>
        member this.List (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/exchange_rates"
            |> this.RestApiClient.GetAsync<ExchangeRate>

        ///<p>Retrieves the exchange rates from the given currency to every supported currency.</p>
        member this.Retrieve (rateId: string, ?expand: string list) =
            $"/v1/exchange_rates/{rateId}"
            |> this.RestApiClient.GetAsync<ExchangeRate>

    and ExternalAccountService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>List external accounts for an account.</p>
        member this.ListForAccount (account: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/accounts/{account}/external_accounts"
            |> this.RestApiClient.GetAsync<ExternalAccount>

        ///<p>Retrieve a specified external account for a given account.</p>
        member this.RetrieveForAccount (account: string, id: string, ?expand: string list) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.GetAsync<ExternalAccount>

        ///<p>Create an external account for a given account.</p>
        member this.CreateForAccount ((parameters: PostAccountsAccountExternalAccountsParams), account: string) =
            $"/v1/accounts/{account}/external_accounts"
            |> this.RestApiClient.PostAsync<_, ExternalAccount> parameters

        ///<p>Updates the metadata, account holder name, and account holder type of a bank account belonging to a <a href="/docs/connect/custom-accounts">Custom account</a>, and optionally sets it as the default for its currency. Other bank account details are not editable by design.
        ///You can re-enable a disabled bank account by performing an update call without providing any arguments or changes.</p>
        member this.UpdateForAccount ((parameters: PostAccountsAccountExternalAccountsIdParams), account: string, id: string) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.PostAsync<_, ExternalAccount> parameters

        ///<p>Delete a specified external account for a given account.</p>
        member this.DeleteForAccount (account: string, id: string) =
            $"/v1/accounts/{account}/external_accounts/{id}"
            |> this.RestApiClient.DeleteAsync<DeletedExternalAccount>

    and FeeRefundService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Refunds an application fee that has previously been collected but not yet refunded.
        ///Funds will be refunded to the Stripe account from which the fee was originally collected.
        ///You can optionally refund only part of an application fee.
        ///You can do so multiple times, until the entire fee has been refunded.
        ///Once entirely refunded, an application fee can’t be refunded again.
        ///This method will raise an error when called on an already-refunded application fee,
        ///or when trying to refund more money than is left on an application fee.</p>
        member this.CreateForApplicationFee ((parameters: PostApplicationFeesIdRefundsParams), id: string) =
            $"/v1/application_fees/{id}/refunds"
            |> this.RestApiClient.PostAsync<_, FeeRefund> parameters

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
        member this.UpdateForApplicationFee ((parameters: PostApplicationFeesFeeRefundsIdParams), fee: string, id: string) =
            $"/v1/application_fees/{fee}/refunds/{id}"
            |> this.RestApiClient.PostAsync<_, FeeRefund> parameters

    and FileService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

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

    and FileLinkService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Retrieves the file link with the given ID.</p>
        member this.Retrieve (link: string, ?expand: string list) =
            $"/v1/file_links/{link}"
            |> this.RestApiClient.GetAsync<FileLink>

        ///<p>Creates a new file link object.</p>
        member this.Create ((parameters: PostFileLinksParams)) =
            $"/v1/file_links"
            |> this.RestApiClient.PostAsync<_, FileLink> parameters

        ///<p>Updates an existing file link object. Expired links can no longer be updated.</p>
        member this.Update ((parameters: PostFileLinksLinkParams), link: string) =
            $"/v1/file_links/{link}"
            |> this.RestApiClient.PostAsync<_, FileLink> parameters

        ///<p>Returns a list of file links.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?expired: bool, ?file: string, ?limit: int, ?startingAfter: string) =
            $"/v1/file_links"
            |> this.RestApiClient.GetAsync<FileLink>

    and InvoiceService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

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
        member this.Create ((parameters: PostInvoicesParams)) =
            $"/v1/invoices"
            |> this.RestApiClient.PostAsync<_, Invoice> parameters

        ///<p>Retrieves the invoice with the given ID.</p>
        member this.Retrieve (invoice: string, ?expand: string list) =
            $"/v1/invoices/{invoice}"
            |> this.RestApiClient.GetAsync<Invoice>

        ///<p>Draft invoices are fully editable. Once an invoice is <a href="/docs/billing/invoices/workflow#finalized">finalized</a>,
        ///monetary values, as well as <code>collection_method</code>, become uneditable.
        ///If you would like to stop the Stripe Billing engine from automatically finalizing, reattempting payments on,
        ///sending reminders for, or <a href="/docs/billing/invoices/reconciliation">automatically reconciling</a> invoices, pass
        ///<code>auto_advance=false</code>.</p>
        member this.Update ((parameters: PostInvoicesInvoiceParams), invoice: string) =
            $"/v1/invoices/{invoice}"
            |> this.RestApiClient.PostAsync<_, Invoice> parameters

        ///<p>Permanently deletes a one-off invoice draft. This cannot be undone. Attempts to delete invoices that are no longer in a draft state will fail; once an invoice has been finalized or if an invoice is for a subscription, it must be <a href="#void_invoice">voided</a>.</p>
        member this.Delete (invoice: string) =
            $"/v1/invoices/{invoice}"
            |> this.RestApiClient.DeleteAsync<DeletedInvoice>

        ///<p>Stripe automatically creates and then attempts to collect payment on invoices for customers on subscriptions according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to attempt payment on an invoice out of the normal collection schedule or for some other reason, you can do so.</p>
        member this.Pay ((parameters: PostInvoicesInvoicePayParams), invoice: string) =
            $"/v1/invoices/{invoice}/pay"
            |> this.RestApiClient.PostAsync<_, Invoice> parameters

        ///<p>Stripe automatically finalizes drafts before sending and attempting payment on invoices. However, if you’d like to finalize a draft invoice manually, you can do so using this method.</p>
        member this.FinalizeInvoice ((parameters: PostInvoicesInvoiceFinalizeParams), invoice: string) =
            $"/v1/invoices/{invoice}/finalize"
            |> this.RestApiClient.PostAsync<_, Invoice> parameters

        ///<p>When retrieving an upcoming invoice, you’ll get a <strong>lines</strong> property containing the total count of line items and the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
        member this.UpcomingLines (?coupon: string, ?subscriptionStartDate: int, ?subscriptionProrationDate: int, ?subscriptionProrationBehavior: string, ?subscriptionItems: string list, ?subscriptionDefaultTaxRates: string list, ?subscriptionCancelNow: bool, ?subscriptionCancelAtPeriodEnd: bool, ?subscriptionCancelAt: int, ?subscriptionTrialEnd: string, ?subscriptionBillingCycleAnchor: string, ?startingAfter: string, ?schedule: string, ?limit: int, ?invoiceItems: string list, ?expand: string list, ?endingBefore: string, ?discounts: string list, ?customer: string, ?subscription: string, ?subscriptionTrialFromPlan: bool) =
            $"/v1/invoices/upcoming/lines"
            |> this.RestApiClient.GetAsync<LineItem>

        ///<p>Stripe will automatically send invoices to customers according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to manually send an invoice to your customer out of the normal schedule, you can do so. When sending invoices that have already been paid, there will be no reference to the payment in the email.
        ///Requests made in test-mode result in no emails being sent, despite sending an <code>invoice.sent</code> event.</p>
        member this.SendInvoice ((parameters: PostInvoicesInvoiceSendParams), invoice: string) =
            $"/v1/invoices/{invoice}/send"
            |> this.RestApiClient.PostAsync<_, Invoice> parameters

        ///<p>Marking an invoice as uncollectible is useful for keeping track of bad debts that can be written off for accounting purposes.</p>
        member this.MarkUncollectible ((parameters: PostInvoicesInvoiceMarkUncollectibleParams), invoice: string) =
            $"/v1/invoices/{invoice}/mark_uncollectible"
            |> this.RestApiClient.PostAsync<_, Invoice> parameters

        ///<p>Mark a finalized invoice as void. This cannot be undone. Voiding an invoice is similar to <a href="#delete_invoice">deletion</a>, however it only applies to finalized invoices and maintains a papertrail where the invoice can still be found.</p>
        member this.VoidInvoice ((parameters: PostInvoicesInvoiceVoidParams), invoice: string) =
            $"/v1/invoices/{invoice}/void"
            |> this.RestApiClient.PostAsync<_, Invoice> parameters

    and InvoiceitemService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of your invoice items. Invoice items are returned sorted by creation date, with the most recently created invoice items appearing first.</p>
        member this.List (?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?invoice: string, ?limit: int, ?pending: bool, ?startingAfter: string) =
            $"/v1/invoiceitems"
            |> this.RestApiClient.GetAsync<Invoiceitem>

        ///<p>Creates an item to be added to a draft invoice (up to 250 items per invoice). If no invoice is specified, the item will be on the next invoice created for the customer specified.</p>
        member this.Create ((parameters: PostInvoiceitemsParams)) =
            $"/v1/invoiceitems"
            |> this.RestApiClient.PostAsync<_, Invoiceitem> parameters

        ///<p>Retrieves the invoice item with the given ID.</p>
        member this.Retrieve (invoiceitem: string, ?expand: string list) =
            $"/v1/invoiceitems/{invoiceitem}"
            |> this.RestApiClient.GetAsync<Invoiceitem>

        ///<p>Updates the amount or description of an invoice item on an upcoming invoice. Updating an invoice item is only possible before the invoice it’s attached to is closed.</p>
        member this.Update ((parameters: PostInvoiceitemsInvoiceitemParams), invoiceitem: string) =
            $"/v1/invoiceitems/{invoiceitem}"
            |> this.RestApiClient.PostAsync<_, Invoiceitem> parameters

        ///<p>Deletes an invoice item, removing it from an invoice. Deleting invoice items is only possible when they’re not attached to invoices, or if it’s attached to a draft invoice.</p>
        member this.Delete (invoiceitem: string) =
            $"/v1/invoiceitems/{invoiceitem}"
            |> this.RestApiClient.DeleteAsync<DeletedInvoiceitem>

    and IssuerFraudRecordService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of issuer fraud records.</p>
        member this.List (?charge: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/issuer_fraud_records"
            |> this.RestApiClient.GetAsync<IssuerFraudRecord>

        ///<p>Retrieves the details of an issuer fraud record that has previously been created. 
        ///Please refer to the <a href="#issuer_fraud_record_object">issuer fraud record</a> object reference for more details.</p>
        member this.Retrieve (issuerFraudRecord: string, ?expand: string list) =
            $"/v1/issuer_fraud_records/{issuerFraudRecord}"
            |> this.RestApiClient.GetAsync<IssuerFraudRecord>

    and IssuingAuthorizationService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of Issuing <code>Authorization</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?card: string, ?cardholder: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            $"/v1/issuing/authorizations"
            |> this.RestApiClient.GetAsync<IssuingAuthorization>

        ///<p>Retrieves an Issuing <code>Authorization</code> object.</p>
        member this.Retrieve (authorization: string, ?expand: string list) =
            $"/v1/issuing/authorizations/{authorization}"
            |> this.RestApiClient.GetAsync<IssuingAuthorization>

        ///<p>Updates the specified Issuing <code>Authorization</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((parameters: PostIssuingAuthorizationsAuthorizationParams), authorization: string) =
            $"/v1/issuing/authorizations/{authorization}"
            |> this.RestApiClient.PostAsync<_, IssuingAuthorization> parameters

        ///<p>Approves a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real-time authorization</a> flow.</p>
        member this.Approve ((parameters: PostIssuingAuthorizationsAuthorizationApproveParams), authorization: string) =
            $"/v1/issuing/authorizations/{authorization}/approve"
            |> this.RestApiClient.PostAsync<_, IssuingAuthorization> parameters

        ///<p>Declines a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real time authorization</a> flow.</p>
        member this.Decline ((parameters: PostIssuingAuthorizationsAuthorizationDeclineParams), authorization: string) =
            $"/v1/issuing/authorizations/{authorization}/decline"
            |> this.RestApiClient.PostAsync<_, IssuingAuthorization> parameters

    and IssuingCardService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of Issuing <code>Card</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?cardholder: string, ?created: int, ?endingBefore: string, ?expMonth: int, ?expYear: int, ?expand: string list, ?last4: string, ?limit: int, ?startingAfter: string, ?status: string, ?``type``: string) =
            $"/v1/issuing/cards"
            |> this.RestApiClient.GetAsync<IssuingCard>

        ///<p>Creates an Issuing <code>Card</code> object.</p>
        member this.Create ((parameters: PostIssuingCardsParams)) =
            $"/v1/issuing/cards"
            |> this.RestApiClient.PostAsync<_, IssuingCard> parameters

        ///<p>Retrieves an Issuing <code>Card</code> object.</p>
        member this.Retrieve (card: string, ?expand: string list) =
            $"/v1/issuing/cards/{card}"
            |> this.RestApiClient.GetAsync<IssuingCard>

        ///<p>Updates the specified Issuing <code>Card</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((parameters: PostIssuingCardsCardParams), card: string) =
            $"/v1/issuing/cards/{card}"
            |> this.RestApiClient.PostAsync<_, IssuingCard> parameters

    and IssuingCardholderService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of Issuing <code>Cardholder</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?created: int, ?email: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?phoneNumber: string, ?startingAfter: string, ?status: string, ?``type``: string) =
            $"/v1/issuing/cardholders"
            |> this.RestApiClient.GetAsync<IssuingCardholder>

        ///<p>Creates a new Issuing <code>Cardholder</code> object that can be issued cards.</p>
        member this.Create ((parameters: PostIssuingCardholdersParams)) =
            $"/v1/issuing/cardholders"
            |> this.RestApiClient.PostAsync<_, IssuingCardholder> parameters

        ///<p>Retrieves an Issuing <code>Cardholder</code> object.</p>
        member this.Retrieve (cardholder: string, ?expand: string list) =
            $"/v1/issuing/cardholders/{cardholder}"
            |> this.RestApiClient.GetAsync<IssuingCardholder>

        ///<p>Updates the specified Issuing <code>Cardholder</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((parameters: PostIssuingCardholdersCardholderParams), cardholder: string) =
            $"/v1/issuing/cardholders/{cardholder}"
            |> this.RestApiClient.PostAsync<_, IssuingCardholder> parameters

    and IssuingDisputeService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of Issuing <code>Dispute</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string, ?transaction: string) =
            $"/v1/issuing/disputes"
            |> this.RestApiClient.GetAsync<IssuingDispute>

        ///<p>Creates an Issuing <code>Dispute</code> object. Individual pieces of evidence within the <code>evidence</code> object are optional at this point. Stripe only validates that required evidence is present during submission. Refer to <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a> for more details about evidence requirements.</p>
        member this.Create ((parameters: PostIssuingDisputesParams)) =
            $"/v1/issuing/disputes"
            |> this.RestApiClient.PostAsync<_, IssuingDispute> parameters

        ///<p>Updates the specified Issuing <code>Dispute</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Properties on the <code>evidence</code> object can be unset by passing in an empty string.</p>
        member this.Update ((parameters: PostIssuingDisputesDisputeParams), dispute: string) =
            $"/v1/issuing/disputes/{dispute}"
            |> this.RestApiClient.PostAsync<_, IssuingDispute> parameters

        ///<p>Retrieves an Issuing <code>Dispute</code> object.</p>
        member this.Retrieve (dispute: string, ?expand: string list) =
            $"/v1/issuing/disputes/{dispute}"
            |> this.RestApiClient.GetAsync<IssuingDispute>

        ///<p>Submits an Issuing <code>Dispute</code> to the card network. Stripe validates that all evidence fields required for the dispute’s reason are present. For more details, see <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a>.</p>
        member this.Submit ((parameters: PostIssuingDisputesDisputeSubmitParams), dispute: string) =
            $"/v1/issuing/disputes/{dispute}/submit"
            |> this.RestApiClient.PostAsync<_, IssuingDispute> parameters

    and IssuingTransactionService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of Issuing <code>Transaction</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?card: string, ?cardholder: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/issuing/transactions"
            |> this.RestApiClient.GetAsync<IssuingTransaction>

        ///<p>Retrieves an Issuing <code>Transaction</code> object.</p>
        member this.Retrieve (transaction: string, ?expand: string list) =
            $"/v1/issuing/transactions/{transaction}"
            |> this.RestApiClient.GetAsync<IssuingTransaction>

        ///<p>Updates the specified Issuing <code>Transaction</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((parameters: PostIssuingTransactionsTransactionParams), transaction: string) =
            $"/v1/issuing/transactions/{transaction}"
            |> this.RestApiClient.PostAsync<_, IssuingTransaction> parameters

    and ItemService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>When retrieving a Checkout Session, there is an includable <strong>line_items</strong> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
        member this.ListForCheckout (session: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/checkout/sessions/{session}/line_items"
            |> this.RestApiClient.GetAsync<Item>

    and LineItemService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>When retrieving an invoice, you’ll get a <strong>lines</strong> property containing the total count of line items and the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
        member this.ListForInvoice (invoice: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/invoices/{invoice}/lines"
            |> this.RestApiClient.GetAsync<LineItem>

    and LoginLinkService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Creates a single-use login link for an Express account to access their Stripe dashboard.
        ///<strong>You may only create login links for <a href="/docs/connect/express-accounts">Express accounts</a> connected to your platform</strong>.</p>
        member this.CreateForAccount ((parameters: PostAccountsAccountLoginLinksParams), account: string) =
            $"/v1/accounts/{account}/login_links"
            |> this.RestApiClient.PostAsync<_, LoginLink> parameters

    and MandateService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Retrieves a Mandate object.</p>
        member this.Retrieve (mandate: string, ?expand: string list) =
            $"/v1/mandates/{mandate}"
            |> this.RestApiClient.GetAsync<Mandate>

    and OrderService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Creates a new order object.</p>
        member this.Create ((parameters: PostOrdersParams)) =
            $"/v1/orders"
            |> this.RestApiClient.PostAsync<_, Order> parameters

        ///<p>Returns a list of your orders. The orders are returned sorted by creation date, with the most recently created orders appearing first.</p>
        member this.List (?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?ids: string list, ?limit: int, ?startingAfter: string, ?status: string, ?statusTransitions: Map<string, string>, ?upstreamIds: string list) =
            $"/v1/orders"
            |> this.RestApiClient.GetAsync<Order>

        ///<p>Retrieves the details of an existing order. Supply the unique order ID from either an order creation request or the order list, and Stripe will return the corresponding order information.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/orders/{id}"
            |> this.RestApiClient.GetAsync<Order>

        ///<p>Updates the specific order by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((parameters: PostOrdersIdParams), id: string) =
            $"/v1/orders/{id}"
            |> this.RestApiClient.PostAsync<_, Order> parameters

        ///<p>Pay an order by providing a <code>source</code> to create a payment.</p>
        member this.Pay ((parameters: PostOrdersIdPayParams), id: string) =
            $"/v1/orders/{id}/pay"
            |> this.RestApiClient.PostAsync<_, Order> parameters

        ///<p>Return all or part of an order. The order must have a status of <code>paid</code> or <code>fulfilled</code> before it can be returned. Once all items have been returned, the order will become <code>canceled</code> or <code>returned</code> depending on which status the order started in.</p>
        member this.ReturnOrder ((parameters: PostOrdersIdReturnsParams), id: string) =
            $"/v1/orders/{id}/returns"
            |> this.RestApiClient.PostAsync<_, OrderReturn> parameters

    and OrderReturnService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of your order returns. The returns are returned sorted by creation date, with the most recently created return appearing first.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?order: string, ?startingAfter: string) =
            $"/v1/order_returns"
            |> this.RestApiClient.GetAsync<OrderReturn>

        ///<p>Retrieves the details of an existing order return. Supply the unique order ID from either an order return creation request or the order return list, and Stripe will return the corresponding order information.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/order_returns/{id}"
            |> this.RestApiClient.GetAsync<OrderReturn>

    and PaymentIntentService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Creates a PaymentIntent object.
        ///After the PaymentIntent is created, attach a payment method and <a href="/docs/api/payment_intents/confirm">confirm</a>
        ///to continue the payment. You can read more about the different payment flows
        ///available via the Payment Intents API <a href="/docs/payments/payment-intents">here</a>.
        ///When <code>confirm=true</code> is used during creation, it is equivalent to creating
        ///and confirming the PaymentIntent in the same call. You may use any parameters
        ///available in the <a href="/docs/api/payment_intents/confirm">confirm API</a> when <code>confirm=true</code>
        ///is supplied.</p>
        member this.Create ((parameters: PostPaymentIntentsParams)) =
            $"/v1/payment_intents"
            |> this.RestApiClient.PostAsync<_, PaymentIntent> parameters

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
        member this.Update ((parameters: PostPaymentIntentsIntentParams), intent: string) =
            $"/v1/payment_intents/{intent}"
            |> this.RestApiClient.PostAsync<_, PaymentIntent> parameters

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
        member this.Confirm ((parameters: PostPaymentIntentsIntentConfirmParams), intent: string) =
            $"/v1/payment_intents/{intent}/confirm"
            |> this.RestApiClient.PostAsync<_, PaymentIntent> parameters

        ///<p>A PaymentIntent object can be canceled when it is in one of these statuses: <code>requires_payment_method</code>, <code>requires_capture</code>, <code>requires_confirmation</code>, or <code>requires_action</code>. 
        ///Once canceled, no additional charges will be made by the PaymentIntent and any operations on the PaymentIntent will fail with an error. For PaymentIntents with <code>status=’requires_capture’</code>, the remaining <code>amount_capturable</code> will automatically be refunded.</p>
        member this.Cancel ((parameters: PostPaymentIntentsIntentCancelParams), intent: string) =
            $"/v1/payment_intents/{intent}/cancel"
            |> this.RestApiClient.PostAsync<_, PaymentIntent> parameters

        ///<p>Capture the funds of an existing uncaptured PaymentIntent when its status is <code>requires_capture</code>.
        ///Uncaptured PaymentIntents will be canceled exactly seven days after they are created.
        ///Learn more about <a href="/docs/payments/capture-later">separate authorization and capture</a>.</p>
        member this.Capture ((parameters: PostPaymentIntentsIntentCaptureParams), intent: string) =
            $"/v1/payment_intents/{intent}/capture"
            |> this.RestApiClient.PostAsync<_, PaymentIntent> parameters

    and PaymentMethodService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Creates a PaymentMethod object. Read the <a href="/docs/stripe-js/reference#stripe-create-payment-method">Stripe.js reference</a> to learn how to create PaymentMethods via Stripe.js.</p>
        member this.Create ((parameters: PostPaymentMethodsParams)) =
            $"/v1/payment_methods"
            |> this.RestApiClient.PostAsync<_, PaymentMethod> parameters

        ///<p>Retrieves a PaymentMethod object.</p>
        member this.Retrieve (paymentMethod: string, ?expand: string list) =
            $"/v1/payment_methods/{paymentMethod}"
            |> this.RestApiClient.GetAsync<PaymentMethod>

        ///<p>Updates a PaymentMethod object. A PaymentMethod must be attached a customer to be updated.</p>
        member this.Update ((parameters: PostPaymentMethodsPaymentMethodParams), paymentMethod: string) =
            $"/v1/payment_methods/{paymentMethod}"
            |> this.RestApiClient.PostAsync<_, PaymentMethod> parameters

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
        member this.Attach ((parameters: PostPaymentMethodsPaymentMethodAttachParams), paymentMethod: string) =
            $"/v1/payment_methods/{paymentMethod}/attach"
            |> this.RestApiClient.PostAsync<_, PaymentMethod> parameters

        ///<p>Detaches a PaymentMethod object from a Customer.</p>
        member this.Detach ((parameters: PostPaymentMethodsPaymentMethodDetachParams), paymentMethod: string) =
            $"/v1/payment_methods/{paymentMethod}/detach"
            |> this.RestApiClient.PostAsync<_, PaymentMethod> parameters

    and PaymentSourceService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

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
        member this.CreateForCustomer ((parameters: PostCustomersCustomerSourcesParams), customer: string) =
            $"/v1/customers/{customer}/sources"
            |> this.RestApiClient.PostAsync<_, PaymentSource> parameters

    and PayoutService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

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
        member this.Create ((parameters: PostPayoutsParams)) =
            $"/v1/payouts"
            |> this.RestApiClient.PostAsync<_, Payout> parameters

        ///<p>Updates the specified payout by setting the values of the parameters passed. Any parameters not provided will be left unchanged. This request accepts only the metadata as arguments.</p>
        member this.Update ((parameters: PostPayoutsPayoutParams), payout: string) =
            $"/v1/payouts/{payout}"
            |> this.RestApiClient.PostAsync<_, Payout> parameters

        ///<p>A previously created payout can be canceled if it has not yet been paid out. Funds will be refunded to your available balance. You may not cancel automatic Stripe payouts.</p>
        member this.Cancel ((parameters: PostPayoutsPayoutCancelParams), payout: string) =
            $"/v1/payouts/{payout}/cancel"
            |> this.RestApiClient.PostAsync<_, Payout> parameters

        ///<p>Reverses a payout by debiting the destination bank account. Only payouts for connected accounts to US bank accounts may be reversed at this time. If the payout is in the <code>pending</code> status, <code>/v1/payouts/:id/cancel</code> should be used instead.
        ///By requesting a reversal via <code>/v1/payouts/:id/reverse</code>, you confirm that the authorized signatory of the selected bank account has authorized the debit on the bank account and that no other authorization is required.</p>
        member this.Reverse ((parameters: PostPayoutsPayoutReverseParams), payout: string) =
            $"/v1/payouts/{payout}/reverse"
            |> this.RestApiClient.PostAsync<_, Payout> parameters

    and PersonService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of people associated with the account’s legal entity. The people are returned sorted by creation date, with the most recent people appearing first.</p>
        member this.ListForAccount (account: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?relationship: Map<string, string>, ?startingAfter: string) =
            $"/v1/accounts/{account}/persons"
            |> this.RestApiClient.GetAsync<Person>

        ///<p>Retrieves an existing person.</p>
        member this.RetrieveForAccount (account: string, person: string, ?expand: string list) =
            $"/v1/accounts/{account}/persons/{person}"
            |> this.RestApiClient.GetAsync<Person>

        ///<p>Creates a new person.</p>
        member this.CreateForAccount ((parameters: PostAccountsAccountPersonsParams), account: string) =
            $"/v1/accounts/{account}/persons"
            |> this.RestApiClient.PostAsync<_, Person> parameters

        ///<p>Updates an existing person.</p>
        member this.UpdateForAccount ((parameters: PostAccountsAccountPersonsPersonParams), account: string, person: string) =
            $"/v1/accounts/{account}/persons/{person}"
            |> this.RestApiClient.PostAsync<_, Person> parameters

        ///<p>Deletes an existing person’s relationship to the account’s legal entity. Any person with a relationship for an account can be deleted through the API, except if the person is the <code>account_opener</code>. If your integration is using the <code>executive</code> parameter, you cannot delete the only verified <code>executive</code> on file.</p>
        member this.DeleteForAccount (account: string, person: string) =
            $"/v1/accounts/{account}/persons/{person}"
            |> this.RestApiClient.DeleteAsync<DeletedPerson>

    and PlanService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of your plans.</p>
        member this.List (?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?product: string, ?startingAfter: string) =
            $"/v1/plans"
            |> this.RestApiClient.GetAsync<Plan>

        ///<p>You can now model subscriptions more flexibly using the <a href="#prices">Prices API</a>. It replaces the Plans API and is backwards compatible to simplify your migration.</p>
        member this.Create ((parameters: PostPlansParams)) =
            $"/v1/plans"
            |> this.RestApiClient.PostAsync<_, Plan> parameters

        ///<p>Retrieves the plan with the given ID.</p>
        member this.Retrieve (plan: string, ?expand: string list) =
            $"/v1/plans/{plan}"
            |> this.RestApiClient.GetAsync<Plan>

        ///<p>Updates the specified plan by setting the values of the parameters passed. Any parameters not provided are left unchanged. By design, you cannot change a plan’s ID, amount, currency, or billing cycle.</p>
        member this.Update ((parameters: PostPlansPlanParams), plan: string) =
            $"/v1/plans/{plan}"
            |> this.RestApiClient.PostAsync<_, Plan> parameters

        ///<p>Deleting plans means new subscribers can’t be added. Existing subscribers aren’t affected.</p>
        member this.Delete (plan: string) =
            $"/v1/plans/{plan}"
            |> this.RestApiClient.DeleteAsync<DeletedPlan>

    and PriceService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of your prices.</p>
        member this.List (?active: bool, ?created: int, ?currency: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?lookupKeys: string list, ?product: string, ?recurring: Map<string, string>, ?startingAfter: string, ?``type``: string) =
            $"/v1/prices"
            |> this.RestApiClient.GetAsync<Price>

        ///<p>Creates a new price for an existing product. The price can be recurring or one-time.</p>
        member this.Create ((parameters: PostPricesParams)) =
            $"/v1/prices"
            |> this.RestApiClient.PostAsync<_, Price> parameters

        ///<p>Retrieves the price with the given ID.</p>
        member this.Retrieve (price: string, ?expand: string list) =
            $"/v1/prices/{price}"
            |> this.RestApiClient.GetAsync<Price>

        ///<p>Updates the specified price by setting the values of the parameters passed. Any parameters not provided are left unchanged.</p>
        member this.Update ((parameters: PostPricesPriceParams), price: string) =
            $"/v1/prices/{price}"
            |> this.RestApiClient.PostAsync<_, Price> parameters

    and ProductService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Creates a new product object.</p>
        member this.Create ((parameters: PostProductsParams)) =
            $"/v1/products"
            |> this.RestApiClient.PostAsync<_, Product> parameters

        ///<p>Retrieves the details of an existing product. Supply the unique product ID from either a product creation request or the product list, and Stripe will return the corresponding product information.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/products/{id}"
            |> this.RestApiClient.GetAsync<Product>

        ///<p>Updates the specific product by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((parameters: PostProductsIdParams), id: string) =
            $"/v1/products/{id}"
            |> this.RestApiClient.PostAsync<_, Product> parameters

        ///<p>Returns a list of your products. The products are returned sorted by creation date, with the most recently created products appearing first.</p>
        member this.List (?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?ids: string list, ?limit: int, ?shippable: bool, ?startingAfter: string, ?``type``: string, ?url: string) =
            $"/v1/products"
            |> this.RestApiClient.GetAsync<Product>

        ///<p>Delete a product. Deleting a product is only possible if it has no prices associated with it. Additionally, deleting a product with <code>type=good</code> is only possible if it has no SKUs associated with it.</p>
        member this.Delete (id: string) =
            $"/v1/products/{id}"
            |> this.RestApiClient.DeleteAsync<DeletedProduct>

    and PromotionCodeService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Retrieves the promotion code with the given ID.</p>
        member this.Retrieve (promotionCode: string, ?expand: string list) =
            $"/v1/promotion_codes/{promotionCode}"
            |> this.RestApiClient.GetAsync<PromotionCode>

        ///<p>A promotion code points to a coupon. You can optionally restrict the code to a specific customer, redemption limit, and expiration date.</p>
        member this.Create ((parameters: PostPromotionCodesParams)) =
            $"/v1/promotion_codes"
            |> this.RestApiClient.PostAsync<_, PromotionCode> parameters

        ///<p>Updates the specified promotion code by setting the values of the parameters passed. Most fields are, by design, not editable.</p>
        member this.Update ((parameters: PostPromotionCodesPromotionCodeParams), promotionCode: string) =
            $"/v1/promotion_codes/{promotionCode}"
            |> this.RestApiClient.PostAsync<_, PromotionCode> parameters

        ///<p>Returns a list of your promotion codes.</p>
        member this.List (?active: bool, ?code: string, ?coupon: string, ?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/promotion_codes"
            |> this.RestApiClient.GetAsync<PromotionCode>

    and RadarEarlyFraudWarningService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of early fraud warnings.</p>
        member this.List (?charge: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/radar/early_fraud_warnings"
            |> this.RestApiClient.GetAsync<RadarEarlyFraudWarning>

        ///<p>Retrieves the details of an early fraud warning that has previously been created. 
        ///Please refer to the <a href="#early_fraud_warning_object">early fraud warning</a> object reference for more details.</p>
        member this.Retrieve (earlyFraudWarning: string, ?expand: string list) =
            $"/v1/radar/early_fraud_warnings/{earlyFraudWarning}"
            |> this.RestApiClient.GetAsync<RadarEarlyFraudWarning>

    and RadarValueListService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of <code>ValueList</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?alias: string, ?contains: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/radar/value_lists"
            |> this.RestApiClient.GetAsync<RadarValueList>

        ///<p>Retrieves a <code>ValueList</code> object.</p>
        member this.Retrieve (valueList: string, ?expand: string list) =
            $"/v1/radar/value_lists/{valueList}"
            |> this.RestApiClient.GetAsync<RadarValueList>

        ///<p>Creates a new <code>ValueList</code> object, which can then be referenced in rules.</p>
        member this.Create ((parameters: PostRadarValueListsParams)) =
            $"/v1/radar/value_lists"
            |> this.RestApiClient.PostAsync<_, RadarValueList> parameters

        ///<p>Updates a <code>ValueList</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Note that <code>item_type</code> is immutable.</p>
        member this.Update ((parameters: PostRadarValueListsValueListParams), valueList: string) =
            $"/v1/radar/value_lists/{valueList}"
            |> this.RestApiClient.PostAsync<_, RadarValueList> parameters

        ///<p>Deletes a <code>ValueList</code> object, also deleting any items contained within the value list. To be deleted, a value list must not be referenced in any rules.</p>
        member this.Delete (valueList: string) =
            $"/v1/radar/value_lists/{valueList}"
            |> this.RestApiClient.DeleteAsync<DeletedRadarValueList>

    and RadarValueListItemService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of <code>ValueListItem</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (valueList: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?value: string) =
            $"/v1/radar/value_list_items"
            |> this.RestApiClient.GetAsync<RadarValueListItem>

        ///<p>Retrieves a <code>ValueListItem</code> object.</p>
        member this.Retrieve (item: string, ?expand: string list) =
            $"/v1/radar/value_list_items/{item}"
            |> this.RestApiClient.GetAsync<RadarValueListItem>

        ///<p>Creates a new <code>ValueListItem</code> object, which is added to the specified parent value list.</p>
        member this.Create ((parameters: PostRadarValueListItemsParams)) =
            $"/v1/radar/value_list_items"
            |> this.RestApiClient.PostAsync<_, RadarValueListItem> parameters

        ///<p>Deletes a <code>ValueListItem</code> object, removing it from its parent value list.</p>
        member this.Delete (item: string) =
            $"/v1/radar/value_list_items/{item}"
            |> this.RestApiClient.DeleteAsync<DeletedRadarValueListItem>

    and RecipientService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of your recipients. The recipients are returned sorted by creation date, with the most recently created recipients appearing first.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?``type``: string, ?verified: bool) =
            $"/v1/recipients"
            |> this.RestApiClient.GetAsync<Recipient>

        ///<p>Creates a new <code>Recipient</code> object and verifies the recipient’s identity.
        ///Also verifies the recipient’s bank account information or debit card, if either is provided.</p>
        member this.Create ((parameters: PostRecipientsParams)) =
            $"/v1/recipients"
            |> this.RestApiClient.PostAsync<_, Recipient> parameters

        ///<p>Retrieves the details of an existing recipient. You need only supply the unique recipient identifier that was returned upon recipient creation.</p>
        member this.Retrieve (id: string, ?expand: string list) =
            $"/v1/recipients/{id}"
            |> this.RestApiClient.GetAsync<Recipient>

        ///<p>Updates the specified recipient by setting the values of the parameters passed.
        ///Any parameters not provided will be left unchanged.
        ///If you update the name or tax ID, the identity verification will automatically be rerun.
        ///If you update the bank account, the bank account validation will automatically be rerun.</p>
        member this.Update ((parameters: PostRecipientsIdParams), id: string) =
            $"/v1/recipients/{id}"
            |> this.RestApiClient.PostAsync<_, Recipient> parameters

        ///<p>Permanently deletes a recipient. It cannot be undone.</p>
        member this.Delete (id: string) =
            $"/v1/recipients/{id}"
            |> this.RestApiClient.DeleteAsync<DeletedRecipient>

    and RefundService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of all refunds you’ve previously created. The refunds are returned in sorted order, with the most recent refunds appearing first. For convenience, the 10 most recent refunds are always available by default on the charge object.</p>
        member this.List (?charge: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string) =
            $"/v1/refunds"
            |> this.RestApiClient.GetAsync<Refund>

        ///<p>Create a refund.</p>
        member this.Create ((parameters: PostRefundsParams)) =
            $"/v1/refunds"
            |> this.RestApiClient.PostAsync<_, Refund> parameters

        ///<p>Retrieves the details of an existing refund.</p>
        member this.Retrieve (refund: string, ?expand: string list) =
            $"/v1/refunds/{refund}"
            |> this.RestApiClient.GetAsync<Refund>

        ///<p>Updates the specified refund by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request only accepts <code>metadata</code> as an argument.</p>
        member this.Update ((parameters: PostRefundsRefundParams), refund: string) =
            $"/v1/refunds/{refund}"
            |> this.RestApiClient.PostAsync<_, Refund> parameters

    and ReportingReportRunService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Retrieves the details of an existing Report Run. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        member this.Retrieve (reportRun: string, ?expand: string list) =
            $"/v1/reporting/report_runs/{reportRun}"
            |> this.RestApiClient.GetAsync<ReportingReportRun>

        ///<p>Creates a new object and begin running the report. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        member this.Create ((parameters: PostReportingReportRunsParams)) =
            $"/v1/reporting/report_runs"
            |> this.RestApiClient.PostAsync<_, ReportingReportRun> parameters

        ///<p>Returns a list of Report Runs, with the most recent appearing first. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/reporting/report_runs"
            |> this.RestApiClient.GetAsync<ReportingReportRun>

    and ReportingReportTypeService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Retrieves the details of a Report Type. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        member this.Retrieve (reportType: string, ?expand: string list) =
            $"/v1/reporting/report_types/{reportType}"
            |> this.RestApiClient.GetAsync<ReportingReportType>

        ///<p>Returns a full list of Report Types. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        member this.List (?expand: string list) =
            $"/v1/reporting/report_types"
            |> this.RestApiClient.GetAsync<ReportingReportType>

    and ReviewService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of <code>Review</code> objects that have <code>open</code> set to <code>true</code>. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        member this.List (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/reviews"
            |> this.RestApiClient.GetAsync<Review>

        ///<p>Retrieves a <code>Review</code> object.</p>
        member this.Retrieve (review: string, ?expand: string list) =
            $"/v1/reviews/{review}"
            |> this.RestApiClient.GetAsync<Review>

        ///<p>Approves a <code>Review</code> object, closing it and removing it from the list of reviews.</p>
        member this.Approve ((parameters: PostReviewsReviewApproveParams), review: string) =
            $"/v1/reviews/{review}/approve"
            |> this.RestApiClient.PostAsync<_, Review> parameters

    and ScheduledQueryRunService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of scheduled query runs.</p>
        member this.ListForSigma (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/sigma/scheduled_query_runs"
            |> this.RestApiClient.GetAsync<ScheduledQueryRun>

        ///<p>Retrieves the details of an scheduled query run.</p>
        member this.RetrieveForSigma (scheduledQueryRun: string, ?expand: string list) =
            $"/v1/sigma/scheduled_query_runs/{scheduledQueryRun}"
            |> this.RestApiClient.GetAsync<ScheduledQueryRun>

    and SetupAttemptService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of SetupAttempts associated with a provided SetupIntent.</p>
        member this.List (setupIntent: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/setup_attempts"
            |> this.RestApiClient.GetAsync<SetupAttempt>

    and SetupIntentService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Creates a SetupIntent object.
        ///After the SetupIntent is created, attach a payment method and <a href="/docs/api/setup_intents/confirm">confirm</a>
        ///to collect any required permissions to charge the payment method later.</p>
        member this.Create ((parameters: PostSetupIntentsParams)) =
            $"/v1/setup_intents"
            |> this.RestApiClient.PostAsync<_, SetupIntent> parameters

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
        member this.Update ((parameters: PostSetupIntentsIntentParams), intent: string) =
            $"/v1/setup_intents/{intent}"
            |> this.RestApiClient.PostAsync<_, SetupIntent> parameters

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
        member this.Confirm ((parameters: PostSetupIntentsIntentConfirmParams), intent: string) =
            $"/v1/setup_intents/{intent}/confirm"
            |> this.RestApiClient.PostAsync<_, SetupIntent> parameters

        ///<p>A SetupIntent object can be canceled when it is in one of these statuses: <code>requires_payment_method</code>, <code>requires_confirmation</code>, or <code>requires_action</code>. 
        ///Once canceled, setup is abandoned and any operations on the SetupIntent will fail with an error.</p>
        member this.Cancel ((parameters: PostSetupIntentsIntentCancelParams), intent: string) =
            $"/v1/setup_intents/{intent}/cancel"
            |> this.RestApiClient.PostAsync<_, SetupIntent> parameters

    and SkuService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

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
        member this.Update ((parameters: PostSkusIdParams), id: string) =
            $"/v1/skus/{id}"
            |> this.RestApiClient.PostAsync<_, Sku> parameters

        ///<p>Creates a new SKU associated with a product.</p>
        member this.Create ((parameters: PostSkusParams)) =
            $"/v1/skus"
            |> this.RestApiClient.PostAsync<_, Sku> parameters

        ///<p>Delete a SKU. Deleting a SKU is only possible until it has been used in an order.</p>
        member this.Delete (id: string) =
            $"/v1/skus/{id}"
            |> this.RestApiClient.DeleteAsync<DeletedSku>

    and SourceService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Delete a specified source for a given customer.</p>
        member this.DetachForCustomer ((parameters: DeleteCustomersCustomerSourcesIdParams), customer: string, id: string) =
            $"/v1/customers/{customer}/sources/{id}"
            |> this.RestApiClient.DeleteAsync<PaymentSource>

        ///<p>Retrieves an existing source object. Supply the unique source ID from a source creation request and Stripe will return the corresponding up-to-date source object information.</p>
        member this.Retrieve (source: string, ?expand: string list, ?clientSecret: string) =
            $"/v1/sources/{source}"
            |> this.RestApiClient.GetAsync<Source>

        ///<p>Creates a new source object.</p>
        member this.Create ((parameters: PostSourcesParams)) =
            $"/v1/sources"
            |> this.RestApiClient.PostAsync<_, Source> parameters

        ///<p>Updates the specified source by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request accepts the <code>metadata</code> and <code>owner</code> as arguments. It is also possible to update type specific information for selected payment methods. Please refer to our <a href="/docs/sources">payment method guides</a> for more detail.</p>
        member this.Update ((parameters: PostSourcesSourceParams), source: string) =
            $"/v1/sources/{source}"
            |> this.RestApiClient.PostAsync<_, Source> parameters

        ///<p>Verify a given source.</p>
        member this.Verify ((parameters: PostSourcesSourceVerifyParams), source: string) =
            $"/v1/sources/{source}/verify"
            |> this.RestApiClient.PostAsync<_, Source> parameters

        ///<p>List source transactions for a given source.</p>
        member this.SourceTransactions (source: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/sources/{source}/source_transactions"
            |> this.RestApiClient.GetAsync<SourceTransaction>

    and SubscriptionService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>By default, returns a list of subscriptions that have not been canceled. In order to list canceled subscriptions, specify <code>status=canceled</code>.</p>
        member this.List (?collectionMethod: string, ?created: int, ?currentPeriodEnd: int, ?currentPeriodStart: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?plan: string, ?price: string, ?startingAfter: string, ?status: string) =
            $"/v1/subscriptions"
            |> this.RestApiClient.GetAsync<Subscription>

        ///<p>Creates a new subscription on an existing customer. Each customer can have up to 500 active or scheduled subscriptions.</p>
        member this.Create ((parameters: PostSubscriptionsParams)) =
            $"/v1/subscriptions"
            |> this.RestApiClient.PostAsync<_, Subscription> parameters

        ///<p>Updates an existing subscription on a customer to match the specified parameters. When changing plans or quantities, we will optionally prorate the price we charge next month to make up for any price changes. To preview how the proration will be calculated, use the <a href="#upcoming_invoice">upcoming invoice</a> endpoint.</p>
        member this.Update ((parameters: PostSubscriptionsSubscriptionExposedIdParams), subscriptionExposedId: string) =
            $"/v1/subscriptions/{subscriptionExposedId}"
            |> this.RestApiClient.PostAsync<_, Subscription> parameters

        ///<p>Retrieves the subscription with the given ID.</p>
        member this.Retrieve (subscriptionExposedId: string, ?expand: string list) =
            $"/v1/subscriptions/{subscriptionExposedId}"
            |> this.RestApiClient.GetAsync<Subscription>

        ///<p>Cancels a customer’s subscription immediately. The customer will not be charged again for the subscription.
        ///Note, however, that any pending invoice items that you’ve created will still be charged for at the end of the period, unless manually <a href="#delete_invoiceitem">deleted</a>. If you’ve set the subscription to cancel at the end of the period, any pending prorations will also be left in place and collected at the end of the period. But if the subscription is set to cancel immediately, pending prorations will be removed.
        ///By default, upon subscription cancellation, Stripe will stop automatic collection of all finalized invoices for the customer. This is intended to prevent unexpected payment attempts after the customer has canceled a subscription. However, you can resume automatic collection of the invoices manually after subscription cancellation to have us proceed. Or, you could check for unpaid invoices before allowing the customer to cancel the subscription at all.</p>
        member this.Cancel ((parameters: DeleteSubscriptionsSubscriptionExposedIdParams), subscriptionExposedId: string) =
            $"/v1/subscriptions/{subscriptionExposedId}"
            |> this.RestApiClient.DeleteAsync<Subscription>

        ///<p>Removes the currently applied discount on a subscription.</p>
        member this.DeleteDiscount (subscriptionExposedId: string) =
            $"/v1/subscriptions/{subscriptionExposedId}/discount"
            |> this.RestApiClient.DeleteAsync<DeletedDiscount>

    and SubscriptionItemService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of your subscription items for a given subscription.</p>
        member this.List (subscription: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/subscription_items"
            |> this.RestApiClient.GetAsync<SubscriptionItem>

        ///<p>Retrieves the subscription item with the given ID.</p>
        member this.Retrieve (item: string, ?expand: string list) =
            $"/v1/subscription_items/{item}"
            |> this.RestApiClient.GetAsync<SubscriptionItem>

        ///<p>Adds a new item to an existing subscription. No existing items will be changed or replaced.</p>
        member this.Create ((parameters: PostSubscriptionItemsParams)) =
            $"/v1/subscription_items"
            |> this.RestApiClient.PostAsync<_, SubscriptionItem> parameters

        ///<p>Updates the plan or quantity of an item on a current subscription.</p>
        member this.Update ((parameters: PostSubscriptionItemsItemParams), item: string) =
            $"/v1/subscription_items/{item}"
            |> this.RestApiClient.PostAsync<_, SubscriptionItem> parameters

        ///<p>Deletes an item from the subscription. Removing a subscription item from a subscription will not cancel the subscription.</p>
        member this.Delete ((parameters: DeleteSubscriptionItemsItemParams), item: string) =
            $"/v1/subscription_items/{item}"
            |> this.RestApiClient.DeleteAsync<DeletedSubscriptionItem>

        ///<p>For the specified subscription item, returns a list of summary objects. Each object in the list provides usage information that’s been summarized from multiple usage records and over a subscription billing period (e.g., 15 usage records in the month of September).
        ///The list is sorted in reverse-chronological order (newest first). The first list item represents the most current usage period that hasn’t ended yet. Since new usage records can still be added, the returned summary information for the subscription item’s ID should be seen as unstable until the subscription billing period ends.</p>
        member this.UsageRecordSummaries (subscriptionItem: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/subscription_items/{subscriptionItem}/usage_record_summaries"
            |> this.RestApiClient.GetAsync<UsageRecordSummary>

    and SubscriptionScheduleService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Retrieves the list of your subscription schedules.</p>
        member this.List (?canceledAt: int, ?completedAt: int, ?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?releasedAt: int, ?scheduled: bool, ?startingAfter: string) =
            $"/v1/subscription_schedules"
            |> this.RestApiClient.GetAsync<SubscriptionSchedule>

        ///<p>Creates a new subscription schedule object. Each customer can have up to 500 active or scheduled subscriptions.</p>
        member this.Create ((parameters: PostSubscriptionSchedulesParams)) =
            $"/v1/subscription_schedules"
            |> this.RestApiClient.PostAsync<_, SubscriptionSchedule> parameters

        ///<p>Retrieves the details of an existing subscription schedule. You only need to supply the unique subscription schedule identifier that was returned upon subscription schedule creation.</p>
        member this.Retrieve (schedule: string, ?expand: string list) =
            $"/v1/subscription_schedules/{schedule}"
            |> this.RestApiClient.GetAsync<SubscriptionSchedule>

        ///<p>Updates an existing subscription schedule.</p>
        member this.Update ((parameters: PostSubscriptionSchedulesScheduleParams), schedule: string) =
            $"/v1/subscription_schedules/{schedule}"
            |> this.RestApiClient.PostAsync<_, SubscriptionSchedule> parameters

        ///<p>Cancels a subscription schedule and its associated subscription immediately (if the subscription schedule has an active subscription). A subscription schedule can only be canceled if its status is <code>not_started</code> or <code>active</code>.</p>
        member this.Cancel ((parameters: PostSubscriptionSchedulesScheduleCancelParams), schedule: string) =
            $"/v1/subscription_schedules/{schedule}/cancel"
            |> this.RestApiClient.PostAsync<_, SubscriptionSchedule> parameters

        ///<p>Releases the subscription schedule immediately, which will stop scheduling of its phases, but leave any existing subscription in place. A schedule can only be released if its status is <code>not_started</code> or <code>active</code>. If the subscription schedule is currently associated with a subscription, releasing it will remove its <code>subscription</code> property and set the subscription’s ID to the <code>released_subscription</code> property.</p>
        member this.Release ((parameters: PostSubscriptionSchedulesScheduleReleaseParams), schedule: string) =
            $"/v1/subscription_schedules/{schedule}/release"
            |> this.RestApiClient.PostAsync<_, SubscriptionSchedule> parameters

    and TaxIdService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Creates a new <code>TaxID</code> object for a customer.</p>
        member this.CreateForCustomer ((parameters: PostCustomersCustomerTaxIdsParams), customer: string) =
            $"/v1/customers/{customer}/tax_ids"
            |> this.RestApiClient.PostAsync<_, TaxId> parameters

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

    and TaxRateService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of your tax rates. Tax rates are returned sorted by creation date, with the most recently created tax rates appearing first.</p>
        member this.List (?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?inclusive: bool, ?limit: int, ?startingAfter: string) =
            $"/v1/tax_rates"
            |> this.RestApiClient.GetAsync<TaxRate>

        ///<p>Retrieves a tax rate with the given ID</p>
        member this.Retrieve (taxRate: string, ?expand: string list) =
            $"/v1/tax_rates/{taxRate}"
            |> this.RestApiClient.GetAsync<TaxRate>

        ///<p>Creates a new tax rate.</p>
        member this.Create ((parameters: PostTaxRatesParams)) =
            $"/v1/tax_rates"
            |> this.RestApiClient.PostAsync<_, TaxRate> parameters

        ///<p>Updates an existing tax rate.</p>
        member this.Update ((parameters: PostTaxRatesTaxRateParams), taxRate: string) =
            $"/v1/tax_rates/{taxRate}"
            |> this.RestApiClient.PostAsync<_, TaxRate> parameters

    and TerminalConnectionTokenService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>To connect to a reader the Stripe Terminal SDK needs to retrieve a short-lived connection token from Stripe, proxied through your server. On your backend, add an endpoint that creates and returns a connection token.</p>
        member this.Create ((parameters: PostTerminalConnectionTokensParams)) =
            $"/v1/terminal/connection_tokens"
            |> this.RestApiClient.PostAsync<_, TerminalConnectionToken> parameters

    and TerminalLocationService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Retrieves a <code>Location</code> object.</p>
        member this.Retrieve (location: string, ?expand: string list) =
            $"/v1/terminal/locations/{location}"
            |> this.RestApiClient.GetAsync<TerminalLocation>

        ///<p>Creates a new <code>Location</code> object.</p>
        member this.Create ((parameters: PostTerminalLocationsParams)) =
            $"/v1/terminal/locations"
            |> this.RestApiClient.PostAsync<_, TerminalLocation> parameters

        ///<p>Updates a <code>Location</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((parameters: PostTerminalLocationsLocationParams), location: string) =
            $"/v1/terminal/locations/{location}"
            |> this.RestApiClient.PostAsync<_, TerminalLocation> parameters

        ///<p>Returns a list of <code>Location</code> objects.</p>
        member this.List (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/terminal/locations"
            |> this.RestApiClient.GetAsync<TerminalLocation>

        ///<p>Deletes a <code>Location</code> object.</p>
        member this.Delete (location: string) =
            $"/v1/terminal/locations/{location}"
            |> this.RestApiClient.DeleteAsync<DeletedTerminalLocation>

    and TerminalReaderService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Updates a <code>Reader</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        member this.Update ((parameters: PostTerminalReadersReaderParams), reader: string) =
            $"/v1/terminal/readers/{reader}"
            |> this.RestApiClient.PostAsync<_, TerminalReader> parameters

        ///<p>Retrieves a <code>Reader</code> object.</p>
        member this.Retrieve (reader: string, ?expand: string list) =
            $"/v1/terminal/readers/{reader}"
            |> this.RestApiClient.GetAsync<TerminalReader>

        ///<p>Creates a new <code>Reader</code> object.</p>
        member this.Create ((parameters: PostTerminalReadersParams)) =
            $"/v1/terminal/readers"
            |> this.RestApiClient.PostAsync<_, TerminalReader> parameters

        ///<p>Returns a list of <code>Reader</code> objects.</p>
        member this.List (?deviceType: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?location: string, ?startingAfter: string, ?status: string) =
            $"/v1/terminal/readers"
            |> this.RestApiClient.GetAsync<TerminalReader>

        ///<p>Deletes a <code>Reader</code> object.</p>
        member this.Delete (reader: string) =
            $"/v1/terminal/readers/{reader}"
            |> this.RestApiClient.DeleteAsync<DeletedTerminalReader>

    and ThreeDSecureService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Retrieves a 3D Secure object.</p>
        member this.RetrieveFor3dSecure (threeDSecure: string, ?expand: string list) =
            $"/v1/3d_secure/{threeDSecure}"
            |> this.RestApiClient.GetAsync<ThreeDSecure>

        ///<p>Initiate 3D Secure authentication.</p>
        member this.Create ((parameters: Post3dSecureParams)) =
            $"/v1/3d_secure"
            |> this.RestApiClient.PostAsync<_, ThreeDSecure> parameters

    and TokenService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Retrieves the token with the given ID.</p>
        member this.Retrieve (token: string, ?expand: string list) =
            $"/v1/tokens/{token}"
            |> this.RestApiClient.GetAsync<Token>

        ///<p>Creates a single-use token that represents a bank account’s details.
        ///This token can be used with any API method in place of a bank account dictionary. This token can be used only once, by attaching it to a <a href="#accounts">Custom account</a>.</p>
        member this.Create ((parameters: PostTokensParams)) =
            $"/v1/tokens"
            |> this.RestApiClient.PostAsync<_, Token> parameters

    and TopupService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Top up the balance of an account</p>
        member this.Create ((parameters: PostTopupsParams)) =
            $"/v1/topups"
            |> this.RestApiClient.PostAsync<_, Topup> parameters

        ///<p>Returns a list of top-ups.</p>
        member this.List (?amount: int, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            $"/v1/topups"
            |> this.RestApiClient.GetAsync<Topup>

        ///<p>Retrieves the details of a top-up that has previously been created. Supply the unique top-up ID that was returned from your previous request, and Stripe will return the corresponding top-up information.</p>
        member this.Retrieve (topup: string, ?expand: string list) =
            $"/v1/topups/{topup}"
            |> this.RestApiClient.GetAsync<Topup>

        ///<p>Updates the metadata of a top-up. Other top-up details are not editable by design.</p>
        member this.Update ((parameters: PostTopupsTopupParams), topup: string) =
            $"/v1/topups/{topup}"
            |> this.RestApiClient.PostAsync<_, Topup> parameters

        ///<p>Cancels a top-up. Only pending top-ups can be canceled.</p>
        member this.Cancel ((parameters: PostTopupsTopupCancelParams), topup: string) =
            $"/v1/topups/{topup}/cancel"
            |> this.RestApiClient.PostAsync<_, Topup> parameters

    and TransferService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>To send funds from your Stripe account to a connected account, you create a new transfer object. Your <a href="#balance">Stripe balance</a> must be able to cover the transfer amount, or you’ll receive an “Insufficient Funds” error.</p>
        member this.Create ((parameters: PostTransfersParams)) =
            $"/v1/transfers"
            |> this.RestApiClient.PostAsync<_, Transfer> parameters

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
        member this.Update ((parameters: PostTransfersTransferParams), transfer: string) =
            $"/v1/transfers/{transfer}"
            |> this.RestApiClient.PostAsync<_, Transfer> parameters

    and TransferReversalService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>When you create a new reversal, you must specify a transfer to create it on.
        ///When reversing transfers, you can optionally reverse part of the transfer. You can do so as many times as you wish until the entire transfer has been reversed.
        ///Once entirely reversed, a transfer can’t be reversed again. This method will return an error when called on an already-reversed transfer, or when trying to reverse more money than is left on a transfer.</p>
        member this.Create ((parameters: PostTransfersIdReversalsParams), id: string) =
            $"/v1/transfers/{id}/reversals"
            |> this.RestApiClient.PostAsync<_, TransferReversal> parameters

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
        member this.Update ((parameters: PostTransfersTransferReversalsIdParams), id: string, transfer: string) =
            $"/v1/transfers/{transfer}/reversals/{id}"
            |> this.RestApiClient.PostAsync<_, TransferReversal> parameters

    and UsageRecordService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Creates a usage record for a specified subscription item and date, and fills it with a quantity.
        ///Usage records provide <code>quantity</code> information that Stripe uses to track how much a customer is using your service. With usage information and the pricing model set up by the <a href="https://stripe.com/docs/billing/subscriptions/metered-billing">metered billing</a> plan, Stripe helps you send accurate invoices to your customers.
        ///The default calculation for usage is to add up all the <code>quantity</code> values of the usage records within a billing period. You can change this default behavior with the billing plan’s <code>aggregate_usage</code> <a href="/docs/api/plans/create#create_plan-aggregate_usage">parameter</a>. When there is more than one usage record with the same timestamp, Stripe adds the <code>quantity</code> values together. In most cases, this is the desired resolution, however, you can change this behavior with the <code>action</code> parameter.
        ///The default pricing model for metered billing is <a href="/docs/api/plans/object#plan_object-billing_scheme">per-unit pricing</a>. For finer granularity, you can configure metered billing to have a <a href="https://stripe.com/docs/billing/subscriptions/tiers">tiered pricing</a> model.</p>
        member this.CreateForSubscriptionItem ((parameters: PostSubscriptionItemsSubscriptionItemUsageRecordsParams), subscriptionItem: string) =
            $"/v1/subscription_items/{subscriptionItem}/usage_records"
            |> this.RestApiClient.PostAsync<_, UsageRecord> parameters

    and UsageRecordSummaryService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>For the specified subscription item, returns a list of summary objects. Each object in the list provides usage information that’s been summarized from multiple usage records and over a subscription billing period (e.g., 15 usage records in the month of September).
        ///The list is sorted in reverse-chronological order (newest first). The first list item represents the most current usage period that hasn’t ended yet. Since new usage records can still be added, the returned summary information for the subscription item’s ID should be seen as unstable until the subscription billing period ends.</p>
        member this.ListForSubscriptionItem (subscriptionItem: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/subscription_items/{subscriptionItem}/usage_record_summaries"
            |> this.RestApiClient.GetAsync<UsageRecordSummary>

    and WebhookEndpointService(?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) = 

        member _.RestApiClient = RestApi.RestApiClient(?apiKey = apiKey, ?idempotencyKey = idempotencyKey, ?stripeAccount = stripeAccount, ?stripeVersion = stripeVersion)

        ///<p>Returns a list of your webhook endpoints.</p>
        member this.List (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            $"/v1/webhook_endpoints"
            |> this.RestApiClient.GetAsync<WebhookEndpoint>

        ///<p>Retrieves the webhook endpoint with the given ID.</p>
        member this.Retrieve (webhookEndpoint: string, ?expand: string list) =
            $"/v1/webhook_endpoints/{webhookEndpoint}"
            |> this.RestApiClient.GetAsync<WebhookEndpoint>

        ///<p>A webhook endpoint must have a <code>url</code> and a list of <code>enabled_events</code>. You may optionally specify the Boolean <code>connect</code> parameter. If set to true, then a Connect webhook endpoint that notifies the specified <code>url</code> about events from all connected accounts is created; otherwise an account webhook endpoint that notifies the specified <code>url</code> only about events from your account is created. You can also create webhook endpoints in the <a href="https://dashboard.stripe.com/account/webhooks">webhooks settings</a> section of the Dashboard.</p>
        member this.Create ((parameters: PostWebhookEndpointsParams)) =
            $"/v1/webhook_endpoints"
            |> this.RestApiClient.PostAsync<_, WebhookEndpoint> parameters

        ///<p>Updates the webhook endpoint. You may edit the <code>url</code>, the list of <code>enabled_events</code>, and the status of your endpoint.</p>
        member this.Update ((parameters: PostWebhookEndpointsWebhookEndpointParams), webhookEndpoint: string) =
            $"/v1/webhook_endpoints/{webhookEndpoint}"
            |> this.RestApiClient.PostAsync<_, WebhookEndpoint> parameters

        ///<p>You can also delete webhook endpoints via the <a href="https://dashboard.stripe.com/account/webhooks">webhook endpoint management</a> page of the Stripe dashboard.</p>
        member this.Delete (webhookEndpoint: string) =
            $"/v1/webhook_endpoints/{webhookEndpoint}"
            |> this.RestApiClient.DeleteAsync<DeletedWebhookEndpoint>

