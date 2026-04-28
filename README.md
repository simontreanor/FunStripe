# FunStripe

An F# library to connect to the Stripe API, including code generators to update the model and requests. Targets .NET Standard 2.0 and .NET Standard 2.1.

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for version history.

## Installation

Get the latest version of FunStripe.Core from [NuGet](https://www.nuget.org/packages/FunStripe.Core/). For Fable/Node.js projects, use [FunStripe.Core.Fable](https://www.nuget.org/packages/FunStripe.Core.Fable/) instead.

## Usage

Open the StripeModel and StripeRequest modules.

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
open FunStripe.StripeRequest

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
| Code generation (`ModelBuilder`, `RequestBuilder`) | ✅ via `FunStripe.Generator` | ❌ not needed |

### Code generation

Code generation (`ModelBuilder.fs`, `RequestBuilder.fs`) uses `Fabulous.AST` which is
.NET-only.  It is intentionally excluded from the Fable package.  Run code generation with
`dotnet fsi` on the .NET side and commit the generated `StripeModel.fs` /
`StripeRequest.fs` into your repository.

## Partial API Loading

FunStripe's API requests are split into resource groups to reduce compile-time overhead and improve build performance, especially for WASM/browser targets. The `Core` group is always included. All other groups are included by default but can be excluded via MSBuild properties.

### Available Resource Groups

| Group                  | Description                                                  | MSBuild Property                           |
|------------------------|--------------------------------------------------------------|--------------------------------------------|
| Core                   | Accounts, Payments, Customers, Transfers, etc. (always on) | *(always included)*                        |
| Connect                | Platform accounts, application fees, secrets               | `FunStripeExcludeConnect=true`             |
| Billing                | Subscriptions, Invoices, Coupons, Quotes, Tax, etc.        | `FunStripeExcludeBilling=true`             |
| Checkout               | Checkout Sessions                                          | `FunStripeExcludeCheckout=true`            |
| FinancialConnections   | Financial Connections accounts and sessions                | `FunStripeExcludeFinancialConnections=true`|
| Identity               | Identity Verification Reports and Sessions                 | `FunStripeExcludeIdentity=true`            |
| Issuing                | Issuing cards, cardholders, authorisations, etc.           | `FunStripeExcludeIssuing=true`             |
| PaymentLinks           | Payment Links                                              | `FunStripeExcludePaymentLinks=true`        |
| Radar                  | Radar fraud warnings and value lists                       | `FunStripeExcludeRadar=true`               |
| Reporting              | Reporting runs and report types                            | `FunStripeExcludeReporting=true`           |
| Sigma                  | Sigma scheduled query runs                                 | `FunStripeExcludeSigma=true`               |
| Terminal               | Terminal configurations, locations, readers, etc.          | `FunStripeExcludeTerminal=true`            |
| TestHelpers            | Test mode helper endpoints                                 | `FunStripeExcludeTestHelpers=true`         |
| Treasury               | Treasury financial accounts, transfers, etc.               | `FunStripeExcludeTreasury=true`            |

### Example: Core + Billing only

To compile only Core and Billing (skipping all other groups), add the following to your project file:

```xml
<PropertyGroup>
  <FunStripeExcludeConnect>true</FunStripeExcludeConnect>
  <FunStripeExcludeCheckout>true</FunStripeExcludeCheckout>
  <FunStripeExcludeFinancialConnections>true</FunStripeExcludeFinancialConnections>
  <FunStripeExcludeIdentity>true</FunStripeExcludeIdentity>
  <FunStripeExcludeIssuing>true</FunStripeExcludeIssuing>
  <FunStripeExcludePaymentLinks>true</FunStripeExcludePaymentLinks>
  <FunStripeExcludeRadar>true</FunStripeExcludeRadar>
  <FunStripeExcludeReporting>true</FunStripeExcludeReporting>
  <FunStripeExcludeSigma>true</FunStripeExcludeSigma>
  <FunStripeExcludeTerminal>true</FunStripeExcludeTerminal>
  <FunStripeExcludeTestHelpers>true</FunStripeExcludeTestHelpers>
  <FunStripeExcludeTreasury>true</FunStripeExcludeTreasury>
</PropertyGroup>
```

Or pass directly to `dotnet build`:

```sh
dotnet build -p:FunStripeExcludeIssuing=true -p:FunStripeExcludeTreasury=true
```

## Code Generation

By cloning the source repository, as a developer you can use `ModelBuilder.fs` and `RequestBuilder.fs` to generate the code in `StripeModel.fs` and the per-resource-group `StripeRequest.<Group>.fs` files respectively.

Using Visual Studio Code, you simply select all the text in each document and hit `Alt + Enter` to send the code to F# Interactive. This will overwrite the contents of the target modules.

The `spec/` directory contains several historical Stripe OpenAPI specifications, with `stripe-openapi-2026-04-22.dahlia.json` used as the default for code generation. The current default path is set in `ModelBuilder.fs` and `RequestBuilder.fs`. To regenerate against a different version, pass the desired spec file path as a parameter, or update the default path in those files. To use a spec version not already included, download it from the link in the References section and place it in the `spec/` directory with the API version in the filename.

Running the `RequestBuilder.fs` interactive code generates all per-group files (`StripeRequest.Core.fs`, `StripeRequest.Billing.fs`, etc.) as well as the legacy monolithic `StripeRequest.fs` for reference. The per-group files are the ones included in the compiled project.

You could also customise how the source code is represented by editing the builder code files.

## Comparison with Stripe.net

[Stripe.net](https://github.com/stripe/stripe-dotnet) is the official Stripe library for .NET, maintained by the Stripe team. FunStripe is a community-maintained library written specifically for F#. Here are some reasons why an F# developer might prefer FunStripe:

### Idiomatic F# design

FunStripe is written in F# for F# developers. API responses are returned as `AsyncResult<'T, ErrorResponse>`, which integrates naturally with F# async workflows and computation expressions, letting you handle success and error cases without exceptions using standard F# pattern matching. Stripe.net, being a C# library, uses exceptions for error handling and does not provide the same level of F# ergonomics.

### Strong typing with discriminated unions

All enumerated values (field types, event types, error codes, webhook event kinds) are represented as F# discriminated unions rather than plain strings. This enables exhaustive pattern matching and gives compile-time confidence that all cases are handled. In Stripe.net, these values are typically plain strings or string constants.

### Full API coverage

FunStripe aims to cover the full Stripe API surface and tracks each Stripe API release version. `ModelBuilder.fs` and `RequestBuilder.fs` regenerate `StripeModel.fs` and `StripeRequest.fs` directly from the Stripe OpenAPI specification, making it straightforward to adopt new API versions. Stripe.net's model is maintained by Stripe rather than derived from the public OpenAPI spec, so the generation process is not available to contributors.

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

