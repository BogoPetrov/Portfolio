using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexators_Exercise
{
    internal class ParkingMachine
    {
        // Static fields
        protected readonly Random random = new();

        // Fields
        protected double _time;
        protected double _price;
        protected int _numberOfVehicle;

        // Indexator
        public virtual double this[int index]
        {
            get
            {
                return index switch
                {
                    0 => _numberOfVehicle = random.Next(1000, 5000),
                    1 => _time = random.Next(30, 180),
                    2 => _price = Math.Round(_time / 60.0 * 3, 2),
                    _ => throw new IndexOutOfRangeException(),
                };
            }
            set
            {
                switch (index)
                {
                    case 0:
                        _numberOfVehicle = (int)value;
                        break;
                    case 1:
                        _time = value;
                        break;
                    case 2:
                        _price = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
    }
}
