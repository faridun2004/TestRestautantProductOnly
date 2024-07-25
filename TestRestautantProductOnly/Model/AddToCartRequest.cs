namespace TestRestautantProductOnly.Model
{
    public class AddToCartRequest
    {
        public int UserId { get; set; }
        public CartItem? Item { get; set; }
    }
}
