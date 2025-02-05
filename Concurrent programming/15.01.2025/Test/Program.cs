using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Task<List<double>> weatherForecastTask = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(1000);
                return new List<double> { 22, 25, 21, 19, 23, 24, 20 };
            });

            Task<double> averageTemperatureTask = weatherForecastTask.ContinueWith((task) =>
            {
                return task.Result.Average();
            });

            Task<double> highestTemperatureTask = weatherForecastTask.ContinueWith((task) =>
            {
                return task.Result.Max();
            });

            Task<double> lowestTemperatureTask = weatherForecastTask.ContinueWith((task) =>
            {
                return task.Result.Min();
            });

            Task.WhenAll(weatherForecastTask, averageTemperatureTask, highestTemperatureTask, lowestTemperatureTask);

            Console.WriteLine("Weather Forecast Summary:");
            Console.WriteLine("- Temperatures: " + string.Join(", ", weatherForecastTask.Result));
            Console.WriteLine("- Average Temperature: " + averageTemperatureTask.Result + "°C");
            Console.WriteLine("- Highest Temperature: " + highestTemperatureTask.Result + "°C");
            Console.WriteLine("- Lowest Temperature: " + lowestTemperatureTask.Result + "°C");

            Console.ReadKey(true);
        }
    }
}
