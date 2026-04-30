"""Analyse the remaining cycle: which schema references hold the giant SCC together?"""
import json
import collections

with open('spec/stripe-openapi-2026-04-22.dahlia.json', encoding='utf-8') as f:
    data = json.load(f)
schemas = data['components']['schemas']

CANONICAL = {
    'account', 'customer', 'charge', 'invoice', 'subscription', 'subscription_schedule',
    'payment_intent', 'setup_intent', 'payment_method', 'payment_link', 'card',
    'mandate', 'source', 'transfer', 'refund', 'payment_attempt_record',
    'issuing_authorization', 'issuing_card', 'issuing_cardholder', 'issuing_dispute',
    'issuing_token', 'issuing_transaction', 'credit_note', 'credit_note_line_item',
    'cash_balance', 'funding_instructions', 'invoice_payment', 'item',
    'payment_intent_amount_details_line_item', 'person', 'promotion_code', 'radar',
    'setup_attempt', 'token', 'billing', 'checkout', 'test_helpers', 'thresholds',
}


def domain_of(name):
    if '.' in name:
        return name.split('.')[0]
    # Find longest canonical prefix
    matches = [d for d in CANONICAL if name == d or name.startswith(d + '_')]
    if matches:
        return max(matches, key=len)
    return name.split('_')[0]


def collect_refs(node):
    refs = set()
    if isinstance(node, dict):
        if '$ref' in node and isinstance(node['$ref'], str) and node['$ref'].startswith('#/components/schemas/'):
            refs.add(node['$ref'].split('/')[-1])
        for v in node.values():
            refs |= collect_refs(v)
    elif isinstance(node, list):
        for v in node:
            refs |= collect_refs(v)
    return refs


def collect_refs_excluding_expandable(node):
    """Collect refs but skip those inside an anyOf that contains a string member (expandable)."""
    refs = set()
    if isinstance(node, dict):
        if 'anyOf' in node and isinstance(node['anyOf'], list):
            items = [it for it in node['anyOf'] if isinstance(it, dict)]
            has_string = any(it.get('type') == 'string' for it in items)
            has_ref = any('$ref' in it for it in items)
            if has_string and has_ref:
                # Skip the entire anyOf — these are expandables, now strings
                return refs
        if '$ref' in node and isinstance(node['$ref'], str) and node['$ref'].startswith('#/components/schemas/'):
            refs.add(node['$ref'].split('/')[-1])
        for v in node.values():
            refs |= collect_refs_excluding_expandable(v)
    elif isinstance(node, list):
        for v in node:
            refs |= collect_refs_excluding_expandable(v)
    return refs


# Build dependency graph excluding expandables
graph = {}
for name, sch in schemas.items():
    refs = collect_refs_excluding_expandable(sch) - {name}
    refs = {r for r in refs if r in schemas}
    graph[name] = refs

# Find cross-domain edges between top-level resources only
top_resources = [n for n in schemas if not n.startswith('deleted_')]
top_resources = [n for n in top_resources if (
    isinstance(schemas[n].get('properties'), dict)
    and 'object' in schemas[n].get('properties', {})
)]

# Cross-domain edges between resources where the domains differ
print(f"Top-level resources: {len(top_resources)}")
cross_edges = collections.Counter()
for src in top_resources:
    src_dom = domain_of(src)
    for tgt in graph[src]:
        tgt_dom = domain_of(tgt)
        if src_dom != tgt_dom:
            cross_edges[(src_dom, tgt_dom)] += 1

print(f"\nTop cross-domain edges (post-expandable removal):")
for (s, t), c in cross_edges.most_common(40):
    print(f"  {s:30s} -> {t:30s}  ({c} refs)")

# Find which specific schema fields create back-edges (indicate cycle)
# E.g. customer -> subscription AND subscription -> customer
print(f"\nMutual cross-domain references (cycles):")
seen = set()
mutuals = []
for (s, t), c in cross_edges.items():
    if (t, s) in cross_edges and (t, s) not in seen:
        mutuals.append(((s, t), c, cross_edges[(t, s)]))
        seen.add((s, t))
for ((s, t), c1, c2) in sorted(mutuals, key=lambda x: -(x[1] + x[2]))[:30]:
    print(f"  {s} <-> {t}  ({c1} forward, {c2} reverse)")
