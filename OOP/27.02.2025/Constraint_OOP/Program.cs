namespace Constraint_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            The_Matrix_Hero<Hacker> hacker = new(new Hacker("1"));
            The_Matrix_Hero<Agent> agent = new(new Agent("2"));
            The_Matrix_Hero<TheOne> theOne = new(new TheOne("3"));
            Console.ReadKey(true);
        }
    }

    public class Matrix(string? name)
    {
        public string? _name = name;

        public virtual void Show()
        {
            Console.WriteLine($"Name: {_name}");
        }
    }

    public class Hacker(string? name) : Matrix(name) { }
    public class Agent(string? name) : Matrix(name) { }
    public class TheOne(string? name) : Matrix(name) { }

    public class The_Matrix_Hero<T> where T : Matrix
    {
        public Matrix? obj;

        public The_Matrix_Hero(T t)
        {
            obj = t;
            obj.Show();
        }
    }
}
