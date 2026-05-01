# Contributing to FunStripe

Thanks for contributing! Please read the relevant section below before opening a PR.

## Branches

All development happens on `main`. NuGet packages: `FunStripe.Core`, `FunStripe.Core.Fable`.

## Workflow

1. Fork and create a feature branch from `main`.
2. Run `dotnet build` and `dotnet test` locally before pushing.
3. For changes to generated code, update the generator under `tools/FunStripe.Generator/` and regenerate — do not hand-edit the generated files.
4. Open a PR against the appropriate target branch. The PR template guides the rest.

## Releases

Releases are cut by maintainers via the workflow dispatch UI using the `publish-funstripe-core.yml` workflow (triggered by `v2/*` tag pushes) and the `publish-funstripe-core-fable.yml` workflow (triggered by `v2-fable/*` tag pushes), both on `main`.
