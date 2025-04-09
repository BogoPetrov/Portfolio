namespace Tasks_Exercise
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Program
    {
        private readonly static List<long> randomNumbers = [];

        static async Task Main()
        {
            Task task1 = AddRandomNumbersAsync();
            Task task2 = PrintNumbersAsync();

            await task2;
            Console.ReadKey(true);
        }

        static async Task AddRandomNumbersAsync()
        {
            Random random = new();
            for (int i = 0; i < 10; i++)
            {
                randomNumbers.Add(random.Next(0, int.MaxValue));
                Console.WriteLine($"Task {Task.CurrentId} added number {randomNumbers[i]}");
                await Task.Delay(100);
            }
        }

        static async Task PrintNumbersAsync()
        {
            Task.WaitAll(); // wait for task1 to add some numbers
            Console.WriteLine("Task " + Task.CurrentId + " is printing numbers:");
            foreach (var number in randomNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}