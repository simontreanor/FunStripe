namespace Stripe.Payouts

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type PayoutsTraceIdStatus =
    | Pending
    | Supported
    | Unsupported

type PayoutsTraceId =
    {
        /// Possible values are `pending`, `supported`, and `unsupported`. When `payout.status` is `pending` or `in_transit`, this will be `pending`. When the payout transitions to `paid`, `failed`, or `canceled`, this status will become `supported` or `unsupported` shortly after in most cases. In some cases, this may appear as `pending` for up to 10 days after `arrival_date` until transitioning to `supported` or `unsupported`.
        Status: PayoutsTraceIdStatus
        /// The trace ID value if `trace_id.status` is `supported`, otherwise `nil`.
        Value: string option
    }

