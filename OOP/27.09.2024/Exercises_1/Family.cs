using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_1
{
    internal class Family
    {
        private List<Person> _family = new List<Person>();

        public void AddMembers()
        {
            Console.Write("Enter the count of member for this family: ");
            int memberCount = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < memberCount; i++)
            {
                Person member = new Person();

                Console.Write($"Enter name of {i + 1} person of this family: ");
                member.Name = Console.ReadLine()!;
                Console.Write($"Enter age of {i + 1} person of this family: ");
                member.Age = short.Parse(Console.ReadLine()!);
                _family.Add(member);

                Console.WriteLine();
            }
        }

        public void AddMembers(Person member)
        {
            _family.Add(member);
        }

        public void PrintMembers()
        {
            foreach (Person member in _family)
            {
                Console.WriteLine($"Name: {member.Name}, Age: {member.Age}");
            }
        }

        public void Statistics()
        {
            List<Person> membersToShow = new List<Person>();
            foreach (Person member in _family)
            {
                if (member.Age > 30)
                {
                    membersToShow.Add(member);
                }
            }

            for (int i = 0; i < membersToShow.Count; i++)
            {
                for (int j = 0; j < membersToShow.Count - 1 - i; j++)
                {
                    if (membersToShow[j].Name!.ToLower().CompareTo(membersToShow[j + 1].Name!.ToLower()) > 0)
                    {
                        Person temp = membersToShow[j];
                        membersToShow[j] = membersToShow[j + 1];
                        membersToShow[j + 1] = temp;
                    }
                }
            }

            foreach (Person member in membersToShow)
            {
                Console.WriteLine($"Name: {member.Name}, Age: {member.Age}");
            }
        }
    }
}
