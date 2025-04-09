namespace Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStore<string, int> store = new();
            store.Add("Ivan", 10);
            store.Add("Peter", 15);
            store.Add("Georgie", 17);
            store.Add("Ann", 35);
            store.Add("Jhon", 25);
            store.Add("Jane", 15);
            store.Add("Marina", 65);
            store.Add("Daniel", 18);
            store.Add("Ilon", 45);
            store.Add("Ilan", 34);
            
            string? input;
            while (true)
            {
                input = Console.ReadLine()!;
                if (int.TryParse(input, out int result))
                {
                    store.Print(result - 1);
                }
                else
                {
                    if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("Program finished!");
            Console.ReadKey(true);
        }
    }

    public class DataStore<TKey, TValue> where TKey : notnull
    {
        private Dictionary<TKey, TValue> Dictionary { get; set; } = [];

        public void Add(TKey key, TValue value)
        {
            Dictionary.Add(key, value);
        }

        public void Print(int select)
        {
            for (int i = 0; i < Dictionary.Count; i++)
            {
                if (i == select)
                {
                    Console.WriteLine($"{Dictionary.ElementAt(i).Key} : {Dictionary.ElementAt(i).Value}");
                }
            }
        }
    }
}
