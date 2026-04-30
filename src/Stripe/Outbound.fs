namespace Stripe.Outbound

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

[<Struct; System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type OutboundTransfersPaymentMethodDetailsUsBankAccountAccountHolderType =
    | Company
    | Individual

[<Struct>]
type OutboundTransfersPaymentMethodDetailsUsBankAccountAccountType =
    | Checking
    | Savings

type OutboundTransfersPaymentMethodDetailsUsBankAccountMandate'AnyOf =
    | String of string
    | Mandate of Mandate

[<Struct>]
type OutboundTransfersPaymentMethodDetailsUsBankAccountNetwork =
    | Ach
    | UsDomesticWire

type OutboundTransfersPaymentMethodDetailsUsBankAccount =
    {
        /// Account holder type: individual or company.
        AccountHolderType: OutboundTransfersPaymentMethodDetailsUsBankAccountAccountHolderType option
        /// Account type: checkings or savings. Defaults to checking if omitted.
        AccountType: OutboundTransfersPaymentMethodDetailsUsBankAccountAccountType option
        /// Name of the bank associated with the bank account.
        BankName: string option
        /// Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        /// Last four digits of the bank account number.
        [<JsonPropertyName("last4")>]
        Last4: string option
        /// ID of the mandate used to make this payment.
        Mandate: OutboundTransfersPaymentMethodDetailsUsBankAccountMandate'AnyOf option
        /// The network rails used. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.
        Network: OutboundTransfersPaymentMethodDetailsUsBankAccountNetwork
        /// Routing number of the bank account.
        RoutingNumber: string option
    }

type OutboundTransfersPaymentMethodDetailsFinancialAccount =
    {
        /// Token of the FinancialAccount.
        Id: string
    }

module OutboundTransfersPaymentMethodDetailsFinancialAccount =
    ///The rails used to send funds.
    let network = "stripe"

[<Struct>]
type OutboundPaymentsPaymentMethodDetailsUsBankAccountAccountHolderType =
    | Company
    | Individual

[<Struct>]
type OutboundPaymentsPaymentMethodDetailsUsBankAccountAccountType =
    | Checking
    | Savings

type OutboundPaymentsPaymentMethodDetailsUsBankAccountMandate'AnyOf =
    | String of string
    | Mandate of Mandate

[<Struct>]
type OutboundPaymentsPaymentMethodDetailsUsBankAccountNetwork =
    | Ach
    | UsDomesticWire

type OutboundPaymentsPaymentMethodDetailsUsBankAccount =
    {
        /// Account holder type: individual or company.
        AccountHolderType: OutboundPaymentsPaymentMethodDetailsUsBankAccountAccountHolderType option
        /// Account type: checkings or savings. Defaults to checking if omitted.
        AccountType: OutboundPaymentsPaymentMethodDetailsUsBankAccountAccountType option
        /// Name of the bank associated with the bank account.
        BankName: string option
        /// Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are the same.
        Fingerprint: string option
        /// Last four digits of the bank account number.
        [<JsonPropertyName("last4")>]
        Last4: string option
        /// ID of the mandate used to make this payment.
        Mandate: OutboundPaymentsPaymentMethodDetailsUsBankAccountMandate'AnyOf option
        /// The network rails used. See the [docs](https://docs.stripe.com/treasury/money-movement/timelines) to learn more about money movement timelines for each network type.
        Network: OutboundPaymentsPaymentMethodDetailsUsBankAccountNetwork
        /// Routing number of the bank account.
        RoutingNumber: string option
    }

type OutboundPaymentsPaymentMethodDetailsFinancialAccount =
    {
        /// Token of the FinancialAccount.
        Id: string
    }

module OutboundPaymentsPaymentMethodDetailsFinancialAccount =
    ///The rails used to send funds.
    let network = "stripe"

