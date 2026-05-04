namespace StripeRequest.Charges

open FunStripe
open System.Text.Json.Serialization
open Stripe.PaymentMethod
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
module Charges =

    type ListOptions =
        {
            /// Only return charges that were created during the given date interval.
            [<Config.Query>]
            Created: int option
            /// Only return charges for the customer specified by this customer ID.
            [<Config.Query>]
            Customer: string option
            /// A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
            [<Config.Query>]
            EndingBefore: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// Only return charges that were created by the PaymentIntent specified by this PaymentIntent ID.
            [<Config.Query>]
            PaymentIntent: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
            /// Only return charges for this transfer group, limited to 100.
            [<Config.Query>]
            TransferGroup: string option
        }

    type ListOptions with
        static member New(?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string, ?transferGroup: string) =
            {
                Created = created
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                PaymentIntent = paymentIntent
                StartingAfter = startingAfter
                TransferGroup = transferGroup
            }

    type Create'Destination =
        {
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Account: string option
            /// The amount to transfer to the destination account without creating an `Application Fee` object. Cannot be combined with the `application_fee` parameter. Must be less than or equal to the charge amount.
            [<Config.Form>]
            Amount: int option
        }

    type Create'Destination with
        static member New(?account: string, ?amount: int) =
            {
                Account = account
                Amount = amount
            }

    type Create'RadarOptions =
        {
            /// A [Radar Session](https://docs.stripe.com/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
            [<Config.Form>]
            Session: string option
        }

    type Create'RadarOptions with
        static member New(?session: string) =
            {
                Session = session
            }

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
            /// State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).
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

    type Create'Shipping =
        {
            /// Shipping address.
            [<Config.Form>]
            Address: Create'ShippingAddress option
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

    type Create'Shipping with
        static member New(?address: Create'ShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type Create'TransferData =
        {
            /// The amount transferred to the destination account, if specified. By default, the entire charge amount is transferred to the destination account.
            [<Config.Form>]
            Amount: int option
            /// ID of an existing, connected Stripe account.
            [<Config.Form>]
            Destination: string option
        }

    type Create'TransferData with
        static member New(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type CreateOptions =
        {
            /// Amount intended to be collected by this payment. A positive integer representing how much to charge in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://docs.stripe.com/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
            [<Config.Form>]
            Amount: int option
            [<Config.Form>]
            ApplicationFee: int option
            /// A fee in cents (or local equivalent) that will be applied to the charge and transferred to the application owner's Stripe account. The request must be made with an OAuth key or the `Stripe-Account` header in order to take an application fee. For more information, see the application fees [documentation](https://docs.stripe.com/connect/direct-charges#collect-fees).
            [<Config.Form>]
            ApplicationFeeAmount: int option
            /// Whether to immediately capture the charge. Defaults to `true`. When `false`, the charge issues an authorization (or pre-authorization), and will need to be [captured](https://api.stripe.com#capture_charge) later. Uncaptured charges expire after a set number of days (7 by default). For more information, see the [authorizing charges and settling later](https://docs.stripe.com/charges/placing-a-hold) documentation.
            [<Config.Form>]
            Capture: bool option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// The ID of an existing customer that will be charged in this request.
            [<Config.Form>]
            Customer: string option
            /// An arbitrary string which you can attach to a `Charge` object. It is displayed when in the web interface alongside the charge. Note that if you use Stripe to send automatic email receipts to your customers, your receipt emails will include the `description` of the charge(s) that they are describing.
            [<Config.Form>]
            Description: string option
            [<Config.Form>]
            Destination: Create'Destination option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The Stripe account ID for which these funds are intended. You can specify the business of record as the connected account using the `on_behalf_of` attribute on the charge. For details, see [Creating Separate Charges and Transfers](https://docs.stripe.com/connect/separate-charges-and-transfers#settlement-merchant).
            [<Config.Form>]
            OnBehalfOf: string option
            /// Options to configure Radar. See [Radar Session](https://docs.stripe.com/radar/radar-session) for more information.
            [<Config.Form>]
            RadarOptions: Create'RadarOptions option
            /// The email address to which this charge's [receipt](https://docs.stripe.com/dashboard/receipts) will be sent. The receipt will not be sent until the charge is paid, and no receipts will be sent for test mode charges. If this charge is for a [Customer](https://docs.stripe.com/api/customers/object), the email address specified here will override the customer's email address. If `receipt_email` is specified for a charge in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).
            [<Config.Form>]
            ReceiptEmail: string option
            /// Shipping information for the charge. Helps prevent fraud on charges for physical goods.
            [<Config.Form>]
            Shipping: Create'Shipping option
            /// A payment source to be charged. This can be the ID of a [card](https://docs.stripe.com/api#cards) (i.e., credit or debit card), a [bank account](https://docs.stripe.com/api#bank_accounts), a [source](https://docs.stripe.com/api#sources), a [token](https://docs.stripe.com/api#tokens), or a [connected account](https://docs.stripe.com/connect/account-debits#charging-a-connected-account). For certain sources---namely, [cards](https://docs.stripe.com/api#cards), [bank accounts](https://docs.stripe.com/api#bank_accounts), and attached [sources](https://docs.stripe.com/api#sources)---you must also pass the ID of the associated customer.
            [<Config.Form>]
            Source: string option
            /// For a non-card charge, text that appears on the customer's statement as the statement descriptor. This value overrides the account's default statement descriptor. For information about requirements, including the 22-character limit, see [the Statement Descriptor docs](https://docs.stripe.com/get-started/account/statement-descriptors).
            /// For a card charge, this value is ignored unless you don't specify a `statement_descriptor_suffix`, in which case this value is used as the suffix.
            [<Config.Form>]
            StatementDescriptor: string option
            /// Provides information about a card charge. Concatenated to the account's [statement descriptor prefix](https://docs.stripe.com/get-started/account/statement-descriptors#static) to form the complete statement descriptor that appears on the customer's statement. If the account has no prefix value, the suffix is concatenated to the account's statement descriptor.
            [<Config.Form>]
            StatementDescriptorSuffix: string option
            /// An optional dictionary including the account to automatically transfer to as part of a destination charge. [See the Connect documentation](https://docs.stripe.com/connect/destination-charges) for details.
            [<Config.Form>]
            TransferData: Create'TransferData option
            /// A string that identifies this transaction as part of a group. For details, see [Grouping transactions](https://docs.stripe.com/connect/separate-charges-and-transfers#transfer-options).
            [<Config.Form>]
            TransferGroup: string option
        }

    type CreateOptions with
        static member New(?amount: int, ?applicationFee: int, ?applicationFeeAmount: int, ?capture: bool, ?currency: IsoTypes.IsoCurrencyCode, ?customer: string, ?description: string, ?destination: Create'Destination, ?expand: string list, ?metadata: Map<string, string>, ?onBehalfOf: string, ?radarOptions: Create'RadarOptions, ?receiptEmail: string, ?shipping: Create'Shipping, ?source: string, ?statementDescriptor: string, ?statementDescriptorSuffix: string, ?transferData: Create'TransferData, ?transferGroup: string) =
            {
                Amount = amount
                ApplicationFee = applicationFee
                ApplicationFeeAmount = applicationFeeAmount
                Capture = capture
                Currency = currency
                Customer = customer
                Description = description
                Destination = destination
                Expand = expand
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                RadarOptions = radarOptions
                ReceiptEmail = receiptEmail
                Shipping = shipping
                Source = source
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferData = transferData
                TransferGroup = transferGroup
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Charge: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(charge: string, ?expand: string list) =
            {
                Charge = charge
                Expand = expand
            }

    type Update'FraudDetailsUserReport =
        | Fraudulent
        | Safe

    type Update'FraudDetails =
        {
            /// Either `safe` or `fraudulent`.
            [<Config.Form>]
            UserReport: Update'FraudDetailsUserReport option
        }

    type Update'FraudDetails with
        static member New(?userReport: Update'FraudDetailsUserReport) =
            {
                UserReport = userReport
            }

    type Update'ShippingAddress =
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

    type Update'ShippingAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'Shipping =
        {
            /// Shipping address.
            [<Config.Form>]
            Address: Update'ShippingAddress option
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

    type Update'Shipping with
        static member New(?address: Update'ShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Charge: string
            /// The ID of an existing customer that will be associated with this request. This field may only be updated if there is no existing associated customer with this charge.
            [<Config.Form>]
            Customer: string option
            /// An arbitrary string which you can attach to a charge object. It is displayed when in the web interface alongside the charge. Note that if you use Stripe to send automatic email receipts to your customers, your receipt emails will include the `description` of the charge(s) that they are describing.
            [<Config.Form>]
            Description: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// A set of key-value pairs you can attach to a charge giving information about its riskiness. If you believe a charge is fraudulent, include a `user_report` key with a value of `fraudulent`. If you believe a charge is safe, include a `user_report` key with a value of `safe`. Stripe will use the information you send to improve our fraud detection algorithms.
            [<Config.Form>]
            FraudDetails: Update'FraudDetails option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// This is the email address that the receipt for this charge will be sent to. If this field is updated, then a new email receipt will be sent to the updated address.
            [<Config.Form>]
            ReceiptEmail: string option
            /// Shipping information for the charge. Helps prevent fraud on charges for physical goods.
            [<Config.Form>]
            Shipping: Update'Shipping option
            /// A string that identifies this transaction as part of a group. `transfer_group` may only be provided if it has not been set. See the [Connect documentation](https://docs.stripe.com/connect/separate-charges-and-transfers#transfer-options) for details.
            [<Config.Form>]
            TransferGroup: string option
        }

    type UpdateOptions with
        static member New(charge: string, ?customer: string, ?description: string, ?expand: string list, ?fraudDetails: Update'FraudDetails, ?metadata: Map<string, string>, ?receiptEmail: string, ?shipping: Update'Shipping, ?transferGroup: string) =
            {
                Charge = charge
                Customer = customer
                Description = description
                Expand = expand
                FraudDetails = fraudDetails
                Metadata = metadata
                ReceiptEmail = receiptEmail
                Shipping = shipping
                TransferGroup = transferGroup
            }

    ///<p>Returns a list of charges you’ve previously created. The charges are returned in sorted order, with the most recent charges appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("starting_after", options.StartingAfter |> box); ("transfer_group", options.TransferGroup |> box)] |> Map.ofList
        $"/v1/charges"
        |> RestApi.getAsync<StripeList<Charge>> settings qs

    ///<p>This method is no longer recommended—use the <a href="/docs/api/payment_intents">Payment Intents API</a>
    ///to initiate a new payment instead. Confirmation of the PaymentIntent creates the <code>Charge</code>
    ///object used to request payment.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/charges"
        |> RestApi.postAsync<_, Charge> settings (Map.empty) options

    ///<p>Retrieves the details of a charge that has previously been created. Supply the unique charge ID that was returned from your previous request, and Stripe will return the corresponding charge information. The same information is returned when creating or refunding the charge.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/charges/{options.Charge}"
        |> RestApi.getAsync<Charge> settings qs

    ///<p>Updates the specified charge by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/charges/{options.Charge}"
        |> RestApi.postAsync<_, Charge> settings (Map.empty) options

module ChargesSearch =

    type SearchOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
            [<Config.Query>]
            Limit: int option
            /// A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.
            [<Config.Query>]
            Page: string option
            /// The search query string. See [search query language](https://docs.stripe.com/search#search-query-language) and the list of supported [query fields for charges](https://docs.stripe.com/search#query-fields-for-charges).
            [<Config.Query>]
            Query: string
        }

    type SearchOptions with
        static member New(query: string, ?expand: string list, ?limit: int, ?page: string) =
            {
                Query = query
                Expand = expand
                Limit = limit
                Page = page
            }

    ///<p>Search for charges you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/charges/search"
        |> RestApi.getAsync<StripeList<Charge>> settings qs

module ChargesCapture =

    type Capture'TransferData =
        {
            /// The amount transferred to the destination account, if specified. By default, the entire charge amount is transferred to the destination account.
            [<Config.Form>]
            Amount: int option
        }

    type Capture'TransferData with
        static member New(?amount: int) =
            {
                Amount = amount
            }

    type CaptureOptions =
        {
            [<Config.Path>]
            Charge: string
            /// The amount to capture, which must be less than or equal to the original amount.
            [<Config.Form>]
            Amount: int option
            /// An application fee to add on to this charge.
            [<Config.Form>]
            ApplicationFee: int option
            /// An application fee amount to add on to this charge, which must be less than or equal to the original amount.
            [<Config.Form>]
            ApplicationFeeAmount: int option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The email address to send this charge's receipt to. This will override the previously-specified email address for this charge, if one was set. Receipts will not be sent in test mode.
            [<Config.Form>]
            ReceiptEmail: string option
            /// For a non-card charge, text that appears on the customer's statement as the statement descriptor. This value overrides the account's default statement descriptor. For information about requirements, including the 22-character limit, see [the Statement Descriptor docs](https://docs.stripe.com/get-started/account/statement-descriptors).
            /// For a card charge, this value is ignored unless you don't specify a `statement_descriptor_suffix`, in which case this value is used as the suffix.
            [<Config.Form>]
            StatementDescriptor: string option
            /// Provides information about a card charge. Concatenated to the account's [statement descriptor prefix](https://docs.stripe.com/get-started/account/statement-descriptors#static) to form the complete statement descriptor that appears on the customer's statement. If the account has no prefix value, the suffix is concatenated to the account's statement descriptor.
            [<Config.Form>]
            StatementDescriptorSuffix: string option
            /// An optional dictionary including the account to automatically transfer to as part of a destination charge. [See the Connect documentation](https://docs.stripe.com/connect/destination-charges) for details.
            [<Config.Form>]
            TransferData: Capture'TransferData option
            /// A string that identifies this transaction as part of a group. `transfer_group` may only be provided if it has not been set. See the [Connect documentation](https://docs.stripe.com/connect/separate-charges-and-transfers#transfer-options) for details.
            [<Config.Form>]
            TransferGroup: string option
        }

    type CaptureOptions with
        static member New(charge: string, ?amount: int, ?applicationFee: int, ?applicationFeeAmount: int, ?expand: string list, ?receiptEmail: string, ?statementDescriptor: string, ?statementDescriptorSuffix: string, ?transferData: Capture'TransferData, ?transferGroup: string) =
            {
                Charge = charge
                Amount = amount
                ApplicationFee = applicationFee
                ApplicationFeeAmount = applicationFeeAmount
                Expand = expand
                ReceiptEmail = receiptEmail
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferData = transferData
                TransferGroup = transferGroup
            }

    ///<p>Capture the payment of an existing, uncaptured charge that was created with the <code>capture</code> option set to false.</p>
    ///<p>Uncaptured payments expire a set number of days after they are created (<a href="/docs/charges/placing-a-hold">7 by default</a>), after which they are marked as refunded and capture attempts will fail.</p>
    ///<p>Don’t use this method to capture a PaymentIntent-initiated charge. Use <a href="/docs/api/payment_intents/capture">Capture a PaymentIntent</a>.</p>
    let Capture settings (options: CaptureOptions) =
        $"/v1/charges/{options.Charge}/capture"
        |> RestApi.postAsync<_, Charge> settings (Map.empty) options

module ChargesRefunds =

    type ListOptions =
        {
            [<Config.Path>]
            Charge: string
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
        }

    type ListOptions with
        static member New(charge: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Charge = charge
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Charge: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Refund: string
        }

    type RetrieveOptions with
        static member New(charge: string, refund: string, ?expand: string list) =
            {
                Charge = charge
                Refund = refund
                Expand = expand
            }

    ///<p>You can see a list of the refunds belonging to a specific charge. Note that the 10 most recent refunds are always available by default on the charge object. If you need more than those 10, you can use this API method and the <code>limit</code> and <code>starting_after</code> parameters to page through additional refunds.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/charges/{options.Charge}/refunds"
        |> RestApi.getAsync<StripeList<Refund>> settings qs

    ///<p>Retrieves the details of an existing refund.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/charges/{options.Charge}/refunds/{options.Refund}"
        |> RestApi.getAsync<Refund> settings qs

