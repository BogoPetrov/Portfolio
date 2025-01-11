namespace Films
{
    public class Film(string title, string director, int releaseYear, string genre, double budget)
    {
        public string Title { get; set; } = title;
        public string Director { get; set; } = director;
        public int ReleaseYear { get; set; } = releaseYear;
        public string Genre { get; set; } = genre;
        public double Budget { get; set; } = budget;

        public override string ToString()
        {
            return $"{Title} ({ReleaseYear}), Directed by {Director}, Genre: {Genre}, Budget: {Budget}M USD";
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<Film> films = [];

            Console.WriteLine("Welcome to the Film Catalog!");
            Console.WriteLine("Please enter details for 5 films.\n");

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Enter details for film #{i}:");

                Console.Write("Title: ");
                string title = Console.ReadLine()!;

                Console.Write("Director: ");
                string director = Console.ReadLine()!;

                Console.Write("Release Year: ");
                int releaseYear;
                while (!int.TryParse(Console.ReadLine(), out releaseYear) || releaseYear <= 0)
                {
                    Console.Write("Invalid year. Please enter a valid release year: ");
                }

                Console.Write("Genre: ");
                string genre = Console.ReadLine()!;

                Console.Write("Budget (in millions USD): ");
                double budget;
                while (!double.TryParse(Console.ReadLine(), out budget) || budget < 0)
                {
                    Console.Write("Invalid budget. Please enter a positive value: ");
                }

                films.Add(new Film(title!, director!, releaseYear, genre!, budget));
                Console.WriteLine("Film added successfully!\n");
            }

            Console.WriteLine("Here are the films you entered:");
            foreach (var film in films)
            {
                Console.WriteLine(film);
            }

            Console.WriteLine("\nFilms released after 2019:");
            foreach (var film in films.Where(f => f.ReleaseYear > 2019))
            {
                Console.WriteLine(film);
            }

            Console.WriteLine("\nNumber of films by genre:");
            var genreCount = films.GroupBy(f => f.Genre).ToDictionary(g => g.Key, g => g.Count());

            foreach (var genre in genreCount)
            {
                Console.WriteLine($"{genre.Key}: {genre.Value}");
            }

            var sortedFilms = films.OrderBy(f => f.Budget).ToList();
            Console.WriteLine("\nFilms sorted by budget:");
            foreach (var film in sortedFilms)
            {
                Console.WriteLine(film);
            }

            var highBudgetFilms = new List<Film>();

            Console.WriteLine("\nMoving top 2 highest budget films to highBudgetFilms:");
            while (sortedFilms.Count > 2)
            {
                var filmToRemove = sortedFilms.Last();
                sortedFilms.Remove(filmToRemove);
                highBudgetFilms.Add(filmToRemove);
            }

            Console.WriteLine("High budget films:");
            foreach (var film in highBudgetFilms)
            {
                Console.WriteLine(film);
            }

            Console.WriteLine("\nRemaining sorted films:");
            foreach (var film in sortedFilms)
            {
                Console.WriteLine(film);
            }

            Console.ReadKey(true);
        }
    }
}
