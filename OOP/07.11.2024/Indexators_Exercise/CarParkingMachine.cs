using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexators_Exercise
{
    internal class CarParkingMachine : ParkingMachine
    {
        public override double this[int index]
        {
            get
            {
                return index switch
                {
                    0 => _numberOfVehicle = random.Next(1000, 5000),
                    1 => _time = random.Next(30, 180),
                    2 => _price = Math.Round(_time / 60.0 * 1.5, 2),
                    _ => throw new IndexOutOfRangeException()
                };
            }
            set
            {
                base[index] = value;
            }
        }
    }
}
