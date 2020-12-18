namespace FunStripe

open FSharp.Data

module RestApi =

    type ErrorResponse = {
        Error: ErrorObject
    }
    and ErrorObject = {
        Code: string
        DocUrl: string
        Message: string
        Param: string
        Type: string
    }

    type RestApiClient(?baseUrl: string, ?apiKey: string) =

        let baseUrl = defaultArg baseUrl "https://api.stripe.com"

        let apiKey = defaultArg apiKey "<enter stripe secret key here>"

        let authHeader = HttpRequestHeaders.BasicAuth apiKey ""

        let outputToConsole (s: string) =
            printf "%s" s
            s

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
                    
        member x.GetAsync<'a> (url: string) =
            async {
                let! response =
                    Http.AsyncRequest ($"{baseUrl}{url}", headers = [ authHeader ])
                return response |> x.ParseResponse<'a>
            }

        member x.GetWithAsync<'a, 'b> (data: 'a) (url: string) =
            async {
                let! response =
                    Http.AsyncRequest ($"{baseUrl}{url}", headers = [ authHeader ], body = FormValues (data |> FormUtil.serialise))
                return response |> x.ParseResponse<'b>
            }

        member x.PostAsync<'a, 'b> (data: 'a) (url: string) = 
            async {
                let! response =
                    Http.AsyncRequest ($"{baseUrl}{url}", headers = [ authHeader ], body = FormValues (data |> FormUtil.serialise))
                return response |> x.ParseResponse<'b>
            }

        member x.PostWithoutAsync<'a> (url: string) = 
            async {
                let! response =
                    Http.AsyncRequest ($"{baseUrl}{url}", headers = [ authHeader ], httpMethod = HttpMethod.Post)
                return response |> x.ParseResponse<'a>
            }

        member x.DeleteAsync<'a> (url: string) =
            async {
                let! response =
                    Http.AsyncRequest ($"{baseUrl}{url}", headers = [ authHeader ], httpMethod = HttpMethod.Delete)
                return response |> x.ParseResponse<'a> //to do: check if response should be unit
            }
