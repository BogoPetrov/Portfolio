namespace Comparator_Demo
{
    internal class Program
    {
        public static void Main()
        {
            List<Person> people = [
                new("Petar", 30),
                new("Ivan", 25),
                new("Mariq", 20)
            ];

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine();
            people.Sort();
            Console.WriteLine("Sorted people by age:");
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }

            people.Sort(new NameComparer());
            Console.WriteLine();
            Console.WriteLine("Sorted people by name:");
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
            Console.ReadKey(true);
        }
    }

    public class Person(string name, int age) : IComparable<Person>
    {
        public string? Name { get; set; } = name;
        public int Age { get; set; } = age;

        public int CompareTo(Person? other)
        {
            if (other == null)
            {
                return 1;
            }
            return Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }

    public class NameComparer : IComparer<Person>
    {
        public int Compare(Person? x, Person? y)
        {
            return x?.Name!.CompareTo(y?.Name!) ?? 0;
        }
    }
}
