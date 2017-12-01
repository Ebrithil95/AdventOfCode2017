file = open("input.txt")

input = file.readline()
input += input[0]

sum=0
for index in range(len(input) - 1):
    if (input[index] == input[index + 1]):
        sum += int(input[index])

print(sum)