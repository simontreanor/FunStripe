namespace StripeRequest.Coupons

open FunStripe
open System.Text.Json.Serialization
open Stripe.Coupon
open Stripe.Deleted
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.0")>]
module Coupons =

    type ListOptions =
        {
            /// A filter on the list, based on the object `created` field. The value can be a string with an integer Unix timestamp, or it can be a dictionary with a number of different query options.
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

    module ListOptions =
        let create
            (
                created: int option,
                endingBefore: string option,
                expand: string list option,
                limit: int option,
                startingAfter: string option
            ) : ListOptions
            =
            {
              Created = created
              EndingBefore = endingBefore
              Expand = expand
              Limit = limit
              StartingAfter = startingAfter
            }

    type Create'AppliesTo =
        {
            /// An array of Product IDs that this Coupon will apply to.
            [<Config.Form>]
            Products: string list option
        }

    module Create'AppliesTo =
        let create
            (
                products: string list option
            ) : Create'AppliesTo
            =
            {
              Products = products
            }

    type Create'Duration =
        | Forever
        | Once
        | Repeating

    type CreateOptions =
        {
            /// A positive integer representing the amount to subtract from an invoice total (required if `percent_off` is not passed).
            [<Config.Form>]
            AmountOff: int option
            /// A hash containing directions for what this Coupon will apply discounts to.
            [<Config.Form>]
            AppliesTo: Create'AppliesTo option
            /// Three-letter [ISO code for the currency](https://stripe.com/docs/currencies) of the `amount_off` parameter (required if `amount_off` is passed).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode option
            /// Coupons defined in each available currency option (only supported if `amount_off` is passed). Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            CurrencyOptions: Map<string, string> option
            /// Specifies how long the discount will be in effect if used on a subscription. Defaults to `once`.
            [<Config.Form>]
            Duration: Create'Duration option
            /// Required only if `duration` is `repeating`, in which case it must be a positive integer that specifies the number of months the discount will be in effect.
            [<Config.Form>]
            DurationInMonths: int option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Unique string of your choice that will be used to identify this coupon when applying it to a customer. If you don't want to specify a particular code, you can leave the ID blank and we'll generate a random code for you.
            [<Config.Form>]
            Id: string option
            /// A positive integer specifying the number of times the coupon can be redeemed before it's no longer valid. For example, you might have a 50% off coupon that the first 20 readers of your blog can use.
            [<Config.Form>]
            MaxRedemptions: int option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Name of the coupon displayed to customers on, for instance invoices, or receipts. By default the `id` is shown if `name` is not set.
            [<Config.Form>]
            Name: string option
            /// A positive float larger than 0, and smaller or equal to 100, that represents the discount the coupon will apply (required if `amount_off` is not passed).
            [<Config.Form>]
            PercentOff: decimal option
            /// Unix timestamp specifying the last time at which the coupon can be redeemed (cannot be set to more than 5 years in the future). After the redeem_by date, the coupon can no longer be applied to new customers.
            [<Config.Form>]
            RedeemBy: DateTime option
        }

    module CreateOptions =
        let create
            (
                amountOff: int option,
                appliesTo: Create'AppliesTo option,
                currency: IsoTypes.IsoCurrencyCode option,
                currencyOptions: Map<string, string> option,
                duration: Create'Duration option,
                durationInMonths: int option,
                expand: string list option,
                id: string option,
                maxRedemptions: int option,
                metadata: Map<string, string> option,
                name: string option,
                percentOff: decimal option,
                redeemBy: DateTime option
            ) : CreateOptions
            =
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

    type DeleteOptions =
        { [<Config.Path>]
          Coupon: string }

    module DeleteOptions =
        let create
            (
                coupon: string
            ) : DeleteOptions
            =
            {
              Coupon = coupon
            }

    type RetrieveOptions =
        {
            [<Config.Path>]
            Coupon: string
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
        }

    module RetrieveOptions =
        let create
            (
                coupon: string
            ) : RetrieveOptions
            =
            {
              Coupon = coupon
              Expand = None
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Coupon: string
            /// Coupons defined in each available currency option (only supported if the coupon is amount-based). Each key must be a three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html) and a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            CurrencyOptions: Map<string, string> option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// Name of the coupon displayed to customers on, for instance invoices, or receipts. By default the `id` is shown if `name` is not set.
            [<Config.Form>]
            Name: string option
        }

    module UpdateOptions =
        let create
            (
                coupon: string
            ) : UpdateOptions
            =
            {
              Coupon = coupon
              CurrencyOptions = None
              Expand = None
              Metadata = None
              Name = None
            }

    ///<p>Returns a list of your coupons.</p>
    let List settings (options: ListOptions) =
        let qs = [("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/coupons"
        |> RestApi.getAsync<StripeList<Coupon>> settings qs

    ///<p>You can create coupons easily via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. Coupon creation is also accessible via the API if you need to create coupons on the fly.</p>
    ///<p>A coupon has either a <code>percent_off</code> or an <code>amount_off</code> and <code>currency</code>. If you set an <code>amount_off</code>, that amount will be subtracted from any invoice’s subtotal. For example, an invoice with a subtotal of <currency>100</currency> will have a final total of <currency>0</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it and an invoice with a subtotal of <currency>300</currency> will have a final total of <currency>100</currency> if a coupon with an <code>amount_off</code> of <amount>200</amount> is applied to it.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/coupons"
        |> RestApi.postAsync<_, Coupon> settings (Map.empty) options

    ///<p>You can delete coupons via the <a href="https://dashboard.stripe.com/coupons">coupon management</a> page of the Stripe dashboard. However, deleting a coupon does not affect any customers who have already applied the coupon; it means that new customers can’t redeem the coupon. You can also delete coupons via the API.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/coupons/{options.Coupon}"
        |> RestApi.deleteAsync<DeletedCoupon> settings (Map.empty)

    ///<p>Retrieves the coupon with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/coupons/{options.Coupon}"
        |> RestApi.getAsync<Coupon> settings qs

    ///<p>Updates the metadata of a coupon. Other coupon details (currency, duration, amount_off) are, by design, not editable.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/coupons/{options.Coupon}"
        |> RestApi.postAsync<_, Coupon> settings (Map.empty) options

