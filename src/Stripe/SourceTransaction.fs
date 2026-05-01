namespace Stripe.SourceTransaction

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type SourceTransactionAchCreditTransferData =
    {
        /// Customer data associated with the transfer.
        CustomerData: string option
        /// Bank account fingerprint associated with the transfer.
        Fingerprint: string option
        /// Last 4 digits of the account number associated with the transfer.
        [<JsonPropertyName("last4")>]
        Last4: string option
        /// Routing number associated with the transfer.
        RoutingNumber: string option
    }

type SourceTransactionAchCreditTransferData with
    static member New(?customerData: string, ?fingerprint: string, ?last4: string, ?routingNumber: string) =
        {
            CustomerData = customerData
            Fingerprint = fingerprint
            Last4 = last4
            RoutingNumber = routingNumber
        }

type SourceTransactionChfCreditTransferData =
    {
        /// Reference associated with the transfer.
        Reference: string option
        /// Sender's country address.
        SenderAddressCountry: IsoTypes.IsoCountryCode option
        /// Sender's line 1 address.
        [<JsonPropertyName("sender_address_line1")>]
        SenderAddressLine1: string option
        /// Sender's bank account IBAN.
        SenderIban: string option
        /// Sender's name.
        SenderName: string option
    }

type SourceTransactionChfCreditTransferData with
    static member New(?reference: string, ?senderAddressCountry: IsoTypes.IsoCountryCode, ?senderAddressLine1: string, ?senderIban: string, ?senderName: string) =
        {
            Reference = reference
            SenderAddressCountry = senderAddressCountry
            SenderAddressLine1 = senderAddressLine1
            SenderIban = senderIban
            SenderName = senderName
        }

type SourceTransactionGbpCreditTransferData =
    {
        /// Bank account fingerprint associated with the Stripe owned bank account receiving the transfer.
        Fingerprint: string option
        /// The credit transfer rails the sender used to push this transfer. The possible rails are: Faster Payments, BACS, CHAPS, and wire transfers. Currently only Faster Payments is supported.
        FundingMethod: string option
        /// Last 4 digits of sender account number associated with the transfer.
        [<JsonPropertyName("last4")>]
        Last4: string option
        /// Sender entered arbitrary information about the transfer.
        Reference: string option
        /// Sender account number associated with the transfer.
        SenderAccountNumber: string option
        /// Sender name associated with the transfer.
        SenderName: string option
        /// Sender sort code associated with the transfer.
        SenderSortCode: string option
    }

type SourceTransactionGbpCreditTransferData with
    static member New(?fingerprint: string, ?fundingMethod: string, ?last4: string, ?reference: string, ?senderAccountNumber: string, ?senderName: string, ?senderSortCode: string) =
        {
            Fingerprint = fingerprint
            FundingMethod = fundingMethod
            Last4 = last4
            Reference = reference
            SenderAccountNumber = senderAccountNumber
            SenderName = senderName
            SenderSortCode = senderSortCode
        }

type SourceTransactionPaperCheckData =
    {
        /// Time at which the deposited funds will be available for use. Measured in seconds since the Unix epoch.
        AvailableAt: string option
        /// Comma-separated list of invoice IDs associated with the paper check.
        Invoices: string option
    }

type SourceTransactionPaperCheckData with
    static member New(?availableAt: string, ?invoices: string) =
        {
            AvailableAt = availableAt
            Invoices = invoices
        }

type SourceTransactionSepaCreditTransferData =
    {
        /// Reference associated with the transfer.
        Reference: string option
        /// Sender's bank account IBAN.
        SenderIban: string option
        /// Sender's name.
        SenderName: string option
    }

type SourceTransactionSepaCreditTransferData with
    static member New(?reference: string, ?senderIban: string, ?senderName: string) =
        {
            Reference = reference
            SenderIban = senderIban
            SenderName = senderName
        }

[<Struct>]
type SourceTransactionStatus =
    | Succeeded
    | Pending
    | Failed

type SourceTransactionType =
    | AchCreditTransfer
    | AchDebit
    | Alipay
    | Bancontact
    | Card
    | CardPresent
    | Eps
    | Giropay
    | Ideal
    | Klarna
    | Multibanco
    | P24
    | SepaDebit
    | Sofort
    | ThreeDSecure
    | Wechat

/// Some payment methods have no required amount that a customer must send.
/// Customers can be instructed to send any amount, and it can be made up of
/// multiple transactions. As such, sources can have multiple associated
/// transactions.
type SourceTransaction =
    {
        AchCreditTransfer: SourceTransactionAchCreditTransferData option
        /// A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a zero-decimal currency) representing the amount your customer has pushed to the receiver.
        Amount: int
        ChfCreditTransfer: SourceTransactionChfCreditTransferData option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        GbpCreditTransfer: SourceTransactionGbpCreditTransferData option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        PaperCheck: SourceTransactionPaperCheckData option
        SepaCreditTransfer: SourceTransactionSepaCreditTransferData option
        /// The ID of the source this transaction is attached to.
        Source: string
        /// The status of the transaction, one of `succeeded`, `pending`, or `failed`.
        Status: SourceTransactionStatus
        /// The type of source this transaction is attached to.
        Type: SourceTransactionType
    }

type SourceTransaction with
    static member New(amount: int, created: DateTime, currency: IsoTypes.IsoCurrencyCode, id: string, livemode: bool, source: string, status: SourceTransactionStatus, ``type``: SourceTransactionType, ?achCreditTransfer: SourceTransactionAchCreditTransferData, ?chfCreditTransfer: SourceTransactionChfCreditTransferData, ?gbpCreditTransfer: SourceTransactionGbpCreditTransferData, ?paperCheck: SourceTransactionPaperCheckData, ?sepaCreditTransfer: SourceTransactionSepaCreditTransferData) =
        {
            Amount = amount
            Created = created
            Currency = currency
            Id = id
            Livemode = livemode
            Source = source
            Status = status
            Type = ``type``
            AchCreditTransfer = achCreditTransfer
            ChfCreditTransfer = chfCreditTransfer
            GbpCreditTransfer = gbpCreditTransfer
            PaperCheck = paperCheck
            SepaCreditTransfer = sepaCreditTransfer
        }

module SourceTransaction =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "source_transaction"

/// Occurs whenever a source transaction is updated.
type SourceTransactionUpdated = { Object: SourceTransaction }

type SourceTransactionUpdated with
    static member New(object: SourceTransaction) =
        {
            Object = object
        }

/// Occurs whenever a source transaction is created.
type SourceTransactionCreated = { Object: SourceTransaction }

type SourceTransactionCreated with
    static member New(object: SourceTransaction) =
        {
            Object = object
        }

