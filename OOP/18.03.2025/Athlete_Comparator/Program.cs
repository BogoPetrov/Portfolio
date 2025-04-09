namespace Athlete_Comparator
{
    internal class Program
    {
        public static void Main()
        {
            List<Athlete> athletes = [
            new Athlete("John", "Doe", 95.5, 22),
            new Athlete("Alice", "Smith", 97.2, 24),
            new Athlete("Bob", "Doe", 95.5, 21),
            new Athlete("Charlie", "Brown", 90.1, 23)
            ];

            Console.WriteLine("Sorted by AverageScore (descending):");
            athletes.Sort();
            athletes.ForEach(Console.WriteLine);

            Console.WriteLine("\nSorted by LastName, FirstName, Age:");
            athletes.Sort(new AthleteComparer());
            athletes.ForEach(Console.WriteLine);
            Console.ReadKey(true);
        }
    }

    class Athlete(string firstName, string lastName, double averageScore, int age) : IComparable<Athlete>
    {
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public double AverageScore { get; set; } = averageScore;
        public int Age { get; set; } = age;

        public int CompareTo(Athlete? other)
        {
            return other!.AverageScore.CompareTo(AverageScore); // Descending order
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, Score: {AverageScore}, Age: {Age}";
        }
    }

    class AthleteComparer : IComparer<Athlete>
    {
        public int Compare(Athlete? x, Athlete? y)
        {
            int lastNameComparison = x!.LastName.CompareTo(y!.LastName);
            if (lastNameComparison != 0) return lastNameComparison;

            int firstNameComparison = x!.FirstName.CompareTo(y!.FirstName);
            if (firstNameComparison != 0) return firstNameComparison;

            return x.Age.CompareTo(y.Age);
        }
    }
}
