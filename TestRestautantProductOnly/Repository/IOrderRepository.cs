using TestRestautantProductOnly.Model.Orders;

namespace TestRestautantProductOnly.Repository
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(int userId,Order order);
        Task<IEnumerable<Order>> GetAllOrdersAsync(int userId);
    }
}
