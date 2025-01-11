using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_2
{
    internal class Student : Person
    {
        // Properties
        public List<string?>? Grades { get; set; }
        public List<string?>? Subjects { get; set; }

        // Constructors
        public Student() : base()
        {
            Grades = [];
            Subjects = [];
        }
        public Student(List<string?> grades) : base()
        {
            Grades = grades;
        }
        public Student(List<string?> grades, List<string?> subjects) : this(grades)
        {
            Subjects = subjects;
        }

        // Methods
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Grades count: {Grades!.Count}\nSubjects count: {Subjects!.Count}");
        }

        public override void Input()
        {
            base.Input();

            if (Grades!.Count == 0 && Subjects!.Count == 0 || Grades == null && Subjects == null)
            {
                List<string?> grades;
                List<string?> subjects;

                Console.Write("Grades: ");
                grades = Console.ReadLine()!.Split(" ").ToList()!;

                Console.Write("Subjects: ");
                subjects = Console.ReadLine()!.Split(" ").ToList()!;


                Grades = grades;
                Subjects = subjects; 
            }
        }
    }
}
