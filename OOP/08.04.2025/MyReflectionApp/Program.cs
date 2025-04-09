namespace MyReflectionApp
{
    internal class Program
    {
        private static void Main()
        {
            HtmlDocGenerator.GenerateHtmlDocumentation("documentation.html");
            Console.ReadKey(true);
        }
    }
}
