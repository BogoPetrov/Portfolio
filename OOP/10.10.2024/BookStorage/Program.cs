namespace BookStorage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new();
            Console.Write("Enter how much books you want to add: ");
            int count = Convert.ToInt32(Console.ReadLine());
            if (count <= 0)
            {
                while (count <= 0)
                {
                    Console.Write("Enter valid count: ");
                    count = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine();

            for (int i = 0; i < count; i++)
            {
                storage.AddBook(i);
            }

            Console.Write("Enter how much books you want to buy: ");
            int countForSell = Convert.ToInt32(Console.ReadLine());
            if (countForSell < 0)
            {
                while (countForSell < 0)
                {
                    Console.Write("Enter valid count: ");
                    countForSell = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine();

            for (int i = 0; i < countForSell; i++)
            {
                storage.SellBook(i);
            }

            storage.ShowTheMostSoldBook();
            Console.WriteLine();
            storage.ShowTotalPrice();

            Console.ReadKey(true);
        }
    }
}
