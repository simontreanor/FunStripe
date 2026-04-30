namespace Stripe.Deleted

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedWebhookEndpoint
        =
        {
          Deleted = deleted
          Id = id
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedTestHelpersTestClock
        =
        {
          Deleted = deleted
          Id = id
        }

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

    let create
        (
            deleted: bool,
            deviceType: DeletedTerminalReaderDeviceType,
            id: string,
            serialNumber: string
        ) : DeletedTerminalReader
        =
        {
          Deleted = deleted
          DeviceType = deviceType
          Id = id
          SerialNumber = serialNumber
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedTerminalLocation
        =
        {
          Deleted = deleted
          Id = id
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedTerminalConfiguration
        =
        {
          Deleted = deleted
          Id = id
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedSubscriptionItem
        =
        {
          Deleted = deleted
          Id = id
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedRadarValueListItem
        =
        {
          Deleted = deleted
          Id = id
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedRadarValueList
        =
        {
          Deleted = deleted
          Id = id
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedProductFeature
        =
        {
          Deleted = deleted
          Id = id
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedPerson
        =
        {
          Deleted = deleted
          Id = id
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedInvoiceitem
        =
        {
          Deleted = deleted
          Id = id
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedCoupon
        =
        {
          Deleted = deleted
          Id = id
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedApplePayDomain
        =
        {
          Deleted = deleted
          Id = id
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedAccount
        =
        {
          Deleted = deleted
          Id = id
        }

type DeletedPlan =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedPlan =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "plan"

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedPlan
        =
        {
          Deleted = deleted
          Id = id
        }

type DeletedPrice =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedPrice =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "price"

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedPrice
        =
        {
          Deleted = deleted
          Id = id
        }

type DeletedInvoice =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedInvoice =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "invoice"

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedInvoice
        =
        {
          Deleted = deleted
          Id = id
        }

type DeletedTaxId =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedTaxId =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "tax_id"

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedTaxId
        =
        {
          Deleted = deleted
          Id = id
        }

type DeletedProduct =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedProduct =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "product"

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedProduct
        =
        {
          Deleted = deleted
          Id = id
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedBankAccount
        =
        {
          Deleted = deleted
          Id = id
          Currency = None
        }

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

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedCard
        =
        {
          Deleted = deleted
          Id = id
          Currency = None
        }

type DeletedPaymentSource =
    | DeletedBankAccount of DeletedBankAccount
    | DeletedCard of DeletedCard

type DeletedExternalAccount =
    | DeletedBankAccount of DeletedBankAccount
    | DeletedCard of DeletedCard

type DeletedApplication =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
        /// The name of the application.
        Name: string option
    }

module DeletedApplication =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "application"

    let create
        (
            deleted: bool,
            id: string,
            name: string option
        ) : DeletedApplication
        =
        {
          Deleted = deleted
          Id = id
          Name = name
        }

type DeletedCustomer =
    {
        /// Always true for a deleted object
        Deleted: bool
        /// Unique identifier for the object.
        Id: string
    }

module DeletedCustomer =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "customer"

    let create
        (
            deleted: bool,
            id: string
        ) : DeletedCustomer
        =
        {
          Deleted = deleted
          Id = id
        }

