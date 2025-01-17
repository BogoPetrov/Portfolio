namespace Polymorphism_Exercise
{
    public class Program
    {
        private static void Main(string[] args)
        {
            List<Car> cars =
            [
                new Car("BMW"),
                new Car("Audi"),
                new Car("Mercedes"),
                new CarWithBoost("Ferrari"),
                new CarWithBoost("Lamborghini"),
                new CarWithBoost("Porsche"),
            ];

            string result;
            while (cars.Any(c => c != null) && cars.Count > 1)
            {
                for (int i = 0; i < cars.Count; i ++)
                {
                    try
                    {
                        result = cars[i].Race(cars[i + 1])!;
                        if (result.Contains(cars[i].Name!))
                        {
                            Console.WriteLine(result);
                            Console.WriteLine();
                            cars.RemoveAt(i + 1);
                        }
                        else
                        { 
                            Console.WriteLine(result);
                            Console.WriteLine();
                            cars.RemoveAt(i);
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                } 
            }

            Car winCar = cars.First(c => c != null)!;
            Console.WriteLine($"{winCar.Name} win the whole race!");

            Console.ReadKey(true);
        }
    }

    public class Car
    {
        public string? Name { get; set; }
        public int Speed { get; set; }
        public int Durability { get; set; }
        public int Performance { get; set; }

        protected Random random = new();

        public Car(string? name = null)
        {
            Name = name;
            Speed = random!.Next(100, 200);
            if (Speed > 150)
            {
                Durability += random.Next(10, 50);
            }

            if (Durability < 50)
            {
                Performance -= random.Next(10, 30);
            }
        }

        public virtual string? Race(Car opponent)
        {
            Console.WriteLine($"{Name} (Performance: {Performance}) vs {opponent.Name} (Performance: {opponent.Performance})");
            if (Performance > opponent.Performance)
            {
                return $"{Name} win the race!";
            }
            else
            {
                return $"{opponent.Name} win the race!";
            }
        }
    }

    public class CarWithBoost : Car
    {
        public int NitroBoost { get; set; }

        public CarWithBoost(string? name = null) : base(name)
        {
            NitroBoost = random!.Next(20, 50);
            Performance += NitroBoost;
        }

        public override string? Race(Car opponent)
        {
            Console.WriteLine($"{Name} (Performance + Boost: {Performance}) vs {opponent.Name} (Performance: {opponent.Performance})");
            if (Performance > opponent.Performance)
            {
                return $"{Name} win the race with NitroBoost!";
            }
            else
            {
                return $"{opponent.Name} win the race!";
            }
        }
    }
}