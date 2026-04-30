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

type SourceTransactionPaperCheckData =
    {
        /// Time at which the deposited funds will be available for use. Measured in seconds since the Unix epoch.
        AvailableAt: string option
        /// Comma-separated list of invoice IDs associated with the paper check.
        Invoices: string option
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

module SourceTransaction =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "source_transaction"

/// Occurs whenever a source transaction is updated.
type SourceTransactionUpdated = { Object: SourceTransaction }

/// Occurs whenever a source transaction is created.
type SourceTransactionCreated = { Object: SourceTransaction }

