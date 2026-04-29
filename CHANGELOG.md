# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

## [Unreleased]

### Added
- `FunStripe.Core` NuGet package (netstandard2.0/2.1) replacing `FunStripe` and `FunStripeLite`
- `FunStripe.Core.Fable` NuGet package (netstandard2.0) replacing `FunStripeLite.Fable`
- `FunStripe.Generator` project (net10.0 console app) containing code generators, separated from the published library
- Central Package Management via `Directory.Packages.props`
- `Directory.Build.props` in `src/FunStripe.Core/` to isolate NuGet restore artefacts for the Fable project
- Modern `.slnx` solution file replacing the legacy `.sln`
- Publish workflows for `FunStripe.Core` and `FunStripe.Core.Fable`; version passed at pack time via `-p:Version=`
- `Config.DefaultStripeApiVersion` constant and `Config.StripeApiVersionAttribute` assembly attribute for auditable API version tracking
- `<StripeApiVersion>` and `<PackageTags>` NuGet metadata on `FunStripe.Core`

### Changed
- All package dependencies updated to latest versions (FSharp.Core 10.1.203, FSharp.Data.Json.Core 8.1.11, NUnit 4.5.1, NUnit3TestAdapter 6.2.0, Microsoft.NET.Test.Sdk 18.5.1, Microsoft.Extensions.Configuration 10.0.7)
- `global.json` updated to .NET SDK 10.0.x
- Tests updated to target net10.0

### Removed
- `FunStripe` NuGet package
- `FunStripeLite` NuGet package and project
- `FunStripeLite.Fable` project
- `publish-funstripe.yml`, `publish-funstripelite.yml`, `publish-funstripelite-fable.yml` workflows

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
