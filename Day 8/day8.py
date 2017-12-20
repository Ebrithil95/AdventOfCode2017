import re
pattern = re.compile("([a-z]+) ((?:inc)|(?:dec)) (-?\d+) if ([a-z]+) ([!=<>]+) (-?\d+)")

lines = open("input.txt", "r").readlines()

registers = dict()

for line in lines:
    match = pattern.match(line)

    if match:
        register = match.group(1)
        operation = match.group(2)
        change = int(match.group(3))
        conRegister = match.group(4)
        check = match.group(5)
        checkVal = int(match.group(6))

        if operation == "dec":
            change *= -1

        conRegisterVal = int(registers.get(conRegister, 0))
        if check == ">":
            if conRegisterVal > checkVal:
                registers[register] = registers.get(register, 0) + change
        if check == ">=":
            if conRegisterVal >= checkVal:
                registers[register] = registers.get(register, 0) + change
        if check == "<":
            if conRegisterVal < checkVal:
                registers[register] = registers.get(register, 0) + change
        if check == "<=":
            if conRegisterVal <= checkVal:
                registers[register] = registers.get(register, 0) + change
        if check == "==":
            if conRegisterVal == checkVal:
                registers[register] = registers.get(register, 0) + change
        if check == "!=":
            if conRegisterVal != checkVal:
                registers[register] = registers.get(register, 0) + change

print(max(registers.values()))