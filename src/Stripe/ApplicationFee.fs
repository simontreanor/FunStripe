namespace Stripe.ApplicationFee

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

/// Occurs whenever an application fee is refunded, whether from refunding a charge or from [refunding the application fee directly](#fee_refunds). This includes partial refunds.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type ApplicationFeeRefunded = { Object: ApplicationFee }

/// Occurs whenever an application fee refund is updated.
type ApplicationFeeRefundUpdated = { Object: FeeRefund }

/// Occurs whenever an application fee is created on a charge.
type ApplicationFeeCreated = { Object: ApplicationFee }

