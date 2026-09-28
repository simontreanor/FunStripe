namespace Stripe.ProductCatalog

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.Price

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.5.0")>]
type ProductCatalogImplEndpointsTrialOfferResourceRelativeDuration =
    {
        /// The number of iterations of the price's interval for this trial offer.
        Iterations: int
    }

type ProductCatalogImplEndpointsTrialOfferResourceRelativeDuration with
    static member New(iterations: int) =
        {
            Iterations = iterations
        }

type ProductCatalogImplEndpointsTrialOfferResourceTransitionPrice'AnyOf =
    | String of string
    | Price of Price
    | DeletedPrice of DeletedPrice

type ProductCatalogImplEndpointsTrialOfferResourceTransition =
    {
        /// The new price to use at the end of the trial offer period.
        Price: ProductCatalogImplEndpointsTrialOfferResourceTransitionPrice'AnyOf
    }

type ProductCatalogImplEndpointsTrialOfferResourceTransition with
    static member New(price: ProductCatalogImplEndpointsTrialOfferResourceTransitionPrice'AnyOf) =
        {
            Price = price
        }

type ProductCatalogImplEndpointsTrialOfferResourceTrialOfferDuration =
    { Relative: ProductCatalogImplEndpointsTrialOfferResourceRelativeDuration option }

type ProductCatalogImplEndpointsTrialOfferResourceTrialOfferDuration with
    static member New(?relative: ProductCatalogImplEndpointsTrialOfferResourceRelativeDuration) =
        {
            Relative = relative
        }

module ProductCatalogImplEndpointsTrialOfferResourceTrialOfferDuration =
    ///The type of trial offer duration.
    let ``type`` = "relative"

type ProductCatalogImplEndpointsTrialOfferResourceTrialOfferEndBehavior =
    { Transition: ProductCatalogImplEndpointsTrialOfferResourceTransition option }

type ProductCatalogImplEndpointsTrialOfferResourceTrialOfferEndBehavior with
    static member New(?transition: ProductCatalogImplEndpointsTrialOfferResourceTransition) =
        {
            Transition = transition
        }

module ProductCatalogImplEndpointsTrialOfferResourceTrialOfferEndBehavior =
    ///The type of behavior when the trial offer ends.
    let ``type`` = "transition"

type ProductCatalogTrialOfferPrice'AnyOf =
    | String of string
    | Price of Price
    | DeletedPrice of DeletedPrice

/// Trial offers let you define free or paid introductory pricing for a subscription item.
/// A TrialOffer specifies the price to charge during the trial, how many billing intervals
/// the trial lasts, and what price the subscription item transitions to when the trial ends.
/// You attach a TrialOffer to a subscription item
/// using `items[current_trial][trial_offer]` when creating or updating a subscription.
type ProductCatalogTrialOffer =
    {
        /// Whether the trial offer is active. Set to false to archive the trial offer.
        Active: bool
        Duration: ProductCatalogImplEndpointsTrialOfferResourceTrialOfferDuration
        EndBehavior: ProductCatalogImplEndpointsTrialOfferResourceTrialOfferEndBehavior
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// A brief description of the trial offer, hidden from customers.
        Nickname: string option
        /// The price during the trial offer.
        Price: ProductCatalogTrialOfferPrice'AnyOf
    }

type ProductCatalogTrialOffer with
    static member New(active: bool, duration: ProductCatalogImplEndpointsTrialOfferResourceTrialOfferDuration, endBehavior: ProductCatalogImplEndpointsTrialOfferResourceTrialOfferEndBehavior, id: string, livemode: bool, nickname: string option, price: ProductCatalogTrialOfferPrice'AnyOf) =
        {
            Active = active
            Duration = duration
            EndBehavior = endBehavior
            Id = id
            Livemode = livemode
            Nickname = nickname
            Price = price
        }

module ProductCatalogTrialOffer =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "product_catalog.trial_offer"

