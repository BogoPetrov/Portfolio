namespace TouristShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tourist tourist = new() 
            {
                Balance = Convert.ToDouble(Console.ReadLine()),
            };

            tourist.Shopping();

            Console.ReadKey(true);
        }
    }
}
