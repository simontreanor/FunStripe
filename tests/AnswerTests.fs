/// Answers that can't be read, and webhook headers no sender of Stripe's would write.
module FunStripe.AnswerTests

open System
open FSharp.Data
open NUnit.Framework
open FunStripe
open FunStripe.WebhookSigning

let private answer (status: int) (body: string) : HttpResponse =
    { Body = Text body
      StatusCode = status
      ResponseUrl = "https://api.stripe.com/v1/issuing/disputes/idp_1"
      Headers = Map.empty
      Cookies = Map.empty }

let private read (status: int) (body: string) =
    RestApi.parseResponse<Stripe.PaymentMethod.IssuingDispute> (answer status body)

[<TestCase(502, "<html><body>502 Bad Gateway</body></html>")>]
[<TestCase(500, "")>]
[<TestCase(400, "{}")>]
[<TestCase(400, "null")>]
[<TestCase(200, "")>]
[<TestCase(200, "null")>]
[<TestCase(200, "<html></html>")>]
[<TestCase(200, """{"id":"idp_1","object":"issuing.dispute","status":"a_status_of_tomorrow"}""")>]
let ``an answer that can't be read is an Error that says so`` (status: int, body: string) =
    match read status body with
    | Error e ->
        Assert.That(e.StripeError.Message.Value, Does.StartWith $"Stripe answered HTTP {status}, and the answer could not be read")
        Assert.That(e.StripeError.Type, Is.EqualTo(Some StripeError.ApiError))
    | Ok _ -> Assert.Fail "An answer that can't be read isn't a success"

[<Test>]
let ``Stripe's own error is read as before`` () =
    match read 404 """{"error":{"type":"invalid_request_error","message":"No such dispute","code":"resource_missing"}}""" with
    | Error e ->
        Assert.That(e.StripeError.Message, Is.EqualTo(Some "No such dispute"))
        Assert.That(e.StripeError.Type, Is.EqualTo(Some StripeError.InvalidRequestError))
    | Ok _ -> Assert.Fail "A 404 isn't a success"

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
