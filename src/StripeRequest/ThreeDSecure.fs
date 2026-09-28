namespace StripeRequest.ThreeDSecure

open FunStripe
open System.Text.Json.Serialization
open Stripe.ThreeDSecure
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.5.0")>]
module ThreeDSecureAuthentications =

    type ListOptions =
        {
            /// A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp or a dictionary with a number of different query options.
            [<Config.Query>]
            Created: int option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return 3D Secure Authentications for specified status.
            [<Config.Query>]
            Status: string option
        }

    type ListOptions with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    type Create'AcquirerDetails =
        {
            /// The Acquirer BIN (specific to the directory_server).
            [<Config.Form>]
            AcquirerBin: string option
            /// The two-letter country code of the acquirer ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
            [<Config.Form>]
            AcquirerCountry: IsoTypes.IsoCountryCode option
            /// The Merchant ID (or Card Acceptor ID) that your acquirer assigned you (specific to the directory_server).
            [<Config.Form>]
            AcquirerMerchantId: string option
            /// The [merchant category code](https://en.wikipedia.org/wiki/Merchant_category_code) as defined by each payment system or directory server.
            [<Config.Form>]
            Mcc: string option
            /// The merchant name assigned by the acquirer or payment system. Same name used in the authorization message as defined in [ISO 8583](https://en.wikipedia.org/wiki/ISO_8583).
            [<Config.Form>]
            MerchantName: string option
            /// Requestor ID if you’re enrolled in the card network’s 3DS program. Otherwise, you can omit this field because Stripe assigns a Requestor ID with the card networks.
            [<Config.Form>]
            RequestorId: string option
        }

    type Create'AcquirerDetails with
        static member New(?acquirerBin: string, ?acquirerCountry: IsoTypes.IsoCountryCode, ?acquirerMerchantId: string, ?mcc: string, ?merchantName: string, ?requestorId: string) =
            {
                AcquirerBin = acquirerBin
                AcquirerCountry = acquirerCountry
                AcquirerMerchantId = acquirerMerchantId
                Mcc = mcc
                MerchantName = merchantName
                RequestorId = requestorId
            }

    type Create'ChannelBrowser =
        {
            /// The HTTP accept headers from the cardholder's browser. Collected server-side.
            [<Config.Form>]
            AcceptHeader: string option
            /// The color depth of the cardholder’s screen.
            /// Returned from the `screen.colorDepth` property.
            [<Config.Form>]
            ColorDepth: int option
            /// Unique and immutable identifier linked to a device that is consistent across 3DS transactions for the specific user device. For example: hardware device ID or a platform-calculated device fingerprint.
            [<Config.Form>]
            DeviceId: string option
            /// The IP address of the browser. Included in the HTTP request to your server before you create the 3DS Authentication.
            /// Collected server-side.
            [<Config.Form>]
            IpAddress: string option
            /// The cardholder browser’s ability to execute Java. Returned from the navigator.javaEnabled property.
            [<Config.Form>]
            JavaEnabled: bool option
            /// The cardholder browser’s ability to execute JavaScript.
            [<Config.Form>]
            JavascriptEnabled: bool option
            /// An IETF BCP 47 language tag representing the browser language. Typically returned from the `navigator.language` property, but might also be returned from `navigator.languages` or `navigator.browserLanguage`.
            /// In some cases, this value might be an array. To cast it to a string or null value, you can use the `getBrowserLanguage()` [example function](/payments/3d-secure/standalone-3d-secure#pass-client-side-collected-channel-information).
            [<Config.Form>]
            Language: string option
            /// The total height of the cardholder’s screen in pixels.
            /// Returned from the `screen.height` property.
            [<Config.Form>]
            ScreenHeight: int option
            /// The total width of the cardholder’s screen in pixels.
            /// Returned from the `screen.width` property.
            [<Config.Form>]
            ScreenWidth: int option
            /// The time difference between UTC time and the local time of the cardholder’s browser, in minutes.
            /// Returned by `new Date().getTimezoneOffset()`
            [<Config.Form>]
            TimezoneOffset: int option
            /// The browser user agent. You can retrieve this value on the client side using the `navigator.userAgent` property, or in the HTTP request to your server before you create the 3DS Authentication.
            [<Config.Form>]
            UserAgent: string option
        }

    type Create'ChannelBrowser with
        static member New(?acceptHeader: string, ?colorDepth: int, ?deviceId: string, ?ipAddress: string, ?javaEnabled: bool, ?javascriptEnabled: bool, ?language: string, ?screenHeight: int, ?screenWidth: int, ?timezoneOffset: int, ?userAgent: string) =
            {
                AcceptHeader = acceptHeader
                ColorDepth = colorDepth
                DeviceId = deviceId
                IpAddress = ipAddress
                JavaEnabled = javaEnabled
                JavascriptEnabled = javascriptEnabled
                Language = language
                ScreenHeight = screenHeight
                ScreenWidth = screenWidth
                TimezoneOffset = timezoneOffset
                UserAgent = userAgent
            }

    type Create'ChannelThreeRIType =
        | DelayedShipment
        | OtherPayment
        | Recurring
        | SplitShipment

    type Create'ChannelThreeRI =
        {
            /// ID of a prior `Authentication`. For example, the first recurring transaction that was authenticated by the cardholder.
            [<Config.Form>]
            PreviousAuthentication: string option
            /// It provides additional information to the ACS to determine the best approach for handling a 3RI request.
            [<Config.Form>]
            Type: Create'ChannelThreeRIType option
        }

    type Create'ChannelThreeRI with
        static member New(?previousAuthentication: string, ?type': Create'ChannelThreeRIType) =
            {
                PreviousAuthentication = previousAuthentication
                Type = type'
            }

    type Create'ChannelType =
        | Browser
        | [<JsonPropertyName("three_r_i")>] ThreeRI

    type Create'Channel =
        {
            /// Contains additional details about the browser details you collected.
            [<Config.Form>]
            Browser: Create'ChannelBrowser option
            /// Contains additional details about the 3DS Requestor Initiated (3RI) channel.
            [<Config.Form>]
            ThreeRI: Create'ChannelThreeRI option
            /// Type of channel you would prefer to use for this 3DS Authentication.
            [<Config.Form>]
            Type: Create'ChannelType option
        }

    type Create'Channel with
        static member New(?browser: Create'ChannelBrowser, ?threeRI: Create'ChannelThreeRI, ?type': Create'ChannelType) =
            {
                Browser = browser
                ThreeRI = threeRI
                Type = type'
            }

    type Create'DirectoryServer =
        | AmericanExpress
        | CartesBancaires
        | Discover
        | Mastercard
        | Visa

    type Create'FlowPreferenceChallengeType =
        | Mandated
        | Preferred

    type Create'FlowPreferenceChallenge =
        {
            /// Type of challenge flow you requested for this 3DS Authentication.
            [<Config.Form>]
            Type: Create'FlowPreferenceChallengeType option
        }

    type Create'FlowPreferenceChallenge with
        static member New(?type': Create'FlowPreferenceChallengeType) =
            {
                Type = type'
            }

    type Create'FlowPreferenceDataShareType =
        | DsSpecific
        | EmvStandard

    type Create'FlowPreferenceDataShare =
        {
            /// Type of data share only flow you requested for this 3DS Authentication.
            [<Config.Form>]
            Type: Create'FlowPreferenceDataShareType option
        }

    type Create'FlowPreferenceDataShare with
        static member New(?type': Create'FlowPreferenceDataShareType) =
            {
                Type = type'
            }

    type Create'FlowPreferenceFrictionlessType =
        | LowRisk
        | [<JsonPropertyName("none")>] None'

    type Create'FlowPreferenceFrictionless =
        {
            /// Type of frictionless flow you requested for this 3DS Authentication.
            [<Config.Form>]
            Type: Create'FlowPreferenceFrictionlessType option
        }

    type Create'FlowPreferenceFrictionless with
        static member New(?type': Create'FlowPreferenceFrictionlessType) =
            {
                Type = type'
            }

    type Create'FlowPreferenceType =
        | Challenge
        | DataShare
        | Frictionless

    type Create'FlowPreference =
        {
            /// Contains additional details about your challenge flow preference for this 3DS Authentication.
            [<Config.Form>]
            Challenge: Create'FlowPreferenceChallenge option
            /// Contains additional details about your data share only flow preference for this 3DS Authentication.
            [<Config.Form>]
            DataShare: Create'FlowPreferenceDataShare option
            /// Contains additional details about your frictionless flow preference for this 3DS Authentication.
            [<Config.Form>]
            Frictionless: Create'FlowPreferenceFrictionless option
            /// Type of flow you requested for this 3DS Authentication.
            [<Config.Form>]
            Type: Create'FlowPreferenceType option
        }

    type Create'FlowPreference with
        static member New(?challenge: Create'FlowPreferenceChallenge, ?dataShare: Create'FlowPreferenceDataShare, ?frictionless: Create'FlowPreferenceFrictionless, ?type': Create'FlowPreferenceType) =
            {
                Challenge = challenge
                DataShare = dataShare
                Frictionless = frictionless
                Type = type'
            }

    type Create'FutureUsageInstallmentExpiryType =
        | Date
        | Never

    type Create'FutureUsageInstallmentExpiry =
        {
            /// The date before which the last authorization related to this authentication will occur.
            [<Config.Form>]
            Date: string option
            /// The type of expiry for the future use of this authentication.
            [<Config.Form>]
            Type: Create'FutureUsageInstallmentExpiryType option
        }

    type Create'FutureUsageInstallmentExpiry with
        static member New(?date: string, ?type': Create'FutureUsageInstallmentExpiryType) =
            {
                Date = date
                Type = type'
            }

    type Create'FutureUsageInstallmentInterval = | Day

    type Create'FutureUsageInstallment =
        {
            /// A non-negative integer representing the future authorizations' amount in the [smallest currency unit](/currencies#zero-decimal).
            [<Config.Form>]
            Amount: int option
            /// Information about the expiry of the future usage of this authentication.
            [<Config.Form>]
            Expiry: Create'FutureUsageInstallmentExpiry option
            /// The unit of time for `interval_count`.
            [<Config.Form>]
            Interval: Create'FutureUsageInstallmentInterval option
            /// The minimum number of time intervals between authorizations. Must be greater than 0, and defaults to 1.
            [<Config.Form>]
            IntervalCount: int option
            /// The maximum number of installments. Must be greater than 1.
            [<Config.Form>]
            Number: int option
        }

    type Create'FutureUsageInstallment with
        static member New(?amount: int, ?expiry: Create'FutureUsageInstallmentExpiry, ?interval: Create'FutureUsageInstallmentInterval, ?intervalCount: int, ?number: int) =
            {
                Amount = amount
                Expiry = expiry
                Interval = interval
                IntervalCount = intervalCount
                Number = number
            }

    type Create'FutureUsageRecurringExpiryType =
        | Date
        | Never

    type Create'FutureUsageRecurringExpiry =
        {
            /// The date before which the last authorization related to this authentication will occur.
            [<Config.Form>]
            Date: string option
            /// The type of expiry for the future use of this authentication.
            [<Config.Form>]
            Type: Create'FutureUsageRecurringExpiryType option
        }

    type Create'FutureUsageRecurringExpiry with
        static member New(?date: string, ?type': Create'FutureUsageRecurringExpiryType) =
            {
                Date = date
                Type = type'
            }

    type Create'FutureUsageRecurringInterval = | Day

    type Create'FutureUsageRecurring =
        {
            /// A non-negative integer representing the future authorizations' amount in the [smallest currency unit](/currencies#zero-decimal).
            [<Config.Form>]
            Amount: int option
            /// Information about the expiry of the future usage of this authentication.
            [<Config.Form>]
            Expiry: Create'FutureUsageRecurringExpiry option
            /// The unit of time for `interval_count`.
            [<Config.Form>]
            Interval: Create'FutureUsageRecurringInterval option
            /// The minimum number of time intervals between authorizations. Must be greater than 0, and defaults to 1.
            [<Config.Form>]
            IntervalCount: int option
        }

    type Create'FutureUsageRecurring with
        static member New(?amount: int, ?expiry: Create'FutureUsageRecurringExpiry, ?interval: Create'FutureUsageRecurringInterval, ?intervalCount: int) =
            {
                Amount = amount
                Expiry = expiry
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'FutureUsageType =
        | CardOnFile
        | Installment
        | Recurring

    type Create'FutureUsage =
        {
            /// Parameters related to an installment payment.
            [<Config.Form>]
            Installment: Create'FutureUsageInstallment option
            /// Parameters related to a recurring payment.
            [<Config.Form>]
            Recurring: Create'FutureUsageRecurring option
            /// The type of future usage declared for this 3DS Authentication
            [<Config.Form>]
            Type: Create'FutureUsageType option
        }

    type Create'FutureUsage with
        static member New(?installment: Create'FutureUsageInstallment, ?recurring: Create'FutureUsageRecurring, ?type': Create'FutureUsageType) =
            {
                Installment = installment
                Recurring = recurring
                Type = type'
            }

    type Create'MessageCategory =
        | NonPaymentAuthentication
        | PaymentAuthentication

    type Create'PaymentMethodDataBillingDetailsAddress =
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
            /// Country subdivision code defined in ISO 3166-2.
            [<Config.Form>]
            State: string option
        }

    type Create'PaymentMethodDataBillingDetailsAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PaymentMethodDataBillingDetails =
        {
            /// Billing address.
            [<Config.Form>]
            Address: Create'PaymentMethodDataBillingDetailsAddress option
            /// Email address.
            [<Config.Form>]
            Email: string option
            /// Full name.
            [<Config.Form>]
            Name: string option
            /// Billing phone number (including extension).
            [<Config.Form>]
            Phone: string option
        }

    type Create'PaymentMethodDataBillingDetails with
        static member New(?address: Create'PaymentMethodDataBillingDetailsAddress, ?email: string, ?name: string, ?phone: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Create'PaymentMethodDataCardCard =
        { [<Config.Form>]
          Cvc: string option
          [<Config.Form>]
          ExpMonth: int option
          [<Config.Form>]
          ExpYear: int option
          [<Config.Form>]
          Number: string option }

    type Create'PaymentMethodDataCardCard with
        static member New(?cvc: string, ?expMonth: int, ?expYear: int, ?number: string) =
            {
                Cvc = cvc
                ExpMonth = expMonth
                ExpYear = expYear
                Number = number
            }

    type Create'PaymentMethodDataCardCardToken =
        { [<Config.Form>]
          Token: string option }

    type Create'PaymentMethodDataCardCardToken with
        static member New(?token: string) =
            {
                Token = token
            }

    type Create'PaymentMethodDataType = | Card

    type Create'PaymentMethodData =
        {
            /// Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
            [<Config.Form>]
            BillingDetails: Create'PaymentMethodDataBillingDetails option
            [<Config.Form>]
            Card: Choice<Create'PaymentMethodDataCardCard,Create'PaymentMethodDataCardCardToken> option
            /// The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
            [<Config.Form>]
            Type: Create'PaymentMethodDataType option
        }

    type Create'PaymentMethodData with
        static member New(?billingDetails: Create'PaymentMethodDataBillingDetails, ?card: Choice<Create'PaymentMethodDataCardCard,Create'PaymentMethodDataCardCardToken>, ?type': Create'PaymentMethodDataType) =
            {
                BillingDetails = billingDetails
                Card = card
                Type = type'
            }

    type Create'Reason =
        | CardholderAuthentication
        | IssuerRequested
        | LiabilityShift
        | ProcessingCosts
        | RegulatoryCompliance

    type Create'ShippingAddress =
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
            /// Country subdivision code defined in ISO 3166-2.
            [<Config.Form>]
            State: string option
        }

    type Create'ShippingAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'Submit =
        | Always
        | IfFingerprintingNotSupported
        | Never

    type CreateOptions =
        {
            /// Contains additional details about the acquirer for this 3DS Authentication.
            /// Refer to the [Pass acquirer details and directory server section of the standalone 3DS guide](/payments/3d-secure/standalone-3d-secure#pass-acquirer-details-and-directory-server) for more information.
            [<Config.Form>]
            AcquirerDetails: Create'AcquirerDetails option
            /// A non-negative integer representing the amount in the [smallest currency unit](/currencies#zero-decimal). You can't include this parameter if `message_category` is `non_payment_authentication`
            [<Config.Form>]
            Amount: int option
            /// Contains additional details on the channel used for this 3DS Authentication.
            [<Config.Form>]
            Channel: Create'Channel
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The 3DS directory server with which this 3DS Authentication was processed.
            [<Config.Form>]
            DirectoryServer: Create'DirectoryServer option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Contains additional details on your flow preference for this 3DS Authentication.
            /// Refer to the [Specify a flow preference section of the standalone 3DS guide](/payments/3d-secure/standalone-3d-secure#specify-a-flow-preference) for more information.
            [<Config.Form>]
            FlowPreference: Create'FlowPreference option
            /// Contains information about future usage of this 3DS Authentication
            [<Config.Form>]
            FutureUsage: Create'FutureUsage option
            /// Indicates whether this 3DS Authentication is being performed for a payment or non-payment use case.
            [<Config.Form>]
            MessageCategory: Create'MessageCategory
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// ID of the payment method (a PaymentMethod object) to attach to this 3DS Authentication.
            [<Config.Form>]
            PaymentMethod: string option
            /// Hash used to generate the PaymentMethod to be used for this Authentication. This is mutually exclusive with the `payment_method` parameter.
            [<Config.Form>]
            PaymentMethodData: Create'PaymentMethodData option
            /// The reason for invoking standalone 3DS. This is tailored specifically for cases when you want Stripe to help determine the standalone 3DS flow to fit your use case instead of needing to select a specific 3DS flow.
            /// This parameter is exclusive with `flow_preference`. You can either use `reason` for controlling 3DS according to your business requirements, or use `flow_preference` for having fine-grained control over your 3DS flow preference.
            [<Config.Form>]
            Reason: Create'Reason option
            /// The shipping address requested by the cardholder. You should try to include as complete address information as possible.
            [<Config.Form>]
            ShippingAddress: Create'ShippingAddress option
            /// Set to `always` to skip the fingerprinting step and submit this Authentication immediately or `if_fingerprinting_not_supported` to submit this Authentication only if fingerprinting is not available. This parameter defaults to `never`.
            /// Refer to the [Submit at creation section of the standalone 3DS guide](/payments/3d-secure/standalone-3d-secure#submit-at-creation) for more information.
            [<Config.Form>]
            Submit: Create'Submit option
        }

    type CreateOptions with
        static member New(channel: Create'Channel, messageCategory: Create'MessageCategory, ?acquirerDetails: Create'AcquirerDetails, ?amount: int, ?currency: IsoTypes.IsoCurrencyCode, ?directoryServer: Create'DirectoryServer, ?expand: string list, ?flowPreference: Create'FlowPreference, ?futureUsage: Create'FutureUsage, ?metadata: Map<string, string>, ?paymentMethod: string, ?paymentMethodData: Create'PaymentMethodData, ?reason: Create'Reason, ?shippingAddress: Create'ShippingAddress, ?submit: Create'Submit) =
            {
                Channel = channel
                MessageCategory = messageCategory
                AcquirerDetails = acquirerDetails
                Amount = amount
                Currency = currency
                DirectoryServer = directoryServer
                Expand = expand
                FlowPreference = flowPreference
                FutureUsage = futureUsage
                Metadata = metadata
                PaymentMethod = paymentMethod
                PaymentMethodData = paymentMethodData
                Reason = reason
                ShippingAddress = shippingAddress
                Submit = submit
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Authentication: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(authentication: string, ?expand: string list) =
            {
                Authentication = authentication
                Expand = expand
            }

    ///<p>Returns a list of 3D Secure Authentications.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/three_d_secure/authentications"
        |> RestApi.getAsync<StripeList<ThreeDSecureAuthentication>> settings qs

    ///<p>This endpoint creates a 3DS Authentication. Refer to the <a href="/payments/3d-secure/standalone-3d-secure#create-a-3ds-authentication-object">Create a 3DS Authentication object section of the Standalone 3DS guide</a> for more information.</p>
    ///<p>You can pass the submit parameter to automatically submit the 3DS Authentication object when you create it. Refer to the <a href="/payments/3d-secure/standalone-3d-secure#submit-at-creation">Submit at creation section of the Standalone 3DS guide</a> for more information.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/three_d_secure/authentications"
        |> RestApi.postAsync<_, ThreeDSecureAuthentication> settings (Map.empty) options

    ///<p>This endpoint retrieves a 3DS Authentication.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/three_d_secure/authentications/{options.Authentication}"
        |> RestApi.getAsync<ThreeDSecureAuthentication> settings qs

module ThreeDSecureAuthenticationsCancel =

    type CancelOptions =
        {
            [<Config.Path>]
            Authentication: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    type CancelOptions with
        static member New(authentication: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Authentication = authentication
                Expand = expand
                Metadata = metadata
            }

    ///<p>This endpoint cancels a 3DS Authentication. You can cancel a 3DS Authentication object when it’s in a non-final status:
    ///<code>requires_submission</code> or <code>requires_challenge</code>.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/three_d_secure/authentications/{options.Authentication}/cancel"
        |> RestApi.postAsync<_, ThreeDSecureAuthentication> settings (Map.empty) options

module ThreeDSecureAuthenticationsSubmit =

    type SubmitOptions =
        {
            [<Config.Path>]
            Authentication: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The fingerprinting result of the issuer fingerprinting step.
            /// Refer to the [Issuer fingerprinting section of the Standalone 3DS guide](/payments/3d-secure/standalone-3d-secure#issuer-fingerprinting) for more information.
            [<Config.Form>]
            FingerprintingResult: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
        }

    type SubmitOptions with
        static member New(authentication: string, ?expand: string list, ?fingerprintingResult: string, ?metadata: Map<string, string>) =
            {
                Authentication = authentication
                Expand = expand
                FingerprintingResult = fingerprintingResult
                Metadata = metadata
            }

    ///<p>This endpoint submits a 3DS Authentication. You can submit a 3DS Authentication object when it has status <code>requires_submission</code>. Refer to the <a href="/payments/3d-secure/standalone-3d-secure#submit-the-3ds-authentication-object">Submit the 3DS Authentication object section of the Standalone 3DS guide</a> for more information.</p>
    let Submit settings (options: SubmitOptions) =
        $"/v1/three_d_secure/authentications/{options.Authentication}/submit"
        |> RestApi.postAsync<_, ThreeDSecureAuthentication> settings (Map.empty) options

