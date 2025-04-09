using System.Collections;

namespace Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? input = Console.ReadLine();
            List<int> stones = [.. input!.Split(',').Select(int.Parse)];

            Lake<int> lake = [];
            lake.AddStones(stones);
            IEnumerator<int> result = lake.GetEnumerator();

            string? resultString = "";

            while (result.MoveNext())
            {
                resultString += result.Current + ", ";
            }

            Console.WriteLine();
            resultString = resultString.TrimEnd(',', ' ');
            Console.Write(resultString);

            Console.ReadKey(true);
        }
    }

    public class Lake<T> : IEnumerable<T>
    {
        public T[] _elements = [];

        public void AddStones(List<T> stones)
        {
            List<T> evenIndexes = [];
            List<T> oddIndexes = [];
            for (int i = 0; i < stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    evenIndexes.Add(stones[i]); 
                }
                else
                {
                    oddIndexes.Add(stones[i]);
                }
            }
            oddIndexes.Reverse();

            _elements = [.. evenIndexes, .. oddIndexes];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LakeEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LakeEnumerator(Lake<T> lake) : IEnumerator<T>
        {
            private readonly Lake<T> _lake = lake;
            private int _index = -1;

            public T Current => _lake._elements[_index];

            object IEnumerator.Current => Current!;

            public bool MoveNext()
            {
                _index++;
                return _index < _lake._elements.Length;
            }

            public void Reset()
            {
                _index = -1;
            }

            public void Dispose() { }
        }
    }
}
