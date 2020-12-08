namespace FunStripe

open Charges

module PaymentIntents =

    type PaymentIntent = {
        Id: string
        Amount: int
        Charges: ChargeList
        ClientSecret: string
        Currency: string
        Customer: string
        Description: string
        LastPaymentError: Map<string, string>
        Metadata: Map<string, string>
        NextAction: Map<string, string>
        PaymentMethod: string
        PaymentMethodTypes: string list
        ReceiptEmail: string
        SetupFutureUsage: FutureUsage
        Shipping: Map<string, string>
        StatementDescriptor: string
        StatementDescriptorSuffix: string
        Status: PaymentIntentStatus
    }

    and ChargeList = {
        Object: string
        Data: Charge list
        HasMore: bool
        Url: string
    }

    and FutureUsage =
        | OffSession
        | OnSession

    and PaymentIntentStatus =
        | Cancelled
        | Processing
        | RequiresAction
        | RequiresCapture
        | RequiresConfirmation
        | RequiresPaymentMethod
        | Succeeded
