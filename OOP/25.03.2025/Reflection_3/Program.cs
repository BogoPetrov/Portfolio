using System.Reflection;

namespace Reflection_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicalInstrument instrument = new()
            {
                Name = "Guitar",
                Brand = "Fender",
                Price = 1200.50
            };

            Type instrumentType = instrument.GetType();
            PropertyInfo[] properties = instrumentType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                object? value = property.GetValue(instrument);
                Console.WriteLine($"{property.Name}: {value}");
            }

            PropertyInfo nameProperty = instrumentType.GetProperty("Name", BindingFlags.Public | BindingFlags.Instance)!;
            nameProperty.SetValue(instrument, "Electric Guitar");
            Console.WriteLine($"New value for Name: {instrument.Name}");
            Console.ReadKey(true);
        }
    }

    public class MusicalInstrument
    {
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public double Price { get; set; }
    }
}
