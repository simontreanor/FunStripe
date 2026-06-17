# Contributing to FunStripe

Thanks for contributing! Please read the relevant section below before opening a PR.

## Branches

All development happens on `main`. NuGet packages: `FunStripe.Core`, `FunStripe.Core.Fable`.

## Workflow

1. Fork and create a feature branch from `main`.
2. Run `dotnet build` and `dotnet test` locally before pushing.
3. For changes to generated code, update the generator under `tools/FunStripe.Generator/` and regenerate — do not hand-edit the generated files.
4. Open a PR against the appropriate target branch. The PR template guides the rest.

## Versioning

The version lives in **one place**: `Directory.Build.props` at the repo root.

```xml
<FunStripeVersion>2.1.0</FunStripeVersion>     <!-- NuGet package version, shared by both packages -->
<StripeApiVersion>2026-05-27.dahlia</StripeApiVersion> <!-- spec/ file the generated code targets -->
```

Both `.fsproj` files read `<Version>$(FunStripeVersion)</Version>` from it, and the code
generator reads `FunStripeVersion` to stamp the `GeneratedCode("FunStripe", "X.Y.Z")`
attributes. **Do not** hard-code the version anywhere else.

Version-bump policy (semantic versioning):

| Change | Bump | Example |
| --- | --- | --- |
| New Stripe API spec version | **minor** | `2.0.6` → `2.1.0` |
| Library bug fix / feature | patch | `2.1.0` → `2.1.1` |
| Breaking library API change | major | `2.1.0` → `3.0.0` |

New-spec releases are produced automatically: the **Check for new Stripe OpenAPI spec**
workflow bumps `Directory.Build.props`, regenerates `src/`, adds a `CHANGELOG.md` entry, and
opens a PR. You normally just review that PR rather than bumping by hand.

## Releases

1. Make sure `Directory.Build.props` has the target `FunStripeVersion` (the spec-update PR
   already did this; for a manual release, edit it here and nowhere else).
2. Regenerate if needed — `dotnet run --project tools/FunStripe.Generator -- --output src`
   picks up the version automatically — and add/expand the `CHANGELOG.md` entry.
3. Commit as `release: X.Y.Z`.

Publishing is triggered by pushing the release tags (handled by `publish-funstripe-core.yml`
for `v2/*` and `publish-funstripe-core-fable.yml` for `v2-fable/*`):

```powershell
git tag v2/X.Y.Z
git tag v2-fable/X.Y.Z
git push origin main v2/X.Y.Z v2-fable/X.Y.Z
```

The publish workflows take the package version from the tag, so the tag is the ultimate
source of truth for what gets pushed to NuGet — keep it in sync with `FunStripeVersion`.
