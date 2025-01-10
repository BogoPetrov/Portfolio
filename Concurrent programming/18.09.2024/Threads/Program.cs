internal class Program
{
    private static void Main(string[] args)
    {
        string text = "Hello World!";
        Thread thread = new Thread(() => Print(text));
    }

    public static void Print(string text)
    {
        Console.WriteLine(text);
    }

    public static void Show()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.Write(i);
        }
    }
}