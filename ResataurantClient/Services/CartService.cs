using ResataurantClient.Models;
using System.Net.Http.Json;

namespace ResataurantClient.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Cart> GetCart(int userId)
        {
            return await _httpClient.GetFromJsonAsync<Cart>($"api/cart/{userId}");
        }

        public async Task AddToCart(int userId, CartItem item)
        {
            await _httpClient.PostAsJsonAsync($"api/cart/{userId}", item);
        }

        public async Task RemoveFromCart(int userId, int productId)
        {
            await _httpClient.DeleteAsync($"api/cart/{userId}/{productId}");
        }

        public async Task ClearCart(int userId)
        {
            await _httpClient.DeleteAsync($"api/cart/{userId}/clear");
        }

        public async Task UpdateQuantity(int userId, int productId, int newQuantity)
        {
            var updateQuantityRequest = new { ProductId = productId, NewQuantity = newQuantity };
            await _httpClient.PutAsJsonAsync($"api/cart/{userId}/update-quantity", updateQuantityRequest);
        }
    }

}

