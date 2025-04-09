using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            Stack<int> stack = new([]);
            string?[] items;
            string? command;

            while (flag)
            {
                string? input = Console.ReadLine();
                command = input!.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];

                switch (command.ToLower())
                {
                    case "push":
                        {
                            items = input[5..].Split(',', StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < items.Length; i++)
                            {
                                stack.Push(int.Parse(items[i]!));
                            }
                        }
                        break;

                    case "pop":
                        {
                            stack.Pop();
                        }
                        break;

                    case "end":
                        {
                            flag = false;
                        }
                        break;
                }
            }

            IEnumerator<int> enumerator = stack.GetEnumerator();

            // Write all elements once time
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            enumerator.Reset();

            // Write all elements again
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            Console.ReadKey(true);
        }
    }

    public class Stack<T>(List<T>? elements) : IEnumerable<T>
    {
        private readonly List<T> _elements = elements ?? [];

        public void Push(T item)
        {
            _elements.Add(item);
        }

        public T Pop()
        {
            if (_elements.Count == 0)
            {
                Console.WriteLine("The stack is empty.");
                return default!;
            }
            else
            {
                T item = _elements[^1];
                _elements.RemoveAt(_elements.Count - 1);
                return item;
            }
        }

        public T Peek()
        {
            if (_elements.Count == 0)
                throw new InvalidOperationException("The stack is empty.");

            return _elements[^1];
        }

        public int Count => _elements.Count;

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class StackEnumerator : IEnumerator<T>
        {
            private readonly Stack<T> _stack;
            private int _index;

            public StackEnumerator(Stack<T> stack)
            {
                _stack = stack;
                _index = _stack._elements.Count;
            }

            public T Current => _stack._elements[_index];

            object IEnumerator.Current => Current!;

            public bool MoveNext()
            {
                _index--;
                return _index >= 0;
            }

            public void Reset()
            {
                _index = _stack._elements.Count;
            }

            public void Dispose() { }
        }
    }
}
