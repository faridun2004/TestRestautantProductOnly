using TestRestautantProductOnly.Model;

namespace TestRestautantProductOnly.Service
{
    public interface ICartService
    {
        bool UserExists(int userId);
        Cart GetCart(int userId);
        void AddToCart(int userId,CartItem item);
        void RemoveFromCart(int userId,int productId);
        void ClearCart(int userId);
        void UpdateQuantity(int userId, int productId, int newQuantity);
    }
}
