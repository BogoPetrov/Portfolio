namespace Exercise_Generic_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            People<Employee> employees = new();

            employees.Add(new Employee { EmployeeNumber = 1, FirstName = "John", LastName = "Doe", HourlySalary = 1000 });
            employees.Add(new Employee { EmployeeNumber = 2, FirstName = "Jane", LastName = "Doe", HourlySalary = 2000 });
            employees.Add(new Employee { EmployeeNumber = 3, FirstName = "Bob", LastName = "Smith", HourlySalary = 3000 });

            Console.WriteLine("--------------------------------------");
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees.Get(i).ToString());
                Console.WriteLine("--------------------------------------");
            }

            Console.ReadKey(true);
        }
    }

    public interface IPersons<T>
    {
        public int Count { get; }
        public T Get(int index);
        public void Add(T item);
    }

    public class People<T> : IPersons<T>
    {
        private int _size;
        private T[] _persons = [];

        public People()
        {
            _size = 0;
            _persons = new T[10];
        }

        public int Count { get => _size; }
        public T Get(int index) => _persons[index];
        public void Add(T item)
        {
            if (_size == _persons.Length)
            {
                T[] newPersons = new T[_persons.Length * 2];
                Array.Copy(_persons, newPersons, _persons.Length);
                _persons = newPersons;
            }
            _persons[_size++] = item;
        }
    }

    public class Employee
    {
        public long EmployeeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public double HourlySalary { get; set; }

        public override string ToString()
        {
            return $"Employee #: {EmployeeNumber}\nFirst Name: {FirstName}\nLast Name: {LastName}\nHourly Salary: {HourlySalary}";
        }
    }
}
