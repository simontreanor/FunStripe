/// Answers that can't be read, and webhook headers no sender of Stripe's would write.
module FunStripe.AnswerTests

open System
open FSharp.Data
open NUnit.Framework
open FunStripe
open FunStripe.WebhookSigning

let private answer (status: int) (headers: (string * string) list) (body: string) : HttpResponse =
    { Body = Text body
      StatusCode = status
      ResponseUrl = "https://api.stripe.com/v1/issuing/disputes/idp_1"
      Headers = Map.ofList headers
      Cookies = Map.empty }

let private read (status: int) (body: string) =
    RestApi.parseResponse<Stripe.PaymentMethod.IssuingDispute> (answer status [] body)

[<TestCase(502, "<html><body>502 Bad Gateway</body></html>")>]
[<TestCase(500, "")>]
[<TestCase(400, "{}")>]
[<TestCase(400, "null")>]
[<TestCase(402, """{"error":{"payment_method_type":"a_type_of_tomorrow"}}""")>]
let ``an error answer that can't be read is an api_error with its own code`` (status: int, body: string) =
    match read status body with
    | Error e ->
        Assert.That(e.StripeError.Message.Value, Does.StartWith $"Stripe answered HTTP {status}, and the answer could not be read")
        Assert.That(e.StripeError.Code, Is.EqualTo(Some StripeError.UnreadableErrorCode))
        Assert.That(e.StripeError.Type, Is.EqualTo(Some StripeError.ApiError))
        Assert.That(e.StripeError.Metadata, Is.EqualTo(Some(Map.ofList [ "http_status", string status ])))
    | Ok _ -> Assert.Fail "An answer that can't be read isn't a success"

[<TestCase(200, "")>]
[<TestCase(200, "null")>]
[<TestCase(200, "{}")>]
[<TestCase(201, "<html></html>")>]
[<TestCase(200, """{"id":"idp_1","object":"issuing.dispute","status":"a_status_of_tomorrow"}""")>]
let ``a 2xx that can't be read has its own code and no type, as Stripe has done the work`` (status: int, body: string) =
    match read status body with
    | Error e ->
        Assert.That(e.StripeError.Message.Value, Does.StartWith $"Stripe answered HTTP {status}, and the answer could not be read")
        Assert.That(e.StripeError.Code, Is.EqualTo(Some StripeError.UnreadableSuccessCode))
        Assert.That(e.StripeError.Type, Is.EqualTo(None: StripeError.ErrorType option))
        Assert.That(e.StripeError.Metadata, Is.EqualTo(Some(Map.ofList [ "http_status", string status ])))
    | Ok _ -> Assert.Fail "An answer that can't be read isn't a success"

[<TestCase("Request-Id")>]
[<TestCase("request-id")>]
let ``an answer that can't be read carries Stripe's request id`` (header: string) =
    let unreadable = answer 200 [ header, "req_123"; "Content-Type", "application/json" ] "<html></html>"

    match RestApi.parseResponse<Stripe.PaymentMethod.IssuingDispute> unreadable with
    | Error e ->
        Assert.That(e.StripeError.Metadata, Is.EqualTo(Some(Map.ofList [ "http_status", "200"; "request_id", "req_123" ])))
    | Ok _ -> Assert.Fail "An answer that can't be read isn't a success"

[<Test>]
let ``an answer that can't be read names the value and its type`` () =
    match read 200 """{"id":"idp_1","object":"issuing.dispute","status":"a_status_of_tomorrow"}""" with
    | Error e ->
        Assert.That(e.StripeError.Message.Value, Does.Contain "'a_status_of_tomorrow'")
        Assert.That(e.StripeError.Message.Value, Does.Contain "IssuingDisputeStatus")
    | Ok _ -> Assert.Fail "An answer that can't be read isn't a success"

[<Test>]
let ``a string answer that is null is an Error`` () =
    match RestApi.parseResponse<string> (answer 200 [] "null") with
    | Error e -> Assert.That(e.StripeError.Code, Is.EqualTo(Some StripeError.UnreadableSuccessCode))
    | Ok _ -> Assert.Fail "null isn't an answer"

[<Test>]
let ``Stripe's own error is read as before`` () =
    match read 404 """{"error":{"type":"invalid_request_error","message":"No such dispute","code":"resource_missing"}}""" with
    | Error e ->
        Assert.That(e.StripeError.Message, Is.EqualTo(Some "No such dispute"))
        Assert.That(e.StripeError.Type, Is.EqualTo(Some StripeError.InvalidRequestError))
        Assert.That(e.StripeError.Code, Is.EqualTo(Some "resource_missing"))
        Assert.That(e.StripeError.Metadata, Is.EqualTo(None: Map<string, string> option))
    | Ok _ -> Assert.Fail "A 404 isn't a success"

[<Test>]
let ``a decline stays a decline when a value in its body isn't in the models`` () =
    let body =
        """{"error":{"type":"card_error","code":"card_declined","decline_code":"insufficient_funds",
            "message":"Your card has insufficient funds.","param":"payment_method","charge":"ch_1",
            "doc_url":"https://stripe.com/docs/error-codes/card-declined",
            "payment_method_type":"a_type_of_tomorrow",
            "payment_method":{"id":"pm_1","object":"payment_method","type":"a_type_of_tomorrow"}}}"""

    match read 402 body with
    | Error e ->
        Assert.That(e.StripeError.Type, Is.EqualTo(Some StripeError.CardError))
        Assert.That(e.StripeError.Code, Is.EqualTo(Some "card_declined"))
        Assert.That(e.StripeError.DeclineCode, Is.EqualTo(Some "insufficient_funds"))
        Assert.That(e.StripeError.Message, Is.EqualTo(Some "Your card has insufficient funds."))
        Assert.That(e.StripeError.Param, Is.EqualTo(Some "payment_method"))
        Assert.That(e.StripeError.Charge, Is.EqualTo(Some "ch_1"))
        Assert.That(e.StripeError.DocUrl, Is.EqualTo(Some "https://stripe.com/docs/error-codes/card-declined"))
        Assert.That(e.StripeError.PaymentMethod, Is.EqualTo(None: Stripe.PaymentMethod.PaymentMethod option))
    | Ok _ -> Assert.Fail "A 402 isn't a success"

[<Test>]
let ``an error type of tomorrow is kept when its body can't be read in full`` () =
    match read 400 """{"error":{"type":"a_type_of_tomorrow","message":"No","payment_method_type":"a_type_of_tomorrow"}}""" with
    | Error e ->
        Assert.That(e.StripeError.Type, Is.EqualTo(Some(StripeError.UnknownEnumValue "a_type_of_tomorrow")))
        Assert.That(e.StripeError.Message, Is.EqualTo(Some "No"))
    | Ok _ -> Assert.Fail "A 400 isn't a success"

[<TestCase("\"a_brand_of_tomorrow\"", typeof<Stripe.PaymentMethod.PaymentMethodCardBrand>)>]
[<TestCase("true", typeof<Stripe.PaymentMethod.PaymentMethodCardBrand>)>]
[<TestCase("\"not a date\"", typeof<DateTime>)>]
[<TestCase("true", typeof<DateTime>)>]
[<TestCase("1.5", typeof<DateTime>)>]
[<TestCase("-99999999999999", typeof<DateTime>)>]
[<TestCase("9223372036854775807", typeof<DateTime>)>]
[<TestCase("{\"object\":\"customer\"}", typeof<StripeIds.StripeId<Markers.Customer>>)>]
[<TestCase("5", typeof<StripeIds.StripeId<Markers.Customer>>)>]
[<TestCase("{\"object\":null}", typeof<Stripe.Checkout.CheckoutSessionCustomer'AnyOf>)>]
[<TestCase("{\"object\":5}", typeof<Stripe.Checkout.CheckoutSessionCustomer'AnyOf>)>]
[<TestCase("{\"object\":\"thing_of_tomorrow\"}", typeof<Stripe.Checkout.CheckoutSessionCustomer'AnyOf>)>]
let ``JSON the converters can't read fails as a JsonException`` (json: string, target: Type) =
    Assert.Throws<Text.Json.JsonException>(fun () ->
        Text.Json.JsonSerializer.Deserialize(json, target, Json.StripeConverter.sharedOptions.Value) |> ignore)
    |> ignore

let private sign (secret: string) (timestamp: int64) (body: string) =
    use hmac = new Security.Cryptography.HMACSHA256(Text.Encoding.UTF8.GetBytes secret)

    let signature =
        hmac.ComputeHash(Text.Encoding.UTF8.GetBytes $"{timestamp}.{body}")
        |> Array.map (fun b -> b.ToString "x2")
        |> String.concat ""

    $"t={timestamp},v1={signature}"

[<TestCase("")>]
[<TestCase(" ")>]
[<TestCase(null)>]
let ``an empty secret verifies nothing, though anyone can sign with it`` (secret: string) =
    let now = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
    let header = sign (if isNull secret then "" else secret) now "{}"

    match verifySignature secret "{}" header defaultTolerance with
    | Error(SignatureMismatch _) -> ()
    | other -> Assert.Fail $"%A{other}"

[<Test>]
let ``a request without the signature header is an InvalidHeader, and nothing is thrown`` () =
    match verifySignature "whsec_test" "{}" null defaultTolerance with
    | Error(InvalidHeader _) -> ()
    | other -> Assert.Fail $"%A{other}"

    match parseHeader null with
    | Error(InvalidHeader _) -> ()
    | other -> Assert.Fail $"%A{other}"

[<Test>]
let ``a timestamp with no age to take is out of tolerance, and nothing is thrown`` () =
    // now - t is the one number without an absolute value, in the second the check reads the time
    for _ in 1..3 do
        let t = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + Int64.MinValue

        match verifySignature "whsec_test" "{}" $"t={t},v1=00" defaultTolerance with
        | Error(TimestampOutOfTolerance _) -> ()
        | other -> Assert.Fail $"%A{other}"

    for t in [ Int64.MinValue; Int64.MaxValue ] do
        match verifySignature "whsec_test" "{}" $"t={t},v1=00" defaultTolerance with
        | Error(TimestampOutOfTolerance _) -> ()
        | other -> Assert.Fail $"%A{other}"

[<Test>]
let ``a signature within the tolerance on either side of now still verifies`` () =
    let now = DateTimeOffset.UtcNow.ToUnixTimeSeconds()

    for offset in [ -290L; 0L; 290L ] do
        let header = sign "whsec_test" (now + offset) "{}"
        Assert.That(verifySignature "whsec_test" "{}" header defaultTolerance, Is.EqualTo(Ok(): Result<unit, WebhookError>))

    for offset in [ -310L; 310L ] do
        match verifySignature "whsec_test" "{}" (sign "whsec_test" (now + offset) "{}") defaultTolerance with
        | Error(TimestampOutOfTolerance _) -> ()
        | other -> Assert.Fail $"%A{other}"
