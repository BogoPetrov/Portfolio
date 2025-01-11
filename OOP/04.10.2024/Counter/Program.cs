namespace Counter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Questions.Ask();
            Console.WriteLine();
            Questions.Grade();
            Console.ReadKey(true);
        }
    }
}
