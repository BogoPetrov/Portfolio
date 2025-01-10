n = int(input("Enter how many numbers you want to see for Fibonacci squence: "))
if n <= 0:
    while n <= 0:
        n = int(input("Enter valid number: "))

fib_sequence = [0, 1]
while len(fib_sequence) < n:
    fib_sequence.append(fib_sequence[-1] + fib_sequence[-2])
print(f"Fibonacci sequence up to {n} terms: {fib_sequence}")