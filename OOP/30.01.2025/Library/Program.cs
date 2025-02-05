namespace Library
{
    public class Program
    {
        static void Main(string[] args)
        {
            StudentReaders studentReader = new();
            RegularReaders regularReader = new();

            Book_Romance RomanceBooks = new();
            Book_Crime CrimeBooks = new();

            RomanceBooks.AddToCollection("Romance", "Pride and Prejudice");
            RomanceBooks.AddToCollection("Romance", "Wuthering Heights");
            Console.WriteLine("----------------------");

            PrintCollection(Book_Romance.RomanceSection);

            studentReader.TakeBook(Book_Romance.RomanceSection!.Find(book => book.Title!.Equals("Pride and Prejudice", StringComparison.OrdinalIgnoreCase)));

            PrintCollection(Book_Romance.RomanceSection);

            CrimeBooks.AddToCollection("Crime", "The house on the lake");
            CrimeBooks.AddToCollection("Crime", "Strike back");
            Console.WriteLine("----------------------");

            PrintCollection(Book_Crime.CrimeSection);

            regularReader.TakeBook(Book_Crime.CrimeSection!.Find(book => book.Title!.Equals("The house on the lake", StringComparison.OrdinalIgnoreCase)));

            PrintCollection(Book_Crime.CrimeSection);

            Console.WriteLine("END OF THE PROGRAM");

            Console.ReadKey(true);
        }

        public static void PrintCollection(List<ILibrary>? collection)
        {
            if (collection != null && collection.Count > 0)
            {
                Console.WriteLine($"There are the following books in {collection![0].Ganre} collection: ");
                for (int i = 0; i < collection.Count; i++)
                {
                    Console.WriteLine(collection[i].Title);
                }
                Console.WriteLine("----------------------");
            }
            else if (collection!.Count == 0)
            {
                Console.WriteLine("There are no books in the collection.");
                Console.WriteLine("----------------------");
            }
            else
            {
                Console.WriteLine("Collection is null.");
                return;
            }
        }
    }

    public interface ILibrary
    {
        public string? Title { get; set; }
        public string? Ganre { get; set; }
        public void AddToCollection(string? ganre, string? title = "");
    }

    public class Book_Romance : ILibrary
    {
        public static List<ILibrary>? RomanceSection { get; set; } = [];

        public string? Title { get; set; }
        public string? Ganre { get; set; }

        public void AddToCollection(string? ganre, string? title)
        {
            if (ganre!.Equals("Romance", StringComparison.OrdinalIgnoreCase))
            {
                Book_Romance newBook = new()
                {
                    Title = title,
                    Ganre = ganre
                };
                RomanceSection!.Add(newBook);
                Console.WriteLine($"Adding {newBook.Title} to Romance section.");
            }
        }
    }

    public class Book_Crime : ILibrary
    {
        public static List<ILibrary>? CrimeSection { get; set; } = [];

        public string? Title { get; set; }
        public string? Ganre { get; set; }

        public void AddToCollection(string? ganre, string? title = "")
        {
            if (ganre!.Equals("Crime", StringComparison.OrdinalIgnoreCase))
            {
                Book_Crime newBook = new()
                {
                    Title = title,
                    Ganre = ganre
                };
                CrimeSection?.Add(newBook);
                Console.WriteLine($"Adding {newBook.Title} to Crime section.");
            }
        }
    }

    public abstract class Readers
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }

        public abstract void TakeBook(ILibrary? book);
    }

    public class StudentReaders : Readers
    {
        public override void TakeBook(ILibrary? book)
        {
            Console.WriteLine("Student reader takes a book.");
            Console.WriteLine($"Book {book!.Title} has been removed from the {book!.Ganre!.ToUpper()} collection.");
            Console.WriteLine("----------------------");
            switch (book!.Ganre!.ToLower())
            {
                case "romance":
                    Book_Romance.RomanceSection!.Remove((book as Book_Romance)!);
                    break;
                case "crime":
                    Book_Crime.CrimeSection!.Remove((book as Book_Crime)!);
                    break;
            }
        }
    }

    public class RegularReaders : Readers
    {
        public override void TakeBook(ILibrary? book)
        {
            Console.WriteLine("Regular reader takes a book.");
            Console.WriteLine($"Book {book!.Title} has been removed from the {book!.Ganre!.ToUpper()} collection.");
            Console.WriteLine("----------------------");
            switch (book!.Ganre!.ToLower())
            {
                case "romance":
                    Book_Romance.RomanceSection!.Remove((book as Book_Romance)!);
                    break;
                case "crime":
                    Book_Crime.CrimeSection!.Remove((book as Book_Crime)!);
                    break;
            }
        }
    }
}