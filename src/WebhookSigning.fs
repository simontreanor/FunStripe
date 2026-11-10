namespace FunStripe

open System
open System.Security.Cryptography
open System.Text

///Helper for verifying Stripe webhook signatures.
///See https://stripe.com/docs/webhooks/signatures
module WebhookSigning =

    ///Errors that can occur when verifying a webhook signature
    type WebhookError =
        ///The Stripe-Signature header is missing or malformed
        | InvalidHeader of string
        ///The webhook timestamp is outside the tolerance window
        | TimestampOutOfTolerance of string
        ///The computed signature does not match any of the signatures in the header
        | SignatureMismatch of string

    ///Default tolerance window in seconds (300 seconds = 5 minutes)
    let defaultTolerance = 300

    ///Parse the Stripe-Signature header into a Unix timestamp and a list of v1 signatures.
    ///Returns the parsed components so callers can inspect or log suspicious headers.
    let parseHeader (header: string) =
        let parts = header.Split(',')
        let mutable timestamp: int64 option = None
        let mutable signatures: string list = []
        for part in parts do
            let kv = part.Split([|'='|], 2)
            if kv.Length = 2 then
                match kv.[0].Trim() with
                | "t" ->
                    match Int64.TryParse(kv.[1].Trim()) with
                    | true, ts -> timestamp <- Some ts
                    | false, _ -> ()
                | "v1" ->
                    signatures <- kv.[1].Trim() :: signatures
                | _ -> ()
        match timestamp, signatures with
        | None, _ -> Error (InvalidHeader "Missing or invalid timestamp in Stripe-Signature header")
        | _, [] -> Error (InvalidHeader "Missing v1 signature in Stripe-Signature header")
        | Some ts, sigs -> Ok (ts, sigs)

    ///Compute an HMAC-SHA256 hex digest of the payload using the given secret
    let private computeSignature (secret: string) (payload: string) =
        let keyBytes = Encoding.UTF8.GetBytes(secret)
        let payloadBytes = Encoding.UTF8.GetBytes(payload)
        use hmac = new HMACSHA256(keyBytes)
        hmac.ComputeHash(payloadBytes)
        |> Array.map (fun b -> b.ToString("x2"))
        |> String.concat ""

    ///Constant-time comparison of two strings to prevent timing attacks
    let private constantTimeEquals (a: string) (b: string) =
        if a.Length <> b.Length then
            false
        else
            let mutable result = 0
            for i in 0 .. a.Length - 1 do
                result <- result ||| (int a.[i] ^^^ int b.[i])
            result = 0

    ///Verify the Stripe-Signature header for a webhook payload.
    ///
    ///<param name="secret">The webhook endpoint's signing secret from the Stripe dashboard.</param>
    ///<param name="rawBody">The raw (unparsed) request body string as received from Stripe.</param>
    ///<param name="header">The value of the Stripe-Signature header.</param>
    ///<param name="tolerance">Maximum age in seconds for a webhook timestamp (use defaultTolerance for 300 s).</param>
    ///Returns Ok () if the signature is valid, or Error with a WebhookError describing the failure.
    ///An empty secret is a SignatureMismatch.
    let verifySignature (secret: string) (rawBody: string) (header: string) (tolerance: int) : Result<unit, WebhookError> =
        // Anyone can compute an HMAC keyed with nothing, so an empty secret verifies nothing
        if String.IsNullOrWhiteSpace secret then
            Error (SignatureMismatch "The signing secret is empty, so no signature can be verified")
        else
        match parseHeader header with
        | Error e -> Error e
        | Ok (timestamp, signatures) ->
            let currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            // Compared without a difference: t is the sender's, and one at the far end of its range has no age to take
            let withinTolerance =
                timestamp >= currentTime - int64 tolerance && timestamp <= currentTime + int64 tolerance
            if not withinTolerance then
                Error (TimestampOutOfTolerance (sprintf "Webhook timestamp %d is more than %d seconds from now" timestamp tolerance))
            else
                let signedPayload = sprintf "%d.%s" timestamp rawBody
                let computedSig = computeSignature secret signedPayload
                let isValid = signatures |> List.exists (constantTimeEquals computedSig)
                if isValid then
                    Ok ()
                else
                    Error (SignatureMismatch "Computed HMAC-SHA256 signature does not match any v1 signature in the Stripe-Signature header")

    ///Verify a Stripe webhook using the default 5-minute tolerance window.
    ///Equivalent to calling verifySignature with defaultTolerance.
    let verifyWithDefaultTolerance (secret: string) (rawBody: string) (header: string) : Result<unit, WebhookError> =
        verifySignature secret rawBody header defaultTolerance
