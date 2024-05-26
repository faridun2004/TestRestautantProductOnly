using ResataurantClient.Models;

public interface IOrderService
{
    Task<int> CreateOrder();
    Task<Order> GetOrder(int orderId);
    Task<IEnumerable<Order>> GetOrders();
}