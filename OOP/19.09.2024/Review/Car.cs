using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review
{
    internal class Car
    {
        // Fields
        private string? _brand;
        private string? _model;
        private int _yearOfManufacture;
        private static int _totalCount = 0;


        // Properties
        public string Brand
        {
            get
            {
                return _brand!;
            }
            set
            {
                if (value != null)
                {
                    _brand = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid name for brand: ");
                        value = Console.ReadLine()!;
                        if (value != null)
                        {
                            _brand = value;
                            break;
                        }
                    }
                }
            }
        }

        public string Model
        {
            get
            {
                return _model!;
            }
            set
            {
                if (value != null)
                {
                    _model = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid name for model: ");
                        value = Console.ReadLine()!;
                        if (value != null)
                        {
                            _model = value;
                            break;
                        }
                    }
                }
            }
        }

        public int YearOfManufacture
        {
            get
            {
                return _yearOfManufacture;
            }
            set
            {
                if (value.ToString() != null)
                {
                    _yearOfManufacture = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid date of manufacture: ");
                        value = int.Parse(Console.ReadLine()!);
                        if (value.ToString() != null)
                        {
                            _yearOfManufacture = value;
                            break;
                        }
                    }
                }
            }
        }

        public static int TotalCount { get => _totalCount; }
        
        // Constructors
        public Car()
        {
            _totalCount++;
        }
        public Car(string? brand, string? model, int yearOfManufacture)
        :this()
        {
            Brand = brand!;
            Model = model!;
            YearOfManufacture = yearOfManufacture;
        }

        // Methods
        public void CarInfo()
        {
            Console.WriteLine($"Car brand: {_brand}; Car model: {_model}; Car year of manufacture: {this._yearOfManufacture}; Car age: {CarAge()}");
        }

        public int CarAge()
        {
            return DateTime.Now.Year - this._yearOfManufacture;
        }

        public static void CarComparison(Car car1, Car car2)
        {
            if (car1.CarAge() > car2.CarAge())
            {
                car1.CarInfo();
            }
            else
            {
                car2.CarInfo();
            }
        }
    }
}
