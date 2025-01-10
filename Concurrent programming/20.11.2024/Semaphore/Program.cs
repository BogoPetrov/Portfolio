namespace Semaphore
{
    using Semaphore = System.Threading.Semaphore;
    class Program
    {
        private static readonly Semaphore semaphore = new(2, 3);
        private static int sharedNumber = 0;
        private static readonly object lockObject = new();

        public static void Main(string[] args)
        {
            Thread threadOne = new(WorkForFrist) { Name = "Nishka1" };
            Thread threadTwo = new(WorkForSecond) { Name = "Nishka2" };

            threadOne.Start();
            threadTwo.Start();

            threadOne.Join();
            threadTwo.Join();
        }

        public static void WorkForFrist()
        {
            while (true)
            {
                semaphore.WaitOne();
                lock (lockObject)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} = Running");
                }

                lock (lockObject)
                {
                    sharedNumber++;
                    Console.WriteLine($"{Thread.CurrentThread.Name} add number 1");
                }

                Thread.Sleep(1000);

                lock (lockObject)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} releasing...");
                    sharedNumber--;
                    Console.WriteLine($"The number after releasing: {sharedNumber}");
                }
                semaphore.Release();

                Thread.Sleep(1000);
            }
        }

        public static void WorkForSecond()
        {
            while (true)
            {
                lock (lockObject)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} = waiting");
                }
                Thread.Sleep(2000);
            }
        }
    }
}
