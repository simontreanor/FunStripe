namespace Stripe.PaymentRecord

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type PaymentRecordCustomerPresence =
    | OffSession
    | OnSession

[<Struct>]
type PaymentRecordReportedBy =
    | Self
    | Stripe

/// A Payment Record is a resource that allows you to represent payments that occur on- or off-Stripe.
/// For example, you can create a Payment Record to model a payment made on a different payment processor,
/// in order to mark an Invoice as paid and a Subscription as active. Payment Records consist of one or
/// more Payment Attempt Records, which represent individual attempts made on a payment network.
type PaymentRecord =
    {
        Amount: PaymentsPrimitivesPaymentRecordsResourceAmount
        AmountAuthorized: PaymentsPrimitivesPaymentRecordsResourceAmount
        AmountCanceled: PaymentsPrimitivesPaymentRecordsResourceAmount
        AmountFailed: PaymentsPrimitivesPaymentRecordsResourceAmount
        AmountGuaranteed: PaymentsPrimitivesPaymentRecordsResourceAmount
        AmountRefunded: PaymentsPrimitivesPaymentRecordsResourceAmount
        AmountRequested: PaymentsPrimitivesPaymentRecordsResourceAmount
        /// ID of the Connect application that created the PaymentRecord.
        Application: string option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Customer information for this payment.
        CustomerDetails: PaymentsPrimitivesPaymentRecordsResourceCustomerDetails option
        /// Indicates whether the customer was present in your checkout flow during this payment.
        CustomerPresence: PaymentRecordCustomerPresence option
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        /// Unique identifier for the object.
        Id: string
        /// ID of the latest Payment Attempt Record attached to this Payment Record.
        LatestPaymentAttemptRecord: string option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// Information about the Payment Method debited for this payment.
        PaymentMethodDetails: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodDetails option
        ProcessorDetails: PaymentsPrimitivesPaymentRecordsResourceProcessorDetails
        /// Indicates who reported the payment.
        ReportedBy: PaymentRecordReportedBy
        /// Shipping information for this payment.
        ShippingDetails: PaymentsPrimitivesPaymentRecordsResourceShippingDetails option
    }

type PaymentRecord with
    static member New(amount: PaymentsPrimitivesPaymentRecordsResourceAmount, amountAuthorized: PaymentsPrimitivesPaymentRecordsResourceAmount, amountCanceled: PaymentsPrimitivesPaymentRecordsResourceAmount, amountFailed: PaymentsPrimitivesPaymentRecordsResourceAmount, amountGuaranteed: PaymentsPrimitivesPaymentRecordsResourceAmount, amountRefunded: PaymentsPrimitivesPaymentRecordsResourceAmount, amountRequested: PaymentsPrimitivesPaymentRecordsResourceAmount, application: string option, created: DateTime, customerDetails: PaymentsPrimitivesPaymentRecordsResourceCustomerDetails option, customerPresence: PaymentRecordCustomerPresence option, description: string option, id: string, latestPaymentAttemptRecord: string option, livemode: bool, metadata: Map<string, string>, paymentMethodDetails: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodDetails option, processorDetails: PaymentsPrimitivesPaymentRecordsResourceProcessorDetails, reportedBy: PaymentRecordReportedBy, shippingDetails: PaymentsPrimitivesPaymentRecordsResourceShippingDetails option) =
        {
            Amount = amount
            AmountAuthorized = amountAuthorized
            AmountCanceled = amountCanceled
            AmountFailed = amountFailed
            AmountGuaranteed = amountGuaranteed
            AmountRefunded = amountRefunded
            AmountRequested = amountRequested
            Application = application
            Created = created
            CustomerDetails = customerDetails
            CustomerPresence = customerPresence
            Description = description
            Id = id
            LatestPaymentAttemptRecord = latestPaymentAttemptRecord
            Livemode = livemode
            Metadata = metadata
            PaymentMethodDetails = paymentMethodDetails
            ProcessorDetails = processorDetails
            ReportedBy = reportedBy
            ShippingDetails = shippingDetails
        }

module PaymentRecord =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "payment_record"

