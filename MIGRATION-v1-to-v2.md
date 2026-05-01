# Migrating from FunStripe v1 to v2

FunStripe v2 is a paradigm shift that aligns the library with Stripe's official publishing conventions. The `v1` branch (`FunStripe` / `FunStripeLite` package IDs) is no longer maintained.

This guide covers the breaking changes and how to update.

## At a glance

| Concern | v1 (`FunStripe` / `FunStripeLite`) | v2 (`FunStripe.Core` / `FunStripe.Core.Fable`) |
|---------|-------------------------------------|------------------------------------------------|
| NuGet package | `FunStripe` (full, with generators), `FunStripeLite` (generated files only, smaller) | `FunStripe.Core`, `FunStripe.Core.Fable` (Fable/Node.js) |
| Response models | Single `StripeModel` module (~50k lines) | Per-domain `Stripe.{Domain}` namespaces |
| Request options | `StripeRequest.{Group}` modules in monolithic files | `StripeRequest.{Domain}` per-domain files |
| ID types | `string` everywhere | Phantom-typed `StripeId<'phantom>` |
| JSON serialization (.NET) | Forked `FSharp.Json` (`[<JsonField>]`, `[<JsonUnionCase>]`) | `FSharp.SystemTextJson` + custom converters (`[<JsonPropertyName>]`) |
| JSON serialization (Fable) | `Json.FableCore` reading legacy attributes | `Json.FableCore` reading `[<JsonPropertyName>]` |
| API key configuration | `Microsoft.Extensions.Configuration.UserSecrets` | `STRIPE_TEST_API_KEY` environment variable |
| Record construction | Record literal or partial `New` helpers | `static member New(...)` on every record and request options record |

## 1. Switch the NuGet package

```diff
- <PackageReference Include="FunStripe" Version="1.*" />
+ <PackageReference Include="FunStripe.Core" Version="2.*" />
```

If you were using `FunStripeLite` (the generator-free, smaller-footprint variant of `FunStripe`):

```diff
- <PackageReference Include="FunStripeLite" Version="1.*" />
+ <PackageReference Include="FunStripe.Core" Version="2.*" />
```

For Fable/Node.js projects (v2 introduces Fable support that v1 did not have):

```diff
+ <PackageReference Include="FunStripe.Core.Fable" Version="2.*" />
```

You can install both packages side-by-side during migration — the package IDs and namespaces don't collide.

## 2. Update `open` statements

v1 surfaced everything from a single `FunStripe.StripeModel` and a handful of `FunStripe.StripeRequest.*` modules. v2 splits responses and requests by domain.

```diff
- open FunStripe
- open FunStripe.StripeModel
- open FunStripe.StripeRequest
+ open Stripe.PaymentMethod
+ open Stripe.Customer
+ open StripeRequest.Payment
```

Each Stripe resource lives in its own namespace under `Stripe.*` (response models) and `StripeRequest.*` (request options). Pick only what you need; intellisense will discover the rest.

## 3. Replace JSON attributes (only relevant if you depend on FunStripe types directly in your serialization layer)

```diff
- open FunStripe.Json
- [<JsonField("card")>] CardField : string option
+ open System.Text.Json.Serialization
+ [<JsonPropertyName("card")>] CardField : string option
```

Discriminated union case names use `[<JsonPropertyName>]` instead of `[<JsonUnionCase>]`. The `StripeUnionConverterFactory` in `Json/StripeConverter.fs` handles the rest automatically.

## 4. Adopt phantom-typed IDs (optional, recommended)

v2 introduces `StripeId<'phantom>` with marker types like `Customer`, `PaymentMethod`, `Charge`, etc. The type carries no runtime cost — it is `[<Struct>]` over the underlying string — but prevents passing a customer ID where a payment-method ID is expected.

```fsharp
let customerId : StripeId<Customer> = StripeId.Of "cus_..."
```

Existing string IDs continue to work; phantom typing is opt-in at call sites.

## 5. API key configuration

v1 used `Microsoft.Extensions.Configuration.UserSecrets`. v2 reads `Config.StripeTestApiKey` from the `STRIPE_TEST_API_KEY` environment variable.

For local development, set the variable in your shell profile or `.env` loader. For CI, expose it as a secret (e.g. GitHub Actions `secrets.STRIPE_TEST_API_KEY`).

## 6. Construct records via `static member New(...)`

Every modular record and request options record has a `static member New(...)` augmentation with named, optional arguments. This is now the recommended construction style:

```fsharp
let opts =
    PaymentMethods.CreateOptions.New(
        card = Choice2Of2 (PaymentMethods.Create'CardTokenParams.New("tok_visa")),
        type' = PaymentMethods.Create'Type.Card
    )
```

## 7. Run the build

After updating package references and `open` statements:

```bash
dotnet restore
dotnet build
dotnet test
```

The compiler will surface any remaining mismatches — usually missing or moved namespaces.

## Need help?

Open an issue with the `migration` label. PRs that improve this guide are very welcome.
