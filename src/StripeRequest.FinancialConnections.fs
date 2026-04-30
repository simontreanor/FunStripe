namespace FunStripe.StripeRequest

open FunStripe
open System.Text.Json.Serialization
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module FinancialConnectionsAccounts =

    type ListOptions = {
        ///<summary>If present, only return accounts that belong to the specified account holder. `account_holder[customer]` and `account_holder[account]` are mutually exclusive.</summary>
        [<Config.Query>]AccountHolder: Map<string, string> option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>If present, only return accounts that were collected as part of the given session.</summary>
        [<Config.Query>]Session: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?accountHolder: Map<string, string>, ?endingBefore: string, ?expand: string list, ?limit: int, ?session: string, ?startingAfter: string) =
            {
                AccountHolder = accountHolder
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Session = session
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of Financial Connections <code>Account</code> objects.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("account_holder", options.AccountHolder |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("session", options.Session |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/financial_connections/accounts"
        |> RestApi.getAsync<StripeList<FinancialConnectionsAccount>> settings qs

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

    ///<summary><p>Retrieves the details of an Financial Connections <code>Account</code>.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/financial_connections/accounts/{options.Account}"
        |> RestApi.getAsync<FinancialConnectionsAccount> settings qs

module FinancialConnectionsAccountsDisconnect =

    type DisconnectOptions = {
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

    ///<summary><p>Disables your access to a Financial Connections <code>Account</code>. You will no longer be able to access data associated with the account (e.g. balances, transactions).</p></summary>
    let Disconnect settings (options: DisconnectOptions) =
        $"/v1/financial_connections/accounts/{options.Account}/disconnect"
        |> RestApi.postAsync<_, FinancialConnectionsAccount> settings (Map.empty) options

module FinancialConnectionsAccountsOwners =

    type ListOwnersOptions = {
        [<Config.Path>]Account: string
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>The ID of the ownership object to fetch owners from.</summary>
        [<Config.Query>]Ownership: string
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(account: string, ownership: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Account = account
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Ownership = ownership
                StartingAfter = startingAfter
            }

    ///<summary><p>Lists all owners for a given <code>Account</code></p></summary>
    let ListOwners settings (options: ListOwnersOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("ownership", options.Ownership |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/financial_connections/accounts/{options.Account}/owners"
        |> RestApi.getAsync<StripeList<FinancialConnectionsAccountOwner>> settings qs

module FinancialConnectionsAccountsRefresh =

    type Refresh'Features =
    | Balance
    | Ownership
    | Transactions

    type RefreshOptions = {
        [<Config.Path>]Account: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The list of account features that you would like to refresh.</summary>
        [<Config.Form>]Features: Refresh'Features list
    }
    with
        static member New(account: string, features: Refresh'Features list, ?expand: string list) =
            {
                Account = account
                Expand = expand
                Features = features
            }

    ///<summary><p>Refreshes the data associated with a Financial Connections <code>Account</code>.</p></summary>
    let Refresh settings (options: RefreshOptions) =
        $"/v1/financial_connections/accounts/{options.Account}/refresh"
        |> RestApi.postAsync<_, FinancialConnectionsAccount> settings (Map.empty) options

module FinancialConnectionsAccountsSubscribe =

    type Subscribe'Features =
    | Transactions

    type SubscribeOptions = {
        [<Config.Path>]Account: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The list of account features to which you would like to subscribe.</summary>
        [<Config.Form>]Features: Subscribe'Features list
    }
    with
        static member New(account: string, features: Subscribe'Features list, ?expand: string list) =
            {
                Account = account
                Expand = expand
                Features = features
            }

    ///<summary><p>Subscribes to periodic refreshes of data associated with a Financial Connections <code>Account</code>. When the account status is active, data is typically refreshed once a day.</p></summary>
    let Subscribe settings (options: SubscribeOptions) =
        $"/v1/financial_connections/accounts/{options.Account}/subscribe"
        |> RestApi.postAsync<_, FinancialConnectionsAccount> settings (Map.empty) options

module FinancialConnectionsAccountsUnsubscribe =

    type Unsubscribe'Features =
    | Transactions

    type UnsubscribeOptions = {
        [<Config.Path>]Account: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The list of account features from which you would like to unsubscribe.</summary>
        [<Config.Form>]Features: Unsubscribe'Features list
    }
    with
        static member New(account: string, features: Unsubscribe'Features list, ?expand: string list) =
            {
                Account = account
                Expand = expand
                Features = features
            }

    ///<summary><p>Unsubscribes from periodic refreshes of data associated with a Financial Connections <code>Account</code>.</p></summary>
    let Unsubscribe settings (options: UnsubscribeOptions) =
        $"/v1/financial_connections/accounts/{options.Account}/unsubscribe"
        |> RestApi.postAsync<_, FinancialConnectionsAccount> settings (Map.empty) options

module FinancialConnectionsSessions =

    type Create'AccountHolderType =
    | Account
    | Customer

    type Create'AccountHolder = {
        ///<summary>The ID of the Stripe account whose accounts you will retrieve. Only available when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>The ID of the Stripe customer whose accounts you will retrieve. Only available when `type` is `customer`.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>The ID of Account representing a customer whose accounts you will retrieve. Only available when `type` is `customer`.</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>Type of account holder to collect accounts for.</summary>
        [<Config.Form>]Type: Create'AccountHolderType option
    }
    with
        static member New(?account: string, ?customer: string, ?customerAccount: string, ?type': Create'AccountHolderType) =
            {
                Account = account
                Customer = customer
                CustomerAccount = customerAccount
                Type = type'
            }

    type Create'FiltersAccountSubcategories =
    | Checking
    | CreditCard
    | LineOfCredit
    | Mortgage
    | Savings

    type Create'Filters = {
        ///<summary>Restricts the Session to subcategories of accounts that can be linked. Valid subcategories are: `checking`, `savings`, `mortgage`, `line_of_credit`, `credit_card`.</summary>
        [<Config.Form>]AccountSubcategories: Create'FiltersAccountSubcategories list option
        ///<summary>List of countries from which to collect accounts.</summary>
        [<Config.Form>]Countries: string list option
    }
    with
        static member New(?accountSubcategories: Create'FiltersAccountSubcategories list, ?countries: string list) =
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

    type CreateOptions = {
        ///<summary>The account holder to link accounts for.</summary>
        [<Config.Form>]AccountHolder: Create'AccountHolder
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Filters to restrict the kinds of accounts to collect.</summary>
        [<Config.Form>]Filters: Create'Filters option
        ///<summary>List of data features that you would like to request access to.
        ///Possible values are `balances`, `transactions`, `ownership`, and `payment_method`.</summary>
        [<Config.Form>]Permissions: Create'Permissions list
        ///<summary>List of data features that you would like to retrieve upon account creation.</summary>
        [<Config.Form>]Prefetch: Create'Prefetch list option
        ///<summary>For webview integrations only. Upon completing OAuth login in the native browser, the user will be redirected to this URL to return to your app.</summary>
        [<Config.Form>]ReturnUrl: string option
    }
    with
        static member New(accountHolder: Create'AccountHolder, permissions: Create'Permissions list, ?expand: string list, ?filters: Create'Filters, ?prefetch: Create'Prefetch list, ?returnUrl: string) =
            {
                AccountHolder = accountHolder
                Expand = expand
                Filters = filters
                Permissions = permissions
                Prefetch = prefetch
                ReturnUrl = returnUrl
            }

    ///<summary><p>To launch the Financial Connections authorization flow, create a <code>Session</code>. The session’s <code>client_secret</code> can be used to launch the flow using Stripe.js.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/financial_connections/sessions"
        |> RestApi.postAsync<_, FinancialConnectionsSession> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Session: string
    }
    with
        static member New(session: string, ?expand: string list) =
            {
                Expand = expand
                Session = session
            }

    ///<summary><p>Retrieves the details of a Financial Connections <code>Session</code></p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/financial_connections/sessions/{options.Session}"
        |> RestApi.getAsync<FinancialConnectionsSession> settings qs

module FinancialConnectionsTransactions =

    type ListOptions = {
        ///<summary>The ID of the Financial Connections Account whose transactions will be retrieved.</summary>
        [<Config.Query>]Account: string
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>A filter on the list based on the object `transacted_at` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with the following options:</summary>
        [<Config.Query>]TransactedAt: int option
        ///<summary>A filter on the list based on the object `transaction_refresh` field. The value can be a dictionary with the following options:</summary>
        [<Config.Query>]TransactionRefresh: Map<string, string> option
    }
    with
        static member New(account: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?transactedAt: int, ?transactionRefresh: Map<string, string>) =
            {
                Account = account
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                TransactedAt = transactedAt
                TransactionRefresh = transactionRefresh
            }

    ///<summary><p>Returns a list of Financial Connections <code>Transaction</code> objects.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("account", options.Account |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("transacted_at", options.TransactedAt |> box); ("transaction_refresh", options.TransactionRefresh |> box)] |> Map.ofList
        $"/v1/financial_connections/transactions"
        |> RestApi.getAsync<StripeList<FinancialConnectionsTransaction>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Transaction: string
    }
    with
        static member New(transaction: string, ?expand: string list) =
            {
                Expand = expand
                Transaction = transaction
            }

    ///<summary><p>Retrieves the details of a Financial Connections <code>Transaction</code></p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/financial_connections/transactions/{options.Transaction}"
        |> RestApi.getAsync<FinancialConnectionsTransaction> settings qs
