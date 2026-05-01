namespace StripeRequest.Promotion

open FunStripe
open System.Text.Json.Serialization
open Stripe.PromotionCode
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
module PromotionCodes =

    type ListOptions =
        {
            /// Filter promotion codes by whether they are active.
            [<Config.Query>]
            Active: bool option
            /// Only return promotion codes that have this case-insensitive code.
            [<Config.Query>]
            Code: string option
            /// Only return promotion codes for this coupon.
            [<Config.Query>]
            Coupon: string option
            /// A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
            [<Config.Query>]
            Created: int option
            /// Only return promotion codes that are restricted to this customer.
            [<Config.Query>]
            Customer: string option
            /// Only return promotion codes that are restricted to this account representing the customer.
            [<Config.Query>]
            CustomerAccount: string option
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

    module ListOptions =
        let create
            (
                active: bool option,
                code: string option,
                coupon: string option,
                created: int option,
                customer: string option,
                customerAccount: string option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
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

    type Create'PromotionType = | Coupon

    type Create'Promotion =
        {
            /// If promotion `type` is `coupon`, the coupon for this promotion code.
            [<Config.Form>]
            Coupon: string option
            /// Specifies the type of promotion.
            [<Config.Form>]
            Type: Create'PromotionType option
        }

    type Create'Promotion with
        static member New(?coupon: string, ?type': Create'PromotionType) =
            {
                Coupon = coupon
                Type = type'
            }

    module Create'Promotion =
        let create
            (
                coupon: string option,
                type': Create'PromotionType option
            ) : Create'Promotion
            =
            {
              Coupon = coupon
              Type = type'
            }

    type Create'Restrictions =
        {
            /// Promotion codes defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            CurrencyOptions: Map<string, string> option
            /// A Boolean indicating if the Promotion Code should only be redeemed for Customers without any successful payments or invoices
            [<Config.Form>]
            FirstTimeTransaction: bool option
            /// Minimum amount required to redeem this Promotion Code into a Coupon (e.g., a purchase must be $100 or more to work).
            [<Config.Form>]
            MinimumAmount: int option
            /// Three-letter [ISO code](https://stripe.com/docs/currencies) for minimum_amount
            [<Config.Form>]
            MinimumAmountCurrency: IsoTypes.IsoCurrencyCode option
        }

    type Create'Restrictions with
        static member New(?currencyOptions: Map<string, string>, ?firstTimeTransaction: bool, ?minimumAmount: int, ?minimumAmountCurrency: IsoTypes.IsoCurrencyCode) =
            {
                CurrencyOptions = currencyOptions
                FirstTimeTransaction = firstTimeTransaction
                MinimumAmount = minimumAmount
                MinimumAmountCurrency = minimumAmountCurrency
            }

    module Create'Restrictions =
        let create
            (
                currencyOptions: Map<string, string> option,
                firstTimeTransaction: bool option,
                minimumAmount: int option,
                minimumAmountCurrency: IsoTypes.IsoCurrencyCode option
            ) : Create'Restrictions
            =
            {
              CurrencyOptions = currencyOptions
              FirstTimeTransaction = firstTimeTransaction
              MinimumAmount = minimumAmount
              MinimumAmountCurrency = minimumAmountCurrency
            }

    type CreateOptions =
        {
            /// Whether the promotion code is currently active.
            [<Config.Form>]
            Active: bool option
            /// The customer-facing code. Regardless of case, this code must be unique across all active promotion codes for a specific customer. Valid characters are lower case letters (a-z), upper case letters (A-Z), digits (0-9), and dashes (-).
            /// If left blank, we will generate one automatically.
            [<Config.Form>]
            Code: string option
            /// The customer who can use this promotion code. If not set, all customers can use the promotion code.
            [<Config.Form>]
            Customer: string option
            /// The account representing the customer who can use this promotion code. If not set, all customers can use the promotion code.
            [<Config.Form>]
            CustomerAccount: string option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// The timestamp at which this promotion code will expire. If the coupon has specified a `redeems_by`, then this value cannot be after the coupon's `redeems_by`.
            [<Config.Form>]
            ExpiresAt: DateTime option
            /// A positive integer specifying the number of times the promotion code can be redeemed. If the coupon has specified a `max_redemptions`, then this value cannot be greater than the coupon's `max_redemptions`.
            [<Config.Form>]
            MaxRedemptions: int option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The promotion referenced by this promotion code.
            [<Config.Form>]
            Promotion: Create'Promotion
            /// Settings that restrict the redemption of the promotion code.
            [<Config.Form>]
            Restrictions: Create'Restrictions option
        }

    type CreateOptions with
        static member New(promotion: Create'Promotion, ?active: bool, ?code: string, ?customer: string, ?customerAccount: string, ?expand: string list, ?expiresAt: DateTime, ?maxRedemptions: int, ?metadata: Map<string, string>, ?restrictions: Create'Restrictions) =
            {
                Promotion = promotion
                Active = active
                Code = code
                Customer = customer
                CustomerAccount = customerAccount
                Expand = expand
                ExpiresAt = expiresAt
                MaxRedemptions = maxRedemptions
                Metadata = metadata
                Restrictions = restrictions
            }

    module CreateOptions =
        let create
            (
                promotion: Create'Promotion
            ) : CreateOptions
            =
            {
              Promotion = promotion
              Active = None
              Code = None
              Customer = None
              CustomerAccount = None
              Expand = None
              ExpiresAt = None
              MaxRedemptions = None
              Metadata = None
              Restrictions = None
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            PromotionCode: string
        }

    type RetrieveOptions with
        static member New(promotionCode: string, ?expand: string list) =
            {
                PromotionCode = promotionCode
                Expand = expand
            }

    module RetrieveOptions =
        let create
            (
                promotionCode: string
            ) : RetrieveOptions
            =
            {
              PromotionCode = promotionCode
              Expand = None
            }

    type Update'Restrictions =
        {
            /// Promotion codes defined in each available currency option. Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            CurrencyOptions: Map<string, string> option
        }

    type Update'Restrictions with
        static member New(?currencyOptions: Map<string, string>) =
            {
                CurrencyOptions = currencyOptions
            }

    module Update'Restrictions =
        let create
            (
                currencyOptions: Map<string, string> option
            ) : Update'Restrictions
            =
            {
              CurrencyOptions = currencyOptions
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            PromotionCode: string
            /// Whether the promotion code is currently active. A promotion code can only be reactivated when the coupon is still valid and the promotion code is otherwise redeemable.
            [<Config.Form>]
            Active: bool option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Settings that restrict the redemption of the promotion code.
            [<Config.Form>]
            Restrictions: Update'Restrictions option
        }

    type UpdateOptions with
        static member New(promotionCode: string, ?active: bool, ?expand: string list, ?metadata: Map<string, string>, ?restrictions: Update'Restrictions) =
            {
                PromotionCode = promotionCode
                Active = active
                Expand = expand
                Metadata = metadata
                Restrictions = restrictions
            }

    module UpdateOptions =
        let create
            (
                promotionCode: string
            ) : UpdateOptions
            =
            {
              PromotionCode = promotionCode
              Active = None
              Expand = None
              Metadata = None
              Restrictions = None
            }

    ///<p>Returns a list of your promotion codes.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("code", options.Code |> box); ("coupon", options.Coupon |> box); ("created", options.Created |> box); ("customer", options.Customer |> box); ("customer_account", options.CustomerAccount |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/promotion_codes"
        |> RestApi.getAsync<StripeList<PromotionCode>> settings qs

    ///<p>A promotion code points to an underlying promotion. You can optionally restrict the code to a specific customer, redemption limit, and expiration date.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/promotion_codes"
        |> RestApi.postAsync<_, PromotionCode> settings (Map.empty) options

    ///<p>Retrieves the promotion code with the given ID. In order to retrieve a promotion code by the customer-facing <code>code</code> use <a href="/docs/api/promotion_codes/list">list</a> with the desired <code>code</code>.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/promotion_codes/{options.PromotionCode}"
        |> RestApi.getAsync<PromotionCode> settings qs

    ///<p>Updates the specified promotion code by setting the values of the parameters passed. Most fields are, by design, not editable.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/promotion_codes/{options.PromotionCode}"
        |> RestApi.postAsync<_, PromotionCode> settings (Map.empty) options

