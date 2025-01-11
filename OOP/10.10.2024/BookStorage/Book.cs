using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage
{
    internal class Book
    {
        // Fields
        private string? _title;
        private string? _author;
        private double _price;
        private int _count;

        // Prperties
        public string? Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    _title = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid title: ");
                        value = Console.ReadLine();

                        if (value != null && value.Length > 0)
                        {
                            _title = value;
                            break;
                        }
                    }
                }
            }
        }
        public string? Author
        {
            get
            {
                return _author;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    _author = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid name of author: ");
                        value = Console.ReadLine();

                        if (value != null && value.Length > 0)
                        {
                            _author = value;
                            break;
                        }
                    }
                }
            }
        }
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid price: ");
                        value = Convert.ToDouble(Console.ReadLine());
                        if (value > 0)
                        {
                            _price = value;
                            break;
                        }
                    }
                }
            }
        }
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value > 0)
                {
                    _count = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid value for count: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        if (value > 0)
                        {
                            _count = value;
                            break;
                        }
                    }
                }
            }
        }
    }
}
