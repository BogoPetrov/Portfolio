using MyTimer = System.Timers.Timer;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace MyReflectionApp
{
    internal class Program
    {
        private static MyTimer? _timer;
        private static string? _lastProductHash;

        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Изчисляване на първоначалния хеш на Product.cs
            string productFilePath = "S:\\Programming\\Learning\\C\\C#\\School\\Work in class\\Bogomil Petrov 11a\\OOP\\08.04.2025\\MyReflectionApp\\Product.cs";
            _lastProductHash = ComputeFileHash(productFilePath);

            // Настройка на таймера с интервал от 5 секунди
            _timer = new MyTimer(5000); // 5000ms = 5 секунди
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = false; // Таймерът се изпълнява само веднъж
            _timer.Start();

            Console.WriteLine("Приложението ще се рестартира след 5 секунди...");
            Console.ReadKey(true);
        }

        private static void OnTimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Таймерът изтече. Проверка за промени в Product.cs...");

            // Проверка за промени в Product.cs
            string productFilePath = "S:\\Programming\\Learning\\C\\C#\\School\\Work in class\\Bogomil Petrov 11a\\OOP\\08.04.2025\\MyReflectionApp\\Product.cs";

            string currentHash = ComputeFileHash(productFilePath);
            if (_lastProductHash != currentHash)
            {
                Console.WriteLine("Открита е промяна в Product.cs. Генериране на нова HTML документация...");
                HtmlDocGenerator.GenerateHtmlDocumentation("documentation.html");
                _lastProductHash = currentHash; // Обновяване на хеша
            }
            else
            {
                Console.WriteLine("Няма промени в Product.cs. Пропускане на обновяването.");
            }

            RestartApplication();
        }

        private static string ComputeFileHash(string filePath)
        {
            using var sha256 = SHA256.Create();
            using var stream = File.OpenRead(filePath);
            var hash = sha256.ComputeHash(stream);
            return Convert.ToBase64String(hash);
        }

        private static void RestartApplication()
        {
            try
            {
                // Стартиране на нова инстанция на текущото приложение
                Process.Start(Process.GetCurrentProcess().MainModule?.FileName!);

                // Изход от текущата инстанция
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка при рестартиране на приложението: {ex.Message}");
            }
        }
    }
}
