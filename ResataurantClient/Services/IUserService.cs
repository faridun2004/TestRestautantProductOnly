using ResataurantClient.Models;

namespace ResataurantClient.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task AddUser(User product, MultipartFormDataContent content);
        Task UpdateUser(User product, MultipartFormDataContent content);
        Task DeleteUser(int id);
    }
}
