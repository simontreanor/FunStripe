namespace Stripe.Apple

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
type ApplePayDomain =
    {
        /// Time at which the object was created. Measured in seconds since the Unix epoch.
        Created: DateTime
        DomainName: string
        /// Unique identifier for the object.
        Id: string
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
    }

module ApplePayDomain =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "apple_pay_domain"

    let create
        (
            created: DateTime,
            domainName: string,
            id: string,
            livemode: bool
        ) : ApplePayDomain
        =
        {
          Created = created
          DomainName = domainName
          Id = id
          Livemode = livemode
        }

