using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_2
{
    internal class Person
    {
        // Properties
        public string? Name { get; set; }
        public string? EGN { get; set; }
        public short Age { get; set; }

        // Cosntructors
        public Person()
        {
            Name = "No name";
            EGN = "No EGN";
            Age = 0;
        }
        public Person(string? name)
            : this()
        {
            Name = name;
        }
        public Person(string? name, string? egn)
            : this(name)
        {
            EGN = egn;
        }
        public Person(string? name, string? egn, short age)
            : this(name, egn)
        {
            Age = age;
        }

        // Methods
        public virtual void Input()
        {
            Console.Write("Name: ");
            Name = Console.ReadLine();

            Console.Write("EGN: ");
            EGN = Console.ReadLine();

            Console.Write("Age: ");
            Age = Convert.ToInt16(Console.ReadLine());
        }

        public virtual void Print()
        {
            Console.WriteLine($"Name: {Name}\nEGN: {EGN}\nAge: {Age}");
        }

    }
}
