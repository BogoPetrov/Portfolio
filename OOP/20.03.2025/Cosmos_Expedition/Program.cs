namespace Cosmos_Expedition
{
    using System;
    using System.Collections.Generic;

    class Mission(string name, string destination, DateTime launchDate, int durationDays, double budget) : IComparable<Mission>
    {
        public string Name { get; set; } = name;
        public string Destination { get; set; } = destination;
        public DateTime LaunchDate { get; set; } = launchDate;
        public int DurationDays { get; set; } = durationDays;
        public double Budget { get; set; } = budget;

        public int CompareTo(Mission? other)
        {
            return LaunchDate.CompareTo(other!.LaunchDate);
        }

        public override string ToString()
        {
            return $"{Name} - {Destination}, Launch: {LaunchDate.ToShortDateString()}, Duration: {DurationDays} days, Budget: ${Budget}B";
        }
    }

    class MissionBudgetComparer : IComparer<Mission>
    {
        public int Compare(Mission? x, Mission? y)
        {
            return y!.Budget.CompareTo(x!.Budget);
        }
    }

    class MissionComplexityComparer : IComparer<Mission>
    {
        public int Compare(Mission? x, Mission? y)
        {
            int durationComparison = y!.DurationDays.CompareTo(x!.DurationDays);
            if (durationComparison != 0)
                return durationComparison;

            int destinationComparison = string.Compare(x.Destination, y.Destination, StringComparison.Ordinal);
            if (destinationComparison != 0)
                return destinationComparison;

            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<Mission> missions =
            [
                new("Apollo 11", "Moon", new DateTime(1969, 7, 16), 8, 25.4),
                new("Mars Rover", "Mars", new DateTime(2020, 7, 30), 687, 2.7),
                new("Voyager 1", "Interstellar", new DateTime(1977, 9, 5), 16000, 0.25),
                new("Europa Clipper", "Europa", new DateTime(2024, 10, 15), 3650, 4.25)
            ];

            Console.WriteLine("Sorted by Launch Date:");
            missions.Sort();
            missions.ForEach(Console.WriteLine);

            Console.WriteLine("\nSorted by Budget:");
            missions.Sort(new MissionBudgetComparer());
            missions.ForEach(Console.WriteLine);

            Console.WriteLine("\nSorted by Complexity:");
            missions.Sort(new MissionComplexityComparer());
            missions.ForEach(Console.WriteLine);

            Console.ReadKey(true);
        }
    }
}
