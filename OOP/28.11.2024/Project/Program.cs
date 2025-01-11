namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ItemsInFrige itemsInFrige = new();
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("CALORIE CALCULATOR");
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("1. Add product\n2. Print products\n3. Find product by index\n4. Eat product\n5. Exit");
                Console.WriteLine("-------------------------");
                Console.Write("Please enter your choice: ");
                int choice = int.Parse(Console.ReadLine()!);
                switch (choice)
                {
                    case 1:
                        itemsInFrige.AddProduct();
                        break;
                    case 2:
                        itemsInFrige.PrintProducts();
                        break;
                    case 3:
                        itemsInFrige.FindProduct();
                        break;
                    case 4:
                        itemsInFrige.EatProduct();
                        break;
                    case 5:
                        Console.ReadKey(true);
                        return;
                }
                Console.ReadKey(true);
                Console.Clear();
            }

        }
    }

    public class ItemsInFrige
    {
        public float Balance { get; set; } = 500;
        public List<Product> Products { get; set; } = [];
        public short DailyCalories { get; set; }

        public void PrintProducts()
        {
            foreach (var product in Products)
            {
                product.PrintProduct();
            }
        }

        public void AddProduct()
        {
            Product product;
            Console.Write("Enter product category 1 - meat, 2 - dairy, 3 - vegetable, 4 - fruit: ");
            string? input = Console.ReadLine();
            product = Convert.ToByte(input) switch
            {
                1 => new MeatProducts(),
                2 => new DairyProducts(),
                3 => new VegProducts(),
                4 => new FruitProducts(),
                _ => null!
            };
            Console.Write("Enter product name: ");
            product.Name = Console.ReadLine();
            Console.Write("Enter product price: ");
            product.Price = float.Parse(Console.ReadLine()!);
            Console.Write("Enter product clalories: ");
            product.Clalories = Convert.ToInt16(Console.ReadLine());
            Balance -= product.Price;
            Console.WriteLine($"Left balance: {Math.Round(Balance, 2)}");
            Products.Add(product);
        }

        public void FindProduct()
        {
            Console.Write("Enter index of product to find: ");
            byte index = (byte)(Convert.ToByte(Console.ReadLine()) - 1);
            for (int i = 0; i < Products.Count; i++)
            {
                if (i == index)
                {
                    Console.WriteLine($"In the position {index + 1} is {Products[i].Name}");
                    break;
                }
            }
        }

        public void EatProduct()
        {
            Console.Write("Enter index of product to eat: ");
            byte index = (byte)(Convert.ToByte(Console.ReadLine()) - 1);
            for (int i = 0; i < Products.Count; i++)
            {
                if (i == index)
                {
                    Products[i].Eat();
                    DailyCalories += Products[i].Clalories;
                    break;
                }
            }
            Console.WriteLine($"Daily calories: {DailyCalories}");
            Products.RemoveAt(index);
        }

    }

    public abstract class Product
    {
        public string? Name { get; set; }
        public float Price { get; set; }
        public short Clalories { get; set; }

        public void PrintProduct()
        {
            Console.WriteLine($"The product {Name} - price: {Price}, clalories: {Clalories}");
        }

        public abstract void Eat();
    }

    public class MeatProducts : Product
    {
        public override void Eat()
        {
            Console.WriteLine($"Eating meat product {Name} with calories {Clalories}");
        }
    }

    public class DairyProducts : Product
    {
        public override void Eat()
        {
            Console.WriteLine($"Eating dairy product {Name} with calories {Clalories}");
        }
    }

    public class VegProducts : Product
    {
        public override void Eat()
        {
            Console.WriteLine($"Eating vegetable product {Name} with calories {Clalories}");
        }
    }

    public class FruitProducts : Product
    {
        public override void Eat()
        {
            Console.WriteLine($"Eating fiut product {Name} with calories {Clalories}");
        }
    }
}
