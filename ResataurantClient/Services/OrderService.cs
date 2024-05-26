using ResataurantClient.Models;
using System.Net.Http.Json;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> CreateOrder()
    {
        var response = await _httpClient.PostAsync("api/order", null);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<int>();
    }

    public async Task<Order> GetOrder(int orderId)
    {
        return await _httpClient.GetFromJsonAsync<Order>($"api/order/{orderId}");
    }

    public async Task<IEnumerable<Order>> GetOrders()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Order>>("api/order");
    }
}
