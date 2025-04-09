using System.Collections;

namespace Library_Iterators
{
    internal class Program
    {
        public static void Main()
        {
            #region Ex. 1
            //Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            //Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            //Book bookThree = new Book("The Documents in the Case", 1930);
            //Library libraryOne = new Library(); 
            //Library libraryTwo = new Library(bookOne, bookTwo, bookThree); 
            #endregion

            #region Ex. 2
            //Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            //Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            //Book bookThree = new Book("The Documents in the Case", 1930);
            //Library libraryOne = new Library();
            //Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            //foreach (var book in libraryTwo)
            //{
            //    Console.WriteLine(book.Title);
            //} 
            #endregion

            #region Ex. 3
            //bool flag = true;
            //List<string> result = [];
            //string? input = Console.ReadLine();
            //input = input!.Remove(input.IndexOf("create", StringComparison.OrdinalIgnoreCase), 6);
            //List<string> items = [.. input.Split(',', ' ')];
            //items.Remove("");
            //ListyIterator<string> listyIterator = new ListyIterator<string>(items);
            //while (flag)
            //{
            //    input = Console.ReadLine();
            //    switch (input!.ToLower())
            //    {
            //        case "hasnext":
            //            {
            //                result.Add(listyIterator.HasNext().ToString());
            //            }
            //            break;
            //        case "move":
            //            {
            //                result.Add(listyIterator.Move().ToString());
            //            }
            //            break;
            //        case "print":
            //            {
            //                result.Add(listyIterator.Print()!);
            //            }
            //            break;
            //        case "end":
            //            {
            //                flag = false;
            //            }
            //            break;
            //    }
            //}
            //Console.WriteLine();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Ex. 4
            bool flag = true;
            List<string> result = [];
            string? input = Console.ReadLine();
            input = input!.Remove(input.IndexOf("create", StringComparison.OrdinalIgnoreCase), 6);
            List<string> items = [.. input.Split(',', ' ')];
            items.Remove("");
            ListyIterator<string> listyIterator = new(items);
            while (flag)
            {
                input = Console.ReadLine();
                switch (input!.ToLower())
                {
                    case "hasnext":
                        {
                            result.Add(listyIterator.HasNext().ToString());
                        }
                        break;
                    case "move":
                        {
                            result.Add(listyIterator.Move().ToString());
                        }
                        break;
                    case "print":
                        {
                            result.Add(listyIterator.Print()!);
                        }
                        break;
                    case "printall":
                        {
                            result.Add(listyIterator.PrintAll()!);
                        }
                        break;
                    case "end":
                        {
                            flag = false;
                        }
                        break;
                }
            }
            Console.WriteLine();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            #endregion

            Console.ReadKey(true);
        }
    }

    public class Book(string? title, int year, params string[] authors)
    {
        public string? Title { get; private set; } = title;
        public int Year { get; private set; } = year;
        public IReadOnlyList<string> Authors { get; private set; } = authors;
    }

    public class Library(params Book[] books) : IEnumerable<Book>
    {
        private readonly List<Book> books = [.. books];

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

    public class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> _books;
        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books)
        {
            Reset();
            _books = [.. books];
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MoveNext() => ++currentIndex < _books.Count;
        public void Reset() => currentIndex = -1;
        public Book Current => _books[currentIndex];

        object IEnumerator.Current => Current;
    }

    public class ListyIterator<T>(IEnumerable<T> collection) : IEnumerable<T>
    {
        private readonly List<T> elements = [.. collection];
        private int index = 0;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                yield return elements[i]; 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return index < elements.Count - 1;
        }

        public string? Print()
        {
            if (elements.Count == 0)
            {
                return "Invalid Operation!";
            }
            else
            {

                return elements[index]!.ToString();
            }
        }

        public string? PrintAll()
        {
            string? result = "";
            if (elements.Count == 0)
            {
                return "Invalid Operation!";
            }
            else
            {
                IEnumerator<T> enumerator = GetEnumerator();
                while (enumerator.MoveNext())
                {
                    result += enumerator.Current + " ";
                }
                _ = result.TrimEnd(' ');
                return result;
            }
        }
    }
}