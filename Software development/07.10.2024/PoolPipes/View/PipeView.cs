using PoolPipes.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolPipes.View
{
    internal static class PipeView
    {
        public static void Start()
        {
            _ = new PipeController();
        }
    }
}
