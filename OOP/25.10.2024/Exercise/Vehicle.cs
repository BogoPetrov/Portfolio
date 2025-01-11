using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Vehicle
    {
        // Fields
        private protected int _wheelsCount;
        private protected int _passangersCount;
        private protected double _speed;
        private protected string? _model;
        private protected string? _color;

        public int WheelsCount { get => _wheelsCount; set => _wheelsCount = value; }
        public int PassangersCount { get => _passangersCount; set => _passangersCount = value; }
        public double Speed { get => _speed; set => _speed = value; }
        public string? Model { get => _model; set => _model = value; }
        public string? Color { get => _color; set => _color = value; }

        // Methods
        public override string ToString()
        {
            string res = $"The model of the vehicle is: {_model}" +
                $"\nWheels count: {_wheelsCount}" +
                $"\nPassangers count: {_passangersCount}" +
                $"\nSpeed: {_speed}" +
                $"\nModel: {_model}" +
                $"\nColor: {_color}";

            return res;
        }
    }
}
