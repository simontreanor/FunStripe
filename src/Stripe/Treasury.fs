namespace Stripe.Treasury

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Address
open Stripe.Payment
open Stripe.Received

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
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

type TreasuryReceivedDebitsResourceStatusTransitions =
    {
        /// Timestamp describing when the DebitReversal changed status to `completed`.
        CompletedAt: DateTime option
    }

[<Struct>]
type InboundTransfersPaymentMethodDetailsUsBankAccountAccountHolderType =
    | Company
    | Individual

[<Struct>]
type InboundTransfersPaymentMethodDetailsUsBankAccountAccountType =
    | Checking
    | Savings

type InboundTransfersPaymentMethodDetailsUsBankAccountMandate'AnyOf =
    | String of string
    | Mandate of Mandate

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
        Mandate: InboundTransfersPaymentMethodDetailsUsBankAccountMandate'AnyOf option
        /// Routing number of the bank account.
        RoutingNumber: string option
    }

type TreasurySharedResourceBillingDetails =
    {
        Address: Address
        /// Email address.
        Email: string option
        /// Full name.
        Name: string option
    }

type InboundTransfers =
    { BillingDetails: TreasurySharedResourceBillingDetails
      UsBankAccount: InboundTransfersPaymentMethodDetailsUsBankAccount option }

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

type TreasuryInboundTransfersResourceInboundTransferResourceLinkedFlows =
    {
        /// If funds for this flow were returned after the flow went to the `succeeded` state, this field contains a reference to the ReceivedDebit return.
        ReceivedDebit: string option
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

type OutboundPaymentsPaymentMethodDetailsFinancialAccount =
    {
        /// Token of the FinancialAccount.
        Id: string
    }

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

type OutboundPaymentsPaymentMethodDetailsUsBankAccountMandate'AnyOf =
    | String of string
    | Mandate of Mandate

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
        Mandate: OutboundPaymentsPaymentMethodDetailsUsBankAccountMandate'AnyOf option
        /// The network rails used. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.
        Network: OutboundPaymentsPaymentMethodDetailsUsBankAccountNetwork
        /// Routing number of the bank account.
        RoutingNumber: string option
    }

type OutboundPaymentsPaymentMethodDetails =
    {
        BillingDetails: TreasurySharedResourceBillingDetails
        FinancialAccount: OutboundPaymentsPaymentMethodDetailsFinancialAccount option
        /// The type of the payment method used in the OutboundPayment.
        Type: OutboundPaymentsPaymentMethodDetailsType
        UsBankAccount: OutboundPaymentsPaymentMethodDetailsUsBankAccount option
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

type TreasuryOutboundPaymentsResourceAchTrackingDetails =
    {
        /// ACH trace ID of the OutboundPayment for payments sent over the `ach` network.
        TraceId: string
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

type TreasuryOutboundPaymentsResourceOutboundPaymentResourceTrackingDetails =
    {
        Ach: TreasuryOutboundPaymentsResourceAchTrackingDetails option
        /// The US bank account network used to send funds.
        Type: TreasuryOutboundPaymentsResourceOutboundPaymentResourceTrackingDetailsType
        UsDomesticWire: TreasuryOutboundPaymentsResourceUsDomesticWireTrackingDetails option
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

type OutboundTransfersPaymentMethodDetailsFinancialAccount =
    {
        /// Token of the FinancialAccount.
        Id: string
    }

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

type OutboundTransfersPaymentMethodDetailsUsBankAccountMandate'AnyOf =
    | String of string
    | Mandate of Mandate

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
        Mandate: OutboundTransfersPaymentMethodDetailsUsBankAccountMandate'AnyOf option
        /// The network rails used. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.
        Network: OutboundTransfersPaymentMethodDetailsUsBankAccountNetwork
        /// Routing number of the bank account.
        RoutingNumber: string option
    }

type OutboundTransfersPaymentMethodDetails =
    {
        BillingDetails: TreasurySharedResourceBillingDetails
        FinancialAccount: OutboundTransfersPaymentMethodDetailsFinancialAccount option
        /// The type of the payment method used in the OutboundTransfer.
        Type: OutboundTransfersPaymentMethodDetailsType
        UsBankAccount: OutboundTransfersPaymentMethodDetailsUsBankAccount option
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

type TreasuryOutboundTransfersResourceOutboundTransferResourceTrackingDetails =
    {
        Ach: TreasuryOutboundTransfersResourceAchTrackingDetails option
        /// The US bank account network used to send funds.
        Type: TreasuryOutboundTransfersResourceOutboundTransferResourceTrackingDetailsType
        UsDomesticWire: TreasuryOutboundTransfersResourceUsDomesticWireTrackingDetails option
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
        Transaction: TreasuryCreditReversalTransaction'AnyOf option
    }

and TreasuryCreditReversalTransaction'AnyOf =
    | String of string
    | TreasuryTransaction of TreasuryTransaction

/// You can reverse some [ReceivedDebits](https://api.stripe.com#received_debits) depending on their network and source flow. Reversing a ReceivedDebit leads to the creation of a new object known as a DebitReversal.
and TreasuryDebitReversal =
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
        Transaction: TreasuryDebitReversalTransaction'AnyOf option
    }

and TreasuryDebitReversalTransaction'AnyOf =
    | String of string
    | TreasuryTransaction of TreasuryTransaction

/// Use [InboundTransfers](https://docs.stripe.com/docs/treasury/moving-money/financial-accounts/into/inbound-transfers) to add funds to your [FinancialAccount](https://api.stripe.com#financial_accounts) via a PaymentMethod that is owned by you. The funds will be transferred via an ACH debit.
/// Related guide: [Moving money with Treasury using InboundTransfer objects](https://docs.stripe.com/docs/treasury/moving-money/financial-accounts/into/inbound-transfers)
and TreasuryInboundTransfer =
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
        Transaction: TreasuryInboundTransferTransaction'AnyOf option
    }

and TreasuryInboundTransferTransaction'AnyOf =
    | String of string
    | TreasuryTransaction of TreasuryTransaction

/// Use [OutboundPayments](https://docs.stripe.com/docs/treasury/moving-money/financial-accounts/out-of/outbound-payments) to send funds to another party's external bank account or [FinancialAccount](https://api.stripe.com#financial_accounts). To send money to an account belonging to the same user, use an [OutboundTransfer](https://api.stripe.com#outbound_transfers).
/// Simulate OutboundPayment state changes with the `/v1/test_helpers/treasury/outbound_payments` endpoints. These methods can only be called on test mode objects.
/// Related guide: [Moving money with Treasury using OutboundPayment objects](https://docs.stripe.com/docs/treasury/moving-money/financial-accounts/out-of/outbound-payments)
and TreasuryOutboundPayment =
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
        Transaction: TreasuryOutboundPaymentTransaction'AnyOf
    }

and TreasuryOutboundPaymentTransaction'AnyOf =
    | String of string
    | TreasuryTransaction of TreasuryTransaction

/// Use [OutboundTransfers](https://docs.stripe.com/docs/treasury/moving-money/financial-accounts/out-of/outbound-transfers) to transfer funds from a [FinancialAccount](https://api.stripe.com#financial_accounts) to a PaymentMethod belonging to the same entity. To send funds to a different party, use [OutboundPayments](https://api.stripe.com#outbound_payments) instead. You can send funds over ACH rails or through a domestic wire transfer to a user's own external bank account.
/// Simulate OutboundTransfer state changes with the `/v1/test_helpers/treasury/outbound_transfers` endpoints. These methods can only be called on test mode objects.
/// Related guide: [Moving money with Treasury using OutboundTransfer objects](https://docs.stripe.com/docs/treasury/moving-money/financial-accounts/out-of/outbound-transfers)
and TreasuryOutboundTransfer =
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
        Transaction: TreasuryOutboundTransferTransaction'AnyOf
    }

and TreasuryOutboundTransferTransaction'AnyOf =
    | String of string
    | TreasuryTransaction of TreasuryTransaction

/// ReceivedCredits represent funds sent to a [FinancialAccount](https://api.stripe.com#financial_accounts) (for example, via ACH or wire). These money movements are not initiated from the FinancialAccount.
and TreasuryReceivedCredit =
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
        Transaction: TreasuryReceivedCreditTransaction'AnyOf option
    }

and TreasuryReceivedCreditTransaction'AnyOf =
    | String of string
    | TreasuryTransaction of TreasuryTransaction

/// ReceivedDebits represent funds pulled from a [FinancialAccount](https://api.stripe.com#financial_accounts). These are not initiated from the FinancialAccount.
and TreasuryReceivedDebit =
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
        Transaction: TreasuryReceivedDebitTransaction'AnyOf option
    }

and TreasuryReceivedDebitTransaction'AnyOf =
    | String of string
    | TreasuryTransaction of TreasuryTransaction

/// Transactions represent changes to a [FinancialAccount's](https://api.stripe.com#financial_accounts) balance.
and TreasuryTransaction =
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

/// A list of TransactionEntries that are part of this Transaction. This cannot be expanded in any list endpoints.
and TreasuryTransactionEntries =
    {
        /// Details about each object.
        Data: TreasuryTransactionEntry list
        /// True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        /// The URL where this list can be accessed.
        Url: string
    }

/// TransactionEntries represent individual units of money movements within a single [Transaction](https://api.stripe.com#transactions).
and TreasuryTransactionEntry =
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
        Transaction: TreasuryTransactionEntryTransaction'AnyOf
        /// The specific money movement that generated the TransactionEntry.
        Type: TreasuryTransactionEntryType
    }

and TreasuryTransactionEntryTransaction'AnyOf =
    | String of string
    | TreasuryTransaction of TreasuryTransaction

and TreasuryOutboundPaymentsResourceReturnedStatus =
    {
        /// Reason for the return.
        Code: TreasuryOutboundPaymentsResourceReturnedStatusCode
        /// The Transaction associated with this object.
        Transaction: TreasuryOutboundPaymentsResourceReturnedStatusTransaction'AnyOf
    }

and TreasuryOutboundPaymentsResourceReturnedStatusTransaction'AnyOf =
    | String of string
    | TreasuryTransaction of TreasuryTransaction

and TreasuryOutboundTransfersResourceReturnedDetails =
    {
        /// Reason for the return.
        Code: TreasuryOutboundTransfersResourceReturnedDetailsCode
        /// The Transaction associated with this object.
        Transaction: TreasuryOutboundTransfersResourceReturnedDetailsTransaction'AnyOf
    }

and TreasuryOutboundTransfersResourceReturnedDetailsTransaction'AnyOf =
    | String of string
    | TreasuryTransaction of TreasuryTransaction

and TreasuryReceivedCreditsResourceLinkedFlows =
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

and TreasuryReceivedCreditsResourceSourceFlowsDetails =
    {
        CreditReversal: TreasuryCreditReversal option
        OutboundPayment: TreasuryOutboundPayment option
        OutboundTransfer: TreasuryOutboundTransfer option
        Payout: Payout option
        /// The type of the source flow that originated the ReceivedCredit.
        Type: TreasuryReceivedCreditsResourceSourceFlowsDetailsType
    }

and TreasuryTransactionsResourceFlowDetails =
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

/// Occurs whenever a received_debit is created as a result of funds being pulled by another account.
type TreasuryReceivedDebitCreated = { Object: TreasuryReceivedDebit }

/// Occurs whenever a received_credit transitions to succeeded state. Only applicable for check deposits.
type TreasuryReceivedCreditSucceeded = { Object: TreasuryReceivedCredit }

/// Occurs whenever a received_credit transitions to failed state. Only applicable for check deposits.
type TreasuryReceivedCreditFailed = { Object: TreasuryReceivedCredit }

/// Occurs whenever a received_credit is created as a result of funds being pushed by another account.
type TreasuryReceivedCreditCreated = { Object: TreasuryReceivedCredit }

/// Occurs whenever tracking_details on an OutboundTransfer is updated.
type TreasuryOutboundTransferTrackingDetailsUpdated = { Object: TreasuryOutboundTransfer }

/// Occurs whenever an OutboundTransfer is returned.
type TreasuryOutboundTransferReturned = { Object: TreasuryOutboundTransfer }

/// Occurs whenever an OutboundTransfer is posted.
type TreasuryOutboundTransferPosted = { Object: TreasuryOutboundTransfer }

/// Occurs whenever an OutboundTransfer has failed.
type TreasuryOutboundTransferFailed = { Object: TreasuryOutboundTransfer }

/// Occurs whenever the arrival date on an OutboundTransfer updates.
type TreasuryOutboundTransferExpectedArrivalDateUpdated = { Object: TreasuryOutboundTransfer }

/// Occurs whenever an OutboundTransfer is created.
type TreasuryOutboundTransferCreated = { Object: TreasuryOutboundTransfer }

/// Occurs whenever an OutboundTransfer is canceled.
type TreasuryOutboundTransferCanceled = { Object: TreasuryOutboundTransfer }

/// Occurs whenever tracking_details on an OutboundPayment is updated.
type TreasuryOutboundPaymentTrackingDetailsUpdated = { Object: TreasuryOutboundPayment }

/// Occurs whenever an OutboundPayment was returned.
type TreasuryOutboundPaymentReturned = { Object: TreasuryOutboundPayment }

/// Occurs whenever an OutboundPayment posts.
type TreasuryOutboundPaymentPosted = { Object: TreasuryOutboundPayment }

/// Occurs whenever an OutboundPayment fails.
type TreasuryOutboundPaymentFailed = { Object: TreasuryOutboundPayment }

/// Occurs whenever the arrival date on an OutboundPayment updates.
type TreasuryOutboundPaymentExpectedArrivalDateUpdated = { Object: TreasuryOutboundPayment }

/// Occurs whenever a new OutboundPayment is successfully created.
type TreasuryOutboundPaymentCreated = { Object: TreasuryOutboundPayment }

/// Occurs whenever an OutboundPayment is canceled.
type TreasuryOutboundPaymentCanceled = { Object: TreasuryOutboundPayment }

/// Occurs whenever an InboundTransfer has succeeded.
type TreasuryInboundTransferSucceeded = { Object: TreasuryInboundTransfer }

/// Occurs whenever an InboundTransfer has failed.
type TreasuryInboundTransferFailed = { Object: TreasuryInboundTransfer }

/// Occurs whenever an InboundTransfer is created.
type TreasuryInboundTransferCreated = { Object: TreasuryInboundTransfer }

/// Occurs whenever an InboundTransfer is canceled.
type TreasuryInboundTransferCanceled = { Object: TreasuryInboundTransfer }

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

/// Settings related to Financial Addresses features on a Financial Account
type TreasuryFinancialAccountsResourceFinancialAddressesFeatures =
    { Aba: TreasuryFinancialAccountsResourceAbaToggleSettings option }

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

/// InboundTransfers contains inbound transfers features for a FinancialAccount.
type TreasuryFinancialAccountsResourceInboundTransfers =
    { Ach: TreasuryFinancialAccountsResourceInboundAchToggleSettings option }

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

/// Settings related to Outbound Payments features on a Financial Account
type TreasuryFinancialAccountsResourceOutboundPayments =
    { Ach: TreasuryFinancialAccountsResourceOutboundAchToggleSettings option
      UsDomesticWire: TreasuryFinancialAccountsResourceToggleSettings option }

/// OutboundTransfers contains outbound transfers features for a FinancialAccount.
type TreasuryFinancialAccountsResourceOutboundTransfers =
    { Ach: TreasuryFinancialAccountsResourceOutboundAchToggleSettings option
      UsDomesticWire: TreasuryFinancialAccountsResourceToggleSettings option }

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

type TreasuryFinancialAccountsResourceStatusDetails =
    {
        /// Details related to the closure of this FinancialAccount
        Closed: TreasuryFinancialAccountsResourceClosedStatusDetails option
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

/// Occurs whenever the statuses of any features within an existing FinancialAccount are updated.
type TreasuryFinancialAccountFeaturesStatusUpdated = { Object: TreasuryFinancialAccount }

/// Occurs whenever a new FinancialAccount is created.
type TreasuryFinancialAccountCreated = { Object: TreasuryFinancialAccount }

/// Occurs whenever the status of the FinancialAccount becomes closed.
type TreasuryFinancialAccountClosed = { Object: TreasuryFinancialAccount }

/// Occurs whenever an initial credit is granted on a DebitReversal.
type TreasuryDebitReversalInitialCreditGranted = { Object: TreasuryDebitReversal }

/// Occurs whenever a DebitReversal is created.
type TreasuryDebitReversalCreated = { Object: TreasuryDebitReversal }

/// Occurs whenever a DebitReversal is completed.
type TreasuryDebitReversalCompleted = { Object: TreasuryDebitReversal }

/// Occurs whenever an CreditReversal post is posted.
type TreasuryCreditReversalPosted = { Object: TreasuryCreditReversal }

/// Occurs whenever an CreditReversal is submitted and created.
type TreasuryCreditReversalCreated = { Object: TreasuryCreditReversal }

module InboundTransfersPaymentMethodDetailsUsBankAccount =
    ///The network rails used. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.
    let network = "ach"

module InboundTransfers =
    ///The type of the payment method used in the InboundTransfer.
    let ``type`` = "us_bank_account"

module OutboundPaymentsPaymentMethodDetailsFinancialAccount =
    ///The rails used to send funds.
    let network = "stripe"

module OutboundTransfersPaymentMethodDetailsFinancialAccount =
    ///The rails used to send funds.
    let network = "stripe"

module TreasurySharedResourceInitiatingPaymentMethodDetailsInitiatingPaymentMethodDetails =
    ///Set when `type` is `balance`.
    let balance = "payments"

module TreasuryCreditReversal =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.credit_reversal"

module TreasuryDebitReversal =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.debit_reversal"

module TreasuryInboundTransfer =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.inbound_transfer"

module TreasuryOutboundPayment =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.outbound_payment"

module TreasuryOutboundTransfer =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.outbound_transfer"

module TreasuryReceivedCredit =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.received_credit"

module TreasuryReceivedDebit =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.received_debit"

module TreasuryTransaction =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.transaction"

module TreasuryTransactionEntries =
    ///String representing the object's type. Objects of the same type share the same value. Always has the value `list`.
    let object = "list"

module TreasuryTransactionEntry =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.transaction_entry"

module TreasuryFinancialAccountFeatures =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.financial_account_features"

module TreasuryFinancialAccountsResourceFinancialAddress =
    ///The type of financial address
    let ``type`` = "aba"

module TreasuryFinancialAccount =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "treasury.financial_account"

