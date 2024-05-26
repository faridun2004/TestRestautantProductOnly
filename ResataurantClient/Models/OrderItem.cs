namespace ResataurantClient.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int DishId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
