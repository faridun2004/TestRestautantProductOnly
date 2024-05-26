using TestRestautantProductOnly.Model;

namespace TestRestautantProductOnly.Service
{
    public interface IOrderService
    {

        Task<int> CreateOrder(Order order);
        Task<Order> GetOrder(int orderId);
        Task<IEnumerable<Order>> GetOrders();
    }
}
