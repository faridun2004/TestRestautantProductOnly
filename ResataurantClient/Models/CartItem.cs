using System.ComponentModel.DataAnnotations;

namespace ResataurantClient.Models
{
    public class CartItem
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CartItemId { get; internal set; }
    }
}
