class Employee:
    def __init__(self, *args):
        if len(args) < 4:
            self.id= 1000
            self.first_name = "Unknown"
            self.last_name = "Unknown"
            self.salary = 0
        else:
            self.id = args[0]
            self.first_name = args[1]
            self.last_name = args[2]
            self.salary = args[3]

    def get_id(self):
        return self.id

    def set_id(self, id_number):
        self.id = id_number

    def get_first_name(self):
        return self.first_name

    def set_first_name(self, first_name):
        self.first_name = first_name

    def get_last_name(self):
        return self.last_name

    def set_last_name(self, last_name):
        self.last_name = last_name

    def get_salary(self):
        return self.salary

    def set_salary(self, salary):
        self.salary = salary


    def print(self):
        print(f"ID: {self.id}\nName: {self.first_name} {self.last_name}\nSalary: {self.salary}")

emp1 = Employee(1, "John", "Smith", 1000)
emp1.print()
print()
emp1.set_id(2)
emp1.print()