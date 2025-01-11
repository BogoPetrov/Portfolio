namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new();
            Dog dog = new();
            Puppy puppy = new();
            Cat cat = new();

            Console.Write("The animal is: ");
            animal.Eat();

            Console.WriteLine();

            Console.Write("First the dog is: ");
            dog.Bark();
            Console.Write("and then dog is: ");
            dog.Eat();

            Console.WriteLine();

            Console.Write("First the puppy is: ");
            puppy.Bark();
            Console.Write("Then puppy is: ");
            puppy.Eat();
            Console.Write("And finally the puppy is: ");
            puppy.Weep();

            Console.WriteLine();

            Console.Write("First the cat is: ");
            cat.Meow();
            Console.Write("and then cat is: ");
            cat.Eat();

            Console.ReadKey(true);
        }
    }
}
