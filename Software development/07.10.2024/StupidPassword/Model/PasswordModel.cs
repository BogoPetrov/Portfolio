using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidPassword.Model
{
    internal class PasswordModel
    {
        // Fields
        private short _n; // the max number value for numbers in password
        private short _l; // the max char value for password
        private List<string> _passwords = [];

        // Properties
        public short N
        {
            get => _n;
            set
            {
                if (value > 0)
                {
                    _n = value;
                }
                else
                {
                    while (value <= 0)
                    {
                        Console.WriteLine("Please enter a valid number: ");
                        value = Convert.ToInt16(Console.ReadLine());
                    }

                    _n = value;
                }
            }
        }

        public short L
        {
            get => _l;
            set
            {
                if (value >= 1 && value < 10)
                {
                    _l = value;
                }
                else
                {
                    while (value < 1 || value >= 10)
                    {
                        Console.WriteLine("Please enter a valid number for selection of characters: ");
                        value = Convert.ToInt16(Console.ReadLine());
                    }

                    _l = value;
                }
            }
        }

        public List<string> Passwords { get => _passwords; set => _passwords = value; }
    }
}
