using Exercises_1;

namespace Exercises_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Family familyDemo = new Family();
            familyDemo.AddMembers(new Person("John", 31));
            familyDemo.AddMembers(new Person("Jane", 25));
            familyDemo.AddMembers(new Person("Bob", 35));

            Console.WriteLine("Members of the family:");
            familyDemo.PrintMembers();

            Console.WriteLine();

            Console.WriteLine("The members of the family who are older than 30 in alphabetical order:");
            familyDemo.Statistics();

            Console.WriteLine("-----------------------------");
            Family family = new Family();
            family.AddMembers();

            Console.WriteLine("Members of the family:");
            family.PrintMembers();

            Console.WriteLine();

            Console.WriteLine("The members of the family who are older than 30 in alphabetical order:");
            family.Statistics();

            Console.ReadKey(true);
        }
    }
}
