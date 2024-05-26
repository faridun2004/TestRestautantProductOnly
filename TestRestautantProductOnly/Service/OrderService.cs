using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TestRestautantProductOnly.Model;
using TestRestautantProductOnly.Repository;

namespace TestRestautantProductOnly.Service
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders = new();

        public Task<int> CreateOrder(Order order)
        {
            order.OrderId = _orders.Count + 1;
            _orders.Add(order);
            return Task.FromResult(order.OrderId);
        }

        public Task<Order> GetOrder(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            return Task.FromResult(order);
        }

        public Task<IEnumerable<Order>> GetOrders()
        {
            return Task.FromResult<IEnumerable<Order>>(_orders);
        }
    }
}

