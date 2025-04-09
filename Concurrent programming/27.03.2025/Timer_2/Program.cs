using MyTimer = System.Timers;

namespace Timer_2
{
    internal class Program
    {
        private static int _count;

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MyTimer.Timer timer = new()
            {
                Interval = 2000 // Set interval to 2 seconds
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
            DateTime localTime = DateTime.Now;
            DateTime utcTime = DateTime.UtcNow;
            Console.WriteLine($"LOCAL: {localTime} UTC: {utcTime}");
        }
    }
}
