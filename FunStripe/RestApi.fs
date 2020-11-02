namespace FunStripe

open FSharp.Data

module RestApi =

    type RestApiClient(?baseUrl: string, ?apiKey: string) =

        let BaseUrl = defaultArg baseUrl "https://api.stripe.com"

        let ApiKey = defaultArg apiKey "<enter stripe secret key here>"

        let AuthHeader = HttpRequestHeaders.BasicAuth ApiKey ""

        let outputToConsole (s: string) =
            printf "%s" s
            s

        member _.GetAsync<'a> (url: string) =
            async {
                let! json =
                    Http.AsyncRequestString ($"{BaseUrl}{url}", headers = [ AuthHeader ])
                return
                    json
                    |> JsonUtil.deserialise<'a>
            }

        member _.GetWithAsync<'a, 'b> (data: 'a) (url: string) =
            async {
                let! json =
                    Http.AsyncRequestString ($"{BaseUrl}{url}", headers = [ AuthHeader ], body = FormValues (data |> FormUtil.serialise))
                return
                    json
                    |> JsonUtil.deserialise<'b>
            }

        member _.PostAsync<'a, 'b> (data: 'a) (url: string) = 
            async {
                let! json =
                    Http.AsyncRequestString ( $"{BaseUrl}{url}", headers = [ AuthHeader ], body = FormValues (data |> FormUtil.serialise))
                return
                    json
                    |> JsonUtil.deserialise<'b>
            }

        member _.PostWithoutAsync<'a, 'b> (url: string) = 
            async {
                let! json =
                    Http.AsyncRequestString ( $"{BaseUrl}{url}", headers = [ AuthHeader ], httpMethod = HttpMethod.Post )
                return
                    json
                    |> JsonUtil.deserialise<'b>
            }
