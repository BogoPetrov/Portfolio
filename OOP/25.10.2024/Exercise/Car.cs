using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Car : Vehicle
    {
        // Methods
        public override string ToString()
        {
            return base.ToString().Replace("vehicle", "car");
        }
    }
}
