namespace FunStripe

open System.Text.Json
open FSharp.Data
open FSharp.Reflection
open FunStripe

///The content of a file to upload, e.g. with `Files.Create`
type FileUpload = {
    ///The file name Stripe stores with the file
    FileName: string
    ///The media type, e.g. `image/png` or `application/pdf`
    ContentType: string
    Content: byte array
}
with
    static member New(fileName: string, content: byte array, ?contentType: string) =
        {
            FileName = fileName
            ContentType = defaultArg contentType "application/octet-stream"
            Content = content
        }

module RestApi =

    ///Stripe API settings
    type StripeApiSettings = {
        ApiKey: string
        BaseUrl: string
        ///Where file uploads go, when not the default (see `EffectiveFilesBaseUrl`)
        FilesBaseUrl: string option
        IdempotencyKey: string option
        StripeAccount: string option
        ///The `Stripe-Version` header: the API version Stripe answers in. `None` sends no header, so Stripe answers
        ///in the account's default version, which may not be the one the models were generated from.
        StripeVersion: string option
    }
    with
        ///`stripeVersion` defaults to `Config.DefaultStripeApiVersion`, the version the models were generated from.
        static member New(?apiKey: string, ?baseUrl: string, ?idempotencyKey: string, ?stripeAccount: string, ?stripeVersion: string, ?filesBaseUrl: string) =
            {
                ApiKey = defaultArg apiKey Config.StripeTestApiKey
                BaseUrl = defaultArg baseUrl Config.StripeBaseUrl
                FilesBaseUrl = filesBaseUrl
                IdempotencyKey = idempotencyKey
                StripeAccount = stripeAccount
                StripeVersion = Some (defaultArg stripeVersion Config.DefaultStripeApiVersion)
            }

        ///Where file uploads go: `FilesBaseUrl` when set; otherwise Stripe's files host for Stripe's
        ///API host, and `BaseUrl` itself for any other host (a mock or proxy serves both). Decided
        ///per request, so a copy of the settings with another `BaseUrl` uploads there too.
        member this.EffectiveFilesBaseUrl =
            match this.FilesBaseUrl with
            | Some url -> url
            | None when this.BaseUrl.TrimEnd('/') = Config.StripeBaseUrl -> Config.StripeFilesBaseUrl
            | None -> this.BaseUrl

        ///Return a copy of these settings with the given idempotency key applied, for use on a single mutating request
        member this.WithIdempotencyKey(key: string) =
            if System.String.IsNullOrWhiteSpace(key) then
                invalidArg (nameof key) "Idempotency key must not be null or empty"
            { this with IdempotencyKey = Some key }

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

    ///Format query string values if present with proper URL encoding
    let formatQueryString (options: Map<string, obj>) =
        let urlEncode (s: string) = System.Uri.EscapeDataString s

        // A map is sent as one parameter per entry, `key[entry]=value`, as Stripe expects for
        // filters such as `account_holder[customer]`
        let mapEntries (encodedKey: string) (entries: Map<string, string>) =
            if entries.IsEmpty then None
            else
                entries
                |> Map.toList
                |> List.map (fun (entry, value) -> encodedKey + urlEncode ("[" + entry + "]") + "=" + urlEncode value)
                |> String.concat "&"
                |> Some

        // Lower-case, as in the JSON and form encodings
        let currencyCode (currency: IsoTypes.IsoCurrencyCode) =
            (Util.serialise currency).Trim('"')

        let options' =
            options
            |> Map.toArray
            |> Array.choose(fun (k, v) ->
                let encodedKey = urlEncode k
                match v with
                | :? Option<List<string>> as o ->
                    o
                    |> Option.bind(fun ss ->
                        if ss.IsEmpty then None
                        else
                            ss
                            |> List.map (fun v -> $"{encodedKey}[]={urlEncode v}")
                            |> String.concat "&"
                            |> Some
                    )
                | :? Option<bool> as o ->
                    o |> Option.map(fun b -> $"{encodedKey}={urlEncode (b |> string |> fun s -> s.ToLowerInvariant())}")
                | :? Option<int> as o ->
                    o |> Option.map(fun i -> $"{encodedKey}={urlEncode (i |> string)}")
                | :? Option<string> as o ->
                    o |> Option.map(fun s -> $"{encodedKey}={urlEncode s}")
                | :? Option<Map<string, string>> as o ->
                    o |> Option.bind (mapEntries encodedKey)
                | :? Map<string, string> as m ->
                    mapEntries encodedKey m
                | :? Option<IsoTypes.IsoCurrencyCode> as o ->
                    o |> Option.map(fun c -> $"{encodedKey}={urlEncode (currencyCode c)}")
                | :? IsoTypes.IsoCurrencyCode as c ->
                    $"{encodedKey}={urlEncode (currencyCode c)}" |> Some
                | :? bool as b ->
                    $"{encodedKey}={urlEncode (b |> string |> fun s -> s.ToLowerInvariant())}" |> Some
                | :? List<string> as ss ->
                    if ss.IsEmpty then None
                    else
                        ss
                        |> List.map (fun v -> $"{encodedKey}[]={urlEncode v}")
                        |> String.concat "&"
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

    ///Requests don't follow redirects: the form body and headers such as `Stripe-Account` would go to wherever one points.
    let private noRedirects (request: System.Net.HttpWebRequest) =
        request.AllowAutoRedirect <- false
        request

    ///The error for a redirect, which has no Stripe error in its body.
    let private redirected (status: int) =
        $"""{{"error":{{"message":"Stripe answered HTTP {status}, a redirect, which isn't followed.","type":"api_error"}}}}"""
        |> Util.deserialise<StripeError.ErrorResponse>

    ///The error for an answer that can't be read, which has no Stripe error to give: a body that isn't JSON, such as a
    ///proxy's page, or one with a value the models don't list. Its `Code` tells it from Stripe's own errors, and its
    ///`Metadata` has the `http_status` and Stripe's `request_id`. For a 2xx Stripe has done the work, so the error
    ///has no type: `api_error` is Stripe's own failure, which callers send again.
    let private unreadable (status: int) (requestId: string option) (reason: string) : StripeError.ErrorResponse =
        let success = status >= 200 && status <= 299
        let metadata =
            ("http_status", string status) :: (requestId |> Option.map (fun id -> "request_id", id) |> Option.toList)
            |> Map.ofList
        { StripeError =
            { StripeError.ErrorObject.New(
                message = $"Stripe answered HTTP {status}, and the answer could not be read: {reason}",
                code = (if success then StripeError.UnreadableSuccessCode else StripeError.UnreadableErrorCode),
                metadata = metadata) with
                Type = if success then None else Some StripeError.ApiError } }

    ///Why an answer could not be read, with the place in the JSON when the serialiser gives one. Inside a record it
    ///gives the root only, as FSharp.SystemTextJson reads a record's fields itself.
    let private reasonOf (e: JsonException) =
        if isNull e.Path || e.Path = "$" || e.Message.Contains "Path: " then e.Message else $"{e.Message} Path: {e.Path}"

    ///Stripe's error read field by field, for an error body the models can't read in full. An error embeds a payment
    ///intent, payment method, setup intent and source, and one value the models don't list in any of them fails the
    ///typed read. The embedded objects are left out. `None` when the body has no error to read.
    let private errorFields (body: string) : StripeError.ErrorResponse option =
        try
            use doc = JsonDocument.Parse body
            let stringOf (name: string) (element: JsonElement) =
                match element.TryGetProperty name with
                | true, value when value.ValueKind = JsonValueKind.String -> Some value
                | _ -> None
            let error =
                if doc.RootElement.ValueKind <> JsonValueKind.Object then None
                else
                    match doc.RootElement.TryGetProperty "error" with
                    | true, error when error.ValueKind = JsonValueKind.Object -> Some error
                    | _ -> None
            error
            |> Option.bind (fun error ->
                let text name = error |> stringOf name |> Option.map (fun value -> value.GetString())
                let errorType =
                    error |> stringOf "type" |> Option.map (fun value -> Util.deserialise<StripeError.ErrorType> (value.GetRawText()))
                match errorType, text "code", text "message" with
                | None, None, None -> None
                | _, code, message ->
                    Some
                        { StripeError =
                            { StripeError.ErrorObject.New() with
                                Charge = text "charge"
                                Code = code
                                DeclineCode = text "decline_code"
                                DocUrl = text "doc_url"
                                Message = message
                                Param = text "param"
                                Type = errorType } })
        with :? JsonException -> None

    ///Read an answer's status and text as a `Result`. An answer that can't be read is an `Error`. Only the
    ///serialiser's `JsonException` is caught: any other exception is a fault in the library.
    let private readAnswer<'a> (status: int) (requestId: string option) (text: string) : Result<'a, StripeError.ErrorResponse> =
        if status >= 200 && status <= 299 then
            try
                match Util.deserialise<'a> text with
                // A record is never null; a `string` answer can be
                | value when isNull (box value) -> Error (unreadable status requestId "it is null")
                | value -> Ok value
            with :? JsonException as e ->
                Error (unreadable status requestId (reasonOf e))
        elif status >= 300 && status <= 399 then
            Error (redirected status)
        else
            try
                Error (Util.deserialise<StripeError.ErrorResponse> text)
            with :? JsonException as e ->
                errorFields text
                |> Option.defaultWith (fun () -> unreadable status requestId (reasonOf e))
                |> Error

    ///Parse response from API and convert it to a `Result`. An answer that can't be read is an `Error` whose `Code`
    ///is `StripeError.UnreadableSuccessCode` for a 2xx, which must not be sent again, and
    ///`StripeError.UnreadableErrorCode` otherwise.
    let parseResponse<'a> (r: HttpResponse) =
        let requestId =
            r.Headers
            |> Map.tryPick (fun name value ->
                if name.Equals("Request-Id", System.StringComparison.OrdinalIgnoreCase) then Some value else None)
        readAnswer<'a> r.StatusCode requestId (match r.Body with Text t -> t | Binary _ -> "")

    ///Make a `GET` request (without form parameters in the body (default))
    let getAsync<'a> settings queryStringOptions (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        async {
            let! response = Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, customizeHttpRequest = noRedirects, httpMethod = HttpMethod.Get)
            return response |> parseResponse<'a>
        }

    ///Make a `GET` request with form parameters in the body
    let getWithAsync<'a, 'b> settings queryStringOptions (data: 'a) (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        let formValues = data |> Util.serialiseForm |> FormValues
        async {
            let! response = Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, customizeHttpRequest = noRedirects, httpMethod = HttpMethod.Get, body = formValues)
            return response |> parseResponse<'b>
        }

    ///Make a `POST` request (with form parameters in the body (default))
    let postAsync<'a, 'b> settings queryStringOptions (data: 'a) (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        let formValues = data |> Util.serialiseForm |> FormValues
        async {
            let! response = Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, customizeHttpRequest = noRedirects, httpMethod = HttpMethod.Post, body = formValues)
            return response |> parseResponse<'b>
        }

    ///Make a `POST` request without form parameters in the body
    let postWithoutAsync<'a> settings queryStringOptions (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        async {
            let! response = Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, customizeHttpRequest = noRedirects, httpMethod = HttpMethod.Post)
            return response |> parseResponse<'a>
        }

    let private httpClient = lazy (new System.Net.Http.HttpClient(new System.Net.Http.HttpClientHandler(AllowAutoRedirect = false)))

    ///Make a `POST` request with a `multipart/form-data` body to the files host (file uploads).
    ///`FileUpload` fields become file parts; the other form fields are encoded as for `postAsync`.
    let postMultipartAsync<'a, 'b> (settings: StripeApiSettings) queryStringOptions (data: 'a) (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        let formFields =
            FSharpType.GetRecordFields typeof<'a>
            |> Array.filter (fun pi -> pi.GetCustomAttributes(typeof<Config.FormAttribute>, false).Length > 0)
        let fileOf (pi: System.Reflection.PropertyInfo) =
            match pi.GetValue(data, [||]) with
            | :? FileUpload as file -> Some file
            | :? (FileUpload option) as file -> file
            | _ -> None
        let isFileField (pi: System.Reflection.PropertyInfo) =
            pi.PropertyType = typeof<FileUpload> || pi.PropertyType = typeof<FileUpload option>
        // Part names quoted, as RFC 7578 has them and Stripe's own clients send them. An ASCII file
        // name is quoted the same way, in filename only; any other is left to .NET, which encodes it
        // in both filename and filename*.
        let quoted (s: string) = "\"" + s + "\""
        let isPlainAscii (s: string) = s |> Seq.forall (fun c -> c >= ' ' && c <= '~' && c <> '"' && c <> '\\')
        let mediaType (contentType: string) =
            match System.Net.Http.Headers.MediaTypeHeaderValue.TryParse contentType with
            | true, parsed -> parsed
            | _ -> System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream")
        async {
            let! cancellationToken = Async.CancellationToken
            use content = new System.Net.Http.MultipartFormDataContent()
            for pi in formFields do
                if isFileField pi then
                    match fileOf pi with
                    | Some file ->
                        let part = new System.Net.Http.ByteArrayContent(file.Content |> Option.ofObj |> Option.defaultValue [||])
                        part.Headers.ContentType <- mediaType file.ContentType
                        let fileName = if System.String.IsNullOrWhiteSpace file.FileName then "upload" else file.FileName
                        // Add puts the same string in filename and filename*, so the quotes go on afterwards
                        // (in filename*, they would become part of the name).
                        content.Add(part, quoted (Util.snakeCase pi.Name), fileName)
                        if isPlainAscii fileName then
                            part.Headers.ContentDisposition.FileName <- quoted fileName
                            part.Headers.ContentDisposition.FileNameStar <- null
                    | None -> ()
                else
                    for key, value in Util.format pi data do
                        content.Add(new System.Net.Http.StringContent(value), quoted key)
            use request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post, $"{settings.EffectiveFilesBaseUrl}{url}{queryString}", Content = content)
            for name, value in createHeader settings do
                request.Headers.TryAddWithoutValidation(name, value) |> ignore
            use! response = httpClient.Value.SendAsync(request, cancellationToken) |> Async.AwaitTask
            let! body = response.Content.ReadAsStringAsync() |> Async.AwaitTask
            let requestId =
                match response.Headers.TryGetValues "Request-Id" with
                | true, values -> Seq.tryHead values
                | _ -> None
            return readAnswer<'b> (int response.StatusCode) requestId body
        }

    ///Make a `DELETE` request (without form parameters in the body (default))
    let deleteAsync<'a> settings queryStringOptions (url: string) =
        let queryString = queryStringOptions |> formatQueryString
        async {
            let! response = Http.AsyncRequest ($"{settings.BaseUrl}{url}{queryString}", headers = createHeader settings, silentHttpErrors = true, customizeHttpRequest = noRedirects, httpMethod = HttpMethod.Delete)
            return response |> parseResponse<'a>
        }

    ///<summary>Automatically fetches all pages of a Stripe paginated list endpoint, handling the cursor-based
    ///pagination transparently. Calls the list function repeatedly using the ID of the last item in
    ///each page as the <c>starting_after</c> cursor until <c>has_more</c> is false.</summary>
    ///<param name="listFunc">The list function from a StripeRequest module (e.g., <c>Customers.List</c>).</param>
    ///<param name="withStartingAfter">A function that sets the <c>StartingAfter</c> field on the options record.</param>
    ///<param name="getId">A function that extracts the ID from each item in the list.</param>
    ///<param name="settings">The Stripe API settings.</param>
    ///<param name="options">The initial list options.</param>
    ///<returns>An async result containing all items from all pages combined into a single list.</returns>
    let listAllAsync<'item, 'options> (listFunc: StripeApiSettings -> 'options -> Async<Result<StripeList<'item>, StripeError.ErrorResponse>>) (withStartingAfter: string -> 'options -> 'options) (getId: 'item -> string) settings options =
        // Accumulate pages as a list-of-lists (each prepend is O(1)), then concat once at the end (O(n total)).
        let rec loop (acc: 'item list list) (opts: 'options) =
            async {
                let! result = listFunc settings opts
                match result with
                | Error e -> return Error e
                | Ok page ->
                    let acc' = page.Data :: acc
                    if page.HasMore then
                        match page.Data |> List.tryLast with
                        | Some lastItem ->
                            let opts' = withStartingAfter (getId lastItem) opts
                            return! loop acc' opts'
                        | None ->
                            return Ok (acc' |> List.rev |> List.concat)
                    else
                        return Ok (acc' |> List.rev |> List.concat)
            }
        loop [] options

    ///<summary>Fetches every page of a Stripe search. A search continues from the <c>next_page</c> its answer gives,
    ///not from the last item's id, so this passes that on until <c>has_more</c> is false.</summary>
    ///<param name="searchFunc">The search function from a StripeRequest module (e.g., <c>Customers.Search</c>).</param>
    ///<param name="withPage">A function that sets the <c>Page</c> field on the options record.</param>
    ///<param name="settings">The Stripe API settings.</param>
    ///<param name="options">The initial search options.</param>
    ///<returns>An async result containing all items from all pages combined into a single list.</returns>
    let searchAllAsync<'item, 'options> (searchFunc: StripeApiSettings -> 'options -> Async<Result<StripeSearchResult<'item>, StripeError.ErrorResponse>>) (withPage: string -> 'options -> 'options) (settings: StripeApiSettings) (options: 'options) =
        let rec loop (acc: 'item list list) (opts: 'options) =
            async {
                let! result = searchFunc settings opts
                match result with
                | Error e -> return Error e
                | Ok page ->
                    let acc' = page.Data :: acc
                    match page.NextPage with
                    | Some next when page.HasMore -> return! loop acc' (withPage next opts)
                    | _ -> return Ok (acc' |> List.rev |> List.concat)
            }
        loop [] options
