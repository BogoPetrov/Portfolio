class Point:
    count = 0

    def __init__(self, x, y):
        print("Call the constructor")
        self.x = x
        self.y = y
        Point.count = Point.count + 1

    def __print__(self):
        print(f"({self.x},{self.y}")

    @classmethod
    def get_count(cls):
        return cls.count

    @staticmethod
    def distance(p1, p2):
        return ((p1.x - p2.x) ** 2 + (p1.y - p2.y) ** 2) ** 0.5