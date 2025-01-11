using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage
{
    internal class Storage
    {
        private readonly List<Book> _books = [];
        private readonly Dictionary<string, int> _soldBooks = [];
        private double totalPrice;

        public void AddBook(int position = -1)
        {
            Book book = new();
            if (position == -1)
            {
                Console.Write("Enter book title: ");
                book.Title = Console.ReadLine();

                Console.Write("Enter book author: ");
                book.Author = Console.ReadLine();

                Console.Write("Enter book price: ");
                book.Price = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter book count: ");
                book.Count = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
            }
            else
            {
                Console.Write($"Enter {position + 1}'s book title: ");
                book.Title = Console.ReadLine();

                Console.Write($"Enter {position + 1}'s book author: ");
                book.Author = Console.ReadLine();

                Console.Write($"Enter {position + 1}'s book price: ");
                book.Price = Convert.ToDouble(Console.ReadLine());

                Console.Write($"Enter {position + 1}'s book count: ");
                book.Count = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
            }

            _books.Add(book);
            _soldBooks.Add(book.Title!, 0);
        }

        public void SellBook(int position = -1)
        {
            string? title = " ";
            int count = 0;
            if (position == -1)
            {
                Console.Write("Enter book title: ");
                title = Console.ReadLine();

                Console.Write("Enter book count: ");
                count = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.Write($"Enter {position + 1}'s book title: ");
                title = Console.ReadLine();

                Console.Write($"Enter {position + 1} book count: ");
                count = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Title!.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    if (_books[i].Count >= count)
                    {
                        SellSelected(_books[i], ref count, ref i);
                    }
                    else
                    {
                        Console.WriteLine($"Not enought books! The count of this book is {_books[i].Count}");
                        while (count > _books[i].Count)
                        {
                            Console.Write("Enter valid count for bying: ");
                            count = Convert.ToInt32(Console.ReadLine());
                        }
                        SellSelected(_books[i], ref count, ref i);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Book not found!");
                }
            }
        }

        private void SellSelected(Book book, ref int count, ref int position)
        {
            if (book.Count == count)
            {
                _soldBooks[book.Title!] += count;
                _books.RemoveAt(position);
            }
            else
            {
                _soldBooks[book.Title!] += count;
                _books[position].Count -= count;
            }
            double priceWithDDS = Math.Round(book.Price + book.Price * 0.2, 2);
            Console.WriteLine($"Sold {count} books on price {priceWithDDS * count}$");
            totalPrice += priceWithDDS * count;

            Console.WriteLine();
        }

        public void ShowTheMostSoldBook()
        {
            int max = _soldBooks.Values.Max();
            Console.WriteLine($"The most sold book is {_soldBooks.FirstOrDefault(count => count.Value == max).Key}");
        }

        public void ShowTotalPrice()
        {
            Console.WriteLine($"The amout of all sold books is {totalPrice}$");
        }
    }
}
