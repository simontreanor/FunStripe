# Changelog

## FunStripe / FunStripeLite – Stripe API Version Compatibility

Each row covers all FunStripe / FunStripeLite releases that target that Stripe API version.

| FunStripe    | FunStripeLite | Stripe API version | Notes                     |
|--------------|---------------|--------------------|---------------------------|
| 0.11.x       | 1.4.x         | 2023-08-16         | Current                   |
| 0.9.3–0.10.x | 1.2.3–1.3.x   | 2023-08-16         | Upgraded from 2022-11-15  |
| 0.9.2        | 1.2.0–1.2.2   | 2022-11-15         | Upgraded from 2022-08-01  |
| 0.9.0–0.9.1  | 1.1.0–1.1.x   | 2022-08-01         | Upgraded from 2020-08-27  |
| 0.8.x        | —             | 2020-08-27         | Upgraded from 2020-03-02  |

> **Updating the Stripe API version:** when the target changes, update these four locations
> together so they stay in sync:
>
> 1. `Config.DefaultStripeApiVersion` in `src/Config.fs`
> 2. The attribute literal in `src/AssemblyInfo.fs`
> 3. `<StripeApiVersion>` in `src/FunStripe.fsproj`
> 4. `<StripeApiVersion>` in `src/FunStripeLite/FunStripeLite.fsproj`

## Version notes

### FunStripe 0.11.x / FunStripeLite 1.4.x

Targets Stripe API `2023-08-16`.

- Introduces `Config.DefaultStripeApiVersion` (`"2023-08-16"`) so callers can reference the
  exact Stripe API date-version the library was compiled against.
- Embeds `[<assembly: Config.StripeApiVersionAttribute("2023-08-16")>]` for auditable
  assembly-level inspection.
- Adds `<StripeApiVersion>` and `PackageTags` to NuGet package metadata for both packages.
- `FunStripe 0.11.2 / FunStripeLite 1.4.2` (2025-02-24): implements changes to the order of
  generated types to reduce the need for recursive type declarations.
- `FunStripe 0.11.0 / FunStripeLite 1.4.0` (2025-01-21): changes target frameworks to
  .NET Standard 2.0/2.1 and updates FSharp.Core to 9.0.101 and FSharp.Data to 6.4.1.

### FunStripe 0.9.3–0.10.x / FunStripeLite 1.2.3–1.3.x

Targets Stripe API `2023-08-16`.

2023-08-29: upgraded from Stripe API `2022-11-15` to `2023-08-16`. See the
[Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog) for breaking changes.

### FunStripe 0.9.2 / FunStripeLite 1.2.0–1.2.2

Targets Stripe API `2022-11-15`.

2022-11-22: upgraded from Stripe API `2022-08-01` to `2022-11-15`. See the
[Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog) for breaking changes.

### FunStripe 0.9.0–0.9.1 / FunStripeLite 1.1.0–1.1.x

Targets Stripe API `2022-08-01`.

2022-10-04: upgraded from Stripe API `2020-08-27` to `2022-08-01`. See the
[Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog) for breaking changes.

### FunStripe 0.8.x

Targets Stripe API `2020-08-27`.

2021-07-18: upgraded from Stripe API `2020-03-02` to `2020-08-27`. See the
[Stripe API changelog](https://stripe.com/docs/upgrades#api-changelog) for breaking changes.
