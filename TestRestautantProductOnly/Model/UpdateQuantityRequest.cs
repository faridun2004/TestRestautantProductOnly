namespace TestRestautantProductOnly.Controllers
{
    public class UpdateQuantityRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int NewQuantity { get; set; }
    }
}