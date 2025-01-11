namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes =
            [
                new Hero("Athena"),
                new Hero("Ethan"),
                new Hero("Sophia"),
                new Knight("Sir Valor"),
                new Knight("Sir Galahad"),
                new Knight("Sir Percival"),
                new Wizard("Zephyr", "Staff of Light"),
                new Wizard("Lyra", "Crystal Ball"),
                new Wizard("Kaida", "Tome of Shadows")
            ];

            for (int i = 0; i < heroes.Count; i++)
            {
                for (int j = 0; j < heroes.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    else
                    {
                        heroes[i].Battle(heroes[j]);
                        Console.WriteLine("----------------------------------");
                    }
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine();

            for (int i = 0; i < heroes.Count; i++)
            {
                Console.WriteLine(heroes[i].ShowExperience());
                Console.WriteLine("----------------------------------");
            }

            Console.ReadKey(true);
        }
    }
}
