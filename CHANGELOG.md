# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

Version numbers follow the `FunStripeLite` package from v1.0.0 onward. Where the same change was released for `FunStripe`, the equivalent version is noted in brackets, e.g. `[FunStripe 0.9.2]`. Entries marked `FunStripe only` have no `FunStripeLite` equivalent.

## [2.5.0] - 2026-09-28

### Changed
- Regenerated against Stripe OpenAPI spec `2026-09-30.endive` (was `2026-08-26.dahlia`)

## [2.4.0] - 2026-09-07

### Upgrade notes
- Three payment-method-details types were renamed to track renamed schema titles in Stripe's spec: `AlmaInstallments` → `PaymentFlowsPrivatePaymentMethodsAlmaDetailsResourceInstallments`, `PaymentMethodDetailsKonbiniStore` → `PaymentFlowsPrivatePaymentMethodsKonbiniDetailsResourceStore`, `PaymentMethodDetailsKonbiniStoreChain` → `PaymentFlowsPrivatePaymentMethodsKonbiniDetailsResourceStoreChain`. Field names and shapes are unchanged, so only code that names these types explicitly needs updating

### Changed
- Regenerated against Stripe OpenAPI spec `2026-08-26.dahlia` (was `2026-07-29.dahlia`). Highlights:
  - **Billing feedback options**: new `BillingFeedbackOption` resource (`/v1/billing/feedback_options` — create, retrieve, update, list, and `deactivate`) with `status` and `status_transitions`. Portal cancellation-reason configuration takes a list of `feedback_options`, and subscription `cancellation_details` takes a `feedback_option` on cancel and update
  - **Billing portal**: new `customer_update` flow type (`PortalFlowsFlowCustomerUpdate`)
  - **Customer sessions**: `active_entitlements` and `customer_portal` components (the latter with `disable_stripe_user_authentication`)
  - **Tax registrations**: `igic` country option (Canary Islands IGIC) with `place_of_supply_scheme` (`standard` / `inbound_goods`), available across the EU country options
  - **Checkout**: Financial Connections payment method options (`filters.account_subcategories`, `permissions`, `prefetch`, `return_url`), and card `restrictions.funding_types_blocked` (`credit` / `debit` / `prepaid`)
  - **Billie**: invoice and subscription payment method options (`InvoicePaymentMethodOptionsBillie`, `SubscriptionPaymentMethodOptionsBillie`)
  - **Payment links**: `application_fee_amount`, `application_fee_percent`, `on_behalf_of` and `transfer_data` on update
  - **Connect embedded components**: new `payment_method_settings` component (`ConnectEmbeddedPaymentMethodSettingsConfigClaim`)
  - `Invoiceitem`: `frozen_fields` (`discounts`, `pricing`, `quantity`); `ConfirmationToken`: `metadata`
  - `Terminal` location addresses now use a dedicated `AddressApiResourceTerminal` type
  - Payment-record NZ bank account details gained their own `PaymentMethodDetailsPaymentRecordNzBankAccount` type (account holder name, bank/branch code, bank name, last4, suffix)
  - `touch_n_go` added to the FPX bank enums on `PaymentIntent` and `SetupIntent`
  - `2026-08-26.dahlia` added to the webhook endpoint API version enum

## [2.3.0] - 2026-08-03

### Upgrade notes
- `Event.Data.Object`, `Event.Data.PreviousAttributes`, and `next_action.use_stripe_sdk` (on `PaymentIntent`/`SetupIntent`) change type from `string` to `RawJson`. This is shipped as a **minor** release despite the type change because these fields previously could not deserialise at all — any real webhook payload or 3DS `next_action` threw `JsonException` — so no working code can depend on the old type. If you constructed these values manually (e.g. in tests), wrap the string in `RawJson`; to read them, use the new `Util.deserialiseRaw<'a>`
- Pattern matches on `EventType` and `StripeError.ErrorType` need an `UnknownEnumValue` case (or a wildcard). Previously an enum value unknown to the library failed the whole response at deserialisation, so no match on such a value could ever run

### Changed
- Regenerated against Stripe OpenAPI spec `2026-07-29.dahlia` (was `2026-06-24.dahlia`). Highlights:
  - Financial Connections: new `FinancialConnectionsAuthorization` resource with status details, session limits and manual-entry options, plus account/authorization deactivation lifecycle event types (`financial_connections.account.upcoming_deactivation`, `*.expected_deactivation_date_updated`, and authorization equivalents)
  - `PaymentIntent`/`SetupIntent`: `allowed_payment_method_types`; expanded payment-record payment method details across many payment methods
  - `Topup`: `initiated_by` and US bank account payment method options
  - Tax: US mass-transit parking tax and parking tax registration options; `ic_nif` tax ID type
- **Lenient deserialisation for high-churn enums**: `EventType` and `StripeError.ErrorType` gained an `UnknownEnumValue of string` catch-all case. Stripe adds enum values without an API-version bump, and one unknown nested value fails the whole response, so webhook event types and error types added after this library version was generated now deserialise to the catch-all instead of throwing; the case round-trips to its raw string on serialisation. Pattern matches on these two unions need a case for `UnknownEnumValue` (or a wildcard). All other enums keep strict exhaustive matching; the allowlist is `enumsWithCatchAll` in the generator

### Fixed
- **Form encoding of list parameters**: `Util.format` now recurses into list elements instead of calling `ToString()` on them, so `List<record>` and `List<union>` request fields serialise correctly. Previously e.g. `Checkout.Sessions.Create` with `line_items` sent the F# record representation (`line_items[0] = { PriceData = ... }`) and `payment_method_types` sent PascalCase case names; both were rejected by Stripe. They now emit `line_items[0][price_data][unit_amount]=500` and `payment_method_types[0]=card`
- **Webhook `Event` deserialisation**: `Event.Data.Object` and `Event.Data.PreviousAttributes` (and `next_action.use_stripe_sdk` on `PaymentIntent`/`SetupIntent`) were typed `string`, so deserialising any real webhook payload (or a 3DS `next_action`) threw `JsonException`. These untyped-object fields are now `RawJson`, which preserves the JSON fragment verbatim; deserialise it with the new `Util.deserialiseRaw<'a>` (breaking: these fields change type from `string` to `RawJson`)
- Generator: `--spec` omitted on the command line now resolves to the `StripeApiVersion` in `Directory.Build.props` for the model and request builders too (previously only `StripeIds.fs` used it; models/requests silently fell back to a hard-coded older spec)
- Generator: boolean-valued `additionalProperties` (`additionalProperties: true`, meaning "any JSON") is now recognised as an untyped object and emitted as `RawJson`; previously it was conflated with schema-valued `additionalProperties` (free-form maps) and emitted as `Map<string, string list>`. The `2026-07-29.dahlia` spec is the first to use the boolean form (on exactly the webhook/`use_stripe_sdk` fields above)

### Added
- `RawJson` type (`FunStripe` namespace) with System.Text.Json and Fable converters
- `Util.deserialiseRaw<'a>`: deserialise a `RawJson` fragment (e.g. a webhook event's `data.object`) into a typed model

## [2.2.0] - 2026-07-06

### Changed
- Regenerated against Stripe OpenAPI spec `2026-06-24.dahlia` (was `2026-05-27.dahlia`)
- `SetupAttempt` Pix details: field `SetupAttemptPaymentMethodDetailsPix` replaced by `Fingerprint` (uniquely identifies the Pix account), tracking Stripe's spec

### Added
- `Satispay` payment method support across `PaymentMethod`, `SetupAttempt`, and `Checkout` (including `PaymentMethodOptionsSatispay` with `setup_future_usage`)
- `Checkout`: `Sunbit` payment method options (`capture_method`, `setup_future_usage`) and `WeChat Pay` options (`app_id`, `client`: Android/iOS/Web)
- `Disputes`: Mastercard compliance evidence submission (`MastercardCompliance` / `FeeAcknowledged`)
- `Reserve`: `ReleaseDetails` on reserve holds (per-release amounts and originating `ReserveRelease`)
- `Event`: new billing event types (`billing.meter.*`, `billing.credit_balance_transaction.created`, `billing.credit_grant.updated`)

## [2.1.0] - 2026-06-17

### Changed
- Regenerated against Stripe OpenAPI spec `2026-05-27.dahlia` (was `2026-04-22.dahlia`)

## [2.0.6] - 2026-05-06

### Fixed
- `formatQueryString`: `List<string>` and `Option<List<string>>` query parameters (e.g. `expand`, `ids`) now emit Rack-style repeated keys (`key[]=a&key[]=b`) instead of a single semicolon-joined value (`key[]=a;b`), matching Stripe's expected encoding
- `WebhookSigning.verifySignature`: future-dated timestamps (clock skew or replay) are now correctly rejected; tolerance check uses `abs (currentTime - timestamp)` instead of the one-sided `currentTime - timestamp`

### Added
- `WebhookSigning.verifyWithDefaultTolerance`: convenience wrapper using the default 5-minute tolerance
- `WebhookSigning.parseHeader`: previously private; now public so callers can inspect or log parsed header components
- `AsyncResult` module with `ofResult`, `ofAsync`, `map`, and `mapError` helpers
- `AsyncResultBuilder.ReturnFrom` overload for `Result<'a,'e>` (lifting a plain `Result` into `AsyncResult`)
- `AsyncResultBuilder.Bind` error-type constraint tightened: both arms now share the same `'e` type parameter

### Tests
- Updated `expand list produces array notation` assertion to match corrected Rack-style encoding (`expand[]=default_source&expand[]=sources`)
- Added `future timestamp outside tolerance returns TimestampOutOfTolerance` test to `WebhookSigningTests`
- Added `hasStripeKey` / `assumeStripeKey` helpers; all integration test fixtures now emit `Assert.Ignore` and skip cleanly when `STRIPE_TEST_API_KEY` is not set

## [2.0.5] - 2026-05-05

### Added
- Unit tests for serialisation edge cases in `tests/Tests.fs`
- CI workflow (`.github/workflows/check-stripe-spec.yml`) to detect new Stripe OpenAPI spec versions and trigger regeneration automatically

### Fixed
- Serialisation edge cases in generated model and request files (`ConfirmationToken`, `Issuing`, `IssuingCard`, `IssuingCardholder`, `PaymentLink`, `PaymentMethod`, `SetupAttempt`, `SourceTransaction`, `Terminal`, and request files for `Accounts`, `Checkout`, `Invoices`, `Issuing`, `Payment`, `Setup`, `Sources`, `Subscriptions`, `TestHelpers`)

## [2.0.4] - 2026-05-04

### Changed
- Refactored Tarjan's SCC and Kahn's topological sort algorithms in the code generator to idiomatic functional style; generated file and type ordering is updated accordingly

## [2.0.3] - 2026-05-01

### Fixed
- `bool option` query parameters (e.g. `BillingPortalConfigurations.ListOptions.Active`) were silently dropped from query strings; `formatQueryString` now handles `bool option` and `bool`, serialising as lowercase `true`/`false`

### Removed
- Redundant `module XxxOptions = let create(...)` tupled-parameter constructors from all generated `src/StripeRequest/*.fs` files; the idiomatic `static member New(...)` augmentations remain the sole public construction API

### Changed
- `[<GeneratedCode("FunStripe", ...)>]` version updated from `"1.0.0"` to `"2.0.3"` in all generated files

## [2.0.2] - 2026-05-01

### Fixed
- Removed obsolete `ModelBuilder` and `RequestBuilder` calls from `FunStripe.Generator` that referenced deleted monolithic generator code

## [2.0.1] - 2026-05-01

### Fixed
- Removed stale `ModelBuilder.fs` / `RequestBuilder.fs` project references from `FunStripe.Generator.fsproj` that pointed to deleted files

## [2.0.0] - 2026-05-01

### Branch / package strategy
- Renamed default branch from `master` → `main`; the `v1` branch (`FunStripe` / `FunStripeLite` package IDs) is no longer maintained

### Added
- Modular per-domain code layout: `Stripe.{Domain}` namespaces under `src/Stripe/` for response models and `StripeRequest.{Domain}` namespaces under `src/StripeRequest/` for request options, replacing the monolithic `StripeModel.fs` / `StripeRequest.*.fs` files
- Phantom-typed `StripeId<'phantom>` and `StripeList<'T>` in `src/StripeIds.fs`, with marker types for ~73 Stripe resources giving compile-time differentiation of ID strings
- `static member New(...)` augmentations on every modular record and request options record for ergonomic named/optional-argument construction
- `FunStripe.Core` NuGet package (netstandard2.0/2.1) — v2 successor to `FunStripe`
- `FunStripe.Core.Fable` NuGet package (netstandard2.0) — v2 Fable-compatible package; replaces `FunStripeLite` for Node.js projects upgrading to v2
- `FunStripe.Generator` project (net10.0 console app) containing code generators, separated from the published library
- `CONTRIBUTING.md` documenting branch model, backport policy, and release process
- `MIGRATION-v1-to-v2.md` upgrade guide for v1 consumers
- `Config.DefaultStripeApiVersion` constant and `Config.StripeApiVersionAttribute` assembly attribute for auditable API version tracking

### Changed
- All package dependencies updated to latest versions (FSharp.Core 10.1.203, FSharp.Data.Json.Core 8.1.11, NUnit 4.5.1, NUnit3TestAdapter 6.2.0, Microsoft.NET.Test.Sdk 18.5.1)
- JSON serialization replaced: forked `FSharp.Json` removed and replaced by `FSharp.SystemTextJson` + custom converters
- `Config.StripeTestApiKey` now reads from the `STRIPE_TEST_API_KEY` environment variable; replaces `Microsoft.Extensions.Configuration.UserSecrets`

### Removed
- Monolithic `src/StripeModel.fs` (~40k lines) and `src/StripeRequest.fs` files (73k lines)
- Forked `FSharp.Json` library files (`InterfaceTypes.fs`, `Reflection.fs`, `Core.fs`, `Transforms.fs`, `JsonValueHelpers.fs`)
- `Microsoft.Extensions.Configuration.*` dependency

## [FunStripe 0.11.3] - 2025-02-24 _(FunStripe only)_

### Fixed
- Order of generated types changed to reduce the need for recursive type declarations (thanks [Thorium](https://github.com/Thorium))

## [1.4.0] - 2023-12-06 [FunStripe 0.11.0]

### Changed
- Target frameworks changed to .NET Standard 2.0 and .NET Standard 2.1
- FSharp.Core updated to 8.0.100

## [1.3.3] - 2023-11-13 [FunStripe 0.10.2]

### Changed
- Minor performance enhancements

## [1.3.2] - 2023-10-13

### Fixed
- Corrected `serialise` utility function

## [1.3.1] - 2023-10-13 [FunStripe 0.10.1]

### Changed
- Minor tweaks to normalise folder structure

## [1.3.0] - 2023-10-13 [FunStripe 0.10.0]

### Fixed
- Form serialisation issue where `JsonField` names were only applied to top-level elements

## [1.2.3] - 2023-08-29 [FunStripe 0.9.3]

### Changed
- Stripe API updated from version 2022-11-15 to 2023-08-16 (breaking — see [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog))

## [1.2.2] - 2023-06-29

### Changed
- FSharp.Core updated to 6.0.7
- FSharp.Data updated to 6.2.0

## [1.2.0] - 2022-11-22 [FunStripe 0.9.2]

### Changed
- Stripe API updated from version 2022-08-01 to 2022-11-15 (breaking — see [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog))

### Removed
- .NET 5 target (out of support)

## [1.1.0] - 2022-10-05 [FunStripe 0.9.0]

### Changed
- Stripe API updated from version 2020-08-27 to 2022-08-01 (breaking — see [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog))

## [1.0.0] - 2022-04-22

### Added
- FunStripeLite forked from FunStripe as a lightweight variant without code generators

## [FunStripe 0.8.0] - 2021-07-18 _(FunStripe only — predates FunStripeLite)_

### Changed
- Stripe API updated from version 2020-03-02 to 2020-08-27 (breaking — see [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog))

---

## Stripe API Version Compatibility

| Package | Version | Stripe API version    | Notes                          |
|---------|---------|-----------------------|--------------------------------|
| `FunStripe.Core` | 2.0.x | 2026-04-22.dahlia | Current |
| `FunStripe` | 0.11.x | 2023-08-16 | Upgraded from 2022-11-15 |
| `FunStripeLite` | 1.4.x | 2023-08-16 | Upgraded from 2022-11-15 |
| `FunStripe` | 0.9.3–0.10.x | 2023-08-16 | Upgraded from 2022-11-15 |
| `FunStripeLite` | 1.2.3–1.3.x | 2023-08-16 | Upgraded from 2022-11-15 |
| `FunStripe` | 0.9.2 | 2022-11-15 | Upgraded from 2022-08-01 |
| `FunStripeLite` | 1.2.0–1.2.2 | 2022-11-15 | Upgraded from 2022-08-01 |
| `FunStripe` | 0.9.0–0.9.1 | 2022-08-01 | Upgraded from 2020-08-27 |
| `FunStripeLite` | 1.1.0 | 2022-08-01 | Upgraded from 2020-08-27 |
| `FunStripe` | 0.8.x | 2020-08-27 | Upgraded from 2020-03-02 |
| `FunStripeLite` | 1.0.0 | 2020-08-27 | Forked from `FunStripe` |

> **Updating the Stripe API version:** when the target changes, update these locations together:
>
> 1. `Config.DefaultStripeApiVersion` in `src/Config.fs`
> 2. The attribute literal in `src/AssemblyInfo.fs`
> 3. `<StripeApiVersion>` in `src/FunStripe.Core/FunStripe.Core.fsproj`
