// Finds where Stripe's OpenAPI spec falls short of its API, for the weekly "Spec gaps" issue.
//
// Two checks:
//
// 1. Endpoints in the API reference (docs.stripe.com) that the spec leaves out. Every reference
//    page has a Markdown version (<url>.md), and the resource pages list their endpoints as
//    `[POST /v1/...]` links; the sitemap lists the pages.
// 2. Response enums narrower than the request enums of the same operation: Stripe answers with a
//    value it accepts, and the response model cannot read it (e.g. `gb_bank_transfer` funding
//    instructions, #52).
//
// Compare against the spec with SpecPatches applied, so patched gaps drop off by themselves:
//
//     dotnet run --project tools/FunStripe.Generator -- --patched-spec patched.json
//     dotnet fsi tools/SpecGaps.fsx --spec patched.json --other-spec "latest GA=spec3.sdk.json" ...
//
// Known gaps that need no patch go in tools/spec_gaps_known.txt.

open System
open System.Collections.Generic
open System.IO
open System.Net.Http
open System.Text.Json
open System.Text.RegularExpressions

let usage =
    """Usage: dotnet fsi tools/SpecGaps.fsx --spec <path> --report <path> --new <path> [options]

  --spec <path>               our spec, with SpecPatches applied
  --other-spec <label=path>   another Stripe spec to classify gaps by, e.g. "beta=spec3.beta.sdk.json"
                              (repeatable; checked in the order given)
  --known <path>              known gaps (default: tools/spec_gaps_known.txt)
  --previous <path>           the issue body of the last run, to list what is new
  --cache <dir>               directory to cache docs pages in (local runs)
  --repo-url <url>            the repository's URL, for links in the report
  --report <path>             Markdown issue body to write
  --new <path>                file to write the keys of new gaps to"""

let fail (message: string) =
    eprintfn "%s" message
    exit 1

let options =
    let args = fsi.CommandLineArgs |> Array.tail
    if args |> Array.exists (fun a -> a = "--help" || a = "-h") then
        printfn "%s" usage
        exit 0
    let names = set [ "spec"; "other-spec"; "known"; "previous"; "cache"; "repo-url"; "report"; "new" ]
    args
    |> Array.chunkBySize 2
    |> Array.map (function
        | [| name; value |] when name.StartsWith("--", StringComparison.Ordinal) && names.Contains(name.Substring 2) ->
            name.Substring 2, value
        | other -> fail $"""Unexpected argument: {String.Join(" ", other)}

{usage}""")

let option name = options |> Array.tryFindBack (fun (n, _) -> n = name) |> Option.map snd
let required name = option name |> Option.defaultWith (fun () -> fail $"--{name} is required\n\n{usage}")

// Checked before the docs are read, which takes a while
let specPath = required "spec"
let reportPath = required "report"
let newPath = required "new"

let docs = "https://docs.stripe.com"
let methods = set [ "get"; "post"; "delete" ]

/// An operation: its method in capitals and its path with the parameters as `{}`
type Key = string * string

let http =
    let client = new HttpClient(Timeout = TimeSpan.FromSeconds 30.)
    client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "FunStripe spec gaps (github.com/simontreanor/FunStripe)") |> ignore
    client

let fetch (cache: string option) (url: string) =
    let file =
        cache
        |> Option.map (fun dir ->
            let name = if url.StartsWith(docs + "/", StringComparison.Ordinal) then url.Substring(docs.Length + 1) else url
            Path.Combine(dir, Regex.Replace(name, "[^A-Za-z0-9._-]", "_")))
    match file with
    | Some file when File.Exists file -> async { return Some(File.ReadAllText file) }
    | _ ->
        let rec attempt n =
            async {
                let! result = http.GetStringAsync url |> Async.AwaitTask |> Async.Catch
                match result with
                | Choice1Of2 text ->
                    file |> Option.iter (fun file -> File.WriteAllText(file, text))
                    return Some text
                | Choice2Of2 _ when n < 3 ->
                    do! Async.Sleep(2000 * n)
                    return! attempt (n + 1)
                | Choice2Of2 error ->
                    eprintfn "  ! %s: %s" url error.Message
                    return None
            }
        attempt 1

/// `/v1/customers/{customer}/cards` and `/v1/customers/:id/cards` both become `/v1/customers/{}/cards`
let norm (path: string) =
    Regex.Replace(path.Split('?').[0].TrimEnd('/'), @"\{[^}]+\}|:[A-Za-z_]+", "{}")

/// The operations of a spec, each with its path as the spec has it
let operations (spec: JsonElement) =
    let ops = Dictionary<Key, string>()
    for path in spec.GetProperty("paths").EnumerateObject() do
        for op in path.Value.EnumerateObject() do
            if methods.Contains op.Name then
                ops.[(op.Name.ToUpperInvariant(), norm path.Name)] <- path.Name
    ops

/// `/v1/reserve/holds/{}` -> `/v1/reserve/holds`, `/v1/reserve`: the resource and its product
let resources (path: string) =
    let parts = path.Split('/') |> Array.filter (fun p -> p <> "" && p <> "{}")
    [ for n in [ 3; 2 ] do
          if parts.Length >= n then "/" + String.Join("/", parts.[.. n - 1]) ]

let hasResource (ops: Dictionary<Key, string>) (prefix: string) =
    ops.Keys |> Seq.exists (fun (_, path) -> path = prefix || path.StartsWith(prefix + "/", StringComparison.Ordinal))

let documentedEndpoints cache =
    let sitemap = fetch cache $"{docs}/sitemap.xml" |> Async.RunSynchronously |> Option.defaultValue ""
    let pages =
        Regex.Matches(sitemap, $"<loc>({Regex.Escape docs}/api/[^<]+)</loc>")
        |> Seq.map (fun m -> m.Groups.[1].Value)
        |> Seq.distinct
        |> Seq.sortWith (fun a b -> String.CompareOrdinal(a, b))
        |> Array.ofSeq
    let texts = Async.Parallel(pages |> Array.map (fun url -> fetch cache (url + ".md")), 6) |> Async.RunSynchronously
    let failed = Array.zip pages texts |> Array.filter (snd >> Option.isNone) |> Array.map fst
    let found = Dictionary<Key, string * string>()
    for url, text in Array.zip pages texts do
        for m in Regex.Matches(defaultArg text "", @"\[(GET|POST|DELETE) (/v[12]/[^\]\s]+)\]") do
            let key = m.Groups.[1].Value, norm m.Groups.[2].Value
            if not (found.ContainsKey key) then found.[key] <- (m.Groups.[2].Value, url)
    pages, failed, found

// --- request/response enum check -------------------------------------------------------------

/// The node at `path` under `node`, or an undefined element where any step is missing
let at (path: string list) (node: JsonElement) =
    path
    |> List.fold
        (fun (n: JsonElement) key ->
            match n.ValueKind with
            | JsonValueKind.Object ->
                match n.TryGetProperty key with
                | true, child -> child
                | _ -> JsonElement()
            | _ -> JsonElement())
        node

/// (field path, enum values) for every string enum reachable from `schema`
let rec enums (spec: JsonElement) (schema: JsonElement) (path: string list) (seen: Set<string>) depth : (string * Set<string>) seq =
    seq {
        if schema.ValueKind = JsonValueKind.Object && depth <= 12 then
            match schema.TryGetProperty "$ref" with
            | true, ref ->
                let ref = ref.GetString()
                if not (seen.Contains ref) then
                    let target = spec |> at (ref.TrimStart('#', '/').Split('/') |> List.ofArray)
                    yield! enums spec target path (seen.Add ref) (depth + 1)
            | _ ->
                for key in [ "anyOf"; "oneOf"; "allOf" ] do
                    match schema.TryGetProperty key with
                    | true, alternatives when alternatives.ValueKind = JsonValueKind.Array ->
                        for alternative in alternatives.EnumerateArray() do
                            yield! enums spec alternative path seen (depth + 1)
                    | _ -> ()
                match schema.TryGetProperty "enum", schema.TryGetProperty "type" with
                | (true, values), (true, kind) when
                    values.ValueKind = JsonValueKind.Array && kind.ValueKind = JsonValueKind.String && kind.GetString() = "string"
                    ->
                    yield
                        String.Join(".", path),
                        set [ for v in values.EnumerateArray() -> if v.ValueKind = JsonValueKind.String then v.GetString() else v.GetRawText() ]
                | _ -> ()
                match schema.TryGetProperty "properties" with
                | true, properties when properties.ValueKind = JsonValueKind.Object ->
                    for property in properties.EnumerateObject() do
                        yield! enums spec property.Value (path @ [ property.Name ]) seen (depth + 1)
                | _ -> ()
                match schema.TryGetProperty "items" with
                | true, items -> yield! enums spec items path seen (depth + 1)
                | _ -> ()
    }

/// The values of each field path, in the order the paths are first found
let collect (pairs: (string * Set<string>) seq) =
    let found = Dictionary<string, Set<string>>()
    for path, values in pairs do
        found.[path] <-
            match found.TryGetValue path with
            | true, existing -> existing + values
            | _ -> values
    found

/// Operations whose response enum leaves out values their request enum accepts
let narrowResponses (spec: JsonElement) =
    [ for path in spec.GetProperty("paths").EnumerateObject() do
          for op in path.Value.EnumerateObject() do
              if methods.Contains op.Name then
                  // Form bodies only: query filters take values no object has, such as status=all
                  let request = op.Value |> at [ "requestBody"; "content"; "application/x-www-form-urlencoded"; "schema" ]
                  let response = op.Value |> at [ "responses"; "200"; "content"; "application/json"; "schema" ]
                  let answers = collect (enums spec response [] Set.empty 0)
                  for KeyValue(field, accepted) in collect (enums spec request [] Set.empty 0) do
                      match answers.TryGetValue field with
                      | true, has ->
                          let missing = accepted - has - set [ "" ]
                          if not missing.IsEmpty then
                              op.Name.ToUpperInvariant(), path.Name, field, Set.toList missing, Set.toList has
                      | _ -> () ]

// --- report ----------------------------------------------------------------------------------

let known path =
    let keys = Dictionary<string, string>()
    if File.Exists path then
        for line in File.ReadLines path do
            let key, reason =
                match line.IndexOf '#' with
                | -1 -> line, ""
                | i -> line.Substring(0, i), line.Substring(i + 1)
            if key.Trim() <> "" then keys.[key.Trim()] <- reason.Trim()
    keys

let readSpec (path: string) =
    use stream = File.OpenRead path
    (JsonDocument.Parse stream).RootElement

let cache = option "cache"
cache |> Option.iter (Directory.CreateDirectory >> ignore)
let spec = readSpec specPath
let ours = operations spec
let others =
    [ for name, value in options do
          if name = "other-spec" then
              match value.IndexOf '=' with
              | -1 -> fail $"--other-spec takes label=path, not {value}"
              | i -> value.Substring(0, i), operations (readSpec (value.Substring(i + 1))) ]
let accepted = known (option "known" |> Option.defaultValue (Path.Combine(__SOURCE_DIRECTORY__, "spec_gaps_known.txt")))
let repoUrl =
    option "repo-url"
    |> Option.defaultWith (fun () ->
        let env name fallback = Environment.GetEnvironmentVariable name |> Option.ofObj |> Option.defaultValue fallback
        $"""{env "GITHUB_SERVER_URL" "https://github.com"}/{env "GITHUB_REPOSITORY" "simontreanor/FunStripe"}""")

let pages, failed, documented = documentedEndpoints cache
if documented.Count < 300 then
    fail $"Only {documented.Count} endpoints found in {pages.Length} docs pages: has the docs format changed?"

let gaps = ResizeArray<string * string>()
let elsewhere = ResizeArray<string * string * string>()
let listed = ResizeArray<string * string>()
let mutable v2 = 0
for (method, normed) as key in documented.Keys |> Seq.filter (ours.ContainsKey >> not) |> Seq.sortBy (fun (m, p) -> p, m) do
    let _, url = documented.[key]
    let text = $"{method} {normed}"
    let inOther = others |> List.tryFind (fun (_, ops) -> ops.ContainsKey key) |> Option.map fst
    // A preview product: the rest of its resource is in a preview spec, none of it in ours
    let previewResource () =
        resources normed
        |> List.filter (hasResource ours >> not)
        |> List.tryPick (fun prefix -> others |> List.tryFind (fun (_, ops) -> hasResource ops prefix) |> Option.map (fun (label, _) -> label, prefix))
    if normed.StartsWith("/v2/", StringComparison.Ordinal) then v2 <- v2 + 1
    elif accepted.ContainsKey text then listed.Add(text, accepted.[text])
    else
        match inOther with
        | Some label -> elsewhere.Add(text, $"in Stripe's {label} spec", url)
        | None ->
            match previewResource () with
            | Some(label, prefix) -> elsewhere.Add(text, $"the rest of `{prefix}` is in Stripe's {label} spec", url)
            | None -> gaps.Add(text, url)
let undocumented =
    [ for KeyValue((method, _) as key, path) in ours do
          if not (documented.ContainsKey key) && path.StartsWith("/v1/", StringComparison.Ordinal) then $"{method} {path}" ]
    |> List.sort

let narrow = ResizeArray<string * string * string * string * string list * string list>()
for method, path, field, missing, answers in narrowResponses spec do
    let text = $"{method} {norm path} {field}"
    if accepted.ContainsKey text then listed.Add(text, accepted.[text])
    else narrow.Add(text, method, path, field, missing, answers)

let keys = [ for text, _ in gaps -> text ] @ [ for text, _, _, _, _, _ in narrow -> text ]
let previous =
    match option "previous" with
    | Some path when File.Exists path ->
        let block = Regex.Match(File.ReadAllText path, @"<!-- gap keys\r?\n(.*?)-->", RegexOptions.Singleline)
        if block.Success then
            block.Groups.[1].Value.Split([| '\r'; '\n' |], StringSplitOptions.RemoveEmptyEntries) |> set
        else Set.empty
    | _ -> Set.empty
let fresh = keys |> List.filter (previous.Contains >> not)
File.WriteAllText(newPath,String.Join("", fresh |> List.map (fun k -> k + "\n")))

let code (values: string list) = String.Join(", ", values |> List.map (fun v -> $"`{v}`"))
let lines (items: string seq) = String.Join("\n", items)
let report =
    [ $"Places where Stripe's OpenAPI spec falls short of its API, found by [`tools/SpecGaps.fsx`]({repoUrl}/blob/main/tools/SpecGaps.fsx) "
      + $"in the weekly [Spec gaps]({repoUrl}/actions/workflows/spec-gaps.yml) workflow. It compares the spec we generate from, "
      + "with `SpecPatches` applied, against Stripe's API reference. A gap is closed by a patch in "
      + "`tools/FunStripe.Generator/SpecPatches.fs`, or listed in `tools/spec_gaps_known.txt` when no patch is needed. "
      + "This issue is rewritten on each run.\n"
      $"## Documented endpoints missing from the spec ({gaps.Count})\n"
      "In the API reference but in none of Stripe's specs.\n"
      (if gaps.Count = 0 then "None." else lines [ for text, url in gaps -> $"- [ ] `{text}` ([docs]({url}))" ])
      $"\n## Responses that cannot read values their request accepts ({narrow.Count})\n"
      "The request enum accepts values the response enum leaves out, so the response model fails on an answer Stripe can give.\n"
      (if narrow.Count = 0 then "None."
       else lines [ for _, m, p, f, missing, has in narrow -> $"- [ ] `{m} {p}` `{f}`: the response lacks {code missing} (has {code has})" ])
      "\n<details><summary>Other documented endpoints we don't generate</summary>\n"
      $"- **v2:** {v2} endpoints. FunStripe generates the v1 API only."
      String.Join("", [ for text, why, url in elsewhere -> $"\n- `{text}`: {why} ([docs]({url}))" ])
      String.Join("", [ for text, reason in listed -> $"\n- `{text}`: known, {reason}" ])
      "\n</details>\n"
      $"<details><summary>In the spec, not in the API reference ({undocumented.Length}), often deprecated</summary>\n"
      (if undocumented.IsEmpty then "None." else lines [ for text in undocumented -> $"- `{text}`" ])
      "\n</details>\n"
      $"{documented.Count} documented endpoints in {pages.Length} reference pages; {ours.Count} operations in our spec."
      + (if failed.Length = 0 then "" else $" {failed.Length} pages could not be read, so endpoints on them count as undocumented.")
      "\n<!-- gap keys\n" + String.Join("", keys |> List.map (fun k -> k + "\n")) + "-->\n" ]
File.WriteAllText(reportPath, lines report)

printfn $"{gaps.Count} missing endpoints, {narrow.Count} narrow responses, {fresh.Length} new"
match Environment.GetEnvironmentVariable "GITHUB_OUTPUT" with
| null | "" -> ()
| output -> File.AppendAllText(output, $"gaps={keys.Length}\nnew={fresh.Length}\n")
