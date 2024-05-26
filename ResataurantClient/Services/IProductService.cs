using ResataurantClient.Models;

namespace RestaurantClient.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(Product product, MultipartFormDataContent content);
        Task UpdateProduct(Product product, MultipartFormDataContent content);
        Task DeleteProduct(int id);
    }
}
