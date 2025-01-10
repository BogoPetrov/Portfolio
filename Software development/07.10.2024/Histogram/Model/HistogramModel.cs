using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram.Model
{
    internal class HistogramModel
    {
        // Field
        private List<int> _digits = [];

        // Property
        public List<int> Digits { get => _digits; set => _digits = value; }
    }
}
