using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Customer
    {
        // Fields
        private int _customerId;
        private string? _name;
        private string? _address;
        private string? _phoneNumber;
        private List<Account> _accounts = [];

        // Properties
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
        public string? Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != "")
                {
                    _name = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid name: ");
                        value = Console.ReadLine();
                        if (value != "")
                        {
                            _name = value;
                            break;
                        }
                    }
                }
            }
        }
        public string? Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (value != "")
                {
                    _address = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid address: ");
                        value = Console.ReadLine();
                        if (value != "")
                        {
                            _address = value;
                            break;
                        }
                    }
                }
            }
        }
        public string? PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value != "")
                {
                    _phoneNumber = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter valid address: ");
                        value = Console.ReadLine();
                        if (value != "")
                        {
                            _phoneNumber = value;
                            break;
                        }
                    }
                }
            }
        }
        public List<Account> Accounts
        {
            get
            {
                return _accounts;
            }
            set
            {
                _accounts = value;
            }
        }

        // Constructors
        public Customer() { }
        public Customer(int customerId, string name, string address, string phoneNumber)
        {
            this.CustomerId = customerId;
            this.Name = name;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        // Mehtods
        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name} Address: {Address} Phone: {PhoneNumber} Accounts count: {Accounts.Count}");
        }
    }
}
