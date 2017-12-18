buckets = [int(i) for i in open("input.txt", "r").readline().split()]

oldBuckets = []

def redistribute(in_buckets):
    max_elem = max(in_buckets)
    index = in_buckets.index(max_elem)
    in_buckets[index] = 0

    while max_elem > 0:
        index = (index + 1) % len(in_buckets)
        in_buckets[index] += 1
        max_elem -= 1
    return in_buckets

while tuple(buckets) not in oldBuckets:
    oldBuckets.append(tuple(buckets))
    buckets = redistribute(buckets)

print(len(oldBuckets))
print(len(oldBuckets) - oldBuckets.index(tuple(buckets)))