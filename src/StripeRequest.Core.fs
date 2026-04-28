namespace FunStripe.StripeRequest

open FunStripe
open FunStripe.Json
open FunStripe.StripeModel
open System

module Account =

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(?expand: string list) =
            {
                Expand = expand
            }

    ///<p>Retrieves the details of an account.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/account"
        |> RestApi.getAsync<Account> settings qs

module Balance =

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(?expand: string list) =
            {
                Expand = expand
            }

    ///<p>Retrieves the current account balance, based on the authentication that was used to make the request.
    /// For a sample request, see <a href="/docs/connect/account-balances#accounting-for-negative-balances">Accounting for negative balances</a>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/balance"
        |> RestApi.getAsync<Balance> settings qs

module BalanceTransactions =

    type ListOptions = {
        [<Config.Query>]Created: int option
        ///Only return transactions in a certain currency. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Query>]Currency: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///For automatic Stripe payouts only, only returns transactions that were paid out on the specified payout ID.
        [<Config.Query>]Payout: string option
        ///Only returns the original transaction.
        [<Config.Query>]Source: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only returns transactions of the given type. One of: `adjustment`, `advance`, `advance_funding`, `anticipation_repayment`, `application_fee`, `application_fee_refund`, `charge`, `connect_collection_transfer`, `contribution`, `issuing_authorization_hold`, `issuing_authorization_release`, `issuing_dispute`, `issuing_transaction`, `payment`, `payment_failure_refund`, `payment_refund`, `payment_reversal`, `payout`, `payout_cancel`, `payout_failure`, `refund`, `refund_failure`, `reserve_transaction`, `reserved_funds`, `stripe_fee`, `stripe_fx_fee`, `tax_fee`, `topup`, `topup_reversal`, `transfer`, `transfer_cancel`, `transfer_failure`, or `transfer_refund`.
        [<Config.Query>]Type: string option
    }
    with
        static member New(?created: int, ?currency: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?payout: string, ?source: string, ?startingAfter: string, ?type': string) =
            {
                Created = created
                Currency = currency
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Payout = payout
                Source = source
                StartingAfter = startingAfter
                Type = type'
            }

    ///<p>Returns a list of transactions that have contributed to the Stripe account balance (e.g., charges, transfers, and so forth). The transactions are returned in sorted order, with the most recent transactions appearing first.
    ///Note that this endpoint was previously called “Balance history” and used the path <code>/v1/balance/history</code>.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("currency", options.Currency |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payout", options.Payout |> box); ("source", options.Source |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/balance_transactions"
        |> RestApi.getAsync<BalanceTransaction list> settings qs

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<p>Retrieves the balance transaction with the given ID.
    ///Note that this endpoint previously used the path <code>/v1/balance/history/:id</code>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/balance_transactions/{options.Id}"
        |> RestApi.getAsync<BalanceTransaction> settings qs

module Charges =

    type ListOptions = {
        [<Config.Query>]Created: int option
        ///Only return charges for the customer specified by this customer ID.
        [<Config.Query>]Customer: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Only return charges that were created by the PaymentIntent specified by this PaymentIntent ID.
        [<Config.Query>]PaymentIntent: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only return charges for this transfer group.
        [<Config.Query>]TransferGroup: string option
    }
    with
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

    ///<p>Returns a list of charges you’ve previously created. The charges are returned in sorted order, with the most recent charges appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("starting_after", options.StartingAfter |> box); ("transfer_group", options.TransferGroup |> box)] |> Map.ofList
        $"/v1/charges"
        |> RestApi.getAsync<Charge list> settings qs

    type Create'Destination = {
        ///ID of an existing, connected Stripe account.
        [<Config.Form>]Account: string option
        ///The amount to transfer to the destination account without creating an `Application Fee` object. Cannot be combined with the `application_fee` parameter. Must be less than or equal to the charge amount.
        [<Config.Form>]Amount: int option
    }
    with
        static member New(?account: string, ?amount: int) =
            {
                Account = account
                Amount = amount
            }

    type Create'RadarOptions = {
        ///A [Radar Session](https://stripe.com/docs/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
        [<Config.Form>]Session: string option
    }
    with
        static member New(?session: string) =
            {
                Session = session
            }

    type Create'ShippingAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'Shipping = {
        ///Shipping address.
        [<Config.Form>]Address: Create'ShippingAddress option
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        [<Config.Form>]Carrier: string option
        ///Recipient name.
        [<Config.Form>]Name: string option
        ///Recipient phone (including extension).
        [<Config.Form>]Phone: string option
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        [<Config.Form>]TrackingNumber: string option
    }
    with
        static member New(?address: Create'ShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type Create'TransferData = {
        ///The amount transferred to the destination account, if specified. By default, the entire charge amount is transferred to the destination account.
        [<Config.Form>]Amount: int option
        ///ID of an existing, connected Stripe account.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type CreateOptions = {
        ///Amount intended to be collected by this payment. A positive integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://stripe.com/docs/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        [<Config.Form>]Amount: int option
        [<Config.Form>]ApplicationFee: int option
        ///A fee in cents (or local equivalent) that will be applied to the charge and transferred to the application owner's Stripe account. The request must be made with an OAuth key or the `Stripe-Account` header in order to take an application fee. For more information, see the application fees [documentation](https://stripe.com/docs/connect/direct-charges#collecting-fees).
        [<Config.Form>]ApplicationFeeAmount: int option
        ///Whether to immediately capture the charge. Defaults to `true`. When `false`, the charge issues an authorization (or pre-authorization), and will need to be [captured](https://stripe.com/docs/api#capture_charge) later. Uncaptured charges expire after a set number of days (7 by default). For more information, see the [authorizing charges and settling later](https://stripe.com/docs/charges/placing-a-hold) documentation.
        [<Config.Form>]Capture: bool option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///The ID of an existing customer that will be charged in this request.
        [<Config.Form>]Customer: string option
        ///An arbitrary string which you can attach to a `Charge` object. It is displayed when in the web interface alongside the charge. Note that if you use Stripe to send automatic email receipts to your customers, your receipt emails will include the `description` of the charge(s) that they are describing.
        [<Config.Form>]Description: string option
        [<Config.Form>]Destination: Create'Destination option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The Stripe account ID for which these funds are intended. Automatically set if you use the `destination` parameter. For details, see [Creating Separate Charges and Transfers](https://stripe.com/docs/connect/separate-charges-and-transfers#on-behalf-of).
        [<Config.Form>]OnBehalfOf: string option
        ///Options to configure Radar. See [Radar Session](https://stripe.com/docs/radar/radar-session) for more information.
        [<Config.Form>]RadarOptions: Create'RadarOptions option
        ///The email address to which this charge's [receipt](https://stripe.com/docs/dashboard/receipts) will be sent. The receipt will not be sent until the charge is paid, and no receipts will be sent for test mode charges. If this charge is for a [Customer](https://stripe.com/docs/api/customers/object), the email address specified here will override the customer's email address. If `receipt_email` is specified for a charge in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).
        [<Config.Form>]ReceiptEmail: string option
        ///Shipping information for the charge. Helps prevent fraud on charges for physical goods.
        [<Config.Form>]Shipping: Create'Shipping option
        ///A payment source to be charged. This can be the ID of a [card](https://stripe.com/docs/api#cards) (i.e., credit or debit card), a [bank account](https://stripe.com/docs/api#bank_accounts), a [source](https://stripe.com/docs/api#sources), a [token](https://stripe.com/docs/api#tokens), or a [connected account](https://stripe.com/docs/connect/account-debits#charging-a-connected-account). For certain sources---namely, [cards](https://stripe.com/docs/api#cards), [bank accounts](https://stripe.com/docs/api#bank_accounts), and attached [sources](https://stripe.com/docs/api#sources)---you must also pass the ID of the associated customer.
        [<Config.Form>]Source: string option
        ///For card charges, use `statement_descriptor_suffix` instead. Otherwise, you can use this value as the complete description of a charge on your customers’ statements. Must contain at least one letter, maximum 22 characters.
        [<Config.Form>]StatementDescriptor: string option
        ///Provides information about the charge that customers see on their statements. Concatenated with the prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters for the concatenated descriptor.
        [<Config.Form>]StatementDescriptorSuffix: string option
        ///An optional dictionary including the account to automatically transfer to as part of a destination charge. [See the Connect documentation](https://stripe.com/docs/connect/destination-charges) for details.
        [<Config.Form>]TransferData: Create'TransferData option
        ///A string that identifies this transaction as part of a group. For details, see [Grouping transactions](https://stripe.com/docs/connect/separate-charges-and-transfers#transfer-options).
        [<Config.Form>]TransferGroup: string option
    }
    with
        static member New(?amount: int, ?statementDescriptorSuffix: string, ?statementDescriptor: string, ?source: string, ?shipping: Create'Shipping, ?receiptEmail: string, ?radarOptions: Create'RadarOptions, ?onBehalfOf: string, ?transferData: Create'TransferData, ?metadata: Map<string, string>, ?destination: Create'Destination, ?description: string, ?customer: string, ?currency: string, ?capture: bool, ?applicationFeeAmount: int, ?applicationFee: int, ?expand: string list, ?transferGroup: string) =
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

    ///<p>Use the <a href="/docs/api/payment_intents">Payment Intents API</a> to initiate a new payment instead
    ///of using this method. Confirmation of the PaymentIntent creates the <code>Charge</code>
    ///object used to request payment, so this method is limited to legacy integrations.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/charges"
        |> RestApi.postAsync<_, Charge> settings (Map.empty) options

    type RetrieveOptions = {
        [<Config.Path>]Charge: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(charge: string, ?expand: string list) =
            {
                Charge = charge
                Expand = expand
            }

    ///<p>Retrieves the details of a charge that has previously been created. Supply the unique charge ID that was returned from your previous request, and Stripe will return the corresponding charge information. The same information is returned when creating or refunding the charge.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/charges/{options.Charge}"
        |> RestApi.getAsync<Charge> settings qs

    type Update'FraudDetailsUserReport =
    | Fraudulent
    | Safe

    type Update'FraudDetails = {
        ///Either `safe` or `fraudulent`.
        [<Config.Form>]UserReport: Update'FraudDetailsUserReport option
    }
    with
        static member New(?userReport: Update'FraudDetailsUserReport) =
            {
                UserReport = userReport
            }

    type Update'ShippingAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'Shipping = {
        ///Shipping address.
        [<Config.Form>]Address: Update'ShippingAddress option
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        [<Config.Form>]Carrier: string option
        ///Recipient name.
        [<Config.Form>]Name: string option
        ///Recipient phone (including extension).
        [<Config.Form>]Phone: string option
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        [<Config.Form>]TrackingNumber: string option
    }
    with
        static member New(?address: Update'ShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type UpdateOptions = {
        [<Config.Path>]Charge: string
        ///The ID of an existing customer that will be associated with this request. This field may only be updated if there is no existing associated customer with this charge.
        [<Config.Form>]Customer: string option
        ///An arbitrary string which you can attach to a charge object. It is displayed when in the web interface alongside the charge. Note that if you use Stripe to send automatic email receipts to your customers, your receipt emails will include the `description` of the charge(s) that they are describing.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A set of key-value pairs you can attach to a charge giving information about its riskiness. If you believe a charge is fraudulent, include a `user_report` key with a value of `fraudulent`. If you believe a charge is safe, include a `user_report` key with a value of `safe`. Stripe will use the information you send to improve our fraud detection algorithms.
        [<Config.Form>]FraudDetails: Update'FraudDetails option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///This is the email address that the receipt for this charge will be sent to. If this field is updated, then a new email receipt will be sent to the updated address.
        [<Config.Form>]ReceiptEmail: string option
        ///Shipping information for the charge. Helps prevent fraud on charges for physical goods.
        [<Config.Form>]Shipping: Update'Shipping option
        ///A string that identifies this transaction as part of a group. `transfer_group` may only be provided if it has not been set. See the [Connect documentation](https://stripe.com/docs/connect/separate-charges-and-transfers#transfer-options) for details.
        [<Config.Form>]TransferGroup: string option
    }
    with
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

    ///<p>Updates the specified charge by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/charges/{options.Charge}"
        |> RestApi.postAsync<_, Charge> settings (Map.empty) options

module ChargesSearch =

    type SearchOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.
        [<Config.Query>]Page: string option
        ///The search query string. See [search query language](https://stripe.com/docs/search#search-query-language) and the list of supported [query fields for charges](https://stripe.com/docs/search#query-fields-for-charges).
        [<Config.Query>]Query: string
    }
    with
        static member New(query: string, ?expand: string list, ?limit: int, ?page: string) =
            {
                Expand = expand
                Limit = limit
                Page = page
                Query = query
            }

    ///<p>Search for charges you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/charges/search"
        |> RestApi.getAsync<Charge list> settings qs

module ChargesCapture =

    type Capture'TransferData = {
        ///The amount transferred to the destination account, if specified. By default, the entire charge amount is transferred to the destination account.
        [<Config.Form>]Amount: int option
    }
    with
        static member New(?amount: int) =
            {
                Amount = amount
            }

    type CaptureOptions = {
        [<Config.Path>]Charge: string
        ///The amount to capture, which must be less than or equal to the original amount. Any additional amount will be automatically refunded.
        [<Config.Form>]Amount: int option
        ///An application fee to add on to this charge.
        [<Config.Form>]ApplicationFee: int option
        ///An application fee amount to add on to this charge, which must be less than or equal to the original amount.
        [<Config.Form>]ApplicationFeeAmount: int option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The email address to send this charge's receipt to. This will override the previously-specified email address for this charge, if one was set. Receipts will not be sent in test mode.
        [<Config.Form>]ReceiptEmail: string option
        ///For card charges, use `statement_descriptor_suffix` instead. Otherwise, you can use this value as the complete description of a charge on your customers’ statements. Must contain at least one letter, maximum 22 characters.
        [<Config.Form>]StatementDescriptor: string option
        ///Provides information about the charge that customers see on their statements. Concatenated with the prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters for the concatenated descriptor.
        [<Config.Form>]StatementDescriptorSuffix: string option
        ///An optional dictionary including the account to automatically transfer to as part of a destination charge. [See the Connect documentation](https://stripe.com/docs/connect/destination-charges) for details.
        [<Config.Form>]TransferData: Capture'TransferData option
        ///A string that identifies this transaction as part of a group. `transfer_group` may only be provided if it has not been set. See the [Connect documentation](https://stripe.com/docs/connect/separate-charges-and-transfers#transfer-options) for details.
        [<Config.Form>]TransferGroup: string option
    }
    with
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

    ///<p>Capture the payment of an existing, uncaptured charge that was created with the <code>capture</code> option set to false.
    ///Uncaptured payments expire a set number of days after they are created (<a href="/docs/charges/placing-a-hold">7 by default</a>), after which they are marked as refunded and capture attempts will fail.
    ///Don’t use this method to capture a PaymentIntent-initiated charge. Use <a href="/docs/api/payment_intents/capture">Capture a PaymentIntent</a>.</p>
    let Capture settings (options: CaptureOptions) =
        $"/v1/charges/{options.Charge}/capture"
        |> RestApi.postAsync<_, Charge> settings (Map.empty) options

module ChargesRefunds =

    type ListOptions = {
        [<Config.Path>]Charge: string
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(charge: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Charge = charge
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>You can see a list of the refunds belonging to a specific charge. Note that the 10 most recent refunds are always available by default on the charge object. If you need more than those 10, you can use this API method and the <code>limit</code> and <code>starting_after</code> parameters to page through additional refunds.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/charges/{options.Charge}/refunds"
        |> RestApi.getAsync<Refund list> settings qs

    type RetrieveOptions = {
        [<Config.Path>]Charge: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Refund: string
    }
    with
        static member New(charge: string, refund: string, ?expand: string list) =
            {
                Charge = charge
                Expand = expand
                Refund = refund
            }

    ///<p>Retrieves the details of an existing refund.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/charges/{options.Charge}/refunds/{options.Refund}"
        |> RestApi.getAsync<Refund> settings qs

module CountrySpecs =

    type ListOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Lists all Country Spec objects available in the API.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/country_specs"
        |> RestApi.getAsync<CountrySpec list> settings qs

    type RetrieveOptions = {
        [<Config.Path>]Country: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(country: string, ?expand: string list) =
            {
                Country = country
                Expand = expand
            }

    ///<p>Returns a Country Spec for a given Country code.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/country_specs/{options.Country}"
        |> RestApi.getAsync<CountrySpec> settings qs

module Customers =

    type ListOptions = {
        [<Config.Query>]Created: int option
        ///A case-sensitive filter on the list based on the customer's `email` field. The value must be a string.
        [<Config.Query>]Email: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Provides a list of customers that are associated with the specified test clock. The response will not include customers with test clocks if this parameter is not set.
        [<Config.Query>]TestClock: string option
    }
    with
        static member New(?created: int, ?email: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?testClock: string) =
            {
                Created = created
                Email = email
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                TestClock = testClock
            }

    ///<p>Returns a list of your customers. The customers are returned sorted by creation date, with the most recent customers appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("email", options.Email |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("test_clock", options.TestClock |> box)] |> Map.ofList
        $"/v1/customers"
        |> RestApi.getAsync<Customer list> settings qs

    type Create'AddressOptionalFieldsAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'CashBalanceSettingsReconciliationMode =
    | Automatic
    | Manual
    | MerchantDefault

    type Create'CashBalanceSettings = {
        ///Controls how funds transferred by the customer are applied to payment intents and invoices. Valid options are `automatic`, `manual`, or `merchant_default`. For more information about these reconciliation modes, see [Reconciliation](https://stripe.com/docs/payments/customer-balance/reconciliation).
        [<Config.Form>]ReconciliationMode: Create'CashBalanceSettingsReconciliationMode option
    }
    with
        static member New(?reconciliationMode: Create'CashBalanceSettingsReconciliationMode) =
            {
                ReconciliationMode = reconciliationMode
            }

    type Create'CashBalance = {
        ///Settings controlling the behavior of the customer's cash balance,
        ///such as reconciliation of funds received.
        [<Config.Form>]Settings: Create'CashBalanceSettings option
    }
    with
        static member New(?settings: Create'CashBalanceSettings) =
            {
                Settings = settings
            }

    type Create'InvoiceSettingsCustomFields = {
        ///The name of the custom field. This may be up to 30 characters.
        [<Config.Form>]Name: string option
        ///The value of the custom field. This may be up to 30 characters.
        [<Config.Form>]Value: string option
    }
    with
        static member New(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Create'InvoiceSettingsRenderingOptionsRenderingOptionsAmountTaxDisplay =
    | ExcludeTax
    | IncludeInclusiveTax

    type Create'InvoiceSettingsRenderingOptionsRenderingOptions = {
        ///How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.
        [<Config.Form>]AmountTaxDisplay: Create'InvoiceSettingsRenderingOptionsRenderingOptionsAmountTaxDisplay option
    }
    with
        static member New(?amountTaxDisplay: Create'InvoiceSettingsRenderingOptionsRenderingOptionsAmountTaxDisplay) =
            {
                AmountTaxDisplay = amountTaxDisplay
            }

    type Create'InvoiceSettings = {
        ///Default custom fields to be displayed on invoices for this customer. When updating, pass an empty string to remove previously-defined fields.
        [<Config.Form>]CustomFields: Choice<Create'InvoiceSettingsCustomFields list,string> option
        ///ID of a payment method that's attached to the customer, to be used as the customer's default payment method for subscriptions and invoices.
        [<Config.Form>]DefaultPaymentMethod: string option
        ///Default footer to be displayed on invoices for this customer.
        [<Config.Form>]Footer: string option
        ///Default options for invoice PDF rendering for this customer.
        [<Config.Form>]RenderingOptions: Choice<Create'InvoiceSettingsRenderingOptionsRenderingOptions,string> option
    }
    with
        static member New(?customFields: Choice<Create'InvoiceSettingsCustomFields list,string>, ?defaultPaymentMethod: string, ?footer: string, ?renderingOptions: Choice<Create'InvoiceSettingsRenderingOptionsRenderingOptions,string>) =
            {
                CustomFields = customFields
                DefaultPaymentMethod = defaultPaymentMethod
                Footer = footer
                RenderingOptions = renderingOptions
            }

    type Create'ShippingCustomerShippingAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'ShippingCustomerShipping = {
        ///Customer shipping address.
        [<Config.Form>]Address: Create'ShippingCustomerShippingAddress option
        ///Customer name.
        [<Config.Form>]Name: string option
        ///Customer phone (including extension).
        [<Config.Form>]Phone: string option
    }
    with
        static member New(?address: Create'ShippingCustomerShippingAddress, ?name: string, ?phone: string) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Create'Tax = {
        ///A recent IP address of the customer used for tax reporting and tax location inference. Stripe recommends updating the IP address when a new PaymentMethod is attached or the address field on the customer is updated. We recommend against updating this field more frequently since it could result in unexpected tax location/reporting outcomes.
        [<Config.Form>]IpAddress: Choice<string,string> option
    }
    with
        static member New(?ipAddress: Choice<string,string>) =
            {
                IpAddress = ipAddress
            }

    type Create'TaxIdDataType =
    | AdNrt
    | AeTrn
    | ArCuit
    | AuAbn
    | AuArn
    | BgUic
    | BoTin
    | BrCnpj
    | BrCpf
    | CaBn
    | CaGstHst
    | CaPstBc
    | CaPstMb
    | CaPstSk
    | CaQst
    | ChVat
    | ClTin
    | CnTin
    | CoNit
    | CrTin
    | DoRcn
    | EcRuc
    | EgTin
    | EsCif
    | EuOssVat
    | EuVat
    | GbVat
    | GeVat
    | HkBr
    | HuTin
    | IdNpwp
    | IlVat
    | InGst
    | IsVat
    | JpCn
    | JpRn
    | JpTrn
    | KePin
    | KrBrn
    | LiUid
    | MxRfc
    | MyFrp
    | MyItn
    | MySst
    | NoVat
    | NzGst
    | PeRuc
    | PhTin
    | RoTin
    | RsPib
    | RuInn
    | RuKpp
    | SaVat
    | SgGst
    | SgUen
    | SiTin
    | SvNit
    | ThVat
    | TrTin
    | TwVat
    | UaVat
    | UsEin
    | UyRuc
    | VeRif
    | VnTin
    | ZaVat

    type Create'TaxIdData = {
        ///Type of the tax ID, one of `ad_nrt`, `ae_trn`, `ar_cuit`, `au_abn`, `au_arn`, `bg_uic`, `bo_tin`, `br_cnpj`, `br_cpf`, `ca_bn`, `ca_gst_hst`, `ca_pst_bc`, `ca_pst_mb`, `ca_pst_sk`, `ca_qst`, `ch_vat`, `cl_tin`, `cn_tin`, `co_nit`, `cr_tin`, `do_rcn`, `ec_ruc`, `eg_tin`, `es_cif`, `eu_oss_vat`, `eu_vat`, `gb_vat`, `ge_vat`, `hk_br`, `hu_tin`, `id_npwp`, `il_vat`, `in_gst`, `is_vat`, `jp_cn`, `jp_rn`, `jp_trn`, `ke_pin`, `kr_brn`, `li_uid`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `no_vat`, `nz_gst`, `pe_ruc`, `ph_tin`, `ro_tin`, `rs_pib`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `si_tin`, `sv_nit`, `th_vat`, `tr_tin`, `tw_vat`, `ua_vat`, `us_ein`, `uy_ruc`, `ve_rif`, `vn_tin`, or `za_vat`
        [<Config.Form>]Type: Create'TaxIdDataType option
        ///Value of the tax ID.
        [<Config.Form>]Value: string option
    }
    with
        static member New(?type': Create'TaxIdDataType, ?value: string) =
            {
                Type = type'
                Value = value
            }

    type Create'TaxExempt =
    | Exempt
    | None'
    | Reverse

    type CreateOptions = {
        ///The customer's address.
        [<Config.Form>]Address: Choice<Create'AddressOptionalFieldsAddress,string> option
        ///An integer amount in cents (or local equivalent) that represents the customer's current balance, which affect the customer's future invoices. A negative amount represents a credit that decreases the amount due on an invoice; a positive amount increases the amount due on an invoice.
        [<Config.Form>]Balance: int option
        ///Balance information and default balance settings for this customer.
        [<Config.Form>]CashBalance: Create'CashBalance option
        [<Config.Form>]Coupon: string option
        ///An arbitrary string that you can attach to a customer object. It is displayed alongside the customer in the dashboard.
        [<Config.Form>]Description: string option
        ///Customer's email address. It's displayed alongside the customer in your dashboard and can be useful for searching and tracking. This may be up to *512 characters*.
        [<Config.Form>]Email: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The prefix for the customer used to generate unique invoice numbers. Must be 3–12 uppercase letters or numbers.
        [<Config.Form>]InvoicePrefix: string option
        ///Default invoice settings for this customer.
        [<Config.Form>]InvoiceSettings: Create'InvoiceSettings option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The customer's full name or business name.
        [<Config.Form>]Name: string option
        ///The sequence to be used on the customer's next invoice. Defaults to 1.
        [<Config.Form>]NextInvoiceSequence: int option
        [<Config.Form>]PaymentMethod: string option
        ///The customer's phone number.
        [<Config.Form>]Phone: string option
        ///Customer's preferred languages, ordered by preference.
        [<Config.Form>]PreferredLocales: string list option
        ///The API ID of a promotion code to apply to the customer. The customer will have a discount applied on all recurring payments. Charges you create through the API will not have the discount.
        [<Config.Form>]PromotionCode: string option
        ///The customer's shipping information. Appears on invoices emailed to this customer.
        [<Config.Form>]Shipping: Choice<Create'ShippingCustomerShipping,string> option
        [<Config.Form>]Source: string option
        ///Tax details about the customer.
        [<Config.Form>]Tax: Create'Tax option
        ///The customer's tax exemption. One of `none`, `exempt`, or `reverse`.
        [<Config.Form>]TaxExempt: Create'TaxExempt option
        ///The customer's tax IDs.
        [<Config.Form>]TaxIdData: Create'TaxIdData list option
        ///ID of the test clock to attach to the customer.
        [<Config.Form>]TestClock: string option
        [<Config.Form>]Validate: bool option
    }
    with
        static member New(?address: Choice<Create'AddressOptionalFieldsAddress,string>, ?taxIdData: Create'TaxIdData list, ?taxExempt: Create'TaxExempt, ?tax: Create'Tax, ?source: string, ?shipping: Choice<Create'ShippingCustomerShipping,string>, ?promotionCode: string, ?preferredLocales: string list, ?phone: string, ?paymentMethod: string, ?testClock: string, ?nextInvoiceSequence: int, ?metadata: Map<string, string>, ?invoiceSettings: Create'InvoiceSettings, ?invoicePrefix: string, ?expand: string list, ?email: string, ?description: string, ?coupon: string, ?cashBalance: Create'CashBalance, ?balance: int, ?name: string, ?validate: bool) =
            {
                Address = address
                Balance = balance
                CashBalance = cashBalance
                Coupon = coupon
                Description = description
                Email = email
                Expand = expand
                InvoicePrefix = invoicePrefix
                InvoiceSettings = invoiceSettings
                Metadata = metadata
                Name = name
                NextInvoiceSequence = nextInvoiceSequence
                PaymentMethod = paymentMethod
                Phone = phone
                PreferredLocales = preferredLocales
                PromotionCode = promotionCode
                Shipping = shipping
                Source = source
                Tax = tax
                TaxExempt = taxExempt
                TaxIdData = taxIdData
                TestClock = testClock
                Validate = validate
            }

    ///<p>Creates a new customer object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/customers"
        |> RestApi.postAsync<_, Customer> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Customer: string
    }
    with
        static member New(customer: string) =
            {
                Customer = customer
            }

    ///<p>Permanently deletes a customer. It cannot be undone. Also immediately cancels any active subscriptions on the customer.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/customers/{options.Customer}"
        |> RestApi.deleteAsync<DeletedCustomer> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Customer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(customer: string, ?expand: string list) =
            {
                Customer = customer
                Expand = expand
            }

    ///<p>Retrieves a Customer object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}"
        |> RestApi.getAsync<Customer> settings qs

    type Update'AddressOptionalFieldsAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'CashBalanceSettingsReconciliationMode =
    | Automatic
    | Manual
    | MerchantDefault

    type Update'CashBalanceSettings = {
        ///Controls how funds transferred by the customer are applied to payment intents and invoices. Valid options are `automatic`, `manual`, or `merchant_default`. For more information about these reconciliation modes, see [Reconciliation](https://stripe.com/docs/payments/customer-balance/reconciliation).
        [<Config.Form>]ReconciliationMode: Update'CashBalanceSettingsReconciliationMode option
    }
    with
        static member New(?reconciliationMode: Update'CashBalanceSettingsReconciliationMode) =
            {
                ReconciliationMode = reconciliationMode
            }

    type Update'CashBalance = {
        ///Settings controlling the behavior of the customer's cash balance,
        ///such as reconciliation of funds received.
        [<Config.Form>]Settings: Update'CashBalanceSettings option
    }
    with
        static member New(?settings: Update'CashBalanceSettings) =
            {
                Settings = settings
            }

    type Update'InvoiceSettingsCustomFields = {
        ///The name of the custom field. This may be up to 30 characters.
        [<Config.Form>]Name: string option
        ///The value of the custom field. This may be up to 30 characters.
        [<Config.Form>]Value: string option
    }
    with
        static member New(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Update'InvoiceSettingsRenderingOptionsRenderingOptionsAmountTaxDisplay =
    | ExcludeTax
    | IncludeInclusiveTax

    type Update'InvoiceSettingsRenderingOptionsRenderingOptions = {
        ///How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.
        [<Config.Form>]AmountTaxDisplay: Update'InvoiceSettingsRenderingOptionsRenderingOptionsAmountTaxDisplay option
    }
    with
        static member New(?amountTaxDisplay: Update'InvoiceSettingsRenderingOptionsRenderingOptionsAmountTaxDisplay) =
            {
                AmountTaxDisplay = amountTaxDisplay
            }

    type Update'InvoiceSettings = {
        ///Default custom fields to be displayed on invoices for this customer. When updating, pass an empty string to remove previously-defined fields.
        [<Config.Form>]CustomFields: Choice<Update'InvoiceSettingsCustomFields list,string> option
        ///ID of a payment method that's attached to the customer, to be used as the customer's default payment method for subscriptions and invoices.
        [<Config.Form>]DefaultPaymentMethod: string option
        ///Default footer to be displayed on invoices for this customer.
        [<Config.Form>]Footer: string option
        ///Default options for invoice PDF rendering for this customer.
        [<Config.Form>]RenderingOptions: Choice<Update'InvoiceSettingsRenderingOptionsRenderingOptions,string> option
    }
    with
        static member New(?customFields: Choice<Update'InvoiceSettingsCustomFields list,string>, ?defaultPaymentMethod: string, ?footer: string, ?renderingOptions: Choice<Update'InvoiceSettingsRenderingOptionsRenderingOptions,string>) =
            {
                CustomFields = customFields
                DefaultPaymentMethod = defaultPaymentMethod
                Footer = footer
                RenderingOptions = renderingOptions
            }

    type Update'ShippingCustomerShippingAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'ShippingCustomerShipping = {
        ///Customer shipping address.
        [<Config.Form>]Address: Update'ShippingCustomerShippingAddress option
        ///Customer name.
        [<Config.Form>]Name: string option
        ///Customer phone (including extension).
        [<Config.Form>]Phone: string option
    }
    with
        static member New(?address: Update'ShippingCustomerShippingAddress, ?name: string, ?phone: string) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Update'Tax = {
        ///A recent IP address of the customer used for tax reporting and tax location inference. Stripe recommends updating the IP address when a new PaymentMethod is attached or the address field on the customer is updated. We recommend against updating this field more frequently since it could result in unexpected tax location/reporting outcomes.
        [<Config.Form>]IpAddress: Choice<string,string> option
    }
    with
        static member New(?ipAddress: Choice<string,string>) =
            {
                IpAddress = ipAddress
            }

    type Update'TaxExempt =
    | Exempt
    | None'
    | Reverse

    type UpdateOptions = {
        [<Config.Path>]Customer: string
        ///The customer's address.
        [<Config.Form>]Address: Choice<Update'AddressOptionalFieldsAddress,string> option
        ///An integer amount in cents (or local equivalent) that represents the customer's current balance, which affect the customer's future invoices. A negative amount represents a credit that decreases the amount due on an invoice; a positive amount increases the amount due on an invoice.
        [<Config.Form>]Balance: int option
        ///Balance information and default balance settings for this customer.
        [<Config.Form>]CashBalance: Update'CashBalance option
        [<Config.Form>]Coupon: string option
        ///If you are using payment methods created via the PaymentMethods API, see the [invoice_settings.default_payment_method](https://stripe.com/docs/api/customers/update#update_customer-invoice_settings-default_payment_method) parameter.
        ///Provide the ID of a payment source already attached to this customer to make it this customer's default payment source.
        ///If you want to add a new payment source and make it the default, see the [source](https://stripe.com/docs/api/customers/update#update_customer-source) property.
        [<Config.Form>]DefaultSource: string option
        ///An arbitrary string that you can attach to a customer object. It is displayed alongside the customer in the dashboard.
        [<Config.Form>]Description: string option
        ///Customer's email address. It's displayed alongside the customer in your dashboard and can be useful for searching and tracking. This may be up to *512 characters*.
        [<Config.Form>]Email: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The prefix for the customer used to generate unique invoice numbers. Must be 3–12 uppercase letters or numbers.
        [<Config.Form>]InvoicePrefix: string option
        ///Default invoice settings for this customer.
        [<Config.Form>]InvoiceSettings: Update'InvoiceSettings option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The customer's full name or business name.
        [<Config.Form>]Name: string option
        ///The sequence to be used on the customer's next invoice. Defaults to 1.
        [<Config.Form>]NextInvoiceSequence: int option
        ///The customer's phone number.
        [<Config.Form>]Phone: string option
        ///Customer's preferred languages, ordered by preference.
        [<Config.Form>]PreferredLocales: string list option
        ///The API ID of a promotion code to apply to the customer. The customer will have a discount applied on all recurring payments. Charges you create through the API will not have the discount.
        [<Config.Form>]PromotionCode: string option
        ///The customer's shipping information. Appears on invoices emailed to this customer.
        [<Config.Form>]Shipping: Choice<Update'ShippingCustomerShipping,string> option
        [<Config.Form>]Source: string option
        ///Tax details about the customer.
        [<Config.Form>]Tax: Update'Tax option
        ///The customer's tax exemption. One of `none`, `exempt`, or `reverse`.
        [<Config.Form>]TaxExempt: Update'TaxExempt option
        [<Config.Form>]Validate: bool option
    }
    with
        static member New(customer: string, ?tax: Update'Tax, ?source: string, ?shipping: Choice<Update'ShippingCustomerShipping,string>, ?promotionCode: string, ?preferredLocales: string list, ?phone: string, ?nextInvoiceSequence: int, ?name: string, ?metadata: Map<string, string>, ?invoiceSettings: Update'InvoiceSettings, ?invoicePrefix: string, ?expand: string list, ?email: string, ?description: string, ?defaultSource: string, ?coupon: string, ?cashBalance: Update'CashBalance, ?balance: int, ?address: Choice<Update'AddressOptionalFieldsAddress,string>, ?taxExempt: Update'TaxExempt, ?validate: bool) =
            {
                Customer = customer
                Address = address
                Balance = balance
                CashBalance = cashBalance
                Coupon = coupon
                DefaultSource = defaultSource
                Description = description
                Email = email
                Expand = expand
                InvoicePrefix = invoicePrefix
                InvoiceSettings = invoiceSettings
                Metadata = metadata
                Name = name
                NextInvoiceSequence = nextInvoiceSequence
                Phone = phone
                PreferredLocales = preferredLocales
                PromotionCode = promotionCode
                Shipping = shipping
                Source = source
                Tax = tax
                TaxExempt = taxExempt
                Validate = validate
            }

    ///<p>Updates the specified customer by setting the values of the parameters passed. Any parameters not provided will be left unchanged. For example, if you pass the <strong>source</strong> parameter, that becomes the customer’s active source (e.g., a card) to be used for all charges in the future. When you update a customer to a new valid card source by passing the <strong>source</strong> parameter: for each of the customer’s current subscriptions, if the subscription bills automatically and is in the <code>past_due</code> state, then the latest open invoice for the subscription with automatic collection enabled will be retried. This retry will not count as an automatic retry, and will not affect the next regularly scheduled payment for the invoice. Changing the <strong>default_source</strong> for a customer will not trigger this behavior.
    ///This request accepts mostly the same arguments as the customer creation call.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/customers/{options.Customer}"
        |> RestApi.postAsync<_, Customer> settings (Map.empty) options

module CustomersSearch =

    type SearchOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.
        [<Config.Query>]Page: string option
        ///The search query string. See [search query language](https://stripe.com/docs/search#search-query-language) and the list of supported [query fields for customers](https://stripe.com/docs/search#query-fields-for-customers).
        [<Config.Query>]Query: string
    }
    with
        static member New(query: string, ?expand: string list, ?limit: int, ?page: string) =
            {
                Expand = expand
                Limit = limit
                Page = page
                Query = query
            }

    ///<p>Search for customers you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/customers/search"
        |> RestApi.getAsync<Customer list> settings qs

module CustomersBalanceTransactions =

    type BalanceTransactionsOptions = {
        [<Config.Path>]Customer: string
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of transactions that updated the customer’s <a href="/docs/billing/customer/balance">balances</a>.</p>
    let BalanceTransactions settings (options: BalanceTransactionsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/balance_transactions"
        |> RestApi.getAsync<CustomerBalanceTransaction list> settings qs

    type CreateOptions = {
        [<Config.Path>]Customer: string
        ///The integer amount in **cents (or local equivalent)** to apply to the customer's credit balance.
        [<Config.Form>]Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies). Specifies the [`invoice_credit_balance`](https://stripe.com/docs/api/customers/object#customer_object-invoice_credit_balance) that this transaction will apply to. If the customer's `currency` is not set, it will be updated to this value.
        [<Config.Form>]Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(customer: string, amount: int, currency: string, ?description: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Customer = customer
                Amount = amount
                Currency = currency
                Description = description
                Expand = expand
                Metadata = metadata
            }

    ///<p>Creates an immutable transaction that updates the customer’s credit <a href="/docs/billing/customer/balance">balance</a>.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/customers/{options.Customer}/balance_transactions"
        |> RestApi.postAsync<_, CustomerBalanceTransaction> settings (Map.empty) options

    type RetrieveOptions = {
        [<Config.Path>]Customer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Transaction: string
    }
    with
        static member New(customer: string, transaction: string, ?expand: string list) =
            {
                Customer = customer
                Expand = expand
                Transaction = transaction
            }

    ///<p>Retrieves a specific customer balance transaction that updated the customer’s <a href="/docs/billing/customer/balance">balances</a>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/balance_transactions/{options.Transaction}"
        |> RestApi.getAsync<CustomerBalanceTransaction> settings qs

    type UpdateOptions = {
        [<Config.Path>]Customer: string
        [<Config.Path>]Transaction: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(customer: string, transaction: string, ?description: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Customer = customer
                Transaction = transaction
                Description = description
                Expand = expand
                Metadata = metadata
            }

    ///<p>Most credit balance transaction fields are immutable, but you may update its <code>description</code> and <code>metadata</code>.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/customers/{options.Customer}/balance_transactions/{options.Transaction}"
        |> RestApi.postAsync<_, CustomerBalanceTransaction> settings (Map.empty) options

module CustomersCashBalance =

    type RetrieveOptions = {
        [<Config.Path>]Customer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(customer: string, ?expand: string list) =
            {
                Customer = customer
                Expand = expand
            }

    ///<p>Retrieves a customer’s cash balance.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/cash_balance"
        |> RestApi.getAsync<CashBalance> settings qs

    type Update'SettingsReconciliationMode =
    | Automatic
    | Manual
    | MerchantDefault

    type Update'Settings = {
        ///Controls how funds transferred by the customer are applied to payment intents and invoices. Valid options are `automatic`, `manual`, or `merchant_default`. For more information about these reconciliation modes, see [Reconciliation](https://stripe.com/docs/payments/customer-balance/reconciliation).
        [<Config.Form>]ReconciliationMode: Update'SettingsReconciliationMode option
    }
    with
        static member New(?reconciliationMode: Update'SettingsReconciliationMode) =
            {
                ReconciliationMode = reconciliationMode
            }

    type UpdateOptions = {
        [<Config.Path>]Customer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A hash of settings for this cash balance.
        [<Config.Form>]Settings: Update'Settings option
    }
    with
        static member New(customer: string, ?expand: string list, ?settings: Update'Settings) =
            {
                Customer = customer
                Expand = expand
                Settings = settings
            }

    ///<p>Changes the settings on a customer’s cash balance.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/customers/{options.Customer}/cash_balance"
        |> RestApi.postAsync<_, CashBalance> settings (Map.empty) options

module CustomersCashBalanceTransactions =

    type ListOptions = {
        [<Config.Path>]Customer: string
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of transactions that modified the customer’s <a href="/docs/payments/customer-balance">cash balance</a>.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/cash_balance_transactions"
        |> RestApi.getAsync<CustomerCashBalanceTransaction list> settings qs

    type RetrieveOptions = {
        [<Config.Path>]Customer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Transaction: string
    }
    with
        static member New(customer: string, transaction: string, ?expand: string list) =
            {
                Customer = customer
                Expand = expand
                Transaction = transaction
            }

    ///<p>Retrieves a specific cash balance transaction, which updated the customer’s <a href="/docs/payments/customer-balance">cash balance</a>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/cash_balance_transactions/{options.Transaction}"
        |> RestApi.getAsync<CustomerCashBalanceTransaction> settings qs

module CustomersDiscount =

    type DeleteDiscountOptions = {
        [<Config.Path>]Customer: string
    }
    with
        static member New(customer: string) =
            {
                Customer = customer
            }

    ///<p>Removes the currently applied discount on a customer.</p>
    let DeleteDiscount settings (options: DeleteDiscountOptions) =
        $"/v1/customers/{options.Customer}/discount"
        |> RestApi.deleteAsync<DeletedDiscount> settings (Map.empty)

module CustomersFundingInstructions =

    type CreateFundingInstructions'BankTransferEuBankTransfer = {
        ///The desired country code of the bank account information. Permitted values include: `BE`, `DE`, `ES`, `FR`, `IE`, or `NL`.
        [<Config.Form>]Country: string option
    }
    with
        static member New(?country: string) =
            {
                Country = country
            }

    type CreateFundingInstructions'BankTransferRequestedAddressTypes =
    | Iban
    | SortCode
    | Spei
    | Zengin

    type CreateFundingInstructions'BankTransferType =
    | EuBankTransfer
    | GbBankTransfer
    | JpBankTransfer
    | MxBankTransfer
    | UsBankTransfer

    type CreateFundingInstructions'BankTransfer = {
        ///Configuration for eu_bank_transfer funding type.
        [<Config.Form>]EuBankTransfer: CreateFundingInstructions'BankTransferEuBankTransfer option
        ///List of address types that should be returned in the financial_addresses response. If not specified, all valid types will be returned.
        ///Permitted values include: `sort_code`, `zengin`, `iban`, or `spei`.
        [<Config.Form>]RequestedAddressTypes: CreateFundingInstructions'BankTransferRequestedAddressTypes list option
        ///The type of the `bank_transfer`
        [<Config.Form>]Type: CreateFundingInstructions'BankTransferType option
    }
    with
        static member New(?euBankTransfer: CreateFundingInstructions'BankTransferEuBankTransfer, ?requestedAddressTypes: CreateFundingInstructions'BankTransferRequestedAddressTypes list, ?type': CreateFundingInstructions'BankTransferType) =
            {
                EuBankTransfer = euBankTransfer
                RequestedAddressTypes = requestedAddressTypes
                Type = type'
            }

    type CreateFundingInstructions'FundingType =
    | BankTransfer

    type CreateFundingInstructionsOptions = {
        [<Config.Path>]Customer: string
        ///Additional parameters for `bank_transfer` funding types
        [<Config.Form>]BankTransfer: CreateFundingInstructions'BankTransfer
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The `funding_type` to get the instructions for.
        [<Config.Form>]FundingType: CreateFundingInstructions'FundingType
    }
    with
        static member New(customer: string, bankTransfer: CreateFundingInstructions'BankTransfer, currency: string, fundingType: CreateFundingInstructions'FundingType, ?expand: string list) =
            {
                Customer = customer
                BankTransfer = bankTransfer
                Currency = currency
                Expand = expand
                FundingType = fundingType
            }

    ///<p>Retrieve funding instructions for a customer cash balance. If funding instructions do not yet exist for the customer, new
    ///funding instructions will be created. If funding instructions have already been created for a given customer, the same
    ///funding instructions will be retrieved. In other words, we will return the same funding instructions each time.</p>
    let CreateFundingInstructions settings (options: CreateFundingInstructionsOptions) =
        $"/v1/customers/{options.Customer}/funding_instructions"
        |> RestApi.postAsync<_, FundingInstructions> settings (Map.empty) options

module CustomersPaymentMethods =

    type ListPaymentMethodsOptions = {
        [<Config.Path>]Customer: string
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///An optional filter on the list, based on the object `type` field. Without the filter, the list includes all current and future payment method types. If your integration expects only one type of payment method in the response, make sure to provide a type value in the request.
        [<Config.Query>]Type: string option
    }
    with
        static member New(customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?type': string) =
            {
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Type = type'
            }

    ///<p>Returns a list of PaymentMethods for a given Customer</p>
    let ListPaymentMethods settings (options: ListPaymentMethodsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/payment_methods"
        |> RestApi.getAsync<PaymentMethod list> settings qs

    type RetrievePaymentMethodOptions = {
        [<Config.Path>]Customer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]PaymentMethod: string
    }
    with
        static member New(customer: string, paymentMethod: string, ?expand: string list) =
            {
                Customer = customer
                Expand = expand
                PaymentMethod = paymentMethod
            }

    ///<p>Retrieves a PaymentMethod object for a given Customer.</p>
    let RetrievePaymentMethod settings (options: RetrievePaymentMethodOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/payment_methods/{options.PaymentMethod}"
        |> RestApi.getAsync<PaymentMethod> settings qs

module CustomersSources =

    type ListOptions = {
        [<Config.Path>]Customer: string
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Filter sources according to a particular object type.
        [<Config.Query>]Object: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?object: string, ?startingAfter: string) =
            {
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Object = object
                StartingAfter = startingAfter
            }

    ///<p>List sources for a specified customer.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("object", options.Object |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/sources"
        |> RestApi.getAsync<PaymentSource list> settings qs

    type CreateOptions = {
        [<Config.Path>]Customer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Please refer to full [documentation](https://stripe.com/docs/api) instead.
        [<Config.Form>]Source: string
        [<Config.Form>]Validate: bool option
    }
    with
        static member New(customer: string, source: string, ?expand: string list, ?metadata: Map<string, string>, ?validate: bool) =
            {
                Customer = customer
                Expand = expand
                Metadata = metadata
                Source = source
                Validate = validate
            }

    ///<p>When you create a new credit card, you must specify a customer or recipient on which to create it.
    ///If the card’s owner has no default card, then the new card will become the default.
    ///However, if the owner already has a default, then it will not change.
    ///To change the default, you should <a href="/docs/api#update_customer">update the customer</a> to have a new <code>default_source</code>.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/customers/{options.Customer}/sources"
        |> RestApi.postAsync<_, PaymentSource> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Customer: string
        [<Config.Path>]Id: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(customer: string, id: string, ?expand: string list) =
            {
                Customer = customer
                Id = id
                Expand = expand
            }

    ///<p>Delete a specified source for a given customer.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/customers/{options.Customer}/sources/{options.Id}"
        |> RestApi.deleteAsync<PaymentSource> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Customer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(customer: string, id: string, ?expand: string list) =
            {
                Customer = customer
                Expand = expand
                Id = id
            }

    ///<p>Retrieve a specified source for a given customer.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/sources/{options.Id}"
        |> RestApi.getAsync<PaymentSource> settings qs

    type Update'OwnerAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'Owner = {
        ///Owner's address.
        [<Config.Form>]Address: Update'OwnerAddress option
        ///Owner's email address.
        [<Config.Form>]Email: string option
        ///Owner's full name.
        [<Config.Form>]Name: string option
        ///Owner's phone number.
        [<Config.Form>]Phone: string option
    }
    with
        static member New(?address: Update'OwnerAddress, ?email: string, ?name: string, ?phone: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Update'AccountHolderType =
    | Company
    | Individual

    type UpdateOptions = {
        [<Config.Path>]Customer: string
        [<Config.Path>]Id: string
        ///The name of the person or business that owns the bank account.
        [<Config.Form>]AccountHolderName: string option
        ///The type of entity that holds the account. This can be either `individual` or `company`.
        [<Config.Form>]AccountHolderType: Update'AccountHolderType option
        ///City/District/Suburb/Town/Village.
        [<Config.Form>]AddressCity: string option
        ///Billing address country, if provided when creating card.
        [<Config.Form>]AddressCountry: string option
        ///Address line 1 (Street address/PO Box/Company name).
        [<Config.Form>]AddressLine1: string option
        ///Address line 2 (Apartment/Suite/Unit/Building).
        [<Config.Form>]AddressLine2: string option
        ///State/County/Province/Region.
        [<Config.Form>]AddressState: string option
        ///ZIP or postal code.
        [<Config.Form>]AddressZip: string option
        ///Two digit number representing the card’s expiration month.
        [<Config.Form>]ExpMonth: string option
        ///Four digit number representing the card’s expiration year.
        [<Config.Form>]ExpYear: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Cardholder name.
        [<Config.Form>]Name: string option
        [<Config.Form>]Owner: Update'Owner option
    }
    with
        static member New(customer: string, id: string, ?accountHolderName: string, ?accountHolderType: Update'AccountHolderType, ?addressCity: string, ?addressCountry: string, ?addressLine1: string, ?addressLine2: string, ?addressState: string, ?addressZip: string, ?expMonth: string, ?expYear: string, ?expand: string list, ?metadata: Map<string, string>, ?name: string, ?owner: Update'Owner) =
            {
                Customer = customer
                Id = id
                AccountHolderName = accountHolderName
                AccountHolderType = accountHolderType
                AddressCity = addressCity
                AddressCountry = addressCountry
                AddressLine1 = addressLine1
                AddressLine2 = addressLine2
                AddressState = addressState
                AddressZip = addressZip
                ExpMonth = expMonth
                ExpYear = expYear
                Expand = expand
                Metadata = metadata
                Name = name
                Owner = owner
            }

    ///<p>Update a specified source for a given customer.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/customers/{options.Customer}/sources/{options.Id}"
        |> RestApi.postAsync<_, Card> settings (Map.empty) options

module CustomersSourcesVerify =

    type VerifyOptions = {
        [<Config.Path>]Customer: string
        [<Config.Path>]Id: string
        ///Two positive integers, in *cents*, equal to the values of the microdeposits sent to the bank account.
        [<Config.Form>]Amounts: int list option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(customer: string, id: string, ?amounts: int list, ?expand: string list) =
            {
                Customer = customer
                Id = id
                Amounts = amounts
                Expand = expand
            }

    ///<p>Verify a specified bank account for a given customer.</p>
    let Verify settings (options: VerifyOptions) =
        $"/v1/customers/{options.Customer}/sources/{options.Id}/verify"
        |> RestApi.postAsync<_, BankAccount> settings (Map.empty) options

module CustomersTaxIds =

    type ListOptions = {
        [<Config.Path>]Customer: string
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of tax IDs for a customer.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/tax_ids"
        |> RestApi.getAsync<TaxId list> settings qs

    type Create'Type =
    | AdNrt
    | AeTrn
    | ArCuit
    | AuAbn
    | AuArn
    | BgUic
    | BoTin
    | BrCnpj
    | BrCpf
    | CaBn
    | CaGstHst
    | CaPstBc
    | CaPstMb
    | CaPstSk
    | CaQst
    | ChVat
    | ClTin
    | CnTin
    | CoNit
    | CrTin
    | DoRcn
    | EcRuc
    | EgTin
    | EsCif
    | EuOssVat
    | EuVat
    | GbVat
    | GeVat
    | HkBr
    | HuTin
    | IdNpwp
    | IlVat
    | InGst
    | IsVat
    | JpCn
    | JpRn
    | JpTrn
    | KePin
    | KrBrn
    | LiUid
    | MxRfc
    | MyFrp
    | MyItn
    | MySst
    | NoVat
    | NzGst
    | PeRuc
    | PhTin
    | RoTin
    | RsPib
    | RuInn
    | RuKpp
    | SaVat
    | SgGst
    | SgUen
    | SiTin
    | SvNit
    | ThVat
    | TrTin
    | TwVat
    | UaVat
    | UsEin
    | UyRuc
    | VeRif
    | VnTin
    | ZaVat

    type CreateOptions = {
        [<Config.Path>]Customer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Type of the tax ID, one of `ad_nrt`, `ae_trn`, `ar_cuit`, `au_abn`, `au_arn`, `bg_uic`, `bo_tin`, `br_cnpj`, `br_cpf`, `ca_bn`, `ca_gst_hst`, `ca_pst_bc`, `ca_pst_mb`, `ca_pst_sk`, `ca_qst`, `ch_vat`, `cl_tin`, `cn_tin`, `co_nit`, `cr_tin`, `do_rcn`, `ec_ruc`, `eg_tin`, `es_cif`, `eu_oss_vat`, `eu_vat`, `gb_vat`, `ge_vat`, `hk_br`, `hu_tin`, `id_npwp`, `il_vat`, `in_gst`, `is_vat`, `jp_cn`, `jp_rn`, `jp_trn`, `ke_pin`, `kr_brn`, `li_uid`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `no_vat`, `nz_gst`, `pe_ruc`, `ph_tin`, `ro_tin`, `rs_pib`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `si_tin`, `sv_nit`, `th_vat`, `tr_tin`, `tw_vat`, `ua_vat`, `us_ein`, `uy_ruc`, `ve_rif`, `vn_tin`, or `za_vat`
        [<Config.Form>]Type: Create'Type
        ///Value of the tax ID.
        [<Config.Form>]Value: string
    }
    with
        static member New(customer: string, type': Create'Type, value: string, ?expand: string list) =
            {
                Customer = customer
                Expand = expand
                Type = type'
                Value = value
            }

    ///<p>Creates a new <code>TaxID</code> object for a customer.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/customers/{options.Customer}/tax_ids"
        |> RestApi.postAsync<_, TaxId> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Customer: string
        [<Config.Path>]Id: string
    }
    with
        static member New(customer: string, id: string) =
            {
                Customer = customer
                Id = id
            }

    ///<p>Deletes an existing <code>TaxID</code> object.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/customers/{options.Customer}/tax_ids/{options.Id}"
        |> RestApi.deleteAsync<DeletedTaxId> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Customer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(customer: string, id: string, ?expand: string list) =
            {
                Customer = customer
                Expand = expand
                Id = id
            }

    ///<p>Retrieves the <code>TaxID</code> object with the given identifier.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/customers/{options.Customer}/tax_ids/{options.Id}"
        |> RestApi.getAsync<TaxId> settings qs

module Disputes =

    type ListOptions = {
        ///Only return disputes associated to the charge specified by this charge ID.
        [<Config.Query>]Charge: string option
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Only return disputes associated to the PaymentIntent specified by this PaymentIntent ID.
        [<Config.Query>]PaymentIntent: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
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

    ///<p>Returns a list of your disputes.</p>
    let List settings (options: ListOptions) =
        let qs = [("charge", options.Charge |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/disputes"
        |> RestApi.getAsync<Dispute list> settings qs

    type RetrieveOptions = {
        [<Config.Path>]Dispute: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(dispute: string, ?expand: string list) =
            {
                Dispute = dispute
                Expand = expand
            }

    ///<p>Retrieves the dispute with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/disputes/{options.Dispute}"
        |> RestApi.getAsync<Dispute> settings qs

    type Update'Evidence = {
        ///Any server or activity logs showing proof that the customer accessed or downloaded the purchased digital product. This information should include IP addresses, corresponding timestamps, and any detailed recorded activity. Has a maximum character count of 20,000.
        [<Config.Form>]AccessActivityLog: string option
        ///The billing address provided by the customer.
        [<Config.Form>]BillingAddress: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Your subscription cancellation policy, as shown to the customer.
        [<Config.Form>]CancellationPolicy: string option
        ///An explanation of how and when the customer was shown your refund policy prior to purchase. Has a maximum character count of 20,000.
        [<Config.Form>]CancellationPolicyDisclosure: string option
        ///A justification for why the customer's subscription was not canceled. Has a maximum character count of 20,000.
        [<Config.Form>]CancellationRebuttal: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any communication with the customer that you feel is relevant to your case. Examples include emails proving that the customer received the product or service, or demonstrating their use of or satisfaction with the product or service.
        [<Config.Form>]CustomerCommunication: string option
        ///The email address of the customer.
        [<Config.Form>]CustomerEmailAddress: string option
        ///The name of the customer.
        [<Config.Form>]CustomerName: string option
        ///The IP address that the customer used when making the purchase.
        [<Config.Form>]CustomerPurchaseIp: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) A relevant document or contract showing the customer's signature.
        [<Config.Form>]CustomerSignature: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation for the prior charge that can uniquely identify the charge, such as a receipt, shipping label, work order, etc. This document should be paired with a similar document from the disputed payment that proves the two payments are separate.
        [<Config.Form>]DuplicateChargeDocumentation: string option
        ///An explanation of the difference between the disputed charge versus the prior charge that appears to be a duplicate. Has a maximum character count of 20,000.
        [<Config.Form>]DuplicateChargeExplanation: string option
        ///The Stripe ID for the prior charge which appears to be a duplicate of the disputed charge.
        [<Config.Form>]DuplicateChargeId: string option
        ///A description of the product or service that was sold. Has a maximum character count of 20,000.
        [<Config.Form>]ProductDescription: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any receipt or message sent to the customer notifying them of the charge.
        [<Config.Form>]Receipt: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Your refund policy, as shown to the customer.
        [<Config.Form>]RefundPolicy: string option
        ///Documentation demonstrating that the customer was shown your refund policy prior to purchase. Has a maximum character count of 20,000.
        [<Config.Form>]RefundPolicyDisclosure: string option
        ///A justification for why the customer is not entitled to a refund. Has a maximum character count of 20,000.
        [<Config.Form>]RefundRefusalExplanation: string option
        ///The date on which the customer received or began receiving the purchased service, in a clear human-readable format.
        [<Config.Form>]ServiceDate: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation showing proof that a service was provided to the customer. This could include a copy of a signed contract, work order, or other form of written agreement.
        [<Config.Form>]ServiceDocumentation: string option
        ///The address to which a physical product was shipped. You should try to include as complete address information as possible.
        [<Config.Form>]ShippingAddress: string option
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc. If multiple carriers were used for this purchase, please separate them with commas.
        [<Config.Form>]ShippingCarrier: string option
        ///The date on which a physical product began its route to the shipping address, in a clear human-readable format.
        [<Config.Form>]ShippingDate: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Documentation showing proof that a product was shipped to the customer at the same address the customer provided to you. This could include a copy of the shipment receipt, shipping label, etc. It should show the customer's full shipping address, if possible.
        [<Config.Form>]ShippingDocumentation: string option
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        [<Config.Form>]ShippingTrackingNumber: string option
        ///(ID of a [file upload](https://stripe.com/docs/guides/file-upload)) Any additional evidence or statements.
        [<Config.Form>]UncategorizedFile: string option
        ///Any additional evidence or statements. Has a maximum character count of 20,000.
        [<Config.Form>]UncategorizedText: string option
    }
    with
        static member New(?accessActivityLog: string, ?shippingTrackingNumber: string, ?shippingDocumentation: string, ?shippingDate: string, ?shippingCarrier: string, ?shippingAddress: string, ?serviceDocumentation: string, ?serviceDate: string, ?refundRefusalExplanation: string, ?refundPolicyDisclosure: string, ?refundPolicy: string, ?receipt: string, ?uncategorizedFile: string, ?productDescription: string, ?duplicateChargeExplanation: string, ?duplicateChargeDocumentation: string, ?customerSignature: string, ?customerPurchaseIp: string, ?customerName: string, ?customerEmailAddress: string, ?customerCommunication: string, ?cancellationRebuttal: string, ?cancellationPolicyDisclosure: string, ?cancellationPolicy: string, ?billingAddress: string, ?duplicateChargeId: string, ?uncategorizedText: string) =
            {
                AccessActivityLog = accessActivityLog
                BillingAddress = billingAddress
                CancellationPolicy = cancellationPolicy
                CancellationPolicyDisclosure = cancellationPolicyDisclosure
                CancellationRebuttal = cancellationRebuttal
                CustomerCommunication = customerCommunication
                CustomerEmailAddress = customerEmailAddress
                CustomerName = customerName
                CustomerPurchaseIp = customerPurchaseIp
                CustomerSignature = customerSignature
                DuplicateChargeDocumentation = duplicateChargeDocumentation
                DuplicateChargeExplanation = duplicateChargeExplanation
                DuplicateChargeId = duplicateChargeId
                ProductDescription = productDescription
                Receipt = receipt
                RefundPolicy = refundPolicy
                RefundPolicyDisclosure = refundPolicyDisclosure
                RefundRefusalExplanation = refundRefusalExplanation
                ServiceDate = serviceDate
                ServiceDocumentation = serviceDocumentation
                ShippingAddress = shippingAddress
                ShippingCarrier = shippingCarrier
                ShippingDate = shippingDate
                ShippingDocumentation = shippingDocumentation
                ShippingTrackingNumber = shippingTrackingNumber
                UncategorizedFile = uncategorizedFile
                UncategorizedText = uncategorizedText
            }

    type UpdateOptions = {
        [<Config.Path>]Dispute: string
        ///Evidence to upload, to respond to a dispute. Updating any field in the hash will submit all fields in the hash for review. The combined character count of all fields is limited to 150,000.
        [<Config.Form>]Evidence: Update'Evidence option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Whether to immediately submit evidence to the bank. If `false`, evidence is staged on the dispute. Staged evidence is visible in the API and Dashboard, and can be submitted to the bank by making another request with this attribute set to `true` (the default).
        [<Config.Form>]Submit: bool option
    }
    with
        static member New(dispute: string, ?evidence: Update'Evidence, ?expand: string list, ?metadata: Map<string, string>, ?submit: bool) =
            {
                Dispute = dispute
                Evidence = evidence
                Expand = expand
                Metadata = metadata
                Submit = submit
            }

    ///<p>When you get a dispute, contacting your customer is always the best first step. If that doesn’t work, you can submit evidence to help us resolve the dispute in your favor. You can do this in your <a href="https://dashboard.stripe.com/disputes">dashboard</a>, but if you prefer, you can use the API to submit evidence programmatically.
    ///Depending on your dispute type, different evidence fields will give you a better chance of winning your dispute. To figure out which evidence fields to provide, see our <a href="/docs/disputes/categories">guide to dispute types</a>.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/disputes/{options.Dispute}"
        |> RestApi.postAsync<_, Dispute> settings (Map.empty) options

module DisputesClose =

    type CloseOptions = {
        [<Config.Path>]Dispute: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(dispute: string, ?expand: string list) =
            {
                Dispute = dispute
                Expand = expand
            }

    ///<p>Closing the dispute for a charge indicates that you do not have any evidence to submit and are essentially dismissing the dispute, acknowledging it as lost.
    ///The status of the dispute will change from <code>needs_response</code> to <code>lost</code>. <em>Closing a dispute is irreversible</em>.</p>
    let Close settings (options: CloseOptions) =
        $"/v1/disputes/{options.Dispute}/close"
        |> RestApi.postAsync<_, Dispute> settings (Map.empty) options

module EphemeralKeys =

    type CreateOptions = {
        ///The ID of the Customer you'd like to modify using the resulting ephemeral key.
        [<Config.Form>]Customer: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The ID of the Issuing Card you'd like to access using the resulting ephemeral key.
        [<Config.Form>]IssuingCard: string option
        ///The ID of the Identity VerificationSession you'd like to access using the resulting ephemeral key
        [<Config.Form>]VerificationSession: string option
    }
    with
        static member New(?customer: string, ?expand: string list, ?issuingCard: string, ?verificationSession: string) =
            {
                Customer = customer
                Expand = expand
                IssuingCard = issuingCard
                VerificationSession = verificationSession
            }

    ///<p>Creates a short-lived API key for a given resource.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/ephemeral_keys"
        |> RestApi.postAsync<_, EphemeralKey> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Key: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(key: string, ?expand: string list) =
            {
                Key = key
                Expand = expand
            }

    ///<p>Invalidates a short-lived API key for a given resource.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/ephemeral_keys/{options.Key}"
        |> RestApi.deleteAsync<EphemeralKey> settings (Map.empty)

module Events =

    type ListOptions = {
        [<Config.Query>]Created: int option
        ///Filter events by whether all webhooks were successfully delivered. If false, events which are still pending or have failed all delivery attempts to a webhook endpoint will be returned.
        [<Config.Query>]DeliverySuccess: bool option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///A string containing a specific event name, or group of events using * as a wildcard. The list will be filtered to include only events with a matching event property.
        [<Config.Query>]Type: string option
        ///An array of up to 20 strings containing specific event names. The list will be filtered to include only events with a matching event property. You may pass either `type` or `types`, but not both.
        [<Config.Query>]Types: string list option
    }
    with
        static member New(?created: int, ?deliverySuccess: bool, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?type': string, ?types: string list) =
            {
                Created = created
                DeliverySuccess = deliverySuccess
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Type = type'
                Types = types
            }

    ///<p>List events, going back up to 30 days. Each event data is rendered according to Stripe API version at its creation time, specified in <a href="/docs/api/events/object">event object</a> <code>api_version</code> attribute (not according to your current Stripe API version or <code>Stripe-Version</code> header).</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("delivery_success", options.DeliverySuccess |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box); ("types", options.Types |> box)] |> Map.ofList
        $"/v1/events"
        |> RestApi.getAsync<Event list> settings qs

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<p>Retrieves the details of an event. Supply the unique identifier of the event, which you might have received in a webhook.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/events/{options.Id}"
        |> RestApi.getAsync<Event> settings qs

module ExchangeRates =

    type ListOptions = {
        ///A cursor for use in pagination. `ending_before` is the currency that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with the exchange rate for currency X your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and total number of supported payout currencies, and the default is the max.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is the currency that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with the exchange rate for currency X, your subsequent call can include `starting_after=X` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of objects that contain the rates at which foreign currencies are converted to one another. Only shows the currencies for which Stripe supports.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/exchange_rates"
        |> RestApi.getAsync<ExchangeRate list> settings qs

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]RateId: string
    }
    with
        static member New(rateId: string, ?expand: string list) =
            {
                Expand = expand
                RateId = rateId
            }

    ///<p>Retrieves the exchange rates from the given currency to every supported currency.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/exchange_rates/{options.RateId}"
        |> RestApi.getAsync<ExchangeRate> settings qs

module FileLinks =

    type ListOptions = {
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///Filter links by their expiration status. By default, all links are returned.
        [<Config.Query>]Expired: bool option
        ///Only return links for the given file.
        [<Config.Query>]File: string option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?expired: bool, ?file: string, ?limit: int, ?startingAfter: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Expired = expired
                File = file
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of file links.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("expired", options.Expired |> box); ("file", options.File |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/file_links"
        |> RestApi.getAsync<FileLink list> settings qs

    type CreateOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A future timestamp after which the link will no longer be usable.
        [<Config.Form>]ExpiresAt: DateTime option
        ///The ID of the file. The file's `purpose` must be one of the following: `business_icon`, `business_logo`, `customer_signature`, `dispute_evidence`, `finance_report_run`, `identity_document_downloadable`, `pci_document`, `selfie`, `sigma_scheduled_query`, `tax_document_user_upload`, or `terminal_reader_splashscreen`.
        [<Config.Form>]File: string
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(file: string, ?expand: string list, ?expiresAt: DateTime, ?metadata: Map<string, string>) =
            {
                Expand = expand
                ExpiresAt = expiresAt
                File = file
                Metadata = metadata
            }

    ///<p>Creates a new file link object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/file_links"
        |> RestApi.postAsync<_, FileLink> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Link: string
    }
    with
        static member New(link: string, ?expand: string list) =
            {
                Expand = expand
                Link = link
            }

    ///<p>Retrieves the file link with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/file_links/{options.Link}"
        |> RestApi.getAsync<FileLink> settings qs

    type Update'ExpiresAt =
    | Now

    type UpdateOptions = {
        [<Config.Path>]Link: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A future timestamp after which the link will no longer be usable, or `now` to expire the link immediately.
        [<Config.Form>]ExpiresAt: Choice<Update'ExpiresAt,DateTime,string> option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(link: string, ?expand: string list, ?expiresAt: Choice<Update'ExpiresAt,DateTime,string>, ?metadata: Map<string, string>) =
            {
                Link = link
                Expand = expand
                ExpiresAt = expiresAt
                Metadata = metadata
            }

    ///<p>Updates an existing file link object. Expired links can no longer be updated.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/file_links/{options.Link}"
        |> RestApi.postAsync<_, FileLink> settings (Map.empty) options

module Files =

    type ListOptions = {
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///The file purpose to filter queries by. If none is provided, files will not be filtered by purpose.
        [<Config.Query>]Purpose: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?purpose: string, ?startingAfter: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Purpose = purpose
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of the files that your account has access to. The files are returned sorted by creation date, with the most recently created files appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("purpose", options.Purpose |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/files"
        |> RestApi.getAsync<File list> settings qs

    type Create'FileLinkData = {
        ///Set this to `true` to create a file link for the newly created file. Creating a link is only possible when the file's `purpose` is one of the following: `business_icon`, `business_logo`, `customer_signature`, `dispute_evidence`, `pci_document`, `tax_document_user_upload`, or `terminal_reader_splashscreen`.
        [<Config.Form>]Create: bool option
        ///A future timestamp after which the link will no longer be usable.
        [<Config.Form>]ExpiresAt: DateTime option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(?create: bool, ?expiresAt: DateTime, ?metadata: Map<string, string>) =
            {
                Create = create
                ExpiresAt = expiresAt
                Metadata = metadata
            }

    type Create'Purpose =
    | AccountRequirement
    | AdditionalVerification
    | BusinessIcon
    | BusinessLogo
    | CustomerSignature
    | DisputeEvidence
    | IdentityDocument
    | PciDocument
    | TaxDocumentUserUpload
    | TerminalReaderSplashscreen

    type CreateOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A file to upload. The file should follow the specifications of RFC 2388 (which defines file transfers for the `multipart/form-data` protocol).
        [<Config.Form>]File: string
        ///Optional parameters to automatically create a [file link](https://stripe.com/docs/api#file_links) for the newly created file.
        [<Config.Form>]FileLinkData: Create'FileLinkData option
        ///The [purpose](https://stripe.com/docs/file-upload#uploading-a-file) of the uploaded file.
        [<Config.Form>]Purpose: Create'Purpose
    }
    with
        static member New(file: string, purpose: Create'Purpose, ?expand: string list, ?fileLinkData: Create'FileLinkData) =
            {
                Expand = expand
                File = file
                FileLinkData = fileLinkData
                Purpose = purpose
            }

    ///<p>To upload a file to Stripe, you’ll need to send a request of type <code>multipart/form-data</code>. The request should contain the file you would like to upload, as well as the parameters for creating a file.
    ///All of Stripe’s officially supported Client libraries should have support for sending <code>multipart/form-data</code>.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/files"
        |> RestApi.postAsync<_, File> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]File: string
    }
    with
        static member New(file: string, ?expand: string list) =
            {
                Expand = expand
                File = file
            }

    ///<p>Retrieves the details of an existing file object. Supply the unique file ID from a file, and Stripe will return the corresponding file object. To access file contents, see the <a href="/docs/file-upload#download-file-contents">File Upload Guide</a>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/files/{options.File}"
        |> RestApi.getAsync<File> settings qs

module Mandates =

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Mandate: string
    }
    with
        static member New(mandate: string, ?expand: string list) =
            {
                Expand = expand
                Mandate = mandate
            }

    ///<p>Retrieves a Mandate object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/mandates/{options.Mandate}"
        |> RestApi.getAsync<Mandate> settings qs

module PaymentIntents =

    type ListOptions = {
        ///A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
        [<Config.Query>]Created: int option
        ///Only return PaymentIntents for the customer specified by this customer ID.
        [<Config.Query>]Customer: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Created = created
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of PaymentIntents.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/payment_intents"
        |> RestApi.getAsync<PaymentIntent list> settings qs

    type Create'AutomaticPaymentMethodsAllowRedirects =
    | Always
    | Never

    type Create'AutomaticPaymentMethods = {
        ///Controls whether this PaymentIntent will accept redirect-based payment methods.
        ///Redirect-based payment methods may require your customer to be redirected to a payment method's app or site for authentication or additional steps. To [confirm](https://stripe.com/docs/api/payment_intents/confirm) this PaymentIntent, you may be required to provide a `return_url` to redirect customers back to your site after they authenticate or complete the payment.
        [<Config.Form>]AllowRedirects: Create'AutomaticPaymentMethodsAllowRedirects option
        ///Whether this feature is enabled.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?allowRedirects: Create'AutomaticPaymentMethodsAllowRedirects, ?enabled: bool) =
            {
                AllowRedirects = allowRedirects
                Enabled = enabled
            }

    type Create'MandateDataSecretKeyCustomerAcceptanceOnline = {
        ///The IP address from which the Mandate was accepted by the customer.
        [<Config.Form>]IpAddress: string option
        ///The user agent of the browser from which the Mandate was accepted by the customer.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type Create'MandateDataSecretKeyCustomerAcceptanceType =
    | Offline
    | Online

    type Create'MandateDataSecretKeyCustomerAcceptance = {
        ///The time at which the customer accepted the Mandate.
        [<Config.Form>]AcceptedAt: DateTime option
        ///If this is a Mandate accepted offline, this hash contains details about the offline acceptance.
        [<Config.Form>]Offline: string option
        ///If this is a Mandate accepted online, this hash contains details about the online acceptance.
        [<Config.Form>]Online: Create'MandateDataSecretKeyCustomerAcceptanceOnline option
        ///The type of customer acceptance information included with the Mandate. One of `online` or `offline`.
        [<Config.Form>]Type: Create'MandateDataSecretKeyCustomerAcceptanceType option
    }
    with
        static member New(?acceptedAt: DateTime, ?offline: string, ?online: Create'MandateDataSecretKeyCustomerAcceptanceOnline, ?type': Create'MandateDataSecretKeyCustomerAcceptanceType) =
            {
                AcceptedAt = acceptedAt
                Offline = offline
                Online = online
                Type = type'
            }

    type Create'MandateDataSecretKey = {
        ///This hash contains details about the customer acceptance of the Mandate.
        [<Config.Form>]CustomerAcceptance: Create'MandateDataSecretKeyCustomerAcceptance option
    }
    with
        static member New(?customerAcceptance: Create'MandateDataSecretKeyCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type Create'OffSession =
    | OneOff
    | Recurring

    type Create'PaymentMethodDataAcssDebit = {
        ///Customer's bank account number.
        [<Config.Form>]AccountNumber: string option
        ///Institution number of the customer's bank.
        [<Config.Form>]InstitutionNumber: string option
        ///Transit number of the customer's bank.
        [<Config.Form>]TransitNumber: string option
    }
    with
        static member New(?accountNumber: string, ?institutionNumber: string, ?transitNumber: string) =
            {
                AccountNumber = accountNumber
                InstitutionNumber = institutionNumber
                TransitNumber = transitNumber
            }

    type Create'PaymentMethodDataAuBecsDebit = {
        ///The account number for the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Bank-State-Branch number of the bank account.
        [<Config.Form>]BsbNumber: string option
    }
    with
        static member New(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type Create'PaymentMethodDataBacsDebit = {
        ///Account number of the bank account that the funds will be debited from.
        [<Config.Form>]AccountNumber: string option
        ///Sort code of the bank account. (e.g., `10-20-30`)
        [<Config.Form>]SortCode: string option
    }
    with
        static member New(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type Create'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PaymentMethodDataBillingDetails = {
        ///Billing address.
        [<Config.Form>]Address: Choice<Create'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
        ///Email address.
        [<Config.Form>]Email: Choice<string,string> option
        ///Full name.
        [<Config.Form>]Name: Choice<string,string> option
        ///Billing phone number (including extension).
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Choice<Create'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: Choice<string,string>, ?name: Choice<string,string>, ?phone: Choice<string,string>) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Create'PaymentMethodDataBoleto = {
        ///The tax ID of the customer (CPF for individual consumers or CNPJ for businesses consumers)
        [<Config.Form>]TaxId: string option
    }
    with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Create'PaymentMethodDataEpsBank =
    | ArzteUndApothekerBank
    | AustrianAnadiBankAg
    | BankAustria
    | BankhausCarlSpangler
    | BankhausSchelhammerUndSchatteraAg
    | BawagPskAg
    | BksBankAg
    | BrullKallmusBankAg
    | BtvVierLanderBank
    | CapitalBankGraweGruppeAg
    | DeutscheBankAg
    | Dolomitenbank
    | EasybankAg
    | ErsteBankUndSparkassen
    | HypoAlpeadriabankInternationalAg
    | HypoBankBurgenlandAktiengesellschaft
    | HypoNoeLbFurNiederosterreichUWien
    | HypoOberosterreichSalzburgSteiermark
    | HypoTirolBankAg
    | HypoVorarlbergBankAg
    | MarchfelderBank
    | OberbankAg
    | RaiffeisenBankengruppeOsterreich
    | SchoellerbankAg
    | SpardaBankWien
    | VolksbankGruppe
    | VolkskreditbankAg
    | VrBankBraunau

    type Create'PaymentMethodDataEps = {
        ///The customer's bank.
        [<Config.Form>]Bank: Create'PaymentMethodDataEpsBank option
    }
    with
        static member New(?bank: Create'PaymentMethodDataEpsBank) =
            {
                Bank = bank
            }

    type Create'PaymentMethodDataFpxAccountHolderType =
    | Company
    | Individual

    type Create'PaymentMethodDataFpxBank =
    | AffinBank
    | Agrobank
    | AllianceBank
    | Ambank
    | BankIslam
    | BankMuamalat
    | BankOfChina
    | BankRakyat
    | Bsn
    | Cimb
    | DeutscheBank
    | HongLeongBank
    | Hsbc
    | Kfh
    | Maybank2e
    | Maybank2u
    | Ocbc
    | PbEnterprise
    | PublicBank
    | Rhb
    | StandardChartered
    | Uob

    type Create'PaymentMethodDataFpx = {
        ///Account holder type for FPX transaction
        [<Config.Form>]AccountHolderType: Create'PaymentMethodDataFpxAccountHolderType option
        ///The customer's bank.
        [<Config.Form>]Bank: Create'PaymentMethodDataFpxBank option
    }
    with
        static member New(?accountHolderType: Create'PaymentMethodDataFpxAccountHolderType, ?bank: Create'PaymentMethodDataFpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type Create'PaymentMethodDataIdealBank =
    | AbnAmro
    | AsnBank
    | Bunq
    | Handelsbanken
    | Ing
    | Knab
    | Moneyou
    | Rabobank
    | Regiobank
    | Revolut
    | SnsBank
    | TriodosBank
    | VanLanschot
    | Yoursafe

    type Create'PaymentMethodDataIdeal = {
        ///The customer's bank.
        [<Config.Form>]Bank: Create'PaymentMethodDataIdealBank option
    }
    with
        static member New(?bank: Create'PaymentMethodDataIdealBank) =
            {
                Bank = bank
            }

    type Create'PaymentMethodDataKlarnaDob = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'PaymentMethodDataKlarna = {
        ///Customer's date of birth
        [<Config.Form>]Dob: Create'PaymentMethodDataKlarnaDob option
    }
    with
        static member New(?dob: Create'PaymentMethodDataKlarnaDob) =
            {
                Dob = dob
            }

    type Create'PaymentMethodDataP24Bank =
    | AliorBank
    | BankMillennium
    | BankNowyBfgSa
    | BankPekaoSa
    | BankiSpbdzielcze
    | Blik
    | BnpParibas
    | Boz
    | CitiHandlowy
    | CreditAgricole
    | Envelobank
    | EtransferPocztowy24
    | GetinBank
    | Ideabank
    | Ing
    | Inteligo
    | MbankMtransfer
    | NestPrzelew
    | NoblePay
    | PbacZIpko
    | PlusBank
    | SantanderPrzelew24
    | TmobileUsbugiBankowe
    | ToyotaBank
    | VolkswagenBank

    type Create'PaymentMethodDataP24 = {
        ///The customer's bank.
        [<Config.Form>]Bank: Create'PaymentMethodDataP24Bank option
    }
    with
        static member New(?bank: Create'PaymentMethodDataP24Bank) =
            {
                Bank = bank
            }

    type Create'PaymentMethodDataRadarOptions = {
        ///A [Radar Session](https://stripe.com/docs/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
        [<Config.Form>]Session: string option
    }
    with
        static member New(?session: string) =
            {
                Session = session
            }

    type Create'PaymentMethodDataSepaDebit = {
        ///IBAN of the bank account.
        [<Config.Form>]Iban: string option
    }
    with
        static member New(?iban: string) =
            {
                Iban = iban
            }

    type Create'PaymentMethodDataSofortCountry =
    | [<JsonUnionCase("AT")>] AT
    | [<JsonUnionCase("BE")>] BE
    | [<JsonUnionCase("DE")>] DE
    | [<JsonUnionCase("ES")>] ES
    | [<JsonUnionCase("IT")>] IT
    | [<JsonUnionCase("NL")>] NL

    type Create'PaymentMethodDataSofort = {
        ///Two-letter ISO code representing the country the bank account is located in.
        [<Config.Form>]Country: Create'PaymentMethodDataSofortCountry option
    }
    with
        static member New(?country: Create'PaymentMethodDataSofortCountry) =
            {
                Country = country
            }

    type Create'PaymentMethodDataUsBankAccountAccountHolderType =
    | Company
    | Individual

    type Create'PaymentMethodDataUsBankAccountAccountType =
    | Checking
    | Savings

    type Create'PaymentMethodDataUsBankAccount = {
        ///Account holder type: individual or company.
        [<Config.Form>]AccountHolderType: Create'PaymentMethodDataUsBankAccountAccountHolderType option
        ///Account number of the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Account type: checkings or savings. Defaults to checking if omitted.
        [<Config.Form>]AccountType: Create'PaymentMethodDataUsBankAccountAccountType option
        ///The ID of a Financial Connections Account to use as a payment method.
        [<Config.Form>]FinancialConnectionsAccount: string option
        ///Routing number of the bank account.
        [<Config.Form>]RoutingNumber: string option
    }
    with
        static member New(?accountHolderType: Create'PaymentMethodDataUsBankAccountAccountHolderType, ?accountNumber: string, ?accountType: Create'PaymentMethodDataUsBankAccountAccountType, ?financialConnectionsAccount: string, ?routingNumber: string) =
            {
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                FinancialConnectionsAccount = financialConnectionsAccount
                RoutingNumber = routingNumber
            }

    type Create'PaymentMethodDataType =
    | AcssDebit
    | Affirm
    | AfterpayClearpay
    | Alipay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Blik
    | Boleto
    | Cashapp
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Klarna
    | Konbini
    | Link
    | Oxxo
    | P24
    | Paynow
    | Paypal
    | Pix
    | Promptpay
    | SepaDebit
    | Sofort
    | UsBankAccount
    | WechatPay
    | Zip

    type Create'PaymentMethodData = {
        ///If this is an `acss_debit` PaymentMethod, this hash contains details about the ACSS Debit payment method.
        [<Config.Form>]AcssDebit: Create'PaymentMethodDataAcssDebit option
        ///If this is an `affirm` PaymentMethod, this hash contains details about the Affirm payment method.
        [<Config.Form>]Affirm: string option
        ///If this is an `AfterpayClearpay` PaymentMethod, this hash contains details about the AfterpayClearpay payment method.
        [<Config.Form>]AfterpayClearpay: string option
        ///If this is an `Alipay` PaymentMethod, this hash contains details about the Alipay payment method.
        [<Config.Form>]Alipay: string option
        ///If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
        [<Config.Form>]AuBecsDebit: Create'PaymentMethodDataAuBecsDebit option
        ///If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
        [<Config.Form>]BacsDebit: Create'PaymentMethodDataBacsDebit option
        ///If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
        [<Config.Form>]Bancontact: string option
        ///Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
        [<Config.Form>]BillingDetails: Create'PaymentMethodDataBillingDetails option
        ///If this is a `blik` PaymentMethod, this hash contains details about the BLIK payment method.
        [<Config.Form>]Blik: string option
        ///If this is a `boleto` PaymentMethod, this hash contains details about the Boleto payment method.
        [<Config.Form>]Boleto: Create'PaymentMethodDataBoleto option
        ///If this is a `cashapp` PaymentMethod, this hash contains details about the Cash App Pay payment method.
        [<Config.Form>]Cashapp: string option
        ///If this is a `customer_balance` PaymentMethod, this hash contains details about the CustomerBalance payment method.
        [<Config.Form>]CustomerBalance: string option
        ///If this is an `eps` PaymentMethod, this hash contains details about the EPS payment method.
        [<Config.Form>]Eps: Create'PaymentMethodDataEps option
        ///If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
        [<Config.Form>]Fpx: Create'PaymentMethodDataFpx option
        ///If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
        [<Config.Form>]Giropay: string option
        ///If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
        [<Config.Form>]Grabpay: string option
        ///If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
        [<Config.Form>]Ideal: Create'PaymentMethodDataIdeal option
        ///If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
        [<Config.Form>]InteracPresent: string option
        ///If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method.
        [<Config.Form>]Klarna: Create'PaymentMethodDataKlarna option
        ///If this is a `konbini` PaymentMethod, this hash contains details about the Konbini payment method.
        [<Config.Form>]Konbini: string option
        ///If this is an `Link` PaymentMethod, this hash contains details about the Link payment method.
        [<Config.Form>]Link: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
        [<Config.Form>]Oxxo: string option
        ///If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
        [<Config.Form>]P24: Create'PaymentMethodDataP24 option
        ///If this is a `paynow` PaymentMethod, this hash contains details about the PayNow payment method.
        [<Config.Form>]Paynow: string option
        ///If this is a `paypal` PaymentMethod, this hash contains details about the PayPal payment method.
        [<Config.Form>]Paypal: string option
        ///If this is a `pix` PaymentMethod, this hash contains details about the Pix payment method.
        [<Config.Form>]Pix: string option
        ///If this is a `promptpay` PaymentMethod, this hash contains details about the PromptPay payment method.
        [<Config.Form>]Promptpay: string option
        ///Options to configure Radar. See [Radar Session](https://stripe.com/docs/radar/radar-session) for more information.
        [<Config.Form>]RadarOptions: Create'PaymentMethodDataRadarOptions option
        ///If this is a `sepa_debit` PaymentMethod, this hash contains details about the SEPA debit bank account.
        [<Config.Form>]SepaDebit: Create'PaymentMethodDataSepaDebit option
        ///If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
        [<Config.Form>]Sofort: Create'PaymentMethodDataSofort option
        ///The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
        [<Config.Form>]Type: Create'PaymentMethodDataType option
        ///If this is an `us_bank_account` PaymentMethod, this hash contains details about the US bank account payment method.
        [<Config.Form>]UsBankAccount: Create'PaymentMethodDataUsBankAccount option
        ///If this is an `wechat_pay` PaymentMethod, this hash contains details about the wechat_pay payment method.
        [<Config.Form>]WechatPay: string option
        ///If this is a `zip` PaymentMethod, this hash contains details about the Zip payment method.
        [<Config.Form>]Zip: string option
    }
    with
        static member New(?acssDebit: Create'PaymentMethodDataAcssDebit, ?konbini: string, ?link: string, ?metadata: Map<string, string>, ?oxxo: string, ?p24: Create'PaymentMethodDataP24, ?paynow: string, ?klarna: Create'PaymentMethodDataKlarna, ?paypal: string, ?promptpay: string, ?radarOptions: Create'PaymentMethodDataRadarOptions, ?sepaDebit: Create'PaymentMethodDataSepaDebit, ?sofort: Create'PaymentMethodDataSofort, ?type': Create'PaymentMethodDataType, ?usBankAccount: Create'PaymentMethodDataUsBankAccount, ?pix: string, ?wechatPay: string, ?interacPresent: string, ?grabpay: string, ?affirm: string, ?afterpayClearpay: string, ?alipay: string, ?auBecsDebit: Create'PaymentMethodDataAuBecsDebit, ?bacsDebit: Create'PaymentMethodDataBacsDebit, ?bancontact: string, ?ideal: Create'PaymentMethodDataIdeal, ?billingDetails: Create'PaymentMethodDataBillingDetails, ?boleto: Create'PaymentMethodDataBoleto, ?cashapp: string, ?customerBalance: string, ?eps: Create'PaymentMethodDataEps, ?fpx: Create'PaymentMethodDataFpx, ?giropay: string, ?blik: string, ?zip: string) =
            {
                AcssDebit = acssDebit
                Affirm = affirm
                AfterpayClearpay = afterpayClearpay
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                BillingDetails = billingDetails
                Blik = blik
                Boleto = boleto
                Cashapp = cashapp
                CustomerBalance = customerBalance
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Klarna = klarna
                Konbini = konbini
                Link = link
                Metadata = metadata
                Oxxo = oxxo
                P24 = p24
                Paynow = paynow
                Paypal = paypal
                Pix = pix
                Promptpay = promptpay
                RadarOptions = radarOptions
                SepaDebit = sepaDebit
                Sofort = sofort
                Type = type'
                UsBankAccount = usBankAccount
                WechatPay = wechatPay
                Zip = zip
            }

    type Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsPaymentSchedule =
    | Combined
    | Interval
    | Sporadic

    type Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsTransactionType =
    | Business
    | Personal

    type Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptions = {
        ///A URL for custom mandate text to render during confirmation step.
        ///The URL will be rendered with additional GET parameters `payment_intent` and `payment_intent_client_secret` when confirming a Payment Intent,
        ///or `setup_intent` and `setup_intent_client_secret` when confirming a Setup Intent.
        [<Config.Form>]CustomMandateUrl: Choice<string,string> option
        ///Description of the mandate interval. Only required if 'payment_schedule' parameter is 'interval' or 'combined'.
        [<Config.Form>]IntervalDescription: string option
        ///Payment schedule for the mandate.
        [<Config.Form>]PaymentSchedule: Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsPaymentSchedule option
        ///Transaction type of the mandate.
        [<Config.Form>]TransactionType: Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsTransactionType option
    }
    with
        static member New(?customMandateUrl: Choice<string,string>, ?intervalDescription: string, ?paymentSchedule: Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsPaymentSchedule, ?transactionType: Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsTransactionType) =
            {
                CustomMandateUrl = customMandateUrl
                IntervalDescription = intervalDescription
                PaymentSchedule = paymentSchedule
                TransactionType = transactionType
            }

    type Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptions = {
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptions option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?mandateOptions: Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptions, ?setupFutureUsage: Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage, ?verificationMethod: Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsVerificationMethod) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
                VerificationMethod = verificationMethod
            }

    type Create'PaymentMethodOptionsAffirmPaymentMethodOptionsCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsAffirmPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsAffirmPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsAffirmPaymentMethodOptionsCaptureMethod option
        ///Preferred language of the Affirm authorization page that the customer is redirected to.
        [<Config.Form>]PreferredLocale: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAffirmPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsAffirmPaymentMethodOptionsCaptureMethod, ?preferredLocale: string, ?setupFutureUsage: Create'PaymentMethodOptionsAffirmPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PreferredLocale = preferredLocale
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsCaptureMethod option
        ///Order identifier shown to the customer in Afterpay’s online portal. We recommend using a value that helps you answer any questions a customer might have about
        ///the payment. The identifier is limited to 128 characters and may contain only letters, digits, underscores, backslashes and dashes.
        [<Config.Form>]Reference: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsCaptureMethod, ?reference: string, ?setupFutureUsage: Create'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                Reference = reference
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAlipayPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsAlipayPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAlipayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsAlipayPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsBacsDebitPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsBacsDebitPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsBacsDebitPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsBacsDebitPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Fr
    | Nl

    type Create'PaymentMethodOptionsBancontactPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsBancontactPaymentMethodOptions = {
        ///Preferred language of the Bancontact authorization page that the customer is redirected to.
        [<Config.Form>]PreferredLanguage: Create'PaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsBancontactPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?preferredLanguage: Create'PaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage, ?setupFutureUsage: Create'PaymentMethodOptionsBancontactPaymentMethodOptionsSetupFutureUsage) =
            {
                PreferredLanguage = preferredLanguage
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsBlikPaymentIntentPaymentMethodOptions = {
        ///The 6-digit BLIK code that a customer has generated using their banking application. Can only be set on confirmation.
        [<Config.Form>]Code: string option
    }
    with
        static member New(?code: string) =
            {
                Code = code
            }

    type Create'PaymentMethodOptionsBoletoPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsBoletoPaymentMethodOptions = {
        ///The number of calendar days before a Boleto voucher expires. For example, if you create a Boleto voucher on Monday and you set expires_after_days to 2, the Boleto invoice will expire on Wednesday at 23:59 America/Sao_Paulo time.
        [<Config.Form>]ExpiresAfterDays: int option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsBoletoPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Create'PaymentMethodOptionsBoletoPaymentMethodOptionsSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval =
    | Month

    type Create'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType =
    | FixedCount

    type Create'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan = {
        ///For `fixed_count` installment plans, this is the number of installment payments your customer will make to their credit card.
        [<Config.Form>]Count: int option
        ///For `fixed_count` installment plans, this is the interval between installment payments your customer will make to their credit card.
        ///One of `month`.
        [<Config.Form>]Interval: Create'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval option
        ///Type of installment plan, one of `fixed_count`.
        [<Config.Form>]Type: Create'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType option
    }
    with
        static member New(?count: int, ?interval: Create'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval, ?type': Create'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType) =
            {
                Count = count
                Interval = interval
                Type = type'
            }

    type Create'PaymentMethodOptionsCardPaymentIntentInstallments = {
        ///Setting to true enables installments for this PaymentIntent.
        ///This will cause the response to contain a list of available installment plans.
        ///Setting to false will prevent any selected plan from applying to a charge.
        [<Config.Form>]Enabled: bool option
        ///The selected installment plan to use for this payment attempt.
        ///This parameter can only be provided during confirmation.
        [<Config.Form>]Plan: Choice<Create'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string> option
    }
    with
        static member New(?enabled: bool, ?plan: Choice<Create'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string>) =
            {
                Enabled = enabled
                Plan = plan
            }

    type Create'PaymentMethodOptionsCardPaymentIntentMandateOptionsSupportedTypes =
    | India

    type Create'PaymentMethodOptionsCardPaymentIntentMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Create'PaymentMethodOptionsCardPaymentIntentMandateOptionsInterval =
    | Day
    | Month
    | Sporadic
    | Week
    | Year

    type Create'PaymentMethodOptionsCardPaymentIntentMandateOptions = {
        ///Amount to be charged for future payments.
        [<Config.Form>]Amount: int option
        ///One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
        [<Config.Form>]AmountType: Create'PaymentMethodOptionsCardPaymentIntentMandateOptionsAmountType option
        ///A description of the mandate or subscription that is meant to be displayed to the customer.
        [<Config.Form>]Description: string option
        ///End date of the mandate or subscription. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.
        [<Config.Form>]EndDate: DateTime option
        ///Specifies payment frequency. One of `day`, `week`, `month`, `year`, or `sporadic`.
        [<Config.Form>]Interval: Create'PaymentMethodOptionsCardPaymentIntentMandateOptionsInterval option
        ///The number of intervals between payments. For example, `interval=month` and `interval_count=3` indicates one payment every three months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks). This parameter is optional when `interval=sporadic`.
        [<Config.Form>]IntervalCount: int option
        ///Unique identifier for the mandate or subscription.
        [<Config.Form>]Reference: string option
        ///Start date of the mandate or subscription. Start date should not be lesser than yesterday.
        [<Config.Form>]StartDate: DateTime option
        ///Specifies the type of mandates supported. Possible values are `india`.
        [<Config.Form>]SupportedTypes: Create'PaymentMethodOptionsCardPaymentIntentMandateOptionsSupportedTypes list option
    }
    with
        static member New(?amount: int, ?amountType: Create'PaymentMethodOptionsCardPaymentIntentMandateOptionsAmountType, ?description: string, ?endDate: DateTime, ?interval: Create'PaymentMethodOptionsCardPaymentIntentMandateOptionsInterval, ?intervalCount: int, ?reference: string, ?startDate: DateTime, ?supportedTypes: Create'PaymentMethodOptionsCardPaymentIntentMandateOptionsSupportedTypes list) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
                Interval = interval
                IntervalCount = intervalCount
                Reference = reference
                StartDate = startDate
                SupportedTypes = supportedTypes
            }

    type Create'PaymentMethodOptionsCardPaymentIntentCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsCardPaymentIntentNetwork =
    | Amex
    | CartesBancaires
    | Diners
    | Discover
    | EftposAu
    | Interac
    | Jcb
    | Mastercard
    | Unionpay
    | Unknown
    | Visa

    type Create'PaymentMethodOptionsCardPaymentIntentRequestThreeDSecure =
    | Any
    | Automatic

    type Create'PaymentMethodOptionsCardPaymentIntentSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsCardPaymentIntent = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsCardPaymentIntentCaptureMethod option
        ///A single-use `cvc_update` Token that represents a card CVC value. When provided, the CVC value will be verified during the card payment attempt. This parameter can only be provided during confirmation.
        [<Config.Form>]CvcToken: string option
        ///Installment configuration for payments attempted on this PaymentIntent (Mexico Only).
        ///For more information, see the [installments integration guide](https://stripe.com/docs/payments/installments).
        [<Config.Form>]Installments: Create'PaymentMethodOptionsCardPaymentIntentInstallments option
        ///Configuration options for setting up an eMandate for cards issued in India.
        [<Config.Form>]MandateOptions: Create'PaymentMethodOptionsCardPaymentIntentMandateOptions option
        ///When specified, this parameter indicates that a transaction will be marked
        ///as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
        ///parameter can only be provided during confirmation.
        [<Config.Form>]Moto: bool option
        ///Selected network to process this PaymentIntent on. Depends on the available networks of the card attached to the PaymentIntent. Can be only set confirm-time.
        [<Config.Form>]Network: Create'PaymentMethodOptionsCardPaymentIntentNetwork option
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        [<Config.Form>]RequestThreeDSecure: Create'PaymentMethodOptionsCardPaymentIntentRequestThreeDSecure option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsCardPaymentIntentSetupFutureUsage option
        ///Provides information about a card payment that customers see on their statements. Concatenated with the Kana prefix (shortened Kana descriptor) or Kana statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 22 characters.
        [<Config.Form>]StatementDescriptorSuffixKana: Choice<string,string> option
        ///Provides information about a card payment that customers see on their statements. Concatenated with the Kanji prefix (shortened Kanji descriptor) or Kanji statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 17 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 17 characters.
        [<Config.Form>]StatementDescriptorSuffixKanji: Choice<string,string> option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsCardPaymentIntentCaptureMethod, ?cvcToken: string, ?installments: Create'PaymentMethodOptionsCardPaymentIntentInstallments, ?mandateOptions: Create'PaymentMethodOptionsCardPaymentIntentMandateOptions, ?moto: bool, ?network: Create'PaymentMethodOptionsCardPaymentIntentNetwork, ?requestThreeDSecure: Create'PaymentMethodOptionsCardPaymentIntentRequestThreeDSecure, ?setupFutureUsage: Create'PaymentMethodOptionsCardPaymentIntentSetupFutureUsage, ?statementDescriptorSuffixKana: Choice<string,string>, ?statementDescriptorSuffixKanji: Choice<string,string>) =
            {
                CaptureMethod = captureMethod
                CvcToken = cvcToken
                Installments = installments
                MandateOptions = mandateOptions
                Moto = moto
                Network = network
                RequestThreeDSecure = requestThreeDSecure
                SetupFutureUsage = setupFutureUsage
                StatementDescriptorSuffixKana = statementDescriptorSuffixKana
                StatementDescriptorSuffixKanji = statementDescriptorSuffixKanji
            }

    type Create'PaymentMethodOptionsCardPresentPaymentMethodOptions = {
        ///Request ability to capture this payment beyond the standard [authorization validity window](https://stripe.com/docs/terminal/features/extended-authorizations#authorization-validity)
        [<Config.Form>]RequestExtendedAuthorization: bool option
        ///Request ability to [increment](https://stripe.com/docs/terminal/features/incremental-authorizations) this PaymentIntent if the combination of MCC and card brand is eligible. Check [incremental_authorization_supported](https://stripe.com/docs/api/charges/object#charge_object-payment_method_details-card_present-incremental_authorization_supported) in the [Confirm](https://stripe.com/docs/api/payment_intents/confirm) response to verify support.
        [<Config.Form>]RequestIncrementalAuthorizationSupport: bool option
    }
    with
        static member New(?requestExtendedAuthorization: bool, ?requestIncrementalAuthorizationSupport: bool) =
            {
                RequestExtendedAuthorization = requestExtendedAuthorization
                RequestIncrementalAuthorizationSupport = requestIncrementalAuthorizationSupport
            }

    type Create'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsCaptureMethod option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsCaptureMethod, ?setupFutureUsage: Create'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferEuBankTransfer = {
        ///The desired country code of the bank account information. Permitted values include: `BE`, `DE`, `ES`, `FR`, `IE`, or `NL`.
        [<Config.Form>]Country: string option
    }
    with
        static member New(?country: string) =
            {
                Country = country
            }

    type Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferRequestedAddressTypes =
    | Aba
    | Iban
    | Sepa
    | SortCode
    | Spei
    | Swift
    | Zengin

    type Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferType =
    | EuBankTransfer
    | GbBankTransfer
    | JpBankTransfer
    | MxBankTransfer
    | UsBankTransfer

    type Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransfer = {
        ///Configuration for the eu_bank_transfer funding type.
        [<Config.Form>]EuBankTransfer: Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferEuBankTransfer option
        ///List of address types that should be returned in the financial_addresses response. If not specified, all valid types will be returned.
        ///Permitted values include: `sort_code`, `zengin`, `iban`, or `spei`.
        [<Config.Form>]RequestedAddressTypes: Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferRequestedAddressTypes list option
        ///The list of bank transfer types that this PaymentIntent is allowed to use for funding Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.
        [<Config.Form>]Type: Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferType option
    }
    with
        static member New(?euBankTransfer: Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferEuBankTransfer, ?requestedAddressTypes: Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferRequestedAddressTypes list, ?type': Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferType) =
            {
                EuBankTransfer = euBankTransfer
                RequestedAddressTypes = requestedAddressTypes
                Type = type'
            }

    type Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsFundingType =
    | BankTransfer

    type Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptions = {
        ///Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.
        [<Config.Form>]BankTransfer: Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransfer option
        ///The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
        [<Config.Form>]FundingType: Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsFundingType option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?bankTransfer: Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransfer, ?fundingType: Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsFundingType, ?setupFutureUsage: Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsFpxPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsFpxPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsFpxPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsFpxPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsGiropayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsGiropayPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsGiropayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsGiropayPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsGrabpayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsGrabpayPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsGrabpayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsGrabpayPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsIdealPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsIdealPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsIdealPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsIdealPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsKlarnaPaymentMethodOptionsCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsKlarnaPaymentMethodOptionsPreferredLocale =
    | [<JsonUnionCase("cs-CZ")>] CsCZ
    | [<JsonUnionCase("da-DK")>] DaDK
    | [<JsonUnionCase("de-AT")>] DeAT
    | [<JsonUnionCase("de-CH")>] DeCH
    | [<JsonUnionCase("de-DE")>] DeDE
    | [<JsonUnionCase("el-GR")>] ElGR
    | [<JsonUnionCase("en-AT")>] EnAT
    | [<JsonUnionCase("en-AU")>] EnAU
    | [<JsonUnionCase("en-BE")>] EnBE
    | [<JsonUnionCase("en-CA")>] EnCA
    | [<JsonUnionCase("en-CH")>] EnCH
    | [<JsonUnionCase("en-CZ")>] EnCZ
    | [<JsonUnionCase("en-DE")>] EnDE
    | [<JsonUnionCase("en-DK")>] EnDK
    | [<JsonUnionCase("en-ES")>] EnES
    | [<JsonUnionCase("en-FI")>] EnFI
    | [<JsonUnionCase("en-FR")>] EnFR
    | [<JsonUnionCase("en-GB")>] EnGB
    | [<JsonUnionCase("en-GR")>] EnGR
    | [<JsonUnionCase("en-IE")>] EnIE
    | [<JsonUnionCase("en-IT")>] EnIT
    | [<JsonUnionCase("en-NL")>] EnNL
    | [<JsonUnionCase("en-NO")>] EnNO
    | [<JsonUnionCase("en-NZ")>] EnNZ
    | [<JsonUnionCase("en-PL")>] EnPL
    | [<JsonUnionCase("en-PT")>] EnPT
    | [<JsonUnionCase("en-SE")>] EnSE
    | [<JsonUnionCase("en-US")>] EnUS
    | [<JsonUnionCase("es-ES")>] EsES
    | [<JsonUnionCase("es-US")>] EsUS
    | [<JsonUnionCase("fi-FI")>] FiFI
    | [<JsonUnionCase("fr-BE")>] FrBE
    | [<JsonUnionCase("fr-CA")>] FrCA
    | [<JsonUnionCase("fr-CH")>] FrCH
    | [<JsonUnionCase("fr-FR")>] FrFR
    | [<JsonUnionCase("it-CH")>] ItCH
    | [<JsonUnionCase("it-IT")>] ItIT
    | [<JsonUnionCase("nb-NO")>] NbNO
    | [<JsonUnionCase("nl-BE")>] NlBE
    | [<JsonUnionCase("nl-NL")>] NlNL
    | [<JsonUnionCase("pl-PL")>] PlPL
    | [<JsonUnionCase("pt-PT")>] PtPT
    | [<JsonUnionCase("sv-FI")>] SvFI
    | [<JsonUnionCase("sv-SE")>] SvSE

    type Create'PaymentMethodOptionsKlarnaPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsKlarnaPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsKlarnaPaymentMethodOptionsCaptureMethod option
        ///Preferred language of the Klarna authorization page that the customer is redirected to
        [<Config.Form>]PreferredLocale: Create'PaymentMethodOptionsKlarnaPaymentMethodOptionsPreferredLocale option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsKlarnaPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsKlarnaPaymentMethodOptionsCaptureMethod, ?preferredLocale: Create'PaymentMethodOptionsKlarnaPaymentMethodOptionsPreferredLocale, ?setupFutureUsage: Create'PaymentMethodOptionsKlarnaPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PreferredLocale = preferredLocale
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsKonbiniPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsKonbiniPaymentMethodOptions = {
        ///An optional 10 to 11 digit numeric-only string determining the confirmation code at applicable convenience stores. Must not consist of only zeroes and could be rejected in case of insufficient uniqueness. We recommend to use the customer's phone number.
        [<Config.Form>]ConfirmationNumber: Choice<string,string> option
        ///The number of calendar days (between 1 and 60) after which Konbini payment instructions will expire. For example, if a PaymentIntent is confirmed with Konbini and `expires_after_days` set to 2 on Monday JST, the instructions will expire on Wednesday 23:59:59 JST. Defaults to 3 days.
        [<Config.Form>]ExpiresAfterDays: Choice<int,string> option
        ///The timestamp at which the Konbini payment instructions will expire. Only one of `expires_after_days` or `expires_at` may be set.
        [<Config.Form>]ExpiresAt: Choice<DateTime,string> option
        ///A product descriptor of up to 22 characters, which will appear to customers at the convenience store.
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsKonbiniPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?confirmationNumber: Choice<string,string>, ?expiresAfterDays: Choice<int,string>, ?expiresAt: Choice<DateTime,string>, ?productDescription: Choice<string,string>, ?setupFutureUsage: Create'PaymentMethodOptionsKonbiniPaymentMethodOptionsSetupFutureUsage) =
            {
                ConfirmationNumber = confirmationNumber
                ExpiresAfterDays = expiresAfterDays
                ExpiresAt = expiresAt
                ProductDescription = productDescription
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsCaptureMethod option
        ///[Deprecated] This is a legacy parameter that no longer has any function.
        [<Config.Form>]PersistentToken: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsCaptureMethod, ?persistentToken: string, ?setupFutureUsage: Create'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PersistentToken = persistentToken
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsOxxoPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsOxxoPaymentMethodOptions = {
        ///The number of calendar days before an OXXO voucher expires. For example, if you create an OXXO voucher on Monday and you set expires_after_days to 2, the OXXO invoice will expire on Wednesday at 23:59 America/Mexico_City time.
        [<Config.Form>]ExpiresAfterDays: int option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsOxxoPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Create'PaymentMethodOptionsOxxoPaymentMethodOptionsSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsP24PaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsP24PaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsP24PaymentMethodOptionsSetupFutureUsage option
        ///Confirm that the payer has accepted the P24 terms and conditions.
        [<Config.Form>]TosShownAndAccepted: bool option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsP24PaymentMethodOptionsSetupFutureUsage, ?tosShownAndAccepted: bool) =
            {
                SetupFutureUsage = setupFutureUsage
                TosShownAndAccepted = tosShownAndAccepted
            }

    type Create'PaymentMethodOptionsPaynowPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsPaynowPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsPaynowPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsPaynowPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsPaypalPaymentMethodOptionsCaptureMethod =
    | Manual

    type Create'PaymentMethodOptionsPaypalPaymentMethodOptionsPreferredLocale =
    | [<JsonUnionCase("cs-CZ")>] CsCZ
    | [<JsonUnionCase("da-DK")>] DaDK
    | [<JsonUnionCase("de-AT")>] DeAT
    | [<JsonUnionCase("de-DE")>] DeDE
    | [<JsonUnionCase("de-LU")>] DeLU
    | [<JsonUnionCase("el-GR")>] ElGR
    | [<JsonUnionCase("en-GB")>] EnGB
    | [<JsonUnionCase("en-US")>] EnUS
    | [<JsonUnionCase("es-ES")>] EsES
    | [<JsonUnionCase("fi-FI")>] FiFI
    | [<JsonUnionCase("fr-BE")>] FrBE
    | [<JsonUnionCase("fr-FR")>] FrFR
    | [<JsonUnionCase("fr-LU")>] FrLU
    | [<JsonUnionCase("hu-HU")>] HuHU
    | [<JsonUnionCase("it-IT")>] ItIT
    | [<JsonUnionCase("nl-BE")>] NlBE
    | [<JsonUnionCase("nl-NL")>] NlNL
    | [<JsonUnionCase("pl-PL")>] PlPL
    | [<JsonUnionCase("pt-PT")>] PtPT
    | [<JsonUnionCase("sk-SK")>] SkSK
    | [<JsonUnionCase("sv-SE")>] SvSE

    type Create'PaymentMethodOptionsPaypalPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsPaypalPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        [<Config.Form>]CaptureMethod: Create'PaymentMethodOptionsPaypalPaymentMethodOptionsCaptureMethod option
        ///[Preferred locale](https://stripe.com/docs/payments/paypal/supported-locales) of the PayPal checkout page that the customer is redirected to.
        [<Config.Form>]PreferredLocale: Create'PaymentMethodOptionsPaypalPaymentMethodOptionsPreferredLocale option
        ///A reference of the PayPal transaction visible to customer which is mapped to PayPal's invoice ID. This must be a globally unique ID if you have configured in your PayPal settings to block multiple payments per invoice ID.
        [<Config.Form>]Reference: string option
        ///The risk correlation ID for an on-session payment using a saved PayPal payment method.
        [<Config.Form>]RiskCorrelationId: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsPaypalPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Create'PaymentMethodOptionsPaypalPaymentMethodOptionsCaptureMethod, ?preferredLocale: Create'PaymentMethodOptionsPaypalPaymentMethodOptionsPreferredLocale, ?reference: string, ?riskCorrelationId: string, ?setupFutureUsage: Create'PaymentMethodOptionsPaypalPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PreferredLocale = preferredLocale
                Reference = reference
                RiskCorrelationId = riskCorrelationId
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsPixPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsPixPaymentMethodOptions = {
        ///The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.
        [<Config.Form>]ExpiresAfterSeconds: int option
        ///The timestamp at which the Pix expires (between 10 and 1209600 seconds in the future). Defaults to 1 day in the future.
        [<Config.Form>]ExpiresAt: DateTime option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsPixPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?expiresAfterSeconds: int, ?expiresAt: DateTime, ?setupFutureUsage: Create'PaymentMethodOptionsPixPaymentMethodOptionsSetupFutureUsage) =
            {
                ExpiresAfterSeconds = expiresAfterSeconds
                ExpiresAt = expiresAt
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsPromptpayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsPromptpayPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsPromptpayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsPromptpayPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions = {
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?mandateOptions: string, ?setupFutureUsage: Create'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Es
    | Fr
    | It
    | Nl
    | Pl

    type Create'PaymentMethodOptionsSofortPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Create'PaymentMethodOptionsSofortPaymentMethodOptions = {
        ///Language shown to the payer on redirect.
        [<Config.Form>]PreferredLanguage: Create'PaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsSofortPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?preferredLanguage: Create'PaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage, ?setupFutureUsage: Create'PaymentMethodOptionsSofortPaymentMethodOptionsSetupFutureUsage) =
            {
                PreferredLanguage = preferredLanguage
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPrefetch =
    | Balances

    type Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnections = {
        ///The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
        [<Config.Form>]Permissions: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPermissions list option
        ///List of data features that you would like to retrieve upon account creation.
        [<Config.Form>]Prefetch: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPrefetch list option
        ///For webview integrations only. Upon completing OAuth login in the native browser, the user will be redirected to this URL to return to your app.
        [<Config.Form>]ReturnUrl: string option
    }
    with
        static member New(?permissions: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPermissions list, ?prefetch: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPrefetch list, ?returnUrl: string) =
            {
                Permissions = permissions
                Prefetch = prefetch
                ReturnUrl = returnUrl
            }

    type Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworksRequested =
    | Ach
    | UsDomesticWire

    type Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworks = {
        ///Triggers validations to run across the selected networks
        [<Config.Form>]Requested: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworksRequested list option
    }
    with
        static member New(?requested: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworksRequested list) =
            {
                Requested = requested
            }

    type Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsPreferredSettlementSpeed =
    | Fastest
    | Standard

    type Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptions = {
        ///Additional fields for Financial Connections Session creation
        [<Config.Form>]FinancialConnections: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnections option
        ///Additional fields for network related functions
        [<Config.Form>]Networks: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworks option
        ///Preferred transaction settlement speed
        [<Config.Form>]PreferredSettlementSpeed: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsPreferredSettlementSpeed option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsSetupFutureUsage option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?financialConnections: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnections, ?networks: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworks, ?preferredSettlementSpeed: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsPreferredSettlementSpeed, ?setupFutureUsage: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsSetupFutureUsage, ?verificationMethod: Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsVerificationMethod) =
            {
                FinancialConnections = financialConnections
                Networks = networks
                PreferredSettlementSpeed = preferredSettlementSpeed
                SetupFutureUsage = setupFutureUsage
                VerificationMethod = verificationMethod
            }

    type Create'PaymentMethodOptionsWechatPayPaymentMethodOptionsClient =
    | Android
    | Ios
    | Web

    type Create'PaymentMethodOptionsWechatPayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsWechatPayPaymentMethodOptions = {
        ///The app ID registered with WeChat Pay. Only required when client is ios or android.
        [<Config.Form>]AppId: string option
        ///The client type that the end customer will pay from
        [<Config.Form>]Client: Create'PaymentMethodOptionsWechatPayPaymentMethodOptionsClient option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsWechatPayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?appId: string, ?client: Create'PaymentMethodOptionsWechatPayPaymentMethodOptionsClient, ?setupFutureUsage: Create'PaymentMethodOptionsWechatPayPaymentMethodOptionsSetupFutureUsage) =
            {
                AppId = appId
                Client = client
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptionsZipPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Create'PaymentMethodOptionsZipPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Create'PaymentMethodOptionsZipPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Create'PaymentMethodOptionsZipPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Create'PaymentMethodOptions = {
        ///If this is a `acss_debit` PaymentMethod, this sub-hash contains details about the ACSS Debit payment method options.
        [<Config.Form>]AcssDebit: Choice<Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptions,string> option
        ///If this is an `affirm` PaymentMethod, this sub-hash contains details about the Affirm payment method options.
        [<Config.Form>]Affirm: Choice<Create'PaymentMethodOptionsAffirmPaymentMethodOptions,string> option
        ///If this is a `afterpay_clearpay` PaymentMethod, this sub-hash contains details about the Afterpay Clearpay payment method options.
        [<Config.Form>]AfterpayClearpay: Choice<Create'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptions,string> option
        ///If this is a `alipay` PaymentMethod, this sub-hash contains details about the Alipay payment method options.
        [<Config.Form>]Alipay: Choice<Create'PaymentMethodOptionsAlipayPaymentMethodOptions,string> option
        ///If this is a `au_becs_debit` PaymentMethod, this sub-hash contains details about the AU BECS Direct Debit payment method options.
        [<Config.Form>]AuBecsDebit: Choice<Create'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `bacs_debit` PaymentMethod, this sub-hash contains details about the BACS Debit payment method options.
        [<Config.Form>]BacsDebit: Choice<Create'PaymentMethodOptionsBacsDebitPaymentMethodOptions,string> option
        ///If this is a `bancontact` PaymentMethod, this sub-hash contains details about the Bancontact payment method options.
        [<Config.Form>]Bancontact: Choice<Create'PaymentMethodOptionsBancontactPaymentMethodOptions,string> option
        ///If this is a `blik` PaymentMethod, this sub-hash contains details about the BLIK payment method options.
        [<Config.Form>]Blik: Choice<Create'PaymentMethodOptionsBlikPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `boleto` PaymentMethod, this sub-hash contains details about the Boleto payment method options.
        [<Config.Form>]Boleto: Choice<Create'PaymentMethodOptionsBoletoPaymentMethodOptions,string> option
        ///Configuration for any card payments attempted on this PaymentIntent.
        [<Config.Form>]Card: Choice<Create'PaymentMethodOptionsCardPaymentIntent,string> option
        ///If this is a `card_present` PaymentMethod, this sub-hash contains details about the Card Present payment method options.
        [<Config.Form>]CardPresent: Choice<Create'PaymentMethodOptionsCardPresentPaymentMethodOptions,string> option
        ///If this is a `cashapp` PaymentMethod, this sub-hash contains details about the Cash App Pay payment method options.
        [<Config.Form>]Cashapp: Choice<Create'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `customer balance` PaymentMethod, this sub-hash contains details about the customer balance payment method options.
        [<Config.Form>]CustomerBalance: Choice<Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptions,string> option
        ///If this is a `eps` PaymentMethod, this sub-hash contains details about the EPS payment method options.
        [<Config.Form>]Eps: Choice<Create'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `fpx` PaymentMethod, this sub-hash contains details about the FPX payment method options.
        [<Config.Form>]Fpx: Choice<Create'PaymentMethodOptionsFpxPaymentMethodOptions,string> option
        ///If this is a `giropay` PaymentMethod, this sub-hash contains details about the Giropay payment method options.
        [<Config.Form>]Giropay: Choice<Create'PaymentMethodOptionsGiropayPaymentMethodOptions,string> option
        ///If this is a `grabpay` PaymentMethod, this sub-hash contains details about the Grabpay payment method options.
        [<Config.Form>]Grabpay: Choice<Create'PaymentMethodOptionsGrabpayPaymentMethodOptions,string> option
        ///If this is a `ideal` PaymentMethod, this sub-hash contains details about the Ideal payment method options.
        [<Config.Form>]Ideal: Choice<Create'PaymentMethodOptionsIdealPaymentMethodOptions,string> option
        ///If this is a `interac_present` PaymentMethod, this sub-hash contains details about the Card Present payment method options.
        [<Config.Form>]InteracPresent: Choice<string,string> option
        ///If this is a `klarna` PaymentMethod, this sub-hash contains details about the Klarna payment method options.
        [<Config.Form>]Klarna: Choice<Create'PaymentMethodOptionsKlarnaPaymentMethodOptions,string> option
        ///If this is a `konbini` PaymentMethod, this sub-hash contains details about the Konbini payment method options.
        [<Config.Form>]Konbini: Choice<Create'PaymentMethodOptionsKonbiniPaymentMethodOptions,string> option
        ///If this is a `link` PaymentMethod, this sub-hash contains details about the Link payment method options.
        [<Config.Form>]Link: Choice<Create'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `oxxo` PaymentMethod, this sub-hash contains details about the OXXO payment method options.
        [<Config.Form>]Oxxo: Choice<Create'PaymentMethodOptionsOxxoPaymentMethodOptions,string> option
        ///If this is a `p24` PaymentMethod, this sub-hash contains details about the Przelewy24 payment method options.
        [<Config.Form>]P24: Choice<Create'PaymentMethodOptionsP24PaymentMethodOptions,string> option
        ///If this is a `paynow` PaymentMethod, this sub-hash contains details about the PayNow payment method options.
        [<Config.Form>]Paynow: Choice<Create'PaymentMethodOptionsPaynowPaymentMethodOptions,string> option
        ///If this is a `paypal` PaymentMethod, this sub-hash contains details about the PayPal payment method options.
        [<Config.Form>]Paypal: Choice<Create'PaymentMethodOptionsPaypalPaymentMethodOptions,string> option
        ///If this is a `pix` PaymentMethod, this sub-hash contains details about the Pix payment method options.
        [<Config.Form>]Pix: Choice<Create'PaymentMethodOptionsPixPaymentMethodOptions,string> option
        ///If this is a `promptpay` PaymentMethod, this sub-hash contains details about the PromptPay payment method options.
        [<Config.Form>]Promptpay: Choice<Create'PaymentMethodOptionsPromptpayPaymentMethodOptions,string> option
        ///If this is a `sepa_debit` PaymentIntent, this sub-hash contains details about the SEPA Debit payment method options.
        [<Config.Form>]SepaDebit: Choice<Create'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `sofort` PaymentMethod, this sub-hash contains details about the SOFORT payment method options.
        [<Config.Form>]Sofort: Choice<Create'PaymentMethodOptionsSofortPaymentMethodOptions,string> option
        ///If this is a `us_bank_account` PaymentMethod, this sub-hash contains details about the US bank account payment method options.
        [<Config.Form>]UsBankAccount: Choice<Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `wechat_pay` PaymentMethod, this sub-hash contains details about the WeChat Pay payment method options.
        [<Config.Form>]WechatPay: Choice<Create'PaymentMethodOptionsWechatPayPaymentMethodOptions,string> option
        ///If this is a `zip` PaymentMethod, this sub-hash contains details about the Zip payment method options.
        [<Config.Form>]Zip: Choice<Create'PaymentMethodOptionsZipPaymentMethodOptions,string> option
    }
    with
        static member New(?acssDebit: Choice<Create'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptions,string>, ?usBankAccount: Choice<Create'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptions,string>, ?sofort: Choice<Create'PaymentMethodOptionsSofortPaymentMethodOptions,string>, ?sepaDebit: Choice<Create'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string>, ?promptpay: Choice<Create'PaymentMethodOptionsPromptpayPaymentMethodOptions,string>, ?pix: Choice<Create'PaymentMethodOptionsPixPaymentMethodOptions,string>, ?paypal: Choice<Create'PaymentMethodOptionsPaypalPaymentMethodOptions,string>, ?paynow: Choice<Create'PaymentMethodOptionsPaynowPaymentMethodOptions,string>, ?p24: Choice<Create'PaymentMethodOptionsP24PaymentMethodOptions,string>, ?oxxo: Choice<Create'PaymentMethodOptionsOxxoPaymentMethodOptions,string>, ?link: Choice<Create'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptions,string>, ?konbini: Choice<Create'PaymentMethodOptionsKonbiniPaymentMethodOptions,string>, ?klarna: Choice<Create'PaymentMethodOptionsKlarnaPaymentMethodOptions,string>, ?interacPresent: Choice<string,string>, ?ideal: Choice<Create'PaymentMethodOptionsIdealPaymentMethodOptions,string>, ?wechatPay: Choice<Create'PaymentMethodOptionsWechatPayPaymentMethodOptions,string>, ?grabpay: Choice<Create'PaymentMethodOptionsGrabpayPaymentMethodOptions,string>, ?fpx: Choice<Create'PaymentMethodOptionsFpxPaymentMethodOptions,string>, ?eps: Choice<Create'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptions,string>, ?customerBalance: Choice<Create'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptions,string>, ?cashapp: Choice<Create'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptions,string>, ?cardPresent: Choice<Create'PaymentMethodOptionsCardPresentPaymentMethodOptions,string>, ?card: Choice<Create'PaymentMethodOptionsCardPaymentIntent,string>, ?boleto: Choice<Create'PaymentMethodOptionsBoletoPaymentMethodOptions,string>, ?blik: Choice<Create'PaymentMethodOptionsBlikPaymentIntentPaymentMethodOptions,string>, ?bancontact: Choice<Create'PaymentMethodOptionsBancontactPaymentMethodOptions,string>, ?bacsDebit: Choice<Create'PaymentMethodOptionsBacsDebitPaymentMethodOptions,string>, ?auBecsDebit: Choice<Create'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptions,string>, ?alipay: Choice<Create'PaymentMethodOptionsAlipayPaymentMethodOptions,string>, ?afterpayClearpay: Choice<Create'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptions,string>, ?affirm: Choice<Create'PaymentMethodOptionsAffirmPaymentMethodOptions,string>, ?giropay: Choice<Create'PaymentMethodOptionsGiropayPaymentMethodOptions,string>, ?zip: Choice<Create'PaymentMethodOptionsZipPaymentMethodOptions,string>) =
            {
                AcssDebit = acssDebit
                Affirm = affirm
                AfterpayClearpay = afterpayClearpay
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                Blik = blik
                Boleto = boleto
                Card = card
                CardPresent = cardPresent
                Cashapp = cashapp
                CustomerBalance = customerBalance
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Klarna = klarna
                Konbini = konbini
                Link = link
                Oxxo = oxxo
                P24 = p24
                Paynow = paynow
                Paypal = paypal
                Pix = pix
                Promptpay = promptpay
                SepaDebit = sepaDebit
                Sofort = sofort
                UsBankAccount = usBankAccount
                WechatPay = wechatPay
                Zip = zip
            }

    type Create'RadarOptions = {
        ///A [Radar Session](https://stripe.com/docs/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
        [<Config.Form>]Session: string option
    }
    with
        static member New(?session: string) =
            {
                Session = session
            }

    type Create'ShippingAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'Shipping = {
        ///Shipping address.
        [<Config.Form>]Address: Create'ShippingAddress option
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        [<Config.Form>]Carrier: string option
        ///Recipient name.
        [<Config.Form>]Name: string option
        ///Recipient phone (including extension).
        [<Config.Form>]Phone: string option
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        [<Config.Form>]TrackingNumber: string option
    }
    with
        static member New(?address: Create'ShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type Create'TransferData = {
        ///The amount that will be transferred automatically when a charge succeeds.
        ///The amount is capped at the total transaction amount and if no amount is set,
        ///the full amount is transferred.
        ///If you intend to collect a fee and you need a more robust reporting experience, using
        ///[application_fee_amount](https://stripe.com/docs/api/payment_intents/create#create_payment_intent-application_fee_amount)
        ///might be a better fit for your integration.
        [<Config.Form>]Amount: int option
        ///If specified, successful charges will be attributed to the destination
        ///account for tax reporting, and the funds from charges will be transferred
        ///to the destination account. The ID of the resulting transfer will be
        ///returned on the successful charge's `transfer` field.
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type Create'CaptureMethod =
    | Automatic
    | AutomaticAsync
    | Manual

    type Create'ConfirmationMethod =
    | Automatic
    | Manual

    type Create'SetupFutureUsage =
    | OffSession
    | OnSession

    type CreateOptions = {
        ///Amount intended to be collected by this PaymentIntent. A positive integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://stripe.com/docs/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        [<Config.Form>]Amount: int
        ///The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. The amount of the application fee collected will be capped at the total payment amount. For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        [<Config.Form>]ApplicationFeeAmount: int option
        ///When enabled, this PaymentIntent will accept payment methods that you have enabled in the Dashboard and are compatible with this PaymentIntent's other parameters.
        [<Config.Form>]AutomaticPaymentMethods: Create'AutomaticPaymentMethods option
        ///Controls when the funds will be captured from the customer's account.
        [<Config.Form>]CaptureMethod: Create'CaptureMethod option
        ///Set to `true` to attempt to [confirm](https://stripe.com/docs/api/payment_intents/confirm) this PaymentIntent immediately. This parameter defaults to `false`. When creating and confirming a PaymentIntent at the same time, parameters available in the [confirm](https://stripe.com/docs/api/payment_intents/confirm) API may also be provided.
        [<Config.Form>]Confirm: bool option
        [<Config.Form>]ConfirmationMethod: Create'ConfirmationMethod option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string
        ///ID of the Customer this PaymentIntent belongs to, if one exists.
        ///Payment methods attached to other Customers cannot be used with this PaymentIntent.
        ///If present in combination with [setup_future_usage](https://stripe.com/docs/api#payment_intent_object-setup_future_usage), this PaymentIntent's payment method will be attached to the Customer after the PaymentIntent has been confirmed and any required actions from the user are complete.
        [<Config.Form>]Customer: string option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Set to `true` to fail the payment attempt if the PaymentIntent transitions into `requires_action`. This parameter is intended for simpler integrations that do not handle customer actions, like [saving cards without authentication](https://stripe.com/docs/payments/save-card-without-authentication). This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/payment_intents/create#create_payment_intent-confirm).
        [<Config.Form>]ErrorOnRequiresAction: bool option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///ID of the mandate to be used for this payment. This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/payment_intents/create#create_payment_intent-confirm).
        [<Config.Form>]Mandate: string option
        ///This hash contains details about the Mandate to create. This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/payment_intents/create#create_payment_intent-confirm).
        [<Config.Form>]MandateData: Choice<Create'MandateDataSecretKey,string> option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Set to `true` to indicate that the customer is not in your checkout flow during this payment attempt, and therefore is unable to authenticate. This parameter is intended for scenarios where you collect card details and [charge them later](https://stripe.com/docs/payments/cards/charging-saved-cards). This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/payment_intents/create#create_payment_intent-confirm).
        [<Config.Form>]OffSession: Choice<bool,Create'OffSession> option
        ///The Stripe account ID for which these funds are intended. For details, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        [<Config.Form>]OnBehalfOf: string option
        ///ID of the payment method (a PaymentMethod, Card, or [compatible Source](https://stripe.com/docs/payments/payment-methods#compatibility) object) to attach to this PaymentIntent.
        ///If neither the `payment_method` parameter nor the `source` parameter are provided with `confirm=true`, `source` will be automatically populated with `customer.default_source` to improve the migration experience for users of the Charges API. We recommend that you explicitly provide the `payment_method` going forward.
        [<Config.Form>]PaymentMethod: string option
        ///If provided, this hash will be used to create a PaymentMethod. The new PaymentMethod will appear
        ///in the [payment_method](https://stripe.com/docs/api/payment_intents/object#payment_intent_object-payment_method)
        ///property on the PaymentIntent.
        [<Config.Form>]PaymentMethodData: Create'PaymentMethodData option
        ///Payment-method-specific configuration for this PaymentIntent.
        [<Config.Form>]PaymentMethodOptions: Create'PaymentMethodOptions option
        ///The list of payment method types (e.g. card) that this PaymentIntent is allowed to use. If this is not provided, defaults to ["card"]. Use automatic_payment_methods to manage payment methods from the [Stripe Dashboard](https://dashboard.stripe.com/settings/payment_methods).
        [<Config.Form>]PaymentMethodTypes: string list option
        ///Options to configure Radar. See [Radar Session](https://stripe.com/docs/radar/radar-session) for more information.
        [<Config.Form>]RadarOptions: Create'RadarOptions option
        ///Email address that the receipt for the resulting payment will be sent to. If `receipt_email` is specified for a payment in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).
        [<Config.Form>]ReceiptEmail: string option
        ///The URL to redirect your customer back to after they authenticate or cancel their payment on the payment method's app or site. If you'd prefer to redirect to a mobile application, you can alternatively supply an application URI scheme. This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/payment_intents/create#create_payment_intent-confirm).
        [<Config.Form>]ReturnUrl: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        [<Config.Form>]SetupFutureUsage: Create'SetupFutureUsage option
        ///Shipping information for this PaymentIntent.
        [<Config.Form>]Shipping: Create'Shipping option
        ///For non-card charges, you can use this value as the complete description that appears on your customers’ statements. Must contain at least one letter, maximum 22 characters.
        [<Config.Form>]StatementDescriptor: string option
        ///Provides information about a card payment that customers see on their statements. Concatenated with the prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters for the concatenated descriptor.
        [<Config.Form>]StatementDescriptorSuffix: string option
        ///The parameters used to automatically create a Transfer when the payment succeeds.
        ///For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        [<Config.Form>]TransferData: Create'TransferData option
        ///A string that identifies the resulting payment as part of a group. See the PaymentIntents [use case for connected accounts](https://stripe.com/docs/connect/separate-charges-and-transfers) for details.
        [<Config.Form>]TransferGroup: string option
        ///Set to `true` when confirming server-side and using Stripe.js, iOS, or Android client-side SDKs to handle the next actions.
        [<Config.Form>]UseStripeSdk: bool option
    }
    with
        static member New(amount: int, currency: string, ?transferData: Create'TransferData, ?statementDescriptorSuffix: string, ?statementDescriptor: string, ?shipping: Create'Shipping, ?setupFutureUsage: Create'SetupFutureUsage, ?returnUrl: string, ?receiptEmail: string, ?radarOptions: Create'RadarOptions, ?paymentMethodTypes: string list, ?paymentMethodOptions: Create'PaymentMethodOptions, ?paymentMethodData: Create'PaymentMethodData, ?paymentMethod: string, ?onBehalfOf: string, ?offSession: Choice<bool,Create'OffSession>, ?metadata: Map<string, string>, ?mandateData: Choice<Create'MandateDataSecretKey,string>, ?mandate: string, ?expand: string list, ?errorOnRequiresAction: bool, ?description: string, ?customer: string, ?confirmationMethod: Create'ConfirmationMethod, ?confirm: bool, ?captureMethod: Create'CaptureMethod, ?automaticPaymentMethods: Create'AutomaticPaymentMethods, ?applicationFeeAmount: int, ?transferGroup: string, ?useStripeSdk: bool) =
            {
                Amount = amount
                ApplicationFeeAmount = applicationFeeAmount
                AutomaticPaymentMethods = automaticPaymentMethods
                CaptureMethod = captureMethod
                Confirm = confirm
                ConfirmationMethod = confirmationMethod
                Currency = currency
                Customer = customer
                Description = description
                ErrorOnRequiresAction = errorOnRequiresAction
                Expand = expand
                Mandate = mandate
                MandateData = mandateData
                Metadata = metadata
                OffSession = offSession
                OnBehalfOf = onBehalfOf
                PaymentMethod = paymentMethod
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
                RadarOptions = radarOptions
                ReceiptEmail = receiptEmail
                ReturnUrl = returnUrl
                SetupFutureUsage = setupFutureUsage
                Shipping = shipping
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferData = transferData
                TransferGroup = transferGroup
                UseStripeSdk = useStripeSdk
            }

    ///<p>Creates a PaymentIntent object.
    ///After the PaymentIntent is created, attach a payment method and <a href="/docs/api/payment_intents/confirm">confirm</a>
    ///to continue the payment. You can read more about the different payment flows
    ///available via the Payment Intents API <a href="/docs/payments/payment-intents">here</a>.
    ///When <code>confirm=true</code> is used during creation, it is equivalent to creating
    ///and confirming the PaymentIntent in the same call. You may use any parameters
    ///available in the <a href="/docs/api/payment_intents/confirm">confirm API</a> when <code>confirm=true</code>
    ///is supplied.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/payment_intents"
        |> RestApi.postAsync<_, PaymentIntent> settings (Map.empty) options

    type RetrieveOptions = {
        ///The client secret of the PaymentIntent. Required if a publishable key is used to retrieve the source.
        [<Config.Query>]ClientSecret: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Intent: string
    }
    with
        static member New(intent: string, ?expand: string list, ?clientSecret: string) =
            {
                ClientSecret = clientSecret
                Expand = expand
                Intent = intent
            }

    ///<p>Retrieves the details of a PaymentIntent that has previously been created. 
    ///Client-side retrieval using a publishable key is allowed when the <code>client_secret</code> is provided in the query string. 
    ///When retrieved with a publishable key, only a subset of properties will be returned. Please refer to the <a href="#payment_intent_object">payment intent</a> object reference for more details.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("client_secret", options.ClientSecret |> box); ("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/payment_intents/{options.Intent}"
        |> RestApi.getAsync<PaymentIntent> settings qs

    type Update'PaymentMethodDataAcssDebit = {
        ///Customer's bank account number.
        [<Config.Form>]AccountNumber: string option
        ///Institution number of the customer's bank.
        [<Config.Form>]InstitutionNumber: string option
        ///Transit number of the customer's bank.
        [<Config.Form>]TransitNumber: string option
    }
    with
        static member New(?accountNumber: string, ?institutionNumber: string, ?transitNumber: string) =
            {
                AccountNumber = accountNumber
                InstitutionNumber = institutionNumber
                TransitNumber = transitNumber
            }

    type Update'PaymentMethodDataAuBecsDebit = {
        ///The account number for the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Bank-State-Branch number of the bank account.
        [<Config.Form>]BsbNumber: string option
    }
    with
        static member New(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type Update'PaymentMethodDataBacsDebit = {
        ///Account number of the bank account that the funds will be debited from.
        [<Config.Form>]AccountNumber: string option
        ///Sort code of the bank account. (e.g., `10-20-30`)
        [<Config.Form>]SortCode: string option
    }
    with
        static member New(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type Update'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'PaymentMethodDataBillingDetails = {
        ///Billing address.
        [<Config.Form>]Address: Choice<Update'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
        ///Email address.
        [<Config.Form>]Email: Choice<string,string> option
        ///Full name.
        [<Config.Form>]Name: Choice<string,string> option
        ///Billing phone number (including extension).
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Choice<Update'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: Choice<string,string>, ?name: Choice<string,string>, ?phone: Choice<string,string>) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Update'PaymentMethodDataBoleto = {
        ///The tax ID of the customer (CPF for individual consumers or CNPJ for businesses consumers)
        [<Config.Form>]TaxId: string option
    }
    with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Update'PaymentMethodDataEpsBank =
    | ArzteUndApothekerBank
    | AustrianAnadiBankAg
    | BankAustria
    | BankhausCarlSpangler
    | BankhausSchelhammerUndSchatteraAg
    | BawagPskAg
    | BksBankAg
    | BrullKallmusBankAg
    | BtvVierLanderBank
    | CapitalBankGraweGruppeAg
    | DeutscheBankAg
    | Dolomitenbank
    | EasybankAg
    | ErsteBankUndSparkassen
    | HypoAlpeadriabankInternationalAg
    | HypoBankBurgenlandAktiengesellschaft
    | HypoNoeLbFurNiederosterreichUWien
    | HypoOberosterreichSalzburgSteiermark
    | HypoTirolBankAg
    | HypoVorarlbergBankAg
    | MarchfelderBank
    | OberbankAg
    | RaiffeisenBankengruppeOsterreich
    | SchoellerbankAg
    | SpardaBankWien
    | VolksbankGruppe
    | VolkskreditbankAg
    | VrBankBraunau

    type Update'PaymentMethodDataEps = {
        ///The customer's bank.
        [<Config.Form>]Bank: Update'PaymentMethodDataEpsBank option
    }
    with
        static member New(?bank: Update'PaymentMethodDataEpsBank) =
            {
                Bank = bank
            }

    type Update'PaymentMethodDataFpxAccountHolderType =
    | Company
    | Individual

    type Update'PaymentMethodDataFpxBank =
    | AffinBank
    | Agrobank
    | AllianceBank
    | Ambank
    | BankIslam
    | BankMuamalat
    | BankOfChina
    | BankRakyat
    | Bsn
    | Cimb
    | DeutscheBank
    | HongLeongBank
    | Hsbc
    | Kfh
    | Maybank2e
    | Maybank2u
    | Ocbc
    | PbEnterprise
    | PublicBank
    | Rhb
    | StandardChartered
    | Uob

    type Update'PaymentMethodDataFpx = {
        ///Account holder type for FPX transaction
        [<Config.Form>]AccountHolderType: Update'PaymentMethodDataFpxAccountHolderType option
        ///The customer's bank.
        [<Config.Form>]Bank: Update'PaymentMethodDataFpxBank option
    }
    with
        static member New(?accountHolderType: Update'PaymentMethodDataFpxAccountHolderType, ?bank: Update'PaymentMethodDataFpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type Update'PaymentMethodDataIdealBank =
    | AbnAmro
    | AsnBank
    | Bunq
    | Handelsbanken
    | Ing
    | Knab
    | Moneyou
    | Rabobank
    | Regiobank
    | Revolut
    | SnsBank
    | TriodosBank
    | VanLanschot
    | Yoursafe

    type Update'PaymentMethodDataIdeal = {
        ///The customer's bank.
        [<Config.Form>]Bank: Update'PaymentMethodDataIdealBank option
    }
    with
        static member New(?bank: Update'PaymentMethodDataIdealBank) =
            {
                Bank = bank
            }

    type Update'PaymentMethodDataKlarnaDob = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Update'PaymentMethodDataKlarna = {
        ///Customer's date of birth
        [<Config.Form>]Dob: Update'PaymentMethodDataKlarnaDob option
    }
    with
        static member New(?dob: Update'PaymentMethodDataKlarnaDob) =
            {
                Dob = dob
            }

    type Update'PaymentMethodDataP24Bank =
    | AliorBank
    | BankMillennium
    | BankNowyBfgSa
    | BankPekaoSa
    | BankiSpbdzielcze
    | Blik
    | BnpParibas
    | Boz
    | CitiHandlowy
    | CreditAgricole
    | Envelobank
    | EtransferPocztowy24
    | GetinBank
    | Ideabank
    | Ing
    | Inteligo
    | MbankMtransfer
    | NestPrzelew
    | NoblePay
    | PbacZIpko
    | PlusBank
    | SantanderPrzelew24
    | TmobileUsbugiBankowe
    | ToyotaBank
    | VolkswagenBank

    type Update'PaymentMethodDataP24 = {
        ///The customer's bank.
        [<Config.Form>]Bank: Update'PaymentMethodDataP24Bank option
    }
    with
        static member New(?bank: Update'PaymentMethodDataP24Bank) =
            {
                Bank = bank
            }

    type Update'PaymentMethodDataRadarOptions = {
        ///A [Radar Session](https://stripe.com/docs/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
        [<Config.Form>]Session: string option
    }
    with
        static member New(?session: string) =
            {
                Session = session
            }

    type Update'PaymentMethodDataSepaDebit = {
        ///IBAN of the bank account.
        [<Config.Form>]Iban: string option
    }
    with
        static member New(?iban: string) =
            {
                Iban = iban
            }

    type Update'PaymentMethodDataSofortCountry =
    | [<JsonUnionCase("AT")>] AT
    | [<JsonUnionCase("BE")>] BE
    | [<JsonUnionCase("DE")>] DE
    | [<JsonUnionCase("ES")>] ES
    | [<JsonUnionCase("IT")>] IT
    | [<JsonUnionCase("NL")>] NL

    type Update'PaymentMethodDataSofort = {
        ///Two-letter ISO code representing the country the bank account is located in.
        [<Config.Form>]Country: Update'PaymentMethodDataSofortCountry option
    }
    with
        static member New(?country: Update'PaymentMethodDataSofortCountry) =
            {
                Country = country
            }

    type Update'PaymentMethodDataUsBankAccountAccountHolderType =
    | Company
    | Individual

    type Update'PaymentMethodDataUsBankAccountAccountType =
    | Checking
    | Savings

    type Update'PaymentMethodDataUsBankAccount = {
        ///Account holder type: individual or company.
        [<Config.Form>]AccountHolderType: Update'PaymentMethodDataUsBankAccountAccountHolderType option
        ///Account number of the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Account type: checkings or savings. Defaults to checking if omitted.
        [<Config.Form>]AccountType: Update'PaymentMethodDataUsBankAccountAccountType option
        ///The ID of a Financial Connections Account to use as a payment method.
        [<Config.Form>]FinancialConnectionsAccount: string option
        ///Routing number of the bank account.
        [<Config.Form>]RoutingNumber: string option
    }
    with
        static member New(?accountHolderType: Update'PaymentMethodDataUsBankAccountAccountHolderType, ?accountNumber: string, ?accountType: Update'PaymentMethodDataUsBankAccountAccountType, ?financialConnectionsAccount: string, ?routingNumber: string) =
            {
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                FinancialConnectionsAccount = financialConnectionsAccount
                RoutingNumber = routingNumber
            }

    type Update'PaymentMethodDataType =
    | AcssDebit
    | Affirm
    | AfterpayClearpay
    | Alipay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Blik
    | Boleto
    | Cashapp
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Klarna
    | Konbini
    | Link
    | Oxxo
    | P24
    | Paynow
    | Paypal
    | Pix
    | Promptpay
    | SepaDebit
    | Sofort
    | UsBankAccount
    | WechatPay
    | Zip

    type Update'PaymentMethodData = {
        ///If this is an `acss_debit` PaymentMethod, this hash contains details about the ACSS Debit payment method.
        [<Config.Form>]AcssDebit: Update'PaymentMethodDataAcssDebit option
        ///If this is an `affirm` PaymentMethod, this hash contains details about the Affirm payment method.
        [<Config.Form>]Affirm: string option
        ///If this is an `AfterpayClearpay` PaymentMethod, this hash contains details about the AfterpayClearpay payment method.
        [<Config.Form>]AfterpayClearpay: string option
        ///If this is an `Alipay` PaymentMethod, this hash contains details about the Alipay payment method.
        [<Config.Form>]Alipay: string option
        ///If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
        [<Config.Form>]AuBecsDebit: Update'PaymentMethodDataAuBecsDebit option
        ///If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
        [<Config.Form>]BacsDebit: Update'PaymentMethodDataBacsDebit option
        ///If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
        [<Config.Form>]Bancontact: string option
        ///Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
        [<Config.Form>]BillingDetails: Update'PaymentMethodDataBillingDetails option
        ///If this is a `blik` PaymentMethod, this hash contains details about the BLIK payment method.
        [<Config.Form>]Blik: string option
        ///If this is a `boleto` PaymentMethod, this hash contains details about the Boleto payment method.
        [<Config.Form>]Boleto: Update'PaymentMethodDataBoleto option
        ///If this is a `cashapp` PaymentMethod, this hash contains details about the Cash App Pay payment method.
        [<Config.Form>]Cashapp: string option
        ///If this is a `customer_balance` PaymentMethod, this hash contains details about the CustomerBalance payment method.
        [<Config.Form>]CustomerBalance: string option
        ///If this is an `eps` PaymentMethod, this hash contains details about the EPS payment method.
        [<Config.Form>]Eps: Update'PaymentMethodDataEps option
        ///If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
        [<Config.Form>]Fpx: Update'PaymentMethodDataFpx option
        ///If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
        [<Config.Form>]Giropay: string option
        ///If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
        [<Config.Form>]Grabpay: string option
        ///If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
        [<Config.Form>]Ideal: Update'PaymentMethodDataIdeal option
        ///If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
        [<Config.Form>]InteracPresent: string option
        ///If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method.
        [<Config.Form>]Klarna: Update'PaymentMethodDataKlarna option
        ///If this is a `konbini` PaymentMethod, this hash contains details about the Konbini payment method.
        [<Config.Form>]Konbini: string option
        ///If this is an `Link` PaymentMethod, this hash contains details about the Link payment method.
        [<Config.Form>]Link: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
        [<Config.Form>]Oxxo: string option
        ///If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
        [<Config.Form>]P24: Update'PaymentMethodDataP24 option
        ///If this is a `paynow` PaymentMethod, this hash contains details about the PayNow payment method.
        [<Config.Form>]Paynow: string option
        ///If this is a `paypal` PaymentMethod, this hash contains details about the PayPal payment method.
        [<Config.Form>]Paypal: string option
        ///If this is a `pix` PaymentMethod, this hash contains details about the Pix payment method.
        [<Config.Form>]Pix: string option
        ///If this is a `promptpay` PaymentMethod, this hash contains details about the PromptPay payment method.
        [<Config.Form>]Promptpay: string option
        ///Options to configure Radar. See [Radar Session](https://stripe.com/docs/radar/radar-session) for more information.
        [<Config.Form>]RadarOptions: Update'PaymentMethodDataRadarOptions option
        ///If this is a `sepa_debit` PaymentMethod, this hash contains details about the SEPA debit bank account.
        [<Config.Form>]SepaDebit: Update'PaymentMethodDataSepaDebit option
        ///If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
        [<Config.Form>]Sofort: Update'PaymentMethodDataSofort option
        ///The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
        [<Config.Form>]Type: Update'PaymentMethodDataType option
        ///If this is an `us_bank_account` PaymentMethod, this hash contains details about the US bank account payment method.
        [<Config.Form>]UsBankAccount: Update'PaymentMethodDataUsBankAccount option
        ///If this is an `wechat_pay` PaymentMethod, this hash contains details about the wechat_pay payment method.
        [<Config.Form>]WechatPay: string option
        ///If this is a `zip` PaymentMethod, this hash contains details about the Zip payment method.
        [<Config.Form>]Zip: string option
    }
    with
        static member New(?acssDebit: Update'PaymentMethodDataAcssDebit, ?konbini: string, ?link: string, ?metadata: Map<string, string>, ?oxxo: string, ?p24: Update'PaymentMethodDataP24, ?paynow: string, ?klarna: Update'PaymentMethodDataKlarna, ?paypal: string, ?promptpay: string, ?radarOptions: Update'PaymentMethodDataRadarOptions, ?sepaDebit: Update'PaymentMethodDataSepaDebit, ?sofort: Update'PaymentMethodDataSofort, ?type': Update'PaymentMethodDataType, ?usBankAccount: Update'PaymentMethodDataUsBankAccount, ?pix: string, ?wechatPay: string, ?interacPresent: string, ?grabpay: string, ?affirm: string, ?afterpayClearpay: string, ?alipay: string, ?auBecsDebit: Update'PaymentMethodDataAuBecsDebit, ?bacsDebit: Update'PaymentMethodDataBacsDebit, ?bancontact: string, ?ideal: Update'PaymentMethodDataIdeal, ?billingDetails: Update'PaymentMethodDataBillingDetails, ?boleto: Update'PaymentMethodDataBoleto, ?cashapp: string, ?customerBalance: string, ?eps: Update'PaymentMethodDataEps, ?fpx: Update'PaymentMethodDataFpx, ?giropay: string, ?blik: string, ?zip: string) =
            {
                AcssDebit = acssDebit
                Affirm = affirm
                AfterpayClearpay = afterpayClearpay
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                BillingDetails = billingDetails
                Blik = blik
                Boleto = boleto
                Cashapp = cashapp
                CustomerBalance = customerBalance
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Klarna = klarna
                Konbini = konbini
                Link = link
                Metadata = metadata
                Oxxo = oxxo
                P24 = p24
                Paynow = paynow
                Paypal = paypal
                Pix = pix
                Promptpay = promptpay
                RadarOptions = radarOptions
                SepaDebit = sepaDebit
                Sofort = sofort
                Type = type'
                UsBankAccount = usBankAccount
                WechatPay = wechatPay
                Zip = zip
            }

    type Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsPaymentSchedule =
    | Combined
    | Interval
    | Sporadic

    type Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsTransactionType =
    | Business
    | Personal

    type Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptions = {
        ///A URL for custom mandate text to render during confirmation step.
        ///The URL will be rendered with additional GET parameters `payment_intent` and `payment_intent_client_secret` when confirming a Payment Intent,
        ///or `setup_intent` and `setup_intent_client_secret` when confirming a Setup Intent.
        [<Config.Form>]CustomMandateUrl: Choice<string,string> option
        ///Description of the mandate interval. Only required if 'payment_schedule' parameter is 'interval' or 'combined'.
        [<Config.Form>]IntervalDescription: string option
        ///Payment schedule for the mandate.
        [<Config.Form>]PaymentSchedule: Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsPaymentSchedule option
        ///Transaction type of the mandate.
        [<Config.Form>]TransactionType: Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsTransactionType option
    }
    with
        static member New(?customMandateUrl: Choice<string,string>, ?intervalDescription: string, ?paymentSchedule: Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsPaymentSchedule, ?transactionType: Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsTransactionType) =
            {
                CustomMandateUrl = customMandateUrl
                IntervalDescription = intervalDescription
                PaymentSchedule = paymentSchedule
                TransactionType = transactionType
            }

    type Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptions = {
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptions option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?mandateOptions: Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptions, ?setupFutureUsage: Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage, ?verificationMethod: Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsVerificationMethod) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
                VerificationMethod = verificationMethod
            }

    type Update'PaymentMethodOptionsAffirmPaymentMethodOptionsCaptureMethod =
    | Manual

    type Update'PaymentMethodOptionsAffirmPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsAffirmPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Update'PaymentMethodOptionsAffirmPaymentMethodOptionsCaptureMethod option
        ///Preferred language of the Affirm authorization page that the customer is redirected to.
        [<Config.Form>]PreferredLocale: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsAffirmPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Update'PaymentMethodOptionsAffirmPaymentMethodOptionsCaptureMethod, ?preferredLocale: string, ?setupFutureUsage: Update'PaymentMethodOptionsAffirmPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PreferredLocale = preferredLocale
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsCaptureMethod =
    | Manual

    type Update'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Update'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsCaptureMethod option
        ///Order identifier shown to the customer in Afterpay’s online portal. We recommend using a value that helps you answer any questions a customer might have about
        ///the payment. The identifier is limited to 128 characters and may contain only letters, digits, underscores, backslashes and dashes.
        [<Config.Form>]Reference: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Update'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsCaptureMethod, ?reference: string, ?setupFutureUsage: Update'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                Reference = reference
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsAlipayPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Update'PaymentMethodOptionsAlipayPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsAlipayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Update'PaymentMethodOptionsAlipayPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Update'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Update'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsBacsDebitPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Update'PaymentMethodOptionsBacsDebitPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsBacsDebitPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Update'PaymentMethodOptionsBacsDebitPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Fr
    | Nl

    type Update'PaymentMethodOptionsBancontactPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Update'PaymentMethodOptionsBancontactPaymentMethodOptions = {
        ///Preferred language of the Bancontact authorization page that the customer is redirected to.
        [<Config.Form>]PreferredLanguage: Update'PaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsBancontactPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?preferredLanguage: Update'PaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage, ?setupFutureUsage: Update'PaymentMethodOptionsBancontactPaymentMethodOptionsSetupFutureUsage) =
            {
                PreferredLanguage = preferredLanguage
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsBlikPaymentIntentPaymentMethodOptions = {
        ///The 6-digit BLIK code that a customer has generated using their banking application. Can only be set on confirmation.
        [<Config.Form>]Code: string option
    }
    with
        static member New(?code: string) =
            {
                Code = code
            }

    type Update'PaymentMethodOptionsBoletoPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Update'PaymentMethodOptionsBoletoPaymentMethodOptions = {
        ///The number of calendar days before a Boleto voucher expires. For example, if you create a Boleto voucher on Monday and you set expires_after_days to 2, the Boleto invoice will expire on Wednesday at 23:59 America/Sao_Paulo time.
        [<Config.Form>]ExpiresAfterDays: int option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsBoletoPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Update'PaymentMethodOptionsBoletoPaymentMethodOptionsSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval =
    | Month

    type Update'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType =
    | FixedCount

    type Update'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan = {
        ///For `fixed_count` installment plans, this is the number of installment payments your customer will make to their credit card.
        [<Config.Form>]Count: int option
        ///For `fixed_count` installment plans, this is the interval between installment payments your customer will make to their credit card.
        ///One of `month`.
        [<Config.Form>]Interval: Update'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval option
        ///Type of installment plan, one of `fixed_count`.
        [<Config.Form>]Type: Update'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType option
    }
    with
        static member New(?count: int, ?interval: Update'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval, ?type': Update'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType) =
            {
                Count = count
                Interval = interval
                Type = type'
            }

    type Update'PaymentMethodOptionsCardPaymentIntentInstallments = {
        ///Setting to true enables installments for this PaymentIntent.
        ///This will cause the response to contain a list of available installment plans.
        ///Setting to false will prevent any selected plan from applying to a charge.
        [<Config.Form>]Enabled: bool option
        ///The selected installment plan to use for this payment attempt.
        ///This parameter can only be provided during confirmation.
        [<Config.Form>]Plan: Choice<Update'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string> option
    }
    with
        static member New(?enabled: bool, ?plan: Choice<Update'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string>) =
            {
                Enabled = enabled
                Plan = plan
            }

    type Update'PaymentMethodOptionsCardPaymentIntentMandateOptionsSupportedTypes =
    | India

    type Update'PaymentMethodOptionsCardPaymentIntentMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Update'PaymentMethodOptionsCardPaymentIntentMandateOptionsInterval =
    | Day
    | Month
    | Sporadic
    | Week
    | Year

    type Update'PaymentMethodOptionsCardPaymentIntentMandateOptions = {
        ///Amount to be charged for future payments.
        [<Config.Form>]Amount: int option
        ///One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
        [<Config.Form>]AmountType: Update'PaymentMethodOptionsCardPaymentIntentMandateOptionsAmountType option
        ///A description of the mandate or subscription that is meant to be displayed to the customer.
        [<Config.Form>]Description: string option
        ///End date of the mandate or subscription. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.
        [<Config.Form>]EndDate: DateTime option
        ///Specifies payment frequency. One of `day`, `week`, `month`, `year`, or `sporadic`.
        [<Config.Form>]Interval: Update'PaymentMethodOptionsCardPaymentIntentMandateOptionsInterval option
        ///The number of intervals between payments. For example, `interval=month` and `interval_count=3` indicates one payment every three months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks). This parameter is optional when `interval=sporadic`.
        [<Config.Form>]IntervalCount: int option
        ///Unique identifier for the mandate or subscription.
        [<Config.Form>]Reference: string option
        ///Start date of the mandate or subscription. Start date should not be lesser than yesterday.
        [<Config.Form>]StartDate: DateTime option
        ///Specifies the type of mandates supported. Possible values are `india`.
        [<Config.Form>]SupportedTypes: Update'PaymentMethodOptionsCardPaymentIntentMandateOptionsSupportedTypes list option
    }
    with
        static member New(?amount: int, ?amountType: Update'PaymentMethodOptionsCardPaymentIntentMandateOptionsAmountType, ?description: string, ?endDate: DateTime, ?interval: Update'PaymentMethodOptionsCardPaymentIntentMandateOptionsInterval, ?intervalCount: int, ?reference: string, ?startDate: DateTime, ?supportedTypes: Update'PaymentMethodOptionsCardPaymentIntentMandateOptionsSupportedTypes list) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
                Interval = interval
                IntervalCount = intervalCount
                Reference = reference
                StartDate = startDate
                SupportedTypes = supportedTypes
            }

    type Update'PaymentMethodOptionsCardPaymentIntentCaptureMethod =
    | Manual

    type Update'PaymentMethodOptionsCardPaymentIntentNetwork =
    | Amex
    | CartesBancaires
    | Diners
    | Discover
    | EftposAu
    | Interac
    | Jcb
    | Mastercard
    | Unionpay
    | Unknown
    | Visa

    type Update'PaymentMethodOptionsCardPaymentIntentRequestThreeDSecure =
    | Any
    | Automatic

    type Update'PaymentMethodOptionsCardPaymentIntentSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Update'PaymentMethodOptionsCardPaymentIntent = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Update'PaymentMethodOptionsCardPaymentIntentCaptureMethod option
        ///A single-use `cvc_update` Token that represents a card CVC value. When provided, the CVC value will be verified during the card payment attempt. This parameter can only be provided during confirmation.
        [<Config.Form>]CvcToken: string option
        ///Installment configuration for payments attempted on this PaymentIntent (Mexico Only).
        ///For more information, see the [installments integration guide](https://stripe.com/docs/payments/installments).
        [<Config.Form>]Installments: Update'PaymentMethodOptionsCardPaymentIntentInstallments option
        ///Configuration options for setting up an eMandate for cards issued in India.
        [<Config.Form>]MandateOptions: Update'PaymentMethodOptionsCardPaymentIntentMandateOptions option
        ///When specified, this parameter indicates that a transaction will be marked
        ///as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
        ///parameter can only be provided during confirmation.
        [<Config.Form>]Moto: bool option
        ///Selected network to process this PaymentIntent on. Depends on the available networks of the card attached to the PaymentIntent. Can be only set confirm-time.
        [<Config.Form>]Network: Update'PaymentMethodOptionsCardPaymentIntentNetwork option
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        [<Config.Form>]RequestThreeDSecure: Update'PaymentMethodOptionsCardPaymentIntentRequestThreeDSecure option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsCardPaymentIntentSetupFutureUsage option
        ///Provides information about a card payment that customers see on their statements. Concatenated with the Kana prefix (shortened Kana descriptor) or Kana statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 22 characters.
        [<Config.Form>]StatementDescriptorSuffixKana: Choice<string,string> option
        ///Provides information about a card payment that customers see on their statements. Concatenated with the Kanji prefix (shortened Kanji descriptor) or Kanji statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 17 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 17 characters.
        [<Config.Form>]StatementDescriptorSuffixKanji: Choice<string,string> option
    }
    with
        static member New(?captureMethod: Update'PaymentMethodOptionsCardPaymentIntentCaptureMethod, ?cvcToken: string, ?installments: Update'PaymentMethodOptionsCardPaymentIntentInstallments, ?mandateOptions: Update'PaymentMethodOptionsCardPaymentIntentMandateOptions, ?moto: bool, ?network: Update'PaymentMethodOptionsCardPaymentIntentNetwork, ?requestThreeDSecure: Update'PaymentMethodOptionsCardPaymentIntentRequestThreeDSecure, ?setupFutureUsage: Update'PaymentMethodOptionsCardPaymentIntentSetupFutureUsage, ?statementDescriptorSuffixKana: Choice<string,string>, ?statementDescriptorSuffixKanji: Choice<string,string>) =
            {
                CaptureMethod = captureMethod
                CvcToken = cvcToken
                Installments = installments
                MandateOptions = mandateOptions
                Moto = moto
                Network = network
                RequestThreeDSecure = requestThreeDSecure
                SetupFutureUsage = setupFutureUsage
                StatementDescriptorSuffixKana = statementDescriptorSuffixKana
                StatementDescriptorSuffixKanji = statementDescriptorSuffixKanji
            }

    type Update'PaymentMethodOptionsCardPresentPaymentMethodOptions = {
        ///Request ability to capture this payment beyond the standard [authorization validity window](https://stripe.com/docs/terminal/features/extended-authorizations#authorization-validity)
        [<Config.Form>]RequestExtendedAuthorization: bool option
        ///Request ability to [increment](https://stripe.com/docs/terminal/features/incremental-authorizations) this PaymentIntent if the combination of MCC and card brand is eligible. Check [incremental_authorization_supported](https://stripe.com/docs/api/charges/object#charge_object-payment_method_details-card_present-incremental_authorization_supported) in the [Confirm](https://stripe.com/docs/api/payment_intents/confirm) response to verify support.
        [<Config.Form>]RequestIncrementalAuthorizationSupport: bool option
    }
    with
        static member New(?requestExtendedAuthorization: bool, ?requestIncrementalAuthorizationSupport: bool) =
            {
                RequestExtendedAuthorization = requestExtendedAuthorization
                RequestIncrementalAuthorizationSupport = requestIncrementalAuthorizationSupport
            }

    type Update'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsCaptureMethod =
    | Manual

    type Update'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Update'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Update'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsCaptureMethod option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Update'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsCaptureMethod, ?setupFutureUsage: Update'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferEuBankTransfer = {
        ///The desired country code of the bank account information. Permitted values include: `BE`, `DE`, `ES`, `FR`, `IE`, or `NL`.
        [<Config.Form>]Country: string option
    }
    with
        static member New(?country: string) =
            {
                Country = country
            }

    type Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferRequestedAddressTypes =
    | Aba
    | Iban
    | Sepa
    | SortCode
    | Spei
    | Swift
    | Zengin

    type Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferType =
    | EuBankTransfer
    | GbBankTransfer
    | JpBankTransfer
    | MxBankTransfer
    | UsBankTransfer

    type Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransfer = {
        ///Configuration for the eu_bank_transfer funding type.
        [<Config.Form>]EuBankTransfer: Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferEuBankTransfer option
        ///List of address types that should be returned in the financial_addresses response. If not specified, all valid types will be returned.
        ///Permitted values include: `sort_code`, `zengin`, `iban`, or `spei`.
        [<Config.Form>]RequestedAddressTypes: Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferRequestedAddressTypes list option
        ///The list of bank transfer types that this PaymentIntent is allowed to use for funding Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.
        [<Config.Form>]Type: Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferType option
    }
    with
        static member New(?euBankTransfer: Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferEuBankTransfer, ?requestedAddressTypes: Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferRequestedAddressTypes list, ?type': Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferType) =
            {
                EuBankTransfer = euBankTransfer
                RequestedAddressTypes = requestedAddressTypes
                Type = type'
            }

    type Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsFundingType =
    | BankTransfer

    type Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptions = {
        ///Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.
        [<Config.Form>]BankTransfer: Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransfer option
        ///The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
        [<Config.Form>]FundingType: Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsFundingType option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?bankTransfer: Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransfer, ?fundingType: Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsFundingType, ?setupFutureUsage: Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Update'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsFpxPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsFpxPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsFpxPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Update'PaymentMethodOptionsFpxPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsGiropayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsGiropayPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsGiropayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Update'PaymentMethodOptionsGiropayPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsGrabpayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsGrabpayPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsGrabpayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Update'PaymentMethodOptionsGrabpayPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsIdealPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Update'PaymentMethodOptionsIdealPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsIdealPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Update'PaymentMethodOptionsIdealPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsKlarnaPaymentMethodOptionsCaptureMethod =
    | Manual

    type Update'PaymentMethodOptionsKlarnaPaymentMethodOptionsPreferredLocale =
    | [<JsonUnionCase("cs-CZ")>] CsCZ
    | [<JsonUnionCase("da-DK")>] DaDK
    | [<JsonUnionCase("de-AT")>] DeAT
    | [<JsonUnionCase("de-CH")>] DeCH
    | [<JsonUnionCase("de-DE")>] DeDE
    | [<JsonUnionCase("el-GR")>] ElGR
    | [<JsonUnionCase("en-AT")>] EnAT
    | [<JsonUnionCase("en-AU")>] EnAU
    | [<JsonUnionCase("en-BE")>] EnBE
    | [<JsonUnionCase("en-CA")>] EnCA
    | [<JsonUnionCase("en-CH")>] EnCH
    | [<JsonUnionCase("en-CZ")>] EnCZ
    | [<JsonUnionCase("en-DE")>] EnDE
    | [<JsonUnionCase("en-DK")>] EnDK
    | [<JsonUnionCase("en-ES")>] EnES
    | [<JsonUnionCase("en-FI")>] EnFI
    | [<JsonUnionCase("en-FR")>] EnFR
    | [<JsonUnionCase("en-GB")>] EnGB
    | [<JsonUnionCase("en-GR")>] EnGR
    | [<JsonUnionCase("en-IE")>] EnIE
    | [<JsonUnionCase("en-IT")>] EnIT
    | [<JsonUnionCase("en-NL")>] EnNL
    | [<JsonUnionCase("en-NO")>] EnNO
    | [<JsonUnionCase("en-NZ")>] EnNZ
    | [<JsonUnionCase("en-PL")>] EnPL
    | [<JsonUnionCase("en-PT")>] EnPT
    | [<JsonUnionCase("en-SE")>] EnSE
    | [<JsonUnionCase("en-US")>] EnUS
    | [<JsonUnionCase("es-ES")>] EsES
    | [<JsonUnionCase("es-US")>] EsUS
    | [<JsonUnionCase("fi-FI")>] FiFI
    | [<JsonUnionCase("fr-BE")>] FrBE
    | [<JsonUnionCase("fr-CA")>] FrCA
    | [<JsonUnionCase("fr-CH")>] FrCH
    | [<JsonUnionCase("fr-FR")>] FrFR
    | [<JsonUnionCase("it-CH")>] ItCH
    | [<JsonUnionCase("it-IT")>] ItIT
    | [<JsonUnionCase("nb-NO")>] NbNO
    | [<JsonUnionCase("nl-BE")>] NlBE
    | [<JsonUnionCase("nl-NL")>] NlNL
    | [<JsonUnionCase("pl-PL")>] PlPL
    | [<JsonUnionCase("pt-PT")>] PtPT
    | [<JsonUnionCase("sv-FI")>] SvFI
    | [<JsonUnionCase("sv-SE")>] SvSE

    type Update'PaymentMethodOptionsKlarnaPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsKlarnaPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Update'PaymentMethodOptionsKlarnaPaymentMethodOptionsCaptureMethod option
        ///Preferred language of the Klarna authorization page that the customer is redirected to
        [<Config.Form>]PreferredLocale: Update'PaymentMethodOptionsKlarnaPaymentMethodOptionsPreferredLocale option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsKlarnaPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Update'PaymentMethodOptionsKlarnaPaymentMethodOptionsCaptureMethod, ?preferredLocale: Update'PaymentMethodOptionsKlarnaPaymentMethodOptionsPreferredLocale, ?setupFutureUsage: Update'PaymentMethodOptionsKlarnaPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PreferredLocale = preferredLocale
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsKonbiniPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsKonbiniPaymentMethodOptions = {
        ///An optional 10 to 11 digit numeric-only string determining the confirmation code at applicable convenience stores. Must not consist of only zeroes and could be rejected in case of insufficient uniqueness. We recommend to use the customer's phone number.
        [<Config.Form>]ConfirmationNumber: Choice<string,string> option
        ///The number of calendar days (between 1 and 60) after which Konbini payment instructions will expire. For example, if a PaymentIntent is confirmed with Konbini and `expires_after_days` set to 2 on Monday JST, the instructions will expire on Wednesday 23:59:59 JST. Defaults to 3 days.
        [<Config.Form>]ExpiresAfterDays: Choice<int,string> option
        ///The timestamp at which the Konbini payment instructions will expire. Only one of `expires_after_days` or `expires_at` may be set.
        [<Config.Form>]ExpiresAt: Choice<DateTime,string> option
        ///A product descriptor of up to 22 characters, which will appear to customers at the convenience store.
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsKonbiniPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?confirmationNumber: Choice<string,string>, ?expiresAfterDays: Choice<int,string>, ?expiresAt: Choice<DateTime,string>, ?productDescription: Choice<string,string>, ?setupFutureUsage: Update'PaymentMethodOptionsKonbiniPaymentMethodOptionsSetupFutureUsage) =
            {
                ConfirmationNumber = confirmationNumber
                ExpiresAfterDays = expiresAfterDays
                ExpiresAt = expiresAt
                ProductDescription = productDescription
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsCaptureMethod =
    | Manual

    type Update'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Update'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Update'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsCaptureMethod option
        ///[Deprecated] This is a legacy parameter that no longer has any function.
        [<Config.Form>]PersistentToken: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Update'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsCaptureMethod, ?persistentToken: string, ?setupFutureUsage: Update'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PersistentToken = persistentToken
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsOxxoPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsOxxoPaymentMethodOptions = {
        ///The number of calendar days before an OXXO voucher expires. For example, if you create an OXXO voucher on Monday and you set expires_after_days to 2, the OXXO invoice will expire on Wednesday at 23:59 America/Mexico_City time.
        [<Config.Form>]ExpiresAfterDays: int option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsOxxoPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Update'PaymentMethodOptionsOxxoPaymentMethodOptionsSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsP24PaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsP24PaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsP24PaymentMethodOptionsSetupFutureUsage option
        ///Confirm that the payer has accepted the P24 terms and conditions.
        [<Config.Form>]TosShownAndAccepted: bool option
    }
    with
        static member New(?setupFutureUsage: Update'PaymentMethodOptionsP24PaymentMethodOptionsSetupFutureUsage, ?tosShownAndAccepted: bool) =
            {
                SetupFutureUsage = setupFutureUsage
                TosShownAndAccepted = tosShownAndAccepted
            }

    type Update'PaymentMethodOptionsPaynowPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsPaynowPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsPaynowPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Update'PaymentMethodOptionsPaynowPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsPaypalPaymentMethodOptionsCaptureMethod =
    | Manual

    type Update'PaymentMethodOptionsPaypalPaymentMethodOptionsPreferredLocale =
    | [<JsonUnionCase("cs-CZ")>] CsCZ
    | [<JsonUnionCase("da-DK")>] DaDK
    | [<JsonUnionCase("de-AT")>] DeAT
    | [<JsonUnionCase("de-DE")>] DeDE
    | [<JsonUnionCase("de-LU")>] DeLU
    | [<JsonUnionCase("el-GR")>] ElGR
    | [<JsonUnionCase("en-GB")>] EnGB
    | [<JsonUnionCase("en-US")>] EnUS
    | [<JsonUnionCase("es-ES")>] EsES
    | [<JsonUnionCase("fi-FI")>] FiFI
    | [<JsonUnionCase("fr-BE")>] FrBE
    | [<JsonUnionCase("fr-FR")>] FrFR
    | [<JsonUnionCase("fr-LU")>] FrLU
    | [<JsonUnionCase("hu-HU")>] HuHU
    | [<JsonUnionCase("it-IT")>] ItIT
    | [<JsonUnionCase("nl-BE")>] NlBE
    | [<JsonUnionCase("nl-NL")>] NlNL
    | [<JsonUnionCase("pl-PL")>] PlPL
    | [<JsonUnionCase("pt-PT")>] PtPT
    | [<JsonUnionCase("sk-SK")>] SkSK
    | [<JsonUnionCase("sv-SE")>] SvSE

    type Update'PaymentMethodOptionsPaypalPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Update'PaymentMethodOptionsPaypalPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        [<Config.Form>]CaptureMethod: Update'PaymentMethodOptionsPaypalPaymentMethodOptionsCaptureMethod option
        ///[Preferred locale](https://stripe.com/docs/payments/paypal/supported-locales) of the PayPal checkout page that the customer is redirected to.
        [<Config.Form>]PreferredLocale: Update'PaymentMethodOptionsPaypalPaymentMethodOptionsPreferredLocale option
        ///A reference of the PayPal transaction visible to customer which is mapped to PayPal's invoice ID. This must be a globally unique ID if you have configured in your PayPal settings to block multiple payments per invoice ID.
        [<Config.Form>]Reference: string option
        ///The risk correlation ID for an on-session payment using a saved PayPal payment method.
        [<Config.Form>]RiskCorrelationId: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsPaypalPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Update'PaymentMethodOptionsPaypalPaymentMethodOptionsCaptureMethod, ?preferredLocale: Update'PaymentMethodOptionsPaypalPaymentMethodOptionsPreferredLocale, ?reference: string, ?riskCorrelationId: string, ?setupFutureUsage: Update'PaymentMethodOptionsPaypalPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PreferredLocale = preferredLocale
                Reference = reference
                RiskCorrelationId = riskCorrelationId
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsPixPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsPixPaymentMethodOptions = {
        ///The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.
        [<Config.Form>]ExpiresAfterSeconds: int option
        ///The timestamp at which the Pix expires (between 10 and 1209600 seconds in the future). Defaults to 1 day in the future.
        [<Config.Form>]ExpiresAt: DateTime option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsPixPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?expiresAfterSeconds: int, ?expiresAt: DateTime, ?setupFutureUsage: Update'PaymentMethodOptionsPixPaymentMethodOptionsSetupFutureUsage) =
            {
                ExpiresAfterSeconds = expiresAfterSeconds
                ExpiresAt = expiresAt
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsPromptpayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsPromptpayPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsPromptpayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Update'PaymentMethodOptionsPromptpayPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Update'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions = {
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?mandateOptions: string, ?setupFutureUsage: Update'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Es
    | Fr
    | It
    | Nl
    | Pl

    type Update'PaymentMethodOptionsSofortPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Update'PaymentMethodOptionsSofortPaymentMethodOptions = {
        ///Language shown to the payer on redirect.
        [<Config.Form>]PreferredLanguage: Update'PaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsSofortPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?preferredLanguage: Update'PaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage, ?setupFutureUsage: Update'PaymentMethodOptionsSofortPaymentMethodOptionsSetupFutureUsage) =
            {
                PreferredLanguage = preferredLanguage
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPrefetch =
    | Balances

    type Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnections = {
        ///The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
        [<Config.Form>]Permissions: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPermissions list option
        ///List of data features that you would like to retrieve upon account creation.
        [<Config.Form>]Prefetch: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPrefetch list option
        ///For webview integrations only. Upon completing OAuth login in the native browser, the user will be redirected to this URL to return to your app.
        [<Config.Form>]ReturnUrl: string option
    }
    with
        static member New(?permissions: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPermissions list, ?prefetch: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPrefetch list, ?returnUrl: string) =
            {
                Permissions = permissions
                Prefetch = prefetch
                ReturnUrl = returnUrl
            }

    type Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworksRequested =
    | Ach
    | UsDomesticWire

    type Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworks = {
        ///Triggers validations to run across the selected networks
        [<Config.Form>]Requested: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworksRequested list option
    }
    with
        static member New(?requested: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworksRequested list) =
            {
                Requested = requested
            }

    type Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsPreferredSettlementSpeed =
    | Fastest
    | Standard

    type Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptions = {
        ///Additional fields for Financial Connections Session creation
        [<Config.Form>]FinancialConnections: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnections option
        ///Additional fields for network related functions
        [<Config.Form>]Networks: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworks option
        ///Preferred transaction settlement speed
        [<Config.Form>]PreferredSettlementSpeed: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsPreferredSettlementSpeed option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsSetupFutureUsage option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?financialConnections: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnections, ?networks: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworks, ?preferredSettlementSpeed: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsPreferredSettlementSpeed, ?setupFutureUsage: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsSetupFutureUsage, ?verificationMethod: Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsVerificationMethod) =
            {
                FinancialConnections = financialConnections
                Networks = networks
                PreferredSettlementSpeed = preferredSettlementSpeed
                SetupFutureUsage = setupFutureUsage
                VerificationMethod = verificationMethod
            }

    type Update'PaymentMethodOptionsWechatPayPaymentMethodOptionsClient =
    | Android
    | Ios
    | Web

    type Update'PaymentMethodOptionsWechatPayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsWechatPayPaymentMethodOptions = {
        ///The app ID registered with WeChat Pay. Only required when client is ios or android.
        [<Config.Form>]AppId: string option
        ///The client type that the end customer will pay from
        [<Config.Form>]Client: Update'PaymentMethodOptionsWechatPayPaymentMethodOptionsClient option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsWechatPayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?appId: string, ?client: Update'PaymentMethodOptionsWechatPayPaymentMethodOptionsClient, ?setupFutureUsage: Update'PaymentMethodOptionsWechatPayPaymentMethodOptionsSetupFutureUsage) =
            {
                AppId = appId
                Client = client
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptionsZipPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Update'PaymentMethodOptionsZipPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'PaymentMethodOptionsZipPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Update'PaymentMethodOptionsZipPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Update'PaymentMethodOptions = {
        ///If this is a `acss_debit` PaymentMethod, this sub-hash contains details about the ACSS Debit payment method options.
        [<Config.Form>]AcssDebit: Choice<Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptions,string> option
        ///If this is an `affirm` PaymentMethod, this sub-hash contains details about the Affirm payment method options.
        [<Config.Form>]Affirm: Choice<Update'PaymentMethodOptionsAffirmPaymentMethodOptions,string> option
        ///If this is a `afterpay_clearpay` PaymentMethod, this sub-hash contains details about the Afterpay Clearpay payment method options.
        [<Config.Form>]AfterpayClearpay: Choice<Update'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptions,string> option
        ///If this is a `alipay` PaymentMethod, this sub-hash contains details about the Alipay payment method options.
        [<Config.Form>]Alipay: Choice<Update'PaymentMethodOptionsAlipayPaymentMethodOptions,string> option
        ///If this is a `au_becs_debit` PaymentMethod, this sub-hash contains details about the AU BECS Direct Debit payment method options.
        [<Config.Form>]AuBecsDebit: Choice<Update'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `bacs_debit` PaymentMethod, this sub-hash contains details about the BACS Debit payment method options.
        [<Config.Form>]BacsDebit: Choice<Update'PaymentMethodOptionsBacsDebitPaymentMethodOptions,string> option
        ///If this is a `bancontact` PaymentMethod, this sub-hash contains details about the Bancontact payment method options.
        [<Config.Form>]Bancontact: Choice<Update'PaymentMethodOptionsBancontactPaymentMethodOptions,string> option
        ///If this is a `blik` PaymentMethod, this sub-hash contains details about the BLIK payment method options.
        [<Config.Form>]Blik: Choice<Update'PaymentMethodOptionsBlikPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `boleto` PaymentMethod, this sub-hash contains details about the Boleto payment method options.
        [<Config.Form>]Boleto: Choice<Update'PaymentMethodOptionsBoletoPaymentMethodOptions,string> option
        ///Configuration for any card payments attempted on this PaymentIntent.
        [<Config.Form>]Card: Choice<Update'PaymentMethodOptionsCardPaymentIntent,string> option
        ///If this is a `card_present` PaymentMethod, this sub-hash contains details about the Card Present payment method options.
        [<Config.Form>]CardPresent: Choice<Update'PaymentMethodOptionsCardPresentPaymentMethodOptions,string> option
        ///If this is a `cashapp` PaymentMethod, this sub-hash contains details about the Cash App Pay payment method options.
        [<Config.Form>]Cashapp: Choice<Update'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `customer balance` PaymentMethod, this sub-hash contains details about the customer balance payment method options.
        [<Config.Form>]CustomerBalance: Choice<Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptions,string> option
        ///If this is a `eps` PaymentMethod, this sub-hash contains details about the EPS payment method options.
        [<Config.Form>]Eps: Choice<Update'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `fpx` PaymentMethod, this sub-hash contains details about the FPX payment method options.
        [<Config.Form>]Fpx: Choice<Update'PaymentMethodOptionsFpxPaymentMethodOptions,string> option
        ///If this is a `giropay` PaymentMethod, this sub-hash contains details about the Giropay payment method options.
        [<Config.Form>]Giropay: Choice<Update'PaymentMethodOptionsGiropayPaymentMethodOptions,string> option
        ///If this is a `grabpay` PaymentMethod, this sub-hash contains details about the Grabpay payment method options.
        [<Config.Form>]Grabpay: Choice<Update'PaymentMethodOptionsGrabpayPaymentMethodOptions,string> option
        ///If this is a `ideal` PaymentMethod, this sub-hash contains details about the Ideal payment method options.
        [<Config.Form>]Ideal: Choice<Update'PaymentMethodOptionsIdealPaymentMethodOptions,string> option
        ///If this is a `interac_present` PaymentMethod, this sub-hash contains details about the Card Present payment method options.
        [<Config.Form>]InteracPresent: Choice<string,string> option
        ///If this is a `klarna` PaymentMethod, this sub-hash contains details about the Klarna payment method options.
        [<Config.Form>]Klarna: Choice<Update'PaymentMethodOptionsKlarnaPaymentMethodOptions,string> option
        ///If this is a `konbini` PaymentMethod, this sub-hash contains details about the Konbini payment method options.
        [<Config.Form>]Konbini: Choice<Update'PaymentMethodOptionsKonbiniPaymentMethodOptions,string> option
        ///If this is a `link` PaymentMethod, this sub-hash contains details about the Link payment method options.
        [<Config.Form>]Link: Choice<Update'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `oxxo` PaymentMethod, this sub-hash contains details about the OXXO payment method options.
        [<Config.Form>]Oxxo: Choice<Update'PaymentMethodOptionsOxxoPaymentMethodOptions,string> option
        ///If this is a `p24` PaymentMethod, this sub-hash contains details about the Przelewy24 payment method options.
        [<Config.Form>]P24: Choice<Update'PaymentMethodOptionsP24PaymentMethodOptions,string> option
        ///If this is a `paynow` PaymentMethod, this sub-hash contains details about the PayNow payment method options.
        [<Config.Form>]Paynow: Choice<Update'PaymentMethodOptionsPaynowPaymentMethodOptions,string> option
        ///If this is a `paypal` PaymentMethod, this sub-hash contains details about the PayPal payment method options.
        [<Config.Form>]Paypal: Choice<Update'PaymentMethodOptionsPaypalPaymentMethodOptions,string> option
        ///If this is a `pix` PaymentMethod, this sub-hash contains details about the Pix payment method options.
        [<Config.Form>]Pix: Choice<Update'PaymentMethodOptionsPixPaymentMethodOptions,string> option
        ///If this is a `promptpay` PaymentMethod, this sub-hash contains details about the PromptPay payment method options.
        [<Config.Form>]Promptpay: Choice<Update'PaymentMethodOptionsPromptpayPaymentMethodOptions,string> option
        ///If this is a `sepa_debit` PaymentIntent, this sub-hash contains details about the SEPA Debit payment method options.
        [<Config.Form>]SepaDebit: Choice<Update'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `sofort` PaymentMethod, this sub-hash contains details about the SOFORT payment method options.
        [<Config.Form>]Sofort: Choice<Update'PaymentMethodOptionsSofortPaymentMethodOptions,string> option
        ///If this is a `us_bank_account` PaymentMethod, this sub-hash contains details about the US bank account payment method options.
        [<Config.Form>]UsBankAccount: Choice<Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `wechat_pay` PaymentMethod, this sub-hash contains details about the WeChat Pay payment method options.
        [<Config.Form>]WechatPay: Choice<Update'PaymentMethodOptionsWechatPayPaymentMethodOptions,string> option
        ///If this is a `zip` PaymentMethod, this sub-hash contains details about the Zip payment method options.
        [<Config.Form>]Zip: Choice<Update'PaymentMethodOptionsZipPaymentMethodOptions,string> option
    }
    with
        static member New(?acssDebit: Choice<Update'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptions,string>, ?usBankAccount: Choice<Update'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptions,string>, ?sofort: Choice<Update'PaymentMethodOptionsSofortPaymentMethodOptions,string>, ?sepaDebit: Choice<Update'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string>, ?promptpay: Choice<Update'PaymentMethodOptionsPromptpayPaymentMethodOptions,string>, ?pix: Choice<Update'PaymentMethodOptionsPixPaymentMethodOptions,string>, ?paypal: Choice<Update'PaymentMethodOptionsPaypalPaymentMethodOptions,string>, ?paynow: Choice<Update'PaymentMethodOptionsPaynowPaymentMethodOptions,string>, ?p24: Choice<Update'PaymentMethodOptionsP24PaymentMethodOptions,string>, ?oxxo: Choice<Update'PaymentMethodOptionsOxxoPaymentMethodOptions,string>, ?link: Choice<Update'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptions,string>, ?konbini: Choice<Update'PaymentMethodOptionsKonbiniPaymentMethodOptions,string>, ?klarna: Choice<Update'PaymentMethodOptionsKlarnaPaymentMethodOptions,string>, ?interacPresent: Choice<string,string>, ?ideal: Choice<Update'PaymentMethodOptionsIdealPaymentMethodOptions,string>, ?wechatPay: Choice<Update'PaymentMethodOptionsWechatPayPaymentMethodOptions,string>, ?grabpay: Choice<Update'PaymentMethodOptionsGrabpayPaymentMethodOptions,string>, ?fpx: Choice<Update'PaymentMethodOptionsFpxPaymentMethodOptions,string>, ?eps: Choice<Update'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptions,string>, ?customerBalance: Choice<Update'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptions,string>, ?cashapp: Choice<Update'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptions,string>, ?cardPresent: Choice<Update'PaymentMethodOptionsCardPresentPaymentMethodOptions,string>, ?card: Choice<Update'PaymentMethodOptionsCardPaymentIntent,string>, ?boleto: Choice<Update'PaymentMethodOptionsBoletoPaymentMethodOptions,string>, ?blik: Choice<Update'PaymentMethodOptionsBlikPaymentIntentPaymentMethodOptions,string>, ?bancontact: Choice<Update'PaymentMethodOptionsBancontactPaymentMethodOptions,string>, ?bacsDebit: Choice<Update'PaymentMethodOptionsBacsDebitPaymentMethodOptions,string>, ?auBecsDebit: Choice<Update'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptions,string>, ?alipay: Choice<Update'PaymentMethodOptionsAlipayPaymentMethodOptions,string>, ?afterpayClearpay: Choice<Update'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptions,string>, ?affirm: Choice<Update'PaymentMethodOptionsAffirmPaymentMethodOptions,string>, ?giropay: Choice<Update'PaymentMethodOptionsGiropayPaymentMethodOptions,string>, ?zip: Choice<Update'PaymentMethodOptionsZipPaymentMethodOptions,string>) =
            {
                AcssDebit = acssDebit
                Affirm = affirm
                AfterpayClearpay = afterpayClearpay
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                Blik = blik
                Boleto = boleto
                Card = card
                CardPresent = cardPresent
                Cashapp = cashapp
                CustomerBalance = customerBalance
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Klarna = klarna
                Konbini = konbini
                Link = link
                Oxxo = oxxo
                P24 = p24
                Paynow = paynow
                Paypal = paypal
                Pix = pix
                Promptpay = promptpay
                SepaDebit = sepaDebit
                Sofort = sofort
                UsBankAccount = usBankAccount
                WechatPay = wechatPay
                Zip = zip
            }

    type Update'ShippingOptionalFieldsShippingAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'ShippingOptionalFieldsShipping = {
        ///Shipping address.
        [<Config.Form>]Address: Update'ShippingOptionalFieldsShippingAddress option
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        [<Config.Form>]Carrier: string option
        ///Recipient name.
        [<Config.Form>]Name: string option
        ///Recipient phone (including extension).
        [<Config.Form>]Phone: string option
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        [<Config.Form>]TrackingNumber: string option
    }
    with
        static member New(?address: Update'ShippingOptionalFieldsShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type Update'TransferData = {
        ///The amount that will be transferred automatically when a charge succeeds.
        [<Config.Form>]Amount: int option
    }
    with
        static member New(?amount: int) =
            {
                Amount = amount
            }

    type Update'CaptureMethod =
    | Automatic
    | AutomaticAsync
    | Manual

    type Update'SetupFutureUsage =
    | OffSession
    | OnSession

    type UpdateOptions = {
        [<Config.Path>]Intent: string
        ///Amount intended to be collected by this PaymentIntent. A positive integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://stripe.com/docs/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        [<Config.Form>]Amount: int option
        ///The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. The amount of the application fee collected will be capped at the total payment amount. For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        [<Config.Form>]ApplicationFeeAmount: Choice<int,string> option
        ///Controls when the funds will be captured from the customer's account.
        [<Config.Form>]CaptureMethod: Update'CaptureMethod option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///ID of the Customer this PaymentIntent belongs to, if one exists.
        ///Payment methods attached to other Customers cannot be used with this PaymentIntent.
        ///If present in combination with [setup_future_usage](https://stripe.com/docs/api#payment_intent_object-setup_future_usage), this PaymentIntent's payment method will be attached to the Customer after the PaymentIntent has been confirmed and any required actions from the user are complete.
        [<Config.Form>]Customer: string option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///ID of the payment method (a PaymentMethod, Card, or [compatible Source](https://stripe.com/docs/payments/payment-methods/transitioning#compatibility) object) to attach to this PaymentIntent.
        [<Config.Form>]PaymentMethod: string option
        ///If provided, this hash will be used to create a PaymentMethod. The new PaymentMethod will appear
        ///in the [payment_method](https://stripe.com/docs/api/payment_intents/object#payment_intent_object-payment_method)
        ///property on the PaymentIntent.
        [<Config.Form>]PaymentMethodData: Update'PaymentMethodData option
        ///Payment-method-specific configuration for this PaymentIntent.
        [<Config.Form>]PaymentMethodOptions: Update'PaymentMethodOptions option
        ///The list of payment method types (e.g. card) that this PaymentIntent is allowed to use. Use automatic_payment_methods to manage payment methods from the [Stripe Dashboard](https://dashboard.stripe.com/settings/payment_methods).
        [<Config.Form>]PaymentMethodTypes: string list option
        ///Email address that the receipt for the resulting payment will be sent to. If `receipt_email` is specified for a payment in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).
        [<Config.Form>]ReceiptEmail: Choice<string,string> option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Update'SetupFutureUsage option
        ///Shipping information for this PaymentIntent.
        [<Config.Form>]Shipping: Choice<Update'ShippingOptionalFieldsShipping,string> option
        ///For non-card charges, you can use this value as the complete description that appears on your customers’ statements. Must contain at least one letter, maximum 22 characters.
        [<Config.Form>]StatementDescriptor: string option
        ///Provides information about a card payment that customers see on their statements. Concatenated with the prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters for the concatenated descriptor.
        [<Config.Form>]StatementDescriptorSuffix: string option
        ///The parameters used to automatically create a Transfer when the payment succeeds. For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        [<Config.Form>]TransferData: Update'TransferData option
        ///A string that identifies the resulting payment as part of a group. `transfer_group` may only be provided if it has not been set. See the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts) for details.
        [<Config.Form>]TransferGroup: string option
    }
    with
        static member New(intent: string, ?statementDescriptorSuffix: string, ?statementDescriptor: string, ?shipping: Choice<Update'ShippingOptionalFieldsShipping,string>, ?setupFutureUsage: Update'SetupFutureUsage, ?receiptEmail: Choice<string,string>, ?paymentMethodTypes: string list, ?paymentMethodOptions: Update'PaymentMethodOptions, ?paymentMethodData: Update'PaymentMethodData, ?paymentMethod: string, ?metadata: Map<string, string>, ?expand: string list, ?description: string, ?customer: string, ?currency: string, ?captureMethod: Update'CaptureMethod, ?applicationFeeAmount: Choice<int,string>, ?amount: int, ?transferData: Update'TransferData, ?transferGroup: string) =
            {
                Intent = intent
                Amount = amount
                ApplicationFeeAmount = applicationFeeAmount
                CaptureMethod = captureMethod
                Currency = currency
                Customer = customer
                Description = description
                Expand = expand
                Metadata = metadata
                PaymentMethod = paymentMethod
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
                ReceiptEmail = receiptEmail
                SetupFutureUsage = setupFutureUsage
                Shipping = shipping
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferData = transferData
                TransferGroup = transferGroup
            }

    ///<p>Updates properties on a PaymentIntent object without confirming.
    ///Depending on which properties you update, you may need to confirm the
    ///PaymentIntent again. For example, updating the <code>payment_method</code> will
    ///always require you to confirm the PaymentIntent again. If you prefer to
    ///update and confirm at the same time, we recommend updating properties via
    ///the <a href="/docs/api/payment_intents/confirm">confirm API</a> instead.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/payment_intents/{options.Intent}"
        |> RestApi.postAsync<_, PaymentIntent> settings (Map.empty) options

module PaymentIntentsSearch =

    type SearchOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.
        [<Config.Query>]Page: string option
        ///The search query string. See [search query language](https://stripe.com/docs/search#search-query-language) and the list of supported [query fields for payment intents](https://stripe.com/docs/search#query-fields-for-payment-intents).
        [<Config.Query>]Query: string
    }
    with
        static member New(query: string, ?expand: string list, ?limit: int, ?page: string) =
            {
                Expand = expand
                Limit = limit
                Page = page
                Query = query
            }

    ///<p>Search for PaymentIntents you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/payment_intents/search"
        |> RestApi.getAsync<PaymentIntent list> settings qs

module PaymentIntentsApplyCustomerBalance =

    type ApplyCustomerBalanceOptions = {
        [<Config.Path>]Intent: string
        ///Amount intended to be applied to this PaymentIntent from the customer’s cash balance.
        ///A positive integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency).
        ///The maximum amount is the amount of the PaymentIntent.
        ///When omitted, the amount defaults to the remaining amount requested on the PaymentIntent.
        [<Config.Form>]Amount: int option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(intent: string, ?amount: int, ?currency: string, ?expand: string list) =
            {
                Intent = intent
                Amount = amount
                Currency = currency
                Expand = expand
            }

    ///<p>Manually reconcile the remaining amount for a customer_balance PaymentIntent.</p>
    let ApplyCustomerBalance settings (options: ApplyCustomerBalanceOptions) =
        $"/v1/payment_intents/{options.Intent}/apply_customer_balance"
        |> RestApi.postAsync<_, PaymentIntent> settings (Map.empty) options

module PaymentIntentsCancel =

    type Cancel'CancellationReason =
    | Abandoned
    | Duplicate
    | Fraudulent
    | RequestedByCustomer

    type CancelOptions = {
        [<Config.Path>]Intent: string
        ///Reason for canceling this PaymentIntent. Possible values are `duplicate`, `fraudulent`, `requested_by_customer`, or `abandoned`
        [<Config.Form>]CancellationReason: Cancel'CancellationReason option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(intent: string, ?cancellationReason: Cancel'CancellationReason, ?expand: string list) =
            {
                Intent = intent
                CancellationReason = cancellationReason
                Expand = expand
            }

    ///<p>A PaymentIntent object can be canceled when it is in one of these statuses: <code>requires_payment_method</code>, <code>requires_capture</code>, <code>requires_confirmation</code>, <code>requires_action</code> or, <a href="/docs/payments/intents">in rare cases</a>, <code>processing</code>. 
    ///Once canceled, no additional charges will be made by the PaymentIntent and any operations on the PaymentIntent will fail with an error. For PaymentIntents with a <code>status</code> of <code>requires_capture</code>, the remaining <code>amount_capturable</code> will automatically be refunded. 
    ///You cannot cancel the PaymentIntent for a Checkout Session. <a href="/docs/api/checkout/sessions/expire">Expire the Checkout Session</a> instead.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/payment_intents/{options.Intent}/cancel"
        |> RestApi.postAsync<_, PaymentIntent> settings (Map.empty) options

module PaymentIntentsCapture =

    type Capture'TransferData = {
        ///The amount that will be transferred automatically when a charge succeeds.
        [<Config.Form>]Amount: int option
    }
    with
        static member New(?amount: int) =
            {
                Amount = amount
            }

    type CaptureOptions = {
        [<Config.Path>]Intent: string
        ///The amount to capture from the PaymentIntent, which must be less than or equal to the original amount. Any additional amount will be automatically refunded. Defaults to the full `amount_capturable` if not provided.
        [<Config.Form>]AmountToCapture: int option
        ///The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. The amount of the application fee collected will be capped at the total payment amount. For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        [<Config.Form>]ApplicationFeeAmount: int option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///For non-card charges, you can use this value as the complete description that appears on your customers’ statements. Must contain at least one letter, maximum 22 characters.
        [<Config.Form>]StatementDescriptor: string option
        ///Provides information about a card payment that customers see on their statements. Concatenated with the prefix (shortened descriptor) or statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters for the concatenated descriptor.
        [<Config.Form>]StatementDescriptorSuffix: string option
        ///The parameters used to automatically create a Transfer when the payment
        ///is captured. For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        [<Config.Form>]TransferData: Capture'TransferData option
    }
    with
        static member New(intent: string, ?amountToCapture: int, ?applicationFeeAmount: int, ?expand: string list, ?metadata: Map<string, string>, ?statementDescriptor: string, ?statementDescriptorSuffix: string, ?transferData: Capture'TransferData) =
            {
                Intent = intent
                AmountToCapture = amountToCapture
                ApplicationFeeAmount = applicationFeeAmount
                Expand = expand
                Metadata = metadata
                StatementDescriptor = statementDescriptor
                StatementDescriptorSuffix = statementDescriptorSuffix
                TransferData = transferData
            }

    ///<p>Capture the funds of an existing uncaptured PaymentIntent when its status is <code>requires_capture</code>.
    ///Uncaptured PaymentIntents will be canceled a set number of days after they are created (7 by default).
    ///Learn more about <a href="/docs/payments/capture-later">separate authorization and capture</a>.</p>
    let Capture settings (options: CaptureOptions) =
        $"/v1/payment_intents/{options.Intent}/capture"
        |> RestApi.postAsync<_, PaymentIntent> settings (Map.empty) options

module PaymentIntentsConfirm =

    type Confirm'MandateDataSecretKeyCustomerAcceptanceOnline = {
        ///The IP address from which the Mandate was accepted by the customer.
        [<Config.Form>]IpAddress: string option
        ///The user agent of the browser from which the Mandate was accepted by the customer.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type Confirm'MandateDataSecretKeyCustomerAcceptanceType =
    | Offline
    | Online

    type Confirm'MandateDataSecretKeyCustomerAcceptance = {
        ///The time at which the customer accepted the Mandate.
        [<Config.Form>]AcceptedAt: DateTime option
        ///If this is a Mandate accepted offline, this hash contains details about the offline acceptance.
        [<Config.Form>]Offline: string option
        ///If this is a Mandate accepted online, this hash contains details about the online acceptance.
        [<Config.Form>]Online: Confirm'MandateDataSecretKeyCustomerAcceptanceOnline option
        ///The type of customer acceptance information included with the Mandate. One of `online` or `offline`.
        [<Config.Form>]Type: Confirm'MandateDataSecretKeyCustomerAcceptanceType option
    }
    with
        static member New(?acceptedAt: DateTime, ?offline: string, ?online: Confirm'MandateDataSecretKeyCustomerAcceptanceOnline, ?type': Confirm'MandateDataSecretKeyCustomerAcceptanceType) =
            {
                AcceptedAt = acceptedAt
                Offline = offline
                Online = online
                Type = type'
            }

    type Confirm'MandateDataSecretKey = {
        ///This hash contains details about the customer acceptance of the Mandate.
        [<Config.Form>]CustomerAcceptance: Confirm'MandateDataSecretKeyCustomerAcceptance option
    }
    with
        static member New(?customerAcceptance: Confirm'MandateDataSecretKeyCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type Confirm'MandateDataClientKeyCustomerAcceptanceOnline = {
        ///The IP address from which the Mandate was accepted by the customer.
        [<Config.Form>]IpAddress: string option
        ///The user agent of the browser from which the Mandate was accepted by the customer.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type Confirm'MandateDataClientKeyCustomerAcceptanceType =
    | Online

    type Confirm'MandateDataClientKeyCustomerAcceptance = {
        ///If this is a Mandate accepted online, this hash contains details about the online acceptance.
        [<Config.Form>]Online: Confirm'MandateDataClientKeyCustomerAcceptanceOnline option
        ///The type of customer acceptance information included with the Mandate.
        [<Config.Form>]Type: Confirm'MandateDataClientKeyCustomerAcceptanceType option
    }
    with
        static member New(?online: Confirm'MandateDataClientKeyCustomerAcceptanceOnline, ?type': Confirm'MandateDataClientKeyCustomerAcceptanceType) =
            {
                Online = online
                Type = type'
            }

    type Confirm'MandateDataClientKey = {
        ///This hash contains details about the customer acceptance of the Mandate.
        [<Config.Form>]CustomerAcceptance: Confirm'MandateDataClientKeyCustomerAcceptance option
    }
    with
        static member New(?customerAcceptance: Confirm'MandateDataClientKeyCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type Confirm'OffSession =
    | OneOff
    | Recurring

    type Confirm'PaymentMethodDataAcssDebit = {
        ///Customer's bank account number.
        [<Config.Form>]AccountNumber: string option
        ///Institution number of the customer's bank.
        [<Config.Form>]InstitutionNumber: string option
        ///Transit number of the customer's bank.
        [<Config.Form>]TransitNumber: string option
    }
    with
        static member New(?accountNumber: string, ?institutionNumber: string, ?transitNumber: string) =
            {
                AccountNumber = accountNumber
                InstitutionNumber = institutionNumber
                TransitNumber = transitNumber
            }

    type Confirm'PaymentMethodDataAuBecsDebit = {
        ///The account number for the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Bank-State-Branch number of the bank account.
        [<Config.Form>]BsbNumber: string option
    }
    with
        static member New(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type Confirm'PaymentMethodDataBacsDebit = {
        ///Account number of the bank account that the funds will be debited from.
        [<Config.Form>]AccountNumber: string option
        ///Sort code of the bank account. (e.g., `10-20-30`)
        [<Config.Form>]SortCode: string option
    }
    with
        static member New(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type Confirm'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Confirm'PaymentMethodDataBillingDetails = {
        ///Billing address.
        [<Config.Form>]Address: Choice<Confirm'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
        ///Email address.
        [<Config.Form>]Email: Choice<string,string> option
        ///Full name.
        [<Config.Form>]Name: Choice<string,string> option
        ///Billing phone number (including extension).
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Choice<Confirm'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: Choice<string,string>, ?name: Choice<string,string>, ?phone: Choice<string,string>) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Confirm'PaymentMethodDataBoleto = {
        ///The tax ID of the customer (CPF for individual consumers or CNPJ for businesses consumers)
        [<Config.Form>]TaxId: string option
    }
    with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Confirm'PaymentMethodDataEpsBank =
    | ArzteUndApothekerBank
    | AustrianAnadiBankAg
    | BankAustria
    | BankhausCarlSpangler
    | BankhausSchelhammerUndSchatteraAg
    | BawagPskAg
    | BksBankAg
    | BrullKallmusBankAg
    | BtvVierLanderBank
    | CapitalBankGraweGruppeAg
    | DeutscheBankAg
    | Dolomitenbank
    | EasybankAg
    | ErsteBankUndSparkassen
    | HypoAlpeadriabankInternationalAg
    | HypoBankBurgenlandAktiengesellschaft
    | HypoNoeLbFurNiederosterreichUWien
    | HypoOberosterreichSalzburgSteiermark
    | HypoTirolBankAg
    | HypoVorarlbergBankAg
    | MarchfelderBank
    | OberbankAg
    | RaiffeisenBankengruppeOsterreich
    | SchoellerbankAg
    | SpardaBankWien
    | VolksbankGruppe
    | VolkskreditbankAg
    | VrBankBraunau

    type Confirm'PaymentMethodDataEps = {
        ///The customer's bank.
        [<Config.Form>]Bank: Confirm'PaymentMethodDataEpsBank option
    }
    with
        static member New(?bank: Confirm'PaymentMethodDataEpsBank) =
            {
                Bank = bank
            }

    type Confirm'PaymentMethodDataFpxAccountHolderType =
    | Company
    | Individual

    type Confirm'PaymentMethodDataFpxBank =
    | AffinBank
    | Agrobank
    | AllianceBank
    | Ambank
    | BankIslam
    | BankMuamalat
    | BankOfChina
    | BankRakyat
    | Bsn
    | Cimb
    | DeutscheBank
    | HongLeongBank
    | Hsbc
    | Kfh
    | Maybank2e
    | Maybank2u
    | Ocbc
    | PbEnterprise
    | PublicBank
    | Rhb
    | StandardChartered
    | Uob

    type Confirm'PaymentMethodDataFpx = {
        ///Account holder type for FPX transaction
        [<Config.Form>]AccountHolderType: Confirm'PaymentMethodDataFpxAccountHolderType option
        ///The customer's bank.
        [<Config.Form>]Bank: Confirm'PaymentMethodDataFpxBank option
    }
    with
        static member New(?accountHolderType: Confirm'PaymentMethodDataFpxAccountHolderType, ?bank: Confirm'PaymentMethodDataFpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type Confirm'PaymentMethodDataIdealBank =
    | AbnAmro
    | AsnBank
    | Bunq
    | Handelsbanken
    | Ing
    | Knab
    | Moneyou
    | Rabobank
    | Regiobank
    | Revolut
    | SnsBank
    | TriodosBank
    | VanLanschot
    | Yoursafe

    type Confirm'PaymentMethodDataIdeal = {
        ///The customer's bank.
        [<Config.Form>]Bank: Confirm'PaymentMethodDataIdealBank option
    }
    with
        static member New(?bank: Confirm'PaymentMethodDataIdealBank) =
            {
                Bank = bank
            }

    type Confirm'PaymentMethodDataKlarnaDob = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Confirm'PaymentMethodDataKlarna = {
        ///Customer's date of birth
        [<Config.Form>]Dob: Confirm'PaymentMethodDataKlarnaDob option
    }
    with
        static member New(?dob: Confirm'PaymentMethodDataKlarnaDob) =
            {
                Dob = dob
            }

    type Confirm'PaymentMethodDataP24Bank =
    | AliorBank
    | BankMillennium
    | BankNowyBfgSa
    | BankPekaoSa
    | BankiSpbdzielcze
    | Blik
    | BnpParibas
    | Boz
    | CitiHandlowy
    | CreditAgricole
    | Envelobank
    | EtransferPocztowy24
    | GetinBank
    | Ideabank
    | Ing
    | Inteligo
    | MbankMtransfer
    | NestPrzelew
    | NoblePay
    | PbacZIpko
    | PlusBank
    | SantanderPrzelew24
    | TmobileUsbugiBankowe
    | ToyotaBank
    | VolkswagenBank

    type Confirm'PaymentMethodDataP24 = {
        ///The customer's bank.
        [<Config.Form>]Bank: Confirm'PaymentMethodDataP24Bank option
    }
    with
        static member New(?bank: Confirm'PaymentMethodDataP24Bank) =
            {
                Bank = bank
            }

    type Confirm'PaymentMethodDataRadarOptions = {
        ///A [Radar Session](https://stripe.com/docs/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
        [<Config.Form>]Session: string option
    }
    with
        static member New(?session: string) =
            {
                Session = session
            }

    type Confirm'PaymentMethodDataSepaDebit = {
        ///IBAN of the bank account.
        [<Config.Form>]Iban: string option
    }
    with
        static member New(?iban: string) =
            {
                Iban = iban
            }

    type Confirm'PaymentMethodDataSofortCountry =
    | [<JsonUnionCase("AT")>] AT
    | [<JsonUnionCase("BE")>] BE
    | [<JsonUnionCase("DE")>] DE
    | [<JsonUnionCase("ES")>] ES
    | [<JsonUnionCase("IT")>] IT
    | [<JsonUnionCase("NL")>] NL

    type Confirm'PaymentMethodDataSofort = {
        ///Two-letter ISO code representing the country the bank account is located in.
        [<Config.Form>]Country: Confirm'PaymentMethodDataSofortCountry option
    }
    with
        static member New(?country: Confirm'PaymentMethodDataSofortCountry) =
            {
                Country = country
            }

    type Confirm'PaymentMethodDataUsBankAccountAccountHolderType =
    | Company
    | Individual

    type Confirm'PaymentMethodDataUsBankAccountAccountType =
    | Checking
    | Savings

    type Confirm'PaymentMethodDataUsBankAccount = {
        ///Account holder type: individual or company.
        [<Config.Form>]AccountHolderType: Confirm'PaymentMethodDataUsBankAccountAccountHolderType option
        ///Account number of the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Account type: checkings or savings. Defaults to checking if omitted.
        [<Config.Form>]AccountType: Confirm'PaymentMethodDataUsBankAccountAccountType option
        ///The ID of a Financial Connections Account to use as a payment method.
        [<Config.Form>]FinancialConnectionsAccount: string option
        ///Routing number of the bank account.
        [<Config.Form>]RoutingNumber: string option
    }
    with
        static member New(?accountHolderType: Confirm'PaymentMethodDataUsBankAccountAccountHolderType, ?accountNumber: string, ?accountType: Confirm'PaymentMethodDataUsBankAccountAccountType, ?financialConnectionsAccount: string, ?routingNumber: string) =
            {
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                FinancialConnectionsAccount = financialConnectionsAccount
                RoutingNumber = routingNumber
            }

    type Confirm'PaymentMethodDataType =
    | AcssDebit
    | Affirm
    | AfterpayClearpay
    | Alipay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Blik
    | Boleto
    | Cashapp
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Klarna
    | Konbini
    | Link
    | Oxxo
    | P24
    | Paynow
    | Paypal
    | Pix
    | Promptpay
    | SepaDebit
    | Sofort
    | UsBankAccount
    | WechatPay
    | Zip

    type Confirm'PaymentMethodData = {
        ///If this is an `acss_debit` PaymentMethod, this hash contains details about the ACSS Debit payment method.
        [<Config.Form>]AcssDebit: Confirm'PaymentMethodDataAcssDebit option
        ///If this is an `affirm` PaymentMethod, this hash contains details about the Affirm payment method.
        [<Config.Form>]Affirm: string option
        ///If this is an `AfterpayClearpay` PaymentMethod, this hash contains details about the AfterpayClearpay payment method.
        [<Config.Form>]AfterpayClearpay: string option
        ///If this is an `Alipay` PaymentMethod, this hash contains details about the Alipay payment method.
        [<Config.Form>]Alipay: string option
        ///If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
        [<Config.Form>]AuBecsDebit: Confirm'PaymentMethodDataAuBecsDebit option
        ///If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
        [<Config.Form>]BacsDebit: Confirm'PaymentMethodDataBacsDebit option
        ///If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
        [<Config.Form>]Bancontact: string option
        ///Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
        [<Config.Form>]BillingDetails: Confirm'PaymentMethodDataBillingDetails option
        ///If this is a `blik` PaymentMethod, this hash contains details about the BLIK payment method.
        [<Config.Form>]Blik: string option
        ///If this is a `boleto` PaymentMethod, this hash contains details about the Boleto payment method.
        [<Config.Form>]Boleto: Confirm'PaymentMethodDataBoleto option
        ///If this is a `cashapp` PaymentMethod, this hash contains details about the Cash App Pay payment method.
        [<Config.Form>]Cashapp: string option
        ///If this is a `customer_balance` PaymentMethod, this hash contains details about the CustomerBalance payment method.
        [<Config.Form>]CustomerBalance: string option
        ///If this is an `eps` PaymentMethod, this hash contains details about the EPS payment method.
        [<Config.Form>]Eps: Confirm'PaymentMethodDataEps option
        ///If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
        [<Config.Form>]Fpx: Confirm'PaymentMethodDataFpx option
        ///If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
        [<Config.Form>]Giropay: string option
        ///If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
        [<Config.Form>]Grabpay: string option
        ///If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
        [<Config.Form>]Ideal: Confirm'PaymentMethodDataIdeal option
        ///If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
        [<Config.Form>]InteracPresent: string option
        ///If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method.
        [<Config.Form>]Klarna: Confirm'PaymentMethodDataKlarna option
        ///If this is a `konbini` PaymentMethod, this hash contains details about the Konbini payment method.
        [<Config.Form>]Konbini: string option
        ///If this is an `Link` PaymentMethod, this hash contains details about the Link payment method.
        [<Config.Form>]Link: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
        [<Config.Form>]Oxxo: string option
        ///If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
        [<Config.Form>]P24: Confirm'PaymentMethodDataP24 option
        ///If this is a `paynow` PaymentMethod, this hash contains details about the PayNow payment method.
        [<Config.Form>]Paynow: string option
        ///If this is a `paypal` PaymentMethod, this hash contains details about the PayPal payment method.
        [<Config.Form>]Paypal: string option
        ///If this is a `pix` PaymentMethod, this hash contains details about the Pix payment method.
        [<Config.Form>]Pix: string option
        ///If this is a `promptpay` PaymentMethod, this hash contains details about the PromptPay payment method.
        [<Config.Form>]Promptpay: string option
        ///Options to configure Radar. See [Radar Session](https://stripe.com/docs/radar/radar-session) for more information.
        [<Config.Form>]RadarOptions: Confirm'PaymentMethodDataRadarOptions option
        ///If this is a `sepa_debit` PaymentMethod, this hash contains details about the SEPA debit bank account.
        [<Config.Form>]SepaDebit: Confirm'PaymentMethodDataSepaDebit option
        ///If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
        [<Config.Form>]Sofort: Confirm'PaymentMethodDataSofort option
        ///The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
        [<Config.Form>]Type: Confirm'PaymentMethodDataType option
        ///If this is an `us_bank_account` PaymentMethod, this hash contains details about the US bank account payment method.
        [<Config.Form>]UsBankAccount: Confirm'PaymentMethodDataUsBankAccount option
        ///If this is an `wechat_pay` PaymentMethod, this hash contains details about the wechat_pay payment method.
        [<Config.Form>]WechatPay: string option
        ///If this is a `zip` PaymentMethod, this hash contains details about the Zip payment method.
        [<Config.Form>]Zip: string option
    }
    with
        static member New(?acssDebit: Confirm'PaymentMethodDataAcssDebit, ?konbini: string, ?link: string, ?metadata: Map<string, string>, ?oxxo: string, ?p24: Confirm'PaymentMethodDataP24, ?paynow: string, ?klarna: Confirm'PaymentMethodDataKlarna, ?paypal: string, ?promptpay: string, ?radarOptions: Confirm'PaymentMethodDataRadarOptions, ?sepaDebit: Confirm'PaymentMethodDataSepaDebit, ?sofort: Confirm'PaymentMethodDataSofort, ?type': Confirm'PaymentMethodDataType, ?usBankAccount: Confirm'PaymentMethodDataUsBankAccount, ?pix: string, ?wechatPay: string, ?interacPresent: string, ?grabpay: string, ?affirm: string, ?afterpayClearpay: string, ?alipay: string, ?auBecsDebit: Confirm'PaymentMethodDataAuBecsDebit, ?bacsDebit: Confirm'PaymentMethodDataBacsDebit, ?bancontact: string, ?ideal: Confirm'PaymentMethodDataIdeal, ?billingDetails: Confirm'PaymentMethodDataBillingDetails, ?boleto: Confirm'PaymentMethodDataBoleto, ?cashapp: string, ?customerBalance: string, ?eps: Confirm'PaymentMethodDataEps, ?fpx: Confirm'PaymentMethodDataFpx, ?giropay: string, ?blik: string, ?zip: string) =
            {
                AcssDebit = acssDebit
                Affirm = affirm
                AfterpayClearpay = afterpayClearpay
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                BillingDetails = billingDetails
                Blik = blik
                Boleto = boleto
                Cashapp = cashapp
                CustomerBalance = customerBalance
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Klarna = klarna
                Konbini = konbini
                Link = link
                Metadata = metadata
                Oxxo = oxxo
                P24 = p24
                Paynow = paynow
                Paypal = paypal
                Pix = pix
                Promptpay = promptpay
                RadarOptions = radarOptions
                SepaDebit = sepaDebit
                Sofort = sofort
                Type = type'
                UsBankAccount = usBankAccount
                WechatPay = wechatPay
                Zip = zip
            }

    type Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsPaymentSchedule =
    | Combined
    | Interval
    | Sporadic

    type Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsTransactionType =
    | Business
    | Personal

    type Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptions = {
        ///A URL for custom mandate text to render during confirmation step.
        ///The URL will be rendered with additional GET parameters `payment_intent` and `payment_intent_client_secret` when confirming a Payment Intent,
        ///or `setup_intent` and `setup_intent_client_secret` when confirming a Setup Intent.
        [<Config.Form>]CustomMandateUrl: Choice<string,string> option
        ///Description of the mandate interval. Only required if 'payment_schedule' parameter is 'interval' or 'combined'.
        [<Config.Form>]IntervalDescription: string option
        ///Payment schedule for the mandate.
        [<Config.Form>]PaymentSchedule: Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsPaymentSchedule option
        ///Transaction type of the mandate.
        [<Config.Form>]TransactionType: Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsTransactionType option
    }
    with
        static member New(?customMandateUrl: Choice<string,string>, ?intervalDescription: string, ?paymentSchedule: Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsPaymentSchedule, ?transactionType: Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptionsTransactionType) =
            {
                CustomMandateUrl = customMandateUrl
                IntervalDescription = intervalDescription
                PaymentSchedule = paymentSchedule
                TransactionType = transactionType
            }

    type Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptions = {
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptions option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?mandateOptions: Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsMandateOptions, ?setupFutureUsage: Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage, ?verificationMethod: Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptionsVerificationMethod) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
                VerificationMethod = verificationMethod
            }

    type Confirm'PaymentMethodOptionsAffirmPaymentMethodOptionsCaptureMethod =
    | Manual

    type Confirm'PaymentMethodOptionsAffirmPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsAffirmPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Confirm'PaymentMethodOptionsAffirmPaymentMethodOptionsCaptureMethod option
        ///Preferred language of the Affirm authorization page that the customer is redirected to.
        [<Config.Form>]PreferredLocale: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsAffirmPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Confirm'PaymentMethodOptionsAffirmPaymentMethodOptionsCaptureMethod, ?preferredLocale: string, ?setupFutureUsage: Confirm'PaymentMethodOptionsAffirmPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PreferredLocale = preferredLocale
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsCaptureMethod =
    | Manual

    type Confirm'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Confirm'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsCaptureMethod option
        ///Order identifier shown to the customer in Afterpay’s online portal. We recommend using a value that helps you answer any questions a customer might have about
        ///the payment. The identifier is limited to 128 characters and may contain only letters, digits, underscores, backslashes and dashes.
        [<Config.Form>]Reference: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Confirm'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsCaptureMethod, ?reference: string, ?setupFutureUsage: Confirm'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                Reference = reference
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsAlipayPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Confirm'PaymentMethodOptionsAlipayPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsAlipayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Confirm'PaymentMethodOptionsAlipayPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Confirm'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Confirm'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsBacsDebitPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Confirm'PaymentMethodOptionsBacsDebitPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsBacsDebitPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Confirm'PaymentMethodOptionsBacsDebitPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Fr
    | Nl

    type Confirm'PaymentMethodOptionsBancontactPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Confirm'PaymentMethodOptionsBancontactPaymentMethodOptions = {
        ///Preferred language of the Bancontact authorization page that the customer is redirected to.
        [<Config.Form>]PreferredLanguage: Confirm'PaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsBancontactPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?preferredLanguage: Confirm'PaymentMethodOptionsBancontactPaymentMethodOptionsPreferredLanguage, ?setupFutureUsage: Confirm'PaymentMethodOptionsBancontactPaymentMethodOptionsSetupFutureUsage) =
            {
                PreferredLanguage = preferredLanguage
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsBlikPaymentIntentPaymentMethodOptions = {
        ///The 6-digit BLIK code that a customer has generated using their banking application. Can only be set on confirmation.
        [<Config.Form>]Code: string option
    }
    with
        static member New(?code: string) =
            {
                Code = code
            }

    type Confirm'PaymentMethodOptionsBoletoPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Confirm'PaymentMethodOptionsBoletoPaymentMethodOptions = {
        ///The number of calendar days before a Boleto voucher expires. For example, if you create a Boleto voucher on Monday and you set expires_after_days to 2, the Boleto invoice will expire on Wednesday at 23:59 America/Sao_Paulo time.
        [<Config.Form>]ExpiresAfterDays: int option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsBoletoPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Confirm'PaymentMethodOptionsBoletoPaymentMethodOptionsSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval =
    | Month

    type Confirm'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType =
    | FixedCount

    type Confirm'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan = {
        ///For `fixed_count` installment plans, this is the number of installment payments your customer will make to their credit card.
        [<Config.Form>]Count: int option
        ///For `fixed_count` installment plans, this is the interval between installment payments your customer will make to their credit card.
        ///One of `month`.
        [<Config.Form>]Interval: Confirm'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval option
        ///Type of installment plan, one of `fixed_count`.
        [<Config.Form>]Type: Confirm'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType option
    }
    with
        static member New(?count: int, ?interval: Confirm'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanInterval, ?type': Confirm'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlanType) =
            {
                Count = count
                Interval = interval
                Type = type'
            }

    type Confirm'PaymentMethodOptionsCardPaymentIntentInstallments = {
        ///Setting to true enables installments for this PaymentIntent.
        ///This will cause the response to contain a list of available installment plans.
        ///Setting to false will prevent any selected plan from applying to a charge.
        [<Config.Form>]Enabled: bool option
        ///The selected installment plan to use for this payment attempt.
        ///This parameter can only be provided during confirmation.
        [<Config.Form>]Plan: Choice<Confirm'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string> option
    }
    with
        static member New(?enabled: bool, ?plan: Choice<Confirm'PaymentMethodOptionsCardPaymentIntentInstallmentsPlanInstallmentPlan,string>) =
            {
                Enabled = enabled
                Plan = plan
            }

    type Confirm'PaymentMethodOptionsCardPaymentIntentMandateOptionsSupportedTypes =
    | India

    type Confirm'PaymentMethodOptionsCardPaymentIntentMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Confirm'PaymentMethodOptionsCardPaymentIntentMandateOptionsInterval =
    | Day
    | Month
    | Sporadic
    | Week
    | Year

    type Confirm'PaymentMethodOptionsCardPaymentIntentMandateOptions = {
        ///Amount to be charged for future payments.
        [<Config.Form>]Amount: int option
        ///One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
        [<Config.Form>]AmountType: Confirm'PaymentMethodOptionsCardPaymentIntentMandateOptionsAmountType option
        ///A description of the mandate or subscription that is meant to be displayed to the customer.
        [<Config.Form>]Description: string option
        ///End date of the mandate or subscription. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.
        [<Config.Form>]EndDate: DateTime option
        ///Specifies payment frequency. One of `day`, `week`, `month`, `year`, or `sporadic`.
        [<Config.Form>]Interval: Confirm'PaymentMethodOptionsCardPaymentIntentMandateOptionsInterval option
        ///The number of intervals between payments. For example, `interval=month` and `interval_count=3` indicates one payment every three months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks). This parameter is optional when `interval=sporadic`.
        [<Config.Form>]IntervalCount: int option
        ///Unique identifier for the mandate or subscription.
        [<Config.Form>]Reference: string option
        ///Start date of the mandate or subscription. Start date should not be lesser than yesterday.
        [<Config.Form>]StartDate: DateTime option
        ///Specifies the type of mandates supported. Possible values are `india`.
        [<Config.Form>]SupportedTypes: Confirm'PaymentMethodOptionsCardPaymentIntentMandateOptionsSupportedTypes list option
    }
    with
        static member New(?amount: int, ?amountType: Confirm'PaymentMethodOptionsCardPaymentIntentMandateOptionsAmountType, ?description: string, ?endDate: DateTime, ?interval: Confirm'PaymentMethodOptionsCardPaymentIntentMandateOptionsInterval, ?intervalCount: int, ?reference: string, ?startDate: DateTime, ?supportedTypes: Confirm'PaymentMethodOptionsCardPaymentIntentMandateOptionsSupportedTypes list) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
                Interval = interval
                IntervalCount = intervalCount
                Reference = reference
                StartDate = startDate
                SupportedTypes = supportedTypes
            }

    type Confirm'PaymentMethodOptionsCardPaymentIntentCaptureMethod =
    | Manual

    type Confirm'PaymentMethodOptionsCardPaymentIntentNetwork =
    | Amex
    | CartesBancaires
    | Diners
    | Discover
    | EftposAu
    | Interac
    | Jcb
    | Mastercard
    | Unionpay
    | Unknown
    | Visa

    type Confirm'PaymentMethodOptionsCardPaymentIntentRequestThreeDSecure =
    | Any
    | Automatic

    type Confirm'PaymentMethodOptionsCardPaymentIntentSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Confirm'PaymentMethodOptionsCardPaymentIntent = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Confirm'PaymentMethodOptionsCardPaymentIntentCaptureMethod option
        ///A single-use `cvc_update` Token that represents a card CVC value. When provided, the CVC value will be verified during the card payment attempt. This parameter can only be provided during confirmation.
        [<Config.Form>]CvcToken: string option
        ///Installment configuration for payments attempted on this PaymentIntent (Mexico Only).
        ///For more information, see the [installments integration guide](https://stripe.com/docs/payments/installments).
        [<Config.Form>]Installments: Confirm'PaymentMethodOptionsCardPaymentIntentInstallments option
        ///Configuration options for setting up an eMandate for cards issued in India.
        [<Config.Form>]MandateOptions: Confirm'PaymentMethodOptionsCardPaymentIntentMandateOptions option
        ///When specified, this parameter indicates that a transaction will be marked
        ///as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
        ///parameter can only be provided during confirmation.
        [<Config.Form>]Moto: bool option
        ///Selected network to process this PaymentIntent on. Depends on the available networks of the card attached to the PaymentIntent. Can be only set confirm-time.
        [<Config.Form>]Network: Confirm'PaymentMethodOptionsCardPaymentIntentNetwork option
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        [<Config.Form>]RequestThreeDSecure: Confirm'PaymentMethodOptionsCardPaymentIntentRequestThreeDSecure option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsCardPaymentIntentSetupFutureUsage option
        ///Provides information about a card payment that customers see on their statements. Concatenated with the Kana prefix (shortened Kana descriptor) or Kana statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 22 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 22 characters.
        [<Config.Form>]StatementDescriptorSuffixKana: Choice<string,string> option
        ///Provides information about a card payment that customers see on their statements. Concatenated with the Kanji prefix (shortened Kanji descriptor) or Kanji statement descriptor that’s set on the account to form the complete statement descriptor. Maximum 17 characters. On card statements, the *concatenation* of both prefix and suffix (including separators) will appear truncated to 17 characters.
        [<Config.Form>]StatementDescriptorSuffixKanji: Choice<string,string> option
    }
    with
        static member New(?captureMethod: Confirm'PaymentMethodOptionsCardPaymentIntentCaptureMethod, ?cvcToken: string, ?installments: Confirm'PaymentMethodOptionsCardPaymentIntentInstallments, ?mandateOptions: Confirm'PaymentMethodOptionsCardPaymentIntentMandateOptions, ?moto: bool, ?network: Confirm'PaymentMethodOptionsCardPaymentIntentNetwork, ?requestThreeDSecure: Confirm'PaymentMethodOptionsCardPaymentIntentRequestThreeDSecure, ?setupFutureUsage: Confirm'PaymentMethodOptionsCardPaymentIntentSetupFutureUsage, ?statementDescriptorSuffixKana: Choice<string,string>, ?statementDescriptorSuffixKanji: Choice<string,string>) =
            {
                CaptureMethod = captureMethod
                CvcToken = cvcToken
                Installments = installments
                MandateOptions = mandateOptions
                Moto = moto
                Network = network
                RequestThreeDSecure = requestThreeDSecure
                SetupFutureUsage = setupFutureUsage
                StatementDescriptorSuffixKana = statementDescriptorSuffixKana
                StatementDescriptorSuffixKanji = statementDescriptorSuffixKanji
            }

    type Confirm'PaymentMethodOptionsCardPresentPaymentMethodOptions = {
        ///Request ability to capture this payment beyond the standard [authorization validity window](https://stripe.com/docs/terminal/features/extended-authorizations#authorization-validity)
        [<Config.Form>]RequestExtendedAuthorization: bool option
        ///Request ability to [increment](https://stripe.com/docs/terminal/features/incremental-authorizations) this PaymentIntent if the combination of MCC and card brand is eligible. Check [incremental_authorization_supported](https://stripe.com/docs/api/charges/object#charge_object-payment_method_details-card_present-incremental_authorization_supported) in the [Confirm](https://stripe.com/docs/api/payment_intents/confirm) response to verify support.
        [<Config.Form>]RequestIncrementalAuthorizationSupport: bool option
    }
    with
        static member New(?requestExtendedAuthorization: bool, ?requestIncrementalAuthorizationSupport: bool) =
            {
                RequestExtendedAuthorization = requestExtendedAuthorization
                RequestIncrementalAuthorizationSupport = requestIncrementalAuthorizationSupport
            }

    type Confirm'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsCaptureMethod =
    | Manual

    type Confirm'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Confirm'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Confirm'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsCaptureMethod option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Confirm'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsCaptureMethod, ?setupFutureUsage: Confirm'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferEuBankTransfer = {
        ///The desired country code of the bank account information. Permitted values include: `BE`, `DE`, `ES`, `FR`, `IE`, or `NL`.
        [<Config.Form>]Country: string option
    }
    with
        static member New(?country: string) =
            {
                Country = country
            }

    type Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferRequestedAddressTypes =
    | Aba
    | Iban
    | Sepa
    | SortCode
    | Spei
    | Swift
    | Zengin

    type Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferType =
    | EuBankTransfer
    | GbBankTransfer
    | JpBankTransfer
    | MxBankTransfer
    | UsBankTransfer

    type Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransfer = {
        ///Configuration for the eu_bank_transfer funding type.
        [<Config.Form>]EuBankTransfer: Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferEuBankTransfer option
        ///List of address types that should be returned in the financial_addresses response. If not specified, all valid types will be returned.
        ///Permitted values include: `sort_code`, `zengin`, `iban`, or `spei`.
        [<Config.Form>]RequestedAddressTypes: Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferRequestedAddressTypes list option
        ///The list of bank transfer types that this PaymentIntent is allowed to use for funding Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.
        [<Config.Form>]Type: Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferType option
    }
    with
        static member New(?euBankTransfer: Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferEuBankTransfer, ?requestedAddressTypes: Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferRequestedAddressTypes list, ?type': Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransferType) =
            {
                EuBankTransfer = euBankTransfer
                RequestedAddressTypes = requestedAddressTypes
                Type = type'
            }

    type Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsFundingType =
    | BankTransfer

    type Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptions = {
        ///Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.
        [<Config.Form>]BankTransfer: Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransfer option
        ///The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.
        [<Config.Form>]FundingType: Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsFundingType option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?bankTransfer: Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsBankTransfer, ?fundingType: Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsFundingType, ?setupFutureUsage: Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Confirm'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsFpxPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsFpxPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsFpxPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Confirm'PaymentMethodOptionsFpxPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsGiropayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsGiropayPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsGiropayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Confirm'PaymentMethodOptionsGiropayPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsGrabpayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsGrabpayPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsGrabpayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Confirm'PaymentMethodOptionsGrabpayPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsIdealPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Confirm'PaymentMethodOptionsIdealPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsIdealPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Confirm'PaymentMethodOptionsIdealPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsKlarnaPaymentMethodOptionsCaptureMethod =
    | Manual

    type Confirm'PaymentMethodOptionsKlarnaPaymentMethodOptionsPreferredLocale =
    | [<JsonUnionCase("cs-CZ")>] CsCZ
    | [<JsonUnionCase("da-DK")>] DaDK
    | [<JsonUnionCase("de-AT")>] DeAT
    | [<JsonUnionCase("de-CH")>] DeCH
    | [<JsonUnionCase("de-DE")>] DeDE
    | [<JsonUnionCase("el-GR")>] ElGR
    | [<JsonUnionCase("en-AT")>] EnAT
    | [<JsonUnionCase("en-AU")>] EnAU
    | [<JsonUnionCase("en-BE")>] EnBE
    | [<JsonUnionCase("en-CA")>] EnCA
    | [<JsonUnionCase("en-CH")>] EnCH
    | [<JsonUnionCase("en-CZ")>] EnCZ
    | [<JsonUnionCase("en-DE")>] EnDE
    | [<JsonUnionCase("en-DK")>] EnDK
    | [<JsonUnionCase("en-ES")>] EnES
    | [<JsonUnionCase("en-FI")>] EnFI
    | [<JsonUnionCase("en-FR")>] EnFR
    | [<JsonUnionCase("en-GB")>] EnGB
    | [<JsonUnionCase("en-GR")>] EnGR
    | [<JsonUnionCase("en-IE")>] EnIE
    | [<JsonUnionCase("en-IT")>] EnIT
    | [<JsonUnionCase("en-NL")>] EnNL
    | [<JsonUnionCase("en-NO")>] EnNO
    | [<JsonUnionCase("en-NZ")>] EnNZ
    | [<JsonUnionCase("en-PL")>] EnPL
    | [<JsonUnionCase("en-PT")>] EnPT
    | [<JsonUnionCase("en-SE")>] EnSE
    | [<JsonUnionCase("en-US")>] EnUS
    | [<JsonUnionCase("es-ES")>] EsES
    | [<JsonUnionCase("es-US")>] EsUS
    | [<JsonUnionCase("fi-FI")>] FiFI
    | [<JsonUnionCase("fr-BE")>] FrBE
    | [<JsonUnionCase("fr-CA")>] FrCA
    | [<JsonUnionCase("fr-CH")>] FrCH
    | [<JsonUnionCase("fr-FR")>] FrFR
    | [<JsonUnionCase("it-CH")>] ItCH
    | [<JsonUnionCase("it-IT")>] ItIT
    | [<JsonUnionCase("nb-NO")>] NbNO
    | [<JsonUnionCase("nl-BE")>] NlBE
    | [<JsonUnionCase("nl-NL")>] NlNL
    | [<JsonUnionCase("pl-PL")>] PlPL
    | [<JsonUnionCase("pt-PT")>] PtPT
    | [<JsonUnionCase("sv-FI")>] SvFI
    | [<JsonUnionCase("sv-SE")>] SvSE

    type Confirm'PaymentMethodOptionsKlarnaPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsKlarnaPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Confirm'PaymentMethodOptionsKlarnaPaymentMethodOptionsCaptureMethod option
        ///Preferred language of the Klarna authorization page that the customer is redirected to
        [<Config.Form>]PreferredLocale: Confirm'PaymentMethodOptionsKlarnaPaymentMethodOptionsPreferredLocale option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsKlarnaPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Confirm'PaymentMethodOptionsKlarnaPaymentMethodOptionsCaptureMethod, ?preferredLocale: Confirm'PaymentMethodOptionsKlarnaPaymentMethodOptionsPreferredLocale, ?setupFutureUsage: Confirm'PaymentMethodOptionsKlarnaPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PreferredLocale = preferredLocale
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsKonbiniPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsKonbiniPaymentMethodOptions = {
        ///An optional 10 to 11 digit numeric-only string determining the confirmation code at applicable convenience stores. Must not consist of only zeroes and could be rejected in case of insufficient uniqueness. We recommend to use the customer's phone number.
        [<Config.Form>]ConfirmationNumber: Choice<string,string> option
        ///The number of calendar days (between 1 and 60) after which Konbini payment instructions will expire. For example, if a PaymentIntent is confirmed with Konbini and `expires_after_days` set to 2 on Monday JST, the instructions will expire on Wednesday 23:59:59 JST. Defaults to 3 days.
        [<Config.Form>]ExpiresAfterDays: Choice<int,string> option
        ///The timestamp at which the Konbini payment instructions will expire. Only one of `expires_after_days` or `expires_at` may be set.
        [<Config.Form>]ExpiresAt: Choice<DateTime,string> option
        ///A product descriptor of up to 22 characters, which will appear to customers at the convenience store.
        [<Config.Form>]ProductDescription: Choice<string,string> option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsKonbiniPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?confirmationNumber: Choice<string,string>, ?expiresAfterDays: Choice<int,string>, ?expiresAt: Choice<DateTime,string>, ?productDescription: Choice<string,string>, ?setupFutureUsage: Confirm'PaymentMethodOptionsKonbiniPaymentMethodOptionsSetupFutureUsage) =
            {
                ConfirmationNumber = confirmationNumber
                ExpiresAfterDays = expiresAfterDays
                ExpiresAt = expiresAt
                ProductDescription = productDescription
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsCaptureMethod =
    | Manual

    type Confirm'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Confirm'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        ///If provided, this parameter will override the top-level `capture_method` when finalizing the payment with this payment method type.
        ///If `capture_method` is already set on the PaymentIntent, providing an empty value for this parameter will unset the stored value for this payment method type.
        [<Config.Form>]CaptureMethod: Confirm'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsCaptureMethod option
        ///[Deprecated] This is a legacy parameter that no longer has any function.
        [<Config.Form>]PersistentToken: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Confirm'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsCaptureMethod, ?persistentToken: string, ?setupFutureUsage: Confirm'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PersistentToken = persistentToken
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsOxxoPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsOxxoPaymentMethodOptions = {
        ///The number of calendar days before an OXXO voucher expires. For example, if you create an OXXO voucher on Monday and you set expires_after_days to 2, the OXXO invoice will expire on Wednesday at 23:59 America/Mexico_City time.
        [<Config.Form>]ExpiresAfterDays: int option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsOxxoPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?expiresAfterDays: int, ?setupFutureUsage: Confirm'PaymentMethodOptionsOxxoPaymentMethodOptionsSetupFutureUsage) =
            {
                ExpiresAfterDays = expiresAfterDays
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsP24PaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsP24PaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsP24PaymentMethodOptionsSetupFutureUsage option
        ///Confirm that the payer has accepted the P24 terms and conditions.
        [<Config.Form>]TosShownAndAccepted: bool option
    }
    with
        static member New(?setupFutureUsage: Confirm'PaymentMethodOptionsP24PaymentMethodOptionsSetupFutureUsage, ?tosShownAndAccepted: bool) =
            {
                SetupFutureUsage = setupFutureUsage
                TosShownAndAccepted = tosShownAndAccepted
            }

    type Confirm'PaymentMethodOptionsPaynowPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsPaynowPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsPaynowPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Confirm'PaymentMethodOptionsPaynowPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsPaypalPaymentMethodOptionsCaptureMethod =
    | Manual

    type Confirm'PaymentMethodOptionsPaypalPaymentMethodOptionsPreferredLocale =
    | [<JsonUnionCase("cs-CZ")>] CsCZ
    | [<JsonUnionCase("da-DK")>] DaDK
    | [<JsonUnionCase("de-AT")>] DeAT
    | [<JsonUnionCase("de-DE")>] DeDE
    | [<JsonUnionCase("de-LU")>] DeLU
    | [<JsonUnionCase("el-GR")>] ElGR
    | [<JsonUnionCase("en-GB")>] EnGB
    | [<JsonUnionCase("en-US")>] EnUS
    | [<JsonUnionCase("es-ES")>] EsES
    | [<JsonUnionCase("fi-FI")>] FiFI
    | [<JsonUnionCase("fr-BE")>] FrBE
    | [<JsonUnionCase("fr-FR")>] FrFR
    | [<JsonUnionCase("fr-LU")>] FrLU
    | [<JsonUnionCase("hu-HU")>] HuHU
    | [<JsonUnionCase("it-IT")>] ItIT
    | [<JsonUnionCase("nl-BE")>] NlBE
    | [<JsonUnionCase("nl-NL")>] NlNL
    | [<JsonUnionCase("pl-PL")>] PlPL
    | [<JsonUnionCase("pt-PT")>] PtPT
    | [<JsonUnionCase("sk-SK")>] SkSK
    | [<JsonUnionCase("sv-SE")>] SvSE

    type Confirm'PaymentMethodOptionsPaypalPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Confirm'PaymentMethodOptionsPaypalPaymentMethodOptions = {
        ///Controls when the funds will be captured from the customer's account.
        [<Config.Form>]CaptureMethod: Confirm'PaymentMethodOptionsPaypalPaymentMethodOptionsCaptureMethod option
        ///[Preferred locale](https://stripe.com/docs/payments/paypal/supported-locales) of the PayPal checkout page that the customer is redirected to.
        [<Config.Form>]PreferredLocale: Confirm'PaymentMethodOptionsPaypalPaymentMethodOptionsPreferredLocale option
        ///A reference of the PayPal transaction visible to customer which is mapped to PayPal's invoice ID. This must be a globally unique ID if you have configured in your PayPal settings to block multiple payments per invoice ID.
        [<Config.Form>]Reference: string option
        ///The risk correlation ID for an on-session payment using a saved PayPal payment method.
        [<Config.Form>]RiskCorrelationId: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsPaypalPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?captureMethod: Confirm'PaymentMethodOptionsPaypalPaymentMethodOptionsCaptureMethod, ?preferredLocale: Confirm'PaymentMethodOptionsPaypalPaymentMethodOptionsPreferredLocale, ?reference: string, ?riskCorrelationId: string, ?setupFutureUsage: Confirm'PaymentMethodOptionsPaypalPaymentMethodOptionsSetupFutureUsage) =
            {
                CaptureMethod = captureMethod
                PreferredLocale = preferredLocale
                Reference = reference
                RiskCorrelationId = riskCorrelationId
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsPixPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsPixPaymentMethodOptions = {
        ///The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.
        [<Config.Form>]ExpiresAfterSeconds: int option
        ///The timestamp at which the Pix expires (between 10 and 1209600 seconds in the future). Defaults to 1 day in the future.
        [<Config.Form>]ExpiresAt: DateTime option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsPixPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?expiresAfterSeconds: int, ?expiresAt: DateTime, ?setupFutureUsage: Confirm'PaymentMethodOptionsPixPaymentMethodOptionsSetupFutureUsage) =
            {
                ExpiresAfterSeconds = expiresAfterSeconds
                ExpiresAt = expiresAt
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsPromptpayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsPromptpayPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsPromptpayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Confirm'PaymentMethodOptionsPromptpayPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Confirm'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions = {
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?mandateOptions: string, ?setupFutureUsage: Confirm'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptionsSetupFutureUsage) =
            {
                MandateOptions = mandateOptions
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Es
    | Fr
    | It
    | Nl
    | Pl

    type Confirm'PaymentMethodOptionsSofortPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession

    type Confirm'PaymentMethodOptionsSofortPaymentMethodOptions = {
        ///Language shown to the payer on redirect.
        [<Config.Form>]PreferredLanguage: Confirm'PaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsSofortPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?preferredLanguage: Confirm'PaymentMethodOptionsSofortPaymentMethodOptionsPreferredLanguage, ?setupFutureUsage: Confirm'PaymentMethodOptionsSofortPaymentMethodOptionsSetupFutureUsage) =
            {
                PreferredLanguage = preferredLanguage
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPrefetch =
    | Balances

    type Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnections = {
        ///The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
        [<Config.Form>]Permissions: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPermissions list option
        ///List of data features that you would like to retrieve upon account creation.
        [<Config.Form>]Prefetch: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPrefetch list option
        ///For webview integrations only. Upon completing OAuth login in the native browser, the user will be redirected to this URL to return to your app.
        [<Config.Form>]ReturnUrl: string option
    }
    with
        static member New(?permissions: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPermissions list, ?prefetch: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnectionsPrefetch list, ?returnUrl: string) =
            {
                Permissions = permissions
                Prefetch = prefetch
                ReturnUrl = returnUrl
            }

    type Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworksRequested =
    | Ach
    | UsDomesticWire

    type Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworks = {
        ///Triggers validations to run across the selected networks
        [<Config.Form>]Requested: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworksRequested list option
    }
    with
        static member New(?requested: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworksRequested list) =
            {
                Requested = requested
            }

    type Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsPreferredSettlementSpeed =
    | Fastest
    | Standard

    type Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsSetupFutureUsage =
    | None'
    | OffSession
    | OnSession

    type Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptions = {
        ///Additional fields for Financial Connections Session creation
        [<Config.Form>]FinancialConnections: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnections option
        ///Additional fields for network related functions
        [<Config.Form>]Networks: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworks option
        ///Preferred transaction settlement speed
        [<Config.Form>]PreferredSettlementSpeed: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsPreferredSettlementSpeed option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsSetupFutureUsage option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?financialConnections: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsFinancialConnections, ?networks: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsNetworks, ?preferredSettlementSpeed: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsPreferredSettlementSpeed, ?setupFutureUsage: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsSetupFutureUsage, ?verificationMethod: Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptionsVerificationMethod) =
            {
                FinancialConnections = financialConnections
                Networks = networks
                PreferredSettlementSpeed = preferredSettlementSpeed
                SetupFutureUsage = setupFutureUsage
                VerificationMethod = verificationMethod
            }

    type Confirm'PaymentMethodOptionsWechatPayPaymentMethodOptionsClient =
    | Android
    | Ios
    | Web

    type Confirm'PaymentMethodOptionsWechatPayPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsWechatPayPaymentMethodOptions = {
        ///The app ID registered with WeChat Pay. Only required when client is ios or android.
        [<Config.Form>]AppId: string option
        ///The client type that the end customer will pay from
        [<Config.Form>]Client: Confirm'PaymentMethodOptionsWechatPayPaymentMethodOptionsClient option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsWechatPayPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?appId: string, ?client: Confirm'PaymentMethodOptionsWechatPayPaymentMethodOptionsClient, ?setupFutureUsage: Confirm'PaymentMethodOptionsWechatPayPaymentMethodOptionsSetupFutureUsage) =
            {
                AppId = appId
                Client = client
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptionsZipPaymentMethodOptionsSetupFutureUsage =
    | None'

    type Confirm'PaymentMethodOptionsZipPaymentMethodOptions = {
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'PaymentMethodOptionsZipPaymentMethodOptionsSetupFutureUsage option
    }
    with
        static member New(?setupFutureUsage: Confirm'PaymentMethodOptionsZipPaymentMethodOptionsSetupFutureUsage) =
            {
                SetupFutureUsage = setupFutureUsage
            }

    type Confirm'PaymentMethodOptions = {
        ///If this is a `acss_debit` PaymentMethod, this sub-hash contains details about the ACSS Debit payment method options.
        [<Config.Form>]AcssDebit: Choice<Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptions,string> option
        ///If this is an `affirm` PaymentMethod, this sub-hash contains details about the Affirm payment method options.
        [<Config.Form>]Affirm: Choice<Confirm'PaymentMethodOptionsAffirmPaymentMethodOptions,string> option
        ///If this is a `afterpay_clearpay` PaymentMethod, this sub-hash contains details about the Afterpay Clearpay payment method options.
        [<Config.Form>]AfterpayClearpay: Choice<Confirm'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptions,string> option
        ///If this is a `alipay` PaymentMethod, this sub-hash contains details about the Alipay payment method options.
        [<Config.Form>]Alipay: Choice<Confirm'PaymentMethodOptionsAlipayPaymentMethodOptions,string> option
        ///If this is a `au_becs_debit` PaymentMethod, this sub-hash contains details about the AU BECS Direct Debit payment method options.
        [<Config.Form>]AuBecsDebit: Choice<Confirm'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `bacs_debit` PaymentMethod, this sub-hash contains details about the BACS Debit payment method options.
        [<Config.Form>]BacsDebit: Choice<Confirm'PaymentMethodOptionsBacsDebitPaymentMethodOptions,string> option
        ///If this is a `bancontact` PaymentMethod, this sub-hash contains details about the Bancontact payment method options.
        [<Config.Form>]Bancontact: Choice<Confirm'PaymentMethodOptionsBancontactPaymentMethodOptions,string> option
        ///If this is a `blik` PaymentMethod, this sub-hash contains details about the BLIK payment method options.
        [<Config.Form>]Blik: Choice<Confirm'PaymentMethodOptionsBlikPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `boleto` PaymentMethod, this sub-hash contains details about the Boleto payment method options.
        [<Config.Form>]Boleto: Choice<Confirm'PaymentMethodOptionsBoletoPaymentMethodOptions,string> option
        ///Configuration for any card payments attempted on this PaymentIntent.
        [<Config.Form>]Card: Choice<Confirm'PaymentMethodOptionsCardPaymentIntent,string> option
        ///If this is a `card_present` PaymentMethod, this sub-hash contains details about the Card Present payment method options.
        [<Config.Form>]CardPresent: Choice<Confirm'PaymentMethodOptionsCardPresentPaymentMethodOptions,string> option
        ///If this is a `cashapp` PaymentMethod, this sub-hash contains details about the Cash App Pay payment method options.
        [<Config.Form>]Cashapp: Choice<Confirm'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `customer balance` PaymentMethod, this sub-hash contains details about the customer balance payment method options.
        [<Config.Form>]CustomerBalance: Choice<Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptions,string> option
        ///If this is a `eps` PaymentMethod, this sub-hash contains details about the EPS payment method options.
        [<Config.Form>]Eps: Choice<Confirm'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `fpx` PaymentMethod, this sub-hash contains details about the FPX payment method options.
        [<Config.Form>]Fpx: Choice<Confirm'PaymentMethodOptionsFpxPaymentMethodOptions,string> option
        ///If this is a `giropay` PaymentMethod, this sub-hash contains details about the Giropay payment method options.
        [<Config.Form>]Giropay: Choice<Confirm'PaymentMethodOptionsGiropayPaymentMethodOptions,string> option
        ///If this is a `grabpay` PaymentMethod, this sub-hash contains details about the Grabpay payment method options.
        [<Config.Form>]Grabpay: Choice<Confirm'PaymentMethodOptionsGrabpayPaymentMethodOptions,string> option
        ///If this is a `ideal` PaymentMethod, this sub-hash contains details about the Ideal payment method options.
        [<Config.Form>]Ideal: Choice<Confirm'PaymentMethodOptionsIdealPaymentMethodOptions,string> option
        ///If this is a `interac_present` PaymentMethod, this sub-hash contains details about the Card Present payment method options.
        [<Config.Form>]InteracPresent: Choice<string,string> option
        ///If this is a `klarna` PaymentMethod, this sub-hash contains details about the Klarna payment method options.
        [<Config.Form>]Klarna: Choice<Confirm'PaymentMethodOptionsKlarnaPaymentMethodOptions,string> option
        ///If this is a `konbini` PaymentMethod, this sub-hash contains details about the Konbini payment method options.
        [<Config.Form>]Konbini: Choice<Confirm'PaymentMethodOptionsKonbiniPaymentMethodOptions,string> option
        ///If this is a `link` PaymentMethod, this sub-hash contains details about the Link payment method options.
        [<Config.Form>]Link: Choice<Confirm'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `oxxo` PaymentMethod, this sub-hash contains details about the OXXO payment method options.
        [<Config.Form>]Oxxo: Choice<Confirm'PaymentMethodOptionsOxxoPaymentMethodOptions,string> option
        ///If this is a `p24` PaymentMethod, this sub-hash contains details about the Przelewy24 payment method options.
        [<Config.Form>]P24: Choice<Confirm'PaymentMethodOptionsP24PaymentMethodOptions,string> option
        ///If this is a `paynow` PaymentMethod, this sub-hash contains details about the PayNow payment method options.
        [<Config.Form>]Paynow: Choice<Confirm'PaymentMethodOptionsPaynowPaymentMethodOptions,string> option
        ///If this is a `paypal` PaymentMethod, this sub-hash contains details about the PayPal payment method options.
        [<Config.Form>]Paypal: Choice<Confirm'PaymentMethodOptionsPaypalPaymentMethodOptions,string> option
        ///If this is a `pix` PaymentMethod, this sub-hash contains details about the Pix payment method options.
        [<Config.Form>]Pix: Choice<Confirm'PaymentMethodOptionsPixPaymentMethodOptions,string> option
        ///If this is a `promptpay` PaymentMethod, this sub-hash contains details about the PromptPay payment method options.
        [<Config.Form>]Promptpay: Choice<Confirm'PaymentMethodOptionsPromptpayPaymentMethodOptions,string> option
        ///If this is a `sepa_debit` PaymentIntent, this sub-hash contains details about the SEPA Debit payment method options.
        [<Config.Form>]SepaDebit: Choice<Confirm'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `sofort` PaymentMethod, this sub-hash contains details about the SOFORT payment method options.
        [<Config.Form>]Sofort: Choice<Confirm'PaymentMethodOptionsSofortPaymentMethodOptions,string> option
        ///If this is a `us_bank_account` PaymentMethod, this sub-hash contains details about the US bank account payment method options.
        [<Config.Form>]UsBankAccount: Choice<Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptions,string> option
        ///If this is a `wechat_pay` PaymentMethod, this sub-hash contains details about the WeChat Pay payment method options.
        [<Config.Form>]WechatPay: Choice<Confirm'PaymentMethodOptionsWechatPayPaymentMethodOptions,string> option
        ///If this is a `zip` PaymentMethod, this sub-hash contains details about the Zip payment method options.
        [<Config.Form>]Zip: Choice<Confirm'PaymentMethodOptionsZipPaymentMethodOptions,string> option
    }
    with
        static member New(?acssDebit: Choice<Confirm'PaymentMethodOptionsAcssDebitPaymentIntentPaymentMethodOptions,string>, ?usBankAccount: Choice<Confirm'PaymentMethodOptionsUsBankAccountPaymentIntentPaymentMethodOptions,string>, ?sofort: Choice<Confirm'PaymentMethodOptionsSofortPaymentMethodOptions,string>, ?sepaDebit: Choice<Confirm'PaymentMethodOptionsSepaDebitPaymentIntentPaymentMethodOptions,string>, ?promptpay: Choice<Confirm'PaymentMethodOptionsPromptpayPaymentMethodOptions,string>, ?pix: Choice<Confirm'PaymentMethodOptionsPixPaymentMethodOptions,string>, ?paypal: Choice<Confirm'PaymentMethodOptionsPaypalPaymentMethodOptions,string>, ?paynow: Choice<Confirm'PaymentMethodOptionsPaynowPaymentMethodOptions,string>, ?p24: Choice<Confirm'PaymentMethodOptionsP24PaymentMethodOptions,string>, ?oxxo: Choice<Confirm'PaymentMethodOptionsOxxoPaymentMethodOptions,string>, ?link: Choice<Confirm'PaymentMethodOptionsLinkPaymentIntentPaymentMethodOptions,string>, ?konbini: Choice<Confirm'PaymentMethodOptionsKonbiniPaymentMethodOptions,string>, ?klarna: Choice<Confirm'PaymentMethodOptionsKlarnaPaymentMethodOptions,string>, ?interacPresent: Choice<string,string>, ?ideal: Choice<Confirm'PaymentMethodOptionsIdealPaymentMethodOptions,string>, ?wechatPay: Choice<Confirm'PaymentMethodOptionsWechatPayPaymentMethodOptions,string>, ?grabpay: Choice<Confirm'PaymentMethodOptionsGrabpayPaymentMethodOptions,string>, ?fpx: Choice<Confirm'PaymentMethodOptionsFpxPaymentMethodOptions,string>, ?eps: Choice<Confirm'PaymentMethodOptionsEpsPaymentIntentPaymentMethodOptions,string>, ?customerBalance: Choice<Confirm'PaymentMethodOptionsCustomerBalancePaymentIntentPaymentMethodOptions,string>, ?cashapp: Choice<Confirm'PaymentMethodOptionsCashappPaymentIntentPaymentMethodOptions,string>, ?cardPresent: Choice<Confirm'PaymentMethodOptionsCardPresentPaymentMethodOptions,string>, ?card: Choice<Confirm'PaymentMethodOptionsCardPaymentIntent,string>, ?boleto: Choice<Confirm'PaymentMethodOptionsBoletoPaymentMethodOptions,string>, ?blik: Choice<Confirm'PaymentMethodOptionsBlikPaymentIntentPaymentMethodOptions,string>, ?bancontact: Choice<Confirm'PaymentMethodOptionsBancontactPaymentMethodOptions,string>, ?bacsDebit: Choice<Confirm'PaymentMethodOptionsBacsDebitPaymentMethodOptions,string>, ?auBecsDebit: Choice<Confirm'PaymentMethodOptionsAuBecsDebitPaymentIntentPaymentMethodOptions,string>, ?alipay: Choice<Confirm'PaymentMethodOptionsAlipayPaymentMethodOptions,string>, ?afterpayClearpay: Choice<Confirm'PaymentMethodOptionsAfterpayClearpayPaymentMethodOptions,string>, ?affirm: Choice<Confirm'PaymentMethodOptionsAffirmPaymentMethodOptions,string>, ?giropay: Choice<Confirm'PaymentMethodOptionsGiropayPaymentMethodOptions,string>, ?zip: Choice<Confirm'PaymentMethodOptionsZipPaymentMethodOptions,string>) =
            {
                AcssDebit = acssDebit
                Affirm = affirm
                AfterpayClearpay = afterpayClearpay
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                Blik = blik
                Boleto = boleto
                Card = card
                CardPresent = cardPresent
                Cashapp = cashapp
                CustomerBalance = customerBalance
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Klarna = klarna
                Konbini = konbini
                Link = link
                Oxxo = oxxo
                P24 = p24
                Paynow = paynow
                Paypal = paypal
                Pix = pix
                Promptpay = promptpay
                SepaDebit = sepaDebit
                Sofort = sofort
                UsBankAccount = usBankAccount
                WechatPay = wechatPay
                Zip = zip
            }

    type Confirm'RadarOptions = {
        ///A [Radar Session](https://stripe.com/docs/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
        [<Config.Form>]Session: string option
    }
    with
        static member New(?session: string) =
            {
                Session = session
            }

    type Confirm'ShippingOptionalFieldsShippingAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Confirm'ShippingOptionalFieldsShipping = {
        ///Shipping address.
        [<Config.Form>]Address: Confirm'ShippingOptionalFieldsShippingAddress option
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        [<Config.Form>]Carrier: string option
        ///Recipient name.
        [<Config.Form>]Name: string option
        ///Recipient phone (including extension).
        [<Config.Form>]Phone: string option
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        [<Config.Form>]TrackingNumber: string option
    }
    with
        static member New(?address: Confirm'ShippingOptionalFieldsShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type Confirm'CaptureMethod =
    | Automatic
    | AutomaticAsync
    | Manual

    type Confirm'SetupFutureUsage =
    | OffSession
    | OnSession

    type ConfirmOptions = {
        [<Config.Path>]Intent: string
        ///Controls when the funds will be captured from the customer's account.
        [<Config.Form>]CaptureMethod: Confirm'CaptureMethod option
        ///Set to `true` to fail the payment attempt if the PaymentIntent transitions into `requires_action`. This parameter is intended for simpler integrations that do not handle customer actions, like [saving cards without authentication](https://stripe.com/docs/payments/save-card-without-authentication).
        [<Config.Form>]ErrorOnRequiresAction: bool option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///ID of the mandate to be used for this payment.
        [<Config.Form>]Mandate: string option
        ///This hash contains details about the Mandate to create
        [<Config.Form>]MandateData: Choice<Confirm'MandateDataSecretKey,string,Confirm'MandateDataClientKey> option
        ///Set to `true` to indicate that the customer is not in your checkout flow during this payment attempt, and therefore is unable to authenticate. This parameter is intended for scenarios where you collect card details and [charge them later](https://stripe.com/docs/payments/cards/charging-saved-cards).
        [<Config.Form>]OffSession: Choice<bool,Confirm'OffSession> option
        ///ID of the payment method (a PaymentMethod, Card, or [compatible Source](https://stripe.com/docs/payments/payment-methods/transitioning#compatibility) object) to attach to this PaymentIntent.
        [<Config.Form>]PaymentMethod: string option
        ///If provided, this hash will be used to create a PaymentMethod. The new PaymentMethod will appear
        ///in the [payment_method](https://stripe.com/docs/api/payment_intents/object#payment_intent_object-payment_method)
        ///property on the PaymentIntent.
        [<Config.Form>]PaymentMethodData: Confirm'PaymentMethodData option
        ///Payment-method-specific configuration for this PaymentIntent.
        [<Config.Form>]PaymentMethodOptions: Confirm'PaymentMethodOptions option
        ///Options to configure Radar. See [Radar Session](https://stripe.com/docs/radar/radar-session) for more information.
        [<Config.Form>]RadarOptions: Confirm'RadarOptions option
        ///Email address that the receipt for the resulting payment will be sent to. If `receipt_email` is specified for a payment in live mode, a receipt will be sent regardless of your [email settings](https://dashboard.stripe.com/account/emails).
        [<Config.Form>]ReceiptEmail: Choice<string,string> option
        ///The URL to redirect your customer back to after they authenticate or cancel their payment on the payment method's app or site.
        ///If you'd prefer to redirect to a mobile application, you can alternatively supply an application URI scheme.
        ///This parameter is only used for cards and other redirect-based payment methods.
        [<Config.Form>]ReturnUrl: string option
        ///Indicates that you intend to make future payments with this PaymentIntent's payment method.
        ///Providing this parameter will [attach the payment method](https://stripe.com/docs/payments/save-during-payment) to the PaymentIntent's Customer, if present, after the PaymentIntent is confirmed and any required actions from the user are complete. If no Customer was provided, the payment method can still be [attached](https://stripe.com/docs/api/payment_methods/attach) to a Customer after the transaction completes.
        ///When processing card payments, Stripe also uses `setup_future_usage` to dynamically optimize your payment flow and comply with regional legislation and network rules, such as [SCA](https://stripe.com/docs/strong-customer-authentication).
        ///If `setup_future_usage` is already set and you are performing a request using a publishable key, you may only update the value from `on_session` to `off_session`.
        [<Config.Form>]SetupFutureUsage: Confirm'SetupFutureUsage option
        ///Shipping information for this PaymentIntent.
        [<Config.Form>]Shipping: Choice<Confirm'ShippingOptionalFieldsShipping,string> option
        ///Set to `true` when confirming server-side and using Stripe.js, iOS, or Android client-side SDKs to handle the next actions.
        [<Config.Form>]UseStripeSdk: bool option
    }
    with
        static member New(intent: string, ?captureMethod: Confirm'CaptureMethod, ?errorOnRequiresAction: bool, ?expand: string list, ?mandate: string, ?mandateData: Choice<Confirm'MandateDataSecretKey,string,Confirm'MandateDataClientKey>, ?offSession: Choice<bool,Confirm'OffSession>, ?paymentMethod: string, ?paymentMethodData: Confirm'PaymentMethodData, ?paymentMethodOptions: Confirm'PaymentMethodOptions, ?radarOptions: Confirm'RadarOptions, ?receiptEmail: Choice<string,string>, ?returnUrl: string, ?setupFutureUsage: Confirm'SetupFutureUsage, ?shipping: Choice<Confirm'ShippingOptionalFieldsShipping,string>, ?useStripeSdk: bool) =
            {
                Intent = intent
                CaptureMethod = captureMethod
                ErrorOnRequiresAction = errorOnRequiresAction
                Expand = expand
                Mandate = mandate
                MandateData = mandateData
                OffSession = offSession
                PaymentMethod = paymentMethod
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                RadarOptions = radarOptions
                ReceiptEmail = receiptEmail
                ReturnUrl = returnUrl
                SetupFutureUsage = setupFutureUsage
                Shipping = shipping
                UseStripeSdk = useStripeSdk
            }

    ///<p>Confirm that your customer intends to pay with current or provided
    ///payment method. Upon confirmation, the PaymentIntent will attempt to initiate
    ///a payment.
    ///If the selected payment method requires additional authentication steps, the
    ///PaymentIntent will transition to the <code>requires_action</code> status and
    ///suggest additional actions via <code>next_action</code>. If payment fails,
    ///the PaymentIntent transitions to the <code>requires_payment_method</code> status or the
    ///<code>canceled</code> status if the confirmation limit is reached. If
    ///payment succeeds, the PaymentIntent will transition to the <code>succeeded</code>
    ///status (or <code>requires_capture</code>, if <code>capture_method</code> is set to <code>manual</code>).
    ///If the <code>confirmation_method</code> is <code>automatic</code>, payment may be attempted
    ///using our <a href="/docs/stripe-js/reference#stripe-handle-card-payment">client SDKs</a>
    ///and the PaymentIntent’s <a href="#payment_intent_object-client_secret">client_secret</a>.
    ///After <code>next_action</code>s are handled by the client, no additional
    ///confirmation is required to complete the payment.
    ///If the <code>confirmation_method</code> is <code>manual</code>, all payment attempts must be
    ///initiated using a secret key.
    ///If any actions are required for the payment, the PaymentIntent will
    ///return to the <code>requires_confirmation</code> state
    ///after those actions are completed. Your server needs to then
    ///explicitly re-confirm the PaymentIntent to initiate the next payment
    ///attempt. Read the <a href="/docs/payments/payment-intents/web-manual">expanded documentation</a>
    ///to learn more about manual confirmation.</p>
    let Confirm settings (options: ConfirmOptions) =
        $"/v1/payment_intents/{options.Intent}/confirm"
        |> RestApi.postAsync<_, PaymentIntent> settings (Map.empty) options

module PaymentIntentsIncrementAuthorization =

    type IncrementAuthorization'TransferData = {
        ///The amount that will be transferred automatically when a charge succeeds.
        [<Config.Form>]Amount: int option
    }
    with
        static member New(?amount: int) =
            {
                Amount = amount
            }

    type IncrementAuthorizationOptions = {
        [<Config.Path>]Intent: string
        ///The updated total amount you intend to collect from the cardholder. This amount must be greater than the currently authorized amount.
        [<Config.Form>]Amount: int
        ///The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. The amount of the application fee collected will be capped at the total payment amount. For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        [<Config.Form>]ApplicationFeeAmount: int option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///For non-card charges, you can use this value as the complete description that appears on your customers’ statements. Must contain at least one letter, maximum 22 characters.
        [<Config.Form>]StatementDescriptor: string option
        ///The parameters used to automatically create a Transfer when the payment is captured.
        ///For more information, see the PaymentIntents [use case for connected accounts](https://stripe.com/docs/payments/connected-accounts).
        [<Config.Form>]TransferData: IncrementAuthorization'TransferData option
    }
    with
        static member New(intent: string, amount: int, ?applicationFeeAmount: int, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?statementDescriptor: string, ?transferData: IncrementAuthorization'TransferData) =
            {
                Intent = intent
                Amount = amount
                ApplicationFeeAmount = applicationFeeAmount
                Description = description
                Expand = expand
                Metadata = metadata
                StatementDescriptor = statementDescriptor
                TransferData = transferData
            }

    ///<p>Perform an incremental authorization on an eligible
    ///<a href="/docs/api/payment_intents/object">PaymentIntent</a>. To be eligible, the
    ///PaymentIntent’s status must be <code>requires_capture</code> and
    ///<a href="/docs/api/charges/object#charge_object-payment_method_details-card_present-incremental_authorization_supported">incremental_authorization_supported</a>
    ///must be <code>true</code>.
    ///Incremental authorizations attempt to increase the authorized amount on
    ///your customer’s card to the new, higher <code>amount</code> provided. As with the
    ///initial authorization, incremental authorizations may be declined. A
    ///single PaymentIntent can call this endpoint multiple times to further
    ///increase the authorized amount.
    ///If the incremental authorization succeeds, the PaymentIntent object is
    ///returned with the updated
    ///<a href="/docs/api/payment_intents/object#payment_intent_object-amount">amount</a>.
    ///If the incremental authorization fails, a
    ///<a href="/docs/error-codes#card-declined">card_declined</a> error is returned, and no
    ///fields on the PaymentIntent or Charge are updated. The PaymentIntent
    ///object remains capturable for the previously authorized amount.
    ///Each PaymentIntent can have a maximum of 10 incremental authorization attempts, including declines.
    ///Once captured, a PaymentIntent can no longer be incremented.
    ///Learn more about <a href="/docs/terminal/features/incremental-authorizations">incremental authorizations</a>.</p>
    let IncrementAuthorization settings (options: IncrementAuthorizationOptions) =
        $"/v1/payment_intents/{options.Intent}/increment_authorization"
        |> RestApi.postAsync<_, PaymentIntent> settings (Map.empty) options

module PaymentIntentsVerifyMicrodeposits =

    type VerifyMicrodepositsOptions = {
        [<Config.Path>]Intent: string
        ///Two positive integers, in *cents*, equal to the values of the microdeposits sent to the bank account.
        [<Config.Form>]Amounts: int list option
        ///A six-character code starting with SM present in the microdeposit sent to the bank account.
        [<Config.Form>]DescriptorCode: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(intent: string, ?amounts: int list, ?descriptorCode: string, ?expand: string list) =
            {
                Intent = intent
                Amounts = amounts
                DescriptorCode = descriptorCode
                Expand = expand
            }

    ///<p>Verifies microdeposits on a PaymentIntent object.</p>
    let VerifyMicrodeposits settings (options: VerifyMicrodepositsOptions) =
        $"/v1/payment_intents/{options.Intent}/verify_microdeposits"
        |> RestApi.postAsync<_, PaymentIntent> settings (Map.empty) options

module PaymentMethods =

    type ListOptions = {
        ///The ID of the customer whose PaymentMethods will be retrieved.
        [<Config.Query>]Customer: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///An optional filter on the list, based on the object `type` field. Without the filter, the list includes all current and future payment method types. If your integration expects only one type of payment method in the response, make sure to provide a type value in the request.
        [<Config.Query>]Type: string option
    }
    with
        static member New(?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?type': string) =
            {
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Type = type'
            }

    ///<p>Returns a list of PaymentMethods for Treasury flows. If you want to list the PaymentMethods attached to a Customer for payments, you should use the <a href="/docs/api/payment_methods/customer_list">List a Customer’s PaymentMethods</a> API instead.</p>
    let List settings (options: ListOptions) =
        let qs = [("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/payment_methods"
        |> RestApi.getAsync<PaymentMethod list> settings qs

    type Create'AcssDebit = {
        ///Customer's bank account number.
        [<Config.Form>]AccountNumber: string option
        ///Institution number of the customer's bank.
        [<Config.Form>]InstitutionNumber: string option
        ///Transit number of the customer's bank.
        [<Config.Form>]TransitNumber: string option
    }
    with
        static member New(?accountNumber: string, ?institutionNumber: string, ?transitNumber: string) =
            {
                AccountNumber = accountNumber
                InstitutionNumber = institutionNumber
                TransitNumber = transitNumber
            }

    type Create'AuBecsDebit = {
        ///The account number for the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Bank-State-Branch number of the bank account.
        [<Config.Form>]BsbNumber: string option
    }
    with
        static member New(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type Create'BacsDebit = {
        ///Account number of the bank account that the funds will be debited from.
        [<Config.Form>]AccountNumber: string option
        ///Sort code of the bank account. (e.g., `10-20-30`)
        [<Config.Form>]SortCode: string option
    }
    with
        static member New(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type Create'BillingDetailsAddressBillingDetailsAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'BillingDetails = {
        ///Billing address.
        [<Config.Form>]Address: Choice<Create'BillingDetailsAddressBillingDetailsAddress,string> option
        ///Email address.
        [<Config.Form>]Email: Choice<string,string> option
        ///Full name.
        [<Config.Form>]Name: Choice<string,string> option
        ///Billing phone number (including extension).
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Choice<Create'BillingDetailsAddressBillingDetailsAddress,string>, ?email: Choice<string,string>, ?name: Choice<string,string>, ?phone: Choice<string,string>) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Create'Boleto = {
        ///The tax ID of the customer (CPF for individual consumers or CNPJ for businesses consumers)
        [<Config.Form>]TaxId: string option
    }
    with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Create'CardCardDetailsParams = {
        ///The card's CVC. It is highly recommended to always include this value.
        [<Config.Form>]Cvc: string option
        ///Two-digit number representing the card's expiration month.
        [<Config.Form>]ExpMonth: int option
        ///Four-digit number representing the card's expiration year.
        [<Config.Form>]ExpYear: int option
        ///The card number, as a string without any separators.
        [<Config.Form>]Number: string option
    }
    with
        static member New(?cvc: string, ?expMonth: int, ?expYear: int, ?number: string) =
            {
                Cvc = cvc
                ExpMonth = expMonth
                ExpYear = expYear
                Number = number
            }

    type Create'CardTokenParams = {
        [<Config.Form>]Token: string option
    }
    with
        static member New(?token: string) =
            {
                Token = token
            }

    type Create'EpsBank =
    | ArzteUndApothekerBank
    | AustrianAnadiBankAg
    | BankAustria
    | BankhausCarlSpangler
    | BankhausSchelhammerUndSchatteraAg
    | BawagPskAg
    | BksBankAg
    | BrullKallmusBankAg
    | BtvVierLanderBank
    | CapitalBankGraweGruppeAg
    | DeutscheBankAg
    | Dolomitenbank
    | EasybankAg
    | ErsteBankUndSparkassen
    | HypoAlpeadriabankInternationalAg
    | HypoBankBurgenlandAktiengesellschaft
    | HypoNoeLbFurNiederosterreichUWien
    | HypoOberosterreichSalzburgSteiermark
    | HypoTirolBankAg
    | HypoVorarlbergBankAg
    | MarchfelderBank
    | OberbankAg
    | RaiffeisenBankengruppeOsterreich
    | SchoellerbankAg
    | SpardaBankWien
    | VolksbankGruppe
    | VolkskreditbankAg
    | VrBankBraunau

    type Create'Eps = {
        ///The customer's bank.
        [<Config.Form>]Bank: Create'EpsBank option
    }
    with
        static member New(?bank: Create'EpsBank) =
            {
                Bank = bank
            }

    type Create'FpxAccountHolderType =
    | Company
    | Individual

    type Create'FpxBank =
    | AffinBank
    | Agrobank
    | AllianceBank
    | Ambank
    | BankIslam
    | BankMuamalat
    | BankOfChina
    | BankRakyat
    | Bsn
    | Cimb
    | DeutscheBank
    | HongLeongBank
    | Hsbc
    | Kfh
    | Maybank2e
    | Maybank2u
    | Ocbc
    | PbEnterprise
    | PublicBank
    | Rhb
    | StandardChartered
    | Uob

    type Create'Fpx = {
        ///Account holder type for FPX transaction
        [<Config.Form>]AccountHolderType: Create'FpxAccountHolderType option
        ///The customer's bank.
        [<Config.Form>]Bank: Create'FpxBank option
    }
    with
        static member New(?accountHolderType: Create'FpxAccountHolderType, ?bank: Create'FpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type Create'IdealBank =
    | AbnAmro
    | AsnBank
    | Bunq
    | Handelsbanken
    | Ing
    | Knab
    | Moneyou
    | Rabobank
    | Regiobank
    | Revolut
    | SnsBank
    | TriodosBank
    | VanLanschot
    | Yoursafe

    type Create'Ideal = {
        ///The customer's bank.
        [<Config.Form>]Bank: Create'IdealBank option
    }
    with
        static member New(?bank: Create'IdealBank) =
            {
                Bank = bank
            }

    type Create'KlarnaDob = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'Klarna = {
        ///Customer's date of birth
        [<Config.Form>]Dob: Create'KlarnaDob option
    }
    with
        static member New(?dob: Create'KlarnaDob) =
            {
                Dob = dob
            }

    type Create'P24Bank =
    | AliorBank
    | BankMillennium
    | BankNowyBfgSa
    | BankPekaoSa
    | BankiSpbdzielcze
    | Blik
    | BnpParibas
    | Boz
    | CitiHandlowy
    | CreditAgricole
    | Envelobank
    | EtransferPocztowy24
    | GetinBank
    | Ideabank
    | Ing
    | Inteligo
    | MbankMtransfer
    | NestPrzelew
    | NoblePay
    | PbacZIpko
    | PlusBank
    | SantanderPrzelew24
    | TmobileUsbugiBankowe
    | ToyotaBank
    | VolkswagenBank

    type Create'P24 = {
        ///The customer's bank.
        [<Config.Form>]Bank: Create'P24Bank option
    }
    with
        static member New(?bank: Create'P24Bank) =
            {
                Bank = bank
            }

    type Create'RadarOptions = {
        ///A [Radar Session](https://stripe.com/docs/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
        [<Config.Form>]Session: string option
    }
    with
        static member New(?session: string) =
            {
                Session = session
            }

    type Create'SepaDebit = {
        ///IBAN of the bank account.
        [<Config.Form>]Iban: string option
    }
    with
        static member New(?iban: string) =
            {
                Iban = iban
            }

    type Create'SofortCountry =
    | [<JsonUnionCase("AT")>] AT
    | [<JsonUnionCase("BE")>] BE
    | [<JsonUnionCase("DE")>] DE
    | [<JsonUnionCase("ES")>] ES
    | [<JsonUnionCase("IT")>] IT
    | [<JsonUnionCase("NL")>] NL

    type Create'Sofort = {
        ///Two-letter ISO code representing the country the bank account is located in.
        [<Config.Form>]Country: Create'SofortCountry option
    }
    with
        static member New(?country: Create'SofortCountry) =
            {
                Country = country
            }

    type Create'UsBankAccountAccountHolderType =
    | Company
    | Individual

    type Create'UsBankAccountAccountType =
    | Checking
    | Savings

    type Create'UsBankAccount = {
        ///Account holder type: individual or company.
        [<Config.Form>]AccountHolderType: Create'UsBankAccountAccountHolderType option
        ///Account number of the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Account type: checkings or savings. Defaults to checking if omitted.
        [<Config.Form>]AccountType: Create'UsBankAccountAccountType option
        ///The ID of a Financial Connections Account to use as a payment method.
        [<Config.Form>]FinancialConnectionsAccount: string option
        ///Routing number of the bank account.
        [<Config.Form>]RoutingNumber: string option
    }
    with
        static member New(?accountHolderType: Create'UsBankAccountAccountHolderType, ?accountNumber: string, ?accountType: Create'UsBankAccountAccountType, ?financialConnectionsAccount: string, ?routingNumber: string) =
            {
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                FinancialConnectionsAccount = financialConnectionsAccount
                RoutingNumber = routingNumber
            }

    type Create'Type =
    | AcssDebit
    | Affirm
    | AfterpayClearpay
    | Alipay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Blik
    | Boleto
    | Card
    | Cashapp
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Klarna
    | Konbini
    | Link
    | Oxxo
    | P24
    | Paynow
    | Paypal
    | Pix
    | Promptpay
    | SepaDebit
    | Sofort
    | UsBankAccount
    | WechatPay
    | Zip

    type CreateOptions = {
        ///If this is an `acss_debit` PaymentMethod, this hash contains details about the ACSS Debit payment method.
        [<Config.Form>]AcssDebit: Create'AcssDebit option
        ///If this is an `affirm` PaymentMethod, this hash contains details about the Affirm payment method.
        [<Config.Form>]Affirm: string option
        ///If this is an `AfterpayClearpay` PaymentMethod, this hash contains details about the AfterpayClearpay payment method.
        [<Config.Form>]AfterpayClearpay: string option
        ///If this is an `Alipay` PaymentMethod, this hash contains details about the Alipay payment method.
        [<Config.Form>]Alipay: string option
        ///If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
        [<Config.Form>]AuBecsDebit: Create'AuBecsDebit option
        ///If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
        [<Config.Form>]BacsDebit: Create'BacsDebit option
        ///If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
        [<Config.Form>]Bancontact: string option
        ///Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
        [<Config.Form>]BillingDetails: Create'BillingDetails option
        ///If this is a `blik` PaymentMethod, this hash contains details about the BLIK payment method.
        [<Config.Form>]Blik: string option
        ///If this is a `boleto` PaymentMethod, this hash contains details about the Boleto payment method.
        [<Config.Form>]Boleto: Create'Boleto option
        ///If this is a `card` PaymentMethod, this hash contains the user's card details. For backwards compatibility, you can alternatively provide a Stripe token (e.g., for Apple Pay, Amex Express Checkout, or legacy Checkout) into the card hash with format `card: {token: "tok_visa"}`. When providing a card number, you must meet the requirements for [PCI compliance](https://stripe.com/docs/security#validating-pci-compliance). We strongly recommend using Stripe.js instead of interacting with this API directly.
        [<Config.Form>]Card: Choice<Create'CardCardDetailsParams,Create'CardTokenParams> option
        ///If this is a `cashapp` PaymentMethod, this hash contains details about the Cash App Pay payment method.
        [<Config.Form>]Cashapp: string option
        ///The `Customer` to whom the original PaymentMethod is attached.
        [<Config.Form>]Customer: string option
        ///If this is a `customer_balance` PaymentMethod, this hash contains details about the CustomerBalance payment method.
        [<Config.Form>]CustomerBalance: string option
        ///If this is an `eps` PaymentMethod, this hash contains details about the EPS payment method.
        [<Config.Form>]Eps: Create'Eps option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
        [<Config.Form>]Fpx: Create'Fpx option
        ///If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
        [<Config.Form>]Giropay: string option
        ///If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
        [<Config.Form>]Grabpay: string option
        ///If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
        [<Config.Form>]Ideal: Create'Ideal option
        ///If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
        [<Config.Form>]InteracPresent: string option
        ///If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method.
        [<Config.Form>]Klarna: Create'Klarna option
        ///If this is a `konbini` PaymentMethod, this hash contains details about the Konbini payment method.
        [<Config.Form>]Konbini: string option
        ///If this is an `Link` PaymentMethod, this hash contains details about the Link payment method.
        [<Config.Form>]Link: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
        [<Config.Form>]Oxxo: string option
        ///If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
        [<Config.Form>]P24: Create'P24 option
        ///The PaymentMethod to share.
        [<Config.Form>]PaymentMethod: string option
        ///If this is a `paynow` PaymentMethod, this hash contains details about the PayNow payment method.
        [<Config.Form>]Paynow: string option
        ///If this is a `paypal` PaymentMethod, this hash contains details about the PayPal payment method.
        [<Config.Form>]Paypal: string option
        ///If this is a `pix` PaymentMethod, this hash contains details about the Pix payment method.
        [<Config.Form>]Pix: string option
        ///If this is a `promptpay` PaymentMethod, this hash contains details about the PromptPay payment method.
        [<Config.Form>]Promptpay: string option
        ///Options to configure Radar. See [Radar Session](https://stripe.com/docs/radar/radar-session) for more information.
        [<Config.Form>]RadarOptions: Create'RadarOptions option
        ///If this is a `sepa_debit` PaymentMethod, this hash contains details about the SEPA debit bank account.
        [<Config.Form>]SepaDebit: Create'SepaDebit option
        ///If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
        [<Config.Form>]Sofort: Create'Sofort option
        ///The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
        [<Config.Form>]Type: Create'Type option
        ///If this is an `us_bank_account` PaymentMethod, this hash contains details about the US bank account payment method.
        [<Config.Form>]UsBankAccount: Create'UsBankAccount option
        ///If this is an `wechat_pay` PaymentMethod, this hash contains details about the wechat_pay payment method.
        [<Config.Form>]WechatPay: string option
        ///If this is a `zip` PaymentMethod, this hash contains details about the Zip payment method.
        [<Config.Form>]Zip: string option
    }
    with
        static member New(?acssDebit: Create'AcssDebit, ?klarna: Create'Klarna, ?konbini: string, ?link: string, ?metadata: Map<string, string>, ?oxxo: string, ?p24: Create'P24, ?paymentMethod: string, ?interacPresent: string, ?paynow: string, ?pix: string, ?promptpay: string, ?radarOptions: Create'RadarOptions, ?sepaDebit: Create'SepaDebit, ?sofort: Create'Sofort, ?type': Create'Type, ?usBankAccount: Create'UsBankAccount, ?paypal: string, ?wechatPay: string, ?ideal: Create'Ideal, ?giropay: string, ?affirm: string, ?afterpayClearpay: string, ?alipay: string, ?auBecsDebit: Create'AuBecsDebit, ?bacsDebit: Create'BacsDebit, ?bancontact: string, ?billingDetails: Create'BillingDetails, ?grabpay: string, ?blik: string, ?card: Choice<Create'CardCardDetailsParams,Create'CardTokenParams>, ?cashapp: string, ?customer: string, ?customerBalance: string, ?eps: Create'Eps, ?expand: string list, ?fpx: Create'Fpx, ?boleto: Create'Boleto, ?zip: string) =
            {
                AcssDebit = acssDebit
                Affirm = affirm
                AfterpayClearpay = afterpayClearpay
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                BillingDetails = billingDetails
                Blik = blik
                Boleto = boleto
                Card = card
                Cashapp = cashapp
                Customer = customer
                CustomerBalance = customerBalance
                Eps = eps
                Expand = expand
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Klarna = klarna
                Konbini = konbini
                Link = link
                Metadata = metadata
                Oxxo = oxxo
                P24 = p24
                PaymentMethod = paymentMethod
                Paynow = paynow
                Paypal = paypal
                Pix = pix
                Promptpay = promptpay
                RadarOptions = radarOptions
                SepaDebit = sepaDebit
                Sofort = sofort
                Type = type'
                UsBankAccount = usBankAccount
                WechatPay = wechatPay
                Zip = zip
            }

    ///<p>Creates a PaymentMethod object. Read the <a href="/docs/stripe-js/reference#stripe-create-payment-method">Stripe.js reference</a> to learn how to create PaymentMethods via Stripe.js.
    ///Instead of creating a PaymentMethod directly, we recommend using the <a href="/docs/payments/accept-a-payment">PaymentIntents</a> API to accept a payment immediately or the <a href="/docs/payments/save-and-reuse">SetupIntent</a> API to collect payment method details ahead of a future payment.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/payment_methods"
        |> RestApi.postAsync<_, PaymentMethod> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]PaymentMethod: string
    }
    with
        static member New(paymentMethod: string, ?expand: string list) =
            {
                Expand = expand
                PaymentMethod = paymentMethod
            }

    ///<p>Retrieves a PaymentMethod object attached to the StripeAccount. To retrieve a payment method attached to a Customer, you should use <a href="/docs/api/payment_methods/customer">Retrieve a Customer’s PaymentMethods</a></p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/payment_methods/{options.PaymentMethod}"
        |> RestApi.getAsync<PaymentMethod> settings qs

    type Update'BillingDetailsAddressBillingDetailsAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'BillingDetails = {
        ///Billing address.
        [<Config.Form>]Address: Choice<Update'BillingDetailsAddressBillingDetailsAddress,string> option
        ///Email address.
        [<Config.Form>]Email: Choice<string,string> option
        ///Full name.
        [<Config.Form>]Name: Choice<string,string> option
        ///Billing phone number (including extension).
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Choice<Update'BillingDetailsAddressBillingDetailsAddress,string>, ?email: Choice<string,string>, ?name: Choice<string,string>, ?phone: Choice<string,string>) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Update'Card = {
        ///Two-digit number representing the card's expiration month.
        [<Config.Form>]ExpMonth: int option
        ///Four-digit number representing the card's expiration year.
        [<Config.Form>]ExpYear: int option
    }
    with
        static member New(?expMonth: int, ?expYear: int) =
            {
                ExpMonth = expMonth
                ExpYear = expYear
            }

    type Update'UsBankAccountAccountHolderType =
    | Company
    | Individual

    type Update'UsBankAccount = {
        ///Bank account type.
        [<Config.Form>]AccountHolderType: Update'UsBankAccountAccountHolderType option
    }
    with
        static member New(?accountHolderType: Update'UsBankAccountAccountHolderType) =
            {
                AccountHolderType = accountHolderType
            }

    type UpdateOptions = {
        [<Config.Path>]PaymentMethod: string
        ///Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
        [<Config.Form>]BillingDetails: Update'BillingDetails option
        ///If this is a `card` PaymentMethod, this hash contains the user's card details.
        [<Config.Form>]Card: Update'Card option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///If this is an `Link` PaymentMethod, this hash contains details about the Link payment method.
        [<Config.Form>]Link: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///If this is an `us_bank_account` PaymentMethod, this hash contains details about the US bank account payment method.
        [<Config.Form>]UsBankAccount: Update'UsBankAccount option
    }
    with
        static member New(paymentMethod: string, ?billingDetails: Update'BillingDetails, ?card: Update'Card, ?expand: string list, ?link: string, ?metadata: Map<string, string>, ?usBankAccount: Update'UsBankAccount) =
            {
                PaymentMethod = paymentMethod
                BillingDetails = billingDetails
                Card = card
                Expand = expand
                Link = link
                Metadata = metadata
                UsBankAccount = usBankAccount
            }

    ///<p>Updates a PaymentMethod object. A PaymentMethod must be attached a customer to be updated.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/payment_methods/{options.PaymentMethod}"
        |> RestApi.postAsync<_, PaymentMethod> settings (Map.empty) options

module PaymentMethodsAttach =

    type AttachOptions = {
        [<Config.Path>]PaymentMethod: string
        ///The ID of the customer to which to attach the PaymentMethod.
        [<Config.Form>]Customer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(paymentMethod: string, customer: string, ?expand: string list) =
            {
                PaymentMethod = paymentMethod
                Customer = customer
                Expand = expand
            }

    ///<p>Attaches a PaymentMethod object to a Customer.
    ///To attach a new PaymentMethod to a customer for future payments, we recommend you use a <a href="/docs/api/setup_intents">SetupIntent</a>
    ///or a PaymentIntent with <a href="/docs/api/payment_intents/create#create_payment_intent-setup_future_usage">setup_future_usage</a>.
    ///These approaches will perform any necessary steps to set up the PaymentMethod for future payments. Using the <code>/v1/payment_methods/:id/attach</code>
    ///endpoint without first using a SetupIntent or PaymentIntent with <code>setup_future_usage</code> does not optimize the PaymentMethod for
    ///future use, which makes later declines and payment friction more likely.
    ///See <a href="/docs/payments/payment-intents#future-usage">Optimizing cards for future payments</a> for more information about setting up
    ///future payments.
    ///To use this PaymentMethod as the default for invoice or subscription payments,
    ///set <a href="/docs/api/customers/update#update_customer-invoice_settings-default_payment_method"><code>invoice_settings.default_payment_method</code></a>,
    ///on the Customer to the PaymentMethod’s ID.</p>
    let Attach settings (options: AttachOptions) =
        $"/v1/payment_methods/{options.PaymentMethod}/attach"
        |> RestApi.postAsync<_, PaymentMethod> settings (Map.empty) options

module PaymentMethodsDetach =

    type DetachOptions = {
        [<Config.Path>]PaymentMethod: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(paymentMethod: string, ?expand: string list) =
            {
                PaymentMethod = paymentMethod
                Expand = expand
            }

    ///<p>Detaches a PaymentMethod object from a Customer. After a PaymentMethod is detached, it can no longer be used for a payment or re-attached to a Customer.</p>
    let Detach settings (options: DetachOptions) =
        $"/v1/payment_methods/{options.PaymentMethod}/detach"
        |> RestApi.postAsync<_, PaymentMethod> settings (Map.empty) options

module Payouts =

    type ListOptions = {
        [<Config.Query>]ArrivalDate: int option
        [<Config.Query>]Created: int option
        ///The ID of an external account - only return payouts sent to this external account.
        [<Config.Query>]Destination: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only return payouts that have the given status: `pending`, `paid`, `failed`, or `canceled`.
        [<Config.Query>]Status: string option
    }
    with
        static member New(?arrivalDate: int, ?created: int, ?destination: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                ArrivalDate = arrivalDate
                Created = created
                Destination = destination
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    ///<p>Returns a list of existing payouts sent to third-party bank accounts or that Stripe has sent you. The payouts are returned in sorted order, with the most recently created payouts appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("arrival_date", options.ArrivalDate |> box); ("created", options.Created |> box); ("destination", options.Destination |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/payouts"
        |> RestApi.getAsync<Payout list> settings qs

    type Create'Method =
    | Instant
    | Standard

    type Create'SourceType =
    | BankAccount
    | Card
    | Fpx

    type CreateOptions = {
        ///A positive integer in cents representing how much to payout.
        [<Config.Form>]Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///The ID of a bank account or a card to send the payout to. If no destination is supplied, the default external account for the specified currency will be used.
        [<Config.Form>]Destination: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The method used to send this payout, which can be `standard` or `instant`. `instant` is supported for payouts to debit cards and bank accounts in certain countries. (See [Bank support for Instant Payouts](https://stripe.com/docs/payouts/instant-payouts-banks) for more information.)
        [<Config.Form>]Method: Create'Method option
        ///The balance type of your Stripe balance to draw this payout from. Balances for different payment sources are kept separately. You can find the amounts with the balances API. One of `bank_account`, `card`, or `fpx`.
        [<Config.Form>]SourceType: Create'SourceType option
        ///A string to be displayed on the recipient's bank or card statement. This may be at most 22 characters. Attempting to use a `statement_descriptor` longer than 22 characters will return an error. Note: Most banks will truncate this information and/or display it inconsistently. Some may not display it at all.
        [<Config.Form>]StatementDescriptor: string option
    }
    with
        static member New(amount: int, currency: string, ?description: string, ?destination: string, ?expand: string list, ?metadata: Map<string, string>, ?method: Create'Method, ?sourceType: Create'SourceType, ?statementDescriptor: string) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Destination = destination
                Expand = expand
                Metadata = metadata
                Method = method
                SourceType = sourceType
                StatementDescriptor = statementDescriptor
            }

    ///<p>To send funds to your own bank account, you create a new payout object. Your <a href="#balance">Stripe balance</a> must be able to cover the payout amount, or you’ll receive an “Insufficient Funds” error.
    ///If your API key is in test mode, money won’t actually be sent, though everything else will occur as if in live mode.
    ///If you are creating a manual payout on a Stripe account that uses multiple payment source types, you’ll need to specify the source type balance that the payout should draw from. The <a href="#balance_object">balance object</a> details available and pending amounts by source type.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/payouts"
        |> RestApi.postAsync<_, Payout> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Payout: string
    }
    with
        static member New(payout: string, ?expand: string list) =
            {
                Expand = expand
                Payout = payout
            }

    ///<p>Retrieves the details of an existing payout. Supply the unique payout ID from either a payout creation request or the payout list, and Stripe will return the corresponding payout information.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/payouts/{options.Payout}"
        |> RestApi.getAsync<Payout> settings qs

    type UpdateOptions = {
        [<Config.Path>]Payout: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(payout: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Payout = payout
                Expand = expand
                Metadata = metadata
            }

    ///<p>Updates the specified payout by setting the values of the parameters passed. Any parameters not provided will be left unchanged. This request accepts only the metadata as arguments.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/payouts/{options.Payout}"
        |> RestApi.postAsync<_, Payout> settings (Map.empty) options

module PayoutsCancel =

    type CancelOptions = {
        [<Config.Path>]Payout: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(payout: string, ?expand: string list) =
            {
                Payout = payout
                Expand = expand
            }

    ///<p>A previously created payout can be canceled if it has not yet been paid out. Funds will be refunded to your available balance. You may not cancel automatic Stripe payouts.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/payouts/{options.Payout}/cancel"
        |> RestApi.postAsync<_, Payout> settings (Map.empty) options

module PayoutsReverse =

    type ReverseOptions = {
        [<Config.Path>]Payout: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(payout: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Payout = payout
                Expand = expand
                Metadata = metadata
            }

    ///<p>Reverses a payout by debiting the destination bank account. Only payouts for connected accounts to US bank accounts may be reversed at this time. If the payout is in the <code>pending</code> status, <code>/v1/payouts/:id/cancel</code> should be used instead.
    ///By requesting a reversal via <code>/v1/payouts/:id/reverse</code>, you confirm that the authorized signatory of the selected bank account has authorized the debit on the bank account and that no other authorization is required.</p>
    let Reverse settings (options: ReverseOptions) =
        $"/v1/payouts/{options.Payout}/reverse"
        |> RestApi.postAsync<_, Payout> settings (Map.empty) options

module Products =

    type ListOptions = {
        ///Only return products that are active or inactive (e.g., pass `false` to list all inactive products).
        [<Config.Query>]Active: bool option
        ///Only return products that were created during the given date interval.
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///Only return products with the given IDs. Cannot be used with [starting_after](https://stripe.com/docs/api#list_products-starting_after) or [ending_before](https://stripe.com/docs/api#list_products-ending_before).
        [<Config.Query>]Ids: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Only return products that can be shipped (i.e., physical, not digital products).
        [<Config.Query>]Shippable: bool option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only return products of this type.
        [<Config.Query>]Type: string option
        ///Only return products with the given url.
        [<Config.Query>]Url: string option
    }
    with
        static member New(?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?ids: string list, ?limit: int, ?shippable: bool, ?startingAfter: string, ?type': string, ?url: string) =
            {
                Active = active
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Ids = ids
                Limit = limit
                Shippable = shippable
                StartingAfter = startingAfter
                Type = type'
                Url = url
            }

    ///<p>Returns a list of your products. The products are returned sorted by creation date, with the most recently created products appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("ids", options.Ids |> box); ("limit", options.Limit |> box); ("shippable", options.Shippable |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box); ("url", options.Url |> box)] |> Map.ofList
        $"/v1/products"
        |> RestApi.getAsync<Product list> settings qs

    type Create'DefaultPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'DefaultPriceDataRecurring = {
        ///Specifies billing frequency. Either `day`, `week`, `month` or `year`.
        [<Config.Form>]Interval: Create'DefaultPriceDataRecurringInterval option
        ///The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'DefaultPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'DefaultPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'DefaultPriceData = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///Prices defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]CurrencyOptions: Map<string, string> option
        ///The recurring components of a price such as `interval` and `interval_count`.
        [<Config.Form>]Recurring: Create'DefaultPriceDataRecurring option
        ///Only required if a [default tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.
        [<Config.Form>]TaxBehavior: Create'DefaultPriceDataTaxBehavior option
        ///A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge. One of `unit_amount` or `unit_amount_decimal` is required.
        [<Config.Form>]UnitAmount: int option
        ///Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: string, ?currencyOptions: Map<string, string>, ?recurring: Create'DefaultPriceDataRecurring, ?taxBehavior: Create'DefaultPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                CurrencyOptions = currencyOptions
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'PackageDimensions = {
        ///Height, in inches. Maximum precision is 2 decimal places.
        [<Config.Form>]Height: decimal option
        ///Length, in inches. Maximum precision is 2 decimal places.
        [<Config.Form>]Length: decimal option
        ///Weight, in ounces. Maximum precision is 2 decimal places.
        [<Config.Form>]Weight: decimal option
        ///Width, in inches. Maximum precision is 2 decimal places.
        [<Config.Form>]Width: decimal option
    }
    with
        static member New(?height: decimal, ?length: decimal, ?weight: decimal, ?width: decimal) =
            {
                Height = height
                Length = length
                Weight = weight
                Width = width
            }

    type Create'Type =
    | Good
    | Service

    type CreateOptions = {
        ///Whether the product is currently available for purchase. Defaults to `true`.
        [<Config.Form>]Active: bool option
        ///Data used to generate a new [Price](https://stripe.com/docs/api/prices) object. This Price will be set as the default price for this product.
        [<Config.Form>]DefaultPriceData: Create'DefaultPriceData option
        ///The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///An identifier will be randomly generated by Stripe. You can optionally override this ID, but the ID must be unique across all products in your Stripe account.
        [<Config.Form>]Id: string option
        ///A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
        [<Config.Form>]Images: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The product's name, meant to be displayable to the customer.
        [<Config.Form>]Name: string
        ///The dimensions of this product for shipping purposes.
        [<Config.Form>]PackageDimensions: Create'PackageDimensions option
        ///Whether this product is shipped (i.e., physical goods).
        [<Config.Form>]Shippable: bool option
        ///An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
        ///This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.
        /// It must contain at least one letter.
        [<Config.Form>]StatementDescriptor: string option
        ///A [tax code](https://stripe.com/docs/tax/tax-categories) ID.
        [<Config.Form>]TaxCode: string option
        ///The type of the product. Defaults to `service` if not explicitly specified, enabling use of this product with Subscriptions and Plans. Set this parameter to `good` to use this product with Orders and SKUs. On API versions before `2018-02-05`, this field defaults to `good` for compatibility reasons.
        [<Config.Form>]Type: Create'Type option
        ///A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.
        [<Config.Form>]UnitLabel: string option
        ///A URL of a publicly-accessible webpage for this product.
        [<Config.Form>]Url: string option
    }
    with
        static member New(name: string, ?active: bool, ?defaultPriceData: Create'DefaultPriceData, ?description: string, ?expand: string list, ?id: string, ?images: string list, ?metadata: Map<string, string>, ?packageDimensions: Create'PackageDimensions, ?shippable: bool, ?statementDescriptor: string, ?taxCode: string, ?type': Create'Type, ?unitLabel: string, ?url: string) =
            {
                Active = active
                DefaultPriceData = defaultPriceData
                Description = description
                Expand = expand
                Id = id
                Images = images
                Metadata = metadata
                Name = name
                PackageDimensions = packageDimensions
                Shippable = shippable
                StatementDescriptor = statementDescriptor
                TaxCode = taxCode
                Type = type'
                UnitLabel = unitLabel
                Url = url
            }

    ///<p>Creates a new product object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/products"
        |> RestApi.postAsync<_, Product> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string) =
            {
                Id = id
            }

    ///<p>Delete a product. Deleting a product is only possible if it has no prices associated with it. Additionally, deleting a product with <code>type=good</code> is only possible if it has no SKUs associated with it.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/products/{options.Id}"
        |> RestApi.deleteAsync<DeletedProduct> settings (Map.empty)

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<p>Retrieves the details of an existing product. Supply the unique product ID from either a product creation request or the product list, and Stripe will return the corresponding product information.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/products/{options.Id}"
        |> RestApi.getAsync<Product> settings qs

    type Update'PackageDimensionsPackageDimensionsSpecs = {
        ///Height, in inches. Maximum precision is 2 decimal places.
        [<Config.Form>]Height: decimal option
        ///Length, in inches. Maximum precision is 2 decimal places.
        [<Config.Form>]Length: decimal option
        ///Weight, in ounces. Maximum precision is 2 decimal places.
        [<Config.Form>]Weight: decimal option
        ///Width, in inches. Maximum precision is 2 decimal places.
        [<Config.Form>]Width: decimal option
    }
    with
        static member New(?height: decimal, ?length: decimal, ?weight: decimal, ?width: decimal) =
            {
                Height = height
                Length = length
                Weight = weight
                Width = width
            }

    type UpdateOptions = {
        [<Config.Path>]Id: string
        ///Whether the product is available for purchase.
        [<Config.Form>]Active: bool option
        ///The ID of the [Price](https://stripe.com/docs/api/prices) object that is the default price for this product.
        [<Config.Form>]DefaultPrice: string option
        ///The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
        [<Config.Form>]Description: Choice<string,string> option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
        [<Config.Form>]Images: Choice<string list,string> option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The product's name, meant to be displayable to the customer.
        [<Config.Form>]Name: string option
        ///The dimensions of this product for shipping purposes.
        [<Config.Form>]PackageDimensions: Choice<Update'PackageDimensionsPackageDimensionsSpecs,string> option
        ///Whether this product is shipped (i.e., physical goods).
        [<Config.Form>]Shippable: bool option
        ///An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
        ///This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.
        /// It must contain at least one letter. May only be set if `type=service`.
        [<Config.Form>]StatementDescriptor: string option
        ///A [tax code](https://stripe.com/docs/tax/tax-categories) ID.
        [<Config.Form>]TaxCode: Choice<string,string> option
        ///A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal. May only be set if `type=service`.
        [<Config.Form>]UnitLabel: Choice<string,string> option
        ///A URL of a publicly-accessible webpage for this product.
        [<Config.Form>]Url: Choice<string,string> option
    }
    with
        static member New(id: string, ?active: bool, ?defaultPrice: string, ?description: Choice<string,string>, ?expand: string list, ?images: Choice<string list,string>, ?metadata: Map<string, string>, ?name: string, ?packageDimensions: Choice<Update'PackageDimensionsPackageDimensionsSpecs,string>, ?shippable: bool, ?statementDescriptor: string, ?taxCode: Choice<string,string>, ?unitLabel: Choice<string,string>, ?url: Choice<string,string>) =
            {
                Id = id
                Active = active
                DefaultPrice = defaultPrice
                Description = description
                Expand = expand
                Images = images
                Metadata = metadata
                Name = name
                PackageDimensions = packageDimensions
                Shippable = shippable
                StatementDescriptor = statementDescriptor
                TaxCode = taxCode
                UnitLabel = unitLabel
                Url = url
            }

    ///<p>Updates the specific product by setting the values of the parameters passed. Any parameters not provided will be left unchanged.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/products/{options.Id}"
        |> RestApi.postAsync<_, Product> settings (Map.empty) options

module ProductsSearch =

    type SearchOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.
        [<Config.Query>]Page: string option
        ///The search query string. See [search query language](https://stripe.com/docs/search#search-query-language) and the list of supported [query fields for products](https://stripe.com/docs/search#query-fields-for-products).
        [<Config.Query>]Query: string
    }
    with
        static member New(query: string, ?expand: string list, ?limit: int, ?page: string) =
            {
                Expand = expand
                Limit = limit
                Page = page
                Query = query
            }

    ///<p>Search for products you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/products/search"
        |> RestApi.getAsync<Product list> settings qs

module Refunds =

    type ListOptions = {
        ///Only return refunds for the charge specified by this charge ID.
        [<Config.Query>]Charge: string option
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Only return refunds for the PaymentIntent specified by this ID.
        [<Config.Query>]PaymentIntent: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
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

    ///<p>Returns a list of all refunds you’ve previously created. The refunds are returned in sorted order, with the most recent refunds appearing first. For convenience, the 10 most recent refunds are always available by default on the charge object.</p>
    let List settings (options: ListOptions) =
        let qs = [("charge", options.Charge |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/refunds"
        |> RestApi.getAsync<Refund list> settings qs

    type Create'Origin =
    | CustomerBalance

    type Create'Reason =
    | Duplicate
    | Fraudulent
    | RequestedByCustomer

    type CreateOptions = {
        ///A positive integer representing how much to refund.
        [<Config.Form>]Amount: int option
        [<Config.Form>]Charge: string option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///Customer whose customer balance to refund from.
        [<Config.Form>]Customer: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///For payment methods without native refund support (e.g., Konbini, PromptPay), use this email from the customer to receive refund instructions.
        [<Config.Form>]InstructionsEmail: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Origin of the refund
        [<Config.Form>]Origin: Create'Origin option
        [<Config.Form>]PaymentIntent: string option
        [<Config.Form>]Reason: Create'Reason option
        [<Config.Form>]RefundApplicationFee: bool option
        [<Config.Form>]ReverseTransfer: bool option
    }
    with
        static member New(?amount: int, ?charge: string, ?currency: string, ?customer: string, ?expand: string list, ?instructionsEmail: string, ?metadata: Map<string, string>, ?origin: Create'Origin, ?paymentIntent: string, ?reason: Create'Reason, ?refundApplicationFee: bool, ?reverseTransfer: bool) =
            {
                Amount = amount
                Charge = charge
                Currency = currency
                Customer = customer
                Expand = expand
                InstructionsEmail = instructionsEmail
                Metadata = metadata
                Origin = origin
                PaymentIntent = paymentIntent
                Reason = reason
                RefundApplicationFee = refundApplicationFee
                ReverseTransfer = reverseTransfer
            }

    ///<p>Create a refund.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/refunds"
        |> RestApi.postAsync<_, Refund> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Refund: string
    }
    with
        static member New(refund: string, ?expand: string list) =
            {
                Expand = expand
                Refund = refund
            }

    ///<p>Retrieves the details of an existing refund.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/refunds/{options.Refund}"
        |> RestApi.getAsync<Refund> settings qs

    type UpdateOptions = {
        [<Config.Path>]Refund: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(refund: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Refund = refund
                Expand = expand
                Metadata = metadata
            }

    ///<p>Updates the specified refund by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
    ///This request only accepts <code>metadata</code> as an argument.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/refunds/{options.Refund}"
        |> RestApi.postAsync<_, Refund> settings (Map.empty) options

module RefundsCancel =

    type CancelOptions = {
        [<Config.Path>]Refund: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(refund: string, ?expand: string list) =
            {
                Refund = refund
                Expand = expand
            }

    ///<p>Cancels a refund with a status of <code>requires_action</code>.
    ///Refunds in other states cannot be canceled, and only refunds for payment methods that require customer action will enter the <code>requires_action</code> state.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/refunds/{options.Refund}/cancel"
        |> RestApi.postAsync<_, Refund> settings (Map.empty) options

module Reviews =

    type ListOptions = {
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of <code>Review</code> objects that have <code>open</code> set to <code>true</code>. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/reviews"
        |> RestApi.getAsync<Review list> settings qs

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Review: string
    }
    with
        static member New(review: string, ?expand: string list) =
            {
                Expand = expand
                Review = review
            }

    ///<p>Retrieves a <code>Review</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/reviews/{options.Review}"
        |> RestApi.getAsync<Review> settings qs

module ReviewsApprove =

    type ApproveOptions = {
        [<Config.Path>]Review: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(review: string, ?expand: string list) =
            {
                Review = review
                Expand = expand
            }

    ///<p>Approves a <code>Review</code> object, closing it and removing it from the list of reviews.</p>
    let Approve settings (options: ApproveOptions) =
        $"/v1/reviews/{options.Review}/approve"
        |> RestApi.postAsync<_, Review> settings (Map.empty) options

module SetupAttempts =

    type ListOptions = {
        ///A filter on the list, based on the object `created` field. The value
        ///can be a string with an integer Unix timestamp, or it can be a
        ///dictionary with a number of different query options.
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Only return SetupAttempts created by the SetupIntent specified by
        ///this ID.
        [<Config.Query>]SetupIntent: string
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(setupIntent: string, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                SetupIntent = setupIntent
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of SetupAttempts associated with a provided SetupIntent.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("setup_intent", options.SetupIntent |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/setup_attempts"
        |> RestApi.getAsync<SetupAttempt list> settings qs

module SetupIntents =

    type ListOptions = {
        ///If present, the SetupIntent's payment method will be attached to the in-context Stripe Account.
        ///It can only be used for this Stripe Account’s own money movement flows like InboundTransfer and OutboundTransfers. It cannot be set to true when setting up a PaymentMethod for a Customer, and defaults to false when attaching a PaymentMethod to a Customer.
        [<Config.Query>]AttachToSelf: bool option
        ///A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
        [<Config.Query>]Created: int option
        ///Only return SetupIntents for the customer specified by this customer ID.
        [<Config.Query>]Customer: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Only return SetupIntents associated with the specified payment method.
        [<Config.Query>]PaymentMethod: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?attachToSelf: bool, ?created: int, ?customer: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentMethod: string, ?startingAfter: string) =
            {
                AttachToSelf = attachToSelf
                Created = created
                Customer = customer
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                PaymentMethod = paymentMethod
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of SetupIntents.</p>
    let List settings (options: ListOptions) =
        let qs = [("attach_to_self", options.AttachToSelf |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_method", options.PaymentMethod |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/setup_intents"
        |> RestApi.getAsync<SetupIntent list> settings qs

    type Create'AutomaticPaymentMethodsAllowRedirects =
    | Always
    | Never

    type Create'AutomaticPaymentMethods = {
        ///Controls whether this SetupIntent will accept redirect-based payment methods.
        ///Redirect-based payment methods may require your customer to be redirected to a payment method's app or site for authentication or additional steps. To [confirm](https://stripe.com/docs/api/setup_intents/confirm) this SetupIntent, you may be required to provide a `return_url` to redirect customers back to your site after they authenticate or complete the setup.
        [<Config.Form>]AllowRedirects: Create'AutomaticPaymentMethodsAllowRedirects option
        ///Whether this feature is enabled.
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?allowRedirects: Create'AutomaticPaymentMethodsAllowRedirects, ?enabled: bool) =
            {
                AllowRedirects = allowRedirects
                Enabled = enabled
            }

    type Create'FlowDirections =
    | Inbound
    | Outbound

    type Create'MandateDataSecretKeyCustomerAcceptanceOnline = {
        ///The IP address from which the Mandate was accepted by the customer.
        [<Config.Form>]IpAddress: string option
        ///The user agent of the browser from which the Mandate was accepted by the customer.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type Create'MandateDataSecretKeyCustomerAcceptanceType =
    | Offline
    | Online

    type Create'MandateDataSecretKeyCustomerAcceptance = {
        ///The time at which the customer accepted the Mandate.
        [<Config.Form>]AcceptedAt: DateTime option
        ///If this is a Mandate accepted offline, this hash contains details about the offline acceptance.
        [<Config.Form>]Offline: string option
        ///If this is a Mandate accepted online, this hash contains details about the online acceptance.
        [<Config.Form>]Online: Create'MandateDataSecretKeyCustomerAcceptanceOnline option
        ///The type of customer acceptance information included with the Mandate. One of `online` or `offline`.
        [<Config.Form>]Type: Create'MandateDataSecretKeyCustomerAcceptanceType option
    }
    with
        static member New(?acceptedAt: DateTime, ?offline: string, ?online: Create'MandateDataSecretKeyCustomerAcceptanceOnline, ?type': Create'MandateDataSecretKeyCustomerAcceptanceType) =
            {
                AcceptedAt = acceptedAt
                Offline = offline
                Online = online
                Type = type'
            }

    type Create'MandateDataSecretKey = {
        ///This hash contains details about the customer acceptance of the Mandate.
        [<Config.Form>]CustomerAcceptance: Create'MandateDataSecretKeyCustomerAcceptance option
    }
    with
        static member New(?customerAcceptance: Create'MandateDataSecretKeyCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type Create'PaymentMethodDataAcssDebit = {
        ///Customer's bank account number.
        [<Config.Form>]AccountNumber: string option
        ///Institution number of the customer's bank.
        [<Config.Form>]InstitutionNumber: string option
        ///Transit number of the customer's bank.
        [<Config.Form>]TransitNumber: string option
    }
    with
        static member New(?accountNumber: string, ?institutionNumber: string, ?transitNumber: string) =
            {
                AccountNumber = accountNumber
                InstitutionNumber = institutionNumber
                TransitNumber = transitNumber
            }

    type Create'PaymentMethodDataAuBecsDebit = {
        ///The account number for the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Bank-State-Branch number of the bank account.
        [<Config.Form>]BsbNumber: string option
    }
    with
        static member New(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type Create'PaymentMethodDataBacsDebit = {
        ///Account number of the bank account that the funds will be debited from.
        [<Config.Form>]AccountNumber: string option
        ///Sort code of the bank account. (e.g., `10-20-30`)
        [<Config.Form>]SortCode: string option
    }
    with
        static member New(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type Create'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PaymentMethodDataBillingDetails = {
        ///Billing address.
        [<Config.Form>]Address: Choice<Create'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
        ///Email address.
        [<Config.Form>]Email: Choice<string,string> option
        ///Full name.
        [<Config.Form>]Name: Choice<string,string> option
        ///Billing phone number (including extension).
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Choice<Create'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: Choice<string,string>, ?name: Choice<string,string>, ?phone: Choice<string,string>) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Create'PaymentMethodDataBoleto = {
        ///The tax ID of the customer (CPF for individual consumers or CNPJ for businesses consumers)
        [<Config.Form>]TaxId: string option
    }
    with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Create'PaymentMethodDataEpsBank =
    | ArzteUndApothekerBank
    | AustrianAnadiBankAg
    | BankAustria
    | BankhausCarlSpangler
    | BankhausSchelhammerUndSchatteraAg
    | BawagPskAg
    | BksBankAg
    | BrullKallmusBankAg
    | BtvVierLanderBank
    | CapitalBankGraweGruppeAg
    | DeutscheBankAg
    | Dolomitenbank
    | EasybankAg
    | ErsteBankUndSparkassen
    | HypoAlpeadriabankInternationalAg
    | HypoBankBurgenlandAktiengesellschaft
    | HypoNoeLbFurNiederosterreichUWien
    | HypoOberosterreichSalzburgSteiermark
    | HypoTirolBankAg
    | HypoVorarlbergBankAg
    | MarchfelderBank
    | OberbankAg
    | RaiffeisenBankengruppeOsterreich
    | SchoellerbankAg
    | SpardaBankWien
    | VolksbankGruppe
    | VolkskreditbankAg
    | VrBankBraunau

    type Create'PaymentMethodDataEps = {
        ///The customer's bank.
        [<Config.Form>]Bank: Create'PaymentMethodDataEpsBank option
    }
    with
        static member New(?bank: Create'PaymentMethodDataEpsBank) =
            {
                Bank = bank
            }

    type Create'PaymentMethodDataFpxAccountHolderType =
    | Company
    | Individual

    type Create'PaymentMethodDataFpxBank =
    | AffinBank
    | Agrobank
    | AllianceBank
    | Ambank
    | BankIslam
    | BankMuamalat
    | BankOfChina
    | BankRakyat
    | Bsn
    | Cimb
    | DeutscheBank
    | HongLeongBank
    | Hsbc
    | Kfh
    | Maybank2e
    | Maybank2u
    | Ocbc
    | PbEnterprise
    | PublicBank
    | Rhb
    | StandardChartered
    | Uob

    type Create'PaymentMethodDataFpx = {
        ///Account holder type for FPX transaction
        [<Config.Form>]AccountHolderType: Create'PaymentMethodDataFpxAccountHolderType option
        ///The customer's bank.
        [<Config.Form>]Bank: Create'PaymentMethodDataFpxBank option
    }
    with
        static member New(?accountHolderType: Create'PaymentMethodDataFpxAccountHolderType, ?bank: Create'PaymentMethodDataFpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type Create'PaymentMethodDataIdealBank =
    | AbnAmro
    | AsnBank
    | Bunq
    | Handelsbanken
    | Ing
    | Knab
    | Moneyou
    | Rabobank
    | Regiobank
    | Revolut
    | SnsBank
    | TriodosBank
    | VanLanschot
    | Yoursafe

    type Create'PaymentMethodDataIdeal = {
        ///The customer's bank.
        [<Config.Form>]Bank: Create'PaymentMethodDataIdealBank option
    }
    with
        static member New(?bank: Create'PaymentMethodDataIdealBank) =
            {
                Bank = bank
            }

    type Create'PaymentMethodDataKlarnaDob = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'PaymentMethodDataKlarna = {
        ///Customer's date of birth
        [<Config.Form>]Dob: Create'PaymentMethodDataKlarnaDob option
    }
    with
        static member New(?dob: Create'PaymentMethodDataKlarnaDob) =
            {
                Dob = dob
            }

    type Create'PaymentMethodDataP24Bank =
    | AliorBank
    | BankMillennium
    | BankNowyBfgSa
    | BankPekaoSa
    | BankiSpbdzielcze
    | Blik
    | BnpParibas
    | Boz
    | CitiHandlowy
    | CreditAgricole
    | Envelobank
    | EtransferPocztowy24
    | GetinBank
    | Ideabank
    | Ing
    | Inteligo
    | MbankMtransfer
    | NestPrzelew
    | NoblePay
    | PbacZIpko
    | PlusBank
    | SantanderPrzelew24
    | TmobileUsbugiBankowe
    | ToyotaBank
    | VolkswagenBank

    type Create'PaymentMethodDataP24 = {
        ///The customer's bank.
        [<Config.Form>]Bank: Create'PaymentMethodDataP24Bank option
    }
    with
        static member New(?bank: Create'PaymentMethodDataP24Bank) =
            {
                Bank = bank
            }

    type Create'PaymentMethodDataRadarOptions = {
        ///A [Radar Session](https://stripe.com/docs/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
        [<Config.Form>]Session: string option
    }
    with
        static member New(?session: string) =
            {
                Session = session
            }

    type Create'PaymentMethodDataSepaDebit = {
        ///IBAN of the bank account.
        [<Config.Form>]Iban: string option
    }
    with
        static member New(?iban: string) =
            {
                Iban = iban
            }

    type Create'PaymentMethodDataSofortCountry =
    | [<JsonUnionCase("AT")>] AT
    | [<JsonUnionCase("BE")>] BE
    | [<JsonUnionCase("DE")>] DE
    | [<JsonUnionCase("ES")>] ES
    | [<JsonUnionCase("IT")>] IT
    | [<JsonUnionCase("NL")>] NL

    type Create'PaymentMethodDataSofort = {
        ///Two-letter ISO code representing the country the bank account is located in.
        [<Config.Form>]Country: Create'PaymentMethodDataSofortCountry option
    }
    with
        static member New(?country: Create'PaymentMethodDataSofortCountry) =
            {
                Country = country
            }

    type Create'PaymentMethodDataUsBankAccountAccountHolderType =
    | Company
    | Individual

    type Create'PaymentMethodDataUsBankAccountAccountType =
    | Checking
    | Savings

    type Create'PaymentMethodDataUsBankAccount = {
        ///Account holder type: individual or company.
        [<Config.Form>]AccountHolderType: Create'PaymentMethodDataUsBankAccountAccountHolderType option
        ///Account number of the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Account type: checkings or savings. Defaults to checking if omitted.
        [<Config.Form>]AccountType: Create'PaymentMethodDataUsBankAccountAccountType option
        ///The ID of a Financial Connections Account to use as a payment method.
        [<Config.Form>]FinancialConnectionsAccount: string option
        ///Routing number of the bank account.
        [<Config.Form>]RoutingNumber: string option
    }
    with
        static member New(?accountHolderType: Create'PaymentMethodDataUsBankAccountAccountHolderType, ?accountNumber: string, ?accountType: Create'PaymentMethodDataUsBankAccountAccountType, ?financialConnectionsAccount: string, ?routingNumber: string) =
            {
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                FinancialConnectionsAccount = financialConnectionsAccount
                RoutingNumber = routingNumber
            }

    type Create'PaymentMethodDataType =
    | AcssDebit
    | Affirm
    | AfterpayClearpay
    | Alipay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Blik
    | Boleto
    | Cashapp
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Klarna
    | Konbini
    | Link
    | Oxxo
    | P24
    | Paynow
    | Paypal
    | Pix
    | Promptpay
    | SepaDebit
    | Sofort
    | UsBankAccount
    | WechatPay
    | Zip

    type Create'PaymentMethodData = {
        ///If this is an `acss_debit` PaymentMethod, this hash contains details about the ACSS Debit payment method.
        [<Config.Form>]AcssDebit: Create'PaymentMethodDataAcssDebit option
        ///If this is an `affirm` PaymentMethod, this hash contains details about the Affirm payment method.
        [<Config.Form>]Affirm: string option
        ///If this is an `AfterpayClearpay` PaymentMethod, this hash contains details about the AfterpayClearpay payment method.
        [<Config.Form>]AfterpayClearpay: string option
        ///If this is an `Alipay` PaymentMethod, this hash contains details about the Alipay payment method.
        [<Config.Form>]Alipay: string option
        ///If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
        [<Config.Form>]AuBecsDebit: Create'PaymentMethodDataAuBecsDebit option
        ///If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
        [<Config.Form>]BacsDebit: Create'PaymentMethodDataBacsDebit option
        ///If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
        [<Config.Form>]Bancontact: string option
        ///Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
        [<Config.Form>]BillingDetails: Create'PaymentMethodDataBillingDetails option
        ///If this is a `blik` PaymentMethod, this hash contains details about the BLIK payment method.
        [<Config.Form>]Blik: string option
        ///If this is a `boleto` PaymentMethod, this hash contains details about the Boleto payment method.
        [<Config.Form>]Boleto: Create'PaymentMethodDataBoleto option
        ///If this is a `cashapp` PaymentMethod, this hash contains details about the Cash App Pay payment method.
        [<Config.Form>]Cashapp: string option
        ///If this is a `customer_balance` PaymentMethod, this hash contains details about the CustomerBalance payment method.
        [<Config.Form>]CustomerBalance: string option
        ///If this is an `eps` PaymentMethod, this hash contains details about the EPS payment method.
        [<Config.Form>]Eps: Create'PaymentMethodDataEps option
        ///If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
        [<Config.Form>]Fpx: Create'PaymentMethodDataFpx option
        ///If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
        [<Config.Form>]Giropay: string option
        ///If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
        [<Config.Form>]Grabpay: string option
        ///If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
        [<Config.Form>]Ideal: Create'PaymentMethodDataIdeal option
        ///If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
        [<Config.Form>]InteracPresent: string option
        ///If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method.
        [<Config.Form>]Klarna: Create'PaymentMethodDataKlarna option
        ///If this is a `konbini` PaymentMethod, this hash contains details about the Konbini payment method.
        [<Config.Form>]Konbini: string option
        ///If this is an `Link` PaymentMethod, this hash contains details about the Link payment method.
        [<Config.Form>]Link: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
        [<Config.Form>]Oxxo: string option
        ///If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
        [<Config.Form>]P24: Create'PaymentMethodDataP24 option
        ///If this is a `paynow` PaymentMethod, this hash contains details about the PayNow payment method.
        [<Config.Form>]Paynow: string option
        ///If this is a `paypal` PaymentMethod, this hash contains details about the PayPal payment method.
        [<Config.Form>]Paypal: string option
        ///If this is a `pix` PaymentMethod, this hash contains details about the Pix payment method.
        [<Config.Form>]Pix: string option
        ///If this is a `promptpay` PaymentMethod, this hash contains details about the PromptPay payment method.
        [<Config.Form>]Promptpay: string option
        ///Options to configure Radar. See [Radar Session](https://stripe.com/docs/radar/radar-session) for more information.
        [<Config.Form>]RadarOptions: Create'PaymentMethodDataRadarOptions option
        ///If this is a `sepa_debit` PaymentMethod, this hash contains details about the SEPA debit bank account.
        [<Config.Form>]SepaDebit: Create'PaymentMethodDataSepaDebit option
        ///If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
        [<Config.Form>]Sofort: Create'PaymentMethodDataSofort option
        ///The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
        [<Config.Form>]Type: Create'PaymentMethodDataType option
        ///If this is an `us_bank_account` PaymentMethod, this hash contains details about the US bank account payment method.
        [<Config.Form>]UsBankAccount: Create'PaymentMethodDataUsBankAccount option
        ///If this is an `wechat_pay` PaymentMethod, this hash contains details about the wechat_pay payment method.
        [<Config.Form>]WechatPay: string option
        ///If this is a `zip` PaymentMethod, this hash contains details about the Zip payment method.
        [<Config.Form>]Zip: string option
    }
    with
        static member New(?acssDebit: Create'PaymentMethodDataAcssDebit, ?konbini: string, ?link: string, ?metadata: Map<string, string>, ?oxxo: string, ?p24: Create'PaymentMethodDataP24, ?paynow: string, ?klarna: Create'PaymentMethodDataKlarna, ?paypal: string, ?promptpay: string, ?radarOptions: Create'PaymentMethodDataRadarOptions, ?sepaDebit: Create'PaymentMethodDataSepaDebit, ?sofort: Create'PaymentMethodDataSofort, ?type': Create'PaymentMethodDataType, ?usBankAccount: Create'PaymentMethodDataUsBankAccount, ?pix: string, ?wechatPay: string, ?interacPresent: string, ?grabpay: string, ?affirm: string, ?afterpayClearpay: string, ?alipay: string, ?auBecsDebit: Create'PaymentMethodDataAuBecsDebit, ?bacsDebit: Create'PaymentMethodDataBacsDebit, ?bancontact: string, ?ideal: Create'PaymentMethodDataIdeal, ?billingDetails: Create'PaymentMethodDataBillingDetails, ?boleto: Create'PaymentMethodDataBoleto, ?cashapp: string, ?customerBalance: string, ?eps: Create'PaymentMethodDataEps, ?fpx: Create'PaymentMethodDataFpx, ?giropay: string, ?blik: string, ?zip: string) =
            {
                AcssDebit = acssDebit
                Affirm = affirm
                AfterpayClearpay = afterpayClearpay
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                BillingDetails = billingDetails
                Blik = blik
                Boleto = boleto
                Cashapp = cashapp
                CustomerBalance = customerBalance
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Klarna = klarna
                Konbini = konbini
                Link = link
                Metadata = metadata
                Oxxo = oxxo
                P24 = p24
                Paynow = paynow
                Paypal = paypal
                Pix = pix
                Promptpay = promptpay
                RadarOptions = radarOptions
                SepaDebit = sepaDebit
                Sofort = sofort
                Type = type'
                UsBankAccount = usBankAccount
                WechatPay = wechatPay
                Zip = zip
            }

    type Create'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor =
    | Invoice
    | Subscription

    type Create'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule =
    | Combined
    | Interval
    | Sporadic

    type Create'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType =
    | Business
    | Personal

    type Create'PaymentMethodOptionsAcssDebitMandateOptions = {
        ///A URL for custom mandate text to render during confirmation step.
        ///The URL will be rendered with additional GET parameters `payment_intent` and `payment_intent_client_secret` when confirming a Payment Intent,
        ///or `setup_intent` and `setup_intent_client_secret` when confirming a Setup Intent.
        [<Config.Form>]CustomMandateUrl: Choice<string,string> option
        ///List of Stripe products where this mandate can be selected automatically.
        [<Config.Form>]DefaultFor: Create'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list option
        ///Description of the mandate interval. Only required if 'payment_schedule' parameter is 'interval' or 'combined'.
        [<Config.Form>]IntervalDescription: string option
        ///Payment schedule for the mandate.
        [<Config.Form>]PaymentSchedule: Create'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule option
        ///Transaction type of the mandate.
        [<Config.Form>]TransactionType: Create'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType option
    }
    with
        static member New(?customMandateUrl: Choice<string,string>, ?defaultFor: Create'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list, ?intervalDescription: string, ?paymentSchedule: Create'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule, ?transactionType: Create'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType) =
            {
                CustomMandateUrl = customMandateUrl
                DefaultFor = defaultFor
                IntervalDescription = intervalDescription
                PaymentSchedule = paymentSchedule
                TransactionType = transactionType
            }

    type Create'PaymentMethodOptionsAcssDebitCurrency =
    | Cad
    | Usd

    type Create'PaymentMethodOptionsAcssDebitVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Create'PaymentMethodOptionsAcssDebit = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: Create'PaymentMethodOptionsAcssDebitCurrency option
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: Create'PaymentMethodOptionsAcssDebitMandateOptions option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Create'PaymentMethodOptionsAcssDebitVerificationMethod option
    }
    with
        static member New(?currency: Create'PaymentMethodOptionsAcssDebitCurrency, ?mandateOptions: Create'PaymentMethodOptionsAcssDebitMandateOptions, ?verificationMethod: Create'PaymentMethodOptionsAcssDebitVerificationMethod) =
            {
                Currency = currency
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Create'PaymentMethodOptionsCardMandateOptionsSupportedTypes =
    | India

    type Create'PaymentMethodOptionsCardMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Create'PaymentMethodOptionsCardMandateOptionsInterval =
    | Day
    | Month
    | Sporadic
    | Week
    | Year

    type Create'PaymentMethodOptionsCardMandateOptions = {
        ///Amount to be charged for future payments.
        [<Config.Form>]Amount: int option
        ///One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
        [<Config.Form>]AmountType: Create'PaymentMethodOptionsCardMandateOptionsAmountType option
        ///Currency in which future payments will be charged. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///A description of the mandate or subscription that is meant to be displayed to the customer.
        [<Config.Form>]Description: string option
        ///End date of the mandate or subscription. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.
        [<Config.Form>]EndDate: DateTime option
        ///Specifies payment frequency. One of `day`, `week`, `month`, `year`, or `sporadic`.
        [<Config.Form>]Interval: Create'PaymentMethodOptionsCardMandateOptionsInterval option
        ///The number of intervals between payments. For example, `interval=month` and `interval_count=3` indicates one payment every three months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks). This parameter is optional when `interval=sporadic`.
        [<Config.Form>]IntervalCount: int option
        ///Unique identifier for the mandate or subscription.
        [<Config.Form>]Reference: string option
        ///Start date of the mandate or subscription. Start date should not be lesser than yesterday.
        [<Config.Form>]StartDate: DateTime option
        ///Specifies the type of mandates supported. Possible values are `india`.
        [<Config.Form>]SupportedTypes: Create'PaymentMethodOptionsCardMandateOptionsSupportedTypes list option
    }
    with
        static member New(?amount: int, ?amountType: Create'PaymentMethodOptionsCardMandateOptionsAmountType, ?currency: string, ?description: string, ?endDate: DateTime, ?interval: Create'PaymentMethodOptionsCardMandateOptionsInterval, ?intervalCount: int, ?reference: string, ?startDate: DateTime, ?supportedTypes: Create'PaymentMethodOptionsCardMandateOptionsSupportedTypes list) =
            {
                Amount = amount
                AmountType = amountType
                Currency = currency
                Description = description
                EndDate = endDate
                Interval = interval
                IntervalCount = intervalCount
                Reference = reference
                StartDate = startDate
                SupportedTypes = supportedTypes
            }

    type Create'PaymentMethodOptionsCardNetwork =
    | Amex
    | CartesBancaires
    | Diners
    | Discover
    | EftposAu
    | Interac
    | Jcb
    | Mastercard
    | Unionpay
    | Unknown
    | Visa

    type Create'PaymentMethodOptionsCardRequestThreeDSecure =
    | Any
    | Automatic

    type Create'PaymentMethodOptionsCard = {
        ///Configuration options for setting up an eMandate for cards issued in India.
        [<Config.Form>]MandateOptions: Create'PaymentMethodOptionsCardMandateOptions option
        ///When specified, this parameter signals that a card has been collected
        ///as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
        ///parameter can only be provided during confirmation.
        [<Config.Form>]Moto: bool option
        ///Selected network to process this SetupIntent on. Depends on the available networks of the card attached to the SetupIntent. Can be only set confirm-time.
        [<Config.Form>]Network: Create'PaymentMethodOptionsCardNetwork option
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        [<Config.Form>]RequestThreeDSecure: Create'PaymentMethodOptionsCardRequestThreeDSecure option
    }
    with
        static member New(?mandateOptions: Create'PaymentMethodOptionsCardMandateOptions, ?moto: bool, ?network: Create'PaymentMethodOptionsCardNetwork, ?requestThreeDSecure: Create'PaymentMethodOptionsCardRequestThreeDSecure) =
            {
                MandateOptions = mandateOptions
                Moto = moto
                Network = network
                RequestThreeDSecure = requestThreeDSecure
            }

    type Create'PaymentMethodOptionsLink = {
        ///[Deprecated] This is a legacy parameter that no longer has any function.
        [<Config.Form>]PersistentToken: string option
    }
    with
        static member New(?persistentToken: string) =
            {
                PersistentToken = persistentToken
            }

    type Create'PaymentMethodOptionsPaypal = {
        ///The PayPal Billing Agreement ID (BAID). This is an ID generated by PayPal which represents the mandate between the merchant and the customer.
        [<Config.Form>]BillingAgreementId: string option
    }
    with
        static member New(?billingAgreementId: string) =
            {
                BillingAgreementId = billingAgreementId
            }

    type Create'PaymentMethodOptionsSepaDebit = {
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: string option
    }
    with
        static member New(?mandateOptions: string) =
            {
                MandateOptions = mandateOptions
            }

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch =
    | Balances

    type Create'PaymentMethodOptionsUsBankAccountFinancialConnections = {
        ///The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
        [<Config.Form>]Permissions: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list option
        ///List of data features that you would like to retrieve upon account creation.
        [<Config.Form>]Prefetch: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list option
        ///For webview integrations only. Upon completing OAuth login in the native browser, the user will be redirected to this URL to return to your app.
        [<Config.Form>]ReturnUrl: string option
    }
    with
        static member New(?permissions: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list, ?prefetch: Create'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list, ?returnUrl: string) =
            {
                Permissions = permissions
                Prefetch = prefetch
                ReturnUrl = returnUrl
            }

    type Create'PaymentMethodOptionsUsBankAccountNetworksRequested =
    | Ach
    | UsDomesticWire

    type Create'PaymentMethodOptionsUsBankAccountNetworks = {
        ///Triggers validations to run across the selected networks
        [<Config.Form>]Requested: Create'PaymentMethodOptionsUsBankAccountNetworksRequested list option
    }
    with
        static member New(?requested: Create'PaymentMethodOptionsUsBankAccountNetworksRequested list) =
            {
                Requested = requested
            }

    type Create'PaymentMethodOptionsUsBankAccountVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Create'PaymentMethodOptionsUsBankAccount = {
        ///Additional fields for Financial Connections Session creation
        [<Config.Form>]FinancialConnections: Create'PaymentMethodOptionsUsBankAccountFinancialConnections option
        ///Additional fields for network related functions
        [<Config.Form>]Networks: Create'PaymentMethodOptionsUsBankAccountNetworks option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Create'PaymentMethodOptionsUsBankAccountVerificationMethod option
    }
    with
        static member New(?financialConnections: Create'PaymentMethodOptionsUsBankAccountFinancialConnections, ?networks: Create'PaymentMethodOptionsUsBankAccountNetworks, ?verificationMethod: Create'PaymentMethodOptionsUsBankAccountVerificationMethod) =
            {
                FinancialConnections = financialConnections
                Networks = networks
                VerificationMethod = verificationMethod
            }

    type Create'PaymentMethodOptions = {
        ///If this is a `acss_debit` SetupIntent, this sub-hash contains details about the ACSS Debit payment method options.
        [<Config.Form>]AcssDebit: Create'PaymentMethodOptionsAcssDebit option
        ///Configuration for any card setup attempted on this SetupIntent.
        [<Config.Form>]Card: Create'PaymentMethodOptionsCard option
        ///If this is a `link` PaymentMethod, this sub-hash contains details about the Link payment method options.
        [<Config.Form>]Link: Create'PaymentMethodOptionsLink option
        ///If this is a `paypal` PaymentMethod, this sub-hash contains details about the PayPal payment method options.
        [<Config.Form>]Paypal: Create'PaymentMethodOptionsPaypal option
        ///If this is a `sepa_debit` SetupIntent, this sub-hash contains details about the SEPA Debit payment method options.
        [<Config.Form>]SepaDebit: Create'PaymentMethodOptionsSepaDebit option
        ///If this is a `us_bank_account` SetupIntent, this sub-hash contains details about the US bank account payment method options.
        [<Config.Form>]UsBankAccount: Create'PaymentMethodOptionsUsBankAccount option
    }
    with
        static member New(?acssDebit: Create'PaymentMethodOptionsAcssDebit, ?card: Create'PaymentMethodOptionsCard, ?link: Create'PaymentMethodOptionsLink, ?paypal: Create'PaymentMethodOptionsPaypal, ?sepaDebit: Create'PaymentMethodOptionsSepaDebit, ?usBankAccount: Create'PaymentMethodOptionsUsBankAccount) =
            {
                AcssDebit = acssDebit
                Card = card
                Link = link
                Paypal = paypal
                SepaDebit = sepaDebit
                UsBankAccount = usBankAccount
            }

    type Create'SingleUse = {
        ///Amount the customer is granting permission to collect later. A positive integer representing how much to charge in the [smallest currency unit](https://stripe.com/docs/currencies#zero-decimal) (e.g., 100 cents to charge $1.00 or 100 to charge ¥100, a zero-decimal currency). The minimum amount is $0.50 US or [equivalent in charge currency](https://stripe.com/docs/currencies#minimum-and-maximum-charge-amounts). The amount value supports up to eight digits (e.g., a value of 99999999 for a USD charge of $999,999.99).
        [<Config.Form>]Amount: int option
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
    }
    with
        static member New(?amount: int, ?currency: string) =
            {
                Amount = amount
                Currency = currency
            }

    type Create'Usage =
    | OffSession
    | OnSession

    type CreateOptions = {
        ///If present, the SetupIntent's payment method will be attached to the in-context Stripe Account.
        ///It can only be used for this Stripe Account’s own money movement flows like InboundTransfer and OutboundTransfers. It cannot be set to true when setting up a PaymentMethod for a Customer, and defaults to false when attaching a PaymentMethod to a Customer.
        [<Config.Form>]AttachToSelf: bool option
        ///When enabled, this SetupIntent will accept payment methods that you have enabled in the Dashboard and are compatible with this SetupIntent's other parameters.
        [<Config.Form>]AutomaticPaymentMethods: Create'AutomaticPaymentMethods option
        ///Set to `true` to attempt to confirm this SetupIntent immediately. This parameter defaults to `false`. If the payment method attached is a card, a return_url may be provided in case additional authentication is required.
        [<Config.Form>]Confirm: bool option
        ///ID of the Customer this SetupIntent belongs to, if one exists.
        ///If present, the SetupIntent's payment method will be attached to the Customer on successful setup. Payment methods attached to other Customers cannot be used with this SetupIntent.
        [<Config.Form>]Customer: string option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Indicates the directions of money movement for which this payment method is intended to be used.
        ///Include `inbound` if you intend to use the payment method as the origin to pull funds from. Include `outbound` if you intend to use the payment method as the destination to send funds to. You can include both if you intend to use the payment method for both purposes.
        [<Config.Form>]FlowDirections: Create'FlowDirections list option
        ///This hash contains details about the Mandate to create. This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/setup_intents/create#create_setup_intent-confirm).
        [<Config.Form>]MandateData: Choice<Create'MandateDataSecretKey,string> option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The Stripe account ID for which this SetupIntent is created.
        [<Config.Form>]OnBehalfOf: string option
        ///ID of the payment method (a PaymentMethod, Card, or saved Source object) to attach to this SetupIntent.
        [<Config.Form>]PaymentMethod: string option
        ///When included, this hash creates a PaymentMethod that is set as the [`payment_method`](https://stripe.com/docs/api/setup_intents/object#setup_intent_object-payment_method)
        ///value in the SetupIntent.
        [<Config.Form>]PaymentMethodData: Create'PaymentMethodData option
        ///Payment-method-specific configuration for this SetupIntent.
        [<Config.Form>]PaymentMethodOptions: Create'PaymentMethodOptions option
        ///The list of payment method types (e.g. card) that this SetupIntent is allowed to use. If this is not provided, defaults to ["card"].
        [<Config.Form>]PaymentMethodTypes: string list option
        ///The URL to redirect your customer back to after they authenticate or cancel their payment on the payment method's app or site. If you'd prefer to redirect to a mobile application, you can alternatively supply an application URI scheme. This parameter can only be used with [`confirm=true`](https://stripe.com/docs/api/setup_intents/create#create_setup_intent-confirm).
        [<Config.Form>]ReturnUrl: string option
        ///If this hash is populated, this SetupIntent will generate a single_use Mandate on success.
        [<Config.Form>]SingleUse: Create'SingleUse option
        ///Indicates how the payment method is intended to be used in the future. If not provided, this value defaults to `off_session`.
        [<Config.Form>]Usage: Create'Usage option
        ///Set to `true` when confirming server-side and using Stripe.js, iOS, or Android client-side SDKs to handle the next actions.
        [<Config.Form>]UseStripeSdk: bool option
    }
    with
        static member New(?attachToSelf: bool, ?singleUse: Create'SingleUse, ?returnUrl: string, ?paymentMethodTypes: string list, ?paymentMethodOptions: Create'PaymentMethodOptions, ?paymentMethodData: Create'PaymentMethodData, ?paymentMethod: string, ?onBehalfOf: string, ?metadata: Map<string, string>, ?mandateData: Choice<Create'MandateDataSecretKey,string>, ?flowDirections: Create'FlowDirections list, ?expand: string list, ?description: string, ?customer: string, ?confirm: bool, ?automaticPaymentMethods: Create'AutomaticPaymentMethods, ?usage: Create'Usage, ?useStripeSdk: bool) =
            {
                AttachToSelf = attachToSelf
                AutomaticPaymentMethods = automaticPaymentMethods
                Confirm = confirm
                Customer = customer
                Description = description
                Expand = expand
                FlowDirections = flowDirections
                MandateData = mandateData
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                PaymentMethod = paymentMethod
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
                ReturnUrl = returnUrl
                SingleUse = singleUse
                Usage = usage
                UseStripeSdk = useStripeSdk
            }

    ///<p>Creates a SetupIntent object.
    ///After the SetupIntent is created, attach a payment method and <a href="/docs/api/setup_intents/confirm">confirm</a>
    ///to collect any required permissions to charge the payment method later.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/setup_intents"
        |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) options

    type RetrieveOptions = {
        ///The client secret of the SetupIntent. Required if a publishable key is used to retrieve the SetupIntent.
        [<Config.Query>]ClientSecret: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Intent: string
    }
    with
        static member New(intent: string, ?expand: string list, ?clientSecret: string) =
            {
                ClientSecret = clientSecret
                Expand = expand
                Intent = intent
            }

    ///<p>Retrieves the details of a SetupIntent that has previously been created. 
    ///Client-side retrieval using a publishable key is allowed when the <code>client_secret</code> is provided in the query string. 
    ///When retrieved with a publishable key, only a subset of properties will be returned. Please refer to the <a href="#setup_intent_object">SetupIntent</a> object reference for more details.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("client_secret", options.ClientSecret |> box); ("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/setup_intents/{options.Intent}"
        |> RestApi.getAsync<SetupIntent> settings qs

    type Update'FlowDirections =
    | Inbound
    | Outbound

    type Update'PaymentMethodDataAcssDebit = {
        ///Customer's bank account number.
        [<Config.Form>]AccountNumber: string option
        ///Institution number of the customer's bank.
        [<Config.Form>]InstitutionNumber: string option
        ///Transit number of the customer's bank.
        [<Config.Form>]TransitNumber: string option
    }
    with
        static member New(?accountNumber: string, ?institutionNumber: string, ?transitNumber: string) =
            {
                AccountNumber = accountNumber
                InstitutionNumber = institutionNumber
                TransitNumber = transitNumber
            }

    type Update'PaymentMethodDataAuBecsDebit = {
        ///The account number for the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Bank-State-Branch number of the bank account.
        [<Config.Form>]BsbNumber: string option
    }
    with
        static member New(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type Update'PaymentMethodDataBacsDebit = {
        ///Account number of the bank account that the funds will be debited from.
        [<Config.Form>]AccountNumber: string option
        ///Sort code of the bank account. (e.g., `10-20-30`)
        [<Config.Form>]SortCode: string option
    }
    with
        static member New(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type Update'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'PaymentMethodDataBillingDetails = {
        ///Billing address.
        [<Config.Form>]Address: Choice<Update'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
        ///Email address.
        [<Config.Form>]Email: Choice<string,string> option
        ///Full name.
        [<Config.Form>]Name: Choice<string,string> option
        ///Billing phone number (including extension).
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Choice<Update'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: Choice<string,string>, ?name: Choice<string,string>, ?phone: Choice<string,string>) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Update'PaymentMethodDataBoleto = {
        ///The tax ID of the customer (CPF for individual consumers or CNPJ for businesses consumers)
        [<Config.Form>]TaxId: string option
    }
    with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Update'PaymentMethodDataEpsBank =
    | ArzteUndApothekerBank
    | AustrianAnadiBankAg
    | BankAustria
    | BankhausCarlSpangler
    | BankhausSchelhammerUndSchatteraAg
    | BawagPskAg
    | BksBankAg
    | BrullKallmusBankAg
    | BtvVierLanderBank
    | CapitalBankGraweGruppeAg
    | DeutscheBankAg
    | Dolomitenbank
    | EasybankAg
    | ErsteBankUndSparkassen
    | HypoAlpeadriabankInternationalAg
    | HypoBankBurgenlandAktiengesellschaft
    | HypoNoeLbFurNiederosterreichUWien
    | HypoOberosterreichSalzburgSteiermark
    | HypoTirolBankAg
    | HypoVorarlbergBankAg
    | MarchfelderBank
    | OberbankAg
    | RaiffeisenBankengruppeOsterreich
    | SchoellerbankAg
    | SpardaBankWien
    | VolksbankGruppe
    | VolkskreditbankAg
    | VrBankBraunau

    type Update'PaymentMethodDataEps = {
        ///The customer's bank.
        [<Config.Form>]Bank: Update'PaymentMethodDataEpsBank option
    }
    with
        static member New(?bank: Update'PaymentMethodDataEpsBank) =
            {
                Bank = bank
            }

    type Update'PaymentMethodDataFpxAccountHolderType =
    | Company
    | Individual

    type Update'PaymentMethodDataFpxBank =
    | AffinBank
    | Agrobank
    | AllianceBank
    | Ambank
    | BankIslam
    | BankMuamalat
    | BankOfChina
    | BankRakyat
    | Bsn
    | Cimb
    | DeutscheBank
    | HongLeongBank
    | Hsbc
    | Kfh
    | Maybank2e
    | Maybank2u
    | Ocbc
    | PbEnterprise
    | PublicBank
    | Rhb
    | StandardChartered
    | Uob

    type Update'PaymentMethodDataFpx = {
        ///Account holder type for FPX transaction
        [<Config.Form>]AccountHolderType: Update'PaymentMethodDataFpxAccountHolderType option
        ///The customer's bank.
        [<Config.Form>]Bank: Update'PaymentMethodDataFpxBank option
    }
    with
        static member New(?accountHolderType: Update'PaymentMethodDataFpxAccountHolderType, ?bank: Update'PaymentMethodDataFpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type Update'PaymentMethodDataIdealBank =
    | AbnAmro
    | AsnBank
    | Bunq
    | Handelsbanken
    | Ing
    | Knab
    | Moneyou
    | Rabobank
    | Regiobank
    | Revolut
    | SnsBank
    | TriodosBank
    | VanLanschot
    | Yoursafe

    type Update'PaymentMethodDataIdeal = {
        ///The customer's bank.
        [<Config.Form>]Bank: Update'PaymentMethodDataIdealBank option
    }
    with
        static member New(?bank: Update'PaymentMethodDataIdealBank) =
            {
                Bank = bank
            }

    type Update'PaymentMethodDataKlarnaDob = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Update'PaymentMethodDataKlarna = {
        ///Customer's date of birth
        [<Config.Form>]Dob: Update'PaymentMethodDataKlarnaDob option
    }
    with
        static member New(?dob: Update'PaymentMethodDataKlarnaDob) =
            {
                Dob = dob
            }

    type Update'PaymentMethodDataP24Bank =
    | AliorBank
    | BankMillennium
    | BankNowyBfgSa
    | BankPekaoSa
    | BankiSpbdzielcze
    | Blik
    | BnpParibas
    | Boz
    | CitiHandlowy
    | CreditAgricole
    | Envelobank
    | EtransferPocztowy24
    | GetinBank
    | Ideabank
    | Ing
    | Inteligo
    | MbankMtransfer
    | NestPrzelew
    | NoblePay
    | PbacZIpko
    | PlusBank
    | SantanderPrzelew24
    | TmobileUsbugiBankowe
    | ToyotaBank
    | VolkswagenBank

    type Update'PaymentMethodDataP24 = {
        ///The customer's bank.
        [<Config.Form>]Bank: Update'PaymentMethodDataP24Bank option
    }
    with
        static member New(?bank: Update'PaymentMethodDataP24Bank) =
            {
                Bank = bank
            }

    type Update'PaymentMethodDataRadarOptions = {
        ///A [Radar Session](https://stripe.com/docs/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
        [<Config.Form>]Session: string option
    }
    with
        static member New(?session: string) =
            {
                Session = session
            }

    type Update'PaymentMethodDataSepaDebit = {
        ///IBAN of the bank account.
        [<Config.Form>]Iban: string option
    }
    with
        static member New(?iban: string) =
            {
                Iban = iban
            }

    type Update'PaymentMethodDataSofortCountry =
    | [<JsonUnionCase("AT")>] AT
    | [<JsonUnionCase("BE")>] BE
    | [<JsonUnionCase("DE")>] DE
    | [<JsonUnionCase("ES")>] ES
    | [<JsonUnionCase("IT")>] IT
    | [<JsonUnionCase("NL")>] NL

    type Update'PaymentMethodDataSofort = {
        ///Two-letter ISO code representing the country the bank account is located in.
        [<Config.Form>]Country: Update'PaymentMethodDataSofortCountry option
    }
    with
        static member New(?country: Update'PaymentMethodDataSofortCountry) =
            {
                Country = country
            }

    type Update'PaymentMethodDataUsBankAccountAccountHolderType =
    | Company
    | Individual

    type Update'PaymentMethodDataUsBankAccountAccountType =
    | Checking
    | Savings

    type Update'PaymentMethodDataUsBankAccount = {
        ///Account holder type: individual or company.
        [<Config.Form>]AccountHolderType: Update'PaymentMethodDataUsBankAccountAccountHolderType option
        ///Account number of the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Account type: checkings or savings. Defaults to checking if omitted.
        [<Config.Form>]AccountType: Update'PaymentMethodDataUsBankAccountAccountType option
        ///The ID of a Financial Connections Account to use as a payment method.
        [<Config.Form>]FinancialConnectionsAccount: string option
        ///Routing number of the bank account.
        [<Config.Form>]RoutingNumber: string option
    }
    with
        static member New(?accountHolderType: Update'PaymentMethodDataUsBankAccountAccountHolderType, ?accountNumber: string, ?accountType: Update'PaymentMethodDataUsBankAccountAccountType, ?financialConnectionsAccount: string, ?routingNumber: string) =
            {
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                FinancialConnectionsAccount = financialConnectionsAccount
                RoutingNumber = routingNumber
            }

    type Update'PaymentMethodDataType =
    | AcssDebit
    | Affirm
    | AfterpayClearpay
    | Alipay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Blik
    | Boleto
    | Cashapp
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Klarna
    | Konbini
    | Link
    | Oxxo
    | P24
    | Paynow
    | Paypal
    | Pix
    | Promptpay
    | SepaDebit
    | Sofort
    | UsBankAccount
    | WechatPay
    | Zip

    type Update'PaymentMethodData = {
        ///If this is an `acss_debit` PaymentMethod, this hash contains details about the ACSS Debit payment method.
        [<Config.Form>]AcssDebit: Update'PaymentMethodDataAcssDebit option
        ///If this is an `affirm` PaymentMethod, this hash contains details about the Affirm payment method.
        [<Config.Form>]Affirm: string option
        ///If this is an `AfterpayClearpay` PaymentMethod, this hash contains details about the AfterpayClearpay payment method.
        [<Config.Form>]AfterpayClearpay: string option
        ///If this is an `Alipay` PaymentMethod, this hash contains details about the Alipay payment method.
        [<Config.Form>]Alipay: string option
        ///If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
        [<Config.Form>]AuBecsDebit: Update'PaymentMethodDataAuBecsDebit option
        ///If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
        [<Config.Form>]BacsDebit: Update'PaymentMethodDataBacsDebit option
        ///If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
        [<Config.Form>]Bancontact: string option
        ///Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
        [<Config.Form>]BillingDetails: Update'PaymentMethodDataBillingDetails option
        ///If this is a `blik` PaymentMethod, this hash contains details about the BLIK payment method.
        [<Config.Form>]Blik: string option
        ///If this is a `boleto` PaymentMethod, this hash contains details about the Boleto payment method.
        [<Config.Form>]Boleto: Update'PaymentMethodDataBoleto option
        ///If this is a `cashapp` PaymentMethod, this hash contains details about the Cash App Pay payment method.
        [<Config.Form>]Cashapp: string option
        ///If this is a `customer_balance` PaymentMethod, this hash contains details about the CustomerBalance payment method.
        [<Config.Form>]CustomerBalance: string option
        ///If this is an `eps` PaymentMethod, this hash contains details about the EPS payment method.
        [<Config.Form>]Eps: Update'PaymentMethodDataEps option
        ///If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
        [<Config.Form>]Fpx: Update'PaymentMethodDataFpx option
        ///If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
        [<Config.Form>]Giropay: string option
        ///If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
        [<Config.Form>]Grabpay: string option
        ///If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
        [<Config.Form>]Ideal: Update'PaymentMethodDataIdeal option
        ///If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
        [<Config.Form>]InteracPresent: string option
        ///If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method.
        [<Config.Form>]Klarna: Update'PaymentMethodDataKlarna option
        ///If this is a `konbini` PaymentMethod, this hash contains details about the Konbini payment method.
        [<Config.Form>]Konbini: string option
        ///If this is an `Link` PaymentMethod, this hash contains details about the Link payment method.
        [<Config.Form>]Link: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
        [<Config.Form>]Oxxo: string option
        ///If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
        [<Config.Form>]P24: Update'PaymentMethodDataP24 option
        ///If this is a `paynow` PaymentMethod, this hash contains details about the PayNow payment method.
        [<Config.Form>]Paynow: string option
        ///If this is a `paypal` PaymentMethod, this hash contains details about the PayPal payment method.
        [<Config.Form>]Paypal: string option
        ///If this is a `pix` PaymentMethod, this hash contains details about the Pix payment method.
        [<Config.Form>]Pix: string option
        ///If this is a `promptpay` PaymentMethod, this hash contains details about the PromptPay payment method.
        [<Config.Form>]Promptpay: string option
        ///Options to configure Radar. See [Radar Session](https://stripe.com/docs/radar/radar-session) for more information.
        [<Config.Form>]RadarOptions: Update'PaymentMethodDataRadarOptions option
        ///If this is a `sepa_debit` PaymentMethod, this hash contains details about the SEPA debit bank account.
        [<Config.Form>]SepaDebit: Update'PaymentMethodDataSepaDebit option
        ///If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
        [<Config.Form>]Sofort: Update'PaymentMethodDataSofort option
        ///The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
        [<Config.Form>]Type: Update'PaymentMethodDataType option
        ///If this is an `us_bank_account` PaymentMethod, this hash contains details about the US bank account payment method.
        [<Config.Form>]UsBankAccount: Update'PaymentMethodDataUsBankAccount option
        ///If this is an `wechat_pay` PaymentMethod, this hash contains details about the wechat_pay payment method.
        [<Config.Form>]WechatPay: string option
        ///If this is a `zip` PaymentMethod, this hash contains details about the Zip payment method.
        [<Config.Form>]Zip: string option
    }
    with
        static member New(?acssDebit: Update'PaymentMethodDataAcssDebit, ?konbini: string, ?link: string, ?metadata: Map<string, string>, ?oxxo: string, ?p24: Update'PaymentMethodDataP24, ?paynow: string, ?klarna: Update'PaymentMethodDataKlarna, ?paypal: string, ?promptpay: string, ?radarOptions: Update'PaymentMethodDataRadarOptions, ?sepaDebit: Update'PaymentMethodDataSepaDebit, ?sofort: Update'PaymentMethodDataSofort, ?type': Update'PaymentMethodDataType, ?usBankAccount: Update'PaymentMethodDataUsBankAccount, ?pix: string, ?wechatPay: string, ?interacPresent: string, ?grabpay: string, ?affirm: string, ?afterpayClearpay: string, ?alipay: string, ?auBecsDebit: Update'PaymentMethodDataAuBecsDebit, ?bacsDebit: Update'PaymentMethodDataBacsDebit, ?bancontact: string, ?ideal: Update'PaymentMethodDataIdeal, ?billingDetails: Update'PaymentMethodDataBillingDetails, ?boleto: Update'PaymentMethodDataBoleto, ?cashapp: string, ?customerBalance: string, ?eps: Update'PaymentMethodDataEps, ?fpx: Update'PaymentMethodDataFpx, ?giropay: string, ?blik: string, ?zip: string) =
            {
                AcssDebit = acssDebit
                Affirm = affirm
                AfterpayClearpay = afterpayClearpay
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                BillingDetails = billingDetails
                Blik = blik
                Boleto = boleto
                Cashapp = cashapp
                CustomerBalance = customerBalance
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Klarna = klarna
                Konbini = konbini
                Link = link
                Metadata = metadata
                Oxxo = oxxo
                P24 = p24
                Paynow = paynow
                Paypal = paypal
                Pix = pix
                Promptpay = promptpay
                RadarOptions = radarOptions
                SepaDebit = sepaDebit
                Sofort = sofort
                Type = type'
                UsBankAccount = usBankAccount
                WechatPay = wechatPay
                Zip = zip
            }

    type Update'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor =
    | Invoice
    | Subscription

    type Update'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule =
    | Combined
    | Interval
    | Sporadic

    type Update'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType =
    | Business
    | Personal

    type Update'PaymentMethodOptionsAcssDebitMandateOptions = {
        ///A URL for custom mandate text to render during confirmation step.
        ///The URL will be rendered with additional GET parameters `payment_intent` and `payment_intent_client_secret` when confirming a Payment Intent,
        ///or `setup_intent` and `setup_intent_client_secret` when confirming a Setup Intent.
        [<Config.Form>]CustomMandateUrl: Choice<string,string> option
        ///List of Stripe products where this mandate can be selected automatically.
        [<Config.Form>]DefaultFor: Update'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list option
        ///Description of the mandate interval. Only required if 'payment_schedule' parameter is 'interval' or 'combined'.
        [<Config.Form>]IntervalDescription: string option
        ///Payment schedule for the mandate.
        [<Config.Form>]PaymentSchedule: Update'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule option
        ///Transaction type of the mandate.
        [<Config.Form>]TransactionType: Update'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType option
    }
    with
        static member New(?customMandateUrl: Choice<string,string>, ?defaultFor: Update'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list, ?intervalDescription: string, ?paymentSchedule: Update'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule, ?transactionType: Update'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType) =
            {
                CustomMandateUrl = customMandateUrl
                DefaultFor = defaultFor
                IntervalDescription = intervalDescription
                PaymentSchedule = paymentSchedule
                TransactionType = transactionType
            }

    type Update'PaymentMethodOptionsAcssDebitCurrency =
    | Cad
    | Usd

    type Update'PaymentMethodOptionsAcssDebitVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Update'PaymentMethodOptionsAcssDebit = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: Update'PaymentMethodOptionsAcssDebitCurrency option
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: Update'PaymentMethodOptionsAcssDebitMandateOptions option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Update'PaymentMethodOptionsAcssDebitVerificationMethod option
    }
    with
        static member New(?currency: Update'PaymentMethodOptionsAcssDebitCurrency, ?mandateOptions: Update'PaymentMethodOptionsAcssDebitMandateOptions, ?verificationMethod: Update'PaymentMethodOptionsAcssDebitVerificationMethod) =
            {
                Currency = currency
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Update'PaymentMethodOptionsCardMandateOptionsSupportedTypes =
    | India

    type Update'PaymentMethodOptionsCardMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Update'PaymentMethodOptionsCardMandateOptionsInterval =
    | Day
    | Month
    | Sporadic
    | Week
    | Year

    type Update'PaymentMethodOptionsCardMandateOptions = {
        ///Amount to be charged for future payments.
        [<Config.Form>]Amount: int option
        ///One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
        [<Config.Form>]AmountType: Update'PaymentMethodOptionsCardMandateOptionsAmountType option
        ///Currency in which future payments will be charged. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///A description of the mandate or subscription that is meant to be displayed to the customer.
        [<Config.Form>]Description: string option
        ///End date of the mandate or subscription. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.
        [<Config.Form>]EndDate: DateTime option
        ///Specifies payment frequency. One of `day`, `week`, `month`, `year`, or `sporadic`.
        [<Config.Form>]Interval: Update'PaymentMethodOptionsCardMandateOptionsInterval option
        ///The number of intervals between payments. For example, `interval=month` and `interval_count=3` indicates one payment every three months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks). This parameter is optional when `interval=sporadic`.
        [<Config.Form>]IntervalCount: int option
        ///Unique identifier for the mandate or subscription.
        [<Config.Form>]Reference: string option
        ///Start date of the mandate or subscription. Start date should not be lesser than yesterday.
        [<Config.Form>]StartDate: DateTime option
        ///Specifies the type of mandates supported. Possible values are `india`.
        [<Config.Form>]SupportedTypes: Update'PaymentMethodOptionsCardMandateOptionsSupportedTypes list option
    }
    with
        static member New(?amount: int, ?amountType: Update'PaymentMethodOptionsCardMandateOptionsAmountType, ?currency: string, ?description: string, ?endDate: DateTime, ?interval: Update'PaymentMethodOptionsCardMandateOptionsInterval, ?intervalCount: int, ?reference: string, ?startDate: DateTime, ?supportedTypes: Update'PaymentMethodOptionsCardMandateOptionsSupportedTypes list) =
            {
                Amount = amount
                AmountType = amountType
                Currency = currency
                Description = description
                EndDate = endDate
                Interval = interval
                IntervalCount = intervalCount
                Reference = reference
                StartDate = startDate
                SupportedTypes = supportedTypes
            }

    type Update'PaymentMethodOptionsCardNetwork =
    | Amex
    | CartesBancaires
    | Diners
    | Discover
    | EftposAu
    | Interac
    | Jcb
    | Mastercard
    | Unionpay
    | Unknown
    | Visa

    type Update'PaymentMethodOptionsCardRequestThreeDSecure =
    | Any
    | Automatic

    type Update'PaymentMethodOptionsCard = {
        ///Configuration options for setting up an eMandate for cards issued in India.
        [<Config.Form>]MandateOptions: Update'PaymentMethodOptionsCardMandateOptions option
        ///When specified, this parameter signals that a card has been collected
        ///as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
        ///parameter can only be provided during confirmation.
        [<Config.Form>]Moto: bool option
        ///Selected network to process this SetupIntent on. Depends on the available networks of the card attached to the SetupIntent. Can be only set confirm-time.
        [<Config.Form>]Network: Update'PaymentMethodOptionsCardNetwork option
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        [<Config.Form>]RequestThreeDSecure: Update'PaymentMethodOptionsCardRequestThreeDSecure option
    }
    with
        static member New(?mandateOptions: Update'PaymentMethodOptionsCardMandateOptions, ?moto: bool, ?network: Update'PaymentMethodOptionsCardNetwork, ?requestThreeDSecure: Update'PaymentMethodOptionsCardRequestThreeDSecure) =
            {
                MandateOptions = mandateOptions
                Moto = moto
                Network = network
                RequestThreeDSecure = requestThreeDSecure
            }

    type Update'PaymentMethodOptionsLink = {
        ///[Deprecated] This is a legacy parameter that no longer has any function.
        [<Config.Form>]PersistentToken: string option
    }
    with
        static member New(?persistentToken: string) =
            {
                PersistentToken = persistentToken
            }

    type Update'PaymentMethodOptionsPaypal = {
        ///The PayPal Billing Agreement ID (BAID). This is an ID generated by PayPal which represents the mandate between the merchant and the customer.
        [<Config.Form>]BillingAgreementId: string option
    }
    with
        static member New(?billingAgreementId: string) =
            {
                BillingAgreementId = billingAgreementId
            }

    type Update'PaymentMethodOptionsSepaDebit = {
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: string option
    }
    with
        static member New(?mandateOptions: string) =
            {
                MandateOptions = mandateOptions
            }

    type Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch =
    | Balances

    type Update'PaymentMethodOptionsUsBankAccountFinancialConnections = {
        ///The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
        [<Config.Form>]Permissions: Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list option
        ///List of data features that you would like to retrieve upon account creation.
        [<Config.Form>]Prefetch: Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list option
        ///For webview integrations only. Upon completing OAuth login in the native browser, the user will be redirected to this URL to return to your app.
        [<Config.Form>]ReturnUrl: string option
    }
    with
        static member New(?permissions: Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list, ?prefetch: Update'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list, ?returnUrl: string) =
            {
                Permissions = permissions
                Prefetch = prefetch
                ReturnUrl = returnUrl
            }

    type Update'PaymentMethodOptionsUsBankAccountNetworksRequested =
    | Ach
    | UsDomesticWire

    type Update'PaymentMethodOptionsUsBankAccountNetworks = {
        ///Triggers validations to run across the selected networks
        [<Config.Form>]Requested: Update'PaymentMethodOptionsUsBankAccountNetworksRequested list option
    }
    with
        static member New(?requested: Update'PaymentMethodOptionsUsBankAccountNetworksRequested list) =
            {
                Requested = requested
            }

    type Update'PaymentMethodOptionsUsBankAccountVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Update'PaymentMethodOptionsUsBankAccount = {
        ///Additional fields for Financial Connections Session creation
        [<Config.Form>]FinancialConnections: Update'PaymentMethodOptionsUsBankAccountFinancialConnections option
        ///Additional fields for network related functions
        [<Config.Form>]Networks: Update'PaymentMethodOptionsUsBankAccountNetworks option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Update'PaymentMethodOptionsUsBankAccountVerificationMethod option
    }
    with
        static member New(?financialConnections: Update'PaymentMethodOptionsUsBankAccountFinancialConnections, ?networks: Update'PaymentMethodOptionsUsBankAccountNetworks, ?verificationMethod: Update'PaymentMethodOptionsUsBankAccountVerificationMethod) =
            {
                FinancialConnections = financialConnections
                Networks = networks
                VerificationMethod = verificationMethod
            }

    type Update'PaymentMethodOptions = {
        ///If this is a `acss_debit` SetupIntent, this sub-hash contains details about the ACSS Debit payment method options.
        [<Config.Form>]AcssDebit: Update'PaymentMethodOptionsAcssDebit option
        ///Configuration for any card setup attempted on this SetupIntent.
        [<Config.Form>]Card: Update'PaymentMethodOptionsCard option
        ///If this is a `link` PaymentMethod, this sub-hash contains details about the Link payment method options.
        [<Config.Form>]Link: Update'PaymentMethodOptionsLink option
        ///If this is a `paypal` PaymentMethod, this sub-hash contains details about the PayPal payment method options.
        [<Config.Form>]Paypal: Update'PaymentMethodOptionsPaypal option
        ///If this is a `sepa_debit` SetupIntent, this sub-hash contains details about the SEPA Debit payment method options.
        [<Config.Form>]SepaDebit: Update'PaymentMethodOptionsSepaDebit option
        ///If this is a `us_bank_account` SetupIntent, this sub-hash contains details about the US bank account payment method options.
        [<Config.Form>]UsBankAccount: Update'PaymentMethodOptionsUsBankAccount option
    }
    with
        static member New(?acssDebit: Update'PaymentMethodOptionsAcssDebit, ?card: Update'PaymentMethodOptionsCard, ?link: Update'PaymentMethodOptionsLink, ?paypal: Update'PaymentMethodOptionsPaypal, ?sepaDebit: Update'PaymentMethodOptionsSepaDebit, ?usBankAccount: Update'PaymentMethodOptionsUsBankAccount) =
            {
                AcssDebit = acssDebit
                Card = card
                Link = link
                Paypal = paypal
                SepaDebit = sepaDebit
                UsBankAccount = usBankAccount
            }

    type UpdateOptions = {
        [<Config.Path>]Intent: string
        ///If present, the SetupIntent's payment method will be attached to the in-context Stripe Account.
        ///It can only be used for this Stripe Account’s own money movement flows like InboundTransfer and OutboundTransfers. It cannot be set to true when setting up a PaymentMethod for a Customer, and defaults to false when attaching a PaymentMethod to a Customer.
        [<Config.Form>]AttachToSelf: bool option
        ///ID of the Customer this SetupIntent belongs to, if one exists.
        ///If present, the SetupIntent's payment method will be attached to the Customer on successful setup. Payment methods attached to other Customers cannot be used with this SetupIntent.
        [<Config.Form>]Customer: string option
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Indicates the directions of money movement for which this payment method is intended to be used.
        ///Include `inbound` if you intend to use the payment method as the origin to pull funds from. Include `outbound` if you intend to use the payment method as the destination to send funds to. You can include both if you intend to use the payment method for both purposes.
        [<Config.Form>]FlowDirections: Update'FlowDirections list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///ID of the payment method (a PaymentMethod, Card, or saved Source object) to attach to this SetupIntent.
        [<Config.Form>]PaymentMethod: string option
        ///When included, this hash creates a PaymentMethod that is set as the [`payment_method`](https://stripe.com/docs/api/setup_intents/object#setup_intent_object-payment_method)
        ///value in the SetupIntent.
        [<Config.Form>]PaymentMethodData: Update'PaymentMethodData option
        ///Payment-method-specific configuration for this SetupIntent.
        [<Config.Form>]PaymentMethodOptions: Update'PaymentMethodOptions option
        ///The list of payment method types (e.g. card) that this SetupIntent is allowed to set up. If this is not provided, defaults to ["card"].
        [<Config.Form>]PaymentMethodTypes: string list option
    }
    with
        static member New(intent: string, ?attachToSelf: bool, ?customer: string, ?description: string, ?expand: string list, ?flowDirections: Update'FlowDirections list, ?metadata: Map<string, string>, ?paymentMethod: string, ?paymentMethodData: Update'PaymentMethodData, ?paymentMethodOptions: Update'PaymentMethodOptions, ?paymentMethodTypes: string list) =
            {
                Intent = intent
                AttachToSelf = attachToSelf
                Customer = customer
                Description = description
                Expand = expand
                FlowDirections = flowDirections
                Metadata = metadata
                PaymentMethod = paymentMethod
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
            }

    ///<p>Updates a SetupIntent object.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/setup_intents/{options.Intent}"
        |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) options

module SetupIntentsCancel =

    type Cancel'CancellationReason =
    | Abandoned
    | Duplicate
    | RequestedByCustomer

    type CancelOptions = {
        [<Config.Path>]Intent: string
        ///Reason for canceling this SetupIntent. Possible values are `abandoned`, `requested_by_customer`, or `duplicate`
        [<Config.Form>]CancellationReason: Cancel'CancellationReason option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(intent: string, ?cancellationReason: Cancel'CancellationReason, ?expand: string list) =
            {
                Intent = intent
                CancellationReason = cancellationReason
                Expand = expand
            }

    ///<p>A SetupIntent object can be canceled when it is in one of these statuses: <code>requires_payment_method</code>, <code>requires_confirmation</code>, or <code>requires_action</code>. 
    ///Once canceled, setup is abandoned and any operations on the SetupIntent will fail with an error.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/setup_intents/{options.Intent}/cancel"
        |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) options

module SetupIntentsConfirm =

    type Confirm'MandateDataSecretKeyCustomerAcceptanceOnline = {
        ///The IP address from which the Mandate was accepted by the customer.
        [<Config.Form>]IpAddress: string option
        ///The user agent of the browser from which the Mandate was accepted by the customer.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type Confirm'MandateDataSecretKeyCustomerAcceptanceType =
    | Offline
    | Online

    type Confirm'MandateDataSecretKeyCustomerAcceptance = {
        ///The time at which the customer accepted the Mandate.
        [<Config.Form>]AcceptedAt: DateTime option
        ///If this is a Mandate accepted offline, this hash contains details about the offline acceptance.
        [<Config.Form>]Offline: string option
        ///If this is a Mandate accepted online, this hash contains details about the online acceptance.
        [<Config.Form>]Online: Confirm'MandateDataSecretKeyCustomerAcceptanceOnline option
        ///The type of customer acceptance information included with the Mandate. One of `online` or `offline`.
        [<Config.Form>]Type: Confirm'MandateDataSecretKeyCustomerAcceptanceType option
    }
    with
        static member New(?acceptedAt: DateTime, ?offline: string, ?online: Confirm'MandateDataSecretKeyCustomerAcceptanceOnline, ?type': Confirm'MandateDataSecretKeyCustomerAcceptanceType) =
            {
                AcceptedAt = acceptedAt
                Offline = offline
                Online = online
                Type = type'
            }

    type Confirm'MandateDataSecretKey = {
        ///This hash contains details about the customer acceptance of the Mandate.
        [<Config.Form>]CustomerAcceptance: Confirm'MandateDataSecretKeyCustomerAcceptance option
    }
    with
        static member New(?customerAcceptance: Confirm'MandateDataSecretKeyCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type Confirm'MandateDataClientKeyCustomerAcceptanceOnline = {
        ///The IP address from which the Mandate was accepted by the customer.
        [<Config.Form>]IpAddress: string option
        ///The user agent of the browser from which the Mandate was accepted by the customer.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?ipAddress: string, ?userAgent: string) =
            {
                IpAddress = ipAddress
                UserAgent = userAgent
            }

    type Confirm'MandateDataClientKeyCustomerAcceptanceType =
    | Online

    type Confirm'MandateDataClientKeyCustomerAcceptance = {
        ///If this is a Mandate accepted online, this hash contains details about the online acceptance.
        [<Config.Form>]Online: Confirm'MandateDataClientKeyCustomerAcceptanceOnline option
        ///The type of customer acceptance information included with the Mandate.
        [<Config.Form>]Type: Confirm'MandateDataClientKeyCustomerAcceptanceType option
    }
    with
        static member New(?online: Confirm'MandateDataClientKeyCustomerAcceptanceOnline, ?type': Confirm'MandateDataClientKeyCustomerAcceptanceType) =
            {
                Online = online
                Type = type'
            }

    type Confirm'MandateDataClientKey = {
        ///This hash contains details about the customer acceptance of the Mandate.
        [<Config.Form>]CustomerAcceptance: Confirm'MandateDataClientKeyCustomerAcceptance option
    }
    with
        static member New(?customerAcceptance: Confirm'MandateDataClientKeyCustomerAcceptance) =
            {
                CustomerAcceptance = customerAcceptance
            }

    type Confirm'PaymentMethodDataAcssDebit = {
        ///Customer's bank account number.
        [<Config.Form>]AccountNumber: string option
        ///Institution number of the customer's bank.
        [<Config.Form>]InstitutionNumber: string option
        ///Transit number of the customer's bank.
        [<Config.Form>]TransitNumber: string option
    }
    with
        static member New(?accountNumber: string, ?institutionNumber: string, ?transitNumber: string) =
            {
                AccountNumber = accountNumber
                InstitutionNumber = institutionNumber
                TransitNumber = transitNumber
            }

    type Confirm'PaymentMethodDataAuBecsDebit = {
        ///The account number for the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Bank-State-Branch number of the bank account.
        [<Config.Form>]BsbNumber: string option
    }
    with
        static member New(?accountNumber: string, ?bsbNumber: string) =
            {
                AccountNumber = accountNumber
                BsbNumber = bsbNumber
            }

    type Confirm'PaymentMethodDataBacsDebit = {
        ///Account number of the bank account that the funds will be debited from.
        [<Config.Form>]AccountNumber: string option
        ///Sort code of the bank account. (e.g., `10-20-30`)
        [<Config.Form>]SortCode: string option
    }
    with
        static member New(?accountNumber: string, ?sortCode: string) =
            {
                AccountNumber = accountNumber
                SortCode = sortCode
            }

    type Confirm'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Confirm'PaymentMethodDataBillingDetails = {
        ///Billing address.
        [<Config.Form>]Address: Choice<Confirm'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string> option
        ///Email address.
        [<Config.Form>]Email: Choice<string,string> option
        ///Full name.
        [<Config.Form>]Name: Choice<string,string> option
        ///Billing phone number (including extension).
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Choice<Confirm'PaymentMethodDataBillingDetailsAddressBillingDetailsAddress,string>, ?email: Choice<string,string>, ?name: Choice<string,string>, ?phone: Choice<string,string>) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Confirm'PaymentMethodDataBoleto = {
        ///The tax ID of the customer (CPF for individual consumers or CNPJ for businesses consumers)
        [<Config.Form>]TaxId: string option
    }
    with
        static member New(?taxId: string) =
            {
                TaxId = taxId
            }

    type Confirm'PaymentMethodDataEpsBank =
    | ArzteUndApothekerBank
    | AustrianAnadiBankAg
    | BankAustria
    | BankhausCarlSpangler
    | BankhausSchelhammerUndSchatteraAg
    | BawagPskAg
    | BksBankAg
    | BrullKallmusBankAg
    | BtvVierLanderBank
    | CapitalBankGraweGruppeAg
    | DeutscheBankAg
    | Dolomitenbank
    | EasybankAg
    | ErsteBankUndSparkassen
    | HypoAlpeadriabankInternationalAg
    | HypoBankBurgenlandAktiengesellschaft
    | HypoNoeLbFurNiederosterreichUWien
    | HypoOberosterreichSalzburgSteiermark
    | HypoTirolBankAg
    | HypoVorarlbergBankAg
    | MarchfelderBank
    | OberbankAg
    | RaiffeisenBankengruppeOsterreich
    | SchoellerbankAg
    | SpardaBankWien
    | VolksbankGruppe
    | VolkskreditbankAg
    | VrBankBraunau

    type Confirm'PaymentMethodDataEps = {
        ///The customer's bank.
        [<Config.Form>]Bank: Confirm'PaymentMethodDataEpsBank option
    }
    with
        static member New(?bank: Confirm'PaymentMethodDataEpsBank) =
            {
                Bank = bank
            }

    type Confirm'PaymentMethodDataFpxAccountHolderType =
    | Company
    | Individual

    type Confirm'PaymentMethodDataFpxBank =
    | AffinBank
    | Agrobank
    | AllianceBank
    | Ambank
    | BankIslam
    | BankMuamalat
    | BankOfChina
    | BankRakyat
    | Bsn
    | Cimb
    | DeutscheBank
    | HongLeongBank
    | Hsbc
    | Kfh
    | Maybank2e
    | Maybank2u
    | Ocbc
    | PbEnterprise
    | PublicBank
    | Rhb
    | StandardChartered
    | Uob

    type Confirm'PaymentMethodDataFpx = {
        ///Account holder type for FPX transaction
        [<Config.Form>]AccountHolderType: Confirm'PaymentMethodDataFpxAccountHolderType option
        ///The customer's bank.
        [<Config.Form>]Bank: Confirm'PaymentMethodDataFpxBank option
    }
    with
        static member New(?accountHolderType: Confirm'PaymentMethodDataFpxAccountHolderType, ?bank: Confirm'PaymentMethodDataFpxBank) =
            {
                AccountHolderType = accountHolderType
                Bank = bank
            }

    type Confirm'PaymentMethodDataIdealBank =
    | AbnAmro
    | AsnBank
    | Bunq
    | Handelsbanken
    | Ing
    | Knab
    | Moneyou
    | Rabobank
    | Regiobank
    | Revolut
    | SnsBank
    | TriodosBank
    | VanLanschot
    | Yoursafe

    type Confirm'PaymentMethodDataIdeal = {
        ///The customer's bank.
        [<Config.Form>]Bank: Confirm'PaymentMethodDataIdealBank option
    }
    with
        static member New(?bank: Confirm'PaymentMethodDataIdealBank) =
            {
                Bank = bank
            }

    type Confirm'PaymentMethodDataKlarnaDob = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Confirm'PaymentMethodDataKlarna = {
        ///Customer's date of birth
        [<Config.Form>]Dob: Confirm'PaymentMethodDataKlarnaDob option
    }
    with
        static member New(?dob: Confirm'PaymentMethodDataKlarnaDob) =
            {
                Dob = dob
            }

    type Confirm'PaymentMethodDataP24Bank =
    | AliorBank
    | BankMillennium
    | BankNowyBfgSa
    | BankPekaoSa
    | BankiSpbdzielcze
    | Blik
    | BnpParibas
    | Boz
    | CitiHandlowy
    | CreditAgricole
    | Envelobank
    | EtransferPocztowy24
    | GetinBank
    | Ideabank
    | Ing
    | Inteligo
    | MbankMtransfer
    | NestPrzelew
    | NoblePay
    | PbacZIpko
    | PlusBank
    | SantanderPrzelew24
    | TmobileUsbugiBankowe
    | ToyotaBank
    | VolkswagenBank

    type Confirm'PaymentMethodDataP24 = {
        ///The customer's bank.
        [<Config.Form>]Bank: Confirm'PaymentMethodDataP24Bank option
    }
    with
        static member New(?bank: Confirm'PaymentMethodDataP24Bank) =
            {
                Bank = bank
            }

    type Confirm'PaymentMethodDataRadarOptions = {
        ///A [Radar Session](https://stripe.com/docs/radar/radar-session) is a snapshot of the browser metadata and device details that help Radar make more accurate predictions on your payments.
        [<Config.Form>]Session: string option
    }
    with
        static member New(?session: string) =
            {
                Session = session
            }

    type Confirm'PaymentMethodDataSepaDebit = {
        ///IBAN of the bank account.
        [<Config.Form>]Iban: string option
    }
    with
        static member New(?iban: string) =
            {
                Iban = iban
            }

    type Confirm'PaymentMethodDataSofortCountry =
    | [<JsonUnionCase("AT")>] AT
    | [<JsonUnionCase("BE")>] BE
    | [<JsonUnionCase("DE")>] DE
    | [<JsonUnionCase("ES")>] ES
    | [<JsonUnionCase("IT")>] IT
    | [<JsonUnionCase("NL")>] NL

    type Confirm'PaymentMethodDataSofort = {
        ///Two-letter ISO code representing the country the bank account is located in.
        [<Config.Form>]Country: Confirm'PaymentMethodDataSofortCountry option
    }
    with
        static member New(?country: Confirm'PaymentMethodDataSofortCountry) =
            {
                Country = country
            }

    type Confirm'PaymentMethodDataUsBankAccountAccountHolderType =
    | Company
    | Individual

    type Confirm'PaymentMethodDataUsBankAccountAccountType =
    | Checking
    | Savings

    type Confirm'PaymentMethodDataUsBankAccount = {
        ///Account holder type: individual or company.
        [<Config.Form>]AccountHolderType: Confirm'PaymentMethodDataUsBankAccountAccountHolderType option
        ///Account number of the bank account.
        [<Config.Form>]AccountNumber: string option
        ///Account type: checkings or savings. Defaults to checking if omitted.
        [<Config.Form>]AccountType: Confirm'PaymentMethodDataUsBankAccountAccountType option
        ///The ID of a Financial Connections Account to use as a payment method.
        [<Config.Form>]FinancialConnectionsAccount: string option
        ///Routing number of the bank account.
        [<Config.Form>]RoutingNumber: string option
    }
    with
        static member New(?accountHolderType: Confirm'PaymentMethodDataUsBankAccountAccountHolderType, ?accountNumber: string, ?accountType: Confirm'PaymentMethodDataUsBankAccountAccountType, ?financialConnectionsAccount: string, ?routingNumber: string) =
            {
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                FinancialConnectionsAccount = financialConnectionsAccount
                RoutingNumber = routingNumber
            }

    type Confirm'PaymentMethodDataType =
    | AcssDebit
    | Affirm
    | AfterpayClearpay
    | Alipay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Blik
    | Boleto
    | Cashapp
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | Klarna
    | Konbini
    | Link
    | Oxxo
    | P24
    | Paynow
    | Paypal
    | Pix
    | Promptpay
    | SepaDebit
    | Sofort
    | UsBankAccount
    | WechatPay
    | Zip

    type Confirm'PaymentMethodData = {
        ///If this is an `acss_debit` PaymentMethod, this hash contains details about the ACSS Debit payment method.
        [<Config.Form>]AcssDebit: Confirm'PaymentMethodDataAcssDebit option
        ///If this is an `affirm` PaymentMethod, this hash contains details about the Affirm payment method.
        [<Config.Form>]Affirm: string option
        ///If this is an `AfterpayClearpay` PaymentMethod, this hash contains details about the AfterpayClearpay payment method.
        [<Config.Form>]AfterpayClearpay: string option
        ///If this is an `Alipay` PaymentMethod, this hash contains details about the Alipay payment method.
        [<Config.Form>]Alipay: string option
        ///If this is an `au_becs_debit` PaymentMethod, this hash contains details about the bank account.
        [<Config.Form>]AuBecsDebit: Confirm'PaymentMethodDataAuBecsDebit option
        ///If this is a `bacs_debit` PaymentMethod, this hash contains details about the Bacs Direct Debit bank account.
        [<Config.Form>]BacsDebit: Confirm'PaymentMethodDataBacsDebit option
        ///If this is a `bancontact` PaymentMethod, this hash contains details about the Bancontact payment method.
        [<Config.Form>]Bancontact: string option
        ///Billing information associated with the PaymentMethod that may be used or required by particular types of payment methods.
        [<Config.Form>]BillingDetails: Confirm'PaymentMethodDataBillingDetails option
        ///If this is a `blik` PaymentMethod, this hash contains details about the BLIK payment method.
        [<Config.Form>]Blik: string option
        ///If this is a `boleto` PaymentMethod, this hash contains details about the Boleto payment method.
        [<Config.Form>]Boleto: Confirm'PaymentMethodDataBoleto option
        ///If this is a `cashapp` PaymentMethod, this hash contains details about the Cash App Pay payment method.
        [<Config.Form>]Cashapp: string option
        ///If this is a `customer_balance` PaymentMethod, this hash contains details about the CustomerBalance payment method.
        [<Config.Form>]CustomerBalance: string option
        ///If this is an `eps` PaymentMethod, this hash contains details about the EPS payment method.
        [<Config.Form>]Eps: Confirm'PaymentMethodDataEps option
        ///If this is an `fpx` PaymentMethod, this hash contains details about the FPX payment method.
        [<Config.Form>]Fpx: Confirm'PaymentMethodDataFpx option
        ///If this is a `giropay` PaymentMethod, this hash contains details about the Giropay payment method.
        [<Config.Form>]Giropay: string option
        ///If this is a `grabpay` PaymentMethod, this hash contains details about the GrabPay payment method.
        [<Config.Form>]Grabpay: string option
        ///If this is an `ideal` PaymentMethod, this hash contains details about the iDEAL payment method.
        [<Config.Form>]Ideal: Confirm'PaymentMethodDataIdeal option
        ///If this is an `interac_present` PaymentMethod, this hash contains details about the Interac Present payment method.
        [<Config.Form>]InteracPresent: string option
        ///If this is a `klarna` PaymentMethod, this hash contains details about the Klarna payment method.
        [<Config.Form>]Klarna: Confirm'PaymentMethodDataKlarna option
        ///If this is a `konbini` PaymentMethod, this hash contains details about the Konbini payment method.
        [<Config.Form>]Konbini: string option
        ///If this is an `Link` PaymentMethod, this hash contains details about the Link payment method.
        [<Config.Form>]Link: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///If this is an `oxxo` PaymentMethod, this hash contains details about the OXXO payment method.
        [<Config.Form>]Oxxo: string option
        ///If this is a `p24` PaymentMethod, this hash contains details about the P24 payment method.
        [<Config.Form>]P24: Confirm'PaymentMethodDataP24 option
        ///If this is a `paynow` PaymentMethod, this hash contains details about the PayNow payment method.
        [<Config.Form>]Paynow: string option
        ///If this is a `paypal` PaymentMethod, this hash contains details about the PayPal payment method.
        [<Config.Form>]Paypal: string option
        ///If this is a `pix` PaymentMethod, this hash contains details about the Pix payment method.
        [<Config.Form>]Pix: string option
        ///If this is a `promptpay` PaymentMethod, this hash contains details about the PromptPay payment method.
        [<Config.Form>]Promptpay: string option
        ///Options to configure Radar. See [Radar Session](https://stripe.com/docs/radar/radar-session) for more information.
        [<Config.Form>]RadarOptions: Confirm'PaymentMethodDataRadarOptions option
        ///If this is a `sepa_debit` PaymentMethod, this hash contains details about the SEPA debit bank account.
        [<Config.Form>]SepaDebit: Confirm'PaymentMethodDataSepaDebit option
        ///If this is a `sofort` PaymentMethod, this hash contains details about the SOFORT payment method.
        [<Config.Form>]Sofort: Confirm'PaymentMethodDataSofort option
        ///The type of the PaymentMethod. An additional hash is included on the PaymentMethod with a name matching this value. It contains additional information specific to the PaymentMethod type.
        [<Config.Form>]Type: Confirm'PaymentMethodDataType option
        ///If this is an `us_bank_account` PaymentMethod, this hash contains details about the US bank account payment method.
        [<Config.Form>]UsBankAccount: Confirm'PaymentMethodDataUsBankAccount option
        ///If this is an `wechat_pay` PaymentMethod, this hash contains details about the wechat_pay payment method.
        [<Config.Form>]WechatPay: string option
        ///If this is a `zip` PaymentMethod, this hash contains details about the Zip payment method.
        [<Config.Form>]Zip: string option
    }
    with
        static member New(?acssDebit: Confirm'PaymentMethodDataAcssDebit, ?konbini: string, ?link: string, ?metadata: Map<string, string>, ?oxxo: string, ?p24: Confirm'PaymentMethodDataP24, ?paynow: string, ?klarna: Confirm'PaymentMethodDataKlarna, ?paypal: string, ?promptpay: string, ?radarOptions: Confirm'PaymentMethodDataRadarOptions, ?sepaDebit: Confirm'PaymentMethodDataSepaDebit, ?sofort: Confirm'PaymentMethodDataSofort, ?type': Confirm'PaymentMethodDataType, ?usBankAccount: Confirm'PaymentMethodDataUsBankAccount, ?pix: string, ?wechatPay: string, ?interacPresent: string, ?grabpay: string, ?affirm: string, ?afterpayClearpay: string, ?alipay: string, ?auBecsDebit: Confirm'PaymentMethodDataAuBecsDebit, ?bacsDebit: Confirm'PaymentMethodDataBacsDebit, ?bancontact: string, ?ideal: Confirm'PaymentMethodDataIdeal, ?billingDetails: Confirm'PaymentMethodDataBillingDetails, ?boleto: Confirm'PaymentMethodDataBoleto, ?cashapp: string, ?customerBalance: string, ?eps: Confirm'PaymentMethodDataEps, ?fpx: Confirm'PaymentMethodDataFpx, ?giropay: string, ?blik: string, ?zip: string) =
            {
                AcssDebit = acssDebit
                Affirm = affirm
                AfterpayClearpay = afterpayClearpay
                Alipay = alipay
                AuBecsDebit = auBecsDebit
                BacsDebit = bacsDebit
                Bancontact = bancontact
                BillingDetails = billingDetails
                Blik = blik
                Boleto = boleto
                Cashapp = cashapp
                CustomerBalance = customerBalance
                Eps = eps
                Fpx = fpx
                Giropay = giropay
                Grabpay = grabpay
                Ideal = ideal
                InteracPresent = interacPresent
                Klarna = klarna
                Konbini = konbini
                Link = link
                Metadata = metadata
                Oxxo = oxxo
                P24 = p24
                Paynow = paynow
                Paypal = paypal
                Pix = pix
                Promptpay = promptpay
                RadarOptions = radarOptions
                SepaDebit = sepaDebit
                Sofort = sofort
                Type = type'
                UsBankAccount = usBankAccount
                WechatPay = wechatPay
                Zip = zip
            }

    type Confirm'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor =
    | Invoice
    | Subscription

    type Confirm'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule =
    | Combined
    | Interval
    | Sporadic

    type Confirm'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType =
    | Business
    | Personal

    type Confirm'PaymentMethodOptionsAcssDebitMandateOptions = {
        ///A URL for custom mandate text to render during confirmation step.
        ///The URL will be rendered with additional GET parameters `payment_intent` and `payment_intent_client_secret` when confirming a Payment Intent,
        ///or `setup_intent` and `setup_intent_client_secret` when confirming a Setup Intent.
        [<Config.Form>]CustomMandateUrl: Choice<string,string> option
        ///List of Stripe products where this mandate can be selected automatically.
        [<Config.Form>]DefaultFor: Confirm'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list option
        ///Description of the mandate interval. Only required if 'payment_schedule' parameter is 'interval' or 'combined'.
        [<Config.Form>]IntervalDescription: string option
        ///Payment schedule for the mandate.
        [<Config.Form>]PaymentSchedule: Confirm'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule option
        ///Transaction type of the mandate.
        [<Config.Form>]TransactionType: Confirm'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType option
    }
    with
        static member New(?customMandateUrl: Choice<string,string>, ?defaultFor: Confirm'PaymentMethodOptionsAcssDebitMandateOptionsDefaultFor list, ?intervalDescription: string, ?paymentSchedule: Confirm'PaymentMethodOptionsAcssDebitMandateOptionsPaymentSchedule, ?transactionType: Confirm'PaymentMethodOptionsAcssDebitMandateOptionsTransactionType) =
            {
                CustomMandateUrl = customMandateUrl
                DefaultFor = defaultFor
                IntervalDescription = intervalDescription
                PaymentSchedule = paymentSchedule
                TransactionType = transactionType
            }

    type Confirm'PaymentMethodOptionsAcssDebitCurrency =
    | Cad
    | Usd

    type Confirm'PaymentMethodOptionsAcssDebitVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Confirm'PaymentMethodOptionsAcssDebit = {
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: Confirm'PaymentMethodOptionsAcssDebitCurrency option
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: Confirm'PaymentMethodOptionsAcssDebitMandateOptions option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Confirm'PaymentMethodOptionsAcssDebitVerificationMethod option
    }
    with
        static member New(?currency: Confirm'PaymentMethodOptionsAcssDebitCurrency, ?mandateOptions: Confirm'PaymentMethodOptionsAcssDebitMandateOptions, ?verificationMethod: Confirm'PaymentMethodOptionsAcssDebitVerificationMethod) =
            {
                Currency = currency
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Confirm'PaymentMethodOptionsCardMandateOptionsSupportedTypes =
    | India

    type Confirm'PaymentMethodOptionsCardMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Confirm'PaymentMethodOptionsCardMandateOptionsInterval =
    | Day
    | Month
    | Sporadic
    | Week
    | Year

    type Confirm'PaymentMethodOptionsCardMandateOptions = {
        ///Amount to be charged for future payments.
        [<Config.Form>]Amount: int option
        ///One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.
        [<Config.Form>]AmountType: Confirm'PaymentMethodOptionsCardMandateOptionsAmountType option
        ///Currency in which future payments will be charged. Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string option
        ///A description of the mandate or subscription that is meant to be displayed to the customer.
        [<Config.Form>]Description: string option
        ///End date of the mandate or subscription. If not provided, the mandate will be active until canceled. If provided, end date should be after start date.
        [<Config.Form>]EndDate: DateTime option
        ///Specifies payment frequency. One of `day`, `week`, `month`, `year`, or `sporadic`.
        [<Config.Form>]Interval: Confirm'PaymentMethodOptionsCardMandateOptionsInterval option
        ///The number of intervals between payments. For example, `interval=month` and `interval_count=3` indicates one payment every three months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks). This parameter is optional when `interval=sporadic`.
        [<Config.Form>]IntervalCount: int option
        ///Unique identifier for the mandate or subscription.
        [<Config.Form>]Reference: string option
        ///Start date of the mandate or subscription. Start date should not be lesser than yesterday.
        [<Config.Form>]StartDate: DateTime option
        ///Specifies the type of mandates supported. Possible values are `india`.
        [<Config.Form>]SupportedTypes: Confirm'PaymentMethodOptionsCardMandateOptionsSupportedTypes list option
    }
    with
        static member New(?amount: int, ?amountType: Confirm'PaymentMethodOptionsCardMandateOptionsAmountType, ?currency: string, ?description: string, ?endDate: DateTime, ?interval: Confirm'PaymentMethodOptionsCardMandateOptionsInterval, ?intervalCount: int, ?reference: string, ?startDate: DateTime, ?supportedTypes: Confirm'PaymentMethodOptionsCardMandateOptionsSupportedTypes list) =
            {
                Amount = amount
                AmountType = amountType
                Currency = currency
                Description = description
                EndDate = endDate
                Interval = interval
                IntervalCount = intervalCount
                Reference = reference
                StartDate = startDate
                SupportedTypes = supportedTypes
            }

    type Confirm'PaymentMethodOptionsCardNetwork =
    | Amex
    | CartesBancaires
    | Diners
    | Discover
    | EftposAu
    | Interac
    | Jcb
    | Mastercard
    | Unionpay
    | Unknown
    | Visa

    type Confirm'PaymentMethodOptionsCardRequestThreeDSecure =
    | Any
    | Automatic

    type Confirm'PaymentMethodOptionsCard = {
        ///Configuration options for setting up an eMandate for cards issued in India.
        [<Config.Form>]MandateOptions: Confirm'PaymentMethodOptionsCardMandateOptions option
        ///When specified, this parameter signals that a card has been collected
        ///as MOTO (Mail Order Telephone Order) and thus out of scope for SCA. This
        ///parameter can only be provided during confirmation.
        [<Config.Form>]Moto: bool option
        ///Selected network to process this SetupIntent on. Depends on the available networks of the card attached to the SetupIntent. Can be only set confirm-time.
        [<Config.Form>]Network: Confirm'PaymentMethodOptionsCardNetwork option
        ///We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://stripe.com/docs/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Permitted values include: `automatic` or `any`. If not provided, defaults to `automatic`. Read our guide on [manually requesting 3D Secure](https://stripe.com/docs/payments/3d-secure#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.
        [<Config.Form>]RequestThreeDSecure: Confirm'PaymentMethodOptionsCardRequestThreeDSecure option
    }
    with
        static member New(?mandateOptions: Confirm'PaymentMethodOptionsCardMandateOptions, ?moto: bool, ?network: Confirm'PaymentMethodOptionsCardNetwork, ?requestThreeDSecure: Confirm'PaymentMethodOptionsCardRequestThreeDSecure) =
            {
                MandateOptions = mandateOptions
                Moto = moto
                Network = network
                RequestThreeDSecure = requestThreeDSecure
            }

    type Confirm'PaymentMethodOptionsLink = {
        ///[Deprecated] This is a legacy parameter that no longer has any function.
        [<Config.Form>]PersistentToken: string option
    }
    with
        static member New(?persistentToken: string) =
            {
                PersistentToken = persistentToken
            }

    type Confirm'PaymentMethodOptionsPaypal = {
        ///The PayPal Billing Agreement ID (BAID). This is an ID generated by PayPal which represents the mandate between the merchant and the customer.
        [<Config.Form>]BillingAgreementId: string option
    }
    with
        static member New(?billingAgreementId: string) =
            {
                BillingAgreementId = billingAgreementId
            }

    type Confirm'PaymentMethodOptionsSepaDebit = {
        ///Additional fields for Mandate creation
        [<Config.Form>]MandateOptions: string option
    }
    with
        static member New(?mandateOptions: string) =
            {
                MandateOptions = mandateOptions
            }

    type Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch =
    | Balances

    type Confirm'PaymentMethodOptionsUsBankAccountFinancialConnections = {
        ///The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.
        [<Config.Form>]Permissions: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list option
        ///List of data features that you would like to retrieve upon account creation.
        [<Config.Form>]Prefetch: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list option
        ///For webview integrations only. Upon completing OAuth login in the native browser, the user will be redirected to this URL to return to your app.
        [<Config.Form>]ReturnUrl: string option
    }
    with
        static member New(?permissions: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsPermissions list, ?prefetch: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnectionsPrefetch list, ?returnUrl: string) =
            {
                Permissions = permissions
                Prefetch = prefetch
                ReturnUrl = returnUrl
            }

    type Confirm'PaymentMethodOptionsUsBankAccountNetworksRequested =
    | Ach
    | UsDomesticWire

    type Confirm'PaymentMethodOptionsUsBankAccountNetworks = {
        ///Triggers validations to run across the selected networks
        [<Config.Form>]Requested: Confirm'PaymentMethodOptionsUsBankAccountNetworksRequested list option
    }
    with
        static member New(?requested: Confirm'PaymentMethodOptionsUsBankAccountNetworksRequested list) =
            {
                Requested = requested
            }

    type Confirm'PaymentMethodOptionsUsBankAccountVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Confirm'PaymentMethodOptionsUsBankAccount = {
        ///Additional fields for Financial Connections Session creation
        [<Config.Form>]FinancialConnections: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnections option
        ///Additional fields for network related functions
        [<Config.Form>]Networks: Confirm'PaymentMethodOptionsUsBankAccountNetworks option
        ///Verification method for the intent
        [<Config.Form>]VerificationMethod: Confirm'PaymentMethodOptionsUsBankAccountVerificationMethod option
    }
    with
        static member New(?financialConnections: Confirm'PaymentMethodOptionsUsBankAccountFinancialConnections, ?networks: Confirm'PaymentMethodOptionsUsBankAccountNetworks, ?verificationMethod: Confirm'PaymentMethodOptionsUsBankAccountVerificationMethod) =
            {
                FinancialConnections = financialConnections
                Networks = networks
                VerificationMethod = verificationMethod
            }

    type Confirm'PaymentMethodOptions = {
        ///If this is a `acss_debit` SetupIntent, this sub-hash contains details about the ACSS Debit payment method options.
        [<Config.Form>]AcssDebit: Confirm'PaymentMethodOptionsAcssDebit option
        ///Configuration for any card setup attempted on this SetupIntent.
        [<Config.Form>]Card: Confirm'PaymentMethodOptionsCard option
        ///If this is a `link` PaymentMethod, this sub-hash contains details about the Link payment method options.
        [<Config.Form>]Link: Confirm'PaymentMethodOptionsLink option
        ///If this is a `paypal` PaymentMethod, this sub-hash contains details about the PayPal payment method options.
        [<Config.Form>]Paypal: Confirm'PaymentMethodOptionsPaypal option
        ///If this is a `sepa_debit` SetupIntent, this sub-hash contains details about the SEPA Debit payment method options.
        [<Config.Form>]SepaDebit: Confirm'PaymentMethodOptionsSepaDebit option
        ///If this is a `us_bank_account` SetupIntent, this sub-hash contains details about the US bank account payment method options.
        [<Config.Form>]UsBankAccount: Confirm'PaymentMethodOptionsUsBankAccount option
    }
    with
        static member New(?acssDebit: Confirm'PaymentMethodOptionsAcssDebit, ?card: Confirm'PaymentMethodOptionsCard, ?link: Confirm'PaymentMethodOptionsLink, ?paypal: Confirm'PaymentMethodOptionsPaypal, ?sepaDebit: Confirm'PaymentMethodOptionsSepaDebit, ?usBankAccount: Confirm'PaymentMethodOptionsUsBankAccount) =
            {
                AcssDebit = acssDebit
                Card = card
                Link = link
                Paypal = paypal
                SepaDebit = sepaDebit
                UsBankAccount = usBankAccount
            }

    type ConfirmOptions = {
        [<Config.Path>]Intent: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///This hash contains details about the Mandate to create
        [<Config.Form>]MandateData: Choice<Confirm'MandateDataSecretKey,string,Confirm'MandateDataClientKey> option
        ///ID of the payment method (a PaymentMethod, Card, or saved Source object) to attach to this SetupIntent.
        [<Config.Form>]PaymentMethod: string option
        ///When included, this hash creates a PaymentMethod that is set as the [`payment_method`](https://stripe.com/docs/api/setup_intents/object#setup_intent_object-payment_method)
        ///value in the SetupIntent.
        [<Config.Form>]PaymentMethodData: Confirm'PaymentMethodData option
        ///Payment-method-specific configuration for this SetupIntent.
        [<Config.Form>]PaymentMethodOptions: Confirm'PaymentMethodOptions option
        ///The URL to redirect your customer back to after they authenticate on the payment method's app or site.
        ///If you'd prefer to redirect to a mobile application, you can alternatively supply an application URI scheme.
        ///This parameter is only used for cards and other redirect-based payment methods.
        [<Config.Form>]ReturnUrl: string option
        ///Set to `true` when confirming server-side and using Stripe.js, iOS, or Android client-side SDKs to handle the next actions.
        [<Config.Form>]UseStripeSdk: bool option
    }
    with
        static member New(intent: string, ?expand: string list, ?mandateData: Choice<Confirm'MandateDataSecretKey,string,Confirm'MandateDataClientKey>, ?paymentMethod: string, ?paymentMethodData: Confirm'PaymentMethodData, ?paymentMethodOptions: Confirm'PaymentMethodOptions, ?returnUrl: string, ?useStripeSdk: bool) =
            {
                Intent = intent
                Expand = expand
                MandateData = mandateData
                PaymentMethod = paymentMethod
                PaymentMethodData = paymentMethodData
                PaymentMethodOptions = paymentMethodOptions
                ReturnUrl = returnUrl
                UseStripeSdk = useStripeSdk
            }

    ///<p>Confirm that your customer intends to set up the current or
    ///provided payment method. For example, you would confirm a SetupIntent
    ///when a customer hits the “Save” button on a payment method management
    ///page on your website.
    ///If the selected payment method does not require any additional
    ///steps from the customer, the SetupIntent will transition to the
    ///<code>succeeded</code> status.
    ///Otherwise, it will transition to the <code>requires_action</code> status and
    ///suggest additional actions via <code>next_action</code>. If setup fails,
    ///the SetupIntent will transition to the
    ///<code>requires_payment_method</code> status or the <code>canceled</code> status if the
    ///confirmation limit is reached.</p>
    let Confirm settings (options: ConfirmOptions) =
        $"/v1/setup_intents/{options.Intent}/confirm"
        |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) options

module SetupIntentsVerifyMicrodeposits =

    type VerifyMicrodepositsOptions = {
        [<Config.Path>]Intent: string
        ///Two positive integers, in *cents*, equal to the values of the microdeposits sent to the bank account.
        [<Config.Form>]Amounts: int list option
        ///A six-character code starting with SM present in the microdeposit sent to the bank account.
        [<Config.Form>]DescriptorCode: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(intent: string, ?amounts: int list, ?descriptorCode: string, ?expand: string list) =
            {
                Intent = intent
                Amounts = amounts
                DescriptorCode = descriptorCode
                Expand = expand
            }

    ///<p>Verifies microdeposits on a SetupIntent object.</p>
    let VerifyMicrodeposits settings (options: VerifyMicrodepositsOptions) =
        $"/v1/setup_intents/{options.Intent}/verify_microdeposits"
        |> RestApi.postAsync<_, SetupIntent> settings (Map.empty) options

module Sources =

    type Create'MandateAcceptanceOffline = {
        ///An email to contact you with if a copy of the mandate is requested, required if `type` is `offline`.
        [<Config.Form>]ContactEmail: string option
    }
    with
        static member New(?contactEmail: string) =
            {
                ContactEmail = contactEmail
            }

    type Create'MandateAcceptanceOnline = {
        ///The Unix timestamp (in seconds) when the mandate was accepted or refused by the customer.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the mandate was accepted or refused by the customer.
        [<Config.Form>]Ip: string option
        ///The user agent of the browser from which the mandate was accepted or refused by the customer.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
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

    type Create'MandateAcceptance = {
        ///The Unix timestamp (in seconds) when the mandate was accepted or refused by the customer.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the mandate was accepted or refused by the customer.
        [<Config.Form>]Ip: string option
        ///The parameters required to store a mandate accepted offline. Should only be set if `mandate[type]` is `offline`
        [<Config.Form>]Offline: Create'MandateAcceptanceOffline option
        ///The parameters required to store a mandate accepted online. Should only be set if `mandate[type]` is `online`
        [<Config.Form>]Online: Create'MandateAcceptanceOnline option
        ///The status of the mandate acceptance. Either `accepted` (the mandate was accepted) or `refused` (the mandate was refused).
        [<Config.Form>]Status: Create'MandateAcceptanceStatus option
        ///The type of acceptance information included with the mandate. Either `online` or `offline`
        [<Config.Form>]Type: Create'MandateAcceptanceType option
        ///The user agent of the browser from which the mandate was accepted or refused by the customer.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?offline: Create'MandateAcceptanceOffline, ?online: Create'MandateAcceptanceOnline, ?status: Create'MandateAcceptanceStatus, ?type': Create'MandateAcceptanceType, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                Offline = offline
                Online = online
                Status = status
                Type = type'
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
    | None'
    | StripeEmail

    type Create'Mandate = {
        ///The parameters required to notify Stripe of a mandate acceptance or refusal by the customer.
        [<Config.Form>]Acceptance: Create'MandateAcceptance option
        ///The amount specified by the mandate. (Leave null for a mandate covering all amounts)
        [<Config.Form>]Amount: Choice<int,string> option
        ///The currency specified by the mandate. (Must match `currency` of the source)
        [<Config.Form>]Currency: string option
        ///The interval of debits permitted by the mandate. Either `one_time` (just permitting a single debit), `scheduled` (with debits on an agreed schedule or for clearly-defined events), or `variable`(for debits with any frequency)
        [<Config.Form>]Interval: Create'MandateInterval option
        ///The method Stripe should use to notify the customer of upcoming debit instructions and/or mandate confirmation as required by the underlying debit network. Either `email` (an email is sent directly to the customer), `manual` (a `source.mandate_notification` event is sent to your webhooks endpoint and you should handle the notification) or `none` (the underlying debit network does not require any notification).
        [<Config.Form>]NotificationMethod: Create'MandateNotificationMethod option
    }
    with
        static member New(?acceptance: Create'MandateAcceptance, ?amount: Choice<int,string>, ?currency: string, ?interval: Create'MandateInterval, ?notificationMethod: Create'MandateNotificationMethod) =
            {
                Acceptance = acceptance
                Amount = amount
                Currency = currency
                Interval = interval
                NotificationMethod = notificationMethod
            }

    type Create'OwnerAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'Owner = {
        ///Owner's address.
        [<Config.Form>]Address: Create'OwnerAddress option
        ///Owner's email address.
        [<Config.Form>]Email: string option
        ///Owner's full name.
        [<Config.Form>]Name: string option
        ///Owner's phone number.
        [<Config.Form>]Phone: string option
    }
    with
        static member New(?address: Create'OwnerAddress, ?email: string, ?name: string, ?phone: string) =
            {
                Address = address
                Email = email
                Name = name
                Phone = phone
            }

    type Create'ReceiverRefundAttributesMethod =
    | Email
    | Manual
    | None'

    type Create'Receiver = {
        ///The method Stripe should use to request information needed to process a refund or mispayment. Either `email` (an email is sent directly to the customer) or `manual` (a `source.refund_attributes_required` event is sent to your webhooks endpoint). Refer to each payment method's documentation to learn which refund attributes may be required.
        [<Config.Form>]RefundAttributesMethod: Create'ReceiverRefundAttributesMethod option
    }
    with
        static member New(?refundAttributesMethod: Create'ReceiverRefundAttributesMethod) =
            {
                RefundAttributesMethod = refundAttributesMethod
            }

    type Create'Redirect = {
        ///The URL you provide to redirect the customer back to you after they authenticated their payment. It can use your application URI scheme in the context of a mobile application.
        [<Config.Form>]ReturnUrl: string option
    }
    with
        static member New(?returnUrl: string) =
            {
                ReturnUrl = returnUrl
            }

    type Create'SourceOrderItemsType =
    | Discount
    | Shipping
    | Sku
    | Tax

    type Create'SourceOrderItems = {
        [<Config.Form>]Amount: int option
        [<Config.Form>]Currency: string option
        [<Config.Form>]Description: string option
        ///The ID of the SKU being ordered.
        [<Config.Form>]Parent: string option
        ///The quantity of this order item. When type is `sku`, this is the number of instances of the SKU to be ordered.
        [<Config.Form>]Quantity: int option
        [<Config.Form>]Type: Create'SourceOrderItemsType option
    }
    with
        static member New(?amount: int, ?currency: string, ?description: string, ?parent: string, ?quantity: int, ?type': Create'SourceOrderItemsType) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Parent = parent
                Quantity = quantity
                Type = type'
            }

    type Create'SourceOrderShippingAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'SourceOrderShipping = {
        ///Shipping address.
        [<Config.Form>]Address: Create'SourceOrderShippingAddress option
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        [<Config.Form>]Carrier: string option
        ///Recipient name.
        [<Config.Form>]Name: string option
        ///Recipient phone (including extension).
        [<Config.Form>]Phone: string option
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        [<Config.Form>]TrackingNumber: string option
    }
    with
        static member New(?address: Create'SourceOrderShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type Create'SourceOrder = {
        ///List of items constituting the order.
        [<Config.Form>]Items: Create'SourceOrderItems list option
        ///Shipping address for the order. Required if any of the SKUs are for products that have `shippable` set to true.
        [<Config.Form>]Shipping: Create'SourceOrderShipping option
    }
    with
        static member New(?items: Create'SourceOrderItems list, ?shipping: Create'SourceOrderShipping) =
            {
                Items = items
                Shipping = shipping
            }

    type Create'Flow =
    | CodeVerification
    | None'
    | Receiver
    | Redirect

    type Create'Usage =
    | Reusable
    | SingleUse

    type CreateOptions = {
        ///Amount associated with the source. This is the amount for which the source will be chargeable once ready. Required for `single_use` sources. Not supported for `receiver` type sources, where charge amount may not be specified until funds land.
        [<Config.Form>]Amount: int option
        ///Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) associated with the source. This is the currency for which the source will be chargeable once ready.
        [<Config.Form>]Currency: string option
        ///The `Customer` to whom the original source is attached to. Must be set when the original source is not a `Source` (e.g., `Card`).
        [<Config.Form>]Customer: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The authentication `flow` of the source to create. `flow` is one of `redirect`, `receiver`, `code_verification`, `none`. It is generally inferred unless a type supports multiple flows.
        [<Config.Form>]Flow: Create'Flow option
        ///Information about a mandate possibility attached to a source object (generally for bank debits) as well as its acceptance status.
        [<Config.Form>]Mandate: Create'Mandate option
        [<Config.Form>]Metadata: Map<string, string> option
        ///The source to share.
        [<Config.Form>]OriginalSource: string option
        ///Information about the owner of the payment instrument that may be used or required by particular source types.
        [<Config.Form>]Owner: Create'Owner option
        ///Optional parameters for the receiver flow. Can be set only if the source is a receiver (`flow` is `receiver`).
        [<Config.Form>]Receiver: Create'Receiver option
        ///Parameters required for the redirect flow. Required if the source is authenticated by a redirect (`flow` is `redirect`).
        [<Config.Form>]Redirect: Create'Redirect option
        ///Information about the items and shipping associated with the source. Required for transactional credit (for example Klarna) sources before you can charge it.
        [<Config.Form>]SourceOrder: Create'SourceOrder option
        ///An arbitrary string to be displayed on your customer's statement. As an example, if your website is `RunClub` and the item you're charging for is a race ticket, you may want to specify a `statement_descriptor` of `RunClub 5K race ticket.` While many payment types will display this information, some may not display it at all.
        [<Config.Form>]StatementDescriptor: string option
        ///An optional token used to create the source. When passed, token properties will override source parameters.
        [<Config.Form>]Token: string option
        ///The `type` of the source to create. Required unless `customer` and `original_source` are specified (see the [Cloning card Sources](https://stripe.com/docs/sources/connect#cloning-card-sources) guide)
        [<Config.Form>]Type: string option
        [<Config.Form>]Usage: Create'Usage option
    }
    with
        static member New(?amount: int, ?currency: string, ?customer: string, ?expand: string list, ?flow: Create'Flow, ?mandate: Create'Mandate, ?metadata: Map<string, string>, ?originalSource: string, ?owner: Create'Owner, ?receiver: Create'Receiver, ?redirect: Create'Redirect, ?sourceOrder: Create'SourceOrder, ?statementDescriptor: string, ?token: string, ?type': string, ?usage: Create'Usage) =
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
                Type = type'
                Usage = usage
            }

    ///<p>Creates a new source object.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/sources"
        |> RestApi.postAsync<_, Source> settings (Map.empty) options

    type RetrieveOptions = {
        ///The client secret of the source. Required if a publishable key is used to retrieve the source.
        [<Config.Query>]ClientSecret: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Source: string
    }
    with
        static member New(source: string, ?expand: string list, ?clientSecret: string) =
            {
                ClientSecret = clientSecret
                Expand = expand
                Source = source
            }

    ///<p>Retrieves an existing source object. Supply the unique source ID from a source creation request and Stripe will return the corresponding up-to-date source object information.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("client_secret", options.ClientSecret |> box); ("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/sources/{options.Source}"
        |> RestApi.getAsync<Source> settings qs

    type Update'MandateAcceptanceOffline = {
        ///An email to contact you with if a copy of the mandate is requested, required if `type` is `offline`.
        [<Config.Form>]ContactEmail: string option
    }
    with
        static member New(?contactEmail: string) =
            {
                ContactEmail = contactEmail
            }

    type Update'MandateAcceptanceOnline = {
        ///The Unix timestamp (in seconds) when the mandate was accepted or refused by the customer.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the mandate was accepted or refused by the customer.
        [<Config.Form>]Ip: string option
        ///The user agent of the browser from which the mandate was accepted or refused by the customer.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
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

    type Update'MandateAcceptance = {
        ///The Unix timestamp (in seconds) when the mandate was accepted or refused by the customer.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the mandate was accepted or refused by the customer.
        [<Config.Form>]Ip: string option
        ///The parameters required to store a mandate accepted offline. Should only be set if `mandate[type]` is `offline`
        [<Config.Form>]Offline: Update'MandateAcceptanceOffline option
        ///The parameters required to store a mandate accepted online. Should only be set if `mandate[type]` is `online`
        [<Config.Form>]Online: Update'MandateAcceptanceOnline option
        ///The status of the mandate acceptance. Either `accepted` (the mandate was accepted) or `refused` (the mandate was refused).
        [<Config.Form>]Status: Update'MandateAcceptanceStatus option
        ///The type of acceptance information included with the mandate. Either `online` or `offline`
        [<Config.Form>]Type: Update'MandateAcceptanceType option
        ///The user agent of the browser from which the mandate was accepted or refused by the customer.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?offline: Update'MandateAcceptanceOffline, ?online: Update'MandateAcceptanceOnline, ?status: Update'MandateAcceptanceStatus, ?type': Update'MandateAcceptanceType, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                Offline = offline
                Online = online
                Status = status
                Type = type'
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
    | None'
    | StripeEmail

    type Update'Mandate = {
        ///The parameters required to notify Stripe of a mandate acceptance or refusal by the customer.
        [<Config.Form>]Acceptance: Update'MandateAcceptance option
        ///The amount specified by the mandate. (Leave null for a mandate covering all amounts)
        [<Config.Form>]Amount: Choice<int,string> option
        ///The currency specified by the mandate. (Must match `currency` of the source)
        [<Config.Form>]Currency: string option
        ///The interval of debits permitted by the mandate. Either `one_time` (just permitting a single debit), `scheduled` (with debits on an agreed schedule or for clearly-defined events), or `variable`(for debits with any frequency)
        [<Config.Form>]Interval: Update'MandateInterval option
        ///The method Stripe should use to notify the customer of upcoming debit instructions and/or mandate confirmation as required by the underlying debit network. Either `email` (an email is sent directly to the customer), `manual` (a `source.mandate_notification` event is sent to your webhooks endpoint and you should handle the notification) or `none` (the underlying debit network does not require any notification).
        [<Config.Form>]NotificationMethod: Update'MandateNotificationMethod option
    }
    with
        static member New(?acceptance: Update'MandateAcceptance, ?amount: Choice<int,string>, ?currency: string, ?interval: Update'MandateInterval, ?notificationMethod: Update'MandateNotificationMethod) =
            {
                Acceptance = acceptance
                Amount = amount
                Currency = currency
                Interval = interval
                NotificationMethod = notificationMethod
            }

    type Update'OwnerAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'Owner = {
        ///Owner's address.
        [<Config.Form>]Address: Update'OwnerAddress option
        ///Owner's email address.
        [<Config.Form>]Email: string option
        ///Owner's full name.
        [<Config.Form>]Name: string option
        ///Owner's phone number.
        [<Config.Form>]Phone: string option
    }
    with
        static member New(?address: Update'OwnerAddress, ?email: string, ?name: string, ?phone: string) =
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

    type Update'SourceOrderItems = {
        [<Config.Form>]Amount: int option
        [<Config.Form>]Currency: string option
        [<Config.Form>]Description: string option
        ///The ID of the SKU being ordered.
        [<Config.Form>]Parent: string option
        ///The quantity of this order item. When type is `sku`, this is the number of instances of the SKU to be ordered.
        [<Config.Form>]Quantity: int option
        [<Config.Form>]Type: Update'SourceOrderItemsType option
    }
    with
        static member New(?amount: int, ?currency: string, ?description: string, ?parent: string, ?quantity: int, ?type': Update'SourceOrderItemsType) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Parent = parent
                Quantity = quantity
                Type = type'
            }

    type Update'SourceOrderShippingAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Update'SourceOrderShipping = {
        ///Shipping address.
        [<Config.Form>]Address: Update'SourceOrderShippingAddress option
        ///The delivery service that shipped a physical product, such as Fedex, UPS, USPS, etc.
        [<Config.Form>]Carrier: string option
        ///Recipient name.
        [<Config.Form>]Name: string option
        ///Recipient phone (including extension).
        [<Config.Form>]Phone: string option
        ///The tracking number for a physical product, obtained from the delivery service. If multiple tracking numbers were generated for this purchase, please separate them with commas.
        [<Config.Form>]TrackingNumber: string option
    }
    with
        static member New(?address: Update'SourceOrderShippingAddress, ?carrier: string, ?name: string, ?phone: string, ?trackingNumber: string) =
            {
                Address = address
                Carrier = carrier
                Name = name
                Phone = phone
                TrackingNumber = trackingNumber
            }

    type Update'SourceOrder = {
        ///List of items constituting the order.
        [<Config.Form>]Items: Update'SourceOrderItems list option
        ///Shipping address for the order. Required if any of the SKUs are for products that have `shippable` set to true.
        [<Config.Form>]Shipping: Update'SourceOrderShipping option
    }
    with
        static member New(?items: Update'SourceOrderItems list, ?shipping: Update'SourceOrderShipping) =
            {
                Items = items
                Shipping = shipping
            }

    type UpdateOptions = {
        [<Config.Path>]Source: string
        ///Amount associated with the source.
        [<Config.Form>]Amount: int option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Information about a mandate possibility attached to a source object (generally for bank debits) as well as its acceptance status.
        [<Config.Form>]Mandate: Update'Mandate option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Information about the owner of the payment instrument that may be used or required by particular source types.
        [<Config.Form>]Owner: Update'Owner option
        ///Information about the items and shipping associated with the source. Required for transactional credit (for example Klarna) sources before you can charge it.
        [<Config.Form>]SourceOrder: Update'SourceOrder option
    }
    with
        static member New(source: string, ?amount: int, ?expand: string list, ?mandate: Update'Mandate, ?metadata: Map<string, string>, ?owner: Update'Owner, ?sourceOrder: Update'SourceOrder) =
            {
                Source = source
                Amount = amount
                Expand = expand
                Mandate = mandate
                Metadata = metadata
                Owner = owner
                SourceOrder = sourceOrder
            }

    ///<p>Updates the specified source by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
    ///This request accepts the <code>metadata</code> and <code>owner</code> as arguments. It is also possible to update type specific information for selected payment methods. Please refer to our <a href="/docs/sources">payment method guides</a> for more detail.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/sources/{options.Source}"
        |> RestApi.postAsync<_, Source> settings (Map.empty) options

module SourcesSourceTransactions =

    type SourceTransactionsOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        [<Config.Path>]Source: string
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(source: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Source = source
                StartingAfter = startingAfter
            }

    ///<p>List source transactions for a given source.</p>
    let SourceTransactions settings (options: SourceTransactionsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/sources/{options.Source}/source_transactions"
        |> RestApi.getAsync<SourceTransaction list> settings qs

module SourcesVerify =

    type VerifyOptions = {
        [<Config.Path>]Source: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The values needed to verify the source.
        [<Config.Form>]Values: string list
    }
    with
        static member New(source: string, values: string list, ?expand: string list) =
            {
                Source = source
                Expand = expand
                Values = values
            }

    ///<p>Verify a given source.</p>
    let Verify settings (options: VerifyOptions) =
        $"/v1/sources/{options.Source}/verify"
        |> RestApi.postAsync<_, Source> settings (Map.empty) options

module Tokens =

    type Create'AccountCompanyAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'AccountCompanyAddressKana = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'AccountCompanyAddressKanji = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'AccountCompanyOwnershipDeclaration = {
        ///The Unix timestamp marking when the beneficial owner attestation was made.
        [<Config.Form>]Date: DateTime option
        ///The IP address from which the beneficial owner attestation was made.
        [<Config.Form>]Ip: string option
        ///The user agent of the browser from which the beneficial owner attestation was made.
        [<Config.Form>]UserAgent: string option
    }
    with
        static member New(?date: DateTime, ?ip: string, ?userAgent: string) =
            {
                Date = date
                Ip = ip
                UserAgent = userAgent
            }

    type Create'AccountCompanyVerificationDocument = {
        ///The back of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of a document returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `additional_verification`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'AccountCompanyVerification = {
        ///A document verifying the business.
        [<Config.Form>]Document: Create'AccountCompanyVerificationDocument option
    }
    with
        static member New(?document: Create'AccountCompanyVerificationDocument) =
            {
                Document = document
            }

    type Create'AccountCompanyStructure =
    | FreeZoneEstablishment
    | FreeZoneLlc
    | GovernmentInstrumentality
    | GovernmentalUnit
    | IncorporatedNonProfit
    | IncorporatedPartnership
    | LimitedLiabilityPartnership
    | Llc
    | MultiMemberLlc
    | PrivateCompany
    | PrivateCorporation
    | PrivatePartnership
    | PublicCompany
    | PublicCorporation
    | PublicPartnership
    | SingleMemberLlc
    | SoleEstablishment
    | SoleProprietorship
    | TaxExemptGovernmentInstrumentality
    | UnincorporatedAssociation
    | UnincorporatedNonProfit
    | UnincorporatedPartnership

    type Create'AccountCompany = {
        ///The company's primary address.
        [<Config.Form>]Address: Create'AccountCompanyAddress option
        ///The Kana variation of the company's primary address (Japan only).
        [<Config.Form>]AddressKana: Create'AccountCompanyAddressKana option
        ///The Kanji variation of the company's primary address (Japan only).
        [<Config.Form>]AddressKanji: Create'AccountCompanyAddressKanji option
        ///Whether the company's directors have been provided. Set this Boolean to `true` after creating all the company's directors with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.director` requirement. This value is not automatically set to `true` after creating directors, so it needs to be updated to indicate all directors have been provided.
        [<Config.Form>]DirectorsProvided: bool option
        ///Whether the company's executives have been provided. Set this Boolean to `true` after creating all the company's executives with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.executive` requirement.
        [<Config.Form>]ExecutivesProvided: bool option
        ///The export license ID number of the company, also referred as Import Export Code (India only).
        [<Config.Form>]ExportLicenseId: string option
        ///The purpose code to use for export transactions (India only).
        [<Config.Form>]ExportPurposeCode: string option
        ///The company's legal name.
        [<Config.Form>]Name: string option
        ///The Kana variation of the company's legal name (Japan only).
        [<Config.Form>]NameKana: string option
        ///The Kanji variation of the company's legal name (Japan only).
        [<Config.Form>]NameKanji: string option
        ///Whether the company's owners have been provided. Set this Boolean to `true` after creating all the company's owners with [the Persons API](https://stripe.com/docs/api/persons) for accounts with a `relationship.owner` requirement.
        [<Config.Form>]OwnersProvided: bool option
        ///This hash is used to attest that the beneficial owner information provided to Stripe is both current and correct.
        [<Config.Form>]OwnershipDeclaration: Create'AccountCompanyOwnershipDeclaration option
        ///Whether the user described by the data in the token has been shown the Ownership Declaration and indicated that it is correct.
        [<Config.Form>]OwnershipDeclarationShownAndSigned: bool option
        ///The company's phone number (used for verification).
        [<Config.Form>]Phone: string option
        ///The identification number given to a company when it is registered or incorporated, if distinct from the identification number used for filing taxes. (Examples are the CIN for companies and LLP IN for partnerships in India, and the Company Registration Number in Hong Kong).
        [<Config.Form>]RegistrationNumber: string option
        ///The category identifying the legal structure of the company or legal entity. See [Business structure](https://stripe.com/docs/connect/identity-verification#business-structure) for more details.
        [<Config.Form>]Structure: Create'AccountCompanyStructure option
        ///The business ID number of the company, as appropriate for the company’s country. (Examples are an Employer ID Number in the U.S., a Business Number in Canada, or a Company Number in the UK.)
        [<Config.Form>]TaxId: string option
        ///The jurisdiction in which the `tax_id` is registered (Germany-based companies only).
        [<Config.Form>]TaxIdRegistrar: string option
        ///The VAT number of the company.
        [<Config.Form>]VatId: string option
        ///Information on the verification state of the company.
        [<Config.Form>]Verification: Create'AccountCompanyVerification option
    }
    with
        static member New(?address: Create'AccountCompanyAddress, ?taxIdRegistrar: string, ?taxId: string, ?structure: Create'AccountCompanyStructure, ?registrationNumber: string, ?phone: string, ?ownershipDeclarationShownAndSigned: bool, ?ownershipDeclaration: Create'AccountCompanyOwnershipDeclaration, ?ownersProvided: bool, ?nameKanji: string, ?nameKana: string, ?name: string, ?exportPurposeCode: string, ?exportLicenseId: string, ?executivesProvided: bool, ?directorsProvided: bool, ?addressKanji: Create'AccountCompanyAddressKanji, ?addressKana: Create'AccountCompanyAddressKana, ?vatId: string, ?verification: Create'AccountCompanyVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                DirectorsProvided = directorsProvided
                ExecutivesProvided = executivesProvided
                ExportLicenseId = exportLicenseId
                ExportPurposeCode = exportPurposeCode
                Name = name
                NameKana = nameKana
                NameKanji = nameKanji
                OwnersProvided = ownersProvided
                OwnershipDeclaration = ownershipDeclaration
                OwnershipDeclarationShownAndSigned = ownershipDeclarationShownAndSigned
                Phone = phone
                RegistrationNumber = registrationNumber
                Structure = structure
                TaxId = taxId
                TaxIdRegistrar = taxIdRegistrar
                VatId = vatId
                Verification = verification
            }

    type Create'AccountIndividualAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'AccountIndividualAddressKana = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'AccountIndividualAddressKanji = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'AccountIndividualDobDateOfBirthSpecs = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'AccountIndividualRegisteredAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'AccountIndividualVerificationAdditionalDocument = {
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'AccountIndividualVerificationDocument = {
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'AccountIndividualVerification = {
        ///A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        [<Config.Form>]AdditionalDocument: Create'AccountIndividualVerificationAdditionalDocument option
        ///An identifying document, either a passport or local ID card.
        [<Config.Form>]Document: Create'AccountIndividualVerificationDocument option
    }
    with
        static member New(?additionalDocument: Create'AccountIndividualVerificationAdditionalDocument, ?document: Create'AccountIndividualVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Create'AccountIndividualPoliticalExposure =
    | Existing
    | None'

    type Create'AccountIndividual = {
        ///The individual's primary address.
        [<Config.Form>]Address: Create'AccountIndividualAddress option
        ///The Kana variation of the the individual's primary address (Japan only).
        [<Config.Form>]AddressKana: Create'AccountIndividualAddressKana option
        ///The Kanji variation of the the individual's primary address (Japan only).
        [<Config.Form>]AddressKanji: Create'AccountIndividualAddressKanji option
        ///The individual's date of birth.
        [<Config.Form>]Dob: Choice<Create'AccountIndividualDobDateOfBirthSpecs,string> option
        ///The individual's email address.
        [<Config.Form>]Email: string option
        ///The individual's first name.
        [<Config.Form>]FirstName: string option
        ///The Kana variation of the the individual's first name (Japan only).
        [<Config.Form>]FirstNameKana: string option
        ///The Kanji variation of the individual's first name (Japan only).
        [<Config.Form>]FirstNameKanji: string option
        ///A list of alternate names or aliases that the individual is known by.
        [<Config.Form>]FullNameAliases: Choice<string list,string> option
        ///The individual's gender (International regulations require either "male" or "female").
        [<Config.Form>]Gender: string option
        ///The government-issued ID number of the individual, as appropriate for the representative's country. (Examples are a Social Security Number in the U.S., or a Social Insurance Number in Canada). Instead of the number itself, you can also provide a [PII token created with Stripe.js](https://stripe.com/docs/js/tokens_sources/create_token?type=pii).
        [<Config.Form>]IdNumber: string option
        ///The government-issued secondary ID number of the individual, as appropriate for the representative's country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token created with Stripe.js](https://stripe.com/docs/js/tokens_sources/create_token?type=pii).
        [<Config.Form>]IdNumberSecondary: string option
        ///The individual's last name.
        [<Config.Form>]LastName: string option
        ///The Kana variation of the individual's last name (Japan only).
        [<Config.Form>]LastNameKana: string option
        ///The Kanji variation of the individual's last name (Japan only).
        [<Config.Form>]LastNameKanji: string option
        ///The individual's maiden name.
        [<Config.Form>]MaidenName: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The individual's phone number.
        [<Config.Form>]Phone: string option
        ///Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
        [<Config.Form>]PoliticalExposure: Create'AccountIndividualPoliticalExposure option
        ///The individual's registered address.
        [<Config.Form>]RegisteredAddress: Create'AccountIndividualRegisteredAddress option
        ///The last four digits of the individual's Social Security Number (U.S. only).
        [<Config.Form>]SsnLast4: string option
        ///The individual's verification document information.
        [<Config.Form>]Verification: Create'AccountIndividualVerification option
    }
    with
        static member New(?address: Create'AccountIndividualAddress, ?registeredAddress: Create'AccountIndividualRegisteredAddress, ?politicalExposure: Create'AccountIndividualPoliticalExposure, ?phone: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?idNumberSecondary: string, ?idNumber: string, ?gender: string, ?fullNameAliases: Choice<string list,string>, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?dob: Choice<Create'AccountIndividualDobDateOfBirthSpecs,string>, ?addressKanji: Create'AccountIndividualAddressKanji, ?addressKana: Create'AccountIndividualAddressKana, ?ssnLast4: string, ?verification: Create'AccountIndividualVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Email = email
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                FullNameAliases = fullNameAliases
                Gender = gender
                IdNumber = idNumber
                IdNumberSecondary = idNumberSecondary
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                Phone = phone
                PoliticalExposure = politicalExposure
                RegisteredAddress = registeredAddress
                SsnLast4 = ssnLast4
                Verification = verification
            }

    type Create'AccountBusinessType =
    | Company
    | GovernmentEntity
    | Individual
    | NonProfit

    type Create'Account = {
        ///The business type.
        [<Config.Form>]BusinessType: Create'AccountBusinessType option
        ///Information about the company or business.
        [<Config.Form>]Company: Create'AccountCompany option
        ///Information about the person represented by the account.
        [<Config.Form>]Individual: Create'AccountIndividual option
        ///Whether the user described by the data in the token has been shown [the Stripe Connected Account Agreement](https://stripe.com/docs/connect/account-tokens#stripe-connected-account-agreement). When creating an account token to create a new Connect account, this value must be `true`.
        [<Config.Form>]TosShownAndAccepted: bool option
    }
    with
        static member New(?businessType: Create'AccountBusinessType, ?company: Create'AccountCompany, ?individual: Create'AccountIndividual, ?tosShownAndAccepted: bool) =
            {
                BusinessType = businessType
                Company = company
                Individual = individual
                TosShownAndAccepted = tosShownAndAccepted
            }

    type Create'BankAccountAccountHolderType =
    | Company
    | Individual

    type Create'BankAccountAccountType =
    | Checking
    | Futsu
    | Savings
    | Toza

    type Create'BankAccount = {
        ///The name of the person or business that owns the bank account.This field is required when attaching the bank account to a `Customer` object.
        [<Config.Form>]AccountHolderName: string option
        ///The type of entity that holds the account. It can be `company` or `individual`. This field is required when attaching the bank account to a `Customer` object.
        [<Config.Form>]AccountHolderType: Create'BankAccountAccountHolderType option
        ///The account number for the bank account, in string form. Must be a checking account.
        [<Config.Form>]AccountNumber: string option
        ///The bank account type. This can only be `checking` or `savings` in most countries. In Japan, this can only be `futsu` or `toza`.
        [<Config.Form>]AccountType: Create'BankAccountAccountType option
        ///The country in which the bank account is located.
        [<Config.Form>]Country: string option
        ///The currency the bank account is in. This must be a country/currency pairing that [Stripe supports.](https://stripe.com/docs/payouts)
        [<Config.Form>]Currency: string option
        ///The routing number, sort code, or other country-appropriateinstitution number for the bank account. For US bank accounts, this is required and should bethe ACH routing number, not the wire routing number. If you are providing an IBAN for`account_number`, this field is not required.
        [<Config.Form>]RoutingNumber: string option
    }
    with
        static member New(?accountHolderName: string, ?accountHolderType: Create'BankAccountAccountHolderType, ?accountNumber: string, ?accountType: Create'BankAccountAccountType, ?country: string, ?currency: string, ?routingNumber: string) =
            {
                AccountHolderName = accountHolderName
                AccountHolderType = accountHolderType
                AccountNumber = accountNumber
                AccountType = accountType
                Country = country
                Currency = currency
                RoutingNumber = routingNumber
            }

    type Create'CardCreditCardSpecs = {
        [<Config.Form>]AddressCity: string option
        [<Config.Form>]AddressCountry: string option
        [<Config.Form>]AddressLine1: string option
        [<Config.Form>]AddressLine2: string option
        [<Config.Form>]AddressState: string option
        [<Config.Form>]AddressZip: string option
        [<Config.Form>]Currency: string option
        [<Config.Form>]Cvc: string option
        [<Config.Form>]ExpMonth: string option
        [<Config.Form>]ExpYear: string option
        [<Config.Form>]Name: string option
        [<Config.Form>]Number: string option
    }
    with
        static member New(?addressCity: string, ?addressCountry: string, ?addressLine1: string, ?addressLine2: string, ?addressState: string, ?addressZip: string, ?currency: string, ?cvc: string, ?expMonth: string, ?expYear: string, ?name: string, ?number: string) =
            {
                AddressCity = addressCity
                AddressCountry = addressCountry
                AddressLine1 = addressLine1
                AddressLine2 = addressLine2
                AddressState = addressState
                AddressZip = addressZip
                Currency = currency
                Cvc = cvc
                ExpMonth = expMonth
                ExpYear = expYear
                Name = name
                Number = number
            }

    type Create'CvcUpdate = {
        ///The CVC value, in string form.
        [<Config.Form>]Cvc: string option
    }
    with
        static member New(?cvc: string) =
            {
                Cvc = cvc
            }

    type Create'PersonAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PersonAddressKana = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'PersonAddressKanji = {
        ///City or ward.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Block or building number.
        [<Config.Form>]Line1: string option
        ///Building details.
        [<Config.Form>]Line2: string option
        ///Postal code.
        [<Config.Form>]PostalCode: string option
        ///Prefecture.
        [<Config.Form>]State: string option
        ///Town or cho-me.
        [<Config.Form>]Town: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string, ?town: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
                Town = town
            }

    type Create'PersonDobDateOfBirthSpecs = {
        ///The day of birth, between 1 and 31.
        [<Config.Form>]Day: int option
        ///The month of birth, between 1 and 12.
        [<Config.Form>]Month: int option
        ///The four-digit year of birth.
        [<Config.Form>]Year: int option
    }
    with
        static member New(?day: int, ?month: int, ?year: int) =
            {
                Day = day
                Month = month
                Year = year
            }

    type Create'PersonDocumentsCompanyAuthorization = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Create'PersonDocumentsPassport = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Create'PersonDocumentsVisa = {
        ///One or more document ids returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `account_requirement`.
        [<Config.Form>]Files: Choice<string,string> list option
    }
    with
        static member New(?files: Choice<string,string> list) =
            {
                Files = files
            }

    type Create'PersonDocuments = {
        ///One or more documents that demonstrate proof that this person is authorized to represent the company.
        [<Config.Form>]CompanyAuthorization: Create'PersonDocumentsCompanyAuthorization option
        ///One or more documents showing the person's passport page with photo and personal data.
        [<Config.Form>]Passport: Create'PersonDocumentsPassport option
        ///One or more documents showing the person's visa required for living in the country where they are residing.
        [<Config.Form>]Visa: Create'PersonDocumentsVisa option
    }
    with
        static member New(?companyAuthorization: Create'PersonDocumentsCompanyAuthorization, ?passport: Create'PersonDocumentsPassport, ?visa: Create'PersonDocumentsVisa) =
            {
                CompanyAuthorization = companyAuthorization
                Passport = passport
                Visa = visa
            }

    type Create'PersonRegisteredAddress = {
        ///City, district, suburb, town, or village.
        [<Config.Form>]City: string option
        ///Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).
        [<Config.Form>]Country: string option
        ///Address line 1 (e.g., street, PO Box, or company name).
        [<Config.Form>]Line1: string option
        ///Address line 2 (e.g., apartment, suite, unit, or building).
        [<Config.Form>]Line2: string option
        ///ZIP or postal code.
        [<Config.Form>]PostalCode: string option
        ///State, county, province, or region.
        [<Config.Form>]State: string option
    }
    with
        static member New(?city: string, ?country: string, ?line1: string, ?line2: string, ?postalCode: string, ?state: string) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'PersonRelationship = {
        ///Whether the person is a director of the account's legal entity. Directors are typically members of the governing board of the company, or responsible for ensuring the company meets its regulatory obligations.
        [<Config.Form>]Director: bool option
        ///Whether the person has significant responsibility to control, manage, or direct the organization.
        [<Config.Form>]Executive: bool option
        ///Whether the person is an owner of the account’s legal entity.
        [<Config.Form>]Owner: bool option
        ///The percent owned by the person of the account's legal entity.
        [<Config.Form>]PercentOwnership: Choice<decimal,string> option
        ///Whether the person is authorized as the primary representative of the account. This is the person nominated by the business to provide information about themselves, and general information about the account. There can only be one representative at any given time. At the time the account is created, this person should be set to the person responsible for opening the account.
        [<Config.Form>]Representative: bool option
        ///The person's title (e.g., CEO, Support Engineer).
        [<Config.Form>]Title: string option
    }
    with
        static member New(?director: bool, ?executive: bool, ?owner: bool, ?percentOwnership: Choice<decimal,string>, ?representative: bool, ?title: string) =
            {
                Director = director
                Executive = executive
                Owner = owner
                PercentOwnership = percentOwnership
                Representative = representative
                Title = title
            }

    type Create'PersonVerificationAdditionalDocument = {
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'PersonVerificationDocument = {
        ///The back of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Back: string option
        ///The front of an ID returned by a [file upload](https://stripe.com/docs/api#create_file) with a `purpose` value of `identity_document`. The uploaded file needs to be a color image (smaller than 8,000px by 8,000px), in JPG, PNG, or PDF format, and less than 10 MB in size.
        [<Config.Form>]Front: string option
    }
    with
        static member New(?back: string, ?front: string) =
            {
                Back = back
                Front = front
            }

    type Create'PersonVerification = {
        ///A document showing address, either a passport, local ID card, or utility bill from a well-known utility company.
        [<Config.Form>]AdditionalDocument: Create'PersonVerificationAdditionalDocument option
        ///An identifying document, either a passport or local ID card.
        [<Config.Form>]Document: Create'PersonVerificationDocument option
    }
    with
        static member New(?additionalDocument: Create'PersonVerificationAdditionalDocument, ?document: Create'PersonVerificationDocument) =
            {
                AdditionalDocument = additionalDocument
                Document = document
            }

    type Create'Person = {
        ///The person's address.
        [<Config.Form>]Address: Create'PersonAddress option
        ///The Kana variation of the person's address (Japan only).
        [<Config.Form>]AddressKana: Create'PersonAddressKana option
        ///The Kanji variation of the person's address (Japan only).
        [<Config.Form>]AddressKanji: Create'PersonAddressKanji option
        ///The person's date of birth.
        [<Config.Form>]Dob: Choice<Create'PersonDobDateOfBirthSpecs,string> option
        ///Documents that may be submitted to satisfy various informational requests.
        [<Config.Form>]Documents: Create'PersonDocuments option
        ///The person's email address.
        [<Config.Form>]Email: string option
        ///The person's first name.
        [<Config.Form>]FirstName: string option
        ///The Kana variation of the person's first name (Japan only).
        [<Config.Form>]FirstNameKana: string option
        ///The Kanji variation of the person's first name (Japan only).
        [<Config.Form>]FirstNameKanji: string option
        ///A list of alternate names or aliases that the person is known by.
        [<Config.Form>]FullNameAliases: Choice<string list,string> option
        ///The person's gender (International regulations require either "male" or "female").
        [<Config.Form>]Gender: string option
        ///The person's ID number, as appropriate for their country. For example, a social security number in the U.S., social insurance number in Canada, etc. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://stripe.com/docs/js/tokens_sources/create_token?type=pii).
        [<Config.Form>]IdNumber: string option
        ///The person's secondary ID number, as appropriate for their country, will be used for enhanced verification checks. In Thailand, this would be the laser code found on the back of an ID card. Instead of the number itself, you can also provide a [PII token provided by Stripe.js](https://stripe.com/docs/js/tokens_sources/create_token?type=pii).
        [<Config.Form>]IdNumberSecondary: string option
        ///The person's last name.
        [<Config.Form>]LastName: string option
        ///The Kana variation of the person's last name (Japan only).
        [<Config.Form>]LastNameKana: string option
        ///The Kanji variation of the person's last name (Japan only).
        [<Config.Form>]LastNameKanji: string option
        ///The person's maiden name.
        [<Config.Form>]MaidenName: string option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The country where the person is a national. Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)), or "XX" if unavailable.
        [<Config.Form>]Nationality: string option
        ///The person's phone number.
        [<Config.Form>]Phone: string option
        ///Indicates if the person or any of their representatives, family members, or other closely related persons, declares that they hold or have held an important public job or function, in any jurisdiction.
        [<Config.Form>]PoliticalExposure: string option
        ///The person's registered address.
        [<Config.Form>]RegisteredAddress: Create'PersonRegisteredAddress option
        ///The relationship that this person has with the account's legal entity.
        [<Config.Form>]Relationship: Create'PersonRelationship option
        ///The last four digits of the person's Social Security number (U.S. only).
        [<Config.Form>]SsnLast4: string option
        ///The person's verification status.
        [<Config.Form>]Verification: Create'PersonVerification option
    }
    with
        static member New(?address: Create'PersonAddress, ?relationship: Create'PersonRelationship, ?registeredAddress: Create'PersonRegisteredAddress, ?politicalExposure: string, ?phone: string, ?nationality: string, ?metadata: Map<string, string>, ?maidenName: string, ?lastNameKanji: string, ?lastNameKana: string, ?lastName: string, ?ssnLast4: string, ?idNumberSecondary: string, ?gender: string, ?fullNameAliases: Choice<string list,string>, ?firstNameKanji: string, ?firstNameKana: string, ?firstName: string, ?email: string, ?documents: Create'PersonDocuments, ?dob: Choice<Create'PersonDobDateOfBirthSpecs,string>, ?addressKanji: Create'PersonAddressKanji, ?addressKana: Create'PersonAddressKana, ?idNumber: string, ?verification: Create'PersonVerification) =
            {
                Address = address
                AddressKana = addressKana
                AddressKanji = addressKanji
                Dob = dob
                Documents = documents
                Email = email
                FirstName = firstName
                FirstNameKana = firstNameKana
                FirstNameKanji = firstNameKanji
                FullNameAliases = fullNameAliases
                Gender = gender
                IdNumber = idNumber
                IdNumberSecondary = idNumberSecondary
                LastName = lastName
                LastNameKana = lastNameKana
                LastNameKanji = lastNameKanji
                MaidenName = maidenName
                Metadata = metadata
                Nationality = nationality
                Phone = phone
                PoliticalExposure = politicalExposure
                RegisteredAddress = registeredAddress
                Relationship = relationship
                SsnLast4 = ssnLast4
                Verification = verification
            }

    type Create'Pii = {
        ///The `id_number` for the PII, in string form.
        [<Config.Form>]IdNumber: string option
    }
    with
        static member New(?idNumber: string) =
            {
                IdNumber = idNumber
            }

    type CreateOptions = {
        ///Information for the account this token will represent.
        [<Config.Form>]Account: Create'Account option
        ///The bank account this token will represent.
        [<Config.Form>]BankAccount: Create'BankAccount option
        [<Config.Form>]Card: Choice<Create'CardCreditCardSpecs,string> option
        ///The customer (owned by the application's account) for which to create a token. This can be used only with an [OAuth access token](https://stripe.com/docs/connect/standard-accounts) or [Stripe-Account header](https://stripe.com/docs/connect/authentication). For more details, see [Cloning Saved Payment Methods](https://stripe.com/docs/connect/cloning-saved-payment-methods).
        [<Config.Form>]Customer: string option
        ///The updated CVC value this token will represent.
        [<Config.Form>]CvcUpdate: Create'CvcUpdate option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Information for the person this token will represent.
        [<Config.Form>]Person: Create'Person option
        ///The PII this token will represent.
        [<Config.Form>]Pii: Create'Pii option
    }
    with
        static member New(?account: Create'Account, ?bankAccount: Create'BankAccount, ?card: Choice<Create'CardCreditCardSpecs,string>, ?customer: string, ?cvcUpdate: Create'CvcUpdate, ?expand: string list, ?person: Create'Person, ?pii: Create'Pii) =
            {
                Account = account
                BankAccount = bankAccount
                Card = card
                Customer = customer
                CvcUpdate = cvcUpdate
                Expand = expand
                Person = person
                Pii = pii
            }

    ///<p>Creates a single-use token that represents a bank account’s details.
    ///This token can be used with any API method in place of a bank account dictionary. This token can be used only once, by attaching it to a <a href="#accounts">Custom account</a>.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/tokens"
        |> RestApi.postAsync<_, Token> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Token: string
    }
    with
        static member New(token: string, ?expand: string list) =
            {
                Expand = expand
                Token = token
            }

    ///<p>Retrieves the token with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tokens/{options.Token}"
        |> RestApi.getAsync<Token> settings qs

module Topups =

    type ListOptions = {
        ///A positive integer representing how much to transfer.
        [<Config.Query>]Amount: int option
        ///A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
        [<Config.Query>]Created: int option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only return top-ups that have the given status. One of `canceled`, `failed`, `pending` or `succeeded`.
        [<Config.Query>]Status: string option
    }
    with
        static member New(?amount: int, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                Amount = amount
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    ///<p>Returns a list of top-ups.</p>
    let List settings (options: ListOptions) =
        let qs = [("amount", options.Amount |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/topups"
        |> RestApi.getAsync<Topup list> settings qs

    type CreateOptions = {
        ///A positive integer representing how much to transfer.
        [<Config.Form>]Amount: int
        ///Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        [<Config.Form>]Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The ID of a source to transfer funds from. For most users, this should be left unspecified which will use the bank account that was set up in the dashboard for the specified currency. In test mode, this can be a test bank token (see [Testing Top-ups](https://stripe.com/docs/connect/testing#testing-top-ups)).
        [<Config.Form>]Source: string option
        ///Extra information about a top-up for the source's bank statement. Limited to 15 ASCII characters.
        [<Config.Form>]StatementDescriptor: string option
        ///A string that identifies this top-up as part of a group.
        [<Config.Form>]TransferGroup: string option
    }
    with
        static member New(amount: int, currency: string, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?source: string, ?statementDescriptor: string, ?transferGroup: string) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Expand = expand
                Metadata = metadata
                Source = source
                StatementDescriptor = statementDescriptor
                TransferGroup = transferGroup
            }

    ///<p>Top up the balance of an account</p>
    let Create settings (options: CreateOptions) =
        $"/v1/topups"
        |> RestApi.postAsync<_, Topup> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Topup: string
    }
    with
        static member New(topup: string, ?expand: string list) =
            {
                Expand = expand
                Topup = topup
            }

    ///<p>Retrieves the details of a top-up that has previously been created. Supply the unique top-up ID that was returned from your previous request, and Stripe will return the corresponding top-up information.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/topups/{options.Topup}"
        |> RestApi.getAsync<Topup> settings qs

    type UpdateOptions = {
        [<Config.Path>]Topup: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(topup: string, ?description: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Topup = topup
                Description = description
                Expand = expand
                Metadata = metadata
            }

    ///<p>Updates the metadata of a top-up. Other top-up details are not editable by design.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/topups/{options.Topup}"
        |> RestApi.postAsync<_, Topup> settings (Map.empty) options

module TopupsCancel =

    type CancelOptions = {
        [<Config.Path>]Topup: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(topup: string, ?expand: string list) =
            {
                Topup = topup
                Expand = expand
            }

    ///<p>Cancels a top-up. Only pending top-ups can be canceled.</p>
    let Cancel settings (options: CancelOptions) =
        $"/v1/topups/{options.Topup}/cancel"
        |> RestApi.postAsync<_, Topup> settings (Map.empty) options

module Transfers =

    type ListOptions = {
        [<Config.Query>]Created: int option
        ///Only return transfers for the destination specified by this account ID.
        [<Config.Query>]Destination: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
        ///Only return transfers with the specified transfer group.
        [<Config.Query>]TransferGroup: string option
    }
    with
        static member New(?created: int, ?destination: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?transferGroup: string) =
            {
                Created = created
                Destination = destination
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                TransferGroup = transferGroup
            }

    ///<p>Returns a list of existing transfers sent to connected accounts. The transfers are returned in sorted order, with the most recently created transfers appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("destination", options.Destination |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("transfer_group", options.TransferGroup |> box)] |> Map.ofList
        $"/v1/transfers"
        |> RestApi.getAsync<Transfer list> settings qs

    type Create'SourceType =
    | BankAccount
    | Card
    | Fpx

    type CreateOptions = {
        ///A positive integer in cents (or local equivalent) representing how much to transfer.
        [<Config.Form>]Amount: int option
        ///3-letter [ISO code for currency](https://stripe.com/docs/payouts).
        [<Config.Form>]Currency: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///The ID of a connected Stripe account. <a href="/docs/connect/separate-charges-and-transfers">See the Connect documentation</a> for details.
        [<Config.Form>]Destination: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///You can use this parameter to transfer funds from a charge before they are added to your available balance. A pending balance will transfer immediately but the funds will not become available until the original charge becomes available. [See the Connect documentation](https://stripe.com/docs/connect/separate-charges-and-transfers#transfer-availability) for details.
        [<Config.Form>]SourceTransaction: string option
        ///The source balance to use for this transfer. One of `bank_account`, `card`, or `fpx`. For most users, this will default to `card`.
        [<Config.Form>]SourceType: Create'SourceType option
        ///A string that identifies this transaction as part of a group. See the [Connect documentation](https://stripe.com/docs/connect/separate-charges-and-transfers#transfer-options) for details.
        [<Config.Form>]TransferGroup: string option
    }
    with
        static member New(currency: string, destination: string, ?amount: int, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?sourceTransaction: string, ?sourceType: Create'SourceType, ?transferGroup: string) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Destination = destination
                Expand = expand
                Metadata = metadata
                SourceTransaction = sourceTransaction
                SourceType = sourceType
                TransferGroup = transferGroup
            }

    ///<p>To send funds from your Stripe account to a connected account, you create a new transfer object. Your <a href="#balance">Stripe balance</a> must be able to cover the transfer amount, or you’ll receive an “Insufficient Funds” error.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/transfers"
        |> RestApi.postAsync<_, Transfer> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Transfer: string
    }
    with
        static member New(transfer: string, ?expand: string list) =
            {
                Expand = expand
                Transfer = transfer
            }

    ///<p>Retrieves the details of an existing transfer. Supply the unique transfer ID from either a transfer creation request or the transfer list, and Stripe will return the corresponding transfer information.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/transfers/{options.Transfer}"
        |> RestApi.getAsync<Transfer> settings qs

    type UpdateOptions = {
        [<Config.Path>]Transfer: string
        ///An arbitrary string attached to the object. Often useful for displaying to users.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(transfer: string, ?description: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Transfer = transfer
                Description = description
                Expand = expand
                Metadata = metadata
            }

    ///<p>Updates the specified transfer by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
    ///This request accepts only metadata as an argument.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/transfers/{options.Transfer}"
        |> RestApi.postAsync<_, Transfer> settings (Map.empty) options

module TransfersReversals =

    type ListOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(id: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Id = id
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>You can see a list of the reversals belonging to a specific transfer. Note that the 10 most recent reversals are always available by default on the transfer object. If you need more than those 10, you can use this API method and the <code>limit</code> and <code>starting_after</code> parameters to page through additional reversals.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/transfers/{options.Id}/reversals"
        |> RestApi.getAsync<TransferReversal list> settings qs

    type CreateOptions = {
        [<Config.Path>]Id: string
        ///A positive integer in cents (or local equivalent) representing how much of this transfer to reverse. Can only reverse up to the unreversed amount remaining of the transfer. Partial transfer reversals are only allowed for transfers to Stripe Accounts. Defaults to the entire transfer amount.
        [<Config.Form>]Amount: int option
        ///An arbitrary string which you can attach to a reversal object. It is displayed alongside the reversal in the Dashboard. This will be unset if you POST an empty value.
        [<Config.Form>]Description: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///Boolean indicating whether the application fee should be refunded when reversing this transfer. If a full transfer reversal is given, the full application fee will be refunded. Otherwise, the application fee will be refunded with an amount proportional to the amount of the transfer reversed.
        [<Config.Form>]RefundApplicationFee: bool option
    }
    with
        static member New(id: string, ?amount: int, ?description: string, ?expand: string list, ?metadata: Map<string, string>, ?refundApplicationFee: bool) =
            {
                Id = id
                Amount = amount
                Description = description
                Expand = expand
                Metadata = metadata
                RefundApplicationFee = refundApplicationFee
            }

    ///<p>When you create a new reversal, you must specify a transfer to create it on.
    ///When reversing transfers, you can optionally reverse part of the transfer. You can do so as many times as you wish until the entire transfer has been reversed.
    ///Once entirely reversed, a transfer can’t be reversed again. This method will return an error when called on an already-reversed transfer, or when trying to reverse more money than is left on a transfer.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/transfers/{options.Id}/reversals"
        |> RestApi.postAsync<_, TransferReversal> settings (Map.empty) options

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
        [<Config.Path>]Transfer: string
    }
    with
        static member New(id: string, transfer: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
                Transfer = transfer
            }

    ///<p>By default, you can see the 10 most recent reversals stored directly on the transfer object, but you can also retrieve details about a specific reversal stored on the transfer.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/transfers/{options.Transfer}/reversals/{options.Id}"
        |> RestApi.getAsync<TransferReversal> settings qs

    type UpdateOptions = {
        [<Config.Path>]Id: string
        [<Config.Path>]Transfer: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(id: string, transfer: string, ?expand: string list, ?metadata: Map<string, string>) =
            {
                Id = id
                Transfer = transfer
                Expand = expand
                Metadata = metadata
            }

    ///<p>Updates the specified reversal by setting the values of the parameters passed. Any parameters not provided will be left unchanged.
    ///This request only accepts metadata and description as arguments.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/transfers/{options.Transfer}/reversals/{options.Id}"
        |> RestApi.postAsync<_, TransferReversal> settings (Map.empty) options

module WebhookEndpoints =

    type ListOptions = {
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of your webhook endpoints.</p>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/webhook_endpoints"
        |> RestApi.getAsync<WebhookEndpoint list> settings qs

    type Create'EnabledEvents =
    | Asterix
    | AccountApplicationAuthorized
    | AccountApplicationDeauthorized
    | AccountExternalAccountCreated
    | AccountExternalAccountDeleted
    | AccountExternalAccountUpdated
    | AccountUpdated
    | ApplicationFeeCreated
    | ApplicationFeeRefundUpdated
    | ApplicationFeeRefunded
    | BalanceAvailable
    | BillingPortalConfigurationCreated
    | BillingPortalConfigurationUpdated
    | BillingPortalSessionCreated
    | CapabilityUpdated
    | CashBalanceFundsAvailable
    | ChargeCaptured
    | ChargeDisputeClosed
    | ChargeDisputeCreated
    | ChargeDisputeFundsReinstated
    | ChargeDisputeFundsWithdrawn
    | ChargeDisputeUpdated
    | ChargeExpired
    | ChargeFailed
    | ChargePending
    | ChargeRefundUpdated
    | ChargeRefunded
    | ChargeSucceeded
    | ChargeUpdated
    | CheckoutSessionAsyncPaymentFailed
    | CheckoutSessionAsyncPaymentSucceeded
    | CheckoutSessionCompleted
    | CheckoutSessionExpired
    | CouponCreated
    | CouponDeleted
    | CouponUpdated
    | CreditNoteCreated
    | CreditNoteUpdated
    | CreditNoteVoided
    | CustomerCreated
    | CustomerDeleted
    | CustomerDiscountCreated
    | CustomerDiscountDeleted
    | CustomerDiscountUpdated
    | CustomerSourceCreated
    | CustomerSourceDeleted
    | CustomerSourceExpiring
    | CustomerSourceUpdated
    | CustomerSubscriptionCreated
    | CustomerSubscriptionDeleted
    | CustomerSubscriptionPaused
    | CustomerSubscriptionPendingUpdateApplied
    | CustomerSubscriptionPendingUpdateExpired
    | CustomerSubscriptionResumed
    | CustomerSubscriptionTrialWillEnd
    | CustomerSubscriptionUpdated
    | CustomerTaxIdCreated
    | CustomerTaxIdDeleted
    | CustomerTaxIdUpdated
    | CustomerUpdated
    | CustomerCashBalanceTransactionCreated
    | FileCreated
    | FinancialConnectionsAccountCreated
    | FinancialConnectionsAccountDeactivated
    | FinancialConnectionsAccountDisconnected
    | FinancialConnectionsAccountReactivated
    | FinancialConnectionsAccountRefreshedBalance
    | IdentityVerificationSessionCanceled
    | IdentityVerificationSessionCreated
    | IdentityVerificationSessionProcessing
    | IdentityVerificationSessionRedacted
    | IdentityVerificationSessionRequiresInput
    | IdentityVerificationSessionVerified
    | InvoiceCreated
    | InvoiceDeleted
    | InvoiceFinalizationFailed
    | InvoiceFinalized
    | InvoiceMarkedUncollectible
    | InvoicePaid
    | InvoicePaymentActionRequired
    | InvoicePaymentFailed
    | InvoicePaymentSucceeded
    | InvoiceSent
    | InvoiceUpcoming
    | InvoiceUpdated
    | InvoiceVoided
    | InvoiceitemCreated
    | InvoiceitemDeleted
    | InvoiceitemUpdated
    | IssuingAuthorizationCreated
    | IssuingAuthorizationRequest
    | IssuingAuthorizationUpdated
    | IssuingCardCreated
    | IssuingCardUpdated
    | IssuingCardholderCreated
    | IssuingCardholderUpdated
    | IssuingDisputeClosed
    | IssuingDisputeCreated
    | IssuingDisputeFundsReinstated
    | IssuingDisputeSubmitted
    | IssuingDisputeUpdated
    | IssuingTransactionCreated
    | IssuingTransactionUpdated
    | MandateUpdated
    | OrderCreated
    | PaymentIntentAmountCapturableUpdated
    | PaymentIntentCanceled
    | PaymentIntentCreated
    | PaymentIntentPartiallyFunded
    | PaymentIntentPaymentFailed
    | PaymentIntentProcessing
    | PaymentIntentRequiresAction
    | PaymentIntentSucceeded
    | PaymentLinkCreated
    | PaymentLinkUpdated
    | PaymentMethodAttached
    | PaymentMethodAutomaticallyUpdated
    | PaymentMethodDetached
    | PaymentMethodUpdated
    | PayoutCanceled
    | PayoutCreated
    | PayoutFailed
    | PayoutPaid
    | PayoutReconciliationCompleted
    | PayoutUpdated
    | PersonCreated
    | PersonDeleted
    | PersonUpdated
    | PlanCreated
    | PlanDeleted
    | PlanUpdated
    | PriceCreated
    | PriceDeleted
    | PriceUpdated
    | ProductCreated
    | ProductDeleted
    | ProductUpdated
    | PromotionCodeCreated
    | PromotionCodeUpdated
    | QuoteAccepted
    | QuoteCanceled
    | QuoteCreated
    | QuoteFinalized
    | RadarEarlyFraudWarningCreated
    | RadarEarlyFraudWarningUpdated
    | RecipientCreated
    | RecipientDeleted
    | RecipientUpdated
    | RefundCreated
    | RefundUpdated
    | ReportingReportRunFailed
    | ReportingReportRunSucceeded
    | ReportingReportTypeUpdated
    | ReviewClosed
    | ReviewOpened
    | SetupIntentCanceled
    | SetupIntentCreated
    | SetupIntentRequiresAction
    | SetupIntentSetupFailed
    | SetupIntentSucceeded
    | SigmaScheduledQueryRunCreated
    | SkuCreated
    | SkuDeleted
    | SkuUpdated
    | SourceCanceled
    | SourceChargeable
    | SourceFailed
    | SourceMandateNotification
    | SourceRefundAttributesRequired
    | SourceTransactionCreated
    | SourceTransactionUpdated
    | SubscriptionScheduleAborted
    | SubscriptionScheduleCanceled
    | SubscriptionScheduleCompleted
    | SubscriptionScheduleCreated
    | SubscriptionScheduleExpiring
    | SubscriptionScheduleReleased
    | SubscriptionScheduleUpdated
    | TaxSettingsUpdated
    | TaxRateCreated
    | TaxRateUpdated
    | TerminalReaderActionFailed
    | TerminalReaderActionSucceeded
    | TestHelpersTestClockAdvancing
    | TestHelpersTestClockCreated
    | TestHelpersTestClockDeleted
    | TestHelpersTestClockInternalFailure
    | TestHelpersTestClockReady
    | TopupCanceled
    | TopupCreated
    | TopupFailed
    | TopupReversed
    | TopupSucceeded
    | TransferCreated
    | TransferReversed
    | TransferUpdated
    | TreasuryCreditReversalCreated
    | TreasuryCreditReversalPosted
    | TreasuryDebitReversalCompleted
    | TreasuryDebitReversalCreated
    | TreasuryDebitReversalInitialCreditGranted
    | TreasuryFinancialAccountClosed
    | TreasuryFinancialAccountCreated
    | TreasuryFinancialAccountFeaturesStatusUpdated
    | TreasuryInboundTransferCanceled
    | TreasuryInboundTransferCreated
    | TreasuryInboundTransferFailed
    | TreasuryInboundTransferSucceeded
    | TreasuryOutboundPaymentCanceled
    | TreasuryOutboundPaymentCreated
    | TreasuryOutboundPaymentExpectedArrivalDateUpdated
    | TreasuryOutboundPaymentFailed
    | TreasuryOutboundPaymentPosted
    | TreasuryOutboundPaymentReturned
    | TreasuryOutboundTransferCanceled
    | TreasuryOutboundTransferCreated
    | TreasuryOutboundTransferExpectedArrivalDateUpdated
    | TreasuryOutboundTransferFailed
    | TreasuryOutboundTransferPosted
    | TreasuryOutboundTransferReturned
    | TreasuryReceivedCreditCreated
    | TreasuryReceivedCreditFailed
    | TreasuryReceivedCreditSucceeded
    | TreasuryReceivedDebitCreated

    type Create'ApiVersion =
    | [<JsonUnionCase("2011-01-01")>] Numeric20110101
    | [<JsonUnionCase("2011-06-21")>] Numeric20110621
    | [<JsonUnionCase("2011-06-28")>] Numeric20110628
    | [<JsonUnionCase("2011-08-01")>] Numeric20110801
    | [<JsonUnionCase("2011-09-15")>] Numeric20110915
    | [<JsonUnionCase("2011-11-17")>] Numeric20111117
    | [<JsonUnionCase("2012-02-23")>] Numeric20120223
    | [<JsonUnionCase("2012-03-25")>] Numeric20120325
    | [<JsonUnionCase("2012-06-18")>] Numeric20120618
    | [<JsonUnionCase("2012-06-28")>] Numeric20120628
    | [<JsonUnionCase("2012-07-09")>] Numeric20120709
    | [<JsonUnionCase("2012-09-24")>] Numeric20120924
    | [<JsonUnionCase("2012-10-26")>] Numeric20121026
    | [<JsonUnionCase("2012-11-07")>] Numeric20121107
    | [<JsonUnionCase("2013-02-11")>] Numeric20130211
    | [<JsonUnionCase("2013-02-13")>] Numeric20130213
    | [<JsonUnionCase("2013-07-05")>] Numeric20130705
    | [<JsonUnionCase("2013-08-12")>] Numeric20130812
    | [<JsonUnionCase("2013-08-13")>] Numeric20130813
    | [<JsonUnionCase("2013-10-29")>] Numeric20131029
    | [<JsonUnionCase("2013-12-03")>] Numeric20131203
    | [<JsonUnionCase("2014-01-31")>] Numeric20140131
    | [<JsonUnionCase("2014-03-13")>] Numeric20140313
    | [<JsonUnionCase("2014-03-28")>] Numeric20140328
    | [<JsonUnionCase("2014-05-19")>] Numeric20140519
    | [<JsonUnionCase("2014-06-13")>] Numeric20140613
    | [<JsonUnionCase("2014-06-17")>] Numeric20140617
    | [<JsonUnionCase("2014-07-22")>] Numeric20140722
    | [<JsonUnionCase("2014-07-26")>] Numeric20140726
    | [<JsonUnionCase("2014-08-04")>] Numeric20140804
    | [<JsonUnionCase("2014-08-20")>] Numeric20140820
    | [<JsonUnionCase("2014-09-08")>] Numeric20140908
    | [<JsonUnionCase("2014-10-07")>] Numeric20141007
    | [<JsonUnionCase("2014-11-05")>] Numeric20141105
    | [<JsonUnionCase("2014-11-20")>] Numeric20141120
    | [<JsonUnionCase("2014-12-08")>] Numeric20141208
    | [<JsonUnionCase("2014-12-17")>] Numeric20141217
    | [<JsonUnionCase("2014-12-22")>] Numeric20141222
    | [<JsonUnionCase("2015-01-11")>] Numeric20150111
    | [<JsonUnionCase("2015-01-26")>] Numeric20150126
    | [<JsonUnionCase("2015-02-10")>] Numeric20150210
    | [<JsonUnionCase("2015-02-16")>] Numeric20150216
    | [<JsonUnionCase("2015-02-18")>] Numeric20150218
    | [<JsonUnionCase("2015-03-24")>] Numeric20150324
    | [<JsonUnionCase("2015-04-07")>] Numeric20150407
    | [<JsonUnionCase("2015-06-15")>] Numeric20150615
    | [<JsonUnionCase("2015-07-07")>] Numeric20150707
    | [<JsonUnionCase("2015-07-13")>] Numeric20150713
    | [<JsonUnionCase("2015-07-28")>] Numeric20150728
    | [<JsonUnionCase("2015-08-07")>] Numeric20150807
    | [<JsonUnionCase("2015-08-19")>] Numeric20150819
    | [<JsonUnionCase("2015-09-03")>] Numeric20150903
    | [<JsonUnionCase("2015-09-08")>] Numeric20150908
    | [<JsonUnionCase("2015-09-23")>] Numeric20150923
    | [<JsonUnionCase("2015-10-01")>] Numeric20151001
    | [<JsonUnionCase("2015-10-12")>] Numeric20151012
    | [<JsonUnionCase("2015-10-16")>] Numeric20151016
    | [<JsonUnionCase("2016-02-03")>] Numeric20160203
    | [<JsonUnionCase("2016-02-19")>] Numeric20160219
    | [<JsonUnionCase("2016-02-22")>] Numeric20160222
    | [<JsonUnionCase("2016-02-23")>] Numeric20160223
    | [<JsonUnionCase("2016-02-29")>] Numeric20160229
    | [<JsonUnionCase("2016-03-07")>] Numeric20160307
    | [<JsonUnionCase("2016-06-15")>] Numeric20160615
    | [<JsonUnionCase("2016-07-06")>] Numeric20160706
    | [<JsonUnionCase("2016-10-19")>] Numeric20161019
    | [<JsonUnionCase("2017-01-27")>] Numeric20170127
    | [<JsonUnionCase("2017-02-14")>] Numeric20170214
    | [<JsonUnionCase("2017-04-06")>] Numeric20170406
    | [<JsonUnionCase("2017-05-25")>] Numeric20170525
    | [<JsonUnionCase("2017-06-05")>] Numeric20170605
    | [<JsonUnionCase("2017-08-15")>] Numeric20170815
    | [<JsonUnionCase("2017-12-14")>] Numeric20171214
    | [<JsonUnionCase("2018-01-23")>] Numeric20180123
    | [<JsonUnionCase("2018-02-05")>] Numeric20180205
    | [<JsonUnionCase("2018-02-06")>] Numeric20180206
    | [<JsonUnionCase("2018-02-28")>] Numeric20180228
    | [<JsonUnionCase("2018-05-21")>] Numeric20180521
    | [<JsonUnionCase("2018-07-27")>] Numeric20180727
    | [<JsonUnionCase("2018-08-23")>] Numeric20180823
    | [<JsonUnionCase("2018-09-06")>] Numeric20180906
    | [<JsonUnionCase("2018-09-24")>] Numeric20180924
    | [<JsonUnionCase("2018-10-31")>] Numeric20181031
    | [<JsonUnionCase("2018-11-08")>] Numeric20181108
    | [<JsonUnionCase("2019-02-11")>] Numeric20190211
    | [<JsonUnionCase("2019-02-19")>] Numeric20190219
    | [<JsonUnionCase("2019-03-14")>] Numeric20190314
    | [<JsonUnionCase("2019-05-16")>] Numeric20190516
    | [<JsonUnionCase("2019-08-14")>] Numeric20190814
    | [<JsonUnionCase("2019-09-09")>] Numeric20190909
    | [<JsonUnionCase("2019-10-08")>] Numeric20191008
    | [<JsonUnionCase("2019-10-17")>] Numeric20191017
    | [<JsonUnionCase("2019-11-05")>] Numeric20191105
    | [<JsonUnionCase("2019-12-03")>] Numeric20191203
    | [<JsonUnionCase("2020-03-02")>] Numeric20200302
    | [<JsonUnionCase("2020-08-27")>] Numeric20200827
    | [<JsonUnionCase("2022-08-01")>] Numeric20220801
    | [<JsonUnionCase("2022-11-15")>] Numeric20221115
    | [<JsonUnionCase("2023-08-16")>] Numeric20230816

    type CreateOptions = {
        ///Events sent to this endpoint will be generated with this Stripe Version instead of your account's default Stripe Version.
        [<Config.Form>]ApiVersion: Create'ApiVersion option
        ///Whether this endpoint should receive events from connected accounts (`true`), or from your account (`false`). Defaults to `false`.
        [<Config.Form>]Connect: bool option
        ///An optional description of what the webhook is used for.
        [<Config.Form>]Description: Choice<string,string> option
        ///The list of events to enable for this endpoint. You may specify `['*']` to enable all events, except those that require explicit selection.
        [<Config.Form>]EnabledEvents: Create'EnabledEvents list
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The URL of the webhook endpoint.
        [<Config.Form>]Url: string
    }
    with
        static member New(enabledEvents: Create'EnabledEvents list, url: string, ?apiVersion: Create'ApiVersion, ?connect: bool, ?description: Choice<string,string>, ?expand: string list, ?metadata: Map<string, string>) =
            {
                ApiVersion = apiVersion
                Connect = connect
                Description = description
                EnabledEvents = enabledEvents
                Expand = expand
                Metadata = metadata
                Url = url
            }

    ///<p>A webhook endpoint must have a <code>url</code> and a list of <code>enabled_events</code>. You may optionally specify the Boolean <code>connect</code> parameter. If set to true, then a Connect webhook endpoint that notifies the specified <code>url</code> about events from all connected accounts is created; otherwise an account webhook endpoint that notifies the specified <code>url</code> only about events from your account is created. You can also create webhook endpoints in the <a href="https://dashboard.stripe.com/account/webhooks">webhooks settings</a> section of the Dashboard.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/webhook_endpoints"
        |> RestApi.postAsync<_, WebhookEndpoint> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]WebhookEndpoint: string
    }
    with
        static member New(webhookEndpoint: string) =
            {
                WebhookEndpoint = webhookEndpoint
            }

    ///<p>You can also delete webhook endpoints via the <a href="https://dashboard.stripe.com/account/webhooks">webhook endpoint management</a> page of the Stripe dashboard.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/webhook_endpoints/{options.WebhookEndpoint}"
        |> RestApi.deleteAsync<DeletedWebhookEndpoint> settings (Map.empty)

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]WebhookEndpoint: string
    }
    with
        static member New(webhookEndpoint: string, ?expand: string list) =
            {
                Expand = expand
                WebhookEndpoint = webhookEndpoint
            }

    ///<p>Retrieves the webhook endpoint with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/webhook_endpoints/{options.WebhookEndpoint}"
        |> RestApi.getAsync<WebhookEndpoint> settings qs

    type Update'EnabledEvents =
    | Asterix
    | AccountApplicationAuthorized
    | AccountApplicationDeauthorized
    | AccountExternalAccountCreated
    | AccountExternalAccountDeleted
    | AccountExternalAccountUpdated
    | AccountUpdated
    | ApplicationFeeCreated
    | ApplicationFeeRefundUpdated
    | ApplicationFeeRefunded
    | BalanceAvailable
    | BillingPortalConfigurationCreated
    | BillingPortalConfigurationUpdated
    | BillingPortalSessionCreated
    | CapabilityUpdated
    | CashBalanceFundsAvailable
    | ChargeCaptured
    | ChargeDisputeClosed
    | ChargeDisputeCreated
    | ChargeDisputeFundsReinstated
    | ChargeDisputeFundsWithdrawn
    | ChargeDisputeUpdated
    | ChargeExpired
    | ChargeFailed
    | ChargePending
    | ChargeRefundUpdated
    | ChargeRefunded
    | ChargeSucceeded
    | ChargeUpdated
    | CheckoutSessionAsyncPaymentFailed
    | CheckoutSessionAsyncPaymentSucceeded
    | CheckoutSessionCompleted
    | CheckoutSessionExpired
    | CouponCreated
    | CouponDeleted
    | CouponUpdated
    | CreditNoteCreated
    | CreditNoteUpdated
    | CreditNoteVoided
    | CustomerCreated
    | CustomerDeleted
    | CustomerDiscountCreated
    | CustomerDiscountDeleted
    | CustomerDiscountUpdated
    | CustomerSourceCreated
    | CustomerSourceDeleted
    | CustomerSourceExpiring
    | CustomerSourceUpdated
    | CustomerSubscriptionCreated
    | CustomerSubscriptionDeleted
    | CustomerSubscriptionPaused
    | CustomerSubscriptionPendingUpdateApplied
    | CustomerSubscriptionPendingUpdateExpired
    | CustomerSubscriptionResumed
    | CustomerSubscriptionTrialWillEnd
    | CustomerSubscriptionUpdated
    | CustomerTaxIdCreated
    | CustomerTaxIdDeleted
    | CustomerTaxIdUpdated
    | CustomerUpdated
    | CustomerCashBalanceTransactionCreated
    | FileCreated
    | FinancialConnectionsAccountCreated
    | FinancialConnectionsAccountDeactivated
    | FinancialConnectionsAccountDisconnected
    | FinancialConnectionsAccountReactivated
    | FinancialConnectionsAccountRefreshedBalance
    | IdentityVerificationSessionCanceled
    | IdentityVerificationSessionCreated
    | IdentityVerificationSessionProcessing
    | IdentityVerificationSessionRedacted
    | IdentityVerificationSessionRequiresInput
    | IdentityVerificationSessionVerified
    | InvoiceCreated
    | InvoiceDeleted
    | InvoiceFinalizationFailed
    | InvoiceFinalized
    | InvoiceMarkedUncollectible
    | InvoicePaid
    | InvoicePaymentActionRequired
    | InvoicePaymentFailed
    | InvoicePaymentSucceeded
    | InvoiceSent
    | InvoiceUpcoming
    | InvoiceUpdated
    | InvoiceVoided
    | InvoiceitemCreated
    | InvoiceitemDeleted
    | InvoiceitemUpdated
    | IssuingAuthorizationCreated
    | IssuingAuthorizationRequest
    | IssuingAuthorizationUpdated
    | IssuingCardCreated
    | IssuingCardUpdated
    | IssuingCardholderCreated
    | IssuingCardholderUpdated
    | IssuingDisputeClosed
    | IssuingDisputeCreated
    | IssuingDisputeFundsReinstated
    | IssuingDisputeSubmitted
    | IssuingDisputeUpdated
    | IssuingTransactionCreated
    | IssuingTransactionUpdated
    | MandateUpdated
    | OrderCreated
    | PaymentIntentAmountCapturableUpdated
    | PaymentIntentCanceled
    | PaymentIntentCreated
    | PaymentIntentPartiallyFunded
    | PaymentIntentPaymentFailed
    | PaymentIntentProcessing
    | PaymentIntentRequiresAction
    | PaymentIntentSucceeded
    | PaymentLinkCreated
    | PaymentLinkUpdated
    | PaymentMethodAttached
    | PaymentMethodAutomaticallyUpdated
    | PaymentMethodDetached
    | PaymentMethodUpdated
    | PayoutCanceled
    | PayoutCreated
    | PayoutFailed
    | PayoutPaid
    | PayoutReconciliationCompleted
    | PayoutUpdated
    | PersonCreated
    | PersonDeleted
    | PersonUpdated
    | PlanCreated
    | PlanDeleted
    | PlanUpdated
    | PriceCreated
    | PriceDeleted
    | PriceUpdated
    | ProductCreated
    | ProductDeleted
    | ProductUpdated
    | PromotionCodeCreated
    | PromotionCodeUpdated
    | QuoteAccepted
    | QuoteCanceled
    | QuoteCreated
    | QuoteFinalized
    | RadarEarlyFraudWarningCreated
    | RadarEarlyFraudWarningUpdated
    | RecipientCreated
    | RecipientDeleted
    | RecipientUpdated
    | RefundCreated
    | RefundUpdated
    | ReportingReportRunFailed
    | ReportingReportRunSucceeded
    | ReportingReportTypeUpdated
    | ReviewClosed
    | ReviewOpened
    | SetupIntentCanceled
    | SetupIntentCreated
    | SetupIntentRequiresAction
    | SetupIntentSetupFailed
    | SetupIntentSucceeded
    | SigmaScheduledQueryRunCreated
    | SkuCreated
    | SkuDeleted
    | SkuUpdated
    | SourceCanceled
    | SourceChargeable
    | SourceFailed
    | SourceMandateNotification
    | SourceRefundAttributesRequired
    | SourceTransactionCreated
    | SourceTransactionUpdated
    | SubscriptionScheduleAborted
    | SubscriptionScheduleCanceled
    | SubscriptionScheduleCompleted
    | SubscriptionScheduleCreated
    | SubscriptionScheduleExpiring
    | SubscriptionScheduleReleased
    | SubscriptionScheduleUpdated
    | TaxSettingsUpdated
    | TaxRateCreated
    | TaxRateUpdated
    | TerminalReaderActionFailed
    | TerminalReaderActionSucceeded
    | TestHelpersTestClockAdvancing
    | TestHelpersTestClockCreated
    | TestHelpersTestClockDeleted
    | TestHelpersTestClockInternalFailure
    | TestHelpersTestClockReady
    | TopupCanceled
    | TopupCreated
    | TopupFailed
    | TopupReversed
    | TopupSucceeded
    | TransferCreated
    | TransferReversed
    | TransferUpdated
    | TreasuryCreditReversalCreated
    | TreasuryCreditReversalPosted
    | TreasuryDebitReversalCompleted
    | TreasuryDebitReversalCreated
    | TreasuryDebitReversalInitialCreditGranted
    | TreasuryFinancialAccountClosed
    | TreasuryFinancialAccountCreated
    | TreasuryFinancialAccountFeaturesStatusUpdated
    | TreasuryInboundTransferCanceled
    | TreasuryInboundTransferCreated
    | TreasuryInboundTransferFailed
    | TreasuryInboundTransferSucceeded
    | TreasuryOutboundPaymentCanceled
    | TreasuryOutboundPaymentCreated
    | TreasuryOutboundPaymentExpectedArrivalDateUpdated
    | TreasuryOutboundPaymentFailed
    | TreasuryOutboundPaymentPosted
    | TreasuryOutboundPaymentReturned
    | TreasuryOutboundTransferCanceled
    | TreasuryOutboundTransferCreated
    | TreasuryOutboundTransferExpectedArrivalDateUpdated
    | TreasuryOutboundTransferFailed
    | TreasuryOutboundTransferPosted
    | TreasuryOutboundTransferReturned
    | TreasuryReceivedCreditCreated
    | TreasuryReceivedCreditFailed
    | TreasuryReceivedCreditSucceeded
    | TreasuryReceivedDebitCreated

    type UpdateOptions = {
        [<Config.Path>]WebhookEndpoint: string
        ///An optional description of what the webhook is used for.
        [<Config.Form>]Description: Choice<string,string> option
        ///Disable the webhook endpoint if set to true.
        [<Config.Form>]Disabled: bool option
        ///The list of events to enable for this endpoint. You may specify `['*']` to enable all events, except those that require explicit selection.
        [<Config.Form>]EnabledEvents: Update'EnabledEvents list option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The URL of the webhook endpoint.
        [<Config.Form>]Url: string option
    }
    with
        static member New(webhookEndpoint: string, ?description: Choice<string,string>, ?disabled: bool, ?enabledEvents: Update'EnabledEvents list, ?expand: string list, ?metadata: Map<string, string>, ?url: string) =
            {
                WebhookEndpoint = webhookEndpoint
                Description = description
                Disabled = disabled
                EnabledEvents = enabledEvents
                Expand = expand
                Metadata = metadata
                Url = url
            }

    ///<p>Updates the webhook endpoint. You may edit the <code>url</code>, the list of <code>enabled_events</code>, and the status of your endpoint.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/webhook_endpoints/{options.WebhookEndpoint}"
        |> RestApi.postAsync<_, WebhookEndpoint> settings (Map.empty) options
