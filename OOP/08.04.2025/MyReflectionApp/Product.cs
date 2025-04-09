namespace MyReflectionApp
{
    [Documented("Този клас описва продукт в онлайн магазин.")]
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public string? GetLabel() => $"{Id} - {Name}";
    }
}
