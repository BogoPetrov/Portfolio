using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMVC.Model;

namespace ConsoleMVC.Views
{
    internal class Display
    {
        // Properties
        public double Total { get; set; }

        public double TipAmount { get; set; }

        // Constructor
        public Display()
        {
            Total = 0;
            TipAmount = 0;
        }

        //Methods
        public void ShowTipandTotal()
        {
            Console.WriteLine($"Your tip is {TipAmount:C}");
            Console.WriteLine($"The total will be {Total:C}");
        }
    }
}
