namespace FunStripe

open FSharp.Data
open FSharp.Reflection
open FunStripe
open System

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
                ApiKey = defaultArg apiKey Config.StripeTestApiKey
                BaseUrl = defaultArg baseUrl Config.StripeBaseUrl
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

    ///Format query string values if present
    let formatQueryString (options: Map<string, obj>) =
        let options' =
            ("&",
                options
                |> Map.toArray
                |> Array.choose(fun (k, v) ->
                    match v with
                    | :? Option<List<string>> as o ->
                        o
                        |> Option.map(fun ss ->
                            (";", ss)
                            |> String.Join
                            |> fun s -> $"{k}[]={s}"
                        )
                    | :? Option<int> as o ->
                        o |> Option.map(fun i -> $"{k}={i |> string}")
                    | :? Option<string> as o ->
                        o |> Option.map(fun s -> $"{k}={s}")
                    | :? List<string> as ss ->
                        (";", ss)
                        |> String.Join
                        |> fun s -> $"{k}[]={s}"
                        |> Some
                    | :? int as i ->
                        $"{k}={i |> string}" |> Some
                    | :? string as s ->
                        $"{k}={s}" |> Some
                    | _ ->
                        None
                )
            ) |> String.Join
        match options' with
        | "" -> ""
        | _ -> $"?{options'}"

    ///Parse response from API and convert it to a `Result`
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
            |> Json.Util.deserialise<StripeError.ErrorResponse>
            |> Error

    ///Make a `GET` request (without form parameters in the body (default))
    let getAsync<'a> settings queryStringOptions (url: string) =
        async {
            let queryString = queryStringOptions |> formatQueryString
            let! response =
                Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Get)
            return response |> parseResponse<'a>
        }

    ///Make a `GET` request with form parameters in the body
    let getWithAsync<'a, 'b> settings queryStringOptions (data: 'a) (url: string) =
        async {
            let queryString = queryStringOptions |> formatQueryString
            let! response =
                Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Get, body = FormValues (data |> FormUtil.serialise))
            return response |> parseResponse<'b>
        }

    ///Make a `POST` request (with form parameters in the body (default))
    let postAsync<'a, 'b> settings queryStringOptions (data: 'a) (url: string) = 
        async {
            let queryString = queryStringOptions |> formatQueryString
            let! response =
                Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Post, body = FormValues (data |> FormUtil.serialise))
            return response |> parseResponse<'b>
        }

    ///Make a `POST` request without form parameters in the body
    let postWithoutAsync<'a> settings queryStringOptions (url: string) = 
        async {
            let queryString = queryStringOptions |> formatQueryString
            let! response =
                Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Post)
            return response |> parseResponse<'a>
        }

    ///Make a `DELETE` request (without form parameters in the body (default))
    let deleteAsync<'a> settings queryStringOptions (url: string) =
        async {
            let queryString = queryStringOptions |> formatQueryString
            let! response =
                Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Delete)
            return response |> parseResponse<'a>
        }
