namespace Comparator_Exercises
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Team> teams = [
                new() {Name = "Manchester United", City = "Manchester", YearFounded = new DateOnly(1878, 1, 1)},
                new() {Name = "Chelsea", City = "London", YearFounded = new DateOnly(1905, 1, 1)},
                new() {Name = "Liverpool", City = "Liverpool", YearFounded = new DateOnly(1892, 1, 1)}
            ];


            foreach (Team team in teams)
            {
                Console.WriteLine(team);
            }

            Console.WriteLine();
            teams.Sort();

            Console.WriteLine("Sorted teams by year founded:");
            foreach (Team team in teams)
            {
                Console.WriteLine(team);
            }

            Console.WriteLine();
            Console.WriteLine("Sorted teams by name:");
            teams.Sort(new TeamComparer());
            foreach (Team team in teams)
            {
                Console.WriteLine(team);
            }
            Console.ReadKey(true);
        }
    }

    public class Team : IComparable<Team>
    {
        public string? Name { get; set; }
        public string? City { get; set; }
        public DateOnly? YearFounded { get; set; }

        public int CompareTo(Team? other)
        {
            if (other == null)
            {
                return 1;
            }
            return YearFounded!.Value.CompareTo(other.YearFounded!.Value);
        }

        public override string ToString()
        {
            return $"Name: {Name}, City: {City}, Year Founded: {YearFounded}";
        }
    }

    public class TeamComparer : IComparer<Team>
    {
        public int Compare(Team? x, Team? y)
        {
            return x?.Name!.CompareTo(y?.Name!) ?? 0;
        }
    }
}
