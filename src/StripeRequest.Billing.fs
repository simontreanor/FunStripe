namespace FunStripe.StripeRequest

open FunStripe
open System.Text.Json.Serialization
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module BillingAlerts =

    type ListOptions = {
        ///<summary>Filter results to only include this type of alert.</summary>
        [<Config.Query>]AlertType: string option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Filter results to only include alerts with the given meter.</summary>
        [<Config.Query>]Meter: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?alertType: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?meter: string, ?startingAfter: string) =
            {
                AlertType = alertType
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Meter = meter
                StartingAfter = startingAfter
            }

    ///<summary><p>Lists billing active and inactive alerts</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("alert_type", options.AlertType |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("meter", options.Meter |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/billing/alerts"
        |> RestApi.getAsync<StripeList<BillingAlert>> settings qs

    type Create'UsageThresholdFiltersType =
    | Customer

    type Create'UsageThresholdFilters = {
        ///<summary>Limit the scope to this usage alert only to this customer.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>What type of filter is being applied to this usage alert.</summary>
        [<Config.Form>]Type: Create'UsageThresholdFiltersType option
    }
    with
        static member New(?customer: string, ?type': Create'UsageThresholdFiltersType) =
            {
                Customer = customer
                Type = type'
            }

    type Create'UsageThresholdRecurrence =
    | OneTime

    type Create'UsageThreshold = {
        ///<summary>The filters allows limiting the scope of this usage alert. You can only specify up to one filter at this time.</summary>
        [<Config.Form>]Filters: Create'UsageThresholdFilters list option
        ///<summary>Defines the threshold value that triggers the alert.</summary>
        [<Config.Form>]Gte: int option
        ///<summary>The [Billing Meter](/api/billing/meter) ID whose usage is monitored.</summary>
        [<Config.Form>]Meter: string option
        ///<summary>Defines how the alert will behave.</summary>
        [<Config.Form>]Recurrence: Create'UsageThresholdRecurrence option
    }
    with
        static member New(?filters: Create'UsageThresholdFilters list, ?gte: int, ?meter: string, ?recurrence: Create'UsageThresholdRecurrence) =
            {
                Filters = filters
                Gte = gte
                Meter = meter
                Recurrence = recurrence
            }

    type Create'AlertType =
    | UsageThreshold

    type CreateOptions = {
        ///<summary>The type of alert to create.</summary>
        [<Config.Form>]AlertType: Create'AlertType
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The title of the alert.</summary>
        [<Config.Form>]Title: string
        ///<summary>The configuration of the usage threshold.</summary>
        [<Config.Form>]UsageThreshold: Create'UsageThreshold option
    }
    with
        static member New(alertType: Create'AlertType, title: string, ?expand: string list, ?usageThreshold: Create'UsageThreshold) =
            {
                AlertType = alertType
                Expand = expand
                Title = title
                UsageThreshold = usageThreshold
            }

    ///<summary><p>Creates a billing alert</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/billing/alerts"
        |> RestApi.postAsync<_, BillingAlert> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves a billing alert given an ID</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/billing/alerts/{options.Id}"
        |> RestApi.getAsync<BillingAlert> settings qs

module BillingAlertsActivate =

    type ActivateOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<summary><p>Reactivates this alert, allowing it to trigger again.</p></summary>
    let Activate settings (options: ActivateOptions) =
        $"/v1/billing/alerts/{options.Id}/activate"
        |> RestApi.postAsync<_, BillingAlert> settings (Map.empty) options

module BillingAlertsArchive =

    type ArchiveOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<summary><p>Archives this alert, removing it from the list view and APIs. This is non-reversible.</p></summary>
    let Archive settings (options: ArchiveOptions) =
        $"/v1/billing/alerts/{options.Id}/archive"
        |> RestApi.postAsync<_, BillingAlert> settings (Map.empty) options

module BillingAlertsDeactivate =

    type DeactivateOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<summary><p>Deactivates this alert, preventing it from triggering.</p></summary>
    let Deactivate settings (options: DeactivateOptions) =
        $"/v1/billing/alerts/{options.Id}/deactivate"
        |> RestApi.postAsync<_, BillingAlert> settings (Map.empty) options

module BillingCreditBalanceSummary =

    type RetrieveOptions = {
        ///<summary>The customer whose credit balance summary you're retrieving.</summary>
        [<Config.Query>]Customer: string option
        ///<summary>The account representing the customer whose credit balance summary you're retrieving.</summary>
        [<Config.Query>]CustomerAccount: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>The filter criteria for the credit balance summary.</summary>
        [<Config.Query>]Filter: Map<string, string>
    }
    with
        static member New(filter: Map<string, string>, ?customer: string, ?customerAccount: string, ?expand: string list) =
            {
                Customer = customer
                CustomerAccount = customerAccount
                Expand = expand
                Filter = filter
            }

    ///<summary><p>Retrieves the credit balance summary for a customer.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("expand", options.Expand |> box); ("filter", options.Filter |> box)] |> Map.ofList
        $"/v1/billing/credit_balance_summary"
        |> RestApi.getAsync<BillingCreditBalanceSummary> settings qs

module BillingCreditBalanceTransactions =

    type ListOptions = {
        ///<summary>The credit grant for which to fetch credit balance transactions.</summary>
        [<Config.Query>]CreditGrant: string option
        ///<summary>The customer whose credit balance transactions you're retrieving.</summary>
        [<Config.Query>]Customer: string option
        ///<summary>The account representing the customer whose credit balance transactions you're retrieving.</summary>
        [<Config.Query>]CustomerAccount: string option
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
        static member New(?creditGrant: string, ?customer: string, ?customerAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                CreditGrant = creditGrant
                Customer = customer
                CustomerAccount = customerAccount
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Retrieve a list of credit balance transactions.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("credit_grant", options.CreditGrant |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/billing/credit_balance_transactions"
        |> RestApi.getAsync<StripeList<BillingCreditBalanceTransaction>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Unique identifier for the object.</summary>
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves a credit balance transaction.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/billing/credit_balance_transactions/{options.Id}"
        |> RestApi.getAsync<BillingCreditBalanceTransaction> settings qs

module BillingCreditGrants =

    type ListOptions = {
        ///<summary>Only return credit grants for this customer.</summary>
        [<Config.Query>]Customer: string option
        ///<summary>Only return credit grants for this account representing the customer.</summary>
        [<Config.Query>]CustomerAccount: string option
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
        static member New(?customer: string, ?customerAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Customer = customer
                CustomerAccount = customerAccount
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Retrieve a list of credit grants.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/billing/credit_grants"
        |> RestApi.getAsync<StripeList<BillingCreditGrant>> settings qs

    type Create'AmountMonetary = {
        ///<summary>Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) of the `value` parameter.</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>A positive integer representing the amount of the credit grant.</summary>
        [<Config.Form>]Value: int option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?value: int) =
            {
                Currency = currency
                Value = value
            }

    type Create'AmountType =
    | Monetary

    type Create'Amount = {
        ///<summary>The monetary amount.</summary>
        [<Config.Form>]Monetary: Create'AmountMonetary option
        ///<summary>The type of this amount. We currently only support `monetary` billing credits.</summary>
        [<Config.Form>]Type: Create'AmountType option
    }
    with
        static member New(?monetary: Create'AmountMonetary, ?type': Create'AmountType) =
            {
                Monetary = monetary
                Type = type'
            }

    type Create'ApplicabilityConfigScopePrices = {
        ///<summary>The price ID this credit grant should apply to.</summary>
        [<Config.Form>]Id: string option
    }
    with
        static member New(?id: string) =
            {
                Id = id
            }

    type Create'ApplicabilityConfigScopePriceType =
    | Metered

    type Create'ApplicabilityConfigScope = {
        ///<summary>The price type that credit grants can apply to. We currently only support the `metered` price type. Cannot be used in combination with `prices`.</summary>
        [<Config.Form>]PriceType: Create'ApplicabilityConfigScopePriceType option
        ///<summary>A list of prices that the credit grant can apply to. We currently only support the `metered` prices. Cannot be used in combination with `price_type`.</summary>
        [<Config.Form>]Prices: Create'ApplicabilityConfigScopePrices list option
    }
    with
        static member New(?priceType: Create'ApplicabilityConfigScopePriceType, ?prices: Create'ApplicabilityConfigScopePrices list) =
            {
                PriceType = priceType
                Prices = prices
            }

    type Create'ApplicabilityConfig = {
        ///<summary>Specify the scope of this applicability config.</summary>
        [<Config.Form>]Scope: Create'ApplicabilityConfigScope option
    }
    with
        static member New(?scope: Create'ApplicabilityConfigScope) =
            {
                Scope = scope
            }

    type Create'Category =
    | Paid
    | Promotional

    type CreateOptions = {
        ///<summary>Amount of this credit grant.</summary>
        [<Config.Form>]Amount: Create'Amount
        ///<summary>Configuration specifying what this credit grant applies to. We currently only support `metered` prices that have a [Billing Meter](https://docs.stripe.com/api/billing/meter) attached to them.</summary>
        [<Config.Form>]ApplicabilityConfig: Create'ApplicabilityConfig
        ///<summary>The category of this credit grant. It defaults to `paid` if not specified.</summary>
        [<Config.Form>]Category: Create'Category option
        ///<summary>ID of the customer receiving the billing credits.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>ID of the account representing the customer receiving the billing credits.</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>The time when the billing credits become effective-when they're eligible for use. It defaults to the current timestamp if not specified.</summary>
        [<Config.Form>]EffectiveAt: DateTime option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The time when the billing credits expire. If not specified, the billing credits don't expire.</summary>
        [<Config.Form>]ExpiresAt: DateTime option
        ///<summary>Set of key-value pairs that you can attach to an object. You can use this to store additional information about the object (for example, cost basis) in a structured format.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>A descriptive name shown in the Dashboard.</summary>
        [<Config.Form>]Name: string option
        ///<summary>The desired priority for applying this credit grant. If not specified, it will be set to the default value of 50. The highest priority is 0 and the lowest is 100.</summary>
        [<Config.Form>]Priority: int option
    }
    with
        static member New(amount: Create'Amount, applicabilityConfig: Create'ApplicabilityConfig, ?category: Create'Category, ?customer: string, ?customerAccount: string, ?effectiveAt: DateTime, ?expand: string list, ?expiresAt: DateTime, ?metadata: Map<string, string>, ?name: string, ?priority: int) =
            {
                Amount = amount
                ApplicabilityConfig = applicabilityConfig
                Category = category
                Customer = customer
                CustomerAccount = customerAccount
                EffectiveAt = effectiveAt
                Expand = expand
                ExpiresAt = expiresAt
                Metadata = metadata
                Name = name
                Priority = priority
            }

    ///<summary><p>Creates a credit grant.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/billing/credit_grants"
        |> RestApi.postAsync<_, BillingCreditGrant> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Unique identifier for the object.</summary>
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves a credit grant.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/billing/credit_grants/{options.Id}"
        |> RestApi.getAsync<BillingCreditGrant> settings qs

    type UpdateOptions = {
        ///<summary>Unique identifier for the object.</summary>
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The time when the billing credits created by this credit grant expire. If set to empty, the billing credits never expire.</summary>
        [<Config.Form>]ExpiresAt: Choice<DateTime,string> option
        ///<summary>Set of key-value pairs you can attach to an object. You can use this to store additional information about the object (for example, cost basis) in a structured format.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(id: string, ?expand: string list, ?expiresAt: Choice<DateTime,string>, ?metadata: Map<string, string>) =
            {
                Id = id
                Expand = expand
                ExpiresAt = expiresAt
                Metadata = metadata
            }

    ///<summary><p>Updates a credit grant.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/billing/credit_grants/{options.Id}"
        |> RestApi.postAsync<_, BillingCreditGrant> settings (Map.empty) options

module BillingCreditGrantsExpire =

    type ExpireOptions = {
        ///<summary>Unique identifier for the object.</summary>
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<summary><p>Expires a credit grant.</p></summary>
    let Expire settings (options: ExpireOptions) =
        $"/v1/billing/credit_grants/{options.Id}/expire"
        |> RestApi.postAsync<_, BillingCreditGrant> settings (Map.empty) options

module BillingCreditGrantsVoid =

    type VoidGrantOptions = {
        ///<summary>Unique identifier for the object.</summary>
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<summary><p>Voids a credit grant.</p></summary>
    let VoidGrant settings (options: VoidGrantOptions) =
        $"/v1/billing/credit_grants/{options.Id}/void"
        |> RestApi.postAsync<_, BillingCreditGrant> settings (Map.empty) options

module BillingMeterEventAdjustments =

    type Create'Cancel = {
        ///<summary>Unique identifier for the event. You can only cancel events within 24 hours of Stripe receiving them.</summary>
        [<Config.Form>]Identifier: string option
    }
    with
        static member New(?identifier: string) =
            {
                Identifier = identifier
            }

    type Create'Type =
    | Cancel

    type CreateOptions = {
        ///<summary>Specifies which event to cancel.</summary>
        [<Config.Form>]Cancel: Create'Cancel option
        ///<summary>The name of the meter event. Corresponds with the `event_name` field on a meter.</summary>
        [<Config.Form>]EventName: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Specifies whether to cancel a single event or a range of events for a time period. Time period cancellation is not supported yet.</summary>
        [<Config.Form>]Type: Create'Type
    }
    with
        static member New(eventName: string, type': Create'Type, ?cancel: Create'Cancel, ?expand: string list) =
            {
                Cancel = cancel
                EventName = eventName
                Expand = expand
                Type = type'
            }

    ///<summary><p>Creates a billing meter event adjustment.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/billing/meter_event_adjustments"
        |> RestApi.postAsync<_, BillingMeterEventAdjustment> settings (Map.empty) options

module BillingMeterEvents =

    type CreateOptions = {
        ///<summary>The name of the meter event. Corresponds with the `event_name` field on a meter.</summary>
        [<Config.Form>]EventName: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A unique identifier for the event. If not provided, one is generated. We recommend using UUID-like identifiers. Stripe enforces uniqueness within a rolling period of at least 24 hours. The enforcement of uniqueness primarily addresses issues arising from accidental retries or other problems occurring within extremely brief time intervals. This approach helps prevent duplicate entries and ensures data integrity in high-frequency operations.</summary>
        [<Config.Form>]Identifier: string option
        ///<summary>The payload of the event. This must contain the fields corresponding to a meter's `customer_mapping.event_payload_key` (default is `stripe_customer_id`) and `value_settings.event_payload_key` (default is `value`). Read more about the [payload](https://docs.stripe.com/billing/subscriptions/usage-based/meters/configure#meter-configuration-attributes).</summary>
        [<Config.Form>]Payload: Map<string, string>
        ///<summary>The time of the event. Measured in seconds since the Unix epoch. Must be within the past 35 calendar days or up to 5 minutes in the future. Defaults to current timestamp if not specified.</summary>
        [<Config.Form>]Timestamp: DateTime option
    }
    with
        static member New(eventName: string, payload: Map<string, string>, ?expand: string list, ?identifier: string, ?timestamp: DateTime) =
            {
                EventName = eventName
                Expand = expand
                Identifier = identifier
                Payload = payload
                Timestamp = timestamp
            }

    ///<summary><p>Creates a billing meter event.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/billing/meter_events"
        |> RestApi.postAsync<_, BillingMeterEvent> settings (Map.empty) options

module BillingMeters =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Filter results to only include meters with the given status.</summary>
        [<Config.Query>]Status: string option
    }
    with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    ///<summary><p>Retrieve a list of billing meters.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/billing/meters"
        |> RestApi.getAsync<StripeList<BillingMeter>> settings qs

    type Create'CustomerMappingType =
    | ById

    type Create'CustomerMapping = {
        ///<summary>The key in the meter event payload to use for mapping the event to a customer.</summary>
        [<Config.Form>]EventPayloadKey: string option
        ///<summary>The method for mapping a meter event to a customer. Must be `by_id`.</summary>
        [<Config.Form>]Type: Create'CustomerMappingType option
    }
    with
        static member New(?eventPayloadKey: string, ?type': Create'CustomerMappingType) =
            {
                EventPayloadKey = eventPayloadKey
                Type = type'
            }

    type Create'DefaultAggregationFormula =
    | Count
    | Last
    | Sum

    type Create'DefaultAggregation = {
        ///<summary>Specifies how events are aggregated.</summary>
        [<Config.Form>]Formula: Create'DefaultAggregationFormula option
    }
    with
        static member New(?formula: Create'DefaultAggregationFormula) =
            {
                Formula = formula
            }

    type Create'ValueSettings = {
        ///<summary>The key in the usage event payload to use as the value for this meter. For example, if the event payload contains usage on a `bytes_used` field, then set the event_payload_key to "bytes_used".</summary>
        [<Config.Form>]EventPayloadKey: string option
    }
    with
        static member New(?eventPayloadKey: string) =
            {
                EventPayloadKey = eventPayloadKey
            }

    type Create'EventTimeWindow =
    | Day
    | Hour

    type CreateOptions = {
        ///<summary>Fields that specify how to map a meter event to a customer.</summary>
        [<Config.Form>]CustomerMapping: Create'CustomerMapping option
        ///<summary>The default settings to aggregate a meter's events with.</summary>
        [<Config.Form>]DefaultAggregation: Create'DefaultAggregation
        ///<summary>The meter’s name. Not visible to the customer.</summary>
        [<Config.Form>]DisplayName: string
        ///<summary>The name of the meter event to record usage for. Corresponds with the `event_name` field on meter events.</summary>
        [<Config.Form>]EventName: string
        ///<summary>The time window which meter events have been pre-aggregated for, if any.</summary>
        [<Config.Form>]EventTimeWindow: Create'EventTimeWindow option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Fields that specify how to calculate a meter event's value.</summary>
        [<Config.Form>]ValueSettings: Create'ValueSettings option
    }
    with
        static member New(defaultAggregation: Create'DefaultAggregation, displayName: string, eventName: string, ?customerMapping: Create'CustomerMapping, ?eventTimeWindow: Create'EventTimeWindow, ?expand: string list, ?valueSettings: Create'ValueSettings) =
            {
                CustomerMapping = customerMapping
                DefaultAggregation = defaultAggregation
                DisplayName = displayName
                EventName = eventName
                EventTimeWindow = eventTimeWindow
                Expand = expand
                ValueSettings = valueSettings
            }

    ///<summary><p>Creates a billing meter.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/billing/meters"
        |> RestApi.postAsync<_, BillingMeter> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves a billing meter given an ID.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/billing/meters/{options.Id}"
        |> RestApi.getAsync<BillingMeter> settings qs

    type UpdateOptions = {
        [<Config.Path>]Id: string
        ///<summary>The meter’s name. Not visible to the customer.</summary>
        [<Config.Form>]DisplayName: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?displayName: string, ?expand: string list) =
            {
                Id = id
                DisplayName = displayName
                Expand = expand
            }

    ///<summary><p>Updates a billing meter.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/billing/meters/{options.Id}"
        |> RestApi.postAsync<_, BillingMeter> settings (Map.empty) options

module BillingMetersDeactivate =

    type DeactivateOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<summary><p>When a meter is deactivated, no more meter events will be accepted for this meter. You can’t attach a deactivated meter to a price.</p></summary>
    let Deactivate settings (options: DeactivateOptions) =
        $"/v1/billing/meters/{options.Id}/deactivate"
        |> RestApi.postAsync<_, BillingMeter> settings (Map.empty) options

module BillingMetersEventSummaries =

    type ListOptions = {
        ///<summary>The customer for which to fetch event summaries.</summary>
        [<Config.Query>]Customer: string
        ///<summary>The timestamp from when to stop aggregating meter events (exclusive). Must be aligned with minute boundaries.</summary>
        [<Config.Query>]EndTime: int
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Unique identifier for the object.</summary>
        [<Config.Path>]Id: string
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>The timestamp from when to start aggregating meter events (inclusive). Must be aligned with minute boundaries.</summary>
        [<Config.Query>]StartTime: int
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Specifies what granularity to use when generating event summaries. If not specified, a single event summary would be returned for the specified time range. For hourly granularity, start and end times must align with hour boundaries (e.g., 00:00, 01:00, ..., 23:00). For daily granularity, start and end times must align with UTC day boundaries (00:00 UTC).</summary>
        [<Config.Query>]ValueGroupingWindow: string option
    }
    with
        static member New(customer: string, endTime: int, id: string, startTime: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?valueGroupingWindow: string) =
            {
                Customer = customer
                EndTime = endTime
                EndingBefore = endingBefore
                Expand = expand
                Id = id
                Limit = limit
                StartTime = startTime
                StartingAfter = startingAfter
                ValueGroupingWindow = valueGroupingWindow
            }

    ///<summary><p>Retrieve a list of billing meter event summaries.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("customer", options.Customer |> box); ("end_time", options.EndTime |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("start_time", options.StartTime |> box); ("starting_after", options.StartingAfter |> box); ("value_grouping_window", options.ValueGroupingWindow |> box)] |> Map.ofList
        $"/v1/billing/meters/{options.Id}/event_summaries"
        |> RestApi.getAsync<StripeList<BillingMeterEventSummary>> settings qs

module BillingMetersReactivate =

    type ReactivateOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<summary><p>When a meter is reactivated, events for this meter can be accepted and you can attach the meter to a price.</p></summary>
    let Reactivate settings (options: ReactivateOptions) =
        $"/v1/billing/meters/{options.Id}/reactivate"
        |> RestApi.postAsync<_, BillingMeter> settings (Map.empty) options

module BillingPortalConfigurations =

    type ListOptions = {
        ///<summary>Only return configurations that are active or inactive (e.g., pass `true` to only list active configurations).</summary>
        [<Config.Query>]Active: bool option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Only return the default or non-default configurations (e.g., pass `true` to only list the default configuration).</summary>
        [<Config.Query>]IsDefault: bool option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?active: bool, ?endingBefore: string, ?expand: string list, ?isDefault: bool, ?limit: int, ?startingAfter: string) =
            {
                Active = active
                EndingBefore = endingBefore
                Expand = expand
                IsDefault = isDefault
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of configurations that describe the functionality of the customer portal.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("is_default", options.IsDefault |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/billing_portal/configurations"
        |> RestApi.getAsync<StripeList<BillingPortalConfiguration>> settings qs

    type Create'BusinessProfile = {
        ///<summary>The messaging shown to customers in the portal.</summary>
        [<Config.Form>]Headline: Choice<string,string> option
        ///<summary>A link to the business’s publicly available privacy policy.</summary>
        [<Config.Form>]PrivacyPolicyUrl: string option
        ///<summary>A link to the business’s publicly available terms of service.</summary>
        [<Config.Form>]TermsOfServiceUrl: string option
    }
    with
        static member New(?headline: Choice<string,string>, ?privacyPolicyUrl: string, ?termsOfServiceUrl: string) =
            {
                Headline = headline
                PrivacyPolicyUrl = privacyPolicyUrl
                TermsOfServiceUrl = termsOfServiceUrl
            }

    type Create'FeaturesCustomerUpdateAllowedUpdates =
    | Address
    | Email
    | Name
    | Phone
    | Shipping
    | TaxId

    type Create'FeaturesCustomerUpdate = {
        ///<summary>The types of customer updates that are supported. When empty, customers are not updateable.</summary>
        [<Config.Form>]AllowedUpdates: Choice<Create'FeaturesCustomerUpdateAllowedUpdates list,string> option
        ///<summary>Whether the feature is enabled.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?allowedUpdates: Choice<Create'FeaturesCustomerUpdateAllowedUpdates list,string>, ?enabled: bool) =
            {
                AllowedUpdates = allowedUpdates
                Enabled = enabled
            }

    type Create'FeaturesInvoiceHistory = {
        ///<summary>Whether the feature is enabled.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Create'FeaturesPaymentMethodUpdate = {
        ///<summary>Whether the feature is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The [Payment Method Configuration](/api/payment_method_configurations) to use for this portal session. When specified, customers will be able to update their payment method to one of the options specified by the payment method configuration. If not set or set to an empty string, the default payment method configuration is used.</summary>
        [<Config.Form>]PaymentMethodConfiguration: Choice<string,string> option
    }
    with
        static member New(?enabled: bool, ?paymentMethodConfiguration: Choice<string,string>) =
            {
                Enabled = enabled
                PaymentMethodConfiguration = paymentMethodConfiguration
            }

    type Create'FeaturesSubscriptionCancelCancellationReasonOptions =
    | CustomerService
    | LowQuality
    | MissingFeatures
    | Other
    | SwitchedService
    | TooComplex
    | TooExpensive
    | Unused

    type Create'FeaturesSubscriptionCancelCancellationReason = {
        ///<summary>Whether the feature is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Which cancellation reasons will be given as options to the customer.</summary>
        [<Config.Form>]Options: Choice<Create'FeaturesSubscriptionCancelCancellationReasonOptions list,string> option
    }
    with
        static member New(?enabled: bool, ?options: Choice<Create'FeaturesSubscriptionCancelCancellationReasonOptions list,string>) =
            {
                Enabled = enabled
                Options = options
            }

    type Create'FeaturesSubscriptionCancelMode =
    | AtPeriodEnd
    | Immediately

    type Create'FeaturesSubscriptionCancelProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type Create'FeaturesSubscriptionCancel = {
        ///<summary>Whether the cancellation reasons will be collected in the portal and which options are exposed to the customer</summary>
        [<Config.Form>]CancellationReason: Create'FeaturesSubscriptionCancelCancellationReason option
        ///<summary>Whether the feature is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Whether to cancel subscriptions immediately or at the end of the billing period.</summary>
        [<Config.Form>]Mode: Create'FeaturesSubscriptionCancelMode option
        ///<summary>Whether to create prorations when canceling subscriptions. Possible values are `none` and `create_prorations`, which is only compatible with `mode=immediately`. Passing `always_invoice` will result in an error. No prorations are generated when canceling a subscription at the end of its natural billing period.</summary>
        [<Config.Form>]ProrationBehavior: Create'FeaturesSubscriptionCancelProrationBehavior option
    }
    with
        static member New(?cancellationReason: Create'FeaturesSubscriptionCancelCancellationReason, ?enabled: bool, ?mode: Create'FeaturesSubscriptionCancelMode, ?prorationBehavior: Create'FeaturesSubscriptionCancelProrationBehavior) =
            {
                CancellationReason = cancellationReason
                Enabled = enabled
                Mode = mode
                ProrationBehavior = prorationBehavior
            }

    type Create'FeaturesSubscriptionUpdateDefaultAllowedUpdates =
    | Price
    | PromotionCode
    | Quantity

    type Create'FeaturesSubscriptionUpdateProductsAdjustableQuantity = {
        ///<summary>Set to true if the quantity can be adjusted to any non-negative integer.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The maximum quantity that can be set for the product.</summary>
        [<Config.Form>]Maximum: int option
        ///<summary>The minimum quantity that can be set for the product.</summary>
        [<Config.Form>]Minimum: int option
    }
    with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
            }

    type Create'FeaturesSubscriptionUpdateProducts = {
        ///<summary>Control whether the quantity of the product can be adjusted.</summary>
        [<Config.Form>]AdjustableQuantity: Create'FeaturesSubscriptionUpdateProductsAdjustableQuantity option
        ///<summary>The list of price IDs for the product that a subscription can be updated to.</summary>
        [<Config.Form>]Prices: string list option
        ///<summary>The product id.</summary>
        [<Config.Form>]Product: string option
    }
    with
        static member New(?adjustableQuantity: Create'FeaturesSubscriptionUpdateProductsAdjustableQuantity, ?prices: string list, ?product: string) =
            {
                AdjustableQuantity = adjustableQuantity
                Prices = prices
                Product = product
            }

    type Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType =
    | DecreasingItemAmount
    | ShorteningInterval

    type Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions = {
        ///<summary>The type of condition.</summary>
        [<Config.Form>]Type: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType option
    }
    with
        static member New(?type': Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType) =
            {
                Type = type'
            }

    type Create'FeaturesSubscriptionUpdateScheduleAtPeriodEnd = {
        ///<summary>List of conditions. When any condition is true, the update will be scheduled at the end of the current period.</summary>
        [<Config.Form>]Conditions: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions list option
    }
    with
        static member New(?conditions: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions list) =
            {
                Conditions = conditions
            }

    type Create'FeaturesSubscriptionUpdateBillingCycleAnchor =
    | Now
    | Unchanged

    type Create'FeaturesSubscriptionUpdateProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type Create'FeaturesSubscriptionUpdateTrialUpdateBehavior =
    | ContinueTrial
    | EndTrial

    type Create'FeaturesSubscriptionUpdate = {
        ///<summary>Determines the value to use for the billing cycle anchor on subscription updates. Valid values are `now` or `unchanged`, and the default value is `unchanged`. Setting the value to `now` resets the subscription's billing cycle anchor to the current time (in UTC). For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).</summary>
        [<Config.Form>]BillingCycleAnchor: Create'FeaturesSubscriptionUpdateBillingCycleAnchor option
        ///<summary>The types of subscription updates that are supported. When empty, subscriptions are not updateable.</summary>
        [<Config.Form>]DefaultAllowedUpdates: Choice<Create'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string> option
        ///<summary>Whether the feature is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of up to 10 products that support subscription updates.</summary>
        [<Config.Form>]Products: Choice<Create'FeaturesSubscriptionUpdateProducts list,string> option
        ///<summary>Determines how to handle prorations resulting from subscription updates. Valid values are `none`, `create_prorations`, and `always_invoice`.</summary>
        [<Config.Form>]ProrationBehavior: Create'FeaturesSubscriptionUpdateProrationBehavior option
        ///<summary>Setting to control when an update should be scheduled at the end of the period instead of applying immediately.</summary>
        [<Config.Form>]ScheduleAtPeriodEnd: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEnd option
        ///<summary>The behavior when updating a subscription that is trialing.</summary>
        [<Config.Form>]TrialUpdateBehavior: Create'FeaturesSubscriptionUpdateTrialUpdateBehavior option
    }
    with
        static member New(?billingCycleAnchor: Create'FeaturesSubscriptionUpdateBillingCycleAnchor, ?defaultAllowedUpdates: Choice<Create'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string>, ?enabled: bool, ?products: Choice<Create'FeaturesSubscriptionUpdateProducts list,string>, ?prorationBehavior: Create'FeaturesSubscriptionUpdateProrationBehavior, ?scheduleAtPeriodEnd: Create'FeaturesSubscriptionUpdateScheduleAtPeriodEnd, ?trialUpdateBehavior: Create'FeaturesSubscriptionUpdateTrialUpdateBehavior) =
            {
                BillingCycleAnchor = billingCycleAnchor
                DefaultAllowedUpdates = defaultAllowedUpdates
                Enabled = enabled
                Products = products
                ProrationBehavior = prorationBehavior
                ScheduleAtPeriodEnd = scheduleAtPeriodEnd
                TrialUpdateBehavior = trialUpdateBehavior
            }

    type Create'Features = {
        ///<summary>Information about updating the customer details in the portal.</summary>
        [<Config.Form>]CustomerUpdate: Create'FeaturesCustomerUpdate option
        ///<summary>Information about showing the billing history in the portal.</summary>
        [<Config.Form>]InvoiceHistory: Create'FeaturesInvoiceHistory option
        ///<summary>Information about updating payment methods in the portal.</summary>
        [<Config.Form>]PaymentMethodUpdate: Create'FeaturesPaymentMethodUpdate option
        ///<summary>Information about canceling subscriptions in the portal.</summary>
        [<Config.Form>]SubscriptionCancel: Create'FeaturesSubscriptionCancel option
        ///<summary>Information about updating subscriptions in the portal.</summary>
        [<Config.Form>]SubscriptionUpdate: Create'FeaturesSubscriptionUpdate option
    }
    with
        static member New(?customerUpdate: Create'FeaturesCustomerUpdate, ?invoiceHistory: Create'FeaturesInvoiceHistory, ?paymentMethodUpdate: Create'FeaturesPaymentMethodUpdate, ?subscriptionCancel: Create'FeaturesSubscriptionCancel, ?subscriptionUpdate: Create'FeaturesSubscriptionUpdate) =
            {
                CustomerUpdate = customerUpdate
                InvoiceHistory = invoiceHistory
                PaymentMethodUpdate = paymentMethodUpdate
                SubscriptionCancel = subscriptionCancel
                SubscriptionUpdate = subscriptionUpdate
            }

    type Create'LoginPage = {
        ///<summary>Set to `true` to generate a shareable URL [`login_page.url`](https://docs.stripe.com/api/customer_portal/configuration#portal_configuration_object-login_page-url) that will take your customers to a hosted login page for the customer portal.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type CreateOptions = {
        ///<summary>The business information shown to customers in the portal.</summary>
        [<Config.Form>]BusinessProfile: Create'BusinessProfile option
        ///<summary>The default URL to redirect customers to when they click on the portal's link to return to your website. This can be [overriden](https://docs.stripe.com/api/customer_portal/sessions/create#create_portal_session-return_url) when creating the session.</summary>
        [<Config.Form>]DefaultReturnUrl: Choice<string,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Information about the features available in the portal.</summary>
        [<Config.Form>]Features: Create'Features
        ///<summary>The hosted login page for this configuration. Learn more about the portal login page in our [integration docs](https://stripe.com/docs/billing/subscriptions/integrating-customer-portal#share).</summary>
        [<Config.Form>]LoginPage: Create'LoginPage option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The name of the configuration.</summary>
        [<Config.Form>]Name: Choice<string,string> option
    }
    with
        static member New(features: Create'Features, ?businessProfile: Create'BusinessProfile, ?defaultReturnUrl: Choice<string,string>, ?expand: string list, ?loginPage: Create'LoginPage, ?metadata: Map<string, string>, ?name: Choice<string,string>) =
            {
                BusinessProfile = businessProfile
                DefaultReturnUrl = defaultReturnUrl
                Expand = expand
                Features = features
                LoginPage = loginPage
                Metadata = metadata
                Name = name
            }

    ///<summary><p>Creates a configuration that describes the functionality and behavior of a PortalSession</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/billing_portal/configurations"
        |> RestApi.postAsync<_, BillingPortalConfiguration> settings (Map.empty) options

    type RetrieveOptions = {
        [<Config.Path>]Configuration: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(configuration: string, ?expand: string list) =
            {
                Configuration = configuration
                Expand = expand
            }

    ///<summary><p>Retrieves a configuration that describes the functionality of the customer portal.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/billing_portal/configurations/{options.Configuration}"
        |> RestApi.getAsync<BillingPortalConfiguration> settings qs

    type Update'BusinessProfile = {
        ///<summary>The messaging shown to customers in the portal.</summary>
        [<Config.Form>]Headline: Choice<string,string> option
        ///<summary>A link to the business’s publicly available privacy policy.</summary>
        [<Config.Form>]PrivacyPolicyUrl: Choice<string,string> option
        ///<summary>A link to the business’s publicly available terms of service.</summary>
        [<Config.Form>]TermsOfServiceUrl: Choice<string,string> option
    }
    with
        static member New(?headline: Choice<string,string>, ?privacyPolicyUrl: Choice<string,string>, ?termsOfServiceUrl: Choice<string,string>) =
            {
                Headline = headline
                PrivacyPolicyUrl = privacyPolicyUrl
                TermsOfServiceUrl = termsOfServiceUrl
            }

    type Update'FeaturesCustomerUpdateAllowedUpdates =
    | Address
    | Email
    | Name
    | Phone
    | Shipping
    | TaxId

    type Update'FeaturesCustomerUpdate = {
        ///<summary>The types of customer updates that are supported. When empty, customers are not updateable.</summary>
        [<Config.Form>]AllowedUpdates: Choice<Update'FeaturesCustomerUpdateAllowedUpdates list,string> option
        ///<summary>Whether the feature is enabled.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?allowedUpdates: Choice<Update'FeaturesCustomerUpdateAllowedUpdates list,string>, ?enabled: bool) =
            {
                AllowedUpdates = allowedUpdates
                Enabled = enabled
            }

    type Update'FeaturesInvoiceHistory = {
        ///<summary>Whether the feature is enabled.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type Update'FeaturesPaymentMethodUpdate = {
        ///<summary>Whether the feature is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The [Payment Method Configuration](/api/payment_method_configurations) to use for this portal session. When specified, customers will be able to update their payment method to one of the options specified by the payment method configuration. If not set or set to an empty string, the default payment method configuration is used.</summary>
        [<Config.Form>]PaymentMethodConfiguration: Choice<string,string> option
    }
    with
        static member New(?enabled: bool, ?paymentMethodConfiguration: Choice<string,string>) =
            {
                Enabled = enabled
                PaymentMethodConfiguration = paymentMethodConfiguration
            }

    type Update'FeaturesSubscriptionCancelCancellationReasonOptions =
    | CustomerService
    | LowQuality
    | MissingFeatures
    | Other
    | SwitchedService
    | TooComplex
    | TooExpensive
    | Unused

    type Update'FeaturesSubscriptionCancelCancellationReason = {
        ///<summary>Whether the feature is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Which cancellation reasons will be given as options to the customer.</summary>
        [<Config.Form>]Options: Choice<Update'FeaturesSubscriptionCancelCancellationReasonOptions list,string> option
    }
    with
        static member New(?enabled: bool, ?options: Choice<Update'FeaturesSubscriptionCancelCancellationReasonOptions list,string>) =
            {
                Enabled = enabled
                Options = options
            }

    type Update'FeaturesSubscriptionCancelMode =
    | AtPeriodEnd
    | Immediately

    type Update'FeaturesSubscriptionCancelProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type Update'FeaturesSubscriptionCancel = {
        ///<summary>Whether the cancellation reasons will be collected in the portal and which options are exposed to the customer</summary>
        [<Config.Form>]CancellationReason: Update'FeaturesSubscriptionCancelCancellationReason option
        ///<summary>Whether the feature is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>Whether to cancel subscriptions immediately or at the end of the billing period.</summary>
        [<Config.Form>]Mode: Update'FeaturesSubscriptionCancelMode option
        ///<summary>Whether to create prorations when canceling subscriptions. Possible values are `none` and `create_prorations`, which is only compatible with `mode=immediately`. Passing `always_invoice` will result in an error. No prorations are generated when canceling a subscription at the end of its natural billing period.</summary>
        [<Config.Form>]ProrationBehavior: Update'FeaturesSubscriptionCancelProrationBehavior option
    }
    with
        static member New(?cancellationReason: Update'FeaturesSubscriptionCancelCancellationReason, ?enabled: bool, ?mode: Update'FeaturesSubscriptionCancelMode, ?prorationBehavior: Update'FeaturesSubscriptionCancelProrationBehavior) =
            {
                CancellationReason = cancellationReason
                Enabled = enabled
                Mode = mode
                ProrationBehavior = prorationBehavior
            }

    type Update'FeaturesSubscriptionUpdateDefaultAllowedUpdates =
    | Price
    | PromotionCode
    | Quantity

    type Update'FeaturesSubscriptionUpdateProductsAdjustableQuantity = {
        ///<summary>Set to true if the quantity can be adjusted to any non-negative integer.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The maximum quantity that can be set for the product.</summary>
        [<Config.Form>]Maximum: int option
        ///<summary>The minimum quantity that can be set for the product.</summary>
        [<Config.Form>]Minimum: int option
    }
    with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
            }

    type Update'FeaturesSubscriptionUpdateProducts = {
        ///<summary>Control whether the quantity of the product can be adjusted.</summary>
        [<Config.Form>]AdjustableQuantity: Update'FeaturesSubscriptionUpdateProductsAdjustableQuantity option
        ///<summary>The list of price IDs for the product that a subscription can be updated to.</summary>
        [<Config.Form>]Prices: string list option
        ///<summary>The product id.</summary>
        [<Config.Form>]Product: string option
    }
    with
        static member New(?adjustableQuantity: Update'FeaturesSubscriptionUpdateProductsAdjustableQuantity, ?prices: string list, ?product: string) =
            {
                AdjustableQuantity = adjustableQuantity
                Prices = prices
                Product = product
            }

    type Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType =
    | DecreasingItemAmount
    | ShorteningInterval

    type Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions = {
        ///<summary>The type of condition.</summary>
        [<Config.Form>]Type: Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType option
    }
    with
        static member New(?type': Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditionsType) =
            {
                Type = type'
            }

    type Update'FeaturesSubscriptionUpdateScheduleAtPeriodEnd = {
        ///<summary>List of conditions. When any condition is true, the update will be scheduled at the end of the current period.</summary>
        [<Config.Form>]Conditions: Choice<Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions list,string> option
    }
    with
        static member New(?conditions: Choice<Update'FeaturesSubscriptionUpdateScheduleAtPeriodEndConditions list,string>) =
            {
                Conditions = conditions
            }

    type Update'FeaturesSubscriptionUpdateBillingCycleAnchor =
    | Now
    | Unchanged

    type Update'FeaturesSubscriptionUpdateProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type Update'FeaturesSubscriptionUpdateTrialUpdateBehavior =
    | ContinueTrial
    | EndTrial

    type Update'FeaturesSubscriptionUpdate = {
        ///<summary>Determines the value to use for the billing cycle anchor on subscription updates. Valid values are `now` or `unchanged`, and the default value is `unchanged`. Setting the value to `now` resets the subscription's billing cycle anchor to the current time (in UTC). For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).</summary>
        [<Config.Form>]BillingCycleAnchor: Update'FeaturesSubscriptionUpdateBillingCycleAnchor option
        ///<summary>The types of subscription updates that are supported. When empty, subscriptions are not updateable.</summary>
        [<Config.Form>]DefaultAllowedUpdates: Choice<Update'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string> option
        ///<summary>Whether the feature is enabled.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The list of up to 10 products that support subscription updates.</summary>
        [<Config.Form>]Products: Choice<Update'FeaturesSubscriptionUpdateProducts list,string> option
        ///<summary>Determines how to handle prorations resulting from subscription updates. Valid values are `none`, `create_prorations`, and `always_invoice`.</summary>
        [<Config.Form>]ProrationBehavior: Update'FeaturesSubscriptionUpdateProrationBehavior option
        ///<summary>Setting to control when an update should be scheduled at the end of the period instead of applying immediately.</summary>
        [<Config.Form>]ScheduleAtPeriodEnd: Update'FeaturesSubscriptionUpdateScheduleAtPeriodEnd option
        ///<summary>The behavior when updating a subscription that is trialing.</summary>
        [<Config.Form>]TrialUpdateBehavior: Update'FeaturesSubscriptionUpdateTrialUpdateBehavior option
    }
    with
        static member New(?billingCycleAnchor: Update'FeaturesSubscriptionUpdateBillingCycleAnchor, ?defaultAllowedUpdates: Choice<Update'FeaturesSubscriptionUpdateDefaultAllowedUpdates list,string>, ?enabled: bool, ?products: Choice<Update'FeaturesSubscriptionUpdateProducts list,string>, ?prorationBehavior: Update'FeaturesSubscriptionUpdateProrationBehavior, ?scheduleAtPeriodEnd: Update'FeaturesSubscriptionUpdateScheduleAtPeriodEnd, ?trialUpdateBehavior: Update'FeaturesSubscriptionUpdateTrialUpdateBehavior) =
            {
                BillingCycleAnchor = billingCycleAnchor
                DefaultAllowedUpdates = defaultAllowedUpdates
                Enabled = enabled
                Products = products
                ProrationBehavior = prorationBehavior
                ScheduleAtPeriodEnd = scheduleAtPeriodEnd
                TrialUpdateBehavior = trialUpdateBehavior
            }

    type Update'Features = {
        ///<summary>Information about updating the customer details in the portal.</summary>
        [<Config.Form>]CustomerUpdate: Update'FeaturesCustomerUpdate option
        ///<summary>Information about showing the billing history in the portal.</summary>
        [<Config.Form>]InvoiceHistory: Update'FeaturesInvoiceHistory option
        ///<summary>Information about updating payment methods in the portal.</summary>
        [<Config.Form>]PaymentMethodUpdate: Update'FeaturesPaymentMethodUpdate option
        ///<summary>Information about canceling subscriptions in the portal.</summary>
        [<Config.Form>]SubscriptionCancel: Update'FeaturesSubscriptionCancel option
        ///<summary>Information about updating subscriptions in the portal.</summary>
        [<Config.Form>]SubscriptionUpdate: Update'FeaturesSubscriptionUpdate option
    }
    with
        static member New(?customerUpdate: Update'FeaturesCustomerUpdate, ?invoiceHistory: Update'FeaturesInvoiceHistory, ?paymentMethodUpdate: Update'FeaturesPaymentMethodUpdate, ?subscriptionCancel: Update'FeaturesSubscriptionCancel, ?subscriptionUpdate: Update'FeaturesSubscriptionUpdate) =
            {
                CustomerUpdate = customerUpdate
                InvoiceHistory = invoiceHistory
                PaymentMethodUpdate = paymentMethodUpdate
                SubscriptionCancel = subscriptionCancel
                SubscriptionUpdate = subscriptionUpdate
            }

    type Update'LoginPage = {
        ///<summary>Set to `true` to generate a shareable URL [`login_page.url`](https://docs.stripe.com/api/customer_portal/configuration#portal_configuration_object-login_page-url) that will take your customers to a hosted login page for the customer portal.
        ///Set to `false` to deactivate the `login_page.url`.</summary>
        [<Config.Form>]Enabled: bool option
    }
    with
        static member New(?enabled: bool) =
            {
                Enabled = enabled
            }

    type UpdateOptions = {
        [<Config.Path>]Configuration: string
        ///<summary>Whether the configuration is active and can be used to create portal sessions.</summary>
        [<Config.Form>]Active: bool option
        ///<summary>The business information shown to customers in the portal.</summary>
        [<Config.Form>]BusinessProfile: Update'BusinessProfile option
        ///<summary>The default URL to redirect customers to when they click on the portal's link to return to your website. This can be [overriden](https://docs.stripe.com/api/customer_portal/sessions/create#create_portal_session-return_url) when creating the session.</summary>
        [<Config.Form>]DefaultReturnUrl: Choice<string,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Information about the features available in the portal.</summary>
        [<Config.Form>]Features: Update'Features option
        ///<summary>The hosted login page for this configuration. Learn more about the portal login page in our [integration docs](https://stripe.com/docs/billing/subscriptions/integrating-customer-portal#share).</summary>
        [<Config.Form>]LoginPage: Update'LoginPage option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The name of the configuration.</summary>
        [<Config.Form>]Name: Choice<string,string> option
    }
    with
        static member New(configuration: string, ?active: bool, ?businessProfile: Update'BusinessProfile, ?defaultReturnUrl: Choice<string,string>, ?expand: string list, ?features: Update'Features, ?loginPage: Update'LoginPage, ?metadata: Map<string, string>, ?name: Choice<string,string>) =
            {
                Configuration = configuration
                Active = active
                BusinessProfile = businessProfile
                DefaultReturnUrl = defaultReturnUrl
                Expand = expand
                Features = features
                LoginPage = loginPage
                Metadata = metadata
                Name = name
            }

    ///<summary><p>Updates a configuration that describes the functionality of the customer portal.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/billing_portal/configurations/{options.Configuration}"
        |> RestApi.postAsync<_, BillingPortalConfiguration> settings (Map.empty) options

module BillingPortalSessions =

    type Create'FlowDataAfterCompletionHostedConfirmation = {
        ///<summary>A custom message to display to the customer after the flow is completed.</summary>
        [<Config.Form>]CustomMessage: string option
    }
    with
        static member New(?customMessage: string) =
            {
                CustomMessage = customMessage
            }

    type Create'FlowDataAfterCompletionRedirect = {
        ///<summary>The URL the customer will be redirected to after the flow is completed.</summary>
        [<Config.Form>]ReturnUrl: string option
    }
    with
        static member New(?returnUrl: string) =
            {
                ReturnUrl = returnUrl
            }

    type Create'FlowDataAfterCompletionType =
    | HostedConfirmation
    | PortalHomepage
    | Redirect

    type Create'FlowDataAfterCompletion = {
        ///<summary>Configuration when `after_completion.type=hosted_confirmation`.</summary>
        [<Config.Form>]HostedConfirmation: Create'FlowDataAfterCompletionHostedConfirmation option
        ///<summary>Configuration when `after_completion.type=redirect`.</summary>
        [<Config.Form>]Redirect: Create'FlowDataAfterCompletionRedirect option
        ///<summary>The specified behavior after the flow is completed.</summary>
        [<Config.Form>]Type: Create'FlowDataAfterCompletionType option
    }
    with
        static member New(?hostedConfirmation: Create'FlowDataAfterCompletionHostedConfirmation, ?redirect: Create'FlowDataAfterCompletionRedirect, ?type': Create'FlowDataAfterCompletionType) =
            {
                HostedConfirmation = hostedConfirmation
                Redirect = redirect
                Type = type'
            }

    type Create'FlowDataSubscriptionCancelRetentionCouponOffer = {
        ///<summary>The ID of the coupon to be offered.</summary>
        [<Config.Form>]Coupon: string option
    }
    with
        static member New(?coupon: string) =
            {
                Coupon = coupon
            }

    type Create'FlowDataSubscriptionCancelRetentionType =
    | CouponOffer

    type Create'FlowDataSubscriptionCancelRetention = {
        ///<summary>Configuration when `retention.type=coupon_offer`.</summary>
        [<Config.Form>]CouponOffer: Create'FlowDataSubscriptionCancelRetentionCouponOffer option
        ///<summary>Type of retention strategy to use with the customer.</summary>
        [<Config.Form>]Type: Create'FlowDataSubscriptionCancelRetentionType option
    }
    with
        static member New(?couponOffer: Create'FlowDataSubscriptionCancelRetentionCouponOffer, ?type': Create'FlowDataSubscriptionCancelRetentionType) =
            {
                CouponOffer = couponOffer
                Type = type'
            }

    type Create'FlowDataSubscriptionCancel = {
        ///<summary>Specify a retention strategy to be used in the cancellation flow.</summary>
        [<Config.Form>]Retention: Create'FlowDataSubscriptionCancelRetention option
        ///<summary>The ID of the subscription to be canceled.</summary>
        [<Config.Form>]Subscription: string option
    }
    with
        static member New(?retention: Create'FlowDataSubscriptionCancelRetention, ?subscription: string) =
            {
                Retention = retention
                Subscription = subscription
            }

    type Create'FlowDataSubscriptionUpdate = {
        ///<summary>The ID of the subscription to be updated.</summary>
        [<Config.Form>]Subscription: string option
    }
    with
        static member New(?subscription: string) =
            {
                Subscription = subscription
            }

    type Create'FlowDataSubscriptionUpdateConfirmDiscounts = {
        ///<summary>The ID of the coupon to apply to this subscription update.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>The ID of a promotion code to apply to this subscription update.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?promotionCode: string) =
            {
                Coupon = coupon
                PromotionCode = promotionCode
            }

    type Create'FlowDataSubscriptionUpdateConfirmItems = {
        ///<summary>The ID of the [subscription item](https://docs.stripe.com/api/subscriptions/object#subscription_object-items-data-id) to be updated.</summary>
        [<Config.Form>]Id: string option
        ///<summary>The price the customer should subscribe to through this flow. The price must also be included in the configuration's [`features.subscription_update.products`](https://docs.stripe.com/api/customer_portal/configuration#portal_configuration_object-features-subscription_update-products).</summary>
        [<Config.Form>]Price: string option
        ///<summary>[Quantity](https://docs.stripe.com/subscriptions/quantities) for this item that the customer should subscribe to through this flow.</summary>
        [<Config.Form>]Quantity: int option
    }
    with
        static member New(?id: string, ?price: string, ?quantity: int) =
            {
                Id = id
                Price = price
                Quantity = quantity
            }

    type Create'FlowDataSubscriptionUpdateConfirm = {
        ///<summary>The coupon or promotion code to apply to this subscription update.</summary>
        [<Config.Form>]Discounts: Create'FlowDataSubscriptionUpdateConfirmDiscounts list option
        ///<summary>The [subscription item](https://docs.stripe.com/api/subscription_items) to be updated through this flow. Currently, only up to one may be specified and subscriptions with multiple items are not updatable.</summary>
        [<Config.Form>]Items: Create'FlowDataSubscriptionUpdateConfirmItems list option
        ///<summary>The ID of the subscription to be updated.</summary>
        [<Config.Form>]Subscription: string option
    }
    with
        static member New(?discounts: Create'FlowDataSubscriptionUpdateConfirmDiscounts list, ?items: Create'FlowDataSubscriptionUpdateConfirmItems list, ?subscription: string) =
            {
                Discounts = discounts
                Items = items
                Subscription = subscription
            }

    type Create'FlowDataType =
    | PaymentMethodUpdate
    | SubscriptionCancel
    | SubscriptionUpdate
    | SubscriptionUpdateConfirm

    type Create'FlowData = {
        ///<summary>Behavior after the flow is completed.</summary>
        [<Config.Form>]AfterCompletion: Create'FlowDataAfterCompletion option
        ///<summary>Configuration when `flow_data.type=subscription_cancel`.</summary>
        [<Config.Form>]SubscriptionCancel: Create'FlowDataSubscriptionCancel option
        ///<summary>Configuration when `flow_data.type=subscription_update`.</summary>
        [<Config.Form>]SubscriptionUpdate: Create'FlowDataSubscriptionUpdate option
        ///<summary>Configuration when `flow_data.type=subscription_update_confirm`.</summary>
        [<Config.Form>]SubscriptionUpdateConfirm: Create'FlowDataSubscriptionUpdateConfirm option
        ///<summary>Type of flow that the customer will go through.</summary>
        [<Config.Form>]Type: Create'FlowDataType option
    }
    with
        static member New(?afterCompletion: Create'FlowDataAfterCompletion, ?subscriptionCancel: Create'FlowDataSubscriptionCancel, ?subscriptionUpdate: Create'FlowDataSubscriptionUpdate, ?subscriptionUpdateConfirm: Create'FlowDataSubscriptionUpdateConfirm, ?type': Create'FlowDataType) =
            {
                AfterCompletion = afterCompletion
                SubscriptionCancel = subscriptionCancel
                SubscriptionUpdate = subscriptionUpdate
                SubscriptionUpdateConfirm = subscriptionUpdateConfirm
                Type = type'
            }

    type Create'Locale =
    | Auto
    | Bg
    | Cs
    | Da
    | De
    | El
    | En
    | [<JsonPropertyName("en-AU")>] EnAU
    | [<JsonPropertyName("en-CA")>] EnCA
    | [<JsonPropertyName("en-GB")>] EnGB
    | [<JsonPropertyName("en-IE")>] EnIE
    | [<JsonPropertyName("en-IN")>] EnIN
    | [<JsonPropertyName("en-NZ")>] EnNZ
    | [<JsonPropertyName("en-SG")>] EnSG
    | Es
    | [<JsonPropertyName("es-419")>] Es419
    | Et
    | Fi
    | Fil
    | Fr
    | [<JsonPropertyName("fr-CA")>] FrCA
    | Hr
    | Hu
    | Id
    | It
    | Ja
    | Ko
    | Lt
    | Lv
    | Ms
    | Mt
    | Nb
    | Nl
    | Pl
    | Pt
    | [<JsonPropertyName("pt-BR")>] PtBR
    | Ro
    | Ru
    | Sk
    | Sl
    | Sv
    | Th
    | Tr
    | Vi
    | Zh
    | [<JsonPropertyName("zh-HK")>] ZhHK
    | [<JsonPropertyName("zh-TW")>] ZhTW

    type CreateOptions = {
        ///<summary>The ID of an existing [configuration](https://docs.stripe.com/api/customer_portal/configurations) to use for this session, describing its functionality and features. If not specified, the session uses the default configuration.</summary>
        [<Config.Form>]Configuration: string option
        ///<summary>The ID of an existing customer.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>The ID of an existing account.</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Information about a specific flow for the customer to go through. See the [docs](https://docs.stripe.com/customer-management/portal-deep-links) to learn more about using customer portal deep links and flows.</summary>
        [<Config.Form>]FlowData: Create'FlowData option
        ///<summary>The IETF language tag of the locale customer portal is displayed in. If blank or auto, the customer’s `preferred_locales` or browser’s locale is used.</summary>
        [<Config.Form>]Locale: Create'Locale option
        ///<summary>The `on_behalf_of` account to use for this session. When specified, only subscriptions and invoices with this `on_behalf_of` account appear in the portal. For more information, see the [docs](https://docs.stripe.com/connect/separate-charges-and-transfers#settlement-merchant). Use the [Accounts API](https://docs.stripe.com/api/accounts/object#account_object-settings-branding) to modify the `on_behalf_of` account's branding settings, which the portal displays.</summary>
        [<Config.Form>]OnBehalfOf: string option
        ///<summary>The default URL to redirect customers to when they click on the portal's link to return to your website.</summary>
        [<Config.Form>]ReturnUrl: string option
    }
    with
        static member New(?configuration: string, ?customer: string, ?customerAccount: string, ?expand: string list, ?flowData: Create'FlowData, ?locale: Create'Locale, ?onBehalfOf: string, ?returnUrl: string) =
            {
                Configuration = configuration
                Customer = customer
                CustomerAccount = customerAccount
                Expand = expand
                FlowData = flowData
                Locale = locale
                OnBehalfOf = onBehalfOf
                ReturnUrl = returnUrl
            }

    ///<summary><p>Creates a session of the customer portal.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/billing_portal/sessions"
        |> RestApi.postAsync<_, BillingPortalSession> settings (Map.empty) options

module Coupons =

    type ListOptions = {
        ///<summary>A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.</summary>
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
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of your coupons.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/coupons"
        |> RestApi.getAsync<StripeList<Coupon>> settings qs

    type Create'AppliesTo = {
        ///<summary>An array of Product IDs that this Coupon will apply to.</summary>
        [<Config.Form>]Products: string list option
    }
    with
        static member New(?products: string list) =
            {
                Products = products
            }

    type Create'Duration =
    | Forever
    | Once
    | Repeating

    type CreateOptions = {
        ///<summary>A positive integer representing the amount to subtract from an invoice total (required if `percent_off` is not passed).</summary>
        [<Config.Form>]AmountOff: int option
        ///<summary>A hash containing directions for what this Coupon will apply discounts to.</summary>
        [<Config.Form>]AppliesTo: Create'AppliesTo option
        ///<summary>Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) of the `amount_off` parameter (required if `amount_off` is passed).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>Coupons defined in each available currency option (only supported if `amount_off` is passed). Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]CurrencyOptions: Map<string, string> option
        ///<summary>Specifies how long the discount will be in effect if used on a subscription. Defaults to `once`.</summary>
        [<Config.Form>]Duration: Create'Duration option
        ///<summary>Required only if `duration` is `repeating`, in which case it must be a positive integer that specifies the number of months the discount will be in effect.</summary>
        [<Config.Form>]DurationInMonths: int option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Unique string of your choice that will be used to identify this coupon when applying it to a customer. If you don't want to specify a particular code, you can leave the ID blank and we'll generate a random code for you.</summary>
        [<Config.Form>]Id: string option
        ///<summary>A positive integer specifying the number of times the coupon can be redeemed before it's no longer valid. For example, you might have a 50% off coupon that the first 20 readers of your blog can use.</summary>
        [<Config.Form>]MaxRedemptions: int option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Name of the coupon displayed to customers on, for instance invoices, or receipts. By default the `id` is shown if `name` is not set.</summary>
        [<Config.Form>]Name: string option
        ///<summary>A positive float larger than 0, and smaller or equal to 100, that represents the discount the coupon will apply (required if `amount_off` is not passed).</summary>
        [<Config.Form>]PercentOff: decimal option
        ///<summary>Unix timestamp specifying the last time at which the coupon can be redeemed (cannot be set to more than 5 years in the future). After the redeem_by date, the coupon can no longer be applied to new customers.</summary>
        [<Config.Form>]RedeemBy: DateTime option
    }
    with
        static member New(?amountOff: int, ?appliesTo: Create'AppliesTo, ?currency: IsoTypes.IsoCurrencyCode, ?currencyOptions: Map<string, string>, ?duration: Create'Duration, ?durationInMonths: int, ?expand: string list, ?id: string, ?maxRedemptions: int, ?metadata: Map<string, string>, ?name: string, ?percentOff: decimal, ?redeemBy: DateTime) =
            {
                AmountOff = amountOff
                AppliesTo = appliesTo
                Currency = currency
                CurrencyOptions = currencyOptions
                Duration = duration
                DurationInMonths = durationInMonths
                Expand = expand
                Id = id
                MaxRedemptions = maxRedemptions
                Metadata = metadata
                Name = name
                PercentOff = percentOff
                RedeemBy = redeemBy
            }

    ///<summary><p>You can create coupons easily via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. Coupon creation is also accessible via the API if you need to create coupons on the fly.</p>
    ///<p>A coupon has either a <code>percent_off</code> or an <code>amount_off</code> and <code>currency</code>. If you set an <code>amount_off</code>, that amount will be subtracted from any invoice’s subtotal. For example, an invoice with a subtotal of <currency>100</currency> will have a final total of <currency>0</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it and an invoice with a subtotal of <currency>300</currency> will have a final total of <currency>100</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/coupons"
        |> RestApi.postAsync<_, Coupon> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Coupon: string
    }
    with
        static member New(coupon: string) =
            {
                Coupon = coupon
            }

    ///<summary><p>You can delete coupons via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. However, deleting a coupon does not affect any customers who have already applied the coupon; it means that new customers can’t redeem the coupon. You can also delete coupons via the API.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/coupons/{options.Coupon}"
        |> RestApi.deleteAsync<DeletedCoupon> settings (Map.empty)

    type RetrieveOptions = {
        [<Config.Path>]Coupon: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(coupon: string, ?expand: string list) =
            {
                Coupon = coupon
                Expand = expand
            }

    ///<summary><p>Retrieves the coupon with the given ID.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/coupons/{options.Coupon}"
        |> RestApi.getAsync<Coupon> settings qs

    type UpdateOptions = {
        [<Config.Path>]Coupon: string
        ///<summary>Coupons defined in each available currency option (only supported if the coupon is amount-based). Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]CurrencyOptions: Map<string, string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Name of the coupon displayed to customers on, for instance invoices, or receipts. By default the `id` is shown if `name` is not set.</summary>
        [<Config.Form>]Name: string option
    }
    with
        static member New(coupon: string, ?currencyOptions: Map<string, string>, ?expand: string list, ?metadata: Map<string, string>, ?name: string) =
            {
                Coupon = coupon
                CurrencyOptions = currencyOptions
                Expand = expand
                Metadata = metadata
                Name = name
            }

    ///<summary><p>Updates the metadata of a coupon. Other coupon details (currency, duration, amount_off) are, by design, not editable.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/coupons/{options.Coupon}"
        |> RestApi.postAsync<_, Coupon> settings (Map.empty) options

module CreditNotes =

    type ListOptions = {
        ///<summary>Only return credit notes that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>Only return credit notes for the customer specified by this customer ID.</summary>
        [<Config.Query>]Customer: string option
        ///<summary>Only return credit notes for the account representing the customer specified by this account ID.</summary>
        [<Config.Query>]CustomerAccount: string option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Only return credit notes for the invoice specified by this invoice ID.</summary>
        [<Config.Query>]Invoice: string option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?created: int, ?customer: string, ?customerAccount: string, ?endingBefore: string, ?expand: string list, ?invoice: string, ?limit: int, ?startingAfter: string) =
            {
                Created = created
                Customer = customer
                CustomerAccount = customerAccount
                EndingBefore = endingBefore
                Expand = expand
                Invoice = invoice
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of credit notes.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/credit_notes"
        |> RestApi.getAsync<StripeList<CreditNote>> settings qs

    type Create'LinesTaxAmounts = {
        ///<summary>The amount, in cents (or local equivalent), of the tax.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>The id of the tax rate for this tax amount. The tax rate must have been automatically created by Stripe.</summary>
        [<Config.Form>]TaxRate: string option
        ///<summary>The amount on which tax is calculated, in cents (or local equivalent).</summary>
        [<Config.Form>]TaxableAmount: int option
    }
    with
        static member New(?amount: int, ?taxRate: string, ?taxableAmount: int) =
            {
                Amount = amount
                TaxRate = taxRate
                TaxableAmount = taxableAmount
            }

    type Create'LinesType =
    | CustomLineItem
    | InvoiceLineItem

    type Create'Lines = {
        ///<summary>The line item amount to credit. Only valid when `type` is `invoice_line_item`. If invoice is set up with `automatic_tax[enabled]=true`, this amount is tax exclusive</summary>
        [<Config.Form>]Amount: int option
        ///<summary>The description of the credit note line item. Only valid when the `type` is `custom_line_item`.</summary>
        [<Config.Form>]Description: string option
        ///<summary>The invoice line item to credit. Only valid when the `type` is `invoice_line_item`.</summary>
        [<Config.Form>]InvoiceLineItem: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The line item quantity to credit.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>A list of up to 10 tax amounts for the credit note line item. Not valid when `tax_rates` is used or if invoice is set up with `automatic_tax[enabled]=true`.</summary>
        [<Config.Form>]TaxAmounts: Choice<Create'LinesTaxAmounts list,string> option
        ///<summary>The tax rates which apply to the credit note line item. Only valid when the `type` is `custom_line_item` and `tax_amounts` is not used.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
        ///<summary>Type of the credit note line item, one of `invoice_line_item` or `custom_line_item`. `custom_line_item` is not valid when the invoice is set up with `automatic_tax[enabled]=true`.</summary>
        [<Config.Form>]Type: Create'LinesType option
        ///<summary>The integer unit amount in cents (or local equivalent) of the credit note line item. This `unit_amount` will be multiplied by the quantity to get the full amount to credit for this line item. Only valid when `type` is `custom_line_item`.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?amount: int, ?description: string, ?invoiceLineItem: string, ?metadata: Map<string, string>, ?quantity: int, ?taxAmounts: Choice<Create'LinesTaxAmounts list,string>, ?taxRates: Choice<string list,string>, ?type': Create'LinesType, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Amount = amount
                Description = description
                InvoiceLineItem = invoiceLineItem
                Metadata = metadata
                Quantity = quantity
                TaxAmounts = taxAmounts
                TaxRates = taxRates
                Type = type'
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'RefundsPaymentRecordRefund = {
        ///<summary>The ID of the PaymentRecord with the refund to link to this credit note.</summary>
        [<Config.Form>]PaymentRecord: string option
        ///<summary>The PaymentRecord refund group to link to this credit note. For refunds processed off-Stripe, this will correspond to the `processor_details.custom.refund_reference` field provided when reporting the refund on the PaymentRecord.</summary>
        [<Config.Form>]RefundGroup: string option
    }
    with
        static member New(?paymentRecord: string, ?refundGroup: string) =
            {
                PaymentRecord = paymentRecord
                RefundGroup = refundGroup
            }

    type Create'RefundsType =
    | PaymentRecordRefund
    | Refund

    type Create'Refunds = {
        ///<summary>Amount of the refund that applies to this credit note, in cents (or local equivalent). Defaults to the entire refund amount.</summary>
        [<Config.Form>]AmountRefunded: int option
        ///<summary>The PaymentRecord refund details to link to this credit note. Required when `type` is `payment_record_refund`.</summary>
        [<Config.Form>]PaymentRecordRefund: Create'RefundsPaymentRecordRefund option
        ///<summary>ID of an existing refund to link this credit note to. Required when `type` is `refund`.</summary>
        [<Config.Form>]Refund: string option
        ///<summary>Type of the refund, one of `refund` or `payment_record_refund`. Defaults to `refund`.</summary>
        [<Config.Form>]Type: Create'RefundsType option
    }
    with
        static member New(?amountRefunded: int, ?paymentRecordRefund: Create'RefundsPaymentRecordRefund, ?refund: string, ?type': Create'RefundsType) =
            {
                AmountRefunded = amountRefunded
                PaymentRecordRefund = paymentRecordRefund
                Refund = refund
                Type = type'
            }

    type Create'ShippingCost = {
        ///<summary>The ID of the shipping rate to use for this order.</summary>
        [<Config.Form>]ShippingRate: string option
    }
    with
        static member New(?shippingRate: string) =
            {
                ShippingRate = shippingRate
            }

    type Create'EmailType =
    | CreditNote
    | None'

    type Create'Reason =
    | Duplicate
    | Fraudulent
    | OrderChange
    | ProductUnsatisfactory

    type CreateOptions = {
        ///<summary>The integer amount in cents (or local equivalent) representing the total amount of the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>The integer amount in cents (or local equivalent) representing the amount to credit the customer's balance, which will be automatically applied to their next invoice.</summary>
        [<Config.Form>]CreditAmount: int option
        ///<summary>The date when this credit note is in effect. Same as `created` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the credit note PDF.</summary>
        [<Config.Form>]EffectiveAt: DateTime option
        ///<summary>Type of email to send to the customer, one of `credit_note` or `none` and the default is `credit_note`.</summary>
        [<Config.Form>]EmailType: Create'EmailType option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>ID of the invoice.</summary>
        [<Config.Form>]Invoice: string
        ///<summary>Line items that make up the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.</summary>
        [<Config.Form>]Lines: Create'Lines list option
        ///<summary>The credit note's memo appears on the credit note PDF.</summary>
        [<Config.Form>]Memo: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The integer amount in cents (or local equivalent) representing the amount that is credited outside of Stripe.</summary>
        [<Config.Form>]OutOfBandAmount: int option
        ///<summary>Reason for issuing this credit note, one of `duplicate`, `fraudulent`, `order_change`, or `product_unsatisfactory`</summary>
        [<Config.Form>]Reason: Create'Reason option
        ///<summary>The integer amount in cents (or local equivalent) representing the amount to refund. If set, a refund will be created for the charge associated with the invoice.</summary>
        [<Config.Form>]RefundAmount: int option
        ///<summary>Refunds to link to this credit note.</summary>
        [<Config.Form>]Refunds: Create'Refunds list option
        ///<summary>When shipping_cost contains the shipping_rate from the invoice, the shipping_cost is included in the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.</summary>
        [<Config.Form>]ShippingCost: Create'ShippingCost option
    }
    with
        static member New(invoice: string, ?amount: int, ?creditAmount: int, ?effectiveAt: DateTime, ?emailType: Create'EmailType, ?expand: string list, ?lines: Create'Lines list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: Create'Reason, ?refundAmount: int, ?refunds: Create'Refunds list, ?shippingCost: Create'ShippingCost) =
            {
                Amount = amount
                CreditAmount = creditAmount
                EffectiveAt = effectiveAt
                EmailType = emailType
                Expand = expand
                Invoice = invoice
                Lines = lines
                Memo = memo
                Metadata = metadata
                OutOfBandAmount = outOfBandAmount
                Reason = reason
                RefundAmount = refundAmount
                Refunds = refunds
                ShippingCost = shippingCost
            }

    ///<summary><p>Issue a credit note to adjust the amount of a finalized invoice. A credit note will first reduce the invoice’s <code>amount_remaining</code> (and <code>amount_due</code>), but not below zero.
    ///This amount is indicated by the credit note’s <code>pre_payment_amount</code>. The excess amount is indicated by <code>post_payment_amount</code>, and it can result in any combination of the following:</p>
    ///<ul>
    ///<li>Refunds: create a new refund (using <code>refund_amount</code>) or link existing refunds (using <code>refunds</code>).</li>
    ///<li>Customer balance credit: credit the customer’s balance (using <code>credit_amount</code>) which will be automatically applied to their next invoice when it’s finalized.</li>
    ///<li>Outside of Stripe credit: record the amount that is or will be credited outside of Stripe (using <code>out_of_band_amount</code>).</li>
    ///</ul>
    ///<p>The sum of refunds, customer balance credits, and outside of Stripe credits must equal the <code>post_payment_amount</code>.</p>
    ///<p>You may issue multiple credit notes for an invoice. Each credit note may increment the invoice’s <code>pre_payment_credit_notes_amount</code>,
    ///<code>post_payment_credit_notes_amount</code>, or both, depending on the invoice’s <code>amount_remaining</code> at the time of credit note creation.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/credit_notes"
        |> RestApi.postAsync<_, CreditNote> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves the credit note object with the given identifier.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/credit_notes/{options.Id}"
        |> RestApi.getAsync<CreditNote> settings qs

    type UpdateOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Credit note memo.</summary>
        [<Config.Form>]Memo: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
    }
    with
        static member New(id: string, ?expand: string list, ?memo: string, ?metadata: Map<string, string>) =
            {
                Id = id
                Expand = expand
                Memo = memo
                Metadata = metadata
            }

    ///<summary><p>Updates an existing credit note.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/credit_notes/{options.Id}"
        |> RestApi.postAsync<_, CreditNote> settings (Map.empty) options

module CreditNotesPreview =

    type PreviewOptions = {
        ///<summary>The integer amount in cents (or local equivalent) representing the total amount of the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.</summary>
        [<Config.Query>]Amount: int option
        ///<summary>The integer amount in cents (or local equivalent) representing the amount to credit the customer's balance, which will be automatically applied to their next invoice.</summary>
        [<Config.Query>]CreditAmount: int option
        ///<summary>The date when this credit note is in effect. Same as `created` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the credit note PDF.</summary>
        [<Config.Query>]EffectiveAt: int option
        ///<summary>Type of email to send to the customer, one of `credit_note` or `none` and the default is `credit_note`.</summary>
        [<Config.Query>]EmailType: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>ID of the invoice.</summary>
        [<Config.Query>]Invoice: string
        ///<summary>Line items that make up the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.</summary>
        [<Config.Query>]Lines: string list option
        ///<summary>The credit note's memo appears on the credit note PDF.</summary>
        [<Config.Query>]Memo: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Query>]Metadata: Map<string, string> option
        ///<summary>The integer amount in cents (or local equivalent) representing the amount that is credited outside of Stripe.</summary>
        [<Config.Query>]OutOfBandAmount: int option
        ///<summary>Reason for issuing this credit note, one of `duplicate`, `fraudulent`, `order_change`, or `product_unsatisfactory`</summary>
        [<Config.Query>]Reason: string option
        ///<summary>The integer amount in cents (or local equivalent) representing the amount to refund. If set, a refund will be created for the charge associated with the invoice.</summary>
        [<Config.Query>]RefundAmount: int option
        ///<summary>Refunds to link to this credit note.</summary>
        [<Config.Query>]Refunds: string list option
        ///<summary>When shipping_cost contains the shipping_rate from the invoice, the shipping_cost is included in the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.</summary>
        [<Config.Query>]ShippingCost: Map<string, string> option
    }
    with
        static member New(invoice: string, ?amount: int, ?creditAmount: int, ?effectiveAt: int, ?emailType: string, ?expand: string list, ?lines: string list, ?memo: string, ?metadata: Map<string, string>, ?outOfBandAmount: int, ?reason: string, ?refundAmount: int, ?refunds: string list, ?shippingCost: Map<string, string>) =
            {
                Amount = amount
                CreditAmount = creditAmount
                EffectiveAt = effectiveAt
                EmailType = emailType
                Expand = expand
                Invoice = invoice
                Lines = lines
                Memo = memo
                Metadata = metadata
                OutOfBandAmount = outOfBandAmount
                Reason = reason
                RefundAmount = refundAmount
                Refunds = refunds
                ShippingCost = shippingCost
            }

    ///<summary><p>Get a preview of a credit note without creating it.</p></summary>
    let Preview settings (options: PreviewOptions) =
        let qs = [("amount", options.Amount |> box); ("credit_amount", options.CreditAmount |> box); ("effective_at", options.EffectiveAt |> box); ("email_type", options.EmailType |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("lines", options.Lines |> box); ("memo", options.Memo |> box); ("metadata", options.Metadata |> box); ("out_of_band_amount", options.OutOfBandAmount |> box); ("reason", options.Reason |> box); ("refund_amount", options.RefundAmount |> box); ("refunds", options.Refunds |> box); ("shipping_cost", options.ShippingCost |> box)] |> Map.ofList
        $"/v1/credit_notes/preview"
        |> RestApi.getAsync<CreditNote> settings qs

module CreditNotesPreviewLines =

    type PreviewLinesOptions = {
        ///<summary>The integer amount in cents (or local equivalent) representing the total amount of the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.</summary>
        [<Config.Query>]Amount: int option
        ///<summary>The integer amount in cents (or local equivalent) representing the amount to credit the customer's balance, which will be automatically applied to their next invoice.</summary>
        [<Config.Query>]CreditAmount: int option
        ///<summary>The date when this credit note is in effect. Same as `created` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the credit note PDF.</summary>
        [<Config.Query>]EffectiveAt: int option
        ///<summary>Type of email to send to the customer, one of `credit_note` or `none` and the default is `credit_note`.</summary>
        [<Config.Query>]EmailType: string option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>ID of the invoice.</summary>
        [<Config.Query>]Invoice: string
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Line items that make up the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.</summary>
        [<Config.Query>]Lines: string list option
        ///<summary>The credit note's memo appears on the credit note PDF.</summary>
        [<Config.Query>]Memo: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Query>]Metadata: Map<string, string> option
        ///<summary>The integer amount in cents (or local equivalent) representing the amount that is credited outside of Stripe.</summary>
        [<Config.Query>]OutOfBandAmount: int option
        ///<summary>Reason for issuing this credit note, one of `duplicate`, `fraudulent`, `order_change`, or `product_unsatisfactory`</summary>
        [<Config.Query>]Reason: string option
        ///<summary>The integer amount in cents (or local equivalent) representing the amount to refund. If set, a refund will be created for the charge associated with the invoice.</summary>
        [<Config.Query>]RefundAmount: int option
        ///<summary>Refunds to link to this credit note.</summary>
        [<Config.Query>]Refunds: string list option
        ///<summary>When shipping_cost contains the shipping_rate from the invoice, the shipping_cost is included in the credit note. One of `amount`, `lines`, or `shipping_cost` must be provided.</summary>
        [<Config.Query>]ShippingCost: Map<string, string> option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(invoice: string, ?amount: int, ?refunds: string list, ?refundAmount: int, ?reason: string, ?outOfBandAmount: int, ?metadata: Map<string, string>, ?memo: string, ?lines: string list, ?limit: int, ?expand: string list, ?endingBefore: string, ?emailType: string, ?effectiveAt: int, ?creditAmount: int, ?shippingCost: Map<string, string>, ?startingAfter: string) =
            {
                Amount = amount
                CreditAmount = creditAmount
                EffectiveAt = effectiveAt
                EmailType = emailType
                EndingBefore = endingBefore
                Expand = expand
                Invoice = invoice
                Limit = limit
                Lines = lines
                Memo = memo
                Metadata = metadata
                OutOfBandAmount = outOfBandAmount
                Reason = reason
                RefundAmount = refundAmount
                Refunds = refunds
                ShippingCost = shippingCost
                StartingAfter = startingAfter
            }

    ///<summary><p>When retrieving a credit note preview, you’ll get a <strong>lines</strong> property containing the first handful of those items. This URL you can retrieve the full (paginated) list of line items.</p></summary>
    let PreviewLines settings (options: PreviewLinesOptions) =
        let qs = [("amount", options.Amount |> box); ("credit_amount", options.CreditAmount |> box); ("effective_at", options.EffectiveAt |> box); ("email_type", options.EmailType |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("lines", options.Lines |> box); ("memo", options.Memo |> box); ("metadata", options.Metadata |> box); ("out_of_band_amount", options.OutOfBandAmount |> box); ("reason", options.Reason |> box); ("refund_amount", options.RefundAmount |> box); ("refunds", options.Refunds |> box); ("shipping_cost", options.ShippingCost |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/credit_notes/preview/lines"
        |> RestApi.getAsync<StripeList<CreditNoteLineItem>> settings qs

module CreditNotesLines =

    type ListOptions = {
        [<Config.Path>]CreditNote: string
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
        static member New(creditNote: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                CreditNote = creditNote
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>When retrieving a credit note, you’ll get a <strong>lines</strong> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/credit_notes/{options.CreditNote}/lines"
        |> RestApi.getAsync<StripeList<CreditNoteLineItem>> settings qs

module CreditNotesVoid =

    type VoidCreditNoteOptions = {
        [<Config.Path>]Id: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Id = id
                Expand = expand
            }

    ///<summary><p>Marks a credit note as void. Learn more about <a href="/docs/billing/invoices/credit-notes#voiding">voiding credit notes</a>.</p></summary>
    let VoidCreditNote settings (options: VoidCreditNoteOptions) =
        $"/v1/credit_notes/{options.Id}/void"
        |> RestApi.postAsync<_, CreditNote> settings (Map.empty) options

module InvoicePayments =

    type ListOptions = {
        ///<summary>Only return invoice payments that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>The identifier of the invoice whose payments to return.</summary>
        [<Config.Query>]Invoice: string option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>The payment details of the invoice payments to return.</summary>
        [<Config.Query>]Payment: Map<string, string> option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>The status of the invoice payments to return.</summary>
        [<Config.Query>]Status: string option
    }
    with
        static member New(?created: int, ?endingBefore: string, ?expand: string list, ?invoice: string, ?limit: int, ?payment: Map<string, string>, ?startingAfter: string, ?status: string) =
            {
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Invoice = invoice
                Limit = limit
                Payment = payment
                StartingAfter = startingAfter
                Status = status
            }

    ///<summary><p>When retrieving an invoice, there is an includable payments property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of payments.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("payment", options.Payment |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/invoice_payments"
        |> RestApi.getAsync<StripeList<InvoicePayment>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]InvoicePayment: string
    }
    with
        static member New(invoicePayment: string, ?expand: string list) =
            {
                Expand = expand
                InvoicePayment = invoicePayment
            }

    ///<summary><p>Retrieves the invoice payment with the given ID.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/invoice_payments/{options.InvoicePayment}"
        |> RestApi.getAsync<InvoicePayment> settings qs

module InvoiceRenderingTemplates =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        [<Config.Query>]Status: string option
    }
    with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    ///<summary><p>List all templates, ordered by creation date, with the most recently created template appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/invoice_rendering_templates"
        |> RestApi.getAsync<StripeList<InvoiceRenderingTemplate>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Template: string
        [<Config.Query>]Version: int option
    }
    with
        static member New(template: string, ?expand: string list, ?version: int) =
            {
                Expand = expand
                Template = template
                Version = version
            }

    ///<summary><p>Retrieves an invoice rendering template with the given ID. It by default returns the latest version of the template. Optionally, specify a version to see previous versions.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box); ("version", options.Version |> box)] |> Map.ofList
        $"/v1/invoice_rendering_templates/{options.Template}"
        |> RestApi.getAsync<InvoiceRenderingTemplate> settings qs

module InvoiceRenderingTemplatesArchive =

    type ArchiveOptions = {
        [<Config.Path>]Template: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(template: string, ?expand: string list) =
            {
                Template = template
                Expand = expand
            }

    ///<summary><p>Updates the status of an invoice rendering template to ‘archived’ so no new Stripe objects (customers, invoices, etc.) can reference it. The template can also no longer be updated. However, if the template is already set on a Stripe object, it will continue to be applied on invoices generated by it.</p></summary>
    let Archive settings (options: ArchiveOptions) =
        $"/v1/invoice_rendering_templates/{options.Template}/archive"
        |> RestApi.postAsync<_, InvoiceRenderingTemplate> settings (Map.empty) options

module InvoiceRenderingTemplatesUnarchive =

    type UnarchiveOptions = {
        [<Config.Path>]Template: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(template: string, ?expand: string list) =
            {
                Template = template
                Expand = expand
            }

    ///<summary><p>Unarchive an invoice rendering template so it can be used on new Stripe objects again.</p></summary>
    let Unarchive settings (options: UnarchiveOptions) =
        $"/v1/invoice_rendering_templates/{options.Template}/unarchive"
        |> RestApi.postAsync<_, InvoiceRenderingTemplate> settings (Map.empty) options

module Invoiceitems =

    type ListOptions = {
        ///<summary>Only return invoice items that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>The identifier of the customer whose invoice items to return. If none is provided, returns all invoice items.</summary>
        [<Config.Query>]Customer: string option
        ///<summary>The identifier of the account representing the customer whose invoice items to return. If none is provided, returns all invoice items.</summary>
        [<Config.Query>]CustomerAccount: string option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Only return invoice items belonging to this invoice. If none is provided, all invoice items will be returned. If specifying an invoice, no customer identifier is needed.</summary>
        [<Config.Query>]Invoice: string option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Set to `true` to only show pending invoice items, which are not yet attached to any invoices. Set to `false` to only show invoice items already attached to invoices. If unspecified, no filter is applied.</summary>
        [<Config.Query>]Pending: bool option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?created: int, ?customer: string, ?customerAccount: string, ?endingBefore: string, ?expand: string list, ?invoice: string, ?limit: int, ?pending: bool, ?startingAfter: string) =
            {
                Created = created
                Customer = customer
                CustomerAccount = customerAccount
                EndingBefore = endingBefore
                Expand = expand
                Invoice = invoice
                Limit = limit
                Pending = pending
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of your invoice items. Invoice items are returned sorted by creation date, with the most recently created invoice items appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("invoice", options.Invoice |> box); ("limit", options.Limit |> box); ("pending", options.Pending |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/invoiceitems"
        |> RestApi.getAsync<StripeList<Invoiceitem>> settings qs

    type Create'Discounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Create'Period = {
        ///<summary>The end of the period, which must be greater than or equal to the start. This value is inclusive.</summary>
        [<Config.Form>]End: DateTime option
        ///<summary>The start of the period. This value is inclusive.</summary>
        [<Config.Form>]Start: DateTime option
    }
    with
        static member New(?end': DateTime, ?start: DateTime) =
            {
                End = end'
                Start = start
            }

    type Create'PriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'PriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Create'PriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?taxBehavior: Create'PriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'Pricing = {
        ///<summary>The ID of the price object.</summary>
        [<Config.Form>]Price: string option
    }
    with
        static member New(?price: string) =
            {
                Price = price
            }

    type Create'TaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type CreateOptions = {
        ///<summary>The integer amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. Passing in a negative `amount` will reduce the `amount_due` on the invoice.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the customer to bill for this invoice item.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>The ID of the account representing the customer to bill for this invoice item.</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Controls whether discounts apply to this invoice item. Defaults to false for prorations or negative invoice items, and true for all other invoice items.</summary>
        [<Config.Form>]Discountable: bool option
        ///<summary>The coupons and promotion codes to redeem into discounts for the invoice item or invoice line item.</summary>
        [<Config.Form>]Discounts: Choice<Create'Discounts list,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The ID of an existing invoice to add this invoice item to. For subscription invoices, when left blank, the invoice item will be added to the next upcoming scheduled invoice. For standalone invoices, the invoice item won't be automatically added unless you pass `pending_invoice_item_behavior: 'include'` when creating the invoice. This is useful when adding invoice items in response to an invoice.created webhook. You can only add invoice items to draft invoices and there is a maximum of 250 items per invoice.</summary>
        [<Config.Form>]Invoice: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://docs.stripe.com/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://docs.stripe.com/revenue-recognition/methodology/subscriptions-and-invoicing) for details.</summary>
        [<Config.Form>]Period: Create'Period option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.</summary>
        [<Config.Form>]PriceData: Create'PriceData option
        ///<summary>The pricing information for the invoice item.</summary>
        [<Config.Form>]Pricing: Create'Pricing option
        ///<summary>Non-negative integer. The quantity of units for the invoice item. Use `quantity_decimal` instead to provide decimal precision. This field will be deprecated in favor of `quantity_decimal` in a future version.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>Non-negative decimal with at most 12 decimal places. The quantity of units for the invoice item.</summary>
        [<Config.Form>]QuantityDecimal: string option
        ///<summary>The ID of a subscription to add this invoice item to. When left blank, the invoice item is added to the next upcoming scheduled invoice. When set, scheduled invoices for subscriptions other than the specified subscription will ignore the invoice item. Use this when you want to express that an invoice item has been accrued within the context of a particular subscription.</summary>
        [<Config.Form>]Subscription: string option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Create'TaxBehavior option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID.</summary>
        [<Config.Form>]TaxCode: Choice<string,string> option
        ///<summary>The tax rates which apply to the invoice item. When set, the `default_tax_rates` on the invoice do not apply to this invoice item.</summary>
        [<Config.Form>]TaxRates: string list option
        ///<summary>The decimal unit amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. This `unit_amount_decimal` will be multiplied by the quantity to get the full amount. Passing in a negative `unit_amount_decimal` will reduce the `amount_due` on the invoice. Accepts at most 12 decimal places.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?amount: int, ?taxCode: Choice<string,string>, ?taxBehavior: Create'TaxBehavior, ?subscription: string, ?quantityDecimal: string, ?quantity: int, ?pricing: Create'Pricing, ?priceData: Create'PriceData, ?period: Create'Period, ?metadata: Map<string, string>, ?invoice: string, ?expand: string list, ?discounts: Choice<Create'Discounts list,string>, ?discountable: bool, ?description: string, ?customerAccount: string, ?customer: string, ?currency: IsoTypes.IsoCurrencyCode, ?taxRates: string list, ?unitAmountDecimal: string) =
            {
                Amount = amount
                Currency = currency
                Customer = customer
                CustomerAccount = customerAccount
                Description = description
                Discountable = discountable
                Discounts = discounts
                Expand = expand
                Invoice = invoice
                Metadata = metadata
                Period = period
                PriceData = priceData
                Pricing = pricing
                Quantity = quantity
                QuantityDecimal = quantityDecimal
                Subscription = subscription
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                TaxRates = taxRates
                UnitAmountDecimal = unitAmountDecimal
            }

    ///<summary><p>Creates an item to be added to a draft invoice (up to 250 items per invoice). If no invoice is specified, the item will be on the next invoice created for the customer specified.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/invoiceitems"
        |> RestApi.postAsync<_, Invoiceitem> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Invoiceitem: string
    }
    with
        static member New(invoiceitem: string) =
            {
                Invoiceitem = invoiceitem
            }

    ///<summary><p>Deletes an invoice item, removing it from an invoice. Deleting invoice items is only possible when they’re not attached to invoices, or if it’s attached to a draft invoice.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/invoiceitems/{options.Invoiceitem}"
        |> RestApi.deleteAsync<DeletedInvoiceitem> settings (Map.empty)

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Invoiceitem: string
    }
    with
        static member New(invoiceitem: string, ?expand: string list) =
            {
                Expand = expand
                Invoiceitem = invoiceitem
            }

    ///<summary><p>Retrieves the invoice item with the given ID.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/invoiceitems/{options.Invoiceitem}"
        |> RestApi.getAsync<Invoiceitem> settings qs

    type Update'Discounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'Period = {
        ///<summary>The end of the period, which must be greater than or equal to the start. This value is inclusive.</summary>
        [<Config.Form>]End: DateTime option
        ///<summary>The start of the period. This value is inclusive.</summary>
        [<Config.Form>]Start: DateTime option
    }
    with
        static member New(?end': DateTime, ?start: DateTime) =
            {
                End = end'
                Start = start
            }

    type Update'PriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'PriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Update'PriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?taxBehavior: Update'PriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'Pricing = {
        ///<summary>The ID of the price object.</summary>
        [<Config.Form>]Price: string option
    }
    with
        static member New(?price: string) =
            {
                Price = price
            }

    type Update'TaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type UpdateOptions = {
        [<Config.Path>]Invoiceitem: string
        ///<summary>The integer amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. If you want to apply a credit to the customer's account, pass a negative amount.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Controls whether discounts apply to this invoice item. Defaults to false for prorations or negative invoice items, and true for all other invoice items. Cannot be set to true for prorations.</summary>
        [<Config.Form>]Discountable: bool option
        ///<summary>The coupons, promotion codes & existing discounts which apply to the invoice item or invoice line item. Item discounts are applied before invoice discounts. Pass an empty string to remove previously-defined discounts.</summary>
        [<Config.Form>]Discounts: Choice<Update'Discounts list,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://docs.stripe.com/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://docs.stripe.com/revenue-recognition/methodology/subscriptions-and-invoicing) for details.</summary>
        [<Config.Form>]Period: Update'Period option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.</summary>
        [<Config.Form>]PriceData: Update'PriceData option
        ///<summary>The pricing information for the invoice item.</summary>
        [<Config.Form>]Pricing: Update'Pricing option
        ///<summary>Non-negative integer. The quantity of units for the invoice item. Use `quantity_decimal` instead to provide decimal precision. This field will be deprecated in favor of `quantity_decimal` in a future version.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>Non-negative decimal with at most 12 decimal places. The quantity of units for the line item.</summary>
        [<Config.Form>]QuantityDecimal: string option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Update'TaxBehavior option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID.</summary>
        [<Config.Form>]TaxCode: Choice<string,string> option
        ///<summary>The tax rates which apply to the invoice item. When set, the `default_tax_rates` on the invoice do not apply to this invoice item. Pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
        ///<summary>The decimal unit amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. This `unit_amount_decimal` will be multiplied by the quantity to get the full amount. Passing in a negative `unit_amount_decimal` will reduce the `amount_due` on the invoice. Accepts at most 12 decimal places.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(invoiceitem: string, ?amount: int, ?description: string, ?discountable: bool, ?discounts: Choice<Update'Discounts list,string>, ?expand: string list, ?metadata: Map<string, string>, ?period: Update'Period, ?priceData: Update'PriceData, ?pricing: Update'Pricing, ?quantity: int, ?quantityDecimal: string, ?taxBehavior: Update'TaxBehavior, ?taxCode: Choice<string,string>, ?taxRates: Choice<string list,string>, ?unitAmountDecimal: string) =
            {
                Invoiceitem = invoiceitem
                Amount = amount
                Description = description
                Discountable = discountable
                Discounts = discounts
                Expand = expand
                Metadata = metadata
                Period = period
                PriceData = priceData
                Pricing = pricing
                Quantity = quantity
                QuantityDecimal = quantityDecimal
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                TaxRates = taxRates
                UnitAmountDecimal = unitAmountDecimal
            }

    ///<summary><p>Updates the amount or description of an invoice item on an upcoming invoice. Updating an invoice item is only possible before the invoice it’s attached to is closed.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/invoiceitems/{options.Invoiceitem}"
        |> RestApi.postAsync<_, Invoiceitem> settings (Map.empty) options

module Invoices =

    type ListOptions = {
        ///<summary>The collection method of the invoice to retrieve. Either `charge_automatically` or `send_invoice`.</summary>
        [<Config.Query>]CollectionMethod: string option
        ///<summary>Only return invoices that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>Only return invoices for the customer specified by this customer ID.</summary>
        [<Config.Query>]Customer: string option
        ///<summary>Only return invoices for the account representing the customer specified by this account ID.</summary>
        [<Config.Query>]CustomerAccount: string option
        [<Config.Query>]DueDate: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>The status of the invoice, one of `draft`, `open`, `paid`, `uncollectible`, or `void`. [Learn more](https://docs.stripe.com/billing/invoices/workflow#workflow-overview)</summary>
        [<Config.Query>]Status: string option
        ///<summary>Only return invoices for the subscription specified by this subscription ID.</summary>
        [<Config.Query>]Subscription: string option
    }
    with
        static member New(?collectionMethod: string, ?created: int, ?customer: string, ?customerAccount: string, ?dueDate: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string, ?subscription: string) =
            {
                CollectionMethod = collectionMethod
                Created = created
                Customer = customer
                CustomerAccount = customerAccount
                DueDate = dueDate
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
                Subscription = subscription
            }

    ///<summary><p>You can list all invoices, or list the invoices for a specific customer. The invoices are returned sorted by creation date, with the most recently created invoices appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("collection_method", options.CollectionMethod |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("due_date", options.DueDate |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("subscription", options.Subscription |> box)] |> Map.ofList
        $"/v1/invoices"
        |> RestApi.getAsync<StripeList<Invoice>> settings qs

    type Create'AutomaticTaxLiabilityType =
    | Account
    | Self

    type Create'AutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Create'AutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': Create'AutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Create'AutomaticTax = {
        ///<summary>Whether Stripe automatically computes tax on this invoice. Note that incompatible invoice items (invoice items with manually specified [tax rates](https://docs.stripe.com/api/tax_rates), negative amounts, or `tax_behavior=unspecified`) cannot be added to automatic tax invoices.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: Create'AutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: Create'AutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Create'CustomFields = {
        ///<summary>The name of the custom field. This may be up to 40 characters.</summary>
        [<Config.Form>]Name: string option
        ///<summary>The value of the custom field. This may be up to 140 characters.</summary>
        [<Config.Form>]Value: string option
    }
    with
        static member New(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Create'Discounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Create'FromInvoiceAction =
    | Revision

    type Create'FromInvoice = {
        ///<summary>The relation between the new invoice and the original invoice. Currently, only 'revision' is permitted</summary>
        [<Config.Form>]Action: Create'FromInvoiceAction option
        ///<summary>The `id` of the invoice that will be cloned.</summary>
        [<Config.Form>]Invoice: string option
    }
    with
        static member New(?action: Create'FromInvoiceAction, ?invoice: string) =
            {
                Action = action
                Invoice = invoice
            }

    type Create'IssuerType =
    | Account
    | Self

    type Create'Issuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Create'IssuerType option
    }
    with
        static member New(?account: string, ?type': Create'IssuerType) =
            {
                Account = account
                Type = type'
            }

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType =
    | Business
    | Personal

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions = {
        ///<summary>Transaction type of the mandate.</summary>
        [<Config.Form>]TransactionType: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
    }
    with
        static member New(?transactionType: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType) =
            {
                TransactionType = transactionType
            }

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions = {
        ///<summary>Additional fields for Mandate creation</summary>
        [<Config.Form>]MandateOptions: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option
        ///<summary>Verification method for the intent</summary>
        [<Config.Form>]VerificationMethod: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions, ?verificationMethod: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod) =
            {
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Fr
    | Nl

    type Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions = {
        ///<summary>Preferred language of the Bancontact authorization page that the customer is redirected to.</summary>
        [<Config.Form>]PreferredLanguage: Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
    }
    with
        static member New(?preferredLanguage: Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval =
    | Month

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType =
    | Bonus
    | FixedCount
    | Revolving

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan = {
        ///<summary>For `fixed_count` installment plans, this is required. It represents the number of installment payments your customer will make to their credit card.</summary>
        [<Config.Form>]Count: int option
        ///<summary>For `fixed_count` installment plans, this is required. It represents the interval between installment payments your customer will make to their credit card.
        ///One of `month`.</summary>
        [<Config.Form>]Interval: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval option
        ///<summary>Type of installment plan, one of `fixed_count`, `bonus`, or `revolving`.</summary>
        [<Config.Form>]Type: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType option
    }
    with
        static member New(?count: int, ?interval: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval, ?type': Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType) =
            {
                Count = count
                Interval = interval
                Type = type'
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments = {
        ///<summary>Setting to true enables installments for this invoice.
        ///Setting to false will prevent any selected plan from applying to a payment.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The selected installment plan to use for this invoice.</summary>
        [<Config.Form>]Plan: Choice<Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan,string> option
    }
    with
        static member New(?enabled: bool, ?plan: Choice<Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan,string>) =
            {
                Enabled = enabled
                Plan = plan
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure =
    | Any
    | Automatic
    | Challenge

    type Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions = {
        ///<summary>Installment configuration for payments attempted on this invoice.
        ///For more information, see the [installments integration guide](https://docs.stripe.com/payments/installments).</summary>
        [<Config.Form>]Installments: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments option
        ///<summary>We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.</summary>
        [<Config.Form>]RequestThreeDSecure: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure option
    }
    with
        static member New(?installments: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments, ?requestThreeDSecure: Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure) =
            {
                Installments = installments
                RequestThreeDSecure = requestThreeDSecure
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer = {
        ///<summary>The desired country code of the bank account information. Permitted values include: `DE`, `FR`, `IE`, or `NL`.</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
    }
    with
        static member New(?country: IsoTypes.IsoCountryCode) =
            {
                Country = country
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer = {
        ///<summary>Configuration for eu_bank_transfer funding type.</summary>
        [<Config.Form>]EuBankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option
        ///<summary>The bank transfer type that can be used for funding. Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.</summary>
        [<Config.Form>]Type: string option
    }
    with
        static member New(?euBankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer, ?type': string) =
            {
                EuBankTransfer = euBankTransfer
                Type = type'
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions = {
        ///<summary>Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.</summary>
        [<Config.Form>]BankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option
        ///<summary>The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.</summary>
        [<Config.Form>]FundingType: string option
    }
    with
        static member New(?bankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer, ?fundingType: string) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
            }

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose =
    | DependantSupport
    | Government
    | Loan
    | Mortgage
    | Other
    | Pension
    | Personal
    | Retail
    | Salary
    | Tax
    | Utility

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions = {
        ///<summary>The maximum amount that can be collected in a single invoice. If you don't specify a maximum, then there is no limit.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>The purpose for which payments are made. Has a default value based on your merchant category code.</summary>
        [<Config.Form>]Purpose: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose option
    }
    with
        static member New(?amount: int, ?purpose: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose) =
            {
                Amount = amount
                Purpose = purpose
            }

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions = {
        ///<summary>Additional fields for Mandate creation.</summary>
        [<Config.Form>]MandateOptions: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions option
    }
    with
        static member New(?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Create'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptionsAmountIncludesIof =
    | Always
    | Never

    type Create'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions = {
        ///<summary>Determines if the amount includes the IOF tax. Defaults to `never`.</summary>
        [<Config.Form>]AmountIncludesIof: Create'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptionsAmountIncludesIof option
        ///<summary>The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.</summary>
        [<Config.Form>]ExpiresAfterSeconds: int option
    }
    with
        static member New(?amountIncludesIof: Create'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptionsAmountIncludesIof, ?expiresAfterSeconds: int) =
            {
                AmountIncludesIof = amountIncludesIof
                ExpiresAfterSeconds = expiresAfterSeconds
            }

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions = {
        ///<summary>Amount to be charged for future payments.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.</summary>
        [<Config.Form>]AmountType: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType option
        ///<summary>A description of the mandate or subscription that is meant to be displayed to the customer.</summary>
        [<Config.Form>]Description: string option
        ///<summary>End date of the mandate or subscription.</summary>
        [<Config.Form>]EndDate: DateTime option
    }
    with
        static member New(?amount: int, ?amountType: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions = {
        ///<summary>Configuration options for setting up an eMandate</summary>
        [<Config.Form>]MandateOptions: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions option
    }
    with
        static member New(?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories =
    | Checking
    | Savings

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters = {
        ///<summary>The account subcategories to use to filter for selectable accounts. Valid subcategories are `checking` and `savings`.</summary>
        [<Config.Form>]AccountSubcategories: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list option
    }
    with
        static member New(?accountSubcategories: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list) =
            {
                AccountSubcategories = accountSubcategories
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch =
    | Balances
    | Ownership
    | Transactions

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections = {
        ///<summary>Provide filters for the linked accounts that the customer can select for the payment method.</summary>
        [<Config.Form>]Filters: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters option
        ///<summary>The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.</summary>
        [<Config.Form>]Permissions: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option
        ///<summary>List of data features that you would like to retrieve upon account creation.</summary>
        [<Config.Form>]Prefetch: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
    }
    with
        static member New(?filters: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters, ?permissions: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list, ?prefetch: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list) =
            {
                Filters = filters
                Permissions = permissions
                Prefetch = prefetch
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions = {
        ///<summary>Additional fields for Financial Connections Session creation</summary>
        [<Config.Form>]FinancialConnections: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option
        ///<summary>Verification method for the intent</summary>
        [<Config.Form>]VerificationMethod: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?financialConnections: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections, ?verificationMethod: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod) =
            {
                FinancialConnections = financialConnections
                VerificationMethod = verificationMethod
            }

    type Create'PaymentSettingsPaymentMethodOptions = {
        ///<summary>If paying by `acss_debit`, this sub-hash contains details about the Canadian pre-authorized debit payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]AcssDebit: Choice<Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `bancontact`, this sub-hash contains details about the Bancontact payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Bancontact: Choice<Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `card`, this sub-hash contains details about the Card payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Card: Choice<Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `customer_balance`, this sub-hash contains details about the Bank transfer payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]CustomerBalance: Choice<Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `konbini`, this sub-hash contains details about the Konbini payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Konbini: Choice<string,string> option
        ///<summary>If paying by `payto`, this sub-hash contains details about the PayTo payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Payto: Choice<Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `pix`, this sub-hash contains details about the Pix payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Pix: Choice<Create'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `sepa_debit`, this sub-hash contains details about the SEPA Direct Debit payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]SepaDebit: Choice<string,string> option
        ///<summary>If paying by `upi`, this sub-hash contains details about the UPI payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Upi: Choice<Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `us_bank_account`, this sub-hash contains details about the ACH direct debit payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]UsBankAccount: Choice<Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
    }
    with
        static member New(?acssDebit: Choice<Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string>, ?bancontact: Choice<Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string>, ?card: Choice<Create'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions,string>, ?customerBalance: Choice<Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string>, ?konbini: Choice<string,string>, ?payto: Choice<Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string>, ?pix: Choice<Create'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions,string>, ?sepaDebit: Choice<string,string>, ?upi: Choice<Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string>, ?usBankAccount: Choice<Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string>) =
            {
                AcssDebit = acssDebit
                Bancontact = bancontact
                Card = card
                CustomerBalance = customerBalance
                Konbini = konbini
                Payto = payto
                Pix = pix
                SepaDebit = sepaDebit
                Upi = upi
                UsBankAccount = usBankAccount
            }

    type Create'PaymentSettingsPaymentMethodTypes =
    | AchCreditTransfer
    | AchDebit
    | AcssDebit
    | Affirm
    | AmazonPay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Boleto
    | Card
    | Cashapp
    | Crypto
    | Custom
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | JpCreditTransfer
    | KakaoPay
    | Klarna
    | Konbini
    | KrCard
    | Link
    | Multibanco
    | NaverPay
    | NzBankAccount
    | P24
    | PayByBank
    | Payco
    | Paynow
    | Paypal
    | Payto
    | Pix
    | Promptpay
    | RevolutPay
    | SepaCreditTransfer
    | SepaDebit
    | Sofort
    | Swish
    | Upi
    | UsBankAccount
    | WechatPay

    type Create'PaymentSettings = {
        ///<summary>ID of the mandate to be used for this invoice. It must correspond to the payment method used to pay the invoice, including the invoice's default_payment_method or default_source, if set.</summary>
        [<Config.Form>]DefaultMandate: Choice<string,string> option
        ///<summary>Payment-method-specific configuration to provide to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]PaymentMethodOptions: Create'PaymentSettingsPaymentMethodOptions option
        ///<summary>The list of payment method types (e.g. card) to provide to the invoice’s PaymentIntent. If not set, Stripe attempts to automatically determine the types to use by looking at the invoice’s default payment method, the subscription’s default payment method, the customer’s default payment method, and your [invoice template settings](https://dashboard.stripe.com/settings/billing/invoice).</summary>
        [<Config.Form>]PaymentMethodTypes: Choice<Create'PaymentSettingsPaymentMethodTypes list,string> option
    }
    with
        static member New(?defaultMandate: Choice<string,string>, ?paymentMethodOptions: Create'PaymentSettingsPaymentMethodOptions, ?paymentMethodTypes: Choice<Create'PaymentSettingsPaymentMethodTypes list,string>) =
            {
                DefaultMandate = defaultMandate
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
            }

    type Create'RenderingPdfPageSize =
    | A4
    | Auto
    | Letter

    type Create'RenderingPdf = {
        ///<summary>Page size for invoice PDF. Can be set to `a4`, `letter`, or `auto`.
        /// If set to `auto`, invoice PDF page size defaults to `a4` for customers with
        /// Japanese locale and `letter` for customers with other locales.</summary>
        [<Config.Form>]PageSize: Create'RenderingPdfPageSize option
    }
    with
        static member New(?pageSize: Create'RenderingPdfPageSize) =
            {
                PageSize = pageSize
            }

    type Create'RenderingAmountTaxDisplay =
    | ExcludeTax
    | IncludeInclusiveTax

    type Create'Rendering = {
        ///<summary>How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.</summary>
        [<Config.Form>]AmountTaxDisplay: Create'RenderingAmountTaxDisplay option
        ///<summary>Invoice pdf rendering options</summary>
        [<Config.Form>]Pdf: Create'RenderingPdf option
        ///<summary>ID of the invoice rendering template to use for this invoice.</summary>
        [<Config.Form>]Template: string option
        ///<summary>The specific version of invoice rendering template to use for this invoice.</summary>
        [<Config.Form>]TemplateVersion: Choice<int,string> option
    }
    with
        static member New(?amountTaxDisplay: Create'RenderingAmountTaxDisplay, ?pdf: Create'RenderingPdf, ?template: string, ?templateVersion: Choice<int,string>) =
            {
                AmountTaxDisplay = amountTaxDisplay
                Pdf = pdf
                Template = template
                TemplateVersion = templateVersion
            }

    type Create'ShippingCostShippingRateDataDeliveryEstimateMaximumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Create'ShippingCostShippingRateDataDeliveryEstimateMaximum = {
        ///<summary>A unit of time.</summary>
        [<Config.Form>]Unit: Create'ShippingCostShippingRateDataDeliveryEstimateMaximumUnit option
        ///<summary>Must be greater than 0.</summary>
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Create'ShippingCostShippingRateDataDeliveryEstimateMaximumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'ShippingCostShippingRateDataDeliveryEstimateMinimumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Create'ShippingCostShippingRateDataDeliveryEstimateMinimum = {
        ///<summary>A unit of time.</summary>
        [<Config.Form>]Unit: Create'ShippingCostShippingRateDataDeliveryEstimateMinimumUnit option
        ///<summary>Must be greater than 0.</summary>
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Create'ShippingCostShippingRateDataDeliveryEstimateMinimumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'ShippingCostShippingRateDataDeliveryEstimate = {
        ///<summary>The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.</summary>
        [<Config.Form>]Maximum: Create'ShippingCostShippingRateDataDeliveryEstimateMaximum option
        ///<summary>The lower bound of the estimated range. If empty, represents no lower bound.</summary>
        [<Config.Form>]Minimum: Create'ShippingCostShippingRateDataDeliveryEstimateMinimum option
    }
    with
        static member New(?maximum: Create'ShippingCostShippingRateDataDeliveryEstimateMaximum, ?minimum: Create'ShippingCostShippingRateDataDeliveryEstimateMinimum) =
            {
                Maximum = maximum
                Minimum = minimum
            }

    type Create'ShippingCostShippingRateDataFixedAmount = {
        ///<summary>A non-negative integer in cents representing how much to charge.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]CurrencyOptions: Map<string, string> option
    }
    with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode, ?currencyOptions: Map<string, string>) =
            {
                Amount = amount
                Currency = currency
                CurrencyOptions = currencyOptions
            }

    type Create'ShippingCostShippingRateDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'ShippingCostShippingRateDataType =
    | FixedAmount

    type Create'ShippingCostShippingRateData = {
        ///<summary>The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.</summary>
        [<Config.Form>]DeliveryEstimate: Create'ShippingCostShippingRateDataDeliveryEstimate option
        ///<summary>The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.</summary>
        [<Config.Form>]DisplayName: string option
        ///<summary>Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.</summary>
        [<Config.Form>]FixedAmount: Create'ShippingCostShippingRateDataFixedAmount option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.</summary>
        [<Config.Form>]TaxBehavior: Create'ShippingCostShippingRateDataTaxBehavior option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.</summary>
        [<Config.Form>]TaxCode: string option
        ///<summary>The type of calculation to use on the shipping rate.</summary>
        [<Config.Form>]Type: Create'ShippingCostShippingRateDataType option
    }
    with
        static member New(?deliveryEstimate: Create'ShippingCostShippingRateDataDeliveryEstimate, ?displayName: string, ?fixedAmount: Create'ShippingCostShippingRateDataFixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Create'ShippingCostShippingRateDataTaxBehavior, ?taxCode: string, ?type': Create'ShippingCostShippingRateDataType) =
            {
                DeliveryEstimate = deliveryEstimate
                DisplayName = displayName
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                Type = type'
            }

    type Create'ShippingCost = {
        ///<summary>The ID of the shipping rate to use for this order.</summary>
        [<Config.Form>]ShippingRate: string option
        ///<summary>Parameters to create a new ad-hoc shipping rate for this order.</summary>
        [<Config.Form>]ShippingRateData: Create'ShippingCostShippingRateData option
    }
    with
        static member New(?shippingRate: string, ?shippingRateData: Create'ShippingCostShippingRateData) =
            {
                ShippingRate = shippingRate
                ShippingRateData = shippingRateData
            }

    type Create'ShippingDetailsAddress = {
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

    type Create'ShippingDetails = {
        ///<summary>Shipping address</summary>
        [<Config.Form>]Address: Create'ShippingDetailsAddress option
        ///<summary>Recipient name.</summary>
        [<Config.Form>]Name: string option
        ///<summary>Recipient phone (including extension)</summary>
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Create'ShippingDetailsAddress, ?name: string, ?phone: Choice<string,string>) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Create'TransferData = {
        ///<summary>The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>ID of an existing, connected Stripe account.</summary>
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type Create'CollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Create'PendingInvoiceItemsBehavior =
    | Exclude
    | Include

    type CreateOptions = {
        ///<summary>The account tax IDs associated with the invoice. Only editable when the invoice is a draft.</summary>
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///<summary>A fee in cents (or local equivalent) that will be applied to the invoice and transferred to the application owner's Stripe account. The request must be made with an OAuth key or the Stripe-Account header in order to take an application fee. For more information, see the application fees [documentation](https://docs.stripe.com/billing/invoices/connect#collecting-fees).</summary>
        [<Config.Form>]ApplicationFeeAmount: int option
        ///<summary>Controls whether Stripe performs [automatic collection](https://docs.stripe.com/invoicing/integration/automatic-advancement-collection) of the invoice. If `false`, the invoice's state doesn't automatically advance without an explicit action. Defaults to false.</summary>
        [<Config.Form>]AutoAdvance: bool option
        ///<summary>Settings for automatic tax lookup for this invoice.</summary>
        [<Config.Form>]AutomaticTax: Create'AutomaticTax option
        ///<summary>The time when this invoice should be scheduled to finalize (up to 5 years in the future). The invoice is finalized at this time if it's still in draft state.</summary>
        [<Config.Form>]AutomaticallyFinalizesAt: DateTime option
        ///<summary>Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this invoice using the default source attached to the customer. When sending an invoice, Stripe will email this invoice to the customer with payment instructions. Defaults to `charge_automatically`.</summary>
        [<Config.Form>]CollectionMethod: Create'CollectionMethod option
        ///<summary>The currency to create this invoice in. Defaults to that of `customer` if not specified.</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>A list of up to 4 custom fields to be displayed on the invoice.</summary>
        [<Config.Form>]CustomFields: Choice<Create'CustomFields list,string> option
        ///<summary>The ID of the customer to bill.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>The ID of the account to bill.</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>The number of days from when the invoice is created until it is due. Valid only for invoices where `collection_method=send_invoice`.</summary>
        [<Config.Form>]DaysUntilDue: int option
        ///<summary>ID of the default payment method for the invoice. It must belong to the customer associated with the invoice. If not set, defaults to the subscription's default payment method, if any, or to the default payment method in the customer's invoice settings.</summary>
        [<Config.Form>]DefaultPaymentMethod: string option
        ///<summary>ID of the default payment source for the invoice. It must belong to the customer associated with the invoice and be in a chargeable state. If not set, defaults to the subscription's default source, if any, or to the customer's default source.</summary>
        [<Config.Form>]DefaultSource: string option
        ///<summary>The tax rates that will apply to any line item that does not have `tax_rates` set.</summary>
        [<Config.Form>]DefaultTaxRates: string list option
        ///<summary>An arbitrary string attached to the object. Often useful for displaying to users. Referenced as 'memo' in the Dashboard.</summary>
        [<Config.Form>]Description: string option
        ///<summary>The coupons and promotion codes to redeem into discounts for the invoice. If not specified, inherits the discount from the invoice's customer. Pass an empty string to avoid inheriting any discounts.</summary>
        [<Config.Form>]Discounts: Choice<Create'Discounts list,string> option
        ///<summary>The date on which payment for this invoice is due. Valid only for invoices where `collection_method=send_invoice`.</summary>
        [<Config.Form>]DueDate: DateTime option
        ///<summary>The date when this invoice is in effect. Same as `finalized_at` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the invoice PDF and receipt.</summary>
        [<Config.Form>]EffectiveAt: DateTime option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Footer to be displayed on the invoice.</summary>
        [<Config.Form>]Footer: string option
        ///<summary>Revise an existing invoice. The new invoice will be created in `status=draft`. See the [revision documentation](https://docs.stripe.com/invoicing/invoice-revisions) for more details.</summary>
        [<Config.Form>]FromInvoice: Create'FromInvoice option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Create'Issuer option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Set the number for this invoice. If no number is present then a number will be assigned automatically when the invoice is finalized. In many markets, regulations require invoices to be unique, sequential and / or gapless. You are responsible for ensuring this is true across all your different invoicing systems in the event that you edit the invoice number using our API. If you use only Stripe for your invoices and do not change invoice numbers, Stripe handles this aspect of compliance for you automatically.</summary>
        [<Config.Form>]Number: string option
        ///<summary>The account (if any) for which the funds of the invoice payment are intended. If set, the invoice will be presented with the branding and support information of the specified account. See the [Invoices with Connect](https://docs.stripe.com/billing/invoices/connect) documentation for details.</summary>
        [<Config.Form>]OnBehalfOf: string option
        ///<summary>Configuration settings for the PaymentIntent that is generated when the invoice is finalized.</summary>
        [<Config.Form>]PaymentSettings: Create'PaymentSettings option
        ///<summary>How to handle pending invoice items on invoice creation. Defaults to `exclude` if the parameter is omitted.</summary>
        [<Config.Form>]PendingInvoiceItemsBehavior: Create'PendingInvoiceItemsBehavior option
        ///<summary>The rendering-related settings that control how the invoice is displayed on customer-facing surfaces such as PDF and Hosted Invoice Page.</summary>
        [<Config.Form>]Rendering: Create'Rendering option
        ///<summary>Settings for the cost of shipping for this invoice.</summary>
        [<Config.Form>]ShippingCost: Create'ShippingCost option
        ///<summary>Shipping details for the invoice. The Invoice PDF will use the `shipping_details` value if it is set, otherwise the PDF will render the shipping address from the customer.</summary>
        [<Config.Form>]ShippingDetails: Create'ShippingDetails option
        ///<summary>Extra information about a charge for the customer's credit card statement. It must contain at least one letter. If not specified and this invoice is part of a subscription, the default `statement_descriptor` will be set to the first subscription item's product's `statement_descriptor`.</summary>
        [<Config.Form>]StatementDescriptor: string option
        ///<summary>The ID of the subscription to invoice, if any. If set, the created invoice will only include pending invoice items for that subscription. The subscription's billing cycle and regular subscription events won't be affected.</summary>
        [<Config.Form>]Subscription: string option
        ///<summary>If specified, the funds from the invoice will be transferred to the destination and the ID of the resulting transfer will be found on the invoice's charge.</summary>
        [<Config.Form>]TransferData: Create'TransferData option
    }
    with
        static member New(?accountTaxIds: Choice<string list,string>, ?statementDescriptor: string, ?shippingDetails: Create'ShippingDetails, ?shippingCost: Create'ShippingCost, ?rendering: Create'Rendering, ?pendingInvoiceItemsBehavior: Create'PendingInvoiceItemsBehavior, ?paymentSettings: Create'PaymentSettings, ?onBehalfOf: string, ?number: string, ?metadata: Map<string, string>, ?issuer: Create'Issuer, ?fromInvoice: Create'FromInvoice, ?footer: string, ?expand: string list, ?effectiveAt: DateTime, ?subscription: string, ?dueDate: DateTime, ?description: string, ?defaultTaxRates: string list, ?defaultSource: string, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?customerAccount: string, ?customer: string, ?customFields: Choice<Create'CustomFields list,string>, ?currency: IsoTypes.IsoCurrencyCode, ?collectionMethod: Create'CollectionMethod, ?automaticallyFinalizesAt: DateTime, ?automaticTax: Create'AutomaticTax, ?autoAdvance: bool, ?applicationFeeAmount: int, ?discounts: Choice<Create'Discounts list,string>, ?transferData: Create'TransferData) =
            {
                AccountTaxIds = accountTaxIds
                ApplicationFeeAmount = applicationFeeAmount
                AutoAdvance = autoAdvance
                AutomaticTax = automaticTax
                AutomaticallyFinalizesAt = automaticallyFinalizesAt
                CollectionMethod = collectionMethod
                Currency = currency
                CustomFields = customFields
                Customer = customer
                CustomerAccount = customerAccount
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                DueDate = dueDate
                EffectiveAt = effectiveAt
                Expand = expand
                Footer = footer
                FromInvoice = fromInvoice
                Issuer = issuer
                Metadata = metadata
                Number = number
                OnBehalfOf = onBehalfOf
                PaymentSettings = paymentSettings
                PendingInvoiceItemsBehavior = pendingInvoiceItemsBehavior
                Rendering = rendering
                ShippingCost = shippingCost
                ShippingDetails = shippingDetails
                StatementDescriptor = statementDescriptor
                Subscription = subscription
                TransferData = transferData
            }

    ///<summary><p>This endpoint creates a draft invoice for a given customer. The invoice remains a draft until you <a href="/api/invoices/finalize">finalize</a> the invoice, which allows you to <a href="/api/invoices/pay">pay</a> or <a href="/api/invoices/send">send</a> the invoice to your customers.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/invoices"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Invoice: string
    }
    with
        static member New(invoice: string) =
            {
                Invoice = invoice
            }

    ///<summary><p>Permanently deletes a one-off invoice draft. This cannot be undone. Attempts to delete invoices that are no longer in a draft state will fail; once an invoice has been finalized or if an invoice is for a subscription, it must be <a href="/api/invoices/void">voided</a>.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/invoices/{options.Invoice}"
        |> RestApi.deleteAsync<DeletedInvoice> settings (Map.empty)

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Invoice: string
    }
    with
        static member New(invoice: string, ?expand: string list) =
            {
                Expand = expand
                Invoice = invoice
            }

    ///<summary><p>Retrieves the invoice with the given ID.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/invoices/{options.Invoice}"
        |> RestApi.getAsync<Invoice> settings qs

    type Update'AutomaticTaxLiabilityType =
    | Account
    | Self

    type Update'AutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Update'AutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': Update'AutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Update'AutomaticTax = {
        ///<summary>Whether Stripe automatically computes tax on this invoice. Note that incompatible invoice items (invoice items with manually specified [tax rates](https://docs.stripe.com/api/tax_rates), negative amounts, or `tax_behavior=unspecified`) cannot be added to automatic tax invoices.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: Update'AutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: Update'AutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Update'CustomFields = {
        ///<summary>The name of the custom field. This may be up to 40 characters.</summary>
        [<Config.Form>]Name: string option
        ///<summary>The value of the custom field. This may be up to 140 characters.</summary>
        [<Config.Form>]Value: string option
    }
    with
        static member New(?name: string, ?value: string) =
            {
                Name = name
                Value = value
            }

    type Update'Discounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'IssuerType =
    | Account
    | Self

    type Update'Issuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Update'IssuerType option
    }
    with
        static member New(?account: string, ?type': Update'IssuerType) =
            {
                Account = account
                Type = type'
            }

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType =
    | Business
    | Personal

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions = {
        ///<summary>Transaction type of the mandate.</summary>
        [<Config.Form>]TransactionType: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
    }
    with
        static member New(?transactionType: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType) =
            {
                TransactionType = transactionType
            }

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions = {
        ///<summary>Additional fields for Mandate creation</summary>
        [<Config.Form>]MandateOptions: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option
        ///<summary>Verification method for the intent</summary>
        [<Config.Form>]VerificationMethod: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions, ?verificationMethod: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod) =
            {
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Fr
    | Nl

    type Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions = {
        ///<summary>Preferred language of the Bancontact authorization page that the customer is redirected to.</summary>
        [<Config.Form>]PreferredLanguage: Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
    }
    with
        static member New(?preferredLanguage: Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval =
    | Month

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType =
    | Bonus
    | FixedCount
    | Revolving

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan = {
        ///<summary>For `fixed_count` installment plans, this is required. It represents the number of installment payments your customer will make to their credit card.</summary>
        [<Config.Form>]Count: int option
        ///<summary>For `fixed_count` installment plans, this is required. It represents the interval between installment payments your customer will make to their credit card.
        ///One of `month`.</summary>
        [<Config.Form>]Interval: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval option
        ///<summary>Type of installment plan, one of `fixed_count`, `bonus`, or `revolving`.</summary>
        [<Config.Form>]Type: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType option
    }
    with
        static member New(?count: int, ?interval: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanInterval, ?type': Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlanType) =
            {
                Count = count
                Interval = interval
                Type = type'
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments = {
        ///<summary>Setting to true enables installments for this invoice.
        ///Setting to false will prevent any selected plan from applying to a payment.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The selected installment plan to use for this invoice.</summary>
        [<Config.Form>]Plan: Choice<Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan,string> option
    }
    with
        static member New(?enabled: bool, ?plan: Choice<Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallmentsPlanInstallmentPlan,string>) =
            {
                Enabled = enabled
                Plan = plan
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure =
    | Any
    | Automatic
    | Challenge

    type Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions = {
        ///<summary>Installment configuration for payments attempted on this invoice.
        ///For more information, see the [installments integration guide](https://docs.stripe.com/payments/installments).</summary>
        [<Config.Form>]Installments: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments option
        ///<summary>We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.</summary>
        [<Config.Form>]RequestThreeDSecure: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure option
    }
    with
        static member New(?installments: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsInstallments, ?requestThreeDSecure: Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptionsRequestThreeDSecure) =
            {
                Installments = installments
                RequestThreeDSecure = requestThreeDSecure
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer = {
        ///<summary>The desired country code of the bank account information. Permitted values include: `DE`, `FR`, `IE`, or `NL`.</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
    }
    with
        static member New(?country: IsoTypes.IsoCountryCode) =
            {
                Country = country
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer = {
        ///<summary>Configuration for eu_bank_transfer funding type.</summary>
        [<Config.Form>]EuBankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option
        ///<summary>The bank transfer type that can be used for funding. Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.</summary>
        [<Config.Form>]Type: string option
    }
    with
        static member New(?euBankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer, ?type': string) =
            {
                EuBankTransfer = euBankTransfer
                Type = type'
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions = {
        ///<summary>Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.</summary>
        [<Config.Form>]BankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option
        ///<summary>The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.</summary>
        [<Config.Form>]FundingType: string option
    }
    with
        static member New(?bankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer, ?fundingType: string) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
            }

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose =
    | DependantSupport
    | Government
    | Loan
    | Mortgage
    | Other
    | Pension
    | Personal
    | Retail
    | Salary
    | Tax
    | Utility

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions = {
        ///<summary>The maximum amount that can be collected in a single invoice. If you don't specify a maximum, then there is no limit.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>The purpose for which payments are made. Has a default value based on your merchant category code.</summary>
        [<Config.Form>]Purpose: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose option
    }
    with
        static member New(?amount: int, ?purpose: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose) =
            {
                Amount = amount
                Purpose = purpose
            }

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions = {
        ///<summary>Additional fields for Mandate creation.</summary>
        [<Config.Form>]MandateOptions: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions option
    }
    with
        static member New(?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Update'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptionsAmountIncludesIof =
    | Always
    | Never

    type Update'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions = {
        ///<summary>Determines if the amount includes the IOF tax. Defaults to `never`.</summary>
        [<Config.Form>]AmountIncludesIof: Update'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptionsAmountIncludesIof option
        ///<summary>The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.</summary>
        [<Config.Form>]ExpiresAfterSeconds: int option
    }
    with
        static member New(?amountIncludesIof: Update'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptionsAmountIncludesIof, ?expiresAfterSeconds: int) =
            {
                AmountIncludesIof = amountIncludesIof
                ExpiresAfterSeconds = expiresAfterSeconds
            }

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions = {
        ///<summary>Amount to be charged for future payments.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.</summary>
        [<Config.Form>]AmountType: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType option
        ///<summary>A description of the mandate or subscription that is meant to be displayed to the customer.</summary>
        [<Config.Form>]Description: string option
        ///<summary>End date of the mandate or subscription.</summary>
        [<Config.Form>]EndDate: DateTime option
    }
    with
        static member New(?amount: int, ?amountType: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions = {
        ///<summary>Configuration options for setting up an eMandate</summary>
        [<Config.Form>]MandateOptions: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions option
    }
    with
        static member New(?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories =
    | Checking
    | Savings

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters = {
        ///<summary>The account subcategories to use to filter for selectable accounts. Valid subcategories are `checking` and `savings`.</summary>
        [<Config.Form>]AccountSubcategories: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list option
    }
    with
        static member New(?accountSubcategories: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list) =
            {
                AccountSubcategories = accountSubcategories
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch =
    | Balances
    | Ownership
    | Transactions

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections = {
        ///<summary>Provide filters for the linked accounts that the customer can select for the payment method.</summary>
        [<Config.Form>]Filters: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters option
        ///<summary>The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.</summary>
        [<Config.Form>]Permissions: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option
        ///<summary>List of data features that you would like to retrieve upon account creation.</summary>
        [<Config.Form>]Prefetch: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
    }
    with
        static member New(?filters: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters, ?permissions: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list, ?prefetch: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list) =
            {
                Filters = filters
                Permissions = permissions
                Prefetch = prefetch
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions = {
        ///<summary>Additional fields for Financial Connections Session creation</summary>
        [<Config.Form>]FinancialConnections: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option
        ///<summary>Verification method for the intent</summary>
        [<Config.Form>]VerificationMethod: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?financialConnections: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections, ?verificationMethod: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod) =
            {
                FinancialConnections = financialConnections
                VerificationMethod = verificationMethod
            }

    type Update'PaymentSettingsPaymentMethodOptions = {
        ///<summary>If paying by `acss_debit`, this sub-hash contains details about the Canadian pre-authorized debit payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]AcssDebit: Choice<Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `bancontact`, this sub-hash contains details about the Bancontact payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Bancontact: Choice<Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `card`, this sub-hash contains details about the Card payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Card: Choice<Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `customer_balance`, this sub-hash contains details about the Bank transfer payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]CustomerBalance: Choice<Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `konbini`, this sub-hash contains details about the Konbini payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Konbini: Choice<string,string> option
        ///<summary>If paying by `payto`, this sub-hash contains details about the PayTo payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Payto: Choice<Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `pix`, this sub-hash contains details about the Pix payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Pix: Choice<Update'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `sepa_debit`, this sub-hash contains details about the SEPA Direct Debit payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]SepaDebit: Choice<string,string> option
        ///<summary>If paying by `upi`, this sub-hash contains details about the UPI payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Upi: Choice<Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string> option
        ///<summary>If paying by `us_bank_account`, this sub-hash contains details about the ACH direct debit payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]UsBankAccount: Choice<Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
    }
    with
        static member New(?acssDebit: Choice<Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string>, ?bancontact: Choice<Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string>, ?card: Choice<Update'PaymentSettingsPaymentMethodOptionsCardInvoicePaymentMethodOptions,string>, ?customerBalance: Choice<Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string>, ?konbini: Choice<string,string>, ?payto: Choice<Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string>, ?pix: Choice<Update'PaymentSettingsPaymentMethodOptionsPixInvoicePaymentMethodOptions,string>, ?sepaDebit: Choice<string,string>, ?upi: Choice<Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string>, ?usBankAccount: Choice<Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string>) =
            {
                AcssDebit = acssDebit
                Bancontact = bancontact
                Card = card
                CustomerBalance = customerBalance
                Konbini = konbini
                Payto = payto
                Pix = pix
                SepaDebit = sepaDebit
                Upi = upi
                UsBankAccount = usBankAccount
            }

    type Update'PaymentSettingsPaymentMethodTypes =
    | AchCreditTransfer
    | AchDebit
    | AcssDebit
    | Affirm
    | AmazonPay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Boleto
    | Card
    | Cashapp
    | Crypto
    | Custom
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | JpCreditTransfer
    | KakaoPay
    | Klarna
    | Konbini
    | KrCard
    | Link
    | Multibanco
    | NaverPay
    | NzBankAccount
    | P24
    | PayByBank
    | Payco
    | Paynow
    | Paypal
    | Payto
    | Pix
    | Promptpay
    | RevolutPay
    | SepaCreditTransfer
    | SepaDebit
    | Sofort
    | Swish
    | Upi
    | UsBankAccount
    | WechatPay

    type Update'PaymentSettings = {
        ///<summary>ID of the mandate to be used for this invoice. It must correspond to the payment method used to pay the invoice, including the invoice's default_payment_method or default_source, if set.</summary>
        [<Config.Form>]DefaultMandate: Choice<string,string> option
        ///<summary>Payment-method-specific configuration to provide to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]PaymentMethodOptions: Update'PaymentSettingsPaymentMethodOptions option
        ///<summary>The list of payment method types (e.g. card) to provide to the invoice’s PaymentIntent. If not set, Stripe attempts to automatically determine the types to use by looking at the invoice’s default payment method, the subscription’s default payment method, the customer’s default payment method, and your [invoice template settings](https://dashboard.stripe.com/settings/billing/invoice).</summary>
        [<Config.Form>]PaymentMethodTypes: Choice<Update'PaymentSettingsPaymentMethodTypes list,string> option
    }
    with
        static member New(?defaultMandate: Choice<string,string>, ?paymentMethodOptions: Update'PaymentSettingsPaymentMethodOptions, ?paymentMethodTypes: Choice<Update'PaymentSettingsPaymentMethodTypes list,string>) =
            {
                DefaultMandate = defaultMandate
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
            }

    type Update'RenderingPdfPageSize =
    | A4
    | Auto
    | Letter

    type Update'RenderingPdf = {
        ///<summary>Page size for invoice PDF. Can be set to `a4`, `letter`, or `auto`.
        /// If set to `auto`, invoice PDF page size defaults to `a4` for customers with
        /// Japanese locale and `letter` for customers with other locales.</summary>
        [<Config.Form>]PageSize: Update'RenderingPdfPageSize option
    }
    with
        static member New(?pageSize: Update'RenderingPdfPageSize) =
            {
                PageSize = pageSize
            }

    type Update'RenderingAmountTaxDisplay =
    | ExcludeTax
    | IncludeInclusiveTax

    type Update'Rendering = {
        ///<summary>How line-item prices and amounts will be displayed with respect to tax on invoice PDFs. One of `exclude_tax` or `include_inclusive_tax`. `include_inclusive_tax` will include inclusive tax (and exclude exclusive tax) in invoice PDF amounts. `exclude_tax` will exclude all tax (inclusive and exclusive alike) from invoice PDF amounts.</summary>
        [<Config.Form>]AmountTaxDisplay: Update'RenderingAmountTaxDisplay option
        ///<summary>Invoice pdf rendering options</summary>
        [<Config.Form>]Pdf: Update'RenderingPdf option
        ///<summary>ID of the invoice rendering template to use for this invoice.</summary>
        [<Config.Form>]Template: string option
        ///<summary>The specific version of invoice rendering template to use for this invoice.</summary>
        [<Config.Form>]TemplateVersion: Choice<int,string> option
    }
    with
        static member New(?amountTaxDisplay: Update'RenderingAmountTaxDisplay, ?pdf: Update'RenderingPdf, ?template: string, ?templateVersion: Choice<int,string>) =
            {
                AmountTaxDisplay = amountTaxDisplay
                Pdf = pdf
                Template = template
                TemplateVersion = templateVersion
            }

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximum = {
        ///<summary>A unit of time.</summary>
        [<Config.Form>]Unit: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximumUnit option
        ///<summary>Must be greater than 0.</summary>
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimum = {
        ///<summary>A unit of time.</summary>
        [<Config.Form>]Unit: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimumUnit option
        ///<summary>Must be greater than 0.</summary>
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Update'ShippingCostShippingCostShippingRateDataDeliveryEstimate = {
        ///<summary>The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.</summary>
        [<Config.Form>]Maximum: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximum option
        ///<summary>The lower bound of the estimated range. If empty, represents no lower bound.</summary>
        [<Config.Form>]Minimum: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimum option
    }
    with
        static member New(?maximum: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMaximum, ?minimum: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimateMinimum) =
            {
                Maximum = maximum
                Minimum = minimum
            }

    type Update'ShippingCostShippingCostShippingRateDataFixedAmount = {
        ///<summary>A non-negative integer in cents representing how much to charge.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]CurrencyOptions: Map<string, string> option
    }
    with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode, ?currencyOptions: Map<string, string>) =
            {
                Amount = amount
                Currency = currency
                CurrencyOptions = currencyOptions
            }

    type Update'ShippingCostShippingCostShippingRateDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'ShippingCostShippingCostShippingRateDataType =
    | FixedAmount

    type Update'ShippingCostShippingCostShippingRateData = {
        ///<summary>The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.</summary>
        [<Config.Form>]DeliveryEstimate: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimate option
        ///<summary>The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.</summary>
        [<Config.Form>]DisplayName: string option
        ///<summary>Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.</summary>
        [<Config.Form>]FixedAmount: Update'ShippingCostShippingCostShippingRateDataFixedAmount option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.</summary>
        [<Config.Form>]TaxBehavior: Update'ShippingCostShippingCostShippingRateDataTaxBehavior option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.</summary>
        [<Config.Form>]TaxCode: string option
        ///<summary>The type of calculation to use on the shipping rate.</summary>
        [<Config.Form>]Type: Update'ShippingCostShippingCostShippingRateDataType option
    }
    with
        static member New(?deliveryEstimate: Update'ShippingCostShippingCostShippingRateDataDeliveryEstimate, ?displayName: string, ?fixedAmount: Update'ShippingCostShippingCostShippingRateDataFixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Update'ShippingCostShippingCostShippingRateDataTaxBehavior, ?taxCode: string, ?type': Update'ShippingCostShippingCostShippingRateDataType) =
            {
                DeliveryEstimate = deliveryEstimate
                DisplayName = displayName
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                Type = type'
            }

    type Update'ShippingCostShippingCost = {
        ///<summary>The ID of the shipping rate to use for this order.</summary>
        [<Config.Form>]ShippingRate: string option
        ///<summary>Parameters to create a new ad-hoc shipping rate for this order.</summary>
        [<Config.Form>]ShippingRateData: Update'ShippingCostShippingCostShippingRateData option
    }
    with
        static member New(?shippingRate: string, ?shippingRateData: Update'ShippingCostShippingCostShippingRateData) =
            {
                ShippingRate = shippingRate
                ShippingRateData = shippingRateData
            }

    type Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddressAddress = {
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

    type Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddress = {
        ///<summary>Shipping address</summary>
        [<Config.Form>]Address: Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddressAddress option
        ///<summary>Recipient name.</summary>
        [<Config.Form>]Name: string option
        ///<summary>Recipient phone (including extension)</summary>
        [<Config.Form>]Phone: Choice<string,string> option
    }
    with
        static member New(?address: Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddressAddress, ?name: string, ?phone: Choice<string,string>) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type Update'TransferDataTransferDataSpecs = {
        ///<summary>The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>ID of an existing, connected Stripe account.</summary>
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amount: int, ?destination: string) =
            {
                Amount = amount
                Destination = destination
            }

    type Update'CollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type UpdateOptions = {
        [<Config.Path>]Invoice: string
        ///<summary>The account tax IDs associated with the invoice. Only editable when the invoice is a draft.</summary>
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///<summary>A fee in cents (or local equivalent) that will be applied to the invoice and transferred to the application owner's Stripe account. The request must be made with an OAuth key or the Stripe-Account header in order to take an application fee. For more information, see the application fees [documentation](https://docs.stripe.com/billing/invoices/connect#collecting-fees).</summary>
        [<Config.Form>]ApplicationFeeAmount: int option
        ///<summary>Controls whether Stripe performs [automatic collection](https://docs.stripe.com/invoicing/integration/automatic-advancement-collection) of the invoice.</summary>
        [<Config.Form>]AutoAdvance: bool option
        ///<summary>Settings for automatic tax lookup for this invoice.</summary>
        [<Config.Form>]AutomaticTax: Update'AutomaticTax option
        ///<summary>The time when this invoice should be scheduled to finalize (up to 5 years in the future). The invoice is finalized at this time if it's still in draft state. To turn off automatic finalization, set `auto_advance` to false.</summary>
        [<Config.Form>]AutomaticallyFinalizesAt: DateTime option
        ///<summary>Either `charge_automatically` or `send_invoice`. This field can be updated only on `draft` invoices.</summary>
        [<Config.Form>]CollectionMethod: Update'CollectionMethod option
        ///<summary>A list of up to 4 custom fields to be displayed on the invoice. If a value for `custom_fields` is specified, the list specified will replace the existing custom field list on this invoice. Pass an empty string to remove previously-defined fields.</summary>
        [<Config.Form>]CustomFields: Choice<Update'CustomFields list,string> option
        ///<summary>The number of days from which the invoice is created until it is due. Only valid for invoices where `collection_method=send_invoice`. This field can only be updated on `draft` invoices.</summary>
        [<Config.Form>]DaysUntilDue: int option
        ///<summary>ID of the default payment method for the invoice. It must belong to the customer associated with the invoice. If not set, defaults to the subscription's default payment method, if any, or to the default payment method in the customer's invoice settings.</summary>
        [<Config.Form>]DefaultPaymentMethod: string option
        ///<summary>ID of the default payment source for the invoice. It must belong to the customer associated with the invoice and be in a chargeable state. If not set, defaults to the subscription's default source, if any, or to the customer's default source.</summary>
        [<Config.Form>]DefaultSource: Choice<string,string> option
        ///<summary>The tax rates that will apply to any line item that does not have `tax_rates` set. Pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///<summary>An arbitrary string attached to the object. Often useful for displaying to users. Referenced as 'memo' in the Dashboard.</summary>
        [<Config.Form>]Description: string option
        ///<summary>The discounts that will apply to the invoice. Pass an empty string to remove previously-defined discounts.</summary>
        [<Config.Form>]Discounts: Choice<Update'Discounts list,string> option
        ///<summary>The date on which payment for this invoice is due. Only valid for invoices where `collection_method=send_invoice`. This field can only be updated on `draft` invoices.</summary>
        [<Config.Form>]DueDate: DateTime option
        ///<summary>The date when this invoice is in effect. Same as `finalized_at` unless overwritten. When defined, this value replaces the system-generated 'Date of issue' printed on the invoice PDF and receipt.</summary>
        [<Config.Form>]EffectiveAt: Choice<DateTime,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Footer to be displayed on the invoice.</summary>
        [<Config.Form>]Footer: string option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Update'Issuer option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Set the number for this invoice. If no number is present then a number will be assigned automatically when the invoice is finalized. In many markets, regulations require invoices to be unique, sequential and / or gapless. You are responsible for ensuring this is true across all your different invoicing systems in the event that you edit the invoice number using our API. If you use only Stripe for your invoices and do not change invoice numbers, Stripe handles this aspect of compliance for you automatically.</summary>
        [<Config.Form>]Number: Choice<string,string> option
        ///<summary>The account (if any) for which the funds of the invoice payment are intended. If set, the invoice will be presented with the branding and support information of the specified account. See the [Invoices with Connect](https://docs.stripe.com/billing/invoices/connect) documentation for details.</summary>
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///<summary>Configuration settings for the PaymentIntent that is generated when the invoice is finalized.</summary>
        [<Config.Form>]PaymentSettings: Update'PaymentSettings option
        ///<summary>The rendering-related settings that control how the invoice is displayed on customer-facing surfaces such as PDF and Hosted Invoice Page.</summary>
        [<Config.Form>]Rendering: Update'Rendering option
        ///<summary>Settings for the cost of shipping for this invoice.</summary>
        [<Config.Form>]ShippingCost: Choice<Update'ShippingCostShippingCost,string> option
        ///<summary>Shipping details for the invoice. The Invoice PDF will use the `shipping_details` value if it is set, otherwise the PDF will render the shipping address from the customer.</summary>
        [<Config.Form>]ShippingDetails: Choice<Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddress,string> option
        ///<summary>Extra information about a charge for the customer's credit card statement. It must contain at least one letter. If not specified and this invoice is part of a subscription, the default `statement_descriptor` will be set to the first subscription item's product's `statement_descriptor`.</summary>
        [<Config.Form>]StatementDescriptor: string option
        ///<summary>If specified, the funds from the invoice will be transferred to the destination and the ID of the resulting transfer will be found on the invoice's charge. This will be unset if you POST an empty value.</summary>
        [<Config.Form>]TransferData: Choice<Update'TransferDataTransferDataSpecs,string> option
    }
    with
        static member New(invoice: string, ?shippingDetails: Choice<Update'ShippingDetailsRecipientShippingWithOptionalFieldsAddress,string>, ?shippingCost: Choice<Update'ShippingCostShippingCost,string>, ?rendering: Update'Rendering, ?paymentSettings: Update'PaymentSettings, ?onBehalfOf: Choice<string,string>, ?number: Choice<string,string>, ?metadata: Map<string, string>, ?issuer: Update'Issuer, ?footer: string, ?expand: string list, ?effectiveAt: Choice<DateTime,string>, ?dueDate: DateTime, ?discounts: Choice<Update'Discounts list,string>, ?description: string, ?defaultTaxRates: Choice<string list,string>, ?defaultSource: Choice<string,string>, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?customFields: Choice<Update'CustomFields list,string>, ?collectionMethod: Update'CollectionMethod, ?automaticallyFinalizesAt: DateTime, ?automaticTax: Update'AutomaticTax, ?autoAdvance: bool, ?applicationFeeAmount: int, ?accountTaxIds: Choice<string list,string>, ?statementDescriptor: string, ?transferData: Choice<Update'TransferDataTransferDataSpecs,string>) =
            {
                Invoice = invoice
                AccountTaxIds = accountTaxIds
                ApplicationFeeAmount = applicationFeeAmount
                AutoAdvance = autoAdvance
                AutomaticTax = automaticTax
                AutomaticallyFinalizesAt = automaticallyFinalizesAt
                CollectionMethod = collectionMethod
                CustomFields = customFields
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                DueDate = dueDate
                EffectiveAt = effectiveAt
                Expand = expand
                Footer = footer
                Issuer = issuer
                Metadata = metadata
                Number = number
                OnBehalfOf = onBehalfOf
                PaymentSettings = paymentSettings
                Rendering = rendering
                ShippingCost = shippingCost
                ShippingDetails = shippingDetails
                StatementDescriptor = statementDescriptor
                TransferData = transferData
            }

    ///<summary><p>Draft invoices are fully editable. Once an invoice is <a href="/docs/billing/invoices/workflow#finalized">finalized</a>,
    ///monetary values, as well as <code>collection_method</code>, become uneditable.</p>
    ///<p>If you would like to stop the Stripe Billing engine from automatically finalizing, reattempting payments on,
    ///sending reminders for, or <a href="/docs/billing/invoices/reconciliation">automatically reconciling</a> invoices, pass
    ///<code>auto_advance=false</code>.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/invoices/{options.Invoice}"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesCreatePreview =

    type CreatePreview'AutomaticTaxLiabilityType =
    | Account
    | Self

    type CreatePreview'AutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: CreatePreview'AutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': CreatePreview'AutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type CreatePreview'AutomaticTax = {
        ///<summary>Whether Stripe automatically computes tax on this invoice. Note that incompatible invoice items (invoice items with manually specified [tax rates](https://docs.stripe.com/api/tax_rates), negative amounts, or `tax_behavior=unspecified`) cannot be added to automatic tax invoices.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: CreatePreview'AutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: CreatePreview'AutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type CreatePreview'CustomerDetailsAddressOptionalFieldsAddress = {
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

    type CreatePreview'CustomerDetailsShippingCustomerShippingAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: string option
        ///<summary>A freeform text field for the country. However, in order to activate some tax features, the format should be a two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
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

    type CreatePreview'CustomerDetailsShippingCustomerShipping = {
        ///<summary>Customer shipping address.</summary>
        [<Config.Form>]Address: CreatePreview'CustomerDetailsShippingCustomerShippingAddress option
        ///<summary>Customer name.</summary>
        [<Config.Form>]Name: string option
        ///<summary>Customer phone (including extension).</summary>
        [<Config.Form>]Phone: string option
    }
    with
        static member New(?address: CreatePreview'CustomerDetailsShippingCustomerShippingAddress, ?name: string, ?phone: string) =
            {
                Address = address
                Name = name
                Phone = phone
            }

    type CreatePreview'CustomerDetailsTax = {
        ///<summary>A recent IP address of the customer used for tax reporting and tax location inference. Stripe recommends updating the IP address when a new PaymentMethod is attached or the address field on the customer is updated. We recommend against updating this field more frequently since it could result in unexpected tax location/reporting outcomes.</summary>
        [<Config.Form>]IpAddress: Choice<string,string> option
    }
    with
        static member New(?ipAddress: Choice<string,string>) =
            {
                IpAddress = ipAddress
            }

    type CreatePreview'CustomerDetailsTaxIdsType =
    | AdNrt
    | AeTrn
    | AlTin
    | AmTin
    | AoTin
    | ArCuit
    | AuAbn
    | AuArn
    | AwTin
    | AzTin
    | BaTin
    | BbTin
    | BdBin
    | BfIfu
    | BgUic
    | BhVat
    | BjIfu
    | BoTin
    | BrCnpj
    | BrCpf
    | BsTin
    | ByTin
    | CaBn
    | CaGstHst
    | CaPstBc
    | CaPstMb
    | CaPstSk
    | CaQst
    | CdNif
    | ChUid
    | ChVat
    | ClTin
    | CmNiu
    | CnTin
    | CoNit
    | CrTin
    | CvNif
    | DeStn
    | DoRcn
    | EcRuc
    | EgTin
    | EsCif
    | EtTin
    | EuOssVat
    | EuVat
    | FoVat
    | GbVat
    | GeVat
    | GiTin
    | GnNif
    | HkBr
    | HrOib
    | HuTin
    | IdNpwp
    | IlVat
    | InGst
    | IsVat
    | ItCf
    | JpCn
    | JpRn
    | JpTrn
    | KePin
    | KgTin
    | KhTin
    | KrBrn
    | KzBin
    | LaTin
    | LiUid
    | LiVat
    | LkVat
    | MaVat
    | MdVat
    | MePib
    | MkVat
    | MrNif
    | MxRfc
    | MyFrp
    | MyItn
    | MySst
    | NgTin
    | NoVat
    | NoVoec
    | NpPan
    | NzGst
    | OmVat
    | PeRuc
    | PhTin
    | PlNip
    | PyRuc
    | RoTin
    | RsPib
    | RuInn
    | RuKpp
    | SaVat
    | SgGst
    | SgUen
    | SiTin
    | SnNinea
    | SrFin
    | SvNit
    | ThVat
    | TjTin
    | TrTin
    | TwVat
    | TzVat
    | UaVat
    | UgTin
    | UsEin
    | UyRuc
    | UzTin
    | UzVat
    | VeRif
    | VnTin
    | ZaVat
    | ZmTin
    | ZwTin

    type CreatePreview'CustomerDetailsTaxIds = {
        ///<summary>Type of the tax ID, one of `ad_nrt`, `ae_trn`, `al_tin`, `am_tin`, `ao_tin`, `ar_cuit`, `au_abn`, `au_arn`, `aw_tin`, `az_tin`, `ba_tin`, `bb_tin`, `bd_bin`, `bf_ifu`, `bg_uic`, `bh_vat`, `bj_ifu`, `bo_tin`, `br_cnpj`, `br_cpf`, `bs_tin`, `by_tin`, `ca_bn`, `ca_gst_hst`, `ca_pst_bc`, `ca_pst_mb`, `ca_pst_sk`, `ca_qst`, `cd_nif`, `ch_uid`, `ch_vat`, `cl_tin`, `cm_niu`, `cn_tin`, `co_nit`, `cr_tin`, `cv_nif`, `de_stn`, `do_rcn`, `ec_ruc`, `eg_tin`, `es_cif`, `et_tin`, `eu_oss_vat`, `eu_vat`, `fo_vat`, `gb_vat`, `ge_vat`, `gi_tin`, `gn_nif`, `hk_br`, `hr_oib`, `hu_tin`, `id_npwp`, `il_vat`, `in_gst`, `is_vat`, `it_cf`, `jp_cn`, `jp_rn`, `jp_trn`, `ke_pin`, `kg_tin`, `kh_tin`, `kr_brn`, `kz_bin`, `la_tin`, `li_uid`, `li_vat`, `lk_vat`, `ma_vat`, `md_vat`, `me_pib`, `mk_vat`, `mr_nif`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `ng_tin`, `no_vat`, `no_voec`, `np_pan`, `nz_gst`, `om_vat`, `pe_ruc`, `ph_tin`, `pl_nip`, `py_ruc`, `ro_tin`, `rs_pib`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `si_tin`, `sn_ninea`, `sr_fin`, `sv_nit`, `th_vat`, `tj_tin`, `tr_tin`, `tw_vat`, `tz_vat`, `ua_vat`, `ug_tin`, `us_ein`, `uy_ruc`, `uz_tin`, `uz_vat`, `ve_rif`, `vn_tin`, `za_vat`, `zm_tin`, or `zw_tin`</summary>
        [<Config.Form>]Type: CreatePreview'CustomerDetailsTaxIdsType option
        ///<summary>Value of the tax ID.</summary>
        [<Config.Form>]Value: string option
    }
    with
        static member New(?type': CreatePreview'CustomerDetailsTaxIdsType, ?value: string) =
            {
                Type = type'
                Value = value
            }

    type CreatePreview'CustomerDetailsTaxExempt =
    | Exempt
    | None'
    | Reverse

    type CreatePreview'CustomerDetails = {
        ///<summary>The customer's address. Learn about [country-specific requirements for calculating tax](/invoicing/taxes?dashboard-or-api=dashboard#set-up-customer).</summary>
        [<Config.Form>]Address: Choice<CreatePreview'CustomerDetailsAddressOptionalFieldsAddress,string> option
        ///<summary>The customer's shipping information. Appears on invoices emailed to this customer.</summary>
        [<Config.Form>]Shipping: Choice<CreatePreview'CustomerDetailsShippingCustomerShipping,string> option
        ///<summary>Tax details about the customer.</summary>
        [<Config.Form>]Tax: CreatePreview'CustomerDetailsTax option
        ///<summary>The customer's tax exemption. One of `none`, `exempt`, or `reverse`.</summary>
        [<Config.Form>]TaxExempt: CreatePreview'CustomerDetailsTaxExempt option
        ///<summary>The customer's tax IDs.</summary>
        [<Config.Form>]TaxIds: CreatePreview'CustomerDetailsTaxIds list option
    }
    with
        static member New(?address: Choice<CreatePreview'CustomerDetailsAddressOptionalFieldsAddress,string>, ?shipping: Choice<CreatePreview'CustomerDetailsShippingCustomerShipping,string>, ?tax: CreatePreview'CustomerDetailsTax, ?taxExempt: CreatePreview'CustomerDetailsTaxExempt, ?taxIds: CreatePreview'CustomerDetailsTaxIds list) =
            {
                Address = address
                Shipping = shipping
                Tax = tax
                TaxExempt = taxExempt
                TaxIds = taxIds
            }

    type CreatePreview'Discounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type CreatePreview'InvoiceItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type CreatePreview'InvoiceItemsPeriod = {
        ///<summary>The end of the period, which must be greater than or equal to the start. This value is inclusive.</summary>
        [<Config.Form>]End: DateTime option
        ///<summary>The start of the period. This value is inclusive.</summary>
        [<Config.Form>]Start: DateTime option
    }
    with
        static member New(?end': DateTime, ?start: DateTime) =
            {
                End = end'
                Start = start
            }

    type CreatePreview'InvoiceItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type CreatePreview'InvoiceItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: CreatePreview'InvoiceItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?taxBehavior: CreatePreview'InvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type CreatePreview'InvoiceItemsTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type CreatePreview'InvoiceItems = {
        ///<summary>The integer amount in cents (or local equivalent) of previewed invoice item.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies). Only applicable to new invoice items.</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Explicitly controls whether discounts apply to this invoice item. Defaults to true, except for negative invoice items.</summary>
        [<Config.Form>]Discountable: bool option
        ///<summary>The coupons to redeem into discounts for the invoice item in the preview.</summary>
        [<Config.Form>]Discounts: Choice<CreatePreview'InvoiceItemsDiscounts list,string> option
        ///<summary>The ID of the invoice item to update in preview. If not specified, a new invoice item will be added to the preview of the upcoming invoice.</summary>
        [<Config.Form>]Invoiceitem: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://docs.stripe.com/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://docs.stripe.com/revenue-recognition/methodology/subscriptions-and-invoicing) for details.</summary>
        [<Config.Form>]Period: CreatePreview'InvoiceItemsPeriod option
        ///<summary>The ID of the price object. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]PriceData: CreatePreview'InvoiceItemsPriceData option
        ///<summary>Non-negative integer. The quantity of units for the invoice item. Use `quantity_decimal` instead to provide decimal precision. This field will be deprecated in favor of `quantity_decimal` in a future version.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>Non-negative decimal with at most 12 decimal places. The quantity of units for the invoice item.</summary>
        [<Config.Form>]QuantityDecimal: string option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: CreatePreview'InvoiceItemsTaxBehavior option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID.</summary>
        [<Config.Form>]TaxCode: Choice<string,string> option
        ///<summary>The tax rates that apply to the item. When set, any `default_tax_rates` do not apply to this item.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
        ///<summary>The integer unit amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. This unit_amount will be multiplied by the quantity to get the full amount. If you want to apply a credit to the customer's account, pass a negative unit_amount.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?amount: int, ?taxRates: Choice<string list,string>, ?taxCode: Choice<string,string>, ?taxBehavior: CreatePreview'InvoiceItemsTaxBehavior, ?quantityDecimal: string, ?quantity: int, ?priceData: CreatePreview'InvoiceItemsPriceData, ?unitAmount: int, ?price: string, ?metadata: Map<string, string>, ?invoiceitem: string, ?discounts: Choice<CreatePreview'InvoiceItemsDiscounts list,string>, ?discountable: bool, ?description: string, ?currency: IsoTypes.IsoCurrencyCode, ?period: CreatePreview'InvoiceItemsPeriod, ?unitAmountDecimal: string) =
            {
                Amount = amount
                Currency = currency
                Description = description
                Discountable = discountable
                Discounts = discounts
                Invoiceitem = invoiceitem
                Metadata = metadata
                Period = period
                Price = price
                PriceData = priceData
                Quantity = quantity
                QuantityDecimal = quantityDecimal
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                TaxRates = taxRates
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type CreatePreview'IssuerType =
    | Account
    | Self

    type CreatePreview'Issuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: CreatePreview'IssuerType option
    }
    with
        static member New(?account: string, ?type': CreatePreview'IssuerType) =
            {
                Account = account
                Type = type'
            }

    type CreatePreview'ScheduleDetailsBillingModeFlexibleProrationDiscounts =
    | Included
    | Itemized

    type CreatePreview'ScheduleDetailsBillingModeFlexible = {
        ///<summary>Controls how invoices and invoice items display proration amounts and discount amounts.</summary>
        [<Config.Form>]ProrationDiscounts: CreatePreview'ScheduleDetailsBillingModeFlexibleProrationDiscounts option
    }
    with
        static member New(?prorationDiscounts: CreatePreview'ScheduleDetailsBillingModeFlexibleProrationDiscounts) =
            {
                ProrationDiscounts = prorationDiscounts
            }

    type CreatePreview'ScheduleDetailsBillingModeType =
    | Classic
    | Flexible

    type CreatePreview'ScheduleDetailsBillingMode = {
        ///<summary>Configure behavior for flexible billing mode.</summary>
        [<Config.Form>]Flexible: CreatePreview'ScheduleDetailsBillingModeFlexible option
        ///<summary>Controls the calculation and orchestration of prorations and invoices for subscriptions. If no value is passed, the default is `flexible`.</summary>
        [<Config.Form>]Type: CreatePreview'ScheduleDetailsBillingModeType option
    }
    with
        static member New(?flexible: CreatePreview'ScheduleDetailsBillingModeFlexible, ?type': CreatePreview'ScheduleDetailsBillingModeType) =
            {
                Flexible = flexible
                Type = type'
            }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodEndType =
    | MinItemPeriodEnd
    | PhaseEnd
    | Timestamp

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodEnd = {
        ///<summary>A precise Unix timestamp for the end of the invoice item period. Must be greater than or equal to `period.start`.</summary>
        [<Config.Form>]Timestamp: DateTime option
        ///<summary>Select how to calculate the end of the invoice item period.</summary>
        [<Config.Form>]Type: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodEndType option
    }
    with
        static member New(?timestamp: DateTime, ?type': CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodEndType) =
            {
                Timestamp = timestamp
                Type = type'
            }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodStartType =
    | MaxItemPeriodStart
    | PhaseStart
    | Timestamp

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodStart = {
        ///<summary>A precise Unix timestamp for the start of the invoice item period. Must be less than or equal to `period.end`.</summary>
        [<Config.Form>]Timestamp: DateTime option
        ///<summary>Select how to calculate the start of the invoice item period.</summary>
        [<Config.Form>]Type: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodStartType option
    }
    with
        static member New(?timestamp: DateTime, ?type': CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodStartType) =
            {
                Timestamp = timestamp
                Type = type'
            }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriod = {
        ///<summary>End of the invoice item period.</summary>
        [<Config.Form>]End: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodEnd option
        ///<summary>Start of the invoice item period.</summary>
        [<Config.Form>]Start: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodStart option
    }
    with
        static member New(?end': CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodEnd, ?start: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriodStart) =
            {
                End = end'
                Start = start
            }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge or a negative integer representing the amount to credit to the customer.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?taxBehavior: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type CreatePreview'ScheduleDetailsPhasesAddInvoiceItems = {
        ///<summary>The coupons to redeem into discounts for the item.</summary>
        [<Config.Form>]Discounts: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsDiscounts list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The period associated with this invoice item. If not set, `period.start.type` defaults to `max_item_period_start` and `period.end.type` defaults to `min_item_period_end`.</summary>
        [<Config.Form>]Period: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriod option
        ///<summary>The ID of the price object. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]PriceData: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPriceData option
        ///<summary>Quantity for this item. Defaults to 1.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?discounts: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsDiscounts list, ?metadata: Map<string, string>, ?period: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPeriod, ?price: string, ?priceData: CreatePreview'ScheduleDetailsPhasesAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Discounts = discounts
                Metadata = metadata
                Period = period
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type CreatePreview'ScheduleDetailsPhasesAutomaticTaxLiabilityType =
    | Account
    | Self

    type CreatePreview'ScheduleDetailsPhasesAutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: CreatePreview'ScheduleDetailsPhasesAutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': CreatePreview'ScheduleDetailsPhasesAutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type CreatePreview'ScheduleDetailsPhasesAutomaticTax = {
        ///<summary>Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: CreatePreview'ScheduleDetailsPhasesAutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: CreatePreview'ScheduleDetailsPhasesAutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type CreatePreview'ScheduleDetailsPhasesBillingThresholdsBillingThresholds = {
        ///<summary>Monetary threshold that triggers the subscription to advance to a new billing period</summary>
        [<Config.Form>]AmountGte: int option
        ///<summary>Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.</summary>
        [<Config.Form>]ResetBillingCycleAnchor: bool option
    }
    with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type CreatePreview'ScheduleDetailsPhasesDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type CreatePreview'ScheduleDetailsPhasesDurationInterval =
    | Day
    | Month
    | Week
    | Year

    type CreatePreview'ScheduleDetailsPhasesDuration = {
        ///<summary>Specifies phase duration. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: CreatePreview'ScheduleDetailsPhasesDurationInterval option
        ///<summary>The multiplier applied to the interval.</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: CreatePreview'ScheduleDetailsPhasesDurationInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type CreatePreview'ScheduleDetailsPhasesEndDate =
    | Now

    type CreatePreview'ScheduleDetailsPhasesInvoiceSettingsIssuerType =
    | Account
    | Self

    type CreatePreview'ScheduleDetailsPhasesInvoiceSettingsIssuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: CreatePreview'ScheduleDetailsPhasesInvoiceSettingsIssuerType option
    }
    with
        static member New(?account: string, ?type': CreatePreview'ScheduleDetailsPhasesInvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
            }

    type CreatePreview'ScheduleDetailsPhasesInvoiceSettings = {
        ///<summary>The account tax IDs associated with this phase of the subscription schedule. Will be set on invoices generated by this phase of the subscription schedule.</summary>
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///<summary>Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `billing=charge_automatically`.</summary>
        [<Config.Form>]DaysUntilDue: int option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: CreatePreview'ScheduleDetailsPhasesInvoiceSettingsIssuer option
    }
    with
        static member New(?accountTaxIds: Choice<string list,string>, ?daysUntilDue: int, ?issuer: CreatePreview'ScheduleDetailsPhasesInvoiceSettingsIssuer) =
            {
                AccountTaxIds = accountTaxIds
                DaysUntilDue = daysUntilDue
                Issuer = issuer
            }

    type CreatePreview'ScheduleDetailsPhasesItemsBillingThresholdsItemBillingThresholds = {
        ///<summary>Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))</summary>
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type CreatePreview'ScheduleDetailsPhasesItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type CreatePreview'ScheduleDetailsPhasesItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type CreatePreview'ScheduleDetailsPhasesItemsPriceDataRecurring = {
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: CreatePreview'ScheduleDetailsPhasesItemsPriceDataRecurringInterval option
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: CreatePreview'ScheduleDetailsPhasesItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type CreatePreview'ScheduleDetailsPhasesItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type CreatePreview'ScheduleDetailsPhasesItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>The recurring components of a price such as `interval` and `interval_count`.</summary>
        [<Config.Form>]Recurring: CreatePreview'ScheduleDetailsPhasesItemsPriceDataRecurring option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: CreatePreview'ScheduleDetailsPhasesItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: CreatePreview'ScheduleDetailsPhasesItemsPriceDataRecurring, ?taxBehavior: CreatePreview'ScheduleDetailsPhasesItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type CreatePreview'ScheduleDetailsPhasesItems = {
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<CreatePreview'ScheduleDetailsPhasesItemsBillingThresholdsItemBillingThresholds,string> option
        ///<summary>The coupons to redeem into discounts for the subscription item.</summary>
        [<Config.Form>]Discounts: Choice<CreatePreview'ScheduleDetailsPhasesItemsDiscounts list,string> option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to a configuration item. Metadata on a configuration item will update the underlying subscription item's `metadata` when the phase is entered, adding new keys and replacing existing keys. Individual keys in the subscription item's `metadata` can be unset by posting an empty value to them in the configuration item's `metadata`. To unset all keys in the subscription item's `metadata`, update the subscription item directly or unset every key individually from the configuration item's `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The plan ID to subscribe to. You may specify the same ID in `plan` and `price`.</summary>
        [<Config.Form>]Plan: string option
        ///<summary>The ID of the price object.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.</summary>
        [<Config.Form>]PriceData: CreatePreview'ScheduleDetailsPhasesItemsPriceData option
        ///<summary>Quantity for the given price. Can be set only if the price's `usage_type` is `licensed` and not `metered`.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?billingThresholds: Choice<CreatePreview'ScheduleDetailsPhasesItemsBillingThresholdsItemBillingThresholds,string>, ?discounts: Choice<CreatePreview'ScheduleDetailsPhasesItemsDiscounts list,string>, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: CreatePreview'ScheduleDetailsPhasesItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Discounts = discounts
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type CreatePreview'ScheduleDetailsPhasesStartDate =
    | Now

    type CreatePreview'ScheduleDetailsPhasesTransferData = {
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.</summary>
        [<Config.Form>]AmountPercent: decimal option
        ///<summary>ID of an existing, connected Stripe account.</summary>
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type CreatePreview'ScheduleDetailsPhasesTrialEnd =
    | Now

    type CreatePreview'ScheduleDetailsPhasesBillingCycleAnchor =
    | Automatic
    | PhaseStart

    type CreatePreview'ScheduleDetailsPhasesCollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type CreatePreview'ScheduleDetailsPhasesProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type CreatePreview'ScheduleDetailsPhases = {
        ///<summary>A list of prices and quantities that will generate invoice items appended to the next invoice for this phase. You may pass up to 20 items.</summary>
        [<Config.Form>]AddInvoiceItems: CreatePreview'ScheduleDetailsPhasesAddInvoiceItems list option
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).</summary>
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///<summary>Automatic tax settings for this phase.</summary>
        [<Config.Form>]AutomaticTax: CreatePreview'ScheduleDetailsPhasesAutomaticTax option
        ///<summary>Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).</summary>
        [<Config.Form>]BillingCycleAnchor: CreatePreview'ScheduleDetailsPhasesBillingCycleAnchor option
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<CreatePreview'ScheduleDetailsPhasesBillingThresholdsBillingThresholds,string> option
        ///<summary>Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.</summary>
        [<Config.Form>]CollectionMethod: CreatePreview'ScheduleDetailsPhasesCollectionMethod option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.</summary>
        [<Config.Form>]DefaultPaymentMethod: string option
        ///<summary>A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will set the Subscription's [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates), which means they will be the Invoice's [`default_tax_rates`](https://docs.stripe.com/api/invoices/create#create_invoice-default_tax_rates) for any Invoices issued by the Subscription during this Phase.</summary>
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///<summary>Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.</summary>
        [<Config.Form>]Description: Choice<string,string> option
        ///<summary>The coupons to redeem into discounts for the schedule phase. If not specified, inherits the discount from the subscription's customer. Pass an empty string to avoid inheriting any discounts.</summary>
        [<Config.Form>]Discounts: Choice<CreatePreview'ScheduleDetailsPhasesDiscounts list,string> option
        ///<summary>The number of intervals the phase should last. If set, `end_date` must not be set.</summary>
        [<Config.Form>]Duration: CreatePreview'ScheduleDetailsPhasesDuration option
        ///<summary>The date at which this phase of the subscription schedule ends. If set, `duration` must not be set.</summary>
        [<Config.Form>]EndDate: Choice<DateTime,CreatePreview'ScheduleDetailsPhasesEndDate> option
        ///<summary>All invoices will be billed using the specified settings.</summary>
        [<Config.Form>]InvoiceSettings: CreatePreview'ScheduleDetailsPhasesInvoiceSettings option
        ///<summary>List of configuration items, each with an attached price, to apply during this phase of the subscription schedule.</summary>
        [<Config.Form>]Items: CreatePreview'ScheduleDetailsPhasesItems list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to a phase. Metadata on a schedule's phase will update the underlying subscription's `metadata` when the phase is entered, adding new keys and replacing existing keys in the subscription's `metadata`. Individual keys in the subscription's `metadata` can be unset by posting an empty value to them in the phase's `metadata`. To unset all keys in the subscription's `metadata`, update the subscription directly or unset every key individually from the phase's `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The account on behalf of which to charge, for each of the associated subscription's invoices.</summary>
        [<Config.Form>]OnBehalfOf: string option
        ///<summary>Controls whether the subscription schedule should create [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when transitioning to this phase if there is a difference in billing configuration. It's different from the request-level [proration_behavior](https://docs.stripe.com/api/subscription_schedules/update#update_subscription_schedule-proration_behavior) parameter which controls what happens if the update request affects the billing configuration (item price, quantity, etc.) of the current phase.</summary>
        [<Config.Form>]ProrationBehavior: CreatePreview'ScheduleDetailsPhasesProrationBehavior option
        ///<summary>The date at which this phase of the subscription schedule starts or `now`. Must be set on the first phase.</summary>
        [<Config.Form>]StartDate: Choice<DateTime,CreatePreview'ScheduleDetailsPhasesStartDate> option
        ///<summary>The data with which to automatically create a Transfer for each of the associated subscription's invoices.</summary>
        [<Config.Form>]TransferData: CreatePreview'ScheduleDetailsPhasesTransferData option
        ///<summary>If set to true the entire phase is counted as a trial and the customer will not be charged for any fees.</summary>
        [<Config.Form>]Trial: bool option
        ///<summary>Sets the phase to trialing from the start date to this date. Must be before the phase end date, can not be combined with `trial`</summary>
        [<Config.Form>]TrialEnd: Choice<DateTime,CreatePreview'ScheduleDetailsPhasesTrialEnd> option
    }
    with
        static member New(?addInvoiceItems: CreatePreview'ScheduleDetailsPhasesAddInvoiceItems list, ?transferData: CreatePreview'ScheduleDetailsPhasesTransferData, ?startDate: Choice<DateTime,CreatePreview'ScheduleDetailsPhasesStartDate>, ?prorationBehavior: CreatePreview'ScheduleDetailsPhasesProrationBehavior, ?onBehalfOf: string, ?metadata: Map<string, string>, ?items: CreatePreview'ScheduleDetailsPhasesItems list, ?invoiceSettings: CreatePreview'ScheduleDetailsPhasesInvoiceSettings, ?endDate: Choice<DateTime,CreatePreview'ScheduleDetailsPhasesEndDate>, ?duration: CreatePreview'ScheduleDetailsPhasesDuration, ?discounts: Choice<CreatePreview'ScheduleDetailsPhasesDiscounts list,string>, ?description: Choice<string,string>, ?defaultTaxRates: Choice<string list,string>, ?defaultPaymentMethod: string, ?currency: IsoTypes.IsoCurrencyCode, ?collectionMethod: CreatePreview'ScheduleDetailsPhasesCollectionMethod, ?billingThresholds: Choice<CreatePreview'ScheduleDetailsPhasesBillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: CreatePreview'ScheduleDetailsPhasesBillingCycleAnchor, ?automaticTax: CreatePreview'ScheduleDetailsPhasesAutomaticTax, ?applicationFeePercent: decimal, ?trial: bool, ?trialEnd: Choice<DateTime,CreatePreview'ScheduleDetailsPhasesTrialEnd>) =
            {
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                Currency = currency
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                Duration = duration
                EndDate = endDate
                InvoiceSettings = invoiceSettings
                Items = items
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                ProrationBehavior = prorationBehavior
                StartDate = startDate
                TransferData = transferData
                Trial = trial
                TrialEnd = trialEnd
            }

    type CreatePreview'ScheduleDetailsEndBehavior =
    | Cancel
    | Release

    type CreatePreview'ScheduleDetailsProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type CreatePreview'ScheduleDetails = {
        ///<summary>Controls how prorations and invoices for subscriptions are calculated and orchestrated.</summary>
        [<Config.Form>]BillingMode: CreatePreview'ScheduleDetailsBillingMode option
        ///<summary>Behavior of the subscription schedule and underlying subscription when it ends. Possible values are `release` or `cancel` with the default being `release`. `release` will end the subscription schedule and keep the underlying subscription running. `cancel` will end the subscription schedule and cancel the underlying subscription.</summary>
        [<Config.Form>]EndBehavior: CreatePreview'ScheduleDetailsEndBehavior option
        ///<summary>List representing phases of the subscription schedule. Each phase can be customized to have different durations, plans, and coupons. If there are multiple phases, the `end_date` of one phase will always equal the `start_date` of the next phase.</summary>
        [<Config.Form>]Phases: CreatePreview'ScheduleDetailsPhases list option
        ///<summary>In cases where the `schedule_details` params update the currently active phase, specifies if and how to prorate at the time of the request.</summary>
        [<Config.Form>]ProrationBehavior: CreatePreview'ScheduleDetailsProrationBehavior option
    }
    with
        static member New(?billingMode: CreatePreview'ScheduleDetailsBillingMode, ?endBehavior: CreatePreview'ScheduleDetailsEndBehavior, ?phases: CreatePreview'ScheduleDetailsPhases list, ?prorationBehavior: CreatePreview'ScheduleDetailsProrationBehavior) =
            {
                BillingMode = billingMode
                EndBehavior = endBehavior
                Phases = phases
                ProrationBehavior = prorationBehavior
            }

    type CreatePreview'SubscriptionDetailsBillingCycleAnchor =
    | Now
    | Unchanged

    type CreatePreview'SubscriptionDetailsBillingModeFlexibleProrationDiscounts =
    | Included
    | Itemized

    type CreatePreview'SubscriptionDetailsBillingModeFlexible = {
        ///<summary>Controls how invoices and invoice items display proration amounts and discount amounts.</summary>
        [<Config.Form>]ProrationDiscounts: CreatePreview'SubscriptionDetailsBillingModeFlexibleProrationDiscounts option
    }
    with
        static member New(?prorationDiscounts: CreatePreview'SubscriptionDetailsBillingModeFlexibleProrationDiscounts) =
            {
                ProrationDiscounts = prorationDiscounts
            }

    type CreatePreview'SubscriptionDetailsBillingModeType =
    | Classic
    | Flexible

    type CreatePreview'SubscriptionDetailsBillingMode = {
        ///<summary>Configure behavior for flexible billing mode.</summary>
        [<Config.Form>]Flexible: CreatePreview'SubscriptionDetailsBillingModeFlexible option
        ///<summary>Controls the calculation and orchestration of prorations and invoices for subscriptions. If no value is passed, the default is `flexible`.</summary>
        [<Config.Form>]Type: CreatePreview'SubscriptionDetailsBillingModeType option
    }
    with
        static member New(?flexible: CreatePreview'SubscriptionDetailsBillingModeFlexible, ?type': CreatePreview'SubscriptionDetailsBillingModeType) =
            {
                Flexible = flexible
                Type = type'
            }

    type CreatePreview'SubscriptionDetailsCancelAt =
    | MaxPeriodEnd
    | MinPeriodEnd

    type CreatePreview'SubscriptionDetailsItemsBillingThresholdsItemBillingThresholds = {
        ///<summary>Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))</summary>
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type CreatePreview'SubscriptionDetailsItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type CreatePreview'SubscriptionDetailsItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type CreatePreview'SubscriptionDetailsItemsPriceDataRecurring = {
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: CreatePreview'SubscriptionDetailsItemsPriceDataRecurringInterval option
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: CreatePreview'SubscriptionDetailsItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type CreatePreview'SubscriptionDetailsItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type CreatePreview'SubscriptionDetailsItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>The recurring components of a price such as `interval` and `interval_count`.</summary>
        [<Config.Form>]Recurring: CreatePreview'SubscriptionDetailsItemsPriceDataRecurring option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: CreatePreview'SubscriptionDetailsItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: CreatePreview'SubscriptionDetailsItemsPriceDataRecurring, ?taxBehavior: CreatePreview'SubscriptionDetailsItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type CreatePreview'SubscriptionDetailsItems = {
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<CreatePreview'SubscriptionDetailsItemsBillingThresholdsItemBillingThresholds,string> option
        ///<summary>Delete all usage for a given subscription item. You must pass this when deleting a usage records subscription item. `clear_usage` has no effect if the plan has a billing meter attached.</summary>
        [<Config.Form>]ClearUsage: bool option
        ///<summary>A flag that, if set to `true`, will delete the specified item.</summary>
        [<Config.Form>]Deleted: bool option
        ///<summary>The coupons to redeem into discounts for the subscription item.</summary>
        [<Config.Form>]Discounts: Choice<CreatePreview'SubscriptionDetailsItemsDiscounts list,string> option
        ///<summary>Subscription item to update.</summary>
        [<Config.Form>]Id: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Plan ID for this item, as a string.</summary>
        [<Config.Form>]Plan: string option
        ///<summary>The ID of the price object. One of `price` or `price_data` is required. When changing a subscription item's price, `quantity` is set to 1 unless a `quantity` parameter is provided.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]PriceData: CreatePreview'SubscriptionDetailsItemsPriceData option
        ///<summary>Quantity for this item.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?billingThresholds: Choice<CreatePreview'SubscriptionDetailsItemsBillingThresholdsItemBillingThresholds,string>, ?clearUsage: bool, ?deleted: bool, ?discounts: Choice<CreatePreview'SubscriptionDetailsItemsDiscounts list,string>, ?id: string, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: CreatePreview'SubscriptionDetailsItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                ClearUsage = clearUsage
                Deleted = deleted
                Discounts = discounts
                Id = id
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type CreatePreview'SubscriptionDetailsTrialEnd =
    | Now

    type CreatePreview'SubscriptionDetailsProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type CreatePreview'SubscriptionDetailsResumeAt =
    | Now

    type CreatePreview'SubscriptionDetails = {
        ///<summary>For new subscriptions, a future timestamp to anchor the subscription's [billing cycle](https://docs.stripe.com/subscriptions/billing-cycle). This is used to determine the date of the first full invoice, and, for plans with `month` or `year` intervals, the day of the month for subsequent invoices. For existing subscriptions, the value can only be set to `now` or `unchanged`.</summary>
        [<Config.Form>]BillingCycleAnchor: Choice<CreatePreview'SubscriptionDetailsBillingCycleAnchor,DateTime> option
        ///<summary>Controls how prorations and invoices for subscriptions are calculated and orchestrated.</summary>
        [<Config.Form>]BillingMode: CreatePreview'SubscriptionDetailsBillingMode option
        ///<summary>A timestamp at which the subscription should cancel. If set to a date before the current period ends, this will cause a proration if prorations have been enabled using `proration_behavior`. If set during a future period, this will always cause a proration for that period.</summary>
        [<Config.Form>]CancelAt: Choice<DateTime,string,CreatePreview'SubscriptionDetailsCancelAt> option
        ///<summary>Indicate whether this subscription should cancel at the end of the current period (`current_period_end`). Defaults to `false`.</summary>
        [<Config.Form>]CancelAtPeriodEnd: bool option
        ///<summary>This simulates the subscription being canceled or expired immediately.</summary>
        [<Config.Form>]CancelNow: bool option
        ///<summary>If provided, the invoice returned will preview updating or creating a subscription with these default tax rates. The default tax rates will apply to any line item that does not have `tax_rates` set.</summary>
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///<summary>A list of up to 20 subscription items, each with an attached price.</summary>
        [<Config.Form>]Items: CreatePreview'SubscriptionDetailsItems list option
        ///<summary>Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.</summary>
        [<Config.Form>]ProrationBehavior: CreatePreview'SubscriptionDetailsProrationBehavior option
        ///<summary>If previewing an update to a subscription, and doing proration, `subscription_details.proration_date` forces the proration to be calculated as though the update was done at the specified time. The time given must be within the current subscription period and within the current phase of the schedule backing this subscription, if the schedule exists. If set, `subscription`, and one of `subscription_details.items`, or `subscription_details.trial_end` are required. Also, `subscription_details.proration_behavior` cannot be set to 'none'.</summary>
        [<Config.Form>]ProrationDate: DateTime option
        ///<summary>For paused subscriptions, setting `subscription_details.resume_at` to `now` will preview the invoice that will be generated if the subscription is resumed.</summary>
        [<Config.Form>]ResumeAt: CreatePreview'SubscriptionDetailsResumeAt option
        ///<summary>Date a subscription is intended to start (can be future or past).</summary>
        [<Config.Form>]StartDate: DateTime option
        ///<summary>If provided, the invoice returned will preview updating or creating a subscription with that trial end. If set, one of `subscription_details.items` or `subscription` is required.</summary>
        [<Config.Form>]TrialEnd: Choice<CreatePreview'SubscriptionDetailsTrialEnd,DateTime> option
    }
    with
        static member New(?billingCycleAnchor: Choice<CreatePreview'SubscriptionDetailsBillingCycleAnchor,DateTime>, ?billingMode: CreatePreview'SubscriptionDetailsBillingMode, ?cancelAt: Choice<DateTime,string,CreatePreview'SubscriptionDetailsCancelAt>, ?cancelAtPeriodEnd: bool, ?cancelNow: bool, ?defaultTaxRates: Choice<string list,string>, ?items: CreatePreview'SubscriptionDetailsItems list, ?prorationBehavior: CreatePreview'SubscriptionDetailsProrationBehavior, ?prorationDate: DateTime, ?resumeAt: CreatePreview'SubscriptionDetailsResumeAt, ?startDate: DateTime, ?trialEnd: Choice<CreatePreview'SubscriptionDetailsTrialEnd,DateTime>) =
            {
                BillingCycleAnchor = billingCycleAnchor
                BillingMode = billingMode
                CancelAt = cancelAt
                CancelAtPeriodEnd = cancelAtPeriodEnd
                CancelNow = cancelNow
                DefaultTaxRates = defaultTaxRates
                Items = items
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
                ResumeAt = resumeAt
                StartDate = startDate
                TrialEnd = trialEnd
            }

    type CreatePreview'PreviewMode =
    | Next
    | Recurring

    type CreatePreviewOptions = {
        ///<summary>Settings for automatic tax lookup for this invoice preview.</summary>
        [<Config.Form>]AutomaticTax: CreatePreview'AutomaticTax option
        ///<summary>The currency to preview this invoice in. Defaults to that of `customer` if not specified.</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The identifier of the customer whose upcoming invoice you're retrieving. If `automatic_tax` is enabled then one of `customer`, `customer_details`, `subscription`, or `schedule` must be set.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>The identifier of the account representing the customer whose upcoming invoice you're retrieving. If `automatic_tax` is enabled then one of `customer`, `customer_account`, `customer_details`, `subscription`, or `schedule` must be set.</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>Details about the customer you want to invoice or overrides for an existing customer. If `automatic_tax` is enabled then one of `customer`, `customer_details`, `subscription`, or `schedule` must be set.</summary>
        [<Config.Form>]CustomerDetails: CreatePreview'CustomerDetails option
        ///<summary>The coupons to redeem into discounts for the invoice preview. If not specified, inherits the discount from the subscription or customer. This works for both coupons directly applied to an invoice and coupons applied to a subscription. Pass an empty string to avoid inheriting any discounts.</summary>
        [<Config.Form>]Discounts: Choice<CreatePreview'Discounts list,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>List of invoice items to add or update in the upcoming invoice preview (up to 250).</summary>
        [<Config.Form>]InvoiceItems: CreatePreview'InvoiceItems list option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: CreatePreview'Issuer option
        ///<summary>The account (if any) for which the funds of the invoice payment are intended. If set, the invoice will be presented with the branding and support information of the specified account. See the [Invoices with Connect](https://docs.stripe.com/billing/invoices/connect) documentation for details.</summary>
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///<summary>Customizes the types of values to include when calculating the invoice. Defaults to `next` if unspecified.</summary>
        [<Config.Form>]PreviewMode: CreatePreview'PreviewMode option
        ///<summary>The identifier of the schedule whose upcoming invoice you'd like to retrieve. Cannot be used with subscription or subscription fields.</summary>
        [<Config.Form>]Schedule: string option
        ///<summary>The schedule creation or modification params to apply as a preview. Cannot be used with `subscription` or `subscription_` prefixed fields.</summary>
        [<Config.Form>]ScheduleDetails: CreatePreview'ScheduleDetails option
        ///<summary>The identifier of the subscription for which you'd like to retrieve the upcoming invoice. If not provided, but a `subscription_details.items` is provided, you will preview creating a subscription with those items. If neither `subscription` nor `subscription_details.items` is provided, you will retrieve the next upcoming invoice from among the customer's subscriptions.</summary>
        [<Config.Form>]Subscription: string option
        ///<summary>The subscription creation or modification params to apply as a preview. Cannot be used with `schedule` or `schedule_details` fields.</summary>
        [<Config.Form>]SubscriptionDetails: CreatePreview'SubscriptionDetails option
    }
    with
        static member New(?automaticTax: CreatePreview'AutomaticTax, ?currency: IsoTypes.IsoCurrencyCode, ?customer: string, ?customerAccount: string, ?customerDetails: CreatePreview'CustomerDetails, ?discounts: Choice<CreatePreview'Discounts list,string>, ?expand: string list, ?invoiceItems: CreatePreview'InvoiceItems list, ?issuer: CreatePreview'Issuer, ?onBehalfOf: Choice<string,string>, ?previewMode: CreatePreview'PreviewMode, ?schedule: string, ?scheduleDetails: CreatePreview'ScheduleDetails, ?subscription: string, ?subscriptionDetails: CreatePreview'SubscriptionDetails) =
            {
                AutomaticTax = automaticTax
                Currency = currency
                Customer = customer
                CustomerAccount = customerAccount
                CustomerDetails = customerDetails
                Discounts = discounts
                Expand = expand
                InvoiceItems = invoiceItems
                Issuer = issuer
                OnBehalfOf = onBehalfOf
                PreviewMode = previewMode
                Schedule = schedule
                ScheduleDetails = scheduleDetails
                Subscription = subscription
                SubscriptionDetails = subscriptionDetails
            }

    ///<summary><p>At any time, you can preview the upcoming invoice for a subscription or subscription schedule. This will show you all the charges that are pending, including subscription renewal charges, invoice item charges, etc. It will also show you any discounts that are applicable to the invoice.</p>
    ///<p>You can also preview the effects of creating or updating a subscription or subscription schedule, including a preview of any prorations that will take place. To ensure that the actual proration is calculated exactly the same as the previewed proration, you should pass the <code>subscription_details.proration_date</code> parameter when doing the actual subscription update.</p>
    ///<p>The recommended way to get only the prorations being previewed on the invoice is to consider line items where <code>parent.subscription_item_details.proration</code> is <code>true</code>.</p>
    ///<p>Note that when you are viewing an upcoming invoice, you are simply viewing a preview – the invoice has not yet been created. As such, the upcoming invoice will not show up in invoice listing calls, and you cannot use the API to pay or edit the invoice. If you want to change the amount that your customer will be billed, you can add, remove, or update pending invoice items, or update the customer’s discount.</p>
    ///<p>Note: Currency conversion calculations use the latest exchange rates. Exchange rates may vary between the time of the preview and the time of the actual invoice creation. <a href="https://docs.stripe.com/currencies/conversions">Learn more</a></p></summary>
    let CreatePreview settings (options: CreatePreviewOptions) =
        $"/v1/invoices/create_preview"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesSearch =

    type SearchOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.</summary>
        [<Config.Query>]Page: string option
        ///<summary>The search query string. See [search query language](https://docs.stripe.com/search#search-query-language) and the list of supported [query fields for invoices](https://docs.stripe.com/search#query-fields-for-invoices).</summary>
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

    ///<summary><p>Search for invoices you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p></summary>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/invoices/search"
        |> RestApi.getAsync<StripeList<Invoice>> settings qs

module InvoicesAddLines =

    type AddLines'LinesDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type AddLines'LinesPeriod = {
        ///<summary>The end of the period, which must be greater than or equal to the start. This value is inclusive.</summary>
        [<Config.Form>]End: DateTime option
        ///<summary>The start of the period. This value is inclusive.</summary>
        [<Config.Form>]Start: DateTime option
    }
    with
        static member New(?end': DateTime, ?start: DateTime) =
            {
                End = end'
                Start = start
            }

    type AddLines'LinesPriceDataProductData = {
        ///<summary>The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.</summary>
        [<Config.Form>]Description: string option
        ///<summary>A list of up to 8 URLs of images for this product, meant to be displayable to the customer.</summary>
        [<Config.Form>]Images: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The product's name, meant to be displayable to the customer.</summary>
        [<Config.Form>]Name: string option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID.</summary>
        [<Config.Form>]TaxCode: string option
        ///<summary>A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.</summary>
        [<Config.Form>]UnitLabel: string option
    }
    with
        static member New(?description: string, ?images: string list, ?metadata: Map<string, string>, ?name: string, ?taxCode: string, ?unitLabel: string) =
            {
                Description = description
                Images = images
                Metadata = metadata
                Name = name
                TaxCode = taxCode
                UnitLabel = unitLabel
            }

    type AddLines'LinesPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type AddLines'LinesPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to. One of `product` or `product_data` is required.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Data used to generate a new [Product](https://docs.stripe.com/api/products) object inline. One of `product` or `product_data` is required.</summary>
        [<Config.Form>]ProductData: AddLines'LinesPriceDataProductData option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: AddLines'LinesPriceDataTaxBehavior option
        ///<summary>A non-negative integer in cents (or local equivalent) representing how much to charge. One of `unit_amount` or `unit_amount_decimal` is required.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?productData: AddLines'LinesPriceDataProductData, ?taxBehavior: AddLines'LinesPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                ProductData = productData
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type AddLines'LinesPricing = {
        ///<summary>The ID of the price object.</summary>
        [<Config.Form>]Price: string option
    }
    with
        static member New(?price: string) =
            {
                Price = price
            }

    type AddLines'LinesTaxAmountsTaxRateDataJurisdictionLevel =
    | City
    | Country
    | County
    | District
    | Multiple
    | State

    type AddLines'LinesTaxAmountsTaxRateDataTaxType =
    | AmusementTax
    | CommunicationsTax
    | Gst
    | Hst
    | Igst
    | Jct
    | LeaseTax
    | Pst
    | Qst
    | RetailDeliveryFee
    | Rst
    | SalesTax
    | ServiceTax
    | Vat

    type AddLines'LinesTaxAmountsTaxRateData = {
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.</summary>
        [<Config.Form>]Description: string option
        ///<summary>The display name of the tax rate, which will be shown to users.</summary>
        [<Config.Form>]DisplayName: string option
        ///<summary>This specifies if the tax rate is inclusive or exclusive.</summary>
        [<Config.Form>]Inclusive: bool option
        ///<summary>The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.</summary>
        [<Config.Form>]Jurisdiction: string option
        ///<summary>The level of the jurisdiction that imposes this tax rate.</summary>
        [<Config.Form>]JurisdictionLevel: AddLines'LinesTaxAmountsTaxRateDataJurisdictionLevel option
        ///<summary>The statutory tax rate percent. This field accepts decimal values between 0 and 100 inclusive with at most 4 decimal places. To accommodate fixed-amount taxes, set the percentage to zero. Stripe will not display zero percentages on the invoice unless the `amount` of the tax is also zero.</summary>
        [<Config.Form>]Percentage: decimal option
        ///<summary>[ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2:US), without country prefix. For example, "NY" for New York, United States.</summary>
        [<Config.Form>]State: string option
        ///<summary>The high-level tax type, such as `vat` or `sales_tax`.</summary>
        [<Config.Form>]TaxType: AddLines'LinesTaxAmountsTaxRateDataTaxType option
    }
    with
        static member New(?country: IsoTypes.IsoCountryCode, ?description: string, ?displayName: string, ?inclusive: bool, ?jurisdiction: string, ?jurisdictionLevel: AddLines'LinesTaxAmountsTaxRateDataJurisdictionLevel, ?percentage: decimal, ?state: string, ?taxType: AddLines'LinesTaxAmountsTaxRateDataTaxType) =
            {
                Country = country
                Description = description
                DisplayName = displayName
                Inclusive = inclusive
                Jurisdiction = jurisdiction
                JurisdictionLevel = jurisdictionLevel
                Percentage = percentage
                State = state
                TaxType = taxType
            }

    type AddLines'LinesTaxAmountsTaxabilityReason =
    | CustomerExempt
    | NotCollecting
    | NotSubjectToTax
    | NotSupported
    | PortionProductExempt
    | PortionReducedRated
    | PortionStandardRated
    | ProductExempt
    | ProductExemptHoliday
    | ProportionallyRated
    | ReducedRated
    | ReverseCharge
    | StandardRated
    | TaxableBasisReduced
    | ZeroRated

    type AddLines'LinesTaxAmounts = {
        ///<summary>The amount, in cents (or local equivalent), of the tax.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Data to find or create a TaxRate object.
        ///Stripe automatically creates or reuses a TaxRate object for each tax amount. If the `tax_rate_data` exactly matches a previous value, Stripe will reuse the TaxRate object. TaxRate objects created automatically by Stripe are immediately archived, do not appear in the line item’s `tax_rates`, and cannot be directly added to invoices, payments, or line items.</summary>
        [<Config.Form>]TaxRateData: AddLines'LinesTaxAmountsTaxRateData option
        ///<summary>The reasoning behind this tax, for example, if the product is tax exempt.</summary>
        [<Config.Form>]TaxabilityReason: AddLines'LinesTaxAmountsTaxabilityReason option
        ///<summary>The amount on which tax is calculated, in cents (or local equivalent).</summary>
        [<Config.Form>]TaxableAmount: int option
    }
    with
        static member New(?amount: int, ?taxRateData: AddLines'LinesTaxAmountsTaxRateData, ?taxabilityReason: AddLines'LinesTaxAmountsTaxabilityReason, ?taxableAmount: int) =
            {
                Amount = amount
                TaxRateData = taxRateData
                TaxabilityReason = taxabilityReason
                TaxableAmount = taxableAmount
            }

    type AddLines'Lines = {
        ///<summary>The integer amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. If you want to apply a credit to the customer's account, pass a negative amount.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Controls whether discounts apply to this line item. Defaults to false for prorations or negative line items, and true for all other line items. Cannot be set to true for prorations.</summary>
        [<Config.Form>]Discountable: bool option
        ///<summary>The coupons, promotion codes & existing discounts which apply to the line item. Item discounts are applied before invoice discounts. Pass an empty string to remove previously-defined discounts.</summary>
        [<Config.Form>]Discounts: Choice<AddLines'LinesDiscounts list,string> option
        ///<summary>ID of an unassigned invoice item to assign to this invoice. If not provided, a new item will be created.</summary>
        [<Config.Form>]InvoiceItem: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://docs.stripe.com/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://docs.stripe.com/revenue-recognition/methodology/subscriptions-and-invoicing) for details.</summary>
        [<Config.Form>]Period: AddLines'LinesPeriod option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.</summary>
        [<Config.Form>]PriceData: AddLines'LinesPriceData option
        ///<summary>The pricing information for the invoice item.</summary>
        [<Config.Form>]Pricing: AddLines'LinesPricing option
        ///<summary>Non-negative integer. The quantity of units for the line item. Use `quantity_decimal` instead to provide decimal precision. This field will be deprecated in favor of `quantity_decimal` in a future version.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>Non-negative decimal with at most 12 decimal places. The quantity of units for the line item.</summary>
        [<Config.Form>]QuantityDecimal: string option
        ///<summary>A list of up to 10 tax amounts for this line item. This can be useful if you calculate taxes on your own or use a third-party to calculate them. You cannot set tax amounts if any line item has [tax_rates](https://docs.stripe.com/api/invoices/line_item#invoice_line_item_object-tax_rates) or if the invoice has [default_tax_rates](https://docs.stripe.com/api/invoices/object#invoice_object-default_tax_rates) or uses [automatic tax](https://docs.stripe.com/tax/invoicing). Pass an empty string to remove previously defined tax amounts.</summary>
        [<Config.Form>]TaxAmounts: Choice<AddLines'LinesTaxAmounts list,string> option
        ///<summary>The tax rates which apply to the line item. When set, the `default_tax_rates` on the invoice do not apply to this line item. Pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?amount: int, ?description: string, ?discountable: bool, ?discounts: Choice<AddLines'LinesDiscounts list,string>, ?invoiceItem: string, ?metadata: Map<string, string>, ?period: AddLines'LinesPeriod, ?priceData: AddLines'LinesPriceData, ?pricing: AddLines'LinesPricing, ?quantity: int, ?quantityDecimal: string, ?taxAmounts: Choice<AddLines'LinesTaxAmounts list,string>, ?taxRates: Choice<string list,string>) =
            {
                Amount = amount
                Description = description
                Discountable = discountable
                Discounts = discounts
                InvoiceItem = invoiceItem
                Metadata = metadata
                Period = period
                PriceData = priceData
                Pricing = pricing
                Quantity = quantity
                QuantityDecimal = quantityDecimal
                TaxAmounts = taxAmounts
                TaxRates = taxRates
            }

    type AddLinesOptions = {
        [<Config.Path>]Invoice: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]InvoiceMetadata: Choice<Map<string, string>,string> option
        ///<summary>The line items to add.</summary>
        [<Config.Form>]Lines: AddLines'Lines list
    }
    with
        static member New(invoice: string, lines: AddLines'Lines list, ?expand: string list, ?invoiceMetadata: Choice<Map<string, string>,string>) =
            {
                Invoice = invoice
                Expand = expand
                InvoiceMetadata = invoiceMetadata
                Lines = lines
            }

    ///<summary><p>Adds multiple line items to an invoice. This is only possible when an invoice is still a draft.</p></summary>
    let AddLines settings (options: AddLinesOptions) =
        $"/v1/invoices/{options.Invoice}/add_lines"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesAttachPayment =

    type AttachPaymentOptions = {
        [<Config.Path>]Invoice: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The ID of the PaymentIntent to attach to the invoice.</summary>
        [<Config.Form>]PaymentIntent: string option
        ///<summary>The ID of the PaymentRecord to attach to the invoice.</summary>
        [<Config.Form>]PaymentRecord: string option
    }
    with
        static member New(invoice: string, ?expand: string list, ?paymentIntent: string, ?paymentRecord: string) =
            {
                Invoice = invoice
                Expand = expand
                PaymentIntent = paymentIntent
                PaymentRecord = paymentRecord
            }

    ///<summary><p>Attaches a PaymentIntent or an Out of Band Payment to the invoice, adding it to the list of <code>payments</code>.</p>
    ///<p>For the PaymentIntent, when the PaymentIntent’s status changes to <code>succeeded</code>, the payment is credited
    ///to the invoice, increasing its <code>amount_paid</code>. When the invoice is fully paid, the
    ///invoice’s status becomes <code>paid</code>.</p>
    ///<p>If the PaymentIntent’s status is already <code>succeeded</code> when it’s attached, it’s
    ///credited to the invoice immediately.</p>
    ///<p>See: <a href="/docs/invoicing/partial-payments">Partial payments</a> to learn more.</p></summary>
    let AttachPayment settings (options: AttachPaymentOptions) =
        $"/v1/invoices/{options.Invoice}/attach_payment"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesFinalize =

    type FinalizeInvoiceOptions = {
        [<Config.Path>]Invoice: string
        ///<summary>Controls whether Stripe performs [automatic collection](https://docs.stripe.com/invoicing/integration/automatic-advancement-collection) of the invoice. If `false`, the invoice's state doesn't automatically advance without an explicit action.</summary>
        [<Config.Form>]AutoAdvance: bool option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(invoice: string, ?autoAdvance: bool, ?expand: string list) =
            {
                Invoice = invoice
                AutoAdvance = autoAdvance
                Expand = expand
            }

    ///<summary><p>Stripe automatically finalizes drafts before sending and attempting payment on invoices. However, if you’d like to finalize a draft invoice manually, you can do so using this method.</p></summary>
    let FinalizeInvoice settings (options: FinalizeInvoiceOptions) =
        $"/v1/invoices/{options.Invoice}/finalize"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesLines =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Invoice: string
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(invoice: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Invoice = invoice
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>When retrieving an invoice, you’ll get a <strong>lines</strong> property containing the total count of line items and the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/invoices/{options.Invoice}/lines"
        |> RestApi.getAsync<StripeList<LineItem>> settings qs

    type Update'Discounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'Period = {
        ///<summary>The end of the period, which must be greater than or equal to the start. This value is inclusive.</summary>
        [<Config.Form>]End: DateTime option
        ///<summary>The start of the period. This value is inclusive.</summary>
        [<Config.Form>]Start: DateTime option
    }
    with
        static member New(?end': DateTime, ?start: DateTime) =
            {
                End = end'
                Start = start
            }

    type Update'PriceDataProductData = {
        ///<summary>The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.</summary>
        [<Config.Form>]Description: string option
        ///<summary>A list of up to 8 URLs of images for this product, meant to be displayable to the customer.</summary>
        [<Config.Form>]Images: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The product's name, meant to be displayable to the customer.</summary>
        [<Config.Form>]Name: string option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID.</summary>
        [<Config.Form>]TaxCode: string option
        ///<summary>A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.</summary>
        [<Config.Form>]UnitLabel: string option
    }
    with
        static member New(?description: string, ?images: string list, ?metadata: Map<string, string>, ?name: string, ?taxCode: string, ?unitLabel: string) =
            {
                Description = description
                Images = images
                Metadata = metadata
                Name = name
                TaxCode = taxCode
                UnitLabel = unitLabel
            }

    type Update'PriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'PriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to. One of `product` or `product_data` is required.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Data used to generate a new [Product](https://docs.stripe.com/api/products) object inline. One of `product` or `product_data` is required.</summary>
        [<Config.Form>]ProductData: Update'PriceDataProductData option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Update'PriceDataTaxBehavior option
        ///<summary>A non-negative integer in cents (or local equivalent) representing how much to charge. One of `unit_amount` or `unit_amount_decimal` is required.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?productData: Update'PriceDataProductData, ?taxBehavior: Update'PriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                ProductData = productData
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'Pricing = {
        ///<summary>The ID of the price object.</summary>
        [<Config.Form>]Price: string option
    }
    with
        static member New(?price: string) =
            {
                Price = price
            }

    type Update'TaxAmountsTaxRateDataJurisdictionLevel =
    | City
    | Country
    | County
    | District
    | Multiple
    | State

    type Update'TaxAmountsTaxRateDataTaxType =
    | AmusementTax
    | CommunicationsTax
    | Gst
    | Hst
    | Igst
    | Jct
    | LeaseTax
    | Pst
    | Qst
    | RetailDeliveryFee
    | Rst
    | SalesTax
    | ServiceTax
    | Vat

    type Update'TaxAmountsTaxRateData = {
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.</summary>
        [<Config.Form>]Description: string option
        ///<summary>The display name of the tax rate, which will be shown to users.</summary>
        [<Config.Form>]DisplayName: string option
        ///<summary>This specifies if the tax rate is inclusive or exclusive.</summary>
        [<Config.Form>]Inclusive: bool option
        ///<summary>The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.</summary>
        [<Config.Form>]Jurisdiction: string option
        ///<summary>The level of the jurisdiction that imposes this tax rate.</summary>
        [<Config.Form>]JurisdictionLevel: Update'TaxAmountsTaxRateDataJurisdictionLevel option
        ///<summary>The statutory tax rate percent. This field accepts decimal values between 0 and 100 inclusive with at most 4 decimal places. To accommodate fixed-amount taxes, set the percentage to zero. Stripe will not display zero percentages on the invoice unless the `amount` of the tax is also zero.</summary>
        [<Config.Form>]Percentage: decimal option
        ///<summary>[ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2:US), without country prefix. For example, "NY" for New York, United States.</summary>
        [<Config.Form>]State: string option
        ///<summary>The high-level tax type, such as `vat` or `sales_tax`.</summary>
        [<Config.Form>]TaxType: Update'TaxAmountsTaxRateDataTaxType option
    }
    with
        static member New(?country: IsoTypes.IsoCountryCode, ?description: string, ?displayName: string, ?inclusive: bool, ?jurisdiction: string, ?jurisdictionLevel: Update'TaxAmountsTaxRateDataJurisdictionLevel, ?percentage: decimal, ?state: string, ?taxType: Update'TaxAmountsTaxRateDataTaxType) =
            {
                Country = country
                Description = description
                DisplayName = displayName
                Inclusive = inclusive
                Jurisdiction = jurisdiction
                JurisdictionLevel = jurisdictionLevel
                Percentage = percentage
                State = state
                TaxType = taxType
            }

    type Update'TaxAmountsTaxabilityReason =
    | CustomerExempt
    | NotCollecting
    | NotSubjectToTax
    | NotSupported
    | PortionProductExempt
    | PortionReducedRated
    | PortionStandardRated
    | ProductExempt
    | ProductExemptHoliday
    | ProportionallyRated
    | ReducedRated
    | ReverseCharge
    | StandardRated
    | TaxableBasisReduced
    | ZeroRated

    type Update'TaxAmounts = {
        ///<summary>The amount, in cents (or local equivalent), of the tax.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Data to find or create a TaxRate object.
        ///Stripe automatically creates or reuses a TaxRate object for each tax amount. If the `tax_rate_data` exactly matches a previous value, Stripe will reuse the TaxRate object. TaxRate objects created automatically by Stripe are immediately archived, do not appear in the line item’s `tax_rates`, and cannot be directly added to invoices, payments, or line items.</summary>
        [<Config.Form>]TaxRateData: Update'TaxAmountsTaxRateData option
        ///<summary>The reasoning behind this tax, for example, if the product is tax exempt.</summary>
        [<Config.Form>]TaxabilityReason: Update'TaxAmountsTaxabilityReason option
        ///<summary>The amount on which tax is calculated, in cents (or local equivalent).</summary>
        [<Config.Form>]TaxableAmount: int option
    }
    with
        static member New(?amount: int, ?taxRateData: Update'TaxAmountsTaxRateData, ?taxabilityReason: Update'TaxAmountsTaxabilityReason, ?taxableAmount: int) =
            {
                Amount = amount
                TaxRateData = taxRateData
                TaxabilityReason = taxabilityReason
                TaxableAmount = taxableAmount
            }

    type UpdateOptions = {
        ///<summary>Invoice ID of line item</summary>
        [<Config.Path>]Invoice: string
        ///<summary>Invoice line item ID</summary>
        [<Config.Path>]LineItemId: string
        ///<summary>The integer amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. If you want to apply a credit to the customer's account, pass a negative amount.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Controls whether discounts apply to this line item. Defaults to false for prorations or negative line items, and true for all other line items. Cannot be set to true for prorations.</summary>
        [<Config.Form>]Discountable: bool option
        ///<summary>The coupons, promotion codes & existing discounts which apply to the line item. Item discounts are applied before invoice discounts. Pass an empty string to remove previously-defined discounts.</summary>
        [<Config.Form>]Discounts: Choice<Update'Discounts list,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`. For [type=subscription](/api/invoices/line_item) line items, the incoming metadata specified on the request is directly used to set this value, in contrast to [type=invoiceitem](/api/invoices/line_item) line items, where any existing metadata on the invoice line is merged with the incoming data.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://docs.stripe.com/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://docs.stripe.com/revenue-recognition/methodology/subscriptions-and-invoicing) for details.</summary>
        [<Config.Form>]Period: Update'Period option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.</summary>
        [<Config.Form>]PriceData: Update'PriceData option
        ///<summary>The pricing information for the invoice item.</summary>
        [<Config.Form>]Pricing: Update'Pricing option
        ///<summary>Non-negative integer. The quantity of units for the line item. Use `quantity_decimal` instead to provide decimal precision. This field will be deprecated in favor of `quantity_decimal` in a future version.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>Non-negative decimal with at most 12 decimal places. The quantity of units for the line item.</summary>
        [<Config.Form>]QuantityDecimal: string option
        ///<summary>A list of up to 10 tax amounts for this line item. This can be useful if you calculate taxes on your own or use a third-party to calculate them. You cannot set tax amounts if any line item has [tax_rates](https://docs.stripe.com/api/invoices/line_item#invoice_line_item_object-tax_rates) or if the invoice has [default_tax_rates](https://docs.stripe.com/api/invoices/object#invoice_object-default_tax_rates) or uses [automatic tax](https://docs.stripe.com/tax/invoicing). Pass an empty string to remove previously defined tax amounts.</summary>
        [<Config.Form>]TaxAmounts: Choice<Update'TaxAmounts list,string> option
        ///<summary>The tax rates which apply to the line item. When set, the `default_tax_rates` on the invoice do not apply to this line item. Pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(invoice: string, lineItemId: string, ?amount: int, ?description: string, ?discountable: bool, ?discounts: Choice<Update'Discounts list,string>, ?expand: string list, ?metadata: Map<string, string>, ?period: Update'Period, ?priceData: Update'PriceData, ?pricing: Update'Pricing, ?quantity: int, ?quantityDecimal: string, ?taxAmounts: Choice<Update'TaxAmounts list,string>, ?taxRates: Choice<string list,string>) =
            {
                Invoice = invoice
                LineItemId = lineItemId
                Amount = amount
                Description = description
                Discountable = discountable
                Discounts = discounts
                Expand = expand
                Metadata = metadata
                Period = period
                PriceData = priceData
                Pricing = pricing
                Quantity = quantity
                QuantityDecimal = quantityDecimal
                TaxAmounts = taxAmounts
                TaxRates = taxRates
            }

    ///<summary><p>Updates an invoice’s line item. Some fields, such as <code>tax_amounts</code>, only live on the invoice line item,
    ///so they can only be updated through this endpoint. Other fields, such as <code>amount</code>, live on both the invoice
    ///item and the invoice line item, so updates on this endpoint will propagate to the invoice item as well.
    ///Updating an invoice’s line item is only possible before the invoice is finalized.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/invoices/{options.Invoice}/lines/{options.LineItemId}"
        |> RestApi.postAsync<_, LineItem> settings (Map.empty) options

module InvoicesMarkUncollectible =

    type MarkUncollectibleOptions = {
        [<Config.Path>]Invoice: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(invoice: string, ?expand: string list) =
            {
                Invoice = invoice
                Expand = expand
            }

    ///<summary><p>Marking an invoice as uncollectible is useful for keeping track of bad debts that can be written off for accounting purposes.</p></summary>
    let MarkUncollectible settings (options: MarkUncollectibleOptions) =
        $"/v1/invoices/{options.Invoice}/mark_uncollectible"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesPay =

    type PayOptions = {
        [<Config.Path>]Invoice: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>In cases where the source used to pay the invoice has insufficient funds, passing `forgive=true` controls whether a charge should be attempted for the full amount available on the source, up to the amount to fully pay the invoice. This effectively forgives the difference between the amount available on the source and the amount due. 
        ///Passing `forgive=false` will fail the charge if the source hasn't been pre-funded with the right amount. An example for this case is with ACH Credit Transfers and wires: if the amount wired is less than the amount due by a small amount, you might want to forgive the difference. Defaults to `false`.</summary>
        [<Config.Form>]Forgive: bool option
        ///<summary>ID of the mandate to be used for this invoice. It must correspond to the payment method used to pay the invoice, including the payment_method param or the invoice's default_payment_method or default_source, if set.</summary>
        [<Config.Form>]Mandate: Choice<string,string> option
        ///<summary>Indicates if a customer is on or off-session while an invoice payment is attempted. Defaults to `true` (off-session).</summary>
        [<Config.Form>]OffSession: bool option
        ///<summary>Boolean representing whether an invoice is paid outside of Stripe. This will result in no charge being made. Defaults to `false`.</summary>
        [<Config.Form>]PaidOutOfBand: bool option
        ///<summary>A PaymentMethod to be charged. The PaymentMethod must be the ID of a PaymentMethod belonging to the customer associated with the invoice being paid.</summary>
        [<Config.Form>]PaymentMethod: string option
        ///<summary>A payment source to be charged. The source must be the ID of a source belonging to the customer associated with the invoice being paid.</summary>
        [<Config.Form>]Source: string option
    }
    with
        static member New(invoice: string, ?expand: string list, ?forgive: bool, ?mandate: Choice<string,string>, ?offSession: bool, ?paidOutOfBand: bool, ?paymentMethod: string, ?source: string) =
            {
                Invoice = invoice
                Expand = expand
                Forgive = forgive
                Mandate = mandate
                OffSession = offSession
                PaidOutOfBand = paidOutOfBand
                PaymentMethod = paymentMethod
                Source = source
            }

    ///<summary><p>Stripe automatically creates and then attempts to collect payment on invoices for customers on subscriptions according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to attempt payment on an invoice out of the normal collection schedule or for some other reason, you can do so.</p></summary>
    let Pay settings (options: PayOptions) =
        $"/v1/invoices/{options.Invoice}/pay"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesRemoveLines =

    type RemoveLines'LinesBehavior =
    | Delete
    | Unassign

    type RemoveLines'Lines = {
        ///<summary>Either `delete` or `unassign`. Deleted line items are permanently deleted. Unassigned line items can be reassigned to an invoice.</summary>
        [<Config.Form>]Behavior: RemoveLines'LinesBehavior option
        ///<summary>ID of an existing line item to remove from this invoice.</summary>
        [<Config.Form>]Id: string option
    }
    with
        static member New(?behavior: RemoveLines'LinesBehavior, ?id: string) =
            {
                Behavior = behavior
                Id = id
            }

    type RemoveLinesOptions = {
        [<Config.Path>]Invoice: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]InvoiceMetadata: Choice<Map<string, string>,string> option
        ///<summary>The line items to remove.</summary>
        [<Config.Form>]Lines: RemoveLines'Lines list
    }
    with
        static member New(invoice: string, lines: RemoveLines'Lines list, ?expand: string list, ?invoiceMetadata: Choice<Map<string, string>,string>) =
            {
                Invoice = invoice
                Expand = expand
                InvoiceMetadata = invoiceMetadata
                Lines = lines
            }

    ///<summary><p>Removes multiple line items from an invoice. This is only possible when an invoice is still a draft.</p></summary>
    let RemoveLines settings (options: RemoveLinesOptions) =
        $"/v1/invoices/{options.Invoice}/remove_lines"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesSend =

    type SendInvoiceOptions = {
        [<Config.Path>]Invoice: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(invoice: string, ?expand: string list) =
            {
                Invoice = invoice
                Expand = expand
            }

    ///<summary><p>Stripe will automatically send invoices to customers according to your <a href="https://dashboard.stripe.com/account/billing/automatic">subscriptions settings</a>. However, if you’d like to manually send an invoice to your customer out of the normal schedule, you can do so. When sending invoices that have already been paid, there will be no reference to the payment in the email.</p>
    ///<p>Requests made in test-mode result in no emails being sent, despite sending an <code>invoice.sent</code> event.</p></summary>
    let SendInvoice settings (options: SendInvoiceOptions) =
        $"/v1/invoices/{options.Invoice}/send"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesUpdateLines =

    type UpdateLines'LinesDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type UpdateLines'LinesPeriod = {
        ///<summary>The end of the period, which must be greater than or equal to the start. This value is inclusive.</summary>
        [<Config.Form>]End: DateTime option
        ///<summary>The start of the period. This value is inclusive.</summary>
        [<Config.Form>]Start: DateTime option
    }
    with
        static member New(?end': DateTime, ?start: DateTime) =
            {
                End = end'
                Start = start
            }

    type UpdateLines'LinesPriceDataProductData = {
        ///<summary>The product's description, meant to be displayable to the customer. Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.</summary>
        [<Config.Form>]Description: string option
        ///<summary>A list of up to 8 URLs of images for this product, meant to be displayable to the customer.</summary>
        [<Config.Form>]Images: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The product's name, meant to be displayable to the customer.</summary>
        [<Config.Form>]Name: string option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID.</summary>
        [<Config.Form>]TaxCode: string option
        ///<summary>A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.</summary>
        [<Config.Form>]UnitLabel: string option
    }
    with
        static member New(?description: string, ?images: string list, ?metadata: Map<string, string>, ?name: string, ?taxCode: string, ?unitLabel: string) =
            {
                Description = description
                Images = images
                Metadata = metadata
                Name = name
                TaxCode = taxCode
                UnitLabel = unitLabel
            }

    type UpdateLines'LinesPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type UpdateLines'LinesPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to. One of `product` or `product_data` is required.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Data used to generate a new [Product](https://docs.stripe.com/api/products) object inline. One of `product` or `product_data` is required.</summary>
        [<Config.Form>]ProductData: UpdateLines'LinesPriceDataProductData option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: UpdateLines'LinesPriceDataTaxBehavior option
        ///<summary>A non-negative integer in cents (or local equivalent) representing how much to charge. One of `unit_amount` or `unit_amount_decimal` is required.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?productData: UpdateLines'LinesPriceDataProductData, ?taxBehavior: UpdateLines'LinesPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                ProductData = productData
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type UpdateLines'LinesPricing = {
        ///<summary>The ID of the price object.</summary>
        [<Config.Form>]Price: string option
    }
    with
        static member New(?price: string) =
            {
                Price = price
            }

    type UpdateLines'LinesTaxAmountsTaxRateDataJurisdictionLevel =
    | City
    | Country
    | County
    | District
    | Multiple
    | State

    type UpdateLines'LinesTaxAmountsTaxRateDataTaxType =
    | AmusementTax
    | CommunicationsTax
    | Gst
    | Hst
    | Igst
    | Jct
    | LeaseTax
    | Pst
    | Qst
    | RetailDeliveryFee
    | Rst
    | SalesTax
    | ServiceTax
    | Vat

    type UpdateLines'LinesTaxAmountsTaxRateData = {
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.</summary>
        [<Config.Form>]Description: string option
        ///<summary>The display name of the tax rate, which will be shown to users.</summary>
        [<Config.Form>]DisplayName: string option
        ///<summary>This specifies if the tax rate is inclusive or exclusive.</summary>
        [<Config.Form>]Inclusive: bool option
        ///<summary>The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.</summary>
        [<Config.Form>]Jurisdiction: string option
        ///<summary>The level of the jurisdiction that imposes this tax rate.</summary>
        [<Config.Form>]JurisdictionLevel: UpdateLines'LinesTaxAmountsTaxRateDataJurisdictionLevel option
        ///<summary>The statutory tax rate percent. This field accepts decimal values between 0 and 100 inclusive with at most 4 decimal places. To accommodate fixed-amount taxes, set the percentage to zero. Stripe will not display zero percentages on the invoice unless the `amount` of the tax is also zero.</summary>
        [<Config.Form>]Percentage: decimal option
        ///<summary>[ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2:US), without country prefix. For example, "NY" for New York, United States.</summary>
        [<Config.Form>]State: string option
        ///<summary>The high-level tax type, such as `vat` or `sales_tax`.</summary>
        [<Config.Form>]TaxType: UpdateLines'LinesTaxAmountsTaxRateDataTaxType option
    }
    with
        static member New(?country: IsoTypes.IsoCountryCode, ?description: string, ?displayName: string, ?inclusive: bool, ?jurisdiction: string, ?jurisdictionLevel: UpdateLines'LinesTaxAmountsTaxRateDataJurisdictionLevel, ?percentage: decimal, ?state: string, ?taxType: UpdateLines'LinesTaxAmountsTaxRateDataTaxType) =
            {
                Country = country
                Description = description
                DisplayName = displayName
                Inclusive = inclusive
                Jurisdiction = jurisdiction
                JurisdictionLevel = jurisdictionLevel
                Percentage = percentage
                State = state
                TaxType = taxType
            }

    type UpdateLines'LinesTaxAmountsTaxabilityReason =
    | CustomerExempt
    | NotCollecting
    | NotSubjectToTax
    | NotSupported
    | PortionProductExempt
    | PortionReducedRated
    | PortionStandardRated
    | ProductExempt
    | ProductExemptHoliday
    | ProportionallyRated
    | ReducedRated
    | ReverseCharge
    | StandardRated
    | TaxableBasisReduced
    | ZeroRated

    type UpdateLines'LinesTaxAmounts = {
        ///<summary>The amount, in cents (or local equivalent), of the tax.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Data to find or create a TaxRate object.
        ///Stripe automatically creates or reuses a TaxRate object for each tax amount. If the `tax_rate_data` exactly matches a previous value, Stripe will reuse the TaxRate object. TaxRate objects created automatically by Stripe are immediately archived, do not appear in the line item’s `tax_rates`, and cannot be directly added to invoices, payments, or line items.</summary>
        [<Config.Form>]TaxRateData: UpdateLines'LinesTaxAmountsTaxRateData option
        ///<summary>The reasoning behind this tax, for example, if the product is tax exempt.</summary>
        [<Config.Form>]TaxabilityReason: UpdateLines'LinesTaxAmountsTaxabilityReason option
        ///<summary>The amount on which tax is calculated, in cents (or local equivalent).</summary>
        [<Config.Form>]TaxableAmount: int option
    }
    with
        static member New(?amount: int, ?taxRateData: UpdateLines'LinesTaxAmountsTaxRateData, ?taxabilityReason: UpdateLines'LinesTaxAmountsTaxabilityReason, ?taxableAmount: int) =
            {
                Amount = amount
                TaxRateData = taxRateData
                TaxabilityReason = taxabilityReason
                TaxableAmount = taxableAmount
            }

    type UpdateLines'Lines = {
        ///<summary>The integer amount in cents (or local equivalent) of the charge to be applied to the upcoming invoice. If you want to apply a credit to the customer's account, pass a negative amount.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>An arbitrary string which you can attach to the invoice item. The description is displayed in the invoice for easy tracking.</summary>
        [<Config.Form>]Description: string option
        ///<summary>Controls whether discounts apply to this line item. Defaults to false for prorations or negative line items, and true for all other line items. Cannot be set to true for prorations.</summary>
        [<Config.Form>]Discountable: bool option
        ///<summary>The coupons, promotion codes & existing discounts which apply to the line item. Item discounts are applied before invoice discounts. Pass an empty string to remove previously-defined discounts.</summary>
        [<Config.Form>]Discounts: Choice<UpdateLines'LinesDiscounts list,string> option
        ///<summary>ID of an existing line item on the invoice.</summary>
        [<Config.Form>]Id: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`. For [type=subscription](https://docs.stripe.com/api/invoices/line_item#invoice_line_item_object-type) line items, the incoming metadata specified on the request is directly used to set this value, in contrast to [type=invoiceitem](api/invoices/line_item#invoice_line_item_object-type) line items, where any existing metadata on the invoice line is merged with the incoming data.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The period associated with this invoice item. When set to different values, the period will be rendered on the invoice. If you have [Stripe Revenue Recognition](https://docs.stripe.com/revenue-recognition) enabled, the period will be used to recognize and defer revenue. See the [Revenue Recognition documentation](https://docs.stripe.com/revenue-recognition/methodology/subscriptions-and-invoicing) for details.</summary>
        [<Config.Form>]Period: UpdateLines'LinesPeriod option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.</summary>
        [<Config.Form>]PriceData: UpdateLines'LinesPriceData option
        ///<summary>The pricing information for the invoice item.</summary>
        [<Config.Form>]Pricing: UpdateLines'LinesPricing option
        ///<summary>Non-negative integer. The quantity of units for the line item. Use `quantity_decimal` instead to provide decimal precision. This field will be deprecated in favor of `quantity_decimal` in a future version.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>Non-negative decimal with at most 12 decimal places. The quantity of units for the line item.</summary>
        [<Config.Form>]QuantityDecimal: string option
        ///<summary>A list of up to 10 tax amounts for this line item. This can be useful if you calculate taxes on your own or use a third-party to calculate them. You cannot set tax amounts if any line item has [tax_rates](https://docs.stripe.com/api/invoices/line_item#invoice_line_item_object-tax_rates) or if the invoice has [default_tax_rates](https://docs.stripe.com/api/invoices/object#invoice_object-default_tax_rates) or uses [automatic tax](https://docs.stripe.com/tax/invoicing). Pass an empty string to remove previously defined tax amounts.</summary>
        [<Config.Form>]TaxAmounts: Choice<UpdateLines'LinesTaxAmounts list,string> option
        ///<summary>The tax rates which apply to the line item. When set, the `default_tax_rates` on the invoice do not apply to this line item. Pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?amount: int, ?description: string, ?discountable: bool, ?discounts: Choice<UpdateLines'LinesDiscounts list,string>, ?id: string, ?metadata: Map<string, string>, ?period: UpdateLines'LinesPeriod, ?priceData: UpdateLines'LinesPriceData, ?pricing: UpdateLines'LinesPricing, ?quantity: int, ?quantityDecimal: string, ?taxAmounts: Choice<UpdateLines'LinesTaxAmounts list,string>, ?taxRates: Choice<string list,string>) =
            {
                Amount = amount
                Description = description
                Discountable = discountable
                Discounts = discounts
                Id = id
                Metadata = metadata
                Period = period
                PriceData = priceData
                Pricing = pricing
                Quantity = quantity
                QuantityDecimal = quantityDecimal
                TaxAmounts = taxAmounts
                TaxRates = taxRates
            }

    type UpdateLinesOptions = {
        [<Config.Path>]Invoice: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`. For [type=subscription](https://docs.stripe.com/api/invoices/line_item#invoice_line_item_object-type) line items, the incoming metadata specified on the request is directly used to set this value, in contrast to [type=invoiceitem](api/invoices/line_item#invoice_line_item_object-type) line items, where any existing metadata on the invoice line is merged with the incoming data.</summary>
        [<Config.Form>]InvoiceMetadata: Choice<Map<string, string>,string> option
        ///<summary>The line items to update.</summary>
        [<Config.Form>]Lines: UpdateLines'Lines list
    }
    with
        static member New(invoice: string, lines: UpdateLines'Lines list, ?expand: string list, ?invoiceMetadata: Choice<Map<string, string>,string>) =
            {
                Invoice = invoice
                Expand = expand
                InvoiceMetadata = invoiceMetadata
                Lines = lines
            }

    ///<summary><p>Updates multiple line items on an invoice. This is only possible when an invoice is still a draft.</p></summary>
    let UpdateLines settings (options: UpdateLinesOptions) =
        $"/v1/invoices/{options.Invoice}/update_lines"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module InvoicesVoid =

    type VoidInvoiceOptions = {
        [<Config.Path>]Invoice: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(invoice: string, ?expand: string list) =
            {
                Invoice = invoice
                Expand = expand
            }

    ///<summary><p>Mark a finalized invoice as void. This cannot be undone. Voiding an invoice is similar to <a href="/api/invoices/delete">deletion</a>, however it only applies to finalized invoices and maintains a papertrail where the invoice can still be found.</p>
    ///<p>Consult with local regulations to determine whether and how an invoice might be amended, canceled, or voided in the jurisdiction you’re doing business in. You might need to <a href="/api/invoices/create">issue another invoice</a> or <a href="/api/credit_notes/create">credit note</a> instead. Stripe recommends that you consult with your legal counsel for advice specific to your business.</p></summary>
    let VoidInvoice settings (options: VoidInvoiceOptions) =
        $"/v1/invoices/{options.Invoice}/void"
        |> RestApi.postAsync<_, Invoice> settings (Map.empty) options

module Plans =

    type ListOptions = {
        ///<summary>Only return plans that are active or inactive (e.g., pass `false` to list all inactive plans).</summary>
        [<Config.Query>]Active: bool option
        ///<summary>A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Only return plans for the given product.</summary>
        [<Config.Query>]Product: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?limit: int, ?product: string, ?startingAfter: string) =
            {
                Active = active
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Product = product
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of your plans.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("product", options.Product |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/plans"
        |> RestApi.getAsync<StripeList<Plan>> settings qs

    type Create'ProductInlineProductParams = {
        ///<summary>Whether the product is currently available for purchase. Defaults to `true`.</summary>
        [<Config.Form>]Active: bool option
        ///<summary>The identifier for the product. Must be unique. If not provided, an identifier will be randomly generated.</summary>
        [<Config.Form>]Id: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The product's name, meant to be displayable to the customer.</summary>
        [<Config.Form>]Name: string option
        ///<summary>An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
        ///This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.</summary>
        [<Config.Form>]StatementDescriptor: string option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID.</summary>
        [<Config.Form>]TaxCode: string option
        ///<summary>A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.</summary>
        [<Config.Form>]UnitLabel: string option
    }
    with
        static member New(?active: bool, ?id: string, ?metadata: Map<string, string>, ?name: string, ?statementDescriptor: string, ?taxCode: string, ?unitLabel: string) =
            {
                Active = active
                Id = id
                Metadata = metadata
                Name = name
                StatementDescriptor = statementDescriptor
                TaxCode = taxCode
                UnitLabel = unitLabel
            }

    type Create'TiersUpTo =
    | Inf

    type Create'Tiers = {
        ///<summary>The flat billing amount for an entire tier, regardless of the number of units in the tier.</summary>
        [<Config.Form>]FlatAmount: int option
        ///<summary>Same as `flat_amount`, but accepts a decimal value representing an integer in the minor units of the currency. Only one of `flat_amount` and `flat_amount_decimal` can be set.</summary>
        [<Config.Form>]FlatAmountDecimal: string option
        ///<summary>The per unit billing amount for each individual unit for which this tier applies.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
        ///<summary>Specifies the upper bound of this tier. The lower bound of a tier is the upper bound of the previous tier adding one. Use `inf` to define a fallback tier.</summary>
        [<Config.Form>]UpTo: Choice<Create'TiersUpTo,int> option
    }
    with
        static member New(?flatAmount: int, ?flatAmountDecimal: string, ?unitAmount: int, ?unitAmountDecimal: string, ?upTo: Choice<Create'TiersUpTo,int>) =
            {
                FlatAmount = flatAmount
                FlatAmountDecimal = flatAmountDecimal
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
                UpTo = upTo
            }

    type Create'TransformUsageRound =
    | Down
    | Up

    type Create'TransformUsage = {
        ///<summary>Divide usage by this number.</summary>
        [<Config.Form>]DivideBy: int option
        ///<summary>After division, either round the result `up` or `down`.</summary>
        [<Config.Form>]Round: Create'TransformUsageRound option
    }
    with
        static member New(?divideBy: int, ?round: Create'TransformUsageRound) =
            {
                DivideBy = divideBy
                Round = round
            }

    type Create'BillingScheme =
    | PerUnit
    | Tiered

    type Create'Interval =
    | Day
    | Month
    | Week
    | Year

    type Create'TiersMode =
    | Graduated
    | Volume

    type Create'UsageType =
    | Licensed
    | Metered

    type CreateOptions = {
        ///<summary>Whether the plan is currently available for new subscriptions. Defaults to `true`.</summary>
        [<Config.Form>]Active: bool option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free plan) representing how much to charge on a recurring basis.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Same as `amount`, but accepts a decimal value with at most 12 decimal places. Only one of `amount` and `amount_decimal` can be set.</summary>
        [<Config.Form>]AmountDecimal: string option
        ///<summary>Describes how to compute the price per period. Either `per_unit` or `tiered`. `per_unit` indicates that the fixed amount (specified in `amount`) will be charged per unit in `quantity` (for plans with `usage_type=licensed`), or per unit of total usage (for plans with `usage_type=metered`). `tiered` indicates that the unit pricing will be computed using a tiering strategy as defined using the `tiers` and `tiers_mode` attributes.</summary>
        [<Config.Form>]BillingScheme: Create'BillingScheme option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>An identifier randomly generated by Stripe. Used to identify this plan when subscribing a customer. You can optionally override this ID, but the ID must be unique across all plans in your Stripe account. You can, however, use the same plan ID in both live and test modes.</summary>
        [<Config.Form>]Id: string option
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Create'Interval
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The meter tracking the usage of a metered price</summary>
        [<Config.Form>]Meter: string option
        ///<summary>A brief description of the plan, hidden from customers.</summary>
        [<Config.Form>]Nickname: string option
        [<Config.Form>]Product: Choice<Create'ProductInlineProductParams,string> option
        ///<summary>Each element represents a pricing tier. This parameter requires `billing_scheme` to be set to `tiered`. See also the documentation for `billing_scheme`.</summary>
        [<Config.Form>]Tiers: Create'Tiers list option
        ///<summary>Defines if the tiering price should be `graduated` or `volume` based. In `volume`-based tiering, the maximum quantity within a period determines the per unit price, in `graduated` tiering pricing can successively change as the quantity grows.</summary>
        [<Config.Form>]TiersMode: Create'TiersMode option
        ///<summary>Apply a transformation to the reported usage or set quantity before computing the billed price. Cannot be combined with `tiers`.</summary>
        [<Config.Form>]TransformUsage: Create'TransformUsage option
        ///<summary>Default number of trial days when subscribing a customer to this plan using [`trial_from_plan=true`](https://docs.stripe.com/api#create_subscription-trial_from_plan).</summary>
        [<Config.Form>]TrialPeriodDays: int option
        ///<summary>Configures how the quantity per period should be determined. Can be either `metered` or `licensed`. `licensed` automatically bills the `quantity` set when adding it to a subscription. `metered` aggregates the total usage based on usage records. Defaults to `licensed`.</summary>
        [<Config.Form>]UsageType: Create'UsageType option
    }
    with
        static member New(currency: IsoTypes.IsoCurrencyCode, interval: Create'Interval, ?active: bool, ?transformUsage: Create'TransformUsage, ?tiersMode: Create'TiersMode, ?tiers: Create'Tiers list, ?product: Choice<Create'ProductInlineProductParams,string>, ?nickname: string, ?meter: string, ?intervalCount: int, ?trialPeriodDays: int, ?id: string, ?expand: string list, ?billingScheme: Create'BillingScheme, ?amountDecimal: string, ?amount: int, ?metadata: Map<string, string>, ?usageType: Create'UsageType) =
            {
                Active = active
                Amount = amount
                AmountDecimal = amountDecimal
                BillingScheme = billingScheme
                Currency = currency
                Expand = expand
                Id = id
                Interval = interval
                IntervalCount = intervalCount
                Metadata = metadata
                Meter = meter
                Nickname = nickname
                Product = product
                Tiers = tiers
                TiersMode = tiersMode
                TransformUsage = transformUsage
                TrialPeriodDays = trialPeriodDays
                UsageType = usageType
            }

    ///<summary><p>You can now model subscriptions more flexibly using the <a href="#prices">Prices API</a>. It replaces the Plans API and is backwards compatible to simplify your migration.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/plans"
        |> RestApi.postAsync<_, Plan> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Plan: string
    }
    with
        static member New(plan: string) =
            {
                Plan = plan
            }

    ///<summary><p>Deleting plans means new subscribers can’t be added. Existing subscribers aren’t affected.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/plans/{options.Plan}"
        |> RestApi.deleteAsync<DeletedPlan> settings (Map.empty)

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Plan: string
    }
    with
        static member New(plan: string, ?expand: string list) =
            {
                Expand = expand
                Plan = plan
            }

    ///<summary><p>Retrieves the plan with the given ID.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/plans/{options.Plan}"
        |> RestApi.getAsync<Plan> settings qs

    type UpdateOptions = {
        [<Config.Path>]Plan: string
        ///<summary>Whether the plan is currently available for new subscriptions.</summary>
        [<Config.Form>]Active: bool option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>A brief description of the plan, hidden from customers.</summary>
        [<Config.Form>]Nickname: string option
        ///<summary>The product the plan belongs to. This cannot be changed once it has been used in a subscription or subscription schedule.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Default number of trial days when subscribing a customer to this plan using [`trial_from_plan=true`](https://docs.stripe.com/api#create_subscription-trial_from_plan).</summary>
        [<Config.Form>]TrialPeriodDays: int option
    }
    with
        static member New(plan: string, ?active: bool, ?expand: string list, ?metadata: Map<string, string>, ?nickname: string, ?product: string, ?trialPeriodDays: int) =
            {
                Plan = plan
                Active = active
                Expand = expand
                Metadata = metadata
                Nickname = nickname
                Product = product
                TrialPeriodDays = trialPeriodDays
            }

    ///<summary><p>Updates the specified plan by setting the values of the parameters passed. Any parameters not provided are left unchanged. By design, you cannot change a plan’s ID, amount, currency, or billing cycle.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/plans/{options.Plan}"
        |> RestApi.postAsync<_, Plan> settings (Map.empty) options

module Prices =

    type ListOptions = {
        ///<summary>Only return prices that are active or inactive (e.g., pass `false` to list all inactive prices).</summary>
        [<Config.Query>]Active: bool option
        ///<summary>A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.</summary>
        [<Config.Query>]Created: int option
        ///<summary>Only return prices for the given currency.</summary>
        [<Config.Query>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Only return the price with these lookup_keys, if any exist. You can specify up to 10 lookup_keys.</summary>
        [<Config.Query>]LookupKeys: string list option
        ///<summary>Only return prices for the given product.</summary>
        [<Config.Query>]Product: string option
        ///<summary>Only return prices with these recurring fields.</summary>
        [<Config.Query>]Recurring: Map<string, string> option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>Only return prices of type `recurring` or `one_time`.</summary>
        [<Config.Query>]Type: string option
    }
    with
        static member New(?active: bool, ?created: int, ?currency: IsoTypes.IsoCurrencyCode, ?endingBefore: string, ?expand: string list, ?limit: int, ?lookupKeys: string list, ?product: string, ?recurring: Map<string, string>, ?startingAfter: string, ?type': string) =
            {
                Active = active
                Created = created
                Currency = currency
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                LookupKeys = lookupKeys
                Product = product
                Recurring = recurring
                StartingAfter = startingAfter
                Type = type'
            }

    ///<summary><p>Returns a list of your active prices, excluding <a href="/docs/products-prices/pricing-models#inline-pricing">inline prices</a>. For the list of inactive prices, set <code>active</code> to false.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("currency", options.Currency |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("lookup_keys", options.LookupKeys |> box); ("product", options.Product |> box); ("recurring", options.Recurring |> box); ("starting_after", options.StartingAfter |> box); ("type", options.Type |> box)] |> Map.ofList
        $"/v1/prices"
        |> RestApi.getAsync<StripeList<Price>> settings qs

    type Create'CustomUnitAmount = {
        ///<summary>Pass in `true` to enable `custom_unit_amount`, otherwise omit `custom_unit_amount`.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The maximum unit amount the customer can specify for this item.</summary>
        [<Config.Form>]Maximum: int option
        ///<summary>The minimum unit amount the customer can specify for this item. Must be at least the minimum charge amount.</summary>
        [<Config.Form>]Minimum: int option
        ///<summary>The starting unit amount which can be updated by the customer.</summary>
        [<Config.Form>]Preset: int option
    }
    with
        static member New(?enabled: bool, ?maximum: int, ?minimum: int, ?preset: int) =
            {
                Enabled = enabled
                Maximum = maximum
                Minimum = minimum
                Preset = preset
            }

    type Create'ProductData = {
        ///<summary>Whether the product is currently available for purchase. Defaults to `true`.</summary>
        [<Config.Form>]Active: bool option
        ///<summary>The identifier for the product. Must be unique. If not provided, an identifier will be randomly generated.</summary>
        [<Config.Form>]Id: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The product's name, meant to be displayable to the customer.</summary>
        [<Config.Form>]Name: string option
        ///<summary>An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
        ///This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.</summary>
        [<Config.Form>]StatementDescriptor: string option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID.</summary>
        [<Config.Form>]TaxCode: string option
        ///<summary>A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.</summary>
        [<Config.Form>]UnitLabel: string option
    }
    with
        static member New(?active: bool, ?id: string, ?metadata: Map<string, string>, ?name: string, ?statementDescriptor: string, ?taxCode: string, ?unitLabel: string) =
            {
                Active = active
                Id = id
                Metadata = metadata
                Name = name
                StatementDescriptor = statementDescriptor
                TaxCode = taxCode
                UnitLabel = unitLabel
            }

    type Create'RecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'RecurringUsageType =
    | Licensed
    | Metered

    type Create'Recurring = {
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Create'RecurringInterval option
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
        ///<summary>The meter tracking the usage of a metered price</summary>
        [<Config.Form>]Meter: string option
        ///<summary>Default number of trial days when subscribing a customer to this price using [`trial_from_plan=true`](https://docs.stripe.com/api#create_subscription-trial_from_plan).</summary>
        [<Config.Form>]TrialPeriodDays: int option
        ///<summary>Configures how the quantity per period should be determined. Can be either `metered` or `licensed`. `licensed` automatically bills the `quantity` set when adding it to a subscription. `metered` aggregates the total usage based on usage records. Defaults to `licensed`.</summary>
        [<Config.Form>]UsageType: Create'RecurringUsageType option
    }
    with
        static member New(?interval: Create'RecurringInterval, ?intervalCount: int, ?meter: string, ?trialPeriodDays: int, ?usageType: Create'RecurringUsageType) =
            {
                Interval = interval
                IntervalCount = intervalCount
                Meter = meter
                TrialPeriodDays = trialPeriodDays
                UsageType = usageType
            }

    type Create'TiersUpTo =
    | Inf

    type Create'Tiers = {
        ///<summary>The flat billing amount for an entire tier, regardless of the number of units in the tier.</summary>
        [<Config.Form>]FlatAmount: int option
        ///<summary>Same as `flat_amount`, but accepts a decimal value representing an integer in the minor units of the currency. Only one of `flat_amount` and `flat_amount_decimal` can be set.</summary>
        [<Config.Form>]FlatAmountDecimal: string option
        ///<summary>The per unit billing amount for each individual unit for which this tier applies.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
        ///<summary>Specifies the upper bound of this tier. The lower bound of a tier is the upper bound of the previous tier adding one. Use `inf` to define a fallback tier.</summary>
        [<Config.Form>]UpTo: Choice<Create'TiersUpTo,int> option
    }
    with
        static member New(?flatAmount: int, ?flatAmountDecimal: string, ?unitAmount: int, ?unitAmountDecimal: string, ?upTo: Choice<Create'TiersUpTo,int>) =
            {
                FlatAmount = flatAmount
                FlatAmountDecimal = flatAmountDecimal
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
                UpTo = upTo
            }

    type Create'TransformQuantityRound =
    | Down
    | Up

    type Create'TransformQuantity = {
        ///<summary>Divide usage by this number.</summary>
        [<Config.Form>]DivideBy: int option
        ///<summary>After division, either round the result `up` or `down`.</summary>
        [<Config.Form>]Round: Create'TransformQuantityRound option
    }
    with
        static member New(?divideBy: int, ?round: Create'TransformQuantityRound) =
            {
                DivideBy = divideBy
                Round = round
            }

    type Create'BillingScheme =
    | PerUnit
    | Tiered

    type Create'TaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'TiersMode =
    | Graduated
    | Volume

    type CreateOptions = {
        ///<summary>Whether the price can be used for new purchases. Defaults to `true`.</summary>
        [<Config.Form>]Active: bool option
        ///<summary>Describes how to compute the price per period. Either `per_unit` or `tiered`. `per_unit` indicates that the fixed amount (specified in `unit_amount` or `unit_amount_decimal`) will be charged per unit in `quantity` (for prices with `usage_type=licensed`), or per unit of total usage (for prices with `usage_type=metered`). `tiered` indicates that the unit pricing will be computed using a tiering strategy as defined using the `tiers` and `tiers_mode` attributes.</summary>
        [<Config.Form>]BillingScheme: Create'BillingScheme option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode
        ///<summary>Prices defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]CurrencyOptions: Map<string, string> option
        ///<summary>When set, provides configuration for the amount to be adjusted by the customer during Checkout Sessions and Payment Links.</summary>
        [<Config.Form>]CustomUnitAmount: Create'CustomUnitAmount option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A lookup key used to retrieve prices dynamically from a static string. This may be up to 200 characters.</summary>
        [<Config.Form>]LookupKey: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>A brief description of the price, hidden from customers.</summary>
        [<Config.Form>]Nickname: string option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>These fields can be used to create a new product that this price will belong to.</summary>
        [<Config.Form>]ProductData: Create'ProductData option
        ///<summary>The recurring components of a price such as `interval` and `usage_type`.</summary>
        [<Config.Form>]Recurring: Create'Recurring option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Create'TaxBehavior option
        ///<summary>Each element represents a pricing tier. This parameter requires `billing_scheme` to be set to `tiered`. See also the documentation for `billing_scheme`.</summary>
        [<Config.Form>]Tiers: Create'Tiers list option
        ///<summary>Defines if the tiering price should be `graduated` or `volume` based. In `volume`-based tiering, the maximum quantity within a period determines the per unit price, in `graduated` tiering pricing can successively change as the quantity grows.</summary>
        [<Config.Form>]TiersMode: Create'TiersMode option
        ///<summary>If set to true, will atomically remove the lookup key from the existing price, and assign it to this price.</summary>
        [<Config.Form>]TransferLookupKey: bool option
        ///<summary>Apply a transformation to the reported usage or set quantity before computing the billed price. Cannot be combined with `tiers`.</summary>
        [<Config.Form>]TransformQuantity: Create'TransformQuantity option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge. One of `unit_amount`, `unit_amount_decimal`, or `custom_unit_amount` is required, unless `billing_scheme=tiered`.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(currency: IsoTypes.IsoCurrencyCode, ?active: bool, ?transformQuantity: Create'TransformQuantity, ?transferLookupKey: bool, ?tiersMode: Create'TiersMode, ?tiers: Create'Tiers list, ?taxBehavior: Create'TaxBehavior, ?recurring: Create'Recurring, ?productData: Create'ProductData, ?product: string, ?nickname: string, ?metadata: Map<string, string>, ?lookupKey: string, ?expand: string list, ?customUnitAmount: Create'CustomUnitAmount, ?currencyOptions: Map<string, string>, ?billingScheme: Create'BillingScheme, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Active = active
                BillingScheme = billingScheme
                Currency = currency
                CurrencyOptions = currencyOptions
                CustomUnitAmount = customUnitAmount
                Expand = expand
                LookupKey = lookupKey
                Metadata = metadata
                Nickname = nickname
                Product = product
                ProductData = productData
                Recurring = recurring
                TaxBehavior = taxBehavior
                Tiers = tiers
                TiersMode = tiersMode
                TransferLookupKey = transferLookupKey
                TransformQuantity = transformQuantity
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    ///<summary><p>Creates a new <a href="https://docs.stripe.com/api/prices">Price</a> for an existing <a href="https://docs.stripe.com/api/products">Product</a>. The Price can be recurring or one-time.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/prices"
        |> RestApi.postAsync<_, Price> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Price: string
    }
    with
        static member New(price: string, ?expand: string list) =
            {
                Expand = expand
                Price = price
            }

    ///<summary><p>Retrieves the price with the given ID.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/prices/{options.Price}"
        |> RestApi.getAsync<Price> settings qs

    type Update'TaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type UpdateOptions = {
        [<Config.Path>]Price: string
        ///<summary>Whether the price can be used for new purchases. Defaults to `true`.</summary>
        [<Config.Form>]Active: bool option
        ///<summary>Prices defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]CurrencyOptions: Choice<Map<string, string>,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A lookup key used to retrieve prices dynamically from a static string. This may be up to 200 characters.</summary>
        [<Config.Form>]LookupKey: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>A brief description of the price, hidden from customers.</summary>
        [<Config.Form>]Nickname: string option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Update'TaxBehavior option
        ///<summary>If set to true, will atomically remove the lookup key from the existing price, and assign it to this price.</summary>
        [<Config.Form>]TransferLookupKey: bool option
    }
    with
        static member New(price: string, ?active: bool, ?currencyOptions: Choice<Map<string, string>,string>, ?expand: string list, ?lookupKey: string, ?metadata: Map<string, string>, ?nickname: string, ?taxBehavior: Update'TaxBehavior, ?transferLookupKey: bool) =
            {
                Price = price
                Active = active
                CurrencyOptions = currencyOptions
                Expand = expand
                LookupKey = lookupKey
                Metadata = metadata
                Nickname = nickname
                TaxBehavior = taxBehavior
                TransferLookupKey = transferLookupKey
            }

    ///<summary><p>Updates the specified price by setting the values of the parameters passed. Any parameters not provided are left unchanged.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/prices/{options.Price}"
        |> RestApi.postAsync<_, Price> settings (Map.empty) options

module PricesSearch =

    type SearchOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.</summary>
        [<Config.Query>]Page: string option
        ///<summary>The search query string. See [search query language](https://docs.stripe.com/search#search-query-language) and the list of supported [query fields for prices](https://docs.stripe.com/search#query-fields-for-prices).</summary>
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

    ///<summary><p>Search for prices you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p></summary>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/prices/search"
        |> RestApi.getAsync<StripeList<Price>> settings qs

module PromotionCodes =

    type ListOptions = {
        ///<summary>Filter promotion codes by whether they are active.</summary>
        [<Config.Query>]Active: bool option
        ///<summary>Only return promotion codes that have this case-insensitive code.</summary>
        [<Config.Query>]Code: string option
        ///<summary>Only return promotion codes for this coupon.</summary>
        [<Config.Query>]Coupon: string option
        ///<summary>A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.</summary>
        [<Config.Query>]Created: int option
        ///<summary>Only return promotion codes that are restricted to this customer.</summary>
        [<Config.Query>]Customer: string option
        ///<summary>Only return promotion codes that are restricted to this account representing the customer.</summary>
        [<Config.Query>]CustomerAccount: string option
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
        static member New(?active: bool, ?code: string, ?coupon: string, ?created: int, ?customer: string, ?customerAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Active = active
                Code = code
                Coupon = coupon
                Created = created
                Customer = customer
                CustomerAccount = customerAccount
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of your promotion codes.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("code", options.Code |> box); ("coupon", options.Coupon |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/promotion_codes"
        |> RestApi.getAsync<StripeList<PromotionCode>> settings qs

    type Create'PromotionType =
    | Coupon

    type Create'Promotion = {
        ///<summary>If promotion `type` is `coupon`, the coupon for this promotion code.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>Specifies the type of promotion.</summary>
        [<Config.Form>]Type: Create'PromotionType option
    }
    with
        static member New(?coupon: string, ?type': Create'PromotionType) =
            {
                Coupon = coupon
                Type = type'
            }

    type Create'Restrictions = {
        ///<summary>Promotion codes defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]CurrencyOptions: Map<string, string> option
        ///<summary>A Boolean indicating if the Promotion Code should only be redeemed for Customers without any successful payments or invoices</summary>
        [<Config.Form>]FirstTimeTransaction: bool option
        ///<summary>Minimum amount required to redeem this Promotion Code into a Coupon (e.g., a purchase must be $100 or more to work).</summary>
        [<Config.Form>]MinimumAmount: int option
        ///<summary>Three-letter [ISO code](https://stripe.com/docs/currencies) for minimum_amount</summary>
        [<Config.Form>]MinimumAmountCurrency: IsoTypes.IsoCurrencyCode option
    }
    with
        static member New(?currencyOptions: Map<string, string>, ?firstTimeTransaction: bool, ?minimumAmount: int, ?minimumAmountCurrency: IsoTypes.IsoCurrencyCode) =
            {
                CurrencyOptions = currencyOptions
                FirstTimeTransaction = firstTimeTransaction
                MinimumAmount = minimumAmount
                MinimumAmountCurrency = minimumAmountCurrency
            }

    type CreateOptions = {
        ///<summary>Whether the promotion code is currently active.</summary>
        [<Config.Form>]Active: bool option
        ///<summary>The customer-facing code. Regardless of case, this code must be unique across all active promotion codes for a specific customer. Valid characters are lower case letters (a-z), upper case letters (A-Z), digits (0-9), and dashes (-).
        ///If left blank, we will generate one automatically.</summary>
        [<Config.Form>]Code: string option
        ///<summary>The customer who can use this promotion code. If not set, all customers can use the promotion code.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>The account representing the customer who can use this promotion code. If not set, all customers can use the promotion code.</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The timestamp at which this promotion code will expire. If the coupon has specified a `redeems_by`, then this value cannot be after the coupon's `redeems_by`.</summary>
        [<Config.Form>]ExpiresAt: DateTime option
        ///<summary>A positive integer specifying the number of times the promotion code can be redeemed. If the coupon has specified a `max_redemptions`, then this value cannot be greater than the coupon's `max_redemptions`.</summary>
        [<Config.Form>]MaxRedemptions: int option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The promotion referenced by this promotion code.</summary>
        [<Config.Form>]Promotion: Create'Promotion
        ///<summary>Settings that restrict the redemption of the promotion code.</summary>
        [<Config.Form>]Restrictions: Create'Restrictions option
    }
    with
        static member New(promotion: Create'Promotion, ?active: bool, ?code: string, ?customer: string, ?customerAccount: string, ?expand: string list, ?expiresAt: DateTime, ?maxRedemptions: int, ?metadata: Map<string, string>, ?restrictions: Create'Restrictions) =
            {
                Active = active
                Code = code
                Customer = customer
                CustomerAccount = customerAccount
                Expand = expand
                ExpiresAt = expiresAt
                MaxRedemptions = maxRedemptions
                Metadata = metadata
                Promotion = promotion
                Restrictions = restrictions
            }

    ///<summary><p>A promotion code points to an underlying promotion. You can optionally restrict the code to a specific customer, redemption limit, and expiration date.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/promotion_codes"
        |> RestApi.postAsync<_, PromotionCode> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]PromotionCode: string
    }
    with
        static member New(promotionCode: string, ?expand: string list) =
            {
                Expand = expand
                PromotionCode = promotionCode
            }

    ///<summary><p>Retrieves the promotion code with the given ID. In order to retrieve a promotion code by the customer-facing <code>code</code> use <a href="/docs/api/promotion_codes/list">list</a> with the desired <code>code</code>.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/promotion_codes/{options.PromotionCode}"
        |> RestApi.getAsync<PromotionCode> settings qs

    type Update'Restrictions = {
        ///<summary>Promotion codes defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]CurrencyOptions: Map<string, string> option
    }
    with
        static member New(?currencyOptions: Map<string, string>) =
            {
                CurrencyOptions = currencyOptions
            }

    type UpdateOptions = {
        [<Config.Path>]PromotionCode: string
        ///<summary>Whether the promotion code is currently active. A promotion code can only be reactivated when the coupon is still valid and the promotion code is otherwise redeemable.</summary>
        [<Config.Form>]Active: bool option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Settings that restrict the redemption of the promotion code.</summary>
        [<Config.Form>]Restrictions: Update'Restrictions option
    }
    with
        static member New(promotionCode: string, ?active: bool, ?expand: string list, ?metadata: Map<string, string>, ?restrictions: Update'Restrictions) =
            {
                PromotionCode = promotionCode
                Active = active
                Expand = expand
                Metadata = metadata
                Restrictions = restrictions
            }

    ///<summary><p>Updates the specified promotion code by setting the values of the parameters passed. Most fields are, by design, not editable.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/promotion_codes/{options.PromotionCode}"
        |> RestApi.postAsync<_, PromotionCode> settings (Map.empty) options

module Quotes =

    type ListOptions = {
        ///<summary>The ID of the customer whose quotes you're retrieving.</summary>
        [<Config.Query>]Customer: string option
        ///<summary>The ID of the account representing the customer whose quotes you're retrieving.</summary>
        [<Config.Query>]CustomerAccount: string option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>The status of the quote.</summary>
        [<Config.Query>]Status: string option
        ///<summary>Provides a list of quotes that are associated with the specified test clock. The response will not include quotes with test clocks if this and the customer parameter is not set.</summary>
        [<Config.Query>]TestClock: string option
    }
    with
        static member New(?customer: string, ?customerAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string, ?testClock: string) =
            {
                Customer = customer
                CustomerAccount = customerAccount
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
                TestClock = testClock
            }

    ///<summary><p>Returns a list of your quotes.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("test_clock", options.TestClock |> box)] |> Map.ofList
        $"/v1/quotes"
        |> RestApi.getAsync<StripeList<Quote>> settings qs

    type Create'AutomaticTaxLiabilityType =
    | Account
    | Self

    type Create'AutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Create'AutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': Create'AutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Create'AutomaticTax = {
        ///<summary>Controls whether Stripe will automatically compute tax on the resulting invoices or subscriptions as well as the quote itself.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: Create'AutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: Create'AutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Create'Discounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Create'FromQuote = {
        ///<summary>Whether this quote is a revision of the previous quote.</summary>
        [<Config.Form>]IsRevision: bool option
        ///<summary>The `id` of the quote that will be cloned.</summary>
        [<Config.Form>]Quote: string option
    }
    with
        static member New(?isRevision: bool, ?quote: string) =
            {
                IsRevision = isRevision
                Quote = quote
            }

    type Create'InvoiceSettingsIssuerType =
    | Account
    | Self

    type Create'InvoiceSettingsIssuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Create'InvoiceSettingsIssuerType option
    }
    with
        static member New(?account: string, ?type': Create'InvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Create'InvoiceSettings = {
        ///<summary>Number of days within which a customer must pay the invoice generated by this quote. This value will be `null` for quotes where `collection_method=charge_automatically`.</summary>
        [<Config.Form>]DaysUntilDue: int option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Create'InvoiceSettingsIssuer option
    }
    with
        static member New(?daysUntilDue: int, ?issuer: Create'InvoiceSettingsIssuer) =
            {
                DaysUntilDue = daysUntilDue
                Issuer = issuer
            }

    type Create'LineItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Create'LineItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'LineItemsPriceDataRecurring = {
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Create'LineItemsPriceDataRecurringInterval option
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'LineItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'LineItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'LineItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>The recurring components of a price such as `interval` and `interval_count`.</summary>
        [<Config.Form>]Recurring: Create'LineItemsPriceDataRecurring option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Create'LineItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: Create'LineItemsPriceDataRecurring, ?taxBehavior: Create'LineItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'LineItems = {
        ///<summary>The discounts applied to this line item.</summary>
        [<Config.Form>]Discounts: Choice<Create'LineItemsDiscounts list,string> option
        ///<summary>The ID of the price object. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]PriceData: Create'LineItemsPriceData option
        ///<summary>The quantity of the line item.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>The tax rates which apply to the line item. When set, the `default_tax_rates` on the quote do not apply to this line item.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?discounts: Choice<Create'LineItemsDiscounts list,string>, ?price: string, ?priceData: Create'LineItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Discounts = discounts
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Create'SubscriptionDataBillingModeFlexibleProrationDiscounts =
    | Included
    | Itemized

    type Create'SubscriptionDataBillingModeFlexible = {
        ///<summary>Controls how invoices and invoice items display proration amounts and discount amounts.</summary>
        [<Config.Form>]ProrationDiscounts: Create'SubscriptionDataBillingModeFlexibleProrationDiscounts option
    }
    with
        static member New(?prorationDiscounts: Create'SubscriptionDataBillingModeFlexibleProrationDiscounts) =
            {
                ProrationDiscounts = prorationDiscounts
            }

    type Create'SubscriptionDataBillingModeType =
    | Classic
    | Flexible

    type Create'SubscriptionDataBillingMode = {
        ///<summary>Configure behavior for flexible billing mode.</summary>
        [<Config.Form>]Flexible: Create'SubscriptionDataBillingModeFlexible option
        ///<summary>Controls the calculation and orchestration of prorations and invoices for subscriptions. If no value is passed, the default is `flexible`.</summary>
        [<Config.Form>]Type: Create'SubscriptionDataBillingModeType option
    }
    with
        static member New(?flexible: Create'SubscriptionDataBillingModeFlexible, ?type': Create'SubscriptionDataBillingModeType) =
            {
                Flexible = flexible
                Type = type'
            }

    type Create'SubscriptionDataEffectiveDate =
    | CurrentPeriodEnd

    type Create'SubscriptionData = {
        ///<summary>Controls how prorations and invoices for subscriptions are calculated and orchestrated.</summary>
        [<Config.Form>]BillingMode: Create'SubscriptionDataBillingMode option
        ///<summary>The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.</summary>
        [<Config.Form>]Description: string option
        ///<summary>When creating a new subscription, the date of which the subscription schedule will start after the quote is accepted. The `effective_date` is ignored if it is in the past when the quote is accepted.</summary>
        [<Config.Form>]EffectiveDate: Choice<Create'SubscriptionDataEffectiveDate,DateTime,string> option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that will set metadata on the subscription or subscription schedule when the quote is accepted. If a recurring price is included in `line_items`, this field will be passed to the resulting subscription's `metadata` field. If `subscription_data.effective_date` is used, this field will be passed to the resulting subscription schedule's `phases.metadata` field. Unlike object-level metadata, this field is declarative. Updates will clear prior values.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Integer representing the number of trial period days before the customer is charged for the first time.</summary>
        [<Config.Form>]TrialPeriodDays: Choice<int,string> option
    }
    with
        static member New(?billingMode: Create'SubscriptionDataBillingMode, ?description: string, ?effectiveDate: Choice<Create'SubscriptionDataEffectiveDate,DateTime,string>, ?metadata: Map<string, string>, ?trialPeriodDays: Choice<int,string>) =
            {
                BillingMode = billingMode
                Description = description
                EffectiveDate = effectiveDate
                Metadata = metadata
                TrialPeriodDays = trialPeriodDays
            }

    type Create'TransferDataTransferDataSpecs = {
        ///<summary>The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred. There cannot be any line items with recurring prices when using this field.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination. There must be at least 1 line item with a recurring price to use this field.</summary>
        [<Config.Form>]AmountPercent: decimal option
        ///<summary>ID of an existing, connected Stripe account.</summary>
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amount: int, ?amountPercent: decimal, ?destination: string) =
            {
                Amount = amount
                AmountPercent = amountPercent
                Destination = destination
            }

    type Create'CollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type CreateOptions = {
        ///<summary>The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. There cannot be any line items with recurring prices when using this field.</summary>
        [<Config.Form>]ApplicationFeeAmount: Choice<int,string> option
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. There must be at least 1 line item with a recurring price to use this field.</summary>
        [<Config.Form>]ApplicationFeePercent: Choice<decimal,string> option
        ///<summary>Settings for automatic tax lookup for this quote and resulting invoices and subscriptions.</summary>
        [<Config.Form>]AutomaticTax: Create'AutomaticTax option
        ///<summary>Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay invoices at the end of the subscription cycle or at invoice finalization using the default payment method attached to the subscription or customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically`.</summary>
        [<Config.Form>]CollectionMethod: Create'CollectionMethod option
        ///<summary>The customer for which this quote belongs to. A customer is required before finalizing the quote. Once specified, it cannot be changed.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>The account for which this quote belongs to. A customer or account is required before finalizing the quote. Once specified, it cannot be changed.</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>The tax rates that will apply to any line item that does not have `tax_rates` set.</summary>
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///<summary>A description that will be displayed on the quote PDF. If no value is passed, the default description configured in your [quote template settings](https://dashboard.stripe.com/settings/billing/quote) will be used.</summary>
        [<Config.Form>]Description: Choice<string,string> option
        ///<summary>The discounts applied to the quote.</summary>
        [<Config.Form>]Discounts: Choice<Create'Discounts list,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A future timestamp on which the quote will be canceled if in `open` or `draft` status. Measured in seconds since the Unix epoch. If no value is passed, the default expiration date configured in your [quote template settings](https://dashboard.stripe.com/settings/billing/quote) will be used.</summary>
        [<Config.Form>]ExpiresAt: DateTime option
        ///<summary>A footer that will be displayed on the quote PDF. If no value is passed, the default footer configured in your [quote template settings](https://dashboard.stripe.com/settings/billing/quote) will be used.</summary>
        [<Config.Form>]Footer: Choice<string,string> option
        ///<summary>Clone an existing quote. The new quote will be created in `status=draft`. When using this parameter, you cannot specify any other parameters except for `expires_at`.</summary>
        [<Config.Form>]FromQuote: Create'FromQuote option
        ///<summary>A header that will be displayed on the quote PDF. If no value is passed, the default header configured in your [quote template settings](https://dashboard.stripe.com/settings/billing/quote) will be used.</summary>
        [<Config.Form>]Header: Choice<string,string> option
        ///<summary>All invoices will be billed using the specified settings.</summary>
        [<Config.Form>]InvoiceSettings: Create'InvoiceSettings option
        ///<summary>A list of line items the customer is being quoted for. Each line item includes information about the product, the quantity, and the resulting cost.</summary>
        [<Config.Form>]LineItems: Create'LineItems list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The account on behalf of which to charge.</summary>
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///<summary>When creating a subscription or subscription schedule, the specified configuration data will be used. There must be at least one line item with a recurring price for a subscription or subscription schedule to be created. A subscription schedule is created if `subscription_data[effective_date]` is present and in the future, otherwise a subscription is created.</summary>
        [<Config.Form>]SubscriptionData: Create'SubscriptionData option
        ///<summary>ID of the test clock to attach to the quote.</summary>
        [<Config.Form>]TestClock: string option
        ///<summary>The data with which to automatically create a Transfer for each of the invoices.</summary>
        [<Config.Form>]TransferData: Choice<Create'TransferDataTransferDataSpecs,string> option
    }
    with
        static member New(?applicationFeeAmount: Choice<int,string>, ?subscriptionData: Create'SubscriptionData, ?onBehalfOf: Choice<string,string>, ?metadata: Map<string, string>, ?lineItems: Create'LineItems list, ?invoiceSettings: Create'InvoiceSettings, ?header: Choice<string,string>, ?fromQuote: Create'FromQuote, ?footer: Choice<string,string>, ?testClock: string, ?expiresAt: DateTime, ?discounts: Choice<Create'Discounts list,string>, ?description: Choice<string,string>, ?defaultTaxRates: Choice<string list,string>, ?customerAccount: string, ?customer: string, ?collectionMethod: Create'CollectionMethod, ?automaticTax: Create'AutomaticTax, ?applicationFeePercent: Choice<decimal,string>, ?expand: string list, ?transferData: Choice<Create'TransferDataTransferDataSpecs,string>) =
            {
                ApplicationFeeAmount = applicationFeeAmount
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                CollectionMethod = collectionMethod
                Customer = customer
                CustomerAccount = customerAccount
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                Expand = expand
                ExpiresAt = expiresAt
                Footer = footer
                FromQuote = fromQuote
                Header = header
                InvoiceSettings = invoiceSettings
                LineItems = lineItems
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                SubscriptionData = subscriptionData
                TestClock = testClock
                TransferData = transferData
            }

    ///<summary><p>A quote models prices and services for a customer. Default options for <code>header</code>, <code>description</code>, <code>footer</code>, and <code>expires_at</code> can be set in the dashboard via the <a href="https://dashboard.stripe.com/settings/billing/quote">quote template</a>.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/quotes"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Quote: string
    }
    with
        static member New(quote: string, ?expand: string list) =
            {
                Expand = expand
                Quote = quote
            }

    ///<summary><p>Retrieves the quote with the given ID.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/quotes/{options.Quote}"
        |> RestApi.getAsync<Quote> settings qs

    type Update'AutomaticTaxLiabilityType =
    | Account
    | Self

    type Update'AutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Update'AutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': Update'AutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Update'AutomaticTax = {
        ///<summary>Controls whether Stripe will automatically compute tax on the resulting invoices or subscriptions as well as the quote itself.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: Update'AutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: Update'AutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Update'Discounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'InvoiceSettingsIssuerType =
    | Account
    | Self

    type Update'InvoiceSettingsIssuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Update'InvoiceSettingsIssuerType option
    }
    with
        static member New(?account: string, ?type': Update'InvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Update'InvoiceSettings = {
        ///<summary>Number of days within which a customer must pay the invoice generated by this quote. This value will be `null` for quotes where `collection_method=charge_automatically`.</summary>
        [<Config.Form>]DaysUntilDue: int option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Update'InvoiceSettingsIssuer option
    }
    with
        static member New(?daysUntilDue: int, ?issuer: Update'InvoiceSettingsIssuer) =
            {
                DaysUntilDue = daysUntilDue
                Issuer = issuer
            }

    type Update'LineItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'LineItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Update'LineItemsPriceDataRecurring = {
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Update'LineItemsPriceDataRecurringInterval option
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Update'LineItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Update'LineItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'LineItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>The recurring components of a price such as `interval` and `interval_count`.</summary>
        [<Config.Form>]Recurring: Update'LineItemsPriceDataRecurring option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Update'LineItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: Update'LineItemsPriceDataRecurring, ?taxBehavior: Update'LineItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'LineItems = {
        ///<summary>The discounts applied to this line item.</summary>
        [<Config.Form>]Discounts: Choice<Update'LineItemsDiscounts list,string> option
        ///<summary>The ID of an existing line item on the quote.</summary>
        [<Config.Form>]Id: string option
        ///<summary>The ID of the price object. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]PriceData: Update'LineItemsPriceData option
        ///<summary>The quantity of the line item.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>The tax rates which apply to the line item. When set, the `default_tax_rates` on the quote do not apply to this line item.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?discounts: Choice<Update'LineItemsDiscounts list,string>, ?id: string, ?price: string, ?priceData: Update'LineItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Discounts = discounts
                Id = id
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Update'SubscriptionDataEffectiveDate =
    | CurrentPeriodEnd

    type Update'SubscriptionData = {
        ///<summary>The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.</summary>
        [<Config.Form>]Description: Choice<string,string> option
        ///<summary>When creating a new subscription, the date of which the subscription schedule will start after the quote is accepted. The `effective_date` is ignored if it is in the past when the quote is accepted.</summary>
        [<Config.Form>]EffectiveDate: Choice<Update'SubscriptionDataEffectiveDate,DateTime,string> option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that will set metadata on the subscription or subscription schedule when the quote is accepted. If a recurring price is included in `line_items`, this field will be passed to the resulting subscription's `metadata` field. If `subscription_data.effective_date` is used, this field will be passed to the resulting subscription schedule's `phases.metadata` field. Unlike object-level metadata, this field is declarative. Updates will clear prior values.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Integer representing the number of trial period days before the customer is charged for the first time.</summary>
        [<Config.Form>]TrialPeriodDays: Choice<int,string> option
    }
    with
        static member New(?description: Choice<string,string>, ?effectiveDate: Choice<Update'SubscriptionDataEffectiveDate,DateTime,string>, ?metadata: Map<string, string>, ?trialPeriodDays: Choice<int,string>) =
            {
                Description = description
                EffectiveDate = effectiveDate
                Metadata = metadata
                TrialPeriodDays = trialPeriodDays
            }

    type Update'TransferDataTransferDataSpecs = {
        ///<summary>The amount that will be transferred automatically when the invoice is paid. If no amount is set, the full amount is transferred. There cannot be any line items with recurring prices when using this field.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination. There must be at least 1 line item with a recurring price to use this field.</summary>
        [<Config.Form>]AmountPercent: decimal option
        ///<summary>ID of an existing, connected Stripe account.</summary>
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amount: int, ?amountPercent: decimal, ?destination: string) =
            {
                Amount = amount
                AmountPercent = amountPercent
                Destination = destination
            }

    type Update'CollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type UpdateOptions = {
        [<Config.Path>]Quote: string
        ///<summary>The amount of the application fee (if any) that will be requested to be applied to the payment and transferred to the application owner's Stripe account. There cannot be any line items with recurring prices when using this field.</summary>
        [<Config.Form>]ApplicationFeeAmount: Choice<int,string> option
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. There must be at least 1 line item with a recurring price to use this field.</summary>
        [<Config.Form>]ApplicationFeePercent: Choice<decimal,string> option
        ///<summary>Settings for automatic tax lookup for this quote and resulting invoices and subscriptions.</summary>
        [<Config.Form>]AutomaticTax: Update'AutomaticTax option
        ///<summary>Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay invoices at the end of the subscription cycle or at invoice finalization using the default payment method attached to the subscription or customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically`.</summary>
        [<Config.Form>]CollectionMethod: Update'CollectionMethod option
        ///<summary>The customer for which this quote belongs to. A customer is required before finalizing the quote. Once specified, it cannot be changed.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>The account for which this quote belongs to. A customer or account is required before finalizing the quote. Once specified, it cannot be changed.</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>The tax rates that will apply to any line item that does not have `tax_rates` set.</summary>
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///<summary>A description that will be displayed on the quote PDF.</summary>
        [<Config.Form>]Description: Choice<string,string> option
        ///<summary>The discounts applied to the quote.</summary>
        [<Config.Form>]Discounts: Choice<Update'Discounts list,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A future timestamp on which the quote will be canceled if in `open` or `draft` status. Measured in seconds since the Unix epoch.</summary>
        [<Config.Form>]ExpiresAt: DateTime option
        ///<summary>A footer that will be displayed on the quote PDF.</summary>
        [<Config.Form>]Footer: Choice<string,string> option
        ///<summary>A header that will be displayed on the quote PDF.</summary>
        [<Config.Form>]Header: Choice<string,string> option
        ///<summary>All invoices will be billed using the specified settings.</summary>
        [<Config.Form>]InvoiceSettings: Update'InvoiceSettings option
        ///<summary>A list of line items the customer is being quoted for. Each line item includes information about the product, the quantity, and the resulting cost.</summary>
        [<Config.Form>]LineItems: Update'LineItems list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The account on behalf of which to charge.</summary>
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///<summary>When creating a subscription or subscription schedule, the specified configuration data will be used. There must be at least one line item with a recurring price for a subscription or subscription schedule to be created. A subscription schedule is created if `subscription_data[effective_date]` is present and in the future, otherwise a subscription is created.</summary>
        [<Config.Form>]SubscriptionData: Update'SubscriptionData option
        ///<summary>The data with which to automatically create a Transfer for each of the invoices.</summary>
        [<Config.Form>]TransferData: Choice<Update'TransferDataTransferDataSpecs,string> option
    }
    with
        static member New(quote: string, ?onBehalfOf: Choice<string,string>, ?metadata: Map<string, string>, ?lineItems: Update'LineItems list, ?invoiceSettings: Update'InvoiceSettings, ?header: Choice<string,string>, ?footer: Choice<string,string>, ?expiresAt: DateTime, ?expand: string list, ?discounts: Choice<Update'Discounts list,string>, ?description: Choice<string,string>, ?defaultTaxRates: Choice<string list,string>, ?customerAccount: string, ?customer: string, ?collectionMethod: Update'CollectionMethod, ?automaticTax: Update'AutomaticTax, ?applicationFeePercent: Choice<decimal,string>, ?applicationFeeAmount: Choice<int,string>, ?subscriptionData: Update'SubscriptionData, ?transferData: Choice<Update'TransferDataTransferDataSpecs,string>) =
            {
                Quote = quote
                ApplicationFeeAmount = applicationFeeAmount
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                CollectionMethod = collectionMethod
                Customer = customer
                CustomerAccount = customerAccount
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                Expand = expand
                ExpiresAt = expiresAt
                Footer = footer
                Header = header
                InvoiceSettings = invoiceSettings
                LineItems = lineItems
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                SubscriptionData = subscriptionData
                TransferData = transferData
            }

    ///<summary><p>A quote models prices and services for a customer.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/quotes/{options.Quote}"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

module QuotesAccept =

    type AcceptOptions = {
        [<Config.Path>]Quote: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(quote: string, ?expand: string list) =
            {
                Quote = quote
                Expand = expand
            }

    ///<summary><p>Accepts the specified quote.</p></summary>
    let Accept settings (options: AcceptOptions) =
        $"/v1/quotes/{options.Quote}/accept"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

module QuotesCancel =

    type CancelOptions = {
        [<Config.Path>]Quote: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(quote: string, ?expand: string list) =
            {
                Quote = quote
                Expand = expand
            }

    ///<summary><p>Cancels the quote.</p></summary>
    let Cancel settings (options: CancelOptions) =
        $"/v1/quotes/{options.Quote}/cancel"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

module QuotesComputedUpfrontLineItems =

    type ListComputedUpfrontLineItemsOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        [<Config.Path>]Quote: string
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(quote: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Quote = quote
                StartingAfter = startingAfter
            }

    ///<summary><p>When retrieving a quote, there is an includable <a href="https://stripe.com/docs/api/quotes/object#quote_object-computed-upfront-line_items"><strong>computed.upfront.line_items</strong></a> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of upfront line items.</p></summary>
    let ListComputedUpfrontLineItems settings (options: ListComputedUpfrontLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/quotes/{options.Quote}/computed_upfront_line_items"
        |> RestApi.getAsync<StripeList<Item>> settings qs

module QuotesFinalize =

    type FinalizeQuoteOptions = {
        [<Config.Path>]Quote: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A future timestamp on which the quote will be canceled if in `open` or `draft` status. Measured in seconds since the Unix epoch.</summary>
        [<Config.Form>]ExpiresAt: DateTime option
    }
    with
        static member New(quote: string, ?expand: string list, ?expiresAt: DateTime) =
            {
                Quote = quote
                Expand = expand
                ExpiresAt = expiresAt
            }

    ///<summary><p>Finalizes the quote.</p></summary>
    let FinalizeQuote settings (options: FinalizeQuoteOptions) =
        $"/v1/quotes/{options.Quote}/finalize"
        |> RestApi.postAsync<_, Quote> settings (Map.empty) options

module QuotesLineItems =

    type ListLineItemsOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        [<Config.Path>]Quote: string
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(quote: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Quote = quote
                StartingAfter = startingAfter
            }

    ///<summary><p>When retrieving a quote, there is an includable <strong>line_items</strong> property containing the first handful of those items. There is also a URL where you can retrieve the full (paginated) list of line items.</p></summary>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/quotes/{options.Quote}/line_items"
        |> RestApi.getAsync<StripeList<Item>> settings qs

module QuotesPdf =

    type PdfOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Quote: string
    }
    with
        static member New(quote: string, ?expand: string list) =
            {
                Expand = expand
                Quote = quote
            }

    ///<summary><p>Download the PDF for a finalized quote. Explanation for special handling can be found <a href="https://docs.stripe.com/quotes/overview#quote_pdf">here</a></p></summary>
    let Pdf settings (options: PdfOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/quotes/{options.Quote}/pdf"
        |> RestApi.getAsync<string> settings qs

module ShippingRates =

    type ListOptions = {
        ///<summary>Only return shipping rates that are active or inactive.</summary>
        [<Config.Query>]Active: bool option
        ///<summary>A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.</summary>
        [<Config.Query>]Created: int option
        ///<summary>Only return shipping rates for the given currency.</summary>
        [<Config.Query>]Currency: IsoTypes.IsoCurrencyCode option
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
        static member New(?active: bool, ?created: int, ?currency: IsoTypes.IsoCurrencyCode, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Active = active
                Created = created
                Currency = currency
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of your shipping rates.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("currency", options.Currency |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/shipping_rates"
        |> RestApi.getAsync<StripeList<ShippingRate>> settings qs

    type Create'DeliveryEstimateMaximumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Create'DeliveryEstimateMaximum = {
        ///<summary>A unit of time.</summary>
        [<Config.Form>]Unit: Create'DeliveryEstimateMaximumUnit option
        ///<summary>Must be greater than 0.</summary>
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Create'DeliveryEstimateMaximumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'DeliveryEstimateMinimumUnit =
    | BusinessDay
    | Day
    | Hour
    | Month
    | Week

    type Create'DeliveryEstimateMinimum = {
        ///<summary>A unit of time.</summary>
        [<Config.Form>]Unit: Create'DeliveryEstimateMinimumUnit option
        ///<summary>Must be greater than 0.</summary>
        [<Config.Form>]Value: int option
    }
    with
        static member New(?unit: Create'DeliveryEstimateMinimumUnit, ?value: int) =
            {
                Unit = unit
                Value = value
            }

    type Create'DeliveryEstimate = {
        ///<summary>The upper bound of the estimated range. If empty, represents no upper bound i.e., infinite.</summary>
        [<Config.Form>]Maximum: Create'DeliveryEstimateMaximum option
        ///<summary>The lower bound of the estimated range. If empty, represents no lower bound.</summary>
        [<Config.Form>]Minimum: Create'DeliveryEstimateMinimum option
    }
    with
        static member New(?maximum: Create'DeliveryEstimateMaximum, ?minimum: Create'DeliveryEstimateMinimum) =
            {
                Maximum = maximum
                Minimum = minimum
            }

    type Create'FixedAmount = {
        ///<summary>A non-negative integer in cents representing how much to charge.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]CurrencyOptions: Map<string, string> option
    }
    with
        static member New(?amount: int, ?currency: IsoTypes.IsoCurrencyCode, ?currencyOptions: Map<string, string>) =
            {
                Amount = amount
                Currency = currency
                CurrencyOptions = currencyOptions
            }

    type Create'TaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'Type =
    | FixedAmount

    type CreateOptions = {
        ///<summary>The estimated range for how long shipping will take, meant to be displayable to the customer. This will appear on CheckoutSessions.</summary>
        [<Config.Form>]DeliveryEstimate: Create'DeliveryEstimate option
        ///<summary>The name of the shipping rate, meant to be displayable to the customer. This will appear on CheckoutSessions.</summary>
        [<Config.Form>]DisplayName: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.</summary>
        [<Config.Form>]FixedAmount: Create'FixedAmount option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.</summary>
        [<Config.Form>]TaxBehavior: Create'TaxBehavior option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID. The Shipping tax code is `txcd_92010001`.</summary>
        [<Config.Form>]TaxCode: string option
        ///<summary>The type of calculation to use on the shipping rate.</summary>
        [<Config.Form>]Type: Create'Type option
    }
    with
        static member New(displayName: string, ?deliveryEstimate: Create'DeliveryEstimate, ?expand: string list, ?fixedAmount: Create'FixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Create'TaxBehavior, ?taxCode: string, ?type': Create'Type) =
            {
                DeliveryEstimate = deliveryEstimate
                DisplayName = displayName
                Expand = expand
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
                TaxCode = taxCode
                Type = type'
            }

    ///<summary><p>Creates a new shipping rate object.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/shipping_rates"
        |> RestApi.postAsync<_, ShippingRate> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]ShippingRateToken: string
    }
    with
        static member New(shippingRateToken: string, ?expand: string list) =
            {
                Expand = expand
                ShippingRateToken = shippingRateToken
            }

    ///<summary><p>Returns the shipping rate object with the given ID.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/shipping_rates/{options.ShippingRateToken}"
        |> RestApi.getAsync<ShippingRate> settings qs

    type Update'FixedAmount = {
        ///<summary>Shipping rates defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]CurrencyOptions: Map<string, string> option
    }
    with
        static member New(?currencyOptions: Map<string, string>) =
            {
                CurrencyOptions = currencyOptions
            }

    type Update'TaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type UpdateOptions = {
        [<Config.Path>]ShippingRateToken: string
        ///<summary>Whether the shipping rate can be used for new purchases. Defaults to `true`.</summary>
        [<Config.Form>]Active: bool option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Describes a fixed amount to charge for shipping. Must be present if type is `fixed_amount`.</summary>
        [<Config.Form>]FixedAmount: Update'FixedAmount option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Specifies whether the rate is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`.</summary>
        [<Config.Form>]TaxBehavior: Update'TaxBehavior option
    }
    with
        static member New(shippingRateToken: string, ?active: bool, ?expand: string list, ?fixedAmount: Update'FixedAmount, ?metadata: Map<string, string>, ?taxBehavior: Update'TaxBehavior) =
            {
                ShippingRateToken = shippingRateToken
                Active = active
                Expand = expand
                FixedAmount = fixedAmount
                Metadata = metadata
                TaxBehavior = taxBehavior
            }

    ///<summary><p>Updates an existing shipping rate object.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/shipping_rates/{options.ShippingRateToken}"
        |> RestApi.postAsync<_, ShippingRate> settings (Map.empty) options

module SubscriptionItems =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>The ID of the subscription whose items will be retrieved.</summary>
        [<Config.Query>]Subscription: string
    }
    with
        static member New(subscription: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Subscription = subscription
            }

    ///<summary><p>Returns a list of your subscription items for a given subscription.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("subscription", options.Subscription |> box)] |> Map.ofList
        $"/v1/subscription_items"
        |> RestApi.getAsync<StripeList<SubscriptionItem>> settings qs

    type Create'BillingThresholdsItemBillingThresholds = {
        ///<summary>Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))</summary>
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Create'Discounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Create'PriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'PriceDataRecurring = {
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Create'PriceDataRecurringInterval option
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'PriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'PriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'PriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>The recurring components of a price such as `interval` and `interval_count`.</summary>
        [<Config.Form>]Recurring: Create'PriceDataRecurring option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Create'PriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: Create'PriceDataRecurring, ?taxBehavior: Create'PriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'PaymentBehavior =
    | AllowIncomplete
    | DefaultIncomplete
    | ErrorIfIncomplete
    | PendingIfIncomplete

    type Create'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type CreateOptions = {
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<Create'BillingThresholdsItemBillingThresholds,string> option
        ///<summary>The coupons to redeem into discounts for the subscription item.</summary>
        [<Config.Form>]Discounts: Choice<Create'Discounts list,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://docs.stripe.com/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
        ///Use `default_incomplete` to transition the subscription to `status=past_due` when payment is required and await explicit confirmation of the invoice's payment intent. This allows simpler management of scenarios where additional user actions are needed to pay a subscription’s invoice. Such as failed payments, [SCA regulation](https://docs.stripe.com/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method.
        ///Use `pending_if_incomplete` to update the subscription using [pending updates](https://docs.stripe.com/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://docs.stripe.com/billing/pending-updates-reference#supported-attributes).
        ///Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://docs.stripe.com/changelog/2019-03-14) to learn more.</summary>
        [<Config.Form>]PaymentBehavior: Create'PaymentBehavior option
        ///<summary>The identifier of the plan to add to the subscription.</summary>
        [<Config.Form>]Plan: string option
        ///<summary>The ID of the price object.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.</summary>
        [<Config.Form>]PriceData: Create'PriceData option
        ///<summary>Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.</summary>
        [<Config.Form>]ProrationBehavior: Create'ProrationBehavior option
        ///<summary>If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply the same proration that was previewed with the [upcoming invoice](/api/invoices/create_preview) endpoint.</summary>
        [<Config.Form>]ProrationDate: DateTime option
        ///<summary>The quantity you'd like to apply to the subscription item you're creating.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>The identifier of the subscription to modify.</summary>
        [<Config.Form>]Subscription: string
        ///<summary>A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(subscription: string, ?billingThresholds: Choice<Create'BillingThresholdsItemBillingThresholds,string>, ?discounts: Choice<Create'Discounts list,string>, ?expand: string list, ?metadata: Map<string, string>, ?paymentBehavior: Create'PaymentBehavior, ?plan: string, ?price: string, ?priceData: Create'PriceData, ?prorationBehavior: Create'ProrationBehavior, ?prorationDate: DateTime, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Discounts = discounts
                Expand = expand
                Metadata = metadata
                PaymentBehavior = paymentBehavior
                Plan = plan
                Price = price
                PriceData = priceData
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
                Quantity = quantity
                Subscription = subscription
                TaxRates = taxRates
            }

    ///<summary><p>Adds a new item to an existing subscription. No existing items will be changed or replaced.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/subscription_items"
        |> RestApi.postAsync<_, SubscriptionItem> settings (Map.empty) options

    type Delete'PaymentBehavior =
    | AllowIncomplete
    | DefaultIncomplete
    | ErrorIfIncomplete
    | PendingIfIncomplete

    type Delete'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type DeleteOptions = {
        [<Config.Path>]Item: string
        ///<summary>Delete all usage for the given subscription item. Allowed only when the current plan's `usage_type` is `metered`.</summary>
        [<Config.Form>]ClearUsage: bool option
        ///<summary>Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://docs.stripe.com/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
        ///Use `default_incomplete` to transition the subscription to `status=past_due` when payment is required and await explicit confirmation of the invoice's payment intent. This allows simpler management of scenarios where additional user actions are needed to pay a subscription’s invoice. Such as failed payments, [SCA regulation](https://docs.stripe.com/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method.
        ///Use `pending_if_incomplete` to update the subscription using [pending updates](https://docs.stripe.com/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://docs.stripe.com/billing/pending-updates-reference#supported-attributes).
        ///Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://docs.stripe.com/changelog/2019-03-14) to learn more.</summary>
        [<Config.Form>]PaymentBehavior: Delete'PaymentBehavior option
        ///<summary>Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.</summary>
        [<Config.Form>]ProrationBehavior: Delete'ProrationBehavior option
        ///<summary>If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply the same proration that was previewed with the [upcoming invoice](/api/invoices/create_preview) endpoint.</summary>
        [<Config.Form>]ProrationDate: DateTime option
    }
    with
        static member New(item: string, ?clearUsage: bool, ?paymentBehavior: Delete'PaymentBehavior, ?prorationBehavior: Delete'ProrationBehavior, ?prorationDate: DateTime) =
            {
                Item = item
                ClearUsage = clearUsage
                PaymentBehavior = paymentBehavior
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
            }

    ///<summary><p>Deletes an item from the subscription. Removing a subscription item from a subscription will not cancel the subscription.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/subscription_items/{options.Item}"
        |> RestApi.deleteAsync<DeletedSubscriptionItem> settings (Map.empty)

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

    ///<summary><p>Retrieves the subscription item with the given ID.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/subscription_items/{options.Item}"
        |> RestApi.getAsync<SubscriptionItem> settings qs

    type Update'BillingThresholdsItemBillingThresholds = {
        ///<summary>Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))</summary>
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Update'Discounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'PriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Update'PriceDataRecurring = {
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Update'PriceDataRecurringInterval option
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Update'PriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Update'PriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'PriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>The recurring components of a price such as `interval` and `interval_count`.</summary>
        [<Config.Form>]Recurring: Update'PriceDataRecurring option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Update'PriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: Update'PriceDataRecurring, ?taxBehavior: Update'PriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'PaymentBehavior =
    | AllowIncomplete
    | DefaultIncomplete
    | ErrorIfIncomplete
    | PendingIfIncomplete

    type Update'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type UpdateOptions = {
        [<Config.Path>]Item: string
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<Update'BillingThresholdsItemBillingThresholds,string> option
        ///<summary>The coupons to redeem into discounts for the subscription item.</summary>
        [<Config.Form>]Discounts: Choice<Update'Discounts list,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Indicates if a customer is on or off-session while an invoice payment is attempted. Defaults to `false` (on-session).</summary>
        [<Config.Form>]OffSession: bool option
        ///<summary>Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://docs.stripe.com/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
        ///Use `default_incomplete` to transition the subscription to `status=past_due` when payment is required and await explicit confirmation of the invoice's payment intent. This allows simpler management of scenarios where additional user actions are needed to pay a subscription’s invoice. Such as failed payments, [SCA regulation](https://docs.stripe.com/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method.
        ///Use `pending_if_incomplete` to update the subscription using [pending updates](https://docs.stripe.com/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://docs.stripe.com/billing/pending-updates-reference#supported-attributes).
        ///Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://docs.stripe.com/changelog/2019-03-14) to learn more.</summary>
        [<Config.Form>]PaymentBehavior: Update'PaymentBehavior option
        ///<summary>The identifier of the new plan for this subscription item.</summary>
        [<Config.Form>]Plan: string option
        ///<summary>The ID of the price object. One of `price` or `price_data` is required. When changing a subscription item's price, `quantity` is set to 1 unless a `quantity` parameter is provided.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]PriceData: Update'PriceData option
        ///<summary>Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.</summary>
        [<Config.Form>]ProrationBehavior: Update'ProrationBehavior option
        ///<summary>If set, the proration will be calculated as though the subscription was updated at the given time. This can be used to apply the same proration that was previewed with the [upcoming invoice](/api/invoices/create_preview) endpoint.</summary>
        [<Config.Form>]ProrationDate: DateTime option
        ///<summary>The quantity you'd like to apply to the subscription item you're creating.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(item: string, ?billingThresholds: Choice<Update'BillingThresholdsItemBillingThresholds,string>, ?discounts: Choice<Update'Discounts list,string>, ?expand: string list, ?metadata: Map<string, string>, ?offSession: bool, ?paymentBehavior: Update'PaymentBehavior, ?plan: string, ?price: string, ?priceData: Update'PriceData, ?prorationBehavior: Update'ProrationBehavior, ?prorationDate: DateTime, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Item = item
                BillingThresholds = billingThresholds
                Discounts = discounts
                Expand = expand
                Metadata = metadata
                OffSession = offSession
                PaymentBehavior = paymentBehavior
                Plan = plan
                Price = price
                PriceData = priceData
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
                Quantity = quantity
                TaxRates = taxRates
            }

    ///<summary><p>Updates the plan or quantity of an item on a current subscription.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/subscription_items/{options.Item}"
        |> RestApi.postAsync<_, SubscriptionItem> settings (Map.empty) options

module SubscriptionSchedules =

    type ListOptions = {
        ///<summary>Only return subscription schedules that were created canceled the given date interval.</summary>
        [<Config.Query>]CanceledAt: int option
        ///<summary>Only return subscription schedules that completed during the given date interval.</summary>
        [<Config.Query>]CompletedAt: int option
        ///<summary>Only return subscription schedules that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>Only return subscription schedules for the given customer.</summary>
        [<Config.Query>]Customer: string option
        ///<summary>Only return subscription schedules for the given account.</summary>
        [<Config.Query>]CustomerAccount: string option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>Only return subscription schedules that were released during the given date interval.</summary>
        [<Config.Query>]ReleasedAt: int option
        ///<summary>Only return subscription schedules that have not started yet.</summary>
        [<Config.Query>]Scheduled: bool option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?canceledAt: int, ?completedAt: int, ?created: int, ?customer: string, ?customerAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?releasedAt: int, ?scheduled: bool, ?startingAfter: string) =
            {
                CanceledAt = canceledAt
                CompletedAt = completedAt
                Created = created
                Customer = customer
                CustomerAccount = customerAccount
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                ReleasedAt = releasedAt
                Scheduled = scheduled
                StartingAfter = startingAfter
            }

    ///<summary><p>Retrieves the list of your subscription schedules.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("canceled_at", options.CanceledAt |> box); ("completed_at", options.CompletedAt |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("released_at", options.ReleasedAt |> box); ("scheduled", options.Scheduled |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/subscription_schedules"
        |> RestApi.getAsync<StripeList<SubscriptionSchedule>> settings qs

    type Create'BillingModeFlexibleProrationDiscounts =
    | Included
    | Itemized

    type Create'BillingModeFlexible = {
        ///<summary>Controls how invoices and invoice items display proration amounts and discount amounts.</summary>
        [<Config.Form>]ProrationDiscounts: Create'BillingModeFlexibleProrationDiscounts option
    }
    with
        static member New(?prorationDiscounts: Create'BillingModeFlexibleProrationDiscounts) =
            {
                ProrationDiscounts = prorationDiscounts
            }

    type Create'BillingModeType =
    | Classic
    | Flexible

    type Create'BillingMode = {
        ///<summary>Configure behavior for flexible billing mode.</summary>
        [<Config.Form>]Flexible: Create'BillingModeFlexible option
        ///<summary>Controls the calculation and orchestration of prorations and invoices for subscriptions. If no value is passed, the default is `flexible`.</summary>
        [<Config.Form>]Type: Create'BillingModeType option
    }
    with
        static member New(?flexible: Create'BillingModeFlexible, ?type': Create'BillingModeType) =
            {
                Flexible = flexible
                Type = type'
            }

    type Create'DefaultSettingsAutomaticTaxLiabilityType =
    | Account
    | Self

    type Create'DefaultSettingsAutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Create'DefaultSettingsAutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': Create'DefaultSettingsAutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Create'DefaultSettingsAutomaticTax = {
        ///<summary>Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: Create'DefaultSettingsAutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: Create'DefaultSettingsAutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Create'DefaultSettingsBillingThresholdsBillingThresholds = {
        ///<summary>Monetary threshold that triggers the subscription to advance to a new billing period</summary>
        [<Config.Form>]AmountGte: int option
        ///<summary>Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.</summary>
        [<Config.Form>]ResetBillingCycleAnchor: bool option
    }
    with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Create'DefaultSettingsInvoiceSettingsIssuerType =
    | Account
    | Self

    type Create'DefaultSettingsInvoiceSettingsIssuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Create'DefaultSettingsInvoiceSettingsIssuerType option
    }
    with
        static member New(?account: string, ?type': Create'DefaultSettingsInvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Create'DefaultSettingsInvoiceSettings = {
        ///<summary>The account tax IDs associated with the subscription schedule. Will be set on invoices generated by the subscription schedule.</summary>
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///<summary>Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `collection_method=charge_automatically`.</summary>
        [<Config.Form>]DaysUntilDue: int option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Create'DefaultSettingsInvoiceSettingsIssuer option
    }
    with
        static member New(?accountTaxIds: Choice<string list,string>, ?daysUntilDue: int, ?issuer: Create'DefaultSettingsInvoiceSettingsIssuer) =
            {
                AccountTaxIds = accountTaxIds
                DaysUntilDue = daysUntilDue
                Issuer = issuer
            }

    type Create'DefaultSettingsTransferDataTransferDataSpecs = {
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.</summary>
        [<Config.Form>]AmountPercent: decimal option
        ///<summary>ID of an existing, connected Stripe account.</summary>
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Create'DefaultSettingsBillingCycleAnchor =
    | Automatic
    | PhaseStart

    type Create'DefaultSettingsCollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Create'DefaultSettings = {
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).</summary>
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///<summary>Default settings for automatic tax computation.</summary>
        [<Config.Form>]AutomaticTax: Create'DefaultSettingsAutomaticTax option
        ///<summary>Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).</summary>
        [<Config.Form>]BillingCycleAnchor: Create'DefaultSettingsBillingCycleAnchor option
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<Create'DefaultSettingsBillingThresholdsBillingThresholds,string> option
        ///<summary>Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.</summary>
        [<Config.Form>]CollectionMethod: Create'DefaultSettingsCollectionMethod option
        ///<summary>ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.</summary>
        [<Config.Form>]DefaultPaymentMethod: string option
        ///<summary>Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.</summary>
        [<Config.Form>]Description: Choice<string,string> option
        ///<summary>All invoices will be billed using the specified settings.</summary>
        [<Config.Form>]InvoiceSettings: Create'DefaultSettingsInvoiceSettings option
        ///<summary>The account on behalf of which to charge, for each of the associated subscription's invoices.</summary>
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///<summary>The data with which to automatically create a Transfer for each of the associated subscription's invoices.</summary>
        [<Config.Form>]TransferData: Choice<Create'DefaultSettingsTransferDataTransferDataSpecs,string> option
    }
    with
        static member New(?applicationFeePercent: decimal, ?automaticTax: Create'DefaultSettingsAutomaticTax, ?billingCycleAnchor: Create'DefaultSettingsBillingCycleAnchor, ?billingThresholds: Choice<Create'DefaultSettingsBillingThresholdsBillingThresholds,string>, ?collectionMethod: Create'DefaultSettingsCollectionMethod, ?defaultPaymentMethod: string, ?description: Choice<string,string>, ?invoiceSettings: Create'DefaultSettingsInvoiceSettings, ?onBehalfOf: Choice<string,string>, ?transferData: Choice<Create'DefaultSettingsTransferDataTransferDataSpecs,string>) =
            {
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                DefaultPaymentMethod = defaultPaymentMethod
                Description = description
                InvoiceSettings = invoiceSettings
                OnBehalfOf = onBehalfOf
                TransferData = transferData
            }

    type Create'PhasesAddInvoiceItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Create'PhasesAddInvoiceItemsPeriodEndType =
    | MinItemPeriodEnd
    | PhaseEnd
    | Timestamp

    type Create'PhasesAddInvoiceItemsPeriodEnd = {
        ///<summary>A precise Unix timestamp for the end of the invoice item period. Must be greater than or equal to `period.start`.</summary>
        [<Config.Form>]Timestamp: DateTime option
        ///<summary>Select how to calculate the end of the invoice item period.</summary>
        [<Config.Form>]Type: Create'PhasesAddInvoiceItemsPeriodEndType option
    }
    with
        static member New(?timestamp: DateTime, ?type': Create'PhasesAddInvoiceItemsPeriodEndType) =
            {
                Timestamp = timestamp
                Type = type'
            }

    type Create'PhasesAddInvoiceItemsPeriodStartType =
    | MaxItemPeriodStart
    | PhaseStart
    | Timestamp

    type Create'PhasesAddInvoiceItemsPeriodStart = {
        ///<summary>A precise Unix timestamp for the start of the invoice item period. Must be less than or equal to `period.end`.</summary>
        [<Config.Form>]Timestamp: DateTime option
        ///<summary>Select how to calculate the start of the invoice item period.</summary>
        [<Config.Form>]Type: Create'PhasesAddInvoiceItemsPeriodStartType option
    }
    with
        static member New(?timestamp: DateTime, ?type': Create'PhasesAddInvoiceItemsPeriodStartType) =
            {
                Timestamp = timestamp
                Type = type'
            }

    type Create'PhasesAddInvoiceItemsPeriod = {
        ///<summary>End of the invoice item period.</summary>
        [<Config.Form>]End: Create'PhasesAddInvoiceItemsPeriodEnd option
        ///<summary>Start of the invoice item period.</summary>
        [<Config.Form>]Start: Create'PhasesAddInvoiceItemsPeriodStart option
    }
    with
        static member New(?end': Create'PhasesAddInvoiceItemsPeriodEnd, ?start: Create'PhasesAddInvoiceItemsPeriodStart) =
            {
                End = end'
                Start = start
            }

    type Create'PhasesAddInvoiceItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'PhasesAddInvoiceItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Create'PhasesAddInvoiceItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge or a negative integer representing the amount to credit to the customer.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?taxBehavior: Create'PhasesAddInvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'PhasesAddInvoiceItems = {
        ///<summary>The coupons to redeem into discounts for the item.</summary>
        [<Config.Form>]Discounts: Create'PhasesAddInvoiceItemsDiscounts list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The period associated with this invoice item. If not set, `period.start.type` defaults to `max_item_period_start` and `period.end.type` defaults to `min_item_period_end`.</summary>
        [<Config.Form>]Period: Create'PhasesAddInvoiceItemsPeriod option
        ///<summary>The ID of the price object. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]PriceData: Create'PhasesAddInvoiceItemsPriceData option
        ///<summary>Quantity for this item. Defaults to 1.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?discounts: Create'PhasesAddInvoiceItemsDiscounts list, ?metadata: Map<string, string>, ?period: Create'PhasesAddInvoiceItemsPeriod, ?price: string, ?priceData: Create'PhasesAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Discounts = discounts
                Metadata = metadata
                Period = period
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Create'PhasesAutomaticTaxLiabilityType =
    | Account
    | Self

    type Create'PhasesAutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Create'PhasesAutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': Create'PhasesAutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Create'PhasesAutomaticTax = {
        ///<summary>Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: Create'PhasesAutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: Create'PhasesAutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Create'PhasesBillingThresholdsBillingThresholds = {
        ///<summary>Monetary threshold that triggers the subscription to advance to a new billing period</summary>
        [<Config.Form>]AmountGte: int option
        ///<summary>Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.</summary>
        [<Config.Form>]ResetBillingCycleAnchor: bool option
    }
    with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Create'PhasesDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Create'PhasesDurationInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'PhasesDuration = {
        ///<summary>Specifies phase duration. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Create'PhasesDurationInterval option
        ///<summary>The multiplier applied to the interval.</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'PhasesDurationInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'PhasesInvoiceSettingsIssuerType =
    | Account
    | Self

    type Create'PhasesInvoiceSettingsIssuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Create'PhasesInvoiceSettingsIssuerType option
    }
    with
        static member New(?account: string, ?type': Create'PhasesInvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Create'PhasesInvoiceSettings = {
        ///<summary>The account tax IDs associated with this phase of the subscription schedule. Will be set on invoices generated by this phase of the subscription schedule.</summary>
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///<summary>Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `billing=charge_automatically`.</summary>
        [<Config.Form>]DaysUntilDue: int option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Create'PhasesInvoiceSettingsIssuer option
    }
    with
        static member New(?accountTaxIds: Choice<string list,string>, ?daysUntilDue: int, ?issuer: Create'PhasesInvoiceSettingsIssuer) =
            {
                AccountTaxIds = accountTaxIds
                DaysUntilDue = daysUntilDue
                Issuer = issuer
            }

    type Create'PhasesItemsBillingThresholdsItemBillingThresholds = {
        ///<summary>Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))</summary>
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Create'PhasesItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Create'PhasesItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'PhasesItemsPriceDataRecurring = {
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Create'PhasesItemsPriceDataRecurringInterval option
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'PhasesItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'PhasesItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'PhasesItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>The recurring components of a price such as `interval` and `interval_count`.</summary>
        [<Config.Form>]Recurring: Create'PhasesItemsPriceDataRecurring option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Create'PhasesItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: Create'PhasesItemsPriceDataRecurring, ?taxBehavior: Create'PhasesItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'PhasesItems = {
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<Create'PhasesItemsBillingThresholdsItemBillingThresholds,string> option
        ///<summary>The coupons to redeem into discounts for the subscription item.</summary>
        [<Config.Form>]Discounts: Choice<Create'PhasesItemsDiscounts list,string> option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to a configuration item. Metadata on a configuration item will update the underlying subscription item's `metadata` when the phase is entered, adding new keys and replacing existing keys. Individual keys in the subscription item's `metadata` can be unset by posting an empty value to them in the configuration item's `metadata`. To unset all keys in the subscription item's `metadata`, update the subscription item directly or unset every key individually from the configuration item's `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The plan ID to subscribe to. You may specify the same ID in `plan` and `price`.</summary>
        [<Config.Form>]Plan: string option
        ///<summary>The ID of the price object.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.</summary>
        [<Config.Form>]PriceData: Create'PhasesItemsPriceData option
        ///<summary>Quantity for the given price. Can be set only if the price's `usage_type` is `licensed` and not `metered`.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?billingThresholds: Choice<Create'PhasesItemsBillingThresholdsItemBillingThresholds,string>, ?discounts: Choice<Create'PhasesItemsDiscounts list,string>, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: Create'PhasesItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Discounts = discounts
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Create'PhasesTransferData = {
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.</summary>
        [<Config.Form>]AmountPercent: decimal option
        ///<summary>ID of an existing, connected Stripe account.</summary>
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Create'PhasesBillingCycleAnchor =
    | Automatic
    | PhaseStart

    type Create'PhasesCollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Create'PhasesProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type Create'Phases = {
        ///<summary>A list of prices and quantities that will generate invoice items appended to the next invoice for this phase. You may pass up to 20 items.</summary>
        [<Config.Form>]AddInvoiceItems: Create'PhasesAddInvoiceItems list option
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).</summary>
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///<summary>Automatic tax settings for this phase.</summary>
        [<Config.Form>]AutomaticTax: Create'PhasesAutomaticTax option
        ///<summary>Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).</summary>
        [<Config.Form>]BillingCycleAnchor: Create'PhasesBillingCycleAnchor option
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<Create'PhasesBillingThresholdsBillingThresholds,string> option
        ///<summary>Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.</summary>
        [<Config.Form>]CollectionMethod: Create'PhasesCollectionMethod option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.</summary>
        [<Config.Form>]DefaultPaymentMethod: string option
        ///<summary>A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will set the Subscription's [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates), which means they will be the Invoice's [`default_tax_rates`](https://docs.stripe.com/api/invoices/create#create_invoice-default_tax_rates) for any Invoices issued by the Subscription during this Phase.</summary>
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///<summary>Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.</summary>
        [<Config.Form>]Description: Choice<string,string> option
        ///<summary>The coupons to redeem into discounts for the schedule phase. If not specified, inherits the discount from the subscription's customer. Pass an empty string to avoid inheriting any discounts.</summary>
        [<Config.Form>]Discounts: Choice<Create'PhasesDiscounts list,string> option
        ///<summary>The number of intervals the phase should last. If set, `end_date` must not be set.</summary>
        [<Config.Form>]Duration: Create'PhasesDuration option
        ///<summary>The date at which this phase of the subscription schedule ends. If set, `duration` must not be set.</summary>
        [<Config.Form>]EndDate: DateTime option
        ///<summary>All invoices will be billed using the specified settings.</summary>
        [<Config.Form>]InvoiceSettings: Create'PhasesInvoiceSettings option
        ///<summary>List of configuration items, each with an attached price, to apply during this phase of the subscription schedule.</summary>
        [<Config.Form>]Items: Create'PhasesItems list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to a phase. Metadata on a schedule's phase will update the underlying subscription's `metadata` when the phase is entered, adding new keys and replacing existing keys in the subscription's `metadata`. Individual keys in the subscription's `metadata` can be unset by posting an empty value to them in the phase's `metadata`. To unset all keys in the subscription's `metadata`, update the subscription directly or unset every key individually from the phase's `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The account on behalf of which to charge, for each of the associated subscription's invoices.</summary>
        [<Config.Form>]OnBehalfOf: string option
        ///<summary>Controls whether the subscription schedule should create [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when transitioning to this phase if there is a difference in billing configuration. It's different from the request-level [proration_behavior](https://docs.stripe.com/api/subscription_schedules/update#update_subscription_schedule-proration_behavior) parameter which controls what happens if the update request affects the billing configuration (item price, quantity, etc.) of the current phase.</summary>
        [<Config.Form>]ProrationBehavior: Create'PhasesProrationBehavior option
        ///<summary>The data with which to automatically create a Transfer for each of the associated subscription's invoices.</summary>
        [<Config.Form>]TransferData: Create'PhasesTransferData option
        ///<summary>If set to true the entire phase is counted as a trial and the customer will not be charged for any fees.</summary>
        [<Config.Form>]Trial: bool option
        ///<summary>Sets the phase to trialing from the start date to this date. Must be before the phase end date, can not be combined with `trial`</summary>
        [<Config.Form>]TrialEnd: DateTime option
    }
    with
        static member New(?addInvoiceItems: Create'PhasesAddInvoiceItems list, ?transferData: Create'PhasesTransferData, ?prorationBehavior: Create'PhasesProrationBehavior, ?onBehalfOf: string, ?metadata: Map<string, string>, ?items: Create'PhasesItems list, ?invoiceSettings: Create'PhasesInvoiceSettings, ?endDate: DateTime, ?duration: Create'PhasesDuration, ?trial: bool, ?discounts: Choice<Create'PhasesDiscounts list,string>, ?defaultTaxRates: Choice<string list,string>, ?defaultPaymentMethod: string, ?currency: IsoTypes.IsoCurrencyCode, ?collectionMethod: Create'PhasesCollectionMethod, ?billingThresholds: Choice<Create'PhasesBillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: Create'PhasesBillingCycleAnchor, ?automaticTax: Create'PhasesAutomaticTax, ?applicationFeePercent: decimal, ?description: Choice<string,string>, ?trialEnd: DateTime) =
            {
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                Currency = currency
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                Duration = duration
                EndDate = endDate
                InvoiceSettings = invoiceSettings
                Items = items
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                ProrationBehavior = prorationBehavior
                TransferData = transferData
                Trial = trial
                TrialEnd = trialEnd
            }

    type Create'StartDate =
    | Now

    type Create'EndBehavior =
    | Cancel
    | None'
    | Release
    | Renew

    type CreateOptions = {
        ///<summary>Controls how prorations and invoices for subscriptions are calculated and orchestrated.</summary>
        [<Config.Form>]BillingMode: Create'BillingMode option
        ///<summary>The identifier of the customer to create the subscription schedule for.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>The identifier of the account to create the subscription schedule for.</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>Object representing the subscription schedule's default settings.</summary>
        [<Config.Form>]DefaultSettings: Create'DefaultSettings option
        ///<summary>Behavior of the subscription schedule and underlying subscription when it ends. Possible values are `release` or `cancel` with the default being `release`. `release` will end the subscription schedule and keep the underlying subscription running. `cancel` will end the subscription schedule and cancel the underlying subscription.</summary>
        [<Config.Form>]EndBehavior: Create'EndBehavior option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Migrate an existing subscription to be managed by a subscription schedule. If this parameter is set, a subscription schedule will be created using the subscription's item(s), set to auto-renew using the subscription's interval. When using this parameter, other parameters (such as phase values) cannot be set. To create a subscription schedule with other modifications, we recommend making two separate API calls.</summary>
        [<Config.Form>]FromSubscription: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>List representing phases of the subscription schedule. Each phase can be customized to have different durations, plans, and coupons. If there are multiple phases, the `end_date` of one phase will always equal the `start_date` of the next phase.</summary>
        [<Config.Form>]Phases: Create'Phases list option
        ///<summary>When the subscription schedule starts. We recommend using `now` so that it starts the subscription immediately. You can also use a Unix timestamp to backdate the subscription so that it starts on a past date, or set a future date for the subscription to start on.</summary>
        [<Config.Form>]StartDate: Choice<DateTime,Create'StartDate> option
    }
    with
        static member New(?billingMode: Create'BillingMode, ?customer: string, ?customerAccount: string, ?defaultSettings: Create'DefaultSettings, ?endBehavior: Create'EndBehavior, ?expand: string list, ?fromSubscription: string, ?metadata: Map<string, string>, ?phases: Create'Phases list, ?startDate: Choice<DateTime,Create'StartDate>) =
            {
                BillingMode = billingMode
                Customer = customer
                CustomerAccount = customerAccount
                DefaultSettings = defaultSettings
                EndBehavior = endBehavior
                Expand = expand
                FromSubscription = fromSubscription
                Metadata = metadata
                Phases = phases
                StartDate = startDate
            }

    ///<summary><p>Creates a new subscription schedule object. Each customer can have up to 500 active or scheduled subscriptions.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/subscription_schedules"
        |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Schedule: string
    }
    with
        static member New(schedule: string, ?expand: string list) =
            {
                Expand = expand
                Schedule = schedule
            }

    ///<summary><p>Retrieves the details of an existing subscription schedule. You only need to supply the unique subscription schedule identifier that was returned upon subscription schedule creation.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/subscription_schedules/{options.Schedule}"
        |> RestApi.getAsync<SubscriptionSchedule> settings qs

    type Update'DefaultSettingsAutomaticTaxLiabilityType =
    | Account
    | Self

    type Update'DefaultSettingsAutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Update'DefaultSettingsAutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': Update'DefaultSettingsAutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Update'DefaultSettingsAutomaticTax = {
        ///<summary>Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: Update'DefaultSettingsAutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: Update'DefaultSettingsAutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Update'DefaultSettingsBillingThresholdsBillingThresholds = {
        ///<summary>Monetary threshold that triggers the subscription to advance to a new billing period</summary>
        [<Config.Form>]AmountGte: int option
        ///<summary>Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.</summary>
        [<Config.Form>]ResetBillingCycleAnchor: bool option
    }
    with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Update'DefaultSettingsInvoiceSettingsIssuerType =
    | Account
    | Self

    type Update'DefaultSettingsInvoiceSettingsIssuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Update'DefaultSettingsInvoiceSettingsIssuerType option
    }
    with
        static member New(?account: string, ?type': Update'DefaultSettingsInvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Update'DefaultSettingsInvoiceSettings = {
        ///<summary>The account tax IDs associated with the subscription schedule. Will be set on invoices generated by the subscription schedule.</summary>
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///<summary>Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `collection_method=charge_automatically`.</summary>
        [<Config.Form>]DaysUntilDue: int option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Update'DefaultSettingsInvoiceSettingsIssuer option
    }
    with
        static member New(?accountTaxIds: Choice<string list,string>, ?daysUntilDue: int, ?issuer: Update'DefaultSettingsInvoiceSettingsIssuer) =
            {
                AccountTaxIds = accountTaxIds
                DaysUntilDue = daysUntilDue
                Issuer = issuer
            }

    type Update'DefaultSettingsTransferDataTransferDataSpecs = {
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.</summary>
        [<Config.Form>]AmountPercent: decimal option
        ///<summary>ID of an existing, connected Stripe account.</summary>
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Update'DefaultSettingsBillingCycleAnchor =
    | Automatic
    | PhaseStart

    type Update'DefaultSettingsCollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Update'DefaultSettings = {
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).</summary>
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///<summary>Default settings for automatic tax computation.</summary>
        [<Config.Form>]AutomaticTax: Update'DefaultSettingsAutomaticTax option
        ///<summary>Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).</summary>
        [<Config.Form>]BillingCycleAnchor: Update'DefaultSettingsBillingCycleAnchor option
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<Update'DefaultSettingsBillingThresholdsBillingThresholds,string> option
        ///<summary>Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.</summary>
        [<Config.Form>]CollectionMethod: Update'DefaultSettingsCollectionMethod option
        ///<summary>ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.</summary>
        [<Config.Form>]DefaultPaymentMethod: string option
        ///<summary>Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.</summary>
        [<Config.Form>]Description: Choice<string,string> option
        ///<summary>All invoices will be billed using the specified settings.</summary>
        [<Config.Form>]InvoiceSettings: Update'DefaultSettingsInvoiceSettings option
        ///<summary>The account on behalf of which to charge, for each of the associated subscription's invoices.</summary>
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///<summary>The data with which to automatically create a Transfer for each of the associated subscription's invoices.</summary>
        [<Config.Form>]TransferData: Choice<Update'DefaultSettingsTransferDataTransferDataSpecs,string> option
    }
    with
        static member New(?applicationFeePercent: decimal, ?automaticTax: Update'DefaultSettingsAutomaticTax, ?billingCycleAnchor: Update'DefaultSettingsBillingCycleAnchor, ?billingThresholds: Choice<Update'DefaultSettingsBillingThresholdsBillingThresholds,string>, ?collectionMethod: Update'DefaultSettingsCollectionMethod, ?defaultPaymentMethod: string, ?description: Choice<string,string>, ?invoiceSettings: Update'DefaultSettingsInvoiceSettings, ?onBehalfOf: Choice<string,string>, ?transferData: Choice<Update'DefaultSettingsTransferDataTransferDataSpecs,string>) =
            {
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                DefaultPaymentMethod = defaultPaymentMethod
                Description = description
                InvoiceSettings = invoiceSettings
                OnBehalfOf = onBehalfOf
                TransferData = transferData
            }

    type Update'PhasesAddInvoiceItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'PhasesAddInvoiceItemsPeriodEndType =
    | MinItemPeriodEnd
    | PhaseEnd
    | Timestamp

    type Update'PhasesAddInvoiceItemsPeriodEnd = {
        ///<summary>A precise Unix timestamp for the end of the invoice item period. Must be greater than or equal to `period.start`.</summary>
        [<Config.Form>]Timestamp: DateTime option
        ///<summary>Select how to calculate the end of the invoice item period.</summary>
        [<Config.Form>]Type: Update'PhasesAddInvoiceItemsPeriodEndType option
    }
    with
        static member New(?timestamp: DateTime, ?type': Update'PhasesAddInvoiceItemsPeriodEndType) =
            {
                Timestamp = timestamp
                Type = type'
            }

    type Update'PhasesAddInvoiceItemsPeriodStartType =
    | MaxItemPeriodStart
    | PhaseStart
    | Timestamp

    type Update'PhasesAddInvoiceItemsPeriodStart = {
        ///<summary>A precise Unix timestamp for the start of the invoice item period. Must be less than or equal to `period.end`.</summary>
        [<Config.Form>]Timestamp: DateTime option
        ///<summary>Select how to calculate the start of the invoice item period.</summary>
        [<Config.Form>]Type: Update'PhasesAddInvoiceItemsPeriodStartType option
    }
    with
        static member New(?timestamp: DateTime, ?type': Update'PhasesAddInvoiceItemsPeriodStartType) =
            {
                Timestamp = timestamp
                Type = type'
            }

    type Update'PhasesAddInvoiceItemsPeriod = {
        ///<summary>End of the invoice item period.</summary>
        [<Config.Form>]End: Update'PhasesAddInvoiceItemsPeriodEnd option
        ///<summary>Start of the invoice item period.</summary>
        [<Config.Form>]Start: Update'PhasesAddInvoiceItemsPeriodStart option
    }
    with
        static member New(?end': Update'PhasesAddInvoiceItemsPeriodEnd, ?start: Update'PhasesAddInvoiceItemsPeriodStart) =
            {
                End = end'
                Start = start
            }

    type Update'PhasesAddInvoiceItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'PhasesAddInvoiceItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Update'PhasesAddInvoiceItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge or a negative integer representing the amount to credit to the customer.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?taxBehavior: Update'PhasesAddInvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'PhasesAddInvoiceItems = {
        ///<summary>The coupons to redeem into discounts for the item.</summary>
        [<Config.Form>]Discounts: Update'PhasesAddInvoiceItemsDiscounts list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The period associated with this invoice item. If not set, `period.start.type` defaults to `max_item_period_start` and `period.end.type` defaults to `min_item_period_end`.</summary>
        [<Config.Form>]Period: Update'PhasesAddInvoiceItemsPeriod option
        ///<summary>The ID of the price object. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]PriceData: Update'PhasesAddInvoiceItemsPriceData option
        ///<summary>Quantity for this item. Defaults to 1.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?discounts: Update'PhasesAddInvoiceItemsDiscounts list, ?metadata: Map<string, string>, ?period: Update'PhasesAddInvoiceItemsPeriod, ?price: string, ?priceData: Update'PhasesAddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Discounts = discounts
                Metadata = metadata
                Period = period
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Update'PhasesAutomaticTaxLiabilityType =
    | Account
    | Self

    type Update'PhasesAutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Update'PhasesAutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': Update'PhasesAutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Update'PhasesAutomaticTax = {
        ///<summary>Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: Update'PhasesAutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: Update'PhasesAutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Update'PhasesBillingThresholdsBillingThresholds = {
        ///<summary>Monetary threshold that triggers the subscription to advance to a new billing period</summary>
        [<Config.Form>]AmountGte: int option
        ///<summary>Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.</summary>
        [<Config.Form>]ResetBillingCycleAnchor: bool option
    }
    with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Update'PhasesDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'PhasesDurationInterval =
    | Day
    | Month
    | Week
    | Year

    type Update'PhasesDuration = {
        ///<summary>Specifies phase duration. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Update'PhasesDurationInterval option
        ///<summary>The multiplier applied to the interval.</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Update'PhasesDurationInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Update'PhasesEndDate =
    | Now

    type Update'PhasesInvoiceSettingsIssuerType =
    | Account
    | Self

    type Update'PhasesInvoiceSettingsIssuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Update'PhasesInvoiceSettingsIssuerType option
    }
    with
        static member New(?account: string, ?type': Update'PhasesInvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Update'PhasesInvoiceSettings = {
        ///<summary>The account tax IDs associated with this phase of the subscription schedule. Will be set on invoices generated by this phase of the subscription schedule.</summary>
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///<summary>Number of days within which a customer must pay invoices generated by this subscription schedule. This value will be `null` for subscription schedules where `billing=charge_automatically`.</summary>
        [<Config.Form>]DaysUntilDue: int option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Update'PhasesInvoiceSettingsIssuer option
    }
    with
        static member New(?accountTaxIds: Choice<string list,string>, ?daysUntilDue: int, ?issuer: Update'PhasesInvoiceSettingsIssuer) =
            {
                AccountTaxIds = accountTaxIds
                DaysUntilDue = daysUntilDue
                Issuer = issuer
            }

    type Update'PhasesItemsBillingThresholdsItemBillingThresholds = {
        ///<summary>Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))</summary>
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Update'PhasesItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'PhasesItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Update'PhasesItemsPriceDataRecurring = {
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Update'PhasesItemsPriceDataRecurringInterval option
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Update'PhasesItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Update'PhasesItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'PhasesItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>The recurring components of a price such as `interval` and `interval_count`.</summary>
        [<Config.Form>]Recurring: Update'PhasesItemsPriceDataRecurring option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Update'PhasesItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: Update'PhasesItemsPriceDataRecurring, ?taxBehavior: Update'PhasesItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'PhasesItems = {
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<Update'PhasesItemsBillingThresholdsItemBillingThresholds,string> option
        ///<summary>The coupons to redeem into discounts for the subscription item.</summary>
        [<Config.Form>]Discounts: Choice<Update'PhasesItemsDiscounts list,string> option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to a configuration item. Metadata on a configuration item will update the underlying subscription item's `metadata` when the phase is entered, adding new keys and replacing existing keys. Individual keys in the subscription item's `metadata` can be unset by posting an empty value to them in the configuration item's `metadata`. To unset all keys in the subscription item's `metadata`, update the subscription item directly or unset every key individually from the configuration item's `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The plan ID to subscribe to. You may specify the same ID in `plan` and `price`.</summary>
        [<Config.Form>]Plan: string option
        ///<summary>The ID of the price object.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.</summary>
        [<Config.Form>]PriceData: Update'PhasesItemsPriceData option
        ///<summary>Quantity for the given price. Can be set only if the price's `usage_type` is `licensed` and not `metered`.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?billingThresholds: Choice<Update'PhasesItemsBillingThresholdsItemBillingThresholds,string>, ?discounts: Choice<Update'PhasesItemsDiscounts list,string>, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: Update'PhasesItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Discounts = discounts
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Update'PhasesStartDate =
    | Now

    type Update'PhasesTransferData = {
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.</summary>
        [<Config.Form>]AmountPercent: decimal option
        ///<summary>ID of an existing, connected Stripe account.</summary>
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Update'PhasesTrialEnd =
    | Now

    type Update'PhasesBillingCycleAnchor =
    | Automatic
    | PhaseStart

    type Update'PhasesCollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Update'PhasesProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type Update'Phases = {
        ///<summary>A list of prices and quantities that will generate invoice items appended to the next invoice for this phase. You may pass up to 20 items.</summary>
        [<Config.Form>]AddInvoiceItems: Update'PhasesAddInvoiceItems list option
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).</summary>
        [<Config.Form>]ApplicationFeePercent: decimal option
        ///<summary>Automatic tax settings for this phase.</summary>
        [<Config.Form>]AutomaticTax: Update'PhasesAutomaticTax option
        ///<summary>Can be set to `phase_start` to set the anchor to the start of the phase or `automatic` to automatically change it if needed. Cannot be set to `phase_start` if this phase specifies a trial. For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).</summary>
        [<Config.Form>]BillingCycleAnchor: Update'PhasesBillingCycleAnchor option
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<Update'PhasesBillingThresholdsBillingThresholds,string> option
        ///<summary>Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay the underlying subscription at the end of each billing cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically` on creation.</summary>
        [<Config.Form>]CollectionMethod: Update'PhasesCollectionMethod option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>ID of the default payment method for the subscription schedule. It must belong to the customer associated with the subscription schedule. If not set, invoices will use the default payment method in the customer's invoice settings.</summary>
        [<Config.Form>]DefaultPaymentMethod: string option
        ///<summary>A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will set the Subscription's [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates), which means they will be the Invoice's [`default_tax_rates`](https://docs.stripe.com/api/invoices/create#create_invoice-default_tax_rates) for any Invoices issued by the Subscription during this Phase.</summary>
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///<summary>Subscription description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.</summary>
        [<Config.Form>]Description: Choice<string,string> option
        ///<summary>The coupons to redeem into discounts for the schedule phase. If not specified, inherits the discount from the subscription's customer. Pass an empty string to avoid inheriting any discounts.</summary>
        [<Config.Form>]Discounts: Choice<Update'PhasesDiscounts list,string> option
        ///<summary>The number of intervals the phase should last. If set, `end_date` must not be set.</summary>
        [<Config.Form>]Duration: Update'PhasesDuration option
        ///<summary>The date at which this phase of the subscription schedule ends. If set, `duration` must not be set.</summary>
        [<Config.Form>]EndDate: Choice<DateTime,Update'PhasesEndDate> option
        ///<summary>All invoices will be billed using the specified settings.</summary>
        [<Config.Form>]InvoiceSettings: Update'PhasesInvoiceSettings option
        ///<summary>List of configuration items, each with an attached price, to apply during this phase of the subscription schedule.</summary>
        [<Config.Form>]Items: Update'PhasesItems list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to a phase. Metadata on a schedule's phase will update the underlying subscription's `metadata` when the phase is entered, adding new keys and replacing existing keys in the subscription's `metadata`. Individual keys in the subscription's `metadata` can be unset by posting an empty value to them in the phase's `metadata`. To unset all keys in the subscription's `metadata`, update the subscription directly or unset every key individually from the phase's `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The account on behalf of which to charge, for each of the associated subscription's invoices.</summary>
        [<Config.Form>]OnBehalfOf: string option
        ///<summary>Controls whether the subscription schedule should create [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when transitioning to this phase if there is a difference in billing configuration. It's different from the request-level [proration_behavior](https://docs.stripe.com/api/subscription_schedules/update#update_subscription_schedule-proration_behavior) parameter which controls what happens if the update request affects the billing configuration (item price, quantity, etc.) of the current phase.</summary>
        [<Config.Form>]ProrationBehavior: Update'PhasesProrationBehavior option
        ///<summary>The date at which this phase of the subscription schedule starts or `now`. Must be set on the first phase.</summary>
        [<Config.Form>]StartDate: Choice<DateTime,Update'PhasesStartDate> option
        ///<summary>The data with which to automatically create a Transfer for each of the associated subscription's invoices.</summary>
        [<Config.Form>]TransferData: Update'PhasesTransferData option
        ///<summary>If set to true the entire phase is counted as a trial and the customer will not be charged for any fees.</summary>
        [<Config.Form>]Trial: bool option
        ///<summary>Sets the phase to trialing from the start date to this date. Must be before the phase end date, can not be combined with `trial`</summary>
        [<Config.Form>]TrialEnd: Choice<DateTime,Update'PhasesTrialEnd> option
    }
    with
        static member New(?addInvoiceItems: Update'PhasesAddInvoiceItems list, ?transferData: Update'PhasesTransferData, ?startDate: Choice<DateTime,Update'PhasesStartDate>, ?prorationBehavior: Update'PhasesProrationBehavior, ?onBehalfOf: string, ?metadata: Map<string, string>, ?items: Update'PhasesItems list, ?invoiceSettings: Update'PhasesInvoiceSettings, ?endDate: Choice<DateTime,Update'PhasesEndDate>, ?duration: Update'PhasesDuration, ?discounts: Choice<Update'PhasesDiscounts list,string>, ?description: Choice<string,string>, ?defaultTaxRates: Choice<string list,string>, ?defaultPaymentMethod: string, ?currency: IsoTypes.IsoCurrencyCode, ?collectionMethod: Update'PhasesCollectionMethod, ?billingThresholds: Choice<Update'PhasesBillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: Update'PhasesBillingCycleAnchor, ?automaticTax: Update'PhasesAutomaticTax, ?applicationFeePercent: decimal, ?trial: bool, ?trialEnd: Choice<DateTime,Update'PhasesTrialEnd>) =
            {
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CollectionMethod = collectionMethod
                Currency = currency
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                Duration = duration
                EndDate = endDate
                InvoiceSettings = invoiceSettings
                Items = items
                Metadata = metadata
                OnBehalfOf = onBehalfOf
                ProrationBehavior = prorationBehavior
                StartDate = startDate
                TransferData = transferData
                Trial = trial
                TrialEnd = trialEnd
            }

    type Update'EndBehavior =
    | Cancel
    | None'
    | Release
    | Renew

    type Update'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type UpdateOptions = {
        [<Config.Path>]Schedule: string
        ///<summary>Object representing the subscription schedule's default settings.</summary>
        [<Config.Form>]DefaultSettings: Update'DefaultSettings option
        ///<summary>Behavior of the subscription schedule and underlying subscription when it ends. Possible values are `release` or `cancel` with the default being `release`. `release` will end the subscription schedule and keep the underlying subscription running. `cancel` will end the subscription schedule and cancel the underlying subscription.</summary>
        [<Config.Form>]EndBehavior: Update'EndBehavior option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>List representing phases of the subscription schedule. Each phase can be customized to have different durations, plans, and coupons. If there are multiple phases, the `end_date` of one phase will always equal the `start_date` of the next phase. Note that past phases can be omitted.</summary>
        [<Config.Form>]Phases: Update'Phases list option
        ///<summary>If the update changes the billing configuration (item price, quantity, etc.) of the current phase, indicates how prorations from this change should be handled. The default value is `create_prorations`.</summary>
        [<Config.Form>]ProrationBehavior: Update'ProrationBehavior option
    }
    with
        static member New(schedule: string, ?defaultSettings: Update'DefaultSettings, ?endBehavior: Update'EndBehavior, ?expand: string list, ?metadata: Map<string, string>, ?phases: Update'Phases list, ?prorationBehavior: Update'ProrationBehavior) =
            {
                Schedule = schedule
                DefaultSettings = defaultSettings
                EndBehavior = endBehavior
                Expand = expand
                Metadata = metadata
                Phases = phases
                ProrationBehavior = prorationBehavior
            }

    ///<summary><p>Updates an existing subscription schedule.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/subscription_schedules/{options.Schedule}"
        |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) options

module SubscriptionSchedulesCancel =

    type CancelOptions = {
        [<Config.Path>]Schedule: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>If the subscription schedule is `active`, indicates if a final invoice will be generated that contains any un-invoiced metered usage and new/pending proration invoice items. Defaults to `true`.</summary>
        [<Config.Form>]InvoiceNow: bool option
        ///<summary>If the subscription schedule is `active`, indicates if the cancellation should be prorated. Defaults to `true`.</summary>
        [<Config.Form>]Prorate: bool option
    }
    with
        static member New(schedule: string, ?expand: string list, ?invoiceNow: bool, ?prorate: bool) =
            {
                Schedule = schedule
                Expand = expand
                InvoiceNow = invoiceNow
                Prorate = prorate
            }

    ///<summary><p>Cancels a subscription schedule and its associated subscription immediately (if the subscription schedule has an active subscription). A subscription schedule can only be canceled if its status is <code>not_started</code> or <code>active</code>.</p></summary>
    let Cancel settings (options: CancelOptions) =
        $"/v1/subscription_schedules/{options.Schedule}/cancel"
        |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) options

module SubscriptionSchedulesRelease =

    type ReleaseOptions = {
        [<Config.Path>]Schedule: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Keep any cancellation on the subscription that the schedule has set</summary>
        [<Config.Form>]PreserveCancelDate: bool option
    }
    with
        static member New(schedule: string, ?expand: string list, ?preserveCancelDate: bool) =
            {
                Schedule = schedule
                Expand = expand
                PreserveCancelDate = preserveCancelDate
            }

    ///<summary><p>Releases the subscription schedule immediately, which will stop scheduling of its phases, but leave any existing subscription in place. A schedule can only be released if its status is <code>not_started</code> or <code>active</code>. If the subscription schedule is currently associated with a subscription, releasing it will remove its <code>subscription</code> property and set the subscription’s ID to the <code>released_subscription</code> property.</p></summary>
    let Release settings (options: ReleaseOptions) =
        $"/v1/subscription_schedules/{options.Schedule}/release"
        |> RestApi.postAsync<_, SubscriptionSchedule> settings (Map.empty) options

module Subscriptions =

    type ListOptions = {
        ///<summary>Filter subscriptions by their automatic tax settings.</summary>
        [<Config.Query>]AutomaticTax: Map<string, string> option
        ///<summary>The collection method of the subscriptions to retrieve. Either `charge_automatically` or `send_invoice`.</summary>
        [<Config.Query>]CollectionMethod: string option
        ///<summary>Only return subscriptions that were created during the given date interval.</summary>
        [<Config.Query>]Created: int option
        ///<summary>Only return subscriptions whose minimum item current_period_end falls within the given date interval.</summary>
        [<Config.Query>]CurrentPeriodEnd: int option
        ///<summary>Only return subscriptions whose maximum item current_period_start falls within the given date interval.</summary>
        [<Config.Query>]CurrentPeriodStart: int option
        ///<summary>The ID of the customer whose subscriptions you're retrieving.</summary>
        [<Config.Query>]Customer: string option
        ///<summary>The ID of the account representing the customer whose subscriptions you're retrieving.</summary>
        [<Config.Query>]CustomerAccount: string option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>The ID of the plan whose subscriptions will be retrieved.</summary>
        [<Config.Query>]Plan: string option
        ///<summary>Filter for subscriptions that contain this recurring price ID.</summary>
        [<Config.Query>]Price: string option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>The status of the subscriptions to retrieve. Passing in a value of `canceled` will return all canceled subscriptions, including those belonging to deleted customers. Pass `ended` to find subscriptions that are canceled and subscriptions that are expired due to [incomplete payment](https://docs.stripe.com/billing/subscriptions/overview#subscription-statuses). Passing in a value of `all` will return subscriptions of all statuses. If no value is supplied, all subscriptions that have not been canceled are returned.</summary>
        [<Config.Query>]Status: string option
        ///<summary>Filter for subscriptions that are associated with the specified test clock. The response will not include subscriptions with test clocks if this and the customer parameter is not set.</summary>
        [<Config.Query>]TestClock: string option
    }
    with
        static member New(?automaticTax: Map<string, string>, ?collectionMethod: string, ?created: int, ?currentPeriodEnd: int, ?currentPeriodStart: int, ?customer: string, ?customerAccount: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?plan: string, ?price: string, ?startingAfter: string, ?status: string, ?testClock: string) =
            {
                AutomaticTax = automaticTax
                CollectionMethod = collectionMethod
                Created = created
                CurrentPeriodEnd = currentPeriodEnd
                CurrentPeriodStart = currentPeriodStart
                Customer = customer
                CustomerAccount = customerAccount
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Plan = plan
                Price = price
                StartingAfter = startingAfter
                Status = status
                TestClock = testClock
            }

    ///<summary><p>By default, returns a list of subscriptions that have not been canceled. In order to list canceled subscriptions, specify <code>status=canceled</code>.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("automatic_tax", options.AutomaticTax |> box); ("collection_method", options.CollectionMethod |> box); ("created", options.Created |> box); ("current_period_end", options.CurrentPeriodEnd |> box); ("current_period_start", options.CurrentPeriodStart |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("plan", options.Plan |> box); ("price", options.Price |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box); ("test_clock", options.TestClock |> box)] |> Map.ofList
        $"/v1/subscriptions"
        |> RestApi.getAsync<StripeList<Subscription>> settings qs

    type Create'AddInvoiceItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Create'AddInvoiceItemsPeriodEndType =
    | MinItemPeriodEnd
    | Timestamp

    type Create'AddInvoiceItemsPeriodEnd = {
        ///<summary>A precise Unix timestamp for the end of the invoice item period. Must be greater than or equal to `period.start`.</summary>
        [<Config.Form>]Timestamp: DateTime option
        ///<summary>Select how to calculate the end of the invoice item period.</summary>
        [<Config.Form>]Type: Create'AddInvoiceItemsPeriodEndType option
    }
    with
        static member New(?timestamp: DateTime, ?type': Create'AddInvoiceItemsPeriodEndType) =
            {
                Timestamp = timestamp
                Type = type'
            }

    type Create'AddInvoiceItemsPeriodStartType =
    | MaxItemPeriodStart
    | Now
    | Timestamp

    type Create'AddInvoiceItemsPeriodStart = {
        ///<summary>A precise Unix timestamp for the start of the invoice item period. Must be less than or equal to `period.end`.</summary>
        [<Config.Form>]Timestamp: DateTime option
        ///<summary>Select how to calculate the start of the invoice item period.</summary>
        [<Config.Form>]Type: Create'AddInvoiceItemsPeriodStartType option
    }
    with
        static member New(?timestamp: DateTime, ?type': Create'AddInvoiceItemsPeriodStartType) =
            {
                Timestamp = timestamp
                Type = type'
            }

    type Create'AddInvoiceItemsPeriod = {
        ///<summary>End of the invoice item period.</summary>
        [<Config.Form>]End: Create'AddInvoiceItemsPeriodEnd option
        ///<summary>Start of the invoice item period.</summary>
        [<Config.Form>]Start: Create'AddInvoiceItemsPeriodStart option
    }
    with
        static member New(?end': Create'AddInvoiceItemsPeriodEnd, ?start: Create'AddInvoiceItemsPeriodStart) =
            {
                End = end'
                Start = start
            }

    type Create'AddInvoiceItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'AddInvoiceItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Create'AddInvoiceItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge or a negative integer representing the amount to credit to the customer.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?taxBehavior: Create'AddInvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'AddInvoiceItems = {
        ///<summary>The coupons to redeem into discounts for the item.</summary>
        [<Config.Form>]Discounts: Create'AddInvoiceItemsDiscounts list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The period associated with this invoice item. If not set, `period.start.type` defaults to `max_item_period_start` and `period.end.type` defaults to `min_item_period_end`.</summary>
        [<Config.Form>]Period: Create'AddInvoiceItemsPeriod option
        ///<summary>The ID of the price object. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]PriceData: Create'AddInvoiceItemsPriceData option
        ///<summary>Quantity for this item. Defaults to 1.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?discounts: Create'AddInvoiceItemsDiscounts list, ?metadata: Map<string, string>, ?period: Create'AddInvoiceItemsPeriod, ?price: string, ?priceData: Create'AddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Discounts = discounts
                Metadata = metadata
                Period = period
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Create'AutomaticTaxLiabilityType =
    | Account
    | Self

    type Create'AutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Create'AutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': Create'AutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Create'AutomaticTax = {
        ///<summary>Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: Create'AutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: Create'AutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Create'BillingCycleAnchorConfig = {
        ///<summary>The day of the month the anchor should be. Ranges from 1 to 31.</summary>
        [<Config.Form>]DayOfMonth: int option
        ///<summary>The hour of the day the anchor should be. Ranges from 0 to 23.</summary>
        [<Config.Form>]Hour: int option
        ///<summary>The minute of the hour the anchor should be. Ranges from 0 to 59.</summary>
        [<Config.Form>]Minute: int option
        ///<summary>The month to start full cycle periods. Ranges from 1 to 12.</summary>
        [<Config.Form>]Month: int option
        ///<summary>The second of the minute the anchor should be. Ranges from 0 to 59.</summary>
        [<Config.Form>]Second: int option
    }
    with
        static member New(?dayOfMonth: int, ?hour: int, ?minute: int, ?month: int, ?second: int) =
            {
                DayOfMonth = dayOfMonth
                Hour = hour
                Minute = minute
                Month = month
                Second = second
            }

    type Create'BillingModeFlexibleProrationDiscounts =
    | Included
    | Itemized

    type Create'BillingModeFlexible = {
        ///<summary>Controls how invoices and invoice items display proration amounts and discount amounts.</summary>
        [<Config.Form>]ProrationDiscounts: Create'BillingModeFlexibleProrationDiscounts option
    }
    with
        static member New(?prorationDiscounts: Create'BillingModeFlexibleProrationDiscounts) =
            {
                ProrationDiscounts = prorationDiscounts
            }

    type Create'BillingModeType =
    | Classic
    | Flexible

    type Create'BillingMode = {
        ///<summary>Configure behavior for flexible billing mode.</summary>
        [<Config.Form>]Flexible: Create'BillingModeFlexible option
        ///<summary>Controls the calculation and orchestration of prorations and invoices for subscriptions. If no value is passed, the default is `flexible`.</summary>
        [<Config.Form>]Type: Create'BillingModeType option
    }
    with
        static member New(?flexible: Create'BillingModeFlexible, ?type': Create'BillingModeType) =
            {
                Flexible = flexible
                Type = type'
            }

    type Create'BillingThresholdsBillingThresholds = {
        ///<summary>Monetary threshold that triggers the subscription to advance to a new billing period</summary>
        [<Config.Form>]AmountGte: int option
        ///<summary>Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.</summary>
        [<Config.Form>]ResetBillingCycleAnchor: bool option
    }
    with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Create'CancelAt =
    | MaxPeriodEnd
    | MinPeriodEnd

    type Create'Discounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Create'InvoiceSettingsIssuerType =
    | Account
    | Self

    type Create'InvoiceSettingsIssuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Create'InvoiceSettingsIssuerType option
    }
    with
        static member New(?account: string, ?type': Create'InvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Create'InvoiceSettings = {
        ///<summary>The account tax IDs associated with the subscription. Will be set on invoices generated by the subscription.</summary>
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Create'InvoiceSettingsIssuer option
    }
    with
        static member New(?accountTaxIds: Choice<string list,string>, ?issuer: Create'InvoiceSettingsIssuer) =
            {
                AccountTaxIds = accountTaxIds
                Issuer = issuer
            }

    type Create'ItemsBillingThresholdsItemBillingThresholds = {
        ///<summary>Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))</summary>
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Create'ItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Create'ItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'ItemsPriceDataRecurring = {
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Create'ItemsPriceDataRecurringInterval option
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'ItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'ItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Create'ItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>The recurring components of a price such as `interval` and `interval_count`.</summary>
        [<Config.Form>]Recurring: Create'ItemsPriceDataRecurring option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Create'ItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: Create'ItemsPriceDataRecurring, ?taxBehavior: Create'ItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Create'Items = {
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<Create'ItemsBillingThresholdsItemBillingThresholds,string> option
        ///<summary>The coupons to redeem into discounts for the subscription item.</summary>
        [<Config.Form>]Discounts: Choice<Create'ItemsDiscounts list,string> option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Plan ID for this item, as a string.</summary>
        [<Config.Form>]Plan: string option
        ///<summary>The ID of the price object.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline.</summary>
        [<Config.Form>]PriceData: Create'ItemsPriceData option
        ///<summary>Quantity for this item.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?billingThresholds: Choice<Create'ItemsBillingThresholdsItemBillingThresholds,string>, ?discounts: Choice<Create'ItemsDiscounts list,string>, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: Create'ItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                Discounts = discounts
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType =
    | Business
    | Personal

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions = {
        ///<summary>Transaction type of the mandate.</summary>
        [<Config.Form>]TransactionType: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
    }
    with
        static member New(?transactionType: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType) =
            {
                TransactionType = transactionType
            }

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions = {
        ///<summary>Additional fields for Mandate creation</summary>
        [<Config.Form>]MandateOptions: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option
        ///<summary>Verification method for the intent</summary>
        [<Config.Form>]VerificationMethod: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions, ?verificationMethod: Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod) =
            {
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Fr
    | Nl

    type Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions = {
        ///<summary>Preferred language of the Bancontact authorization page that the customer is redirected to.</summary>
        [<Config.Form>]PreferredLanguage: Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
    }
    with
        static member New(?preferredLanguage: Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions = {
        ///<summary>Amount to be charged for future payments, specified in the presentment currency.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.</summary>
        [<Config.Form>]AmountType: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType option
        ///<summary>A description of the mandate or subscription that is meant to be displayed to the customer.</summary>
        [<Config.Form>]Description: string option
    }
    with
        static member New(?amount: int, ?amountType: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType, ?description: string) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
            }

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork =
    | Amex
    | CartesBancaires
    | Diners
    | Discover
    | EftposAu
    | Girocard
    | Interac
    | Jcb
    | Link
    | Mastercard
    | Unionpay
    | Unknown
    | Visa

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure =
    | Any
    | Automatic
    | Challenge

    type Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions = {
        ///<summary>Configuration options for setting up an eMandate for cards issued in India.</summary>
        [<Config.Form>]MandateOptions: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions option
        ///<summary>Selected network to process this Subscription on. Depends on the available networks of the card attached to the Subscription. Can be only set confirm-time.</summary>
        [<Config.Form>]Network: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork option
        ///<summary>We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.</summary>
        [<Config.Form>]RequestThreeDSecure: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure option
    }
    with
        static member New(?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions, ?network: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork, ?requestThreeDSecure: Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure) =
            {
                MandateOptions = mandateOptions
                Network = network
                RequestThreeDSecure = requestThreeDSecure
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer = {
        ///<summary>The desired country code of the bank account information. Permitted values include: `DE`, `FR`, `IE`, or `NL`.</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
    }
    with
        static member New(?country: IsoTypes.IsoCountryCode) =
            {
                Country = country
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer = {
        ///<summary>Configuration for eu_bank_transfer funding type.</summary>
        [<Config.Form>]EuBankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option
        ///<summary>The bank transfer type that can be used for funding. Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.</summary>
        [<Config.Form>]Type: string option
    }
    with
        static member New(?euBankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer, ?type': string) =
            {
                EuBankTransfer = euBankTransfer
                Type = type'
            }

    type Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions = {
        ///<summary>Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.</summary>
        [<Config.Form>]BankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option
        ///<summary>The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.</summary>
        [<Config.Form>]FundingType: string option
    }
    with
        static member New(?bankTransfer: Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer, ?fundingType: string) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
            }

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose =
    | DependantSupport
    | Government
    | Loan
    | Mortgage
    | Other
    | Pension
    | Personal
    | Retail
    | Salary
    | Tax
    | Utility

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions = {
        ///<summary>The maximum amount that can be collected in a single invoice. If you don't specify a maximum, then there is no limit.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>The purpose for which payments are made. Has a default value based on your merchant category code.</summary>
        [<Config.Form>]Purpose: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose option
    }
    with
        static member New(?amount: int, ?purpose: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose) =
            {
                Amount = amount
                Purpose = purpose
            }

    type Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions = {
        ///<summary>Additional fields for Mandate creation.</summary>
        [<Config.Form>]MandateOptions: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions option
    }
    with
        static member New(?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsAmountIncludesIof =
    | Always
    | Never

    type Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsPaymentSchedule =
    | Halfyearly
    | Monthly
    | Quarterly
    | Weekly
    | Yearly

    type Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions = {
        ///<summary>Amount to be charged for future payments. If not provided, defaults to 40000.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Determines if the amount includes the IOF tax. Defaults to `never`.</summary>
        [<Config.Form>]AmountIncludesIof: Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsAmountIncludesIof option
        ///<summary>Date when the mandate expires and no further payments will be charged, in `YYYY-MM-DD`. If not provided, the mandate will be active until canceled.</summary>
        [<Config.Form>]EndDate: string option
        ///<summary>Schedule at which the future payments will be charged. Defaults to the subscription servicing interval.</summary>
        [<Config.Form>]PaymentSchedule: Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsPaymentSchedule option
    }
    with
        static member New(?amount: int, ?amountIncludesIof: Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsAmountIncludesIof, ?endDate: string, ?paymentSchedule: Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsPaymentSchedule) =
            {
                Amount = amount
                AmountIncludesIof = amountIncludesIof
                EndDate = endDate
                PaymentSchedule = paymentSchedule
            }

    type Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions = {
        ///<summary>The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.</summary>
        [<Config.Form>]ExpiresAfterSeconds: int option
        ///<summary>Configuration options for setting up a mandate</summary>
        [<Config.Form>]MandateOptions: Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions option
    }
    with
        static member New(?expiresAfterSeconds: int, ?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions) =
            {
                ExpiresAfterSeconds = expiresAfterSeconds
                MandateOptions = mandateOptions
            }

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions = {
        ///<summary>Amount to be charged for future payments.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.</summary>
        [<Config.Form>]AmountType: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType option
        ///<summary>A description of the mandate or subscription that is meant to be displayed to the customer.</summary>
        [<Config.Form>]Description: string option
        ///<summary>End date of the mandate or subscription.</summary>
        [<Config.Form>]EndDate: DateTime option
    }
    with
        static member New(?amount: int, ?amountType: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions = {
        ///<summary>Configuration options for setting up an eMandate</summary>
        [<Config.Form>]MandateOptions: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions option
    }
    with
        static member New(?mandateOptions: Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories =
    | Checking
    | Savings

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters = {
        ///<summary>The account subcategories to use to filter for selectable accounts. Valid subcategories are `checking` and `savings`.</summary>
        [<Config.Form>]AccountSubcategories: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list option
    }
    with
        static member New(?accountSubcategories: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list) =
            {
                AccountSubcategories = accountSubcategories
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch =
    | Balances
    | Ownership
    | Transactions

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections = {
        ///<summary>Provide filters for the linked accounts that the customer can select for the payment method.</summary>
        [<Config.Form>]Filters: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters option
        ///<summary>The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.</summary>
        [<Config.Form>]Permissions: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option
        ///<summary>List of data features that you would like to retrieve upon account creation.</summary>
        [<Config.Form>]Prefetch: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
    }
    with
        static member New(?filters: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters, ?permissions: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list, ?prefetch: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list) =
            {
                Filters = filters
                Permissions = permissions
                Prefetch = prefetch
            }

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions = {
        ///<summary>Additional fields for Financial Connections Session creation</summary>
        [<Config.Form>]FinancialConnections: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option
        ///<summary>Verification method for the intent</summary>
        [<Config.Form>]VerificationMethod: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?financialConnections: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections, ?verificationMethod: Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod) =
            {
                FinancialConnections = financialConnections
                VerificationMethod = verificationMethod
            }

    type Create'PaymentSettingsPaymentMethodOptions = {
        ///<summary>This sub-hash contains details about the Canadian pre-authorized debit payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]AcssDebit: Choice<Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the Bancontact payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Bancontact: Choice<Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the Card payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Card: Choice<Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the Bank transfer payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]CustomerBalance: Choice<Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the Konbini payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Konbini: Choice<string,string> option
        ///<summary>This sub-hash contains details about the PayTo payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Payto: Choice<Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the Pix payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Pix: Choice<Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the SEPA Direct Debit payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]SepaDebit: Choice<string,string> option
        ///<summary>This sub-hash contains details about the UPI payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Upi: Choice<Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the ACH direct debit payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]UsBankAccount: Choice<Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
    }
    with
        static member New(?acssDebit: Choice<Create'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string>, ?bancontact: Choice<Create'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string>, ?card: Choice<Create'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions,string>, ?customerBalance: Choice<Create'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string>, ?konbini: Choice<string,string>, ?payto: Choice<Create'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string>, ?pix: Choice<Create'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions,string>, ?sepaDebit: Choice<string,string>, ?upi: Choice<Create'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string>, ?usBankAccount: Choice<Create'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string>) =
            {
                AcssDebit = acssDebit
                Bancontact = bancontact
                Card = card
                CustomerBalance = customerBalance
                Konbini = konbini
                Payto = payto
                Pix = pix
                SepaDebit = sepaDebit
                Upi = upi
                UsBankAccount = usBankAccount
            }

    type Create'PaymentSettingsPaymentMethodTypes =
    | AchCreditTransfer
    | AchDebit
    | AcssDebit
    | Affirm
    | AmazonPay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Boleto
    | Card
    | Cashapp
    | Crypto
    | Custom
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | JpCreditTransfer
    | KakaoPay
    | Klarna
    | Konbini
    | KrCard
    | Link
    | Multibanco
    | NaverPay
    | NzBankAccount
    | P24
    | PayByBank
    | Payco
    | Paynow
    | Paypal
    | Payto
    | Pix
    | Promptpay
    | RevolutPay
    | SepaCreditTransfer
    | SepaDebit
    | Sofort
    | Swish
    | Upi
    | UsBankAccount
    | WechatPay

    type Create'PaymentSettingsSaveDefaultPaymentMethod =
    | Off
    | OnSubscription

    type Create'PaymentSettings = {
        ///<summary>Payment-method-specific configuration to provide to invoices created by the subscription.</summary>
        [<Config.Form>]PaymentMethodOptions: Create'PaymentSettingsPaymentMethodOptions option
        ///<summary>The list of payment method types (e.g. card) to provide to the invoice’s PaymentIntent. If not set, Stripe attempts to automatically determine the types to use by looking at the invoice’s default payment method, the subscription’s default payment method, the customer’s default payment method, and your [invoice template settings](https://dashboard.stripe.com/settings/billing/invoice). Should not be specified with payment_method_configuration</summary>
        [<Config.Form>]PaymentMethodTypes: Choice<Create'PaymentSettingsPaymentMethodTypes list,string> option
        ///<summary>Configure whether Stripe updates `subscription.default_payment_method` when payment succeeds. Defaults to `off` if unspecified.</summary>
        [<Config.Form>]SaveDefaultPaymentMethod: Create'PaymentSettingsSaveDefaultPaymentMethod option
    }
    with
        static member New(?paymentMethodOptions: Create'PaymentSettingsPaymentMethodOptions, ?paymentMethodTypes: Choice<Create'PaymentSettingsPaymentMethodTypes list,string>, ?saveDefaultPaymentMethod: Create'PaymentSettingsSaveDefaultPaymentMethod) =
            {
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
                SaveDefaultPaymentMethod = saveDefaultPaymentMethod
            }

    type Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval =
    | Day
    | Month
    | Week
    | Year

    type Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams = {
        ///<summary>Specifies invoicing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval option
        ///<summary>The number of intervals between invoices. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Create'TransferData = {
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.</summary>
        [<Config.Form>]AmountPercent: decimal option
        ///<summary>ID of an existing, connected Stripe account.</summary>
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Create'TrialEnd =
    | Now

    type Create'TrialSettingsEndBehaviorMissingPaymentMethod =
    | Cancel
    | CreateInvoice
    | Pause

    type Create'TrialSettingsEndBehavior = {
        ///<summary>Indicates how the subscription should change when the trial ends if the user did not provide a payment method.</summary>
        [<Config.Form>]MissingPaymentMethod: Create'TrialSettingsEndBehaviorMissingPaymentMethod option
    }
    with
        static member New(?missingPaymentMethod: Create'TrialSettingsEndBehaviorMissingPaymentMethod) =
            {
                MissingPaymentMethod = missingPaymentMethod
            }

    type Create'TrialSettings = {
        ///<summary>Defines how the subscription should behave when the user's free trial ends.</summary>
        [<Config.Form>]EndBehavior: Create'TrialSettingsEndBehavior option
    }
    with
        static member New(?endBehavior: Create'TrialSettingsEndBehavior) =
            {
                EndBehavior = endBehavior
            }

    type Create'CollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Create'PaymentBehavior =
    | AllowIncomplete
    | DefaultIncomplete
    | ErrorIfIncomplete
    | PendingIfIncomplete

    type Create'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type CreateOptions = {
        ///<summary>A list of prices and quantities that will generate invoice items appended to the next invoice for this subscription. You may pass up to 20 items.</summary>
        [<Config.Form>]AddInvoiceItems: Create'AddInvoiceItems list option
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).</summary>
        [<Config.Form>]ApplicationFeePercent: Choice<decimal,string> option
        ///<summary>Automatic tax settings for this subscription.</summary>
        [<Config.Form>]AutomaticTax: Create'AutomaticTax option
        ///<summary>A past timestamp to backdate the subscription's start date to. If set, the first invoice will contain line items for the timespan between the start date and the current time. Can be combined with trials and the billing cycle anchor.</summary>
        [<Config.Form>]BackdateStartDate: DateTime option
        ///<summary>A future timestamp in UTC format to anchor the subscription's [billing cycle](https://docs.stripe.com/subscriptions/billing-cycle). The anchor is the reference point that aligns future billing cycle dates. It sets the day of week for `week` intervals, the day of month for `month` and `year` intervals, and the month of year for `year` intervals.</summary>
        [<Config.Form>]BillingCycleAnchor: DateTime option
        ///<summary>Mutually exclusive with billing_cycle_anchor and only valid with monthly and yearly price intervals. When provided, the billing_cycle_anchor is set to the next occurrence of the day_of_month at the hour, minute, and second UTC.</summary>
        [<Config.Form>]BillingCycleAnchorConfig: Create'BillingCycleAnchorConfig option
        ///<summary>Controls how prorations and invoices for subscriptions are calculated and orchestrated.</summary>
        [<Config.Form>]BillingMode: Create'BillingMode option
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<Create'BillingThresholdsBillingThresholds,string> option
        ///<summary>A timestamp at which the subscription should cancel. If set to a date before the current period ends, this will cause a proration if prorations have been enabled using `proration_behavior`. If set during a future period, this will always cause a proration for that period.</summary>
        [<Config.Form>]CancelAt: Choice<DateTime,Create'CancelAt> option
        ///<summary>Indicate whether this subscription should cancel at the end of the current period (`current_period_end`). Defaults to `false`.</summary>
        [<Config.Form>]CancelAtPeriodEnd: bool option
        ///<summary>Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this subscription at the end of the cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically`.</summary>
        [<Config.Form>]CollectionMethod: Create'CollectionMethod option
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The identifier of the customer to subscribe.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>The identifier of the account representing the customer to subscribe.</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>Number of days a customer has to pay invoices generated by this subscription. Valid only for subscriptions where `collection_method` is set to `send_invoice`.</summary>
        [<Config.Form>]DaysUntilDue: int option
        ///<summary>ID of the default payment method for the subscription. It must belong to the customer associated with the subscription. This takes precedence over `default_source`. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://docs.stripe.com/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://docs.stripe.com/api/customers/object#customer_object-default_source).</summary>
        [<Config.Form>]DefaultPaymentMethod: string option
        ///<summary>ID of the default payment source for the subscription. It must belong to the customer associated with the subscription and be in a chargeable state. If `default_payment_method` is also set, `default_payment_method` will take precedence. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://docs.stripe.com/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://docs.stripe.com/api/customers/object#customer_object-default_source).</summary>
        [<Config.Form>]DefaultSource: string option
        ///<summary>The tax rates that will apply to any subscription item that does not have `tax_rates` set. Invoices created will have their `default_tax_rates` populated from the subscription.</summary>
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///<summary>The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.</summary>
        [<Config.Form>]Description: string option
        ///<summary>The coupons to redeem into discounts for the subscription. If not specified or empty, inherits the discount from the subscription's customer.</summary>
        [<Config.Form>]Discounts: Choice<Create'Discounts list,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>All invoices will be billed using the specified settings.</summary>
        [<Config.Form>]InvoiceSettings: Create'InvoiceSettings option
        ///<summary>A list of up to 20 subscription items, each with an attached price.</summary>
        [<Config.Form>]Items: Create'Items list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Indicates if a customer is on or off-session while an invoice payment is attempted. Defaults to `false` (on-session).</summary>
        [<Config.Form>]OffSession: bool option
        ///<summary>The account on behalf of which to charge, for each of the subscription's invoices.</summary>
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///<summary>Only applies to subscriptions with `collection_method=charge_automatically`.
        ///Use `allow_incomplete` to create Subscriptions with `status=incomplete` if the first invoice can't be paid. Creating Subscriptions with this status allows you to manage scenarios where additional customer actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://docs.stripe.com/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
        ///Use `default_incomplete` to create Subscriptions with `status=incomplete` when the first invoice requires payment, otherwise start as active. Subscriptions transition to `status=active` when successfully confirming the PaymentIntent on the first invoice. This allows simpler management of scenarios where additional customer actions are needed to pay a subscription’s invoice, such as failed payments, [SCA regulation](https://docs.stripe.com/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method. If the PaymentIntent is not confirmed within 23 hours Subscriptions transition to `status=incomplete_expired`, which is a terminal state.
        ///Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's first invoice can't be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further customer action is needed, this parameter doesn't create a Subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://docs.stripe.com/upgrades#2019-03-14) to learn more.
        ///`pending_if_incomplete` is only used with updates and cannot be passed when creating a Subscription.
        ///Subscriptions with `collection_method=send_invoice` are automatically activated regardless of the first Invoice status.</summary>
        [<Config.Form>]PaymentBehavior: Create'PaymentBehavior option
        ///<summary>Payment settings to pass to invoices created by the subscription.</summary>
        [<Config.Form>]PaymentSettings: Create'PaymentSettings option
        ///<summary>Specifies an interval for how often to bill for any pending invoice items. It is analogous to calling [Create an invoice](/api/invoices/create) for the given subscription at the specified interval.</summary>
        [<Config.Form>]PendingInvoiceItemInterval: Choice<Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string> option
        ///<summary>Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) resulting from the `billing_cycle_anchor`. If no value is passed, the default is `create_prorations`.</summary>
        [<Config.Form>]ProrationBehavior: Create'ProrationBehavior option
        ///<summary>If specified, the funds from the subscription's invoices will be transferred to the destination and the ID of the resulting transfers will be found on the resulting charges.</summary>
        [<Config.Form>]TransferData: Create'TransferData option
        ///<summary>Unix timestamp representing the end of the trial period the customer will get before being charged for the first time. If set, trial_end will override the default trial period of the plan the customer is being subscribed to. The special value `now` can be provided to end the customer's trial immediately. Can be at most two years from `billing_cycle_anchor`. See [Using trial periods on subscriptions](https://docs.stripe.com/billing/subscriptions/trials) to learn more.</summary>
        [<Config.Form>]TrialEnd: Choice<Create'TrialEnd,DateTime> option
        ///<summary>Indicates if a plan's `trial_period_days` should be applied to the subscription. Setting `trial_end` per subscription is preferred, and this defaults to `false`. Setting this flag to `true` together with `trial_end` is not allowed. See [Using trial periods on subscriptions](https://docs.stripe.com/billing/subscriptions/trials) to learn more.</summary>
        [<Config.Form>]TrialFromPlan: bool option
        ///<summary>Integer representing the number of trial period days before the customer is charged for the first time. This will always overwrite any trials that might apply via a subscribed plan. See [Using trial periods on subscriptions](https://docs.stripe.com/billing/subscriptions/trials) to learn more.</summary>
        [<Config.Form>]TrialPeriodDays: int option
        ///<summary>Settings related to subscription trials.</summary>
        [<Config.Form>]TrialSettings: Create'TrialSettings option
    }
    with
        static member New(?addInvoiceItems: Create'AddInvoiceItems list, ?discounts: Choice<Create'Discounts list,string>, ?expand: string list, ?invoiceSettings: Create'InvoiceSettings, ?items: Create'Items list, ?metadata: Map<string, string>, ?offSession: bool, ?description: string, ?onBehalfOf: Choice<string,string>, ?paymentSettings: Create'PaymentSettings, ?pendingInvoiceItemInterval: Choice<Create'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string>, ?prorationBehavior: Create'ProrationBehavior, ?transferData: Create'TransferData, ?trialEnd: Choice<Create'TrialEnd,DateTime>, ?trialFromPlan: bool, ?paymentBehavior: Create'PaymentBehavior, ?trialPeriodDays: int, ?defaultTaxRates: Choice<string list,string>, ?defaultPaymentMethod: string, ?applicationFeePercent: Choice<decimal,string>, ?automaticTax: Create'AutomaticTax, ?backdateStartDate: DateTime, ?billingCycleAnchor: DateTime, ?billingCycleAnchorConfig: Create'BillingCycleAnchorConfig, ?billingMode: Create'BillingMode, ?defaultSource: string, ?billingThresholds: Choice<Create'BillingThresholdsBillingThresholds,string>, ?cancelAtPeriodEnd: bool, ?collectionMethod: Create'CollectionMethod, ?currency: IsoTypes.IsoCurrencyCode, ?customer: string, ?customerAccount: string, ?daysUntilDue: int, ?cancelAt: Choice<DateTime,Create'CancelAt>, ?trialSettings: Create'TrialSettings) =
            {
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BackdateStartDate = backdateStartDate
                BillingCycleAnchor = billingCycleAnchor
                BillingCycleAnchorConfig = billingCycleAnchorConfig
                BillingMode = billingMode
                BillingThresholds = billingThresholds
                CancelAt = cancelAt
                CancelAtPeriodEnd = cancelAtPeriodEnd
                CollectionMethod = collectionMethod
                Currency = currency
                Customer = customer
                CustomerAccount = customerAccount
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                Expand = expand
                InvoiceSettings = invoiceSettings
                Items = items
                Metadata = metadata
                OffSession = offSession
                OnBehalfOf = onBehalfOf
                PaymentBehavior = paymentBehavior
                PaymentSettings = paymentSettings
                PendingInvoiceItemInterval = pendingInvoiceItemInterval
                ProrationBehavior = prorationBehavior
                TransferData = transferData
                TrialEnd = trialEnd
                TrialFromPlan = trialFromPlan
                TrialPeriodDays = trialPeriodDays
                TrialSettings = trialSettings
            }

    ///<summary><p>Creates a new subscription on an existing customer. Each customer can have up to 500 active or scheduled subscriptions.</p>
    ///<p>When you create a subscription with <code>collection_method=charge_automatically</code>, the first invoice is finalized as part of the request.
    ///The <code>payment_behavior</code> parameter determines the exact behavior of the initial payment.</p>
    ///<p>To start subscriptions where the first invoice always begins in a <code>draft</code> status, use <a href="/docs/billing/subscriptions/subscription-schedules#managing">subscription schedules</a> instead.
    ///Schedules provide the flexibility to model more complex billing configurations that change over time.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/subscriptions"
        |> RestApi.postAsync<_, Subscription> settings (Map.empty) options

    type Cancel'CancellationDetailsFeedback =
    | CustomerService
    | LowQuality
    | MissingFeatures
    | Other
    | SwitchedService
    | TooComplex
    | TooExpensive
    | Unused

    type Cancel'CancellationDetails = {
        ///<summary>Additional comments about why the user canceled the subscription, if the subscription was canceled explicitly by the user.</summary>
        [<Config.Form>]Comment: Choice<string,string> option
        ///<summary>The customer submitted reason for why they canceled, if the subscription was canceled explicitly by the user.</summary>
        [<Config.Form>]Feedback: Cancel'CancellationDetailsFeedback option
    }
    with
        static member New(?comment: Choice<string,string>, ?feedback: Cancel'CancellationDetailsFeedback) =
            {
                Comment = comment
                Feedback = feedback
            }

    type CancelOptions = {
        [<Config.Path>]SubscriptionExposedId: string
        ///<summary>Details about why this subscription was cancelled</summary>
        [<Config.Form>]CancellationDetails: Cancel'CancellationDetails option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Will generate a final invoice that invoices for any un-invoiced metered usage and new/pending proration invoice items. Defaults to `false`.</summary>
        [<Config.Form>]InvoiceNow: bool option
        ///<summary>Will generate a proration invoice item that credits remaining unused time until the subscription period end. Defaults to `false`.</summary>
        [<Config.Form>]Prorate: bool option
    }
    with
        static member New(subscriptionExposedId: string, ?cancellationDetails: Cancel'CancellationDetails, ?expand: string list, ?invoiceNow: bool, ?prorate: bool) =
            {
                SubscriptionExposedId = subscriptionExposedId
                CancellationDetails = cancellationDetails
                Expand = expand
                InvoiceNow = invoiceNow
                Prorate = prorate
            }

    ///<summary><p>Cancels a customer’s subscription immediately. The customer won’t be charged again for the subscription. After it’s canceled, you can no longer update the subscription or its <a href="/metadata">metadata</a>.</p>
    ///<p>Any pending invoice items that you’ve created are still charged at the end of the period, unless manually <a href="/api/invoiceitems/delete">deleted</a>. If you’ve set the subscription to cancel at the end of the period, any pending prorations are also left in place and collected at the end of the period. But if the subscription is set to cancel immediately, pending prorations are removed if <code>invoice_now</code> and <code>prorate</code> are both set to true.</p>
    ///<p>By default, upon subscription cancellation, Stripe stops automatic collection of all finalized invoices for the customer. This is intended to prevent unexpected payment attempts after the customer has canceled a subscription. However, you can resume automatic collection of the invoices manually after subscription cancellation to have us proceed. Or, you could check for unpaid invoices before allowing the customer to cancel the subscription at all.</p></summary>
    let Cancel settings (options: CancelOptions) =
        $"/v1/subscriptions/{options.SubscriptionExposedId}"
        |> RestApi.deleteAsync<Subscription> settings (Map.empty)

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]SubscriptionExposedId: string
    }
    with
        static member New(subscriptionExposedId: string, ?expand: string list) =
            {
                Expand = expand
                SubscriptionExposedId = subscriptionExposedId
            }

    ///<summary><p>Retrieves the subscription with the given ID.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/subscriptions/{options.SubscriptionExposedId}"
        |> RestApi.getAsync<Subscription> settings qs

    type Update'AddInvoiceItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'AddInvoiceItemsPeriodEndType =
    | MinItemPeriodEnd
    | Timestamp

    type Update'AddInvoiceItemsPeriodEnd = {
        ///<summary>A precise Unix timestamp for the end of the invoice item period. Must be greater than or equal to `period.start`.</summary>
        [<Config.Form>]Timestamp: DateTime option
        ///<summary>Select how to calculate the end of the invoice item period.</summary>
        [<Config.Form>]Type: Update'AddInvoiceItemsPeriodEndType option
    }
    with
        static member New(?timestamp: DateTime, ?type': Update'AddInvoiceItemsPeriodEndType) =
            {
                Timestamp = timestamp
                Type = type'
            }

    type Update'AddInvoiceItemsPeriodStartType =
    | MaxItemPeriodStart
    | Now
    | Timestamp

    type Update'AddInvoiceItemsPeriodStart = {
        ///<summary>A precise Unix timestamp for the start of the invoice item period. Must be less than or equal to `period.end`.</summary>
        [<Config.Form>]Timestamp: DateTime option
        ///<summary>Select how to calculate the start of the invoice item period.</summary>
        [<Config.Form>]Type: Update'AddInvoiceItemsPeriodStartType option
    }
    with
        static member New(?timestamp: DateTime, ?type': Update'AddInvoiceItemsPeriodStartType) =
            {
                Timestamp = timestamp
                Type = type'
            }

    type Update'AddInvoiceItemsPeriod = {
        ///<summary>End of the invoice item period.</summary>
        [<Config.Form>]End: Update'AddInvoiceItemsPeriodEnd option
        ///<summary>Start of the invoice item period.</summary>
        [<Config.Form>]Start: Update'AddInvoiceItemsPeriodStart option
    }
    with
        static member New(?end': Update'AddInvoiceItemsPeriodEnd, ?start: Update'AddInvoiceItemsPeriodStart) =
            {
                End = end'
                Start = start
            }

    type Update'AddInvoiceItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'AddInvoiceItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Update'AddInvoiceItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge or a negative integer representing the amount to credit to the customer.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?taxBehavior: Update'AddInvoiceItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'AddInvoiceItems = {
        ///<summary>The coupons to redeem into discounts for the item.</summary>
        [<Config.Form>]Discounts: Update'AddInvoiceItemsDiscounts list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The period associated with this invoice item. If not set, `period.start.type` defaults to `max_item_period_start` and `period.end.type` defaults to `min_item_period_end`.</summary>
        [<Config.Form>]Period: Update'AddInvoiceItemsPeriod option
        ///<summary>The ID of the price object. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]PriceData: Update'AddInvoiceItemsPriceData option
        ///<summary>Quantity for this item. Defaults to 1.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>The tax rates which apply to the item. When set, the `default_tax_rates` do not apply to this item.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?discounts: Update'AddInvoiceItemsDiscounts list, ?metadata: Map<string, string>, ?period: Update'AddInvoiceItemsPeriod, ?price: string, ?priceData: Update'AddInvoiceItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                Discounts = discounts
                Metadata = metadata
                Period = period
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Update'AutomaticTaxLiabilityType =
    | Account
    | Self

    type Update'AutomaticTaxLiability = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Update'AutomaticTaxLiabilityType option
    }
    with
        static member New(?account: string, ?type': Update'AutomaticTaxLiabilityType) =
            {
                Account = account
                Type = type'
            }

    type Update'AutomaticTax = {
        ///<summary>Enabled automatic tax calculation which will automatically compute tax rates on all invoices generated by the subscription.</summary>
        [<Config.Form>]Enabled: bool option
        ///<summary>The account that's liable for tax. If set, the business address and tax registrations required to perform the tax calculation are loaded from this account. The tax transaction is returned in the report of the connected account.</summary>
        [<Config.Form>]Liability: Update'AutomaticTaxLiability option
    }
    with
        static member New(?enabled: bool, ?liability: Update'AutomaticTaxLiability) =
            {
                Enabled = enabled
                Liability = liability
            }

    type Update'BillingThresholdsBillingThresholds = {
        ///<summary>Monetary threshold that triggers the subscription to advance to a new billing period</summary>
        [<Config.Form>]AmountGte: int option
        ///<summary>Indicates if the `billing_cycle_anchor` should be reset when a threshold is reached. If true, `billing_cycle_anchor` will be updated to the date/time the threshold was last reached; otherwise, the value will remain unchanged.</summary>
        [<Config.Form>]ResetBillingCycleAnchor: bool option
    }
    with
        static member New(?amountGte: int, ?resetBillingCycleAnchor: bool) =
            {
                AmountGte = amountGte
                ResetBillingCycleAnchor = resetBillingCycleAnchor
            }

    type Update'CancelAt =
    | MaxPeriodEnd
    | MinPeriodEnd

    type Update'CancellationDetailsFeedback =
    | CustomerService
    | LowQuality
    | MissingFeatures
    | Other
    | SwitchedService
    | TooComplex
    | TooExpensive
    | Unused

    type Update'CancellationDetails = {
        ///<summary>Additional comments about why the user canceled the subscription, if the subscription was canceled explicitly by the user.</summary>
        [<Config.Form>]Comment: Choice<string,string> option
        ///<summary>The customer submitted reason for why they canceled, if the subscription was canceled explicitly by the user.</summary>
        [<Config.Form>]Feedback: Update'CancellationDetailsFeedback option
    }
    with
        static member New(?comment: Choice<string,string>, ?feedback: Update'CancellationDetailsFeedback) =
            {
                Comment = comment
                Feedback = feedback
            }

    type Update'Discounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'InvoiceSettingsIssuerType =
    | Account
    | Self

    type Update'InvoiceSettingsIssuer = {
        ///<summary>The connected account being referenced when `type` is `account`.</summary>
        [<Config.Form>]Account: string option
        ///<summary>Type of the account referenced in the request.</summary>
        [<Config.Form>]Type: Update'InvoiceSettingsIssuerType option
    }
    with
        static member New(?account: string, ?type': Update'InvoiceSettingsIssuerType) =
            {
                Account = account
                Type = type'
            }

    type Update'InvoiceSettings = {
        ///<summary>The account tax IDs associated with the subscription. Will be set on invoices generated by the subscription.</summary>
        [<Config.Form>]AccountTaxIds: Choice<string list,string> option
        ///<summary>The connected account that issues the invoice. The invoice is presented with the branding and support information of the specified account.</summary>
        [<Config.Form>]Issuer: Update'InvoiceSettingsIssuer option
    }
    with
        static member New(?accountTaxIds: Choice<string list,string>, ?issuer: Update'InvoiceSettingsIssuer) =
            {
                AccountTaxIds = accountTaxIds
                Issuer = issuer
            }

    type Update'ItemsBillingThresholdsItemBillingThresholds = {
        ///<summary>Number of units that meets the billing threshold to advance the subscription to a new billing period (e.g., it takes 10 $5 units to meet a $50 [monetary threshold](https://docs.stripe.com/api/subscriptions/update#update_subscription-billing_thresholds-amount_gte))</summary>
        [<Config.Form>]UsageGte: int option
    }
    with
        static member New(?usageGte: int) =
            {
                UsageGte = usageGte
            }

    type Update'ItemsDiscounts = {
        ///<summary>ID of the coupon to create a new discount for.</summary>
        [<Config.Form>]Coupon: string option
        ///<summary>ID of an existing discount on the object (or one of its ancestors) to reuse.</summary>
        [<Config.Form>]Discount: string option
        ///<summary>ID of the promotion code to create a new discount for.</summary>
        [<Config.Form>]PromotionCode: string option
    }
    with
        static member New(?coupon: string, ?discount: string, ?promotionCode: string) =
            {
                Coupon = coupon
                Discount = discount
                PromotionCode = promotionCode
            }

    type Update'ItemsPriceDataRecurringInterval =
    | Day
    | Month
    | Week
    | Year

    type Update'ItemsPriceDataRecurring = {
        ///<summary>Specifies billing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Update'ItemsPriceDataRecurringInterval option
        ///<summary>The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Update'ItemsPriceDataRecurringInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Update'ItemsPriceDataTaxBehavior =
    | Exclusive
    | Inclusive
    | Unspecified

    type Update'ItemsPriceData = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode option
        ///<summary>The ID of the [Product](https://docs.stripe.com/api/products) that this [Price](https://docs.stripe.com/api/prices) will belong to.</summary>
        [<Config.Form>]Product: string option
        ///<summary>The recurring components of a price such as `interval` and `interval_count`.</summary>
        [<Config.Form>]Recurring: Update'ItemsPriceDataRecurring option
        ///<summary>Only required if a [default tax behavior](https://docs.stripe.com/tax/products-prices-tax-categories-tax-behavior#setting-a-default-tax-behavior-(recommended)) was not provided in the Stripe Tax settings. Specifies whether the price is considered inclusive of taxes or exclusive of taxes. One of `inclusive`, `exclusive`, or `unspecified`. Once specified as either `inclusive` or `exclusive`, it cannot be changed.</summary>
        [<Config.Form>]TaxBehavior: Update'ItemsPriceDataTaxBehavior option
        ///<summary>A positive integer in cents (or local equivalent) (or 0 for a free price) representing how much to charge.</summary>
        [<Config.Form>]UnitAmount: int option
        ///<summary>Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.</summary>
        [<Config.Form>]UnitAmountDecimal: string option
    }
    with
        static member New(?currency: IsoTypes.IsoCurrencyCode, ?product: string, ?recurring: Update'ItemsPriceDataRecurring, ?taxBehavior: Update'ItemsPriceDataTaxBehavior, ?unitAmount: int, ?unitAmountDecimal: string) =
            {
                Currency = currency
                Product = product
                Recurring = recurring
                TaxBehavior = taxBehavior
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
            }

    type Update'Items = {
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. Pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<Update'ItemsBillingThresholdsItemBillingThresholds,string> option
        ///<summary>Delete all usage for a given subscription item. You must pass this when deleting a usage records subscription item. `clear_usage` has no effect if the plan has a billing meter attached.</summary>
        [<Config.Form>]ClearUsage: bool option
        ///<summary>A flag that, if set to `true`, will delete the specified item.</summary>
        [<Config.Form>]Deleted: bool option
        ///<summary>The coupons to redeem into discounts for the subscription item.</summary>
        [<Config.Form>]Discounts: Choice<Update'ItemsDiscounts list,string> option
        ///<summary>Subscription item to update.</summary>
        [<Config.Form>]Id: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Plan ID for this item, as a string.</summary>
        [<Config.Form>]Plan: string option
        ///<summary>The ID of the price object. One of `price` or `price_data` is required. When changing a subscription item's price, `quantity` is set to 1 unless a `quantity` parameter is provided.</summary>
        [<Config.Form>]Price: string option
        ///<summary>Data used to generate a new [Price](https://docs.stripe.com/api/prices) object inline. One of `price` or `price_data` is required.</summary>
        [<Config.Form>]PriceData: Update'ItemsPriceData option
        ///<summary>Quantity for this item.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>A list of [Tax Rate](https://docs.stripe.com/api/tax_rates) ids. These Tax Rates will override the [`default_tax_rates`](https://docs.stripe.com/api/subscriptions/create#create_subscription-default_tax_rates) on the Subscription. When updating, pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]TaxRates: Choice<string list,string> option
    }
    with
        static member New(?billingThresholds: Choice<Update'ItemsBillingThresholdsItemBillingThresholds,string>, ?clearUsage: bool, ?deleted: bool, ?discounts: Choice<Update'ItemsDiscounts list,string>, ?id: string, ?metadata: Map<string, string>, ?plan: string, ?price: string, ?priceData: Update'ItemsPriceData, ?quantity: int, ?taxRates: Choice<string list,string>) =
            {
                BillingThresholds = billingThresholds
                ClearUsage = clearUsage
                Deleted = deleted
                Discounts = discounts
                Id = id
                Metadata = metadata
                Plan = plan
                Price = price
                PriceData = priceData
                Quantity = quantity
                TaxRates = taxRates
            }

    type Update'PauseCollectionPauseCollectionBehavior =
    | KeepAsDraft
    | MarkUncollectible
    | Void

    type Update'PauseCollectionPauseCollection = {
        ///<summary>The payment collection behavior for this subscription while paused.</summary>
        [<Config.Form>]Behavior: Update'PauseCollectionPauseCollectionBehavior option
        ///<summary>The time after which the subscription will resume collecting payments.</summary>
        [<Config.Form>]ResumesAt: DateTime option
    }
    with
        static member New(?behavior: Update'PauseCollectionPauseCollectionBehavior, ?resumesAt: DateTime) =
            {
                Behavior = behavior
                ResumesAt = resumesAt
            }

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType =
    | Business
    | Personal

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions = {
        ///<summary>Transaction type of the mandate.</summary>
        [<Config.Form>]TransactionType: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType option
    }
    with
        static member New(?transactionType: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptionsTransactionType) =
            {
                TransactionType = transactionType
            }

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions = {
        ///<summary>Additional fields for Mandate creation</summary>
        [<Config.Form>]MandateOptions: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions option
        ///<summary>Verification method for the intent</summary>
        [<Config.Form>]VerificationMethod: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsMandateOptions, ?verificationMethod: Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptionsVerificationMethod) =
            {
                MandateOptions = mandateOptions
                VerificationMethod = verificationMethod
            }

    type Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage =
    | De
    | En
    | Fr
    | Nl

    type Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions = {
        ///<summary>Preferred language of the Bancontact authorization page that the customer is redirected to.</summary>
        [<Config.Form>]PreferredLanguage: Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage option
    }
    with
        static member New(?preferredLanguage: Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptionsPreferredLanguage) =
            {
                PreferredLanguage = preferredLanguage
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions = {
        ///<summary>Amount to be charged for future payments, specified in the presentment currency.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.</summary>
        [<Config.Form>]AmountType: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType option
        ///<summary>A description of the mandate or subscription that is meant to be displayed to the customer.</summary>
        [<Config.Form>]Description: string option
    }
    with
        static member New(?amount: int, ?amountType: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptionsAmountType, ?description: string) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
            }

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork =
    | Amex
    | CartesBancaires
    | Diners
    | Discover
    | EftposAu
    | Girocard
    | Interac
    | Jcb
    | Link
    | Mastercard
    | Unionpay
    | Unknown
    | Visa

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure =
    | Any
    | Automatic
    | Challenge

    type Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions = {
        ///<summary>Configuration options for setting up an eMandate for cards issued in India.</summary>
        [<Config.Form>]MandateOptions: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions option
        ///<summary>Selected network to process this Subscription on. Depends on the available networks of the card attached to the Subscription. Can be only set confirm-time.</summary>
        [<Config.Form>]Network: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork option
        ///<summary>We strongly recommend that you rely on our SCA Engine to automatically prompt your customers for authentication based on risk level and [other requirements](https://docs.stripe.com/strong-customer-authentication). However, if you wish to request 3D Secure based on logic from your own fraud engine, provide this option. Read our guide on [manually requesting 3D Secure](https://docs.stripe.com/payments/3d-secure/authentication-flow#manual-three-ds) for more information on how this configuration interacts with Radar and our SCA Engine.</summary>
        [<Config.Form>]RequestThreeDSecure: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure option
    }
    with
        static member New(?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsMandateOptions, ?network: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsNetwork, ?requestThreeDSecure: Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptionsRequestThreeDSecure) =
            {
                MandateOptions = mandateOptions
                Network = network
                RequestThreeDSecure = requestThreeDSecure
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer = {
        ///<summary>The desired country code of the bank account information. Permitted values include: `DE`, `FR`, `IE`, or `NL`.</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
    }
    with
        static member New(?country: IsoTypes.IsoCountryCode) =
            {
                Country = country
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer = {
        ///<summary>Configuration for eu_bank_transfer funding type.</summary>
        [<Config.Form>]EuBankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer option
        ///<summary>The bank transfer type that can be used for funding. Permitted values include: `eu_bank_transfer`, `gb_bank_transfer`, `jp_bank_transfer`, `mx_bank_transfer`, or `us_bank_transfer`.</summary>
        [<Config.Form>]Type: string option
    }
    with
        static member New(?euBankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransferEuBankTransfer, ?type': string) =
            {
                EuBankTransfer = euBankTransfer
                Type = type'
            }

    type Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions = {
        ///<summary>Configuration for the bank transfer funding type, if the `funding_type` is set to `bank_transfer`.</summary>
        [<Config.Form>]BankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer option
        ///<summary>The funding method type to be used when there are not enough funds in the customer balance. Permitted values include: `bank_transfer`.</summary>
        [<Config.Form>]FundingType: string option
    }
    with
        static member New(?bankTransfer: Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptionsBankTransfer, ?fundingType: string) =
            {
                BankTransfer = bankTransfer
                FundingType = fundingType
            }

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose =
    | DependantSupport
    | Government
    | Loan
    | Mortgage
    | Other
    | Pension
    | Personal
    | Retail
    | Salary
    | Tax
    | Utility

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions = {
        ///<summary>The maximum amount that can be collected in a single invoice. If you don't specify a maximum, then there is no limit.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>The purpose for which payments are made. Has a default value based on your merchant category code.</summary>
        [<Config.Form>]Purpose: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose option
    }
    with
        static member New(?amount: int, ?purpose: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptionsPurpose) =
            {
                Amount = amount
                Purpose = purpose
            }

    type Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions = {
        ///<summary>Additional fields for Mandate creation.</summary>
        [<Config.Form>]MandateOptions: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions option
    }
    with
        static member New(?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptionsMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsAmountIncludesIof =
    | Always
    | Never

    type Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsPaymentSchedule =
    | Halfyearly
    | Monthly
    | Quarterly
    | Weekly
    | Yearly

    type Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions = {
        ///<summary>Amount to be charged for future payments. If not provided, defaults to 40000.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Determines if the amount includes the IOF tax. Defaults to `never`.</summary>
        [<Config.Form>]AmountIncludesIof: Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsAmountIncludesIof option
        ///<summary>Date when the mandate expires and no further payments will be charged, in `YYYY-MM-DD`. If not provided, the mandate will be active until canceled.</summary>
        [<Config.Form>]EndDate: string option
        ///<summary>Schedule at which the future payments will be charged. Defaults to the subscription servicing interval.</summary>
        [<Config.Form>]PaymentSchedule: Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsPaymentSchedule option
    }
    with
        static member New(?amount: int, ?amountIncludesIof: Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsAmountIncludesIof, ?endDate: string, ?paymentSchedule: Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptionsPaymentSchedule) =
            {
                Amount = amount
                AmountIncludesIof = amountIncludesIof
                EndDate = endDate
                PaymentSchedule = paymentSchedule
            }

    type Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions = {
        ///<summary>The number of seconds (between 10 and 1209600) after which Pix payment will expire. Defaults to 86400 seconds.</summary>
        [<Config.Form>]ExpiresAfterSeconds: int option
        ///<summary>Configuration options for setting up a mandate</summary>
        [<Config.Form>]MandateOptions: Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions option
    }
    with
        static member New(?expiresAfterSeconds: int, ?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptionsMandateOptions) =
            {
                ExpiresAfterSeconds = expiresAfterSeconds
                MandateOptions = mandateOptions
            }

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType =
    | Fixed
    | Maximum

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions = {
        ///<summary>Amount to be charged for future payments.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>One of `fixed` or `maximum`. If `fixed`, the `amount` param refers to the exact amount to be charged in future payments. If `maximum`, the amount charged can be up to the value passed for the `amount` param.</summary>
        [<Config.Form>]AmountType: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType option
        ///<summary>A description of the mandate or subscription that is meant to be displayed to the customer.</summary>
        [<Config.Form>]Description: string option
        ///<summary>End date of the mandate or subscription.</summary>
        [<Config.Form>]EndDate: DateTime option
    }
    with
        static member New(?amount: int, ?amountType: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptionsAmountType, ?description: string, ?endDate: DateTime) =
            {
                Amount = amount
                AmountType = amountType
                Description = description
                EndDate = endDate
            }

    type Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions = {
        ///<summary>Configuration options for setting up an eMandate</summary>
        [<Config.Form>]MandateOptions: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions option
    }
    with
        static member New(?mandateOptions: Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptionsMandateOptions) =
            {
                MandateOptions = mandateOptions
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories =
    | Checking
    | Savings

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters = {
        ///<summary>The account subcategories to use to filter for selectable accounts. Valid subcategories are `checking` and `savings`.</summary>
        [<Config.Form>]AccountSubcategories: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list option
    }
    with
        static member New(?accountSubcategories: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFiltersAccountSubcategories list) =
            {
                AccountSubcategories = accountSubcategories
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions =
    | Balances
    | Ownership
    | PaymentMethod
    | Transactions

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch =
    | Balances
    | Ownership
    | Transactions

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections = {
        ///<summary>Provide filters for the linked accounts that the customer can select for the payment method.</summary>
        [<Config.Form>]Filters: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters option
        ///<summary>The list of permissions to request. If this parameter is passed, the `payment_method` permission must be included. Valid permissions include: `balances`, `ownership`, `payment_method`, and `transactions`.</summary>
        [<Config.Form>]Permissions: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list option
        ///<summary>List of data features that you would like to retrieve upon account creation.</summary>
        [<Config.Form>]Prefetch: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list option
    }
    with
        static member New(?filters: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsFilters, ?permissions: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPermissions list, ?prefetch: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnectionsPrefetch list) =
            {
                Filters = filters
                Permissions = permissions
                Prefetch = prefetch
            }

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod =
    | Automatic
    | Instant
    | Microdeposits

    type Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions = {
        ///<summary>Additional fields for Financial Connections Session creation</summary>
        [<Config.Form>]FinancialConnections: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections option
        ///<summary>Verification method for the intent</summary>
        [<Config.Form>]VerificationMethod: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod option
    }
    with
        static member New(?financialConnections: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsFinancialConnections, ?verificationMethod: Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptionsVerificationMethod) =
            {
                FinancialConnections = financialConnections
                VerificationMethod = verificationMethod
            }

    type Update'PaymentSettingsPaymentMethodOptions = {
        ///<summary>This sub-hash contains details about the Canadian pre-authorized debit payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]AcssDebit: Choice<Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the Bancontact payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Bancontact: Choice<Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the Card payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Card: Choice<Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the Bank transfer payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]CustomerBalance: Choice<Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the Konbini payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Konbini: Choice<string,string> option
        ///<summary>This sub-hash contains details about the PayTo payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Payto: Choice<Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the Pix payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Pix: Choice<Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the SEPA Direct Debit payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]SepaDebit: Choice<string,string> option
        ///<summary>This sub-hash contains details about the UPI payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]Upi: Choice<Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string> option
        ///<summary>This sub-hash contains details about the ACH direct debit payment method options to pass to the invoice’s PaymentIntent.</summary>
        [<Config.Form>]UsBankAccount: Choice<Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string> option
    }
    with
        static member New(?acssDebit: Choice<Update'PaymentSettingsPaymentMethodOptionsAcssDebitInvoicePaymentMethodOptions,string>, ?bancontact: Choice<Update'PaymentSettingsPaymentMethodOptionsBancontactInvoicePaymentMethodOptions,string>, ?card: Choice<Update'PaymentSettingsPaymentMethodOptionsCardSubscriptionPaymentMethodOptions,string>, ?customerBalance: Choice<Update'PaymentSettingsPaymentMethodOptionsCustomerBalanceInvoicePaymentMethodOptions,string>, ?konbini: Choice<string,string>, ?payto: Choice<Update'PaymentSettingsPaymentMethodOptionsPaytoInvoicePaymentMethodOptions,string>, ?pix: Choice<Update'PaymentSettingsPaymentMethodOptionsPixSubscriptionPaymentMethodOptions,string>, ?sepaDebit: Choice<string,string>, ?upi: Choice<Update'PaymentSettingsPaymentMethodOptionsUpiInvoicePaymentMethodOptions,string>, ?usBankAccount: Choice<Update'PaymentSettingsPaymentMethodOptionsUsBankAccountInvoicePaymentMethodOptions,string>) =
            {
                AcssDebit = acssDebit
                Bancontact = bancontact
                Card = card
                CustomerBalance = customerBalance
                Konbini = konbini
                Payto = payto
                Pix = pix
                SepaDebit = sepaDebit
                Upi = upi
                UsBankAccount = usBankAccount
            }

    type Update'PaymentSettingsPaymentMethodTypes =
    | AchCreditTransfer
    | AchDebit
    | AcssDebit
    | Affirm
    | AmazonPay
    | AuBecsDebit
    | BacsDebit
    | Bancontact
    | Boleto
    | Card
    | Cashapp
    | Crypto
    | Custom
    | CustomerBalance
    | Eps
    | Fpx
    | Giropay
    | Grabpay
    | Ideal
    | JpCreditTransfer
    | KakaoPay
    | Klarna
    | Konbini
    | KrCard
    | Link
    | Multibanco
    | NaverPay
    | NzBankAccount
    | P24
    | PayByBank
    | Payco
    | Paynow
    | Paypal
    | Payto
    | Pix
    | Promptpay
    | RevolutPay
    | SepaCreditTransfer
    | SepaDebit
    | Sofort
    | Swish
    | Upi
    | UsBankAccount
    | WechatPay

    type Update'PaymentSettingsSaveDefaultPaymentMethod =
    | Off
    | OnSubscription

    type Update'PaymentSettings = {
        ///<summary>Payment-method-specific configuration to provide to invoices created by the subscription.</summary>
        [<Config.Form>]PaymentMethodOptions: Update'PaymentSettingsPaymentMethodOptions option
        ///<summary>The list of payment method types (e.g. card) to provide to the invoice’s PaymentIntent. If not set, Stripe attempts to automatically determine the types to use by looking at the invoice’s default payment method, the subscription’s default payment method, the customer’s default payment method, and your [invoice template settings](https://dashboard.stripe.com/settings/billing/invoice). Should not be specified with payment_method_configuration</summary>
        [<Config.Form>]PaymentMethodTypes: Choice<Update'PaymentSettingsPaymentMethodTypes list,string> option
        ///<summary>Configure whether Stripe updates `subscription.default_payment_method` when payment succeeds. Defaults to `off` if unspecified.</summary>
        [<Config.Form>]SaveDefaultPaymentMethod: Update'PaymentSettingsSaveDefaultPaymentMethod option
    }
    with
        static member New(?paymentMethodOptions: Update'PaymentSettingsPaymentMethodOptions, ?paymentMethodTypes: Choice<Update'PaymentSettingsPaymentMethodTypes list,string>, ?saveDefaultPaymentMethod: Update'PaymentSettingsSaveDefaultPaymentMethod) =
            {
                PaymentMethodOptions = paymentMethodOptions
                PaymentMethodTypes = paymentMethodTypes
                SaveDefaultPaymentMethod = saveDefaultPaymentMethod
            }

    type Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval =
    | Day
    | Month
    | Week
    | Year

    type Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams = {
        ///<summary>Specifies invoicing frequency. Either `day`, `week`, `month` or `year`.</summary>
        [<Config.Form>]Interval: Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval option
        ///<summary>The number of intervals between invoices. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of one year interval allowed (1 year, 12 months, or 52 weeks).</summary>
        [<Config.Form>]IntervalCount: int option
    }
    with
        static member New(?interval: Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParamsInterval, ?intervalCount: int) =
            {
                Interval = interval
                IntervalCount = intervalCount
            }

    type Update'TransferDataTransferDataSpecs = {
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the destination account. By default, the entire amount is transferred to the destination.</summary>
        [<Config.Form>]AmountPercent: decimal option
        ///<summary>ID of an existing, connected Stripe account.</summary>
        [<Config.Form>]Destination: string option
    }
    with
        static member New(?amountPercent: decimal, ?destination: string) =
            {
                AmountPercent = amountPercent
                Destination = destination
            }

    type Update'TrialEnd =
    | Now

    type Update'TrialSettingsEndBehaviorMissingPaymentMethod =
    | Cancel
    | CreateInvoice
    | Pause

    type Update'TrialSettingsEndBehavior = {
        ///<summary>Indicates how the subscription should change when the trial ends if the user did not provide a payment method.</summary>
        [<Config.Form>]MissingPaymentMethod: Update'TrialSettingsEndBehaviorMissingPaymentMethod option
    }
    with
        static member New(?missingPaymentMethod: Update'TrialSettingsEndBehaviorMissingPaymentMethod) =
            {
                MissingPaymentMethod = missingPaymentMethod
            }

    type Update'TrialSettings = {
        ///<summary>Defines how the subscription should behave when the user's free trial ends.</summary>
        [<Config.Form>]EndBehavior: Update'TrialSettingsEndBehavior option
    }
    with
        static member New(?endBehavior: Update'TrialSettingsEndBehavior) =
            {
                EndBehavior = endBehavior
            }

    type Update'BillingCycleAnchor =
    | Now
    | Unchanged

    type Update'CollectionMethod =
    | ChargeAutomatically
    | SendInvoice

    type Update'PaymentBehavior =
    | AllowIncomplete
    | DefaultIncomplete
    | ErrorIfIncomplete
    | PendingIfIncomplete

    type Update'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type UpdateOptions = {
        [<Config.Path>]SubscriptionExposedId: string
        ///<summary>A list of prices and quantities that will generate invoice items appended to the next invoice for this subscription. You may pass up to 20 items.</summary>
        [<Config.Form>]AddInvoiceItems: Update'AddInvoiceItems list option
        ///<summary>A non-negative decimal between 0 and 100, with at most two decimal places. This represents the percentage of the subscription invoice total that will be transferred to the application owner's Stripe account. The request must be made by a platform account on a connected account in order to set an application fee percentage. For more information, see the application fees [documentation](https://stripe.com/docs/connect/subscriptions#collecting-fees-on-subscriptions).</summary>
        [<Config.Form>]ApplicationFeePercent: Choice<decimal,string> option
        ///<summary>Automatic tax settings for this subscription. We recommend you only include this parameter when the existing value is being changed.</summary>
        [<Config.Form>]AutomaticTax: Update'AutomaticTax option
        ///<summary>Either `now` or `unchanged`. Setting the value to `now` resets the subscription's billing cycle anchor to the current time (in UTC). For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).</summary>
        [<Config.Form>]BillingCycleAnchor: Update'BillingCycleAnchor option
        ///<summary>Define thresholds at which an invoice will be sent, and the subscription advanced to a new billing period. When updating, pass an empty string to remove previously-defined thresholds.</summary>
        [<Config.Form>]BillingThresholds: Choice<Update'BillingThresholdsBillingThresholds,string> option
        ///<summary>A timestamp at which the subscription should cancel. If set to a date before the current period ends, this will cause a proration if prorations have been enabled using `proration_behavior`. If set during a future period, this will always cause a proration for that period.</summary>
        [<Config.Form>]CancelAt: Choice<DateTime,string,Update'CancelAt> option
        ///<summary>Indicate whether this subscription should cancel at the end of the current period (`current_period_end`). Defaults to `false`.</summary>
        [<Config.Form>]CancelAtPeriodEnd: bool option
        ///<summary>Details about why this subscription was cancelled</summary>
        [<Config.Form>]CancellationDetails: Update'CancellationDetails option
        ///<summary>Either `charge_automatically`, or `send_invoice`. When charging automatically, Stripe will attempt to pay this subscription at the end of the cycle using the default source attached to the customer. When sending an invoice, Stripe will email your customer an invoice with payment instructions and mark the subscription as `active`. Defaults to `charge_automatically`.</summary>
        [<Config.Form>]CollectionMethod: Update'CollectionMethod option
        ///<summary>Number of days a customer has to pay invoices generated by this subscription. Valid only for subscriptions where `collection_method` is set to `send_invoice`.</summary>
        [<Config.Form>]DaysUntilDue: int option
        ///<summary>ID of the default payment method for the subscription. It must belong to the customer associated with the subscription. This takes precedence over `default_source`. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://docs.stripe.com/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://docs.stripe.com/api/customers/object#customer_object-default_source).</summary>
        [<Config.Form>]DefaultPaymentMethod: string option
        ///<summary>ID of the default payment source for the subscription. It must belong to the customer associated with the subscription and be in a chargeable state. If `default_payment_method` is also set, `default_payment_method` will take precedence. If neither are set, invoices will use the customer's [invoice_settings.default_payment_method](https://docs.stripe.com/api/customers/object#customer_object-invoice_settings-default_payment_method) or [default_source](https://docs.stripe.com/api/customers/object#customer_object-default_source).</summary>
        [<Config.Form>]DefaultSource: Choice<string,string> option
        ///<summary>The tax rates that will apply to any subscription item that does not have `tax_rates` set. Invoices created will have their `default_tax_rates` populated from the subscription. Pass an empty string to remove previously-defined tax rates.</summary>
        [<Config.Form>]DefaultTaxRates: Choice<string list,string> option
        ///<summary>The subscription's description, meant to be displayable to the customer. Use this field to optionally store an explanation of the subscription for rendering in Stripe surfaces and certain local payment methods UIs.</summary>
        [<Config.Form>]Description: Choice<string,string> option
        ///<summary>The coupons to redeem into discounts for the subscription. If not specified or empty, inherits the discount from the subscription's customer.</summary>
        [<Config.Form>]Discounts: Choice<Update'Discounts list,string> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>All invoices will be billed using the specified settings.</summary>
        [<Config.Form>]InvoiceSettings: Update'InvoiceSettings option
        ///<summary>A list of up to 20 subscription items, each with an attached price.</summary>
        [<Config.Form>]Items: Update'Items list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>Indicates if a customer is on or off-session while an invoice payment is attempted. Defaults to `false` (on-session).</summary>
        [<Config.Form>]OffSession: bool option
        ///<summary>The account on behalf of which to charge, for each of the subscription's invoices.</summary>
        [<Config.Form>]OnBehalfOf: Choice<string,string> option
        ///<summary>If specified, payment collection for this subscription will be paused. Note that the subscription status will be unchanged and will not be updated to `paused`. Learn more about [pausing collection](https://docs.stripe.com/billing/subscriptions/pause-payment).</summary>
        [<Config.Form>]PauseCollection: Choice<Update'PauseCollectionPauseCollection,string> option
        ///<summary>Use `allow_incomplete` to transition the subscription to `status=past_due` if a payment is required but cannot be paid. This allows you to manage scenarios where additional user actions are needed to pay a subscription's invoice. For example, SCA regulation may require 3DS authentication to complete payment. See the [SCA Migration Guide](https://docs.stripe.com/billing/migration/strong-customer-authentication) for Billing to learn more. This is the default behavior.
        ///Use `default_incomplete` to transition the subscription to `status=past_due` when payment is required and await explicit confirmation of the invoice's payment intent. This allows simpler management of scenarios where additional user actions are needed to pay a subscription’s invoice. Such as failed payments, [SCA regulation](https://docs.stripe.com/billing/migration/strong-customer-authentication), or collecting a mandate for a bank debit payment method.
        ///Use `pending_if_incomplete` to update the subscription using [pending updates](https://docs.stripe.com/billing/subscriptions/pending-updates). When you use `pending_if_incomplete` you can only pass the parameters [supported by pending updates](https://docs.stripe.com/billing/pending-updates-reference#supported-attributes).
        ///Use `error_if_incomplete` if you want Stripe to return an HTTP 402 status code if a subscription's invoice cannot be paid. For example, if a payment method requires 3DS authentication due to SCA regulation and further user action is needed, this parameter does not update the subscription and returns an error instead. This was the default behavior for API versions prior to 2019-03-14. See the [changelog](https://docs.stripe.com/changelog/2019-03-14) to learn more.</summary>
        [<Config.Form>]PaymentBehavior: Update'PaymentBehavior option
        ///<summary>Payment settings to pass to invoices created by the subscription.</summary>
        [<Config.Form>]PaymentSettings: Update'PaymentSettings option
        ///<summary>Specifies an interval for how often to bill for any pending invoice items. It is analogous to calling [Create an invoice](/api/invoices/create) for the given subscription at the specified interval.</summary>
        [<Config.Form>]PendingInvoiceItemInterval: Choice<Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string> option
        ///<summary>Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) when the billing cycle changes (e.g., when switching plans, resetting `billing_cycle_anchor=now`, or starting a trial), or if an item's `quantity` changes. The default value is `create_prorations`.</summary>
        [<Config.Form>]ProrationBehavior: Update'ProrationBehavior option
        ///<summary>If set, prorations will be calculated as though the subscription was updated at the given time. This can be used to apply exactly the same prorations that were previewed with the [create preview](https://stripe.com/docs/api/invoices/create_preview) endpoint. `proration_date` can also be used to implement custom proration logic, such as prorating by day instead of by second, by providing the time that you wish to use for proration calculations.</summary>
        [<Config.Form>]ProrationDate: DateTime option
        ///<summary>If specified, the funds from the subscription's invoices will be transferred to the destination and the ID of the resulting transfers will be found on the resulting charges. This will be unset if you POST an empty value.</summary>
        [<Config.Form>]TransferData: Choice<Update'TransferDataTransferDataSpecs,string> option
        ///<summary>Unix timestamp representing the end of the trial period the customer will get before being charged for the first time. This will always overwrite any trials that might apply via a subscribed plan. If set, `trial_end` will override the default trial period of the plan the customer is being subscribed to. The `billing_cycle_anchor` will be updated to the `trial_end` value. The special value `now` can be provided to end the customer's trial immediately. Can be at most two years from `billing_cycle_anchor`.</summary>
        [<Config.Form>]TrialEnd: Choice<Update'TrialEnd,DateTime> option
        ///<summary>Indicates if a plan's `trial_period_days` should be applied to the subscription. Setting `trial_end` per subscription is preferred, and this defaults to `false`. Setting this flag to `true` together with `trial_end` is not allowed. See [Using trial periods on subscriptions](https://docs.stripe.com/billing/subscriptions/trials) to learn more.</summary>
        [<Config.Form>]TrialFromPlan: bool option
        ///<summary>Settings related to subscription trials.</summary>
        [<Config.Form>]TrialSettings: Update'TrialSettings option
    }
    with
        static member New(subscriptionExposedId: string, ?trialEnd: Choice<Update'TrialEnd,DateTime>, ?transferData: Choice<Update'TransferDataTransferDataSpecs,string>, ?prorationDate: DateTime, ?prorationBehavior: Update'ProrationBehavior, ?pendingInvoiceItemInterval: Choice<Update'PendingInvoiceItemIntervalPendingInvoiceItemIntervalParams,string>, ?paymentSettings: Update'PaymentSettings, ?paymentBehavior: Update'PaymentBehavior, ?pauseCollection: Choice<Update'PauseCollectionPauseCollection,string>, ?onBehalfOf: Choice<string,string>, ?offSession: bool, ?metadata: Map<string, string>, ?items: Update'Items list, ?invoiceSettings: Update'InvoiceSettings, ?expand: string list, ?discounts: Choice<Update'Discounts list,string>, ?description: Choice<string,string>, ?defaultTaxRates: Choice<string list,string>, ?defaultSource: Choice<string,string>, ?defaultPaymentMethod: string, ?daysUntilDue: int, ?collectionMethod: Update'CollectionMethod, ?cancellationDetails: Update'CancellationDetails, ?cancelAtPeriodEnd: bool, ?cancelAt: Choice<DateTime,string,Update'CancelAt>, ?billingThresholds: Choice<Update'BillingThresholdsBillingThresholds,string>, ?billingCycleAnchor: Update'BillingCycleAnchor, ?automaticTax: Update'AutomaticTax, ?applicationFeePercent: Choice<decimal,string>, ?addInvoiceItems: Update'AddInvoiceItems list, ?trialFromPlan: bool, ?trialSettings: Update'TrialSettings) =
            {
                SubscriptionExposedId = subscriptionExposedId
                AddInvoiceItems = addInvoiceItems
                ApplicationFeePercent = applicationFeePercent
                AutomaticTax = automaticTax
                BillingCycleAnchor = billingCycleAnchor
                BillingThresholds = billingThresholds
                CancelAt = cancelAt
                CancelAtPeriodEnd = cancelAtPeriodEnd
                CancellationDetails = cancellationDetails
                CollectionMethod = collectionMethod
                DaysUntilDue = daysUntilDue
                DefaultPaymentMethod = defaultPaymentMethod
                DefaultSource = defaultSource
                DefaultTaxRates = defaultTaxRates
                Description = description
                Discounts = discounts
                Expand = expand
                InvoiceSettings = invoiceSettings
                Items = items
                Metadata = metadata
                OffSession = offSession
                OnBehalfOf = onBehalfOf
                PauseCollection = pauseCollection
                PaymentBehavior = paymentBehavior
                PaymentSettings = paymentSettings
                PendingInvoiceItemInterval = pendingInvoiceItemInterval
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
                TransferData = transferData
                TrialEnd = trialEnd
                TrialFromPlan = trialFromPlan
                TrialSettings = trialSettings
            }

    ///<summary><p>Updates an existing subscription to match the specified parameters.
    ///When changing prices or quantities, we optionally prorate the price we charge next month to make up for any price changes.
    ///To preview how the proration is calculated, use the <a href="/docs/api/invoices/create_preview">create preview</a> endpoint.</p>
    ///<p>By default, we prorate subscription changes. For example, if a customer signs up on May 1 for a <currency>100</currency> price, they’ll be billed <currency>100</currency> immediately. If on May 15 they switch to a <currency>200</currency> price, then on June 1 they’ll be billed <currency>250</currency> (<currency>200</currency> for a renewal of her subscription, plus a <currency>50</currency> prorating adjustment for half of the previous month’s <currency>100</currency> difference). Similarly, a downgrade generates a credit that is applied to the next invoice. We also prorate when you make quantity changes.</p>
    ///<p>Switching prices does not normally change the billing date or generate an immediate charge unless:</p>
    ///<ul>
    ///<li>The billing interval is changed (for example, from monthly to yearly).</li>
    ///<li>The subscription moves from free to paid.</li>
    ///<li>A trial starts or ends.</li>
    ///</ul>
    ///<p>In these cases, we apply a credit for the unused time on the previous price, immediately charge the customer using the new price, and reset the billing date. Learn about how <a href="/docs/billing/subscriptions/upgrade-downgrade#immediate-payment">Stripe immediately attempts payment for subscription changes</a>.</p>
    ///<p>If you want to charge for an upgrade immediately, pass <code>proration_behavior</code> as <code>always_invoice</code> to create prorations, automatically invoice the customer for those proration adjustments, and attempt to collect payment. If you pass <code>create_prorations</code>, the prorations are created but not automatically invoiced. If you want to bill the customer for the prorations before the subscription’s renewal date, you need to manually <a href="/docs/api/invoices/create">invoice the customer</a>.</p>
    ///<p>If you don’t want to prorate, set the <code>proration_behavior</code> option to <code>none</code>. With this option, the customer is billed <currency>100</currency> on May 1 and <currency>200</currency> on June 1. Similarly, if you set <code>proration_behavior</code> to <code>none</code> when switching between different billing intervals (for example, from monthly to yearly), we don’t generate any credits for the old subscription’s unused time. We still reset the billing date and bill immediately for the new subscription.</p>
    ///<p>Updating the quantity on a subscription many times in an hour may result in <a href="/docs/rate-limits">rate limiting</a>. If you need to bill for a frequently changing quantity, consider integrating <a href="/docs/billing/subscriptions/usage-based">usage-based billing</a> instead.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/subscriptions/{options.SubscriptionExposedId}"
        |> RestApi.postAsync<_, Subscription> settings (Map.empty) options

module SubscriptionsSearch =

    type SearchOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for pagination across multiple pages of results. Don't include this parameter on the first call. Use the next_page value returned in a previous response to request subsequent results.</summary>
        [<Config.Query>]Page: string option
        ///<summary>The search query string. See [search query language](https://docs.stripe.com/search#search-query-language) and the list of supported [query fields for subscriptions](https://docs.stripe.com/search#query-fields-for-subscriptions).</summary>
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

    ///<summary><p>Search for subscriptions you’ve previously created using Stripe’s <a href="/docs/search#search-query-language">Search Query Language</a>.
    ///Don’t use search in read-after-write flows where strict consistency is necessary. Under normal operating
    ///conditions, data is searchable in less than a minute. Occasionally, propagation of new or updated data can be up
    ///to an hour behind during outages. Search functionality is not available to merchants in India.</p></summary>
    let Search settings (options: SearchOptions) =
        let qs = [("expand", options.Expand |> box); ("limit", options.Limit |> box); ("page", options.Page |> box); ("query", options.Query |> box)] |> Map.ofList
        $"/v1/subscriptions/search"
        |> RestApi.getAsync<StripeList<Subscription>> settings qs

module SubscriptionsDiscount =

    type DeleteDiscountOptions = {
        [<Config.Path>]SubscriptionExposedId: string
    }
    with
        static member New(subscriptionExposedId: string) =
            {
                SubscriptionExposedId = subscriptionExposedId
            }

    ///<summary><p>Removes the currently applied discount on a subscription.</p></summary>
    let DeleteDiscount settings (options: DeleteDiscountOptions) =
        $"/v1/subscriptions/{options.SubscriptionExposedId}/discount"
        |> RestApi.deleteAsync<DeletedDiscount> settings (Map.empty)

module SubscriptionsMigrate =

    type Migrate'BillingModeFlexibleProrationDiscounts =
    | Included
    | Itemized

    type Migrate'BillingModeFlexible = {
        ///<summary>Controls how invoices and invoice items display proration amounts and discount amounts.</summary>
        [<Config.Form>]ProrationDiscounts: Migrate'BillingModeFlexibleProrationDiscounts option
    }
    with
        static member New(?prorationDiscounts: Migrate'BillingModeFlexibleProrationDiscounts) =
            {
                ProrationDiscounts = prorationDiscounts
            }

    type Migrate'BillingModeType =
    | Flexible

    type Migrate'BillingMode = {
        ///<summary>Configure behavior for flexible billing mode.</summary>
        [<Config.Form>]Flexible: Migrate'BillingModeFlexible option
        ///<summary>Controls the calculation and orchestration of prorations and invoices for subscriptions.</summary>
        [<Config.Form>]Type: Migrate'BillingModeType option
    }
    with
        static member New(?flexible: Migrate'BillingModeFlexible, ?type': Migrate'BillingModeType) =
            {
                Flexible = flexible
                Type = type'
            }

    type MigrateOptions = {
        [<Config.Path>]Subscription: string
        ///<summary>Controls how prorations and invoices for subscriptions are calculated and orchestrated.</summary>
        [<Config.Form>]BillingMode: Migrate'BillingMode
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
    }
    with
        static member New(subscription: string, billingMode: Migrate'BillingMode, ?expand: string list) =
            {
                Subscription = subscription
                BillingMode = billingMode
                Expand = expand
            }

    ///<summary><p>Upgrade the billing_mode of an existing subscription.</p></summary>
    let Migrate settings (options: MigrateOptions) =
        $"/v1/subscriptions/{options.Subscription}/migrate"
        |> RestApi.postAsync<_, Subscription> settings (Map.empty) options

module SubscriptionsResume =

    type Resume'BillingCycleAnchor =
    | Now
    | Unchanged

    type Resume'ProrationBehavior =
    | AlwaysInvoice
    | CreateProrations
    | None'

    type ResumeOptions = {
        [<Config.Path>]Subscription: string
        ///<summary>The billing cycle anchor that applies when the subscription is resumed. Either `now` or `unchanged`. The default is `now`. For more information, see the billing cycle [documentation](https://docs.stripe.com/billing/subscriptions/billing-cycle).</summary>
        [<Config.Form>]BillingCycleAnchor: Resume'BillingCycleAnchor option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Determines how to handle [prorations](https://docs.stripe.com/billing/subscriptions/prorations) resulting from the `billing_cycle_anchor` being `unchanged`. When the `billing_cycle_anchor` is set to `now` (default value), no prorations are generated. If no value is passed, the default is `create_prorations`.</summary>
        [<Config.Form>]ProrationBehavior: Resume'ProrationBehavior option
        ///<summary>If set, prorations will be calculated as though the subscription was resumed at the given time. This can be used to apply exactly the same prorations that were previewed with the [create preview](https://stripe.com/docs/api/invoices/create_preview) endpoint.</summary>
        [<Config.Form>]ProrationDate: DateTime option
    }
    with
        static member New(subscription: string, ?billingCycleAnchor: Resume'BillingCycleAnchor, ?expand: string list, ?prorationBehavior: Resume'ProrationBehavior, ?prorationDate: DateTime) =
            {
                Subscription = subscription
                BillingCycleAnchor = billingCycleAnchor
                Expand = expand
                ProrationBehavior = prorationBehavior
                ProrationDate = prorationDate
            }

    ///<summary><p>Initiates resumption of a paused subscription, optionally resetting the billing cycle anchor and creating prorations. If no resumption invoice is generated, the subscription becomes <code>active</code> immediately. If a resumption invoice is generated, the subscription remains <code>paused</code> until the invoice is paid or marked uncollectible. If the invoice isn’t paid by the expiration date, it is voided and the subscription remains <code>paused</code>. You can only resume subscriptions with <code>collection_method</code> set to <code>charge_automatically</code>. <code>send_invoice</code> subscriptions are not supported.</p></summary>
    let Resume settings (options: ResumeOptions) =
        $"/v1/subscriptions/{options.Subscription}/resume"
        |> RestApi.postAsync<_, Subscription> settings (Map.empty) options

module TaxAssociationsFind =

    type FindOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Valid [PaymentIntent](https://docs.stripe.com/api/payment_intents/object) id</summary>
        [<Config.Query>]PaymentIntent: string
    }
    with
        static member New(paymentIntent: string, ?expand: string list) =
            {
                Expand = expand
                PaymentIntent = paymentIntent
            }

    ///<summary><p>Finds a tax association object by PaymentIntent id.</p></summary>
    let Find settings (options: FindOptions) =
        let qs = [("expand", options.Expand |> box); ("payment_intent", options.PaymentIntent |> box)] |> Map.ofList
        $"/v1/tax/associations/find"
        |> RestApi.getAsync<TaxAssociation> settings qs

module TaxCalculations =

    type Create'CustomerDetailsAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: Choice<string,string> option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: Choice<string,string> option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: Choice<string,string> option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: Choice<string,string> option
        ///<summary>State, county, province, or region. We recommend sending [ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2) subdivision code value when possible.</summary>
        [<Config.Form>]State: Choice<string,string> option
    }
    with
        static member New(?city: Choice<string,string>, ?country: IsoTypes.IsoCountryCode, ?line1: Choice<string,string>, ?line2: Choice<string,string>, ?postalCode: Choice<string,string>, ?state: Choice<string,string>) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'CustomerDetailsTaxIdsType =
    | AdNrt
    | AeTrn
    | AlTin
    | AmTin
    | AoTin
    | ArCuit
    | AuAbn
    | AuArn
    | AwTin
    | AzTin
    | BaTin
    | BbTin
    | BdBin
    | BfIfu
    | BgUic
    | BhVat
    | BjIfu
    | BoTin
    | BrCnpj
    | BrCpf
    | BsTin
    | ByTin
    | CaBn
    | CaGstHst
    | CaPstBc
    | CaPstMb
    | CaPstSk
    | CaQst
    | CdNif
    | ChUid
    | ChVat
    | ClTin
    | CmNiu
    | CnTin
    | CoNit
    | CrTin
    | CvNif
    | DeStn
    | DoRcn
    | EcRuc
    | EgTin
    | EsCif
    | EtTin
    | EuOssVat
    | EuVat
    | FoVat
    | GbVat
    | GeVat
    | GiTin
    | GnNif
    | HkBr
    | HrOib
    | HuTin
    | IdNpwp
    | IlVat
    | InGst
    | IsVat
    | ItCf
    | JpCn
    | JpRn
    | JpTrn
    | KePin
    | KgTin
    | KhTin
    | KrBrn
    | KzBin
    | LaTin
    | LiUid
    | LiVat
    | LkVat
    | MaVat
    | MdVat
    | MePib
    | MkVat
    | MrNif
    | MxRfc
    | MyFrp
    | MyItn
    | MySst
    | NgTin
    | NoVat
    | NoVoec
    | NpPan
    | NzGst
    | OmVat
    | PeRuc
    | PhTin
    | PlNip
    | PyRuc
    | RoTin
    | RsPib
    | RuInn
    | RuKpp
    | SaVat
    | SgGst
    | SgUen
    | SiTin
    | SnNinea
    | SrFin
    | SvNit
    | ThVat
    | TjTin
    | TrTin
    | TwVat
    | TzVat
    | UaVat
    | UgTin
    | UsEin
    | UyRuc
    | UzTin
    | UzVat
    | VeRif
    | VnTin
    | ZaVat
    | ZmTin
    | ZwTin

    type Create'CustomerDetailsTaxIds = {
        ///<summary>Type of the tax ID, one of `ad_nrt`, `ae_trn`, `al_tin`, `am_tin`, `ao_tin`, `ar_cuit`, `au_abn`, `au_arn`, `aw_tin`, `az_tin`, `ba_tin`, `bb_tin`, `bd_bin`, `bf_ifu`, `bg_uic`, `bh_vat`, `bj_ifu`, `bo_tin`, `br_cnpj`, `br_cpf`, `bs_tin`, `by_tin`, `ca_bn`, `ca_gst_hst`, `ca_pst_bc`, `ca_pst_mb`, `ca_pst_sk`, `ca_qst`, `cd_nif`, `ch_uid`, `ch_vat`, `cl_tin`, `cm_niu`, `cn_tin`, `co_nit`, `cr_tin`, `cv_nif`, `de_stn`, `do_rcn`, `ec_ruc`, `eg_tin`, `es_cif`, `et_tin`, `eu_oss_vat`, `eu_vat`, `fo_vat`, `gb_vat`, `ge_vat`, `gi_tin`, `gn_nif`, `hk_br`, `hr_oib`, `hu_tin`, `id_npwp`, `il_vat`, `in_gst`, `is_vat`, `it_cf`, `jp_cn`, `jp_rn`, `jp_trn`, `ke_pin`, `kg_tin`, `kh_tin`, `kr_brn`, `kz_bin`, `la_tin`, `li_uid`, `li_vat`, `lk_vat`, `ma_vat`, `md_vat`, `me_pib`, `mk_vat`, `mr_nif`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `ng_tin`, `no_vat`, `no_voec`, `np_pan`, `nz_gst`, `om_vat`, `pe_ruc`, `ph_tin`, `pl_nip`, `py_ruc`, `ro_tin`, `rs_pib`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `si_tin`, `sn_ninea`, `sr_fin`, `sv_nit`, `th_vat`, `tj_tin`, `tr_tin`, `tw_vat`, `tz_vat`, `ua_vat`, `ug_tin`, `us_ein`, `uy_ruc`, `uz_tin`, `uz_vat`, `ve_rif`, `vn_tin`, `za_vat`, `zm_tin`, or `zw_tin`</summary>
        [<Config.Form>]Type: Create'CustomerDetailsTaxIdsType option
        ///<summary>Value of the tax ID.</summary>
        [<Config.Form>]Value: string option
    }
    with
        static member New(?type': Create'CustomerDetailsTaxIdsType, ?value: string) =
            {
                Type = type'
                Value = value
            }

    type Create'CustomerDetailsAddressSource =
    | Billing
    | Shipping

    type Create'CustomerDetailsTaxabilityOverride =
    | CustomerExempt
    | None'
    | ReverseCharge

    type Create'CustomerDetails = {
        ///<summary>The customer's postal address (for example, home or business location).</summary>
        [<Config.Form>]Address: Create'CustomerDetailsAddress option
        ///<summary>The type of customer address provided.</summary>
        [<Config.Form>]AddressSource: Create'CustomerDetailsAddressSource option
        ///<summary>The customer's IP address (IPv4 or IPv6).</summary>
        [<Config.Form>]IpAddress: string option
        ///<summary>The customer's tax IDs. Stripe Tax might consider a transaction with applicable tax IDs to be B2B, which might affect the tax calculation result. Stripe Tax doesn't validate tax IDs for correctness.</summary>
        [<Config.Form>]TaxIds: Create'CustomerDetailsTaxIds list option
        ///<summary>Overrides the tax calculation result to allow you to not collect tax from your customer. Use this if you've manually checked your customer's tax exemptions. Prefer providing the customer's `tax_ids` where possible, which automatically determines whether `reverse_charge` applies.</summary>
        [<Config.Form>]TaxabilityOverride: Create'CustomerDetailsTaxabilityOverride option
    }
    with
        static member New(?address: Create'CustomerDetailsAddress, ?addressSource: Create'CustomerDetailsAddressSource, ?ipAddress: string, ?taxIds: Create'CustomerDetailsTaxIds list, ?taxabilityOverride: Create'CustomerDetailsTaxabilityOverride) =
            {
                Address = address
                AddressSource = addressSource
                IpAddress = ipAddress
                TaxIds = taxIds
                TaxabilityOverride = taxabilityOverride
            }

    type Create'LineItemsTaxBehavior =
    | Exclusive
    | Inclusive

    type Create'LineItems = {
        ///<summary>A positive integer representing the line item's total price in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units).
        ///If `tax_behavior=inclusive`, then this amount includes taxes. Otherwise, taxes are calculated on top of this amount.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>If provided, the product's `tax_code` will be used as the line item's `tax_code`.</summary>
        [<Config.Form>]Product: string option
        ///<summary>The number of units of the item being purchased. Used to calculate the per-unit price from the total `amount` for the line. For example, if `amount=100` and `quantity=4`, the calculated unit price is 25.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>A custom identifier for this line item, which must be unique across the line items in the calculation. The reference helps identify each line item in exported [tax reports](https://docs.stripe.com/tax/reports).</summary>
        [<Config.Form>]Reference: string option
        ///<summary>Specifies whether the `amount` includes taxes. Defaults to `exclusive`.</summary>
        [<Config.Form>]TaxBehavior: Create'LineItemsTaxBehavior option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID to use for this line item. If not provided, we will use the tax code from the provided `product` param. If neither `tax_code` nor `product` is provided, we will use the default tax code from your Tax Settings.</summary>
        [<Config.Form>]TaxCode: string option
    }
    with
        static member New(?amount: int, ?metadata: Map<string, string>, ?product: string, ?quantity: int, ?reference: string, ?taxBehavior: Create'LineItemsTaxBehavior, ?taxCode: string) =
            {
                Amount = amount
                Metadata = metadata
                Product = product
                Quantity = quantity
                Reference = reference
                TaxBehavior = taxBehavior
                TaxCode = taxCode
            }

    type Create'ShipFromDetailsAddress = {
        ///<summary>City, district, suburb, town, or village.</summary>
        [<Config.Form>]City: Choice<string,string> option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>Address line 1, such as the street, PO Box, or company name.</summary>
        [<Config.Form>]Line1: Choice<string,string> option
        ///<summary>Address line 2, such as the apartment, suite, unit, or building.</summary>
        [<Config.Form>]Line2: Choice<string,string> option
        ///<summary>ZIP or postal code.</summary>
        [<Config.Form>]PostalCode: Choice<string,string> option
        ///<summary>State/province as an [ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2) subdivision code, without country prefix, such as "NY" or "TX".</summary>
        [<Config.Form>]State: Choice<string,string> option
    }
    with
        static member New(?city: Choice<string,string>, ?country: IsoTypes.IsoCountryCode, ?line1: Choice<string,string>, ?line2: Choice<string,string>, ?postalCode: Choice<string,string>, ?state: Choice<string,string>) =
            {
                City = city
                Country = country
                Line1 = line1
                Line2 = line2
                PostalCode = postalCode
                State = state
            }

    type Create'ShipFromDetails = {
        ///<summary>The address from which the goods are being shipped from.</summary>
        [<Config.Form>]Address: Create'ShipFromDetailsAddress option
    }
    with
        static member New(?address: Create'ShipFromDetailsAddress) =
            {
                Address = address
            }

    type Create'ShippingCostTaxBehavior =
    | Exclusive
    | Inclusive

    type Create'ShippingCost = {
        ///<summary>A positive integer in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units) representing the shipping charge. If `tax_behavior=inclusive`, then this amount includes taxes. Otherwise, taxes are calculated on top of this amount.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>If provided, the [shipping rate](https://docs.stripe.com/api/shipping_rates/object)'s `amount`, `tax_code` and `tax_behavior` are used. If you provide a shipping rate, then you cannot pass the `amount`, `tax_code`, or `tax_behavior` parameters.</summary>
        [<Config.Form>]ShippingRate: string option
        ///<summary>Specifies whether the `amount` includes taxes. If `tax_behavior=inclusive`, then the amount includes taxes. Defaults to `exclusive`.</summary>
        [<Config.Form>]TaxBehavior: Create'ShippingCostTaxBehavior option
        ///<summary>The [tax code](https://docs.stripe.com/tax/tax-categories) used to calculate tax on shipping. If not provided, the default shipping tax code from your [Tax Settings](https://dashboard.stripe.com/settings/tax) is used.</summary>
        [<Config.Form>]TaxCode: string option
    }
    with
        static member New(?amount: int, ?shippingRate: string, ?taxBehavior: Create'ShippingCostTaxBehavior, ?taxCode: string) =
            {
                Amount = amount
                ShippingRate = shippingRate
                TaxBehavior = taxBehavior
                TaxCode = taxCode
            }

    type CreateOptions = {
        ///<summary>Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).</summary>
        [<Config.Form>]Currency: IsoTypes.IsoCurrencyCode
        ///<summary>The ID of an existing customer to use for this calculation. If provided, the customer's address and tax IDs are copied to `customer_details`.</summary>
        [<Config.Form>]Customer: string option
        ///<summary>Details about the customer, including address and tax IDs.</summary>
        [<Config.Form>]CustomerDetails: Create'CustomerDetails option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A list of items the customer is purchasing.</summary>
        [<Config.Form>]LineItems: Create'LineItems list
        ///<summary>Details about the address from which the goods are being shipped.</summary>
        [<Config.Form>]ShipFromDetails: Create'ShipFromDetails option
        ///<summary>Shipping cost details to be used for the calculation.</summary>
        [<Config.Form>]ShippingCost: Create'ShippingCost option
        ///<summary>Timestamp of date at which the tax rules and rates in effect applies for the calculation. Measured in seconds since the Unix epoch. Can be up to 48 hours in the past, and up to 48 hours in the future.</summary>
        [<Config.Form>]TaxDate: int option
    }
    with
        static member New(currency: IsoTypes.IsoCurrencyCode, lineItems: Create'LineItems list, ?customer: string, ?customerDetails: Create'CustomerDetails, ?expand: string list, ?shipFromDetails: Create'ShipFromDetails, ?shippingCost: Create'ShippingCost, ?taxDate: int) =
            {
                Currency = currency
                Customer = customer
                CustomerDetails = customerDetails
                Expand = expand
                LineItems = lineItems
                ShipFromDetails = shipFromDetails
                ShippingCost = shippingCost
                TaxDate = taxDate
            }

    ///<summary><p>Calculates tax based on the input and returns a Tax <code>Calculation</code> object.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/tax/calculations"
        |> RestApi.postAsync<_, TaxCalculation> settings (Map.empty) options

    type RetrieveOptions = {
        [<Config.Path>]Calculation: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(calculation: string, ?expand: string list) =
            {
                Calculation = calculation
                Expand = expand
            }

    ///<summary><p>Retrieves a Tax <code>Calculation</code> object, if the calculation hasn’t expired.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax/calculations/{options.Calculation}"
        |> RestApi.getAsync<TaxCalculation> settings qs

module TaxCalculationsLineItems =

    type ListLineItemsOptions = {
        [<Config.Path>]Calculation: string
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
        static member New(calculation: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                Calculation = calculation
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Retrieves the line items of a tax calculation as a collection, if the calculation hasn’t expired.</p></summary>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax/calculations/{options.Calculation}/line_items"
        |> RestApi.getAsync<StripeList<TaxCalculationLineItem>> settings qs

module TaxRegistrations =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        ///<summary>The status of the Tax Registration.</summary>
        [<Config.Query>]Status: string option
    }
    with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string, ?status: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Status = status
            }

    ///<summary><p>Returns a list of Tax <code>Registration</code> objects.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("status", options.Status |> box)] |> Map.ofList
        $"/v1/tax/registrations"
        |> RestApi.getAsync<StripeList<TaxRegistration>> settings qs

    type Create'ActiveFrom =
    | Now

    type Create'CountryOptionsAeStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsAeStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsAeStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsAeStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsAeType =
    | Standard

    type Create'CountryOptionsAe = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsAeStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsAeType option
    }
    with
        static member New(?standard: Create'CountryOptionsAeStandard, ?type': Create'CountryOptionsAeType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsAlStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsAlStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsAlStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsAlStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsAlType =
    | Standard

    type Create'CountryOptionsAl = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsAlStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsAlType option
    }
    with
        static member New(?standard: Create'CountryOptionsAlStandard, ?type': Create'CountryOptionsAlType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsAmType =
    | Simplified

    type Create'CountryOptionsAm = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsAmType option
    }
    with
        static member New(?type': Create'CountryOptionsAmType) =
            {
                Type = type'
            }

    type Create'CountryOptionsAoStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsAoStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsAoStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsAoStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsAoType =
    | Standard

    type Create'CountryOptionsAo = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsAoStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsAoType option
    }
    with
        static member New(?standard: Create'CountryOptionsAoStandard, ?type': Create'CountryOptionsAoType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsAtStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsAtStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsAtStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsAtStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsAtType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsAt = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsAtStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsAtType option
    }
    with
        static member New(?standard: Create'CountryOptionsAtStandard, ?type': Create'CountryOptionsAtType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsAuStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsAuStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsAuStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsAuStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsAuType =
    | Standard

    type Create'CountryOptionsAu = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsAuStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsAuType option
    }
    with
        static member New(?standard: Create'CountryOptionsAuStandard, ?type': Create'CountryOptionsAuType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsAwStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsAwStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsAwStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsAwStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsAwType =
    | Standard

    type Create'CountryOptionsAw = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsAwStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsAwType option
    }
    with
        static member New(?standard: Create'CountryOptionsAwStandard, ?type': Create'CountryOptionsAwType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsAzType =
    | Simplified

    type Create'CountryOptionsAz = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsAzType option
    }
    with
        static member New(?type': Create'CountryOptionsAzType) =
            {
                Type = type'
            }

    type Create'CountryOptionsBaStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsBaStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsBaStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBaStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBaType =
    | Standard

    type Create'CountryOptionsBa = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsBaStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsBaType option
    }
    with
        static member New(?standard: Create'CountryOptionsBaStandard, ?type': Create'CountryOptionsBaType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsBbStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsBbStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsBbStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBbStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBbType =
    | Standard

    type Create'CountryOptionsBb = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsBbStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsBbType option
    }
    with
        static member New(?standard: Create'CountryOptionsBbStandard, ?type': Create'CountryOptionsBbType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsBdStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsBdStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsBdStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBdStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBdType =
    | Standard

    type Create'CountryOptionsBd = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsBdStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsBdType option
    }
    with
        static member New(?standard: Create'CountryOptionsBdStandard, ?type': Create'CountryOptionsBdType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsBeStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsBeStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsBeStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBeStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBeType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsBe = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsBeStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsBeType option
    }
    with
        static member New(?standard: Create'CountryOptionsBeStandard, ?type': Create'CountryOptionsBeType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsBfStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsBfStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsBfStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBfStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBfType =
    | Standard

    type Create'CountryOptionsBf = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsBfStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsBfType option
    }
    with
        static member New(?standard: Create'CountryOptionsBfStandard, ?type': Create'CountryOptionsBfType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsBgStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsBgStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsBgStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBgStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBgType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsBg = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsBgStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsBgType option
    }
    with
        static member New(?standard: Create'CountryOptionsBgStandard, ?type': Create'CountryOptionsBgType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsBhStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsBhStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsBhStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBhStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBhType =
    | Standard

    type Create'CountryOptionsBh = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsBhStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsBhType option
    }
    with
        static member New(?standard: Create'CountryOptionsBhStandard, ?type': Create'CountryOptionsBhType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsBjType =
    | Simplified

    type Create'CountryOptionsBj = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsBjType option
    }
    with
        static member New(?type': Create'CountryOptionsBjType) =
            {
                Type = type'
            }

    type Create'CountryOptionsBsStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsBsStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsBsStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsBsStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsBsType =
    | Standard

    type Create'CountryOptionsBs = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsBsStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsBsType option
    }
    with
        static member New(?standard: Create'CountryOptionsBsStandard, ?type': Create'CountryOptionsBsType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsByType =
    | Simplified

    type Create'CountryOptionsBy = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsByType option
    }
    with
        static member New(?type': Create'CountryOptionsByType) =
            {
                Type = type'
            }

    type Create'CountryOptionsCaProvinceStandard = {
        ///<summary>Two-letter CA province code ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]Province: string option
    }
    with
        static member New(?province: string) =
            {
                Province = province
            }

    type Create'CountryOptionsCaType =
    | ProvinceStandard
    | Simplified
    | Standard

    type Create'CountryOptionsCa = {
        ///<summary>Options for the provincial tax registration.</summary>
        [<Config.Form>]ProvinceStandard: Create'CountryOptionsCaProvinceStandard option
        ///<summary>Type of registration to be created in Canada.</summary>
        [<Config.Form>]Type: Create'CountryOptionsCaType option
    }
    with
        static member New(?provinceStandard: Create'CountryOptionsCaProvinceStandard, ?type': Create'CountryOptionsCaType) =
            {
                ProvinceStandard = provinceStandard
                Type = type'
            }

    type Create'CountryOptionsCdStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsCdStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsCdStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsCdStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsCdType =
    | Standard

    type Create'CountryOptionsCd = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsCdStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsCdType option
    }
    with
        static member New(?standard: Create'CountryOptionsCdStandard, ?type': Create'CountryOptionsCdType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsChStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsChStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsChStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsChStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsChType =
    | Standard

    type Create'CountryOptionsCh = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsChStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsChType option
    }
    with
        static member New(?standard: Create'CountryOptionsChStandard, ?type': Create'CountryOptionsChType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsClType =
    | Simplified

    type Create'CountryOptionsCl = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsClType option
    }
    with
        static member New(?type': Create'CountryOptionsClType) =
            {
                Type = type'
            }

    type Create'CountryOptionsCmType =
    | Simplified

    type Create'CountryOptionsCm = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsCmType option
    }
    with
        static member New(?type': Create'CountryOptionsCmType) =
            {
                Type = type'
            }

    type Create'CountryOptionsCoType =
    | Simplified

    type Create'CountryOptionsCo = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsCoType option
    }
    with
        static member New(?type': Create'CountryOptionsCoType) =
            {
                Type = type'
            }

    type Create'CountryOptionsCrType =
    | Simplified

    type Create'CountryOptionsCr = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsCrType option
    }
    with
        static member New(?type': Create'CountryOptionsCrType) =
            {
                Type = type'
            }

    type Create'CountryOptionsCvType =
    | Simplified

    type Create'CountryOptionsCv = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsCvType option
    }
    with
        static member New(?type': Create'CountryOptionsCvType) =
            {
                Type = type'
            }

    type Create'CountryOptionsCyStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsCyStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsCyStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsCyStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsCyType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsCy = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsCyStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsCyType option
    }
    with
        static member New(?standard: Create'CountryOptionsCyStandard, ?type': Create'CountryOptionsCyType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsCzStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsCzStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsCzStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsCzStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsCzType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsCz = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsCzStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsCzType option
    }
    with
        static member New(?standard: Create'CountryOptionsCzStandard, ?type': Create'CountryOptionsCzType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsDeStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsDeStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsDeStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsDeStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsDeType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsDe = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsDeStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsDeType option
    }
    with
        static member New(?standard: Create'CountryOptionsDeStandard, ?type': Create'CountryOptionsDeType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsDkStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsDkStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsDkStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsDkStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsDkType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsDk = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsDkStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsDkType option
    }
    with
        static member New(?standard: Create'CountryOptionsDkStandard, ?type': Create'CountryOptionsDkType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsEcType =
    | Simplified

    type Create'CountryOptionsEc = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsEcType option
    }
    with
        static member New(?type': Create'CountryOptionsEcType) =
            {
                Type = type'
            }

    type Create'CountryOptionsEeStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsEeStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsEeStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsEeStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsEeType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsEe = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsEeStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsEeType option
    }
    with
        static member New(?standard: Create'CountryOptionsEeStandard, ?type': Create'CountryOptionsEeType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsEgType =
    | Simplified

    type Create'CountryOptionsEg = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsEgType option
    }
    with
        static member New(?type': Create'CountryOptionsEgType) =
            {
                Type = type'
            }

    type Create'CountryOptionsEsStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsEsStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsEsStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsEsStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsEsType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsEs = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsEsStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsEsType option
    }
    with
        static member New(?standard: Create'CountryOptionsEsStandard, ?type': Create'CountryOptionsEsType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsEtStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsEtStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsEtStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsEtStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsEtType =
    | Standard

    type Create'CountryOptionsEt = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsEtStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsEtType option
    }
    with
        static member New(?standard: Create'CountryOptionsEtStandard, ?type': Create'CountryOptionsEtType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsFiStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsFiStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsFiStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsFiStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsFiType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsFi = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsFiStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsFiType option
    }
    with
        static member New(?standard: Create'CountryOptionsFiStandard, ?type': Create'CountryOptionsFiType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsFrStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsFrStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsFrStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsFrStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsFrType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsFr = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsFrStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsFrType option
    }
    with
        static member New(?standard: Create'CountryOptionsFrStandard, ?type': Create'CountryOptionsFrType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsGbStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsGbStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsGbStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsGbStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsGbType =
    | Standard

    type Create'CountryOptionsGb = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsGbStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsGbType option
    }
    with
        static member New(?standard: Create'CountryOptionsGbStandard, ?type': Create'CountryOptionsGbType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsGeType =
    | Simplified

    type Create'CountryOptionsGe = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsGeType option
    }
    with
        static member New(?type': Create'CountryOptionsGeType) =
            {
                Type = type'
            }

    type Create'CountryOptionsGnStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsGnStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsGnStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsGnStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsGnType =
    | Standard

    type Create'CountryOptionsGn = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsGnStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsGnType option
    }
    with
        static member New(?standard: Create'CountryOptionsGnStandard, ?type': Create'CountryOptionsGnType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsGrStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsGrStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsGrStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsGrStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsGrType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsGr = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsGrStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsGrType option
    }
    with
        static member New(?standard: Create'CountryOptionsGrStandard, ?type': Create'CountryOptionsGrType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsHrStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsHrStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsHrStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsHrStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsHrType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsHr = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsHrStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsHrType option
    }
    with
        static member New(?standard: Create'CountryOptionsHrStandard, ?type': Create'CountryOptionsHrType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsHuStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsHuStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsHuStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsHuStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsHuType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsHu = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsHuStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsHuType option
    }
    with
        static member New(?standard: Create'CountryOptionsHuStandard, ?type': Create'CountryOptionsHuType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsIdType =
    | Simplified

    type Create'CountryOptionsId = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsIdType option
    }
    with
        static member New(?type': Create'CountryOptionsIdType) =
            {
                Type = type'
            }

    type Create'CountryOptionsIeStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsIeStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsIeStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsIeStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsIeType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsIe = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsIeStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsIeType option
    }
    with
        static member New(?standard: Create'CountryOptionsIeStandard, ?type': Create'CountryOptionsIeType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsInType =
    | Simplified

    type Create'CountryOptionsIn = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsInType option
    }
    with
        static member New(?type': Create'CountryOptionsInType) =
            {
                Type = type'
            }

    type Create'CountryOptionsIsStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsIsStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsIsStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsIsStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsIsType =
    | Standard

    type Create'CountryOptionsIs = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsIsStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsIsType option
    }
    with
        static member New(?standard: Create'CountryOptionsIsStandard, ?type': Create'CountryOptionsIsType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsItStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsItStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsItStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsItStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsItType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsIt = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsItStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsItType option
    }
    with
        static member New(?standard: Create'CountryOptionsItStandard, ?type': Create'CountryOptionsItType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsJpStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsJpStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsJpStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsJpStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsJpType =
    | Standard

    type Create'CountryOptionsJp = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsJpStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsJpType option
    }
    with
        static member New(?standard: Create'CountryOptionsJpStandard, ?type': Create'CountryOptionsJpType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsKeType =
    | Simplified

    type Create'CountryOptionsKe = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsKeType option
    }
    with
        static member New(?type': Create'CountryOptionsKeType) =
            {
                Type = type'
            }

    type Create'CountryOptionsKgType =
    | Simplified

    type Create'CountryOptionsKg = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsKgType option
    }
    with
        static member New(?type': Create'CountryOptionsKgType) =
            {
                Type = type'
            }

    type Create'CountryOptionsKhType =
    | Simplified

    type Create'CountryOptionsKh = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsKhType option
    }
    with
        static member New(?type': Create'CountryOptionsKhType) =
            {
                Type = type'
            }

    type Create'CountryOptionsKrType =
    | Simplified

    type Create'CountryOptionsKr = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsKrType option
    }
    with
        static member New(?type': Create'CountryOptionsKrType) =
            {
                Type = type'
            }

    type Create'CountryOptionsKzType =
    | Simplified

    type Create'CountryOptionsKz = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsKzType option
    }
    with
        static member New(?type': Create'CountryOptionsKzType) =
            {
                Type = type'
            }

    type Create'CountryOptionsLaType =
    | Simplified

    type Create'CountryOptionsLa = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsLaType option
    }
    with
        static member New(?type': Create'CountryOptionsLaType) =
            {
                Type = type'
            }

    type Create'CountryOptionsLkType =
    | Simplified

    type Create'CountryOptionsLk = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsLkType option
    }
    with
        static member New(?type': Create'CountryOptionsLkType) =
            {
                Type = type'
            }

    type Create'CountryOptionsLtStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsLtStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsLtStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsLtStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsLtType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsLt = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsLtStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsLtType option
    }
    with
        static member New(?standard: Create'CountryOptionsLtStandard, ?type': Create'CountryOptionsLtType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsLuStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsLuStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsLuStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsLuStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsLuType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsLu = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsLuStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsLuType option
    }
    with
        static member New(?standard: Create'CountryOptionsLuStandard, ?type': Create'CountryOptionsLuType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsLvStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsLvStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsLvStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsLvStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsLvType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsLv = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsLvStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsLvType option
    }
    with
        static member New(?standard: Create'CountryOptionsLvStandard, ?type': Create'CountryOptionsLvType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsMaType =
    | Simplified

    type Create'CountryOptionsMa = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsMaType option
    }
    with
        static member New(?type': Create'CountryOptionsMaType) =
            {
                Type = type'
            }

    type Create'CountryOptionsMdType =
    | Simplified

    type Create'CountryOptionsMd = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsMdType option
    }
    with
        static member New(?type': Create'CountryOptionsMdType) =
            {
                Type = type'
            }

    type Create'CountryOptionsMeStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsMeStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsMeStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsMeStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsMeType =
    | Standard

    type Create'CountryOptionsMe = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsMeStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsMeType option
    }
    with
        static member New(?standard: Create'CountryOptionsMeStandard, ?type': Create'CountryOptionsMeType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsMkStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsMkStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsMkStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsMkStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsMkType =
    | Standard

    type Create'CountryOptionsMk = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsMkStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsMkType option
    }
    with
        static member New(?standard: Create'CountryOptionsMkStandard, ?type': Create'CountryOptionsMkType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsMrStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsMrStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsMrStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsMrStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsMrType =
    | Standard

    type Create'CountryOptionsMr = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsMrStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsMrType option
    }
    with
        static member New(?standard: Create'CountryOptionsMrStandard, ?type': Create'CountryOptionsMrType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsMtStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsMtStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsMtStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsMtStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsMtType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsMt = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsMtStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsMtType option
    }
    with
        static member New(?standard: Create'CountryOptionsMtStandard, ?type': Create'CountryOptionsMtType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsMxType =
    | Simplified

    type Create'CountryOptionsMx = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsMxType option
    }
    with
        static member New(?type': Create'CountryOptionsMxType) =
            {
                Type = type'
            }

    type Create'CountryOptionsMyType =
    | Simplified

    type Create'CountryOptionsMy = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsMyType option
    }
    with
        static member New(?type': Create'CountryOptionsMyType) =
            {
                Type = type'
            }

    type Create'CountryOptionsNgType =
    | Simplified

    type Create'CountryOptionsNg = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsNgType option
    }
    with
        static member New(?type': Create'CountryOptionsNgType) =
            {
                Type = type'
            }

    type Create'CountryOptionsNlStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsNlStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsNlStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsNlStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsNlType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsNl = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsNlStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsNlType option
    }
    with
        static member New(?standard: Create'CountryOptionsNlStandard, ?type': Create'CountryOptionsNlType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsNoStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsNoStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsNoStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsNoStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsNoType =
    | Standard

    type Create'CountryOptionsNo = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsNoStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsNoType option
    }
    with
        static member New(?standard: Create'CountryOptionsNoStandard, ?type': Create'CountryOptionsNoType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsNpType =
    | Simplified

    type Create'CountryOptionsNp = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsNpType option
    }
    with
        static member New(?type': Create'CountryOptionsNpType) =
            {
                Type = type'
            }

    type Create'CountryOptionsNzStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsNzStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsNzStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsNzStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsNzType =
    | Standard

    type Create'CountryOptionsNz = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsNzStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsNzType option
    }
    with
        static member New(?standard: Create'CountryOptionsNzStandard, ?type': Create'CountryOptionsNzType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsOmStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsOmStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsOmStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsOmStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsOmType =
    | Standard

    type Create'CountryOptionsOm = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsOmStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsOmType option
    }
    with
        static member New(?standard: Create'CountryOptionsOmStandard, ?type': Create'CountryOptionsOmType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsPeType =
    | Simplified

    type Create'CountryOptionsPe = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsPeType option
    }
    with
        static member New(?type': Create'CountryOptionsPeType) =
            {
                Type = type'
            }

    type Create'CountryOptionsPhType =
    | Simplified

    type Create'CountryOptionsPh = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsPhType option
    }
    with
        static member New(?type': Create'CountryOptionsPhType) =
            {
                Type = type'
            }

    type Create'CountryOptionsPlStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsPlStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsPlStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsPlStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsPlType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsPl = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsPlStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsPlType option
    }
    with
        static member New(?standard: Create'CountryOptionsPlStandard, ?type': Create'CountryOptionsPlType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsPtStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsPtStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsPtStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsPtStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsPtType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsPt = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsPtStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsPtType option
    }
    with
        static member New(?standard: Create'CountryOptionsPtStandard, ?type': Create'CountryOptionsPtType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsRoStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsRoStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsRoStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsRoStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsRoType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsRo = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsRoStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsRoType option
    }
    with
        static member New(?standard: Create'CountryOptionsRoStandard, ?type': Create'CountryOptionsRoType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsRsStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsRsStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsRsStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsRsStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsRsType =
    | Standard

    type Create'CountryOptionsRs = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsRsStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsRsType option
    }
    with
        static member New(?standard: Create'CountryOptionsRsStandard, ?type': Create'CountryOptionsRsType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsRuType =
    | Simplified

    type Create'CountryOptionsRu = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsRuType option
    }
    with
        static member New(?type': Create'CountryOptionsRuType) =
            {
                Type = type'
            }

    type Create'CountryOptionsSaType =
    | Simplified

    type Create'CountryOptionsSa = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsSaType option
    }
    with
        static member New(?type': Create'CountryOptionsSaType) =
            {
                Type = type'
            }

    type Create'CountryOptionsSeStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsSeStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsSeStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsSeStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsSeType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsSe = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsSeStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsSeType option
    }
    with
        static member New(?standard: Create'CountryOptionsSeStandard, ?type': Create'CountryOptionsSeType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsSgStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsSgStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsSgStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsSgStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsSgType =
    | Standard

    type Create'CountryOptionsSg = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsSgStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsSgType option
    }
    with
        static member New(?standard: Create'CountryOptionsSgStandard, ?type': Create'CountryOptionsSgType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsSiStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsSiStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsSiStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsSiStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsSiType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsSi = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsSiStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsSiType option
    }
    with
        static member New(?standard: Create'CountryOptionsSiStandard, ?type': Create'CountryOptionsSiType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsSkStandardPlaceOfSupplyScheme =
    | InboundGoods
    | SmallSeller
    | Standard

    type Create'CountryOptionsSkStandard = {
        ///<summary>Place of supply scheme used in an EU standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsSkStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsSkStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsSkType =
    | Ioss
    | OssNonUnion
    | OssUnion
    | Standard

    type Create'CountryOptionsSk = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsSkStandard option
        ///<summary>Type of registration to be created in an EU country.</summary>
        [<Config.Form>]Type: Create'CountryOptionsSkType option
    }
    with
        static member New(?standard: Create'CountryOptionsSkStandard, ?type': Create'CountryOptionsSkType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsSnType =
    | Simplified

    type Create'CountryOptionsSn = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsSnType option
    }
    with
        static member New(?type': Create'CountryOptionsSnType) =
            {
                Type = type'
            }

    type Create'CountryOptionsSrStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsSrStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsSrStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsSrStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsSrType =
    | Standard

    type Create'CountryOptionsSr = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsSrStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsSrType option
    }
    with
        static member New(?standard: Create'CountryOptionsSrStandard, ?type': Create'CountryOptionsSrType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsThType =
    | Simplified

    type Create'CountryOptionsTh = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsThType option
    }
    with
        static member New(?type': Create'CountryOptionsThType) =
            {
                Type = type'
            }

    type Create'CountryOptionsTjType =
    | Simplified

    type Create'CountryOptionsTj = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsTjType option
    }
    with
        static member New(?type': Create'CountryOptionsTjType) =
            {
                Type = type'
            }

    type Create'CountryOptionsTrType =
    | Simplified

    type Create'CountryOptionsTr = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsTrType option
    }
    with
        static member New(?type': Create'CountryOptionsTrType) =
            {
                Type = type'
            }

    type Create'CountryOptionsTwType =
    | Simplified

    type Create'CountryOptionsTw = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsTwType option
    }
    with
        static member New(?type': Create'CountryOptionsTwType) =
            {
                Type = type'
            }

    type Create'CountryOptionsTzType =
    | Simplified

    type Create'CountryOptionsTz = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsTzType option
    }
    with
        static member New(?type': Create'CountryOptionsTzType) =
            {
                Type = type'
            }

    type Create'CountryOptionsUaType =
    | Simplified

    type Create'CountryOptionsUa = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsUaType option
    }
    with
        static member New(?type': Create'CountryOptionsUaType) =
            {
                Type = type'
            }

    type Create'CountryOptionsUgType =
    | Simplified

    type Create'CountryOptionsUg = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsUgType option
    }
    with
        static member New(?type': Create'CountryOptionsUgType) =
            {
                Type = type'
            }

    type Create'CountryOptionsUsLocalAmusementTax = {
        ///<summary>A jurisdiction code representing the [local jurisdiction](/tax/registering?type=amusement_tax#registration-types).</summary>
        [<Config.Form>]Jurisdiction: string option
    }
    with
        static member New(?jurisdiction: string) =
            {
                Jurisdiction = jurisdiction
            }

    type Create'CountryOptionsUsLocalLeaseTax = {
        ///<summary>A [FIPS code](https://www.census.gov/library/reference/code-lists/ansi.html) representing the local jurisdiction. Supported FIPS codes are: `14000` (Chicago).</summary>
        [<Config.Form>]Jurisdiction: string option
    }
    with
        static member New(?jurisdiction: string) =
            {
                Jurisdiction = jurisdiction
            }

    type Create'CountryOptionsUsStateSalesTaxElectionsType =
    | LocalUseTax
    | SimplifiedSellersUseTax
    | SingleLocalUseTax

    type Create'CountryOptionsUsStateSalesTaxElections = {
        ///<summary>A [FIPS code](https://www.census.gov/library/reference/code-lists/ansi.html) representing the local jurisdiction. Supported FIPS codes are: `003` (Allegheny County) and `60000` (Philadelphia City).</summary>
        [<Config.Form>]Jurisdiction: string option
        ///<summary>The type of the election for the state sales tax registration.</summary>
        [<Config.Form>]Type: Create'CountryOptionsUsStateSalesTaxElectionsType option
    }
    with
        static member New(?jurisdiction: string, ?type': Create'CountryOptionsUsStateSalesTaxElectionsType) =
            {
                Jurisdiction = jurisdiction
                Type = type'
            }

    type Create'CountryOptionsUsStateSalesTax = {
        ///<summary>Elections for the state sales tax registration.</summary>
        [<Config.Form>]Elections: Create'CountryOptionsUsStateSalesTaxElections list option
    }
    with
        static member New(?elections: Create'CountryOptionsUsStateSalesTaxElections list) =
            {
                Elections = elections
            }

    type Create'CountryOptionsUsType =
    | LocalAmusementTax
    | LocalLeaseTax
    | StateCommunicationsTax
    | StateRetailDeliveryFee
    | StateSalesTax

    type Create'CountryOptionsUs = {
        ///<summary>Options for the local amusement tax registration.</summary>
        [<Config.Form>]LocalAmusementTax: Create'CountryOptionsUsLocalAmusementTax option
        ///<summary>Options for the local lease tax registration.</summary>
        [<Config.Form>]LocalLeaseTax: Create'CountryOptionsUsLocalLeaseTax option
        ///<summary>Two-letter US state code ([ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2)).</summary>
        [<Config.Form>]State: string option
        ///<summary>Options for the state sales tax registration.</summary>
        [<Config.Form>]StateSalesTax: Create'CountryOptionsUsStateSalesTax option
        ///<summary>Type of registration to be created in the US.</summary>
        [<Config.Form>]Type: Create'CountryOptionsUsType option
    }
    with
        static member New(?localAmusementTax: Create'CountryOptionsUsLocalAmusementTax, ?localLeaseTax: Create'CountryOptionsUsLocalLeaseTax, ?state: string, ?stateSalesTax: Create'CountryOptionsUsStateSalesTax, ?type': Create'CountryOptionsUsType) =
            {
                LocalAmusementTax = localAmusementTax
                LocalLeaseTax = localLeaseTax
                State = state
                StateSalesTax = stateSalesTax
                Type = type'
            }

    type Create'CountryOptionsUyStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsUyStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsUyStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsUyStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsUyType =
    | Standard

    type Create'CountryOptionsUy = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsUyStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsUyType option
    }
    with
        static member New(?standard: Create'CountryOptionsUyStandard, ?type': Create'CountryOptionsUyType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsUzType =
    | Simplified

    type Create'CountryOptionsUz = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsUzType option
    }
    with
        static member New(?type': Create'CountryOptionsUzType) =
            {
                Type = type'
            }

    type Create'CountryOptionsVnType =
    | Simplified

    type Create'CountryOptionsVn = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsVnType option
    }
    with
        static member New(?type': Create'CountryOptionsVnType) =
            {
                Type = type'
            }

    type Create'CountryOptionsZaStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsZaStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsZaStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsZaStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsZaType =
    | Standard

    type Create'CountryOptionsZa = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsZaStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsZaType option
    }
    with
        static member New(?standard: Create'CountryOptionsZaStandard, ?type': Create'CountryOptionsZaType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptionsZmType =
    | Simplified

    type Create'CountryOptionsZm = {
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsZmType option
    }
    with
        static member New(?type': Create'CountryOptionsZmType) =
            {
                Type = type'
            }

    type Create'CountryOptionsZwStandardPlaceOfSupplyScheme =
    | InboundGoods
    | Standard

    type Create'CountryOptionsZwStandard = {
        ///<summary>Place of supply scheme used in an standard registration.</summary>
        [<Config.Form>]PlaceOfSupplyScheme: Create'CountryOptionsZwStandardPlaceOfSupplyScheme option
    }
    with
        static member New(?placeOfSupplyScheme: Create'CountryOptionsZwStandardPlaceOfSupplyScheme) =
            {
                PlaceOfSupplyScheme = placeOfSupplyScheme
            }

    type Create'CountryOptionsZwType =
    | Standard

    type Create'CountryOptionsZw = {
        ///<summary>Options for the standard registration.</summary>
        [<Config.Form>]Standard: Create'CountryOptionsZwStandard option
        ///<summary>Type of registration to be created in `country`.</summary>
        [<Config.Form>]Type: Create'CountryOptionsZwType option
    }
    with
        static member New(?standard: Create'CountryOptionsZwStandard, ?type': Create'CountryOptionsZwType) =
            {
                Standard = standard
                Type = type'
            }

    type Create'CountryOptions = {
        ///<summary>Options for the registration in AE.</summary>
        [<Config.Form>]Ae: Create'CountryOptionsAe option
        ///<summary>Options for the registration in AL.</summary>
        [<Config.Form>]Al: Create'CountryOptionsAl option
        ///<summary>Options for the registration in AM.</summary>
        [<Config.Form>]Am: Create'CountryOptionsAm option
        ///<summary>Options for the registration in AO.</summary>
        [<Config.Form>]Ao: Create'CountryOptionsAo option
        ///<summary>Options for the registration in AT.</summary>
        [<Config.Form>]At: Create'CountryOptionsAt option
        ///<summary>Options for the registration in AU.</summary>
        [<Config.Form>]Au: Create'CountryOptionsAu option
        ///<summary>Options for the registration in AW.</summary>
        [<Config.Form>]Aw: Create'CountryOptionsAw option
        ///<summary>Options for the registration in AZ.</summary>
        [<Config.Form>]Az: Create'CountryOptionsAz option
        ///<summary>Options for the registration in BA.</summary>
        [<Config.Form>]Ba: Create'CountryOptionsBa option
        ///<summary>Options for the registration in BB.</summary>
        [<Config.Form>]Bb: Create'CountryOptionsBb option
        ///<summary>Options for the registration in BD.</summary>
        [<Config.Form>]Bd: Create'CountryOptionsBd option
        ///<summary>Options for the registration in BE.</summary>
        [<Config.Form>]Be: Create'CountryOptionsBe option
        ///<summary>Options for the registration in BF.</summary>
        [<Config.Form>]Bf: Create'CountryOptionsBf option
        ///<summary>Options for the registration in BG.</summary>
        [<Config.Form>]Bg: Create'CountryOptionsBg option
        ///<summary>Options for the registration in BH.</summary>
        [<Config.Form>]Bh: Create'CountryOptionsBh option
        ///<summary>Options for the registration in BJ.</summary>
        [<Config.Form>]Bj: Create'CountryOptionsBj option
        ///<summary>Options for the registration in BS.</summary>
        [<Config.Form>]Bs: Create'CountryOptionsBs option
        ///<summary>Options for the registration in BY.</summary>
        [<Config.Form>]By: Create'CountryOptionsBy option
        ///<summary>Options for the registration in CA.</summary>
        [<Config.Form>]Ca: Create'CountryOptionsCa option
        ///<summary>Options for the registration in CD.</summary>
        [<Config.Form>]Cd: Create'CountryOptionsCd option
        ///<summary>Options for the registration in CH.</summary>
        [<Config.Form>]Ch: Create'CountryOptionsCh option
        ///<summary>Options for the registration in CL.</summary>
        [<Config.Form>]Cl: Create'CountryOptionsCl option
        ///<summary>Options for the registration in CM.</summary>
        [<Config.Form>]Cm: Create'CountryOptionsCm option
        ///<summary>Options for the registration in CO.</summary>
        [<Config.Form>]Co: Create'CountryOptionsCo option
        ///<summary>Options for the registration in CR.</summary>
        [<Config.Form>]Cr: Create'CountryOptionsCr option
        ///<summary>Options for the registration in CV.</summary>
        [<Config.Form>]Cv: Create'CountryOptionsCv option
        ///<summary>Options for the registration in CY.</summary>
        [<Config.Form>]Cy: Create'CountryOptionsCy option
        ///<summary>Options for the registration in CZ.</summary>
        [<Config.Form>]Cz: Create'CountryOptionsCz option
        ///<summary>Options for the registration in DE.</summary>
        [<Config.Form>]De: Create'CountryOptionsDe option
        ///<summary>Options for the registration in DK.</summary>
        [<Config.Form>]Dk: Create'CountryOptionsDk option
        ///<summary>Options for the registration in EC.</summary>
        [<Config.Form>]Ec: Create'CountryOptionsEc option
        ///<summary>Options for the registration in EE.</summary>
        [<Config.Form>]Ee: Create'CountryOptionsEe option
        ///<summary>Options for the registration in EG.</summary>
        [<Config.Form>]Eg: Create'CountryOptionsEg option
        ///<summary>Options for the registration in ES.</summary>
        [<Config.Form>]Es: Create'CountryOptionsEs option
        ///<summary>Options for the registration in ET.</summary>
        [<Config.Form>]Et: Create'CountryOptionsEt option
        ///<summary>Options for the registration in FI.</summary>
        [<Config.Form>]Fi: Create'CountryOptionsFi option
        ///<summary>Options for the registration in FR.</summary>
        [<Config.Form>]Fr: Create'CountryOptionsFr option
        ///<summary>Options for the registration in GB.</summary>
        [<Config.Form>]Gb: Create'CountryOptionsGb option
        ///<summary>Options for the registration in GE.</summary>
        [<Config.Form>]Ge: Create'CountryOptionsGe option
        ///<summary>Options for the registration in GN.</summary>
        [<Config.Form>]Gn: Create'CountryOptionsGn option
        ///<summary>Options for the registration in GR.</summary>
        [<Config.Form>]Gr: Create'CountryOptionsGr option
        ///<summary>Options for the registration in HR.</summary>
        [<Config.Form>]Hr: Create'CountryOptionsHr option
        ///<summary>Options for the registration in HU.</summary>
        [<Config.Form>]Hu: Create'CountryOptionsHu option
        ///<summary>Options for the registration in ID.</summary>
        [<Config.Form>]Id: Create'CountryOptionsId option
        ///<summary>Options for the registration in IE.</summary>
        [<Config.Form>]Ie: Create'CountryOptionsIe option
        ///<summary>Options for the registration in IN.</summary>
        [<Config.Form>]In: Create'CountryOptionsIn option
        ///<summary>Options for the registration in IS.</summary>
        [<Config.Form>]Is: Create'CountryOptionsIs option
        ///<summary>Options for the registration in IT.</summary>
        [<Config.Form>]It: Create'CountryOptionsIt option
        ///<summary>Options for the registration in JP.</summary>
        [<Config.Form>]Jp: Create'CountryOptionsJp option
        ///<summary>Options for the registration in KE.</summary>
        [<Config.Form>]Ke: Create'CountryOptionsKe option
        ///<summary>Options for the registration in KG.</summary>
        [<Config.Form>]Kg: Create'CountryOptionsKg option
        ///<summary>Options for the registration in KH.</summary>
        [<Config.Form>]Kh: Create'CountryOptionsKh option
        ///<summary>Options for the registration in KR.</summary>
        [<Config.Form>]Kr: Create'CountryOptionsKr option
        ///<summary>Options for the registration in KZ.</summary>
        [<Config.Form>]Kz: Create'CountryOptionsKz option
        ///<summary>Options for the registration in LA.</summary>
        [<Config.Form>]La: Create'CountryOptionsLa option
        ///<summary>Options for the registration in LK.</summary>
        [<Config.Form>]Lk: Create'CountryOptionsLk option
        ///<summary>Options for the registration in LT.</summary>
        [<Config.Form>]Lt: Create'CountryOptionsLt option
        ///<summary>Options for the registration in LU.</summary>
        [<Config.Form>]Lu: Create'CountryOptionsLu option
        ///<summary>Options for the registration in LV.</summary>
        [<Config.Form>]Lv: Create'CountryOptionsLv option
        ///<summary>Options for the registration in MA.</summary>
        [<Config.Form>]Ma: Create'CountryOptionsMa option
        ///<summary>Options for the registration in MD.</summary>
        [<Config.Form>]Md: Create'CountryOptionsMd option
        ///<summary>Options for the registration in ME.</summary>
        [<Config.Form>]Me: Create'CountryOptionsMe option
        ///<summary>Options for the registration in MK.</summary>
        [<Config.Form>]Mk: Create'CountryOptionsMk option
        ///<summary>Options for the registration in MR.</summary>
        [<Config.Form>]Mr: Create'CountryOptionsMr option
        ///<summary>Options for the registration in MT.</summary>
        [<Config.Form>]Mt: Create'CountryOptionsMt option
        ///<summary>Options for the registration in MX.</summary>
        [<Config.Form>]Mx: Create'CountryOptionsMx option
        ///<summary>Options for the registration in MY.</summary>
        [<Config.Form>]My: Create'CountryOptionsMy option
        ///<summary>Options for the registration in NG.</summary>
        [<Config.Form>]Ng: Create'CountryOptionsNg option
        ///<summary>Options for the registration in NL.</summary>
        [<Config.Form>]Nl: Create'CountryOptionsNl option
        ///<summary>Options for the registration in NO.</summary>
        [<Config.Form>]No: Create'CountryOptionsNo option
        ///<summary>Options for the registration in NP.</summary>
        [<Config.Form>]Np: Create'CountryOptionsNp option
        ///<summary>Options for the registration in NZ.</summary>
        [<Config.Form>]Nz: Create'CountryOptionsNz option
        ///<summary>Options for the registration in OM.</summary>
        [<Config.Form>]Om: Create'CountryOptionsOm option
        ///<summary>Options for the registration in PE.</summary>
        [<Config.Form>]Pe: Create'CountryOptionsPe option
        ///<summary>Options for the registration in PH.</summary>
        [<Config.Form>]Ph: Create'CountryOptionsPh option
        ///<summary>Options for the registration in PL.</summary>
        [<Config.Form>]Pl: Create'CountryOptionsPl option
        ///<summary>Options for the registration in PT.</summary>
        [<Config.Form>]Pt: Create'CountryOptionsPt option
        ///<summary>Options for the registration in RO.</summary>
        [<Config.Form>]Ro: Create'CountryOptionsRo option
        ///<summary>Options for the registration in RS.</summary>
        [<Config.Form>]Rs: Create'CountryOptionsRs option
        ///<summary>Options for the registration in RU.</summary>
        [<Config.Form>]Ru: Create'CountryOptionsRu option
        ///<summary>Options for the registration in SA.</summary>
        [<Config.Form>]Sa: Create'CountryOptionsSa option
        ///<summary>Options for the registration in SE.</summary>
        [<Config.Form>]Se: Create'CountryOptionsSe option
        ///<summary>Options for the registration in SG.</summary>
        [<Config.Form>]Sg: Create'CountryOptionsSg option
        ///<summary>Options for the registration in SI.</summary>
        [<Config.Form>]Si: Create'CountryOptionsSi option
        ///<summary>Options for the registration in SK.</summary>
        [<Config.Form>]Sk: Create'CountryOptionsSk option
        ///<summary>Options for the registration in SN.</summary>
        [<Config.Form>]Sn: Create'CountryOptionsSn option
        ///<summary>Options for the registration in SR.</summary>
        [<Config.Form>]Sr: Create'CountryOptionsSr option
        ///<summary>Options for the registration in TH.</summary>
        [<Config.Form>]Th: Create'CountryOptionsTh option
        ///<summary>Options for the registration in TJ.</summary>
        [<Config.Form>]Tj: Create'CountryOptionsTj option
        ///<summary>Options for the registration in TR.</summary>
        [<Config.Form>]Tr: Create'CountryOptionsTr option
        ///<summary>Options for the registration in TW.</summary>
        [<Config.Form>]Tw: Create'CountryOptionsTw option
        ///<summary>Options for the registration in TZ.</summary>
        [<Config.Form>]Tz: Create'CountryOptionsTz option
        ///<summary>Options for the registration in UA.</summary>
        [<Config.Form>]Ua: Create'CountryOptionsUa option
        ///<summary>Options for the registration in UG.</summary>
        [<Config.Form>]Ug: Create'CountryOptionsUg option
        ///<summary>Options for the registration in US.</summary>
        [<Config.Form>]Us: Create'CountryOptionsUs option
        ///<summary>Options for the registration in UY.</summary>
        [<Config.Form>]Uy: Create'CountryOptionsUy option
        ///<summary>Options for the registration in UZ.</summary>
        [<Config.Form>]Uz: Create'CountryOptionsUz option
        ///<summary>Options for the registration in VN.</summary>
        [<Config.Form>]Vn: Create'CountryOptionsVn option
        ///<summary>Options for the registration in ZA.</summary>
        [<Config.Form>]Za: Create'CountryOptionsZa option
        ///<summary>Options for the registration in ZM.</summary>
        [<Config.Form>]Zm: Create'CountryOptionsZm option
        ///<summary>Options for the registration in ZW.</summary>
        [<Config.Form>]Zw: Create'CountryOptionsZw option
    }
    with
        static member New(?ae: Create'CountryOptionsAe, ?om: Create'CountryOptionsOm, ?nz: Create'CountryOptionsNz, ?np: Create'CountryOptionsNp, ?no: Create'CountryOptionsNo, ?nl: Create'CountryOptionsNl, ?ng: Create'CountryOptionsNg, ?my: Create'CountryOptionsMy, ?mx: Create'CountryOptionsMx, ?mt: Create'CountryOptionsMt, ?mr: Create'CountryOptionsMr, ?mk: Create'CountryOptionsMk, ?me: Create'CountryOptionsMe, ?md: Create'CountryOptionsMd, ?ma: Create'CountryOptionsMa, ?lv: Create'CountryOptionsLv, ?lu: Create'CountryOptionsLu, ?lt: Create'CountryOptionsLt, ?lk: Create'CountryOptionsLk, ?la: Create'CountryOptionsLa, ?kz: Create'CountryOptionsKz, ?kr: Create'CountryOptionsKr, ?pe: Create'CountryOptionsPe, ?ph: Create'CountryOptionsPh, ?pl: Create'CountryOptionsPl, ?pt: Create'CountryOptionsPt, ?za: Create'CountryOptionsZa, ?vn: Create'CountryOptionsVn, ?uz: Create'CountryOptionsUz, ?uy: Create'CountryOptionsUy, ?us: Create'CountryOptionsUs, ?ug: Create'CountryOptionsUg, ?ua: Create'CountryOptionsUa, ?tz: Create'CountryOptionsTz, ?tw: Create'CountryOptionsTw, ?tr: Create'CountryOptionsTr, ?kh: Create'CountryOptionsKh, ?tj: Create'CountryOptionsTj, ?sr: Create'CountryOptionsSr, ?sn: Create'CountryOptionsSn, ?sk: Create'CountryOptionsSk, ?si: Create'CountryOptionsSi, ?sg: Create'CountryOptionsSg, ?se: Create'CountryOptionsSe, ?sa: Create'CountryOptionsSa, ?ru: Create'CountryOptionsRu, ?rs: Create'CountryOptionsRs, ?ro: Create'CountryOptionsRo, ?th: Create'CountryOptionsTh, ?zm: Create'CountryOptionsZm, ?kg: Create'CountryOptionsKg, ?jp: Create'CountryOptionsJp, ?cl: Create'CountryOptionsCl, ?ch: Create'CountryOptionsCh, ?cd: Create'CountryOptionsCd, ?ca: Create'CountryOptionsCa, ?by: Create'CountryOptionsBy, ?bs: Create'CountryOptionsBs, ?bj: Create'CountryOptionsBj, ?bh: Create'CountryOptionsBh, ?bg: Create'CountryOptionsBg, ?bf: Create'CountryOptionsBf, ?be: Create'CountryOptionsBe, ?bd: Create'CountryOptionsBd, ?bb: Create'CountryOptionsBb, ?ba: Create'CountryOptionsBa, ?az: Create'CountryOptionsAz, ?aw: Create'CountryOptionsAw, ?au: Create'CountryOptionsAu, ?at: Create'CountryOptionsAt, ?ao: Create'CountryOptionsAo, ?am: Create'CountryOptionsAm, ?al: Create'CountryOptionsAl, ?cm: Create'CountryOptionsCm, ?co: Create'CountryOptionsCo, ?cr: Create'CountryOptionsCr, ?cv: Create'CountryOptionsCv, ?it: Create'CountryOptionsIt, ?is: Create'CountryOptionsIs, ?in': Create'CountryOptionsIn, ?ie: Create'CountryOptionsIe, ?id: Create'CountryOptionsId, ?hu: Create'CountryOptionsHu, ?hr: Create'CountryOptionsHr, ?gr: Create'CountryOptionsGr, ?gn: Create'CountryOptionsGn, ?ge: Create'CountryOptionsGe, ?ke: Create'CountryOptionsKe, ?gb: Create'CountryOptionsGb, ?fi: Create'CountryOptionsFi, ?et: Create'CountryOptionsEt, ?es: Create'CountryOptionsEs, ?eg: Create'CountryOptionsEg, ?ee: Create'CountryOptionsEe, ?ec: Create'CountryOptionsEc, ?dk: Create'CountryOptionsDk, ?de: Create'CountryOptionsDe, ?cz: Create'CountryOptionsCz, ?cy: Create'CountryOptionsCy, ?fr: Create'CountryOptionsFr, ?zw: Create'CountryOptionsZw) =
            {
                Ae = ae
                Al = al
                Am = am
                Ao = ao
                At = at
                Au = au
                Aw = aw
                Az = az
                Ba = ba
                Bb = bb
                Bd = bd
                Be = be
                Bf = bf
                Bg = bg
                Bh = bh
                Bj = bj
                Bs = bs
                By = by
                Ca = ca
                Cd = cd
                Ch = ch
                Cl = cl
                Cm = cm
                Co = co
                Cr = cr
                Cv = cv
                Cy = cy
                Cz = cz
                De = de
                Dk = dk
                Ec = ec
                Ee = ee
                Eg = eg
                Es = es
                Et = et
                Fi = fi
                Fr = fr
                Gb = gb
                Ge = ge
                Gn = gn
                Gr = gr
                Hr = hr
                Hu = hu
                Id = id
                Ie = ie
                In = in'
                Is = is
                It = it
                Jp = jp
                Ke = ke
                Kg = kg
                Kh = kh
                Kr = kr
                Kz = kz
                La = la
                Lk = lk
                Lt = lt
                Lu = lu
                Lv = lv
                Ma = ma
                Md = md
                Me = me
                Mk = mk
                Mr = mr
                Mt = mt
                Mx = mx
                My = my
                Ng = ng
                Nl = nl
                No = no
                Np = np
                Nz = nz
                Om = om
                Pe = pe
                Ph = ph
                Pl = pl
                Pt = pt
                Ro = ro
                Rs = rs
                Ru = ru
                Sa = sa
                Se = se
                Sg = sg
                Si = si
                Sk = sk
                Sn = sn
                Sr = sr
                Th = th
                Tj = tj
                Tr = tr
                Tw = tw
                Tz = tz
                Ua = ua
                Ug = ug
                Us = us
                Uy = uy
                Uz = uz
                Vn = vn
                Za = za
                Zm = zm
                Zw = zw
            }

    type CreateOptions = {
        ///<summary>Time at which the Tax Registration becomes active. It can be either `now` to indicate the current time, or a future timestamp measured in seconds since the Unix epoch.</summary>
        [<Config.Form>]ActiveFrom: Choice<Create'ActiveFrom,DateTime>
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode
        ///<summary>Specific options for a registration in the specified `country`.</summary>
        [<Config.Form>]CountryOptions: Create'CountryOptions
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>If set, the Tax Registration stops being active at this time. If not set, the Tax Registration will be active indefinitely. Timestamp measured in seconds since the Unix epoch.</summary>
        [<Config.Form>]ExpiresAt: DateTime option
    }
    with
        static member New(activeFrom: Choice<Create'ActiveFrom,DateTime>, country: IsoTypes.IsoCountryCode, countryOptions: Create'CountryOptions, ?expand: string list, ?expiresAt: DateTime) =
            {
                ActiveFrom = activeFrom
                Country = country
                CountryOptions = countryOptions
                Expand = expand
                ExpiresAt = expiresAt
            }

    ///<summary><p>Creates a new Tax <code>Registration</code> object.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/tax/registrations"
        |> RestApi.postAsync<_, TaxRegistration> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Returns a Tax <code>Registration</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax/registrations/{options.Id}"
        |> RestApi.getAsync<TaxRegistration> settings qs

    type Update'ActiveFrom =
    | Now

    type Update'ExpiresAt =
    | Now

    type UpdateOptions = {
        [<Config.Path>]Id: string
        ///<summary>Time at which the registration becomes active. It can be either `now` to indicate the current time, or a timestamp measured in seconds since the Unix epoch.</summary>
        [<Config.Form>]ActiveFrom: Choice<Update'ActiveFrom,DateTime> option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>If set, the registration stops being active at this time. If not set, the registration will be active indefinitely. It can be either `now` to indicate the current time, or a timestamp measured in seconds since the Unix epoch.</summary>
        [<Config.Form>]ExpiresAt: Choice<Update'ExpiresAt,DateTime,string> option
    }
    with
        static member New(id: string, ?activeFrom: Choice<Update'ActiveFrom,DateTime>, ?expand: string list, ?expiresAt: Choice<Update'ExpiresAt,DateTime,string>) =
            {
                Id = id
                ActiveFrom = activeFrom
                Expand = expand
                ExpiresAt = expiresAt
            }

    ///<summary><p>Updates an existing Tax <code>Registration</code> object.</p>
    ///<p>A registration cannot be deleted after it has been created. If you wish to end a registration you may do so by setting <code>expires_at</code>.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/tax/registrations/{options.Id}"
        |> RestApi.postAsync<_, TaxRegistration> settings (Map.empty) options

module TaxSettings =

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(?expand: string list) =
            {
                Expand = expand
            }

    ///<summary><p>Retrieves Tax <code>Settings</code> for a merchant.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax/settings"
        |> RestApi.getAsync<TaxSettings> settings qs

    type Update'DefaultsTaxBehavior =
    | Exclusive
    | Inclusive
    | InferredByCurrency

    type Update'Defaults = {
        ///<summary>Specifies the default [tax behavior](https://stripe.com/docs/tax/products-prices-tax-categories-tax-behavior#tax-behavior) to be used when the item's price has unspecified tax behavior. One of inclusive, exclusive, or inferred_by_currency. Once specified, it cannot be changed back to null.</summary>
        [<Config.Form>]TaxBehavior: Update'DefaultsTaxBehavior option
        ///<summary>A [tax code](https://docs.stripe.com/tax/tax-categories) ID.</summary>
        [<Config.Form>]TaxCode: string option
    }
    with
        static member New(?taxBehavior: Update'DefaultsTaxBehavior, ?taxCode: string) =
            {
                TaxBehavior = taxBehavior
                TaxCode = taxCode
            }

    type Update'HeadOfficeAddress = {
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
        ///<summary>State/province as an [ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2) subdivision code, without country prefix, such as "NY" or "TX".</summary>
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

    type Update'HeadOffice = {
        ///<summary>The location of the business for tax purposes.</summary>
        [<Config.Form>]Address: Update'HeadOfficeAddress option
    }
    with
        static member New(?address: Update'HeadOfficeAddress) =
            {
                Address = address
            }

    type UpdateOptions = {
        ///<summary>Default configuration to be used on Stripe Tax calculations.</summary>
        [<Config.Form>]Defaults: Update'Defaults option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The place where your business is located.</summary>
        [<Config.Form>]HeadOffice: Update'HeadOffice option
    }
    with
        static member New(?defaults: Update'Defaults, ?expand: string list, ?headOffice: Update'HeadOffice) =
            {
                Defaults = defaults
                Expand = expand
                HeadOffice = headOffice
            }

    ///<summary><p>Updates Tax <code>Settings</code> parameters used in tax calculations. All parameters are editable but none can be removed once set.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/tax/settings"
        |> RestApi.postAsync<_, TaxSettings> settings (Map.empty) options

module TaxTransactionsCreateFromCalculation =

    type CreateFromCalculationOptions = {
        ///<summary>Tax Calculation ID to be used as input when creating the transaction.</summary>
        [<Config.Form>]Calculation: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The Unix timestamp representing when the tax liability is assumed or reduced, which determines the liability posting period and handling in tax liability reports. The timestamp must fall within the `tax_date` and the current time, unless the `tax_date` is scheduled in advance. Defaults to the current time.</summary>
        [<Config.Form>]PostedAt: DateTime option
        ///<summary>A custom order or sale identifier, such as 'myOrder_123'. Must be unique across all transactions, including reversals.</summary>
        [<Config.Form>]Reference: string
    }
    with
        static member New(calculation: string, reference: string, ?expand: string list, ?metadata: Map<string, string>, ?postedAt: DateTime) =
            {
                Calculation = calculation
                Expand = expand
                Metadata = metadata
                PostedAt = postedAt
                Reference = reference
            }

    ///<summary><p>Creates a Tax Transaction from a calculation, if that calculation hasn’t expired. Calculations expire after 90 days.</p></summary>
    let CreateFromCalculation settings (options: CreateFromCalculationOptions) =
        $"/v1/tax/transactions/create_from_calculation"
        |> RestApi.postAsync<_, TaxTransaction> settings (Map.empty) options

module TaxTransactionsCreateReversal =

    type CreateReversal'LineItems = {
        ///<summary>The amount to reverse, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units) in negative.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>The amount of tax to reverse, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units) in negative.</summary>
        [<Config.Form>]AmountTax: int option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>The `id` of the line item to reverse in the original transaction.</summary>
        [<Config.Form>]OriginalLineItem: string option
        ///<summary>The quantity reversed. Appears in [tax exports](https://docs.stripe.com/tax/reports), but does not affect the amount of tax reversed.</summary>
        [<Config.Form>]Quantity: int option
        ///<summary>A custom identifier for this line item in the reversal transaction, such as 'L1-refund'.</summary>
        [<Config.Form>]Reference: string option
    }
    with
        static member New(?amount: int, ?amountTax: int, ?metadata: Map<string, string>, ?originalLineItem: string, ?quantity: int, ?reference: string) =
            {
                Amount = amount
                AmountTax = amountTax
                Metadata = metadata
                OriginalLineItem = originalLineItem
                Quantity = quantity
                Reference = reference
            }

    type CreateReversal'ShippingCost = {
        ///<summary>The amount to reverse, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units) in negative.</summary>
        [<Config.Form>]Amount: int option
        ///<summary>The amount of tax to reverse, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units) in negative.</summary>
        [<Config.Form>]AmountTax: int option
    }
    with
        static member New(?amount: int, ?amountTax: int) =
            {
                Amount = amount
                AmountTax = amountTax
            }

    type CreateReversal'Mode =
    | Full
    | Partial

    type CreateReversalOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>A flat amount to reverse across the entire transaction, in the [smallest currency unit](https://docs.stripe.com/currencies#minor-units) in negative. This value represents the total amount to refund from the transaction, including taxes.</summary>
        [<Config.Form>]FlatAmount: int option
        ///<summary>The line item amounts to reverse.</summary>
        [<Config.Form>]LineItems: CreateReversal'LineItems list option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>If `partial`, the provided line item or shipping cost amounts are reversed. If `full`, the original transaction is fully reversed.</summary>
        [<Config.Form>]Mode: CreateReversal'Mode
        ///<summary>The ID of the Transaction to partially or fully reverse.</summary>
        [<Config.Form>]OriginalTransaction: string
        ///<summary>A custom identifier for this reversal, such as `myOrder_123-refund_1`, which must be unique across all transactions. The reference helps identify this reversal transaction in exported [tax reports](https://docs.stripe.com/tax/reports).</summary>
        [<Config.Form>]Reference: string
        ///<summary>The shipping cost to reverse.</summary>
        [<Config.Form>]ShippingCost: CreateReversal'ShippingCost option
    }
    with
        static member New(mode: CreateReversal'Mode, originalTransaction: string, reference: string, ?expand: string list, ?flatAmount: int, ?lineItems: CreateReversal'LineItems list, ?metadata: Map<string, string>, ?shippingCost: CreateReversal'ShippingCost) =
            {
                Expand = expand
                FlatAmount = flatAmount
                LineItems = lineItems
                Metadata = metadata
                Mode = mode
                OriginalTransaction = originalTransaction
                Reference = reference
                ShippingCost = shippingCost
            }

    ///<summary><p>Partially or fully reverses a previously created <code>Transaction</code>.</p></summary>
    let CreateReversal settings (options: CreateReversalOptions) =
        $"/v1/tax/transactions/create_reversal"
        |> RestApi.postAsync<_, TaxTransaction> settings (Map.empty) options

module TaxTransactions =

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Transaction: string
    }
    with
        static member New(transaction: string, ?expand: string list) =
            {
                Expand = expand
                Transaction = transaction
            }

    ///<summary><p>Retrieves a Tax <code>Transaction</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax/transactions/{options.Transaction}"
        |> RestApi.getAsync<TaxTransaction> settings qs

module TaxTransactionsLineItems =

    type ListLineItemsOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
        [<Config.Path>]Transaction: string
    }
    with
        static member New(transaction: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
                Transaction = transaction
            }

    ///<summary><p>Retrieves the line items of a committed standalone transaction as a collection.</p></summary>
    let ListLineItems settings (options: ListLineItemsOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax/transactions/{options.Transaction}/line_items"
        |> RestApi.getAsync<StripeList<TaxTransactionLineItem>> settings qs

module TaxCodes =

    type ListOptions = {
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
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>A list of <a href="https://stripe.com/docs/tax/tax-categories">all tax codes available</a> to add to Products in order to allow specific tax calculations.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax_codes"
        |> RestApi.getAsync<StripeList<TaxCode>> settings qs

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves the details of an existing tax code. Supply the unique tax code ID and Stripe will return the corresponding tax code information.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax_codes/{options.Id}"
        |> RestApi.getAsync<TaxCode> settings qs

module TaxIds =

    type ListOptions = {
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>The account or customer the tax ID belongs to. Defaults to `owner[type]=self`.</summary>
        [<Config.Query>]Owner: Map<string, string> option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?endingBefore: string, ?expand: string list, ?limit: int, ?owner: Map<string, string>, ?startingAfter: string) =
            {
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                Owner = owner
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of tax IDs.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("owner", options.Owner |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax_ids"
        |> RestApi.getAsync<StripeList<TaxId>> settings qs

    type Create'OwnerType =
    | Account
    | Application
    | Customer
    | Self

    type Create'Owner = {
        ///<summary>Connected Account the tax ID belongs to. Required when `type=account`</summary>
        [<Config.Form>]Account: string option
        ///<summary>Customer the tax ID belongs to. Required when `type=customer`</summary>
        [<Config.Form>]Customer: string option
        ///<summary>ID of the Account representing the customer that the tax ID belongs to. Can be used in place of `customer` when `type=customer`</summary>
        [<Config.Form>]CustomerAccount: string option
        ///<summary>Type of owner referenced.</summary>
        [<Config.Form>]Type: Create'OwnerType option
    }
    with
        static member New(?account: string, ?customer: string, ?customerAccount: string, ?type': Create'OwnerType) =
            {
                Account = account
                Customer = customer
                CustomerAccount = customerAccount
                Type = type'
            }

    type Create'Type =
    | AdNrt
    | AeTrn
    | AlTin
    | AmTin
    | AoTin
    | ArCuit
    | AuAbn
    | AuArn
    | AwTin
    | AzTin
    | BaTin
    | BbTin
    | BdBin
    | BfIfu
    | BgUic
    | BhVat
    | BjIfu
    | BoTin
    | BrCnpj
    | BrCpf
    | BsTin
    | ByTin
    | CaBn
    | CaGstHst
    | CaPstBc
    | CaPstMb
    | CaPstSk
    | CaQst
    | CdNif
    | ChUid
    | ChVat
    | ClTin
    | CmNiu
    | CnTin
    | CoNit
    | CrTin
    | CvNif
    | DeStn
    | DoRcn
    | EcRuc
    | EgTin
    | EsCif
    | EtTin
    | EuOssVat
    | EuVat
    | FoVat
    | GbVat
    | GeVat
    | GiTin
    | GnNif
    | HkBr
    | HrOib
    | HuTin
    | IdNpwp
    | IlVat
    | InGst
    | IsVat
    | ItCf
    | JpCn
    | JpRn
    | JpTrn
    | KePin
    | KgTin
    | KhTin
    | KrBrn
    | KzBin
    | LaTin
    | LiUid
    | LiVat
    | LkVat
    | MaVat
    | MdVat
    | MePib
    | MkVat
    | MrNif
    | MxRfc
    | MyFrp
    | MyItn
    | MySst
    | NgTin
    | NoVat
    | NoVoec
    | NpPan
    | NzGst
    | OmVat
    | PeRuc
    | PhTin
    | PlNip
    | PyRuc
    | RoTin
    | RsPib
    | RuInn
    | RuKpp
    | SaVat
    | SgGst
    | SgUen
    | SiTin
    | SnNinea
    | SrFin
    | SvNit
    | ThVat
    | TjTin
    | TrTin
    | TwVat
    | TzVat
    | UaVat
    | UgTin
    | UsEin
    | UyRuc
    | UzTin
    | UzVat
    | VeRif
    | VnTin
    | ZaVat
    | ZmTin
    | ZwTin

    type CreateOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The account or customer the tax ID belongs to. Defaults to `owner[type]=self`.</summary>
        [<Config.Form>]Owner: Create'Owner option
        ///<summary>Type of the tax ID, one of `ad_nrt`, `ae_trn`, `al_tin`, `am_tin`, `ao_tin`, `ar_cuit`, `au_abn`, `au_arn`, `aw_tin`, `az_tin`, `ba_tin`, `bb_tin`, `bd_bin`, `bf_ifu`, `bg_uic`, `bh_vat`, `bj_ifu`, `bo_tin`, `br_cnpj`, `br_cpf`, `bs_tin`, `by_tin`, `ca_bn`, `ca_gst_hst`, `ca_pst_bc`, `ca_pst_mb`, `ca_pst_sk`, `ca_qst`, `cd_nif`, `ch_uid`, `ch_vat`, `cl_tin`, `cm_niu`, `cn_tin`, `co_nit`, `cr_tin`, `cv_nif`, `de_stn`, `do_rcn`, `ec_ruc`, `eg_tin`, `es_cif`, `et_tin`, `eu_oss_vat`, `eu_vat`, `fo_vat`, `gb_vat`, `ge_vat`, `gi_tin`, `gn_nif`, `hk_br`, `hr_oib`, `hu_tin`, `id_npwp`, `il_vat`, `in_gst`, `is_vat`, `it_cf`, `jp_cn`, `jp_rn`, `jp_trn`, `ke_pin`, `kg_tin`, `kh_tin`, `kr_brn`, `kz_bin`, `la_tin`, `li_uid`, `li_vat`, `lk_vat`, `ma_vat`, `md_vat`, `me_pib`, `mk_vat`, `mr_nif`, `mx_rfc`, `my_frp`, `my_itn`, `my_sst`, `ng_tin`, `no_vat`, `no_voec`, `np_pan`, `nz_gst`, `om_vat`, `pe_ruc`, `ph_tin`, `pl_nip`, `py_ruc`, `ro_tin`, `rs_pib`, `ru_inn`, `ru_kpp`, `sa_vat`, `sg_gst`, `sg_uen`, `si_tin`, `sn_ninea`, `sr_fin`, `sv_nit`, `th_vat`, `tj_tin`, `tr_tin`, `tw_vat`, `tz_vat`, `ua_vat`, `ug_tin`, `us_ein`, `uy_ruc`, `uz_tin`, `uz_vat`, `ve_rif`, `vn_tin`, `za_vat`, `zm_tin`, or `zw_tin`</summary>
        [<Config.Form>]Type: Create'Type
        ///<summary>Value of the tax ID.</summary>
        [<Config.Form>]Value: string
    }
    with
        static member New(type': Create'Type, value: string, ?expand: string list, ?owner: Create'Owner) =
            {
                Expand = expand
                Owner = owner
                Type = type'
                Value = value
            }

    ///<summary><p>Creates a new account or customer <code>tax_id</code> object.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/tax_ids"
        |> RestApi.postAsync<_, TaxId> settings (Map.empty) options

    type DeleteOptions = {
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string) =
            {
                Id = id
            }

    ///<summary><p>Deletes an existing account or customer <code>tax_id</code> object.</p></summary>
    let Delete settings (options: DeleteOptions) =
        $"/v1/tax_ids/{options.Id}"
        |> RestApi.deleteAsync<DeletedTaxId> settings (Map.empty)

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Id: string
    }
    with
        static member New(id: string, ?expand: string list) =
            {
                Expand = expand
                Id = id
            }

    ///<summary><p>Retrieves an account or customer <code>tax_id</code> object.</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax_ids/{options.Id}"
        |> RestApi.getAsync<TaxId> settings qs

module TaxRates =

    type ListOptions = {
        ///<summary>Optional flag to filter by tax rates that are either active or inactive (archived).</summary>
        [<Config.Query>]Active: bool option
        ///<summary>Optional range for filtering created date.</summary>
        [<Config.Query>]Created: int option
        ///<summary>A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.</summary>
        [<Config.Query>]EndingBefore: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        ///<summary>Optional flag to filter by tax rates that are inclusive (or those that are not inclusive).</summary>
        [<Config.Query>]Inclusive: bool option
        ///<summary>A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.</summary>
        [<Config.Query>]Limit: int option
        ///<summary>A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.</summary>
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?active: bool, ?created: int, ?endingBefore: string, ?expand: string list, ?inclusive: bool, ?limit: int, ?startingAfter: string) =
            {
                Active = active
                Created = created
                EndingBefore = endingBefore
                Expand = expand
                Inclusive = inclusive
                Limit = limit
                StartingAfter = startingAfter
            }

    ///<summary><p>Returns a list of your tax rates. Tax rates are returned sorted by creation date, with the most recently created tax rates appearing first.</p></summary>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("inclusive", options.Inclusive |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/tax_rates"
        |> RestApi.getAsync<StripeList<TaxRate>> settings qs

    type Create'TaxType =
    | AmusementTax
    | CommunicationsTax
    | Gst
    | Hst
    | Igst
    | Jct
    | LeaseTax
    | Pst
    | Qst
    | RetailDeliveryFee
    | Rst
    | SalesTax
    | ServiceTax
    | Vat

    type CreateOptions = {
        ///<summary>Flag determining whether the tax rate is active or inactive (archived). Inactive tax rates cannot be used with new applications or Checkout Sessions, but will still work for subscriptions and invoices that already have it set.</summary>
        [<Config.Form>]Active: bool option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.</summary>
        [<Config.Form>]Description: string option
        ///<summary>The display name of the tax rate, which will be shown to users.</summary>
        [<Config.Form>]DisplayName: string
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>This specifies if the tax rate is inclusive or exclusive.</summary>
        [<Config.Form>]Inclusive: bool
        ///<summary>The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.</summary>
        [<Config.Form>]Jurisdiction: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>This represents the tax rate percent out of 100.</summary>
        [<Config.Form>]Percentage: decimal
        ///<summary>[ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2), without country prefix. For example, "NY" for New York, United States.</summary>
        [<Config.Form>]State: string option
        ///<summary>The high-level tax type, such as `vat` or `sales_tax`.</summary>
        [<Config.Form>]TaxType: Create'TaxType option
    }
    with
        static member New(displayName: string, inclusive: bool, percentage: decimal, ?active: bool, ?country: IsoTypes.IsoCountryCode, ?description: string, ?expand: string list, ?jurisdiction: string, ?metadata: Map<string, string>, ?state: string, ?taxType: Create'TaxType) =
            {
                Active = active
                Country = country
                Description = description
                DisplayName = displayName
                Expand = expand
                Inclusive = inclusive
                Jurisdiction = jurisdiction
                Metadata = metadata
                Percentage = percentage
                State = state
                TaxType = taxType
            }

    ///<summary><p>Creates a new tax rate.</p></summary>
    let Create settings (options: CreateOptions) =
        $"/v1/tax_rates"
        |> RestApi.postAsync<_, TaxRate> settings (Map.empty) options

    type RetrieveOptions = {
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Query>]Expand: string list option
        [<Config.Path>]TaxRate: string
    }
    with
        static member New(taxRate: string, ?expand: string list) =
            {
                Expand = expand
                TaxRate = taxRate
            }

    ///<summary><p>Retrieves a tax rate with the given ID</p></summary>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/tax_rates/{options.TaxRate}"
        |> RestApi.getAsync<TaxRate> settings qs

    type Update'TaxType =
    | AmusementTax
    | CommunicationsTax
    | Gst
    | Hst
    | Igst
    | Jct
    | LeaseTax
    | Pst
    | Qst
    | RetailDeliveryFee
    | Rst
    | SalesTax
    | ServiceTax
    | Vat

    type UpdateOptions = {
        [<Config.Path>]TaxRate: string
        ///<summary>Flag determining whether the tax rate is active or inactive (archived). Inactive tax rates cannot be used with new applications or Checkout Sessions, but will still work for subscriptions and invoices that already have it set.</summary>
        [<Config.Form>]Active: bool option
        ///<summary>Two-letter country code ([ISO 3166-1 alpha-2](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)).</summary>
        [<Config.Form>]Country: IsoTypes.IsoCountryCode option
        ///<summary>An arbitrary string attached to the tax rate for your internal use only. It will not be visible to your customers.</summary>
        [<Config.Form>]Description: string option
        ///<summary>The display name of the tax rate, which will be shown to users.</summary>
        [<Config.Form>]DisplayName: string option
        ///<summary>Specifies which fields in the response should be expanded.</summary>
        [<Config.Form>]Expand: string list option
        ///<summary>The jurisdiction for the tax rate. You can use this label field for tax reporting purposes. It also appears on your customer’s invoice.</summary>
        [<Config.Form>]Jurisdiction: string option
        ///<summary>Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.</summary>
        [<Config.Form>]Metadata: Map<string, string> option
        ///<summary>[ISO 3166-2 subdivision code](https://en.wikipedia.org/wiki/ISO_3166-2), without country prefix. For example, "NY" for New York, United States.</summary>
        [<Config.Form>]State: string option
        ///<summary>The high-level tax type, such as `vat` or `sales_tax`.</summary>
        [<Config.Form>]TaxType: Update'TaxType option
    }
    with
        static member New(taxRate: string, ?active: bool, ?country: IsoTypes.IsoCountryCode, ?description: string, ?displayName: string, ?expand: string list, ?jurisdiction: string, ?metadata: Map<string, string>, ?state: string, ?taxType: Update'TaxType) =
            {
                TaxRate = taxRate
                Active = active
                Country = country
                Description = description
                DisplayName = displayName
                Expand = expand
                Jurisdiction = jurisdiction
                Metadata = metadata
                State = state
                TaxType = taxType
            }

    ///<summary><p>Updates an existing tax rate.</p></summary>
    let Update settings (options: UpdateOptions) =
        $"/v1/tax_rates/{options.TaxRate}"
        |> RestApi.postAsync<_, TaxRate> settings (Map.empty) options
