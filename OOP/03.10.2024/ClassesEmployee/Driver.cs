using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Driver
    {
        // Fields
        private string? _name;
        private int _age;
        private double _totalTime;
        private double _speed;

        // Properties
        public string? Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }
        public double TotalTime { get => _totalTime; set => _totalTime = value; }
        public double Speed { get => _speed; set => _speed = value; }

        // Constructors
        public Driver()
        {
            _name = "No name";
            _age = 1;
            _totalTime = 0;
            _speed = 0;
        }

        public Driver(string? name)
        {
            _name = name;
        }

        public Driver(string? name, int age)
            : this(name)
        {
            _age = age;
        }

        public Driver(string? name, int age, double totalTime)
            : this(name, age)
        {
            _totalTime = totalTime;
        }

        public Driver(string? name, int age, double totalTime, double speed)
            : this(name, age, totalTime)
        {
            _speed = speed;
        }
    }
}
