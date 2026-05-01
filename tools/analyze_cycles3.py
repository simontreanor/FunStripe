"""Analyze cycles AFTER skipping both expandable AND polymorphic anyOf blocks
(matching the current collectSchemaRefs in ModelBuilderModular.fs).

Show the actual ref edges within each remaining SCC so we can see what direct
references are still creating cycles.
"""
import json
import re
from pathlib import Path
from collections import defaultdict

SPEC = Path(__file__).parent.parent / "spec" / "stripe-openapi-2026-04-22.dahlia.json"
spec = json.loads(SPEC.read_text(encoding="utf-8"))
schemas = spec["components"]["schemas"]


def normalize(name: str) -> str:
    return name.lower().replace(".", "_")


def collect_refs(node, refs_out, current_field_path=""):
    """Mirror ModelBuilderModular.collectSchemaRefs."""
    if isinstance(node, dict):
        # anyOf classification
        if "anyOf" in node and isinstance(node["anyOf"], list):
            members = node["anyOf"]
            has_string = any(
                isinstance(m, dict) and m.get("type") == "string" for m in members
            )
            ref_count = sum(
                1 for m in members if isinstance(m, dict) and "$ref" in m
            )
            if (has_string and ref_count > 0) or (not has_string and ref_count >= 2):
                # Skip — expandable or polymorphic
                return
        if "$ref" in node and isinstance(node["$ref"], str):
            r = node["$ref"]
            if r.startswith("#/components/schemas/"):
                refs_out.append((r.split("/")[-1], current_field_path))
        for k, v in node.items():
            collect_refs(v, refs_out, f"{current_field_path}.{k}")
    elif isinstance(node, list):
        for i, item in enumerate(node):
            collect_refs(item, refs_out, f"{current_field_path}[{i}]")


# Build module assignment using the SAME canonical-domain approach as the generator.
canonical_domains = set()
for name in schemas:
    if "." in name:
        canonical_domains.add(name.split(".")[0])
    else:
        # Top-level resource with object discriminator?
        s = schemas[name]
        if isinstance(s, dict) and "properties" in s:
            obj = s["properties"].get("object")
            if isinstance(obj, dict) and "enum" in obj:
                if name in obj["enum"]:
                    canonical_domains.add(name)
canonical_sorted = sorted(canonical_domains, key=lambda x: -len(x))


# Aliases (keep in sync with ModelBuilderModular.canonicalAliases)
aliases = {
    "invoices": "invoice", "subscriptions": "subscription", "quotes": "quote",
    "payments": "payment_method", "payment": "payment_method",
    "inbound": "treasury", "outbound": "treasury",
    "thresholds": "subscription", "level3": "charge", "klarna": "payment_method",
    "bank": "financial_connections", "portal": "billing_portal",
    "confirmation": "confirmation_token", "insights": "radar", "rule": "radar",
    "forwarded": "forwarding", "gelato": "identity",
    "legal": "account", "connect": "account", "credit": "billing",
    "currency": "price", "scheduled": "sigma", "promotion": "promotion_code",
    "external": "account", "linked": "account", "line_item": "invoice",
    "amazon": "payment_method", "revolut": "payment_method", "error": "misc",
}


def assign_module(schema_name: str) -> str:
    n = normalize(schema_name)
    if n.startswith("deleted_"):
        n = n[len("deleted_"):]
    for d in canonical_sorted:
        if n == d or n.startswith(d + "_"):
            return d
    first = n.split("_")[0]
    if first in aliases and aliases[first] in canonical_domains:
        return aliases[first]
    if first.endswith("s") and first[:-1] in canonical_domains:
        return first[:-1]
    return first


# Build module-level ref graph
mod_refs = defaultdict(set)
mod_examples = defaultdict(list)
for name, schema in schemas.items():
    src_mod = assign_module(name)
    refs = []
    collect_refs(schema, refs)
    for tgt_name, path in refs:
        tgt_mod = assign_module(tgt_name)
        if src_mod != tgt_mod:
            mod_refs[src_mod].add(tgt_mod)
            if len(mod_examples[(src_mod, tgt_mod)]) < 3:
                mod_examples[(src_mod, tgt_mod)].append(f"{name}{path} -> {tgt_name}")


# Tarjan SCC on module graph
def tarjan(graph):
    idx_counter = [0]
    stack = []
    lowlink = {}
    index = {}
    on_stack = set()
    sccs = []

    def strongconnect(node):
        index[node] = idx_counter[0]
        lowlink[node] = idx_counter[0]
        idx_counter[0] += 1
        stack.append(node)
        on_stack.add(node)
        for neighbor in graph.get(node, ()):
            if neighbor not in index:
                strongconnect(neighbor)
                lowlink[node] = min(lowlink[node], lowlink[neighbor])
            elif neighbor in on_stack:
                lowlink[node] = min(lowlink[node], index[neighbor])
        if lowlink[node] == index[node]:
            scc = []
            while True:
                w = stack.pop()
                on_stack.remove(w)
                scc.append(w)
                if w == node:
                    break
            sccs.append(scc)

    nodes = set(graph.keys()) | {n for v in graph.values() for n in v}
    for n in nodes:
        if n not in index:
            strongconnect(n)
    return sccs


sccs = [s for s in tarjan({k: list(v) for k, v in mod_refs.items()}) if len(s) > 1]
sccs.sort(key=lambda s: -len(s))

print(f"Cyclic module groups (>1 module): {len(sccs)}")
print()
for scc in sccs:
    members = set(scc)
    print(f"SCC with {len(scc)} modules:")
    print(f"  {', '.join(sorted(scc))}")
    edges = []
    for src in scc:
        for tgt in mod_refs.get(src, ()):
            if tgt in members:
                examples = mod_examples.get((src, tgt), [])
                edges.append((src, tgt, len(examples), examples))
    edges.sort(key=lambda e: -e[2])
    print(f"  Edges within SCC ({len(edges)} total):")
    for src, tgt, count, examples in edges:
        print(f"    {src:30s} -> {tgt:30s} (e.g. {examples[0] if examples else '?'})")
    print()
