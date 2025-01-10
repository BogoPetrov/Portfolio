namespace Debuging
{
    internal class Program
    {
        static void Main()
        {
            string opCode = Console.ReadLine()!;

            long result = 0;
            while (!opCode.Equals("end", StringComparison.OrdinalIgnoreCase))
            {
                string[] codeArgs = opCode.Split(' ');

                switch (codeArgs[0])
                {
                    case "INC":
                        {
                            int operandOne = int.Parse(codeArgs[1]);
                            operandOne++;
                            result = operandOne;
                            break;
                        }
                    case "DEC":
                        {
                            int operandOne = int.Parse(codeArgs[1]);
                            operandOne--;
                            result = operandOne;
                            break;
                        }
                    case "ADD":
                        {
                            int operandOne = int.Parse(codeArgs[1]);
                            int operandTwo = int.Parse(codeArgs[2]);
                            result = operandOne + operandTwo;
                            break;
                        }
                    case "MLA":
                        {
                            int operandOne = int.Parse(codeArgs[1]);
                            int operandTwo = int.Parse(codeArgs[2]);
                            result = (long)operandOne * operandTwo;
                            break;
                        }
                }
                opCode = Console.ReadLine()!;
            }

            Console.WriteLine(result);
            Console.ReadKey(true);
        }
    }
}
