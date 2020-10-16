namespace CoffeeShop.Core.Extension
{
    public class TempOrderItem
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal TotalPrice
        {
            get { return Price * Qty; }
        }
    }
}
