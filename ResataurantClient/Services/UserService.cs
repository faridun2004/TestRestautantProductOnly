using ResataurantClient.Models;
using ResataurantClient.Services;
using RestaurantClient.Services;
using System.Net.Http.Json;

namespace ResataurantClient.Services
{
    public class UserService: IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<User>>("api/users");
        }

        public async Task<User> GetUserById(int id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"api/users/{id}");
        }

        public async Task AddUser(User user, MultipartFormDataContent content)
        {
            var response = await _httpClient.PostAsync("api/users", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateUser(User user, MultipartFormDataContent content)
        {
            var response = await _httpClient.PutAsync($"api/users/{user.Id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUser(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/users/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

