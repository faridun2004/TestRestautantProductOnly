using Microsoft.EntityFrameworkCore;
using TestRestautantProductOnly.Infractruct;
using TestRestautantProductOnly.Model.Orders;

namespace TestRestautantProductOnly.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantContext _context;

        public OrderRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(int userId,Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(int userId)
        {
            return await _context.Orders.ToListAsync();
        }
    }
}
