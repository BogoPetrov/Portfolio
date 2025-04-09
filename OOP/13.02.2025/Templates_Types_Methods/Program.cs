namespace Templates_Types_Methods
{
    internal class Program
    {
        static void Main()
        {
            #region Ex. 1
            string[] strings = ArrayCreator<string>.Create(5, "Pesho");
            int[] integers = ArrayCreator<int>.Create(10, 33);
            Console.WriteLine(string.Join(" ", strings));
            Console.WriteLine(string.Join(" ", integers));
            Console.WriteLine();
            #endregion

            // Vars for count in Ex. 2, Ex. 3, Ex. 4 and Ex. 5
            int count;
            string? input;

            #region Ex. 2
            count = int.Parse(Console.ReadLine()!);
            Box<string> box2 = new();
            box2.AddItems(count);
            input = Console.ReadLine()!;
            Console.WriteLine();
            box2.Swap(int.Parse(input.Split()[0]), int.Parse(input.Split()[1]));
            #endregion

            Console.WriteLine();

            #region Ex. 3
            count = int.Parse(Console.ReadLine()!);
            Box<int> box3 = new();
            box3.AddItems(count);
            input = Console.ReadLine()!;
            Console.WriteLine();
            box3.Swap(int.Parse(input.Split()[0]), int.Parse(input.Split()[1]));
            #endregion

            Console.WriteLine();

            #region Ex. 4
            count = int.Parse(Console.ReadLine()!);
            Box<string> box4 = new();
            box4.AddItems(count);
            input = Console.ReadLine()!;
            Console.WriteLine();
            Console.WriteLine(box4.FindGreaterItem(input));
            #endregion

            Console.WriteLine();

            #region Ex. 5
            count = int.Parse(Console.ReadLine()!);
            Box<double> box5 = new();
            box5.AddItems(count);
            input = Console.ReadLine()!;
            Console.WriteLine();
            Console.WriteLine(box5.FindGreaterItem(double.Parse(input)));
            #endregion

            Console.ReadKey(true);
        }
    }

    public class ArrayCreator<T>
    {
        private static T[]? _array;

        public static T[] Create(int length, params List<T> values)
        {
            _array = new T[length];
            _array = [.. values];
            return _array;
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
                if (_items.GetType() == typeof(List<double>))
                {
                    if (double.TryParse(item, out double itemValue))
                    {
                        (_items as List<double>)!.Add(itemValue); 
                    }
                }
                if (_items.GetType() == typeof(List<string>))
                {
                    (_items as List<string>)!.Add(item);
                }
            }
        }

        public void Swap(int index1, int index2)
        {
            (_items[index2], _items[index1]) = (_items[index1], _items[index2]);
            Console.Write(ToString());
        }

        public int FindGreaterItem(T item)
        {
            int count = 0;
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items.GetType() == typeof(List<string>))
                {
                    if (item!.GetType() == typeof(string))
                    {
                        if ((_items as List<string>)![i]!.CompareTo(item) > 0)
                        {
                            count++;
                        }
                    }
                }
                if (_items.GetType() == typeof(List<double>))
                {
                    if (item!.GetType() == typeof(double))
                    {
                        if ((_items as List<double>)![i].CompareTo(item) > 0)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
