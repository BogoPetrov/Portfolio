string_value = input("Enter a string: ")

dict_from_string = {}
for i in range(len(string_value)):
    dict_from_string[string_value[i]] = 0
for i in range(len(string_value)):
    dict_from_string[string_value[i]] += 1

for key, value in dict_from_string.items():
    print(key, ':', value)