using System.Collections;

namespace LinkedList_Iterators
{
    internal class Program
    {
        static void Main()
        {
            LinkedList<int?> list = [];
            List<string?>? commands;
            string? input;

            if (int.TryParse(Console.ReadLine(), out int count))
            {
                for (int i = 0; i < count; i++)
                {
                    input = Console.ReadLine();
                    commands = [.. input!.Split(' ')];

                    switch (commands.Count)
                    {
                        case 2:
                            {
                                if (commands[0]!.Equals("Add", StringComparison.OrdinalIgnoreCase))
                                {
                                    list.Add(int.Parse(commands[1]!));
                                }
                                else if (commands[0]!.Equals("Remove", StringComparison.OrdinalIgnoreCase))
                                {
                                    list.Remove(int.Parse(commands[1]!));
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine(list.Count);
            IEnumerator<int?> enumerator = list.GetEnumerator();
            string? values = "";
            while (enumerator.MoveNext())
            {
                values += enumerator.Current + " ";
            }
            _ = values.TrimEnd(' ');
            Console.Write(values);
            Console.ReadKey(true);
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        private class Node(T value)
        {
            public T _value = value;
            public Node _next = null!;
        }

        private Node? _head;
        private Node? _tail;
        private int _count;

        public LinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public int Count => _count;

        public void Add(T item)
        {
            Node newNode = new(item);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail!._next = newNode;
                _tail = newNode;
            }
            _count++;
        }

        public bool Remove(T item)
        {
            Node current = _head!;
            Node previous = null!;

            while (current != null)
            {
                if (current!._value!.Equals(item))
                {
                    if (previous == null)
                    {
                        _head = current._next;
                    }
                    else
                    {
                        previous._next = current._next;
                    }

                    if (current._next == null)
                    {
                        _tail = previous;
                    }

                    _count--;
                    return true;
                }

                previous = current;
                current = current._next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = _head!;
            while (current != null)
            {
                yield return current._value;
                current = current._next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
