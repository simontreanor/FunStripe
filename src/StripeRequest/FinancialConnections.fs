namespace StripeRequest.FinancialConnections

open FunStripe
open System.Text.Json.Serialization
open Stripe.FinancialConnections
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
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

    module ListOptions =
        let create
            (
                accountHolder: Map<string, string> option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                session: string option,
                startingAfter: string option
            ) : ListOptions
            =
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

    module RetrieveOptions =
        let create
            (
                account: string
            ) : RetrieveOptions
            =
            {
              Account = account
              Expand = None
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

    module DisconnectOptions =
        let create
            (
                account: string
            ) : DisconnectOptions
            =
            {
              Account = account
              Expand = None
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

    module ListOwnersOptions =
        let create
            (
                account: string,
                ownership: string
            ) : ListOwnersOptions
            =
            {
              Account = account
              Ownership = ownership
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
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

    module RefreshOptions =
        let create
            (
                account: string,
                features: Refresh'Features list
            ) : RefreshOptions
            =
            {
              Account = account
              Features = features
              Expand = None
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

    module SubscribeOptions =
        let create
            (
                account: string,
                features: Subscribe'Features list
            ) : SubscribeOptions
            =
            {
              Account = account
              Features = features
              Expand = None
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

    module UnsubscribeOptions =
        let create
            (
                account: string,
                features: Unsubscribe'Features list
            ) : UnsubscribeOptions
            =
            {
              Account = account
              Features = features
              Expand = None
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

    module Create'AccountHolder =
        let create
            (
                account: string option,
                customer: string option,
                customerAccount: string option,
                ``type``: Create'AccountHolderType option
            ) : Create'AccountHolder
            =
            {
              Account = account
              Customer = customer
              CustomerAccount = customerAccount
              Type = ``type``
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

    module Create'Filters =
        let create
            (
                accountSubcategories: Create'FiltersAccountSubcategories list option,
                countries: string list option
            ) : Create'Filters
            =
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

    module CreateOptions =
        let create
            (
                accountHolder: Create'AccountHolder,
                permissions: Create'Permissions list
            ) : CreateOptions
            =
            {
              AccountHolder = accountHolder
              Permissions = permissions
              Expand = None
              Filters = None
              Prefetch = None
              ReturnUrl = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Session: string
        }

    module RetrieveOptions =
        let create
            (
                session: string
            ) : RetrieveOptions
            =
            {
              Session = session
              Expand = None
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

    module ListOptions =
        let create
            (
                account: string
            ) : ListOptions
            =
            {
              Account = account
              EndingBefore = None
              Expand = None
              Limit = None
              StartingAfter = None
              TransactedAt = None
              TransactionRefresh = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Transaction: string
        }

    module RetrieveOptions =
        let create
            (
                transaction: string
            ) : RetrieveOptions
            =
            {
              Transaction = transaction
              Expand = None
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

