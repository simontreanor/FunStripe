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

If you don't specify the API key in the settings record, it will look for a default test API key to use, and to keep the keys out of source code, it uses [UserSecrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=windows). It is recommended to use `UserSecrets` during development and web-server configuration settings in production, but if your source code will not be made public you can simply specify the API key as a string, at least for testing purposes. `Config.fs` contains some notes to help you.

The `options` can be provided using record notation or if there are many uninitialised properties you can use the static `New` method to instantiate the record more effiently.

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

## Code Generation

By cloning the source repository, as a developer you can use `ModelBuilder.fs` and `RequestBuilder.fs` to generate the code in `StripeModel.fs` and `StripeRequest.fs` respectively.

Using Visual Studio Code, you simply select all the text in each document and hit `Alt + Enter` to send the code to F# Interactive. This will overwrite the contents of the target modules.

The `spec/` directory contains several historical Stripe OpenAPI specifications, with `stripe-openapi-2026-04-22.dahlia.json` used as the default for code generation. The current default path is set in `ModelBuilder.fs` and `RequestBuilder.fs`. To regenerate against a different version, pass the desired spec file path as a parameter, or update the default path in those files. To use a spec version not already included, download it from the link in the References section and place it in the `spec/` directory with the API version in the filename.

You could also customise how the source code is represented by editing the builder code files.

## References

[Stripe Documentation](https://stripe.com/docs)

[Developer Tools](https://stripe.com/docs/development)

[API Reference](https://stripe.com/docs/api)

[Official Stripe .NET Library](https://github.com/stripe/stripe-dotnet)

[Stripe OpenAPI Specification](https://raw.githubusercontent.com/stripe/openapi/master/openapi/spec3.sdk.json)

