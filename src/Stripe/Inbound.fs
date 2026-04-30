namespace Stripe.Inbound

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type InboundTransfersPaymentMethodDetailsUsBankAccountAccountHolderType =
    | Company
    | Individual

[<Struct>]
type InboundTransfersPaymentMethodDetailsUsBankAccountAccountType =
    | Checking
    | Savings

type InboundTransfersPaymentMethodDetailsUsBankAccountMandate'AnyOf =
    | String of string
    | Mandate of Mandate

type InboundTransfersPaymentMethodDetailsUsBankAccount =
    {
        /// Account holder type: individual or company.
        AccountHolderType: InboundTransfersPaymentMethodDetailsUsBankAccountAccountHolderType option
        /// Account type: checkings or savings. Defaults to checking if omitted.
        AccountType: InboundTransfersPaymentMethodDetailsUsBankAccountAccountType option
        /// Name of the bank associated with the bank account.
        BankName: string option
        /// Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        /// Last four digits of the bank account number.
        [<JsonPropertyName("last4")>]
        Last4: string option
        /// ID of the mandate used to make this payment.
        Mandate: InboundTransfersPaymentMethodDetailsUsBankAccountMandate'AnyOf option
        /// Routing number of the bank account.
        RoutingNumber: string option
    }

module InboundTransfersPaymentMethodDetailsUsBankAccount =
    ///The network rails used. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.
    let network = "ach"

