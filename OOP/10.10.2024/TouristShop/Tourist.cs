using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristShop
{
    internal class Tourist
    {
        // Fields
        private double _balance;
        private List<double> _productsPrice = [];
        private List<string> _productsName = [];

        // Properties
        public double Balance
        {
            get => _balance;
            set
            {
                if (value >= 1.0 && value <= 100000.0)
                {
                    _balance = value;
                }
                else
                {
                    while (value < 1.0 || value > 100000.0)
                    {
                        Console.Write("Enter a value between 1.0 and 100000.0: ");
                        value = Convert.ToDouble(Console.ReadLine());
                    }
                }
            }
        }

        // Methods
        public void Shopping()
        {
            int i = 0;
            string? input = "";
            while (!input!.Equals("Stop", StringComparison.OrdinalIgnoreCase))
            {
                input = Console.ReadLine();
                if (i % 2 == 0 && !input!.Equals("Stop", StringComparison.OrdinalIgnoreCase))
                {
                    _productsName.Add(input!);
                }
                else if (i % 2 != 0 && !input!.Equals("Stop", StringComparison.OrdinalIgnoreCase))
                {
                    _productsPrice.Add(Convert.ToDouble(input!));
                    CalculateBill();
                    if (_balance < 0)
                    {
                        return;
                    }
                }
                i++;
            }

            CalculateBill(0);
        }

        private void CalculateBill(int end = -1)
        {
            double bill = 0.0;
            for (int i = 1; i <= _productsPrice.Count; i++)
            {
                if (i % 3 == 0)
                {
                    bill += _productsPrice[i - 1] / 2;
                }
                else
                {
                    bill += _productsPrice[i - 1];
                }
            }

            if (end == -1)
            {
                _balance -= bill;
                if (_balance < 0)
                {
                    Console.WriteLine($"You don't have enough money! You need {Math.Abs(_balance)} leva!");
                    return;
                }
                _balance += bill;
            }
            else
            {
                Console.WriteLine($"You bought {_productsPrice.Count} products for {Math.Round(bill, 2)} leva.");
                return;
            }
        }
    }
}
