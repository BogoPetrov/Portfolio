namespace ForegroundBackgroundThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            int[] numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 100);
            }


            Thread foregroundThread = new(() =>
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        Console.WriteLine(numbers[i]);
                        Thread.Sleep(1000);
                    }
                });

            Thread backgroundThread = new(() =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    Thread.Sleep(1000);
                    if (numbers[i] % 2 == 0)
                    {
                        Console.WriteLine("The value is even");
                    }
                    else
                    {
                        Console.WriteLine("The value is odd");
                    }
                }
            })
            {
                IsBackground = true
            };

            foregroundThread.Start();
            backgroundThread.Start();
            backgroundThread.Join();

            Console.ReadKey(true);
        }
    }
}
