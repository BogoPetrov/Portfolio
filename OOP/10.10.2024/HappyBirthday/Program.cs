namespace HappyBirthday
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HallForBithday hallForBithday = new()
            {
                PriceOfHall = Convert.ToDouble(Console.ReadLine())
            };
            hallForBithday.Print();

            Console.ReadKey(true);
        }
    }
}
