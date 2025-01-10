namespace Bank
{
    internal class Program
    {
        static double bankBalance = 1000;

        static void Main(string[] args)
        {
            clientThread.Start();
            while (clientThread.IsAlive == true)
            {
                continue;
            }
            workerThread.Start();
            while (workerThread.IsAlive == true)
            {
                continue;
            }
            Console.ReadKey(true);
        }

        static Thread clientThread = new Thread(() =>
        {
            double amountToWithdraw = 0;
            Console.Write("Enter amount to withdraw: ");
            amountToWithdraw = double.Parse(Console.ReadLine()!);
            for (int i = 0; i < 3; i++)
            {
                if (bankBalance >= amountToWithdraw)
                {
                    bankBalance -= amountToWithdraw;
                    Console.WriteLine($"Withdrawn amount: {amountToWithdraw}. The current balance is: {bankBalance}");
                }
                else
                {
                    Console.WriteLine("Not enough money!");
                    break;
                }
            }
        });

        static Thread workerThread = new Thread(() =>
        {
            double amountToDeposit = 0;
            Console.Write("Enter amount to deposit: ");
            amountToDeposit = double.Parse(Console.ReadLine()!);
            for (int i = 0; i < 3; i++)
            {
                bankBalance += amountToDeposit;
                Console.WriteLine($"Deposited amount: {amountToDeposit}. The current balance is: {bankBalance}");
            }
        });
    }
}
