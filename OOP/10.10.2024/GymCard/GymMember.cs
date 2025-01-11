using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCard
{
    internal class GymMember
    {
        private static readonly Dictionary<string, double> dataForMen = new()
        {
            {"gym", 42.0},
            {"boxing", 41.0},
            {"yoga", 45.0},
            {"zumba", 34.0},
            {"dances", 51.0},
            {"pilates", 39.0}
        };

        private static readonly Dictionary<string, double> dataForWomen = new()
        {
            {"gym", 35.0},
            {"boxing", 37.0},
            {"yoga", 42.0},
            {"zumba", 31.0},
            {"dances", 53.0},
            {"pilates", 37.0}
        };

        // Fields
        private double _amount;
        private char? _gender;
        private byte _age;
        private string? _selectSport;

        // Properties
        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value >= 10.0 && value <= 1000.0)
                {
                    _amount = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid amount: ");
                        value = Convert.ToDouble(Console.ReadLine());
                        if (value >= 10.0 && value <= 1000.0)
                        {
                            _amount = value;
                            break;
                        }
                    }
                }
            }
        }
        public char? Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                if (value == 'm' || value == 'f')
                {
                    _gender = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid gender: ");
                        value = Console.ReadLine()!.ToLower()[0];
                        if (value == 'm' || value == 'f')
                        {
                            _gender = value;
                            break;
                        }
                    }
                }
            }
        }
        public byte Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value >= 5 && value <= 105)
                {
                    _age = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid age: ");
                        value = Convert.ToByte(Console.ReadLine());
                        if (value >= 5 && value <= 105)
                        {
                            _age = value;
                            break;
                        }
                    }
                }
            }
        }
        public string? SelectSport
        {
            get
            {
                return _selectSport;
            }
            set
            {
                if (dataForMen.ContainsKey(value!.ToLower()))
                {
                    _selectSport = value.ToLower();
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter correct sport: ");
                        value = Console.ReadLine();
                        if (dataForMen.ContainsKey(value!.ToLower()))
                        {
                            _selectSport = value.ToLower();
                            break;
                        }
                    }
                }
            }
        }

        // Methods
        public void BuyACard()
        {
            switch (Gender)
            {
                case 'm':
                    if (Age <= 19)
                    {
                        double price = dataForMen!.GetValueOrDefault(SelectSport) - (dataForMen!.GetValueOrDefault(SelectSport) * 0.2);
                        if (Amount >= price)
                        {
                            Console.WriteLine($"You purchased a 1 month pass for {SelectSport}."); 
                        }
                        else
                        {
                            Console.WriteLine($"You don't have enough money! You need ${Math.Round(price - Amount, 2):0.00} more.");
                        }
                    }
                    else
                    {
                        double price = dataForMen!.GetValueOrDefault(SelectSport);
                        if (Amount >= price)
                        {
                            Console.WriteLine($"You purchased a 1 month pass for {SelectSport}.");
                        }
                        else
                        {
                            Console.WriteLine($"You don't have enough money! You need ${Math.Round(price - Amount, 2):0.00} more.");
                        }
                    }
                    break;
                case 'f':
                    if (Age <= 19)
                    {
                        double price = dataForWomen!.GetValueOrDefault(SelectSport) - (dataForWomen!.GetValueOrDefault(SelectSport) * 0.2);
                        if (Amount >= price)
                        {
                            Console.WriteLine($"You purchased a 1 month pass for {SelectSport}.");
                        }
                        else
                        {
                            Console.WriteLine($"You don't have enough money! You need ${Math.Round(price - Amount, 2):0.00} more.");
                        }
                    }
                    else
                    {
                        double price = dataForWomen!.GetValueOrDefault(SelectSport);
                        if (Amount >= price)
                        {
                            Console.WriteLine($"You purchased a 1 month pass for {SelectSport}.");
                        }
                        else
                        {
                            Console.WriteLine($"You don't have enough money! You need ${Math.Round(price - Amount, 2):0.00} more.");
                        }
                    }
                    break;
            }
        }
    }
}
