namespace FunStripe

open FSharp.Data

module RestApi =

    ///Record for capturing response errors
    type ErrorResponse = {
        Error: ErrorObject
    }

    ///Record for detailing response errors
    and ErrorObject = {
        Code: string
        DocUrl: string
        Message: string
        Param: string
        Type: string
    }

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
                    |> JsonUtil.deserialise<'a>
                    |> Ok
            | _ ->
                r.Body
                |> function Text t -> t | Binary _ -> ""
                |> JsonUtil.deserialise<ErrorResponse>
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
