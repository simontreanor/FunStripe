namespace StripeRequest.Plans

open FunStripe
open System.Text.Json.Serialization
open Stripe.Plan
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.4")>]
module Plans =

    type ListOptions =
        {
            /// Only return plans that are active or inactive (e.g., pass `false` to list all inactive plans).
            [<Config.Query>]
            Active: bool option
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
            /// Only return plans for the given product.
            [<Config.Query>]
            Product: string option
            /// A cursor for use in pagination. `starting_after` is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with `obj_foo`, your subsequent call can include `starting_after=obj_foo` in order to fetch the next page of the list.
            [<Config.Query>]
            StartingAfter: string option
        }

    type ListOptions with
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

    type Create'BillingScheme =
        | PerUnit
        | Tiered

    type Create'Interval =
        | Day
        | Month
        | Week
        | Year

    type Create'ProductInlineProductParams =
        {
            /// Whether the product is currently available for purchase. Defaults to `true`.
            [<Config.Form>]
            Active: bool option
            /// The identifier for the product. Must be unique. If not provided, an identifier will be randomly generated.
            [<Config.Form>]
            Id: string option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The product's name, meant to be displayable to the customer.
            [<Config.Form>]
            Name: string option
            /// An arbitrary string to be displayed on your customer's credit card or bank statement. While most banks display this information consistently, some may display it incorrectly or not at all.
            /// This may be up to 22 characters. The statement description may not include `<`, `>`, `\`, `"`, `'` characters, and will appear on your customer's statement in capital letters. Non-ASCII characters are automatically stripped.
            [<Config.Form>]
            StatementDescriptor: string option
            /// A [tax code](https://docs.stripe.com/tax/tax-categories) ID.
            [<Config.Form>]
            TaxCode: string option
            /// A label that represents units of this product. When set, this will be included in customers' receipts, invoices, Checkout, and the customer portal.
            [<Config.Form>]
            UnitLabel: string option
        }

    type Create'ProductInlineProductParams with
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

    type Create'TiersUpTo = | Inf

    type Create'Tiers =
        {
            /// The flat billing amount for an entire tier, regardless of the number of units in the tier.
            [<Config.Form>]
            FlatAmount: int option
            /// Same as `flat_amount`, but accepts a decimal value representing an integer in the minor units of the currency. Only one of `flat_amount` and `flat_amount_decimal` can be set.
            [<Config.Form>]
            FlatAmountDecimal: string option
            /// The per unit billing amount for each individual unit for which this tier applies.
            [<Config.Form>]
            UnitAmount: int option
            /// Same as `unit_amount`, but accepts a decimal value in cents (or local equivalent) with at most 12 decimal places. Only one of `unit_amount` and `unit_amount_decimal` can be set.
            [<Config.Form>]
            UnitAmountDecimal: string option
            /// Specifies the upper bound of this tier. The lower bound of a tier is the upper bound of the previous tier adding one. Use `inf` to define a fallback tier.
            [<Config.Form>]
            UpTo: Choice<Create'TiersUpTo,int> option
        }

    type Create'Tiers with
        static member New(?flatAmount: int, ?flatAmountDecimal: string, ?unitAmount: int, ?unitAmountDecimal: string, ?upTo: Choice<Create'TiersUpTo,int>) =
            {
                FlatAmount = flatAmount
                FlatAmountDecimal = flatAmountDecimal
                UnitAmount = unitAmount
                UnitAmountDecimal = unitAmountDecimal
                UpTo = upTo
            }

    type Create'TiersMode =
        | Graduated
        | Volume

    type Create'TransformUsageRound =
        | Down
        | Up

    type Create'TransformUsage =
        {
            /// Divide usage by this number.
            [<Config.Form>]
            DivideBy: int option
            /// After division, either round the result `up` or `down`.
            [<Config.Form>]
            Round: Create'TransformUsageRound option
        }

    type Create'TransformUsage with
        static member New(?divideBy: int, ?round: Create'TransformUsageRound) =
            {
                DivideBy = divideBy
                Round = round
            }

    type Create'UsageType =
        | Licensed
        | Metered

    type CreateOptions =
        {
            /// Whether the plan is currently available for new subscriptions. Defaults to `true`.
            [<Config.Form>]
            Active: bool option
            /// A positive integer in cents (or local equivalent) (or 0 for a free plan) representing how much to charge on a recurring basis.
            [<Config.Form>]
            Amount: int option
            /// Same as `amount`, but accepts a decimal value with at most 12 decimal places. Only one of `amount` and `amount_decimal` can be set.
            [<Config.Form>]
            AmountDecimal: string option
            /// Describes how to compute the price per period. Either `per_unit` or `tiered`. `per_unit` indicates that the fixed amount (specified in `amount`) will be charged per unit in `quantity` (for plans with `usage_type=licensed`), or per unit of total usage (for plans with `usage_type=metered`). `tiered` indicates that the unit pricing will be computed using a tiering strategy as defined using the `tiers` and `tiers_mode` attributes.
            [<Config.Form>]
            BillingScheme: Create'BillingScheme option
            /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
            [<Config.Form>]
            Currency: IsoTypes.IsoCurrencyCode
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// An identifier randomly generated by Stripe. Used to identify this plan when subscribing a customer. You can optionally override this ID, but the ID must be unique across all plans in your Stripe account. You can, however, use the same plan ID in both live and test modes.
            [<Config.Form>]
            Id: string option
            /// Specifies billing frequency. Either `day`, `week`, `month` or `year`.
            [<Config.Form>]
            Interval: Create'Interval
            /// The number of intervals between subscription billings. For example, `interval=month` and `interval_count=3` bills every 3 months. Maximum of three years interval allowed (3 years, 36 months, or 156 weeks).
            [<Config.Form>]
            IntervalCount: int option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// The meter tracking the usage of a metered price
            [<Config.Form>]
            Meter: string option
            /// A brief description of the plan, hidden from customers.
            [<Config.Form>]
            Nickname: string option
            [<Config.Form>]
            Product: Choice<Create'ProductInlineProductParams,string> option
            /// Each element represents a pricing tier. This parameter requires `billing_scheme` to be set to `tiered`. See also the documentation for `billing_scheme`.
            [<Config.Form>]
            Tiers: Create'Tiers list option
            /// Defines if the tiering price should be `graduated` or `volume` based. In `volume`-based tiering, the maximum quantity within a period determines the per unit price, in `graduated` tiering pricing can successively change as the quantity grows.
            [<Config.Form>]
            TiersMode: Create'TiersMode option
            /// Apply a transformation to the reported usage or set quantity before computing the billed price. Cannot be combined with `tiers`.
            [<Config.Form>]
            TransformUsage: Create'TransformUsage option
            /// Default number of trial days when subscribing a customer to this plan using [`trial_from_plan=true`](https://docs.stripe.com/api#create_subscription-trial_from_plan).
            [<Config.Form>]
            TrialPeriodDays: int option
            /// Configures how the quantity per period should be determined. Can be either `metered` or `licensed`. `licensed` automatically bills the `quantity` set when adding it to a subscription. `metered` aggregates the total usage based on usage records. Defaults to `licensed`.
            [<Config.Form>]
            UsageType: Create'UsageType option
        }

    type CreateOptions with
        static member New(currency: IsoTypes.IsoCurrencyCode, interval: Create'Interval, ?active: bool, ?amount: int, ?amountDecimal: string, ?billingScheme: Create'BillingScheme, ?expand: string list, ?id: string, ?intervalCount: int, ?metadata: Map<string, string>, ?meter: string, ?nickname: string, ?product: Choice<Create'ProductInlineProductParams,string>, ?tiers: Create'Tiers list, ?tiersMode: Create'TiersMode, ?transformUsage: Create'TransformUsage, ?trialPeriodDays: int, ?usageType: Create'UsageType) =
            {
                Currency = currency
                Interval = interval
                Active = active
                Amount = amount
                AmountDecimal = amountDecimal
                BillingScheme = billingScheme
                Expand = expand
                Id = id
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

    type DeleteOptions =
        { [<Config.Path>]
          Plan: string }

    type DeleteOptions with
        static member New(plan: string) =
            {
                Plan = plan
            }

    type RetrieveOptions =
        {
            /// Specifies which fields in the response should be expanded.
            [<Config.Query>]
            Expand: string list option
            [<Config.Path>]
            Plan: string
        }

    type RetrieveOptions with
        static member New(plan: string, ?expand: string list) =
            {
                Plan = plan
                Expand = expand
            }

    type UpdateOptions =
        {
            [<Config.Path>]
            Plan: string
            /// Whether the plan is currently available for new subscriptions.
            [<Config.Form>]
            Active: bool option
            /// Specifies which fields in the response should be expanded.
            [<Config.Form>]
            Expand: string list option
            /// Set of [key-value pairs](https://docs.stripe.com/api/metadata) that you can attach to an object. This can be useful for storing additional information about the object in a structured format. Individual keys can be unset by posting an empty value to them. All keys can be unset by posting an empty value to `metadata`.
            [<Config.Form>]
            Metadata: Map<string, string> option
            /// A brief description of the plan, hidden from customers.
            [<Config.Form>]
            Nickname: string option
            /// The product the plan belongs to. This cannot be changed once it has been used in a subscription or subscription schedule.
            [<Config.Form>]
            Product: string option
            /// Default number of trial days when subscribing a customer to this plan using [`trial_from_plan=true`](https://docs.stripe.com/api#create_subscription-trial_from_plan).
            [<Config.Form>]
            TrialPeriodDays: int option
        }

    type UpdateOptions with
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

    ///<p>Returns a list of your plans.</p>
    let List settings (options: ListOptions) =
        let qs = [("active", options.Active |> box); ("created", options.Created |> box); ("ending_before", options.EndingBefore |> box); ("expand", options.Expand |> box); ("limit", options.Limit |> box); ("product", options.Product |> box); ("starting_after", options.StartingAfter |> box)] |> Map.ofList
        $"/v1/plans"
        |> RestApi.getAsync<StripeList<Plan>> settings qs

    ///<p>You can now model subscriptions more flexibly using the <a href="#prices">Prices API</a>. It replaces the Plans API and is backwards compatible to simplify your migration.</p>
    let Create settings (options: CreateOptions) =
        $"/v1/plans"
        |> RestApi.postAsync<_, Plan> settings (Map.empty) options

    ///<p>Deleting plans means new subscribers can’t be added. Existing subscribers aren’t affected.</p>
    let Delete settings (options: DeleteOptions) =
        $"/v1/plans/{options.Plan}"
        |> RestApi.deleteAsync<DeletedPlan> settings (Map.empty)

    ///<p>Retrieves the plan with the given ID.</p>
    let Retrieve settings (options: RetrieveOptions) =
        let qs = [("expand", options.Expand |> box)] |> Map.ofList
        $"/v1/plans/{options.Plan}"
        |> RestApi.getAsync<Plan> settings qs

    ///<p>Updates the specified plan by setting the values of the parameters passed. Any parameters not provided are left unchanged. By design, you cannot change a plan’s ID, amount, currency, or billing cycle.</p>
    let Update settings (options: UpdateOptions) =
        $"/v1/plans/{options.Plan}"
        |> RestApi.postAsync<_, Plan> settings (Map.empty) options

