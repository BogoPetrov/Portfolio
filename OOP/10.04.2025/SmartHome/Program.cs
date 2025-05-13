using System.Collections;
using System.Reflection;

namespace SmartHome
{
    internal class Program
    {
        static void Main()
        {
            // Create and configure a SmartLight device
            SmartLight light = new() { Name = "Living Room Light", EnergyConsumption = 10, Brightness = 75, LightColor = "Warm White" };

            // Create and configure a SmartThermostat device
            SmartThermostat thermostat = new() { Name = "Bedroom Thermostat", EnergyConsumption = 5, CurrentTemperature = 18, TargetTemperature = 24 };

            // Initialize the SmartHome and add devices to it
            SmartHome smartHome = new();
            smartHome.AddDevice(light);
            smartHome.AddDevice(thermostat);

            // Display all devices in the SmartHome with enumeration
            Console.WriteLine("Devices in SmartHome:");
            IEnumerator<SmartDevice> enumerator = smartHome.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine($" - {enumerator.Current.Name} ({enumerator.Current.GetType().Name})");
            }

            // Display devices sorted by energy consumption
            Console.WriteLine("\nDevices sorted by Energy Consumption:");
            var sortedByEnergy = smartHome.OrderBy(d => d, new EnergyConsumptionComparer());
            foreach (var device in sortedByEnergy)
            {
                Console.WriteLine($" - {device.Name}: {device.EnergyConsumption}W");
            }

            // Display devices sorted by name
            Console.WriteLine("\nDevices sorted by Name:");
            var sortedByName = smartHome.OrderBy(device => device, new NameComparer());
            foreach (var device in sortedByName)
            {
                Console.WriteLine($" - {device.Name}");
            }

            // Use reflection to display detailed information about each device
            Console.WriteLine("\nDevices Information (Reflection):");
            Console.WriteLine("----------------------------------");
            smartHome.DisplayDevicesInfo();

            Console.ReadKey(true);
        }
    }

    // Abstract base class representing a generic smart device
    public abstract class SmartDevice
    {
        public string? Name { get; set; } // Name of the device
        public double EnergyConsumption { get; set; } // Energy consumption in watts

        // Abstract methods to be implemented by derived classes
        public abstract void TurnOn();
        public abstract void TurnOff();
    }

    // Represents a smart light with additional properties for brightness and color
    public class SmartLight : SmartDevice
    {
        public int Brightness { get; set; }
        public string? LightColor { get; set; }

        public override void TurnOn()
        {
            Console.WriteLine($"{Name} is now ON.");
        }

        public override void TurnOff()
        {
            Console.WriteLine($"{Name} is now OFF.");
        }
    }

    // Represents a smart thermostat with temperature control properties
    public class SmartThermostat : SmartDevice
    {
        public double CurrentTemperature { get; set; }
        public double TargetTemperature { get; set; }

        public override void TurnOn()
        {
            Console.WriteLine($"{Name} is now ON.");
        }

        public override void TurnOff()
        {
            Console.WriteLine($"{Name} is now OFF.");
        }
    }

    // Represents a collection of smart devices
    public class SmartHome : IEnumerable<SmartDevice>
    {
        private readonly List<SmartDevice> _devices = [];

        // Adds a new device to the SmartHome
        public void AddDevice(SmartDevice device)
        {
            _devices.Add(device);
        }

        // Returns an enumerator for iterating over the devices
        public IEnumerator<SmartDevice> GetEnumerator()
        {
            return _devices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Displays detailed information about each device using reflection
        public void DisplayDevicesInfo()
        {
            foreach (var device in _devices)
            {
                Console.WriteLine($"Device Type: {device.GetType().Name}");
                Console.WriteLine("Properties:");
                foreach (var prop in device.GetType().GetProperties())
                {
                    Console.WriteLine($" - {prop.Name} ({prop.PropertyType.Name})");
                }
                Console.WriteLine("Methods:");
                foreach (var method in device.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    Console.WriteLine($" - {method.Name}");
                }
                Console.WriteLine();
            }
        }
    }

    // Comparer for sorting devices by energy consumption
    public class EnergyConsumptionComparer : IComparer<SmartDevice>
    {
        public int Compare(SmartDevice? x, SmartDevice? y)
        {
            return x!.EnergyConsumption.CompareTo(y!.EnergyConsumption);
        }
    }

    // Comparer for sorting devices by name
    public class NameComparer : IComparer<SmartDevice>
    {
        public int Compare(SmartDevice? x, SmartDevice? y)
        {
            return string.Compare(x!.Name, y!.Name, StringComparison.Ordinal);
        }
    }
}