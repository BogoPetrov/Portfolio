using TransportCost.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCost.Controller
{
    internal class TransportController
    {
        // Fields
        private readonly TransportModel _transportModel = new();

        // Constructors
        public TransportController()
        {
            Input();
            Run();
        }

        // Methods
        public void Input()
        {
            Console.Write("Enter how much kilometers you want to travel: ");
            _transportModel.Distance = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter when would you want to travel (day or night): ");
            _transportModel.Time = Console.ReadLine();
        }

        public void Run()
        {
            double[] costs =
            [
                _transportModel.Time switch
                {
                    "day" => Math.Round(_transportModel.Distance * TransportModel.TaxiDayCost + TransportModel.TaxiStartCost, 2),
                    "night" => Math.Round(_transportModel.Distance * TransportModel.TaxiNightCost + TransportModel.TaxiStartCost, 2),
                    _ => 0
                },
                _transportModel.Distance switch
                {
                    >= 20 => Math.Round(_transportModel.Distance * TransportModel.BusCost, 2),
                    _ => 0
                },
                _transportModel.Distance switch
                {
                    >= 100 => Math.Round(_transportModel.Distance * TransportModel.TrainCost, 2),
                    _ => 0
                },
            ];

            Output(costs);
        }

        public static void Output(double[] costs = null!)
        {
            double minCost = costs[0];
            for (int i = 1; i < costs.Length; i++)
            {
                if (costs[i] != 0)
                {
                    if (minCost > costs[i])
                    {
                        minCost = costs[i];
                    }
                }
            }
            Console.WriteLine($"The journey costs: {minCost}");
        }
    }
}
