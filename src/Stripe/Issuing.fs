namespace Stripe.Issuing

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type IssuingPhysicalBundleFeaturesCardLogo =
    | Optional
    | Required
    | Unsupported

[<Struct>]
type IssuingPhysicalBundleFeaturesCarrierText =
    | Optional
    | Required
    | Unsupported

[<Struct>]
type IssuingPhysicalBundleFeaturesSecondLine =
    | Optional
    | Required
    | Unsupported

type IssuingPhysicalBundleFeatures =
    {
        /// The policy for how to use card logo images in a card design with this physical bundle.
        CardLogo: IssuingPhysicalBundleFeaturesCardLogo
        /// The policy for how to use carrier letter text in a card design with this physical bundle.
        CarrierText: IssuingPhysicalBundleFeaturesCarrierText
        /// The policy for how to use a second line on a card with this physical bundle.
        SecondLine: IssuingPhysicalBundleFeaturesSecondLine
    }

[<Struct>]
type IssuingPhysicalBundleStatus =
    | Active
    | Inactive
    | Review

[<Struct>]
type IssuingPhysicalBundleType =
    | Custom
    | Standard

/// A Physical Bundle represents the bundle of physical items - card stock, carrier letter, and envelope - that is shipped to a cardholder when you create a physical card.
type IssuingPhysicalBundle =
    {
        Features: IssuingPhysicalBundleFeatures
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Friendly display name.
        Name: string
        /// Whether this physical bundle can be used to create cards.
        Status: IssuingPhysicalBundleStatus
        /// Whether this physical bundle is a standard Stripe offering or custom-made for you.
        Type: IssuingPhysicalBundleType
    }

module IssuingPhysicalBundle =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "issuing.physical_bundle"

[<Struct>]
type IssuingNetworkTokenDeviceType =
    | Other
    | Phone
    | Watch

type IssuingNetworkTokenDevice =
    {
        /// An obfuscated ID derived from the device ID.
        DeviceFingerprint: string option
        /// The IP address of the device at provisioning time.
        IpAddress: string option
        /// The geographic latitude/longitude coordinates of the device at provisioning time. The format is [+-]decimal/[+-]decimal.
        Location: string option
        /// The name of the device used for tokenization.
        Name: string option
        /// The phone number of the device used for tokenization.
        PhoneNumber: string option
        /// The type of device used for tokenization.
        Type: IssuingNetworkTokenDeviceType option
    }

type IssuingNetworkTokenMastercard =
    {
        /// A unique reference ID from MasterCard to represent the card account number.
        CardReferenceId: string option
        /// The network-unique identifier for the token.
        TokenReferenceId: string
        /// The ID of the entity requesting tokenization, specific to MasterCard.
        TokenRequestorId: string
        /// The name of the entity requesting tokenization, if known. This is directly provided from MasterCard.
        TokenRequestorName: string option
    }

[<Struct>]
type IssuingNetworkTokenNetworkDataType =
    | Mastercard
    | Visa

type IssuingNetworkTokenVisa =
    {
        /// A unique reference ID from Visa to represent the card account number.
        CardReferenceId: string option
        /// The network-unique identifier for the token.
        TokenReferenceId: string
        /// The ID of the entity requesting tokenization, specific to Visa.
        TokenRequestorId: string
        /// Degree of risk associated with the token between `01` and `99`, with higher number indicating higher risk. A `00` value indicates the token was not scored by Visa.
        TokenRiskScore: string option
    }

type IssuingNetworkTokenAddress =
    {
        /// The street address of the cardholder tokenizing the card.
        [<JsonPropertyName("line1")>]
        Line1: string
        /// The postal code of the cardholder tokenizing the card.
        PostalCode: string
    }

[<Struct>]
type IssuingNetworkTokenWalletProviderCardNumberSource =
    | App
    | Manual
    | OnFile
    | Other

type IssuingNetworkTokenWalletProviderReasonCodes =
    | AccountCardTooNew
    | AccountRecentlyChanged
    | AccountTooNew
    | AccountTooNewSinceLaunch
    | AdditionalDevice
    | DataExpired
    | DeferIdVDecision
    | DeviceRecentlyLost
    | GoodActivityHistory
    | HasSuspendedTokens
    | HighRisk
    | InactiveAccount
    | LongAccountTenure
    | LowAccountScore
    | LowDeviceScore
    | LowPhoneNumberScore
    | NetworkServiceError
    | OutsideHomeTerritory
    | ProvisioningCardholderMismatch
    | ProvisioningDeviceAndCardholderMismatch
    | ProvisioningDeviceMismatch
    | SameDeviceNoPriorAuthentication
    | SameDeviceSuccessfulPriorAuthentication
    | SoftwareUpdate
    | SuspiciousActivity
    | TooManyDifferentCardholders
    | TooManyRecentAttempts
    | TooManyRecentTokens

[<Struct>]
type IssuingNetworkTokenWalletProviderSuggestedDecision =
    | Approve
    | Decline
    | RequireAuth

type IssuingNetworkTokenWalletProvider =
    {
        /// The wallet provider-given account ID of the digital wallet the token belongs to.
        AccountId: string option
        /// An evaluation on the trustworthiness of the wallet account between 1 and 5. A higher score indicates more trustworthy.
        AccountTrustScore: int option
        /// The method used for tokenizing a card.
        CardNumberSource: IssuingNetworkTokenWalletProviderCardNumberSource option
        CardholderAddress: IssuingNetworkTokenAddress option
        /// The name of the cardholder tokenizing the card.
        CardholderName: string option
        /// An evaluation on the trustworthiness of the device. A higher score indicates more trustworthy.
        DeviceTrustScore: int option
        /// The hashed email address of the cardholder's account with the wallet provider.
        HashedAccountEmailAddress: string option
        /// The reasons for suggested tokenization given by the card network.
        ReasonCodes: IssuingNetworkTokenWalletProviderReasonCodes list option
        /// The recommendation on responding to the tokenization request.
        SuggestedDecision: IssuingNetworkTokenWalletProviderSuggestedDecision option
        /// The version of the standard for mapping reason codes followed by the wallet provider.
        SuggestedDecisionVersion: string option
    }

type IssuingNetworkTokenNetworkData =
    {
        Device: IssuingNetworkTokenDevice option
        Mastercard: IssuingNetworkTokenMastercard option
        /// The network that the token is associated with. An additional hash is included with a name matching this value, containing tokenization data specific to the card network.
        Type: IssuingNetworkTokenNetworkDataType
        Visa: IssuingNetworkTokenVisa option
        WalletProvider: IssuingNetworkTokenWalletProvider option
    }

