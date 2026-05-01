namespace Stripe.TestHelpers

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
type TestHelpersTestClockStatus =
    | Advancing
    | InternalFailure
    | Ready

/// A test clock enables deterministic control over objects in testmode. With a test clock, you can create
/// objects at a frozen time in the past or future, and advance to a specific future time to observe webhooks and state changes. After the clock advances,
/// you can either validate the current state of your scenario (and test your assumptions), change the current state of your scenario (and test more complex scenarios), or keep advancing forward in time.
type TestHelpersTestClock =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Time at which this clock is scheduled to auto delete.
        DeletesAfter: DateTime
        /// Time at which all objects belonging to this clock are frozen.
        FrozenTime: DateTime
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// The custom name supplied at creation.
        Name: string option
        /// The status of the Test Clock.
        Status: TestHelpersTestClockStatus
        StatusDetails: BillingClocksResourceStatusDetailsStatusDetails
    }

type TestHelpersTestClock with
    static member New(created: DateTime, deletesAfter: DateTime, frozenTime: DateTime, id: string, livemode: bool, name: string option, status: TestHelpersTestClockStatus, statusDetails: BillingClocksResourceStatusDetailsStatusDetails) =
        {
            Created = created
            DeletesAfter = deletesAfter
            FrozenTime = frozenTime
            Id = id
            Livemode = livemode
            Name = name
            Status = status
            StatusDetails = statusDetails
        }

module TestHelpersTestClock =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "test_helpers.test_clock"

/// Occurs whenever a test clock transitions to a ready status.
type TestHelpersTestClockReady = { Object: TestHelpersTestClock }

type TestHelpersTestClockReady with
    static member New(object: TestHelpersTestClock) =
        {
            Object = object
        }

/// Occurs whenever a test clock fails to advance its frozen time.
type TestHelpersTestClockInternalFailure = { Object: TestHelpersTestClock }

type TestHelpersTestClockInternalFailure with
    static member New(object: TestHelpersTestClock) =
        {
            Object = object
        }

/// Occurs whenever a test clock is deleted.
type TestHelpersTestClockDeleted = { Object: TestHelpersTestClock }

type TestHelpersTestClockDeleted with
    static member New(object: TestHelpersTestClock) =
        {
            Object = object
        }

/// Occurs whenever a test clock is created.
type TestHelpersTestClockCreated = { Object: TestHelpersTestClock }

type TestHelpersTestClockCreated with
    static member New(object: TestHelpersTestClock) =
        {
            Object = object
        }

/// Occurs whenever a test clock starts advancing.
type TestHelpersTestClockAdvancing = { Object: TestHelpersTestClock }

type TestHelpersTestClockAdvancing with
    static member New(object: TestHelpersTestClock) =
        {
            Object = object
        }

type DeletedTestHelpersTestClock =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

type DeletedTestHelpersTestClock with
    static member New(deleted: bool, id: string) =
        {
            Deleted = deleted
            Id = id
        }

module DeletedTestHelpersTestClock =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "test_helpers.test_clock"

