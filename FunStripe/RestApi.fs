namespace FunStripe

open FSharp.Data
open FunStripe.StripeError

module RestApi =

    ///Stripe API settings
    type StripeApiSettings = {
        ApiKey: string
        BaseUrl: string
        IdempotencyKey: string option
        StripeAccount: string option
        StripeVersion: string option
    }
    with
        static member Create(?apiKey: string, ?baseUrl: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) =
            {
                ApiKey = defaultArg apiKey "https://api.stripe.com"
                BaseUrl = defaultArg baseUrl "<enter default stripe secret key here>"
                IdempotencyKey = idempotencyKey
                StripeAccount = stripeAccount
                StripeVersion = stripeVersion
            }

    ///Create request header
    let createHeader settings =
        let authHeader = HttpRequestHeaders.BasicAuth settings.ApiKey ""

        let idempotencyHeader = settings.IdempotencyKey |> Option.map (fun ik -> "Idempotency-Key", ik)
        let stripeAccountHeader = settings.StripeAccount |> Option.map (fun sa -> "Stripe-Account", sa)
        let stripeVersionHeader = settings.StripeVersion |> Option.map (fun sv -> "Stripe-Version", sv)

        let stripeHeaders =
            [
                idempotencyHeader
                stripeAccountHeader
                stripeVersionHeader
            ]
            |> List.choose id

        authHeader :: stripeHeaders

    ///Parse response from API and convert it to a ```Result```
    let parseResponse<'a> (r: HttpResponse) =
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
    let getAsync<'a> settings (url: string) =
        async {
            let! response =
                Http.AsyncRequest ($"{settings.BaseUrl}{url}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Get)
            return response |> parseResponse<'a>
        }

    ///Make a ```GET``` request with form parameters in the body
    let getWithAsync<'a, 'b> settings (data: 'a) (url: string) =
        async {
            let! response =
                Http.AsyncRequest ($"{settings.BaseUrl}{url}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Get, body = FormValues (data |> FormUtil.serialise))
            return response |> parseResponse<'b>
        }

    ///Make a ```POST``` request (with form parameters in the body (default))
    let postAsync<'a, 'b> settings (data: 'a) (url: string) = 
        async {
            let! response =
                Http.AsyncRequest ($"{settings.BaseUrl}{url}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Post, body = FormValues (data |> FormUtil.serialise))
            return response |> parseResponse<'b>
        }

    ///Make a ```POST``` request without form parameters in the body
    let postWithoutAsync<'a> settings (url: string) = 
        async {
            let! response =
                Http.AsyncRequest ($"{settings.BaseUrl}{url}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Post)
            return response |> parseResponse<'a>
        }

    ///Make a ```DELETE``` request (without form parameters in the body (default))
    let deleteAsync<'a> settings (url: string) =
        async {
            let! response =
                Http.AsyncRequest ($"{settings.BaseUrl}{url}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Delete)
            return response |> parseResponse<'a>
        }
