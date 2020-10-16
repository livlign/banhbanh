namespace CoffeeShop.Core.Extension
{
    public class TempIngredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get { return Price * Quantity; } }
    }
}
