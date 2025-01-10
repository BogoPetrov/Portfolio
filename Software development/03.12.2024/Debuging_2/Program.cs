namespace Debuging_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine()!;
            int jump = int.Parse(Console.ReadLine()!);

            const char Search = 'p';
            bool hasMatch = false;
            string matchedString;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == Search)
                {
                    hasMatch = true;

                    int endIndex = jump + 1;

                    if (endIndex > text.Length)
                    {
                        endIndex = text.Length;
                    }

                    if (text.Length - i < endIndex)
                    {
                        matchedString = text[i..];
                    }
                    else
                    {
                        matchedString = text.Substring(i, endIndex);
                    }
                    Console.WriteLine(matchedString);
                    i += jump;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
            Console.ReadKey(true);
        }
    }
}
