using Microsoft.EntityFrameworkCore;
using TestRestautantProductOnly.Infractruct;
using TestRestautantProductOnly.Model;
using TestRestautantProductOnly.Model.Orders;

namespace TestRestautantProductOnly.Service
{
    public class OrderService : IOrderService
    {
        private readonly RestaurantContext _context;

        public OrderService(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(int userId,OrderCreateDto orderCreateDto)
        {
            var order = new Order
            {
                UserId = userId,
                CustomerName = orderCreateDto.CustomerName,
                CustomerEmail = orderCreateDto.CustomerEmail,
                CustomerAddress = orderCreateDto.CustomerAddress
            };

            foreach (var item in orderCreateDto.OrderItems)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product != null)
                {
                    var orderItem = new OrderItem
                    {
                        ProductId = product.Id,
                        Name = product.Name,
                        Quantity = item.Quantity,
                        Price = product.Price,
                        ImageUrl = product.ImageUrl
                    };
                    order.OrderItems.Add(orderItem);
                }
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int userId, int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                // Здесь можно добавить дополнительную обработку, например, логирование
                return null;
            }

            return order;
        }
    }
}

