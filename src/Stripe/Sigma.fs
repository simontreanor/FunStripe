namespace Stripe.Sigma

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.File

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type SigmaScheduledQueryRunError =
    {
        /// Information about the run failure.
        Message: string
    }

/// If you have [scheduled a Sigma query](https://docs.stripe.com/sigma/scheduled-queries), you'll
/// receive a `sigma.scheduled_query_run.created` webhook each time the query
/// runs. The webhook contains a `ScheduledQueryRun` object, which you can use to
/// retrieve the query results.
type ScheduledQueryRun =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// When the query was run, Sigma contained a snapshot of your Stripe data at this time.
        DataLoadTime: DateTime
        Error: SigmaScheduledQueryRunError option
        /// The file object representing the results of the query.
        File: File option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Time at which the result expires and is no longer available for download.
        ResultAvailableUntil: DateTime
        /// SQL for the query.
        Sql: string
        /// The query's execution status, which will be `completed` for successful runs, and `canceled`, `failed`, or `timed_out` otherwise.
        Status: string
        /// Title of the query.
        Title: string
    }

module ScheduledQueryRun =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "scheduled_query_run"

/// Occurs whenever a Sigma scheduled query run finishes.
type SigmaScheduledQueryRunCreated = { Object: ScheduledQueryRun }

