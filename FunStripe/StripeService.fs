namespace FunStripe

open StripeModel
open StripeRequest

module StripeService =

    module ThreeDSecure =

        ///<p>Initiate 3D Secure authentication.</p>
        let Create settings (formOptions: ThreeDSecure'CreateOptions) =

            $"/v1/3d_secure"
            |> RestApi.postAsync<_, ThreeDSecure> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/3d_secure/{options.ThreeDSecure}"
            |> RestApi.getAsync<ThreeDSecure> settings qs

    module Account =

        type RetrieveOptions = {
            Expand: string list option
        }
        with
            static member Create (?expand: string list) =
                {
                    Expand = expand
                }

        ///<p>Retrieves the details of an account.</p>
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/account"
            |> RestApi.getAsync<Account> settings qs

    module AccountLinks =

        ///<p>Creates an AccountLink object that includes a single-use Stripe URL that the platform can redirect their user to in order to take them through the Connect Onboarding flow.</p>
        let Create settings (formOptions: AccountLinks'CreateOptions) =

            $"/v1/account_links"
            |> RestApi.postAsync<_, AccountLink> settings (Map.empty) formOptions

    module Accounts =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/accounts"
            |> RestApi.getAsync<Account list> settings qs

        ///<p>With <a href="/docs/connect">Connect</a>, you can create Stripe accounts for your users.
        ///To do this, you’ll first need to <a href="https://dashboard.stripe.com/account/applications/settings">register your platform</a>.</p>
        let Create settings (formOptions: Accounts'CreateOptions) =

            $"/v1/accounts"
            |> RestApi.postAsync<_, Account> settings (Map.empty) formOptions

        type DeleteOptions = {
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
        let Delete settings (options: DeleteOptions) =

            $"/v1/accounts/{options.Account}"
            |> RestApi.deleteAsync<DeletedAccount> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/accounts/{options.Account}"
            |> RestApi.getAsync<Account> settings qs

        type UpdateOptions = {
            Account: string
        }
        with
            static member Create (account: string) =
                {
                    Account = account
                }

        ///<p>Updates a connected <a href="/docs/connect/accounts">Express or Custom account</a> by setting the values of the parameters passed. Any parameters not provided are left unchanged. Most parameters can be changed only for Custom accounts. (These are marked <strong>Custom Only</strong> below.) Parameters marked <strong>Custom and Express</strong> are supported by both account types.
        ///To update your own account, use the <a href="https://dashboard.stripe.com/account">Dashboard</a>. Refer to our <a href="/docs/connect/updating-accounts">Connect</a> documentation to learn more about updating accounts.</p>
        let Update settings (formOptions: Accounts'UpdateOptions) (options: UpdateOptions) =

            $"/v1/accounts/{options.Account}"
            |> RestApi.postAsync<_, Account> settings (Map.empty) formOptions

    module AccountsCapabilities =

        type CapabilitiesOptions = {
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
        let Capabilities settings (options: CapabilitiesOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/accounts/{options.Account}/capabilities"
            |> RestApi.getAsync<Capability list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/accounts/{options.Account}/capabilities/{options.Capability}"
            |> RestApi.getAsync<Capability> settings qs

        type UpdateOptions = {
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
        let Update settings (formOptions: AccountsCapabilities'UpdateOptions) (options: UpdateOptions) =

            $"/v1/accounts/{options.Account}/capabilities/{options.Capability}"
            |> RestApi.postAsync<_, Capability> settings (Map.empty) formOptions

    module AccountsExternalAccounts =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/accounts/{options.Account}/external_accounts"
            |> RestApi.getAsync<ExternalAccount list> settings qs

        type CreateOptions = {
            Account: string
        }
        with
            static member Create (account: string) =
                {
                    Account = account
                }

        ///<p>Create an external account for a given account.</p>
        let Create settings (formOptions: AccountsExternalAccounts'CreateOptions) (options: CreateOptions) =

            $"/v1/accounts/{options.Account}/external_accounts"
            |> RestApi.postAsync<_, ExternalAccount> settings (Map.empty) formOptions

        type DeleteOptions = {
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
        let Delete settings (options: DeleteOptions) =

            $"/v1/accounts/{options.Account}/external_accounts/{options.Id}"
            |> RestApi.deleteAsync<DeletedExternalAccount> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/accounts/{options.Account}/external_accounts/{options.Id}"
            |> RestApi.getAsync<ExternalAccount> settings qs

        type UpdateOptions = {
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
        let Update settings (formOptions: AccountsExternalAccounts'UpdateOptions) (options: UpdateOptions) =

            $"/v1/accounts/{options.Account}/external_accounts/{options.Id}"
            |> RestApi.postAsync<_, ExternalAccount> settings (Map.empty) formOptions

    module AccountsLoginLinks =

        type CreateOptions = {
            Account: string
        }
        with
            static member Create (account: string) =
                {
                    Account = account
                }

        ///<p>Creates a single-use login link for an Express account to access their Stripe dashboard.
        ///<strong>You may only create login links for <a href="/docs/connect/express-accounts">Express accounts</a> connected to your platform</strong>.</p>
        let Create settings (formOptions: AccountsLoginLinks'CreateOptions) (options: CreateOptions) =

            $"/v1/accounts/{options.Account}/login_links"
            |> RestApi.postAsync<_, LoginLink> settings (Map.empty) formOptions

    module AccountsPersons =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("relationship", options.Relationship |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/accounts/{options.Account}/persons"
            |> RestApi.getAsync<Person list> settings qs

        type CreateOptions = {
            Account: string
        }
        with
            static member Create (account: string) =
                {
                    Account = account
                }

        ///<p>Creates a new person.</p>
        let Create settings (formOptions: AccountsPersons'CreateOptions) (options: CreateOptions) =

            $"/v1/accounts/{options.Account}/persons"
            |> RestApi.postAsync<_, Person> settings (Map.empty) formOptions

        type DeleteOptions = {
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
        let Delete settings (options: DeleteOptions) =

            $"/v1/accounts/{options.Account}/persons/{options.Person}"
            |> RestApi.deleteAsync<DeletedPerson> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/accounts/{options.Account}/persons/{options.Person}"
            |> RestApi.getAsync<Person> settings qs

        type UpdateOptions = {
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
        let Update settings (formOptions: AccountsPersons'UpdateOptions) (options: UpdateOptions) =

            $"/v1/accounts/{options.Account}/persons/{options.Person}"
            |> RestApi.postAsync<_, Person> settings (Map.empty) formOptions

    module AccountsReject =

        type RejectOptions = {
            Account: string
        }
        with
            static member Create (account: string) =
                {
                    Account = account
                }

        ///<p>With <a href="/docs/connect">Connect</a>, you may flag accounts as suspicious.
        ///Test-mode Custom and Express accounts can be rejected at any time. Accounts created using live-mode keys may only be rejected once all balances are zero.</p>
        let Reject settings (formOptions: AccountsReject'RejectOptions) (options: RejectOptions) =

            $"/v1/accounts/{options.Account}/reject"
            |> RestApi.postAsync<_, Account> settings (Map.empty) formOptions

    module ApplePayDomains =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("domain_name", options.DomainName |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/apple_pay/domains"
            |> RestApi.getAsync<ApplePayDomain list> settings qs

        ///<p>Create an apple pay domain.</p>
        let Create settings (formOptions: ApplePayDomains'CreateOptions) =

            $"/v1/apple_pay/domains"
            |> RestApi.postAsync<_, ApplePayDomain> settings (Map.empty) formOptions

        type DeleteOptions = {
            Domain: string
        }
        with
            static member Create (domain: string) =
                {
                    Domain = domain
                }

        ///<p>Delete an apple pay domain.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/apple_pay/domains/{options.Domain}"
            |> RestApi.deleteAsync<DeletedApplePayDomain> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/apple_pay/domains/{options.Domain}"
            |> RestApi.getAsync<ApplePayDomain> settings qs

    module ApplicationFees =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("charge", options.Charge |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/application_fees"
            |> RestApi.getAsync<ApplicationFee list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/application_fees/{options.Id}"
            |> RestApi.getAsync<ApplicationFee> settings qs

    module ApplicationFeesRefunds =

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/application_fees/{options.Fee}/refunds/{options.Id}"
            |> RestApi.getAsync<FeeRefund> settings qs

        type UpdateOptions = {
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
        let Update settings (formOptions: ApplicationFeesRefunds'UpdateOptions) (options: UpdateOptions) =

            $"/v1/application_fees/{options.Fee}/refunds/{options.Id}"
            |> RestApi.postAsync<_, FeeRefund> settings (Map.empty) formOptions

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/application_fees/{options.Id}/refunds"
            |> RestApi.getAsync<FeeRefund list> settings qs

        type CreateOptions = {
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
        let Create settings (formOptions: ApplicationFeesRefunds'CreateOptions) (options: CreateOptions) =

            $"/v1/application_fees/{options.Id}/refunds"
            |> RestApi.postAsync<_, FeeRefund> settings (Map.empty) formOptions

    module Balance =

        type RetrieveOptions = {
            Expand: string list option
        }
        with
            static member Create (?expand: string list) =
                {
                    Expand = expand
                }

        ///<p>Retrieves the current account balance, based on the authentication that was used to make the request.
        /// For a sample request, see <a href="/docs/connect/account-balances#accounting-for-negative-balances">Accounting for negative balances</a>.</p>
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/balance"
            |> RestApi.getAsync<Balance> settings qs

    module BalanceTransactions =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("available_on", options.AvailableOn |> box); ("created", options.Created |> box); ("currency", options.Currency |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payout", options.Payout |> box); ("source", options.Source |> box); ("starting_after", options.StartingAfter |> box); ("type", options.``type`` |> box)] |> Map.ofList
            $"/v1/balance_transactions"
            |> RestApi.getAsync<BalanceTransaction list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/balance_transactions/{options.Id}"
            |> RestApi.getAsync<BalanceTransaction> settings qs

    module BillingPortalSessions =

        ///<p>Creates a session of the customer portal.</p>
        let Create settings (formOptions: BillingPortalSessions'CreateOptions) =

            $"/v1/billing_portal/sessions"
            |> RestApi.postAsync<_, BillingPortalSession> settings (Map.empty) formOptions

    module BitcoinReceivers =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("active", options.Active |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("filled", options.Filled |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("uncaptured_funds", options.UncapturedFunds |> box)] |> Map.ofList
            $"/v1/bitcoin/receivers"
            |> RestApi.getAsync<BitcoinReceiver list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/bitcoin/receivers/{options.Id}"
            |> RestApi.getAsync<BitcoinReceiver> settings qs

    module BitcoinReceiversTransactions =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/bitcoin/receivers/{options.Receiver}/transactions"
            |> RestApi.getAsync<BitcoinTransaction list> settings qs

    module Charges =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("starting_after", options.StartingAfter |> box); ("transfer_group", options.TransferGroup |> box)] |> Map.ofList
            $"/v1/charges"
            |> RestApi.getAsync<Charge list> settings qs

        ///<p>To charge a credit card or other payment source, you create a <code>Charge</code> object. If your API key is in test mode, the supplied payment source (e.g., card) won’t actually be charged, although everything else will occur as if in live mode. (Stripe assumes that the charge would have completed successfully).</p>
        let Create settings (formOptions: Charges'CreateOptions) =

            $"/v1/charges"
            |> RestApi.postAsync<_, Charge> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/charges/{options.Charge}"
            |> RestApi.getAsync<Charge> settings qs

        type UpdateOptions = {
            Charge: string
        }
        with
            static member Create (charge: string) =
                {
                    Charge = charge
                }

        ///<p>Updates the specified charge by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formOptions: Charges'UpdateOptions) (options: UpdateOptions) =

            $"/v1/charges/{options.Charge}"
            |> RestApi.postAsync<_, Charge> settings (Map.empty) formOptions

    module ChargesCapture =

        type CaptureOptions = {
            Charge: string
        }
        with
            static member Create (charge: string) =
                {
                    Charge = charge
                }

        ///<p>Capture the payment of an existing, uncaptured, charge. This is the second half of the two-step payment flow, where first you <a href="#create_charge">created a charge</a> with the capture option set to false.
        ///Uncaptured payments expire exactly seven days after they are created. If they are not captured by that point in time, they will be marked as refunded and will no longer be capturable.</p>
        let Capture settings (formOptions: ChargesCapture'CaptureOptions) (options: CaptureOptions) =

            $"/v1/charges/{options.Charge}/capture"
            |> RestApi.postAsync<_, Charge> settings (Map.empty) formOptions

    module ChargesRefunds =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/charges/{options.Charge}/refunds"
            |> RestApi.getAsync<Refund list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/charges/{options.Charge}/refunds/{options.Refund}"
            |> RestApi.getAsync<Refund> settings qs

    module CheckoutSessions =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("starting_after", options.StartingAfter |> box); ("subscription", options.Subscription |> box)] |> Map.ofList
            $"/v1/checkout/sessions"
            |> RestApi.getAsync<CheckoutSession list> settings qs

        ///<p>Creates a Session object.</p>
        let Create settings (formOptions: CheckoutSessions'CreateOptions) =

            $"/v1/checkout/sessions"
            |> RestApi.postAsync<_, CheckoutSession> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/checkout/sessions/{options.Session}"
            |> RestApi.getAsync<CheckoutSession> settings qs

    module CheckoutSessionsLineItems =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/checkout/sessions/{options.Session}/line_items"
            |> RestApi.getAsync<Item list> settings qs

    module CountrySpecs =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/country_specs"
            |> RestApi.getAsync<CountrySpec list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/country_specs/{options.Country}"
            |> RestApi.getAsync<CountrySpec> settings qs

    module Coupons =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/coupons"
            |> RestApi.getAsync<Coupon list> settings qs

        ///<p>You can create coupons easily via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. Coupon creation is also accessible via the API if you need to create coupons on the fly.
        ///A coupon has either a <code>percent_off</code> or an <code>amount_off</code> and <code>currency</code>. If you set an <code>amount_off</code>, that amount will be subtracted from any invoice’s subtotal. For example, an invoice with a subtotal of <currency>100</currency> will have a final total of <currency>0</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it and an invoice with a subtotal of <currency>300</currency> will have a final total of <currency>100</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it.</p>
        let Create settings (formOptions: Coupons'CreateOptions) =

            $"/v1/coupons"
            |> RestApi.postAsync<_, Coupon> settings (Map.empty) formOptions

        type DeleteOptions = {
            Coupon: string
        }
        with
            static member Create (coupon: string) =
                {
                    Coupon = coupon
                }

        ///<p>You can delete coupons via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. However, deleting a coupon does not affect any customers who have already applied the coupon; it means that new customers can’t redeem the coupon. You can also delete coupons via the API.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/coupons/{options.Coupon}"
            |> RestApi.deleteAsync<DeletedCoupon> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/coupons/{options.Coupon}"
            |> RestApi.getAsync<Coupon> settings qs

        type UpdateOptions = {
            Coupon: string
        }
        with
            static member Create (coupon: string) =
                {
                    Coupon = coupon
                }

        ///<p>Updates the metadata of a coupon. Other coupon details (currency, duration, amount_off) are, by design, not editable.</p>
        let Update settings (formOptions: Coupons'UpdateOptions) (options: UpdateOptions) =

            $"/v1/coupons/{options.Coupon}"
            |> RestApi.postAsync<_, Coupon> settings (Map.empty) formOptions

    module CreditNotes =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/credit_notes"
            |> RestApi.getAsync<CreditNote list> settings qs

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
        let Create settings (formOptions: CreditNotes'CreateOptions) =

            $"/v1/credit_notes"
            |> RestApi.postAsync<_, CreditNote> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/credit_notes/{options.Id}"
            |> RestApi.getAsync<CreditNote> settings qs

        type UpdateOptions = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Updates an existing credit note.</p>
        let Update settings (formOptions: CreditNotes'UpdateOptions) (options: UpdateOptions) =

            $"/v1/credit_notes/{options.Id}"
            |> RestApi.postAsync<_, CreditNote> settings (Map.empty) formOptions

    module CreditNotesPreview =

        type PreviewOptions = {
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
        let Preview settings (options: PreviewOptions) =
            let qs = [("invoice", options.Invoice |> box); ("amount", options.Amount |> box); ("credit_amount", options.CreditAmount |> box); ("expand", options.Expand |> box); ("lines", options.Lines |> box); ("memo", options.Memo |> box); ("metadata", options.Metadata |> box); ("out_of_band_amount", options.OutOfBandAmount |> box); ("reason", options.Reason |> box); ("refund", options.Refund |> box); ("refund_amount", options.RefundAmount |> box)] |> Map.ofList
            $"/v1/credit_notes/preview"
            |> RestApi.getAsync<CreditNote> settings qs

    module CreditNotesPreviewLines =

        type PreviewLinesOptions = {
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
        let PreviewLines settings (options: PreviewLinesOptions) =
            let qs = [("invoice", options.Invoice |> box); ("amount", options.Amount |> box); ("credit_amount", options.CreditAmount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("lines", options.Lines |> box); ("memo", options.Memo |> box); ("metadata", options.Metadata |> box); ("out_of_band_amount", options.OutOfBandAmount |> box); ("reason", options.Reason |> box); ("refund", options.Refund |> box); ("refund_amount", options.RefundAmount |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/credit_notes/preview/lines"
            |> RestApi.getAsync<CreditNoteLineItem list> settings qs

    module CreditNotesLines =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/credit_notes/{options.CreditNote}/lines"
            |> RestApi.getAsync<CreditNoteLineItem list> settings qs

    module CreditNotesVoid =

        type VoidCreditNoteOptions = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Marks a credit note as void. Learn more about <a href="/docs/billing/invoices/credit-notes#voiding">voiding credit notes</a>.</p>
        let VoidCreditNote settings (formOptions: CreditNotesVoid'VoidCreditNoteOptions) (options: VoidCreditNoteOptions) =

            $"/v1/credit_notes/{options.Id}/void"
            |> RestApi.postAsync<_, CreditNote> settings (Map.empty) formOptions

    module Customers =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("email", options.Email |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/customers"
            |> RestApi.getAsync<Customer list> settings qs

        ///<p>Creates a new customer object.</p>
        let Create settings (formOptions: Customers'CreateOptions) =

            $"/v1/customers"
            |> RestApi.postAsync<_, Customer> settings (Map.empty) formOptions

        type DeleteOptions = {
            Customer: string
        }
        with
            static member Create (customer: string) =
                {
                    Customer = customer
                }

        ///<p>Permanently deletes a customer. It cannot be undone. Also immediately cancels any active subscriptions on the customer.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/customers/{options.Customer}"
            |> RestApi.deleteAsync<DeletedCustomer> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/customers/{options.Customer}"
            |> RestApi.getAsync<Customer> settings qs

        type UpdateOptions = {
            Customer: string
        }
        with
            static member Create (customer: string) =
                {
                    Customer = customer
                }

        ///<p>Updates the specified customer by setting the values of the parameters passed. Any parameters not provided will be left unchanged. For example, if you pass the <strong>source</strong> parameter, that becomes the customer’s active source (e.g., a card) to be used for all charges in the future. When you update a customer to a new valid card source by passing the <strong>source</strong> parameter: for each of the customer’s current subscriptions, if the subscription bills automatically and is in the <code>past_due</code> state, then the latest open invoice for the subscription with automatic collection enabled will be retried. This retry will not count as an automatic retry, and will not affect the next regularly scheduled payment for the invoice. Changing the <strong>default_source</strong> for a customer will not trigger this behavior.
        ///This request accepts mostly the same arguments as the customer creation call.</p>
        let Update settings (formOptions: Customers'UpdateOptions) (options: UpdateOptions) =

            $"/v1/customers/{options.Customer}"
            |> RestApi.postAsync<_, Customer> settings (Map.empty) formOptions

    module CustomersBalanceTransactions =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/customers/{options.Customer}/balance_transactions"
            |> RestApi.getAsync<CustomerBalanceTransaction list> settings qs

        type CreateOptions = {
            Customer: string
        }
        with
            static member Create (customer: string) =
                {
                    Customer = customer
                }

        ///<p>Creates an immutable transaction that updates the customer’s credit <a href="/docs/billing/customer/balance">balance</a>.</p>
        let Create settings (formOptions: CustomersBalanceTransactions'CreateOptions) (options: CreateOptions) =

            $"/v1/customers/{options.Customer}/balance_transactions"
            |> RestApi.postAsync<_, CustomerBalanceTransaction> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/customers/{options.Customer}/balance_transactions/{options.Transaction}"
            |> RestApi.getAsync<CustomerBalanceTransaction> settings qs

        type UpdateOptions = {
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
        let Update settings (formOptions: CustomersBalanceTransactions'UpdateOptions) (options: UpdateOptions) =

            $"/v1/customers/{options.Customer}/balance_transactions/{options.Transaction}"
            |> RestApi.postAsync<_, CustomerBalanceTransaction> settings (Map.empty) formOptions

    module CustomersDiscount =

        type DeleteDiscountOptions = {
            Customer: string
        }
        with
            static member Create (customer: string) =
                {
                    Customer = customer
                }

        ///<p>Removes the currently applied discount on a customer.</p>
        let DeleteDiscount settings (options: DeleteDiscountOptions) =

            $"/v1/customers/{options.Customer}/discount"
            |> RestApi.deleteAsync<DeletedDiscount> settings (Map.empty)

    module CustomersSources =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("object", options.Object |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/customers/{options.Customer}/sources"
            |> RestApi.getAsync<PaymentSource list> settings qs

        type CreateOptions = {
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
        let Create settings (formOptions: CustomersSources'CreateOptions) (options: CreateOptions) =

            $"/v1/customers/{options.Customer}/sources"
            |> RestApi.postAsync<_, PaymentSource> settings (Map.empty) formOptions

        type DeleteOptions = {
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
        let Delete settings (formOptions: CustomersSources'DeleteOptions) (options: DeleteOptions) =

            $"/v1/customers/{options.Customer}/sources/{options.Id}"
            |> RestApi.deleteAsync<PaymentSource> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/customers/{options.Customer}/sources/{options.Id}"
            |> RestApi.getAsync<PaymentSource> settings qs

        type UpdateOptions = {
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
        let Update settings (formOptions: CustomersSources'UpdateOptions) (options: UpdateOptions) =

            $"/v1/customers/{options.Customer}/sources/{options.Id}"
            |> RestApi.postAsync<_, Card> settings (Map.empty) formOptions

    module CustomersSourcesVerify =

        type VerifyOptions = {
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
        let Verify settings (formOptions: CustomersSourcesVerify'VerifyOptions) (options: VerifyOptions) =

            $"/v1/customers/{options.Customer}/sources/{options.Id}/verify"
            |> RestApi.postAsync<_, BankAccount> settings (Map.empty) formOptions

    module CustomersTaxIds =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/customers/{options.Customer}/tax_ids"
            |> RestApi.getAsync<TaxId list> settings qs

        type CreateOptions = {
            Customer: string
        }
        with
            static member Create (customer: string) =
                {
                    Customer = customer
                }

        ///<p>Creates a new <code>TaxID</code> object for a customer.</p>
        let Create settings (formOptions: CustomersTaxIds'CreateOptions) (options: CreateOptions) =

            $"/v1/customers/{options.Customer}/tax_ids"
            |> RestApi.postAsync<_, TaxId> settings (Map.empty) formOptions

        type DeleteOptions = {
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
        let Delete settings (options: DeleteOptions) =

            $"/v1/customers/{options.Customer}/tax_ids/{options.Id}"
            |> RestApi.deleteAsync<DeletedTaxId> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/customers/{options.Customer}/tax_ids/{options.Id}"
            |> RestApi.getAsync<TaxId> settings qs

    module Disputes =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("charge", options.Charge |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/disputes"
            |> RestApi.getAsync<Dispute list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/disputes/{options.Dispute}"
            |> RestApi.getAsync<Dispute> settings qs

        type UpdateOptions = {
            Dispute: string
        }
        with
            static member Create (dispute: string) =
                {
                    Dispute = dispute
                }

        ///<p>When you get a dispute, contacting your customer is always the best first step. If that doesn’t work, you can submit evidence to help us resolve the dispute in your favor. You can do this in your <a href="https://dashboard.stripe.com/disputes">dashboard</a>, but if you prefer, you can use the API to submit evidence programmatically.
        ///Depending on your dispute type, different evidence fields will give you a better chance of winning your dispute. To figure out which evidence fields to provide, see our <a href="/docs/disputes/categories">guide to dispute types</a>.</p>
        let Update settings (formOptions: Disputes'UpdateOptions) (options: UpdateOptions) =

            $"/v1/disputes/{options.Dispute}"
            |> RestApi.postAsync<_, Dispute> settings (Map.empty) formOptions

    module DisputesClose =

        type CloseOptions = {
            Dispute: string
        }
        with
            static member Create (dispute: string) =
                {
                    Dispute = dispute
                }

        ///<p>Closing the dispute for a charge indicates that you do not have any evidence to submit and are essentially dismissing the dispute, acknowledging it as lost.
        ///The status of the dispute will change from <code>needs_response</code> to <code>lost</code>. <em>Closing a dispute is irreversible</em>.</p>
        let Close settings (formOptions: DisputesClose'CloseOptions) (options: CloseOptions) =

            $"/v1/disputes/{options.Dispute}/close"
            |> RestApi.postAsync<_, Dispute> settings (Map.empty) formOptions

    module EphemeralKeys =

        ///<p>Creates a short-lived API key for a given resource.</p>
        let Create settings (formOptions: EphemeralKeys'CreateOptions) =

            $"/v1/ephemeral_keys"
            |> RestApi.postAsync<_, EphemeralKey> settings (Map.empty) formOptions

        type DeleteOptions = {
            Key: string
        }
        with
            static member Create (key: string) =
                {
                    Key = key
                }

        ///<p>Invalidates a short-lived API key for a given resource.</p>
        let Delete settings (formOptions: EphemeralKeys'DeleteOptions) (options: DeleteOptions) =

            $"/v1/ephemeral_keys/{options.Key}"
            |> RestApi.deleteAsync<EphemeralKey> settings (Map.empty)

    module Events =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("delivery_success", options.DeliverySuccess |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("type", options.``type`` |> box); ("types", options.Types |> box)] |> Map.ofList
            $"/v1/events"
            |> RestApi.getAsync<Event list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/events/{options.Id}"
            |> RestApi.getAsync<Event> settings qs

    module ExchangeRates =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/exchange_rates"
            |> RestApi.getAsync<ExchangeRate list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/exchange_rates/{options.RateId}"
            |> RestApi.getAsync<ExchangeRate> settings qs

    module FileLinks =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("expired", options.Expired |> box); ("file", options.File |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/file_links"
            |> RestApi.getAsync<FileLink list> settings qs

        ///<p>Creates a new file link object.</p>
        let Create settings (formOptions: FileLinks'CreateOptions) =

            $"/v1/file_links"
            |> RestApi.postAsync<_, FileLink> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/file_links/{options.Link}"
            |> RestApi.getAsync<FileLink> settings qs

        type UpdateOptions = {
            Link: string
        }
        with
            static member Create (link: string) =
                {
                    Link = link
                }

        ///<p>Updates an existing file link object. Expired links can no longer be updated.</p>
        let Update settings (formOptions: FileLinks'UpdateOptions) (options: UpdateOptions) =

            $"/v1/file_links/{options.Link}"
            |> RestApi.postAsync<_, FileLink> settings (Map.empty) formOptions

    module Files =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("purpose", options.Purpose |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/files"
            |> RestApi.getAsync<File list> settings qs

        ///<p>To upload a file to Stripe, you’ll need to send a request of type <code>multipart/form-data</code>. The request should contain the file you would like to upload, as well as the parameters for creating a file.
        ///All of Stripe’s officially supported Client libraries should have support for sending <code>multipart/form-data</code>.</p>
        let Create settings (formOptions: Files'CreateOptions) =

            $"/v1/files"
            |> RestApi.postAsync<_, File> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/files/{options.File}"
            |> RestApi.getAsync<File> settings qs

    module Invoiceitems =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("pending", options.Pending |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/invoiceitems"
            |> RestApi.getAsync<Invoiceitem list> settings qs

        ///<p>Creates an item to be added to a draft invoice (up to 250 items per invoice). If no invoice is specified, the item will be on the next invoice created for the customer specified.</p>
        let Create settings (formOptions: Invoiceitems'CreateOptions) =

            $"/v1/invoiceitems"
            |> RestApi.postAsync<_, Invoiceitem> settings (Map.empty) formOptions

        type DeleteOptions = {
            Invoiceitem: string
        }
        with
            static member Create (invoiceitem: string) =
                {
                    Invoiceitem = invoiceitem
                }

        ///<p>Deletes an invoice item, removing it from an invoice. Deleting invoice items is only possible when they’re not attached to invoices, or if it’s attached to a draft invoice.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/invoiceitems/{options.Invoiceitem}"
            |> RestApi.deleteAsync<DeletedInvoiceitem> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/invoiceitems/{options.Invoiceitem}"
            |> RestApi.getAsync<Invoiceitem> settings qs

        type UpdateOptions = {
            Invoiceitem: string
        }
        with
            static member Create (invoiceitem: string) =
                {
                    Invoiceitem = invoiceitem
                }

        ///<p>Updates the amount or description of an invoice item on an upcoming invoice. Updating an invoice item is only possible before the invoice it’s attached to is closed.</p>
        let Update settings (formOptions: Invoiceitems'UpdateOptions) (options: UpdateOptions) =

            $"/v1/invoiceitems/{options.Invoiceitem}"
            |> RestApi.postAsync<_, Invoiceitem> settings (Map.empty) formOptions

    module Invoices =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("collection_method", options.CollectionMethod |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("due_date", options.DueDate |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("subscription", options.Subscription |> box)] |> Map.ofList
            $"/v1/invoices"
            |> RestApi.getAsync<Invoice list> settings qs

        ///<p>This endpoint creates a draft invoice for a given customer. The draft invoice created pulls in all pending invoice items on that customer, including prorations. The invoice remains a draft until you <a href="#finalize_invoice">finalize</a> the invoice, which allows you to <a href="#pay_invoice">pay</a> or <a href="#send_invoice">send</a> the invoice to your customers.</p>
        let Create settings (formOptions: Invoices'CreateOptions) =

            $"/v1/invoices"
            |> RestApi.postAsync<_, Invoice> settings (Map.empty) formOptions

        type DeleteOptions = {
            Invoice: string
        }
        with
            static member Create (invoice: string) =
                {
                    Invoice = invoice
                }

        ///<p>Permanently deletes a one-off invoice draft. This cannot be undone. Attempts to delete invoices that are no longer in a draft state will fail; once an invoice has been finalized or if an invoice is for a subscription, it must be <a href="#void_invoice">voided</a>.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/invoices/{options.Invoice}"
            |> RestApi.deleteAsync<DeletedInvoice> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/invoices/{options.Invoice}"
            |> RestApi.getAsync<Invoice> settings qs

        type UpdateOptions = {
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
        let Update settings (formOptions: Invoices'UpdateOptions) (options: UpdateOptions) =

            $"/v1/invoices/{options.Invoice}"
            |> RestApi.postAsync<_, Invoice> settings (Map.empty) formOptions

    module InvoicesUpcoming =

        type UpcomingOptions = {
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
        let Upcoming settings (options: UpcomingOptions) =
            let qs = [("coupon", options.Coupon |> box); ("subscription_start_date", options.SubscriptionStartDate |> box); ("subscription_proration_date", options.SubscriptionProrationDate |> box); ("subscription_proration_behavior", options.SubscriptionProrationBehavior |> box); ("subscription_items", options.SubscriptionItems |> box); ("subscription_default_tax_rates", options.SubscriptionDefaultTaxRates |> box); ("subscription_cancel_now", options.SubscriptionCancelNow |> box); ("subscription_cancel_at_period_end", options.SubscriptionCancelAtPeriodEnd |> box); ("subscription_cancel_at", options.SubscriptionCancelAt |> box); ("subscription_billing_cycle_anchor", options.SubscriptionBillingCycleAnchor |> box); ("subscription", options.Subscription |> box); ("schedule", options.Schedule |> box); ("invoice_items", options.InvoiceItems |> box); ("expand", options.Expand |> box); ("discounts", options.Discounts |> box); ("customer", options.Customer |> box); ("subscription_trial_end", options.SubscriptionTrialEnd |> box); ("subscription_trial_from_plan", options.SubscriptionTrialFromPlan |> box)] |> Map.ofList
            $"/v1/invoices/upcoming"
            |> RestApi.getAsync<Invoice> settings qs

    module InvoicesUpcomingLines =

        type UpcomingLinesOptions = {
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
        let UpcomingLines settings (options: UpcomingLinesOptions) =
            let qs = [("coupon", options.Coupon |> box); ("subscription_start_date", options.SubscriptionStartDate |> box); ("subscription_proration_date", options.SubscriptionProrationDate |> box); ("subscription_proration_behavior", options.SubscriptionProrationBehavior |> box); ("subscription_items", options.SubscriptionItems |> box); ("subscription_default_tax_rates", options.SubscriptionDefaultTaxRates |> box); ("subscription_cancel_now", options.SubscriptionCancelNow |> box); ("subscription_cancel_at_period_end", options.SubscriptionCancelAtPeriodEnd |> box); ("subscription_cancel_at", options.SubscriptionCancelAt |> box); ("subscription_trial_end", options.SubscriptionTrialEnd |> box); ("subscription_billing_cycle_anchor", options.SubscriptionBillingCycleAnchor |> box); ("starting_after", options.StartingAfter |> box); ("schedule", options.Schedule |> box); ("limit", options.Limit |> box); ("invoice_items", options.InvoiceItems |> box); ("expand", options.Expand |> box); ("ending_before", options.EndingBefore |> box); ("discounts", options.Discounts |> box); ("customer", options.Customer |> box); ("subscription", options.Subscription |> box); ("subscription_trial_from_plan", options.SubscriptionTrialFromPlan |> box)] |> Map.ofList
            $"/v1/invoices/upcoming/lines"
            |> RestApi.getAsync<LineItem list> settings qs

    module InvoicesFinalize =

        type FinalizeInvoiceOptions = {
            Invoice: string
        }
        with
            static member Create (invoice: string) =
                {
                    Invoice = invoice
                }

        ///<p>Stripe automatically finalizes drafts before sending and attempting payment on invoices. However, if you’d like to finalize a draft invoice manually, you can do so using this method.</p>
        let FinalizeInvoice settings (formOptions: InvoicesFinalize'FinalizeInvoiceOptions) (options: FinalizeInvoiceOptions) =

            $"/v1/invoices/{options.Invoice}/finalize"
            |> RestApi.postAsync<_, Invoice> settings (Map.empty) formOptions

    module InvoicesLines =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/invoices/{options.Invoice}/lines"
            |> RestApi.getAsync<LineItem list> settings qs

    module InvoicesMarkUncollectible =

        type MarkUncollectibleOptions = {
            Invoice: string
        }
        with
            static member Create (invoice: string) =
                {
                    Invoice = invoice
                }

        ///<p>Marking an invoice as uncollectible is useful for keeping track of bad debts that can be written off for accounting purposes.</p>
        let MarkUncollectible settings (formOptions: InvoicesMarkUncollectible'MarkUncollectibleOptions) (options: MarkUncollectibleOptions) =

            $"/v1/invoices/{options.Invoice}/mark_uncollectible"
            |> RestApi.postAsync<_, Invoice> settings (Map.empty) formOptions

    module InvoicesPay =

        type PayOptions = {
            Invoice: string
        }
        with
            static member Create (invoice: string) =
                {
                    Invoice = invoice
                }

        ///<p>Stripe automatically creates and then attempts to collect payment on invoices for customers on subscriptions according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to attempt payment on an invoice out of the normal collection schedule or for some other reason, you can do so.</p>
        let Pay settings (formOptions: InvoicesPay'PayOptions) (options: PayOptions) =

            $"/v1/invoices/{options.Invoice}/pay"
            |> RestApi.postAsync<_, Invoice> settings (Map.empty) formOptions

    module InvoicesSend =

        type SendInvoiceOptions = {
            Invoice: string
        }
        with
            static member Create (invoice: string) =
                {
                    Invoice = invoice
                }

        ///<p>Stripe will automatically send invoices to customers according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to manually send an invoice to your customer out of the normal schedule, you can do so. When sending invoices that have already been paid, there will be no reference to the payment in the email.
        ///Requests made in test-mode result in no emails being sent, despite sending an <code>invoice.sent</code> event.</p>
        let SendInvoice settings (formOptions: InvoicesSend'SendInvoiceOptions) (options: SendInvoiceOptions) =

            $"/v1/invoices/{options.Invoice}/send"
            |> RestApi.postAsync<_, Invoice> settings (Map.empty) formOptions

    module InvoicesVoid =

        type VoidInvoiceOptions = {
            Invoice: string
        }
        with
            static member Create (invoice: string) =
                {
                    Invoice = invoice
                }

        ///<p>Mark a finalized invoice as void. This cannot be undone. Voiding an invoice is similar to <a href="#delete_invoice">deletion</a>, however it only applies to finalized invoices and maintains a papertrail where the invoice can still be found.</p>
        let VoidInvoice settings (formOptions: InvoicesVoid'VoidInvoiceOptions) (options: VoidInvoiceOptions) =

            $"/v1/invoices/{options.Invoice}/void"
            |> RestApi.postAsync<_, Invoice> settings (Map.empty) formOptions

    module IssuerFraudRecords =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("charge", options.Charge |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/issuer_fraud_records"
            |> RestApi.getAsync<IssuerFraudRecord list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/issuer_fraud_records/{options.IssuerFraudRecord}"
            |> RestApi.getAsync<IssuerFraudRecord> settings qs

    module IssuingAuthorizations =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("card", options.Card |> box); ("cardholder", options.Cardholder |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
            $"/v1/issuing/authorizations"
            |> RestApi.getAsync<IssuingAuthorization list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/issuing/authorizations/{options.Authorization}"
            |> RestApi.getAsync<IssuingAuthorization> settings qs

        type UpdateOptions = {
            Authorization: string
        }
        with
            static member Create (authorization: string) =
                {
                    Authorization = authorization
                }

        ///<p>Updates the specified Issuing <code>Authorization</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formOptions: IssuingAuthorizations'UpdateOptions) (options: UpdateOptions) =

            $"/v1/issuing/authorizations/{options.Authorization}"
            |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) formOptions

    module IssuingAuthorizationsApprove =

        type ApproveOptions = {
            Authorization: string
        }
        with
            static member Create (authorization: string) =
                {
                    Authorization = authorization
                }

        ///<p>Approves a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real-time authorization</a> flow.</p>
        let Approve settings (formOptions: IssuingAuthorizationsApprove'ApproveOptions) (options: ApproveOptions) =

            $"/v1/issuing/authorizations/{options.Authorization}/approve"
            |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) formOptions

    module IssuingAuthorizationsDecline =

        type DeclineOptions = {
            Authorization: string
        }
        with
            static member Create (authorization: string) =
                {
                    Authorization = authorization
                }

        ///<p>Declines a pending Issuing <code>Authorization</code> object. This request should be made within the timeout window of the <a href="/docs/issuing/controls/real-time-authorizations">real time authorization</a> flow.</p>
        let Decline settings (formOptions: IssuingAuthorizationsDecline'DeclineOptions) (options: DeclineOptions) =

            $"/v1/issuing/authorizations/{options.Authorization}/decline"
            |> RestApi.postAsync<_, IssuingAuthorization> settings (Map.empty) formOptions

    module IssuingCardholders =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("email", options.Email |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("phone_number", options.PhoneNumber |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("type", options.``type`` |> box)] |> Map.ofList
            $"/v1/issuing/cardholders"
            |> RestApi.getAsync<IssuingCardholder list> settings qs

        ///<p>Creates a new Issuing <code>Cardholder</code> object that can be issued cards.</p>
        let Create settings (formOptions: IssuingCardholders'CreateOptions) =

            $"/v1/issuing/cardholders"
            |> RestApi.postAsync<_, IssuingCardholder> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/issuing/cardholders/{options.Cardholder}"
            |> RestApi.getAsync<IssuingCardholder> settings qs

        type UpdateOptions = {
            Cardholder: string
        }
        with
            static member Create (cardholder: string) =
                {
                    Cardholder = cardholder
                }

        ///<p>Updates the specified Issuing <code>Cardholder</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formOptions: IssuingCardholders'UpdateOptions) (options: UpdateOptions) =

            $"/v1/issuing/cardholders/{options.Cardholder}"
            |> RestApi.postAsync<_, IssuingCardholder> settings (Map.empty) formOptions

    module IssuingCards =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("cardholder", options.Cardholder |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("exp_month", options.ExpMonth |> box); ("exp_year", options.ExpYear |> box); ("expand", options.Expand |> box); ("last4", options.Last4 |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("type", options.``type`` |> box)] |> Map.ofList
            $"/v1/issuing/cards"
            |> RestApi.getAsync<IssuingCard list> settings qs

        ///<p>Creates an Issuing <code>Card</code> object.</p>
        let Create settings (formOptions: IssuingCards'CreateOptions) =

            $"/v1/issuing/cards"
            |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/issuing/cards/{options.Card}"
            |> RestApi.getAsync<IssuingCard> settings qs

        type UpdateOptions = {
            Card: string
        }
        with
            static member Create (card: string) =
                {
                    Card = card
                }

        ///<p>Updates the specified Issuing <code>Card</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formOptions: IssuingCards'UpdateOptions) (options: UpdateOptions) =

            $"/v1/issuing/cards/{options.Card}"
            |> RestApi.postAsync<_, IssuingCard> settings (Map.empty) formOptions

    module IssuingDisputes =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("transaction", options.Transaction |> box)] |> Map.ofList
            $"/v1/issuing/disputes"
            |> RestApi.getAsync<IssuingDispute list> settings qs

        ///<p>Creates an Issuing <code>Dispute</code> object. Individual pieces of evidence within the <code>evidence</code> object are optional at this point. Stripe only validates that required evidence is present during submission. Refer to <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a> for more details about evidence requirements.</p>
        let Create settings (formOptions: IssuingDisputes'CreateOptions) =

            $"/v1/issuing/disputes"
            |> RestApi.postAsync<_, IssuingDispute> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/issuing/disputes/{options.Dispute}"
            |> RestApi.getAsync<IssuingDispute> settings qs

        type UpdateOptions = {
            Dispute: string
        }
        with
            static member Create (dispute: string) =
                {
                    Dispute = dispute
                }

        ///<p>Updates the specified Issuing <code>Dispute</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Properties on the <code>evidence</code> object can be unset by passing in an empty string.</p>
        let Update settings (formOptions: IssuingDisputes'UpdateOptions) (options: UpdateOptions) =

            $"/v1/issuing/disputes/{options.Dispute}"
            |> RestApi.postAsync<_, IssuingDispute> settings (Map.empty) formOptions

    module IssuingDisputesSubmit =

        type SubmitOptions = {
            Dispute: string
        }
        with
            static member Create (dispute: string) =
                {
                    Dispute = dispute
                }

        ///<p>Submits an Issuing <code>Dispute</code> to the card network. Stripe validates that all evidence fields required for the dispute’s reason are present. For more details, see <a href="/docs/issuing/purchases/disputes#dispute-reasons-and-evidence">Dispute reasons and evidence</a>.</p>
        let Submit settings (formOptions: IssuingDisputesSubmit'SubmitOptions) (options: SubmitOptions) =

            $"/v1/issuing/disputes/{options.Dispute}/submit"
            |> RestApi.postAsync<_, IssuingDispute> settings (Map.empty) formOptions

    module IssuingTransactions =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("card", options.Card |> box); ("cardholder", options.Cardholder |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/issuing/transactions"
            |> RestApi.getAsync<IssuingTransaction list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/issuing/transactions/{options.Transaction}"
            |> RestApi.getAsync<IssuingTransaction> settings qs

        type UpdateOptions = {
            Transaction: string
        }
        with
            static member Create (transaction: string) =
                {
                    Transaction = transaction
                }

        ///<p>Updates the specified Issuing <code>Transaction</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formOptions: IssuingTransactions'UpdateOptions) (options: UpdateOptions) =

            $"/v1/issuing/transactions/{options.Transaction}"
            |> RestApi.postAsync<_, IssuingTransaction> settings (Map.empty) formOptions

    module Mandates =

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/mandates/{options.Mandate}"
            |> RestApi.getAsync<Mandate> settings qs

    module OrderReturns =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("order", options.Order |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/order_returns"
            |> RestApi.getAsync<OrderReturn list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/order_returns/{options.Id}"
            |> RestApi.getAsync<OrderReturn> settings qs

    module Orders =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("ids", options.Ids |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("status_transitions", options.StatusTransitions |> box); ("upstream_ids", options.UpstreamIds |> box)] |> Map.ofList
            $"/v1/orders"
            |> RestApi.getAsync<Order list> settings qs

        ///<p>Creates a new order object.</p>
        let Create settings (formOptions: Orders'CreateOptions) =

            $"/v1/orders"
            |> RestApi.postAsync<_, Order> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/orders/{options.Id}"
            |> RestApi.getAsync<Order> settings qs

        type UpdateOptions = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Updates the specific order by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formOptions: Orders'UpdateOptions) (options: UpdateOptions) =

            $"/v1/orders/{options.Id}"
            |> RestApi.postAsync<_, Order> settings (Map.empty) formOptions

    module OrdersPay =

        type PayOptions = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Pay an order by providing a <code>source</code> to create a payment.</p>
        let Pay settings (formOptions: OrdersPay'PayOptions) (options: PayOptions) =

            $"/v1/orders/{options.Id}/pay"
            |> RestApi.postAsync<_, Order> settings (Map.empty) formOptions

    module OrdersReturns =

        type ReturnOrderOptions = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Return all or part of an order. The order must have a status of <code>paid</code> or <code>fulfilled</code> before it can be returned. Once all items have been returned, the order will become <code>canceled</code> or <code>returned</code> depending on which status the order started in.</p>
        let ReturnOrder settings (formOptions: OrdersReturns'ReturnOrderOptions) (options: ReturnOrderOptions) =

            $"/v1/orders/{options.Id}/returns"
            |> RestApi.postAsync<_, OrderReturn> settings (Map.empty) formOptions

    module PaymentIntents =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/payment_intents"
            |> RestApi.getAsync<PaymentIntent list> settings qs

        ///<p>Creates a PaymentIntent object.
        ///After the PaymentIntent is created, attach a payment method and <a href="/docs/api/payment_intents/confirm">confirm</a>
        ///to continue the payment. You can read more about the different payment flows
        ///available via the Payment Intents API <a href="/docs/payments/payment-intents">here</a>.
        ///When <code>confirm=true</code> is used during creation, it is equivalent to creating
        ///and confirming the PaymentIntent in the same call. You may use any parameters
        ///available in the <a href="/docs/api/payment_intents/confirm">confirm API</a> when <code>confirm=true</code>
        ///is supplied.</p>
        let Create settings (formOptions: PaymentIntents'CreateOptions) =

            $"/v1/payment_intents"
            |> RestApi.postAsync<_, PaymentIntent> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("client_secret", options.ClientSecret |> box); ("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/payment_intents/{options.Intent}"
            |> RestApi.getAsync<PaymentIntent> settings qs

        type UpdateOptions = {
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
        let Update settings (formOptions: PaymentIntents'UpdateOptions) (options: UpdateOptions) =

            $"/v1/payment_intents/{options.Intent}"
            |> RestApi.postAsync<_, PaymentIntent> settings (Map.empty) formOptions

    module PaymentIntentsCancel =

        type CancelOptions = {
            Intent: string
        }
        with
            static member Create (intent: string) =
                {
                    Intent = intent
                }

        ///<p>A PaymentIntent object can be canceled when it is in one of these statuses: <code>requires_payment_method</code>, <code>requires_capture</code>, <code>requires_confirmation</code>, or <code>requires_action</code>. 
        ///Once canceled, no additional charges will be made by the PaymentIntent and any operations on the PaymentIntent will fail with an error. For PaymentIntents with <code>status=’requires_capture’</code>, the remaining <code>amount_capturable</code> will automatically be refunded.</p>
        let Cancel settings (formOptions: PaymentIntentsCancel'CancelOptions) (options: CancelOptions) =

            $"/v1/payment_intents/{options.Intent}/cancel"
            |> RestApi.postAsync<_, PaymentIntent> settings (Map.empty) formOptions

    module PaymentIntentsCapture =

        type CaptureOptions = {
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
        let Capture settings (formOptions: PaymentIntentsCapture'CaptureOptions) (options: CaptureOptions) =

            $"/v1/payment_intents/{options.Intent}/capture"
            |> RestApi.postAsync<_, PaymentIntent> settings (Map.empty) formOptions

    module PaymentIntentsConfirm =

        type ConfirmOptions = {
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
        let Confirm settings (formOptions: PaymentIntentsConfirm'ConfirmOptions) (options: ConfirmOptions) =

            $"/v1/payment_intents/{options.Intent}/confirm"
            |> RestApi.postAsync<_, PaymentIntent> settings (Map.empty) formOptions

    module PaymentMethods =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("customer", options.Customer |> box); ("type", options.``type`` |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/payment_methods"
            |> RestApi.getAsync<PaymentMethod list> settings qs

        ///<p>Creates a PaymentMethod object. Read the <a href="/docs/stripe-js/reference#stripe-create-payment-method">Stripe.js reference</a> to learn how to create PaymentMethods via Stripe.js.</p>
        let Create settings (formOptions: PaymentMethods'CreateOptions) =

            $"/v1/payment_methods"
            |> RestApi.postAsync<_, PaymentMethod> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/payment_methods/{options.PaymentMethod}"
            |> RestApi.getAsync<PaymentMethod> settings qs

        type UpdateOptions = {
            PaymentMethod: string
        }
        with
            static member Create (paymentMethod: string) =
                {
                    PaymentMethod = paymentMethod
                }

        ///<p>Updates a PaymentMethod object. A PaymentMethod must be attached a customer to be updated.</p>
        let Update settings (formOptions: PaymentMethods'UpdateOptions) (options: UpdateOptions) =

            $"/v1/payment_methods/{options.PaymentMethod}"
            |> RestApi.postAsync<_, PaymentMethod> settings (Map.empty) formOptions

    module PaymentMethodsAttach =

        type AttachOptions = {
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
        let Attach settings (formOptions: PaymentMethodsAttach'AttachOptions) (options: AttachOptions) =

            $"/v1/payment_methods/{options.PaymentMethod}/attach"
            |> RestApi.postAsync<_, PaymentMethod> settings (Map.empty) formOptions

    module PaymentMethodsDetach =

        type DetachOptions = {
            PaymentMethod: string
        }
        with
            static member Create (paymentMethod: string) =
                {
                    PaymentMethod = paymentMethod
                }

        ///<p>Detaches a PaymentMethod object from a Customer.</p>
        let Detach settings (formOptions: PaymentMethodsDetach'DetachOptions) (options: DetachOptions) =

            $"/v1/payment_methods/{options.PaymentMethod}/detach"
            |> RestApi.postAsync<_, PaymentMethod> settings (Map.empty) formOptions

    module Payouts =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("arrival_date", options.ArrivalDate |> box); ("created", options.Created |> box); ("destination", options.Destination |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
            $"/v1/payouts"
            |> RestApi.getAsync<Payout list> settings qs

        ///<p>To send funds to your own bank account, you create a new payout object. Your <a href="#balance">Stripe balance</a> must be able to cover the payout amount, or you’ll receive an “Insufficient Funds” error.
        ///If your API key is in test mode, money won’t actually be sent, though everything else will occur as if in live mode.
        ///If you are creating a manual payout on a Stripe account that uses multiple payment source types, you’ll need to specify the source type balance that the payout should draw from. The <a href="#balance_object">balance object</a> details available and pending amounts by source type.</p>
        let Create settings (formOptions: Payouts'CreateOptions) =

            $"/v1/payouts"
            |> RestApi.postAsync<_, Payout> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/payouts/{options.Payout}"
            |> RestApi.getAsync<Payout> settings qs

        type UpdateOptions = {
            Payout: string
        }
        with
            static member Create (payout: string) =
                {
                    Payout = payout
                }

        ///<p>Updates the specified payout by setting the values of the parameters passed. Any parameters not provided will be left unchanged. This request accepts only the metadata as arguments.</p>
        let Update settings (formOptions: Payouts'UpdateOptions) (options: UpdateOptions) =

            $"/v1/payouts/{options.Payout}"
            |> RestApi.postAsync<_, Payout> settings (Map.empty) formOptions

    module PayoutsCancel =

        type CancelOptions = {
            Payout: string
        }
        with
            static member Create (payout: string) =
                {
                    Payout = payout
                }

        ///<p>A previously created payout can be canceled if it has not yet been paid out. Funds will be refunded to your available balance. You may not cancel automatic Stripe payouts.</p>
        let Cancel settings (formOptions: PayoutsCancel'CancelOptions) (options: CancelOptions) =

            $"/v1/payouts/{options.Payout}/cancel"
            |> RestApi.postAsync<_, Payout> settings (Map.empty) formOptions

    module PayoutsReverse =

        type ReverseOptions = {
            Payout: string
        }
        with
            static member Create (payout: string) =
                {
                    Payout = payout
                }

        ///<p>Reverses a payout by debiting the destination bank account. Only payouts for connected accounts to US bank accounts may be reversed at this time. If the payout is in the <code>pending</code> status, <code>/v1/payouts/:id/cancel</code> should be used instead.
        ///By requesting a reversal via <code>/v1/payouts/:id/reverse</code>, you confirm that the authorized signatory of the selected bank account has authorized the debit on the bank account and that no other authorization is required.</p>
        let Reverse settings (formOptions: PayoutsReverse'ReverseOptions) (options: ReverseOptions) =

            $"/v1/payouts/{options.Payout}/reverse"
            |> RestApi.postAsync<_, Payout> settings (Map.empty) formOptions

    module Plans =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("product", options.Product |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/plans"
            |> RestApi.getAsync<Plan list> settings qs

        ///<p>You can now model subscriptions more flexibly using the <a href="#prices">Prices API</a>. It replaces the Plans API and is backwards compatible to simplify your migration.</p>
        let Create settings (formOptions: Plans'CreateOptions) =

            $"/v1/plans"
            |> RestApi.postAsync<_, Plan> settings (Map.empty) formOptions

        type DeleteOptions = {
            Plan: string
        }
        with
            static member Create (plan: string) =
                {
                    Plan = plan
                }

        ///<p>Deleting plans means new subscribers can’t be added. Existing subscribers aren’t affected.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/plans/{options.Plan}"
            |> RestApi.deleteAsync<DeletedPlan> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/plans/{options.Plan}"
            |> RestApi.getAsync<Plan> settings qs

        type UpdateOptions = {
            Plan: string
        }
        with
            static member Create (plan: string) =
                {
                    Plan = plan
                }

        ///<p>Updates the specified plan by setting the values of the parameters passed. Any parameters not provided are left unchanged. By design, you cannot change a plan’s ID, amount, currency, or billing cycle.</p>
        let Update settings (formOptions: Plans'UpdateOptions) (options: UpdateOptions) =

            $"/v1/plans/{options.Plan}"
            |> RestApi.postAsync<_, Plan> settings (Map.empty) formOptions

    module Prices =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("currency", options.Currency |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("lookup_keys", options.LookupKeys |> box); ("product", options.Product |> box); ("recurring", options.Recurring |> box); ("starting_after", options.StartingAfter |> box); ("type", options.``type`` |> box)] |> Map.ofList
            $"/v1/prices"
            |> RestApi.getAsync<Price list> settings qs

        ///<p>Creates a new price for an existing product. The price can be recurring or one-time.</p>
        let Create settings (formOptions: Prices'CreateOptions) =

            $"/v1/prices"
            |> RestApi.postAsync<_, Price> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/prices/{options.Price}"
            |> RestApi.getAsync<Price> settings qs

        type UpdateOptions = {
            Price: string
        }
        with
            static member Create (price: string) =
                {
                    Price = price
                }

        ///<p>Updates the specified price by setting the values of the parameters passed. Any parameters not provided are left unchanged.</p>
        let Update settings (formOptions: Prices'UpdateOptions) (options: UpdateOptions) =

            $"/v1/prices/{options.Price}"
            |> RestApi.postAsync<_, Price> settings (Map.empty) formOptions

    module Products =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("ids", options.Ids |> box); ("limit", options.Limit |> box); ("shippable", options.Shippable |> box); ("starting_after", options.StartingAfter |> box); ("type", options.``type`` |> box); ("url", options.Url |> box)] |> Map.ofList
            $"/v1/products"
            |> RestApi.getAsync<Product list> settings qs

        ///<p>Creates a new product object.</p>
        let Create settings (formOptions: Products'CreateOptions) =

            $"/v1/products"
            |> RestApi.postAsync<_, Product> settings (Map.empty) formOptions

        type DeleteOptions = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Delete a product. Deleting a product is only possible if it has no prices associated with it. Additionally, deleting a product with <code>type=good</code> is only possible if it has no SKUs associated with it.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/products/{options.Id}"
            |> RestApi.deleteAsync<DeletedProduct> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/products/{options.Id}"
            |> RestApi.getAsync<Product> settings qs

        type UpdateOptions = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Updates the specific product by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formOptions: Products'UpdateOptions) (options: UpdateOptions) =

            $"/v1/products/{options.Id}"
            |> RestApi.postAsync<_, Product> settings (Map.empty) formOptions

    module PromotionCodes =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("active", options.Active |> box); ("code", options.Code |> box); ("coupon", options.Coupon |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/promotion_codes"
            |> RestApi.getAsync<PromotionCode list> settings qs

        ///<p>A promotion code points to a coupon. You can optionally restrict the code to a specific customer, redemption limit, and expiration date.</p>
        let Create settings (formOptions: PromotionCodes'CreateOptions) =

            $"/v1/promotion_codes"
            |> RestApi.postAsync<_, PromotionCode> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/promotion_codes/{options.PromotionCode}"
            |> RestApi.getAsync<PromotionCode> settings qs

        type UpdateOptions = {
            PromotionCode: string
        }
        with
            static member Create (promotionCode: string) =
                {
                    PromotionCode = promotionCode
                }

        ///<p>Updates the specified promotion code by setting the values of the parameters passed. Most fields are, by design, not editable.</p>
        let Update settings (formOptions: PromotionCodes'UpdateOptions) (options: UpdateOptions) =

            $"/v1/promotion_codes/{options.PromotionCode}"
            |> RestApi.postAsync<_, PromotionCode> settings (Map.empty) formOptions

    module RadarEarlyFraudWarnings =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("charge", options.Charge |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/radar/early_fraud_warnings"
            |> RestApi.getAsync<RadarEarlyFraudWarning list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/radar/early_fraud_warnings/{options.EarlyFraudWarning}"
            |> RestApi.getAsync<RadarEarlyFraudWarning> settings qs

    module RadarValueListItems =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("value_list", options.ValueList |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("value", options.Value |> box)] |> Map.ofList
            $"/v1/radar/value_list_items"
            |> RestApi.getAsync<RadarValueListItem list> settings qs

        ///<p>Creates a new <code>ValueListItem</code> object, which is added to the specified parent value list.</p>
        let Create settings (formOptions: RadarValueListItems'CreateOptions) =

            $"/v1/radar/value_list_items"
            |> RestApi.postAsync<_, RadarValueListItem> settings (Map.empty) formOptions

        type DeleteOptions = {
            Item: string
        }
        with
            static member Create (item: string) =
                {
                    Item = item
                }

        ///<p>Deletes a <code>ValueListItem</code> object, removing it from its parent value list.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/radar/value_list_items/{options.Item}"
            |> RestApi.deleteAsync<DeletedRadarValueListItem> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/radar/value_list_items/{options.Item}"
            |> RestApi.getAsync<RadarValueListItem> settings qs

    module RadarValueLists =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("alias", options.Alias |> box); ("contains", options.Contains |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/radar/value_lists"
            |> RestApi.getAsync<RadarValueList list> settings qs

        ///<p>Creates a new <code>ValueList</code> object, which can then be referenced in rules.</p>
        let Create settings (formOptions: RadarValueLists'CreateOptions) =

            $"/v1/radar/value_lists"
            |> RestApi.postAsync<_, RadarValueList> settings (Map.empty) formOptions

        type DeleteOptions = {
            ValueList: string
        }
        with
            static member Create (valueList: string) =
                {
                    ValueList = valueList
                }

        ///<p>Deletes a <code>ValueList</code> object, also deleting any items contained within the value list. To be deleted, a value list must not be referenced in any rules.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/radar/value_lists/{options.ValueList}"
            |> RestApi.deleteAsync<DeletedRadarValueList> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/radar/value_lists/{options.ValueList}"
            |> RestApi.getAsync<RadarValueList> settings qs

        type UpdateOptions = {
            ValueList: string
        }
        with
            static member Create (valueList: string) =
                {
                    ValueList = valueList
                }

        ///<p>Updates a <code>ValueList</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Note that <code>item_type</code> is immutable.</p>
        let Update settings (formOptions: RadarValueLists'UpdateOptions) (options: UpdateOptions) =

            $"/v1/radar/value_lists/{options.ValueList}"
            |> RestApi.postAsync<_, RadarValueList> settings (Map.empty) formOptions

    module Recipients =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("type", options.``type`` |> box); ("verified", options.Verified |> box)] |> Map.ofList
            $"/v1/recipients"
            |> RestApi.getAsync<Recipient list> settings qs

        ///<p>Creates a new <code>Recipient</code> object and verifies the recipient’s identity.
        ///Also verifies the recipient’s bank account information or debit card, if either is provided.</p>
        let Create settings (formOptions: Recipients'CreateOptions) =

            $"/v1/recipients"
            |> RestApi.postAsync<_, Recipient> settings (Map.empty) formOptions

        type DeleteOptions = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Permanently deletes a recipient. It cannot be undone.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/recipients/{options.Id}"
            |> RestApi.deleteAsync<DeletedRecipient> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/recipients/{options.Id}"
            |> RestApi.getAsync<Recipient> settings qs

        type UpdateOptions = {
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
        let Update settings (formOptions: Recipients'UpdateOptions) (options: UpdateOptions) =

            $"/v1/recipients/{options.Id}"
            |> RestApi.postAsync<_, Recipient> settings (Map.empty) formOptions

    module Refunds =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("charge", options.Charge |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/refunds"
            |> RestApi.getAsync<Refund list> settings qs

        ///<p>Create a refund.</p>
        let Create settings (formOptions: Refunds'CreateOptions) =

            $"/v1/refunds"
            |> RestApi.postAsync<_, Refund> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/refunds/{options.Refund}"
            |> RestApi.getAsync<Refund> settings qs

        type UpdateOptions = {
            Refund: string
        }
        with
            static member Create (refund: string) =
                {
                    Refund = refund
                }

        ///<p>Updates the specified refund by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request only accepts <code>metadata</code> as an argument.</p>
        let Update settings (formOptions: Refunds'UpdateOptions) (options: UpdateOptions) =

            $"/v1/refunds/{options.Refund}"
            |> RestApi.postAsync<_, Refund> settings (Map.empty) formOptions

    module ReportingReportRuns =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/reporting/report_runs"
            |> RestApi.getAsync<ReportingReportRun list> settings qs

        ///<p>Creates a new object and begin running the report. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        let Create settings (formOptions: ReportingReportRuns'CreateOptions) =

            $"/v1/reporting/report_runs"
            |> RestApi.postAsync<_, ReportingReportRun> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/reporting/report_runs/{options.ReportRun}"
            |> RestApi.getAsync<ReportingReportRun> settings qs

    module ReportingReportTypes =

        type ListOptions = {
            Expand: string list option
        }
        with
            static member Create (?expand: string list) =
                {
                    Expand = expand
                }

        ///<p>Returns a full list of Report Types. (Requires a <a href="https://stripe.com/docs/keys#test-live-modes">live-mode API key</a>.)</p>
        let List settings (options: ListOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/reporting/report_types"
            |> RestApi.getAsync<ReportingReportType list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/reporting/report_types/{options.ReportType}"
            |> RestApi.getAsync<ReportingReportType> settings qs

    module Reviews =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/reviews"
            |> RestApi.getAsync<Review list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/reviews/{options.Review}"
            |> RestApi.getAsync<Review> settings qs

    module ReviewsApprove =

        type ApproveOptions = {
            Review: string
        }
        with
            static member Create (review: string) =
                {
                    Review = review
                }

        ///<p>Approves a <code>Review</code> object, closing it and removing it from the list of reviews.</p>
        let Approve settings (formOptions: ReviewsApprove'ApproveOptions) (options: ApproveOptions) =

            $"/v1/reviews/{options.Review}/approve"
            |> RestApi.postAsync<_, Review> settings (Map.empty) formOptions

    module SetupAttempts =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("setup_intent", options.SetupIntent |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/setup_attempts"
            |> RestApi.getAsync<SetupAttempt list> settings qs

    module SetupIntents =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_method", options.PaymentMethod |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/setup_intents"
            |> RestApi.getAsync<SetupIntent list> settings qs

        ///<p>Creates a SetupIntent object.
        ///After the SetupIntent is created, attach a payment method and <a href="/docs/api/setup_intents/confirm">confirm</a>
        ///to collect any required permissions to charge the payment method later.</p>
        let Create settings (formOptions: SetupIntents'CreateOptions) =

            $"/v1/setup_intents"
            |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("client_secret", options.ClientSecret |> box); ("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/setup_intents/{options.Intent}"
            |> RestApi.getAsync<SetupIntent> settings qs

        type UpdateOptions = {
            Intent: string
        }
        with
            static member Create (intent: string) =
                {
                    Intent = intent
                }

        ///<p>Updates a SetupIntent object.</p>
        let Update settings (formOptions: SetupIntents'UpdateOptions) (options: UpdateOptions) =

            $"/v1/setup_intents/{options.Intent}"
            |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) formOptions

    module SetupIntentsCancel =

        type CancelOptions = {
            Intent: string
        }
        with
            static member Create (intent: string) =
                {
                    Intent = intent
                }

        ///<p>A SetupIntent object can be canceled when it is in one of these statuses: <code>requires_payment_method</code>, <code>requires_confirmation</code>, or <code>requires_action</code>. 
        ///Once canceled, setup is abandoned and any operations on the SetupIntent will fail with an error.</p>
        let Cancel settings (formOptions: SetupIntentsCancel'CancelOptions) (options: CancelOptions) =

            $"/v1/setup_intents/{options.Intent}/cancel"
            |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) formOptions

    module SetupIntentsConfirm =

        type ConfirmOptions = {
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
        let Confirm settings (formOptions: SetupIntentsConfirm'ConfirmOptions) (options: ConfirmOptions) =

            $"/v1/setup_intents/{options.Intent}/confirm"
            |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) formOptions

    module SigmaScheduledQueryRuns =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/sigma/scheduled_query_runs"
            |> RestApi.getAsync<ScheduledQueryRun list> settings qs

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/sigma/scheduled_query_runs/{options.ScheduledQueryRun}"
            |> RestApi.getAsync<ScheduledQueryRun> settings qs

    module Skus =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("active", options.Active |> box); ("attributes", options.Attributes |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("ids", options.Ids |> box); ("in_stock", options.InStock |> box); ("limit", options.Limit |> box); ("product", options.Product |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/skus"
            |> RestApi.getAsync<Sku list> settings qs

        ///<p>Creates a new SKU associated with a product.</p>
        let Create settings (formOptions: Skus'CreateOptions) =

            $"/v1/skus"
            |> RestApi.postAsync<_, Sku> settings (Map.empty) formOptions

        type DeleteOptions = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Delete a SKU. Deleting a SKU is only possible until it has been used in an order.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/skus/{options.Id}"
            |> RestApi.deleteAsync<DeletedSku> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/skus/{options.Id}"
            |> RestApi.getAsync<Sku> settings qs

        type UpdateOptions = {
            Id: string
        }
        with
            static member Create (id: string) =
                {
                    Id = id
                }

        ///<p>Updates the specific SKU by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///Note that a SKU’s <code>attributes</code> are not editable. Instead, you would need to deactivate the existing SKU and create a new one with the new attribute values.</p>
        let Update settings (formOptions: Skus'UpdateOptions) (options: UpdateOptions) =

            $"/v1/skus/{options.Id}"
            |> RestApi.postAsync<_, Sku> settings (Map.empty) formOptions

    module Sources =

        ///<p>Creates a new source object.</p>
        let Create settings (formOptions: Sources'CreateOptions) =

            $"/v1/sources"
            |> RestApi.postAsync<_, Source> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("client_secret", options.ClientSecret |> box); ("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/sources/{options.Source}"
            |> RestApi.getAsync<Source> settings qs

        type UpdateOptions = {
            Source: string
        }
        with
            static member Create (source: string) =
                {
                    Source = source
                }

        ///<p>Updates the specified source by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request accepts the <code>metadata</code> and <code>owner</code> as arguments. It is also possible to update type specific information for selected payment methods. Please refer to our <a href="/docs/sources">payment method guides</a> for more detail.</p>
        let Update settings (formOptions: Sources'UpdateOptions) (options: UpdateOptions) =

            $"/v1/sources/{options.Source}"
            |> RestApi.postAsync<_, Source> settings (Map.empty) formOptions

    module SourcesSourceTransactions =

        type SourceTransactionsOptions = {
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
        let SourceTransactions settings (options: SourceTransactionsOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/sources/{options.Source}/source_transactions"
            |> RestApi.getAsync<SourceTransaction list> settings qs

    module SourcesVerify =

        type VerifyOptions = {
            Source: string
        }
        with
            static member Create (source: string) =
                {
                    Source = source
                }

        ///<p>Verify a given source.</p>
        let Verify settings (formOptions: SourcesVerify'VerifyOptions) (options: VerifyOptions) =

            $"/v1/sources/{options.Source}/verify"
            |> RestApi.postAsync<_, Source> settings (Map.empty) formOptions

    module SubscriptionItems =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("subscription", options.Subscription |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/subscription_items"
            |> RestApi.getAsync<SubscriptionItem list> settings qs

        ///<p>Adds a new item to an existing subscription. No existing items will be changed or replaced.</p>
        let Create settings (formOptions: SubscriptionItems'CreateOptions) =

            $"/v1/subscription_items"
            |> RestApi.postAsync<_, SubscriptionItem> settings (Map.empty) formOptions

        type DeleteOptions = {
            Item: string
        }
        with
            static member Create (item: string) =
                {
                    Item = item
                }

        ///<p>Deletes an item from the subscription. Removing a subscription item from a subscription will not cancel the subscription.</p>
        let Delete settings (formOptions: SubscriptionItems'DeleteOptions) (options: DeleteOptions) =

            $"/v1/subscription_items/{options.Item}"
            |> RestApi.deleteAsync<DeletedSubscriptionItem> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/subscription_items/{options.Item}"
            |> RestApi.getAsync<SubscriptionItem> settings qs

        type UpdateOptions = {
            Item: string
        }
        with
            static member Create (item: string) =
                {
                    Item = item
                }

        ///<p>Updates the plan or quantity of an item on a current subscription.</p>
        let Update settings (formOptions: SubscriptionItems'UpdateOptions) (options: UpdateOptions) =

            $"/v1/subscription_items/{options.Item}"
            |> RestApi.postAsync<_, SubscriptionItem> settings (Map.empty) formOptions

    module SubscriptionItemsUsageRecordSummaries =

        type UsageRecordSummariesOptions = {
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
        let UsageRecordSummaries settings (options: UsageRecordSummariesOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/subscription_items/{options.SubscriptionItem}/usage_record_summaries"
            |> RestApi.getAsync<UsageRecordSummary list> settings qs

    module SubscriptionItemsUsageRecords =

        type CreateOptions = {
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
        let Create settings (formOptions: SubscriptionItemsUsageRecords'CreateOptions) (options: CreateOptions) =

            $"/v1/subscription_items/{options.SubscriptionItem}/usage_records"
            |> RestApi.postAsync<_, UsageRecord> settings (Map.empty) formOptions

    module SubscriptionSchedules =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("canceled_at", options.CanceledAt |> box); ("completed_at", options.CompletedAt |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("released_at", options.ReleasedAt |> box); ("scheduled", options.Scheduled |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/subscription_schedules"
            |> RestApi.getAsync<SubscriptionSchedule list> settings qs

        ///<p>Creates a new subscription schedule object. Each customer can have up to 500 active or scheduled subscriptions.</p>
        let Create settings (formOptions: SubscriptionSchedules'CreateOptions) =

            $"/v1/subscription_schedules"
            |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/subscription_schedules/{options.Schedule}"
            |> RestApi.getAsync<SubscriptionSchedule> settings qs

        type UpdateOptions = {
            Schedule: string
        }
        with
            static member Create (schedule: string) =
                {
                    Schedule = schedule
                }

        ///<p>Updates an existing subscription schedule.</p>
        let Update settings (formOptions: SubscriptionSchedules'UpdateOptions) (options: UpdateOptions) =

            $"/v1/subscription_schedules/{options.Schedule}"
            |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) formOptions

    module SubscriptionSchedulesCancel =

        type CancelOptions = {
            Schedule: string
        }
        with
            static member Create (schedule: string) =
                {
                    Schedule = schedule
                }

        ///<p>Cancels a subscription schedule and its associated subscription immediately (if the subscription schedule has an active subscription). A subscription schedule can only be canceled if its status is <code>not_started</code> or <code>active</code>.</p>
        let Cancel settings (formOptions: SubscriptionSchedulesCancel'CancelOptions) (options: CancelOptions) =

            $"/v1/subscription_schedules/{options.Schedule}/cancel"
            |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) formOptions

    module SubscriptionSchedulesRelease =

        type ReleaseOptions = {
            Schedule: string
        }
        with
            static member Create (schedule: string) =
                {
                    Schedule = schedule
                }

        ///<p>Releases the subscription schedule immediately, which will stop scheduling of its phases, but leave any existing subscription in place. A schedule can only be released if its status is <code>not_started</code> or <code>active</code>. If the subscription schedule is currently associated with a subscription, releasing it will remove its <code>subscription</code> property and set the subscription’s ID to the <code>released_subscription</code> property.</p>
        let Release settings (formOptions: SubscriptionSchedulesRelease'ReleaseOptions) (options: ReleaseOptions) =

            $"/v1/subscription_schedules/{options.Schedule}/release"
            |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) formOptions

    module Subscriptions =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("collection_method", options.CollectionMethod |> box); ("created", options.Created |> box); ("current_period_end", options.CurrentPeriodEnd |> box); ("current_period_start", options.CurrentPeriodStart |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("plan", options.Plan |> box); ("price", options.Price |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
            $"/v1/subscriptions"
            |> RestApi.getAsync<Subscription list> settings qs

        ///<p>Creates a new subscription on an existing customer. Each customer can have up to 500 active or scheduled subscriptions.</p>
        let Create settings (formOptions: Subscriptions'CreateOptions) =

            $"/v1/subscriptions"
            |> RestApi.postAsync<_, Subscription> settings (Map.empty) formOptions

        type CancelOptions = {
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
        let Cancel settings (formOptions: Subscriptions'CancelOptions) (options: CancelOptions) =

            $"/v1/subscriptions/{options.SubscriptionExposedId}"
            |> RestApi.deleteAsync<Subscription> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/subscriptions/{options.SubscriptionExposedId}"
            |> RestApi.getAsync<Subscription> settings qs

        type UpdateOptions = {
            SubscriptionExposedId: string
        }
        with
            static member Create (subscriptionExposedId: string) =
                {
                    SubscriptionExposedId = subscriptionExposedId
                }

        ///<p>Updates an existing subscription on a customer to match the specified parameters. When changing plans or quantities, we will optionally prorate the price we charge next month to make up for any price changes. To preview how the proration will be calculated, use the <a href="#upcoming_invoice">upcoming invoice</a> endpoint.</p>
        let Update settings (formOptions: Subscriptions'UpdateOptions) (options: UpdateOptions) =

            $"/v1/subscriptions/{options.SubscriptionExposedId}"
            |> RestApi.postAsync<_, Subscription> settings (Map.empty) formOptions

    module SubscriptionsDiscount =

        type DeleteDiscountOptions = {
            SubscriptionExposedId: string
        }
        with
            static member Create (subscriptionExposedId: string) =
                {
                    SubscriptionExposedId = subscriptionExposedId
                }

        ///<p>Removes the currently applied discount on a subscription.</p>
        let DeleteDiscount settings (options: DeleteDiscountOptions) =

            $"/v1/subscriptions/{options.SubscriptionExposedId}/discount"
            |> RestApi.deleteAsync<DeletedDiscount> settings (Map.empty)

    module TaxRates =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("inclusive", options.Inclusive |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/tax_rates"
            |> RestApi.getAsync<TaxRate list> settings qs

        ///<p>Creates a new tax rate.</p>
        let Create settings (formOptions: TaxRates'CreateOptions) =

            $"/v1/tax_rates"
            |> RestApi.postAsync<_, TaxRate> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/tax_rates/{options.TaxRate}"
            |> RestApi.getAsync<TaxRate> settings qs

        type UpdateOptions = {
            TaxRate: string
        }
        with
            static member Create (taxRate: string) =
                {
                    TaxRate = taxRate
                }

        ///<p>Updates an existing tax rate.</p>
        let Update settings (formOptions: TaxRates'UpdateOptions) (options: UpdateOptions) =

            $"/v1/tax_rates/{options.TaxRate}"
            |> RestApi.postAsync<_, TaxRate> settings (Map.empty) formOptions

    module TerminalConnectionTokens =

        ///<p>To connect to a reader the Stripe Terminal SDK needs to retrieve a short-lived connection token from Stripe, proxied through your server. On your backend, add an endpoint that creates and returns a connection token.</p>
        let Create settings (formOptions: TerminalConnectionTokens'CreateOptions) =

            $"/v1/terminal/connection_tokens"
            |> RestApi.postAsync<_, TerminalConnectionToken> settings (Map.empty) formOptions

    module TerminalLocations =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/terminal/locations"
            |> RestApi.getAsync<TerminalLocation list> settings qs

        ///<p>Creates a new <code>Location</code> object.</p>
        let Create settings (formOptions: TerminalLocations'CreateOptions) =

            $"/v1/terminal/locations"
            |> RestApi.postAsync<_, TerminalLocation> settings (Map.empty) formOptions

        type DeleteOptions = {
            Location: string
        }
        with
            static member Create (location: string) =
                {
                    Location = location
                }

        ///<p>Deletes a <code>Location</code> object.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/terminal/locations/{options.Location}"
            |> RestApi.deleteAsync<DeletedTerminalLocation> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/terminal/locations/{options.Location}"
            |> RestApi.getAsync<TerminalLocation> settings qs

        type UpdateOptions = {
            Location: string
        }
        with
            static member Create (location: string) =
                {
                    Location = location
                }

        ///<p>Updates a <code>Location</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formOptions: TerminalLocations'UpdateOptions) (options: UpdateOptions) =

            $"/v1/terminal/locations/{options.Location}"
            |> RestApi.postAsync<_, TerminalLocation> settings (Map.empty) formOptions

    module TerminalReaders =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("device_type", options.DeviceType |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("location", options.Location |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
            $"/v1/terminal/readers"
            |> RestApi.getAsync<TerminalReader list> settings qs

        ///<p>Creates a new <code>Reader</code> object.</p>
        let Create settings (formOptions: TerminalReaders'CreateOptions) =

            $"/v1/terminal/readers"
            |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) formOptions

        type DeleteOptions = {
            Reader: string
        }
        with
            static member Create (reader: string) =
                {
                    Reader = reader
                }

        ///<p>Deletes a <code>Reader</code> object.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/terminal/readers/{options.Reader}"
            |> RestApi.deleteAsync<DeletedTerminalReader> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/terminal/readers/{options.Reader}"
            |> RestApi.getAsync<TerminalReader> settings qs

        type UpdateOptions = {
            Reader: string
        }
        with
            static member Create (reader: string) =
                {
                    Reader = reader
                }

        ///<p>Updates a <code>Reader</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
        let Update settings (formOptions: TerminalReaders'UpdateOptions) (options: UpdateOptions) =

            $"/v1/terminal/readers/{options.Reader}"
            |> RestApi.postAsync<_, TerminalReader> settings (Map.empty) formOptions

    module Tokens =

        ///<p>Creates a single-use token that represents a bank account’s details.
        ///This token can be used with any API method in place of a bank account dictionary. This token can be used only once, by attaching it to a <a href="#accounts">Custom account</a>.</p>
        let Create settings (formOptions: Tokens'CreateOptions) =

            $"/v1/tokens"
            |> RestApi.postAsync<_, Token> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/tokens/{options.Token}"
            |> RestApi.getAsync<Token> settings qs

    module Topups =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("amount", options.Amount |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
            $"/v1/topups"
            |> RestApi.getAsync<Topup list> settings qs

        ///<p>Top up the balance of an account</p>
        let Create settings (formOptions: Topups'CreateOptions) =

            $"/v1/topups"
            |> RestApi.postAsync<_, Topup> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/topups/{options.Topup}"
            |> RestApi.getAsync<Topup> settings qs

        type UpdateOptions = {
            Topup: string
        }
        with
            static member Create (topup: string) =
                {
                    Topup = topup
                }

        ///<p>Updates the metadata of a top-up. Other top-up details are not editable by design.</p>
        let Update settings (formOptions: Topups'UpdateOptions) (options: UpdateOptions) =

            $"/v1/topups/{options.Topup}"
            |> RestApi.postAsync<_, Topup> settings (Map.empty) formOptions

    module TopupsCancel =

        type CancelOptions = {
            Topup: string
        }
        with
            static member Create (topup: string) =
                {
                    Topup = topup
                }

        ///<p>Cancels a top-up. Only pending top-ups can be canceled.</p>
        let Cancel settings (formOptions: TopupsCancel'CancelOptions) (options: CancelOptions) =

            $"/v1/topups/{options.Topup}/cancel"
            |> RestApi.postAsync<_, Topup> settings (Map.empty) formOptions

    module Transfers =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("created", options.Created |> box); ("destination", options.Destination |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("transfer_group", options.TransferGroup |> box)] |> Map.ofList
            $"/v1/transfers"
            |> RestApi.getAsync<Transfer list> settings qs

        ///<p>To send funds from your Stripe account to a connected account, you create a new transfer object. Your <a href="#balance">Stripe balance</a> must be able to cover the transfer amount, or you’ll receive an “Insufficient Funds” error.</p>
        let Create settings (formOptions: Transfers'CreateOptions) =

            $"/v1/transfers"
            |> RestApi.postAsync<_, Transfer> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/transfers/{options.Transfer}"
            |> RestApi.getAsync<Transfer> settings qs

        type UpdateOptions = {
            Transfer: string
        }
        with
            static member Create (transfer: string) =
                {
                    Transfer = transfer
                }

        ///<p>Updates the specified transfer by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
        ///This request accepts only metadata as an argument.</p>
        let Update settings (formOptions: Transfers'UpdateOptions) (options: UpdateOptions) =

            $"/v1/transfers/{options.Transfer}"
            |> RestApi.postAsync<_, Transfer> settings (Map.empty) formOptions

    module TransfersReversals =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/transfers/{options.Id}/reversals"
            |> RestApi.getAsync<TransferReversal list> settings qs

        type CreateOptions = {
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
        let Create settings (formOptions: TransfersReversals'CreateOptions) (options: CreateOptions) =

            $"/v1/transfers/{options.Id}/reversals"
            |> RestApi.postAsync<_, TransferReversal> settings (Map.empty) formOptions

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/transfers/{options.Transfer}/reversals/{options.Id}"
            |> RestApi.getAsync<TransferReversal> settings qs

        type UpdateOptions = {
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
        let Update settings (formOptions: TransfersReversals'UpdateOptions) (options: UpdateOptions) =

            $"/v1/transfers/{options.Transfer}/reversals/{options.Id}"
            |> RestApi.postAsync<_, TransferReversal> settings (Map.empty) formOptions

    module WebhookEndpoints =

        type ListOptions = {
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
        let List settings (options: ListOptions) =
            let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
            $"/v1/webhook_endpoints"
            |> RestApi.getAsync<WebhookEndpoint list> settings qs

        ///<p>A webhook endpoint must have a <code>url</code> and a list of <code>enabled_events</code>. You may optionally specify the Boolean <code>connect</code> parameter. If set to true, then a Connect webhook endpoint that notifies the specified <code>url</code> about events from all connected accounts is created; otherwise an account webhook endpoint that notifies the specified <code>url</code> only about events from your account is created. You can also create webhook endpoints in the <a href="https://dashboard.stripe.com/account/webhooks">webhooks settings</a> section of the Dashboard.</p>
        let Create settings (formOptions: WebhookEndpoints'CreateOptions) =

            $"/v1/webhook_endpoints"
            |> RestApi.postAsync<_, WebhookEndpoint> settings (Map.empty) formOptions

        type DeleteOptions = {
            WebhookEndpoint: string
        }
        with
            static member Create (webhookEndpoint: string) =
                {
                    WebhookEndpoint = webhookEndpoint
                }

        ///<p>You can also delete webhook endpoints via the <a href="https://dashboard.stripe.com/account/webhooks">webhook endpoint management</a> page of the Stripe dashboard.</p>
        let Delete settings (options: DeleteOptions) =

            $"/v1/webhook_endpoints/{options.WebhookEndpoint}"
            |> RestApi.deleteAsync<DeletedWebhookEndpoint> settings (Map.empty)

        type RetrieveOptions = {
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
        let Retrieve settings (options: RetrieveOptions) =
            let qs = [("expand", options.Expand |> box)] |> Map.ofList
            $"/v1/webhook_endpoints/{options.WebhookEndpoint}"
            |> RestApi.getAsync<WebhookEndpoint> settings qs

        type UpdateOptions = {
            WebhookEndpoint: string
        }
        with
            static member Create (webhookEndpoint: string) =
                {
                    WebhookEndpoint = webhookEndpoint
                }

        ///<p>Updates the webhook endpoint. You may edit the <code>url</code>, the list of <code>enabled_events</code>, and the status of your endpoint.</p>
        let Update settings (formOptions: WebhookEndpoints'UpdateOptions) (options: UpdateOptions) =

            $"/v1/webhook_endpoints/{options.WebhookEndpoint}"
            |> RestApi.postAsync<_, WebhookEndpoint> settings (Map.empty) formOptions

