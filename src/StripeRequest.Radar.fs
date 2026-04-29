namespace FunStripe.StripeRequest

open FunStripe
open FunStripe.Json
open FunStripe.StripeModel
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module RadarEarlyFraudWarnings =

    type ListOptions = {
        ///Only return early fraud warnings for the charge specified by this charge ID.
        [<Config.Query>]Charge: string option
        ///A cursor for use in pagination. `ending_before` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with `obj_bar`, your subsequent call can include `ending_before=obj_bar` in order to fetch the previous page of the list.
        [<Config.Query>]EndingBefore: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        ///A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 10.
        [<Config.Query>]Limit: int option
        ///Only return early fraud warnings for charges that were created by the PaymentIntent specified by this PaymentIntent ID.
        [<Config.Query>]PaymentIntent: string option
        ///A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
        [<Config.Query>]StartingAfter: string option
    }
    with
        static member New(?charge: string, ?endingBefore: string, ?expand: string list, ?limit: int, ?paymentIntent: string, ?startingAfter: string) =
            {
                Charge = charge
                EndingBefore = endingBefore
                Expand = expand
                Limit = limit
                PaymentIntent = paymentIntent
                StartingAfter = startingAfter
            }

    ///<p>Returns a list of early fraud warnings.</p>
    let List settings (options: ListOptions) =
        let qs = [("charge", options.Charge |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("payment_intent", options.PaymentIntent |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/radar/early_fraud_warnings"
        |> RestApi.getAsync<RadarEarlyFraudWarning list> settings qs

    type RetrieveOptions = {
        [<Config.Path>]EarlyFraudWarning: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
    }
    with
        static member New(earlyFraudWarning: string, ?expand: string list) =
            {
                EarlyFraudWarning = earlyFraudWarning
                Expand = expand
            }

    ///<p>Retrieves the details of an early fraud warning that has previously been created. 
    ///Please refer to the <a href="#early_fraud_warning_object">early fraud warning</a> object reference for more details.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/radar/early_fraud_warnings/{options.EarlyFraudWarning}"
        |> RestApi.getAsync<RadarEarlyFraudWarning> settings qs

module RadarValueListItems =

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
        ///Return items belonging to the parent list whose value matches the specified value (using an "is like" match).
        [<Config.Query>]Value: string option
        ///Identifier for the parent value list this item belongs to.
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

    ///<p>Returns a list of <code>ValueListItem</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box); ("value", options.Value |> box); ("value_list", options.ValueList |> box)] |> Map.ofList
        $"/v1/radar/value_list_items"
        |> RestApi.getAsync<RadarValueListItem list> settings qs

    type CreateOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///The value of the item (whose type must match the type of the parent value list).
        [<Config.Form>]Value: string
        ///The identifier of the value list which the created item will be added to.
        [<Config.Form>]ValueList: string
    }
    with
        static member New(value: string, valueList: string, ?expand: string list) =
            {
                Expand = expand
                Value = value
                ValueList = valueList
            }

    ///<p>Creates a new <code>ValueListItem</code> object, which is added to the specified parent value list.</p>
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

    ///<p>Deletes a <code>ValueListItem</code> object, removing it from its parent value list.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/radar/value_list_items/{options.Item}"
        |> RestApi.deleteAsync<DeletedRadarValueListItem> settings (Map.empty)

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]Item: string
    }
    with
        static member New(item: string, ?expand: string list) =
            {
                Expand = expand
                Item = item
            }

    ///<p>Retrieves a <code>ValueListItem</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/radar/value_list_items/{options.Item}"
        |> RestApi.getAsync<RadarValueListItem> settings qs

module RadarValueLists =

    type ListOptions = {
        ///The alias used to reference the value list when writing rules.
        [<Config.Query>]Alias: string option
        ///A value contained within a value list - returns all value lists containing this value.
        [<Config.Query>]Contains: string option
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

    ///<p>Returns a list of <code>ValueList</code> objects. The objects are sorted in descending order by creation date, with the most recently created object appearing first.</p>
    let List settings (options: ListOptions) =
        let qs = [("alias", options.Alias |> box); ("contains", options.Contains |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/radar/value_lists"
        |> RestApi.getAsync<RadarValueList list> settings qs

    type Create'ItemType =
    | CardBin
    | CardFingerprint
    | CaseSensitiveString
    | Country
    | CustomerId
    | Email
    | IpAddress
    | SepaDebitFingerprint
    | String
    | UsBankAccountFingerprint

    type CreateOptions = {
        ///The name of the value list for use in rules.
        [<Config.Form>]Alias: string
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Type of the items in the value list. One of `card_fingerprint`, `us_bank_account_fingerprint`, `sepa_debit_fingerprint`, `card_bin`, `email`, `ip_address`, `country`, `string`, `case_sensitive_string`, or `customer_id`. Use `string` if the item type is unknown or mixed.
        [<Config.Form>]ItemType: Create'ItemType option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The human-readable name of the value list.
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

    ///<p>Creates a new <code>ValueList</code> object, which can then be referenced in rules.</p>
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

    ///<p>Deletes a <code>ValueList</code> object, also deleting any items contained within the value list. To be deleted, a value list must not be referenced in any rules.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/radar/value_lists/{options.ValueList}"
        |> RestApi.deleteAsync<DeletedRadarValueList> settings (Map.empty)

    type RetrieveOptions = {
        ///Specifies which fields in the response should be expanded.
        [<Config.Query>]Expand: string list option
        [<Config.Path>]ValueList: string
    }
    with
        static member New(valueList: string, ?expand: string list) =
            {
                Expand = expand
                ValueList = valueList
            }

    ///<p>Retrieves a <code>ValueList</code> object.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/radar/value_lists/{options.ValueList}"
        |> RestApi.getAsync<RadarValueList> settings qs

    type UpdateOptions = {
        [<Config.Path>]ValueList: string
        ///The name of the value list for use in rules.
        [<Config.Form>]Alias: string option
        ///Specifies which fields in the response should be expanded.
        [<Config.Form>]Expand: string list option
        ///Set of [key-value pairs](https://stripe.com/docs/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
        [<Config.Form>]Metadata: Map<string, string> option
        ///The human-readable name of the value list.
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

    ///<p>Updates a <code>ValueList</code> object by setting the values of the parameters passed. Any parameters not provided will be left unchanged. Note that <code>item_type</code> is immutable.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/radar/value_lists/{options.ValueList}"
        |> RestApi.postAsync<_, RadarValueList> settings (Map.empty) options
