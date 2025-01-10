using OnTime.Controller;
using OnTime.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.View
{
    internal static class TimeView
    {
        public static byte[] Input()
        {
            Console.Write("Enter start hour of exam (0-23): ");
            byte hourOfExam = Convert.ToByte(Console.ReadLine());

            Console.Write("Enter start minutes of exam (0-59): ");
            byte minsOfExam = Convert.ToByte(Console.ReadLine());

            Console.Write("Enter arrival hour of the student (0-23): ");
            byte hourOfStudent = Convert.ToByte(Console.ReadLine());

            Console.Write("Enter arrival minutes of the student (0-59): ");
            byte minsOfStudent = Convert.ToByte(Console.ReadLine());

            return [hourOfExam, minsOfExam, hourOfStudent, minsOfStudent];
        }

    }
}
