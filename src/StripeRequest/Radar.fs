namespace StripeRequest.Radar

open FunStripe
open System.Text.Json.Serialization
open Stripe.Radar
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
module RadarEarlyFraudWarnings =

    type ListOptions =
        {
            /// Only return early fraud warnings for the charge specified by this charge ID.
            [<Config.Query>]
            Charge: string option
            /// Only return early fraud warnings that were created during the given date interval.
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
            /// Only return early fraud warnings for charges that were created by the PaymentIntent specified by this PaymentIntent ID.
            [<Config.Query>]
            PaymentIntent: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListOptions with
        static member New(?charge: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string) =
            {
                Charge = charge
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                PaymentIntent = paymentIntent
                StartingAfter = startingAfter
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            EarlyFraudWarning: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    type RetrieveOptions with
        static member New(earlyFraudWarning: string, ?expand: string list) =
            {
                EarlyFraudWarning = earlyFraudWarning
                Expand = expand
            }

    ///<p>Returns a list of early fraud warnings.</p>
    let List settings (options: ListOptions) =
        let qs = [("charge", options.Charge |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/radar/early_fraud_warnings"
        |> RestApi.getAsync<StripeList<RadarEarlyFraudWarning>> settings qs

    ///<p>Retrieves the details of an early fraud warning that has previously been created. </p>
    ///<p>Please refer to the <a href="#early_fraud_warning_object">early fraud warning</a> object reference for more details.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/radar/early_fraud_warnings/{options.EarlyFraudWarning}"
        |> RestApi.getAsync<RadarEarlyFraudWarning> settings qs

module RadarPaymentEvaluations =

    type Create'ClientDeviceMetadataDetails =
        {
            /// ID for the Radar Session to associate with the payment evaluation. A [Radar Session](https://docs.stripe.com/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
            [<Config.Form>]
            RadarSession: string option
        }

    type Create'ClientDeviceMetadataDetails with
        static member New(?radarSession: string) =
            {
                RadarSession = radarSession
            }

    type Create'CustomerDetails =
        {
            /// The ID of the customer associated with the payment evaluation.
            [<Config.Form>]
            Customer: string option
            /// The ID of the Account representing the customer associated with the payment evaluation.
            [<Config.Form>]
            CustomerAccount: string option
            /// The customer's email address.
            [<Config.Form>]
            Email: string option
            /// The customer's full name or business name.
            [<Config.Form>]
            Name: string option
            /// The customer's phone number.
            [<Config.Form>]
            Phone: string option
        }

    type Create'CustomerDetails with
        static member New(?customer: string, ?customerAccount: string, ?email: string, ?name: string, ?phone: string) =
            {
                Customer = customer
                CustomerAccount = customerAccount
                Email = email
                Name = name
                Phone = phone
            }

    type Create'PaymentDetailsMoneyMovementDetailsCardCustomerPresence =
        | OffSession
        | OnSession

    type Create'PaymentDetailsMoneyMovementDetailsCardPaymentType =
        | OneOff
        | Recurring
        | SetupOneOff
        | SetupRecurring

    type Create'PaymentDetailsMoneyMovementDetailsCard =
        {
            /// Describes the presence of the customer during the payment.
            [<Config.Form>]
            CustomerPresence: Create'PaymentDetailsMoneyMovementDetailsCardCustomerPresence option
            /// Describes the type of payment.
            [<Config.Form>]
            PaymentType: Create'PaymentDetailsMoneyMovementDetailsCardPaymentType option
        }

    type Create'PaymentDetailsMoneyMovementDetailsCard with
        static member New(?customerPresence: Create'PaymentDetailsMoneyMovementDetailsCardCustomerPresence, ?paymentType: Create'PaymentDetailsMoneyMovementDetailsCardPaymentType) =
            {
                CustomerPresence = customerPresence
                PaymentType = paymentType
            }

    type Create'PaymentDetailsMoneyMovementDetailsMoneyMovementType = | Card

    type Create'PaymentDetailsMoneyMovementDetails =
        {
            /// Describes card money movement details for the payment evaluation.
            [<Config.Form>]
            Card: Create'PaymentDetailsMoneyMovementDetailsCard option
            /// Describes the type of money movement. Currently only `card` is supported.
            [<Config.Form>]
            MoneyMovementType: Create'PaymentDetailsMoneyMovementDetailsMoneyMovementType option
        }

    type Create'PaymentDetailsMoneyMovementDetails with
        static member New(?card: Create'PaymentDetailsMoneyMovementDetailsCard, ?moneyMovementType: Create'PaymentDetailsMoneyMovementDetailsMoneyMovementType) =
            {
                Card = card
                MoneyMovementType = moneyMovementType
            }

    type Create'PaymentDetailsPaymentMethodDetailsBillingDetailsAddress =
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

    type Create'PaymentDetailsPaymentMethodDetailsBillingDetailsAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PaymentDetailsPaymentMethodDetailsBillingDetails =
        {
            /// Billing address.
            [<Config.Form>]
            Address: Create'PaymentDetailsPaymentMethodDetailsBillingDetailsAddress option
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

    type Create'PaymentDetailsPaymentMethodDetailsBillingDetails with
        static member New(?address: Create'PaymentDetailsPaymentMethodDetailsBillingDetailsAddress, ?email: string, ?name: string, ?phone: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Create'PaymentDetailsPaymentMethodDetails =
        {
            /// Billing information associated with the payment evaluation.
            [<Config.Form>]
            BillingDetails: Create'PaymentDetailsPaymentMethodDetailsBillingDetails option
            /// ID of the payment method used in this payment evaluation.
            [<Config.Form>]
            PaymentMethod: string option
        }

    type Create'PaymentDetailsPaymentMethodDetails with
        static member New(?billingDetails: Create'PaymentDetailsPaymentMethodDetailsBillingDetails, ?paymentMethod: string) =
            {
                BillingDetails = billingDetails
                PaymentMethod = paymentMethod
            }

    type Create'PaymentDetailsShippingDetailsAddress =
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

    type Create'PaymentDetailsShippingDetailsAddress with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PaymentDetailsShippingDetails =
        {
            /// Shipping address.
            [<Config.Form>]
            Address: Create'PaymentDetailsShippingDetailsAddress option
            /// Shipping name.
            [<Config.Form>]
            Name: string option
            /// Shipping phone number.
            [<Config.Form>]
            Phone: string option
        }

    type Create'PaymentDetailsShippingDetails with
        static member New(?address: Create'PaymentDetailsShippingDetailsAddress, ?name: string, ?phone: string) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Create'PaymentDetails =
        {
            /// The intended amount to collect with this payment. A positive integer representing how much to charge in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal) (for example, 100 cents to charge 1.00 USD or 100 to charge 100 Yen, a zero-decimal currency).
            [<Config.Form>]
            Amount: int option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// An arbitrary string attached to the object. Often useful for displaying to users.
            [<Config.Form>]
            Description: string option
            /// Details about the payment's customer presence and type.
            [<Config.Form>]
            MoneyMovementDetails: Create'PaymentDetailsMoneyMovementDetails option
            /// Details about the payment method to use for the payment.
            [<Config.Form>]
            PaymentMethodDetails: Create'PaymentDetailsPaymentMethodDetails option
            /// Shipping details for the payment evaluation.
            [<Config.Form>]
            ShippingDetails: Create'PaymentDetailsShippingDetails option
            /// Payment statement descriptor.
            [<Config.Form>]
            StatementDescriptor: string option
        }

    type Create'PaymentDetails with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode, ?description: string, ?moneyMovementDetails: Create'PaymentDetailsMoneyMovementDetails, ?paymentMethodDetails: Create'PaymentDetailsPaymentMethodDetails, ?shippingDetails: Create'PaymentDetailsShippingDetails, ?statementDescriptor: string) =
            {
                Amount = amount
                Currency = currency
                Description = description
                MoneyMovementDetails = moneyMovementDetails
                PaymentMethodDetails = paymentMethodDetails
                ShippingDetails = shippingDetails
                StatementDescriptor = statementDescriptor
            }

    type CreateOptions =
        {
            /// Details about the Client Device Metadata to associate with the payment evaluation.
            [<Config.Form>]
            ClientDeviceMetadataDetails: Create'ClientDeviceMetadataDetails option
            /// Details about the customer associated with the payment evaluation.
            [<Config.Form>]
            CustomerDetails: Create'CustomerDetails
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Details about the payment.
            [<Config.Form>]
            PaymentDetails: Create'PaymentDetails
        }

    type CreateOptions with
        static member New(customerDetails: Create'CustomerDetails, paymentDetails: Create'PaymentDetails, ?clientDeviceMetadataDetails: Create'ClientDeviceMetadataDetails, ?expand: string list, ?metadata: Map<string, string>) =
            {
                CustomerDetails = customerDetails
                PaymentDetails = paymentDetails
                ClientDeviceMetadataDetails = clientDeviceMetadataDetails
                Expand = expand
                Metadata = metadata
            }

    ///<p>Request a Radar API fraud risk score from Stripe for a payment before sending it for external processor authorization.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/radar/payment_evaluations"
        |> RestApi.postAsync<_, RadarPaymentEvaluation> settings (Map.empty) options

module RadarValueListItems =

    type ListOptions =
        {
            /// Only return items that were created during the given date interval.
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
            /// Return items belonging to the parent list whose value matches the specified value (using an "is like" match).
            [<Config.Query>]
            Value: string option
            /// Identifier for the parent value list this item belongs to.
            [<Config.Query>]
            ValueList: string
        }

    type ListOptions with
        static member New(valueList: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?value: string) =
            {
                ValueList = valueList
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Value = value
            }

    type CreateOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The value of the item (whose type must match the type of the parent value list).
            [<Config.Form>]
            Value: string
            /// The identifier of the value list which the created item will be added to.
            [<Config.Form>]
            ValueList: string
        }

    type CreateOptions with
        static member New(value: string, valueList: string, ?expand: string list) =
            {
                Value = value
                ValueList = valueList
                Expand = expand
            }

    type DeleteOptions =
        { [<Config.Path>]
          Item: string }

    type DeleteOptions with
        static member New(item: string) =
            {
                Item = item
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Item: string
        }

    type RetrieveOptions with
        static member New(item: string, ?expand: string list) =
            {
                Item = item
                Expand = expand
            }

    ///<p>Returns a list of <code>ValueListItem</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("value", options.Value |> box); ("value_list", options.ValueList |> box)] |> Map.ofList
        $"/v1/radar/value_list_items"
        |> RestApi.getAsync<StripeList<RadarValueListItem>> settings qs

    ///<p>Creates a new <code>ValueListItem</code> object, which is added to the specified parent value list.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/radar/value_list_items"
        |> RestApi.postAsync<_, RadarValueListItem> settings (Map.empty) options

    ///<p>Deletes a <code>ValueListItem</code> object, removing it from its parent value list.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/radar/value_list_items/{options.Item}"
        |> RestApi.deleteAsync<DeletedRadarValueListItem> settings (Map.empty)

    ///<p>Retrieves a <code>ValueListItem</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/radar/value_list_items/{options.Item}"
        |> RestApi.getAsync<RadarValueListItem> settings qs

module RadarValueLists =

    type ListOptions =
        {
            /// The alias used to reference the value list when writing rules.
            [<Config.Query>]
            Alias: string option
            /// A value contained within a value list - returns all value lists containing this value.
            [<Config.Query>]
            Contains: string option
            /// Only return value lists that were created during the given date interval.
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
        }

    type ListOptions with
        static member New(?alias: string, ?contains: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Alias = alias
                Contains = contains
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    type Create'ItemType =
        | Account
        | CardBin
        | CardFingerprint
        | CaseSensitiveString
        | Country
        | CryptoFingerprint
        | CustomerId
        | Email
        | IpAddress
        | SepaDebitFingerprint
        | String
        | UsBankAccountFingerprint

    type CreateOptions =
        {
            /// The name of the value list for use in rules.
            [<Config.Form>]
            Alias: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Type of the items in the value list. One of `card_fingerprint`, `card_bin`, `crypto_fingerprint`, `email`, `ip_address`, `country`, `string`, `case_sensitive_string`, `customer_id`, `account`, `sepa_debit_fingerprint`, or `us_bank_account_fingerprint`. Use `string` if the item type is unknown or mixed.
            [<Config.Form>]
            ItemType: Create'ItemType option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The human-readable name of the value list.
            [<Config.Form>]
            Name: string
        }

    type CreateOptions with
        static member New(alias: string, name: string, ?expand: string list, ?itemType: Create'ItemType, ?metadata: Map<string, string>) =
            {
                Alias = alias
                Name = name
                Expand = expand
                ItemType = itemType
                Metadata = metadata
            }

    type DeleteOptions =
        { [<Config.Path>]
          ValueList: string }

    type DeleteOptions with
        static member New(valueList: string) =
            {
                ValueList = valueList
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            ValueList: string
        }

    type RetrieveOptions with
        static member New(valueList: string, ?expand: string list) =
            {
                ValueList = valueList
                Expand = expand
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            ValueList: string
            /// The name of the value list for use in rules.
            [<Config.Form>]
            Alias: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The human-readable name of the value list.
            [<Config.Form>]
            Name: string option
        }

    type UpdateOptions with
        static member New(valueList: string, ?alias: string, ?expand: string list, ?metadata: Map<string, string>, ?name: string) =
            {
                ValueList = valueList
                Alias = alias
                Expand = expand
                Metadata = metadata
                Name = name
            }

    ///<p>Returns a list of <code>ValueList</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("alias", options.Alias |> box); ("contains", options.Contains |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/radar/value_lists"
        |> RestApi.getAsync<StripeList<RadarValueList>> settings qs

    ///<p>Creates a new <code>ValueList</code> object, which can then be referenced in rules.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/radar/value_lists"
        |> RestApi.postAsync<_, RadarValueList> settings (Map.empty) options

    ///<p>Deletes a <code>ValueList</code> object, also deleting any items contained within the value list. To be deleted, a value list must not be referenced in any rules.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/radar/value_lists/{options.ValueList}"
        |> RestApi.deleteAsync<DeletedRadarValueList> settings (Map.empty)

    ///<p>Retrieves a <code>ValueList</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/radar/value_lists/{options.ValueList}"
        |> RestApi.getAsync<RadarValueList> settings qs

    ///<p>Updates a <code>ValueList</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Note that <code>item_type</code> is immutable.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/radar/value_lists/{options.ValueList}"
        |> RestApi.postAsync<_, RadarValueList> settings (Map.empty) options

