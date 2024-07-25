using TestRestautantProductOnly.Model.Orders;

namespace TestRestautantProductOnly.Model
{
    public class Users
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Photo {  get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
    }
}
