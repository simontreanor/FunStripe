namespace Stripe.Bank

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Payment

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type BankConnectionsResourceTransactionResourceStatusTransitions =
    {
        /// Time at which this transaction posted. Measured in seconds since the Unix epoch.
        PostedAt: DateTime option
        /// Time at which this transaction was voided. Measured in seconds since the Unix epoch.
        VoidAt: DateTime option
    }

module BankConnectionsResourceTransactionResourceStatusTransitions =
    let create
        (
            postedAt: DateTime option,
            voidAt: DateTime option
        ) : BankConnectionsResourceTransactionResourceStatusTransitions
        =
        {
          PostedAt = postedAt
          VoidAt = voidAt
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

module BankConnectionsResourceTransactionRefresh =
    let create
        (
            id: string,
            lastAttemptedAt: DateTime,
            nextRefreshAvailableAt: DateTime option,
            status: BankConnectionsResourceTransactionRefreshStatus
        ) : BankConnectionsResourceTransactionRefresh
        =
        {
          Id = id
          LastAttemptedAt = lastAttemptedAt
          NextRefreshAvailableAt = nextRefreshAvailableAt
          Status = status
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

module BankConnectionsResourceOwnershipRefresh =
    let create
        (
            lastAttemptedAt: DateTime,
            nextRefreshAvailableAt: DateTime option,
            status: BankConnectionsResourceOwnershipRefreshStatus
        ) : BankConnectionsResourceOwnershipRefresh
        =
        {
          LastAttemptedAt = lastAttemptedAt
          NextRefreshAvailableAt = nextRefreshAvailableAt
          Status = status
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

module BankConnectionsResourceLinkAccountSessionFilters =
    let create
        (
            accountSubcategories: BankConnectionsResourceLinkAccountSessionFiltersAccountSubcategories list option,
            countries: string list option
        ) : BankConnectionsResourceLinkAccountSessionFilters
        =
        {
          AccountSubcategories = accountSubcategories
          Countries = countries
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

module BankConnectionsResourceBalanceRefresh =
    let create
        (
            lastAttemptedAt: DateTime,
            nextRefreshAvailableAt: DateTime option,
            status: BankConnectionsResourceBalanceRefreshStatus
        ) : BankConnectionsResourceBalanceRefresh
        =
        {
          LastAttemptedAt = lastAttemptedAt
          NextRefreshAvailableAt = nextRefreshAvailableAt
          Status = status
        }

type BankConnectionsResourceBalanceApiResourceCashBalance =
    {
        /// The funds available to the account holder. Typically this is the current balance after subtracting any outbound pending transactions and adding any inbound pending transactions.
        /// Each key is a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase.
        /// Each value is a integer amount. A positive amount indicates money owed to the account holder. A negative amount indicates money owed by the account holder.
        Available: Map<string, string list> option
    }

module BankConnectionsResourceBalanceApiResourceCashBalance =
    let create
        (
            available: Map<string, string list> option
        ) : BankConnectionsResourceBalanceApiResourceCashBalance
        =
        {
          Available = available
        }

type BankConnectionsResourceBalanceApiResourceCreditBalance =
    {
        /// The credit that has been used by the account holder.
        /// Each key is a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase.
        /// Each value is a integer amount. A positive amount indicates money owed to the account holder. A negative amount indicates money owed by the account holder.
        Used: Map<string, string list> option
    }

module BankConnectionsResourceBalanceApiResourceCreditBalance =
    let create
        (
            used: Map<string, string list> option
        ) : BankConnectionsResourceBalanceApiResourceCreditBalance
        =
        {
          Used = used
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

module BankConnectionsResourceBalance =
    let create
        (
            asOf: DateTime,
            current: Map<string, string list>,
            ``type``: BankConnectionsResourceBalanceType,
            cash: BankConnectionsResourceBalanceApiResourceCashBalance option,
            credit: BankConnectionsResourceBalanceApiResourceCreditBalance option
        ) : BankConnectionsResourceBalance
        =
        {
          AsOf = asOf
          Current = current
          Type = ``type``
          Cash = cash
          Credit = credit
        }

type BankConnectionsResourceAccountholderAccount'AnyOf =
    | String of string
    | Account of Account

type BankConnectionsResourceAccountholderCustomer'AnyOf =
    | String of string
    | Customer of Customer

[<Struct>]
type BankConnectionsResourceAccountholderType =
    | Account
    | Customer

type BankConnectionsResourceAccountholder =
    {
        /// The ID of the Stripe account that this account belongs to. Only available when `account_holder.type` is `account`.
        Account: BankConnectionsResourceAccountholderAccount'AnyOf option
        /// The ID for an Account representing a customer that this account belongs to. Only available when `account_holder.type` is `customer`.
        Customer: BankConnectionsResourceAccountholderCustomer'AnyOf option
        CustomerAccount: string option
        /// Type of account holder that this account belongs to.
        Type: BankConnectionsResourceAccountholderType
    }

module BankConnectionsResourceAccountholder =
    let create
        (
            ``type``: BankConnectionsResourceAccountholderType,
            account: BankConnectionsResourceAccountholderAccount'AnyOf option,
            customer: BankConnectionsResourceAccountholderCustomer'AnyOf option,
            customerAccount: string option
        ) : BankConnectionsResourceAccountholder
        =
        {
          Type = ``type``
          Account = account
          Customer = customer
          CustomerAccount = customerAccount
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

module BankConnectionsResourceAccountNumberDetails =
    let create
        (
            expectedExpiryDate: DateTime option,
            identifierType: BankConnectionsResourceAccountNumberDetailsIdentifierType,
            status: BankConnectionsResourceAccountNumberDetailsStatus,
            supportedNetworks: string list
        ) : BankConnectionsResourceAccountNumberDetails
        =
        {
          ExpectedExpiryDate = expectedExpiryDate
          IdentifierType = identifierType
          Status = status
          SupportedNetworks = supportedNetworks
        }

