namespace Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car()
            {
                WheelsCount = 4,
                PassangersCount = 5,
                Speed = 300,
                Model = "X5",
                Color = "Red"
            };

            Motorbike moterbike = new()
            {
                WheelsCount = 2,
                PassangersCount = 2,
                Speed = 250,
                Model = "Honda",
                Color = "Black"
            };

            Console.WriteLine(car.ToString());
            Console.WriteLine();
            Console.WriteLine(moterbike.ToString());

            Console.ReadKey(true);
        }
    }
}
