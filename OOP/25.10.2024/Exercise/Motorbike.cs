using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Motorbike : Vehicle
    {
        
        // Methods
        public override string ToString()
        {
            return base.ToString().Replace("vehicle", "motorbike");
        }
    }
}
