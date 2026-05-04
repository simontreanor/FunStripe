namespace Stripe.FundingInstructions

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type Address =
    {
        /// City, district, suburb, town, or village.
        City: string option
        /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        Country: IsoTypes.IsoCountryCode option
        /// Address line 1, such as the street, PO Box, or company name.
        [<JsonPropertyName("line1")>]
        Line1: string option
        /// Address line 2, such as the apartment, suite, unit, or building.
        [<JsonPropertyName("line2")>]
        Line2: string option
        /// ZIP or postal code.
        PostalCode: string option
        /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
        State: string option
    }

type Address with
    static member New(city: string option, country: IsoTypes.IsoCountryCode option, line1: string option, line2: string option, postalCode: string option, state: string option) =
        {
            City = city
            Country = country
            Line1 = line1
            Line2 = line2
            PostalCode = postalCode
            State = state
        }

/// ABA Records contain U.S. bank account details per the ABA format.
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

type FundingInstructionsBankTransferAbaRecord with
    static member New(accountHolderAddress: Address, accountHolderName: string, accountNumber: string, accountType: string, bankAddress: Address, bankName: string, routingNumber: string) =
        {
            AccountHolderAddress = accountHolderAddress
            AccountHolderName = accountHolderName
            AccountNumber = accountNumber
            AccountType = accountType
            BankAddress = bankAddress
            BankName = bankName
            RoutingNumber = routingNumber
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

type FundingInstructionsBankTransferIbanRecord with
    static member New(accountHolderAddress: Address, accountHolderName: string, bankAddress: Address, bic: string, country: IsoTypes.IsoCountryCode, iban: string) =
        {
            AccountHolderAddress = accountHolderAddress
            AccountHolderName = accountHolderName
            BankAddress = bankAddress
            Bic = bic
            Country = country
            Iban = iban
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

type FundingInstructionsBankTransferSortCodeRecord with
    static member New(accountHolderAddress: Address, accountHolderName: string, accountNumber: string, bankAddress: Address, sortCode: string) =
        {
            AccountHolderAddress = accountHolderAddress
            AccountHolderName = accountHolderName
            AccountNumber = accountNumber
            BankAddress = bankAddress
            SortCode = sortCode
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

type FundingInstructionsBankTransferSpeiRecord with
    static member New(accountHolderAddress: Address, accountHolderName: string, bankAddress: Address, bankCode: string, bankName: string, clabe: string) =
        {
            AccountHolderAddress = accountHolderAddress
            AccountHolderName = accountHolderName
            BankAddress = bankAddress
            BankCode = bankCode
            BankName = bankName
            Clabe = clabe
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

type FundingInstructionsBankTransferSwiftRecord with
    static member New(accountHolderAddress: Address, accountHolderName: string, accountNumber: string, accountType: string, bankAddress: Address, bankName: string, swiftCode: string) =
        {
            AccountHolderAddress = accountHolderAddress
            AccountHolderName = accountHolderName
            AccountNumber = accountNumber
            AccountType = accountType
            BankAddress = bankAddress
            BankName = bankName
            SwiftCode = swiftCode
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

type FundingInstructionsBankTransferZenginRecord with
    static member New(accountHolderAddress: Address, accountHolderName: string option, accountNumber: string option, accountType: FundingInstructionsBankTransferZenginRecordAccountType option, bankAddress: Address, bankCode: string option, bankName: string option, branchCode: string option, branchName: string option) =
        {
            AccountHolderAddress = accountHolderAddress
            AccountHolderName = accountHolderName
            AccountNumber = accountNumber
            AccountType = accountType
            BankAddress = bankAddress
            BankCode = bankCode
            BankName = bankName
            BranchCode = branchCode
            BranchName = branchName
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

type FundingInstructionsBankTransferFinancialAddress with
    static member New(``type``: FundingInstructionsBankTransferFinancialAddressType, ?aba: FundingInstructionsBankTransferAbaRecord, ?iban: FundingInstructionsBankTransferIbanRecord, ?sortCode: FundingInstructionsBankTransferSortCodeRecord, ?spei: FundingInstructionsBankTransferSpeiRecord, ?supportedNetworks: FundingInstructionsBankTransferFinancialAddressSupportedNetworks list, ?swift: FundingInstructionsBankTransferSwiftRecord, ?zengin: FundingInstructionsBankTransferZenginRecord) =
        {
            Type = ``type``
            Aba = aba
            Iban = iban
            SortCode = sortCode
            Spei = spei
            SupportedNetworks = supportedNetworks
            Swift = swift
            Zengin = zengin
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

type FundingInstructionsBankTransfer with
    static member New(country: IsoTypes.IsoCountryCode, financialAddresses: FundingInstructionsBankTransferFinancialAddress list, ``type``: FundingInstructionsBankTransferType) =
        {
            Country = country
            FinancialAddresses = financialAddresses
            Type = ``type``
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

type FundingInstructions with
    static member New(bankTransfer: FundingInstructionsBankTransfer, currency: IsoTypes.IsoCurrencyCode, livemode: bool) =
        {
            BankTransfer = bankTransfer
            Currency = currency
            Livemode = livemode
        }

module FundingInstructions =
    ///The `funding_type` of the returned instructions
    let fundingType = "bank_transfer"

    ///String representing the object's type. Objects of the same type share the same value.
    let object = "funding_instructions"

