using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesEmployee
{
    public class Employee
    {
        // Fields
        private string? _name;
        private int _age;

        // Properties
        public string? Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }

        // Constructors
        public Employee()
        {
            _name = "No name";
            _age = 1;
        }

        public Employee(int age)
        {
            _name = "No name";
            _age = age;
        }

        public Employee(string? name, int age)
        {
            _name = name;
            _age = age;
        }
    }
}
