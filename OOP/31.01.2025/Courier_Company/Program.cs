namespace Courier_Company
{
    public class Program
    {
        static void Main(string[] args)
        {
            CourierBranch branch = new()
            {
                Name = "Branch 1",
                Address = "12 Maria Luiza str.",
                Packages =
                [
                    new Package("Ivan Ivanov", "Plovdiv", 10.0m, DateTime.Now),
                    new ExpeditedPackage("Petar Georgiev", "Sofia", 5.0m, DateTime.Now.AddDays(3)),
                    new InternationalPackage("Kalin Ivanov", "UK", 25.0m, DateTime.Now, "UK"),
                ]
            };

            Console.WriteLine($"{branch.Name} : {branch.Address}");
            Console.WriteLine();
            foreach (Package package in branch.Packages!)
            {
                Console.WriteLine($"Package recipient: {package.Recipient}");
                Console.WriteLine($"Package address: {package.Address}");
                Console.WriteLine($"Package weight: {package.Weight} kg");
                Console.WriteLine($"Package delivery cost: {package.GetDeliveryCost()} lv");
                Console.WriteLine($"Package delivery date: {package.GetDeliveryDate()}");
                Console.WriteLine();
            }
            Console.WriteLine($"Total cost: {branch.GetTotalCost()} lv");
            Console.ReadKey(true);
        }
    }

    public class Package(string? recipient, string? address, decimal weight, DateTime? sendDate)
    {
        public string? Recipient { get; set; } = recipient;
        public string? Address { get; set; } = address;
        public decimal Weight { get; set; } = weight;
        public DateTime? SendDate { get; set; } = sendDate;

        public virtual decimal GetDeliveryCost()
        {
            return Weight * 0.6m;
        }

        public virtual DateTime GetDeliveryDate()
        {
            if (SendDate!.Value.DayOfWeek! == DayOfWeek.Saturday || SendDate!.Value.DayOfWeek! == DayOfWeek.Sunday)
            {
                return SendDate!.Value.AddDays(4);
            }
            else
            {
                return SendDate!.Value.AddDays(2);
            }
        }
    }

    public class ExpeditedPackage(string? recipient, string? address, decimal weight, DateTime? sendDate) : Package(recipient, address, weight, sendDate)
    {
        public override decimal GetDeliveryCost()
        {
            return Weight * 0.8m;
        }

        public override DateTime GetDeliveryDate()
        {
            return DateTime.Now.AddDays(1);
        }
    }

    public class InternationalPackage(string? recipient, string? address, decimal weight, DateTime? sendDate, string? countryCode) : Package(recipient, address, weight, sendDate)
    {
        public string? CountryCode { get; set; } = countryCode;

        public override decimal GetDeliveryCost()
        {
            if (CountryCode == "US")
            {
                return Weight * 0.5m;
            }
            else if (CountryCode == "UK")
            {
                return Weight * 0.6m;
            }
            else if (CountryCode == "DE")
            {
                return Weight * 0.7m;
            }
            else
            {
                return Weight * 0.4m;
            }
        }
    }

    public class CourierBranch
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public List<Package>? Packages { get; set; } = [];

        public decimal GetTotalCost()
        {
            decimal totalCost = 0;
            foreach (Package package in Packages!)
            {
                totalCost += package.GetDeliveryCost();
            }
            return totalCost;
        }
    }
}
