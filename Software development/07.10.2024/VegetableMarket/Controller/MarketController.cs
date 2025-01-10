using VegetableMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableMarket.Controller
{
    internal class MarketController
    {
        // Fields
        private readonly MarketModel _marketModel = new();

        // Constructors
        public MarketController()
        {
            Input();
            RunLogicAndOutput();
        }

        // Methods
        public void Input()
        {
            Console.Write("Enter how much cost the kg of vegetables: ");
            _marketModel.VegCost = decimal.Parse(Console.ReadLine()!);

            Console.Write("Enter how much cost the kg of fruits: ");
            _marketModel.FrutCost = decimal.Parse(Console.ReadLine()!);

            Console.Write("Enter how much kg of vegetables you want to buy: ");
            _marketModel.VegKg = int.Parse(Console.ReadLine()!);

            Console.Write("Enter how much kg of fruits you want to buy: ");
            _marketModel.FrutKg = int.Parse(Console.ReadLine()!);

            Console.WriteLine();
        }

        public void RunLogicAndOutput()
        {
            decimal calulation = ((_marketModel.VegCost * _marketModel.VegKg) + (_marketModel.FrutCost * _marketModel.FrutKg)) / 1.94M;
            Console.WriteLine(calulation);
        }
    }
}
