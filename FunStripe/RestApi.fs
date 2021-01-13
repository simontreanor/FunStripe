namespace FunStripe

open FSharp.Data

module RestApi =

    ///Record for capturing response errors
    type ErrorResponse = {
        Error: ErrorObject
    }

    ///Record for detailing response errors; see [Stripe API docs](https://stripe.com/docs/api/errors)
    and ErrorObject = {
        ///For card errors, the ID of the failed charge.
        Charge: string option
        ///For some errors that could be handled programmatically, a short string indicating the [error code](https://stripe.com/docs/error-codes) reported.
        Code: string
        ///For card errors resulting from a card issuer decline, a short string indicating the [card issuer’s reason for the decline](https://stripe.com/docs/declines#issuer-declines) if they provide one.
        DeclineCode: string option
        ///A URL to more information about the [error code](https://stripe.com/docs/error-codes) reported.
        DocUrl: string
        ///A human-readable message providing more details about the error. For card errors, these messages can be shown to your users.
        Message: string
        Metadata: Map<string, string>
        ///If the error is parameter-specific, the parameter related to the error. For example, you can use this to display a message near the correct form field.
        Param: string
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
        Type: ErrorType
    }

    and ErrorType =
    | ApiConnectionError
    | ApiError
    | AuthenticationError
    | CardError
    | IdempotencyError
    | InvalidRequestError
    | RateLimitError

    ///Class for making API calls to the Stripe API
    type RestApiClient(?baseUrl: string, ?apiKey: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) =

        ///Stripe API base URL (if not specified in constructor)
        let baseUrl = defaultArg baseUrl "https://api.stripe.com"

        ///Stripe API key (if not specified in constructor)
        let apiKey = defaultArg apiKey "<enter stripe secret key here>"

        ///Basic authentication header
        let authHeader = HttpRequestHeaders.BasicAuth apiKey ""

        ///Stripe-specific headers
        let idempotencyHeader = idempotencyKey |> Option.map (fun ik -> "Idempotency-Key", ik)
        let stripeAccountHeader = stripeAccount |> Option.map (fun sa -> "Stripe-Account", sa)
        let stripeVersionHeader = stripeVersion |> Option.map (fun sv -> "Stripe-Version", sv)
        let stripeHeaders =
            [
                idempotencyHeader
                stripeAccountHeader
                stripeVersionHeader
            ]
            |> List.choose id

        ///Parse response from API and convert it to a ```Result```
        member private _.ParseResponse<'a> (r: HttpResponse) =
            match r.StatusCode with
            | sc when sc >= 200 && sc <= 299 ->
                r.Body
                    |> function Text t -> t | Binary _ -> ""
                    |> Json.Util.deserialise<'a>
                    |> Ok
            | _ ->
                r.Body
                |> function Text t -> t | Binary _ -> ""
                |> Json.Util.deserialise<ErrorResponse>
                |> Error

        ///Make a ```GET``` request (without form parameters in the body (default))
        member x.GetAsync<'a> (url: string) =
            async {
                let! response =
                    Http.AsyncRequest ($"{baseUrl}{url}", headers = (authHeader :: stripeHeaders))
                return response |> x.ParseResponse<'a>
            }

        ///Make a ```GET``` request with form parameters in the body
        member x.GetWithAsync<'a, 'b> (data: 'a) (url: string) =
            async {
                let! response =
                    Http.AsyncRequest ($"{baseUrl}{url}", headers = (authHeader :: stripeHeaders), body = FormValues (data |> FormUtil.serialise))
                return response |> x.ParseResponse<'b>
            }

        ///Make a ```POST``` request (with form parameters in the body (default))
        member x.PostAsync<'a, 'b> (data: 'a) (url: string) = 
            async {
                let! response =
                    Http.AsyncRequest ($"{baseUrl}{url}", headers = (authHeader :: stripeHeaders), body = FormValues (data |> FormUtil.serialise))
                return response |> x.ParseResponse<'b>
            }

        ///Make a ```POST``` request without form parameters in the body
        member x.PostWithoutAsync<'a> (url: string) = 
            async {
                let! response =
                    Http.AsyncRequest ($"{baseUrl}{url}", headers = (authHeader :: stripeHeaders), httpMethod = HttpMethod.Post)
                return response |> x.ParseResponse<'a>
            }

        ///Make a ```DELETE``` request (without form parameters in the body (default))
        member x.DeleteAsync<'a> (url: string) =
            async {
                let! response =
                    Http.AsyncRequest ($"{baseUrl}{url}", headers = (authHeader :: stripeHeaders), httpMethod = HttpMethod.Delete)
                return response |> x.ParseResponse<'a> //to do: check if response should be unit
            }
