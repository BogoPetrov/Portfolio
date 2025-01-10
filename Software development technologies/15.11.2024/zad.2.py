def count_prime_numbers(*args):
    def is_prime(number):
        if number < 2:
            return False
        for i in range(2, int(number ** 0.5) + 1):
            if number % i == 0:
                return False
        return True

    for num in args:
        if is_prime(num):
            print(num)

count_prime_numbers(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)