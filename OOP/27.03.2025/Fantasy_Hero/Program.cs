using System;
using System.Reflection;
using System.Xml.Linq;

namespace Fantasy_Hero
{
    public class Program
    {
        private static FantasyCharacter _selectedCharacter = new();
        static void Main()
        {
            List<FantasyCharacter> characters = [];
            bool isRunning = true;
            while (isRunning)
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
                if (int.TryParse(Console.ReadLine(), out int switch_on))
                {
                    Console.Clear();
                    switch (switch_on)
                    {
                        case 1:
                            {
                                Console.Write("Enter name: ");
                                string? name = Console.ReadLine();

                                Console.Write("Enter race: ");
                                string? race = Console.ReadLine();

                                Console.Write("Enter class: ");
                                string? heroClass = Console.ReadLine();

                                Console.Write("Enter level: ");
                                int level = int.Parse(Console.ReadLine()!);

                                Console.Write("Enter health: ");
                                double health = double.Parse(Console.ReadLine()!);

                                FantasyCharacter character = new(name!, race!, heroClass!, level, health);
                                characters.Add(character);

                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey(true);
                                Console.Clear();
                            }
                            break;

                        case 2:
                            {
                                int index = 1;
                                characters.ForEach(character => Console.WriteLine($"{index++}. {character.Name}"));
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey(true);
                                Console.Clear();
                            }
                            break;

                        case 3:
                            {
                                Console.Write("Enter name of the character: ");
                                string? name = Console.ReadLine();
                                try
                                {
                                    characters.Remove(characters.FirstOrDefault(character => character.Name!.Equals(name, StringComparison.OrdinalIgnoreCase))!);
                                    Console.WriteLine($"Character with {name} was deleted successfully.");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("ERROR: Character not found.");
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                }
                            }
                            break;

                        case 4:
                            {

                                Console.Write("Enter name of the character: ");
                                string? name = Console.ReadLine();
                                {
                                    _selectedCharacter = characters.FirstOrDefault(character => character.Name!.Equals(name, StringComparison.OrdinalIgnoreCase))!;
                                    if (_selectedCharacter != null)
                                    {
                                        Console.Clear();
                                        HeroActions();
                                        characters[characters.IndexOf(characters.FirstOrDefault(character => character.Name!.Equals(name, StringComparison.OrdinalIgnoreCase))!)] = _selectedCharacter;
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERROR: Character not found.");
                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey(true);
                                        Console.Clear();
                                    }
                                }
                            }
                            break;

                        case 5:
                            {
                                Console.Clear();
                            }
                            break;

                        case 6:
                            {
                                isRunning = false;
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid input");
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                    }
                }
            }

            Console.WriteLine("Goodbye!");
            Console.ReadKey(true);
        }

        public static void HeroActions()
        {
            bool isSelected = true;
            while (isSelected)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("--- SELECTED HERO ---");
                Console.WriteLine("---------------------\n");
                ShowAllPropeties();
                Console.WriteLine("---------------------\n");

                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Change property value");
                Console.WriteLine("2. Invoke method");
                Console.WriteLine("3. Show the secret ability of the hero");
                Console.WriteLine("4. Clear console");
                Console.WriteLine("5. Return to main menu\n");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                ChangePropertyValue();
                            }
                            break;

                        case 2:
                            {
                                InvokeMethod();
                            }
                            break;

                        case 3:
                            {
                                ShowSecretAbility();
                            }
                            break;

                        case 4:
                            {
                                Console.Clear();
                            }
                            break;

                        case 5:
                            {
                                isSelected = false;
                            }
                            break;

                        default:
                            {
                                Console.WriteLine("Invalid choice!");
                                Console.WriteLine("\nPress any key to continue...");
                                Console.ReadKey(true);
                                Console.Clear();
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }

        public static void ShowAllPropeties()
        {
            List<PropertyInfo> properties = [.. _selectedCharacter.GetType().GetProperties()];

            Console.WriteLine("Properties:");
            properties.ForEach(property =>
            {
                object value = property.GetValue(_selectedCharacter)!;
                Console.WriteLine($"- {property.Name}: {value}");
            });
        }

        public static void ChangePropertyValue()
        {
            Console.WriteLine("Available properties:");
            PropertyInfo[] properties = _selectedCharacter.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].DeclaringType!.Equals(typeof(FantasyCharacter)))
                {
                    Console.WriteLine($"{i + 1}. {properties[i].Name}");
                }
            }

            Console.Write($"\nSelect a property to change form 1 to {properties.Length}: ");
            if (int.TryParse(Console.ReadLine(), out int switch_property))
            {
                string? propertyName = switch_property switch
                {
                    1 => "Name",
                    2 => "Race",
                    3 => "Class",
                    4 => "Level",
                    5 => "Health",
                    _ => null
                };

                Console.Clear();
                PropertyInfo property = _selectedCharacter.GetType()!.GetProperty(propertyName!)!;

                if (property != null)
                {
                    Console.Write($"Enter new value for {propertyName}: ");
                    string? newValue = Console.ReadLine()!;

                    try
                    {
                        object? convertedValue = Convert.ChangeType(newValue, property.PropertyType);
                        property.SetValue(_selectedCharacter, convertedValue);
                        Console.WriteLine($"Successfully changed the value of {propertyName} to {convertedValue}.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    catch
                    {
                        Console.WriteLine("ERROR: Invalid value format for selected property.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Property not found.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }

        public static void InvokeMethod()
        {
            Console.WriteLine("Available methods:");
            MethodInfo[] methods = _selectedCharacter.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < methods.Length; i++)
            {
                if (methods[i].DeclaringType!.Equals(typeof(FantasyCharacter)))
                {
                    Console.WriteLine($"{i + 1}. {methods[i].Name}");
                }
            }


            Console.Write($"\nSelect a method to invoke form 1 to {methods.Length - 4}: ");
            if (int.TryParse(Console.ReadLine(), out int switch_property))
            {
                string? methodName = switch_property switch
                {
                    1 => "get_Name",
                    2 => "set_Name",
                    3 => "get_Race",
                    4 => "set_Race",
                    5 => "get_Class",
                    6 => "set_Class",
                    7 => "get_Level",
                    8 => "set_Level",
                    9 => "get_Health",
                    10 => "set_Health",
                    11 => "Attack",
                    12 => "Heal",
                    _ => null
                };

                Console.Clear();
                MethodInfo methodInfo = _selectedCharacter.GetType().GetMethod(methodName!)!;
                if (methodInfo != null)
                {
                    if (methodInfo.Name.Contains("get_") || methodInfo.Name.Contains("Attack"))
                    {
                        Console.WriteLine(methodInfo.Invoke(_selectedCharacter, null));
                    }
                    else if (methodInfo.Name.Contains("set_"))
                    {
                        Console.Write($"Enter new value for {methodName}: ");
                        string? newValue = Console.ReadLine()!;
                        object? convertedValue = Convert.ChangeType(newValue, methodInfo.GetParameters()[0].ParameterType);
                        methodInfo.Invoke(_selectedCharacter, [convertedValue]);
                        Console.WriteLine($"Successfully executed {methodName}");
                    }

                    if (methodInfo.Name == "Heal")
                    {
                        Console.Write($"Enter new value for {methodName}: ");
                        string? newValue = Console.ReadLine()!;
                        object? convertedValue = Convert.ChangeType(newValue, methodInfo.GetParameters()[0].ParameterType);
                        methodInfo.Invoke(_selectedCharacter, [convertedValue]);
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("ERROR: Specified method does not exist.");
                }
            }
        }

        public static void ShowSecretAbility()
        {
            FieldInfo secretField = _selectedCharacter.GetType()!.GetField("_secretAbility", BindingFlags.NonPublic | BindingFlags.Instance)!;
            if (secretField != null)
            {
                string ability = (string)secretField.GetValue(_selectedCharacter)!;
                Console.WriteLine($"The secret ability is: {ability}");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("ERROR: The hero does not have a secret ability.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            }
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
            Console.WriteLine($"{Name} attacks with powerful hit!");
        }

        public void Heal(int amount = 20)
        {
            Health += amount;
            Console.WriteLine($"{Name} is healing with +{amount}. New health: {Health}");
        }
    }
}