"""Use the generator's canonical-domain logic to find the actual cycle structure."""
import json
import collections

with open('spec/stripe-openapi-2026-04-22.dahlia.json', encoding='utf-8') as f:
    data = json.load(f)
schemas = data['components']['schemas']

# Replicate generator's canonical domain extraction
dot_prefixes = {n.split('.')[0] for n in schemas if '.' in n}
top_levels = set()
for name, sch in schemas.items():
    if '.' in name:
        continue
    props = sch.get('properties', {})
    if isinstance(props, dict):
        obj = props.get('object', {})
        if isinstance(obj, dict) and 'enum' in obj and obj['enum'] == [name]:
            top_levels.add(name)

canonical = (dot_prefixes | top_levels) - {n for n in (dot_prefixes | top_levels) if n.startswith('deleted_')}
canonical_sorted = sorted(canonical, key=lambda x: -len(x))


def domain_of(name):
    norm = name.lower().replace('.', '_')
    for d in canonical_sorted:
        if norm == d or norm.startswith(d + '_'):
            return d
    return norm.split('_')[0]


def collect_refs_excluding_expandable(node):
    refs = set()
    if isinstance(node, dict):
        if 'anyOf' in node and isinstance(node['anyOf'], list):
            items = [it for it in node['anyOf'] if isinstance(it, dict)]
            has_string = any(it.get('type') == 'string' for it in items)
            has_ref = any('$ref' in it for it in items)
            if has_string and has_ref:
                return refs
        if '$ref' in node and isinstance(node['$ref'], str) and node['$ref'].startswith('#/components/schemas/'):
            refs.add(node['$ref'].split('/')[-1])
        for v in node.values():
            refs |= collect_refs_excluding_expandable(v)
    elif isinstance(node, list):
        for v in node:
            refs |= collect_refs_excluding_expandable(v)
    return refs


# Build module-level edges
module_edges = collections.defaultdict(lambda: collections.Counter())
for name, sch in schemas.items():
    src_dom = domain_of(name)
    refs = collect_refs_excluding_expandable(sch) - {name}
    refs = {r for r in refs if r in schemas}
    for r in refs:
        tgt_dom = domain_of(r)
        if src_dom != tgt_dom:
            module_edges[(src_dom, tgt_dom)][(name, r)] += 1

# Tarjan SCC on module graph
adj = collections.defaultdict(set)
for (s, t) in module_edges:
    adj[s].add(t)
nodes = set(adj) | {t for ts in adj.values() for t in ts}

idx = [0]
stack = []
on_stack = set()
indices = {}
lowlinks = {}
sccs = []


def strongconnect(v):
    indices[v] = idx[0]
    lowlinks[v] = idx[0]
    idx[0] += 1
    stack.append(v)
    on_stack.add(v)
    for w in adj[v]:
        if w not in indices:
            strongconnect(w)
            lowlinks[v] = min(lowlinks[v], lowlinks[w])
        elif w in on_stack:
            lowlinks[v] = min(lowlinks[v], indices[w])
    if lowlinks[v] == indices[v]:
        comp = []
        while True:
            w = stack.pop()
            on_stack.discard(w)
            comp.append(w)
            if w == v:
                break
        sccs.append(comp)


import sys
sys.setrecursionlimit(5000)
for v in list(nodes):
    if v not in indices:
        strongconnect(v)

big_sccs = [s for s in sccs if len(s) > 1]
print(f"Cyclic module groups (>1 module): {len(big_sccs)}")
for s in sorted(big_sccs, key=len, reverse=True):
    print(f"\nSCC with {len(s)} modules:")
    print('  ' + ', '.join(sorted(s)))
    # Print the edges WITHIN the SCC
    s_set = set(s)
    edges_in_scc = []
    for (src, tgt), refs in module_edges.items():
        if src in s_set and tgt in s_set:
            for (sname, tname), _ in refs.items():
                edges_in_scc.append((src, sname, tgt, tname))
    edge_counts = collections.Counter((e[0], e[2]) for e in edges_in_scc)
    print(f'  Edges within SCC ({len(edges_in_scc)} total):')
    for (s, t), c in sorted(edge_counts.items(), key=lambda x: -x[1])[:20]:
        examples = [(sn, tn) for (sd, sn, td, tn) in edges_in_scc if sd == s and td == t][:2]
        print(f'    {s:30s} -> {t:30s}  ({c} refs, e.g. {examples[0][0]}.* -> {examples[0][1]})')
