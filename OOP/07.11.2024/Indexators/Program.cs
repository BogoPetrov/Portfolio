namespace Indexators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IndexClass team = new();
            team[0] = "Rocky";
            team[1] = "Teena";
            team[2] = "Ana";
            team[3] = "Victoria";

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(team[i]);
            }

            Console.ReadKey(true);
        }
    }
}
