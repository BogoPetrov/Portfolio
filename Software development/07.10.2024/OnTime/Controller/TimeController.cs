using OnTime.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTime.Model;
using System.Data;

namespace OnTime.Controller
{
    internal class TimeController
    {
        private TimeModel timeInfo = new TimeModel();

        public TimeController()
        {
            timeInfo.SetTimeInfo(TimeView.Input());
            CheckAndOutput();
        }

        public void CheckAndOutput()
        {
            Console.WriteLine();
            TimeSpan timeOfExam = new TimeSpan(timeInfo.HourOfExam, timeInfo.MinsOfExam, 0);
            TimeSpan timeOfStudent = new TimeSpan(timeInfo.HourOfStudent, timeInfo.MinsOfStudent, 0);

            if (timeOfExam.CompareTo(timeOfStudent) > 0)
            {
                if (timeOfExam.Subtract(timeOfStudent).Hours < 1 && timeOfExam.Subtract(timeOfStudent).Minutes <= 30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{timeOfExam.Subtract(timeOfStudent).Minutes} minutes before the start");
                }
                else
                {
                    Console.WriteLine("Early");
                    if (timeOfExam.Subtract(timeOfStudent).Hours >= 1)
                    {
                        if (timeOfExam.Subtract(timeOfStudent).Minutes <= 9)
                        {
                            Console.WriteLine($"{timeOfExam.Subtract(timeOfStudent).Hours}:0{timeOfExam.Subtract(timeOfStudent).Minutes} hours before the start");
                        }
                        else
                        {
                            Console.WriteLine($"{timeOfExam.Subtract(timeOfStudent).Hours}:{timeOfExam.Subtract(timeOfStudent).Minutes} hours before the start");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{timeOfExam.Subtract(timeOfStudent).Minutes} minutes before the start");
                    }
                }
            }
            else if (timeOfExam.CompareTo(timeOfStudent) == 0)
            {
                Console.WriteLine("On time");
            }
            else
            {
                Console.WriteLine("Late");
                if (Math.Abs(timeOfExam.Subtract(timeOfStudent).Hours) >= 1)
                {
                    if (Math.Abs(timeOfExam.Subtract(timeOfStudent).Minutes) <= 9)
                    {
                        Console.WriteLine($"{Math.Abs(timeOfExam.Subtract(timeOfStudent).Hours)}:0{Math.Abs(timeOfExam.Subtract(timeOfStudent).Minutes)} hours after the start"); 
                    }
                    else
                    {
                        Console.WriteLine($"{Math.Abs(timeOfExam.Subtract(timeOfStudent).Hours)}:{Math.Abs(timeOfExam.Subtract(timeOfStudent).Minutes)} hours after the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{Math.Abs(timeOfExam.Subtract(timeOfStudent).Minutes)} minutes after the start");
                }
            }
        }
    }
}
