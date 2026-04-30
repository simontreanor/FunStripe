namespace Stripe.IssuingPersonalizationDesign

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
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

type IssuingPersonalizationDesignPreferences =
    {
        /// Whether we use this personalization design to create cards when one isn't specified. A connected account uses the Connect platform's default design if no personalization design is set as the default design.
        IsDefault: bool
        /// Whether this personalization design is used to create cards when one is not specified and a default for this connected account does not exist.
        IsPlatformDefault: bool option
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
        CardLogo: string option
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
        PhysicalBundle: string
        Preferences: IssuingPersonalizationDesignPreferences
        RejectionReasons: IssuingPersonalizationDesignRejectionReasons
        /// Whether this personalization design can be used to create cards.
        Status: IssuingPersonalizationDesignStatus
    }

module IssuingPersonalizationDesign =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "issuing.personalization_design"

/// Occurs whenever a personalization design is updated.
type IssuingPersonalizationDesignUpdated =
    { Object: IssuingPersonalizationDesign }

/// Occurs whenever a personalization design is rejected by design review.
type IssuingPersonalizationDesignRejected =
    { Object: IssuingPersonalizationDesign }

/// Occurs whenever a personalization design is deactivated following the deactivation of the physical bundle that belongs to it.
type IssuingPersonalizationDesignDeactivated =
    { Object: IssuingPersonalizationDesign }

/// Occurs whenever a personalization design is activated following the activation of the physical bundle that belongs to it.
type IssuingPersonalizationDesignActivated =
    { Object: IssuingPersonalizationDesign }

