namespace Stripe.Reporting

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.File
open Stripe.Financial

/// The Report Type resource corresponds to a particular type of report, such as
/// the "Activity summary" or "Itemized payouts" reports. These objects are
/// identified by an ID belonging to a set of enumerated values. See
/// [API Access to Reports documentation](https://docs.stripe.com/reporting/statements/api)
/// for those Report Type IDs, along with required and optional parameters.
/// Note that certain report types can only be run based on your live-mode data (not test-mode
/// data), and will error when queried without a [live-mode API key](https://docs.stripe.com/keys#test-live-modes).
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type ReportingReportType =
    {
        /// Most recent time for which this Report Type is available. Measured in seconds since the Unix epoch.
        DataAvailableEnd: DateTime
        /// Earliest time for which this Report Type is available. Measured in seconds since the Unix epoch.
        DataAvailableStart: DateTime
        /// List of column names that are included by default when this Report Type gets run. (If the Report Type doesn't support the `columns` parameter, this will be null.)
        DefaultColumns: string list option
        /// The [ID of the Report Type](https://docs.stripe.com/reporting/statements/api#available-report-types), such as `balance.summary.1`.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Human-readable name of the Report Type
        Name: string
        /// When this Report Type was latest updated. Measured in seconds since the Unix epoch.
        Updated: DateTime
        /// Version of the Report Type. Different versions report with the same ID will have the same purpose, but may take different run parameters or have different result schemas.
        Version: int
    }

module ReportingReportType =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "reporting.report_type"

/// Occurs whenever a `ReportType` is updated (typically to indicate that a new day's data has come available).
type ReportingReportTypeUpdated = { Object: ReportingReportType }

/// The Report Run object represents an instance of a report type generated with
/// specific run parameters. Once the object is created, Stripe begins processing the report.
/// When the report has finished running, it will give you a reference to a file
/// where you can retrieve your results. For an overview, see
/// [API Access to Reports](https://docs.stripe.com/reporting/statements/api).
/// Note that certain report types can only be run based on your live-mode data (not test-mode
/// data), and will error when queried without a [live-mode API key](https://docs.stripe.com/keys#test-live-modes).
type ReportingReportRun =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// If something should go wrong during the run, a message about the failure (populated when
        ///  `status=failed`).
        Error: string option
        /// Unique identifier for the object.
        Id: string
        /// `true` if the report is run on live mode data and `false` if it is run on test mode data.
        Livemode: bool
        Parameters: FinancialReportingFinanceReportRunRunParameters
        /// The ID of the [report type](https://docs.stripe.com/reports/report-types) to run, such as `"balance.summary.1"`.
        ReportType: string
        /// The file object representing the result of the report run (populated when
        ///  `status=succeeded`).
        Result: File option
        /// Status of this report run. This will be `pending` when the run is initially created.
        ///  When the run finishes, this will be set to `succeeded` and the `result` field will be populated.
        ///  Rarely, we may encounter an error, at which point this will be set to `failed` and the `error` field will be populated.
        Status: string
        /// Timestamp at which this run successfully finished (populated when
        ///  `status=succeeded`). Measured in seconds since the Unix epoch.
        SucceededAt: DateTime option
    }

module ReportingReportRun =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "reporting.report_run"

/// Occurs whenever a requested `ReportRun` completed successfully.
type ReportingReportRunSucceeded = { Object: ReportingReportRun }

/// Occurs whenever a requested `ReportRun` failed to complete.
type ReportingReportRunFailed = { Object: ReportingReportRun }

