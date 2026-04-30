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

