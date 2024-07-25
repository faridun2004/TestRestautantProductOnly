namespace TestRestautantProductOnly.Model.Orders
{
    public class OrderItemCreateDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
