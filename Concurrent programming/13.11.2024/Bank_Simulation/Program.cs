namespace Banck_Simulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new(1000000.00m);
            Console.WriteLine($"The start balance is: {bank.Balance}");
            List<Thread> threads =
            [
                new Thread(() => bank.DeductFee(1.50m)) { Name = "EmployeeFee" },
                new Thread(() => bank.Deposit(50.00m)) { Name = "EmployeeDeposit" },
                new Thread(() => bank.Deposit(100.00m)) { Name = "EmployeeDeposit" },
                new Thread(() => bank.Withdraw(100.00m)) { Name = "Customer1" },
                new Thread(() => bank.Withdraw(200.00m)) { Name = "Customer2" }
            ];

            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Start();
            }

            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine($"The current balance is: {bank.Balance}");

            Console.ReadKey(true);
        }
    }

    public class Bank
    {
        // Properties for data
        public decimal Balance { get; set; }

        // Constructor
        public Bank(decimal initialBalance)
        {
            if (initialBalance > 0)
            {
                Balance = initialBalance;
            }
            else
            {
                throw new ArgumentException("The value must be greater than zero!");
            }
        }

        // Methods for bank operations
        public void Deposit(decimal amount)
        {
            lock (this)
            {
                if (amount > 0)
                {
                    Balance += amount;
                    Console.WriteLine($"Current balance: {Balance}");
                }
                else
                {
                    throw new InvalidOperationException("The amout must be greater than zero!");
                }
            }
        }

        public void DeductFee(decimal amount)
        {
            lock (this)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine($"Current balance: {Balance}");
                }
                else
                {
                    throw new InvalidOperationException("Insufficient balance!");
                }
            }
        }

        public void Withdraw(decimal amount)
        {
            lock (this)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine($"Current balance: {Balance}");
                }
                else
                {
                    throw new InvalidOperationException("Insufficient balance!");
                }
            }
        }
    }

    public class BankPerson(Bank bank)
    {
        public Bank? Bank { get; set; } = bank;


    }

    public class BankEmployee(Bank bank) : BankPerson(bank)
    {
        //public void Pr { get; set; }
    }

    public class BankCustom(Bank bank) : BankPerson(bank) { }
}
