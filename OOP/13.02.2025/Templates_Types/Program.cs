namespace Templates_Types
{
    internal class Program
    {
        static void Main()
        {
            #region Ex. 1
            Box<int> box1 = new();
            box1.Add(1);
            box1.Add(2);
            box1.Add(3);
            Console.WriteLine();
            Console.WriteLine(box1.Remove(2));
            Console.WriteLine();

            box1.Add(4);
            box1.Add(5);
            Console.WriteLine(box1.Remove(4));
            Console.WriteLine();

            Console.WriteLine($"There are {box1.Count()} elements in this box");
            Console.WriteLine();
            #endregion

            #region Ex. 2
            box1.Add(123123);
            Console.WriteLine(box1.ToString());
            Console.WriteLine();

            Box<string> box2 = new();
            box2.Add("life in a box");
            Console.WriteLine(box2.ToString());
            #endregion

            // Var for count in Ex. 3 and Ex. 4
            int count;

            #region Ex. 3
            count = int.Parse(Console.ReadLine()!);
            Box<string> box3 = new();
            box3.AddItems(count);
            Console.WriteLine(box3.ToString());
            Console.WriteLine();
            #endregion

            #region Ex. 4
            count = int.Parse(Console.ReadLine()!);
            Box<int> box4 = new();
            box4.AddItems(count);
            Console.WriteLine(box4.ToString());
            Console.WriteLine();
            #endregion

            Console.ReadKey(true);
        }
    }

    public class Box<T>
    {
        private readonly List<T> _items;

        public Box()
        {
            _items = [];
        }

        public void Add(T item)
        {
            _items.Add(item);
            Console.WriteLine($"The item with value {item} was added");
        }

        public string? Remove(T item)
        {
            T selected = item;
            _items.Remove(item);
            return $"The item with value {selected} was removed";
        }

        public int Count()
        {
            return _items.Count;
        }

        public override string ToString()
        {
            string? text = "";
            for (int i = 0; i < _items.Count; i++)
            {
                text += $"{_items[i]!.GetType().FullName}: {_items[i]}\n";
            }
            return text;
        }

        public void AddItems(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string? item = Console.ReadLine()!;
                if (_items.GetType() == typeof(List<int>))
                {
                    if (int.TryParse(item, out int itemValue))
                    {
                        (_items as List<int>)!.Add(itemValue);
                    }
                }
                if (_items.GetType() == typeof(List<string>))
                {
                    (_items as List<string>)!.Add(item);
                }
            }
        }
    }
}