namespace FunStripe.StripeRequest

open FunStripe
open System.Text.Json.Serialization
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module RadarEarlyFraudWarnings =

    type ListOptions = {
        ///<summary>Only return early fraud warnings for the charge specified by this charge ID.</summary>
        [<Config.Query>]Charge: string option
        ///<summary>Only return early fraud warnings that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Only return early fraud warnings for charges that were created by the PaymentIntent specified by this PaymentIntent ID.</summary>
        [<Config.Query>]PaymentIntent: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
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

    ///<summary><p>Returns a list of early fraud warnings.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("charge", options.Charge |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/radar/early_fraud_warnings"
        |> RestApi.getAsync<StripeList<RadarEarlyFraudWarning>> settings qs

    type RetrieveOptions = {
        [<Config.Path>]EarlyFraudWarning: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(earlyFraudWarning: string, ?expand: string list) =
            {
                EarlyFraudWarning = earlyFraudWarning
                Expand = expand
            }

    ///<summary><p>Retrieves the details of an early fraud warning that has previously been created. </p>
    ///<p>Please refer to the <a href="#early_fraud_warning_object">early fraud warning</a> object reference for more details.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/radar/early_fraud_warnings/{options.EarlyFraudWarning}"
        |> RestApi.getAsync<RadarEarlyFraudWarning> settings qs

module RadarPaymentEvaluations =

    type Create'ClientDeviceMetadataDetails = {
        ///<summary>ID for the Radar Session to associate with the payment evaluation. A [Radar Session](https://docs.stripe.com/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.</summary>
        [<Config.Form>]RadarSession: string option
    }
    with
        static member New(?radarSession: string) =
            {
                RadarSession = radarSession
            }

    type Create'CustomerDetails = {
        ///<summary>The ID of the customer associated with the payment evaluation.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>The ID of the Account representing the customer associated with the payment evaluation.</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>The customer's email address.</summary>
        [<Config.Form>]Email: string option
        ///<summary>The customer's full name or business name.</summary>
        [<Config.Form>]Name: string option
        ///<summary>The customer's phone number.</summary>
        [<Config.Form>]Phone: string option
    }
    with
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

    type Create'PaymentDetailsMoneyMovementDetailsCard = {
        ///<summary>Describes the presence of the customer during the payment.</summary>
        [<Config.Form>]CustomerPresence: Create'PaymentDetailsMoneyMovementDetailsCardCustomerPresence option
        ///<summary>Describes the type of payment.</summary>
        [<Config.Form>]PaymentType: Create'PaymentDetailsMoneyMovementDetailsCardPaymentType option
    }
    with
        static member New(?customerPresence: Create'PaymentDetailsMoneyMovementDetailsCardCustomerPresence, ?paymentType: Create'PaymentDetailsMoneyMovementDetailsCardPaymentType) =
            {
                CustomerPresence = customerPresence
                PaymentType = paymentType
            }

    type Create'PaymentDetailsMoneyMovementDetailsMoneyMovementType =
    | Card

    type Create'PaymentDetailsMoneyMovementDetails = {
        ///<summary>Describes card money movement details for the payment evaluation.</summary>
        [<Config.Form>]Card: Create'PaymentDetailsMoneyMovementDetailsCard option
        ///<summary>Describes the type of money movement. Currently only `card` is supported.</summary>
        [<Config.Form>]MoneyMovementType: Create'PaymentDetailsMoneyMovementDetailsMoneyMovementType option
    }
    with
        static member New(?card: Create'PaymentDetailsMoneyMovementDetailsCard, ?moneyMovementType: Create'PaymentDetailsMoneyMovementDetailsMoneyMovementType) =
            {
                Card = card
                MoneyMovementType = moneyMovementType
            }

    type Create'PaymentDetailsPaymentMethodDetailsBillingDetailsAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PaymentDetailsPaymentMethodDetailsBillingDetails = {
        ///<summary>Billing address.</summary>
        [<Config.Form>]Address: Create'PaymentDetailsPaymentMethodDetailsBillingDetailsAddress option
        ///<summary>Email address.</summary>
        [<Config.Form>]Email: string option
        ///<summary>Full name.</summary>
        [<Config.Form>]Name: string option
        ///<summary>Billing phone number (including extension).</summary>
        [<Config.Form>]Phone: string option
    }
    with
        static member New(?address: Create'PaymentDetailsPaymentMethodDetailsBillingDetailsAddress, ?email: string, ?name: string, ?phone: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Create'PaymentDetailsPaymentMethodDetails = {
        ///<summary>Billing information associated with the payment evaluation.</summary>
        [<Config.Form>]BillingDetails: Create'PaymentDetailsPaymentMethodDetailsBillingDetails option
        ///<summary>ID of the payment method used in this payment evaluation.</summary>
        [<Config.Form>]PaymentMethod: string option
    }
    with
        static member New(?billingDetails: Create'PaymentDetailsPaymentMethodDetailsBillingDetails, ?paymentMethod: string) =
            {
                BillingDetails = billingDetails
                PaymentMethod = paymentMethod
            }

    type Create'PaymentDetailsShippingDetailsAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: string option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: string option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: string option
        ///<summary>State, county, province, or region ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: IsoTypes.IsoCountryCode, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PaymentDetailsShippingDetails = {
        ///<summary>Shipping address.</summary>
        [<Config.Form>]Address: Create'PaymentDetailsShippingDetailsAddress option
        ///<summary>Shipping name.</summary>
        [<Config.Form>]Name: string option
        ///<summary>Shipping phone number.</summary>
        [<Config.Form>]Phone: string option
    }
    with
        static member New(?address: Create'PaymentDetailsShippingDetailsAddress, ?name: string, ?phone: string) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Create'PaymentDetails = {
        ///<summary>The intended amount to collect with this payment. A positive integer representing how much to charge in the [smallest currency unit](https://docs.stripe.com/currencies#zero-decimal) (for example, 100 cents to charge 1.00 USD or 100 to charge 100 Yen, a zero-decimal currency).</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>An arbitrary string attached to the object. Often useful for displaying to users.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Details about the payment's customer presence and type.</summary>
        [<Config.Form>]MoneyMovementDetails: Create'PaymentDetailsMoneyMovementDetails option
        ///<summary>Details about the payment method to use for the payment.</summary>
        [<Config.Form>]PaymentMethodDetails: Create'PaymentDetailsPaymentMethodDetails option
        ///<summary>Shipping details for the payment evaluation.</summary>
        [<Config.Form>]ShippingDetails: Create'PaymentDetailsShippingDetails option
        ///<summary>Payment statement descriptor.</summary>
        [<Config.Form>]StatementDescriptor: string option
    }
    with
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

    type CreateOptions = {
        ///<summary>Details about the Client Device Metadata to associate with the payment evaluation.</summary>
        [<Config.Form>]ClientDeviceMetadataDetails: Create'ClientDeviceMetadataDetails option
        ///<summary>Details about the customer associated with the payment evaluation.</summary>
        [<Config.Form>]CustomerDetails: Create'CustomerDetails
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Details about the payment.</summary>
        [<Config.Form>]PaymentDetails: Create'PaymentDetails
    }
    with
        static member New(customerDetails: Create'CustomerDetails, paymentDetails: Create'PaymentDetails, ?clientDeviceMetadataDetails: Create'ClientDeviceMetadataDetails, ?expand: string list, ?metadata: Map<string, string>) =
            {
                ClientDeviceMetadataDetails = clientDeviceMetadataDetails
                CustomerDetails = customerDetails
                Expand = expand
                Metadata = metadata
                PaymentDetails = paymentDetails
            }

    ///<summary><p>Request a Radar API fraud risk score from Stripe for a payment before sending it for external processor authorization.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/radar/payment_evaluations"
        |> RestApi.postAsync<_, RadarPaymentEvaluation> settings (Map.empty) options

module RadarValueListItems =

    type ListOptions = {
        ///<summary>Only return items that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Return items belonging to the parent list whose value matches the specified value (using an "is like" match).</summary>
        [<Config.Query>]Value: string option
        ///<summary>Identifier for the parent value list this item belongs to.</summary>
        [<Config.Query>]ValueList: string
    }
    with
        static member New(valueList: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?value: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Value = value
                ValueList = valueList
            }

    ///<summary><p>Returns a list of <code>ValueListItem</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("value", options.Value |> box); ("value_list", options.ValueList |> box)] |> Map.ofList
        $"/v1/radar/value_list_items"
        |> RestApi.getAsync<StripeList<RadarValueListItem>> settings qs

    type CreateOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The value of the item (whose type must match the type of the parent value list).</summary>
        [<Config.Form>]Value: string
        ///<summary>The identifier of the value list which the created item will be added to.</summary>
        [<Config.Form>]ValueList: string
    }
    with
        static member New(value: string, valueList: string, ?expand: string list) =
            {
                Expand = expand
                Value = value
                ValueList = valueList
            }

    ///<summary><p>Creates a new <code>ValueListItem</code> object, which is added to the specified parent value list.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/radar/value_list_items"
        |> RestApi.postAsync<_, RadarValueListItem> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Item: string
    }
    with
        static member New(item: string) =
            {
                Item = item
            }

    ///<summary><p>Deletes a <code>ValueListItem</code> object, removing it from its parent value list.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/radar/value_list_items/{options.Item}"
        |> RestApi.deleteAsync<DeletedRadarValueListItem> settings (Map.empty)

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Item: string
    }
    with
        static member New(item: string, ?expand: string list) =
            {
                Expand = expand
                Item = item
            }

    ///<summary><p>Retrieves a <code>ValueListItem</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/radar/value_list_items/{options.Item}"
        |> RestApi.getAsync<RadarValueListItem> settings qs

module RadarValueLists =

    type ListOptions = {
        ///<summary>The alias used to reference the value list when writing rules.</summary>
        [<Config.Query>]Alias: string option
        ///<summary>A value contained within a value list - returns all value lists containing this value.</summary>
        [<Config.Query>]Contains: string option
        ///<summary>Only return value lists that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
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

    ///<summary><p>Returns a list of <code>ValueList</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("alias", options.Alias |> box); ("contains", options.Contains |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/radar/value_lists"
        |> RestApi.getAsync<StripeList<RadarValueList>> settings qs

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

    type CreateOptions = {
        ///<summary>The name of the value list for use in rules.</summary>
        [<Config.Form>]Alias: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Type of the items in the value list. One of `card_fingerprint`, `card_bin`, `crypto_fingerprint`, `email`, `ip_address`, `country`, `string`, `case_sensitive_string`, `customer_id`, `account`, `sepa_debit_fingerprint`, or `us_bank_account_fingerprint`. Use `string` if the item type is unknown or mixed.</summary>
        [<Config.Form>]ItemType: Create'ItemType option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The human-readable name of the value list.</summary>
        [<Config.Form>]Name: string
    }
    with
        static member New(alias: string, name: string, ?expand: string list, ?itemType: Create'ItemType, ?metadata: Map<string, string>) =
            {
                Alias = alias
                Expand = expand
                ItemType = itemType
                Metadata = metadata
                Name = name
            }

    ///<summary><p>Creates a new <code>ValueList</code> object, which can then be referenced in rules.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/radar/value_lists"
        |> RestApi.postAsync<_, RadarValueList> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]ValueList: string
    }
    with
        static member New(valueList: string) =
            {
                ValueList = valueList
            }

    ///<summary><p>Deletes a <code>ValueList</code> object, also deleting any items contained within the value list. To be deleted, a value list must not be referenced in any rules.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/radar/value_lists/{options.ValueList}"
        |> RestApi.deleteAsync<DeletedRadarValueList> settings (Map.empty)

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]ValueList: string
    }
    with
        static member New(valueList: string, ?expand: string list) =
            {
                Expand = expand
                ValueList = valueList
            }

    ///<summary><p>Retrieves a <code>ValueList</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/radar/value_lists/{options.ValueList}"
        |> RestApi.getAsync<RadarValueList> settings qs

    type UpdateOptions = {
        [<Config.Path>]ValueList: string
        ///<summary>The name of the value list for use in rules.</summary>
        [<Config.Form>]Alias: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The human-readable name of the value list.</summary>
        [<Config.Form>]Name: string option
    }
    with
        static member New(valueList: string, ?alias: string, ?expand: string list, ?metadata: Map<string, string>, ?name: string) =
            {
                ValueList = valueList
                Alias = alias
                Expand = expand
                Metadata = metadata
                Name = name
            }

    ///<summary><p>Updates a <code>ValueList</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Note that <code>item_type</code> is immutable.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/radar/value_lists/{options.ValueList}"
        |> RestApi.postAsync<_, RadarValueList> settings (Map.empty) options
