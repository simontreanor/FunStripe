namespace FunStripe

#if !FABLE_COMPILER
open FSharp.Data
#else
open Fable.SimpleHttp
#endif
open FunStripe

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
        static member New(?apiKey: string, ?baseUrl: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string) =
            {
                ApiKey = defaultArg apiKey Config.StripeTestApiKey
                BaseUrl = defaultArg baseUrl Config.StripeBaseUrl
                IdempotencyKey = idempotencyKey
                StripeAccount = stripeAccount
                StripeVersion = stripeVersion
            }

#if FABLE_COMPILER
    ///Create Basic auth header value for the given API key
    let private createBasicAuthValue (apiKey: string) =
        let credentials = System.Text.Encoding.UTF8.GetBytes($"{apiKey}:")
        let base64 = System.Convert.ToBase64String(credentials)
        $"Basic {base64}"

    ///Create request headers for Fable
    let createHeader settings =
        let authHeader = Headers.authorization (createBasicAuthValue settings.ApiKey)

        let idempotencyHeader = settings.IdempotencyKey |> Option.map (fun ik -> Headers.create "Idempotency-Key" ik)
        let stripeAccountHeader = settings.StripeAccount |> Option.map (fun sa -> Headers.create "Stripe-Account" sa)
        let stripeVersionHeader = settings.StripeVersion |> Option.map (fun sv -> Headers.create "Stripe-Version" sv)

        let stripeHeaders =
            [
                idempotencyHeader
                stripeAccountHeader
                stripeVersionHeader
            ]
            |> List.choose id

        authHeader :: stripeHeaders
#else
    ///Create request headers
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
#endif

    ///Format query string values if present with proper URL encoding
    let formatQueryString (options: Map<string, obj>) =
        let urlEncode (s: string) = System.Uri.EscapeDataString s
        
        let options' =
            options
            |> Map.toArray
            |> Array.choose(fun (k, v) ->
                let encodedKey = urlEncode k
                match v with
                | :? Option<List<string>> as o ->
                    o
                    |> Option.map(fun ss ->
                        ss
                        |> List.map urlEncode
                        |> String.concat ";"
                        |> fun s -> $"{encodedKey}[]={s}"
                    )
                | :? Option<int> as o ->
                    o |> Option.map(fun i -> $"{encodedKey}={urlEncode (i |> string)}")
                | :? Option<string> as o ->
                    o |> Option.map(fun s -> $"{encodedKey}={urlEncode s}")
                | :? List<string> as ss ->
                    ss
                    |> List.map urlEncode
                    |> String.concat ";"
                    |> fun s -> $"{encodedKey}[]={s}"
                    |> Some
                | :? int as i ->
                    $"{encodedKey}={urlEncode (i |> string)}" |> Some
                | :? string as s ->
                    $"{encodedKey}={urlEncode s}" |> Some
                | _ ->
                    None
            )
            |> String.concat "&"
        match options' with
        | "" -> ""
        | _ -> $"?{options'}"

#if FABLE_COMPILER
    ///Encode form values as application/x-www-form-urlencoded body
    let private encodeFormBody (formValues: seq<string * string>) =
        formValues
        |> Seq.map (fun (k, v) -> $"{System.Uri.EscapeDataString k}={System.Uri.EscapeDataString v}")
        |> String.concat "&"

    ///Parse response from API and convert it to a `Result` (Fable version)
    let private parseFableResponse<'a> (statusCode: int) (responseText: string) =
        if statusCode >= 200 && statusCode <= 299 then
            responseText
            |> Util.deserialise<'a>
            |> Ok
        else
            responseText
            |> Util.deserialise<StripeError.ErrorResponse>
            |> Error

    ///Make a `GET` request (Fable version)
    let getAsync<'a> settings queryStringOptions (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        async {
            let! response =
                Http.request $"{settings.BaseUrl}{url}{queryString}"
                |> Http.method GET
                |> Http.headers (createHeader settings)
                |> Http.send
            return parseFableResponse<'a> response.statusCode response.responseText
        }

    ///Make a `GET` request with form parameters in the body (Fable version)
    let getWithAsync<'a, 'b> settings queryStringOptions (data: 'a) (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        let body = data |> Util.serialiseForm |> encodeFormBody
        async {
            let! response =
                Http.request $"{settings.BaseUrl}{url}{queryString}"
                |> Http.method GET
                |> Http.headers (createHeader settings)
                |> Http.header (Headers.contentType "application/x-www-form-urlencoded")
                |> Http.content (BodyContent.Text body)
                |> Http.send
            return parseFableResponse<'b> response.statusCode response.responseText
        }

    ///Make a `POST` request (with form parameters in the body) (Fable version)
    let postAsync<'a, 'b> settings queryStringOptions (data: 'a) (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        let body = data |> Util.serialiseForm |> encodeFormBody
        async {
            let! response =
                Http.request $"{settings.BaseUrl}{url}{queryString}"
                |> Http.method POST
                |> Http.headers (createHeader settings)
                |> Http.header (Headers.contentType "application/x-www-form-urlencoded")
                |> Http.content (BodyContent.Text body)
                |> Http.send
            return parseFableResponse<'b> response.statusCode response.responseText
        }

    ///Make a `POST` request without form parameters in the body (Fable version)
    let postWithoutAsync<'a> settings queryStringOptions (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        async {
            let! response =
                Http.request $"{settings.BaseUrl}{url}{queryString}"
                |> Http.method POST
                |> Http.headers (createHeader settings)
                |> Http.send
            return parseFableResponse<'a> response.statusCode response.responseText
        }

    ///Make a `DELETE` request (Fable version)
    let deleteAsync<'a> settings queryStringOptions (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        async {
            let! response =
                Http.request $"{settings.BaseUrl}{url}{queryString}"
                |> Http.method DELETE
                |> Http.headers (createHeader settings)
                |> Http.send
            return parseFableResponse<'a> response.statusCode response.responseText
        }
#else
    ///Parse response from API and convert it to a `Result`
    let parseResponse<'a> (r: HttpResponse) =
        match r.StatusCode with
        | sc when sc >= 200 && sc <= 299 ->
            r.Body
                |> function Text t -> t | Binary _ -> ""
                |> Util.deserialise<'a>
                |> Ok
        | _ ->
            r.Body
            |> function Text t -> t | Binary _ -> ""
            |> Util.deserialise<StripeError.ErrorResponse>
            |> Error

    ///Make a `GET` request (without form parameters in the body (default))
    let getAsync<'a> settings queryStringOptions (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        async {
            let! response = Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Get)
            return response |> parseResponse<'a>
        }

    ///Make a `GET` request with form parameters in the body
    let getWithAsync<'a, 'b> settings queryStringOptions (data: 'a) (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        let formValues = data |> Util.serialiseForm |> FormValues
        async {
            let! response = Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Get, body = formValues)
            return response |> parseResponse<'b>
        }

    ///Make a `POST` request (with form parameters in the body (default))
    let postAsync<'a, 'b> settings queryStringOptions (data: 'a) (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        let formValues = data |> Util.serialiseForm |> FormValues
        async {
            let! response = Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Post, body = formValues)
            return response |> parseResponse<'b>
        }

    ///Make a `POST` request without form parameters in the body
    let postWithoutAsync<'a> settings queryStringOptions (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        async {
            let! response = Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Post)
            return response |> parseResponse<'a>
        }

    ///Make a `DELETE` request (without form parameters in the body (default))
    let deleteAsync<'a> settings queryStringOptions (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        async {
            let! response = Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, httpMethod = HttpMethod.Delete)
            return response |> parseResponse<'a>
        }
#endif
