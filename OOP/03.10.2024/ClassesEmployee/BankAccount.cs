using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesEmployee
{
    public class BankAccount
    {
        // Fields
        private string? _accountNumber;
        private string? _ownerName;
        private decimal _accountBalance;

        // Properties
        public string? AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public string? OwnerName { get => _ownerName; set => _ownerName = value; }
        public decimal AccountBalance { get => _accountBalance; set => _accountBalance = value; }

        // Constructors
        public BankAccount()
        {
            _accountNumber = "Null";
            _ownerName = "No name";
            _accountBalance = 0;
        }

        public BankAccount(string? accountNumber)
        {
            _accountNumber = accountNumber;
        }

        public BankAccount(string? accountNumber, string? ownerName)
            : this(accountNumber)
        {
            _ownerName = ownerName;
        }

        public BankAccount(string? accountNumber, string? ownerName, decimal accountBalance)
            : this(accountNumber, ownerName)
        {
            _accountBalance = accountBalance;
        }

        // Methods
        public void MakeDeposit(decimal amount)
        {
            _accountBalance += amount;
            Console.WriteLine($"Account balance: {_accountBalance}");
        }

        public void MakeWithdrawal(decimal amount)
        {
            if (_accountBalance >= amount)
            {
                _accountBalance -= amount;
                Console.WriteLine($"Withdrawn funds: {amount}. Funds available on the account: {_accountBalance}");
            }
            else
            {
                Console.WriteLine("Non-Sufficient Funds");
            }
        }
    }
}
