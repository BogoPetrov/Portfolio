namespace Thread_Priority_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating and initializing threads
            Thread T1 = new(Work);
            Thread T2 = new(Work);
            Thread T3 = new(Work);

            // Set the priority of threads
            T2.Priority = ThreadPriority.Highest;
            T3.Priority = ThreadPriority.BelowNormal;
            T1.Start();
            T2.Start();
            T3.Start();

            // Display the priority of threads
            Console.WriteLine("The priority of T1 is: {0}", T1.Priority);
            Console.WriteLine("The priority of T2 is: {0}", T2.Priority);
            Console.WriteLine("The priority of T3 is: {0}", T3.Priority);

            Console.ReadKey(true);
        }

        public static void Work()
        {
            // Sleep for 1 second
            Thread.Sleep(1000);
        }
    }
}
