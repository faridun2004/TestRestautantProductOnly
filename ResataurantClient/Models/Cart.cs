using System.ComponentModel.DataAnnotations;

namespace ResataurantClient.Models
{
    public class Cart
    {
        [Key] 
        public int CartId { get; set; }
        public int UserId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(item => item.Price * item.Quantity);
            }
        }
    }
}
