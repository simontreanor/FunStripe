namespace Stripe.Deleted

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type DeletedWebhookEndpoint =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedWebhookEndpoint =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "webhook_endpoint"

type DeletedTestHelpersTestClock =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedTestHelpersTestClock =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "test_helpers.test_clock"

type DeletedTerminalReaderDeviceType =
    | BbposChipper2x
    | BbposWisepad3
    | BbposWiseposE
    | MobilePhoneReader
    | SimulatedStripeS700
    | SimulatedStripeS710
    | SimulatedWiseposE
    | StripeM2
    | StripeS700
    | StripeS710
    | VerifoneP400

type DeletedTerminalReader =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Device type of the reader.
        DeviceType: DeletedTerminalReaderDeviceType
        /// Unique identifier for the object.
        Id: string
        /// Serial number of the reader.
        SerialNumber: string
    }

module DeletedTerminalReader =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.reader"

type DeletedTerminalLocation =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedTerminalLocation =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.location"

type DeletedTerminalConfiguration =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedTerminalConfiguration =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "terminal.configuration"

type DeletedSubscriptionItem =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedSubscriptionItem =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "subscription_item"

type DeletedRadarValueListItem =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedRadarValueListItem =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "radar.value_list_item"

type DeletedRadarValueList =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedRadarValueList =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "radar.value_list"

type DeletedProductFeature =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedProductFeature =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "product_feature"

type DeletedPerson =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedPerson =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "person"

type DeletedInvoiceitem =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedInvoiceitem =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "invoiceitem"

type DeletedCoupon =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedCoupon =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "coupon"

type DeletedApplePayDomain =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedApplePayDomain =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "apple_pay_domain"

type DeletedAccount =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedAccount =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "account"

type DeletedCard =
    {
        /// Three-letter [ISO code for the currency](https://stripe.com/docs/payouts) paid out to the bank account.
        Currency: IsoTypes.IsoCurrencyCode option
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedCard =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "card"

type DeletedBankAccount =
    {
        /// Three-letter [ISO code for the currency](https://stripe.com/docs/payouts) paid out to the bank account.
        Currency: IsoTypes.IsoCurrencyCode option
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedBankAccount =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "bank_account"

