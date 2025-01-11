namespace Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAnimal person = new Person();

            Mammal personOne = new Person();

            Person personTwo = new();
        }
    }

    #region Dinamic polymorphism
    public interface IAnimal { }

    public abstract class Mammal { }

    public class Person : Mammal, IAnimal
    {
        #region Static polymorphism
        public void Eat()
        {
            Console.WriteLine("Person is eating");
        }

        public void Eat(string? foodName)
        {
            Console.WriteLine($"Person is eating {foodName}");
        }
        #endregion
    } 
    #endregion
}
