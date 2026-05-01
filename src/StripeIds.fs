namespace FunStripe

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
[<AutoOpen>]
module StripeIds =

    /// A phantom-typed Stripe resource identifier.
    /// `'phantom` is a zero-cost type tag (see `Markers`) that records which
    /// resource this ID points at. Wire-form is a plain string.
    type StripeId<'phantom> = StripeId of string

    /// A generic paginated list of Stripe objects, including pagination metadata.
    /// Defined here (independent of any per-domain modular file) so all consumers
    /// of the modular Stripe.{Domain} namespaces can reference the same wrapper.
    type StripeList<'T> = {
        ///The list of objects in this page.
        Data: 'T list
        ///True if this list has another page of items after this one that can be fetched.
        HasMore: bool
        ///The URL where this list can be accessed.
        Url: string
    }
        with
            ///String representing the object's type. Always has the value `list`.
            member _.Object = "list"
            static member New (data: 'T list, hasMore: bool, url: string) =
                { Data = data; HasMore = hasMore; Url = url }

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "2.0.3")>]
module Markers =

    // Phantom marker types — one per resource that appears as a single-target
    // expandable reference in the Stripe OpenAPI spec. They have no fields and
    // no runtime cost; they exist solely to parameterise StripeId<'phantom>.
    type Account = class end
    type Application = class end
    type ApplicationFee = class end
    type BalanceTransaction = class end
    type BalanceTransactionSource = class end
    type BillingCreditBalanceTransaction = class end
    type BillingCreditGrant = class end
    type BillingMeter = class end
    type BillingPortalConfiguration = class end
    type Charge = class end
    type CheckoutSession = class end
    type ClimateProduct = class end
    type Coupon = class end
    type CreditNote = class end
    type Customer = class end
    type CustomerBalanceTransaction = class end
    type CustomerCashBalanceTransaction = class end
    type DeletedApplication = class end
    type DeletedCustomer = class end
    type DeletedDiscount = class end
    type DeletedExternalAccount = class end
    type DeletedInvoice = class end
    type DeletedPaymentSource = class end
    type DeletedPlan = class end
    type DeletedPrice = class end
    type DeletedProduct = class end
    type DeletedTaxId = class end
    type Discount = class end
    type Dispute = class end
    type EntitlementsFeature = class end
    type ExternalAccount = class end
    type File = class end
    type FinancialConnectionsAccountOwnership = class end
    type IdentityVerificationReport = class end
    type Invoice = class end
    type IssuingAuthorization = class end
    type IssuingCard = class end
    type IssuingCardholder = class end
    type IssuingDispute = class end
    type IssuingPersonalizationDesign = class end
    type IssuingPhysicalBundle = class end
    type IssuingToken = class end
    type IssuingTransaction = class end
    type Mandate = class end
    type PaymentIntent = class end
    type PaymentLink = class end
    type PaymentMethod = class end
    type PaymentRecord = class end
    type PaymentSource = class end
    type Payout = class end
    type Plan = class end
    type Price = class end
    type Product = class end
    type PromotionCode = class end
    type Quote = class end
    type Refund = class end
    type ReserveHold = class end
    type ReservePlan = class end
    type Review = class end
    type Rule = class end
    type SetupAttempt = class end
    type SetupIntent = class end
    type ShippingRate = class end
    type Subscription = class end
    type SubscriptionSchedule = class end
    type TaxCode = class end
    type TaxId = class end
    type TaxRate = class end
    type TerminalLocation = class end
    type TestHelpersTestClock = class end
    type Transfer = class end
    type TransferReversal = class end
    type TreasuryTransaction = class end
