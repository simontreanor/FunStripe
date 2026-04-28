namespace FunStripe.StripeRequest

open FunStripe
open FunStripe.Json
open FunStripe.StripeModel
open System

module FinancialConnectionsAccounts =

    type ListOptions = {
        ///If present, only return accounts that belong to the specified account holder. `account_holder[customer]` and `account_holder[account]` are mutually exclusive.
        [<Config.Query>]AccountHolder: Map<string, string> option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///If present, only return accounts that were collected as part of the given session.
        [<Config.Query>]Session: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
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

    ///<p>Returns a list of Financial Connections <code>Account</code> objects.</p>
    let List settings (options: ListOptions) =
        let qs = [("account_holder", options.AccountHolder |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("session", options.Session |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/financial_connections/accounts"
        |> RestApi.getAsync<FinancialConnectionsAccount list> settings qs

    type RetrieveOptions = {
        [<Config.Path>]Account: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(account: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
            }

    ///<p>Retrieves the details of an Financial Connections <code>Account</code>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/financial_connections/accounts/{options.Account}"
        |> RestApi.getAsync<FinancialConnectionsAccount> settings qs

module FinancialConnectionsAccountsDisconnect =

    type DisconnectOptions = {
        [<Config.Path>]Account: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(account: string, ?expand: string list) =
            {
                Account = account
                Expand = expand
            }

    ///<p>Disables your access to a Financial Connections <code>Account</code>. You will no longer be able to access data associated with the account (e.g. balances, transactions).</p>
    let Disconnect settings (options: DisconnectOptions) =
        $"/v1/financial_connections/accounts/{options.Account}/disconnect"
        |> RestApi.postAsync<_, FinancialConnectionsAccount> settings (Map.empty) options

module FinancialConnectionsAccountsOwners =

    type ListOwnersOptions = {
        [<Config.Path>]Account: string
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///The ID of the ownership object to fetch owners from.
        [<Config.Query>]Ownership: string
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
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

    ///<p>Lists all owners for a given <code>Account</code></p>
    let ListOwners settings (options: ListOwnersOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("ownership", options.Ownership |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/financial_connections/accounts/{options.Account}/owners"
        |> RestApi.getAsync<FinancialConnectionsAccountOwner list> settings qs

module FinancialConnectionsAccountsRefresh =

    type Refresh'Features =
    | Balance
    | Ownership

    type RefreshOptions = {
        [<Config.Path>]Account: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The list of account features that you would like to refresh.
        [<Config.Form>]Features: Refresh'Features list
    }
    with
        static member New(account: string, features: Refresh'Features list, ?expand: string list) =
            {
                Account = account
                Expand = expand
                Features = features
            }

    ///<p>Refreshes the data associated with a Financial Connections <code>Account</code>.</p>
    let Refresh settings (options: RefreshOptions) =
        $"/v1/financial_connections/accounts/{options.Account}/refresh"
        |> RestApi.postAsync<_, FinancialConnectionsAccount> settings (Map.empty) options

module FinancialConnectionsSessions =

    type Create'AccountHolderType =
    | Account
    | Customer

    type Create'AccountHolder = {
        ///The ID of the Stripe account whose accounts will be retrieved. Should only be present if `type` is `account`.
        [<Config.Form>]Account: string option
        ///The ID of the Stripe customer whose accounts will be retrieved. Should only be present if `type` is `customer`.
        [<Config.Form>]Customer: string option
        ///Type of account holder to collect accounts for.
        [<Config.Form>]Type: Create'AccountHolderType option
    }
    with
        static member New(?account: string, ?customer: string, ?type': Create'AccountHolderType) =
            {
                Account = account
                Customer = customer
                Type = type'
            }

    type Create'Filters = {
        ///List of countries from which to collect accounts.
        [<Config.Form>]Countries: string list option
    }
    with
        static member New(?countries: string list) =
            {
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

    type CreateOptions = {
        ///The account holder to link accounts for.
        [<Config.Form>]AccountHolder: Create'AccountHolder
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Filters to restrict the kinds of accounts to collect.
        [<Config.Form>]Filters: Create'Filters option
        ///List of data features that you would like to request access to.
        ///Possible values are `balances`, `transactions`, `ownership`, and `payment_method`.
        [<Config.Form>]Permissions: Create'Permissions list
        ///List of data features that you would like to retrieve upon account creation.
        [<Config.Form>]Prefetch: Create'Prefetch list option
        ///For webview integrations only. Upon completing OAuth login in the native browser, the user will be redirected to this URL to return to your app.
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

    ///<p>To launch the Financial Connections authorization flow, create a <code>Session</code>. The session’s <code>client_secret</code> can be used to launch the flow using Stripe.js.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/financial_connections/sessions"
        |> RestApi.postAsync<_, FinancialConnectionsSession> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Session: string
    }
    with
        static member New(session: string, ?expand: string list) =
            {
                Expand = expand
                Session = session
            }

    ///<p>Retrieves the details of a Financial Connections <code>Session</code></p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/financial_connections/sessions/{options.Session}"
        |> RestApi.getAsync<FinancialConnectionsSession> settings qs
