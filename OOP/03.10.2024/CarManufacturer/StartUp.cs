namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new()
            {
                Make = "VW",
                Model = "MK3",
                Year = 1992,
                FuelQuantity = 200f,

            };
            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
            Console.ReadKey(true);

            Console.Write("Enter number of part you want to do (1 to 3): ");
            int part = int.Parse(Console.ReadLine()!);

            if (part == 1)
            {
                Console.Clear();

                string mark = Console.ReadLine()!;
                string model = Console.ReadLine()!;
                int year = int.Parse(Console.ReadLine()!);
                double fuelQuantity = double.Parse(Console.ReadLine()!);
                double fuelConsumption = double.Parse(Console.ReadLine()!);

                Console.WriteLine();

                Car firstCar = new();
                Car secondCar = new(mark, model, year);
                Car thirdCar = new(mark, model, year, fuelQuantity, fuelConsumption);

                Console.WriteLine(firstCar.WhoAmI());
                Console.WriteLine();
                Console.WriteLine(secondCar.WhoAmI());
                Console.WriteLine();
                Console.WriteLine(thirdCar.WhoAmI());
            }
            if (part == 2)
            {
                Console.Clear();

                Tire[] tires =
                [
                    new(1, 2.5),
                    new(1, 2.1),
                    new(2, 0.5),
                    new(2, 2.3),
                ];

                Engine engine = new(560, 6300);

                Car fourthCar = new("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

                Console.WriteLine(fourthCar.WhoAmI());
            }
            if (part == 3)
            {
                Console.Clear();
                SpecialCars();
            }

            Console.ReadKey(true);
        }

        public static void SpecialCars()
        {
            List<Tire[]> tires = new([]);
            List<Engine> engines = [];
            List<Car> cars = [];
            string input;
            string[] tiresInput;
            string[] enginesInput;
            string[] carInput;

            while (true)
            {
                input = Console.ReadLine()!;
                tiresInput = [.. input.Split(" ")];
                if (tiresInput.Length == 8)
                {
                    tires.Add(
                        [
                            new(int.Parse(tiresInput[0]), double.Parse(tiresInput[1])),
                            new(int.Parse(tiresInput[2]), double.Parse(tiresInput[3])),
                            new(int.Parse(tiresInput[4]), double.Parse(tiresInput[5])),
                            new(int.Parse(tiresInput[6]), double.Parse(tiresInput[7]))
                        ]);
                }
                else if (input.Equals("No more tires", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again!");
                }
            }

            while (true)
            {
                input = Console.ReadLine()!;
                enginesInput = [.. input.Split(" ")];
                if (enginesInput.Length == 2 && !input.Equals("Engines done", StringComparison.OrdinalIgnoreCase))
                {
                    engines.Add(new(int.Parse(enginesInput[0]), double.Parse(enginesInput[1])));
                }
                else if (input.Equals("Engines done", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again!");
                }
            }

            while (true)
            {
                input = Console.ReadLine()!;
                carInput = [.. input.Split(" ")];
                if (carInput.Length == 7)
                {
                    cars.Add(new(carInput[0], carInput[1], int.Parse(carInput[2]), double.Parse(carInput[3]), double.Parse(carInput[4]), engines[int.Parse(carInput[5])], tires[int.Parse(carInput[6])]));
                }
                else if (input.Equals("Show special", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again!");
                }
            }

            foreach (Car car in cars)
            {
                double carTiresPressure = car.Tires![0].Pressure + car.Tires![1].Pressure + car.Tires![2].Pressure + car.Tires![3].Pressure;
                if (car.Engine!.HorsePower > 330 && car.Year >= 2017 && carTiresPressure >= 9 && carTiresPressure <= 10)
                {
                    Console.WriteLine();
                    car.Drive(20);
                    Console.WriteLine();
                    Console.WriteLine($"Make: {car.Make} " +
                        $"\nModel: {car.Model}" +
                        $"\nYear: {car.Year}" +
                        $"\nHorsePowers: {car.Engine.HorsePower}" +
                        $"\nFuelQuantity: {car.FuelQuantity}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("No more special cars!");
        }
    }
}