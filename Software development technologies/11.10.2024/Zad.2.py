import math

# Zad.2
# Enter radius of circle and then calculate its perimeter
radius = float(input("Enter radius of a circle: "))
if radius <= 0:
    while True:
        radius = float(input("Enter valid radius: "))
        if radius > 0:
            break

circle_perimeter = 2 * math.pi * radius
print(f"The perimeter of circle is: {circle_perimeter:.3f}")