namespace Practice
{
    internal class Program
    {
        public static readonly List<int>? randomNumbers = [];

        public static async Task Main()
        {
            Task taskAddNumbers = new Task(() => AddNumbersAsync());
            Console.WriteLine($"Task id {taskAddNumbers.Id} added numbers...");
            taskAddNumbers.Start();

            Task taskPrintNumbers = new Task(() => PrintListAsync());
            Console.WriteLine($"Task id {taskPrintNumbers.Id} printing numbers...");
            taskPrintNumbers.Start();

            await Task.WhenAll(taskAddNumbers, taskPrintNumbers);

            Console.ReadKey(true);
        }

        public static async Task AddNumbersAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                randomNumbers!.Add(new Random().Next(0, int.MaxValue));
                await Task.Delay(100);
            }
        }

        public static async Task PrintListAsync()
        {
            await Task.Delay(1000);
            foreach (var number in randomNumbers!)
            {
                Console.WriteLine(number);
            }
        }
    }
}
