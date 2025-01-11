using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexators
{
    internal class IndexClass
    {
        private readonly string[] _names = new string[4];
        public string this [int i]
        {
            get
            {
                return _names[i];
            }
            set
            {
                _names[i] = value;
            }
        }
    }
}
