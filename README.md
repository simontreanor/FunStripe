# FunStripe

An F# library to connect to the Stripe API, including code generators to update the model and requests. Targets .NET Standard 2.0 and .NET Standard 2.1.

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for version history.

## Installation

Get the latest version of FunStripe.Core from [NuGet](https://www.nuget.org/packages/FunStripe.Core/). For Fable/Node.js projects, use [FunStripe.Core.Fable](https://www.nuget.org/packages/FunStripe.Core.Fable/) instead.

## Usage

FunStripe types are organised into per-domain namespaces:

- Response models live under `Stripe.{Domain}` (e.g. `Stripe.PaymentMethod`, `Stripe.Customer`, `Stripe.Invoice`).
- Request option records live under `StripeRequest.{Domain}` (e.g. `StripeRequest.Payment`, `StripeRequest.Customers`).

Open the domains you need:

```F#
open Stripe.PaymentMethod
open StripeRequest.Payment
```

Here's an example of how to create a new payment method:

```F#
let settings = RestApi.StripeApiSettings.New(apiKey = Config.StripeTestApiKey)

let getNewPaymentMethod () =
    asyncResult {
        return! 
            PaymentMethods.CreateOptions.New(
                card = Choice2Of2 (PaymentMethods.Create'CardTokenParams.New("tok_visa")),
                type' = PaymentMethods.Create'Type.Card
            )
            |> PaymentMethods.Create settings
    }
```

The result value is an `AsyncResult<PaymentMethod,ErrorResponse>`, giving you the requested object in case of success or a detailed error response if not.

The general format of API requests is `<module>`.`<method>` `settings` `options`.

To instantiate the `settings` you need to pass in your Stripe API key. Having local rather than global settings allows you to use different keys for different Stripe accounts if you need to.

## Idempotency Keys

For mutating requests (e.g. creating a charge), Stripe supports an `Idempotency-Key` header to safely retry requests without accidentally performing the same operation twice. You should supply a deterministic key derived from the operation — typically a stable GUID you generate and store alongside the operation.

You can set an idempotency key when creating settings:

```F#
let settings = RestApi.StripeApiSettings.New(apiKey = "<your Stripe API key>", idempotencyKey = "my-unique-operation-id")
```

Or, more conveniently, use `WithIdempotencyKey` to apply a key per-request without affecting your base settings:

```F#
let createPaymentMethod idempotencyKey =
    asyncResult {
        return!
            PaymentMethods.CreateOptions.New(
                card = Choice2Of2 (PaymentMethods.Create'CardTokenParams.New("tok_visa")),
                type' = PaymentMethods.Create'Type.Card
            )
            |> PaymentMethods.Create (settings.WithIdempotencyKey(idempotencyKey))
    }
```

The idempotency key is propagated transparently through the `AsyncResult`-based wrappers. Keys are never auto-generated — the caller always controls key derivation to guarantee retry safety.

If you don't specify the API key in the settings record, it will look for a default test API key to use, and to keep the keys out of source code, it uses [UserSecrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=windows). It is recommended to use `UserSecrets` during development and web-server configuration settings in production, but if your source code will not be made public you can simply specify the API key as a string, at least for testing purposes. `Config.fs` contains some notes to help you.

The `options` can be provided using record notation or if there are many uninitialised properties you can use the static `New` method to instantiate the record more efficiently.

### Paginated Lists

All list endpoints return a `StripeList<'T>` that includes the current page of items alongside the pagination metadata:

```F#
let listOptions = Customers.ListOptions.New(limit = 10)
let! page = Customers.List settings listOptions
// page.Data  — the current page of Customer records
// page.HasMore — true if more pages are available
// page.Url    — the endpoint URL
```

To automatically fetch all pages and combine them into a single list, use `RestApi.listAllAsync`:

```F#
let! allCustomers =
    RestApi.listAllAsync
        Customers.List
        (fun id opts -> { opts with StartingAfter = Some id })
        (fun (c: Customer) -> c.Id)
        settings
        (Customers.ListOptions.New())
// allCustomers is Result<Customer list, ErrorResponse>
```

## Stripe API version

FunStripe targets a specific Stripe API date-version. The version this build was generated from is exposed as a constant:

```F#
Config.DefaultStripeApiVersion  // e.g. "2026-04-22.dahlia"
```

It is also embedded as an assembly-level attribute (`Config.StripeApiVersionAttribute`) and in the NuGet package tags, giving downstream projects an auditable record of the API surface they are compiled against.

By default, FunStripe does **not** send a `Stripe-Version` request header, so Stripe uses the version pinned to your account. If you want every request to be explicitly tied to the library's target API version — useful when upgrading or for forward-compatibility testing — pass it through `StripeApiSettings`:

```F#
let settings =
    RestApi.StripeApiSettings.New(
        apiKey = Config.StripeTestApiKey,
        stripeVersion = Config.DefaultStripeApiVersion
    )
```

To test against a **newer** Stripe API version before upgrading the library, supply the target date directly:

```F#
let settings =
    RestApi.StripeApiSettings.New(
        apiKey = Config.StripeTestApiKey,
        stripeVersion = "2026-04-22.dahlia"   // override for forward-compatibility testing
    )
```

See [CHANGELOG.md](CHANGELOG.md) for the full FunStripe version → Stripe API version compatibility table.

## Fable (Node.js) Support

FunStripe.Core can be compiled to JavaScript via [Fable](https://fable.io) using the companion
[FunStripe.Core.Fable](https://www.nuget.org/packages/FunStripe.Core.Fable/) package.  This targets **Node.js server-side** scripts written in F#.

> [!WARNING]
> **Do not use this package in browser applications.**
> Calling the Stripe REST API directly from a browser requires embedding a Stripe API key in
> the client, where it is trivially extractable from network traffic or the JS bundle.  Even
> a *publishable* key grants more access than should be exposed client-side, and a *secret*
> key would expose your full Stripe account to anyone who inspects your app.
>
> For browser-side card collection, use
> [Stripe.js / Stripe Elements](https://stripe.com/docs/js) instead — it keeps all sensitive
> data within Stripe's own iframe and never touches your server with raw card details.

### Installation

Reference the `FunStripe.Core.Fable` NuGet package from your Fable/Node.js project instead of
`FunStripe.Core`.  `Fable.SimpleHttp` and `Thoth.Json` are pulled in automatically as
transitive dependencies.

### Usage

The public API is identical to the regular .NET edition.  Your Stripe **secret key**
(`sk_test_...` / `sk_live_...`) stays on the server, exactly as in the .NET version:

```fsharp
open FunStripe
open FunStripe.RestApi
open Stripe.PaymentMethod
open StripeRequest.Payment

// Secret key — server-side only, never expose this in a browser bundle.
// Find yours at https://dashboard.stripe.com/apikeys
let settings = StripeApiSettings.New(apiKey = "<your-secret-key>")

let createPaymentMethod () =
    asyncResult {
        return!
            PaymentMethods.CreateOptions.New(
                card = Choice2Of2 (PaymentMethods.Create'CardTokenParams.New("tok_visa")),
                type' = PaymentMethods.Create'Type.Card
            )
            |> PaymentMethods.Create settings
    }
```

### Platform differences

| Feature | .NET (`FunStripe.Core`) | Fable (`FunStripe.Core.Fable`) |
|---------|------------------------|--------------------------------|
| Target runtime | .NET (server) | Node.js (server) |
| HTTP layer | `FSharp.Data` (`HttpClient`) | `Fable.SimpleHttp` (Node.js fetch) |
| JSON parsing | `FSharp.Data.JsonValue` | `Thoth.Json` |
| JSON serialisation (`Util.serialise`) | ✅ available | ❌ not available |
| Code generation (`FunStripe.Generator`) | ✅ runs on .NET | ❌ not needed |

### Code generation

Code generation is .NET-only and intentionally excluded from the Fable package.
Run the generator with `dotnet run` (see below) and commit the generated files
under `src/Stripe/`, `src/StripeRequest/`, and `src/StripeIds.fs` into your
repository.

## Modular file layout

`FunStripe.Core` is generated as a set of per-domain F# files rather than a single monolith:

- `src/Stripe/{Domain}.fs` — response models grouped by Stripe domain (e.g. `PaymentMethod.fs`, `Customer.fs`, `Invoice.fs`). Each file declares `namespace Stripe.{Domain}`.
- `src/StripeRequest/{Domain}.fs` — request option records and call-site modules (e.g. `Payment.fs`, `Customers.fs`). Each file declares `namespace StripeRequest.{Domain}`.
- `src/StripeIds.fs` — phantom-typed `StripeId<'phantom>` and `StripeList<'T>`, auto-opened so the wrappers are available everywhere without an explicit `open`.

The two folders are wired into the project via auto-generated MSBuild props files (`src/Stripe/Stripe.Modular.props` and `src/StripeRequest/StripeRequest.Modular.props`), imported by both `FunStripe.Core.fsproj` and `FunStripe.Core.Fable.fsproj`. Compile order is determined by the generator from the schema dependency graph.

## Code Generation

By cloning the source repository, you can regenerate the modular files using the `FunStripe.Generator` console tool:

```sh
dotnet run --project tools/FunStripe.Generator -- \
  --spec spec/stripe-openapi-2026-04-22.dahlia.json \
  --output src \
  --version 1.0.0
```

All three arguments are optional and default to the values shown above. The generator emits:

- `src/StripeIds.fs`
- `src/Stripe/{Domain}.fs` plus `src/Stripe/Stripe.Modular.props`
- `src/StripeRequest/{Domain}.fs` plus `src/StripeRequest/StripeRequest.Modular.props`

The `spec/` directory contains several historical Stripe OpenAPI specifications, with `stripe-openapi-2026-04-22.dahlia.json` used as the default. To regenerate against a different version, pass its path via `--spec`. To use a spec version not already included, download it from the link in the References section and place it in the `spec/` directory with the API version in the filename.

A **Regenerate source files** GitHub Actions workflow (`.github/workflows/regenerate.yml`) is also provided. Trigger it manually from the Actions tab; it will run the generator and open a pull request if any files changed.

The generator sources live under `tools/FunStripe.Generator/` (notably `ModelBuilderModular.fs`, `RequestBuilderAST.fs`, and `StripeIdsBuilder.fs`); customise emission by editing those files.

## Comparison with Stripe.net

[Stripe.net](https://github.com/stripe/stripe-dotnet) is the official Stripe library for .NET, maintained by the Stripe team. FunStripe is a community-maintained library written specifically for F#. Here are some reasons why an F# developer might prefer FunStripe:

### Idiomatic F# design

FunStripe is written in F# for F# developers. API responses are returned as `AsyncResult<'T, ErrorResponse>`, which integrates naturally with F# async workflows and computation expressions, letting you handle success and error cases without exceptions using standard F# pattern matching. Stripe.net, being a C# library, uses exceptions for error handling and does not provide the same level of F# ergonomics.

### Strong typing with discriminated unions

All enumerated values (field types, event types, error codes, webhook event kinds) are represented as F# discriminated unions rather than plain strings. This enables exhaustive pattern matching and gives compile-time confidence that all cases are handled. In Stripe.net, these values are typically plain strings or string constants.

### Full API coverage

FunStripe aims to cover the full Stripe API surface and tracks each Stripe API release version. The `FunStripe.Generator` console tool regenerates the per-domain `Stripe.{Domain}` and `StripeRequest.{Domain}` files directly from the Stripe OpenAPI specification, making it straightforward to adopt new API versions. Stripe.net's model is maintained by Stripe rather than derived from the public OpenAPI spec, so the generation process is not available to contributors.

### Summary

| Feature | FunStripe | Stripe.net |
|---|---|---|
| Language | F# | C# |
| Error handling | `AsyncResult` | Exceptions |
| Enum types | Discriminated unions | Strings |
| Webhook event types | Discriminated unions | Strings |
| API coverage | Full | Full |
| Code generation | Yes (from OpenAPI spec) | No |
| Maintained by | Community (F# focused) | Stripe |

If you need official Stripe support or are working primarily in C#, Stripe.net is the right choice. If you want idiomatic F# with strong typing and tracked Stripe API versions, FunStripe is a great fit.

## References

[Stripe Documentation](https://stripe.com/docs)

[Developer Tools](https://stripe.com/docs/development)

[API Reference](https://stripe.com/docs/api)

[Official Stripe .NET Library](https://github.com/stripe/stripe-dotnet)

[Stripe OpenAPI Specification](https://raw.githubusercontent.com/stripe/openapi/master/openapi/spec3.sdk.json)

