namespace Async_Exercise
{
    internal class Program
    {
        public static async Task Main()
        {
            List<Task> orderTasks = [];
            Random random = new();

            bool flag = true;
            Console.Write("Enter the number of orders to process: ");
            while (flag)
            {
                if (int.TryParse(Console.ReadLine()!, out int count))
                {
                    for (int i = 1; i <= count; i++)
                    {
                        int orderId = i;
                        orderTasks.Add(ProcessOrderAsync(orderId, random.Next(1000, 5000)));
                    }
                    flag = false;
                }
                else
                {
                    Console.Write("Invalid input. Please enter a valid number: ");
                }
            }

            await Task.WhenAll(orderTasks);
            Console.WriteLine("All orders are processed.");
            Console.ReadKey(true);
        }

        public static async Task ProcessOrderAsync(int orderId, int delay)
        {
            Console.WriteLine($"Order {orderId} start processing...");
            await Task.Delay(delay);
            Console.WriteLine($"Order {orderId} has been processed in {delay / 1000.0} seconds.");
        }
    }
}
