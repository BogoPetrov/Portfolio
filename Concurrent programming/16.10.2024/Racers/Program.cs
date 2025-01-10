namespace ThreadsCycle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread[] racers = new Thread[5];
            bool[] stopFlags = new bool[5];

            for (int i = 0; i < 5; i++)
            {
                stopFlags[i] = false;
                int racerIndex = i;
                racers[i] = new Thread(() => RunRace(ref stopFlags[racerIndex]))
                {
                    Name = $"Racer {i + 1}"
                };

                if (i == 1)
                {
                    Console.WriteLine("Stopping racer 2!");
                    stopFlags[1] = true;
                }
                else if (i == 3)
                {
                    Console.WriteLine("Stopping racer 4!");
                    stopFlags[3] = true;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                racers[i].Start();
                racers[i].Join();
            }
            Console.WriteLine("All racers finished the race!");

            Console.ReadKey(true);
        }

        public static void RunRace(ref bool stopFlag)
        {
            for (int km = 10; km >= 0; km--)
            {
                if (stopFlag)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} stopped at {km} km for the finish.");
                    return;
                }
                else
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} ran {km} km.");
                }

            }
            Console.WriteLine($"{Thread.CurrentThread.Name} finished the race!");
        }
    }
}
