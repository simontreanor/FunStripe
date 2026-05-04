# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

Version numbers follow the `FunStripeLite` package from v1.0.0 onward. Where the same change was released for `FunStripe`, the equivalent version is noted in brackets, e.g. `[FunStripe 0.9.2]`. Entries marked `FunStripe only` have no `FunStripeLite` equivalent.

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
- Monolithic `src/StripeModel.fs` (~50k lines) and per-group `src/StripeRequest.*.fs` files
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
