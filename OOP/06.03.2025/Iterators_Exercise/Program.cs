namespace Iterators_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string?> authors = [];
            authors.Add("William");
            authors.Add("Agatha");
            authors.Add("Barbara Cartland");
            authors.Add("Danielle");
            authors.Add("Harold");
            authors.Add("Georges");

            authors.Insert(3, "Dorothy");
            authors.Remove("Georges Simenon");
            Console.WriteLine(string.Join(", ", authors));
            Console.WriteLine(authors.IndexOf("Danielle"));
            authors.Reverse();
            Console.WriteLine(string.Join(", ", authors));
            authors.Sort();
            Console.WriteLine(string.Join(", ", authors));

            Console.WriteLine(authors.Count);

            Console.ReadKey(true);
        }
    }
}
