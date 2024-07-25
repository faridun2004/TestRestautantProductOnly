using ResataurantClient.Models;

namespace ResataurantClient.Services
{
    public interface ICartService
    {
        Task<Cart> GetCart(int userId);
        Task AddToCart(int userId,CartItem item);
        Task RemoveFromCart(int productId, int userId);
        Task ClearCart(int userId);
        Task UpdateQuantity(int userId,int productId, int newQuantity);
    }
}
