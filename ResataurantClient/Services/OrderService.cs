using ResataurantClient.Models;
using System.Net.Http.Json;

namespace ResataurantClient.Services
{
    public class OrderService: IOrderService
    {
        //private readonly HttpClient _httpClient;

        //public OrderService(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        //public async Task<Order> CreateOrderAsync(OrderCreateDto orderCreateDto)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("api/orders", orderCreateDto);
        //    response.EnsureSuccessStatusCode();

        //    return await response.Content.ReadFromJsonAsync<Order>();
        //}

        //public async Task<Order> GetOrderByIdAsync(int id)
        //{
        //    var response = await _httpClient.GetAsync($"api/orders/{id}");
        //    response.EnsureSuccessStatusCode();

        //    return await response.Content.ReadFromJsonAsync<Order>();
        //}
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> PlaceOrder(OrderCreateDto orderCreateDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/orders", orderCreateDto);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, логирование или возврат false
                return false;
            }
        }
    }
}
