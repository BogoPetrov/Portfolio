using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StupidPassword.Model;

namespace StupidPassword.Controller
{
    internal class PasswordController
    {
        // Fields
        private readonly PasswordModel _passwordModel = new();

        // Constructor
        public PasswordController()
        {
            Input();
            Run();
            Console.WriteLine();
            Output();
        }

        // Methods
        public void Input()
        {
            Console.Write("Enter n for how much will be the max digit value: ");
            _passwordModel.N = Convert.ToInt16(Console.ReadLine()!);

            Console.Write("Enter l for how much letters from a to z will be used: ");
            _passwordModel.L = Convert.ToInt16(Console.ReadLine());
        }

        public void Run()
        {
            List<char> chars = [];
            char startLeter = 'a';
            for (int i = 0; i < _passwordModel.L; i++)
            {
                chars.Add(Convert.ToChar((short)startLeter + i));
            }

            for (int char1 = 1; char1 <= _passwordModel.N; char1++)
            {
                for (int char2 = 1; char2 <= _passwordModel.N; char2++)
                {
                    for (int char3 = 0; char3 < chars.Count; char3++)
                    {
                        for (int char4 = 0; char4 < chars.Count; char4++)
                        {
                            for (int char5 = 1; char5 <= _passwordModel.N; char5++)
                            {
                                if (char1 < char5 && char2 < char5)
                                {
                                    string password = char1.ToString() + char2.ToString() + chars[char3] + chars[char4] + char5.ToString();
                                    _passwordModel.Passwords.Add(password);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Output()
        {
            Console.WriteLine("Generated passwords:");
            foreach (string password in _passwordModel.Passwords)
            {
                Console.Write(password + " ");
            }
        }
    }
}
