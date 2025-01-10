import random

x = random.randint(1,20)
while True:
    user_number = int(input("Gess the number form 1 to 20: "))
    if user_number > x:
        print("Too high")
    elif user_number == x:
        print("You win!")
        break
    else:
        print("To low!")