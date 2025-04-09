using MyTimer = System.Timers;

namespace Timer_1
{
    internal class Program
    {
        private static int _count = 0;
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MyTimer.Timer timer = new()
            {
                Interval = 1000
            };

            timer.Elapsed += TimerElapsed!;

            timer.Start();

            Console.WriteLine("Timer is started. Press Enter to stop it.");
            Console.ReadLine();

            timer.Stop(); 

            Console.WriteLine("Timer is stopped. Press any key to exit.");
            Console.ReadKey(true);
        }

        public static void TimerElapsed(object sender, MyTimer.ElapsedEventArgs e)
        {
            _count++;
            Console.WriteLine(_count);
        }
    }
}
