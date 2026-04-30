namespace Stripe.Capability

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type CapabilityStatus =
    | Active
    | Inactive
    | Pending
    | Unrequested

/// This is an object representing a capability for a Stripe account.
/// Related guide: [Account capabilities](https://docs.stripe.com/connect/account-capabilities)
type Capability =
    {
        /// The account for which the capability enables functionality.
        Account: string
        FutureRequirements: AccountCapabilityFutureRequirements option
        /// The identifier for the capability.
        Id: string
        /// Whether the capability has been requested.
        Requested: bool
        /// Time at which the capability was requested. Measured in seconds since the Unix epoch.
        RequestedAt: DateTime option
        Requirements: AccountCapabilityRequirements option
        /// The status of the capability.
        Status: CapabilityStatus
    }

module Capability =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "capability"

/// Occurs whenever a capability has new requirements or a new status.
type CapabilityUpdated = { Object: Capability }

