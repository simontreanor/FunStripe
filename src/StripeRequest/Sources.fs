namespace StripeRequest.Sources

open FunStripe
open System.Text.Json.Serialization
open Stripe.Source
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module Sources =

    type Create'Flow =
        | CodeVerification
        | [<JsonPropertyName("none")>] None'
        | Receiver
        | Redirect

    type Create'MandateAcceptanceOffline =
        {
            /// An email to contact you with if a copy of the mandate is requested, required if `type` is `offline`.
            [<Config.Form>]
            ContactEmail: string option
        }

    module Create'MandateAcceptanceOffline =
        let create
            (
                contactEmail: string option
            ) : Create'MandateAcceptanceOffline
            =
            {
              ContactEmail = contactEmail
            }

    type Create'MandateAcceptanceOnline =
        {
            /// The Unix timestamp (in seconds) when the mandate was accepted or refused by the customer.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the mandate was accepted or refused by the customer.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the mandate was accepted or refused by the customer.
            [<Config.Form>]
            UserAgent: string option
        }

    module Create'MandateAcceptanceOnline =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: string option
            ) : Create'MandateAcceptanceOnline
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Create'MandateAcceptanceStatus =
        | Accepted
        | Pending
        | Refused
        | Revoked

    type Create'MandateAcceptanceType =
        | Offline
        | Online

    type Create'MandateAcceptance =
        {
            /// The Unix timestamp (in seconds) when the mandate was accepted or refused by the customer.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the mandate was accepted or refused by the customer.
            [<Config.Form>]
            Ip: string option
            /// The parameters required to store a mandate accepted offline. Should only be set if `mandate[type]` is `offline`
            [<Config.Form>]
            Offline: Create'MandateAcceptanceOffline option
            /// The parameters required to store a mandate accepted online. Should only be set if `mandate[type]` is `online`
            [<Config.Form>]
            Online: Create'MandateAcceptanceOnline option
            /// The status of the mandate acceptance. Either `accepted` (the mandate was accepted) or `refused` (the mandate was refused).
            [<Config.Form>]
            Status: Create'MandateAcceptanceStatus option
            /// The type of acceptance information included with the mandate. Either `online` or `offline`
            [<Config.Form>]
            Type: Create'MandateAcceptanceType option
            /// The user agent of the browser from which the mandate was accepted or refused by the customer.
            [<Config.Form>]
            UserAgent: string option
        }

    module Create'MandateAcceptance =
        let create
            (
                date: DateTime option,
                ip: string option,
                offline: Create'MandateAcceptanceOffline option,
                online: Create'MandateAcceptanceOnline option,
                status: Create'MandateAcceptanceStatus option,
                ``type``: Create'MandateAcceptanceType option,
                userAgent: string option
            ) : Create'MandateAcceptance
            =
            {
              Date = date
              Ip = ip
              Offline = offline
              Online = online
              Status = status
              Type = ``type``
              UserAgent = userAgent
            }

    type Create'MandateInterval =
        | OneTime
        | Scheduled
        | Variable

    type Create'MandateNotificationMethod =
        | DeprecatedNone'
        | Email
        | Manual
        | [<JsonPropertyName("none")>] None'
        | StripeEmail

    type Create'Mandate =
        {
            /// The parameters required to notify Stripe of a mandate acceptance or refusal by the customer.
            [<Config.Form>]
            Acceptance: Create'MandateAcceptance option
            /// The amount specified by the mandate. (Leave null for a mandate covering all amounts)
            [<Config.Form>]
            Amount: Choice<int,string> option
            /// The currency specified by the mandate. (Must match `currency` of the source)
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The interval of debits permitted by the mandate. Either `one_time` (just permitting a single debit), `scheduled` (with debits on an agreed schedule or for clearly-defined events), or `variable`(for debits with any frequency)
            [<Config.Form>]
            Interval: Create'MandateInterval option
            /// The method Stripe should use to notify the customer of upcoming debit instructions and/or mandate confirmation as required by the underlying debit network. Either `email` (an email is sent directly to the customer), `manual` (a `source.mandate_notification` event is sent to your webhooks endpoint and you should handle the notification) or `none` (the underlying debit network does not require any notification).
            [<Config.Form>]
            NotificationMethod: Create'MandateNotificationMethod option
        }

    module Create'Mandate =
        let create
            (
                acceptance: Create'MandateAcceptance option,
                amount: Choice<int,string> option,
                currency: IsoTypes.IsoCurrencyCode option,
                interval: Create'MandateInterval option,
                notificationMethod: Create'MandateNotificationMethod option
            ) : Create'Mandate
            =
            {
              Acceptance = acceptance
              Amount = amount
              Currency = currency
              Interval = interval
              NotificationMethod = notificationMethod
            }

    type Create'OwnerAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    module Create'OwnerAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'OwnerAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'Owner =
        {
            /// Owner's address.
            [<Config.Form>]
            Address: Create'OwnerAddress option
            /// Owner's email address.
            [<Config.Form>]
            Email: string option
            /// Owner's full name.
            [<Config.Form>]
            Name: string option
            /// Owner's phone number.
            [<Config.Form>]
            Phone: string option
        }

    module Create'Owner =
        let create
            (
                address: Create'OwnerAddress option,
                email: string option,
                name: string option,
                phone: string option
            ) : Create'Owner
            =
            {
              Address = address
              Email = email
              Name = name
              Phone = phone
            }

    type Create'ReceiverRefundAttributesMethod =
        | Email
        | Manual
        | [<JsonPropertyName("none")>] None'

    type Create'Receiver =
        {
            /// The method Stripe should use to request information needed to process a refund or mispayment. Either `email` (an email is sent directly to the customer) or `manual` (a `source.refund_attributes_required` event is sent to your webhooks endpoint). Refer to each payment method's documentation to learn which refund attributes may be required.
            [<Config.Form>]
            RefundAttributesMethod: Create'ReceiverRefundAttributesMethod option
        }

    module Create'Receiver =
        let create
            (
                refundAttributesMethod: Create'ReceiverRefundAttributesMethod option
            ) : Create'Receiver
            =
            {
              RefundAttributesMethod = refundAttributesMethod
            }

    type Create'Redirect =
        {
            /// The URL you provide to redirect the customer back to you after they authenticated their payment. It can use your application URI scheme in the context of a mobile application.
            [<Config.Form>]
            ReturnUrl: string option
        }

    module Create'Redirect =
        let create
            (
                returnUrl: string option
            ) : Create'Redirect
            =
            {
              ReturnUrl = returnUrl
            }

    type Create'SourceOrderItemsType =
        | Discount
        | Shipping
        | Sku
        | Tax

    type Create'SourceOrderItems =
        {
            [<Config.Form>]
            Amount: int option
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            [<Config.Form>]
            Description: string option
            /// The ID of the SKU being ordered.
            [<Config.Form>]
            Parent: string option
            /// The quantity of this order item. When type is `sku`, this is the number of instances of the SKU to be ordered.
            [<Config.Form>]
            Quantity: int option
            [<Config.Form>]
            Type: Create'SourceOrderItemsType option
        }

    module Create'SourceOrderItems =
        let create
            (
                amount: int option,
                currency: IsoTypes.IsoCurrencyCode option,
                description: string option,
                parent: string option,
                quantity: int option,
                ``type``: Create'SourceOrderItemsType option
            ) : Create'SourceOrderItems
            =
            {
              Amount = amount
              Currency = currency
              Description = description
              Parent = parent
              Quantity = quantity
              Type = ``type``
            }

    type Create'SourceOrderShippingAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    module Create'SourceOrderShippingAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Create'SourceOrderShippingAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Create'SourceOrderShipping =
        {
            /// Shipping address.
            [<Config.Form>]
            Address: Create'SourceOrderShippingAddress option
            /// The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
            [<Config.Form>]
            Carrier: string option
            /// Recipient name.
            [<Config.Form>]
            Name: string option
            /// Recipient phone (including extension).
            [<Config.Form>]
            Phone: string option
            /// The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
            [<Config.Form>]
            TrackingNumber: string option
        }

    module Create'SourceOrderShipping =
        let create
            (
                address: Create'SourceOrderShippingAddress option,
                carrier: string option,
                name: string option,
                phone: string option,
                trackingNumber: string option
            ) : Create'SourceOrderShipping
            =
            {
              Address = address
              Carrier = carrier
              Name = name
              Phone = phone
              TrackingNumber = trackingNumber
            }

    type Create'SourceOrder =
        {
            /// List of items constituting the order.
            [<Config.Form>]
            Items: Create'SourceOrderItems list option
            /// Shipping address for the order. Required if any of the SKUs are for products that have `shippable` set to true.
            [<Config.Form>]
            Shipping: Create'SourceOrderShipping option
        }

    module Create'SourceOrder =
        let create
            (
                items: Create'SourceOrderItems list option,
                shipping: Create'SourceOrderShipping option
            ) : Create'SourceOrder
            =
            {
              Items = items
              Shipping = shipping
            }

    type Create'Usage =
        | Reusable
        | SingleUse

    type CreateOptions =
        {
            /// Amount associated with the source. This is the amount for which the source will be chargeable once ready. Required for `single_use` sources. Not supported for `receiver` type sources, where charge amount may not be specified until funds land.
            [<Config.Form>]
            Amount: int option
            /// Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) associated with the source. This is the currency for which the source will be chargeable once ready.
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The `Customer` to whom the original source is attached to. Must be set when the original source is not a `Source` (e.g., `Card`).
            [<Config.Form>]
            Customer: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The authentication `flow` of the source to create. `flow` is one of `redirect`, `receiver`, `code_verification`, `none`. It is generally inferred unless a type supports multiple flows.
            [<Config.Form>]
            Flow: Create'Flow option
            /// Information about a mandate possibility attached to a source object (generally for bank debits) as well as its acceptance status.
            [<Config.Form>]
            Mandate: Create'Mandate option
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The source to share.
            [<Config.Form>]
            OriginalSource: string option
            /// Information about the owner of the payment instrument that may be used or required by particular source types.
            [<Config.Form>]
            Owner: Create'Owner option
            /// Optional parameters for the receiver flow. Can be set only if the source is a receiver (`flow` is `receiver`).
            [<Config.Form>]
            Receiver: Create'Receiver option
            /// Parameters required for the redirect flow. Required if the source is authenticated by a redirect (`flow` is `redirect`).
            [<Config.Form>]
            Redirect: Create'Redirect option
            /// Information about the items and shipping associated with the source. Required for transactional credit (for example Klarna) sources before you can charge it.
            [<Config.Form>]
            SourceOrder: Create'SourceOrder option
            /// An arbitrary string to be displayed on your customer's statement. As an example, if your website is `RunClub` and the item you're charging for is a race ticket, you may want to specify a `statement_descriptor` of `RunClub 5K race ticket.` While many payment types will display this information, some may not display it at all.
            [<Config.Form>]
            StatementDescriptor: string option
            /// An optional token used to create the source. When passed, token properties will override source parameters.
            [<Config.Form>]
            Token: string option
            /// The `type` of the source to create. Required unless `customer` and `original_source` are specified (see the [Cloning card Sources](https://docs.stripe.com/sources/connect#cloning-card-sources) guide)
            [<Config.Form>]
            Type: string option
            [<Config.Form>]
            Usage: Create'Usage option
        }

    module CreateOptions =
        let create
            (
                amount: int option,
                currency: IsoTypes.IsoCurrencyCode option,
                customer: string option,
                expand: string list option,
                flow: Create'Flow option,
                mandate: Create'Mandate option,
                metadata: Map<string, string> option,
                originalSource: string option,
                owner: Create'Owner option,
                receiver: Create'Receiver option,
                redirect: Create'Redirect option,
                sourceOrder: Create'SourceOrder option,
                statementDescriptor: string option,
                token: string option,
                ``type``: string option,
                usage: Create'Usage option
            ) : CreateOptions
            =
            {
              Amount = amount
              Currency = currency
              Customer = customer
              Expand = expand
              Flow = flow
              Mandate = mandate
              Metadata = metadata
              OriginalSource = originalSource
              Owner = owner
              Receiver = receiver
              Redirect = redirect
              SourceOrder = sourceOrder
              StatementDescriptor = statementDescriptor
              Token = token
              Type = ``type``
              Usage = usage
            }

    type RetrieveOptions =
        {
            /// The client secret of the source. Required if a publishable key is used to retrieve the source.
            [<Config.Query>]
            ClientSecret: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Source: string
        }

    module RetrieveOptions =
        let create
            (
                source: string,
                clientSecret: string option,
                expand: string list option
            ) : RetrieveOptions
            =
            {
              Source = source
              ClientSecret = clientSecret
              Expand = expand
            }

    type Update'MandateAcceptanceOffline =
        {
            /// An email to contact you with if a copy of the mandate is requested, required if `type` is `offline`.
            [<Config.Form>]
            ContactEmail: string option
        }

    module Update'MandateAcceptanceOffline =
        let create
            (
                contactEmail: string option
            ) : Update'MandateAcceptanceOffline
            =
            {
              ContactEmail = contactEmail
            }

    type Update'MandateAcceptanceOnline =
        {
            /// The Unix timestamp (in seconds) when the mandate was accepted or refused by the customer.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the mandate was accepted or refused by the customer.
            [<Config.Form>]
            Ip: string option
            /// The user agent of the browser from which the mandate was accepted or refused by the customer.
            [<Config.Form>]
            UserAgent: string option
        }

    module Update'MandateAcceptanceOnline =
        let create
            (
                date: DateTime option,
                ip: string option,
                userAgent: string option
            ) : Update'MandateAcceptanceOnline
            =
            {
              Date = date
              Ip = ip
              UserAgent = userAgent
            }

    type Update'MandateAcceptanceStatus =
        | Accepted
        | Pending
        | Refused
        | Revoked

    type Update'MandateAcceptanceType =
        | Offline
        | Online

    type Update'MandateAcceptance =
        {
            /// The Unix timestamp (in seconds) when the mandate was accepted or refused by the customer.
            [<Config.Form>]
            Date: DateTime option
            /// The IP address from which the mandate was accepted or refused by the customer.
            [<Config.Form>]
            Ip: string option
            /// The parameters required to store a mandate accepted offline. Should only be set if `mandate[type]` is `offline`
            [<Config.Form>]
            Offline: Update'MandateAcceptanceOffline option
            /// The parameters required to store a mandate accepted online. Should only be set if `mandate[type]` is `online`
            [<Config.Form>]
            Online: Update'MandateAcceptanceOnline option
            /// The status of the mandate acceptance. Either `accepted` (the mandate was accepted) or `refused` (the mandate was refused).
            [<Config.Form>]
            Status: Update'MandateAcceptanceStatus option
            /// The type of acceptance information included with the mandate. Either `online` or `offline`
            [<Config.Form>]
            Type: Update'MandateAcceptanceType option
            /// The user agent of the browser from which the mandate was accepted or refused by the customer.
            [<Config.Form>]
            UserAgent: string option
        }

    module Update'MandateAcceptance =
        let create
            (
                date: DateTime option,
                ip: string option,
                offline: Update'MandateAcceptanceOffline option,
                online: Update'MandateAcceptanceOnline option,
                status: Update'MandateAcceptanceStatus option,
                ``type``: Update'MandateAcceptanceType option,
                userAgent: string option
            ) : Update'MandateAcceptance
            =
            {
              Date = date
              Ip = ip
              Offline = offline
              Online = online
              Status = status
              Type = ``type``
              UserAgent = userAgent
            }

    type Update'MandateInterval =
        | OneTime
        | Scheduled
        | Variable

    type Update'MandateNotificationMethod =
        | DeprecatedNone'
        | Email
        | Manual
        | [<JsonPropertyName("none")>] None'
        | StripeEmail

    type Update'Mandate =
        {
            /// The parameters required to notify Stripe of a mandate acceptance or refusal by the customer.
            [<Config.Form>]
            Acceptance: Update'MandateAcceptance option
            /// The amount specified by the mandate. (Leave null for a mandate covering all amounts)
            [<Config.Form>]
            Amount: Choice<int,string> option
            /// The currency specified by the mandate. (Must match `currency` of the source)
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The interval of debits permitted by the mandate. Either `one_time` (just permitting a single debit), `scheduled` (with debits on an agreed schedule or for clearly-defined events), or `variable`(for debits with any frequency)
            [<Config.Form>]
            Interval: Update'MandateInterval option
            /// The method Stripe should use to notify the customer of upcoming debit instructions and/or mandate confirmation as required by the underlying debit network. Either `email` (an email is sent directly to the customer), `manual` (a `source.mandate_notification` event is sent to your webhooks endpoint and you should handle the notification) or `none` (the underlying debit network does not require any notification).
            [<Config.Form>]
            NotificationMethod: Update'MandateNotificationMethod option
        }

    module Update'Mandate =
        let create
            (
                acceptance: Update'MandateAcceptance option,
                amount: Choice<int,string> option,
                currency: IsoTypes.IsoCurrencyCode option,
                interval: Update'MandateInterval option,
                notificationMethod: Update'MandateNotificationMethod option
            ) : Update'Mandate
            =
            {
              Acceptance = acceptance
              Amount = amount
              Currency = currency
              Interval = interval
              NotificationMethod = notificationMethod
            }

    type Update'OwnerAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    module Update'OwnerAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'OwnerAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'Owner =
        {
            /// Owner's address.
            [<Config.Form>]
            Address: Update'OwnerAddress option
            /// Owner's email address.
            [<Config.Form>]
            Email: string option
            /// Owner's full name.
            [<Config.Form>]
            Name: string option
            /// Owner's phone number.
            [<Config.Form>]
            Phone: string option
        }

    module Update'Owner =
        let create
            (
                address: Update'OwnerAddress option,
                email: string option,
                name: string option,
                phone: string option
            ) : Update'Owner
            =
            {
              Address = address
              Email = email
              Name = name
              Phone = phone
            }

    type Update'SourceOrderItemsType =
        | Discount
        | Shipping
        | Sku
        | Tax

    type Update'SourceOrderItems =
        {
            [<Config.Form>]
            Amount: int option
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            [<Config.Form>]
            Description: string option
            /// The ID of the SKU being ordered.
            [<Config.Form>]
            Parent: string option
            /// The quantity of this order item. When type is `sku`, this is the number of instances of the SKU to be ordered.
            [<Config.Form>]
            Quantity: int option
            [<Config.Form>]
            Type: Update'SourceOrderItemsType option
        }

    module Update'SourceOrderItems =
        let create
            (
                amount: int option,
                currency: IsoTypes.IsoCurrencyCode option,
                description: string option,
                parent: string option,
                quantity: int option,
                ``type``: Update'SourceOrderItemsType option
            ) : Update'SourceOrderItems
            =
            {
              Amount = amount
              Currency = currency
              Description = description
              Parent = parent
              Quantity = quantity
              Type = ``type``
            }

    type Update'SourceOrderShippingAddress =
        {
            /// City, district, suburb, town, or village.
            [<Config.Form>]
            City: string option
            /// Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            Country: IsoTypes.IsoCountryCode option
            /// Address line 1, such as the street, PO Box, or company name.
            [<Config.Form>]
            Line1: string option
            /// Address line 2, such as the apartment, suite, unit, or building.
            [<Config.Form>]
            Line2: string option
            /// ZIP or postal code.
            [<Config.Form>]
            PostalCode: string option
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
            [<Config.Form>]
            State: string option
        }

    module Update'SourceOrderShippingAddress =
        let create
            (
                city: string option,
                country: IsoTypes.IsoCountryCode option,
                line1: string option,
                line2: string option,
                postalCode: string option,
                state: string option
            ) : Update'SourceOrderShippingAddress
            =
            {
              City = city
              Country = country
              Line1 = line1
              Line2 = line2
              PostalCode = postalCode
              State = state
            }

    type Update'SourceOrderShipping =
        {
            /// Shipping address.
            [<Config.Form>]
            Address: Update'SourceOrderShippingAddress option
            /// The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
            [<Config.Form>]
            Carrier: string option
            /// Recipient name.
            [<Config.Form>]
            Name: string option
            /// Recipient phone (including extension).
            [<Config.Form>]
            Phone: string option
            /// The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
            [<Config.Form>]
            TrackingNumber: string option
        }

    module Update'SourceOrderShipping =
        let create
            (
                address: Update'SourceOrderShippingAddress option,
                carrier: string option,
                name: string option,
                phone: string option,
                trackingNumber: string option
            ) : Update'SourceOrderShipping
            =
            {
              Address = address
              Carrier = carrier
              Name = name
              Phone = phone
              TrackingNumber = trackingNumber
            }

    type Update'SourceOrder =
        {
            /// List of items constituting the order.
            [<Config.Form>]
            Items: Update'SourceOrderItems list option
            /// Shipping address for the order. Required if any of the SKUs are for products that have `shippable` set to true.
            [<Config.Form>]
            Shipping: Update'SourceOrderShipping option
        }

    module Update'SourceOrder =
        let create
            (
                items: Update'SourceOrderItems list option,
                shipping: Update'SourceOrderShipping option
            ) : Update'SourceOrder
            =
            {
              Items = items
              Shipping = shipping
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Source: string
            /// Amount associated with the source.
            [<Config.Form>]
            Amount: int option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Information about a mandate possibility attached to a source object (generally for bank debits) as well as its acceptance status.
            [<Config.Form>]
            Mandate: Update'Mandate option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Information about the owner of the payment instrument that may be used or required by particular source types.
            [<Config.Form>]
            Owner: Update'Owner option
            /// Information about the items and shipping associated with the source. Required for transactional credit (for example Klarna) sources before you can charge it.
            [<Config.Form>]
            SourceOrder: Update'SourceOrder option
        }

    module UpdateOptions =
        let create
            (
                source: string,
                amount: int option,
                expand: string list option,
                mandate: Update'Mandate option,
                metadata: Map<string, string> option,
                owner: Update'Owner option,
                sourceOrder: Update'SourceOrder option
            ) : UpdateOptions
            =
            {
              Source = source
              Amount = amount
              Expand = expand
              Mandate = mandate
              Metadata = metadata
              Owner = owner
              SourceOrder = sourceOrder
            }

    ///<p>Creates a new source object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/sources"
        |> RestApi.postAsync<_, Source> settings (Map.empty) options

    ///<p>Retrieves an existing source object. Supply the unique source ID from a source creation request and Stripe will return the corresponding up-to-date source object information.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("client_secret", options.ClientSecret |> box); ("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/sources/{options.Source}"
        |> RestApi.getAsync<Source> settings qs

    ///<p>Updates the specified source by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    ///<p>This request accepts the <code>metadata</code> and <code>owner</code> as arguments. It is also possible to update type specific information for selected payment methods. Please refer to our <a href="/docs/sources">payment method guides</a> for more detail.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/sources/{options.Source}"
        |> RestApi.postAsync<_, Source> settings (Map.empty) options

module SourcesSourceTransactions =

    type SourceTransactionsOptions =
        {
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            [<Config.Path>]
            Source: string
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    module SourceTransactionsOptions =
        let create
            (
                source: string,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : SourceTransactionsOptions
            =
            {
              Source = source
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    ///<p>List source transactions for a given source.</p>
    let SourceTransactions settings (options: SourceTransactionsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/sources/{options.Source}/source_transactions"
        |> RestApi.getAsync<StripeList<SourceTransaction>> settings qs

module SourcesVerify =

    type VerifyOptions =
        {
            [<Config.Path>]
            Source: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The values needed to verify the source.
            [<Config.Form>]
            Values: string list
        }

    module VerifyOptions =
        let create
            (
                source: string,
                values: string list,
                expand: string list option
            ) : VerifyOptions
            =
            {
              Source = source
              Values = values
              Expand = expand
            }

    ///<p>Verify a given source.</p>
    let Verify settings (options: VerifyOptions) =
        $"/v1/sources/{options.Source}/verify"
        |> RestApi.postAsync<_, Source> settings (Map.empty) options

