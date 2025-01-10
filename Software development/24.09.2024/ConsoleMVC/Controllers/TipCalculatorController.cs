using ConsoleMVC.Model;
using ConsoleMVC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMVC.Controllers
{
    internal class TipCalculatorController
    {
        private Tip _tip;
        private Display _display;


        public TipCalculatorController()
        {
            _display = new Display();
            _tip = new Tip();
            GetValues();
            _display.TipAmount = _tip!.CalculateTip();
            _display.Total = _tip.CalculateTotal();
            Console.WriteLine("------------------------");
            _display.ShowTipandTotal();
        }


        private void GetValues()
        {
            Console.Write("Enter the amount of the meal: ");
            _tip.Amount = double.Parse(Console.ReadLine()!);
            Console.Write("Enter the percent you want to tip: ");
            _tip.Percent = double.Parse(Console.ReadLine()!);
        }

    }
}
