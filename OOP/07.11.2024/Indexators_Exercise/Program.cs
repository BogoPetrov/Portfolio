namespace Indexators_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ParkingMachine> parkingMachines = [];

            parkingMachines.Add(new ParkingMachine());
            parkingMachines.Add(new CarParkingMachine());
            parkingMachines.Add(new BusParkingMachine());

            foreach (ParkingMachine parkingMachine in parkingMachines)
            {
                Console.WriteLine($"Number of vehicle: {parkingMachine[0]}");
                Console.WriteLine($"Time in parking: {parkingMachine[1]}");
                Console.WriteLine($"Price for whole time: {parkingMachine[2]}");
                Console.WriteLine();
            }

            Console.ReadKey(true);
        }
    }
}
