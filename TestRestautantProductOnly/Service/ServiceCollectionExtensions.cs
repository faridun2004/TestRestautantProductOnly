using FluentAssertions.Common;
using TestRestautantProductOnly.Repository;

namespace TestRestautantProductOnly.Service
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMyServices(this IServiceCollection service)
        {           
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddSingleton<ICartService, CartService>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IShipmentRepository, ShipmentRepository>();
        }
    }
}
