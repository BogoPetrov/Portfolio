namespace Box_Unbox
{
    internal class Program
    {
        static void Main()
        {
            List<object> list = [];
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter {i + 1} number: ");
                if (int.TryParse(Console.ReadLine()!, out int number))
                {
                    list.Add(number);
                }
                else
                {
                    continue;
                }
            }

            foreach (var item in list)
            {
                if (item is int v)
                {
                    if (v % 2 == 0)
                    {
                        Console.WriteLine($"The item {item} is even, so n^2 = {Math.Pow(v, 2)}");
                    }
                    else
                    {
                        Console.WriteLine($"The item {item} is odd, so (n * 3) + 1 = {(v * 3) + 1}");
                    } 
                }
                else
                {
                    Console.WriteLine($"The item {item} is not a number");
                }
            }

            Console.ReadKey(true);
        }
    }
}
