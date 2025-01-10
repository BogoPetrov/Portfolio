namespace Thread_Priority_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating and initializing threads
            Thread T1 = new(Work1);
            Thread T2 = new(Work2);

            // Set the priority of threads
            // Here T2 thread executes first
            // because the Priority of T2 is
            // highest as compared to T1 thread
            T1.Priority = ThreadPriority.Lowest;
            T2.Priority = ThreadPriority.Highest;

            T1.Start();
            T2.Start();

            Console.ReadKey(true);
        }

        public static void Work1()
        {
            Console.WriteLine("T1 thread is working..");
        }

        public static void Work2()
        {
            Console.WriteLine("T2 thread is working..");
        }
    }
}
