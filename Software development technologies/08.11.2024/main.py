def show_balance(balance: float):
    print("*" * 23)
    print(f"Your balance is ${balance:.2f}")
    print("*" * 23)


def deposit():
    print("*" * 23)
    amount = float(input("Enter the amount to be deposited: "))
    print("*" * 23)

    if amount < 0:
        print("*" * 23)
        print("Invalid amount. Please try again.")
        print("*" * 23)
        return 0
    else:
        return amount


def withdraw(balance: float):
    print("*" * 23)
    amount = float(input("Enter the amount to be withdrawn: "))
    print("*" * 23)

    if amount > balance:
        print("*" * 23)
        print("Insufficient funds. Please try again.")
        print("*" * 23)
        return 0
    elif amount < 0:
        print("*" * 23)
        print("Invalid amount. Please try again.")
        print("*" * 23)
        return 0
    else:
        return amount


def main():
    balance = 0
    is_running = True

    while is_running:
        print("*"*23)
        print("   Banking Program   ")
        print("*"*23)
        print("1. Show balance")
        print("2. Deposit")
        print("3. Withdraw")
        print("4. Exit")
        print("*"*23)
        choice = input("Enter your choice (1-4): ")

        match choice:
            case "1":
                show_balance(balance)
            case "2":
                balance += deposit()
            case "3":
                balance -= withdraw(balance)
            case "4":
                is_running = False
            case _:
                print("*"*23)
                print("Invalid choice. Please try again.")
                print("*"*23)

    print("*"*23)
    print("Thank you! Have a nice day!")
    print("*"*23)

if __name__ == "__main__":
    main()