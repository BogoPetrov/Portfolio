namespace Animal_Kingdom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = new Cat();

            Trainer trainerOfCats = new(animal);
            Console.WriteLine("Trainer of cats:");
            trainerOfCats.Make();

            animal = new Dog();
            Trainer trainerOfDogs = new(animal);
            Console.WriteLine("Trainer of dogs:");
            trainerOfDogs.Make();

            Console.ReadKey(true);
        }
    }

    public interface IMakeNoise
    {
        public string? MakeNoise();
    }

    public interface IMakeTrick
    {
        public string? MakeTrick();
    }

    public interface IAnimal : IMakeNoise, IMakeTrick
    {
        public void Preform();
    }

    public class Cat : IAnimal
    {
        public string? MakeNoise() => "Meow";
        public string? MakeTrick() => "No trick for you! I'm too lazy!”";

        public void Preform()
        {
            Console.WriteLine(MakeNoise());
            Console.WriteLine(MakeTrick());
        }
    }

    public class Dog : IAnimal
    {
        public string? MakeNoise() => "Woof";
        public string? MakeTrick() => "Hold my paw, human!";

        public void Preform()
        {
            Console.WriteLine(MakeNoise());
            Console.WriteLine(MakeTrick());
        }
    }

    public class Trainer
    {
        public IAnimal? _entity;

        public Trainer(IAnimal animal)
        {
            _entity = animal;
        }

        public void Make()
        {
            _entity?.Preform();
        }
    }
}
