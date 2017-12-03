file = open("input.txt", "r")

input = file.readlines()

sumOne = 0
sumTwo = 0
for line in input:
    vals = [int(i) for i in line.split()]
    sumOne += max(vals) - min(vals)

    for i in range(len(vals)):
        for j in range(len(vals)):
            if (i != j and vals[i] % vals[j] == 0):
                sumTwo += vals[i] / vals[j]

print(sumOne)
print(sumTwo)