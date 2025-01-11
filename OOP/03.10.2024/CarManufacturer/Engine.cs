using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Engine
    {
        // Fields
        private int _horsePower;
        private double _cubicCentimeters;

        // Properties
        public int HorsePower { get => _horsePower; set => _horsePower = value; }
        public double CubicCentimeters { get => _cubicCentimeters; set => _cubicCentimeters = value; }

        // Constructors
        public Engine(int horsePower, double cubicCentimeters)
        {
            _horsePower = horsePower;
            _cubicCentimeters = cubicCentimeters;
        }
    }
}
