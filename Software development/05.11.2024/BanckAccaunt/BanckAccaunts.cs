using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanckAccaunt
{
    public class BanckAccaunts
    {
        public static int Balance { get; set; }

        static void Main(string[] args)
        {
        }

        public static int Deposid(int amout)
        {
            if (amout > 0)
            {
                Balance += amout; 
                return Balance;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid amout to add!");
            }
        }

        public static int Withdraw(int amout)
        {
            if (Balance > 0)
            {
                Balance -= amout;
                return Balance;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid amout to withdraw!");
            }
        }

        public static bool Check()
        {
            if (Balance > 0)
            {
                Console.WriteLine($"The current balance is: {Balance}");
                return true;
            }
            else
            {
                return false;
                throw new ArgumentOutOfRangeException("Invalid amout in the balance!");
            }
        }
    }
}
