using System.Reflection;

namespace Reflection_1
{
    internal class Program
    {
        public static void Main()
        {
            // Get the Type object corresponding to the Animal class
            Type animalType = typeof(Animal);

            // Retrieve all methods (public and non-public) of the Animal class
            MethodInfo[] methods = animalType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            // Print the names and visibility of the methods
            Console.WriteLine("Methods of class Animal:");
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine($"{method.Name} - IsPublic: {method.IsPublic}");
            }

            // Wait for a key press before closing the console window
            Console.ReadKey(true);
        }
    }

    public class Animal(string? name, int age)
    {

        // Property to get or set the name of the animal
        public string? Name { get; set; } = name;

        // Property to get or set the age of the animal
        public int Age { get; set; } = age;

        // Method for the animal to speak
        public void Speak()
        {
            Console.WriteLine($"{Name} makes a sound.");
        }

        // Method for the animal to sleep
        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping.");
        }
    }
}

