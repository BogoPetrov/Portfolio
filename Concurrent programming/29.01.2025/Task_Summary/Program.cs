namespace Task_Summary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //CallMethod();
            Task t1 = Task.Run(() =>
            {
                PrintInfo();
            });

            t1.Wait();

            Console.WriteLine("Main Thread Completed");

            Console.ReadKey(true);
        }

        public static async void PrintInfo()
        {
            for (int i = 0; i <= 4; i++)
            {
                Console.WriteLine($"{Task.CurrentId} value: {i}");
                await Task.Delay(1000);
            }
        }

        public static async void CallMethod()
        {
            Task<int> task = Method1();
            Method2();
            int count = await task;
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Method 1");
                    count++;
                }
            });
            return count;
        }

        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine("Method 2");
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine($"Total count is {count}");
        }
    }
}
