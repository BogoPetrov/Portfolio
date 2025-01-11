namespace Review
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Toyota", "Corolla", 2005);
            Console.WriteLine("First car: ");
            car1.CarInfo();
            Console.WriteLine();

            Car car2 = new Car("Honda", "Civic", 2010);
            Console.WriteLine("Second car: ");
            car2.CarInfo();
            Console.WriteLine();
            
            Console.WriteLine("The older car form the two cars is: ");
            Car.CarComparison(car1, car2);
            Console.WriteLine();

            Console.WriteLine($"All cars total count is: {Car.TotalCount}");

            Console.ReadKey();
        }
    }
}
