namespace Stripe.IssuingPersonalizationDesign

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
type IssuingPersonalizationDesignCarrierText =
    {
        /// The footer body text of the carrier letter.
        FooterBody: string option
        /// The footer title text of the carrier letter.
        FooterTitle: string option
        /// The header body text of the carrier letter.
        HeaderBody: string option
        /// The header title text of the carrier letter.
        HeaderTitle: string option
    }

type IssuingPersonalizationDesignCarrierText with
    static member New(footerBody: string option, footerTitle: string option, headerBody: string option, headerTitle: string option) =
        {
            FooterBody = footerBody
            FooterTitle = footerTitle
            HeaderBody = headerBody
            HeaderTitle = headerTitle
        }

type IssuingPersonalizationDesignPreferences =
    {
        /// Whether we use this personalization design to create cards when one isn't specified. A connected account uses the Connect platform's default design if no personalization design is set as the default design.
        IsDefault: bool
        /// Whether this personalization design is used to create cards when one is not specified and a default for this connected account does not exist.
        IsPlatformDefault: bool option
    }

type IssuingPersonalizationDesignPreferences with
    static member New(isDefault: bool, isPlatformDefault: bool option) =
        {
            IsDefault = isDefault
            IsPlatformDefault = isPlatformDefault
        }

type IssuingPersonalizationDesignRejectionReasonsCardLogo =
    | GeographicLocation
    | Inappropriate
    | NetworkName
    | NonBinaryImage
    | NonFiatCurrency
    | Other
    | OtherEntity
    | PromotionalMaterial

type IssuingPersonalizationDesignRejectionReasonsCarrierText =
    | GeographicLocation
    | Inappropriate
    | NetworkName
    | NonFiatCurrency
    | Other
    | OtherEntity
    | PromotionalMaterial

type IssuingPersonalizationDesignRejectionReasons =
    {
        /// The reason(s) the card logo was rejected.
        CardLogo: IssuingPersonalizationDesignRejectionReasonsCardLogo list option
        /// The reason(s) the carrier text was rejected.
        CarrierText: IssuingPersonalizationDesignRejectionReasonsCarrierText list option
    }

type IssuingPersonalizationDesignRejectionReasons with
    static member New(cardLogo: IssuingPersonalizationDesignRejectionReasonsCardLogo list option, carrierText: IssuingPersonalizationDesignRejectionReasonsCarrierText list option) =
        {
            CardLogo = cardLogo
            CarrierText = carrierText
        }

[<Struct>]
type IssuingPersonalizationDesignStatus =
    | Active
    | Inactive
    | Rejected
    | Review

/// A Personalization Design is a logical grouping of a Physical Bundle, card logo, and carrier text that represents a product line.
type IssuingPersonalizationDesign =
    {
        /// The file for the card logo to use with physical bundles that support card logos. Must have a `purpose` value of `issuing_logo`.
        CardLogo: StripeId<Markers.File> option
        /// Hash containing carrier text, for use with physical bundles that support carrier text.
        CarrierText: IssuingPersonalizationDesignCarrierText option
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// A lookup key used to retrieve personalization designs dynamically from a static string. This may be up to 200 characters.
        LookupKey: string option
        /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
        Metadata: Map<string, string>
        /// Friendly display name.
        Name: string option
        /// The physical bundle object belonging to this personalization design.
        PhysicalBundle: StripeId<Markers.IssuingPhysicalBundle>
        Preferences: IssuingPersonalizationDesignPreferences
        RejectionReasons: IssuingPersonalizationDesignRejectionReasons
        /// Whether this personalization design can be used to create cards.
        Status: IssuingPersonalizationDesignStatus
    }

type IssuingPersonalizationDesign with
    static member New(cardLogo: StripeId<Markers.File> option, carrierText: IssuingPersonalizationDesignCarrierText option, created: DateTime, id: string, livemode: bool, lookupKey: string option, metadata: Map<string, string>, name: string option, physicalBundle: StripeId<Markers.IssuingPhysicalBundle>, preferences: IssuingPersonalizationDesignPreferences, rejectionReasons: IssuingPersonalizationDesignRejectionReasons, status: IssuingPersonalizationDesignStatus) =
        {
            CardLogo = cardLogo
            CarrierText = carrierText
            Created = created
            Id = id
            Livemode = livemode
            LookupKey = lookupKey
            Metadata = metadata
            Name = name
            PhysicalBundle = physicalBundle
            Preferences = preferences
            RejectionReasons = rejectionReasons
            Status = status
        }

module IssuingPersonalizationDesign =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "issuing.personalization_design"

/// Occurs whenever a personalization design is activated following the activation of the physical bundle that belongs to it.
type IssuingPersonalizationDesignActivated =
    { Object: IssuingPersonalizationDesign }

type IssuingPersonalizationDesignActivated with
    static member New(object: IssuingPersonalizationDesign) =
        {
            Object = object
        }

/// Occurs whenever a personalization design is deactivated following the deactivation of the physical bundle that belongs to it.
type IssuingPersonalizationDesignDeactivated =
    { Object: IssuingPersonalizationDesign }

type IssuingPersonalizationDesignDeactivated with
    static member New(object: IssuingPersonalizationDesign) =
        {
            Object = object
        }

/// Occurs whenever a personalization design is rejected by design review.
type IssuingPersonalizationDesignRejected =
    { Object: IssuingPersonalizationDesign }

type IssuingPersonalizationDesignRejected with
    static member New(object: IssuingPersonalizationDesign) =
        {
            Object = object
        }

/// Occurs whenever a personalization design is updated.
type IssuingPersonalizationDesignUpdated =
    { Object: IssuingPersonalizationDesign }

type IssuingPersonalizationDesignUpdated with
    static member New(object: IssuingPersonalizationDesign) =
        {
            Object = object
        }

