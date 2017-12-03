file = open("input.txt", "r")

input = file.readline()

sumPart1=0
sumPart2=0
length=len(input)
for index in range(length):
    compareIndex = (index + 1) % (length - 1)
    if (input[index] == input[compareIndex]):
        sumPart1 += int(input[index])
    compareIndex = (index + int(length / 2)) % (length - 1)
    if (input[index] == input[compareIndex]):
        sumPart2 += int(input[index])

print(sumPart1)
print(sumPart2)