namespace Debuging_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte number = byte.Parse(Console.ReadLine()!);
            byte rotations = byte.Parse(Console.ReadLine()!);

            if (number > 63)
            {
                Console.WriteLine("Wrong input!");
                return;
            }

            for (int i = 0; i < rotations; i++)
            {
                string direction = Console.ReadLine()!;

                if (direction == "right")
                {
                    int rightMostBit = number & 1;
                    number >>= 1;
                    number |= (byte)(rightMostBit << 5);
                }
                else if (direction == "left")
                {
                    int leftMostBit = (number >> 5) & 1;
                    number <<= 1;
                    number &= 63;
                    number |= (byte)leftMostBit;
                }
            }

            Console.WriteLine(number);
            Console.ReadKey(true);
        }
    }
}
