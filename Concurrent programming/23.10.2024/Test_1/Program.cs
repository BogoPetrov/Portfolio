namespace Test_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[4];

            for (int i = 0; i < threads.Length; i++)
            {
                if (i % 2 == 0)
                {
                    threads[i] = new(Calculation);
                }
                else
                {
                    threads[i] = new(PrintThreadInformation);
                }
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
                threads[i].Join();
            }

            Console.ReadKey(true);
        }

        public static void Calculation()
        {
            //Console.Write("Enter radius of the circle: ");
            //double radius = Convert.ToDouble(Console.ReadLine());
            //if (radius <= 0)
            //{
            //    while (radius <= 0)
            //    {
            //        Console.Write("Enter valid value again: ");
            //        radius = Convert.ToDouble(Console.ReadLine());
            //    }
            //}

            double radius = 15.0;

            Thread.Sleep(500);
            Console.WriteLine($"The area of the circle is: {Math.Round(Math.PI * Math.Pow(radius, 2), 2)}");

        }

        public static void PrintThreadInformation()
        {
            Thread.Sleep(500);
            Console.WriteLine(Thread.CurrentThread.ThreadState);
        }
    }
}
