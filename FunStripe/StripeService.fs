namespace FunStripe

open StripeModel
open StripeRequest

module StripeService =

    module ThreeDSecureService =

        ///<p>Initiate 3D Secure authentication.</p>
        let Create settings (formParameters: Post3dSecureParams) =
            $"/v1/3d_secure"
            |> RestApi.postAsync<_, ThreeDSecure> settings formParameters

        type RetrieveQueryParams = {
            ThreeDSecure: string
            Expand: string list option
        }
        with
            static member Create (threeDSecure: string, ?expand: string list) =
                {
                    ThreeDSecure = threeDSecure
                    Expand = expand
                }

        ///<p>Retrieves a 3D Secure object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/3d_secure/{queryParameters.ThreeDSecure}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<ThreeDSecure> settings

    module AccountService =

        type RetrieveQueryParams = {
            Expand: string list option
        }
        with
            static member Create (?expand: string list) =
                {
                    Expand = expand
                }

        ///<p>Retrieves the details of an account.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/account?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Account> settings

    module AccountLinksService =

        ///<p>Creates an AccountLink object that includes a single-use Stripe URL that the platform can redirect their user to in order to take them through the Connect Onboarding flow.</p>
        let Create settings (formParameters: PostAccountLinksParams) =
            $"/v1/account_links"
            |> RestApi.postAsync<_, AccountLink> settings formParameters

    module AccountsService =

        type ListQueryParams = {
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of accounts connected to your platform via <a href="/docs/connect">Connect</a>. If you’re not a platform, the list is empty.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/accounts?created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<Account list> settings

        ///<p>With <a href="/docs/connect">Connect</a>, you can create Stripe accounts for your users.
        ///To do this, you’ll first need to <a href="https://dashboard.stripe.com/account/applications/settings">register your platform</a>.</p>
        let Create settings (formParameters: PostAccountsParams) =
            $"/v1/accounts"
            |> RestApi.postAsync<_, Account> settings formParameters

        type DeleteQueryParams = {
            Account: string
        }
        with
            static member Create (account: string) =
                {
                    Account = account
                }

        ///<p>With <a href="/docs/connect">Connect</a>, you can delete Custom or Express accounts you manage.
        ///Accounts created using test-mode keys can be deleted at any time. Accounts created using live-mode keys can only be deleted once all balances are zero.
        ///If you want to delete your own account, use the <a href="https://dashboard.stripe.com/account">account information tab in your account settings</a> instead.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/accounts/{queryParameters.Account}"
            |> RestApi.deleteAsync<DeletedAccount> settings

        type RetrieveQueryParams = {
            Account: string
            Expand: string list option
        }
        with
            static member Create (account: string, ?expand: string list) =
                {
                    Account = account
                    Expand = expand
                }

        ///<p>Retrieves the details of an account.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/accounts/{queryParameters.Account}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Account> settings

        type UpdateQueryParams = {
            Account: string
        }
        with
            static member Create (account: string) =
                {
                    Account = account
                }

        ///<p>Updates a connected <a href="/docs/connect/accounts">Express or Custom account</a> by setting the values of the parameters passed. Any parameters not provided are left unchanged. Most parameters can be changed only for Custom accounts. (These are marked <strong>Custom Only</strong> below.) Parameters marked <strong>Custom and Express</strong> are supported by both account types.
        ///To update your own account, use the <a href="https://dashboard.stripe.com/account">Dashboard</a>. Refer to our <a href="/docs/connect/updating-accounts">Connect</a> documentation to learn more about updating accounts.</p>
        let Update settings (formParameters: PostAccountsAccountParams) (queryParameters: UpdateQueryParams) =
            $"/v1/accounts/{queryParameters.Account}"
            |> RestApi.postAsync<_, Account> settings formParameters

    module AccountsCapabilitiesService =

        type CapabilitiesQueryParams = {
            Account: string
            Expand: string list option
        }
        with
            static member Create (account: string, ?expand: string list) =
                {
                    Account = account
                    Expand = expand
                }

        ///<p>Returns a list of capabilities associated with the account. The capabilities are returned sorted by creation date, with the most recent capability appearing first.</p>
        let Capabilities settings (queryParameters: CapabilitiesQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/capabilities?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Capability list> settings

        type RetrieveQueryParams = {
            Account: string
            Capability: string
            Expand: string list option
        }
        with
            static member Create (account: string, capability: string, ?expand: string list) =
                {
                    Account = account
                    Capability = capability
                    Expand = expand
                }

        ///<p>Retrieves information about the specified Account Capability.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/capabilities/{queryParameters.Capability}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Capability> settings

        type UpdateQueryParams = {
            Account: string
            Capability: string
        }
        with
            static member Create (account: string, capability: string) =
                {
                    Account = account
                    Capability = capability
                }

        ///<p>Updates an existing Account Capability.</p>
        let Update settings (formParameters: PostAccountsAccountCapabilitiesCapabilityParams) (queryParameters: UpdateQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/capabilities/{queryParameters.Capability}"
            |> RestApi.postAsync<_, Capability> settings formParameters

    module AccountsExternalAccountsService =

        type ListQueryParams = {
            Account: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (account: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Account = account
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>List external accounts for an account.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/external_accounts?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<ExternalAccount list> settings

        type CreateQueryParams = {
            Account: string
        }
        with
            static member Create (account: string) =
                {
                    Account = account
                }

        ///<p>Create an external account for a given account.</p>
        let Create settings (formParameters: PostAccountsAccountExternalAccountsParams) (queryParameters: CreateQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/external_accounts"
            |> RestApi.postAsync<_, ExternalAccount> settings formParameters

        type DeleteQueryParams = {
            Account: string
            Id: string
        }
        with
            static member Create (account: string, id: string) =
                {
                    Account = account
                    Id = id
                }

        ///<p>Delete a specified external account for a given account.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/external_accounts/{queryParameters.Id}"
            |> RestApi.deleteAsync<DeletedExternalAccount> settings

        type RetrieveQueryParams = {
            Account: string
            Id: string
            Expand: string list option
        }
        with
            static member Create (account: string, id: string, ?expand: string list) =
                {
                    Account = account
                    Id = id
                    Expand = expand
                }

        ///<p>Retrieve a specified external account for a given account.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/external_accounts/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<ExternalAccount> settings

        type UpdateQueryParams = {
            Account: string
            Id: string
        }
        with
            static member Create (account: string, id: string) =
                {
                    Account = account
                    Id = id
                }

        ///<p>Updates the metadata, account holder name, and account holder type of a bank account belonging to a <a href="/docs/connect/custom-accounts">Custom account</a>, and optionally sets it as the default for its currency. Other bank account details are not editable by design.
        ///You can re-enable a disabled bank account by performing an update call without providing any arguments or changes.</p>
        let Update settings (formParameters: PostAccountsAccountExternalAccountsIdParams) (queryParameters: UpdateQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/external_accounts/{queryParameters.Id}"
            |> RestApi.postAsync<_, ExternalAccount> settings formParameters

    module AccountsLoginLinksService =

        type CreateQueryParams = {
            Account: string
        }
        with
            static member Create (account: string) =
                {
                    Account = account
                }

        ///<p>Creates a single-use login link for an Express account to access their Stripe dashboard.
        ///<strong>You may only create login links for <a href="/docs/connect/express-accounts">Express accounts</a> connected to your platform</strong>.</p>
        let Create settings (formParameters: PostAccountsAccountLoginLinksParams) (queryParameters: CreateQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/login_links"
            |> RestApi.postAsync<_, LoginLink> settings formParameters

    module AccountsPersonsService =

        type ListQueryParams = {
            Account: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            Relationship: Map<string, string> option
            StartingAfter: string option
        }
        with
            static member Create (account: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?relationship: Map<string, string>, ?startingAfter: string) =
                {
                    Account = account
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    Relationship = relationship
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of people associated with the account’s legal entity. The people are returned sorted by creation date, with the most recent people appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/persons?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&relationship={queryParameters.Relationship}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<Person list> settings

        type CreateQueryParams = {
            Account: string
        }
        with
            static member Create (account: string) =
                {
                    Account = account
                }

        ///<p>Creates a new person.</p>
        let Create settings (formParameters: PostAccountsAccountPersonsParams) (queryParameters: CreateQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/persons"
            |> RestApi.postAsync<_, Person> settings formParameters

        type DeleteQueryParams = {
            Account: string
            Person: string
        }
        with
            static member Create (account: string, person: string) =
                {
                    Account = account
                    Person = person
                }

        ///<p>Deletes an existing person’s relationship to the account’s legal entity. Any person with a relationship for an account can be deleted through the API, except if the person is the <code>account_opener</code>. If your integration is using the <code>executive</code> parameter, you cannot delete the only verified <code>executive</code> on file.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/persons/{queryParameters.Person}"
            |> RestApi.deleteAsync<DeletedPerson> settings

        type RetrieveQueryParams = {
            Account: string
            Person: string
            Expand: string list option
        }
        with
            static member Create (account: string, person: string, ?expand: string list) =
                {
                    Account = account
                    Person = person
                    Expand = expand
                }

        ///<p>Retrieves an existing person.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/persons/{queryParameters.Person}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Person> settings

        type UpdateQueryParams = {
            Account: string
            Person: string
        }
        with
            static member Create (account: string, person: string) =
                {
                    Account = account
                    Person = person
                }

        ///<p>Updates an existing person.</p>
        let Update settings (formParameters: PostAccountsAccountPersonsPersonParams) (queryParameters: UpdateQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/persons/{queryParameters.Person}"
            |> RestApi.postAsync<_, Person> settings formParameters

    module AccountsRejectService =

        type RejectQueryParams = {
            Account: string
        }
        with
            static member Create (account: string) =
                {
                    Account = account
                }

        ///<p>With <a href="/docs/connect">Connect</a>, you may flag accounts as suspicious.
        ///Test-mode Custom and Express accounts can be rejected at any time. Accounts created using live-mode keys may only be rejected once all balances are zero.</p>
        let Reject settings (formParameters: PostAccountsAccountRejectParams) (queryParameters: RejectQueryParams) =
            $"/v1/accounts/{queryParameters.Account}/reject"
            |> RestApi.postAsync<_, Account> settings formParameters

    module ApplePayDomainsService =

        type ListQueryParams = {
            DomainName: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?domainName: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    DomainName = domainName
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>List apple pay domains.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/apple_pay/domains?domain_name={queryParameters.DomainName}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<ApplePayDomain list> settings

        ///<p>Create an apple pay domain.</p>
        let Create settings (formParameters: PostApplePayDomainsParams) =
            $"/v1/apple_pay/domains"
            |> RestApi.postAsync<_, ApplePayDomain> settings formParameters

        type DeleteQueryParams = {
            Domain: string
        }
        with
            static member Create (domain: string) =
                {
                    Domain = domain
                }

        ///<p>Delete an apple pay domain.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/apple_pay/domains/{queryParameters.Domain}"
            |> RestApi.deleteAsync<DeletedApplePayDomain> settings

        type RetrieveQueryParams = {
            Domain: string
            Expand: string list option
        }
        with
            static member Create (domain: string, ?expand: string list) =
                {
                    Domain = domain
                    Expand = expand
                }

        ///<p>Retrieve an apple pay domain.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/apple_pay/domains/{queryParameters.Domain}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<ApplePayDomain> settings

    module ApplicationFeesService =

        type ListQueryParams = {
            Charge: string option
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?charge: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Charge = charge
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of application fees you’ve previously collected. The application fees are returned in sorted order, with the most recent fees appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/application_fees?charge={queryParameters.Charge}&created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<ApplicationFee list> settings

        type RetrieveQueryParams = {
            Id: string
            Expand: string list option
        }
        with
            static member Create (id: string, ?expand: string list) =
                {
                    Id = id
                    Expand = expand
                }

        ///<p>Retrieves the details of an application fee that your account has collected. The same information is returned when refunding the application fee.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/application_fees/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<ApplicationFee> settings

    module ApplicationFeesRefundsService =

        type RetrieveQueryParams = {
            Fee: string
            Id: string
            Expand: string list option
        }
        with
            static member Create (fee: string, id: string, ?expand: string list) =
                {
                    Fee = fee
                    Id = id
                    Expand = expand
                }

        ///<p>By default, you can see the 10 most recent refunds stored directly on the application fee object, but you can also retrieve details about a specific refund stored on the application fee.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/application_fees/{queryParameters.Fee}/refunds/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<FeeRefund> settings

        type UpdateQueryParams = {
            Fee: string
            Id: string
        }
        with
            static member Create (fee: string, id: string) =
                {
                    Fee = fee
                    Id = id
                }

        ///<p>Updates the specified application fee refund by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request only accepts metadata as an argument.</p>
        let Update settings (formParameters: PostApplicationFeesFeeRefundsIdParams) (queryParameters: UpdateQueryParams) =
            $"/v1/application_fees/{queryParameters.Fee}/refunds/{queryParameters.Id}"
            |> RestApi.postAsync<_, FeeRefund> settings formParameters

        type ListQueryParams = {
            Id: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (id: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Id = id
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>You can see a list of the refunds belonging to a specific application fee. Note that the 10 most recent refunds are always available by default on the application fee object. If you need more than those 10, you can use this API method and the <code>limit</code> and <code>starting_after</code> parameters to page through additional refunds.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/application_fees/{queryParameters.Id}/refunds?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<FeeRefund list> settings

        type CreateQueryParams = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Refunds an application fee that has previously been collected but not yet refunded.
        ///Funds will be refunded to the Stripe account from which the fee was originally collected.
        ///You can optionally refund only part of an application fee.
        ///You can do so multiple times, until the entire fee has been refunded.
        ///Once entirely refunded, an application fee can’t be refunded again.
        ///This method will raise an error when called on an already-refunded application fee,
        ///or when trying to refund more money than is left on an application fee.</p>
        let Create settings (formParameters: PostApplicationFeesIdRefundsParams) (queryParameters: CreateQueryParams) =
            $"/v1/application_fees/{queryParameters.Id}/refunds"
            |> RestApi.postAsync<_, FeeRefund> settings formParameters

    module BalanceService =

        type RetrieveQueryParams = {
            Expand: string list option
        }
        with
            static member Create (?expand: string list) =
                {
                    Expand = expand
                }

        ///<p>Retrieves the current account balance, based on the authentication that was used to make the request.
        /// For a sample request, see <a href="/docs/connect/account-balances#accounting-for-negative-balances">Accounting for negative balances</a>.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/balance?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Balance> settings

    module BalanceTransactionsService =

        type ListQueryParams = {
            AvailableOn: int option
            Created: int option
            Currency: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            Payout: string option
            Source: string option
            StartingAfter: string option
            ``type``: string option
        }
        with
            static member Create (?availableOn: int, ?created: int, ?currency: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?payout: string, ?source: string, ?startingAfter: string, ?``type``: string) =
                {
                    AvailableOn = availableOn
                    Created = created
                    Currency = currency
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    Payout = payout
                    Source = source
                    StartingAfter = startingAfter
                    ``type`` = ``type``
                }

        ///<p>Returns a list of transactions that have contributed to the Stripe account balance (e.g., charges, transfers, and so forth). The transactions are returned in sorted order, with the most recent transactions appearing first.
        ///Note that this endpoint was previously called “Balance history” and used the path <code>/v1/balance/history</code>.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/balance_transactions?available_on={queryParameters.AvailableOn}&created={queryParameters.Created}&currency={queryParameters.Currency}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&payout={queryParameters.Payout}&source={queryParameters.Source}&starting_after={queryParameters.StartingAfter}&type={queryParameters.``type``}"
            |> RestApi.getAsync<BalanceTransaction list> settings

        type RetrieveQueryParams = {
            Id: string
            Expand: string list option
        }
        with
            static member Create (id: string, ?expand: string list) =
                {
                    Id = id
                    Expand = expand
                }

        ///<p>Retrieves the balance transaction with the given ID.
        ///Note that this endpoint previously used the path <code>/v1/balance/history/:id</code>.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/balance_transactions/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<BalanceTransaction> settings

    module BillingPortalSessionsService =

        ///<p>Creates a session of the customer portal.</p>
        let Create settings (formParameters: PostBillingPortalSessionsParams) =
            $"/v1/billing_portal/sessions"
            |> RestApi.postAsync<_, BillingPortalSession> settings formParameters

    module BitcoinReceiversService =

        type ListQueryParams = {
            Active: bool option
            EndingBefore: string option
            Expand: string list option
            Filled: bool option
            Limit: int option
            StartingAfter: string option
            UncapturedFunds: bool option
        }
        with
            static member Create (?active: bool, ?endingBefore: string, ?expand: string list, ?filled: bool, ?limit: int, ?startingAfter: string, ?uncapturedFunds: bool) =
                {
                    Active = active
                    EndingBefore = endingBefore
                    Expand = expand
                    Filled = filled
                    Limit = limit
                    StartingAfter = startingAfter
                    UncapturedFunds = uncapturedFunds
                }

        ///<p>Returns a list of your receivers. Receivers are returned sorted by creation date, with the most recently created receivers appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/bitcoin/receivers?active={queryParameters.Active}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&filled={queryParameters.Filled}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}&uncaptured_funds={queryParameters.UncapturedFunds}"
            |> RestApi.getAsync<BitcoinReceiver list> settings

        type RetrieveQueryParams = {
            Id: string
            Expand: string list option
        }
        with
            static member Create (id: string, ?expand: string list) =
                {
                    Id = id
                    Expand = expand
                }

        ///<p>Retrieves the Bitcoin receiver with the given ID.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/bitcoin/receivers/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<BitcoinReceiver> settings

    module BitcoinReceiversTransactionsService =

        type ListQueryParams = {
            Receiver: string
            Customer: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (receiver: string, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Receiver = receiver
                    Customer = customer
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>List bitcoin transacitons for a given receiver.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/bitcoin/receivers/{queryParameters.Receiver}/transactions?customer={queryParameters.Customer}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<BitcoinTransaction list> settings

    module ChargesService =

        type ListQueryParams = {
            Created: int option
            Customer: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            PaymentIntent: string option
            StartingAfter: string option
            TransferGroup: string option
        }
        with
            static member Create (?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string, ?transferGroup: string) =
                {
                    Created = created
                    Customer = customer
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    PaymentIntent = paymentIntent
                    StartingAfter = startingAfter
                    TransferGroup = transferGroup
                }

        ///<p>Returns a list of charges you’ve previously created. The charges are returned in sorted order, with the most recent charges appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/charges?created={queryParameters.Created}&customer={queryParameters.Customer}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&payment_intent={queryParameters.PaymentIntent}&starting_after={queryParameters.StartingAfter}&transfer_group={queryParameters.TransferGroup}"
            |> RestApi.getAsync<Charge list> settings

        ///<p>To charge a credit card or other payment source, you create a <code>Charge</code> object. If your API key is in test mode, the supplied payment source (e.g., card) won’t actually be charged, although everything else will occur as if in live mode. (Stripe assumes that the charge would have completed successfully).</p>
        let Create settings (formParameters: PostChargesParams) =
            $"/v1/charges"
            |> RestApi.postAsync<_, Charge> settings formParameters

        type RetrieveQueryParams = {
            Charge: string
            Expand: string list option
        }
        with
            static member Create (charge: string, ?expand: string list) =
                {
                    Charge = charge
                    Expand = expand
                }

        ///<p>Retrieves the details of a charge that has previously been created. Supply the unique charge ID that was returned from your previous request, and Stripe will return the corresponding charge information. The same information is returned when creating or refunding the charge.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/charges/{queryParameters.Charge}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Charge> settings

        type UpdateQueryParams = {
            Charge: string
        }
        with
            static member Create (charge: string) =
                {
                    Charge = charge
                }

        ///<p>Updates the specified charge by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formParameters: PostChargesChargeParams) (queryParameters: UpdateQueryParams) =
            $"/v1/charges/{queryParameters.Charge}"
            |> RestApi.postAsync<_, Charge> settings formParameters

    module ChargesCaptureService =

        type CaptureQueryParams = {
            Charge: string
        }
        with
            static member Create (charge: string) =
                {
                    Charge = charge
                }

        ///<p>Capture the payment of an existing, uncaptured, charge. This is the second half of the two-step payment flow, where first you <a href="#create_charge">created a charge</a> with the capture option set to false.
        ///Uncaptured payments expire exactly seven days after they are created. If they are not captured by that point in time, they will be marked as refunded and will no longer be capturable.</p>
        let Capture settings (formParameters: PostChargesChargeCaptureParams) (queryParameters: CaptureQueryParams) =
            $"/v1/charges/{queryParameters.Charge}/capture"
            |> RestApi.postAsync<_, Charge> settings formParameters

    module ChargesRefundsService =

        type ListQueryParams = {
            Charge: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (charge: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Charge = charge
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>You can see a list of the refunds belonging to a specific charge. Note that the 10 most recent refunds are always available by default on the charge object. If you need more than those 10, you can use this API method and the <code>limit</code> and <code>starting_after</code> parameters to page through additional refunds.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/charges/{queryParameters.Charge}/refunds?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<Refund list> settings

        type RetrieveQueryParams = {
            Charge: string
            Refund: string
            Expand: string list option
        }
        with
            static member Create (charge: string, refund: string, ?expand: string list) =
                {
                    Charge = charge
                    Refund = refund
                    Expand = expand
                }

        ///<p>Retrieves the details of an existing refund.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/charges/{queryParameters.Charge}/refunds/{queryParameters.Refund}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Refund> settings

    module CheckoutSessionsService =

        type ListQueryParams = {
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            PaymentIntent: string option
            StartingAfter: string option
            Subscription: string option
        }
        with
            static member Create (?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string, ?subscription: string) =
                {
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    PaymentIntent = paymentIntent
                    StartingAfter = startingAfter
                    Subscription = subscription
                }

        ///<p>Returns a list of Checkout Sessions.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/checkout/sessions?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&payment_intent={queryParameters.PaymentIntent}&starting_after={queryParameters.StartingAfter}&subscription={queryParameters.Subscription}"
            |> RestApi.getAsync<CheckoutSession list> settings

        ///<p>Creates a Session object.</p>
        let Create settings (formParameters: PostCheckoutSessionsParams) =
            $"/v1/checkout/sessions"
            |> RestApi.postAsync<_, CheckoutSession> settings formParameters

        type RetrieveQueryParams = {
            Session: string
            Expand: string list option
        }
        with
            static member Create (session: string, ?expand: string list) =
                {
                    Session = session
                    Expand = expand
                }

        ///<p>Retrieves a Session object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/checkout/sessions/{queryParameters.Session}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<CheckoutSession> settings

    module CheckoutSessionsLineItemsService =

        type ListQueryParams = {
            Session: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (session: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Session = session
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>When retrieving a Checkout Session, there is an includable <strong>line_items</strong> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/checkout/sessions/{queryParameters.Session}/line_items?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<Item list> settings

    module CountrySpecsService =

        type ListQueryParams = {
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Lists all Country Spec objects available in the API.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/country_specs?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<CountrySpec list> settings

        type RetrieveQueryParams = {
            Country: string
            Expand: string list option
        }
        with
            static member Create (country: string, ?expand: string list) =
                {
                    Country = country
                    Expand = expand
                }

        ///<p>Returns a Country Spec for a given Country code.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/country_specs/{queryParameters.Country}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<CountrySpec> settings

    module CouponsService =

        type ListQueryParams = {
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of your coupons.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/coupons?created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<Coupon list> settings

        ///<p>You can create coupons easily via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. Coupon creation is also accessible via the API if you need to create coupons on the fly.
        ///A coupon has either a <code>percent_off</code> or an <code>amount_off</code> and <code>currency</code>. If you set an <code>amount_off</code>, that amount will be subtracted from any invoice’s subtotal. For example, an invoice with a subtotal of <currency>100</currency> will have a final total of <currency>0</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it and an invoice with a subtotal of <currency>300</currency> will have a final total of <currency>100</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it.</p>
        let Create settings (formParameters: PostCouponsParams) =
            $"/v1/coupons"
            |> RestApi.postAsync<_, Coupon> settings formParameters

        type DeleteQueryParams = {
            Coupon: string
        }
        with
            static member Create (coupon: string) =
                {
                    Coupon = coupon
                }

        ///<p>You can delete coupons via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. However, deleting a coupon does not affect any customers who have already applied the coupon; it means that new customers can’t redeem the coupon. You can also delete coupons via the API.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/coupons/{queryParameters.Coupon}"
            |> RestApi.deleteAsync<DeletedCoupon> settings

        type RetrieveQueryParams = {
            Coupon: string
            Expand: string list option
        }
        with
            static member Create (coupon: string, ?expand: string list) =
                {
                    Coupon = coupon
                    Expand = expand
                }

        ///<p>Retrieves the coupon with the given ID.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/coupons/{queryParameters.Coupon}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Coupon> settings

        type UpdateQueryParams = {
            Coupon: string
        }
        with
            static member Create (coupon: string) =
                {
                    Coupon = coupon
                }

        ///<p>Updates the metadata of a coupon. Other coupon details (currency, duration, amount_off) are, by design, not editable.</p>
        let Update settings (formParameters: PostCouponsCouponParams) (queryParameters: UpdateQueryParams) =
            $"/v1/coupons/{queryParameters.Coupon}"
            |> RestApi.postAsync<_, Coupon> settings formParameters

    module CreditNotesService =

        type ListQueryParams = {
            Customer: string option
            EndingBefore: string option
            Expand: string list option
            Invoice: string option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?customer: string, ?endingBefore: string, ?expand: string list, ?invoice: string, ?limit: int, ?startingAfter: string) =
                {
                    Customer = customer
                    EndingBefore = endingBefore
                    Expand = expand
                    Invoice = invoice
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of credit notes.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/credit_notes?customer={queryParameters.Customer}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&invoice={queryParameters.Invoice}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<CreditNote list> settings

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
        let Create settings (formParameters: PostCreditNotesParams) =
            $"/v1/credit_notes"
            |> RestApi.postAsync<_, CreditNote> settings formParameters

        type RetrieveQueryParams = {
            Id: string
            Expand: string list option
        }
        with
            static member Create (id: string, ?expand: string list) =
                {
                    Id = id
                    Expand = expand
                }

        ///<p>Retrieves the credit note object with the given identifier.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/credit_notes/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<CreditNote> settings

        type UpdateQueryParams = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Updates an existing credit note.</p>
        let Update settings (formParameters: PostCreditNotesIdParams) (queryParameters: UpdateQueryParams) =
            $"/v1/credit_notes/{queryParameters.Id}"
            |> RestApi.postAsync<_, CreditNote> settings formParameters

    module CreditNotesPreviewService =

        type PreviewQueryParams = {
            Invoice: string
            Amount: int option
            CreditAmount: int option
            Expand: string list option
            Lines: string list option
            Memo: string option
            Metadata: Map<string, string> option
            OutOfBandAmount: int option
            Reason: string option
            Refund: string option
            RefundAmount: int option
        }
        with
            static member Create (invoice: string, ?amount: int, ?creditAmount: int, ?expand: string list, ?lines: string list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: string, ?refund: string, ?refundAmount: int) =
                {
                    Invoice = invoice
                    Amount = amount
                    CreditAmount = creditAmount
                    Expand = expand
                    Lines = lines
                    Memo = memo
                    Metadata = metadata
                    OutOfBandAmount = outOfBandAmount
                    Reason = reason
                    Refund = refund
                    RefundAmount = refundAmount
                }

        ///<p>Get a preview of a credit note without creating it.</p>
        let Preview settings (queryParameters: PreviewQueryParams) =
            $"/v1/credit_notes/preview?invoice={queryParameters.Invoice}&amount={queryParameters.Amount}&credit_amount={queryParameters.CreditAmount}&expand={queryParameters.Expand}&lines={queryParameters.Lines}&memo={queryParameters.Memo}&metadata={queryParameters.Metadata}&out_of_band_amount={queryParameters.OutOfBandAmount}&reason={queryParameters.Reason}&refund={queryParameters.Refund}&refund_amount={queryParameters.RefundAmount}"
            |> RestApi.getAsync<CreditNote> settings

    module CreditNotesPreviewLinesService =

        type PreviewLinesQueryParams = {
            Invoice: string
            Amount: int option
            CreditAmount: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            Lines: string list option
            Memo: string option
            Metadata: Map<string, string> option
            OutOfBandAmount: int option
            Reason: string option
            Refund: string option
            RefundAmount: int option
            StartingAfter: string option
        }
        with
            static member Create (invoice: string, ?amount: int, ?creditAmount: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?lines: string list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: string, ?refund: string, ?refundAmount: int, ?startingAfter: string) =
                {
                    Invoice = invoice
                    Amount = amount
                    CreditAmount = creditAmount
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    Lines = lines
                    Memo = memo
                    Metadata = metadata
                    OutOfBandAmount = outOfBandAmount
                    Reason = reason
                    Refund = refund
                    RefundAmount = refundAmount
                    StartingAfter = startingAfter
                }

        ///<p>When retrieving a credit note preview, you’ll get a <strong>lines</strong> property containing the first handful of those items. This URL you can retrieve the full (paginated) list of line items.</p>
        let PreviewLines settings (queryParameters: PreviewLinesQueryParams) =
            $"/v1/credit_notes/preview/lines?invoice={queryParameters.Invoice}&amount={queryParameters.Amount}&credit_amount={queryParameters.CreditAmount}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&lines={queryParameters.Lines}&memo={queryParameters.Memo}&metadata={queryParameters.Metadata}&out_of_band_amount={queryParameters.OutOfBandAmount}&reason={queryParameters.Reason}&refund={queryParameters.Refund}&refund_amount={queryParameters.RefundAmount}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<CreditNoteLineItem list> settings

    module CreditNotesLinesService =

        type ListQueryParams = {
            CreditNote: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (creditNote: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    CreditNote = creditNote
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>When retrieving a credit note, you’ll get a <strong>lines</strong> property containing the the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/credit_notes/{queryParameters.CreditNote}/lines?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<CreditNoteLineItem list> settings

    module CreditNotesVoidService =

        type VoidCreditNoteQueryParams = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Marks a credit note as void. Learn more about <a href="/docs/billing/invoices/credit-notes#voiding">voiding credit notes</a>.</p>
        let VoidCreditNote settings (formParameters: PostCreditNotesIdVoidParams) (queryParameters: VoidCreditNoteQueryParams) =
            $"/v1/credit_notes/{queryParameters.Id}/void"
            |> RestApi.postAsync<_, CreditNote> settings formParameters

    module CustomersService =

        type ListQueryParams = {
            Created: int option
            Email: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?created: int, ?email: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Created = created
                    Email = email
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of your customers. The customers are returned sorted by creation date, with the most recent customers appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/customers?created={queryParameters.Created}&email={queryParameters.Email}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<Customer list> settings

        ///<p>Creates a new customer object.</p>
        let Create settings (formParameters: PostCustomersParams) =
            $"/v1/customers"
            |> RestApi.postAsync<_, Customer> settings formParameters

        type DeleteQueryParams = {
            Customer: string
        }
        with
            static member Create (customer: string) =
                {
                    Customer = customer
                }

        ///<p>Permanently deletes a customer. It cannot be undone. Also immediately cancels any active subscriptions on the customer.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/customers/{queryParameters.Customer}"
            |> RestApi.deleteAsync<DeletedCustomer> settings

        type RetrieveQueryParams = {
            Customer: string
            Expand: string list option
        }
        with
            static member Create (customer: string, ?expand: string list) =
                {
                    Customer = customer
                    Expand = expand
                }

        ///<p>Retrieves the details of an existing customer. You need only supply the unique customer identifier that was returned upon customer creation.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/customers/{queryParameters.Customer}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Customer> settings

        type UpdateQueryParams = {
            Customer: string
        }
        with
            static member Create (customer: string) =
                {
                    Customer = customer
                }

        ///<p>Updates the specified customer by setting the values of the parameters passed. Any parameters not provided will be left unchanged. For example, if you pass the <strong>source</strong> parameter, that becomes the customer’s active source (e.g., a card) to be used for all charges in the future. When you update a customer to a new valid card source by passing the <strong>source</strong> parameter: for each of the customer’s current subscriptions, if the subscription bills automatically and is in the <code>past_due</code> state, then the latest open invoice for the subscription with automatic collection enabled will be retried. This retry will not count as an automatic retry, and will not affect the next regularly scheduled payment for the invoice. Changing the <strong>default_source</strong> for a customer will not trigger this behavior.
        ///This request accepts mostly the same arguments as the customer creation call.</p>
        let Update settings (formParameters: PostCustomersCustomerParams) (queryParameters: UpdateQueryParams) =
            $"/v1/customers/{queryParameters.Customer}"
            |> RestApi.postAsync<_, Customer> settings formParameters

    module CustomersBalanceTransactionsService =

        type ListQueryParams = {
            Customer: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Customer = customer
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of transactions that updated the customer’s <a href="/docs/billing/customer/balance">balances</a>.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/balance_transactions?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<CustomerBalanceTransaction list> settings

        type CreateQueryParams = {
            Customer: string
        }
        with
            static member Create (customer: string) =
                {
                    Customer = customer
                }

        ///<p>Creates an immutable transaction that updates the customer’s credit <a href="/docs/billing/customer/balance">balance</a>.</p>
        let Create settings (formParameters: PostCustomersCustomerBalanceTransactionsParams) (queryParameters: CreateQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/balance_transactions"
            |> RestApi.postAsync<_, CustomerBalanceTransaction> settings formParameters

        type RetrieveQueryParams = {
            Customer: string
            Transaction: string
            Expand: string list option
        }
        with
            static member Create (customer: string, transaction: string, ?expand: string list) =
                {
                    Customer = customer
                    Transaction = transaction
                    Expand = expand
                }

        ///<p>Retrieves a specific customer balance transaction that updated the customer’s <a href="/docs/billing/customer/balance">balances</a>.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/balance_transactions/{queryParameters.Transaction}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<CustomerBalanceTransaction> settings

        type UpdateQueryParams = {
            Customer: string
            Transaction: string
        }
        with
            static member Create (customer: string, transaction: string) =
                {
                    Customer = customer
                    Transaction = transaction
                }

        ///<p>Most credit balance transaction fields are immutable, but you may update its <code>description</code> and <code>metadata</code>.</p>
        let Update settings (formParameters: PostCustomersCustomerBalanceTransactionsTransactionParams) (queryParameters: UpdateQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/balance_transactions/{queryParameters.Transaction}"
            |> RestApi.postAsync<_, CustomerBalanceTransaction> settings formParameters

    module CustomersDiscountService =

        type DeleteDiscountQueryParams = {
            Customer: string
        }
        with
            static member Create (customer: string) =
                {
                    Customer = customer
                }

        ///<p>Removes the currently applied discount on a customer.</p>
        let DeleteDiscount settings (queryParameters: DeleteDiscountQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/discount"
            |> RestApi.deleteAsync<DeletedDiscount> settings

    module CustomersSourcesService =

        type ListQueryParams = {
            Customer: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            Object: string option
            StartingAfter: string option
        }
        with
            static member Create (customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?object: string, ?startingAfter: string) =
                {
                    Customer = customer
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    Object = object
                    StartingAfter = startingAfter
                }

        ///<p>List sources for a specified customer.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/sources?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&object={queryParameters.Object}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<PaymentSource list> settings

        type CreateQueryParams = {
            Customer: string
        }
        with
            static member Create (customer: string) =
                {
                    Customer = customer
                }

        ///<p>When you create a new credit card, you must specify a customer or recipient on which to create it.
        ///If the card’s owner has no default card, then the new card will become the default.
        ///However, if the owner already has a default, then it will not change.
        ///To change the default, you should <a href="/docs/api#update_customer">update the customer</a> to have a new <code>default_source</code>.</p>
        let Create settings (formParameters: PostCustomersCustomerSourcesParams) (queryParameters: CreateQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/sources"
            |> RestApi.postAsync<_, PaymentSource> settings formParameters

        type DeleteQueryParams = {
            Customer: string
            Id: string
        }
        with
            static member Create (customer: string, id: string) =
                {
                    Customer = customer
                    Id = id
                }

        ///<p>Delete a specified source for a given customer.</p>
        let Delete settings (formParameters: DeleteCustomersCustomerSourcesIdParams) (queryParameters: DeleteQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/sources/{queryParameters.Id}"
            |> RestApi.deleteAsync<PaymentSource> settings

        type RetrieveQueryParams = {
            Customer: string
            Id: string
            Expand: string list option
        }
        with
            static member Create (customer: string, id: string, ?expand: string list) =
                {
                    Customer = customer
                    Id = id
                    Expand = expand
                }

        ///<p>Retrieve a specified source for a given customer.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/sources/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<PaymentSource> settings

        type UpdateQueryParams = {
            Customer: string
            Id: string
        }
        with
            static member Create (customer: string, id: string) =
                {
                    Customer = customer
                    Id = id
                }

        ///<p>Update a specified source for a given customer.</p>
        let Update settings (formParameters: PostCustomersCustomerSourcesIdParams) (queryParameters: UpdateQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/sources/{queryParameters.Id}"
            |> RestApi.postAsync<_, Card> settings formParameters

    module CustomersSourcesVerifyService =

        type VerifyQueryParams = {
            Customer: string
            Id: string
        }
        with
            static member Create (customer: string, id: string) =
                {
                    Customer = customer
                    Id = id
                }

        ///<p>Verify a specified bank account for a given customer.</p>
        let Verify settings (formParameters: PostCustomersCustomerSourcesIdVerifyParams) (queryParameters: VerifyQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/sources/{queryParameters.Id}/verify"
            |> RestApi.postAsync<_, BankAccount> settings formParameters

    module CustomersTaxIdsService =

        type ListQueryParams = {
            Customer: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Customer = customer
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of tax IDs for a customer.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/tax_ids?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<TaxId list> settings

        type CreateQueryParams = {
            Customer: string
        }
        with
            static member Create (customer: string) =
                {
                    Customer = customer
                }

        ///<p>Creates a new <code>TaxID</code> object for a customer.</p>
        let Create settings (formParameters: PostCustomersCustomerTaxIdsParams) (queryParameters: CreateQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/tax_ids"
            |> RestApi.postAsync<_, TaxId> settings formParameters

        type DeleteQueryParams = {
            Customer: string
            Id: string
        }
        with
            static member Create (customer: string, id: string) =
                {
                    Customer = customer
                    Id = id
                }

        ///<p>Deletes an existing <code>TaxID</code> object.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/tax_ids/{queryParameters.Id}"
            |> RestApi.deleteAsync<DeletedTaxId> settings

        type RetrieveQueryParams = {
            Customer: string
            Id: string
            Expand: string list option
        }
        with
            static member Create (customer: string, id: string, ?expand: string list) =
                {
                    Customer = customer
                    Id = id
                    Expand = expand
                }

        ///<p>Retrieves the <code>TaxID</code> object with the given identifier.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/customers/{queryParameters.Customer}/tax_ids/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<TaxId> settings

    module DisputesService =

        type ListQueryParams = {
            Charge: string option
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            PaymentIntent: string option
            StartingAfter: string option
        }
        with
            static member Create (?charge: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string) =
                {
                    Charge = charge
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    PaymentIntent = paymentIntent
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of your disputes.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/disputes?charge={queryParameters.Charge}&created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&payment_intent={queryParameters.PaymentIntent}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<Dispute list> settings

        type RetrieveQueryParams = {
            Dispute: string
            Expand: string list option
        }
        with
            static member Create (dispute: string, ?expand: string list) =
                {
                    Dispute = dispute
                    Expand = expand
                }

        ///<p>Retrieves the dispute with the given ID.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/disputes/{queryParameters.Dispute}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Dispute> settings

        type UpdateQueryParams = {
            Dispute: string
        }
        with
            static member Create (dispute: string) =
                {
                    Dispute = dispute
                }

        ///<p>When you get a dispute, contacting your customer is always the best first step. If that doesn’t work, you can submit evidence to help us resolve the dispute in your favor. You can do this in your <a href="https://dashboard.stripe.com/disputes">dashboard</a>, but if you prefer, you can use the API to submit evidence programmatically.
        ///Depending on your dispute type, different evidence fields will give you a better chance of winning your dispute. To figure out which evidence fields to provide, see our <a href="/docs/disputes/categories">guide to dispute types</a>.</p>
        let Update settings (formParameters: PostDisputesDisputeParams) (queryParameters: UpdateQueryParams) =
            $"/v1/disputes/{queryParameters.Dispute}"
            |> RestApi.postAsync<_, Dispute> settings formParameters

    module DisputesCloseService =

        type CloseQueryParams = {
            Dispute: string
        }
        with
            static member Create (dispute: string) =
                {
                    Dispute = dispute
                }

        ///<p>Closing the dispute for a charge indicates that you do not have any evidence to submit and are essentially dismissing the dispute, acknowledging it as lost.
        ///The status of the dispute will change from <code>needs_response</code> to <code>lost</code>. <em>Closing a dispute is irreversible</em>.</p>
        let Close settings (formParameters: PostDisputesDisputeCloseParams) (queryParameters: CloseQueryParams) =
            $"/v1/disputes/{queryParameters.Dispute}/close"
            |> RestApi.postAsync<_, Dispute> settings formParameters

    module EphemeralKeysService =

        ///<p>Creates a short-lived API key for a given resource.</p>
        let Create settings (formParameters: PostEphemeralKeysParams) =
            $"/v1/ephemeral_keys"
            |> RestApi.postAsync<_, EphemeralKey> settings formParameters

        type DeleteQueryParams = {
            Key: string
        }
        with
            static member Create (key: string) =
                {
                    Key = key
                }

        ///<p>Invalidates a short-lived API key for a given resource.</p>
        let Delete settings (formParameters: DeleteEphemeralKeysKeyParams) (queryParameters: DeleteQueryParams) =
            $"/v1/ephemeral_keys/{queryParameters.Key}"
            |> RestApi.deleteAsync<EphemeralKey> settings

    module EventsService =

        type ListQueryParams = {
            Created: int option
            DeliverySuccess: bool option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
            ``type``: string option
            Types: string list option
        }
        with
            static member Create (?created: int, ?deliverySuccess: bool, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?``type``: string, ?types: string list) =
                {
                    Created = created
                    DeliverySuccess = deliverySuccess
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                    ``type`` = ``type``
                    Types = types
                }

        ///<p>List events, going back up to 30 days. Each event data is rendered according to Stripe API version at its creation time, specified in <a href="/docs/api/events/object">event object</a> <code>api_version</code> attribute (not according to your current Stripe API version or <code>Stripe-Version</code> header).</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/events?created={queryParameters.Created}&delivery_success={queryParameters.DeliverySuccess}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}&type={queryParameters.``type``}&types={queryParameters.Types}"
            |> RestApi.getAsync<Event list> settings

        type RetrieveQueryParams = {
            Id: string
            Expand: string list option
        }
        with
            static member Create (id: string, ?expand: string list) =
                {
                    Id = id
                    Expand = expand
                }

        ///<p>Retrieves the details of an event. Supply the unique identifier of the event, which you might have received in a webhook.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/events/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Event> settings

    module ExchangeRatesService =

        type ListQueryParams = {
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of objects that contain the rates at which foreign currencies are converted to one another. Only shows the currencies for which Stripe supports.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/exchange_rates?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<ExchangeRate list> settings

        type RetrieveQueryParams = {
            RateId: string
            Expand: string list option
        }
        with
            static member Create (rateId: string, ?expand: string list) =
                {
                    RateId = rateId
                    Expand = expand
                }

        ///<p>Retrieves the exchange rates from the given currency to every supported currency.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/exchange_rates/{queryParameters.RateId}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<ExchangeRate> settings

    module FileLinksService =

        type ListQueryParams = {
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Expired: bool option
            File: string option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?created: int, ?endingBefore: string, ?expand: string list, ?expired: bool, ?file: string, ?limit: int, ?startingAfter: string) =
                {
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Expired = expired
                    File = file
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of file links.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/file_links?created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&expired={queryParameters.Expired}&file={queryParameters.File}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<FileLink list> settings

        ///<p>Creates a new file link object.</p>
        let Create settings (formParameters: PostFileLinksParams) =
            $"/v1/file_links"
            |> RestApi.postAsync<_, FileLink> settings formParameters

        type RetrieveQueryParams = {
            Link: string
            Expand: string list option
        }
        with
            static member Create (link: string, ?expand: string list) =
                {
                    Link = link
                    Expand = expand
                }

        ///<p>Retrieves the file link with the given ID.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/file_links/{queryParameters.Link}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<FileLink> settings

        type UpdateQueryParams = {
            Link: string
        }
        with
            static member Create (link: string) =
                {
                    Link = link
                }

        ///<p>Updates an existing file link object. Expired links can no longer be updated.</p>
        let Update settings (formParameters: PostFileLinksLinkParams) (queryParameters: UpdateQueryParams) =
            $"/v1/file_links/{queryParameters.Link}"
            |> RestApi.postAsync<_, FileLink> settings formParameters

    module FilesService =

        type ListQueryParams = {
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            Purpose: string option
            StartingAfter: string option
        }
        with
            static member Create (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?purpose: string, ?startingAfter: string) =
                {
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    Purpose = purpose
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of the files that your account has access to. The files are returned sorted by creation date, with the most recently created files appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/files?created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&purpose={queryParameters.Purpose}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<File list> settings

        ///<p>To upload a file to Stripe, you’ll need to send a request of type <code>multipart/form-data</code>. The request should contain the file you would like to upload, as well as the parameters for creating a file.
        ///All of Stripe’s officially supported Client libraries should have support for sending <code>multipart/form-data</code>.</p>
        let Create settings =
            $"/v1/files"
            |> RestApi.postWithoutAsync<File> settings

        type RetrieveQueryParams = {
            File: string
            Expand: string list option
        }
        with
            static member Create (file: string, ?expand: string list) =
                {
                    File = file
                    Expand = expand
                }

        ///<p>Retrieves the details of an existing file object. Supply the unique file ID from a file, and Stripe will return the corresponding file object. To access file contents, see the <a href="/docs/file-upload#download-file-contents">File Upload Guide</a>.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/files/{queryParameters.File}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<File> settings

    module InvoiceitemsService =

        type ListQueryParams = {
            Created: int option
            Customer: string option
            EndingBefore: string option
            Expand: string list option
            Invoice: string option
            Limit: int option
            Pending: bool option
            StartingAfter: string option
        }
        with
            static member Create (?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?invoice: string, ?limit: int, ?pending: bool, ?startingAfter: string) =
                {
                    Created = created
                    Customer = customer
                    EndingBefore = endingBefore
                    Expand = expand
                    Invoice = invoice
                    Limit = limit
                    Pending = pending
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of your invoice items. Invoice items are returned sorted by creation date, with the most recently created invoice items appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/invoiceitems?created={queryParameters.Created}&customer={queryParameters.Customer}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&invoice={queryParameters.Invoice}&limit={queryParameters.Limit}&pending={queryParameters.Pending}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<Invoiceitem list> settings

        ///<p>Creates an item to be added to a draft invoice (up to 250 items per invoice). If no invoice is specified, the item will be on the next invoice created for the customer specified.</p>
        let Create settings (formParameters: PostInvoiceitemsParams) =
            $"/v1/invoiceitems"
            |> RestApi.postAsync<_, Invoiceitem> settings formParameters

        type DeleteQueryParams = {
            Invoiceitem: string
        }
        with
            static member Create (invoiceitem: string) =
                {
                    Invoiceitem = invoiceitem
                }

        ///<p>Deletes an invoice item, removing it from an invoice. Deleting invoice items is only possible when they’re not attached to invoices, or if it’s attached to a draft invoice.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/invoiceitems/{queryParameters.Invoiceitem}"
            |> RestApi.deleteAsync<DeletedInvoiceitem> settings

        type RetrieveQueryParams = {
            Invoiceitem: string
            Expand: string list option
        }
        with
            static member Create (invoiceitem: string, ?expand: string list) =
                {
                    Invoiceitem = invoiceitem
                    Expand = expand
                }

        ///<p>Retrieves the invoice item with the given ID.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/invoiceitems/{queryParameters.Invoiceitem}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Invoiceitem> settings

        type UpdateQueryParams = {
            Invoiceitem: string
        }
        with
            static member Create (invoiceitem: string) =
                {
                    Invoiceitem = invoiceitem
                }

        ///<p>Updates the amount or description of an invoice item on an upcoming invoice. Updating an invoice item is only possible before the invoice it’s attached to is closed.</p>
        let Update settings (formParameters: PostInvoiceitemsInvoiceitemParams) (queryParameters: UpdateQueryParams) =
            $"/v1/invoiceitems/{queryParameters.Invoiceitem}"
            |> RestApi.postAsync<_, Invoiceitem> settings formParameters

    module InvoicesService =

        type ListQueryParams = {
            CollectionMethod: string option
            Created: int option
            Customer: string option
            DueDate: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
            Status: string option
            Subscription: string option
        }
        with
            static member Create (?collectionMethod: string, ?created: int, ?customer: string, ?dueDate: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string, ?subscription: string) =
                {
                    CollectionMethod = collectionMethod
                    Created = created
                    Customer = customer
                    DueDate = dueDate
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                    Status = status
                    Subscription = subscription
                }

        ///<p>You can list all invoices, or list the invoices for a specific customer. The invoices are returned sorted by creation date, with the most recently created invoices appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/invoices?collection_method={queryParameters.CollectionMethod}&created={queryParameters.Created}&customer={queryParameters.Customer}&due_date={queryParameters.DueDate}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}&status={queryParameters.Status}&subscription={queryParameters.Subscription}"
            |> RestApi.getAsync<Invoice list> settings

        ///<p>This endpoint creates a draft invoice for a given customer. The draft invoice created pulls in all pending invoice items on that customer, including prorations. The invoice remains a draft until you <a href="#finalize_invoice">finalize</a> the invoice, which allows you to <a href="#pay_invoice">pay</a> or <a href="#send_invoice">send</a> the invoice to your customers.</p>
        let Create settings (formParameters: PostInvoicesParams) =
            $"/v1/invoices"
            |> RestApi.postAsync<_, Invoice> settings formParameters

        type DeleteQueryParams = {
            Invoice: string
        }
        with
            static member Create (invoice: string) =
                {
                    Invoice = invoice
                }

        ///<p>Permanently deletes a one-off invoice draft. This cannot be undone. Attempts to delete invoices that are no longer in a draft state will fail; once an invoice has been finalized or if an invoice is for a subscription, it must be <a href="#void_invoice">voided</a>.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/invoices/{queryParameters.Invoice}"
            |> RestApi.deleteAsync<DeletedInvoice> settings

        type RetrieveQueryParams = {
            Invoice: string
            Expand: string list option
        }
        with
            static member Create (invoice: string, ?expand: string list) =
                {
                    Invoice = invoice
                    Expand = expand
                }

        ///<p>Retrieves the invoice with the given ID.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/invoices/{queryParameters.Invoice}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Invoice> settings

        type UpdateQueryParams = {
            Invoice: string
        }
        with
            static member Create (invoice: string) =
                {
                    Invoice = invoice
                }

        ///<p>Draft invoices are fully editable. Once an invoice is <a href="/docs/billing/invoices/workflow#finalized">finalized</a>,
        ///monetary values, as well as <code>collection_method</code>, become uneditable.
        ///If you would like to stop the Stripe Billing engine from automatically finalizing, reattempting payments on,
        ///sending reminders for, or <a href="/docs/billing/invoices/reconciliation">automatically reconciling</a> invoices, pass
        ///<code>auto_advance=false</code>.</p>
        let Update settings (formParameters: PostInvoicesInvoiceParams) (queryParameters: UpdateQueryParams) =
            $"/v1/invoices/{queryParameters.Invoice}"
            |> RestApi.postAsync<_, Invoice> settings formParameters

    module InvoicesUpcomingService =

        type UpcomingQueryParams = {
            Coupon: string option
            SubscriptionStartDate: int option
            SubscriptionProrationDate: int option
            SubscriptionProrationBehavior: string option
            SubscriptionItems: string list option
            SubscriptionDefaultTaxRates: string list option
            SubscriptionCancelNow: bool option
            SubscriptionCancelAtPeriodEnd: bool option
            SubscriptionCancelAt: int option
            SubscriptionBillingCycleAnchor: string option
            Subscription: string option
            Schedule: string option
            InvoiceItems: string list option
            Expand: string list option
            Discounts: string list option
            Customer: string option
            SubscriptionTrialEnd: string option
            SubscriptionTrialFromPlan: bool option
        }
        with
            static member Create (?coupon: string, ?subscriptionStartDate: int, ?subscriptionProrationDate: int, ?subscriptionProrationBehavior: string, ?subscriptionItems: string list, ?subscriptionDefaultTaxRates: string list, ?subscriptionCancelNow: bool, ?subscriptionCancelAtPeriodEnd: bool, ?subscriptionCancelAt: int, ?subscriptionBillingCycleAnchor: string, ?subscription: string, ?schedule: string, ?invoiceItems: string list, ?expand: string list, ?discounts: string list, ?customer: string, ?subscriptionTrialEnd: string, ?subscriptionTrialFromPlan: bool) =
                {
                    Coupon = coupon
                    SubscriptionStartDate = subscriptionStartDate
                    SubscriptionProrationDate = subscriptionProrationDate
                    SubscriptionProrationBehavior = subscriptionProrationBehavior
                    SubscriptionItems = subscriptionItems
                    SubscriptionDefaultTaxRates = subscriptionDefaultTaxRates
                    SubscriptionCancelNow = subscriptionCancelNow
                    SubscriptionCancelAtPeriodEnd = subscriptionCancelAtPeriodEnd
                    SubscriptionCancelAt = subscriptionCancelAt
                    SubscriptionBillingCycleAnchor = subscriptionBillingCycleAnchor
                    Subscription = subscription
                    Schedule = schedule
                    InvoiceItems = invoiceItems
                    Expand = expand
                    Discounts = discounts
                    Customer = customer
                    SubscriptionTrialEnd = subscriptionTrialEnd
                    SubscriptionTrialFromPlan = subscriptionTrialFromPlan
                }

        ///<p>At any time, you can preview the upcoming invoice for a customer. This will show you all the charges that are pending, including subscription renewal charges, invoice item charges, etc. It will also show you any discounts that are applicable to the invoice.
        ///Note that when you are viewing an upcoming invoice, you are simply viewing a preview – the invoice has not yet been created. As such, the upcoming invoice will not show up in invoice listing calls, and you cannot use the API to pay or edit the invoice. If you want to change the amount that your customer will be billed, you can add, remove, or update pending invoice items, or update the customer’s discount.
        ///You can preview the effects of updating a subscription, including a preview of what proration will take place. To ensure that the actual proration is calculated exactly the same as the previewed proration, you should pass a <code>proration_date</code> parameter when doing the actual subscription update. The value passed in should be the same as the <code>subscription_proration_date</code> returned on the upcoming invoice resource. The recommended way to get only the prorations being previewed is to consider only proration line items where <code>period[start]</code> is equal to the <code>subscription_proration_date</code> on the upcoming invoice resource.</p>
        let Upcoming settings (queryParameters: UpcomingQueryParams) =
            $"/v1/invoices/upcoming?coupon={queryParameters.Coupon}&subscription_start_date={queryParameters.SubscriptionStartDate}&subscription_proration_date={queryParameters.SubscriptionProrationDate}&subscription_proration_behavior={queryParameters.SubscriptionProrationBehavior}&subscription_items={queryParameters.SubscriptionItems}&subscription_default_tax_rates={queryParameters.SubscriptionDefaultTaxRates}&subscription_cancel_now={queryParameters.SubscriptionCancelNow}&subscription_cancel_at_period_end={queryParameters.SubscriptionCancelAtPeriodEnd}&subscription_cancel_at={queryParameters.SubscriptionCancelAt}&subscription_billing_cycle_anchor={queryParameters.SubscriptionBillingCycleAnchor}&subscription={queryParameters.Subscription}&schedule={queryParameters.Schedule}&invoice_items={queryParameters.InvoiceItems}&expand={queryParameters.Expand}&discounts={queryParameters.Discounts}&customer={queryParameters.Customer}&subscription_trial_end={queryParameters.SubscriptionTrialEnd}&subscription_trial_from_plan={queryParameters.SubscriptionTrialFromPlan}"
            |> RestApi.getAsync<Invoice> settings

    module InvoicesUpcomingLinesService =

        type UpcomingLinesQueryParams = {
            Coupon: string option
            SubscriptionStartDate: int option
            SubscriptionProrationDate: int option
            SubscriptionProrationBehavior: string option
            SubscriptionItems: string list option
            SubscriptionDefaultTaxRates: string list option
            SubscriptionCancelNow: bool option
            SubscriptionCancelAtPeriodEnd: bool option
            SubscriptionCancelAt: int option
            SubscriptionTrialEnd: string option
            SubscriptionBillingCycleAnchor: string option
            StartingAfter: string option
            Schedule: string option
            Limit: int option
            InvoiceItems: string list option
            Expand: string list option
            EndingBefore: string option
            Discounts: string list option
            Customer: string option
            Subscription: string option
            SubscriptionTrialFromPlan: bool option
        }
        with
            static member Create (?coupon: string, ?subscriptionStartDate: int, ?subscriptionProrationDate: int, ?subscriptionProrationBehavior: string, ?subscriptionItems: string list, ?subscriptionDefaultTaxRates: string list, ?subscriptionCancelNow: bool, ?subscriptionCancelAtPeriodEnd: bool, ?subscriptionCancelAt: int, ?subscriptionTrialEnd: string, ?subscriptionBillingCycleAnchor: string, ?startingAfter: string, ?schedule: string, ?limit: int, ?invoiceItems: string list, ?expand: string list, ?endingBefore: string, ?discounts: string list, ?customer: string, ?subscription: string, ?subscriptionTrialFromPlan: bool) =
                {
                    Coupon = coupon
                    SubscriptionStartDate = subscriptionStartDate
                    SubscriptionProrationDate = subscriptionProrationDate
                    SubscriptionProrationBehavior = subscriptionProrationBehavior
                    SubscriptionItems = subscriptionItems
                    SubscriptionDefaultTaxRates = subscriptionDefaultTaxRates
                    SubscriptionCancelNow = subscriptionCancelNow
                    SubscriptionCancelAtPeriodEnd = subscriptionCancelAtPeriodEnd
                    SubscriptionCancelAt = subscriptionCancelAt
                    SubscriptionTrialEnd = subscriptionTrialEnd
                    SubscriptionBillingCycleAnchor = subscriptionBillingCycleAnchor
                    StartingAfter = startingAfter
                    Schedule = schedule
                    Limit = limit
                    InvoiceItems = invoiceItems
                    Expand = expand
                    EndingBefore = endingBefore
                    Discounts = discounts
                    Customer = customer
                    Subscription = subscription
                    SubscriptionTrialFromPlan = subscriptionTrialFromPlan
                }

        ///<p>When retrieving an upcoming invoice, you’ll get a <strong>lines</strong> property containing the total count of line items and the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
        let UpcomingLines settings (queryParameters: UpcomingLinesQueryParams) =
            $"/v1/invoices/upcoming/lines?coupon={queryParameters.Coupon}&subscription_start_date={queryParameters.SubscriptionStartDate}&subscription_proration_date={queryParameters.SubscriptionProrationDate}&subscription_proration_behavior={queryParameters.SubscriptionProrationBehavior}&subscription_items={queryParameters.SubscriptionItems}&subscription_default_tax_rates={queryParameters.SubscriptionDefaultTaxRates}&subscription_cancel_now={queryParameters.SubscriptionCancelNow}&subscription_cancel_at_period_end={queryParameters.SubscriptionCancelAtPeriodEnd}&subscription_cancel_at={queryParameters.SubscriptionCancelAt}&subscription_trial_end={queryParameters.SubscriptionTrialEnd}&subscription_billing_cycle_anchor={queryParameters.SubscriptionBillingCycleAnchor}&starting_after={queryParameters.StartingAfter}&schedule={queryParameters.Schedule}&limit={queryParameters.Limit}&invoice_items={queryParameters.InvoiceItems}&expand={queryParameters.Expand}&ending_before={queryParameters.EndingBefore}&discounts={queryParameters.Discounts}&customer={queryParameters.Customer}&subscription={queryParameters.Subscription}&subscription_trial_from_plan={queryParameters.SubscriptionTrialFromPlan}"
            |> RestApi.getAsync<LineItem list> settings

    module InvoicesFinalizeService =

        type FinalizeInvoiceQueryParams = {
            Invoice: string
        }
        with
            static member Create (invoice: string) =
                {
                    Invoice = invoice
                }

        ///<p>Stripe automatically finalizes drafts before sending and attempting payment on invoices. However, if you’d like to finalize a draft invoice manually, you can do so using this method.</p>
        let FinalizeInvoice settings (formParameters: PostInvoicesInvoiceFinalizeParams) (queryParameters: FinalizeInvoiceQueryParams) =
            $"/v1/invoices/{queryParameters.Invoice}/finalize"
            |> RestApi.postAsync<_, Invoice> settings formParameters

    module InvoicesLinesService =

        type ListQueryParams = {
            Invoice: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (invoice: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Invoice = invoice
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>When retrieving an invoice, you’ll get a <strong>lines</strong> property containing the total count of line items and the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/invoices/{queryParameters.Invoice}/lines?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<LineItem list> settings

    module InvoicesMarkUncollectibleService =

        type MarkUncollectibleQueryParams = {
            Invoice: string
        }
        with
            static member Create (invoice: string) =
                {
                    Invoice = invoice
                }

        ///<p>Marking an invoice as uncollectible is useful for keeping track of bad debts that can be written off for accounting purposes.</p>
        let MarkUncollectible settings (formParameters: PostInvoicesInvoiceMarkUncollectibleParams) (queryParameters: MarkUncollectibleQueryParams) =
            $"/v1/invoices/{queryParameters.Invoice}/mark_uncollectible"
            |> RestApi.postAsync<_, Invoice> settings formParameters

    module InvoicesPayService =

        type PayQueryParams = {
            Invoice: string
        }
        with
            static member Create (invoice: string) =
                {
                    Invoice = invoice
                }

        ///<p>Stripe automatically creates and then attempts to collect payment on invoices for customers on subscriptions according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to attempt payment on an invoice out of the normal collection schedule or for some other reason, you can do so.</p>
        let Pay settings (formParameters: PostInvoicesInvoicePayParams) (queryParameters: PayQueryParams) =
            $"/v1/invoices/{queryParameters.Invoice}/pay"
            |> RestApi.postAsync<_, Invoice> settings formParameters

    module InvoicesSendService =

        type SendInvoiceQueryParams = {
            Invoice: string
        }
        with
            static member Create (invoice: string) =
                {
                    Invoice = invoice
                }

        ///<p>Stripe will automatically send invoices to customers according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to manually send an invoice to your customer out of the normal schedule, you can do so. When sending invoices that have already been paid, there will be no reference to the payment in the email.
        ///Requests made in test-mode result in no emails being sent, despite sending an <code>invoice.sent</code> event.</p>
        let SendInvoice settings (formParameters: PostInvoicesInvoiceSendParams) (queryParameters: SendInvoiceQueryParams) =
            $"/v1/invoices/{queryParameters.Invoice}/send"
            |> RestApi.postAsync<_, Invoice> settings formParameters

    module InvoicesVoidService =

        type VoidInvoiceQueryParams = {
            Invoice: string
        }
        with
            static member Create (invoice: string) =
                {
                    Invoice = invoice
                }

        ///<p>Mark a finalized invoice as void. This cannot be undone. Voiding an invoice is similar to <a href="#delete_invoice">deletion</a>, however it only applies to finalized invoices and maintains a papertrail where the invoice can still be found.</p>
        let VoidInvoice settings (formParameters: PostInvoicesInvoiceVoidParams) (queryParameters: VoidInvoiceQueryParams) =
            $"/v1/invoices/{queryParameters.Invoice}/void"
            |> RestApi.postAsync<_, Invoice> settings formParameters

    module IssuerFraudRecordsService =

        type ListQueryParams = {
            Charge: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?charge: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Charge = charge
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of issuer fraud records.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/issuer_fraud_records?charge={queryParameters.Charge}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<IssuerFraudRecord list> settings

        type RetrieveQueryParams = {
            IssuerFraudRecord: string
            Expand: string list option
        }
        with
            static member Create (issuerFraudRecord: string, ?expand: string list) =
                {
                    IssuerFraudRecord = issuerFraudRecord
                    Expand = expand
                }

        ///<p>Retrieves the details of an issuer fraud record that has previously been created. 
        ///Please refer to the <a href="#issuer_fraud_record_object">issuer fraud record</a> object reference for more details.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/issuer_fraud_records/{queryParameters.IssuerFraudRecord}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<IssuerFraudRecord> settings

    module IssuingAuthorizationsService =

        type ListQueryParams = {
            Card: string option
            Cardholder: string option
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
            Status: string option
        }
        with
            static member Create (?card: string, ?cardholder: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
                {
                    Card = card
                    Cardholder = cardholder
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                    Status = status
                }

        ///<p>Returns a list of Issuing <code>Authorization</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/issuing/authorizations?card={queryParameters.Card}&cardholder={queryParameters.Cardholder}&created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}&status={queryParameters.Status}"
            |> RestApi.getAsync<IssuingAuthorization list> settings

        type RetrieveQueryParams = {
            Authorization: string
            Expand: string list option
        }
        with
            static member Create (authorization: string, ?expand: string list) =
                {
                    Authorization = authorization
                    Expand = expand
                }

        ///<p>Retrieves an Issuing <code>Authorization</code> object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/issuing/authorizations/{queryParameters.Authorization}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<IssuingAuthorization> settings

        type UpdateQueryParams = {
            Authorization: string
        }
        with
            static member Create (authorization: string) =
                {
                    Authorization = authorization
                }

        ///<p>Updates the specified Issuing <code>Authorization</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formParameters: PostIssuingAuthorizationsAuthorizationParams) (queryParameters: UpdateQueryParams) =
            $"/v1/issuing/authorizations/{queryParameters.Authorization}"
            |> RestApi.postAsync<_, IssuingAuthorization> settings formParameters

    module IssuingAuthorizationsApproveService =

        type ApproveQueryParams = {
            Authorization: string
        }
        with
            static member Create (authorization: string) =
                {
                    Authorization = authorization
                }

        ///<p>Approves a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real-time authorization</a> flow.</p>
        let Approve settings (formParameters: PostIssuingAuthorizationsAuthorizationApproveParams) (queryParameters: ApproveQueryParams) =
            $"/v1/issuing/authorizations/{queryParameters.Authorization}/approve"
            |> RestApi.postAsync<_, IssuingAuthorization> settings formParameters

    module IssuingAuthorizationsDeclineService =

        type DeclineQueryParams = {
            Authorization: string
        }
        with
            static member Create (authorization: string) =
                {
                    Authorization = authorization
                }

        ///<p>Declines a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real time authorization</a> flow.</p>
        let Decline settings (formParameters: PostIssuingAuthorizationsAuthorizationDeclineParams) (queryParameters: DeclineQueryParams) =
            $"/v1/issuing/authorizations/{queryParameters.Authorization}/decline"
            |> RestApi.postAsync<_, IssuingAuthorization> settings formParameters

    module IssuingCardholdersService =

        type ListQueryParams = {
            Created: int option
            Email: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            PhoneNumber: string option
            StartingAfter: string option
            Status: string option
            ``type``: string option
        }
        with
            static member Create (?created: int, ?email: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?phoneNumber: string, ?startingAfter: string, ?status: string, ?``type``: string) =
                {
                    Created = created
                    Email = email
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    PhoneNumber = phoneNumber
                    StartingAfter = startingAfter
                    Status = status
                    ``type`` = ``type``
                }

        ///<p>Returns a list of Issuing <code>Cardholder</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/issuing/cardholders?created={queryParameters.Created}&email={queryParameters.Email}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&phone_number={queryParameters.PhoneNumber}&starting_after={queryParameters.StartingAfter}&status={queryParameters.Status}&type={queryParameters.``type``}"
            |> RestApi.getAsync<IssuingCardholder list> settings

        ///<p>Creates a new Issuing <code>Cardholder</code> object that can be issued cards.</p>
        let Create settings (formParameters: PostIssuingCardholdersParams) =
            $"/v1/issuing/cardholders"
            |> RestApi.postAsync<_, IssuingCardholder> settings formParameters

        type RetrieveQueryParams = {
            Cardholder: string
            Expand: string list option
        }
        with
            static member Create (cardholder: string, ?expand: string list) =
                {
                    Cardholder = cardholder
                    Expand = expand
                }

        ///<p>Retrieves an Issuing <code>Cardholder</code> object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/issuing/cardholders/{queryParameters.Cardholder}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<IssuingCardholder> settings

        type UpdateQueryParams = {
            Cardholder: string
        }
        with
            static member Create (cardholder: string) =
                {
                    Cardholder = cardholder
                }

        ///<p>Updates the specified Issuing <code>Cardholder</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formParameters: PostIssuingCardholdersCardholderParams) (queryParameters: UpdateQueryParams) =
            $"/v1/issuing/cardholders/{queryParameters.Cardholder}"
            |> RestApi.postAsync<_, IssuingCardholder> settings formParameters

    module IssuingCardsService =

        type ListQueryParams = {
            Cardholder: string option
            Created: int option
            EndingBefore: string option
            ExpMonth: int option
            ExpYear: int option
            Expand: string list option
            Last4: string option
            Limit: int option
            StartingAfter: string option
            Status: string option
            ``type``: string option
        }
        with
            static member Create (?cardholder: string, ?created: int, ?endingBefore: string, ?expMonth: int, ?expYear: int, ?expand: string list, ?last4: string, ?limit: int, ?startingAfter: string, ?status: string, ?``type``: string) =
                {
                    Cardholder = cardholder
                    Created = created
                    EndingBefore = endingBefore
                    ExpMonth = expMonth
                    ExpYear = expYear
                    Expand = expand
                    Last4 = last4
                    Limit = limit
                    StartingAfter = startingAfter
                    Status = status
                    ``type`` = ``type``
                }

        ///<p>Returns a list of Issuing <code>Card</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/issuing/cards?cardholder={queryParameters.Cardholder}&created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&exp_month={queryParameters.ExpMonth}&exp_year={queryParameters.ExpYear}&expand={queryParameters.Expand}&last4={queryParameters.Last4}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}&status={queryParameters.Status}&type={queryParameters.``type``}"
            |> RestApi.getAsync<IssuingCard list> settings

        ///<p>Creates an Issuing <code>Card</code> object.</p>
        let Create settings (formParameters: PostIssuingCardsParams) =
            $"/v1/issuing/cards"
            |> RestApi.postAsync<_, IssuingCard> settings formParameters

        type RetrieveQueryParams = {
            Card: string
            Expand: string list option
        }
        with
            static member Create (card: string, ?expand: string list) =
                {
                    Card = card
                    Expand = expand
                }

        ///<p>Retrieves an Issuing <code>Card</code> object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/issuing/cards/{queryParameters.Card}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<IssuingCard> settings

        type UpdateQueryParams = {
            Card: string
        }
        with
            static member Create (card: string) =
                {
                    Card = card
                }

        ///<p>Updates the specified Issuing <code>Card</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formParameters: PostIssuingCardsCardParams) (queryParameters: UpdateQueryParams) =
            $"/v1/issuing/cards/{queryParameters.Card}"
            |> RestApi.postAsync<_, IssuingCard> settings formParameters

    module IssuingDisputesService =

        type ListQueryParams = {
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
            Status: string option
            Transaction: string option
        }
        with
            static member Create (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string, ?transaction: string) =
                {
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                    Status = status
                    Transaction = transaction
                }

        ///<p>Returns a list of Issuing <code>Dispute</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/issuing/disputes?created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}&status={queryParameters.Status}&transaction={queryParameters.Transaction}"
            |> RestApi.getAsync<IssuingDispute list> settings

        ///<p>Creates an Issuing <code>Dispute</code> object. Individual pieces of evidence within the <code>evidence</code> object are optional at this point. Stripe only validates that required evidence is present during submission. Refer to <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a> for more details about evidence requirements.</p>
        let Create settings (formParameters: PostIssuingDisputesParams) =
            $"/v1/issuing/disputes"
            |> RestApi.postAsync<_, IssuingDispute> settings formParameters

        type RetrieveQueryParams = {
            Dispute: string
            Expand: string list option
        }
        with
            static member Create (dispute: string, ?expand: string list) =
                {
                    Dispute = dispute
                    Expand = expand
                }

        ///<p>Retrieves an Issuing <code>Dispute</code> object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/issuing/disputes/{queryParameters.Dispute}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<IssuingDispute> settings

        type UpdateQueryParams = {
            Dispute: string
        }
        with
            static member Create (dispute: string) =
                {
                    Dispute = dispute
                }

        ///<p>Updates the specified Issuing <code>Dispute</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Properties on the <code>evidence</code> object can be unset by passing in an empty string.</p>
        let Update settings (formParameters: PostIssuingDisputesDisputeParams) (queryParameters: UpdateQueryParams) =
            $"/v1/issuing/disputes/{queryParameters.Dispute}"
            |> RestApi.postAsync<_, IssuingDispute> settings formParameters

    module IssuingDisputesSubmitService =

        type SubmitQueryParams = {
            Dispute: string
        }
        with
            static member Create (dispute: string) =
                {
                    Dispute = dispute
                }

        ///<p>Submits an Issuing <code>Dispute</code> to the card network. Stripe validates that all evidence fields required for the dispute’s reason are present. For more details, see <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a>.</p>
        let Submit settings (formParameters: PostIssuingDisputesDisputeSubmitParams) (queryParameters: SubmitQueryParams) =
            $"/v1/issuing/disputes/{queryParameters.Dispute}/submit"
            |> RestApi.postAsync<_, IssuingDispute> settings formParameters

    module IssuingTransactionsService =

        type ListQueryParams = {
            Card: string option
            Cardholder: string option
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?card: string, ?cardholder: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Card = card
                    Cardholder = cardholder
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of Issuing <code>Transaction</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/issuing/transactions?card={queryParameters.Card}&cardholder={queryParameters.Cardholder}&created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<IssuingTransaction list> settings

        type RetrieveQueryParams = {
            Transaction: string
            Expand: string list option
        }
        with
            static member Create (transaction: string, ?expand: string list) =
                {
                    Transaction = transaction
                    Expand = expand
                }

        ///<p>Retrieves an Issuing <code>Transaction</code> object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/issuing/transactions/{queryParameters.Transaction}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<IssuingTransaction> settings

        type UpdateQueryParams = {
            Transaction: string
        }
        with
            static member Create (transaction: string) =
                {
                    Transaction = transaction
                }

        ///<p>Updates the specified Issuing <code>Transaction</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formParameters: PostIssuingTransactionsTransactionParams) (queryParameters: UpdateQueryParams) =
            $"/v1/issuing/transactions/{queryParameters.Transaction}"
            |> RestApi.postAsync<_, IssuingTransaction> settings formParameters

    module MandatesService =

        type RetrieveQueryParams = {
            Mandate: string
            Expand: string list option
        }
        with
            static member Create (mandate: string, ?expand: string list) =
                {
                    Mandate = mandate
                    Expand = expand
                }

        ///<p>Retrieves a Mandate object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/mandates/{queryParameters.Mandate}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Mandate> settings

    module OrderReturnsService =

        type ListQueryParams = {
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            Order: string option
            StartingAfter: string option
        }
        with
            static member Create (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?order: string, ?startingAfter: string) =
                {
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    Order = order
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of your order returns. The returns are returned sorted by creation date, with the most recently created return appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/order_returns?created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&order={queryParameters.Order}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<OrderReturn list> settings

        type RetrieveQueryParams = {
            Id: string
            Expand: string list option
        }
        with
            static member Create (id: string, ?expand: string list) =
                {
                    Id = id
                    Expand = expand
                }

        ///<p>Retrieves the details of an existing order return. Supply the unique order ID from either an order return creation request or the order return list, and Stripe will return the corresponding order information.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/order_returns/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<OrderReturn> settings

    module OrdersService =

        type ListQueryParams = {
            Created: int option
            Customer: string option
            EndingBefore: string option
            Expand: string list option
            Ids: string list option
            Limit: int option
            StartingAfter: string option
            Status: string option
            StatusTransitions: Map<string, string> option
            UpstreamIds: string list option
        }
        with
            static member Create (?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?ids: string list, ?limit: int, ?startingAfter: string, ?status: string, ?statusTransitions: Map<string, string>, ?upstreamIds: string list) =
                {
                    Created = created
                    Customer = customer
                    EndingBefore = endingBefore
                    Expand = expand
                    Ids = ids
                    Limit = limit
                    StartingAfter = startingAfter
                    Status = status
                    StatusTransitions = statusTransitions
                    UpstreamIds = upstreamIds
                }

        ///<p>Returns a list of your orders. The orders are returned sorted by creation date, with the most recently created orders appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/orders?created={queryParameters.Created}&customer={queryParameters.Customer}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&ids={queryParameters.Ids}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}&status={queryParameters.Status}&status_transitions={queryParameters.StatusTransitions}&upstream_ids={queryParameters.UpstreamIds}"
            |> RestApi.getAsync<Order list> settings

        ///<p>Creates a new order object.</p>
        let Create settings (formParameters: PostOrdersParams) =
            $"/v1/orders"
            |> RestApi.postAsync<_, Order> settings formParameters

        type RetrieveQueryParams = {
            Id: string
            Expand: string list option
        }
        with
            static member Create (id: string, ?expand: string list) =
                {
                    Id = id
                    Expand = expand
                }

        ///<p>Retrieves the details of an existing order. Supply the unique order ID from either an order creation request or the order list, and Stripe will return the corresponding order information.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/orders/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Order> settings

        type UpdateQueryParams = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Updates the specific order by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formParameters: PostOrdersIdParams) (queryParameters: UpdateQueryParams) =
            $"/v1/orders/{queryParameters.Id}"
            |> RestApi.postAsync<_, Order> settings formParameters

    module OrdersPayService =

        type PayQueryParams = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Pay an order by providing a <code>source</code> to create a payment.</p>
        let Pay settings (formParameters: PostOrdersIdPayParams) (queryParameters: PayQueryParams) =
            $"/v1/orders/{queryParameters.Id}/pay"
            |> RestApi.postAsync<_, Order> settings formParameters

    module OrdersReturnsService =

        type ReturnOrderQueryParams = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Return all or part of an order. The order must have a status of <code>paid</code> or <code>fulfilled</code> before it can be returned. Once all items have been returned, the order will become <code>canceled</code> or <code>returned</code> depending on which status the order started in.</p>
        let ReturnOrder settings (formParameters: PostOrdersIdReturnsParams) (queryParameters: ReturnOrderQueryParams) =
            $"/v1/orders/{queryParameters.Id}/returns"
            |> RestApi.postAsync<_, OrderReturn> settings formParameters

    module PaymentIntentsService =

        type ListQueryParams = {
            Created: int option
            Customer: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Created = created
                    Customer = customer
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of PaymentIntents.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/payment_intents?created={queryParameters.Created}&customer={queryParameters.Customer}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<PaymentIntent list> settings

        ///<p>Creates a PaymentIntent object.
        ///After the PaymentIntent is created, attach a payment method and <a href="/docs/api/payment_intents/confirm">confirm</a>
        ///to continue the payment. You can read more about the different payment flows
        ///available via the Payment Intents API <a href="/docs/payments/payment-intents">here</a>.
        ///When <code>confirm=true</code> is used during creation, it is equivalent to creating
        ///and confirming the PaymentIntent in the same call. You may use any parameters
        ///available in the <a href="/docs/api/payment_intents/confirm">confirm API</a> when <code>confirm=true</code>
        ///is supplied.</p>
        let Create settings (formParameters: PostPaymentIntentsParams) =
            $"/v1/payment_intents"
            |> RestApi.postAsync<_, PaymentIntent> settings formParameters

        type RetrieveQueryParams = {
            Intent: string
            Expand: string list option
            ClientSecret: string option
        }
        with
            static member Create (intent: string, ?expand: string list, ?clientSecret: string) =
                {
                    Intent = intent
                    Expand = expand
                    ClientSecret = clientSecret
                }

        ///<p>Retrieves the details of a PaymentIntent that has previously been created. 
        ///Client-side retrieval using a publishable key is allowed when the <code>client_secret</code> is provided in the query string. 
        ///When retrieved with a publishable key, only a subset of properties will be returned. Please refer to the <a href="#payment_intent_object">payment intent</a> object reference for more details.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/payment_intents/{queryParameters.Intent}?client_secret={queryParameters.ClientSecret}&expand={queryParameters.Expand}"
            |> RestApi.getAsync<PaymentIntent> settings

        type UpdateQueryParams = {
            Intent: string
        }
        with
            static member Create (intent: string) =
                {
                    Intent = intent
                }

        ///<p>Updates properties on a PaymentIntent object without confirming.
        ///Depending on which properties you update, you may need to confirm the
        ///PaymentIntent again. For example, updating the <code>payment_method</code> will
        ///always require you to confirm the PaymentIntent again. If you prefer to
        ///update and confirm at the same time, we recommend updating properties via
        ///the <a href="/docs/api/payment_intents/confirm">confirm API</a> instead.</p>
        let Update settings (formParameters: PostPaymentIntentsIntentParams) (queryParameters: UpdateQueryParams) =
            $"/v1/payment_intents/{queryParameters.Intent}"
            |> RestApi.postAsync<_, PaymentIntent> settings formParameters

    module PaymentIntentsCancelService =

        type CancelQueryParams = {
            Intent: string
        }
        with
            static member Create (intent: string) =
                {
                    Intent = intent
                }

        ///<p>A PaymentIntent object can be canceled when it is in one of these statuses: <code>requires_payment_method</code>, <code>requires_capture</code>, <code>requires_confirmation</code>, or <code>requires_action</code>. 
        ///Once canceled, no additional charges will be made by the PaymentIntent and any operations on the PaymentIntent will fail with an error. For PaymentIntents with <code>status=’requires_capture’</code>, the remaining <code>amount_capturable</code> will automatically be refunded.</p>
        let Cancel settings (formParameters: PostPaymentIntentsIntentCancelParams) (queryParameters: CancelQueryParams) =
            $"/v1/payment_intents/{queryParameters.Intent}/cancel"
            |> RestApi.postAsync<_, PaymentIntent> settings formParameters

    module PaymentIntentsCaptureService =

        type CaptureQueryParams = {
            Intent: string
        }
        with
            static member Create (intent: string) =
                {
                    Intent = intent
                }

        ///<p>Capture the funds of an existing uncaptured PaymentIntent when its status is <code>requires_capture</code>.
        ///Uncaptured PaymentIntents will be canceled exactly seven days after they are created.
        ///Learn more about <a href="/docs/payments/capture-later">separate authorization and capture</a>.</p>
        let Capture settings (formParameters: PostPaymentIntentsIntentCaptureParams) (queryParameters: CaptureQueryParams) =
            $"/v1/payment_intents/{queryParameters.Intent}/capture"
            |> RestApi.postAsync<_, PaymentIntent> settings formParameters

    module PaymentIntentsConfirmService =

        type ConfirmQueryParams = {
            Intent: string
        }
        with
            static member Create (intent: string) =
                {
                    Intent = intent
                }

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
        let Confirm settings (formParameters: PostPaymentIntentsIntentConfirmParams) (queryParameters: ConfirmQueryParams) =
            $"/v1/payment_intents/{queryParameters.Intent}/confirm"
            |> RestApi.postAsync<_, PaymentIntent> settings formParameters

    module PaymentMethodsService =

        type ListQueryParams = {
            Customer: string
            ``type``: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (customer: string, ``type``: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Customer = customer
                    ``type`` = ``type``
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of PaymentMethods for a given Customer</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/payment_methods?customer={queryParameters.Customer}&type={queryParameters.``type``}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<PaymentMethod list> settings

        ///<p>Creates a PaymentMethod object. Read the <a href="/docs/stripe-js/reference#stripe-create-payment-method">Stripe.js reference</a> to learn how to create PaymentMethods via Stripe.js.</p>
        let Create settings (formParameters: PostPaymentMethodsParams) =
            $"/v1/payment_methods"
            |> RestApi.postAsync<_, PaymentMethod> settings formParameters

        type RetrieveQueryParams = {
            PaymentMethod: string
            Expand: string list option
        }
        with
            static member Create (paymentMethod: string, ?expand: string list) =
                {
                    PaymentMethod = paymentMethod
                    Expand = expand
                }

        ///<p>Retrieves a PaymentMethod object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/payment_methods/{queryParameters.PaymentMethod}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<PaymentMethod> settings

        type UpdateQueryParams = {
            PaymentMethod: string
        }
        with
            static member Create (paymentMethod: string) =
                {
                    PaymentMethod = paymentMethod
                }

        ///<p>Updates a PaymentMethod object. A PaymentMethod must be attached a customer to be updated.</p>
        let Update settings (formParameters: PostPaymentMethodsPaymentMethodParams) (queryParameters: UpdateQueryParams) =
            $"/v1/payment_methods/{queryParameters.PaymentMethod}"
            |> RestApi.postAsync<_, PaymentMethod> settings formParameters

    module PaymentMethodsAttachService =

        type AttachQueryParams = {
            PaymentMethod: string
        }
        with
            static member Create (paymentMethod: string) =
                {
                    PaymentMethod = paymentMethod
                }

        ///<p>Attaches a PaymentMethod object to a Customer.
        ///To attach a new PaymentMethod to a customer for future payments, we recommend you use a <a href="/docs/api/setup_intents">SetupIntent</a>
        ///or a PaymentIntent with <a href="/docs/api/payment_intents/create#create_payment_intent-setup_future_usage">setup_future_usage</a>.
        ///These approaches will perform any necessary steps to ensure that the PaymentMethod can be used in a future payment. Using the
        ///<code>/v1/payment_methods/:id/attach</code> endpoint does not ensure that future payments can be made with the attached PaymentMethod.
        ///See <a href="/docs/payments/payment-intents#future-usage">Optimizing cards for future payments</a> for more information about setting up future payments.
        ///To use this PaymentMethod as the default for invoice or subscription payments,
        ///set <a href="/docs/api/customers/update#update_customer-invoice_settings-default_payment_method"><code>invoice_settings.default_payment_method</code></a>,
        ///on the Customer to the PaymentMethod’s ID.</p>
        let Attach settings (formParameters: PostPaymentMethodsPaymentMethodAttachParams) (queryParameters: AttachQueryParams) =
            $"/v1/payment_methods/{queryParameters.PaymentMethod}/attach"
            |> RestApi.postAsync<_, PaymentMethod> settings formParameters

    module PaymentMethodsDetachService =

        type DetachQueryParams = {
            PaymentMethod: string
        }
        with
            static member Create (paymentMethod: string) =
                {
                    PaymentMethod = paymentMethod
                }

        ///<p>Detaches a PaymentMethod object from a Customer.</p>
        let Detach settings (formParameters: PostPaymentMethodsPaymentMethodDetachParams) (queryParameters: DetachQueryParams) =
            $"/v1/payment_methods/{queryParameters.PaymentMethod}/detach"
            |> RestApi.postAsync<_, PaymentMethod> settings formParameters

    module PayoutsService =

        type ListQueryParams = {
            ArrivalDate: int option
            Created: int option
            Destination: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
            Status: string option
        }
        with
            static member Create (?arrivalDate: int, ?created: int, ?destination: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
                {
                    ArrivalDate = arrivalDate
                    Created = created
                    Destination = destination
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                    Status = status
                }

        ///<p>Returns a list of existing payouts sent to third-party bank accounts or that Stripe has sent you. The payouts are returned in sorted order, with the most recently created payouts appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/payouts?arrival_date={queryParameters.ArrivalDate}&created={queryParameters.Created}&destination={queryParameters.Destination}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}&status={queryParameters.Status}"
            |> RestApi.getAsync<Payout list> settings

        ///<p>To send funds to your own bank account, you create a new payout object. Your <a href="#balance">Stripe balance</a> must be able to cover the payout amount, or you’ll receive an “Insufficient Funds” error.
        ///If your API key is in test mode, money won’t actually be sent, though everything else will occur as if in live mode.
        ///If you are creating a manual payout on a Stripe account that uses multiple payment source types, you’ll need to specify the source type balance that the payout should draw from. The <a href="#balance_object">balance object</a> details available and pending amounts by source type.</p>
        let Create settings (formParameters: PostPayoutsParams) =
            $"/v1/payouts"
            |> RestApi.postAsync<_, Payout> settings formParameters

        type RetrieveQueryParams = {
            Payout: string
            Expand: string list option
        }
        with
            static member Create (payout: string, ?expand: string list) =
                {
                    Payout = payout
                    Expand = expand
                }

        ///<p>Retrieves the details of an existing payout. Supply the unique payout ID from either a payout creation request or the payout list, and Stripe will return the corresponding payout information.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/payouts/{queryParameters.Payout}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Payout> settings

        type UpdateQueryParams = {
            Payout: string
        }
        with
            static member Create (payout: string) =
                {
                    Payout = payout
                }

        ///<p>Updates the specified payout by setting the values of the parameters passed. Any parameters not provided will be left unchanged. This request accepts only the metadata as arguments.</p>
        let Update settings (formParameters: PostPayoutsPayoutParams) (queryParameters: UpdateQueryParams) =
            $"/v1/payouts/{queryParameters.Payout}"
            |> RestApi.postAsync<_, Payout> settings formParameters

    module PayoutsCancelService =

        type CancelQueryParams = {
            Payout: string
        }
        with
            static member Create (payout: string) =
                {
                    Payout = payout
                }

        ///<p>A previously created payout can be canceled if it has not yet been paid out. Funds will be refunded to your available balance. You may not cancel automatic Stripe payouts.</p>
        let Cancel settings (formParameters: PostPayoutsPayoutCancelParams) (queryParameters: CancelQueryParams) =
            $"/v1/payouts/{queryParameters.Payout}/cancel"
            |> RestApi.postAsync<_, Payout> settings formParameters

    module PayoutsReverseService =

        type ReverseQueryParams = {
            Payout: string
        }
        with
            static member Create (payout: string) =
                {
                    Payout = payout
                }

        ///<p>Reverses a payout by debiting the destination bank account. Only payouts for connected accounts to US bank accounts may be reversed at this time. If the payout is in the <code>pending</code> status, <code>/v1/payouts/:id/cancel</code> should be used instead.
        ///By requesting a reversal via <code>/v1/payouts/:id/reverse</code>, you confirm that the authorized signatory of the selected bank account has authorized the debit on the bank account and that no other authorization is required.</p>
        let Reverse settings (formParameters: PostPayoutsPayoutReverseParams) (queryParameters: ReverseQueryParams) =
            $"/v1/payouts/{queryParameters.Payout}/reverse"
            |> RestApi.postAsync<_, Payout> settings formParameters

    module PlansService =

        type ListQueryParams = {
            Active: bool option
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            Product: string option
            StartingAfter: string option
        }
        with
            static member Create (?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?product: string, ?startingAfter: string) =
                {
                    Active = active
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    Product = product
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of your plans.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/plans?active={queryParameters.Active}&created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&product={queryParameters.Product}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<Plan list> settings

        ///<p>You can now model subscriptions more flexibly using the <a href="#prices">Prices API</a>. It replaces the Plans API and is backwards compatible to simplify your migration.</p>
        let Create settings (formParameters: PostPlansParams) =
            $"/v1/plans"
            |> RestApi.postAsync<_, Plan> settings formParameters

        type DeleteQueryParams = {
            Plan: string
        }
        with
            static member Create (plan: string) =
                {
                    Plan = plan
                }

        ///<p>Deleting plans means new subscribers can’t be added. Existing subscribers aren’t affected.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/plans/{queryParameters.Plan}"
            |> RestApi.deleteAsync<DeletedPlan> settings

        type RetrieveQueryParams = {
            Plan: string
            Expand: string list option
        }
        with
            static member Create (plan: string, ?expand: string list) =
                {
                    Plan = plan
                    Expand = expand
                }

        ///<p>Retrieves the plan with the given ID.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/plans/{queryParameters.Plan}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Plan> settings

        type UpdateQueryParams = {
            Plan: string
        }
        with
            static member Create (plan: string) =
                {
                    Plan = plan
                }

        ///<p>Updates the specified plan by setting the values of the parameters passed. Any parameters not provided are left unchanged. By design, you cannot change a plan’s ID, amount, currency, or billing cycle.</p>
        let Update settings (formParameters: PostPlansPlanParams) (queryParameters: UpdateQueryParams) =
            $"/v1/plans/{queryParameters.Plan}"
            |> RestApi.postAsync<_, Plan> settings formParameters

    module PricesService =

        type ListQueryParams = {
            Active: bool option
            Created: int option
            Currency: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            LookupKeys: string list option
            Product: string option
            Recurring: Map<string, string> option
            StartingAfter: string option
            ``type``: string option
        }
        with
            static member Create (?active: bool, ?created: int, ?currency: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?lookupKeys: string list, ?product: string, ?recurring: Map<string, string>, ?startingAfter: string, ?``type``: string) =
                {
                    Active = active
                    Created = created
                    Currency = currency
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    LookupKeys = lookupKeys
                    Product = product
                    Recurring = recurring
                    StartingAfter = startingAfter
                    ``type`` = ``type``
                }

        ///<p>Returns a list of your prices.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/prices?active={queryParameters.Active}&created={queryParameters.Created}&currency={queryParameters.Currency}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&lookup_keys={queryParameters.LookupKeys}&product={queryParameters.Product}&recurring={queryParameters.Recurring}&starting_after={queryParameters.StartingAfter}&type={queryParameters.``type``}"
            |> RestApi.getAsync<Price list> settings

        ///<p>Creates a new price for an existing product. The price can be recurring or one-time.</p>
        let Create settings (formParameters: PostPricesParams) =
            $"/v1/prices"
            |> RestApi.postAsync<_, Price> settings formParameters

        type RetrieveQueryParams = {
            Price: string
            Expand: string list option
        }
        with
            static member Create (price: string, ?expand: string list) =
                {
                    Price = price
                    Expand = expand
                }

        ///<p>Retrieves the price with the given ID.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/prices/{queryParameters.Price}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Price> settings

        type UpdateQueryParams = {
            Price: string
        }
        with
            static member Create (price: string) =
                {
                    Price = price
                }

        ///<p>Updates the specified price by setting the values of the parameters passed. Any parameters not provided are left unchanged.</p>
        let Update settings (formParameters: PostPricesPriceParams) (queryParameters: UpdateQueryParams) =
            $"/v1/prices/{queryParameters.Price}"
            |> RestApi.postAsync<_, Price> settings formParameters

    module ProductsService =

        type ListQueryParams = {
            Active: bool option
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Ids: string list option
            Limit: int option
            Shippable: bool option
            StartingAfter: string option
            ``type``: string option
            Url: string option
        }
        with
            static member Create (?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?ids: string list, ?limit: int, ?shippable: bool, ?startingAfter: string, ?``type``: string, ?url: string) =
                {
                    Active = active
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Ids = ids
                    Limit = limit
                    Shippable = shippable
                    StartingAfter = startingAfter
                    ``type`` = ``type``
                    Url = url
                }

        ///<p>Returns a list of your products. The products are returned sorted by creation date, with the most recently created products appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/products?active={queryParameters.Active}&created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&ids={queryParameters.Ids}&limit={queryParameters.Limit}&shippable={queryParameters.Shippable}&starting_after={queryParameters.StartingAfter}&type={queryParameters.``type``}&url={queryParameters.Url}"
            |> RestApi.getAsync<Product list> settings

        ///<p>Creates a new product object.</p>
        let Create settings (formParameters: PostProductsParams) =
            $"/v1/products"
            |> RestApi.postAsync<_, Product> settings formParameters

        type DeleteQueryParams = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Delete a product. Deleting a product is only possible if it has no prices associated with it. Additionally, deleting a product with <code>type=good</code> is only possible if it has no SKUs associated with it.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/products/{queryParameters.Id}"
            |> RestApi.deleteAsync<DeletedProduct> settings

        type RetrieveQueryParams = {
            Id: string
            Expand: string list option
        }
        with
            static member Create (id: string, ?expand: string list) =
                {
                    Id = id
                    Expand = expand
                }

        ///<p>Retrieves the details of an existing product. Supply the unique product ID from either a product creation request or the product list, and Stripe will return the corresponding product information.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/products/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Product> settings

        type UpdateQueryParams = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Updates the specific product by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formParameters: PostProductsIdParams) (queryParameters: UpdateQueryParams) =
            $"/v1/products/{queryParameters.Id}"
            |> RestApi.postAsync<_, Product> settings formParameters

    module PromotionCodesService =

        type ListQueryParams = {
            Active: bool option
            Code: string option
            Coupon: string option
            Created: int option
            Customer: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?active: bool, ?code: string, ?coupon: string, ?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Active = active
                    Code = code
                    Coupon = coupon
                    Created = created
                    Customer = customer
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of your promotion codes.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/promotion_codes?active={queryParameters.Active}&code={queryParameters.Code}&coupon={queryParameters.Coupon}&created={queryParameters.Created}&customer={queryParameters.Customer}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<PromotionCode list> settings

        ///<p>A promotion code points to a coupon. You can optionally restrict the code to a specific customer, redemption limit, and expiration date.</p>
        let Create settings (formParameters: PostPromotionCodesParams) =
            $"/v1/promotion_codes"
            |> RestApi.postAsync<_, PromotionCode> settings formParameters

        type RetrieveQueryParams = {
            PromotionCode: string
            Expand: string list option
        }
        with
            static member Create (promotionCode: string, ?expand: string list) =
                {
                    PromotionCode = promotionCode
                    Expand = expand
                }

        ///<p>Retrieves the promotion code with the given ID.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/promotion_codes/{queryParameters.PromotionCode}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<PromotionCode> settings

        type UpdateQueryParams = {
            PromotionCode: string
        }
        with
            static member Create (promotionCode: string) =
                {
                    PromotionCode = promotionCode
                }

        ///<p>Updates the specified promotion code by setting the values of the parameters passed. Most fields are, by design, not editable.</p>
        let Update settings (formParameters: PostPromotionCodesPromotionCodeParams) (queryParameters: UpdateQueryParams) =
            $"/v1/promotion_codes/{queryParameters.PromotionCode}"
            |> RestApi.postAsync<_, PromotionCode> settings formParameters

    module RadarEarlyFraudWarningsService =

        type ListQueryParams = {
            Charge: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?charge: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Charge = charge
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of early fraud warnings.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/radar/early_fraud_warnings?charge={queryParameters.Charge}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<RadarEarlyFraudWarning list> settings

        type RetrieveQueryParams = {
            EarlyFraudWarning: string
            Expand: string list option
        }
        with
            static member Create (earlyFraudWarning: string, ?expand: string list) =
                {
                    EarlyFraudWarning = earlyFraudWarning
                    Expand = expand
                }

        ///<p>Retrieves the details of an early fraud warning that has previously been created. 
        ///Please refer to the <a href="#early_fraud_warning_object">early fraud warning</a> object reference for more details.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/radar/early_fraud_warnings/{queryParameters.EarlyFraudWarning}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<RadarEarlyFraudWarning> settings

    module RadarValueListItemsService =

        type ListQueryParams = {
            ValueList: string
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
            Value: string option
        }
        with
            static member Create (valueList: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?value: string) =
                {
                    ValueList = valueList
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                    Value = value
                }

        ///<p>Returns a list of <code>ValueListItem</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/radar/value_list_items?value_list={queryParameters.ValueList}&created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}&value={queryParameters.Value}"
            |> RestApi.getAsync<RadarValueListItem list> settings

        ///<p>Creates a new <code>ValueListItem</code> object, which is added to the specified parent value list.</p>
        let Create settings (formParameters: PostRadarValueListItemsParams) =
            $"/v1/radar/value_list_items"
            |> RestApi.postAsync<_, RadarValueListItem> settings formParameters

        type DeleteQueryParams = {
            Item: string
        }
        with
            static member Create (item: string) =
                {
                    Item = item
                }

        ///<p>Deletes a <code>ValueListItem</code> object, removing it from its parent value list.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/radar/value_list_items/{queryParameters.Item}"
            |> RestApi.deleteAsync<DeletedRadarValueListItem> settings

        type RetrieveQueryParams = {
            Item: string
            Expand: string list option
        }
        with
            static member Create (item: string, ?expand: string list) =
                {
                    Item = item
                    Expand = expand
                }

        ///<p>Retrieves a <code>ValueListItem</code> object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/radar/value_list_items/{queryParameters.Item}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<RadarValueListItem> settings

    module RadarValueListsService =

        type ListQueryParams = {
            Alias: string option
            Contains: string option
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?alias: string, ?contains: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Alias = alias
                    Contains = contains
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of <code>ValueList</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/radar/value_lists?alias={queryParameters.Alias}&contains={queryParameters.Contains}&created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<RadarValueList list> settings

        ///<p>Creates a new <code>ValueList</code> object, which can then be referenced in rules.</p>
        let Create settings (formParameters: PostRadarValueListsParams) =
            $"/v1/radar/value_lists"
            |> RestApi.postAsync<_, RadarValueList> settings formParameters

        type DeleteQueryParams = {
            ValueList: string
        }
        with
            static member Create (valueList: string) =
                {
                    ValueList = valueList
                }

        ///<p>Deletes a <code>ValueList</code> object, also deleting any items contained within the value list. To be deleted, a value list must not be referenced in any rules.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/radar/value_lists/{queryParameters.ValueList}"
            |> RestApi.deleteAsync<DeletedRadarValueList> settings

        type RetrieveQueryParams = {
            ValueList: string
            Expand: string list option
        }
        with
            static member Create (valueList: string, ?expand: string list) =
                {
                    ValueList = valueList
                    Expand = expand
                }

        ///<p>Retrieves a <code>ValueList</code> object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/radar/value_lists/{queryParameters.ValueList}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<RadarValueList> settings

        type UpdateQueryParams = {
            ValueList: string
        }
        with
            static member Create (valueList: string) =
                {
                    ValueList = valueList
                }

        ///<p>Updates a <code>ValueList</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Note that <code>item_type</code> is immutable.</p>
        let Update settings (formParameters: PostRadarValueListsValueListParams) (queryParameters: UpdateQueryParams) =
            $"/v1/radar/value_lists/{queryParameters.ValueList}"
            |> RestApi.postAsync<_, RadarValueList> settings formParameters

    module RecipientsService =

        type ListQueryParams = {
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
            ``type``: string option
            Verified: bool option
        }
        with
            static member Create (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?``type``: string, ?verified: bool) =
                {
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                    ``type`` = ``type``
                    Verified = verified
                }

        ///<p>Returns a list of your recipients. The recipients are returned sorted by creation date, with the most recently created recipients appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/recipients?created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}&type={queryParameters.``type``}&verified={queryParameters.Verified}"
            |> RestApi.getAsync<Recipient list> settings

        ///<p>Creates a new <code>Recipient</code> object and verifies the recipient’s identity.
        ///Also verifies the recipient’s bank account information or debit card, if either is provided.</p>
        let Create settings (formParameters: PostRecipientsParams) =
            $"/v1/recipients"
            |> RestApi.postAsync<_, Recipient> settings formParameters

        type DeleteQueryParams = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Permanently deletes a recipient. It cannot be undone.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/recipients/{queryParameters.Id}"
            |> RestApi.deleteAsync<DeletedRecipient> settings

        type RetrieveQueryParams = {
            Id: string
            Expand: string list option
        }
        with
            static member Create (id: string, ?expand: string list) =
                {
                    Id = id
                    Expand = expand
                }

        ///<p>Retrieves the details of an existing recipient. You need only supply the unique recipient identifier that was returned upon recipient creation.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/recipients/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Recipient> settings

        type UpdateQueryParams = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Updates the specified recipient by setting the values of the parameters passed.
        ///Any parameters not provided will be left unchanged.
        ///If you update the name or tax ID, the identity verification will automatically be rerun.
        ///If you update the bank account, the bank account validation will automatically be rerun.</p>
        let Update settings (formParameters: PostRecipientsIdParams) (queryParameters: UpdateQueryParams) =
            $"/v1/recipients/{queryParameters.Id}"
            |> RestApi.postAsync<_, Recipient> settings formParameters

    module RefundsService =

        type ListQueryParams = {
            Charge: string option
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            PaymentIntent: string option
            StartingAfter: string option
        }
        with
            static member Create (?charge: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string) =
                {
                    Charge = charge
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    PaymentIntent = paymentIntent
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of all refunds you’ve previously created. The refunds are returned in sorted order, with the most recent refunds appearing first. For convenience, the 10 most recent refunds are always available by default on the charge object.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/refunds?charge={queryParameters.Charge}&created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&payment_intent={queryParameters.PaymentIntent}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<Refund list> settings

        ///<p>Create a refund.</p>
        let Create settings (formParameters: PostRefundsParams) =
            $"/v1/refunds"
            |> RestApi.postAsync<_, Refund> settings formParameters

        type RetrieveQueryParams = {
            Refund: string
            Expand: string list option
        }
        with
            static member Create (refund: string, ?expand: string list) =
                {
                    Refund = refund
                    Expand = expand
                }

        ///<p>Retrieves the details of an existing refund.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/refunds/{queryParameters.Refund}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Refund> settings

        type UpdateQueryParams = {
            Refund: string
        }
        with
            static member Create (refund: string) =
                {
                    Refund = refund
                }

        ///<p>Updates the specified refund by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request only accepts <code>metadata</code> as an argument.</p>
        let Update settings (formParameters: PostRefundsRefundParams) (queryParameters: UpdateQueryParams) =
            $"/v1/refunds/{queryParameters.Refund}"
            |> RestApi.postAsync<_, Refund> settings formParameters

    module ReportingReportRunsService =

        type ListQueryParams = {
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of Report Runs, with the most recent appearing first. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/reporting/report_runs?created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<ReportingReportRun list> settings

        ///<p>Creates a new object and begin running the report. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        let Create settings (formParameters: PostReportingReportRunsParams) =
            $"/v1/reporting/report_runs"
            |> RestApi.postAsync<_, ReportingReportRun> settings formParameters

        type RetrieveQueryParams = {
            ReportRun: string
            Expand: string list option
        }
        with
            static member Create (reportRun: string, ?expand: string list) =
                {
                    ReportRun = reportRun
                    Expand = expand
                }

        ///<p>Retrieves the details of an existing Report Run. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/reporting/report_runs/{queryParameters.ReportRun}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<ReportingReportRun> settings

    module ReportingReportTypesService =

        type ListQueryParams = {
            Expand: string list option
        }
        with
            static member Create (?expand: string list) =
                {
                    Expand = expand
                }

        ///<p>Returns a full list of Report Types. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/reporting/report_types?expand={queryParameters.Expand}"
            |> RestApi.getAsync<ReportingReportType list> settings

        type RetrieveQueryParams = {
            ReportType: string
            Expand: string list option
        }
        with
            static member Create (reportType: string, ?expand: string list) =
                {
                    ReportType = reportType
                    Expand = expand
                }

        ///<p>Retrieves the details of a Report Type. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/reporting/report_types/{queryParameters.ReportType}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<ReportingReportType> settings

    module ReviewsService =

        type ListQueryParams = {
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of <code>Review</code> objects that have <code>open</code> set to <code>true</code>. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/reviews?created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<Review list> settings

        type RetrieveQueryParams = {
            Review: string
            Expand: string list option
        }
        with
            static member Create (review: string, ?expand: string list) =
                {
                    Review = review
                    Expand = expand
                }

        ///<p>Retrieves a <code>Review</code> object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/reviews/{queryParameters.Review}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Review> settings

    module ReviewsApproveService =

        type ApproveQueryParams = {
            Review: string
        }
        with
            static member Create (review: string) =
                {
                    Review = review
                }

        ///<p>Approves a <code>Review</code> object, closing it and removing it from the list of reviews.</p>
        let Approve settings (formParameters: PostReviewsReviewApproveParams) (queryParameters: ApproveQueryParams) =
            $"/v1/reviews/{queryParameters.Review}/approve"
            |> RestApi.postAsync<_, Review> settings formParameters

    module SetupAttemptsService =

        type ListQueryParams = {
            SetupIntent: string
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (setupIntent: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    SetupIntent = setupIntent
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of SetupAttempts associated with a provided SetupIntent.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/setup_attempts?setup_intent={queryParameters.SetupIntent}&created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<SetupAttempt list> settings

    module SetupIntentsService =

        type ListQueryParams = {
            Created: int option
            Customer: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            PaymentMethod: string option
            StartingAfter: string option
        }
        with
            static member Create (?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentMethod: string, ?startingAfter: string) =
                {
                    Created = created
                    Customer = customer
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    PaymentMethod = paymentMethod
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of SetupIntents.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/setup_intents?created={queryParameters.Created}&customer={queryParameters.Customer}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&payment_method={queryParameters.PaymentMethod}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<SetupIntent list> settings

        ///<p>Creates a SetupIntent object.
        ///After the SetupIntent is created, attach a payment method and <a href="/docs/api/setup_intents/confirm">confirm</a>
        ///to collect any required permissions to charge the payment method later.</p>
        let Create settings (formParameters: PostSetupIntentsParams) =
            $"/v1/setup_intents"
            |> RestApi.postAsync<_, SetupIntent> settings formParameters

        type RetrieveQueryParams = {
            Intent: string
            Expand: string list option
            ClientSecret: string option
        }
        with
            static member Create (intent: string, ?expand: string list, ?clientSecret: string) =
                {
                    Intent = intent
                    Expand = expand
                    ClientSecret = clientSecret
                }

        ///<p>Retrieves the details of a SetupIntent that has previously been created. 
        ///Client-side retrieval using a publishable key is allowed when the <code>client_secret</code> is provided in the query string. 
        ///When retrieved with a publishable key, only a subset of properties will be returned. Please refer to the <a href="#setup_intent_object">SetupIntent</a> object reference for more details.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/setup_intents/{queryParameters.Intent}?client_secret={queryParameters.ClientSecret}&expand={queryParameters.Expand}"
            |> RestApi.getAsync<SetupIntent> settings

        type UpdateQueryParams = {
            Intent: string
        }
        with
            static member Create (intent: string) =
                {
                    Intent = intent
                }

        ///<p>Updates a SetupIntent object.</p>
        let Update settings (formParameters: PostSetupIntentsIntentParams) (queryParameters: UpdateQueryParams) =
            $"/v1/setup_intents/{queryParameters.Intent}"
            |> RestApi.postAsync<_, SetupIntent> settings formParameters

    module SetupIntentsCancelService =

        type CancelQueryParams = {
            Intent: string
        }
        with
            static member Create (intent: string) =
                {
                    Intent = intent
                }

        ///<p>A SetupIntent object can be canceled when it is in one of these statuses: <code>requires_payment_method</code>, <code>requires_confirmation</code>, or <code>requires_action</code>. 
        ///Once canceled, setup is abandoned and any operations on the SetupIntent will fail with an error.</p>
        let Cancel settings (formParameters: PostSetupIntentsIntentCancelParams) (queryParameters: CancelQueryParams) =
            $"/v1/setup_intents/{queryParameters.Intent}/cancel"
            |> RestApi.postAsync<_, SetupIntent> settings formParameters

    module SetupIntentsConfirmService =

        type ConfirmQueryParams = {
            Intent: string
        }
        with
            static member Create (intent: string) =
                {
                    Intent = intent
                }

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
        let Confirm settings (formParameters: PostSetupIntentsIntentConfirmParams) (queryParameters: ConfirmQueryParams) =
            $"/v1/setup_intents/{queryParameters.Intent}/confirm"
            |> RestApi.postAsync<_, SetupIntent> settings formParameters

    module SigmaScheduledQueryRunsService =

        type ListQueryParams = {
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of scheduled query runs.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/sigma/scheduled_query_runs?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<ScheduledQueryRun list> settings

        type RetrieveQueryParams = {
            ScheduledQueryRun: string
            Expand: string list option
        }
        with
            static member Create (scheduledQueryRun: string, ?expand: string list) =
                {
                    ScheduledQueryRun = scheduledQueryRun
                    Expand = expand
                }

        ///<p>Retrieves the details of an scheduled query run.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/sigma/scheduled_query_runs/{queryParameters.ScheduledQueryRun}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<ScheduledQueryRun> settings

    module SkusService =

        type ListQueryParams = {
            Active: bool option
            Attributes: Map<string, string> option
            EndingBefore: string option
            Expand: string list option
            Ids: string list option
            InStock: bool option
            Limit: int option
            Product: string option
            StartingAfter: string option
        }
        with
            static member Create (?active: bool, ?attributes: Map<string, string>, ?endingBefore: string, ?expand: string list, ?ids: string list, ?inStock: bool, ?limit: int, ?product: string, ?startingAfter: string) =
                {
                    Active = active
                    Attributes = attributes
                    EndingBefore = endingBefore
                    Expand = expand
                    Ids = ids
                    InStock = inStock
                    Limit = limit
                    Product = product
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of your SKUs. The SKUs are returned sorted by creation date, with the most recently created SKUs appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/skus?active={queryParameters.Active}&attributes={queryParameters.Attributes}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&ids={queryParameters.Ids}&in_stock={queryParameters.InStock}&limit={queryParameters.Limit}&product={queryParameters.Product}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<Sku list> settings

        ///<p>Creates a new SKU associated with a product.</p>
        let Create settings (formParameters: PostSkusParams) =
            $"/v1/skus"
            |> RestApi.postAsync<_, Sku> settings formParameters

        type DeleteQueryParams = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Delete a SKU. Deleting a SKU is only possible until it has been used in an order.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/skus/{queryParameters.Id}"
            |> RestApi.deleteAsync<DeletedSku> settings

        type RetrieveQueryParams = {
            Id: string
            Expand: string list option
        }
        with
            static member Create (id: string, ?expand: string list) =
                {
                    Id = id
                    Expand = expand
                }

        ///<p>Retrieves the details of an existing SKU. Supply the unique SKU identifier from either a SKU creation request or from the product, and Stripe will return the corresponding SKU information.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/skus/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Sku> settings

        type UpdateQueryParams = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Updates the specific SKU by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///Note that a SKU’s <code>attributes</code> are not editable. Instead, you would need to deactivate the existing SKU and create a new one with the new attribute values.</p>
        let Update settings (formParameters: PostSkusIdParams) (queryParameters: UpdateQueryParams) =
            $"/v1/skus/{queryParameters.Id}"
            |> RestApi.postAsync<_, Sku> settings formParameters

    module SourcesService =

        ///<p>Creates a new source object.</p>
        let Create settings (formParameters: PostSourcesParams) =
            $"/v1/sources"
            |> RestApi.postAsync<_, Source> settings formParameters

        type RetrieveQueryParams = {
            Source: string
            Expand: string list option
            ClientSecret: string option
        }
        with
            static member Create (source: string, ?expand: string list, ?clientSecret: string) =
                {
                    Source = source
                    Expand = expand
                    ClientSecret = clientSecret
                }

        ///<p>Retrieves an existing source object. Supply the unique source ID from a source creation request and Stripe will return the corresponding up-to-date source object information.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/sources/{queryParameters.Source}?client_secret={queryParameters.ClientSecret}&expand={queryParameters.Expand}"
            |> RestApi.getAsync<Source> settings

        type UpdateQueryParams = {
            Source: string
        }
        with
            static member Create (source: string) =
                {
                    Source = source
                }

        ///<p>Updates the specified source by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request accepts the <code>metadata</code> and <code>owner</code> as arguments. It is also possible to update type specific information for selected payment methods. Please refer to our <a href="/docs/sources">payment method guides</a> for more detail.</p>
        let Update settings (formParameters: PostSourcesSourceParams) (queryParameters: UpdateQueryParams) =
            $"/v1/sources/{queryParameters.Source}"
            |> RestApi.postAsync<_, Source> settings formParameters

    module SourcesSourceTransactionsService =

        type SourceTransactionsQueryParams = {
            Source: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (source: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Source = source
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>List source transactions for a given source.</p>
        let SourceTransactions settings (queryParameters: SourceTransactionsQueryParams) =
            $"/v1/sources/{queryParameters.Source}/source_transactions?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<SourceTransaction list> settings

    module SourcesVerifyService =

        type VerifyQueryParams = {
            Source: string
        }
        with
            static member Create (source: string) =
                {
                    Source = source
                }

        ///<p>Verify a given source.</p>
        let Verify settings (formParameters: PostSourcesSourceVerifyParams) (queryParameters: VerifyQueryParams) =
            $"/v1/sources/{queryParameters.Source}/verify"
            |> RestApi.postAsync<_, Source> settings formParameters

    module SubscriptionItemsService =

        type ListQueryParams = {
            Subscription: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (subscription: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Subscription = subscription
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of your subscription items for a given subscription.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/subscription_items?subscription={queryParameters.Subscription}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<SubscriptionItem list> settings

        ///<p>Adds a new item to an existing subscription. No existing items will be changed or replaced.</p>
        let Create settings (formParameters: PostSubscriptionItemsParams) =
            $"/v1/subscription_items"
            |> RestApi.postAsync<_, SubscriptionItem> settings formParameters

        type DeleteQueryParams = {
            Item: string
        }
        with
            static member Create (item: string) =
                {
                    Item = item
                }

        ///<p>Deletes an item from the subscription. Removing a subscription item from a subscription will not cancel the subscription.</p>
        let Delete settings (formParameters: DeleteSubscriptionItemsItemParams) (queryParameters: DeleteQueryParams) =
            $"/v1/subscription_items/{queryParameters.Item}"
            |> RestApi.deleteAsync<DeletedSubscriptionItem> settings

        type RetrieveQueryParams = {
            Item: string
            Expand: string list option
        }
        with
            static member Create (item: string, ?expand: string list) =
                {
                    Item = item
                    Expand = expand
                }

        ///<p>Retrieves the subscription item with the given ID.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/subscription_items/{queryParameters.Item}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<SubscriptionItem> settings

        type UpdateQueryParams = {
            Item: string
        }
        with
            static member Create (item: string) =
                {
                    Item = item
                }

        ///<p>Updates the plan or quantity of an item on a current subscription.</p>
        let Update settings (formParameters: PostSubscriptionItemsItemParams) (queryParameters: UpdateQueryParams) =
            $"/v1/subscription_items/{queryParameters.Item}"
            |> RestApi.postAsync<_, SubscriptionItem> settings formParameters

    module SubscriptionItemsUsageRecordSummariesService =

        type UsageRecordSummariesQueryParams = {
            SubscriptionItem: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (subscriptionItem: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    SubscriptionItem = subscriptionItem
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>For the specified subscription item, returns a list of summary objects. Each object in the list provides usage information that’s been summarized from multiple usage records and over a subscription billing period (e.g., 15 usage records in the month of September).
        ///The list is sorted in reverse-chronological order (newest first). The first list item represents the most current usage period that hasn’t ended yet. Since new usage records can still be added, the returned summary information for the subscription item’s ID should be seen as unstable until the subscription billing period ends.</p>
        let UsageRecordSummaries settings (queryParameters: UsageRecordSummariesQueryParams) =
            $"/v1/subscription_items/{queryParameters.SubscriptionItem}/usage_record_summaries?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<UsageRecordSummary list> settings

    module SubscriptionItemsUsageRecordsService =

        type CreateQueryParams = {
            SubscriptionItem: string
        }
        with
            static member Create (subscriptionItem: string) =
                {
                    SubscriptionItem = subscriptionItem
                }

        ///<p>Creates a usage record for a specified subscription item and date, and fills it with a quantity.
        ///Usage records provide <code>quantity</code> information that Stripe uses to track how much a customer is using your service. With usage information and the pricing model set up by the <a href="https://stripe.com/docs/billing/subscriptions/metered-billing">metered billing</a> plan, Stripe helps you send accurate invoices to your customers.
        ///The default calculation for usage is to add up all the <code>quantity</code> values of the usage records within a billing period. You can change this default behavior with the billing plan’s <code>aggregate_usage</code> <a href="/docs/api/plans/create#create_plan-aggregate_usage">parameter</a>. When there is more than one usage record with the same timestamp, Stripe adds the <code>quantity</code> values together. In most cases, this is the desired resolution, however, you can change this behavior with the <code>action</code> parameter.
        ///The default pricing model for metered billing is <a href="/docs/api/plans/object#plan_object-billing_scheme">per-unit pricing</a>. For finer granularity, you can configure metered billing to have a <a href="https://stripe.com/docs/billing/subscriptions/tiers">tiered pricing</a> model.</p>
        let Create settings (formParameters: PostSubscriptionItemsSubscriptionItemUsageRecordsParams) (queryParameters: CreateQueryParams) =
            $"/v1/subscription_items/{queryParameters.SubscriptionItem}/usage_records"
            |> RestApi.postAsync<_, UsageRecord> settings formParameters

    module SubscriptionSchedulesService =

        type ListQueryParams = {
            CanceledAt: int option
            CompletedAt: int option
            Created: int option
            Customer: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            ReleasedAt: int option
            Scheduled: bool option
            StartingAfter: string option
        }
        with
            static member Create (?canceledAt: int, ?completedAt: int, ?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?releasedAt: int, ?scheduled: bool, ?startingAfter: string) =
                {
                    CanceledAt = canceledAt
                    CompletedAt = completedAt
                    Created = created
                    Customer = customer
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    ReleasedAt = releasedAt
                    Scheduled = scheduled
                    StartingAfter = startingAfter
                }

        ///<p>Retrieves the list of your subscription schedules.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/subscription_schedules?canceled_at={queryParameters.CanceledAt}&completed_at={queryParameters.CompletedAt}&created={queryParameters.Created}&customer={queryParameters.Customer}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&released_at={queryParameters.ReleasedAt}&scheduled={queryParameters.Scheduled}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<SubscriptionSchedule list> settings

        ///<p>Creates a new subscription schedule object. Each customer can have up to 500 active or scheduled subscriptions.</p>
        let Create settings (formParameters: PostSubscriptionSchedulesParams) =
            $"/v1/subscription_schedules"
            |> RestApi.postAsync<_, SubscriptionSchedule> settings formParameters

        type RetrieveQueryParams = {
            Schedule: string
            Expand: string list option
        }
        with
            static member Create (schedule: string, ?expand: string list) =
                {
                    Schedule = schedule
                    Expand = expand
                }

        ///<p>Retrieves the details of an existing subscription schedule. You only need to supply the unique subscription schedule identifier that was returned upon subscription schedule creation.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/subscription_schedules/{queryParameters.Schedule}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<SubscriptionSchedule> settings

        type UpdateQueryParams = {
            Schedule: string
        }
        with
            static member Create (schedule: string) =
                {
                    Schedule = schedule
                }

        ///<p>Updates an existing subscription schedule.</p>
        let Update settings (formParameters: PostSubscriptionSchedulesScheduleParams) (queryParameters: UpdateQueryParams) =
            $"/v1/subscription_schedules/{queryParameters.Schedule}"
            |> RestApi.postAsync<_, SubscriptionSchedule> settings formParameters

    module SubscriptionSchedulesCancelService =

        type CancelQueryParams = {
            Schedule: string
        }
        with
            static member Create (schedule: string) =
                {
                    Schedule = schedule
                }

        ///<p>Cancels a subscription schedule and its associated subscription immediately (if the subscription schedule has an active subscription). A subscription schedule can only be canceled if its status is <code>not_started</code> or <code>active</code>.</p>
        let Cancel settings (formParameters: PostSubscriptionSchedulesScheduleCancelParams) (queryParameters: CancelQueryParams) =
            $"/v1/subscription_schedules/{queryParameters.Schedule}/cancel"
            |> RestApi.postAsync<_, SubscriptionSchedule> settings formParameters

    module SubscriptionSchedulesReleaseService =

        type ReleaseQueryParams = {
            Schedule: string
        }
        with
            static member Create (schedule: string) =
                {
                    Schedule = schedule
                }

        ///<p>Releases the subscription schedule immediately, which will stop scheduling of its phases, but leave any existing subscription in place. A schedule can only be released if its status is <code>not_started</code> or <code>active</code>. If the subscription schedule is currently associated with a subscription, releasing it will remove its <code>subscription</code> property and set the subscription’s ID to the <code>released_subscription</code> property.</p>
        let Release settings (formParameters: PostSubscriptionSchedulesScheduleReleaseParams) (queryParameters: ReleaseQueryParams) =
            $"/v1/subscription_schedules/{queryParameters.Schedule}/release"
            |> RestApi.postAsync<_, SubscriptionSchedule> settings formParameters

    module SubscriptionsService =

        type ListQueryParams = {
            CollectionMethod: string option
            Created: int option
            CurrentPeriodEnd: int option
            CurrentPeriodStart: int option
            Customer: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            Plan: string option
            Price: string option
            StartingAfter: string option
            Status: string option
        }
        with
            static member Create (?collectionMethod: string, ?created: int, ?currentPeriodEnd: int, ?currentPeriodStart: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?plan: string, ?price: string, ?startingAfter: string, ?status: string) =
                {
                    CollectionMethod = collectionMethod
                    Created = created
                    CurrentPeriodEnd = currentPeriodEnd
                    CurrentPeriodStart = currentPeriodStart
                    Customer = customer
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    Plan = plan
                    Price = price
                    StartingAfter = startingAfter
                    Status = status
                }

        ///<p>By default, returns a list of subscriptions that have not been canceled. In order to list canceled subscriptions, specify <code>status=canceled</code>.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/subscriptions?collection_method={queryParameters.CollectionMethod}&created={queryParameters.Created}&current_period_end={queryParameters.CurrentPeriodEnd}&current_period_start={queryParameters.CurrentPeriodStart}&customer={queryParameters.Customer}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&plan={queryParameters.Plan}&price={queryParameters.Price}&starting_after={queryParameters.StartingAfter}&status={queryParameters.Status}"
            |> RestApi.getAsync<Subscription list> settings

        ///<p>Creates a new subscription on an existing customer. Each customer can have up to 500 active or scheduled subscriptions.</p>
        let Create settings (formParameters: PostSubscriptionsParams) =
            $"/v1/subscriptions"
            |> RestApi.postAsync<_, Subscription> settings formParameters

        type CancelQueryParams = {
            SubscriptionExposedId: string
        }
        with
            static member Create (subscriptionExposedId: string) =
                {
                    SubscriptionExposedId = subscriptionExposedId
                }

        ///<p>Cancels a customer’s subscription immediately. The customer will not be charged again for the subscription.
        ///Note, however, that any pending invoice items that you’ve created will still be charged for at the end of the period, unless manually <a href="#delete_invoiceitem">deleted</a>. If you’ve set the subscription to cancel at the end of the period, any pending prorations will also be left in place and collected at the end of the period. But if the subscription is set to cancel immediately, pending prorations will be removed.
        ///By default, upon subscription cancellation, Stripe will stop automatic collection of all finalized invoices for the customer. This is intended to prevent unexpected payment attempts after the customer has canceled a subscription. However, you can resume automatic collection of the invoices manually after subscription cancellation to have us proceed. Or, you could check for unpaid invoices before allowing the customer to cancel the subscription at all.</p>
        let Cancel settings (formParameters: DeleteSubscriptionsSubscriptionExposedIdParams) (queryParameters: CancelQueryParams) =
            $"/v1/subscriptions/{queryParameters.SubscriptionExposedId}"
            |> RestApi.deleteAsync<Subscription> settings

        type RetrieveQueryParams = {
            SubscriptionExposedId: string
            Expand: string list option
        }
        with
            static member Create (subscriptionExposedId: string, ?expand: string list) =
                {
                    SubscriptionExposedId = subscriptionExposedId
                    Expand = expand
                }

        ///<p>Retrieves the subscription with the given ID.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/subscriptions/{queryParameters.SubscriptionExposedId}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Subscription> settings

        type UpdateQueryParams = {
            SubscriptionExposedId: string
        }
        with
            static member Create (subscriptionExposedId: string) =
                {
                    SubscriptionExposedId = subscriptionExposedId
                }

        ///<p>Updates an existing subscription on a customer to match the specified parameters. When changing plans or quantities, we will optionally prorate the price we charge next month to make up for any price changes. To preview how the proration will be calculated, use the <a href="#upcoming_invoice">upcoming invoice</a> endpoint.</p>
        let Update settings (formParameters: PostSubscriptionsSubscriptionExposedIdParams) (queryParameters: UpdateQueryParams) =
            $"/v1/subscriptions/{queryParameters.SubscriptionExposedId}"
            |> RestApi.postAsync<_, Subscription> settings formParameters

    module SubscriptionsDiscountService =

        type DeleteDiscountQueryParams = {
            SubscriptionExposedId: string
        }
        with
            static member Create (subscriptionExposedId: string) =
                {
                    SubscriptionExposedId = subscriptionExposedId
                }

        ///<p>Removes the currently applied discount on a subscription.</p>
        let DeleteDiscount settings (queryParameters: DeleteDiscountQueryParams) =
            $"/v1/subscriptions/{queryParameters.SubscriptionExposedId}/discount"
            |> RestApi.deleteAsync<DeletedDiscount> settings

    module TaxRatesService =

        type ListQueryParams = {
            Active: bool option
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Inclusive: bool option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?inclusive: bool, ?limit: int, ?startingAfter: string) =
                {
                    Active = active
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Inclusive = inclusive
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of your tax rates. Tax rates are returned sorted by creation date, with the most recently created tax rates appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/tax_rates?active={queryParameters.Active}&created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&inclusive={queryParameters.Inclusive}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<TaxRate list> settings

        ///<p>Creates a new tax rate.</p>
        let Create settings (formParameters: PostTaxRatesParams) =
            $"/v1/tax_rates"
            |> RestApi.postAsync<_, TaxRate> settings formParameters

        type RetrieveQueryParams = {
            TaxRate: string
            Expand: string list option
        }
        with
            static member Create (taxRate: string, ?expand: string list) =
                {
                    TaxRate = taxRate
                    Expand = expand
                }

        ///<p>Retrieves a tax rate with the given ID</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/tax_rates/{queryParameters.TaxRate}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<TaxRate> settings

        type UpdateQueryParams = {
            TaxRate: string
        }
        with
            static member Create (taxRate: string) =
                {
                    TaxRate = taxRate
                }

        ///<p>Updates an existing tax rate.</p>
        let Update settings (formParameters: PostTaxRatesTaxRateParams) (queryParameters: UpdateQueryParams) =
            $"/v1/tax_rates/{queryParameters.TaxRate}"
            |> RestApi.postAsync<_, TaxRate> settings formParameters

    module TerminalConnectionTokensService =

        ///<p>To connect to a reader the Stripe Terminal SDK needs to retrieve a short-lived connection token from Stripe, proxied through your server. On your backend, add an endpoint that creates and returns a connection token.</p>
        let Create settings (formParameters: PostTerminalConnectionTokensParams) =
            $"/v1/terminal/connection_tokens"
            |> RestApi.postAsync<_, TerminalConnectionToken> settings formParameters

    module TerminalLocationsService =

        type ListQueryParams = {
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of <code>Location</code> objects.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/terminal/locations?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<TerminalLocation list> settings

        ///<p>Creates a new <code>Location</code> object.</p>
        let Create settings (formParameters: PostTerminalLocationsParams) =
            $"/v1/terminal/locations"
            |> RestApi.postAsync<_, TerminalLocation> settings formParameters

        type DeleteQueryParams = {
            Location: string
        }
        with
            static member Create (location: string) =
                {
                    Location = location
                }

        ///<p>Deletes a <code>Location</code> object.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/terminal/locations/{queryParameters.Location}"
            |> RestApi.deleteAsync<DeletedTerminalLocation> settings

        type RetrieveQueryParams = {
            Location: string
            Expand: string list option
        }
        with
            static member Create (location: string, ?expand: string list) =
                {
                    Location = location
                    Expand = expand
                }

        ///<p>Retrieves a <code>Location</code> object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/terminal/locations/{queryParameters.Location}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<TerminalLocation> settings

        type UpdateQueryParams = {
            Location: string
        }
        with
            static member Create (location: string) =
                {
                    Location = location
                }

        ///<p>Updates a <code>Location</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formParameters: PostTerminalLocationsLocationParams) (queryParameters: UpdateQueryParams) =
            $"/v1/terminal/locations/{queryParameters.Location}"
            |> RestApi.postAsync<_, TerminalLocation> settings formParameters

    module TerminalReadersService =

        type ListQueryParams = {
            DeviceType: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            Location: string option
            StartingAfter: string option
            Status: string option
        }
        with
            static member Create (?deviceType: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?location: string, ?startingAfter: string, ?status: string) =
                {
                    DeviceType = deviceType
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    Location = location
                    StartingAfter = startingAfter
                    Status = status
                }

        ///<p>Returns a list of <code>Reader</code> objects.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/terminal/readers?device_type={queryParameters.DeviceType}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&location={queryParameters.Location}&starting_after={queryParameters.StartingAfter}&status={queryParameters.Status}"
            |> RestApi.getAsync<TerminalReader list> settings

        ///<p>Creates a new <code>Reader</code> object.</p>
        let Create settings (formParameters: PostTerminalReadersParams) =
            $"/v1/terminal/readers"
            |> RestApi.postAsync<_, TerminalReader> settings formParameters

        type DeleteQueryParams = {
            Reader: string
        }
        with
            static member Create (reader: string) =
                {
                    Reader = reader
                }

        ///<p>Deletes a <code>Reader</code> object.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/terminal/readers/{queryParameters.Reader}"
            |> RestApi.deleteAsync<DeletedTerminalReader> settings

        type RetrieveQueryParams = {
            Reader: string
            Expand: string list option
        }
        with
            static member Create (reader: string, ?expand: string list) =
                {
                    Reader = reader
                    Expand = expand
                }

        ///<p>Retrieves a <code>Reader</code> object.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/terminal/readers/{queryParameters.Reader}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<TerminalReader> settings

        type UpdateQueryParams = {
            Reader: string
        }
        with
            static member Create (reader: string) =
                {
                    Reader = reader
                }

        ///<p>Updates a <code>Reader</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formParameters: PostTerminalReadersReaderParams) (queryParameters: UpdateQueryParams) =
            $"/v1/terminal/readers/{queryParameters.Reader}"
            |> RestApi.postAsync<_, TerminalReader> settings formParameters

    module TokensService =

        ///<p>Creates a single-use token that represents a bank account’s details.
        ///This token can be used with any API method in place of a bank account dictionary. This token can be used only once, by attaching it to a <a href="#accounts">Custom account</a>.</p>
        let Create settings (formParameters: PostTokensParams) =
            $"/v1/tokens"
            |> RestApi.postAsync<_, Token> settings formParameters

        type RetrieveQueryParams = {
            Token: string
            Expand: string list option
        }
        with
            static member Create (token: string, ?expand: string list) =
                {
                    Token = token
                    Expand = expand
                }

        ///<p>Retrieves the token with the given ID.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/tokens/{queryParameters.Token}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Token> settings

    module TopupsService =

        type ListQueryParams = {
            Amount: int option
            Created: int option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
            Status: string option
        }
        with
            static member Create (?amount: int, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
                {
                    Amount = amount
                    Created = created
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                    Status = status
                }

        ///<p>Returns a list of top-ups.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/topups?amount={queryParameters.Amount}&created={queryParameters.Created}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}&status={queryParameters.Status}"
            |> RestApi.getAsync<Topup list> settings

        ///<p>Top up the balance of an account</p>
        let Create settings (formParameters: PostTopupsParams) =
            $"/v1/topups"
            |> RestApi.postAsync<_, Topup> settings formParameters

        type RetrieveQueryParams = {
            Topup: string
            Expand: string list option
        }
        with
            static member Create (topup: string, ?expand: string list) =
                {
                    Topup = topup
                    Expand = expand
                }

        ///<p>Retrieves the details of a top-up that has previously been created. Supply the unique top-up ID that was returned from your previous request, and Stripe will return the corresponding top-up information.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/topups/{queryParameters.Topup}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Topup> settings

        type UpdateQueryParams = {
            Topup: string
        }
        with
            static member Create (topup: string) =
                {
                    Topup = topup
                }

        ///<p>Updates the metadata of a top-up. Other top-up details are not editable by design.</p>
        let Update settings (formParameters: PostTopupsTopupParams) (queryParameters: UpdateQueryParams) =
            $"/v1/topups/{queryParameters.Topup}"
            |> RestApi.postAsync<_, Topup> settings formParameters

    module TopupsCancelService =

        type CancelQueryParams = {
            Topup: string
        }
        with
            static member Create (topup: string) =
                {
                    Topup = topup
                }

        ///<p>Cancels a top-up. Only pending top-ups can be canceled.</p>
        let Cancel settings (formParameters: PostTopupsTopupCancelParams) (queryParameters: CancelQueryParams) =
            $"/v1/topups/{queryParameters.Topup}/cancel"
            |> RestApi.postAsync<_, Topup> settings formParameters

    module TransfersService =

        type ListQueryParams = {
            Created: int option
            Destination: string option
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
            TransferGroup: string option
        }
        with
            static member Create (?created: int, ?destination: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?transferGroup: string) =
                {
                    Created = created
                    Destination = destination
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                    TransferGroup = transferGroup
                }

        ///<p>Returns a list of existing transfers sent to connected accounts. The transfers are returned in sorted order, with the most recently created transfers appearing first.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/transfers?created={queryParameters.Created}&destination={queryParameters.Destination}&ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}&transfer_group={queryParameters.TransferGroup}"
            |> RestApi.getAsync<Transfer list> settings

        ///<p>To send funds from your Stripe account to a connected account, you create a new transfer object. Your <a href="#balance">Stripe balance</a> must be able to cover the transfer amount, or you’ll receive an “Insufficient Funds” error.</p>
        let Create settings (formParameters: PostTransfersParams) =
            $"/v1/transfers"
            |> RestApi.postAsync<_, Transfer> settings formParameters

        type RetrieveQueryParams = {
            Transfer: string
            Expand: string list option
        }
        with
            static member Create (transfer: string, ?expand: string list) =
                {
                    Transfer = transfer
                    Expand = expand
                }

        ///<p>Retrieves the details of an existing transfer. Supply the unique transfer ID from either a transfer creation request or the transfer list, and Stripe will return the corresponding transfer information.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/transfers/{queryParameters.Transfer}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<Transfer> settings

        type UpdateQueryParams = {
            Transfer: string
        }
        with
            static member Create (transfer: string) =
                {
                    Transfer = transfer
                }

        ///<p>Updates the specified transfer by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request accepts only metadata as an argument.</p>
        let Update settings (formParameters: PostTransfersTransferParams) (queryParameters: UpdateQueryParams) =
            $"/v1/transfers/{queryParameters.Transfer}"
            |> RestApi.postAsync<_, Transfer> settings formParameters

    module TransfersReversalsService =

        type ListQueryParams = {
            Id: string
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (id: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    Id = id
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>You can see a list of the reversals belonging to a specific transfer. Note that the 10 most recent reversals are always available by default on the transfer object. If you need more than those 10, you can use this API method and the <code>limit</code> and <code>starting_after</code> parameters to page through additional reversals.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/transfers/{queryParameters.Id}/reversals?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<TransferReversal list> settings

        type CreateQueryParams = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>When you create a new reversal, you must specify a transfer to create it on.
        ///When reversing transfers, you can optionally reverse part of the transfer. You can do so as many times as you wish until the entire transfer has been reversed.
        ///Once entirely reversed, a transfer can’t be reversed again. This method will return an error when called on an already-reversed transfer, or when trying to reverse more money than is left on a transfer.</p>
        let Create settings (formParameters: PostTransfersIdReversalsParams) (queryParameters: CreateQueryParams) =
            $"/v1/transfers/{queryParameters.Id}/reversals"
            |> RestApi.postAsync<_, TransferReversal> settings formParameters

        type RetrieveQueryParams = {
            Id: string
            Transfer: string
            Expand: string list option
        }
        with
            static member Create (id: string, transfer: string, ?expand: string list) =
                {
                    Id = id
                    Transfer = transfer
                    Expand = expand
                }

        ///<p>By default, you can see the 10 most recent reversals stored directly on the transfer object, but you can also retrieve details about a specific reversal stored on the transfer.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/transfers/{queryParameters.Transfer}/reversals/{queryParameters.Id}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<TransferReversal> settings

        type UpdateQueryParams = {
            Id: string
            Transfer: string
        }
        with
            static member Create (id: string, transfer: string) =
                {
                    Id = id
                    Transfer = transfer
                }

        ///<p>Updates the specified reversal by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request only accepts metadata and description as arguments.</p>
        let Update settings (formParameters: PostTransfersTransferReversalsIdParams) (queryParameters: UpdateQueryParams) =
            $"/v1/transfers/{queryParameters.Transfer}/reversals/{queryParameters.Id}"
            |> RestApi.postAsync<_, TransferReversal> settings formParameters

    module WebhookEndpointsService =

        type ListQueryParams = {
            EndingBefore: string option
            Expand: string list option
            Limit: int option
            StartingAfter: string option
        }
        with
            static member Create (?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
                {
                    EndingBefore = endingBefore
                    Expand = expand
                    Limit = limit
                    StartingAfter = startingAfter
                }

        ///<p>Returns a list of your webhook endpoints.</p>
        let List settings (queryParameters: ListQueryParams) =
            $"/v1/webhook_endpoints?ending_before={queryParameters.EndingBefore}&expand={queryParameters.Expand}&limit={queryParameters.Limit}&starting_after={queryParameters.StartingAfter}"
            |> RestApi.getAsync<WebhookEndpoint list> settings

        ///<p>A webhook endpoint must have a <code>url</code> and a list of <code>enabled_events</code>. You may optionally specify the Boolean <code>connect</code> parameter. If set to true, then a Connect webhook endpoint that notifies the specified <code>url</code> about events from all connected accounts is created; otherwise an account webhook endpoint that notifies the specified <code>url</code> only about events from your account is created. You can also create webhook endpoints in the <a href="https://dashboard.stripe.com/account/webhooks">webhooks settings</a> section of the Dashboard.</p>
        let Create settings (formParameters: PostWebhookEndpointsParams) =
            $"/v1/webhook_endpoints"
            |> RestApi.postAsync<_, WebhookEndpoint> settings formParameters

        type DeleteQueryParams = {
            WebhookEndpoint: string
        }
        with
            static member Create (webhookEndpoint: string) =
                {
                    WebhookEndpoint = webhookEndpoint
                }

        ///<p>You can also delete webhook endpoints via the <a href="https://dashboard.stripe.com/account/webhooks">webhook endpoint management</a> page of the Stripe dashboard.</p>
        let Delete settings (queryParameters: DeleteQueryParams) =
            $"/v1/webhook_endpoints/{queryParameters.WebhookEndpoint}"
            |> RestApi.deleteAsync<DeletedWebhookEndpoint> settings

        type RetrieveQueryParams = {
            WebhookEndpoint: string
            Expand: string list option
        }
        with
            static member Create (webhookEndpoint: string, ?expand: string list) =
                {
                    WebhookEndpoint = webhookEndpoint
                    Expand = expand
                }

        ///<p>Retrieves the webhook endpoint with the given ID.</p>
        let Retrieve settings (queryParameters: RetrieveQueryParams) =
            $"/v1/webhook_endpoints/{queryParameters.WebhookEndpoint}?expand={queryParameters.Expand}"
            |> RestApi.getAsync<WebhookEndpoint> settings

        type UpdateQueryParams = {
            WebhookEndpoint: string
        }
        with
            static member Create (webhookEndpoint: string) =
                {
                    WebhookEndpoint = webhookEndpoint
                }

        ///<p>Updates the webhook endpoint. You may edit the <code>url</code>, the list of <code>enabled_events</code>, and the status of your endpoint.</p>
        let Update settings (formParameters: PostWebhookEndpointsWebhookEndpointParams) (queryParameters: UpdateQueryParams) =
            $"/v1/webhook_endpoints/{queryParameters.WebhookEndpoint}"
            |> RestApi.postAsync<_, WebhookEndpoint> settings formParameters

