using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Account
    {
        // Fields
        private int _accountNumber;
        private int _customerId;
        private double _balance;
        private CurrencyType _currencyType;

        // Properties
        public int AccountNumber
        {
            get
            {
                return _accountNumber;
            }
            set
            {
                _accountNumber = value;
            }
        }
        public int CustomerId
        {
            get
            {
                return _customerId;
            }
            set
            {
                _customerId = value;
            }
        }
        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (value >= 0)
                {
                    _balance = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid balance: ");
                        value = double.Parse(Console.ReadLine()!);
                        if (value >= 0)
                        {
                            _balance = value;
                            break;
                        }
                    }
                }
            }
        }
        public CurrencyType CurrencyType
        {
            get
            {
                return _currencyType;
            }
            set
            {
                _currencyType = value;
            }
        }

        // Constructors
        public Account() { }
        public Account(int customerId, double balance, CurrencyType currencyType)
        {
            this.CustomerId = customerId;
            this.Balance = balance;
            this.CurrencyType = currencyType;
        }
        public Account(int accountNumber, int customerId, double balance, CurrencyType currencyType)
        : this(customerId, balance, currencyType)
        {
            this.AccountNumber = accountNumber;
        }

    }

    public enum CurrencyType
    {
        Lev,
        USD,
        Euro
    }
}
