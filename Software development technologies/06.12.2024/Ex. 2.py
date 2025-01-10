def has_duplicates_1(list_val):
    dict_from_string = {}
    for i in range(len(list_val)):
        dict_from_string[list_val[i]] = 0
    for i in range(len(list_val)):
        dict_from_string[list_val[i]] += 1
    for key, value in dict_from_string.items():
        if value > 1:
            return True
    return False

def has_duplicates_2(list_val):
    for i in range(len(list_val)):
        for j in range(i + 1, len(list_val)):
            if list_val[i] == list_val[j]:
                return True
    return False

list_value = input("Enter a list: ").split(',')

if has_duplicates_1(list_value):
    print("True")
else:
    print("False")

if has_duplicates_2(list_value):
    print("True")
else:
    print("False")