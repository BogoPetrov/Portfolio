using System.Diagnostics;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread starting.");

            int x = 5;
            int y = 10;

            // Create two tasks.
            Task<int> task1 = Task<int>.Factory.StartNew(() => DoCalculation("Task 1", x, y));
            Task<int> task2 = Task<int>.Factory.StartNew(() => DoCalculation("Task 2", x, y));

            // Wait for both tasks to complete.
            System.Threading.Tasks.Task.WaitAll(task1, task2);

            // Get the results of the two tasks.
            double result1 = task1.Result;
            double result2 = task2.Result;

            Console.WriteLine($"Result 1: {result1}");
            Console.WriteLine($"Result 2: {result2}");

            Console.WriteLine("Main thread ending.");
            Console.ReadKey(true);
        }

        static int DoCalculation(string taskName, int x, int y)
        {
            Console.WriteLine($"{taskName} starting.");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Perform a calculation.
            int result = x * y;

            stopwatch.Stop();
            Console.WriteLine($"{taskName} ending after {stopwatch.ElapsedMilliseconds} milliseconds.");

            return result;
        }
    }
}
