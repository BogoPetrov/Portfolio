using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lock_Ex
{
    internal class Accaunt
    {
        // Fields
        private int _bankBalance;

        // Properties
        public int BankBalance { get => _bankBalance; set => _bankBalance = value; }

        // Methods
        public void Deposit(int amount)
        {
            lock (this)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (amount > 0)
                    {
                        Console.WriteLine($"Depositing {amount}");
                        _bankBalance += amount;
                        Console.WriteLine($"Current balance: {_bankBalance}");
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("The amount must be positive");
                    } 
                }
            }
        }

        public void Withdraw(int amount)
        {
            lock (this)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_bankBalance >= amount && amount > 0)
                    {
                        Console.WriteLine($"Withdrawing {amount}");
                        _bankBalance -= amount;
                        Console.WriteLine($"Current balance: {_bankBalance}");
                    }
                    else if (_bankBalance < amount)
                    {
                        throw new ArgumentOutOfRangeException("Not enough money!");
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("The amount must be positive and less than the balance!");
                    } 
                }
            }
        }
    }
}
