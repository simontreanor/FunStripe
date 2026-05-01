"""
Find every polymorphic non-expandable anyOf in the spec.
Returns sites where anyOf contains ONLY $ref members (no `string` type member),
which currently emit inline DUs and create cycles between domains.
"""
import json
from collections import defaultdict
from pathlib import Path

SPEC = Path(__file__).parent.parent / "spec" / "stripe-openapi-2026-04-22.dahlia.json"
spec = json.loads(SPEC.read_text(encoding="utf-8"))
schemas = spec["components"]["schemas"]


def walk(node, path, schema_name, sites):
    if isinstance(node, dict):
        if "anyOf" in node and isinstance(node["anyOf"], list):
            members = node["anyOf"]
            has_string = any(
                isinstance(m, dict) and m.get("type") == "string" for m in members
            )
            refs = [
                m["$ref"].split("/")[-1]
                for m in members
                if isinstance(m, dict) and "$ref" in m
            ]
            # Polymorphic non-expandable: 2+ refs, no string member
            if len(refs) >= 2 and not has_string:
                sites.append((schema_name, path, tuple(sorted(refs))))
        for k, v in node.items():
            walk(v, f"{path}.{k}", schema_name, sites)
    elif isinstance(node, list):
        for i, v in enumerate(node):
            walk(v, f"{path}[{i}]", schema_name, sites)


sites = []
for name, schema in schemas.items():
    walk(schema, "", name, sites)

# Distinct shapes (variant tuples)
by_shape = defaultdict(list)
for src, path, refs in sites:
    by_shape[refs].append((src, path))

print(f"Total polymorphic anyOf sites: {len(sites)}")
print(f"Distinct variant shapes:        {len(by_shape)}")
print()
print("--- Top 25 most-used variant shapes ---")
for shape, occurrences in sorted(by_shape.items(), key=lambda x: -len(x[1]))[:25]:
    print(f"  [{len(occurrences):3d}x] {' | '.join(shape)}")
    for src, path in occurrences[:3]:
        print(f"          {src}{path}")
    if len(occurrences) > 3:
        print(f"          ... ({len(occurrences) - 3} more)")
