# CLAUDE.md

Guidance for Claude Code (and other AI assistants) working in this repository.

## What this is

FunStripe is an F# client library for the [Stripe](https://stripe.com) API. It ships
as two NuGet packages built from one shared source tree:

- **`FunStripe.Core`** — the .NET library (`netstandard2.0;netstandard2.1`).
- **`FunStripe.Core.Fable`** — the same code compiled for [Fable](https://fable.io)
  (F# → JavaScript), so the client can run in the browser.

Most of the library's surface area is **generated** from Stripe's OpenAPI spec — see
below. The hand-written code is the JSON layer, HTTP layer, config, and ISO types.

## Build & test

```powershell
dotnet build   --configuration Release      # builds all projects in FunStripe.slnx
dotnet test    tests/FunStripe.Tests.fsproj # NUnit; live-API tests are skipped without a key
```

- SDK is pinned in `global.json` (.NET 10). Package versions are centralized in
  `Directory.Packages.props` (central package management — do not put versions in `.fsproj`).
- Live integration tests read `STRIPE_TEST_API_KEY` from the environment; without it
  those tests are skipped (this is expected locally and in PR CI).

## Repository layout

- `src/` — the library source.
  - Hand-written: `Json/`, `RestApi.fs`, `Config.fs`, `Util.fs`, `AsyncResult.fs`,
    `WebhookSigning.fs`, `IsoTypes.fs`, `StripeError.fs`.
  - **Generated** (do not hand-edit): `StripeIds.fs`, `Stripe/*.fs` (response models),
    `StripeRequest/*.fs` (request builders). The `Stripe.Modular.props` /
    `StripeRequest.Modular.props` files list the generated files for compilation.
- `tools/FunStripe.Generator/` — the code generator (an F# console app) that reads the
  OpenAPI spec and emits the generated `src/` files using Fabulous.AST.
- `spec/` — bundled Stripe OpenAPI spec snapshots (`stripe-openapi-<version>.json`).
- `tests/` — NUnit test project.
- `.github/workflows/` — CI, publishing, and the spec-update automation (see below).

F# is compile-order sensitive: files compile in the order listed in the `.fsproj` /
`.props` files, and a definition must precede its use.

## The generator (important)

**Never hand-edit generated files.** To change generated output, edit the generator under
`tools/FunStripe.Generator/` and regenerate:

```powershell
dotnet run --project tools/FunStripe.Generator -- `
  --spec spec/stripe-openapi-2026-04-22.dahlia.json `
  --output src `
  --version 2.0.6
```

Key generator modules:

- `RequestParsing.fs` / `RequestBuilderAST.fs` — parse request schemas, emit `StripeRequest/`.
- `ModelParsing.fs` / `ModelBuilderModular.fs` / `ModelBuilderAST.fs` — emit `Stripe/` models.
- `StripeIdsBuilder.fs` — emits `StripeIds.fs`.
- `Generator.fs` — entry point (`--spec`, `--output`, `--version` args).

Note on schema shapes: Stripe represents free-form maps as title-less `"type": "object"`
schemas with `additionalProperties` (e.g. the various `*_by_currency` fields). The request
parser maps these to `Map<string, string>`. New ones are detected generically via
`additionalProperties` rather than by name, so a new spec adding such a field won't crash
the generator.

## Spec update automation

- **`check-stripe-spec.yml`** (weekly + manual) — checks `stripe/openapi` for a newer spec
  version, downloads it, runs the generator, and opens a PR with the new spec + regenerated
  `src/`. The PR body carries a human checklist (version bump, changelog, release tags).
- **`regenerate.yml`** (manual) — regenerate `src/` from a chosen spec/version and open a PR.
- **`ci.yml`** — build + test on PR/push, plus a generator smoke-test that runs the generator
  end-to-end so generator regressions are caught in PR CI (not only in the weekly job).

## Releasing

See `CONTRIBUTING.md` for the full process. In short: bump `<Version>` in both
`FunStripe.Core*.fsproj`, update the `GeneratedCode("FunStripe", "X.Y.Z")` attributes across
generated files, add a `CHANGELOG.md` entry, commit as `release: X.Y.Z`, then push `v2/X.Y.Z`
and `v2-fable/X.Y.Z` tags to trigger the publish workflows.

## Conventions

- Match the style of surrounding code (terse F#, pipelines, records).
- Keep `FunStripe.Core` and the Fable build in sync — they share source, so changes must
  compile under both `netstandard` and Fable.
- Prefer editing the generator over editing generated output.
