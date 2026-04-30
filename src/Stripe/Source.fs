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

module SourceTransactionAchCreditTransferData =
    let create
        (
            customerData: string option,
            fingerprint: string option,
            last4: string option,
            routingNumber: string option
        ) : SourceTransactionAchCreditTransferData
        =
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

module SourceTransactionChfCreditTransferData =
    let create
        (
            reference: string option,
            senderAddressCountry: IsoTypes.IsoCountryCode option,
            senderAddressLine1: string option,
            senderIban: string option,
            senderName: string option
        ) : SourceTransactionChfCreditTransferData
        =
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

module SourceTransactionGbpCreditTransferData =
    let create
        (
            fingerprint: string option,
            fundingMethod: string option,
            last4: string option,
            reference: string option,
            senderAccountNumber: string option,
            senderName: string option,
            senderSortCode: string option
        ) : SourceTransactionGbpCreditTransferData
        =
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

module SourceTransactionPaperCheckData =
    let create
        (
            availableAt: string option,
            invoices: string option
        ) : SourceTransactionPaperCheckData
        =
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

module SourceTransactionSepaCreditTransferData =
    let create
        (
            reference: string option,
            senderIban: string option,
            senderName: string option
        ) : SourceTransactionSepaCreditTransferData
        =
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

module SourceTransaction =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "source_transaction"

    let create
        (
            amount: int,
            created: DateTime,
            currency: IsoTypes.IsoCurrencyCode,
            id: string,
            livemode: bool,
            source: string,
            status: SourceTransactionStatus,
            ``type``: SourceTransactionType
        ) : SourceTransaction
        =
        {
          Amount = amount
          Created = created
          Currency = currency
          Id = id
          Livemode = livemode
          Source = source
          Status = status
          Type = ``type``
          AchCreditTransfer = None
          ChfCreditTransfer = None
          GbpCreditTransfer = None
          PaperCheck = None
          SepaCreditTransfer = None
        }

/// Occurs whenever a source transaction is updated.
type SourceTransactionUpdated = { Object: SourceTransaction }

module SourceTransactionUpdated =
    let create
        (
            object: SourceTransaction
        ) : SourceTransactionUpdated
        =
        {
          Object = object
        }

/// Occurs whenever a source transaction is created.
type SourceTransactionCreated = { Object: SourceTransaction }

module SourceTransactionCreated =
    let create
        (
            object: SourceTransaction
        ) : SourceTransactionCreated
        =
        {
          Object = object
        }

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

module SourceCodeVerificationFlow =
    let create
        (
            attemptsRemaining: int,
            status: string
        ) : SourceCodeVerificationFlow
        =
        {
          AttemptsRemaining = attemptsRemaining
          Status = status
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

module SourceOrderItem =
    let create
        (
            amount: int option,
            currency: IsoTypes.IsoCurrencyCode option,
            description: string option,
            parent: string option,
            ``type``: SourceOrderItemType option
        ) : SourceOrderItem
        =
        {
          Amount = amount
          Currency = currency
          Description = description
          Parent = parent
          Type = ``type``
          Quantity = None
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

module SourceOrder =
    let create
        (
            amount: int,
            currency: IsoTypes.IsoCurrencyCode,
            items: SourceOrderItem list option
        ) : SourceOrder
        =
        {
          Amount = amount
          Currency = currency
          Items = items
          Email = None
          Shipping = None
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

module SourceOwner =
    let create
        (
            address: Address option,
            email: string option,
            name: string option,
            phone: string option,
            verifiedAddress: Address option,
            verifiedEmail: string option,
            verifiedName: string option,
            verifiedPhone: string option
        ) : SourceOwner
        =
        {
          Address = address
          Email = email
          Name = name
          Phone = phone
          VerifiedAddress = verifiedAddress
          VerifiedEmail = verifiedEmail
          VerifiedName = verifiedName
          VerifiedPhone = verifiedPhone
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

module SourceReceiverFlow =
    let create
        (
            address: string option,
            amountCharged: int,
            amountReceived: int,
            amountReturned: int,
            refundAttributesMethod: SourceReceiverFlowRefundAttributesMethod,
            refundAttributesStatus: SourceReceiverFlowRefundAttributesStatus
        ) : SourceReceiverFlow
        =
        {
          Address = address
          AmountCharged = amountCharged
          AmountReceived = amountReceived
          AmountReturned = amountReturned
          RefundAttributesMethod = refundAttributesMethod
          RefundAttributesStatus = refundAttributesStatus
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

module SourceRedirectFlow =
    let create
        (
            failureReason: string option,
            returnUrl: string,
            status: string,
            url: string
        ) : SourceRedirectFlow
        =
        {
          FailureReason = failureReason
          ReturnUrl = returnUrl
          Status = status
          Url = url
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

module SourceTypeAchCreditTransfer =
    let create
        (
            accountNumber: string option option,
            bankName: string option option,
            fingerprint: string option option,
            refundAccountHolderName: string option option,
            refundAccountHolderType: string option option,
            refundRoutingNumber: string option option,
            routingNumber: string option option,
            swiftCode: string option option
        ) : SourceTypeAchCreditTransfer
        =
        {
          AccountNumber = accountNumber |> Option.flatten
          BankName = bankName |> Option.flatten
          Fingerprint = fingerprint |> Option.flatten
          RefundAccountHolderName = refundAccountHolderName |> Option.flatten
          RefundAccountHolderType = refundAccountHolderType |> Option.flatten
          RefundRoutingNumber = refundRoutingNumber |> Option.flatten
          RoutingNumber = routingNumber |> Option.flatten
          SwiftCode = swiftCode |> Option.flatten
        }

type SourceTypeAchDebit =
    { BankName: string option
      Country: IsoTypes.IsoCountryCode option
      Fingerprint: string option
      [<JsonPropertyName("last4")>]
      Last4: string option
      RoutingNumber: string option
      Type: string option }

module SourceTypeAchDebit =
    let create
        (
            bankName: string option option,
            country: IsoTypes.IsoCountryCode option option,
            fingerprint: string option option,
            last4: string option option,
            routingNumber: string option option,
            ``type``: string option option
        ) : SourceTypeAchDebit
        =
        {
          BankName = bankName |> Option.flatten
          Country = country |> Option.flatten
          Fingerprint = fingerprint |> Option.flatten
          Last4 = last4 |> Option.flatten
          RoutingNumber = routingNumber |> Option.flatten
          Type = ``type`` |> Option.flatten
        }

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

module SourceTypeAcssDebit =
    let create
        (
            bankAddressCity: string option option,
            bankAddressLine1: string option option,
            bankAddressLine2: string option option,
            bankAddressPostalCode: string option option,
            bankName: string option option,
            category: string option option,
            country: IsoTypes.IsoCountryCode option option,
            fingerprint: string option option,
            last4: string option option,
            routingNumber: string option option
        ) : SourceTypeAcssDebit
        =
        {
          BankAddressCity = bankAddressCity |> Option.flatten
          BankAddressLine1 = bankAddressLine1 |> Option.flatten
          BankAddressLine2 = bankAddressLine2 |> Option.flatten
          BankAddressPostalCode = bankAddressPostalCode |> Option.flatten
          BankName = bankName |> Option.flatten
          Category = category |> Option.flatten
          Country = country |> Option.flatten
          Fingerprint = fingerprint |> Option.flatten
          Last4 = last4 |> Option.flatten
          RoutingNumber = routingNumber |> Option.flatten
        }

type SourceTypeAlipay =
    { DataString: string option
      NativeUrl: string option
      StatementDescriptor: string option }

module SourceTypeAlipay =
    let create
        (
            dataString: string option option,
            nativeUrl: string option option,
            statementDescriptor: string option option
        ) : SourceTypeAlipay
        =
        {
          DataString = dataString |> Option.flatten
          NativeUrl = nativeUrl |> Option.flatten
          StatementDescriptor = statementDescriptor |> Option.flatten
        }

type SourceTypeAuBecsDebit =
    { BsbNumber: string option
      Fingerprint: string option
      [<JsonPropertyName("last4")>]
      Last4: string option }

module SourceTypeAuBecsDebit =
    let create
        (
            bsbNumber: string option option,
            fingerprint: string option option,
            last4: string option option
        ) : SourceTypeAuBecsDebit
        =
        {
          BsbNumber = bsbNumber |> Option.flatten
          Fingerprint = fingerprint |> Option.flatten
          Last4 = last4 |> Option.flatten
        }

type SourceTypeBancontact =
    { BankCode: string option
      BankName: string option
      Bic: string option
      [<JsonPropertyName("iban_last4")>]
      IbanLast4: string option
      PreferredLanguage: string option
      StatementDescriptor: string option }

module SourceTypeBancontact =
    let create
        (
            bankCode: string option option,
            bankName: string option option,
            bic: string option option,
            ibanLast4: string option option,
            preferredLanguage: string option option,
            statementDescriptor: string option option
        ) : SourceTypeBancontact
        =
        {
          BankCode = bankCode |> Option.flatten
          BankName = bankName |> Option.flatten
          Bic = bic |> Option.flatten
          IbanLast4 = ibanLast4 |> Option.flatten
          PreferredLanguage = preferredLanguage |> Option.flatten
          StatementDescriptor = statementDescriptor |> Option.flatten
        }

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

module SourceTypeCard =
    let create
        (
            addressLine1Check: string option option,
            addressZipCheck: string option option,
            brand: string option option,
            country: IsoTypes.IsoCountryCode option option,
            cvcCheck: string option option,
            description: string option,
            dynamicLast4: string option option,
            expMonth: int option option,
            expYear: int option option,
            fingerprint: string option,
            funding: string option option,
            iin: string option,
            issuer: string option,
            last4: string option option,
            name: string option option,
            threeDSecure: string option,
            tokenizationMethod: string option option
        ) : SourceTypeCard
        =
        {
          AddressLine1Check = addressLine1Check |> Option.flatten
          AddressZipCheck = addressZipCheck |> Option.flatten
          Brand = brand |> Option.flatten
          Country = country |> Option.flatten
          CvcCheck = cvcCheck |> Option.flatten
          Description = description
          DynamicLast4 = dynamicLast4 |> Option.flatten
          ExpMonth = expMonth |> Option.flatten
          ExpYear = expYear |> Option.flatten
          Fingerprint = fingerprint
          Funding = funding |> Option.flatten
          Iin = iin
          Issuer = issuer
          Last4 = last4 |> Option.flatten
          Name = name |> Option.flatten
          ThreeDSecure = threeDSecure
          TokenizationMethod = tokenizationMethod |> Option.flatten
        }

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

module SourceTypeCardPresent =
    let create
        (
            applicationCryptogram: string option,
            applicationPreferredName: string option,
            authorizationCode: string option option,
            authorizationResponseCode: string option,
            brand: string option option,
            country: IsoTypes.IsoCountryCode option option,
            cvmType: string option,
            dataType: string option option,
            dedicatedFileName: string option,
            description: string option,
            emvAuthData: string option,
            evidenceCustomerSignature: string option option,
            evidenceTransactionCertificate: string option option,
            expMonth: int option option,
            expYear: int option option,
            fingerprint: string option,
            funding: string option option,
            iin: string option,
            issuer: string option,
            last4: string option option,
            posDeviceId: string option option,
            posEntryMode: string option,
            readMethod: string option option,
            reader: string option option,
            terminalVerificationResults: string option,
            transactionStatusInformation: string option
        ) : SourceTypeCardPresent
        =
        {
          ApplicationCryptogram = applicationCryptogram
          ApplicationPreferredName = applicationPreferredName
          AuthorizationCode = authorizationCode |> Option.flatten
          AuthorizationResponseCode = authorizationResponseCode
          Brand = brand |> Option.flatten
          Country = country |> Option.flatten
          CvmType = cvmType
          DataType = dataType |> Option.flatten
          DedicatedFileName = dedicatedFileName
          Description = description
          EmvAuthData = emvAuthData
          EvidenceCustomerSignature = evidenceCustomerSignature |> Option.flatten
          EvidenceTransactionCertificate = evidenceTransactionCertificate |> Option.flatten
          ExpMonth = expMonth |> Option.flatten
          ExpYear = expYear |> Option.flatten
          Fingerprint = fingerprint
          Funding = funding |> Option.flatten
          Iin = iin
          Issuer = issuer
          Last4 = last4 |> Option.flatten
          PosDeviceId = posDeviceId |> Option.flatten
          PosEntryMode = posEntryMode
          ReadMethod = readMethod |> Option.flatten
          Reader = reader |> Option.flatten
          TerminalVerificationResults = terminalVerificationResults
          TransactionStatusInformation = transactionStatusInformation
        }

type SourceTypeEps =
    { Reference: string option
      StatementDescriptor: string option }

module SourceTypeEps =
    let create
        (
            reference: string option option,
            statementDescriptor: string option option
        ) : SourceTypeEps
        =
        {
          Reference = reference |> Option.flatten
          StatementDescriptor = statementDescriptor |> Option.flatten
        }

type SourceTypeGiropay =
    { BankCode: string option
      BankName: string option
      Bic: string option
      StatementDescriptor: string option }

module SourceTypeGiropay =
    let create
        (
            bankCode: string option option,
            bankName: string option option,
            bic: string option option,
            statementDescriptor: string option option
        ) : SourceTypeGiropay
        =
        {
          BankCode = bankCode |> Option.flatten
          BankName = bankName |> Option.flatten
          Bic = bic |> Option.flatten
          StatementDescriptor = statementDescriptor |> Option.flatten
        }

type SourceTypeIdeal =
    { Bank: string option
      Bic: string option
      [<JsonPropertyName("iban_last4")>]
      IbanLast4: string option
      StatementDescriptor: string option }

module SourceTypeIdeal =
    let create
        (
            bank: string option option,
            bic: string option option,
            ibanLast4: string option option,
            statementDescriptor: string option option
        ) : SourceTypeIdeal
        =
        {
          Bank = bank |> Option.flatten
          Bic = bic |> Option.flatten
          IbanLast4 = ibanLast4 |> Option.flatten
          StatementDescriptor = statementDescriptor |> Option.flatten
        }

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

module SourceTypeKlarna =
    let create
        (
            backgroundImageUrl: string option,
            clientToken: string option option,
            firstName: string option,
            lastName: string option,
            locale: string option,
            logoUrl: string option,
            pageTitle: string option,
            payLaterAssetUrlsDescriptive: string option,
            payLaterAssetUrlsStandard: string option,
            payLaterName: string option,
            payLaterRedirectUrl: string option,
            payNowAssetUrlsDescriptive: string option,
            payNowAssetUrlsStandard: string option,
            payNowName: string option,
            payNowRedirectUrl: string option,
            payOverTimeAssetUrlsDescriptive: string option,
            payOverTimeAssetUrlsStandard: string option,
            payOverTimeName: string option,
            payOverTimeRedirectUrl: string option,
            paymentMethodCategories: string option,
            purchaseCountry: IsoTypes.IsoCountryCode option,
            purchaseType: string option,
            redirectUrl: string option,
            shippingDelay: int option,
            shippingFirstName: string option,
            shippingLastName: string option
        ) : SourceTypeKlarna
        =
        {
          BackgroundImageUrl = backgroundImageUrl
          ClientToken = clientToken |> Option.flatten
          FirstName = firstName
          LastName = lastName
          Locale = locale
          LogoUrl = logoUrl
          PageTitle = pageTitle
          PayLaterAssetUrlsDescriptive = payLaterAssetUrlsDescriptive
          PayLaterAssetUrlsStandard = payLaterAssetUrlsStandard
          PayLaterName = payLaterName
          PayLaterRedirectUrl = payLaterRedirectUrl
          PayNowAssetUrlsDescriptive = payNowAssetUrlsDescriptive
          PayNowAssetUrlsStandard = payNowAssetUrlsStandard
          PayNowName = payNowName
          PayNowRedirectUrl = payNowRedirectUrl
          PayOverTimeAssetUrlsDescriptive = payOverTimeAssetUrlsDescriptive
          PayOverTimeAssetUrlsStandard = payOverTimeAssetUrlsStandard
          PayOverTimeName = payOverTimeName
          PayOverTimeRedirectUrl = payOverTimeRedirectUrl
          PaymentMethodCategories = paymentMethodCategories
          PurchaseCountry = purchaseCountry
          PurchaseType = purchaseType
          RedirectUrl = redirectUrl
          ShippingDelay = shippingDelay
          ShippingFirstName = shippingFirstName
          ShippingLastName = shippingLastName
        }

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

module SourceTypeMultibanco =
    let create
        (
            entity: string option option,
            reference: string option option,
            refundAccountHolderAddressCity: string option option,
            refundAccountHolderAddressCountry: IsoTypes.IsoCountryCode option option,
            refundAccountHolderAddressLine1: string option option,
            refundAccountHolderAddressLine2: string option option,
            refundAccountHolderAddressPostalCode: string option option,
            refundAccountHolderAddressState: string option option,
            refundAccountHolderName: string option option,
            refundIban: string option option
        ) : SourceTypeMultibanco
        =
        {
          Entity = entity |> Option.flatten
          Reference = reference |> Option.flatten
          RefundAccountHolderAddressCity = refundAccountHolderAddressCity |> Option.flatten
          RefundAccountHolderAddressCountry = refundAccountHolderAddressCountry |> Option.flatten
          RefundAccountHolderAddressLine1 = refundAccountHolderAddressLine1 |> Option.flatten
          RefundAccountHolderAddressLine2 = refundAccountHolderAddressLine2 |> Option.flatten
          RefundAccountHolderAddressPostalCode = refundAccountHolderAddressPostalCode |> Option.flatten
          RefundAccountHolderAddressState = refundAccountHolderAddressState |> Option.flatten
          RefundAccountHolderName = refundAccountHolderName |> Option.flatten
          RefundIban = refundIban |> Option.flatten
        }

type SourceTypeP24 = { Reference: string option }

module SourceTypeP24 =
    let create
        (
            reference: string option option
        ) : SourceTypeP24
        =
        {
          Reference = reference |> Option.flatten
        }

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

module SourceTypeSepaCreditTransfer =
    let create
        (
            bankName: string option option,
            bic: string option option,
            iban: string option option,
            refundAccountHolderAddressCity: string option option,
            refundAccountHolderAddressCountry: IsoTypes.IsoCountryCode option option,
            refundAccountHolderAddressLine1: string option option,
            refundAccountHolderAddressLine2: string option option,
            refundAccountHolderAddressPostalCode: string option option,
            refundAccountHolderAddressState: string option option,
            refundAccountHolderName: string option option,
            refundIban: string option option
        ) : SourceTypeSepaCreditTransfer
        =
        {
          BankName = bankName |> Option.flatten
          Bic = bic |> Option.flatten
          Iban = iban |> Option.flatten
          RefundAccountHolderAddressCity = refundAccountHolderAddressCity |> Option.flatten
          RefundAccountHolderAddressCountry = refundAccountHolderAddressCountry |> Option.flatten
          RefundAccountHolderAddressLine1 = refundAccountHolderAddressLine1 |> Option.flatten
          RefundAccountHolderAddressLine2 = refundAccountHolderAddressLine2 |> Option.flatten
          RefundAccountHolderAddressPostalCode = refundAccountHolderAddressPostalCode |> Option.flatten
          RefundAccountHolderAddressState = refundAccountHolderAddressState |> Option.flatten
          RefundAccountHolderName = refundAccountHolderName |> Option.flatten
          RefundIban = refundIban |> Option.flatten
        }

type SourceTypeSepaDebit =
    { BankCode: string option
      BranchCode: string option
      Country: IsoTypes.IsoCountryCode option
      Fingerprint: string option
      [<JsonPropertyName("last4")>]
      Last4: string option
      MandateReference: string option
      MandateUrl: string option }

module SourceTypeSepaDebit =
    let create
        (
            bankCode: string option option,
            branchCode: string option option,
            country: IsoTypes.IsoCountryCode option option,
            fingerprint: string option option,
            last4: string option option,
            mandateReference: string option option,
            mandateUrl: string option option
        ) : SourceTypeSepaDebit
        =
        {
          BankCode = bankCode |> Option.flatten
          BranchCode = branchCode |> Option.flatten
          Country = country |> Option.flatten
          Fingerprint = fingerprint |> Option.flatten
          Last4 = last4 |> Option.flatten
          MandateReference = mandateReference |> Option.flatten
          MandateUrl = mandateUrl |> Option.flatten
        }

type SourceTypeSofort =
    { BankCode: string option
      BankName: string option
      Bic: string option
      Country: IsoTypes.IsoCountryCode option
      [<JsonPropertyName("iban_last4")>]
      IbanLast4: string option
      PreferredLanguage: string option
      StatementDescriptor: string option }

module SourceTypeSofort =
    let create
        (
            bankCode: string option option,
            bankName: string option option,
            bic: string option option,
            country: IsoTypes.IsoCountryCode option option,
            ibanLast4: string option option,
            preferredLanguage: string option option,
            statementDescriptor: string option option
        ) : SourceTypeSofort
        =
        {
          BankCode = bankCode |> Option.flatten
          BankName = bankName |> Option.flatten
          Bic = bic |> Option.flatten
          Country = country |> Option.flatten
          IbanLast4 = ibanLast4 |> Option.flatten
          PreferredLanguage = preferredLanguage |> Option.flatten
          StatementDescriptor = statementDescriptor |> Option.flatten
        }

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

module SourceTypeThreeDSecure =
    let create
        (
            addressLine1Check: string option option,
            addressZipCheck: string option option,
            authenticated: bool option option,
            brand: string option option,
            card: string option option,
            country: IsoTypes.IsoCountryCode option option,
            customer: string option option,
            cvcCheck: string option option,
            description: string option,
            dynamicLast4: string option option,
            expMonth: int option option,
            expYear: int option option,
            fingerprint: string option,
            funding: string option option,
            iin: string option,
            issuer: string option,
            last4: string option option,
            name: string option option,
            threeDSecure: string option,
            tokenizationMethod: string option option
        ) : SourceTypeThreeDSecure
        =
        {
          AddressLine1Check = addressLine1Check |> Option.flatten
          AddressZipCheck = addressZipCheck |> Option.flatten
          Authenticated = authenticated |> Option.flatten
          Brand = brand |> Option.flatten
          Card = card |> Option.flatten
          Country = country |> Option.flatten
          Customer = customer |> Option.flatten
          CvcCheck = cvcCheck |> Option.flatten
          Description = description
          DynamicLast4 = dynamicLast4 |> Option.flatten
          ExpMonth = expMonth |> Option.flatten
          ExpYear = expYear |> Option.flatten
          Fingerprint = fingerprint
          Funding = funding |> Option.flatten
          Iin = iin
          Issuer = issuer
          Last4 = last4 |> Option.flatten
          Name = name |> Option.flatten
          ThreeDSecure = threeDSecure
          TokenizationMethod = tokenizationMethod |> Option.flatten
        }

type SourceTypeWechat =
    { PrepayId: string option
      QrCodeUrl: string option
      StatementDescriptor: string option }

module SourceTypeWechat =
    let create
        (
            prepayId: string option,
            qrCodeUrl: string option option,
            statementDescriptor: string option
        ) : SourceTypeWechat
        =
        {
          PrepayId = prepayId
          QrCodeUrl = qrCodeUrl |> Option.flatten
          StatementDescriptor = statementDescriptor
        }

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

    let create
        (
            allowRedisplay: SourceAllowRedisplay option,
            amount: int option,
            clientSecret: string,
            created: DateTime,
            currency: IsoTypes.IsoCurrencyCode option,
            flow: string,
            id: string,
            livemode: bool,
            metadata: Map<string, string> option,
            owner: SourceOwner option,
            statementDescriptor: string option,
            status: SourceStatus,
            ``type``: SourceType,
            usage: SourceUsage option
        ) : Source
        =
        {
          AllowRedisplay = allowRedisplay
          Amount = amount
          ClientSecret = clientSecret
          Created = created
          Currency = currency
          Flow = flow
          Id = id
          Livemode = livemode
          Metadata = metadata
          Owner = owner
          StatementDescriptor = statementDescriptor
          Status = status
          Type = ``type``
          Usage = usage
          AchCreditTransfer = None
          AchDebit = None
          AcssDebit = None
          Alipay = None
          AuBecsDebit = None
          Bancontact = None
          Card = None
          CardPresent = None
          CodeVerification = None
          Customer = None
          Eps = None
          Giropay = None
          Ideal = None
          Klarna = None
          Multibanco = None
          P24 = None
          Receiver = None
          Redirect = None
          SepaCreditTransfer = None
          SepaDebit = None
          Sofort = None
          SourceOrder = None
          ThreeDSecure = None
          Wechat = None
        }

/// Occurs whenever the refund attributes are required on a receiver source to process a refund or a mispayment.
type SourceRefundAttributesRequired = { Object: Source }

module SourceRefundAttributesRequired =
    let create
        (
            object: Source
        ) : SourceRefundAttributesRequired
        =
        {
          Object = object
        }

type SourceMandateNotificationAcssDebitData =
    {
        /// The statement descriptor associate with the debit.
        StatementDescriptor: string option
    }

module SourceMandateNotificationAcssDebitData =
    let create
        (
            statementDescriptor: string option
        ) : SourceMandateNotificationAcssDebitData
        =
        {
          StatementDescriptor = statementDescriptor
        }

type SourceMandateNotificationBacsDebitData =
    {
        /// Last 4 digits of the account number associated with the debit.
        [<JsonPropertyName("last4")>]
        Last4: string option
    }

module SourceMandateNotificationBacsDebitData =
    let create
        (
            last4: string option
        ) : SourceMandateNotificationBacsDebitData
        =
        {
          Last4 = last4
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

module SourceMandateNotificationSepaDebitData =
    let create
        (
            creditorIdentifier: string option,
            last4: string option,
            mandateReference: string option
        ) : SourceMandateNotificationSepaDebitData
        =
        {
          CreditorIdentifier = creditorIdentifier
          Last4 = last4
          MandateReference = mandateReference
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

    let create
        (
            amount: int option,
            created: DateTime,
            id: string,
            livemode: bool,
            reason: SourceMandateNotificationReason,
            source: Source,
            status: SourceMandateNotificationStatus,
            ``type``: string
        ) : SourceMandateNotification
        =
        {
          Amount = amount
          Created = created
          Id = id
          Livemode = livemode
          Reason = reason
          Source = source
          Status = status
          Type = ``type``
          AcssDebit = None
          BacsDebit = None
          SepaDebit = None
        }

/// Occurs whenever a source fails.
type SourceFailed = { Object: Source }

module SourceFailed =
    let create
        (
            object: Source
        ) : SourceFailed
        =
        {
          Object = object
        }

/// Occurs whenever a source transitions to chargeable.
type SourceChargeable = { Object: Source }

module SourceChargeable =
    let create
        (
            object: Source
        ) : SourceChargeable
        =
        {
          Object = object
        }

/// Occurs whenever a source is canceled.
type SourceCanceled = { Object: Source }

module SourceCanceled =
    let create
        (
            object: Source
        ) : SourceCanceled
        =
        {
          Object = object
        }

