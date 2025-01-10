namespace Debuging
{
    internal class Program
    {
        // Optimization: I made an optimization here.
        static readonly Dictionary<string, int> inventory = [];
        static readonly Dictionary<string, double> prices = [];
        static readonly List<string> auditLog = [];
        static readonly Random random = new();

        static void InitializeInventory()
        {
            inventory.Add("Apple", 50);
            inventory.Add("Banana", 10); // Bug: Negative quantity
            inventory.Add("Orange", 20);

            prices.Add("Apple", 0.5);
            prices.Add("Banana", 0.2);
            prices.Add("Orange", 0.7); // Bug: Negative price
            prices.Add("Grapes", 1.2);

            Console.WriteLine("Inventory initialized.");
        }

        static void ManageInventory()
        {
            while (true)
            {
                Console.WriteLine("\nInventory Management:");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Add Item");
                Console.WriteLine("3. Update Price");
                Console.WriteLine("4. Set Bulk Discounts");
                Console.WriteLine("5. Show Summary Of The Inventory");
                Console.WriteLine("6. Go Back");
                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        auditLog.Add("Viewed inventory");
                        ViewInventory();
                        break;
                    case "2":
                        auditLog.Add("Added item");
                        AddItem();
                        break;
                    case "3":
                        auditLog.Add("Updated price");
                        UpdatePrice();
                        break;
                    case "4":
                        auditLog.Add("Set bulk discounts");
                        SetBulkDiscounts();
                        break;
                    case "5":
                        auditLog.Add("Show summary of the inventory");
                        ShowSummary();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void ViewInventory()
        {
            Console.WriteLine("\nCurrent Inventory:");
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Key}: {item.Value} items @ ${prices[item.Key]:0.00} each");
            }
        }

        static void AddItem()
        {
            Console.Write("Enter item name: ");
            string? itemName = Console.ReadLine();

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0) // Bug: Step into if's body, despite the fact the quantity is positive number
            {
                Console.WriteLine("Invalid quantity. Please enter a positive number.");
                return;
            }

            // I decide to make an optimization here.
            if (inventory.TryAdd(itemName!, quantity) && quantity > 0)
            {
                Console.Write("Enter price: ");
                if (!double.TryParse(Console.ReadLine(), out double price))
                {
                    Console.WriteLine("Invalid price. Please enter a positive value.");
                    return;
                }

                if (prices.TryAdd(itemName!, price))
                {
                    Console.WriteLine($"Added {quantity} {itemName}(s) at ${price:0.00} each to inventory.");
                }
            }
            else if (inventory.ContainsKey(itemName!) && quantity > 0)
            {
                inventory[itemName!] += quantity;
                Console.WriteLine($"Successful add {quantity} items of {itemName} to inventory.");
            }
            else
            {
                Console.WriteLine("Unsuccessful attempt to add item to inventory.");
            }

        }

        static void UpdatePrice()
        {
            Console.Write("Enter item name: ");
            string? itemName = Console.ReadLine();

            if (!prices.ContainsKey(itemName!))
            {
                Console.WriteLine("Item not found in inventory.");
                return;
            }

            Console.Write("Enter new price: ");
            if (!double.TryParse(Console.ReadLine(), out double price) || price <= 0)
            {
                Console.WriteLine("Invalid price. Please enter a positive value.");
                return;
            }

            prices[itemName!] = price; // Bug: The new price must be the given form console, not the old one plus the new one

            Console.WriteLine($"Updated {itemName}'s price to ${price:0.00}.");
        }

        static void SetBulkDiscounts()
        {
            Console.Write("Enter item name: ");
            string? itemName = Console.ReadLine();

            if (!prices.TryGetValue(itemName!, out double value))
            {
                Console.WriteLine("Error: Item not found in inventory.");
                return;
            }

            Console.Write("Enter discount percentage (0-100): ");
            if (!double.TryParse(Console.ReadLine(), out double discount) || discount < 0 || discount > 100)
            {
                Console.WriteLine("Invalid discount percentage.");
                return;
            }


            prices[itemName!] = (value * discount / 100); // Bug: The new price must be the calculated with discount given form console, not the old one plus the new calculated one
            Console.WriteLine($"Applied a {discount}% discount to {itemName}. New price: ${prices[itemName!]:0.00}");
        }

        static void ProcessTransactions()
        {
            Console.WriteLine("\nProcessing random transactions...");

            for (int i = 0; i < 5; i++)
            {
                string randomItem = GetRandomItem();

                int quantity = random.Next(1, inventory[randomItem]); // Optimization: To avoid negative quantity and have at least one item 

                inventory[randomItem] -= quantity;

                double total = quantity * prices[randomItem];
                Console.WriteLine($"Processed transaction: Sold {quantity} {randomItem}(s) for ${total:0.00}.");
            }
        }

        static string GetRandomItem()
        {
            if (inventory.Count == 0)
            {
                return null!;
            }
            else
            {
                string[] items = [.. inventory.Keys];
                int index = random.Next(0, inventory.Count);
                return items[index];
            }
        }

        static void ShowSummary()
        {
            Console.WriteLine("\nInventory Summary:");
            int totalItems = 0;
            double totalValue = 0;

            foreach (var item in inventory)
            {
                totalItems += item.Value;
                totalValue = item.Value * prices[item.Key];
            }

            Console.WriteLine($"Total Items: {totalItems}");
            Console.WriteLine($"Total Value: ${totalValue:0.00}");
        }

        static void PerformAudit()
        {
            Console.WriteLine("\nInventory Audit Log:");
            if (auditLog.Count == 0)
            {
                Console.WriteLine("No audit records available.");
                return;
            }

            foreach (string log in auditLog)
            {
                Console.WriteLine(log);
            }
        }

        static void Main()
        {
            Console.WriteLine("Welcome to the Advanced Inventory Manager!");

            InitializeInventory();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Manage Inventory");
                Console.WriteLine("2. Process Transactions");
                Console.WriteLine("3. Inventory Audit");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        auditLog.Add("Managed inventory");
                        ManageInventory();
                        break;
                    case "2":
                        auditLog.Add("Processed transactions");
                        ProcessTransactions();
                        break;
                    case "3":
                        auditLog.Add("Preformed audit");
                        PerformAudit();
                        break;
                    case "4":
                        Console.WriteLine("Exiting program. Goodbye!");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            Console.ReadKey(true);
        }
    }
}
