namespace Stripe.Us

open System.Text.Json.Serialization
open FunStripe
open System

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type UsBankAccountNetworksSupported =
    | Ach
    | UsDomesticWire

type UsBankAccountNetworks =
    {
        /// The preferred network.
        Preferred: string option
        /// All supported networks.
        Supported: UsBankAccountNetworksSupported list
    }

module UsBankAccountNetworks =
    let create
        (
            preferred: string option,
            supported: UsBankAccountNetworksSupported list
        ) : UsBankAccountNetworks
        =
        {
          Preferred = preferred
          Supported = supported
        }

