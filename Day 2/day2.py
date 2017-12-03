file = open("input.txt", "r")

input = file.readlines()

sum = 0;
for line in input:
    vals = [int(i) for i in line.split()]
    sum += max(vals) - min(vals)

print(sum)