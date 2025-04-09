using System.Reflection;
using System.Text;

namespace Reflection_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Spy spy = new();
            string? result = spy.StealFieldInfo("Reflection_4.Hacker", "username", "password");
            Console.WriteLine(result);
            Console.ReadKey(true);
        }
    }

    public class Hacker
    {
        public string username = "securityGod82";
        private string password = "mySuperSecretPassw0rd";
        public string Password
        {
            get => this.password;
            set => this.password = value;
        }
        private int Id { get; set; }
        public double BankAccountBalance { get; private set; }
        public static void DownloadAllBankAccountsInTheWorld() { }
    }

    public class Spy
    {
        public string? StealFieldInfo(string? investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass!)!;
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder stringBuilder = new();

            object? classInstance = Activator.CreateInstance(classType, [])!;

            stringBuilder.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(field => requestedFields.Contains(field.Name)))
            {
                object? fieldValue = field.GetValue(classInstance);
                stringBuilder.AppendLine($"{field.Name}: {fieldValue}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
