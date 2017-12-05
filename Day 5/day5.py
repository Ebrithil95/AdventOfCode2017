file = open("input.txt", "r")

lines = file.readlines()

index = 0
jumps = 0
while index >= 0 and index < len(lines):
	num = int(lines[index])
	lines[index] = num + 1
	index += num
	jumps += 1

print(jumps)

file = open("input.txt", "r")
lines = file.readlines()

index = 0
jumps = 0
while index >= 0 and index < len(lines):
	num = int(lines[index])
	lines[index] = num - 1 if num >= 3 else num + 1
	index += num
	jumps += 1

print(jumps)