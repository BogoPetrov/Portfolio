namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank myBank = new();
            string command = string.Empty;
            while (command.Equals("exit", StringComparison.CurrentCultureIgnoreCase) == false)
            {
                Console.WriteLine("CHOOSE COMMAND:\n" +
                    "---------------------------------------\n" +
                    "REGCUST - TO REGISTER NEW CUSTOMER\n" +
                    "CREATACC - TO CREATE NEW ACCOUNT TO CUSTOMER\n" +
                    "FINDID - TO FIND CUSTOMER ID BY CUSTOMER NAME\n" +
                    "DISPLAY - TO DISPLAY ALL INFORMATION ABOUT CUSTOMER BY NAME\n" +
                    "DEP - TO DEPOSIT MONEY TO CUSTOMER ACCOUNT\n" +
                    "WITH - TO WITHDRAW MONEY FROM CUSTOMER ACCOUNT\n" +
                    "TRANSFER - TO TRANSFER MONEY FROM ONE CUSTOMER ACCOUNT TO ANOTHER\n" +
                    "TRANSFERACC - TO TRANSFER MONEY FROM ONE CUSTOMER ACCOUNT TO ANOTHER CUSTOMER ACCOUNT\n" +
                    "EXIT - TO EXIT PROGRAM\n" +
                    "---------------------------------------");
                command = Console.ReadLine()!;
                switch (command.ToLower())
                {
                    case "regcust":
                        Console.Clear();
                        myBank.RegisterCustomer();
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case "creatacc":
                        Console.Clear();
                        myBank.CreateAccount();
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case "findid":
                        Console.Clear();
                        myBank.FindCustomerIdByCustomerName();
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case "display":
                        Console.Clear();
                        myBank.DisplayCustomerInfo();
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case "dep":
                        Console.Clear();
                        myBank.Deposit();
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case "with":
                        Console.Clear();
                        myBank.Withdraw();
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case "transfer":
                        Console.Clear();
                        myBank.TransferToAccount();
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case "transferacc":
                        Console.Clear();
                        myBank.TransferToOtherCustomerAccount();
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case "exit":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("WRONG COMMAND");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("THANKS FOR USING MY PROGRAM");
            Console.ReadKey(true);
        }
    }
}
