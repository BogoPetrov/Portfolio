namespace Animal_Kingdom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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
        public void Preform()
        {
            MakeNoise();
            MakeTrick();
        }
    }

    public class Cat : IAnimal
    {
        public string? MakeNoise() => "Meow";
        public string? MakeTrick() => "Jump";

        public void Preform()
        {
            MakeNoise();
            MakeTrick();
        }
    }

    public class Dog : IAnimal
    {
        public string? MakeNoise() => "Woof";
        public string? MakeTrick() => "Fetch";

        public void Preform()
        {
            MakeNoise();
            MakeTrick();
        }
    }
}
