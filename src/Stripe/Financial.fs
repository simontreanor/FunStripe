namespace Stripe.Financial

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Bank

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type FinancialReportingFinanceReportRunRunParametersTimezone =
    | IntervalStart
    | IntervalEnd

type FinancialReportingFinanceReportRunRunParameters =
    {
        /// The set of output columns requested for inclusion in the report run.
        Columns: string list option
        /// Connected account ID by which to filter the report run.
        ConnectedAccount: string option
        /// Currency of objects to be included in the report run.
        Currency: IsoTypes.IsoCurrencyCode option
        /// Ending timestamp of data to be included in the report run. Can be any UTC timestamp between 1 second after the user specified `interval_start` and 1 second before this report's last `data_available_end` value.
        IntervalEnd: DateTime option
        /// Starting timestamp of data to be included in the report run. Can be any UTC timestamp between 1 second after this report's `data_available_start` and 1 second before the user specified `interval_end` value.
        IntervalStart: DateTime option
        /// Payout ID by which to filter the report run.
        Payout: string option
        /// Category of balance transactions to be included in the report run.
        ReportingCategory: string option
        /// Defaults to `Etc/UTC`. The output timezone for all timestamps in the report. A list of possible time zone values is maintained at the [IANA Time Zone Database](http://www.iana.org/time-zones). Has no effect on `interval_start` or `interval_end`.
        Timezone: FinancialReportingFinanceReportRunRunParametersTimezone option
    }

module FinancialReportingFinanceReportRunRunParameters =
    let create
        (
            columns: string list option,
            connectedAccount: string option,
            currency: IsoTypes.IsoCurrencyCode option,
            intervalEnd: DateTime option,
            intervalStart: DateTime option,
            payout: string option,
            reportingCategory: string option,
            timezone: FinancialReportingFinanceReportRunRunParametersTimezone option
        ) : FinancialReportingFinanceReportRunRunParameters
        =
        {
          Columns = columns
          ConnectedAccount = connectedAccount
          Currency = currency
          IntervalEnd = intervalEnd
          IntervalStart = intervalStart
          Payout = payout
          ReportingCategory = reportingCategory
          Timezone = timezone
        }

[<Struct>]
type FinancialConnectionsTransactionStatus =
    | Pending
    | Posted
    | Void

/// A Transaction represents a real transaction that affects a Financial Connections Account balance.
type FinancialConnectionsTransaction =
    {
        /// The ID of the Financial Connections Account this transaction belongs to.
        Account: string
        /// The amount of this transaction, in cents (or local equivalent).
        Amount: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// The description of this transaction.
        Description: string
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The status of the transaction.
        Status: FinancialConnectionsTransactionStatus
        StatusTransitions: BankConnectionsResourceTransactionResourceStatusTransitions
        /// Time at which the transaction was transacted. Measured in seconds since the Unix epoch.
        TransactedAt: DateTime
        /// The token of the transaction refresh that last updated or created this transaction.
        TransactionRefresh: string
        /// Time at which the object was last updated. Measured in seconds since the Unix epoch.
        Updated: DateTime
    }

module FinancialConnectionsTransaction =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "financial_connections.transaction"

    let create
        (
            account: string,
            amount: int,
            currency: IsoTypes.IsoCurrencyCode,
            description: string,
            id: string,
            livemode: bool,
            status: FinancialConnectionsTransactionStatus,
            statusTransitions: BankConnectionsResourceTransactionResourceStatusTransitions,
            transactedAt: DateTime,
            transactionRefresh: string,
            updated: DateTime
        ) : FinancialConnectionsTransaction
        =
        {
          Account = account
          Amount = amount
          Currency = currency
          Description = description
          Id = id
          Livemode = livemode
          Status = status
          StatusTransitions = statusTransitions
          TransactedAt = transactedAt
          TransactionRefresh = transactionRefresh
          Updated = updated
        }

[<Struct>]
type FinancialConnectionsAccountCategory =
    | Cash
    | Credit
    | Investment
    | Other

/// Describes an owner of an account.
type FinancialConnectionsAccountOwner =
    {
        /// The email address of the owner.
        Email: string option
        /// Unique identifier for the object.
        Id: string
        /// The full name of the owner.
        Name: string
        /// The ownership object that this owner belongs to.
        Ownership: string
        /// The raw phone number of the owner.
        Phone: string option
        /// The raw physical address of the owner.
        RawAddress: string option
        /// The timestamp of the refresh that updated this owner.
        RefreshedAt: DateTime option
    }

module FinancialConnectionsAccountOwner =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "financial_connections.account_owner"

    let create
        (
            email: string option,
            id: string,
            name: string,
            ownership: string,
            phone: string option,
            rawAddress: string option,
            refreshedAt: DateTime option
        ) : FinancialConnectionsAccountOwner
        =
        {
          Email = email
          Id = id
          Name = name
          Ownership = ownership
          Phone = phone
          RawAddress = rawAddress
          RefreshedAt = refreshedAt
        }

/// A paginated list of owners for this account.
type FinancialConnectionsAccountOwnershipOwners =
    {
        /// Details about each object.
        Data: FinancialConnectionsAccountOwner list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

module FinancialConnectionsAccountOwnershipOwners =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

    let create
        (
            data: FinancialConnectionsAccountOwner list,
            hasMore: bool,
            url: string
        ) : FinancialConnectionsAccountOwnershipOwners
        =
        {
          Data = data
          HasMore = hasMore
          Url = url
        }

/// Describes a snapshot of the owners of an account at a particular point in time.
type FinancialConnectionsAccountOwnership =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Unique identifier for the object.
        Id: string
        /// A paginated list of owners for this account.
        Owners: FinancialConnectionsAccountOwnershipOwners
    }

module FinancialConnectionsAccountOwnership =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "financial_connections.account_ownership"

    let create
        (
            created: DateTime,
            id: string,
            owners: FinancialConnectionsAccountOwnershipOwners
        ) : FinancialConnectionsAccountOwnership
        =
        {
          Created = created
          Id = id
          Owners = owners
        }

type FinancialConnectionsAccountOwnership'AnyOf =
    | String of string
    | FinancialConnectionsAccountOwnership of FinancialConnectionsAccountOwnership

[<Struct>]
type FinancialConnectionsAccountPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

[<Struct>]
type FinancialConnectionsAccountStatus =
    | Active
    | Disconnected
    | Inactive

type FinancialConnectionsAccountSubcategory =
    | Checking
    | CreditCard
    | LineOfCredit
    | Mortgage
    | Other
    | Savings

[<Struct>]
type FinancialConnectionsAccountSupportedPaymentMethodTypes =
    | Link
    | UsBankAccount

/// A Financial Connections Account represents an account that exists outside of Stripe, to which you have been granted some degree of access.
type FinancialConnectionsAccount =
    {
        /// The account holder that this account belongs to.
        AccountHolder: BankConnectionsResourceAccountholder option
        /// Details about the account numbers.
        AccountNumbers: BankConnectionsResourceAccountNumberDetails list option
        /// The most recent information about the account's balance.
        Balance: BankConnectionsResourceBalance option
        /// The state of the most recent attempt to refresh the account balance.
        BalanceRefresh: BankConnectionsResourceBalanceRefresh option
        /// The type of the account. Account category is further divided in `subcategory`.
        Category: FinancialConnectionsAccountCategory
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// A human-readable name that has been assigned to this account, either by the account holder or by the institution.
        DisplayName: string option
        /// Unique identifier for the object.
        Id: string
        /// The name of the institution that holds this account.
        InstitutionName: string
        /// The last 4 digits of the account number. If present, this will be 4 numeric characters.
        [<JsonPropertyName("last4")>]
        Last4: string option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The most recent information about the account's owners.
        Ownership: FinancialConnectionsAccountOwnership'AnyOf option
        /// The state of the most recent attempt to refresh the account owners.
        OwnershipRefresh: BankConnectionsResourceOwnershipRefresh option
        /// The list of permissions granted by this account.
        Permissions: FinancialConnectionsAccountPermissions list option
        /// The status of the link to the account.
        Status: FinancialConnectionsAccountStatus
        /// If `category` is `cash`, one of:
        ///  - `checking`
        ///  - `savings`
        ///  - `other`
        /// If `category` is `credit`, one of:
        ///  - `mortgage`
        ///  - `line_of_credit`
        ///  - `credit_card`
        ///  - `other`
        /// If `category` is `investment` or `other`, this will be `other`.
        Subcategory: FinancialConnectionsAccountSubcategory
        /// The list of data refresh subscriptions requested on this account.
        Subscriptions: string list option
        /// The [PaymentMethod type](https://docs.stripe.com/api/payment_methods/object#payment_method_object-type)(s) that can be created from this account.
        SupportedPaymentMethodTypes: FinancialConnectionsAccountSupportedPaymentMethodTypes list
        /// The state of the most recent attempt to refresh the account transactions.
        TransactionRefresh: BankConnectionsResourceTransactionRefresh option
    }

module FinancialConnectionsAccount =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "financial_connections.account"

    let create
        (
            accountHolder: BankConnectionsResourceAccountholder option,
            accountNumbers: BankConnectionsResourceAccountNumberDetails list option,
            balance: BankConnectionsResourceBalance option,
            balanceRefresh: BankConnectionsResourceBalanceRefresh option,
            category: FinancialConnectionsAccountCategory,
            created: DateTime,
            displayName: string option,
            id: string,
            institutionName: string,
            last4: string option,
            livemode: bool,
            ownership: FinancialConnectionsAccountOwnership'AnyOf option,
            ownershipRefresh: BankConnectionsResourceOwnershipRefresh option,
            permissions: FinancialConnectionsAccountPermissions list option,
            status: FinancialConnectionsAccountStatus,
            subcategory: FinancialConnectionsAccountSubcategory,
            subscriptions: string list option,
            supportedPaymentMethodTypes: FinancialConnectionsAccountSupportedPaymentMethodTypes list,
            transactionRefresh: BankConnectionsResourceTransactionRefresh option
        ) : FinancialConnectionsAccount
        =
        {
          AccountHolder = accountHolder
          AccountNumbers = accountNumbers
          Balance = balance
          BalanceRefresh = balanceRefresh
          Category = category
          Created = created
          DisplayName = displayName
          Id = id
          InstitutionName = institutionName
          Last4 = last4
          Livemode = livemode
          Ownership = ownership
          OwnershipRefresh = ownershipRefresh
          Permissions = permissions
          Status = status
          Subcategory = subcategory
          Subscriptions = subscriptions
          SupportedPaymentMethodTypes = supportedPaymentMethodTypes
          TransactionRefresh = transactionRefresh
        }

/// The accounts that were collected as part of this Session.
type FinancialConnectionsSessionAccounts =
    {
        /// Details about each object.
        Data: FinancialConnectionsAccount list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

module FinancialConnectionsSessionAccounts =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

    let create
        (
            data: FinancialConnectionsAccount list,
            hasMore: bool,
            url: string
        ) : FinancialConnectionsSessionAccounts
        =
        {
          Data = data
          HasMore = hasMore
          Url = url
        }

[<Struct>]
type FinancialConnectionsSessionPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

[<Struct>]
type FinancialConnectionsSessionPrefetch =
    | Balances
    | Ownership
    | Transactions

/// A Financial Connections Session is the secure way to programmatically launch the client-side Stripe.js modal that lets your users link their accounts.
type FinancialConnectionsSession =
    {
        /// The account holder for whom accounts are collected in this session.
        AccountHolder: BankConnectionsResourceAccountholder option
        /// The accounts that were collected as part of this Session.
        Accounts: FinancialConnectionsSessionAccounts
        /// A value that will be passed to the client to launch the authentication flow.
        ClientSecret: string option
        Filters: BankConnectionsResourceLinkAccountSessionFilters option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Permissions requested for accounts collected during this session.
        Permissions: FinancialConnectionsSessionPermissions list
        /// Data features requested to be retrieved upon account creation.
        Prefetch: FinancialConnectionsSessionPrefetch list option
        /// For webview integrations only. Upon completing OAuth login in the native browser, the user will be redirected to this URL to return to your app.
        ReturnUrl: string option
    }

module FinancialConnectionsSession =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "financial_connections.session"

    let create
        (
            accountHolder: BankConnectionsResourceAccountholder option,
            accounts: FinancialConnectionsSessionAccounts,
            clientSecret: string option,
            id: string,
            livemode: bool,
            permissions: FinancialConnectionsSessionPermissions list,
            prefetch: FinancialConnectionsSessionPrefetch list option,
            filters: BankConnectionsResourceLinkAccountSessionFilters option,
            returnUrl: string option
        ) : FinancialConnectionsSession
        =
        {
          AccountHolder = accountHolder
          Accounts = accounts
          ClientSecret = clientSecret
          Id = id
          Livemode = livemode
          Permissions = permissions
          Prefetch = prefetch
          Filters = filters
          ReturnUrl = returnUrl
        }

/// Occurs when an Account’s tokenized account number is about to expire.
type FinancialConnectionsAccountUpcomingAccountNumberExpiry = { Object: FinancialConnectionsAccount }

module FinancialConnectionsAccountUpcomingAccountNumberExpiry =
    let create
        (
            object: FinancialConnectionsAccount
        ) : FinancialConnectionsAccountUpcomingAccountNumberExpiry
        =
        {
          Object = object
        }

/// Occurs when an Account’s `transaction_refresh` status transitions from `pending` to either `succeeded` or `failed`.
type FinancialConnectionsAccountRefreshedTransactions = { Object: FinancialConnectionsAccount }

module FinancialConnectionsAccountRefreshedTransactions =
    let create
        (
            object: FinancialConnectionsAccount
        ) : FinancialConnectionsAccountRefreshedTransactions
        =
        {
          Object = object
        }

/// Occurs when an Account’s `ownership_refresh` status transitions from `pending` to either `succeeded` or `failed`.
type FinancialConnectionsAccountRefreshedOwnership = { Object: FinancialConnectionsAccount }

module FinancialConnectionsAccountRefreshedOwnership =
    let create
        (
            object: FinancialConnectionsAccount
        ) : FinancialConnectionsAccountRefreshedOwnership
        =
        {
          Object = object
        }

/// Occurs when an Account’s `balance_refresh` status transitions from `pending` to either `succeeded` or `failed`.
type FinancialConnectionsAccountRefreshedBalance = { Object: FinancialConnectionsAccount }

module FinancialConnectionsAccountRefreshedBalance =
    let create
        (
            object: FinancialConnectionsAccount
        ) : FinancialConnectionsAccountRefreshedBalance
        =
        {
          Object = object
        }

/// Occurs when a Financial Connections account's status is updated from `inactive` to `active`.
type FinancialConnectionsAccountReactivated = { Object: FinancialConnectionsAccount }

module FinancialConnectionsAccountReactivated =
    let create
        (
            object: FinancialConnectionsAccount
        ) : FinancialConnectionsAccountReactivated
        =
        {
          Object = object
        }

/// Occurs when a Financial Connections account is disconnected.
type FinancialConnectionsAccountDisconnected = { Object: FinancialConnectionsAccount }

module FinancialConnectionsAccountDisconnected =
    let create
        (
            object: FinancialConnectionsAccount
        ) : FinancialConnectionsAccountDisconnected
        =
        {
          Object = object
        }

/// Occurs when a Financial Connections account's status is updated from `active` to `inactive`.
type FinancialConnectionsAccountDeactivated = { Object: FinancialConnectionsAccount }

module FinancialConnectionsAccountDeactivated =
    let create
        (
            object: FinancialConnectionsAccount
        ) : FinancialConnectionsAccountDeactivated
        =
        {
          Object = object
        }

/// Occurs when a new Financial Connections account is created.
type FinancialConnectionsAccountCreated = { Object: FinancialConnectionsAccount }

module FinancialConnectionsAccountCreated =
    let create
        (
            object: FinancialConnectionsAccount
        ) : FinancialConnectionsAccountCreated
        =
        {
          Object = object
        }

/// Occurs when a Financial Connections account's account numbers are updated.
type FinancialConnectionsAccountAccountNumbersUpdated = { Object: FinancialConnectionsAccount }

module FinancialConnectionsAccountAccountNumbersUpdated =
    let create
        (
            object: FinancialConnectionsAccount
        ) : FinancialConnectionsAccountAccountNumbersUpdated
        =
        {
          Object = object
        }

