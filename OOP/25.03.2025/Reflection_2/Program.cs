using System.Reflection;

namespace Reflection_2
{
    internal class Program
    {
        public static void Main()
        {
            Type fruitType = Type.GetType("Reflection_2.Fruit")!;
            object? fruitInstance = Activator.CreateInstance(fruitType, ["Apple"]);
            MethodInfo? describeMethod = fruitType.GetMethod("Describe")!;
            describeMethod.Invoke(fruitInstance, null);
            Console.ReadKey(true);
        }
    }

    public class Fruit(string? type)
    {
        public string? Type { get; set; } = type;

        public void Describe()
        {
            Console.WriteLine($"This fruit is a {Type}.");
        }
    }
}
