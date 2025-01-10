import math

# Ex. 1
def is_triangle(a, b, c):
    return a + b > c and a + c > b and b + c > a

def triangle_type(a, b, c):
    if not is_triangle(a, b, c):
        return "Not a triangle"
    if a == b == c:
        return "Equilateral triangle"
    elif a == b or b == c or a == c:
        return "Isosceles triangle"
    else:
        return "Scalene triangle"

def perimeter(a, b, c):
    if is_triangle(a, b, c):
        return a + b + c
    else:
        return "Not a triangle"

def area_heron(a, b, c):
    if is_triangle(a, b, c):
        s = (a + b + c) / 2
        return math.sqrt(s * (s - a) * (s - b) * (s - c))
    else:
        return "Not a triangle"

def area_with_height(base, height):
    return 0.5 * base * height

# Ex. 2
def intersection(list1, list2):
    return list(set(list1) & set(list2))

def union(list1, list2):
    return list(set(list1) | set(list2))

def difference(list1, list2):
    return list(set(list1) - set(list2))

def reverse_list(lst):
    return lst[::-1]

def create_list():
    n = int(input("Enter the number of elements: "))
    return [int(input(f"Element {i + 1}: ")) for i in range(n)]

def test_triangles():
    print("=== TRIANGLE MODULE TEST ===")
    a, b, c = 3, 4, 5
    print(f"Sides: {a}, {b}, {c}")
    print("Is a triangle:", is_triangle(a, b, c))
    print("Triangle type:", triangle_type(a, b, c))
    print("Perimeter:", perimeter(a, b, c))
    print("Area (Heron's formula):", area_heron(a, b, c))
    print("Area (base and height):", area_with_height(4, 3))

def test_list_utils():
    print("\n=== LIST UTILITIES MODULE TEST ===")
    list1 = [1, 2, 3, 4, 5]
    list2 = [4, 5, 6, 7, 8]
    print(f"List 1: {list1}")
    print(f"List 2: {list2}")
    print("Intersection:", intersection(list1, list2))
    print("Union:", union(list1, list2))
    print("Difference (list1 - list2):", difference(list1, list2))
    print("Reversed list 1:", reverse_list(list1))
    print("Created list:", create_list())

# Ex. 1
test_triangles()

# Ex. 2
test_list_utils()