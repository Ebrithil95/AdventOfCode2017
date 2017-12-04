import collections as c

file = open("input.txt", "r")

lines = file.readlines()

def contains_anagram(words):
    hasAnagram = False
    for i in range(len(words)):
        for j in range(i + 1, len(words)):
            if c.Counter(words[i]) == c.Counter(words[j]):
                hasAnagram = True
    return hasAnagram

valid = 0
valid2 = 0
for line in lines:
    words = line.split()
    if len(words) == len(set(words)):
        valid += 1
    if not contains_anagram(words):
        valid2 += 1

print(valid)
print(valid2)