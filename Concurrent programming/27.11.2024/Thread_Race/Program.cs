namespace Thread_Race
{
    internal class Program
    {
        private readonly static AutoResetEvent autoResetEvent = new(false);
        public static void ThreadMethod()
        {
            if (WaitHandle.WaitAll([autoResetEvent]))
            {
                Console.WriteLine("Thread got signal");
            }
        }
        public static void Work1()
        {
            Console.WriteLine("Continue1");
            autoResetEvent.Set();
        }

        public static void Work2()
        {
            Console.WriteLine("Continue2");
            autoResetEvent.Set();
        }

        static void Main(string[] args)
        {
            Thread tr1 = new(ThreadMethod);
            Thread tr2 = new(Work1);
            Thread tr3 = new(Work2);
            tr1.Start();
            tr2.Start();
            tr3.Start();
            Console.ReadKey(true);
        }
    }
}
