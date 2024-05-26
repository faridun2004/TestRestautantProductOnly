using ResataurantClient.Models;

namespace ResataurantClient.Services
{
    public interface ICartService
    {
        Task<Cart> GetCart();
        Task AddToCart(CartItem item);
        Task RemoveFromCart(int productId);
        Task ClearCart();
        Task UpdateQuantity(int productId, int newQuantity);
    }
}
