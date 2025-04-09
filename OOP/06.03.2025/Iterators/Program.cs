namespace Iterators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }
        public double Price { get; set; }

        public Book(string title, string author, int yearPublished, double price)
        {
            Title = title;
            Author = author;
            YearPublished = yearPublished;
            Price = price;
        }
    }

    public class BookList : IEnumerable<Book>
    {
        private List<Book> _books = new List<Book>();

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new BookEnumerator(_books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class BookEnumerator : IEnumerator<Book>
        {
            private List<Book> _books;
            private int _currentIndex = -1;

            public BookEnumerator(List<Book> books)
            {
                _books = books;
            }

            public Book Current
            {
                get { return _books[_currentIndex]; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                _currentIndex++;
                return _currentIndex < _books.Count;
            }

            public void Reset()
            {
                _currentIndex = -1;
            }

            public void Dispose()
            {
                // Not implemented
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            BookList bookList = new BookList();

            // Adding some books to the list
            bookList.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, 9.99));
            bookList.Add(new Book("To Kill a Mockingbird", "Harper Lee", 1960, 8.99));
            bookList.Add(new Book("1984", "George Orwell", 1949, 7.99));

            // Using the custom BookEnumerator to perform an action on each book in the list
            foreach (Book book in bookList)
            {
                Console.WriteLine("The book '{0}' by {1} was published in {2}.", book.Title, book.Author, book.YearPublished);
            }

            Console.ReadKey(true);
        }
    }
}