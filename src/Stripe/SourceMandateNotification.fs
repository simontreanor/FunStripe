namespace Stripe.SourceMandateNotification

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
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

