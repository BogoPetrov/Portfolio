using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMVC.Model
{
    internal class Tip
    {
        // Fieds
        private double _amount;
        private double _percent;

        // Properties
        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value >= 0)
                {
                    _amount = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter a valid amount: ");
                        value = double.Parse(Console.ReadLine()!);
                        if (value >= 0)
                        {
                            _amount = value;
                            break;
                        }
                    }
                }
            }
        }

        public double Percent
        {
            get
            {
                return _percent;
            }
            set
            {
                if (value >= 0)
                {
                    value /= 100;
                    _percent = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter a valid percentage: ");
                        value = double.Parse(Console.ReadLine()!);
                        if (value >= 0)
                        {
                            value /= 100;
                            _percent = value;
                            break;
                        }
                    }
                }
            }
        }

        // Constructors
        public Tip(double amount, double percent)
        {
            Amount = amount;
            Percent = percent;
        }
        public Tip() : this(0, 0) { }

        // Methods
        public double CalculateTip()
        {
            return Amount * Percent;
        }

        public double CalculateTotal()
        {
            return CalculateTip() + Amount;
        }

    }
}
