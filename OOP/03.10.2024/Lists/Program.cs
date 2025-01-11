namespace Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Person> people1 = new List<Person>(3);
            List<Person> people2 =
                [
                new Person(),
                new Person("Peter"),
                new Person("Maria"),
                new Person("Ivan", 17)
                ];

            people.Add(new Person());
            people.Add(new Person("Martin"));
            people.Add(new Person("Martin A.", 15));

            Console.WriteLine(people.Capacity + " - " + people1.Capacity + " - " + people2.Capacity);
            Console.WriteLine(people.Count + " - " + people1.Count + " - " + people2.Count);

            people.RemoveAt(0);
            foreach (Person person in people)
            {
                if (person.Name == "Martin")
                {
                    people.Remove(person);
                    break;
                }
            }

            Console.Write("Items of the list: ");
            foreach (Person person in people2)
            {
                Console.Write(person.Name + " ");
            }
            Console.WriteLine();
            Console.Write("Enter the index on which you want to delete object: ");
            byte index = Convert.ToByte(Console.ReadLine());
            people2.RemoveAt(index);

            Console.Write("Items of the list: ");
            foreach (Person person in people2)
            {
                Console.Write(person.Name + " ");
            }
            Console.WriteLine();
            Console.Write("Enter the index on which you want to insert object: ");
            byte indexInsert = Convert.ToByte(Console.ReadLine());
            Console.Write("Enter the name and age of the person who want to insert: ");
            string[] input = Console.ReadLine()!.Split(" ").ToArray();

            people2.Insert(indexInsert, new Person(input[0], Convert.ToByte(input[1])));

            Console.ReadKey(true);
        }
    }
}
