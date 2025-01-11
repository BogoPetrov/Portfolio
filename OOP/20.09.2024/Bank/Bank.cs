using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Bank
    {
        private readonly List<Customer> _customers = [];
        private static int _idCounter;
        private static readonly double[,] transferMatrix =
        {
           {1,0.5711,0.5115},
           {1.7511,1,0.8957},
           {1.955,1.1164,1}
        };

        public List<Customer> Customers => _customers;

        #region Used
        public void RegisterCustomer()
        {
            Customer customer = new();

            Console.Write("Enter name: ");
            customer.Name = Console.ReadLine();

            Console.Write("Enter address: ");
            customer.Address = Console.ReadLine();

            Console.Write("Enter phone number: ");
            customer.PhoneNumber = Console.ReadLine();

            customer.CustomerId = _idCounter++;
            _customers.Add(customer);

            Console.Clear();
            Console.WriteLine($"Successfully registered customer with name {customer.Name}");
        }

        public void CreateAccount()
        {
            if (_customers.Count != 0)
            {
                Console.Write("Enter name of customer: ");
                string? name = Console.ReadLine();

                Account account = new();
                for (int i = 0; i < _customers.Count; i++)
                {
                    if (_customers[i].Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.Write("Enter balance: ");
                        account.Balance = double.Parse(Console.ReadLine()!);

                        Console.Write("Enter currency type (0 - LEV, 1 - USD, 2 - EURO): ");
                        account.CurrencyType = (CurrencyType)Enum.Parse(typeof(CurrencyType), Console.ReadLine()!);

                        account.AccountNumber = _customers[i].Accounts.Count + 1;
                        account.CustomerId = _customers[i].CustomerId;

                        _customers[i].Accounts.Add(account);

                        Console.Clear();
                        Console.WriteLine($"You have successfully added an account to {name}'s bank account whit {account.Balance} {account.CurrencyType} balance");
                        break;
                    }
                    else if (i == _customers.Count - 1)
                    {
                        Console.WriteLine($"{name} not found");
                    }
                }
            }
            else
            {
                Console.WriteLine("This bank is without customers");
            }
        }

        public void FindCustomerIdByCustomerName()
        {
            if (_customers.Count != 0)
            {
                Console.Write("Enter name of customer: ");
                string? name = Console.ReadLine();

                for (int i = 0; i < _customers.Count; i++)
                {
                    if (_customers[i].Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.WriteLine($"{name} has ID: {_customers[i].CustomerId}");
                        break;
                    }
                    else if (i == _customers.Count - 1)
                    {
                        Console.WriteLine($"{name} not found");
                    }
                }
            }
            else
            {
                Console.WriteLine("This bank is without customers");
            }
        }

        public void DisplayCustomerInfo()
        {
            if (_customers.Count != 0)
            {
                Console.Write("Enter name of customer: ");
                string? name = Console.ReadLine();

                for (int i = 0; i < _customers.Count; i++)
                {
                    if (_customers[i].Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        _customers[i].ShowInfo();
                        break;
                    }
                    else if (i == _customers.Count - 1)
                    {
                        Console.WriteLine($"{name} not found");
                    }
                }
            }
            else
            {
                Console.WriteLine("This bank is without customers");
            }
        }

        public void Deposit()
        {
            if (_customers.Count != 0)
            {
                Console.Write("Enter name of customer: ");
                string? name = Console.ReadLine();

                for (int i = 0; i < _customers.Count; i++)
                {
                    if (_customers[i].Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.Write("Enter account number: ");
                        int accountNumber = int.Parse(Console.ReadLine()!) - 1;

                        if (accountNumber >= 0)
                        {
                            if (_customers[i].Accounts.Count > 0 && _customers[i].Accounts[accountNumber] != null)
                            {
                                Console.Write("Enter amount: ");
                                double amount = double.Parse(Console.ReadLine()!);

                                _customers[i].Accounts[accountNumber].Balance += amount;
                                Console.Clear();
                                Console.WriteLine($"You have successfully added {amount} {_customers[i].Accounts[accountNumber].CurrencyType} to account №{accountNumber + 1} of {name}'s bank account");
                                Console.WriteLine($"Current balance for account №{accountNumber + 1} of {name}'s bank account is {_customers[i].Accounts[accountNumber].Balance} {_customers[i].Accounts[accountNumber].CurrencyType}");
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("This account doesn't exist");
                                break;
                            } 
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong account number");
                            break;
                        }
                    }
                    else if (i == _customers.Count - 1)
                    {
                        Console.WriteLine($"{name} not found");
                    }
                }
            }
            else
            {
                Console.WriteLine("This bank is without customers");
            }
        }

        public void Withdraw()
        {
            if (_customers.Count != 0)
            {
                Console.Write("Enter name of customer: ");
                string? name = Console.ReadLine();

                for (int i = 0; i < _customers.Count; i++)
                {
                    if (_customers[i].Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.Write("Enter account number: ");
                        int accountNumber = int.Parse(Console.ReadLine()!) - 1;

                        if (accountNumber >= 0)
                        {
                            if (_customers[i].Accounts.Count > 0 && _customers[i].Accounts[accountNumber] != null)
                            {
                                Console.Write("Enter amount: ");
                                double amount = double.Parse(Console.ReadLine()!);

                                if (_customers[i].Accounts[accountNumber].Balance >= amount)
                                {
                                    _customers[i].Accounts[accountNumber].Balance -= amount;
                                    Console.Clear();
                                    Console.WriteLine($"You have successfully withdrawn {amount} {_customers[i].Accounts[accountNumber].CurrencyType} from account №{accountNumber + 1} of {name}'s bank account");
                                    Console.WriteLine($"Current balance for account №{accountNumber + 1} of {name}'s bank account is {_customers[i].Accounts[accountNumber].Balance} {_customers[i].Accounts[accountNumber].CurrencyType}");
                                    break;
                                }
                                else if (_customers[i].Accounts[accountNumber].Balance < amount)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"You don't have enough money in account №{accountNumber + 1} of {name}'s bank account");
                                    break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("This account doesn't exist");
                                break;
                            } 
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong account number");
                            break;
                        }
                    }
                    else if (i == _customers.Count - 1)
                    {
                        Console.WriteLine($"{name} not found");
                    }
                }
            }
            else
            {
                Console.WriteLine("This bank is without customers");
            }
        }

        public void TransferToAccount()
        {
            if (_customers.Count != 0)
            {
                Console.Write("Enter name of customer: ");
                string? name = Console.ReadLine();

                for (int i = 0; i < _customers.Count; i++)
                {
                    if (_customers[i].Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.Write("Enter account number form which you want to start this transfer: ");
                        int accountNumberFrom = int.Parse(Console.ReadLine()!) - 1;

                        if (accountNumberFrom >= 0)
                        {
                            if (_customers[i].Accounts.Count > 0 && _customers[i].Accounts[accountNumberFrom] != null)
                            {
                                Console.Write("Enter account number to which you want to end this transfer: ");
                                int accountNumberTo = int.Parse(Console.ReadLine()!) - 1;

                                if (accountNumberTo >= 0)
                                {
                                    if (_customers[i].Accounts[accountNumberTo] != null)
                                    {
                                        Console.Write("Enter amount: ");
                                        double amount = double.Parse(Console.ReadLine()!);

                                        if (_customers[i].Accounts[accountNumberFrom].Balance >= amount)
                                        {
                                            _customers[i].Accounts[accountNumberFrom].Balance -= amount;
                                            _customers[i].Accounts[accountNumberTo].Balance += amount * transferMatrix[Convert.ToInt32(_customers[i].Accounts[accountNumberFrom].CurrencyType), Convert.ToInt32(_customers[i].Accounts[accountNumberTo].CurrencyType)];
                                            Console.Clear();
                                            Console.WriteLine($"Successfully transferred {amount} {_customers[i].Accounts[accountNumberFrom].CurrencyType} from {name}'s №{accountNumberFrom + 1} account to {name}'s №{accountNumberTo + 1} accaunt.\n" +
                                                $"The current balance in account №{accountNumberFrom + 1} is {_customers[i].Accounts[accountNumberFrom].Balance} {_customers[i].Accounts[accountNumberFrom].CurrencyType}.\n" +
                                                $"The current balance in account №{accountNumberTo + 1} is {_customers[i].Accounts[accountNumberTo].Balance} {_customers[i].Accounts[accountNumberTo].CurrencyType}.");
                                            break;
                                        }
                                        else if (_customers[i].Accounts[accountNumberFrom].Balance < amount)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"You don't have enough money in account №{accountNumberFrom + 1} of {name}'s bank account");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("This account doesn't exist");
                                        break;
                                    } 
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Wrong account number");
                                    break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("This account doesn't exist");
                                break;
                            } 
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong account number");
                            break;
                        }
                    }
                    else if (i == _customers.Count - 1)
                    {
                        Console.WriteLine($"{name} not found");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("This bank is without customers");
            }
        }

        public void TransferToOtherCustomerAccount()
        {
            if (_customers.Count != 0)
            {
                Customer customerFrom = new();
                Customer customerTo = new();

                Console.Write("Enter name of customer from whom you want to start this transfer: ");
                string? nameFrom = Console.ReadLine();
                for (int i = 0; i < _customers.Count; i++)
                {
                    if (_customers[i].Name!.Equals(nameFrom, StringComparison.CurrentCultureIgnoreCase))
                    {
                        customerFrom = _customers[i];
                        break;
                    }
                    else if (i == _customers.Count - 1)
                    {
                        Console.WriteLine($"{nameFrom} not found");
                        return;
                    }
                }

                Console.Write("Enter name of customer from whom you want to end this transfer: ");
                string? nameTo = Console.ReadLine();
                for (int i = 0; i < _customers.Count; i++)
                {
                    if (_customers[i].Name!.Equals(nameTo, StringComparison.CurrentCultureIgnoreCase))
                    {
                        customerTo = _customers[i];
                        break;
                    }
                    else if (i == _customers.Count - 1)
                    {
                        Console.WriteLine($"{nameTo} not found");
                        return;
                    }
                }

                Console.Write("Enter account number form which you want to start this transfer: ");
                int accountNumberFrom = int.Parse(Console.ReadLine()!) - 1;
                if (accountNumberFrom >= 0)
                {
                    if (customerFrom.Accounts[accountNumberFrom] != null)
                    {
                        Console.Write("Enter account number to which you want to end this transfer: ");
                        int accountNumberTo = int.Parse(Console.ReadLine()!) - 1;
                        if (accountNumberTo >= 0)
                        {
                            if (customerTo.Accounts.Count > 0 && customerTo.Accounts[accountNumberTo] != null)
                            {
                                Console.Write("Enter amount: ");
                                double amount = double.Parse(Console.ReadLine()!);
                                if (customerFrom.Accounts[accountNumberFrom].Balance >= amount)
                                {
                                    customerFrom.Accounts[accountNumberFrom].Balance -= amount;
                                    customerTo.Accounts[accountNumberTo].Balance += amount * transferMatrix[Convert.ToInt32(customerFrom.Accounts[accountNumberFrom].CurrencyType), Convert.ToInt32(customerTo.Accounts[accountNumberTo].CurrencyType)];
                                    Console.Clear();
                                    Console.WriteLine($"Successfully transferred {amount} {customerFrom.Accounts[accountNumberFrom].CurrencyType} from {nameFrom}'s №{accountNumberFrom + 1} account to {nameTo}'s №{accountNumberTo + 1} accaunt.\n" +
                                                $"The current balance in {nameFrom}'s №{accountNumberFrom + 1} account is {customerFrom.Accounts[accountNumberFrom].Balance} {customerFrom.Accounts[accountNumberFrom].CurrencyType}.\n" +
                                                $"The current balance in {nameTo}'s №{accountNumberTo + 1} account is {customerTo.Accounts[accountNumberTo].Balance} {customerTo.Accounts[accountNumberTo].CurrencyType}.");
                                }
                                else if (customerFrom.Accounts[accountNumberFrom].Balance < amount)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"You don't have enough money in account №{accountNumberFrom + 1} of {nameFrom}'s bank account");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("This account doesn't exist");
                                return;
                            } 
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong account number");
                            return;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("This account doesn't exist");
                        return;
                    } 
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong account number");
                    return;
                }
            }
            else
            {
                Console.WriteLine("This bank is without customers");
            }
        }
        #endregion

        //#region Unused
        //public void RegisterCustomer(string? name, string? address, string? phoneNumber)
        //{
        //    _customers.Add(new Customer(_idCounter++, name!, address!, phoneNumber!));
        //    Console.WriteLine($"Successfully registered customer with name {name}");
        //}

        //public void CreateAccount(string? name, double balance, CurrencyType currencyType)
        //{
        //    for (int i = 0; i < _customers.Count; i++)
        //    {
        //        if (_customers[i].Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase))
        //        {
        //            _customers[i].Accounts.Add(new Account(_customers[i].Accounts.Count + 1, _customers[i].CustomerId, balance, currencyType));
        //            Console.WriteLine($"You have successfully added an account to {name}'s bank account whit {balance} {currencyType} balance");
        //            break;
        //        }
        //        else if (i == _customers.Count - 1)
        //        {
        //            Console.WriteLine($"{name} not found");
        //        }
        //    }
        //}

        //public void FindCustomerIdByCustomerName(string? name)
        //{
        //    for (int i = 0; i < _customers.Count; i++)
        //    {
        //        if (_customers[i].Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase))
        //        {
        //            Console.WriteLine($"{name} has ID: {_customers[i].CustomerId}");
        //            break;
        //        }
        //        else if (i == _customers.Count - 1)
        //        {
        //            Console.WriteLine($"{name} not found");
        //        }
        //    }
        //}

        //public void DisplayCustomerInfo(string? name)
        //{
        //    for (int i = 0; i < _customers.Count; i++)
        //    {
        //        if (_customers[i].Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase))
        //        {
        //            _customers[i].ShowInfo();
        //            break;
        //        }
        //        else if (i == _customers.Count - 1)
        //        {
        //            Console.WriteLine($"{name} not found");
        //        }
        //    }
        //}

        //public void Deposit(string? name, int accountNumber, double amount)
        //{
        //    for (int i = 0; i < _customers.Count; i++)
        //    {
        //        if (_customers[i].Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase))
        //        {
        //            _customers[i].Accounts[accountNumber].Balance += amount;
        //            Console.WriteLine($"You have successfully added {amount} {_customers[i].Accounts[accountNumber].CurrencyType} to account №{accountNumber + 1} of {name}'s bank account");
        //            Console.WriteLine($"Current balance for account №{accountNumber + 1} of {name}'s bank account is {_customers[i].Accounts[accountNumber].Balance} {_customers[i].Accounts[accountNumber].CurrencyType}");
        //            break;
        //        }
        //        else if (i == _customers.Count - 1)
        //        {
        //            Console.WriteLine($"{name} not found");
        //        }
        //    }
        //}

        //public void Withdraw(string? name, int accountNumber, double amount)
        //{
        //    for (int i = 0; i < _customers.Count; i++)
        //    {
        //        if (_customers[i].Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase) && _customers[i].Accounts[accountNumber].Balance >= amount)
        //        {
        //            _customers[i].Accounts[accountNumber].Balance -= amount;
        //            Console.WriteLine($"You have successfully withdrawn {amount} {_customers[i].Accounts[accountNumber].CurrencyType} from account №{accountNumber + 1} of {name}'s bank account");
        //            Console.WriteLine($"Current balance for account №{accountNumber + 1} of {name}'s bank account is {_customers[i].Accounts[accountNumber].Balance} {_customers[i].Accounts[accountNumber].CurrencyType}");
        //            break;
        //        }
        //        else if (_customers[i].Accounts[accountNumber].Balance < amount)
        //        {
        //            Console.WriteLine($"You don't have enough money in account №{accountNumber + 1} of {name}'s bank account");
        //            break;
        //        }
        //        else if (i == _customers.Count - 1)
        //        {
        //            Console.WriteLine($"{name} not found");
        //        }
        //    }
        //}

        //public void TransferToAccount(string? name, int accountNumberFrom, int accountNumberTo, double amount)
        //{
        //    for (int i = 0; i < _customers.Count; i++)
        //    {
        //        if (_customers[i].Name!.Equals(name, StringComparison.CurrentCultureIgnoreCase) && _customers[i].Accounts[accountNumberFrom].Balance >= amount)
        //        {
        //            _customers[i].Accounts[accountNumberFrom].Balance -= amount;
        //            _customers[i].Accounts[accountNumberTo].Balance += amount * transferMatrix[Convert.ToInt32(_customers[i].Accounts[accountNumberFrom].CurrencyType), Convert.ToInt32(_customers[i].Accounts[accountNumberTo].CurrencyType)];
        //            Console.WriteLine($"Successfully transferred {amount} {_customers[i].Accounts[accountNumberFrom].CurrencyType} from {name}'s №{accountNumberFrom + 1} account to {name}'s №{accountNumberTo + 1} accaunt.\n" +
        //                $"The current balance in account №{accountNumberFrom + 1} is {_customers[i].Accounts[accountNumberFrom].Balance} {_customers[i].Accounts[accountNumberFrom].CurrencyType}.\n" +
        //                $"The current balance in account №{accountNumberTo + 1} is {_customers[i].Accounts[accountNumberTo].Balance} {_customers[i].Accounts[accountNumberTo].CurrencyType}.");
        //            break;
        //        }
        //        else if (_customers[i].Accounts[accountNumberFrom].Balance < amount)
        //        {
        //            Console.WriteLine($"You don't have enough money in account №{accountNumberFrom + 1} of {name}'s bank account");
        //            break;
        //        }
        //        else if (i == _customers.Count - 1)
        //        {
        //            Console.WriteLine($"{name} not found");
        //        }
        //    }
        //}

        //public void TransferToOtherCustomerAccount(string? nameFrom, int accountNumberFrom, string? nameTo, int accountNumberTo, double amount)
        //{
        //    Customer customerFrom = new();
        //    Customer customerTo = new();

        //    for (int i = 0; i < _customers.Count; i++)
        //    {
        //        if (_customers[i].Name!.Equals(nameFrom, StringComparison.CurrentCultureIgnoreCase))
        //        {
        //            customerFrom = _customers[i];
        //            break;
        //        }
        //        else if (i == _customers.Count - 1)
        //        {
        //            Console.WriteLine($"{nameFrom} not found");
        //        }
        //    }

        //    for (int i = 0; i < _customers.Count; i++)
        //    {
        //        if (_customers[i].Name!.Equals(nameTo, StringComparison.CurrentCultureIgnoreCase))
        //        {
        //            customerTo = _customers[i];
        //            break;
        //        }
        //        else if (i == _customers.Count - 1)
        //        {
        //            Console.WriteLine($"{nameTo} not found");
        //        }
        //    }

        //    if (customerFrom.Accounts[accountNumberFrom].Balance >= amount)
        //    {
        //        customerFrom.Accounts[accountNumberFrom].Balance -= amount;
        //        customerTo.Accounts[accountNumberTo].Balance += amount * transferMatrix[Convert.ToInt32(customerFrom.Accounts[accountNumberFrom].CurrencyType), Convert.ToInt32(customerTo.Accounts[accountNumberTo].CurrencyType)];
        //        Console.WriteLine($"Successfully transferred {amount} {customerFrom.Accounts[accountNumberFrom].CurrencyType} from {nameFrom}'s №{accountNumberFrom + 1} account to {nameTo}'s №{accountNumberTo + 1} accaunt.\n" +
        //                    $"The current balance in {nameFrom}'s №{accountNumberFrom + 1} account is {customerFrom.Accounts[accountNumberFrom].Balance} {customerFrom.Accounts[accountNumberFrom].CurrencyType}.\n" +
        //                    $"The current balance in {nameTo}'s №{accountNumberTo + 1} account is {customerTo.Accounts[accountNumberTo].Balance} {customerTo.Accounts[accountNumberTo].CurrencyType}.");
        //    }
        //    else if (customerFrom.Accounts[accountNumberFrom].Balance < amount)
        //    {
        //        Console.WriteLine($"You don't have enough money in account №{accountNumberFrom + 1} of {nameFrom}'s bank account");
        //    }
        //}
        //#endregion
    }
}
