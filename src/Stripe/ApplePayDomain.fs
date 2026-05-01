namespace Stripe.ApplePayDomain

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type DeletedApplePayDomain =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

type DeletedApplePayDomain with
    static member New(deleted: bool, id: string) =
        {
            Deleted = deleted
            Id = id
        }

module DeletedApplePayDomain =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "apple_pay_domain"

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

type ApplePayDomain with
    static member New(created: DateTime, domainName: string, id: string, livemode: bool) =
        {
            Created = created
            DomainName = domainName
            Id = id
            Livemode = livemode
        }

module ApplePayDomain =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "apple_pay_domain"

