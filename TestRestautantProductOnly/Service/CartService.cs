using TestRestautantProductOnly.Model;

namespace TestRestautantProductOnly.Service
{
    public class CartService : ICartService
    {
        private readonly Dictionary<int, Cart> _carts = new Dictionary<int, Cart>();

        public bool UserExists(int userId)
        {
            // Здесь можно добавить логику для проверки существования пользователя в базе данных
            return true; // Пример для упрощения
        }

        public Cart GetCart(int userId)
        {
            if (!_carts.ContainsKey(userId))
            {
                _carts[userId] = new Cart { UserId = userId };
            }
            return _carts[userId];
        }

        public void AddToCart(int userId, CartItem item)
        {
            var cart = GetCart(userId);
            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                cart.Items.Add(item);
            }
        }

        public void RemoveFromCart(int userId, int productId)
        {
            var cart = GetCart(userId);
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                cart.Items.Remove(item);
            }
        }

        public void ClearCart(int userId)
        {
            var cart = GetCart(userId);
            cart.Items.Clear();
        }

        public void UpdateQuantity(int userId, int productId, int newQuantity)
        {
            var cart = GetCart(userId);
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                if (newQuantity > 0)
                {
                    item.Quantity = newQuantity;
                }
                else
                {
                    cart.Items.Remove(item);
                }
            }
        }
    }

}
