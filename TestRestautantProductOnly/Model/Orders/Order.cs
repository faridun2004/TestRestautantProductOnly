using System.ComponentModel.DataAnnotations.Schema;

namespace TestRestautantProductOnly.Model.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public decimal TotalPrice
        {
            get
            {
                return OrderItems.Sum(item => item.Price * item.Quantity);
            }
        }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public Users? Users { get; set; }
    }
}