using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_2
{
    internal class Employee : Person
    {
        // Properties
        public double Salary { get; set; }

        // Constructors
        public Employee() : base()
        {
            Salary = 0.0;
        }
        public Employee(double salary) : base()
        {
            Salary = salary;
        }

        // Methods
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Slary: {Salary}");
        }

        public override void Input()
        {
            base.Input();

            Console.Write("Salary: ");
            Salary = Convert.ToDouble(Console.ReadLine());
        }
    }
}
