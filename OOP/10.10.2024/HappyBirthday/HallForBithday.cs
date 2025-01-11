using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyBirthday
{
    internal class HallForBithday
    {
        private double _priceOfHall;

        public double PriceOfHall
        {
            get
            {
                return _priceOfHall;
            }
            set
            {
                if (value >= 100 && value <= 10000)
                {
                    _priceOfHall = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter correct price of hall: ");
                        value = Convert.ToDouble(Console.ReadLine());
                        if (value >= 100 && value <= 10000)
                        {
                            _priceOfHall = value;
                            break;
                        }
                    }
                }
            }
        }

        public HallForBithday()
        {
            PriceOfHall = 101;
        }

        public HallForBithday(double priceOfHall)
        {
            PriceOfHall = priceOfHall;
        }

        public void Print()
        {
            double priceOfCake = (PriceOfHall * 20) / 100;
            double priceOfDrinks = priceOfCake - (priceOfCake * 45) / 100;
            double priceOfAnimator = PriceOfHall * (1 / 3.0);
            double sum = _priceOfHall + priceOfCake + priceOfDrinks + priceOfAnimator;

            Console.WriteLine("Total price: " + sum);
        }
    }
}
