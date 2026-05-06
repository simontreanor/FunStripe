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

Before tagging a release, update **all** of the following to the new version number `X.Y.Z`:

1. `<Version>` in `src/FunStripe.Core/FunStripe.Core.fsproj`
2. `<Version>` in `src/FunStripe.Core/FunStripe.Core.Fable.fsproj`
3. All `[<System.CodeDom.Compiler.GeneratedCode("FunStripe", "X.Y.Z")>]` attributes across the generated source files — run the following from the repo root:
   ```powershell
   Get-ChildItem -Recurse -Include "*.fs" | ForEach-Object {
       (Get-Content $_.FullName) -replace 'GeneratedCode\("FunStripe", "OLD"\)', 'GeneratedCode("FunStripe", "NEW")' | Set-Content $_.FullName
   }
   ```
4. Add a `## [X.Y.Z]` entry to `CHANGELOG.md`.

Commit everything as `release: X.Y.Z`, then create and push both tags to trigger the publish workflows:

```powershell
git tag vX.Y.Z-core/X.Y.Z   # not used — see below
```

Releases are cut by maintainers via the workflow dispatch UI using the `publish-funstripe-core.yml` workflow (triggered by `v2/*` tag pushes) and the `publish-funstripe-core-fable.yml` workflow (triggered by `v2-fable/*` tag pushes), both on `main`:

```powershell
git tag v2/X.Y.Z
git tag v2-fable/X.Y.Z
git push origin main v2/X.Y.Z v2-fable/X.Y.Z
```
