using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesEmployee
{
    public class Department
    {
        // Field
        private readonly List<Employee> _employees = [];

        // Property
        public List<Employee> Employees
        {
            get
            {
                return _employees;
            }
        }

        // Methods
        public void AddMember(Employee member)
        {
            _employees.Add(member);
        }

        public Employee GetOldest()
        {
            Employee oldest = _employees[0];
            foreach (Employee employee in _employees)
            {
                if (oldest.Age < employee.Age)
                {
                    oldest = employee;
                }
            }

            return oldest;
        }
    }
}
