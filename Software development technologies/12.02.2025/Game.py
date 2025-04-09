import random
from Heroes import Warrior, Mage

def duel(hero_1, hero_2):
    print("The duel begins!")
    hero_1.print()
    hero_2.print()

    while hero_1.is_alive() and hero_2.is_alive():
        if random.choice([True, False]):
            damage = hero_1.attack()
            hero_2.hit(damage)
            print(f"{hero_1.name} attacks {hero_2.name} for {damage} damage!")
        else:
            damage = hero_2.attack()
            hero_1.hit(damage)
            print(f"{hero_2.name} attacks {hero_1.name} for {damage} damage!")

        hero_1.print()
        hero_2.print()
        print("-")

    winner = hero_1 if hero_1.is_alive() else hero_2
    print(f"The winner is {winner.name}!")

# Game start
hero1 = Warrior("Thor")
hero2 = Mage("Merlin")
duel(hero1, hero2)