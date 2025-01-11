namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> performances = new()
            {
                { "Hamlet", 20.0m },
                { "Romeo and Juliet", 18.5m },
                { "Macbeth", 22.0m },
                { "Othello", 19.5m },
                { "King Lear", 21.0m }
            };

            List<Ticket> tickets = [];

            string? input;
            while (true)
            {
                Console.WriteLine("Avilable performances: ");
                foreach (string performance in performances.Keys)
                {
                    Console.WriteLine($"- {performance}");
                }

                Console.Write("Preformance? (or type 'exit' to quit): ");
                input = Console.ReadLine();
                string? performanceName = input;

                if (input!.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                Console.Write("Ticket type? ([regular] or with [discount] for students or pensioners): ");
                input = Console.ReadLine();
                string? ticketType = input;

                Console.Write("Name: ");
                input = Console.ReadLine();
                string? name = input;

                Console.Write("Age: ");
                input = Console.ReadLine();
                int age = Convert.ToInt32(input);

                if (ticketType!.Equals("discount", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine();
                    Discount_Ticket ticket = new(name, age)
                    {
                        PerformanceName = performanceName,
                        Price = performances[performanceName!]
                    };
                    tickets.Add(ticket);
                    Console.WriteLine(ticket.GetTicketInfo());
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Ticket ticket = new(name, age)
                    {
                        PerformanceName = performanceName,
                        Price = performances[performanceName!]
                    };
                    tickets.Add(ticket);
                    Console.WriteLine(ticket.GetTicketInfo());
                    Console.WriteLine();
                }

            }
            Console.ReadKey(true);
        }
    }
}
