using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter
{
    internal class Questions
    {
        // Fields
        private static string[] _questions = [
            "Била ли е България част от Османската империя повече от 400 години?",
            "Участвала ли е Франция във Втората световна война на страната на нацистка Германия?",
            "Бил ли е Рим първоначално основан като република?",
            "Станала ли е Византия наследник на Римската империя след нейния упадък?",
            "Била ли е Великата китайска стена построена за защита от монголите?",
            "Участвала ли е България в Балканската война през 1912 година?"
        ];
        private static string[] _answers = new string[6];
        private static string[] _keys = ["yes", "no", "no", "yes", "yes", "yes"];

        // Methods
        public static void Ask()
        {
            Console.InputEncoding = Encoding.UTF8;
            string answer;
            for (int i = 0; i < _questions.Length; i++)
            {
                Console.WriteLine(_questions[i]);
                answer = Console.ReadLine()!.ToLower();
                if (answer == "yes" || answer == "no")
                {
                    _answers[i] = answer;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Въведете отново: ");
                        answer = Console.ReadLine()!.ToLower();
                        if (answer == "yes" || answer == "no")
                        {
                            _answers[i] = answer;
                            break;
                        }
                    }
                }
            }
        }

        public static void Grade()
        {
            byte gradePoints = 0;
            for (int i = 0; i < _answers.Length; i++)
            {
                if (_answers[i] == _keys[i])
                {
                    gradePoints++;
                }
            }

            switch (gradePoints)
            {
                case 0:
                    Console.WriteLine("За жалост имате оценка Слаб 2");
                    Console.WriteLine($"Имате {gradePoints} точки");
                    break;
                case 1:
                    Console.WriteLine("Имате оценка Среден 3");
                    Console.WriteLine($"Имате {gradePoints} точки");
                    break;
                case 2:
                    Console.WriteLine("Имате оценка Добър 4");
                    Console.WriteLine($"Имате {gradePoints} точки");
                    break;
                case 3:
                case 4:
                    Console.WriteLine("Имате оценка Много добър 5");
                    Console.WriteLine($"Имате {gradePoints} точки");
                    break;
                case 5:
                case 6:
                    Console.WriteLine("Имате оценка Отличен 6");
                    Console.WriteLine($"Имате {gradePoints} точки");
                    break;
            }
        }
    }
}
