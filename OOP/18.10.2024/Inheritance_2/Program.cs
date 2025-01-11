namespace Inheritance_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new();
            person.Input();
            Console.WriteLine();
            person.Print();

            Console.WriteLine();

            Student student = new(["5", "6", "4"], ["Math", "English", "Physics"]);
            student.Input();
            Console.WriteLine();
            student.Print();

            Console.WriteLine();

            Employee employe = new();
            employe.Input();
            Console.WriteLine();
            employe.Print();

            Console.WriteLine();

            Staff staff = new();
            staff.Input();
            Console.WriteLine();
            staff.Print();

            Console.ReadKey(true);
        }
    }
}
