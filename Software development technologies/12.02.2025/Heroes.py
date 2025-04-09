class Hero:
    def __init__(self, name, strength, health):
        self.name = name
        self.strength = strength
        self.health = health

    def attack(self):
        return self.strength

    def hit(self, points):
        self.health -= points

    def is_alive(self):
        return self.health > 0

    def print(self):
        print(f"{self.name} ({self.__class__.__name__}) - Strength: {self.strength}, Health: {self.health}")

class Warrior(Hero):
    def __init__(self, name):
        super().__init__(name, strength=15, health=100)

class Archer(Hero):
    def __init__(self, name):
        super().__init__(name, strength=12, health=80)

class Mage(Hero):
    def __init__(self, name):
        super().__init__(name, strength=18, health=70)