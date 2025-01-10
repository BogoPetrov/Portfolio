using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableMarket.Model
{
    internal class MarketModel
    {
        // Field
        private decimal _vegCost;
        private decimal _frutCost;
        private int _vegKg;
        private int _frutKg;

        // Property
        public decimal VegCost
        {
            get => _vegCost;
            set
            {
                if (value < 0 || value > 1000)
                {
                    while (true)
                    {
                        Console.Write("Enter valid value: ");
                        value = int.Parse(Console.ReadLine()!);
                        if (value >= 0 && value < 1000)
                        {
                            _vegCost = value;
                            break;
                        }
                    }
                }
                else
                {
                    _vegCost = value;
                }
            }
        }
        public decimal FrutCost
        {
            get => _frutCost;
            set
            {
                if (value < 0 || value > 1000)
                {
                    while (true)
                    {
                        Console.Write("Enter valid value: ");
                        value = int.Parse(Console.ReadLine()!);
                        if (value >= 0 && value < 1000)
                        {
                            _frutCost = value;
                            break;
                        }
                    }
                }
                else
                {
                    _frutCost = value;
                }
            }
        }
        public int VegKg
        {
            get => _vegKg;
            set
            {
                if (value < 0 || value > 1000)
                {
                    while (true)
                    {
                        Console.Write("Enter valid value: ");
                        value = int.Parse(Console.ReadLine()!);
                        if (value >= 0 && value < 1000)
                        {
                            _vegKg = value;
                            break;
                        }
                    }
                }
                else
                {
                    _vegKg = value;
                }
            }
        }
        public int FrutKg
        {
            get => _frutKg;
            set
            {
                if (value < 0 || value > 1000)
                {
                    while (true)
                    {
                        Console.Write("Enter valid value: ");
                        value = int.Parse(Console.ReadLine()!);
                        if (value >= 0 && value < 1000)
                        {
                            _frutKg = value;
                            break;
                        }
                    }
                }
                else
                {
                    _frutKg = value;
                }
            }
        }
    }
}
