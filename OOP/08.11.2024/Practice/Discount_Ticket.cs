using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Discount_Ticket : Ticket
    {
        public Discount_Ticket() : base() { }
        public Discount_Ticket(string? name, int age) : base(name, age) { }

        public override decimal? GetPrice()
        {
            decimal? price = _age switch
            {
                < 20 => base.GetPrice() * 0.5m,
                >= 60 => base.GetPrice() * 0.5m,
                _ => base.GetPrice()
            };
            return price;
        }

        public override string? GetTicketInfo()
        {
            return $"Customer name: {_name}\nAge: {_age}\nPerformance to watch: {PerformanceName}\nPrice: {GetPrice()}";
        }
    }
}
