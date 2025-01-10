using OnTime.Controller;
using OnTime.View;
namespace OnTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeController timeController = new TimeController();
            Console.ReadKey(true);
        }
    }
}
