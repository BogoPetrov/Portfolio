namespace Lock_Ex
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Accaunt accaunt = new()
            {
                BankBalance = 1000
            };

            Thread customerThread = new(() => accaunt.Withdraw(200))
            {
                Name = "Customer"
            };

            Thread employeeThread = new(() => accaunt.Deposit(100))
            {
                Name = "Bank employee"
            };

            customerThread.Start();

            Console.WriteLine();

            employeeThread.Start();

            Console.ReadKey(true);
        }
    }
}
