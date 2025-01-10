namespace Lock_Exercises
{
    internal class Program
    {
        private static List<byte> numbers = [];
        static void Main(string[] args)
        {
            Thread firstThread = new(Add) { Name = "First" };
            Thread secondThread = new(Add) { Name = "Second" };

            firstThread.Start();
            secondThread.Start();

            while (firstThread.IsAlive || secondThread.IsAlive)
            {
                continue;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            Console.ReadKey(true);
        }

        public static void Add()
        {
            lock (numbers)
            {
                byte startNumber;
                if (numbers.Count != 0)
                {
                    startNumber = numbers[numbers.Count - 1];
                }
                else
                {
                    startNumber = 0;
                }


                for (byte i = 1; i <= 5; i++)
                {
                    numbers.Add((byte)(startNumber + i));
                }
            }
        }
    }
}
