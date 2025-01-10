using StupidPassword.View;

namespace StupidPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PasswordView.Start();
            Console.ReadKey(true);
        }
    }
}
