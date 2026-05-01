namespace Stripe.PaymentAttemptRecord

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type PaymentAttemptRecordCustomerPresence =
    | OffSession
    | OnSession

[<Struct>]
type PaymentAttemptRecordReportedBy =
    | Self
    | Stripe

/// A Payment Attempt Record represents an individual attempt at making a payment, on or off Stripe.
/// Each payment attempt tries to collect a fixed amount of money from a fixed customer and payment
/// method. Payment Attempt Records are attached to Payment Records. Only one attempt per Payment Record
/// can have guaranteed funds.
type PaymentAttemptRecord =
    {
        Amount: PaymentsPrimitivesPaymentRecordsResourceAmount
        AmountAuthorized: PaymentsPrimitivesPaymentRecordsResourceAmount
        AmountCanceled: PaymentsPrimitivesPaymentRecordsResourceAmount
        AmountFailed: PaymentsPrimitivesPaymentRecordsResourceAmount
        AmountGuaranteed: PaymentsPrimitivesPaymentRecordsResourceAmount
        AmountRefunded: PaymentsPrimitivesPaymentRecordsResourceAmount
        AmountRequested: PaymentsPrimitivesPaymentRecordsResourceAmount
        /// ID of the Connect application that created the PaymentAttemptRecord.
        Application: string option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Customer information for this payment.
        CustomerDetails: PaymentsPrimitivesPaymentRecordsResourceCustomerDetails option
        /// Indicates whether the customer was present in your checkout flow during this payment.
        CustomerPresence: PaymentAttemptRecordCustomerPresence option
        /// An arbitrary string attached to the object. Often useful for displaying to users.
        Description: string option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// Information about the Payment Method debited for this payment.
        PaymentMethodDetails: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodDetails option
        /// ID of the Payment Record this Payment Attempt Record belongs to.
        PaymentRecord: string option
        ProcessorDetails: PaymentsPrimitivesPaymentRecordsResourceProcessorDetails
        /// Indicates who reported the payment.
        ReportedBy: PaymentAttemptRecordReportedBy
        /// Shipping information for this payment.
        ShippingDetails: PaymentsPrimitivesPaymentRecordsResourceShippingDetails option
    }

type PaymentAttemptRecord with
    static member New(amount: PaymentsPrimitivesPaymentRecordsResourceAmount, amountAuthorized: PaymentsPrimitivesPaymentRecordsResourceAmount, amountCanceled: PaymentsPrimitivesPaymentRecordsResourceAmount, amountFailed: PaymentsPrimitivesPaymentRecordsResourceAmount, amountGuaranteed: PaymentsPrimitivesPaymentRecordsResourceAmount, amountRefunded: PaymentsPrimitivesPaymentRecordsResourceAmount, amountRequested: PaymentsPrimitivesPaymentRecordsResourceAmount, application: string option, created: DateTime, customerDetails: PaymentsPrimitivesPaymentRecordsResourceCustomerDetails option, customerPresence: PaymentAttemptRecordCustomerPresence option, description: string option, id: string, livemode: bool, metadata: Map<string, string>, paymentMethodDetails: PaymentsPrimitivesPaymentRecordsResourcePaymentMethodDetails option, paymentRecord: string option, processorDetails: PaymentsPrimitivesPaymentRecordsResourceProcessorDetails, reportedBy: PaymentAttemptRecordReportedBy, shippingDetails: PaymentsPrimitivesPaymentRecordsResourceShippingDetails option) =
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
            Livemode = livemode
            Metadata = metadata
            PaymentMethodDetails = paymentMethodDetails
            PaymentRecord = paymentRecord
            ProcessorDetails = processorDetails
            ReportedBy = reportedBy
            ShippingDetails = shippingDetails
        }

module PaymentAttemptRecord =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "payment_attempt_record"

