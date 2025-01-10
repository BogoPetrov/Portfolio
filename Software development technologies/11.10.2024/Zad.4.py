# Zad. 4
# Check if input data is correct
def check_is_correct(coordinate_1: float, coordinate_2: float, coordinate_name: str):
    if coordinate_1 > coordinate_2:
        while True:
            coordinate_2 = float(input(f"Enter value, which is bigger than {coordinate_1} {coordinate_name}: "))
            if coordinate_2 > coordinate_1:
                break


# Enters coordinates of point for a rectangle
x1 = float(input("Enter value for x1 coordinate: "))
x2 = float(input("Enter value for x2 coordinate: "))
check_is_correct(x1, x2, 'x1')
y1 = float(input("Enter value for y1 coordinate: "))
y2 = float(input("Enter value for y2 coordinate: "))
check_is_correct(y1, y2, 'y1')

x = float(input("Enter value for x coordinate of a point: "))
y = float(input("Enter value for y coordinate of a point: "))

if (x1 < x < x2) and (y1 < y < y2):
    print(f"The point with coordinates {x} : {y} is in this rectangle")
else:
    print(f"The point with coordinates {x} : {y} isn't in this rectangle")
