namespace Thread_ResSusp_Alter
{
    using System;
    using System.Threading;

    class Program
    {
        static readonly ManualResetEvent pauseEvent = new(false);
        static bool stopThread = false;

        static void Main()
        {

            Thread workerThread = new(WorkerMethod);
            workerThread.Start();

            Console.WriteLine("Press 'p' to pause, 'r' to resume, and 'q' to quit.");

            while (true)
            {
                char input = Console.ReadKey(true).KeyChar;
                if (input == 'p')
                {
                    Console.WriteLine("Pausing thread...");
                    pauseEvent.Reset();
                }
                else if (input == 'r')
                {
                    Console.WriteLine("Resuming thread...");
                    pauseEvent.Set();
                }
                else if (input == 'q')
                {
                    Console.WriteLine("Stopping thread...");
                    stopThread = true;
                    pauseEvent.Set();
                    break;
                }
            }

            workerThread.Join();
            Console.WriteLine("Thread stopped.");

            Console.ReadKey(true);
        }

        static void WorkerMethod()
        {
            while (!stopThread)
            {

                pauseEvent.WaitOne();

                Console.WriteLine("Working...");
                Thread.Sleep(1000);
            }
        }
    }

}
