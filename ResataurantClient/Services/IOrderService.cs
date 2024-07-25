using ResataurantClient.Models;

namespace ResataurantClient.Services
{
    public interface IOrderService
    {
        //Task<Order> CreateOrderAsync(OrderCreateDto orderCreateDto);
        //Task<Order> GetOrderByIdAsync(int id);
        Task<bool> PlaceOrder(OrderCreateDto orderCreateDto);
    }
}
