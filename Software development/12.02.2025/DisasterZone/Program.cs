using System;
using System.Text;
namespace DisasterZone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type something:");
            var input = Console.ReadLine();

            if (input.Length > 5)
            {
                input = input.Substring(0, 5);
            }
            else
            {
                for (int z = 0; z < 5; z++)
                {
                    input += "*";
                }
            }

            string result = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                {
                    result += input[i];
                }
                else
                {
                    result += (char)(input[i] + 1);
                }
            }

            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 100);
            Console.WriteLine("Result so far: " + result);

            Console.WriteLine("Random number is: " + randomNumber);
            if (randomNumber % 2 == 0)
            {
                Console.WriteLine("Generating nonsense...");
                for (int x = 0; x < 3; x++)
                {
                    Console.WriteLine("Spam! Count: " + x);
                    for (int j = 0; j < randomNumber % 10; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Wait! Adding more mess...");
                result = string.Join("-", result.ToCharArray());
                Console.WriteLine("Modified Result: " + result);
            }

            string finalOutput = GetFinalOutput(result, randomNumber);
            Console.WriteLine("Final output: " + finalOutput);
        }

        static string GetFinalOutput(string input, int num)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < num % 10; i++)
            {
                sb.Append(input);
                if (i % 3 == 0)
                {
                    sb.Append("...");
                }
                else
                {
                    sb.Append("!");
                }
            }
            sb.Append("The end."); return sb.ToString();
        }
    }
}