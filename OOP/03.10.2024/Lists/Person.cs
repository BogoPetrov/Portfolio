using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    internal class Person
    {
        // Fields
        private string? _name;
        private int _age;

        // Properties
        public string? Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }

        // Constructors
        public Person()
        {
            _name = "";
            _age = 0;
        }
        public Person(string? name)
            : this()
        {
            _name = name;
        }
        public Person(string? name, int age)
            : this(name)
        {
            _age = age;
        }
    }
}
