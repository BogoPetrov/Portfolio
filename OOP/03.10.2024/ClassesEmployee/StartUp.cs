using CarManufacturer;

namespace ClassesEmployee
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Employee employee1 = new Employee("Dan", 20);
            //Employee employee2 = new Employee("Joey", 18);
            //Employee employee3 = new Employee("Tommy", 43);

            Console.Write("Enter number of part you want to do (1 to 3): ");
            int part = int.Parse(Console.ReadLine()!);

            if (part == 1)
            {
                Console.Clear();

                Department department = new();
                AddEmployees(ref department);
                Console.WriteLine();
                PrintEmployee(department.GetOldest());

                Console.WriteLine();

                Department oldDepartment = IsOver30(ref department);
                Console.WriteLine("Employees over 30:");
                for (int i = 0; i < oldDepartment.Employees.Count; i++)
                {
                    Console.WriteLine(oldDepartment.Employees[i].Name + " - " + oldDepartment.Employees[i].Age);
                }
            }
            if (part == 2)
            {
                Console.Clear();

                List<Driver> drivers = [];
                AddDrivers(ref drivers);
                Console.WriteLine();
                PrintBestDriver(ref drivers);
            }
            if (part == 3)
            {
                Console.Clear();

                Bank();
            }
            Console.ReadKey(true);
        }

        public static void AddEmployees(ref Department department)
        {
            //Console.Write("Enter how many employees you want to add: ");
            int numberOfEmployees = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < numberOfEmployees; i++)
            {
                //Console.Write("Enter info for employee: ");
                string[] info = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                while (true)
                {
                    if (info.Length == 2)
                    {
                        department.AddMember(new Employee(info[0], int.Parse(info[1])));
                        break;
                    }
                    else
                    {
                        Console.Write("Enter valid info for employee again: ");
                        info = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    }
                }
            }
        }

        public static void PrintEmployee(Employee employee)
        {
            Console.WriteLine(employee.Name + " " + employee.Age);
        }

        public static Department IsOver30(ref Department department)
        {
            Department newDepartment = new();
            foreach (Employee employee in department.Employees)
            {
                if (employee.Age > 30)
                {
                    newDepartment.AddMember(employee);
                }
            }
            return newDepartment;
        }

        public static void AddDrivers(ref List<Driver> drivers)
        {
            //Console.Write("Enter how many drivers you want to add: ");
            int numberOfDrivers = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < numberOfDrivers; i++)
            {
                //Console.Write("Enter info for driver: ");
                string[] info = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                while (true)
                {
                    if (info.Length == 5)
                    {
                        drivers.Add(new Driver(info[0] + " " + info[1], int.Parse(info[2]), double.Parse(info[3]), int.Parse(info[4])));
                        break;
                    }
                    else
                    {
                        Console.Write("Enter valid info for driver again: ");
                        info = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    }
                }
            }
        }

        public static void PrintBestDriver(ref List<Driver> drivers)
        {
            Driver bestDriver = drivers[0];
            foreach (Driver driver in drivers)
            {
                if (bestDriver.TotalTime > driver.TotalTime)
                {
                    bestDriver = driver;
                }
            }
            Console.WriteLine(
                $"DriverName: {bestDriver.Name}\n" +
                $"  DriverAge: {bestDriver.Age}\n" +
                $"    Time: {bestDriver.TotalTime}\n" +
                $"    Speed: {bestDriver.Speed}");
        }

        public static void Bank()
        {
            BankAccount account = new();

            //Console.Write("Enter info for bank account: ");
            string[] info = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (true)
            {
                if (info.Length == 4)
                {
                    account = new BankAccount(info[0], info[1] + " " + info[2], decimal.Parse(info[3]));
                    break;
                }
                else
                {
                    Console.Write("Enter valid info for bank account again: ");
                    info = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }
            }

            string input;
            string[] inputInfo;
            while (true)
            {
                input = Console.ReadLine()!;
                if (input.Equals("End", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    inputInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (inputInfo.Length == 2)
                    {
                        switch (inputInfo[0].ToLower())
                        {
                            case "deposit":
                                account.MakeDeposit(decimal.Parse(inputInfo[1]));
                                break;
                            case "withdrawal":
                                account.MakeWithdrawal(decimal.Parse(inputInfo[1]));
                                break;
                        }
                    }
                }
            }
        }
    }
}
