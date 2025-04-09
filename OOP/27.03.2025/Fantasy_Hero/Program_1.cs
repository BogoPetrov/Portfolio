using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fantasy_Hero_1
{
    public class Program
    {
        private static FantasyCharacter? _selectedCharacter;
        private static readonly List<FantasyCharacter> Characters = new();

        static void Main()
        {
            bool isRunning = true;

            while (isRunning)
            {
                DisplayMainMenu();

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.Clear();
                    switch (choice)
                    {
                        case 1: CreateCharacter(); break;
                        case 2: ListCharacters(); break;
                        case 3: DeleteCharacter(); break;
                        case 4: SelectCharacter(); break;
                        case 5: Console.Clear(); break;
                        case 6: isRunning = false; break;
                        default: ShowInvalidInputMessage(); break;
                    }
                }
                else
                {
                    ShowInvalidInputMessage();
                }
            }

            Console.WriteLine("Goodbye!");
        }

        private static void DisplayMainMenu()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("--- FANTASY HEROES ---");
            Console.WriteLine("----------------------");
            Console.WriteLine("1. Create character");
            Console.WriteLine("2. List characters");
            Console.WriteLine("3. Delete character");
            Console.WriteLine("4. Select character");
            Console.WriteLine("5. Clear console");
            Console.WriteLine("6. Exit\n");
        }

        private static void CreateCharacter()
        {
            Console.Write("Enter name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter race: ");
            string? race = Console.ReadLine();

            Console.Write("Enter class: ");
            string? heroClass = Console.ReadLine();

            Console.Write("Enter level: ");
            if (!int.TryParse(Console.ReadLine(), out int level))
            {
                Console.WriteLine("Invalid level. Returning to main menu.");
                return;
            }

            Console.Write("Enter health: ");
            if (!double.TryParse(Console.ReadLine(), out double health))
            {
                Console.WriteLine("Invalid health. Returning to main menu.");
                return;
            }

            Characters.Add(new FantasyCharacter(name!, race!, heroClass!, level, health));
            Console.WriteLine("Character created successfully!\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void ListCharacters()
        {
            if (!Characters.Any())
            {
                Console.WriteLine("No characters available.");
            }
            else
            {
                int index = 1;
                Console.WriteLine("Characters:");
                Characters.ForEach(character => Console.WriteLine($"{index++}. {character.Name}"));
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void DeleteCharacter()
        {
            Console.Write("Enter name of the character to delete: ");
            string? name = Console.ReadLine();

            var character = Characters.FirstOrDefault(c => c.Name!.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (character != null)
            {
                Characters.Remove(character);
                Console.WriteLine($"Character '{name}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Character '{name}' not found.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void SelectCharacter()
        {
            Console.Write("Enter name of the character to select: ");
            string? name = Console.ReadLine();

            _selectedCharacter = Characters.FirstOrDefault(c => c.Name!.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (_selectedCharacter != null)
            {
                Console.Clear();
                HeroActions();
            }
            else
            {
                Console.WriteLine($"Character '{name}' not found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        private static void HeroActions()
        {
            bool isSelected = true;

            while (isSelected)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("--- SELECTED HERO ---");
                Console.WriteLine("---------------------\n");
                ShowAllProperties();
                Console.WriteLine("---------------------\n");

                Console.WriteLine("1. Change property value");
                Console.WriteLine("2. Invoke method");
                Console.WriteLine("3. Show the secret ability of the hero");
                Console.WriteLine("4. Clear console");
                Console.WriteLine("5. Return to main menu\n");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.Clear();
                    switch (choice)
                    {
                        case 1: ChangePropertyValue(); break;
                        case 2: InvokeMethod(); break;
                        case 3: ShowSecretAbility(); break;
                        case 4: Console.Clear(); break;
                        case 5: isSelected = false; break;
                        default: ShowInvalidInputMessage(); break;
                    }
                }
                else
                {
                    ShowInvalidInputMessage();
                }
            }
        }

        private static void ShowAllProperties()
        {
            Console.WriteLine("Properties:");
            foreach (var property in _selectedCharacter!.GetType().GetProperties())
            {
                Console.WriteLine($"- {property.Name}: {property.GetValue(_selectedCharacter)}");
            }
        }

        private static void ChangePropertyValue()
        {
            Console.WriteLine("Available properties:");
            var properties = _selectedCharacter!.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {properties[i].Name}");
            }

            Console.Write("\nSelect a property to change: ");
            if (int.TryParse(Console.ReadLine(), out int propertyIndex) && propertyIndex > 0 && propertyIndex <= properties.Length)
            {
                var property = properties[propertyIndex - 1];
                Console.Write($"Enter new value for {property.Name}: ");
                string? newValue = Console.ReadLine();

                try
                {
                    var convertedValue = Convert.ChangeType(newValue, property.PropertyType);
                    property.SetValue(_selectedCharacter, convertedValue);
                    Console.WriteLine($"Successfully updated {property.Name}.");
                }
                catch
                {
                    Console.WriteLine("Invalid value format.");
                }
            }
            else
            {
                Console.WriteLine("Invalid property selection.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void InvokeMethod()
        {
            Console.WriteLine("Available methods:");
            var methods = _selectedCharacter!.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.DeclaringType == typeof(FantasyCharacter) && !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_"))
                .ToList();

            for (int i = 0; i < methods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {methods[i].Name}");
            }

            Console.Write("\nSelect a method to invoke: ");
            if (int.TryParse(Console.ReadLine(), out int methodIndex) && methodIndex > 0 && methodIndex <= methods.Count)
            {
                var method = methods[methodIndex - 1];
                var parameters = method.GetParameters();

                object?[] args = parameters.Select(p =>
                {
                    Console.Write($"Enter value for {p.Name} ({p.ParameterType.Name}): ");
                    return Convert.ChangeType(Console.ReadLine(), p.ParameterType);
                }).ToArray();

                method.Invoke(_selectedCharacter, args);
            }
            else
            {
                Console.WriteLine("Invalid method selection.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void ShowSecretAbility()
        {
            var secretField = _selectedCharacter!.GetType().GetField("_secretAbility", BindingFlags.NonPublic | BindingFlags.Instance);
            if (secretField != null)
            {
                Console.WriteLine($"The secret ability is: {secretField.GetValue(_selectedCharacter)}");
            }
            else
            {
                Console.WriteLine("No secret ability found.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void ShowInvalidInputMessage()
        {
            Console.WriteLine("Invalid input. Please try again.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }

    public class FantasyCharacter
    {
        public string? Name { get; set; }
        public string? Race { get; set; }
        public string? Class { get; set; }
        public int Level { get; set; }
        public double Health { get; set; }

        private readonly string _secretAbility = "Invisibility";

        public FantasyCharacter() { }

        public FantasyCharacter(string name, string race, string characterClass, int level, double health)
        {
            Name = name;
            Race = race;
            Class = characterClass;
            Level = level;
            Health = health;
        }

        public void Attack()
        {
            Console.WriteLine($"{Name} attacks with a powerful hit!");
        }

        public void Heal(int amount = 20)
        {
            Health += amount;
            Console.WriteLine($"{Name} heals for {amount}. New health: {Health}");
        }
    }
}