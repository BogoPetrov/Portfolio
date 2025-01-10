using Histogram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram.Controller
{
    internal class HistogramController
    {
        // Fields
        private readonly HistogramModel _histogramModel = new();
        private int _lessThan200;
        private int _lessThan400;
        private int _lessThan600;
        private int _lessThan800;
        private int _moreThan800;

        // Constructors
        public HistogramController()
        {
            Input();
            Run();
            Output();
        }

        // Methods
        public void Input()
        {
            Console.Write("Enter how much digets you want input: ");
            int n = int.Parse(Console.ReadLine()!);
            if (n <= 0)
            {
                while (true)
                {
                    Console.Write("Enter valid value: ");
                    n = int.Parse(Console.ReadLine()!);
                    if (n > 0)
                    {
                        break;
                    }
                }
            }

            int number;
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                number = int.Parse(Console.ReadLine()!);

                if (number >= 1 && number <= 1000)
                {
                    _histogramModel.Digits.Add(number);
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid value: ");
                        number = int.Parse(Console.ReadLine()!);

                        if (number >= 1 && number <= 1000)
                        {
                            break;
                        }
                    }

                    _histogramModel.Digits.Add(number);
                }
            }

            Console.WriteLine();
        }

        public void Run()
        {
            for (int i = 0; i < _histogramModel.Digits.Count; i++)
            {
                switch (_histogramModel.Digits[i])
                {
                    case <= 200:
                        _lessThan200++;
                        break;
                    case <= 400:
                        _lessThan400++;
                        break;
                    case <= 600:
                        _lessThan600++;
                        break;
                    case <= 800:
                        _lessThan800++;
                        break;
                    case <= 1000:
                        _moreThan800++;
                        break;
                    default:
                        break;
                }
            }            
        }

        public void Output()
        {
            Console.WriteLine($"{Math.Round(_lessThan200 / (double)_histogramModel.Digits.Count * 100, 2)} %");
            Console.WriteLine($"{Math.Round(_lessThan400 / (double)_histogramModel.Digits.Count * 100, 2)} %");
            Console.WriteLine($"{Math.Round(_lessThan600 / (double)_histogramModel.Digits.Count * 100, 2)} %");
            Console.WriteLine($"{Math.Round(_lessThan800 / (double)_histogramModel.Digits.Count * 100, 2)} %");
            Console.WriteLine($"{Math.Round(_moreThan800 / (double)_histogramModel.Digits.Count * 100, 2)} %");
        }
    }
}
