using ResataurantClient.Models;
using RestaurantClient.Services;
using System.Net.Http.Json;

namespace ResataurantClient.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/products");
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
        }

        public async Task AddProduct(Product product, MultipartFormDataContent content)
        {
            var response = await _httpClient.PostAsync("api/products", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProduct(Product product, MultipartFormDataContent content)
        {
            var response = await _httpClient.PutAsync($"api/products/{product.Id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProduct(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/products/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
