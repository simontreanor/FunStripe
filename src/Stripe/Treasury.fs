namespace Stripe.Treasury

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.FundingInstructions
open Stripe.PaymentMethod

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type InboundTransfersPaymentMethodDetailsUsBankAccountAccountHolderType =
    | Company
    | Individual

[<Struct>]
type InboundTransfersPaymentMethodDetailsUsBankAccountAccountType =
    | Checking
    | Savings

type InboundTransfersPaymentMethodDetailsUsBankAccount =
    {
        /// Account holder type: individual or company.
        AccountHolderType: InboundTransfersPaymentMethodDetailsUsBankAccountAccountHolderType option
        /// Account type: checkings or savings. Defaults to checking if omitted.
        AccountType: InboundTransfersPaymentMethodDetailsUsBankAccountAccountType option
        /// Name of the bank associated with the bank account.
        BankName: string option
        /// Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        /// Last four digits of the bank account number.
        [<JsonPropertyName("last4")>]
        Last4: string option
        /// ID of the mandate used to make this payment.
        Mandate: StripeId<Markers.Mandate> option
        /// Routing number of the bank account.
        RoutingNumber: string option
    }

type InboundTransfersPaymentMethodDetailsUsBankAccount with
    static member New(accountHolderType: InboundTransfersPaymentMethodDetailsUsBankAccountAccountHolderType option, accountType: InboundTransfersPaymentMethodDetailsUsBankAccountAccountType option, bankName: string option, fingerprint: string option, last4: string option, routingNumber: string option, ?mandate: StripeId<Markers.Mandate>) =
        {
            AccountHolderType = accountHolderType
            AccountType = accountType
            BankName = bankName
            Fingerprint = fingerprint
            Last4 = last4
            RoutingNumber = routingNumber
            Mandate = mandate
        }

module InboundTransfersPaymentMethodDetailsUsBankAccount =
    ///The network rails used. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.
    let network = "ach"

type TreasurySharedResourceBillingDetails =
    {
        Address: Address
        /// Email address.
        Email: string option
        /// Full name.
        Name: string option
    }

type TreasurySharedResourceBillingDetails with
    static member New(address: Address, email: string option, name: string option) =
        {
            Address = address
            Email = email
            Name = name
        }

type InboundTransfers =
    { BillingDetails: TreasurySharedResourceBillingDetails
      UsBankAccount: InboundTransfersPaymentMethodDetailsUsBankAccount option }

type InboundTransfers with
    static member New(billingDetails: TreasurySharedResourceBillingDetails, ?usBankAccount: InboundTransfersPaymentMethodDetailsUsBankAccount) =
        {
            BillingDetails = billingDetails
            UsBankAccount = usBankAccount
        }

module InboundTransfers =
    ///The type of the payment method used in the InboundTransfer.
    let ``type`` = "us_bank_account"

type OutboundPaymentsPaymentMethodDetailsFinancialAccount =
    {
        /// Token of the FinancialAccount.
        Id: string
    }

type OutboundPaymentsPaymentMethodDetailsFinancialAccount with
    static member New(id: string) =
        {
            Id = id
        }

module OutboundPaymentsPaymentMethodDetailsFinancialAccount =
    ///The rails used to send funds.
    let network = "stripe"

[<Struct>]
type OutboundPaymentsPaymentMethodDetailsType =
    | FinancialAccount
    | UsBankAccount

[<Struct>]
type OutboundPaymentsPaymentMethodDetailsUsBankAccountAccountHolderType =
    | Company
    | Individual

[<Struct>]
type OutboundPaymentsPaymentMethodDetailsUsBankAccountAccountType =
    | Checking
    | Savings

[<Struct>]
type OutboundPaymentsPaymentMethodDetailsUsBankAccountNetwork =
    | Ach
    | UsDomesticWire

type OutboundPaymentsPaymentMethodDetailsUsBankAccount =
    {
        /// Account holder type: individual or company.
        AccountHolderType: OutboundPaymentsPaymentMethodDetailsUsBankAccountAccountHolderType option
        /// Account type: checkings or savings. Defaults to checking if omitted.
        AccountType: OutboundPaymentsPaymentMethodDetailsUsBankAccountAccountType option
        /// Name of the bank associated with the bank account.
        BankName: string option
        /// Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        /// Last four digits of the bank account number.
        [<JsonPropertyName("last4")>]
        Last4: string option
        /// ID of the mandate used to make this payment.
        Mandate: StripeId<Markers.Mandate> option
        /// The network rails used. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.
        Network: OutboundPaymentsPaymentMethodDetailsUsBankAccountNetwork
        /// Routing number of the bank account.
        RoutingNumber: string option
    }

type OutboundPaymentsPaymentMethodDetailsUsBankAccount with
    static member New(accountHolderType: OutboundPaymentsPaymentMethodDetailsUsBankAccountAccountHolderType option, accountType: OutboundPaymentsPaymentMethodDetailsUsBankAccountAccountType option, bankName: string option, fingerprint: string option, last4: string option, network: OutboundPaymentsPaymentMethodDetailsUsBankAccountNetwork, routingNumber: string option, ?mandate: StripeId<Markers.Mandate>) =
        {
            AccountHolderType = accountHolderType
            AccountType = accountType
            BankName = bankName
            Fingerprint = fingerprint
            Last4 = last4
            Network = network
            RoutingNumber = routingNumber
            Mandate = mandate
        }

type OutboundPaymentsPaymentMethodDetails =
    {
        BillingDetails: TreasurySharedResourceBillingDetails
        FinancialAccount: OutboundPaymentsPaymentMethodDetailsFinancialAccount option
        /// The type of the payment method used in the OutboundPayment.
        Type: OutboundPaymentsPaymentMethodDetailsType
        UsBankAccount: OutboundPaymentsPaymentMethodDetailsUsBankAccount option
    }

type OutboundPaymentsPaymentMethodDetails with
    static member New(billingDetails: TreasurySharedResourceBillingDetails, ``type``: OutboundPaymentsPaymentMethodDetailsType, ?financialAccount: OutboundPaymentsPaymentMethodDetailsFinancialAccount, ?usBankAccount: OutboundPaymentsPaymentMethodDetailsUsBankAccount) =
        {
            BillingDetails = billingDetails
            Type = ``type``
            FinancialAccount = financialAccount
            UsBankAccount = usBankAccount
        }

type OutboundTransfersPaymentMethodDetailsFinancialAccount =
    {
        /// Token of the FinancialAccount.
        Id: string
    }

type OutboundTransfersPaymentMethodDetailsFinancialAccount with
    static member New(id: string) =
        {
            Id = id
        }

module OutboundTransfersPaymentMethodDetailsFinancialAccount =
    ///The rails used to send funds.
    let network = "stripe"

[<Struct>]
type OutboundTransfersPaymentMethodDetailsType =
    | FinancialAccount
    | UsBankAccount

[<Struct>]
type OutboundTransfersPaymentMethodDetailsUsBankAccountAccountHolderType =
    | Company
    | Individual

[<Struct>]
type OutboundTransfersPaymentMethodDetailsUsBankAccountAccountType =
    | Checking
    | Savings

[<Struct>]
type OutboundTransfersPaymentMethodDetailsUsBankAccountNetwork =
    | Ach
    | UsDomesticWire

type OutboundTransfersPaymentMethodDetailsUsBankAccount =
    {
        /// Account holder type: individual or company.
        AccountHolderType: OutboundTransfersPaymentMethodDetailsUsBankAccountAccountHolderType option
        /// Account type: checkings or savings. Defaults to checking if omitted.
        AccountType: OutboundTransfersPaymentMethodDetailsUsBankAccountAccountType option
        /// Name of the bank associated with the bank account.
        BankName: string option
        /// Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        /// Last four digits of the bank account number.
        [<JsonPropertyName("last4")>]
        Last4: string option
        /// ID of the mandate used to make this payment.
        Mandate: StripeId<Markers.Mandate> option
        /// The network rails used. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.
        Network: OutboundTransfersPaymentMethodDetailsUsBankAccountNetwork
        /// Routing number of the bank account.
        RoutingNumber: string option
    }

type OutboundTransfersPaymentMethodDetailsUsBankAccount with
    static member New(accountHolderType: OutboundTransfersPaymentMethodDetailsUsBankAccountAccountHolderType option, accountType: OutboundTransfersPaymentMethodDetailsUsBankAccountAccountType option, bankName: string option, fingerprint: string option, last4: string option, network: OutboundTransfersPaymentMethodDetailsUsBankAccountNetwork, routingNumber: string option, ?mandate: StripeId<Markers.Mandate>) =
        {
            AccountHolderType = accountHolderType
            AccountType = accountType
            BankName = bankName
            Fingerprint = fingerprint
            Last4 = last4
            Network = network
            RoutingNumber = routingNumber
            Mandate = mandate
        }

type OutboundTransfersPaymentMethodDetails =
    {
        BillingDetails: TreasurySharedResourceBillingDetails
        FinancialAccount: OutboundTransfersPaymentMethodDetailsFinancialAccount option
        /// The type of the payment method used in the OutboundTransfer.
        Type: OutboundTransfersPaymentMethodDetailsType
        UsBankAccount: OutboundTransfersPaymentMethodDetailsUsBankAccount option
    }

type OutboundTransfersPaymentMethodDetails with
    static member New(billingDetails: TreasurySharedResourceBillingDetails, ``type``: OutboundTransfersPaymentMethodDetailsType, ?financialAccount: OutboundTransfersPaymentMethodDetailsFinancialAccount, ?usBankAccount: OutboundTransfersPaymentMethodDetailsUsBankAccount) =
        {
            BillingDetails = billingDetails
            Type = ``type``
            FinancialAccount = financialAccount
            UsBankAccount = usBankAccount
        }

type ReceivedPaymentMethodDetailsFinancialAccount =
    {
        /// The FinancialAccount ID.
        Id: string
    }

type ReceivedPaymentMethodDetailsFinancialAccount with
    static member New(id: string) =
        {
            Id = id
        }

module ReceivedPaymentMethodDetailsFinancialAccount =
    ///The rails the ReceivedCredit was sent over. A FinancialAccount can only send funds over `stripe`.
    let network = "stripe"

[<Struct>]
type TreasuryCreditReversalNetwork =
    | Ach
    | Stripe

[<Struct>]
type TreasuryCreditReversalStatus =
    | Canceled
    | Posted
    | Processing

type TreasuryReceivedCreditsResourceStatusTransitions =
    {
        /// Timestamp describing when the CreditReversal changed status to `posted`
        PostedAt: DateTime option
    }

type TreasuryReceivedCreditsResourceStatusTransitions with
    static member New(postedAt: DateTime option) =
        {
            PostedAt = postedAt
        }

/// You can reverse some [ReceivedCredits](https://api.stripe.com#received_credits) depending on their network and source flow. Reversing a ReceivedCredit leads to the creation of a new object known as a CreditReversal.
type TreasuryCreditReversal =
    {
        /// Amount (in cents) transferred.
        Amount: int
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// The FinancialAccount to reverse funds from.
        FinancialAccount: string
        /// A [hosted transaction receipt](https://docs.stripe.com/treasury/moving-money/regulatory-receipts) URL that is provided when money movement is considered regulated under Stripe's money transmission licenses.
        HostedRegulatoryReceiptUrl: string option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// The rails used to reverse the funds.
        Network: TreasuryCreditReversalNetwork
        /// The ReceivedCredit being reversed.
        ReceivedCredit: string
        /// Status of the CreditReversal
        Status: TreasuryCreditReversalStatus
        StatusTransitions: TreasuryReceivedCreditsResourceStatusTransitions
        /// The Transaction associated with this object.
        Transaction: StripeId<Markers.TreasuryTransaction> option
    }

type TreasuryCreditReversal with
    static member New(amount: int, created: DateTime, currency: IsoTypes.IsoCurrencyCode, financialAccount: string, hostedRegulatoryReceiptUrl: string option, id: string, livemode: bool, metadata: Map<string, string>, network: TreasuryCreditReversalNetwork, receivedCredit: string, status: TreasuryCreditReversalStatus, statusTransitions: TreasuryReceivedCreditsResourceStatusTransitions, transaction: StripeId<Markers.TreasuryTransaction> option) =
        {
            Amount = amount
            Created = created
            Currency = currency
            FinancialAccount = financialAccount
            HostedRegulatoryReceiptUrl = hostedRegulatoryReceiptUrl
            Id = id
            Livemode = livemode
            Metadata = metadata
            Network = network
            ReceivedCredit = receivedCredit
            Status = status
            StatusTransitions = statusTransitions
            Transaction = transaction
        }

module TreasuryCreditReversal =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.credit_reversal"

/// Occurs whenever an CreditReversal is submitted and created.
type TreasuryCreditReversalCreated = { Object: TreasuryCreditReversal }

type TreasuryCreditReversalCreated with
    static member New(object: TreasuryCreditReversal) =
        {
            Object = object
        }

/// Occurs whenever an CreditReversal post is posted.
type TreasuryCreditReversalPosted = { Object: TreasuryCreditReversal }

type TreasuryCreditReversalPosted with
    static member New(object: TreasuryCreditReversal) =
        {
            Object = object
        }

[<Struct>]
type TreasuryDebitReversalNetwork =
    | Ach
    | Card

[<Struct>]
type TreasuryDebitReversalStatus =
    | Failed
    | Processing
    | Succeeded

type TreasuryReceivedDebitsResourceDebitReversalLinkedFlows =
    {
        /// Set if there is an Issuing dispute associated with the DebitReversal.
        IssuingDispute: string option
    }

type TreasuryReceivedDebitsResourceDebitReversalLinkedFlows with
    static member New(issuingDispute: string option) =
        {
            IssuingDispute = issuingDispute
        }

type TreasuryReceivedDebitsResourceStatusTransitions =
    {
        /// Timestamp describing when the DebitReversal changed status to `completed`.
        CompletedAt: DateTime option
    }

type TreasuryReceivedDebitsResourceStatusTransitions with
    static member New(completedAt: DateTime option) =
        {
            CompletedAt = completedAt
        }

/// You can reverse some [ReceivedDebits](https://api.stripe.com#received_debits) depending on their network and source flow. Reversing a ReceivedDebit leads to the creation of a new object known as a DebitReversal.
type TreasuryDebitReversal =
    {
        /// Amount (in cents) transferred.
        Amount: int
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// The FinancialAccount to reverse funds from.
        FinancialAccount: string option
        /// A [hosted transaction receipt](https://docs.stripe.com/treasury/moving-money/regulatory-receipts) URL that is provided when money movement is considered regulated under Stripe's money transmission licenses.
        HostedRegulatoryReceiptUrl: string option
        /// Unique identifier for the object.
        Id: string
        /// Other flows linked to a DebitReversal.
        LinkedFlows: TreasuryReceivedDebitsResourceDebitReversalLinkedFlows option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// The rails used to reverse the funds.
        Network: TreasuryDebitReversalNetwork
        /// The ReceivedDebit being reversed.
        ReceivedDebit: string
        /// Status of the DebitReversal
        Status: TreasuryDebitReversalStatus
        StatusTransitions: TreasuryReceivedDebitsResourceStatusTransitions
        /// The Transaction associated with this object.
        Transaction: StripeId<Markers.TreasuryTransaction> option
    }

type TreasuryDebitReversal with
    static member New(amount: int, created: DateTime, currency: IsoTypes.IsoCurrencyCode, financialAccount: string option, hostedRegulatoryReceiptUrl: string option, id: string, linkedFlows: TreasuryReceivedDebitsResourceDebitReversalLinkedFlows option, livemode: bool, metadata: Map<string, string>, network: TreasuryDebitReversalNetwork, receivedDebit: string, status: TreasuryDebitReversalStatus, statusTransitions: TreasuryReceivedDebitsResourceStatusTransitions, transaction: StripeId<Markers.TreasuryTransaction> option) =
        {
            Amount = amount
            Created = created
            Currency = currency
            FinancialAccount = financialAccount
            HostedRegulatoryReceiptUrl = hostedRegulatoryReceiptUrl
            Id = id
            LinkedFlows = linkedFlows
            Livemode = livemode
            Metadata = metadata
            Network = network
            ReceivedDebit = receivedDebit
            Status = status
            StatusTransitions = statusTransitions
            Transaction = transaction
        }

module TreasuryDebitReversal =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.debit_reversal"

/// Occurs whenever a DebitReversal is completed.
type TreasuryDebitReversalCompleted = { Object: TreasuryDebitReversal }

type TreasuryDebitReversalCompleted with
    static member New(object: TreasuryDebitReversal) =
        {
            Object = object
        }

/// Occurs whenever a DebitReversal is created.
type TreasuryDebitReversalCreated = { Object: TreasuryDebitReversal }

type TreasuryDebitReversalCreated with
    static member New(object: TreasuryDebitReversal) =
        {
            Object = object
        }

/// Occurs whenever an initial credit is granted on a DebitReversal.
type TreasuryDebitReversalInitialCreditGranted = { Object: TreasuryDebitReversal }

type TreasuryDebitReversalInitialCreditGranted with
    static member New(object: TreasuryDebitReversal) =
        {
            Object = object
        }

type TreasuryFinancialAccountActiveFeatures =
    | CardIssuing
    | DepositInsurance
    | [<JsonPropertyName("financial_addresses.aba")>] FinancialAddressesAba
    | [<JsonPropertyName("financial_addresses.aba.forwarding")>] FinancialAddressesAbaForwarding
    | [<JsonPropertyName("inbound_transfers.ach")>] InboundTransfersAch
    | IntraStripeFlows
    | [<JsonPropertyName("outbound_payments.ach")>] OutboundPaymentsAch
    | [<JsonPropertyName("outbound_payments.us_domestic_wire")>] OutboundPaymentsUsDomesticWire
    | [<JsonPropertyName("outbound_transfers.ach")>] OutboundTransfersAch
    | [<JsonPropertyName("outbound_transfers.us_domestic_wire")>] OutboundTransfersUsDomesticWire
    | RemoteDepositCapture

[<Struct>]
type TreasuryFinancialAccountsResourceAbaToggleSettingsStatus =
    | Active
    | Pending
    | Restricted

type TreasuryFinancialAccountsResourceTogglesSettingStatusDetailsCode =
    | Activating
    | CapabilityNotRequested
    | FinancialAccountClosed
    | RejectedOther
    | RejectedUnsupportedBusiness
    | RequirementsPastDue
    | RequirementsPendingVerification
    | RestrictedByPlatform
    | RestrictedOther

[<Struct>]
type TreasuryFinancialAccountsResourceTogglesSettingStatusDetailsResolution =
    | ContactStripe
    | ProvideInformation
    | RemoveRestriction

[<Struct>]
type TreasuryFinancialAccountsResourceTogglesSettingStatusDetailsRestriction =
    | InboundFlows
    | OutboundFlows

/// Additional details on the FinancialAccount Features information.
type TreasuryFinancialAccountsResourceTogglesSettingStatusDetails =
    {
        /// Represents the reason why the status is `pending` or `restricted`.
        Code: TreasuryFinancialAccountsResourceTogglesSettingStatusDetailsCode
        /// Represents what the user should do, if anything, to activate the Feature.
        Resolution: TreasuryFinancialAccountsResourceTogglesSettingStatusDetailsResolution option
        /// The `platform_restrictions` that are restricting this Feature.
        Restriction: TreasuryFinancialAccountsResourceTogglesSettingStatusDetailsRestriction option
    }

type TreasuryFinancialAccountsResourceTogglesSettingStatusDetails with
    static member New(code: TreasuryFinancialAccountsResourceTogglesSettingStatusDetailsCode, resolution: TreasuryFinancialAccountsResourceTogglesSettingStatusDetailsResolution option, ?restriction: TreasuryFinancialAccountsResourceTogglesSettingStatusDetailsRestriction) =
        {
            Code = code
            Resolution = resolution
            Restriction = restriction
        }

/// Toggle settings for enabling/disabling the ABA address feature
type TreasuryFinancialAccountsResourceAbaToggleSettings =
    {
        /// Whether the FinancialAccount should have the Feature.
        Requested: bool
        /// Whether the Feature is operational.
        Status: TreasuryFinancialAccountsResourceAbaToggleSettingsStatus
        /// Additional details; includes at least one entry when the status is not `active`.
        StatusDetails: TreasuryFinancialAccountsResourceTogglesSettingStatusDetails list
    }

type TreasuryFinancialAccountsResourceAbaToggleSettings with
    static member New(requested: bool, status: TreasuryFinancialAccountsResourceAbaToggleSettingsStatus, statusDetails: TreasuryFinancialAccountsResourceTogglesSettingStatusDetails list) =
        {
            Requested = requested
            Status = status
            StatusDetails = statusDetails
        }

/// Settings related to Financial Addresses features on a Financial Account
type TreasuryFinancialAccountsResourceFinancialAddressesFeatures =
    { Aba: TreasuryFinancialAccountsResourceAbaToggleSettings option }

type TreasuryFinancialAccountsResourceFinancialAddressesFeatures with
    static member New(?aba: TreasuryFinancialAccountsResourceAbaToggleSettings) =
        {
            Aba = aba
        }

[<Struct>]
type TreasuryFinancialAccountsResourceInboundAchToggleSettingsStatus =
    | Active
    | Pending
    | Restricted

/// Toggle settings for enabling/disabling an inbound ACH specific feature
type TreasuryFinancialAccountsResourceInboundAchToggleSettings =
    {
        /// Whether the FinancialAccount should have the Feature.
        Requested: bool
        /// Whether the Feature is operational.
        Status: TreasuryFinancialAccountsResourceInboundAchToggleSettingsStatus
        /// Additional details; includes at least one entry when the status is not `active`.
        StatusDetails: TreasuryFinancialAccountsResourceTogglesSettingStatusDetails list
    }

type TreasuryFinancialAccountsResourceInboundAchToggleSettings with
    static member New(requested: bool, status: TreasuryFinancialAccountsResourceInboundAchToggleSettingsStatus, statusDetails: TreasuryFinancialAccountsResourceTogglesSettingStatusDetails list) =
        {
            Requested = requested
            Status = status
            StatusDetails = statusDetails
        }

/// InboundTransfers contains inbound transfers features for a FinancialAccount.
type TreasuryFinancialAccountsResourceInboundTransfers =
    { Ach: TreasuryFinancialAccountsResourceInboundAchToggleSettings option }

type TreasuryFinancialAccountsResourceInboundTransfers with
    static member New(?ach: TreasuryFinancialAccountsResourceInboundAchToggleSettings) =
        {
            Ach = ach
        }

[<Struct>]
type TreasuryFinancialAccountsResourceOutboundAchToggleSettingsStatus =
    | Active
    | Pending
    | Restricted

/// Toggle settings for enabling/disabling an outbound ACH specific feature
type TreasuryFinancialAccountsResourceOutboundAchToggleSettings =
    {
        /// Whether the FinancialAccount should have the Feature.
        Requested: bool
        /// Whether the Feature is operational.
        Status: TreasuryFinancialAccountsResourceOutboundAchToggleSettingsStatus
        /// Additional details; includes at least one entry when the status is not `active`.
        StatusDetails: TreasuryFinancialAccountsResourceTogglesSettingStatusDetails list
    }

type TreasuryFinancialAccountsResourceOutboundAchToggleSettings with
    static member New(requested: bool, status: TreasuryFinancialAccountsResourceOutboundAchToggleSettingsStatus, statusDetails: TreasuryFinancialAccountsResourceTogglesSettingStatusDetails list) =
        {
            Requested = requested
            Status = status
            StatusDetails = statusDetails
        }

[<Struct>]
type TreasuryFinancialAccountsResourceToggleSettingsStatus =
    | Active
    | Pending
    | Restricted

/// Toggle settings for enabling/disabling a feature
type TreasuryFinancialAccountsResourceToggleSettings =
    {
        /// Whether the FinancialAccount should have the Feature.
        Requested: bool
        /// Whether the Feature is operational.
        Status: TreasuryFinancialAccountsResourceToggleSettingsStatus
        /// Additional details; includes at least one entry when the status is not `active`.
        StatusDetails: TreasuryFinancialAccountsResourceTogglesSettingStatusDetails list
    }

type TreasuryFinancialAccountsResourceToggleSettings with
    static member New(requested: bool, status: TreasuryFinancialAccountsResourceToggleSettingsStatus, statusDetails: TreasuryFinancialAccountsResourceTogglesSettingStatusDetails list) =
        {
            Requested = requested
            Status = status
            StatusDetails = statusDetails
        }

/// Settings related to Outbound Payments features on a Financial Account
type TreasuryFinancialAccountsResourceOutboundPayments =
    { Ach: TreasuryFinancialAccountsResourceOutboundAchToggleSettings option
      UsDomesticWire: TreasuryFinancialAccountsResourceToggleSettings option }

type TreasuryFinancialAccountsResourceOutboundPayments with
    static member New(?ach: TreasuryFinancialAccountsResourceOutboundAchToggleSettings, ?usDomesticWire: TreasuryFinancialAccountsResourceToggleSettings) =
        {
            Ach = ach
            UsDomesticWire = usDomesticWire
        }

/// OutboundTransfers contains outbound transfers features for a FinancialAccount.
type TreasuryFinancialAccountsResourceOutboundTransfers =
    { Ach: TreasuryFinancialAccountsResourceOutboundAchToggleSettings option
      UsDomesticWire: TreasuryFinancialAccountsResourceToggleSettings option }

type TreasuryFinancialAccountsResourceOutboundTransfers with
    static member New(?ach: TreasuryFinancialAccountsResourceOutboundAchToggleSettings, ?usDomesticWire: TreasuryFinancialAccountsResourceToggleSettings) =
        {
            Ach = ach
            UsDomesticWire = usDomesticWire
        }

/// Encodes whether a FinancialAccount has access to a particular Feature, with a `status` enum and associated `status_details`.
/// Stripe or the platform can control Features via the requested field.
type TreasuryFinancialAccountFeatures =
    { CardIssuing: TreasuryFinancialAccountsResourceToggleSettings option
      DepositInsurance: TreasuryFinancialAccountsResourceToggleSettings option
      FinancialAddresses: TreasuryFinancialAccountsResourceFinancialAddressesFeatures option
      InboundTransfers: TreasuryFinancialAccountsResourceInboundTransfers option
      IntraStripeFlows: TreasuryFinancialAccountsResourceToggleSettings option
      OutboundPayments: TreasuryFinancialAccountsResourceOutboundPayments option
      OutboundTransfers: TreasuryFinancialAccountsResourceOutboundTransfers option }

type TreasuryFinancialAccountFeatures with
    static member New(?cardIssuing: TreasuryFinancialAccountsResourceToggleSettings, ?depositInsurance: TreasuryFinancialAccountsResourceToggleSettings, ?financialAddresses: TreasuryFinancialAccountsResourceFinancialAddressesFeatures, ?inboundTransfers: TreasuryFinancialAccountsResourceInboundTransfers, ?intraStripeFlows: TreasuryFinancialAccountsResourceToggleSettings, ?outboundPayments: TreasuryFinancialAccountsResourceOutboundPayments, ?outboundTransfers: TreasuryFinancialAccountsResourceOutboundTransfers) =
        {
            CardIssuing = cardIssuing
            DepositInsurance = depositInsurance
            FinancialAddresses = financialAddresses
            InboundTransfers = inboundTransfers
            IntraStripeFlows = intraStripeFlows
            OutboundPayments = outboundPayments
            OutboundTransfers = outboundTransfers
        }

module TreasuryFinancialAccountFeatures =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.financial_account_features"

type TreasuryFinancialAccountPendingFeatures =
    | CardIssuing
    | DepositInsurance
    | [<JsonPropertyName("financial_addresses.aba")>] FinancialAddressesAba
    | [<JsonPropertyName("financial_addresses.aba.forwarding")>] FinancialAddressesAbaForwarding
    | [<JsonPropertyName("inbound_transfers.ach")>] InboundTransfersAch
    | IntraStripeFlows
    | [<JsonPropertyName("outbound_payments.ach")>] OutboundPaymentsAch
    | [<JsonPropertyName("outbound_payments.us_domestic_wire")>] OutboundPaymentsUsDomesticWire
    | [<JsonPropertyName("outbound_transfers.ach")>] OutboundTransfersAch
    | [<JsonPropertyName("outbound_transfers.us_domestic_wire")>] OutboundTransfersUsDomesticWire
    | RemoteDepositCapture

type TreasuryFinancialAccountRestrictedFeatures =
    | CardIssuing
    | DepositInsurance
    | [<JsonPropertyName("financial_addresses.aba")>] FinancialAddressesAba
    | [<JsonPropertyName("financial_addresses.aba.forwarding")>] FinancialAddressesAbaForwarding
    | [<JsonPropertyName("inbound_transfers.ach")>] InboundTransfersAch
    | IntraStripeFlows
    | [<JsonPropertyName("outbound_payments.ach")>] OutboundPaymentsAch
    | [<JsonPropertyName("outbound_payments.us_domestic_wire")>] OutboundPaymentsUsDomesticWire
    | [<JsonPropertyName("outbound_transfers.ach")>] OutboundTransfersAch
    | [<JsonPropertyName("outbound_transfers.us_domestic_wire")>] OutboundTransfersUsDomesticWire
    | RemoteDepositCapture

[<Struct>]
type TreasuryFinancialAccountStatus =
    | Closed
    | Open

/// Balance information for the FinancialAccount
type TreasuryFinancialAccountsResourceBalance =
    {
        /// Funds the user can spend right now.
        Cash: Map<string, string list>
        /// Funds not spendable yet, but will become available at a later time.
        InboundPending: Map<string, string list>
        /// Funds in the account, but not spendable because they are being held for pending outbound flows.
        OutboundPending: Map<string, string list>
    }

type TreasuryFinancialAccountsResourceBalance with
    static member New(cash: Map<string, string list>, inboundPending: Map<string, string list>, outboundPending: Map<string, string list>) =
        {
            Cash = cash
            InboundPending = inboundPending
            OutboundPending = outboundPending
        }

/// ABA Records contain U.S. bank account details per the ABA format.
type TreasuryFinancialAccountsResourceAbaRecord =
    {
        /// The name of the person or business that owns the bank account.
        AccountHolderName: string
        /// The account number.
        AccountNumber: string option
        /// The last four characters of the account number.
        [<JsonPropertyName("account_number_last4")>]
        AccountNumberLast4: string
        /// Name of the bank.
        BankName: string
        /// Routing number for the account.
        RoutingNumber: string
    }

type TreasuryFinancialAccountsResourceAbaRecord with
    static member New(accountHolderName: string, accountNumberLast4: string, bankName: string, routingNumber: string, ?accountNumber: string option) =
        {
            AccountHolderName = accountHolderName
            AccountNumberLast4 = accountNumberLast4
            BankName = bankName
            RoutingNumber = routingNumber
            AccountNumber = accountNumber |> Option.flatten
        }

[<Struct>]
type TreasuryFinancialAccountsResourceFinancialAddressSupportedNetworks =
    | Ach
    | UsDomesticWire

/// FinancialAddresses contain identifying information that resolves to a FinancialAccount.
type TreasuryFinancialAccountsResourceFinancialAddress =
    {
        Aba: TreasuryFinancialAccountsResourceAbaRecord option
        /// The list of networks that the address supports
        SupportedNetworks: TreasuryFinancialAccountsResourceFinancialAddressSupportedNetworks list option
    }

type TreasuryFinancialAccountsResourceFinancialAddress with
    static member New(?aba: TreasuryFinancialAccountsResourceAbaRecord, ?supportedNetworks: TreasuryFinancialAccountsResourceFinancialAddressSupportedNetworks list) =
        {
            Aba = aba
            SupportedNetworks = supportedNetworks
        }

module TreasuryFinancialAccountsResourceFinancialAddress =
    ///The type of financial address
    let ``type`` = "aba"

[<Struct>]
type TreasuryFinancialAccountsResourcePlatformRestrictionsInboundFlows =
    | Restricted
    | Unrestricted

[<Struct>]
type TreasuryFinancialAccountsResourcePlatformRestrictionsOutboundFlows =
    | Restricted
    | Unrestricted

/// Restrictions that a Connect Platform has placed on this FinancialAccount.
type TreasuryFinancialAccountsResourcePlatformRestrictions =
    {
        /// Restricts all inbound money movement.
        InboundFlows: TreasuryFinancialAccountsResourcePlatformRestrictionsInboundFlows option
        /// Restricts all outbound money movement.
        OutboundFlows: TreasuryFinancialAccountsResourcePlatformRestrictionsOutboundFlows option
    }

type TreasuryFinancialAccountsResourcePlatformRestrictions with
    static member New(inboundFlows: TreasuryFinancialAccountsResourcePlatformRestrictionsInboundFlows option, outboundFlows: TreasuryFinancialAccountsResourcePlatformRestrictionsOutboundFlows option) =
        {
            InboundFlows = inboundFlows
            OutboundFlows = outboundFlows
        }

[<Struct>]
type TreasuryFinancialAccountsResourceClosedStatusDetailsReasons =
    | AccountRejected
    | ClosedByPlatform
    | Other

type TreasuryFinancialAccountsResourceClosedStatusDetails =
    {
        /// The array that contains reasons for a FinancialAccount closure.
        Reasons: TreasuryFinancialAccountsResourceClosedStatusDetailsReasons list
    }

type TreasuryFinancialAccountsResourceClosedStatusDetails with
    static member New(reasons: TreasuryFinancialAccountsResourceClosedStatusDetailsReasons list) =
        {
            Reasons = reasons
        }

type TreasuryFinancialAccountsResourceStatusDetails =
    {
        /// Details related to the closure of this FinancialAccount
        Closed: TreasuryFinancialAccountsResourceClosedStatusDetails option
    }

type TreasuryFinancialAccountsResourceStatusDetails with
    static member New(closed: TreasuryFinancialAccountsResourceClosedStatusDetails option) =
        {
            Closed = closed
        }

/// Stripe Treasury provides users with a container for money called a FinancialAccount that is separate from their Payments balance.
/// FinancialAccounts serve as the source and destination of Treasury’s money movement APIs.
type TreasuryFinancialAccount =
    {
        /// The array of paths to active Features in the Features hash.
        ActiveFeatures: TreasuryFinancialAccountActiveFeatures list option
        Balance: TreasuryFinancialAccountsResourceBalance
        /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        Country: IsoTypes.IsoCountryCode
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        Features: TreasuryFinancialAccountFeatures option
        /// The set of credentials that resolve to a FinancialAccount.
        FinancialAddresses: TreasuryFinancialAccountsResourceFinancialAddress list
        /// Unique identifier for the object.
        Id: string
        IsDefault: bool option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The nickname for the FinancialAccount.
        Nickname: string option
        /// The array of paths to pending Features in the Features hash.
        PendingFeatures: TreasuryFinancialAccountPendingFeatures list option
        /// The set of functionalities that the platform can restrict on the FinancialAccount.
        PlatformRestrictions: TreasuryFinancialAccountsResourcePlatformRestrictions option
        /// The array of paths to restricted Features in the Features hash.
        RestrictedFeatures: TreasuryFinancialAccountRestrictedFeatures list option
        /// Status of this FinancialAccount.
        Status: TreasuryFinancialAccountStatus
        StatusDetails: TreasuryFinancialAccountsResourceStatusDetails
        /// The currencies the FinancialAccount can hold a balance in. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase.
        SupportedCurrencies: string list
    }

type TreasuryFinancialAccount with
    static member New(balance: TreasuryFinancialAccountsResourceBalance, country: IsoTypes.IsoCountryCode, created: DateTime, financialAddresses: TreasuryFinancialAccountsResourceFinancialAddress list, id: string, livemode: bool, metadata: Map<string, string> option, status: TreasuryFinancialAccountStatus, statusDetails: TreasuryFinancialAccountsResourceStatusDetails, supportedCurrencies: string list, ?activeFeatures: TreasuryFinancialAccountActiveFeatures list, ?features: TreasuryFinancialAccountFeatures, ?isDefault: bool, ?nickname: string option, ?pendingFeatures: TreasuryFinancialAccountPendingFeatures list, ?platformRestrictions: TreasuryFinancialAccountsResourcePlatformRestrictions option, ?restrictedFeatures: TreasuryFinancialAccountRestrictedFeatures list) =
        {
            Balance = balance
            Country = country
            Created = created
            FinancialAddresses = financialAddresses
            Id = id
            Livemode = livemode
            Metadata = metadata
            Status = status
            StatusDetails = statusDetails
            SupportedCurrencies = supportedCurrencies
            ActiveFeatures = activeFeatures
            Features = features
            IsDefault = isDefault
            Nickname = nickname |> Option.flatten
            PendingFeatures = pendingFeatures
            PlatformRestrictions = platformRestrictions |> Option.flatten
            RestrictedFeatures = restrictedFeatures
        }

module TreasuryFinancialAccount =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.financial_account"

/// Occurs whenever the status of the FinancialAccount becomes closed.
type TreasuryFinancialAccountClosed = { Object: TreasuryFinancialAccount }

type TreasuryFinancialAccountClosed with
    static member New(object: TreasuryFinancialAccount) =
        {
            Object = object
        }

/// Occurs whenever a new FinancialAccount is created.
type TreasuryFinancialAccountCreated = { Object: TreasuryFinancialAccount }

type TreasuryFinancialAccountCreated with
    static member New(object: TreasuryFinancialAccount) =
        {
            Object = object
        }

/// Occurs whenever the statuses of any features within an existing FinancialAccount are updated.
type TreasuryFinancialAccountFeaturesStatusUpdated = { Object: TreasuryFinancialAccount }

type TreasuryFinancialAccountFeaturesStatusUpdated with
    static member New(object: TreasuryFinancialAccount) =
        {
            Object = object
        }

[<Struct>]
type TreasuryInboundTransferStatus =
    | Canceled
    | Failed
    | Processing
    | Succeeded

type TreasuryInboundTransfersResourceFailureDetailsCode =
    | AccountClosed
    | AccountFrozen
    | BankAccountRestricted
    | BankOwnershipChanged
    | DebitNotAuthorized
    | IncorrectAccountHolderAddress
    | IncorrectAccountHolderName
    | IncorrectAccountHolderTaxId
    | InsufficientFunds
    | InvalidAccountNumber
    | InvalidCurrency
    | NoAccount
    | Other

type TreasuryInboundTransfersResourceFailureDetails =
    {
        /// Reason for the failure.
        Code: TreasuryInboundTransfersResourceFailureDetailsCode
    }

type TreasuryInboundTransfersResourceFailureDetails with
    static member New(code: TreasuryInboundTransfersResourceFailureDetailsCode) =
        {
            Code = code
        }

type TreasuryInboundTransfersResourceInboundTransferResourceLinkedFlows =
    {
        /// If funds for this flow were returned after the flow went to the `succeeded` state, this field contains a reference to the ReceivedDebit return.
        ReceivedDebit: string option
    }

type TreasuryInboundTransfersResourceInboundTransferResourceLinkedFlows with
    static member New(receivedDebit: string option) =
        {
            ReceivedDebit = receivedDebit
        }

type TreasuryInboundTransfersResourceInboundTransferResourceStatusTransitions =
    {
        /// Timestamp describing when an InboundTransfer changed status to `canceled`.
        CanceledAt: DateTime option
        /// Timestamp describing when an InboundTransfer changed status to `failed`.
        FailedAt: DateTime option
        /// Timestamp describing when an InboundTransfer changed status to `succeeded`.
        SucceededAt: DateTime option
    }

type TreasuryInboundTransfersResourceInboundTransferResourceStatusTransitions with
    static member New(failedAt: DateTime option, succeededAt: DateTime option, ?canceledAt: DateTime option) =
        {
            FailedAt = failedAt
            SucceededAt = succeededAt
            CanceledAt = canceledAt |> Option.flatten
        }

/// Use [InboundTransfers](https://docs.stripe.com/docs/treasury/moving-money/financial-accounts/into/inbound-transfers) to add funds to your [FinancialAccount](https://api.stripe.com#financial_accounts) via a PaymentMethod that is owned by you. The funds will be transferred via an ACH debit.
/// Related guide: [Moving money with Treasury using InboundTransfer objects](https://docs.stripe.com/docs/treasury/moving-money/financial-accounts/into/inbound-transfers)
type TreasuryInboundTransfer =
    {
        /// Amount (in cents) transferred.
        Amount: int
        /// Returns `true` if the InboundTransfer is able to be canceled.
        Cancelable: bool
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        /// Details about this InboundTransfer's failure. Only set when status is `failed`.
        FailureDetails: TreasuryInboundTransfersResourceFailureDetails option
        /// The FinancialAccount that received the funds.
        FinancialAccount: string
        /// A [hosted transaction receipt](https://docs.stripe.com/treasury/moving-money/regulatory-receipts) URL that is provided when money movement is considered regulated under Stripe's money transmission licenses.
        HostedRegulatoryReceiptUrl: string option
        /// Unique identifier for the object.
        Id: string
        LinkedFlows: TreasuryInboundTransfersResourceInboundTransferResourceLinkedFlows
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// The origin payment method to be debited for an InboundTransfer.
        OriginPaymentMethod: string option
        /// Details about the PaymentMethod for an InboundTransfer.
        OriginPaymentMethodDetails: InboundTransfers option
        /// Returns `true` if the funds for an InboundTransfer were returned after the InboundTransfer went to the `succeeded` state.
        Returned: bool option
        /// Statement descriptor shown when funds are debited from the source. Not all payment networks support `statement_descriptor`.
        StatementDescriptor: string
        /// Status of the InboundTransfer: `processing`, `succeeded`, `failed`, and `canceled`. An InboundTransfer is `processing` if it is created and pending. The status changes to `succeeded` once the funds have been "confirmed" and a `transaction` is created and posted. The status changes to `failed` if the transfer fails.
        Status: TreasuryInboundTransferStatus
        StatusTransitions: TreasuryInboundTransfersResourceInboundTransferResourceStatusTransitions
        /// The Transaction associated with this object.
        Transaction: StripeId<Markers.TreasuryTransaction> option
    }

type TreasuryInboundTransfer with
    static member New(amount: int, cancelable: bool, created: DateTime, currency: IsoTypes.IsoCurrencyCode, description: string option, failureDetails: TreasuryInboundTransfersResourceFailureDetails option, financialAccount: string, hostedRegulatoryReceiptUrl: string option, id: string, linkedFlows: TreasuryInboundTransfersResourceInboundTransferResourceLinkedFlows, livemode: bool, metadata: Map<string, string>, originPaymentMethod: string option, originPaymentMethodDetails: InboundTransfers option, returned: bool option, statementDescriptor: string, status: TreasuryInboundTransferStatus, statusTransitions: TreasuryInboundTransfersResourceInboundTransferResourceStatusTransitions, transaction: StripeId<Markers.TreasuryTransaction> option) =
        {
            Amount = amount
            Cancelable = cancelable
            Created = created
            Currency = currency
            Description = description
            FailureDetails = failureDetails
            FinancialAccount = financialAccount
            HostedRegulatoryReceiptUrl = hostedRegulatoryReceiptUrl
            Id = id
            LinkedFlows = linkedFlows
            Livemode = livemode
            Metadata = metadata
            OriginPaymentMethod = originPaymentMethod
            OriginPaymentMethodDetails = originPaymentMethodDetails
            Returned = returned
            StatementDescriptor = statementDescriptor
            Status = status
            StatusTransitions = statusTransitions
            Transaction = transaction
        }

module TreasuryInboundTransfer =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.inbound_transfer"

/// Occurs whenever an InboundTransfer is canceled.
type TreasuryInboundTransferCanceled = { Object: TreasuryInboundTransfer }

type TreasuryInboundTransferCanceled with
    static member New(object: TreasuryInboundTransfer) =
        {
            Object = object
        }

/// Occurs whenever an InboundTransfer is created.
type TreasuryInboundTransferCreated = { Object: TreasuryInboundTransfer }

type TreasuryInboundTransferCreated with
    static member New(object: TreasuryInboundTransfer) =
        {
            Object = object
        }

/// Occurs whenever an InboundTransfer has failed.
type TreasuryInboundTransferFailed = { Object: TreasuryInboundTransfer }

type TreasuryInboundTransferFailed with
    static member New(object: TreasuryInboundTransfer) =
        {
            Object = object
        }

/// Occurs whenever an InboundTransfer has succeeded.
type TreasuryInboundTransferSucceeded = { Object: TreasuryInboundTransfer }

type TreasuryInboundTransferSucceeded with
    static member New(object: TreasuryInboundTransfer) =
        {
            Object = object
        }

[<Struct>]
type TreasuryOutboundPaymentStatus =
    | Canceled
    | Failed
    | Posted
    | Processing
    | Returned

type TreasuryOutboundPaymentsResourceOutboundPaymentResourceEndUserDetails =
    {
        /// IP address of the user initiating the OutboundPayment. Set if `present` is set to `true`. IP address collection is required for risk and compliance reasons. This will be used to help determine if the OutboundPayment is authorized or should be blocked.
        IpAddress: string option
        /// `true` if the OutboundPayment creation request is being made on behalf of an end user by a platform. Otherwise, `false`.
        Present: bool
    }

type TreasuryOutboundPaymentsResourceOutboundPaymentResourceEndUserDetails with
    static member New(ipAddress: string option, present: bool) =
        {
            IpAddress = ipAddress
            Present = present
        }

type TreasuryOutboundPaymentsResourceOutboundPaymentResourceStatusTransitions =
    {
        /// Timestamp describing when an OutboundPayment changed status to `canceled`.
        CanceledAt: DateTime option
        /// Timestamp describing when an OutboundPayment changed status to `failed`.
        FailedAt: DateTime option
        /// Timestamp describing when an OutboundPayment changed status to `posted`.
        PostedAt: DateTime option
        /// Timestamp describing when an OutboundPayment changed status to `returned`.
        ReturnedAt: DateTime option
    }

type TreasuryOutboundPaymentsResourceOutboundPaymentResourceStatusTransitions with
    static member New(canceledAt: DateTime option, failedAt: DateTime option, postedAt: DateTime option, returnedAt: DateTime option) =
        {
            CanceledAt = canceledAt
            FailedAt = failedAt
            PostedAt = postedAt
            ReturnedAt = returnedAt
        }

type TreasuryOutboundPaymentsResourceAchTrackingDetails =
    {
        /// ACH trace ID of the OutboundPayment for payments sent over the `ach` network.
        TraceId: string
    }

type TreasuryOutboundPaymentsResourceAchTrackingDetails with
    static member New(traceId: string) =
        {
            TraceId = traceId
        }

[<Struct>]
type TreasuryOutboundPaymentsResourceOutboundPaymentResourceTrackingDetailsType =
    | Ach
    | UsDomesticWire

type TreasuryOutboundPaymentsResourceUsDomesticWireTrackingDetails =
    {
        /// CHIPS System Sequence Number (SSN) of the OutboundPayment for payments sent over the `us_domestic_wire` network.
        Chips: string option
        /// IMAD of the OutboundPayment for payments sent over the `us_domestic_wire` network.
        Imad: string option
        /// OMAD of the OutboundPayment for payments sent over the `us_domestic_wire` network.
        Omad: string option
    }

type TreasuryOutboundPaymentsResourceUsDomesticWireTrackingDetails with
    static member New(chips: string option, imad: string option, omad: string option) =
        {
            Chips = chips
            Imad = imad
            Omad = omad
        }

type TreasuryOutboundPaymentsResourceOutboundPaymentResourceTrackingDetails =
    {
        Ach: TreasuryOutboundPaymentsResourceAchTrackingDetails option
        /// The US bank account network used to send funds.
        Type: TreasuryOutboundPaymentsResourceOutboundPaymentResourceTrackingDetailsType
        UsDomesticWire: TreasuryOutboundPaymentsResourceUsDomesticWireTrackingDetails option
    }

type TreasuryOutboundPaymentsResourceOutboundPaymentResourceTrackingDetails with
    static member New(``type``: TreasuryOutboundPaymentsResourceOutboundPaymentResourceTrackingDetailsType, ?ach: TreasuryOutboundPaymentsResourceAchTrackingDetails, ?usDomesticWire: TreasuryOutboundPaymentsResourceUsDomesticWireTrackingDetails) =
        {
            Type = ``type``
            Ach = ach
            UsDomesticWire = usDomesticWire
        }

type TreasuryOutboundPaymentsResourceReturnedStatusCode =
    | AccountClosed
    | AccountFrozen
    | BankAccountRestricted
    | BankOwnershipChanged
    | Declined
    | IncorrectAccountHolderName
    | InvalidAccountNumber
    | InvalidCurrency
    | NoAccount
    | Other

type TreasuryOutboundPaymentsResourceReturnedStatus =
    {
        /// Reason for the return.
        Code: TreasuryOutboundPaymentsResourceReturnedStatusCode
        /// The Transaction associated with this object.
        Transaction: StripeId<Markers.TreasuryTransaction>
    }

type TreasuryOutboundPaymentsResourceReturnedStatus with
    static member New(code: TreasuryOutboundPaymentsResourceReturnedStatusCode, transaction: StripeId<Markers.TreasuryTransaction>) =
        {
            Code = code
            Transaction = transaction
        }

/// Use [OutboundPayments](https://docs.stripe.com/docs/treasury/moving-money/financial-accounts/out-of/outbound-payments) to send funds to another party's external bank account or [FinancialAccount](https://api.stripe.com#financial_accounts). To send money to an account belonging to the same user, use an [OutboundTransfer](https://api.stripe.com#outbound_transfers).
/// Simulate OutboundPayment state changes with the `/v1/test_helpers/treasury/outbound_payments` endpoints. These methods can only be called on test mode objects.
/// Related guide: [Moving money with Treasury using OutboundPayment objects](https://docs.stripe.com/docs/treasury/moving-money/financial-accounts/out-of/outbound-payments)
type TreasuryOutboundPayment =
    {
        /// Amount (in cents) transferred.
        Amount: int
        /// Returns `true` if the object can be canceled, and `false` otherwise.
        Cancelable: bool
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// ID of the [customer](https://docs.stripe.com/api/customers) to whom an OutboundPayment is sent.
        Customer: string option
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        /// The PaymentMethod via which an OutboundPayment is sent. This field can be empty if the OutboundPayment was created using `destination_payment_method_data`.
        DestinationPaymentMethod: string option
        /// Details about the PaymentMethod for an OutboundPayment.
        DestinationPaymentMethodDetails: OutboundPaymentsPaymentMethodDetails option
        /// Details about the end user.
        EndUserDetails: TreasuryOutboundPaymentsResourceOutboundPaymentResourceEndUserDetails option
        /// The date when funds are expected to arrive in the destination account.
        ExpectedArrivalDate: DateTime
        /// The FinancialAccount that funds were pulled from.
        FinancialAccount: string
        /// A [hosted transaction receipt](https://docs.stripe.com/treasury/moving-money/regulatory-receipts) URL that is provided when money movement is considered regulated under Stripe's money transmission licenses.
        HostedRegulatoryReceiptUrl: string option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// Details about a returned OutboundPayment. Only set when the status is `returned`.
        ReturnedDetails: TreasuryOutboundPaymentsResourceReturnedStatus option
        /// The description that appears on the receiving end for an OutboundPayment (for example, bank statement for external bank transfer).
        StatementDescriptor: string
        /// Current status of the OutboundPayment: `processing`, `failed`, `posted`, `returned`, `canceled`. An OutboundPayment is `processing` if it has been created and is pending. The status changes to `posted` once the OutboundPayment has been "confirmed" and funds have left the account, or to `failed` or `canceled`. If an OutboundPayment fails to arrive at its destination, its status will change to `returned`.
        Status: TreasuryOutboundPaymentStatus
        StatusTransitions: TreasuryOutboundPaymentsResourceOutboundPaymentResourceStatusTransitions
        /// Details about network-specific tracking information if available.
        TrackingDetails: TreasuryOutboundPaymentsResourceOutboundPaymentResourceTrackingDetails option
        /// The Transaction associated with this object.
        Transaction: StripeId<Markers.TreasuryTransaction>
    }

type TreasuryOutboundPayment with
    static member New(amount: int, cancelable: bool, created: DateTime, currency: IsoTypes.IsoCurrencyCode, customer: string option, description: string option, destinationPaymentMethod: string option, destinationPaymentMethodDetails: OutboundPaymentsPaymentMethodDetails option, endUserDetails: TreasuryOutboundPaymentsResourceOutboundPaymentResourceEndUserDetails option, expectedArrivalDate: DateTime, financialAccount: string, hostedRegulatoryReceiptUrl: string option, id: string, livemode: bool, metadata: Map<string, string>, returnedDetails: TreasuryOutboundPaymentsResourceReturnedStatus option, statementDescriptor: string, status: TreasuryOutboundPaymentStatus, statusTransitions: TreasuryOutboundPaymentsResourceOutboundPaymentResourceStatusTransitions, trackingDetails: TreasuryOutboundPaymentsResourceOutboundPaymentResourceTrackingDetails option, transaction: StripeId<Markers.TreasuryTransaction>) =
        {
            Amount = amount
            Cancelable = cancelable
            Created = created
            Currency = currency
            Customer = customer
            Description = description
            DestinationPaymentMethod = destinationPaymentMethod
            DestinationPaymentMethodDetails = destinationPaymentMethodDetails
            EndUserDetails = endUserDetails
            ExpectedArrivalDate = expectedArrivalDate
            FinancialAccount = financialAccount
            HostedRegulatoryReceiptUrl = hostedRegulatoryReceiptUrl
            Id = id
            Livemode = livemode
            Metadata = metadata
            ReturnedDetails = returnedDetails
            StatementDescriptor = statementDescriptor
            Status = status
            StatusTransitions = statusTransitions
            TrackingDetails = trackingDetails
            Transaction = transaction
        }

module TreasuryOutboundPayment =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.outbound_payment"

/// Occurs whenever an OutboundPayment is canceled.
type TreasuryOutboundPaymentCanceled = { Object: TreasuryOutboundPayment }

type TreasuryOutboundPaymentCanceled with
    static member New(object: TreasuryOutboundPayment) =
        {
            Object = object
        }

/// Occurs whenever a new OutboundPayment is successfully created.
type TreasuryOutboundPaymentCreated = { Object: TreasuryOutboundPayment }

type TreasuryOutboundPaymentCreated with
    static member New(object: TreasuryOutboundPayment) =
        {
            Object = object
        }

/// Occurs whenever the arrival date on an OutboundPayment updates.
type TreasuryOutboundPaymentExpectedArrivalDateUpdated = { Object: TreasuryOutboundPayment }

type TreasuryOutboundPaymentExpectedArrivalDateUpdated with
    static member New(object: TreasuryOutboundPayment) =
        {
            Object = object
        }

/// Occurs whenever an OutboundPayment fails.
type TreasuryOutboundPaymentFailed = { Object: TreasuryOutboundPayment }

type TreasuryOutboundPaymentFailed with
    static member New(object: TreasuryOutboundPayment) =
        {
            Object = object
        }

/// Occurs whenever an OutboundPayment posts.
type TreasuryOutboundPaymentPosted = { Object: TreasuryOutboundPayment }

type TreasuryOutboundPaymentPosted with
    static member New(object: TreasuryOutboundPayment) =
        {
            Object = object
        }

/// Occurs whenever an OutboundPayment was returned.
type TreasuryOutboundPaymentReturned = { Object: TreasuryOutboundPayment }

type TreasuryOutboundPaymentReturned with
    static member New(object: TreasuryOutboundPayment) =
        {
            Object = object
        }

/// Occurs whenever tracking_details on an OutboundPayment is updated.
type TreasuryOutboundPaymentTrackingDetailsUpdated = { Object: TreasuryOutboundPayment }

type TreasuryOutboundPaymentTrackingDetailsUpdated with
    static member New(object: TreasuryOutboundPayment) =
        {
            Object = object
        }

[<Struct>]
type TreasuryOutboundTransferStatus =
    | Canceled
    | Failed
    | Posted
    | Processing
    | Returned

type TreasuryOutboundTransfersResourceAchTrackingDetails =
    {
        /// ACH trace ID of the OutboundTransfer for transfers sent over the `ach` network.
        TraceId: string
    }

type TreasuryOutboundTransfersResourceAchTrackingDetails with
    static member New(traceId: string) =
        {
            TraceId = traceId
        }

[<Struct>]
type TreasuryOutboundTransfersResourceOutboundTransferResourceTrackingDetailsType =
    | Ach
    | UsDomesticWire

type TreasuryOutboundTransfersResourceUsDomesticWireTrackingDetails =
    {
        /// CHIPS System Sequence Number (SSN) of the OutboundTransfer for transfers sent over the `us_domestic_wire` network.
        Chips: string option
        /// IMAD of the OutboundTransfer for transfers sent over the `us_domestic_wire` network.
        Imad: string option
        /// OMAD of the OutboundTransfer for transfers sent over the `us_domestic_wire` network.
        Omad: string option
    }

type TreasuryOutboundTransfersResourceUsDomesticWireTrackingDetails with
    static member New(chips: string option, imad: string option, omad: string option) =
        {
            Chips = chips
            Imad = imad
            Omad = omad
        }

type TreasuryOutboundTransfersResourceOutboundTransferResourceTrackingDetails =
    {
        Ach: TreasuryOutboundTransfersResourceAchTrackingDetails option
        /// The US bank account network used to send funds.
        Type: TreasuryOutboundTransfersResourceOutboundTransferResourceTrackingDetailsType
        UsDomesticWire: TreasuryOutboundTransfersResourceUsDomesticWireTrackingDetails option
    }

type TreasuryOutboundTransfersResourceOutboundTransferResourceTrackingDetails with
    static member New(``type``: TreasuryOutboundTransfersResourceOutboundTransferResourceTrackingDetailsType, ?ach: TreasuryOutboundTransfersResourceAchTrackingDetails, ?usDomesticWire: TreasuryOutboundTransfersResourceUsDomesticWireTrackingDetails) =
        {
            Type = ``type``
            Ach = ach
            UsDomesticWire = usDomesticWire
        }

type TreasuryOutboundTransfersResourceReturnedDetailsCode =
    | AccountClosed
    | AccountFrozen
    | BankAccountRestricted
    | BankOwnershipChanged
    | Declined
    | IncorrectAccountHolderName
    | InvalidAccountNumber
    | InvalidCurrency
    | NoAccount
    | Other

type TreasuryOutboundTransfersResourceReturnedDetails =
    {
        /// Reason for the return.
        Code: TreasuryOutboundTransfersResourceReturnedDetailsCode
        /// The Transaction associated with this object.
        Transaction: StripeId<Markers.TreasuryTransaction>
    }

type TreasuryOutboundTransfersResourceReturnedDetails with
    static member New(code: TreasuryOutboundTransfersResourceReturnedDetailsCode, transaction: StripeId<Markers.TreasuryTransaction>) =
        {
            Code = code
            Transaction = transaction
        }

type TreasuryOutboundTransfersResourceStatusTransitions =
    {
        /// Timestamp describing when an OutboundTransfer changed status to `canceled`
        CanceledAt: DateTime option
        /// Timestamp describing when an OutboundTransfer changed status to `failed`
        FailedAt: DateTime option
        /// Timestamp describing when an OutboundTransfer changed status to `posted`
        PostedAt: DateTime option
        /// Timestamp describing when an OutboundTransfer changed status to `returned`
        ReturnedAt: DateTime option
    }

type TreasuryOutboundTransfersResourceStatusTransitions with
    static member New(canceledAt: DateTime option, failedAt: DateTime option, postedAt: DateTime option, returnedAt: DateTime option) =
        {
            CanceledAt = canceledAt
            FailedAt = failedAt
            PostedAt = postedAt
            ReturnedAt = returnedAt
        }

/// Use [OutboundTransfers](https://docs.stripe.com/docs/treasury/moving-money/financial-accounts/out-of/outbound-transfers) to transfer funds from a [FinancialAccount](https://api.stripe.com#financial_accounts) to a PaymentMethod belonging to the same entity. To send funds to a different party, use [OutboundPayments](https://api.stripe.com#outbound_payments) instead. You can send funds over ACH rails or through a domestic wire transfer to a user's own external bank account.
/// Simulate OutboundTransfer state changes with the `/v1/test_helpers/treasury/outbound_transfers` endpoints. These methods can only be called on test mode objects.
/// Related guide: [Moving money with Treasury using OutboundTransfer objects](https://docs.stripe.com/docs/treasury/moving-money/financial-accounts/out-of/outbound-transfers)
type TreasuryOutboundTransfer =
    {
        /// Amount (in cents) transferred.
        Amount: int
        /// Returns `true` if the object can be canceled, and `false` otherwise.
        Cancelable: bool
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        /// The PaymentMethod used as the payment instrument for an OutboundTransfer.
        DestinationPaymentMethod: string option
        DestinationPaymentMethodDetails: OutboundTransfersPaymentMethodDetails
        /// The date when funds are expected to arrive in the destination account.
        ExpectedArrivalDate: DateTime
        /// The FinancialAccount that funds were pulled from.
        FinancialAccount: string
        /// A [hosted transaction receipt](https://docs.stripe.com/treasury/moving-money/regulatory-receipts) URL that is provided when money movement is considered regulated under Stripe's money transmission licenses.
        HostedRegulatoryReceiptUrl: string option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// Details about a returned OutboundTransfer. Only set when the status is `returned`.
        ReturnedDetails: TreasuryOutboundTransfersResourceReturnedDetails option
        /// Information about the OutboundTransfer to be sent to the recipient account.
        StatementDescriptor: string
        /// Current status of the OutboundTransfer: `processing`, `failed`, `canceled`, `posted`, `returned`. An OutboundTransfer is `processing` if it has been created and is pending. The status changes to `posted` once the OutboundTransfer has been "confirmed" and funds have left the account, or to `failed` or `canceled`. If an OutboundTransfer fails to arrive at its destination, its status will change to `returned`.
        Status: TreasuryOutboundTransferStatus
        StatusTransitions: TreasuryOutboundTransfersResourceStatusTransitions
        /// Details about network-specific tracking information if available.
        TrackingDetails: TreasuryOutboundTransfersResourceOutboundTransferResourceTrackingDetails option
        /// The Transaction associated with this object.
        Transaction: StripeId<Markers.TreasuryTransaction>
    }

type TreasuryOutboundTransfer with
    static member New(amount: int, cancelable: bool, created: DateTime, currency: IsoTypes.IsoCurrencyCode, description: string option, destinationPaymentMethod: string option, destinationPaymentMethodDetails: OutboundTransfersPaymentMethodDetails, expectedArrivalDate: DateTime, financialAccount: string, hostedRegulatoryReceiptUrl: string option, id: string, livemode: bool, metadata: Map<string, string>, returnedDetails: TreasuryOutboundTransfersResourceReturnedDetails option, statementDescriptor: string, status: TreasuryOutboundTransferStatus, statusTransitions: TreasuryOutboundTransfersResourceStatusTransitions, trackingDetails: TreasuryOutboundTransfersResourceOutboundTransferResourceTrackingDetails option, transaction: StripeId<Markers.TreasuryTransaction>) =
        {
            Amount = amount
            Cancelable = cancelable
            Created = created
            Currency = currency
            Description = description
            DestinationPaymentMethod = destinationPaymentMethod
            DestinationPaymentMethodDetails = destinationPaymentMethodDetails
            ExpectedArrivalDate = expectedArrivalDate
            FinancialAccount = financialAccount
            HostedRegulatoryReceiptUrl = hostedRegulatoryReceiptUrl
            Id = id
            Livemode = livemode
            Metadata = metadata
            ReturnedDetails = returnedDetails
            StatementDescriptor = statementDescriptor
            Status = status
            StatusTransitions = statusTransitions
            TrackingDetails = trackingDetails
            Transaction = transaction
        }

module TreasuryOutboundTransfer =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.outbound_transfer"

/// Occurs whenever an OutboundTransfer is canceled.
type TreasuryOutboundTransferCanceled = { Object: TreasuryOutboundTransfer }

type TreasuryOutboundTransferCanceled with
    static member New(object: TreasuryOutboundTransfer) =
        {
            Object = object
        }

/// Occurs whenever an OutboundTransfer is created.
type TreasuryOutboundTransferCreated = { Object: TreasuryOutboundTransfer }

type TreasuryOutboundTransferCreated with
    static member New(object: TreasuryOutboundTransfer) =
        {
            Object = object
        }

/// Occurs whenever the arrival date on an OutboundTransfer updates.
type TreasuryOutboundTransferExpectedArrivalDateUpdated = { Object: TreasuryOutboundTransfer }

type TreasuryOutboundTransferExpectedArrivalDateUpdated with
    static member New(object: TreasuryOutboundTransfer) =
        {
            Object = object
        }

/// Occurs whenever an OutboundTransfer has failed.
type TreasuryOutboundTransferFailed = { Object: TreasuryOutboundTransfer }

type TreasuryOutboundTransferFailed with
    static member New(object: TreasuryOutboundTransfer) =
        {
            Object = object
        }

/// Occurs whenever an OutboundTransfer is posted.
type TreasuryOutboundTransferPosted = { Object: TreasuryOutboundTransfer }

type TreasuryOutboundTransferPosted with
    static member New(object: TreasuryOutboundTransfer) =
        {
            Object = object
        }

/// Occurs whenever an OutboundTransfer is returned.
type TreasuryOutboundTransferReturned = { Object: TreasuryOutboundTransfer }

type TreasuryOutboundTransferReturned with
    static member New(object: TreasuryOutboundTransfer) =
        {
            Object = object
        }

/// Occurs whenever tracking_details on an OutboundTransfer is updated.
type TreasuryOutboundTransferTrackingDetailsUpdated = { Object: TreasuryOutboundTransfer }

type TreasuryOutboundTransferTrackingDetailsUpdated with
    static member New(object: TreasuryOutboundTransfer) =
        {
            Object = object
        }

[<Struct>]
type TreasuryReceivedCreditFailureCode =
    | AccountClosed
    | AccountFrozen
    | InternationalTransaction
    | Other

[<Struct>]
type TreasuryReceivedCreditNetwork =
    | Ach
    | Card
    | Stripe
    | UsDomesticWire

[<Struct>]
type TreasuryReceivedCreditStatus =
    | Failed
    | Succeeded

[<Struct>]
type TreasuryReceivedCreditsResourceSourceFlowsDetailsType =
    | CreditReversal
    | Other
    | OutboundPayment
    | OutboundTransfer
    | Payout

type TreasuryReceivedCreditsResourceSourceFlowsDetails =
    {
        CreditReversal: TreasuryCreditReversal option
        OutboundPayment: TreasuryOutboundPayment option
        OutboundTransfer: TreasuryOutboundTransfer option
        Payout: Payout option
        /// The type of the source flow that originated the ReceivedCredit.
        Type: TreasuryReceivedCreditsResourceSourceFlowsDetailsType
    }

type TreasuryReceivedCreditsResourceSourceFlowsDetails with
    static member New(``type``: TreasuryReceivedCreditsResourceSourceFlowsDetailsType, ?creditReversal: TreasuryCreditReversal, ?outboundPayment: TreasuryOutboundPayment, ?outboundTransfer: TreasuryOutboundTransfer, ?payout: Payout) =
        {
            Type = ``type``
            CreditReversal = creditReversal
            OutboundPayment = outboundPayment
            OutboundTransfer = outboundTransfer
            Payout = payout
        }

type TreasuryReceivedCreditsResourceLinkedFlows =
    {
        /// The CreditReversal created as a result of this ReceivedCredit being reversed.
        CreditReversal: string option
        /// Set if the ReceivedCredit was created due to an [Issuing Authorization](https://api.stripe.com#issuing_authorizations) object.
        IssuingAuthorization: string option
        /// Set if the ReceivedCredit is also viewable as an [Issuing transaction](https://api.stripe.com#issuing_transactions) object.
        IssuingTransaction: string option
        /// ID of the source flow. Set if `network` is `stripe` and the source flow is visible to the user. Examples of source flows include OutboundPayments, payouts, or CreditReversals.
        SourceFlow: string option
        /// The expandable object of the source flow.
        SourceFlowDetails: TreasuryReceivedCreditsResourceSourceFlowsDetails option
        /// The type of flow that originated the ReceivedCredit (for example, `outbound_payment`).
        SourceFlowType: string option
    }

type TreasuryReceivedCreditsResourceLinkedFlows with
    static member New(creditReversal: string option, issuingAuthorization: string option, issuingTransaction: string option, sourceFlow: string option, sourceFlowType: string option, ?sourceFlowDetails: TreasuryReceivedCreditsResourceSourceFlowsDetails option) =
        {
            CreditReversal = creditReversal
            IssuingAuthorization = issuingAuthorization
            IssuingTransaction = issuingTransaction
            SourceFlow = sourceFlow
            SourceFlowType = sourceFlowType
            SourceFlowDetails = sourceFlowDetails |> Option.flatten
        }

[<Struct>]
type TreasuryReceivedCreditsResourceReversalDetailsRestrictedReason =
    | AlreadyReversed
    | DeadlinePassed
    | NetworkRestricted
    | Other
    | SourceFlowRestricted

type TreasuryReceivedCreditsResourceReversalDetails =
    {
        /// Time before which a ReceivedCredit can be reversed.
        Deadline: DateTime option
        /// Set if a ReceivedCredit cannot be reversed.
        RestrictedReason: TreasuryReceivedCreditsResourceReversalDetailsRestrictedReason option
    }

type TreasuryReceivedCreditsResourceReversalDetails with
    static member New(deadline: DateTime option, restrictedReason: TreasuryReceivedCreditsResourceReversalDetailsRestrictedReason option) =
        {
            Deadline = deadline
            RestrictedReason = restrictedReason
        }

[<Struct>]
type TreasurySharedResourceInitiatingPaymentMethodDetailsInitiatingPaymentMethodDetailsType =
    | Balance
    | FinancialAccount
    | IssuingCard
    | Stripe
    | UsBankAccount

type TreasurySharedResourceInitiatingPaymentMethodDetailsUsBankAccount =
    {
        /// Bank name.
        BankName: string option
        /// The last four digits of the bank account number.
        [<JsonPropertyName("last4")>]
        Last4: string option
        /// The routing number for the bank account.
        RoutingNumber: string option
    }

type TreasurySharedResourceInitiatingPaymentMethodDetailsUsBankAccount with
    static member New(bankName: string option, last4: string option, routingNumber: string option) =
        {
            BankName = bankName
            Last4 = last4
            RoutingNumber = routingNumber
        }

type TreasurySharedResourceInitiatingPaymentMethodDetailsInitiatingPaymentMethodDetails =
    {
        BillingDetails: TreasurySharedResourceBillingDetails
        FinancialAccount: ReceivedPaymentMethodDetailsFinancialAccount option
        /// Set when `type` is `issuing_card`. This is an [Issuing Card](https://api.stripe.com#issuing_cards) ID.
        IssuingCard: string option
        /// Polymorphic type matching the originating money movement's source. This can be an external account, a Stripe balance, or a FinancialAccount.
        Type: TreasurySharedResourceInitiatingPaymentMethodDetailsInitiatingPaymentMethodDetailsType
        UsBankAccount: TreasurySharedResourceInitiatingPaymentMethodDetailsUsBankAccount option
    }

type TreasurySharedResourceInitiatingPaymentMethodDetailsInitiatingPaymentMethodDetails with
    static member New(billingDetails: TreasurySharedResourceBillingDetails, ``type``: TreasurySharedResourceInitiatingPaymentMethodDetailsInitiatingPaymentMethodDetailsType, ?financialAccount: ReceivedPaymentMethodDetailsFinancialAccount, ?issuingCard: string, ?usBankAccount: TreasurySharedResourceInitiatingPaymentMethodDetailsUsBankAccount) =
        {
            BillingDetails = billingDetails
            Type = ``type``
            FinancialAccount = financialAccount
            IssuingCard = issuingCard
            UsBankAccount = usBankAccount
        }

module TreasurySharedResourceInitiatingPaymentMethodDetailsInitiatingPaymentMethodDetails =
    ///Set when `type` is `balance`.
    let balance = "payments"

/// ReceivedCredits represent funds sent to a [FinancialAccount](https://api.stripe.com#financial_accounts) (for example, via ACH or wire). These money movements are not initiated from the FinancialAccount.
type TreasuryReceivedCredit =
    {
        /// Amount (in cents) transferred.
        Amount: int
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string
        /// Reason for the failure. A ReceivedCredit might fail because the receiving FinancialAccount is closed or frozen.
        FailureCode: TreasuryReceivedCreditFailureCode option
        /// The FinancialAccount that received the funds.
        FinancialAccount: string option
        /// A [hosted transaction receipt](https://docs.stripe.com/treasury/moving-money/regulatory-receipts) URL that is provided when money movement is considered regulated under Stripe's money transmission licenses.
        HostedRegulatoryReceiptUrl: string option
        /// Unique identifier for the object.
        Id: string
        InitiatingPaymentMethodDetails:
            TreasurySharedResourceInitiatingPaymentMethodDetailsInitiatingPaymentMethodDetails
        LinkedFlows: TreasuryReceivedCreditsResourceLinkedFlows
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The rails used to send the funds.
        Network: TreasuryReceivedCreditNetwork
        /// Details describing when a ReceivedCredit may be reversed.
        ReversalDetails: TreasuryReceivedCreditsResourceReversalDetails option
        /// Status of the ReceivedCredit. ReceivedCredits are created either `succeeded` (approved) or `failed` (declined). If a ReceivedCredit is declined, the failure reason can be found in the `failure_code` field.
        Status: TreasuryReceivedCreditStatus
        /// The Transaction associated with this object.
        Transaction: StripeId<Markers.TreasuryTransaction> option
    }

type TreasuryReceivedCredit with
    static member New(amount: int, created: DateTime, currency: IsoTypes.IsoCurrencyCode, description: string, failureCode: TreasuryReceivedCreditFailureCode option, financialAccount: string option, hostedRegulatoryReceiptUrl: string option, id: string, initiatingPaymentMethodDetails: TreasurySharedResourceInitiatingPaymentMethodDetailsInitiatingPaymentMethodDetails, linkedFlows: TreasuryReceivedCreditsResourceLinkedFlows, livemode: bool, network: TreasuryReceivedCreditNetwork, reversalDetails: TreasuryReceivedCreditsResourceReversalDetails option, status: TreasuryReceivedCreditStatus, transaction: StripeId<Markers.TreasuryTransaction> option) =
        {
            Amount = amount
            Created = created
            Currency = currency
            Description = description
            FailureCode = failureCode
            FinancialAccount = financialAccount
            HostedRegulatoryReceiptUrl = hostedRegulatoryReceiptUrl
            Id = id
            InitiatingPaymentMethodDetails = initiatingPaymentMethodDetails
            LinkedFlows = linkedFlows
            Livemode = livemode
            Network = network
            ReversalDetails = reversalDetails
            Status = status
            Transaction = transaction
        }

module TreasuryReceivedCredit =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.received_credit"

/// Occurs whenever a received_credit is created as a result of funds being pushed by another account.
type TreasuryReceivedCreditCreated = { Object: TreasuryReceivedCredit }

type TreasuryReceivedCreditCreated with
    static member New(object: TreasuryReceivedCredit) =
        {
            Object = object
        }

/// Occurs whenever a received_credit transitions to failed state. Only applicable for check deposits.
type TreasuryReceivedCreditFailed = { Object: TreasuryReceivedCredit }

type TreasuryReceivedCreditFailed with
    static member New(object: TreasuryReceivedCredit) =
        {
            Object = object
        }

/// Occurs whenever a received_credit transitions to succeeded state. Only applicable for check deposits.
type TreasuryReceivedCreditSucceeded = { Object: TreasuryReceivedCredit }

type TreasuryReceivedCreditSucceeded with
    static member New(object: TreasuryReceivedCredit) =
        {
            Object = object
        }

[<Struct>]
type TreasuryReceivedDebitFailureCode =
    | AccountClosed
    | AccountFrozen
    | InsufficientFunds
    | InternationalTransaction
    | Other

[<Struct>]
type TreasuryReceivedDebitNetwork =
    | Ach
    | Card
    | Stripe

[<Struct>]
type TreasuryReceivedDebitStatus =
    | Failed
    | Succeeded

type TreasuryReceivedDebitsResourceLinkedFlows =
    {
        /// The DebitReversal created as a result of this ReceivedDebit being reversed.
        DebitReversal: string option
        /// Set if the ReceivedDebit is associated with an InboundTransfer's return of funds.
        InboundTransfer: string option
        /// Set if the ReceivedDebit was created due to an [Issuing Authorization](https://api.stripe.com#issuing_authorizations) object.
        IssuingAuthorization: string option
        /// Set if the ReceivedDebit is also viewable as an [Issuing Dispute](https://api.stripe.com#issuing_disputes) object.
        IssuingTransaction: string option
        /// Set if the ReceivedDebit was created due to a [Payout](https://api.stripe.com#payouts) object.
        Payout: string option
        /// Set if the ReceivedDebit was created due to a [Topup](https://api.stripe.com#topups) object.
        Topup: string option
    }

type TreasuryReceivedDebitsResourceLinkedFlows with
    static member New(debitReversal: string option, inboundTransfer: string option, issuingAuthorization: string option, issuingTransaction: string option, payout: string option, topup: string option) =
        {
            DebitReversal = debitReversal
            InboundTransfer = inboundTransfer
            IssuingAuthorization = issuingAuthorization
            IssuingTransaction = issuingTransaction
            Payout = payout
            Topup = topup
        }

[<Struct>]
type TreasuryReceivedDebitsResourceReversalDetailsRestrictedReason =
    | AlreadyReversed
    | DeadlinePassed
    | NetworkRestricted
    | Other
    | SourceFlowRestricted

type TreasuryReceivedDebitsResourceReversalDetails =
    {
        /// Time before which a ReceivedDebit can be reversed.
        Deadline: DateTime option
        /// Set if a ReceivedDebit can't be reversed.
        RestrictedReason: TreasuryReceivedDebitsResourceReversalDetailsRestrictedReason option
    }

type TreasuryReceivedDebitsResourceReversalDetails with
    static member New(deadline: DateTime option, restrictedReason: TreasuryReceivedDebitsResourceReversalDetailsRestrictedReason option) =
        {
            Deadline = deadline
            RestrictedReason = restrictedReason
        }

/// ReceivedDebits represent funds pulled from a [FinancialAccount](https://api.stripe.com#financial_accounts). These are not initiated from the FinancialAccount.
type TreasuryReceivedDebit =
    {
        /// Amount (in cents) transferred.
        Amount: int
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string
        /// Reason for the failure. A ReceivedDebit might fail because the FinancialAccount doesn't have sufficient funds, is closed, or is frozen.
        FailureCode: TreasuryReceivedDebitFailureCode option
        /// The FinancialAccount that funds were pulled from.
        FinancialAccount: string option
        /// A [hosted transaction receipt](https://docs.stripe.com/treasury/moving-money/regulatory-receipts) URL that is provided when money movement is considered regulated under Stripe's money transmission licenses.
        HostedRegulatoryReceiptUrl: string option
        /// Unique identifier for the object.
        Id: string
        InitiatingPaymentMethodDetails:
            TreasurySharedResourceInitiatingPaymentMethodDetailsInitiatingPaymentMethodDetails option
        LinkedFlows: TreasuryReceivedDebitsResourceLinkedFlows
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The network used for the ReceivedDebit.
        Network: TreasuryReceivedDebitNetwork
        /// Details describing when a ReceivedDebit might be reversed.
        ReversalDetails: TreasuryReceivedDebitsResourceReversalDetails option
        /// Status of the ReceivedDebit. ReceivedDebits are created with a status of either `succeeded` (approved) or `failed` (declined). The failure reason can be found under the `failure_code`.
        Status: TreasuryReceivedDebitStatus
        /// The Transaction associated with this object.
        Transaction: StripeId<Markers.TreasuryTransaction> option
    }

type TreasuryReceivedDebit with
    static member New(amount: int, created: DateTime, currency: IsoTypes.IsoCurrencyCode, description: string, failureCode: TreasuryReceivedDebitFailureCode option, financialAccount: string option, hostedRegulatoryReceiptUrl: string option, id: string, linkedFlows: TreasuryReceivedDebitsResourceLinkedFlows, livemode: bool, network: TreasuryReceivedDebitNetwork, reversalDetails: TreasuryReceivedDebitsResourceReversalDetails option, status: TreasuryReceivedDebitStatus, transaction: StripeId<Markers.TreasuryTransaction> option, ?initiatingPaymentMethodDetails: TreasurySharedResourceInitiatingPaymentMethodDetailsInitiatingPaymentMethodDetails) =
        {
            Amount = amount
            Created = created
            Currency = currency
            Description = description
            FailureCode = failureCode
            FinancialAccount = financialAccount
            HostedRegulatoryReceiptUrl = hostedRegulatoryReceiptUrl
            Id = id
            LinkedFlows = linkedFlows
            Livemode = livemode
            Network = network
            ReversalDetails = reversalDetails
            Status = status
            Transaction = transaction
            InitiatingPaymentMethodDetails = initiatingPaymentMethodDetails
        }

module TreasuryReceivedDebit =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.received_debit"

/// Occurs whenever a received_debit is created as a result of funds being pulled by another account.
type TreasuryReceivedDebitCreated = { Object: TreasuryReceivedDebit }

type TreasuryReceivedDebitCreated with
    static member New(object: TreasuryReceivedDebit) =
        {
            Object = object
        }

type TreasuryTransactionEntryFlowType =
    | CreditReversal
    | DebitReversal
    | InboundTransfer
    | IssuingAuthorization
    | Other
    | OutboundPayment
    | OutboundTransfer
    | ReceivedCredit
    | ReceivedDebit

type TreasuryTransactionEntryType =
    | CreditReversal
    | CreditReversalPosting
    | DebitReversal
    | InboundTransfer
    | InboundTransferReturn
    | IssuingAuthorizationHold
    | IssuingAuthorizationRelease
    | Other
    | OutboundPayment
    | OutboundPaymentCancellation
    | OutboundPaymentFailure
    | OutboundPaymentPosting
    | OutboundPaymentReturn
    | OutboundTransfer
    | OutboundTransferCancellation
    | OutboundTransferFailure
    | OutboundTransferPosting
    | OutboundTransferReturn
    | ReceivedCredit
    | ReceivedDebit

/// Change to a FinancialAccount's balance
type TreasuryTransactionsResourceBalanceImpact =
    {
        /// The change made to funds the user can spend right now.
        Cash: int
        /// The change made to funds that are not spendable yet, but will become available at a later time.
        InboundPending: int
        /// The change made to funds in the account, but not spendable because they are being held for pending outbound flows.
        OutboundPending: int
    }

type TreasuryTransactionsResourceBalanceImpact with
    static member New(cash: int, inboundPending: int, outboundPending: int) =
        {
            Cash = cash
            InboundPending = inboundPending
            OutboundPending = outboundPending
        }

type TreasuryTransactionsResourceFlowDetailsType =
    | CreditReversal
    | DebitReversal
    | InboundTransfer
    | IssuingAuthorization
    | Other
    | OutboundPayment
    | OutboundTransfer
    | ReceivedCredit
    | ReceivedDebit

type TreasuryTransactionsResourceFlowDetails =
    {
        CreditReversal: TreasuryCreditReversal option
        DebitReversal: TreasuryDebitReversal option
        InboundTransfer: TreasuryInboundTransfer option
        IssuingAuthorization: IssuingAuthorization option
        OutboundPayment: TreasuryOutboundPayment option
        OutboundTransfer: TreasuryOutboundTransfer option
        ReceivedCredit: TreasuryReceivedCredit option
        ReceivedDebit: TreasuryReceivedDebit option
        /// Type of the flow that created the Transaction. Set to the same value as `flow_type`.
        Type: TreasuryTransactionsResourceFlowDetailsType
    }

type TreasuryTransactionsResourceFlowDetails with
    static member New(``type``: TreasuryTransactionsResourceFlowDetailsType, ?creditReversal: TreasuryCreditReversal, ?debitReversal: TreasuryDebitReversal, ?inboundTransfer: TreasuryInboundTransfer, ?issuingAuthorization: IssuingAuthorization, ?outboundPayment: TreasuryOutboundPayment, ?outboundTransfer: TreasuryOutboundTransfer, ?receivedCredit: TreasuryReceivedCredit, ?receivedDebit: TreasuryReceivedDebit) =
        {
            Type = ``type``
            CreditReversal = creditReversal
            DebitReversal = debitReversal
            InboundTransfer = inboundTransfer
            IssuingAuthorization = issuingAuthorization
            OutboundPayment = outboundPayment
            OutboundTransfer = outboundTransfer
            ReceivedCredit = receivedCredit
            ReceivedDebit = receivedDebit
        }

/// TransactionEntries represent individual units of money movements within a single [Transaction](https://api.stripe.com#transactions).
type TreasuryTransactionEntry =
    {
        BalanceImpact: TreasuryTransactionsResourceBalanceImpact
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// When the TransactionEntry will impact the FinancialAccount's balance.
        EffectiveAt: DateTime
        /// The FinancialAccount associated with this object.
        FinancialAccount: string
        /// Token of the flow associated with the TransactionEntry.
        Flow: string option
        /// Details of the flow associated with the TransactionEntry.
        FlowDetails: TreasuryTransactionsResourceFlowDetails option
        /// Type of the flow associated with the TransactionEntry.
        FlowType: TreasuryTransactionEntryFlowType
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The Transaction associated with this object.
        Transaction: StripeId<Markers.TreasuryTransaction>
        /// The specific money movement that generated the TransactionEntry.
        Type: TreasuryTransactionEntryType
    }

type TreasuryTransactionEntry with
    static member New(balanceImpact: TreasuryTransactionsResourceBalanceImpact, created: DateTime, currency: IsoTypes.IsoCurrencyCode, effectiveAt: DateTime, financialAccount: string, flow: string option, flowType: TreasuryTransactionEntryFlowType, id: string, livemode: bool, transaction: StripeId<Markers.TreasuryTransaction>, ``type``: TreasuryTransactionEntryType, ?flowDetails: TreasuryTransactionsResourceFlowDetails option) =
        {
            BalanceImpact = balanceImpact
            Created = created
            Currency = currency
            EffectiveAt = effectiveAt
            FinancialAccount = financialAccount
            Flow = flow
            FlowType = flowType
            Id = id
            Livemode = livemode
            Transaction = transaction
            Type = ``type``
            FlowDetails = flowDetails |> Option.flatten
        }

module TreasuryTransactionEntry =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.transaction_entry"

/// A list of TransactionEntries that are part of this Transaction. This cannot be expanded in any list endpoints.
type TreasuryTransactionEntries =
    {
        /// Details about each object.
        Data: TreasuryTransactionEntry list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

type TreasuryTransactionEntries with
    static member New(data: TreasuryTransactionEntry list, hasMore: bool, url: string) =
        {
            Data = data
            HasMore = hasMore
            Url = url
        }

module TreasuryTransactionEntries =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

type TreasuryTransactionFlowType =
    | CreditReversal
    | DebitReversal
    | InboundTransfer
    | IssuingAuthorization
    | Other
    | OutboundPayment
    | OutboundTransfer
    | ReceivedCredit
    | ReceivedDebit

[<Struct>]
type TreasuryTransactionStatus =
    | Open
    | Posted
    | Void

type TreasuryTransactionsResourceAbstractTransactionResourceStatusTransitions =
    {
        /// Timestamp describing when the Transaction changed status to `posted`.
        PostedAt: DateTime option
        /// Timestamp describing when the Transaction changed status to `void`.
        VoidAt: DateTime option
    }

type TreasuryTransactionsResourceAbstractTransactionResourceStatusTransitions with
    static member New(postedAt: DateTime option, voidAt: DateTime option) =
        {
            PostedAt = postedAt
            VoidAt = voidAt
        }

/// Transactions represent changes to a [FinancialAccount's](https://api.stripe.com#financial_accounts) balance.
type TreasuryTransaction =
    {
        /// Amount (in cents) transferred.
        Amount: int
        BalanceImpact: TreasuryTransactionsResourceBalanceImpact
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string
        /// A list of TransactionEntries that are part of this Transaction. This cannot be expanded in any list endpoints.
        Entries: TreasuryTransactionEntries option
        /// The FinancialAccount associated with this object.
        FinancialAccount: string
        /// ID of the flow that created the Transaction.
        Flow: string option
        /// Details of the flow that created the Transaction.
        FlowDetails: TreasuryTransactionsResourceFlowDetails option
        /// Type of the flow that created the Transaction.
        FlowType: TreasuryTransactionFlowType
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Status of the Transaction.
        Status: TreasuryTransactionStatus
        StatusTransitions: TreasuryTransactionsResourceAbstractTransactionResourceStatusTransitions
    }

type TreasuryTransaction with
    static member New(amount: int, balanceImpact: TreasuryTransactionsResourceBalanceImpact, created: DateTime, currency: IsoTypes.IsoCurrencyCode, description: string, financialAccount: string, flow: string option, flowType: TreasuryTransactionFlowType, id: string, livemode: bool, status: TreasuryTransactionStatus, statusTransitions: TreasuryTransactionsResourceAbstractTransactionResourceStatusTransitions, ?entries: TreasuryTransactionEntries option, ?flowDetails: TreasuryTransactionsResourceFlowDetails option) =
        {
            Amount = amount
            BalanceImpact = balanceImpact
            Created = created
            Currency = currency
            Description = description
            FinancialAccount = financialAccount
            Flow = flow
            FlowType = flowType
            Id = id
            Livemode = livemode
            Status = status
            StatusTransitions = statusTransitions
            Entries = entries |> Option.flatten
            FlowDetails = flowDetails |> Option.flatten
        }

module TreasuryTransaction =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.transaction"

