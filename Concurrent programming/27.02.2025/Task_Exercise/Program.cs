namespace Task_Exercise
{
    using System;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main(string[] args)
        {
            Task<int>[] tasks = [StartNewCar("Red Car", 0), StartNewCar("Blue Car", 0), StartNewCar("Green Car", 0)];
            Task.WaitAll(tasks);

            Console.WriteLine("Final positions:");
            Console.WriteLine($"Red Car: {tasks[0].Result}");
            Console.WriteLine($"Blue Car: {tasks[1].Result}");
            Console.WriteLine($"Green Car: {tasks[2].Result}");

            int winnerPosition = Math.Max(Math.Max(tasks[0].Result, tasks[1].Result), tasks[2].Result);
            string winnerName = winnerPosition == tasks[0].Result ? "Red Car" :
                                winnerPosition == tasks[1].Result ? "Blue Car" :
                                "Green Car";

            Console.WriteLine($"{winnerName} wins the race!");

            Console.ReadKey(true);
        }

        public static Task<int> StartNewCar(string name, int initialPosition)
        {
            return Task.Factory.StartNew(() => RaceCar(name, initialPosition));
        }

        public static int RaceCar(string name, int initialPosition)
        {
            Random random = new();
            int currentPosition = initialPosition;

            while (currentPosition <= 50)
            {
                int speed = random.Next(1, 10);
                currentPosition += speed;
                Console.WriteLine($"{name} moved {speed} positions. Current position: {currentPosition}");
                
                Task.Delay(100).Wait();
            }

            return currentPosition;
        }
    }
}
