using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_1
{
    internal class Person
    {
        // Fields
        private string? _name;
        private short _age;

        // Properties
        public string? Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != "")
                {
                    _name = value;
                    
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter a valid name: ");
                        value = Console.ReadLine()!;
                        if (value != "")
                        {
                            _name = value;
                            break;
                        }
                    }
                }
            }
        }
        public short Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value > 0)
                {
                    _age = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter a valid age: ");
                        try
                        {
                            value = short.Parse(Console.ReadLine()!);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                        if (value > 0)
                        {
                            _age = value;
                            break;
                        }
                    }
                }
            }
        }

        // Constructors
        public Person() { }

        public Person(string? name, short age)
        {
            Name = name;
            Age = age;
        }
    }
}
