namespace Stripe.Source

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Address
open Stripe.Shipping

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
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

[<Struct>]
type SourceAllowRedisplay =
    | Always
    | Limited
    | Unspecified

type SourceCodeVerificationFlow =
    {
        /// The number of attempts remaining to authenticate the source object with a verification code.
        AttemptsRemaining: int
        /// The status of the code verification, either `pending` (awaiting verification, `attempts_remaining` should be greater than 0), `succeeded` (successful verification) or `failed` (failed verification, cannot be verified anymore as `attempts_remaining` should be 0).
        Status: string
    }

[<Struct>]
type SourceOrderItemType =
    | Sku
    | Tax
    | Shipping

type SourceOrderItem =
    {
        /// The amount (price) for this order item.
        Amount: int option
        /// This currency of this order item. Required when `amount` is present.
        Currency: IsoTypes.IsoCurrencyCode option
        /// Human-readable description for this order item.
        Description: string option
        /// The ID of the associated object for this line item. Expandable if not null (e.g., expandable to a SKU).
        Parent: string option
        /// The quantity of this order item. When type is `sku`, this is the number of instances of the SKU to be ordered.
        Quantity: int option
        /// The type of this order item. Must be `sku`, `tax`, or `shipping`.
        Type: SourceOrderItemType option
    }

type SourceOrder =
    {
        /// A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a zero-decimal currency) representing the total amount for the order.
        Amount: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// The email address of the customer placing the order.
        Email: string option
        /// List of items constituting the order.
        Items: SourceOrderItem list option
        Shipping: Shipping option
    }

type SourceOwner =
    {
        /// Owner's address.
        Address: Address option
        /// Owner's email address.
        Email: string option
        /// Owner's full name.
        Name: string option
        /// Owner's phone number (including extension).
        Phone: string option
        /// Verified owner's address. Verified values are verified or provided by the payment method directly (and if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedAddress: Address option
        /// Verified owner's email address. Verified values are verified or provided by the payment method directly (and if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedEmail: string option
        /// Verified owner's full name. Verified values are verified or provided by the payment method directly (and if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedName: string option
        /// Verified owner's phone number (including extension). Verified values are verified or provided by the payment method directly (and if supported) at the time of authorization or settlement. They cannot be set or mutated.
        VerifiedPhone: string option
    }

[<Struct>]
type SourceReceiverFlowRefundAttributesMethod =
    | Email
    | Manual
    | [<JsonPropertyName("none")>] None'

[<Struct>]
type SourceReceiverFlowRefundAttributesStatus =
    | Missing
    | Requested
    | Available

type SourceReceiverFlow =
    {
        /// The address of the receiver source. This is the value that should be communicated to the customer to send their funds to.
        Address: string option
        /// The total amount that was moved to your balance. This is almost always equal to the amount charged. In rare cases when customers deposit excess funds and we are unable to refund those, those funds get moved to your balance and show up in amount_charged as well. The amount charged is expressed in the source's currency.
        AmountCharged: int
        /// The total amount received by the receiver source. `amount_received = amount_returned + amount_charged` should be true for consumed sources unless customers deposit excess funds. The amount received is expressed in the source's currency.
        AmountReceived: int
        /// The total amount that was returned to the customer. The amount returned is expressed in the source's currency.
        AmountReturned: int
        /// Type of refund attribute method, one of `email`, `manual`, or `none`.
        RefundAttributesMethod: SourceReceiverFlowRefundAttributesMethod
        /// Type of refund attribute status, one of `missing`, `requested`, or `available`.
        RefundAttributesStatus: SourceReceiverFlowRefundAttributesStatus
    }

type SourceRedirectFlow =
    {
        /// The failure reason for the redirect, either `user_abort` (the customer aborted or dropped out of the redirect flow), `declined` (the authentication failed or the transaction was declined), or `processing_error` (the redirect failed due to a technical error). Present only if the redirect status is `failed`.
        FailureReason: string option
        /// The URL you provide to redirect the customer to after they authenticated their payment.
        ReturnUrl: string
        /// The status of the redirect, either `pending` (ready to be used by your customer to authenticate the transaction), `succeeded` (successful authentication, cannot be reused) or `not_required` (redirect should not be used) or `failed` (failed authentication, cannot be reused).
        Status: string
        /// The URL provided to you to redirect a customer to as part of a `redirect` authentication flow.
        Url: string
    }

[<Struct>]
type SourceStatus =
    | Canceled
    | Chargeable
    | Consumed
    | Failed
    | Pending

type SourceType =
    | AchCreditTransfer
    | AchDebit
    | AcssDebit
    | Alipay
    | AuBecsDebit
    | Bancontact
    | Card
    | CardPresent
    | Eps
    | Giropay
    | Ideal
    | Klarna
    | Multibanco
    | P24
    | SepaCreditTransfer
    | SepaDebit
    | Sofort
    | ThreeDSecure
    | Wechat

type SourceTypeAchCreditTransfer =
    { AccountNumber: string option
      BankName: string option
      Fingerprint: string option
      RefundAccountHolderName: string option
      RefundAccountHolderType: string option
      RefundRoutingNumber: string option
      RoutingNumber: string option
      SwiftCode: string option }

type SourceTypeAchDebit =
    { BankName: string option
      Country: IsoTypes.IsoCountryCode option
      Fingerprint: string option
      [<JsonPropertyName("last4")>]
      Last4: string option
      RoutingNumber: string option
      Type: string option }

type SourceTypeAcssDebit =
    { BankAddressCity: string option
      BankAddressLine1: string option
      BankAddressLine2: string option
      BankAddressPostalCode: string option
      BankName: string option
      Category: string option
      Country: IsoTypes.IsoCountryCode option
      Fingerprint: string option
      [<JsonPropertyName("last4")>]
      Last4: string option
      RoutingNumber: string option }

type SourceTypeAlipay =
    { DataString: string option
      NativeUrl: string option
      StatementDescriptor: string option }

type SourceTypeAuBecsDebit =
    { BsbNumber: string option
      Fingerprint: string option
      [<JsonPropertyName("last4")>]
      Last4: string option }

type SourceTypeBancontact =
    { BankCode: string option
      BankName: string option
      Bic: string option
      [<JsonPropertyName("iban_last4")>]
      IbanLast4: string option
      PreferredLanguage: string option
      StatementDescriptor: string option }

type SourceTypeCard =
    { [<JsonPropertyName("address_line1_check")>]
      AddressLine1Check: string option
      AddressZipCheck: string option
      Brand: string option
      Country: IsoTypes.IsoCountryCode option
      CvcCheck: string option
      Description: string option
      [<JsonPropertyName("dynamic_last4")>]
      DynamicLast4: string option
      ExpMonth: int option
      ExpYear: int option
      Fingerprint: string option
      Funding: string option
      Iin: string option
      Issuer: string option
      [<JsonPropertyName("last4")>]
      Last4: string option
      Name: string option
      ThreeDSecure: string option
      TokenizationMethod: string option }

type SourceTypeCardPresent =
    { ApplicationCryptogram: string option
      ApplicationPreferredName: string option
      AuthorizationCode: string option
      AuthorizationResponseCode: string option
      Brand: string option
      Country: IsoTypes.IsoCountryCode option
      CvmType: string option
      DataType: string option
      DedicatedFileName: string option
      Description: string option
      EmvAuthData: string option
      EvidenceCustomerSignature: string option
      EvidenceTransactionCertificate: string option
      ExpMonth: int option
      ExpYear: int option
      Fingerprint: string option
      Funding: string option
      Iin: string option
      Issuer: string option
      [<JsonPropertyName("last4")>]
      Last4: string option
      PosDeviceId: string option
      PosEntryMode: string option
      ReadMethod: string option
      Reader: string option
      TerminalVerificationResults: string option
      TransactionStatusInformation: string option }

type SourceTypeEps =
    { Reference: string option
      StatementDescriptor: string option }

type SourceTypeGiropay =
    { BankCode: string option
      BankName: string option
      Bic: string option
      StatementDescriptor: string option }

type SourceTypeIdeal =
    { Bank: string option
      Bic: string option
      [<JsonPropertyName("iban_last4")>]
      IbanLast4: string option
      StatementDescriptor: string option }

type SourceTypeKlarna =
    { BackgroundImageUrl: string option
      ClientToken: string option
      FirstName: string option
      LastName: string option
      Locale: string option
      LogoUrl: string option
      PageTitle: string option
      PayLaterAssetUrlsDescriptive: string option
      PayLaterAssetUrlsStandard: string option
      PayLaterName: string option
      PayLaterRedirectUrl: string option
      PayNowAssetUrlsDescriptive: string option
      PayNowAssetUrlsStandard: string option
      PayNowName: string option
      PayNowRedirectUrl: string option
      PayOverTimeAssetUrlsDescriptive: string option
      PayOverTimeAssetUrlsStandard: string option
      PayOverTimeName: string option
      PayOverTimeRedirectUrl: string option
      PaymentMethodCategories: string option
      PurchaseCountry: IsoTypes.IsoCountryCode option
      PurchaseType: string option
      RedirectUrl: string option
      ShippingDelay: int option
      ShippingFirstName: string option
      ShippingLastName: string option }

type SourceTypeMultibanco =
    { Entity: string option
      Reference: string option
      RefundAccountHolderAddressCity: string option
      RefundAccountHolderAddressCountry: IsoTypes.IsoCountryCode option
      [<JsonPropertyName("refund_account_holder_address_line1")>]
      RefundAccountHolderAddressLine1: string option
      [<JsonPropertyName("refund_account_holder_address_line2")>]
      RefundAccountHolderAddressLine2: string option
      RefundAccountHolderAddressPostalCode: string option
      RefundAccountHolderAddressState: string option
      RefundAccountHolderName: string option
      RefundIban: string option }

type SourceTypeP24 = { Reference: string option }

type SourceTypeSepaCreditTransfer =
    { BankName: string option
      Bic: string option
      Iban: string option
      RefundAccountHolderAddressCity: string option
      RefundAccountHolderAddressCountry: IsoTypes.IsoCountryCode option
      [<JsonPropertyName("refund_account_holder_address_line1")>]
      RefundAccountHolderAddressLine1: string option
      [<JsonPropertyName("refund_account_holder_address_line2")>]
      RefundAccountHolderAddressLine2: string option
      RefundAccountHolderAddressPostalCode: string option
      RefundAccountHolderAddressState: string option
      RefundAccountHolderName: string option
      RefundIban: string option }

type SourceTypeSepaDebit =
    { BankCode: string option
      BranchCode: string option
      Country: IsoTypes.IsoCountryCode option
      Fingerprint: string option
      [<JsonPropertyName("last4")>]
      Last4: string option
      MandateReference: string option
      MandateUrl: string option }

type SourceTypeSofort =
    { BankCode: string option
      BankName: string option
      Bic: string option
      Country: IsoTypes.IsoCountryCode option
      [<JsonPropertyName("iban_last4")>]
      IbanLast4: string option
      PreferredLanguage: string option
      StatementDescriptor: string option }

type SourceTypeThreeDSecure =
    { [<JsonPropertyName("address_line1_check")>]
      AddressLine1Check: string option
      AddressZipCheck: string option
      Authenticated: bool option
      Brand: string option
      Card: string option
      Country: IsoTypes.IsoCountryCode option
      Customer: string option
      CvcCheck: string option
      Description: string option
      [<JsonPropertyName("dynamic_last4")>]
      DynamicLast4: string option
      ExpMonth: int option
      ExpYear: int option
      Fingerprint: string option
      Funding: string option
      Iin: string option
      Issuer: string option
      [<JsonPropertyName("last4")>]
      Last4: string option
      Name: string option
      ThreeDSecure: string option
      TokenizationMethod: string option }

type SourceTypeWechat =
    { PrepayId: string option
      QrCodeUrl: string option
      StatementDescriptor: string option }

[<Struct>]
type SourceUsage =
    | Reusable
    | SingleUse

/// `Source` objects allow you to accept a variety of payment methods. They
/// represent a customer's payment instrument, and can be used with the Stripe API
/// just like a `Card` object: once chargeable, they can be charged, or can be
/// attached to customers.
/// Stripe doesn't recommend using the deprecated [Sources API](https://docs.stripe.com/api/sources).
/// We recommend that you adopt the [PaymentMethods API](https://docs.stripe.com/api/payment_methods).
/// This newer API provides access to our latest features and payment method types.
/// Related guides: [Sources API](https://docs.stripe.com/sources) and [Sources & Customers](https://docs.stripe.com/sources/customers).
type Source =
    {
        AchCreditTransfer: SourceTypeAchCreditTransfer option
        AchDebit: SourceTypeAchDebit option
        AcssDebit: SourceTypeAcssDebit option
        Alipay: SourceTypeAlipay option
        /// This field indicates whether this payment method can be shown again to its customer in a checkout flow. Stripe products such as Checkout and Elements use this field to determine whether a payment method can be shown as a saved payment method in a checkout flow. The field defaults to “unspecified”.
        AllowRedisplay: SourceAllowRedisplay option
        /// A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a zero-decimal currency) representing the total amount associated with the source. This is the amount for which the source will be chargeable once ready. Required for `single_use` sources.
        Amount: int option
        AuBecsDebit: SourceTypeAuBecsDebit option
        Bancontact: SourceTypeBancontact option
        Card: SourceTypeCard option
        CardPresent: SourceTypeCardPresent option
        /// The client secret of the source. Used for client-side retrieval using a publishable key.
        ClientSecret: string
        CodeVerification: SourceCodeVerificationFlow option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) associated with the source. This is the currency for which the source will be chargeable once ready. Required for `single_use` sources.
        Currency: IsoTypes.IsoCurrencyCode option
        /// The ID of the customer to which this source is attached. This will not be present when the source has not been attached to a customer.
        Customer: string option
        Eps: SourceTypeEps option
        /// The authentication `flow` of the source. `flow` is one of `redirect`, `receiver`, `code_verification`, `none`.
        Flow: string
        Giropay: SourceTypeGiropay option
        /// Unique identifier for the object.
        Id: string
        Ideal: SourceTypeIdeal option
        Klarna: SourceTypeKlarna option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        Multibanco: SourceTypeMultibanco option
        /// Information about the owner of the payment instrument that may be used or required by particular source types.
        Owner: SourceOwner option
        [<JsonPropertyName("p24")>]
        P24: SourceTypeP24 option
        Receiver: SourceReceiverFlow option
        Redirect: SourceRedirectFlow option
        SepaCreditTransfer: SourceTypeSepaCreditTransfer option
        SepaDebit: SourceTypeSepaDebit option
        Sofort: SourceTypeSofort option
        SourceOrder: SourceOrder option
        /// Extra information about a source. This will appear on your customer's statement every time you charge the source.
        StatementDescriptor: string option
        /// The status of the source, one of `canceled`, `chargeable`, `consumed`, `failed`, or `pending`. Only `chargeable` sources can be used to create a charge.
        Status: SourceStatus
        ThreeDSecure: SourceTypeThreeDSecure option
        /// The `type` of the source. The `type` is a payment method, one of `ach_credit_transfer`, `ach_debit`, `alipay`, `bancontact`, `card`, `card_present`, `eps`, `giropay`, `ideal`, `multibanco`, `klarna`, `p24`, `sepa_debit`, `sofort`, `three_d_secure`, or `wechat`. An additional hash is included on the source with a name matching this value. It contains additional information specific to the [payment method](https://docs.stripe.com/sources) used.
        Type: SourceType
        /// Either `reusable` or `single_use`. Whether this source should be reusable or not. Some source types may or may not be reusable by construction, while others may leave the option at creation. If an incompatible value is passed, an error will be returned.
        Usage: SourceUsage option
        Wechat: SourceTypeWechat option
    }

module Source =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "source"

/// Occurs whenever the refund attributes are required on a receiver source to process a refund or a mispayment.
type SourceRefundAttributesRequired = { Object: Source }

type SourceMandateNotificationAcssDebitData =
    {
        /// The statement descriptor associate with the debit.
        StatementDescriptor: string option
    }

type SourceMandateNotificationBacsDebitData =
    {
        /// Last 4 digits of the account number associated with the debit.
        [<JsonPropertyName("last4")>]
        Last4: string option
    }

[<Struct>]
type SourceMandateNotificationReason =
    | MandateConfirmed
    | DebitInitiated

type SourceMandateNotificationSepaDebitData =
    {
        /// SEPA creditor ID.
        CreditorIdentifier: string option
        /// Last 4 digits of the account number associated with the debit.
        [<JsonPropertyName("last4")>]
        Last4: string option
        /// Mandate reference associated with the debit.
        MandateReference: string option
    }

[<Struct>]
type SourceMandateNotificationStatus =
    | Pending
    | Submitted

/// Source mandate notifications should be created when a notification related to
/// a source mandate must be sent to the payer. They will trigger a webhook or
/// deliver an email to the customer.
type SourceMandateNotification =
    {
        AcssDebit: SourceMandateNotificationAcssDebitData option
        /// A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a zero-decimal currency) representing the amount associated with the mandate notification. The amount is expressed in the currency of the underlying source. Required if the notification type is `debit_initiated`.
        Amount: int option
        BacsDebit: SourceMandateNotificationBacsDebitData option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The reason of the mandate notification. Valid reasons are `mandate_confirmed` or `debit_initiated`.
        Reason: SourceMandateNotificationReason
        SepaDebit: SourceMandateNotificationSepaDebitData option
        Source: Source
        /// The status of the mandate notification. Valid statuses are `pending` or `submitted`.
        Status: SourceMandateNotificationStatus
        /// The type of source this mandate notification is attached to. Should be the source type identifier code for the payment method, such as `three_d_secure`.
        Type: string
    }

module SourceMandateNotification =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "source_mandate_notification"

/// Occurs whenever a source fails.
type SourceFailed = { Object: Source }

/// Occurs whenever a source transitions to chargeable.
type SourceChargeable = { Object: Source }

/// Occurs whenever a source is canceled.
type SourceCanceled = { Object: Source }

