namespace DelegateAndEvents
{
    delegate int MyDelegate(int x, int y);

    public class MyClass(int n)
    {
        public int _code = n;

        public int GetNumber(int k, int m)
        {
            return k + m + _code;
        }

        public static int GetFirst(int k, int m)
        {
            return k + m;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new(10);
            MyDelegate math = new(obj.GetNumber);
            MyDelegate math1 = new(MyClass.GetFirst);
            Console.WriteLine(math(2, 3));
            Console.WriteLine(math1(2, 3));
            Console.ReadKey(true);
        }
    }
}
