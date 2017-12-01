file = open("input.txt")

input = file.readline()

sum=0
for index in range(len(input)):
    compareIndex = (index + 1) % (len(input) - 1)
    if (input[index] == input[compareIndex]):
        sum += int(input[index])

print(sum)

sum=0
for index in range(len(input)):
    compareIndex = (index + int(len(input) / 2)) % (len(input) - 1)
    if (input[index] == input[compareIndex]):
        sum += int(input[index])

print(sum)