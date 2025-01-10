number_1 = float(input("Enter first number: "))
number_2 = float(input("Enter second number: "))

while number_1 != number_2:
    if number_1 > number_2:
        number_1 = number_1 - number_2
    else:
        number_2 = number_2 - number_1
print(number_1)