namespace Execise_Task
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            Random random = new();

            int pizzaTime = random.Next(2000, 5000);
            int pastaTime = random.Next(2000, 5000);
            int dessertTime = random.Next(4000, 7000);

            Task pizzaTask = PreparePizza(pizzaTime);
            Task pastaTask = PreparePasta(pastaTime);
            Task dessertTask = PrepareDessert(dessertTime);

            Stopwatch stopwatch = Stopwatch.StartNew();

            pizzaTask.Wait();
            await pastaTask;
            await dessertTask;

            stopwatch.Stop();

            Console.WriteLine("\nAll dishes are ready!");
            Console.WriteLine($"Total preparation time: {stopwatch.ElapsedMilliseconds / 1000.0} seconds.");
            Console.ReadKey(true);
        }

        public static Task PreparePizza(int delay)
        {
            Console.WriteLine("Pizza preparation starts...");
            Task.Delay(delay).Wait();
            Console.WriteLine($"Pizza is ready after {delay / 1000.0} seconds.");
            return Task.CompletedTask;
        }

        public static async Task PreparePasta(int delay)
        {
            Console.WriteLine("Pasta preparation starts...");
            await Task.Delay(delay);
            Console.WriteLine($"Pasta is ready after {delay / 1000.0} seconds.");
        }

        public static async Task PrepareDessert(int delay)
        {
            Console.WriteLine("Dessert preparation starts...");
            await Task.Delay(delay);
            Console.WriteLine($"Dessert is ready after {delay / 1000.0} seconds.");
        }
    }
}