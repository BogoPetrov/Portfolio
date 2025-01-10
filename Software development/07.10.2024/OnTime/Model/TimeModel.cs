using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.Model
{
    internal class TimeModel
    {
        private byte _hourOfExam;
        private byte _minsOfExam;
        private byte _hourOfStudent;
        private byte _minsOfStudent;

        public byte HourOfExam
        {
            get
            {
                return _hourOfExam;
            }
            set
            {
                if (value >= 0 && value < 24)
                {
                    _hourOfExam = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Please enter a valid hour (0-23): ");
                        value = Convert.ToByte(Console.ReadLine());
                        if (value >= 0 && value < 24)
                        {
                            _hourOfExam = value;
                            break;
                        }
                    }
                }
            }
        }

        public byte MinsOfExam
        {
            get
            {
                return _minsOfExam;
            }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    _minsOfExam = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Please enter a valid minutes (0-59): ");
                        value = Convert.ToByte(Console.ReadLine());
                        if (value >= 0 && value <= 59)
                        {
                            _minsOfExam = value;
                            break;
                        }
                    }
                }
            }
        }

        public byte HourOfStudent
        {
            get
            {
                return _hourOfStudent;
            }
            set
            {
                if (value >= 0 && value < 24)
                {
                    _hourOfStudent = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Please enter a valid hour (0-23): ");
                        value = Convert.ToByte(Console.ReadLine());
                        if (value >= 0 && value < 24)
                        {
                            _hourOfStudent = value;
                            break;
                        }
                    }
                }
            }
        }

        public byte MinsOfStudent
        {
            get
            {
                return _minsOfStudent;
            }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    _minsOfStudent = value;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Please enter a valid minutes (0-59): ");
                        value = Convert.ToByte(Console.ReadLine());
                        if (value >= 0 && value <= 59)
                        {
                            _minsOfStudent = value;
                            break;
                        }
                    }
                }
            }
        }

        // Methods
        public void SetTimeInfo(byte[] input)
        {
            HourOfExam = input[0];
            MinsOfExam = input[1];
            HourOfStudent = input[2];
            MinsOfStudent = input[3];
        }
    }
}
