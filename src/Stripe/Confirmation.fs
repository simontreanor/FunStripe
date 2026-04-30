namespace Stripe.Confirmation

open System.Text.Json.Serialization
open FunStripe
open System
open Stripe.PaymentMethod

/// Installment configuration for payments.
[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "1.0.0")>]
type ConfirmationTokensResourcePaymentMethodOptionsResourceCardResourceInstallment =
    { Plan: PaymentMethodDetailsCardInstallmentsPlan option }

/// This hash contains the card payment method options.
type ConfirmationTokensResourcePaymentMethodOptionsResourceCard =
    {
        /// The `cvc_update` Token collected from the Payment Element.
        CvcToken: string option
        Installments: ConfirmationTokensResourcePaymentMethodOptionsResourceCardResourceInstallment option
    }

/// This hash contains details about the online acceptance.
type ConfirmationTokensResourceMandateDataResourceCustomerAcceptanceResourceOnline =
    {
        /// The IP address from which the Mandate was accepted by the customer.
        IpAddress: string option
        /// The user agent of the browser from which the Mandate was accepted by the customer.
        UserAgent: string option
    }

/// This hash contains details about the customer acceptance of the Mandate.
type ConfirmationTokensResourceMandateDataResourceCustomerAcceptance =
    {
        /// If this is a Mandate accepted online, this hash contains details about the online acceptance.
        Online: ConfirmationTokensResourceMandateDataResourceCustomerAcceptanceResourceOnline option
        /// The type of customer acceptance information included with the Mandate.
        Type: string
    }

