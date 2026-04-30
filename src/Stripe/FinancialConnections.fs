namespace Stripe.FinancialConnections

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type BankConnectionsResourceTransactionResourceStatusTransitions =
    {
        /// Time at which this transaction posted. Measured in seconds since the Unix epoch.
        PostedAt: DateTime option
        /// Time at which this transaction was voided. Measured in seconds since the Unix epoch.
        VoidAt: DateTime option
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

[<Struct>]
type BankConnectionsResourceAccountholderType =
    | Account
    | Customer

type BankConnectionsResourceAccountholder =
    {
        /// The ID of the Stripe account that this account belongs to. Only available when `account_holder.type` is `account`.
        Account: string option
        /// The ID for an Account representing a customer that this account belongs to. Only available when `account_holder.type` is `customer`.
        Customer: string option
        CustomerAccount: string option
        /// Type of account holder that this account belongs to.
        Type: BankConnectionsResourceAccountholderType
    }

[<Struct>]
type BankConnectionsResourceLinkAccountSessionFiltersAccountSubcategories =
    | Checking
    | CreditCard
    | LineOfCredit
    | Mortgage
    | Savings

type BankConnectionsResourceLinkAccountSessionFilters =
    {
        /// Restricts the Session to subcategories of accounts that can be linked. Valid subcategories are: `checking`, `savings`, `mortgage`, `line_of_credit`, `credit_card`.
        AccountSubcategories: BankConnectionsResourceLinkAccountSessionFiltersAccountSubcategories list option
        /// List of countries from which to filter accounts.
        Countries: string list option
    }

[<Struct>]
type BankConnectionsResourceAccountNumberDetailsIdentifierType =
    | AccountNumber
    | TokenizedAccountNumber

[<Struct>]
type BankConnectionsResourceAccountNumberDetailsStatus =
    | Deactivated
    | Transactable

type BankConnectionsResourceAccountNumberDetails =
    {
        /// When the account number is expected to expire, if applicable.
        ExpectedExpiryDate: DateTime option
        /// The type of account number associated with the account.
        IdentifierType: BankConnectionsResourceAccountNumberDetailsIdentifierType
        /// Whether the account number is currently active and usable for transactions.
        Status: BankConnectionsResourceAccountNumberDetailsStatus
        /// The payment networks that the account number can be used for.
        SupportedNetworks: string list
    }

type BankConnectionsResourceBalanceApiResourceCashBalance =
    {
        /// The funds available to the account holder. Typically this is the current balance after subtracting any outbound pending transactions and adding any inbound pending transactions.
        /// Each key is a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase.
        /// Each value is a integer amount. A positive amount indicates money owed to the account holder. A negative amount indicates money owed by the account holder.
        Available: Map<string, string list> option
    }

type BankConnectionsResourceBalanceApiResourceCreditBalance =
    {
        /// The credit that has been used by the account holder.
        /// Each key is a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase.
        /// Each value is a integer amount. A positive amount indicates money owed to the account holder. A negative amount indicates money owed by the account holder.
        Used: Map<string, string list> option
    }

[<Struct>]
type BankConnectionsResourceBalanceType =
    | Cash
    | Credit

type BankConnectionsResourceBalance =
    {
        /// The time that the external institution calculated this balance. Measured in seconds since the Unix epoch.
        AsOf: DateTime
        Cash: BankConnectionsResourceBalanceApiResourceCashBalance option
        Credit: BankConnectionsResourceBalanceApiResourceCreditBalance option
        /// The balances owed to (or by) the account holder, before subtracting any outbound pending transactions or adding any inbound pending transactions.
        /// Each key is a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase.
        /// Each value is a integer amount. A positive amount indicates money owed to the account holder. A negative amount indicates money owed by the account holder.
        Current: Map<string, string list>
        /// The `type` of the balance. An additional hash is included on the balance with a name matching this value.
        Type: BankConnectionsResourceBalanceType
    }

[<Struct>]
type BankConnectionsResourceBalanceRefreshStatus =
    | Failed
    | Pending
    | Succeeded

type BankConnectionsResourceBalanceRefresh =
    {
        /// The time at which the last refresh attempt was initiated. Measured in seconds since the Unix epoch.
        LastAttemptedAt: DateTime
        /// Time at which the next balance refresh can be initiated. This value will be `null` when `status` is `pending`. Measured in seconds since the Unix epoch.
        NextRefreshAvailableAt: DateTime option
        /// The status of the last refresh attempt.
        Status: BankConnectionsResourceBalanceRefreshStatus
    }

[<Struct>]
type BankConnectionsResourceOwnershipRefreshStatus =
    | Failed
    | Pending
    | Succeeded

type BankConnectionsResourceOwnershipRefresh =
    {
        /// The time at which the last refresh attempt was initiated. Measured in seconds since the Unix epoch.
        LastAttemptedAt: DateTime
        /// Time at which the next ownership refresh can be initiated. This value will be `null` when `status` is `pending`. Measured in seconds since the Unix epoch.
        NextRefreshAvailableAt: DateTime option
        /// The status of the last refresh attempt.
        Status: BankConnectionsResourceOwnershipRefreshStatus
    }

[<Struct>]
type BankConnectionsResourceTransactionRefreshStatus =
    | Failed
    | Pending
    | Succeeded

type BankConnectionsResourceTransactionRefresh =
    {
        /// Unique identifier for the object.
        Id: string
        /// The time at which the last refresh attempt was initiated. Measured in seconds since the Unix epoch.
        LastAttemptedAt: DateTime
        /// Time at which the next transaction refresh can be initiated. This value will be `null` when `status` is `pending`. Measured in seconds since the Unix epoch.
        NextRefreshAvailableAt: DateTime option
        /// The status of the last refresh attempt.
        Status: BankConnectionsResourceTransactionRefreshStatus
    }

[<Struct>]
type FinancialConnectionsAccountCategory =
    | Cash
    | Credit
    | Investment
    | Other

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
        Ownership: string option
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

/// Occurs when an Account’s tokenized account number is about to expire.
type FinancialConnectionsAccountUpcomingAccountNumberExpiry = { Object: FinancialConnectionsAccount }

/// Occurs when an Account’s `transaction_refresh` status transitions from `pending` to either `succeeded` or `failed`.
type FinancialConnectionsAccountRefreshedTransactions = { Object: FinancialConnectionsAccount }

/// Occurs when an Account’s `ownership_refresh` status transitions from `pending` to either `succeeded` or `failed`.
type FinancialConnectionsAccountRefreshedOwnership = { Object: FinancialConnectionsAccount }

/// Occurs when an Account’s `balance_refresh` status transitions from `pending` to either `succeeded` or `failed`.
type FinancialConnectionsAccountRefreshedBalance = { Object: FinancialConnectionsAccount }

/// Occurs when a Financial Connections account's status is updated from `inactive` to `active`.
type FinancialConnectionsAccountReactivated = { Object: FinancialConnectionsAccount }

/// Occurs when a Financial Connections account is disconnected.
type FinancialConnectionsAccountDisconnected = { Object: FinancialConnectionsAccount }

/// Occurs when a Financial Connections account's status is updated from `active` to `inactive`.
type FinancialConnectionsAccountDeactivated = { Object: FinancialConnectionsAccount }

/// Occurs when a new Financial Connections account is created.
type FinancialConnectionsAccountCreated = { Object: FinancialConnectionsAccount }

/// Occurs when a Financial Connections account's account numbers are updated.
type FinancialConnectionsAccountAccountNumbersUpdated = { Object: FinancialConnectionsAccount }

