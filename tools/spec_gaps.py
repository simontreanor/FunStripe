"""Finds where Stripe's OpenAPI spec falls short of its API, for the weekly "Spec gaps" issue.

Two checks:

1. Endpoints in the API reference (docs.stripe.com) that the spec leaves out. Every reference
   page has a Markdown version (<url>.md), and the resource pages list their endpoints as
   `[POST /v1/...]` links; the sitemap lists the pages.
2. Response enums narrower than the request enums of the same operation: Stripe answers with a
   value it accepts, and the response model cannot read it (e.g. `gb_bank_transfer` funding
   instructions, #52).

Compare against the spec with SpecPatches applied, so patched gaps drop off by themselves:

    dotnet run --project tools/FunStripe.Generator -- --patched-spec patched.json
    python -I tools/spec_gaps.py --spec patched.json --other-spec newer=spec3.sdk.json ...

Known gaps that need no patch go in tools/spec_gaps_known.txt.
"""
import argparse, concurrent.futures, json, os, re, sys, time, urllib.request

DOCS = "https://docs.stripe.com"
METHODS = ("get", "post", "delete")


def fetch(url, cache):
    name = os.path.join(cache, re.sub(r"[^A-Za-z0-9._-]", "_", url.removeprefix(DOCS + "/"))) if cache else None
    if name and os.path.exists(name):
        return open(name, encoding="utf-8").read()
    for attempt in range(3):
        try:
            req = urllib.request.Request(url, headers={"User-Agent": "FunStripe spec gaps (github.com/simontreanor/FunStripe)"})
            text = urllib.request.urlopen(req, timeout=30).read().decode("utf-8")
            if name:
                open(name, "w", encoding="utf-8").write(text)
            return text
        except Exception as e:
            error = e
            time.sleep(2 * (attempt + 1))
    print(f"  ! {url}: {error}", file=sys.stderr)
    return None


def norm(path):
    """`/v1/customers/{customer}/cards` and `/v1/customers/:id/cards` both become `/v1/customers/{}/cards`."""
    return re.sub(r"\{[^}]+\}|:[A-Za-z_]+", "{}", path.split("?")[0].rstrip("/"))


def operations(spec):
    return {(m.upper(), norm(p)): p for p, ops in spec["paths"].items() for m in ops if m in METHODS}


def resources(path):
    """`/v1/reserve/holds/{}` -> `/v1/reserve/holds`, `/v1/reserve`: the resource and its product."""
    parts = [p for p in path.split("/") if p and p != "{}"]
    return ["/" + "/".join(parts[:n]) for n in (3, 2) if len(parts) >= n]


def has_resource(ops, prefix):
    return any(path == prefix or path.startswith(prefix + "/") for _, path in ops)


def documented_endpoints(cache):
    sitemap = fetch(f"{DOCS}/sitemap.xml", cache) or ""
    pages = sorted(set(re.findall(rf"<loc>({re.escape(DOCS)}/api/[^<]+)</loc>", sitemap)))
    with concurrent.futures.ThreadPoolExecutor(6) as pool:
        texts = dict(zip(pages, pool.map(lambda u: fetch(u + ".md", cache), pages)))
    failed = [u for u, t in texts.items() if t is None]
    found = {}
    for url, text in texts.items():
        for method, path in re.findall(r"\[(GET|POST|DELETE) (/v[12]/[^\]\s]+)\]", text or ""):
            found.setdefault((method, norm(path)), (path, url))
    return pages, failed, found


# --- request/response enum check -------------------------------------------------------------

def enums(spec, schema, path=(), seen=frozenset(), depth=0):
    """(field path, enum values) for every string enum reachable from `schema`."""
    if not isinstance(schema, dict) or depth > 12:
        return
    ref = schema.get("$ref")
    if ref:
        if ref in seen:
            return
        target = spec
        for part in ref.removeprefix("#/").split("/"):
            target = target[part]
        yield from enums(spec, target, path, seen | {ref}, depth + 1)
        return
    for key in ("anyOf", "oneOf", "allOf"):
        for alternative in schema.get(key, []):
            yield from enums(spec, alternative, path, seen, depth + 1)
    if "enum" in schema and schema.get("type") == "string":
        yield ".".join(path), set(schema["enum"])
    for name, prop in schema.get("properties", {}).items():
        yield from enums(spec, prop, path + (name,), seen, depth + 1)
    if "items" in schema:
        yield from enums(spec, schema["items"], path, seen, depth + 1)


def collect(pairs):
    found = {}
    for path, values in pairs:
        found.setdefault(path, set()).update(values)
    return found


def narrow_responses(spec):
    """Operations whose response enum leaves out values their request enum accepts."""
    gaps = []
    for path, ops in spec["paths"].items():
        for method, op in ops.items():
            if method not in METHODS:
                continue
            body = (op.get("requestBody", {}).get("content", {})
                    .get("application/x-www-form-urlencoded", {}).get("schema", {}))
            # Form bodies only: query filters take values no object has, such as status=all
            request = enums(spec, body)
            response = op.get("responses", {}).get("200", {}).get("content", {}).get("application/json", {}).get("schema", {})
            answers = collect(enums(spec, response))
            for field, accepted in collect(request).items():
                missing = accepted - answers.get(field, accepted) - {""}
                if missing:
                    gaps.append((method.upper(), path, field, sorted(missing), sorted(answers[field])))
    return gaps


# --- report ----------------------------------------------------------------------------------

def known(path):
    keys = {}
    if path and os.path.exists(path):
        for line in open(path, encoding="utf-8"):
            key, _, reason = line.partition("#")
            if key.strip():
                keys[key.strip()] = reason.strip()
    return keys


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--spec", required=True, help="our spec, with SpecPatches applied")
    ap.add_argument("--other-spec", action="append", default=[], metavar="LABEL=PATH",
                    help="another Stripe spec to classify gaps by, e.g. newer=, beta=, private preview=")
    ap.add_argument("--known", default=os.path.join(os.path.dirname(__file__), "spec_gaps_known.txt"))
    ap.add_argument("--previous", help="the issue body of the last run, to list what is new")
    ap.add_argument("--cache", help="directory to cache docs pages in (local runs)")
    ap.add_argument("--repo-url", default="{}/{}".format(os.environ.get("GITHUB_SERVER_URL", "https://github.com"),
                                                        os.environ.get("GITHUB_REPOSITORY", "simontreanor/FunStripe")))
    ap.add_argument("--report", required=True, help="Markdown issue body to write")
    ap.add_argument("--new", required=True, help="file to write the keys of new gaps to")
    args = ap.parse_args()

    if args.cache:
        os.makedirs(args.cache, exist_ok=True)
    spec = json.load(open(args.spec, encoding="utf-8"))
    ours = operations(spec)
    others = []
    for item in args.other_spec:
        label, _, path = item.partition("=")
        others.append((label, operations(json.load(open(path, encoding="utf-8")))))
    accepted = known(args.known)

    pages, failed, documented = documented_endpoints(args.cache)
    if len(documented) < 300:
        sys.exit(f"Only {len(documented)} endpoints found in {len(pages)} docs pages: has the docs format changed?")

    gaps, elsewhere, v2, listed = [], [], 0, []
    for key in sorted(documented.keys() - ours.keys(), key=lambda k: (k[1], k[0])):
        path, url = documented[key]
        text = f"{key[0]} {key[1]}"
        if key[1].startswith("/v2/"):
            v2 += 1
        elif text in accepted:
            listed.append((text, accepted[text]))
        elif spec_label := next((label for label, ops in others if key in ops), None):
            elsewhere.append((text, f"in Stripe's {spec_label} spec", url))
        elif found := next(((label, prefix) for prefix in resources(key[1]) if not has_resource(ours, prefix)
                            for label, ops in others if has_resource(ops, prefix)), None):
            # A preview product: the rest of its resource is in a preview spec, none of it in ours
            elsewhere.append((text, f"the rest of `{found[1]}` is in Stripe's {found[0]} spec", url))
        else:
            gaps.append((text, url))
    undocumented = sorted(f"{k[0]} {v}" for k, v in ours.items() if k not in documented and v.startswith("/v1/"))

    narrow = []
    for method, path, field, missing, answers in narrow_responses(spec):
        text = f"{method} {norm(path)} {field}"
        if text in accepted:
            listed.append((text, accepted[text]))
        else:
            narrow.append((text, method, path, field, missing, answers))

    keys = [g[0] for g in gaps] + [n[0] for n in narrow]
    previous = set()
    if args.previous and os.path.exists(args.previous):
        block = re.search(r"<!-- gap keys\n(.*?)-->", open(args.previous, encoding="utf-8").read(), re.S)
        previous = set(block.group(1).splitlines()) if block else set()
    new = [k for k in keys if k not in previous]
    open(args.new, "w", encoding="utf-8").write("".join(k + "\n" for k in new))

    out = []
    w = out.append
    w("Places where Stripe's OpenAPI spec falls short of its API, found by "
      f"[`tools/spec_gaps.py`]({args.repo_url}/blob/main/tools/spec_gaps.py) in the weekly "
      f"[Spec gaps]({args.repo_url}/actions/workflows/spec-gaps.yml) workflow. It compares the spec we generate from, "
      "with `SpecPatches` applied, against Stripe's API reference. A gap is closed by a patch in "
      "`tools/FunStripe.Generator/SpecPatches.fs`, or listed in `tools/spec_gaps_known.txt` when no patch is needed. "
      "This issue is rewritten on each run.\n")
    w(f"## Documented endpoints missing from the spec ({len(gaps)})\n")
    w("In the API reference but in none of Stripe's specs.\n")
    w("\n".join(f"- [ ] `{t}` ([docs]({u}))" for t, u in gaps) or "None.")
    w(f"\n## Responses that cannot read values their request accepts ({len(narrow)})\n")
    w("The request enum accepts values the response enum leaves out, so the response model fails on "
      "an answer Stripe can give.\n")
    w("\n".join(f"- [ ] `{m} {p}` `{f}`: the response lacks {', '.join(f'`{v}`' for v in miss)} "
                f"(has {', '.join(f'`{v}`' for v in has)})" for _, m, p, f, miss, has in narrow) or "None.")
    w("\n<details><summary>Other documented endpoints we don't generate</summary>\n")
    w(f"- **v2:** {v2} endpoints. FunStripe generates the v1 API only.")
    w("".join(f"\n- `{t}`: {why} ([docs]({u}))" for t, why, u in elsewhere))
    w("".join(f"\n- `{t}`: known, {reason}" for t, reason in listed))
    w("\n</details>\n")
    w(f"<details><summary>In the spec, not in the API reference ({len(undocumented)}), often deprecated</summary>\n")
    w("\n".join(f"- `{t}`" for t in undocumented) or "None.")
    w("\n</details>\n")
    w(f"{len(documented)} documented endpoints in {len(pages)} reference pages; {len(ours)} operations in our spec.")
    if failed:
        w(f" {len(failed)} pages could not be read, so endpoints on them count as undocumented.")
    w("\n<!-- gap keys\n" + "".join(k + "\n" for k in keys) + "-->\n")
    open(args.report, "w", encoding="utf-8").write("\n".join(out))

    print(f"{len(gaps)} missing endpoints, {len(narrow)} narrow responses, {len(new)} new")
    if os.environ.get("GITHUB_OUTPUT"):
        with open(os.environ["GITHUB_OUTPUT"], "a", encoding="utf-8") as output:
            output.write(f"gaps={len(keys)}\nnew={len(new)}\n")


if __name__ == "__main__":
    main()
