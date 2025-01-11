namespace GymCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GymMember gymMember = new();

            Console.Write("Enter your balance: ");
            gymMember.Amount = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter your gender: ");
            gymMember.Gender = Console.ReadKey().KeyChar;

            Console.WriteLine();

            Console.Write("Enter your age: ");
            gymMember.Age = Convert.ToByte(Console.ReadLine());

            Console.Write("Enter sport name for which you want to buy a card: ");
            gymMember.SelectSport = Console.ReadLine();

            gymMember.BuyACard();

            Console.ReadKey(true);
        }
    }
}
