# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

## [Unreleased]

### Branch / package strategy
- Dual-track maintenance model: `main` (this branch) hosts v2 — `FunStripe.Core` / `FunStripe.Core.Fable` packages — while the `v1` branch continues to ship the legacy `FunStripe` / `FunStripeLite` packages with Stripe API spec updates and critical fixes only. See `README.md`, `CONTRIBUTING.md`, and `MIGRATION-v1-to-v2.md` for the full policy.
- Renamed default branch from `master` → `main`; legacy branch renamed from `master` → `v1` (GitHub auto-redirects old URLs).

### Added
- Modular per-domain code layout: `Stripe.{Domain}` namespaces under `src/Stripe/` for response models and `StripeRequest.{Domain}` namespaces under `src/StripeRequest/` for request options, replacing the monolithic `StripeModel.fs` / `StripeRequest.*.fs` files
- Auto-generated `src/Stripe/Stripe.Modular.props` and `src/StripeRequest/StripeRequest.Modular.props` MSBuild imports wiring the per-domain files into both `FunStripe.Core.fsproj` and `FunStripe.Core.Fable.fsproj` in dependency-graph compile order
- Phantom-typed `StripeId<'phantom>` and `StripeList<'T>` in a new auto-opened `src/StripeIds.fs`, with marker types for ~73 Stripe resources giving compile-time differentiation of ID strings
- `static member New(...)` augmentations on every modular record and request options record for ergonomic named/optional-argument construction
- Modular code generators in `tools/FunStripe.Generator/` (`ModelBuilderModular.fs`, `RequestBuilderAST.fs`, `StripeIdsBuilder.fs`)
- `FunStripe.Core` NuGet package (netstandard2.0/2.1) — v2 successor to `FunStripe`
- `FunStripe.Core.Fable` NuGet package (netstandard2.0) — v2 successor to `FunStripeLite`
- `FunStripe.Generator` project (net10.0 console app) containing code generators, separated from the published library
- Central Package Management via `Directory.Packages.props`
- `Directory.Build.props` in `src/FunStripe.Core/` to isolate NuGet restore artefacts for the Fable project
- Modern `.slnx` solution file replacing the legacy `.sln`
- Publish workflows for `FunStripe.Core` and `FunStripe.Core.Fable`, triggered by `v2/*` and `v2-fable/*` tag pushes (version derived from tag); manual `workflow_dispatch` still supported with a version override
- `ci.yml` PR/push build workflow on `main`
- `CONTRIBUTING.md` documenting branch model, backport policy, and release process
- `MIGRATION-v1-to-v2.md` upgrade guide for v1 consumers
- `Config.DefaultStripeApiVersion` constant and `Config.StripeApiVersionAttribute` assembly attribute for auditable API version tracking
- `<StripeApiVersion>` and `<PackageTags>` NuGet metadata on `FunStripe.Core`
- `src/Json/StripeConverter.fs`: custom `FSharp.SystemTextJson`-based converters replacing the forked `FSharp.Json` library (`EpochDateTimeConverter`, `StripeUnionConverterFactory`, `SnakeCaseNamingPolicy`)
- `src/Json/FableCore.fs`: updated Fable-compatible JSON deserializer reading `[<JsonPropertyName>]` attributes instead of the old `[<JsonField>]`/`[<JsonUnionCase>]` attributes
- `Fable.Package.SDK` reference to `FunStripe.Core.Fable.fsproj` so the package is discoverable on fable.io/packages and `.fs` sources are packed into the `fable/` folder

### Changed
- All package dependencies updated to latest versions (FSharp.Core 10.1.203, FSharp.Data.Json.Core 8.1.11, NUnit 4.5.1, NUnit3TestAdapter 6.2.0, Microsoft.NET.Test.Sdk 18.5.1)
- `global.json` updated to .NET SDK 10.0.x
- Tests updated to target net10.0
- JSON serialization for the `.NET` path replaced: forked `FSharp.Json` (4 files, ~1700 lines) removed and replaced by `FSharp.SystemTextJson` + `StripeConverter.fs` (~230 lines)
- All `[<JsonUnionCase>]` attributes replaced with `[<JsonPropertyName>]` (from `System.Text.Json.Serialization`) across `IsoTypes.fs` and the generated `Stripe.{Domain}` / `StripeRequest.{Domain}` sources
- All `open FunStripe.Json` replaced with `open System.Text.Json.Serialization` across the same files
- `Config.StripeTestApiKey` now reads from the `STRIPE_TEST_API_KEY` environment variable (set via GitHub Actions secret or local shell); replaces `Microsoft.Extensions.Configuration.UserSecrets`

### Removed (from v2; still available on `v1` branch)
- `src/StripeModel.fs` (monolithic response model file, ~50k lines)
- `src/StripeRequest.fs` and 14 per-group `src/StripeRequest.<Group>.fs` files (monolithic request files)
- `FunStripeExclude<Group>` MSBuild properties (the modular layout always includes all generated files)
- `src/Json/InterfaceTypes.fs`, `src/Json/Reflection.fs`, `src/Json/Core.fs`, `src/Json/Transforms.fs`, `src/Json/JsonValueHelpers.fs` (forked FSharp.Json files)
- `LITE` conditional compilation symbol; `Microsoft.Extensions.Configuration.*` removed as a dependency

## [0.11.3] - 2025-02-24

### Fixed
- Order of generated types changed to reduce the need for recursive type declarations (thanks [Thorium](https://github.com/Thorium))

## [0.11.0] - 2025-01-21

### Changed
- Target frameworks changed to .NET Standard 2.0 and .NET Standard 2.1
- FSharp.Core updated to 9.0.101
- FSharp.Data updated to 6.4.1

## [0.10.2] - 2023-11-13

### Changed
- Minor performance enhancements

## [0.10.1] - 2023-10-13

### Changed
- Minor tweaks to normalise folder structure

## [0.10.0] - 2023-10-11

### Fixed
- Form serialisation issue where `JsonField` names were only applied to top-level elements

## [0.9.3] - 2023-08-29

### Changed
- Stripe API updated from version 2022-11-15 to 2023-08-16 (breaking — see [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog))
- FSharp.Core updated to 6.0.7
- FSharp.Data updated to 6.2.0

## [0.9.2] - 2022-11-22

### Changed
- Stripe API updated from version 2022-08-01 to 2022-11-15 (breaking — see [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog))

### Removed
- .NET 5 target (out of support)

## [0.9.0] - 2022-10-04

### Changed
- Stripe API updated from version 2020-08-27 to 2022-08-01 (breaking — see [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog))

## [0.8.0] - 2021-07-18

### Changed
- Stripe API updated from version 2020-03-02 to 2020-08-27 (breaking — see [Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog))

---

## Stripe API Version Compatibility

| FunStripe.Core | Stripe API version    | Notes                          |
|----------------|-----------------------|--------------------------------|
| 1.0.x          | 2026-04-22.dahlia     | Current                        |
| 0.11.x         | 2023-08-16            | Upgraded from 2022-11-15       |
| 0.9.3–0.10.x   | 2023-08-16            | Upgraded from 2022-11-15       |
| 0.9.2          | 2022-11-15            | Upgraded from 2022-08-01       |
| 0.9.0–0.9.1    | 2022-08-01            | Upgraded from 2020-08-27       |
| 0.8.x          | 2020-08-27            | Upgraded from 2020-03-02       |

> **Updating the Stripe API version:** when the target changes, update these locations together:
>
> 1. `Config.DefaultStripeApiVersion` in `src/Config.fs`
> 2. The attribute literal in `src/AssemblyInfo.fs`
> 3. `<StripeApiVersion>` in `src/FunStripe.Core/FunStripe.Core.fsproj`
