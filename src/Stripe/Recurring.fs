namespace Stripe.Recurring

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type RecurringInterval =
    | Day
    | Month
    | Week
    | Year

[<Struct>]
type RecurringUsageType =
    | Licensed
    | Metered

type Recurring =
    {
        /// The frequency at which a subscription is billed. One of `day`, `week`, `month` or `year`.
        Interval: RecurringInterval
        /// The number of intervals (specified in the `interval` attribute) between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months.
        IntervalCount: int
        /// The meter tracking the usage of a metered price
        Meter: string option
        /// Default number of trial days when subscribing a customer to this price using [`trial_from_plan=true`](https://docs.stripe.com/api#create_subscription-trial_from_plan).
        TrialPeriodDays: int option
        /// Configures how the quantity per period should be determined. Can be either `metered` or `licensed`. `licensed` automatically bills the `quantity` set when adding it to a subscription. `metered` aggregates the total usage based on usage records. Defaults to `licensed`.
        UsageType: RecurringUsageType
    }

module Recurring =
    let create
        (
            interval: RecurringInterval,
            intervalCount: int,
            meter: string option,
            trialPeriodDays: int option,
            usageType: RecurringUsageType
        ) : Recurring
        =
        {
          Interval = interval
          IntervalCount = intervalCount
          Meter = meter
          TrialPeriodDays = trialPeriodDays
          UsageType = usageType
        }

