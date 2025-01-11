using System.Runtime.CompilerServices;

namespace AbstractClass_Interface
{
    // ALL POINTS IN FILE "10.2-Abstract-Classes-and-Interfaces-Advanced-Exercises" ARE DONE IN ONLY THSI FILE
    // BECAUSE IT'S EASIER TO READ FOR THIS EXERCISE
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter which exercise you want to see (1 - 4): ");
            string? input = Console.ReadLine();
            Console.Clear();

            string[] inputData;
            List<Citizen> citizens = [];
            List<Robot> robots = [];
            List<Pet> pets = [];
            List<Rebel> rebels = [];

            switch (Convert.ToInt32(input))
            {
                // Ex. 1
                case 1:
                    input = Console.ReadLine();
                    do
                    {
                        inputData = input!.Split(' ');
                        switch (inputData.Length)
                        {
                            case 2:
                                Robot robot = new()
                                {
                                    Model = inputData[0],
                                    ID = inputData[1]
                                };
                                robots.Add(robot);
                                break;
                            case 3:
                                Citizen citizen = new()
                                {
                                    Name = inputData[0],
                                    Age = Convert.ToInt32(inputData[1]),
                                    ID = inputData[2]
                                };
                                citizens.Add(citizen);
                                break;
                        }

                        if (!input.Equals("end", StringComparison.OrdinalIgnoreCase))
                        {
                            input = Console.ReadLine();
                        }
                    }
                    while (!input!.Equals("end", StringComparison.OrdinalIgnoreCase));

                    if (citizens.Count > 0 || robots.Count > 0)
                    {
                        input = Console.ReadLine();
                        Console.Clear();

                        foreach (Citizen citizen in citizens)
                        {
                            if (citizen.ID!.Substring(citizen.ID!.Length - input!.Length, input!.Length).Equals(input!, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(citizen.ID);
                            }
                        }

                        foreach (Robot robot in robots)
                        {
                            if (robot.ID!.Substring(robot.ID!.Length - input!.Length, input!.Length).Equals(input!, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(robot.ID);
                            }
                        }
                    }
                    break;

                // Ex. 2
                case 2:
                    input = Console.ReadLine();
                    do
                    {
                        inputData = input!.Split(' ');
                        switch (inputData[0].ToLower())
                        {
                            case "robot":
                                Robot robot = new()
                                {
                                    Model = inputData[1],
                                    ID = inputData[2]
                                };
                                robots.Add(robot);
                                break;
                            case "citizen":
                                Citizen citizen = new()
                                {
                                    Name = inputData[1],
                                    Age = Convert.ToInt32(inputData[2]),
                                    ID = inputData[3],
                                    BirthDate = DateOnly.Parse(inputData[4])

                                };
                                citizens.Add(citizen);
                                break;
                            case "pet":
                                Pet pet = new()
                                {
                                    Name = inputData[1],
                                    BirthDate = DateOnly.Parse(inputData[2]),
                                };
                                pets.Add(pet);
                                break;
                        }

                        if (!input.Equals("end", StringComparison.OrdinalIgnoreCase))
                        {
                            input = Console.ReadLine();
                        }
                    }
                    while (!input!.Equals("end", StringComparison.OrdinalIgnoreCase));

                    if (citizens.Count > 0 || robots.Count > 0 || pets.Count > 0)
                    {
                        input = Console.ReadLine();
                        Console.Clear();

                        foreach (Citizen citizen in citizens)
                        {
                            if (citizen.BirthDate.Year == Convert.ToInt32(input!))
                            {
                                Console.WriteLine(citizen.BirthDate);
                            }
                        }

                        foreach (Pet pet in pets)
                        {
                            if (pet.BirthDate.Year == Convert.ToInt32(input!))
                            {
                                Console.WriteLine(pet.BirthDate);
                            }
                        }
                    }
                    break;

                // Ex. 3
                case 3:
                    input = Console.ReadLine();
                    int N = Convert.ToInt32(input);
                    for (int i = 0; i < N; i++)
                    {
                        input = Console.ReadLine();
                        inputData = input!.Split(' ');
                        switch (inputData.Length)
                        {
                            case 4:
                                Citizen citizen = new()
                                {
                                    Name = inputData[0],
                                    Age = Convert.ToInt32(inputData[1]),
                                    ID = inputData[2],
                                    BirthDate = DateOnly.Parse(inputData[3])
                                };
                                if (citizens.Find(check => check.Name == citizen.Name) == null)
                                {
                                    citizens.Add(citizen);
                                }
                                break;
                            case 3:
                                Rebel rebel = new()
                                {
                                    Name = inputData[0],
                                    Age = Convert.ToInt32(inputData[1]),
                                    Group = inputData[2]
                                };
                                if (rebels.Find(check => check.Name == rebel.Name) == null)
                                {
                                    rebels.Add(rebel);
                                }
                                break;
                        }
                    }

                    input = Console.ReadLine();
                    while (!input!.Equals("end", StringComparison.OrdinalIgnoreCase))
                    {
                        for (int i = 0; i < citizens.Count; i++)
                        {
                            if (citizens[i].Name!.Equals(input, StringComparison.OrdinalIgnoreCase))
                            {
                                citizens[i].ByFood();
                            }
                        }

                        for (int i = 0; i < rebels.Count; i++)
                        {
                            if (rebels[i].Name!.Equals(input, StringComparison.OrdinalIgnoreCase))
                            {
                                rebels[i].ByFood();
                            }
                        }

                        input = Console.ReadLine();
                    }

                    int totalFood = 0;
                    foreach (Citizen citizen in citizens)
                    {
                        totalFood += citizen.Food;
                    }
                    foreach (Rebel rebel in rebels)
                    {
                        totalFood += rebel.Food;
                    }

                    Console.Clear();
                    Console.WriteLine(totalFood);
                    break;

                // Ex. 4
                case 4:
                    input = Console.ReadLine();
                    do
                    {
                        inputData = input!.Split(' ');
                        if (inputData.Length == 3)
                        {
                            Citizen citizen = new()
                            {
                                Name = inputData[0],
                                Country = inputData[1],
                                Age = Convert.ToInt32(inputData[2])
                            };
                            if (citizens.Find(check => check.Name == citizen.Name) == null)
                            {
                                citizens.Add(citizen);
                            }
                        }
                        if (!input.Equals("end", StringComparison.OrdinalIgnoreCase))
                        {
                            input = Console.ReadLine();
                        }
                        else
                        {
                            throw new Exception("Invalid input!");
                        }
                    }
                    while (!input!.Equals("end", StringComparison.OrdinalIgnoreCase));

                    if (citizens.Count > 0)
                    {
                        Console.Clear();

                        foreach (Citizen citizen in citizens)
                        {
                            Console.WriteLine(citizen.GetName());
                            Console.WriteLine((citizen as IResident).GetName());
                        }
                    }
                    break;

                default:
                    throw new Exception("Invalid exercise number!");
            }

            Console.ReadKey(true);
        }
    }

    #region Interfaces
    public interface IPerson
    {
        string? Name { get; set; }
        int Age { get; set; }
        string? ID { get; set; }
        DateOnly BirthDate { get; set; }

        public string? GetName();
    }

    public interface IRobot
    {
        string? Model { get; set; }
        string? ID { get; set; }
    }

    public interface IPet
    {
        string? Name { get; set; }
        DateOnly BirthDate { get; set; }
    }

    public interface IBuyer
    {
        int Food { get; set; }

        void ByFood();
    }

    public interface IResident
    {
        string? Country { get; set; }

        public string? GetName();
    }
    #endregion

    #region Abstract classes
    public abstract class Person : IPerson, IBuyer
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? ID { get; set; }
        public int Food { get; set; }
        public DateOnly BirthDate { get; set; }

        public abstract void ByFood();
        public abstract string? GetName();
    }

    public abstract class Animal : IPet
    {
        public string? Name { get; set; }
        public DateOnly BirthDate { get; set; }
    }

    public abstract class Machine : IRobot
    {
        public string? Model { get; set; }
        public string? ID { get; set; }
    }
    #endregion

    #region Work classes
    public class Citizen : Person, IResident
    {
        public string? Country { get; set; }

        public override void ByFood()
        {
            Food += 10;
        }

        public override string? GetName()
        {
            return Name;
        }

        string? IResident.GetName()
        {
            return "Mr/Ms/Mrs " + Name;
        }
    }

    public class Rebel : Person
    {
        public string? Group { get; set; }

        public override void ByFood()
        {
            Food += 5;
        }

        public override string? GetName()
        {
            return Name;
        }
    }

    public class Robot : Machine { }

    public class Pet : Animal { }
    #endregion
}