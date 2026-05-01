# Contributing to FunStripe

Thanks for contributing! Please read the relevant section below before opening a PR.

## Branches

FunStripe is maintained on two long-lived branches:

- **`main`** — v2, active development. NuGet packages: `FunStripe.Core`, `FunStripe.Core.Fable`.
- **`v1`** — v1 maintenance. NuGet packages: `FunStripe`, `FunStripeLite`.

There are no merges between the two branches. The codebases have diverged significantly (monolithic vs modular layout, `FSharp.Json` vs `FSharp.SystemTextJson`, etc.) so all cross-branch fixes are cherry-picked or re-implemented.

## Backport policy (v1)

The `v1` branch accepts:

- **Stripe API spec updates** — regenerate the v1 model/request files when Stripe ships a new API version.
- **Security fixes** — vulnerabilities in FunStripe itself or in transitive dependencies that cannot be mitigated downstream.
- **Critical bug fixes** — bugs that produce incorrect results, data loss, or block valid Stripe usage.

The `v1` branch does **not** accept:

- New features, ergonomic improvements, or refactors.
- Dependency upgrades beyond what is required for security.
- Test infrastructure changes that aren't tied to a backported fix.

If you are unsure whether a fix qualifies for backport, open the PR against `main` first and mention `v1` in the description; a maintainer will tag it for backport if appropriate.

## End of life

`v1` will be supported until at least 12 months after the v2 `2.0.0` GA release. The exact EOL date is announced in the README and the pinned tracking issue once it is set. After EOL, the branch is archived (read-only) and the corresponding NuGet versions are marked deprecated — they remain installable for reproducible builds but no further updates are published.

## Workflow

1. Fork and create a feature branch from `main` (or from `v1` for a backport).
2. Run `dotnet build` and `dotnet test` locally before pushing.
3. For changes to generated code, update the generator under `tools/FunStripe.Generator/` and regenerate — do not hand-edit the generated files.
4. Open a PR against the appropriate target branch. The PR template guides the rest.

## Releases

Releases are cut by maintainers via the workflow dispatch UI. v1 and v2 use separate publish workflows (`publish-funstripe.yml` / `publish-funstripelite.yml` on `v1`; `publish-funstripe-core.yml` / `publish-funstripe-core-fable.yml` on `main`) and tag prefixes (`v1/x.y.z` and `v2/x.y.z`).
