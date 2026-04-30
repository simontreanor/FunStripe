"""One-shot analysis: find expandable cross-references in the OpenAPI spec."""
import json
import collections

with open('spec/stripe-openapi-2026-04-22.dahlia.json', encoding='utf-8') as f:
    data = json.load(f)
schemas = data['components']['schemas']

expandable = []  # (source_schema, json_path, target_schema)


def walk(node, path, source):
    if isinstance(node, dict):
        # An expandable field is an anyOf with at least one string member and one $ref member
        if 'anyOf' in node and isinstance(node['anyOf'], list):
            items = [it for it in node['anyOf'] if isinstance(it, dict)]
            has_string = any(it.get('type') == 'string' for it in items)
            refs = [it['$ref'] for it in items if '$ref' in it]
            if has_string and refs:
                target = refs[0].split('/')[-1]
                expandable.append((source, path, target))
        for k, v in node.items():
            walk(v, path + '.' + k, source)
    elif isinstance(node, list):
        for i, v in enumerate(node):
            walk(v, path + f'[{i}]', source)


for name, sch in schemas.items():
    walk(sch, name, name)

print(f'Total expandable anyOf occurrences: {len(expandable)}')

# Group by target schema
target_counts = collections.Counter(t for _, _, t in expandable)
print(f'\nMost-referenced expansion targets:')
for t, c in target_counts.most_common(25):
    print(f'  {t:50s} {c}')

# Cross-domain edges: source domain -> target domain
def domain_of(name):
    if '.' in name:
        return name.split('.')[0]
    # Top-level resources in our canonical list
    return name


# Count how many cross-references would be broken if we converted ALL expandables to strings
src_targets = collections.defaultdict(set)
for s, _, t in expandable:
    src_targets[s].add(t)

print(f'\nUnique (source -> target) pairs from expandable fields: {sum(len(v) for v in src_targets.values())}')
print(f'Schemas that have expandable references: {len(src_targets)}')
