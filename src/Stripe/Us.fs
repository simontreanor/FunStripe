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

