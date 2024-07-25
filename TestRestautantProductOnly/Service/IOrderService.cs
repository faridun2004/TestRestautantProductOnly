using TestRestautantProductOnly.Model.Orders;

namespace TestRestautantProductOnly.Service
{
    public interface IOrderService
    {

        Task<Order> CreateOrderAsync(int userId,OrderCreateDto orderCreateDto);
        Task<Order> GetOrderByIdAsync(int userId,int id);
    }
}
