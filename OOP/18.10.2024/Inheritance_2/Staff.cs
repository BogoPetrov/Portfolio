using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_2
{
    internal class Staff : Employee
    {
        // Properties
        public string? Position { get; set; }

        // Constructors
        public Staff() : base()
        {
            Position = string.Empty;
        }
        public Staff(string? position) : base()
        {
            Position = position;
        }

        // Methods
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Position: {Position}");
        }

        public override void Input()
        {
            base.Input();

            Console.Write("Position: ");
            Position = Console.ReadLine();
        }
    }
}
