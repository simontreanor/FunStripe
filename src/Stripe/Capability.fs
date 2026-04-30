namespace Stripe.Capability

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Payment

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type CapabilityAccount'AnyOf =
    | String of string
    | Account of Account

[<Struct>]
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
        Account: CapabilityAccount'AnyOf
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

    let create
        (
            account: CapabilityAccount'AnyOf,
            id: string,
            requested: bool,
            requestedAt: DateTime option,
            status: CapabilityStatus,
            futureRequirements: AccountCapabilityFutureRequirements option,
            requirements: AccountCapabilityRequirements option
        ) : Capability
        =
        {
          Account = account
          Id = id
          Requested = requested
          RequestedAt = requestedAt
          Status = status
          FutureRequirements = futureRequirements
          Requirements = requirements
        }

/// Occurs whenever a capability has new requirements or a new status.
type CapabilityUpdated = { Object: Capability }

module CapabilityUpdated =
    let create
        (
            object: Capability
        ) : CapabilityUpdated
        =
        {
          Object = object
        }

