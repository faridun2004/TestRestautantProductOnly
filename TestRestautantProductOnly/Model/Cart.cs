using System.ComponentModel.DataAnnotations.Schema;

namespace TestRestautantProductOnly.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(item => item.Price * item.Quantity);
            }
        }

        public Users Users { get; internal set; }
    }
}
