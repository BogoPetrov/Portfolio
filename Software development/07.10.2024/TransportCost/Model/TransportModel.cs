using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCost.Model
{
    internal class TransportModel
    {
        // Static Fields
        public static readonly double TaxiStartCost = 0.70;
        public static readonly double TaxiDayCost = 0.79;
        public static readonly double TaxiNightCost = 0.90;
        public static readonly double BusCost = 0.09;
        public static readonly double TrainCost = 0.06;

        // Fields
        private int _distance;
        private string? _time;

        // Property
        public int Distance
        {
            get
            {
                return _distance;
            }
            set
            {
                if (value >= 1 && value <= 5000)
                {
                    _distance = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter count of km between 1 and 5000");
                        value = Convert.ToInt32(Console.ReadLine());
                        if (value >= 1 && value <= 5000)
                        {
                            _distance = value;
                            break;
                        }
                    }
                }
            }
        }
        public string? Time
        {
            get
            {
                return _time;
            }
            set
            {
                if (value!.Equals("day", StringComparison.OrdinalIgnoreCase) || value.Equals("night", StringComparison.OrdinalIgnoreCase))
                {
                    _time = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid time (day or night): ");
                        value = Console.ReadLine();
                        if (value!.Equals("day", StringComparison.OrdinalIgnoreCase) || value.Equals("night", StringComparison.OrdinalIgnoreCase))
                        {
                            _time = value;
                            break;
                        }
                    }
                }
            }
        }

    }
}
