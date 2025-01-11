using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Tire
    {
        // Fields
        private int _year;
        private double _pressure;

        // Properties
        public int Year { get => _year; set => _year = value; }
        public double Pressure { get => _pressure; set => _pressure = value; }

        // Constructors
        public Tire(int year, double pressure)
        {
            _pressure = pressure;
            _year = year;
        }
    }
}
