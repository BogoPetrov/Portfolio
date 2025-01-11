using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        // Fileds
        private string? _mark;
        private string? _model;
        private int _year;
        private double _fuelQuantity;
        private double _fuelConsumption;
        private Engine? _engine;
        private Tire[] _tires = new Tire[4];

        // Properties
        public string? Make { get => _mark; set => _mark = value; }
        public string? Model { get => _model; set => _model = value; }
        public int Year { get => _year; set => _year = value; }
        public double FuelQuantity { get => _fuelQuantity; set => _fuelQuantity = value; }
        public double FuelConsumption { get => _fuelConsumption; set => _fuelConsumption = value; }
        public Engine? Engine { get => _engine; set => _engine = value; }
        public Tire[] Tires { get => _tires; set => _tires = value; }

        // Constructors
        public Car()
        {
            _mark = "VW";
            _model = "Golf";
            _year = 2025;
            _fuelQuantity = 200;
            _fuelConsumption = 10;
        }

        public Car(string? mark, string? model, int year)
        {
            _mark = mark;
            _model = model;
            _year = year;
        }

        public Car(string? mark, string? model, int year, double fuelQuantity, double fuelConsumption)
            : this(mark, model, year)
        {
            _fuelQuantity = fuelQuantity;
            _fuelConsumption = fuelConsumption;
        }
        
        public Car(string? mark, string? model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(mark, model, year, fuelQuantity, fuelConsumption)
        {
            _engine = engine;
            _tires = tires;
        }



        // Methods
        public void Drive(double distance)
        {
            if (_fuelQuantity - distance * _fuelConsumption >= 0)
            {
                Console.WriteLine($"Liters of fuel consumed on this trip is: {distance * _fuelConsumption}");
                _fuelQuantity -= distance * _fuelConsumption;
                Console.WriteLine($"The fuel left is: {_fuelQuantity}");
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }

        }

        public string WhoAmI()
        {
            return $"Make: {_mark}\nModel: {_model}\nYear: {_year}\nFuel: {_fuelQuantity}";
        }
    }
}
