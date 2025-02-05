import sys
sys.path.append(r"S:\Programming\Learning\C\C#\School\Work in class\Bogomil Petrov 11a\Software development technologies\24.01.2025")

from Point import Point

class TestPoint:
    point1 = 0
    point2 = 0

    def __init__(self, x1, y1, x2, y2):
        self.point1 = Point(x1, y1)
        self.point2 = Point(x2, y2)

    def add(self):
        return self.point1.x + self.point2.x, self.point1.y + self.point2.y

    def sub(self):
        return self.point1.x - self.point2.x, self.point1.y - self.point2.y

    def distance(self):
        return ((self.point1.x - self.point2.x) ** 2 + (self.point1.y - self.point2.y) ** 2) ** 0.5

    def run_test(self):
        print(f"Sum point of the two points: {self.add()}")
        print(f"Sub point of the two points{self.sub()}")
        print(f"Distance between point using Point class: {Point.distance(self.point1, self.point2):.2f}")
        print(f"Distance between point using this class: {self.distance():.2f}")