namespace Stripe.Balance

open System.Text.Json.Serialization
open FunStripe
open System

[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type BalanceAmountBySourceType =
    {
        /// Amount coming from [legacy US ACH payments](https://docs.stripe.com/ach-deprecated).
        BankAccount: int option
        /// Amount coming from most payment methods, including cards as well as [non-legacy bank debits](https://docs.stripe.com/payments/bank-debits).
        Card: int option
        /// Amount coming from [FPX](https://docs.stripe.com/payments/fpx), a Malaysian payment method.
        Fpx: int option
    }

type BalanceAmount =
    {
        /// Balance amount.
        Amount: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        SourceTypes: BalanceAmountBySourceType option
    }

type BalanceNetAvailable =
    {
        /// Net balance amount, subtracting fees from platform-set pricing.
        Amount: int
        /// ID of the external account for this net balance (not expandable).
        Destination: string
        SourceTypes: BalanceAmountBySourceType option
    }

type BalanceAmountNet =
    {
        /// Balance amount.
        Amount: int
        /// Three-letter [ISO currency code](https://www.iso.org/iso-4217-currency-codes.html), in lowercase. Must be a [supported currency](https://stripe.com/docs/currencies).
        Currency: IsoTypes.IsoCurrencyCode
        /// Breakdown of balance by destination.
        NetAvailable: BalanceNetAvailable list option
        SourceTypes: BalanceAmountBySourceType option
    }

type BalanceDetail =
    {
        /// Funds that are available for use.
        Available: BalanceAmount list
    }

type BalanceDetailUngated =
    {
        /// Funds that are available for use.
        Available: BalanceAmount list
        /// Funds that are pending
        Pending: BalanceAmount list
    }

/// This is an object representing your Stripe balance. You can retrieve it to see
/// the balance currently on your Stripe account.
/// The top-level `available` and `pending` comprise your "payments balance."
/// Related guide: [Balances and settlement time](https://docs.stripe.com/payments/balances), [Understanding Connect account balances](https://docs.stripe.com/connect/account-balances)
type Balance =
    {
        /// Available funds that you can transfer or pay out automatically by Stripe or explicitly through the [Transfers API](https://api.stripe.com#transfers) or [Payouts API](https://api.stripe.com#payouts). You can find the available balance for each currency and payment type in the `source_types` property.
        Available: BalanceAmount list
        /// Funds held due to negative balances on connected accounts where [account.controller.requirement_collection](/api/accounts/object#account_object-controller-requirement_collection) is `application`, which includes Custom accounts. You can find the connect reserve balance for each currency and payment type in the `source_types` property.
        ConnectReserved: BalanceAmount list option
        /// Funds that you can pay out using Instant Payouts.
        InstantAvailable: BalanceAmountNet list option
        Issuing: BalanceDetail option
        /// If the object exists in live mode, the value is `true`. If the object exists in test mode, the value is `false`.
        Livemode: bool
        /// Funds that aren't available in the balance yet. You can find the pending balance for each currency and each payment type in the `source_types` property.
        Pending: BalanceAmount list
        RefundAndDisputePrefunding: BalanceDetailUngated option
    }

module Balance =
    ///String representing the object's type. Objects of the same type share the same value.
    let object = "balance"

/// Occurs whenever your Stripe balance has been updated (e.g., when a charge is available to be paid out). By default, Stripe automatically transfers funds in your balance to your bank account on a daily basis. This event is not fired for negative transactions.
type BalanceAvailable = { Object: Balance }

