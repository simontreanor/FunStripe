namespace FunStripe

open FunStripe.Json

///See [Stripe API docs](https://stripe.com/docs/api/errors)
module StripeError =

    ///Type of error
    type ErrorType =
    | ApiConnectionError
    | ApiError
    | AuthenticationError
    | CardError
    | IdempotencyError
    | InvalidRequestError
    | RateLimitError

    ///Error response details
    type ErrorObject = {
        ///For card errors, the ID of the failed charge.
        Charge: string option
        ///For some errors that could be handled programmatically, a short string indicating the [error code](https://stripe.com/docs/error-codes) reported.
        Code: string option
        ///For card errors resulting from a card issuer decline, a short string indicating the [card issuer’s reason for the decline](https://stripe.com/docs/declines#issuer-declines) if they provide one.
        DeclineCode: string option
        ///A URL to more information about the [error code](https://stripe.com/docs/error-codes) reported.
        DocUrl: string option
        ///A human-readable message providing more details about the error. For card errors, these messages can be shown to your users.
        Message: string option
        ///Internally-defined dictionary of parameters for use in custom error reporting
        Metadata: Map<string, string> option
        ///If the error is parameter-specific, the parameter related to the error. For example, you can use this to display a message near the correct form field.
        Param: string option
        ///The PaymentIntent object for errors returned on a request involving a PaymentIntent.
        PaymentIntent: StripeModel.PaymentIntent option
        ///The PaymentMethod object for errors returned on a request involving a PaymentMethod.
        PaymentMethod: StripeModel.PaymentMethod option
        ///If the error is specific to the type of payment method, the payment method type that had a problem. This field is only populated for invoice-related errors.
        PaymentMethodType: StripeModel.PaymentMethodType option
        ///The SetupIntent object for errors returned on a request involving a SetupIntent.
        SetupIntent: StripeModel.SetupIntent option
        ///The source object for errors returned on a request involving a source.
        Source: StripeModel.Source option
        ///The type of error returned. One of `api_connection_error`, `api_error`, `authentication_error`, `card_error`, `idempotency_error`, `invalid_request_error`, `or rate_limit_error`
        Type: ErrorType option
    }
    with
        static member New(?charge: string, ?code: string, ?declineCode: string, ?docUrl: string, ?message: string, ?metadata: Map<string, string>, ?param: string, ?paymentIntent: StripeModel.PaymentIntent, ?paymentMethod: StripeModel.PaymentMethod, ?paymentMethodType: StripeModel.PaymentMethodType, ?setupIntent: StripeModel.SetupIntent, ?source: StripeModel.Source, ?``type``: ErrorType) =
            {
                Charge = charge
                Code = code
                DeclineCode = declineCode
                DocUrl = docUrl
                Message = message
                Metadata = metadata
                Param = param
                PaymentIntent = paymentIntent
                PaymentMethod = paymentMethod
                PaymentMethodType = paymentMethodType
                SetupIntent = setupIntent
                Source = source
                Type = ``type``
            }

    ///Record for capturing response errors
    type ErrorResponse = {
        [<JsonField("error")>]StripeError: ErrorObject
    }
