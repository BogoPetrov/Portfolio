namespace Polymorphism_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new();
            Airplane airplane = new();
            Truck truck = new();
            LawnMower lawnMower = new();

            MachineOperator machineOperator = new(car);

            // Start and stop car
            machineOperator.Start();
            machineOperator.Stop();

            machineOperator.Entity = airplane;

            // Start and stop airplane
            machineOperator.Start();
            machineOperator.Stop();

            machineOperator.Entity = truck;

            // Start and stop truck
            machineOperator.Start();
            machineOperator.Stop();

            machineOperator.Entity = lawnMower;

            // Start and stop lawn mower
            machineOperator.Start();
            machineOperator.Stop();

            Console.ReadKey(true);
        }
    }

    public interface IMachine
    {
        public string? MachineType { get; set; }
        public bool Start();
        public bool Stop();
    }

    public class Car : IMachine
    {
        public string? MachineType { get; set; }
        public bool Start()
        {
            Console.WriteLine("Car starting...");
            return true;
        }
        public bool Stop()
        {
            Console.WriteLine("Car stopping...");
            return true;
        }
    }

    public class Truck : IMachine
    {
        public string? MachineType { get; set; }
        public bool Start()
        {
            Console.WriteLine("Truck starting...");
            return true;
        }
        public bool Stop()
        {
            Console.WriteLine("Truck stopping...");
            return true;
        }
    }

    public class Airplane : IMachine
    {
        public string? MachineType { get; set; }
        public bool Start()
        {
            Console.WriteLine("Airplane starting...");
            return true;
        }
        public bool Stop()
        {
            Console.WriteLine("Airplane stopping...");
            return true;
        }
    }

    public class LawnMower : IMachine
    {
        public string? MachineType { get; set; }
        public bool Start()
        {
            Console.WriteLine("Lawn mower starting...");
            return true;
        }
        public bool Stop()
        {
            Console.WriteLine("Lawn mower stopping...");
            return true;
        }
    }

    public class MachineOperator
    {
        private IMachine? _entity;
        public IMachine? Entity
        {
            get
            {
                return _entity;
            }
            set
            {
                _entity = value;
                Console.WriteLine($"Machine operator is operating: {value!.MachineType}");
            }
        }

        public MachineOperator(IMachine? entity)
        {
            Entity = entity;
        }

        public bool Start()
        {
            return Entity!.Start();
        }

        public bool Stop()
        {
            return Entity!.Stop();
        }
    }
}
