// Bumps the version for a spec update, for the "Check for new Stripe OpenAPI spec" workflow.
//
// A new spec version is a minor bump; Stripe updating the targeted spec in place is a patch bump
// (see Directory.Build.props). Sets FunStripeVersion and StripeApiVersion in Directory.Build.props,
// adds a CHANGELOG.md entry above the latest release, writes the pull request body, and writes
// next, title, subject, branch and body_path to GITHUB_OUTPUT.
//
//     dotnet fsi tools/BumpSpecVersion.fsx --kind new --spec-version 2026-10-28.endive --tag v2214 --body pr-body.md

open System
open System.IO
open System.Text.RegularExpressions

let usage =
    """Usage: dotnet fsi tools/BumpSpecVersion.fsx --kind <new|refresh> --spec-version <version> --tag <tag> --body <path>

  --kind <new|refresh>      new: a spec version we don't have (minor bump)
                            refresh: Stripe updated the targeted spec in place (patch bump)
  --spec-version <version>  the spec version, e.g. 2026-10-28.endive
  --tag <tag>               the stripe/openapi release the spec comes from
  --body <path>             pull request body to write"""

let fail (message: string) =
    eprintfn "%s" message
    exit 1

let options =
    fsi.CommandLineArgs
    |> Array.tail
    |> Array.chunkBySize 2
    |> Array.map (function
        | [| name; value |] when name.StartsWith("--", StringComparison.Ordinal) -> name.Substring 2, value
        | other -> fail $"""Unexpected argument: {String.Join(" ", other)}

{usage}""")

let required name =
    options
    |> Array.tryFindBack (fun (n, _) -> n = name)
    |> Option.map snd
    |> Option.defaultWith (fun () -> fail $"--{name} is required\n\n{usage}")

let kind = required "kind"
let spec = required "spec-version"
let tag = required "tag"
let bodyPath = Path.GetFullPath(required "body")
if kind <> "new" && kind <> "refresh" then fail $"--kind must be new or refresh, not {kind}"

let root = Path.GetFullPath(Path.Combine(__SOURCE_DIRECTORY__, ".."))
let propsPath = Path.Combine(root, "Directory.Build.props")
let changelogPath = Path.Combine(root, "CHANGELOG.md")

let props = File.ReadAllText propsPath
let element name =
    let found = Regex.Match(props, $"<{name}>([^<]+)</{name}>")
    if found.Success then found.Groups.[1].Value else fail $"No <{name}> in {propsPath}"
let setElement name (value: string) (text: string) =
    Regex.Replace(text, $"<{name}>[^<]*</{name}>", (fun (_: Match) -> $"<{name}>{value}</{name}>"))

let current = element "FunStripeVersion"
let oldSpec = element "StripeApiVersion"
let next =
    match current.Split('.') with
    | [| major; minor; patch |] ->
        if kind = "new" then $"{major}.{int minor + 1}.0" else $"{major}.{minor}.{int patch + 1}"
    | _ -> fail $"FunStripeVersion {current} is not major.minor.patch"

File.WriteAllText(propsPath, props |> setElement "FunStripeVersion" next |> setElement "StripeApiVersion" spec)

let releaseUrl = $"https://github.com/stripe/openapi/releases/tag/{tag}"
let note, title, branch, intro, bumpCheck =
    if kind = "new" then
        $"Regenerated against Stripe OpenAPI spec `{spec}` (was `{oldSpec}`)",
        $"Release {next} — Stripe OpenAPI spec {spec}",
        $"update/stripe-openapi-{spec}",
        $"A new Stripe OpenAPI spec version has been detected: **`{spec}`**\n"
        + $"(from [`stripe/openapi` {tag}]({releaseUrl}))\n\n"
        + "A new spec version is treated as a **minor** release, so the version has already been\n"
        + $"bumped to **`{next}`** (from `{oldSpec}`'s release):",
        "- [ ] Confirm the bump is right (use a **major** bump instead if the new spec is breaking; the tag prefix then becomes `v<major>/`)"
    else
        $"Refreshed Stripe OpenAPI spec `{spec}`, which Stripe updated in place (now as of `stripe/openapi` {tag})",
        $"Release {next} — refreshed Stripe OpenAPI spec {spec} ({tag})",
        $"update/stripe-openapi-{spec}-refresh",
        $"Stripe updated the **`{spec}`** spec in place, without changing its version\n"
        + $"(now as of [`stripe/openapi` {tag}]({releaseUrl})), and the generated code changed.\n\n"
        + "An in-place refresh is treated as a **patch** release, so the version has already been\n"
        + $"bumped to **`{next}`**:",
        "- [ ] Confirm the bump is right (a refresh that removes or retypes anything needs a minor or major bump instead)"

// The entry goes above the most recent release heading
let changelog = File.ReadAllText changelogPath
let latest = changelog.IndexOf("## [", StringComparison.Ordinal)
if latest < 0 then fail $"No release heading (## [) in {changelogPath}"
let date = DateTime.UtcNow.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture)
let entry = $"## [{next}] - {date}\n\n### Changed\n- {note}\n\n"
File.WriteAllText(changelogPath, changelog.Insert(latest, entry))

let major = next.Split('.').[0]
let body =
    String.Join(
        "\n",
        [ intro
          ""
          "- `Directory.Build.props` — `FunStripeVersion` (and `StripeApiVersion`) updated"
          $"- `spec/` — `stripe-openapi-{spec}.json` downloaded from `stripe/openapi` {tag}"
          $"- `src/` — regenerated and stamped with `{next}`"
          "- `CHANGELOG.md` — entry added (please flesh out the notes)"
          ""
          "This PR was auto-generated by the **Check for new Stripe OpenAPI spec** workflow."
          ""
          "**Before merging, please:**"
          "- [ ] Review the generated changes in `src/`"
          "- [ ] Expand the `CHANGELOG.md` entry with anything notable in the spec changes"
          bumpCheck
          ""
          "**After merging, push the release tag:**"
          "```"
          $"git tag v{major}/{next}"
          $"git push origin v{major}/{next}"
          "```"
          "" ]
    )
File.WriteAllText(bodyPath, body)

match Environment.GetEnvironmentVariable "GITHUB_OUTPUT" with
| null | "" -> ()
| output ->
    let subject = title.Substring(title.IndexOf(" — ", StringComparison.Ordinal) + " — ".Length)
    File.AppendAllText(output, $"next={next}\ntitle={title}\nsubject={subject}\nbranch={branch}\nbody_path={bodyPath}\n")
printfn $"Bumped FunStripe {current} -> {next} ({kind}); spec {oldSpec} -> {spec} @ {tag}"
