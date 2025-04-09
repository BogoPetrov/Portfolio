using System;
namespace BadCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter num1:");
            var x = Console.ReadLine();
            Console.WriteLine("Enter num2:");
            var y = Console.ReadLine();

            int xx = 0, yy = 0, zz = 0;
            try
            {
                xx = Convert.ToInt32(x);
                yy = Convert.ToInt32(y);
            }
            catch
            {
                Console.WriteLine("Oops something went wrong lol");
                Console.WriteLine("Bye");
                return;
            }
            Console.WriteLine("Pick 1:add, 2:sub, 3:mul, 4:div");
            string z = Console.ReadLine();

            if (z == "1")
            {
                zz = xx + yy;
                Console.WriteLine("Result is " + zz);
                Console.WriteLine("Nice work!");
            }
            else
            {
                if (z == "2")
                {
                    zz = xx - yy;
                    Console.WriteLine("Result is " + zz);
                    Console.WriteLine("Goodbye");
                }
                else
                {
                    if (z == "3")
                    {
                        zz = xx * yy; Console.WriteLine("Result = " + zz);
                    }
                    else
                    {
                        if (z == "4")
                        {
                            if (yy == 0)
                            {
                                Console.WriteLine("NOPE!!! Cannot divide by ZERO!!");
                                return;
                            }
                            zz = xx / yy;
                            Console.WriteLine("Final answer: " + zz);
                        }
                        else
                        {
                            Console.WriteLine("IDK what you picked, try again later");
                        }
                    }
                }
            }

            Console.WriteLine("DONE");
            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine("Counting: " + i);
                }
            }
        }
    }
}