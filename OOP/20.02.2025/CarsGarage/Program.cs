namespace CarsGarage
{
    public class Program
    {
        public static void Main()
        {
            bool flag = true;
            Garage<int> garage = new();

            while (flag)
            {
                Console.WriteLine("--- Cars Garage ---");
                Console.WriteLine("1. Add vehicle");
                Console.WriteLine("2. Remove vehicle");
                Console.WriteLine("3. Find vehicle by model");
                Console.WriteLine("4. Find vehicles by manufacturer");
                Console.WriteLine("5. Update vehicle");
                Console.WriteLine("6. Display vehicles");
                Console.WriteLine("7. Clear text above");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                if (int.TryParse(Console.ReadLine()!, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            {
                                Console.WriteLine();
                                while (true)
                                {
                                    Console.Write("Enter vehicle ID: ");
                                    if (int.TryParse(Console.ReadLine(), out int id))
                                    {
                                        Console.Write("Enter vehicle model: ");
                                        string? model = Console.ReadLine();

                                        Console.Write("Enter vehicle manufacturer: ");
                                        string? manufacturer = Console.ReadLine();

                                        Console.Write("Enter vehicle type: ");
                                        string? type = Console.ReadLine();

                                        Vehicle<int> vehicle = new(id, model, manufacturer, type);
                                        garage.AddVehicle(id, vehicle);
                                        Console.WriteLine();

                                        Console.WriteLine("Vehicle added successfully.");
                                        Console.WriteLine();
                                        break;
                                    }
                                }
                            }
                            break;

                        case 2:
                            {
                                Console.WriteLine();
                                Console.Write("Enter vehicle ID: ");
                                while (true)
                                {
                                    if (int.TryParse(Console.ReadLine()!, out int id))
                                    {
                                        if (garage.RemoveVehicle(id))
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Vehicle removed successfully.");
                                            Console.WriteLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Vehicle not found.");
                                            Console.WriteLine();
                                        }
                                        break;
                                    }
                                }
                            }
                            break;

                        case 3:
                            {
                                Console.WriteLine();
                                Console.Write("Enter vehicle model: ");
                                Vehicle<int> vehicle = garage.FindVehicle(Console.ReadLine()!);
                                if (vehicle != null)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(vehicle.GetInfo());
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Vehicle not found.");
                                    Console.WriteLine();
                                }
                            }
                            break;

                        case 4:
                            {
                                Console.WriteLine();
                                Console.Write("Enter vehicle manufacturer: ");
                                List<Vehicle<int>> vehicles = garage.FindVehiclesByManufacturer(Console.ReadLine()!);
                                if (vehicles.Count != 0)
                                {
                                    Console.WriteLine();
                                    foreach (var vehicle in vehicles)
                                    {
                                        Console.WriteLine(vehicle.GetInfo());
                                    }
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("No vehicles found.");
                                    Console.WriteLine();
                                }
                            }
                            break;

                        case 5:
                            {
                                Console.WriteLine();
                                while (true)
                                {
                                    Console.Write("Enter vehicle ID: ");
                                    if (int.TryParse(Console.ReadLine(), out int id))
                                    {
                                        Console.Write("Enter new vehicle model: ");
                                        string? model = Console.ReadLine();

                                        Console.Write("Enter new vehicle manufacturer: ");
                                        string? manufacturer = Console.ReadLine();

                                        Console.Write("Enter new vehicle type: ");
                                        string? type = Console.ReadLine();

                                        Console.WriteLine();
                                        if (garage.UpdateVehicle(id, model, manufacturer, type))
                                        {
                                            Console.WriteLine($"Vehicle with ID {id} was updated successfully.");
                                            Console.WriteLine(garage.Vehicles![id]!.GetInfo());
                                            Console.WriteLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Vehicle not found.");
                                            Console.WriteLine();
                                        }
                                        break;
                                    }
                                }
                            }
                            break;

                        case 6:
                            {
                                Console.WriteLine();
                                garage.DisplayVehicles();
                                Console.WriteLine();
                            }
                            break;

                        case 7:
                            {
                                Console.Clear();
                            }
                            break;

                        case 8:
                            {
                                flag = false;
                            }
                            break;

                        default:
                            {
                                Console.WriteLine();
                                Console.WriteLine("Invalid option. Please try again.");
                                Console.WriteLine();
                            }
                            break;
                    }
                }
            }

            Console.Clear();
            Console.WriteLine("END OF PROGRAM");
            Console.ReadKey(true);
        }
    }

    public interface IVehicle
    {
        public string? GetInfo();
        public string? GetTypeOfVehicle();
        public string? GetManufacturer();
    }

    public class Vehicle<T>(T? id, string? model, string? manufacturer, string? type) : IVehicle
    {
        public T ID { get; private set; } = id!;
        public string? Model { get; protected set; } = model;
        public string? Manufacturer { get; private set; } = manufacturer;
        public string? Type { get; private set; } = type;

        public string? GetInfo()
        {
            return $"ID: {ID}, Model: {Model}, Manufacturer: {Manufacturer}, Type: {Type}";
        }
        public string? GetTypeOfVehicle()
        {
            return Type;
        }
        public string? GetManufacturer()
        {
            return Manufacturer;
        }

        public void UpdateInfo(string? newModel, string? newManufacturer, string? newType)
        {
            Model = newModel;
            Manufacturer = newManufacturer;
            Type = newType;
        }
    }

    public class Garage<T> where T : notnull
    {
        public Dictionary<T, Vehicle<T>>? Vehicles { get; set; } = [];

        public void AddVehicle(T? id, Vehicle<T> vehicle)
        {
            Vehicles!.Add(id!, vehicle);
        }

        public bool RemoveVehicle(T? id)
        {
            return Vehicles!.Remove(id!);
        }

        public void DisplayVehicles()
        {
            foreach (var vehicle in Vehicles!)
            {
                Console.WriteLine(vehicle.Value.GetInfo());
            }
        }

        public Vehicle<T> FindVehicle(string? model)
        {
            foreach (var vehicle in Vehicles!)
            {
                if (vehicle.Value.Model == model)
                {
                    return vehicle.Value;
                }
            }
            return null!;
        }

        public List<Vehicle<T>> FindVehiclesByManufacturer(string? manufacturer)
        {
            var vehicles = new List<Vehicle<T>>();
            foreach (var vehicle in Vehicles!)
            {
                if (vehicle.Value.Manufacturer == manufacturer)
                {
                    vehicles.Add(vehicle.Value);
                }
            }
            return vehicles;
        }

        public bool UpdateVehicle(T? id, string? newModel, string? newManufacturer, string? newType)
        {
            if (Vehicles!.TryGetValue(id!, out Vehicle<T>? vehicle))
            {
                vehicle.UpdateInfo(newModel, newManufacturer, newType);
                return true;
            }
            return false;
        }
    }
}