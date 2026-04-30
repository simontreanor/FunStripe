namespace Stripe.Reserve

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type ReserveReleaseCreatedBy =
    | Application
    | Stripe

[<Struct>]
type ReserveReleaseReason =
    | BulkHoldExpiry
    | HoldReleasedEarly
    | HoldReversed
    | PlanDisabled

[<Struct>]
type ReserveHoldCreatedBy =
    | Application
    | Stripe

[<Struct>]
type ReserveHoldReason =
    | Charge
    | Standalone

[<Struct>]
type ReservePlanCreatedBy =
    | Application
    | Stripe

[<Struct>]
type ReservePlanStatus =
    | Active
    | Disabled
    | Expired

[<Struct>]
type ReservePlanType =
    | FixedRelease
    | RollingRelease

type ReservesReservePlansResourcesFixedRelease =
    {
        /// The time after which all reserved funds are requested for release.
        ReleaseAfter: int
        /// The time at which reserved funds are scheduled for release, automatically set to midnight UTC of the day after `release_after`.
        ScheduledRelease: DateTime
    }

type ReservesReservePlansResourcesRollingRelease =
    {
        /// The number of days to reserve funds before releasing.
        DaysAfterCharge: int
        /// The time at which the ReservePlan expires.
        ExpiresOn: int option
    }

/// ReservePlans are used to automatically place holds on a merchant's funds until the plan expires. It takes a portion of each incoming Charge (including those resulting from a Transfer from a platform account).
type ReservePlan =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Indicates which party created this ReservePlan.
        CreatedBy: ReservePlanCreatedBy
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies). An unset currency indicates that the plan applies to all currencies.
        Currency: IsoTypes.IsoCurrencyCode option
        /// Time at which the ReservePlan was disabled.
        DisabledAt: DateTime option
        FixedRelease: ReservesReservePlansResourcesFixedRelease option
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The percent of each Charge to reserve.
        Percent: int
        RollingRelease: ReservesReservePlansResourcesRollingRelease option
        /// The current status of the ReservePlan. The ReservePlan only affects charges if it is `active`.
        Status: ReservePlanStatus
        /// The type of the ReservePlan.
        Type: ReservePlanType
    }

module ReservePlan =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "reserve.plan"

type ReserveHoldReservePlan'AnyOf =
    | String of string
    | ReservePlan of ReservePlan

type ReserveHoldSourceCharge'AnyOf =
    | String of string
    | Charge of Charge

[<Struct>]
type ReserveHoldSourceType =
    | BankAccount
    | Card
    | Fpx

type ReservesReserveHoldsResourcesReleaseSchedule =
    {
        /// The time after which the ReserveHold is requested to be released.
        ReleaseAfter: DateTime option
        /// The time at which the ReserveHold is scheduled to be released, automatically set to midnight UTC of the day after `release_after`.
        ScheduledRelease: DateTime option
    }

/// ReserveHolds are used to place a temporary ReserveHold on a merchant's funds.
type ReserveHold =
    {
        /// Amount reserved. A positive integer representing how much is reserved in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
        Amount: int
        /// Amount in cents that can be released from this ReserveHold
        AmountReleasable: int option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Indicates which party created this ReserveHold.
        CreatedBy: ReserveHoldCreatedBy
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// Unique identifier for the object.
        Id: string
        /// Whether there are any funds available to release on this ReserveHold. Note that if the ReserveHold is in the process of being released, this could be false, even though the funds haven't been fully released yet.
        IsReleasable: bool option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The reason for the ReserveHold.
        Reason: ReserveHoldReason
        ReleaseSchedule: ReservesReserveHoldsResourcesReleaseSchedule
        /// The ReservePlan which produced this ReserveHold (i.e., resplan_123)
        ReservePlan: ReserveHoldReservePlan'AnyOf option
        /// The Charge which funded this ReserveHold (e.g., ch_123)
        SourceCharge: ReserveHoldSourceCharge'AnyOf option
        /// Which source balance type this ReserveHold reserves funds from. One of `bank_account`, `card`, or `fpx`.
        SourceType: ReserveHoldSourceType
    }

module ReserveHold =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "reserve.hold"

type ReserveReleaseReserveHold'AnyOf =
    | String of string
    | ReserveHold of ReserveHold

type ReserveReleaseReservePlan'AnyOf =
    | String of string
    | ReservePlan of ReservePlan

type ReservesReserveReleasesResourcesSourceTransactionDispute'AnyOf =
    | String of string
    | Dispute of Dispute

type ReservesReserveReleasesResourcesSourceTransactionRefund'AnyOf =
    | String of string
    | Refund of Refund

[<Struct>]
type ReservesReserveReleasesResourcesSourceTransactionType =
    | Dispute
    | Refund

type ReservesReserveReleasesResourcesSourceTransaction =
    {
        /// The ID of the dispute.
        Dispute: ReservesReserveReleasesResourcesSourceTransactionDispute'AnyOf option
        /// The ID of the refund.
        Refund: ReservesReserveReleasesResourcesSourceTransactionRefund'AnyOf option
        /// The type of source transaction.
        Type: ReservesReserveReleasesResourcesSourceTransactionType
    }

/// ReserveReleases represent the release of funds from a ReserveHold.
type ReserveRelease =
    {
        /// Amount released. A positive integer representing how much is released in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal).
        Amount: int
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Indicates which party created this ReserveRelease.
        CreatedBy: ReserveReleaseCreatedBy
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string> option
        /// The reason for the ReserveRelease, indicating why the funds were released.
        Reason: ReserveReleaseReason
        /// The release timestamp of the funds.
        ReleasedAt: DateTime
        /// The ReserveHold this ReserveRelease is associated with.
        ReserveHold: ReserveReleaseReserveHold'AnyOf option
        /// The ReservePlan ID this ReserveRelease is associated with. This field is only populated if a ReserveRelease is created by a ReservePlan disable operation, or from a scheduled ReservedHold expiry.
        ReservePlan: ReserveReleaseReservePlan'AnyOf option
        SourceTransaction: ReservesReserveReleasesResourcesSourceTransaction option
    }

module ReserveRelease =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "reserve.release"

/// Occurs when a reserve release is created.
type ReserveReleaseCreated = { Object: ReserveRelease }

/// Occurs when a reserve plan is updated.
type ReservePlanUpdated = { Object: ReservePlan }

/// Occurs when a reserve plan expires.
type ReservePlanExpired = { Object: ReservePlan }

/// Occurs when a reserve plan is disabled.
type ReservePlanDisabled = { Object: ReservePlan }

/// Occurs when a reserve plan is created.
type ReservePlanCreated = { Object: ReservePlan }

/// Occurs when a reserve hold is updated.
type ReserveHoldUpdated = { Object: ReserveHold }

/// Occurs when a reserve hold is created.
type ReserveHoldCreated = { Object: ReserveHold }

