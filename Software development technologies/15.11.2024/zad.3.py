def print_primes_in_range(m, n):
    def is_prime(num):
        if num < 2:
            return False
        for i in range(2, int(num ** 0.5) + 1):
            if num % i == 0:
                return False
        return True

    primes = [num for num in range(m, n + 1) if is_prime(num)]
    print(f"Prime numbers in range [{m} - {n}]:", primes)

print_primes_in_range(10, 30)
