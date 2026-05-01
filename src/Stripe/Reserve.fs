namespace Stripe.Reserve

open System.Text.Json.Serialization
open FunStripe
open System

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
type ReservesReserveReleasesResourcesSourceTransactionType =
    | Dispute
    | Refund

type ReservesReserveReleasesResourcesSourceTransaction =
    {
        /// The ID of the dispute.
        Dispute: StripeId<Markers.Dispute> option
        /// The ID of the refund.
        Refund: StripeId<Markers.Refund> option
        /// The type of source transaction.
        Type: ReservesReserveReleasesResourcesSourceTransactionType
    }

type ReservesReserveReleasesResourcesSourceTransaction with
    static member New(``type``: ReservesReserveReleasesResourcesSourceTransactionType, ?dispute: StripeId<Markers.Dispute>, ?refund: StripeId<Markers.Refund>) =
        {
            Type = ``type``
            Dispute = dispute
            Refund = refund
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
        ReserveHold: StripeId<Markers.ReserveHold> option
        /// The ReservePlan ID this ReserveRelease is associated with. This field is only populated if a ReserveRelease is created by a ReservePlan disable operation, or from a scheduled ReservedHold expiry.
        ReservePlan: StripeId<Markers.ReservePlan> option
        SourceTransaction: ReservesReserveReleasesResourcesSourceTransaction option
    }

type ReserveRelease with
    static member New(amount: int, created: DateTime, createdBy: ReserveReleaseCreatedBy, currency: IsoTypes.IsoCurrencyCode, id: string, livemode: bool, reason: ReserveReleaseReason, releasedAt: DateTime, reserveHold: StripeId<Markers.ReserveHold> option, reservePlan: StripeId<Markers.ReservePlan> option, ?metadata: Map<string, string>, ?sourceTransaction: ReservesReserveReleasesResourcesSourceTransaction) =
        {
            Amount = amount
            Created = created
            CreatedBy = createdBy
            Currency = currency
            Id = id
            Livemode = livemode
            Reason = reason
            ReleasedAt = releasedAt
            ReserveHold = reserveHold
            ReservePlan = reservePlan
            Metadata = metadata
            SourceTransaction = sourceTransaction
        }

module ReserveRelease =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "reserve.release"

/// Occurs when a reserve release is created.
type ReserveReleaseCreated = { Object: ReserveRelease }

type ReserveReleaseCreated with
    static member New(object: ReserveRelease) =
        {
            Object = object
        }

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

type ReservesReservePlansResourcesFixedRelease with
    static member New(releaseAfter: int, scheduledRelease: DateTime) =
        {
            ReleaseAfter = releaseAfter
            ScheduledRelease = scheduledRelease
        }

type ReservesReservePlansResourcesRollingRelease =
    {
        /// The number of days to reserve funds before releasing.
        DaysAfterCharge: int
        /// The time at which the ReservePlan expires.
        ExpiresOn: int option
    }

type ReservesReservePlansResourcesRollingRelease with
    static member New(daysAfterCharge: int, expiresOn: int option) =
        {
            DaysAfterCharge = daysAfterCharge
            ExpiresOn = expiresOn
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

type ReservePlan with
    static member New(created: DateTime, createdBy: ReservePlanCreatedBy, currency: IsoTypes.IsoCurrencyCode option, disabledAt: DateTime option, id: string, livemode: bool, percent: int, status: ReservePlanStatus, ``type``: ReservePlanType, ?fixedRelease: ReservesReservePlansResourcesFixedRelease, ?metadata: Map<string, string>, ?rollingRelease: ReservesReservePlansResourcesRollingRelease) =
        {
            Created = created
            CreatedBy = createdBy
            Currency = currency
            DisabledAt = disabledAt
            Id = id
            Livemode = livemode
            Percent = percent
            Status = status
            Type = ``type``
            FixedRelease = fixedRelease
            Metadata = metadata
            RollingRelease = rollingRelease
        }

module ReservePlan =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "reserve.plan"

/// Occurs when a reserve plan is updated.
type ReservePlanUpdated = { Object: ReservePlan }

type ReservePlanUpdated with
    static member New(object: ReservePlan) =
        {
            Object = object
        }

/// Occurs when a reserve plan expires.
type ReservePlanExpired = { Object: ReservePlan }

type ReservePlanExpired with
    static member New(object: ReservePlan) =
        {
            Object = object
        }

/// Occurs when a reserve plan is disabled.
type ReservePlanDisabled = { Object: ReservePlan }

type ReservePlanDisabled with
    static member New(object: ReservePlan) =
        {
            Object = object
        }

/// Occurs when a reserve plan is created.
type ReservePlanCreated = { Object: ReservePlan }

type ReservePlanCreated with
    static member New(object: ReservePlan) =
        {
            Object = object
        }

[<Struct>]
type ReserveHoldCreatedBy =
    | Application
    | Stripe

[<Struct>]
type ReserveHoldReason =
    | Charge
    | Standalone

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

type ReservesReserveHoldsResourcesReleaseSchedule with
    static member New(releaseAfter: DateTime option, scheduledRelease: DateTime option) =
        {
            ReleaseAfter = releaseAfter
            ScheduledRelease = scheduledRelease
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
        ReservePlan: StripeId<Markers.ReservePlan> option
        /// The Charge which funded this ReserveHold (e.g., ch_123)
        SourceCharge: StripeId<Markers.Charge> option
        /// Which source balance type this ReserveHold reserves funds from. One of `bank_account`, `card`, or `fpx`.
        SourceType: ReserveHoldSourceType
    }

type ReserveHold with
    static member New(amount: int, created: DateTime, createdBy: ReserveHoldCreatedBy, currency: IsoTypes.IsoCurrencyCode, id: string, livemode: bool, reason: ReserveHoldReason, releaseSchedule: ReservesReserveHoldsResourcesReleaseSchedule, reservePlan: StripeId<Markers.ReservePlan> option, sourceCharge: StripeId<Markers.Charge> option, sourceType: ReserveHoldSourceType, ?amountReleasable: int, ?isReleasable: bool, ?metadata: Map<string, string>) =
        {
            Amount = amount
            Created = created
            CreatedBy = createdBy
            Currency = currency
            Id = id
            Livemode = livemode
            Reason = reason
            ReleaseSchedule = releaseSchedule
            ReservePlan = reservePlan
            SourceCharge = sourceCharge
            SourceType = sourceType
            AmountReleasable = amountReleasable
            IsReleasable = isReleasable
            Metadata = metadata
        }

module ReserveHold =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "reserve.hold"

/// Occurs when a reserve hold is updated.
type ReserveHoldUpdated = { Object: ReserveHold }

type ReserveHoldUpdated with
    static member New(object: ReserveHold) =
        {
            Object = object
        }

/// Occurs when a reserve hold is created.
type ReserveHoldCreated = { Object: ReserveHold }

type ReserveHoldCreated with
    static member New(object: ReserveHold) =
        {
            Object = object
        }

