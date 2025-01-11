using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Ticket
    {
        // Fields
        protected string? _name;
        protected readonly int _age;

        // Properties
        public string? PerformanceName { get; set; }
        public decimal Price { get; set; }

        // Constructors
        public Ticket()
        {
            _name = "No name";
            _age = 0;
            PerformanceName = "No performance";
            Price = 0.0m;
        }

        public Ticket(string? name, int age)
        {
            _age = age;
            _name = name;
        }

        // Methods
        public virtual decimal? GetPrice()
        {
            return Price;
        }

        public virtual string? GetTicketInfo()
        {
            return $"Customer name: {_name}\nAge: {_age}\nPerformance to watch: {PerformanceName}\nPrice: {Price}";
        }
    }
}
