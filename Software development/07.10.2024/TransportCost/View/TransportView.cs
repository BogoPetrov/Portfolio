using TransportCost.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCost.View
{
    internal static class TransportView
    {
        public static void Start()
        {
            _ = new TransportController();
        }
    }
}
