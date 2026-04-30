namespace Stripe.Funding

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Address

/// ABA Records contain U.S. bank account details per the ABA format.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type FundingInstructionsBankTransferAbaRecord =
    {
        AccountHolderAddress: Address
        /// The account holder name
        AccountHolderName: string
        /// The ABA account number
        AccountNumber: string
        /// The account type
        AccountType: string
        BankAddress: Address
        /// The bank name
        BankName: string
        /// The ABA routing number
        RoutingNumber: string
    }

type FundingInstructionsBankTransferFinancialAddressSupportedNetworks =
    | Ach
    | Bacs
    | DomesticWireUs
    | Fps
    | Sepa
    | Spei
    | Swift
    | Zengin

type FundingInstructionsBankTransferFinancialAddressType =
    | Aba
    | Iban
    | SortCode
    | Spei
    | Swift
    | Zengin

/// Iban Records contain E.U. bank account details per the SEPA format.
type FundingInstructionsBankTransferIbanRecord =
    {
        AccountHolderAddress: Address
        /// The name of the person or business that owns the bank account
        AccountHolderName: string
        BankAddress: Address
        /// The BIC/SWIFT code of the account.
        Bic: string
        /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        Country: IsoTypes.IsoCountryCode
        /// The IBAN of the account.
        Iban: string
    }

/// Sort Code Records contain U.K. bank account details per the sort code format.
type FundingInstructionsBankTransferSortCodeRecord =
    {
        AccountHolderAddress: Address
        /// The name of the person or business that owns the bank account
        AccountHolderName: string
        /// The account number
        AccountNumber: string
        BankAddress: Address
        /// The six-digit sort code
        SortCode: string
    }

/// SPEI Records contain Mexico bank account details per the SPEI format.
type FundingInstructionsBankTransferSpeiRecord =
    {
        AccountHolderAddress: Address
        /// The account holder name
        AccountHolderName: string
        BankAddress: Address
        /// The three-digit bank code
        BankCode: string
        /// The short banking institution name
        BankName: string
        /// The CLABE number
        Clabe: string
    }

/// SWIFT Records contain U.S. bank account details per the SWIFT format.
type FundingInstructionsBankTransferSwiftRecord =
    {
        AccountHolderAddress: Address
        /// The account holder name
        AccountHolderName: string
        /// The account number
        AccountNumber: string
        /// The account type
        AccountType: string
        BankAddress: Address
        /// The bank name
        BankName: string
        /// The SWIFT code
        SwiftCode: string
    }

[<Struct>]
type FundingInstructionsBankTransferZenginRecordAccountType =
    | Futsu
    | Toza

/// Zengin Records contain Japan bank account details per the Zengin format.
type FundingInstructionsBankTransferZenginRecord =
    {
        AccountHolderAddress: Address
        /// The account holder name
        AccountHolderName: string option
        /// The account number
        AccountNumber: string option
        /// The bank account type. In Japan, this can only be `futsu` or `toza`.
        AccountType: FundingInstructionsBankTransferZenginRecordAccountType option
        BankAddress: Address
        /// The bank code of the account
        BankCode: string option
        /// The bank name of the account
        BankName: string option
        /// The branch code of the account
        BranchCode: string option
        /// The branch name of the account
        BranchName: string option
    }

/// FinancialAddresses contain identifying information that resolves to a FinancialAccount.
type FundingInstructionsBankTransferFinancialAddress =
    {
        Aba: FundingInstructionsBankTransferAbaRecord option
        Iban: FundingInstructionsBankTransferIbanRecord option
        SortCode: FundingInstructionsBankTransferSortCodeRecord option
        Spei: FundingInstructionsBankTransferSpeiRecord option
        /// The payment networks supported by this FinancialAddress
        SupportedNetworks: FundingInstructionsBankTransferFinancialAddressSupportedNetworks list option
        Swift: FundingInstructionsBankTransferSwiftRecord option
        /// The type of financial address
        Type: FundingInstructionsBankTransferFinancialAddressType
        Zengin: FundingInstructionsBankTransferZenginRecord option
    }

[<Struct>]
type FundingInstructionsBankTransferType =
    | EuBankTransfer
    | JpBankTransfer

type FundingInstructionsBankTransfer =
    {
        /// The country of the bank account to fund
        Country: IsoTypes.IsoCountryCode
        /// A list of financial addresses that can be used to fund a particular balance
        FinancialAddresses: FundingInstructionsBankTransferFinancialAddress list
        /// The bank_transfer type
        Type: FundingInstructionsBankTransferType
    }

/// Each customer has a [`balance`](https://docs.stripe.com/api/customers/object#customer_object-balance) that is
/// automatically applied to future invoices and payments using the `customer_balance` payment method.
/// Customers can fund this balance by initiating a bank transfer to any account in the
/// `financial_addresses` field.
/// Related guide: [Customer balance funding instructions](https://docs.stripe.com/payments/customer-balance/funding-instructions)
type FundingInstructions =
    {
        BankTransfer: FundingInstructionsBankTransfer
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
    }

module FundingInstructions =
    ///The `funding_type` of the returned instructions
    let fundingType = "bank_transfer"

    ///String representing the object's type. Objects of the same type share the same value.
    let object = "funding_instructions"

