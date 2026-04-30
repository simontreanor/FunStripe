namespace Stripe.Transform

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type TransformUsageRound =
    | Down
    | Up

type TransformUsage =
    {
        /// Divide usage by this number.
        DivideBy: int
        /// After division, either round the result `up` or `down`.
        Round: TransformUsageRound
    }

[<Struct>]
type TransformQuantityRound =
    | Down
    | Up

type TransformQuantity =
    {
        /// Divide usage by this number.
        DivideBy: int
        /// After division, either round the result `up` or `down`.
        Round: TransformQuantityRound
    }

