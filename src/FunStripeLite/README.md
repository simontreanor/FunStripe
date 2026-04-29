# FunStripeLite

A lightweight F# library to connect to the Stripe API. Targets .NET Standard 2.0 and .NET Standard 2.1.

## Latest updates

2025-02-24: version 1.4.3 updates model generation. Moved FunStripeLite repository under FunStripe.

2025-01-21: version 1.4.1 updates FSharp.Core to version 9.0.101 and FSharp.Data to 6.4.1.

2023-12-06: version 1.4.0 changes the target frameworks to .NET Standard 2.0 and .NET Standard 2.1 and updates FSharp.Core to version 8.0.100.

2023-11-13: version 1.3.3 makes some minor performance enhancements.

2023-10-13: version 1.3.2 provides a corrected serialise utility function.

2023-10-13: version 1.3.1 restores a small number of utility functions that are not required by the library but are very useful for serialising Stripe objects.

2023-10-13: version 1.3.0 fixes an issue with form serialisation that meant that JsonField names were only applied to the top level elements. It also tidies the code up a little.

2023-08-29: version 1.2.3 updates the Stripe API from version 2022-11-15 to 2023-08-16, which contains some breaking changes. See the [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog) for details.

2023-06-29: version 1.2.2 updates the package dependencies for FSharp.Core and FSharp.Data to 6.0.7 and 6.2.0 respectively.

2022-11-22: version 1.2.0 updates the Stripe API from version 2022-08-01 to 2022-11-15, which contains some breaking changes. See the [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog) for details. As .NET 5 is out-of-support, this has been removed from the target frameworks.

2022-10-05: version 1.1.0 updates the Stripe API from version 2020-08-27 to 2022-08-01, which contains some breaking changes. See the [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog) for details.

2022-04-22: FunStripeLite version 1.0.0 forked from FunStripe and stripped down

## Installation

Get the latest version from [Nuget](https://www.nuget.org/packages/FunStripeLite/)

## Usage

Open the StripeModel and StripeRequest modules.

Here's an example of how to create a new payment method:

```F#
let settings = RestApi.StripeApiSettings.New(apiKey = "<your Stripe API key>")

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

The `options` can be provided using record notation or if there are many uninitialised properties you can use the static `New` method to instantiate the record more efficiently.

## Stripe API version

FunStripeLite targets a specific Stripe API date-version. The version this build was generated from is exposed as a constant:

```F#
Config.DefaultStripeApiVersion  // e.g. "2023-08-16"
```

It is also embedded as an assembly-level attribute (`Config.StripeApiVersionAttribute`) and in the NuGet package tags, giving downstream projects an auditable record of the API surface they are compiled against.

By default, FunStripeLite does **not** send a `Stripe-Version` request header, so Stripe uses the version pinned to your account. If you want every request to be explicitly tied to the library's target API version — useful when upgrading or for forward-compatibility testing — pass it through `StripeApiSettings`:

```F#
let settings =
    RestApi.StripeApiSettings.New(
        apiKey = "<your Stripe API key>",
        stripeVersion = Config.DefaultStripeApiVersion
    )
```

To test against a **newer** Stripe API version before upgrading the library, supply the target date directly:

```F#
let settings =
    RestApi.StripeApiSettings.New(
        apiKey = "<your Stripe API key>",
        stripeVersion = "2024-06-20"   // override for forward-compatibility testing
    )
```

See the [FunStripe CHANGELOG](https://github.com/simontreanor/FunStripe/blob/master/CHANGELOG.md) for the full FunStripeLite version → Stripe API version compatibility table.

## References

[Stripe Documentation](https://stripe.com/docs)

[Developer Tools](https://stripe.com/docs/development)

[API Reference](https://stripe.com/docs/api)

[Official Stripe .NET Library](https://github.com/stripe/stripe-dotnet)

[Stripe OpenAPI Specification](https://raw.githubusercontent.com/stripe/openapi/master/openapi/spec3.sdk.json)
