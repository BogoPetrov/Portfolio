namespace Farm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Farm farm = new();
            Console.WriteLine("Welcome to the farm! One day in this farm is equal to one year for the animals.");
            
            Console.Write("Enter the number of animals: ");
            int numberOfAnimals = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            for (int i = 0; i < numberOfAnimals; i++)
            {
                farm.AddAnimal();
            }
            Console.WriteLine();

            farm.FeedAnimals();
            Console.WriteLine();

            farm.PerformActions();
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                farm.CalculateProducts();
                Console.WriteLine(); 
            }

            farm.RemoveOldAnimals();

            Console.ReadKey(true);
        }
    }

    public abstract class Animal(string? breed, short age, short energy)
    {
        // Fields
        protected string? _breed = breed;
        protected short _age = age;
        protected short _energy = energy;

        // Properties
        public string? Breed { get => _breed; set => _breed = value; }
        public short Age { get => _age; set => _age = value; }
        public short Energy { get => _energy; set => _energy = value; }

        public bool IsMature
        {
            get => _age >= 3;
        }

        public bool IsElderly
        {
            get => _age >= 10;
        }

        // Abstract methods
        public abstract double CalulateProductPerDay();
        public abstract void PreformAction();

        // Methods
        public void Feed()
        {
            Console.WriteLine($"{Breed} is happily eating!");
            Energy += 10;
        }
    }

    public class Sheep(string? breed, short age, short energy) : Animal(breed, age, energy)
    {
        private short _woolAmount = 150;

        public short WoolAmount { get => _woolAmount;}

        public override double CalulateProductPerDay()
        {
            if (IsMature && !IsElderly)
            {
                double wollAmountForDay = 0.0625 * _woolAmount;
                _woolAmount -= (short)wollAmountForDay;
                _age++;
                return Math.Round(wollAmountForDay, 2);
            }
            else
            {
                _woolAmount += 10;
                _age++;
                return 0.0;
            }
        }

        public override void PreformAction()
        {
            Console.WriteLine("Beee....");
            Energy -= 15;
        }
    }

    public class Cow(string? breed, short age, short energy) : Animal(breed, age, energy)
    {
        private short _milkAmount = 250;

        public short MilkAmount { get => _milkAmount;}

        public override double CalulateProductPerDay()
        {
            if (IsMature && !IsElderly)
            {
                double milkAmountForDay = 0.03125 * _milkAmount;
                _milkAmount -= (short)milkAmountForDay;
                _age++;
                return Math.Round(milkAmountForDay, 2);
            }
            else
            {
                _milkAmount += 10;
                _age++;
                return 0.0;
            }
        }

        public override void PreformAction()
        {
            Console.WriteLine("Mooo....");
        }
    }

    public class Farm
    {
        public List<Animal> Animals = [];

        public void AddAnimal()
        {
            string[] animalInfo = new string[4];

            Console.Write("Enter type of the animal: ");
            animalInfo[0] = Console.ReadLine()!;

            Console.Write("Enter the breed of the animal: ");
            animalInfo[1] = Console.ReadLine()!;

            Console.Write("Enter age of the animal: ");
            animalInfo[2] = Console.ReadLine()!;

            Console.Write("Enter energy of the animal: ");
            animalInfo[3] = Console.ReadLine()!;

            Animal? animal = animalInfo[0] switch
            {
                "Sheep" => new Sheep(animalInfo[1], short.Parse(animalInfo[2]), short.Parse(animalInfo[3])),
                "Cow" => new Cow(animalInfo[1], short.Parse(animalInfo[2]), short.Parse(animalInfo[3])),
                _ => null
            };

            if (animal != null)
            {
                Animals.Add(animal); 
                if (animal.GetType() == typeof(Sheep))
                {
                    Console.WriteLine($"Animal with type Sheep and breed {animal.Breed} was added successfully!"); 
                }
                else if (animal.GetType() == typeof(Cow))
                {
                    Console.WriteLine($"Animal with type Cow and breed {animal.Breed} was added successfully!"); 
                }
                Console.WriteLine();
            }
            else
            {
                throw new FormatException("Invalid input!");
            }
        }

        public void FeedAnimals()
        {
            foreach (Animal animal in Animals)
            {
                animal.Feed();
            }
        }

        public void PerformActions()
        {
            foreach (Animal animal in Animals)
            {
                animal.PreformAction();
            }
        }

        public void CalculateProducts()
        {
            foreach (Animal animal in Animals)
            {
                Console.WriteLine($"{animal.Breed} produced {animal.CalulateProductPerDay()} products per day.");
            }
        }

        public void RemoveOldAnimals()
        {
            for(int i = 0; i < Animals.Count; i++)
            {
                if (Animals[i].IsElderly)
                {
                    if (Animals[i].GetType() == typeof(Sheep))
                    {
                        Console.WriteLine($"Animal with type Sheep and breed {Animals[i].Breed} was removed because it is too old.");
                    }
                    else if (Animals[i].GetType() == typeof(Cow))
                    {
                        Console.WriteLine($"Animal with type Cow and breed {Animals[i].Breed} was removed because it is too old.");
                    }
                    Animals.Remove(Animals[i]);
                }
            }
        }
    }
}
