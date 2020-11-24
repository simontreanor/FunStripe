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

        let BaseUrl = defaultArg baseUrl "https://api.stripe.com"

        let ApiKey = defaultArg apiKey "<enter stripe secret key here>"

        let AuthHeader = HttpRequestHeaders.BasicAuth ApiKey ""

        let outputToConsole (s: string) =
            printf "%s" s
            s

        member private _.parseResponse<'a> (r: HttpResponse) =
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
                    Http.AsyncRequest ($"{BaseUrl}{url}", headers = [ AuthHeader ])
                return response |> x.parseResponse<'a>
            }

        member x.GetWithAsync<'a, 'b> (data: 'a) (url: string) =
            async {
                let! response =
                    Http.AsyncRequest ($"{BaseUrl}{url}", headers = [ AuthHeader ], body = FormValues (data |> FormUtil.serialise))
                return response |> x.parseResponse<'b>
            }

        member x.PostAsync<'a, 'b> (data: 'a) (url: string) = 
            async {
                let! response =
                    Http.AsyncRequest ( $"{BaseUrl}{url}", headers = [ AuthHeader ], body = FormValues (data |> FormUtil.serialise))
                return response |> x.parseResponse<'b>
            }

        member x.PostWithoutAsync<'a> (url: string) = 
            async {
                let! response =
                    Http.AsyncRequest ( $"{BaseUrl}{url}", headers = [ AuthHeader ], httpMethod = HttpMethod.Post )
                return response |> x.parseResponse<'a>
            }
